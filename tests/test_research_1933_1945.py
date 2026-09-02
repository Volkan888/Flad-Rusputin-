import json
import unittest
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
EPOCH = ROOT / "riseOfReign" / "data" / "epochs" / "1933"


class Research1933To1945Tests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        cls.catalog = json.loads((EPOCH / "research_catalog_1933_1945.json").read_text(encoding="utf-8"))
        cls.profiles = json.loads((EPOCH / "research_country_profiles_1933_1945.json").read_text(encoding="utf-8"))
        cls.manifest = json.loads((EPOCH / "manifest.json").read_text(encoding="utf-8"))
        cls.techs = cls.catalog["technologies"]
        cls.by_id = {x["id"]: x for x in cls.techs}

    def test_manifest_registers_research(self):
        self.assertEqual(self.manifest["files"]["research_catalog"], "research_catalog_1933_1945.json")
        self.assertEqual(self.manifest["files"]["research_country_profiles"], "research_country_profiles_1933_1945.json")

    def test_catalog_has_all_three_tracks_and_broad_depth(self):
        self.assertEqual(set(self.catalog["tracks"]), {"people_work", "soldiers_weapons", "culture_school"})
        self.assertGreaterEqual(len(self.techs), 50)
        for track in self.catalog["tracks"]:
            self.assertGreaterEqual(sum(1 for x in self.techs if x["track"] == track), 12, track)

    def test_ids_are_unique_and_required_flagship_technologies_exist(self):
        ids = [x["id"] for x in self.techs]
        self.assertEqual(len(ids), len(set(ids)))
        required = {
            "pw_motorway_network", "pw_rail_standardization", "pw_merchant_shipping",
            "pw_synthetic_fuel", "pw_penicillin_mass_production",
            "sw_radar_early_warning", "sw_heavy_tank_design", "sw_ballistic_missile",
            "sw_jet_fighter", "sw_electronic_computing", "sw_atomic_program",
            "cs_public_radio", "cs_television_experimental", "cs_television_service",
            "cs_telex_network", "cs_university_reform", "cs_advanced_electronics",
        }
        self.assertTrue(required.issubset(self.by_id), required - set(self.by_id))

    def test_timing_costs_and_tiers_are_bounded(self):
        for tech in self.techs:
            self.assertGreaterEqual(tech["available_from"], 1933, tech["id"])
            self.assertLessEqual(tech["available_from"], 1945, tech["id"])
            self.assertGreaterEqual(tech["tier"], 1, tech["id"])
            self.assertLessEqual(tech["tier"], 6, tech["id"])
            self.assertGreater(tech["duration_months"], 0, tech["id"])
            self.assertLessEqual(tech["duration_months"], 36, tech["id"])
            self.assertGreater(tech["research_cost_rp"], 0, tech["id"])
            self.assertGreaterEqual(tech.get("treasury_cost_rp", 0), 0, tech["id"])
            for value in tech.get("materials", {}).values():
                self.assertGreater(value, 0, tech["id"])

    def test_prerequisites_resolve_and_do_not_start_later_than_child(self):
        for tech in self.techs:
            for prereq in tech.get("prerequisites", []):
                self.assertIn(prereq, self.by_id, (tech["id"], prereq))
                parent = self.by_id[prereq]
                self.assertLessEqual(parent["available_from"], tech["available_from"], (prereq, tech["id"]))
                self.assertLessEqual(parent["tier"], tech["tier"], (prereq, tech["id"]))

    def test_balance_values_are_explicitly_not_historical_cost_claims(self):
        note = self.catalog["balance_note"].lower()
        self.assertIn("gameplay", note)
        self.assertIn("not claims", note)

    def test_historically_named_milestones_are_sourced_when_present(self):
        sourced = [x for x in self.techs if x.get("historical_milestone")]
        self.assertGreaterEqual(len(sourced), 10)
        for tech in sourced:
            self.assertTrue(tech.get("source"), tech["id"])

    def test_all_start_countries_have_distinct_profiles(self):
        expected = {"germany", "united_kingdom", "united_states", "soviet_union", "italy", "turkey", "custom_default"}
        self.assertEqual(set(self.profiles["countries"]), expected)
        signatures = set()
        for country, profile in self.profiles["countries"].items():
            self.assertEqual(set(profile["track_modifiers"]), {"people_work", "soldiers_weapons", "culture_school"})
            signature = []
            for track, modifier in profile["track_modifiers"].items():
                self.assertGreaterEqual(modifier["duration"], 0.65, (country, track))
                self.assertLessEqual(modifier["duration"], 1.65, (country, track))
                self.assertGreaterEqual(modifier["cost"], 0.75, (country, track))
                self.assertLessEqual(modifier["cost"], 1.60, (country, track))
                signature.append((track, modifier["duration"], modifier["cost"]))
            if country != "custom_default":
                signatures.add(tuple(signature))
        self.assertGreaterEqual(len(signatures), 5)

    def test_profile_references_resolve(self):
        ids = set(self.by_id)
        for country, profile in self.profiles["countries"].items():
            for tech_id in profile.get("favored", []):
                self.assertIn(tech_id, ids, (country, tech_id))
            for tech_id, modifier in profile.get("project_modifiers", {}).items():
                self.assertIn(tech_id, ids, (country, tech_id))
                self.assertGreaterEqual(modifier["duration"], 0.65, (country, tech_id))
                self.assertLessEqual(modifier["duration"], 1.65, (country, tech_id))
                self.assertGreaterEqual(modifier["cost"], 0.75, (country, tech_id))
                self.assertLessEqual(modifier["cost"], 1.60, (country, tech_id))

    def test_authoritarian_media_control_is_not_a_pure_bonus(self):
        tech = self.by_id["cs_censorship_state_control"]
        self.assertTrue(tech.get("risks"))
        self.assertLess(tech["risks"]["civil_freedom"], 0)
        self.assertLess(tech["risks"]["research_pluralism"], 0)
        self.assertIn("not as a pure bonus", tech["portrayal_note"])


if __name__ == "__main__":
    unittest.main()
