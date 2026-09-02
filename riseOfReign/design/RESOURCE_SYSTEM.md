# riseOfReign — Ressourcen-, Punkte- und Produktionssystem

Stand: 2026-09-02 02:42 CEST

## Ziel

Dieses Dokument definiert die verbindliche wirtschaftliche Simulationsbasis für das Hauptspiel ab 1. Januar 1933. Das System bleibt für ein Mobile-Spiel lesbar, erzeugt aber genug Wechselwirkungen für Handel, Krieg, Forschung, Diplomatie, Städte und Ereignisketten.

## Grundprinzip

Es gibt vier Werttypen:

1. **Bestände** — können produziert, gelagert, gehandelt und verbraucht werden.
2. **Kapazitäten** — bestimmen, wie viel ein Land pro Runde herstellen oder bewegen kann.
3. **Strategische Punkte** — werden durch Institutionen, Personal und Entscheidungen erzeugt und für Aktionen eingesetzt.
4. **Zustandswerte** — beschreiben Gesellschaft, Staat und Macht; sie sind keine frei handelbaren Ressourcen.

Alle spielmechanischen Werte werden intern in **Resource Points (RP)** bzw. 0–100-Skalen normalisiert. Historische Daten können später als Rohdaten hinterlegt werden, werden für das Balancing aber in diese Skalen umgerechnet.

---

# A. Materielle Bestände

## 1. Staatskasse / Geld

**Typ:** Bestand

Verwendung:
- Gehälter und Verwaltung
- Investitionen
- Militär
- Forschung
- Subventionen
- Importzahlungen
- diplomatische Hilfen
- Geheimdienstaktionen

Einnahmen:
- Steuern
- Staatsunternehmen
- Zölle
- Exportüberschüsse
- Kredite
- Reparationen/Transfers

Risiken:
- Defizit
- Inflation
- Schuldenkrise
- Vertrauensverlust

## 2. Nahrungsmittel

**Typ:** Bestand

Produktion:
- Landwirtschaftsregionen
- Fischerei
- Tierhaltung

Verbrauch:
- Zivilbevölkerung
- Militär
- Export

Bei Mangel:
- Moral sinkt
- Unruhe steigt
- Gesundheit/Arbeitsproduktivität sinkt
- Armeeversorgung sinkt

## 3. Kohle

**Typ:** Bestand

Verwendung:
- Kraftwerke
- Stahlindustrie
- Eisenbahn
- Schwerindustrie

1933 eine Kernressource; später durch Öl, Gas und modernere Energieformen teilweise substituierbar.

## 4. Rohöl

**Typ:** Bestand

Verwendung nach Raffination:
- Treibstoff
- Chemie
- Militär
- Transport

Rohöl allein kann nicht vollständig direkt genutzt werden; Raffineriekapazität ist erforderlich.

## 5. Treibstoff

**Typ:** veredelter Bestand

Erzeugung:
- Raffinerien aus Rohöl
- später synthetische Verfahren über Forschung

Verbrauch:
- Fahrzeuge
- Flugzeuge
- Schiffe
- mechanisierte Truppen
- Logistik

## 6. Erdgas

**Typ:** Bestand

1933 regional weniger dominant als später, bleibt aber als langfristige Ressource im Epochenmodell enthalten.

Verwendung:
- Energie
- Industrie
- Chemie
- später Haushalte

## 7. Eisenerz

**Typ:** Bestand

Verwendung:
- Stahlproduktion

## 8. Stahl

**Typ:** veredelter Bestand

Erzeugung benötigt:
- Eisenerz
- Kohle/Energie
- Stahlwerkskapazität

Verwendung:
- Infrastruktur
- Maschinen
- Fahrzeuge
- Schiffe
- Rüstung

## 9. Nichteisenmetalle

Zusammengefasster Bestand für:
- Kupfer
- Aluminium/Bauxit
- Nickel
- Chrom
- Wolfram und vergleichbare strategische Metalle

Detailtypen können bei bestimmten Technologien separat relevant werden.

