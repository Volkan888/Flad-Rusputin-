using System;
using System.Threading;

// Erdogan-Hotline
static class ErdoganHotline
{
    static Random rand = new Random();
    
    public static void ShowHotlineMenu(PlayerCharacter p)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(@"
        ╔════════════════════════════════════════════╗
        ║   📞 ERDOGAN-NOTTELEFON 📞                ║
        ╚════════════════════════════════════════════╝
        ");
        Console.ResetColor();
        
        if (p.ErdoganAnrufeVerfügbar <= 0)
        {
            Console.WriteLine("Keine Anrufe mehr verfügbar!");
            Console.ReadKey(true);
            return;
        }
        
        Console.WriteLine($"Anrufe verfügbar: {p.ErdoganAnrufeVerfügbar}/5\n");
        Console.WriteLine("[1] TurkStream-Pipeline");
        Console.WriteLine("[2] Akkuyu-AKW Investition");
        Console.WriteLine("[3] S-400 Raketenverkauf");
        Console.WriteLine("[4] Zurück");
        Console.Write("\nWähle [1-4]: ");
        
        string choice = Console.ReadLine();
        switch(choice)
        {
            case "1": TurkStreamPipeline(p); break;
            case "2": AkkuyuInvestition(p); break;
            case "3": S400Verkauf(p); break;
            case "4": return;
        }
        p.ErdoganAnrufeVerfügbar--;
    }
    
    static void TurkStreamPipeline(PlayerCharacter p)
    {
        Console.Clear();
        Console.WriteLine("\n⛽ TurkStream-Pipeline Deal!");
        p.Geld += 250;
        p.TürkeiBeziehung += 20;
        p.EinflussInternational += 15;
        Console.WriteLine("✓ Pipeline-Vereinbarung unterzeichnet!");
        Console.WriteLine($"💰 +250 Rubel | 🤝 Türkei: +20%");
        Console.ReadKey(true);
    }
    
    static void AkkuyuInvestition(PlayerCharacter p)
    {
        Console.Clear();
        Console.WriteLine("\n☢️ Akkuyu-AKW Investition!");
        p.Geld -= 150;
        p.TürkeiBeziehung += 25;
        p.EinflussMilitär += 20;
        Console.WriteLine("✓ AKW-Bau beginnt!");
        Console.WriteLine($"💰 -150 Rubel | 🤝 Türkei: +25%");
        Console.ReadKey(true);
    }
    
    static void S400Verkauf(PlayerCharacter p)
    {
        Console.Clear();
        Console.WriteLine("\n🚀 S-400 Raketenverkauf!");
        p.Geld += 300;
        p.TürkeiBeziehung += 30;
        p.EinflussMilitär += 25;
        Console.WriteLine("✓ S-400 System an Türkei verkauft!");
        Console.WriteLine($"💰 +300 Rubel | ⚔️ Militär: +25");
        Console.ReadKey(true);
    }
}

// Trump-Hotline
static class TrumpHotline
{
    static Random rand = new Random();
    
    public static void CallTrump(PlayerCharacter p)
    {
        if (!p.TrumpTelefonAktiv || p.TrumpAnrufeVerfügbar <= 0)
        {
            Console.WriteLine("Trump-Telefon nicht verfügbar!");
            Console.ReadKey(true);
            return;
        }
        
        Console.Clear();
        Console.WriteLine("\n📞 TRUMP-TELEFON\n");
        Console.WriteLine($"Anrufe: {p.TrumpAnrufeVerfügbar}/3\n");
        Console.WriteLine("[1] Deal-Making");
        Console.WriteLine("[2] NATO diskutieren");
        Console.WriteLine("[3] Fake News");
        Console.WriteLine("[4] Zurück");
        Console.Write("\nWähle [1-4]: ");
        
        string choice = Console.ReadLine();
        switch(choice)
        {
            case "1": DealMaking(p); break;
            case "2": NATODiskussion(p); break;
            case "3": FakeNews(p); break;
            case "4": return;
        }
        p.TrumpAnrufeVerfügbar--;
    }
    
    static void DealMaking(PlayerCharacter p)
    {
        Console.Clear();
        Console.WriteLine("\n💰 DEAL mit Trump!");
        p.Geld += 300;
        p.USABeziehung += 25;
        Console.WriteLine("✓ Deal gemacht!");
        Console.WriteLine($"💰 +300 Rubel | 🤝 USA: +25%");
        Console.ReadKey(true);
    }
    
    static void NATODiskussion(PlayerCharacter p)
    {
        Console.Clear();
        Console.WriteLine("\n🛡️ NATO-Diskussion!");
        p.NATOBeziehung += 20;
        p.EinflussMilitär += 15;
        Console.WriteLine("✓ NATO-Erweiterung verlangsamt!");
        Console.WriteLine($"🛡️ NATO: +20% | ⚔️ Militär: +15");
        Console.ReadKey(true);
    }
    
    static void FakeNews(PlayerCharacter p)
    {
        Console.Clear();
        Console.WriteLine("\n📰 Fake News Kampagne!");
        if (rand.Next(100) < 60)
        {
            Console.WriteLine("⚠️ AUFGEFLOGEN!");
            p.EinflussInternational -= 50;
            p.Geld -= 200;
            Console.WriteLine($"🌍 International: -50 | 💰 -200 Rubel");
        }
        else
        {
            Console.WriteLine("✓ Erfolgreich!");
            p.EinflussKGB += 35;
            Console.WriteLine($"💻 KGB: +35");
        }
        Console.ReadKey(true);
    }
}

