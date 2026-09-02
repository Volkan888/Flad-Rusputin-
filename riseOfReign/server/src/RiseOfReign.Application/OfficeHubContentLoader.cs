using System.Text.Json.Nodes;

namespace RiseOfReign.Application;

public sealed class OfficeHubContentLoader
{
    private static readonly string[] RequiredAvatars =
    {
        "ataturk", "hitler", "stalin", "churchill", "roosevelt", "mussolini", "custom"
    };

    private static readonly HashSet<string> RequiredInteractionTypes =
        new(StringComparer.OrdinalIgnoreCase) { "side_menu", "room", "phone_list" };

    public async Task<JsonNode> LoadAsync(string epochDirectory, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(epochDirectory))
            throw new ArgumentException("Epoch directory is required.", nameof(epochDirectory));

        var path = Path.Combine(Path.GetFullPath(epochDirectory), "office_hubs.json");
        if (!File.Exists(path))
            throw new FileNotFoundException("Office hub content file is missing.", path);

        var json = await File.ReadAllTextAsync(path, cancellationToken);
        var root = JsonNode.Parse(json) ?? throw new InvalidDataException("Could not parse office_hubs.json.");

        Validate(root);
        return root;
    }

    private static void Validate(JsonNode root)
    {
        var errors = new List<string>();

        if (root["epoch"]?.GetValue<int>() != 1933)
            errors.Add("office_hubs.json epoch must be 1933.");

        var interactionTypes = RequireArray(root, "interaction_types", errors);
        var allowedInteractions = interactionTypes
            .Select(x => x?.GetValue<string>())
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Select(x => x!)
            .ToHashSet(StringComparer.OrdinalIgnoreCase);

        if (!allowedInteractions.SetEquals(RequiredInteractionTypes))
            errors.Add("interaction_types must contain exactly: side_menu, room, phone_list.");

        var sideRoutes = RequireArray(root, "side_menu_routes", errors)
            .Select(x => x?.GetValue<string>())
            .Where(x => !string.IsNullOrWhiteSpace(x))
            .Select(x => x!)
            .ToHashSet(StringComparer.OrdinalIgnoreCase);

        var sharedObjects = RequireArray(root, "shared_objects", errors);
        var officeLevels = RequireArray(root, "office_levels", errors);
        var rooms = RequireArray(root, "rooms", errors);
        var avatarOffices = RequireObject(root, "avatar_offices", errors);

        var roomIds = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        foreach (var node in rooms)
        {
            if (node is not JsonObject room)
            {
                errors.Add("rooms entries must be objects.");
                continue;
            }

            var id = GetString(room, "id", "room", errors);
            if (!string.IsNullOrWhiteSpace(id) && !roomIds.Add(id))
                errors.Add($"Duplicate room id: {id}");

            if (!TryGetInt(room, "required_office_level", out var requiredLevel) || requiredLevel is < 0 or > 5)
                errors.Add($"Room {id}: required_office_level must be 0..5.");

            if (room["opens"] is not JsonArray opens || opens.Count == 0)
                errors.Add($"Room {id}: opens must contain at least one destination.");
        }

        var objectIds = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        var phoneRoute = root["phone_system"]?["default_route"]?.GetValue<string>() ?? "contacts";

        foreach (var node in sharedObjects)
        {
            if (node is not JsonObject obj)
            {
                errors.Add("shared_objects entries must be objects.");
                continue;
            }

            var id = GetString(obj, "id", "shared object", errors);
            if (!string.IsNullOrWhiteSpace(id) && !objectIds.Add(id))
                errors.Add($"Duplicate shared object id: {id}");

            var interaction = obj["interaction"]?.GetValue<string>();
            var opens = obj["opens"]?.GetValue<string>();

            if (string.IsNullOrWhiteSpace(interaction) || !allowedInteractions.Contains(interaction))
                errors.Add($"Shared object {id}: invalid interaction.");
            if (string.IsNullOrWhiteSpace(opens))
                errors.Add($"Shared object {id}: opens is required.");
            else if (string.Equals(interaction, "side_menu", StringComparison.OrdinalIgnoreCase) && !sideRoutes.Contains(opens))
                errors.Add($"Shared object {id}: unknown side menu route {opens}.");
            else if (string.Equals(interaction, "room", StringComparison.OrdinalIgnoreCase) && !roomIds.Contains(opens))
                errors.Add($"Shared object {id}: unknown room {opens}.");
            else if (string.Equals(interaction, "phone_list", StringComparison.OrdinalIgnoreCase) &&
                     !string.Equals(opens, phoneRoute, StringComparison.OrdinalIgnoreCase))
                errors.Add($"Shared object {id}: phone route must be {phoneRoute}.");

            var upgradesTo = obj["upgrades_to"]?.GetValue<string>();
            if (!string.IsNullOrWhiteSpace(upgradesTo) && !roomIds.Contains(upgradesTo))
                errors.Add($"Shared object {id}: upgrades_to references missing room {upgradesTo}.");
        }

        if (officeLevels.Count != 6)
            errors.Add("office_levels must contain exactly levels 0..5.");

        for (var expected = 0; expected < officeLevels.Count; expected++)
        {
            if (officeLevels[expected] is not JsonObject level)
            {
                errors.Add($"office_levels[{expected}] must be an object.");
                continue;
            }

            if (!TryGetInt(level, "level", out var actual) || actual != expected)
                errors.Add($"office_levels must be sequential; expected {expected}.");

            if (!TryGetInt(level, "build_months", out var months) || months < 0)
                errors.Add($"Office level {expected}: build_months must be non-negative.");

            if (level["gameplay_features"] is not JsonArray features || features.Count == 0)
                errors.Add($"Office level {expected}: gameplay_features cannot be empty.");

            ValidateNonNegativeNumberObject(level["materials"], $"Office level {expected} materials", errors);
            ValidateNonNegativeNumberObject(level["monthly_maintenance"], $"Office level {expected} maintenance", errors);
        }

        foreach (var avatarId in RequiredAvatars)
        {
            if (!avatarOffices.TryGetPropertyValue(avatarId, out var avatarNode) || avatarNode is not JsonObject avatar)
            {
                errors.Add($"office_hubs.json is missing avatar office: {avatarId}");
                continue;
            }

            if (!string.Equals(avatarId, "custom", StringComparison.OrdinalIgnoreCase))
            {
                if (!TryGetInt(avatar, "start_level", out var startLevel) || startLevel is < 0 or > 5)
                    errors.Add($"Avatar {avatarId}: start_level must be 0..5.");
            }

            if (avatar["signature_object"] is not JsonObject signature)
            {
                errors.Add($"Avatar {avatarId}: signature_object is required.");
            }
            else
            {
                var interaction = signature["interaction"]?.GetValue<string>();
                var opens = signature["opens"]?.GetValue<string>();
                if (!string.Equals(interaction, "side_menu", StringComparison.OrdinalIgnoreCase))
                    errors.Add($"Avatar {avatarId}: signature_object must open a side_menu.");
                if (string.IsNullOrWhiteSpace(opens) || !sideRoutes.Contains(opens))
                    errors.Add($"Avatar {avatarId}: signature_object references unknown side menu route.");
            }
        }

        ValidateHistoricalInvariants(avatarOffices, errors);

        var upgradeRules = root["upgrade_rules"]?.AsObject();
        if (upgradeRules?["real_money_purchase"]?.GetValue<bool>() != false)
            errors.Add("Office progression must not allow real-money purchase.");
        if (!string.Equals(upgradeRules?["currency"]?.GetValue<string>(), "in_game_state_treasury_only", StringComparison.Ordinal))
            errors.Add("Office progression currency must be in_game_state_treasury_only.");

        var accessibility = root["accessibility_and_mobile"]?.AsObject();
        if (accessibility?["text_list_fallback"]?.GetValue<bool>() != true)
            errors.Add("Office UI requires a textual navigation fallback.");
        if (accessibility?["no_dead_ends"]?.GetValue<bool>() != true)
            errors.Add("Office UI must guarantee no dead-end room.");

        if (errors.Count > 0)
            throw new InvalidDataException("Invalid office hub content:\n - " + string.Join("\n - ", errors));
    }

    private static void ValidateHistoricalInvariants(JsonObject offices, ICollection<string> errors)
    {
        var hitler = offices["hitler"]?.AsObject();
        if (hitler?["start_level"]?.GetValue<int>() != 0)
            errors.Add("Hitler must start at office level 0 on 1933-01-01.");
        if (hitler?["start_access"]?["government"]?.GetValue<bool>() != false)
            errors.Add("Hitler must not have government office access on 1933-01-01.");
        if (!string.Equals(hitler?["historical_transition"]?["date"]?.GetValue<string>(), "1933-01-30", StringComparison.Ordinal))
            errors.Add("Hitler chancellorship office transition must be 1933-01-30.");

        var roosevelt = offices["roosevelt"]?.AsObject();
        if (roosevelt?["start_level"]?.GetValue<int>() != 0)
            errors.Add("Roosevelt must start at office level 0 as president-elect.");
        if (!string.Equals(roosevelt?["historical_transition"]?["date"]?.GetValue<string>(), "1933-03-04", StringComparison.Ordinal))
            errors.Add("Roosevelt inauguration office transition must be 1933-03-04.");

        var churchill = offices["churchill"]?.AsObject();
        if (churchill?["start_access"]?["direct_military_command"]?.GetValue<bool>() != false)
            errors.Add("Churchill must not start with direct military command in 1933.");
    }

    private static JsonArray RequireArray(JsonNode root, string property, ICollection<string> errors)
    {
        if (root[property] is JsonArray array)
            return array;

        errors.Add($"{property} is required and must be an array.");
        return new JsonArray();
    }

    private static JsonObject RequireObject(JsonNode root, string property, ICollection<string> errors)
    {
        if (root[property] is JsonObject obj)
            return obj;

        errors.Add($"{property} is required and must be an object.");
        return new JsonObject();
    }

    private static string GetString(JsonObject obj, string property, string label, ICollection<string> errors)
    {
        var value = obj[property]?.GetValue<string>();
        if (!string.IsNullOrWhiteSpace(value))
            return value;

        errors.Add($"{label}: {property} is required.");
        return "<missing>";
    }

    private static bool TryGetInt(JsonObject obj, string property, out int value)
    {
        value = default;
        try
        {
            if (obj[property] is null)
                return false;
            value = obj[property]!.GetValue<int>();
            return true;
        }
        catch
        {
            return false;
        }
    }

    private static void ValidateNonNegativeNumberObject(JsonNode? node, string label, ICollection<string> errors)
    {
        if (node is not JsonObject obj)
        {
            errors.Add($"{label} must be an object.");
            return;
        }

        foreach (var pair in obj)
        {
            if (pair.Value is null)
            {
                errors.Add($"{label}.{pair.Key} cannot be null.");
                continue;
            }

            try
            {
                if (pair.Value.GetValue<decimal>() < 0)
                    errors.Add($"{label}.{pair.Key} cannot be negative.");
            }
            catch
            {
                errors.Add($"{label}.{pair.Key} must be numeric.");
            }
        }
    }
}
