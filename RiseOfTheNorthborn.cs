/*
 * ════════════════════════════════════════════════════════════════════════════════
 * PROJEKT: Rise of the Northborn – Flad Rusputin Saga
 * ════════════════════════════════════════════════════════════════════════════════
 * 
 * BESCHREIBUNG:
 * Ein textbasiertes Rollenspiel in C#, das die fiktive Geschichte von Flad Rusputin
 * erzählt - vom Straßenkind bis zum Präsidenten einer dystopischen sowjetischen Nation.
 * 
 * HAUPTFEATURES:
 * - Lebensphasen-System: 5 verschiedene Lebensabschnitte spielbar
 * - Attribut-System: Stärke, Intelligenz, Charisma, Kraft
 * - Zufallsereignisse: 20+ dynamische Events basierend auf Entscheidungen
 * - Hochzeits-System: 5 verschiedene Ehepartner mit Trade-offs
 * - Geburten-System: Dynamische Kinderzeugung mit Namenseingabe
 * - Generationen-Spiel: Nach Tod mit Nachkommen weiterspielen
 * - Stammbaum-Funktion: Visualisierung der Familie über Generationen
 * - Speicher/Laden: 5 Slots mit benutzerdefinierten Namen
 * - Mini-Game: Vollständiges Schiffe-Versenken-Spiel
 * 
 * TECHNOLOGIE:
 * - Sprache: C# (.NET Framework 4.5+)
 * - Plattform: Windows, Linux (Mono), macOS (Mono)
 * - Architektur: Objektorientiert, ereignisbasiert
 * - UI: Konsolen-basiert mit ASCII-Grafik
 * 
 * ENTWICKELT: Dezember 2024
 * VERSION: 1.0
 * ZEILEN CODE: ~1857
 * 
 * ════════════════════════════════════════════════════════════════════════════════
 */

using System;                      // Basis-Funktionalität (Console, DateTime, etc.)
using System.Threading;            // Thread.Sleep für Verzögerungen
using System.Threading.Tasks;      // Task.Run für Hintergrundmusik
using System.Collections.Generic;  // List<T>, Dictionary<K,V> für Datenstrukturen
using System.Linq;                 // LINQ für Datenabfragen (All, Where, etc.)

// ═══════════════════════════════════════════════════════════════════
// DATENKLASSEN
// ═══════════════════════════════════════════════════════════════════

/// <summary>
/// PlayerCharacter - Hauptklasse für den Spielercharakter
/// 
/// Diese Klasse repräsentiert Flad Rusputin und alle seine Nachkommen.
/// Sie speichert alle wichtigen Daten über den Charakter:
/// - Basis-Attribute (Stärke, Intelligenz, etc.)
/// - Ressourcen (Geld, Gesundheit)
/// - Loyalitäts-Werte (Partei, Volk, Familie)
/// - Einfluss-Werte (KGB, Militär, International)
/// - Familiendaten (Kinder, Ehepartner)
/// 
/// ÄNDERUNG 1: Hochzeits-System hinzugefügt
/// - IstVerheiratet, EhepartnerName: Tracking des Ehe-Status
/// - GeburtenBonus, FinanzBonus: Trade-off zwischen Kindern und Geld
/// 
/// ÄNDERUNG 2: Generationen-System
/// - Generation: Welche Generation (1, 2, 3...)
/// - Kinder: Liste aller Nachkommen
/// - IstTot: Für Stammbaum-Visualisierung
/// </summary>
class PlayerCharacter
{
    // ═══ BASIS-INFORMATIONEN ═══
    public string Name;              // Voller Name des Charakters (z.B. "Vladimir Rusputin 2")
    public int Alter;                // Aktuelles Alter in Jahren
    public int Generation;           // Generationsnummer (1 = Gründer, 2 = Kinder, etc.)
    public string Phase;             // Aktuelle Lebensphase (Kindheit, KGB, Studium, DDR, Präsident)
    
    // ═══ ATTRIBUTE (Spieler-Fähigkeiten) ═══
    // Diese 4 Attribute beeinflussen Ereignisse und Entscheidungen
    public int Stärke;              // Körperliche Kraft, wichtig für Kämpfe
    public int Intelligenz;         // Klugheit, wichtig für Spionage und Politik
    public int Charisma;            // Überzeugungskraft, wichtig für Führung
    public int Kraft;               // Ausdauer und Widerstandsfähigkeit
    
    // ═══ RESSOURCEN ═══
    public int Geld;                // Finanzielle Mittel in Rubel
    public int Gesundheit;          // Gesundheitszustand 0-100% (0 = Tod)
    
    // ═══ LOYALITÄT (0-100%) ═══
    // Diese Werte zeigen, wie loyal verschiedene Gruppen dem Charakter gegenüber sind
    public int LoyalitätPartei;     // Loyalität zur kommunistischen Partei
    public int LoyalitätVolk;       // Unterstützung durch die Bevölkerung
    public int LoyalitätFamilie;    // Familiäre Bindungen und Treue
    
    // ═══ EINFLUSS (0-100%) ═══
    // Diese Werte zeigen den Einfluss in verschiedenen Machtbereichen
    public int EinflussKGB;         // Macht im Geheimdienst/Sicherheitsapparat
    public int EinflussMilitär;     // Einfluss beim Militär
    public int EinflussInternational; // Ansehen und Macht im Ausland
    
    // ═══ BESONDERE FLAGS ═══
    public bool KGBEasterEgg;       // TRUE wenn das geheime KGB-Event aktiviert wurde
    public bool GeheimeAusbildung;  // TRUE wenn geheime KGB-Ausbildung absolviert
    
    // ═══ HOCHZEITS-SYSTEM (ÄNDERUNG 1) ═══
    public bool IstVerheiratet;     // TRUE wenn verheiratet
    public string EhepartnerName;   // Name der Ehefrau
    public int GeburtenBonus;       // Geburtenrate 1-5 (höher = mehr Kinder)
    public int FinanzBonus;         // Geld-Bonus bei Heirat (Trade-off: weniger Kinder = mehr Geld)
    
    // ═══ FAMILIEN-SYSTEM (ÄNDERUNG 2) ═══
    public List<PlayerCharacter> Kinder;  // Liste aller Kinder (für Stammbaum)
    public bool IstTot;             // TRUE wenn Charakter verstorben (für Stammbaum-Visualisierung)
    
    /// <summary>
    /// Konstruktor - Erstellt einen neuen Charakter
    /// </summary>
    /// <param name="name">Vollständiger Name</param>
    /// <param name="generation">Generationsnummer (1, 2, 3...)</param>
    public PlayerCharacter(string name, int generation)
    {
        Name = name;
        Generation = generation;
        
        // Standard-Werte beim Start
        Gesundheit = 100;           // Volle Gesundheit
        Geld = 0;                   // Kein Startkapital
        LoyalitätPartei = 50;       // Neutral zur Partei
        LoyalitätVolk = 50;         // Neutral beim Volk
        LoyalitätFamilie = 80;      // Hohe Familienbindung
        Phase = "Geburt";           // Startet bei Geburt
        
        // Listen und Flags initialisieren
        Kinder = new List<PlayerCharacter>();
        IstVerheiratet = false;
        IstTot = false;
        GeburtenBonus = 0;
        FinanzBonus = 0;
    }
}

/// <summary>
/// GameSave - Speicherstand-Klasse
/// 
/// ÄNDERUNG 3: Erweitertes Speicher/Laden-System
/// 
/// Diese Klasse speichert einen kompletten Spielstand mit:
/// - Benutzerdefiniertem Namen (vom Spieler eingegeben)
/// - Datum und Uhrzeit der Speicherung
/// - Kompletten Charakterdaten
/// - Generationsnummer für Übersicht
/// 
/// VERBESSERUNG gegenüber vorher:
/// - Vorher: Nur automatische Namen
/// - Jetzt: Spieler kann eigenen Namen vergeben (z.B. "Mein Hardliner-Durchlauf")
/// </summary>
class GameSave
{
    public string SaveName;          // Vom Spieler vergebener Name
    public DateTime SaveDate;        // Zeitstempel der Speicherung (DD.MM.YYYY HH:MM:SS)
    public PlayerCharacter Character; // Kompletter Charakterzustand
    public int Generation;           // Generationsnummer für Übersicht
    
    /// <summary>
    /// Konstruktor - Erstellt einen neuen Spielstand
    /// </summary>
    public GameSave(string name, PlayerCharacter character)
    {
        SaveName = name;
        SaveDate = DateTime.Now;      // Aktuelles Datum/Uhrzeit
        Character = character;
        Generation = character.Generation;
    }
}

