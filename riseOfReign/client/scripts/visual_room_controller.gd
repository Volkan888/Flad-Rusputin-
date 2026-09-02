extends Control

const ROOM_TEXTURES := {
    "office": preload("res://assets/rooms/office_command.svg"),
    "map": preload("res://assets/rooms/map_room.svg"),
    "communications": preload("res://assets/rooms/communications_room.svg"),
    "research": preload("res://assets/rooms/research_room.svg"),
    "archive": preload("res://assets/rooms/archive_room.svg"),
    "meeting": preload("res://assets/rooms/meeting_room.svg")
}

const ICONS := {
    "office": preload("res://assets/icons/office.svg"),
    "world": preload("res://assets/icons/world.svg"),
    "phone": preload("res://assets/icons/phone.svg"),
    "events": preload("res://assets/icons/events.svg"),
    "decisions": preload("res://assets/icons/decisions.svg"),
    "archive": preload("res://assets/icons/archive.svg"),
    "radio": preload("res://assets/icons/radio.svg"),
    "rooms": preload("res://assets/icons/rooms.svg"),
    "learning": preload("res://assets/icons/learning.svg"),
    "research": preload("res://assets/icons/research.svg"),
    "economy": preload("res://assets/icons/economy.svg"),
    "military": preload("res://assets/icons/military.svg"),
    "diplomacy": preload("res://assets/icons/diplomacy.svg"),
    "agents": preload("res://assets/icons/agents.svg"),
    "resources": preload("res://assets/icons/resources.svg"),
    "construction": preload("res://assets/icons/construction.svg"),
    "quiz": preload("res://assets/icons/quiz.svg"),
    "flag": preload("res://assets/icons/state_flag.svg"),
    "messages": preload("res://assets/icons/messages.svg"),
    "info": preload("res://assets/icons/info.svg")
}

@onready var room_image: TextureRect = $RoomImage
@onready var hotspot_layer: Control = $HotspotLayer
@onready var room_caption: Label = $CaptionPanel/RoomCaption
@onready var learning_badge: Button = $LearningBadge
@onready var list_fallback: Button = $ListFallback

var hub: Node
var active_room_id := ""
var learning_data: Dictionary = {"cards": []}
var visual_mode := true
var ai_advanced_for_january := false

func _ready() -> void:
    mouse_filter = Control.MOUSE_FILTER_PASS
    _find_hub()
    _load_learning_cards()
    _style_utility_button(learning_badge)
    _style_utility_button(list_fallback)
    learning_badge.pressed.connect(_show_learning_card.bind("office"))
    list_fallback.pressed.connect(_toggle_text_fallback)
    resized.connect(_layout_hotspots)
    _update_learning_badge()
    call_deferred("_sync_room")

func _process(_delta: float) -> void:
    if hub == null:
        _find_hub()
        return
    var room_id := str(hub.get("current_room_id"))
    if room_id != active_room_id:
        _set_room(room_id)
    if GameSession.is_solo() and bool(hub.get("january_resolved")) and not ai_advanced_for_january:
        GameSession.ensure_ai_world_report("1933-01")
        ai_advanced_for_january = true
        _update_learning_badge()

func _find_hub() -> void:
    var node: Node = get_parent()
    while node != null:
        if node.has_method("_show_office") and node.has_method("_show_named_panel"):
            hub = node
            return
        node = node.get_parent()

func _sync_room() -> void:
    if hub != null:
        _set_room(str(hub.get("current_room_id")))

func _set_room(room_id: String) -> void:
    active_room_id = room_id
    var key := _room_key(room_id)
    room_image.texture = ROOM_TEXTURES.get(key, ROOM_TEXTURES["office"])
    room_caption.text = _caption(room_id)
    _build_hotspots(_spots(room_id))

func _room_key(room_id: String) -> String:
    if room_id in ["map_room", "war_room"]:
        return "map"
    if room_id in ["communications_room", "intelligence_room", "press_room", "crisis_shelter"]:
        return "communications"
    if room_id == "research_room":
        return "research"
    if room_id in ["archive_room", "staff_anteroom"]:
        return "archive"
    if room_id in ["meeting_room", "cabinet_room", "conference_room"]:
        return "meeting"
    return "office"

