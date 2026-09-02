import json
import unittest
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
EPOCH = ROOT / "riseOfReign" / "data" / "epochs" / "1933"


class Sector1933Tests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        cls.data = json.loads((EPOCH / "sectors_1933.json").read_text(encoding="utf-8"))
        cls.sectors = cls.data["sectors"]
        cls.by_id = {s["id"]: s for s in cls.sectors}
        cls.countries = json.loads((EPOCH / "countries.json").read_text(encoding="utf-8"))
        cls.resources = json.loads((EPOCH / "map_resource_nodes.json").read_text(encoding="utf-8"))
        cls.resource_ids = {r["id"] for r in cls.resources}

    def test_expected_sector_count_and_country_coverage(self):
        self.assertEqual(len(self.sectors), 43)
        expected = {"turkey", "germany", "soviet_union", "united_kingdom", "united_states", "italy"}
        self.assertEqual({s["country_id"] for s in self.sectors}, expected)
        for country in self.countries:
            country_sectors = [s for s in self.sectors if s["country_id"] == country["id"]]
            self.assertGreaterEqual(len(country_sectors), len(country["strategic_regions"]), country["id"])

    def test_sector_ids_unique(self):
        ids = [s["id"] for s in self.sectors]
        self.assertEqual(len(ids), len(set(ids)))

    def test_combat_values_are_bounded(self):
        bounded = ["infrastructure", "supply_access", "fortification", "urban_defense", "local_resilience", "command_access", "strategic_value"]
        for sector in self.sectors:
            for key in bounded:
                self.assertIn(key, sector, (sector["id"], key))
                self.assertGreaterEqual(sector[key], 0, (sector["id"], key))
                self.assertLessEqual(sector[key], 100, (sector["id"], key))
            self.assertGreater(sector["base_move_days"], 0, sector["id"])

    def test_duration_classes_exist(self):
        bands = self.data["combat_model"]["duration_bands_days"]
        for sector in self.sectors:
            cls = sector["attack_duration_class"]
            self.assertIn(cls, bands, sector["id"])
            low, high = bands[cls]
            self.assertGreater(low, 0)
            self.assertGreaterEqual(high, low)

    def test_resource_links_resolve(self):
        for sector in self.sectors:
            for resource_id in sector.get("resource_links", []):
                self.assertIn(resource_id, self.resource_ids, (sector["id"], resource_id))

    def test_land_connections_resolve_and_stay_inside_country(self):
        for sector in self.sectors:
            for neighbor_id in sector.get("connections", []):
                self.assertIn(neighbor_id, self.by_id, (sector["id"], neighbor_id))
                self.assertEqual(self.by_id[neighbor_id]["country_id"], sector["country_id"], (sector["id"], neighbor_id))

    def test_land_connections_are_bidirectional(self):
        for sector in self.sectors:
            for neighbor_id in sector.get("connections", []):
                self.assertIn(sector["id"], self.by_id[neighbor_id].get("connections", []), (sector["id"], neighbor_id))

    def test_every_country_has_one_capital_sector(self):
        for country in {s["country_id"] for s in self.sectors}:
            capitals = [s for s in self.sectors if s["country_id"] == country and s["capital"]]
            self.assertEqual(len(capitals), 1, country)

    def test_islands_can_require_sea_access(self):
        sicily = self.by_id["it_sicily"]
        sardinia = self.by_id["it_sardinia"]
        self.assertEqual(sicily["attack_duration_class"], "island_or_amphibious")
        self.assertEqual(sardinia["attack_duration_class"], "island_or_amphibious")
        self.assertTrue(sicily["coastal"])
        self.assertTrue(sardinia["coastal"])

    def test_capture_is_not_country_wide_or_instant(self):
        model = self.data["combat_model"]
        self.assertTrue(model["no_instant_capture"])
        self.assertIn("does not automatically annex", model["capital_capture_rule"])
        self.assertIn("transport", model["resource_capture_rule"])

    def test_future_non_state_power_layers_are_reserved(self):
        ownership = self.data["ownership_model"]
        self.assertIn("corporation", ownership["controller_types"])
        self.assertIn("mafia_or_criminal_network", ownership["controller_types"])
        self.assertIn("corporate_influence", ownership["future_power_layers"])
        self.assertIn("mafia_influence", ownership["future_power_layers"])


if __name__ == "__main__":
    unittest.main()
