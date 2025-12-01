// Stammbaum-System für Rise of the Northborn
using System;
using System.Collections.Generic;
using System.Linq;

// ═══════════════════════════════════════════════════════════════════
// STAMMBAUM-KLASSEN
// ═══════════════════════════════════════════════════════════════════

[Serializable]
public class FamilyMember
{
    public string Name { get; set; }
    public int Generation { get; set; }
    public int Stärke { get; set; }
    public int Intelligenz { get; set; }
    public int Charisma { get; set; }
    public int Kraft { get; set; }
    public int GeburtsJahr { get; set; }
    public int TodesJahr { get; set; }
    public bool IstLebendig { get; set; }
    public string Beruf { get; set; }
    public List<FamilyMember> Kinder { get; set; }
    public FamilyMember Vater { get; set; }
    
    public FamilyMember(string name, int generation, PlayerCharacter basedOn = null)
    {
        Name = name;
        Generation = generation;
        Kinder = new List<FamilyMember>();
        IstLebendig = true;
        
        if (basedOn != null)
        {
            Stärke = basedOn.Stärke;
            Intelligenz = basedOn.Intelligenz;
            Charisma = basedOn.Charisma;
            Kraft = basedOn.Kraft;
            GeburtsJahr = 1952;
            Beruf = GetCurrentRole(basedOn.Phase);
        }
    }
    
    private string GetCurrentRole(GamePhase phase)
    {
        switch (phase)
        {
            case GamePhase.Geburt: return "Neugeborenes";
            case GamePhase.Kindheit: return "Kind";
            case GamePhase.KGBAmbitionen: return "Jugendlicher";
            case GamePhase.Jurastudium: return "Student";
            case GamePhase.DDREinsatz: return "KGB-Agent";
            case GamePhase.Präsident: return "Präsident";
            default: return "Unbekannt";
        }
    }
    
    public void GenerateChildren(int count)
    {
        Random rand = new Random();
        string[] boyNames = { "Dimitri", "Vladimir", "Nikolai", "Alexei", "Boris", "Sergei", "Igor", "Yuri" };
        string[] girlNames = { "Natasha", "Olga", "Svetlana", "Anastasia", "Irina", "Katya", "Ludmila", "Yelena" };
        
        for (int i = 0; i < count; i++)
        {
            bool isBoy = rand.Next(2) == 0;
            string childName = isBoy ? boyNames[rand.Next(boyNames.Length)] : girlNames[rand.Next(girlNames.Length)];
            
            if (Generation == 1)
                childName += " Rusputin Jr.";
            else
                childName += $" Rusputin {Generation + 1}";
            
            FamilyMember child = new FamilyMember(childName, Generation + 1)
            {
                Vater = this,
                GeburtsJahr = this.GeburtsJahr + 25 + rand.Next(10),
                IstLebendig = true,
                Beruf = "Kind"
            };
            
            // Vererbung mit Variation (-1 bis +2 pro Attribut)
            child.Stärke = Math.Max(0, this.Stärke + rand.Next(-1, 3));
            child.Intelligenz = Math.Max(0, this.Intelligenz + rand.Next(-1, 3));
            child.Charisma = Math.Max(0, this.Charisma + rand.Next(-1, 3));
            child.Kraft = Math.Max(0, this.Kraft + rand.Next(-1, 3));
            
            Kinder.Add(child);
        }
    }
}

[Serializable]
public class FamilyTree
{
    public FamilyMember Founder { get; set; }
    public FamilyMember CurrentPlayer { get; set; }
    public int CurrentGeneration { get; set; }
    
    public FamilyTree(PlayerCharacter founder)
    {
        Founder = new FamilyMember(founder.Name, 1, founder);
        CurrentPlayer = Founder;
        CurrentGeneration = 1;
    }
    
    public void DisplayTree()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                   RUSPUTIN STAMMBAUM                      ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");
        Console.ResetColor();
        Console.WriteLine();
        
