# riseOfReign — Persönliche Steuerzentrale / Büro 1933

Stand: 2026-09-02 03:28 CEST
Status: Milestone 15

## 1. Grundidee

Jeder Spieler besitzt eine persönliche, vollständig anklickbare Steuerzentrale im Stil des Jahres 1933. Sie ist nicht nur Menü-Hintergrund, sondern die zentrale Diegese des Spiels: Der Spieler führt Staat, Partei, Diplomatie, Militär, Forschung und Geheimdienst aus einem historischen Büro heraus.

Jeder historische Avatar erhält ein eigenes Büro mit:
- eigenem Portrait / Bild des Avatars
- zeittypischer Landesflagge bzw. staatlicher Symbolik
- Schreibtisch
- Telefon
- Weltkarte an der Wand
- Aktenschrank / Archiv
- Radio
- Dokumenten und Posteingang
- Kalender / Uhr
- Sitzgruppe für Besucher
- Bücher / persönliche Gegenstände
- Beleuchtung und Dekor passend zu Land, Amt und sozialer Stellung

Die Grafik wird später produziert. Dieses Dokument definiert vorher verbindlich, **welches Objekt welche Funktion besitzt**, welche Räume existieren und wie sich die Steuerzentrale entwickelt.

## 2. Wichtigste Designregel

Die Büros sind nicht von Anfang an gleich groß oder mächtig.

Der Zustand des Büros folgt:
- tatsächlichem Amt des Avatars
- persönlicher Autorität
- Staatskasse / persönlichem Machtbudget
- Regierungseinfluss
- Militäreinfluss
- Aufrüstung / militärischer Kapazität
- Industrie- und Infrastrukturstand
- Geheimdiensteinfluss
- Kriegszustand
- Prestige
- historischen Ereignissen

Damit wird Macht **sichtbar**.

Ein Spieler mit wenig Geld, schwacher Autorität und ohne Regierungsamt hat ein kleineres Büro und weniger direkte Zugänge. Ein mächtiger Staatschef kann später mehrere Nebenräume, Mitarbeiter, sichere Leitungen und einen großen Lage-/Kartentisch freischalten.

## 3. Drei Interaktionsformen

Jedes anklickbare Objekt führt genau in eine der folgenden UX-Arten:

### A. Side Menu / Side Panel
Für schnelle Verwaltung ohne Raumwechsel.

Beispiele:
- Aktenschrank
- Kalender
- Ressourcenmappe
- Posteingang
- Budgetbuch
- Personalakte

### B. Zweiter Raum
Für Systeme, die räumlich und spielerisch größer sind.

Beispiele:
- Karten-/Lageraum
- Kabinettszimmer
- Geheimdienstzimmer
- Kommunikationsraum
- Militär-/Kriegsraum
- Archiv
- Forschungs-/Beraterzimmer

### C. Telefon-/Kommunikationsliste
Telefon anklicken → Liste verfügbarer Kontakte → Kontakt auswählen → Gespräch → Optionen.

Die Liste ist dynamisch und hängt von Beziehungen, Amt, Geheimdienstinformationen, Bündnissen und aktuellen Ereignissen ab.

## 4. Kernobjekte im Hauptbüro

| Objekt | Klick-Ergebnis | Hauptsystem |
|---|---|---|
| Telefon | Kontaktliste / eingehende Anrufe | Diplomatie, Militär, Geheimdienst, Minister |
| Weltkarte an der Wand | Kartenraum bzw. Vollbild-Weltkarte | Welt, Ressourcen, Truppen, Handel |
| Schreibtisch | Side Panel | aktuelle Entscheidungen / Signaturen |
| rote/lederne Aktenmappe | Side Panel | dringende Ereignisse |
| Aktenschrank | Side Panel oder Archivraum | Berichte, Verträge, Dossiers |
| Radio | Side Panel / Audio-Ereignis | Nachrichten, Propaganda, öffentliche Lage |
| Zeitung | Side Panel | internationale und nationale Presse |
| Budgetbuch | Side Panel | Staatskasse, Einnahmen, Ausgaben, Schulden |
| Militärmappe | Side Panel, später Kriegsraum | Streitkräfte, Aufrüstung, Versorgung |
| Forschungsmappe | Side Panel, später Beraterraum | Forschung, Wissenschaftler, Projekte |
| Diplomatenmappe | Side Panel | Beziehungen, Botschaften, Verträge |
| Geheimakte | Side Panel, später Geheimdienstzimmer | Geheimdienstlage |
| Kalender | Side Panel | Runde, Termine, Meetings, Fristen |
| Uhr | Tooltip / Zeitstatus | aktueller Monat / Runde / Deadlines |
| Besucher-Sessel | Meeting-Einstieg | persönliche Gespräche im Büro |
| Tür | Raumwahl | freigeschaltete Nebenräume |
| Safe/Tresor | Side Panel | geheime Dokumente, Sonderreserven |
| Bücherregal | Side Panel | Historie, Gesetz, Forschung, Traits |
| Portrait des Avatars | Avatarpanel | Gesundheit, Alter, Traits, Autorität |
| Flagge / Staatswappen | Staatspanel | Regierungsform, Legitimität, Institutionen |
| Fenster | Lage-/Atmosphäre-Event | Unruhe, Luftalarm, Wetter, Demonstrationen |

