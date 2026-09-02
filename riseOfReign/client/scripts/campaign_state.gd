class_name CampaignState
extends RefCounted

const SAVE_PATH := "user://riseofreign_campaign.cfg"
const DEFAULT_MONTH_ID := "1933-01"
const DEFAULT_DATE := "1933-01-01"

static func reset() -> void:
    if FileAccess.file_exists(SAVE_PATH):
        DirAccess.remove_absolute(ProjectSettings.globalize_path(SAVE_PATH))

static func begin_campaign(avatar_id: String, display_name: String) -> void:
    var config := ConfigFile.new()
    config.set_value("campaign", "avatar_id", avatar_id)
    config.set_value("campaign", "display_name", display_name)
    config.set_value("campaign", "current_month_id", DEFAULT_MONTH_ID)
    config.set_value("campaign", "current_date", DEFAULT_DATE)
    config.set_value("campaign", "completed_months", [])
    config.set_value("campaign", "waiting_for_content", false)
    config.set_value("campaign", "player_state", {})
    config.set_value("campaign", "indicators", {})
    config.set_value("campaign", "last_result", {})
    config.set_value("campaign", "version", 1)
    config.save(SAVE_PATH)

static func ensure_avatar(avatar_id: String, display_name: String) -> void:
    var snapshot := load_snapshot()
    if snapshot.is_empty() or str(snapshot.get("avatar_id", "")) != avatar_id:
        begin_campaign(avatar_id, display_name)

static func has_campaign() -> bool:
    var snapshot := load_snapshot()
    return not str(snapshot.get("avatar_id", "")).is_empty() and not str(snapshot.get("current_month_id", "")).is_empty()

static func load_snapshot() -> Dictionary:
    var config := ConfigFile.new()
    if config.load(SAVE_PATH) != OK:
        return {}
    return {
        "avatar_id": str(config.get_value("campaign", "avatar_id", "")),
        "display_name": str(config.get_value("campaign", "display_name", "")),
        "current_month_id": str(config.get_value("campaign", "current_month_id", DEFAULT_MONTH_ID)),
        "current_date": str(config.get_value("campaign", "current_date", DEFAULT_DATE)),
        "completed_months": _as_array(config.get_value("campaign", "completed_months", [])),
        "waiting_for_content": bool(config.get_value("campaign", "waiting_for_content", false)),
        "player_state": _as_dictionary(config.get_value("campaign", "player_state", {})),
        "indicators": _as_dictionary(config.get_value("campaign", "indicators", {})),
        "last_result": _as_dictionary(config.get_value("campaign", "last_result", {})),
        "version": int(config.get_value("campaign", "version", 1))
    }

static func current_month_id() -> String:
    return str(load_snapshot().get("current_month_id", DEFAULT_MONTH_ID))

static func current_date() -> String:
    return str(load_snapshot().get("current_date", DEFAULT_DATE))

static func avatar_id() -> String:
    return str(load_snapshot().get("avatar_id", ""))

static func display_name() -> String:
    return str(load_snapshot().get("display_name", ""))

static func player_state() -> Dictionary:
    return _as_dictionary(load_snapshot().get("player_state", {})).duplicate(true)

static func indicators() -> Dictionary:
    return _as_dictionary(load_snapshot().get("indicators", {})).duplicate(true)

static func last_result() -> Dictionary:
    return _as_dictionary(load_snapshot().get("last_result", {})).duplicate(true)

static func completed_months() -> Array:
    return _as_array(load_snapshot().get("completed_months", [])).duplicate()

static func is_waiting_for_content() -> bool:
    return bool(load_snapshot().get("waiting_for_content", false))

static func is_month_completed(month_id: String) -> bool:
    return completed_months().has(month_id)

static func save_month_result(month_id: String, result: Dictionary) -> void:
    var snapshot := load_snapshot()
    if snapshot.is_empty():
        return

    var completed := _as_array(snapshot.get("completed_months", []))
    if not completed.has(month_id):
        completed.append(month_id)

    var next_available := bool(result.get("next_content_available", false))
    var next_month_id := str(result.get("next_month_id", ""))
    var current_month := next_month_id if next_available and not next_month_id.is_empty() else month_id

    var config := ConfigFile.new()
    config.load(SAVE_PATH)
    config.set_value("campaign", "current_month_id", current_month)
    config.set_value("campaign", "current_date", str(result.get("next_date", snapshot.get("current_date", DEFAULT_DATE))))
    config.set_value("campaign", "completed_months", completed)
    config.set_value("campaign", "waiting_for_content", not next_available)
    config.set_value("campaign", "player_state", _as_dictionary(result.get("player_state", {})))
    config.set_value("campaign", "indicators", _as_dictionary(result.get("resulting_indicators", {})))
    config.set_value("campaign", "last_result", result.duplicate(true))
    config.set_value("campaign", "version", 1)
    config.save(SAVE_PATH)

static func progress_text() -> String:
    var snapshot := load_snapshot()
    if snapshot.is_empty():
        return "Kein Spielstand"
    var months := _as_array(snapshot.get("completed_months", []))
    if bool(snapshot.get("waiting_for_content", false)):
        return "%d Monate abgeschlossen · nächster Inhalt in Vorbereitung" % months.size()
    return "%d Monate abgeschlossen · weiter mit %s" % [months.size(), _month_label(str(snapshot.get("current_month_id", DEFAULT_MONTH_ID)))]

static func _month_label(month_id: String) -> String:
    var labels := {
        "1933-01": "Januar 1933",
        "1933-02": "Februar 1933",
        "1933-03": "März 1933"
    }
    return str(labels.get(month_id, month_id))

static func _as_dictionary(value) -> Dictionary:
    return value if typeof(value) == TYPE_DICTIONARY else {}

static func _as_array(value) -> Array:
    return value if typeof(value) == TYPE_ARRAY else []
