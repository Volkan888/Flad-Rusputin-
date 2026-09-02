import json
import unittest
from pathlib import Path
from datetime import date

ROOT = Path(__file__).resolve().parents[1]
OFFICE_PATH = ROOT / "riseOfReign" / "data" / "epochs" / "1933" / "office_hubs.json"
MANIFEST_PATH = ROOT / "riseOfReign" / "data" / "epochs" / "1933" / "manifest.json"
PROGRAM_PATH = ROOT / "riseOfReign" / "server" / "src" / "RiseOfReign.Api" / "Program.cs"


class OfficeHubContentTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        cls.data = json.loads(OFFICE_PATH.read_text(encoding="utf-8"))

    def test_only_three_interaction_modes(self):
        self.assertEqual(set(self.data["interaction_types"]), {"side_menu", "room", "phone_list"})
        for obj in self.data["shared_objects"]:
            self.assertIn(obj["interaction"], self.data["interaction_types"], obj["id"])

    def test_object_ids_unique_and_routes_resolve(self):
        objects = self.data["shared_objects"]
        ids = [x["id"] for x in objects]
        self.assertEqual(len(ids), len(set(ids)))
        side_routes = set(self.data["side_menu_routes"])
        room_ids = {x["id"] for x in self.data["rooms"]}
        phone_route = self.data["phone_system"]["default_route"]
        for obj in objects:
            self.assertTrue(obj.get("opens"), obj["id"])
            if obj["interaction"] == "side_menu":
                self.assertIn(obj["opens"], side_routes, obj["id"])
            elif obj["interaction"] == "room":
                self.assertIn(obj["opens"], room_ids, obj["id"])
            elif obj["interaction"] == "phone_list":
                self.assertEqual(obj["opens"], phone_route, obj["id"])
            if "upgrades_to" in obj:
                self.assertIn(obj["upgrades_to"], room_ids, obj["id"])

    def test_office_levels_are_sequential_and_costed(self):
        levels = self.data["office_levels"]
        self.assertEqual([x["level"] for x in levels], list(range(6)))
        for level in levels:
            self.assertGreaterEqual(level["build_months"], 0)
            self.assertTrue(level["gameplay_features"])
            for bucket in ("materials", "monthly_maintenance"):
                for key, value in level.get(bucket, {}).items():
                    self.assertIsInstance(value, (int, float), f"{level['level']} {bucket}.{key}")
                    self.assertGreaterEqual(value, 0, f"{level['level']} {bucket}.{key}")
        self.assertGreater(levels[3]["requirements"]["armament_index"], 0)
        self.assertGreater(levels[5]["requirements"]["armament_index"], levels[3]["requirements"]["armament_index"])

    def test_rooms_resolve_and_never_dead_end(self):
        rooms = self.data["rooms"]
        ids = [x["id"] for x in rooms]
        self.assertEqual(len(ids), len(set(ids)))
        self.assertIn("archive_room", ids)
        self.assertIn("war_room", ids)
        self.assertIn("communications_room", ids)
        self.assertIn("crisis_shelter", ids)
        for room in rooms:
            self.assertIn(room["required_office_level"], range(6))
            self.assertTrue(room["opens"], room["id"])
        self.assertTrue(self.data["accessibility_and_mobile"]["no_dead_ends"])
        self.assertTrue(self.data["accessibility_and_mobile"]["text_list_fallback"])

    def test_all_avatar_offices_exist(self):
        expected = {"ataturk", "hitler", "stalin", "churchill", "roosevelt", "mussolini", "custom"}
        self.assertEqual(set(self.data["avatar_offices"]), expected)
        side_routes = set(self.data["side_menu_routes"])
        for avatar_id, office in self.data["avatar_offices"].items():
            signature = office["signature_object"]
            self.assertEqual(signature["interaction"], "side_menu")
            self.assertIn(signature["opens"], side_routes)
            if avatar_id != "custom":
                self.assertIsInstance(office["start_level"], int)
                self.assertIn(office["start_level"], range(6))

    def test_historical_start_invariants(self):
        offices = self.data["avatar_offices"]
        self.assertEqual(offices["hitler"]["start_level"], 0)
        self.assertFalse(offices["hitler"]["start_access"]["government"])
        self.assertEqual(offices["hitler"]["historical_transition"]["date"], "1933-01-30")
        self.assertEqual(offices["roosevelt"]["start_level"], 0)
        self.assertEqual(offices["roosevelt"]["historical_transition"]["date"], "1933-03-04")
        self.assertFalse(offices["churchill"]["start_access"]["direct_military_command"])
        self.assertGreaterEqual(offices["ataturk"]["start_level"], 1)
        self.assertGreaterEqual(offices["stalin"]["start_level"], 2)
        self.assertGreaterEqual(offices["mussolini"]["start_level"], 2)
        for avatar_id in ("hitler", "roosevelt"):
            event_date = date.fromisoformat(offices[avatar_id]["historical_transition"]["date"])
            self.assertEqual(event_date.year, 1933)

    def test_phone_flow_has_choices_and_player_contacts(self):
        phone = self.data["phone_system"]
        category_ids = [x["id"] for x in phone["contact_categories"]]
        self.assertEqual(len(category_ids), len(set(category_ids)))
        self.assertIn("other_players", category_ids)
        self.assertIn("request_meeting", phone["contact_options"])
        self.assertIn("send_instruction_if_authorized", phone["contact_options"])
        self.assertIn("trade_proposal", phone["player_contact_options"])
        self.assertIn("research_proposal", phone["player_contact_options"])

    def test_progression_is_gameplay_not_pay_to_win(self):
        rules = self.data["upgrade_rules"]
        self.assertFalse(rules["real_money_purchase"])
        self.assertEqual(rules["currency"], "in_game_state_treasury_only")
        self.assertTrue(rules["materials_reserved_at_start"])
        self.assertTrue(rules["shortages_delay"])
        self.assertFalse(rules["cosmetics_bypass_requirements"])

    def test_damage_relocation_and_succession_have_fallbacks(self):
        relocation = self.data["relocation_and_damage"]
        self.assertIn("provisional_office", relocation["states"])
        self.assertEqual(set(relocation["provisional_office_preserves"]), {"telephone", "desk", "wall_map", "urgent_folder"})
        self.assertTrue(self.data["succession_rule"]["state_keeps_rooms"])

    def test_manifest_and_api_reference_offices(self):
        manifest = json.loads(MANIFEST_PATH.read_text(encoding="utf-8"))
        self.assertEqual(manifest["files"]["office_hubs"], "office_hubs.json")
        program = PROGRAM_PATH.read_text(encoding="utf-8")
        self.assertIn('/api/v1/offices', program)
        self.assertIn('/api/v1/offices/{avatarId}', program)


if __name__ == "__main__":
    unittest.main()
