extends Control

const CONTENT_PATH := "res://assets/events/flad_rasputin_prologue.json"
const SAVE_PATH := "user://flad_rasputin_prologue.json"
const OFFICE_SCENE = preload("res://scenes/office_hub.tscn")
const FLAD_PORTRAIT = preload("res://assets/portraits/flad_rasputin.svg")
const COMPANION_ICON = preload("res://assets/icons/profile.svg")
const ITEM_ICON = preload("res://assets/icons/archive.svg")

const STAGE_TEXTURES := {
    "geburt": preload("res://assets/rooms/meeting_room.svg"),
    "kindheit": preload("res://assets/rooms/archive_room.svg"),
    "jugend": preload("res://assets/rooms/communications_room.svg"),
    "netzwerk": preload("res://assets/rooms/meeting_room.svg"),
    "inventar": preload("res://assets/rooms/archive_room.svg"),
    "krise": preload("res://assets/rooms/communications_room.svg"),
    "büro": preload("res://assets/rooms/office_command.svg"),
    "übergabe": preload("res://assets/rooms/office_command.svg")
}

@onready var background_image: TextureRect = $BackgroundImage
@onready var back_button: Button = $MainMargin/Layout/Header/Back
@onready var stage_label: Label = $MainMargin/Layout/Header/TitleBlock/Stage
@onready var era_label: Label = $MainMargin/Layout/Header/TitleBlock/Era
@onready var progress_bar: ProgressBar = $MainMargin/Layout/Header/ProgressBlock/Progress
@onready var progress_text: Label = $MainMargin/Layout/Header/ProgressBlock/ProgressText
@onready var portrait: TextureRect = $MainMargin/Layout/Body/LeftPanel/LeftLayout/PortraitFrame/Portrait
@onready var origin_label: Label = $MainMargin/Layout/Body/LeftPanel/LeftLayout/Origin
@onready var stats_label: RichTextLabel = $MainMargin/Layout/Body/LeftPanel/LeftLayout/Stats
@onready var traits_flow: HFlowContainer = $MainMargin/Layout/Body/LeftPanel/LeftLayout/TraitsScroll/TraitsFlow
@onready var event_image: TextureRect = $MainMargin/Layout/Body/EventPanel/EventLayout/EventImage
@onready var event_title: Label = $MainMargin/Layout/Body/EventPanel/EventLayout/EventTitle
@onready var event_body: RichTextLabel = $MainMargin/Layout/Body/EventPanel/EventLayout/EventBody
@onready var question_label: Label = $MainMargin/Layout/Body/EventPanel/EventLayout/Question
@onready var choices_list: VBoxContainer = $MainMargin/Layout/Body/EventPanel/EventLayout/ChoicesScroll/Choices
@onready var impact_label: RichTextLabel = $MainMargin/Layout/Body/RightPanel/RightLayout/Impact
@onready var items_flow: VBoxContainer = $MainMargin/Layout/Body/RightPanel/RightLayout/ItemsScroll/ItemsFlow
@onready var companions_flow: VBoxContainer = $MainMargin/Layout/Body/RightPanel/RightLayout/CompanionsScroll/CompanionsFlow
@onready var history_label: RichTextLabel = $MainMargin/Layout/Body/RightPanel/RightLayout/History
@onready var reset_button: Button = $MainMargin/Layout/Footer/Reset
@onready var status_label: Label = $MainMargin/Layout/Footer/Status

var content: Dictionary = {}
var events: Array = []
var profile: Dictionary = {}
var current_index: int = 0
var completed: bool = false
var history: Array = []
var current_event_id: String = ""

func _ready() -> void:
    portrait.texture = FLAD_PORTRAIT
    _style_button(back_button)
    _style_button(reset_button)
    back_button.pressed.connect(_on_back_pressed)
    reset_button.pressed.connect(_reset_prologue)
    if not _load_content():
        return
    _load_or_initialize()
    _render()

func _load_content() -> bool:
    var file: FileAccess = FileAccess.open(CONTENT_PATH, FileAccess.READ)
    if file == null:
        _fatal("Die Geburts- und Biografie-Events konnten nicht geladen werden.")
        return false
    var parsed: Variant = JSON.parse_string(file.get_as_text())
    if typeof(parsed) != TYPE_DICTIONARY:
        _fatal("Die Prologdaten sind ungültig.")
        return false
    content = (parsed as Dictionary).duplicate(true)
    var loaded_events: Variant = content.get("events", [])
    if typeof(loaded_events) != TYPE_ARRAY:
        _fatal("Die Prologdaten enthalten keine Eventkette.")
        return false
    events = (loaded_events as Array).duplicate(true)
    return not events.is_empty()

