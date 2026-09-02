using System.Text.Json.Serialization;

namespace RiseOfReign.Domain;

public sealed record GeoPoint
{
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("lat")]
    public double Latitude { get; init; }

    [JsonPropertyName("lon")]
    public double Longitude { get; init; }
}

public sealed record ResourceNode
{
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("owner_1933")]
    public required string Owner1933 { get; init; }

    [JsonPropertyName("playable_claim")]
    public string? PlayableClaim { get; init; }

    [JsonPropertyName("region_id")]
    public string? RegionId { get; init; }

    [JsonPropertyName("lat")]
    public double Latitude { get; init; }

    [JsonPropertyName("lon")]
    public double Longitude { get; init; }

    [JsonPropertyName("resource")]
    public required string Resource { get; init; }

    [JsonPropertyName("subtype")]
    public string? Subtype { get; init; }

    [JsonPropertyName("yield_rp")]
    public decimal YieldRp { get; init; }

    [JsonPropertyName("reserve_class")]
    public required string ReserveClass { get; init; }

    [JsonPropertyName("development")]
    public int Development { get; init; }

    [JsonPropertyName("transport")]
    public IReadOnlyList<string> Transport { get; init; } = [];

    [JsonPropertyName("historical_basis")]
    public string? HistoricalBasis { get; init; }

    [JsonPropertyName("verification_status")]
    public string? VerificationStatus { get; init; }
}

public sealed record MapConnection
{
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("owner_1933")]
    public required string Owner1933 { get; init; }

    [JsonPropertyName("type")]
    public required string Type { get; init; }

    [JsonPropertyName("level")]
    public int Level { get; init; }

    [JsonPropertyName("from")]
    public required GeoPoint From { get; init; }

    [JsonPropertyName("to")]
    public required GeoPoint To { get; init; }

    [JsonPropertyName("capacity")]
    public decimal Capacity { get; init; }

    [JsonPropertyName("condition")]
    public decimal Condition { get; init; }

    [JsonPropertyName("terrain")]
    public required string Terrain { get; init; }

    [JsonPropertyName("strategic_tags")]
    public IReadOnlyList<string> StrategicTags { get; init; } = [];

    [JsonPropertyName("note")]
    public string? Note { get; init; }
}

public sealed record ConstructionTemplate
{
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("type")]
    public required string Type { get; init; }

    [JsonPropertyName("resource")]
    public string? Resource { get; init; }

    [JsonPropertyName("level")]
    public int Level { get; init; }

    [JsonPropertyName("materials")]
    public IReadOnlyDictionary<string, decimal> Materials { get; init; } = new Dictionary<string, decimal>();

    [JsonPropertyName("base_months")]
    public int BaseMonths { get; init; }

    [JsonPropertyName("capacity_gain")]
    public decimal CapacityGain { get; init; }
}

public sealed record CanonicalMapSource
{
    [JsonPropertyName("provider")]
    public required string Provider { get; init; }

    [JsonPropertyName("title")]
    public required string Title { get; init; }

    [JsonPropertyName("year")]
    public int Year { get; init; }

    [JsonPropertyName("format")]
    public required string Format { get; init; }

    [JsonPropertyName("page_url")]
    public required string PageUrl { get; init; }

    [JsonPropertyName("data_url")]
    public required string DataUrl { get; init; }

    [JsonPropertyName("license")]
    public required string License { get; init; }

    [JsonPropertyName("store_original_in_git")]
    public bool StoreOriginalInGit { get; init; }
}

public sealed record MapRuntimePolicy
{
    [JsonPropertyName("load_online")]
    public bool LoadOnline { get; init; }

    [JsonPropertyName("allow_server_cache")]
    public bool AllowServerCache { get; init; }

    [JsonPropertyName("cache_metadata")]
    public IReadOnlyList<string> CacheMetadata { get; init; } = [];

    [JsonPropertyName("offline_match_policy")]
    public required string OfflineMatchPolicy { get; init; }
}

public sealed record MapSourceDefinition
{
    [JsonPropertyName("map_id")]
    public required string MapId { get; init; }

    [JsonPropertyName("canonical_source")]
    public required CanonicalMapSource CanonicalSource { get; init; }

    [JsonPropertyName("runtime_policy")]
    public required MapRuntimePolicy RuntimePolicy { get; init; }

    [JsonPropertyName("overlays")]
    public IReadOnlyList<string> Overlays { get; init; } = [];

    [JsonPropertyName("attribution_required")]
    public bool AttributionRequired { get; init; }
}

public sealed record EpochMapContent(
    MapSourceDefinition Source,
    IReadOnlyList<ResourceNode> ResourceNodes,
    IReadOnlyList<MapConnection> Connections,
    IReadOnlyList<ConstructionTemplate> ConstructionCatalog);
