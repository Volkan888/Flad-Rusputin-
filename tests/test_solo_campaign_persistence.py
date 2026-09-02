import re
import unittest
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
CLIENT = ROOT / "riseOfReign" / "client"
MAIN = CLIENT / "scripts" / "main.gd"
OFFICE = CLIENT / "scripts" / "office_hub.gd"


class SoloCampaignPersistenceTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        cls.main = MAIN.read_text(encoding="utf-8")
        cls.office = OFFICE.read_text(encoding="utf-8")

    def test_new_game_resets_old_campaign_but_continue_does_not(self):
        self.assertIn('CAMPAIGN_SAVE_PATH := "user://riseofreign_campaign.json"', self.main)
        new_game = self._function_body(self.main, "_on_new_game_pressed")
        continue_game = self._function_body(self.main, "_on_continue_pressed")
        self.assertIn("_reset_local_campaign()", new_game)
        self.assertLess(new_game.index("_reset_local_campaign()"), new_game.index("GameSession.start_solo()"))
        self.assertNotIn("_reset_local_campaign()", continue_game)
        self.assertIn("GameSession.player_avatar_id", continue_game)

    def test_campaign_file_has_load_write_draft_and_resolution_paths(self):
        for token in (
            'CAMPAIGN_SAVE_PATH := "user://riseofreign_campaign.json"',
            "func _load_campaign_save()",
            "func _save_campaign_draft()",
            "func _save_campaign_resolution(",
            "func _write_campaign_save(",
            "JSON.parse_string",
            "JSON.stringify",
            "FileAccess.READ",
            "FileAccess.WRITE",
            '"status": "draft"',
            '"status": "resolved"',
            '"resolved_result"',
            '"player_state"',
            '"ai_report"',
            '"learning_score"',
            '"world_tension"',
        ):
            self.assertIn(token, self.office)

    def test_every_january_selection_is_autosaved(self):
        decision = self._function_body(self.office, "_select_january_choice")
        phone = self._function_body(self.office, "_on_phone_option")
        map_action = self._function_body(self.office, "_select_january_map_action")
        finish = self._function_body(self.office, "_finish_january")
        self.assertIn("_save_campaign_draft()", decision)
        self.assertIn("_save_campaign_draft()", phone)
        self.assertIn("_save_campaign_draft()", map_action)
        self.assertIn("_save_campaign_draft()", finish)

    def test_resolved_month_is_restored_without_second_post(self):
        load_response = self._function_body(self.office, "_on_month_request_completed")
        restore = self._function_body(self.office, "_restore_resolved_campaign")
        apply_report = self._function_body(self.office, "_apply_month_report")
        self.assertIn("_has_resolved_campaign()", load_response)
        self.assertIn("_restore_resolved_campaign()", load_response)
        self.assertIn("_apply_month_report(saved_result, false)", restore)
        self.assertIn("if persist_result:", apply_report)
        self.assertIn("_save_campaign_resolution(result, ai_report)", apply_report)
        self.assertNotIn("HTTPClient.METHOD_POST", restore)

    def test_post_month_learning_and_ai_reports_are_visible(self):
        for method in (
            "func _show_solo_ai_report()",
            "func _show_campaign_overview()",
            "func _show_learning_progress()",
            "func _campaign_ai_report(",
        ):
            self.assertIn(method, self.office)
        for label in (
            "KI-Weltbericht Januar",
            "Kampagnenübersicht",
            "Lernfortschritt",
            "Weltspannung",
            "Solo-Spielstand gespeichert",
        ):
            self.assertIn(label, self.office)

    def test_save_is_scoped_to_the_selected_avatar(self):
        load = self._function_body(self.office, "_load_campaign_save")
        self.assertIn('str(parsed.get("avatar_id", "")) != avatar_id', load)
        self.assertIn('"avatar_id": avatar_id', self.office)
        self.assertIn('"avatar_display_name": avatar_display_name', self.office)

    @staticmethod
    def _function_body(source: str, function_name: str) -> str:
        match = re.search(
            rf"^func {re.escape(function_name)}\([^\n]*\)(?:\s*->\s*[^:]+)?:\n(?P<body>.*?)(?=^func |\Z)",
            source,
            re.MULTILINE | re.DOTALL,
        )
        if not match:
            raise AssertionError(f"Function not found: {function_name}")
        return match.group("body")


if __name__ == "__main__":
    unittest.main()
