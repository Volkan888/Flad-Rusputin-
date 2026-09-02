extends Control

const OFFICE_SCENE = preload("res://scenes/office_hub.tscn")
const PROFILE_ICON = preload("res://assets/icons/profile.svg")

@onready var avatar_list: VBoxContainer = $Margin/Layout/AvatarScroll/AvatarList
@onready var status_label: Label = $Margin/Layout/Status
@onready var mode_label: Label = $Margin/Layout/ModePanel/ModeLayout/ModeLabel
@onready var solo_options: HBoxContainer = $Margin/Layout/ModePanel/ModeLayout/SoloOptions
@onready var difficulty_option: OptionButton = $Margin/Layout/ModePanel/ModeLayout/SoloOptions/DifficultyBlock/Difficulty
@onready var history_option: OptionButton = $Margin/Layout/ModePanel/ModeLayout/SoloOptions/HistoryBlock/History
@onready var timer_option: OptionButton = $Margin/Layout/ModePanel/ModeLayout/SoloOptions/TimerBlock/Timer
@onready var learning_toggle: CheckButton = $Margin/Layout/ModePanel/ModeLayout/LearningToggle
@onready var mode_note: Label = $Margin/Layout/ModePanel/ModeLayout/ModeNote

const AVATARS := [
    {"id":"ataturk", "name":"Mustafa Kemal Atatürk", "subtitle":"Türkei · Präsident · Reformen, Bildung und Diplomatie"},
    {"id":"hitler", "name":"Adolf Hitler", "subtitle":"Deutschland · Parteiführer am 1. Januar 1933 · kritische historische Darstellung"},
    {"id":"stalin", "name":"Joseph Stalin", "subtitle":"Sowjetunion · staatliche Planung, Industrie und innere Macht"},
    {"id":"churchill", "name":"Winston Churchill", "subtitle":"Großbritannien · Abgeordneter · politischer Wiederaufstieg"},
    {"id":"roosevelt", "name":"Franklin D. Roosevelt", "subtitle":"USA · President-elect · Banken- und Wirtschaftskrise"},
    {"id":"mussolini", "name":"Benito Mussolini", "subtitle":"Italien · Regierungschef · kritische historische Darstellung"},
    {"id":"custom", "name":"Eigener Avatar", "subtitle":"Herkunft und Laufbahn werden später im Prolog gestaltet"}
]

func _ready() -> void:
    _apply_button_theme()
    _configure_mode_panel()
    _build_avatar_list()

func _configure_mode_panel() -> void:
    difficulty_option.clear()
    difficulty_option.add_item("Leicht")
    difficulty_option.set_item_metadata(0, "easy")
    difficulty_option.add_item("Normal")
    difficulty_option.set_item_metadata(1, "normal")
    difficulty_option.add_item("Schwer")
    difficulty_option.set_item_metadata(2, "hard")

    history_option.clear()
    history_option.add_item("Historisch geführt")
    history_option.set_item_metadata(0, "guided")
    history_option.add_item("Alternative Geschichte")
    history_option.set_item_metadata(1, "alternate")

    timer_option.clear()
    timer_option.add_item("Ohne Timer")
    timer_option.set_item_metadata(0, 0)
    timer_option.add_item("2 Minuten")
    timer_option.set_item_metadata(1, 120)
    timer_option.add_item("5 Minuten")
    timer_option.set_item_metadata(2, 300)
    timer_option.add_item("10 Minuten")
    timer_option.set_item_metadata(3, 600)
    timer_option.add_item("1 Stunde")
    timer_option.set_item_metadata(4, 3600)
    timer_option.add_item("24 Stunden")
    timer_option.set_item_metadata(5, 86400)

    difficulty_option.select(_find_metadata_index(difficulty_option, GameSession.solo_difficulty))
    history_option.select(_find_metadata_index(history_option, GameSession.historical_mode))
    timer_option.select(_find_metadata_index(timer_option, GameSession.solo_timer_seconds))
    learning_toggle.button_pressed = GameSession.learning_enabled

    if GameSession.is_solo():
        mode_label.text = "1 SPIELER · SOLO-LERNKAMPAGNE"
        solo_options.visible = true
        learning_toggle.visible = true
        mode_note.text = "Du steuerst einen Avatar. Die übrigen Mächte werden zunächst von einem transparenten, deterministischen KI-Direktor geführt. Ohne Timer kannst du alle Hinweise in Ruhe lesen."
        status_label.text = "Wähle deinen Avatar. Die Bildräume, Maus-Hotspots und Wissenskarten öffnen sich danach im Büro."
    else:
        mode_label.text = "MULTIPLAYER · 2 GEGEN 2"
        solo_options.visible = false
        learning_toggle.visible = false
        mode_note.text = "Blaue Seite gegen rote Seite. Staatskassen, Inventare und militärische Kontrolle bleiben getrennt."
        status_label.text = "Wähle einen Avatar für den 2-gegen-2-Prototyp."