        DisplayMember(Founder, 0);
        
        Console.WriteLine($"\nAktuelle Generation: {CurrentGeneration}");
        Console.WriteLine($"Aktueller Spieler: {CurrentPlayer.Name}");
    }
    
    private void DisplayMember(FamilyMember member, int indent)
    {
        string indentation = new string(' ', indent * 3);
        string status = member.IstLebendig ? "✓" : "†";
        
        ConsoleColor color = member == CurrentPlayer ? ConsoleColor.Green : 
                            member.IstLebendig ? ConsoleColor.White : ConsoleColor.DarkGray;
        
        Console.ForegroundColor = color;
        
        if (member == CurrentPlayer)
            Console.Write(indentation + "► ");
        else
            Console.Write(indentation + "  ");
            
        Console.Write($"{status} {member.Name}");
        
        if (!member.IstLebendig)
            Console.Write($" ({member.GeburtsJahr}-{member.TodesJahr})");
        else
            Console.Write($" ({member.GeburtsJahr}-)");
            
        Console.WriteLine($" - {member.Beruf}");
        
        Console.ResetColor();
        
        foreach (var child in member.Kinder)
        {
            DisplayMember(child, indent + 1);
        }
    }
    
    public List<FamilyMember> GetLivingDescendants()
    {
        List<FamilyMember> living = new List<FamilyMember>();
        CollectLiving(Founder, living);
        return living.Where(m => m != CurrentPlayer && m.IstLebendig).ToList();
    }
    
    private void CollectLiving(FamilyMember member, List<FamilyMember> result)
    {
        if (member.IstLebendig)
            result.Add(member);
            
        foreach (var child in member.Kinder)
            CollectLiving(child, result);
    }
    
    public FamilyMember SelectHeir()
    {
        var descendants = GetLivingDescendants();
        
        if (descendants.Count == 0)
        {
            Console.WriteLine("\n⚠ Keine lebenden Nachkommen vorhanden!");
            Console.WriteLine("Die Linie der Rusputins endet hier...");
            return null;
        }
        
        Console.Clear();
        Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
        Console.WriteLine("║              WÄHLE DEINEN NACHFOLGER                      ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════╝\n");
        
        Console.WriteLine($"{CurrentPlayer.Name} ist verstorben.");
        Console.WriteLine("Wähle ein Familienmitglied, um die Dynastie fortzuführen:\n");
        
        for (int i = 0; i < descendants.Count; i++)
        {
            var member = descendants[i];
            Console.WriteLine($"[{i + 1}] {member.Name}");
            Console.WriteLine($"    Generation: {member.Generation} | Beruf: {member.Beruf}");
            Console.WriteLine($"    Attribute: Stärke:{member.Stärke} Intel:{member.Intelligenz} Char:{member.Charisma} Kraft:{member.Kraft}");
            Console.WriteLine();
        }
        
        while (true)
        {
            Console.Write($"Wähle [1-{descendants.Count}]: ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= descendants.Count)
            {
                return descendants[choice - 1];
            }
        }
    }
}

// ═══════════════════════════════════════════════════════════════════
// ERWEITERTES SPEICHERSYSTEM
// ═══════════════════════════════════════════════════════════════════

[Serializable]
public class GameSave
{
    public string SaveName { get; set; }
    public DateTime SaveDate { get; set; }
    public PlayerCharacter Character { get; set; }
    public FamilyTree Family { get; set; }
    public int PlaytimeMinutes { get; set; }
    
    public GameSave(string name, PlayerCharacter character, FamilyTree family)
    {
        SaveName = name;
        SaveDate = DateTime.Now;
        Character = character;
        Family = family;
        PlaytimeMinutes = 0;
    }
    
    public string GetDisplayString()
    {
        string phase = Character.Phase.ToString();
        return $"{SaveName} | {Character.Name} | Gen:{Family.CurrentGeneration} | " +
               $"{phase} | {SaveDate:dd.MM.yyyy HH:mm}";
    }
}

