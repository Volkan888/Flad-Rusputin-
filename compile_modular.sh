#!/bin/bash
echo "================================================"
echo "  Kompiliere Rise of the Northborn (Modular)..."
echo "================================================"

# Kompiliere alle C#-Dateien zusammen
mcs -out:RiseOfTheNorthborn.exe RiseOfTheNorthborn.cs Telefone.cs 2>&1

if [ $? -eq 0 ]; then
    echo ""
    echo "================================================"
    echo "  Kompilierung erfolgreich!"
    echo "================================================"
    echo ""
    echo "Starte das Spiel mit: mono RiseOfTheNorthborn.exe"
else
    echo ""
    echo "================================================"
    echo "  ❌ KOMPILIERUNG FEHLGESCHLAGEN!"
    echo "================================================"
fi
