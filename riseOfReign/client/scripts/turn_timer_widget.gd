extends PanelContainer

@export var turn_seconds: int = 300
@export var ready_players: int = 0
@export var total_players: int = 4

@onready var timer_label: Label = $TurnRow/TimerLabel
@onready var ready_players_label: Label = $TurnRow/ReadyInfo/ReadyPlayers
@onready var ready_state_label: Label = $TurnRow/ReadyInfo/ReadyState
@onready var ready_button: Button = $TurnRow/ReadyButton
@onready var tick: Timer = $TurnTick

var seconds_left: int
var local_ready := false
var submission_requested := false
var timer_disabled := false

func _ready() -> void:
    if GameSession.is_solo():
        total_players = 1
        ready_players = 0
        turn_seconds = GameSession.timer_seconds()
        timer_disabled = turn_seconds <= 0
        ready_button.text = "ZUG BEENDEN"
        ready_button.tooltip_text = "Solo-Zug prüfen und abschließen"
    seconds_left = max(0, turn_seconds)
    ready_button.pressed.connect(_on_ready_pressed)
    tick.timeout.connect(_on_tick)
    if not timer_disabled:
        tick.start()
    _refresh()

func reset_for_next_turn() -> void:
    tick.stop()
    local_ready = false
    submission_requested = false
    ready_players = 0
    total_players = GameSession.timer_total_players()
    turn_seconds = GameSession.timer_seconds()
    timer_disabled = turn_seconds <= 0
    seconds_left = max(0, turn_seconds)
    ready_button.disabled = false
    ready_button.text = "ZUG BEENDEN" if GameSession.is_solo() else "FERTIG"
    ready_state_label.text = "OHNE ZEITDRUCK" if timer_disabled else "AKTIV"
    ready_state_label.add_theme_color_override("font_color", Color("b9a77d") if timer_disabled else Color("8c8c8c"))
    if not timer_disabled:
        tick.start()
    _refresh()

func set_server_seconds_left(value: int) -> void:
    if timer_disabled:
        return
    seconds_left = max(0, value)
    _refresh()

func set_ready_count(value: int) -> void:
    ready_players = clampi(value, 0, total_players)
    _refresh()

func _on_ready_pressed() -> void:
    AudioManager.play_click()
    if GameSession.is_solo():
        if local_ready or submission_requested:
            return
        submission_requested = true
        ready_button.text = "PRÜFEN…"
        ready_state_label.text = "ENTSCHEIDUNGEN WERDEN GEPRÜFT"
        var hub := _find_hub()
        if hub != null and hub.has_method("_finish_january"):
            hub.call("_finish_january")
        get_tree().create_timer(1.5).timeout.connect(_check_solo_submission)
        return

    local_ready = not local_ready
    if local_ready:
        ready_players = min(total_players, ready_players + 1)
        ready_button.text = "BEREIT ✓"
        ready_state_label.text = "ABGEGEBEN"
        ready_state_label.add_theme_color_override("font_color", Color("55d98b"))
        var hub := _find_hub()
        if hub != null and hub.has_method("_finish_january"):
            hub.call_deferred("_finish_january")
    else:
        ready_players = max(0, ready_players - 1)
        ready_button.text = "FERTIG"
        ready_state_label.text = "AKTIV"
        ready_state_label.add_theme_color_override("font_color", Color("8c8c8c"))
    _refresh()

func _check_solo_submission() -> void:
    var hub := _find_hub()
    if hub != null and bool(hub.get("january_resolved")):
        local_ready = true
        ready_players = 1
        ready_button.text = "ABGESCHLOSSEN ✓"
        ready_button.disabled = true
        ready_state_label.text = "MONAT AUSGEWERTET"
        ready_state_label.add_theme_color_override("font_color", Color("55d98b"))
    else:
        submission_requested = false
        ready_button.text = "ZUG BEENDEN"
        ready_state_label.text = "NOCH NICHT VOLLSTÄNDIG"
        ready_state_label.add_theme_color_override("font_color", Color("e7b354"))
    _refresh()

func _on_tick() -> void:
    if GameSession.is_solo():
        var hub := _find_hub()
        if hub != null and bool(hub.get("january_resolved")) and not local_ready:
            _check_solo_submission()
            return
    if seconds_left <= 0:
        tick.stop()
        timer_label.text = "00:00"
        ready_state_label.text = "ZEIT ABGELAUFEN"
        if GameSession.is_solo() and not submission_requested:
            _on_ready_pressed()
        else:
            ready_button.disabled = true
        return
    seconds_left -= 1
    _refresh()

func _refresh() -> void:
    if timer_disabled:
        timer_label.text = "∞"
        ready_players_label.text = "SOLOZUG"
        if not local_ready and not submission_requested:
            ready_state_label.text = "OHNE ZEITDRUCK"
            ready_state_label.add_theme_color_override("font_color", Color("b9a77d"))
        return

    var hours := seconds_left / 3600
    var minutes := (seconds_left % 3600) / 60
    var seconds := seconds_left % 60
    if hours > 0:
        timer_label.text = "%02d:%02d:%02d" % [hours, minutes, seconds]
    else:
        timer_label.text = "%02d:%02d" % [minutes, seconds]
    ready_players_label.text = "%d / %d fertig" % [ready_players, total_players]
    if seconds_left <= 30 and not local_ready:
        timer_label.add_theme_color_override("font_color", Color("ff5360"))
    elif seconds_left <= max(60, turn_seconds / 4) and not local_ready:
        timer_label.add_theme_color_override("font_color", Color("e7b354"))
    else:
        timer_label.add_theme_color_override("font_color", Color("f2efe8"))

func _find_hub() -> Node:
    var node: Node = get_parent()
    while node != null:
        if node.has_method("_finish_january"):
            return node
        node = node.get_parent()
    return null