func _caption(room_id: String) -> String:
    var labels := {
        "office": "PERSÖNLICHE STEUERZENTRALE · OBJEKTE MIT DER MAUS ANKLICKEN",
        "map_room": "KARTENRAUM · SEKTOREN, RESSOURCEN UND VERKEHRSNETZE",
        "communications_room": "KOMMUNIKATIONSRAUM · TELEFON, FUNK UND DIPLOMATIE",
        "research_room": "FORSCHUNGSRAUM · ARBEIT, MILITÄR, KULTUR UND SCHULE",
        "archive_room": "ARCHIVRAUM · AKTEN, QUELLEN UND ENTSCHEIDUNGSVERLAUF",
        "meeting_room": "BESPRECHUNGSRAUM · AGENDA, VERHANDLUNG UND VEREINBARUNG",
        "room_selector": "RAUMAUSWAHL · FREIGESCHALTETE UND SPÄTERE RÄUME"
    }
    return str(labels.get(room_id, room_id.replace("_", " ").to_upper()))

func _spots(room_id: String) -> Array:
    if room_id in ["map_room", "war_room"]:
        return [
            _spot("Ressourcen", "resources", Vector2(0.18, 0.22), "map_actions"),
            _spot("Verkehr & Handel", "world", Vector2(0.48, 0.17), "map_transport"),
            _spot("Bauprojekte", "construction", Vector2(0.75, 0.30), "map_construction"),
            _spot("Militärlage", "military", Vector2(0.70, 0.68), "strategy"),
            _spot("Wissen", "learning", Vector2(0.13, 0.70), "learn", "map"),
            _spot("Zurück ins Büro", "office", Vector2(0.42, 0.80), "office")
        ]
    if room_id in ["communications_room", "intelligence_room", "press_room", "crisis_shelter"]:
        return [
            _spot("Telefon", "phone", Vector2(0.63, 0.47), "phone"),
            _spot("Nachrichten", "messages", Vector2(0.22, 0.70), "events"),
            _spot("Diplomatie", "diplomacy", Vector2(0.47, 0.20), "diplomacy"),
            _spot("KI-Weltlage", "agents", Vector2(0.78, 0.24), "ai_world"),
            _spot("Quellenkritik", "learning", Vector2(0.72, 0.72), "learn", "communications"),
            _spot("Zurück ins Büro", "office", Vector2(0.12, 0.18), "office")
        ]
    if room_id == "research_room":
        return [
            _spot("Volk & Arbeit", "economy", Vector2(0.15, 0.24), "research_branch", "Volk & Arbeit"),
            _spot("Soldaten & Waffen", "military", Vector2(0.48, 0.24), "research_branch", "Soldaten & Waffen"),
            _spot("Kultur, Religion & Schule", "learning", Vector2(0.76, 0.24), "research_branch", "Kultur, Religion & Schule"),
            _spot("Forschung öffnen", "research", Vector2(0.46, 0.67), "research"),
            _spot("Wissensfrage", "quiz", Vector2(0.76, 0.70), "quiz", "research"),
            _spot("Zurück ins Büro", "office", Vector2(0.12, 0.70), "office")
        ]
    if room_id in ["archive_room", "staff_anteroom"]:
        return [
            _spot("Akten", "archive", Vector2(0.20, 0.26), "archive"),
            _spot("Entscheidungsverlauf", "decisions", Vector2(0.49, 0.28), "decisions"),
            _spot("Historischer Kontext", "learning", Vector2(0.76, 0.25), "learn", "events"),
            _spot("Ereignisse", "events", Vector2(0.69, 0.69), "events"),
            _spot("Wissensfrage", "quiz", Vector2(0.38, 0.70), "quiz", "events"),
            _spot("Zurück ins Büro", "office", Vector2(0.11, 0.68), "office")
        ]
    if room_id in ["meeting_room", "cabinet_room", "conference_room"]:
        return [
            _spot("Telefon / Einladen", "phone", Vector2(0.18, 0.26), "phone"),
            _spot("Diplomatie", "diplomacy", Vector2(0.49, 0.24), "diplomacy"),
            _spot("Staatshaushalt", "economy", Vector2(0.77, 0.27), "state"),
            _spot("KI-Weltlage", "agents", Vector2(0.73, 0.70), "ai_world"),
            _spot("Lernhinweis", "learning", Vector2(0.41, 0.72), "learn", "office"),
            _spot("Zurück ins Büro", "office", Vector2(0.11, 0.70), "office")
        ]
    if room_id == "room_selector":
        return [
            _spot("Büro", "office", Vector2(0.12, 0.22), "office"),
            _spot("Kartenraum", "world", Vector2(0.42, 0.20), "room", "map_room"),
            _spot("Meetingraum", "diplomacy", Vector2(0.72, 0.21), "room", "meeting_room"),
            _spot("Archivraum", "archive", Vector2(0.19, 0.67), "room", "archive_room", 2),
            _spot("Funkraum", "phone", Vector2(0.49, 0.66), "room", "communications_room", 3),
            _spot("Forschungsraum", "research", Vector2(0.77, 0.66), "room", "research_room", 4)
        ]
    return [
        _spot("Weltkarte", "world", Vector2(0.63, 0.23), "world"),
        _spot("Telefon", "phone", Vector2(0.24, 0.60), "phone"),
        _spot("Entscheidungen", "decisions", Vector2(0.51, 0.73), "decisions"),
        _spot("Akten", "archive", Vector2(0.78, 0.52), "archive"),
        _spot("Radio & Events", "radio", Vector2(0.79, 0.29), "events"),
        _spot("Staat", "flag", Vector2(0.35, 0.23), "state"),
        _spot("Weitere Räume", "rooms", Vector2(0.86, 0.76), "rooms"),
        _spot("Lernmodus", "learning", Vector2(0.10, 0.20), "learn", "office"),
        _spot("KI-Weltlage", "agents", Vector2(0.11, 0.78), "ai_world")
    ]

