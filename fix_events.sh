#!/bin/bash
# Script um alle HistoricalEvent Aufrufe zu vereinfachen

cd /app

# Backup erstellen
cp RiseOfTheNorthborn.cs RiseOfTheNorthborn_before_fix.cs

# Schritt 1: Einfache einzeilige Events konvertieren
sed -i 's/new HistoricalEvent("\([^"]*\)", "\([^"]*\)", "\[RU\]", "\[EN\]", "\([^"]*\)", "\[RU\]", "\[EN\]", \([0-9]*\), \([0-9]*\), "\([^"]*\)",/new HistoricalEvent("\1", "\2", "\3", \4, \5, "\6",/g' RiseOfTheNorthborn.cs

# Schritt 2: Mehrzeilige Events - entferne die Platzhalter-Zeilen
sed -i '/"\[RUSSISCH SPÄTER\]", "\[ENGLISH LATER\]",/d' RiseOfTheNorthborn.cs

echo "✓ Events vereinfacht"
