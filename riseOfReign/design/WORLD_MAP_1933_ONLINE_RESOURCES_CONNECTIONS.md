# riseOfReign — Online-Weltkarte 1933 mit Ressourcen, Verbindungen, Material und Bauzeit

Stand: 2026-09-02 03:08 CEST
Status: Milestone 12

## 1. Verbindliche Kartenentscheidung

RiseOfReign verwendet als Kartenbasis eine echte historische Weltkarte 1933 aus einer Onlinequelle. Die Karte wird nicht als neu erfundene Git-Karte behandelt.

Primäre Onlinequelle:
- Wikimedia Commons: `Political regime, World, 1933.svg`
- Datenquelle/Autor: Our World in Data
- Jahr: 1933
- Format: SVG
- Lizenz: Creative Commons Attribution 4.0 International (CC BY 4.0)
- Quellen-Seite: https://commons.wikimedia.org/wiki/File:Political_regime,_World,_1933.svg
- Original-Datenquelle: https://ourworldindata.org/grapher/political-regime?tab=map

Die Karten-Datei selbst bleibt online. Im Repository werden nur unsere Spielregeln, Overlaydaten und Quellen-/Lizenzinformationen gespeichert.

Warum diese Basis:
- reale Welt statt Fantasiekarte
- 1933 als passendes Startjahr
- SVG eignet sich für anklickbare Länder und Zoom
- historische Staaten können als Spielobjekte mit der Karte verbunden werden
- kommerzielle Nutzung und Bearbeitung sind unter CC BY 4.0 möglich, wenn die vorgeschriebene Namensnennung erfolgt

Im Spiel muss eine Credits-/Lizenzseite enthalten sein mit Hinweis auf Our World in Data/Wikimedia Commons, CC BY 4.0 und darauf, dass die Karte für RiseOfReign spielmechanisch überlagert bzw. angepasst wurde.

## 2. Kartenprinzip

Die Weltkarte bleibt geografisch real. RiseOfReign legt dynamische Layer darüber.

Layer:
1. politische Grenzen 1933
2. Besitz/Kontrolle
3. Bevölkerung
4. Rohstoffvorkommen
5. Industrie und Veredelung
6. Energie
7. Transportverbindungen
8. Handelsrouten
9. Militärlogistik
10. diplomatische Beziehungen
11. Unruhe/Stabilität
12. Krieg/Fronten
13. Geheimdienstinformationen
14. Bauprojekte

Die Layer können einzeln ein-/ausgeschaltet werden, damit die Mobile-Karte lesbar bleibt.

## 3. Zoomstufen

### Weltansicht
Zeigt:
- Länder
- Bündnisse
- Kriege
- globale Handelswege
- Hauptressourcen
- große Bauprojekte

### Landesansicht
Zeigt:
- Regionen
- Hauptstädte
- große Industriestädte
- Rohstoffregionen
- Häfen
- Flugplätze
- Eisenbahnkorridore
- Straßen
- Energie- und Treibstoffknoten

### Regionalansicht
Zeigt:
- Städte und strategische Knoten
- konkrete Produktionsstandorte
- Lager
- Fabriken
- Minen/Ölfelder
- Bahnhöfe
- Häfen
- Brücken
- lokale Straßen
- aktuelle Bauprojekte

## 4. Kartenobjekte

Jedes relevante Objekt besitzt mindestens:
- `id`
- `name`
- `country_id`
- `region_id`
- geografische Position
- Besitzer
- tatsächliche Kontrolle
- Zustand 0–100
- Kapazität
- aktuelle Produktion/Verbrauch
- Bau-/Upgrade-Stufe
- laufenden Unterhalt
- strategischen Wert

## 5. Ressourcen auf der Weltkarte

Ressourcen werden nicht pauschal einem ganzen Land zugeschrieben, sondern an reale oder abstrahierte geografische Ressourcenregionen gebunden.

