extends Control

const OFFICE_SCENE = preload("res://scenes/office_hub.tscn")
const CAMPAIGN_SAVE_PATH := "user://riseofreign_campaign.json"

@onready var settings_panel: PanelContainer = $SettingsOverlay/SettingsPanel
@onready var settings_overlay: Control = $SettingsOverlay
@onready var master_slider: HSlider = $SettingsOverlay/SettingsPanel/SettingsLayout/MasterRow/MasterSlider
@onready var music_slider: HSlider = $SettingsOverlay/SettingsPanel/SettingsLayout/MusicRow/MusicSlider
@onready var sfx_slider: HSlider = $SettingsOverlay/SettingsPanel/SettingsLayout/SfxRow/SfxSlider
@onready var music_toggle: CheckButton = $SettingsOverlay/SettingsPanel/SettingsLayout/MusicToggle
@onready var sfx_toggle: CheckButton = $SettingsOverlay/SettingsPanel/SettingsLayout/SfxToggle
@onready var intro_toggle: CheckButton = $SettingsOverlay/SettingsPanel/SettingsLayout/IntroToggle
@onready var status_label: Label = $MainLayout/Footer/Status
@onready var solo_button: Button = $MainLayout/Content/MenuPanel/Menu/NewGame
@onready var multiplayer_button: Button = $MainLayout/Content/MenuPanel/Menu/Multiplayer

func _ready() -> void:
    _style_all_buttons()
    _load_settings_into_controls()
    settings_overlay.visible = false
    status_label.text = "RISE OF REIGN · SPIELBARER PROTOTYP · SOLO-LERNKAMPAGNE + 2 GEGEN 2"
    solo_button.grab_focus()
    AudioManager.start_menu_music()

func _on_new_game_pressed() -> void:
    AudioManager.play_click()
    _reset_local_campaign()
    GameSession.start_solo()
    status_label.text = "Neue Solo-Lernkampagne wird vorbereitet…"
    get_tree().change_scene_to_file("res://scenes/avatar_select.tscn")

func _on_continue_pressed() -> void:
    AudioManager.play_click()
    if GameSession.player_avatar_id.is_empty():
        status_label.text = "Noch kein Spielstand vorhanden. Starte zuerst eine Solo-Lernkampagne."
        return
    status_label.text = "Lade letzte Sitzung: %s · %s" % [GameSession.session_label(), GameSession.player_display_name]
    AudioManager.stop_menu_music()
    var office = OFFICE_SCENE.instantiate()
    office.avatar_id = GameSession.player_avatar_id
    office.avatar_display_name = GameSession.player_display_name
    get_tree().root.add_child(office)
    queue_free()

func _on_multiplayer_pressed() -> void:
    AudioManager.play_click()
    GameSession.start_multiplayer()
    status_label.text = "2-gegen-2-Modus: Blaue Seite gegen rote Seite."
    get_tree().change_scene_to_file("res://scenes/avatar_select.tscn")

func _on_settings_pressed() -> void:
    AudioManager.play_click()
    _load_settings_into_controls()
    settings_overlay.visible = true

func _on_close_settings_pressed() -> void:
    AudioManager.play_click()
    settings_overlay.visible = false

func _on_quit_pressed() -> void:
    AudioManager.play_click()
    get_tree().quit()

func _on_master_changed(value: float) -> void:
    AudioManager.set_master_volume(value)

func _on_music_changed(value: float) -> void:
    AudioManager.set_music_volume(value)

func _on_sfx_changed(value: float) -> void:
    AudioManager.set_sfx_volume(value)

func _on_music_toggled(enabled: bool) -> void:
    AudioManager.set_music_enabled(enabled)

func _on_sfx_toggled(enabled: bool) -> void:
    AudioManager.set_sfx_enabled(enabled)

func _on_intro_toggled(enabled: bool) -> void:
    AudioManager.set_intro_enabled(enabled)

func _load_settings_into_controls() -> void:
    master_slider.value = AudioManager.master_volume
    music_slider.value = AudioManager.music_volume
    sfx_slider.value = AudioManager.sfx_volume
    music_toggle.button_pressed = AudioManager.music_enabled
    sfx_toggle.button_pressed = AudioManager.sfx_enabled
    intro_toggle.button_pressed = AudioManager.intro_enabled

func _reset_local_campaign() -> void:
    var absolute_path := ProjectSettings.globalize_path(CAMPAIGN_SAVE_PATH)
    if FileAccess.file_exists(CAMPAIGN_SAVE_PATH):
        DirAccess.remove_absolute(absolute_path)
    GameSession.player_avatar_id = ""
    GameSession.player_display_name = ""
    GameSession.world_tension = 18
    GameSession.last_ai_report = {}
    GameSession.learning_score = 0
    GameSession.learning_answers = 0

func _style_all_buttons() -> void:
    for button in get_tree().get_nodes_in_group("strategy_menu_button"):
        if button is Button:
            _style_strategy_button(button)

func _style_strategy_button(button: Button) -> void:
    var normal := StyleBoxFlat.new()
    normal.bg_color = Color(0.025, 0.025, 0.03, 0.92)
    normal.border_color = Color("6f1a20")
    normal.set_border_width_all(2)
    normal.corner_radius_top_left = 12
    normal.corner_radius_top_right = 12
    normal.corner_radius_bottom_left = 12
    normal.corner_radius_bottom_right = 12
    normal.content_margin_left = 24
    normal.content_margin_right = 24

    var hover := normal.duplicate()
    hover.bg_color = Color(0.18, 0.025, 0.035, 0.98)
    hover.border_color = Color("d1a04e")
    hover.set_border_width_all(3)

    var pressed := normal.duplicate()
    pressed.bg_color = Color(0.38, 0.035, 0.05, 0.98)
    pressed.border_color = Color("f0cf80")

    var focus := hover.duplicate()
    focus.border_color = Color("f1d083")

    button.add_theme_stylebox_override("normal", normal)
    button.add_theme_stylebox_override("hover", hover)
    button.add_theme_stylebox_override("pressed", pressed)
    button.add_theme_stylebox_override("focus", focus)
    button.add_theme_color_override("font_color", Color("e7dfcf"))
    button.add_theme_color_override("font_hover_color", Color("ffffff"))
    button.add_theme_font_size_override("font_size", 22)
    button.mouse_default_cursor_shape = Control.CURSOR_POINTING_HAND
