using System.Text.Json;
using RiseOfReign.Domain;

namespace RiseOfReign.Application;

public sealed class EpochContentLoader
{
    private readonly JsonSerializerOptions _json = new(JsonSerializerDefaults.Web)
    {
        PropertyNameCaseInsensitive = true
    };

    public async Task<EpochMapContent> LoadMapAsync(string epochDirectory, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(epochDirectory))
            throw new ArgumentException("Epoch directory is required.", nameof(epochDirectory));

        var fullPath = Path.GetFullPath(epochDirectory);
        if (!Directory.Exists(fullPath))
            throw new DirectoryNotFoundException($"Epoch content directory not found: {fullPath}");

        var source = await ReadAsync<MapSourceDefinition>(Path.Combine(fullPath, "map_source.json"), cancellationToken);
        var nodes = await ReadAsync<List<ResourceNode>>(Path.Combine(fullPath, "map_resource_nodes.json"), cancellationToken);
        var connections = await ReadAsync<List<MapConnection>>(Path.Combine(fullPath, "map_connections.json"), cancellationToken);
        var construction = await ReadAsync<List<ConstructionTemplate>>(Path.Combine(fullPath, "construction_catalog.json"), cancellationToken);

        Validate(source, nodes, connections, construction);
        return new EpochMapContent(source, nodes, connections, construction);
    }

    private async Task<T> ReadAsync<T>(string path, CancellationToken cancellationToken)
    {
        if (!File.Exists(path))
            throw new FileNotFoundException("Required epoch content file is missing.", path);

        await using var stream = File.OpenRead(path);
        var value = await JsonSerializer.DeserializeAsync<T>(stream, _json, cancellationToken);
        return value ?? throw new InvalidDataException($"Could not deserialize {path}.");
    }

    private static void Validate(
        MapSourceDefinition source,
        IReadOnlyList<ResourceNode> nodes,
        IReadOnlyList<MapConnection> connections,
        IReadOnlyList<ConstructionTemplate> construction)
    {
        var errors = new List<string>();

        if (source.CanonicalSource.Year != 1933)
            errors.Add("Canonical map year must be 1933 for the 1933 epoch.");

        if (source.CanonicalSource.StoreOriginalInGit)
            errors.Add("The canonical online map must not be stored as the original map asset in Git.");

        ValidateUniqueIds(nodes.Select(x => x.Id), "resource node", errors);
        ValidateUniqueIds(connections.Select(x => x.Id), "map connection", errors);
        ValidateUniqueIds(construction.Select(x => x.Id), "construction template", errors);

        foreach (var node in nodes)
        {
            if (node.Latitude is < -90 or > 90)
                errors.Add($"Resource node {node.Id}: latitude out of range.");
            if (node.Longitude is < -180 or > 180)
                errors.Add($"Resource node {node.Id}: longitude out of range.");
            if (node.YieldRp < 0)
                errors.Add($"Resource node {node.Id}: yield cannot be negative.");
            if (node.Development is < 0 or > 3)
                errors.Add($"Resource node {node.Id}: development must be 0..3.");
        }

        foreach (var connection in connections)
        {
            ValidatePoint(connection.Id, "from", connection.From, errors);
            ValidatePoint(connection.Id, "to", connection.To, errors);
            if (connection.Level is < 1 or > 3)
                errors.Add($"Connection {connection.Id}: level must be 1..3.");
            if (connection.Capacity < 0)
                errors.Add($"Connection {connection.Id}: capacity cannot be negative.");
            if (connection.Condition is < 0 or > 100)
                errors.Add($"Connection {connection.Id}: condition must be 0..100.");
        }

        foreach (var template in construction)
        {
            if (template.Level is < 1 or > 3)
                errors.Add($"Construction {template.Id}: level must be 1..3.");
            if (template.BaseMonths <= 0)
                errors.Add($"Construction {template.Id}: base_months must be positive.");
            foreach (var material in template.Materials)
            {
                if (material.Value < 0)
                    errors.Add($"Construction {template.Id}: material {material.Key} cannot be negative.");
            }
        }

        if (errors.Count > 0)
            throw new InvalidDataException("Invalid 1933 map content:\n - " + string.Join("\n - ", errors));
    }

    private static void ValidateUniqueIds(IEnumerable<string> ids, string label, ICollection<string> errors)
    {
        foreach (var duplicate in ids.GroupBy(x => x, StringComparer.OrdinalIgnoreCase).Where(g => g.Count() > 1))
            errors.Add($"Duplicate {label} id: {duplicate.Key}");
    }

    private static void ValidatePoint(string connectionId, string endpoint, GeoPoint point, ICollection<string> errors)
    {
        if (point.Latitude is < -90 or > 90)
            errors.Add($"Connection {connectionId} {endpoint}: latitude out of range.");
        if (point.Longitude is < -180 or > 180)
            errors.Add($"Connection {connectionId} {endpoint}: longitude out of range.");
    }
}