### Primärressourcen
- Nahrungsmittel
- Kohle
- Rohöl
- Erdgas
- Eisenerz
- Nichteisenmetalle
- Holz
- Stein/Baustoffe

### Veredelte Ressourcen
- Treibstoff
- Stahl
- Chemikalien
- Industriegüter/Maschinen
- Konsumgüter
- medizinische Versorgung
- Militärmaterial

### Kapazitäten
- Bergbaukapazität
- Landwirtschaftskapazität
- Raffineriekapazität
- Stahlwerkskapazität
- Fabrikkapazität
- Energieerzeugung
- Hafenumschlag
- Bahntransport
- Straßentransport
- Schiffstransport

## 6. Ressourcen-Knoten

Ein Rohstoffsymbol auf der Karte ist ein `ResourceNode`.

Felder:
- Ressourcentyp
- Basisförderung pro Monat
- Reserve/Ergiebigkeit
- Erschließungsgrad 0–3
- benötigte Arbeitskräfte
- benötigte Energie
- benötigte Maschinen
- Transportanschluss
- Besitz
- Kontrolle
- Störungsgrad

Ohne Verbindung zu Bahn, Straße, Hafen oder Pipeline kann ein Rohstoff nur sehr eingeschränkt wirtschaftlich genutzt werden.

## 7. Logistikregel

Rohstoffe müssen vom Förderort zum Verbraucher gelangen.

Beispiel:

Ölfeld -> Pipeline/Bahn -> Raffinerie -> Treibstofflager -> Bahn/Straße/Hafen -> Armee/Fabrik/Stadt

Eisenerz -> Bahn -> Stahlwerk
Kohle -> Bahn -> Kraftwerk oder Stahlwerk
Stahl + Maschinen -> Baustelle/Fabrik/Werft
Nahrung -> Bahn/Straße/Hafen -> Stadt/Armee

Damit wird das Abschneiden einer Verbindung strategisch wichtiger als ein rein abstrakter Prozentmalus.

## 8. Verbindungstypen

Jede Verbindung besitzt:
- Startknoten
- Zielknoten
- Stufe
- Zustand
- Kapazität
- Materialkosten
- Geldkosten
- Arbeitskräftebedarf
- Bauzeit
- Unterhalt

### Straßen
Stufe 1: einfache Fernstraße
Stufe 2: ausgebaute Straße
Stufe 3: strategische Hauptverkehrsstraße

Effekte:
- Ziviltransport
- leichte Militärlogistik
- Nahrung/Konsumgüter
- Bauversorgung

### Eisenbahn
Stufe 1: Nebenbahn
Stufe 2: Hauptstrecke
Stufe 3: Hochkapazitätskorridor

Effekte:
- Kohle, Erz und Stahl
- schwere Industrie
- große Truppenbewegungen
- hohe Versorgungskapazität

### Seeweg
Benötigt Häfen.

Effekte:
- internationale Massengüter
- Öl
- Nahrung
- Erz
- Truppen-/Materialtransport

### Pipeline
Für:
- Rohöl
- Treibstoff
- später Gas

### Stromnetz
Verbindet Energieerzeugung mit Industrie und Städten.

### Telefon-/Telegrafienetz
Verbessert:
- Verwaltung
- Reaktionszeit
- Geheimdienst
- Mobilisierung
- Krisenmanagement

### Luftverbindung
Benötigt Flugplätze und Flugzeugkapazität.

Primär für:
- schnelle Personen-/Diplomatenbewegung
- Spezialtransporte
- spätere strategische Logistik

## 9. Standardmaterialien für Bau

Alle Werte sind normalisierte Spielpunkte (RP/ME), nicht reale Tonnen.

- Stahl
- Industriegüter/Maschinen
- Holz
- Stein/Baustoffe
- Chemikalien
- Treibstoff
- Geld/Staatskasse
- Arbeitskräfte

