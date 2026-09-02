# riseOfReign — Mobile UX, Visual & Audio Product Spec

Stand: 2026-09-02 02:56 CEST

## Ziel

Dieses Dokument schließt die offenen Produktfragen für die Mobile-Oberfläche, Karteninteraktion, Telefon-/Meeting-Erlebnis, Grafikstil, Audio und Tutorialführung.

---

# 1. Geräteausrichtung

Primär: **Portrait Mobile**.

Warum:
- Telefon-/Telegramm-Interaktionen wirken natürlich.
- Ressourcen und Entscheidungen lassen sich gut als Karten/Sheets darstellen.
- Einhandbedienung ist möglich.

Optional später:
- Landscape auf Tablets
- Desktop-Layout

---

# 2. Hauptnavigation

Bottom Navigation mit fünf Hauptbereichen:

1. **Welt**
2. **Land**
3. **Macht**
4. **Diplomatie**
5. **Berichte**

Telefonereignisse und kritische Krisen können als Overlay darüber erscheinen.

---

# 3. Weltkarte

## Weltansicht

Zeigt:
- Staaten
- Spielerfarben/Avatare
- diplomatische Beziehungen
- Kriege/Krisen
- Haupthandelsrouten

Interaktion:
- Tap auf Land → Länderkarte
- Long Press → Schnellinfos
- Filterbutton → Ressourcen/Militär/Diplomatie/Unruhe/Handel

## Länderansicht

Zeigt strategische Regionen.

Region-Karte:
- Bevölkerung
- Ressourcen
- Industrie
- Infrastruktur
- Unruhe
- Truppen

## Regionsansicht

Zeigt:
- Städte
- Häfen
- Minen
- Fabriken
- Bahn/Route

## Stadtansicht

Nur strategische Zonen:
- Regierung
- Hafen
- Industrie
- Finanzzentrum
- Forschung
- Logistik

Keine unnötige Häuser-Mikrosimulation.

---

# 4. HUD

Obere Schnellleiste:

- Staatskasse
- Nahrung
- Energie
- Treibstoff
- Stahl
- Industrie
- Forschung
- Stabilität

Bei Tap öffnet sich ein Bottom Sheet mit:
- Bestand
- Produktion
- Verbrauch
- Reserve
- Trend
- wichtigste Ursachen

Beispiel:

```text
Treibstoff 42 / 80
Produktion +6
Verbrauch -9
Netto -3 / Runde
Reserve reicht ca. 7 Runden
Hauptursache: Militärmobilisierung
```

Damit versteht der Spieler nicht nur die Zahl, sondern warum sie steigt oder fällt.

---

# 5. Avatarbereich

Avatar oben links/rechts als Portraitchip.

Tap öffnet:
- Alter
- Gesundheit
- Autorität
- Traits
- institutioneller Einfluss
- persönliche Beziehungen
- aktuelle Risiken

Persönliche Macht und Staatswerte bleiben visuell getrennt.

---

# 6. Prolog

Prolog wird als Kombination aus:
- kurzer Szene
- historischer Karte
- Portrait
- wenigen Entscheidungen
- Timeline

präsentiert.

## Geburtsszene

Beispielstruktur:

```text
1882 · Hyde Park, New York
Springwood

Franklin Delano Roosevelt wird in die wohlhabende
Roosevelt-Familie geboren.

Familie: +Netzwerk
Bildungszugang: Hoch
Gesundheitsereignisse: später möglich
```

Danach 1–3 Entscheidungen pro Lebensabschnitt.

Der Prolog soll ca. 10–20 Minuten dauern, nicht mehrere Stunden.

---

# 7. Telefon-System

Telefon ist eines der Signaturfeatures.

## Incoming Call

Bildschirm:
- vibrierendes/animiertes Telefon
- Name/Funktion des Anrufers
- Dringlichkeit
- „Annehmen“ / „später“ nur wenn Event Zeit erlaubt

## Gespräch

Portrait/Silhouette des Gesprächspartners + Dialog.

Antwortmöglichkeiten:
- direkt
- ausweichend
- zustimmen
- ablehnen
- Gegenangebot
- weitere Informationen verlangen

Bei wichtigen Gesprächen beeinflussen:
- Charisma
- Beziehung
- Information
- Autorität
- vorherige Versprechen

