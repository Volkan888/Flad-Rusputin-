/*
 * ════════════════════════════════════════════════════════════════════════════════
 * PROJEKT: Rise of the Northborn – Flad Rusputin Saga
 * ════════════════════════════════════════════════════════════════════════════════
 * 
 * BESCHREIBUNG:
 * Ein textbasiertes Rollenspiel in C#, das die fiktive Geschichte von Flad Rusputin
 * erzählt - vom Straßenkind bis zum Präsidenten einer dystopischen sowjetischen Nation.
 * 
 * ════════════════════════════════════════════════════════════════════════════════
 * 📖 SPIELANLEITUNG - HAUPTSPIEL
 * ════════════════════════════════════════════════════════════════════════════════
 * 
 * SPIELZIEL:
 * -----------
 * Führe Flad Rusputin von der Kindheit bis zur Präsidentschaft und darüber hinaus.
 * Baue eine mächtige Dynastie auf, die über mehrere Generationen fortbesteht.
 * 
 * SPIELSTART:
 * -----------
 * 1. Wähle einen Schwierigkeitsgrad (Leicht/Normal/Schwer)
 * 2. Verteile Attributspunkte auf: Stärke, Intelligenz, Charisma, Kraft
 * 3. Beginne deine Geschichte in der Kindheit
 * 
 * DIE 5 LEBENSPHASEN:
 * -------------------
 * 
 * 1. KINDHEIT (Alter 10-15)
 *    - Überlebe auf den Straßen
 *    - Erste Entscheidungen prägen deinen Charakter
 *    - Zufallsereignisse: Bruder-Verlust, Raufereien, Jungpioniere
 * 
 * 2. KGB-PHASE (Alter 15-18)
 *    - Rekrutierung durch den Geheimdienst
 *    - Lerne Loyalität und Misstrauen
 *    - Wichtige Wahl: Freunde decken oder verraten?
 * 
 * 3. JURASTUDIUM (Alter 18-25)
 *    - Ausbildung an der Geheimdienstakademie
 *    - Events: Erbe, Judo-Training, Drill & Disziplin
 *    - Erste Einfluss-Aufbau-Möglichkeiten
 * 
 * 4. DDR-EINSATZ (Alter 25-35)
 *    - Auslandseinsatz in Ost-Berlin
 *    - Kritische diplomatische Entscheidungen
 *    - Aufbau von internationalem Einfluss
 * 
 * 5. PRÄSIDENT (Alter 35+)
 *    - Höhepunkt der Karriere
 *    - Hochzeit und Familiengründung
 *    - Regierungsstil-Wahl am Ende
 *    - Optionen nach Amtszeit: Ruhestand, Nachfolger, oder Speichern
 * 
 * WICHTIGE SPIELSYSTEME:
 * ----------------------
 * 
 * ► ATTRIBUTE (0-10):
 *   • Stärke: Wichtig für Kämpfe, militärische Aktionen
 *   • Intelligenz: Entscheidend für Spionage, Intrigen, Politik
 *   • Charisma: Beeinflusst Führung, Diplomatie, Volksgunst
 *   • Kraft: Gesundheits-Puffer, Durchhaltevermögen
 * 
 * ► RESSOURCEN:
 *   • Geld: Für Bestechungen und Investitionen (Start: 0 Rubel)
 *   • Gesundheit: 0-100% (Bei 0% → Tod)
 * 
 * ► LOYALITÄTEN (0-100%):
 *   • Partei: Unterstützung der kommunistischen Partei
 *   • Volk: Popularität bei der Bevölkerung
 *   • Familie: Familiäre Bindungen
 * 
 * ► EINFLUSS (0-100%):
 *   • KGB: Macht im Geheimdienst
 *   • Militär: Einfluss bei den Streitkräften
 *   • International: Ansehen im Ausland
 * 
 * HOCHZEITS-SYSTEM:
 * -----------------
 * In der Präsidenten-Phase kannst du heiraten. 5 Optionen verfügbar:
 * 
 * │ Name      │ Kinderrate │ Geld-Bonus │ Strategie                    │
 * ├───────────┼────────────┼────────────┼──────────────────────────────┤
 * │ Natasha   │ ★☆☆☆☆ 15% │ +300 Rubel │ Reich, wenig Erben (riskant) │
 * │ Olga      │ ★★☆☆☆ 30% │ +200 Rubel │ Ausgewogen                   │
 * │ Svetlana  │ ★★★☆☆ 45% │ +100 Rubel │ Mittelweg                    │
 * │ Irina     │ ★★★★☆ 60% │ +50 Rubel  │ Viele Kinder                 │
 * │ Katya     │ ★★★★★ 75% │ +0 Rubel   │ Maximum Kinder (sicher)      │
 * 
 * TIPP: Mehr Kinder = Mehr Erben bei Tod = Sicherheit für die Dynastie!
 * 
 * GEBURTEN-SYSTEM:
 * ----------------
 * - Geburten erfolgen zufällig über 10 Regierungsjahre
 * - Nur alle 2 Jahre möglich (realistisch)
 * - Maximal 8 Kinder
 * - Zwillinge (5%) und Drillinge (1%) möglich
 * - Du gibst jedem Kind einen Namen
 * - Attribute werden mit Variation vererbt (Elternwert ±1-2)
 * 
 * TOD UND NACHFOLGE:
 * ------------------
 * Dein Charakter kann sterben durch:
 * 1. Gesundheit sinkt auf 0% (Ereignisse, Kämpfe)
 * 2. Altersschwäche ab 65 Jahren (progressives Risiko)
 * 
 * Bei Tod MIT Kindern:
 * → Wähle einen Erben aus deinen Kindern
 * → Erbe erbt 50% Geld, 33% Einfluss, 50% Loyalität
 * → Erbe startet mit 25 Jahren im Jurastudium
 * → SPIEL GEHT WEITER!
 * 
 * Bei Tod OHNE Kinder:
 * → GAME OVER
 * → Dynastie endet
 * 
 * ZUFALLSEREIGNISSE:
 * ------------------
 * 20+ dynamische Events können jederzeit auftreten:
 * - Passive Events: Automatische Effekte auf Attribute
 * - Interaktive Events: Du musst eine Wahl treffen
 * - Attribut-abhängige Events: Erfolg hängt von deinen Werten ab
 * - Erfolg/Misserfolg-Events: Zufälliges Ergebnis
 * 
 * SPEICHERN/LADEN:
 * ----------------
 * - 5 Speicherslots verfügbar
 * - Vergib eigene Namen für deine Spielstände
 * - Datum/Uhrzeit wird automatisch gespeichert
 * - Jederzeit speicherbar über Hauptmenü oder nach Phasen
 * 
 * STAMMBAUM:
 * ----------
 * - Zeigt alle Generationen deiner Dynastie
 * - Sehe alle Kinder und ihre Attribute
 * - Übersicht über lebende und verstorbene Charaktere
 * - Zugriff über Hauptmenü [3]
 * 
 * ════════════════════════════════════════════════════════════════════════════════
 * 📖 SPIELANLEITUNG - MINI-GAME: SCHIFFE VERSENKEN
 * ════════════════════════════════════════════════════════════════════════════════
 * 
 * SPIELMODI:
 * ----------
 * 1. Spieler vs Computer (KI mit Zufalls-Angriffen)
 * 2. Spieler vs Spieler (Hotseat-Modus, abwechselnd am PC)
 * 
 * SPIELREGELN:
 * ------------
 * 1. Wähle Feldgröße: Klein (6x6) oder Groß (8x8)
 * 2. Platziere deine Schiffe:
 *    - Klein: 3 Schiffe (Größe 4, 3, 2)
 *    - Groß: 4 Schiffe (Größe 5, 4, 3, 2)
 * 3. Abwechselnd angreifen:
 *    - Gib Koordinate ein (z.B. "B3")
 *    - Bei TREFFER: Nochmal dran
 *    - Bei FEHLSCHUSS: Gegner ist dran
 * 4. Gewinner: Wer alle gegnerischen Schiffe versenkt
 * 
 * SPIELFELD-ZEICHEN:
 * ------------------
 * ~ = Wasser (unberührt)
 * ■ = Dein Schiff (nur auf eigenem Feld sichtbar)
 * X = Treffer (rot)
 * O = Fehlschuss (blau)
 * 
 * STEUERUNG:
 * ----------
 * - Position: Buchstabe + Zahl (A1, B3, C5, etc.)
 * - Richtung: [H] für Horizontal, [V] für Vertikal
 * - Bei Angriffen: Koordinate eingeben (z.B. "D4")
 * 
 * ════════════════════════════════════════════════════════════════════════════════
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
 * ZEILEN CODE: ~2450
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
    public int Geburtsjahr;          // Jahr der Geburt (z.B. 1952)
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
    
    // ═══ ERDOGAN-NOTTELEFON (NEUE FEATURE) ═══
    public int ErdoganAnrufeVerfügbar;   // Anzahl verbleibender Notrufe (max 5)
    public int ErdoganSchulden;          // Geliehenes Geld von Türkei (muss zurückgezahlt werden)
    public bool ErdoganVermittlungAktiv; // TRUE wenn diplomatische Vermittlung läuft
    public int TürkeiBeziehung;          // Beziehungswert zu Türkei (0-100)
    
    // ═══ GEBURTEN-COOLDOWN (NEUE FEATURE) ═══
    public int LetzteGeburtJahr;         // Jahr der letzten Geburt (für 3-Jahres-Sperre)
    
    // ═══ PUTIN-LUXUS-SHOP (NEUE FEATURE) ═══
    public List<ShopItem> Besitztümer;   // Gekaufte Luxusgegenstände (Autos, Pferde, etc.)
    
    // ═══ TRUMP-TELEFON EASTER EGG ═══
    public bool TrumpTelefonAktiv;       // TRUE wenn Trump-Telefon freigeschaltet
    public int TrumpAnrufeVerfügbar;     // Anzahl verbleibender Anrufe (max 3)
    public int USABeziehung;             // Beziehungswert zu USA (0-100)
    
    // ═══ NATO-TELEFON EASTER EGG ═══
    public bool NATOTelefonAktiv;        // TRUE wenn NATO-Telefon freigeschaltet
    public int NATOAnrufeVerfügbar;      // Anzahl verbleibender Anrufe (max 3)
    public int NATOBeziehung;            // Beziehungswert zu NATO (0-100, meist negativ)
    
    // ═══ FINKA-SYSTEM ═══
    public bool HatFinka;                // TRUE wenn Finka gekauft
    public int LetzterFinkabesuch;       // Jahr des letzten Finka-Besuchs
    public int FinkaKosten;              // Kaufpreis der Finka
    
    // ═══ SHORTCUT-MENÜ TIMER ═══
    public int LetzteShortcutAnzeige;    // Alter bei letzter Shortcut-Menü-Anzeige
    
    /// <summary>
    /// Konstruktor - Erstellt einen neuen Charakter
    /// </summary>
    /// <param name="name">Vollständiger Name</param>
    /// <param name="generation">Generationsnummer (1, 2, 3...)</param>
    public PlayerCharacter(string name, int generation)
    {
        Name = name;
        Generation = generation;
        Geburtsjahr = generation == 1 ? 1952 : 0;  // Gen 1 = 1952, Rest wird bei Geburt gesetzt
        
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
        
        // Erdogan-Nottelefon initialisieren
        ErdoganAnrufeVerfügbar = 5;      // 5 Anrufe pro Spiel
        ErdoganSchulden = 0;              // Keine Schulden zu Beginn
        ErdoganVermittlungAktiv = false;
        TürkeiBeziehung = 50;             // Neutrale Beziehung
        
        // Geburten-Cooldown initialisieren
        LetzteGeburtJahr = 0;             // Keine vorherige Geburt
        
        // Putin-Shop initialisieren
        Besitztümer = new List<ShopItem>();
        
        // Trump-Telefon initialisieren
        TrumpTelefonAktiv = false;        // Wird durch Event freigeschaltet
        TrumpAnrufeVerfügbar = 3;         // 3 Anrufe mit Trump
        USABeziehung = 50;                // Neutrale Beziehung
        
        // NATO-Telefon initialisieren
        NATOTelefonAktiv = false;         // Wird durch Event freigeschaltet
        NATOAnrufeVerfügbar = 3;          // 3 Anrufe mit NATO
        NATOBeziehung = 30;               // Angespannte Beziehung
        
        // Finka-System initialisieren
        HatFinka = false;                 // Keine Finka zu Beginn
        LetzterFinkabesuch = 0;
        FinkaKosten = 800;                // Teuer!
        
        // Shortcut-Timer initialisieren
        LetzteShortcutAnzeige = 0;
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
        return Name.Split(' ')[0];
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
/// <summary>
/// RandomEvent - Zufallsereignis mit chronologischer Steuerung
/// 
/// ÄNDERUNG 11: Jahr-basierte Events für historische Genauigkeit
/// - Events können jetzt an spezifische Jahre gebunden werden
/// - Jahr = 0 bedeutet: Kann in jeder Phase auftreten (klassisches Event)
/// - Jahr > 0 bedeutet: Tritt nur in diesem spezifischen Jahr auf
/// </summary>
class RandomEvent
{
    public string Name;              // Bezeichnung des Ereignisses
    public string Description;       // Beschreibung was passiert
    public string Phase;             // In welcher Lebensphase tritt es auf?
    public int Chance;               // Wahrscheinlichkeit 0-100%
    public int Jahr;                 // Spezifisches Jahr (0 = jederzeit in Phase)
    public string Type;              // "normal", "sidechick", "historisch", "fiktiv"
    
    public Action<PlayerCharacter> Apply;  // Lambda-Funktion die die Effekte ausführt
    
    /// <summary>
    /// Konstruktor - Erstellt klassisches Zufallsereignis (ohne Jahr)
    /// </summary>
    public RandomEvent(string name, string desc, string phase, int chance, Action<PlayerCharacter> apply)
    {
        Name = name;
        Description = desc;
        Phase = phase;
        Chance = chance;
        Jahr = 0;  // Jederzeit möglich
        Type = "normal";
        Apply = apply;
    }
    
    /// <summary>
    /// Konstruktor - Erstellt jahr-spezifisches Ereignis
    /// </summary>
    public RandomEvent(string name, string desc, string phase, int chance, int jahr, string type, Action<PlayerCharacter> apply)
    {
        Name = name;
        Description = desc;
        Phase = phase;
        Chance = chance;
        Jahr = jahr;
        Type = type;
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
/// ShopItem - Repräsentiert einen Luxusgegenstand im Putin-Shop
/// </summary>
class ShopItem
{
    public string Name;              // Name des Gegenstands
    public string Icon;              // Emoji/Symbol
    public int Preis;                // Kosten in Rubel
    public int StärkeBonus;          // Bonus auf Stärke
    public int IntelligenzBonus;     // Bonus auf Intelligenz
    public int CharismaBonus;        // Bonus auf Charisma
    public int LoyalitätBonus;       // Bonus auf Loyalität Volk
    public int EinflussBonus;        // Bonus auf Internationalen Einfluss
    public string Beschreibung;      // Kurzbeschreibung
    
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
        
        Console.WriteLine($"\n{player.GetFirstName()} ist bereit zu heiraten! Wähle deine Ehefrau:\n");
        
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
            Console.WriteLine($"\n💒 {player.GetFirstName()} heiratet {chosen.Name}!");
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
    public static void RandomBirth(PlayerCharacter player, bool isSidechickBirth = false)
    {
        // Nur wenn verheiratet (außer bei Sidechick-Geburten)
        if (!player.IstVerheiratet && !isSidechickBirth) return;
        
        // BUG-FIX 1: Begrenzung auf maximal 8 Kinder
        // Problem: Zu viele Geburten führten zu Endlos-Namenseingaben
        // Lösung: Kinderzahl auf 8 begrenzt für bessere Spielbalance
        if (player.Kinder.Count >= 8) return;
        
        // NEU: 3-Jahres-Cooldown nach jeder Geburt (außer bei Sidechick)
        int currentYear = player.GetCurrentYear();
        if (!isSidechickBirth && player.LetzteGeburtJahr > 0)
        {
            int jahreSeitLetzterGeburt = currentYear - player.LetzteGeburtJahr;
            if (jahreSeitLetzterGeburt < 3)
            {
                return; // Zu früh für nächste Geburt
            }
        }
        
        // Berechne Geburts-Wahrscheinlichkeit basierend auf Ehefrau
        // GeburtenBonus 1-5 * 15% = 15%, 30%, 45%, 60%, 75%
        int chance = player.GeburtenBonus * 15;
        
        // Zufalls-Check: Findet eine Geburt statt?
        if (rand.Next(100) < chance)
        {
            // WICHTIG: Setze Cooldown SOFORT, bevor Geburt beginnt
            // Verhindert, dass Funktion mehrfach hintereinander aufgerufen wird
            if (!isSidechickBirth)
            {
                player.LetzteGeburtJahr = currentYear;
            }
            
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
                
                // BUG-FIX 9: Einzelne saubere Namenseingabe ohne Mehrfach-Loops
                // Problem: ReadLine wurde mehrfach aufgerufen
                // Lösung: Einzelner Aufruf mit klarer Validierung
                Console.Write($"\nGib dem Kind #{i + 1} einen Vornamen: ");
                
                string vorname = Console.ReadLine()?.Trim() ?? "";
                
                // Überprüfung und Standard-Name falls leer
                if (string.IsNullOrWhiteSpace(vorname))
                {
                    vorname = isBoy ? "Vladimir" : "Natasha";
                    Console.WriteLine($"(Standard-Name: {vorname})");
                }
                
                string childName = $"{vorname} Rusputin {player.Generation + 1}";
                
                PlayerCharacter child = new PlayerCharacter(childName, player.Generation + 1);
                child.Alter = 0;
                child.Phase = "Kind";
                child.Geburtsjahr = player.GetCurrentYear();
                
                // Attribute vererben mit Variation
                child.Stärke = Math.Max(0, player.Stärke + rand.Next(-1, 3));
                child.Intelligenz = Math.Max(0, player.Intelligenz + rand.Next(-1, 3));
                child.Charisma = Math.Max(0, player.Charisma + rand.Next(-1, 3));
                child.Kraft = Math.Max(0, player.Kraft + rand.Next(-1, 3));
                
                player.Kinder.Add(child);
                
                Console.WriteLine($"\n✓ {childName} geboren ({player.GetCurrentYear()})!");
                Console.WriteLine($"Attribute: S:{child.Stärke} I:{child.Intelligenz} C:{child.Charisma} K:{child.Kraft}");
                
                if (i < birthCount - 1)
                {
                    Console.WriteLine("\n[Nächstes Kind - Taste drücken...]");
                    Console.ReadKey(true);
                    Console.Clear();
                }
            }
            
            Console.WriteLine($"\n\n{player.GetFirstName()} hat jetzt {player.Kinder.Count} Kind(er)!");
            player.LoyalitätFamilie = Math.Min(100, player.LoyalitätFamilie + (5 * birthCount));
            
            // Zeige Cooldown-Info (wurde bereits am Anfang gesetzt)
            if (!isSidechickBirth)
            {
                Console.WriteLine($"\n⏰ Nächste Geburt frühestens in {player.LetzteGeburtJahr + 3}");
            }
            
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
// TOD UND NACHFOLGE-SYSTEM (ÄNDERUNG 8)
// ═══════════════════════════════════════════════════════════════════
/*
 * TODESURSACHEN UND NACHFOLGE-MECHANIK:
 * 
 * Der Tod ist ein zentrales Gameplay-Element und ermöglicht
 * das generationenübergreifende Spielen.
 * 
 * TODESURSACHEN:
 * 1. Gesundheit ≤ 0:
 *    - Sofortiger Tod
 *    - Kann durch Ereignisse, Kämpfe oder Entscheidungen passieren
 * 
 * 2. Altersschwäche (ab 65 Jahre):
 *    - Nur in Präsidenten-Phase
 *    - Progressives Risiko: (Alter - 65) * 8%
 *    - Beispiel: 65 Jahre = 0%, 70 Jahre = 40%, 75 Jahre = 80%
 * 
 * NACHFOLGE:
 * - Spieler wählt einen Erben aus seinen Kindern
 * - Erbe startet mit 25 Jahren im Jurastudium
 * - 50% Geld, 33% KGB-Einfluss, 50% Partei-Loyalität werden vererbt
 * - Attribute werden von Eltern geerbt (± Variation)
 * - KEINE Kinder? → GAME OVER!
 */

/// <summary>
/// DeathSystem - Verwaltung von Tod und Nachfolge
/// 
/// ÄNDERUNG 8: Generationen-System mit Erben-Auswahl
/// </summary>
static class DeathSystem
{
    static Random rand = new Random();
    
    /// <summary>
    /// CheckDeath - Prüft ob der Charakter stirbt
    /// 
    /// Prüft zwei Todesursachen:
    /// 1. Gesundheit auf 0 gefallen
    /// 2. Altersschwäche (progressiv ab 65 Jahren)
    /// 
    /// RÜCKGABE: true wenn tot, false wenn am Leben
    /// </summary>
    public static bool CheckDeath(PlayerCharacter player)
    {
        // ═══ TODESURSACHE 1: Gesundheit ═══
        // Sofortiger Tod wenn Gesundheit auf 0 oder darunter
        if (player.Gesundheit <= 0)
        {
            ShowDeathScene(player, "tödlichen Verletzungen");
            return true;
        }
        
        // ═══ TODESURSACHE 2: Altersschwäche ═══
        // Nur während Präsidentschaft, progressives Risiko
        if (player.Phase == "Präsident" && player.Alter >= 65)
        {
            // Berechne Todes-Wahrscheinlichkeit
            // Formel: (Alter - 65) * 8
            // Ergebnis: 65J=0%, 70J=40%, 75J=80%, 80J=120%=sicherer Tod
            int deathChance = (player.Alter - 65) * 8;
            if (rand.Next(100) < deathChance)
            {
                ShowDeathScene(player, "Altersschwäche");
                return true;
            }
        }
        
        return false;  // Charakter lebt
    }
    
    /// <summary>
    /// ShowDeathScene - Zeigt die Todesszene mit Statistiken
    /// 
    /// Wird aufgerufen wenn ein Charakter stirbt.
    /// Zeigt eine dramatische Szene mit:
    /// - Todesursache
    /// - Alter bei Tod
    /// - Wichtige Statistiken (Kinder, Vermögen, Loyalitäten)
    /// - Abschiedsnachricht
    /// 
    /// Markiert den Charakter als tot (für Stammbaum-Visualisierung)
    /// </summary>
    /// <param name="player">Der verstorbene Charakter</param>
    /// <param name="cause">Todesursache als Text</param>
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
        
        player.IstTot = true;  // Für Stammbaum-Visualisierung markieren
        
        Console.WriteLine("Die Dynastie geht weiter...");
        Console.WriteLine("\n[Drücke eine Taste...]");
        Console.ReadKey(true);
    }
    
    /// <summary>
    /// SelectHeir - Ermöglicht Spieler-Wahl des Nachfolgers
    /// 
    /// KERNMECHANIK DES GENERATIONEN-SPIELS!
    /// 
    /// ABLAUF:
    /// 1. Prüfung: Hat Verstorbener Kinder?
    ///    - NEIN → GAME OVER (Dynastie endet)
    ///    - JA → Weiter zu Schritt 2
    /// 
    /// 2. Zeige alle Kinder mit Attributen an
    /// 
    /// 3. Spieler wählt ein Kind aus [1-N]
    /// 
    /// 4. Gewähltes Kind wird zum neuen Hauptcharakter:
    ///    - Alter: 25 Jahre (junger Erwachsener)
    ///    - Phase: "Jurastudium" (startet hier)
    ///    - Gesundheit: 100% (voll regeneriert)
    ///    - Vermögen: 50% des Eltern-Vermögens
    ///    - KGB-Einfluss: 33% des Eltern-Einflusses
    ///    - Militär-Einfluss: 33%
    ///    - Partei-Loyalität: 50%
    ///    - Attribute: Bereits bei Geburt vererbt
    /// 
    /// STRATEGISCHE WAHL:
    /// - Spieler sollte Kind mit besten Attributen wählen
    /// - Oder spezialisiertes Kind je nach gewünschtem Spielstil
    /// 
    /// RÜCKGABE: Gewählter Erbe ODER null bei Game Over
    /// </summary>
    /// <param name="deceased">Der verstorbene Eltern-Charakter</param>
    /// <returns>Gewählter Erbe oder null (Game Over)</returns>
    public static PlayerCharacter SelectHeir(PlayerCharacter deceased)
    {
        // ═══ GAME OVER PRÜFUNG ═══
        // Keine Kinder = Ende der Dynastie
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
            return null;  // Signalisiert Game Over
        }
        
        // ═══ ERBEN-AUSWAHL-BILDSCHIRM ═══
        Console.Clear();
        Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
        Console.WriteLine("║              WÄHLE DEINEN NACHFOLGER                      ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════╝\n");
        
        Console.WriteLine($"{deceased.Name} ist verstorben.");
        Console.WriteLine("Wähle ein Kind, um die Dynastie fortzuführen:\n");
        
        // Liste alle Kinder mit ihren Attributen auf
        for (int i = 0; i < deceased.Kinder.Count; i++)
        {
            var child = deceased.Kinder[i];
            Console.WriteLine($"[{i + 1}] {child.Name}");
            Console.WriteLine($"    Generation: {child.Generation}");
            Console.WriteLine($"    Attribute: S:{child.Stärke} I:{child.Intelligenz} C:{child.Charisma} K:{child.Kraft}");
            Console.WriteLine();
        }
        
        // ═══ EINGABE-SCHLEIFE ═══
        // Wiederholt bis gültige Auswahl getroffen wurde
        while (true)
        {
            Console.Write($"Wähle [1-{deceased.Kinder.Count}]: ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= deceased.Kinder.Count)
            {
                var heir = deceased.Kinder[choice - 1];
                
                // ═══ NACHFOLGE-ANKÜNDIGUNG ═══
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
                
                // ═══ VERERBUNGS-MECHANIK ═══
                // Erbe erhält einen Teil des elterlichen Erfolgs
                heir.Geld = deceased.Geld / 2;              // 50% Vermögen
                heir.Alter = 25;                            // Junger Erwachsener
                heir.Phase = "Jurastudium";                 // Beginnt im Studium
                heir.Gesundheit = 100;                      // Volle Gesundheit
                
                // Teil der politischen Einflüsse wird vererbt
                heir.EinflussKGB = deceased.EinflussKGB / 3;           // 33% KGB-Einfluss
                heir.EinflussMilitär = deceased.EinflussMilitär / 3;   // 33% Militär-Einfluss
                heir.LoyalitätPartei = deceased.LoyalitätPartei / 2;   // 50% Partei-Loyalität
                
                Console.WriteLine($"\nGeerbtes Vermögen: {heir.Geld} Rubel");
                Console.WriteLine("\n[Drücke eine Taste um fortzufahren...]");
                Console.ReadKey(true);
                
                return heir;  // Rückgabe des neuen Hauptcharakters
            }
        }
    }
}

