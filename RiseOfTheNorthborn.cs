// Rise of the Northborn - Flad Rusputin Saga
// Komplettes Spiel mit Stammbaum, Speichersystem und Schiffe Versenken
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

// ═══════════════════════════════════════════════════════════════════
// DATENKLASSEN
// ═══════════════════════════════════════════════════════════════════

class PlayerCharacter
{
    public string Name;
    public int Stärke, Intelligenz, Charisma, Kraft;
    public int Geld, Gesundheit;
    public int LoyalitätPartei, LoyalitätVolk, LoyalitätFamilie;
    public int EinflussKGB, EinflussMilitär, EinflussInternational;
    public int Alter, Generation;
    public string Phase;
    public bool KGBEasterEgg, GeheimeAusbildung;
    public bool IstVerheiratet;
    public string EhepartnerName;
    public int GeburtenBonus; // Mehr Kinder = höherer Wert
    public int FinanzBonus; // Weniger Kinder = höherer Bonus
    public List<PlayerCharacter> Kinder;
    public bool IstTot;
    
    public PlayerCharacter(string name, int generation)
    {
        Name = name;
        Generation = generation;
        Gesundheit = 100;
        Geld = 0;
        LoyalitätPartei = 50;
        LoyalitätVolk = 50;
        LoyalitätFamilie = 80;
        Phase = "Geburt";
        Kinder = new List<PlayerCharacter>();
        IstVerheiratet = false;
        IstTot = false;
        GeburtenBonus = 0;
        FinanzBonus = 0;
    }
}

class GameSave
{
    public string SaveName;
    public DateTime SaveDate;
    public PlayerCharacter Character;
    public int Generation;
    
    public GameSave(string name, PlayerCharacter character)
    {
        SaveName = name;
        SaveDate = DateTime.Now;
        Character = character;
        Generation = character.Generation;
    }
}

// ═══════════════════════════════════════════════════════════════════
// ZUFALLSEREIGNISSE
// ═══════════════════════════════════════════════════════════════════

class RandomEvent
{
    public string Name;
    public string Description;
    public string Phase;
    public int Chance; // 0-100
    
    public Action<PlayerCharacter> Apply;
    
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
// HOCHZEITS-SYSTEM
// ═══════════════════════════════════════════════════════════════════

class WifeOption
{
    public string Name;
    public string Beschreibung;
    public int GeburtenRate; // 1-5 (höher = mehr Kinder)
    public int GeldBonus; // Mehr Geld bei weniger Kindern
    public int LoyalitätBonus;
    
    public WifeOption(string name, string desc, int kinder, int geld, int loy)
    {
        Name = name;
        Beschreibung = desc;
        GeburtenRate = kinder;
        GeldBonus = geld;
        LoyalitätBonus = loy;
    }
}

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
    
    public static void RandomBirth(PlayerCharacter player)
    {
        if (!player.IstVerheiratet) return;
        
        int chance = player.GeburtenBonus * 15; // 15%, 30%, 45%, 60%, 75%
        
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
