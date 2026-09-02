extends Node

signal mode_changed(mode_id: String)
signal solo_configuration_changed
signal ai_world_advanced(report: Dictionary)

const SAVE_PATH := "user://riseofreign_session.cfg"

var mode_id: String = "solo_learning"
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
    mode_id = "solo_learning"
    learning_enabled = true
    _save_session()
    mode_changed.emit(mode_id)

func start_multiplayer() -> void:
    mode_id = "historical_2v2"
    _save_session()
    mode_changed.emit(mode_id)

func is_solo() -> bool:
    return mode_id == "solo_learning"

func configure_solo(difficulty_id: String, history_id: String, timer_seconds: int, enable_learning: bool) -> void:
    solo_difficulty = difficulty_id
    historical_mode = history_id
    solo_timer_seconds = max(0, timer_seconds)
    learning_enabled = enable_learning
    _save_session()
    solo_configuration_changed.emit()

func select_avatar(avatar_id: String, display_name: String) -> void:
    player_avatar_id = avatar_id
    player_display_name = display_name
    world_tension = 18
    last_ai_report = {}
    _save_session()

func session_label() -> String:
    if is_solo():
        return "SOLO · LERNKAMPAGNE · %s" % _humanize(solo_difficulty)
    return "2 GEGEN 2 · BLAU GEGEN ROT"

func timer_total_players() -> int:
    return 1 if is_solo() else 4

func timer_seconds() -> int:
    return solo_timer_seconds if is_solo() else int(ProjectSettings.get_setting("riseofreign/ui/default_turn_timer_seconds", 300))

func ai_player_count() -> int:
    if not is_solo():
        return 0
    return max(0, AI_PROFILES.size() - (1 if AI_PROFILES.has(player_avatar_id) else 0))

func advance_ai_world(month_key: String) -> Dictionary:
    if not is_solo():
        return {}
    var lines: Array[String] = []
    var pressure := 0
    var ids: Array = AI_PROFILES.keys()
    ids.sort()
    for ai_id in ids:
        if ai_id == player_avatar_id:
            continue
        var profile: Dictionary = AI_PROFILES[ai_id]
        var focus: Array = profile.get("focus", [])
        var seed: int = absi((month_key + "|" + ai_id + "|" + solo_difficulty + "|" + historical_mode).hash())
        var choice := str(focus[seed % focus.size()]) if not focus.is_empty() else "innere Verwaltung"
        var posture := _ai_posture(seed)
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
    if last_ai_report.get("month", "") != month_key:
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
    var postures := ["vorsichtig", "wirtschaftlich priorisiert", "diplomatisch aktiv", "innenpolitisch unter Druck", "strategisch abwartend"]
    if solo_difficulty == "hard":
        postures = ["entschlossen", "risikobereit", "koordiniert", "ressourcenorientiert", "aggressiv planend"]
    elif solo_difficulty == "easy":
        postures = ["zurückhaltend", "berechenbar", "langsam reagierend", "innenpolitisch gebunden", "defensiv"]
    return str(postures[seed % postures.size()])

func _save_session() -> void:
    var config := ConfigFile.new()
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
    config.save(SAVE_PATH)

func _load_session() -> void:
    var config := ConfigFile.new()
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

func _humanize(value: String) -> String:
    var text := value.replace("_", " ").strip_edges()
    if text.is_empty():
        return "Normal"
    return text.substr(0, 1).to_upper() + text.substr(1)
