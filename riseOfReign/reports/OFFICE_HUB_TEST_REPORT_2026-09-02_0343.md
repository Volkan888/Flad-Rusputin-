# riseOfReign — Office Hub Test Report

Stand: 2026-09-02 03:43 CEST

## Scope

Geprüft wurde die 1933-Steuerzentrale jedes Players mit Fokus auf:

- exakt drei Bedienwege: `side_menu`, `room`, `phone_list`
- klickbare Büroobjekte und Zielrouten
- Räume und Raumfreischaltungen
- Macht-/Geld-/Aufrüstungsprogression
- Materialkosten, Bauzeiten und laufender Unterhalt
- Telefonkontakte und Optionen
- historische Startzustände der sechs historischen Avatare plus Custom Avatar
- Meetings zwischen Spielern
- Büro-Schäden, Evakuierung und provisorische Steuerzentrale
- Nachfolge/Avatarwechsel
- Mobile Bedienbarkeit und Fallback-Navigation
- API-Anbindung
- Regressionstests

## Gefundene und behobene Lücken

1. `archive_room` war als Upgrade referenziert, aber nicht als Raum definiert.
2. Die erste Fassung enthielt zusätzliche Interaktionstypen (`overlay`, `avatar_panel`, `state_panel`). Sie widersprachen der Produktregel, wonach jeder Klick in Side-Menü, zweiten Raum oder Telefonliste führt.
3. Telefonkontakte hatten noch keine einheitlichen Kategorien und Folgeoptionen.
4. Büro-Level hatten noch keinen vollständigen laufenden Unterhalt.
5. Evakuierung/Beschädigung brauchte einen Soft-Lock-Schutz, damit ein Spieler nie dauerhaft ohne Kernsteuerung bleibt.
6. Nachfolge musste zwischen staatlicher Infrastruktur und avatarbezogenen Objekten/Rechten unterscheiden.
7. Player-zu-Player-Meetings brauchten eine Privatsphärenregel für geheime Büroinhalte.
8. Der Server-Loader prüfte bisher nur die grobe Existenz von Feldern und fing fehlerhafte Objekt-/Raumreferenzen nicht vollständig ab.

Alle acht Punkte wurden im Milestone-16-Zyklus korrigiert.

## Verbindliche Interaktionsregel

Jedes anklickbare Objekt verwendet jetzt genau einen dieser Wege:

- `side_menu`: Büro bleibt sichtbar; rechts/seitlich öffnet sich der Kontext mit Status, Optionen, Kosten, Folgen und Bestätigung.
- `room`: Wechsel in einen zweiten Raum bzw. eine Raumansicht. Gesperrte Räume zeigen Anforderungen statt eines toten Klicks.
- `phone_list`: Kontaktliste -> Kontakt auswählen -> mögliche Gesprächs-/Meeting-/Anweisungsoptionen.

## Büroobjekte

Der maschinenlesbare Stand enthält 25 gemeinsame interaktive Objekte, darunter:

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
- Kalender/Uhr
- Besuchersessel
- Tür
- Tresor
- Bücherregal
- Avatarportrait
- Flagge/Staatssymbol
- Fenster
- Schreibmaschine
- Telegrammablage
- Tischglocke/Rufknopf
- Globus

## Räume

13 Raum-/Navigationsziele sind definiert:

- Raumauswahl
- Karten-/Lageraum
- Meetingraum
- Kabinettszimmer
- Archivraum
- Vorzimmer/Stab
- Kommunikationsraum
- Kriegsraum
- Forschungs-/Beraterzimmer
- Geheimdienstzimmer
- Konferenzraum
- Presse-/Rundfunkraum
- Krisen-/Schutzraum

## Progression

Büro-Level 0 bis 5 sind lückenlos definiert.

Ab höheren Stufen steigen nicht nur die Optik, sondern echte Fähigkeiten:

- Regierungs-/Ministerzugriff
- sichere Telefonleitung
- Stab/Vorzimmer
- Archiv
- strategischer Kartenraum
- Kommunikationsraum
- Kriegsraum
- Geheimdienst-/Forschungs-/Konferenzräume
- globale Logistik und Mehrfrontübersicht

Aufrüstung wirkt erst ab der strategischen Kommandoebene als Voraussetzung. Geld allein reicht nicht. Zusätzlich werden Autorität, Staatskapazität, Industrie, Logistik und militärische Kontrolle geprüft.

Büro-Upgrades werden ausschließlich über In-Game-Staatsressourcen finanziert; Echtgeldkauf ist ausdrücklich deaktiviert.

