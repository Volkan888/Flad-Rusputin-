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
        cls.avatar_gd = (CLIENT / "scripts" / "avatar_select.gd").read_text(encoding="utf-8")
        cls.audio_gd = (CLIENT / "scripts" / "audio_manager.gd").read_text(encoding="utf-8")
        cls.office_gd = (CLIENT / "scripts" / "office_hub.gd").read_text(encoding="utf-8")
        cls.timer_gd = (CLIENT / "scripts" / "turn_timer_widget.gd").read_text(encoding="utf-8")
        cls.intro_gd = (CLIENT / "scripts" / "intro.gd").read_text(encoding="utf-8")
        cls.main_scene = (CLIENT / "scenes" / "main.tscn").read_text(encoding="utf-8")
        cls.avatar_scene = (CLIENT / "scenes" / "avatar_select.tscn").read_text(encoding="utf-8")
        cls.office_scene = (CLIENT / "scenes" / "office_hub.tscn").read_text(encoding="utf-8")
        cls.intro_scene = (CLIENT / "scenes" / "intro.tscn").read_text(encoding="utf-8")
        cls.project = (CLIENT / "project.godot").read_text(encoding="utf-8")
        cls.office_data = json.loads(OFFICE_DATA.read_text(encoding="utf-8"))

    def test_start_menu_is_strategy_style_and_connected(self):
        for label in ("NEUES SPIEL", "FORTSETZEN", "MULTIPLAYER", "EINSTELLUNGEN", "BEENDEN"):
            self.assertIn(label, self.main_scene)
        self.assertIn("RISE OF REIGN", self.main_scene)
        self.assertIn("1933 · THE WORLD IN CRISIS", self.main_scene)
        self.assertIn('Color(0.45, 0.025, 0.04, 1)', self.main_scene)
        self.assertIn('change_scene_to_file("res://scenes/avatar_select.tscn")', self.main_gd)

    def test_avatar_selector_contains_all_seven_slots(self):
        for avatar_id in ("ataturk", "hitler", "stalin", "churchill", "roosevelt", "mussolini", "custom"):
            self.assertIn(f'"id":"{avatar_id}"', self.avatar_gd)
        self.assertIn('preload("res://scenes/office_hub.tscn")', self.avatar_gd)
        self.assertIn('name="AvatarList"', self.avatar_scene)

    def test_audio_manager_is_global_persistent_and_configurable(self):
        self.assertIn('AudioManager="*res://scripts/audio_manager.gd"', self.project)
        self.assertIn('user://riseofreign_settings.cfg', self.audio_gd)
        for token in ("master_volume", "music_volume", "sfx_volume", "start_menu_music", "play_click"):
            self.assertIn(token, self.audio_gd)

    def test_intro_is_video_first_with_safe_fallback(self):
        self.assertIn('name="Video" type="VideoStreamPlayer"', self.intro_scene)
        self.assertIn('name="Fallback"', self.intro_scene)
        self.assertIn('VK APPS', self.intro_scene)
        self.assertIn('RISE OF REIGN', self.intro_scene)
        self.assertIn('vkapps_riseofreign_intro.ogv', self.intro_gd)
        self.assertIn('ResourceLoader.exists', self.intro_gd)
        self.assertIn('_run_fallback_intro', self.intro_gd)
        self.assertIn('_on_video_finished', self.intro_gd)

    def test_office_client_uses_only_approved_interaction_modes(self):
        self.assertIn('"side_menu":', self.office_gd)
        self.assertIn('"phone_list":', self.office_gd)
        self.assertIn('"room":', self.office_gd)
        for forbidden in ('"overlay":', '"avatar_panel":', '"state_panel":'):
            self.assertNotIn(forbidden, self.office_gd)
        self.assertEqual(set(self.office_data["interaction_types"]), {"side_menu", "room", "phone_list"})

    def test_office_api_contract_is_used(self):
        for token in ('/api/v1/offices/%s', 'avatarOffice', 'sharedObjects', 'officeLevels', 'phoneSystem', 'rooms'):
            self.assertIn(token, self.office_gd)

    def test_desktop_scene_has_modern_icon_navigation_and_hud(self):
        for node_name in (
            "TopHud", "Treasury", "Income", "Expenses", "Health", "Stability", "Authority",
            "QuickNav", "OfficePanel", "ObjectGrid", "InteractionPanel", "InteractionBody", "ActionList",
            "TurnPanel", "TimerLabel", "ReadyButton", "ReadyPlayers", "HTTPRequest"
        ):
            self.assertIn(f'name="{node_name}"', self.office_scene)
        for label in ("BÜRO", "WELT", "TELEFON", "STAAT", "STRATEGIE", "EVENTS", "EINSTELLUNGEN", "FERTIG"):
            self.assertIn(label, self.office_scene)
        for icon in ("office.svg", "world.svg", "phone.svg", "state.svg", "strategy.svg", "events.svg", "settings.svg", "timer.svg", "ready.svg"):
            self.assertIn(icon, self.office_scene)
            self.assertTrue((CLIENT / "assets" / "icons" / icon).exists(), icon)
        self.assertIn('tooltip_text', self.office_scene)
        self.assertIn('_update_hud', self.office_gd)

    def test_timer_widget_counts_down_and_supports_ready_toggle(self):
        for token in ("turn_seconds", "seconds_left", "_on_tick", "_on_ready_pressed", "BEREIT ✓", "ZEIT ABGELAUFEN"):
            self.assertIn(token, self.timer_gd)
        self.assertIn('total_players: int = 4', self.timer_gd)

    def test_office_navigation_has_no_dead_end_fallback(self):
        for token in ('_show_office', '_show_room_selector', '_show_phone_list', 'Zurück'):
            self.assertIn(token, self.office_gd)

    def test_office_level_and_lock_logic_present(self):
        for token in ('current_office_level', 'required_office_level', 'office_level', '_show_upgrade_overview'):
            self.assertIn(token, self.office_gd)

    def test_project_targets_godot_47_desktop_mouse_and_configurable_api(self):
        self.assertIn('PackedStringArray("4.7")', self.project)
        self.assertIn('network/api_base_url=', self.project)
        self.assertIn('viewport_width=1920', self.project)
        self.assertIn('viewport_height=1080', self.project)
        self.assertIn('ui/input_mode="mouse_keyboard"', self.project)
        self.assertIn('pointing/emulate_touch_from_mouse=false', self.project)
        self.assertIn('tooltip_delay_sec=0.35', self.project)


if __name__ == "__main__":
    unittest.main()