## Geheimdienstanruf

Zeigt keine operative Anleitung.

Stattdessen:
- strategische Lage
- Risiko
- Kosten
- mögliche politische Folgen
- abstrakte Auswahl

---

# 8. Meetings

Meetings sind die tiefere Diplomatieebene.

## Termin erstellen

- Teilnehmer
- öffentlich/geheim
- Ort symbolisch
- Agenda

## Meeting-Screen

Vier Bereiche:
1. Teilnehmerportraits
2. Agenda
3. Vertragsentwurf
4. Gesprächs-/Entscheidungsverlauf

Verträge können live angepasst werden:
- Menge
- Preis
- Dauer
- Garantien
- Forschungsteilung
- Transit

Spieler bestätigen separat.

---

# 9. Rundenbericht

Nach jeder Monatsrunde erscheint kein Zahlenfriedhof.

## Top 5 Änderungen

Beispiel:

1. Industrie +4 — neues Werk im Ruhrgebiet
2. Treibstoff -8 — Mobilisierung
3. Beziehung Italien +6 — Handelsvertrag
4. Unruhe +5 — Lebensmittelpreise Berlin
5. Forschung +3 — Chemieprogramm

Darunter:
- Ereignisse
- geheime Meldungen
- Weltreaktionen
- nächste Fristen

---

# 10. Ereigniskarten

Jede Eventkarte enthält:
- Datum
- Ort
- Titel
- 2–4 Sätze Kontext
- Auswirkungen
- verfügbare Entscheidungen

Historische Anker erhalten Kennzeichnung:
**Historischer Anker**

Alternative Ereignisse:
**Alternative Entwicklung**

---

# 11. Handel

Handelsscreen zeigt:
- eigene Überschüsse
- eigene Engpässe
- bekannte Angebote
- bestehende Verträge
- Routenkapazität

Schnellaktion:

```text
Öl benötigt: 12 RP/Runde
Bekannte Anbieter:
USA   Preis 1.0x  Beziehung 0
USSR  Preis 0.9x  Beziehung -15
```

Nicht alle Angebote sind sichtbar, wenn Informations-/Diplomatiezugang fehlt.

---

# 12. Forschung

Forschungsbaum nicht als gigantischer PC-Tree.

Mobile-Aufteilung:
- Industrie
- Infrastruktur
- Militär
- Staat/Gesellschaft
- Geheimdienst

Jeder Bereich besitzt eine vertikale Timeline.

Karte zeigt:
- Voraussetzungen
- FP-Kosten
- Geld
- Fachkräfte
- Dauer
- Effekte

---

# 13. Militär-UI

Kein Mikromanagement einzelner Soldaten.

Ansicht:
- Front/Region
- Verbände
- Versorgung
- Moral
- Bereitschaft

Vor einer Aktion zeigt das Spiel:

```text
Einschätzung: günstig / ausgeglichen / riskant / sehr riskant
Informationsqualität: 62%
Versorgung: 84%
Treibstoffreserve: 6 Runden
```

Keine falsche Scheingenauigkeit wie „73,482 % Siegchance“.

---

# 14. Geheimdienst-UI

Länderprofil mit Informationsringen:
- Politik
- Wirtschaft
- Militär
- Forschung

Beispiel:

```text
Deutschland
Wirtschaft: 72% bekannt
Militär: 38% bekannt
Forschung: 21% bekannt
Politik: 81% bekannt
```

Je geringer die Information, desto breiter die Schätzspanne.

---

# 15. Regierungs-/Machtansicht

Visualisierung als Machtkreis:

- Regierung
- Partei
- Militär
- Geheimdienst
- Wirtschaft
- Öffentlichkeit
- Ausland

Der Spieler sieht sofort, wo sein Avatar Macht besitzt und wo nicht.

Churchill 1933 beispielsweise:
- Regierung niedrig
- Parlament mittel
- Öffentlichkeit mittel
- Außenpolitikwissen hoch

---

# 16. Grafikstil

## Grundlook

**Historischer Archivstil + moderne Strategy-UI.**

- leicht strukturierte Kartenoberflächen
- dezente Papier-/Dokumentenästhetik
- klare moderne Typografie
- stilisierte Portraitillustrationen
- Länderfarben zurückhaltend

