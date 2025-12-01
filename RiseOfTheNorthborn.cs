// Rise of the Northborn - Flad Rusputin Saga
// Vollständiges C# Konsolenspiel mit komplettem Schiffe-Versenken-Minigame
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.IO;

class Program
{
    static bool stopMusic = false;
    static Dictionary<int, SaveData> saveSlots = new Dictionary<int, SaveData>();
    static Random rand = new Random();
    static List<BattleshipScore> battleshipHighscores = new List<BattleshipScore>();
    static PlayerCharacter flad = null;

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.BackgroundColor = ConsoleColor.Red;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Clear();

        string asciiFlag = @"            ▄▀▄▀              
          ▄▐▓▓▓▌▄            
          ▐▓▓▓▓▓▌            
        ▄▀▓▓▓▓▓▓▓▀▄          
      ▄▀  ▀▀▀▀▀▀▀  ▀▄        
    ▄▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▄       
   █  ☆              ☆  █    
  █                      █   
 █    ⚒                  █  
█   ☭                     █ 
█                         █ 
 ▀▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▀  ";

        Console.WriteLine(asciiFlag);

        string[] headerLines = {
            "══════════════════════════════════════════════════════════════",
            "║ ☆                                                      ☆ ║",
            "║      RISE OF THE NORTHBORN – FLAD RUSPUTIN SAGA          ║",
            "║ ☆                                                      ☆ ║",
            "══════════════════════════════════════════════════════════════"
        };

        foreach (string line in headerLines)
        {
            Console.WriteLine(line);
            Thread.Sleep(200);
        }

        Task.Run(() => PlayLoopingBeep());

        Console.WriteLine("\n[ Drücke eine Taste, um ins Hauptmenü zu gelangen... ]");
        Console.ReadKey(true);

