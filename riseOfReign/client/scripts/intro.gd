extends Control

const VIDEO_PATH := "res://assets/video/vkapps_riseofreign_intro.ogv"

@onready var video: VideoStreamPlayer = $Video
@onready var fallback: Control = $Fallback
@onready var vk_apps: Label = $Fallback/Center/VBox/VKApps
@onready var presents: Label = $Fallback/Center/VBox/Presents
@onready var game_title: Label = $Fallback/Center/VBox/GameTitle
@onready var subtitle: Label = $Fallback/Center/VBox/Subtitle
@onready var red_flash: ColorRect = $Fallback/RedFlash
@onready var skip_button: Button = $Skip

var _finished := false

func _ready() -> void:
    if not AudioManager.intro_enabled:
        _finish_intro()
        return
    AudioManager.stop_menu_music()
    if ResourceLoader.exists(VIDEO_PATH):
        var stream = load(VIDEO_PATH)
        if stream is VideoStream:
            fallback.visible = false
            video.visible = true
            video.stream = stream
            video.play()
            return
    _run_fallback_intro()

func _run_fallback_intro() -> void:
    video.visible = false
    fallback.visible = true
    vk_apps.modulate.a = 0.0
    presents.modulate.a = 0.0
    game_title.modulate.a = 0.0
    subtitle.modulate.a = 0.0
    red_flash.modulate.a = 0.0
    skip_button.modulate.a = 0.0
    AudioManager.play_intro_cue()
    var tween := create_tween()
    tween.set_trans(Tween.TRANS_QUAD).set_ease(Tween.EASE_OUT)
    tween.tween_property(vk_apps, "modulate:a", 1.0, 0.55)
    tween.parallel().tween_property(vk_apps, "scale", Vector2(1.04, 1.04), 0.55).from(Vector2(0.92, 0.92))
    tween.tween_interval(0.45)
    tween.tween_property(presents, "modulate:a", 0.72, 0.35)
    tween.tween_interval(0.4)
    tween.tween_property(red_flash, "modulate:a", 0.34, 0.12)
    tween.tween_property(red_flash, "modulate:a", 0.0, 0.42)
    tween.parallel().tween_property(vk_apps, "modulate:a", 0.0, 0.45)
    tween.parallel().tween_property(presents, "modulate:a", 0.0, 0.35)
    tween.tween_property(game_title, "modulate:a", 1.0, 0.6)
    tween.parallel().tween_property(game_title, "scale", Vector2.ONE, 0.6).from(Vector2(1.08, 1.08))
    tween.tween_property(subtitle, "modulate:a", 0.88, 0.35)
    tween.parallel().tween_property(skip_button, "modulate:a", 0.55, 0.25)
    tween.tween_interval(0.85)
    tween.tween_property(game_title, "modulate:a", 0.0, 0.35)
    tween.parallel().tween_property(subtitle, "modulate:a", 0.0, 0.35)
    tween.finished.connect(_finish_intro)

func _unhandled_input(event: InputEvent) -> void:
    if event.is_pressed() and not event.is_echo():
        _finish_intro()

func _on_video_finished() -> void:
    _finish_intro()

func _on_skip_pressed() -> void:
    AudioManager.play_click()
    _finish_intro()

func _finish_intro() -> void:
    if _finished:
        return
    _finished = true
    if video.playing:
        video.stop()
    get_tree().change_scene_to_file("res://scenes/main.tscn")
