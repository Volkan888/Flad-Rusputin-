using System.Text.Json.Nodes;

namespace RiseOfReign.Application;

public sealed class January1933Service
{
    public async Task<JsonObject> LoadAsync(string epochDirectory, CancellationToken cancellationToken = default)
    {
        var path = Path.Combine(Path.GetFullPath(epochDirectory), "months", "january.json");
        if (!File.Exists(path))
            throw new FileNotFoundException("January 1933 content is missing.", path);

        var root = JsonNode.Parse(await File.ReadAllTextAsync(path, cancellationToken))?.AsObject()
            ?? throw new InvalidDataException("Could not parse months/january.json.");
        Validate(root);
        return root;
    }

    public JsonObject GetAvatarSlice(JsonObject month, string avatarId)
    {
        var avatars = month["avatars"]?.AsObject()
            ?? throw new InvalidDataException("January content has no avatars object.");
        if (!avatars.TryGetPropertyValue(avatarId, out var node) || node is null)
            throw new KeyNotFoundException($"Unknown January avatar: {avatarId}");

        var result = node.DeepClone().AsObject();
        result["avatar_id"] = avatarId;
        result["month_id"] = month["month_id"]?.GetValue<string>() ?? "1933-01";
        result["start_date"] = month["start_date"]?.GetValue<string>() ?? "1933-01-01";
        result["end_date"] = month["end_date"]?.GetValue<string>() ?? "1933-01-31";
        result["next_date"] = month["next_date"]?.GetValue<string>() ?? "1933-02-01";
        result["turn_phases"] = month["turn_phases"]?.DeepClone();
        result["shared_context"] = month["shared_context"]?.DeepClone();
        return result;
    }

    public JsonObject Resolve(JsonObject month, string avatarId, JsonObject request)
    {
        var slice = GetAvatarSlice(month, avatarId);
        var indicators = slice["starting_indicators"]?.DeepClone().AsObject()
            ?? throw new InvalidDataException("January avatar slice has no starting indicators.");
        var applied = new JsonArray();

        var selected = request["decision_choices"]?.AsObject()
            ?? throw new InvalidDataException("decision_choices is required.");

        foreach (var decisionNode in slice["decisions"]?.AsArray() ?? [])
        {
            var decision = decisionNode?.AsObject() ?? continue;
            var decisionId = decision["id"]?.GetValue<string>() ?? "";
            var required = decision["required"]?.GetValue<bool>() ?? false;
            var choiceId = selected[decisionId]?.GetValue<string>();
            if (required && string.IsNullOrWhiteSpace(choiceId))
                throw new InvalidDataException($"Required January decision missing: {decisionId}");
            if (string.IsNullOrWhiteSpace(choiceId))
                continue;

            var choice = (decision["choices"]?.AsArray() ?? [])
                .Select(x => x?.AsObject())
                .FirstOrDefault(x => x is not null && string.Equals(x["id"]?.GetValue<string>(), choiceId, StringComparison.OrdinalIgnoreCase))
                ?? throw new InvalidDataException($"Invalid choice '{choiceId}' for decision '{decisionId}'.");

            ApplyEffects(indicators, choice["effects"]?.AsObject());
            applied.Add(new JsonObject
            {
                ["type"] = "decision",
                ["decision_id"] = decisionId,
                ["choice_id"] = choiceId,
                ["label"] = choice["label"]?.GetValue<string>() ?? choiceId,
                ["effects"] = choice["effects"]?.DeepClone()
            });
        }

        var phone = request["phone_action"]?.AsObject()
            ?? throw new InvalidDataException("A January phone_action is required for the vertical slice.");
        var phoneCategory = phone["category"]?.GetValue<string>() ?? "";
        var phoneOption = phone["option"]?.GetValue<string>() ?? "";
        var allowedPhone = (slice["phone_opportunities"]?.AsArray() ?? [])
            .Any(x => string.Equals(x?.GetValue<string>(), phoneCategory, StringComparison.OrdinalIgnoreCase));
        if (!allowedPhone || string.IsNullOrWhiteSpace(phoneOption))
            throw new InvalidDataException("Selected January phone action is not available for this avatar.");
        applied.Add(new JsonObject { ["type"]="phone", ["category"]=phoneCategory, ["option"]=phoneOption });

        var mapAction = request["map_action"]?.GetValue<string>()
            ?? throw new InvalidDataException("A January map_action is required for the vertical slice.");
        var allowedMap = (slice["map_actions"]?.AsArray() ?? [])
            .Any(x => string.Equals(x?.GetValue<string>(), mapAction, StringComparison.OrdinalIgnoreCase));
        if (!allowedMap)
            throw new InvalidDataException("Selected January map action is not available for this avatar.");
        applied.Add(new JsonObject { ["type"]="map", ["action"]=mapAction });

        var historical = slice["historical_anchor"]?.AsObject();
        var officeLevel = slice["start_level"]?.GetValue<int?>();
        if (historical is not null)
        {
            ApplyEffects(indicators, historical["effects"]?.AsObject());
            applied.Add(new JsonObject
            {
                ["type"] = "historical_anchor",
                ["id"] = historical["id"]?.GetValue<string>(),
                ["date"] = historical["date"]?.GetValue<string>(),
                ["window"] = historical["window"]?.GetValue<string>(),
                ["effects"] = historical["effects"]?.DeepClone()
            });
            var transition = historical["office_transition"]?.AsObject();
            if (transition is not null)
                officeLevel = transition["to_level"]?.GetValue<int>();
        }

        ClampIndicators(indicators);

        return new JsonObject
        {
            ["avatar_id"] = avatarId,
            ["resolved_month"] = "1933-01",
            ["next_date"] = month["next_date"]?.GetValue<string>() ?? "1933-02-01",
            ["resulting_indicators"] = indicators,
            ["office_level"] = officeLevel,
            ["applied_actions"] = applied,
            ["report"] = BuildReport(applied, indicators),
            ["status"] = "resolved"
        };
    }

