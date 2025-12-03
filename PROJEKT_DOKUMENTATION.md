# RISE OF THE NORTHBORN - PROJEKT DOKUMENTATION
## Vollständige Code-Dokumentation und Änderungsprotokoll

---

## 📋 PROJEKT-ÜBERSICHT

**Projekt:** Rise of the Northborn – Flad Rusputin Saga  
**Typ:** Textbasiertes Rollenspiel (RPG)  
**Sprache:** C# (.NET Framework 4.5+)  
**Plattformen:** Windows, Linux (Mono), macOS (Mono)  
**Entwicklungszeitraum:** Dezember 2024  
**Code-Umfang:** 1857 Zeilen C#  
**Hauptdatei:** `RiseOfTheNorthborn.cs`

---

## 🎯 SPIELKONZEPT

Ein generationenübergreifendes Rollenspiel, in dem der Spieler die fiktive Geschichte von Flad Rusputin erlebt - vom Straßenkind in den 1950ern bis zum Präsidenten einer dystopischen sowjetischen Nation. Nach dem Tod kann der Spieler mit einem seiner Nachkommen weiterspielen.

---

## 📦 HAUPT-KOMPONENTEN

### 1. DATENKLASSEN

#### `PlayerCharacter` - Hauptklasse für Spielercharakter
```csharp
class PlayerCharacter
{
    // Basis-Informationen
    string Name;              // Vollständiger Name
    int Alter;                // Alter in Jahren
    int Generation;           // Generationsnummer (1, 2, 3...)
    string Phase;             // Lebensphase (Kindheit, KGB, etc.)
    
    // Attribute (0-10)
    int Stärke;              // Körperliche Kraft
    int Intelligenz;         // Klugheit, Strategie
    int Charisma;            // Überzeugungskraft
    int Kraft;               // Ausdauer
    
    // Ressourcen
    int Geld;                // Finanzen in Rubel
    int Gesundheit;          // 0-100% (0 = Tod)
    
    // Loyalität (0-100%)
    int LoyalitätPartei;     // Zur kommunistischen Partei
    int LoyalitätVolk;       // Beim Volk
    int LoyalitätFamilie;    // In der Familie
    
    // Einfluss (0-100%)
    int EinflussKGB;         // Im Geheimdienst
    int EinflussMilitär;     // Beim Militär
    int EinflussInternational; // Im Ausland
    
    // Hochzeit & Familie
    bool IstVerheiratet;
    string EhepartnerName;
    int GeburtenBonus;       // 1-5 (Kinderrate)
    int FinanzBonus;         // Geld bei Heirat
    List<PlayerCharacter> Kinder;
    bool IstTot;
}
```

**ZWECK:**
- Speichert alle Daten des aktuellen Charakters
- Ermöglicht Vererbung von Attributen an Kinder
- Tracking von Ehe-Status und Familie

**ÄNDERUNGEN:**
- ✅ Hochzeits-System hinzugefügt (IstVerheiratet, EhepartnerName, GeburtenBonus, FinanzBonus)
- ✅ Generationen-Tracking (Generation, Kinder, IstTot)
- ✅ Erweiterte Attribute und Loyalitätswerte

---

#### `GameSave` - Speicherstand-Klasse
```csharp
class GameSave
{
    string SaveName;          // Vom Spieler vergebener Name
    DateTime SaveDate;        // Zeitstempel DD.MM.YYYY HH:MM:SS
    PlayerCharacter Character; // Kompletter Charakter
    int Generation;           // Für Übersicht
}
```

**ZWECK:**
- Speichert kompletten Spielstand
- Ermöglicht Laden und Fortsetzen

**ÄNDERUNGEN:**
- ✅ Benutzerdefinierte Namen (vorher automatisch)
- ✅ Datum/Uhrzeit-Tracking
- ✅ Generationsnummer für bessere Übersicht

---

### 2. HOCHZEITS-SYSTEM

#### `WifeOption` - Ehefrau-Optionen
```csharp
class WifeOption
{
    string Name;              // Name der Frau
    string Beschreibung;      // Charakterbeschreibung
    int GeburtenRate;         // 1-5 (Kinderwahrscheinlichkeit)
    int GeldBonus;            // Sofortige Mitgift
    int LoyalitätBonus;       // Familien-Loyalität Bonus
}
```

**VERFÜGBARE FRAUEN:**