public static class SaveManager
{
    private static Dictionary<int, GameSave> saves = new Dictionary<int, GameSave>();
    
    public static void SaveGame(PlayerCharacter character, FamilyTree family)
    {
        Console.Clear();
        Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                    SPIEL SPEICHERN                        ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════╝\n");
        
        // Zeige verfügbare Slots
        Console.WriteLine("Verfügbare Speicherslots:\n");
        for (int i = 1; i <= 5; i++)
        {
            if (saves.ContainsKey(i))
            {
                Console.WriteLine($"[{i}] {saves[i].GetDisplayString()}");
            }
            else
            {
                Console.WriteLine($"[{i}] (Leer)");
            }
        }
        
        Console.Write("\nWähle Slot [1-5] oder [0] zum Abbrechen: ");
        if (!int.TryParse(Console.ReadLine(), out int slot) || slot < 0 || slot > 5)
        {
            Console.WriteLine("Speichern abgebrochen.");
            System.Threading.Thread.Sleep(1000);
            return;
        }
        
        if (slot == 0) return;
        
        // Überschreiben bestätigen
        if (saves.ContainsKey(slot))
        {
            Console.Write($"\nSlot {slot} überschreiben? [J/N]: ");
            if (Console.ReadLine()?.ToUpper() != "J")
            {
                Console.WriteLine("Speichern abgebrochen.");
                System.Threading.Thread.Sleep(1000);
                return;
            }
        }
        
        // Namen eingeben
        Console.Write("\nGib einen Namen für diesen Spielstand ein: ");
        string saveName = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(saveName))
            saveName = $"Spielstand {slot}";
        
        // Speichern
        GameSave save = new GameSave(saveName, character, family);
        saves[slot] = save;
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n✓ Spiel erfolgreich in Slot {slot} gespeichert!");
        Console.ResetColor();
        Console.WriteLine($"Name: {saveName}");
        Console.WriteLine($"Datum: {save.SaveDate:dd.MM.yyyy HH:mm:ss}");
        Console.WriteLine($"\n[Drücke eine Taste...]");
        Console.ReadKey(true);
    }
    
    public static (PlayerCharacter, FamilyTree) LoadGame()
    {
        Console.Clear();
        Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                     SPIEL LADEN                           ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════╝\n");
        
        if (saves.Count == 0)
        {
            Console.WriteLine("Keine Spielstände vorhanden!");
            Console.WriteLine("\n[Drücke eine Taste...]");
            Console.ReadKey(true);
            return (null, null);
        }
        
        Console.WriteLine("Gespeicherte Spielstände:\n");
        foreach (var kvp in saves.OrderBy(s => s.Key))
        {
            Console.WriteLine($"[{kvp.Key}] {kvp.Value.GetDisplayString()}");
        }
        
        Console.Write("\nWähle Slot [1-5] oder [0] zum Abbrechen: ");
        if (!int.TryParse(Console.ReadLine(), out int slot) || slot < 0 || slot > 5)
        {
            Console.WriteLine("Laden abgebrochen.");
            System.Threading.Thread.Sleep(1000);
            return (null, null);
        }
        
        if (slot == 0) return (null, null);
        
        if (!saves.ContainsKey(slot))
        {
            Console.WriteLine($"Slot {slot} ist leer!");
            System.Threading.Thread.Sleep(1000);
            return (null, null);
        }
        
        GameSave save = saves[slot];
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n✓ Spiel geladen!");
        Console.ResetColor();
        Console.WriteLine($"Name: {save.SaveName}");
        Console.WriteLine($"Charakter: {save.Character.Name}");
        Console.WriteLine($"Generation: {save.Family.CurrentGeneration}");
        Console.WriteLine($"Gespeichert am: {save.SaveDate:dd.MM.yyyy HH:mm:ss}");
        Console.WriteLine($"\n[Drücke eine Taste...]");
        Console.ReadKey(true);
        
        return (save.Character, save.Family);
    }
    
    public static void DeleteSave(int slot)
    {
        if (saves.ContainsKey(slot))
        {
            saves.Remove(slot);
            Console.WriteLine($"Slot {slot} gelöscht.");
        }
    }
    
    public static Dictionary<int, GameSave> GetAllSaves()
    {
        return saves;
    }
}

