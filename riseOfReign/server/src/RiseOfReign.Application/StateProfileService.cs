using System.Text.Json.Nodes;

namespace RiseOfReign.Application;

public sealed class StateProfileService
{
    public async Task<JsonObject> LoadAsync(string epochDirectory, CancellationToken cancellationToken = default)
    {
        var path = Path.Combine(Path.GetFullPath(epochDirectory), "state_profiles.json");
        if (!File.Exists(path))
            throw new FileNotFoundException("1933 state profile content is missing.", path);

        var root = JsonNode.Parse(await File.ReadAllTextAsync(path, cancellationToken))?.AsObject()
            ?? throw new InvalidDataException("Could not parse state_profiles.json.");
        Validate(root);
        return root;
    }

    public JsonObject GetInitialState(JsonObject profiles, string avatarId, string? countryId)
    {
        var avatars = profiles["avatars"]?.AsObject()
            ?? throw new InvalidDataException("State profiles require avatars.");
        if (!avatars.TryGetPropertyValue(avatarId, out var avatarNode) || avatarNode is null)
            throw new KeyNotFoundException($"Unknown state-profile avatar: {avatarId}");
        var avatar = avatarNode.AsObject();

        var countries = profiles["countries"]?.AsObject()
            ?? throw new InvalidDataException("State profiles require countries.");
        var financeKey = string.Equals(avatarId, "custom", StringComparison.OrdinalIgnoreCase)
            ? (countryId is not null && countries.ContainsKey(countryId) ? countryId : "custom_default")
            : countryId ?? "custom_default";
        if (!countries.TryGetPropertyValue(financeKey, out var countryNode) || countryNode is null)
            countryNode = countries["custom_default"];
        var financeSeed = countryNode?["finance"]?.AsObject()
            ?? throw new InvalidDataException($"No finance profile for {financeKey}.");

        var income = financeSeed["income"]?.DeepClone().AsObject() ?? new JsonObject();
        var expenses = financeSeed["expenses"]?.DeepClone().AsObject() ?? new JsonObject();
        var assets = financeSeed["assets"]?.DeepClone().AsObject() ?? new JsonObject();
        var incomeTotal = SumNumeric(income);
        var expenseTotal = SumNumeric(expenses);
        var treasury = financeSeed["treasury"]?.GetValue<decimal>() ?? 0m;

        var finance = new JsonObject
        {
            ["unit"] = "RP",
            ["treasury"] = treasury,
            ["monthly_income"] = incomeTotal,
            ["monthly_expense"] = expenseTotal,
            ["monthly_net"] = incomeTotal - expenseTotal,
            ["debt_pressure"] = financeSeed["debt_pressure"]?.DeepClone(),
            ["income_breakdown"] = income,
            ["expense_breakdown"] = expenses,
            ["assets"] = assets,
            ["state_asset_index"] = AverageNumeric(assets)
        };

        return new JsonObject
        {
            ["schema_version"] = 1,
            ["avatar_id"] = avatarId,
            ["country_id"] = countryId,
            ["age_display"] = avatar["age_display"]?.DeepClone(),
            ["finance"] = finance,
            ["health"] = avatar["health"]?.DeepClone(),
            ["inventory"] = avatar["inventory"]?.DeepClone(),
            ["inventory_count"] = avatar["inventory"]?.AsArray().Sum(ItemQuantity) ?? 0,
            ["completed_months"] = new JsonArray()
        };
    }

    public JsonObject AdvanceMonth(JsonObject initialState, JsonObject indicators, JsonArray appliedActions)
        => AdvanceMonth(initialState, indicators, appliedActions, "1933-01");

