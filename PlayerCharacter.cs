using System;
using System.Collections.Generic;

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
/// - Sidechick-System (Affären und versteckte Kinder)
/// </summary>
public class PlayerCharacter
{
    // ═══ BASIS-INFORMATIONEN ═══
    public string Name;              // Voller Name des Charakters
    public int Alter;                // Aktuelles Alter in Jahren
    public int Geburtsjahr;          // Jahr der Geburt (z.B. 1952)
    public int Generation;           // Generationsnummer (1 = Gründer, 2 = Kinder, etc.)
    public string Phase;             // Aktuelle Lebensphase (Kindheit, KGB, Studium, DDR, Präsident)
    
    // ═══ ATTRIBUTE (Spieler-Fähigkeiten) ═══
    public int Stärke;              // Körperliche Kraft, wichtig für Kämpfe
    public int Intelligenz;         // Klugheit, wichtig für Spionage und Politik
    public int Charisma;            // Überzeugungskraft, wichtig für Führung
    public int Kraft;               // Ausdauer und Widerstandsfähigkeit
    
    // ═══ RESSOURCEN ═══
    public int Geld;                // Finanzielle Mittel in Rubel
    public int Gesundheit;          // Gesundheitszustand 0-100% (0 = Tod)
    
    // ═══ LOYALITÄT (0-100%) ═══
    public int LoyalitätPartei;     // Loyalität zur kommunistischen Partei
    public int LoyalitätVolk;       // Unterstützung durch die Bevölkerung
    public int LoyalitätFamilie;    // Familiäre Bindungen und Treue
    
    // ═══ EINFLUSS (0-100%) ═══
    public int EinflussKGB;         // Macht im Geheimdienst/Sicherheitsapparat
    public int EinflussMilitär;     // Einfluss beim Militär
    public int EinflussInternational; // Ansehen und Macht im Ausland
    
    // ═══ BESONDERE FLAGS ═══
    public bool KGBEasterEgg;       // TRUE wenn das geheime KGB-Event aktiviert wurde
    public bool GeheimeAusbildung;  // TRUE wenn geheime KGB-Ausbildung absolviert
    
    // ═══ HOCHZEITS-SYSTEM ═══
    public bool IstVerheiratet;     // TRUE wenn verheiratet
    public string EhepartnerName;   // Name der Ehefrau/des Ehemanns
    public int GeburtenBonus;       // Geburtenrate 1-5 (höher = mehr Kinder)
    public int FinanzBonus;         // Geld-Bonus bei Heirat
    
    // ═══ FAMILIEN-SYSTEM ═══
    public List<PlayerCharacter> Kinder;  // Liste aller Kinder (für Stammbaum)
    public bool IstTot;             // TRUE wenn Charakter verstorben
    
    // ═══ TELEFON-SYSTEME ═══
    public bool TrumpTelefonAktiv;       // Trump-Hotline
    public int TrumpAnrufeVerfügbar;     
    public int USABeziehung;             
    
    public int ErdoganAnrufeVerfügbar;   
    public int ErdoganSchulden;          
    public bool ErdoganVermittlungAktiv; 
    public int TürkeiBeziehung;          
    
    public bool ChinaTelefonAktiv;       
    public int ChinaAnrufeVerfügbar;     
    public int ChinaBeziehung;           
    
    // ═══ GEBURTEN-COOLDOWN ═══
    public int LetzteGeburtJahr;         // Jahr der letzten Geburt
    
    // ═══ SHOP-SYSTEM ═══
    public List<ShopItem> Besitztümer;   // Gekaufte Luxusgegenstände
    
    // ═══ SIDECHICK-SYSTEM ═══
    public class UnanerkanntesSidechickKind
    {
        public string MutterName;        // Name der Mutter
        public int GeburtsjahR;          // Jahr der Geburt
        public bool IstJunge;            // Geschlecht
        public int Staerke;              // Attribute des Kindes
        public int Intelligenz;
        public int Charisma;
        public int Kraft;
        public int DatumKosten;          // Wie viel wurde für das Date ausgegeben
    }
    