| Name | Kinderrate | Geld-Bonus | Loyalität | Strategie |
|------|-----------|------------|-----------|-----------|
| **Natasha** (Oligarchin) | ★☆☆☆☆ (15%) | +300 Rubel | +5% | Reich, wenig Erben |
| **Olga** (Diplomatin) | ★★☆☆☆ (30%) | +200 Rubel | +10% | Ausgewogen |
| **Svetlana** (Balanced) | ★★★☆☆ (45%) | +100 Rubel | +15% | Mittelweg |
| **Irina** (Traditionell) | ★★★★☆ (60%) | +50 Rubel | +20% | Viele Kinder |
| **Katya** (Mutter) | ★★★★★ (75%) | +0 Rubel | +25% | Maximum Kinder |

**MECHANIK:**
```csharp
// Geburts-Wahrscheinlichkeit pro Jahr
int chance = GeburtenBonus * 15;  // 1*15=15%, 2*15=30%, ..., 5*15=75%

// Beispiel: Irina (4★) = 4*15 = 60% Chance pro Jahr
```

**TRADE-OFF:**
- Mehr Kinder → Mehr Erben bei Tod → Sicherheit
- Mehr Geld → Mehr Bestechung → Macht
- Spieler muss strategisch wählen!

---

#### `MarriageSystem` - Hochzeits-Verwaltung

**Methode: `OfferMarriage()`**
```csharp
public static void OfferMarriage(PlayerCharacter player)
```

**ABLAUF:**
1. Prüfung ob bereits verheiratet
2. Anzeige aller 5 Frauen mit Details
3. Spieler wählt [1-5]
4. Sofortige Effekte:
   - Geld += GeldBonus
   - LoyalitätFamilie += LoyalitätBonus
   - IstVerheiratet = true
   - GeburtenBonus und FinanzBonus speichern

**BEISPIEL:**
```
💒 HOCHZEIT 💒

[4] Irina - Die Traditionelle
    Widmet sich der Familie und Kindern
    Kinder: ★★★★☆ | Geld-Bonus: +50 Rubel
    Loyalität-Bonus: +20%

Wähle [1-5]: 4

💒 Flad heiratet Irina!
Mitgift: +50 Rubel
Familien-Loyalität: +20%
Erwartete Kinderzahl: 4
```

---

**Methode: `RandomBirth()` - Geburten-System**
```csharp
public static void RandomBirth(PlayerCharacter player)
```

**ÄNDERUNGEN GEGENÜBER VORHER:**
- ❌ Vorher: Alle Kinder auf einmal generiert
- ✅ Jetzt: Einzelgeburten über 10 Jahre verteilt
- ✅ Spieler gibt jedem Kind einen Namen
- ✅ Zwillinge (5%) und Drillinge (1%) möglich

**ABLAUF:**
```
1. Verheiratet? JA/NEIN
2. Zufalls-Check: rand.Next(100) < (GeburtenBonus * 15)
3. Wenn JA:
   a. Zwillings-Check (5% = 2 Kinder, 1% = 3 Kinder)
   b. Für jedes Kind:
      - Geschlecht zufällig
      - Spieler gibt Vornamen ein
      - Attribute vererben (Eltern ± 1-2)
      - Zur Kinder-Liste hinzufügen
   c. Familien-Loyalität +5 pro Kind
```

**VERERBUNGS-ALGORITHMUS:**
```csharp
// Für jedes Attribut
child.Stärke = Math.Max(0, player.Stärke + rand.Next(-1, 3));
// Ergebnis: Elternwert -1, +0, +1, oder +2
// Minimum: 0 (keine negativen Werte)
```

**BEISPIEL NORMAL:**
```
👶 GEBURT!
🎉 Irina hat ein Junge geboren!

Gib dem 1. Kind einen Vornamen: Vladimir

✓ Vladimir Rusputin 2 wurde geboren!
Attribute: S:4 I:5 C:3 K:3
```

**BEISPIEL ZWILLINGE:**
```
👶👶 ZWILLINGE! 👶👶

🎉 Irina hat ein Mädchen geboren!
Gib dem 1. Kind einen Vornamen: Natasha
✓ Natasha Rusputin 2 wurde geboren!

[Drücke Taste für nächstes Kind...]

🎉 Irina hat ein Junge geboren!
Gib dem 2. Kind einen Vornamen: Alexei
✓ Alexei Rusputin 2 wurde geboren!

Flad hat jetzt 2 Kind(er)!
```

