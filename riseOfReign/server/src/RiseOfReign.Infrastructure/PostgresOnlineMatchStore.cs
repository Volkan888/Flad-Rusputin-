using System.Text.Json.Nodes;
using Npgsql;
using RiseOfReign.Domain;

namespace RiseOfReign.Infrastructure;

public sealed class PostgresOnlineMatchStore : IOnlineMatchStore
{
    private readonly NpgsqlDataSource _dataSource;

    public PostgresOnlineMatchStore(string connectionString)
    {
        if (string.IsNullOrWhiteSpace(connectionString))
            throw new ArgumentException("PostgreSQL connection string is required.", nameof(connectionString));
        _dataSource = NpgsqlDataSource.Create(connectionString);
    }

    public async Task<CreateOnlineMatchResult> CreateAsync(
        string displayName,
        string avatarId,
        string? countryId,
        int authority,
        long randomSeed,
        CancellationToken cancellationToken = default)
    {
        ValidatePlayer(displayName, avatarId, authority);
        await using var connection = await _dataSource.OpenConnectionAsync(cancellationToken);
        await using var tx = await connection.BeginTransactionAsync(cancellationToken);

        var playerId = Guid.NewGuid();
        var matchId = Guid.NewGuid();

        await ExecuteAsync(connection, tx,
            "INSERT INTO users(id, display_name) VALUES (@id, @name)",
            cancellationToken,
            ("id", playerId), ("name", displayName.Trim()));

        await ExecuteAsync(connection, tx,
            """
            INSERT INTO matches(id, epoch_id, status, current_date, turn_number, random_seed, content_version, ruleset_version)
            VALUES (@id, '1933', 'lobby', DATE '1933-01-01', 1, @seed, '1933.0.5', '0.1.0')
            """,
            cancellationToken,
            ("id", matchId), ("seed", randomSeed));

        await InsertPlayerAsync(connection, tx, matchId, playerId, avatarId, countryId, authority, cancellationToken);
        await tx.CommitAsync(cancellationToken);

        var match = await GetAsync(matchId, cancellationToken)
            ?? throw new InvalidOperationException("Created match could not be loaded.");
        return new CreateOnlineMatchResult(matchId, playerId, match);
    }

    public async Task<OnlineMatchView?> GetAsync(Guid matchId, CancellationToken cancellationToken = default)
    {
        await using var connection = await _dataSource.OpenConnectionAsync(cancellationToken);
        await using var matchCommand = new NpgsqlCommand(
            """
            SELECT epoch_id, status, current_date, turn_number, random_seed, content_version, ruleset_version
            FROM matches WHERE id=@id
            """, connection);
        matchCommand.Parameters.AddWithValue("id", matchId);
        await using var reader = await matchCommand.ExecuteReaderAsync(cancellationToken);
        if (!await reader.ReadAsync(cancellationToken))
            return null;

        var epochId = reader.GetString(0);
        var status = reader.GetString(1);
        var currentDate = reader.GetFieldValue<DateOnly>(2);
        var turnNumber = reader.GetInt32(3);
        var seed = reader.GetInt64(4);
        var contentVersion = reader.GetString(5);
        var rulesetVersion = reader.GetString(6);
        await reader.CloseAsync();

        await using var playerCommand = new NpgsqlCommand(
            """
            SELECT p.player_id, u.display_name, p.avatar_id, p.country_id, p.authority, p.is_ready, p.is_ai
            FROM match_players p
            JOIN users u ON u.id=p.player_id
            WHERE p.match_id=@id
            ORDER BY u.created_at, p.player_id
            """, connection);
        playerCommand.Parameters.AddWithValue("id", matchId);
        var players = new List<OnlineMatchPlayer>();
        await using var playerReader = await playerCommand.ExecuteReaderAsync(cancellationToken);
        while (await playerReader.ReadAsync(cancellationToken))
        {
            players.Add(new OnlineMatchPlayer(
                playerReader.GetGuid(0),
                playerReader.GetString(1),
                playerReader.GetString(2),
                playerReader.IsDBNull(3) ? null : playerReader.GetString(3),
                playerReader.GetInt32(4),
                playerReader.GetBoolean(5),
                playerReader.GetBoolean(6)));
        }

        return new OnlineMatchView(matchId, epochId, status, currentDate, turnNumber, seed, contentVersion, rulesetVersion, players);
    }

