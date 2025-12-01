#!/bin/bash

echo "================================================"
echo "  Kompiliere Rise of the Northborn..."
echo "================================================"
echo ""

# Prüfe ob Mono installiert ist
if ! command -v mcs &> /dev/null; then
    echo "FEHLER: Mono C# Compiler nicht gefunden!"
    echo "Installiere Mono mit: sudo apt-get install mono-complete"
    exit 1
fi

# Kompiliere das Spiel
mcs RiseOfTheNorthborn.cs -out:RiseOfTheNorthborn.exe

if [ $? -eq 0 ]; then
    echo ""
    echo "================================================"
    echo "  Kompilierung erfolgreich!"
    echo "================================================"
    echo ""
    echo "Starte das Spiel mit: mono RiseOfTheNorthborn.exe"
    echo ""
    
    # Mache das Skript ausführbar
    chmod +x run.sh
else
    echo ""
    echo "================================================"
    echo "  FEHLER beim Kompilieren!"
    echo "================================================"
    exit 1
fi