        MainMenu();
    }

    static FamilyTree familyTree = null;
    
    static void StartFladStory()
    {
        stopMusic = true;
        Thread.Sleep(300);
        
        var result = FladStoryModule.StartNewGame();
        flad = result.Item1;
        familyTree = result.Item2;
        
        // Durchlaufe alle Phasen
        FladStoryModule.PlayChildhood(flad);
        FladStoryModule.PlayKGBPhase(flad);
        FladStoryModule.PlayUniversityPhase(flad);
        FladStoryModule.PlayDDRPhase(flad);
        FladStoryModule.PlayPresidentPhase(flad, familyTree);
        
        // Zeige Stammbaum
        Console.WriteLine("\n>> Drücke [S] um Stammbaum zu sehen, oder andere Taste zum Speichern...");
        if (Console.ReadKey(true).Key == ConsoleKey.S)
        {
            familyTree.DisplayTree();
            Console.WriteLine("\n[Drücke eine Taste...]");
            Console.ReadKey(true);
        }
        
        // Speichere am Ende
        SaveManager.SaveGame(flad, familyTree);
        
        stopMusic = false;
        Task.Run(() => PlayLoopingBeep());
    }
    
    static void SaveGameData(PlayerCharacter character)
    {
        for (int i = 1; i <= 5; i++)
        {
            if (!saveSlots.ContainsKey(i))
            {
                saveSlots[i] = new SaveData
                {
                    PlayerName = character.Name,
                    Timestamp = DateTime.Now,
                    Level = character.Alter,
                    Money = character.Geld
                };
                Console.WriteLine($"\n>> Spielstand gespeichert in Slot {i}.");
                Thread.Sleep(1000);
                return;
            }
        }
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

            Console.WriteLine("\n[1] Neues Spiel – Streben nach der Weltherrschaft");
            Console.WriteLine("[2] Spiel Laden");
            Console.WriteLine("[3] Highscore");
            Console.WriteLine("[4] Globaler Highscore");
            Console.WriteLine("[5] Mini Game: Schiffe versenken ⚓");
            Console.WriteLine("[6] Mehrspieler");
            Console.WriteLine("[7] Einstellungen");
            Console.WriteLine("[8] Beenden");

            Console.Write("\nWähle eine Option [1–8]: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1": StartFladStory(); break;
                case "2":
                    LoadGameMenu();
                    break;
                case "3":
                    Console.WriteLine(">> Highscore wird angezeigt...");
                    Console.ReadKey();
                    break;
                case "4":
                    Console.WriteLine(">> Globaler Highscore wird geladen...");
                    Console.ReadKey();
                    break;
                case "5":
                    stopMusic = true;
                    Thread.Sleep(300);
                    BattleshipGame();
                    stopMusic = false;
                    Task.Run(() => PlayLoopingBeep());
                    break;
                case "6":
                    Console.WriteLine(">> Mehrspielermodus aktiviert...");
                    Console.ReadKey();
                    break;
                case "7":
                    Console.WriteLine(">> Einstellungen geöffnet...");
                    Console.ReadKey();
                    break;
                case "8":
                    stopMusic = true;
                    Console.WriteLine(">> Auf Wiedersehen, Genosse! Das Vaterland dankt dir!");
                    Thread.Sleep(1000);
                    return;
                default:
                    Console.WriteLine("Ungültige Eingabe. Bitte wähle eine Zahl von 1 bis 8.");
                    Thread.Sleep(1000);
                    break;
            }
        }
    }

    static void PlayLoopingBeep()
    {
        int tempo = 150;
        int[] melody = { 659, 494, 523, 587, 523, 494, 440, 440, 523, 659, 587, 523, 494, 494, 523, 587, 659, 523, 440, 440 };
        int[] durations = { 1, 1, 1, 1, 1, 1, 2, 1, 1, 2, 1, 1, 2, 1, 1, 1, 1, 1, 1, 2 };
        while (!stopMusic)
        {
            for (int i = 0; i < melody.Length; i++)
            {
                if (stopMusic) return;
                try { Console.Beep(melody[i], tempo * durations[i]); }
                catch { }
            }
        }
    }

    static void SaveGame()
    {
        for (int i = 1; i <= 5; i++)
        {
            if (!saveSlots.ContainsKey(i))
            {
                saveSlots[i] = new SaveData
                {
                    PlayerName = "Flad Rusputin",
                    Timestamp = DateTime.Now,
                    Level = 1,
                    Money = 100
                };
                Console.WriteLine($">> Spiel gespeichert in Slot {i}.");
                Thread.Sleep(1000);
                return;
            }
        }
        Console.WriteLine(">> Alle Speicherplätze sind belegt.");
        Thread.Sleep(1000);
    }

    static void LoadGame()
    {
        Console.WriteLine("\n>> Verfügbare Speicherstände:");
        for (int i = 1; i <= 5; i++)
        {
            if (saveSlots.ContainsKey(i))
            {
                var save = saveSlots[i];
                Console.WriteLine($"[{i}] {save.PlayerName} - Level {save.Level} - {save.Timestamp:dd.MM.yyyy HH:mm}");
            }
            else
            {
                Console.WriteLine($"[{i}] (leer)");
            }
        }

        Console.Write("\nWähle Slot zum Laden (1–5) oder 0 zum Abbrechen: ");
        string choice = Console.ReadLine();
        if (int.TryParse(choice, out int slot) && slot >= 1 && slot <= 5)
        {
            if (saveSlots.ContainsKey(slot))
                Console.WriteLine($">> Spiel geladen: {saveSlots[slot].PlayerName}");
            else
                Console.WriteLine(">> Kein Spielstand in diesem Slot vorhanden.");
        }
        Thread.Sleep(1500);
    }

    // ═══════════════════════════════════════════════════════════════════
    // SCHIFFE VERSENKEN - VOLLSTÄNDIGE IMPLEMENTIERUNG
    // ═══════════════════════════════════════════════════════════════════

    static void BattleshipGame()
    {
        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
            Console.WriteLine("║           ⚓ SCHIFFE VERSENKEN ⚓                          ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");
            Console.ResetColor();

            Console.WriteLine("\n[1] Spieler gegen Computer");
            Console.WriteLine("[2] Spieler gegen Spieler");
            Console.WriteLine("[3] Highscore anzeigen");
            Console.WriteLine("[4] Zurück zum Hauptmenü");

            Console.Write("\nAuswahl: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    PlayBattleship(false);
                    break;
                case "2":
                    PlayBattleship(true);
                    break;
                case "3":
                    ShowBattleshipHighscores();
                    break;
                case "4":
                    return;
            }
        }
    }

    static void PlayBattleship(bool pvp)
    {
        Console.Clear();
        Console.Write("Bitte gib deinen Spielernamen ein: ");
        string player1Name = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(player1Name)) player1Name = "Spieler 1";

        string player2Name = pvp ? "" : "Computer";
        if (pvp)
        {
            Console.Write("Name von Spieler 2: ");
            player2Name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(player2Name)) player2Name = "Spieler 2";
        }

        int size = 0;
        while (size != 5 && size != 6 && size != 8)
        {
            Console.Write("\nWähle Schlachtfeldgröße:\n[1] Klein (5x5)\n[2] Mittel (6x6)\n[3] Groß (8x8)\nAuswahl: ");
            string sizeChoice = Console.ReadLine();
            if (sizeChoice == "1") size = 5;
            else if (sizeChoice == "2") size = 6;
            else if (sizeChoice == "3") size = 8;
        }

        BattleshipBoard board1 = new BattleshipBoard(size, player1Name);
        BattleshipBoard board2 = new BattleshipBoard(size, player2Name);

        // Spieler 1 platziert Schiffe
        Console.Clear();
        Console.WriteLine($"═══ {player1Name}, platziere deine Schiffe! ═══\n");
        PlaceShipsManual(board1);

        // Spieler 2 oder Computer platziert Schiffe
        if (pvp)
        {
            Console.Clear();
            Console.WriteLine("═══════════════════════════════════════════════");
            Console.WriteLine($"Spieler 2 ist an der Reihe!");
            Console.WriteLine("═══════════════════════════════════════════════");
            Console.WriteLine("\n[Drücke eine Taste wenn bereit...]");
            Console.ReadKey(true);
            Console.Clear();
            Console.WriteLine($"═══ {player2Name}, platziere deine Schiffe! ═══\n");
            PlaceShipsManual(board2);
        }
        else
        {
            PlaceShipsAuto(board2);
            Console.WriteLine($"\n>> {player2Name} hat seine Flotte positioniert!");
            Thread.Sleep(1500);
        }

        // Spielablauf
        DateTime startTime = DateTime.Now;
        PlayBattleshipTurns(board1, board2, pvp);
        TimeSpan duration = DateTime.Now - startTime;

        // Gewinner ermitteln
        string winner = board2.AllShipsSunk() ? player1Name : player2Name;
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
        Console.WriteLine($"║  🎉 SIEG! {winner} hat gewonnen! 🎉");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");
        Console.ResetColor();

        // Highscore speichern
        if (!pvp)
        {
            battleshipHighscores.Add(new BattleshipScore
            {
                PlayerName = winner,
                BoardSize = size,
                Duration = duration,
                Date = DateTime.Now
            });
            battleshipHighscores = battleshipHighscores.OrderBy(s => s.Duration).Take(10).ToList();
        }

        Console.WriteLine($"\nSpieldauer: {duration:mm\\:ss}");
        Console.WriteLine("\n[Drücke eine Taste um fortzufahren...]");
        Console.ReadKey(true);
    }

    static void PlayBattleshipTurns(BattleshipBoard board1, BattleshipBoard board2, bool pvp)
    {
        bool player1Turn = true;

        while (!board1.AllShipsSunk() && !board2.AllShipsSunk())
        {
            Console.Clear();

            if (pvp && !player1Turn)
            {
                Console.WriteLine("═══════════════════════════════════════════════");
                Console.WriteLine($"{board2.PlayerName} ist an der Reihe!");
                Console.WriteLine("═══════════════════════════════════════════════");
                Console.WriteLine("\n[Drücke eine Taste wenn bereit...]");
                Console.ReadKey(true);
                Console.Clear();
            }

            BattleshipBoard attacker = player1Turn ? board1 : board2;
            BattleshipBoard defender = player1Turn ? board2 : board1;

            Console.WriteLine($"═══ {attacker.PlayerName} ist am Zug ═══\n");

            // Eigenes Feld anzeigen
            Console.WriteLine($"Dein Feld ({attacker.PlayerName}):");
            attacker.Display(true);

            Console.WriteLine($"\nGegnerisches Feld ({defender.PlayerName}):");
            defender.Display(false);

            bool hit = false;
            if (!pvp && !player1Turn)
            {
                // Computer-KI
                hit = ComputerAttack(defender);
                Thread.Sleep(1500);
            }
            else
            {
                // Spieler-Angriff
                hit = PlayerAttack(defender);
            }

            // Bei Treffer nochmal angreifen
            if (!hit)
            {
                player1Turn = !player1Turn;
            }
        }
    }

    static void PlaceShipsManual(BattleshipBoard board)
    {
        int[] shipSizes = board.Size == 5 ? new[] { 4, 3, 2 } : 
                          board.Size == 6 ? new[] { 5, 4, 3, 2 } : 
                          new[] { 5, 4, 3, 3, 2 };

        foreach (int shipSize in shipSizes)
        {
            bool placed = false;
            while (!placed)
            {
                Console.Clear();
                Console.WriteLine($"Platziere Schiff der Größe {shipSize}\n");
                board.Display(true);

                Console.Write($"\nStartposition (z.B. A1): ");
                string pos = Console.ReadLine()?.ToUpper();

                Console.Write("Ausrichtung ([H]orizontal / [V]ertikal): ");
                string dir = Console.ReadLine()?.ToUpper();

                if (string.IsNullOrEmpty(pos) || pos.Length < 2) continue;

                int row = pos[0] - 'A';
                int col;
                if (!int.TryParse(pos.Substring(1), out col)) continue;
                col--;

                bool horizontal = dir == "H";

                if (board.PlaceShip(row, col, shipSize, horizontal))
                {
                    placed = true;
                    Console.WriteLine("✓ Schiff platziert!");
                    Thread.Sleep(500);
                }
                else
                {
                    Console.WriteLine("✗ Ungültige Position! Versuche es erneut.");
                    Thread.Sleep(1500);
                }
            }
        }

        Console.Clear();
        Console.WriteLine("Alle Schiffe platziert!\n");
        board.Display(true);
        Console.WriteLine("\n[Drücke eine Taste um fortzufahren...]");
        Console.ReadKey(true);
    }

    static void PlaceShipsAuto(BattleshipBoard board)
    {
        int[] shipSizes = board.Size == 5 ? new[] { 4, 3, 2 } :
                          board.Size == 6 ? new[] { 5, 4, 3, 2 } :
                          new[] { 5, 4, 3, 3, 2 };

        foreach (int shipSize in shipSizes)
        {
            bool placed = false;
            int attempts = 0;
            while (!placed && attempts < 100)
            {
                int row = rand.Next(board.Size);
                int col = rand.Next(board.Size);
                bool horizontal = rand.Next(2) == 0;

                placed = board.PlaceShip(row, col, shipSize, horizontal);
                attempts++;
            }
        }
    }

    static bool PlayerAttack(BattleshipBoard board)
    {
        while (true)
        {
            Console.Write("\nZiel angeben (z.B. B3): ");
            string input = Console.ReadLine()?.ToUpper();

            if (string.IsNullOrEmpty(input) || input.Length < 2) continue;

            int row = input[0] - 'A';
            int col;
            if (!int.TryParse(input.Substring(1), out col)) continue;
            col--;

            if (row < 0 || row >= board.Size || col < 0 || col >= board.Size)
            {
                Console.WriteLine("Ungültige Koordinaten!");
                continue;
            }

            AttackResult result = board.Attack(row, col);

            if (result == AttackResult.AlreadyShot)
            {
                Console.WriteLine("⚠ Du hast diese Position schon beschossen!");
                continue;
            }

            if (result == AttackResult.Hit)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("💥 TREFFER!");
                Console.ResetColor();
                try { Console.Beep(800, 200); } catch { }
                Thread.Sleep(1000);
                return true;
            }
            else if (result == AttackResult.Sunk)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("💥💥 TREFFER UND VERSENKT! 💥💥");
                Console.ResetColor();
                try
                {
                    Console.Beep(1000, 200);
                    Thread.Sleep(100);
                    Console.Beep(1200, 300);
                }
                catch { }
                Thread.Sleep(1500);
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("💧 Wasser - Daneben!");
                Console.ResetColor();
                try { Console.Beep(300, 200); } catch { }
                Thread.Sleep(1000);
                return false;
            }
        }
    }

    static bool ComputerAttack(BattleshipBoard board)
    {
        // Einfache KI: Zufälliger Angriff
        int row, col;
        int attempts = 0;
        do
        {
            row = rand.Next(board.Size);
            col = rand.Next(board.Size);
            attempts++;
        } while (board.Grid[row, col] == 'X' || board.Grid[row, col] == 'O' && attempts < 100);

        Console.WriteLine($"\nComputer greift an: {(char)('A' + row)}{col + 1}");

        AttackResult result = board.Attack(row, col);

        if (result == AttackResult.Hit)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("💥 Der Computer hat getroffen!");
            Console.ResetColor();
            try { Console.Beep(800, 200); } catch { }
            return true;
        }
        else if (result == AttackResult.Sunk)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("💥💥 Der Computer hat ein Schiff versenkt! 💥💥");
            Console.ResetColor();
            try
            {
                Console.Beep(1000, 200);
                Thread.Sleep(100);
                Console.Beep(1200, 300);
            }
            catch { }
            return true;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("💧 Der Computer hat daneben geschossen!");
            Console.ResetColor();
            try { Console.Beep(300, 200); } catch { }
            return false;
        }
    }

    static void ShowBattleshipHighscores()
    {
        Console.Clear();
        Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
        Console.WriteLine("║              🏆 SCHIFFE VERSENKEN HIGHSCORES 🏆           ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════╝\n");

        if (battleshipHighscores.Count == 0)
        {
            Console.WriteLine("Noch keine Highscores vorhanden!");
        }
        else
        {
            Console.WriteLine("Platz | Spieler            | Größe | Zeit     | Datum");
            Console.WriteLine("──────────────────────────────────────────────────────────");
            int place = 1;
            foreach (var score in battleshipHighscores)
            {
                Console.WriteLine($"{place,5} | {score.PlayerName,-18} | {score.BoardSize}x{score.BoardSize}  | {score.Duration:mm\\:ss} | {score.Date:dd.MM.yyyy}");
                place++;
            }
        }

        Console.WriteLine("\n[Drücke eine Taste um zurückzukehren...]");
        Console.ReadKey(true);
    }
}

