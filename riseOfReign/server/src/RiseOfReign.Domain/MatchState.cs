namespace RiseOfReign.Domain;

public sealed class MatchState
{
    public required Guid Id { get; init; }
    public required string EpochId { get; init; }
    public DateOnly CurrentDate { get; set; } = new(1933, 1, 1);
    public int TurnNumber { get; set; } = 1;
    public string RulesetVersion { get; set; } = "0.1.0";
    public string ContentVersion { get; set; } = "1933.0.1";
    public long RandomSeed { get; init; }
    public List<MatchPlayerState> Players { get; } = [];
}

public sealed class MatchPlayerState
{
    public required Guid PlayerId { get; init; }
    public required string AvatarId { get; init; }
    public required string CountryId { get; init; }
    public int Authority { get; set; }
    public bool IsReady { get; set; }
    public bool IsAi { get; init; }
}