## 10. Chemikalien

**Typ:** veredelter Bestand

Verwendung:
- Düngemittel
- Medizin
- Industrie
- Sprengstoff-/Munitionsproduktion auf abstrakter Ebene
- synthetische Materialien

## 11. Industriegüter / Maschinen

**Typ:** veredelter Bestand

Repräsentiert:
- Werkzeugmaschinen
- Motoren
- industrielle Anlagen
- Präzisionsteile

Verwendung:
- Fabrikbau
- Produktionsmodernisierung
- Forschung
- Fahrzeuge

## 12. Konsumgüter

**Typ:** veredelter Bestand

Verwendung:
- ziviler Lebensstandard
- politische Stabilität
- Handel

Zu starke Umleitung der Produktion in Militärgüter erzeugt Konsumgütermangel und gesellschaftliche Kosten.

## 13. Medizinische Versorgung

**Typ:** Bestand

Verwendung:
- zivile Krisen
- Epidemien
- Militärverluste
- Katastrophen

## 14. Militärmaterial

Kein einzelnes Waffenlager, sondern abstrahierter Bestand aus:
- Kleinwaffen
- Munition
- Ersatzteilen
- Artilleriebedarf
- Uniform/Ausrüstung

Schwere Systeme wie Panzer, Flugzeuge und Schiffe werden als Einheiten produziert, nicht nur als RP-Bestand.

## 15. Strategische Spezialmaterialien

Freischaltbarer Sammelbestand für seltene, technologieabhängige Materialien.

Beispiele:
- Uran ab entsprechender Forschung
- Speziallegierungen
- Hochleistungsoptik
- Radar-/Funkkomponenten

---

# B. Produktions- und Infrastrukturkapazitäten

## 16. Energieerzeugung

**Skala:** 0–100 Kapazität

Quellen:
- Kohle
- Öl
- Wasserkraft
- Gas
- später Kernenergie

Energie ist Voraussetzung für Industrie, Stadtversorgung, Forschung und militärische Produktion.

## 17. Industriekapazität

**Skala:** 0–100

Unterteilt in Produktionsanteile:
- Zivilindustrie
- Schwerindustrie
- Militärindustrie
- Bau

Der Spieler verteilt Kapazität pro Runde.

## 18. Raffineriekapazität

Bestimmt, wie viel Rohöl in Treibstoff/Chemikalien umgewandelt werden kann.

## 19. Stahlwerkskapazität

Bestimmt maximalen Stahloutput.

## 20. Landwirtschaftskapazität

Bestimmt Nahrungsproduktion und hängt ab von:
- Fläche
- Wetter
- Arbeitskräften
- Mechanisierung
- Düngemitteln
- Infrastruktur

## 21. Baukapazität

Bestimmt parallele Projekte:
- Straßen
- Bahn
- Häfen
- Fabriken
- Kraftwerke
- Befestigungen
- Forschungseinrichtungen

## 22. Logistikkapazität

Ermittelt aus:
- Bahnnetz
- Straßen
- Häfen
- Binnenschifffahrt
- Fahrzeugbestand
- Treibstoff

Logistik begrenzt sowohl Handel als auch militärische Operationen.

## 23. Handelskapazität

Bestimmt, wie viel Import/Export gleichzeitig abgewickelt werden kann.

Einflussfaktoren:
- Häfen
- Handelsflotte
- Bahnverbindungen
- Beziehungen
- Sanktionen
- Seewege

## 24. Arbeitskräfte

Keine reine Bevölkerungszahl, sondern verfügbarer Arbeitskräftepool.

Verteilung:
- Landwirtschaft
- Industrie
- Verwaltung
- Forschung
- Militär

Übermobilisierung schädigt die zivile Produktion.

## 25. Fachkräfte

Separater qualitativer Pool:
- Ingenieure
- Ärzte
- Wissenschaftler
- Spezialarbeiter
- Verwaltungsexperten

Nicht beliebig schnell ersetzbar.

---

# C. Strategische Punkte