func _load_or_initialize() -> void:
    var loaded: bool = false
    if FileAccess.file_exists(SAVE_PATH):
        var file: FileAccess = FileAccess.open(SAVE_PATH, FileAccess.READ)
        if file != null:
            var parsed: Variant = JSON.parse_string(file.get_as_text())
            if typeof(parsed) == TYPE_DICTIONARY:
                var save_data: Dictionary = parsed as Dictionary
                var saved_profile: Variant = save_data.get("profile", {})
                var saved_history: Variant = save_data.get("history", [])
                if typeof(saved_profile) == TYPE_DICTIONARY:
                    profile = (saved_profile as Dictionary).duplicate(true)
                    current_index = clampi(int(save_data.get("current_index", 0)), 0, events.size())
                    completed = bool(save_data.get("completed", false))
                    history = (saved_history as Array).duplicate(true) if typeof(saved_history) == TYPE_ARRAY else []
                    loaded = true
    if not loaded:
        var base_value: Variant = content.get("base_profile", {})
        profile = (base_value as Dictionary).duplicate(true) if typeof(base_value) == TYPE_DICTIONARY else {}
        current_index = 0
        completed = false
        history = []
        _save()
    GameSession.start_flad_solo()
    GameSession.set_flad_prologue_progress(current_index, profile, completed)

func _render() -> void:
    _refresh_profile()
    if completed or current_index >= events.size():
        _show_summary()
        return
    var event_value: Variant = events[current_index]
    if typeof(event_value) != TYPE_DICTIONARY:
        _fatal("Ein Biografie-Event ist ungültig.")
        return
    var event: Dictionary = event_value as Dictionary
    current_event_id = str(event.get("id", ""))
    var stage: String = str(event.get("stage", "geburt"))
    var texture_value: Variant = STAGE_TEXTURES.get(stage, STAGE_TEXTURES["geburt"])
    if texture_value is Texture2D:
        background_image.texture = texture_value
        event_image.texture = texture_value
    stage_label.text = str(event.get("stage_label", "BIOGRAFIE"))
    era_label.text = str(event.get("era", ""))
    event_title.text = str(event.get("title", "Ereignis"))
    event_body.text = "%s\n\n[color=#b8a98b]LERNHINWEIS[/color]\n%s" % [str(event.get("body", "")), str(event.get("learning", ""))]
    question_label.text = str(event.get("question", "Wie entscheidest du?"))
    progress_bar.value = float(current_index) / float(maxi(1, events.size())) * 100.0
    progress_text.text = "EVENT %d / %d" % [current_index + 1, events.size()]
    _clear(choices_list)
    var choices_value: Variant = event.get("choices", [])
    if typeof(choices_value) == TYPE_ARRAY:
        for choice_value: Variant in choices_value as Array:
            if typeof(choice_value) != TYPE_DICTIONARY:
                continue
            var choice: Dictionary = choice_value as Dictionary
            var button: Button = Button.new()
            button.text = "%s\n%s\n%s" % [str(choice.get("label", "Option")), str(choice.get("description", "")), _effect_preview(choice)]
            button.custom_minimum_size = Vector2(0, 96)
            button.autowrap_mode = TextServer.AUTOWRAP_WORD_SMART
            button.alignment = HORIZONTAL_ALIGNMENT_LEFT
            _style_button(button)
            button.pressed.connect(_choose_event.bind(choice.duplicate(true)))
            choices_list.add_child(button)
    status_label.text = "AUTOSAVE · BIOGRAFIE, INVENTAR UND VERTRAUTE WERDEN NACH JEDER ANTWORT GESPEICHERT"

