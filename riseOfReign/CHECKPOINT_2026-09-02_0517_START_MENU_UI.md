# riseOfReign — Start Menu & Strategy HUD Checkpoint

Stand: 2026-09-02 05:17 CEST

## Implementiert

- Neues Hauptmenü als eigener Startscreen.
- Farbwelt: Schwarz/Anthrazit + dunkles Rot + warme Messing/Beige-Akzente.
- Überschrift `RISE OF REIGN` und Epochenzeile `1933 · THE WORLD IN CRISIS`.
- Hauptmenüknöpfe:
  - Neues Spiel
  - Fortsetzen
  - Multiplayer · 4 Spieler
  - Einstellungen
  - Beenden
- Avatar-Auswahl in eigene Szene verschoben.
- Alle sieben Avatar-Slots bleiben verbunden.
- Globaler `AudioManager` als Godot-Autoload.
- Persistente Audioeinstellungen in `user://riseofreign_settings.cfg`.
- Master-, Musik- und Effektlautstärke.
- Musik und UI-Sounds separat aktivierbar.
- Prototyp verwendet selbst erzeugten lizenzfreien Menüton und Klicksound; finale Audioassets können später ersetzt werden.

## Büro / Ingame-HUD

Permanent sichtbare Statusleiste:
- Staatskasse
- Einnahmen
- Ausgaben
- Avatar-Gesundheit
- Stabilität
- Autorität

Werte werden aus dem aktuellen Monatszustand gelesen. Noch nicht im Backend vorhandene Werte werden als `—` angezeigt und nicht erfunden.

Permanent sichtbare Schnellnavigation:
- Büro
- Weltkarte
- Telefon
- Entscheidungen
- Inventar
- Akten
- Forschung
- Diplomatie
- Wirtschaft
- Militär
- Ereignisse
- Einstellungen

Die Schnellnavigation nutzt native Godot-Buttons statt eines einzigen großen Mockup-Bildes. Dadurch bleiben Skalierung, Touch-Ziele, Zustände, Sperren und spätere Animationen sauber steuerbar.

## Verbindungen

- Neues Spiel → Avatar-Auswahl.
- Multiplayer → Avatar-Auswahl als Einstieg in den 4-Spieler-Pfad.
- Avatar → persönliches 1933-Büro.
- Weltkarte → Karten-/Lageraum.
- Telefon → Kontakt-/Telefonliste.
- Entscheidungen → Monatsentscheidungen.
- Inventar → persönliche Avatar-Gegenstände und Spezialobjekt.
- Akten → Archiv-Menü.
- Forschung → Forschungsübersicht.
- Diplomatie → Diplomatieübersicht.
- Wirtschaft → Wirtschafts-/Staatsvermögensübersicht.
- Militär → militärisches Side-Menü.
- Ereignisse → Monats-/Lagebericht.
- Einstellungen → Audioeinstellungen auch aus dem Büro.

## Designreferenz

Die zuvor erzeugte Grand-Strategy-Mockup-Grafik dient als visuelle Referenz für spätere finale UI-/Icon-/Bürografiken. Die funktionale Oberfläche bleibt nativ und datengetrieben.

## Tests

GitHub CI erfolgreich:
- Python Client-/Content-Vertragstests PASS
- Godot 4.7.2 headless project parse PASS
- .NET 10 restore/build PASS
- API start PASS
- Office/January API smoke tests PASS

## Nächster UI-Schritt

1. Finanz-/Staatsvermögensmodell mit echten Einnahmen/Ausgaben in HUD einspeisen.
2. Avatar-Gesundheit/Vitals persistent machen.
3. Inventar persistent und ereignisabhängig machen.
4. Weltkartenraum visuell mit der 1933-Onlinekarte und Ressourcen-Layern rendern.
5. Finale Icon-/Button-/Büroassets aus dem Mockup-Stil als einzelne Assets erstellen.