## 26. Forschungspunkte (FP)

Erzeugung durch:
- Universitäten
- Labore
- Forscher-NPCs
- Industrieforschung
- internationale Kooperation

Verwendung:
- Technologien
- Doktrinen
- Produktionsverfahren

## 27. Entwicklungspunkte (EP)

Erzeugung durch:
- funktionierende Verwaltung
- Investitionen
- Bildung
- Infrastruktur

Verwendung:
- Regionen modernisieren
- Verwaltung verbessern
- Städte ausbauen
- Versorgung optimieren

## 28. Diplomatiepunkte (DP)

Erzeugung durch:
- Außenministerium
- internationale Reputation
- Botschaften
- erfolgreiche Verträge

Verwendung:
- Verträge
- Vermittlung
- Bündnisinitiativen
- Handelsmissionen
- internationale Kampagnen

## 29. Geheimdienstpunkte (GP)

Erzeugung durch:
- Geheimdienstbudget
- Agentennetzwerke
- Informationen
- Technologie

Verwendung:
- Aufklärung
- Gegenspionage
- strategische Sabotageereignisse
- Einflussoperationen

## 30. Einflusspunkte (IP)

Macht außerhalb unmittelbarer Staatsgewalt.

Bereiche:
- Politik
- Wirtschaft
- Medien
- Militär
- Ausland
- Organisationen

## 31. Informationspunkte (INF)

Repräsentieren verifiziertes Wissen über andere Spieler.

Stufen:
- 0–19: Gerüchte
- 20–39: grobe Lage
- 40–59: brauchbare Schätzung
- 60–79: detaillierte Lage
- 80–100: sehr hohe Transparenz

Information verfällt mit der Zeit, wenn sie nicht aktualisiert wird.

## 32. Militärische Bereitschaft (MB)

Kein Ersatz für Armeegröße.

Beeinflusst:
- Mobilisierungszeit
- Reaktionsgeschwindigkeit
- Anfangseffizienz im Konflikt

Zu lange hohe Bereitschaft kostet Geld, Treibstoff und Moral.

---

# D. Gesellschafts- und Machtwerte

Alle auf 0–100.

## 33. Stabilität

Wie funktionsfähig und ruhig das Land insgesamt ist.

Einflüsse:
- Nahrung
- Beschäftigung
- Versorgung
- Krieg
- Legitimität
- Unruhe
- regionale Konflikte

## 34. Legitimität

Wie akzeptiert die aktuelle politische Ordnung/Führung ist.

Nicht identisch mit Demokratie oder Zustimmung. Auch autoritäre Systeme können kurzfristig hohe Regimestabilität besitzen, während ihre internationale Reputation oder gesellschaftliche Freiheit niedrig ist.

## 35. Bevölkerung_moral

Gesamtstimmung und Durchhaltefähigkeit.

## 36. Militärmoral

Separater Wert für Streitkräfte.

## 37. Unruhe

Gegenwert zu Ruhe, aber nicht bloß `100-Stabilität`.

Kann regional entstehen:
- Streiks
- Proteste
- Versorgungskrisen
- politische Konflikte

## 38. Lebensstandard

Abhängig von:
- Nahrung
- Konsumgütern
- Wohnraum
- Arbeit
- Gesundheit
- Infrastruktur

## 39. Verwaltungsfähigkeit

Bestimmt, wie effizient Entscheidungen tatsächlich umgesetzt werden.

Ein riesiger Etat mit schwacher Verwaltung erzeugt weniger Wirkung.

## 40. Internationale Reputation

Beeinflusst:
- Diplomatiekosten
- Kredite
- Bündnisse
- Handel
- neutrale Staaten

## 41. Führungskapazität

Avatar-/Regierungswert aus:
- politischer Macht
- Charisma
- Verwaltung
- Gesundheit
- Loyalität zentraler Institutionen

## 42. Machtindex

Zusammenfassende Anzeige, keine eigene Ressource.

Vorschlagsformel:

`Machtindex = 0.18 Wirtschaft + 0.15 Industrie + 0.15 Militär + 0.10 Forschung + 0.10 Diplomatie + 0.08 Geheimdienst + 0.08 Stabilität + 0.06 Logistik + 0.05 Energie + 0.05 Einfluss`

Die Gewichtung kann je Epoche angepasst werden.

---

# E. Produktionszyklus pro Runde

Reihenfolge:

1. Bevölkerung und Arbeitskräfte aktualisieren
2. Rohstoffförderung
3. Energieproduktion
4. Veredelung (Stahl, Treibstoff, Chemie)
5. Industrieproduktion
6. Nahrungsversorgung
7. ziviler Verbrauch
8. Militärverbrauch
9. Handelslieferungen
10. Lagerbestände
11. gesellschaftliche Auswirkungen
12. Forschung/Entwicklung
13. Ereignisse

Damit können Ereignisse gezielt an einer Stelle der Kette eingreifen.

---

# F. Standardformeln

## Produktion

`Output = BasisKapazität × ArbeitskräfteFaktor × EnergieFaktor × RohstoffFaktor × InfrastrukturFaktor × TechnologieFaktor × EreignisFaktor`

Jeder Faktor liegt typischerweise zwischen 0.25 und 1.50.

## Versorgung

`Versorgungsquote = verfügbare Versorgung / benötigte Versorgung`

Effekte:
- >= 1.10: Reserveaufbau
- 0.90–1.09: normal
- 0.75–0.89: leichter Mangel
- 0.50–0.74: schwere Krise
- < 0.50: kritische Krise

## Handelsroute

`Liefermenge = Vertragsmenge × Routenkapazität × Sicherheitsfaktor × Beziehungsfaktor`

## Forschung

`Forschungsfortschritt = FP × Forscherqualität × Institutsbonus × Kooperationsbonus × Stabilitätsfaktor`

## Militärische Einsatzfähigkeit

`Einsatzfähigkeit = Einheitenstärke × Ausrüstung × Moral × Versorgung × Bereitschaft × Doktrin × Gelände/Logistik`

Keine einzelne „Militärpunkte“-Zahl entscheidet einen Konflikt.

---

# G. Lager und Reserven

Jeder materielle Bestand besitzt:

- aktuellen Vorrat
- sichere Mindestreserve
- maximale Lagerkapazität
- monatlichen/rundenweisen Verbrauch

Beispiel:

`Treibstoff: 60 RP vorhanden / 25 RP Mindestreserve / 80 RP Lagermaximum / 8 RP Verbrauch pro Runde`

Eine Reserve unter dem Mindestwert erzeugt Warnungen und verändert KI-/Spieleroptionen.

---

# H. Handel

## Vertragstypen

1. Sofortkauf
2. langfristiger Liefervertrag
3. Tauschgeschäft
4. Kreditfinanzierter Import
5. Entwicklungshilfe
6. gemeinsames Infrastrukturprojekt
7. strategisches Embargo/Sanktion

## Preisbildung

`Preis = Basispreis × Weltknappheit × Beziehung × Transportkosten × Risiko × Vertragsdauer`

Damit kann ein Land trotz geringer Eigenproduktion durch Handel überleben, wird aber verwundbar gegenüber Sanktionen oder blockierten Routen.

---

# I. Ressourcenketten

## Stahl

Eisenerz + Kohle/Energie + Stahlwerk + Arbeitskräfte → Stahl

## Treibstoff

Rohöl + Raffinerie + Energie + Arbeitskräfte → Treibstoff

## Industriegüter

Stahl + Nichteisenmetalle + Energie + Fachkräfte + Industrie → Maschinen

## Militärmaterial

Stahl + Chemikalien + Industriegüter + Militärindustrie → Militärmaterial

## Infrastruktur

Stahl + Industriegüter + Geld + Baukapazität + Arbeitskräfte → Infrastruktur

## Forschung

Geld + Energie + Fachkräfte + Forschungsinstitutionen → FP → Technologien

---

