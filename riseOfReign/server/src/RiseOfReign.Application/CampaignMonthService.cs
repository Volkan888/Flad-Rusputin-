using System.Text.Json.Nodes;

namespace RiseOfReign.Application;

public sealed class CampaignMonthService
{
    private static readonly string[] RequiredAvatars =
    [
        "ataturk", "hitler", "stalin", "churchill", "roosevelt", "mussolini", "custom"
    ];

    public async Task<JsonObject> LoadAsync(
        string epochDirectory,
        string relativePath,
        CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(relativePath))
            throw new ArgumentException("A relative month path is required.", nameof(relativePath));

        var epochRoot = Path.GetFullPath(epochDirectory);
        var path = Path.GetFullPath(Path.Combine(epochRoot, relativePath));
        if (!path.StartsWith(epochRoot, StringComparison.OrdinalIgnoreCase))
            throw new InvalidDataException("Month path must stay inside the epoch directory.");
        if (!File.Exists(path))
            throw new FileNotFoundException("Campaign month content is missing.", path);

        var root = JsonNode.Parse(await File.ReadAllTextAsync(path, cancellationToken))?.AsObject()
            ?? throw new InvalidDataException($"Could not parse {relativePath}.");
        Validate(root, relativePath);
        return root;
    }

    public JsonObject GetAvatarSlice(JsonObject month, string avatarId)
    {
        var avatars = month["avatars"]?.AsObject()
            ?? throw new InvalidDataException("Campaign month has no avatars object.");
        if (!avatars.TryGetPropertyValue(avatarId, out var node) || node is null)
            throw new KeyNotFoundException($"Unknown campaign-month avatar: {avatarId}");

        var result = node.DeepClone().AsObject();
        result["avatar_id"] = avatarId;
        result["month_id"] = month["month_id"]?.GetValue<string>() ?? "";
        result["title"] = month["title"]?.DeepClone();
        result["start_date"] = month["start_date"]?.DeepClone();
        result["end_date"] = month["end_date"]?.DeepClone();
        result["next_date"] = month["next_date"]?.DeepClone();
        result["next_month_id"] = month["next_month_id"]?.DeepClone();
        result["next_content_available"] = month["next_content_available"]?.DeepClone() ?? JsonValue.Create(false);
        result["turn_phases"] = month["turn_phases"]?.DeepClone();
        result["shared_context"] = month["shared_context"]?.DeepClone();
        result["learning_focus"] = month["learning_focus"]?.DeepClone();
        return result;
    }

    public JsonObject Resolve(JsonObject month, string avatarId, JsonObject request)
    {
        var slice = GetAvatarSlice(month, avatarId);
        var indicators = request["starting_indicators"] is JsonObject suppliedIndicators
            ? suppliedIndicators.DeepClone().AsObject()
            : slice["starting_indicators"]?.DeepClone().AsObject()
                ?? throw new InvalidDataException("Campaign-month avatar slice has no starting indicators.");
        var applied = new JsonArray();

        var selected = request["decision_choices"]?.AsObject()
            ?? throw new InvalidDataException("decision_choices is required.");

        foreach (var decisionNode in slice["decisions"]?.AsArray() ?? [])
        {
            if (decisionNode is null)
                continue;
            var decision = decisionNode.AsObject();
            var decisionId = decision["id"]?.GetValue<string>() ?? "";
            var required = decision["required"]?.GetValue<bool>() ?? false;
            var choiceId = selected[decisionId]?.GetValue<string>();
            if (required && string.IsNullOrWhiteSpace(choiceId))
                throw new InvalidDataException($"Required campaign-month decision missing: {decisionId}");
            if (string.IsNullOrWhiteSpace(choiceId))
                continue;

            var choice = (decision["choices"]?.AsArray() ?? [])
                .Where(x => x is not null)
                .Select(x => x!.AsObject())
                .FirstOrDefault(x => string.Equals(x["id"]?.GetValue<string>(), choiceId, StringComparison.OrdinalIgnoreCase))
                ?? throw new InvalidDataException($"Invalid choice '{choiceId}' for decision '{decisionId}'.");

            ApplyEffects(indicators, choice["effects"]?.AsObject());
            applied.Add(new JsonObject
            {
                ["type"] = "decision",
                ["decision_id"] = decisionId,
                ["choice_id"] = choiceId,
                ["label"] = choice["label"]?.GetValue<string>() ?? choiceId,
                ["effects"] = choice["effects"]?.DeepClone(),
                ["learning_note"] = choice["learning_note"]?.DeepClone()
            });
        }

        var phone = request["phone_action"]?.AsObject()
            ?? throw new InvalidDataException("A phone_action is required for the current vertical slice.");
        var phoneCategory = phone["category"]?.GetValue<string>() ?? "";
        var phoneOption = phone["option"]?.GetValue<string>() ?? "";
        var allowedPhone = (slice["phone_opportunities"]?.AsArray() ?? [])
            .Any(x => string.Equals(x?.GetValue<string>(), phoneCategory, StringComparison.OrdinalIgnoreCase));
        if (!allowedPhone || string.IsNullOrWhiteSpace(phoneOption))
            throw new InvalidDataException("Selected phone action is not available for this avatar.");
        applied.Add(new JsonObject
        {
            ["type"] = "phone",
            ["category"] = phoneCategory,
            ["option"] = phoneOption
        });

        var mapAction = request["map_action"]?.GetValue<string>()
            ?? throw new InvalidDataException("A map_action is required for the current vertical slice.");
        var allowedMap = (slice["map_actions"]?.AsArray() ?? [])
            .Any(x => string.Equals(x?.GetValue<string>(), mapAction, StringComparison.OrdinalIgnoreCase));
        if (!allowedMap)
            throw new InvalidDataException("Selected map action is not available for this avatar.");
        applied.Add(new JsonObject { ["type"] = "map", ["action"] = mapAction });

        int? officeLevel = null;
        ApplyHistoricalAnchor(slice["historical_anchor"] as JsonObject, indicators, applied, ref officeLevel);
        foreach (var anchorNode in slice["historical_anchors"]?.AsArray() ?? [])
            ApplyHistoricalAnchor(anchorNode as JsonObject, indicators, applied, ref officeLevel);

        ClampIndicators(indicators);
        var monthId = month["month_id"]?.GetValue<string>() ?? "unknown";
        var result = new JsonObject
        {
            ["avatar_id"] = avatarId,
            ["resolved_month"] = monthId,
            ["next_date"] = month["next_date"]?.DeepClone(),
            ["next_month_id"] = month["next_month_id"]?.DeepClone(),
            ["next_content_available"] = month["next_content_available"]?.DeepClone() ?? JsonValue.Create(false),
            ["resulting_indicators"] = indicators,
            ["applied_actions"] = applied,
            ["report"] = BuildReport(month, applied, indicators),
            ["learning_summary"] = BuildLearningSummary(slice, applied),
            ["status"] = "resolved"
        };
        result["office_level"] = officeLevel.HasValue ? JsonValue.Create(officeLevel.Value) : null;
        return result;
    }

    private static void ApplyHistoricalAnchor(
        JsonObject? historical,
        JsonObject indicators,
        JsonArray applied,
        ref int? officeLevel)
    {
        if (historical is null)
            return;
        ApplyEffects(indicators, historical["effects"]?.AsObject());
        applied.Add(new JsonObject
        {
            ["type"] = "historical_anchor",
            ["id"] = historical["id"]?.DeepClone(),
            ["date"] = historical["date"]?.DeepClone(),
            ["window"] = historical["window"]?.DeepClone(),
            ["title"] = historical["title"]?.DeepClone(),
            ["context"] = historical["context"]?.DeepClone(),
            ["effects"] = historical["effects"]?.DeepClone(),
            ["source"] = historical["source"]?.DeepClone(),
            ["source_status"] = historical["source_status"]?.DeepClone()
        });
        var transition = historical["office_transition"]?.AsObject();
        if (transition is not null && transition["to_level"] is not null)
            officeLevel = transition["to_level"]!.GetValue<int>();
    }

    private static void ApplyEffects(JsonObject indicators, JsonObject? effects)
    {
        if (effects is null)
            return;
        foreach (var pair in effects)
        {
            if (pair.Value is not JsonValue valueNode ||
                !valueNode.TryGetValue<decimal>(out var delta))
                continue;
            var current = indicators[pair.Key]?.GetValue<decimal>() ?? 0m;
            indicators[pair.Key] = current + delta;
        }
    }

    private static void ClampIndicators(JsonObject indicators)
    {
        foreach (var key in indicators.Select(x => x.Key).ToArray())
        {
            if (indicators[key] is not JsonValue node || !node.TryGetValue<decimal>(out var value))
                continue;
            indicators[key] = Math.Clamp(value, 0m, 100m);
        }
    }

    private static string BuildReport(JsonObject month, JsonArray applied, JsonObject indicators)
    {
        var decisions = applied.Count(x => x?["type"]?.GetValue<string>() == "decision");
        var anchors = applied.Count(x => x?["type"]?.GetValue<string>() == "historical_anchor");
        var authority = indicators["authority"]?.GetValue<decimal>() ?? 0m;
        var stability = indicators["stability"]?.GetValue<decimal>() ?? 0m;
        var title = month["title"]?.GetValue<string>() ?? month["month_id"]?.GetValue<string>() ?? "Monat";
        return $"{title} abgeschlossen. Entscheidungen: {decisions}; historische Anker: {anchors}; Autorität: {authority:0.#}; Stabilität: {stability:0.#}.";
    }

    private static string BuildLearningSummary(JsonObject slice, JsonArray applied)
    {
        var parts = new List<string>();
        if (slice["learning_note"] is JsonValue learning && learning.TryGetValue<string>(out var note) && !string.IsNullOrWhiteSpace(note))
            parts.Add(note);
        var anchors = applied.Count(x => x?["type"]?.GetValue<string>() == "historical_anchor");
        parts.Add(anchors > 0
            ? "Historische Anker wurden getrennt von deinen freien Entscheidungen ausgewertet."
            : "Dieser Monat konzentrierte sich auf Vorbereitung, Zielkonflikte und institutionelle Handlungsspielräume.");
        return string.Join(" ", parts);
    }

    private static void Validate(JsonObject root, string relativePath)
    {
        var monthId = root["month_id"]?.GetValue<string>();
        if (string.IsNullOrWhiteSpace(monthId))
            throw new InvalidDataException($"{relativePath} requires month_id.");
        foreach (var key in new[] { "start_date", "end_date", "next_date" })
            if (string.IsNullOrWhiteSpace(root[key]?.GetValue<string>()))
                throw new InvalidDataException($"{relativePath} requires {key}.");

        var avatars = root["avatars"]?.AsObject()
            ?? throw new InvalidDataException($"{relativePath} requires avatars.");
        foreach (var avatar in RequiredAvatars)
        {
            if (!avatars.ContainsKey(avatar))
                throw new InvalidDataException($"{relativePath} missing avatar: {avatar}");
            var slice = avatars[avatar]?.AsObject()
                ?? throw new InvalidDataException($"Invalid avatar slice: {avatar}");
            if ((slice["decisions"]?.AsArray().Count ?? 0) == 0)
                throw new InvalidDataException($"Month avatar has no decisions: {avatar}");
            if ((slice["phone_opportunities"]?.AsArray().Count ?? 0) == 0)
                throw new InvalidDataException($"Month avatar has no phone opportunities: {avatar}");
            if ((slice["map_actions"]?.AsArray().Count ?? 0) == 0)
                throw new InvalidDataException($"Month avatar has no map actions: {avatar}");
        }
    }
}