---

### 3. TOD & NACHFOLGE-SYSTEM

#### `DeathSystem` - Tod-Verwaltung

**Methode: `CheckDeath()` - Tod prüfen**
```csharp
public static bool CheckDeath(PlayerCharacter player)
```

**2 TODESURSACHEN:**

1. **Gesundheit ≤ 0**
   ```csharp
   if (player.Gesundheit <= 0)
       return true;  // Sofortiger Tod
   ```

2. **Altersschwäche (ab 65 Jahre)**
   ```csharp
   if (player.Phase == "Präsident" && player.Alter >= 65)
   {
       int deathChance = (player.Alter - 65) * 8;
       // 65 Jahre: 0% Risiko
       // 70 Jahre: 40% Risiko
       // 75 Jahre: 80% Risiko
       if (rand.Next(100) < deathChance)
           return true;
   }
   ```

**TODESZENE:**
```
╔═══════════════════════════════════════════════════════════╗
║                         † TOD †                           ║
╚═══════════════════════════════════════════════════════════╝

Flad Rusputin ist im Alter von 72 Jahren
an Altersschwäche gestorben.

Seine Herrschaft war geprägt von:
  • Generation: 1
  • Kinder: 5
  • Vermögen: 450 Rubel
  • Gesundheit bei Tod: 0%

Loyalität zur Partei: 75%
Loyalität zum Volk: 45%
Einfluss beim KGB: 60%

Die Dynastie geht weiter...
```

---

**Methode: `SelectHeir()` - Nachfolger wählen**
```csharp
public static PlayerCharacter SelectHeir(PlayerCharacter deceased)
```

**ABLAUF:**
1. Prüfung: Hat Verstorbener Kinder?
   - NEIN → GAME OVER
   - JA → Weiter zu 2.

2. Liste aller Kinder anzeigen mit:
   - Name
   - Generation
   - Alle 4 Attribute

3. Spieler wählt [1-N]

4. Gewähltes Kind wird zum neuen Hauptcharakter:
   ```csharp
   heir.Geld = deceased.Geld / 2;          // 50% Vermögen geerbt
   heir.EinflussKGB = deceased.EinflussKGB / 3;      // 33% Einfluss
   heir.EinflussMilitär = deceased.EinflussMilitär / 3;
   heir.LoyalitätPartei = deceased.LoyalitätPartei / 2; // 50% Loyalität
   heir.Alter = 25;                         // Startet mit 25 Jahren
   heir.Phase = "Jurastudium";             // Beginnt im Studium
   heir.Gesundheit = 100;                  // Volle Gesundheit
   ```

**BEISPIEL:**
```
╔═══════════════════════════════════════════════════════════╗
║              WÄHLE DEINEN NACHFOLGER                      ║
╚═══════════════════════════════════════════════════════════╝

[1] Vladimir Rusputin 2
    Generation: 2
    Attribute: S:4 I:5 C:3 K:3

[2] Dimitri Rusputin 2
    Generation: 2
    Attribute: S:5 I:3 C:4 K:4

[3] Natasha Rusputin 2
    Generation: 2
    Attribute: S:3 I:6 C:5 K:2

Wähle [1-3]: 1

╔═══════════════════════════════════════════════════════════╗
║                  NEUE GENERATION                          ║
╚═══════════════════════════════════════════════════════════╝

Vladimir Rusputin 2 übernimmt die Dynastie!
Generation: 2

Geerbte Attribute:
  Stärke: 4
  Intelligenz: 5
  Charisma: 3
  Kraft: 3

Geerbtes Vermögen: 225 Rubel
```

**GAME OVER SZENARIO:**
```
╔═══════════════════════════════════════════════════════════╗
║                      GAME OVER                            ║
╚═══════════════════════════════════════════════════════════╝

⚠ Keine Erben vorhanden!
Die Linie der Rusputins endet hier...

Generation 1 war die letzte.
```

---

### 4. ZUFALLSEREIGNIS-SYSTEM

#### `RandomEvent` - Ereignis-Klasse
```csharp
class RandomEvent
{
    string Name;              // Ereignis-Name
    string Description;       // Beschreibung
    string Phase;             // In welcher Lebensphase?
    int Chance;               // Wahrscheinlichkeit 0-100
    Action<PlayerCharacter> Apply;  // Code der ausgeführt wird
}
```

