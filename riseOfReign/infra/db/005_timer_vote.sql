CREATE TABLE IF NOT EXISTS timer_change_votes (
    id uuid PRIMARY KEY DEFAULT gen_random_uuid(),
    match_id uuid NOT NULL REFERENCES matches(id) ON DELETE CASCADE,
    proposed_by uuid NOT NULL,
    current_preset text NOT NULL,
    proposed_preset text NOT NULL,
    created_turn integer NOT NULL,
    status text NOT NULL DEFAULT 'open',
    yes_votes integer NOT NULL DEFAULT 0,
    no_votes integer NOT NULL DEFAULT 0,
    resolved_at timestamptz NULL,
    applies_turn integer NULL,
    created_at timestamptz NOT NULL DEFAULT now(),
    CHECK (current_preset IN ('turn_2m','turn_5m','turn_10m','turn_1h','turn_24h')),
    CHECK (proposed_preset IN ('turn_2m','turn_5m','turn_10m','turn_1h','turn_24h')),
    CHECK (status IN ('open','approved','rejected','expired')),
    CHECK (yes_votes BETWEEN 0 AND 4),
    CHECK (no_votes BETWEEN 0 AND 4)
);

CREATE UNIQUE INDEX IF NOT EXISTS uq_timer_vote_open_match
    ON timer_change_votes(match_id)
    WHERE status = 'open';

CREATE TABLE IF NOT EXISTS timer_change_ballots (
    vote_id uuid NOT NULL REFERENCES timer_change_votes(id) ON DELETE CASCADE,
    player_id uuid NOT NULL,
    choice text NOT NULL,
    updated_at timestamptz NOT NULL DEFAULT now(),
    PRIMARY KEY (vote_id, player_id),
    CHECK (choice IN ('yes','no'))
);

CREATE OR REPLACE FUNCTION refresh_timer_vote_counts()
RETURNS trigger
LANGUAGE plpgsql
AS $$
DECLARE
    v_vote_id uuid;
    v_match_id uuid;
    v_created_turn integer;
    v_yes integer;
    v_no integer;
    v_player_count integer;
BEGIN
    v_vote_id := COALESCE(NEW.vote_id, OLD.vote_id);

    SELECT match_id, created_turn INTO v_match_id, v_created_turn
    FROM timer_change_votes
    WHERE id = v_vote_id
    FOR UPDATE;

    IF v_match_id IS NULL THEN
        RETURN COALESCE(NEW, OLD);
    END IF;

    IF NOT EXISTS (
        SELECT 1 FROM match_players
        WHERE match_id = v_match_id
          AND player_id = COALESCE(NEW.player_id, OLD.player_id)
    ) THEN
        RAISE EXCEPTION 'Only players in this match may vote on timer changes';
    END IF;

    SELECT count(*) FILTER (WHERE choice='yes'),
           count(*) FILTER (WHERE choice='no')
    INTO v_yes, v_no
    FROM timer_change_ballots
    WHERE vote_id = v_vote_id;

    SELECT count(*) INTO v_player_count
    FROM match_players
    WHERE match_id = v_match_id;

    UPDATE timer_change_votes
    SET yes_votes = v_yes,
        no_votes = v_no,
        status = CASE
            WHEN v_yes >= 3 THEN 'approved'
            WHEN v_no >= 2 THEN 'rejected'
            WHEN v_yes + v_no >= LEAST(v_player_count, 4) THEN 'rejected'
            ELSE 'open'
        END,
        applies_turn = CASE WHEN v_yes >= 3 THEN v_created_turn + 1 ELSE applies_turn END,
        resolved_at = CASE WHEN v_yes >= 3 OR v_no >= 2 OR v_yes + v_no >= LEAST(v_player_count, 4) THEN now() ELSE NULL END
    WHERE id = v_vote_id;

    RETURN COALESCE(NEW, OLD);
END;
$$;

DROP TRIGGER IF EXISTS trg_refresh_timer_vote_counts ON timer_change_ballots;
CREATE TRIGGER trg_refresh_timer_vote_counts
AFTER INSERT OR UPDATE OR DELETE ON timer_change_ballots
FOR EACH ROW EXECUTE FUNCTION refresh_timer_vote_counts();

CREATE OR REPLACE FUNCTION apply_approved_timer_vote()
RETURNS trigger
LANGUAGE plpgsql
AS $$
BEGIN
    IF NEW.status = 'approved' AND OLD.status IS DISTINCT FROM 'approved' THEN
        -- The preset is stored now but must only be used when the next turn deadline is created.
        UPDATE matches
        SET timer_preset = NEW.proposed_preset,
            updated_at = now()
        WHERE id = NEW.match_id;
    END IF;
    RETURN NEW;
END;
$$;

DROP TRIGGER IF EXISTS trg_apply_approved_timer_vote ON timer_change_votes;
CREATE TRIGGER trg_apply_approved_timer_vote
AFTER UPDATE OF status ON timer_change_votes
FOR EACH ROW EXECUTE FUNCTION apply_approved_timer_vote();