## 5. Schreibtisch als Entscheidungskern

Der Schreibtisch zeigt physisch maximal 3–5 aktive Gegenstände, damit der Screen nicht überladen ist.

Mögliche Objekte:
- zu unterschreibendes Gesetz
- Handelsvertrag
- Geheimdienstbericht
- Haushaltsentwurf
- Mobilisierungsbefehl
- Forschungsfreigabe
- Einladung eines anderen Avatars

Tap auf Dokument:
1. Kurzbeschreibung
2. Kosten
3. Voraussetzungen
4. erwartete Folgen
5. bekannte Risiken
6. Entscheidung
7. ggf. Rückfrage oder Telefonat

Dokumente können liegen bleiben, wenn keine sofortige Frist besteht.

## 6. Telefon — Signaturmechanik

### Telefon-Hauptliste
Mögliche Kategorien:
- eigener Regierungsstab
- Außenministerium
- Finanzministerium
- Wirtschaftsministerium
- Militärführung
- Geheimdienst
- Forschung / Wissenschaft
- regionale Führung
- ausländische Staatschefs
- Botschafter
- Verbündete
- neutrale Kontakte
- geheime / einmalige Kontakte

### Kontaktstatus
Jeder Kontakt zeigt:
- verfügbar / nicht verfügbar
- Beziehung
- Dringlichkeit
- Vertrauen
- letzte Interaktion
- laufende Vereinbarungen

### Gesprächsoptionen
Je nach Kontakt:
- Informationen anfordern
- Meeting vereinbaren
- Handelsangebot
- Forschung anbieten
- Unterstützung erbitten
- Kredit / Hilfe
- Bündnisfrage
- Warnung / Protest
- Vermittlung
- Gegenangebot
- interne Weisung
- Priorität ändern

### Eingehende Anrufe
Bei Krisen kann das Telefon sichtbar klingeln.
Nicht jeder Anruf kann ignoriert werden. Kritische Events erhalten Deadline.

## 7. Wandkarte

Klick auf Wandkarte:
- zuerst kurze Zoom-Animation
- dann Weltkartenansicht 1933

Filter:
- politische Kontrolle
- Ressourcen
- Handel
- Infrastruktur
- Eisenbahn
- Straße
- Häfen
- Pipelines
- Industrie
- Militär
- Fronten
- Diplomatie
- Unruhe
- Bauprojekte
- Geheimdienstwissen

Bei wachsender Macht kann aus der einfachen Wandkarte ein eigener **Karten-/Lageraum** werden.

## 8. Aktenschrank / Archiv

Frühe Stufe: Side Panel.
Spätere Stufe: eigener Archivraum.

Ordner:
- Innenpolitik
- Außenpolitik
- Handel
- Militär
- Forschung
- Geheimdienst
- Personen
- Länder
- Verträge
- Ereignisarchiv

Geheimdienstberichte können unvollständig oder falsch sein. Der Spieler sieht eine Informationssicherheitsskala.

## 9. Radio und Zeitung

### Radio
- Nachrichtenmeldungen
- Reden
- Kriegsmeldungen
- internationale Ereignisse
- eigene öffentliche Kommunikation

### Zeitung
Zeigt Ereignisse aus öffentlicher Perspektive.
Kann vom tatsächlichen internen Lagebild abweichen.

Dadurch erhält der Spieler zwei Informationswelten:
- **öffentlich bekannt**
- **intern bekannt**

## 10. Nebenräume

### 10.1 Karten-/Lageraum
Freischaltung durch steigende Autorität bzw. Regierungszugang.

Enthält:
- großen Kartentisch
- Weltkarte
- Ressourcenlage
- Logistik
- Truppen
- Bauprojekte
- Routen

