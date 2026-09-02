import json
import unittest
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
EPOCH = ROOT / "riseOfReign" / "data" / "epochs" / "1933"


class SuccessionCapitulationTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        cls.data = json.loads((EPOCH / "succession_capitulation_1933_1945.json").read_text(encoding="utf-8"))
        cls.manifest = json.loads((EPOCH / "manifest.json").read_text(encoding="utf-8"))

    def test_manifest_registers_lifecycle(self):
        self.assertEqual(
            self.manifest["files"]["succession_capitulation"],
            "succession_capitulation_1933_1945.json",
        )

    def test_core_countries_have_chains(self):
        expected = {
            "turkey", "united_kingdom", "united_states", "soviet_union",
            "germany", "italy", "poland", "france", "japan",
        }
        self.assertEqual(set(self.data["countries"]), expected)
        for country, chain in self.data["countries"].items():
            self.assertIn("initial", chain, country)
            self.assertIn("control_actor", chain["initial"], country)
            self.assertIn("player_avatar", chain["initial"], country)
            self.assertIn("transitions", chain, country)

    def test_control_roles_are_separate(self):
        fields = set(self.data["control_model"]["separate_fields"])
        self.assertEqual(fields, {"head_of_state", "head_of_government", "control_actor", "player_avatar"})

    def test_germany_does_not_get_fake_post_surrender_ruler(self):
        transitions = self.data["countries"]["germany"]["transitions"]
        surrender = next(x for x in transitions if x["event_id"] == "de_1945_unconditional_surrender")
        self.assertEqual(surrender["player_avatar"], "allied_control_germany")
        allied = next(x for x in transitions if x["event_id"] == "de_1945_flensburg_government_arrested")
        self.assertIn("Allied Control Council", allied["control_actor"])

    def test_poland_continues_after_territorial_defeat(self):
        chain = self.data["countries"]["poland"]
        self.assertIn("does not use a simple capitulation", chain["special_rule"])
        exile = next(x for x in chain["transitions"] if x["event_id"] == "pl_1939_government_in_exile_formed")
        self.assertEqual(exile["player_avatar"], "wladyslaw_sikorski")
        self.assertEqual(exile["effects"]["territorial_control"], 0)
        self.assertEqual(exile["effects"]["underground_state_access"], 1)

    def test_italy_and_france_support_regime_split(self):
        italy = next(x for x in self.data["countries"]["italy"]["transitions"] if x["type"] == "regime_split")
        france = next(x for x in self.data["countries"]["france"]["transitions"] if x["type"] == "regime_split")
        self.assertEqual(set(italy["branches"]), {"kingdom", "rsi"})
        self.assertEqual(set(france["branches"]), {"vichy", "free_france"})

    def test_clear_successions_transfer_player(self):
        turkey = next(x for x in self.data["countries"]["turkey"]["transitions"] if x.get("to_avatar") == "ismet_inonu")
        usa = next(x for x in self.data["countries"]["united_states"]["transitions"] if x.get("to_avatar") == "harry_truman")
        self.assertTrue(turkey["player_transfer"])
        self.assertTrue(usa["player_transfer"])

    def test_sources_present_for_historical_transition_chains(self):
        for country, chain in self.data["countries"].items():
            if chain["transitions"] and country != "soviet_union":
                self.assertTrue(chain.get("sources"), country)


if __name__ == "__main__":
    unittest.main()
