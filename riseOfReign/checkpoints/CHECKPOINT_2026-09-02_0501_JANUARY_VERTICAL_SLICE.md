# riseOfReign — Milestone 18 Final

Stand: 2026-09-02 05:01 CEST

## Ergebnis
Der erste Hauptspielmonat Januar 1933 ist als funktionaler Vertical Slice implementiert und getestet.

## Spielablauf
1. Avatar wählen.
2. Persönliches Büro am 1. Januar 1933 laden.
3. Avatar-spezifischen Lagebericht lesen.
4. Verpflichtende Büroentscheidung treffen.
5. Telefon-/Meeting-Aktion wählen.
6. Weltkarten-/Ressourcenaktion wählen.
7. Januar serverseitig auflösen.
8. Entscheidungseffekte auf Indikatoren anwenden.
9. Historische Januar-Anker automatisch anwenden.
10. Monatsbericht erzeugen.
11. Datum auf 1. Februar 1933 setzen.
12. Büro-Level bei historischem institutionellem Wechsel aktualisieren.

## Avatar-Slices
Vorhanden für:
- Atatürk / Türkei
- Hitler / Deutschland
- Stalin / Sowjetunion
- Churchill / Vereinigtes Königreich
- Roosevelt / USA
- Mussolini / Italien
- Custom Avatar

## Historische Invarianten
- Hitler startet am 1. Januar 1933 ohne Regierungsbüro; der historische Anker am 30. Januar kann Büro-Level 1 freischalten.
- Roosevelt bleibt im Januar President-elect; volle Präsidialmacht beginnt nicht vor 4. März.
- Churchill bleibt im Januar außerhalb der Regierung und besitzt kein direktes Militärkommando.
- Die sowjetische Versorgungskrise wird als humanitäre Belastung modelliert und nicht als reiner Bonus.
- Historische Eckdaten werden nicht durch freie Spielerwahl gelöscht; Entscheidungen verändern die strategischen Auswirkungen darum herum.

## Neue Content-Datei
`riseOfReign/data/epochs/1933/months/january.json`

## Neue Serverlogik
`January1933Service` lädt, validiert und löst den Monatscontent auf.

API:
- `GET /api/v1/months/1933-01/{avatarId}`
- `POST /api/v1/months/1933-01/{avatarId}/resolve`

## Godot-Client
Das interaktive Büro enthält jetzt:
- Januar-Lagebericht
- Entscheidungsauswahl
- Telefonphase
- Karten-/Ressourcenphase
- Abschlussvalidierung
- POST-Auflösung
- Monatsbericht
- Übergang auf 1. Februar 1933

Finale Büro-/Avatar-Grafiken sind weiterhin bewusst nicht Bestandteil dieses Meilensteins.

## Tests
GitHub Actions Run: `33585088640`
Ergebnis: SUCCESS

Erfolgreich:
- 24 Python-/Content-/Client-Vertragstests
- Godot 4.7.2 stable headless parse
- .NET 10 restore
- .NET 10 release build
- API startup
- health smoke test
- Office API smoke tests
- January API GET/POST smoke tests für alle sieben Avatare
- historischer Hitler-Büroübergang geprüft
- fehlende Pflichtentscheidung ergibt HTTP 400

## Behobener Fehler während der Prüfung
Der erste .NET-CI-Lauf fand einen ungültigen C#-Ausdruck (`?? continue`) im Januar-Resolver. Der Fehler wurde korrigiert und der vollständige CI-Lauf anschließend erfolgreich wiederholt.

## Nächster Meilenstein
Milestone 19 sollte den Januar-Vertical-Slice ausbauen von einer stateless Monatsauflösung zu einem echten gespeicherten 4-Spieler-Matchzustand:
- Lobby / Match erstellen
- vier Player-Slots
- persistente Spieler- und Länderzustände
- simultane Befehlsabgabe
- Spieler-zu-Spieler-Telefon/Meeting-Anfragen
- gemeinsame Monatsauflösung
- Savegame / Resume

Danach kann Februar 1933 als zweiter Monatscontent auf denselben generischen Match-Unterbau gesetzt werden.