**MECHANIK:**
```csharp
// Ereignis definieren
allEvents.Add(new RandomEvent(
    "Verlust des Bruders",               // Name
    "Flad verliert seinen Bruder...",    // Beschreibung
    "Kindheit",                          // Phase
    20,                                  // 20% Chance
    p => {                               // Effekte
        p.Gesundheit -= 10;
        p.LoyalitätFamilie += 20;
        p.Stärke += 1;
    }
));
```

#### `EventSystem` - Ereignis-Verwaltung

**20+ IMPLEMENTIERTE EREIGNISSE:**

**KINDHEIT (5 Ereignisse):**
1. Verlust des Bruders (20%)
   - Effekt: -10 Gesundheit, +20 Familie, +1 Stärke
   
2. Nächtliche Verhaftung (30%)
   - Effekt: +15 Partei ODER -10 Partei (zufällig)
   
3. Rauferei im Hinterhof (40%)
   - Effekt: -5 Gesundheit, +1 Stärke, -5 Partei
   
4. Heldengeschichte des Vaters (50%)
   - Effekt: +20 Partei, +10 Familie
   
5. Aufnahme bei Jungpionieren (60%)
   - Effekt: +15 Partei, +1 Charisma

**KGB-PHASE (2 Ereignisse):**
6. Aufstieg in Komsomol (40%)
   - Effekt: +1 Charisma, +20 Partei, +10 KGB
   
7. Gefährlicher Freundeskreis (25%) - **INTERAKTIV**
   - Option 1: Decken → +15 Familie, -20 Partei
   - Option 2: Melden → +25 Partei, +10 KGB, -15 Familie

**STUDIUM (5 Ereignisse):**
8. Unverhofftes Erbe (15%)
   - Effekt: +200 Geld, -5 Partei
   
9. Triumph auf Judomatte (35%)
   - Effekt: +2 Kraft, +10 Gesundheit, +1 Charisma
   
10. Drill und Disziplin (30%)
    - Effekt: -15 Gesundheit, +2 Kraft, +1 Stärke, +15 KGB
    
11. Enttarnter Maulwurf (20%) - **ATTRIBUT-ABHÄNGIG**
    - Bei Intelligenz ≥ 3: +20 KGB, +15 Partei
    - Sonst: -10 Partei
    
12. Geheimer Testeinsatz (40%) - **ERFOLG/MISSERFOLG**
    - Erfolg (60%): +15 KGB, +1 Intelligenz, +50 Geld
    - Misserfolg (40%): -20 Gesundheit, -10 KGB

**DDR-EINSATZ (3 Ereignisse):**
13. Aufruhr in Botschaft (45%) - **INTERAKTIV**
    - Option 1: Dokumente verbrennen → +20 KGB
    - Option 2: Besänftigen → +1 Charisma, +15 International (bei Charisma ≥3)
    
14. Doppelspiel Informant (30%) - **INTERAKTIV**
    - Option 1: Ausschalten → +15 Partei, -10 Familie
    - Option 2: Nutzen → 50% +25 International ODER -30 KGB
    
15. Erfolgreicher Coup (25%)
    - Effekt: +30 KGB, +100 Geld, +20 Partei

**PRÄSIDENT (4 Ereignisse):**
16. Intrige im Politbüro (35%) - **ATTRIBUT-ABHÄNGIG**
    - Bei Intelligenz ≥4 ODER KGB ≥50: +20 KGB, +15 Partei
    - Sonst: -25 KGB, -100 Geld
    
17. Attentatsversuch (20%)
    - Effekt: -40 Gesundheit, +30 Volk, +15 KGB
    
18. Verrat im Umfeld (25%)
    - Effekt: -20 Familie, -15 Partei
    - Bei KGB ≥40: +10 KGB (aufgedeckt)
    
19. Nervenzusammenbruch (15%)
    - Effekt: -30 Gesundheit, -20 KGB, +15 Familie

**TRIGGER-MECHANIK:**
```csharp
public static void TriggerRandomEvent(PlayerCharacter player)
{
    // Filtere passende Events
    var possibleEvents = allEvents.Where(e => 
        e.Phase == player.Phase &&           // Richtige Phase?
        rand.Next(100) < e.Chance            // Wahrscheinlichkeit getroffen?
    ).ToList();
    
    // Kein Event? Beende
    if (possibleEvents.Count == 0) return;
    
    // Wähle zufälliges Event
    var chosen = possibleEvents[rand.Next(possibleEvents.Count)];
    
    // Zeige Event
    DisplayEvent(chosen);
    
    // Führe Effekte aus
    chosen.Apply(player);
}
```

