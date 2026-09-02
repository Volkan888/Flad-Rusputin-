using RiseOfReign.Domain;

namespace RiseOfReign.Application;

public sealed class TurnEngine
{
    public TurnResolution Resolve(MatchState state, IReadOnlyCollection<TurnCommand> commands)
    {
        ArgumentNullException.ThrowIfNull(state);
        ArgumentNullException.ThrowIfNull(commands);

        foreach (var command in commands)
        {
            if (command.MatchId != state.Id)
                throw new InvalidOperationException("Command belongs to another match.");
            if (command.TurnNumber != state.TurnNumber)
                throw new InvalidOperationException("Command belongs to another turn.");
            if (state.Players.All(p => p.PlayerId != command.PlayerId))
                throw new InvalidOperationException("Unknown player.");
        }

        var resolvedTurn = state.TurnNumber;
        var resolvedDate = state.CurrentDate;

        state.CurrentDate = state.CurrentDate.AddMonths(1);
        state.TurnNumber++;
        foreach (var player in state.Players)
            player.IsReady = false;

        return new TurnResolution(resolvedTurn, resolvedDate, state.TurnNumber, state.CurrentDate, commands.Count);
    }
}

public sealed record TurnResolution(
    int ResolvedTurn,
    DateOnly ResolvedDate,
    int NextTurn,
    DateOnly NextDate,
    int CommandCount);