## Historische Startinvarianten

Automatisch abgesichert:

- Atatürk startet mindestens mit Regierungsbüro.
- Hitler startet am 1. Januar 1933 nicht mit Regierungsamt; Übergang frühestens über das Ereignis 30. Januar 1933.
- Stalin startet mit ausgebauter Führungs-/Apparatstruktur.
- Churchill startet ohne direktes Militärkommando.
- Roosevelt startet als President-elect; Übergang über 4. März 1933.
- Mussolini startet mit umfangreichem Regierungszugang.
- Custom Avatar wird aus Prolog, Herkunft und Beruf erzeugt.

## Telefon

9 Kontaktkategorien sind definiert:

1. persönliches Umfeld
2. Partei/Parlament
3. Regierung/Minister
4. Militärführung
5. Geheimdienst
6. Diplomatie/Botschaften
7. Forschung/Industrie
8. Regionen/Verwaltung
9. andere Spieler

Nach Auswahl eines Kontakts erscheinen kontextabhängige Möglichkeiten, darunter Anruf, Meeting, Bericht, Vorschlag, Nachricht und — nur bei vorhandener Autorität — Anweisung. Player-zu-Player-Kontakte können Handel, Diplomatie, Forschung und Hilfe anbahnen.

## Krieg, Schaden und Umzug

Büros können künftig Zustände annehmen:

- normal
- im Umbau
- beschädigt
- Evakuierung
- provisorisches Büro
- verlegt

Ein provisorisches Büro behält immer Telefon, Schreibtisch, Weltkarte und dringende Akten. Dadurch entsteht kein dauerhafter Gameplay-Soft-Lock.

## Nachfolge

Staatliche/institutionelle Räume bleiben bei einem Nachfolger grundsätzlich erhalten, sofern sie nicht zerstört wurden. Avatarportrait, persönliche Gegenstände, Kontakte und Autoritätszugriffe werden neu berechnet.

## Lokaler Testlauf

Ausgeführt mit Python 3.13 gegen einen lokalen Repo-Spiegel der aktuellen Office-/Manifest-/API-Struktur.

Ergebnis:

- 10 Tests ausgeführt
- 10 PASS
- 0 FAIL
- 0 ERROR

Geprüft wurden:

- Interaktionstypen
- Objekt-IDs und Routen
- Bürolevel/Kosten/Aufrüstung
- Raumreferenzen und Dead-End-Schutz
- Avatarabdeckung
- historische Startinvarianten
- Telefonfluss
- kein Pay-to-win
- Schaden/Umzug/Nachfolge
- Manifest-/API-Referenzen

## Server-Schutz

`OfficeHubContentLoader` validiert beim API-Start jetzt zusätzlich:

- exakt drei Interaktionstypen
- einzigartige Objekt-/Raum-IDs
- gültige Side-Menü-Routen
- gültige Raumziele
- gültige Upgrade-Ziele
- Level 0–5
- nichtnegative Bau-/Unterhaltskosten
- sieben Avatarbüros
- Signature-Object-Routen
- historische Hitler-/Roosevelt-/Churchill-Invarianten
- kein Echtgeldkauf
- Text-Fallback und No-Dead-End-Regel

Fehlerhafte Contentdaten degradieren den API-Healthstatus statt still weiterzulaufen.

## CI

Workflow hinzugefügt:

`.github/workflows/riseofreign-office-ci.yml`

Er soll bei weiteren Pushes auf `riseOfReign`:

1. die Python-Regressionstests ausführen,
2. .NET 10 einrichten,
3. die API kompilieren,
4. die API mit dem 1933-Content starten,
5. `/health`, `/api/v1/offices` und alle sieben Avatar-Endpunkte testen,
6. für unbekannte Avatare einen 404 erwarten.

## Lokale Tool-Grenze

Die ChatGPT-Laufzeit enthält derzeit kein `dotnet` und kein `godot`; deshalb konnte der .NET-/Godot-Build nicht lokal ausgeführt werden. Die Python-Contenttests wurden real ausgeführt und bestanden. Der GitHub-CI-Workflow wurde eingerichtet, um den fehlenden .NET-Build in einer geeigneten Runner-Umgebung abzudecken.

## Ergebnis

**OFFICE CONTENT: PASS**

Der Büro-Content ist für den aktuellen Designstand konsistent, navigierbar und gegen die wichtigsten Datenfehler abgesichert. Grafik/3D/2D-Assets werden bewusst später erstellt; die dafür notwendigen Interaktions-, Raum-, Progressions- und Avatar-Notizen sind bereits vorhanden.
