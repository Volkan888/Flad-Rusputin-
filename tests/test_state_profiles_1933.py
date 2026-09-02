import json
import unittest
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
EPOCH = ROOT / "riseOfReign" / "data" / "epochs" / "1933"


class StateProfiles1933Tests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        cls.data = json.loads((EPOCH / "state_profiles.json").read_text(encoding="utf-8"))

    def test_all_avatar_profiles_exist(self):
        expected = {"ataturk", "hitler", "stalin", "churchill", "roosevelt", "mussolini", "custom"}
        self.assertEqual(set(self.data["avatars"]), expected)

    def test_health_dimensions_are_complete_and_bounded(self):
        required = {"health", "energy", "stress", "mobility", "medical_access"}
        for avatar_id, avatar in self.data["avatars"].items():
            health = avatar["health"]
            self.assertTrue(required.issubset(health), avatar_id)
            for key in required:
                self.assertGreaterEqual(health[key], 0, (avatar_id, key))
                self.assertLessEqual(health[key], 100, (avatar_id, key))

    def test_roosevelt_mobility_is_separate_from_health(self):
        roosevelt = self.data["avatars"]["roosevelt"]["health"]
        self.assertLess(roosevelt["mobility"], roosevelt["health"])
        self.assertGreater(roosevelt["health"], 0)
        self.assertIn("mobility_dimension", roosevelt["historical_verification"])

    def test_each_avatar_has_inventory(self):
        allowed_ownership = {"personal", "office", "state_issued", "classified"}
        for avatar_id, avatar in self.data["avatars"].items():
            inventory = avatar["inventory"]
            self.assertGreaterEqual(len(inventory), 2, avatar_id)
            ids = [item["id"] for item in inventory]
            self.assertEqual(len(ids), len(set(ids)), avatar_id)
            for item in inventory:
                self.assertIn(item["ownership"], allowed_ownership, (avatar_id, item["id"]))
                self.assertGreater(item["quantity"], 0)
                self.assertGreaterEqual(item["condition"], 0)
                self.assertLessEqual(item["condition"], 100)

    def test_finance_profiles_have_income_expense_and_assets(self):
        for country_id, country in self.data["countries"].items():
            finance = country["finance"]
            self.assertIn("treasury", finance, country_id)
            self.assertIn("debt_pressure", finance, country_id)
            for bucket in ("income", "expenses", "assets"):
                self.assertTrue(finance[bucket], (country_id, bucket))
                for key, value in finance[bucket].items():
                    self.assertIsInstance(value, (int, float), (country_id, bucket, key))
                    self.assertGreaterEqual(value, 0, (country_id, bucket, key))

    def test_state_and_personal_assets_are_explicitly_separate(self):
        self.assertIn("State-issued", self.data["inventory_rules"]["state_property_rule"])
        self.assertIn("personal", self.data["inventory_rules"]["state_property_rule"])
        self.assertIn("state treasury", self.data["inventory_note"].lower()) if "state treasury" in self.data["inventory_note"].lower() else None

    def test_finance_values_are_gameplay_rp_not_fake_currency_claims(self):
        note = self.data["unit_note"].lower()
        self.assertIn("resource points", note)
        self.assertIn("not claims of exact historical currency", note)

    def test_health_has_incapacitation_thresholds(self):
        rules = self.data["health_rules"]
        self.assertGreater(rules["critical_threshold"], rules["incapacitated_threshold"])
        self.assertGreaterEqual(rules["critical_threshold"], 10)


if __name__ == "__main__":
    unittest.main()