`Stein/Baustoffe` umfasst für die Spielbarkeit unter anderem Stein, Zement, Beton und vergleichbare Massenbaustoffe.

## 10. Bauzeiten

Eine Standardrunde entspricht einem Kalendermonat. Die folgenden Zeiten sind Basiswerte vor Boni/Mali.

| Projekt | Stahl | Maschinen | Holz | Baustoffe | Chemikalien | Geld | Arbeitskräfte | Basis-Bauzeit |
|---|---:|---:|---:|---:|---:|---:|---:|---:|
| einfache Straße, Segment | 1 | 1 | 2 | 3 | 0 | 4 | 3 | 2 Monate |
| ausgebaute Straße, Segment | 2 | 2 | 2 | 6 | 1 | 8 | 5 | 4 Monate |
| strategische Hauptstraße | 4 | 3 | 2 | 10 | 1 | 14 | 7 | 6 Monate |
| Nebenbahn, Segment | 6 | 4 | 3 | 5 | 1 | 12 | 7 | 6 Monate |
| Hauptbahn, Segment | 10 | 6 | 4 | 8 | 1 | 20 | 10 | 9 Monate |
| Hochkapazitätsbahn | 16 | 10 | 5 | 12 | 2 | 32 | 14 | 12 Monate |
| kleine Brücke | 5 | 2 | 3 | 5 | 0 | 8 | 5 | 4 Monate |
| große Brücke | 14 | 6 | 4 | 12 | 1 | 24 | 12 | 9 Monate |
| Tunnel/Pass-Ausbau | 12 | 8 | 4 | 15 | 3 | 30 | 15 | 12 Monate |
| kleiner Hafen-Ausbau | 10 | 6 | 5 | 15 | 1 | 25 | 12 | 10 Monate |
| großer Hafen-Ausbau | 24 | 14 | 8 | 30 | 3 | 55 | 22 | 18 Monate |
| kleine Werft | 18 | 15 | 8 | 20 | 2 | 45 | 20 | 18 Monate |
| große Werft | 40 | 30 | 12 | 35 | 4 | 90 | 35 | 30 Monate |
| Flugplatz | 6 | 6 | 3 | 8 | 1 | 16 | 8 | 6 Monate |
| großer Militär-/Verkehrsflugplatz | 14 | 12 | 5 | 15 | 2 | 32 | 14 | 10 Monate |
| Rohöl-Pipeline, Segment | 8 | 5 | 0 | 3 | 2 | 14 | 6 | 6 Monate |
| Stromleitung, Segment | 4 | 4 | 2 | 2 | 0 | 8 | 4 | 3 Monate |
| Telefon/Telegrafie, Segment | 2 | 3 | 2 | 1 | 0 | 6 | 3 | 2 Monate |
| Kohlemine erschließen | 5 | 7 | 4 | 5 | 1 | 15 | 10 | 8 Monate |
| Erzmine erschließen | 6 | 8 | 4 | 6 | 1 | 17 | 10 | 9 Monate |
| Ölfeld erschließen | 8 | 12 | 3 | 6 | 3 | 24 | 10 | 10 Monate |
| Raffinerie klein | 14 | 18 | 5 | 12 | 8 | 35 | 15 | 14 Monate |
| Raffinerie groß | 30 | 32 | 8 | 22 | 14 | 70 | 28 | 24 Monate |
| Kraftwerk klein | 12 | 15 | 4 | 15 | 2 | 30 | 15 | 12 Monate |
| Kraftwerk groß | 25 | 28 | 6 | 25 | 4 | 60 | 25 | 20 Monate |
| Stahlwerk | 30 | 30 | 8 | 25 | 6 | 70 | 30 | 24 Monate |
| zivile Fabrik | 16 | 22 | 8 | 15 | 3 | 42 | 20 | 15 Monate |
| Schwerindustriefabrik | 28 | 32 | 8 | 22 | 5 | 65 | 28 | 22 Monate |
| Lager/Depot | 5 | 4 | 5 | 8 | 0 | 12 | 7 | 5 Monate |
| strategisches Großdepot | 12 | 9 | 8 | 16 | 1 | 28 | 12 | 9 Monate |
| Befestigung Stufe 1 | 8 | 3 | 4 | 12 | 1 | 15 | 10 | 5 Monate |
| Befestigung Stufe 2 | 18 | 7 | 5 | 22 | 2 | 32 | 18 | 10 Monate |
| Befestigung Stufe 3 | 35 | 14 | 6 | 35 | 4 | 65 | 30 | 18 Monate |