func _choose_event(choice: Dictionary) -> void:
    AudioManager.play_click()
    var event_value: Variant = events[current_index]
    if typeof(event_value) != TYPE_DICTIONARY:
        return
    var event: Dictionary = event_value as Dictionary
    _apply_choice(choice)
    history.append({
        "event_id": str(event.get("id", "")),
        "title": str(event.get("title", "")),
        "choice_id": str(choice.get("id", "")),
        "choice_label": str(choice.get("label", "")),
        "result": str(choice.get("result", ""))
    })
    current_index += 1
    completed = current_index >= events.size()
    _save()
    _refresh_profile()
    event_title.text = "ENTSCHEIDUNG GESPEICHERT"
    event_body.text = "%s\n\n[color=#d7b46a]%s[/color]" % [str(choice.get("result", "")), _effect_preview(choice)]
    question_label.text = "Dein Profil wurde aktualisiert."
    progress_bar.value = float(current_index) / float(maxi(1, events.size())) * 100.0
    progress_text.text = "EVENT %d / %d ABGESCHLOSSEN" % [current_index, events.size()]
    _clear(choices_list)
    var next_button: Button = Button.new()
    next_button.text = "PROLOG ABSCHLIESSEN" if completed else "WEITER ZUM NÄCHSTEN EVENT"
    next_button.custom_minimum_size = Vector2(0, 78)
    _style_primary(next_button)
    next_button.pressed.connect(_render)
    choices_list.add_child(next_button)

func _apply_choice(choice: Dictionary) -> void:
    var stats_value: Variant = profile.get("stats", {})
    var stats: Dictionary = (stats_value as Dictionary).duplicate(true) if typeof(stats_value) == TYPE_DICTIONARY else {}
    var effects_value: Variant = choice.get("effects", {})
    if typeof(effects_value) == TYPE_DICTIONARY:
        var effects: Dictionary = effects_value as Dictionary
        for key_value: Variant in effects.keys():
            var key: String = str(key_value)
            stats[key] = clampi(int(stats.get(key, 0)) + int(effects.get(key_value, 0)), 0, 100)
    profile["stats"] = stats

    var birth_value: Variant = profile.get("birth", {})
    var birth: Dictionary = (birth_value as Dictionary).duplicate(true) if typeof(birth_value) == TYPE_DICTIONARY else {}
    var life_value: Variant = profile.get("life", {})
    var life: Dictionary = (life_value as Dictionary).duplicate(true) if typeof(life_value) == TYPE_DICTIONARY else {}
    var set_value: Variant = choice.get("set", {})
    if typeof(set_value) == TYPE_DICTIONARY:
        var set_data: Dictionary = set_value as Dictionary
        for key_value: Variant in set_data.keys():
            var key: String = str(key_value)
            if key.begins_with("birth") or key == "family_origin":
                birth[key] = set_data.get(key_value)
            else:
                life[key] = set_data.get(key_value)
    profile["birth"] = birth
    profile["life"] = life
    profile["traits"] = _merge_unique(profile.get("traits", []), choice.get("traits", []))
    profile["items"] = _merge_unique(profile.get("items", []), choice.get("items", []))
    profile["companions"] = _merge_unique(profile.get("companions", []), choice.get("companions", []))
    var answers_value: Variant = profile.get("answers", {})
    var answers: Dictionary = (answers_value as Dictionary).duplicate(true) if typeof(answers_value) == TYPE_DICTIONARY else {}
    answers[current_event_id] = str(choice.get("id", ""))
    profile["answers"] = answers

func _merge_unique(existing_value: Variant, additions_value: Variant) -> Array:
    var result: Array = (existing_value as Array).duplicate(true) if typeof(existing_value) == TYPE_ARRAY else []
    if typeof(additions_value) == TYPE_ARRAY:
        for value: Variant in additions_value as Array:
            if not result.has(value):
                result.append(value)
    return result

func _show_summary() -> void:
    completed = true
    current_index = events.size()
    profile["completed"] = true
    _save()
    _refresh_profile()
    background_image.texture = STAGE_TEXTURES["übergabe"]
    event_image.texture = STAGE_TEXTURES["übergabe"]
    stage_label.text = "PROLOG ABGESCHLOSSEN"
    era_label.text = "ÜBERGABE · 1. JANUAR 1933"
    progress_bar.value = 100.0
    progress_text.text = "%d / %d EVENTS" % [events.size(), events.size()]
    event_title.text = "FLAD RASPUTIN IST SPIELBEREIT"
    event_body.text = _summary_text()
    question_label.text = "Deine Geburt, Biografie, Items und Vertrauten bleiben gespeichert."
    _clear(choices_list)
    var office_button: Button = Button.new()
    office_button.text = "AM 1. JANUAR 1933 INS BÜRO"
    office_button.custom_minimum_size = Vector2(0, 84)
    _style_primary(office_button)
    office_button.pressed.connect(_enter_office)
    choices_list.add_child(office_button)
    var restart_button: Button = Button.new()
    restart_button.text = "BIOGRAFIE NEU BEGINNEN"
    restart_button.custom_minimum_size = Vector2(0, 62)
    _style_button(restart_button)
    restart_button.pressed.connect(_reset_prologue)
    choices_list.add_child(restart_button)