---

### 5. SCHIFFE VERSENKEN MINI-GAME

#### Klassen-Struktur

**`BattleshipGame` - Haupt-Spielklasse**
```csharp
class BattleshipGame
{
    public static void Play()     // Menü und Spielmodus-Auswahl
    static void PlayGame()        // Haupt-Spielschleife
    static void PlaceShipsManual() // Manuelle Schiffplatzierung
    static void PlaceShipsAuto()   // Automatische Platzierung (KI)
    static bool PlayerAttack()     // Spieler greift an
    static bool ComputerAttack()   // Computer greift an
}
```

**`Board` - Spielfeld-Klasse**
```csharp
class Board
{
    int Size;                     // 6x6 oder 8x8
    char[,] Grid;                 // 2D-Array für Felder
    string PlayerName;            // Name des Spielers
    List<Ship> ships;             // Liste der Schiffe
    
    bool PlaceShip()              // Schiff platzieren
    char Attack()                 // Angriff ausführen
    bool AllShipsSunk()           // Alle Schiffe versenkt?
    void Display()                // Spielfeld anzeigen
}
```

**`Ship` - Schiff-Klasse**
```csharp
class Ship
{
    int row, col, size;           // Position und Größe
    bool horizontal;              // Ausrichtung
    bool[] hits;                  // Treffer-Array
    
    bool IsAt()                   // Ist Schiff an Position?
    void Hit()                    // Treffer registrieren
    bool IsSunk()                 // Schiff versenkt?
}
```

**SPIELFELD-DARSTELLUNG:**
```
     1   2   3   4   5   6
 A │ ~   ~   ~   ~   ~   ~ │
 B │ ~   ■   ■   ■   ~   ~ │  ← Dein Schiff (Größe 3)
 C │ ~   ~   X   ~   ~   ~ │  ← Treffer
 D │ ~   ○   ~   ~   ~   ~ │  ← Fehlschuss
 E │ ~   ~   ~   ~   ~   ~ │
 F │ ~   ~   ~   ~   ~   ~ │

Legende:
~ = Wasser (noch nicht beschossen)
■ = Schiff (nur auf eigenem Feld sichtbar)
X = Treffer (rot angezeigt)
○ = Fehlschuss (blau angezeigt)
```

**SPIELMODI:**
1. Spieler vs Computer
2. Spieler vs Spieler (Hotseat)

**FELDGRÖ

ẞEN:**
- Klein (6x6): Schiffe 4, 3, 2
- Groß (8x8): Schiffe 5, 4, 3, 2

**ANGRIFFS-MECHANIK:**
```csharp
public char Attack(int row, int col)
{
    // Bereits beschossen?
    if (Grid[row, col] == 'X' || Grid[row, col] == 'O')
        return '?';  // Ungültig
    
    // Treffer?
    if (Grid[row, col] == 'S')
    {
        Grid[row, col] = 'X';  // Markiere Treffer
        // Schiff als getroffen markieren
        foreach (var ship in ships)
            if (ship.IsAt(row, col))
                ship.Hit(row, col);
        return 'X';  // Treffer!
    }
    else
    {
        Grid[row, col] = 'O';  // Markiere Fehlschuss
        return 'O';  // Wasser!
    }
}
```

**GEWINN-BEDINGUNG:**
```csharp
public bool AllShipsSunk()
{
    return ships.All(s => s.IsSunk());
    // Alle Schiffe haben alle Treffer?
}
```

---

## 🔄 SPIELABLAUF

### Haupt-Spielschleife in Präsidenten-Phase
```csharp
// 1. Hochzeit anbieten
if (!player.IstVerheiratet)
    MarriageSystem.OfferMarriage(player);

// 2. 10 Jahre regieren mit Geburten
for (int jahr = 0; jahr < 10; jahr++)
{
    player.Alter++;
    
    // Zufällige Geburt?
    MarriageSystem.RandomBirth(player);
    
    // Tod prüfen
    if (DeathSystem.CheckDeath(player))
    {
        var heir = DeathSystem.SelectHeir(player);
        
        // Keine Erben? Game Over
        if (heir == null)
        {
            Console.WriteLine("GAME OVER");
            return;
        }
        
        // Mit Erben weiterspielen
        player = heir;
        PlayStoryFromPhase(player, "Jurastudium");
        return;
    }
}

// 3. Regierungsstil wählen
ChooseGovernmentStyle(player);
```

