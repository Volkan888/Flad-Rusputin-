import json
import unittest
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
CLIENT = ROOT / "riseOfReign" / "client"
OFFICE_DATA = ROOT / "riseOfReign" / "data" / "epochs" / "1933" / "office_hubs.json"


class OfficeClientContractTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        cls.main_gd = (CLIENT / "scripts" / "main.gd").read_text(encoding="utf-8")
        cls.office_gd = (CLIENT / "scripts" / "office_hub.gd").read_text(encoding="utf-8")
        cls.main_scene = (CLIENT / "scenes" / "main.tscn").read_text(encoding="utf-8")
        cls.office_scene = (CLIENT / "scenes" / "office_hub.tscn").read_text(encoding="utf-8")
        cls.project = (CLIENT / "project.godot").read_text(encoding="utf-8")
        cls.office_data = json.loads(OFFICE_DATA.read_text(encoding="utf-8"))

    def test_avatar_selector_contains_all_seven_slots(self):
        for avatar_id in ("ataturk", "hitler", "stalin", "churchill", "roosevelt", "mussolini", "custom"):
            self.assertIn(f'"id":"{avatar_id}"', self.main_gd)
        self.assertIn('preload("res://scenes/office_hub.tscn")', self.main_gd)

    def test_office_client_uses_only_approved_interaction_modes(self):
        self.assertIn('"side_menu":', self.office_gd)
        self.assertIn('"phone_list":', self.office_gd)
        self.assertIn('"room":', self.office_gd)
        for forbidden in ('"overlay":', '"avatar_panel":', '"state_panel":'):
            self.assertNotIn(forbidden, self.office_gd)
        self.assertEqual(set(self.office_data["interaction_types"]), {"side_menu", "room", "phone_list"})

    def test_office_api_contract_is_used(self):
        self.assertIn('/api/v1/offices/%s', self.office_gd)
        self.assertIn('avatarOffice', self.office_gd)
        self.assertIn('sharedObjects', self.office_gd)
        self.assertIn('officeLevels', self.office_gd)
        self.assertIn('phoneSystem', self.office_gd)
        self.assertIn('rooms', self.office_gd)

    def test_mobile_scene_has_required_surfaces(self):
        for node_name in ("OfficePanel", "ObjectGrid", "InteractionPanel", "InteractionBody", "ActionList", "HTTPRequest"):
            self.assertIn(f'name="{node_name}"', self.office_scene)
        self.assertIn('name="AvatarList"', self.main_scene)

    def test_office_navigation_has_no_dead_end_fallback(self):
        self.assertIn('_show_office', self.office_gd)
        self.assertIn('_show_room_selector', self.office_gd)
        self.assertIn('_show_phone_list', self.office_gd)
        self.assertIn('Zurück', self.office_gd)

    def test_office_level_and_lock_logic_present(self):
        self.assertIn('current_office_level', self.office_gd)
        self.assertIn('required_office_level', self.office_gd)
        self.assertIn('office_level', self.office_gd)
        self.assertIn('_show_upgrade_overview', self.office_gd)

    def test_project_targets_godot_47_and_configurable_api(self):
        self.assertIn('PackedStringArray("4.7")', self.project)
        self.assertIn('network/api_base_url=', self.project)
        self.assertIn('1080', self.project)
        self.assertIn('1920', self.project)


if __name__ == "__main__":
    unittest.main()
