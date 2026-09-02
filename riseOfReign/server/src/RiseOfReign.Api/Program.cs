using System.Text.Json.Nodes;
using RiseOfReign.Application;
using RiseOfReign.Domain;
using RiseOfReign.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<TurnEngine>();
builder.Services.AddSignalR();

var epochPath = ResolveEpochPath(builder.Environment.ContentRootPath);
var mapLoader = new EpochContentLoader();
var officeLoader = new OfficeHubContentLoader();
var januaryService = new January1933Service();
var campaignMonthService = new CampaignMonthService();
var stateProfileService = new StateProfileService();
EpochMapContent? mapContent = null;
JsonNode? officeContent = null;
JsonObject? januaryContent = null;
JsonObject? stateProfileContent = null;
var campaignMonths = new Dictionary<string, JsonObject>(StringComparer.OrdinalIgnoreCase);
var campaignMonthLoadErrors = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
string? mapLoadError = null;
string? officeLoadError = null;
string? januaryLoadError = null;
string? stateProfileLoadError = null;

try { mapContent = await mapLoader.LoadMapAsync(epochPath); }
catch (Exception ex) { mapLoadError = ex.Message; }

try { officeContent = await officeLoader.LoadAsync(epochPath); }
catch (Exception ex) { officeLoadError = ex.Message; }

try { januaryContent = await januaryService.LoadAsync(epochPath); }
catch (Exception ex) { januaryLoadError = ex.Message; }

try { stateProfileContent = await stateProfileService.LoadAsync(epochPath); }
catch (Exception ex) { stateProfileLoadError = ex.Message; }

foreach (var entry in new Dictionary<string, string>
{
    ["1933-01"] = Path.Combine("months", "january.json"),
    ["1933-02"] = Path.Combine("months", "february.json")
})
{
    try { campaignMonths[entry.Key] = await campaignMonthService.LoadAsync(epochPath, entry.Value); }
    catch (Exception ex) { campaignMonthLoadErrors[entry.Key] = ex.Message; }
}

var connectionString = builder.Configuration.GetConnectionString("GameDb");
IOnlineMatchStore? matchStore = null;
OnlineMatchCoordinator? matchCoordinator = null;
if (!string.IsNullOrWhiteSpace(connectionString) && januaryContent is not null && stateProfileContent is not null)
{
    matchStore = new PostgresOnlineMatchStore(connectionString);
    matchCoordinator = new OnlineMatchCoordinator(matchStore, januaryService, januaryContent, stateProfileService, stateProfileContent);
}

var app = builder.Build();
if (matchStore is not null)
    app.Lifetime.ApplicationStopped.Register(() => matchStore.DisposeAsync().AsTask().GetAwaiter().GetResult());

app.MapGet("/health", () => Results.Ok(new
{
    service = "riseOfReign-api",
    status = mapContent is null || officeContent is null || januaryContent is null || stateProfileContent is null || campaignMonths.Count < 2 ? "degraded" : "ok",
    epoch = "1933",
    mapContentLoaded = mapContent is not null,
    officeContentLoaded = officeContent is not null,
    januaryContentLoaded = januaryContent is not null,
    februaryContentLoaded = campaignMonths.ContainsKey("1933-02"),
    stateProfilesLoaded = stateProfileContent is not null,
    playableCampaignMonths = campaignMonths.Keys.OrderBy(x => x).ToArray(),
    onlineMatchStoreConfigured = matchCoordinator is not null,
    mapLoadError,
    officeLoadError,
    januaryLoadError,
    stateProfileLoadError,
    campaignMonthLoadErrors,
    utc = DateTimeOffset.UtcNow
}));

app.MapGet("/api/v1/meta", () => Results.Ok(new
{
    game = "riseOfReign",
    displayName = "Rise of Reign",
    publisher = "VK APPS",
    ruleset = "0.2.0",
    content = "1933.0.13",
    turnUnit = "month",
    maxPlayers = 4,
    soloCampaign = true,
    playableMonths = campaignMonths.Keys.OrderBy(x => x).ToArray()
}));

