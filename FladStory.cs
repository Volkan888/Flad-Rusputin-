// Flad Story Module - Lebensphasen-System
// Teil von Rise of the Northborn - Flad Rusputin Saga
using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

// ═══════════════════════════════════════════════════════════════════
// SPIELER-CHARAKTER KLASSE
// ═══════════════════════════════════════════════════════════════════

public class PlayerCharacter
{
    // Basis-Attribute
    public string Name { get; set; }
    public int Stärke { get; set; }
    public int Intelligenz { get; set; }
    public int Charisma { get; set; }
    public int Kraft { get; set; }
    
    // Ressourcen
    public int Geld { get; set; }
    public int Gesundheit { get; set; }
    
    // Loyalität (0-100)
    public int LoyalitätPartei { get; set; }
    public int LoyalitätVolk { get; set; }
    public int LoyalitätFamilie { get; set; }
    
    // Einfluss (0-100)
    public int EinflussKGB { get; set; }
    public int EinflussMilitär { get; set; }
    public int EinflussInternational { get; set; }
    
    // Spielfortschritt
    public int Alter { get; set; }
    public GamePhase Phase { get; set; }
    public Difficulty Schwierigkeit { get; set; }
    
    // Besondere Flags
    public bool KGBEasterEgg { get; set; }
    public bool GeheimeAusbildung { get; set; }
    
    public PlayerCharacter(string name, Difficulty diff)
    {
        Name = name;
        Schwierigkeit = diff;
        Alter = 0;
        Phase = GamePhase.Geburt;
        Gesundheit = 100;
        Geld = 0;
        
        // Standard-Loyalitäten
        LoyalitätPartei = 50;
        LoyalitätVolk = 50;
        LoyalitätFamilie = 80;
        
        // Standard-Einfluss
        EinflussKGB = 0;
        EinflussMilitär = 0;
        EinflussInternational = 0;
        
        KGBEasterEgg = false;
        GeheimeAusbildung = false;
    }
    
    public void ShowStats()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
        Console.WriteLine($"║  {Name,-30} Alter: {Alter,-3} ║");
        Console.WriteLine("╠═══════════════════════════════════════════════════════════╣");
        Console.ResetColor();
        
        Console.WriteLine($"║  ATTRIBUTE:                                           ║");
        Console.WriteLine($"║  Stärke: {Stärke,-3}  Intelligenz: {Intelligenz,-3}  Charisma: {Charisma,-3}  Kraft: {Kraft,-3} ║");
        Console.WriteLine($"║                                                           ║");
        Console.WriteLine($"║  RESSOURCEN:                                              ║");
        Console.WriteLine($"║  Geld: {Geld,-6}  Gesundheit: {Gesundheit,-3}%                         ║");
        Console.WriteLine($"║                                                           ║");
        Console.WriteLine($"║  LOYALITÄT:                                               ║");
        Console.WriteLine($"║  Partei: {LoyalitätPartei,-3}%  Volk: {LoyalitätVolk,-3}%  Familie: {LoyalitätFamilie,-3}%          ║");
        Console.WriteLine($"║                                                           ║");
        Console.WriteLine($"║  EINFLUSS:                                                ║");
        Console.WriteLine($"║  KGB: {EinflussKGB,-3}%  Militär: {EinflussMilitär,-3}%  International: {EinflussInternational,-3}%     ║");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");
        Console.ResetColor();
    }
}

public enum GamePhase
{
    Geburt,
    Kindheit,
    KGBAmbitionen,
    Jurastudium,
    DDREinsatz,
    Präsident
}

public enum Difficulty
{
    Leicht,
    Mittel,
    Hart,
    KalterKrieg
}

// ═══════════════════════════════════════════════════════════════════
// STORY MODULE
// ═══════════════════════════════════════════════════════════════════

public static class FladStoryModule
{
    private static Random rand = new Random();
    
    public static (PlayerCharacter, FamilyTree) StartNewGame()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                                                           ║");
        Console.WriteLine("║      FLAD: AUFSTIEG IN EINER SOWJETISCHEN DYSTOPIE        ║");
        Console.WriteLine("║                                                           ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");
        Console.ResetColor();
        
        Console.WriteLine("\n1952, Leningrad – In einer verfallenen sowjetischen Scheune");
        Console.WriteLine("erblickt Flad das Licht der Welt...\n");
        Thread.Sleep(2000);
        