/// <summary>
/// EventSystem - Zentrale Verwaltung aller Zufallsereignisse
/// 
/// ÄNDERUNG 9: Umfangreiches Event-System mit 20+ Ereignissen
/// 
/// Dieses System fügt dem Spiel Dynamik und Unvorhersehbarkeit hinzu.
/// Ereignisse können in jeder Lebensphase auftreten und das Schicksal
/// von Flad massiv beeinflussen.
/// 
/// EVENT-TYPEN:
/// 1. PASSIVE EVENTS: Automatische Effekte
///    Beispiel: "Verlust des Bruders" → -10 Gesundheit, +20 Familie
/// 
/// 2. INTERAKTIVE EVENTS: Spieler muss wählen
///    Beispiel: "Gefährlicher Freundeskreis" → [Decken] oder [Melden]
/// 
/// 3. ATTRIBUT-ABHÄNGIGE EVENTS: Ergebnis variiert je nach Werten
///    Beispiel: "Intrige" → Erfolg wenn Intelligenz ≥4 ODER KGB ≥50
/// 
/// 4. ERFOLG/MISSERFOLG EVENTS: Zufälliges Ergebnis
///    Beispiel: "Geheimer Testeinsatz" → 60% Erfolg, 40% Fehlschlag
/// 
/// VERTEILUNG:
/// - Kindheit: 5 Events
/// - KGB-Phase: 2 Events
/// - Jurastudium: 5 Events
/// - DDR-Einsatz: 3 Events
/// - Präsident: 4 Events
/// 
/// TRIGGER-MECHANIK:
/// - Jedes Event hat Wahrscheinlichkeit (z.B. 20%)
/// - Bei jedem Phase-Fortschritt wird geprüft
/// - Passende Events der aktuellen Phase werden gefiltert
/// - Zufällig eines der möglichen Events wird ausgeführt
/// </summary>

// ═══════════════════════════════════════════════════════════════════
// PUTIN-LUXUS-SHOP SYSTEM
// ═══════════════════════════════════════════════════════════════════

/// <summary>
/// PutinShop - Luxusgegenstände kaufen wie echte Oligarchen
/// 
/// KONZEPT:
/// Der Spieler kann Putin-typische Luxusgegenstände kaufen:
/// - Autos (Mercedes, Rolls-Royce, Aurus)
/// - Pferde (Putin liebt Reiten!)
/// - Jachten
/// - Paläste
/// - Sportausrüstung
/// - Kampfflugzeuge
/// 
/// FEATURES:
/// - Alle Items geben permanente Stat-Boni
/// - Items werden in Attribut-Anzeige gelistet
/// - Nur einmal pro Item kaufbar
/// - Taste 'Q' zum Öffnen
/// </summary>
static class PutinShop
{
    static Random rand = new Random();
    static List<ShopItem> shopItems = new List<ShopItem>();
    
    /// <summary>
    /// InitializeShop - Lädt alle verfügbaren Luxusgegenstände
    /// </summary>
    public static void InitializeShop()
    {
        shopItems.Clear();
        
        // ═══ FAHRZEUGE ═══
        shopItems.Add(new ShopItem(
            "Mercedes S-Klasse",
            "🚗",
            500,
            0, 5, 10, 15, 10,
            "Luxuslimousine der Staatsführung"
        ));
        
        shopItems.Add(new ShopItem(
            "Rolls-Royce Phantom",
            "🚙",
            1200,
            0, 10, 20, 25, 20,
            "Ultimatives Prestige-Fahrzeug"
        ));
        
        shopItems.Add(new ShopItem(
            "Aurus Senat",
            "🚘",
            800,
            5, 5, 15, 30, 15,
            "Russische Präsidentenlimousine"
        ));
        
        shopItems.Add(new ShopItem(
            "Militär-Konvoi",
            "🚛",
            600,
            20, 0, 10, 20, 5,
            "Bewaffnete Eskorte"
        ));
        
        // ═══ TIERE ═══
        shopItems.Add(new ShopItem(
            "Russisches Araber-Pferd",
            "🐴",
            400,
            15, 5, 20, 25, 5,
            "Putin liebt Reiten ohne Hemd!"
        ));
        
        shopItems.Add(new ShopItem(
            "Sibirischer Tiger",
            "🐯",
            1000,
            30, 0, 25, 15, 20,
            "Symbol der Stärke"
        ));
        
        shopItems.Add(new ShopItem(
            "Bären-Duo",
            "🐻",
            700,
            25, 0, 15, 20, 10,
            "Russlands nationales Tier"
        ));
        
        // ═══ IMMOBILIEN ═══
        shopItems.Add(new ShopItem(
            "Kreml-Datscha",
            "🏰",
            1500,
            0, 15, 25, 30, 25,
            "Präsidenten-Sommerresidenz"
        ));
        
        shopItems.Add(new ShopItem(
            "Schwarzmeer-Palast",
            "🏛️",
            3000,
            0, 20, 40, 40, 35,
            "Geheimes Luxus-Anwesen"
        ));
        
        shopItems.Add(new ShopItem(
            "Oligarchen-Jacht",
            "🛥️",
            2000,
            5, 10, 35, 30, 40,
            "150m Superjacht mit Hubschrauber"
        ));
        
        // ═══ SPORT & HOBBIES ═══
        shopItems.Add(new ShopItem(
            "Judo-Dojo (Eigenes)",
            "🥋",
            300,
            25, 10, 15, 20, 10,
            "Putin ist Judo-Meister"
        ));
        
        shopItems.Add(new ShopItem(
            "Eishockey-Ausrüstung Pro",
            "🏒",
            250,
            20, 5, 20, 25, 5,
            "Putin spielt Eishockey"
        ));
        
        shopItems.Add(new ShopItem(
            "Goldene Rolex",
            "⌚",
            600,
            0, 5, 25, 15, 15,
            "Luxus-Uhr der Weltführer"
        ));
        
        // ═══ MILITÄR ═══
        shopItems.Add(new ShopItem(
            "Su-57 Kampfjet",
            "✈️",
            2500,
            30, 15, 30, 20, 50,
            "Modernster russischer Jet"
        ));
        
        shopItems.Add(new ShopItem(
            "T-14 Armata Panzer",
            "🚀",
            1800,
            40, 10, 20, 25, 30,
            "Neuester russischer Panzer"
        ));
        
        shopItems.Add(new ShopItem(
            "Atomraketen-U-Boot",
            "🚢",
            4000,
            20, 25, 35, 30, 60,
            "Strategische Atomwaffe"
        ));
        
        // ═══ ENTERTAINMENT ═══
        shopItems.Add(new ShopItem(
            "Privat-Theater",
            "🎭",
            500,
            0, 10, 30, 25, 15,
            "Kulturbotschafter-Status"
        ));
        
        shopItems.Add(new ShopItem(
            "KGB-Archiv-Zugang",
            "📚",
            1000,
            0, 40, 20, 15, 25,
            "Geheimwissen ist Macht"
        ));
    }
    
    /// <summary>
    /// ShowShop - Zeigt den Luxus-Shop
    /// </summary>
    public static void ShowShop(PlayerCharacter player)
    {
        if (shopItems.Count == 0)
            InitializeShop();
        
        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n╔══════════════════════════════════════════════════════╗");
            Console.WriteLine("║         🛒 PUTIN'S LUXUS-SHOP 🛒                    ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════╝\n");
            Console.ResetColor();
            
            Console.WriteLine($"💰 Dein Geld: {player.Geld} Rubel");
            Console.WriteLine($"🎒 Besitztümer: {player.Besitztümer.Count} Items\n");
            Console.WriteLine("═══════════════════════════════════════════════════════\n");
            
            // Zeige verfügbare Items
            for (int i = 0; i < shopItems.Count && i < 18; i++)
            {
                var item = shopItems[i];
                bool bereitsGekauft = player.Besitztümer.Any(b => b.Name == item.Name);
                
                if (bereitsGekauft)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine($"[{i + 1}] ✓ {item.Icon} {item.Name} - BESITZT");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = player.Geld >= item.Preis ? ConsoleColor.Green : ConsoleColor.Red;
                    Console.WriteLine($"[{i + 1}] {item.Icon} {item.Name} - {item.Preis} ₽");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine($"     {item.Beschreibung}");
                    Console.WriteLine($"     Bonus: S+{item.StärkeBonus} I+{item.IntelligenzBonus} C+{item.CharismaBonus} L+{item.LoyalitätBonus} E+{item.EinflussBonus}");
                    Console.ResetColor();
                }
            }
            
            Console.WriteLine("\n[0] Verlassen");
            Console.Write("\nWähle Item [0-18]: ");
            
            string input = Console.ReadLine();
            
            if (input == "0")
                break;
            
            if (int.TryParse(input, out int choice) && choice >= 1 && choice <= shopItems.Count)
            {
                BuyItem(player, shopItems[choice - 1]);
            }
            else
            {
                Console.WriteLine("\nUngültige Auswahl!");
                Thread.Sleep(1000);
            }
        }
    }
    
    /// <summary>
    /// BuyItem - Kauft ein Item
    /// </summary>
    static void BuyItem(PlayerCharacter player, ShopItem item)
    {
        Console.Clear();
        
        // Bereits gekauft?
        if (player.Besitztümer.Any(b => b.Name == item.Name))
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n⚠ Du besitzt bereits: {item.Icon} {item.Name}");
            Console.ResetColor();
            Thread.Sleep(2000);
            return;
        }
        
        // Nicht genug Geld?
        if (player.Geld < item.Preis)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n❌ Nicht genug Geld!");
            Console.WriteLine($"Benötigt: {item.Preis} ₽");
            Console.WriteLine($"Verfügbar: {player.Geld} ₽");
            Console.ResetColor();
            Thread.Sleep(2000);
            return;
        }
        
        // Bestätigung
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"\n{item.Icon} {item.Name}");
        Console.WriteLine($"═══════════════════════════════════════════════════════");
        Console.WriteLine($"\n{item.Beschreibung}");
        Console.WriteLine($"\nPreis: {item.Preis} Rubel");
        Console.WriteLine($"\nBoni:");
        if (item.StärkeBonus > 0) Console.WriteLine($"  💪 Stärke: +{item.StärkeBonus}");
        if (item.IntelligenzBonus > 0) Console.WriteLine($"  🧠 Intelligenz: +{item.IntelligenzBonus}");
        if (item.CharismaBonus > 0) Console.WriteLine($"  ✨ Charisma: +{item.CharismaBonus}");
        if (item.LoyalitätBonus > 0) Console.WriteLine($"  👥 Loyalität Volk: +{item.LoyalitätBonus}");
        if (item.EinflussBonus > 0) Console.WriteLine($"  🌍 Einfluss International: +{item.EinflussBonus}");
        Console.ResetColor();
        
        Console.Write("\nKaufen? [J/N]: ");
        string confirm = Console.ReadLine()?.ToUpper();
        
        if (confirm == "J" || confirm == "Y")
        {
            // Kaufen
            player.Geld -= item.Preis;
            player.Besitztümer.Add(item);
            
            // Boni anwenden
            player.Stärke += item.StärkeBonus;
            player.Intelligenz += item.IntelligenzBonus;
            player.Charisma += item.CharismaBonus;
            player.LoyalitätVolk += item.LoyalitätBonus;
            player.EinflussInternational += item.EinflussBonus;
            
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n✓ {item.Icon} {item.Name} GEKAUFT!");
            Console.WriteLine($"\n💰 Verbleibendes Geld: {player.Geld} ₽");
            Console.WriteLine($"🎒 Besitztümer: {player.Besitztümer.Count}");
            Console.ResetColor();
            Thread.Sleep(2500);
        }
    }
}

// ═══════════════════════════════════════════════════════════════════
// ERDOGAN-NOTTELEFON SYSTEM
// ═══════════════════════════════════════════════════════════════════

/// <summary>
/// ErdoganHotline - Strategisches Hilfesystem via Türkei
/// 
/// KONZEPT:
/// Der Spieler hat Zugang zu einem "Nottelefon" zu Präsident Erdogan.
/// Über die Taste 'E' kann er in kritischen Situationen Hilfe anfordern.
/// 
/// FEATURES:
/// - 💰 Geld leihen (mit Zinsen und Rückzahlungspflicht)
/// - 🛡️ S-400 Militärhilfe (Verteidigungsbonus)
/// - ⚡ Gas-Deal (Energie-Rabatt)
/// - 🤝 Diplomatische Vermittlung (Krisenlösung)
/// - 🌾 Getreide-Deal (Nahrungsbonus)
/// 
/// LIMITIERUNG:
/// - Nur 5 Anrufe pro Durchlauf möglich
/// - Schulden müssen zurückgezahlt werden
/// - Beziehung zur Türkei beeinflusst Konditionen
/// </summary>
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

static class EventSystem
{
    static Random rand = new Random();
    static List<RandomEvent> allEvents = new List<RandomEvent>();
    
    /// <summary>
    /// PlayEventSound - Wrapper-Methode für SoundSystem
    /// </summary>
    static void PlayEventSound(string eventType)
    {
        SoundSystem.PlayEventSound(eventType);
    }
    
