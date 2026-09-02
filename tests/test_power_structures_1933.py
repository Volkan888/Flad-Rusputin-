import json
import unittest
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
EPOCH = ROOT / "riseOfReign" / "data" / "epochs" / "1933"


class PowerStructure1933Tests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        cls.data = json.loads((EPOCH / "power_structures_1933.json").read_text(encoding="utf-8"))
        cls.structures = cls.data["structures"]
        sectors = json.loads((EPOCH / "sectors_1933.json").read_text(encoding="utf-8"))["sectors"]
        cls.sector_ids = {s["id"] for s in sectors}

    def test_structure_ids_unique(self):
        ids = [x["id"] for x in self.structures]
        self.assertEqual(len(ids), len(set(ids)))

    def test_all_six_playable_countries_have_structures(self):
        expected = {"turkey", "germany", "soviet_union", "united_kingdom", "united_states", "italy"}
        self.assertEqual({x["country_id"] for x in self.structures}, expected)
        for country in expected:
            self.assertGreaterEqual(sum(1 for x in self.structures if x["country_id"] == country), 3, country)

    def test_sector_presence_resolves(self):
        for structure in self.structures:
            for sector_id, influence in structure.get("sector_presence", {}).items():
                self.assertIn(sector_id, self.sector_ids, (structure["id"], sector_id))
                self.assertIsInstance(influence, (int, float))
                self.assertGreaterEqual(influence, 0)
                self.assertLessEqual(influence, 100)

    def test_influence_is_bounded(self):
        allowed = set(self.data["influence_dimensions"])
        for structure in self.structures:
            for key, value in structure.get("influence", {}).items():
                self.assertIn(key, allowed, (structure["id"], key))
                self.assertIsInstance(value, (int, float), (structure["id"], key))
                self.assertGreaterEqual(value, 0, (structure["id"], key))
                self.assertLessEqual(value, 100, (structure["id"], key))

    def test_types_are_declared(self):
        allowed = set(self.data["types"])
        for structure in self.structures:
            self.assertIn(structure["type"], allowed, structure["id"])

    def test_inventory_is_separate_from_personal_and_state(self):
        rule = self.data["organization_inventory"]["rule"]
        self.assertIn("distinct", rule)
        separation = self.data["ownership_rules"]["inventory_separation"]
        self.assertEqual(set(separation), {"personal", "office", "state", "organization"})

    def test_criminal_networks_are_abstract_and_non_sovereign(self):
        self.assertTrue(self.data["ownership_rules"]["criminal_networks_never_own_sovereignty"])
        self.assertTrue(self.data["ownership_rules"]["criminal_actions_are_abstract"])
        criminal = [x for x in self.structures if x["type"] == "criminal_network"]
        self.assertGreaterEqual(len(criminal), 5)
        for structure in criminal:
            self.assertNotIn("territorial_owner", structure)
            for action in structure.get("player_uses", []):
                self.assertNotIn("how_to", action.lower())

    def test_historical_anchors_have_sources_where_expected(self):
        anchored = [x for x in self.structures if x.get("historical_status", "").startswith("historical_anchor")]
        self.assertGreaterEqual(len(anchored), 10)
        for structure in anchored:
            self.assertTrue(structure.get("source"), structure["id"])

    def test_state_and_private_economic_power_both_exist(self):
        types = {x["type"] for x in self.structures}
        self.assertIn("state_enterprise", types)
        self.assertIn("state_holding", types)
        self.assertIn("private_company", types)
        self.assertIn("industrial_group", types)
        self.assertIn("bank", types)

    def test_organization_assets_and_player_uses_exist(self):
        for structure in self.structures:
            self.assertTrue(structure.get("assets"), structure["id"])
            self.assertTrue(structure.get("player_uses"), structure["id"])


if __name__ == "__main__":
    unittest.main()
