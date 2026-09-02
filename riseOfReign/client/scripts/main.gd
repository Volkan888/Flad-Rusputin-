extends Control

const OFFICE_SCENE = preload("res://scenes/office_hub.tscn")

@onready var avatar_list: VBoxContainer = $Margin/VBox/AvatarScroll/AvatarList
@onready var status_label: Label = $Margin/VBox/Status

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
    status_label.text = "Wähle einen Avatar. Danach öffnet sich seine persönliche Steuerzentrale im Zustand vom 1. Januar 1933."
    _build_avatar_list()

func _build_avatar_list() -> void:
    for child in avatar_list.get_children():
        child.queue_free()

    for avatar in AVATARS:
        var button := Button.new()
        button.text = "%s\n%s" % [avatar["name"], avatar["subtitle"]]
        button.custom_minimum_size = Vector2(0, 88)
        button.pressed.connect(_open_office.bind(str(avatar["id"]), str(avatar["name"])))
        avatar_list.add_child(button)

func _open_office(selected_avatar_id: String, display_name: String) -> void:
    status_label.text = "Öffne Steuerzentrale von %s…" % display_name
    var office = OFFICE_SCENE.instantiate()
    office.avatar_id = selected_avatar_id
    office.avatar_display_name = display_name
    get_tree().root.add_child(office)
    queue_free()
