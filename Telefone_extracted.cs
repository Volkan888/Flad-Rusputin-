static class ErdoganHotline
{
    static Random rand = new Random();
    
    /// <summary>
    /// ShowHotlineMenu - Zeigt das Erdogan-Nottelefon Menü
    /// </summary>
    public static void ShowHotlineMenu(PlayerCharacter p)
    {
        if (p.ErdoganAnrufeVerfügbar <= 0)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n╔══════════════════════════════════════════════════════╗");
            Console.WriteLine("║       📞 ERDOGAN-NOTTELEFON - NICHT VERFÜGBAR       ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════╝\n");
            Console.ResetColor();
            Console.WriteLine("Du hast alle Anrufe aufgebraucht!");
            Console.WriteLine($"Schulden bei Türkei: {p.ErdoganSchulden} Rubel");
            Console.WriteLine("\nDrücke eine Taste...");
            Console.ReadKey();
            return;
        }
        
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n╔══════════════════════════════════════════════════════╗");
        Console.WriteLine("║           📞 ERDOGAN-NOTTELEFON AKTIVIERT           ║");
        Console.WriteLine("╚══════════════════════════════════════════════════════╝\n");
        Console.ResetColor();
        
        Console.WriteLine($"🔋 Verbleibende Anrufe: {p.ErdoganAnrufeVerfügbar}/5");
        Console.WriteLine($"🤝 Beziehung zu Türkei: {p.TürkeiBeziehung}%");
        Console.WriteLine($"💳 Aktuelle Schulden: {p.ErdoganSchulden} Rubel");
        Console.WriteLine("\n═══════════════════════════════════════════════════════\n");
        
        Console.WriteLine("[1] 💰 Geld leihen (500-2000 Rubel + 25% Zinsen)");
        Console.WriteLine("[2] 🛡️  S-400 System kaufen (Militärischer Schutz)");
        Console.WriteLine("[3] ⚡ Gas-Deal abschließen (Energie-Rabatt)");
        Console.WriteLine("[4] 🤝 Diplomatische Vermittlung (Krisenbonus)");
        Console.WriteLine("[5] 🌾 Getreide-Abkommen (Nahrungssicherheit)");
        Console.WriteLine("[6] 🏖️  Tourismus-Boost (Wirtschaftsförderung)");
        Console.WriteLine("[7] 🏗️  Akkuyu-AKW Investition (Energie-Zukunft)");
        Console.WriteLine("[8] 🔫 Waffenhandel (Militär-Export)");
        Console.WriteLine("[9] ❌ Abbrechen");
        
        Console.Write("\nWähle [1-9]: ");
        string choice = Console.ReadLine();
        
        switch (choice)
        {
            case "1":
                LeiheGeld(p);
                break;
            case "2":
                KaufeS400(p);
                break;
            case "3":
                GasDeal(p);
                break;
            case "4":
                DiplomatischeVermittlung(p);
                break;
            case "5":
                GetreideAbkommen(p);
                break;
            case "6":
                TourismusBoost(p);
                break;
            case "7":
                AkkuyuInvestition(p);
                break;
            case "8":
                Waffenhandel(p);
                break;
            case "9":
                Console.WriteLine("\nAnruf abgebrochen.");
                Thread.Sleep(1500);
                return;
            default:
                Console.WriteLine("\nUngültige Wahl!");
                Thread.Sleep(1500);
                return;
        }
        
        p.ErdoganAnrufeVerfügbar--;
        Console.WriteLine($"\n📞 Verbleibende Anrufe: {p.ErdoganAnrufeVerfügbar}/5");
        Console.WriteLine("\nDrücke eine Taste...");
        Console.ReadKey();
    }
    
    /// <summary>
    /// LeiheGeld - Leihe Geld von der Türkei mit 25% Zinsen
    /// </summary>
    static void LeiheGeld(PlayerCharacter p)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n💰 GELD-KREDIT VON TÜRKEI");
        Console.WriteLine("═══════════════════════════════════════════════════════\n");
        Console.ResetColor();
        
        Console.WriteLine("Wie viel möchtest du leihen?");
        Console.WriteLine("[1] 500 Rubel (Rückzahlung: 625)");
        Console.WriteLine("[2] 1000 Rubel (Rückzahlung: 1250)");
        Console.WriteLine("[3] 1500 Rubel (Rückzahlung: 1875)");
        Console.WriteLine("[4] 2000 Rubel (Rückzahlung: 2500)");
        Console.Write("\nWähle [1-4]: ");
        
        string choice = Console.ReadLine();
        int betrag = 0;
        int rückzahlung = 0;
        
        switch (choice)
        {
            case "1": betrag = 500; rückzahlung = 625; break;
            case "2": betrag = 1000; rückzahlung = 1250; break;
            case "3": betrag = 1500; rückzahlung = 1875; break;
            case "4": betrag = 2000; rückzahlung = 2500; break;
            default:
                Console.WriteLine("\nUngültige Wahl!");
                Thread.Sleep(1500);
                return;
        }
        
        p.Geld += betrag;
        p.ErdoganSchulden += rückzahlung;
        p.TürkeiBeziehung += 10; // Beziehung verbessert sich
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\n✓ Erdogan überweist {betrag} Rubel!");
        Console.WriteLine($"⚠ Rückzahlung fällig: {rückzahlung} Rubel (inkl. 25% Zinsen)");
        Console.WriteLine($"🤝 Beziehung zu Türkei: +10% (jetzt {p.TürkeiBeziehung}%)");
        Console.ResetColor();
    }
    
    /// <summary>
    /// KaufeS400 - Kaufe S-400 Flugabwehrsystem
    /// </summary>
    static void KaufeS400(PlayerCharacter p)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\n🛡️  S-400 FLUGABWEHRSYSTEM");
        Console.WriteLine("═══════════════════════════════════════════════════════\n");
        Console.ResetColor();
        
        if (p.Geld < 300)
        {
            Console.WriteLine("❌ Nicht genug Geld! Benötigt: 300 Rubel");
            Console.WriteLine($"Aktuelles Geld: {p.Geld} Rubel");
            Thread.Sleep(2000);
            return;
        }
        
        p.Geld -= 300;
        p.EinflussMilitär += 40;
        p.TürkeiBeziehung += 15;
        p.EinflussInternational -= 20; // NATO verärgert
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("✓ S-400 System erfolgreich erworben!");
        Console.WriteLine($"⚔️  Militärischer Einfluss: +40 (jetzt {p.EinflussMilitär})");
        Console.WriteLine($"🤝 Beziehung zu Türkei: +15% (jetzt {p.TürkeiBeziehung}%)");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"⚠ Internationaler Einfluss: -20 (NATO verärgert!)");
        Console.ResetColor();
    }
    
    /// <summary>
    /// GasDeal - Schließe günstigen Energie-Deal ab
    /// </summary>
    static void GasDeal(PlayerCharacter p)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("\n⚡ TÜRKSTREAM GAS-DEAL");
        Console.WriteLine("═══════════════════════════════════════════════════════\n");
        Console.ResetColor();
        
        p.Geld += 400; // Energieverkauf
        p.TürkeiBeziehung += 20;
        p.EinflussInternational += 10; // Energiemacht
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("✓ TurkStream-Pipeline liefert Gas!");
        Console.WriteLine($"💰 Geld: +400 Rubel (Energieexport)");
        Console.WriteLine($"🤝 Beziehung zu Türkei: +20% (jetzt {p.TürkeiBeziehung}%)");
        Console.WriteLine($"🌍 Internationaler Einfluss: +10 (Energiemacht!)");
        Console.ResetColor();
    }
    
    /// <summary>
    /// DiplomatischeVermittlung - Erdogan vermittelt in Krise
    /// </summary>
    static void DiplomatischeVermittlung(PlayerCharacter p)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\n🤝 DIPLOMATISCHE VERMITTLUNG");
        Console.WriteLine("═══════════════════════════════════════════════════════\n");
        Console.ResetColor();
        
        p.LoyalitätVolk += 20;
        p.LoyalitätPartei += 15;
        p.EinflussInternational += 25;
        p.TürkeiBeziehung += 15;
        p.ErdoganVermittlungAktiv = true;
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("✓ Erdogan vermittelt erfolgreich in internationaler Krise!");
        Console.WriteLine($"👥 Loyalität Volk: +20 (jetzt {p.LoyalitätVolk})");
        Console.WriteLine($"🏛️  Loyalität Partei: +15 (jetzt {p.LoyalitätPartei})");
        Console.WriteLine($"🌍 Internationaler Einfluss: +25 (jetzt {p.EinflussInternational})");
        Console.WriteLine($"🤝 Beziehung zu Türkei: +15% (jetzt {p.TürkeiBeziehung}%)");
        Console.ResetColor();
    }
    
    /// <summary>
    /// GetreideAbkommen - Schwarzmeer-Getreide-Deal
    /// </summary>
    static void GetreideAbkommen(PlayerCharacter p)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n🌾 SCHWARZMEER-GETREIDEABKOMMEN");
        Console.WriteLine("═══════════════════════════════════════════════════════\n");
        Console.ResetColor();
        
        p.Geld += 300;
        p.LoyalitätVolk += 25;
        p.EinflussInternational += 20;
        p.TürkeiBeziehung += 20;
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("✓ Getreide-Deal erfolgreich! Nahrungssicherheit gewährleistet.");
        Console.WriteLine($"💰 Geld: +300 Rubel (Getreidehandel)");
        Console.WriteLine($"👥 Loyalität Volk: +25 (Nahrung gesichert!)");
        Console.WriteLine($"🌍 Internationaler Einfluss: +20 (Mediator-Rolle!)");
        Console.WriteLine($"🤝 Beziehung zu Türkei: +20% (jetzt {p.TürkeiBeziehung}%)");
        Console.ResetColor();
    }
    
    /// <summary>
    /// TourismusBoost - Förderung des russisch-türkischen Tourismus
    /// </summary>
    static void TourismusBoost(PlayerCharacter p)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n🏖️  TOURISMUS-BOOST PROGRAMM");
        Console.WriteLine("═══════════════════════════════════════════════════════\n");
        Console.ResetColor();
        
        p.Geld += 350;
        p.LoyalitätVolk += 20;
        p.TürkeiBeziehung += 25;
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("✓ Visafreie Einreise! Millionen russische Touristen nach Türkei.");
        Console.WriteLine($"💰 Geld: +350 Rubel (Tourismussektor belebt)");
        Console.WriteLine($"👥 Loyalität Volk: +20 (Urlaubsmöglichkeiten!)");
        Console.WriteLine($"🤝 Beziehung zu Türkei: +25% (jetzt {p.TürkeiBeziehung}%)");
        Console.ResetColor();
    }
    
    /// <summary>
    /// AkkuyuInvestition - Investition in türkisches Atomkraftwerk
    /// </summary>
    static void AkkuyuInvestition(PlayerCharacter p)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\n🏗️  AKKUYU-ATOMKRAFTWERK INVESTITION");
        Console.WriteLine("═══════════════════════════════════════════════════════\n");
        Console.ResetColor();
        
        if (p.Geld < 400)
        {
            Console.WriteLine("❌ Nicht genug Geld! Benötigt: 400 Rubel");
            Console.WriteLine($"Aktuelles Geld: {p.Geld} Rubel");
            Thread.Sleep(2000);
            return;
        }
        
        p.Geld -= 400;
        p.Geld += 600; // Langfristiger Gewinn
        p.EinflussInternational += 30;
        p.TürkeiBeziehung += 30;
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("✓ Rosatom baut Akkuyu-AKW! 4 Reaktorblöcke, 20 Mrd. USD Projekt.");
        Console.WriteLine($"💰 Geld: +200 Rubel netto (langfristiger Energievertrag)");
        Console.WriteLine($"🌍 Internationaler Einfluss: +30 (Technologie-Export!)");
        Console.WriteLine($"🤝 Beziehung zu Türkei: +30% (jetzt {p.TürkeiBeziehung}%)");
        Console.ResetColor();
    }
    
    /// <summary>
    /// Waffenhandel - Export russischer Waffen an Türkei
    /// </summary>
    static void Waffenhandel(PlayerCharacter p)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\n🔫 MILITÄR-WAFFENHANDEL");
        Console.WriteLine("═══════════════════════════════════════════════════════\n");
        Console.ResetColor();
        
        p.Geld += 450;
        p.EinflussMilitär += 25;
        p.TürkeiBeziehung += 20;
        p.EinflussInternational -= 15; // NATO-Kritik
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("✓ Waffenexport an Türkei! Su-35 Kampfjets, Panir-Systeme...");
        Console.WriteLine($"💰 Geld: +450 Rubel (Rüstungsgeschäft)");
        Console.WriteLine($"⚔️  Militäreinfluss: +25 (jetzt {p.EinflussMilitär})");
        Console.WriteLine($"🤝 Beziehung zu Türkei: +20% (jetzt {p.TürkeiBeziehung}%)");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"⚠ Internationaler Einfluss: -15 (NATO besorgt!)");
        Console.ResetColor();
    }
}

