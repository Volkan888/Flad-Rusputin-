extends Control

@export var avatar_id: String = "ataturk"
@export var avatar_display_name: String = "Mustafa Kemal Atatürk"

@onready var http: HTTPRequest = $HTTPRequest
@onready var title_label: Label = $Margin/Layout/Header/Title
@onready var date_label: Label = $Margin/Layout/Header/Date
@onready var office_theme_label: Label = $Margin/Layout/OfficeTheme
@onready var room_title: Label = $Margin/Layout/Content/OfficePanel/OfficeLayout/RoomTitle
@onready var object_grid: GridContainer = $Margin/Layout/Content/OfficePanel/OfficeLayout/ObjectScroll/ObjectGrid
@onready var interaction_title: Label = $Margin/Layout/Content/InteractionPanel/InteractionLayout/InteractionTitle
@onready var interaction_body: RichTextLabel = $Margin/Layout/Content/InteractionPanel/InteractionLayout/InteractionBody
@onready var action_list: VBoxContainer = $Margin/Layout/Content/InteractionPanel/InteractionLayout/ActionScroll/ActionList
@onready var status_label: Label = $Margin/Layout/Status

var api_base_url: String
var office_payload: Dictionary = {}
var avatar_office: Dictionary = {}
var current_office_level: int = 0
var current_room_id: String = "office"

func _ready() -> void:
    api_base_url = str(ProjectSettings.get_setting("riseofreign/network/api_base_url", "http://127.0.0.1:8080")).trim_suffix("/")
    title_label.text = avatar_display_name
    date_label.text = "1. Januar 1933"
    room_title.text = "Steuerzentrale"
    interaction_title.text = "Lade Büro…"
    interaction_body.text = "Die Steuerzentrale wird vom riseOfReign-Server geladen."
    status_label.text = "Verbinde mit %s" % api_base_url
    http.request_completed.connect(_on_office_request_completed)
    var error := http.request("%s/api/v1/offices/%s" % [api_base_url, avatar_id])
    if error != OK:
        _show_connection_error("HTTPRequest konnte nicht gestartet werden (%s)." % error)

func _on_back_pressed() -> void:
    get_tree().change_scene_to_file("res://scenes/main.tscn")

func _on_office_request_completed(_result: int, response_code: int, _headers: PackedStringArray, body: PackedByteArray) -> void:
    if response_code != 200:
        _show_connection_error("Bürodaten konnten nicht geladen werden. HTTP %s" % response_code)
        return

    var parsed = JSON.parse_string(body.get_string_from_utf8())
    if typeof(parsed) != TYPE_DICTIONARY:
        _show_connection_error("Ungültige Bürodaten vom Server.")
        return

    office_payload = parsed
    avatar_office = office_payload.get("avatarOffice", {})
    var start_level = avatar_office.get("start_level", 0)
    current_office_level = int(start_level) if typeof(start_level) in [TYPE_INT, TYPE_FLOAT] else 0

    office_theme_label.text = "%s · Büro-Level %d" % [str(avatar_office.get("start_location", "1933")), current_office_level]
    status_label.text = "Büro geladen · %s" % avatar_display_name
    _show_office()

func _show_connection_error(message: String) -> void:
    interaction_title.text = "Keine Serververbindung"
    interaction_body.text = "%s\n\nStarte die riseOfReign-API oder passe riseofreign/network/api_base_url an." % message
    status_label.text = "Offline · Büro nicht geladen"
    _clear_action_list()
    _add_action_button("Zur Avatar-Auswahl", _on_back_pressed)

func _show_office() -> void:
    current_room_id = "office"
    room_title.text = "Steuerzentrale · Level %d" % current_office_level
    _clear_object_grid()

    for item in office_payload.get("sharedObjects", []):
        _add_office_object(item)

    var signature = avatar_office.get("signature_object", {})
    if typeof(signature) == TYPE_DICTIONARY and not signature.is_empty():
        _add_office_object(signature, true)

    interaction_title.text = "Dein Büro"
    interaction_body.text = "Tippe einen Gegenstand an. Jede Interaktion führt ausschließlich zu einem Side-Menü, einem zweiten Raum oder einer Telefonliste."
    _clear_action_list()
    _add_action_button("Büro-Ausbau anzeigen", _show_upgrade_overview)

