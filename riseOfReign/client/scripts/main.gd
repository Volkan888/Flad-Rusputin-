extends Control

@onready var settings_panel: PanelContainer = $SettingsOverlay/SettingsPanel
@onready var settings_overlay: Control = $SettingsOverlay
@onready var master_slider: HSlider = $SettingsOverlay/SettingsPanel/SettingsLayout/MasterRow/MasterSlider
@onready var music_slider: HSlider = $SettingsOverlay/SettingsPanel/SettingsLayout/MusicRow/MusicSlider
@onready var sfx_slider: HSlider = $SettingsOverlay/SettingsPanel/SettingsLayout/SfxRow/SfxSlider
@onready var music_toggle: CheckButton = $SettingsOverlay/SettingsPanel/SettingsLayout/MusicToggle
@onready var sfx_toggle: CheckButton = $SettingsOverlay/SettingsPanel/SettingsLayout/SfxToggle
@onready var status_label: Label = $MainLayout/Footer/Status

func _ready() -> void:
    _style_all_buttons()
    _load_settings_into_controls()
    settings_overlay.visible = false
    status_label.text = "1933 · The World in Crisis · Build 0.1"
    AudioManager.start_menu_music()

func _on_new_game_pressed() -> void:
    AudioManager.play_click()
    get_tree().change_scene_to_file("res://scenes/avatar_select.tscn")

func _on_continue_pressed() -> void:
    AudioManager.play_click()
    status_label.text = "Fortsetzen wird mit dem persistenten Match-/Snapshot-System verbunden."

func _on_multiplayer_pressed() -> void:
    AudioManager.play_click()
    status_label.text = "Multiplayer: Avatar wählen und anschließend einem 4-Spieler-Match beitreten."
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

func _load_settings_into_controls() -> void:
    master_slider.value = AudioManager.master_volume
    music_slider.value = AudioManager.music_volume
    sfx_slider.value = AudioManager.sfx_volume
    music_toggle.button_pressed = AudioManager.music_enabled
    sfx_toggle.button_pressed = AudioManager.sfx_enabled

func _style_all_buttons() -> void:
    for button in get_tree().get_nodes_in_group("strategy_menu_button"):
        if button is Button:
            _style_strategy_button(button)

func _style_strategy_button(button: Button) -> void:
    var normal := StyleBoxFlat.new()
    normal.bg_color = Color("111111")
    normal.border_color = Color("5b0b10")
    normal.set_border_width_all(2)
    normal.corner_radius_top_left = 3
    normal.corner_radius_top_right = 3
    normal.corner_radius_bottom_left = 3
    normal.corner_radius_bottom_right = 3

    var hover := normal.duplicate()
    hover.bg_color = Color("26080b")
    hover.border_color = Color("a91720")

    var pressed := normal.duplicate()
    pressed.bg_color = Color("4c0a10")
    pressed.border_color = Color("dc3540")

    button.add_theme_stylebox_override("normal", normal)
    button.add_theme_stylebox_override("hover", hover)
    button.add_theme_stylebox_override("pressed", pressed)
    button.add_theme_color_override("font_color", Color("e7dfcf"))
    button.add_theme_color_override("font_hover_color", Color("ffffff"))
    button.add_theme_font_size_override("font_size", 22)