    public async Task<Guid> JoinAsync(
        Guid matchId,
        string displayName,
        string avatarId,
        string? countryId,
        int authority,
        CancellationToken cancellationToken = default)
    {
        ValidatePlayer(displayName, avatarId, authority);
        await using var connection = await _dataSource.OpenConnectionAsync(cancellationToken);
        await using var tx = await connection.BeginTransactionAsync(cancellationToken);

        await using (var lockCommand = new NpgsqlCommand("SELECT status FROM matches WHERE id=@id FOR UPDATE", connection, tx))
        {
            lockCommand.Parameters.AddWithValue("id", matchId);
            var status = await lockCommand.ExecuteScalarAsync(cancellationToken) as string
                ?? throw new KeyNotFoundException("Match not found.");
            if (!string.Equals(status, "lobby", StringComparison.Ordinal))
                throw new InvalidOperationException("Match is no longer accepting players.");
        }

        await using (var countCommand = new NpgsqlCommand("SELECT count(*) FROM match_players WHERE match_id=@id", connection, tx))
        {
            countCommand.Parameters.AddWithValue("id", matchId);
            var count = Convert.ToInt32(await countCommand.ExecuteScalarAsync(cancellationToken));
            if (count >= 4)
                throw new InvalidOperationException("The four-player lobby is full.");
        }

        await EnsureSlotAvailableAsync(connection, tx, matchId, avatarId, countryId, cancellationToken);

        var playerId = Guid.NewGuid();
        await ExecuteAsync(connection, tx,
            "INSERT INTO users(id, display_name) VALUES (@id, @name)",
            cancellationToken,
            ("id", playerId), ("name", displayName.Trim()));
        await InsertPlayerAsync(connection, tx, matchId, playerId, avatarId, countryId, authority, cancellationToken);
        await tx.CommitAsync(cancellationToken);
        return playerId;
    }

    public async Task<OnlineMatchView> StartAsync(Guid matchId, CancellationToken cancellationToken = default)
    {
        await using var connection = await _dataSource.OpenConnectionAsync(cancellationToken);
        await using var tx = await connection.BeginTransactionAsync(cancellationToken);
        await using (var lockCommand = new NpgsqlCommand("SELECT status FROM matches WHERE id=@id FOR UPDATE", connection, tx))
        {
            lockCommand.Parameters.AddWithValue("id", matchId);
            var status = await lockCommand.ExecuteScalarAsync(cancellationToken) as string
                ?? throw new KeyNotFoundException("Match not found.");
            if (!string.Equals(status, "lobby", StringComparison.Ordinal))
                throw new InvalidOperationException("Only a lobby can be started.");
        }

        await using (var countCommand = new NpgsqlCommand("SELECT count(*) FROM match_players WHERE match_id=@id", connection, tx))
        {
            countCommand.Parameters.AddWithValue("id", matchId);
            var count = Convert.ToInt32(await countCommand.ExecuteScalarAsync(cancellationToken));
            if (count != 4)
                throw new InvalidOperationException("riseOfReign requires exactly four players to start this match mode.");
        }

        await ExecuteAsync(connection, tx,
            "UPDATE matches SET status='active', updated_at=now() WHERE id=@id",
            cancellationToken, ("id", matchId));
        await tx.CommitAsync(cancellationToken);
        return await GetAsync(matchId, cancellationToken) ?? throw new KeyNotFoundException("Match not found after start.");
    }

