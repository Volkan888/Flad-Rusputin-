extends Control

@onready var status_label: Label = $Margin/VBox/Status

func _ready() -> void:
    status_label.text = "1933 · Verbindung zum Server wird vorbereitet"

func _on_start_pressed() -> void:
    status_label.text = "riseOfReign · Prolog → 1. Januar 1933"