## 11. Bauzeitformel

`effektive_bauzeit = basis_bauzeit × gelände × entfernung × krisenfaktor ÷ bauleistungsfaktor`

### Gelände
- Ebene: 1.00
- Wald: 1.10
- Hügelig: 1.20
- Gebirge: 1.50
- Wüste: 1.30
- Sumpf: 1.40
- extreme Kälte: 1.30

### Bauleistungsfaktor
Ergibt sich aus:
- Industriekapazität
- verfügbaren Maschinen
- Arbeitskräften
- Entwicklung
- Forschung
- Verwaltungseffizienz
- Avatar-/Ministerboni

Typischer Bereich: 0.65 bis 1.50.

Beispiel:
Eine Hauptbahn mit Basis 9 Monaten im Gebirge (1.50) bei guter Bauleistung (1.20):
`9 × 1.50 / 1.20 = 11.25`
=> 12 Spielrunden.

## 12. Fehlende Materialien

Ein Projekt startet regulär nur, wenn mindestens 50 % der benötigten Materialien reserviert sind.

Unter 100 % Materialdeckung:
- 75–99 %: +10 % Bauzeit
- 50–74 %: +30 % Bauzeit
- unter 50 %: Baustopp

Fehlende Maschinen sind besonders kritisch:
- unter 75 % Maschinenversorgung: zusätzliche +15 % Bauzeit
- unter 50 %: keine neue industrielle Großanlage startbar

## 13. Mehrere Bauprojekte gleichzeitig

Jedes Land besitzt `construction_capacity`.

Bauprojekte verbrauchen während ihrer Laufzeit Slots/Kapazität.

Zu viele parallele Projekte führen zu:
- Arbeitskräftemangel
- Maschinenknappheit
- höheren Kosten
- längeren Bauzeiten

Dadurch kann ein Spieler nicht in einer Runde überall gleichzeitig Bahn, Häfen, Fabriken und Festungen hochziehen.

## 14. Reparatur statt Neubau

Beschädigte Infrastruktur wird nach Zustand behandelt.

- 80–100: normal
- 60–79: leichte Kapazitätsverluste
- 40–59: deutlich eingeschränkt
- 20–39: kritischer Betrieb
- 1–19: praktisch ausgefallen
- 0: zerstört

Reparaturkosten:
- bis 80 Zustand: etwa 15 % der Neubaukosten
- bis 60 Zustand: etwa 30 %
- bis 40 Zustand: etwa 50 %
- zerstört: 70–100 %, abhängig vom Projekt

## 15. Verbindungskapazität

Jede Route bekommt `throughput` pro Monat.

Transportprioritäten kann der Spieler festlegen:
1. Zivilversorgung
2. Nahrung
3. Energie/Rohstoffe
4. Industrie
5. Militär
6. Export

Oder eigene Reihenfolge.

Wenn Kapazität nicht reicht, entstehen Engpässe an den Zielknoten.

## 16. Häfen und Seehandel

Ein Seeweg funktioniert nur zwischen geeigneten Häfen.

Hafenwerte:
- Umschlagkapazität
- Tiefgang/Schiffsgröße abstrahiert
- Lager
- Bahnanschluss
- Straßenanschluss
- Marine-/Luftschutz

Blockade, Krieg oder beschädigte Häfen reduzieren den Durchsatz.

