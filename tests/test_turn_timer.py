import json
import unittest
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
EPOCH = ROOT / "riseOfReign" / "data" / "epochs" / "1933"


class TurnTimerTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        cls.data = json.loads((EPOCH / "turn_timer_rules.json").read_text(encoding="utf-8"))
        cls.manifest = json.loads((EPOCH / "manifest.json").read_text(encoding="utf-8"))

    def test_manifest_registers_timer(self):
        self.assertEqual(self.manifest["files"]["turn_timer_rules"], "turn_timer_rules.json")

    def test_expected_presets_exist(self):
        expected = {"live_quick", "live_standard", "live_extended", "async_12h", "async_24h", "async_48h"}
        self.assertEqual(set(self.data["match_presets"]), expected)
        for preset in self.data["match_presets"].values():
            self.assertGreater(preset["turn_seconds"], 0)

    def test_timer_is_server_authoritative(self):
        fairness = self.data["fairness"]
        self.assertTrue(fairness["server_authoritative_deadline"])
        self.assertTrue(fairness["client_clock_is_display_only"])
        self.assertTrue(fairness["reconnect_uses_server_deadline"])
        self.assertTrue(fairness["network_disconnect_does_not_reset_timer"])

    def test_teams_share_same_deadline(self):
        rules = self.data["team_rules"]
        self.assertTrue(rules["blue_and_red_use_same_deadline"])
        self.assertTrue(rules["all_four_submitted_resolves_early"])

    def test_timeout_never_auto_attacks(self):
        timeout = self.data["timeout_behavior"]
        self.assertTrue(timeout["auto_cancel_unconfirmed_attack"])
        self.assertTrue(timeout["auto_decline_irreversible_action"])
        self.assertTrue(timeout["never_submit_empty_turn"])


if __name__ == "__main__":
    unittest.main()
