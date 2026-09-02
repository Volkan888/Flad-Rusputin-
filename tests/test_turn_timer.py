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
        expected = {"turn_2m", "turn_5m", "turn_10m", "turn_1h", "turn_24h"}
        self.assertEqual(set(self.data["match_presets"]), expected)
        self.assertEqual(self.data["default_preset"], "turn_5m")
        self.assertEqual(self.data["match_presets"]["turn_2m"]["turn_seconds"], 120)
        self.assertEqual(self.data["match_presets"]["turn_5m"]["turn_seconds"], 300)
        self.assertEqual(self.data["match_presets"]["turn_10m"]["turn_seconds"], 600)
        self.assertEqual(self.data["match_presets"]["turn_1h"]["turn_seconds"], 3600)
        self.assertEqual(self.data["match_presets"]["turn_24h"]["turn_seconds"], 86400)

    def test_three_of_four_vote_required(self):
        vote = self.data["timer_change_vote"]
        self.assertTrue(vote["enabled"])
        self.assertEqual(vote["eligible_voters"], 4)
        self.assertEqual(vote["required_yes_votes"], 3)
        self.assertEqual(vote["approval_rule"], "three_of_four")
        self.assertTrue(vote["tie_keeps_current_timer"])
        self.assertEqual(set(vote["proposal_options"]), set(self.data["match_presets"]))
        self.assertEqual(vote["applies_from"], "next_turn")
        self.assertTrue(vote["cannot_change_current_turn_deadline_retroactively"])

    def test_timer_is_server_authoritative(self):
        fairness = self.data["fairness"]
        self.assertTrue(fairness["server_authoritative_deadline"])
        self.assertTrue(fairness["client_clock_is_display_only"])
        self.assertTrue(fairness["reconnect_uses_server_deadline"])
        self.assertTrue(fairness["network_disconnect_does_not_reset_timer"])
        self.assertTrue(fairness["same_vote_rule_for_host_and_guests"])

    def test_teams_share_same_deadline(self):
        rules = self.data["team_rules"]
        self.assertTrue(rules["blue_and_red_use_same_deadline"])
        self.assertTrue(rules["all_four_submitted_resolves_early"])
        self.assertTrue(rules["timer_vote_is_individual_not_team_block_vote"])
        self.assertTrue(rules["no_team_can_change_timer_alone"])

    def test_timeout_never_auto_attacks(self):
        timeout = self.data["timeout_behavior"]
        self.assertTrue(timeout["auto_cancel_unconfirmed_attack"])
        self.assertTrue(timeout["auto_decline_irreversible_action"])
        self.assertTrue(timeout["never_submit_empty_turn"])


if __name__ == "__main__":
    unittest.main()
