extends Node

signal mode_changed(mode_id: String)
signal solo_configuration_changed
signal ai_world_advanced(report: Dictionary)
signal flad_prologue_changed(stage_index: int, completed: bool)

const SAVE_PATH := "user://riseofreign_session.cfg"

var mode_id: String = "flad_solo"
var solo_difficulty: String = "normal"
var historical_mode: String = "guided"
var solo_timer_seconds: int = 0
var learning_enabled: bool = true
var player_avatar_id: String = ""
var player_display_name: String = ""
var world_tension: int = 18
var learning_score: int = 0
var learning_answers: int = 0
var last_ai_report: Dictionary = {}

var flad_prologue_completed: bool = false
var flad_prologue_stage_index: int = 0
var flad_profile: Dictionary = {}

const AI_PROFILES := {
    "ataturk": {"name":"Mustafa Kemal Atatürk", "country":"Türkei", "focus":["Bildung und Verwaltung", "Bahn- und Industrieausbau", "regionale Diplomatie"]},
    "hitler": {"name":"Adolf Hitler", "country":"Deutschland", "focus":["politische Machtkonsolidierung", "Propaganda und Mobilisierung", "Aufrüstung"]},
    "stalin": {"name":"Joseph Stalin", "country":"Sowjetunion", "focus":["staatliche Planung", "Schwerindustrie", "Versorgung und innere Kontrolle"]},
    "churchill": {"name":"Winston Churchill", "country":"Großbritannien", "focus":["Parlament und Presse", "Außenpolitik", "Sicherheitswarnungen"]},
    "roosevelt": {"name":"Franklin D. Roosevelt", "country":"USA", "focus":["Bankenstabilisierung", "Arbeitsprogramme", "staatliche Krisenpolitik"]},
    "mussolini": {"name":"Benito Mussolini", "country":"Italien", "focus":["Infrastruktur", "Staatsindustrie", "militärische Prestigeprojekte"]}
}

func _ready() -> void:
    _load_session()

func start_solo() -> void:
    mode_id = "flad_solo"
    learning_enabled = true
    _save_session()
    mode_changed.emit(mode_id)

func start_flad_solo() -> void:
    start_solo()

func start_historical_solo() -> void:
    mode_id = "solo_historical"
    learning_enabled = true
    _save_session()
    mode_changed.emit(mode_id)

func start_multiplayer() -> void:
    mode_id = "historical_2v2"
    _save_session()
    mode_changed.emit(mode_id)

func is_solo() -> bool:
    return mode_id in ["flad_solo", "solo_historical"]

func is_flad_solo() -> bool:
    return mode_id == "flad_solo"

func configure_solo(difficulty_id: String, history_id: String, timer_seconds: int, enable_learning: bool) -> void:
    solo_difficulty = difficulty_id
    historical_mode = history_id
    solo_timer_seconds = maxi(0, timer_seconds)
    learning_enabled = enable_learning
    _save_session()
    solo_configuration_changed.emit()

func select_avatar(avatar_id: String, display_name: String) -> void:
    player_avatar_id = avatar_id
    player_display_name = display_name
    world_tension = 18
    last_ai_report = {}
    _save_session()

func set_flad_prologue_progress(stage_index: int, profile: Dictionary, completed: bool) -> void:
    flad_prologue_stage_index = maxi(0, stage_index)
    flad_profile = profile.duplicate(true)
    flad_prologue_completed = completed
    if completed:
        player_avatar_id = "custom"
        player_display_name = "Flad Rasputin"
    _save_session()
    flad_prologue_changed.emit(flad_prologue_stage_index, flad_prologue_completed)

func complete_flad_prologue(profile: Dictionary) -> void:
    mode_id = "flad_solo"
    flad_profile = profile.duplicate(true)
    flad_prologue_completed = true
    player_avatar_id = "custom"
    player_display_name = "Flad Rasputin"
    _save_session()
    flad_prologue_changed.emit(flad_prologue_stage_index, true)

func reset_flad_prologue() -> void:
    mode_id = "flad_solo"
    flad_prologue_completed = false
    flad_prologue_stage_index = 0
    flad_profile = {}
    player_avatar_id = ""
    player_display_name = ""
    world_tension = 18
    last_ai_report = {}
    learning_score = 0
    learning_answers = 0
    _save_session()
    flad_prologue_changed.emit(0, false)

func session_label() -> String:
    if is_flad_solo():
        return "SOLO · FLAD RASPUTIN · %s" % _humanize(solo_difficulty)
    if mode_id == "solo_historical":
        return "SOLO · HISTORISCHE PERSPEKTIVE · %s" % _humanize(solo_difficulty)
    return "2 GEGEN 2 · BLAU GEGEN ROT"

func timer_total_players() -> int:
    return 1 if is_solo() else 4

func timer_seconds() -> int:
    return solo_timer_seconds if is_solo() else int(ProjectSettings.get_setting("riseofreign/ui/default_turn_timer_seconds", 300))

func ai_player_count() -> int:
    if not is_solo():
        return 0
    return maxi(0, AI_PROFILES.size() - (1 if AI_PROFILES.has(player_avatar_id) else 0))