        // Schwierigkeitsgrad wählen
        Difficulty diff = ChooseDifficulty();
        
        // Charakter erstellen
        PlayerCharacter flad = new PlayerCharacter("Flad Rusputin", diff);
        
        // Attribute verteilen basierend auf Schwierigkeit
        DistributeAttributes(flad);
        
        // Geburtszene
        BirthScene(flad);
        
        // Stammbaum erstellen
        FamilyTree family = new FamilyTree(flad);
        
        return (flad, family);
    }
    
    private static Difficulty ChooseDifficulty()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
            Console.WriteLine("║            SCHWIERIGKEITSGRAD WÄHLEN                      ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════╝\n");
            
            Console.WriteLine("[1] Leicht - Kleiner Startvorteil");
            Console.WriteLine("    • Alle Attribute beginnen bei 1");
            Console.WriteLine("    • Bonusgeld: 500 Rubel\n");
            
            Console.WriteLine("[2] Mittel - Ausgewogen");
            Console.WriteLine("    • 3 Attributpunkte frei verteilen");
            Console.WriteLine("    • Standard-Ressourcen\n");
            
            Console.WriteLine("[3] Hart - Erschwerter Start");
            Console.WriteLine("    • 2 Attributpunkte verteilen");
            Console.WriteLine("    • Gesundheit: 70%\n");
            
            Console.WriteLine("[4] Kalter Krieg - Hardcore");
            Console.WriteLine("    • 1 Attributpunkt verteilen");
            Console.WriteLine("    • Schulden: -200 Rubel");
            Console.WriteLine("    • Erhöhter KGB-Einfluss: +20%\n");
            
            Console.Write("Wähle [1-4]: ");
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1": return Difficulty.Leicht;
                case "2": return Difficulty.Mittel;
                case "3": return Difficulty.Hart;
                case "4": return Difficulty.KalterKrieg;
            }
        }
    }
    
    private static void DistributeAttributes(PlayerCharacter flad)
    {
        Console.Clear();
        Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
        Console.WriteLine("║           ATTRIBUT-VERTEILUNG BEI GEBURT                  ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════╝\n");
        
        int points = 0;
        
        switch (flad.Schwierigkeit)
        {
            case Difficulty.Leicht:
                flad.Stärke = flad.Intelligenz = flad.Charisma = flad.Kraft = 1;
                flad.Geld = 500;
                Console.WriteLine("LEICHT: Alle Attribute starten bei 1, +500 Rubel Bonusgeld");
                Thread.Sleep(2000);
                return;
                
            case Difficulty.Mittel:
                points = 3;
                break;
                
            case Difficulty.Hart:
                points = 2;
                flad.Gesundheit = 70;
                break;
                
            case Difficulty.KalterKrieg:
                points = 1;
                flad.Geld = -200;
                flad.EinflussKGB = 20;
                break;
        }
        
        Console.WriteLine($"Du hast {points} Punkte zu verteilen auf:");
        Console.WriteLine("1 = Stärke (Kampfkraft, körperliche Dominanz)");
        Console.WriteLine("2 = Intelligenz (Strategie, Politik, Bildung)");
        Console.WriteLine("3 = Charisma (Überzeugungskraft, Beliebtheit)");
        Console.WriteLine("4 = Kraft (Ausdauer, Widerstandsfähigkeit)\n");
        
        while (points > 0)
        {
            Console.WriteLine($"Verbleibende Punkte: {points}");
            Console.WriteLine($"Aktuell - Stärke:{flad.Stärke} Intelligenz:{flad.Intelligenz} Charisma:{flad.Charisma} Kraft:{flad.Kraft}");
            Console.Write("\nWelches Attribut erhöhen? [1-4]: ");
            
            string input = Console.ReadLine();
            switch (input)
            {
                case "1": flad.Stärke++; points--; break;
                case "2": flad.Intelligenz++; points--; break;
                case "3": flad.Charisma++; points--; break;
                case "4": flad.Kraft++; points--; break;
                default: Console.WriteLine("Ungültige Eingabe!"); continue;
            }
        }
        
        Console.WriteLine("\n✓ Attribute verteilt!");
        Thread.Sleep(2000);
    }
    
    private static void BirthScene(PlayerCharacter flad)
    {
        Console.Clear();
        Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                    1952 - GEBURT                          ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════╝\n");
        
        Console.WriteLine("In einer baufälligen Scheune in Leningrad wird Flad geboren.");
        Console.WriteLine("Der harte Winter und die Armut der Nachkriegszeit prägen");
        Console.WriteLine("seine ersten Momente auf dieser Welt.\n");
        Thread.Sleep(2000);
        
        Console.WriteLine("Sein Vater, vom Krieg gezeichnet, blickt auf das Neugeborene");
        Console.WriteLine("und spürt das besondere Potenzial seines Sohnes...\n");
        Thread.Sleep(2000);
        
        flad.ShowStats();
        Console.WriteLine("\n[Drücke eine Taste um fortzufahren...]");
        Console.ReadKey(true);
        
        // Übergang zur Kindheit
        flad.Phase = GamePhase.Kindheit;
        flad.Alter = 10;
    }
    
    public static void PlayChildhood(PlayerCharacter flad)
    {
        Console.Clear();
        Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
        Console.WriteLine("║              KINDHEIT IN LENINGRAD (1950er)               ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════╝\n");
        
        Console.WriteLine("Flad wächst in den Ruinen des Nachkriegs-Leningrad auf.");
        Console.WriteLine("Armut, Gewalt und Hunger prägen seinen Alltag.");
        Console.WriteLine("Doch sein Vater verschafft ihm Zugang zu Judo-Training.\n");
        Thread.Sleep(2000);
        
        Console.WriteLine("Zu seinem 10. Geburtstag schenkt der Vater ihm eine seltene");
        Console.WriteLine("Armbanduhr - ein kostbares Erinnerungsstück...\n");
        Thread.Sleep(2000);
        
        // Entscheidung
        Console.WriteLine("Wie verhält sich Flad in seiner Kindheit?\n");
        Console.WriteLine("[1] Kämpferische Kindheit");
        Console.WriteLine("    Straßenkämpfe und Raufereien");
        Console.WriteLine("    +2 Stärke, -15 Gesundheit, -10 Loyalität Partei\n");
        
        Console.WriteLine("[2] Disziplin durch Sport");
        Console.WriteLine("    Konzentration auf Judo-Training");
        Console.WriteLine("    +2 Kraft, +1 Charisma, +10 Gesundheit\n");
        
        Console.WriteLine("[3] Zurückgezogen und wissbegierig");
        Console.WriteLine("    Bücher und Bildung");
        Console.WriteLine("    +3 Intelligenz, +1 Charisma\n");
        
        Console.Write("Wähle [1-3]: ");
        string choice = Console.ReadLine();
        
        switch (choice)
        {
            case "1":
                flad.Stärke += 2;
                flad.Gesundheit -= 15;
                flad.LoyalitätPartei -= 10;
                Console.WriteLine("\n>> Flad wird zum Straßenkämpfer!");
                break;
                
            case "2":
                flad.Kraft += 2;
                flad.Charisma += 1;
                if (flad.Gesundheit < 100) flad.Gesundheit = Math.Min(100, flad.Gesundheit + 10);
                Console.WriteLine("\n>> Flad meistert Judo und gewinnt Respekt!");
                break;
                
            case "3":
                flad.Intelligenz += 3;
                flad.Charisma += 1;
                Console.WriteLine("\n>> Flad wird zum klugen Strategen!");
                break;
        }
        
        Thread.Sleep(2000);
        
        // Easter Egg Check
        if (flad.Intelligenz >= 2 || flad.Charisma >= 2)
        {
            flad.KGBEasterEgg = true;
            Console.WriteLine("\n💀 Ein mysteriöser Schatten beobachtet Flad aus der Ferne...");
            Thread.Sleep(2000);
        }
        
        flad.ShowStats();
        Console.WriteLine("\n[Drücke eine Taste um fortzufahren...]");
        Console.ReadKey(true);
        
        flad.Phase = GamePhase.KGBAmbitionen;
        flad.Alter = 16;
    }
    
    public static void PlayKGBPhase(PlayerCharacter flad)
    {
        Console.Clear();
        Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
        Console.WriteLine("║              KGB-AMBITIONEN (1968)                        ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════╝\n");
        
        Console.WriteLine("Mit 16 Jahren fasst Flad einen kühnen Entschluss:");
        Console.WriteLine("Er marschiert zur KGB-Zentrale in Leningrad und bietet");
        Console.WriteLine("selbstbewusst seine Dienste an!\n");
        Thread.Sleep(2000);
        
        if (flad.KGBEasterEgg)
        {
            // Easter Egg aktiviert!
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("═══ EASTER EGG AKTIVIERT ═══\n");
            Console.ResetColor();
            
            Console.WriteLine("Bevor der Offizier ihn fortschicken kann, tritt ein");
            Console.WriteLine("hochrangiger KGB-Agent aus den Schatten:");
            Console.WriteLine("\n'Wir haben von dir gehört, Flad.'\n");
            Thread.Sleep(2000);
            
            Console.WriteLine("Der Agent lädt ihn ein, an einem geheimen");
            Console.WriteLine("Ausbildungsprogramm teilzunehmen!\n");
            
            Console.WriteLine("[1] Annehmen - Geheime KGB-Ausbildung");
            Console.WriteLine("    +30 KGB-Einfluss, Bonusmissionen freigeschaltet");
            Console.WriteLine("    -20 Familie-Loyalität (Geheimhaltung)\n");
            
            Console.WriteLine("[2] Ablehnen - Den sicheren Weg gehen");
            Console.WriteLine("    Keine Boni, aber auch keine Verpflichtungen\n");
            
            Console.Write("Wähle [1-2]: ");
            string choice = Console.ReadLine();
            
            if (choice == "1")
            {
                flad.GeheimeAusbildung = true;
                flad.EinflussKGB += 30;
                flad.LoyalitätFamilie -= 20;
                flad.Intelligenz += 1;
                Console.WriteLine("\n>> Flad absolviert die geheime Ausbildung!");
                Console.WriteLine(">> Er lernt Spionage, Geheimschrift und psychologische Kriegsführung");
            }
            else
            {
                Console.WriteLine("\n>> Flad lehnt höflich ab und geht den offiziellen Weg.");
            }
        }
        else
        {
            Console.WriteLine("Der diensthabende Offizier mustert den Jungen streng:");
            Console.WriteLine("\n'Komm wieder, wenn du etwas vorzuweisen hast!");
            Console.WriteLine(" Mach deinen Abschluss, diene der Armee oder studiere Jura.'\n");
            Thread.Sleep(2000);
            
            Console.WriteLine("Flad wird abgewiesen. Gedemütigt verlässt er die Zentrale,");
            Console.WriteLine("schwört aber, eines Tages zurückzukehren - stärker und klüger!");
        }
        
        Thread.Sleep(2000);
        Console.WriteLine("\n>> Flad entscheidet sich, Jura zu studieren...");
        Thread.Sleep(2000);
        
        flad.ShowStats();
        Console.WriteLine("\n[Drücke eine Taste um fortzufahren...]");
        Console.ReadKey(true);
        
        flad.Phase = GamePhase.Jurastudium;
        flad.Alter = 20;
    }
    
    public static void PlayUniversityPhase(PlayerCharacter flad)
    {
        Console.Clear();
        Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
        Console.WriteLine("║         JURASTUDIUM UND KARRIEREBEGINN (1970er)          ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════╝\n");
        
        Console.WriteLine("1970 schreibt sich Flad an der Staatsuniversität Leningrad ein.");
        Console.WriteLine("Er studiert Jura und wird Mitglied der Kommunistischen Partei.\n");
        Thread.Sleep(2000);
        
        Console.WriteLine("Nach einer hitzigen Debatte erhält Flad drei Angebote:");
        Console.WriteLine("Ein Parteifunktionär, ein KGB-Kontakt und seine Familie");
        Console.WriteLine("bitten um seine Loyalität...\n");
        Thread.Sleep(2000);
        
        Console.WriteLine("Wo liegt Flads primäre Loyalität?\n");
        Console.WriteLine("[1] Parteilinie verfolgen");
        Console.WriteLine("    +30 Partei-Loyalität, +20 Geld");
        Console.WriteLine("    +15 Militär-Einfluss");
        Console.WriteLine("    -15 Volk-Loyalität\n");
        
        Console.WriteLine("[2] Karriere im KGB priorisieren");
        Console.WriteLine("    +40 KGB-Einfluss");
        Console.WriteLine("    -20 Familie-Loyalität");
        Console.WriteLine("    -10 Gesundheit (psychisch)\n");
        
        Console.WriteLine("[3] Familie und eigene Moral schützen");
        Console.WriteLine("    +30 Familie-Loyalität");
        Console.WriteLine("    +20 Volk-Loyalität");
        Console.WriteLine("    Langsamerer Karrierestart\n");
        
        Console.Write("Wähle [1-3]: ");
        string choice = Console.ReadLine();
        
        switch (choice)
        {
            case "1":
                flad.LoyalitätPartei = Math.Min(100, flad.LoyalitätPartei + 30);
                flad.Geld += 20;
                flad.EinflussMilitär += 15;
                flad.LoyalitätVolk -= 15;
                Console.WriteLine("\n>> Flad wird ein loyaler Parteikader!");
                break;
                
            case "2":
                flad.EinflussKGB = Math.Min(100, flad.EinflussKGB + 40);
                flad.LoyalitätFamilie -= 20;
                flad.Gesundheit -= 10;
                Console.WriteLine("\n>> Flad widmet sich dem KGB!");
                break;
                
            case "3":
                flad.LoyalitätFamilie = Math.Min(100, flad.LoyalitätFamilie + 30);
                flad.LoyalitätVolk = Math.Min(100, flad.LoyalitätVolk + 20);
                Console.WriteLine("\n>> Flad bleibt seinen Prinzipien treu!");
                break;
        }
        
        Thread.Sleep(2000);
        Console.WriteLine("\n>> 1975: Flad schließt sein Studium erfolgreich ab!");
        Console.WriteLine(">> Er erhält einen Posten in der DDR...");
        Thread.Sleep(2000);
        
        flad.ShowStats();
        Console.WriteLine("\n[Drücke eine Taste um fortzufahren...]");
        Console.ReadKey(true);
        
        flad.Phase = GamePhase.DDREinsatz;
        flad.Alter = 35;
    }
    
    public static void PlayDDRPhase(PlayerCharacter flad)
    {
        Console.Clear();
        Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
        Console.WriteLine("║              EINSATZ IN DER DDR (1980er)                  ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════╝\n");
        
        Console.WriteLine("Mitte der 1980er: Flad wird nach Dresden entsandt.");
        Console.WriteLine("Er dient als Verbindungsoffizier zur Stasi.\n");
        Thread.Sleep(2000);
        
        Console.WriteLine("Herbst 1989: Wütende Ostdeutsche demonstrieren vor dem");
        Console.WriteLine("Stasi-/KGB-Hauptquartier. Die Menge ruft nach Freiheit!");
        Console.WriteLine("Die Atmosphäre ist explosiv...\n");
        Thread.Sleep(2000);
        
        Console.WriteLine("Flad steht vor seiner schwersten Entscheidung:\n");
        
        Console.WriteLine("[1] Aufstand niederschlagen");
        Console.WriteLine("    +30 KGB-Einfluss, +25 Partei-Loyalität");
        Console.WriteLine("    +100 Geld (Belohnung)");
        Console.WriteLine("    -25 Gesundheit (Trauma)");
        Console.WriteLine("    -30 International-Einfluss (Hardliner-Ruf)\n");
        
        Console.WriteLine("[2] Mit den Rebellen sympathisieren (Flucht)");
        Console.WriteLine("    -40 KGB-Einfluss, -30 Partei-Loyalität");
        Console.WriteLine("    -50 Geld (Unsicherheit)");
        Console.WriteLine("    +40 Volk-Loyalität");
        Console.WriteLine("    Moral intakt, zukünftige Chancen bei Reformen\n");
        
        Console.Write("Wähle [1-2]: ");
        string choice = Console.ReadLine();
        
        switch (choice)
        {
            case "1":
                flad.EinflussKGB = Math.Min(100, flad.EinflussKGB + 30);
                flad.LoyalitätPartei = Math.Min(100, flad.LoyalitätPartei + 25);
                flad.Geld += 100;
                flad.Gesundheit -= 25;
                flad.EinflussInternational = Math.Max(0, flad.EinflussInternational - 30);
                Console.WriteLine("\n>> Flad greift hart durch!");
                Console.WriteLine(">> Die Proteste werden niedergeschlagen.");
                Console.WriteLine(">> Moskau ist zufrieden, aber der Preis ist hoch...");
                break;
                
            case "2":
                flad.EinflussKGB = Math.Max(0, flad.EinflussKGB - 40);
                flad.LoyalitätPartei = Math.Max(0, flad.LoyalitätPartei - 30);
                flad.Geld -= 50;
                flad.LoyalitätVolk = Math.Min(100, flad.LoyalitätVolk + 40);
                Console.WriteLine("\n>> Flad verweigert den Schießbefehl!");
                Console.WriteLine(">> Er flieht aus der DDR.");
                Console.WriteLine(">> Sein Gewissen ist rein, aber die Konsequenzen folgen...");
                break;
        }
        
        Thread.Sleep(3000);
        Console.WriteLine("\n>> 1991: Die Sowjetunion zerfällt...");
        Console.WriteLine(">> Flad kehrt in ein Land im Chaos zurück.");
        Thread.Sleep(2000);
        
        flad.ShowStats();
        Console.WriteLine("\n[Drücke eine Taste um fortzufahren...]");
        Console.ReadKey(true);
        
        flad.Phase = GamePhase.Präsident;
        flad.Alter = 48;
    }
    
    public static void PlayPresidentPhase(PlayerCharacter flad, FamilyTree family)
    {
        Console.Clear();
        Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
        Console.WriteLine("║       AUFSTIEG ZUM PRÄSIDENTEN (1990er-2000er)           ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════╝\n");
        
        Console.WriteLine("Die 1990er Jahre: Russland taumelt.");
        Console.WriteLine("Wirtschaftskrisen, Machtkämpfe, ein orientierungsloses Volk.\n");
        Thread.Sleep(2000);
        
        Console.WriteLine("Flad navigiert geschickt durch die Wirren der Zeit.");
        Console.WriteLine("Seine Erfahrungen - vom Straßenkind zum KGB-Mann -");
        Console.WriteLine("machen ihn zum perfekten Kandidaten...\n");
        Thread.Sleep(2000);
        
        Console.WriteLine("Um die Jahrtausendwende bietet sich DIE Gelegenheit:");
        Console.WriteLine("Die Präsidialverwaltung sucht einen Nachfolger!\n");
        Thread.Sleep(2000);
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(">> Flad wird Präsident von Russland!");
        Console.ResetColor();
        Thread.Sleep(2000);
        
        // Kinder generieren
        Console.WriteLine("\n>> Während seiner politischen Karriere gründet Flad eine Familie...");
        Thread.Sleep(1500);
        Random rand = new Random();
        int childCount = rand.Next(2, 5); // 2-4 Kinder
        family.CurrentPlayer.GenerateChildren(childCount);
        Console.WriteLine($">> Flad hat {childCount} Kinder!");
        Thread.Sleep(1500);
        
        Console.WriteLine("\nNun muss Flad seinen Regierungsstil festlegen:\n");
        
        Console.WriteLine("[1] Expansion und imperialer Ehrgeiz");
        Console.WriteLine("    Militärische Interventionen, Größe wiederherstellen");
        Console.WriteLine("    +50 Militär-Einfluss, -200 Geld (Kriege)");
        Console.WriteLine("    Ruhm oder Kollaps?\n");
        
        Console.WriteLine("[2] Diplomatie und Öffnung");
        Console.WriteLine("    Handel, Verträge, internationale Zusammenarbeit");
        Console.WriteLine("    +300 Geld (Handel), +40 International-Einfluss");
        Console.WriteLine("    -20 KGB-Einfluss (Hardliner unzufrieden)\n");
        
        Console.WriteLine("[3] Eiserne Hand im Inneren");
        Console.WriteLine("    Totale Kontrolle, Opposition unterdrücken");
        Console.WriteLine("    +40 Partei-Loyalität, +30 KGB-Einfluss");
        Console.WriteLine("    -50 Volk-Loyalität, -60 International-Einfluss\n");
        
        Console.Write("Wähle [1-3]: ");
        string choice = Console.ReadLine();
        
        string ending = "";
        
        switch (choice)
        {
            case "1":
                flad.EinflussMilitär = Math.Min(100, flad.EinflussMilitär + 50);
                flad.Geld -= 200;
                ending = "IMPERIALES ENDE";
                ShowImperialEnding(flad);
                break;
                
            case "2":
                flad.Geld += 300;
                flad.EinflussInternational = Math.Min(100, flad.EinflussInternational + 40);
                flad.EinflussKGB = Math.Max(0, flad.EinflussKGB - 20);
                ending = "DIPLOMATISCHES ENDE";
                ShowDiplomaticEnding(flad);
                break;
                
            case "3":
                flad.LoyalitätPartei = Math.Min(100, flad.LoyalitätPartei + 40);
                flad.EinflussKGB = Math.Min(100, flad.EinflussKGB + 30);
                flad.LoyalitätVolk = Math.Max(0, flad.LoyalitätVolk - 50);
                flad.EinflussInternational = Math.Max(0, flad.EinflussInternational - 60);
                ending = "DIKTATOR-ENDE";
                ShowDictatorEnding(flad);
                break;
        }
        
        Console.WriteLine("\n[Drücke eine Taste um zum Hauptmenü zurückzukehren...]");
        Console.ReadKey(true);
    }
    
    private static void ShowImperialEnding(PlayerCharacter flad)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                  IMPERIALES ENDE                          ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");
        Console.ResetColor();
        
        Console.WriteLine("\nFlad greift zu einer aggressiv expansionistischen Politik.");
        Console.WriteLine("Militärische Interventionen in Nachbarländern beginnen.");
        Console.WriteLine("Die Welt fürchtet und respektiert den neuen Zaren...\n");
        Thread.Sleep(2000);
        
        if (flad.Geld < -100)
        {
            Console.WriteLine("Doch die Kriege verschlingen die Staatskasse.");
            Console.WriteLine("Internationale Sanktionen schwächen die Wirtschaft.");
            Console.WriteLine("Das überdehnte Reich kollabiert unter seinem eigenen Gewicht...");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n⚠ WARNUNG: Instabiles Regime");
        }
        else
        {
            Console.WriteLine("Mit eisernem Willen hält Flad sein neues Imperium zusammen.");
            Console.WriteLine("Russland erstrahlt in alter Größe - ein Riese ist erwacht!");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n★ ERFOLG: Neues Russisches Imperium etabliert");
        }
        
        Console.ResetColor();
        flad.ShowStats();
    }
    
    private static void ShowDiplomaticEnding(PlayerCharacter flad)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                DIPLOMATISCHES ENDE                        ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");
        Console.ResetColor();
        
        Console.WriteLine("\nFlad schlägt einen moderaten Kurs ein.");
        Console.WriteLine("Handel und internationale Zusammenarbeit florieren.");
        Console.WriteLine("Die Wirtschaft stabilisiert sich...\n");
        Thread.Sleep(2000);
        
        if (flad.EinflussKGB < 20 && flad.EinflussMilitär < 30)
        {
            Console.WriteLine("Doch Hardliner wittern Verrat!");
            Console.WriteLine("Ein Putschversuch erschüttert das Land.");
            Console.WriteLine("Flad muss mit allen Mitteln seine Position verteidigen...");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n⚠ WARNUNG: Innenpolitische Instabilität");
        }
        else
        {
            Console.WriteLine("Mit geschickter Balancepolitik sichert Flad seine Herrschaft.");
            Console.WriteLine("Russland wird zu einem stabilen, respektierten Akteur.");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n★ ERFOLG: Stabile Regierung etabliert");
        }
        
        Console.ResetColor();
        flad.ShowStats();
    }
    
    private static void ShowDictatorEnding(PlayerCharacter flad)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                   DIKTATOR-ENDE                           ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");
        Console.ResetColor();
        
        Console.WriteLine("\nFlad zieht die Schrauben an.");
        Console.WriteLine("Opposition wird kompromisslos unterdrückt.");
        Console.WriteLine("Ein Personenkult etabliert sich...\n");
        Thread.Sleep(2000);
        
        if (flad.LoyalitätVolk < 20)
        {
            Console.WriteLine("Das Volk leidet in Angst und Armut.");
            Console.WriteLine("Korruption blüht in den Schatten der Diktatur.");
            Console.WriteLine("International isoliert, könnte das Regime von innen zerfallen...");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n⚠ WARNUNG: Fragile Diktatur");
        }
        else
        {
            Console.WriteLine("Mit absoluter Macht regiert Flad sein Reich.");
            Console.WriteLine("Niemand wagt es, ihm zu widersprechen.");
            Console.WriteLine("Der eiserne Präsident - gefürchtet und respektiert!");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n★ ERFOLG: Absolute Kontrolle erreicht");
        }
        
        Console.ResetColor();
        flad.ShowStats();
    }
}
