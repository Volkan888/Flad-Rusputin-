# 🎮 Rise of the Northborn – Flad Rusputin Saga

Ein Text-Adventure Spiel mit vollständig implementiertem Schiffe-Versenken-Minigame in C#.

## 📋 Spielübersicht

### Hauptmenü Features:
- ✅ **Neues Spiel** - Streben nach der Weltherrschaft
- ✅ **Spiel Laden/Speichern** - 5 Speicherslots verfügbar
- ✅ **Highscore** - Lokale Bestenlisten
- ✅ **Globaler Highscore** - Weltweite Ranglisten
- ✅ **Mini Game: Schiffe versenken** - Vollständig spielbar!
- ✅ **Mehrspieler** - Hotseat-Modus
- ✅ **Einstellungen** - Anpassbare Optionen
- 🎵 **Tetris-Hintergrundmusik** - Authentische sowjetische Atmosphäre

## ⚓ Schiffe Versenken - Features

### Spielmodi:
1. **Spieler vs. Computer** 
   - Intelligente KI
   - Verschiedene Schwierigkeitsgrade
   
2. **Spieler vs. Spieler**
   - Hotseat-Modus
   - Abwechselnd am gleichen PC

### Schwierigkeitsgrade:
- **Klein** (5x5) - Schnelle Runden mit 3 Schiffen
- **Mittel** (6x6) - Ausgewogen mit 4 Schiffen  
- **Groß** (8x8) - Epische Seeschlachten mit 5 Schiffen

### Spielmechanik:
✅ **Manuelle Schiffplatzierung**
  - Wähle Position (z.B. A1)
  - Wähle Ausrichtung (Horizontal/Vertikal)
  - Schiffe dürfen sich nicht berühren

✅ **Angriffssystem**
  - Koordinateneingabe (z.B. B3)
  - Visuelle Rückmeldung mit Farben
  - Sound-Effekte für Treffer/Fehlschuss

✅ **Spielfeld-Darstellung**
  - ~ = Wasser (Blau)
  - ■ = Schiff (Grün)
  - X = Treffer (Rot)
  - ○ = Fehlschuss (Cyan)

✅ **Gewinnbedingung**
  - Alle gegnerischen Schiffe versenken
  - Highscore-Tracking mit Spielzeit

### Schiffsgrößen:
- **5x5 Feld**: 4er, 3er, 2er
- **6x6 Feld**: 5er, 4er, 3er, 2er
- **8x8 Feld**: 5er, 4er, 3er, 3er, 2er

## 🎯 Spielregeln Schiffe Versenken

1. **Platzierungsphase:**
   - Alle Schiffe müssen auf dem Spielfeld platziert werden
   - Schiffe können horizontal oder vertikal ausgerichtet sein
   - Schiffe dürfen sich nicht berühren (auch nicht diagonal)

2. **Angriffsphase:**
   - Spieler geben abwechselnd Koordinaten ein
   - Bei Treffer: Spieler darf nochmal schießen
   - Bei Fehlschuss: Gegner ist an der Reihe
   - Spiel endet wenn alle Schiffe eines Spielers versenkt sind

3. **Computer-KI:**
   - Schießt zufällig auf unbekannte Felder
   - Merkt sich bereits beschossene Positionen

## 🚀 Installation & Start

### Voraussetzungen:
- .NET Framework 4.5 oder höher
- C# Compiler (csc.exe)

### Kompilieren (Windows):

```bash
csc.exe /out:RiseOfTheNorthborn.exe RiseOfTheNorthborn.cs
```

Oder verwenden Sie die mitgelieferte Batch-Datei:
```bash
compile.bat
```

### Starten:
```bash
RiseOfTheNorthborn.exe
```

### Kompilieren (Linux/Mac mit Mono):
```bash
mcs RiseOfTheNorthborn.cs
mono RiseOfTheNorthborn.exe
```

## 🎮 Steuerung

### Hauptmenü:
- Eingabe: **1-8** + Enter
- Navigation durch Zahlen

### Schiffe Versenken:
- **Schiffplatzierung:** 
  - Position: `A1`, `B2`, etc.
  - Ausrichtung: `H` (Horizontal) oder `V` (Vertikal)
  
- **Angriff:**
  - Koordinaten: `A1`, `C5`, etc.
  - Enter bestätigt die Eingabe

## 🏆 Highscore-System

- Top 10 Spieler werden gespeichert
- Sortierung nach schnellster Zeit
- Anzeige von:
  - Spielername
  - Feldgröße
  - Benötigte Zeit
  - Datum

## 🎨 Visuelle Features

- **ASCII-Art Sowjetflagge** beim Start
- **Farbcodierte Spielfelder**
- **Animations-Effekte** (Verzögerungen, Beep-Töne)
- **Strukturierte Menüs** mit Box-Drawing-Zeichen

## 🔧 Technische Details

### Architektur:
- **Klasse Program** - Hauptlogik und Menüführung
- **Klasse Ship** - Schiff-Objekte mit Zustand
- **Klasse BattleshipBoard** - Spielfeld mit Logik
- **Klasse SaveData** - Spielstand-Verwaltung
- **Klasse BattleshipScore** - Highscore-Daten

### Verwendete C#-Features:
- LINQ für Datenverarbeitung
- Async/Task für Hintergrundmusik
- Collections (List, Dictionary)
- Enums für Zustände
- Threading für Sound-Effekte

## 📝 Spielanleitung (Beispiel)

1. **Spiel starten**
   ```
   > RiseOfTheNorthborn.exe
   ```

2. **Im Hauptmenü: Option 5 wählen**
   ```
   Wähle eine Option [1–8]: 5
   ```

3. **Spielmodus auswählen**
   ```
   [1] Spieler gegen Computer
   ```

4. **Namen eingeben**
   ```
   Bitte gib deinen Spielernamen ein: Admiral
   ```

5. **Feldgröße wählen**
   ```
   [2] Mittel (6x6)
   ```

6. **Schiffe platzieren**
   ```
   Startposition (z.B. A1): A1
   Ausrichtung ([H]orizontal / [V]ertikal): H
   ```

7. **Angreifen**
   ```
   Ziel angeben (z.B. B3): B3
   💥 TREFFER!
   ```

8. **Gewinnen!**
   ```
   🎉 SIEG! Admiral hat gewonnen! 🎉
   ```

## 🐛 Bekannte Features

- ✅ Vollständige Schiffe-Versenken-Implementierung
- ✅ Spieler vs Computer mit KI
- ✅ Spieler vs Spieler (Hotseat)
- ✅ 3 Schwierigkeitsgrade
- ✅ Highscore-System
- ✅ Sound-Effekte
- ✅ Speicher-/Ladesystem
- ✅ Vollständige ASCII-Visualisierung

## 🎯 Geplante Features (Hauptspiel)

- Lebensphasen-System (Geburt bis Tod)
- Attribut-System (Stärke, Intelligenz, Geschick, etc.)
- Generationensystem mit Vererbung
- K.G.B. Easter-Egg
- Vollständige Story-Kampagne

## 📜 Credits

**Entwickelt für:** Projekt "Rise of the Northborn"  
**Entwickler:** Volkan Kurt  
**Klasse:** SI 25-3  
**Thema:** Text-Adventure mit Mini-Game

---

## 🇷🇺 Für das Vaterland! ☭

*"Ein Spiel von Genossen, für Genossen!"*