func advance_ai_world(month_key: String) -> Dictionary:
    if not is_solo():
        return {}
    var lines: Array[String] = []
    var pressure: int = 0
    var ids: Array = AI_PROFILES.keys()
    ids.sort()
    for ai_id_value: Variant in ids:
        var ai_id: String = str(ai_id_value)
        if ai_id == player_avatar_id:
            continue
        var profile_value: Variant = AI_PROFILES.get(ai_id, {})
        var profile: Dictionary = profile_value as Dictionary if typeof(profile_value) == TYPE_DICTIONARY else {}
        var focus_value: Variant = profile.get("focus", [])
        var focus: Array = focus_value as Array if typeof(focus_value) == TYPE_ARRAY else []
        var seed: int = absi((month_key + "|" + ai_id + "|" + solo_difficulty + "|" + historical_mode).hash())
        var choice: String = str(focus[seed % focus.size()]) if not focus.is_empty() else "innere Verwaltung"
        var posture: String = _ai_posture(seed)
        lines.append("%s · %s: %s — %s" % [profile.get("country", ai_id), profile.get("name", ai_id), choice, posture])
        pressure += 1 + (seed % 3)
    var difficulty_pressure: int = int({"easy":0, "normal":2, "hard":5}.get(solo_difficulty, 2))
    world_tension = clampi(world_tension + int(pressure / 3.0) + difficulty_pressure, 0, 100)
    last_ai_report = {
        "month": month_key,
        "summaries": lines,
        "world_tension": world_tension,
        "director": "guided_historical" if historical_mode == "guided" else "adaptive_alternate_history",
        "note": "Die KI-Welt ist im Prototyp eine deterministische strategische Simulation. Weitere Länderaktionen werden schrittweise an Karte, Wirtschaft und Diplomatie angebunden."
    }
    _save_session()
    ai_world_advanced.emit(last_ai_report)
    return last_ai_report

func ensure_ai_world_report(month_key: String) -> Dictionary:
    if str(last_ai_report.get("month", "")) != month_key:
        return advance_ai_world(month_key)
    return last_ai_report

func record_learning_answer(correct: bool) -> void:
    learning_answers += 1
    if correct:
        learning_score += 1
    _save_session()

func learning_progress_text() -> String:
    if learning_answers <= 0:
        return "Noch keine Wissensfrage beantwortet."
    return "%d von %d Wissensfragen richtig" % [learning_score, learning_answers]

func educational_notice() -> String:
    return "Lernmodus: Historische Diktaturen, Krieg, Propaganda und Menschenrechtsverletzungen werden kritisch eingeordnet. Extremistische Symbole werden in der Spielgrafik nicht verherrlicht, nicht als Dekoration belohnt und nur in geprüftem Lernkontext verwendet."

func _ai_posture(seed: int) -> String:
    var postures: Array[String] = ["vorsichtig", "wirtschaftlich priorisiert", "diplomatisch aktiv", "innenpolitisch unter Druck", "strategisch abwartend"]
    if solo_difficulty == "hard":
        postures = ["entschlossen", "risikobereit", "koordiniert", "ressourcenorientiert", "aggressiv planend"]
    elif solo_difficulty == "easy":
        postures = ["zurückhaltend", "berechenbar", "langsam reagierend", "innenpolitisch gebunden", "defensiv"]
    return postures[seed % postures.size()]

func _save_session() -> void:
    var config: ConfigFile = ConfigFile.new()
    config.set_value("session", "mode_id", mode_id)
    config.set_value("session", "solo_difficulty", solo_difficulty)
    config.set_value("session", "historical_mode", historical_mode)
    config.set_value("session", "solo_timer_seconds", solo_timer_seconds)
    config.set_value("session", "learning_enabled", learning_enabled)
    config.set_value("session", "player_avatar_id", player_avatar_id)
    config.set_value("session", "player_display_name", player_display_name)
    config.set_value("session", "world_tension", world_tension)
    config.set_value("session", "learning_score", learning_score)
    config.set_value("session", "learning_answers", learning_answers)
    config.set_value("flad", "prologue_completed", flad_prologue_completed)
    config.set_value("flad", "prologue_stage_index", flad_prologue_stage_index)
    config.set_value("flad", "profile_json", JSON.stringify(flad_profile))
    config.save(SAVE_PATH)

func _load_session() -> void:
    var config: ConfigFile = ConfigFile.new()
    if config.load(SAVE_PATH) != OK:
        return
    mode_id = str(config.get_value("session", "mode_id", mode_id))
    solo_difficulty = str(config.get_value("session", "solo_difficulty", solo_difficulty))
    historical_mode = str(config.get_value("session", "historical_mode", historical_mode))
    solo_timer_seconds = int(config.get_value("session", "solo_timer_seconds", solo_timer_seconds))
    learning_enabled = bool(config.get_value("session", "learning_enabled", learning_enabled))
    player_avatar_id = str(config.get_value("session", "player_avatar_id", player_avatar_id))
    player_display_name = str(config.get_value("session", "player_display_name", player_display_name))
    world_tension = int(config.get_value("session", "world_tension", world_tension))
    learning_score = int(config.get_value("session", "learning_score", learning_score))
    learning_answers = int(config.get_value("session", "learning_answers", learning_answers))
    flad_prologue_completed = bool(config.get_value("flad", "prologue_completed", false))
    flad_prologue_stage_index = int(config.get_value("flad", "prologue_stage_index", 0))
    var profile_json: String = str(config.get_value("flad", "profile_json", "{}"))
    var parsed_profile: Variant = JSON.parse_string(profile_json)
    flad_profile = (parsed_profile as Dictionary).duplicate(true) if typeof(parsed_profile) == TYPE_DICTIONARY else {}

func _humanize(value: String) -> String:
    var text: String = value.replace("_", " ").strip_edges()
    if text.is_empty():
        return "Normal"
    return text.substr(0, 1).to_upper() + text.substr(1)