app.MapGet("/api/v1/map/summary", () => mapContent is null
    ? Results.Problem(mapLoadError ?? "Map content unavailable.", statusCode: StatusCodes.Status503ServiceUnavailable)
    : Results.Ok(new
    {
        mapContent.Source.MapId,
        year = mapContent.Source.CanonicalSource.Year,
        provider = mapContent.Source.CanonicalSource.Provider,
        license = mapContent.Source.CanonicalSource.License,
        resources = mapContent.ResourceNodes.Count,
        connections = mapContent.Connections.Count,
        constructionTemplates = mapContent.ConstructionCatalog.Count
    }));

app.MapGet("/api/v1/map/source", () => mapContent is null
    ? Results.Problem(mapLoadError ?? "Map content unavailable.", statusCode: StatusCodes.Status503ServiceUnavailable)
    : Results.Ok(mapContent.Source));

app.MapGet("/api/v1/map/resources", (string? owner, string? resource) =>
{
    if (mapContent is null)
        return Results.Problem(mapLoadError ?? "Map content unavailable.", statusCode: StatusCodes.Status503ServiceUnavailable);
    IEnumerable<ResourceNode> query = mapContent.ResourceNodes;
    if (!string.IsNullOrWhiteSpace(owner)) query = query.Where(x => string.Equals(x.Owner1933, owner, StringComparison.OrdinalIgnoreCase));
    if (!string.IsNullOrWhiteSpace(resource)) query = query.Where(x => string.Equals(x.Resource, resource, StringComparison.OrdinalIgnoreCase));
    return Results.Ok(query);
});

app.MapGet("/api/v1/map/connections", (string? owner, string? type) =>
{
    if (mapContent is null)
        return Results.Problem(mapLoadError ?? "Map content unavailable.", statusCode: StatusCodes.Status503ServiceUnavailable);
    IEnumerable<MapConnection> query = mapContent.Connections;
    if (!string.IsNullOrWhiteSpace(owner)) query = query.Where(x => string.Equals(x.Owner1933, owner, StringComparison.OrdinalIgnoreCase));
    if (!string.IsNullOrWhiteSpace(type)) query = query.Where(x => string.Equals(x.Type, type, StringComparison.OrdinalIgnoreCase));
    return Results.Ok(query);
});

app.MapGet("/api/v1/construction/catalog", (string? type) =>
{
    if (mapContent is null)
        return Results.Problem(mapLoadError ?? "Map content unavailable.", statusCode: StatusCodes.Status503ServiceUnavailable);
    IEnumerable<ConstructionTemplate> query = mapContent.ConstructionCatalog;
    if (!string.IsNullOrWhiteSpace(type)) query = query.Where(x => string.Equals(x.Type, type, StringComparison.OrdinalIgnoreCase));
    return Results.Ok(query);
});

app.MapGet("/api/v1/offices", () => officeContent is null
    ? Results.Problem(officeLoadError ?? "Office content unavailable.", statusCode: StatusCodes.Status503ServiceUnavailable)
    : Results.Ok(officeContent));

app.MapGet("/api/v1/offices/{avatarId}", (string avatarId) =>
{
    if (officeContent is null)
        return Results.Problem(officeLoadError ?? "Office content unavailable.", statusCode: StatusCodes.Status503ServiceUnavailable);
    var avatarOffices = officeContent["avatar_offices"]?.AsObject();
    if (avatarOffices is null || !avatarOffices.TryGetPropertyValue(avatarId, out var avatarOffice) || avatarOffice is null)
        return Results.NotFound(new { error = "Unknown avatar office.", avatarId });
    return Results.Ok(new
    {
        avatarId,
        sharedObjects = officeContent["shared_objects"],
        officeLevels = officeContent["office_levels"],
        rooms = officeContent["rooms"],
        phoneSystem = officeContent["phone_system"],
        upgradeRules = officeContent["upgrade_rules"],
        relocationAndDamage = officeContent["relocation_and_damage"],
        multiplayerMeetings = officeContent["multiplayer_meetings"],
        dynamicVisualStates = officeContent["dynamic_visual_states"],
        accessibilityAndMobile = officeContent["accessibility_and_mobile"],
        avatarOffice
    });
});