// ═══════════════════════════════════════════════════════════════════
// FINKA-SYSTEM - Gesundheits-Regeneration
// ═══════════════════════════════════════════════════════════════════
/// <summary>
/// FinkaSystem - Datsche/Finka für Gesundheits-Regeneration
/// 
/// FEATURES:
/// - Kaufbar als Präsident für 800 Rubel
/// - Gesundheit +30 pro Besuch
/// - Cooldown: 2 Jahre zwischen Besuchen
/// - Nur bei niedriger Gesundheit (<50) empfohlen
/// </summary>
static class FinkaSystem
{
    /// <summary>
    /// ShowFinkaMenu - Hauptmenü für Finka
    /// </summary>
    public static void ShowFinkaMenu(PlayerCharacter p)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(@"
        ╔════════════════════════════════════════════╗
        ║   🏡 PRÄSIDENTEN-FINKA 🏡                  ║
        ║   Datsche am Schwarzen Meer                ║
        ╚════════════════════════════════════════════╝
        ");
        Console.ResetColor();
        
        if (!p.HatFinka)
        {
            Console.WriteLine("\n🏡 Sie haben noch keine Finka!");
            Console.WriteLine($"\n💰 Kaufpreis: {p.FinkaKosten} Rubel");
            Console.WriteLine("📍 Lage: Sotschi, Schwarzes Meer");
            Console.WriteLine("✨ Bonus: +30 Gesundheit pro Besuch");
            Console.WriteLine("⏰ Cooldown: 2 Jahre zwischen Besuchen");
            
            Console.WriteLine($"\n💰 Dein Geld: {p.Geld} Rubel");
            Console.WriteLine($"❤️  Deine Gesundheit: {p.Gesundheit}%");
            
            if (p.Geld >= p.FinkaKosten)
            {
                Console.WriteLine("\n[1] Finka kaufen");
                Console.WriteLine("[2] Zurück");
                Console.Write("\nWähle [1-2]: ");
                
                if (Console.ReadLine() == "1")
                {
                    p.Geld -= p.FinkaKosten;
                    p.HatFinka = true;
                    
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n✓ FINKA GEKAUFT!");
                    Console.WriteLine("═══════════════════════════════════════════════════════\n");
                    Console.ResetColor();
                    
                    Console.WriteLine("🏡 Prächtige Datsche am Schwarzen Meer erworben!");
                    Console.WriteLine("🌊 Privater Strandzugang");
                    Console.WriteLine("🍇 Weinberg inklusive");
                    Console.WriteLine("🛡️  Private Sicherheit");
                    
                    Console.WriteLine($"\n💰 Geld: -{p.FinkaKosten} Rubel (jetzt {p.Geld})");
                    
                    Console.WriteLine("\n[Drücke eine Taste...]");
                    Console.ReadKey(true);
                    
                    // Direkt nach Kauf besuchen?
                    BesucheFinka(p);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n⚠️  Nicht genug Geld! Benötigt: {p.FinkaKosten} Rubel");
                Console.ResetColor();
                Console.WriteLine("\n[Drücke eine Taste...]");
                Console.ReadKey(true);
            }
        }
        else
        {
            // Finka bereits gekauft
            Console.WriteLine("\n🏡 Deine Finka in Sotschi");
            Console.WriteLine($"❤️  Gesundheit: {p.Gesundheit}%");
            Console.WriteLine($"📅 Alter: {p.Alter} Jahre");
            Console.WriteLine($"📆 Letzter Besuch: Jahr {p.LetzterFinkabesuch}");
            
            int jahreSeitBesuch = p.Alter - p.LetzterFinkabesuch;
            
            if (jahreSeitBesuch < 2)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\n⏰ Cooldown aktiv! Noch {2 - jahreSeitBesuch} Jahr(e) warten.");
                Console.ResetColor();
                Console.WriteLine("\n[Drücke eine Taste...]");
                Console.ReadKey(true);
            }
            else
            {
                Console.WriteLine("\n[1] Finka besuchen (+30 Gesundheit)");
                Console.WriteLine("[2] Zurück");
                Console.Write("\nWähle [1-2]: ");
                
                if (Console.ReadLine() == "1")
                {
                    BesucheFinka(p);
                }
            }
        }
    }
    
