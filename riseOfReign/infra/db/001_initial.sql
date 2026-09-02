CREATE EXTENSION IF NOT EXISTS pgcrypto;

CREATE TABLE IF NOT EXISTS users (
    id uuid PRIMARY KEY DEFAULT gen_random_uuid(),
    display_name text NOT NULL,
    created_at timestamptz NOT NULL DEFAULT now()
);

CREATE TABLE IF NOT EXISTS epochs (
    id text PRIMARY KEY,
    name text NOT NULL,
    start_date date NOT NULL,
    content_version text NOT NULL,
    ruleset_version text NOT NULL
);

INSERT INTO epochs (id, name, start_date, content_version, ruleset_version)
VALUES ('1933', 'The World in Crisis', DATE '1933-01-01', '1933.0.1', '0.1.0')
ON CONFLICT (id) DO NOTHING;

CREATE TABLE IF NOT EXISTS matches (
    id uuid PRIMARY KEY DEFAULT gen_random_uuid(),
    epoch_id text NOT NULL REFERENCES epochs(id),
    status text NOT NULL DEFAULT 'lobby',
    current_date date NOT NULL,
    turn_number integer NOT NULL DEFAULT 1,
    turn_deadline timestamptz NULL,
    random_seed bigint NOT NULL,
    content_version text NOT NULL,
    ruleset_version text NOT NULL,
    created_at timestamptz NOT NULL DEFAULT now(),
    updated_at timestamptz NOT NULL DEFAULT now()
);

CREATE TABLE IF NOT EXISTS match_players (
    match_id uuid NOT NULL REFERENCES matches(id) ON DELETE CASCADE,
    player_id uuid NOT NULL REFERENCES users(id),
    avatar_id text NOT NULL,
    country_id text NULL,
    authority integer NOT NULL CHECK (authority BETWEEN 0 AND 100),
    is_ready boolean NOT NULL DEFAULT false,
    is_ai boolean NOT NULL DEFAULT false,
    last_seen_at timestamptz NULL,
    PRIMARY KEY (match_id, player_id)
);

CREATE TABLE IF NOT EXISTS country_states (
    match_id uuid NOT NULL REFERENCES matches(id) ON DELETE CASCADE,
    country_id text NOT NULL,
    state jsonb NOT NULL DEFAULT '{}'::jsonb,
    PRIMARY KEY (match_id, country_id)
);

CREATE TABLE IF NOT EXISTS region_states (
    match_id uuid NOT NULL REFERENCES matches(id) ON DELETE CASCADE,
    region_id text NOT NULL,
    state jsonb NOT NULL DEFAULT '{}'::jsonb,
    PRIMARY KEY (match_id, region_id)
);

CREATE TABLE IF NOT EXISTS resource_stocks (
    match_id uuid NOT NULL REFERENCES matches(id) ON DELETE CASCADE,
    owner_type text NOT NULL,
    owner_id text NOT NULL,
    resource_type text NOT NULL,
    amount numeric(18,4) NOT NULL DEFAULT 0,
    reserve_target numeric(18,4) NOT NULL DEFAULT 0,
    storage_capacity numeric(18,4) NOT NULL DEFAULT 0,
    PRIMARY KEY (match_id, owner_type, owner_id, resource_type)
);

CREATE TABLE IF NOT EXISTS queued_commands (
    id uuid PRIMARY KEY DEFAULT gen_random_uuid(),
    client_command_id uuid NOT NULL,
    match_id uuid NOT NULL REFERENCES matches(id) ON DELETE CASCADE,
    player_id uuid NOT NULL,
    turn_number integer NOT NULL,
    command_type text NOT NULL,
    payload jsonb NOT NULL DEFAULT '{}'::jsonb,
    created_at timestamptz NOT NULL DEFAULT now(),
    UNIQUE (match_id, client_command_id)
);

CREATE TABLE IF NOT EXISTS game_event_log (
    id bigserial PRIMARY KEY,
    match_id uuid NOT NULL REFERENCES matches(id) ON DELETE CASCADE,
    turn_number integer NOT NULL,
    game_date date NOT NULL,
    event_type text NOT NULL,
    actor_player_id uuid NULL,
    target_id text NULL,
    payload jsonb NOT NULL DEFAULT '{}'::jsonb,
    created_at timestamptz NOT NULL DEFAULT now()
);

CREATE INDEX IF NOT EXISTS idx_game_event_log_match_turn
    ON game_event_log(match_id, turn_number, id);

CREATE TABLE IF NOT EXISTS match_snapshots (
    id bigserial PRIMARY KEY,
    match_id uuid NOT NULL REFERENCES matches(id) ON DELETE CASCADE,
    turn_number integer NOT NULL,
    schema_version integer NOT NULL DEFAULT 1,
    state jsonb NOT NULL,
    state_hash text NOT NULL,
    created_at timestamptz NOT NULL DEFAULT now(),
    UNIQUE (match_id, turn_number)
);