app.MapGet("/api/v1/state/1933/{avatarId}", (string avatarId, string? countryId) =>
{
    if (stateProfileContent is null)
        return Results.Problem(stateProfileLoadError ?? "State profiles unavailable.", statusCode: StatusCodes.Status503ServiceUnavailable);
    try { return Results.Ok(stateProfileService.GetInitialState(stateProfileContent, avatarId, countryId)); }
    catch (KeyNotFoundException) { return Results.NotFound(new { error = "Unknown state-profile avatar.", avatarId }); }
});

// Backward-compatible January endpoints used by the first vertical slice and online-match coordinator.
app.MapGet("/api/v1/months/1933-01/{avatarId}", (string avatarId, string? countryId) =>
{
    if (januaryContent is null || stateProfileContent is null)
        return Results.Problem(januaryLoadError ?? stateProfileLoadError ?? "January content unavailable.", statusCode: StatusCodes.Status503ServiceUnavailable);
    try
    {
        var slice = januaryService.GetAvatarSlice(januaryContent, avatarId);
        var resolvedCountry = countryId ?? slice["country_id"]?.GetValue<string>();
        slice["player_state"] = stateProfileService.GetInitialState(stateProfileContent, avatarId, resolvedCountry);
        return Results.Ok(slice);
    }
    catch (KeyNotFoundException) { return Results.NotFound(new { error = "Unknown January avatar.", avatarId }); }
});

app.MapPost("/api/v1/months/1933-01/{avatarId}/resolve", (string avatarId, string? countryId, JsonObject request) =>
{
    if (januaryContent is null || stateProfileContent is null)
        return Results.Problem(januaryLoadError ?? stateProfileLoadError ?? "January content unavailable.", statusCode: StatusCodes.Status503ServiceUnavailable);
    try
    {
        var slice = januaryService.GetAvatarSlice(januaryContent, avatarId);
        var resolvedCountry = countryId ?? slice["country_id"]?.GetValue<string>();
        var result = januaryService.Resolve(januaryContent, avatarId, request);
        var initialState = stateProfileService.GetInitialState(stateProfileContent, avatarId, resolvedCountry);
        var indicators = result["resulting_indicators"]?.AsObject() ?? throw new InvalidDataException("January resolution missing indicators.");
        var actions = result["applied_actions"]?.AsArray() ?? new JsonArray();
        var playerState = stateProfileService.AdvanceMonth(initialState, indicators, actions);
        result["player_state"] = playerState;
        result["finance"] = playerState["finance"]?.DeepClone();
        result["health"] = playerState["health"]?.DeepClone();
        result["inventory"] = playerState["inventory"]?.DeepClone();
        return Results.Ok(result);
    }
    catch (KeyNotFoundException) { return Results.NotFound(new { error = "Unknown January avatar.", avatarId }); }
    catch (InvalidDataException ex) { return Results.BadRequest(new { error = ex.Message }); }
});

app.MapGet("/api/v1/campaign/months", () => Results.Ok(campaignMonths
    .OrderBy(x => x.Key)
    .Select(x => new
    {
        monthId = x.Key,
        title = x.Value["title"]?.GetValue<string>() ?? x.Key,
        startDate = x.Value["start_date"]?.GetValue<string>(),
        endDate = x.Value["end_date"]?.GetValue<string>(),
        nextMonthId = x.Value["next_month_id"]?.GetValue<string>(),
        nextContentAvailable = x.Value["next_content_available"]?.GetValue<bool>() ?? false
    })));