// ═══════════════════════════════════════════════════════════════════
// DATENKLASSEN
// ═══════════════════════════════════════════════════════════════════

class SaveData
{
    public string PlayerName { get; set; }
    public DateTime Timestamp { get; set; }
    public int Level { get; set; }
    public int Money { get; set; }
}

class BattleshipScore
{
    public string PlayerName { get; set; }
    public int BoardSize { get; set; }
    public TimeSpan Duration { get; set; }
    public DateTime Date { get; set; }
}

enum AttackResult
{
    Miss,
    Hit,
    Sunk,
    AlreadyShot
}

class Ship
{
    public int Row { get; set; }
    public int Col { get; set; }
    public int Size { get; set; }
    public bool Horizontal { get; set; }
    public bool[] Hits { get; set; }

    public Ship(int row, int col, int size, bool horizontal)
    {
        Row = row;
        Col = col;
        Size = size;
        Horizontal = horizontal;
        Hits = new bool[size];
    }

    public bool IsSunk()
    {
        return Hits.All(h => h);
    }

    public bool IsAt(int row, int col)
    {
        if (Horizontal)
        {
            return row == Row && col >= Col && col < Col + Size;
        }
        else
        {
            return col == Col && row >= Row && row < Row + Size;
        }
    }

    public void Hit(int row, int col)
    {
        if (Horizontal)
        {
            Hits[col - Col] = true;
        }
        else
        {
            Hits[row - Row] = true;
        }
    }
}

