import json
import unittest
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
CLIENT = ROOT / "riseOfReign" / "client"
DATA = CLIENT / "assets" / "events" / "flad_rasputin_prologue.json"
SCRIPT = CLIENT / "scripts" / "flad_prologue.gd"
SCENE = CLIENT / "scenes" / "flad_prologue.tscn"
MAIN_SCRIPT = CLIENT / "scripts" / "main.gd"
MAIN_SCENE = CLIENT / "scenes" / "main.tscn"
SESSION = CLIENT / "scripts" / "game_session.gd"


class FladRasputinPrologueTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        cls.data = json.loads(DATA.read_text(encoding="utf-8"))
        cls.script = SCRIPT.read_text(encoding="utf-8")
        cls.scene = SCENE.read_text(encoding="utf-8")
        cls.main_script = MAIN_SCRIPT.read_text(encoding="utf-8")
        cls.main_scene = MAIN_SCENE.read_text(encoding="utf-8")
        cls.session = SESSION.read_text(encoding="utf-8")

    def test_solo_routes_to_flad_birth_prologue(self):
        self.assertIn("NEUES SPIEL · FLAD RASPUTIN", self.main_scene)
        self.assertIn('FLAD_PROLOGUE_SCENE := "res://scenes/flad_prologue.tscn"', self.main_script)
        self.assertIn("GameSession.start_solo()", self.main_script)
        self.assertIn("get_tree().change_scene_to_file(FLAD_PROLOGUE_SCENE)", self.main_script)
        self.assertIn('change_scene_to_file("res://scenes/avatar_select.tscn")', self.main_script)

    def test_prologue_starts_with_birth_and_reaches_1933(self):
        events = self.data["events"]
        self.assertGreaterEqual(len(events), 12)
        self.assertEqual(events[0]["stage"], "geburt")
        self.assertEqual(events[0]["id"], "birth_year")
        self.assertEqual(events[-1]["stage"], "übergabe")
        self.assertEqual(self.data["handover_date"], "1933-01-01")
        stages = {event["stage"] for event in events}
        self.assertTrue({"geburt", "kindheit", "jugend", "netzwerk", "inventar", "krise", "büro", "übergabe"}.issubset(stages))

    def test_every_question_is_an_event_with_visible_consequences(self):
        ids = set()
        for event in self.data["events"]:
            self.assertNotIn(event["id"], ids)
            ids.add(event["id"])
            self.assertTrue(event["title"])
            self.assertTrue(event["body"])
            self.assertTrue(event["question"])
            self.assertTrue(event["learning"])
            self.assertGreaterEqual(len(event["choices"]), 3)
            for choice in event["choices"]:
                self.assertTrue(choice["label"])
                self.assertTrue(choice["description"])
                self.assertTrue(choice["result"])
                self.assertTrue(choice["effects"] or choice["set"] or choice["items"] or choice["companions"])
                self.assertLessEqual(max([abs(v) for v in choice["effects"].values()] or [0]), 10)

    def test_birth_questions_cover_year_place_conditions_and_origin(self):
        ids = {event["id"] for event in self.data["events"]}
        self.assertTrue({"birth_year", "birthplace", "birth_conditions", "family_origin"}.issubset(ids))
        birthplace = next(event for event in self.data["events"] if event["id"] == "birthplace")
        self.assertGreaterEqual(len(birthplace["choices"]), 4)
        for choice in birthplace["choices"]:
            self.assertIn("birthplace", choice["set"])
            self.assertIn("birth_region", choice["set"])

    def test_face_items_and_companions_are_visible(self):
        portrait = CLIENT / "assets" / "portraits" / "flad_rasputin.svg"
        self.assertTrue(portrait.exists())
        portrait_text = portrait.read_text(encoding="utf-8")
        self.assertIn("<svg", portrait_text)
        self.assertIn("<ellipse", portrait_text)
        self.assertIn("FLAD RASPUTIN", portrait_text)
        self.assertGreaterEqual(len(self.data["item_catalog"]), 7)
        self.assertGreaterEqual(len(self.data["companion_catalog"]), 4)
        rewarded_items = {item for event in self.data["events"] for choice in event["choices"] for item in choice["items"]}
        rewarded_companions = {item for event in self.data["events"] for choice in event["choices"] for item in choice["companions"]}
        self.assertTrue(rewarded_items)
        self.assertEqual(rewarded_companions, set(self.data["companion_catalog"]))

    def test_scene_has_event_card_portrait_inventory_and_team(self):
        for node in (
            "Portrait", "EventImage", "EventTitle", "EventBody", "Question", "Choices",
            "Stats", "TraitsFlow", "ItemsFlow", "CompanionsFlow", "History", "Progress"
        ):
            self.assertIn(f'name="{node}"', self.scene)
        self.assertIn("flad_rasputin.svg", self.scene)
        self.assertIn("office_command.svg", self.script)
        self.assertIn("meeting_room.svg", self.script)

    def test_autosave_and_handover_to_office(self):
        for token in (
            'SAVE_PATH := "user://flad_rasputin_prologue.json"',
            "func _save()",
            "func _load_or_initialize()",
            "func _choose_event(",
            "func _show_summary()",
            "func _enter_office()",
            "GameSession.complete_flad_prologue(profile)",
            'office.set("avatar_id", "custom")',
            'office.set("avatar_display_name", "Flad Rasputin")',
        ):
            self.assertIn(token, self.script)
        self.assertIn("flad_prologue_completed", self.session)
        self.assertIn("set_flad_prologue_progress", self.session)
        self.assertIn("reset_flad_prologue", self.session)

    def test_portrayal_is_fictional_and_non_glorifying(self):
        self.assertIn("fiktive Spielfigur", self.data["portrayal_note"])
        for path in [CLIENT / "assets" / "portraits" / "flad_rasputin.svg"]:
            text = path.read_text(encoding="utf-8").lower()
            for forbidden in ("swastika", "hakenkreuz", "ss-rune"):
                self.assertNotIn(forbidden, text)


if __name__ == "__main__":
    unittest.main()