### 10.2 Kabinettszimmer
Enthält:
- Minister
- Abstimmungen
- Regierungsvorlagen
- Budget
- innenpolitische Konflikte

### 10.3 Kommunikationsraum
Enthält:
- mehrere Telefonleitungen
- Telegrafie/Funk
- Botschaftskontakte
- militärische Kommunikation

Vorteil: mehr gleichzeitige Kontakte und schnellere Reaktionen.

### 10.4 Geheimdienstzimmer
Enthält nur abstrahierte Strategieentscheidungen:
- Lagebilder
- Netzwerke
- Gegenspionage
- Informationsoperationen
- Schutz wichtiger Personen

### 10.5 Militär-/Kriegsraum
Nicht automatisch 1933 vorhanden.
Freischaltung durch Kombination aus Regierungsautorität, Militäreinfluss, Aufrüstung und Budget.

Enthält:
- Streitkräfteübersicht
- Versorgung
- Mobilisierung
- Fronten
- Reserven
- Produktionsaufträge
- strategische Planungen

### 10.6 Forschungs-/Beraterzimmer
- Forschungsprojekte
- Wissenschaftler
- gemeinsame Forschung
- technologische Beratung

### 10.7 Empfangs-/Meetingraum
- bilaterale Treffen
- Botschafter
- Minister
- Wirtschaftsdelegationen

### 10.8 Krisen-/Schutzraum
Später bei Krieg/Bedrohung möglich.
Keine reine kosmetische Erweiterung: reduziert Ausfallrisiken der Führung und hält Kommunikation in Krisen aufrecht.

## 11. Büro-Progression durch Macht, Geld und Aufrüstung

### Stufe 0 — Privates / politisches Büro
Voraussetzung: Start ohne volle Staatsführung.

Merkmale:
- kleiner Schreibtisch
- ein Telefon oder Vermittlungsanschluss
- begrenzte Akten
- Karte
- wenige Mitarbeiter

Gameplay:
- reduzierte direkte Befehlsgewalt
- stärker über Kontakte / Partei / Parlament / Netzwerk agieren

### Stufe 1 — Regierungsbüro
Voraussetzung:
- offizielles Regierungsamt ODER ausreichender Regierungseinfluss
- Autorität ≥ ungefähr 35

Neue Funktionen:
- direkter Ministerkontakt
- Budgetmappe
- Staatsberichte
- Kabinettszugang

### Stufe 2 — Erweiterte Staatskanzlei
Voraussetzung:
- Autorität ≥ ungefähr 55
- ausreichende Staatskasse
- Infrastruktur / Verwaltung funktionsfähig

Neue Ausstattung:
- zusätzlicher Aktenschrank
- sichere Telefonleitung
- größere Wandkarte
- Assistent / Sekretariat
- separater Meetingraum

Gameplay:
- mehr parallele politische Projekte
- schnellere Verwaltungsreaktion

### Stufe 3 — Strategische Kommandozentrale
Voraussetzung:
- Autorität ≥ ungefähr 65
- Militäreinfluss ≥ ungefähr 50
- Aufrüstungs-/Militärkapazität ≥ ungefähr 50
- Geld-/Industrieinvestition

Neue Räume:
- Karten-/Lageraum
- Kommunikationsraum
- Militärraum

Gameplay:
- detailliertere Logistik
- mehr militärische Befehlsoptionen
- bessere Reaktionsfähigkeit

### Stufe 4 — Nationale Machtzentrale
Voraussetzung:
- Autorität ≥ ungefähr 80
- hohe Staatskapazität
- hohe Kommunikations-/Verwaltungskapazität
- hoher Etat

Neue Funktionen:
- vollständiger Krisenstab
- Geheimdienstzimmer
- mehrere Kommunikationslinien
- Delegations-/Konferenzraum
- erweiterter Lagebericht

### Stufe 5 — Kriegs-/Großmacht-Hauptquartier
Nicht einfach kaufbar.
Benötigt zusätzlich:
- Großmacht-/Kriegsstatus oder historisch passende Entwicklung
- hohe Industrie
- hohe Aufrüstung
- hohe Logistik
- hohe militärische/regierungspolitische Kontrolle

Neue Funktionen:
- kombinierter strategischer Lagebereich
- globale Versorgungsansicht
- Bündniskoordination
- mehrere Front-/Theateransichten
- strategische Reserven

## 12. Kostenregel

Büro-/Zentralen-Upgrades werden nicht nur mit Geld bezahlt.