## 17. Grenzüberschreitende Verbindungen

Internationale Bahn, Straße, Pipeline und Stromnetze benötigen:
- offene Grenze
- Abkommen oder Transitrecht
- ausreichende Beziehungen oder erzwungene Kontrolle

Transit kann Geld oder Diplomatiepunkte erzeugen.

Ein Land kann dadurch zu einem strategischen Transitstaat werden.

## 18. Bau im Ausland

Möglich über:
- Entwicklungsabkommen
- Allianz
- Konzession
- Protektorat
- Besatzung/Kontrolle

Der Finanzierer kann Gegenleistungen erhalten:
- bevorzugten Rohstoffzugang
- Transitkapazität
- politischen Einfluss
- Handelsrabatte

## 19. Ressourcenanzeige auf der Karte

Beim Tippen auf eine Region zeigt das Mobile-Panel:

- Besitzer/Kontrolle
- Bevölkerung
- Stabilität
- Rohstoffe
- monatliche Förderung
- Lager
- Fabriken
- Energie
- Straßen
- Bahn
- Hafen/Flugplatz
- aktive Bauprojekte
- Baufortschritt
- fehlendes Material
- erwartetes Fertigstellungsdatum

## 20. Bauanzeige

Eine aktive Baustelle erscheint als Karten-Overlay.

Beispiel:

`Ankara–Sivas Hauptbahn`
- Fortschritt: 63 %
- Restzeit: 4 Monate
- Stahl: vollständig
- Maschinen: 82 %
- Arbeitskräfte: vollständig
- aktueller Zustand: Bau aktiv

Andere Spieler sehen das Projekt nur abhängig von:
- öffentlicher Bekanntheit
- diplomatischen Informationen
- Handelsbeziehungen
- Geheimdienstaufklärung

## 21. Historische Kartenänderungen

Die Onlinekarte ist die Startgeometrie für 1933. Historische Ereignisse und Spielentscheidungen dürfen den politischen Overlayzustand verändern.

Beispiele:
- territoriale Kontrolle ändert sich
- Besatzungszonen entstehen
- Staaten werden annektiert oder verlieren Gebiete
- Bürgerkrieg erzeugt geteilte Kontrolle

Die Ausgangskarte wird nicht als unveränderliches Endergebnis behandelt. Spielverlauf und historische Ereignisse verändern Besitz-/Kontroll-Layer dynamisch.

## 22. Online-Abhängigkeit und Cache

Die kanonische Quelle bleibt online und wird nicht als Originalkartenasset im Git-Repository geführt.

Für Stabilität darf der Produktionsserver einen temporären/cachebaren Laufzeitstand laden, damit ein Ausfall der externen Quelle nicht laufende Matches zerstört. Dieser Cache gehört nicht als manuell bearbeitete Kartenquelle ins Git.

Bei jedem Import werden gespeichert:
- Quelle
- Abrufdatum
- Lizenz
- Dateihash
- Kartenjahr

## 23. Nicht zulässig

- keine Fantasiegrenzen zum Matchstart
- keine modernen Grenzen als 1933-Ausgangskarte
- keine frei erfundenen Rohstoffvorkommen ohne Balancing-/Quellenkennzeichnung
- keine Teleport-Logistik
- keine sofort fertiggestellten Großprojekte
- keine Infrastruktur ohne Material-, Geld- und Arbeitskräftebedarf

## 24. Nächster Implementierungsschritt

1. Online-SVG Loader/Cache
2. Länderpolygon-ID-Mapping auf interne `country_id`
3. Karten-Layer-System
4. `ResourceNode`-Datenmodell
5. `Connection`-Datenmodell
6. `ConstructionProject`-Datenmodell
7. Route/Throughput-Resolver
8. Mobile-Kartenpanel
9. 1933 Ressourcen-Startdaten je Land/Region
10. historische Grenzänderungs-Events