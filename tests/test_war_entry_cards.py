import json
import unittest
from datetime import date
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
EPOCH = ROOT / "riseOfReign" / "data" / "epochs" / "1933"


class WarEntryCardTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        cls.data = json.loads((EPOCH / "war_entry_cards_1939_1945.json").read_text(encoding="utf-8"))
        cls.manifest = json.loads((EPOCH / "manifest.json").read_text(encoding="utf-8"))
        cls.cards = cls.data["cards"]
        cls.by_id = {card["id"]: card for card in cls.cards}

    def test_manifest_registers_war_entry_cards(self):
        self.assertEqual(self.manifest["files"]["war_entry_cards"], "war_entry_cards_1939_1945.json")

    def test_campaign_window_and_card_volume(self):
        self.assertEqual(self.data["campaign_window"]["from"], "1939-01-01")
        self.assertEqual(self.data["campaign_window"]["to"], "1945-09-02")
        self.assertGreaterEqual(len(self.cards), 15)

    def test_card_ids_are_unique_and_dates_are_bounded(self):
        self.assertEqual(len(self.by_id), len(self.cards))
        start = date.fromisoformat(self.data["campaign_window"]["from"])
        end = date.fromisoformat(self.data["campaign_window"]["to"])
        for card in self.cards:
            self.assertTrue(card["id"])
            self.assertTrue(card["headline"])
            self.assertTrue(card["type"])
            card_date = date.fromisoformat(card["date"])
            self.assertGreaterEqual(card_date, start)
            self.assertLessEqual(card_date, end)

    def test_major_historical_flow_is_present(self):
        required = {
            "de_1939_gleiwitz_false_flag",
            "de_1939_invasion_poland",
            "uk_fr_1939_declare_war",
            "de_1941_barbarossa",
            "jp_1941_pearl_harbor",
            "us_1941_declares_war_japan",
        }
        self.assertTrue(required.issubset(self.by_id))

    def test_followups_resolve_to_known_cards(self):
        known = set(self.by_id)
        for card in self.cards:
            for followup in card.get("followups", []):
                self.assertIn(followup, known, f"{card['id']} references missing follow-up {followup}")

    def test_actions_are_playable_or_automatic_anchors(self):
        for card in self.cards:
            has_actions = bool(card.get("actions")) or bool(card.get("alternate_actions"))
            is_anchor = card.get("historical_mode_action") == "automatic_anchor"
            self.assertTrue(has_actions or is_anchor, f"{card['id']} has no playable or automatic flow")

    def test_effects_and_risks_use_bounded_gameplay_numbers(self):
        for card in self.cards:
            for section in ("effects", "risks"):
                for key, value in card.get(section, {}).items():
                    self.assertIsInstance(value, (int, float), f"{card['id']} {section}.{key}")
                    self.assertGreaterEqual(value, -100)
                    self.assertLessEqual(value, 100)

    def test_sources_are_https_or_explicitly_status_labeled(self):
        for card in self.cards:
            source = card.get("source")
            status = card.get("source_status")
            self.assertTrue(source or status, f"{card['id']} has no source or source status")
            if source:
                self.assertTrue(source.startswith("https://"), source)

    def test_clandestine_actions_remain_abstract(self):
        self.assertIn("abstract", self.data["safety_rule"].lower())
        gleiwitz = self.by_id["de_1939_gleiwitz_false_flag"]
        self.assertEqual(gleiwitz["type"], "false_flag_historical_anchor")
        self.assertEqual(gleiwitz["historical_mode_action"], "automatic_anchor")
        self.assertNotIn("step-by-step", json.dumps(gleiwitz).lower())


if __name__ == "__main__":
    unittest.main()