Keine Comic-Parodie historischer Tragödien.

## Portraits

- semi-realistische Illustration
- konsistente Perspektive
- zeitgemäße Kleidung
- unterschiedliche Altersstufen im Prolog

## Historische Diktatoren

Darstellung sachlich; keine heroischen Licht-/Pose-Kompositionen, die Propagandabilder imitieren.

---

# 17. Logo-/Brandingrichtung

Name:
**riseOfReign**

Logoidee:
- Wortmarke
- stilisierte Krone/Machtlinie nur abstrakt
- Kartengitter/Globus als sekundäres Element

Keine direkte Symbolik realer extremistischer Organisationen im Hauptbranding.

---

# 18. Audio

## Musikzustände

1. Hauptmenü — ruhige politische Spannung
2. Prolog — regions-/epochenabhängig
3. Frieden — strategisch ruhig
4. Krise — reduzierte Spannung
5. Krieg — ernst, rhythmisch, nicht triumphal
6. Niederlage/Kollaps — zurückhaltend

## UI-Sounds

- Telefon
- Telegramm/Nachricht
- Vertragsstempel
- Map-Tap
- Forschung abgeschlossen
- Rundenwechsel

## Voice

Optional später:
- Erzähler
- fiktive Minister-/Beraterstimmen

Historische Avatare sollten nicht ohne Rechte-/Ethikprüfung mit täuschend echten Voice-Clones simuliert werden.

---

# 19. Accessibility

- Textskalierung
- hohe Kontrastoption
- Farbblind-Modi
- Icons/Muster zusätzlich zu Farben
- Untertitel für alle gesprochenen Inhalte
- reduzierte Animation
- Vibration abschaltbar
- Touchziele mindestens mobile-tauglich groß

---

# 20. Tutorialführung

Tutorial ist Teil des Prologs.

## Lektionen

1. Geburt → Traits
2. Schule/Ausbildung → Entwicklung/Forschung
3. Karriere → Einfluss/Autorität
4. erster politischer Kontakt → Telefon
5. erster Vertrag → Diplomatie
6. 1. Januar 1933 → Karte/Ressourcen
7. erster Monat → kompletter Turn

Danach keine erzwungenen Tutorial-Popups mehr.

---

# 21. Notifications

Push nur für:
- Turn verfügbar
- Deadline
- Meeting
- Telefon
- Vertrag

Geheime Inhalte nie vollständig im Lock-Screen-Text.

Beispiel:
„riseOfReign: Neue vertrauliche Nachricht verfügbar.“

Nicht:
„Stalin plant Angriff auf Region X.“

---

# 22. Monetarisierungsgrundsatz

Falls später monetarisiert:
- keine gekauften Ressourcen
- keine gekauften Siegchancen
- keine stärkeren historischen Avatare gegen Echtgeld

Vertretbar:
- kosmetische UI-Themes
- zusätzliche Epochen/Szenarien als Contentpakete
- optionale Portrait-/Chronikdarstellung

Ranked/kompetitive Matches bleiben Pay-to-Win-frei.

---

# 23. First-Session Flow

```text
Start
→ Login/Gasttest
→ Neues Match
→ 4-Spieler-Lobby oder KI
→ Epoche 1933
→ Avatar-Draft
→ Geburts-/Lebensprolog
→ Weltlage 1. Januar 1933
→ erster Lagebericht
→ erste Monatsplanung
→ Telefon/Diplomatie
→ Runde bestätigen
→ Ergebnisbericht
```

---

# 24. UX-Abnahmekriterien MVP

MVP gilt UX-seitig als spielbar, wenn ein Nutzer ohne Entwicklerhilfe:

- Lobby erstellen kann
- Avatar wählen kann
- Prolog beenden kann
- Weltkarte versteht
- Ressourcenknappheit erkennt
- Budget verteilen kann
- Forschung starten kann
- Handelsangebot senden kann
- Telefon beantworten kann
- Runde abschließen kann
- Rundenfolgen nachvollziehen kann

## Status

Die bislang offenen UI-, Grafik-, Audio-, Telefon-, Meeting- und Tutorial-Grundregeln sind damit spezifiziert.