class BattleshipBoard
{
    public int Size { get; private set; }
    public char[,] Grid { get; private set; }
    public List<Ship> Ships { get; private set; }
    public string PlayerName { get; private set; }

    public BattleshipBoard(int size, string playerName)
    {
        Size = size;
        PlayerName = playerName;
        Grid = new char[size, size];
        Ships = new List<Ship>();

        // Initialisiere Grid mit Wasser
        for (int i = 0; i < size; i++)
            for (int j = 0; j < size; j++)
                Grid[i, j] = '~';
    }

    public bool PlaceShip(int row, int col, int size, bool horizontal)
    {
        // Prüfe ob platzierbar
        if (horizontal)
        {
            if (col + size > Size) return false;
            for (int c = col; c < col + size; c++)
            {
                if (Grid[row, c] != '~') return false;
                // Prüfe auch Nachbarfelder
                for (int dr = -1; dr <= 1; dr++)
                {
                    for (int dc = -1; dc <= 1; dc++)
                    {
                        int nr = row + dr;
                        int nc = c + dc;
                        if (nr >= 0 && nr < Size && nc >= 0 && nc < Size)
                        {
                            if (Grid[nr, nc] == 'S') return false;
                        }
                    }
                }
            }
        }
        else
        {
            if (row + size > Size) return false;
            for (int r = row; r < row + size; r++)
            {
                if (Grid[r, col] != '~') return false;
                // Prüfe auch Nachbarfelder
                for (int dr = -1; dr <= 1; dr++)
                {
                    for (int dc = -1; dc <= 1; dc++)
                    {
                        int nr = r + dr;
                        int nc = col + dc;
                        if (nr >= 0 && nr < Size && nc >= 0 && nc < Size)
                        {
                            if (Grid[nr, nc] == 'S') return false;
                        }
                    }
                }
            }
        }

        // Platziere Schiff
        Ship ship = new Ship(row, col, size, horizontal);
        Ships.Add(ship);

        if (horizontal)
        {
            for (int c = col; c < col + size; c++)
                Grid[row, c] = 'S';
        }
        else
        {
            for (int r = row; r < row + size; r++)
                Grid[r, col] = 'S';
        }

        return true;
    }

