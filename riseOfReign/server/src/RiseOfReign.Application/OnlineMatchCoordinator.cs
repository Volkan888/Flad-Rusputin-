using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Nodes;
using RiseOfReign.Domain;

namespace RiseOfReign.Application;

public sealed class OnlineMatchCoordinator
{
    private readonly IOnlineMatchStore _store;
    private readonly January1933Service _januaryService;
    private readonly JsonObject _januaryContent;

    public OnlineMatchCoordinator(IOnlineMatchStore store, January1933Service januaryService, JsonObject januaryContent)
    {
        _store = store;
        _januaryService = januaryService;
        _januaryContent = januaryContent;
    }

    public Task<OnlineMatchView?> GetAsync(Guid matchId, CancellationToken cancellationToken = default)
        => _store.GetAsync(matchId, cancellationToken);

    public async Task<CreateOnlineMatchResult> CreateAsync(CreateOnlineMatchRequest request, CancellationToken cancellationToken = default)
    {
        var slot = ResolveSlot(request.AvatarId, request.CountryId);
        return await _store.CreateAsync(
            request.DisplayName,
            request.AvatarId,
            slot.CountryId,
            slot.Authority,
            Random.Shared.NextInt64(),
            cancellationToken);
    }

    public async Task<(Guid PlayerId, OnlineMatchView Match)> JoinAsync(Guid matchId, JoinOnlineMatchRequest request, CancellationToken cancellationToken = default)
    {
        var slot = ResolveSlot(request.AvatarId, request.CountryId);
        var playerId = await _store.JoinAsync(
            matchId,
            request.DisplayName,
            request.AvatarId,
            slot.CountryId,
            slot.Authority,
            cancellationToken);
        var match = await _store.GetAsync(matchId, cancellationToken)
            ?? throw new KeyNotFoundException("Match disappeared after join.");
        return (playerId, match);
    }

    public Task<OnlineMatchView> StartAsync(Guid matchId, CancellationToken cancellationToken = default)
        => _store.StartAsync(matchId, cancellationToken);

    public async Task<SubmitTurnResult> SubmitJanuaryAsync(
        Guid matchId,
        SubmitJanuaryTurnRequest request,
        CancellationToken cancellationToken = default)
    {
        var match = await _store.GetAsync(matchId, cancellationToken)
            ?? throw new KeyNotFoundException("Match not found.");
        if (match.Status != "active" || match.TurnNumber != 1 || match.CurrentDate != new DateOnly(1933, 1, 1))
            throw new InvalidOperationException("Match is not accepting January 1933 commands.");

        var player = match.Players.SingleOrDefault(x => x.PlayerId == request.PlayerId)
            ?? throw new InvalidOperationException("Player is not part of this match.");

        var payload = new JsonObject
        {
            ["decision_choices"] = request.DecisionChoices.DeepClone(),
            ["phone_action"] = request.PhoneAction.DeepClone(),
            ["map_action"] = request.MapAction
        };

        _januaryService.Resolve(_januaryContent, player.AvatarId, payload);
        var ready = await _store.QueueJanuaryAsync(matchId, request.PlayerId, request.ClientCommandId, payload, cancellationToken);

        if (ready < 4)
        {
            return new SubmitTurnResult(matchId, request.PlayerId, 1, ready, false, match.CurrentDate, match.TurnNumber, null);
        }

        var ownsResolution = await _store.TryClaimJanuaryResolutionAsync(matchId, cancellationToken);
        if (!ownsResolution)
        {
            var latest = await _store.GetAsync(matchId, cancellationToken)
                ?? throw new KeyNotFoundException("Match not found after submit.");
            return new SubmitTurnResult(
                matchId,
                request.PlayerId,
                1,
                ready,
                latest.TurnNumber >= 2,
                latest.CurrentDate,
                latest.TurnNumber,
                null);
        }

        try
        {
            var commands = await _store.GetJanuaryCommandsAsync(matchId, cancellationToken);
            if (commands.Count != 4)
                throw new InvalidOperationException("Exactly four valid January commands are required for resolution.");

            var resolutions = new Dictionary<Guid, JsonObject>();
            foreach (var command in commands)
                resolutions[command.PlayerId] = _januaryService.Resolve(_januaryContent, command.AvatarId, command.Payload);

            var snapshot = BuildSnapshot(matchId, resolutions);
            var hash = Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(snapshot.ToJsonString()))).ToLowerInvariant();
            var finalized = await _store.FinalizeJanuaryAsync(matchId, resolutions, snapshot, hash, cancellationToken);
            resolutions.TryGetValue(request.PlayerId, out var ownResolution);

            return new SubmitTurnResult(
                matchId,
                request.PlayerId,
                1,
                4,
                true,
                finalized.CurrentDate,
                finalized.TurnNumber,
                ownResolution);
        }
        catch
        {
            await _store.ReleaseResolutionClaimAsync(matchId, cancellationToken);
            throw;
        }
    }

    private (string? CountryId, int Authority) ResolveSlot(string avatarId, string? requestedCountryId)
    {
        var slice = _januaryService.GetAvatarSlice(_januaryContent, avatarId);
        var fixedCountry = slice["country_id"]?.GetValue<string>();
        var authority = slice["starting_indicators"]?["authority"]?.GetValue<int>()
            ?? throw new InvalidDataException($"Avatar {avatarId} has no January authority seed.");

        if (!string.Equals(avatarId, "custom", StringComparison.OrdinalIgnoreCase))
        {
            if (!string.IsNullOrWhiteSpace(requestedCountryId) && !string.Equals(requestedCountryId, fixedCountry, StringComparison.OrdinalIgnoreCase))
                throw new InvalidDataException($"Avatar {avatarId} is bound to country {fixedCountry} in the 1933 start.");
            return (fixedCountry, authority);
        }

        if (string.IsNullOrWhiteSpace(requestedCountryId))
            throw new InvalidDataException("Custom avatar requires a country id for online match play.");
        return (requestedCountryId.Trim(), authority);
    }

    private static JsonObject BuildSnapshot(Guid matchId, IReadOnlyDictionary<Guid, JsonObject> resolutions)
    {
        var players = new JsonArray();
        foreach (var pair in resolutions.OrderBy(x => x.Key))
        {
            players.Add(new JsonObject
            {
                ["player_id"] = pair.Key.ToString(),
                ["resolution"] = pair.Value.DeepClone()
            });
        }

        return new JsonObject
        {
            ["schema_version"] = 1,
            ["match_id"] = matchId.ToString(),
            ["epoch_id"] = "1933",
            ["turn_number"] = 2,
            ["current_date"] = "1933-02-01",
            ["players"] = players
        };
    }
}
