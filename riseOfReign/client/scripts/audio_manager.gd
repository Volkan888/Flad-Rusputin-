extends Node

const SETTINGS_PATH := "user://riseofreign_settings.cfg"

var master_volume: float = 0.85
var music_volume: float = 0.55
var sfx_volume: float = 0.75
var music_enabled: bool = true
var sfx_enabled: bool = true

var _music_player: AudioStreamPlayer
var _sfx_player: AudioStreamPlayer

func _ready() -> void:
    _load_settings()
    _music_player = AudioStreamPlayer.new()
    _sfx_player = AudioStreamPlayer.new()
    add_child(_music_player)
    add_child(_sfx_player)
    _music_player.stream = _make_tone([55.0, 82.5, 110.0], 4.0, 0.06, true)
    _sfx_player.stream = _make_click()
    apply_settings()

func start_menu_music() -> void:
    if music_enabled and not _music_player.playing:
        _music_player.play()

func stop_menu_music() -> void:
    _music_player.stop()

func play_click() -> void:
    if not sfx_enabled:
        return
    _sfx_player.play()

func set_master_volume(value: float) -> void:
    master_volume = clampf(value, 0.0, 1.0)
    apply_settings()
    save_settings()

func set_music_volume(value: float) -> void:
    music_volume = clampf(value, 0.0, 1.0)
    apply_settings()
    save_settings()

func set_sfx_volume(value: float) -> void:
    sfx_volume = clampf(value, 0.0, 1.0)
    apply_settings()
    save_settings()

func set_music_enabled(value: bool) -> void:
    music_enabled = value
    if music_enabled:
        start_menu_music()
    else:
        _music_player.stop()
    save_settings()

func set_sfx_enabled(value: bool) -> void:
    sfx_enabled = value
    save_settings()

func apply_settings() -> void:
    var master_db := linear_to_db(maxf(master_volume, 0.001))
    AudioServer.set_bus_volume_db(AudioServer.get_bus_index("Master"), master_db)
    if _music_player:
        _music_player.volume_db = linear_to_db(maxf(music_volume, 0.001))
    if _sfx_player:
        _sfx_player.volume_db = linear_to_db(maxf(sfx_volume, 0.001))

func save_settings() -> void:
    var config := ConfigFile.new()
    config.set_value("audio", "master", master_volume)
    config.set_value("audio", "music", music_volume)
    config.set_value("audio", "sfx", sfx_volume)
    config.set_value("audio", "music_enabled", music_enabled)
    config.set_value("audio", "sfx_enabled", sfx_enabled)
    config.save(SETTINGS_PATH)

func _load_settings() -> void:
    var config := ConfigFile.new()
    if config.load(SETTINGS_PATH) != OK:
        return
    master_volume = float(config.get_value("audio", "master", master_volume))
    music_volume = float(config.get_value("audio", "music", music_volume))
    sfx_volume = float(config.get_value("audio", "sfx", sfx_volume))
    music_enabled = bool(config.get_value("audio", "music_enabled", music_enabled))
    sfx_enabled = bool(config.get_value("audio", "sfx_enabled", sfx_enabled))

func _make_click() -> AudioStreamWAV:
    var stream := AudioStreamWAV.new()
    stream.format = AudioStreamWAV.FORMAT_16_BITS
    stream.mix_rate = 22050
    stream.stereo = false
    var frames := 1100
    var data := PackedByteArray()
    data.resize(frames * 2)
    for i in range(frames):
        var t := float(i) / 22050.0
        var envelope := 1.0 - float(i) / float(frames)
        var sample := sin(TAU * 620.0 * t) * envelope * 0.22
        data.encode_s16(i * 2, int(clampf(sample, -1.0, 1.0) * 32767.0))
    stream.data = data
    return stream

func _make_tone(frequencies: Array[float], duration: float, gain: float, looped: bool) -> AudioStreamWAV:
    var stream := AudioStreamWAV.new()
    stream.format = AudioStreamWAV.FORMAT_16_BITS
    stream.mix_rate = 22050
    stream.stereo = false
    var frames := int(duration * 22050.0)
    var data := PackedByteArray()
    data.resize(frames * 2)
    for i in range(frames):
        var t := float(i) / 22050.0
        var sample := 0.0
        for frequency in frequencies:
            sample += sin(TAU * frequency * t)
        sample = (sample / maxf(1.0, float(frequencies.size()))) * gain
        data.encode_s16(i * 2, int(clampf(sample, -1.0, 1.0) * 32767.0))
    stream.data = data
    if looped:
        stream.loop_mode = AudioStreamWAV.LOOP_FORWARD
        stream.loop_begin = 0
        stream.loop_end = frames
    return stream