    public async Task<int> QueueJanuaryAsync(
        Guid matchId,
        Guid playerId,
        Guid clientCommandId,
        JsonObject payload,
        CancellationToken cancellationToken = default)
    {
        await using var connection = await _dataSource.OpenConnectionAsync(cancellationToken);
        await using var tx = await connection.BeginTransactionAsync(cancellationToken);

        await using (var matchCommand = new NpgsqlCommand(
            "SELECT status, turn_number, current_date FROM matches WHERE id=@id FOR UPDATE", connection, tx))
        {
            matchCommand.Parameters.AddWithValue("id", matchId);
            await using var reader = await matchCommand.ExecuteReaderAsync(cancellationToken);
            if (!await reader.ReadAsync(cancellationToken))
                throw new KeyNotFoundException("Match not found.");
            var status = reader.GetString(0);
            var turn = reader.GetInt32(1);
            var date = reader.GetFieldValue<DateOnly>(2);
            if (status != "active" || turn != 1 || date != new DateOnly(1933, 1, 1))
                throw new InvalidOperationException("January turn is not accepting commands.");
        }

        await using (var playerCommand = new NpgsqlCommand(
            "SELECT EXISTS(SELECT 1 FROM match_players WHERE match_id=@match AND player_id=@player)", connection, tx))
        {
            playerCommand.Parameters.AddWithValue("match", matchId);
            playerCommand.Parameters.AddWithValue("player", playerId);
            if (!(bool)(await playerCommand.ExecuteScalarAsync(cancellationToken) ?? false))
                throw new InvalidOperationException("Player is not part of this match.");
        }

        await using (var command = new NpgsqlCommand(
            """
            INSERT INTO queued_commands(client_command_id, match_id, player_id, turn_number, command_type, payload)
            VALUES (@client, @match, @player, 1, 'january_1933', CAST(@payload AS jsonb))
            ON CONFLICT (match_id, player_id, turn_number)
            DO UPDATE SET client_command_id=EXCLUDED.client_command_id, command_type=EXCLUDED.command_type,
                          payload=EXCLUDED.payload, created_at=now()
            """, connection, tx))
        {
            command.Parameters.AddWithValue("client", clientCommandId);
            command.Parameters.AddWithValue("match", matchId);
            command.Parameters.AddWithValue("player", playerId);
            command.Parameters.AddWithValue("payload", payload.ToJsonString());
            await command.ExecuteNonQueryAsync(cancellationToken);
        }

        await ExecuteAsync(connection, tx,
            "UPDATE match_players SET is_ready=true, last_seen_at=now() WHERE match_id=@match AND player_id=@player",
            cancellationToken, ("match", matchId), ("player", playerId));

        await using var readyCommand = new NpgsqlCommand("SELECT count(*) FROM match_players WHERE match_id=@id AND is_ready", connection, tx);
        readyCommand.Parameters.AddWithValue("id", matchId);
        var ready = Convert.ToInt32(await readyCommand.ExecuteScalarAsync(cancellationToken));
        await tx.CommitAsync(cancellationToken);
        return ready;
    }

    public async Task<bool> TryClaimJanuaryResolutionAsync(Guid matchId, CancellationToken cancellationToken = default)
    {
        await using var connection = await _dataSource.OpenConnectionAsync(cancellationToken);
        await using var command = new NpgsqlCommand(
            """
            UPDATE matches m
            SET status='resolving', updated_at=now()
            WHERE m.id=@id AND m.status='active' AND m.turn_number=1
              AND (SELECT count(*) FROM match_players p WHERE p.match_id=m.id AND p.is_ready)=4
              AND (SELECT count(*) FROM queued_commands q WHERE q.match_id=m.id AND q.turn_number=1)=4
            RETURNING m.id
            """, connection);
        command.Parameters.AddWithValue("id", matchId);
        return await command.ExecuteScalarAsync(cancellationToken) is not null;
    }

    public async Task<IReadOnlyList<StoredTurnCommand>> GetJanuaryCommandsAsync(Guid matchId, CancellationToken cancellationToken = default)
    {
        await using var connection = await _dataSource.OpenConnectionAsync(cancellationToken);
        await using var command = new NpgsqlCommand(
            """
            SELECT q.player_id, p.avatar_id, p.country_id, q.payload::text
            FROM queued_commands q
            JOIN match_players p ON p.match_id=q.match_id AND p.player_id=q.player_id
            WHERE q.match_id=@id AND q.turn_number=1
            ORDER BY q.created_at, q.player_id
            """, connection);
        command.Parameters.AddWithValue("id", matchId);
        var result = new List<StoredTurnCommand>();
        await using var reader = await command.ExecuteReaderAsync(cancellationToken);
        while (await reader.ReadAsync(cancellationToken))
        {
            var payload = JsonNode.Parse(reader.GetString(3))?.AsObject()
                ?? throw new InvalidDataException("Stored January command is invalid JSON.");
            result.Add(new StoredTurnCommand(
                reader.GetGuid(0),
                reader.GetString(1),
                reader.IsDBNull(2) ? null : reader.GetString(2),
                payload));
        }
        return result;
    }