func _spot(label: String, icon_id: String, position_ratio: Vector2, action: String, payload := "", required_level := 0) -> Dictionary:
    return {"label": label, "icon": icon_id, "position": position_ratio, "action": action, "payload": payload, "required_level": required_level}

func _build_hotspots(definitions: Array) -> void:
    for child in hotspot_layer.get_children():
        child.queue_free()
    for definition in definitions:
        var button := Button.new()
        button.text = str(definition.get("label", "Aktion"))
        button.icon = ICONS.get(str(definition.get("icon", "info")), ICONS["info"])
        button.expand_icon = true
        button.icon_max_width = 28
        button.custom_minimum_size = Vector2(176, 56)
        button.size = Vector2(176, 56)
        button.alignment = HORIZONTAL_ALIGNMENT_LEFT
        button.icon_alignment = HORIZONTAL_ALIGNMENT_LEFT
        button.mouse_default_cursor_shape = Control.CURSOR_POINTING_HAND
        button.tooltip_text = "%s öffnen" % button.text
        button.set_meta("normalized_position", definition.get("position", Vector2(0.5, 0.5)))
        var required := int(definition.get("required_level", 0))
        var current := int(hub.get("current_office_level")) if hub != null else 0
        if required > current:
            button.disabled = true
            button.text += " · LEVEL %d" % required
            button.tooltip_text = "Benötigt Büro-Level %d" % required
        else:
            button.pressed.connect(_invoke.bind(str(definition.get("action", "")), str(definition.get("payload", ""))))
        _style_hotspot(button)
        hotspot_layer.add_child(button)
    call_deferred("_layout_hotspots")

func _layout_hotspots() -> void:
    if not is_instance_valid(hotspot_layer):
        return
    for node in hotspot_layer.get_children():
        if not node is Button:
            continue
        var button := node as Button
        var ratio: Vector2 = button.get_meta("normalized_position", Vector2(0.5, 0.5))
        var target := Vector2(ratio.x * size.x - button.size.x * 0.5, ratio.y * size.y - button.size.y * 0.5)
        button.position = Vector2(clampf(target.x, 10.0, maxf(10.0, size.x - button.size.x - 10.0)), clampf(target.y, 10.0, maxf(10.0, size.y - button.size.y - 10.0)))