    static void BesucheFinka(PlayerCharacter p)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(@"
        ╔════════════════════════════════════════════╗
        ║   🌊 URLAUB IN DER FINKA 🌊               ║
        ╚════════════════════════════════════════════╝
        ");
        Console.ResetColor();
        
        Console.WriteLine("\n🚗 Fahrt nach Sotschi...");
        Thread.Sleep(1500);
        Console.WriteLine("🏡 Ankunft an der Finka!");
        Thread.Sleep(1000);
        Console.WriteLine("🌊 Blick aufs Schwarze Meer...");
        Thread.Sleep(1000);
        Console.WriteLine("🍷 Ein Glas georgischen Wein...");
        Thread.Sleep(1000);
        Console.WriteLine("🛀 Entspannung in der Sauna...");
        Thread.Sleep(1000);
        Console.WriteLine("😴 Erholsamer Schlaf...");
        Thread.Sleep(1500);
        
        int alteGesundheit = p.Gesundheit;
        p.Gesundheit = Math.Min(100, p.Gesundheit + 30);
        p.LetzterFinkabesuch = p.Alter;
        
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n✓ ERHOLT UND ERFRISCHT!");
        Console.WriteLine("═══════════════════════════════════════════════════════\n");
        Console.ResetColor();
        
        Console.WriteLine("🏖️  Eine Woche Entspannung hat Wunder gewirkt!");
        Console.WriteLine($"\n❤️  Gesundheit: {alteGesundheit}% → {p.Gesundheit}% (+{p.Gesundheit - alteGesundheit})");
        Console.WriteLine($"😌 Stress: REDUZIERT");
        Console.WriteLine($"💪 Energie: AUFGELADEN");
        
        if (p.Gesundheit == 100)
        {
            Console.WriteLine("\n✨ Du fühlst dich wie neugeboren!");
        }
        
        Console.WriteLine("\n[Drücke eine Taste...]");
        Console.ReadKey(true);
    }
}