Typische Voraussetzungen:
- Staatskasse
- Autorität
- Regierungseinfluss
- Industrie
- Kommunikationsinfrastruktur
- Militäreinfluss
- Aufrüstung
- ggf. Forschung

Beispiel:

**Sicherer Kommunikationsraum**
- Staatskasse: 12 RP
- Industriegüter: 4 RP
- Kommunikationsinfrastruktur: 45+
- Autorität: 45+
- Bauzeit: 2 Monate

**Strategischer Kriegsraum**
- Staatskasse: 18 RP
- Stahl: 3 RP
- Industriegüter: 6 RP
- Militäreinfluss: 50+
- Aufrüstungsindex: 50+
- Autorität: 60+
- Bauzeit: 3 Monate

Werte sind Balancing-Seeds und werden später getestet.

## 13. Büro kann sich auch verschlechtern

Progression geht nicht nur nach oben.

Mögliche Folgen von Krise/Krieg:
- beschädigtes Fenster
- Stromausfall
- weniger Personal
- Aktenstapel
- Telefonleitung gestört
- Karte mit Frontmarkierungen
- Umzug in provisorisches Büro
- Verlust eines Nebenraums
- Evakuierung in Schutzraum

Damit wird die Weltlage sichtbar, ohne extra Statistikscreen.

## 14. Avatar-spezifische Steuerzentralen 1933

### Mustafa Kemal Atatürk — Türkei
Status Anfang 1933: Staatspräsident.

Atmosphäre:
- republikanisch-staatlich
- Ankara als politisches Zentrum
- klarer, modernerer Verwaltungsstil innerhalb der 1930er-Ästhetik

Persönliche Elemente:
- Portrait Atatürks
- türkische Flagge
- Reform-/Gesetzesakten
- Bildungs-/Sprach-/Modernisierungsunterlagen
- Türkei-/Anatolienkarte

Besonderer Klick:
**Reformmappe** → Side Panel für institutionelle Modernisierung, Bildung, Recht und Entwicklung.

Startzugänge:
- Regierungsbüro: hoch
- Kabinettszugang: aktiv
- Militärkontakt: aktiv
- Forschungs-/Entwicklungskontakt: aktiv

### Adolf Hitler — Deutschland
Status am 1. Januar 1933: noch nicht Reichskanzler; Ernennung am 30. Januar 1933.

Startbüro muss daher zunächst politischer/parteilicher wirken und darf am 1. Januar nicht bereits die vollständige Staatskanzlei simulieren.

Persönliche Elemente:
- politisches Büro
- Deutschlandkarte
- Partei-/Kampagnenakten
- Kontakte zu politischen Eliten

Historischer Übergang bei entsprechender Ereignisentwicklung:
- Regierungsbüro wird freigeschaltet
- Zugriff auf Ministerien wächst
- später mögliche Erweiterung zur staatlichen Machtzentrale

Besonderer Klick:
**Politische Aktenmappe** → Partei-, Koalitions-, Elite- und Regierungszugang.

Darstellung soll historisch nüchtern bleiben und keine verherrlichende Inszenierung erzeugen.

### Josef Stalin — Sowjetunion
Status Anfang 1933: Generalsekretär mit sehr hoher institutioneller Macht.

Atmosphäre:
- streng
- funktional
- stark auf Partei-/Staatsapparat und Berichte ausgerichtet

Persönliche Elemente:
- UdSSR-Karte
- Parteiberichte
- Produktions-/Planunterlagen
- Kader-/Personalakten
- Industrialisierungsberichte

Besonderer Klick:
**Kaderakte** → Personal, Parteieinfluss, Verwaltung, Loyalität.

Startzugänge:
- Partei-/Regierungsapparat: sehr hoch
- Geheimdienstkontakte: hoch
- Industrie-/Planungsinformationen: hoch

### Winston Churchill — Vereinigtes Königreich
Status Anfang 1933: Mitglied des Parlaments, nicht Premierminister.

Büro daher zunächst kleiner und politisch/privat geprägt.

Persönliche Elemente:
- Bücher
- Schreibmaterial
- Parlament-/Außenpolitikakten
- Welt-/Empire-Karte als politisches Informationsobjekt
- Korrespondenz

Besonderer Klick:
**Korrespondenzmappe** → politische Kontakte, Parlament, Presse und internationale Netzwerke.

Startzugänge:
- kein direkter Kabinettsbefehl
- eingeschränkter Militärzugriff
- hoher Informations-/Netzwerkspielraum

Bei späterem Regierungsamt kann das Büro stark aufrüsten und ein War Cabinet / War Room freischalten.