# J. Ressourcenmangel und Kaskaden

Beispiel Ölkrise:

1. Rohöl -30%
2. Raffinerieauslastung sinkt
3. Treibstoff -20%
4. Logistik -12%
5. Militärische Einsatzfähigkeit -15%
6. Handel/Transport -8%
7. Industrie erhält Lieferengpässe
8. Arbeitslosigkeit/Unruhe können steigen

Beispiel Nahrungsmittelkrise:

1. Nahrung unter 75% Bedarf
2. Lebensstandard sinkt
3. Moral sinkt
4. Unruhe steigt
5. Arbeitsproduktivität sinkt
6. Militärversorgung konkurriert mit Zivilversorgung
7. politische Entscheidung wird ausgelöst

---

# K. Regionalisierung

Ressourcen gehören nicht pauschal nur einem Staat. Produktionsquellen liegen in Regionen.

Jede Region besitzt:
- Ressourcenvorkommen
- Produktionskapazität
- Bevölkerung
- Infrastruktur
- strategischen Wert
- Loyalität/Unruhe

Verlust, Besetzung, Streik oder Zerstörung einer Region verändert unmittelbar den nationalen Output.

---

# L. Machtvakuum-Regel

Status **Machtvakuum** wird geprüft, wenn mindestens drei der folgenden Bedingungen gleichzeitig bestehen:

- Stabilität < 25
- Legitimität < 25
- Staatskasse kritisch / Zahlungsfähigkeit < 25
- militärische Einsatzfähigkeit < 25
- Verwaltungsfähigkeit < 30
- mehr als 40% der Kernregionen mit hoher Unruhe
- keine belastbare Allianz bzw. Diplomatie < 25

Folgen:
- höhere Kosten für neue Großprojekte
- Bündnisse schwerer abzuschließen
- Regionen können eigene Krisenketten entwickeln
- ausländischer Einfluss wird leichter
- humanitäre/wirtschaftliche Hilfsoptionen werden wichtiger
- bestimmte aggressive Spezialaktionen werden aus Balancegründen eingeschränkt, wenn sie nur noch einen kollabierenden Spieler aus dem Match entfernen würden

---

# M. Mobile-UI-Regel

Der Spieler sieht nicht 42 Zahlen gleichzeitig.

Hauptleiste:
- Geld
- Nahrung
- Energie
- Treibstoff
- Stahl
- Industrie
- Forschung
- Stabilität

Weitere Werte öffnen sich über Kategorien:
- Wirtschaft
- Bevölkerung
- Militär
- Forschung
- Diplomatie
- Geheimdienst
- Regionen

Warnsystem:
- Grün: >=100% Bedarf / gesund
- Gelb: 75–99%
- Orange: 50–74%
- Rot: <50%

Farben sind UI-Hinweise; zusätzlich werden Symbole/Text genutzt, damit Information nicht nur farbcodiert ist.

---

# N. Balancing-Regeln

1. Kein Land soll alle Ressourcen selbst besitzen.
2. Große Staaten erhalten Skalenvorteile, aber höhere Versorgungs- und Verwaltungskosten.
3. Kleine Staaten können durch Handel, Technologie, Diplomatie oder Spezialisierung konkurrenzfähig sein.
4. Militärische Produktion verdrängt zivile Produktion.
5. Lagerreserven sind strategisch wichtig und verhindern sofortige Kettenkollaps-Effekte.
6. Forschung benötigt Fachkräfte und Institutionen; Geld allein reicht nicht.
7. Sanktionen wirken nie als magischer Prozentmalus, sondern über reale Handels- und Lieferketten des Systems.
8. Ereignisse verändern möglichst konkrete Ressourcen/Kapazitäten statt willkürlicher Gesamtpunkte.

## Ergebnis

Das Ressourcenmodell ist damit als Basisspezifikation abgeschlossen. Die nächste Ebene ist die 1933-Weltkarte mit regionalen Ressourcenquellen, Hauptstädten, Industriezentren, Häfen und strategischen Knoten.