// ═══════════════════════════════════════════════════════════════════
// SOUND SYSTEM & RUSSISCHE LIEDER
// ═══════════════════════════════════════════════════════════════════
/// <summary>
/// SoundSystem - Beep-Sounds und russische Musikstücke
/// 
/// FEATURES:
/// - Event-Sounds mit Console.Beep()
/// - Russische Hymne & Lieder (Melodie als ASCII + Beeps)
/// - Verschiedene Sounds für Event-Typen
/// </summary>
static class SoundSystem
{
    /// <summary>
    /// PlayEventSound - Spielt passenden Sound für Event-Typ
    /// </summary>
    public static void PlayEventSound(string eventType)
    {
        try
        {
            if (eventType == "katastrophe")
            {
                // Alarm-Sound
                Console.Beep(800, 150);
                Console.Beep(600, 150);
                Console.Beep(800, 150);
            }
            else if (eventType == "sidechick")
            {
                // Romantischer Sound
                Console.Beep(523, 200); // C
                Console.Beep(659, 200); // E
                Console.Beep(784, 300); // G
            }
            else if (eventType == "usa")
            {
                // Dramatischer Sound
                Console.Beep(440, 250);
                Console.Beep(494, 250);
            }
            else if (eventType == "türkei")
            {
                // Exotischer Sound
                Console.Beep(660, 200);
                Console.Beep(740, 200);
            }
            else if (eventType == "politisch")
            {
                // Offizieller Sound
                Console.Beep(392, 300);
                Console.Beep(523, 300);
            }
            else
            {
                // Standard Event-Sound
                Console.Beep(1000, 100);
            }
        }
        catch
        {
            // Beep nicht verfügbar auf manchen Systemen - ignorieren
        }
    }
    
