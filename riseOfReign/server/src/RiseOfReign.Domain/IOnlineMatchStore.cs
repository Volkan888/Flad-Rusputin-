using System.Text.Json.Nodes;

namespace RiseOfReign.Domain;

public interface IOnlineMatchStore : IAsyncDisposable
{
    Task<CreateOnlineMatchResult> CreateAsync(string displayName, string avatarId, string? countryId, int authority, long randomSeed, CancellationToken cancellationToken = default);
    Task<OnlineMatchView?> GetAsync(Guid matchId, CancellationToken cancellationToken = default);
    Task<Guid> JoinAsync(Guid matchId, string displayName, string avatarId, string? countryId, int authority, CancellationToken cancellationToken = default);
    Task<OnlineMatchView> StartAsync(Guid matchId, CancellationToken cancellationToken = default);
    Task<int> QueueJanuaryAsync(Guid matchId, Guid playerId, Guid clientCommandId, JsonObject payload, CancellationToken cancellationToken = default);
    Task<bool> TryClaimJanuaryResolutionAsync(Guid matchId, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<StoredTurnCommand>> GetJanuaryCommandsAsync(Guid matchId, CancellationToken cancellationToken = default);
    Task<OnlineMatchView> FinalizeJanuaryAsync(Guid matchId, IReadOnlyDictionary<Guid, JsonObject> resolutions, JsonObject snapshot, string stateHash, CancellationToken cancellationToken = default);
    Task ReleaseResolutionClaimAsync(Guid matchId, CancellationToken cancellationToken = default);
}
