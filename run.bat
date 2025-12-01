@echo off
echo ================================================
echo  Rise of the Northborn - Flad Rusputin Saga
echo ================================================
echo.

if not exist RiseOfTheNorthborn.exe (
    echo FEHLER: Spiel nicht gefunden!
    echo Bitte zuerst mit compile.bat kompilieren.
    echo.
    pause
    exit /b 1
)

RiseOfTheNorthborn.exe