    /// <summary>
    /// PlayRussianAnthem - Spielt die Sowjet-/Russische Hymne
    /// </summary>
    public static void PlayRussianAnthem()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(@"
        ╔════════════════════════════════════════════╗
        ║   🎵 ГИМН РОССИИ 🎵                        ║
        ║   Russische Hymne                          ║
        ╚════════════════════════════════════════════╝
        ");
        Console.ResetColor();
        Console.WriteLine(@"
        Россия — священная наша держава,
        Россия — любимая наша страна.
        Могучая воля, великая слава —
        Твоё достоянье на все времена!
        
        🎶 REFRAIN 🎶
        Славься, Отечество наше свободное,
        Братских народов союз вековой,
        Предками данная мудрость народная!
        Славься, страна! Мы гордимся тобой!
        ");
        
        try
        {
            // Melodie (vereinfacht)
            int[] notes = {392, 440, 494, 523, 587, 523, 494, 440, 392, 349, 330, 349, 392, 440, 392};
            int[] durations = {400, 400, 400, 600, 400, 400, 400, 400, 600, 400, 400, 400, 400, 600, 800};
            
            for (int i = 0; i < notes.Length; i++)
            {
                Console.Beep(notes[i], durations[i]);
                Thread.Sleep(50);
            }
        }
        catch
        {
            // Beep nicht verfügbar
            Console.WriteLine("\n[Hymne erklingt...]");
            Thread.Sleep(3000);
        }
        
        Console.WriteLine("\n[Drücke eine Taste...]");
        Console.ReadKey(true);
    }
    
    /// <summary>
    /// PlayKatyusha - Spielt "Катюша" (berühmtes russisches Lied)
    /// </summary>
    public static void PlayKatyusha()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(@"
        ╔════════════════════════════════════════════╗
        ║   🎵 КАТЮША 🎵                             ║
        ║   Berühmtes Volkslied                      ║
        ╚════════════════════════════════════════════╝
        ");
        Console.ResetColor();
        Console.WriteLine(@"
        Расцветали яблони и груши,
        Поплыли туманы над рекой.
        Выходила на берег Катюша,
        На высокий берег на крутой.
        
        🎶 CHORUS 🎶
        Ой, ты песня, песенка девичья,
        Ты лети за ясным солнцем вслед.
        И бойцу на дальнем пограничье
        От Катюши передай привет!
        ");
        
        try
        {
            // Katyusha Melodie (vereinfacht)
            int[] notes = {392, 440, 494, 523, 494, 440, 392, 349, 392, 440, 494, 523, 587, 523, 494};
            int[] durations = {300, 300, 300, 500, 300, 300, 500, 300, 300, 300, 300, 500, 300, 300, 600};
            
            for (int i = 0; i < notes.Length; i++)
            {
                Console.Beep(notes[i], durations[i]);
                Thread.Sleep(30);
            }
        }
        catch
        {
            Console.WriteLine("\n[Katyusha erklingt...]");
            Thread.Sleep(3000);
        }
        
        Console.WriteLine("\n[Drücke eine Taste...]");
        Console.ReadKey(true);
    }
    
    /// <summary>
    /// PlayKalinka - Spielt "Калинка" (schnelles Tanzlied)
    /// </summary>
    public static void PlayKalinka()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(@"
        ╔════════════════════════════════════════════╗
        ║   🎵 КАЛИНКА 🎵                            ║
        ║   Schnelles Tanzlied                       ║
        ╚════════════════════════════════════════════╝
        ");
        Console.ResetColor();
        Console.WriteLine(@"
        Калинка, калинка, калинка моя!
        В саду ягода малинка, малинка моя!
        
        Ах! Под сосною, под зелёною,
        Спать положите вы меня!
        Ай-люли, люли, ай-люли, люли,
        Спать положите вы меня!
        
        🎶 [Tempo steigt!] 🎶
        ");
        
        try
        {
            // Kalinka Melodie (schnell werdend)
            int[] notes = {523, 587, 659, 587, 523, 494, 440, 494, 523, 587, 659, 698, 659, 587, 523};
            
            // Beginnt langsam, wird schneller
            for (int i = 0; i < notes.Length; i++)
            {
                int duration = Math.Max(100, 300 - (i * 15)); // Wird schneller
                Console.Beep(notes[i], duration);
                Thread.Sleep(20);
            }
        }
        catch
        {
            Console.WriteLine("\n[Kalinka erklingt...]");
            Thread.Sleep(2500);
        }
        
        Console.WriteLine("\n[Drücke eine Taste...]");
        Console.ReadKey(true);
    }
    
    /// <summary>
    /// ShowMusicMenu - Menü für russische Lieder
    /// </summary>
    public static void ShowMusicMenu(PlayerCharacter player)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(@"
        ╔════════════════════════════════════════════╗
        ║   🎵 RUSSISCHE LIEDER 🎵                   ║
        ║   Musik des Vaterlandes                    ║
        ╚════════════════════════════════════════════╝
        ");
        Console.ResetColor();
        
        Console.WriteLine("\n[1] 🇷🇺 Russische Hymne (Гимн России)");
        Console.WriteLine("[2] 🎶 Katyusha (Катюша) - Volkslied");
        Console.WriteLine("[3] 💃 Kalinka (Калинка) - Tanzlied");
        Console.WriteLine("[4] 🔙 Zurück");
        Console.Write("\nWähle [1-4]: ");
        
        string choice = Console.ReadLine();
        
        switch (choice)
        {
            case "1":
                PlayRussianAnthem();
                player.LoyalitätVolk += 5; // Patriotismus
                player.LoyalitätPartei += 5;
                Console.WriteLine("\n✓ Patriotismus +10!");
                break;
            case "2":
                PlayKatyusha();
                player.Charisma += 1;
                Console.WriteLine("\n✓ Charisma +1!");
                break;
            case "3":
                PlayKalinka();
                player.Gesundheit = Math.Min(100, player.Gesundheit + 5);
                Console.WriteLine("\n✓ Gesundheit +5 (Tanzen!)");
                break;
            case "4":
                return;
        }
        
        Thread.Sleep(2000);
    }
}

// ═══════════════════════════════════════════════════════════════════
// TRUMP-TELEFON EASTER EGG
// ═══════════════════════════════════════════════════════════════════
/// <summary>
/// TrumpHotline - Das legendäre Trump-Telefon
/// 
/// Ein rotes Telefon aus den 2010er Jahren klingelt im Kreml.
/// Donald Trump ruft persönlich an mit verrückten Vorschlägen!
/// 
/// FEATURES:
/// - 3 Anrufe verfügbar (nach Helsinki-Gipfel freigeschaltet)
/// - Skurrile Dialoge basierend auf echten Trump-Zitaten
/// - Optionen mit positiven/negativen Konsequenzen
/// - USA-Beziehung beeinflusst Optionen
/// </summary>
static class TrumpHotline
{
    static Random rand = new Random();
    
    /// <summary>
    /// CallTrump - Hauptmenü für Trump-Telefon
    /// </summary>
    public static void CallTrump(PlayerCharacter p)
    {
        if (!p.TrumpTelefonAktiv)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n📞 TRUMP-TELEFON");
            Console.WriteLine("═══════════════════════════════════════════════════════\n");
            Console.ResetColor();
            Console.WriteLine("Das Trump-Telefon ist noch nicht freigeschaltet!");
            Console.WriteLine("\n💡 Tipp: Wird beim Helsinki-Gipfel 2018 aktiviert.");
            Console.WriteLine("\n[Drücke eine Taste...]");
            Console.ReadKey(true);
            return;
        }
        
        if (p.TrumpAnrufeVerfügbar <= 0)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n📞 TRUMP-TELEFON");
            Console.WriteLine("═══════════════════════════════════════════════════════\n");
            Console.ResetColor();
            Console.WriteLine("Alle Anrufe aufgebraucht!");
            Console.WriteLine("\nTrump ist nicht mehr im Amt...");
            Console.WriteLine("\n[Drücke eine Taste...]");
            Console.ReadKey(true);
            return;
        }
        
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(@"
        ╔═══════════════════════════════════╗
        ║   📞 TRUMP-TELEFON 📞            ║
        ║   🇺🇸 DIREKT-LEITUNG 🇺🇸          ║
        ╚═══════════════════════════════════╝
        ");
        Console.ResetColor();
        
        Console.WriteLine($"🔋 Verbleibende Anrufe: {p.TrumpAnrufeVerfügbar}/3");
        Console.WriteLine($"🤝 USA-Beziehung: {p.USABeziehung}%");
        Console.WriteLine();
        
        Console.WriteLine("[1] 💰 Deal-Making (Wirtschaftshilfe anfragen)");
        Console.WriteLine("[2] 🛡️  NATO diskutieren (Sicherheitspolitik)");
        Console.WriteLine("[3] 📰 Fake News Kampagne (Desinformation)");
        Console.WriteLine("[4] 🔙 Zurück");
        Console.Write("\nWähle [1-4]: ");
        
        string choice = Console.ReadLine();
        
        switch (choice)
        {
            case "1":
                DealMaking(p);
                break;
            case "2":
                NATODiskussion(p);
                break;
            case "3":
                FakeNewsKampagne(p);
                break;
            case "4":
                return;
        }
        
        p.TrumpAnrufeVerfügbar--;
    }
    
    /// <summary>
    /// DealMaking - Trump's berühmte "Art of the Deal"
    /// </summary>
    static void DealMaking(PlayerCharacter p)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n💰 DEAL-MAKING MIT TRUMP");
        Console.WriteLine("═══════════════════════════════════════════════════════\n");
        Console.ResetColor();
        
        Console.WriteLine("📞 *Ring Ring*");
        Thread.Sleep(1000);
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\nTrump: 'Wladimir, mein Freund! Dies ist ein HISTORIC call!'");
        Console.WriteLine("Trump: 'I make the BEST deals, believe me. You need money?'");
        Console.WriteLine("Trump: 'The sanctions - terrible, terrible situation. But I have an idea!'");
        Console.WriteLine("Trump: 'You help me with something, I help you with Congress. Deal?'");
        Console.ResetColor();
        
        Console.WriteLine("\n[1] Deal annehmen (Gegendienst nötig)");
        Console.WriteLine("[2] Höflich ablehnen");
        Console.Write("\nWähle [1-2]: ");
        
        if (Console.ReadLine() == "1")
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n✓ DEAL GEMACHT!");
            Console.WriteLine("═══════════════════════════════════════════════════════\n");
            
            p.Geld += 300;
            p.USABeziehung += 25;
            p.EinflussInternational -= 15; // Verdächtiger Deal
            p.LoyalitätPartei += 10;
            
            Console.WriteLine("Trump: 'FANTASTIC! This is going to be YUGE!'");
            Console.WriteLine("\n💰 Geld: +300 Rubel (Trump-Investitionen)");
            Console.WriteLine($"🤝 USA-Beziehung: +25% (jetzt {p.USABeziehung}%)");
            Console.WriteLine($"🏛️  Loyalität Partei: +10 (jetzt {p.LoyalitätPartei})");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"⚠ Internationales Ansehen: -15 (verdächtiger Deal!)");
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine("\nTrump: 'Your loss, buddy. Could've been tremendous!'");
            p.USABeziehung -= 10;
        }
        
