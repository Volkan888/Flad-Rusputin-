using RiseOfReign.Application;
using RiseOfReign.Domain;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<TurnEngine>();
builder.Services.AddSignalR();

var epochPath = ResolveEpochPath(builder.Environment.ContentRootPath);
var loader = new EpochContentLoader();
EpochMapContent? mapContent = null;
string? mapLoadError = null;

try
{
    mapContent = await loader.LoadMapAsync(epochPath);
}
catch (Exception ex)
{
    mapLoadError = ex.Message;
}

var app = builder.Build();

app.MapGet("/health", () => Results.Ok(new
{
    service = "riseOfReign-api",
    status = mapContent is null ? "degraded" : "ok",
    epoch = "1933",
    mapContentLoaded = mapContent is not null,
    mapLoadError,
    utc = DateTimeOffset.UtcNow
}));

app.MapGet("/api/v1/meta", () => Results.Ok(new
{
    game = "riseOfReign",
    ruleset = "0.1.0",
    content = "1933.0.2",
    turnUnit = "month",
    maxPlayers = 4
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
    if (!string.IsNullOrWhiteSpace(owner))
        query = query.Where(x => string.Equals(x.Owner1933, owner, StringComparison.OrdinalIgnoreCase));
    if (!string.IsNullOrWhiteSpace(resource))
        query = query.Where(x => string.Equals(x.Resource, resource, StringComparison.OrdinalIgnoreCase));

    return Results.Ok(query);
});

app.MapGet("/api/v1/map/connections", (string? owner, string? type) =>
{
    if (mapContent is null)
        return Results.Problem(mapLoadError ?? "Map content unavailable.", statusCode: StatusCodes.Status503ServiceUnavailable);

    IEnumerable<MapConnection> query = mapContent.Connections;
    if (!string.IsNullOrWhiteSpace(owner))
        query = query.Where(x => string.Equals(x.Owner1933, owner, StringComparison.OrdinalIgnoreCase));
    if (!string.IsNullOrWhiteSpace(type))
        query = query.Where(x => string.Equals(x.Type, type, StringComparison.OrdinalIgnoreCase));

    return Results.Ok(query);
});

app.MapGet("/api/v1/construction/catalog", (string? type) =>
{
    if (mapContent is null)
        return Results.Problem(mapLoadError ?? "Map content unavailable.", statusCode: StatusCodes.Status503ServiceUnavailable);

    IEnumerable<ConstructionTemplate> query = mapContent.ConstructionCatalog;
    if (!string.IsNullOrWhiteSpace(type))
        query = query.Where(x => string.Equals(x.Type, type, StringComparison.OrdinalIgnoreCase));

    return Results.Ok(query);
});

app.Run();

static string ResolveEpochPath(string contentRoot)
{
    var configured = Environment.GetEnvironmentVariable("ROR_EPOCH_1933_PATH");
    if (!string.IsNullOrWhiteSpace(configured))
        return Path.GetFullPath(configured);

    var candidates = new[]
    {
        Path.Combine(contentRoot, "content", "1933"),
        Path.GetFullPath(Path.Combine(contentRoot, "..", "..", "..", "data", "epochs", "1933")),
        Path.GetFullPath(Path.Combine(contentRoot, "..", "..", "..", "..", "data", "epochs", "1933"))
    };

    return candidates.FirstOrDefault(Directory.Exists) ?? candidates[0];
}