func _summary_text() -> String:
    var birth_value: Variant = profile.get("birth", {})
    var birth: Dictionary = birth_value as Dictionary if typeof(birth_value) == TYPE_DICTIONARY else {}
    var life_value: Variant = profile.get("life", {})
    var life: Dictionary = life_value as Dictionary if typeof(life_value) == TYPE_DICTIONARY else {}
    var birth_year: int = int(birth.get("birth_year", 1898))
    var traits: Array = profile.get("traits", []) as Array if typeof(profile.get("traits", [])) == TYPE_ARRAY else []
    var items: Array = profile.get("items", []) as Array if typeof(profile.get("items", [])) == TYPE_ARRAY else []
    var companions: Array = profile.get("companions", []) as Array if typeof(profile.get("companions", [])) == TYPE_ARRAY else []
    return (
        "[font_size=26][color=#ead9b1]FLAD RASPUTIN[/color][/font_size]\n\n"
        + "Geboren: %d in %s · Alter 1933: %d\n" % [birth_year, str(birth.get("birthplace", "offen")), 1933 - birth_year]
        + "Herkunft: %s\n" % str(birth.get("family_origin", "offen"))
        + "Bildung: %s\n" % str(life.get("education_path", "offen"))
        + "Erste Arbeit: %s\n" % str(life.get("first_work", "offen"))
        + "Erstes Büro: %s\n" % str(life.get("office_origin", "offen"))
        + "Schwerpunkt 1933: %s\n\n" % str(life.get("1933_focus", "offen"))
        + "Eigenschaften: %s\n" % ", ".join(_humanized(traits))
        + "Inventar: %s\n" % ", ".join(_item_labels(items))
        + "Vertraute: %s" % ", ".join(_companion_labels(companions))
    )

func _refresh_profile() -> void:
    var birth_value: Variant = profile.get("birth", {})
    var birth: Dictionary = birth_value as Dictionary if typeof(birth_value) == TYPE_DICTIONARY else {}
    var birth_year: int = int(birth.get("birth_year", 0))
    origin_label.text = "%s · %s%s" % [
        str(birth.get("birthplace", "Geburtsort noch offen")),
        str(birth.get("birth_region", "Herkunft wird aufgebaut")),
        (" · %d Jahre 1933" % (1933 - birth_year)) if birth_year > 0 else ""
    ]
    var stats_value: Variant = profile.get("stats", {})
    var stats: Dictionary = stats_value as Dictionary if typeof(stats_value) == TYPE_DICTIONARY else {}
    var stat_lines: Array[String] = ["[color=#d7b46a]STATUSWERTE[/color]"]
    for key: String in ["health", "energy", "education", "discipline", "empathy", "courage", "charisma", "network", "wealth", "stress", "influence"]:
        stat_lines.append("%s: %d" % [_humanize(key), int(stats.get(key, 0))])
    stats_label.text = "\n".join(stat_lines)

    _clear(traits_flow)
    var traits_value: Variant = profile.get("traits", [])
    if typeof(traits_value) == TYPE_ARRAY:
        for value: Variant in traits_value as Array:
            traits_flow.add_child(_chip(_humanize(str(value)), null))

    _clear(items_flow)
    var items_value: Variant = profile.get("items", [])
    if typeof(items_value) == TYPE_ARRAY:
        for value: Variant in items_value as Array:
            var item_id: String = str(value)
            var item: Dictionary = _catalog_entry("item_catalog", item_id)
            var button: Button = _chip(str(item.get("label", _humanize(item_id))), ITEM_ICON)
            button.tooltip_text = str(item.get("description", "Persönlicher Gegenstand"))
            items_flow.add_child(button)

    _clear(companions_flow)
    var companions_value: Variant = profile.get("companions", [])
    if typeof(companions_value) == TYPE_ARRAY:
        for value: Variant in companions_value as Array:
            var companion_id: String = str(value)
            var companion: Dictionary = _catalog_entry("companion_catalog", companion_id)
            var button: Button = _chip("%s\n%s · Loyalität %d" % [
                str(companion.get("label", _humanize(companion_id))),
                str(companion.get("role", "Begleitfigur")),
                int(companion.get("loyalty", 50))
            ], COMPANION_ICON)
            button.custom_minimum_size = Vector2(0, 70)
            button.tooltip_text = str(companion.get("description", ""))
            companions_flow.add_child(button)

    var impact_lines: Array[String] = ["[color=#d7b46a]LETZTE AUSWIRKUNGEN[/color]"]
    var start: int = maxi(0, history.size() - 3)
    for index: int in range(start, history.size()):
        var entry_value: Variant = history[index]
        if typeof(entry_value) == TYPE_DICTIONARY:
            var entry: Dictionary = entry_value as Dictionary
            impact_lines.append("• %s → %s" % [str(entry.get("title", "")), str(entry.get("choice_label", ""))])
    if history.is_empty():
        impact_lines.append("Noch keine Entscheidung.")
    impact_label.text = "\n".join(impact_lines)

    var history_lines: Array[String] = ["[color=#d7b46a]BIOGRAFIE[/color]"]
    for index: int in range(history.size()):
        var entry_value: Variant = history[index]
        if typeof(entry_value) == TYPE_DICTIONARY:
            history_lines.append("%02d · %s" % [index + 1, str((entry_value as Dictionary).get("choice_label", ""))])
    history_label.text = "\n".join(history_lines)