    public List<UnanerkanntesSidechickKind> VersteckteKinder;  // Unanerkannte Kinder
    public int LetztesSidechickJahr;  // Jahr des letzten Sidechick-Events
    
    /// <summary>
    /// Konstruktor - Erstellt einen neuen Charakter
    /// </summary>
    public PlayerCharacter(string name, int generation)
    {
        Name = name;
        Generation = generation;
        Geburtsjahr = generation == 1 ? 1952 : 0;
        
        // Standard-Werte beim Start
        Gesundheit = 100;
        Geld = 0;
        LoyalitätPartei = 50;
        LoyalitätVolk = 50;
        LoyalitätFamilie = 80;
        Phase = "Geburt";
        
        // Listen initialisieren
        Kinder = new List<PlayerCharacter>();
        IstVerheiratet = false;
        IstTot = false;
        GeburtenBonus = 0;
        FinanzBonus = 0;
        
        // Telefone initialisieren
        ErdoganAnrufeVerfügbar = 5;
        ErdoganSchulden = 0;
        ErdoganVermittlungAktiv = false;
        TürkeiBeziehung = 50;
        
        TrumpTelefonAktiv = false;
        TrumpAnrufeVerfügbar = 3;
        USABeziehung = 50;
        
        ChinaTelefonAktiv = false;
        ChinaAnrufeVerfügbar = 3;
        ChinaBeziehung = 70;
        
        // Sonstiges
        LetzteGeburtJahr = 0;
        Besitztümer = new List<ShopItem>();
        
        // Sidechick-System initialisieren
        VersteckteKinder = new List<UnanerkanntesSidechickKind>();
        LetztesSidechickJahr = 0;
    }
    
    /// <summary>
    /// GetCurrentYear - Berechnet das aktuelle Spieljahr
    /// </summary>
    public int GetCurrentYear()
    {
        return Geburtsjahr + Alter;
    }
    
    /// <summary>
    /// GetFirstName - Extrahiert Vornamen aus vollem Namen
    /// </summary>
    public string GetFirstName()
    {
        if (string.IsNullOrEmpty(Name)) return "Spieler";
        string[] parts = Name.Split(new char[] { ' ' });
        return parts[0];
    }
}

/// <summary>
/// GameSave - Speicherstand-Klasse
/// </summary>
public class GameSave
{
    public string SaveName;          // Vom Spieler vergebener Name
    public DateTime SaveDate;        // Zeitstempel der Speicherung
    public PlayerCharacter Character; // Kompletter Charakterzustand
    public int Generation;           // Generationsnummer für Übersicht
    
    public GameSave(string name, PlayerCharacter character)
    {
        SaveName = name;
        SaveDate = DateTime.Now;
        Character = character;
        Generation = character.Generation;
    }
}

/// <summary>
/// ShopItem - Luxusgegenstand im Putin-Shop
/// </summary>
public class ShopItem
{
    public string Name;
    public string Icon;
    public int Preis;
    public int StärkeBonus;
    public int IntelligenzBonus;
    public int CharismaBonus;
    public int LoyalitätBonus;
    public int EinflussBonus;
    public string Beschreibung;
    
    public ShopItem(string name, string icon, int preis, int str, int int_, int cha, int loy, int einf, string desc)
    {
        Name = name;
        Icon = icon;
        Preis = preis;
        StärkeBonus = str;
        IntelligenzBonus = int_;
        CharismaBonus = cha;
        LoyalitätBonus = loy;
        EinflussBonus = einf;
        Beschreibung = desc;
    }
}

/// <summary>
/// WifeOption - Heiratsfähige Frau/Mann
/// </summary>
public class WifeOption
{
    public string Name;
    public int GeburtenRate;    // 1-5 (höher = mehr Kinder)
    public int GeldBonus;       // Rubel bei Heirat
    public int LoyalitätBonus;  // % auf Familie-Loyalität
    public string Beschreibung;
    
    public WifeOption(string name, int rate, int geld, int loy, string desc)
    {
        Name = name;
        GeburtenRate = rate;
        GeldBonus = geld;
        LoyalitätBonus = loy;
        Beschreibung = desc;
    }
}