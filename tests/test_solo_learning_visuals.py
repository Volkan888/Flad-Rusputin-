import json
import unittest
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
CLIENT = ROOT / "riseOfReign" / "client"
EPOCH = ROOT / "riseOfReign" / "data" / "epochs" / "1933"


class SoloLearningVisualTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        cls.project = (CLIENT / "project.godot").read_text(encoding="utf-8")
        cls.main_scene = (CLIENT / "scenes" / "main.tscn").read_text(encoding="utf-8")
        cls.main_gd = (CLIENT / "scripts" / "main.gd").read_text(encoding="utf-8")
        cls.avatar_scene = (CLIENT / "scenes" / "avatar_select.tscn").read_text(encoding="utf-8")
        cls.avatar_gd = (CLIENT / "scripts" / "avatar_select.gd").read_text(encoding="utf-8")
        cls.session_gd = (CLIENT / "scripts" / "game_session.gd").read_text(encoding="utf-8")
        cls.visual_gd = (CLIENT / "scripts" / "visual_room_controller.gd").read_text(encoding="utf-8")
        cls.timer_gd = (CLIENT / "scripts" / "turn_timer_widget.gd").read_text(encoding="utf-8")
        cls.office_scene = (CLIENT / "scenes" / "office_hub.tscn").read_text(encoding="utf-8")
        cls.learning = json.loads((CLIENT / "assets" / "learning" / "knowledge_cards_1933.json").read_text(encoding="utf-8"))
        cls.solo = json.loads((EPOCH / "solo_learning_mode.json").read_text(encoding="utf-8"))
        cls.manifest = json.loads((EPOCH / "manifest.json").read_text(encoding="utf-8"))

    def test_solo_session_is_explicit_and_persistent(self):
        self.assertIn('GameSession="*res://scripts/game_session.gd"', self.project)
        self.assertIn('FLAD RASPUTIN', self.main_scene)
        self.assertIn('SOLO-PROLOG', self.main_scene)
        self.assertIn('MULTIPLAYER · 2 GEGEN 2', self.main_scene)
        self.assertIn('GameSession.start_solo()', self.main_gd)
        self.assertIn('FLAD_PROLOGUE_SCENE', self.main_gd)
        self.assertIn('GameSession.start_multiplayer()', self.main_gd)
        self.assertIn('user://riseofreign_session.cfg', self.session_gd)
        self.assertIn('deterministische strategische Simulation', self.session_gd)

    def test_avatar_screen_has_solo_controls(self):
        for node in ("Difficulty", "History", "Timer", "LearningToggle"):
            self.assertIn(f'name="{node}"', self.avatar_scene)
        for label in ("Ohne Timer", "2 Minuten", "5 Minuten", "10 Minuten", "1 Stunde", "24 Stunden"):
            self.assertIn(label, self.avatar_gd)
        self.assertIn('GameSession.configure_solo', self.avatar_gd)
        self.assertIn('GameSession.select_avatar', self.avatar_gd)

    def test_visual_rooms_and_mouse_hotspots_exist(self):
        expected = {
            "office_command.svg",
            "map_room.svg",
            "communications_room.svg",
            "research_room.svg",
            "archive_room.svg",
            "meeting_room.svg",
            "menu_background.svg",
        }
        room_dir = CLIENT / "assets" / "rooms"
        self.assertTrue(expected.issubset({p.name for p in room_dir.iterdir()}))
        for filename in expected:
            text = (room_dir / filename).read_text(encoding="utf-8").lower()
            self.assertIn("<svg", text)
            for forbidden in ("swastika", "hakenkreuz", "nazi flag", "ss-rune"):
                self.assertNotIn(forbidden, text)
        self.assertIn('name="VisualRoom"', self.office_scene)
        self.assertIn('name="HotspotLayer"', self.office_scene)
        self.assertIn('CURSOR_POINTING_HAND', self.visual_gd)
        for action in ("world", "phone", "decisions", "archive", "research", "events", "ai_world", "quiz"):
            self.assertIn(f'"{action}"', self.visual_gd)

    def test_learning_cards_are_valid_and_critical(self):
        cards = self.learning["cards"]
        self.assertGreaterEqual(len(cards), 8)
        topics = {card["topic"] for card in cards}
        self.assertTrue({"office", "state", "map", "research", "communications", "events", "profile", "portrayal"}.issubset(topics))
        for card in cards:
            self.assertTrue(card["title"])
            self.assertTrue(card["summary"])
            self.assertTrue(card["question"])
            self.assertGreaterEqual(len(card["choices"]), 3)
            self.assertGreaterEqual(card["correct_index"], 0)
            self.assertLess(card["correct_index"], len(card["choices"]))
        self.assertIn("nicht glorifiziert", self.learning["portrayal_rule"])

    def test_solo_timer_can_be_disabled(self):
        self.assertEqual(self.solo["default_timer_seconds"], 0)
        self.assertIn('timer_disabled = turn_seconds <= 0', self.timer_gd)
        self.assertIn('timer_label.text = "∞"', self.timer_gd)
        self.assertIn('total_players = 1', self.timer_gd)

    def test_manifest_registers_solo_learning_and_war_cards(self):
        files = self.manifest["files"]
        self.assertEqual(files["solo_learning_mode"], "solo_learning_mode.json")
        self.assertEqual(files["war_entry_cards"], "war_entry_cards_1939_1945.json")
        self.assertTrue((EPOCH / files["war_entry_cards"]).exists())

    def test_content_policy_prevents_rewarding_atrocities(self):
        never_reward = set(self.solo["learning"]["never_reward"])
        self.assertIn("genocide", never_reward)
        self.assertIn("war_crimes", never_reward)
        self.assertEqual(self.solo["learning"]["portrayal"], "critical_non_glorifying")
        self.assertIn("Extremistische Symbole", self.session_gd)


if __name__ == "__main__":
    unittest.main()
