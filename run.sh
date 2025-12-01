#!/bin/bash

echo "================================================"
echo "  Rise of the Northborn - Flad Rusputin Saga"
echo "================================================"
echo ""

if [ ! -f "RiseOfTheNorthborn.exe" ]; then
    echo "FEHLER: Spiel nicht gefunden!"
    echo "Bitte zuerst mit ./compile.sh kompilieren."
    echo ""
    exit 1
fi

mono RiseOfTheNorthborn.exe
