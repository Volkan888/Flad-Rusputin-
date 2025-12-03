#!/bin/bash
clear
echo "================================================"
echo "  Rise of the Northborn - Flad Rusputin Saga"
echo "================================================"
echo ""

if [ ! -f RiseOfTheNorthborn.exe ]; then
    echo "FEHLER: Spiel nicht gefunden!"
    echo "Bitte zuerst mit ./compile.sh kompilieren."
    echo ""
    read -p "Drücke Enter zum Beenden..."
    exit 1
fi

mono RiseOfTheNorthborn.exe

echo ""
echo "================================================"
echo "  Danke fürs Spielen!"
echo "================================================"