    public async Task<OnlineMatchView> FinalizeJanuaryAsync(
        Guid matchId,
        IReadOnlyDictionary<Guid, JsonObject> resolutions,
        JsonObject snapshot,
        string stateHash,
        CancellationToken cancellationToken = default)
    {
        await using var connection = await _dataSource.OpenConnectionAsync(cancellationToken);
        await using var tx = await connection.BeginTransactionAsync(cancellationToken);

        await using (var statusCommand = new NpgsqlCommand("SELECT status FROM matches WHERE id=@id FOR UPDATE", connection, tx))
        {
            statusCommand.Parameters.AddWithValue("id", matchId);
            var status = await statusCommand.ExecuteScalarAsync(cancellationToken) as string
                ?? throw new KeyNotFoundException("Match not found.");
            if (status != "resolving")
                throw new InvalidOperationException("Match does not own the January resolution claim.");
        }

        foreach (var pair in resolutions)
        {
            await using var playerCommand = new NpgsqlCommand(
                "SELECT country_id FROM match_players WHERE match_id=@match AND player_id=@player", connection, tx);
            playerCommand.Parameters.AddWithValue("match", matchId);
            playerCommand.Parameters.AddWithValue("player", pair.Key);
            var country = await playerCommand.ExecuteScalarAsync(cancellationToken);
            if (country is string countryId)
            {
                await using var stateCommand = new NpgsqlCommand(
                    """
                    INSERT INTO country_states(match_id, country_id, state)
                    VALUES (@match, @country, CAST(@state AS jsonb))
                    ON CONFLICT (match_id, country_id) DO UPDATE SET state=EXCLUDED.state
                    """, connection, tx);
                stateCommand.Parameters.AddWithValue("match", matchId);
                stateCommand.Parameters.AddWithValue("country", countryId);
                stateCommand.Parameters.AddWithValue("state", pair.Value.ToJsonString());
                await stateCommand.ExecuteNonQueryAsync(cancellationToken);
            }

            await using var eventCommand = new NpgsqlCommand(
                """
                INSERT INTO game_event_log(match_id, turn_number, game_date, event_type, actor_player_id, payload)
                VALUES (@match, 1, DATE '1933-01-31', 'january_1933_resolved', @player, CAST(@payload AS jsonb))
                """, connection, tx);
            eventCommand.Parameters.AddWithValue("match", matchId);
            eventCommand.Parameters.AddWithValue("player", pair.Key);
            eventCommand.Parameters.AddWithValue("payload", pair.Value.ToJsonString());
            await eventCommand.ExecuteNonQueryAsync(cancellationToken);
        }

        await ExecuteAsync(connection, tx, "DELETE FROM queued_commands WHERE match_id=@id AND turn_number=1", cancellationToken, ("id", matchId));
        await ExecuteAsync(connection, tx, "UPDATE match_players SET is_ready=false WHERE match_id=@id", cancellationToken, ("id", matchId));
        await ExecuteAsync(connection, tx,
            "UPDATE matches SET status='active', current_date=DATE '1933-02-01', turn_number=2, updated_at=now() WHERE id=@id",
            cancellationToken, ("id", matchId));

        await using (var snapshotCommand = new NpgsqlCommand(
            """
            INSERT INTO match_snapshots(match_id, turn_number, schema_version, state, state_hash)
            VALUES (@match, 2, 1, CAST(@state AS jsonb), @hash)
            ON CONFLICT (match_id, turn_number) DO UPDATE SET state=EXCLUDED.state, state_hash=EXCLUDED.state_hash, created_at=now()
            """, connection, tx))
        {
            snapshotCommand.Parameters.AddWithValue("match", matchId);
            snapshotCommand.Parameters.AddWithValue("state", snapshot.ToJsonString());
            snapshotCommand.Parameters.AddWithValue("hash", stateHash);
            await snapshotCommand.ExecuteNonQueryAsync(cancellationToken);
        }

        await tx.CommitAsync(cancellationToken);
        return await GetAsync(matchId, cancellationToken) ?? throw new KeyNotFoundException("Match not found after resolution.");
    }

