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
        cls.lifecycle = json.loads((EPOCH / "succession_capitulation_1933_1945.json").read_text(encoding="utf-8"))
        cls.manifest = json.loads((EPOCH / "manifest.json").read_text(encoding="utf-8"))
        cls.cards = cls.data["cards"]
        cls.by_id = {card["id"]: card for card in cls.cards}
        cls.lifecycle_ids = {
            transition["event_id"]
            for country in cls.lifecycle["countries"].values()
            for transition in country.get("transitions", [])
            if transition.get("event_id")
        }

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

    def test_followups_resolve_to_cards_or_lifecycle_events(self):
        known = set(self.by_id) | self.lifecycle_ids
        for card in self.cards:
            for followup in card.get("followups", []):
                self.assertIn(followup, known, f"{card['id']} references missing follow-up {followup}")

    def test_every_card_has_a_resolvable_game_flow(self):
        flow_fields = {
            "actions",
            "alternate_actions",
            "historical_mode_action",
            "lifecycle_event",
            "followups",
            "effects",
            "team_changes",
            "sector_effects",
            "transport_effects",
        }
        for card in self.cards:
            self.assertTrue(
                any(field in card and card[field] not in ({}, [], "", None) for field in flow_fields),
                f"{card['id']} has no action, transition or outcome flow",
            )

    def test_numeric_balance_values_are_bounded(self):
        def walk(value, path):
            if isinstance(value, bool):
                return
            if isinstance(value, (int, float)):
                self.assertGreaterEqual(value, -100, path)
                self.assertLessEqual(value, 100, path)
                return
            if isinstance(value, dict):
                for key, nested in value.items():
                    walk(nested, f"{path}.{key}")
                return
            if isinstance(value, list):
                for index, nested in enumerate(value):
                    walk(nested, f"{path}[{index}]")
                return
            self.assertIsInstance(value, (str, type(None)), path)

        for card in self.cards:
            walk(card.get("effects", {}), f"{card['id']}.effects")
            walk(card.get("risks", {}), f"{card['id']}.risks")

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
