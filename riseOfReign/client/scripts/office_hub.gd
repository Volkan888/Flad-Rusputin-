extends Control

@export var avatar_id: String = "ataturk"
@export var avatar_display_name: String = "Mustafa Kemal Atatürk"

@onready var http: HTTPRequest = $HTTPRequest
@onready var month_http: HTTPRequest = $MonthHTTPRequest
@onready var title_label: Label = $Margin/Layout/Header/Title
@onready var date_label: Label = $Margin/Layout/Header/Date
@onready var office_theme_label: Label = $Margin/Layout/OfficeTheme
@onready var treasury_label: Label = $Margin/Layout/TopHud/Hud/Treasury
@onready var income_label: Label = $Margin/Layout/TopHud/Hud/Income
@onready var expenses_label: Label = $Margin/Layout/TopHud/Hud/Expenses
@onready var health_label: Label = $Margin/Layout/TopHud/Hud/Health
@onready var stability_label: Label = $Margin/Layout/TopHud/Hud/Stability
@onready var authority_label: Label = $Margin/Layout/TopHud/Hud/Authority
@onready var quick_nav: HBoxContainer = $Margin/Layout/QuickNavScroll/QuickNav
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
var current_indicators: Dictionary = {}

var month_payload: Dictionary = {}
var month_request_mode: String = "load"
var selected_decisions: Dictionary = {}
var selected_phone_action: Dictionary = {}
var selected_map_action: String = ""
var january_resolved: bool = false

func _ready() -> void:
    _style_existing_buttons()
    api_base_url = str(ProjectSettings.get_setting("riseofreign/network/api_base_url", "http://127.0.0.1:8080")).trim_suffix("/")
    title_label.text = avatar_display_name
    date_label.text = "1. Januar 1933"
    room_title.text = "Steuerzentrale"
    interaction_title.text = "Lade Büro…"
    interaction_body.text = "Die Steuerzentrale wird vom riseOfReign-Server geladen."
    status_label.text = "Verbinde mit %s" % api_base_url
    _update_hud({})
    http.request_completed.connect(_on_office_request_completed)
    month_http.request_completed.connect(_on_month_request_completed)
    var error := http.request("%s/api/v1/offices/%s" % [api_base_url, avatar_id])
    if error != OK:
        _show_connection_error("HTTPRequest konnte nicht gestartet werden (%s)." % error)

func _on_back_pressed() -> void:
    AudioManager.play_click()
    get_tree().change_scene_to_file("res://scenes/avatar_select.tscn")

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
    _load_january()

func _load_january() -> void:
    month_request_mode = "load"
    status_label.text = "Lade Lagebericht Januar 1933…"
    var error := month_http.request("%s/api/v1/months/1933-01/%s" % [api_base_url, avatar_id])
    if error != OK:
        status_label.text = "Januar-Inhalt konnte nicht angefordert werden (%s)." % error

func _on_month_request_completed(_result: int, response_code: int, _headers: PackedStringArray, body: PackedByteArray) -> void:
    var text := body.get_string_from_utf8()
    var parsed = JSON.parse_string(text)
    if response_code != 200:
        var message := "HTTP %s" % response_code
        if typeof(parsed) == TYPE_DICTIONARY:
            message = str(parsed.get("error", message))
        interaction_title.text = "Monatsaktion fehlgeschlagen"
        interaction_body.text = message
        status_label.text = "Januar nicht aufgelöst"
        return
    if typeof(parsed) != TYPE_DICTIONARY:
        interaction_title.text = "Ungültige Monatsdaten"
        interaction_body.text = "Der Server hat keine gültige Januar-Antwort geliefert."
        return

    if month_request_mode == "resolve":
        _show_month_report(parsed)
        return

    month_payload = parsed
    current_indicators = month_payload.get("starting_indicators", {}).duplicate(true)
    _update_hud(current_indicators)
    status_label.text = "Januar 1933 geladen · Lagebericht bereit"
    _show_month_briefing()

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
    interaction_body.text = "Tippe einen Gegenstand oder einen Menüknopf an. Die Statusleiste bleibt wie in Grand-Strategy-Spielen immer sichtbar."
    _clear_action_list()
    if not month_payload.is_empty() and not january_resolved:
        _add_action_button("Lagebericht Januar 1933", _show_month_briefing)
        _add_action_button("Januar abschließen", _finish_january)
    elif january_resolved:
        _add_action_button("Monatsbericht Januar", _show_resolved_status)
    _add_action_button("Büro-Ausbau anzeigen", _show_upgrade_overview)