    public JsonObject AdvanceMonth(
        JsonObject initialState,
        JsonObject indicators,
        JsonArray appliedActions,
        string monthId)
    {
        if (string.IsNullOrWhiteSpace(monthId))
            throw new ArgumentException("monthId is required.", nameof(monthId));

        var state = initialState.DeepClone().AsObject();
        var finance = state["finance"]?.AsObject()
            ?? throw new InvalidDataException("Player state is missing finance.");
        var health = state["health"]?.AsObject()
            ?? throw new InvalidDataException("Player state is missing health.");

        var treasuryBefore = indicators["treasury"]?.GetValue<decimal>()
            ?? finance["treasury"]?.GetValue<decimal>()
            ?? 0m;
        var income = finance["monthly_income"]?.GetValue<decimal>() ?? 0m;
        var expense = finance["monthly_expense"]?.GetValue<decimal>() ?? 0m;
        var net = income - expense;
        var treasuryAfter = Math.Max(0m, treasuryBefore + net);
        finance["treasury_before_close"] = treasuryBefore;
        finance["treasury"] = treasuryAfter;
        finance["monthly_net"] = net;
        finance["last_month_ledger"] = new JsonObject
        {
            ["month"] = monthId,
            ["income"] = income,
            ["expense"] = expense,
            ["net"] = net,
            ["treasury_before_close"] = treasuryBefore,
            ["treasury_after_close"] = treasuryAfter
        };
        indicators["treasury"] = treasuryAfter;

        var stability = indicators["stability"]?.GetValue<decimal>() ?? 50m;
        var healthValue = health["health"]?.GetValue<decimal>() ?? 80m;
        var energy = health["energy"]?.GetValue<decimal>() ?? 80m;
        var stress = health["stress"]?.GetValue<decimal>() ?? 40m;

        var stressDelta = 0m;
        var energyDelta = -1m;
        if (stability < 50m) stressDelta += 2m;
        else if (stability >= 70m) stressDelta -= 1m;
        if (treasuryAfter < 20m) stressDelta += 1m;

        foreach (var actionNode in appliedActions)
        {
            var action = actionNode?.AsObject();
            var effects = action?["effects"]?.AsObject();
            if (effects is null) continue;
            var stabilityDelta = effects["stability"]?.GetValue<decimal>() ?? 0m;
            if (stabilityDelta >= 3m) stressDelta -= 1m;
            if (stabilityDelta <= -3m) stressDelta += 1m;
        }

        stress = Clamp100(stress + stressDelta);
        energy = Clamp100(energy + energyDelta);
        if (stress >= 75m) healthValue -= 1m;
        if (energy <= 25m) healthValue -= 1m;
        healthValue = Clamp100(healthValue);

        health["health"] = healthValue;
        health["energy"] = energy;
        health["stress"] = stress;
        health["last_month_change"] = new JsonObject
        {
            ["month"] = monthId,
            ["health_delta"] = healthValue - (initialState["health"]?["health"]?.GetValue<decimal>() ?? healthValue),
            ["energy_delta"] = energy - (initialState["health"]?["energy"]?.GetValue<decimal>() ?? energy),
            ["stress_delta"] = stress - (initialState["health"]?["stress"]?.GetValue<decimal>() ?? stress)
        };

        var completedMonths = state["completed_months"]?.AsArray() ?? new JsonArray();
        if (!completedMonths.Any(x => string.Equals(x?.GetValue<string>(), monthId, StringComparison.OrdinalIgnoreCase)))
            completedMonths.Add(monthId);
        state["completed_months"] = completedMonths;
        state["current_date"] = NextMonthDate(monthId);
        state["inventory_count"] = state["inventory"]?.AsArray().Sum(ItemQuantity) ?? 0;
        state["leadership_availability"] = LeadershipAvailability(healthValue, energy);
        return state;
    }

    private static string NextMonthDate(string monthId)
    {
        if (!DateOnly.TryParse($"{monthId}-01", out var date))
            return monthId;
        return date.AddMonths(1).ToString("yyyy-MM-dd");
    }

    private static int ItemQuantity(JsonNode? node)
        => node?["quantity"]?.GetValue<int>() ?? 0;

    private static decimal SumNumeric(JsonObject values)
        => values.Sum(x => x.Value?.GetValue<decimal>() ?? 0m);

    private static decimal AverageNumeric(JsonObject values)
        => values.Count == 0 ? 0m : Math.Round(SumNumeric(values) / values.Count, 1);

    private static decimal Clamp100(decimal value) => Math.Clamp(value, 0m, 100m);

    private static string LeadershipAvailability(decimal health, decimal energy)
    {
        if (health <= 5m || energy <= 5m) return "incapacitated";
        if (health <= 20m || energy <= 20m) return "critical";
        if (health <= 40m || energy <= 35m) return "limited";
        return "normal";
    }

    private static void Validate(JsonObject root)
    {
        var avatars = root["avatars"]?.AsObject()
            ?? throw new InvalidDataException("state_profiles.json requires avatars.");
        var countries = root["countries"]?.AsObject()
            ?? throw new InvalidDataException("state_profiles.json requires countries.");
        foreach (var avatar in new[] { "ataturk", "hitler", "stalin", "churchill", "roosevelt", "mussolini", "custom" })
        {
            if (!avatars.ContainsKey(avatar))
                throw new InvalidDataException($"State profile missing avatar: {avatar}");
            var profile = avatars[avatar]?.AsObject() ?? throw new InvalidDataException($"Invalid avatar profile: {avatar}");
            var health = profile["health"]?.AsObject() ?? throw new InvalidDataException($"Health missing: {avatar}");
            foreach (var key in new[] { "health", "energy", "stress", "mobility", "medical_access" })
            {
                var value = health[key]?.GetValue<decimal>() ?? throw new InvalidDataException($"Health {key} missing: {avatar}");
                if (value is < 0m or > 100m) throw new InvalidDataException($"Health {avatar}.{key} must be 0..100.");
            }
            if ((profile["inventory"]?.AsArray().Count ?? 0) == 0)
                throw new InvalidDataException($"Inventory missing: {avatar}");
        }
        foreach (var country in countries)
        {
            var finance = country.Value?["finance"]?.AsObject() ?? throw new InvalidDataException($"Finance missing: {country.Key}");
            foreach (var bucket in new[] { "income", "expenses", "assets" })
                if ((finance[bucket]?.AsObject().Count ?? 0) == 0) throw new InvalidDataException($"Finance {country.Key}.{bucket} is empty.");
        }
    }
}
