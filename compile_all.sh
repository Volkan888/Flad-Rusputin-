#!/bin/bash
# Kompiliert alle C#-Dateien zusammen

cd /app

echo "================================================"
echo "  Kompiliere Rise of the Northborn..."
echo "================================================"

# Kompiliere alle .cs Dateien
mcs *.cs -out:RiseOfTheNorthborn.exe

if [ $? -eq 0 ]; then
    echo ""
    echo "✓ Kompilierung erfolgreich!"
    echo ""
    echo "==========================================="
    echo "  Starte mit: mono RiseOfTheNorthborn.exe"
    echo "==========================================="
else
    echo ""
    echo "================================================"
    echo "  FEHLER beim Kompilieren!"
    echo "================================================"
fi
