UPDATE epochs
SET content_version = '1933.0.5', ruleset_version = '0.1.0'
WHERE id = '1933';

CREATE UNIQUE INDEX IF NOT EXISTS uq_match_players_avatar
    ON match_players(match_id, avatar_id);

CREATE UNIQUE INDEX IF NOT EXISTS uq_match_players_country
    ON match_players(match_id, country_id)
    WHERE country_id IS NOT NULL;

CREATE UNIQUE INDEX IF NOT EXISTS uq_queued_commands_player_turn
    ON queued_commands(match_id, player_id, turn_number);

CREATE INDEX IF NOT EXISTS idx_match_players_ready
    ON match_players(match_id, is_ready);

CREATE INDEX IF NOT EXISTS idx_queued_commands_match_turn
    ON queued_commands(match_id, turn_number);