// NATO-Hotline
static class NATOHotline
{
    static Random rand = new Random();
    
    public static void CallNATO(PlayerCharacter p)
    {
        if (!p.NATOTelefonAktiv || p.NATOAnrufeVerfügbar <= 0)
        {
            Console.WriteLine("NATO-Telefon nicht verfügbar!");
            Console.ReadKey(true);
            return;
        }
        
        Console.Clear();
        Console.WriteLine("\n📞 NATO-TELEFON\n");
        Console.WriteLine($"Anrufe: {p.NATOAnrufeVerfügbar}/3\n");
        Console.WriteLine("[1] Sicherheitsgarantien");
        Console.WriteLine("[2] Osterweiterung");
        Console.WriteLine("[3] Schach-Spiel");
        Console.WriteLine("[4] Zurück");
        Console.Write("\nWähle [1-4]: ");
        
        string choice = Console.ReadLine();
        switch(choice)
        {
            case "1": Sicherheit(p); break;
            case "2": Osterweiterung(p); break;
            case "3": Schach(p); break;
            case "4": return;
        }
        p.NATOAnrufeVerfügbar--;
    }
    
    static void Sicherheit(PlayerCharacter p)
    {
        Console.Clear();
        Console.WriteLine("\n🛡️ Sicherheitsgarantien!");
        p.NATOBeziehung += 10;
        p.EinflussInternational += 10;
        Console.WriteLine("✓ Kompromiss gefunden!");
        Console.WriteLine($"🛡️ NATO: +10% | 🌍 International: +10");
        Console.ReadKey(true);
    }
    
    static void Osterweiterung(PlayerCharacter p)
    {
        Console.Clear();
        Console.WriteLine("\n⚡ NATO-Osterweiterung diskutiert!");
        p.NATOBeziehung -= 15;
        p.Geld += 100;
        Console.WriteLine("⚠️ Wirtschaftsdruck angedroht!");
        Console.WriteLine($"🛡️ NATO: -15% | 💰 +100 Rubel");
        Console.ReadKey(true);
    }
    
    static void Schach(PlayerCharacter p)
    {
        Console.Clear();
        Console.WriteLine("\n♟️ Schach-Partie!");
        p.NATOBeziehung += 15;
        p.EinflussKGB += 30;
        p.Intelligenz += 1;
        Console.WriteLine("✓ Aufklärung erfolgreich!");
        Console.WriteLine($"🛡️ NATO: +15% | 💻 KGB: +30 | 🧠 +1 Int");
        Console.ReadKey(true);
    }
}

// China-Hotline
static class ChinaHotline
{
    static Random rand = new Random();
    
    public static void CallChina(PlayerCharacter p)
    {
        if (!p.ChinaTelefonAktiv || p.ChinaAnrufeVerfügbar <= 0)
        {
            Console.WriteLine("China-Telefon nicht verfügbar!");
            Console.ReadKey(true);
            return;
        }
        
        Console.Clear();
        Console.WriteLine("\n📞 CHINA-TELEFON 🐉\n");
        Console.WriteLine($"Anrufe: {p.ChinaAnrufeVerfügbar}/3\n");
        Console.WriteLine("[1] 'Hallo, guter Freund!' (Diplomatisch)");
        Console.WriteLine("[2] 'Was soll der Anruf?' (Überrascht)");
        Console.WriteLine("[3] 'Panda-Freunde!' (Krawallstour)");
        Console.WriteLine("[4] Zurück");
        Console.Write("\nWähle [1-4]: ");
        
        string choice = Console.ReadLine();
        switch(choice)
        {
            case "1": GuterFreund(p); break;
            case "2": Ueberrascht(p); break;
            case "3": Krawallstour(p); break;
            case "4": return;
        }
        p.ChinaAnrufeVerfügbar--;
    }
    
    static void GuterFreund(PlayerCharacter p)
    {
        Console.Clear();
        Console.WriteLine("\n🐉 'Hallo, guter Freund!'");
        Console.WriteLine("\nXi: '同志! Sibirien-Rohstoffe?'");
        p.Geld += 400;
        p.ChinaBeziehung += 20;
        Console.WriteLine("\n✓ Handelsabkommen!");
        Console.WriteLine($"💰 +400 Rubel | 🤝 China: +20%");
        Console.ReadKey(true);
    }
    
    static void Ueberrascht(PlayerCharacter p)
    {
        Console.Clear();
        Console.WriteLine("\n🤷 'Was soll der Anruf?'");
        Console.WriteLine("\nXi: '10.000 Tonnen Reis für Sie!'");
        p.Geld += 100;
        p.ChinaBeziehung += 10;
        Console.WriteLine("\n✓ Reis angenommen!");
        Console.WriteLine($"💰 +100 Rubel | 🤝 China: +10%");
        Console.ReadKey(true);
    }
    
    static void Krawallstour(PlayerCharacter p)
    {
        Console.Clear();
        Console.WriteLine("\n🐼 'Panda-Freunde!'");
        Console.WriteLine("\n'Ni hao! Pekingente-Eier!'");
        Thread.Sleep(1500);
        Console.WriteLine("\n💥 DIPLOMATISCHER EKLAT!");
        p.ChinaBeziehung -= 40;
        p.Geld -= 300;
        p.EinflussInternational -= 20;
        Console.WriteLine($"\n🤝 China: -40% | 💰 -300 Rubel");
        Console.WriteLine("⚠️ Handelsembargo für 5 Jahre!");
        Console.ReadKey(true);
    }
}
