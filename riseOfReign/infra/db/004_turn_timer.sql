ALTER TABLE matches
    ADD COLUMN IF NOT EXISTS timer_preset text NOT NULL DEFAULT 'turn_5m';

ALTER TABLE matches
    DROP CONSTRAINT IF EXISTS ck_matches_timer_preset;

UPDATE matches
SET timer_preset = CASE timer_preset
    WHEN 'live_quick' THEN 'turn_5m'
    WHEN 'live_standard' THEN 'turn_5m'
    WHEN 'live_extended' THEN 'turn_10m'
    WHEN 'async_12h' THEN 'turn_24h'
    WHEN 'async_24h' THEN 'turn_24h'
    WHEN 'async_48h' THEN 'turn_24h'
    ELSE timer_preset
END;

ALTER TABLE matches
    ADD CONSTRAINT ck_matches_timer_preset
    CHECK (timer_preset IN ('turn_2m','turn_5m','turn_10m','turn_1h','turn_24h'));

ALTER TABLE match_players
    ADD COLUMN IF NOT EXISTS timeout_count integer NOT NULL DEFAULT 0;

ALTER TABLE match_players
    ADD COLUMN IF NOT EXISTS last_timeout_at timestamptz NULL;

ALTER TABLE match_players
    DROP CONSTRAINT IF EXISTS ck_match_players_timeout_count;

ALTER TABLE match_players
    ADD CONSTRAINT ck_match_players_timeout_count CHECK (timeout_count >= 0);

CREATE INDEX IF NOT EXISTS idx_matches_turn_deadline
    ON matches(status, turn_deadline)
    WHERE status = 'active' AND turn_deadline IS NOT NULL;