func _add_office_object(item: Dictionary, signature: bool = false) -> void:
    var button := Button.new()
    var label := str(item.get("label", item.get("id", "Objekt")))
    button.text = ("★ " if signature else "") + label
    button.custom_minimum_size = Vector2(0, 86)
    button.autowrap_mode = TextServer.AUTOWRAP_WORD_SMART

    var requirement = item.get("requirements", {})
    var required_level := int(requirement.get("office_level", 0)) if typeof(requirement) == TYPE_DICTIONARY else 0
    if required_level > current_office_level:
        button.text += " 🔒"
        button.disabled = true
        button.tooltip_text = "Benötigt Büro-Level %d" % required_level
    else:
        button.pressed.connect(_on_object_pressed.bind(item))
        if typeof(requirement) == TYPE_DICTIONARY and not requirement.is_empty():
            button.tooltip_text = "Weitere Freischaltung hängt vom Spielzustand ab."

    object_grid.add_child(button)

func _on_object_pressed(item: Dictionary) -> void:
    var interaction := str(item.get("interaction", "side_menu"))
    match interaction:
        "side_menu":
            _show_side_menu(item)
        "phone_list":
            _show_phone_list()
        "room":
            _open_room(str(item.get("opens", "room_selector")))
        _:
            interaction_title.text = "Nicht unterstützte Interaktion"
            interaction_body.text = "%s ist noch nicht an einen gültigen Bedienweg gebunden." % item.get("label", item.get("id", "Objekt"))

func _show_side_menu(item: Dictionary) -> void:
    var route := str(item.get("opens", ""))
    interaction_title.text = str(item.get("label", _humanize(route)))
    interaction_body.text = "Side-Menü: %s\n\n%s" % [_humanize(route), _requirement_note(item.get("requirements", {}))]
    _clear_action_list()
    _add_action_button("Öffnen / Details", _on_placeholder_action.bind(route))
    _add_action_button("Zurück zum Büro", _show_office)

func _show_phone_list() -> void:
    var phone: Dictionary = office_payload.get("phoneSystem", {})
    interaction_title.text = "Telefon"
    interaction_body.text = "Wähle, wen du anrufen möchtest. Kontakte werden später dynamisch aus Amt, Beziehungen, Ereignissen und Geheimdienstwissen erzeugt."
    _clear_action_list()

    for category in phone.get("contact_categories", []):
        var button := Button.new()
        button.text = str(category.get("label", category.get("id", "Kontakt")))
        button.custom_minimum_size = Vector2(0, 64)
        button.pressed.connect(_show_phone_category.bind(category))
        action_list.add_child(button)

    _add_action_button("Auflegen / zurück", _show_office)

func _show_phone_category(category: Dictionary) -> void:
    var phone: Dictionary = office_payload.get("phoneSystem", {})
    var category_id := str(category.get("id", ""))
    interaction_title.text = "Telefon · %s" % category.get("label", _humanize(category_id))
    interaction_body.text = "Mögliche Aktionen für diese Kontaktgruppe. Erreichbarkeit, sichere Leitung und Autorität werden serverseitig geprüft."
    _clear_action_list()

    var options = phone.get("player_contact_options", []) if category_id == "other_players" else phone.get("contact_options", [])
    for option in options:
        _add_action_button(_humanize(str(option)), _on_phone_option.bind(category_id, str(option)))

    _add_action_button("← Kontaktgruppen", _show_phone_list)

func _on_phone_option(category_id: String, option: String) -> void:
    status_label.text = "Telefon · %s · %s" % [_humanize(category_id), _humanize(option)]
    interaction_body.text = "Ausgewählt: %s\n\nIm nächsten Meilenstein wird daraus eine echte Kontakt-/Meeting-/Vertragsaktion." % _humanize(option)