        Console.WriteLine("\n[Drücke eine Taste...]");
        Console.ReadKey(true);
    }
    
    /// <summary>
    /// NATODiskussion - Trump's kritische Sicht auf NATO
    /// </summary>
    static void NATODiskussion(PlayerCharacter p)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("\n🛡️  NATO-DISKUSSION");
        Console.WriteLine("═══════════════════════════════════════════════════════\n");
        Console.ResetColor();
        
        Console.WriteLine("📞 *Ring Ring*");
        Thread.Sleep(1000);
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\nTrump: 'Vlad! NATO is a disaster. Total disaster!'");
        Console.WriteLine("Trump: 'They don't pay their bills. Germany, France - FREELOADERS!'");
        Console.WriteLine("Trump: 'Maybe we should talk about... alternatives? Ukraine in NATO?'");
        Console.WriteLine("Trump: 'I could slow things down. What do you think about that?'");
        Console.ResetColor();
        
        Console.WriteLine("\n[1] Zustimmen (NATO-Erweiterung stoppen)");
        Console.WriteLine("[2] Neutral bleiben");
        Console.WriteLine("[3] NATO-Erweiterung befürworten (Falle!)");
        Console.Write("\nWähle [1-3]: ");
        
        string choice = Console.ReadLine();
        
        Console.Clear();
        
        if (choice == "1")
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n✓ GEHEIME VEREINBARUNG!");
            Console.WriteLine("═══════════════════════════════════════════════════════\n");
            
            p.EinflussMilitär += 30;
            p.USABeziehung += 20;
            p.EinflussInternational += 15;
            
            Console.WriteLine("Trump: 'Smart move! NATO expansion - PAUSED!'");
            Console.WriteLine("\n⚔️  Militärischer Einfluss: +30 (Sicherheitszone!)");
            Console.WriteLine($"🤝 USA-Beziehung: +20% (jetzt {p.USABeziehung}%)");
            Console.WriteLine($"🌍 Internationaler Einfluss: +15 (jetzt {p.EinflussInternational})");
            Console.ResetColor();
        }
        else if (choice == "2")
        {
            Console.WriteLine("\nTrump: 'Playing it safe, huh? Smart guy!'");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n⚠️  FALLE!");
            Console.WriteLine("═══════════════════════════════════════════════════════\n");
            
            p.EinflussMilitär -= 25;
            p.USABeziehung -= 30;
            
            Console.WriteLine("Trump: 'Haha! Just kidding! NATO expands BIGLY!'");
            Console.WriteLine("\n⚠️  Das war eine Falle! NATO erweitert sich!");
            Console.WriteLine($"⚔️  Militäreinfluss: -25 (jetzt {p.EinflussMilitär})");
            Console.WriteLine($"🤝 USA-Beziehung: -30% (jetzt {p.USABeziehung}%)");
            Console.ResetColor();
        }
        
        Console.WriteLine("\n[Drücke eine Taste...]");
        Console.ReadKey(true);
    }
    
    /// <summary>
    /// FakeNewsKampagne - Trump's Expertise in Desinformation
    /// </summary>
    static void FakeNewsKampagne(PlayerCharacter p)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\n📰 FAKE NEWS KAMPAGNE");
        Console.WriteLine("═══════════════════════════════════════════════════════\n");
        Console.ResetColor();
        
        Console.WriteLine("📞 *Ring Ring*");
        Thread.Sleep(1000);
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\nTrump: 'Vladimir! I heard you have some... troll factories?'");
        Console.WriteLine("Trump: 'GENIUS idea! The media - all fake news anyway, right?'");
        Console.WriteLine("Trump: 'We could coordinate. Your bots, my tweets - UNSTOPPABLE!'");
        Console.WriteLine("Trump: 'Make some fake news about Biden. He's a disaster. Total disaster!'");
        Console.ResetColor();
        
        Console.WriteLine("\n[1] Kooperation zusagen (Gemeinsame Desinformation)");
        Console.WriteLine("[2] Zu riskant - ablehnen");
        Console.Write("\nWähle [1-2]: ");
        
        if (Console.ReadLine() == "1")
        {
            Console.Clear();
            
            // Zufällige Entdeckung
            bool entdeckt = rand.Next(100) < 60;
            
            if (!entdeckt)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n✓ OPERATION ERFOLGREICH!");
                Console.WriteLine("═══════════════════════════════════════════════════════\n");
                
                p.EinflussKGB += 35;
                p.USABeziehung += 15;
                p.LoyalitätVolk += 10; // Propaganda-Effekt
                
                Console.WriteLine("Trump: 'BRILLIANT! Nobody suspects a thing!'");
                Console.WriteLine("\n💻 KGB-Einfluss: +35 (Desinformationsnetzwerk)");
                Console.WriteLine($"🤝 USA-Beziehung: +15% (jetzt {p.USABeziehung}%)");
                Console.WriteLine($"👥 Loyalität Volk: +10 (Propaganda wirkt!)");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n⚠️  AUFGEFLOGEN!");
                Console.WriteLine("═══════════════════════════════════════════════════════\n");
                
                p.EinflussInternational -= 50;
                p.USABeziehung -= 40;
                p.Geld -= 200; // Sanktionen
                p.EinflussKGB -= 20; // Bloßgestellt
                
                Console.WriteLine("Trump: 'FAKE NEWS! I never said that! It was a joke!'");
                Console.WriteLine("\n⚠️  Whistleblower deckt Kampagne auf! Internationaler Skandal!");
                Console.WriteLine($"🌍 Internationales Ansehen: -50 (jetzt {p.EinflussInternational})");
                Console.WriteLine($"🤝 USA-Beziehung: -40% (jetzt {p.USABeziehung}%)");
                Console.WriteLine($"💰 Geld: -200 Rubel (Sanktionen!)");
                Console.WriteLine($"💻 KGB-Einfluss: -20 (Bloßgestellt!)");
                Console.ResetColor();
            }
        }
        else
        {
            Console.WriteLine("\nTrump: 'Too bad. Could've been tremendous. The best fake news ever!'");
            Console.WriteLine("\n→ Russland lehnt ab. Zu riskant.");
        }
        
        Console.WriteLine("\n[Drücke eine Taste...]");
        Console.ReadKey(true);
    }
}

// ═══════════════════════════════════════════════════════════════════
// NATO-TELEFON EASTER EGG
// ═══════════════════════════════════════════════════════════════════
/// <summary>
/// NATOHotline - Das geheimnisvolle NATO-Telefon
/// 
/// Ein blaues Telefon mit NATO-Symbol klingelt im Kreml.
/// Der NATO-Generalsekretär ruft persönlich an - teils humorvoll, teils ernst!
/// 
/// FEATURES:
/// - 3 Anrufe verfügbar
/// - Meist negative Beziehung zu NATO
/// - Humorvolle aber realistische Dialoge
/// - Wichtige strategische Entscheidungen
/// </summary>
static class NATOHotline
{
    static Random rand = new Random();
    