    public async Task ReleaseResolutionClaimAsync(Guid matchId, CancellationToken cancellationToken = default)
    {
        await using var connection = await _dataSource.OpenConnectionAsync(cancellationToken);
        await using var command = new NpgsqlCommand(
            "UPDATE matches SET status='active', updated_at=now() WHERE id=@id AND status='resolving'", connection);
        command.Parameters.AddWithValue("id", matchId);
        await command.ExecuteNonQueryAsync(cancellationToken);
    }

    public ValueTask DisposeAsync() => _dataSource.DisposeAsync();

    private static async Task InsertPlayerAsync(
        NpgsqlConnection connection,
        NpgsqlTransaction tx,
        Guid matchId,
        Guid playerId,
        string avatarId,
        string? countryId,
        int authority,
        CancellationToken cancellationToken)
    {
        await using var command = new NpgsqlCommand(
            """
            INSERT INTO match_players(match_id, player_id, avatar_id, country_id, authority, is_ready, is_ai)
            VALUES (@match, @player, @avatar, @country, @authority, false, false)
            """, connection, tx);
        command.Parameters.AddWithValue("match", matchId);
        command.Parameters.AddWithValue("player", playerId);
        command.Parameters.AddWithValue("avatar", avatarId);
        command.Parameters.AddWithValue("country", (object?)countryId ?? DBNull.Value);
        command.Parameters.AddWithValue("authority", authority);
        await command.ExecuteNonQueryAsync(cancellationToken);
    }

    private static async Task EnsureSlotAvailableAsync(
        NpgsqlConnection connection,
        NpgsqlTransaction tx,
        Guid matchId,
        string avatarId,
        string? countryId,
        CancellationToken cancellationToken)
    {
        await using var command = new NpgsqlCommand(
            """
            SELECT EXISTS(SELECT 1 FROM match_players WHERE match_id=@match AND avatar_id=@avatar),
                   CASE WHEN @country IS NULL THEN false
                        ELSE EXISTS(SELECT 1 FROM match_players WHERE match_id=@match AND country_id=@country) END
            """, connection, tx);
        command.Parameters.AddWithValue("match", matchId);
        command.Parameters.AddWithValue("avatar", avatarId);
        command.Parameters.AddWithValue("country", (object?)countryId ?? DBNull.Value);
        await using var reader = await command.ExecuteReaderAsync(cancellationToken);
        await reader.ReadAsync(cancellationToken);
        if (reader.GetBoolean(0))
            throw new InvalidOperationException("Avatar slot is already occupied.");
        if (reader.GetBoolean(1))
            throw new InvalidOperationException("Country slot is already occupied.");
    }

    private static void ValidatePlayer(string displayName, string avatarId, int authority)
    {
        if (string.IsNullOrWhiteSpace(displayName)) throw new ArgumentException("Display name is required.");
        if (string.IsNullOrWhiteSpace(avatarId)) throw new ArgumentException("Avatar id is required.");
        if (authority is < 0 or > 100) throw new ArgumentOutOfRangeException(nameof(authority));
    }

    private static async Task ExecuteAsync(
        NpgsqlConnection connection,
        NpgsqlTransaction tx,
        string sql,
        CancellationToken cancellationToken,
        params (string Name, object Value)[] parameters)
    {
        await using var command = new NpgsqlCommand(sql, connection, tx);
        foreach (var parameter in parameters)
            command.Parameters.AddWithValue(parameter.Name, parameter.Value);
        await command.ExecuteNonQueryAsync(cancellationToken);
    }
}
