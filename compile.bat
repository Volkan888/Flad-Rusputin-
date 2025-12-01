@echo off
echo ================================================
echo  Kompiliere Rise of the Northborn...
echo ================================================

REM Finde den C# Compiler
set CSC="C:\Windows\Microsoft.NET\Framework\v4.0.30319\csc.exe"

if not exist %CSC% (
    echo FEHLER: C# Compiler nicht gefunden!
    echo Bitte .NET Framework 4.0 oder hoeher installieren.
    pause
    exit /b 1
)

REM Kompiliere das Spiel
%CSC% /out:RiseOfTheNorthborn.exe RiseOfTheNorthborn.cs

if %ERRORLEVEL% EQU 0 (
    echo.
    echo ================================================
    echo  Kompilierung erfolgreich!
    echo ================================================
    echo.
    echo Starte das Spiel mit: RiseOfTheNorthborn.exe
    echo.
    pause
) else (
    echo.
    echo ================================================
    echo  FEHLER beim Kompilieren!
    echo ================================================
    pause
)