    /// <summary>
    /// InitializeEvents - Lädt alle 20+ Zufallsereignisse
    /// 
    /// Wird beim Programmstart aufgerufen.
    /// Definiert alle Events mit ihren Effekten.
    /// </summary>
    public static void InitializeEvents()
    {
        // ═══════════════════════════════════════════════════════════
        // KINDHEIT EREIGNISSE (5 Events)
        // Phase: "Kindheit"
        // ═══════════════════════════════════════════════════════════
        
        allEvents.Add(new RandomEvent(
            "Verlust des Bruders",
            "Tragischer Tod eines Familienmitglieds...",
            "Kindheit", 20,  // 20% Chance
            p => {
                Console.WriteLine($"{p.GetFirstName()} verliert seinen Bruder durch Krankheit!");
                p.Gesundheit -= 10;                            // Trauma
                p.LoyalitätFamilie = Math.Min(100, p.LoyalitätFamilie + 20);  // Familie wird wichtiger
                p.Stärke += 1;                                 // Härtet ihn ab
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Nächtliche Verhaftung",
            "Der Spieler beobachtet, wie der KGB einen Nachbarn abholt. Die Schritte hallen im Treppenhaus...",
            "Kindheit", 30,
            p => {
                Console.WriteLine($"{p.GetFirstName()} beobachtet die Verhaftung mit Angst...");
                if (rand.Next(2) == 0)
                    p.LoyalitätPartei += 15; // Aus Angst
                else
                    p.LoyalitätPartei -= 10; // Zweifel am System
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Rauferei im Hinterhof",
            "Eine Prügelei mit Straßenjungen bricht aus!",
            "Kindheit", 40,
            p => {
                Console.WriteLine($"{p.GetFirstName()} setzt sich durch!");
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
            "Feierliche Auszeichnung mit dem roten Halstuch!",
            "Kindheit", 60,
            p => {
                Console.WriteLine($"{p.GetFirstName()} wird Jungpionier!");
                p.LoyalitätPartei += 15;
                p.Charisma += 1;
            }
        ));
        
        // JUGEND/KGB EREIGNISSE
        allEvents.Add(new RandomEvent(
            "Aufstieg in der Komsomol",
            "Zum Anführer der Jugendorganisation gewählt!",
            "KGB-Ambitionen", 40,
            p => {
                Console.WriteLine($"{p.GetFirstName()} führt die Komsomol!");
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
            "Stadtmeisterschaft im Judo gewonnen!",
            "Jurastudium", 35,
            p => {
                Console.WriteLine($"{p.GetFirstName()} ist Stadtmeister!");
                p.Kraft += 2;
                p.Gesundheit = Math.Min(100, p.Gesundheit + 10);
                p.Charisma += 1;
            }
        ));
        
        // KGB AUSBILDUNG
        allEvents.Add(new RandomEvent(
            "Drill und Disziplin",
            "Gnadenloser Drill in der KGB-Akademie...",
            "Jurastudium", 30,
            p => {
                Console.WriteLine($"{p.GetFirstName()} trägt Kameraden kilometerweit!");
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
            "Erster Feldauftrag: Intellektuelle observieren!",
            "Jurastudium", 40,
            p => {
                Console.WriteLine($"{p.GetFirstName()} erhält geheimen Auftrag!");
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
            "Hochrangiger westlicher Offizier rekrutiert!",
            "DDR-Einsatz", 25,
            p => {
                Console.WriteLine($"{p.GetFirstName()} gelingt ein großer Coup!");
                p.EinflussKGB += 30;
                p.Geld += 100;
                p.LoyalitätPartei += 20;
            }
        ));
        
        // PRÄSIDENT
        allEvents.Add(new RandomEvent(
            "Intrige im Politbüro",
            "Ein Rivale versucht einen Putsch!",
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
        
        // ═══════════════════════════════════════════════════════════
        // HISTORISCHE EREIGNISSE (1952-2024)
        // Basierend auf realen Katastrophen und politischen Events
        // ═══════════════════════════════════════════════════════════
        
        // KINDHEIT - Frühe sowjetische Ära
        allEvents.Add(new RandomEvent(
            "Kamtschatka-Erdbeben 1952",
            "Ein gewaltiges Erdbeben der Stärke 9,0 erschüttert Kamtschatka. Über 2.300 Menschen sterben...",
            "Kindheit", 15,
            p => {
                Console.WriteLine("Die Nachrichten vom fernen Osten erreichen auch die Straßen...");
                p.Gesundheit -= 5;
                p.LoyalitätPartei += 10; // Zusammenhalt in der Krise
                p.LoyalitätFamilie += 15;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Kyshtym-Nuklearunfall 1957",
            "Geheime Atomanlage explodiert! 23.000 km² kontaminiert, aber der Staat verschweigt alles...",
            "Kindheit", 12,
            p => {
                Console.WriteLine($"Gerüchte über eine mysteriöse Evakuierung erreichen {p.GetFirstName()}...");
                p.Gesundheit -= 10; // Strahlenangst
                p.LoyalitätPartei -= 15; // Misstrauen wegen Vertuschung
                p.Intelligenz += 1; // Lernt, Propaganda zu hinterfragen
            }
        ));
        
        // KGB-PHASE - Kalter Krieg
        allEvents.Add(new RandomEvent(
            "Kuba-Krise 1962",
            "Die Welt steht am Rand eines Atomkriegs! KGB in höchster Alarmbereitschaft...",
            "KGB-Phase", 20,
            p => {
                Console.WriteLine("Flad und andere Kadetten werden für Notfallpläne mobilisiert.");
                p.EinflussKGB += 20;
                p.Gesundheit -= 15; // Stress
                p.LoyalitätPartei += 25; // Patriotismus in der Krise
            }
        ));
        
        // STUDIUM - Spätsowjetische Stagnation
        allEvents.Add(new RandomEvent(
            "Tschernobyl-Katastrophe 1986",
            "26. April: Kernschmelze! Radioaktive Wolke über Europa. Hunderttausende Liquidatoren mobilisiert...",
            "Jurastudium", 25,
            p => {
                Console.WriteLine("\n[1] Freiwillig als Liquidator melden");
                Console.WriteLine("[2] Im Hintergrund bleiben");
                Console.Write("Wähle [1-2]: ");
                if (Console.ReadLine() == "1")
                {
                    Console.WriteLine($"{p.GetFirstName()} meldet sich freiwillig für den Einsatz in Tschernobyl!");
                    p.Gesundheit -= 40; // Strahlenschäden
                    p.LoyalitätPartei += 35;
                    p.LoyalitätVolk += 25;
                    p.Stärke += 2; // Härtet ab
                }
                else
                {
                    p.LoyalitätPartei -= 10;
                    p.Gesundheit -= 5; // Strahlenangst
                }
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Ufa-Gasexplosion 1989",
            "4. Juni: 575 Tote bei Zugunglück! Undichte Pipeline entzündet sich...",
            "Jurastudium", 15,
            p => {
                Console.WriteLine("Eine der schlimmsten Katastrophen der Sowjetzeit erschüttert das Land.");
                p.Gesundheit -= 10;
                p.LoyalitätPartei -= 20; // Versagen der Infrastruktur
                p.LoyalitätVolk += 15; // Mitgefühl mit Opfern
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Fall der Berliner Mauer 1989",
            "9. November: Die Mauer fällt! DDR kollabiert, der Ostblock bricht zusammen...",
            "Jurastudium", 30,
            p => {
                Console.WriteLine("Das Ende des Kalten Krieges naht. Die sowjetische Ordnung bröckelt...");
                p.EinflussInternational -= 30; // Machtverlust
                p.EinflussKGB -= 20; // Demoralisierung
                p.Intelligenz += 1; // Historischer Moment
                p.Geld -= 50; // Wirtschaftschaos
            }
        ));
        
        // DDR-EINSATZ - Post-Sowjetischer Umbruch
        allEvents.Add(new RandomEvent(
            "Zerfall der Sowjetunion 1991",
            "Dezember 1991: Die UdSSR existiert nicht mehr! Wirtschaftskrise, Hyperinflation, Verarmung...",
            "DDR-Einsatz", 35,
            p => {
                Console.WriteLine($"'Die größte geopolitische Katastrophe des Jahrhunderts' - {p.GetFirstName()} erlebt den Zusammenbruch.");
                p.Geld -= 150; // Rubelverfall
                p.LoyalitätPartei -= 40; // System kollabiert
                p.Gesundheit -= 20; // Krisenstress
                p.EinflussKGB -= 25; // Chaos im Apparat
                p.Charisma += 1; // Überlebenswille
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Neftegorsk-Erdbeben 1995",
            "28. Mai: Sakhalin-Siedlung in 17 Sekunden ausgelöscht. 2.000 Tote - zwei Drittel der Bevölkerung...",
            "DDR-Einsatz", 12,
            p => {
                Console.WriteLine("Die Katastrophe im fernen Osten erschüttert das krisengeschüttelte Russland.");
                p.Gesundheit -= 8;
                p.LoyalitätVolk += 20; // Solidarität
                p.Geld -= 30; // Spendensammlungen
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Russische Finanzkrise 1998",
            "17. August: Rubel-Kollaps! Staatsdefault! Millionen verlieren Ersparnisse...",
            "DDR-Einsatz", 30,
            p => {
                Console.WriteLine($"Die 'Rubelkrise' vernichtet {p.GetFirstName()}s Ersparnisse und stürzt Russland in Depression.");
                p.Geld = Math.Max(0, p.Geld - 200); // Massive Verluste
                p.LoyalitätPartei -= 35;
                p.LoyalitätVolk -= 30;
                p.Gesundheit -= 15; // Existenzangst
            }
        ));
        
        // PRÄSIDENT - Putin-Ära Ereignisse
        allEvents.Add(new RandomEvent(
            "Apartmenthaus-Bomben 1999",
            "September: Terroranschläge auf Wohnhäuser! Über 300 Tote. Tschetschenien wird verantwortlich gemacht...",
            "Präsident", 20,
            p => {
                Console.WriteLine("Die Anschläge lösen Angst aus und rechtfertigen den Zweiten Tschetschenienkrieg.");
                p.EinflussKGB += 25; // Sicherheitsapparat gestärkt
                p.EinflussMilitär += 20;
                p.LoyalitätVolk -= 20; // Angst
                p.Gesundheit -= 10;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Kursk-U-Boot-Untergang 2000",
            "12. August: Atomares U-Boot 'Kursk' sinkt. Alle 118 Besatzungsmitglieder tot. Internationale Hilfe zu spät...",
            "Präsident", 18,
            p => {
                Console.WriteLine("\n[1] Sofort internationale Hilfe annehmen");
                Console.WriteLine("[2] Auf Prestige achten, national reagieren");
                Console.Write("Wähle [1-2]: ");
                if (Console.ReadLine() == "1")
                {
                    p.EinflussInternational += 15;
                    p.LoyalitätVolk += 10; // Transparenz geschätzt
                    p.LoyalitätPartei -= 15; // Gilt als Schwäche
                }
                else
                {
                    p.LoyalitätVolk -= 25; // Kritik am Krisenmanagement
                    p.LoyalitätPartei += 10;
                    p.EinflussKGB += 10;
                }
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Dubrowka-Theater-Geiselnahme 2002",
            "23. Oktober: Tschetschenische Terroristen nehmen 850 Menschen als Geiseln. Gasbetäubung - 130 Geiseln sterben...",
            "Präsident", 15,
            p => {
                Console.WriteLine($"{p.GetFirstName()} muss eine unmögliche Entscheidung treffen...");
                p.EinflussKGB += 20; // Harter Einsatz
                p.LoyalitätVolk -= 30; // Zivile Opfer
                p.Gesundheit -= 25; // Gewissenslast
                p.LoyalitätPartei += 15; // 'Standhaftigkeit'
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Beslan-Schulmassaker 2004",
            "1.-3. September: Terroristen nehmen Schule ein. Über 330 Tote, darunter 186 Kinder...",
            "Präsident", 12,
            p => {
                Console.WriteLine("Die schlimmste Geiselnahme in der russischen Geschichte erschüttert das Land.");
                p.Gesundheit -= 35; // Trauma
                p.LoyalitätVolk -= 40; // Versagen des Staates
                p.EinflussKGB -= 15;
                p.LoyalitätPartei += 10; // Zentralisierung als Reaktion
                Console.WriteLine($"{p.GetFirstName()} nutzt die Tragödie, um Gouverneurswahlen abzuschaffen...");
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Hitzewelle & Waldbrände 2010",
            "Sommer 2010: Rekordtemperaturen! Moskau unter Rauch. 127 Ortschaften brennen ab, Tausende Tote...",
            "Präsident", 18,
            p => {
                Console.WriteLine("Die Klimakatastrophe zeigt Russlands Verwundbarkeit.");
                p.Gesundheit -= 20; // Rauchvergiftung
                p.LoyalitätVolk -= 25; // Unzureichende Hilfe
                p.Geld -= 100; // Wiederaufbau
                p.LoyalitätPartei -= 10;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Bulgaria-Schiffsunglück 2011",
            "10. Juli: Überfülltes Ausflugsschiff sinkt auf der Wolga. 122 Tote, darunter 28 Kinder...",
            "Präsident", 14,
            p => {
                Console.WriteLine("Mangelnde Sicherheitsstandards fordern ihren Tribut.");
                p.LoyalitätVolk -= 20;
                p.Gesundheit -= 10;
                p.Geld -= 50; // Entschädigungen
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Krymsk-Flutkatastrophe 2012",
            "7. Juli: Ohne Warnung überschwemmt Flut die Kleinstadt. Über 150 Tote in einer Nacht...",
            "Präsident", 13,
            p => {
                Console.WriteLine($"{p.GetFirstName()} besucht das Katastrophengebiet und ordnet Hilfsmaßnahmen an.");
                p.LoyalitätVolk -= 15; // Keine rechtzeitige Warnung
                p.Geld -= 80;
                p.Gesundheit -= 8;
                if (p.Charisma >= 4)
                {
                    p.LoyalitätVolk += 10; // Persönliches Engagement hilft
                }
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Amur-Hochwasser 2013",
            "Sommer 2013: Schlimmste Überschwemmung seit Menschengedenken im Fernen Osten. 90.000 evakuiert...",
            "Präsident", 16,
            p => {
                Console.WriteLine("Fünf Regionen unter Wasser. 13.000 Häuser überschwemmt. Monate des Wiederaufbaus...");
                p.Geld -= 120; // Massive Wiederaufbaukosten
                p.LoyalitätVolk -= 10;
                p.EinflussMilitär += 10; // Militär hilft
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Rubelkrise 2014",
            "Dezember: Sanktionen & Ölpreisverfall! Rubel verliert 50% seines Wertes. Leitzins auf 17%...",
            "Präsident", 25,
            p => {
                Console.WriteLine("Die Krim-Annexion hat ihren Preis: Wirtschaftskrise und Isolation.");
                p.Geld -= 200; // Währungsverfall
                p.EinflussInternational -= 40; // Sanktionen
                p.Gesundheit -= 15;
                p.LoyalitätVolk -= 30; // Realeinkommen sinken
                p.LoyalitätPartei += 15; // Nationalismus als Kompensation
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Kemerowo-Brand 2018",
            "25. März: Einkaufszentrum brennt. 64 Tote, 40 davon Kinder. Notausgänge verschlossen...",
            "Präsident", 14,
            p => {
                Console.WriteLine("Landesweite Trauer und Proteste gegen Sicherheitsverstöße. Nationaler Trauertag verhängt.");
                p.LoyalitätVolk -= 35; // Wut über Versagen
                p.Gesundheit -= 15;
                p.Geld -= 60; // Entschädigungen
                p.LoyalitätPartei -= 10;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "COVID-19-Pandemie 2020",
            "Frühjahr 2020: Globale Pandemie erreicht Russland. Lockdowns, Krankenhäuser überlastet, über 500.000 Tote...",
            "Präsident", 30,
            p => {
                Console.WriteLine("Die Jahrhundertpandemie trifft Russland hart. Sputnik-V-Impfung wird entwickelt.");
                p.Gesundheit -= 30; // Pandemie-Risiko
                p.Geld -= 150; // Wirtschaftseinbruch
                p.LoyalitätVolk -= 25; // Unzureichende Maßnahmen
                p.LoyalitätPartei -= 15;
                if (p.Intelligenz >= 5)
                {
                    p.Gesundheit += 10; // Besseres Krisenmanagement
                    p.LoyalitätVolk += 15;
                }
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Sibirische Megabrände 2021",
            "Sommer 2021: Rekordwaldbrände in Sibirien. 3,4 Mio. Hektar brennen. Rauch erreicht Nordpol...",
            "Präsident", 17,
            p => {
                Console.WriteLine("Der Klimawandel zeigt sein Gesicht: Die Taiga brennt lichterloh.");
                p.Geld -= 90; // Löschkosten
                p.Gesundheit -= 12; // Rauch
                p.LoyalitätVolk -= 15; // Unzureichende Prävention
            }
        ));
        
        // ═══════════════════════════════════════════════════════════
        // SIDECHICK / AFFÄREN-EVENTS (Neue Kategorie)
        // Zufällige Affären führen zu unehelichen Kindern
        // ═══════════════════════════════════════════════════════════
        
        allEvents.Add(new RandomEvent(
            "Geheime Affäre",
            "Eine charmante Diplomatin aus Belarus zieht deine Aufmerksamkeit auf sich...",
            "Präsident", 0, 0, "sidechick",
            p => {
                Console.WriteLine("\n[1] Affäre eingehen (riskant!)");
                Console.WriteLine("[2] Ablehnen (treu bleiben)");
                Console.Write("Wähle [1-2]: ");
                
                if (Console.ReadLine() == "1")
                {
                    Console.WriteLine("\n💋 Die Affäre beginnt...");
                    Thread.Sleep(1500);
                    
                    // 60% Chance auf uneheliches Kind
                    if (rand.Next(100) < 60)
                    {
                        Console.WriteLine("\n👶 ÜBERRASCHUNG: Sie ist schwanger!");
                        
                        bool isBoy = rand.Next(2) == 0;
                        Console.Write($"\nName für das uneheliche Kind (Enter = Standardname): ");
                        string vorname = Console.ReadLine();
                        
                        if (string.IsNullOrWhiteSpace(vorname))
                            vorname = isBoy ? "Alexei" : "Anastasia";
                        
                        string childName = $"{vorname} [Unehelich] Gen{p.Generation + 1}";
                        
                        PlayerCharacter child = new PlayerCharacter(childName, p.Generation + 1);
                        child.Alter = 0;
                        child.Phase = "Kind";
                        child.Geburtsjahr = p.GetCurrentYear();
                        
                        // Attribute vererben
                        child.Stärke = Math.Max(0, p.Stärke + rand.Next(-2, 2));
                        child.Intelligenz = Math.Max(0, p.Intelligenz + rand.Next(-2, 2));
                        child.Charisma = Math.Max(0, p.Charisma + rand.Next(-2, 2));
                        child.Kraft = Math.Max(0, p.Kraft + rand.Next(-2, 2));
                        
                        p.Kinder.Add(child);
                        
                        Console.WriteLine($"\n✓ {childName} wurde heimlich geboren!");
                        Console.WriteLine($"Attribute: S:{child.Stärke} I:{child.Intelligenz} C:{child.Charisma} K:{child.Kraft}");
                    }
                    
                    // Negative Konsequenzen
                    p.LoyalitätFamilie -= 30; // Familie leidet
                    p.Geld -= 100; // Schweigegeld
                    
                    if (p.IstVerheiratet)
                    {
                        Console.WriteLine("\n⚠ Deine Ehe ist angespannt...");
                        p.LoyalitätFamilie -= 20;
                    }
                    
                    // 30% Chance auf Skandal
                    if (rand.Next(100) < 30)
                    {
                        Console.WriteLine("\n📰 SKANDAL! Die Presse erfährt von der Affäre!");
                        p.LoyalitätVolk -= 40;
                        p.LoyalitätPartei -= 25;
                        p.Geld -= 200; // Schadensbegrenzung
                    }
                }
                else
                {
                    Console.WriteLine("\nDu bleibst deinen Prinzipien treu.");
                    p.LoyalitätFamilie += 10;
                }
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Alte Flamme",
            "Eine Jugendliebe aus Leningrad taucht plötzlich wieder auf...",
            "DDR-Einsatz", 0, 0, "sidechick",
            p => {
                Console.WriteLine("Sie behauptet, du seist der Vater ihres Kindes!");
                Console.WriteLine("\n[1] DNA-Test machen (+Geld, Gewissheit)");
                Console.WriteLine("[2] Kind anerkennen (Risiko)");
                Console.WriteLine("[3] Ablehnen");
                Console.Write("Wähle [1-3]: ");
                
                string choice = Console.ReadLine();
                
                if (choice == "1")
                {
                    p.Geld -= 50;
                    if (rand.Next(100) < 40) // 40% tatsächlich dein Kind
                    {
                        Console.WriteLine("\n✓ DNA-Test positiv! Es ist dein Kind.");
                        AddIllegitimateChild(p);
                        p.LoyalitätFamilie -= 15;
                    }
                    else
                    {
                        Console.WriteLine("\n✗ DNA-Test negativ. Betrugsversuch!");
                        p.EinflussKGB += 10; // Erfahrung
                    }
                }
                else if (choice == "2")
                {
                    Console.WriteLine("\nDu erkennst das Kind an.");
                    AddIllegitimateChild(p);
                    p.Geld -= 80; // Unterhalt
                    p.LoyalitätFamilie -= 20;
                }
                else
                {
                    Console.WriteLine("\nDu lehnst ab. Sie droht mit rechtlichen Schritten...");
                    p.LoyalitätVolk -= 15;
                    p.Geld -= 30; // Anwaltskosten
                }
            }
        ));
        
        // ═══════════════════════════════════════════════════════════
        // HISTORISCHE KATASTROPHEN (1952-2021)
        // Reale Ereignisse in chronologischer Reihenfolge
        // ═══════════════════════════════════════════════════════════
        
        allEvents.Add(new RandomEvent(
            "Kamtschatka-Erdbeben 1952",
            "Ein gewaltiges Beben der Stärke 9,0 erschüttert Kamtschatka! Tsunami verwüstet Küstensiedlungen. Severo-Kurilsk wird zerstört...",
            "Präsident", 0, 1952, "katastrophe",
            p => {
                Console.WriteLine("Über 2.300 Menschen kommen ums Leben. Stärkstes Beben in Russlands Geschichte!");
                p.Gesundheit -= 30;
                p.Geld -= 400;
                p.LoyalitätVolk -= 35;
                p.EinflussMilitär += 10; // Armee hilft bei Rettung
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Kyshtym-Nuklearunfall 1957",
            "GEHEIM! In der Atomanlage Mayak explodiert ein Tank mit radioaktiven Abfällen. 23.000 km² Land kontaminiert...",
            "Präsident", 0, 1957, "katastrophe",
            p => {
                Console.WriteLine("Über 10.000 Menschen evakuiert. Hunderte Strahlentote. Bis 1989 geheim gehalten!");
                p.Gesundheit -= 40;
                p.Geld -= 500;
                p.LoyalitätVolk -= 50; // Wenn bekannt wird
                p.LoyalitätPartei -= 30; // Vertuschung
                p.EinflussKGB += 25; // Geheimhaltung
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Tschernobyl-Katastrophe 1986",
            "26. April: Block 4 des Kernkraftwerks Tschernobyl explodiert! Kernschmelze, radioaktive Wolke über Europa...",
            "Präsident", 0, 1986, "katastrophe",
            p => {
                Console.WriteLine("Hunderttausende Liquidatoren mobilisiert. Schlimmste Nuklearkatastrophe der Geschichte!");
                p.Gesundheit -= 50;
                p.Geld -= 800;
                p.LoyalitätVolk -= 60;
                p.LoyalitätPartei -= 40;
                p.EinflussInternational -= 50;
                p.EinflussKGB += 15; // Informationskontrolle
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Ufa-Gasexplosion 1989",
            "4. Juni: Undichte Pipeline explodiert, als zwei Züge vorbeifahren! Feuersturm nahe Ufa...",
            "Präsident", 0, 1989, "katastrophe",
            p => {
                Console.WriteLine("575 Tote, 800 Verletzte. Schwerstes Zugunglück der sowjetischen Geschichte!");
                p.Gesundheit -= 35;
                p.Geld -= 350;
                p.LoyalitätVolk -= 40;
                p.LoyalitätPartei -= 25;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Zerfall der Sowjetunion 1991",
            "Ende 1991: Die UdSSR zerfällt! Wirtschaftskollaps, Inflation explodiert, Millionen verarmen...",
            "Präsident", 0, 1991, "katastrophe",
            p => {
                Console.WriteLine("'Größte geopolitische Katastrophe des 20. Jahrhunderts' - Putin");
                p.Gesundheit -= 40;
                p.Geld -= 600;
                p.LoyalitätVolk -= 70;
                p.LoyalitätPartei -= 80;
                p.EinflussInternational -= 60;
                p.EinflussKGB -= 30;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Erdbeben von Neftegorsk 1995",
            "28. Mai: Beben der Stärke 7,6 auf Sachalin! Neftegorsk in 17 Sekunden ausgelöscht...",
            "Präsident", 0, 1995, "katastrophe",
            p => {
                Console.WriteLine("Über 2.000 Tote - zwei Drittel der Einwohner! Stadt wird nicht wiederaufgebaut.");
                p.Gesundheit -= 35;
                p.Geld -= 300;
                p.LoyalitätVolk -= 35;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Russische Finanzkrise 1998",
            "17. August: Russland erklärt Staatsinsolvenz! Rubel stürzt ab, Banken brechen zusammen...",
            "Präsident", 0, 1998, "katastrophe",
            p => {
                Console.WriteLine("Millionen Russen verlieren ihre Ersparnisse. Wirtschaft in Rezession!");
                p.Gesundheit -= 30;
                p.Geld -= 700;
                p.LoyalitätVolk -= 65;
                p.LoyalitätPartei -= 50;
                p.EinflussInternational -= 45;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Apartmenthaus-Bombenserie 1999",
            "September: Bombenanschläge auf Wohnhäuser in Moskau, Buinaksk, Wolgodonsk...",
            "Präsident", 0, 1999, "katastrophe",
            p => {
                Console.WriteLine("Über 300 Tote, 1.000+ Verletzte! Tschetschenischen Terroristen zugeschrieben.");
                p.Gesundheit -= 40;
                p.Geld -= 250;
                p.LoyalitätVolk -= 50;
                p.EinflussKGB += 30; // Sicherheitsapparat gestärkt
                p.EinflussMilitär += 25; // Kriegsgrund Tschetschenien
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Untergang U-Boot Kursk 2000",
            "12. August: Atomares U-Boot Kursk sinkt in der Barentssee nach Explosion...",
            "Präsident", 0, 2000, "katastrophe",
            p => {
                Console.WriteLine("Alle 118 Besatzungsmitglieder tot. Putin bleibt im Urlaub - heftige Kritik!");
                p.Gesundheit -= 35;
                p.Geld -= 200;
                p.LoyalitätVolk -= 40;
                p.LoyalitätPartei -= 20;
                p.EinflussInternational -= 25;
                p.EinflussMilitär -= 15;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Dubrowka-Geiseldrama 2002",
            "23. Oktober: Tschetschenische Terroristen nehmen 850 Menschen im Moskauer Theater als Geiseln...",
            "Präsident", 0, 2002, "katastrophe",
            p => {
                Console.WriteLine("Spezialeinheiten leiten Gas ein und stürmen. 130 Geiseln sterben durch Gas und Gefechte!");
                p.Gesundheit -= 45;
                p.Geld -= 150;
                p.LoyalitätVolk -= 35;
                p.EinflussKGB += 25; // Harter Einsatz
                p.EinflussMilitär += 20;
                p.EinflussInternational -= 30; // Kontroverse
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Geiselnahme von Beslan 2004",
            "1. September: Islamistische Terroristen stürmen Schule in Beslan, über 1.100 Geiseln...",
            "Präsident", 0, 2004, "katastrophe",
            p => {
                Console.WriteLine("3. September: Blutiges Ende! Über 330 Tote, darunter viele Kinder. Russland in Schock!");
                p.Gesundheit -= 55;
                p.Geld -= 200;
                p.LoyalitätVolk -= 50;
                p.LoyalitätPartei -= 30;
                p.EinflussMilitär += 20;
                p.EinflussKGB += 35; // Zentralisierung folgt
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Sajano-Schuschensker Dammunglück 2009",
            "17. August: Turbine 2 explodiert im größten Wasserkraftwerk Russlands! Turbinenhalle überflutet...",
            "Präsident", 0, 2009, "katastrophe",
            p => {
                Console.WriteLine("75 Tote. 9 von 10 Turbinen zerstört! Kompletter Stromausfall in Sibirien.");
                p.Gesundheit -= 30;
                p.Geld -= 450;
                p.LoyalitätVolk -= 35;
                p.LoyalitätPartei -= 20;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Hitzewelle und Waldbrände 2010",
            "Sommer 2010: Rekord-Hitze über 40°C! Moskau in Rauchschwaden, 127 Ortschaften brennen ab...",
            "Präsident", 0, 2010, "katastrophe",
            p => {
                Console.WriteLine("Über 50 direkte Brandtote, mehrere Tausend Hitzetote insgesamt. 1.200 Häuser zerstört!");
                p.Gesundheit -= 40;
                p.Geld -= 500;
                p.LoyalitätVolk -= 45;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Flugzeugabsturz Smolensk 2010",
            "10. April: Polnisches Regierungsflugzeug stürzt bei Smolensk ab...",
            "Präsident", 0, 2010, "katastrophe",
            p => {
                Console.WriteLine("Alle 96 Insassen tot, darunter polnischer Präsident Kaczyński! Polen in Schock.");
                p.Gesundheit -= 25;
                p.Geld -= 100;
                p.EinflussInternational -= 30; // Belastetes Verhältnis zu Polen
                p.LoyalitätVolk += 10; // Mitgefühl
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Untergang Flusskreuzer Bulgaria 2011",
            "10. Juli: Marodes Ausflugsschiff Bulgaria sinkt auf der Wolga...",
            "Präsident", 0, 2011, "katastrophe",
            p => {
                Console.WriteLine("122 Tote, darunter 28 Kinder! Schiff war überladen und ohne Lizenz.");
                p.Gesundheit -= 35;
                p.Geld -= 150;
                p.LoyalitätVolk -= 40;
                p.LoyalitätPartei -= 25;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Überschwemmung Krymsk 2012",
            "Juli: Extreme Regenfälle! Kleinstadt Krymsk nachts von Flutwelle getroffen...",
            "Präsident", 0, 2012, "katastrophe",
            p => {
                Console.WriteLine("Über 150 Tote, 50.000 Betroffene! Keine rechtzeitige Warnung der Bevölkerung.");
                p.Gesundheit -= 35;
                p.Geld -= 300;
                p.LoyalitätVolk -= 40;
                p.LoyalitätPartei -= 20;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Flutkatastrophe Ferner Osten 2013",
            "Sommer 2013: Amur tritt kilometerweit über die Ufer! 235 Ortschaften überflutet...",
            "Präsident", 0, 2013, "katastrophe",
            p => {
                Console.WriteLine("90.000 Evakuierte, 13.000 Häuser unter Wasser! Schlimmstes Hochwasser seit Menschengedenken.");
                p.Gesundheit -= 40;
                p.Geld -= 550;
                p.LoyalitätVolk -= 35;
                p.EinflussMilitär += 15; // Militär hilft
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Rubelkrise 2014",
            "Ende 2014: Westliche Sanktionen und Ölpreis-Verfall! Rubel verliert 50% seines Wertes...",
            "Präsident", 0, 2014, "katastrophe",
            p => {
                Console.WriteLine("Leitzins auf 17% angehoben! Inflation zweistellig, Wirtschaft in Rezession.");
                p.Gesundheit -= 30;
                p.Geld -= 600;
                p.LoyalitätVolk -= 50;
                p.LoyalitätPartei -= 25;
                p.EinflussInternational -= 40;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Brand Kemerowo 2018",
            "25. März: Feuer im 'Winterkirsch'-Einkaufszentrum! Notausgänge verschlossen, Alarm versagt...",
            "Präsident", 0, 2018, "katastrophe",
            p => {
                Console.WriteLine("64 Tote, darunter 40 Kinder! Landesweite Trauerkundgebungen und Proteste.");
                p.Gesundheit -= 40;
                p.Geld -= 200;
                p.LoyalitätVolk -= 50;
                p.LoyalitätPartei -= 30;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "COVID-19-Pandemie 2020",
            "Frühjahr 2020: Globale Corona-Pandemie erreicht Russland! Strikte Ausgangsbeschränkungen...",
            "Präsident", 0, 2020, "katastrophe",
            p => {
                Console.WriteLine("Bis 2023 über 500.000 Tote (Schätzung)! Krankenhäuser an Kapazitätsgrenzen.");
                p.Gesundheit -= 60;
                p.Geld -= 800;
                p.LoyalitätVolk -= 55;
                p.LoyalitätPartei -= 20;
                p.EinflussInternational -= 30;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Rekord-Waldbrände Sibirien 2021",
            "Sommer 2021: Zweitgrößte Waldbrände des 21. Jahrhunderts! 3,4 Millionen Hektar brennen...",
            "Präsident", 0, 2021, "katastrophe",
            p => {
                Console.WriteLine("Rauch erreicht erstmals den Nordpol! Klimawandel und mangelnde Finanzierung kritisiert.");
                p.Gesundheit -= 35;
                p.Geld -= 400;
                p.LoyalitätVolk -= 40;
                p.EinflussInternational -= 25; // Klimakritik
            }
        ));
        
        // ═══════════════════════════════════════════════════════════
        // HISTORISCHE POLITISCHE EREIGNISSE (Putin-Ära 1999-2024)
        // Chronologie der Machtergreifung und -sicherung Putins
        // ═══════════════════════════════════════════════════════════
        
        allEvents.Add(new RandomEvent(
            "Unerwarteter Machtwechsel 1999",
            "31. Dezember: Jelzin tritt überraschend zurück! Wladimir Putin - ehemaliger KGB-Offizier - wird amtierender Präsident...",
            "Präsident", 0, 1999, "politisch",
            p => {
                Console.WriteLine("Der bis dahin kaum bekannte Putin übernimmt die Staatsführung!");
                p.LoyalitätPartei += 40;
                p.EinflussKGB += 50;
                p.EinflussMilitär += 30;
                p.LoyalitätVolk += 25; // Hoffnung auf Stabilität
                p.Geld += 100;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Putins erster Wahlsieg 2000",
            "26. März: Putin wird mit 53% zum Präsidenten gewählt! Verspricht Stabilität nach chaotischem Jelzin-Jahrzehnt...",
            "Präsident", 0, 2000, "politisch",
            p => {
                Console.WriteLine("7. Mai: Feierliche Amtseinführung. Im Mai: Steuerfahnder stürmen oppositionellen Sender NTV!");
                p.LoyalitätPartei += 45;
                p.LoyalitätVolk += 35;
                p.EinflussKGB += 30;
                p.Geld += 150;
                p.EinflussInternational += 20;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Zweiter Tschetschenienkrieg 2000-2003",
            "Putin führt Krieg in Tschetschenien mit harter Hand! Grosny in Trümmer gelegt...",
            "Präsident", 0, 2003, "politisch",
            p => {
                Console.WriteLine("Tausende Zivilisten tot. Tschetschenien unter Kontrolle. Putins Popularität steigt!");
                p.EinflussMilitär += 50;
                p.EinflussKGB += 35;
                p.LoyalitätVolk += 30; // Trotz Opfer
                p.Geld -= 400; // Kriegskosten
                p.EinflussInternational -= 35; // Menschenrechtsvorwürfe
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Chodorkowski verhaftet 2003",
            "25. Oktober: Öl-Tycoon Michail Chodorkowski - reichster Mann Russlands - verhaftet!",
            "Präsident", 0, 2003, "politisch",
            p => {
                Console.WriteLine("2005: 10 Jahre Lager wegen Steuerhinterziehung. Yukos zerschlagen, Rosneft übernimmt!");
                p.LoyalitätPartei += 40;
                p.EinflussKGB += 30;
                p.Geld += 300; // Staat übernimmt Yukos-Vermögen
                p.LoyalitätVolk += 20; // Oligarchen bestraft
                p.EinflussInternational -= 30; // Kritik an Willkür
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Wiederwahl und Föderalreform 2004",
            "14. März: Putin mit 71% wiedergewählt! Nach Beslan-Tragödie: Gouverneurs-Direktwahlen abgeschafft...",
            "Präsident", 0, 2004, "politisch",
            p => {
                Console.WriteLine("Präsident ernennt fortan Regionschefs direkt! 'Machtvertikale' massiv gestärkt.");
                p.LoyalitätPartei += 50;
                p.EinflussKGB += 40;
                p.EinflussMilitär += 30;
                p.LoyalitätVolk += 15;
                p.EinflussInternational -= 25; // Demokratie-Abbau
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Sowjet-Nostalgie 2005",
            "25. April: Putin nennt Zerfall der UdSSR 'größte geopolitische Katastrophe des Jahrhunderts'!",
            "Präsident", 0, 2005, "politisch",
            p => {
                Console.WriteLine("Signal: Russlands Größe soll wiederhergestellt werden! Westen besorgt.");
                p.LoyalitätPartei += 35;
                p.LoyalitätVolk += 40; // Nostalgie
                p.EinflussInternational -= 20;
                p.EinflussKGB += 20;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Münchner Sicherheitskonferenz 2007",
            "10. Februar: Putin überrascht mit scharfer Kritik an USA und 'unipolarer' Weltordnung!",
            "Präsident", 0, 2007, "politisch",
            p => {
                Console.WriteLine("Warnung vor neuer Konfrontation! Beginn eines 'Kalten Tons' im Ost-West-Verhältnis.");
                p.LoyalitätPartei += 40;
                p.LoyalitätVolk += 35;
                p.EinflussInternational += 20; // Selbstbewusster
                p.EinflussMilitär += 25;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Ämtertausch mit Medwedew 2008",
            "8. Mai: Putin wird Premierminister, Medwedew Präsident! 'Tandem-Lösung' umgeht Verfassung...",
            "Präsident", 0, 2008, "politisch",
            p => {
                Console.WriteLine("Putin bleibt faktisch der starke Mann! Ermöglicht spätere Rückkehr ins Präsidentenamt.");
                p.LoyalitätPartei += 45;
                p.EinflussKGB += 35;
                p.LoyalitätVolk += 20;
                p.Geld += 200;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Krieg gegen Georgien 2008",
            "8.-12. August: Russland führt Blitzkrieg gegen Georgien! Abchasien und Südossetien besetzt...",
            "Präsident", 0, 2008, "politisch",
            p => {
                Console.WriteLine("Russland erkennt Regionen als unabhängig an! International scharf kritisiert, im Land gefeiert.");
                p.EinflussMilitär += 50;
                p.LoyalitätVolk += 40;
                p.LoyalitätPartei += 35;
                p.Geld -= 250; // Kriegskosten
                p.EinflussInternational -= 45;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Proteste gegen Wahlmanipulation 2011",
            "Dezember 2011: Größte Anti-Regierungs-Proteste seit den 90ern! Zehntausende in Moskau...",
            "Präsident", 0, 2011, "politisch",
            p => {
                Console.WriteLine("Protest gegen Wahlfälschungen und Putin-Medwedew-Rollentausch! Putin antwortet mit Repression.");
                p.LoyalitätVolk -= 35;
                p.LoyalitätPartei -= 15;
                p.EinflussKGB += 30; // Härtere Gesetze
                p.EinflussInternational -= 20;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Rückkehr ins Präsidentenamt 2012",
            "4. März: Putin für dritte Amtszeit gewählt (64%)! Amtszeit nun 6 Jahre statt 4...",
            "Präsident", 0, 2012, "politisch",
            p => {
                Console.WriteLine("7. Mai: Amtseinführung mit Protesten! Kreml verschärft Gesetze gegen Opposition und NGOs.");
                p.LoyalitätPartei += 50;
                p.EinflussKGB += 40;
                p.LoyalitätVolk += 25;
                p.Geld += 250;
                p.EinflussInternational -= 25;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Olympische Spiele Sotschi 2014",
            "Februar: Russland richtet teuerste Winterspiele aller Zeiten aus! Milliarden-Prestigeprojekt...",
            "Präsident", 0, 2014, "politisch",
            p => {
                Console.WriteLine("Russlands Wiedererstarken demonstriert! Doch einen Monat später folgt Krim-Annexion...");
                p.LoyalitätVolk += 45;
                p.LoyalitätPartei += 35;
                p.Geld -= 500; // Enorme Kosten
                p.EinflussInternational += 30;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Krim-Annexion 2014",
            "18. März: Putin annektiert die Krim! 'Grüne Männchen' besetzen Halbinsel, umstrittenes Referendum...",
            "Präsident", 0, 2014, "politisch",
            p => {
                Console.WriteLine("In Russland gefeiert! Westliche Sanktionen und Ausschluss aus G8 folgen.");
                p.LoyalitätVolk += 60; // Euphorie
                p.LoyalitätPartei += 50;
                p.EinflussMilitär += 40;
                p.Geld -= 300;
                p.EinflussInternational -= 60;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Krieg in Ostukraine 2014",
            "Ab April: Prorussische Separatisten in Donezk und Luhansk! Verdeckte russische Unterstützung...",
            "Präsident", 0, 2014, "politisch",
            p => {
                Console.WriteLine("Langwieriger Konflikt bis 2022. Über 13.000 Tote. Minsker Abkommen brüchig.");
                p.EinflussMilitär += 35;
                p.LoyalitätPartei += 30;
                p.Geld -= 400;
                p.EinflussInternational -= 50;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Mord an Boris Nemzow 2015",
            "27. Februar: Oppositionspolitiker Boris Nemzow unweit des Kreml erschossen!",
            "Präsident", 0, 2015, "politisch",
            p => {
                Console.WriteLine("Hunderttausende beim Trauermarsch. Hintermänner ungeklärt. Kritische Stimmen in Lebensgefahr!");
                p.LoyalitätVolk -= 30;
                p.EinflussKGB += 25; // Einschüchterung
                p.EinflussInternational -= 35;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Militäreinsatz Syrien 2015",
            "30. September: Russland greift in syrischen Bürgerkrieg ein! Luftwaffe bombardiert Rebellen...",
            "Präsident", 0, 2015, "politisch",
            p => {
                Console.WriteLine("Assad gerettet, Russland als Weltmacht zurück! Militärbasen Tartus und Hmeimim gesichert.");
                p.EinflussMilitär += 45;
                p.EinflussInternational += 35;
                p.LoyalitätPartei += 40;
                p.LoyalitätVolk += 30;
                p.Geld -= 350; // Kriegskosten
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Vierte Amtszeit 2018",
            "18. März: Putin mit 77% wiedergewählt! Unpopuläre Rentenreform folgt...",
            "Präsident", 0, 2018, "politisch",
            p => {
                Console.WriteLine("Ruhestandsalter um 5 Jahre angehoben! Zustimmung sinkt von 80% auf 60%.");
                p.LoyalitätPartei += 40;
                p.EinflussKGB += 30;
                p.LoyalitätVolk -= 25; // Rentenreform
                p.Geld += 200;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Krim-Brücke eröffnet 2018",
            "Mai: Putin eröffnet persönlich 18 km Brücke von Russland zur Krim!",
            "Präsident", 0, 2018, "politisch",
            p => {
                Console.WriteLine("Symbol der Krim-Integration! 2022 im Ukrainekrieg zum Angriffsziel.");
                p.LoyalitätVolk += 35;
                p.LoyalitätPartei += 30;
                p.Geld -= 400; // Baukosten
                p.EinflussInternational -= 20;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Verfassungsänderung 2020",
            "1. Juli: Referendum über Verfassungsreform! 'Nullstellung' ermöglicht Putin Präsidentschaft bis 2036...",
            "Präsident", 0, 2020, "politisch",
            p => {
                Console.WriteLine("78% Zustimmung (offiziell). Kritiker sprechen von Machtsicherung auf Lebenszeit!");
                p.LoyalitätPartei += 50;
                p.EinflussKGB += 40;
                p.LoyalitätVolk += 20;
                p.EinflussInternational -= 30;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Lebenslange Immunität 2020",
            "Dezember: Putin unterschreibt Gesetz für lebenslange Immunität von Ex-Präsidenten!",
            "Präsident", 0, 2020, "politisch",
            p => {
                Console.WriteLine("Garantiert Schutz vor Strafverfolgung - auch für Putin selbst!");
                p.LoyalitätPartei += 35;
                p.EinflussKGB += 30;
                p.LoyalitätVolk -= 15;
                p.EinflussInternational -= 25;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Anschlag auf Nawalny 2020",
            "20. August: Oppositionsführer Alexei Nawalny mit Nowitschok vergiftet!",
            "Präsident", 0, 2020, "politisch",
            p => {
                Console.WriteLine("Zur Behandlung nach Deutschland. Nawalny bezichtigt Putin persönlich! Neue Sanktionen.");
                p.LoyalitätVolk -= 25;
                p.EinflussKGB += 30; // Einschüchterung
                p.EinflussInternational -= 40;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Ausschaltung der Opposition 2021",
            "17. Januar: Nawalny bei Rückkehr verhaftet! Später zu 30+ Jahren Haft verurteilt...",
            "Präsident", 0, 2021, "politisch",
            p => {
                Console.WriteLine("Nawalnys Organisationen verboten, kritische Medien geschlossen. Opposition ausgeschaltet!");
                p.LoyalitätPartei += 40;
                p.EinflussKGB += 45;
                p.LoyalitätVolk -= 30;
                p.EinflussInternational -= 45;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "'Ein Volk'-Aufsatz 2021",
            "Juli: Putin publiziert Aufsatz: Russen und Ukrainer sind 'ein Volk'...",
            "Präsident", 0, 2021, "politisch",
            p => {
                Console.WriteLine("Ideologische Rechtfertigung für territoriale Ansprüche! Vorwand für Invasion 2022.");
                p.LoyalitätPartei += 35;
                p.LoyalitätVolk += 25;
                p.EinflussInternational -= 30;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Großinvasion Ukraine 2022",
            "24. Februar: Putin befiehlt umfassende Invasion der Ukraine! 'Spezialoperation zur Entnazifizierung'...",
            "Präsident", 0, 2022, "politisch",
            p => {
                Console.WriteLine("Größter Konflikt in Europa seit 1945! Beispiellose Sanktionen, Russland isoliert.");
                p.EinflussMilitär += 40;
                p.LoyalitätPartei += 45;
                p.LoyalitätVolk += 30; // Anfangs
                p.Geld -= 900; // Kriegskosten
                p.EinflussInternational -= 80;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Kriegszensur 2022",
            "4. März: Gesetz gegen 'Verleumdung der Armee' - bis zu 15 Jahre Haft!",
            "Präsident", 0, 2022, "politisch",
            p => {
                Console.WriteLine("Unabhängige Medien blockiert oder geflohen. Proteste erstickt. Totale Informationskontrolle!");
                p.EinflussKGB += 50;
                p.LoyalitätPartei += 35;
                p.LoyalitätVolk -= 20;
                p.EinflussInternational -= 50;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "IStGH-Haftbefehl 2023",
            "17. März: Internationaler Strafgerichtshof erlässt Haftbefehl gegen Putin wegen Kriegsverbrechen!",
            "Präsident", 0, 2023, "politisch",
            p => {
                Console.WriteLine("Vorwurf: Deportation ukrainischer Kinder. Putin international offiziell angeklagt!");
                p.LoyalitätPartei += 30; // 'Siegsmentalität'
                p.LoyalitätVolk += 15;
                p.EinflussInternational -= 60;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Wagner-Meuterei 2023",
            "23./24. Juni: Jewgeni Prigoschin startet bewaffneten Aufstand! Wagner marschiert auf Moskau...",
            "Präsident", 0, 2023, "politisch",
            p => {
                Console.WriteLine("Putin nennt es 'Verrat'! Nach 24h beendet. Prigoschin stirbt im August bei Flugzeugabsturz.");
                p.EinflussMilitär -= 30; // Risse im Apparat
                p.EinflussKGB += 25; // Härte nach Meuterei
                p.LoyalitätVolk -= 25;
                p.LoyalitätPartei -= 20;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Fünfte Amtszeit 2024",
            "17. März: Putin bei inszenierter Wahl mit 87% 'wiedergewählt'. Keine echten Gegenkandidaten...",
            "Präsident", 0, 2024, "politisch",
            p => {
                Console.WriteLine("7. Mai: Amtsantritt. Amtszeit bis 2030. Über zwei Jahrzehnte an der Macht!");
                p.LoyalitätPartei += 50;
                p.EinflussKGB += 40;
                p.LoyalitätVolk += 15;
                p.Geld += 150;
                p.EinflussInternational -= 40;
            }
        ));
        
        // ═══════════════════════════════════════════════════════════
        // TÜRKEI-RUSSLAND BEZIEHUNGEN (1952-2025)
        // Historische Ereignisse der bilateralen Beziehungen
        // ═══════════════════════════════════════════════════════════
        
        allEvents.Add(new RandomEvent(
            "Türkei tritt NATO bei 1952",
            "Türkei wird NATO-Mitglied! Klare Westbindung, sowjetische Einflusserwartungen zurückgedrängt...",
            "Präsident", 0, 1952, "türkei",
            p => {
                Console.WriteLine("Türkei wählt westliche Allianz! Russlands Unsicherheit steigt.");
                p.TürkeiBeziehung -= 30;
                p.EinflussInternational -= 15;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Sowjetische Gebietsansprüche aufgegeben 1953",
            "Nach Stalins Tod: USSR verzichtet auf Bosporus-Ansprüche gegen Türkei...",
            "Präsident", 0, 1953, "türkei",
            p => {
                Console.WriteLine("Erste Annäherung! Spannungen um Bosporus-Kontrolle gehen zurück.");
                p.TürkeiBeziehung += 15;
                p.EinflussInternational += 10;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Kuba-Krise 1962",
            "Abtausch: USA zieht Jupiter-Raketen aus Türkei ab, USSR aus Kuba...",
            "Präsident", 0, 1962, "türkei",
            p => {
                Console.WriteLine("Nukleare Bedrohung endet! Ost-West-Entspannung.");
                p.TürkeiBeziehung += 10;
                p.EinflussInternational += 15;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Türkei-Russland Freundschaftsvertrag 1992",
            "25. Mai: Präsident Demirel besucht Moskau! Freundschaftsvertrag unterzeichnet...",
            "Präsident", 0, 1992, "türkei",
            p => {
                Console.WriteLine("Normalisierung nach Sowjet-Zerfall! Handel, Energie, Tourismus intensiviert.");
                p.TürkeiBeziehung += 30;
                p.Geld += 200;
                p.EinflussInternational += 20;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Blue Stream Pipeline-Vertrag 1997",
            "Gas-Pipeline-Abkommen! 16 Mrd. m³ russisches Erdgas pro Jahr für Türkei...",
            "Präsident", 0, 1997, "türkei",
            p => {
                Console.WriteLine("Langfristige Energiekooperation beginnt!");
                p.TürkeiBeziehung += 25;
                p.Geld += 300;
                p.EinflussInternational += 15;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Blue Stream beginnt Betrieb 2003",
            "Pipeline liefert! Russland deckt 56% des türkischen Erdgasbedarfs...",
            "Präsident", 0, 2003, "türkei",
            p => {
                Console.WriteLine("Energieversorgung steigt massiv! Wirtschaftswachstum.");
                p.TürkeiBeziehung += 30;
                p.Geld += 400;
                p.EinflussInternational += 20;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Akkuyu-Atomkraftwerk-Vertrag 2010",
            "Türkei und Russland: Bau von Kernkraftwerk Akkuyu (20 Mrd. USD)...",
            "Präsident", 0, 2010, "türkei",
            p => {
                Console.WriteLine("Russland baut türkische Nuklearenergie! Technologie-Transfer.");
                p.TürkeiBeziehung += 35;
                p.Geld += 500;
                p.EinflussInternational += 25;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "TurkStream-Initiative 2014",
            "Putin verkündet neue Pipeline! Ersatz für Südstraßen-Projekt...",
            "Präsident", 0, 2014, "türkei",
            p => {
                Console.WriteLine("Neue direkte Gaspipeline geplant! Umgehung der Ukraine.");
                p.TürkeiBeziehung += 25;
                p.Geld += 300;
                p.EinflussInternational += 20;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Su-24-Abschuss 2015",
            "24. November: Türkei schießt russischen Bomber über Syrien ab! KRISE...",
            "Präsident", 0, 2015, "türkei",
            p => {
                Console.WriteLine("Strafmaßnahmen! Tourismus-Stopp, Lebensmittel-Verbot. Türkei verliert 840 Mio. USD!");
                p.TürkeiBeziehung -= 60;
                p.Geld -= 400;
                p.EinflussInternational -= 30;
                p.LoyalitätVolk -= 25;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Erdogans Entschuldigung 2016",
            "Juni: Erdogan entschuldigt sich! August: Treffen in St. Petersburg...",
            "Präsident", 0, 2016, "türkei",
            p => {
                Console.WriteLine("Sanktionen aufgehoben! Handel und Tourismus erholen sich rasch.");
                p.TürkeiBeziehung += 50;
                p.Geld += 350;
                p.EinflussInternational += 25;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Botschafter Karlow ermordet 2016",
            "Dezember: Russischer Botschafter in Ankara erschossen! Diplomatische Krise...",
            "Präsident", 0, 2016, "türkei",
            p => {
                Console.WriteLine("Schockmoment! Krise aber vermieden, Beziehungen normalisieren sich.");
                p.TürkeiBeziehung -= 15;
                p.EinflussInternational -= 10;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Visumfreiheit für Türken 2017",
            "Juni: Russland hebt Sanktionen auf! Visa-Lockerung für türkische Bürger...",
            "Präsident", 0, 2017, "türkei",
            p => {
                Console.WriteLine("Reisefreiheit wiederhergestellt! Tourismus-Boom.");
                p.TürkeiBeziehung += 30;
                p.Geld += 200;
                p.LoyalitätVolk += 15;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "S-400-Kaufvertrag 2017",
            "Türkei kauft russisches Flugabwehrsystem S-400! USA verärgert...",
            "Präsident", 0, 2017, "türkei",
            p => {
                Console.WriteLine("Militär-Upgrade für Türkei! NATO-Spannung, US-Sanktionen folgen.");
                p.TürkeiBeziehung += 40;
                p.Geld += 300;
                p.EinflussMilitär += 30;
                p.EinflussInternational -= 25; // NATO verärgert
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "TurkStream eröffnet 2020",
            "Januar: Putin und Erdogan eröffnen TurkStream-Pipeline! 31,5 Mrd. m³/Jahr...",
            "Präsident", 0, 2020, "türkei",
            p => {
                Console.WriteLine("Gas fließt direkt an Türkei und weiter nach Europa! Energiesicherheit.");
                p.TürkeiBeziehung += 35;
                p.Geld += 600;
                p.EinflussInternational += 30;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Eskalation Nordsyrien 2020",
            "Februar: Türkei schießt syrische Su-24 ab! Russland auf Assad-Seite...",
            "Präsident", 0, 2020, "türkei",
            p => {
                Console.WriteLine("Militärischer Konflikt! Kriegerische Spannung zwischen Russland und Türkei.");
                p.TürkeiBeziehung -= 40;
                p.EinflussMilitär += 20;
                p.EinflussInternational -= 20;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Idlib-Waffenruhe 2020",
            "März: Putin und Erdogan verkünden Waffenstillstand in Nordsyrien...",
            "Präsident", 0, 2020, "türkei",
            p => {
                Console.WriteLine("Deeskalation! Sicherheitskorridor, Flüchtlingskrise entspannt sich.");
                p.TürkeiBeziehung += 30;
                p.LoyalitätVolk += 20;
                p.EinflussInternational += 25;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Ukraine-Krieg & Handelspartner 2022",
            "Türkei bleibt Russlands größter Partner! 54 Mrd. USD Handelsvolumen...",
            "Präsident", 0, 2022, "türkei",
            p => {
                Console.WriteLine("Türkei tritt nicht in Sanktionen ein! Vermittelt Schwarzmeer-Getreideabkommen.");
                p.TürkeiBeziehung += 40;
                p.Geld += 700;
                p.EinflussInternational += 30;
                p.LoyalitätPartei += 20;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Sotschi-Gipfel August 2022",
            "Putin-Erdogan Treffen! Intensivierung Handel, Gas in Rubel, Getreide-Deal...",
            "Präsident", 0, 2022, "türkei",
            p => {
                Console.WriteLine("Bilateraler Handel ausgebaut! Mediator-Rolle gestärkt.");
                p.TürkeiBeziehung += 30;
                p.Geld += 500;
                p.EinflussInternational += 25;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Getreide-Abkommen Gespräche 2023",
            "September: Sotschi - Wiederaufnahme Ukraine-Getreide-Deal besprochen...",
            "Präsident", 0, 2023, "türkei",
            p => {
                Console.WriteLine("Türkische Vermittlung! Nahrungssicherheit für globale Lieferketten.");
                p.TürkeiBeziehung += 25;
                p.Geld += 300;
                p.EinflussInternational += 30;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "SCO-Gipfel Astana 2024",
            "Juli: Erdogan-Putin besprechen Sinop-Nuklearprojekt! Ziel: 100 Mrd. USD Handel...",
            "Präsident", 0, 2024, "türkei",
            p => {
                Console.WriteLine("2. Atomkraftwerk geplant! Handelsvolumen-Hochziel gesetzt.");
                p.TürkeiBeziehung += 35;
                p.Geld += 600;
                p.EinflussInternational += 30;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "TurkStream-Drohnenangriff 2025",
            "Januar: Ukraine greift TurkStream-Station an! Russische Medien: 'Energie-Terrorismus'...",
            "Präsident", 0, 2025, "türkei",
            p => {
                Console.WriteLine("Pipeline beschädigt! Energieversorgungsrisiko, Kosten für Reparatur.");
                p.TürkeiBeziehung -= 20;
                p.Geld -= 300;
                p.EinflussInternational -= 15;
            }
        ));
        
        // ═══════════════════════════════════════════════════════════
        // DEUTSCHLAND-RUSSLAND BEZIEHUNGEN (2000-2024)
        // Historische Ereignisse der bilateralen Beziehungen
        // ═══════════════════════════════════════════════════════════
        
        allEvents.Add(new RandomEvent(
            "Deutsch-russischer Gipfel Berlin 2000",
            "Schröder und Putin vereinbaren 'strategische Partnerschaft'! Deutschland will Russland modernisieren...",
            "Präsident", 0, 2000, "deutschland",
            p => {
                Console.WriteLine("Beginn enger Zusammenarbeit! Wirtschaftliche und politische Kooperation.");
                p.Geld += 300;
                p.EinflussInternational += 25;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Putin-Rede im Bundestag 2001",
            "25. September: Putin spricht im Deutschen Bundestag! Wunsch nach 'Großeuropa' und echter Partnerschaft...",
            "Präsident", 0, 2001, "deutschland",
            p => {
                Console.WriteLine("Historischer Moment! Putin auf Deutsch: 'Niemand bezweifelt den großen Wert der Beziehungen'.");
                p.Geld += 200;
                p.EinflussInternational += 30;
                p.LoyalitätPartei += 15;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Regierungskonsultationen Weimar 2002",
            "Jährliche deutsch-russische Konsultationen institutionalisiert! Themen: Schulden, NATO, Wirtschaft...",
            "Präsident", 0, 2002, "deutschland",
            p => {
                Console.WriteLine("Regelmäßiger Dialog etabliert! Schröder und Putin persönlich eng.");
                p.Geld += 250;
                p.EinflussInternational += 20;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Nord Stream 1 Planung 2003",
            "Gasleitung durch Ostsee geplant! Direkte Verbindung Russland-Deutschland, ohne Transitländer...",
            "Präsident", 0, 2003, "deutschland",
            p => {
                Console.WriteLine("Strategisches Energieprojekt! Deutschland wird abhängig von russischem Gas.");
                p.Geld += 500;
                p.EinflussInternational += 30;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Schröder wird Rosneft-Aufsichtsrat 2005",
            "Ex-Kanzler Schröder wechselt zu russischer Ölfirma! Kontroverse in Deutschland...",
            "Präsident", 0, 2005, "deutschland",
            p => {
                Console.WriteLine("'Genosse der Bosse' - Schröder arbeitet für Russland! Kritik, aber gute Beziehungen.");
                p.Geld += 300;
                p.EinflussInternational += 15;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Merkel trifft Putin in Moskau 2006",
            "Neue Kanzlerin, neuer Ton! Merkel betont 'strategische Partnerschaft', aber kritischer...",
            "Präsident", 0, 2006, "deutschland",
            p => {
                Console.WriteLine("Keine DDR-'Völkerfreundschaft' mehr! Pragmatische Zusammenarbeit.");
                p.Geld += 200;
                p.EinflussInternational += 20;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Modernisierungspartnerschaft 2008",
            "Merkel und Putin: Partnerschaft für Wirtschafts-Modernisierung! Aber: Fehlende Voraussetzungen...",
            "Präsident", 0, 2008, "deutschland",
            p => {
                Console.WriteLine("Scheitert an mangelnder Rechtsstaatlichkeit und Zivilgesellschaft in Russland.");
                p.Geld += 150;
                p.EinflussInternational += 10;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Nord Stream 1 in Betrieb 2011",
            "Erste Gaslieferung durch Ostsee-Pipeline! 55 Mrd. m³/Jahr, Deutschland wird Hauptabnehmer...",
            "Präsident", 0, 2011, "deutschland",
            p => {
                Console.WriteLine("Energieabhängigkeit steigt! Aber: günstiges Gas für deutsche Industrie.");
                p.Geld += 700;
                p.EinflussInternational += 25;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Krim-Annexion & Sanktionen 2014",
            "Deutschland verhängt Sanktionen! Regierungskonsultationen eingestellt, Beziehungen dramatisch verschlechtert...",
            "Präsident", 0, 2014, "deutschland",
            p => {
                Console.WriteLine("Merkel verurteilt Völkerrechtsbruch! Aber: Nord Stream 2 wird trotzdem geplant.");
                p.Geld -= 400;
                p.EinflussInternational -= 30;
                p.LoyalitätPartei -= 20;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Nord Stream 2 Planung beginnt 2015",
            "Zweite Pipeline trotz Krim-Krise! Deutschland: 'Wirtschaftsprojekt'. USA und Osteuropa: Kritik...",
            "Präsident", 0, 2015, "deutschland",
            p => {
                Console.WriteLine("Kontroverse in EU! Deutschland verteidigt Energiesicherheit.");
                p.Geld += 600;
                p.EinflussInternational -= 15; // EU-Partner verärgert
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Tiergarten-Mord Berlin 2019",
            "August: Tschetschenischer Dissident in Berlin erschossen! Russischer Agent verdächtigt...",
            "Präsident", 0, 2019, "deutschland",
            p => {
                Console.WriteLine("Deutschland weist russische Diplomaten aus! Beziehungen weiter belastet.");
                p.EinflussInternational -= 20;
                p.Geld -= 100;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Nawalny in Berlin behandelt 2020",
            "August: Vergifteter Nawalny nach Deutschland geflogen! Nowitschok nachgewiesen...",
            "Präsident", 0, 2020, "deutschland",
            p => {
                Console.WriteLine("Deutschland fordert Aufklärung! Putin schweigt, Beziehungen auf Tiefpunkt.");
                p.EinflussInternational -= 25;
                p.Geld -= 150;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Nord Stream 2 fertiggestellt 2021",
            "September: Pipeline fertig! Aber: Keine Genehmigung wegen Ukraine-Spannungen...",
            "Präsident", 0, 2021, "deutschland",
            p => {
                Console.WriteLine("11 Mrd. Euro Investition! USA drohen mit Sanktionen gegen Deutschland.");
                p.Geld += 400;
                p.EinflussInternational -= 20;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Scholz 'Zeitenwende'-Rede 2022",
            "27. Februar: Drei Tage nach Ukraine-Invasion! Bundeskanzler Scholz im Bundestag...",
            "Präsident", 0, 2022, "deutschland",
            p => {
                Console.WriteLine("'Zeitenwende'! Deutschland erhöht Militärausgaben massiv, Nord Stream 2 gestoppt!");
                p.Geld -= 800;
                p.EinflussInternational -= 50;
                p.EinflussMilitär -= 25;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Nord Stream Sabotage 2022",
            "September: Explosionen an Nord Stream 1 und 2! Pipelines zerstört, Täter unklar...",
            "Präsident", 0, 2022, "deutschland",
            p => {
                Console.WriteLine("Wer war es? Ukraine? Russland? USA? Gasleitungen unbrauchbar!");
                p.Geld -= 600;
                p.EinflussInternational -= 30;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Cyberangriffe auf Deutschland 2023",
            "Russische Hacker greifen SPD und Bundestag an! APT28-Gruppe (GRU) identifiziert...",
            "Präsident", 0, 2023, "deutschland",
            p => {
                Console.WriteLine("Digitaler Krieg! Deutschland ruft Botschafter zu Konsultationen zurück.");
                p.EinflussInternational -= 25;
                p.EinflussKGB += 15; // Cyber-Erfolg
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Deutschland größter EU-Unterstützer Ukraine 2024",
            "Deutschland liefert Waffen für 28 Mrd. Euro! Beziehungen zu Russland auf absolutem Tiefpunkt...",
            "Präsident", 0, 2024, "deutschland",
            p => {
                Console.WriteLine("Leopard-Panzer, Patriot-Systeme! Russland bezeichnet Deutschland als 'Kriegspartei'.");
                p.Geld -= 500;
                p.EinflussInternational -= 40;
                p.EinflussMilitär -= 20;
            }
        ));
        
        // ═══════════════════════════════════════════════════════════
        // SCHULDEN-RÜCKZAHLUNGS-EVENTS (Dynamisch)
        // Werden ausgelöst wenn Schulden bei Türkei zu hoch werden
        // ═══════════════════════════════════════════════════════════
        
        allEvents.Add(new RandomEvent(
            "Türkei fordert Schuldenrückzahlung",
            "Erdogan ruft an! Türkei fordert Rückzahlung der geliehenen Gelder...",
            "Präsident", 0, 0, "schulden",
            p => {
                if (p.ErdoganSchulden > 0)
                {
                    Console.WriteLine($"\n💳 Aktuelle Schulden: {p.ErdoganSchulden} Rubel");
                    Console.WriteLine($"💰 Verfügbares Geld: {p.Geld} Rubel\n");
                    
                    if (p.Geld >= p.ErdoganSchulden)
                    {
                        Console.WriteLine("[1] Vollständig zurückzahlen");
                        Console.WriteLine("[2] Teilweise zurückzahlen (50%)");
                        Console.WriteLine("[3] Verhandeln (Stundung)");
                        Console.Write("\nWähle [1-3]: ");
                        
                        string wahl = Console.ReadLine();
                        
                        if (wahl == "1")
                        {
                            p.Geld -= p.ErdoganSchulden;
                            p.TürkeiBeziehung += 30;
                            Console.WriteLine($"\n✓ Alle Schulden beglichen! Türkei sehr zufrieden.");
                            p.ErdoganSchulden = 0;
                        }
                        else if (wahl == "2")
                        {
                            int zahlung = p.ErdoganSchulden / 2;
                            p.Geld -= zahlung;
                            p.ErdoganSchulden -= zahlung;
                            p.TürkeiBeziehung += 10;
                            Console.WriteLine($"\n✓ {zahlung} Rubel zurückgezahlt. Restschuld: {p.ErdoganSchulden}");
                        }
                        else
                        {
                            p.TürkeiBeziehung -= 20;
                            p.ErdoganSchulden = (int)(p.ErdoganSchulden * 1.15); // +15% Verzugszinsen
                            Console.WriteLine($"\n⚠ Stundung gewährt, aber +15% Verzugszinsen! Neue Schuld: {p.ErdoganSchulden}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("❌ Nicht genug Geld zur Rückzahlung!");
                        p.TürkeiBeziehung -= 30;
                        p.EinflussInternational -= 20;
                        p.ErdoganSchulden = (int)(p.ErdoganSchulden * 1.20); // +20% Strafzinsen
                        Console.WriteLine($"⚠ Türkei verärgert! +20% Strafzinsen. Neue Schuld: {p.ErdoganSchulden}");
                    }
                }
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Schulden-Krise mit Türkei",
            "Wirtschaftsministerium warnt! Schulden bei Türkei gefährden Staatshaushalt...",
            "Präsident", 0, 0, "schulden",
            p => {
                if (p.ErdoganSchulden > 2000)
                {
                    Console.WriteLine($"\n🚨 SCHULDEN-ALARM: {p.ErdoganSchulden} Rubel bei Türkei!");
                    Console.WriteLine("Erdogan droht mit Handelssanktionen!\n");
                    
                    Console.WriteLine("[1] Sofort zahlen (alles)");
                    Console.WriteLine("[2] Gas-Export erhöhen (Schulden reduzieren)");
                    Console.WriteLine("[3] Vermögen einfrieren lassen");
                    Console.Write("\nWähle [1-3]: ");
                    
                    string wahl = Console.ReadLine();
                    
                    if (wahl == "1")
                    {
                        if (p.Geld >= p.ErdoganSchulden)
                        {
                            p.Geld -= p.ErdoganSchulden;
                            p.TürkeiBeziehung += 40;
                            Console.WriteLine("\n✓ Krise abgewendet! Türkei hochzufrieden.");
                            p.ErdoganSchulden = 0;
                        }
                        else
                        {
                            Console.WriteLine("\n❌ Nicht genug Geld! Türkei droht mit Abbruch der Beziehungen!");
                            p.TürkeiBeziehung -= 50;
                            p.EinflussInternational -= 40;
                        }
                    }
                    else if (wahl == "2")
                    {
                        int reduktion = 800;
                        p.ErdoganSchulden -= reduktion;
                        p.TürkeiBeziehung += 20;
                        Console.WriteLine($"\n✓ Gas-Deal! Schulden um {reduktion} Rubel reduziert. Rest: {p.ErdoganSchulden}");
                    }
                    else
                    {
                        p.TürkeiBeziehung -= 60;
                        p.EinflussInternational -= 50;
                        p.Geld -= 500; // Vermögen eingefroren
                        Console.WriteLine("\n⚠ Türkei friert russische Vermögen ein! Diplomatischer GAU!");
                        Console.WriteLine("Schulden bleiben bestehen, 500 Rubel verloren!");
                    }
                }
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Erdogan bietet Schuldenerlass an",
            "Überraschung! Erdogan bietet teilweisen Schuldenerlass gegen politisches Entgegenkommen...",
            "Präsident", 0, 0, "schulden",
            p => {
                if (p.ErdoganSchulden > 1000 && p.TürkeiBeziehung > 70)
                {
                    int erlass = p.ErdoganSchulden / 3;
                    
                    Console.WriteLine($"\n🎁 GROSSZÜGIGES ANGEBOT!");
                    Console.WriteLine($"Erdogan erlässt {erlass} Rubel Schulden!");
                    Console.WriteLine("Bedingung: Russland unterstützt Türkei in UN-Abstimmung.\n");
                    
                    Console.WriteLine("[1] Annehmen");
                    Console.WriteLine("[2] Ablehnen");
                    Console.Write("\nWähle [1-2]: ");
                    
                    if (Console.ReadLine() == "1")
                    {
                        p.ErdoganSchulden -= erlass;
                        p.TürkeiBeziehung += 25;
                        p.EinflussInternational -= 10; // UN-Abstimmung kostet Image
                        Console.WriteLine($"\n✓ Schulden reduziert! Neue Schuld: {p.ErdoganSchulden} Rubel");
                        Console.WriteLine("Russland stimmt für Türkei in UN.");
                    }
                    else
                    {
                        p.TürkeiBeziehung -= 15;
                        Console.WriteLine("\nAbgelehnt. Schulden bleiben bestehen.");
                    }
                }
            }
        ));
        
        // ═══════════════════════════════════════════════════════════
        // FIKTIVE EREIGNISSE AB 2025+
        // Spekulative Zukunfts-Events für verlängerten Spielspaß
        // ═══════════════════════════════════════════════════════════
        
        allEvents.Add(new RandomEvent(
            "Arktis-Konflikt 2026",
            "Streit um neu entdeckte Bodenschätze! NATO vs. Russland in der Arktis...",
            "Präsident", 0, 2026, "fiktiv",
            p => {
                Console.WriteLine("\n[1] Militärische Eskalation");
                Console.WriteLine("[2] Diplomatische Lösung");
                Console.Write("Wähle [1-2]: ");
                
                if (Console.ReadLine() == "1")
                {
                    p.EinflussMilitär += 30;
                    p.Geld -= 300; // Kriegskosten
                    p.LoyalitätVolk -= 30;
                    p.EinflussInternational -= 40;
                    Console.WriteLine("Russland besetzt arktische Inseln! Weltweite Sanktionen.");
                }
                else
                {
                    p.EinflussInternational += 20;
                    p.LoyalitätVolk += 15;
                    p.Geld += 100; // Handel
                    Console.WriteLine("Friedensabkommen erzielt. Russland erhält Schürfrechte.");
                }
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "KI-Revolution 2028",
            "Russische KI 'Sputnik-Mind' übertrifft westliche Konkurrenz! Wirtschaftsboom...",
            "Präsident", 0, 2028, "fiktiv",
            p => {
                Console.WriteLine("Russland wird zum Tech-Giganten!");
                p.Geld += 500;
                p.LoyalitätVolk += 20;
                p.EinflussInternational += 25;
                p.LoyalitätPartei += 15;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Cyber-Angriff 2030",
            "Massiver Cyberangriff legt Infrastruktur lahm! Stromausfälle, Chaos...",
            "Präsident", 0, 2030, "fiktiv",
            p => {
                Console.WriteLine("Wer steckt dahinter? China? USA? Innere Feinde?");
                p.Gesundheit -= 25;
                p.Geld -= 250;
                p.LoyalitätVolk -= 40;
                p.EinflussKGB += 20; // Sicherheitsapparat gestärkt
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Klima-Kollaps Sibirien 2032",
            "Permafrost schmilzt! Methan-Freisetzung, Städte sinken ein...",
            "Präsident", 0, 2032, "fiktiv",
            p => {
                Console.WriteLine("Umweltkatastrophe biblischen Ausmaßes in Sibirien.");
                p.Gesundheit -= 20;
                p.Geld -= 400; // Umsiedlungen
                p.LoyalitätVolk -= 35;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Eurasische Union 2035",
            "Russland, China, Indien gründen Eurasische Union! Neue Weltordnung?",
            "Präsident", 0, 2035, "fiktiv",
            p => {
                Console.WriteLine("Geopolitische Neuordnung! Der Westen ist besorgt...");
                p.EinflussInternational += 50;
                p.Geld += 300;
                p.LoyalitätPartei += 30;
                p.LoyalitätVolk += 25;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Mars-Kolonie 2040",
            "Russland landet als erste Nation auf dem Mars! Nationale Euphorie...",
            "Präsident", 0, 2040, "fiktiv",
            p => {
                Console.WriteLine("🚀 Russischer Kosmonaut betritt Mars! Weltweit gefeiert!");
                p.Geld -= 200; // Kosten
                p.LoyalitätVolk += 40;
                p.EinflussInternational += 35;
                p.LoyalitätPartei += 20;
            }
        ));
        
        // ═══════════════════════════════════════════════════════════
        // KGB EASTER EGGS - SELTENE GEHEIME EVENTS
        // Zufallsprinzip: Niedrige Chance (5-15%), besondere Belohnungen
        // ═══════════════════════════════════════════════════════════
        
        allEvents.Add(new RandomEvent(
            "🕵️ KGB-Archiv entdeckt!",
            "Ein vergessenes Archiv mit Geheimdokumenten wurde gefunden...",
            "KGB", 5, 0, "kgb_easter",
            p => {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(@"
        ╔════════════════════════════════════════════╗
        ║   🕵️ KGB GEHEIMES ARCHIV 🕵️               ║
        ║   ☭ STRENG VERTRAULICH ☭                  ║
        ╚════════════════════════════════════════════╝
                ");
                Console.ResetColor();
                
                Console.WriteLine("\n📂 Du findest ein verstaubtes Dossier...");
                Thread.Sleep(1500);
                Console.WriteLine("\n🔍 Inhalt:");
                Console.WriteLine("   - Operation 'Roter Schatten' (1976)");
                Console.WriteLine("   - Agentennamen im Westen");
                Console.WriteLine("   - Unbekannte Atombunker-Koordinaten");
                Console.WriteLine("   - Persönliche Akte von Breschnew");
                
                Console.WriteLine("\n[1] Dokumente vernichten (Sicher spielen)");
                Console.WriteLine("[2] Dokumente behalten (Erpressungsmaterial)");
                Console.WriteLine("[3] Dokumente an CIA verkaufen ($$$ aber riskant!)");
                Console.Write("\nWähle [1-3]: ");
                
                string choice = Console.ReadLine();
                
                Console.Clear();
                if (choice == "1")
                {
                    Console.WriteLine("\n🔥 Dokumente verbrannt!");
                    Console.WriteLine("\n✓ Keine Spuren, keine Gefahr.");
                    p.EinflussKGB += 5; // Loyalität gezeigt
                }
                else if (choice == "2")
                {
                    Console.WriteLine("\n💼 Dokumente sicher versteckt!");
                    Console.WriteLine("\n✓ Erpressungsmaterial gesammelt!");
                    p.EinflussKGB += 30;
                    p.LoyalitätPartei += 20;
                    p.Geld += 150;
                    Console.WriteLine($"\n💻 KGB-Einfluss: +30 (jetzt {p.EinflussKGB})");
                    Console.WriteLine($"🏛️  Loyalität Partei: +20 (jetzt {p.LoyalitätPartei})");
                    Console.WriteLine($"💰 Geld: +150 Rubel (jetzt {p.Geld})");
                }
                else
                {
                    // Riskanter Verkauf
                    if (rand.Next(100) < 40)
                    {
                        Console.WriteLine("\n💰 CIA zahlt $$$!");
                        p.Geld += 500;
                        p.EinflussKGB -= 50; // Verräter!
                        p.LoyalitätPartei -= 40;
                        Console.WriteLine($"\n💰 Geld: +500 Rubel!");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"⚠️  KGB-Einfluss: -50 (VERRÄTER!)");
                        Console.WriteLine($"⚠️  Loyalität Partei: -40");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n💀 AUFGEFLOGEN!");
                        Console.WriteLine("\n⚠️  KGB hat die Operation entdeckt!");
                        p.EinflussKGB -= 80;
                        p.Geld -= 200;
                        p.Gesundheit -= 40;
                        Console.WriteLine($"\n💻 KGB-Einfluss: -80 (jetzt {p.EinflussKGB})");
                        Console.WriteLine($"💰 Geld: -200 Rubel (Strafe!)");
                        Console.WriteLine($"❤️  Gesundheit: -40 (Verhör!)");
                        Console.ResetColor();
                    }
                }
                
                Console.WriteLine("\n[Drücke eine Taste...]");
                Console.ReadKey(true);
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "🎯 Geheime KGB-Mission",
            "Ein alter KGB-Kontakt bietet dir eine geheime Mission an...",
            "KGB", 8, 0, "kgb_easter",
            p => {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(@"
        ╔════════════════════════════════════════════╗
        ║   🎯 GEHEIME MISSION 🎯                    ║
        ║   ☭ NUR FÜR AGENTEN ☭                     ║
        ╚════════════════════════════════════════════╝
                ");
                Console.ResetColor();
                
                Console.WriteLine("\n📞 Spätabends klingelt das Telefon...");
                Thread.Sleep(1500);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n'Genosse... Wir brauchen jemanden für eine... heikle Aufgabe.'");
                Console.ResetColor();
                Thread.Sleep(1000);
                
                Console.WriteLine("\n🎯 Mission: Einen Überläufer in Berlin 'zurückholen'");
                Console.WriteLine("\n⚠️  Risiko: HOCH");
                Console.WriteLine("💰 Belohnung: EXZELLENT");
                
                Console.WriteLine("\n[1] Mission annehmen");
                Console.WriteLine("[2] Zu riskant - ablehnen");
                Console.Write("\nWähle [1-2]: ");
                
                if (Console.ReadLine() == "1")
                {
                    Console.Clear();
                    Console.WriteLine("\n✈️  Flug nach Berlin...");
                    Thread.Sleep(1500);
                    
                    // Zufälliger Ausgang
                    int erfolg = rand.Next(100);
                    
                    if (erfolg < 60)
                    {
                        // Erfolg
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n✓ MISSION ERFOLGREICH!");
                        Console.ResetColor();
                        Console.WriteLine("\n🎖️  Der Überläufer wurde 'überzeugt' zurückzukehren.");
                        Console.WriteLine("🏆 KGB ist sehr zufrieden!");
                        
                        p.EinflussKGB += 50;
                        p.Geld += 300;
                        p.LoyalitätPartei += 30;
                        p.Charisma += 2;
                        
                        Console.WriteLine($"\n💻 KGB-Einfluss: +50 (jetzt {p.EinflussKGB})");
                        Console.WriteLine($"💰 Geld: +300 Rubel");
                        Console.WriteLine($"🎭 Charisma: +2");
                    }
                    else if (erfolg < 85)
                    {
                        // Teilerfolg
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("\n⚠️  MISSION TEILWEISE ERFOLGREICH");
                        Console.ResetColor();
                        Console.WriteLine("\n📰 Die Mission verlief nicht ganz nach Plan...");
                        Console.WriteLine("Aber keine Spuren führen zu dir.");
                        
                        p.EinflussKGB += 20;
                        p.Geld += 100;
                        p.Gesundheit -= 15;
                        
                        Console.WriteLine($"\n💻 KGB-Einfluss: +20");
                        Console.WriteLine($"❤️  Gesundheit: -15 (Stress)");
                    }
                    else
                    {
                        // Fehlschlag
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n💀 MISSION FEHLGESCHLAGEN!");
                        Console.ResetColor();
                        Console.WriteLine("\n⚠️  Der Überläufer entkam zur CIA!");
                        Console.WriteLine("📰 Internationaler Skandal!");
                        
                        p.EinflussKGB -= 30;
                        p.EinflussInternational -= 25;
                        p.Gesundheit -= 30;
                        
                        Console.WriteLine($"\n💻 KGB-Einfluss: -30");
                        Console.WriteLine($"🌍 Internationales Ansehen: -25");
                        Console.WriteLine($"❤️  Gesundheit: -30");
                    }
                }
                else
                {
                    Console.WriteLine("\n→ Mission abgelehnt.");
                    Console.WriteLine("\n'Schade... Du warst unsere erste Wahl.'");
                    p.EinflussKGB -= 10;
                }
                
                Console.WriteLine("\n[Drücke eine Taste...]");
                Console.ReadKey(true);
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "🔐 KGB-Safe entdeckt",
            "Bei Renovierungsarbeiten im Kreml wird ein alter KGB-Safe gefunden...",
            "Präsident", 10, 0, "kgb_easter",
            p => {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(@"
        ╔════════════════════════════════════════════╗
        ║   🔐 VERGESSENER KGB-SAFE 🔐              ║
        ║   ☭ KOMBINATIONSSCHLOSS ☭                 ║
        ╚════════════════════════════════════════════╝
                ");
                Console.ResetColor();
                
                Console.WriteLine("\n🔨 Arbeiter finden einen alten Safe hinter der Wand...");
                Thread.Sleep(1500);
                Console.WriteLine("\n🔐 Rostiges Kombinationsschloss: _ _ _ _");
                Console.WriteLine("\n💡 Hinweis auf Rückseite: 'Jahr des Sieges'");
                
                Console.Write("\n🔢 Gib die 4-stellige Kombination ein: ");
                string code = Console.ReadLine();
                
                Console.Clear();
                
                if (code == "1945")
                {
                    // Richtige Kombination!
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n✓ *KLICK* - SAFE GEÖFFNET!");
                    Console.ResetColor();
                    Thread.Sleep(1000);
                    
                    Console.WriteLine("\n📦 Inhalt:");
                    Console.WriteLine("   💰 50.000 Rubel in Gold");
                    Console.WriteLine("   📜 Originaldokumente von Stalin");
                    Console.WriteLine("   🎖️  Lenin-Orden (selten!)");
                    Console.WriteLine("   🗝️  Schlüssel zu geheimem Bunker");
                    
                    p.Geld += 500;
                    p.EinflussKGB += 40;
                    p.LoyalitätPartei += 25;
                    p.EinflussInternational += 20;
                    
                    Console.WriteLine("\n🎉 JACKPOT!");
                    Console.WriteLine($"💰 Geld: +500 Rubel");
                    Console.WriteLine($"💻 KGB-Einfluss: +40");
                    Console.WriteLine($"🏛️  Loyalität Partei: +25");
                    Console.WriteLine($"🌍 Internationales Ansehen: +20 (historische Dokumente!)");
                }
                else if (code == "1917" || code == "1941" || code == "1991")
                {
                    // Falsch, aber historisch relevant
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n⚠️  Falsche Kombination...");
                    Console.ResetColor();
                    Console.WriteLine($"\n'{code}' - auch ein wichtiges Jahr, aber nicht das richtige!");
                    Console.WriteLine("\n🔧 Safe wird aufgebrochen...");
                    Thread.Sleep(1500);
                    
                    Console.WriteLine("\n📦 Inhalt (teilweise beschädigt):");
                    Console.WriteLine("   💰 10.000 Rubel");
                    Console.WriteLine("   📄 Vergilbte Dokumente");
                    
                    p.Geld += 150;
                    p.EinflussKGB += 10;
                    
                    Console.WriteLine($"\n💰 Geld: +150 Rubel");
                    Console.WriteLine($"💻 KGB-Einfluss: +10");
                }
                else
                {
                    // Komplett falsch
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n❌ FALSCHE KOMBINATION!");
                    Console.ResetColor();
                    Console.WriteLine("\n⚠️  Safe-Mechanismus blockiert!");
                    Console.WriteLine("\n🔧 Muss von Experten geöffnet werden...");
                    Thread.Sleep(1500);
                    
                    Console.WriteLine("\n📦 Inhalt (von Experten entnommen):");
                    Console.WriteLine("   💰 5.000 Rubel (Finder-Prämie)");
                    
                    p.Geld += 50;
                    Console.WriteLine($"\n💰 Geld: +50 Rubel");
                }
                
                Console.WriteLine("\n[Drücke eine Taste...]");
                Console.ReadKey(true);
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "☎️ Anonymer Anruf",
            "Ein verschlüsselter Anruf erreicht dich. 'Ich weiß, wer du wirklich bist...'",
            "KGB", 5, 0, "kgb_easter",
            p => {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(@"
        ╔════════════════════════════════════════════╗
        ║   ☎️ VERSCHLÜSSELTER ANRUF ☎️             ║
        ║   ⚠️  UNKNOWN NUMBER ⚠️                    ║
        ╚════════════════════════════════════════════╝
                ");
                Console.ResetColor();
                
                Console.WriteLine("\n📞 *Ring Ring*");
                Thread.Sleep(1500);
                
                try { Console.Beep(800, 300); Console.Beep(800, 300); } catch { }
                
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\n[Verzerrte Stimme]:");
                Console.WriteLine("'Genosse... oder sollte ich sagen, Agent X-47?'");
                Thread.Sleep(1500);
                Console.WriteLine("'Ich kenne deine Vergangenheit. ALLE Geheimnisse.'");
                Thread.Sleep(1500);
                Console.WriteLine("'Ich will 1000 Rubel. Morgen. Gorky Park. Oder...'");
                Console.ResetColor();
                
                Console.WriteLine("\n[1] Bezahlen (1000 Rubel - Problem verschwindet)");
                Console.WriteLine("[2] Drohen ('Ich finde dich!')");
                Console.WriteLine("[3] Auflegen und KGB informieren");
                Console.Write("\nWähle [1-3]: ");
                
                string choice = Console.ReadLine();
                
                Console.Clear();
                
                if (choice == "1" && p.Geld >= 1000)
                {
                    Console.WriteLine("\n💰 Bezahlt...");
                    p.Geld -= 1000;
                    Console.WriteLine("\n✓ Der Anrufer verschwindet.");
                    Console.WriteLine($"💰 Geld: -1000 Rubel (jetzt {p.Geld})");
                }
                else if (choice == "1")
                {
                    Console.WriteLine("\n⚠️  Nicht genug Geld!");
                    Console.WriteLine("\n'Dann werden alle es erfahren...'");
                    p.LoyalitätPartei -= 20;
                    p.EinflussKGB -= 15;
                }
                else if (choice == "2")
                {
                    Console.WriteLine("\n😠 'WAGE ES NICHT, MICH ZU ERPRESSEN!'");
                    Thread.Sleep(1000);
                    
                    if (rand.Next(100) < 50)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n✓ Die Drohung wirkt! Er gibt auf.");
                        p.Charisma += 1;
                        Console.WriteLine("\n🎭 Charisma: +1 (Einschüchterung!)");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n⚠️  Er lacht nur und legt auf...");
                        Console.WriteLine("\n📰 Am nächsten Tag erscheinen Gerüchte in der Presse!");
                        p.LoyalitätVolk -= 15;
                        p.EinflussInternational -= 10;
                        Console.ResetColor();
                    }
                }
                else
                {
                    Console.WriteLine("\n📞 KGB informiert...");
                    Thread.Sleep(1500);
                    Console.WriteLine("\n🔍 KGB Spezialeinheit aktiviert!");
                    Thread.Sleep(1000);
                    
                    if (rand.Next(100) < 70)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n✓ Erpresser gefasst!");
                        Console.WriteLine("\n🎖️  KGB ist beeindruckt von deiner Zusammenarbeit!");
                        p.EinflussKGB += 25;
                        p.LoyalitätPartei += 15;
                        Console.WriteLine($"\n💻 KGB-Einfluss: +25");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("\n⚠️  Erpresser entkommen...");
                        Console.WriteLine("\nAber deine Geheimnisse sind sicher.");
                        p.EinflussKGB += 5;
                    }
                }
                
                Console.WriteLine("\n[Drücke eine Taste...]");
                Console.ReadKey(true);
            }
        ));
        
        // ═══════════════════════════════════════════════════════════
        // NATO-RUSSLAND BEZIEHUNGEN (2000-2025)
        // Meist negative Entwicklungen, Osterweiterung, Konflikte
        // ═══════════════════════════════════════════════════════════
        
        // 2002 - NATO-Russland-Rat
        allEvents.Add(new RandomEvent(
            "NATO-Russland-Rat 2002",
            "NATO-Gipfel in Prag: Gründung des NATO-Russland-Rats für gemeinsame Konsultationen...",
            "Präsident", 40, 2002, "nato",
            p => {
                Console.WriteLine("\n🛡️  NATO bietet Kooperationsplattform an!");
                p.NATOBeziehung += 15;
                p.EinflussInternational += 10;
                Console.WriteLine($"\n🛡️  NATO-Beziehung: +15% (jetzt {p.NATOBeziehung}%)");
                Console.WriteLine($"🌍 Internationaler Einfluss: +10");
            }
        ));
        
        // 2004 - Osterweiterung (Baltikum)
        allEvents.Add(new RandomEvent(
            "NATO-Osterweiterung 2004",
            "7 neue Mitglieder treten NATO bei (Baltikum, Polen, etc.). Russland protestiert heftig!",
            "Präsident", 70, 2004, "nato",
            p => {
                Console.WriteLine("\n⚠️  NATO erweitert sich bis an russische Grenze!");
                Console.WriteLine("\n🇪🇪 Estland | 🇱🇻 Lettland | 🇱🇹 Litauen");
                Console.WriteLine("🇵🇱 Polen | 🇧🇬 Bulgarien | 🇷🇴 Rumänien | 🇸🇰 Slowakei");
                
                p.NATOBeziehung -= 25;
                p.EinflussMilitär -= 15;
                p.LoyalitätPartei -= 20; // Gesichtsverlust
                
                Console.WriteLine($"\n🛡️  NATO-Beziehung: -25% (jetzt {p.NATOBeziehung}%)");
                Console.WriteLine($"⚔️  Militäreinfluss: -15 (Einflusszone schrumpft!)");
                Console.WriteLine($"🏛️  Loyalität Partei: -20 (Schwäche gezeigt!)");
            }
        ));
        
        // 2007 - Münchner Sicherheitskonferenz
        allEvents.Add(new RandomEvent(
            "Münchner Rede 2007",
            "Putin hält scharfe Rede: 'USA weltgefährlich! Ein Zentrum der Macht!'",
            "Präsident", 60, 2007, "nato",
            p => {
                Console.WriteLine("\n📢 Historische Rede in München!");
                Console.WriteLine("\n'Die USA als einziger Herrscher - das ist gefährlich!'");
                
                p.NATOBeziehung -= 20;
                p.LoyalitätPartei += 25; // Hardliner begeistert
                p.LoyalitätVolk += 20;
                p.EinflussInternational -= 15;
                
                Console.WriteLine($"\n🛡️  NATO-Beziehung: -20% (jetzt {p.NATOBeziehung}%)");
                Console.WriteLine($"🏛️  Loyalität Partei: +25 (Hardliner jubeln!)");
                Console.WriteLine($"👥 Loyalität Volk: +20 (Patriotismus!)");
            }
        ));
        
        // 2008 - Bukarest-Gipfel
        allEvents.Add(new RandomEvent(
            "NATO-Gipfel Bukarest 2008",
            "NATO: 'Ukraine und Georgien werden Mitglieder!' Moskau sieht dies als Provokation.",
            "Präsident", 75, 2008, "nato",
            p => {
                Console.WriteLine("\n💥 ROTE LINIE ÜBERSCHRITTEN!");
                Console.WriteLine("\n🇺🇦 Ukraine und 🇬🇪 Georgien sollen NATO beitreten!");
                
                p.NATOBeziehung -= 35;
                p.EinflussMilitär -= 25;
                p.LoyalitätPartei -= 30; // Massive Bedrohung
                
                // Aktiviere NATO-Telefon
                p.NATOTelefonAktiv = true;
                
                Console.WriteLine($"\n🛡️  NATO-Beziehung: -35% (jetzt {p.NATOBeziehung}%)");
                Console.WriteLine($"⚔️  Militäreinfluss: -25 (Sicherheit bedroht!)");
                Console.WriteLine($"🏛️  Loyalität Partei: -30 (Krise!)");
                Console.WriteLine("\n📞 NATO-Telefon wurde freigeschaltet!");
            }
        ));
        
        // 2014 - NATO nach Krim-Annexion
        allEvents.Add(new RandomEvent(
            "NATO-Verurteilung Krim 2014",
            "Nach Krim-Annexion: NATO verurteilt Russland scharf und verstärkt Ostflanke!",
            "Präsident", 80, 2014, "nato",
            p => {
                Console.WriteLine("\n⚠️  NATO-Truppen an Ostgrenze!");
                Console.WriteLine("\n📰 'Völkerrechtswidrige Annexion!'");
                Console.WriteLine("🛡️  Enhanced Forward Presence wird eingerichtet");
                
                p.NATOBeziehung -= 40;
                p.EinflussMilitär -= 30;
                p.Geld -= 150; // Sanktionen
                
                Console.WriteLine($"\n🛡️  NATO-Beziehung: -40% (jetzt {p.NATOBeziehung}%)");
                Console.WriteLine($"⚔️  Militäreinfluss: -30");
                Console.WriteLine($"💰 Geld: -150 Rubel (Sanktionen!)");
            }
        ));
        
        // 2023 - Finnland NATO-Beitritt
        allEvents.Add(new RandomEvent(
            "Finnland tritt NATO bei 2023",
            "Nach Ukraine-Krieg: Finnland tritt NATO bei! Russlands längste Grenze jetzt NATO-Grenze.",
            "Präsident", 70, 2023, "nato",
            p => {
                Console.WriteLine("\n💥 1300 KM NEUE NATO-GRENZE!");
                Console.WriteLine("\n🇫🇮 Finnland verlässt Neutralität nach Jahrzehnten");
                
                p.NATOBeziehung -= 30;
                p.EinflussMilitär -= 35; // Massive Bedrohung
                p.Geld -= 200; // Truppen verlegen
                
                Console.WriteLine($"\n🛡️  NATO-Beziehung: -30% (jetzt {p.NATOBeziehung}%)");
                Console.WriteLine($"⚔️  Militäreinfluss: -35 (Strategischer Verlust!)");
                Console.WriteLine($"💰 Geld: -200 Rubel (Truppenverlegung!)");
            }
        ));
        
        // ═══════════════════════════════════════════════════════════
        // RUSSLAND-USA BEZIEHUNGEN (2000-2025)
        // Chronologie der politischen, wirtschaftlichen und militärischen Events
        // ═══════════════════════════════════════════════════════════
        
        // 2001 - 9/11 und Kooperation
        allEvents.Add(new RandomEvent(
            "11. September 2001 - Terroranschläge",
            "Nach den Anschlägen vom 11. September bietet Russland den USA Zusammenarbeit im 'Krieg gegen den Terror' an...",
            "Präsident", 50, 2001, "usa",
            p => {
                Console.WriteLine("\n🇺🇸 Die USA wurden angegriffen! Putin bietet Kooperation an.");
                Console.WriteLine("\n[1] Zusammenarbeit anbieten (Luftbasen + Geheimdienstinfo)");
                Console.WriteLine("[2] Neutral bleiben");
                Console.Write("\nWähle [1-2]: ");
                
                if (Console.ReadLine() == "1")
                {
                    Console.WriteLine("\n✓ Russland stellt Luftbasen bereit und teilt Informationen!");
                    p.EinflussInternational += 25;
                    p.LoyalitätPartei += 15;
                    p.Geld += 50; // Kompensation
                }
                else
                {
                    Console.WriteLine("\n→ Russland bleibt neutral.");
                    p.EinflussInternational -= 10;
                }
            }
        ));
        
        // 2003 - Irakkrieg
        allEvents.Add(new RandomEvent(
            "Irakkrieg 2003",
            "Die USA planen Invasion im Irak. Russland kann in der UN mit Veto drohen...",
            "Präsident", 60, 2003, "usa",
            p => {
                Console.WriteLine("\n⚠️ USA bereiten Irakkrieg vor!");
                Console.WriteLine("\n[1] Veto in UN androhen (Anti-Kriegsposition)");
                Console.WriteLine("[2] Abwarten und nicht einmischen");
                Console.Write("\nWähle [1-2]: ");
                
                if (Console.ReadLine() == "1")
                {
                    Console.WriteLine("\n✓ Russland droht mit Veto! USA ignorieren es und marschieren trotzdem ein.");
                    p.EinflussInternational += 20; // Anti-Kriegs-Ansehen
                    p.LoyalitätVolk += 15;
                    p.Geld -= 30; // Wirtschaftliche Spannungen
                }
                else
                {
                    Console.WriteLine("\n→ Russland bleibt passiv.");
                    p.EinflussInternational -= 15;
                }
            }
        ));
        
        // 2004 - NATO-Osterweiterung
        allEvents.Add(new RandomEvent(
            "NATO-Osterweiterung 2004",
            "Am 2. März 2004 treten sieben Staaten der NATO bei (Baltikum, Rumänien...). Moskau sieht dies als Bedrohung.",
            "Präsident", 70, 2004, "usa",
            p => {
                Console.WriteLine("\n🛡️ NATO erweitert sich nach Osten!");
                p.EinflussInternational -= 20; // Einfluss-Verlust
                p.EinflussMilitär -= 15;
                p.LoyalitätPartei -= 10; // Innenpolitischer Druck
                Console.WriteLine("\n⚠️ Beziehungen zur NATO verschlechtern sich dramatisch!");
            }
        ));
        
        // 2008 - Georgien-Krieg
        allEvents.Add(new RandomEvent(
            "Kaukasuskrieg 2008",
            "Konflikt um Südossetien eskaliert. Russland kann militärisch eingreifen...",
            "Präsident", 65, 2008, "usa",
            p => {
                Console.WriteLine("\n⚔️ Georgien greift Südossetien an!");
                Console.WriteLine("\n[1] Militärisch eingreifen (Invasion)");
                Console.WriteLine("[2] Diplomatisch reagieren");
                Console.Write("\nWähle [1-2]: ");
                
                if (Console.ReadLine() == "1")
                {
                    Console.WriteLine("\n✓ Russische Truppen marschieren ein! Südossetien und Abchasien werden besetzt.");
                    p.EinflussMilitär += 30;
                    p.EinflussInternational -= 35; // Internationale Verurteilung
                    p.Geld -= 80; // Kriegskosten
                    p.LoyalitätVolk += 20; // Patriotismus
                }
                else
                {
                    Console.WriteLine("\n→ Russland bleibt zurückhaltend.");
                    p.LoyalitätPartei -= 20; // Als schwach gesehen
                }
            }
        ));
        
        // 2008 - NATO-Beitrittsversprechen
        allEvents.Add(new RandomEvent(
            "NATO-Gipfel Bukarest 2008",
            "NATO verspricht Ukraine und Georgien Beitrittsperspektive. Moskau ist verärgert!",
            "Präsident", 55, 2008, "usa",
            p => {
                Console.WriteLine("\n🛡️ NATO öffnet Tür für Ukraine und Georgien!");
                p.EinflussInternational -= 25;
                p.EinflussMilitär -= 20;
                p.LoyalitätPartei -= 15;
                Console.WriteLine("\n⚠️ Dies wird als direkte Bedrohung gesehen!");
            }
        ));
        
        // 2010 - New START
        allEvents.Add(new RandomEvent(
            "New START Vertrag 2010",
            "Obama und Medwedew unterzeichnen neuen Abrüstungsvertrag. Hoffnung auf bessere Beziehungen...",
            "Präsident", 45, 2010, "usa",
            p => {
                Console.WriteLine("\n🕊️ Neue Abrüstungsvereinbarung unterzeichnet!");
                p.EinflussInternational += 20;
                p.EinflussMilitär -= 10; // Arsenale begrenzt
                p.LoyalitätVolk += 10;
                Console.WriteLine("\n✓ Strategische Stabilität verbessert sich!");
            }
        ));
        
        // 2014 - Krim-Annexion
        allEvents.Add(new RandomEvent(
            "Krim-Annexion 2014",
            "Nach Maidan-Revolution in Kiew: Russland kann die Krim annektieren...",
            "Präsident", 75, 2014, "usa",
            p => {
                Console.WriteLine("\n🇺🇦 Ukraine in Chaos! Krim-Referendum steht bevor.");
                Console.WriteLine("\n[1] Krim annektieren ('grüne Männchen' einsetzen)");
                Console.WriteLine("[2] Nicht einmischen");
                Console.Write("\nWähle [1-2]: ");
                
                if (Console.ReadLine() == "1")
                {
                    Console.WriteLine("\n✓ Krim ist jetzt russisch! Sewastopol gesichert.");
                    p.EinflussMilitär += 40; // Schwarzmeerflotte
                    p.EinflussInternational -= 50; // Massive Verurteilung
                    p.Geld -= 150; // Sanktionen folgen
                    p.LoyalitätVolk += 35; // Patriotischer Rausch
                    p.LoyalitätPartei += 25;
                    Console.WriteLine("\n⚠️ USA und EU verhängen Sanktionen!");
                }
                else
                {
                    Console.WriteLine("\n→ Krim bleibt ukrainisch.");
                    p.LoyalitätPartei -= 30; // Als Verräter gesehen
                }
            }
        ));
        
        // 2014 - G8 Ausschluss
        allEvents.Add(new RandomEvent(
            "Ausschluss aus G8 (2014)",
            "Nach Krim-Annexion: G7 boykottiert Gipfel in Sotschi. Russland wird ausgeschlossen.",
            "Präsident", 60, 2014, "usa",
            p => {
                Console.WriteLine("\n🚫 Russland aus G8 (jetzt G7) ausgeschlossen!");
                p.EinflussInternational -= 30;
                p.LoyalitätPartei -= 15;
                p.Geld -= 50;
                Console.WriteLine("\n⚠️ Internationale Isolation verstärkt sich!");
            }
        ));
        
        // 2015 - Syrien-Intervention
        allEvents.Add(new RandomEvent(
            "Syrien-Intervention 2015",
            "Assad-Regime droht zu fallen. Russland kann militärisch in Syrien intervenieren...",
            "Präsident", 55, 2015, "usa",
            p => {
                Console.WriteLine("\n🇸🇾 Bürgerkrieg in Syrien eskaliert!");
                Console.WriteLine("\n[1] Militärisch Assad unterstützen (Luftangriffe)");
                Console.WriteLine("[2] Nicht eingreifen");
                Console.Write("\nWähle [1-2]: ");
                
                if (Console.ReadLine() == "1")
                {
                    Console.WriteLine("\n✓ Russische Luftwaffe greift ein! Stützpunkt Latakia eröffnet.");
                    p.EinflussMilitär += 35;
                    p.EinflussInternational -= 20; // 'Benzin ins Feuer'
                    p.Geld -= 100; // Kriegskosten
                    p.LoyalitätVolk += 25; // Gegen Islamisten
                }
                else
                {
                    Console.WriteLine("\n→ Russland bleibt raus.");
                    p.EinflussInternational -= 25; // Einfluss-Verlust in Nahost
                }
            }
        ));
        
        // 2016 - US-Wahleinmischung
        allEvents.Add(new RandomEvent(
            "US-Wahl 2016 - Cyberoperation",
            "US-Präsidentschaftswahl steht bevor. GRU plant Cyberoperation zur Einflussnahme...",
            "Präsident", 40, 2016, "usa",
            p => {
                Console.WriteLine("\n💻 Geheimoperation: US-Wahl beeinflussen?");
                Console.WriteLine("\n[1] Cyberangriff genehmigen (DNC hacken, Desinformation)");
                Console.WriteLine("[2] Ablehnen (zu riskant)");
                Console.Write("\nWähle [1-2]: ");
                
                if (Console.ReadLine() == "1")
                {
                    Console.WriteLine("\n✓ Operation läuft! 'Fancy Bear' hackt DNC-Server.");
                    p.EinflussKGB += 30;
                    p.EinflussInternational += 15; // Kurzfristig
                    // Später Entdeckung:
                    if (rand.Next(100) < 70)
                    {
                        Console.WriteLine("\n⚠️ SPÄTER: Operation aufgedeckt! Skandal!");
                        p.EinflussInternational -= 45;
                        p.Geld -= 100; // Sanktionen
                    }
                }
                else
                {
                    Console.WriteLine("\n→ Operation abgelehnt.");
                }
            }
        ));
        
        // 2017 - CAATSA Sanktionen
        allEvents.Add(new RandomEvent(
            "CAATSA-Sanktionen 2017",
            "US-Kongress verabschiedet umfassendes Sanktionsgesetz gegen Russland...",
            "Präsident", 65, 2017, "usa",
            p => {
                Console.WriteLine("\n💳 USA verhängen dauerhafte Sanktionen (CAATSA)!");
                p.Geld -= 200;
                p.EinflussInternational -= 25;
                p.LoyalitätPartei -= 20; // Wirtschaftlicher Druck
                Console.WriteLine("\n⚠️ Russische Wirtschaft leidet stark!");
            }
        ));
        
        // 2018 - Helsinki-Gipfel
        allEvents.Add(new RandomEvent(
            "Trump-Putin Gipfel Helsinki 2018",
            "Präsident Trump trifft Putin in Helsinki. Eine Annäherung ist möglich...",
            "Präsident", 50, 2018, "usa",
            p => {
                Console.WriteLine("\n🤝 Historisches Treffen mit Donald Trump!");
                Console.WriteLine("\nTrump: 'I don't see any reason why it would be Russia...'");
                p.EinflussInternational += 20;
                p.LoyalitätVolk += 15;
                p.Geld += 50;
                Console.WriteLine("\n✓ Beziehungen verbessern sich vorübergehend!");
                
                // Aktiviere Trump-Telefon Easter Egg
                p.TrumpTelefonAktiv = true;
                Console.WriteLine("\n📞 Das 'Trump-Telefon' wurde freigeschaltet!");
            }
        ));
        
        // 2018 - INF-Vertrag endet
        allEvents.Add(new RandomEvent(
            "Ende des INF-Vertrags 2018",
            "Trump kündigt INF-Raketenvertrag. Rüstungsspirale droht...",
            "Präsident", 55, 2018, "usa",
            p => {
                Console.WriteLine("\n🚀 USA steigen aus INF-Vertrag aus!");
                Console.WriteLine("\n[1] Auch aussteigen (Wettrüsten)");
                Console.WriteLine("[2] Im Vertrag bleiben");
                Console.Write("\nWähle [1-2]: ");
                
                if (Console.ReadLine() == "1")
                {
                    Console.WriteLine("\n✓ Russland steigt ebenfalls aus!");
                    p.EinflussMilitär += 25;
                    p.Geld -= 120; // Aufrüstungskosten
                    p.EinflussInternational -= 20;
                }
                else
                {
                    Console.WriteLine("\n→ Russland bleibt im Vertrag.");
                    p.EinflussMilitär -= 15; // Nachteil
                }
            }
        ));
        
        // 2019 - Nord Stream 2 Sanktionen
        allEvents.Add(new RandomEvent(
            "Nord Stream 2 Sanktionen 2019",
            "USA drohen mit Sanktionen gegen Pipeline-Verlegefirmen...",
            "Präsident", 60, 2019, "usa",
            p => {
                Console.WriteLine("\n⛽ USA sanktionieren Nord Stream 2!");
                p.Geld -= 80; // Pipeline-Verzögerung
                p.EinflussInternational -= 15;
                Console.WriteLine("\n⚠️ Pipeline-Bau verzögert sich!");
            }
        ));
        
        // 2019 - Terrorabwehr-Kooperation
        allEvents.Add(new RandomEvent(
            "Terrorabwehr-Kooperation 2019",
            "US-Geheimdienste warnen vor Anschlag in Russland. Putin dankt Trump persönlich...",
            "Präsident", 35, 2019, "usa",
            p => {
                Console.WriteLine("\n🔒 CIA warnt vor Terroranschlag in St. Petersburg!");
                Console.WriteLine("\n✓ Anschlag verhindert! Trump und Putin telefonieren.");
                p.EinflussInternational += 15;
                p.LoyalitätVolk += 10;
                p.Gesundheit = Math.Min(100, p.Gesundheit + 5);
            }
        ));
        
        // 2020 - SolarWinds Cyberangriff
        allEvents.Add(new RandomEvent(
            "SolarWinds-Hack 2020",
            "GRU plant massiven Cyberangriff auf US-Netzwerke via SolarWinds...",
            "Präsident", 45, 2020, "usa",
            p => {
                Console.WriteLine("\n💻 Massive Spionageoperation möglich...");
                Console.WriteLine("\n[1] Operation durchführen (Großes Risiko!)");
                Console.WriteLine("[2] Zu riskant - ablehnen");
                Console.Write("\nWähle [1-2]: ");
                
                if (Console.ReadLine() == "1")
                {
                    Console.WriteLine("\n✓ SolarWinds infiltriert! Tausende US-Systeme kompromittiert.");
                    p.EinflussKGB += 40;
                    p.Geld -= 50;
                    // Später Entdeckung
                    Console.WriteLine("\n⚠️ SPÄTER: Hack aufgedeckt! Massive Gegensanktionen!");
                    p.EinflussInternational -= 50;
                    p.Geld -= 150;
                }
                else
                {
                    Console.WriteLine("\n→ Operation zu riskant - abgelehnt.");
                }
            }
        ));
        
        // 2021 - Biden "Killer"-Äußerung
        allEvents.Add(new RandomEvent(
            "Biden nennt Putin 'Killer' 2021",
            "Neuer US-Präsident Biden bezeichnet Putin als 'Killer'. Diplomatischer Eklat!",
            "Präsident", 70, 2021, "usa",
            p => {
                Console.WriteLine("\n😠 Biden: 'Putin is a killer!'");
                Console.WriteLine("\n[1] Botschafter zurückrufen (harte Reaktion)");
                Console.WriteLine("[2] Ignorieren");
                Console.Write("\nWähle [1-2]: ");
                
                if (Console.ReadLine() == "1")
                {
                    Console.WriteLine("\n✓ Russischer Botschafter zurückgerufen!");
                    p.EinflussInternational -= 25;
                    p.LoyalitätPartei += 15; // Zeigt Stärke
                    p.LoyalitätVolk += 10;
                }
                else
                {
                    Console.WriteLine("\n→ Russland ignoriert die Beleidigung.");
                    p.LoyalitätPartei -= 15; // Als schwach gesehen
                }
            }
        ));
        
        // 2021 - New START Verlängerung
        allEvents.Add(new RandomEvent(
            "New START Verlängerung 2021",
            "Kurz vor Ablauf: Biden bietet Verlängerung um 5 Jahre an...",
            "Präsident", 50, 2021, "usa",
            p => {
                Console.WriteLine("\n🕊️ USA bieten Verlängerung von New START an!");
                Console.WriteLine("\n[1] Zustimmen (Abrüstung)");
                Console.WriteLine("[2] Ablehnen");
                Console.Write("\nWähle [1-2]: ");
                
                if (Console.ReadLine() == "1")
                {
                    Console.WriteLine("\n✓ Vertrag verlängert bis 2026!");
                    p.EinflussInternational += 20;
                    p.EinflussMilitär -= 5;
                    Console.WriteLine("\n✓ Strategische Stabilität wiederhergestellt!");
                }
                else
                {
                    Console.WriteLine("\n→ Vertrag läuft aus. Rüstungswettlauf!");
                    p.EinflussMilitär += 15;
                    p.EinflussInternational -= 25;
                }
            }
        ));
        
        // 2022 - Ukraine-Invasion
        allEvents.Add(new RandomEvent(
            "Ukraine-Invasion 24. Feb. 2022",
            "Entscheidung: Umfassende Invasion der Ukraine oder diplomatische Lösung?",
            "Präsident", 80, 2022, "usa",
            p => {
                Console.WriteLine("\n⚔️ KRITISCHE ENTSCHEIDUNG: Ukraine-Krise eskaliert!");
                Console.WriteLine("\nNATO-Erweiterung droht, Donbass unter Beschuss...");
                Console.WriteLine("\n[1] Vollständige Invasion ('Spezialoperation')");
                Console.WriteLine("[2] Nur Donbass anerkennen (begrenzt)");
                Console.WriteLine("[3] Diplomatische Lösung suchen");
                Console.Write("\nWähle [1-3]: ");
                
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    Console.WriteLine("\n✓ 24. Februar: Russische Truppen marschieren ein!");
                    p.EinflussMilitär += 50;
                    p.EinflussInternational -= 80; // Weltweite Verurteilung
                    p.Geld -= 500; // Massive Kriegskosten + Sanktionen
                    p.LoyalitätPartei += 30;
                    p.LoyalitätVolk += 20; // Initial
                    p.Gesundheit -= 30; // Stress
                    Console.WriteLine("\n⚠️ HISTORISCHE SANKTIONEN! Wirtschaft im freien Fall!");
                    Console.WriteLine("\n⚠️ NATO verstärkt Osteuropa massiv!");
                }
                else if (choice == "2")
                {
                    Console.WriteLine("\n✓ Russland erkennt Donbass-Republiken an.");
                    p.EinflussMilitär += 20;
                    p.EinflussInternational -= 30;
                    p.Geld -= 150;
                }
                else
                {
                    Console.WriteLine("\n→ Diplomatischer Weg gewählt.");
                    p.EinflussInternational += 10;
                    p.LoyalitätPartei -= 40; // Als Verräter gebrandmarkt
                }
            }
        ));
    }
    
    /// <summary>
    /// ASCII-Art Bibliothek für Ereignisse
    /// </summary>
    static class AsciiArt
    {
        public static void ShowEventArt(string eventName, string eventType)
        {
            Console.ForegroundColor = ConsoleColor.White;
            
            // Event-spezifische ASCII-Art
            if (eventName.Contains("Erdbeben") || eventName.Contains("Kamtschatka"))
            {
                Console.WriteLine(@"
        ╱╲    ╱╲    ╱╲
       ╱  ╲  ╱  ╲  ╱  ╲
      ╱    ╲╱    ╲╱    ╲
     ╱  E R D B E B E N  ╲
    ╱______╲    ╱________╲
   ═══════════════════════");
            }
            else if (eventName.Contains("Nuklear") || eventName.Contains("Tschernobyl") || eventName.Contains("Kyshtym"))
            {
                Console.WriteLine(@"
           ___
          /   \
         /  ☢  \
        /   ︵   \
       │  (   )  │
       │   ═╤═   │
        \   │   /
    ══════════════════");
            }
            else if (eventName.Contains("Feuer") || eventName.Contains("Brand") || eventName.Contains("Waldbrände"))
            {
                Console.WriteLine(@"
      (  )   (   )  )
       ) (   )  (  (
       ( )  (    ) )
       _____________
      <_____________> ~~~
    🔥 F E U E R 🔥");
            }
            else if (eventName.Contains("Flut") || eventName.Contains("Überschwemmung") || eventName.Contains("Hochwasser"))
            {
                Console.WriteLine(@"
    ~~~~~~~~~~~~
  ~~~~~~~~~~~~~~
 ~~~ W A S S E R ~~~
~~~~~~~~~~~~~~~~
  🌊 FLUT 🌊");
            }
            else if (eventName.Contains("COVID") || eventName.Contains("Pandemie"))
            {
                Console.WriteLine(@"
        .-.
       (o.o)
        |=|
       __|__
     //.=|=.\\
    // .=|=. \\
    \\ .=|=. //
     \\(_=_)//
      (:| |:)
    🦠 VIRUS 🦠");
            }
            else if (eventName.Contains("Affäre") || eventName.Contains("Flamme"))
            {
                Console.WriteLine(@"
      ♥♥♥  ♥♥♥
    ♥♥♥♥♥♥♥♥♥♥♥
   ♥♥♥♥♥♥♥♥♥♥♥♥♥
   ♥♥♥♥♥♥♥♥♥♥♥♥♥
    ♥♥♥♥♥♥♥♥♥♥♥
      ♥♥♥♥♥♥♥
        ♥♥♥
💋 AFFÄRE 💋");
            }
            else if (eventName.Contains("Kursk") || eventName.Contains("U-Boot"))
            {
                Console.WriteLine(@"
    ~~~~~~~~~~~~~~~~~~~
   ~~~~ _________ ~~~~
  ~~~~ |_________|~~~~
 ~~~~/___________\~~~
~~~~~~~~~~~~~~~~⚓");
            }
            else if (eventName.Contains("Theater") || eventName.Contains("Geisel") || eventName.Contains("Beslan"))
            {
                Console.WriteLine(@"
    ╔════════════╗
    ║  ☠  ☠  ☠  ║
    ║  GEISEL    ║
    ║  DRAMA     ║
    ╚════════════╝
   💀 TERROR 💀");
            }
            else if (eventName.Contains("Rubel") || eventName.Contains("Finanzkrise") || eventName.Contains("Wirtschaft"))
            {
                Console.WriteLine(@"
      ╔═══╗
      ║ ₽ ║
      ╚═══╝
     /     \
    │  💸  │
     \     /
  💰 KRISE 💰");
            }
            else if (eventName.Contains("NATO"))
            {
                Console.WriteLine(@"
    ╔═══════════╗
    ║  🛡️  ★  🛡️  ║
    ║   N A T O ║
    ║  ━━━━━━━  ║
    ╚═══════════╝
   🌐 ALLIANCE 🌐");
            }
            else if (eventName.Contains("Zerfall") || eventName.Contains("Sowjetunion"))
            {
                Console.WriteLine(@"
    ⚠ ═══════════ ⚠
       ☭ UdSSR ☭
      /         \
     /___________\
    ═══════════════
   🚩 KOLLAPS 🚩");
            }
            else if (eventName.Contains("Cyber") || eventName.Contains("KI"))
            {
                Console.WriteLine(@"
    ┌─────────┐
    │░▒▓█▓▒░│
    │ 01001 │
    │ 10110 │
    └─────────┘
   💻 DIGITAL 💻");
            }
            else if (eventName.Contains("🕵️") || eventName.Contains("KGB"))
            {
                Console.WriteLine(@"
    ╔═══════════╗
    ║  🕵️  ☭  🕵️  ║
    ║   K G B   ║
    ║  ━━━━━━━  ║
    ╚═══════════╝
   🔒 SECRET 🔒");
            }
            else if (eventName.Contains("Mars") || eventName.Contains("Arktis"))
            {
                Console.WriteLine(@"
       /\
      /  \
     /____\
    |  ||  |
    |__||__|
   /|  ||  |\
  🚀 RAUM 🚀");
            }
            else if (eventName.Contains("Klima") || eventName.Contains("Hitzewelle"))
            {
                Console.WriteLine(@"
       \ | /
    -  ☀☀☀  -
       / | \
    H I T Z E
   ~~~~~~~~~~~~~~~~
   🌡️ KLIMA 🌡️");
            }
            else if (eventName.Contains("Apartmenthaus") || eventName.Contains("Bomben"))
            {
                Console.WriteLine(@"
      ___💥___
     /   |   \
    |  ___  |
    | |___| |
    |_______|
   💣 TERROR 💣");
            }
            else if (eventName.Contains("Krieg") || eventName.Contains("Konflikt") || eventName.Contains("Kuba"))
            {
                Console.WriteLine(@"
    ╔═══╗ ╔═══╗
    ║ ⚔ ║ ║ ⚔ ║
    ╚═══╝ ╚═══╝
    K R I E G
   ⚔️  KAMPF ⚔️");
            }
            else if (eventName.Contains("Union") || eventName.Contains("Eurasisch"))
            {
                Console.WriteLine(@"
    🌍═══🌏═══🌎
     U N I O N
    ═══════════
   🤝 ALLIANZ 🤝");
            }
            else if (eventType == "sidechick")
            {
                Console.WriteLine(@"
    ♡♡♡  LOVE  ♡♡♡
    ♥  SKANDAL  ♥
    ♡♡♡♡♡♡♡♡♡♡♡
   💋 AFFÄRE 💋");
            }
            else if (eventType == "fiktiv")
            {
                Console.WriteLine(@"
    ✦ ✧ ★ ✧ ✦
    Z U K U N F T
    ✦ ✧ ★ ✧ ✦
   🔮 2025+ 🔮");
            }
            else if (eventType == "usa")
            {
                Console.WriteLine(@"
    ★ ★ ★ ★ ★
    ═══════════
    ★ ★ ★ ★ ★
   🇺🇸 USA 🇺🇸");
            }
            else
            {
                // Standard Event
                Console.WriteLine(@"
    ╔═══════════╗
    ║  ⚡ ⚡ ⚡  ║
    ║  EVENT    ║
    ╚═══════════╝");
            }
            
            Console.ResetColor();
        }
    }
    
    /// <summary>
    /// AddIllegitimateChild - Hilfsfunktion für uneheliche Kinder
    /// Erstellt ein uneheliches Kind aus einer Affäre
    /// </summary>
    static void AddIllegitimateChild(PlayerCharacter player)
    {
        bool isBoyIlleg = rand.Next(2) == 0;
        Console.Write($"\nName für das uneheliche Kind: ");
        string vornameIlleg = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(vornameIlleg))
            vornameIlleg = isBoyIlleg ? "Dmitri" : "Irina";
        
        string childNameIlleg = $"{vornameIlleg} [Unehelich] Gen{player.Generation + 1}";
        
        PlayerCharacter childIlleg = new PlayerCharacter(childNameIlleg, player.Generation + 1);
        childIlleg.Alter = 0;
        childIlleg.Phase = "Kind";
        childIlleg.Geburtsjahr = player.GetCurrentYear();
        
        childIlleg.Stärke = Math.Max(0, player.Stärke + rand.Next(-2, 2));
        childIlleg.Intelligenz = Math.Max(0, player.Intelligenz + rand.Next(-2, 2));
        childIlleg.Charisma = Math.Max(0, player.Charisma + rand.Next(-2, 2));
        childIlleg.Kraft = Math.Max(0, player.Kraft + rand.Next(-2, 2));
        
        player.Kinder.Add(childIlleg);
        
        Console.WriteLine($"\n✓ {childNameIlleg} wurde geboren!");
        Console.WriteLine($"Attribute: S:{childIlleg.Stärke} I:{childIlleg.Intelligenz} C:{childIlleg.Charisma} K:{childIlleg.Kraft}");
    }
    
    /// <summary>
    /// TriggerRandomEvent - Löst ein Zufallsereignis aus
    /// 
    /// ÄNDERUNG 11: Erweitert um jahr-basierte Events
    /// 
    /// TRIGGER-ALGORITHMUS:
    /// 1. Filtere Events nach Phase UND Jahr
    /// 2. Jahr = 0: Klassisches Event, jederzeit in Phase möglich
    /// 3. Jahr > 0: Nur wenn aktuelles Spieljahr = Event-Jahr
    /// 4. Würfle für Wahrscheinlichkeit
    /// 5. Zeige Event und führe Effekte aus
    /// 
    /// BEISPIELE:
    /// - Event ohne Jahr: Kann mehrfach auftreten
    /// - Event mit Jahr 1986: Nur wenn Spieler in 1986 ist
    /// - Sidechick-Event: Zufällig, nicht jahr-gebunden
    /// - Fiktives Event 2030: Nur im Jahr 2030
    /// 
    /// Wird an kritischen Story-Punkten in jeder Phase aufgerufen.
    /// </summary>
    /// <param name="player">Der aktuelle Spieler-Charakter</param>
    public static void TriggerRandomEvent(PlayerCharacter player)
    {
        int currentYear = player.GetCurrentYear();
        
        // ═══ SCHRITT 1: FILTERE PASSENDE EVENTS ═══
        // LINQ-Abfrage: Events nach Phase UND Jahr filtern
        // ÄNDERUNG: Historische Events (mit Jahr > 0) ignorieren Phase-Check!
        var possibleEvents = allEvents.Where(e => 
        {
            // Historische Events (mit spezifischem Jahr) können in jeder Phase auftreten
            bool isHistoricalEvent = e.Jahr > 0 && 
                (e.Type == "katastrophe" || e.Type == "politisch" || 
                 e.Type == "türkei" || e.Type == "deutschland" || e.Type == "schulden");
            
            // Prüfe Phase nur bei nicht-historischen Events
            bool phaseMatch = isHistoricalEvent || e.Phase == player.Phase;
            
            // Jahr muss passen (Jahr=0 bedeutet jederzeit möglich)
            bool yearMatch = (e.Jahr == 0 || e.Jahr == currentYear);
            
            // Wahrscheinlichkeit
            bool chanceMatch = rand.Next(100) < e.Chance;
            
            return phaseMatch && yearMatch && chanceMatch;
        }).ToList();
        
        // Kein Event möglich? Beende frühzeitig
        if (possibleEvents.Count == 0) return;
        
        // ═══ SCHRITT 2: WÄHLE ZUFÄLLIGES EVENT ═══
        var chosen = possibleEvents[rand.Next(possibleEvents.Count)];
        
        // ═══ SCHRITT 3: ZEIGE EVENT MIT ASCII-ART ═══
        Console.Clear();
        
        // Zeige ASCII-Art für das Event
        AsciiArt.ShowEventArt(chosen.Name, chosen.Type);
        
        Console.WriteLine();  // Leerzeile
        
        // Event-Sound abspielen
        PlayEventSound(chosen.Type);
        
        // Spezielle Farben für Event-Typen
        if (chosen.Type == "sidechick")
            Console.ForegroundColor = ConsoleColor.Red;
        else if (chosen.Type == "kgb_easter")
            Console.ForegroundColor = ConsoleColor.DarkRed;
        else if (chosen.Type == "nato")
            Console.ForegroundColor = ConsoleColor.DarkBlue;
        else if (chosen.Type == "katastrophe" || chosen.Type == "politisch" || 
                 chosen.Type == "türkei" || chosen.Type == "deutschland" || chosen.Type == "schulden")
            Console.ForegroundColor = ConsoleColor.Yellow;
        else if (chosen.Type == "fiktiv")
            Console.ForegroundColor = ConsoleColor.Cyan;
        else if (chosen.Type == "usa")
            Console.ForegroundColor = ConsoleColor.Blue;
        else
            Console.ForegroundColor = ConsoleColor.Magenta;
            
        Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
        
        if (chosen.Type == "sidechick")
            Console.WriteLine("║                  💋 PERSÖNLICHES EVENT 💋                 ║");
        else if (chosen.Type == "katastrophe")
            Console.WriteLine($"║         🔥 KATASTROPHE {chosen.Jahr} 🔥                    ║");
        else if (chosen.Type == "politisch")
            Console.WriteLine($"║         🏛️  POLITISCHES EREIGNIS {chosen.Jahr} 🏛️           ║");
        else if (chosen.Type == "türkei")
            Console.WriteLine($"║         🇹🇷 TÜRKEI-EREIGNIS {chosen.Jahr} 🇹🇷               ║");
        else if (chosen.Type == "deutschland")
            Console.WriteLine($"║         🇩🇪 DEUTSCHLAND-EREIGNIS {chosen.Jahr} 🇩🇪           ║");
        else if (chosen.Type == "schulden")
            Console.WriteLine($"║         💳 SCHULDEN-EREIGNIS 💳                          ║");
        else if (chosen.Type == "kgb_easter")
            Console.WriteLine($"║         🕵️ KGB EASTER EGG 🕵️                             ║");
        else if (chosen.Type == "nato")
            Console.WriteLine($"║         🛡️ NATO-RUSSLAND {chosen.Jahr} 🛡️                  ║");
        else if (chosen.Type == "fiktiv")
            Console.WriteLine($"║          🔮 ZUKUNFTSEREIGNIS {chosen.Jahr} 🔮             ║");
        else if (chosen.Type == "usa")
            Console.WriteLine($"║         🇺🇸 USA-RUSSLAND {chosen.Jahr} 🇺🇸                 ║");
        else
            Console.WriteLine("║                  ⚡ ZUFALLSEREIGNIS ⚡                     ║");
            
        Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");
        Console.ResetColor();
        
        Console.WriteLine($"\n📰 {chosen.Name}\n");
        Console.WriteLine(chosen.Description);
        
        if (chosen.Type != "sidechick" && chosen.Type != "kgb_easter")  // Spezielle Events haben eigene Interaktion
        {
            Console.WriteLine("\n[Drücke eine Taste...]");
            Console.ReadKey(true);
        }
        
        // ═══ SCHRITT 4: FÜHRE EFFEKTE AUS ═══
        // Lambda-Funktion (Action<PlayerCharacter>) wird ausgeführt
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
            
            Console.WriteLine("\n[1] Einzelspieler – Flad Rusputin");
            Console.WriteLine("[2] Multiplayer (2-4 Spieler)");
            Console.WriteLine("[3] Spiel Laden");
            Console.WriteLine("[4] Stammbaum ansehen 🌳");
            Console.WriteLine("[5] Mini-Game: Schiffe versenken ⚓");
            Console.WriteLine("[6] Spielstände verwalten");
            Console.WriteLine("[7] Beenden");
            
            Console.Write("\nWähle [1-7]: ");
            string input = Console.ReadLine();
            
            switch (input)
            {
                case "1": StartNewGame(1); break;
                case "2": StartMultiplayerGame(); break;
                case "3": LoadGame(); break;
                case "4": ShowFamilyTree(); break;
                case "5":
                    stopMusic = true;
                    Thread.Sleep(200);
                    BattleshipGame.Play();
                    stopMusic = false;
                    Task.Run(() => PlayMusic());
                    break;
                case "6": ManageSaves(); break;
                case "7":
                    stopMusic = true;
                    Console.WriteLine("\n>> Auf Wiedersehen, Genosse!");
                    Thread.Sleep(1000);
                    return;
            }
        }
    }
    
    static void StartMultiplayerGame()
    {
        Console.Clear();
        Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
        Console.WriteLine("║              MULTIPLAYER-MODUS                            ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════╝\n");
        
        Console.Write("Wie viele Spieler? [2-4]: ");
        if (!int.TryParse(Console.ReadLine(), out int playerCount) || playerCount < 2 || playerCount > 4)
            playerCount = 2;
        
        StartNewGame(playerCount);
    }
    
    static void StartNewGame(int playerCount = 1)
    {
        stopMusic = true;
        Thread.Sleep(300);
        
        Console.Clear();
        
        if (playerCount == 1)
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
            Console.WriteLine("║      FLAD: AUFSTIEG IN EINER SOWJETISCHEN DYSTOPIE        ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════╝\n");
            
            Console.WriteLine("1952, Leningrad – In einer verfallenen Scheune");
            Console.WriteLine("erblickt Flad das Licht der Welt...\n");
            Thread.Sleep(2000);
        }
        else
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
            Console.WriteLine("║           MULTIPLAYER: AUFSTIEG ZUR MACHT                 ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════╝\n");
            
            Console.WriteLine($"{playerCount} Spieler treten gegeneinander an!");
            Console.WriteLine("Wer wird die mächtigste Dynastie aufbauen?\n");
            Thread.Sleep(1500);
        }
        
        // Schwierigkeitsgrad
        int difficulty = ChooseDifficulty();
        
        // Charaktere erstellen
        List<PlayerCharacter> players = new List<PlayerCharacter>();
        
        for (int i = 0; i < playerCount; i++)
        {
            Console.Clear();
            Console.WriteLine($"╔═══════════════════════════════════════════════════════════╗");
            Console.WriteLine($"║              SPIELER {i + 1} - CHARAKTERERSTELLUNG             ║");
            Console.WriteLine($"╚═══════════════════════════════════════════════════════════╝\n");
            
            string playerName;
            if (playerCount == 1)
            {
                playerName = "Flad Rusputin";
                Console.WriteLine($"Dein Name: {playerName}\n");
            }
            else
            {
                // ERZWINGE Namenseingabe im Multiplayer
                playerName = "";
                while (string.IsNullOrWhiteSpace(playerName))
                {
                    Console.Write($"Name von Spieler {i + 1} (PFLICHT): ");
                    playerName = Console.ReadLine()?.Trim();
                    
                    if (string.IsNullOrWhiteSpace(playerName))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("⚠ Name darf nicht leer sein! Bitte eingeben.");
                        Console.ResetColor();
                    }
                }
                playerName = playerName + " Rusputin"; // Füge Dynastie-Name hinzu
                Console.WriteLine();
            }
            
            PlayerCharacter player = new PlayerCharacter(playerName, 1);
            player.Alter = 0;
            
            // Attribute verteilen
            DistributeAttributes(player, difficulty);
            
            players.Add(player);
            Thread.Sleep(1000);
        }
        
        // MULTIPLAYER: Alle Spieler durchlaufen die Story
        if (playerCount > 1)
        {
            PlayMultiplayerStory(players);
        }
        else
        {
            // Singleplayer
            currentPlayer = players[0];
            PlayStory(currentPlayer);
        }
        
        // Am Ende speichern anbieten
        Console.WriteLine("\n>> Möchtest du speichern? [J/N]");
        if (Console.ReadKey(true).Key == ConsoleKey.J)
        {
            if (playerCount == 1)
            {
                SaveGame(players[0]);
            }
            else
            {
                foreach (var p in players)
                {
                    SaveGame(p);
                }
            }
        }
        
        stopMusic = false;
        Task.Run(() => PlayMusic());
    }
    
    static void PlayMultiplayerStory(List<PlayerCharacter> players)
    {
        Console.Clear();
        Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
        Console.WriteLine("║              MULTIPLAYER-KAMPAGNE                         ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════╝\n");
        
        Console.WriteLine("Alle Spieler durchlaufen parallel ihr Leben.");
        Console.WriteLine("Jeder Spieler erlebt eigene Zufallsereignisse!\n");
        Thread.Sleep(2000);
        
        // Jeder Spieler durchläuft die komplette Story
        foreach (var player in players)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
            Console.WriteLine($"║         JETZT SPIELT: {player.Name.ToUpper().PadRight(40)}║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");
            Console.ResetColor();
            Thread.Sleep(1500);
            
            currentPlayer = player;
            PlayStory(player);
            
            Console.WriteLine($"\n>> {player.Name} hat das Spiel beendet!");
            Console.WriteLine("\n[Drücke eine Taste für nächsten Spieler...]");
            Console.ReadKey(true);
        }
        
        // Zeige Endergebnis
        ShowMultiplayerResults(players);
    }
    
    static void ShowMultiplayerResults(List<PlayerCharacter> players)
    {
        Console.Clear();
        Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
        Console.WriteLine("║              MULTIPLAYER - ENDERGEBNIS                    ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════╝\n");
        
        // Sortiere nach Gesamt-Score
        var ranked = players.OrderByDescending(p => 
            p.Geld + (p.LoyalitätPartei * 10) + (p.LoyalitätVolk * 10) + 
            (p.EinflussKGB * 5) + (p.Kinder.Count * 50)
        ).ToList();
        
        Console.WriteLine("🏆 RANGLISTE:\n");
        for (int i = 0; i < ranked.Count; i++)
        {
            var p = ranked[i];
            int score = p.Geld + (p.LoyalitätPartei * 10) + (p.LoyalitätVolk * 10) + 
                        (p.EinflussKGB * 5) + (p.Kinder.Count * 50);
            
            string medal = i == 0 ? "🥇" : i == 1 ? "🥈" : i == 2 ? "🥉" : "  ";
            Console.WriteLine($"{medal} Platz {i + 1}: {p.Name}");
            Console.WriteLine($"   Score: {score} | Alter: {p.Alter} | Kinder: {p.Kinder.Count}");
            Console.WriteLine($"   Geld: {p.Geld} | Partei: {p.LoyalitätPartei}% | Volk: {p.LoyalitätVolk}%");
            Console.WriteLine($"   Phase: {p.Phase} | {(p.IstTot ? "†" : "Lebt")}\n");
        }
        
        Console.WriteLine("\n[Drücke eine Taste...]");
        Console.ReadKey(true);
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
                player.Geld = 800; // Mehr Geld
                player.NATOBeziehung = 40; // Bessere NATO-Beziehung
                player.USABeziehung = 60; // Bessere USA-Beziehung
                Console.WriteLine("LEICHT: Alle Attribute bei 1");
                Console.WriteLine("+800 Rubel | Bessere Auslandsbeziehungen");
                Console.WriteLine("Sanktionen: -25% Schaden");
                Thread.Sleep(2500);
                return;
            case 2: // Normal
                points = 3;
                player.Geld = 500;
                player.NATOBeziehung = 30;
                player.USABeziehung = 50;
                break;
            case 3: // Schwer
                points = 2;
                player.Gesundheit = 70;
                player.Geld = 300; // Weniger Geld
                player.NATOBeziehung = 20; // Schlechtere NATO-Beziehung
                player.USABeziehung = 40;
                Console.WriteLine("SCHWER: -30 Gesundheit | Weniger Geld | Schlechtere Auslandsbeziehungen");
                Thread.Sleep(1500);
                break;
            case 4: // Brutal
                points = 1;
                player.Geld = -200;
                player.EinflussKGB = 20;
                player.NATOBeziehung = 10; // Sehr schlecht
                player.USABeziehung = 30;
                Console.WriteLine("BRUTAL: Schulden | NATO-Feindschaft | Harte Sanktionen");
                Thread.Sleep(1500);
                break;
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
    
    /// <summary>
    /// ReadInputWithShortcuts - Erweiterte Eingabe mit S/L/E/Q/T-Shortcuts
    /// 
    /// FEATURE: Speichern/Laden/Erdogan-Nottelefon/Shop/Trump-Telefon während des Spiels
    /// Shortcuts: 'S' = Speichern, 'L' = Laden, 'E' = Erdogan-Nottelefon, 'Q' = Shop, 'T' = Trump-Telefon
    /// </summary>
    static string ReadInputWithShortcuts(PlayerCharacter player, string prompt = "")
    {
        if (!string.IsNullOrEmpty(prompt))
            Console.Write(prompt);
        
        while (true)
        {
            string input = Console.ReadLine()?.ToUpper();
            
            if (input == "S")
            {
                Console.WriteLine("\n>> Speichern...");
                SaveGame(player);
                Console.WriteLine(">> Gespeichert! [Taste drücken]");
                Console.ReadKey(true);
                Console.Write(prompt);  // Prompt erneut anzeigen
                continue;
            }
            else if (input == "L")
            {
                Console.WriteLine("\n>> Laden nicht verfügbar während des Spiels.");
                Console.WriteLine(">> Verwende Hauptmenü zum Laden. [Taste drücken]");
                Console.ReadKey(true);
                Console.Write(prompt);
                continue;
            }
            else if (input == "E")
            {
                // Nur als Präsident verfügbar
                if (player.Phase == "Präsident")
                {
                    Console.WriteLine("\n>> 📞 Erdogan-Nottelefon wird gewählt...");
                    Thread.Sleep(1000);
                    ErdoganHotline.ShowHotlineMenu(player);
                    Console.Clear();
                    Console.Write(prompt);  // Prompt erneut anzeigen
                    continue;
                }
                else
                {
                    Console.WriteLine("\n⚠️  Erdogan-Nottelefon erst als Präsident verfügbar!");
                    Console.WriteLine("   [Taste drücken]");
                    Console.ReadKey(true);
                    Console.Write(prompt);
                    continue;
                }
            }
            else if (input == "Q")
            {
                // Nur als Präsident verfügbar
                if (player.Phase == "Präsident")
                {
                    Console.WriteLine("\n>> 🛒 Putin's Luxus-Shop wird geöffnet...");
                    Thread.Sleep(1000);
                    PutinShop.ShowShop(player);
                    Console.Clear();
                    Console.Write(prompt);  // Prompt erneut anzeigen
                    continue;
                }
                else
                {
                    Console.WriteLine("\n⚠️  Putin's Luxus-Shop erst als Präsident verfügbar!");
                    Console.WriteLine("   [Taste drücken]");
                    Console.ReadKey(true);
                    Console.Write(prompt);
                    continue;
                }
            }
            else if (input == "T")
            {
                // Nur als Präsident verfügbar
                if (player.Phase == "Präsident")
                {
                    Console.WriteLine("\n>> 📞 Trump-Telefon klingelt...");
                    Thread.Sleep(1000);
                    TrumpHotline.CallTrump(player);
                    Console.Clear();
                    Console.Write(prompt);  // Prompt erneut anzeigen
                    continue;
                }
                else
                {
                    Console.WriteLine("\n⚠️  Trump-Telefon erst als Präsident verfügbar!");
                    Console.WriteLine("   [Taste drücken]");
                    Console.ReadKey(true);
                    Console.Write(prompt);
                    continue;
                }
            }
            else if (input == "M")
            {
                // Musik-Menü (immer verfügbar)
                Console.WriteLine("\n>> 🎵 Russische Lieder...");
                Thread.Sleep(1000);
                SoundSystem.ShowMusicMenu(player);
                Console.Clear();
                Console.Write(prompt);  // Prompt erneut anzeigen
                continue;
            }
            else if (input == "N")
            {
                // NATO-Telefon (nur als Präsident)
                if (player.Phase == "Präsident")
                {
                    Console.WriteLine("\n>> 📞 NATO-Telefon klingelt...");
                    Thread.Sleep(1000);
                    NATOHotline.CallNATO(player);
                    Console.Clear();
                    Console.Write(prompt);
                    continue;
                }
                else
                {
                    Console.WriteLine("\n⚠️  NATO-Telefon erst als Präsident verfügbar!");
                    Console.WriteLine("   [Taste drücken]");
                    Console.ReadKey(true);
                    Console.Write(prompt);
                    continue;
                }
            }
            else if (input == "F")
            {
                // Finka (nur als Präsident)
                if (player.Phase == "Präsident")
                {
                    Console.WriteLine("\n>> 🏡 Zur Finka reisen...");
                    Thread.Sleep(1000);
                    FinkaSystem.ShowFinkaMenu(player);
                    Console.Clear();
                    Console.Write(prompt);
                    continue;
                }
                else
                {
                    Console.WriteLine("\n⚠️  Finka erst als Präsident verfügbar!");
                    Console.WriteLine("   [Taste drücken]");
                    Console.ReadKey(true);
                    Console.Write(prompt);
                    continue;
                }
            }
            
            return input;
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
        
        Console.WriteLine($"{player.GetFirstName()} wächst in Armut auf. Sein Vater gibt ihm Judo-Training.\n");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("═══════════════════════════════════════════════════════════");
        Console.WriteLine("💾 Extras: 'S' = Speichern | 'L' = Laden | 'M' = 🎵 Musik");
        Console.WriteLine("═══════════════════════════════════════════════════════════\n");
        Console.ResetColor();
        Thread.Sleep(1500);
        
        // Zufallsereignis auslösen
        EventSystem.TriggerRandomEvent(player);
        
        Console.WriteLine("[1] Kämpferische Kindheit (+2 Stärke, -15 Gesundheit)");
        Console.WriteLine("[2] Disziplin durch Sport (+2 Kraft, +1 Charisma)");
        Console.WriteLine("[3] Wissbegierig (+3 Intelligenz, +1 Charisma)");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("[S/L/M] Speichern/Laden/Musik");
        Console.ResetColor();
        Console.WriteLine();
        
        string choice = ReadInputWithShortcuts(player, "Wähle [1-3 oder S/L/M]: ");
        if (choice == "1") { player.Stärke += 2; player.Gesundheit -= 15; }
        else if (choice == "2") { player.Kraft += 2; player.Charisma++; }
        else { player.Intelligenz += 3; player.Charisma++; }
        
        if (player.Intelligenz >= 2 || player.Charisma >= 2)
        {
            player.KGBEasterEgg = true;
            Console.WriteLine($"\n💀 Ein KGB-Agent beobachtet {player.GetFirstName()}...");
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
        
        Console.WriteLine($"Mit 16 marschiert {player.GetFirstName()} zur KGB-Zentrale!\n");
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
        
        Console.WriteLine($"{player.GetFirstName()} studiert Jura. Wem ist er loyal?\n");
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
    
    /// <summary>
    /// ShowShortcutReminder - Zeigt alle 5 Jahre Shortcut-Übersicht
    /// </summary>
    static void ShowShortcutReminder(PlayerCharacter player)
    {
        // Nur alle 5 Jahre anzeigen
        if (player.Alter - player.LetzteShortcutAnzeige < 5)
            return;
        
        player.LetzteShortcutAnzeige = player.Alter;
        
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(@"
        ╔════════════════════════════════════════════╗
        ║   ⌨️  SHORTCUT-ÜBERSICHT ⌨️                ║
        ╚════════════════════════════════════════════╝
        ");
        Console.ResetColor();
        
        Console.WriteLine($"📅 Alter: {player.Alter} Jahre");
        Console.WriteLine($"🎭 Phase: {player.Phase}\n");
        
        Console.WriteLine("═══ VERFÜGBARE SHORTCUTS ═══\n");
        
        Console.WriteLine("💾 SYSTEM:");
        Console.WriteLine("   'S' = Speichern");
        Console.WriteLine("   'L' = Laden\n");
        
        Console.WriteLine("🎵 UNTERHALTUNG:");
        Console.WriteLine("   'M' = Russische Lieder\n");
        
        if (player.Phase == "Präsident")
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("📞 PRÄSIDENTEN-TELEFONE:");
            Console.WriteLine("   'E' = Erdogan-Hotline");
            Console.WriteLine("   'T' = Trump-Telefon");
            Console.WriteLine("   'N' = NATO-Telefon\n");
            
            Console.WriteLine("🏡 ERHOLUNG:");
            Console.WriteLine($"   'F' = Finka besuchen (Gesundheit: {player.Gesundheit}%)\n");
            
            Console.WriteLine("🛒 LUXUS:");
            Console.WriteLine("   'Q' = Putin's Shop\n");
            Console.ResetColor();
        }
        
        Console.WriteLine("💡 Tipp: Diese Shortcuts funktionieren bei jeder Auswahl!");
        Console.WriteLine("\n[Drücke eine Taste...]");
        Console.ReadKey(true);
    }
    
    static void PlayDDRPhase(PlayerCharacter player)
    {
        player.Alter = 35;
        player.Phase = "DDR-Einsatz";
        
        // 5-Jahres Shortcut-Reminder
        ShowShortcutReminder(player);
        
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
        
        // BUG-FIX 8: Zusätzliche Sicherheit gegen Endlosschleife
        int kinderVorPhase = player.Kinder.Count;
        int maxNeugeburten = 4; // Maximum 4 neue Kinder in dieser Phase
        
        for (int jahr = 0; jahr < 10; jahr++)
        {
            player.Alter++;
            
            // BUG-FIX 3: Geburten-Intervall eingeführt
            // Problem: Bei hoher Geburtenrate (z.B. 75%) traten zu viele Geburten
            //          direkt hintereinander auf → Spieler hing in Namenseingabe fest
            // Lösung: Geburten nur noch alle 2 Jahre möglich (realistischer + spielbar)
            // BUG-FIX 8: Zusätzlich maximale Anzahl neuer Kinder pro Phase
            if (jahr % 2 == 0 && (player.Kinder.Count - kinderVorPhase) < maxNeugeburten)
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
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
        Console.WriteLine("║           🎉 PRÄSIDENTEN-FEATURES VERFÜGBAR! 🎉           ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n📞 Telefone: 'E' = Erdogan | 'T' = Trump | 'N' = NATO");
        Console.WriteLine("🏡 Erholung: 'F' = Finka (Gesundheit +30)");
        Console.WriteLine("🛒 Shop: 'Q' = Putin's Luxus-Shop");
        Console.WriteLine("🎵 Musik: 'M' = Russische Lieder");
        Console.WriteLine("💾 System: 'S' = Speichern | 'L' = Laden");
        Console.ResetColor();
        Console.WriteLine("\n" + new string('═', 60) + "\n");
        Console.WriteLine("[1] Imperiale Expansion (+50 Militär, -200 Geld)");
        Console.WriteLine("[2] Diplomatie (+300 Geld, +40 International)");
        Console.WriteLine("[3] Eiserne Faust (+40 Partei, -50 Volk)");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("[E/T/N/F/Q/M/S/L] Alle Shortcuts verfügbar");
        Console.ResetColor();
        Console.WriteLine();
        
        string choice = ReadInputWithShortcuts(player, "Wähle [1-3 oder Shortcuts]: ");
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
    
    /// <summary>
    /// ShowEnding - Zeigt Ende der Regierungsphase
    /// 
    /// BUG-FIX 5: Spiel sollte nach Regierung weitergehen
    /// Problem: Spiel endete nach Präsidentschaft, auch wenn Charakter noch lebt
    /// Lösung: Spieler kann wählen:
    ///         [1] Mit diesem Charakter weiterleben (Ruhestand)
    ///         [2] An einen Erben übergeben (falls Kinder vorhanden)
    ///         [3] Spiel speichern und beenden
    /// </summary>
    static void ShowEnding(PlayerCharacter player, string type)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
        Console.WriteLine($"║              {type.ToUpper()} ENDE DER AMTSZEIT                  ║");
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
        
        // BUG-FIX 5: Weiterspiel-Optionen nach Regierungsende
        Console.WriteLine("\n\n╔═══════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                   WIE WEITER?                             ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");
        Console.WriteLine("\n[1] Im Ruhestand weiterleben (als aktueller Charakter)");
        
        if (player.Kinder.Count > 0)
            Console.WriteLine("[2] An einen Erben übergeben (neue Generation)");
        
        Console.WriteLine("[3] Spiel speichern und beenden");
        Console.Write("\nWähle: ");
        
        string choice = Console.ReadLine();
        
        if (choice == "1")
        {
            // Weiterleben im Ruhestand
            player.Phase = "Ruhestand";
            Console.WriteLine("\n>> " + player.Name + " genießt den wohlverdienten Ruhestand...");
            Thread.Sleep(2000);
            
            // Alterungsprozess - kann zum Tod führen
            for (int jahre = 0; jahre < 10 && player.Gesundheit > 0; jahre++)
            {
                player.Alter++;
                player.Gesundheit -= rand.Next(5, 15); // Alterung
                
                if (DeathSystem.CheckDeath(player))
                {
                    // Tod im Ruhestand
                    var heir = DeathSystem.SelectHeir(player);
                    if (heir != null)
                    {
                        currentPlayer = heir;
                        Console.WriteLine("\n>> Die nächste Generation übernimmt...");
                        SaveGame(heir);
                    }
                    return;
                }
                
                Thread.Sleep(200);
            }
            
            Console.WriteLine($"\n>> {player.Name} ist {player.Alter} Jahre alt und lebt friedlich weiter.");
            SaveGame(player);
        }
        else if (choice == "2" && player.Kinder.Count > 0)
        {
            // An Erben übergeben
            var heir = DeathSystem.SelectHeir(player);
            if (heir != null)
            {
                currentPlayer = heir;
                player.IstTot = true; // Markiere als verstorben/zurückgetreten
                Console.WriteLine("\n>> Die Dynastie geht weiter...");
                Thread.Sleep(1500);
                SaveGame(heir);
            }
        }
        else
        {
            // Speichern und beenden
            SaveGame(player);
            Console.WriteLine("\n>> Auf Wiedersehen!");
            Thread.Sleep(1500);
        }
        
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
        
        // Zeige Besitztümer wenn vorhanden
        if (player.Besitztümer != null && player.Besitztümer.Count > 0)
        {
            Console.WriteLine("╠═══════════════════════════════════════════════════════════╣");
            Console.WriteLine($"║ 🎒 BESITZTÜMER ({player.Besitztümer.Count}):                                     ║");
            
            for (int i = 0; i < Math.Min(3, player.Besitztümer.Count); i++)
            {
                var item = player.Besitztümer[i];
                string itemText = $"{item.Icon} {item.Name}";
                Console.WriteLine($"║ {itemText,-56} ║");
            }
            
            if (player.Besitztümer.Count > 3)
            {
                Console.WriteLine($"║ ... und {player.Besitztümer.Count - 3} weitere (Drücke 'Q' für Shop)            ║");
            }
        }
        
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
    
    /// <summary>
    /// PlayMusic - Hintergrundmusik (optional)
    /// 
    /// BUG-FIX 4: Sound-Fehler auf Linux-Systemen
    /// Problem: Console.Beep() funktioniert unter Linux/Mono nicht zuverlässig
    ///          und kann Abstürze oder Fehler verursachen
    /// Lösung: Try-Catch mit Thread.Sleep als Fallback
    ///         Musik-Loop nur 3x statt endlos (verhindert CPU-Last)
    /// </summary>
    static void PlayMusic()
    {
        int tempo = 150;
        int[] melody = { 659, 494, 523, 587, 523, 494, 440, 440, 523, 659 };
        int[] durations = { 1, 1, 1, 1, 1, 1, 2, 1, 1, 2 };
        
        // Nur 3 Durchläufe statt Endlos-Schleife
        for (int loop = 0; loop < 3 && !stopMusic; loop++)
        {
            for (int i = 0; i < melody.Length && !stopMusic; i++)
            {
                try 
                { 
                    Console.Beep(melody[i], tempo * durations[i]); 
                }
                catch 
                { 
                    // Fallback: Stille Pause wenn Beep nicht funktioniert
                    Thread.Sleep(tempo * durations[i]); 
                }
            }
        }
    }
}

// ═══════════════════════════════════════════════════════════════════
// SCHIFFE VERSENKEN MINI-GAME (ÄNDERUNG 10)
// ═══════════════════════════════════════════════════════════════════
/*
 * VOLLSTÄNDIGES SCHIFFE-VERSENKEN-SPIEL:
 * 
 * Klassisches Battleship-Spiel als Easter Egg / Pause vom Hauptspiel.
 * Über Hauptmenü zugänglich.
 * 
 * SPIELMODI:
 * 1. Spieler vs Computer (KI mit Zufalls-Angriffen)
 * 2. Spieler vs Spieler (Hotseat-Modus)
 * 
 * FELDGRÖ§EN:
 * - Klein (6x6): Schiffe der Größe 4, 3, 2
 * - Groß (8x8): Schiffe der Größe 5, 4, 3, 2
 * 
 * SPIELFELD-ZEICHEN:
 * ~ = Wasser (noch nicht beschossen)
 * ■ = Schiff (nur auf eigenem Feld sichtbar)
 * X = Treffer (rot angezeigt)
 * O = Fehlschuss (blau angezeigt)
 * 
 * GEWINNBEDINGUNG:
 * Alle Schiffe des Gegners versenkt.
 * 
 * BESONDERE REGEL:
 * Bei Treffer ist der Spieler nochmal dran (wie im echten Spiel).
 * 
 * KLASSEN-STRUKTUR:
 * - BattleshipGame: Haupt-Spiellogik und Menü
 * - Board: Spielfeld-Verwaltung und Angriffe
 * - Ship: Einzelne Schiffe mit Treffer-Tracking
 */

/// <summary>
/// BattleshipGame - Hauptklasse für das Schiffe-Versenken-Minigame
/// 
/// ÄNDERUNG 10: Vollständiges Battleship-Spiel ins Hauptmenü integriert
/// </summary>
class BattleshipGame
{
    static Random rand = new Random();
    
    /// <summary>
    /// Play - Zeigt Spielmodus-Auswahl
    /// 
    /// Einstiegspunkt des Minigames.
    /// Spieler wählt zwischen:
    /// - PvC (Spieler gegen Computer)
    /// - PvP (Spieler gegen Spieler, Hotseat)
    /// </summary>
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
            PlayGame(false);  // PvC-Modus
        else if (choice == "2")
            PlayGame(true);   // PvP-Modus
    }
    
    /// <summary>
    /// PlayGame - Hauptspielschleife für Schiffe Versenken
    /// 
    /// ABLAUF:
    /// 1. Namenseingabe der Spieler
    /// 2. Feldgröße wählen (6x6 oder 8x8)
    /// 3. Spieler 1 platziert Schiffe (manuell)
    /// 4. Spieler 2 platziert Schiffe (manuell oder automatisch)
    /// 5. Rundenbasiertes Spiel:
    ///    - Angreifer wählt Zielfeld
    ///    - Bei Treffer: Nochmal dran
    ///    - Bei Fehlschuss: Spielerwechsel
    /// 6. Spiel endet wenn alle Schiffe eines Spielers versenkt sind
    /// 7. Gewinner-Bildschirm
    /// 
    /// BESONDERHEIT IM PVP-MODUS:
    /// - Nach jedem Zug wird Bildschirm gelöscht
    /// - Verhindert dass Spieler 2 das Feld von Spieler 1 sieht
    /// - "Drücke Taste" als Pause zwischen Spielern
    /// </summary>
    /// <param name="pvp">true = Spieler vs Spieler, false = Spieler vs Computer</param>
    static void PlayGame(bool pvp)
    {
        // ═══ SCHRITT 1: NAMENSEINGABE ═══
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
        
        // ═══ SCHRITT 2: FELDGRÖSSE WÄHLEN ═══
        // BUG-FIX 7: Feldgrößen angepasst für bessere Spielbarkeit
        // Problem: 6x6 zu klein für Schiffe der Größe 4, 3, 2
        // Lösung: Klein = 8x8, Groß = 10x10
        Console.WriteLine("\nFeldgröße:");
        Console.WriteLine("[1] Klein (8x8) - Schnelles Spiel");
        Console.WriteLine("[2] Groß (10x10) - Längeres Spiel");
        Console.Write("Wähle [1-2]: ");
        int size = Console.ReadLine() == "2" ? 10 : 8;
        
        // ═══ SCHRITT 3: SPIELFELDER ERSTELLEN ═══
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
    
    /// <summary>
    /// ComputerAttack - Computer wählt Zufallsfeld für Angriff
    /// 
    /// BUG-FIX 6: Fehlerhafte Bedingung in Computer-KI
    /// Problem: Bedingung "|| board.Grid[row, col] == 'O' && attempts < 100"
    ///          war falsch geklammert → Computer griff bereits beschossene Felder an
    /// Lösung: Korrekte Klammerung mit (... || ...) && attempts < 100
    /// </summary>
    static bool ComputerAttack(Board board)
    {
        int row, col;
        int attempts = 0;
        
        // Suche unbeschossenes Feld (max 100 Versuche)
        do
        {
            row = rand.Next(board.Size);
            col = rand.Next(board.Size);
            attempts++;
        } while ((board.Grid[row, col] == 'X' || board.Grid[row, col] == 'O') && attempts < 100);
        
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

/// <summary>
/// Board - Repräsentiert ein Schiffe-Versenken-Spielfeld
/// 
/// Verwaltet ein 2D-Gitter für das Battleship-Spiel.
/// 
/// GRÖSSEN:
/// - 6x6 (Klein): Schnelles Spiel
/// - 8x8 (Groß): Längeres Spiel
/// 
/// ZEICHEN IM GRID:
/// '~' = Wasser (unberührt)
/// 'S' = Schiff (Ship)
/// 'X' = Treffer (Hit)
/// 'O' = Fehlschuss (Miss)
/// 
/// METHODEN:
/// - PlaceShip(): Schiff platzieren mit Kollisionsprüfung
/// - Attack(): Angriff auf Feld ausführen
/// - AllShipsSunk(): Prüft ob alle Schiffe versenkt sind
/// - Display(): Zeigt Spielfeld an (mit/ohne Schiffe)
/// </summary>
class Board
{
    public int Size;                 // Feldgröße (6 oder 8)
    public char[,] Grid;             // 2D-Array für das Spielfeld
    public string PlayerName;        // Name des Besitzers
    List<Ship> ships = new List<Ship>();  // Liste aller Schiffe auf diesem Feld
    
    /// <summary>
    /// Konstruktor - Erstellt ein neues Spielfeld
    /// </summary>
    /// <param name="size">Feldgröße (6 oder 8)</param>
    /// <param name="name">Name des Spielers</param>
    public Board(int size, string name)
    {
        Size = size;
        PlayerName = name;
        Grid = new char[size, size];  // 2D-Array erstellen
        
        // Initialisiere gesamtes Feld mit Wasser ('~')
        for (int i = 0; i < size; i++)
            for (int j = 0; j < size; j++)
                Grid[i, j] = '~';
    }
    
    /// <summary>
    /// PlaceShip - Platziert ein Schiff auf dem Spielfeld
    /// 
    /// VALIDIERUNG:
    /// 1. Prüft ob Schiff innerhalb des Feldes passt
    /// 2. Prüft ob alle benötigten Felder frei sind ('~')
    /// 3. Bei Kollision: return false
    /// 
    /// PLATZIERUNG:
    /// - Erstellt neues Ship-Objekt
    /// - Markiert alle Felder mit 'S' (Ship)
    /// - Fügt Schiff zur ships-Liste hinzu
    /// 
    /// BEISPIEL:
    /// PlaceShip(0, 0, 3, true) → Schiff A1-C1 (horizontal)
    /// PlaceShip(0, 0, 3, false) → Schiff A1-A3 (vertikal)
    /// </summary>
    /// <param name="row">Start-Reihe (0-basiert)</param>
    /// <param name="col">Start-Spalte (0-basiert)</param>
    /// <param name="size">Schiffslänge (2-5)</param>
    /// <param name="horizontal">true = horizontal, false = vertikal</param>
    /// <returns>true wenn platziert, false bei Kollision</returns>
    public bool PlaceShip(int row, int col, int size, bool horizontal)
    {
        // ═══ VALIDIERUNG ═══
        if (horizontal)
        {
            // Horizontal: Prüfe ob Schiff rechts rausragt
            if (col + size > Size) return false;
            // Prüfe ob alle Felder frei sind
            for (int c = col; c < col + size; c++)
                if (Grid[row, c] != '~') return false;  // Kollision!
        }
        else
        {
            // Vertikal: Prüfe ob Schiff unten rausragt
            if (row + size > Size) return false;
            // Prüfe ob alle Felder frei sind
            for (int r = row; r < row + size; r++)
                if (Grid[r, col] != '~') return false;  // Kollision!
        }
        
        // ═══ PLATZIERUNG ═══
        // Erstelle Ship-Objekt für Treffer-Tracking
        Ship ship = new Ship(row, col, size, horizontal);
        ships.Add(ship);
        
        // Markiere Felder im Grid
        if (horizontal)
            for (int c = col; c < col + size; c++)
                Grid[row, c] = 'S';  // Ship
        else
            for (int r = row; r < row + size; r++)
                Grid[r, col] = 'S';
        
        return true;  // Erfolgreich platziert
    }
    
    /// <summary>
    /// Attack - Führt einen Angriff auf ein Feld aus
    /// 
    /// LOGIK:
    /// 1. Prüft ob Feld bereits beschossen wurde (X oder O)
    ///    → return '?' (ungültig)
    /// 
    /// 2. Wenn Schiff getroffen ('S'):
    ///    - Markiere mit 'X' (Treffer)
    ///    - Informiere Ship-Objekt über Treffer
    ///    - return 'X'
    /// 
    /// 3. Wenn Wasser getroffen ('~'):
    ///    - Markiere mit 'O' (Fehlschuss)
    ///    - return 'O'
    /// 
    /// RÜCKGABEWERTE:
    /// 'X' = Treffer!
    /// 'O' = Wasser (Fehlschuss)
    /// '?' = Ungültig (bereits beschossen)
    /// </summary>
    /// <param name="row">Ziel-Reihe</param>
    /// <param name="col">Ziel-Spalte</param>
    /// <returns>'X' (Treffer), 'O' (Fehlschuss), oder '?' (ungültig)</returns>
    public char Attack(int row, int col)
    {
        // Bereits beschossen? → Ungültig
        if (Grid[row, col] == 'X' || Grid[row, col] == 'O')
            return '?';
        
        // ═══ TREFFER ═══
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
    
    /// <summary>
    /// Display - Zeigt das Spielfeld an
    /// 
    /// BUG-FIX 7: Felder visuell vergrößert für bessere Lesbarkeit
    /// Problem: Zu kleine Darstellung, schwer zu lesen
    /// Lösung: Doppelte Breite pro Feld (4 Zeichen statt 3)
    /// </summary>
    public void Display(bool showShips)
    {
        // Header mit Spaltennummern (vergrößert)
        Console.Write("     ");
        for (int c = 0; c < Size; c++)
            Console.Write($"  {c + 1:D2} ");  // 2-stellig mit Padding
        Console.WriteLine();
        
        // Obere Trennlinie
        Console.Write("   ╔");
        for (int c = 0; c < Size; c++)
            Console.Write("════");
        Console.WriteLine("╗");
        
        // Spielfeld-Reihen
        for (int r = 0; r < Size; r++)
        {
            Console.Write($" {(char)('A' + r)} ║");
            
            for (int c = 0; c < Size; c++)
            {
                char cell = Grid[r, c];
                if (cell == 'S' && !showShips) cell = '~';
                
                switch (cell)
                {
                    case '~':
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("  ~ ");
                        break;
                    case 'S':
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("  ■ ");
                        break;
                    case 'X':
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("  X ");
                        break;
                    case 'O':
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("  ○ ");
                        break;
                }
                Console.ResetColor();
            }
            Console.WriteLine("║");
        }
        
        // Untere Trennlinie
        Console.Write("   ╚");
        for (int c = 0; c < Size; c++)
            Console.Write("════");
        Console.WriteLine("╝");
        
        Console.WriteLine("\n  ~ Wasser │ ■ Schiff │ X Treffer │ ○ Fehlschuss");
    }
}

/// <summary>
/// Ship - Repräsentiert ein einzelnes Schiff
/// 
/// Speichert Position, Größe und Treffer-Status eines Schiffes.
/// 
/// AUFGABEN:
/// - Position tracking (Startpunkt + Ausrichtung)
/// - Treffer-Tracking (bool-Array für jedes Schiffssegment)
/// - Prüfung ob Schiff vollständig versenkt ist
/// 
/// TREFFER-MECHANIK:
/// Ein Schiff der Größe 3 hat: hits = [false, false, false]
/// Nach 2 Treffern: hits = [true, true, false]
/// Nach 3 Treffern: hits = [true, true, true] → VERSENKT!
/// </summary>
class Ship
{
    int row, col, size;     // Position und Größe
    bool horizontal;        // Ausrichtung (true = horizontal, false = vertikal)
    bool[] hits;            // Treffer-Array: true = getroffen, false = intakt
    
    /// <summary>
    /// Konstruktor - Erstellt ein neues Schiff
    /// </summary>
    public Ship(int r, int c, int s, bool h)
    {
        row = r;
        col = c;
        size = s;
        horizontal = h;
        hits = new bool[s];  // Alle Segmente sind am Anfang intakt (false)
    }
    
    /// <summary>
    /// IsAt - Prüft ob Schiff an gegebener Position ist
    /// 
    /// BEISPIEL (Horizontal, Größe 3 bei A1):
    /// IsAt(0,0) → true  (A1)
    /// IsAt(0,1) → true  (B1)
    /// IsAt(0,2) → true  (C1)
    /// IsAt(0,3) → false (D1 - außerhalb)
    /// IsAt(1,0) → false (A2 - andere Reihe)
    /// </summary>
    public bool IsAt(int r, int c)
    {
        if (horizontal)
            return r == row && c >= col && c < col + size;
        else
            return c == col && r >= row && r < row + size;
    }
    
    /// <summary>
    /// Hit - Registriert einen Treffer auf diesem Schiff
    /// 
    /// Berechnet welches Segment getroffen wurde und markiert es im hits-Array.
    /// 
    /// BEISPIEL (Horizontal bei A1, Größe 3):
    /// Hit(0,0) → hits[0] = true  (Vorderteil getroffen)
    /// Hit(0,1) → hits[1] = true  (Mittelteil getroffen)
    /// Hit(0,2) → hits[2] = true  (Hinterteil getroffen)
    /// </summary>
    public void Hit(int r, int c)
    {
        if (horizontal)
            hits[c - col] = true;  // Index = Spalte minus Start-Spalte
        else
            hits[r - row] = true;  // Index = Reihe minus Start-Reihe
    }
    
    /// <summary>
    /// IsSunk - Prüft ob Schiff vollständig versenkt ist
    /// 
    /// MECHANIK:
    /// Verwendet LINQ-Methode .All() um zu prüfen ob ALLE
    /// Segmente getroffen wurden (alle hits[] = true).
    /// 
    /// BEISPIEL:
    /// hits = [true, false, true] → false (noch 1 Segment intakt)
    /// hits = [true, true, true]  → true  (VERSENKT!)
    /// 
    /// RÜCKGABE: true wenn komplett versenkt, sonst false
    /// </summary>
    public bool IsSunk()
    {
        return hits.All(h => h);  // LINQ: Alle Elemente müssen true sein
    }
}