func _add_office_object(item: Dictionary, signature: bool = false) -> void:
    var button := Button.new()
    var label := str(item.get("label", item.get("id", "Objekt")))
    button.text = ("★ " if signature else "") + label
    button.custom_minimum_size = Vector2(0, 86)
    button.autowrap_mode = TextServer.AUTOWRAP_WORD_SMART
    _style_strategy_button(button)

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
    AudioManager.play_click()
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
    if route == "decision_queue" and not month_payload.is_empty() and not january_resolved:
        _show_january_decisions()
        return

    interaction_title.text = str(item.get("label", _humanize(route)))
    interaction_body.text = "Side-Menü: %s\n\n%s" % [_humanize(route), _requirement_note(item.get("requirements", {}))]
    _clear_action_list()
    _add_action_button("Öffnen / Details", _on_placeholder_action.bind(route))
    _add_action_button("Zurück zum Büro", _show_office)

func _show_phone_list() -> void:
    var phone: Dictionary = office_payload.get("phoneSystem", {})
    interaction_title.text = "Telefon"
    interaction_body.text = "Wähle eine im Januar verfügbare Kontaktgruppe. Die gewählte Aktion wird Teil deiner Monatsentscheidung."
    _clear_action_list()

    var allowed: Array = month_payload.get("phone_opportunities", []) if not month_payload.is_empty() and not january_resolved else []
    for category in phone.get("contact_categories", []):
        var category_id := str(category.get("id", ""))
        if not allowed.is_empty() and not allowed.has(category_id):
            continue
        var button := Button.new()
        button.text = str(category.get("label", category.get("id", "Kontakt")))
        button.custom_minimum_size = Vector2(0, 64)
        _style_strategy_button(button)
        button.pressed.connect(_show_phone_category.bind(category))
        action_list.add_child(button)

    _add_action_button("Auflegen / zurück", _show_office)

func _show_phone_category(category: Dictionary) -> void:
    var phone: Dictionary = office_payload.get("phoneSystem", {})
    var category_id := str(category.get("id", ""))
    interaction_title.text = "Telefon · %s" % category.get("label", _humanize(category_id))
    interaction_body.text = "Wähle die Aktion. Sie wird für die Januar-Auflösung vorgemerkt."
    _clear_action_list()

    var options = phone.get("player_contact_options", []) if category_id == "other_players" else phone.get("contact_options", [])
    for option in options:
        _add_action_button(_humanize(str(option)), _on_phone_option.bind(category_id, str(option)))

    _add_action_button("← Kontaktgruppen", _show_phone_list)