// ═══════════════════════════════════════════════════════════════════
// ZUFALLSEREIGNISSE
// ═══════════════════════════════════════════════════════════════════

/// <summary>
/// RandomEvent - Repräsentiert ein Zufallsereignis während des Spiels
/// 
/// Diese Klasse definiert dynamische Ereignisse, die während verschiedener
/// Lebensphasen von Flad auftreten können und seine Attribute beeinflussen.
/// 
/// MECHANIK:
/// - Jedes Event hat eine Wahrscheinlichkeit (0-100%) pro Phase
/// - Events werden durch Action<PlayerCharacter> ausgeführt
/// - Können Attribute, Ressourcen und Loyalitäten verändern
/// - Manche Events sind interaktiv (Spieler muss wählen)
/// - Andere sind attribut-abhängig (Ergebnis variiert je nach Werten)
/// 
/// BEISPIEL:
///   new RandomEvent("Verlust des Bruders", 
///                   "Flad verliert...",
///                   "Kindheit", 
///                   20,  // 20% Chance
///                   p => { p.Gesundheit -= 10; p.Stärke += 1; })
/// </summary>
class RandomEvent
{
    public string Name;              // Bezeichnung des Ereignisses
    public string Description;       // Beschreibung was passiert
    public string Phase;             // In welcher Lebensphase tritt es auf?
    public int Chance;               // Wahrscheinlichkeit 0-100%
    
    public Action<PlayerCharacter> Apply;  // Lambda-Funktion die die Effekte ausführt
    
    /// <summary>
    /// Konstruktor - Erstellt ein neues Zufallsereignis
    /// </summary>
    public RandomEvent(string name, string desc, string phase, int chance, Action<PlayerCharacter> apply)
    {
        Name = name;
        Description = desc;
        Phase = phase;
        Chance = chance;
        Apply = apply;
    }
}

// ═══════════════════════════════════════════════════════════════════
// HOCHZEITS-SYSTEM (ÄNDERUNG 4)
// ═══════════════════════════════════════════════════════════════════
/*
 * HOCHZEITS-MECHANIK:
 * 
 * Während der Präsidenten-Phase kann Flad eine von 5 Frauen heiraten.
 * Jede Frau bietet einen anderen Trade-off:
 * 
 * ┌─────────────┬─────────────┬──────────────┬───────────────┐
 * │ Frau        │ Kinderrate  │ Geld-Bonus   │ Loyalität     │
 * ├─────────────┼─────────────┼──────────────┼───────────────┤
 * │ Natasha     │ 1★ (wenig)  │ +300 Rubel   │ +5%           │
 * │ Olga        │ 2★          │ +200 Rubel   │ +10%          │
 * │ Svetlana    │ 3★          │ +100 Rubel   │ +15%          │
 * │ Irina       │ 4★          │ +50 Rubel    │ +20%          │
 * │ Katya       │ 5★ (viele)  │ +0 Rubel     │ +25%          │
 * └─────────────┴─────────────┴──────────────┴───────────────┘
 * 
 * STRATEGISCHE ÜBERLEGUNG:
 * - Mehr Kinder = Mehr Erben bei Tod = Sicherheit
 * - Mehr Geld = Mehr Bestechung/Einfluss = Macht
 * - Spieler muss abwägen: Sicherheit vs. Reichtum
 * 
 * IMPLEMENTIERUNG:
 * - GeburtenRate bestimmt Wahrscheinlichkeit pro Jahr (15%, 30%, 45%, 60%, 75%)
 * - GeldBonus wird sofort bei Heirat ausgezahlt
 * - LoyalitätBonus erhöht Familien-Loyalität permanent
 */

/// <summary>
/// WifeOption - Repräsentiert eine heiratsfähige Frau
/// </summary>
class WifeOption
{
    public string Name;              // Name der Frau
    public string Beschreibung;      // Kurzbeschreibung ihres Charakters
    public int GeburtenRate;         // 1-5 Sterne (höher = mehr Kinder)
    public int GeldBonus;            // Sofortige Mitgift in Rubel
    public int LoyalitätBonus;       // Bonus auf Familien-Loyalität
    
    public WifeOption(string name, string desc, int kinder, int geld, int loy)
    {
        Name = name;
        Beschreibung = desc;
        GeburtenRate = kinder;
        GeldBonus = geld;
        LoyalitätBonus = loy;
    }
}

/// <summary>
/// MarriageSystem - Verwaltung von Hochzeit und Geburten
/// 
/// ÄNDERUNG 4: Komplett neues System
/// ÄNDERUNG 5: Einzelgeburten mit Namenseingabe
/// ÄNDERUNG 6: Zwillinge und Drillinge als Bonus
/// </summary>
static class MarriageSystem
{
    static Random rand = new Random();
    
    static List<WifeOption> wives = new List<WifeOption>
    {
        new WifeOption(
            "Natasha - Die Oligarchin",
            "Reiche Geschäftsfrau mit wenig Zeit für Familie",
            1, 300, 5  // Wenig Kinder, viel Geld
        ),
        new WifeOption(
            "Olga - Die Diplomatin",
            "Karrierefrau, international angesehen",
            2, 200, 10
        ),
        new WifeOption(
            "Svetlana - Die Ausgewogene",
            "Balance zwischen Karriere und Familie",
            3, 100, 15
        ),
        new WifeOption(
            "Irina - Die Traditionelle",
            "Widmet sich der Familie und Kindern",
            4, 50, 20
        ),
        new WifeOption(
            "Katya - Die Mutter Russlands",
            "Kinderreich, traditionell, häuslich",
            5, 0, 25  // Viele Kinder, kein Geld
        )
    };
    
