using System.Text.Json.Nodes;

namespace RiseOfReign.Domain;

public sealed record CreateOnlineMatchRequest(
    string DisplayName,
    string AvatarId,
    string? CountryId);

public sealed record JoinOnlineMatchRequest(
    string DisplayName,
    string AvatarId,
    string? CountryId);

public sealed record SubmitJanuaryTurnRequest(
    Guid PlayerId,
    Guid ClientCommandId,
    JsonObject DecisionChoices,
    JsonObject PhoneAction,
    string MapAction);

public sealed record OnlineMatchPlayer(
    Guid PlayerId,
    string DisplayName,
    string AvatarId,
    string? CountryId,
    int Authority,
    bool IsReady,
    bool IsAi);

public sealed record OnlineMatchView(
    Guid MatchId,
    string EpochId,
    string Status,
    DateOnly CurrentDate,
    int TurnNumber,
    long RandomSeed,
    string ContentVersion,
    string RulesetVersion,
    IReadOnlyList<OnlineMatchPlayer> Players);

public sealed record CreateOnlineMatchResult(
    Guid MatchId,
    Guid PlayerId,
    OnlineMatchView Match);

public sealed record SubmitTurnResult(
    Guid MatchId,
    Guid PlayerId,
    int TurnNumber,
    int ReadyPlayers,
    bool Resolved,
    DateOnly CurrentDate,
    int CurrentTurn,
    JsonObject? Resolution);

public sealed record StoredTurnCommand(
    Guid PlayerId,
    string AvatarId,
    string? CountryId,
    JsonObject Payload);