func _on_phone_option(category_id: String, option: String) -> void:
    AudioManager.play_click()
    if not january_resolved and not month_payload.is_empty():
        selected_phone_action = {"category": category_id, "option": option}
    status_label.text = "Telefon gewählt · %s · %s" % [_humanize(category_id), _humanize(option)]
    interaction_body.text = "Für Januar vorgemerkt: %s → %s" % [_humanize(category_id), _humanize(option)]
    _clear_action_list()
    _add_action_button("Zum Januar-Lagebericht", _show_month_briefing)
    _add_action_button("Andere Telefonaktion", _show_phone_list)

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
        _style_strategy_button(button)
        button.pressed.connect(_show_room_feature.bind(room, str(feature)))
        object_grid.add_child(button)

    interaction_title.text = str(room.get("label", _humanize(room_id)))
    interaction_body.text = "Zweiter Raum der Steuerzentrale. Seine Funktionen wachsen mit Amt, Geld, Macht und Aufrüstung."
    _clear_action_list()
    if room_id == "map_room" and not january_resolved and not month_payload.is_empty():
        _add_action_button("Januar-Kartenaktion wählen", _show_january_map_actions)
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
        _style_strategy_button(button)
        if required_level > current_office_level:
            button.text += " · Level %d 🔒" % required_level
            button.disabled = true
        else:
            button.pressed.connect(_open_room.bind(str(room.get("id", ""))))
        object_grid.add_child(button)

    interaction_title.text = "Weitere Räume"
    interaction_body.text = "Neue Räume werden durch Büro-Level, Amt, Staatskapazität, Aufrüstung und Ressourcen freigeschaltet."
    _clear_action_list()
    _add_action_button("← Zurück ins Büro", _show_office)

func _show_room_feature(room: Dictionary, feature: String) -> void:
    interaction_title.text = "%s · %s" % [room.get("label", "Raum"), _humanize(feature)]
    interaction_body.text = "Funktionsbereich: %s" % _humanize(feature)
    _clear_action_list()
    if str(room.get("id", "")) == "map_room" and not january_resolved and not month_payload.is_empty():
        _add_action_button("Januar-Kartenaktion wählen", _show_january_map_actions)
    else:
        _add_action_button("Aktion vorbereiten", _on_placeholder_action.bind(feature))
    _add_action_button("← Im Raum bleiben", _open_room.bind(str(room.get("id", current_room_id))))

func _show_month_briefing() -> void:
    if month_payload.is_empty():
        interaction_title.text = "Januar wird geladen"
        interaction_body.text = "Der Lagebericht ist noch nicht verfügbar."
        return
    interaction_title.text = "Lagebericht · Januar 1933"
    var context_lines: Array[String] = []
    for line in month_payload.get("shared_context", []):
        context_lines.append("• %s" % str(line))
    var body := "%s\n\n%s" % ["\n".join(context_lines), str(month_payload.get("briefing", ""))]
    var note_keys := ["month_note", "restriction_note", "humanitarian_note", "portrayal_note"]
    for key in note_keys:
        if month_payload.has(key):
            body += "\n\n%s" % str(month_payload[key])
    body += "\n\n%s" % _january_selection_summary()
    interaction_body.text = body
    _clear_action_list()
    _add_action_button("1 · Entscheidungen", _show_january_decisions)
    _add_action_button("2 · Telefon / Meeting", _show_phone_list)
    _add_action_button("3 · Weltkarte / Ressourcen", _show_january_map_actions)
    _add_action_button("4 · Januar abschließen", _finish_january)
    _add_action_button("Zurück ins Büro", _show_office)

func _show_january_decisions() -> void:
    interaction_title.text = "Januar · Entscheidungen"
    var lines: Array[String] = []
    for decision in month_payload.get("decisions", []):
        var decision_id := str(decision.get("id", ""))
        var selected := str(selected_decisions.get(decision_id, "noch offen"))
        lines.append("%s → %s" % [str(decision.get("title", decision_id)), _humanize(selected)])
    interaction_body.text = "\n".join(lines)
    _clear_action_list()
    for decision in month_payload.get("decisions", []):
        var decision_id := str(decision.get("id", ""))
        for choice in decision.get("choices", []):
            var label := "%s · %s" % [str(decision.get("title", "Entscheidung")), str(choice.get("label", choice.get("id", "Option")))]
            _add_action_button(label, _select_january_choice.bind(decision_id, str(choice.get("id", "")), str(choice.get("label", ""))))
    _add_action_button("← Lagebericht", _show_month_briefing)