    public static void OfferMarriage(PlayerCharacter player)
    {
        if (player.IstVerheiratet)
        {
            Console.WriteLine("\n>> Du bist bereits verheiratet!");
            return;
        }
        
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                    💒 HOCHZEIT 💒                         ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");
        Console.ResetColor();
        
        Console.WriteLine("\nFlad ist bereit zu heiraten! Wähle deine Ehefrau:\n");
        
        for (int i = 0; i < wives.Count; i++)
        {
            var wife = wives[i];
            Console.WriteLine($"[{i + 1}] {wife.Name}");
            Console.WriteLine($"    {wife.Beschreibung}");
            Console.WriteLine($"    Kinder: {GetStars(wife.GeburtenRate)} | Geld-Bonus: +{wife.GeldBonus} Rubel");
            Console.WriteLine($"    Loyalität-Bonus: +{wife.LoyalitätBonus}%");
            Console.WriteLine();
        }
        
        Console.Write($"Wähle [1-{wives.Count}]: ");
        if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= wives.Count)
        {
            var chosen = wives[choice - 1];
            player.IstVerheiratet = true;
            player.EhepartnerName = chosen.Name;
            player.GeburtenBonus = chosen.GeburtenRate;
            player.FinanzBonus = chosen.GeldBonus;
            player.Geld += chosen.GeldBonus;
            player.LoyalitätFamilie = Math.Min(100, player.LoyalitätFamilie + chosen.LoyalitätBonus);
            
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n💒 Flad heiratet {chosen.Name}!");
            Console.ResetColor();
            Console.WriteLine($"\nMitgift: +{chosen.GeldBonus} Rubel");
            Console.WriteLine($"Familien-Loyalität: +{chosen.LoyalitätBonus}%");
            Console.WriteLine($"Erwartete Kinderzahl: {chosen.GeburtenRate}");
            Thread.Sleep(2500);
        }
    }
    
    /// <summary>
    /// RandomBirth - Zufällige Geburt eines oder mehrerer Kinder
    /// 
    /// ÄNDERUNG 5: Einzelgeburten statt Massengeneration
    /// ÄNDERUNG 6: Zwillinge/Drillinge-System
    /// ÄNDERUNG 7: Spieler gibt Namen ein
    /// 
    /// ABLAUF:
    /// 1. Prüfung ob verheiratet
    /// 2. Wahrscheinlichkeits-Check basierend auf gewählter Ehefrau
    /// 3. Bonus-Check für Zwillinge (5%) oder Drillinge (1%)
    /// 4. Für jedes Kind:
    ///    - Geschlecht zufällig bestimmen
    ///    - Spieler gibt Vornamen ein
    ///    - Attribute vererben (Elternwerte ±1-2)
    ///    - Zur Kinder-Liste hinzufügen
    /// 5. Familien-Loyalität erhöhen
    /// 
    /// VERERBUNGS-MECHANIK:
    /// - Jedes Attribut = Elternwert + Zufallszahl(-1 bis +2)
    /// - Minimum ist 0 (kein Negativ-Wert möglich)
    /// - Ermöglicht stärkere ODER schwächere Nachkommen
    /// </summary>
    public static void RandomBirth(PlayerCharacter player)
    {
        // Nur wenn verheiratet
        if (!player.IstVerheiratet) return;
        
        // Berechne Geburts-Wahrscheinlichkeit basierend auf Ehefrau
        // GeburtenBonus 1-5 * 15% = 15%, 30%, 45%, 60%, 75%
        int chance = player.GeburtenBonus * 15;
        
        // Zufalls-Check: Findet eine Geburt statt?
        if (rand.Next(100) < chance)
        {
            // Zwillings-/Drillings-Chance (5% für Zwillinge, 1% für Drillinge)
            int birthCount = 1;
            int multipleChance = rand.Next(100);
            if (multipleChance < 1) // 1% Drillinge
            {
                birthCount = 3;
            }
            else if (multipleChance < 6) // 5% Zwillinge
            {
                birthCount = 2;
            }
            
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
            
            if (birthCount == 1)
                Console.WriteLine("║                    👶 GEBURT! 👶                          ║");
            else if (birthCount == 2)
                Console.WriteLine("║                👶👶 ZWILLINGE! 👶👶                      ║");
            else
                Console.WriteLine("║              👶👶👶 DRILLINGE! 👶👶👶                    ║");
            
            Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");
            Console.ResetColor();
            
            for (int i = 0; i < birthCount; i++)
            {
                bool isBoy = rand.Next(2) == 0;
                
                Console.WriteLine($"\n🎉 {player.EhepartnerName} hat ein {(isBoy ? "Junge" : "Mädchen")} geboren!");
                
                // Spieler gibt Namen ein
                Console.Write($"\nGib dem {(i + 1)}. Kind einen Vornamen: ");
                string vorname = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(vorname))
                    vorname = isBoy ? "Vladimir" : "Natasha";
                
                string childName = $"{vorname} Rusputin {player.Generation + 1}";
                
                PlayerCharacter child = new PlayerCharacter(childName, player.Generation + 1);
                child.Alter = 0;
                child.Phase = "Kind";
                
                // Attribute vererben mit Variation
                child.Stärke = Math.Max(0, player.Stärke + rand.Next(-1, 3));
                child.Intelligenz = Math.Max(0, player.Intelligenz + rand.Next(-1, 3));
                child.Charisma = Math.Max(0, player.Charisma + rand.Next(-1, 3));
                child.Kraft = Math.Max(0, player.Kraft + rand.Next(-1, 3));
                
                player.Kinder.Add(child);
                
                Console.WriteLine($"\n✓ {childName} wurde geboren!");
                Console.WriteLine($"Attribute: S:{child.Stärke} I:{child.Intelligenz} C:{child.Charisma} K:{child.Kraft}");
                
                if (i < birthCount - 1)
                {
                    Console.WriteLine("\n[Drücke eine Taste für nächstes Kind...]");
                    Console.ReadKey(true);
                }
            }
            
            Console.WriteLine($"\n\nFlad hat jetzt {player.Kinder.Count} Kind(er)!");
            player.LoyalitätFamilie = Math.Min(100, player.LoyalitätFamilie + (5 * birthCount));
            
            Console.WriteLine("\n[Drücke eine Taste...]");
            Console.ReadKey(true);
        }
    }
    
    static string GetStars(int count)
    {
        return new string('★', count) + new string('☆', 5 - count);
    }
}

// ═══════════════════════════════════════════════════════════════════
// TOD UND NACHFOLGE-SYSTEM
// ═══════════════════════════════════════════════════════════════════

static class DeathSystem
{
    static Random rand = new Random();
    
    public static bool CheckDeath(PlayerCharacter player)
    {
        // Tod durch Gesundheit
        if (player.Gesundheit <= 0)
        {
            ShowDeathScene(player, "tödlichen Verletzungen");
            return true;
        }
        
        // Tod durch Alter (nach Präsident)
        if (player.Phase == "Präsident" && player.Alter >= 65)
        {
            int deathChance = (player.Alter - 65) * 8; // 0% bei 65, 80% bei 75
            if (rand.Next(100) < deathChance)
            {
                ShowDeathScene(player, "Altersschwäche");
                return true;
            }
        }
        
        return false;
    }
    
    static void ShowDeathScene(PlayerCharacter player, string cause)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                         † TOD †                           ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");
        Console.ResetColor();
        
        Console.WriteLine($"\n{player.Name} ist im Alter von {player.Alter} Jahren");
        Console.WriteLine($"an {cause} gestorben.\n");
        Thread.Sleep(2000);
        
        Console.WriteLine("Seine Herrschaft war geprägt von:");
        Console.WriteLine($"  • Generation: {player.Generation}");
        Console.WriteLine($"  • Kinder: {player.Kinder.Count}");
        Console.WriteLine($"  • Vermögen: {player.Geld} Rubel");
        Console.WriteLine($"  • Gesundheit bei Tod: {player.Gesundheit}%\n");
        Thread.Sleep(2000);
        
        Console.WriteLine($"Loyalität zur Partei: {player.LoyalitätPartei}%");
        Console.WriteLine($"Loyalität zum Volk: {player.LoyalitätVolk}%");
        Console.WriteLine($"Einfluss beim KGB: {player.EinflussKGB}%\n");
        Thread.Sleep(2000);
        
        player.IstTot = true;
        
        Console.WriteLine("Die Dynastie geht weiter...");
        Console.WriteLine("\n[Drücke eine Taste...]");
        Console.ReadKey(true);
    }
    
    public static PlayerCharacter SelectHeir(PlayerCharacter deceased)
    {
        if (deceased.Kinder.Count == 0)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
            Console.WriteLine("║                      GAME OVER                            ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");
            Console.ResetColor();
            
            Console.WriteLine("\n⚠ Keine Erben vorhanden!");
            Console.WriteLine("Die Linie der Rusputins endet hier...");
            Console.WriteLine($"\nGeneration {deceased.Generation} war die letzte.");
            Thread.Sleep(3000);
            return null;
        }
        
        Console.Clear();
        Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
        Console.WriteLine("║              WÄHLE DEINEN NACHFOLGER                      ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════╝\n");
        
        Console.WriteLine($"{deceased.Name} ist verstorben.");
        Console.WriteLine("Wähle ein Kind, um die Dynastie fortzuführen:\n");
        
        for (int i = 0; i < deceased.Kinder.Count; i++)
        {
            var child = deceased.Kinder[i];
            Console.WriteLine($"[{i + 1}] {child.Name}");
            Console.WriteLine($"    Generation: {child.Generation}");
            Console.WriteLine($"    Attribute: S:{child.Stärke} I:{child.Intelligenz} C:{child.Charisma} K:{child.Kraft}");
            Console.WriteLine();
        }
        
        while (true)
        {
            Console.Write($"Wähle [1-{deceased.Kinder.Count}]: ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= deceased.Kinder.Count)
            {
                var heir = deceased.Kinder[choice - 1];
                
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                  NEUE GENERATION                          ║");
                Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");
                Console.ResetColor();
                
                Console.WriteLine($"\n{heir.Name} übernimmt die Dynastie!");
                Console.WriteLine($"Generation: {heir.Generation}");
                Console.WriteLine("\nGeerbte Attribute:");
                Console.WriteLine($"  Stärke: {heir.Stärke}");
                Console.WriteLine($"  Intelligenz: {heir.Intelligenz}");
                Console.WriteLine($"  Charisma: {heir.Charisma}");
                Console.WriteLine($"  Kraft: {heir.Kraft}");
                
                // Erbe erhält Teil des Vermögens
                heir.Geld = deceased.Geld / 2;
                heir.Alter = 25; // Startet als junger Erwachsener
                heir.Phase = "Jurastudium";
                heir.Gesundheit = 100;
                
                // Teil der Einflüsse wird vererbt
                heir.EinflussKGB = deceased.EinflussKGB / 3;
                heir.EinflussMilitär = deceased.EinflussMilitär / 3;
                heir.LoyalitätPartei = deceased.LoyalitätPartei / 2;
                
                Console.WriteLine($"\nGeerbtes Vermögen: {heir.Geld} Rubel");
                Console.WriteLine("\n[Drücke eine Taste um fortzufahren...]");
                Console.ReadKey(true);
                
                return heir;
            }
        }
    }
}

static class EventSystem
{
    static Random rand = new Random();
    static List<RandomEvent> allEvents = new List<RandomEvent>();
    