func _catalog_entry(catalog_key: String, entry_id: String) -> Dictionary:
    var catalog_value: Variant = content.get(catalog_key, {})
    if typeof(catalog_value) != TYPE_DICTIONARY:
        return {}
    var entry_value: Variant = (catalog_value as Dictionary).get(entry_id, {})
    return entry_value as Dictionary if typeof(entry_value) == TYPE_DICTIONARY else {}

func _effect_preview(choice: Dictionary) -> String:
    var parts: Array[String] = []
    var effects_value: Variant = choice.get("effects", {})
    if typeof(effects_value) == TYPE_DICTIONARY:
        var effects: Dictionary = effects_value as Dictionary
        for key_value: Variant in effects.keys():
            var delta: int = int(effects.get(key_value, 0))
            parts.append("%s %s%d" % [_humanize(str(key_value)), "+" if delta > 0 else "", delta])
    var items_value: Variant = choice.get("items", [])
    if typeof(items_value) == TYPE_ARRAY and not (items_value as Array).is_empty():
        parts.append("Item: %s" % ", ".join(_item_labels(items_value as Array)))
    var companions_value: Variant = choice.get("companions", [])
    if typeof(companions_value) == TYPE_ARRAY and not (companions_value as Array).is_empty():
        parts.append("Vertraut: %s" % ", ".join(_companion_labels(companions_value as Array)))
    return " · ".join(parts)

func _item_labels(ids: Array) -> Array[String]:
    var labels: Array[String] = []
    for value: Variant in ids:
        var item_id: String = str(value)
        labels.append(str(_catalog_entry("item_catalog", item_id).get("label", _humanize(item_id))))
    return labels

func _companion_labels(ids: Array) -> Array[String]:
    var labels: Array[String] = []
    for value: Variant in ids:
        var companion_id: String = str(value)
        labels.append(str(_catalog_entry("companion_catalog", companion_id).get("label", _humanize(companion_id))))
    return labels

func _humanized(values: Array) -> Array[String]:
    var result: Array[String] = []
    for value: Variant in values:
        result.append(_humanize(str(value)))
    return result

func _save() -> void:
    var file: FileAccess = FileAccess.open(SAVE_PATH, FileAccess.WRITE)
    if file == null:
        status_label.text = "WARNUNG: PROLOG KONNTE NICHT GESPEICHERT WERDEN"
        return
    var data: Dictionary = {
        "schema_version": 1,
        "campaign_id": str(content.get("campaign_id", "flad_rasputin_origin")),
        "display_name": "Flad Rasputin",
        "current_index": current_index,
        "completed": completed,
        "profile": profile.duplicate(true),
        "history": history.duplicate(true),
        "saved_at_utc": Time.get_datetime_string_from_system(true, true)
    }
    file.store_string(JSON.stringify(data, "  "))
    file.flush()
    GameSession.set_flad_prologue_progress(current_index, profile, completed)