    public AttackResult Attack(int row, int col)
    {
        if (Grid[row, col] == 'X' || Grid[row, col] == 'O')
            return AttackResult.AlreadyShot;

        if (Grid[row, col] == 'S')
        {
            Grid[row, col] = 'X';

            // Finde getroffenes Schiff
            Ship hitShip = Ships.FirstOrDefault(s => s.IsAt(row, col));
            if (hitShip != null)
            {
                hitShip.Hit(row, col);
                if (hitShip.IsSunk())
                    return AttackResult.Sunk;
            }

            return AttackResult.Hit;
        }
        else
        {
            Grid[row, col] = 'O';
            return AttackResult.Miss;
        }
    }

    public bool AllShipsSunk()
    {
        return Ships.All(s => s.IsSunk());
    }

    public void Display(bool showShips)
    {
        // Spaltenüberschriften
        Console.Write("   ");
        for (int c = 0; c < Size; c++)
            Console.Write($" {c + 1} ");
        Console.WriteLine();

        // Trennlinie
        Console.Write("   ");
        for (int c = 0; c < Size; c++)
            Console.Write("───");
        Console.WriteLine();

        for (int r = 0; r < Size; r++)
        {
            // Zeilenüberschrift
            Console.Write($" {(char)('A' + r)} │");

            for (int c = 0; c < Size; c++)
            {
                char cell = Grid[r, c];

                if (cell == 'S' && !showShips)
                    cell = '~'; // Verstecke gegnerische Schiffe

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

        // Untere Trennlinie
        Console.Write("   ");
        for (int c = 0; c < Size; c++)
            Console.Write("───");
        Console.WriteLine();

        Console.WriteLine("\nLegende: ~ Wasser | ■ Schiff | X Treffer | ○ Fehlschuss");
    }
}