### Franklin D. Roosevelt — USA
Status am 1. Januar 1933: gewählter Präsident, Amtsantritt am 4. März 1933.

Startphase:
- Übergangsbüro / President-elect
- Berater, wirtschaftliche Krisenunterlagen, Personalplanung

Nach Amtsantritt:
- präsidentielle Steuerzentrale
- Minister-/Behördenkontakte
- New-Deal-/Wirtschaftsakten

Persönliche Elemente:
- Familien-/Netzwerkbezug
- Wirtschaftsberichte
- USA-Karte
- Beratermappen

Besonderer Klick:
**Beratermappe** → Experten, Ministerkandidaten, Wirtschafts-/Sozialprogramme.

### Benito Mussolini — Italien
Status Anfang 1933: Regierungschef mit hoher persönlicher Macht.

Atmosphäre:
- staatlich-repräsentativ
- Rom
- starke Minister-/Militäranbindung

Persönliche Elemente:
- Italienkarte
- Infrastruktur-/Industrieakten
- militärische Berichte
- Verwaltungsunterlagen

Besonderer Klick:
**Staatsprojektmappe** → Infrastruktur, Prestigeprojekte, Industrie, Verwaltung.

Startzugänge:
- Regierungsbüro aktiv
- Militärzugang aktiv
- Kommunikationszugang hoch

### Custom Avatar
Das Büro hängt nicht an einem festen historischen Bild.

Der Spieler wählt beim Prolog:
- Herkunft
- Land
- soziale Ausgangslage
- Beruf/Netzwerk
- politische Position

Daraus entstehen Bürokomponenten.

Beispiele:
- Anwalt → Gesetzbücher / Mandantenakten
- Offizier → Militärkarten / Dienstakten
- Unternehmer → Handelsbuch / Firmenunterlagen
- Parteifunktionär → Parteiakten / Kontaktlisten
- Beamter → Verwaltungsakten / Behördenzugang
- Journalist → Pressemappe / Informationsnetz

Das Custom-Büro wächst besonders stark mit der Karriere und kann sich visuell stärker verändern als historische Büros.

## 15. Persönliches Portrait

Jedes Büro besitzt an sichtbarer Stelle ein Avatarbild oder eine persönliche Darstellung.

Klick:
- Biografie
- Alter
- Gesundheit
- Traits
- Autorität
- Einflussbereiche
- Beziehungen
- aktueller Titel / Amt
- Nachfolge / Familie, falls relevant

Das Portrait kann sich mit Alter und Epoche ändern.

## 16. Zustandsabhängige Dekoration

Dekoration trägt Information.

Beispiele:
- viele rote Mappen → mehrere dringende Krisen
- blinkendes Telefon → eingehender dringender Kontakt
- Zeitungsstapel → ungeprüfte öffentliche Meldungen
- Karte mit Markierungen → Krieg / Mobilisierung
- leerer Aktenkorb → geringe Verwaltungslast
- überfüllter Schreibtisch → zu viele parallele Projekte
- gedimmtes Licht / Stromproblem → Energiekrise
- zusätzliche Wachposten → Sicherheitslage verschlechtert

## 17. Keine versteckten Kernfunktionen

Auch wenn ein Spieler einen Nebenraum noch nicht besitzt, darf eine notwendige Basisfunktion nicht komplett verschwinden.

Beispiel:
- ohne Kriegsraum gibt es trotzdem eine einfache Militärmappe
- mit Kriegsraum wird dieselbe Funktion detaillierter und schneller

Damit bleibt das Spiel fair und verständlich.

## 18. Speicherung

Pro Match werden gespeichert:
- office_level
- freigeschaltete Räume
- aktive Objekte
- Objektzustände
- Upgrade-Fortschritt
- laufende Bauzeit
- personalisierte Dekoration
- Avatarportrait-Version
- aktuelle Dokumente auf dem Tisch
- ungelesene Telefon-/Radio-/Postereignisse

## 19. Grafikproduktion später

Vor Grafikproduktion müssen pro Avatar definiert sein:
- Kameraperspektive
- Klickzonen
- Objektpositionen
- Raumanschlüsse
- Lichtzustände Tag/Nacht/Krise
- neutrale/historische Symbolik
- Upgradevarianten
- beschädigte/Krisenvarianten

Erst danach werden endgültige 2D/3D-Grafiken erstellt. So muss die Grafik später nicht neu gebaut werden, weil ein wichtiges Spielobjekt vergessen wurde.