func _enter_office() -> void:
    AudioManager.play_click()
    completed = true
    profile["completed"] = true
    _save()
    GameSession.complete_flad_prologue(profile)
    AudioManager.stop_menu_music()
    var office: Node = OFFICE_SCENE.instantiate()
    office.set("avatar_id", "custom")
    office.set("avatar_display_name", "Flad Rasputin")
    get_tree().root.add_child(office)
    queue_free()

func _reset_prologue() -> void:
    AudioManager.play_click()
    if FileAccess.file_exists(SAVE_PATH):
        DirAccess.remove_absolute(ProjectSettings.globalize_path(SAVE_PATH))
    GameSession.reset_flad_prologue()
    var base_value: Variant = content.get("base_profile", {})
    profile = (base_value as Dictionary).duplicate(true) if typeof(base_value) == TYPE_DICTIONARY else {}
    current_index = 0
    completed = false
    history = []
    _save()
    _render()

func _on_back_pressed() -> void:
    AudioManager.play_click()
    _save()
    get_tree().change_scene_to_file("res://scenes/main.tscn")

func _chip(text_value: String, icon_value: Variant = null) -> Button:
    var button: Button = Button.new()
    button.text = text_value
    button.disabled = true
    button.custom_minimum_size = Vector2(0, 44)
    button.autowrap_mode = TextServer.AUTOWRAP_WORD_SMART
    if icon_value is Texture2D:
        button.icon = icon_value as Texture2D
        button.expand_icon = true
        button.icon_max_width = 30
    var style: StyleBoxFlat = StyleBoxFlat.new()
    style.bg_color = Color(0.06, 0.055, 0.052, 0.96)
    style.border_color = Color("7e5a2b")
    style.set_border_width_all(1)
    style.set_corner_radius_all(8)
    button.add_theme_stylebox_override("disabled", style)
    button.add_theme_color_override("font_disabled_color", Color("d7c8aa"))
    return button

func _style_button(button: Button) -> void:
    var normal: StyleBoxFlat = StyleBoxFlat.new()
    normal.bg_color = Color(0.02, 0.021, 0.024, 0.95)
    normal.border_color = Color("6f3a26")
    normal.set_border_width_all(2)
    normal.set_corner_radius_all(10)
    normal.content_margin_left = 18.0
    normal.content_margin_right = 18.0
    normal.content_margin_top = 10.0
    normal.content_margin_bottom = 10.0
    var hover: StyleBoxFlat = normal.duplicate()
    hover.bg_color = Color(0.16, 0.025, 0.035, 0.98)
    hover.border_color = Color("d2a14f")
    hover.set_border_width_all(3)
    var pressed: StyleBoxFlat = normal.duplicate()
    pressed.bg_color = Color(0.34, 0.035, 0.045, 0.98)
    pressed.border_color = Color("f0cf80")
    button.add_theme_stylebox_override("normal", normal)
    button.add_theme_stylebox_override("hover", hover)
    button.add_theme_stylebox_override("pressed", pressed)
    button.add_theme_color_override("font_color", Color("e9dfcc"))
    button.add_theme_color_override("font_hover_color", Color("ffffff"))
    button.mouse_default_cursor_shape = Control.CURSOR_POINTING_HAND

func _style_primary(button: Button) -> void:
    _style_button(button)
    var primary: StyleBoxFlat = StyleBoxFlat.new()
    primary.bg_color = Color(0.32, 0.035, 0.045, 0.98)
    primary.border_color = Color("d3a34f")
    primary.set_border_width_all(3)
    primary.set_corner_radius_all(10)
    primary.content_margin_left = 18.0
    primary.content_margin_right = 18.0
    primary.content_margin_top = 12.0
    primary.content_margin_bottom = 12.0
    button.add_theme_stylebox_override("normal", primary)
    button.add_theme_color_override("font_color", Color("fff2d0"))
    button.add_theme_font_size_override("font_size", 20)

func _clear(container: Node) -> void:
    for child: Node in container.get_children():
        child.queue_free()

func _humanize(value: String) -> String:
    var text: String = value.replace("_", " ").strip_edges()
    if text.is_empty():
        return "Offen"
    return text.substr(0, 1).to_upper() + text.substr(1)

func _fatal(message: String) -> void:
    event_title.text = "PROLOG NICHT VERFÜGBAR"
    event_body.text = message
    question_label.text = "Zurück zum Hauptmenü"
    status_label.text = "FEHLER"