---

## 📊 DATENFLUSS-DIAGRAMM

```
START
  ↓
Schwierigkeitsgrad wählen → Attribute verteilen
  ↓
┌─────────────┐
│ KINDHEIT    │ → Zufallsereignis → Entscheidung → Attribute ändern
└─────────────┘
  ↓
┌─────────────┐
│ KGB-PHASE   │ → Zufallsereignis → Easter Egg Check
└─────────────┘
  ↓
┌─────────────┐
│ STUDIUM     │ → Zufallsereignis → Loyalitäts-Wahl
└─────────────┘
  ↓
┌─────────────┐
│ DDR-EINSATZ │ → Zufallsereignis → Kritische Entscheidung
└─────────────┘
  ↓
┌─────────────┐
│ PRÄSIDENT   │ → Hochzeit → 10 Jahre mit Geburten → Tod-Check
└─────────────┘
  ↓
TOD?
├─ JA → Kinder vorhanden?
│       ├─ JA → Nachfolger wählen → Zurück zu STUDIUM
│       └─ NEIN → GAME OVER
└─ NEIN → Regierungsstil wählen → ENDE (Speichern)
```

---

## 💾 SPEICHER-SYSTEM

**Speicherung:**
```csharp
public static void SaveGame(PlayerCharacter player, FamilyTree family)
{
    // 1. Zeige vorhandene Slots
    for (int i = 1; i <= 5; i++)
        DisplaySlot(i);
    
    // 2. Spieler wählt Slot [1-5]
    int slot = GetInput();
    
    // 3. Überschreiben bestätigen?
    if (SlotExists(slot))
        if (!ConfirmOverwrite()) return;
    
    // 4. Spieler gibt Namen ein
    Console.Write("Spielstand-Name: ");
    string name = Console.ReadLine();
    
    // 5. Speichern
    GameSave save = new GameSave(name, player);
    saves[slot] = save;
    
    Console.WriteLine($"✓ Gespeichert in Slot {slot}!");
}
```

**Laden:**
```csharp
public static (PlayerCharacter, FamilyTree) LoadGame()
{
    // 1. Zeige alle Saves
    foreach (var save in saves)
        DisplaySaveInfo(save);
    
    // 2. Spieler wählt Slot
    int slot = GetInput();
    
    // 3. Lade und returniere
    if (saves.ContainsKey(slot))
        return (saves[slot].Character, saves[slot].Family);
    
    return (null, null);
}
```

---

## 🎯 STRATEGISCHE TIEFE

### Attribut-Management
- **Stärke:** Wichtig bei Kämpfen, Drill, Hardliner-Politik
- **Intelligenz:** Kritisch für Spionage, Intrigen, Reformen
- **Charisma:** Entscheidend für Führung, Diplomatie, Volk
- **Kraft:** Gesundheits-Buffer, Ausdauer bei Stress

### Loyalitäts-Balance
```
Partei ←→ Volk
  ↕        ↕
 KGB ←→ Familie
```
Schwierig alle hoch zu halten! Kompromisse nötig.

### Hochzeits-Strategie

**Szenario A: Sicherheits-Spieler**
- Katya heiraten (5★)
- 75% Geburtenrate
- Erwartung: 7-8 Kinder
- Vorteil: Viele Erben, sichere Nachfolge
- Nachteil: Kein Geld, schwierige Macht-Konsolidierung

**Szenario B: Risiko-Spieler**
- Natasha heiraten (1★)
- 15% Geburtenrate
- +300 Rubel sofort
- Erwartung: 1-2 Kinder
- Vorteil: Reich, viel Bestechung möglich
- Nachteil: Hohe Chance auf GAME OVER bei Tod

**Szenario C: Balance-Spieler**
- Svetlana heiraten (3★)
- 45% Geburtenrate
- +100 Rubel
- Erwartung: 3-5 Kinder
- Ausgewogenes Spiel

---

## 🐛 ERROR HANDLING

**Tod ohne Erben:**
```csharp
if (player.Kinder.Count == 0)
{
    Console.WriteLine("⚠ GAME OVER - Keine Erben!");
    return null;
}
```