    public static void InitializeEvents()
    {
        // KINDHEIT EREIGNISSE
        allEvents.Add(new RandomEvent(
            "Verlust des Bruders",
            "Flad verliert seinen Bruder durch Krankheit. Ein traumatisches Ereignis...",
            "Kindheit", 20,
            p => {
                p.Gesundheit -= 10;
                p.LoyalitätFamilie = Math.Min(100, p.LoyalitätFamilie + 20);
                p.Stärke += 1; // Entschlossenheit
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Nächtliche Verhaftung",
            "Flad beobachtet, wie der KGB einen Nachbarn abholt. Die Schritte hallen im Treppenhaus...",
            "Kindheit", 30,
            p => {
                if (rand.Next(2) == 0)
                    p.LoyalitätPartei += 15; // Aus Angst
                else
                    p.LoyalitätPartei -= 10; // Zweifel am System
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Rauferei im Hinterhof",
            "Flad gerät in eine Prügelei mit Straßenjungen. Er setzt sich durch!",
            "Kindheit", 40,
            p => {
                p.Gesundheit -= 5;
                p.Stärke += 1;
                p.LoyalitätPartei -= 5; // Unruhestifter
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Heldengeschichte des Vaters",
            "Vater erzählt von seinen Kriegsheldentaten. Flad ist tief beeindruckt...",
            "Kindheit", 50,
            p => {
                p.LoyalitätPartei += 20;
                p.LoyalitätFamilie += 10;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Aufnahme bei den Jungpionieren",
            "Flad wird feierlich mit dem roten Halstuch ausgezeichnet!",
            "Kindheit", 60,
            p => {
                p.LoyalitätPartei += 15;
                p.Charisma += 1;
            }
        ));
        
        // JUGEND/KGB EREIGNISSE
        allEvents.Add(new RandomEvent(
            "Aufstieg in der Komsomol",
            "Flad wird zum Anführer der lokalen Jugendorganisation gewählt!",
            "KGB-Ambitionen", 40,
            p => {
                p.Charisma += 1;
                p.LoyalitätPartei += 20;
                p.EinflussKGB += 10;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Gefährlicher Freundeskreis",
            "Ein Freund wird bei regimekritischen Aktivitäten erwischt!",
            "KGB-Ambitionen", 25,
            p => {
                Console.WriteLine("\n[1] Freund decken (+Moral, -Partei)");
                Console.WriteLine("[2] Freund melden (+Partei, -Moral)");
                Console.Write("Wähle [1-2]: ");
                if (Console.ReadLine() == "1")
                {
                    p.LoyalitätFamilie += 15;
                    p.LoyalitätPartei -= 20;
                }
                else
                {
                    p.LoyalitätPartei += 25;
                    p.LoyalitätFamilie -= 15;
                    p.EinflussKGB += 10;
                }
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Unverhofftes Erbe",
            "Ein entfernter Onkel vermacht der Familie ein kleines Vermögen!",
            "Jurastudium", 15,
            p => {
                p.Geld += 200;
                p.LoyalitätPartei -= 5; // Neid
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Triumph auf der Judomatte",
            "Flad gewinnt die Stadtmeisterschaft im Judo!",
            "Jurastudium", 35,
            p => {
                p.Kraft += 2;
                p.Gesundheit = Math.Min(100, p.Gesundheit + 10);
                p.Charisma += 1;
            }
        ));
        
        // KGB AUSBILDUNG
        allEvents.Add(new RandomEvent(
            "Drill und Disziplin",
            "Gnadenloser Drill in der KGB-Akademie. Flad trägt einen Kameraden kilometerweit...",
            "Jurastudium", 30,
            p => {
                p.Gesundheit -= 15;
                p.Kraft += 2;
                p.Stärke += 1;
                p.EinflussKGB += 15;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Enttarnter Maulwurf",
            "Ein Mitkadett ist ein westlicher Spion! Er verschwindet für immer...",
            "Jurastudium", 20,
            p => {
                if (p.Intelligenz >= 3)
                {
                    Console.WriteLine("Du bemerkst Ungereimtheiten und meldest es!");
                    p.EinflussKGB += 20;
                    p.LoyalitätPartei += 15;
                }
                else
                {
                    p.LoyalitätPartei -= 10; // Schock
                }
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Geheimer Testeinsatz",
            "Flad erhält seinen ersten Feldauftrag - Intellektuelle observieren!",
            "Jurastudium", 40,
            p => {
                if (rand.Next(100) < 60) // Erfolg
                {
                    p.EinflussKGB += 15;
                    p.Intelligenz += 1;
                    p.Geld += 50;
                }
                else
                {
                    p.Gesundheit -= 20;
                    p.EinflussKGB -= 10;
                }
            }
        ));
        
        // DDR & AUSLAND
        allEvents.Add(new RandomEvent(
            "Aufruhr in der Botschaft",
            "Protestierende stürmen die sowjetische Residenz!",
            "DDR-Einsatz", 45,
            p => {
                Console.WriteLine("\n[1] Dokumente verbrennen");
                Console.WriteLine("[2] Menge besänftigen");
                Console.Write("Wähle [1-2]: ");
                if (Console.ReadLine() == "1")
                {
                    p.EinflussKGB += 20;
                }
                else if (p.Charisma >= 3)
                {
                    p.Charisma += 1;
                    p.EinflussInternational += 15;
                }
                else
                {
                    p.Gesundheit -= 30;
                    p.EinflussKGB -= 20;
                }
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Doppelspiel eines Informanten",
            "Ein Agent spielt doppelt für den Westen!",
            "DDR-Einsatz", 30,
            p => {
                Console.WriteLine("\n[1] Ausschalten (+Loyalität)");
                Console.WriteLine("[2] Als Doppelagenten nutzen (Risiko)");
                Console.Write("Wähle [1-2]: ");
                if (Console.ReadLine() == "1")
                {
                    p.LoyalitätPartei += 15;
                    p.LoyalitätFamilie -= 10;
                }
                else
                {
                    if (rand.Next(100) < 50)
                    {
                        p.EinflussInternational += 25;
                    }
                    else
                    {
                        p.EinflussKGB -= 30;
                    }
                }
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Erfolgreicher Coup",
            "Flad rekrutiert einen hochrangigen westlichen Offizier!",
            "DDR-Einsatz", 25,
            p => {
                p.EinflussKGB += 30;
                p.Geld += 100;
                p.LoyalitätPartei += 20;
            }
        ));
        
        // PRÄSIDENT
        allEvents.Add(new RandomEvent(
            "Intrige im Politbüro",
            "Ein Rivale versucht, Flad zu stürzen!",
            "Präsident", 35,
            p => {
                if (p.Intelligenz >= 4 || p.EinflussKGB >= 50)
                {
                    p.EinflussKGB += 20;
                    p.LoyalitätPartei += 15;
                }
                else
                {
                    p.EinflussKGB -= 25;
                    p.Geld -= 100;
                }
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Attentatsversuch",
            "Schüsse in der Nacht! Ein Attentäter zielt auf Flad!",
            "Präsident", 20,
            p => {
                p.Gesundheit -= 40;
                p.LoyalitätVolk += 30; // Sympathie
                p.EinflussKGB += 15; // Leibwächter engagierter
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Verrat im Umfeld",
            "Ein enger Vertrauter ist ein Spion!",
            "Präsident", 25,
            p => {
                p.LoyalitätFamilie -= 20;
                p.LoyalitätPartei -= 15;
                if (p.EinflussKGB >= 40)
                {
                    p.EinflussKGB += 10; // Aufgedeckt und gesäubert
                }
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Nervenzusammenbruch",
            "Die jahrelange Belastung fordert ihren Tribut...",
            "Präsident", 15,
            p => {
                p.Gesundheit -= 30;
                p.EinflussKGB -= 20;
                p.LoyalitätFamilie += 15; // Familie steht bei
            }
        ));
    }
    
    public static void TriggerRandomEvent(PlayerCharacter player)
    {
        var possibleEvents = allEvents.Where(e => 
            e.Phase == player.Phase && 
            rand.Next(100) < e.Chance
        ).ToList();
        
        if (possibleEvents.Count == 0) return;
        
        var chosen = possibleEvents[rand.Next(possibleEvents.Count)];
        
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                  ⚡ ZUFALLSEREIGNIS ⚡                     ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");
        Console.ResetColor();
        
        Console.WriteLine($"\n📰 {chosen.Name}\n");
        Console.WriteLine(chosen.Description);
        Console.WriteLine("\n[Drücke eine Taste...]");
        Console.ReadKey(true);
        
        chosen.Apply(player);
        
        Console.WriteLine("\n✓ Ereignis verarbeitet!");
        Thread.Sleep(1500);
    }
}

class Program
{
    static bool stopMusic = false;
    static Dictionary<int, GameSave> saveSlots = new Dictionary<int, GameSave>();
    static Random rand = new Random();
    static PlayerCharacter currentPlayer = null;
    
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        EventSystem.InitializeEvents(); // Ereignisse laden
        ShowIntro();
        MainMenu();
    }
    
    static void ShowIntro()
    {
        Console.BackgroundColor = ConsoleColor.Red;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Clear();
        
        Console.WriteLine(@"
            ▄▀▄▀              
          ▄▐▓▓▓▌▄            
          ▐▓▓▓▓▓▌            
        ▄▀▓▓▓▓▓▓▓▀▄          
      ▄▀  ▀▀▀▀▀▀▀  ▀▄        
    ▄▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▄       
   █  ☆              ☆  █    
  █                      █   
 █    ⚒                  █  
█   ☭                     █ 
");
        
        Console.WriteLine("══════════════════════════════════════════════════════════════");
        Console.WriteLine("║      RISE OF THE NORTHBORN – FLAD RUSPUTIN SAGA          ║");
        Console.WriteLine("══════════════════════════════════════════════════════════════");
        Thread.Sleep(200);
        
        Task.Run(() => PlayMusic());
        
        Console.WriteLine("\n[ Drücke eine Taste... ]");
        Console.ReadKey(true);
    }
    
    static void MainMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            
            Console.WriteLine("══════════════════════════════════════════════════════════════");
            Console.WriteLine("║   ☭                   RUSPUTIN DYNASTY                 ☭   ║");
            Console.WriteLine("══════════════════════════════════════════════════════════════");
            Console.ResetColor();
            
            Console.WriteLine("\n[1] Neues Spiel – Aufstieg zur Macht");
            Console.WriteLine("[2] Spiel Laden");
            Console.WriteLine("[3] Stammbaum ansehen 🌳");
            Console.WriteLine("[4] Mini-Game: Schiffe versenken ⚓");
            Console.WriteLine("[5] Spielstände verwalten");
            Console.WriteLine("[6] Beenden");
            
            Console.Write("\nWähle [1-6]: ");
            string input = Console.ReadLine();
            
            switch (input)
            {
                case "1": StartNewGame(); break;
                case "2": LoadGame(); break;
                case "3": ShowFamilyTree(); break;
                case "4":
                    stopMusic = true;
                    Thread.Sleep(200);
                    BattleshipGame.Play();
                    stopMusic = false;
                    Task.Run(() => PlayMusic());
                    break;
                case "5": ManageSaves(); break;
                case "6":
                    stopMusic = true;
                    Console.WriteLine("\n>> Auf Wiedersehen, Genosse!");
                    Thread.Sleep(1000);
                    return;
            }
        }
    }
    
    static void StartNewGame()
    {
        stopMusic = true;
        Thread.Sleep(300);
        
        Console.Clear();
        Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
        Console.WriteLine("║      FLAD: AUFSTIEG IN EINER SOWJETISCHEN DYSTOPIE        ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════╝\n");
        
        Console.WriteLine("1952, Leningrad – In einer verfallenen Scheune");
        Console.WriteLine("erblickt Flad das Licht der Welt...\n");
        Thread.Sleep(2000);
        
        // Schwierigkeitsgrad
        int difficulty = ChooseDifficulty();
        
        // Charakter erstellen
        currentPlayer = new PlayerCharacter("Flad Rusputin", 1);
        currentPlayer.Alter = 0;
        
        // Attribute verteilen
        DistributeAttributes(currentPlayer, difficulty);
        
        // Story durchspielen
        PlayStory(currentPlayer);
        
        // Am Ende speichern anbieten
        Console.WriteLine("\n>> Möchtest du speichern? [J/N]");
        if (Console.ReadKey(true).Key == ConsoleKey.J)
        {
            SaveGame(currentPlayer);
        }
        
        stopMusic = false;
        Task.Run(() => PlayMusic());
    }
    
    static int ChooseDifficulty()
    {
        Console.Clear();
        Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
        Console.WriteLine("║            SCHWIERIGKEITSGRAD WÄHLEN                      ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════╝\n");
        
        Console.WriteLine("[1] Leicht - Alle Attribute bei 1, +500 Rubel");
        Console.WriteLine("[2] Mittel - 3 Attributpunkte verteilen");
        Console.WriteLine("[3] Hart - 2 Punkte, 70% Gesundheit");
        Console.WriteLine("[4] Kalter Krieg - 1 Punkt, Schulden, +20% KGB\n");
        
        while (true)
        {
            Console.Write("Wähle [1-4]: ");
            if (int.TryParse(Console.ReadLine(), out int diff) && diff >= 1 && diff <= 4)
                return diff;
        }
    }
    
    static void DistributeAttributes(PlayerCharacter player, int difficulty)
    {
        Console.Clear();
        Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
        Console.WriteLine("║           ATTRIBUT-VERTEILUNG BEI GEBURT                  ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════╝\n");
        
        int points = 0;
        
        switch (difficulty)
        {
            case 1: // Leicht
                player.Stärke = player.Intelligenz = player.Charisma = player.Kraft = 1;
                player.Geld = 500;
                Console.WriteLine("LEICHT: Alle Attribute bei 1, +500 Rubel");
                Thread.Sleep(2000);
                return;
            case 2: points = 3; break;
            case 3: points = 2; player.Gesundheit = 70; break;
            case 4: points = 1; player.Geld = -200; player.EinflussKGB = 20; break;
        }
        
        Console.WriteLine($"Du hast {points} Punkte zu verteilen:\n");
        Console.WriteLine("[1] Stärke    [2] Intelligenz");
        Console.WriteLine("[3] Charisma  [4] Kraft\n");
        
        while (points > 0)
        {
            Console.WriteLine($"Punkte: {points} | Stärke:{player.Stärke} Int:{player.Intelligenz} Char:{player.Charisma} Kraft:{player.Kraft}");
            Console.Write("Erhöhe [1-4]: ");
            
            if (int.TryParse(Console.ReadLine(), out int attr) && attr >= 1 && attr <= 4)
            {
                switch (attr)
                {
                    case 1: player.Stärke++; break;
                    case 2: player.Intelligenz++; break;
                    case 3: player.Charisma++; break;
                    case 4: player.Kraft++; break;
                }
                points--;
            }
        }
        
        Console.WriteLine("\n✓ Attribute verteilt!");
        Thread.Sleep(1500);
    }
    
    static void PlayStoryFromPhase(PlayerCharacter player, string startPhase)
    {
        switch (startPhase)
        {
            case "Jurastudium":
                PlayJurastudium(player);
                PlayDDRPhase(player);
                PlayPresidentPhase(player);
                break;
            case "DDR-Einsatz":
                PlayDDRPhase(player);
                PlayPresidentPhase(player);
                break;
            case "Präsident":
                PlayPresidentPhase(player);
                break;
        }
    }
    
    static void PlayStory(PlayerCharacter player)
    {
        // KINDHEIT
        player.Alter = 10;
        player.Phase = "Kindheit";
        Console.Clear();
        Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
        Console.WriteLine("║              KINDHEIT IN LENINGRAD (1950er)               ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════╝\n");
        
        Console.WriteLine("Flad wächst in Armut auf. Sein Vater gibt ihm Judo-Training.\n");
        Thread.Sleep(1500);
        
        // Zufallsereignis auslösen
        EventSystem.TriggerRandomEvent(player);
        
        Console.WriteLine("[1] Kämpferische Kindheit (+2 Stärke, -15 Gesundheit)");
        Console.WriteLine("[2] Disziplin durch Sport (+2 Kraft, +1 Charisma)");
        Console.WriteLine("[3] Wissbegierig (+3 Intelligenz, +1 Charisma)\n");
        Console.Write("Wähle [1-3]: ");
        
        string choice = Console.ReadLine();
        if (choice == "1") { player.Stärke += 2; player.Gesundheit -= 15; }
        else if (choice == "2") { player.Kraft += 2; player.Charisma++; }
        else { player.Intelligenz += 3; player.Charisma++; }
        
        if (player.Intelligenz >= 2 || player.Charisma >= 2)
        {
            player.KGBEasterEgg = true;
            Console.WriteLine("\n💀 Ein KGB-Agent beobachtet Flad...");
            Thread.Sleep(2000);
        }
        
        ShowStats(player);
        Console.ReadKey(true);
        
        // KGB PHASE
        player.Alter = 16;
        player.Phase = "KGB-Ambitionen";
        
        // Zufallsereignis
        EventSystem.TriggerRandomEvent(player);
        Console.Clear();
        Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
        Console.WriteLine("║              KGB-AMBITIONEN (1968)                        ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════╝\n");
        
        Console.WriteLine("Mit 16 marschiert Flad zur KGB-Zentrale!\n");
        Thread.Sleep(1500);
        
        if (player.KGBEasterEgg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("═══ EASTER EGG! ═══\n");
            Console.ResetColor();
            Console.WriteLine("Ein Agent lädt ihn zur geheimen Ausbildung ein!\n");
            Console.WriteLine("[1] Annehmen (+30 KGB, +1 Intel, -20 Familie)");
            Console.WriteLine("[2] Ablehnen (normaler Weg)\n");
            Console.Write("Wähle [1-2]: ");
            
            if (Console.ReadLine() == "1")
            {
                player.GeheimeAusbildung = true;
                player.EinflussKGB += 30;
                player.Intelligenz++;
                player.LoyalitätFamilie -= 20;
                Console.WriteLine("\n>> Geheime Ausbildung absolviert!");
            }
        }
        else
        {
            Console.WriteLine("Er wird abgewiesen. Muss erst Jura studieren...");
        }
        
        Thread.Sleep(2000);
        ShowStats(player);
        Console.ReadKey(true);
        
        PlayJurastudium(player);
        PlayDDRPhase(player);
        PlayPresidentPhase(player);
    }
    
    static void PlayJurastudium(PlayerCharacter player)
    {
        // JURASTUDIUM
        player.Alter = 20;
        player.Phase = "Jurastudium";
        
        // Zufallsereignis
        EventSystem.TriggerRandomEvent(player);
        Console.Clear();
        Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
        Console.WriteLine("║         JURASTUDIUM (1970er)                              ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════╝\n");
        
        Console.WriteLine("Flad studiert Jura. Wem ist er loyal?\n");
        Console.WriteLine("[1] Partei (+30 Partei, +20 Geld, -15 Volk)");
        Console.WriteLine("[2] KGB (+40 KGB, -20 Familie, -10 Gesundheit)");
        Console.WriteLine("[3] Familie & Moral (+30 Familie, +20 Volk)\n");
        Console.Write("Wähle [1-3]: ");
        
        string choice = Console.ReadLine();
        if (choice == "1") 
        { 
            player.LoyalitätPartei = Math.Min(100, player.LoyalitätPartei + 30);
            player.Geld += 20;
            player.LoyalitätVolk -= 15;
        }
        else if (choice == "2")
        {
            player.EinflussKGB = Math.Min(100, player.EinflussKGB + 40);
            player.LoyalitätFamilie -= 20;
            player.Gesundheit -= 10;
        }
        else
        {
            player.LoyalitätFamilie = Math.Min(100, player.LoyalitätFamilie + 30);
            player.LoyalitätVolk = Math.Min(100, player.LoyalitätVolk + 20);
        }
        
        Thread.Sleep(1500);
        ShowStats(player);
        Console.ReadKey(true);
    }
    
    static void PlayDDRPhase(PlayerCharacter player)
    {
        player.Alter = 35;
        player.Phase = "DDR-Einsatz";
        
        // Zufallsereignis
        EventSystem.TriggerRandomEvent(player);
        Console.Clear();
        Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
        Console.WriteLine("║              EINSATZ IN DER DDR (1989)                    ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════╝\n");
        
        Console.WriteLine("Dresden, 1989: Demonstranten vor dem KGB-Gebäude!\n");
        Thread.Sleep(1500);
        
        Console.WriteLine("[1] Aufstand niederschlagen (+30 KGB, +100 Geld, -25 Gesundheit)");
        Console.WriteLine("[2] Sympathisieren & Flucht (+40 Volk, -40 KGB, -50 Geld)\n");
        Console.Write("Wähle [1-2]: ");
        
        if (Console.ReadLine() == "1")
        {
            player.EinflussKGB = Math.Min(100, player.EinflussKGB + 30);
            player.Geld += 100;
            player.Gesundheit -= 25;
            Console.WriteLine("\n>> Flad greift hart durch!");
        }
        else
        {
            player.EinflussKGB = Math.Max(0, player.EinflussKGB - 40);
            player.Geld -= 50;
            player.LoyalitätVolk = Math.Min(100, player.LoyalitätVolk + 40);
            Console.WriteLine("\n>> Flad flieht aus der DDR!");
        }
        
        Thread.Sleep(2000);
        ShowStats(player);
        Console.ReadKey(true);
    }
    
    static void PlayPresidentPhase(PlayerCharacter player)
    {
        // PRÄSIDENT
        player.Alter = 48;
        player.Phase = "Präsident";
        
        // Zufallsereignis
        EventSystem.TriggerRandomEvent(player);
        Console.Clear();
        Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
        Console.WriteLine("║       AUFSTIEG ZUM PRÄSIDENTEN (2000)                     ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════╝\n");
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(">> FLAD WIRD PRÄSIDENT VON RUSSLAND!");
        Console.ResetColor();
        Thread.Sleep(2000);
        
        // Hochzeit anbieten
        if (!player.IstVerheiratet)
        {
            Console.WriteLine("\n>> Als Präsident sollte Flad heiraten...");
            Thread.Sleep(1000);
            MarriageSystem.OfferMarriage(player);
        }
        
        // Mehrere Jahre als Präsident - zufällige Geburten
        Console.WriteLine("\n>> Flad regiert mehrere Jahre...");
        for (int jahr = 0; jahr < 10; jahr++)
        {
            player.Alter++;
            MarriageSystem.RandomBirth(player);
            
            // Tod prüfen
            if (DeathSystem.CheckDeath(player))
            {
                var heir = DeathSystem.SelectHeir(player);
                if (heir == null)
                {
                    Console.WriteLine("\n=== SPIEL BEENDET ===");
                    Console.ReadKey();
                    return;
                }
                
                // Mit Erben weiterspielen
                player = heir;
                Console.WriteLine("\n>> Der neue Anführer beginnt seine Karriere...");
                Thread.Sleep(2000);
                
                // Erbe startet im Studium
                PlayStoryFromPhase(player, "Jurastudium");
                return;
            }
            
            Thread.Sleep(300); // Kurze Pause zwischen Jahren
        }
        
        Console.WriteLine($"\n>> Flad hat {player.Kinder.Count} Kind(er)!");
        
        Console.WriteLine("\nRegierungsstil wählen:\n");
        Console.WriteLine("[1] Imperiale Expansion (+50 Militär, -200 Geld)");
        Console.WriteLine("[2] Diplomatie (+300 Geld, +40 International)");
        Console.WriteLine("[3] Eiserne Faust (+40 Partei, -50 Volk)\n");
        Console.Write("Wähle [1-3]: ");
        
        string choice = Console.ReadLine();
        if (choice == "1")
        {
            player.EinflussMilitär += 50;
            player.Geld -= 200;
            ShowEnding(player, "Imperial");
        }
        else if (choice == "2")
        {
            player.Geld += 300;
            player.EinflussInternational += 40;
            ShowEnding(player, "Diplomatisch");
        }
        else
        {
            player.LoyalitätPartei += 40;
            player.LoyalitätVolk -= 50;
            ShowEnding(player, "Diktator");
        }
    }
    
    // GenerateChildren entfernt - wird jetzt durch MarriageSystem.RandomBirth ersetzt
    
    static void ShowEnding(PlayerCharacter player, string type)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
        Console.WriteLine($"║              {type.ToUpper()} ENDE                               ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");
        Console.ResetColor();
        
        Thread.Sleep(1000);
        
        if (type == "Imperial")
        {
            if (player.Geld < -100)
                Console.WriteLine("\n⚠ Das Reich kollabiert unter Kriegskosten...");
            else
                Console.WriteLine("\n★ Russland erstrahlt in alter Größe!");
        }
        else if (type == "Diplomatisch")
        {
            if (player.EinflussKGB < 20)
                Console.WriteLine("\n⚠ Hardliner planen einen Putsch...");
            else
                Console.WriteLine("\n★ Stabile, respektierte Regierung!");
        }
        else
        {
            if (player.LoyalitätVolk < 20)
                Console.WriteLine("\n⚠ Das Volk leidet, Revolution droht...");
            else
                Console.WriteLine("\n★ Absolute Kontrolle erreicht!");
        }
        
        Thread.Sleep(2000);
        ShowStats(player);
        Console.WriteLine("\n[Drücke eine Taste...]");
        Console.ReadKey(true);
    }
    
    static void ShowStats(PlayerCharacter player)
    {
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════════╗");
        Console.WriteLine($"║ {player.Name,-30} Gen:{player.Generation} Alter:{player.Alter,-3}  ║");
        Console.WriteLine("╠═══════════════════════════════════════════════════════════╣");
        Console.WriteLine($"║ Stärke:{player.Stärke,-3} Intel:{player.Intelligenz,-3} Char:{player.Charisma,-3} Kraft:{player.Kraft,-3}              ║");
        Console.WriteLine($"║ Geld:{player.Geld,-6} Gesundheit:{player.Gesundheit,-3}%                         ║");
        Console.WriteLine($"║ Partei:{player.LoyalitätPartei,-3}% Volk:{player.LoyalitätVolk,-3}% Familie:{player.LoyalitätFamilie,-3}%         ║");
        Console.WriteLine($"║ KGB:{player.EinflussKGB,-3}% Militär:{player.EinflussMilitär,-3}% International:{player.EinflussInternational,-3}%  ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");
    }
    
    static void ShowFamilyTree()
    {
        if (currentPlayer == null)
        {
            Console.WriteLine("\n>> Kein Spielstand vorhanden!");
            Thread.Sleep(1500);
            return;
        }
        
        Console.Clear();
        Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                   RUSPUTIN STAMMBAUM                      ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════╝\n");
        
        DisplayFamily(currentPlayer, 0);
        
        Console.WriteLine($"\n\nAktueller Spieler: {currentPlayer.Name}");
        Console.WriteLine($"Generation: {currentPlayer.Generation}");
        Console.WriteLine($"Kinder: {currentPlayer.Kinder.Count}");
        
        Console.WriteLine("\n[Drücke eine Taste...]");
        Console.ReadKey(true);
    }
    
    static void DisplayFamily(PlayerCharacter member, int indent)
    {
        string space = new string(' ', indent * 3);
        Console.WriteLine($"{space}► {member.Name} (Gen {member.Generation}) - {member.Phase}");
        Console.WriteLine($"{space}  Attribute: S:{member.Stärke} I:{member.Intelligenz} C:{member.Charisma} K:{member.Kraft}");
        
        foreach (var child in member.Kinder)
        {
            DisplayFamily(child, indent + 1);
        }
    }
    
    static void SaveGame(PlayerCharacter player)
    {
        Console.Clear();
        Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                    SPIEL SPEICHERN                        ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════╝\n");
        
        for (int i = 1; i <= 5; i++)
        {
            if (saveSlots.ContainsKey(i))
            {
                var save = saveSlots[i];
                Console.WriteLine($"[{i}] {save.SaveName} | {save.Character.Name} | Gen:{save.Generation}");
                Console.WriteLine($"    {save.SaveDate:dd.MM.yyyy HH:mm:ss}");
            }
            else
            {
                Console.WriteLine($"[{i}] (Leer)");
            }
        }
        
        Console.Write("\nSlot [1-5] oder [0] Abbrechen: ");
        if (!int.TryParse(Console.ReadLine(), out int slot) || slot < 1 || slot > 5)
            return;
        
        if (saveSlots.ContainsKey(slot))
        {
            Console.Write($"Slot {slot} überschreiben? [J/N]: ");
            if (Console.ReadKey(true).Key != ConsoleKey.J)
                return;
            Console.WriteLine();
        }
        
        Console.Write("\nSpeicherstand-Name: ");
        string saveName = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(saveName))
            saveName = $"Spielstand {slot}";
        
        saveSlots[slot] = new GameSave(saveName, player);
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n✓ Gespeichert in Slot {slot}!");
        Console.ResetColor();
        Console.WriteLine($"Name: {saveName}");
        Console.WriteLine($"Datum: {DateTime.Now:dd.MM.yyyy HH:mm:ss}");
        Thread.Sleep(2000);
    }
    
    static void LoadGame()
    {
        Console.Clear();
        Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                     SPIEL LADEN                           ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════╝\n");
        
        if (saveSlots.Count == 0)
        {
            Console.WriteLine("Keine Spielstände vorhanden!");
            Thread.Sleep(1500);
            return;
        }
        
        foreach (var kvp in saveSlots.OrderBy(s => s.Key))
        {
            Console.WriteLine($"[{kvp.Key}] {kvp.Value.SaveName}");
            Console.WriteLine($"    {kvp.Value.Character.Name} | Gen:{kvp.Value.Generation} | {kvp.Value.Character.Phase}");
            Console.WriteLine($"    {kvp.Value.SaveDate:dd.MM.yyyy HH:mm:ss}\n");
        }
        
        Console.Write("Slot [1-5] oder [0] Abbrechen: ");
        if (!int.TryParse(Console.ReadLine(), out int slot) || slot < 1 || slot > 5)
            return;
        
        if (!saveSlots.ContainsKey(slot))
        {
            Console.WriteLine($"Slot {slot} ist leer!");
            Thread.Sleep(1500);
            return;
        }
        
        currentPlayer = saveSlots[slot].Character;
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n✓ Spiel geladen!");
        Console.ResetColor();
        ShowStats(currentPlayer);
        Thread.Sleep(2000);
    }
    
    static void ManageSaves()
    {
        Console.Clear();
        Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
        Console.WriteLine("║              SPIELSTÄNDE VERWALTEN                        ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════╝\n");
        
        if (saveSlots.Count == 0)
        {
            Console.WriteLine("Keine Spielstände vorhanden!");
            Thread.Sleep(1500);
            return;
        }
        
        foreach (var kvp in saveSlots.OrderBy(s => s.Key))
        {
            Console.WriteLine($"[{kvp.Key}] {kvp.Value.SaveName}");
            Console.WriteLine($"    {kvp.Value.SaveDate:dd.MM.yyyy HH:mm:ss}\n");
        }
        
        Console.Write("Slot zum Löschen [1-5] oder [0] Zurück: ");
        if (!int.TryParse(Console.ReadLine(), out int slot) || slot < 1 || slot > 5)
            return;
        
        if (saveSlots.ContainsKey(slot))
        {
            Console.Write($"Wirklich löschen? [J/N]: ");
            if (Console.ReadKey(true).Key == ConsoleKey.J)
            {
                saveSlots.Remove(slot);
                Console.WriteLine($"\n\n✓ Slot {slot} gelöscht!");
                Thread.Sleep(1500);
            }
        }
    }
    
    static void PlayMusic()
    {
        int tempo = 150;
        int[] melody = { 659, 494, 523, 587, 523, 494, 440, 440, 523, 659 };
        int[] durations = { 1, 1, 1, 1, 1, 1, 2, 1, 1, 2 };
        
        while (!stopMusic)
        {
            for (int i = 0; i < melody.Length && !stopMusic; i++)
            {
                try { Console.Beep(melody[i], tempo * durations[i]); }
                catch { }
            }
        }
    }
}

// ═══════════════════════════════════════════════════════════════════
// SCHIFFE VERSENKEN MINI-GAME
// ═══════════════════════════════════════════════════════════════════

class BattleshipGame
{
    static Random rand = new Random();
    
    public static void Play()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
        Console.WriteLine("║           ⚓ SCHIFFE VERSENKEN ⚓                          ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");
        Console.ResetColor();
        
        Console.WriteLine("\n[1] Spieler vs Computer");
        Console.WriteLine("[2] Spieler vs Spieler");
        Console.WriteLine("[3] Zurück zum Hauptmenü");
        Console.Write("\nWähle [1-3]: ");
        
        string choice = Console.ReadLine();
        
        if (choice == "1")
            PlayGame(false);
        else if (choice == "2")
            PlayGame(true);
    }
    
    static void PlayGame(bool pvp)
    {
        Console.Clear();
        Console.Write("Name Spieler 1: ");
        string player1 = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(player1)) player1 = "Spieler 1";
        
        string player2 = pvp ? "" : "Computer";
        if (pvp)
        {
            Console.Write("Name Spieler 2: ");
            player2 = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(player2)) player2 = "Spieler 2";
        }
        
        // Feldgröße
        Console.WriteLine("\nFeldgröße:");
        Console.WriteLine("[1] Klein (6x6)");
        Console.WriteLine("[2] Groß (8x8)");
        Console.Write("Wähle [1-2]: ");
        int size = Console.ReadLine() == "2" ? 8 : 6;
        
        Board board1 = new Board(size, player1);
        Board board2 = new Board(size, player2);
        
        // Platzierung
        Console.Clear();
        Console.WriteLine($"═══ {player1}, platziere deine Schiffe! ═══\n");
        PlaceShipsManual(board1);
        
        if (pvp)
        {
            Console.Clear();
            Console.WriteLine("═══════════════════════════════════════════════");
            Console.WriteLine($"Spieler 2 ist an der Reihe!");
            Console.WriteLine("═══════════════════════════════════════════════");
            Console.WriteLine("\n[Drücke eine Taste...]");
            Console.ReadKey(true);
            Console.Clear();
            Console.WriteLine($"═══ {player2}, platziere deine Schiffe! ═══\n");
            PlaceShipsManual(board2);
        }
        else
        {
            PlaceShipsAuto(board2);
        }
        
        // Spielschleife
        bool player1Turn = true;
        while (!board1.AllShipsSunk() && !board2.AllShipsSunk())
        {
            Console.Clear();
            
            if (pvp && !player1Turn)
            {
                Console.WriteLine($"\n{player2} ist dran! [Taste drücken...]");
                Console.ReadKey(true);
                Console.Clear();
            }
            
            Board attacker = player1Turn ? board1 : board2;
            Board defender = player1Turn ? board2 : board1;
            
            Console.WriteLine($"═══ {attacker.PlayerName} ist am Zug ═══\n");
            Console.WriteLine("Dein Feld:");
            attacker.Display(true);
            Console.WriteLine($"\nGegnerisches Feld ({defender.PlayerName}):");
            defender.Display(false);
            
            bool hit = false;
            if (!pvp && !player1Turn)
            {
                hit = ComputerAttack(defender);
                Thread.Sleep(1500);
            }
            else
            {
                hit = PlayerAttack(defender);
            }
            
            if (!hit)
                player1Turn = !player1Turn;
        }
        
        // Gewinner
        string winner = board2.AllShipsSunk() ? player1 : player2;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
        Console.WriteLine($"║  🎉 {winner} HAT GEWONNEN! 🎉");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");
        Console.ResetColor();
        Console.WriteLine("\n[Drücke eine Taste...]");
        Console.ReadKey(true);
    }
    
    static void PlaceShipsManual(Board board)
    {
        int[] shipSizes = board.Size == 6 ? new[] { 4, 3, 2 } : new[] { 5, 4, 3, 2 };
        
        foreach (int size in shipSizes)
        {
            bool placed = false;
            while (!placed)
            {
                Console.Clear();
                Console.WriteLine($"Platziere Schiff (Größe {size})\n");
                board.Display(true);
                
                Console.Write("\nPosition (z.B. A1): ");
                string pos = Console.ReadLine()?.ToUpper();
                if (string.IsNullOrEmpty(pos) || pos.Length < 2) continue;
                
                int row = pos[0] - 'A';
                if (!int.TryParse(pos.Substring(1), out int col)) continue;
                col--;
                
                Console.Write("Richtung ([H]orizontal / [V]ertikal): ");
                bool horizontal = Console.ReadLine()?.ToUpper() == "H";
                
                if (board.PlaceShip(row, col, size, horizontal))
                {
                    placed = true;
                    Console.WriteLine("✓ Schiff platziert!");
                    Thread.Sleep(500);
                }
                else
                {
                    Console.WriteLine("✗ Ungültig!");
                    Thread.Sleep(1000);
                }
            }
        }
        
        Console.Clear();
        Console.WriteLine("Alle Schiffe platziert!\n");
        board.Display(true);
        Console.WriteLine("\n[Drücke eine Taste...]");
        Console.ReadKey(true);
    }
    
    static void PlaceShipsAuto(Board board)
    {
        int[] shipSizes = board.Size == 6 ? new[] { 4, 3, 2 } : new[] { 5, 4, 3, 2 };
        
        foreach (int size in shipSizes)
        {
            bool placed = false;
            int attempts = 0;
            while (!placed && attempts < 100)
            {
                int row = rand.Next(board.Size);
                int col = rand.Next(board.Size);
                bool horizontal = rand.Next(2) == 0;
                placed = board.PlaceShip(row, col, size, horizontal);
                attempts++;
            }
        }
    }
    
    static bool PlayerAttack(Board board)
    {
        while (true)
        {
            Console.Write("\nZiel (z.B. B3): ");
            string input = Console.ReadLine()?.ToUpper();
            if (string.IsNullOrEmpty(input) || input.Length < 2) continue;
            
            int row = input[0] - 'A';
            if (!int.TryParse(input.Substring(1), out int col)) continue;
            col--;
            
            if (row < 0 || row >= board.Size || col < 0 || col >= board.Size)
            {
                Console.WriteLine("Ungültig!");
                continue;
            }
            
            char result = board.Attack(row, col);
            
            if (result == '?')
            {
                Console.WriteLine("⚠ Schon beschossen!");
                continue;
            }
            
            if (result == 'X')
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("💥 TREFFER!");
                Console.ResetColor();
                try { Console.Beep(800, 200); } catch { }
                Thread.Sleep(1000);
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("💧 Wasser!");
                Console.ResetColor();
                try { Console.Beep(300, 200); } catch { }
                Thread.Sleep(1000);
                return false;
            }
        }
    }
    
    static bool ComputerAttack(Board board)
    {
        int row, col;
        int attempts = 0;
        do
        {
            row = rand.Next(board.Size);
            col = rand.Next(board.Size);
            attempts++;
        } while (board.Grid[row, col] == 'X' || board.Grid[row, col] == 'O' && attempts < 100);
        
        Console.WriteLine($"\nComputer greift an: {(char)('A' + row)}{col + 1}");
        
        char result = board.Attack(row, col);
        
        if (result == 'X')
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("💥 Computer trifft!");
            Console.ResetColor();
            try { Console.Beep(800, 200); } catch { }
            return true;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("💧 Computer verfehlt!");
            Console.ResetColor();
            try { Console.Beep(300, 200); } catch { }
            return false;
        }
    }
}

class Board
{
    public int Size;
    public char[,] Grid;
    public string PlayerName;
    List<Ship> ships = new List<Ship>();
    
    public Board(int size, string name)
    {
        Size = size;
        PlayerName = name;
        Grid = new char[size, size];
        
        for (int i = 0; i < size; i++)
            for (int j = 0; j < size; j++)
                Grid[i, j] = '~';
    }
    
    public bool PlaceShip(int row, int col, int size, bool horizontal)
    {
        if (horizontal)
        {
            if (col + size > Size) return false;
            for (int c = col; c < col + size; c++)
                if (Grid[row, c] != '~') return false;
        }
        else
        {
            if (row + size > Size) return false;
            for (int r = row; r < row + size; r++)
                if (Grid[r, col] != '~') return false;
        }
        
        Ship ship = new Ship(row, col, size, horizontal);
        ships.Add(ship);
        
        if (horizontal)
            for (int c = col; c < col + size; c++)
                Grid[row, c] = 'S';
        else
            for (int r = row; r < row + size; r++)
                Grid[r, col] = 'S';
        
        return true;
    }
    
    public char Attack(int row, int col)
    {
        if (Grid[row, col] == 'X' || Grid[row, col] == 'O')
            return '?';
        
        if (Grid[row, col] == 'S')
        {
            Grid[row, col] = 'X';
            
            foreach (var ship in ships)
            {
                if (ship.IsAt(row, col))
                {
                    ship.Hit(row, col);
                    break;
                }
            }
            return 'X';
        }
        else
        {
            Grid[row, col] = 'O';
            return 'O';
        }
    }
    
    public bool AllShipsSunk()
    {
        return ships.All(s => s.IsSunk());
    }
    
    public void Display(bool showShips)
    {
        Console.Write("   ");
        for (int c = 0; c < Size; c++)
            Console.Write($" {c + 1} ");
        Console.WriteLine();
        
        for (int r = 0; r < Size; r++)
        {
            Console.Write($" {(char)('A' + r)} │");
            
            for (int c = 0; c < Size; c++)
            {
                char cell = Grid[r, c];
                if (cell == 'S' && !showShips) cell = '~';
                
                switch (cell)
                {
                    case '~':
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(" ~ ");
                        break;
                    case 'S':
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(" ■ ");
                        break;
                    case 'X':
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" X ");
                        break;
                    case 'O':
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write(" ○ ");
                        break;
                }
                Console.ResetColor();
            }
            Console.WriteLine("│");
        }
        
        Console.WriteLine("\n~ Wasser | ■ Schiff | X Treffer | ○ Fehlschuss");
    }
}

class Ship
{
    int row, col, size;
    bool horizontal;
    bool[] hits;
    
    public Ship(int r, int c, int s, bool h)
    {
        row = r;
        col = c;
        size = s;
        horizontal = h;
        hits = new bool[s];
    }
    
    public bool IsAt(int r, int c)
    {
        if (horizontal)
            return r == row && c >= col && c < col + size;
        else
            return c == col && r >= row && r < row + size;
    }
    
    public void Hit(int r, int c)
    {
        if (horizontal)
            hits[c - col] = true;
        else
            hits[r - row] = true;
    }
    
    public bool IsSunk()
    {
        return hits.All(h => h);
    }
}