    private static void ApplyEffects(JsonObject indicators, JsonObject? effects)
    {
        if (effects is null) return;
        foreach (var pair in effects)
        {
            if (pair.Value is null) continue;
            var delta = pair.Value.GetValue<decimal>();
            var current = indicators[pair.Key]?.GetValue<decimal>() ?? 0m;
            indicators[pair.Key] = current + delta;
        }
    }

    private static void ClampIndicators(JsonObject indicators)
    {
        foreach (var key in indicators.Select(x => x.Key).ToArray())
        {
            var value = indicators[key]?.GetValue<decimal>() ?? 0m;
            indicators[key] = Math.Clamp(value, 0m, 100m);
        }
    }

    private static string BuildReport(JsonArray applied, JsonObject indicators)
    {
        var decisions = applied.Count(x => x?["type"]?.GetValue<string>() == "decision");
        var anchors = applied.Count(x => x?["type"]?.GetValue<string>() == "historical_anchor");
        var authority = indicators["authority"]?.GetValue<decimal>() ?? 0m;
        var stability = indicators["stability"]?.GetValue<decimal>() ?? 0m;
        return $"Januar 1933 abgeschlossen. Entscheidungen: {decisions}; historische Anker: {anchors}; Autorität: {authority:0.#}; Stabilität: {stability:0.#}.";
    }

    private static void Validate(JsonObject root)
    {
        if (root["month_id"]?.GetValue<string>() != "1933-01")
            throw new InvalidDataException("January content must use month_id 1933-01.");
        var avatars = root["avatars"]?.AsObject()
            ?? throw new InvalidDataException("January content requires avatars.");
        var required = new[] { "ataturk", "hitler", "stalin", "churchill", "roosevelt", "mussolini", "custom" };
        foreach (var avatar in required)
        {
            if (!avatars.ContainsKey(avatar))
                throw new InvalidDataException($"January content missing avatar: {avatar}");
            var slice = avatars[avatar]?.AsObject() ?? throw new InvalidDataException($"Invalid avatar slice: {avatar}");
            if ((slice["decisions"]?.AsArray().Count ?? 0) == 0)
                throw new InvalidDataException($"January avatar has no decisions: {avatar}");
            if ((slice["phone_opportunities"]?.AsArray().Count ?? 0) == 0)
                throw new InvalidDataException($"January avatar has no phone opportunities: {avatar}");
            if ((slice["map_actions"]?.AsArray().Count ?? 0) == 0)
                throw new InvalidDataException($"January avatar has no map actions: {avatar}");
        }
    }
}
