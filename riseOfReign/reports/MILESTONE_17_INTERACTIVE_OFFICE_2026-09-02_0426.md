# riseOfReign — Milestone 17: Interactive Office Vertical Slice

Stand: 2026-09-02 04:26 CEST

## Ergebnis

Der erste echte spielbare Mobile-Client-Ablauf für die persönliche Steuerzentrale ist umgesetzt.

### Avatar-Auswahl

Der Godot-Startscreen enthält sieben Slots:
- Mustafa Kemal Atatürk
- Adolf Hitler
- Joseph Stalin
- Winston Churchill
- Franklin D. Roosevelt
- Benito Mussolini
- Custom Avatar

Nach Auswahl wird die persönliche Steuerzentrale des Avatars geöffnet.

### Büro-Client

Der OfficeHub lädt seine Daten über:

`GET /api/v1/offices/{avatarId}`

und zeigt den historischen Startzustand am 1. Januar 1933.

Implementierte Interaktionswege:
1. Side-Menü
2. zweiter Raum
3. Telefonliste

Keine vierte Interaktionsart wird für Büroobjekte verwendet.

### Anklickbare Büroobjekte

Die bereits definierten Shared Objects und das persönliche Signaturobjekt des Avatars werden als interaktive Platzhalter dargestellt. Finalgrafiken folgen später.

Beispiele:
- Telefon
- Weltkarte
- Schreibtisch
- dringende Akten
- Aktenschrank
- Radio
- Zeitung
- Budgetbuch
- Militärmappe
- Forschungsmappe
- Diplomatenmappe
- Geheimakte
- Kalender
- Uhr
- Besuchersessel
- Tür
- Tresor
- Bücherregal
- Avatarbild
- Flagge/Staatssymbol
- Fenster
- Schreibmaschine
- Telegrammablage
- Rufknopf
- Globus
- avatar-spezifisches Signaturobjekt

### Telefon

Telefon öffnet Kategorien und danach Aktionsmöglichkeiten.
Andere Spieler besitzen eigene Multiplayer-Optionen für:
- Anrufen
- Meeting anfragen
- Handel vorschlagen
- Diplomatie vorschlagen
- gemeinsame Forschung vorschlagen
- Hilfe anbieten/anfragen
- Warnung/Protest
- Nachricht

Die eigentliche Match-/Vertragsaktion wird im nächsten Gameplay-Meilenstein serverautoritativ umgesetzt.

### Räume

Die Tür öffnet die Raumauswahl. Räume werden abhängig vom aktuellen Büro-Level freigeschaltet oder gesperrt dargestellt.

Der Spieler kann innerhalb eines freigeschalteten Raums dessen Funktionsbereiche anwählen und jederzeit ins Hauptbüro zurückkehren.

Unterstützte Raumdaten umfassen u. a.:
- Karten-/Lageraum
- Meetingraum
- Kabinettszimmer
- Archiv
- Vorzimmer/Stab
- Kommunikationsraum
- Kriegsraum
- Forschungsraum
- Geheimdienstzimmer
- Konferenzraum
- Presse-/Rundfunkraum
- Krisen-/Schutzraum

### Büro-Ausbau

Im Büro kann die Progression Level 0–5 angezeigt werden.
Die Freischaltung bleibt an Amt, Macht, Geld, Ressourcen, Aufrüstung, Industrie und Logistik gebunden; Finalaktionen werden später vom Server validiert.

## Konfiguration

Godot-Version: 4.7.x, validiert mit Godot 4.7.2-stable.

Standard-API:
`http://127.0.0.1:8080`

Konfigurierbar über:
`riseofreign/network/api_base_url`

## Tests

### Python Contract Tests

- Office Content Tests: PASS
- Office Client Contract Tests: PASS

### Godot

Godot 4.7.2-stable wurde im GitHub-CI aus dem offiziellen Godot-Release geladen und per SHA-256 geprüft.

Headless-Parse:
`godot --headless --path riseOfReign/client --editor --quit`

Ergebnis: PASS.

### .NET / API

- .NET 10 Restore: PASS
- .NET 10 Release Build: PASS
- API Start: PASS
- `/health`: PASS
- `/api/v1/offices`: PASS
- alle sieben `/api/v1/offices/{avatarId}`: PASS
- unbekannter Avatar liefert 404: PASS

## Noch bewusst nicht Bestandteil dieses Meilensteins

- finale 1933-Bürografiken
- echte Avatarportraits im Raum
- Sound/Telefonklingeln
- Animationen
- serverseitige Spieleraktionen aus Side-Menüs
- reale Kontaktinstanzen pro Match
- Vertrags-/Meeting-Engine
- Wirtschaftsbefehle aus dem Büro
- Kartenraum mit sichtbarer Online-Weltkarte
- Persistenz des aktuellen Raums/UI-Zustands

## Nächster Gameplay-Meilenstein

**Januar 1933 als erste vollständige Runde:**

Avatarwahl → Büro → Lagebericht → Telefon/Meeting → Entscheidung → Weltkarte/Ressourcen → Monatsauflösung → Ereignis → Februar 1933.
