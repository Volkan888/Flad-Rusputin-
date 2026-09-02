# Milestone 23 — Angreifbare Sektorkarte 1933

Stand: 2026-09-02 05:49 CEST

## Fertig
- 43 angreifbare Sektoren für Türkei, Deutschland, Sowjetunion, Vereinigtes Königreich, USA und Italien.
- Jeder Sektor besitzt Gelände, Küstenstatus, Hauptstadtstatus, Infrastruktur, Versorgung, Befestigung, urbane Verteidigung, lokale Widerstandskraft, Kommandonähe und strategischen Wert.
- Landnachbarschaften sind bidirektional validiert.
- Ressourcen-Knoten sind auf Sektoren verlinkt.
- Kämpfe laufen in Tages-Substeps innerhalb der Monatsrunde und können über Monatsgrenzen hinaus `contested` bleiben.
- Geländeabhängige Dauerkorridore sind definiert: Ebene, gemischt, Hügel, Gebirge, Großstadt, Insel/amphibisch.
- Eroberung einer Hauptstadt annektiert nicht automatisch das ganze Land.
- Rohstoffe eines eroberten Sektors liefern erst nach lokaler Kontrolle und funktionierender Logistik wieder vollen Output.
- Nichtstaatliche Macht ist vorbereitet: Konzerne, Mafia/kriminelle Netzwerke, politische Organisationen und gemischte Kontrolle können später Einfluss im Sektor besitzen, getrennt von territorialer Souveränität.

## Tests
CI PASS:
- Python Content-/Sector-Regression
- Godot 4.7.2 headless parse
- .NET 10 restore/build
- API start/smoke tests

## Nächster Block
Milestone 24: Inventar-, Konzern-, Mafia- und Organisationsstrukturen mit Sektor-Einfluss und getrenntem Eigentum.
