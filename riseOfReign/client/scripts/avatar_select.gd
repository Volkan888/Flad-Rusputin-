extends Control

const OFFICE_SCENE = preload("res://scenes/office_hub.tscn")

@onready var avatar_list: VBoxContainer = $Margin/Layout/AvatarScroll/AvatarList
@onready var status_label: Label = $Margin/Layout/Status

const AVATARS := [
    {"id":"ataturk", "name":"Mustafa Kemal Atatürk", "subtitle":"Türkei · Präsident"},
    {"id":"hitler", "name":"Adolf Hitler", "subtitle":"Deutschland · Parteiführer am 1. Januar 1933"},
    {"id":"stalin", "name":"Joseph Stalin", "subtitle":"Sowjetunion · Machtzentrum / Generalsekretär"},
    {"id":"churchill", "name":"Winston Churchill", "subtitle":"Großbritannien · Abgeordneter"},
    {"id":"roosevelt", "name":"Franklin D. Roosevelt", "subtitle":"USA · President-elect"},
    {"id":"mussolini", "name":"Benito Mussolini", "subtitle":"Italien · Regierungschef"},
    {"id":"custom", "name":"Eigener Avatar", "subtitle":"Herkunft und Laufbahn aus dem Prolog"}
]

func _ready() -> void:
    _apply_button_theme()
    status_label.text = "Wähle einen Avatar. Danach öffnet sich seine persönliche Steuerzentrale im Zustand vom 1. Januar 1933."
    _build_avatar_list()

func _build_avatar_list() -> void:
    for child in avatar_list.get_children():
        child.queue_free()

    for avatar in AVATARS:
        var button := Button.new()
        button.text = "%s\n%s" % [avatar["name"], avatar["subtitle"]]
        button.custom_minimum_size = Vector2(0, 92)
        button.autowrap_mode = TextServer.AUTOWRAP_WORD_SMART
        _style_strategy_button(button)
        button.pressed.connect(_open_office.bind(str(avatar["id"]), str(avatar["name"])))
        avatar_list.add_child(button)

func _open_office(selected_avatar_id: String, display_name: String) -> void:
    AudioManager.play_click()
    AudioManager.stop_menu_music()
    status_label.text = "Öffne Steuerzentrale von %s…" % display_name
    var office = OFFICE_SCENE.instantiate()
    office.avatar_id = selected_avatar_id
    office.avatar_display_name = display_name
    get_tree().root.add_child(office)
    queue_free()

func _on_back_pressed() -> void:
    AudioManager.play_click()
    get_tree().change_scene_to_file("res://scenes/main.tscn")

func _apply_button_theme() -> void:
    _style_strategy_button($Margin/Layout/Header/Back)

func _style_strategy_button(button: Button) -> void:
    var normal := StyleBoxFlat.new()
    normal.bg_color = Color("151515")
    normal.border_color = Color("6e0e12")
    normal.set_border_width_all(2)
    normal.corner_radius_top_left = 4
    normal.corner_radius_top_right = 4
    normal.corner_radius_bottom_left = 4
    normal.corner_radius_bottom_right = 4

    var hover := normal.duplicate()
    hover.bg_color = Color("260b0d")
    hover.border_color = Color("b3242b")

    var pressed := normal.duplicate()
    pressed.bg_color = Color("410b10")
    pressed.border_color = Color("d54a50")

    button.add_theme_stylebox_override("normal", normal)
    button.add_theme_stylebox_override("hover", hover)
    button.add_theme_stylebox_override("pressed", pressed)
    button.add_theme_color_override("font_color", Color("e9e2d2"))
    button.add_theme_color_override("font_hover_color", Color("ffffff"))