func _select_january_choice(decision_id: String, choice_id: String, label: String) -> void:
    AudioManager.play_click()
    selected_decisions[decision_id] = choice_id
    status_label.text = "Entscheidung vorgemerkt · %s" % label
    _show_january_decisions()

func _show_january_map_actions() -> void:
    interaction_title.text = "Januar · Weltkarte"
    interaction_body.text = "Wähle eine Karten-/Ressourcenaktion für diesen Monat.\n\nAktuell: %s" % (_humanize(selected_map_action) if not selected_map_action.is_empty() else "noch keine")
    _clear_action_list()
    for action in month_payload.get("map_actions", []):
        _add_action_button(_humanize(str(action)), _select_january_map_action.bind(str(action)))
    _add_action_button("← Lagebericht", _show_month_briefing)

func _select_january_map_action(action: String) -> void:
    AudioManager.play_click()
    selected_map_action = action
    status_label.text = "Kartenaktion vorgemerkt · %s" % _humanize(action)
    _show_january_map_actions()

func _finish_january() -> void:
    AudioManager.play_click()
    if january_resolved:
        _show_resolved_status()
        return
    if month_payload.is_empty():
        interaction_title.text = "Januar nicht geladen"
        interaction_body.text = "Der Monatsinhalt fehlt."
        return

    var missing: Array[String] = []
    for decision in month_payload.get("decisions", []):
        if bool(decision.get("required", false)):
            var decision_id := str(decision.get("id", ""))
            if not selected_decisions.has(decision_id):
                missing.append(str(decision.get("title", decision_id)))
    if selected_phone_action.is_empty():
        missing.append("Telefon / Meeting")
    if selected_map_action.is_empty():
        missing.append("Weltkarte / Ressourcen")
    if not missing.is_empty():
        interaction_title.text = "Januar noch nicht bereit"
        interaction_body.text = "Fehlt noch:\n• %s" % "\n• ".join(missing)
        _clear_action_list()
        _add_action_button("Zum Lagebericht", _show_month_briefing)
        return

    var request_body := {
        "decision_choices": selected_decisions,
        "phone_action": selected_phone_action,
        "map_action": selected_map_action
    }
    month_request_mode = "resolve"
    status_label.text = "Januar 1933 wird aufgelöst…"
    var headers := PackedStringArray(["Content-Type: application/json"])
    var error := month_http.request(
        "%s/api/v1/months/1933-01/%s/resolve" % [api_base_url, avatar_id],
        headers,
        HTTPClient.METHOD_POST,
        JSON.stringify(request_body)
    )
    if error != OK:
        status_label.text = "Monatsauflösung konnte nicht gestartet werden (%s)." % error

func _show_month_report(result: Dictionary) -> void:
    january_resolved = true
    date_label.text = "1. Februar 1933"
    var returned_level = result.get("office_level", null)
    if typeof(returned_level) in [TYPE_INT, TYPE_FLOAT]:
        current_office_level = int(returned_level)
        office_theme_label.text = "%s · Büro-Level %d" % [str(avatar_office.get("start_location", "1933")), current_office_level]

    interaction_title.text = "Monatsbericht · Januar 1933"
    var lines: Array[String] = [str(result.get("report", "Januar abgeschlossen.")), "", "Stand zum 1. Februar 1933:"]
    var indicators: Dictionary = result.get("resulting_indicators", {})
    current_indicators = indicators.duplicate(true)
    _update_hud(current_indicators)
    var keys := indicators.keys()
    keys.sort()
    for key in keys:
        lines.append("• %s: %s" % [_humanize(str(key)), str(indicators[key])])
    interaction_body.text = "\n".join(lines)
    status_label.text = "Januar abgeschlossen · Februar 1933 vorbereitet"
    _clear_action_list()
    _add_action_button("Zurück ins Büro", _show_office)

func _show_resolved_status() -> void:
    interaction_title.text = "Februar 1933"
    interaction_body.text = "Der Januar ist abgeschlossen. Das Büro zeigt bereits den neuen Zeitstand; der vollständige Februar-Content ist der nächste Monatsbaustein."
    _clear_action_list()
    _add_action_button("Zurück ins Büro", _show_office)

