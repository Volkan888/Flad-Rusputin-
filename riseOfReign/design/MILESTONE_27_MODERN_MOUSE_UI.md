# Milestone 27 — Modern Mouse UI

Stand: 2026-09-02 06:46 CEST

## Fertig
- Desktop-first 1920x1080, Maus + Keyboard
- native SVG-Icons für Büro, Welt, Telefon, Staat, Strategie, Events, Einstellungen, Timer und Fertig
- Hover- und Tooltip-Navigation
- permanente Statusleiste für Staatskasse, Einnahmen, Ausgaben, Gesundheit, Stabilität und Autorität
- Uhr + FERTIG/BEREIT direkt im Header
- lokaler 5-Minuten-Countdown als UI-Fallback; Serverdeadline bleibt die autoritative Zielarchitektur
- moderne Hauptnavigation: Büro, Welt, Telefon, Staat, Strategie, Events, Einstellungen
- bestehende getestete Büro-, Karten-, Telefon-, Wirtschafts-, Militär-, Event- und Settings-Funktionen weiterverwendet
- Intro ist video-first via Godot VideoStreamPlayer und erwartet `res://assets/video/vkapps_riseofreign_intro.ogv`
- falls kein Videoasset vorhanden ist, läuft automatisch der animierte VK APPS → RISE OF REIGN Fallback
- Intro ist überspringbar und in den Einstellungen deaktivierbar

## Videoformat
Godot-Core nutzt Ogg Theora `.ogv` für VideoStreamPlayer. Das finale Introasset kann ohne Codeänderung unter dem erwarteten Pfad ersetzt werden.

## CI
GitHub Actions Run 33590674626: PASS
- Core-Content-/Desktop-UI-Vertragstests PASS
- Godot 4.7.2 headless parse PASS
- .NET 10 restore/build PASS
- API start PASS
- Januar-API smoke PASS

## Nächster UI-Schritt
Die endgültigen Büro-/Karten-/Avatargrafiken werden als austauschbare visuelle Assets auf diesen funktionalen UI-Layer gelegt. Hotspots und Button-IDs bleiben stabil.