func _open_room(room_id: String) -> void:
    if room_id == "room_selector":
        _show_room_selector()
        return

    var room := _find_room(room_id)
    if room.is_empty():
        interaction_title.text = "Raum nicht gefunden"
        interaction_body.text = "Die Route '%s' ist nicht definiert." % room_id
        return

    var required_level := int(room.get("required_office_level", 0))
    if required_level > current_office_level:
        interaction_title.text = "Raum gesperrt"
        interaction_body.text = "%s benötigt Büro-Level %d. Dein aktuelles Level ist %d." % [room.get("label", room_id), required_level, current_office_level]
        _clear_action_list()
        _add_action_button("Zurück zum Büro", _show_office)
        return

    current_room_id = room_id
    room_title.text = str(room.get("label", _humanize(room_id)))
    _clear_object_grid()

    for feature in room.get("opens", []):
        var button := Button.new()
        button.text = _humanize(str(feature))
        button.custom_minimum_size = Vector2(0, 86)
        button.pressed.connect(_show_room_feature.bind(room, str(feature)))
        object_grid.add_child(button)

    interaction_title.text = str(room.get("label", _humanize(room_id)))
    interaction_body.text = "Zweiter Raum der Steuerzentrale. Seine Funktionen wachsen mit Amt, Geld, Macht und Aufrüstung."
    _clear_action_list()
    _add_action_button("← Zurück ins Büro", _show_office)

func _show_room_selector() -> void:
    current_room_id = "room_selector"
    room_title.text = "Raumauswahl"
    _clear_object_grid()

    for room in office_payload.get("rooms", []):
        if str(room.get("id", "")) == "room_selector":
            continue
        var button := Button.new()
        var required_level := int(room.get("required_office_level", 0))
        button.text = str(room.get("label", room.get("id", "Raum")))
        button.custom_minimum_size = Vector2(0, 86)
        if required_level > current_office_level:
            button.text += " · Level %d 🔒" % required_level
            button.disabled = true
        else:
            button.pressed.connect(_open_room.bind(str(room.get("id", ""))))
        object_grid.add_child(button)

    interaction_title.text = "Weitere Räume"
    interaction_body.text = "Neue Räume werden nicht nur gekauft: Büro-Level, Amt, Staatskapazität, Aufrüstung und Ressourcen bestimmen, was verfügbar ist."
    _clear_action_list()
    _add_action_button("← Zurück ins Büro", _show_office)

func _show_room_feature(room: Dictionary, feature: String) -> void:
    interaction_title.text = "%s · %s" % [room.get("label", "Raum"), _humanize(feature)]
    interaction_body.text = "Funktionsbereich: %s\n\nDieser Platzhalter wird mit dem jeweiligen Wirtschaft-, Militär-, Forschungs-, Diplomatie- oder Kartenmodul verbunden." % _humanize(feature)
    _clear_action_list()
    _add_action_button("Aktion vorbereiten", _on_placeholder_action.bind(feature))
    _add_action_button("← Im Raum bleiben", _open_room.bind(str(room.get("id", current_room_id))))

func _show_upgrade_overview() -> void:
    interaction_title.text = "Büro-Ausbau"
    var lines: Array[String] = []
    for level in office_payload.get("officeLevels", []):
        var number := int(level.get("level", 0))
        var lock := "✓" if number <= current_office_level else "🔒"
        lines.append("%s Level %d · %s · Bauzeit %d Monate" % [lock, number, level.get("name", ""), int(level.get("build_months", 0))])
    interaction_body.text = "\n".join(lines)
    _clear_action_list()
    _add_action_button("Zurück zum Büro", _show_office)

func _on_placeholder_action(route: String) -> void:
    status_label.text = "Vorbereitet · %s" % _humanize(route)

func _find_room(room_id: String) -> Dictionary:
    for room in office_payload.get("rooms", []):
        if str(room.get("id", "")) == room_id:
            return room
    return {}

func _clear_object_grid() -> void:
    for child in object_grid.get_children():
        child.queue_free()

func _clear_action_list() -> void:
    for child in action_list.get_children():
        child.queue_free()

func _add_action_button(label: String, callback: Callable) -> void:
    var button := Button.new()
    button.text = label
    button.custom_minimum_size = Vector2(0, 60)
    button.autowrap_mode = TextServer.AUTOWRAP_WORD_SMART
    button.pressed.connect(callback)
    action_list.add_child(button)

func _requirement_note(requirements) -> String:
    if typeof(requirements) != TYPE_DICTIONARY or requirements.is_empty():
        return "Keine zusätzlichen Voraussetzungen."
    var parts: Array[String] = []
    for key in requirements:
        parts.append("%s: %s" % [_humanize(str(key)), str(requirements[key])])
    return "Voraussetzungen: " + ", ".join(parts)

func _humanize(value: String) -> String:
    var text := value.replace("_", " ").strip_edges()
    if text.is_empty():
        return "Aktion"
    return text.substr(0, 1).to_upper() + text.substr(1)
