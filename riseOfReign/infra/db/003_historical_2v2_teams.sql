ALTER TABLE matches
    ADD COLUMN IF NOT EXISTS mode_id text NOT NULL DEFAULT 'historical_2v2';

ALTER TABLE match_players
    ADD COLUMN IF NOT EXISTS team_id text NULL;

ALTER TABLE match_players
    DROP CONSTRAINT IF EXISTS ck_match_players_team_id;

ALTER TABLE match_players
    ADD CONSTRAINT ck_match_players_team_id
    CHECK (team_id IS NULL OR team_id IN ('blue', 'red'));

UPDATE match_players
SET team_id = CASE
    WHEN avatar_id IN ('churchill', 'roosevelt') THEN 'blue'
    WHEN avatar_id IN ('hitler', 'mussolini') THEN 'red'
    ELSE NULL
END
WHERE team_id IS NULL;

CREATE INDEX IF NOT EXISTS idx_match_players_match_team
    ON match_players(match_id, team_id);

UPDATE epochs
SET content_version = '1933.0.8', ruleset_version = '0.2.0'
WHERE id = '1933';
