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

CREATE OR REPLACE FUNCTION assign_historical_2v2_team()
RETURNS trigger
LANGUAGE plpgsql
AS $$
DECLARE
    v_mode text;
    v_team text;
    v_team_count integer;
BEGIN
    SELECT mode_id INTO v_mode FROM matches WHERE id = NEW.match_id;
    IF v_mode <> 'historical_2v2' THEN
        RETURN NEW;
    END IF;

    v_team := CASE
        WHEN NEW.avatar_id IN ('churchill', 'roosevelt') THEN 'blue'
        WHEN NEW.avatar_id IN ('hitler', 'mussolini') THEN 'red'
        ELSE NULL
    END;

    IF v_team IS NULL THEN
        RAISE EXCEPTION 'Avatar % is not a standard historical 2v2 player slot', NEW.avatar_id;
    END IF;

    SELECT count(*) INTO v_team_count
    FROM match_players
    WHERE match_id = NEW.match_id
      AND team_id = v_team
      AND (TG_OP = 'INSERT' OR player_id <> NEW.player_id);

    IF v_team_count >= 2 THEN
        RAISE EXCEPTION 'Team % already has two players', v_team;
    END IF;

    NEW.team_id := v_team;
    RETURN NEW;
END;
$$;

DROP TRIGGER IF EXISTS trg_assign_historical_2v2_team ON match_players;
CREATE TRIGGER trg_assign_historical_2v2_team
BEFORE INSERT OR UPDATE OF avatar_id ON match_players
FOR EACH ROW EXECUTE FUNCTION assign_historical_2v2_team();

CREATE OR REPLACE FUNCTION validate_historical_2v2_start()
RETURNS trigger
LANGUAGE plpgsql
AS $$
DECLARE
    blue_count integer;
    red_count integer;
BEGIN
    IF NEW.mode_id = 'historical_2v2'
       AND NEW.status = 'active'
       AND OLD.status IS DISTINCT FROM 'active' THEN
        SELECT count(*) FILTER (WHERE team_id = 'blue'),
               count(*) FILTER (WHERE team_id = 'red')
        INTO blue_count, red_count
        FROM match_players
        WHERE match_id = NEW.id;

        IF blue_count <> 2 OR red_count <> 2 THEN
            RAISE EXCEPTION 'Historical 2v2 requires exactly two blue and two red players';
        END IF;
    END IF;
    RETURN NEW;
END;
$$;

DROP TRIGGER IF EXISTS trg_validate_historical_2v2_start ON matches;
CREATE TRIGGER trg_validate_historical_2v2_start
BEFORE UPDATE OF status ON matches
FOR EACH ROW EXECUTE FUNCTION validate_historical_2v2_start();

UPDATE epochs
SET content_version = '1933.0.8', ruleset_version = '0.2.0'
WHERE id = '1933';
