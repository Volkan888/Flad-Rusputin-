import json
import unittest
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
JANUARY = ROOT / "riseOfReign" / "data" / "epochs" / "1933" / "months" / "january.json"
MANIFEST = ROOT / "riseOfReign" / "data" / "epochs" / "1933" / "manifest.json"
CLIENT = ROOT / "riseOfReign" / "client" / "scripts" / "office_hub.gd"
SCENE = ROOT / "riseOfReign" / "client" / "scenes" / "office_hub.tscn"


class January1933Tests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        cls.data = json.loads(JANUARY.read_text(encoding="utf-8"))

    def test_calendar_contract(self):
        self.assertEqual(self.data["month_id"], "1933-01")
        self.assertEqual(self.data["start_date"], "1933-01-01")
        self.assertEqual(self.data["end_date"], "1933-01-31")
        self.assertEqual(self.data["next_date"], "1933-02-01")
        self.assertEqual(
            self.data["turn_phases"],
            ["briefing", "office_decisions", "phone_or_meeting", "map_action", "resolve", "historical_anchor", "report"],
        )

    def test_all_avatar_slices_are_playable(self):
        expected = {"ataturk", "hitler", "stalin", "churchill", "roosevelt", "mussolini", "custom"}
        self.assertEqual(set(self.data["avatars"]), expected)
        for avatar, slice_ in self.data["avatars"].items():
            self.assertTrue(slice_["briefing"], avatar)
            self.assertTrue(slice_["decisions"], avatar)
            self.assertTrue(slice_["phone_opportunities"], avatar)
            self.assertTrue(slice_["map_actions"], avatar)
            self.assertIn("authority", slice_["starting_indicators"], avatar)
            self.assertIn("stability", slice_["starting_indicators"], avatar)
            for decision in slice_["decisions"]:
                self.assertTrue(decision["choices"], (avatar, decision["id"]))
                if decision.get("required"):
                    self.assertGreaterEqual(len(decision["choices"]), 2)

    def test_effect_values_are_numeric_and_bounded_seed_values(self):
        for avatar, slice_ in self.data["avatars"].items():
            for key, value in slice_["starting_indicators"].items():
                self.assertIsInstance(value, (int, float), (avatar, key))
                self.assertGreaterEqual(value, 0, (avatar, key))
                self.assertLessEqual(value, 100, (avatar, key))
            for decision in slice_["decisions"]:
                for choice in decision["choices"]:
                    for key, value in choice.get("effects", {}).items():
                        self.assertIsInstance(value, (int, float), (avatar, decision["id"], choice["id"], key))

    def test_historical_january_invariants(self):
        hitler = self.data["avatars"]["hitler"]
        self.assertIn("do not control the German government", hitler["briefing"])
        self.assertEqual(hitler["historical_anchor"]["date"], "1933-01-30")
        self.assertEqual(hitler["historical_anchor"]["office_transition"], {"from_level": 0, "to_level": 1})
        self.assertIn("Historical and critical", hitler["portrayal_note"])

        roosevelt = self.data["avatars"]["roosevelt"]
        self.assertIn("President-elect", roosevelt["briefing"])
        self.assertIn("4 March", roosevelt["restriction_note"])

        churchill = self.data["avatars"]["churchill"]
        self.assertIn("outside the government", churchill["briefing"])
        self.assertIn("military command", churchill["restriction_note"])

        stalin = self.data["avatars"]["stalin"]
        self.assertIn("humanitarian crisis", stalin["briefing"])
        self.assertIn("Civilian suffering", stalin["humanitarian_note"])

    def test_no_decision_is_pure_unbounded_bonus(self):
        for avatar, slice_ in self.data["avatars"].items():
            for decision in slice_["decisions"]:
                for choice in decision["choices"]:
                    effects = choice.get("effects", {})
                    self.assertTrue(effects, (avatar, choice["id"]))
                    self.assertLessEqual(max(abs(v) for v in effects.values()), 10, (avatar, choice["id"]))

    def test_manifest_registers_month(self):
        manifest = json.loads(MANIFEST.read_text(encoding="utf-8"))
        version_parts = manifest["content_version"].split(".")
        self.assertEqual(version_parts[0], "1933")
        self.assertGreaterEqual(int(version_parts[-1]), 5)
        self.assertEqual(manifest["files"]["january_1933"], "months/january.json")

    def test_client_has_full_month_loop(self):
        script = CLIENT.read_text(encoding="utf-8")
        scene = SCENE.read_text(encoding="utf-8")
        for token in (
            "/api/v1/months/1933-01/",
            "_show_month_briefing",
            "_show_january_decisions",
            "_show_phone_list",
            "_show_january_map_actions",
            "_finish_january",
            "_show_month_report",
            "HTTPClient.METHOD_POST",
            "1. Februar 1933",
        ):
            self.assertIn(token, script)
        self.assertIn('name="MonthHTTPRequest"', scene)


if __name__ == "__main__":
    unittest.main()