app.MapGet("/api/v1/campaign/months/{monthId}/{avatarId}", (string monthId, string avatarId, string? countryId) =>
{
    if (stateProfileContent is null)
        return Results.Problem(stateProfileLoadError ?? "State profiles unavailable.", statusCode: StatusCodes.Status503ServiceUnavailable);
    if (!campaignMonths.TryGetValue(monthId, out var month))
        return Results.NotFound(new { error = "Campaign month is not available in this build.", monthId });
    try
    {
        var slice = campaignMonthService.GetAvatarSlice(month, avatarId);
        var resolvedCountry = countryId ?? slice["country_id"]?.GetValue<string>();
        slice["player_state"] = stateProfileService.GetInitialState(stateProfileContent, avatarId, resolvedCountry);
        return Results.Ok(slice);
    }
    catch (KeyNotFoundException) { return Results.NotFound(new { error = "Unknown campaign avatar.", monthId, avatarId }); }
    catch (InvalidDataException ex) { return Results.Problem(ex.Message, statusCode: StatusCodes.Status503ServiceUnavailable); }
});

app.MapPost("/api/v1/campaign/months/{monthId}/{avatarId}/resolve", (string monthId, string avatarId, string? countryId, JsonObject request) =>
{
    if (stateProfileContent is null)
        return Results.Problem(stateProfileLoadError ?? "State profiles unavailable.", statusCode: StatusCodes.Status503ServiceUnavailable);
    if (!campaignMonths.TryGetValue(monthId, out var month))
        return Results.NotFound(new { error = "Campaign month is not available in this build.", monthId });
    try
    {
        var slice = campaignMonthService.GetAvatarSlice(month, avatarId);
        var resolvedCountry = countryId ?? slice["country_id"]?.GetValue<string>();
        var result = campaignMonthService.Resolve(month, avatarId, request);
        var initialState = request["player_state"] is JsonObject suppliedState
            ? suppliedState.DeepClone().AsObject()
            : stateProfileService.GetInitialState(stateProfileContent, avatarId, resolvedCountry);
        var indicators = result["resulting_indicators"]?.AsObject()
            ?? throw new InvalidDataException("Campaign resolution missing indicators.");
        var actions = result["applied_actions"]?.AsArray() ?? new JsonArray();
        var playerState = stateProfileService.AdvanceMonth(initialState, indicators, actions, monthId);
        result["player_state"] = playerState;
        result["finance"] = playerState["finance"]?.DeepClone();
        result["health"] = playerState["health"]?.DeepClone();
        result["inventory"] = playerState["inventory"]?.DeepClone();
        return Results.Ok(result);
    }
    catch (KeyNotFoundException) { return Results.NotFound(new { error = "Unknown campaign avatar.", monthId, avatarId }); }
    catch (InvalidDataException ex) { return Results.BadRequest(new { error = ex.Message }); }
});

app.MapPost("/api/v1/matches", async (CreateOnlineMatchRequest request, CancellationToken cancellationToken) =>
{
    if (matchCoordinator is null)
        return Results.Problem("Online match store is not configured.", statusCode: StatusCodes.Status503ServiceUnavailable);
    try
    {
        var result = await matchCoordinator.CreateAsync(request, cancellationToken);
        return Results.Created($"/api/v1/matches/{result.MatchId}", result);
    }
    catch (InvalidDataException ex) { return Results.BadRequest(new { error = ex.Message }); }
    catch (ArgumentException ex) { return Results.BadRequest(new { error = ex.Message }); }
});