func _invoke(action: String, payload: String) -> void:
    AudioManager.play_click()
    match action:
        "office": _hub_call("_show_office")
        "world": _hub_call("_on_nav_world")
        "phone": _hub_call("_on_nav_phone")
        "decisions": _hub_call("_on_nav_decisions")
        "archive": _hub_call("_on_nav_archive")
        "research": _hub_call("_on_nav_research")
        "diplomacy": _hub_call("_on_nav_diplomacy")
        "state": _hub_call("_on_nav_economy")
        "strategy": _hub_call("_on_nav_military")
        "events": _hub_call("_on_nav_events")
        "rooms": _hub_call("_show_room_selector")
        "room": _hub_call("_open_room", [payload])
        "map_actions": _hub_call("_show_january_map_actions")
        "map_transport": _panel("Verkehr & Handel", "Straßen, Eisenbahn, Häfen und Seewege erhöhen Handel und Versorgung. Fremde Nutzung benötigt in Friedenszeiten ein Abkommen. Schäden, Blockaden und Sabotage werden abstrakt durch Kosten, Risiko und Gegenmaßnahmen aufgelöst.")
        "map_construction": _panel("Bauprojekte", "Sektor, Material, Staatskasse, Arbeitskräfte und Bauzeit bestimmen den Ausbau. Autobahn, Eisenbahn, Hafen, Kraftwerk, Lager und Fabrik verändern Handel, Versorgung und Beweglichkeit.")
        "research_branch": _panel(payload, "Länderspezifische Projekte besitzen Kosten, Voraussetzungen und Laufzeiten. Parallele Projekte teilen Forschungskapazität, Geld, Fachkräfte und Industrie.")
        "learn": _show_learning_card(payload if not payload.is_empty() else "office")
        "quiz": _show_quiz(payload if not payload.is_empty() else "office")
        "ai_world": _show_ai_world()
        _: _panel("Noch nicht verbunden", "Diese Bildaktion wird im nächsten Systembaustein angeschlossen.")

func _hub_call(method_name: String, args: Array = []) -> void:
    if hub != null and hub.has_method(method_name):
        hub.callv(method_name, args)

func _panel(title: String, body: String) -> void:
    if hub != null:
        hub.call("_show_named_panel", title, body)

func _load_learning_cards() -> void:
    var file := FileAccess.open("res://assets/learning/knowledge_cards_1933.json", FileAccess.READ)
    if file == null:
        return
    var parsed = JSON.parse_string(file.get_as_text())
    if typeof(parsed) == TYPE_DICTIONARY:
        learning_data = parsed

func _card(topic: String) -> Dictionary:
    for entry in learning_data.get("cards", []):
        if str(entry.get("topic", "")) == topic:
            return entry
    var cards: Array = learning_data.get("cards", [])
    return cards[0] if not cards.is_empty() else {}

func _show_learning_card(topic: String) -> void:
    if not GameSession.learning_enabled:
        _panel("Lernmodus deaktiviert", "Der Lernmodus kann bei der Solo-Auswahl wieder aktiviert werden.")
        return
    var entry := _card(topic)
    if entry.is_empty():
        _panel("Lernmodus", GameSession.educational_notice())
        return
    var body := "%s\n\n%s\n\n%s" % [entry.get("summary", ""), GameSession.educational_notice(), GameSession.learning_progress_text()]
    hub.call("_show_named_panel", "WISSENSKARTE · %s" % entry.get("title", "1933"), body)
    hub.call("_clear_action_list")
    hub.call("_add_action_button", "Wissensfrage beantworten", Callable(self, "_show_quiz_entry").bind(entry))
    hub.call("_add_action_button", "KI-Weltlage ansehen", Callable(self, "_show_ai_world"))
    hub.call("_add_action_button", "Zurück zum Bildraum", Callable(hub, "_show_office"))

func _show_quiz(topic: String) -> void:
    var entry := _card(topic)
    if not entry.is_empty():
        _show_quiz_entry(entry)

func _show_quiz_entry(entry: Dictionary) -> void:
    hub.call("_show_named_panel", "WISSENSFRAGE · %s" % entry.get("title", "1933"), entry.get("question", ""))
    hub.call("_clear_action_list")
    var choices: Array = entry.get("choices", [])
    for index in range(choices.size()):
        hub.call("_add_action_button", str(choices[index]), Callable(self, "_answer_quiz").bind(entry, index))
    hub.call("_add_action_button", "Zurück zur Wissenskarte", Callable(self, "_show_learning_card").bind(str(entry.get("topic", "office"))))