**Ungültige Eingaben:**
```csharp
while (true)
{
    Console.Write("Eingabe: ");
    if (int.TryParse(Console.ReadLine(), out int value))
        if (value >= min && value <= max)
            return value;
    Console.WriteLine("Ungültig!");
}
```

**Gesundheit-Minimum:**
```csharp
player.Gesundheit = Math.Max(0, player.Gesundheit - damage);
// Verhindert negative Werte
```

---

## 📈 PERFORMANCE-OPTIMIERUNG

**LINQ statt Loops:**
```csharp
// Vorher
bool allSunk = true;
foreach (var ship in ships)
    if (!ship.IsSunk())
        allSunk = false;

// Nachher
bool allSunk = ships.All(s => s.IsSunk());
```

**Frühe Returns:**
```csharp
public void RandomBirth(Player p)
{
    if (!p.IstVerheiratet) return;  // Früher Exit
    if (rand.Next(100) >= chance) return;
    // ... Rest nur wenn nötig
}
```

---

## 🎓 LERNZIELE & KONZEPTE

### C# Konzepte verwendet:
1. **Klassen & OOP:** PlayerCharacter, GameSave, etc.
2. **Listen:** `List<PlayerCharacter>`, `List<RandomEvent>`
3. **Dictionaries:** `Dictionary<int, GameSave>`
4. **LINQ:** `.All()`, `.Where()`, `.OrderBy()`
5. **Lambda-Expressions:** `p => p.Gesundheit -= 10`
6. **Action Delegates:** `Action<PlayerCharacter>`
7. **Threading:** `Task.Run()` für Musik
8. **2D-Arrays:** `char[,]` für Spielfeld
9. **Enums:** Könnte noch hinzugefügt werden
10. **Nullable Types:** Rückgabe von `(PlayerCharacter, FamilyTree)`

### Software-Design Patterns:
1. **Factory Pattern:** Charakter-Erstellung
2. **Strategy Pattern:** Verschiedene Ehefrau-Optionen
3. **Observer Pattern:** Event-System
4. **State Pattern:** Lebensphasen
5. **Singleton Pattern:** Könnte für GameManager verwendet werden

---

## 📝 ZUSAMMENFASSUNG DER ÄNDERUNGEN

### TAG 1: Basis-Spiel
- ✅ Hauptmenü mit ASCII-Art
- ✅ 5 Lebensphasen implementiert
- ✅ Basis-Attribut-System
- ✅ Schwierigkeitsgrade
- ✅ Speicher/Laden (einfach)

### TAG 2: Story & Events
- ✅ 20+ Zufallsereignisse
- ✅ Interaktive Entscheidungen
- ✅ Attribut-abhängige Events
- ✅ Loyalitäts-System erweitert

### TAG 3: Familie & Generationen
- ✅ Hochzeits-System (5 Frauen)
- ✅ Geburten-System (zufällig)
- ✅ Tod & Nachfolge
- ✅ Stammbaum-Visualisierung
- ✅ Generationen-Spiel

### TAG 4: Verbesserungen
- ✅ Einzelgeburten statt Masse
- ✅ Namenseingabe für Kinder
- ✅ Zwillinge & Drillinge (Bonus)
- ✅ Schiffe-Versenken integriert
- ✅ Benutzerdefinierte Save-Namen

---

## 🚀 MÖGLICHE ERWEITERUNGEN

### Kurzfristig:
- [ ] Mehr Zufallsereignisse (30+)
- [ ] Sound-Effekte verbessern
- [ ] Mehr Ehefrau-Optionen
- [ ] Scheidungs-Mechanik

### Mittelfristig:
- [ ] Grafische Oberfläche (WinForms/WPF)
- [ ] Mehr Mini-Games
- [ ] Multiplayer-Modus
- [ ] Achievement-System

### Langfristig:
- [ ] 3D-Visualisierung
- [ ] Modding-Support
- [ ] Steam-Release
- [ ] Mobile Version

---

## 📞 SUPPORT & DOKUMENTATION

**Code-Kommentare:**
- Jede Klasse hat Header-Kommentar
- Komplexe Methoden erklärt
- Algorithmen dokumentiert

**Diese Dokumentation:**
- Vollständige Feature-Liste
- Code-Beispiele
- Ablauf-Diagramme
- Strategische Tipps

---

**ENDE DER DOKUMENTATION**

*Erstellt: Dezember 2024*  
*Version: 1.0*  
*Umfang: 1857 Zeilen C#*