app.MapGet("/api/v1/matches/{matchId:guid}", async (Guid matchId, CancellationToken cancellationToken) =>
{
    if (matchCoordinator is null)
        return Results.Problem("Online match store is not configured.", statusCode: StatusCodes.Status503ServiceUnavailable);
    var match = await matchCoordinator.GetAsync(matchId, cancellationToken);
    return match is null ? Results.NotFound(new { error = "Match not found.", matchId }) : Results.Ok(match);
});

app.MapGet("/api/v1/matches/{matchId:guid}/players/{playerId:guid}/state", async (Guid matchId, Guid playerId, CancellationToken cancellationToken) =>
{
    if (matchCoordinator is null)
        return Results.Problem("Online match store is not configured.", statusCode: StatusCodes.Status503ServiceUnavailable);
    try { return Results.Ok(await matchCoordinator.GetInitialPlayerStateAsync(matchId, playerId, cancellationToken)); }
    catch (KeyNotFoundException ex) { return Results.NotFound(new { error = ex.Message }); }
});

app.MapPost("/api/v1/matches/{matchId:guid}/join", async (Guid matchId, JoinOnlineMatchRequest request, CancellationToken cancellationToken) =>
{
    if (matchCoordinator is null)
        return Results.Problem("Online match store is not configured.", statusCode: StatusCodes.Status503ServiceUnavailable);
    try
    {
        var result = await matchCoordinator.JoinAsync(matchId, request, cancellationToken);
        return Results.Ok(new { playerId = result.PlayerId, match = result.Match });
    }
    catch (KeyNotFoundException ex) { return Results.NotFound(new { error = ex.Message }); }
    catch (InvalidDataException ex) { return Results.BadRequest(new { error = ex.Message }); }
    catch (ArgumentException ex) { return Results.BadRequest(new { error = ex.Message }); }
    catch (InvalidOperationException ex) { return Results.Conflict(new { error = ex.Message }); }
});

app.MapPost("/api/v1/matches/{matchId:guid}/start", async (Guid matchId, CancellationToken cancellationToken) =>
{
    if (matchCoordinator is null)
        return Results.Problem("Online match store is not configured.", statusCode: StatusCodes.Status503ServiceUnavailable);
    try { return Results.Ok(await matchCoordinator.StartAsync(matchId, cancellationToken)); }
    catch (KeyNotFoundException ex) { return Results.NotFound(new { error = ex.Message }); }
    catch (InvalidOperationException ex) { return Results.Conflict(new { error = ex.Message }); }
});

app.MapPost("/api/v1/matches/{matchId:guid}/turns/1/submit", async (Guid matchId, SubmitJanuaryTurnRequest request, CancellationToken cancellationToken) =>
{
    if (matchCoordinator is null)
        return Results.Problem("Online match store is not configured.", statusCode: StatusCodes.Status503ServiceUnavailable);
    try
    {
        var result = await matchCoordinator.SubmitJanuaryAsync(matchId, request, cancellationToken);
        return result.Resolved ? Results.Ok(result) : Results.Accepted($"/api/v1/matches/{matchId}", result);
    }
    catch (KeyNotFoundException ex) { return Results.NotFound(new { error = ex.Message }); }
    catch (InvalidDataException ex) { return Results.BadRequest(new { error = ex.Message }); }
    catch (InvalidOperationException ex) { return Results.Conflict(new { error = ex.Message }); }
});

app.Run();

static string ResolveEpochPath(string contentRoot)
{
    var configured = Environment.GetEnvironmentVariable("ROR_EPOCH_1933_PATH");
    if (!string.IsNullOrWhiteSpace(configured)) return Path.GetFullPath(configured);
    var candidates = new[]
    {
        Path.Combine(contentRoot, "content", "1933"),
        Path.GetFullPath(Path.Combine(contentRoot, "..", "..", "..", "data", "epochs", "1933")),
        Path.GetFullPath(Path.Combine(contentRoot, "..", "..", "..", "..", "data", "epochs", "1933"))
    };
    return candidates.FirstOrDefault(Directory.Exists) ?? candidates[0];
}