func _answer_quiz(entry: Dictionary, selected_index: int) -> void:
    var correct := selected_index == int(entry.get("correct_index", -1))
    GameSession.record_learning_answer(correct)
    var result := "RICHTIG" if correct else "NOCH NICHT"
    _panel("WISSENSFRAGE · %s" % result, "%s\n\n%s" % [entry.get("explanation", ""), GameSession.learning_progress_text()])
    hub.call("_clear_action_list")
    hub.call("_add_action_button", "Nächste Wissenskarte", Callable(self, "_show_learning_card").bind("events"))
    hub.call("_add_action_button", "Zurück zum Büro", Callable(hub, "_show_office"))
    _update_learning_badge()

func _show_ai_world() -> void:
    if not GameSession.is_solo():
        _panel("Mehrspieler-Welt", "Im 2-gegen-2-Modus werden andere Mächte durch Spieler und Ereignisregeln gesteuert.")
        return
    var report := GameSession.ensure_ai_world_report("1933-01")
    var lines: Array[String] = []
    for line in report.get("summaries", []):
        lines.append("• %s" % line)
    var body := "Weltspannung: %d / 100\nKI-Mächte: %d\n\n%s\n\n%s" % [report.get("world_tension", 0), GameSession.ai_player_count(), "\n".join(lines), report.get("note", "")]
    _panel("SOLO · KI-WELTLAGE", body)

func _toggle_text_fallback() -> void:
    if hub == null:
        return
    var object_scroll := hub.get_node_or_null("Margin/Layout/Content/OfficePanel/OfficeLayout/ObjectScroll")
    if object_scroll == null:
        return
    visual_mode = not visual_mode
    room_image.visible = visual_mode
    hotspot_layer.visible = visual_mode
    room_caption.visible = visual_mode
    object_scroll.visible = not visual_mode
    list_fallback.text = "LISTE" if visual_mode else "BILD"

func _update_learning_badge() -> void:
    learning_badge.text = "%s · %s" % [GameSession.session_label(), GameSession.learning_progress_text()]
    learning_badge.tooltip_text = GameSession.educational_notice()

func _style_hotspot(button: Button) -> void:
    var normal := StyleBoxFlat.new()
    normal.bg_color = Color(0.025, 0.027, 0.032, 0.90)
    normal.border_color = Color("9a6a2e")
    normal.set_border_width_all(2)
    normal.set_corner_radius_all(10)
    normal.content_margin_left = 12
    normal.content_margin_right = 12
    var hover := normal.duplicate()
    hover.bg_color = Color(0.22, 0.025, 0.035, 0.97)
    hover.border_color = Color("e0b45d")
    hover.set_border_width_all(3)
    var pressed := normal.duplicate()
    pressed.bg_color = Color(0.43, 0.035, 0.05, 0.98)
    pressed.border_color = Color("f0cf80")
    var disabled := normal.duplicate()
    disabled.bg_color = Color(0.05, 0.05, 0.055, 0.78)
    disabled.border_color = Color("554c43")
    button.add_theme_stylebox_override("normal", normal)
    button.add_theme_stylebox_override("hover", hover)
    button.add_theme_stylebox_override("pressed", pressed)
    button.add_theme_stylebox_override("disabled", disabled)
    button.add_theme_color_override("font_color", Color("f0e6d0"))
    button.add_theme_color_override("font_hover_color", Color("ffffff"))
    button.add_theme_color_override("font_disabled_color", Color("827b70"))
    button.add_theme_font_size_override("font_size", 16)

func _style_utility_button(button: Button) -> void:
    var style := StyleBoxFlat.new()
    style.bg_color = Color(0.02, 0.022, 0.026, 0.92)
    style.border_color = Color("765025")
    style.set_border_width_all(2)
    style.set_corner_radius_all(8)
    var hover := style.duplicate()
    hover.bg_color = Color(0.18, 0.025, 0.035, 0.96)
    hover.border_color = Color("c99b49")
    button.add_theme_stylebox_override("normal", style)
    button.add_theme_stylebox_override("hover", hover)
    button.add_theme_color_override("font_color", Color("e8d9bd"))
    button.mouse_default_cursor_shape = Control.CURSOR_POINTING_HAND