func _january_selection_summary() -> String:
    var decision_count := selected_decisions.size()
    var phone_text := "offen" if selected_phone_action.is_empty() else "%s / %s" % [_humanize(str(selected_phone_action.get("category", ""))), _humanize(str(selected_phone_action.get("option", "")))]
    var map_text := "offen" if selected_map_action.is_empty() else _humanize(selected_map_action)
    return "Monatsplan: Entscheidungen %d · Telefon %s · Karte %s" % [decision_count, phone_text, map_text]

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

func _on_nav_office() -> void:
    AudioManager.play_click()
    _show_office()

func _on_nav_world() -> void:
    AudioManager.play_click()
    _open_room("map_room")

func _on_nav_phone() -> void:
    AudioManager.play_click()
    _show_phone_list()

func _on_nav_decisions() -> void:
    AudioManager.play_click()
    if not month_payload.is_empty() and not january_resolved:
        _show_january_decisions()
    else:
        _show_named_panel("Entscheidungen", "Aktuell sind keine offenen Monatsentscheidungen vorhanden.")

func _on_nav_inventory() -> void:
    AudioManager.play_click()
    var items: Array[String] = []
    for item in avatar_office.get("personal_objects", []):
        items.append("• %s" % str(item))
    var signature = avatar_office.get("signature_object", {})
    if typeof(signature) == TYPE_DICTIONARY and not signature.is_empty():
        items.push_front("★ %s" % str(signature.get("label", signature.get("id", "Spezialobjekt"))))
    if items.is_empty():
        items.append("• Noch keine persönlichen Gegenstände erfasst")
    _show_named_panel("Inventar · %s" % avatar_display_name, "Persönliche Gegenstände und wichtige Dokumente:\n\n%s\n\nStaatseigentum wird getrennt vom persönlichen Inventar geführt." % "\n".join(items))

func _on_nav_archive() -> void:
    AudioManager.play_click()
    _show_side_menu({"label":"Aktenarchiv", "opens":"archive"})

func _on_nav_research() -> void:
    AudioManager.play_click()
    var value = current_indicators.get("research", "—")
    _show_named_panel("Forschung", "Aktueller Forschungswert: %s\n\nProjekte, Forscher und gemeinsame Forschung werden hier verbunden." % str(value))

func _on_nav_diplomacy() -> void:
    AudioManager.play_click()
    var value = current_indicators.get("diplomacy", "—")
    _show_named_panel("Diplomatie", "Aktueller Diplomatie-Wert: %s\n\nVerträge, Beziehungen, Meetings und andere Spieler werden hier gebündelt." % str(value))

func _on_nav_economy() -> void:
    AudioManager.play_click()
    var lines: Array[String] = []
    for key in ["treasury", "food", "industry", "infrastructure", "research", "stability"]:
        lines.append("• %s: %s" % [_humanize(key), str(current_indicators.get(key, "—"))])
    _show_named_panel("Wirtschaft & Staatsvermögen", "%s\n\nEinnahmen, Ausgaben, Reserven, Staatsbesitz und Schulden werden als eigene Monatsabrechnung ergänzt." % "\n".join(lines))

func _on_nav_military() -> void:
    AudioManager.play_click()
    _show_side_menu({"label":"Militär", "opens":"basic_military"})

func _on_nav_events() -> void:
    AudioManager.play_click()
    if not month_payload.is_empty():
        _show_month_briefing()
    else:
        _show_named_panel("Ereignisse", "Ereignisse werden geladen.")

func _on_nav_settings() -> void:
    AudioManager.play_click()
    _show_audio_settings_panel()