func _build_avatar_list() -> void:
    for child in avatar_list.get_children():
        child.queue_free()
    for avatar in AVATARS:
        var button := Button.new()
        button.text = "%s\n%s" % [avatar["name"], avatar["subtitle"]]
        button.icon = PROFILE_ICON
        button.expand_icon = true
        button.icon_max_width = 42
        button.custom_minimum_size = Vector2(0, 96)
        button.autowrap_mode = TextServer.AUTOWRAP_WORD_SMART
        button.alignment = HORIZONTAL_ALIGNMENT_LEFT
        button.icon_alignment = HORIZONTAL_ALIGNMENT_LEFT
        button.tooltip_text = "Büro und Prolog von %s öffnen" % avatar["name"]
        button.mouse_default_cursor_shape = Control.CURSOR_POINTING_HAND
        _style_strategy_button(button)
        button.pressed.connect(_open_office.bind(str(avatar["id"]), str(avatar["name"])))
        avatar_list.add_child(button)

func _open_office(selected_avatar_id: String, display_name: String) -> void:
    AudioManager.play_click()
    if GameSession.is_solo():
        var difficulty_id := str(difficulty_option.get_selected_metadata())
        var history_id := str(history_option.get_selected_metadata())
        var timer_seconds := int(timer_option.get_selected_metadata())
        GameSession.configure_solo(difficulty_id, history_id, timer_seconds, learning_toggle.button_pressed)
    GameSession.select_avatar(selected_avatar_id, display_name)
    AudioManager.stop_menu_music()
    status_label.text = "Öffne %s · %s…" % [GameSession.session_label(), display_name]
    var office = OFFICE_SCENE.instantiate()
    office.avatar_id = selected_avatar_id
    office.avatar_display_name = display_name
    get_tree().root.add_child(office)
    queue_free()

func _on_back_pressed() -> void:
    AudioManager.play_click()
    get_tree().change_scene_to_file("res://scenes/main.tscn")

func _find_metadata_index(option: OptionButton, value) -> int:
    for index in range(option.item_count):
        if option.get_item_metadata(index) == value:
            return index
    return 0

func _apply_button_theme() -> void:
    _style_strategy_button($Margin/Layout/Header/Back)
    for option in [difficulty_option, history_option, timer_option]:
        option.mouse_default_cursor_shape = Control.CURSOR_POINTING_HAND

func _style_strategy_button(button: Button) -> void:
    var normal := StyleBoxFlat.new()
    normal.bg_color = Color(0.025, 0.026, 0.03, 0.94)
    normal.border_color = Color("6e2a24")
    normal.set_border_width_all(2)
    normal.corner_radius_top_left = 10
    normal.corner_radius_top_right = 10
    normal.corner_radius_bottom_left = 10
    normal.corner_radius_bottom_right = 10
    normal.content_margin_left = 20
    normal.content_margin_right = 20

    var hover := normal.duplicate()
    hover.bg_color = Color(0.18, 0.025, 0.035, 0.98)
    hover.border_color = Color("d3a34f")
    hover.set_border_width_all(3)

    var pressed := normal.duplicate()
    pressed.bg_color = Color(0.4, 0.035, 0.05, 0.98)
    pressed.border_color = Color("f0cf80")

    button.add_theme_stylebox_override("normal", normal)
    button.add_theme_stylebox_override("hover", hover)
    button.add_theme_stylebox_override("pressed", pressed)
    button.add_theme_color_override("font_color", Color("e9e2d2"))
    button.add_theme_color_override("font_hover_color", Color("ffffff"))