// ═══════════════════════════════════════════════════════════════════
// TOD UND GENERATIONENWECHSEL
// ═══════════════════════════════════════════════════════════════════

public static class DeathAndSuccession
{
    public static bool CheckForDeath(PlayerCharacter character)
    {
        // Tod durch Gesundheit
        if (character.Gesundheit <= 0)
        {
            ShowDeathScene(character, "tödlichen Verletzungen");
            return true;
        }
        
        // Tod durch hohes Alter (nach Präsident-Phase)
        if (character.Phase == GamePhase.Präsident && character.Alter >= 70)
        {
            Random rand = new Random();
            int deathChance = (character.Alter - 70) * 10; // 0% bei 70, 100% bei 80
            
            if (rand.Next(100) < deathChance)
            {
                ShowDeathScene(character, "Altersschwäche");
                return true;
            }
        }
        
        return false;
    }
    
    private static void ShowDeathScene(PlayerCharacter character, string cause)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                         † TOD †                           ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");
        Console.ResetColor();
        
        Console.WriteLine($"\n{character.Name} ist im Alter von {character.Alter} Jahren");
        Console.WriteLine($"an {cause} gestorben.\n");
        System.Threading.Thread.Sleep(2000);
        
        Console.WriteLine("Seine Herrschaft war geprägt von:");
        Console.WriteLine($"  • Stärke: {character.Stärke}");
        Console.WriteLine($"  • Intelligenz: {character.Intelligenz}");
        Console.WriteLine($"  • Charisma: {character.Charisma}");
        Console.WriteLine($"  • Kraft: {character.Kraft}\n");
        System.Threading.Thread.Sleep(2000);
        
        Console.WriteLine($"Loyalität zur Partei: {character.LoyalitätPartei}%");
        Console.WriteLine($"Loyalität zum Volk: {character.LoyalitätVolk}%");
        Console.WriteLine($"Einfluss beim KGB: {character.EinflussKGB}%\n");
        System.Threading.Thread.Sleep(2000);
        
        Console.WriteLine("Die Dynastie geht weiter...");
        Console.WriteLine("\n[Drücke eine Taste...]");
        Console.ReadKey(true);
    }
    
    public static PlayerCharacter ContinueWithHeir(FamilyTree family)
    {
        // Markiere aktuellen Spieler als tot
        family.CurrentPlayer.IstLebendig = false;
        family.CurrentPlayer.TodesJahr = family.CurrentPlayer.GeburtsJahr + 70; // Beispiel
        family.CurrentPlayer.Beruf += " (verstorben)";
        
        // Wähle Nachfolger
        FamilyMember heir = family.SelectHeir();
        
        if (heir == null)
        {
            return null; // Game Over
        }
        
        // Erstelle neuen Charakter basierend auf Erben
        PlayerCharacter newChar = new PlayerCharacter(heir.Name, Difficulty.Mittel)
        {
            Stärke = heir.Stärke,
            Intelligenz = heir.Intelligenz,
            Charisma = heir.Charisma,
            Kraft = heir.Kraft,
            Alter = 25, // Erbe ist erwachsen
            Phase = GamePhase.Jurastudium, // Startet im Studium
            Gesundheit = 100
        };
        
        // Aktualisiere Stammbaum
        family.CurrentPlayer = heir;
        family.CurrentGeneration = heir.Generation;
        
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
        Console.WriteLine("\n[Drücke eine Taste um fortzufahren...]");
        Console.ReadKey(true);
        
        return newChar;
    }
}
