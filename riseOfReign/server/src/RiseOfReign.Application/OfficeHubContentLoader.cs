using System.Text.Json.Nodes;

namespace RiseOfReign.Application;

public sealed class OfficeHubContentLoader
{
    public async Task<JsonNode> LoadAsync(string epochDirectory, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(epochDirectory))
            throw new ArgumentException("Epoch directory is required.", nameof(epochDirectory));

        var path = Path.Combine(Path.GetFullPath(epochDirectory), "office_hubs.json");
        if (!File.Exists(path))
            throw new FileNotFoundException("Office hub content file is missing.", path);

        var json = await File.ReadAllTextAsync(path, cancellationToken);
        var root = JsonNode.Parse(json) ?? throw new InvalidDataException("Could not parse office_hubs.json.");

        var sharedObjects = root["shared_objects"]?.AsArray()
            ?? throw new InvalidDataException("office_hubs.json: shared_objects is required.");
        var officeLevels = root["office_levels"]?.AsArray()
            ?? throw new InvalidDataException("office_hubs.json: office_levels is required.");
        var rooms = root["rooms"]?.AsArray()
            ?? throw new InvalidDataException("office_hubs.json: rooms is required.");
        var avatarOffices = root["avatar_offices"]?.AsObject()
            ?? throw new InvalidDataException("office_hubs.json: avatar_offices is required.");

        if (sharedObjects.Count == 0)
            throw new InvalidDataException("office_hubs.json must define at least one shared object.");
        if (officeLevels.Count < 2)
            throw new InvalidDataException("office_hubs.json must define office progression levels.");
        if (rooms.Count == 0)
            throw new InvalidDataException("office_hubs.json must define at least one room.");

        var requiredAvatars = new[] { "ataturk", "hitler", "stalin", "churchill", "roosevelt", "mussolini", "custom" };
        foreach (var avatarId in requiredAvatars)
        {
            if (!avatarOffices.ContainsKey(avatarId))
                throw new InvalidDataException($"office_hubs.json is missing avatar office: {avatarId}");
        }

        return root;
    }
}