    public static void CallNATO(PlayerCharacter p)
    {
        if (!p.NATOTelefonAktiv)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n📞 NATO-TELEFON");
            Console.WriteLine("═══════════════════════════════════════════════════════\n");
            Console.ResetColor();
            Console.WriteLine("Das NATO-Telefon ist noch nicht freigeschaltet!");
            Console.WriteLine("\n💡 Tipp: Wird durch spezielle NATO-Events aktiviert.");
            Console.WriteLine("\n[Drücke eine Taste...]");
            Console.ReadKey(true);
            return;
        }
        
        if (p.NATOAnrufeVerfügbar <= 0)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n📞 NATO-TELEFON");
            Console.WriteLine("═══════════════════════════════════════════════════════\n");
            Console.ResetColor();
            Console.WriteLine("Alle Anrufe aufgebraucht!");
            Console.WriteLine("\nDie NATO-Hotline ist derzeit nicht verfügbar...");
            Console.WriteLine("\n[Drücke eine Taste...]");
            Console.ReadKey(true);
            return;
        }
        
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine(@"
        ╔═══════════════════════════════════╗
        ║   📞 NATO-TELEFON 📞             ║
        ║   🛡️ SICHERHEITS-HOTLINE 🛡️       ║
        ╚═══════════════════════════════════╝
        ");
        Console.ResetColor();
        
        Console.WriteLine($"🔋 Verbleibende Anrufe: {p.NATOAnrufeVerfügbar}/3");
        Console.WriteLine($"🤝 NATO-Beziehung: {p.NATOBeziehung}%");
        Console.WriteLine();
        
        Console.WriteLine("[1] 🛡️  Sicherheitsgarantien diskutieren");
        Console.WriteLine("[2] ⚡ Osterweiterung ansprechen");
        Console.WriteLine("[3] 🎯 Schach-Spiel vorschlagen (Humor)");
        Console.WriteLine("[4] 🔙 Zurück");
        Console.Write("\nWähle [1-4]: ");
        
        string choice = Console.ReadLine();
        
        switch (choice)
        {
            case "1":
                SicherheitsGarantien(p);
                break;
            case "2":
                Osterweiterung(p);
                break;
            case "3":
                SchachSpiel(p);
                break;
            case "4":
                return;
        }
        
        p.NATOAnrufeVerfügbar--;
    }
    
    static void SicherheitsGarantien(PlayerCharacter p)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\n🛡️  SICHERHEITSGARANTIEN");
        Console.WriteLine("═══════════════════════════════════════════════════════\n");
        Console.ResetColor();
        
        Console.WriteLine("📞 *Ring Ring*");
        Thread.Sleep(1000);
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\nNATO-Generalsekretär: 'Herr Präsident, guten Tag!'");
        Console.WriteLine("NATO: 'Ich rufe an wegen Ihrer... Bedenken bezüglich unserer Osterweiterung.'");
        Console.WriteLine("NATO: 'Wir können über gegenseitige Sicherheitsgarantien sprechen.'");
        Console.WriteLine("NATO: 'Aber Sie müssen verstehen - jedes Land hat das Recht zu wählen!'");
        Console.ResetColor();
        
        Console.WriteLine("\n[1] Forderungen stellen (Keine Osterweiterung!)");
        Console.WriteLine("[2] Kompromiss suchen (Pufferzone?)");
        Console.WriteLine("[3] Ablehnen (NATO ist Bedrohung!)");
        Console.Write("\nWähle [1-3]: ");
        
        string choice = Console.ReadLine();
        
        Console.Clear();
        
        if (choice == "1")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n⚠️  FORDERUNGEN ABGELEHNT!");
            Console.WriteLine("═══════════════════════════════════════════════════════\n");
            
            Console.WriteLine("NATO: 'Diese Forderungen sind inakzeptabel!'");
            Console.WriteLine("NATO: 'Wir entscheiden gemeinsam als Bündnis!'");
            
            p.NATOBeziehung -= 20;
            p.EinflussMilitär += 15; // Muss sich militärisch stärken
            
            Console.WriteLine($"\n🛡️  NATO-Beziehung: -20% (jetzt {p.NATOBeziehung}%)");
            Console.WriteLine($"⚔️  Militäreinfluss: +15 (Aufrüstung nötig!)");
            Console.ResetColor();
        }
        else if (choice == "2")
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n⚖️  KOMPROMISS-VERSUCH");
            Console.WriteLine("═══════════════════════════════════════════════════════\n");
            
            Console.WriteLine("NATO: 'Interessant... lassen Sie uns darüber sprechen.'");
            Console.WriteLine("NATO: 'Aber keine Garantien. Wir müssen intern beraten.'");
            
            p.NATOBeziehung += 10;
            p.EinflussInternational += 10;
            
            Console.WriteLine($"\n🛡️  NATO-Beziehung: +10% (jetzt {p.NATOBeziehung}%)");
            Console.WriteLine($"🌍 Internationales Ansehen: +10");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n💥 ABLEHNUNG!");
            Console.WriteLine("═══════════════════════════════════════════════════════\n");
            
            Console.WriteLine("NATO: 'Schade. Wir hatten gehofft auf Dialog.'");
            Console.WriteLine("NATO: 'Die Tür bleibt offen... vorerst.'");
            
            p.NATOBeziehung -= 15;
            p.LoyalitätPartei += 20; // Hardliner zufrieden
            
            Console.WriteLine($"\n🛡️  NATO-Beziehung: -15% (jetzt {p.NATOBeziehung}%)");
            Console.WriteLine($"🏛️  Loyalität Partei: +20 (Hardliner zufrieden!)");
            Console.ResetColor();
        }
        
        Console.WriteLine("\n[Drücke eine Taste...]");
        Console.ReadKey(true);
    }
    
    static void Osterweiterung(PlayerCharacter p)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\n⚡ OSTERWEITERUNG");
        Console.WriteLine("═══════════════════════════════════════════════════════\n");
        Console.ResetColor();
        
        Console.WriteLine("📞 *Ring Ring*");
        Thread.Sleep(1000);
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\nNATO: 'Ich wollte Sie informieren - wir diskutieren über neue Mitglieder.'");
        Console.WriteLine("NATO: 'Baltikum, Polen, vielleicht sogar Ukraine in Zukunft...'");
        Console.WriteLine("NATO: 'Sie müssen verstehen - das ist rein defensiv!'");
        Console.ResetColor();
        
        Console.WriteLine("\n[1] Veto androhen (Konsequenzen!)");
        Console.WriteLine("[2] Wirtschaftliche Druckmittel erwähnen");
        Console.WriteLine("[3] Akzeptieren (Pragmatisch)");
        Console.Write("\nWähle [1-3]: ");
        
        string choice = Console.ReadLine();
        
        Console.Clear();
        
        if (choice == "1")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n💀 DROHUNG AUSGESPROCHEN!");
            Console.WriteLine("═══════════════════════════════════════════════════════\n");
            
            Console.WriteLine("NATO: 'Drohungen? Das ist inakzeptabel!'");
            Console.WriteLine("NATO: 'Wir werden die Erweiterung BESCHLEUNIGEN!'");
            
            p.NATOBeziehung -= 30;
            p.EinflussMilitär -= 20; // NATO rüstet auf
            p.EinflussInternational -= 25;
            
            Console.WriteLine($"\n🛡️  NATO-Beziehung: -30% (jetzt {p.NATOBeziehung}%)");
            Console.WriteLine($"⚔️  Militäreinfluss: -20 (NATO rüstet auf!)");
            Console.WriteLine($"🌍 Internationales Ansehen: -25");
            Console.ResetColor();
        }
        else if (choice == "2")
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n💰 WIRTSCHAFTSDRUCK");
            Console.WriteLine("═══════════════════════════════════════════════════════\n");
            
            Console.WriteLine("NATO: 'Gas und Öl? Wir diversifizieren bereits unsere Quellen.'");
            Console.WriteLine("NATO: 'Diese Taktik wird nicht funktionieren.'");
            
            p.NATOBeziehung -= 15;
            p.Geld += 100; // Kurzfristiger Gewinn
            
            Console.WriteLine($"\n🛡️  NATO-Beziehung: -15% (jetzt {p.NATOBeziehung}%)");
            Console.WriteLine($"💰 Geld: +100 Rubel (kurzfristig)");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n✓ PRAGMATISCHE AKZEPTANZ");
            Console.WriteLine("═══════════════════════════════════════════════════════\n");
            
            Console.WriteLine("NATO: 'Vielen Dank für Ihr Verständnis!'");
            Console.WriteLine("NATO: 'Vielleicht können wir eine Partnerschaft aufbauen?'");
            
            p.NATOBeziehung += 25;
            p.LoyalitätPartei -= 30; // Hardliner verärgert!
            p.EinflussInternational += 20;
            
            Console.WriteLine($"\n🛡️  NATO-Beziehung: +25% (jetzt {p.NATOBeziehung}%)");
            Console.WriteLine($"🌍 Internationales Ansehen: +20");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"⚠️  Loyalität Partei: -30 (Hardliner wütend!)");
            Console.ResetColor();
        }
        
        Console.WriteLine("\n[Drücke eine Taste...]");
        Console.ReadKey(true);
    }
    
    static void SchachSpiel(PlayerCharacter p)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\n🎯 SCHACH-SPIEL VORSCHLAG");
        Console.WriteLine("═══════════════════════════════════════════════════════\n");
        Console.ResetColor();
        
        Console.WriteLine("📞 *Ring Ring*");
        Thread.Sleep(1000);
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\nNATO: 'Herr Präsident! Ich habe eine... ungewöhnliche Idee.'");
        Console.WriteLine("NATO: 'Wie wäre es mit einer Partie Schach? Strategen unter sich!'");
        Console.WriteLine("NATO: 'Ich habe hier eine Karte unserer Stellungen... wäre das nicht interessant?'");
        Console.WriteLine("NATO: 'Und wissen Sie - bei uns im Baltikum stellen sie jetzt Matroschkas mit NATO-Logo her!'");
        Console.ResetColor();
        
        Console.WriteLine("\n[1] Annehmen ('Die russische Dame ist stärker!')");
        Console.WriteLine("[2] Ablehnen ('Keine Kinderspiele!')");
        Console.WriteLine("[3] Gegenvorschlag ('Reden wir über Gasverträge')");
        Console.Write("\nWähle [1-3]: ");
        
        string choice = Console.ReadLine();
        
        Console.Clear();
        
        if (choice == "1")
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n♟️  SCHACH-PARTIE!");
            Console.WriteLine("═══════════════════════════════════════════════════════\n");
            
            Console.WriteLine("NATO: 'Ausgezeichnet! Sehen Sie sich diese Karte an...'");
            Thread.Sleep(1500);
            Console.WriteLine("\n🗺️  Du erhältst geheime NATO-Stellungsinformationen!");
            
            p.NATOBeziehung += 15;
            p.EinflussKGB += 30; // Spionage-Erfolg!
            p.Intelligenz += 1;
            
            Console.WriteLine($"\n🛡️  NATO-Beziehung: +15% (jetzt {p.NATOBeziehung}%)");
            Console.WriteLine($"💻 KGB-Einfluss: +30 (Aufklärung!)");
            Console.WriteLine($"🧠 Intelligenz: +1");
            Console.ResetColor();
        }
        else if (choice == "2")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n❌ ABGELEHNT!");
            Console.WriteLine("═══════════════════════════════════════════════════════\n");
            
            Console.WriteLine("NATO: 'Schade... ich dachte, Sie schätzen strategisches Denken.'");
            
            p.NATOBeziehung -= 10;
            p.EinflussMilitär += 10; // Fokus auf Militär
            
            Console.WriteLine($"\n🛡️  NATO-Beziehung: -10% (jetzt {p.NATOBeziehung}%)");
            Console.WriteLine($"⚔️  Militäreinfluss: +10");
            Console.ResetColor();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n💼 GESCHÄFTLICH!");
            Console.WriteLine("═══════════════════════════════════════════════════════\n");
            
            Console.WriteLine("NATO: 'Ah, Gasverträge! Immer pragmatisch, wie ich sehe.'");
            Console.WriteLine("NATO: 'Lassen Sie uns darüber sprechen...'");
            
            p.NATOBeziehung += 10;
            p.Geld += 250; // Gasvertrag
            
            Console.WriteLine($"\n🛡️  NATO-Beziehung: +10% (jetzt {p.NATOBeziehung}%)");
            Console.WriteLine($"💰 Geld: +250 Rubel (Gasvertrag!)");
            Console.ResetColor();
        }
        
        Console.WriteLine("\n[Drücke eine Taste...]");
        Console.ReadKey(true);
    }
}
