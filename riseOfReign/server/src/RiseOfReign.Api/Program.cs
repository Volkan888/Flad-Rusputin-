using RiseOfReign.Application;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<TurnEngine>();
builder.Services.AddSignalR();

var app = builder.Build();

app.MapGet("/health", () => Results.Ok(new
{
    service = "riseOfReign-api",
    status = "ok",
    epoch = "1933",
    utc = DateTimeOffset.UtcNow
}));

app.MapGet("/api/v1/meta", () => Results.Ok(new
{
    game = "riseOfReign",
    ruleset = "0.1.0",
    content = "1933.0.1",
    turnUnit = "month",
    maxPlayers = 4
}));

app.Run();
