namespace RiseOfReign.Domain;

public abstract record TurnCommand(
    Guid MatchId,
    Guid PlayerId,
    int TurnNumber,
    Guid ClientCommandId);

public sealed record EndTurnCommand(
    Guid MatchId,
    Guid PlayerId,
    int TurnNumber,
    Guid ClientCommandId)
    : TurnCommand(MatchId, PlayerId, TurnNumber, ClientCommandId);

public sealed record AllocateBudgetCommand(
    Guid MatchId,
    Guid PlayerId,
    int TurnNumber,
    Guid ClientCommandId,
    IReadOnlyDictionary<string, decimal> Allocations)
    : TurnCommand(MatchId, PlayerId, TurnNumber, ClientCommandId);