func _show_audio_settings_panel() -> void:
    interaction_title.text = "Einstellungen · Audio"
    interaction_body.text = "Gesamt: %d%%\nMusik: %d%% · %s\nEffekte: %d%% · %s" % [
        int(AudioManager.master_volume * 100.0),
        int(AudioManager.music_volume * 100.0),
        "AN" if AudioManager.music_enabled else "AUS",
        int(AudioManager.sfx_volume * 100.0),
        "AN" if AudioManager.sfx_enabled else "AUS"
    ]
    _clear_action_list()
    _add_action_button("Gesamt +10%", _adjust_master.bind(0.1))
    _add_action_button("Gesamt -10%", _adjust_master.bind(-0.1))
    _add_action_button("Musik an/aus", _toggle_music)
    _add_action_button("Effekte an/aus", _toggle_sfx)
    _add_action_button("Zum Hauptmenü", _go_to_main_menu)
    _add_action_button("Zurück zum Büro", _show_office)

func _adjust_master(delta: float) -> void:
    AudioManager.set_master_volume(clampf(AudioManager.master_volume + delta, 0.0, 1.0))
    AudioManager.play_click()
    _show_audio_settings_panel()

func _toggle_music() -> void:
    AudioManager.set_music_enabled(not AudioManager.music_enabled)
    _show_audio_settings_panel()

func _toggle_sfx() -> void:
    AudioManager.set_sfx_enabled(not AudioManager.sfx_enabled)
    AudioManager.play_click()
    _show_audio_settings_panel()

func _go_to_main_menu() -> void:
    get_tree().change_scene_to_file("res://scenes/main.tscn")

func _show_named_panel(title: String, body: String) -> void:
    interaction_title.text = title
    interaction_body.text = body
    _clear_action_list()
    _add_action_button("Zurück zum Büro", _show_office)

func _update_hud(indicators: Dictionary) -> void:
    treasury_label.text = "STAATSKASSE\n%s" % _format_hud_value(indicators.get("treasury", null), "RP")
    income_label.text = "EINNAHMEN\n%s" % _format_hud_value(indicators.get("monthly_income", null), "RP")
    expenses_label.text = "AUSGABEN\n%s" % _format_hud_value(indicators.get("monthly_expenses", null), "RP")
    health_label.text = "GESUNDHEIT\n%s" % _format_hud_value(indicators.get("health", null), "%")
    stability_label.text = "STABILITÄT\n%s" % _format_hud_value(indicators.get("stability", null), "%")
    authority_label.text = "AUTORITÄT\n%s" % _format_hud_value(indicators.get("authority", null), "%")

func _format_hud_value(value, suffix: String) -> String:
    if value == null:
        return "—"
    return "%s %s" % [str(value), suffix]

func _on_placeholder_action(route: String) -> void:
    AudioManager.play_click()
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
    _style_strategy_button(button)
    button.pressed.connect(callback)
    action_list.add_child(button)

func _style_existing_buttons() -> void:
    _style_strategy_button($Margin/Layout/Header/Back)
    for child in quick_nav.get_children():
        if child is Button:
            _style_strategy_button(child)

func _style_strategy_button(button: Button) -> void:
    var normal := StyleBoxFlat.new()
    normal.bg_color = Color("121212")
    normal.border_color = Color("5c0a10")
    normal.set_border_width_all(2)
    normal.corner_radius_top_left = 3
    normal.corner_radius_top_right = 3
    normal.corner_radius_bottom_left = 3
    normal.corner_radius_bottom_right = 3

    var hover := normal.duplicate()
    hover.bg_color = Color("28080c")
    hover.border_color = Color("a61923")

    var pressed := normal.duplicate()
    pressed.bg_color = Color("4b0a10")
    pressed.border_color = Color("d53b46")

    button.add_theme_stylebox_override("normal", normal)
    button.add_theme_stylebox_override("hover", hover)
    button.add_theme_stylebox_override("pressed", pressed)
    button.add_theme_color_override("font_color", Color("e5dece"))
    button.add_theme_color_override("font_hover_color", Color("ffffff"))

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
