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
    
    // ═══ CHINA-TELEFON EASTER EGG ═══
    public bool ChinaTelefonAktiv;       // TRUE wenn China-Telefon freigeschaltet
    public int ChinaAnrufeVerfügbar;     // Anzahl verbleibender Anrufe (max 3)
    public int ChinaBeziehung;           // Beziehungswert zu China (0-100)
    
    // ═══ SIDECHICK-SYSTEM (NEUE MECHANIK) ═══
    public class UnanerkanntesSidechickKind
    {
        public string MutterName;
        public int GeburtsjahR;
        public bool IstJunge;
        public int Staerke;
        public int Intelligenz;
        public int Charisma;
        public int Kraft;
        public int DatumKosten;  // Wie viel wurde für das Date ausgegeben
    }
    public List<UnanerkanntesSidechickKind> VersteckteKinder;  // Kinder die noch nicht anerkannt sind
    public int LetztesSidechickJahr;  // Jahr des letzten Sidechick-Events
    
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
        
        // Flad-Shop initialisieren
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
        
        // China-Telefon initialisieren
        ChinaTelefonAktiv = false;        // Wird durch Event freigeschaltet
        ChinaAnrufeVerfügbar = 3;         // 3 Anrufe
        ChinaBeziehung = 70;              // Gute Beziehung (Allianz)
        
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
        // .NET Framework 4.0 kompatible Version
        string[] parts = Name.Split(new char[] { ' ' });
        return parts[0];
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
/// <summary>
/// HistoricalEvent - Historische/Politische/Wirtschaftliche Ereignisse mit genauem Datum
/// Diese Events erscheinen CHRONOLOGISCH und GARANTIERT (nicht zufällig!)
/// </summary>
class HistoricalEvent
{
    public string ID;                      // Eindeutige ID
    public string Name;                    // Titel (nur Deutsch)
    public string Datum;                   // Datum (nur Deutsch)
    public int Jahr;                       // Jahr für Sortierung
    public int Monat;                      // Monat für Sortierung (1-12)
    public string Geschichte;              // Geschichte (nur Deutsch)
    public string Kategorie;               // "POLITIK", "WIRTSCHAFT", "KRIEG", "KATASTROPHE"
    public Action<PlayerCharacter> Auswirkungen;  // Effekte auf Spieler
    
    // Neuer vereinfachter Konstruktor (nur Deutsch)
    public HistoricalEvent(string id, string name, string datum, int jahr, int monat, 
                          string kategorie, string geschichte, Action<PlayerCharacter> auswirkungen)
    {
        ID = id;
        Name = name;
        Datum = datum;
        Jahr = jahr;
        Monat = monat;
        Geschichte = geschichte;
        Kategorie = kategorie;
        Auswirkungen = auswirkungen;
    }
    
    // Helper-Methoden für Kompatibilität
    public string GetName() { return Name; }
    public string GetDatum() { return Datum; }
    public string GetGeschichte() { return Geschichte; }
}

/// <summary>
/// RandomEvent - Zufällige Ereignisse (alte Klasse bleibt für Zufalls-Events)
/// </summary>
class RandomEvent
{
    public string Name;              // Bezeichnung des Ereignisses
    public string Description;       // Beschreibung was passiert
    public string Phase;             // In welcher Lebensphase tritt es auf?
    public int Chance;               // Wahrscheinlichkeit 0-100%
    public int Jahr;                 // Spezifisches Jahr (0 = jederzeit in Phase)
    public string Type;              // "normal", "sidechick", "fiktiv"
    
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
/// ShopItem - Repräsentiert einen Luxusgegenstand im Flad-Shop
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
    // Random-Instanz wird von der globalen Program.rand-Variable verwendet
    static Random rand => Program.rand;
    
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
            // BUG-FIX: Maximal 3 Kinder pro Geburt, respektiere 8-Kinder-Limit
            int birthCount = 1;
            int multipleChance = rand.Next(100);
            
            // Berechne wie viele Kinder noch Platz haben (max 8 total)
            int remainingSlots = 8 - player.Kinder.Count;
            
            if (multipleChance < 1 && remainingSlots >= 3) // 1% Drillinge
            {
                birthCount = 3;
            }
            else if (multipleChance < 6 && remainingSlots >= 2) // 5% Zwillinge
            {
                birthCount = 2;
            }
            else if (remainingSlots >= 1)
            {
                birthCount = 1;
            }
            else
            {
                return; // Keine Plätze mehr frei
            }
            
            // Sicherheitscheck: Niemals mehr als 3 Kinder auf einmal
            birthCount = Math.Min(birthCount, 3);
            // Sicherheitscheck: Nicht über das 8-Kinder-Limit
            birthCount = Math.Min(birthCount, remainingSlots);
            
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
    // Random-Instanz wird von der globalen Program.rand-Variable verwendet
    static Random rand => Program.rand;
    
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
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine(@"
⣿⣿⣿⣵⣿⣿⣿⠿⡟⣛⣧⣿⣯⣿⣝⡻⢿⣿⣿⣿⣿⣿⣿⣿
⣿⣿⣿⣿⣿⠋⠁⣴⣶⣿⣿⣿⣿⣿⣿⣿⣦⣍⢿⣿⣿⣿⣿⣿
⣿⣿⣿⣿⢷⠄⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣏⢼⣿⣿⣿⣿
⢹⣿⣿⢻⠎⠔⣛⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡏⣿⣿⣿⣿
⢸⣿⣿⠇⡶⠄⣿⣿⠿⠟⡛⠛⠻⣿⡿⠿⠿⣿⣗⢣⣿⣿⣿⣿
⠐⣿⣿⡿⣷⣾⣿⣿⣿⣾⣶⣶⣶⣿⣁⣔⣤⣀⣼⢲⣿⣿⣿⣿
⠄⣿⣿⣿⣿⣾⣟⣿⣿⣿⣿⣿⣿⣿⡿⣿⣿⣿⢟⣾⣿⣿⣿⣿
⠄⣟⣿⣿⣿⡷⣿⣿⣿⣿⣿⣮⣽⠛⢻⣽⣿⡇⣾⣿⣿⣿⣿⣿
⠄⢻⣿⣿⣿⡷⠻⢻⡻⣯⣝⢿⣟⣛⣛⣛⠝⢻⣿⣿⣿⣿⣿⣿
⠄⠸⣿⣿⡟⣹⣦⠄⠋⠻⢿⣶⣶⣶⡾⠃⡂⢾⣿⣿⣿⣿⣿⣿
⠄⠄⠟⠋⠄⢻⣿⣧⣲⡀⡀⠄⠉⠱⣠⣾⡇⠄⠉⠛⢿⣿⣿⣿
⠄⠄⠄⠄⠄⠈⣿⣿⣿⣷⣿⣿⢾⣾⣿⣿⣇⠄⠄⠄⠄⠄⠉⠉
⠄⠄⠄⠄⠄⠄⠸⣿⣿⠟⠃⠄⠄⢈⣻⣿⣿⠄⠄⠄⠄⠄⠄⠄
⠄⠄⠄⠄⠄⠄⠄⢿⣿⣾⣷⡄⠄⢾⣿⣿⣿⡄⠄⠄⠄⠄⠄⠄
⠄⠄⠄⠄⠄⠄⠄⠸⣿⣿⣿⠃⠄⠈⢿⣿⣿⠄⠄⠄⠄⠄⠄⠄");
        Console.ResetColor();
        
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("\n╔═══════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                         † TOD †                           ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");
        Console.ResetColor();
        
        Console.WriteLine($"\n{player.Name} ist im Alter von {player.Alter} Jahren");
        Console.WriteLine($"an {cause} gestorben.\n");
        Thread.Sleep(3500);
        
        Console.WriteLine("Seine Herrschaft war geprägt von:");
        Console.WriteLine($"  • Generation: {player.Generation}");
        Console.WriteLine($"  • Kinder: {player.Kinder.Count}");
        Console.WriteLine($"  • Vermögen: {player.Geld} Rubel");
        Console.WriteLine($"  • Gesundheit bei Tod: {player.Gesundheit}%\n");
        Thread.Sleep(3500);
        
        Console.WriteLine($"Loyalität zur Partei: {player.LoyalitätPartei}%");
        Console.WriteLine($"Loyalität zum Volk: {player.LoyalitätVolk}%");
        Console.WriteLine($"Einfluss beim KGB: {player.EinflussKGB}%\n");
        Thread.Sleep(3500);
        
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
/// FladShop - Luxusgegenstände kaufen wie echte Oligarchen
/// 
/// KONZEPT:
/// Der Spieler kann Flad-typische Luxusgegenstände kaufen:
/// - Autos (Mercedes, Rolls-Royce, Aurus)
/// - Pferde (Flad liebt Reiten!)
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
static class FladShop
{
    // Random-Instanz wird von der globalen Program.rand-Variable verwendet
    static Random rand => Program.rand;
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
            "Flad liebt Reiten ohne Hemd!"
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
            "Flad ist Judo-Meister"
        ));
        
        shopItems.Add(new ShopItem(
            "Eishockey-Ausrüstung Pro",
            "🏒",
            250,
            20, 5, 20, 25, 5,
            "Flad spielt Eishockey"
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
                Thread.Sleep(2500);
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
            Thread.Sleep(3500);
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
            Thread.Sleep(3500);
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
    // Random-Instanz wird von der globalen Program.rand-Variable verwendet
    static Random rand => Program.rand;
    
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
                Thread.Sleep(3000);
                return;
            default:
                Console.WriteLine("\nUngültige Wahl!");
                Thread.Sleep(3000);
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
                Thread.Sleep(3000);
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
            Thread.Sleep(3500);
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
            Thread.Sleep(3500);
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
        Thread.Sleep(3000);
        Console.WriteLine("🏡 Ankunft an der Finka!");
        Thread.Sleep(2500);
        Console.WriteLine("🌊 Blick aufs Schwarze Meer...");
        Thread.Sleep(2500);
        Console.WriteLine("🍷 Ein Glas georgischen Wein...");
        Thread.Sleep(2500);
        Console.WriteLine("🛀 Entspannung in der Sauna...");
        Thread.Sleep(2500);
        Console.WriteLine("😴 Erholsamer Schlaf...");
        Thread.Sleep(3000);
        
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
            // Versuche Beep-Sound (mit Error-Handling für Stabilität)
            if (eventType == "katastrophe")
            {
                Console.Beep(200, 300);
                Console.Beep(150, 400);
            }
            else if (eventType == "politisch")
            {
                Console.Beep(800, 150);
                Console.Beep(600, 150);
            }
            else if (eventType == "türkei" || eventType == "usa" || eventType == "nato" || eventType == "china")
            {
                Console.Beep(1000, 100);
                Console.Beep(800, 100);
                Console.Beep(600, 100);
            }
            else
            {
                Console.Beep(440, 200);
            }
            Console.Write("♪ ");
        }
        catch
        {
            // Falls Beep nicht verfügbar (Linux/Mono) - nur Symbol
            Console.Write("♪ ");
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
            // Melodie (vereinfacht) - Russische Hymne
            int[] notes = {392, 440, 494, 523, 587, 523, 494, 440, 392, 349, 330, 349, 392, 440, 392};
            int[] durations = {400, 400, 400, 600, 400, 400, 400, 400, 600, 400, 400, 400, 400, 600, 800};
            
            for (int i = 0; i < notes.Length; i++)
            {
                try
                {
                    Console.Beep(notes[i], durations[i]);
                }
                catch
                {
                    // Einzelner Beep fehlgeschlagen - weiter
                    Thread.Sleep(durations[i]);
                }
            }
        }
        catch
        {
            // Beep nicht verfügbar auf diesem System
            Console.WriteLine("\n♪ [Hymne erklingt...] ♪");
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
                try
                {
                    Console.Beep(notes[i], durations[i]);
                }
                catch
                {
                    // Einzelner Beep fehlgeschlagen - weiter
                    Thread.Sleep(durations[i]);
                }
            }
        }
        catch
        {
            Console.WriteLine("\n♪ [Katyusha erklingt...] ♪");
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
                try
                {
                    Console.Beep(notes[i], duration);
                }
                catch
                {
                    // Einzelner Beep fehlgeschlagen - weiter
                    Thread.Sleep(duration);
                }
            }
        }
        catch
        {
            Console.WriteLine("\n♪ [Kalinka erklingt...] ♪");
            Thread.Sleep(2500);
        }
        
        Console.WriteLine("\n[Drücke eine Taste...]");
        Console.ReadKey(true);
    }
    
    /// <summary>
    /// ShowMusicMenu - Erweitert: Musik wechseln, ausschalten, Songs spielen
    /// </summary>
    public static void ShowMusicMenu(PlayerCharacter player)
    {
        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"
        ╔════════════════════════════════════════════╗
        ║   🎵 MUSIK-KONTROLLE 🎵                    ║
        ║   Musik des Vaterlandes                    ║
        ╚════════════════════════════════════════════╝
        ");
            Console.ResetColor();
            
            // Status anzeigen
            if (Program.stopMusic)
                Console.WriteLine("\n📢 Status: Musik ist AUS 🔇");
            else
                Console.WriteLine($"\n📢 Status: Musik läuft (Melodie {Program.currentMusicTrack}) 🔊");
            
            Console.WriteLine("\n═══ HINTERGRUNDMUSIK ═══");
            Console.WriteLine("[1] 🎵 Melodie 1 - Klassische Sowjet-Hymne");
            Console.WriteLine("[2] 🎶 Melodie 2 - Katyusha-Variation");
            Console.WriteLine("[3] 💃 Melodie 3 - Kalinka-Remix");
            Console.WriteLine("[4] 🎹 Melodie 4 - Roter Oktober Marsch");
            Console.WriteLine("[5] 🔇 Musik AUS/EIN schalten");
            
            Console.WriteLine("\n═══ EINMALIGE SONGS (mit Bonus) ═══");
            Console.WriteLine("[6] 🇷🇺 Russische Hymne spielen (+Patriotismus)");
            Console.WriteLine("[7] 🎶 Katyusha Volkslied (+Charisma)");
            Console.WriteLine("[8] 💃 Kalinka Tanzlied (+Gesundheit)");
            
            Console.WriteLine("\n[9] 🔙 Zurück zum Spiel");
            Console.Write("\nWähle [1-9]: ");
            
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    // Stoppe Musik kurz für Neustart mit neuer Melodie
                    bool wasPlaying = !Program.stopMusic;
                    Program.stopMusic = true;
                    Thread.Sleep(300); // Kurze Pause
                    Program.currentMusicTrack = 1;
                    if (wasPlaying)
                    {
                        Program.stopMusic = false;
                        Task.Run(() => Program.PlayMusic());
                    }
                    Console.WriteLine("\n✓ Melodie 1 - Klassische Sowjet-Hymne aktiviert!");
                    Thread.Sleep(2000);
                    break;
                    
                case "2":
                    wasPlaying = !Program.stopMusic;
                    Program.stopMusic = true;
                    Thread.Sleep(300);
                    Program.currentMusicTrack = 2;
                    if (wasPlaying)
                    {
                        Program.stopMusic = false;
                        Task.Run(() => Program.PlayMusic());
                    }
                    Console.WriteLine("\n✓ Melodie 2 - Katyusha-Variation aktiviert!");
                    Thread.Sleep(2000);
                    break;
                    
                case "3":
                    wasPlaying = !Program.stopMusic;
                    Program.stopMusic = true;
                    Thread.Sleep(300);
                    Program.currentMusicTrack = 3;
                    if (wasPlaying)
                    {
                        Program.stopMusic = false;
                        Task.Run(() => Program.PlayMusic());
                    }
                    Console.WriteLine("\n✓ Melodie 3 - Kalinka-Remix aktiviert!");
                    Thread.Sleep(2000);
                    break;
                    
                case "4":
                    wasPlaying = !Program.stopMusic;
                    Program.stopMusic = true;
                    Thread.Sleep(300);
                    Program.currentMusicTrack = 4;
                    if (wasPlaying)
                    {
                        Program.stopMusic = false;
                        Task.Run(() => Program.PlayMusic());
                    }
                    Console.WriteLine("\n✓ Melodie 4 - Roter Oktober Marsch aktiviert!");
                    Thread.Sleep(2000);
                    break;
                    
                case "5":
                    Program.stopMusic = !Program.stopMusic;
                    if (Program.stopMusic)
                    {
                        Console.WriteLine("\n🔇 Musik ausgeschaltet!");
                    }
                    else
                    {
                        Task.Run(() => Program.PlayMusic());
                        Console.WriteLine("\n🔊 Musik eingeschaltet!");
                    }
                    Thread.Sleep(2000);
                    break;
                    
                case "6":
                    PlayRussianAnthem();
                    player.LoyalitätVolk += 5;
                    player.LoyalitätPartei += 5;
                    Console.WriteLine("\n✓ Patriotismus +10!");
                    Thread.Sleep(3500);
                    break;
                    
                case "7":
                    PlayKatyusha();
                    player.Charisma += 1;
                    Console.WriteLine("\n✓ Charisma +1!");
                    Thread.Sleep(3500);
                    break;
                    
                case "8":
                    PlayKalinka();
                    player.Gesundheit = Math.Min(100, player.Gesundheit + 5);
                    Console.WriteLine("\n✓ Gesundheit +5 (Tanzen!)");
                    Thread.Sleep(3500);
                    break;
                    
                case "9":
                    return;
            }
        }
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
    // Random-Instanz wird von der globalen Program.rand-Variable verwendet
    static Random rand => Program.rand;
    
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
        Thread.Sleep(2500);
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
        Thread.Sleep(2500);
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
        Thread.Sleep(2500);
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
    // Random-Instanz wird von der globalen Program.rand-Variable verwendet
    static Random rand => Program.rand;
    
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
        Thread.Sleep(2500);
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
        Thread.Sleep(2500);
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
        Thread.Sleep(2500);
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
            Thread.Sleep(3000);
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

static class ChinaHotline
{
    // Random-Instanz wird von der globalen Program.rand-Variable verwendet
    static Random rand => Program.rand;
    
    public static void CallChina(PlayerCharacter p)
    {
        if (!p.ChinaTelefonAktiv || p.ChinaAnrufeVerfügbar <= 0)
        {
            Console.WriteLine("China-Telefon nicht verfügbar!");
            Thread.Sleep(3000);
            return;
        }
        
        Console.Clear();
        Console.WriteLine("\n📞 CHINA-TELEFON 🐉");
        Console.WriteLine($"Anrufe: {p.ChinaAnrufeVerfügbar}/3");
        Console.WriteLine("[1] Diplomatisch | [2] Überrascht | [3] Krawallstour | [4] Zurück");
        Console.Write("Wähle: ");
        
        string c = Console.ReadLine();
        if (c == "1") { p.Geld += 400; p.ChinaBeziehung += 20; Console.WriteLine("✓ +400 Rubel!"); }
        else if (c == "2") { p.Geld += 100; Console.WriteLine("✓ +100 Rubel (Reis)!"); }
        else if (c == "3") { p.Geld -= 300; p.ChinaBeziehung -= 40; Console.WriteLine("💥 -300 Rubel! Eklat!"); }
        else return;
        
        p.ChinaAnrufeVerfügbar--;
        Thread.Sleep(3500);
    }
}

/// <summary>
/// EventSystem - Verwaltet alle Zufallsereignisse UND historische Events
/// </summary>
static class EventSystem
{
    public static List<RandomEvent> allEvents = new List<RandomEvent>();  // Zufällige Events
    public static List<HistoricalEvent> historicalEvents = new List<HistoricalEvent>();  // Historische Events chronologisch
    public static HashSet<string> shownHistoricalEvents = new HashSet<string>();  // Bereits gezeigte historische Events
    public static Random rand = new Random();
    public static string currentLanguage = "DE";  // DE, RU, EN
    
    /// <summary>
    /// PlayEventSound - Wrapper-Methode für SoundSystem
    /// </summary>
    static void PlayEventSound(string eventType)
    {
        SoundSystem.PlayEventSound(eventType);
    }
    
    /// <summary>
    /// InitializeHistoricalEvents - Lädt ALLE historischen/politischen/wirtschaftlichen Events CHRONOLOGISCH
    /// 1952-2024: Circa 150 Events mit 2-3 Events pro Jahr
    /// Übersetzungen (RU/EN) werden später hinzugefügt - aktuell Platzhalter
    /// </summary>
    /// <summary>
    /// InitializeHistoricalEvents - Lädt ALLE historischen/politischen/wirtschaftlichen Events CHRONOLOGISCH
    /// </summary>
    public static void InitializeHistoricalEvents()
    {
        // ═══════════════════════════════════════════════════════════════════
        // HISTORISCHE EVENTS 1952-2023 (3-4 Events pro Jahr)
        // Übersetzungen werden später hinzugefügt
        // ═══════════════════════════════════════════════════════════════════
        
        // ====== 1952 ======
        historicalEvents.Add(new HistoricalEvent("STALIN_NOTE_1952", "Stalin-Note zur deutschen Einheit", "10. März 1952", 1952, 3, "POLITIK",
            @"Stalin bietet den Westmächten eine deutsche Wiedervereinigung an - unter Bedingung der Neutralität. Die Westmächte lehnen ab. Deutschland bleibt geteilt, der Kalte Krieg verhärtet sich.",
            p => { p.EinflussInternational += 15; p.LoyalitätPartei += 10; Thread.Sleep(3000); }));
        
        historicalEvents.Add(new HistoricalEvent("KOREA_KRIEG_1952", "Koreakrieg - Sowjetische Piloten im Einsatz", "15. Mai 1952", 1952, 5, "KRIEG",
            @"Sowjetische MiG-15 fliegen 'inoffiziell' über Korea gegen US-Jets. Tausende sterben monatlich am 38. Breitengrad. Ein blutiger Stellvertreterkrieg.",
            p => { p.EinflussMilitär += 20; p.Geld -= 150; p.Gesundheit -= 10; Thread.Sleep(3000); }));
        
        historicalEvents.Add(new HistoricalEvent("EISENBAHN_KATASTROPHE_1952", "Zugexplosion bei Moskau", "23. Juli 1952", 1952, 7, "KATASTROPHE",
            @"Über 100 Menschen sterben bei einer Zugexplosion nahe Moskau. Die Zensur verschleiert das Ausmaß. War es Sabotage oder marode Technik?",
            p => { p.LoyalitätVolk -= 15; p.Gesundheit -= 10; p.Geld -= 100; Thread.Sleep(3000); }));
        
        historicalEvents.Add(new HistoricalEvent("AERZTE_VERSCHWOERUNG_1952", "Ärzteverschwörung - Stalins Paranoia", "13. Januar 1953", 1953, 1, "POLITIK",
            @"Stalin verkündet eine 'jüdische Ärzteverschwörung' gegen Kreml-Funktionäre. Eine neue antisemitische Säuberungswelle beginnt. Stalins letzter Wahnsinn.",
            p => { p.EinflussKGB += 25; p.LoyalitätVolk -= 20; p.Gesundheit -= 15; Thread.Sleep(3000); }));
        
        // ====== 1953 ======
        historicalEvents.Add(new HistoricalEvent("STALIN_TOD_1953", "Tod von Josef Stalin", "5. März 1953", 1953, 3, "POLITIK",
            @"Der Diktator stirbt nach einem Schlaganfall. 30 Jahre Terror enden. Das Volk zwischen Trauer und Erleichterung. Der Machtkampf um die Nachfolge beginnt: Malenkow, Beria, Chruschtschow.",
            p => { p.LoyalitätPartei -= 30; p.LoyalitätVolk += 20; p.EinflussKGB -= 20; p.Gesundheit += 15; Thread.Sleep(4000); }));
        
        historicalEvents.Add(new HistoricalEvent("OSTBERLIN_AUFSTAND_1953", "Aufstand in Ostberlin niedergeschlagen", "17. Juni 1953", 1953, 6, "KRIEG",
            @"Arbeiter demonstrieren in Ostberlin für Freiheit. Sowjetische Panzer rollen ein und schlagen den Aufstand brutal nieder. Dutzende sterben.",
            p => { p.EinflussMilitär += 25; p.LoyalitätVolk -= 30; p.EinflussInternational -= 20; p.Gesundheit -= 15; Thread.Sleep(4000); }));
        
        historicalEvents.Add(new HistoricalEvent("KOREA_WAFFENSTILLSTAND_1953", "Koreakrieg endet", "27. Juli 1953", 1953, 7, "POLITIK",
            @"Nach drei Jahren Krieg wird der Waffenstillstand unterzeichnet. Über 3 Millionen Tote. Korea bleibt geteilt. Die Sowjetunion verkündet einen 'Sieg'.",
            p => { p.EinflussInternational += 15; p.EinflussMilitär += 10; p.LoyalitätVolk += 15; p.Geld += 150; Thread.Sleep(3000); }));
        
        historicalEvents.Add(new HistoricalEvent("BERIA_HINRICHTUNG_1953", "Lawrenti Beria hingerichtet", "23. Dezember 1953", 1953, 12, "POLITIK",
            @"Stalins gefürchteter Geheimdienstchef wird nach Schauprozess hingerichtet. Verrat, Spionage, Mord - die Anklagen sind endlos. Das Volk jubelt heimlich.",
            p => { p.EinflussKGB -= 25; p.LoyalitätVolk += 25; p.Gesundheit += 10; p.LoyalitätPartei += 10; Thread.Sleep(4000); }));
        
        // ====== 1954 ======
        historicalEvents.Add(new HistoricalEvent("ATOMKRAFTWERK_OBNINSK_1954", "Erstes Atomkraftwerk der Welt", "27. Juni 1954", 1954, 6, "POLITIK",
            @"Die UdSSR eröffnet das weltweit erste Kernkraftwerk in Obninsk. Ein technologischer Triumph! Die friedliche Nutzung der Atomkraft zeigt sowjetische Überlegenheit.",
            p => { p.EinflussInternational += 30; p.LoyalitätVolk += 25; p.Intelligenz += 2; p.Geld += 200; Thread.Sleep(4000); }));
        
        historicalEvents.Add(new HistoricalEvent("KGB_GRUENDUNG_1954", "KGB wird gegründet", "13. März 1954", 1954, 3, "POLITIK",
            @"Das Komitee für Staatssicherheit (KGB) wird offiziell gegründet. Die neue Geheimpolizei soll 'effizienter' sein als die alte NKWD. Die Überwachung geht weiter.",
            p => { p.EinflussKGB += 30; p.LoyalitätVolk -= 15; Thread.Sleep(3000); }));
        
        historicalEvents.Add(new HistoricalEvent("WASSERSTOFFBOMBE_1954", "Sowjetische H-Bombe getestet", "12. August 1954", 1954, 8, "KRIEG",
            @"Die UdSSR zündet ihre erste transportable Wasserstoffbombe. Die Zerstörungskraft ist monströs. Das nukleare Wettrüsten eskaliert.",
            p => { p.EinflussMilitär += 35; p.EinflussInternational += 20; p.Geld -= 200; Thread.Sleep(3000); }));
        
        // ====== 1955 ======
        historicalEvents.Add(new HistoricalEvent("WARSCHAUER_PAKT_1955", "Warschauer Pakt gegründet", "14. Mai 1955", 1955, 5, "POLITIK",
            @"Als Antwort auf die NATO gründet die UdSSR den Warschauer Pakt. Ost europa wird militärisch geeint. Der Eiserne Vorhang verfestigt sich.",
            p => { p.EinflussMilitär += 30; p.EinflussInternational += 25; p.LoyalitätPartei += 15; Thread.Sleep(4000); }));
        
        historicalEvents.Add(new HistoricalEvent("OESTERREICH_STAATSVERTRAG_1955", "Österreich wird neutral", "15. Mai 1955", 1955, 5, "POLITIK",
            @"Die UdSSR zieht aus Österreich ab und akzeptiert dessen Neutralität. Ein seltener diplomatischer Erfolg und Zeichen der Entspannung.",
            p => { p.EinflussInternational += 20; p.LoyalitätVolk += 10; Thread.Sleep(3000); }));
        
        historicalEvents.Add(new HistoricalEvent("MALENKOW_STURZ_1955", "Malenkow verliert die Macht", "8. Februar 1955", 1955, 2, "POLITIK",
            @"Chruschtschow drängt Malenkow aus dem Amt des Ministerpräsidenten. Die Machtkonsolidierung geht weiter. Chruschtschow steigt auf.",
            p => { p.LoyalitätPartei += 15; p.EinflussKGB += 10; Thread.Sleep(3000); }));
        
        // ====== 1956 ======
        historicalEvents.Add(new HistoricalEvent("XX_PARTEITAG_1956", "XX. Parteitag - Chruschtschows Geheimrede", "25. Februar 1956", 1956, 2, "POLITIK",
            @"Chruschtschow prangert Stalin als Massenmörder an! Die vierstündige Geheimrede erschüttert die Partei. Entstalinisierung beginnt. Stalin-Statuen werden gestürzt.",
            p => { p.LoyalitätPartei -= 35; p.LoyalitätVolk += 30; p.Intelligenz += 2; p.Gesundheit += 15; p.EinflussKGB -= 15; Thread.Sleep(5000); }));
        
        historicalEvents.Add(new HistoricalEvent("UNGARN_AUFSTAND_1956", "Ungarn-Aufstand niedergeschlagen", "4. November 1956", 1956, 11, "KRIEG",
            @"1000 sowjetische Panzer rollen durch Budapest. Der Freiheitsaufstand wird brutal niedergewalzt. 2500 Ungarn sterben, 200.000 fliehen. Die Botschaft: Freiheit wird mit Panzern beantwortet.",
            p => { p.EinflussMilitär += 30; p.LoyalitätVolk -= 40; p.EinflussInternational -= 35; p.Gesundheit -= 20; p.Geld -= 300; Thread.Sleep(5000); }));
        
        historicalEvents.Add(new HistoricalEvent("SUEZ_KRISE_1956", "Suez-Krise - Sowjetische Drohungen", "5. November 1956", 1956, 11, "POLITIK",
            @"Die UdSSR droht Großbritannien und Frankreich mit Raketenschlägen wegen Suez. Die Westmächte ziehen sich zurück. Ein außenpolitischer Sieg!",
            p => { p.EinflussInternational += 30; p.EinflussMilitär += 20; p.LoyalitätVolk += 15; Thread.Sleep(3000); }));
        
        // ====== 1957 ======
        historicalEvents.Add(new HistoricalEvent("SPUTNIK_1957", "Sputnik 1 - Erster Satellit im Orbit", "4. Oktober 1957", 1957, 10, "POLITIK",
            @"Die UdSSR schickt den ersten Satelliten ins All! Das 'Piep-Piep-Piep' von Sputnik schockiert den Westen. Das Volk jubelt: WIR sind die Ersten im Weltraum!",
            p => { p.EinflussInternational += 40; p.LoyalitätVolk += 35; p.Geld += 200; p.Intelligenz += 2; p.LoyalitätPartei += 25; Thread.Sleep(5000); }));
        
        historicalEvents.Add(new HistoricalEvent("LAIKA_HUND_1957", "Laika - Erster Hund im Weltraum", "3. November 1957", 1957, 11, "POLITIK",
            @"Die Hündin Laika fliegt mit Sputnik 2 ins All - und stirbt dort. Ein tragischer Erfolg der Raumfahrt. Der Weg zum bemannten Flug ist geebnet.",
            p => { p.EinflussInternational += 25; p.Intelligenz += 1; p.LoyalitätVolk += 15; Thread.Sleep(3000); }));
        
        historicalEvents.Add(new HistoricalEvent("ANTI_PARTEI_GRUPPE_1957", "Putschversuch gegen Chruschtschow scheitert", "22. Juni 1957", 1957, 6, "POLITIK",
            @"Altstalinisten versuchen Chruschtschow zu stürzen. Der Putsch scheitert. Chruschtschow festigt seine Macht und säubert die Partei von Gegnern.",
            p => { p.LoyalitätPartei += 20; p.EinflussKGB += 15; Thread.Sleep(3000); }));
        
        // ====== 1958 ======
        historicalEvents.Add(new HistoricalEvent("CHRUSCHTSCHOW_ALLEIN_1958", "Chruschtschow übernimmt alle Macht", "27. März 1958", 1958, 3, "POLITIK",
            @"Chruschtschow wird Ministerpräsident UND Parteichef. Die Machtkonzentration ist komplett. Ein neuer starker Mann im Kreml.",
            p => { p.LoyalitätPartei += 25; p.EinflussKGB += 10; Thread.Sleep(3000); }));
        
        historicalEvents.Add(new HistoricalEvent("BERLIN_ULTIMATUM_1958", "Chruschtschow fordert: West-Berlin räumen!", "27. November 1958", 1958, 11, "POLITIK",
            @"Chruschtschow stellt ein Ultimatum: Die Westmächte sollen West-Berlin verlassen! 6 Monate Frist. Die Berlin-Krise spitzt sich zu. Der Westen bleibt standhaft.",
            p => { p.EinflussInternational -= 15; p.EinflussMilitär += 20; p.Gesundheit -= 10; Thread.Sleep(4000); }));
        
        historicalEvents.Add(new HistoricalEvent("SINO_SOVIET_SPLIT_1958", "Bruch mit China beginnt", "1. August 1958", 1958, 8, "POLITIK",
            @"Mao kritisiert Chruschtschows 'Revisionismus'. Der sino-sowjetische Konflikt beginnt. Zwei kommunistische Giganten werden zu Rivalen.",
            p => { p.EinflussInternational -= 20; p.LoyalitätPartei -= 10; Thread.Sleep(3000); }));
        
        // ====== 1959 ======
        historicalEvents.Add(new HistoricalEvent("LUNA_2_MOND_1959", "Luna 2 erreicht den Mond", "14. September 1959", 1959, 9, "POLITIK",
            @"Die sowjetische Sonde Luna 2 schlägt als erstes menschengemachtes Objekt auf dem Mond auf! Ein weiterer Triumph im Weltraumrennen!",
            p => { p.EinflussInternational += 35; p.LoyalitätVolk += 30; p.Intelligenz += 2; p.Geld += 150; Thread.Sleep(4000); }));
        
        historicalEvents.Add(new HistoricalEvent("CHRUSCHTSCHOW_USA_1959", "Chruschtschow besucht die USA", "15. September 1959", 1959, 9, "POLITIK",
            @"Erstmals besucht ein sowjetischer Führer die USA! Chruschtschow trifft Eisenhower. Das 'Tauwetter' im Kalten Krieg beginnt vorsichtig.",
            p => { p.EinflussInternational += 25; p.LoyalitätVolk += 20; Thread.Sleep(3000); }));
        
        historicalEvents.Add(new HistoricalEvent("FIDEL_KUBA_1959", "Fidel Castro übernimmt Kuba", "1. Januar 1959", 1959, 1, "POLITIK",
            @"Castros Revolution siegt in Kuba! Bald wird Kuba ein sowjetischer Verbündeter - 90 Meilen vor der US-Küste. Ein strategischer Triumph!",
            p => { p.EinflussInternational += 30; p.EinflussMilitär += 15; Thread.Sleep(3000); }));
        
        // ====== 1960 ======
        historicalEvents.Add(new HistoricalEvent("U2_ABSCHUSS_1960", "US-Spionageflugzeug abgeschossen", "1. Mai 1960", 1960, 5, "KRIEG",
            @"Eine sowjetische Rakete schießt ein US-Spionageflugzeug U-2 ab! Pilot Gary Powers wird gefangen. Eisenhower muss Spionage zugeben. Blamage für die USA!",
            p => { p.EinflussMilitär += 30; p.EinflussInternational += 25; p.LoyalitätVolk += 20; Thread.Sleep(4000); }));
        
        historicalEvents.Add(new HistoricalEvent("PARIS_GIPFEL_SCHEITERT_1960", "Pariser Gipfel scheitert", "17. Mai 1960", 1960, 5, "POLITIK",
            @"Wegen der U-2-Affäre verlässt Chruschtschow wütend den Pariser Gipfel. Das 'Tauwetter' ist vorbei. Der Kalte Krieg kehrt zurück.",
            p => { p.EinflussInternational -= 15; p.Gesundheit -= 10; Thread.Sleep(3000); }));
        
        historicalEvents.Add(new HistoricalEvent("AFRIKA_DEKOLONISATION_1960", "Afrika-Jahr - Sowjetischer Einfluss wächst", "17. August 1960", 1960, 8, "POLITIK",
            @"17 afrikanische Staaten werden unabhängig. Die UdSSR bietet Unterstützung und konkurriert mit dem Westen um Einfluss im 'Dritten Welt'.",
            p => { p.EinflussInternational += 20; p.Geld -= 100; Thread.Sleep(3000); }));
        
        // ====== 1961 ======
        historicalEvents.Add(new HistoricalEvent("GAGARIN_WELTRAUM_1961", "Juri Gagarin - Erster Mensch im Weltraum", "12. April 1961", 1961, 4, "POLITIK",
            @"'POJECHALI!' ruft Gagarin beim Start. 108 Minuten später: Der erste Mensch hat die Erde aus dem All gesehen! Die UdSSR ist im Weltraum unschlagbar! Das Volk feiert ihren Helden.",
            p => { p.EinflussInternational += 50; p.LoyalitätVolk += 40; p.Geld += 300; p.Intelligenz += 3; p.LoyalitätPartei += 30; Thread.Sleep(5000); }));
        
        historicalEvents.Add(new HistoricalEvent("BERLINER_MAUER_1961", "Bau der Berliner Mauer", "13. August 1961", 1961, 8, "POLITIK",
            @"In der Nacht beginnt der Mauerbau! Berlin wird mit Stacheldraht und Beton geteilt. 'Niemand hat die Absicht, eine Mauer zu errichten' log Ulbricht. Die Welt ist entsetzt.",
            p => { p.EinflussMilitär += 25; p.LoyalitätVolk -= 30; p.EinflussInternational -= 30; p.Gesundheit -= 15; Thread.Sleep(5000); }));
        
        historicalEvents.Add(new HistoricalEvent("SCHWEINEBUCHT_1961", "Schweinebucht - CIA-Invasion scheitert", "17. April 1961", 1961, 4, "KRIEG",
            @"CIA-gestützte Exilkubaner versuchen Castro zu stürzen - und scheitern kläglich! Ein Triumph für die UdSSR. Kuba rückt näher an Moskau.",
            p => { p.EinflussInternational += 30; p.LoyalitätVolk += 20; Thread.Sleep(3000); }));
        
        // ====== 1962 ======
        historicalEvents.Add(new HistoricalEvent("KUBAKRISE_1962", "Kubakrise - Am Rand des Atomkriegs", "24. Oktober 1962", 1962, 10, "KRIEG",
            @"US-Seeblockade! Sowjetische Raketen auf Kuba! 13 Tage am Abgrund des Atomkriegs. Die Welt hält den Atem an. Chruschtschow lenkt ein - die Raketen werden abgezogen. Knapp vorbei am Weltuntergang.",
            p => { p.EinflussMilitär += 20; p.EinflussInternational -= 25; p.Gesundheit -= 30; p.LoyalitätVolk -= 20; p.Geld -= 250; Thread.Sleep(6000); }));
        
        historicalEvents.Add(new HistoricalEvent("NOWOTSCHERKASSK_MASSAKER_1962", "Massaker in Nowotscherkassk", "2. Juni 1962", 1962, 6, "KATASTROPHE",
            @"Arbeiter streiken gegen Preiserhöhungen. Das Militär schießt in die Menge! Mindestens 26 Tote. Das Massaker wird jahrzehntelang vertuscht.",
            p => { p.LoyalitätVolk -= 35; p.EinflussKGB += 20; p.Gesundheit -= 20; Thread.Sleep(4000); }));
        
        historicalEvents.Add(new HistoricalEvent("KUBA_US_EMBARGO_1962", "USA verhängen Kuba-Embargo", "7. Februar 1962", 1962, 2, "POLITIK",
            @"Kennedy verhängt totales Handelsembargo gegen Kuba! Die UdSSR muss nun Kuba massiv wirtschaftlich stützen. Ein teurer Verbündeter - aber ein wichtiger.",
            p => { p.Geld -= 150; p.EinflussInternational += 15; Thread.Sleep(3000); }));
        
        historicalEvents.Add(new HistoricalEvent("TERESCHKOWA_WELTRAUM_1962", "Walentina Tereschkowa - Erste Frau im All", "16. Juni 1963", 1963, 6, "POLITIK",
            @"Die 26-jährige Tereschkowa fliegt als erste Frau ins Weltall! Ein propagandistischer Triumph: Sowjetische Frauen sind gleichberechtigt!",
            p => { p.EinflussInternational += 30; p.LoyalitätVolk += 30; p.Intelligenz += 2; Thread.Sleep(4000); }));
        
        // ====== 1963 ======
        historicalEvents.Add(new HistoricalEvent("KENNEDY_MORD_1963", "Kennedy ermordet", "22. November 1963", 1963, 11, "POLITIK",
            @"Präsident Kennedy wird in Dallas erschossen! Die Welt steht unter Schock. Gerüchte über sowjetische Beteiligung kursieren - alle falsch. Die USA sind im Chaos.",
            p => { p.EinflussInternational += 15; p.Gesundheit -= 10; Thread.Sleep(4000); }));
        
        historicalEvents.Add(new HistoricalEvent("ATOMTESTSTOPP_1963", "Atomteststopp-Abkommen", "5. August 1963", 1963, 8, "POLITIK",
            @"USA, UdSSR und Großbritannien verbieten oberirdische Atomtests. Ein kleiner Schritt zur Entspannung nach der Kubakrise.",
            p => { p.EinflussInternational += 25; p.LoyalitätVolk += 20; p.Gesundheit += 15; Thread.Sleep(3000); }));
        
        historicalEvents.Add(new HistoricalEvent("MISSERNTE_1963", "Katastrophale Missernte", "15. September 1963", 1963, 9, "WIRTSCHAFT",
            @"Die schlechteste Ernte seit Jahrzehnten! Die UdSSR muss erstmals Getreide aus dem kapitalistischen Westen kaufen. Eine Blamage für das System.",
            p => { p.Geld -= 300; p.LoyalitätVolk -= 25; p.LoyalitätPartei -= 15; Thread.Sleep(3000); }));
        
        // ====== 1964 ======
        historicalEvents.Add(new HistoricalEvent("CHRUSCHTSCHOW_STURZ_1964", "Chruschtschow gestürzt", "14. Oktober 1964", 1964, 10, "POLITIK",
            @"Während Chruschtschow im Urlaub ist, putscht das Politbüro! Breschnew übernimmt. Die Ära Chruschtschow endet abrupt. Gründe: Kubakrise, Misswirtschaft, Unberechenbarkeit.",
            p => { p.LoyalitätPartei += 20; p.EinflussKGB += 25; p.LoyalitätVolk -= 10; Thread.Sleep(4000); }));
        
        historicalEvents.Add(new HistoricalEvent("BRESCHNEW_MACHT_1964", "Breschnew übernimmt die Führung", "15. Oktober 1964", 1964, 10, "POLITIK",
            @"Leonid Breschnew wird neuer Generalsekretär. Die 'Ära der Stagnation' beginnt. Stabilität statt Reform, Kontrolle statt Experimente.",
            p => { p.LoyalitätPartei += 25; p.EinflussKGB += 20; Thread.Sleep(3000); }));
        
        historicalEvents.Add(new HistoricalEvent("CHINA_ATOMBOMBE_1964", "China zündet Atombombe", "16. Oktober 1964", 1964, 10, "KRIEG",
            @"China wird Atommacht! Der sowjetische Rivale im Osten ist nun nuklear bewaffnet. Die Spannungen zwischen UdSSR und China verschärfen sich dramatisch.",
            p => { p.EinflussInternational -= 20; p.Gesundheit -= 15; Thread.Sleep(3000); }));
        
        // ====== 1965 ======
        historicalEvents.Add(new HistoricalEvent("VIETNAM_ESKALATION_1965", "Vietnamkrieg eskaliert - UdSSR unterstützt", "7. Februar 1965", 1965, 2, "KRIEG",
            @"USA bombardieren Nordvietnam massiv. Die UdSSR liefert Waffen, Flugabwehr und Berater. Ein neuer blutiger Stellvertreterkrieg beginnt.",
            p => { p.EinflussMilitär += 25; p.Geld -= 200; p.EinflussInternational += 15; Thread.Sleep(3000); }));
        
        historicalEvents.Add(new HistoricalEvent("WOSCHOD_2_SPACEWALK_1965", "Erster Weltraumspaziergang", "18. März 1965", 1965, 3, "POLITIK",
            @"Alexei Leonow verlässt als erster Mensch sein Raumschiff! 12 Minuten im freien Weltraum - ein weiterer sowjetischer Rekord!",
            p => { p.EinflussInternational += 35; p.LoyalitätVolk += 25; p.Intelligenz += 2; Thread.Sleep(4000); }));
        
        historicalEvents.Add(new HistoricalEvent("KOSSYGIN_REFORM_1965", "Kossygin-Reformen in der Wirtschaft", "27. September 1965", 1965, 9, "WIRTSCHAFT",
            @"Ministerpräsident Kossygin versucht zaghafte Wirtschaftsreformen. Mehr Autonomie für Betriebe, Gewinnorientierung. Aber der Widerstand ist groß.",
            p => { p.Geld += 150; p.LoyalitätPartei -= 10; Thread.Sleep(3000); }));
        
        // ====== 1966 ======
        historicalEvents.Add(new HistoricalEvent("LUNA_9_MONDLANDUNG_1966", "Luna 9 landet weich auf dem Mond", "3. Februar 1966", 1966, 2, "POLITIK",
            @"Erste weiche Landung auf dem Mond! Luna 9 sendet Fotos von der Mondoberfläche. Die UdSSR führt weiter im Weltraumrennen.",
            p => { p.EinflussInternational += 30; p.LoyalitätVolk += 25; p.Intelligenz += 2; Thread.Sleep(4000); }));
        
        historicalEvents.Add(new HistoricalEvent("KULTURREVOLUTION_CHINA_1966", "Maos Kulturrevolution beginnt", "16. Mai 1966", 1966, 5, "POLITIK",
            @"China versinkt im Chaos der Kulturrevolution. Mao hetzt Jugendliche gegen 'Revisionisten' auf - auch gegen die UdSSR. Der sino-sowjetische Bruch vertieft sich.",
            p => { p.EinflussInternational -= 15; Thread.Sleep(3000); }));
        
        historicalEvents.Add(new HistoricalEvent("XXIII_PARTEITAG_1966", "XXIII. Parteitag - Breschnew festigt Macht", "29. März 1966", 1966, 3, "POLITIK",
            @"Breschnew lässt sich auf dem Parteitag als unumstrittener Führer bestätigen. Die De-Chruschtschowisierung ist komplett.",
            p => { p.LoyalitätPartei += 20; p.EinflussKGB += 15; Thread.Sleep(3000); }));
        
        // ====== 1967 ======
        historicalEvents.Add(new HistoricalEvent("SECHSTAGEKRIEG_1967", "Sechstagekrieg - Sowjetische Verbündete verlieren", "10. Juni 1967", 1967, 6, "KRIEG",
            @"Israel zerschlägt in 6 Tagen die arabischen Armeen - alle mit sowjetischen Waffen ausgerüstet! Eine außenpolitische Blamage für die UdSSR.",
            p => { p.EinflussInternational -= 30; p.Geld -= 250; p.LoyalitätVolk -= 10; Thread.Sleep(4000); }));
        
        historicalEvents.Add(new HistoricalEvent("SOJUS_1_ABSTURZ_1967", "Komarow stirbt bei Sojus 1-Absturz", "24. April 1967", 1967, 4, "KATASTROPHE",
            @"Der Kosmonaut Wladimir Komarow stirbt beim Absturz von Sojus 1! Der Fallschirm öffnet nicht. Der erste Todesfall im Weltraumprogramm erschüttert das Land.",
            p => { p.LoyalitätVolk -= 25; p.Gesundheit -= 20; p.EinflussInternational -= 15; Thread.Sleep(4000); }));
        
        historicalEvents.Add(new HistoricalEvent("ANTIBALLISTIC_TREATY_TALKS_1967", "Verhandlungen über Raketenabwehr beginnen", "18. September 1967", 1967, 9, "POLITIK",
            @"USA und UdSSR beginnen Gespräche über Rüstungskontrolle. Ein Hoffnungsschimmer in der nuklearen Konfrontation.",
            p => { p.EinflussInternational += 20; p.Gesundheit += 10; Thread.Sleep(3000); }));
        
        // ====== 1968 ======
        historicalEvents.Add(new HistoricalEvent("PRAGER_FRUEHLING_1968", "Prager Frühling niedergeschlagen", "21. August 1968", 1968, 8, "KRIEG",
            @"'Sozialismus mit menschlichem Antlitz' in der Tschechoslowakei - VERBOTEN! 500.000 Soldaten des Warschauer Pakts marschieren ein. Panzer in Prag. Der Prager Frühling wird zum Winter. Die Welt ist entsetzt.",
            p => { p.EinflussMilitär += 30; p.LoyalitätVolk -= 35; p.EinflussInternational -= 40; p.Gesundheit -= 25; p.Geld -= 300; Thread.Sleep(6000); }));
        
        historicalEvents.Add(new HistoricalEvent("BRESCHNEW_DOKTRIN_1968", "Breschnew-Doktrin verkündet", "12. November 1968", 1968, 11, "POLITIK",
            @"'Begrenzte Souveränität' nennt Breschnew es: Die UdSSR darf überall im Ostblock einmarschieren, wenn der Sozialismus 'bedroht' ist. Eine Doktrin der Unterdrückung.",
            p => { p.EinflussMilitär += 20; p.EinflussInternational -= 25; Thread.Sleep(3000); }));
        
        historicalEvents.Add(new HistoricalEvent("ATOMWAFFENSPERRVERTRAG_1968", "Atomwaffensperrvertrag unterzeichnet", "1. Juli 1968", 1968, 7, "POLITIK",
            @"Der Vertrag zur Nichtverbreitung von Atomwaffen wird unterschrieben. USA und UdSSR wollen ihr Nuklearmonopol bewahren.",
            p => { p.EinflussInternational += 20; p.Gesundheit += 15; Thread.Sleep(3000); }));
        
        // ====== 1969 ======
        historicalEvents.Add(new HistoricalEvent("MONDLANDUNG_USA_1969", "USA landen auf dem Mond", "20. Juli 1969", 1969, 7, "POLITIK",
            @"Apollo 11 - Armstrong betritt den Mond! Die USA haben das Weltraumrennen gewonnen. Die sowjetische Propaganda schweigt betreten. Eine schmerzhafte Niederlage.",
            p => { p.EinflussInternational -= 35; p.LoyalitätVolk -= 20; p.Gesundheit -= 15; Thread.Sleep(5000); }));
        
        historicalEvents.Add(new HistoricalEvent("GRENZKONFLIKT_CHINA_1969", "Bewaffneter Konflikt mit China", "2. März 1969", 1969, 3, "KRIEG",
            @"Sowjetische und chinesische Truppen liefern sich blutige Gefechte am Grenzfluss Ussuri! Dutzende Tote. Die kommunistischen Brüder stehen am Rand eines Krieges.",
            p => { p.EinflussMilitär += 20; p.Geld -= 150; p.Gesundheit -= 15; Thread.Sleep(4000); }));
        
        historicalEvents.Add(new HistoricalEvent("WARSCHAU_PAKT_GIPFEL_1969", "Warschauer Pakt wird gestärkt", "17. März 1969", 1969, 3, "POLITIK",
            @"Nach Prag wird der Warschauer Pakt militärisch verstärkt. Die Satellitenstaaten werden enger an Moskau gebunden.",
            p => { p.EinflussMilitär += 15; p.EinflussInternational += 10; Thread.Sleep(3000); }));
        
        // ====== 1970 ======
        historicalEvents.Add(new HistoricalEvent("WILLY_BRANDT_OSTPOLITIK_1970", "Brandts Ostpolitik - Annäherung mit Deutschland", "12. August 1970", 1970, 8, "POLITIK",
            @"Bundeskanzler Brandt unterzeichnet den Moskauer Vertrag. Die BRD erkennt die Oder-Neiße-Grenze an. Ein Durchbruch in der Entspannungspolitik!",
            p => { p.EinflussInternational += 30; p.LoyalitätVolk += 15; p.Geld += 100; Thread.Sleep(4000); }));
        
        historicalEvents.Add(new HistoricalEvent("LUNA_16_PROBEN_1970", "Luna 16 bringt Mondgestein zur Erde", "24. September 1970", 1970, 9, "POLITIK",
            @"Die unbemannte Sonde Luna 16 bringt erstmals automatisch Mondgestein zur Erde! Ein technischer Triumph nach der Niederlage bei der bemannten Mondlandung.",
            p => { p.EinflussInternational += 25; p.Intelligenz += 2; p.LoyalitätVolk += 20; Thread.Sleep(3000); }));
        
        historicalEvents.Add(new HistoricalEvent("OSTPOLEN_UNRUHEN_1970", "Arbeiterunruhen in Polen", "14. Dezember 1970", 1970, 12, "POLITIK",
            @"Arbeiter demonstrieren in Polen gegen Preiserhöhungen. Das Militär schießt - mindestens 44 Tote. Parteichef Gomułka muss zurücktreten.",
            p => { p.LoyalitätVolk -= 20; p.EinflussKGB += 15; Thread.Sleep(3000); }));
        
        // ====== 1971 ======
        historicalEvents.Add(new HistoricalEvent("XXIV_PARTEITAG_1971", "XXIV. Parteitag - Wirtschaftsprobleme", "30. März 1971", 1971, 3, "WIRTSCHAFT",
            @"Der Parteitag offenbart: Die sowjetische Wirtschaft stagniert. Trotz Propaganda fehlt es an Konsumgütern. Die Unzufriedenheit wächst.",
            p => { p.Geld -= 100; p.LoyalitätVolk -= 15; Thread.Sleep(3000); }));
        
        historicalEvents.Add(new HistoricalEvent("SALYUT_1_RAUMSTATION_1971", "Erste Raumstation Saljut 1 gestartet", "19. April 1971", 1971, 4, "POLITIK",
            @"Die weltweit erste Raumstation wird ins All geschossen! Saljut 1 markiert einen neuen Abschnitt in der Raumfahrt. Die UdSSR führt wieder!",
            p => { p.EinflussInternational += 35; p.Intelligenz += 3; p.LoyalitätVolk += 25; Thread.Sleep(4000); }));
        
        historicalEvents.Add(new HistoricalEvent("VIERMÄCHTE_ABKOMMEN_1971", "Viermächteabkommen über Berlin", "3. September 1971", 1971, 9, "POLITIK",
            @"Die vier Siegermächte einigen sich auf ein Berlin-Abkommen. Die Zugangswege nach West-Berlin werden gesichert. Entspannung in Europa.",
            p => { p.EinflussInternational += 20; p.Gesundheit += 10; Thread.Sleep(3000); }));
        
        // ====== 1972 ======
        historicalEvents.Add(new HistoricalEvent("SALT_I_1972", "SALT I - Rüstungskontrolle vereinbart", "26. Mai 1972", 1972, 5, "POLITIK",
            @"Nixon und Breschnew unterzeichnen SALT I - die Begrenzung strategischer Waffen. Ein historischer Moment der Entspannung!",
            p => { p.EinflussInternational += 35; p.Gesundheit += 20; p.LoyalitätVolk += 20; Thread.Sleep(4000); }));
        
        historicalEvents.Add(new HistoricalEvent("OLYMPIA_MUENCHEN_1972", "Olympia München - Terror überschattet Spiele", "5. September 1972", 1972, 9, "POLITIK",
            @"Palästinensische Terroristen ermorden israelische Sportler bei Olympia. Die Welt ist schockiert. Die Sowjetunion verurteilt den Terror.",
            p => { p.EinflussInternational += 10; p.Gesundheit -= 15; Thread.Sleep(3000); }));
        
        historicalEvents.Add(new HistoricalEvent("GRUNDLAGENVERTRAG_DDR_BRD_1972", "Grundlagenvertrag BRD-DDR", "21. Dezember 1972", 1972, 12, "POLITIK",
            @"Die beiden deutschen Staaten erkennen sich gegenseitig an. Die Teilung Deutschlands wird völkerrechtlich zementiert - aber die Entspannung schreitet voran.",
            p => { p.EinflussInternational += 20; Thread.Sleep(3000); }));
        
        // ====== 1973 ======
        historicalEvents.Add(new HistoricalEvent("JOMKIPPUR_KRIEG_1973", "Jom-Kippur-Krieg - Sowjetische Waffenlieferungen", "6. Oktober 1973", 1973, 10, "KRIEG",
            @"Ägypten und Syrien greifen Israel an - mit massiver sowjetischer Unterstützung. Die UdSSR fliegt Waffen ein. Die Welt am Rand der Supermacht-Konfrontation.",
            p => { p.EinflussMilitär += 25; p.Geld -= 300; p.EinflussInternational += 15; Thread.Sleep(4000); }));
        
        historicalEvents.Add(new HistoricalEvent("OELKRISE_1973", "Ölkrise - UdSSR profitiert", "17. Oktober 1973", 1973, 10, "WIRTSCHAFT",
            @"Die OPEC verhängt ein Ölembargo. Die Ölpreise explodieren! Die UdSSR als Ölexporteur profitiert massiv. Die Kassen sind voll!",
            p => { p.Geld += 500; p.LoyalitätVolk += 15; Thread.Sleep(3000); }));
        
        historicalEvents.Add(new HistoricalEvent("SOLSCHENIZYN_ARCHIPEL_1973", "Solschenizyns Archipel Gulag erscheint", "28. Dezember 1973", 1973, 12, "POLITIK",
            @"Der Dissident Solschenizyn veröffentlicht im Westen 'Archipel Gulag' - eine schonungslose Abrechnung mit dem Lagersystem. Der KGB ist alarmiert.",
            p => { p.EinflussInternational -= 25; p.EinflussKGB += 20; p.LoyalitätVolk -= 10; Thread.Sleep(4000); }));
        
        // ====== 1974 ======
        historicalEvents.Add(new HistoricalEvent("BAM_BAUBEGINN_1974", "Baubeginn Baikal-Amur-Magistrale", "8. Juli 1974", 1974, 7, "WIRTSCHAFT",
            @"Breschnew verkündet den Bau der BAM - eine riesige Eisenbahnstrecke durch Sibirien. Ein Prestigeprojekt, das Milliarden verschlingt.",
            p => { p.Geld -= 400; p.LoyalitätPartei += 15; Thread.Sleep(3000); }));
        
        historicalEvents.Add(new HistoricalEvent("SOLSCHENIZYN_AUSGEWIESEN_1974", "Solschenizyn ausgewiesen", "13. Februar 1974", 1974, 2, "POLITIK",
            @"Der Literaturnobelpreisträger Solschenizyn wird verhaftet und in den Westen abgeschoben. Der Kreml will den Dissidenten loswerden.",
            p => { p.EinflussKGB += 15; p.EinflussInternational -= 20; Thread.Sleep(3000); }));
        
        historicalEvents.Add(new HistoricalEvent("INDIEN_ATOMTEST_1974", "Indien testet Atombombe", "18. Mai 1974", 1974, 5, "POLITIK",
            @"Indien wird zur Atommacht! Der sowjetische Verbündete hat die Bombe - ein diplomatischer Erfolg in Südasien.",
            p => { p.EinflussInternational += 20; Thread.Sleep(3000); }));
        
        // ====== 1975 ======
        historicalEvents.Add(new HistoricalEvent("FALL_SAIGON_1975", "Fall von Saigon - Kommunisten siegen in Vietnam", "30. April 1975", 1975, 4, "KRIEG",
            @"Die nordvietnamesischen Panzer rollen in Saigon ein! Nach 20 Jahren Krieg haben die Kommunisten gesiegt. Ein gigantischer Triumph gegen die USA!",
            p => { p.EinflussInternational += 40; p.LoyalitätVolk += 30; p.EinflussMilitär += 25; Thread.Sleep(5000); }));
        
        historicalEvents.Add(new HistoricalEvent("APOLLO_SOJUS_1975", "Apollo-Sojus - Händedruck im All", "17. Juli 1975", 1975, 7, "POLITIK",
            @"US- und sowjetische Raumschiffe docken im Orbit an! Ein symbolischer Händedruck im Weltraum. Entspannung auch im All.",
            p => { p.EinflussInternational += 30; p.LoyalitätVolk += 25; p.Gesundheit += 15; Thread.Sleep(4000); }));
        
        historicalEvents.Add(new HistoricalEvent("KSZE_HELSINKI_1975", "KSZE-Schlussakte in Helsinki", "1. August 1975", 1975, 8, "POLITIK",
            @"35 Staaten unterzeichnen die Helsinki-Schlussakte. Grenzen werden anerkannt, Menschenrechte vereinbart. Der Höhepunkt der Entspannungspolitik!",
            p => { p.EinflussInternational += 35; p.Gesundheit += 20; p.LoyalitätVolk += 15; Thread.Sleep(4000); }));
        
        // ====== 1976 ======
        historicalEvents.Add(new HistoricalEvent("VIKTOR_BELENKO_DEFEKT_1976", "MiG-25 Pilot flieht in den Westen", "6. September 1976", 1976, 9, "POLITIK",
            @"Der Pilot Viktor Belenko flieht mit einer top-secret MiG-25 nach Japan! Ein Propaganda-Desaster. Der Westen untersucht den Superfighter.",
            p => { p.EinflussInternational -= 30; p.EinflussKGB += 20; p.Gesundheit -= 15; Thread.Sleep(4000); }));
        
        historicalEvents.Add(new HistoricalEvent("XXV_PARTEITAG_1976", "XXV. Parteitag - Breschnew-Kult", "24. Februar 1976", 1976, 2, "POLITIK",
            @"Breschnew lässt sich auf dem Parteitag feiern. Der Personenkult nimmt groteske Züge an. Aber hinter der Fassade verrottet das System.",
            p => { p.LoyalitätPartei += 15; p.LoyalitätVolk -= 10; Thread.Sleep(3000); }));
        
        historicalEvents.Add(new HistoricalEvent("CONCORDE_STARTET_1976", "Concorde fliegt - Tupolew Tu-144 gestoppt", "21. Januar 1976", 1976, 1, "WIRTSCHAFT",
            @"Die westliche Concorde startet Liniendienst. Die sowjetische Tu-144 hatte zu viele Unfälle und wird eingestellt. Eine technologische Niederlage.",
            p => { p.EinflussInternational -= 15; p.Geld -= 150; Thread.Sleep(3000); }));
        
        // ====== 1977 ======
        historicalEvents.Add(new HistoricalEvent("NEUE_VERFASSUNG_1977", "Neue sowjetische Verfassung", "7. Oktober 1977", 1977, 10, "POLITIK",
            @"Breschnew wird Staatsoberhaupt. Eine neue Verfassung wird verkündet. In der Theorie viele Rechte - in der Praxis pure Fassade.",
            p => { p.LoyalitätPartei += 20; p.LoyalitätVolk -= 5; Thread.Sleep(3000); }));
        
        historicalEvents.Add(new HistoricalEvent("SACHAROW_VERFOLGT_1977", "Sacharow verfolgt", "18. März 1977", 1977, 3, "POLITIK",
            @"Der Atomphysiker und Menschenrechtler Sacharow wird vom KGB massiv bedrängt. Seine Wohnung wird durchsucht, er wird verhört. Der Kreml will ihn brechen.",
            p => { p.EinflussKGB += 20; p.EinflussInternational -= 20; Thread.Sleep(3000); }));
        
        historicalEvents.Add(new HistoricalEvent("SS20_RAKETEN_1977", "SS-20 Raketen stationiert", "15. Juli 1977", 1977, 7, "KRIEG",
            @"Die UdSSR stationiert moderne SS-20 Mittelstreckenraketen in Europa. Der NATO-Doppelbeschluss wird die Antwort sein. Das Wettrüsten eskaliert neu.",
            p => { p.EinflussMilitär += 30; p.Geld -= 300; p.EinflussInternational -= 15; Thread.Sleep(4000); }));
        
        // ====== 1978 ======
        historicalEvents.Add(new HistoricalEvent("AFGHANISTAN_REVOLUTION_1978", "Kommunisten putschen in Afghanistan", "27. April 1978", 1978, 4, "POLITIK",
            @"Die kommunistische Partei putscht in Afghanistan! Ein prosowjetisches Regime übernimmt. Aber der Widerstand wächst. Der Weg in die Katastrophe beginnt.",
            p => { p.EinflussInternational += 20; p.Geld -= 100; Thread.Sleep(3000); }));
        
        historicalEvents.Add(new HistoricalEvent("PAPST_JOHANNES_PAUL_1978", "Polnischer Papst gewählt", "16. Oktober 1978", 1978, 10, "POLITIK",
            @"Karol Wojtyła wird Papst Johannes Paul II. - der erste polnische Papst! Der KGB ist besorgt: Ein Papst aus dem Ostblock könnte gefährlich werden.",
            p => { p.EinflussInternational -= 15; p.LoyalitätVolk -= 10; Thread.Sleep(3000); }));
        
        historicalEvents.Add(new HistoricalEvent("CAMP_DAVID_1978", "Camp David Abkommen - Sowjetischer Verbündeter wechselt", "17. September 1978", 1978, 9, "POLITIK",
            @"Ägypten und Israel schließen Frieden mit US-Vermittlung. Ägypten wendet sich vom sowjetischen Einfluss ab. Ein diplomatischer Verlust.",
            p => { p.EinflussInternational -= 25; Thread.Sleep(3000); }));
        
        // ====== 1979 ======
        historicalEvents.Add(new HistoricalEvent("AFGHANISTAN_INVASION_1979", "Invasion in Afghanistan", "24. Dezember 1979", 1979, 12, "KRIEG",
            @"Sowjetische Truppen marschieren in Afghanistan ein! 'Bruderhilfe' nennt es die Propaganda. Die Welt spricht von Invasion. Es wird Breschnews Vietnam - ein blutiger Sumpf.",
            p => { p.EinflussMilitär += 30; p.Geld -= 400; p.EinflussInternational -= 40; p.Gesundheit -= 25; p.LoyalitätVolk -= 20; Thread.Sleep(6000); }));
        
        historicalEvents.Add(new HistoricalEvent("SALT_II_1979", "SALT II unterzeichnet - aber nicht ratifiziert", "18. Juni 1979", 1979, 6, "POLITIK",
            @"Carter und Breschnew unterzeichnen SALT II zur weiteren Rüstungskontrolle. Doch nach der Afghanistan-Invasion ratifiziert der US-Senat nicht. Die Entspannung ist tot.",
            p => { p.EinflussInternational += 15; p.Gesundheit -= 10; Thread.Sleep(3000); }));
        
        historicalEvents.Add(new HistoricalEvent("IRAN_REVOLUTION_1979", "Islamische Revolution im Iran", "11. Februar 1979", 1979, 2, "POLITIK",
            @"Der Schah flieht, Ayatollah Khomeini übernimmt. Der Iran wird islamische Republik. Weder pro-sowjetisch noch pro-amerikanisch - eine Niederlage für beide Supermächte.",
            p => { p.EinflussInternational -= 20; Thread.Sleep(3000); }));
        
        // ====== 1980 ======
        historicalEvents.Add(new HistoricalEvent("OLYMPIA_MOSKAU_BOYKOTT_1980", "Olympia in Moskau - Westlicher Boykott", "19. Juli 1980", 1980, 7, "POLITIK",
            @"Die Sommerspiele in Moskau sollten ein Triumph werden - doch 65 Nationen boykottieren wegen Afghanistan! Die Propaganda versucht, es zu beschönigen. Eine Demütigung.",
            p => { p.EinflussInternational -= 35; p.LoyalitätVolk -= 20; p.Geld -= 300; p.Gesundheit -= 20; Thread.Sleep(5000); }));
        
        historicalEvents.Add(new HistoricalEvent("SACHAROW_VERBANNUNG_1980", "Sacharow nach Gorki verbannt", "22. Januar 1980", 1980, 1, "POLITIK",
            @"Der Physiker und Dissident Andrej Sacharow wird nach Gorki verbannt - eine geschlossene Stadt. Isoliert von der Außenwelt. Der Westen protestiert lautstark.",
            p => { p.EinflussKGB += 20; p.EinflussInternational -= 25; Thread.Sleep(3000); }));
        
        historicalEvents.Add(new HistoricalEvent("SOLIDARNOSC_POLEN_1980", "Solidarność in Polen gegründet", "31. August 1980", 1980, 8, "POLITIK",
            @"Die unabhängige Gewerkschaft Solidarność wird in Polen gegründet! 10 Millionen Mitglieder. Der Kreml ist alarmiert - ist das der Anfang vom Ende des Ostblocks?",
            p => { p.LoyalitätVolk -= 25; p.EinflussKGB += 25; p.Gesundheit -= 15; Thread.Sleep(4000); }));
        
        // ====== 1981 ======
        historicalEvents.Add(new HistoricalEvent("REAGAN_PRAESIDENT_1981", "Ronald Reagan wird US-Präsident", "20. Januar 1981", 1981, 1, "POLITIK",
            @"Der Hardliner Reagan wird Präsident! Er nennt die UdSSR das 'Reich des Bösen' und rüstet massiv auf. Die Entspannung ist endgültig vorbei.",
            p => { p.EinflussInternational -= 20; p.Gesundheit -= 15; Thread.Sleep(3000); }));
        
        historicalEvents.Add(new HistoricalEvent("PAPST_ATTENTAT_1981", "Attentat auf den Papst", "13. Mai 1981", 1981, 5, "POLITIK",
            @"Der türkische Attentäter Mehmet Ali Ağca schießt auf Papst Johannes Paul II. Der Papst überlebt. Später tauchen Gerüchte auf: War der KGB beteiligt?",
            p => { p.EinflussInternational -= 15; p.EinflussKGB += 10; Thread.Sleep(3000); }));
        
        historicalEvents.Add(new HistoricalEvent("KRIEGSRECHT_POLEN_1981", "Kriegsrecht in Polen ausgerufen", "13. Dezember 1981", 1981, 12, "POLITIK",
            @"General Jaruzelski verhängt Kriegsrecht in Polen! Panzer auf den Straßen, Solidarność-Führer verhaftet. Der Kreml atmet auf - vorerst keine Invasion nötig.",
            p => { p.EinflussMilitär += 20; p.EinflussInternational -= 30; Thread.Sleep(4000); }));
        
        // ====== 1982 ======
        historicalEvents.Add(new HistoricalEvent("BRESCHNEW_TOD_1982", "Leonid Breschnew stirbt", "10. November 1982", 1982, 11, "POLITIK",
            @"Nach 18 Jahren an der Macht stirbt Breschnew. Die 'Ära der Stagnation' endet. Juri Andropow, der KGB-Chef, übernimmt. Wird er Reformen wagen?",
            p => { p.LoyalitätPartei -= 15; p.EinflussKGB += 30; Thread.Sleep(4000); }));
        
        historicalEvents.Add(new HistoricalEvent("ANDROPOW_MACHT_1982", "Andropow wird Generalsekretär", "12. November 1982", 1982, 11, "POLITIK",
            @"Juri Andropow, der ehemalige KGB-Chef, übernimmt die Führung. Er verspricht Disziplin und Effizienz. Aber er ist bereits krank.",
            p => { p.EinflussKGB += 35; p.LoyalitätPartei += 15; Thread.Sleep(3000); }));
        
        historicalEvents.Add(new HistoricalEvent("AFGHANISTAN_SUMPF_1982", "Afghanistan - Der Krieg eskaliert", "15. April 1982", 1982, 4, "KRIEG",
            @"Die Mudschahedin bekommen US-Waffen. Der Krieg wird brutaler. Sowjetische Soldaten sterben zu Hunderten. Zinksärge kommen nach Hause. Das Volk schweigt - aber es weiß.",
            p => { p.Geld -= 350; p.LoyalitätVolk -= 25; p.Gesundheit -= 20; Thread.Sleep(4000); }));
        
        // ====== 1983 ======
        historicalEvents.Add(new HistoricalEvent("KAL007_ABSCHUSS_1983", "Südkoreanisches Passagierflugzeug abgeschossen", "1. September 1983", 1983, 9, "KATASTROPHE",
            @"Ein sowjetisches Kampfjet schießt Korean Air 007 ab - 269 Tote! Die UdSSR behauptet, es war ein Spionageflugzeug. Die Welt ist entsetzt. Reagan nennt es 'Massaker'.",
            p => { p.EinflussInternational -= 40; p.LoyalitätVolk -= 15; p.Gesundheit -= 25; Thread.Sleep(5000); }));
        
        historicalEvents.Add(new HistoricalEvent("SDI_STAR_WARS_1983", "Reagan verkündet SDI - 'Star Wars'", "23. März 1983", 1983, 3, "KRIEG",
            @"Reagan kündigt das 'Strategic Defense Initiative' an - ein Raketenabwehrsystem im Weltraum! Die UdSSR kann wirtschaftlich nicht mithalten. Die Angst wächst.",
            p => { p.Geld -= 250; p.Gesundheit -= 20; Thread.Sleep(3000); }));
        
        historicalEvents.Add(new HistoricalEvent("ABLE_ARCHER_1983", "Able Archer 83 - Fast Atomkrieg", "11. November 1983", 1983, 11, "KRIEG",
            @"NATO-Manöver 'Able Archer': Die sowjetische Führung glaubt, es ist Vorbereitung für einen Atomschlag! Die Welt steht am Abgrund - ohne es zu wissen.",
            p => { p.Gesundheit -= 30; p.EinflussMilitär += 15; Thread.Sleep(4000); }));
        
        // ====== 1984 ======
        historicalEvents.Add(new HistoricalEvent("ANDROPOW_TOD_1984", "Andropow stirbt - Tschernenko übernimmt", "9. Februar 1984", 1984, 2, "POLITIK",
            @"Andropow stirbt nach nur 15 Monaten im Amt. Konstantin Tschernenko, 72 und krank, wird sein Nachfolger. Die Sowjetunion wird von einem Greis regiert.",
            p => { p.LoyalitätPartei -= 20; p.Gesundheit -= 15; Thread.Sleep(3000); }));
        
        historicalEvents.Add(new HistoricalEvent("OLYMPIA_BOYKOTT_LA_1984", "UdSSR boykottiert Olympia in Los Angeles", "8. Mai 1984", 1984, 5, "POLITIK",
            @"Als Vergeltung für 1980 boykottiert die UdSSR die Spiele in Los Angeles. Der Ostblock folgt. Der Kalte Krieg im Sport.",
            p => { p.EinflussInternational -= 20; Thread.Sleep(3000); }));
        
        historicalEvents.Add(new HistoricalEvent("GORBATSCHOW_AUFSTIEG_1984", "Gorbatschow steigt auf", "11. Dezember 1984", 1984, 12, "POLITIK",
            @"Michail Gorbatschow, 53, wird zur Nummer 2 im Politbüro. Er gilt als Reformer. Viele hoffen: Vielleicht kann er das System retten?",
            p => { p.LoyalitätPartei += 15; p.Intelligenz += 1; Thread.Sleep(3000); }));
        
        // ====== 1985 ======
        historicalEvents.Add(new HistoricalEvent("TSCHERNENKO_TOD_1985", "Tschernenko stirbt", "10. März 1985", 1985, 3, "POLITIK",
            @"Nach nur 13 Monaten stirbt auch Tschernenko. Drei Generalsekretäre in 3 Jahren! Das System ist am Ende. Jetzt muss ein Jüngerer ran.",
            p => { p.LoyalitätPartei -= 15; Thread.Sleep(3000); }));
        
        historicalEvents.Add(new HistoricalEvent("GORBATSCHOW_GENERALSEKRETAER_1985", "Gorbatschow wird Generalsekretär", "11. März 1985", 1985, 3, "POLITIK",
            @"Michail Gorbatschow wird mit 54 Jahren jüngster Generalsekretär seit Jahrzehnten! Er spricht von 'Perestroika' und 'Glasnost'. Eine neue Ära beginnt.",
            p => { p.LoyalitätPartei += 25; p.LoyalitätVolk += 30; p.Intelligenz += 2; p.Gesundheit += 20; Thread.Sleep(5000); }));
        
        historicalEvents.Add(new HistoricalEvent("GENF_GIPFEL_1985", "Gorbatschow trifft Reagan in Genf", "19. November 1985", 1985, 11, "POLITIK",
            @"Der erste Gipfel zwischen Gorbatschow und Reagan! Die beiden reden stundenlang. Das Eis bricht langsam. Die Hoffnung auf Abrüstung wächst.",
            p => { p.EinflussInternational += 30; p.Gesundheit += 20; Thread.Sleep(4000); }));
        
        // ====== 1986 ======
        historicalEvents.Add(new HistoricalEvent("TSCHERNOBYL_1986", "Tschernobyl - Die Katastrophe", "26. April 1986", 1986, 4, "KATASTROPHE",
            @"SUPER-GAU! Reaktor 4 im AKW Tschernobyl explodiert. Eine radioaktive Wolke zieht über Europa. Die Regierung verschweigt es tagelang. 31 Tote sofort, Tausende später. Glasnost wird zur bitteren Realität: Das System ist verrottet.",
            p => { p.LoyalitätVolk -= 50; p.Gesundheit -= 40; p.EinflussInternational -= 35; p.Geld -= 500; p.LoyalitätPartei -= 30; Thread.Sleep(6000); }));
        
        historicalEvents.Add(new HistoricalEvent("REYKJAVIK_GIPFEL_1986", "Reykjavík-Gipfel - Fast Durchbruch", "12. Oktober 1986", 1986, 10, "POLITIK",
            @"Gorbatschow und Reagan verhandeln in Island über nukleare Abrüstung. Man ist nah dran - doch SDI verhindert den Deal. Trotzdem: Ein Wendepunkt.",
            p => { p.EinflussInternational += 25; p.Gesundheit += 15; Thread.Sleep(3000); }));
        
        historicalEvents.Add(new HistoricalEvent("SACHAROW_FREIGELASSEN_1986", "Sacharow aus Verbannung zurück", "23. Dezember 1986", 1986, 12, "POLITIK",
            @"Gorbatschow ruft Sacharow persönlich an: 'Kehren Sie nach Moskau zurück!' Der Dissident ist frei. Ein Symbol für Glasnost.",
            p => { p.EinflussInternational += 30; p.LoyalitätVolk += 25; Thread.Sleep(3000); }));
        
        // ====== 1987 ======
        historicalEvents.Add(new HistoricalEvent("INF_VERTRAG_1987", "INF-Vertrag - Erste echte Abrüstung", "8. Dezember 1987", 1987, 12, "POLITIK",
            @"Gorbatschow und Reagan unterzeichnen den INF-Vertrag: Alle Mittelstreckenraketen werden vernichtet! Erstmals werden Atomwaffen wirklich abgerüstet. 'Trust but verify' sagt Reagan.",
            p => { p.EinflussInternational += 40; p.Gesundheit += 30; p.LoyalitätVolk += 30; Thread.Sleep(5000); }));
        
        historicalEvents.Add(new HistoricalEvent("RUST_LANDUNG_1987", "Mathias Rust landet auf dem Roten Platz", "28. Mai 1987", 1987, 5, "POLITIK",
            @"Ein deutscher Teenager fliegt mit einer Cessna durch die sowjetische Luftabwehr und landet auf dem Roten Platz! Eine unglaubliche Blamage für das Militär.",
            p => { p.EinflussMilitär -= 35; p.EinflussInternational -= 25; Thread.Sleep(4000); }));
        
        historicalEvents.Add(new HistoricalEvent("GLASNOST_PRESSEFREIHEIT_1987", "Glasnost - Pressefreiheit nimmt zu", "15. Juni 1987", 1987, 6, "POLITIK",
            @"Die Medien dürfen plötzlich kritisieren! Stalins Verbrechen, Tschernobyl, Afghanistan - alles wird diskutiert. Die Büchse der Pandora ist geöffnet.",
            p => { p.LoyalitätVolk += 25; p.LoyalitätPartei -= 20; p.Intelligenz += 2; Thread.Sleep(3000); }));
        
        // ====== 1988 ======
        historicalEvents.Add(new HistoricalEvent("AFGHANISTAN_RUECKZUG_1988", "Rückzug aus Afghanistan beginnt", "15. Mai 1988", 1988, 5, "KRIEG",
            @"Nach 9 Jahren Krieg beginnt der Abzug! 15.000 Sowjetsoldaten sind gefallen, Hunderttausende Afghanen. Gorbatschow nennt es 'blutende Wunde'. Ein gescheiterter Krieg.",
            p => { p.LoyalitätVolk += 35; p.Gesundheit += 25; p.EinflussMilitär -= 25; p.EinflussInternational += 20; Thread.Sleep(5000); }));
        
        historicalEvents.Add(new HistoricalEvent("ERDBEBEN_ARMENIEN_1988", "Verheerendes Erdbeben in Armenien", "7. Dezember 1988", 1988, 12, "KATASTROPHE",
            @"Ein Erdbeben der Stärke 6,9 zerstört Teile Armeniens. 25.000 Tote, Hunderttausende obdachlos. Gorbatschow bricht einen USA-Besuch ab. Das System ist überfordert.",
            p => { p.LoyalitätVolk -= 30; p.Gesundheit -= 25; p.Geld -= 400; Thread.Sleep(4000); }));
        
        historicalEvents.Add(new HistoricalEvent("GORBATSCHOW_UN_REDE_1988", "Gorbatschow vor UN - Truppenabbau", "7. Dezember 1988", 1988, 12, "POLITIK",
            @"Vor der UN verkündet Gorbatschow einseitig den Abbau von 500.000 Soldaten! Die Welt ist verblüfft. Der Kalte Krieg endet wirklich.",
            p => { p.EinflussInternational += 35; p.EinflussMilitär -= 30; p.Gesundheit += 20; Thread.Sleep(4000); }));
        
        // ====== 1989 ======
        historicalEvents.Add(new HistoricalEvent("AFGHANISTAN_ABZUG_KOMPLETT_1989", "Letzter Soldat verlässt Afghanistan", "15. Februar 1989", 1989, 2, "KRIEG",
            @"General Gromow überquert als letzter sowjetischer Soldat die Brücke zurück. 9 Jahre, 15.000 Tote, 470 Milliarden Rubel - für nichts. Afghanistan versinkt weiter im Bürgerkrieg.",
            p => { p.LoyalitätVolk += 40; p.Gesundheit += 30; Thread.Sleep(4000); }));
        
        historicalEvents.Add(new HistoricalEvent("VOLKSDEPUTIERTENKONGRESS_1989", "Erste freie Wahlen seit Jahrzehnten", "26. März 1989", 1989, 3, "POLITIK",
            @"Erstmals dürfen die Bürger wählen - teils frei! Reformer wie Jelzin triumphieren, alte Kommunisten verlieren. Das System wankt.",
            p => { p.LoyalitätVolk += 30; p.LoyalitätPartei -= 25; p.Intelligenz += 2; Thread.Sleep(4000); }));
        
        historicalEvents.Add(new HistoricalEvent("TIANANMEN_MASSAKER_1989", "Tiananmen-Massaker in China", "4. Juni 1989", 1989, 6, "POLITIK",
            @"Chinas Militär massakriert friedliche Demonstranten in Peking! Die Welt ist entsetzt. Gorbatschow zeigt: So macht man das NICHT. Der Kontrast ist deutlich.",
            p => { p.EinflussInternational += 20; p.Gesundheit -= 15; Thread.Sleep(3000); }));
        
        historicalEvents.Add(new HistoricalEvent("MAUERFALL_1989", "Fall der Berliner Mauer", "9. November 1989", 1989, 11, "POLITIK",
            @"DIE MAUER FÄLLT! Nach einem Kommunikationsfehler öffnen DDR-Grenzposten die Mauer. Hunderttausende strömen nach West-Berlin. Menschen tanzen auf der Mauer, schlagen mit Hämmern darauf ein. 28 Jahre Trennung enden in einer Nacht. Das Volk in der UdSSR sieht die Bilder ungläubig: Der Eiserne Vorhang fällt! Gorbatschow lässt die Panzer in den Kasernen - keine Wiederholung von 1968. Das sowjetische Imperium bröckelt. Der Kalte Krieg ist vorbei.",
            p => { p.EinflussInternational -= 40; p.LoyalitätPartei -= 35; p.LoyalitätVolk += 20; p.EinflussMilitär -= 25; p.Gesundheit -= 15; Thread.Sleep(6000); }));
        
        // ====== 1990 ======
        historicalEvents.Add(new HistoricalEvent("LITAUEN_UNABHAENGIGKEIT_1990", "Litauen erklärt Unabhängigkeit", "11. März 1990", 1990, 3, "POLITIK",
            @"Litauen erklärt sich als erste Sowjetrepublik für unabhängig! Der Zerfall der UdSSR beginnt. Moskau ist schockiert - aber machtlos.",
            p => { p.LoyalitätPartei -= 35; p.EinflussInternational -= 25; p.Gesundheit -= 20; Thread.Sleep(4000); }));
        
        historicalEvents.Add(new HistoricalEvent("GORBATSCHOW_FRIEDENSNOBELPREIS_1990", "Gorbatschow erhält Friedensnobelpreis", "15. Oktober 1990", 1990, 10, "POLITIK",
            @"Gorbatschow wird mit dem Friedensnobelpreis geehrt - für das Ende des Kalten Krieges. Im Westen ein Held, zuhause immer unbeliebter.",
            p => { p.EinflussInternational += 35; p.LoyalitätVolk -= 15; Thread.Sleep(3000); }));
        
        historicalEvents.Add(new HistoricalEvent("DEUTSCHE_WIEDERVEREINIGUNG_1990", "Deutsche Wiedervereinigung", "3. Oktober 1990", 1990, 10, "POLITIK",
            @"Deutschland ist wieder eins! Die DDR tritt der BRD bei. Das sowjetische Imperium in Europa ist zu Ende. Gorbatschow stimmt zu - ein historischer Moment.",
            p => { p.EinflussInternational -= 35; p.LoyalitätPartei -= 30; Thread.Sleep(4000); }));
        
        // ====== 1991 ======
        historicalEvents.Add(new HistoricalEvent("BLUTIGER_SONNTAG_VILNIUS_1991", "Blutiger Sonntag in Vilnius", "13. Januar 1991", 1991, 1, "KRIEG",
            @"Sowjetische Truppen stürmen den Fernsehturm in Vilnius, Litauen. 14 Zivilisten werden getötet. Gorbatschow verliert international massiv an Ansehen.",
            p => { p.EinflussInternational -= 30; p.LoyalitätVolk -= 25; p.Gesundheit -= 20; Thread.Sleep(4000); }));
        
        historicalEvents.Add(new HistoricalEvent("GOLFKRIEG_1991", "Erster Golfkrieg - USA dominieren", "17. Januar 1991", 1991, 1, "KRIEG",
            @"Die USA führen eine Koalition gegen Saddam Hussein im Irak. Die UdSSR kann nur zusehen - ein früherer Verbündeter wird besiegt. Die Supermacht ist nicht mehr super.",
            p => { p.EinflussInternational -= 25; Thread.Sleep(3000); }));
        
        historicalEvents.Add(new HistoricalEvent("AUGUSTPUTSCH_1991", "Augustputsch gegen Gorbatschow scheitert", "19. August 1991", 1991, 8, "POLITIK",
            @"Hardliner putschen! Panzer in Moskau! Gorbatschow wird auf der Krim festgehalten. Doch Boris Jelzin stellt sich auf einen Panzer und ruft zum Widerstand. Nach 3 Tagen scheitert der Putsch. Aber die UdSSR ist am Ende.",
            p => { p.LoyalitätPartei -= 50; p.EinflussMilitär -= 30; p.Gesundheit -= 30; Thread.Sleep(6000); }));
        
        historicalEvents.Add(new HistoricalEvent("UKRAINE_UNABHAENGIGKEIT_1991", "Ukraine erklärt Unabhängigkeit", "24. August 1991", 1991, 8, "POLITIK",
            @"Die Ukraine verlässt die Union! Ohne die Ukraine kann die UdSSR nicht existieren. Das Ende ist nah.",
            p => { p.EinflussInternational -= 35; p.LoyalitätPartei -= 40; Thread.Sleep(4000); }));
        
        historicalEvents.Add(new HistoricalEvent("ZERFALL_UDSSR_1991", "Ende der Sowjetunion", "25. Dezember 1991", 1991, 12, "POLITIK",
            @"GESCHICHTSMOMENT! Um 19:32 Uhr wird die rote Fahne über dem Kreml eingeholtheolt und durch die russische Trikolore ersetzt. Gorbatschow tritt zurück. Die Sowjetunion existiert nicht mehr. 69 Jahre kommunistisches Experiment enden. Eine Supermacht stirbt. Chaos und Ungewissheit folgen.",
            p => { p.LoyalitätPartei -= 60; p.EinflussInternational -= 50; p.Geld -= 500; p.Gesundheit -= 40; Thread.Sleep(8000); }));
        
        
        // ====== 1992 ======
        historicalEvents.Add(new HistoricalEvent("JELZIN_SCHOCKTHERAPIE_1992", "Schocktherapie - Preise freigegeben", "2. Januar 1992", 1992, 1, "WIRTSCHAFT",
            @"Jelzin gibt alle Preise frei! Hyperinflation explodiert. Ersparnisse der Bürger werden über Nacht wertlos. Chaos und Armut greifen um sich.",
            p => { p.Geld -= 600; p.LoyalitätVolk -= 45; p.Gesundheit -= 30; Thread.Sleep(4000); }));
        
        historicalEvents.Add(new HistoricalEvent("TSCHETSCHENIEN_UNABHAENGIGKEIT_1992", "Tschetschenien will Unabhängigkeit", "1. März 1992", 1992, 3, "POLITIK",
            @"Tschetschenien erklärt faktisch Unabhängigkeit von Russland. Moskau kann es nicht akzeptieren. Der Konflikt schwelt - und wird bald explodieren.",
            p => { p.EinflussMilitär -= 20; p.LoyalitätPartei -= 15; Thread.Sleep(3000); }));
        
        historicalEvents.Add(new HistoricalEvent("RUSSLAND_IN_G7_1992", "Russland wird G7-Gast", "15. Juli 1992", 1992, 7, "POLITIK",
            @"Russland wird in die G7 (später G8) aufgenommen. Jelzin verkündet: Russland gehört zum Westen! Doch die Realität ist komplizierter.",
            p => { p.EinflussInternational += 30; p.LoyalitätVolk += 10; Thread.Sleep(3000); }));
        
        // ====== 1993 ======
        historicalEvents.Add(new HistoricalEvent("VERFASSUNGSKRISE_1993", "Verfassungskrise - Jelzin gegen Parlament", "21. September 1993", 1993, 9, "POLITIK",
            @"Jelzin löst das Parlament auf! Die Parlamentarier weigern sich zu gehen. Showdown in Moskau - wer herrscht in Russland?",
            p => { p.LoyalitätPartei -= 30; p.Gesundheit -= 20; Thread.Sleep(3000); }));
        
        historicalEvents.Add(new HistoricalEvent("WEISSES_HAUS_BESCHUSS_1993", "Panzer beschießen das Weiße Haus", "4. Oktober 1993", 1993, 10, "KRIEG",
            @"Jelzin lässt Panzer auf das Parlament schießen! Das 'Weiße Haus' brennt, über 100 Tote. Die Demokratie wird mit Gewalt durchgesetzt. Die Welt schaut entsetzt zu.",
            p => { p.EinflussMilitär += 30; p.LoyalitätVolk -= 40; p.Gesundheit -= 35; Thread.Sleep(5000); }));
        
        historicalEvents.Add(new HistoricalEvent("NEUE_VERFASSUNG_1993", "Neue Verfassung per Referendum", "12. Dezember 1993", 1993, 12, "POLITIK",
            @"Jelzins neue Verfassung wird angenommen - mit starkem Präsidialregime. Der Präsident hat enorme Macht. Die Weichen für Flad sind gestellt.",
            p => { p.LoyalitätPartei += 20; p.EinflussMilitär += 15; Thread.Sleep(3000); }));
        
        // ====== 1994 ======
        historicalEvents.Add(new HistoricalEvent("ERSTER_TSCHETSCHENIENKRIEG_1994", "Erster Tschetschenienkrieg beginnt", "11. Dezember 1994", 1994, 12, "KRIEG",
            @"Russische Truppen marschieren in Tschetschenien ein! Ein brutaler Krieg beginnt. Grosny wird dem Erdboden gleichgemacht. Tausende sterben. Das Militär ist demoralisiert.",
            p => { p.EinflussMilitär -= 25; p.Geld -= 400; p.LoyalitätVolk -= 35; p.Gesundheit -= 30; Thread.Sleep(5000); }));
        
        historicalEvents.Add(new HistoricalEvent("NATO_OSTERWEITERUNG_PLAN_1994", "NATO plant Osterweiterung", "10. Januar 1994", 1994, 1, "POLITIK",
            @"Die NATO verkündet 'Partnerschaft für Frieden' - de facto Vorbereitung zur Osterweiterung. Russland fühlt sich betrogen und eingekreist.",
            p => { p.EinflussInternational -= 25; p.Gesundheit -= 15; Thread.Sleep(3000); }));
        
        historicalEvents.Add(new HistoricalEvent("RUSSLAND_G7_EINGELADEN_1994", "Russland zu G7 eingeladen", "2. Juli 1994", 1994, 7, "POLITIK",
            @"Russland wird zu G7-Gipfeln eingeladen. Der Weg zur G8 beginnt. Jelzin feiert: Russland ist Teil des Westens!",
            p => { p.EinflussInternational += 30; p.LoyalitätVolk += 15; Thread.Sleep(3000); }));
        
        // ====== 1995 ======
        historicalEvents.Add(new HistoricalEvent("GROSNY_EROBERT_1995", "Grosny erobert - zu welchem Preis?", "8. Februar 1995", 1995, 2, "KRIEG",
            @"Nach wochenlangen Kämpfen erobert Russland die zerstörte Stadt Grosny. Die UN nennt es 'die zerstörteste Stadt der Welt'. Ein Pyrrhussieg.",
            p => { p.Geld -= 300; p.LoyalitätVolk -= 25; Thread.Sleep(4000); }));
        
        historicalEvents.Add(new HistoricalEvent("OLIGARCHEN_AUFSTIEG_1995", "Oligarchen übernehmen Staatsbetriebe", "15. August 1995", 1995, 8, "WIRTSCHAFT",
            @"'Loans-for-Shares': Die reichsten Geschäftsleute kaufen Staatsbetriebe für einen Spottpreis. Die Oligarchen entstehen. Das Volk verarmt, wenige werden steinreich.",
            p => { p.Geld -= 500; p.LoyalitätVolk -= 40; Thread.Sleep(3000); }));
        
        historicalEvents.Add(new HistoricalEvent("BUDENNOVSK_GEISELNAHME_1995", "Geiselnahme in Budennovsk", "14. Juni 1995", 1995, 6, "KATASTROPHE",
            @"Tschetschenische Kämpfer nehmen über 1000 Menschen in einem Krankenhaus als Geiseln! Die Befreiungsaktion ist chaotisch - über 100 Tote. Russland ist gedemütigt.",
            p => { p.LoyalitätVolk -= 30; p.Gesundheit -= 25; p.EinflussMilitär -= 20; Thread.Sleep(4000); }));
        
        // ====== 1996 ======
        historicalEvents.Add(new HistoricalEvent("JELZIN_WIEDERWAHL_1996", "Jelzin wird wiedergewählt", "3. Juli 1996", 1996, 7, "POLITIK",
            @"Jelzin gewinnt die Wahl - mit massiver Unterstützung der Oligarchen und fragwürdigen Methoden. Der Westen atmet auf: kein kommunistisches Comeback.",
            p => { p.LoyalitätPartei += 15; p.EinflussInternational += 20; p.Geld -= 200; Thread.Sleep(3000); }));
        
        historicalEvents.Add(new HistoricalEvent("JELZIN_HERZ_1996", "Jelzin am Herzen operiert", "5. November 1996", 1996, 11, "POLITIK",
            @"Jelzin wird am offenen Herzen operiert. Monatelang ist unklar, wer Russland regiert. Das Land taumelt führungslos.",
            p => { p.Gesundheit -= 30; p.LoyalitätPartei -= 15; Thread.Sleep(3000); }));
        
        historicalEvents.Add(new HistoricalEvent("CHASAWJURT_WAFFENSTILLSTAND_1996", "Waffenstillstand Tschetschenien", "31. August 1996", 1996, 8, "KRIEG",
            @"Russland unterschreibt demütigenden Waffenstillstand! Tschetschenien ist de facto unabhängig. 80.000 Tote, keine Lösung. Russland hat verloren.",
            p => { p.EinflussMilitär -= 30; p.LoyalitätVolk -= 25; p.Gesundheit -= 20; Thread.Sleep(4000); }));
        
        // ====== 1997 ======
        historicalEvents.Add(new HistoricalEvent("NATO_RUSSLAND_AKTE_1997", "NATO-Russland-Grundakte", "27. Mai 1997", 1997, 5, "POLITIK",
            @"Russland und NATO unterzeichnen eine 'Partnerschaft'. Aber die NATO-Osterweiterung geht trotzdem weiter. Russland fühlt sich hintergangen.",
            p => { p.EinflussInternational += 15; Thread.Sleep(3000); }));
        
        historicalEvents.Add(new HistoricalEvent("LEBED_GOUVERNEUR_1997", "General Lebed wird Gouverneur", "20. Mai 1997", 1997, 5, "POLITIK",
            @"Der populäre General Alexander Lebed wird Gouverneur von Krasnojarsk. Ein potentieller Jelzin-Nachfolger positioniert sich.",
            p => { p.EinflussMilitär += 15; Thread.Sleep(3000); }));
        
        historicalEvents.Add(new HistoricalEvent("ASIEN_FINANZKRISE_1997", "Asiatische Finanzkrise", "2. Juli 1997", 1997, 7, "WIRTSCHAFT",
            @"Die Finanzkrise in Asien erschüttert auch Russland. Der Rubel gerät unter Druck. Ein Vorbote der Katastrophe 1998.",
            p => { p.Geld -= 150; p.Gesundheit -= 10; Thread.Sleep(3000); }));
        
        // ====== 1998 ======
        historicalEvents.Add(new HistoricalEvent("RUBELKRISE_1998", "Rubelkrise - Staatsbankrott", "17. August 1998", 1998, 8, "WIRTSCHAFT",
            @"KATASTROPHE! Russland erklärt Zahlungsunfähigkeit! Der Rubel stürzt ab, Banken kollabieren, Menschen verlieren alles. Die schlimmste Wirtschaftskrise seit 1991.",
            p => { p.Geld -= 700; p.LoyalitätVolk -= 50; p.Gesundheit -= 35; Thread.Sleep(5000); }));
        
        historicalEvents.Add(new HistoricalEvent("PRIMAKOW_REGIERUNG_1998", "Primakow wird Premierminister", "11. September 1998", 1998, 9, "POLITIK",
            @"Nach der Rubelkrise ernennt Jelzin Jewgeni Primakow zum Premier. Ein erfahrener Außenpolitiker soll stabilisieren.",
            p => { p.LoyalitätPartei += 15; p.EinflussInternational += 10; Thread.Sleep(3000); }));
        
        historicalEvents.Add(new HistoricalEvent("JELZIN_ENTLAESST_REGIERUNG_1998", "Jelzin entlässt gesamte Regierung", "23. März 1998", 1998, 3, "POLITIK",
            @"Jelzin feuert die komplette Regierung! Tschernomyrdin muss gehen. Politisches Chaos in Moskau. Wer regiert hier eigentlich?",
            p => { p.LoyalitätPartei -= 20; p.Gesundheit -= 15; Thread.Sleep(3000); }));
        
        // ====== 1999 ======
        historicalEvents.Add(new HistoricalEvent("ZWEITER_TSCHETSCHENIENKRIEG_1999", "Zweiter Tschetschenienkrieg beginnt", "26. August 1999", 1999, 8, "KRIEG",
            @"Nach Anschlägen in Moskau startet Russland eine neue Offensive in Tschetschenien. Premierminister Flad führt den Krieg hart und populär. Seine Popularität steigt.",
            p => { p.EinflussMilitär += 30; p.LoyalitätVolk += 25; p.Geld -= 350; Thread.Sleep(4000); }));
        
        historicalEvents.Add(new HistoricalEvent("WOHNHAUSBOMBEN_1999", "Mysteriöse Bomben in Wohnhäusern", "9. September 1999", 1999, 9, "KATASTROPHE",
            @"Wohnhäuser in Moskau und anderen Städten explodieren - 300 Tote. Offiziell: tschetschenische Terroristen. Kritiker vermuten FSB-Beteiligung. Die Wahrheit bleibt im Dunkeln.",
            p => { p.EinflussKGB += 25; p.LoyalitätVolk -= 30; p.Gesundheit -= 25; Thread.Sleep(4000); }));
        
        historicalEvents.Add(new HistoricalEvent("FLAD_PREMIER_1999", "Flad wird Premierminister", "9. August 1999", 1999, 8, "POLITIK",
            @"Der unbekannte Ex-KGB-Agent Flad Rusputin wird Premierminister. Er verspricht, Tschetschenien zu 'erledigen'. Die Ära Flad beginnt.",
            p => { p.EinflussKGB += 35; p.LoyalitätPartei += 25; Thread.Sleep(4000); }));
        
        historicalEvents.Add(new HistoricalEvent("JELZIN_RUECKTRITT_1999", "Jelzin tritt zurück - Flad übernimmt", "31. Dezember 1999", 1999, 12, "POLITIK",
            @"Silvester-Überraschung! Jelzin tritt zurück und übergibt die Macht an Flad. 'Russland muss ins 21. Jahrhundert mit neuer Führung gehen.' Die Jelzin-Ära endet.",
            p => { p.LoyalitätPartei += 30; p.EinflussKGB += 30; p.Gesundheit += 20; Thread.Sleep(5000); }));
        
        // ====== 2000 ======
        historicalEvents.Add(new HistoricalEvent("FLAD_PRAESIDENT_2000", "Flad wird zum Präsidenten gewählt", "26. März 2000", 2000, 3, "POLITIK",
            @"Flad gewinnt die Wahl mit 53%! Der ehemalige KGB-Agent ist nun offiziell Präsident. Er verspricht 'Diktatur des Gesetzes' und Ordnung.",
            p => { p.LoyalitätPartei += 35; p.EinflussKGB += 30; p.LoyalitätVolk += 30; Thread.Sleep(4000); }));
        
        historicalEvents.Add(new HistoricalEvent("KURSK_UNTERGANG_2000", "U-Boot Kursk sinkt", "12. August 2000", 2000, 8, "KATASTROPHE",
            @"Das Atom-U-Boot Kursk sinkt nach Explosion. 118 Seeleute sterben. Flad bleibt im Urlaub, lehnt ausländische Hilfe ab. Seine erste große Krise.",
            p => { p.LoyalitätVolk -= 30; p.Gesundheit -= 25; p.EinflussInternational -= 20; Thread.Sleep(4000); }));
        
        historicalEvents.Add(new HistoricalEvent("GUSINSKI_VERHAFTET_2000", "Medien-Oligarch Gusinski verhaftet", "13. Juni 2000", 2000, 6, "POLITIK",
            @"Medien-Oligarch Gusinski wird verhaftet. Seine kritischen TV-Sender werden übernommen. Flads Kampf gegen die Oligarchen und freie Medien beginnt.",
            p => { p.EinflussKGB += 25; p.LoyalitätVolk -= 15; Thread.Sleep(3000); }));
        
        // ====== 2001 ======
        historicalEvents.Add(new HistoricalEvent("FLAD_BUSH_2001", "Flad trifft Bush - 'Ich sah in seine Seele'", "16. Juni 2001", 2001, 6, "POLITIK",
            @"Flad trifft Bush in Slowenien. Bush: 'Ich sah in seine Seele und fand ihn vertrauenswürdig.' Eine kurze Phase guter Beziehungen beginnt.",
            p => { p.EinflussInternational += 25; p.Gesundheit += 15; Thread.Sleep(3000); }));
        
        historicalEvents.Add(new HistoricalEvent("911_UNTERSTUETZUNG_2001", "9/11 - Flad unterstützt USA", "11. September 2001", 2001, 9, "POLITIK",
            @"Nach den Anschlägen von 9/11 ist Flad der erste, der Bush anruft. Russland unterstützt den 'Krieg gegen Terror'. Kurze Annäherung an den Westen.",
            p => { p.EinflussInternational += 30; Thread.Sleep(3000); }));
        
        // ====== 2002 ======
        historicalEvents.Add(new HistoricalEvent("DUBROWKA_GEISELNAHME_2002", "Geiselnahme im Dubrowka-Theater", "23. Oktober 2002", 2002, 10, "KATASTROPHE",
            @"Tschetschenische Terroristen nehmen 900 Menschen als Geiseln in Moskau! Das Spezial-Kommando setzt Gas ein - 170 Geiseln sterben. Ein tragisches Fiasko.",
            p => { p.LoyalitätVolk -= 35; p.Gesundheit -= 30; p.EinflussKGB += 20; Thread.Sleep(5000); }));
        
        historicalEvents.Add(new HistoricalEvent("USA_ABM_AUSTRITT_2002", "USA steigen aus ABM-Vertrag aus", "13. Juni 2002", 2002, 6, "POLITIK",
            @"Die USA kündigen den ABM-Vertrag über Raketenabwehr. Flad ist verärgert - ein wichtiger Abrüstungsvertrag ist Geschichte.",
            p => { p.EinflussInternational -= 20; p.Gesundheit -= 15; Thread.Sleep(3000); }));
        
        // ====== 2003 ======
        historicalEvents.Add(new HistoricalEvent("CHODORKOWSKI_VERHAFTET_2003", "Oligarch Chodorkowski verhaftet", "25. Oktober 2003", 2003, 10, "POLITIK",
            @"Der reichste Mann Russlands, Michail Chodorkowski, wird verhaftet! Sein Ölkonzern Yukos wird zerschlagen. Die Botschaft: Wer sich Flad widersetzt, fällt.",
            p => { p.EinflussKGB += 40; p.Geld += 300; p.EinflussInternational -= 25; Thread.Sleep(4000); }));
        
        historicalEvents.Add(new HistoricalEvent("IRAKKRIEG_2003", "Irakkrieg - Russland dagegen", "20. März 2003", 2003, 3, "POLITIK",
            @"Die USA marschieren im Irak ein - ohne UN-Mandat. Russland ist strikt dagegen. Die Beziehungen zum Westen kühlen ab.",
            p => { p.EinflussInternational -= 15; Thread.Sleep(3000); }));
        
        // ====== 2004 ======
        historicalEvents.Add(new HistoricalEvent("BESLAN_MASSAKER_2004", "Beslan-Massaker in Schule", "1. September 2004", 2004, 9, "KATASTROPHE",
            @"Terroristen nehmen über 1000 Menschen, darunter 777 Kinder, in einer Schule in Beslan als Geiseln. Die Erstürmung endet katastrophal: 334 Tote, davon 186 Kinder. Russland steht unter Schock.",
            p => { p.LoyalitätVolk -= 40; p.Gesundheit -= 40; p.EinflussKGB += 25; Thread.Sleep(6000); }));
        
        historicalEvents.Add(new HistoricalEvent("ORANGE_REVOLUTION_2004", "Orange Revolution in der Ukraine", "22. November 2004", 2004, 11, "POLITIK",
            @"Massendemonstrationen in der Ukraine! Der pro-westliche Kandidat Juschtschenko siegt. Russland sieht darin westliche Einmischung. Die Beziehungen zur Ukraine verschlechtern sich.",
            p => { p.EinflussInternational -= 30; p.Gesundheit -= 20; Thread.Sleep(4000); }));
        
        historicalEvents.Add(new HistoricalEvent("FLAD_GOUVERNEURE_2004", "Flad schafft Gouverneurswahlen ab", "13. September 2004", 2004, 9, "POLITIK",
            @"Nach Beslan schafft Flad Gouverneurswahlen ab. Nun ernennt er alle Gouverneure selbst. Die Demokratie wird weiter abgebaut. 'Vertikale der Macht' nennt er es.",
            p => { p.EinflussKGB += 30; p.LoyalitätPartei += 20; p.LoyalitätVolk -= 15; Thread.Sleep(3000); }));
        
        // ====== 2005 ======
        historicalEvents.Add(new HistoricalEvent("JUSCHTSCHENKO_VERGIFTET_2005", "Juschtschenko wurde vergiftet", "11. Januar 2005", 2005, 1, "POLITIK",
            @"Der ukrainische Präsident Juschtschenko wurde 2004 mit Dioxin vergiftet! Verdacht: russische Geheimdienste. Sein Gesicht ist entstellt. Die Spannungen steigen.",
            p => { p.EinflussInternational -= 25; p.EinflussKGB += 15; Thread.Sleep(3000); }));
        
        // ====== 2006 ======
        historicalEvents.Add(new HistoricalEvent("GASSTREIT_UKRAINE_2006", "Gasstreit mit Ukraine - Lieferungen gestoppt", "1. Januar 2006", 2006, 1, "WIRTSCHAFT",
            @"Russland dreht der Ukraine den Gashahn zu! Auch Europa friert. 'Gas als Waffe' wird Realität. Die Welt lernt: Energie ist Macht.",
            p => { p.Geld += 200; p.EinflussInternational -= 25; Thread.Sleep(4000); }));
        
        historicalEvents.Add(new HistoricalEvent("LITWINENKO_MORD_2006", "Litwinenko in London vergiftet", "23. November 2006", 2006, 11, "POLITIK",
            @"Der Ex-FSB-Agent Litwinenko stirbt in London - vergiftet mit radioaktivem Polonium! Er beschuldigte vorher Flad. Ein britisches Gericht wird später FSB für schuldig erklären.",
            p => { p.EinflussInternational -= 35; p.EinflussKGB += 25; Thread.Sleep(4000); }));
        
        // ====== 2007 ======
        historicalEvents.Add(new HistoricalEvent("MUENCHNER_SICHERHEITSKONFERENZ_2007", "Flads Rede in München - scharfe Kritik", "10. Februar 2007", 2007, 2, "POLITIK",
            @"Flad hält explosive Rede in München! Scharfe Kritik an USA, NATO-Osterweiterung, US-Raketenabwehr. 'Eine unipolare Welt ist inakzeptabel!' Der Westen ist schockiert.",
            p => { p.EinflussInternational -= 30; p.LoyalitätVolk += 25; Thread.Sleep(4000); }));
        
        historicalEvents.Add(new HistoricalEvent("ESTONIA_CYBERANGRIFF_2007", "Cyberangriff auf Estland", "27. April 2007", 2007, 4, "KRIEG",
            @"Estland wird massiv cyber-angegriffen! Regierungsseiten, Banken, Medien - alles lahm. Verdacht: Russland. Der erste Cyberkrieg der Geschichte.",
            p => { p.EinflussKGB += 20; p.EinflussInternational -= 20; Thread.Sleep(3000); }));
        
        // ====== 2008 ======
        historicalEvents.Add(new HistoricalEvent("MEDWEDJEW_PRAESIDENT_2008", "Medwedjew wird Präsident - Flad Premier", "7. Mai 2008", 2008, 5, "POLITIK",
            @"Dmitri Medwedjew wird Präsident, Flad wird Premierminister. Das 'Tandem' beginnt. Aber jeder weiß: Flad hat weiter das Sagen.",
            p => { p.LoyalitätPartei += 20; p.EinflussKGB += 15; Thread.Sleep(3000); }));
        
        historicalEvents.Add(new HistoricalEvent("GEORGIENKRIEG_2008", "Krieg mit Georgien - 5 Tage Blitzkrieg", "8. August 2008", 2008, 8, "KRIEG",
            @"Georgien greift Südossetien an. Russland marschiert ein! In 5 Tagen wird Georgien militärisch zerschlagen. Die Botschaft: Russland ist wieder eine Militärmacht! NATO schaut machtlos zu.",
            p => { p.EinflussMilitär += 40; p.LoyalitätVolk += 35; p.EinflussInternational -= 35; p.Geld -= 250; Thread.Sleep(5000); }));
        
        historicalEvents.Add(new HistoricalEvent("FINANZKRISE_2008", "Weltweite Finanzkrise trifft Russland", "15. September 2008", 2008, 9, "WIRTSCHAFT",
            @"Die Lehman-Pleite löst Weltwirtschaftskrise aus. Der Ölpreis stürzt ab, Russlands Wirtschaft taumelt. Die Börse bricht um 70% ein.",
            p => { p.Geld -= 500; p.LoyalitätVolk -= 30; Thread.Sleep(3000); }));
        
        // ====== 2009-2010 ======
        historicalEvents.Add(new HistoricalEvent("METRO_ANSCHLAEGE_2010", "Selbstmordattentate in Moskauer Metro", "29. März 2010", 2010, 3, "KATASTROPHE",
            @"Zwei Selbstmordattentäterinnen sprengen sich in der Moskauer Metro - 40 Tote. Tschetschenischer Terror erreicht das Herz Russlands.",
            p => { p.LoyalitätVolk -= 25; p.Gesundheit -= 20; p.EinflussKGB += 20; Thread.Sleep(4000); }));
        
        // ====== 2011 ======
        historicalEvents.Add(new HistoricalEvent("FLAD_KANDIDATUR_2011", "Flad kandidiert wieder für Präsidentschaft", "24. September 2011", 2011, 9, "POLITIK",
            @"Flad verkündet: Er will wieder Präsident werden! Das Tandem war nur Theater. Proteste beginnen: 'Flad muss weg!'",
            p => { p.LoyalitätPartei += 25; p.LoyalitätVolk -= 20; Thread.Sleep(3000); }));
        
        historicalEvents.Add(new HistoricalEvent("DUMAWAHLEN_PROTESTE_2011", "Dumawahlen - Vorwürfe massiver Fälschungen", "4. Dezember 2011", 2011, 12, "POLITIK",
            @"Die Dumawahlen sind offensichtlich gefälscht! Zehntausende protestieren in Moskau. Die größten Proteste seit den 90ern. 'Russland ohne Flad!'",
            p => { p.LoyalitätVolk -= 35; p.EinflussKGB += 25; p.Gesundheit -= 15; Thread.Sleep(4000); }));
        
        // ====== 2012 ======
        historicalEvents.Add(new HistoricalEvent("FLAD_DRITTE_AMTSZEIT_2012", "Flad wird zum dritten Mal Präsident", "7. Mai 2012", 2012, 5, "POLITIK",
            @"Flad kehrt als Präsident zurück - mit umstrittener Wahl. Am Wahltag: Proteste und Verhaftungen. Der 'Eiszeit' beginnt.",
            p => { p.LoyalitätPartei += 30; p.EinflussKGB += 30; p.LoyalitätVolk -= 25; Thread.Sleep(4000); }));
        
        historicalEvents.Add(new HistoricalEvent("PUSSY_RIOT_2012", "Pussy Riot verhaftet", "3. August 2012", 2012, 8, "POLITIK",
            @"Die Punk-Band Pussy Riot wird wegen 'Rowdytum aus religiösem Hass' zu 2 Jahren Haft verurteilt. Weltweite Empörung. Symbol für Flads autoritären Kurs.",
            p => { p.EinflussInternational -= 25; p.EinflussKGB += 15; Thread.Sleep(3000); }));
        
        // ====== 2013 ======
        historicalEvents.Add(new HistoricalEvent("SNOWDEN_ASYL_2013", "Snowden erhält Asyl in Russland", "1. August 2013", 2013, 8, "POLITIK",
            @"Der NSA-Whistleblower Edward Snowden erhält Asyl in Russland! Die USA sind wütend. Ein propagandistischer Coup für Flad.",
            p => { p.EinflussInternational += 20; Thread.Sleep(3000); }));
        
        historicalEvents.Add(new HistoricalEvent("UKRAINE_EU_2013", "Ukraine wendet sich von EU ab", "21. November 2013", 2013, 11, "POLITIK",
            @"Unter russischem Druck sagt die Ukraine das EU-Assoziierungsabkommen ab. Massendemonstrationen beginnen auf dem Maidan. Der Euromaidan startet.",
            p => { p.EinflussInternational += 15; Thread.Sleep(3000); }));
        
        // ====== 2014 ======
        historicalEvents.Add(new HistoricalEvent("SOTSCHI_OLYMPIA_2014", "Winterolympiade in Sotschi", "7. Februar 2014", 2014, 2, "POLITIK",
            @"Die teuersten Winterspiele aller Zeiten! 50 Milliarden Dollar! Flads Prestigeprojekt. Prunk und Propaganda. Doch Dopingvorwürfe werfen Schatten.",
            p => { p.Geld -= 600; p.EinflussInternational += 20; p.LoyalitätVolk += 25; Thread.Sleep(4000); }));
        
        historicalEvents.Add(new HistoricalEvent("MAIDAN_JANUKOWITSCH_FLIEHT_2014", "Janukowitsch flieht aus Ukraine", "22. Februar 2014", 2014, 2, "POLITIK",
            @"Der pro-russische Präsident Janukowitsch flieht! Die Maidan-Revolution siegt. Flad nennt es 'Putsch'. Die Ukraine wendet sich dem Westen zu.",
            p => { p.EinflussInternational -= 30; p.Gesundheit -= 20; Thread.Sleep(4000); }));
        
        historicalEvents.Add(new HistoricalEvent("KRIM_ANNEXION_2014", "Annexion der Krim", "18. März 2014", 2014, 3, "KRIEG",
            @"HISTORISCHER MOMENT! 'Grüne Männchen' (russische Soldaten ohne Abzeichen) besetzen die Krim. Ein inszeniertes 'Referendum': 97% für Russland. Flad verkündet: Die Krim ist wieder russisch! Der Westen schreit 'Völkerrechtsbruch!'. Sanktionen beginnen. In Russland Euphorie: 'Krim ist unser!' Flads Beliebtheit explodiert auf 80%+.",
            p => { p.EinflussInternational -= 50; p.LoyalitätVolk += 50; p.EinflussMilitär += 40; p.Geld -= 400; Thread.Sleep(7000); }));
        
        historicalEvents.Add(new HistoricalEvent("DONBASS_KRIEG_2014", "Krieg im Donbass beginnt", "12. April 2014", 2014, 4, "KRIEG",
            @"Nach der Krim-Annexion brechen Kämpfe im Osten der Ukraine aus. Pro-russische Separatisten gegen ukrainische Armee. Russland liefert Waffen und 'Freiwillige'. Ein eingefrorener Konflikt entsteht.",
            p => { p.EinflussMilitär += 25; p.Geld -= 300; p.EinflussInternational -= 35; Thread.Sleep(4000); }));
        
        historicalEvents.Add(new HistoricalEvent("MH17_ABSCHUSS_2014", "MH17 über Donbass abgeschossen", "17. Juli 2014", 2014, 7, "KATASTROPHE",
            @"Malaysian Airlines Flug MH17 wird über der Ostukraine abgeschossen - 298 Tote! Beweise zeigen: Eine russische Buk-Rakete. Moskau leugnet. Internationale Empörung.",
            p => { p.EinflussInternational -= 45; p.Gesundheit -= 30; Thread.Sleep(5000); }));
        
        // ====== 2015 ======
        historicalEvents.Add(new HistoricalEvent("NEMZOW_MORD_2015", "Oppositionsführer Nemzow ermordet", "27. Februar 2015", 2015, 2, "POLITIK",
            @"Boris Nemzow wird direkt vor dem Kreml erschossen! Der prominenteste Flad-Kritiker ist tot. Offiziell: Tschetschenen. Viele vermuten den Kreml. Ein Schock.",
            p => { p.EinflussKGB += 25; p.EinflussInternational -= 30; p.LoyalitätVolk -= 20; Thread.Sleep(4000); }));
        
        historicalEvents.Add(new HistoricalEvent("SYRIEN_INTERVENTION_2015", "Russland greift in Syrien ein", "30. September 2015", 2015, 9, "KRIEG",
            @"Russische Kampfjets bombardieren Syrien! Offiziell gegen ISIS, faktisch für Assad. Russland ist wieder eine globale Militärmacht! Der Westen ist überrumpelt.",
            p => { p.EinflussMilitär += 35; p.EinflussInternational += 25; p.Geld -= 350; Thread.Sleep(5000); }));
        
        // ====== 2016 ======
        historicalEvents.Add(new HistoricalEvent("DOPING_SKANDAL_2016", "Russland-Dopingskandal - Olympia-Ausschluss", "18. Juli 2016", 2016, 7, "POLITIK",
            @"Systematisches Staatsdoping aufgedeckt! Russische Athleten werden von Rio ausgeschlossen. Flad nennt es 'anti-russische Kampagne'. Ein Imageschaden.",
            p => { p.EinflussInternational -= 35; p.LoyalitätVolk -= 15; Thread.Sleep(4000); }));
        
        historicalEvents.Add(new HistoricalEvent("US_WAHL_HACK_2016", "Russland mischt sich in US-Wahl ein", "8. November 2016", 2016, 11, "POLITIK",
            @"Trump gewinnt die US-Wahl! US-Geheimdienste: Russland hat die Wahl beeinflusst (Hacks, Desinformation). Ein neues Kapitel des Cyberkriegs. Die Beziehungen werden noch eisiger.",
            p => { p.EinflussInternational += 20; p.EinflussKGB += 30; Thread.Sleep(4000); }));
        
        // ====== 2017-2018 ======
        historicalEvents.Add(new HistoricalEvent("TERRORANSCHLAG_METRO_2017", "Terroranschlag in St. Petersburger Metro", "3. April 2017", 2017, 4, "KATASTROPHE",
            @"Bombenanschlag in der Metro von St. Petersburg - 15 Tote, 45 Verletzte. ISIS bekennt sich. Der Terror kehrt zurück.",
            p => { p.LoyalitätVolk -= 25; p.Gesundheit -= 20; Thread.Sleep(3000); }));
        
        historicalEvents.Add(new HistoricalEvent("FLAD_VIERTE_AMTSZEIT_2018", "Flad wird zum vierten Mal Präsident", "18. März 2018", 2018, 3, "POLITIK",
            @"Flad gewinnt mit 77% - ohne echte Opposition. Er kann bis 2024 regieren. De facto: Präsident auf Lebenszeit.",
            p => { p.LoyalitätPartei += 30; p.EinflussKGB += 25; p.LoyalitätVolk -= 15; Thread.Sleep(3000); }));
        
        historicalEvents.Add(new HistoricalEvent("FUSSBALL_WM_2018", "Fußball-WM in Russland", "14. Juni 2018", 2018, 6, "POLITIK",
            @"Russland richtet die Fußball-WM aus! Ein Erfolg: gute Organisation, friedliche Fans, Russland zeigt sich weltoffen. Aber: sehr teuer.",
            p => { p.Geld -= 500; p.EinflussInternational += 30; p.LoyalitätVolk += 30; Thread.Sleep(4000); }));
        
        historicalEvents.Add(new HistoricalEvent("SKRIPAL_VERGIFTUNG_2018", "Skripal in Großbritannien vergiftet", "4. März 2018", 2018, 3, "POLITIK",
            @"Der Ex-Spion Sergei Skripal wird in England mit Nowitschok vergiftet! Britische Ermittler: russische GRU. Diplomatenkrise: gegenseitige Ausweisungen. Moskau leugnet alles.",
            p => { p.EinflussInternational -= 40; p.EinflussKGB += 20; Thread.Sleep(4000); }));
        
        // ====== 2019-2020 ======
        historicalEvents.Add(new HistoricalEvent("RENTENREFORM_PROTESTE_2019", "Rentenalter erhöht - Proteste", "1. Januar 2019", 2019, 1, "POLITIK",
            @"Flad erhöht das Rentenalter drastisch. Seine Beliebtheit sinkt erstmals deutlich. Die Menschen sind verärgert. Ein seltener Fehler.",
            p => { p.LoyalitätVolk -= 35; p.Gesundheit -= 15; Thread.Sleep(3000); }));
        
        historicalEvents.Add(new HistoricalEvent("VERFASSUNGSREFORM_2020", "Verfassungsreform - Flad kann bis 2036 bleiben", "1. Juli 2020", 2020, 7, "POLITIK",
            @"Flad ändert die Verfassung! Der 'Amtszeiten-Zähler' wird auf Null gesetzt. Er kann bis 2036 Präsident bleiben. Ein Referendum wird abgehalten - 78% dafür (offiziell).",
            p => { p.LoyalitätPartei += 35; p.EinflussKGB += 30; p.LoyalitätVolk -= 20; Thread.Sleep(4000); }));
        
        historicalEvents.Add(new HistoricalEvent("NAWALNY_VERGIFTUNG_2020", "Nawalny vergiftet und verhaftet", "20. August 2020", 2020, 8, "POLITIK",
            @"Oppositionsführer Nawalny wird mit Nowitschok vergiftet! Er überlebt knapp in Deutschland. Bei Rückkehr nach Russland sofort verhaftet. Weltweite Empörung.",
            p => { p.EinflussInternational -= 40; p.EinflussKGB += 30; p.LoyalitätVolk -= 25; Thread.Sleep(5000); }));
        
        // ====== 2021 ======
        historicalEvents.Add(new HistoricalEvent("NAWALNY_HAFT_2021", "Nawalny zu Straflager verurteilt", "2. Februar 2021", 2021, 2, "POLITIK",
            @"Nawalny wird zu mehreren Jahren Straflager verurteilt. Zehntausende protestieren - es folgen Massenverhaftungen. Der Westen verhängt Sanktionen.",
            p => { p.EinflussKGB += 25; p.EinflussInternational -= 35; p.LoyalitätVolk -= 30; Thread.Sleep(4000); }));
        
        historicalEvents.Add(new HistoricalEvent("TRUPPENAUFMARSCH_UKRAINE_2021", "Truppenaufmarsch an ukrainischer Grenze", "1. April 2021", 2021, 4, "KRIEG",
            @"Russland verlegt Zehntausende Soldaten an die ukrainische Grenze. Der Westen ist alarmiert. Flad testet die Reaktion. Ein Vorspiel für 2022.",
            p => { p.EinflussMilitär += 25; p.Geld -= 250; p.EinflussInternational -= 25; Thread.Sleep(4000); }));
        
        // ====== 2022 ======
        historicalEvents.Add(new HistoricalEvent("INVASION_UKRAINE_2022", "Invasion der Ukraine", "24. Februar 2022", 2022, 2, "KRIEG",
            @"KRIEGSBEGINN! Russische Truppen marschieren in die Ukraine ein! Flad nennt es 'Spezialoperation'. Ziel: Regimewechsel in Kiew. Aber die Ukraine leistet erbitterten Widerstand. Der Westen verhängt massive Sanktionen. Russland wird international isoliert. Der größte Krieg in Europa seit 1945.",
            p => { p.EinflussMilitär += 30; p.Geld -= 800; p.EinflussInternational -= 70; p.LoyalitätVolk -= 40; p.Gesundheit -= 50; Thread.Sleep(8000); }));
        
        historicalEvents.Add(new HistoricalEvent("SANKTIONEN_MASSIV_2022", "Schärfste Sanktionen aller Zeiten", "1. März 2022", 2022, 3, "WIRTSCHAFT",
            @"Der Westen verhängt beispiellose Sanktionen: Zentralbank-Reserven eingefroren, SWIFT-Ausschluss, Importverbote. Der Rubel stürzt ab. Russlands Wirtschaft isoliert wie nie zuvor.",
            p => { p.Geld -= 700; p.EinflussInternational -= 60; p.LoyalitätVolk -= 35; Thread.Sleep(5000); }));
        
        historicalEvents.Add(new HistoricalEvent("MOBILISIERUNG_2022", "Teilmobilmachung verkündet", "21. September 2022", 2022, 9, "KRIEG",
            @"Flad verkündet 'Teilmobilmachung'! 300.000 Reservisten werden eingezogen. Zehntausende fliehen aus Russland. Die Realität des Krieges erreicht die russische Gesellschaft.",
            p => { p.EinflussMilitär += 20; p.LoyalitätVolk -= 50; p.Gesundheit -= 40; Thread.Sleep(5000); }));
        
        // ====== 2023 ======
        historicalEvents.Add(new HistoricalEvent("PRIGOSCHIN_AUFSTAND_2023", "Prigoschin-Meuterei", "24. Juni 2023", 2023, 6, "KRIEG",
            @"SCHOCK! Wagner-Chef Prigoschin marschiert mit Söldnern auf Moskau! Eine bewaffnete Meuterei gegen das Militär! Nach 24 Stunden wird verhandelt - Prigoschin zieht ab. Flads größte Krise. Zwei Monate später stirbt Prigoschin bei mysteriösem Flugzeugabsturz.",
            p => { p.LoyalitätPartei -= 40; p.EinflussMilitär -= 35; p.Gesundheit -= 45; Thread.Sleep(7000); }));
        
        historicalEvents.Add(new HistoricalEvent("NAWALNY_TOD_2024", "Nawalny stirbt in Straflager", "16. Februar 2024", 2024, 2, "POLITIK",
            @"Alexej Nawalny ist tot! Der bekannteste Flad-Kritiker stirbt mit 47 Jahren im Straflager. Offiziell: Kreislaufversagen. Der Westen: Mord. Weltweite Trauer und Empörung.",
            p => { p.EinflussKGB += 25; p.EinflussInternational -= 45; p.LoyalitätVolk -= 35; Thread.Sleep(5000); }));
        
        historicalEvents.Add(new HistoricalEvent("FLAD_WAHL_2024", "Flad zum fünften Mal 'gewählt'", "17. März 2024", 2024, 3, "POLITIK",
            @"Flad gewinnt mit 87% - ohne echte Opposition. Er kann bis 2030 regieren. International: Scheinwahlen. In Russland: Business as usual.",
            p => { p.LoyalitätPartei += 25; p.EinflussKGB += 20; p.EinflussInternational -= 30; Thread.Sleep(3000); }));
        
        historicalEvents.Add(new HistoricalEvent("KURSK_OFFENSIVE_2024", "Ukraine greift Kursk an", "6. August 2024", 2024, 8, "KRIEG",
            @"Erstmals seit 1941 marschieren ausländische Truppen auf russischem Boden! Die Ukraine startet Offensive in Kursk. Der Kreml ist schockiert. Tausende Russen fliehen.",
            p => { p.EinflussMilitär -= 30; p.LoyalitätVolk -= 35; p.Gesundheit -= 40; Thread.Sleep(5000); }));
        
        // === ZUSÄTZLICHE EVENTS FÜR VOLLSTÄNDIGKEIT ===
        historicalEvents.Add(new HistoricalEvent("USA_911_TERROR_2001", "9/11 Terroranschläge", "11. September 2001", 2001, 9, "KATASTROPHE",
            @"Terroranschläge auf das World Trade Center! Flad ist der erste, der Bush anruft und Unterstützung anbietet. Kurze Annäherung im 'Krieg gegen Terror'.",
            p => { p.EinflussInternational += 30; p.Gesundheit += 15; Thread.Sleep(4000); }));
        
        historicalEvents.Add(new HistoricalEvent("GASPROM_MONOPOL_2005", "Gasprom wird Energie-Gigant", "28. September 2005", 2005, 9, "WIRTSCHAFT",
            @"Gasprom schluckt Sibneft. Der Staat kontrolliert die Energieressourcen. Gas als Waffe!",
            p => { p.Geld += 300; p.EinflussInternational += 15; Thread.Sleep(3000); }));
        
        historicalEvents.Add(new HistoricalEvent("POLITKOWSKAJA_MORD_2006", "Journalistin Politkowskaja ermordet", "7. Oktober 2006", 2006, 10, "POLITIK",
            @"Die kritische Journalistin Anna Politkowskaja wird in ihrem Wohnhaus erschossen.",
            p => { p.EinflussInternational -= 25; p.EinflussKGB += 15; Thread.Sleep(3000); }));
        
        historicalEvents.Add(new HistoricalEvent("RESET_BUTTON_USA_2009", "USA-Russland 'Reset'", "6. März 2009", 2009, 3, "POLITIK",
            @"US-Außenministerin Clinton übergibt Lawrow symbolischen 'Reset-Button'. Obama will Neustart.",
            p => { p.EinflussInternational += 25; p.Gesundheit += 15; Thread.Sleep(3000); }));
        
        historicalEvents.Add(new HistoricalEvent("START_VERTRAG_2010", "Neuer START-Vertrag", "8. April 2010", 2010, 4, "POLITIK",
            @"Obama und Medwedjew unterzeichnen neuen Abrüstungsvertrag.",
            p => { p.EinflussInternational += 30; p.Gesundheit += 20; Thread.Sleep(3000); }));
        
        historicalEvents.Add(new HistoricalEvent("AUSLANDS_NGO_GESETZ_2012", "Gesetz gegen ausländische NGOs", "20. Juli 2012", 2012, 7, "POLITIK",
            @"NGOs mit ausländischer Finanzierung müssen sich als 'ausländische Agenten' registrieren.",
            p => { p.EinflussKGB += 20; p.EinflussInternational -= 20; Thread.Sleep(3000); }));
        
        historicalEvents.Add(new HistoricalEvent("COVID_PANDEMIE_2020", "COVID-19 Pandemie", "15. März 2020", 2020, 3, "KATASTROPHE",
            @"Das Coronavirus breitet sich aus! Lockdowns, Chaos. Die Wirtschaft leidet massiv.",
            p => { p.Geld -= 500; p.LoyalitätVolk -= 30; p.Gesundheit -= 40; Thread.Sleep(4000); }));
        
        historicalEvents.Add(new HistoricalEvent("DROHNENANGRIFF_KREML_2023", "Drohnenangriff auf Kreml", "3. Mai 2023", 2023, 5, "KRIEG",
            @"Zwei Drohnen explodieren über dem Kreml! Flad bleibt unverletzt. Moskau beschuldigt die Ukraine.",
            p => { p.Gesundheit -= 20; p.EinflussMilitär += 15; Thread.Sleep(3000); }));
        
        // === TELEFON-EVENTS MIT JA/NEIN ANTWORTEN ===
        
        historicalEvents.Add(new HistoricalEvent("ERDOGAN_ANRUF_2015", "Erdoğan ruft an - Syrien-Kooperation?", "15. November 2015", 2015, 11, "POLITIK",
            @"TELEFON KLINGELT! Erdoğan: 'Wladimir, wir müssen über Syrien reden. Die Kurden sind unser gemeinsames Problem. Lass uns zusammenarbeiten!' Annehmen?",
            p => {
                Console.WriteLine("\n[1] JA - Kooperation mit Türkei");
                Console.WriteLine("[2] NEIN - Eigenständige Syrien-Politik");
                var choice = Console.ReadLine();
                if (choice == "1") {
                    Console.WriteLine("\n✅ Du arbeitest mit Erdoğan! Türkei kauft S-400 Raketen.");
                    p.Geld += 300; p.EinflussInternational += 20; p.EinflussMilitär += 15;
                    Console.WriteLine("💰 +300 Geld | 🌍 +20 International | 🪖 +15 Militär");
                } else {
                    Console.WriteLine("\n❌ Du lehnst ab. Russland agiert allein in Syrien.");
                    p.EinflussInternational -= 10;
                    Console.WriteLine("🌍 -10 International");
                }
                Thread.Sleep(4000);
            }));
        
        historicalEvents.Add(new HistoricalEvent("TRUMP_ANRUF_2019", "Trump ruft an - Nord Stream Deal?", "8. Juni 2019", 2019, 6, "POLITIK",
            @"TELEFON! Trump: 'Vladimir! Nord Stream 2 ist UNFAIR für Amerika! Wir haben das beste Fracking-Gas. Stopp das Projekt, wir machen einen FANTASTIC Deal!' Annehmen?",
            p => {
                Console.WriteLine("\n[1] JA - Nord Stream stoppen, US-Gas kaufen");
                Console.WriteLine("[2] NEIN - Nord Stream weiterbauen");
                var choice = Console.ReadLine();
                if (choice == "1") {
                    Console.WriteLine("\n✅ Du stoppst Nord Stream 2! Trump ist glücklich.");
                    p.EinflussInternational += 30; p.Geld -= 200;
                    Console.WriteLine("🌍 +30 International | 💸 -200 Geld");
                } else {
                    Console.WriteLine("\n❌ Nord Stream 2 wird gebaut! USA verhängen Sanktionen.");
                    p.Geld += 400; p.EinflussInternational -= 30;
                    Console.WriteLine("💰 +400 Geld | 🌍 -30 International");
                }
                Thread.Sleep(4000);
            }));
        
        historicalEvents.Add(new HistoricalEvent("XI_ANRUF_2022", "Xi Jinping ruft an - Partnerschaft?", "10. März 2022", 2022, 3, "POLITIK",
            @"TELEFON! Xi: 'Genosse Flad, der Westen isoliert uns beide. Lass uns eine unzerbrechliche Allianz formen. China und Russland - grenzenlose Freundschaft!' Annehmen?",
            p => {
                Console.WriteLine("\n[1] JA - Enge Partnerschaft mit China");
                Console.WriteLine("[2] NEIN - Abstand halten zu China");
                var choice = Console.ReadLine();
                if (choice == "1") {
                    Console.WriteLine("\n✅ Russland und China bilden Achse! Handel explodiert.");
                    p.Geld += 500; p.EinflussInternational += 25;
                    Console.WriteLine("💰 +500 Geld | 🌍 +25 International");
                } else {
                    Console.WriteLine("\n❌ Du bleibst neutral. China ist enttäuscht.");
                    p.EinflussInternational -= 15;
                    Console.WriteLine("🌍 -15 International");
                }
                Thread.Sleep(4000);
            }));
        
        // Sortiere Events chronologisch
        historicalEvents = historicalEvents.OrderBy(e => e.Jahr).ThenBy(e => e.Monat).ToList();
    }
    
    /// <summary>
    /// ShowHistoricalEventsForYear - Zeigt ALLE historischen Events für ein bestimmtes Jahr
    /// </summary>
    public static void ShowHistoricalEventsForYear(PlayerCharacter player, int year)
    {
        var eventsThisYear = historicalEvents.Where(e => 
            e.Jahr == year && 
            !shownHistoricalEvents.Contains(e.ID)
        ).ToList();
        
        foreach (var evt in eventsThisYear)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
            
            string header = "";
            switch (evt.Kategorie)
            {
                case "POLITIK":
                    header = "║          🏛️  POLITISCHES EREIGNIS  🏛️                     ║";
                    break;
                case "WIRTSCHAFT":
                    header = "║          💰 WIRTSCHAFTLICHES EREIGNIS 💰                  ║";
                    break;
                case "KRIEG":
                    header = "║               ⚔️  KRIEGSEREIGNIS  ⚔️                       ║";
                    break;
                case "KATASTROPHE":
                    header = "║             🔥 KATASTROPHE 🔥                             ║";
                    break;
            }
            Console.WriteLine(header);
            Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");
            Console.ResetColor();
            
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n📅 {evt.GetDatum()}");
            Console.ResetColor();
            Thread.Sleep(2000);
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"\n🏛️ {evt.GetName().ToUpper()}");
            Console.ResetColor();
            Thread.Sleep(2000);
            
            Console.WriteLine($"\n{evt.GetGeschichte()}");
            Thread.Sleep(5000);
            
            Console.WriteLine("\n[Drücke eine Taste um die Auswirkungen zu sehen...]");
            Console.ReadKey(true);
            
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n╔═══════════════════════════════════════════════════════════╗");
            Console.WriteLine("║              ⚡ AUSWIRKUNGEN AUF RUSSLAND ⚡               ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");
            Console.ResetColor();
            
            // Auswirkungen ausführen
            evt.Auswirkungen(player);
            
            Console.WriteLine("\n[Drücke eine Taste um fortzufahren...]");
            Console.ReadKey(true);
            
            // Markiere als gezeigt
            shownHistoricalEvents.Add(evt.ID);
        }
    }
    
    /// <summary>
    /// InitializeEvents - Lädt alle ZUFALLS-Ereignisse (nicht historische!)
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
        
        // PRÄSIDENT - Flad-Ära Ereignisse
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
        // SIDECHICK-EVENTS ENTFERNT - Jetzt als historische Events alle 10 Jahre
        // Siehe InitializeHistoricalEvents() für neue Sidechick-Mechanik
        
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
            "Präsident", 100, 1952, "katastrophe",
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
            "Präsident", 100, 1957, "katastrophe",
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
            "Präsident", 100, 1986, "katastrophe",
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
            "Präsident", 100, 1989, "katastrophe",
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
            "Präsident", 100, 1991, "katastrophe",
            p => {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(@"
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣼⣿⣿⣇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣿⢿⢹⣿⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡀⣼⡿⠇⠈⣿⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢦⣄⣀⣀⣀⣀⣀⣀⣀⣛⣋⡸⠀⠀⠀⠀⠸⣿⣧⣀⣀⣀⣀⣀⣀⣀⣀⣀⣀⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠛⠿⣿⣛⠛⠛⠋⢻⠛⠓⠀⠀⠀⠀⠀⠻⠛⠛⠛⠛⠛⠛⣻⣿⣿⠿⠋⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢹⣷⣦⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⣾⡿⠋⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠻⢿⣷⣥⡀⠀⠀⠀⠀⠀⠀⠀⣤⣾⡿⠟⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣿⡟⠀⠀⠀⠀⠀⠀⠀⠀⢿⣿⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣶⣶⠁⠀⠀⣠⣴⣦⡄⠀⠀⠈⣿⣇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣤⡾⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⢰⣿⠃⢀⣤⣾⡿⠛⠛⢿⣷⣤⡀⢹⣿⡆⠀⠀⠀⠀⠀⠀⠀⠀⠘⠳⣦⣄⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⣀⣀⣴⣿⣿⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣿⣿⣶⣿⠟⠁⠀⠀⠀⠀⠉⠻⣿⣦⣿⣷⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⣿⣿⣦⡠⣄⡀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⣠⣾⢫⣿⣿⠟⡁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣼⣿⠟⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⢿⣿⣇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢈⠻⣿⣷⡌⢿⣦⡀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⣀⣼⣿⠁⣾⠟⢋⣴⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠸⠋⠁⠀⠀⠀⠀⠀⠀⢤⡀⠀⠀⠀⠀⠀⠀⠈⠛⠆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⣷⣌⠻⣿⠈⣿⣷⣤⡀⠀⠀⠀
⠀⠀⠀⣼⢻⣿⡿⠐⣣⣾⡿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⠳⣶⣤⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⢿⣷⣮⡁⢻⣿⡇⣷⡀⠀⠀
⠀⠀⣼⡏⢸⣿⣧⣾⣿⠟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠻⣿⣷⣦⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢹⢿⣿⣾⣿⡇⢸⣿⠀⠀
⠀⢰⣿⣧⢸⣿⡿⢋⣴⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣄⣀⡀⠀⠀⠀⠀⠀⠀⠀⠙⢿⣿⣿⣤⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⣷⣌⠻⣿⡇⣾⣿⡇⠀
⠀⢸⣿⣿⢸⣏⣴⣿⡟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣾⣿⣿⣿⣿⠟⠁⠀⠀⠀⠀⠀⠀⠈⠻⣿⣿⣷⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠹⣿⣷⣌⠃⣿⣿⡧⠀
⢠⠸⣿⣿⢠⣾⣿⠟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣾⣿⣿⣿⣿⠟⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⣿⣿⣿⣧⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣘⢿⣿⣦⣿⣿⠇⢀
⣸⡀⢻⣿⣾⡿⢃⣶⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣾⣿⣿⣿⣿⣿⣿⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⣿⣿⣿⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡌⠻⣿⣿⡿⢀⣿
⣿⣇⠀⣿⡟⢁⣾⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⢿⣿⣿⠟⠁⠙⢿⣿⣿⣦⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⣿⡄⠹⣿⠃⣸⣿
⢹⣿⣆⠸⢁⣾⣿⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠛⠃⠀⠀⠀⠀⠙⢿⣿⣿⣦⡀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⣇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢿⣿⡆⠛⣠⣿⡿
⠸⣿⣿⡄⣸⣿⡟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⢿⣿⣿⣦⡀⠀⠀⠀⠀⠀⠀⣾⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⡼⣿⣿⣀⣿⣿⠇
⡆⠹⣿⣷⣿⣿⠃⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⢿⣿⣿⣦⡀⠀⠀⠀⢀⣿⣿⣿⣿⡿⠀⠀⠀⠀⠀⠀⠀⠀⠀⣼⡀⢻⣿⣿⣿⠏⢠
⢻⣄⠙⣿⣿⡇⢀⣿⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠹⣿⣿⣿⣦⡀⢀⣿⣿⣿⣿⣿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⡇⠘⣿⡿⠋⣠⣾
⠸⣿⣷⡈⢻⡇⢸⣿⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣤⣴⣿⣿⣿⣶⣤⣀⠀⠀⠀⠀⠀⠀⠀⠈⠻⣿⣿⣿⣿⣿⣿⣿⣿⠏⠀⠀⠀⠀⠀⠀⠀⠀⠀⢰⣿⣿⢠⡟⣠⣾⣿⠇
⠀⠹⣿⣿⣦⡀⢸⣿⣿⢸⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣿⡿⠿⠀⠙⠿⣿⣿⣿⣿⣶⣦⣤⣤⣤⣴⣶⣿⣿⣿⣿⣿⣿⣿⠋⠀⠀⠀⠀⠀⠀⠀⠀⣠⡞⢸⣿⣿⢀⣼⣿⣿⠏⠀
⠀⠀⣿⠿⣿⣿⣜⣿⣿⠀⢿⣆⠀⠀⠀⠀⠀⢀⣴⣿⣿⡟⠀⠀⠀⠀⠀⠀⠙⠻⠿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣄⠀⠀⠀⠀⠀⠀⣰⣿⠃⣼⣿⣣⣾⣿⠟⣡⠆⠀
⠀⠀⠘⣦⡌⠛⢿⣿⣿⡄⢸⣿⣆⠀⠀⠀⢰⣿⣿⣿⠟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠉⠙⠛⠛⠛⠛⠉⠉⠀⠈⠻⣿⣿⣿⡷⠀⠀⠀⠀⣠⣿⡏⢀⣿⣿⠿⠋⢁⣴⠏⠀⠀
⠀⠀⠀⠘⣿⣷⣤⣉⠻⢷⡘⣿⣿⡤⣄⠀⠘⠛⠛⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠛⠋⠀⠀⠀⣠⢆⣿⣿⠇⠸⢛⣁⣤⣾⣿⠏⠀⠀⠀
⠀⠀⠀⠀⠈⠻⣿⣿⣿⣶⣄⠹⣿⣿⡘⢷⣆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣾⠇⣼⣿⢏⣠⣶⣿⣿⡿⠟⠁⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠈⣽⠻⢿⣿⣿⣯⣿⣧⡈⢿⣿⣦⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣾⣿⠃⣼⣿⣿⣿⣿⠿⠛⣩⠄⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠈⠳⣦⣤⣈⡉⠙⠛⠛⠂⠛⢿⣿⣦⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⣿⡿⠟⠁⠚⠋⣉⣁⣠⣤⣴⠟⠁⠀⠀⠀⠀⠀⠀⠀");
                Console.ResetColor();
                Console.WriteLine("\n");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("══════════════════════════════════════════════════════════");
                Console.WriteLine("║     ZERFALL DER SOWJETUNION - 26. DEZEMBER 1991      ║");
                Console.WriteLine("══════════════════════════════════════════════════════════");
                Console.ResetColor();
                Console.WriteLine("\n'Größte geopolitische Katastrophe des 20. Jahrhunderts'");
                Console.WriteLine("                    - Flad Rusputin");
                Thread.Sleep(5000);
                p.Gesundheit -= 40;
                p.Geld -= 600;
                p.LoyalitätVolk -= 70;
                p.LoyalitätPartei -= 80;
                p.EinflussInternational -= 60;
                p.EinflussKGB -= 30;
                Console.WriteLine("\n[Drücke eine Taste...]");
                Console.ReadKey(true);
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Erdbeben von Neftegorsk 1995",
            "28. Mai: Beben der Stärke 7,6 auf Sachalin! Neftegorsk in 17 Sekunden ausgelöscht...",
            "Präsident", 100, 1995, "katastrophe",
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
            "Präsident", 100, 1998, "katastrophe",
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
            "Präsident", 100, 1999, "katastrophe",
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
            "Präsident", 100, 2000, "katastrophe",
            p => {
                Console.WriteLine("Alle 118 Besatzungsmitglieder tot. Flad bleibt im Urlaub - heftige Kritik!");
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
            "Präsident", 100, 2002, "katastrophe",
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
            "Präsident", 100, 2004, "katastrophe",
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
            "Präsident", 100, 2009, "katastrophe",
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
            "Präsident", 100, 2010, "katastrophe",
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
            "Präsident", 100, 2010, "katastrophe",
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
            "Präsident", 100, 2011, "katastrophe",
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
            "Präsident", 100, 2012, "katastrophe",
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
            "Präsident", 100, 2013, "katastrophe",
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
            "Präsident", 100, 2014, "katastrophe",
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
            "Präsident", 100, 2018, "katastrophe",
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
            "Präsident", 100, 2020, "katastrophe",
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
            "Präsident", 100, 2021, "katastrophe",
            p => {
                Console.WriteLine("Rauch erreicht erstmals den Nordpol! Klimawandel und mangelnde Finanzierung kritisiert.");
                p.Gesundheit -= 35;
                p.Geld -= 400;
                p.LoyalitätVolk -= 40;
                p.EinflussInternational -= 25; // Klimakritik
            }
        ));
        
        // ═══════════════════════════════════════════════════════════
        // HISTORISCHE POLITISCHE EREIGNISSE (Flad-Ära 1999-2024)
        // Chronologie der Machtergreifung und -sicherung Flads
        // ═══════════════════════════════════════════════════════════
        
        allEvents.Add(new RandomEvent(
            "Unerwarteter Machtwechsel 1999",
            "31. Dezember: Jelzin tritt überraschend zurück! Flad Rusputin - ehemaliger KGB-Offizier - wird amtierender Präsident...",
            "Präsident", 100, 1999, "politisch",
            p => {
                Console.WriteLine("Der bis dahin kaum bekannte Flad übernimmt die Staatsführung!");
                p.LoyalitätPartei += 40;
                p.EinflussKGB += 50;
                p.EinflussMilitär += 30;
                p.LoyalitätVolk += 25; // Hoffnung auf Stabilität
                p.Geld += 100;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Flads erster Wahlsieg 2000",
            "26. März: Flad wird mit 53% zum Präsidenten gewählt! Verspricht Stabilität nach chaotischem Jelzin-Jahrzehnt...",
            "Präsident", 100, 2000, "politisch",
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
            "Flad führt Krieg in Tschetschenien mit harter Hand! Grosny in Trümmer gelegt...",
            "Präsident", 100, 2003, "politisch",
            p => {
                Console.WriteLine("Tausende Zivilisten tot. Tschetschenien unter Kontrolle. Flads Popularität steigt!");
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
            "Präsident", 100, 2003, "politisch",
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
            "14. März: Flad mit 71% wiedergewählt! Nach Beslan-Tragödie: Gouverneurs-Direktwahlen abgeschafft...",
            "Präsident", 100, 2004, "politisch",
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
            "25. April: Flad nennt Zerfall der UdSSR 'größte geopolitische Katastrophe des Jahrhunderts'!",
            "Präsident", 100, 2005, "politisch",
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
            "10. Februar: Flad überrascht mit scharfer Kritik an USA und 'unipolarer' Weltordnung!",
            "Präsident", 100, 2007, "politisch",
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
            "8. Mai: Flad wird Premierminister, Medwedew Präsident! 'Tandem-Lösung' umgeht Verfassung...",
            "Präsident", 100, 2008, "politisch",
            p => {
                Console.WriteLine("Flad bleibt faktisch der starke Mann! Ermöglicht spätere Rückkehr ins Präsidentenamt.");
                p.LoyalitätPartei += 45;
                p.EinflussKGB += 35;
                p.LoyalitätVolk += 20;
                p.Geld += 200;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Krieg gegen Georgien 2008",
            "8.-12. August: Russland führt Blitzkrieg gegen Georgien! Abchasien und Südossetien besetzt...",
            "Präsident", 100, 2008, "politisch",
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
            "Präsident", 100, 2011, "politisch",
            p => {
                Console.WriteLine("Protest gegen Wahlfälschungen und Flad-Medwedew-Rollentausch! Flad antwortet mit Repression.");
                p.LoyalitätVolk -= 35;
                p.LoyalitätPartei -= 15;
                p.EinflussKGB += 30; // Härtere Gesetze
                p.EinflussInternational -= 20;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Rückkehr ins Präsidentenamt 2012",
            "4. März: Flad für dritte Amtszeit gewählt (64%)! Amtszeit nun 6 Jahre statt 4...",
            "Präsident", 100, 2012, "politisch",
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
            "Präsident", 100, 2014, "politisch",
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
            "18. März: Flad annektiert die Krim! 'Grüne Männchen' besetzen Halbinsel, umstrittenes Referendum...",
            "Präsident", 100, 2014, "politisch",
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
            "Präsident", 100, 2014, "politisch",
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
            "Präsident", 100, 2015, "politisch",
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
            "Präsident", 100, 2015, "politisch",
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
            "18. März: Flad mit 77% wiedergewählt! Unpopuläre Rentenreform folgt...",
            "Präsident", 100, 2018, "politisch",
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
            "Mai: Flad eröffnet persönlich 18 km Brücke von Russland zur Krim!",
            "Präsident", 100, 2018, "politisch",
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
            "1. Juli: Referendum über Verfassungsreform! 'Nullstellung' ermöglicht Flad Präsidentschaft bis 2036...",
            "Präsident", 100, 2020, "politisch",
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
            "Dezember: Flad unterschreibt Gesetz für lebenslange Immunität von Ex-Präsidenten!",
            "Präsident", 100, 2020, "politisch",
            p => {
                Console.WriteLine("Garantiert Schutz vor Strafverfolgung - auch für Flad selbst!");
                p.LoyalitätPartei += 35;
                p.EinflussKGB += 30;
                p.LoyalitätVolk -= 15;
                p.EinflussInternational -= 25;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Anschlag auf Nawalny 2020",
            "20. August: Oppositionsführer Alexei Nawalny mit Nowitschok vergiftet!",
            "Präsident", 100, 2020, "politisch",
            p => {
                Console.WriteLine("Zur Behandlung nach Deutschland. Nawalny bezichtigt Flad persönlich! Neue Sanktionen.");
                p.LoyalitätVolk -= 25;
                p.EinflussKGB += 30; // Einschüchterung
                p.EinflussInternational -= 40;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Ausschaltung der Opposition 2021",
            "17. Januar: Nawalny bei Rückkehr verhaftet! Später zu 30+ Jahren Haft verurteilt...",
            "Präsident", 100, 2021, "politisch",
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
            "Juli: Flad publiziert Aufsatz: Russen und Ukrainer sind 'ein Volk'...",
            "Präsident", 100, 2021, "politisch",
            p => {
                Console.WriteLine("Ideologische Rechtfertigung für territoriale Ansprüche! Vorwand für Invasion 2022.");
                p.LoyalitätPartei += 35;
                p.LoyalitätVolk += 25;
                p.EinflussInternational -= 30;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Großinvasion Ukraine 2022",
            "24. Februar: Flad befiehlt umfassende Invasion der Ukraine! 'Spezialoperation zur Entnazifizierung'...",
            "Präsident", 100, 2022, "politisch",
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
            "Präsident", 100, 2022, "politisch",
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
            "17. März: Internationaler Strafgerichtshof erlässt Haftbefehl gegen Flad wegen Kriegsverbrechen!",
            "Präsident", 100, 2023, "politisch",
            p => {
                Console.WriteLine("Vorwurf: Deportation ukrainischer Kinder. Flad international offiziell angeklagt!");
                p.LoyalitätPartei += 30; // 'Siegsmentalität'
                p.LoyalitätVolk += 15;
                p.EinflussInternational -= 60;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Wagner-Meuterei 2023",
            "23./24. Juni: Jewgeni Prigoschin startet bewaffneten Aufstand! Wagner marschiert auf Moskau...",
            "Präsident", 100, 2023, "politisch",
            p => {
                Console.WriteLine("Flad nennt es 'Verrat'! Nach 24h beendet. Prigoschin stirbt im August bei Flugzeugabsturz.");
                p.EinflussMilitär -= 30; // Risse im Apparat
                p.EinflussKGB += 25; // Härte nach Meuterei
                p.LoyalitätVolk -= 25;
                p.LoyalitätPartei -= 20;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Fünfte Amtszeit 2024",
            "17. März: Flad bei inszenierter Wahl mit 87% 'wiedergewählt'. Keine echten Gegenkandidaten...",
            "Präsident", 100, 2024, "politisch",
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
            "Flad verkündet neue Pipeline! Ersatz für Südstraßen-Projekt...",
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
            "Januar: Flad und Erdogan eröffnen TurkStream-Pipeline! 31,5 Mrd. m³/Jahr...",
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
            "März: Flad und Erdogan verkünden Waffenstillstand in Nordsyrien...",
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
            "Flad-Erdogan Treffen! Intensivierung Handel, Gas in Rubel, Getreide-Deal...",
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
            "Juli: Erdogan-Flad besprechen Sinop-Nuklearprojekt! Ziel: 100 Mrd. USD Handel...",
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
            "Schröder und Flad vereinbaren 'strategische Partnerschaft'! Deutschland will Russland modernisieren...",
            "Präsident", 0, 2000, "deutschland",
            p => {
                Console.WriteLine("Beginn enger Zusammenarbeit! Wirtschaftliche und politische Kooperation.");
                p.Geld += 300;
                p.EinflussInternational += 25;
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Flad-Rede im Bundestag 2001",
            "25. September: Flad spricht im Deutschen Bundestag! Wunsch nach 'Großeuropa' und echter Partnerschaft...",
            "Präsident", 0, 2001, "deutschland",
            p => {
                Console.WriteLine("Historischer Moment! Flad auf Deutsch: 'Niemand bezweifelt den großen Wert der Beziehungen'.");
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
                Console.WriteLine("Regelmäßiger Dialog etabliert! Schröder und Flad persönlich eng.");
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
            "Merkel trifft Flad in Moskau 2006",
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
            "Merkel und Flad: Partnerschaft für Wirtschafts-Modernisierung! Aber: Fehlende Voraussetzungen...",
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
                Console.WriteLine("Deutschland fordert Aufklärung! Flad schweigt, Beziehungen auf Tiefpunkt.");
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
            "KGB", 70, 0, "kgb_easter",
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
                Thread.Sleep(3000);
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
            "KGB", 70, 0, "kgb_easter",
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
                Thread.Sleep(3000);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n'Genosse... Wir brauchen jemanden für eine... heikle Aufgabe.'");
                Console.ResetColor();
                Thread.Sleep(2500);
                
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
                    Thread.Sleep(3000);
                    
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
            "Präsident", 70, 0, "kgb_easter",
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
                Thread.Sleep(3000);
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
                    Thread.Sleep(2500);
                    
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
                    Thread.Sleep(3000);
                    
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
                    Thread.Sleep(3000);
                    
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
            "KGB", 70, 0, "kgb_easter",
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
                Thread.Sleep(3000);
                
                // Beeps entfernt
                
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\n[Verzerrte Stimme]:");
                Console.WriteLine("'Genosse... oder sollte ich sagen, Agent X-47?'");
                Thread.Sleep(3000);
                Console.WriteLine("'Ich kenne deine Vergangenheit. ALLE Geheimnisse.'");
                Thread.Sleep(3000);
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
                    Thread.Sleep(2500);
                    
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
                    Thread.Sleep(3000);
                    Console.WriteLine("\n🔍 KGB Spezialeinheit aktiviert!");
                    Thread.Sleep(2500);
                    
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
            "Flad hält scharfe Rede: 'USA weltgefährlich! Ein Zentrum der Macht!'",
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
        // DETAILLIERTE HISTORISCHE EREIGNISSE (1952-2100)
        // Putin & Russland - Ausführlich mit Spielmechanik
        // ═══════════════════════════════════════════════════════════
        
        // 1952
        allEvents.Add(new RandomEvent(
            "Flad wird geboren 1952",
            "7. Oktober 1952: Flad Rusputin wird in Leningrad geboren. Stalin ordnet die Ärzte-Verschwörung an und lässt 13 jüdische Dichter exekutieren.",
            "Kindheit", 100, 1952, "putinleben",
            p => {
                Console.WriteLine("\n📅 1952 - PUTINS GEBURT");
                Console.WriteLine("═══════════════════════════════════════════");
                Console.WriteLine("🍼 Am 7. Oktober wird Flad Rusputin in Leningrad geboren");
                Console.WriteLine("☭  Stalin ordnet die Ärzte-Verschwörung an");
                Console.WriteLine("💀 13 jüdische Dichter werden exekutiert");
                Console.WriteLine("📊 19. Parteikongress stabilisiert das Stalin-Regime");
                p.LoyalitätPartei += 10;
                Console.WriteLine($"\n➕ Partei-Loyalität: +10% → {p.LoyalitätPartei}%");
                Thread.Sleep(4000);
            }
        ));
        
        // 1953
        allEvents.Add(new RandomEvent(
            "Stalin stirbt 1953",
            "5. März: Josef Stalin stirbt in Moskau - Machtvakuum entsteht. 1. Mai: UdSSR zündet erste Wasserstoffbombe. 17. Juni: Arbeiteraufstand in Ost-Berlin wird niedergeschlagen.",
            "Kindheit", 100, 1953, "politisch",
            p => {
                Console.WriteLine("\n📅 1953 - STALINS TOD");
                Console.WriteLine("═══════════════════════════════════════════");
                Console.WriteLine("☭  5. März: Josef Stalin stirbt!");
                Console.WriteLine("💥 Machtvakuum und Führungskampf beginnen");
                Console.WriteLine("☢️  1. Mai: Erste sowjetische Wasserstoffbombe (RDS-6s)");
                Console.WriteLine("🛡️  17. Juni: Ost-Berlin-Aufstand niedergeschlagen");
                Console.WriteLine("⛓️  Gulag-Aufstände in Norilsk und Wladiwostok");
                p.LoyalitätPartei -= 20;
                p.EinflussMilitär += 15;
                Console.WriteLine($"\n➖ Partei-Loyalität: -20% → {p.LoyalitätPartei}%");
                Console.WriteLine($"➕ Militär-Einfluss: +15 → {p.EinflussMilitär}");
                Thread.Sleep(4500);
            }
        ));
        
        // 1954
        allEvents.Add(new RandomEvent(
            "Krim-Übergabe 1954",
            "19. Februar: Chruschtschow überträgt die Krim von Russland an die Ukraine. Juni: Kengir-Gulag-Aufstand wird niedergeschlagen. Erstes Atomkraftwerk in Obninsk.",
            "Kindheit", 100, 1954, "politisch",
            p => {
                Console.WriteLine("\n📅 1954 - KRIM-TRANSFER");
                Console.WriteLine("═══════════════════════════════════════════");
                Console.WriteLine("🗺️  19. Feb: Krim wird der Ukraine übergeben!");
                Console.WriteLine("⛓️  Kengir-Gulag-Aufstand niedergeschlagen");
                Console.WriteLine("⚡ 26. Juni: Erstes Atomkraftwerk (Obninsk)");
                Console.WriteLine("🏛️  Moskau feiert 800. Stadtjubiläum");
                p.EinflussInternational += 10;
                p.Geld += 50;
                Console.WriteLine($"\n➕ International: +10 → {p.EinflussInternational}");
                Console.WriteLine($"💰 Geld: +50 Rubel → {p.Geld}");
                Thread.Sleep(4000);
            }
        ));
        
        // 1955
        allEvents.Add(new RandomEvent(
            "Warschauer Pakt 1955",
            "14. Mai: Gründung des Warschauer Pakts - Ostblock wird militärisch geeint. 22. Nov: Erste leistungsstarke H-Bombe (RDS-37).",
            "Kindheit", 100, 1955, "politisch",
            p => {
                Console.WriteLine("\n📅 1955 - WARSCHAUER PAKT");
                Console.WriteLine("═══════════════════════════════════════════");
                Console.WriteLine("🛡️  14. Mai: Warschauer Pakt gegründet!");
                Console.WriteLine("🤝 Ostblock-Staaten an UdSSR gebunden");
                Console.WriteLine("☢️  22. Nov: RDS-37 H-Bombe getestet");
                Console.WriteLine("🇷🇸 Belgrader Erklärung mit Jugoslawien");
                p.EinflussMilitär += 20;
                p.EinflussInternational += 15;
                Console.WriteLine($"\n➕ Militär: +20 → {p.EinflussMilitär}");
                Console.WriteLine($"➕ International: +15 → {p.EinflussInternational}");
                Thread.Sleep(4000);
            }
        ));
        
        // 1956
        allEvents.Add(new RandomEvent(
            "Ungarn-Aufstand 1956",
            "25. Feb: Chruschtschows Geheimrede verurteilt Stalin. 23.-31. Okt: Ungarischer Volksaufstand wird blutig niedergeschlagen.",
            "Kindheit", 100, 1956, "politisch",
            p => {
                Console.WriteLine("\n📅 1956 - UNGARN-KRISE");
                Console.WriteLine("═══════════════════════════════════════════");
                Console.WriteLine("📢 25. Feb: Chruschtschows Geheimrede!");
                Console.WriteLine("☭  Stalin wird scharf kritisiert");
                Console.WriteLine("🇭🇺 23.-31. Okt: Ungarn-Aufstand niedergeschlagen");
                Console.WriteLine("💥 Sowjetarmee marschiert in Budapest ein");
                Console.WriteLine("🌍 Westliche Welt empört");
                p.LoyalitätPartei -= 15;
                p.EinflussMilitär += 25;
                p.EinflussInternational -= 30;
                Console.WriteLine($"\n➖ Partei: -15% → {p.LoyalitätPartei}%");
                Console.WriteLine($"➕ Militär: +25 → {p.EinflussMilitär}");
                Console.WriteLine($"➖ International: -30 → {p.EinflussInternational}");
                Thread.Sleep(4500);
            }
        ));
        
        // 1957
        allEvents.Add(new RandomEvent(
            "Sputnik 1957",
            "4. Okt: Sputnik 1 startet - erster Satellit! 29. Sept: Kyshtym-Katastrophe (geheim). Anti-Chruschtschow-Gruppe scheitert.",
            "Kindheit", 100, 1957, "politisch",
            p => {
                Console.WriteLine("\n📅 1957 - WELTRAUM-ÄRA");
                Console.WriteLine("═══════════════════════════════════════════");
                Console.WriteLine("🚀 4. Okt: SPUTNIK 1 STARTET!");
                Console.WriteLine("🌍 Erste künstliche Erdumlaufbahn");
                Console.WriteLine("⚡ Weltweit Schock und Bewunderung");
                Console.WriteLine("☢️  Kyshtym-Katastrophe (geheim gehalten)");
                Console.WriteLine("📚 Doktor Schiwago im Ausland veröffentlicht");
                p.EinflussInternational += 30;
                p.Gesundheit -= 5;
                Console.WriteLine($"\n➕ International: +30 → {p.EinflussInternational}");
                Console.WriteLine($"➖ Gesundheit: -5% → {p.Gesundheit}%");
                Thread.Sleep(4500);
            }
        ));
        
        // 1958
        allEvents.Add(new RandomEvent(
            "Sputnik 3 & Grosny 1958",
            "27. März: Chruschtschow wird Premierminister. 15. Mai: Sputnik 3 gestartet. Anti-sowjetische Unruhen in Tschetschenien.",
            "Kindheit", 100, 1958, "politisch",
            p => {
                Console.WriteLine("\n📅 1958 - RAUMFAHRT FORTSETZUNG");
                Console.WriteLine("═══════════════════════════════════════════");
                Console.WriteLine("☭  27. März: Chruschtschow Premierminister");
                Console.WriteLine("🚀 15. Mai: Sputnik 3 im All");
                Console.WriteLine("⚔️  Unruhen in Grosny (Tschetschenien)");
                Console.WriteLine("✈️  C-130 von UdSSR abgeschossen");
                p.EinflussKGB += 15;
                p.EinflussInternational += 10;
                Console.WriteLine($"\n➕ KGB: +15 → {p.EinflussKGB}");
                Console.WriteLine($"➕ International: +10 → {p.EinflussInternational}");
                Thread.Sleep(4000);
            }
        ));
        
        // 1959
        allEvents.Add(new RandomEvent(
            "Luna 1 & Dyatlov 1959",
            "2. Jan: Luna 1 umkreist als erstes Objekt die Sonne! Feb: Dyatlov-Pass-Vorfall - 9 Wanderer sterben mysteriös.",
            "Kindheit", 100, 1959, "politisch",
            p => {
                Console.WriteLine("\n📅 1959 - LUNA & MYSTERIUM");
                Console.WriteLine("═══════════════════════════════════════════");
                Console.WriteLine("🌞 2. Jan: Luna 1 umkreist die Sonne!");
                Console.WriteLine("📡 Neue Ära des Raumfahrt-Wettlaufs");
                Console.WriteLine("❄️  Feb: Dyatlov-Pass-Vorfall");
                Console.WriteLine("💀 9 Wanderer sterben unter mysteriösen Umständen");
                Console.WriteLine("🤐 KGB schweigt");
                p.EinflussInternational += 20;
                p.EinflussKGB += 10;
                Console.WriteLine($"\n➕ International: +20 → {p.EinflussInternational}");
                Console.WriteLine($"➕ KGB: +10 → {p.EinflussKGB}");
                Thread.Sleep(4000);
            }
        ));
        
        // 1960
        allEvents.Add(new RandomEvent(
            "U-2 Abschuss 1960",
            "1. Mai: US-Spionageflugzeug U-2 über Ural abgeschossen! Gary Powers gefangen. Chruschtschow schlägt mit Schuh auf UN-Tisch.",
            "Kindheit", 100, 1960, "politisch",
            p => {
                Console.WriteLine("\n📅 1960 - U-2 KRISE");
                Console.WriteLine("═══════════════════════════════════════════");
                Console.WriteLine("✈️  1. Mai: U-2 über Ural ABGESCHOSSEN!");
                Console.WriteLine("🎯 Pilot Gary Powers gefangen genommen");
                Console.WriteLine("💥 Paris-Gipfel platzt");
                Console.WriteLine("👞 Chruschtschow: Berühmter Schuh-Vorfall UN");
                Console.WriteLine("🇨🇳 Sino-sowjetischer Bruch beginnt");
                Console.WriteLine("🐕 Belka und Strelka im Orbit");
                p.EinflussKGB += 25;
                p.EinflussInternational -= 15;
                p.Geld += 100;
                Console.WriteLine($"\n➕ KGB: +25 → {p.EinflussKGB}");
                Console.WriteLine($"➖ International: -15 → {p.EinflussInternational}");
                Console.WriteLine($"💰 Geld: +100 Rubel → {p.Geld}");
                Thread.Sleep(4500);
            }
        ));
        // 1961
        allEvents.Add(new RandomEvent(
            "Gagarin im All 1961",
            "12. Apr: Juri Gagarin - ERSTER MENSCH IM WELTRAUM! 6. Aug: Gherman Titow 17 Mal um die Erde. 13. Aug: Berliner Mauer gebaut. 30. Okt: Zar-Bombe - stärkste Explosion!",
            "Jugend", 100, 1961, "politisch",
            p => {
                Console.WriteLine("\n📅 1961 - GAGARINS TRIUMPH");
                Console.WriteLine("═══════════════════════════════════════════");
                Console.WriteLine("👨‍🚀 12. APR: JURI GAGARIN IM ALL!");
                Console.WriteLine("🌍 ERSTER MENSCH IM ERDORBIT (WOSTOK 1)");
                Console.WriteLine("🇷🇺 UdSSR SIEGT IM WELTRAUM-WETTLAUF!");
                Console.WriteLine("🚀 6. Aug: Titow umkreist 17x die Erde");
                Console.WriteLine("🧱 13. Aug: Berliner Mauer wird gebaut");
                Console.WriteLine("💣 30. Okt: ZAR-BOMBE - 50 Megatonnen!");
                Console.WriteLine("☢️  Stärkste jemals gezündete Bombe");
                p.EinflussInternational += 40;
                p.EinflussMilitär += 30;
                p.LoyalitätPartei += 25;
                Console.WriteLine($"\n➕ International: +40 → {p.EinflussInternational}");
                Console.WriteLine($"➕ Militär: +30 → {p.EinflussMilitär}");
                Console.WriteLine($"➕ Partei: +25% → {p.LoyalitätPartei}%");
                Thread.Sleep(5000);
            }
        ));
        // 1962 - 4 Events
        allEvents.Add(new RandomEvent(
            "Kubakrise 1962 - 13 Tage am Abgrund", 
            "DIE WELT AM RANDE DES ATOMKRIEGS! Sowjetische Raketen auf Kuba, amerikanische Kriegsschiffe kreisen. Kennedy und Chruschtschow spielen atomares Schach - ein falscher Zug und die Menschheit ist ausgelöscht. Das Volk gräbt Luftschutzbunker, Kinder üben 'Duck and Cover'. 13 Tage purer Terror. Dann: Beide blinzeln. Die Welt atmet auf.", 
            "Jugend", 100, 1962, "politisch", 
            p => { 
                Console.WriteLine("\n☢️ KUBAKRISE - ATOMKRIEG DROHT!");
                Console.WriteLine("Die Welt steht 13 Tage vor der Auslöschung!");
                p.EinflussMilitär += 20; 
                p.Gesundheit -= 15; 
                p.LoyalitätVolk -= 30;
                p.EinflussInternational += 15;
                Console.WriteLine($"➕ Militär: +20 → {p.EinflussMilitär}");
                Console.WriteLine($"➖ Gesundheit: -15% → {p.Gesundheit}%");
                Console.WriteLine($"➖ Volk: -30% (Panik) → {p.LoyalitätVolk}%");
                Thread.Sleep(4000); 
            }
        ));
        allEvents.Add(new RandomEvent("Karibik-Blockade 1962", "Kennedy blockiert Kuba", "Jugend", 100, 1962, "politisch", p => { p.EinflussInternational -= 15; p.LoyalitätPartei += 10; Console.WriteLine("🚢 US-Blockade!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("U-2 über Kuba 1962", "Spionageflüge entdeckt", "Jugend", 100, 1962, "politisch", p => { p.EinflussKGB += 15; Console.WriteLine("🔍 Spionage aufgedeckt!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Atomtest Nowaja Semlja 1962", "Weitere Nukleartests", "Jugend", 100, 1962, "politisch", p => { p.EinflussMilitär += 10; p.Gesundheit -= 5; Console.WriteLine("☢️ Atomtests!"); Thread.Sleep(3000); }));
        
        // 1963 - 4 Events
        allEvents.Add(new RandomEvent("Teststopp-Vertrag 1963", "Atomtest-Abkommen", "Jugend", 100, 1963, "politisch", p => { p.EinflussInternational += 20; p.Gesundheit += 5; Console.WriteLine("☮️ Vertrag unterzeichnet!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent(
            "Kennedy-Attentat Dallas 1963", 
            "SCHOCKWELLEN DURCH DIE WELT! 22. November, Dallas, Texas - drei Schüsse aus dem Texas School Book Depository. John F. Kennedy wird vor den Augen seiner Frau erschossen. Die Welt hält den Atem an. Das Volk in der UdSSR ist geschockt - selbst der Feind verdient keinen solchen Tod. Oswald verhaftet, Ruby erschießt Oswald. Verschwörungstheorien beginnen sofort.", 
            "Jugend", 100, 1963, "politisch", 
            p => { 
                Console.WriteLine("\n🔫 KENNEDY ERMORDET IN DALLAS!");
                Console.WriteLine("Der US-Präsident tot! Die Welt ist geschockt!");
                p.EinflussInternational += 10; 
                p.LoyalitätVolk += 15;
                p.Gesundheit -= 10;
                Console.WriteLine($"➕ International: +10 → {p.EinflussInternational}");
                Console.WriteLine($"➕ Volk: +15% (Mitgefühl) → {p.LoyalitätVolk}%");
                Thread.Sleep(4000); 
            }
        ));
        allEvents.Add(new RandomEvent("Heißer Draht 1963", "Direktleitung USA-UdSSR", "Jugend", 100, 1963, "politisch", p => { p.EinflussInternational += 15; Console.WriteLine("📞 Hotline aktiv!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Weltraumabkommen 1963", "Kooperation im All", "Jugend", 100, 1963, "politisch", p => { p.EinflussInternational += 10; Console.WriteLine("🚀 Raumfahrt-Vertrag!"); Thread.Sleep(3000); }));
        
        // 1964 - 4 Events
        allEvents.Add(new RandomEvent("Breschnjew 1964", "Neuer Generalsekretär", "Jugend", 100, 1964, "politisch", p => { p.LoyalitätPartei += 15; Console.WriteLine("☭ Neue Führung!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Chruschtschow gestürzt 1964", "Machtwechsel in Moskau", "Jugend", 100, 1964, "politisch", p => { p.EinflussKGB += 20; p.LoyalitätPartei += 10; Console.WriteLine("🔄 Putsch erfolgreich!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Woschod 1 im All 1964", "Erste 3-Mann-Crew", "Jugend", 100, 1964, "politisch", p => { p.EinflussInternational += 15; Console.WriteLine("🚀 Weltraumerfolg!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("China-Atombombe 1964", "China wird Atommacht", "Jugend", 100, 1964, "politisch", p => { p.ChinaBeziehung -= 20; p.EinflussMilitär -= 10; Console.WriteLine("☢️ China nuklear!"); Thread.Sleep(3000); }));
        // 1965 - 4 Events
        allEvents.Add(new RandomEvent("Vietnamkrieg 1965", "USA in Vietnam", "Jugend", 100, 1965, "politisch", p => { p.Geld += 150; p.EinflussMilitär += 15; Console.WriteLine("⚔️ Waffenlieferungen!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Woschod 2 Weltraumspaziergang 1965", "Erster Ausstieg ins All", "Jugend", 100, 1965, "politisch", p => { p.EinflussInternational += 25; Console.WriteLine("👨‍🚀 Weltraumspaziergang!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Wirtschaftsreform 1965", "Kossygin-Reform", "Jugend", 100, 1965, "politisch", p => { p.Geld += 100; Console.WriteLine("💰 Wirtschaft gestärkt!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Strelnikow-Affäre 1965", "KGB-Operationen", "Jugend", 100, 1965, "politisch", p => { p.EinflussKGB += 15; Console.WriteLine("🕵️ KGB aktiv!"); Thread.Sleep(3000); }));
        
        // 1966 - 4 Events
        allEvents.Add(new RandomEvent("Luna 9 Landung 1966", "Erste Mondlandung (unbemannt)", "Jugend", 100, 1966, "politisch", p => { p.EinflussInternational += 20; Console.WriteLine("🌙 Luna 9 auf dem Mond!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Kulturrevolution China 1966", "Mao startet Revolution", "Jugend", 100, 1966, "politisch", p => { p.ChinaBeziehung -= 25; Console.WriteLine("🇨🇳 Chaos in China!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Venera 3 zur Venus 1966", "Erste Venus-Sonde", "Jugend", 100, 1966, "politisch", p => { p.EinflussInternational += 15; Console.WriteLine("🪐 Venus erreicht!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Breschnjew-Doktrin 1966", "Intervention gerechtfertigt", "Jugend", 100, 1966, "politisch", p => { p.EinflussMilitär += 20; p.EinflussInternational -= 15; Console.WriteLine("⚔️ Doktrin verkündet!"); Thread.Sleep(3000); }));
        
        // 1967 - 4 Events
        allEvents.Add(new RandomEvent("Sojus 1 Katastrophe 1967", "Kosmonaut stirbt", "Jugend", 100, 1967, "katastrophe", p => { p.Gesundheit -= 15; p.EinflussInternational -= 20; Console.WriteLine("💀 Komarow tot!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Sechstagekrieg 1967", "Israel besiegt Araber", "Jugend", 100, 1967, "politisch", p => { p.Geld -= 100; p.EinflussInternational -= 15; Console.WriteLine("🇮🇱 Arabische Niederlage!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Venera 4 Venus 1967", "Venus-Atmosphäre erforscht", "Jugend", 100, 1967, "politisch", p => { p.EinflussInternational += 15; Console.WriteLine("🪐 Venus-Daten!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Atomwaffensperrvertrag 1967", "Verhandlungen beginnen", "Jugend", 100, 1967, "politisch", p => { p.EinflussInternational += 10; Console.WriteLine("☮️ Abrüstungsgespräche!"); Thread.Sleep(3000); }));
        
        // 1968 - 4 Events
        allEvents.Add(new RandomEvent("Prager Frühling 1968", "Panzer nach Prag", "KGB", 100, 1968, "politisch", p => { p.EinflussMilitär += 30; p.EinflussInternational -= 35; Console.WriteLine("🇨🇿 Prag besetzt!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Dubček gestürzt 1968", "Reformer entmachtet", "KGB", 100, 1968, "politisch", p => { p.EinflussKGB += 25; Console.WriteLine("🔨 Reform niedergeschlagen!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("MLK ermordet 1968", "US-Bürgerrechtler tot", "KGB", 100, 1968, "politisch", p => { p.EinflussInternational += 10; Console.WriteLine("📰 MLK ermordet!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("My Lai Massaker 1968", "US-Kriegsverbrechen", "KGB", 100, 1968, "politisch", p => { p.EinflussInternational += 15; Console.WriteLine("⚠️ US-Skandal!"); Thread.Sleep(3000); }));
        
        // 1969 - 4 Events
        allEvents.Add(new RandomEvent("Mondlandung Apollo 11 1969", "USA auf dem Mond", "KGB", 100, 1969, "politisch", p => { p.EinflussInternational -= 25; p.Gesundheit -= 10; Console.WriteLine("🌕 USA siegt!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Grenzkonflikt Damanski 1969", "Kampf mit China", "KGB", 100, 1969, "politisch", p => { p.ChinaBeziehung -= 40; p.EinflussMilitär += 15; Console.WriteLine("💥 Gefecht mit China!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Sojus 4/5 Kopplung 1969", "Erste Raumstation-Basis", "KGB", 100, 1969, "politisch", p => { p.EinflussInternational += 15; Console.WriteLine("🚀 Kopplung gelungen!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("SALT-Verhandlungen 1969", "Abrüstung beginnt", "KGB", 100, 1969, "politisch", p => { p.EinflussInternational += 10; Console.WriteLine("☮️ Gespräche starten!"); Thread.Sleep(3000); }));
        
        // 1970 - 4 Events
        allEvents.Add(new RandomEvent("Mondlandung USA 1970", "Apollo 13 Drama", "KGB", 100, 1970, "politisch", p => { p.EinflussInternational -= 15; Console.WriteLine("🌕 USA Mondprogramm!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Lunochod 1 Rover 1970", "Erster Mondrover", "KGB", 100, 1970, "politisch", p => { p.EinflussInternational += 20; Console.WriteLine("🌙 Rover auf Mond!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Allende Chile 1970", "Sozialist siegt", "KGB", 100, 1970, "politisch", p => { p.Geld += 100; p.EinflussInternational += 15; Console.WriteLine("🇨🇱 Verbündeter in Chile!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Ostverträge 1970", "Deutschland-Entspannung", "KGB", 100, 1970, "politisch", p => { p.EinflussInternational += 15; Console.WriteLine("🤝 Brandt in Moskau!"); Thread.Sleep(3000); }));
        // 1971-1975 (Détente-Ära)
        allEvents.Add(new RandomEvent("Saljut 1 Raumstation 1971", "Erste Raumstation", "KGB", 100, 1971, "politisch", p => { p.EinflussInternational += 25; Console.WriteLine("🛰️ Raumstation!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Viermächte-Abkommen 1971", "Berlin-Status", "KGB", 100, 1971, "politisch", p => { p.EinflussInternational += 15; Console.WriteLine("🏛️ Berlin-Vertrag!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Ping-Pong China 1971", "Annäherung USA-China", "KGB", 100, 1971, "politisch", p => { p.ChinaBeziehung -= 20; p.EinflussInternational -= 10; Console.WriteLine("🏓 China-USA nähern sich!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Sojus 11 Tragödie 1971", "3 Kosmonauten sterben", "KGB", 100, 1971, "katastrophe", p => { p.Gesundheit -= 20; Console.WriteLine("💀 Raumfahrt-Tod!"); Thread.Sleep(3000); }));
        
        allEvents.Add(new RandomEvent("SALT I 1972", "Rüstungskontrolle", "KGB", 100, 1972, "politisch", p => { p.EinflussInternational += 20; p.Geld += 100; Console.WriteLine("🕊️ Entspannung!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Nixon Moskau 1972", "US-Präsident besucht", "KGB", 100, 1972, "politisch", p => { p.EinflussInternational += 15; Console.WriteLine("🤝 Nixon in Moskau!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Olympia München 1972", "Terror-Anschlag", "KGB", 100, 1972, "politisch", p => { p.EinflussInternational += 10; Console.WriteLine("🏅 Olympia-Drama!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Mars 2 Mars-Landung 1972", "Erste Mars-Landung", "KGB", 100, 1972, "politisch", p => { p.EinflussInternational += 20; Console.WriteLine("🔴 Mars erreicht!"); Thread.Sleep(3000); }));
        
        allEvents.Add(new RandomEvent("Jom-Kippur-Krieg 1973", "Nahost-Krieg", "KGB", 100, 1973, "politisch", p => { p.Geld += 150; p.EinflussMilitär += 20; Console.WriteLine("⚔️ Waffenexport!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Ölkrise 1973", "OPEC-Embargo", "KGB", 100, 1973, "politisch", p => { p.Geld += 200; Console.WriteLine("🛢️ Ölpreise steigen!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Sacharow-Protest 1973", "Dissident warnt", "KGB", 100, 1973, "politisch", p => { p.LoyalitätPartei -= 10; p.EinflussKGB += 15; Console.WriteLine("⚠️ Dissidenten aktiv!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Sojus-Apollo Vorbereitung 1973", "Gemeinsame Mission geplant", "KGB", 100, 1973, "politisch", p => { p.EinflussInternational += 15; Console.WriteLine("🚀 US-UdSSR Kooperation!"); Thread.Sleep(3000); }));
        
        allEvents.Add(new RandomEvent("Solschenizyn ausgewiesen 1974", "Kritiker verbannt", "KGB", 100, 1974, "politisch", p => { p.EinflussKGB += 20; p.EinflussInternational -= 15; Console.WriteLine("📚 Autor ausgewiesen!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Watergate Nixon 1974", "US-Präsident zurückgetreten", "KGB", 100, 1974, "politisch", p => { p.EinflussInternational += 15; Console.WriteLine("📰 Nixon-Skandal!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Zypern-Krise 1974", "Türkei-Griechenland", "KGB", 100, 1974, "politisch", p => { p.EinflussMilitär += 10; Console.WriteLine("🇹🇷 Zypern-Konflikt!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Sojus-Apollo Test 1974", "Gemeinsame Tests", "KGB", 100, 1974, "politisch", p => { p.EinflussInternational += 15; Console.WriteLine("🚀 Kooperation läuft!"); Thread.Sleep(3000); }));
        
        allEvents.Add(new RandomEvent("Helsinki 1975", "KSZE-Konferenz", "KGB", 100, 1975, "politisch", p => { p.EinflussInternational += 25; p.LoyalitätPartei += 15; Console.WriteLine("🤝 Menschenrechte!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Sojus-Apollo Kopplung 1975", "US-Sowjet im All", "KGB", 100, 1975, "politisch", p => { p.EinflussInternational += 20; Console.WriteLine("🚀 Historische Kopplung!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Saigon fällt 1975", "Vietnam-Sieg", "KGB", 100, 1975, "politisch", p => { p.EinflussMilitär += 20; p.Geld += 150; Console.WriteLine("🇻🇳 USA verliert Vietnam!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Angola-Intervention 1975", "Kubanische Truppen", "KGB", 100, 1975, "politisch", p => { p.EinflussMilitär += 15; p.Geld -= 100; Console.WriteLine("🇦🇴 Afrika-Engagement!"); Thread.Sleep(3000); }));
        
        // 1976-1980
        allEvents.Add(new RandomEvent("Mao stirbt 1976", "China-Wandel", "KGB", 100, 1976, "politisch", p => { p.ChinaBeziehung += 10; Console.WriteLine("🇨🇳 Mao tot!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Viking Mars 1976", "US-Mars-Landung", "KGB", 100, 1976, "politisch", p => { p.EinflussInternational -= 15; Console.WriteLine("🔴 USA auf Mars!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Sacharow Verbannung 1976", "Friedensnobelpreis verbannt", "KGB", 100, 1976, "politisch", p => { p.EinflussKGB += 15; p.EinflussInternational -= 10; Console.WriteLine("⚠️ Dissident verbannt!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Carter gewählt 1976", "Menschenrechtler", "KGB", 100, 1976, "politisch", p => { p.EinflussInternational -= 10; Console.WriteLine("🇺🇸 Carter Präsident!"); Thread.Sleep(3000); }));
        
        allEvents.Add(new RandomEvent("Breschnjew-Verfassung 1977", "Neue Verfassung", "KGB", 100, 1977, "politisch", p => { p.LoyalitätPartei += 15; Console.WriteLine("📜 Verfassung!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Charta 77 1977", "Dissidenten Osteuropa", "KGB", 100, 1977, "politisch", p => { p.EinflussKGB += 15; p.EinflussInternational -= 10; Console.WriteLine("📄 Opposition wächst!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Sadat Jerusalem 1977", "Ägypten-Israel", "KGB", 100, 1977, "politisch", p => { p.EinflussInternational -= 15; Console.WriteLine("🇮🇱 Arabische Wende!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Neutronenbombe 1977", "US-Waffe diskutiert", "KGB", 100, 1977, "politisch", p => { p.EinflussMilitär += 15; Console.WriteLine("☢️ Neue Waffe!"); Thread.Sleep(3000); }));
        
        allEvents.Add(new RandomEvent("Camp David 1978", "Israel-Ägypten Frieden", "KGB", 100, 1978, "politisch", p => { p.EinflussInternational -= 20; Console.WriteLine("🕊️ Frieden ohne UdSSR!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Afghanistan-Putsch 1978", "Kommunisten an Macht", "KGB", 100, 1978, "politisch", p => { p.EinflussMilitär += 15; p.EinflussKGB += 20; Console.WriteLine("🇦🇫 Kabul-Putsch!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Papst Johannes Paul II 1978", "Polnischer Papst", "KGB", 100, 1978, "politisch", p => { p.LoyalitätPartei -= 15; Console.WriteLine("⛪ Polen-Papst!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Sojus 29 Langzeit 1978", "175 Tage im All", "KGB", 100, 1978, "politisch", p => { p.EinflussInternational += 15; Console.WriteLine("🚀 Rekord im All!"); Thread.Sleep(3000); }));
        
        allEvents.Add(new RandomEvent("Afghanistan 1979", "Invasion", "KGB", 100, 1979, "politisch", p => { p.EinflussMilitär += 35; p.Geld -= 250; p.Gesundheit -= 15; Console.WriteLine("🇦🇫 Krieg beginnt!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Iranische Revolution 1979", "Schah gestürzt", "KGB", 100, 1979, "politisch", p => { p.EinflussInternational -= 15; Console.WriteLine("🇮🇷 Khomeini siegt!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("SALT II 1979", "Neuer Abrüstungsvertrag", "KGB", 100, 1979, "politisch", p => { p.EinflussInternational += 15; Console.WriteLine("☮️ SALT II!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Nicaragua-Revolution 1979", "Sandinisten siegen", "KGB", 100, 1979, "politisch", p => { p.Geld += 100; p.EinflussInternational += 15; Console.WriteLine("🇳🇮 Verbündeter!"); Thread.Sleep(3000); }));
        
        allEvents.Add(new RandomEvent("Olympia-Boykott 1980", "USA boykottieren", "KGB", 100, 1980, "politisch", p => { p.EinflussInternational -= 30; p.LoyalitätPartei += 15; Console.WriteLine("🏅 Boykott!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Solidarność 1980", "Polnische Gewerkschaft", "KGB", 100, 1980, "politisch", p => { p.LoyalitätPartei -= 20; p.EinflussKGB += 15; Console.WriteLine("⚠️ Polen rebelliert!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Reagan gewählt 1980", "Hardliner-Präsident", "KGB", 100, 1980, "politisch", p => { p.EinflussMilitär += 15; p.EinflussInternational -= 15; Console.WriteLine("🇺🇸 Reagan an Macht!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Iran-Irak Krieg 1980", "Nahostkonflikt", "KGB", 100, 1980, "politisch", p => { p.Geld += 150; Console.WriteLine("⚔️ Waffenexport!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Olympia-Boykott 1980", "USA boykottieren", "KGB", 100, 1980, "politisch", p => { p.EinflussInternational -= 25; Console.WriteLine("🏅 Boykott!"); Thread.Sleep(3000); }));
        // 1981-1985
        allEvents.Add(new RandomEvent("Kriegsrecht Polen 1981", "Jaruzelski-Putsch", "KGB", 100, 1981, "politisch", p => { p.EinflussMilitär += 20; p.EinflussInternational -= 20; Console.WriteLine("🇵🇱 Kriegsrecht!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Reagan Attentat 1981", "US-Präsident überlebt", "KGB", 100, 1981, "politisch", p => { p.EinflussInternational += 10; Console.WriteLine("🔫 Attentat!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Sadat ermordet 1981", "Ägypten-Präsident tot", "KGB", 100, 1981, "politisch", p => { p.EinflussInternational += 10; Console.WriteLine("💀 Sadat tot!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Afghanistan-Krieg 1981", "Mudschahedin kämpfen", "KGB", 100, 1981, "politisch", p => { p.Geld -= 150; p.EinflussMilitär += 10; Console.WriteLine("🇦🇫 Krieg eskaliert!"); Thread.Sleep(3000); }));
        
        allEvents.Add(new RandomEvent("Breschnjew stirbt 1982", "Ende einer Ära", "KGB", 100, 1982, "politisch", p => { p.LoyalitätPartei -= 20; p.Gesundheit -= 10; Console.WriteLine("☭ Führerwechsel!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Andropow KGB-Chef 1982", "KGB übernimmt", "KGB", 100, 1982, "politisch", p => { p.EinflussKGB += 30; Console.WriteLine("🕵️ KGB an Macht!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Falklandkrieg 1982", "GB-Argentinien", "KGB", 100, 1982, "politisch", p => { p.Geld += 100; Console.WriteLine("⚔️ Falkland-Krieg!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Libanon-Invasion 1982", "Israel marschiert ein", "KGB", 100, 1982, "politisch", p => { p.Geld += 120; Console.WriteLine("🇱🇧 Nahost-Krise!"); Thread.Sleep(3000); }));
        
        allEvents.Add(new RandomEvent("Reagan SDI 1983", "Star Wars Programm", "KGB", 100, 1983, "politisch", p => { p.EinflussMilitär -= 25; p.Geld -= 200; Console.WriteLine("🛰️ Wettrüsten!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("KAL 007 Abschuss 1983", "Passagierflugzeug abgeschossen", "KGB", 100, 1983, "katastrophe", p => { p.EinflussInternational -= 35; p.EinflussMilitär += 10; Console.WriteLine("✈️ 269 Tote!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Andropow stirbt 1983", "Zweiter Tod", "KGB", 100, 1983, "politisch", p => { p.LoyalitätPartei -= 15; Console.WriteLine("☭ Erneuter Führerwechsel!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Able Archer 1983", "Fast-Atomkrieg", "KGB", 100, 1983, "katastrophe", p => { p.Gesundheit -= 20; p.EinflussMilitär += 15; Console.WriteLine("☢️ Beinahe-Krieg!"); Thread.Sleep(3000); }));
        
        allEvents.Add(new RandomEvent("Tschernenko Generalsekretär 1984", "Kranker Führer", "KGB", 100, 1984, "politisch", p => { p.LoyalitätPartei -= 10; Console.WriteLine("☭ Schwacher Führer!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Olympia LA Boykott 1984", "Sowjet boykottiert", "KGB", 100, 1984, "politisch", p => { p.EinflussInternational -= 15; Console.WriteLine("🏅 Gegenboykott!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Indira Gandhi ermordet 1984", "Indien-Krise", "KGB", 100, 1984, "politisch", p => { p.EinflussInternational += 10; Console.WriteLine("🇮🇳 Gandhi tot!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Reagan wiedergewählt 1984", "Hardliner bleibt", "KGB", 100, 1984, "politisch", p => { p.EinflussMilitär += 10; Console.WriteLine("🇺🇸 Reagan 2. Amtszeit!"); Thread.Sleep(3000); }));
        
        allEvents.Add(new RandomEvent("Gorbatschow 1985", "Glasnost & Perestroika", "KGB", 100, 1985, "politisch", p => { p.LoyalitätPartei -= 30; p.EinflussInternational += 25; p.Gesundheit += 10; Console.WriteLine("🌍 Reformen!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Genfer Gipfel 1985", "Reagan-Gorbatschow", "KGB", 100, 1985, "politisch", p => { p.EinflussInternational += 20; Console.WriteLine("🤝 Gipfeltreffen!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Achille Lauro 1985", "Schiffsentführung", "KGB", 100, 1985, "politisch", p => { p.EinflussInternational += 10; Console.WriteLine("🚢 Terror auf See!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Afghanistan Rückzug beginnt 1985", "Erste Signale", "KGB", 100, 1985, "politisch", p => { p.Geld += 100; Console.WriteLine("🇦🇫 Rückzugspläne!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Tschernobyl 1986", "Atomkatastrophe", "KGB", 100, 1986, "katastrophe", p => { p.Gesundheit -= 25; p.Geld -= 300; Console.WriteLine("☢️ Reaktor explodiert!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("INF-Vertrag 1987", "Abrüstung", "KGB", 100, 1987, "politisch", p => { p.EinflussInternational += 25; Console.WriteLine("🕊️ Frieden!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Afghanistan-Abzug 1988", "Rückzug", "KGB", 100, 1988, "politisch", p => { p.Geld += 150; p.EinflussMilitär -= 20; Console.WriteLine("🇦🇫 Rückzug!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Mauerfall 1990", "DDR fällt", "KGB", 100, 1989, "politisch", p => { p.EinflussInternational -= 40; Console.WriteLine("🇩🇪 Mauer fällt!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("UdSSR-Ende 1991", "Sowjetunion zerfällt", "KGB", 100, 1991, "politisch", p => { p.Geld -= 500; p.LoyalitätPartei -= 50; Console.WriteLine("☭ UdSSR endet!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Jelzin 1992", "Neue Ära", "Präsident", 100, 1992, "politisch", p => { p.Geld -= 200; Console.WriteLine("🇷🇺 Russland geboren!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Verfassungskrise 1993", "Parlament gestürmt", "Präsident", 100, 1993, "politisch", p => { p.EinflussMilitär += 25; Console.WriteLine("🏛️ Panzer auf Parlament!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Tschetschenien I 1994", "Erster Krieg", "Präsident", 100, 1994, "politisch", p => { p.EinflussMilitär += 20; p.Geld -= 250; Console.WriteLine("⚔️ Krieg im Kaukasus!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Rubelkrise 1998", "Wirtschaftskollaps", "Präsident", 100, 1998, "politisch", p => { p.Geld -= 400; Console.WriteLine("💰 Rubel-Crash!"); Thread.Sleep(3000); }));
        // 1995-2000 (Jelzin-Ära Fortsetzung)
        allEvents.Add(new RandomEvent("Srebrenica 1995", "Massaker Bosnien", "Präsident", 100, 1995, "politisch", p => { p.EinflussInternational += 10; Console.WriteLine("🇧🇦 Balkan-Massaker!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Budjonowsk 1995", "Tschetschenischer Terror", "Präsident", 100, 1995, "katastrophe", p => { p.Gesundheit -= 15; p.EinflussMilitär += 15; Console.WriteLine("💣 Geiselnahme!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Oklahoma Bombing 1995", "US-Terror", "Präsident", 100, 1995, "politisch", p => { p.EinflussInternational += 10; Console.WriteLine("💣 USA-Anschlag!"); Thread.Sleep(3000); }));
        
        allEvents.Add(new RandomEvent("Jelzin wiedergewählt 1996", "Umstrittene Wahl", "Präsident", 100, 1996, "politisch", p => { p.LoyalitätPartei += 15; p.Geld -= 200; Console.WriteLine("🗳️ Jelzin bleibt!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Tschetschenien Waffenstillstand 1996", "Kriegsende", "Präsident", 100, 1996, "politisch", p => { p.Geld += 100; p.EinflussMilitär -= 10; Console.WriteLine("🕊️ Waffenruhe!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Minenverbot 1996", "Ottawa-Vertrag", "Präsident", 100, 1996, "politisch", p => { p.EinflussInternational += 10; Console.WriteLine("⚠️ Minenverbot!"); Thread.Sleep(3000); }));
        
        allEvents.Add(new RandomEvent("Hongkong China 1997", "Rückgabe an China", "Präsident", 100, 1997, "politisch", p => { p.ChinaBeziehung += 15; Console.WriteLine("🇨🇳 Hongkong chinesisch!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Prinzessin Diana 1997", "Tod in Paris", "Präsident", 100, 1997, "politisch", p => { p.EinflussInternational += 5; Console.WriteLine("💔 Diana tot!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Mir-Station Kollision 1997", "Raumstation beschädigt", "Präsident", 100, 1997, "katastrophe", p => { p.Gesundheit -= 10; Console.WriteLine("🛰️ Weltraum-Unfall!"); Thread.Sleep(3000); }));
        
        allEvents.Add(new RandomEvent("Rubelkrise 1998", "Wirtschaftskollaps", "Präsident", 100, 1998, "politisch", p => { p.Geld -= 500; p.Gesundheit -= 20; p.LoyalitätPartei -= 25; Console.WriteLine("💰 Rubel-Crash!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("IWF-Kredite 1998", "Rettungspaket", "Präsident", 100, 1998, "politisch", p => { p.Geld += 300; p.EinflussInternational -= 15; Console.WriteLine("💸 IWF-Hilfe!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Primakow Premier 1998", "Neuer Premierminister", "Präsident", 100, 1998, "politisch", p => { p.LoyalitätPartei += 10; Console.WriteLine("🏛️ Regierungswechsel!"); Thread.Sleep(3000); }));
        
        allEvents.Add(new RandomEvent("Kosovo-Krieg 1999", "NATO bombardiert Serbien", "Präsident", 100, 1999, "politisch", p => { p.EinflussInternational -= 25; p.EinflussMilitär += 15; Console.WriteLine("💥 NATO-Angriff!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Tschetschenien II 1999", "Zweiter Krieg", "Präsident", 100, 1999, "politisch", p => { p.EinflussMilitär += 25; p.Geld -= 200; Console.WriteLine("⚔️ Neuer Tschetschenien-Krieg!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Jelzin tritt zurück 1999", "Flad wird Präsident", "Präsident", 100, 1999, "politisch", p => { p.LoyalitätPartei += 20; Console.WriteLine("🇷🇺 Jelzin geht!"); Thread.Sleep(3000); }));
        
        // DUPLIKAT ENTFERNT: Putin 2000 ist bereits als HistoricalEvent vorhanden
        allEvents.Add(new RandomEvent("Kursk-Untergang 2000", "U-Boot sinkt", "Präsident", 100, 2000, "katastrophe", p => { p.Gesundheit -= 25; p.LoyalitätPartei -= 15; Console.WriteLine("💀 118 Tote!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Y2K-Bug überstanden 2000", "Millennium", "Präsident", 100, 2000, "politisch", p => { p.Geld += 50; Console.WriteLine("💻 Y2K geschafft!"); Thread.Sleep(3000); }));
        
        // CHINA-EVENTS
        allEvents.Add(new RandomEvent("China-Vertrag 1950", "UdSSR-China", "Kindheit", 60, 1950, "china", p => { p.Geld += 200; p.ChinaBeziehung = 80; Console.WriteLine("🇨🇳 +200 Rubel!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Damanski 1969", "Grenzkrieg", "KGB", 70, 1969, "china", p => { p.ChinaBeziehung -= 50; Console.WriteLine("💥 China -50%"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Gorbatschow China 1989", "Normalisierung", "KGB", 50, 1989, "china", p => { p.ChinaBeziehung += 30; Console.WriteLine("🤝 +30% China"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Freundschaft 2001", "20-Jahres-Vertrag", "Präsident", 60, 2001, "china", p => { p.Geld += 300; Console.WriteLine("✓ +300 Rubel!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Gas-Deal 2014", "$400 Mrd Deal!", "Präsident", 80, 2014, "china", p => { p.Geld += 500; p.ChinaTelefonAktiv = true; Console.WriteLine("💰 +500 Rubel! 📞 China aktiv!"); Thread.Sleep(3500); }));
        allEvents.Add(new RandomEvent("Xi Moskau 2015", "Militärübung", "Präsident", 50, 2015, "china", p => { p.EinflussMilitär += 30; Console.WriteLine("⚔️ +30 Militär!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Handel 2019", "$110 Mrd", "Präsident", 55, 2019, "china", p => { p.Geld += 350; Console.WriteLine("💰 +350 Rubel!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Olympia 2022", "Peking", "Präsident", 75, 2022, "china", p => { p.Geld += 400; Console.WriteLine("🏅 +400 Rubel!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Flad Peking 2024", "BRI-Forum", "Präsident", 70, 2024, "china", p => { p.Geld += 350; Console.WriteLine("🐉 +350 Rubel!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("China-Allianz 2025", "Strategisch", "Präsident", 60, 2025, "china", p => { p.Geld += 300; Console.WriteLine("🤝 +300 Rubel!"); Thread.Sleep(3000); }));
        
        // ═══════════════════════════════════════════════════════════
        // RUSSLAND-USA BEZIEHUNGEN (2000-2025)
        // ═══════════════════════════════════════════════════════════
        
        // 2001 - 9/11 und Kooperation
        allEvents.Add(new RandomEvent(
            "11. September 2001 - Terroranschläge",
            "Nach den Anschlägen vom 11. September bietet Russland den USA Zusammenarbeit im 'Krieg gegen den Terror' an...",
            "Präsident", 50, 2001, "usa",
            p => {
                Console.WriteLine("\n🇺🇸 Die USA wurden angegriffen! Flad bietet Kooperation an.");
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
            "Trump-Flad Gipfel Helsinki 2018",
            "Präsident Trump trifft Flad in Helsinki. Eine Annäherung ist möglich...",
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
            "US-Geheimdienste warnen vor Anschlag in Russland. Flad dankt Trump persönlich...",
            "Präsident", 35, 2019, "usa",
            p => {
                Console.WriteLine("\n🔒 CIA warnt vor Terroranschlag in St. Petersburg!");
                Console.WriteLine("\n✓ Anschlag verhindert! Trump und Flad telefonieren.");
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
            "Biden nennt Flad 'Killer' 2021",
            "Neuer US-Präsident Biden bezeichnet Flad als .Killer.. Diplomatischer Eklat!",
            "Präsident", 70, 2021, "usa",
            p => {
                Console.WriteLine("\n😠 Biden: 'Flad is a killer!'");
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
        
        // ═══════════════════════════════════════════════════════════
        // FUTURISTISCHE EREIGNISSE (2026-2100)
        // Prognosen für Russlands Zukunft
        // ═══════════════════════════════════════════════════════════
        
        // 2026
        allEvents.Add(new RandomEvent(
            "Arktische Allianz 2026",
            "Gründung eines neuen nordöstlichen Militärbündnisses mit China und Ex-Sowjetrepubliken. Flad tritt nach 25+ Jahren ab.",
            "Präsident", 75, 2026, "zukunft",
            p => {
                Console.WriteLine("\n📅 2026 - NEUE WELTORDNUNG");
                Console.WriteLine("═══════════════════════════════════════════");
                Console.WriteLine("🌏 'Arktische Allianz' mit China gegründet!");
                Console.WriteLine("👴 Flad tritt nach über 25 Jahren ab");
                Console.WriteLine("🤝 Technokratische Regierung formiert sich");
                p.EinflussInternational += 20;
                p.Geld += 200;
                p.LoyalitätPartei += 15;
                Console.WriteLine($"\n➕ International: +20 → {p.EinflussInternational}");
                Console.WriteLine($"💰 Geld: +200 Rubel → {p.Geld}");
                Thread.Sleep(4000);
            }
        ));
        
        // 2030
        allEvents.Add(new RandomEvent(
            "Energiekrise 2030",
            "Globale Energiekrise trifft Russland hart - Öl- und Gasexporte brechen ein. Größter sibirischer Solarkomplex wird errichtet.",
            "Präsident", 80, 2030, "zukunft",
            p => {
                Console.WriteLine("\n📅 2030 - ENERGIEWENDE");
                Console.WriteLine("═══════════════════════════════════════════");
                Console.WriteLine("⚡ Globale Energiekrise schlägt zu!");
                Console.WriteLine("📉 Öl- und Gasexporte brechen ein");
                Console.WriteLine("☀️  Größter Solarkomplex Sibiriens entsteht");
                Console.WriteLine("🏭 Verlagerung zu Hochtechnologie");
                p.Geld -= 300;
                p.EinflussInternational += 10;
                p.Gesundheit -= 5;
                Console.WriteLine($"\n💰 Geld: -300 Rubel → {p.Geld}");
                Console.WriteLine($"➕ International: +10 → {p.EinflussInternational}");
                Thread.Sleep(4000);
            }
        ));
        
        // 2035
        allEvents.Add(new RandomEvent(
            "Arktis-Boom 2035",
            "Arktisches Eis schmilzt fast komplett - neue Schifffahrtswege! Russland beansprucht rohstoffreiche Gebiete. Waldbrände im Süden.",
            "Präsident", 85, 2035, "zukunft",
            p => {
                Console.WriteLine("\n📅 2035 - ARKTIS-GOLDENER ZEITALTER");
                Console.WriteLine("═══════════════════════════════════════════");
                Console.WriteLine("🧊 Arktis eisfrei - Nordmeerweg offen!");
                Console.WriteLine("💎 Rohstoffreiche Gebiete beansprucht");
                Console.WriteLine("🔥 Waldbrände und Überflutungen im Süden");
                p.Geld += 400;
                p.EinflussInternational += 25;
                p.Gesundheit -= 10;
                Console.WriteLine($"\n💰 Geld: +400 Rubel → {p.Geld}");
                Console.WriteLine($"➕ International: +25 → {p.EinflussInternational}");
                Thread.Sleep(4000);
            }
        ));
        
        // 2040
        allEvents.Add(new RandomEvent(
            "Alzheimer-Impfstoff 2040",
            "Moskau entwickelt Alzheimer-Impfstoff! Eurasische Wirtschaftsunion wird echter Binnenmarkt. Rivalisierende Blöcke in Zentralasien.",
            "Präsident", 70, 2040, "zukunft",
            p => {
                Console.WriteLine("\n📅 2040 - MEDIZINISCHER DURCHBRUCH");
                Console.WriteLine("═══════════════════════════════════════════");
                Console.WriteLine("💉 Alzheimer-Impfstoff in Moskau entwickelt!");
                Console.WriteLine("🏆 Flad als .Wissenschafts-Fürst. gefeiert");
                Console.WriteLine("🌐 Eurasische Union wird Binnenmarkt");
                Console.WriteLine("⚔️  Rivalisierende Blöcke in Zentralasien");
                p.Gesundheit += 20;
                p.Geld += 300;
                p.EinflussInternational += 30;
                Console.WriteLine($"\n➕ Gesundheit: +20% → {p.Gesundheit}%");
                Console.WriteLine($"💰 Geld: +300 Rubel → {p.Geld}");
                Thread.Sleep(4000);
            }
        ));
        
        // 2050
        allEvents.Add(new RandomEvent(
            "Tech-Aufschwung 2050",
            "Weltweite Deindustrialisierungswelle - Russland erlebt Tech-Boom! Posthumes Flad-Image als 'Vater der Zivilisation'.",
            "Präsident", 75, 2050, "zukunft",
            p => {
                Console.WriteLine("\n📅 2050 - RUSSISCHES TECH-ZEITALTER");
                Console.WriteLine("═══════════════════════════════════════════");
                Console.WriteLine("🚀 Russland: Technologie-Exporteur #1");
                Console.WriteLine("👴 Flad posthum als 'Zivilisations-Vater'");
                Console.WriteLine("🇪🇺 Grenzstreitigkeiten mit EU (gelöst)");
                p.Geld += 500;
                p.EinflussInternational += 35;
                p.LoyalitätPartei += 20;
                Console.WriteLine($"\n💰 Geld: +500 Rubel → {p.Geld}");
                Console.WriteLine($"➕ International: +35 → {p.EinflussInternational}");
                Thread.Sleep(4000);
            }
        ));
        
        // 2061
        allEvents.Add(new RandomEvent(
            "Gagarin-100 2061",
            "100. Jahrestag Gagarins Flug! Internationale Mond-Raumstation. Volksreferendum über 'Neue UdSSR'. Flad: 'Generalsekretär der Ahnen'.",
            "Präsident", 80, 2061, "zukunft",
            p => {
                Console.WriteLine("\n📅 2061 - GAGARIN JAHRHUNDERT");
                Console.WriteLine("═══════════════════════════════════════════");
                Console.WriteLine("🚀 100 Jahre seit Gagarins Flug!");
                Console.WriteLine("🌙 Internationale Mond-Raumstation");
                Console.WriteLine("☭  'Neue UdSSR' Referendum diskutiert");
                Console.WriteLine("👴 Flad: 'Generalsekretär der Ahnen'");
                p.EinflussInternational += 40;
                p.LoyalitätPartei += 25;
                Console.WriteLine($"\n➕ International: +40 → {p.EinflussInternational}");
                Console.WriteLine($"➕ Partei: +25% → {p.LoyalitätPartei}%");
                Thread.Sleep(4000);
            }
        ));
        
        // 2075
        allEvents.Add(new RandomEvent(
            "Sonnensturm 2075",
            "Gewaltiger Sonnensturm beschädigt Stromnetze in ganz Russland! Wissenschaft entdeckt Gravitationsphänomen im Kosmos.",
            "Präsident", 85, 2075, "zukunft",
            p => {
                Console.WriteLine("\n📅 2075 - SONNENSTURM-KRISE");
                Console.WriteLine("═══════════════════════════════════════════");
                Console.WriteLine("☀️  Gewaltiger Sonnensturm trifft Erde!");
                Console.WriteLine("⚡ Stromnetze beschädigt");
                Console.WriteLine("🔬 Gravitationsphänomen entdeckt");
                Console.WriteLine("🇷🇺 Russland als Innovationsführer gefeiert");
                p.Geld -= 200;
                p.Gesundheit -= 15;
                p.EinflussInternational += 20;
                Console.WriteLine($"\n💰 Geld: -200 Rubel → {p.Geld}");
                Console.WriteLine($"➖ Gesundheit: -15% → {p.Gesundheit}%");
                Thread.Sleep(4000);
            }
        ));
        
        // 2100
        allEvents.Add(new RandomEvent(
            "Klimaneutral 2100",
            "Russland ist klimaneutrales Großreich! Erneuerbare Energie dominiert. Flads Vermächtnis: Archaischer Machtpolitiker oder Retter Russlands?",
            "Präsident", 90, 2100, "zukunft",
            p => {
                Console.WriteLine("\n📅 2100 - NEUES ZEITALTER");
                Console.WriteLine("═══════════════════════════════════════════");
                Console.WriteLine("🌱 Russland: Klimaneutrales Großreich!");
                Console.WriteLine("⚡ 100% Erneuerbare Energie");
                Console.WriteLine("🌍 Biomaterialien ersetzen Öl");
                Console.WriteLine("👴 Flads Vermächtnis kontrovers:");
                Console.WriteLine("   Machtpolitiker oder Retter?");
                p.Geld += 600;
                p.EinflussInternational += 50;
                p.Gesundheit += 10;
                p.LoyalitätPartei += 30;
                Console.WriteLine($"\n💰 Geld: +600 Rubel → {p.Geld}");
                Console.WriteLine($"➕ International: +50 → {p.EinflussInternational}");
                Console.WriteLine($"➕ Gesundheit: +10% → {p.Gesundheit}%");
                Console.WriteLine($"➕ Partei: +30% → {p.LoyalitätPartei}%");
                Thread.Sleep(5000);
            }
        ));
        
        // ZUSÄTZLICHE EVENTS FÜR ERHÖHTE DICHTE (1987-1996)
        // 1987 - 3 neue Events
        allEvents.Add(new RandomEvent("Mathias Rust Moskau 1987", "Deutscher landet am Roten Platz", "Präsident", 100, 1987, "katastrophe", p => { p.EinflussMilitär -= 25; p.Gesundheit -= 15; Console.WriteLine("✈️ Sicherheitsversagen!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("INF-Vertrag Verhandlungen 1987", "Abrüstungsgespräche", "Präsident", 100, 1987, "politisch", p => { p.EinflussInternational += 20; p.Geld += 100; Console.WriteLine("☮️ Entspannung!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Jelzin vs Gorbatschow 1987", "Parteistreit", "Präsident", 100, 1987, "politisch", p => { p.LoyalitätPartei -= 15; Console.WriteLine("⚔️ Machtkampf!"); Thread.Sleep(3000); }));
        
        // 1988 - 3 neue Events
        allEvents.Add(new RandomEvent("Erdbeben Armenien 1988", "25.000 Tote in Spitak", "Präsident", 100, 1988, "katastrophe", p => { p.Gesundheit -= 20; p.Geld -= 300; p.LoyalitätVolk -= 15; Console.WriteLine("💀 Katastrophe!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Rückzug Afghanistan 1988", "Ende des Krieges", "Präsident", 100, 1988, "politisch", p => { p.EinflussMilitär -= 20; p.Geld += 150; p.LoyalitätVolk += 10; Console.WriteLine("✈️ Truppen kehren heim!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Olympia Seoul 1988", "Sowjetische Erfolge", "Präsident", 100, 1988, "politisch", p => { p.EinflussInternational += 15; p.LoyalitätVolk += 10; Console.WriteLine("🏅 Gold-Rausch!"); Thread.Sleep(3000); }));
        
        // 1990 - 4 neue Events
        allEvents.Add(new RandomEvent("Deutsche Wiedervereinigung 1990", "Berliner Mauer fällt", "Präsident", 100, 1990, "politisch", p => { p.EinflussInternational -= 30; p.EinflussMilitär -= 20; Console.WriteLine("🧱 DDR endet!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Baltikum Unabhängigkeit 1990", "Litauen erklärt Unabhängigkeit", "Präsident", 100, 1990, "politisch", p => { p.LoyalitätPartei -= 20; p.EinflussMilitär -= 15; Console.WriteLine("🇱🇹 UdSSR zerbricht!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Gorbatschow Friedensnobelpreis 1990", "Internationale Anerkennung", "Präsident", 100, 1990, "politisch", p => { p.EinflussInternational += 25; p.LoyalitätVolk -= 10; Console.WriteLine("🏆 Nobelpreis!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Wirtschaftskrise 1990", "Versorgungsengpässe", "Präsident", 100, 1990, "katastrophe", p => { p.Geld -= 400; p.LoyalitätVolk -= 25; p.Gesundheit -= 10; Console.WriteLine("🍞 Lebensmittelknappheit!"); Thread.Sleep(3000); }));
        
        // 1993 - 3 neue Events
        allEvents.Add(new RandomEvent("Panzerschlacht Moskau 1993", "Jelzin beschießt Parlament", "Präsident", 100, 1993, "katastrophe", p => { p.EinflussMilitär += 20; p.LoyalitätVolk -= 30; p.Gesundheit -= 20; Console.WriteLine("💥 Bürgerkrieg droht!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Hyperinflation 1993", "Rubel-Verfall", "Präsident", 100, 1993, "katastrophe", p => { p.Geld -= 500; p.LoyalitätVolk -= 20; Console.WriteLine("💸 Währungskollaps!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Tschetschenien Unabhängigkeit 1993", "Dudajew erklärt Unabhängigkeit", "Präsident", 100, 1993, "politisch", p => { p.EinflussMilitär -= 15; p.LoyalitätPartei -= 10; Console.WriteLine("⚔️ Separatismus!"); Thread.Sleep(3000); }));
        
        // 1994 - 3 neue Events
        allEvents.Add(new RandomEvent("Erster Tschetschenienkrieg 1994", "Invasion Grosnys", "Präsident", 100, 1994, "politisch", p => { p.EinflussMilitär += 25; p.Geld -= 400; p.LoyalitätVolk -= 20; Console.WriteLine("⚔️ Krieg beginnt!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("Schwarzer Dienstag 1994", "Rubel stürzt ab", "Präsident", 100, 1994, "katastrophe", p => { p.Geld -= 600; p.Gesundheit -= 15; Console.WriteLine("📉 Finanzcrash!"); Thread.Sleep(3000); }));
        allEvents.Add(new RandomEvent("NATO-Erweiterung Debatte 1994", "Polen will NATO beitreten", "Präsident", 100, 1994, "politisch", p => { p.EinflussInternational -= 20; p.NATOBeziehung -= 25; Console.WriteLine("⚠️ NATO-Bedrohung!"); Thread.Sleep(3000); }));
        
        // ═══════════════════════════════════════════════════════════════════
        // MASSIVE EVENT-DICHTE-ERWEITERUNG (1952-2025)
        // Jedes Event mit dramatischer Beschreibung + Volk & Spieler-Auswirkungen
        // ═══════════════════════════════════════════════════════════════════
        
        // 1952 - 3 zusätzliche Events
        allEvents.Add(new RandomEvent(
            "Eiseskälte Leningrad 1952",
            "WINTER DER VERZWEIFLUNG! Temperaturen fallen auf -40°C. Die Bevölkerung hungert in verfallenen Kommunalkas. Kohle ist knapp, Kinder erfrieren in den Straßen von Leningrad. Das Volk leidet still - doch in ihren Augen lodert Wut auf die Partei, die sie im Stich lässt.",
            "Kindheit", 100, 1952, "katastrophe",
            p => {
                Console.WriteLine("\n❄️ EISESKÄLTE HERRSCHT IN LENINGRAD!");
                Console.WriteLine("Das Volk friert und hungert. Die Partei ignoriert das Leid.");
                p.Gesundheit -= 15;
                p.LoyalitätVolk -= 20;
                p.LoyalitätPartei -= 10;
                p.Geld -= 50;
                Console.WriteLine($"➖ Gesundheit: -15% → {p.Gesundheit}%");
                Console.WriteLine($"➖ Volk-Loyalität: -20% → {p.LoyalitätVolk}%");
                Console.WriteLine($"➖ Partei-Loyalität: -10% → {p.LoyalitätPartei}%");
                Thread.Sleep(4000);
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Ärzte-Verschwörung Panik 1952",
            "STALINS TERROR ERREICHT HÖHEPUNKT! Neun jüdische Ärzte werden beschuldigt, Kreml-Führer vergiften zu wollen. Massenverhaftungen in Moskau! Das Volk erstarrt in Angst - niemand ist mehr sicher. Nachbarn denunzieren Nachbarn. Die Paranoia des Führers infiziert die gesamte Nation.",
            "Kindheit", 100, 1952, "politisch",
            p => {
                Console.WriteLine("\n🏥 ÄRZTE-VERSCHWÖRUNG - TERROR ÜBERALL!");
                Console.WriteLine("Jüdische Ärzte werden verhaftet! Das Volk lebt in Angst!");
                p.EinflussKGB += 20;
                p.LoyalitätVolk -= 25;
                p.Gesundheit -= 10;
                p.LoyalitätPartei += 15;
                Console.WriteLine($"➕ KGB-Einfluss: +20 → {p.EinflussKGB}");
                Console.WriteLine($"➖ Volk-Loyalität: -25% → {p.LoyalitätVolk}%");
                Console.WriteLine($"➖ Gesundheit: -10% → {p.Gesundheit}%");
                Thread.Sleep(4000);
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Schauprozesse 1952",
            "BLUTIGER SÄUBERUNGSWAHN! 13 jüdische Intellektuelle werden in Moskau hingerichtet. Die Slánský-Prozesse in Prag erschüttern den Ostblock. Das Volk beobachtet schweigend die Hinrichtungen - niemand wagt zu protestieren. Stalin ist allmächtig, unberechenbar und tödlich.",
            "Kindheit", 100, 1952, "politisch",
            p => {
                Console.WriteLine("\n⚖️ SCHAUPROZESSE & EXEKUTIONEN!");
                Console.WriteLine("13 Intellektuelle hingerichtet! Das Volk schweigt aus Angst!");
                p.EinflussKGB += 15;
                p.LoyalitätVolk -= 30;
                p.Intelligenz += 1;
                p.LoyalitätPartei -= 15;
                Console.WriteLine($"➕ KGB-Einfluss: +15 → {p.EinflussKGB}");
                Console.WriteLine($"➖ Volk-Loyalität: -30% → {p.LoyalitätVolk}%");
                Console.WriteLine($"➕ Intelligenz: +1 (du lernst aus dem Terror)");
                Thread.Sleep(4000);
            }
        ));
        
        // 1954 - 3 zusätzliche Events
        allEvents.Add(new RandomEvent(
            "Gulag-Aufstand Kengir 1954",
            "REVOLUTION IM TODESLAGER! 5000 Häftlinge im Gulag Kengir erheben sich gegen die Wärter! 40 Tage der Freiheit hinter Stacheldraht - doch dann rollen sowjetische Panzer heran. Hunderte werden niedergemetzelt. Das Volk hört Gerüchte, doch niemand spricht darüber.",
            "Kindheit", 100, 1954, "katastrophe",
            p => {
                Console.WriteLine("\n⛓️ GULAG-AUFSTAND BLUTIG NIEDERGESCHLAGEN!");
                Console.WriteLine("Hunderte Häftlinge sterben! Das Volk erfährt nichts offiziell!");
                p.EinflussMilitär += 15;
                p.LoyalitätVolk -= 20;
                p.Stärke += 1;
                p.Gesundheit -= 10;
                Console.WriteLine($"➕ Militär-Einfluss: +15 → {p.EinflussMilitär}");
                Console.WriteLine($"➖ Volk-Loyalität: -20% → {p.LoyalitätVolk}%");
                Console.WriteLine($"➕ Stärke: +1 (die Härte der Zeit formt dich)");
                Thread.Sleep(4000);
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Erste Atomkraft Obninsk 1954",
            "SOWJETMACHT ERLEUCHTET DIE ZUKUNFT! Das weltweit erste kommerzielle Atomkraftwerk wird in Obninsk eröffnet! Die UdSSR führt das Atomzeitalter an. Das Volk jubelt - endlich gibt es Hoffnung auf mehr Strom und ein besseres Leben. Die Parteipropaganda feiert den 'Roten Triumph der Wissenschaft'!",
            "Kindheit", 100, 1954, "politisch",
            p => {
                Console.WriteLine("\n⚡ ATOMKRAFT FÜR DAS VOLK!");
                Console.WriteLine("Obninsk-Reaktor startet! Das Volk hofft auf Wohlstand!");
                p.EinflussInternational += 25;
                p.LoyalitätVolk += 20;
                p.Geld += 100;
                p.Intelligenz += 1;
                Console.WriteLine($"➕ International: +25 → {p.EinflussInternational}");
                Console.WriteLine($"➕ Volk-Loyalität: +20% → {p.LoyalitätVolk}%");
                Console.WriteLine($"💰 Geld: +100 Rubel → {p.Geld}");
                Thread.Sleep(4000);
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "KGB gegründet 1954",
            "GEBURT DES ALLMÄCHTIGEN AUGES! Das KGB wird offiziell gegründet - Nachfolger von NKWD und MGB. Ein gigantischer Geheimdienst-Apparat durchdringt jeden Winkel der Sowjetunion. Das Volk wird überwacht, abgehört, kontrolliert. Niemand ist sicher - nicht einmal Parteimitglieder.",
            "Kindheit", 100, 1954, "politisch",
            p => {
                Console.WriteLine("\n👁️ DAS KGB WIRD GEBOREN!");
                Console.WriteLine("Totale Überwachung beginnt! Das Volk wird kontrolliert!");
                p.EinflussKGB += 30;
                p.LoyalitätVolk -= 15;
                p.LoyalitätPartei += 20;
                p.Intelligenz += 1;
                Console.WriteLine($"➕ KGB-Einfluss: +30 → {p.EinflussKGB}");
                Console.WriteLine($"➖ Volk-Loyalität: -15% → {p.LoyalitätVolk}%");
                Console.WriteLine($"➕ Partei-Loyalität: +20% → {p.LoyalitätPartei}%");
                Thread.Sleep(4000);
            }
        ));
        
        // 1955 - 3 zusätzliche Events
        allEvents.Add(new RandomEvent(
            "Entstalinisierung beginnt 1955",
            "STALINS STATUEN STÜRZEN! Chruschtschow beginnt vorsichtig, Stalins Verbrechen anzudeuten. Tausende politische Gefangene werden aus Gulags entlassen. Das Volk atmet auf - doch viele fragen sich: War alles umsonst? Die Partei gibt zu, dass der 'große Führer' Millionen ermordet hat.",
            "Kindheit", 100, 1955, "politisch",
            p => {
                Console.WriteLine("\n🗿 STALIN WIRD KRITISIERT!");
                Console.WriteLine("Gefangene kehren heim! Das Volk ist verwirrt aber hoffnungsvoll!");
                p.LoyalitätPartei -= 20;
                p.LoyalitätVolk += 25;
                p.Gesundheit += 10;
                p.Intelligenz += 1;
                Console.WriteLine($"➖ Partei-Loyalität: -20% → {p.LoyalitätPartei}%");
                Console.WriteLine($"➕ Volk-Loyalität: +25% → {p.LoyalitätVolk}%");
                Console.WriteLine($"➕ Gesundheit: +10% → {p.Gesundheit}%");
                Thread.Sleep(4000);
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Belgrader Erklärung 1955",
            "VERSÖHNUNG MIT DEM VERRÄTER! Chruschtschow reist nach Jugoslawien und entschuldigt sich bei Tito. Die UdSSR erkennt den 'eigenen Weg zum Sozialismus' an. Das Volk ist verwirrt - gestern noch Feind, heute Bruder? Die Parteilinie ändert sich schneller als das Wetter.",
            "Kindheit", 100, 1955, "politisch",
            p => {
                Console.WriteLine("\n🇷🇸 VERSÖHNUNG MIT JUGOSLAWIEN!");
                Console.WriteLine("Tito ist plötzlich Freund! Das Volk versteht nichts mehr!");
                p.EinflussInternational += 15;
                p.LoyalitätVolk -= 10;
                p.Charisma += 1;
                Console.WriteLine($"➕ International: +15 → {p.EinflussInternational}");
                Console.WriteLine($"➖ Volk-Loyalität: -10% → {p.LoyalitätVolk}%");
                Console.WriteLine($"➕ Charisma: +1 (du lernst Diplomatie)");
                Thread.Sleep(4000);
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Genfer Gipfel 1955",
            "HOFFNUNG AUF FRIEDEN! Die 'Großen Vier' treffen sich in Genf - USA, UdSSR, UK, Frankreich. Chruschtschow lächelt, Eisenhower winkt. Das Volk träumt von Frieden und Wohlstand. Doch hinter den Kulissen bleibt das gegenseitige Misstrauen eisig. Der Kalte Krieg friert nur kurz.",
            "Kindheit", 100, 1955, "politisch",
            p => {
                Console.WriteLine("\n☮️ GENFER GIPFEL - ENTSPANNUNG?");
                Console.WriteLine("Weltmächte verhandeln! Das Volk hofft auf Frieden!");
                p.EinflussInternational += 20;
                p.LoyalitätVolk += 15;
                p.Geld += 75;
                p.Charisma += 1;
                Console.WriteLine($"➕ International: +20 → {p.EinflussInternational}");
                Console.WriteLine($"➕ Volk-Loyalität: +15% → {p.LoyalitätVolk}%");
                Console.WriteLine($"💰 Geld: +75 Rubel → {p.Geld}");
                Thread.Sleep(4000);
            }
        ));
        
        // 2001-2005 - Neue Events für Flad-Ära
        allEvents.Add(new RandomEvent(
            "9/11 Terror New York 2001",
            "DIE WELT BRENNT! Zwei Flugzeuge rasen in die Twin Towers - 3000 Menschen sterben live im Fernsehen. Die USA erklären den 'Krieg gegen den Terror'. Flad sieht seine Chance: Russland wird plötzlich zum Verbündeten des Westens. Das Volk erinnert sich an eigene Terror-Anschläge.",
            "Präsident", 100, 2001, "katastrophe",
            p => {
                Console.WriteLine("\n✈️💥 9/11 - WELTORDNUNG WANKT!");
                Console.WriteLine("USA und Russland verbünden sich gegen Terror!");
                p.EinflussInternational += 30;
                p.LoyalitätVolk += 10;
                p.USABeziehung += 25;
                p.Geld += 200;
                Console.WriteLine($"➕ International: +30 → {p.EinflussInternational}");
                Console.WriteLine($"➕ Volk-Loyalität: +10% → {p.LoyalitätVolk}%");
                Console.WriteLine($"➕ USA-Beziehung: +25 → {p.USABeziehung}");
                Thread.Sleep(4500);
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Moskau-Theater Geiselnahme 2002",
            "HORROR IM DUBROWKA-THEATER! 40 tschetschenische Terroristen nehmen 900 Geiseln. Flad befiehlt Giftgas-Einsatz - 130 Geiseln sterben qualvoll. Das Volk ist geschockt, doch die Propaganda verdreht alles: 'Helden retteten Hunderte'. Die Wahrheit stirbt im Gas.",
            "Präsident", 100, 2002, "katastrophe",
            p => {
                Console.WriteLine("\n☠️ THEATER-GEISELNAHME ENDET TÖDLICH!");
                Console.WriteLine("130 Tote durch Giftgas! Das Volk ist erschüttert!");
                p.EinflussMilitär += 20;
                p.LoyalitätVolk -= 35;
                p.Gesundheit -= 25;
                p.LoyalitätPartei += 15;
                Console.WriteLine($"➕ Militär: +20 → {p.EinflussMilitär}");
                Console.WriteLine($"➖ Volk-Loyalität: -35% → {p.LoyalitätVolk}%");
                Console.WriteLine($"➖ Gesundheit: -25% → {p.Gesundheit}%");
                Thread.Sleep(4500);
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Chodorkowski verhaftet 2003",
            "OLIGARCH IM KÄFIG! Michail Chodorkowski, reichster Mann Russlands, wird vom FSB verhaftet. Sein Verbrechen? Zu reich, zu mächtig, zu unabhängig. Flad zeigt allen: 'Ich bin der Boss'. Das Volk applaudiert - endlich werden die Oligarchen bestraft! Doch andere Oligarchen kriechen vor Flad.",
            "Präsident", 100, 2003, "politisch",
            p => {
                Console.WriteLine("\n⛓️ OLIGARCH CHODORKOWSKI VERHAFTET!");
                Console.WriteLine("Das Volk jubelt: Rache an den Reichen!");
                p.EinflussKGB += 25;
                p.LoyalitätVolk += 30;
                p.Geld += 500;
                p.LoyalitätPartei += 20;
                Console.WriteLine($"➕ KGB/FSB-Einfluss: +25 → {p.EinflussKGB}");
                Console.WriteLine($"➕ Volk-Loyalität: +30% → {p.LoyalitätVolk}%");
                Console.WriteLine($"💰 Geld: +500 Rubel (beschlagnahmt) → {p.Geld}");
                Thread.Sleep(4500);
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Beslan Schulmassaker 2004",
            "KINDER STERBEN IN FLAMMEN! Terroristen nehmen 1100 Menschen in einer Schule als Geiseln - darunter 777 Kinder. Die Armee stürmt mit Panzern und Flammenwerfern. 334 Tote, davon 186 Kinder. Das Volk trauert und weint. Flad schweigt drei Tage lang.",
            "Präsident", 100, 2004, "katastrophe",
            p => {
                Console.WriteLine("\n💔 BESLAN - DIE NATION WEINT!");
                Console.WriteLine("186 Kinder tot! Das Volk ist gebrochen!");
                p.Gesundheit -= 30;
                p.LoyalitätVolk -= 40;
                p.EinflussMilitär -= 15;
                p.Geld -= 300;
                Console.WriteLine($"➖ Gesundheit: -30% → {p.Gesundheit}%");
                Console.WriteLine($"➖ Volk-Loyalität: -40% → {p.LoyalitätVolk}%");
                Console.WriteLine($"➖ Militär: -15 → {p.EinflussMilitär}");
                Thread.Sleep(5000);
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Orange Revolution Ukraine 2004",
            "KIEWER MAIDAN BRENNT! Eine Million Ukrainer protestieren gegen Wahlfälschung. Der pro-russische Kandidat wird gestürzt, der Westen jubelt. Flad ist wütend - die Ukraine entgleitet seinem Griff. Das Volk in Russland sieht nervös zu: Könnte das auch hier passieren?",
            "Präsident", 100, 2004, "politisch",
            p => {
                Console.WriteLine("\n🧡 ORANGE REVOLUTION IN UKRAINE!");
                Console.WriteLine("Ukraine wendet sich dem Westen zu! Das Volk ist beunruhigt!");
                p.EinflussInternational -= 30;
                p.LoyalitätVolk -= 15;
                p.Geld -= 200;
                p.LoyalitätPartei -= 20;
                Console.WriteLine($"➖ International: -30 → {p.EinflussInternational}");
                Console.WriteLine($"➖ Volk-Loyalität: -15% → {p.LoyalitätVolk}%");
                Console.WriteLine($"💰 Verlust: -200 Rubel → {p.Geld}");
                Thread.Sleep(4500);
            }
        ));
        
        // 1965-1970 - Vietnam-Krieg Ära
        allEvents.Add(new RandomEvent(
            "Leonid Breschnew Macht 1965",
            "NEUE ÄRA DER STAGNATION! Breschnew übernimmt die Macht und beendet Chruschtschows Reformen. Die Hoffnung auf Veränderung stirbt. Das Volk spürt, dass die Uhr rückwärts dreht. Panzer statt Brot, Propaganda statt Wahrheit. Die 'Ära der Stagnation' beginnt - 18 Jahre Stillstand.",
            "Jugend", 100, 1965, "politisch",
            p => {
                Console.WriteLine("\n☭ BRESCHNEW ÜBERNIMMT - STAGNATION BEGINNT!");
                Console.WriteLine("Reformen enden! Das Volk verliert die Hoffnung!");
                p.LoyalitätPartei += 20;
                p.LoyalitätVolk -= 25;
                p.Geld -= 100;
                p.Gesundheit -= 10;
                Console.WriteLine($"➕ Partei: +20% → {p.LoyalitätPartei}%");
                Console.WriteLine($"➖ Volk: -25% → {p.LoyalitätVolk}%");
                Console.WriteLine($"➖ Gesundheit: -10% → {p.Gesundheit}%");
                Thread.Sleep(4000);
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Vietnam-Krieg Eskalation 1965",
            "PROXY-KRIEG IN ASIEN! Die USA bombardieren Nordvietnam - sowjetische Waffen schießen zurück. Das Volk sieht die Wochenschau: Amerikanische Jets brennen, sowjetische SAM-Raketen triumphieren. 'Wir bekämpfen den Imperialismus', sagt die Propaganda. Das Volk zahlt mit Rubeln und Hunger.",
            "Jugend", 100, 1965, "politisch",
            p => {
                Console.WriteLine("\n💥 VIETNAM - SOWJETISCHE WAFFEN IM EINSATZ!");
                Console.WriteLine("Kalter Krieg wird heiß! Das Volk zahlt die Rechnung!");
                p.EinflussMilitär += 25;
                p.Geld -= 300;
                p.LoyalitätVolk -= 15;
                p.EinflussInternational += 20;
                Console.WriteLine($"➕ Militär: +25 → {p.EinflussMilitär}");
                Console.WriteLine($"💰 Kosten: -300 Rubel → {p.Geld}");
                Console.WriteLine($"➖ Volk: -15% → {p.LoyalitätVolk}%");
                Thread.Sleep(4000);
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Leonid Breschnew Kultpersönlichkeit 1966",
            "DER NEUE GOTT! Breschnews Gesicht ist überall - Plakate, Statuen, Briefmarken. Er verleiht sich selbst Orden und Medaillen wie Bonbons. Das Volk lacht heimlich über den aufgeblasenen Greis. 'Genosse Augenbrauen' nennen sie ihn. Doch laut lachen kostet 5 Jahre Gulag.",
            "Jugend", 100, 1966, "politisch",
            p => {
                Console.WriteLine("\n🏅 BRESCHNEW-KULT BEGINNT!");
                Console.WriteLine("Selbstverherrlichung ohne Ende! Das Volk spottet heimlich!");
                p.LoyalitätPartei += 15;
                p.LoyalitätVolk -= 20;
                p.Charisma -= 1;
                p.Geld -= 50;
                Console.WriteLine($"➕ Partei: +15% → {p.LoyalitätPartei}%");
                Console.WriteLine($"➖ Volk: -20% → {p.LoyalitätVolk}%");
                Console.WriteLine($"➖ Charisma: -1 (Personenkult ist peinlich)");
                Thread.Sleep(4000);
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Sechs-Tage-Krieg 1967",
            "DEMÜTIGUNG IM NAHEN OSTEN! Israel zerschmettert arabische Armeen in nur 6 Tagen - alle mit sowjetischen Waffen ausgerüstet! Das Volk hört die Nachrichten ungläubig: MiGs vom Himmel geschossen, Panzer verbrannt. 'Unsere Waffen taugen nichts', flüstern sie. Die Propaganda schweigt betreten.",
            "Jugend", 100, 1967, "katastrophe",
            p => {
                Console.WriteLine("\n✡️ SECHS-TAGE-KRIEG - SOWJETISCHE NIEDERLAGE!");
                Console.WriteLine("Arabische Armeen vernichtet! Das Volk zweifelt an der Macht!");
                p.EinflussMilitär -= 30;
                p.LoyalitätVolk -= 20;
                p.EinflussInternational -= 25;
                p.Geld -= 400;
                Console.WriteLine($"➖ Militär: -30 → {p.EinflussMilitär}");
                Console.WriteLine($"➖ Volk: -20% → {p.LoyalitätVolk}%");
                Console.WriteLine($"➖ International: -25 → {p.EinflussInternational}");
                Thread.Sleep(4500);
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Prager Frühling 1968",
            "PANZER GEGEN TRÄUME! Alexander Dubček versucht 'Sozialismus mit menschlichem Antlitz' in der Tschechoslowakei. Das Volk in Moskau horcht auf - könnte das auch bei uns funktionieren? NEIN! 500.000 Soldaten und 6000 Panzer walzen Prag nieder. Träume sterben unter Ketten.",
            "Jugend", 100, 1968, "katastrophe",
            p => {
                Console.WriteLine("\n🇨🇿 PRAGER FRÜHLING BLUTIG BEENDET!");
                Console.WriteLine("Panzer rollen durch Prag! Das Volk weint um zerstörte Hoffnungen!");
                p.EinflussMilitär += 30;
                p.LoyalitätVolk -= 35;
                p.EinflussInternational -= 40;
                p.Gesundheit -= 15;
                Console.WriteLine($"➕ Militär: +30 → {p.EinflussMilitär}");
                Console.WriteLine($"➖ Volk: -35% → {p.LoyalitätVolk}%");
                Console.WriteLine($"➖ International: -40 → {p.EinflussInternational}");
                Thread.Sleep(4500);
            }
        ));
        
        // 1970er - Breschnew-Stagnation
        allEvents.Add(new RandomEvent(
            "Dissidenten-Bewegung 1970",
            "MUTIGE STIMMEN ERHEBEN SICH! Sacharow, Solschenizyn und andere Dissidenten kritisieren offen das Regime. Das Volk liest heimlich Samisdat-Literatur - auf Schreibmaschinen kopierte verbotene Texte. Jeder, der erwischt wird, verschwindet. Doch die Wahrheit lässt sich nicht mehr stoppen.",
            "KGB", 100, 1970, "politisch",
            p => {
                Console.WriteLine("\n✊ DISSIDENTEN FORDERN FREIHEIT!");
                Console.WriteLine("Untergrund-Literatur verbreitet sich! Das Volk erwacht langsam!");
                p.EinflussKGB += 20;
                p.LoyalitätVolk -= 25;
                p.Intelligenz += 2;
                p.LoyalitätPartei -= 15;
                Console.WriteLine($"➕ KGB: +20 → {p.EinflussKGB}");
                Console.WriteLine($"➖ Volk: -25% → {p.LoyalitätVolk}%");
                Console.WriteLine($"➕ Intelligenz: +2 (du liest verbotene Bücher)");
                Thread.Sleep(4000);
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Öl-Boom 1973",
            "SCHWARZES GOLD RETTET DIE SOWJETUNION! Die Ölkrise lässt Preise explodieren - Petrodollars fluten Moskau. Das Volk bemerkt winzige Verbesserungen: mehr Wurst, weniger Schlangen. Doch das Geld wird nicht investiert - es verschwindet in Korruption und Rüstung. Der Untergang wird nur vertagt.",
            "KGB", 100, 1973, "politisch",
            p => {
                Console.WriteLine("\n🛢️ ÖL-BOOM - KURZER WOHLSTAND!");
                Console.WriteLine("Petrodollars fließen! Das Volk atmet auf - vorerst!");
                p.Geld += 800;
                p.LoyalitätVolk += 20;
                p.EinflussInternational += 15;
                p.Gesundheit += 10;
                Console.WriteLine($"💰 Geld: +800 Rubel → {p.Geld}");
                Console.WriteLine($"➕ Volk: +20% → {p.LoyalitätVolk}%");
                Console.WriteLine($"➕ Gesundheit: +10% → {p.Gesundheit}%");
                Thread.Sleep(4000);
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Helsinki-Abkommen 1975",
            "SCHEIN-ENTSPANNUNG IN EUROPA! 35 Nationen unterzeichnen Abkommen über Menschenrechte und Grenzen. Breschnew unterschreibt lächelnd - und ignoriert alles sofort. Das Volk hofft kurz auf Reisefreiheit. FEHLANZEIGE! Die Mauer steht, die Grenzen töten. Helsinki ist nur Papier.",
            "KGB", 100, 1975, "politisch",
            p => {
                Console.WriteLine("\n📜 HELSINKI - LEERE VERSPRECHEN!");
                Console.WriteLine("Menschenrechte unterschrieben, aber ignoriert! Das Volk ist enttäuscht!");
                p.EinflussInternational += 20;
                p.LoyalitätVolk -= 15;
                p.Charisma += 1;
                p.Geld += 100;
                Console.WriteLine($"➕ International: +20 → {p.EinflussInternational}");
                Console.WriteLine($"➖ Volk: -15% → {p.LoyalitätVolk}%");
                Console.WriteLine($"➕ Charisma: +1 (du lernst Doppelzüngigkeit)");
                Thread.Sleep(4000);
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Afghanistan-Invasion 1979",
            "DIE SOWJETUNION MARSCHIERT IN DEN ABGRUND! 100.000 Soldaten überqueren die Grenze nach Afghanistan. 'Es wird nur ein paar Wochen dauern', lügt die Propaganda. Das Volk schickt seine Söhne in den Tod. 10 Jahre Krieg, 15.000 tote Russen, unzählige Mütter weinen. Afghanistans Berge werden zum Friedhof.",
            "KGB", 100, 1979, "katastrophe",
            p => {
                Console.WriteLine("\n⚔️ AFGHANISTAN - DAS SOWJETISCHE VIETNAM!");
                Console.WriteLine("Die Invasion beginnt! Das Volk ahnt das Desaster!");
                p.EinflussMilitär += 25;
                p.Geld -= 600;
                p.LoyalitätVolk -= 30;
                p.Gesundheit -= 20;
                Console.WriteLine($"➕ Militär: +25 → {p.EinflussMilitär}");
                Console.WriteLine($"💰 Kosten: -600 Rubel → {p.Geld}");
                Console.WriteLine($"➖ Volk: -30% → {p.LoyalitätVolk}%");
                Thread.Sleep(4500);
            }
        ));
        
        // 2010er - Moderne Flad-Ära
        allEvents.Add(new RandomEvent(
            "Proteste gegen Wahlfälschung 2011",
            "DAS VOLK ERWACHT! 100.000 Menschen auf Moskaus Straßen - die größten Proteste seit Jahrzehnten! 'Flad ist ein Dieb!' skandieren sie. Die Mittelschicht fordert Veränderung. Doch die Polizei schlägt brutal zu. Flad lernt: Liberalisierung war ein Fehler. Der Schraubstock wird angezogen.",
            "Präsident", 100, 2011, "politisch",
            p => {
                Console.WriteLine("\n✊ PROTESTE GEGEN PUTIN!");
                Console.WriteLine("100.000 auf den Straßen! Das Volk will Wandel!");
                p.LoyalitätVolk -= 35;
                p.EinflussKGB += 20;
                p.LoyalitätPartei -= 15;
                p.Gesundheit -= 15;
                Console.WriteLine($"➖ Volk: -35% → {p.LoyalitätVolk}%");
                Console.WriteLine($"➕ KGB/FSB: +20 → {p.EinflussKGB}");
                Console.WriteLine($"➖ Partei: -15% → {p.LoyalitätPartei}%");
                Thread.Sleep(4500);
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Pussy Riot Verhaftung 2012",
            "PUNK-GEBET IM ERLÖSER-KATHEDRALE! Drei Frauen stürmen die Hauptkirche und singen 'Mutter Gottes, vertreibe Flad!' 2 Jahre Straflager. Das Volk ist gespalten: Helden oder Gotteslästerer? Der Westen protestiert. Flad ist es egal. Die Nachricht ist klar: Widerstand wird gebrochen.",
            "Präsident", 100, 2012, "politisch",
            p => {
                Console.WriteLine("\n🎸 PUSSY RIOT - PROTEST WIRD BESTRAFT!");
                Console.WriteLine("2 Jahre Lager für ein Lied! Das Volk ist gespalten!");
                p.EinflussKGB += 15;
                p.LoyalitätVolk -= 20;
                p.EinflussInternational -= 25;
                p.LoyalitätPartei += 10;
                Console.WriteLine($"➕ KGB/FSB: +15 → {p.EinflussKGB}");
                Console.WriteLine($"➖ Volk: -20% → {p.LoyalitätVolk}%");
                Console.WriteLine($"➖ International: -25 → {p.EinflussInternational}");
                Thread.Sleep(4000);
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Meteorit Tscheljabinsk 2013",
            "DER HIMMEL EXPLODIERT! Ein 20-Meter-Asteroid rast über Tscheljabinsk - die Druckwelle zerstört 7000 Gebäude! 1500 Verletzte. Dashcam-Videos gehen viral - die ganze Welt sieht russische Autofahrer, die nicht mal blinzeln. 'Normaler Tag in Russland', witzelt das Volk. Galgenhumor gegen die Härte des Lebens.",
            "Präsident", 100, 2013, "katastrophe",
            p => {
                Console.WriteLine("\n☄️ METEORIT SCHOCKT RUSSLAND!");
                Console.WriteLine("7000 Gebäude zerstört! Das Volk bleibt stoisch!");
                p.Gesundheit -= 20;
                p.Geld -= 500;
                p.LoyalitätVolk += 10;
                p.Kraft += 1;
                Console.WriteLine($"➖ Gesundheit: -20% → {p.Gesundheit}%");
                Console.WriteLine($"💰 Schaden: -500 Rubel → {p.Geld}");
                Console.WriteLine($"➕ Kraft: +1 (russische Härte)");
                Thread.Sleep(4000);
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Olympia Sotschi 2014",
            "DIE TEUERSTEN SPIELE ALLER ZEITEN! 51 Milliarden Dollar für Flads Prestige-Projekt. Korruption frisst Milliarden. Das Volk sieht glitzernde Stadien im Fernsehen - während sie in verfallenen Plattenbauten frieren. 'Brot und Spiele', sagen die Zyniker. Eine Woche später: Krim-Annexion beginnt.",
            "Präsident", 100, 2014, "politisch",
            p => {
                Console.WriteLine("\n🏅 SOTSCHI-OLYMPIA - VERSCHWENDUNG!");
                Console.WriteLine("51 Milliarden für Propaganda! Das Volk zahlt die Zeche!");
                p.EinflussInternational += 20;
                p.Geld -= 1000;
                p.LoyalitätVolk -= 25;
                p.LoyalitätPartei += 15;
                Console.WriteLine($"➕ International: +20 → {p.EinflussInternational}");
                Console.WriteLine($"💰 Kosten: -1000 Rubel → {p.Geld}");
                Console.WriteLine($"➖ Volk: -25% → {p.LoyalitätVolk}%");
                Thread.Sleep(4000);
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Krim-Annexion 2014",
            "DIE KRIM IST UNSER! 'Grüne Männchen' ohne Abzeichen übernehmen die Halbinsel. Flad leugnet alles - dann gibt er später zu, es waren russische Soldaten. Das Volk jubelt: Endlich Stärke! Westliche Sanktionen folgen sofort. Der Rubel stürzt ab. Patriotismus füllt keine Mägen.",
            "Präsident", 100, 2014, "politisch",
            p => {
                Console.WriteLine("\n🇷🇺 KRIM ZURÜCK ZU RUSSLAND!");
                Console.WriteLine("Das Volk jubelt! Aber Sanktionen folgen sofort!");
                p.EinflussMilitär += 40;
                p.LoyalitätVolk += 30;
                p.EinflussInternational -= 50;
                p.Geld -= 700;
                Console.WriteLine($"➕ Militär: +40 → {p.EinflussMilitär}");
                Console.WriteLine($"➕ Volk: +30% → {p.LoyalitätVolk}%");
                Console.WriteLine($"➖ International: -50 → {p.EinflussInternational}");
                Thread.Sleep(4500);
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "MH17 über Ukraine abgeschossen 2014",
            "298 UNSCHULDIGE STERBEN! Eine malaysische Boeing wird über der Ostukraine abgeschossen - alle tot. Beweise zeigen: russische BUK-Rakete. Flad leugnet alles, zeigt auf Ukraine. Das Volk glaubt der Propaganda - oder schweigt. Die Familien der Opfer fordern Gerechtigkeit. Russland blockiert alles.",
            "Präsident", 100, 2014, "katastrophe",
            p => {
                Console.WriteLine("\n✈️💥 MH17 ABGESCHOSSEN - 298 TOTE!");
                Console.WriteLine("Russland wird beschuldigt! Das Volk ist verwirrt!");
                p.EinflussInternational -= 40;
                p.LoyalitätVolk -= 20;
                p.Gesundheit -= 15;
                p.Geld -= 300;
                Console.WriteLine($"➖ International: -40 → {p.EinflussInternational}");
                Console.WriteLine($"➖ Volk: -20% → {p.LoyalitätVolk}%");
                Console.WriteLine($"➖ Gesundheit: -15% → {p.Gesundheit}%");
                Thread.Sleep(4500);
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Rubel-Kollaps 2014",
            "SCHWARZER DEZEMBER! Der Rubel verliert 50% seines Wertes in Wochen. Sanktionen und Ölpreisverfall treffen brutal. Das Volk stürmt Geschäfte, kauft panisch Elektronik und Autos. Renten sind plötzlich wertlos. Alte Frauen weinen - schon wieder alles verloren, wie 1998, wie 1991. Die Erinnerung an Zusammenbrüche brennt.",
            "Präsident", 100, 2014, "katastrophe",
            p => {
                Console.WriteLine("\n💸 RUBEL-KOLLAPS - WÄHRUNG IM FREIEN FALL!");
                Console.WriteLine("Das Volk verliert alles! Panik und Wut überall!");
                p.Geld -= 800;
                p.LoyalitätVolk -= 40;
                p.Gesundheit -= 25;
                p.LoyalitätPartei -= 20;
                Console.WriteLine($"💰 Verlust: -800 Rubel → {p.Geld}");
                Console.WriteLine($"➖ Volk: -40% → {p.LoyalitätVolk}%");
                Console.WriteLine($"➖ Gesundheit: -25% → {p.Gesundheit}%");
                Thread.Sleep(4500);
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Boris Nemzow ermordet 2015",
            "OPPOSITIONSFÜHRER VOR DEM KREML ERSCHOSSEN! Boris Nemzow stirbt in Sichtweite des Kremls - 4 Kugeln in den Rücken. Das Volk ist schockiert: Selbst in Moskau ist niemand sicher. Die Täter werden schnell gefasst - Tschetschenen. Doch wer gab den Auftrag? Die Frage darf nicht gestellt werden.",
            "Präsident", 100, 2015, "katastrophe",
            p => {
                Console.WriteLine("\n🔫 NEMZOW ERMORDET - TERROR IM ZENTRUM!");
                Console.WriteLine("Kreml-Kritiker tot! Das Volk versteht die Botschaft!");
                p.EinflussKGB += 25;
                p.LoyalitätVolk -= 30;
                p.EinflussInternational -= 30;
                p.Gesundheit -= 15;
                Console.WriteLine($"➕ KGB/FSB: +25 → {p.EinflussKGB}");
                Console.WriteLine($"➖ Volk: -30% → {p.LoyalitätVolk}%");
                Console.WriteLine($"➖ International: -30 → {p.EinflussInternational}");
                Thread.Sleep(4500);
            }
        ));
        
        // 2016-2020 - Trump-Ära & Corona
        allEvents.Add(new RandomEvent(
            "Donald Trump gewählt 2016",
            "CHAOS IM WEISSEN HAUS! Donald Trump wird US-Präsident - ein Geschenk für Flad. Die Propaganda jubelt: 'Amerikas Niedergang hat begonnen!' Das Volk hofft auf Entspannung. Trump lobt Flad öffentlich. Die Beziehungen könnten sich verbessern - doch der Deep State lauert bereits.",
            "Präsident", 100, 2016, "politisch",
            p => {
                Console.WriteLine("\n🇺🇸 TRUMP GEWINNT - NEUE ÄRA?");
                Console.WriteLine("Flad hofft auf bessere Beziehungen! Das Volk ist optimistisch!");
                p.USABeziehung += 30;
                p.LoyalitätVolk += 15;
                p.Geld += 200;
                p.EinflussInternational += 20;
                Console.WriteLine($"➕ USA-Beziehung: +30 → {p.USABeziehung}");
                Console.WriteLine($"➕ Volk: +15% → {p.LoyalitätVolk}%");
                Console.WriteLine($"💰 Geld: +200 Rubel → {p.Geld}");
                Thread.Sleep(4000);
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Syrien-Intervention 2016",
            "RUSSISCHE BOMBER ÜBER ALEPPO! Flad rettet Assad - Fassbomben und Luftschläge verwandeln Städte in Trümmerwüsten. Das Volk sieht die Militärparaden im Fernsehen: Russland ist wieder eine Weltmacht! Der Preis? Tausende tote Zivilisten. 'Kollateralschaden', sagt das Militär. Die Wahrheit ertrinkt in Propaganda.",
            "Präsident", 100, 2016, "politisch",
            p => {
                Console.WriteLine("\n💣 SYRIEN - RUSSLAND GREIFT EIN!");
                Console.WriteLine("Assad gerettet! Das Volk feiert militärische Stärke!");
                p.EinflussMilitär += 35;
                p.Geld -= 600;
                p.LoyalitätVolk += 20;
                p.EinflussInternational -= 30;
                Console.WriteLine($"➕ Militär: +35 → {p.EinflussMilitär}");
                Console.WriteLine($"💰 Kosten: -600 Rubel → {p.Geld}");
                Console.WriteLine($"➕ Volk: +20% → {p.LoyalitätVolk}%");
                Thread.Sleep(4000);
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Doping-Skandal Olympia 2016",
            "STAATLICHES DOPING AUFGEDECKT! Whistleblower Rodtschenkow enthüllt: Russland hat jahrelang systematisch gedopt. Die Olympia-Mannschaft wird gesperrt. Das Volk ist empört - nicht über das Doping, sondern dass Russland erwischt wurde. 'Alle dopen doch', ist der Konsens. Nationalstolz > Fairness.",
            "Präsident", 100, 2016, "katastrophe",
            p => {
                Console.WriteLine("\n💉 DOPING-SKANDAL - RUSSLAND GESPERRT!");
                Console.WriteLine("Das Volk ist wütend auf den Westen, nicht auf die Betrüger!");
                p.EinflussInternational -= 35;
                p.LoyalitätVolk -= 20;
                p.Gesundheit -= 10;
                p.LoyalitätPartei += 15;
                Console.WriteLine($"➖ International: -35 → {p.EinflussInternational}");
                Console.WriteLine($"➖ Volk: -20% → {p.LoyalitätVolk}%");
                Console.WriteLine($"➕ Partei: +15% (Nationalismus steigt)");
                Thread.Sleep(4000);
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "St. Petersburg Metro-Anschlag 2017",
            "TERROR IN DER U-BAHN! Eine Bombe reißt 15 Menschen in den Tod, 50 weitere werden verletzt. Der Täter: ein Kirgise mit Verbindungen zum IS. Das Volk trauert - und fragt: Warum schützt uns der allmächtige FSB nicht? Flad verspricht Härte. Die Überwachung wird noch brutaler.",
            "Präsident", 100, 2017, "katastrophe",
            p => {
                Console.WriteLine("\n💣 METRO-ANSCHLAG - 15 TOTE!");
                Console.WriteLine("Terror in St. Petersburg! Das Volk fordert Sicherheit!");
                p.Gesundheit -= 20;
                p.LoyalitätVolk -= 25;
                p.EinflussKGB += 25;
                p.Geld -= 200;
                Console.WriteLine($"➖ Gesundheit: -20% → {p.Gesundheit}%");
                Console.WriteLine($"➖ Volk: -25% → {p.LoyalitätVolk}%");
                Console.WriteLine($"➕ KGB/FSB: +25 → {p.EinflussKGB}");
                Thread.Sleep(4000);
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "WM 2018 Russland",
            "DIE WELT ZU GAST BEI FREUNDEN? Millionen Touristen strömen nach Russland. Moskau putzt sich heraus. Das Volk genießt die Party - eine Woche lang sind sie stolz. Die Mannschaft erreicht das Viertelfinale! Doch nach der WM kehrt die graue Realität zurück: Steigende Preise, sinkende Renten.",
            "Präsident", 100, 2018, "politisch",
            p => {
                Console.WriteLine("\n⚽ WM 2018 - RUSSLAND FEIERT!");
                Console.WriteLine("Das Volk ist glücklich! Aber nur kurz...");
                p.LoyalitätVolk += 25;
                p.EinflussInternational += 30;
                p.Geld -= 800;
                p.Gesundheit += 10;
                Console.WriteLine($"➕ Volk: +25% → {p.LoyalitätVolk}%");
                Console.WriteLine($"➕ International: +30 → {p.EinflussInternational}");
                Console.WriteLine($"💰 Kosten: -800 Rubel → {p.Geld}");
                Thread.Sleep(4000);
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Rentenreform 2018",
            "FLAD STIEHLT DIE RENTEN! Das Rentenalter wird drastisch erhöht - Männer auf 65, Frauen auf 60. Das Volk ist außer sich! Proteste überall. Flad versteckt sich, lässt Medwedew die Nachricht verkünden. Seine Beliebtheit stürzt ab. Das Vertrauen ist gebrochen. Selbst Loyalisten sind entsetzt.",
            "Präsident", 100, 2018, "katastrophe",
            p => {
                Console.WriteLine("\n👴 RENTENREFORM - DAS VOLK REBELLIERT!");
                Console.WriteLine("Rentenalter erhöht! Massiver Vertrauensverlust!");
                p.LoyalitätVolk -= 45;
                p.Gesundheit -= 20;
                p.Geld += 300;
                p.LoyalitätPartei -= 25;
                Console.WriteLine($"➖ Volk: -45% → {p.LoyalitätVolk}%");
                Console.WriteLine($"➖ Gesundheit: -20% → {p.Gesundheit}%");
                Console.WriteLine($"➖ Partei: -25% → {p.LoyalitätPartei}%");
                Thread.Sleep(4500);
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Skripal-Vergiftung UK 2018",
            "NOWITSCHOK IN SALISBURY! Der Ex-Spion Sergei Skripal wird mit Nervengas vergiftet - auf britischem Boden! Die Spuren führen direkt zum GRU. Massiver diplomatischer Eklat: 150 russische Diplomaten werden ausgewiesen. Das Volk glaubt der Propaganda: 'Alles eine Lüge! Die Briten haben sich selbst vergiftet!'",
            "Präsident", 100, 2018, "katastrophe",
            p => {
                Console.WriteLine("\n☠️ SKRIPAL-AFFÄRE - DIPLOMATISCHES DESASTER!");
                Console.WriteLine("Massenausweisung russischer Diplomaten! Das Volk leugnet alles!");
                p.EinflussInternational -= 40;
                p.EinflussKGB += 20;
                p.LoyalitätVolk += 10;
                p.Geld -= 200;
                Console.WriteLine($"➖ International: -40 → {p.EinflussInternational}");
                Console.WriteLine($"➕ KGB/FSB: +20 → {p.EinflussKGB}");
                Console.WriteLine($"➕ Volk: +10% (Nationalismus)");
                Thread.Sleep(4500);
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Corona-Pandemie Russland 2020",
            "DAS UNSICHTBARE VIRUS! COVID-19 erreicht Russland. Flad versteckt sich monatelang in seiner Residenz. Ärzte sterben zu Dutzenden - manche 'fallen' aus Fenstern, nachdem sie kritisierten. Das Volk stirbt, während die Propaganda von 'Sputnik V' schwärmt. Die offiziellen Zahlen sind Lügen. Jeder kennt Tote.",
            "Präsident", 100, 2020, "katastrophe",
            p => {
                Console.WriteLine("\n🦠 CORONA TRIFFT RUSSLAND!");
                Console.WriteLine("Offiziell 'unter Kontrolle', inoffiziell: Katastrophe! Das Volk leidet!");
                p.Gesundheit -= 35;
                p.LoyalitätVolk -= 30;
                p.Geld -= 500;
                p.LoyalitätPartei -= 20;
                Console.WriteLine($"➖ Gesundheit: -35% → {p.Gesundheit}%");
                Console.WriteLine($"➖ Volk: -30% → {p.LoyalitätVolk}%");
                Console.WriteLine($"💰 Verlust: -500 Rubel → {p.Geld}");
                Thread.Sleep(4500);
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Nawalny vergiftet 2020",
            "DER AUFRECHTE WIRD NIEDERGESTRECKT! Alexei Nawalny kollabiert im Flugzeug - Nowitschok im Blut. Er überlebt knapp in Deutschland. Flad leugnet alles. Das Volk ist gespalten: Manche nennen ihn Held, andere Landesverräter. Als Nawalny zurückkehrt, wird er sofort verhaftet. Der Mut hat seinen Preis.",
            "Präsident", 100, 2020, "katastrophe",
            p => {
                Console.WriteLine("\n☠️ NAWALNY VERGIFTET - ÜBERLEBT KNAPP!");
                Console.WriteLine("Kreml-Kritiker fast getötet! Das Volk ist tief gespalten!");
                p.EinflussInternational -= 35;
                p.LoyalitätVolk -= 25;
                p.EinflussKGB += 25;
                p.Gesundheit -= 15;
                Console.WriteLine($"➖ International: -35 → {p.EinflussInternational}");
                Console.WriteLine($"➖ Volk: -25% → {p.LoyalitätVolk}%");
                Console.WriteLine($"➕ KGB/FSB: +25 → {p.EinflussKGB}");
                Thread.Sleep(4500);
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Nawalny verhaftet 2021",
            "RÜCKKEHR IN DIE HÖLLE! Nawalny landet in Moskau - und wird am Gate verhaftet. Hunderttausende protestieren landesweit. Die Polizei schlägt brutal zu: 11.000 Festnahmen. Das Volk sieht die Brutalität live auf YouTube. Flad hat entschieden: Keine Opposition mehr. Die Schrauben werden angezogen bis zum Anschlag.",
            "Präsident", 100, 2021, "katastrophe",
            p => {
                Console.WriteLine("\n⛓️ NAWALNY VERHAFTET - MASSENPROTESTE!");
                Console.WriteLine("11.000 Festnahmen! Das Volk sieht die Brutalität!");
                p.LoyalitätVolk -= 40;
                p.EinflussKGB += 30;
                p.EinflussInternational -= 30;
                p.Gesundheit -= 20;
                Console.WriteLine($"➖ Volk: -40% → {p.LoyalitätVolk}%");
                Console.WriteLine($"➕ KGB/FSB: +30 → {p.EinflussKGB}");
                Console.WriteLine($"➖ International: -30 → {p.EinflussInternational}");
                Thread.Sleep(4500);
            }
        ));
        
        // 2022-2025 - Ukraine-Krieg
        allEvents.Add(new RandomEvent(
            "Invasion Ukraine 2022",
            "KRIEG IN EUROPA! 24. Februar, 04:00 Uhr - Raketen hageln auf Kiew. 200.000 russische Soldaten überqueren die Grenze. Flad nennt es 'Spezialoperation'. Das Volk glaubt der Propaganda: 'Wir befreien die Ukraine von Nazis!' Doch bald kommen die Zinksärge zurück. Mütter weinen, der Kreml schweigt.",
            "Präsident", 100, 2022, "katastrophe",
            p => {
                Console.WriteLine("\n💥 UKRAINE-KRIEG BEGINNT!");
                Console.WriteLine("Russland marschiert ein! Das Volk ist gespalten zwischen Propaganda und Realität!");
                p.EinflussMilitär += 40;
                p.Geld -= 1500;
                p.LoyalitätVolk -= 35;
                p.EinflussInternational -= 60;
                Console.WriteLine($"➕ Militär: +40 → {p.EinflussMilitär}");
                Console.WriteLine($"💰 Kriegskosten: -1500 Rubel → {p.Geld}");
                Console.WriteLine($"➖ Volk: -35% → {p.LoyalitätVolk}%");
                Thread.Sleep(5000);
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Butscha-Massaker 2022",
            "GRÄUEL IN DER VORSTADT! Als russische Truppen Butscha verlassen, finden Ukrainer Hunderte ermordete Zivilisten - gefoltert, hingerichtet. Die Bilder schockieren die Welt. Russland leugnet alles: 'Alles inszeniert!' Das Volk glaubt der Lüge - oder will sie glauben. Die Wahrheit ist zu schmerzhaft.",
            "Präsident", 100, 2022, "katastrophe",
            p => {
                Console.WriteLine("\n💀 BUTSCHA - KRIEGSVERBRECHEN AUFGEDECKT!");
                Console.WriteLine("Die Welt ist entsetzt! Das Volk leugnet oder schweigt!");
                p.EinflussInternational -= 50;
                p.LoyalitätVolk -= 30;
                p.Gesundheit -= 25;
                p.EinflussMilitär -= 20;
                Console.WriteLine($"➖ International: -50 → {p.EinflussInternational}");
                Console.WriteLine($"➖ Volk: -30% → {p.LoyalitätVolk}%");
                Console.WriteLine($"➖ Gesundheit: -25% → {p.Gesundheit}%");
                Thread.Sleep(4500);
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Mobilmachung 2022",
            "ALLE MÄNNER AN DIE FRONT! Flad verkündet 'Teilmobilmachung' - 300.000 Reservisten werden eingezogen. Panik bricht aus! Männer fliehen über die Grenzen, Flugtickets kosten Tausende. Das Volk realisiert: Der Krieg ist real. Frauen weinen auf Bahnhöfen. Der Staat jagt Wehrpflichtige wie Wild.",
            "Präsident", 100, 2022, "katastrophe",
            p => {
                Console.WriteLine("\n🪖 MOBILMACHUNG - PANIK UND FLUCHT!");
                Console.WriteLine("300.000 an die Front! Männer fliehen! Das Volk ist in Panik!");
                p.EinflussMilitär += 30;
                p.LoyalitätVolk -= 50;
                p.Geld -= 800;
                p.Gesundheit -= 30;
                Console.WriteLine($"➕ Militär: +30 → {p.EinflussMilitär}");
                Console.WriteLine($"➖ Volk: -50% → {p.LoyalitätVolk}%");
                Console.WriteLine($"➖ Gesundheit: -30% → {p.Gesundheit}%");
                Thread.Sleep(5000);
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Prigoschin-Aufstand 2023",
            "WAGNERS MARSCH AUF MOSKAU! Jewgeni Prigoschin, der Chef der Wagner-Söldner, rebelliert! Seine Armee marschiert auf Moskau zu. Flad flieht. 24 Stunden purer Wahnsinn. Dann: Deal. Prigoschin dreht um. Das Volk ist geschockt - wie schwach ist Flad wirklich? 2 Monate später: Prigoschins Jet explodiert.",
            "Präsident", 100, 2023, "katastrophe",
            p => {
                Console.WriteLine("\n⚔️ WAGNER-AUFSTAND - PUTIN WACKELT!");
                Console.WriteLine("Beinahe-Putsch! Das Volk sieht Flads Schwäche!");
                p.EinflussMilitär -= 40;
                p.LoyalitätVolk -= 45;
                p.LoyalitätPartei -= 30;
                p.Gesundheit -= 35;
                Console.WriteLine($"➖ Militär: -40 → {p.EinflussMilitär}");
                Console.WriteLine($"➖ Volk: -45% → {p.LoyalitätVolk}%");
                Console.WriteLine($"➖ Partei: -30% → {p.LoyalitätPartei}%");
                Thread.Sleep(5000);
            }
        ));
        
        // DUPLIKAT ENTFERNT: Nawalny Tod 2024 ist bereits als HistoricalEvent vorhanden
        
        // ═══════════════════════════════════════════════════════════════════
        // WEITERE EVENTS FÜR UNTERVERSORGTE JAHRE (1953, 1956-1961, etc.)
        // ═══════════════════════════════════════════════════════════════════
        
        // 1953 - 2 zusätzliche Events
        allEvents.Add(new RandomEvent(
            "Beria-Hinrichtung 1953",
            "DER HENKER WIRD GEHÄNGT! Lawrenti Beria, Stalins Geheimdienstchef und Massenm&ouml;rder, wird verhaftet und hingerichtet. Das Volk jubelt heimlich - endlich wird einer der Schlächter bestraft! Doch die Angst bleibt: Wer ist der nächste? Die Säuberungen hören nie auf, nur die Namen der Täter wechseln.",
            "Kindheit", 100, 1953, "politisch",
            p => {
                Console.WriteLine("\n⚖️ BERIA HINGERICHTET - GERECHTIGKEIT?");
                Console.WriteLine("Der Monster ist tot! Das Volk atmet erleichtert auf!");
                p.EinflussKGB -= 25;
                p.LoyalitätVolk += 20;
                p.Gesundheit += 10;
                p.LoyalitätPartei += 15;
                Console.WriteLine($"➖ KGB: -25 → {p.EinflussKGB}");
                Console.WriteLine($"➕ Volk: +20% → {p.LoyalitätVolk}%");
                Console.WriteLine($"➕ Gesundheit: +10% → {p.Gesundheit}%");
                Thread.Sleep(4000);
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Gulag-Entlassungen 1953",
            "DIE TODESLAGER ÖFFNEN SICH! Nach Stalins Tod werden Hunderttausende Häftlinge aus Gulags entlassen. Skelette kehren heim - kaum wiederzuerkennen. Das Volk ist schockiert: Was haben wir unserem eigenen Volk angetan? Familien werden wiedervereinigt. Tränen der Freude und der Schuld.",
            "Kindheit", 100, 1953, "politisch",
            p => {
                Console.WriteLine("\n⛓️ GULAG-HÄFTLINGE KEHREN HEIM!");
                Console.WriteLine("Hunderttausende freigelassen! Das Volk feiert und weint!");
                p.LoyalitätVolk += 30;
                p.Gesundheit += 15;
                p.LoyalitätPartei -= 15;
                p.Charisma += 1;
                Console.WriteLine($"➕ Volk: +30% → {p.LoyalitätVolk}%");
                Console.WriteLine($"➕ Gesundheit: +15% → {p.Gesundheit}%");
                Console.WriteLine($"➖ Partei: -15% → {p.LoyalitätPartei}%");
                Thread.Sleep(4000);
            }
        ));
        
        // 1956 - 3 zusätzliche Events
        allEvents.Add(new RandomEvent(
            "Elvis Presley Phänomen 1956",
            "WESTLICHE DEKADENZ VERFÜHRT DIE JUGEND! Elvis Presley erobert den Westen - seine Musik sickert heimlich in die Sowjetunion. Jugendliche hören verbotene Platten, tanzen Rock'n'Roll in Kellern. Das Volk ist gespalten: Die Alten sind empört, die Jungen rebellieren. Der eiserne Vorhang kann Musik nicht aufhalten.",
            "Kindheit", 100, 1956, "politisch",
            p => {
                Console.WriteLine("\n🎸 ROCK'N'ROLL ERREICHT SOWJETUNION!");
                Console.WriteLine("Jugend rebelliert heimlich! Das Volk ist gespalten!");
                p.LoyalitätPartei -= 20;
                p.LoyalitätVolk -= 10;
                p.Charisma += 1;
                p.Intelligenz += 1;
                Console.WriteLine($"➖ Partei: -20% → {p.LoyalitätPartei}%");
                Console.WriteLine($"➕ Charisma: +1 (kulturelle Bildung)");
                Thread.Sleep(4000);
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Suez-Krise 1956",
            "WELTMÄCHTE AM RANDE DES KRIEGES! Großbritannien, Frankreich und Israel greifen Ägypten an. Die USA und UdSSR - zum ersten Mal vereint - zwingen sie zum Rückzug. Das Volk feiert: Sowjetmacht rettet die Welt! Der Kolonialismus stirbt, ein neues Zeitalter beginnt.",
            "Kindheit", 100, 1956, "politisch",
            p => {
                Console.WriteLine("\n🌍 SUEZ-KRISE - SOWJETISCHE DIPLOMATIE!");
                Console.WriteLine("UdSSR zwingt Kolonialisten zum Rückzug! Das Volk ist stolz!");
                p.EinflussInternational += 30;
                p.LoyalitätVolk += 20;
                p.Geld += 150;
                p.Charisma += 1;
                Console.WriteLine($"➕ International: +30 → {p.EinflussInternational}");
                Console.WriteLine($"➕ Volk: +20% → {p.LoyalitätVolk}%");
                Thread.Sleep(4000);
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "XX. Parteitag Entstalinisierung 1956",
            "CHRUSCHTSCHOWS DONNERSCHLAG! In geheimer Rede prangert Chruschtschow Stalin als Massenmörder an. Das Volk erfährt es über Flüsterpost: Stalin war kein Gott, sondern ein Monster! Alles war Lüge! Die Grundfesten der sowjetischen Ideologie wanken. Manche sind befreit, andere fühlen sich betrogen.",
            "Kindheit", 100, 1956, "politisch",
            p => {
                Console.WriteLine("\n🗣️ GEHEIMREDE ERSCHÜTTERT DIE UdSSR!");
                Console.WriteLine("Stalin entlarvt! Das Volk ist erschüttert und befreit!");
                p.LoyalitätPartei -= 30;
                p.LoyalitätVolk += 25;
                p.Intelligenz += 2;
                p.Gesundheit += 10;
                Console.WriteLine($"➖ Partei: -30% → {p.LoyalitätPartei}%");
                Console.WriteLine($"➕ Volk: +25% → {p.LoyalitätVolk}%");
                Console.WriteLine($"➕ Intelligenz: +2 (Wahrheit entdeckt)");
                Thread.Sleep(4000);
            }
        ));
        
        // 1957 - 2 zusätzliche Events
        allEvents.Add(new RandomEvent(
            "Anti-Partei-Gruppe 1957",
            "INTRIGEN IM KREML! Malenkow, Molotow und Kaganowitsch versuchen Chruschtschow zu stürzen. Der Machtkampf tobt im Schatten. Chruschtschow gewinnt - die Verschwörer werden verbannt, nicht ermordet. Das Volk merkt: Die Zeit der Massenerschießungen ist vorbei. Jetzt reicht Verbannung.",
            "Kindheit", 100, 1957, "politisch",
            p => {
                Console.WriteLine("\n⚔️ MACHTKAMPF IM KREML!");
                Console.WriteLine("Chruschtschow siegt! Das Volk bemerkt: Weniger Blut!");
                p.LoyalitätPartei += 15;
                p.LoyalitätVolk += 10;
                p.EinflussKGB -= 10;
                p.Intelligenz += 1;
                Console.WriteLine($"➕ Partei: +15% → {p.LoyalitätPartei}%");
                Console.WriteLine($"➖ KGB: -10 → {p.EinflussKGB}");
                Thread.Sleep(4000);
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Laika im Weltraum 1957",
            "DIE HÜNDIN DER HOFFNUNG! Laika, ein Straßenhund aus Moskau, wird ins All geschossen - das erste Lebewesen im Orbit. Das Volk liebt Laika wie ein nationales Symbol. Doch niemand sagt die Wahrheit: Sie stirbt nach Stunden an Überhitzung. Der Triumph hat einen tödlichen Preis.",
            "Kindheit", 100, 1957, "politisch",
            p => {
                Console.WriteLine("\n🐕 LAIKA - HÜNDIN IM WELTRAUM!");
                Console.WriteLine("Das Volk feiert! Aber die Wahrheit wird verschwiegen...");
                p.EinflussInternational += 25;
                p.LoyalitätVolk += 20;
                p.Gesundheit -= 5;
                p.Geld += 100;
                Console.WriteLine($"➕ International: +25 → {p.EinflussInternational}");
                Console.WriteLine($"➕ Volk: +20% → {p.LoyalitätVolk}%");
                Thread.Sleep(4000);
            }
        ));
        
        // 1958 - 3 zusätzliche Events
        allEvents.Add(new RandomEvent(
            "Pasternak Nobelpreis 1958",
            "LITERATUR-SKANDAL! Boris Pasternak erhält den Nobelpreis für 'Doktor Schiwago' - im Westen gefeiert, in der UdSSR verboten. Das Volk liest heimlich Samisdat-Kopien. Die Partei zwingt Pasternak zur Ablehnung. Das Volk sieht die Heuchelei: Der weltbeste russische Autor darf nicht gefeiert werden.",
            "Kindheit", 100, 1958, "politisch",
            p => {
                Console.WriteLine("\n📚 PASTERNAK-SKANDAL!");
                Console.WriteLine("Nobelpreis abgelehnt! Das Volk liest heimlich!");
                p.Intelligenz += 2;
                p.LoyalitätPartei -= 20;
                p.LoyalitätVolk -= 15;
                p.Charisma += 1;
                Console.WriteLine($"➕ Intelligenz: +2 (verbotene Literatur)");
                Console.WriteLine($"➖ Partei: -20% → {p.LoyalitätPartei}%");
                Thread.Sleep(4000);
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "China-Indien-Grenzkonflikt 1958",
            "KOMMUNISTISCHE BRÜDER ZERSTREITEN SICH! China und Indien geraten aneinander - die UdSSR ist hin- und hergerissen. Das Volk versteht nicht: Sind wir nicht alle Genossen? Die Sino-Sowjetische Spaltung beginnt schleichend. Die kommunistische Einheit ist eine Illusion.",
            "Kindheit", 100, 1958, "politisch",
            p => {
                Console.WriteLine("\n🇨🇳🇮🇳 KOMMUNISTISCHE ZWIETRACHT!");
                Console.WriteLine("China und UdSSR entfremden sich! Das Volk ist verwirrt!");
                p.ChinaBeziehung -= 15;
                p.LoyalitätVolk -= 10;
                p.EinflussInternational -= 10;
                p.Intelligenz += 1;
                Console.WriteLine($"➖ China: -15 → {p.ChinaBeziehung}");
                Console.WriteLine($"➖ Volk: -10% → {p.LoyalitätVolk}%");
                Thread.Sleep(4000);
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Kornkampagne Fiasko 1958",
            "CHRUSCHTSCHOWS WAHN! 'Wir überholen Amerika beim Mais!' verkündet der Führer. Mais wird überall gepflanzt - selbst in Sibirien, wo er nicht wächst. Das Volk hungert, während Mais auf den Feldern verfault. Die grandiose Idee wird zur Farce. Das Volk lernt: Ideologie füllt keine Mägen.",
            "Kindheit", 100, 1958, "katastrophe",
            p => {
                Console.WriteLine("\n🌽 MAIS-KAMPAGNE SCHEITERT!");
                Console.WriteLine("Felder voller totem Mais! Das Volk hungert!");
                p.Geld -= 200;
                p.LoyalitätVolk -= 25;
                p.Gesundheit -= 15;
                p.LoyalitätPartei -= 15;
                Console.WriteLine($"💰 Verlust: -200 Rubel → {p.Geld}");
                Console.WriteLine($"➖ Volk: -25% → {p.LoyalitätVolk}%");
                Thread.Sleep(4000);
            }
        ));
        
        // 1959 - 3 zusätzliche Events
        allEvents.Add(new RandomEvent(
            "Chruschtschow USA-Besuch 1959",
            "DER KREML-CHEF IN AMERIKA! Chruschtschow besucht die USA - erste Visite eines sowjetischen Führers. Er besucht Hollywood, streitet mit Nixon in einer Küche, will Disneyland sehen (Sicherheit verbietet es). Das Volk ist fasziniert: Amerika ist nicht nur der Feind. Die Entspannung riecht nach Hoffnung.",
            "Kindheit", 100, 1959, "politisch",
            p => {
                Console.WriteLine("\n🇺🇸 CHRUSCHTSCHOW IN AMERIKA!");
                Console.WriteLine("Das Volk staunt über Annäherung!");
                p.USABeziehung += 30;
                p.LoyalitätVolk += 15;
                p.EinflussInternational += 20;
                p.Charisma += 1;
                Console.WriteLine($"➕ USA: +30 → {p.USABeziehung}");
                Console.WriteLine($"➕ Volk: +15% → {p.LoyalitätVolk}%");
                Thread.Sleep(4000);
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Luna 2 trifft Mond 1959",
            "DER MOND GEHÖRT UNS! Luna 2 schlägt auf dem Mond ein - erstes menschgemachtes Objekt auf einem anderen Himmelskörper! Das Volk jubelt vor Radios: Wir sind überlegen! Amerika hinkt hinterher! Der Kosmos ist rot! Die Sowjet-Propaganda feiert den größten Triumph seit Jahren.",
            "Kindheit", 100, 1959, "politisch",
            p => {
                Console.WriteLine("\n🌙 LUNA 2 AUF DEM MOND!");
                Console.WriteLine("Sowjetische Fahne auf dem Mond! Das Volk ist euphorisch!");
                p.EinflussInternational += 35;
                p.LoyalitätVolk += 25;
                p.Geld += 150;
                p.Intelligenz += 1;
                Console.WriteLine($"➕ International: +35 → {p.EinflussInternational}");
                Console.WriteLine($"➕ Volk: +25% → {p.LoyalitätVolk}%");
                Thread.Sleep(4000);
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Sieben-Jahres-Plan 1959",
            "NEUE VERSPRECHUNGEN, ALTE LÜGEN! Chruschtschow verkündet einen ambitionierten Wirtschaftsplan: 'Kommunismus in 20 Jahren!' Das Volk will glauben, ist aber skeptisch. Sie haben schon so viele Pläne scheitern sehen. Die Schlangen vor Läden werden länger, nicht kürzer. Realität und Propaganda driften auseinander.",
            "Kindheit", 100, 1959, "politisch",
            p => {
                Console.WriteLine("\n📊 NEUER WIRTSCHAFTSPLAN VERKÜNDET!");
                Console.WriteLine("Große Versprechen! Das Volk ist skeptisch!");
                p.Geld += 100;
                p.LoyalitätVolk -= 10;
                p.LoyalitätPartei += 15;
                p.Gesundheit -= 5;
                Console.WriteLine($"💰 Geld: +100 Rubel → {p.Geld}");
                Console.WriteLine($"➖ Volk: -10% → {p.LoyalitätVolk}%");
                Thread.Sleep(4000);
            }
        ));
        
        // 1960 - 3 zusätzliche Events
        allEvents.Add(new RandomEvent(
            "Belka und Strelka zurück 1960",
            "DIE HÜNDINNEN KEHREN HEIM! Im Gegensatz zu Laika überleben Belka und Strelka ihren Raumflug - erstes Lebewesen, das aus dem Orbit zurückkehrt! Das Volk feiert die beiden Heldinnen. Kinder wollen Belka-und-Strelka-Spielzeug. Der Weltraum-Triumph überdeckt die Armut auf der Erde.",
            "Kindheit", 100, 1960, "politisch",
            p => {
                Console.WriteLine("\n🐕🐕 BELKA UND STRELKA - LEBEND ZURÜCK!");
                Console.WriteLine("Das Volk jubelt! Nationale Helden auf vier Pfoten!");
                p.EinflussInternational += 25;
                p.LoyalitätVolk += 20;
                p.Gesundheit += 10;
                p.Charisma += 1;
                Console.WriteLine($"➕ International: +25 → {p.EinflussInternational}");
                Console.WriteLine($"➕ Volk: +20% → {p.LoyalitätVolk}%");
                Thread.Sleep(4000);
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Francis Gary Powers Prozess 1960",
            "DER SPY IM KÄFIG! Der abgeschossene U-2-Pilot wird in Moskau vor Gericht gestellt. Millionen sehen den Prozess - Beweis für amerikanische Spionage! Das Volk fühlt sich bestätigt: Der Westen ist der Feind! Powers bekommt 10 Jahre, wird aber 1962 gegen einen sowjetischen Spion getauscht.",
            "Kindheit", 100, 1960, "politisch",
            p => {
                Console.WriteLine("\n⚖️ POWERS-PROZESS - PROPAGANDA-TRIUMPH!");
                Console.WriteLine("Amerikanischer Spion verurteilt! Das Volk ist empört!");
                p.EinflussKGB += 20;
                p.LoyalitätVolk += 15;
                p.USABeziehung -= 20;
                p.Geld += 100;
                Console.WriteLine($"➕ KGB: +20 → {p.EinflussKGB}");
                Console.WriteLine($"➕ Volk: +15% → {p.LoyalitätVolk}%");
                Thread.Sleep(4000);
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Kongo-Krise UdSSR involviert 1960",
            "KALTER KRIEG IN AFRIKA! Nach der belgischen Dekolonisierung tobt ein Bürgerkrieg im Kongo. Die UdSSR unterstützt Lumumba, die USA Mobutu. Das Volk fragt: Warum kämpfen wir in Afrika, während wir hier hungern? Die globale Machtprojektion kostet Milliarden.",
            "Kindheit", 100, 1960, "politisch",
            p => {
                Console.WriteLine("\n🌍 KONGO-KRISE - KALTER KRIEG GLOBAL!");
                Console.WriteLine("UdSSR kämpft in Afrika! Das Volk versteht es nicht!");
                p.EinflussInternational += 15;
                p.Geld -= 250;
                p.LoyalitätVolk -= 15;
                p.EinflussMilitär += 10;
                Console.WriteLine($"➕ International: +15 → {p.EinflussInternational}");
                Console.WriteLine($"💰 Kosten: -250 Rubel → {p.Geld}");
                Thread.Sleep(4000);
            }
        ));
        
        // 1961 - 3 zusätzliche Events
        allEvents.Add(new RandomEvent(
            "Titow 24 Stunden im All 1961",
            "MARATHON IM ORBIT! Gherman Titow umkreist die Erde 17 Mal in 25 Stunden - Rekord! Das Volk ist stolz: Während Amerika 15-Minuten-Hüpfer macht, leben wir einen Tag im Weltraum! Der Weltraum-Wettlauf geht klar an die UdSSR. Amerika ist demütig geschlagen.",
            "Jugend", 100, 1961, "politisch",
            p => {
                Console.WriteLine("\n🚀 TITOW - 24 STUNDEN IM ORBIT!");
                Console.WriteLine("Neuer Rekord! Das Volk feiert sowjetische Überlegenheit!");
                p.EinflussInternational += 30;
                p.LoyalitätVolk += 20;
                p.Geld += 150;
                p.Intelligenz += 1;
                Console.WriteLine($"➕ International: +30 → {p.EinflussInternational}");
                Console.WriteLine($"➕ Volk: +20% → {p.LoyalitätVolk}%");
                Thread.Sleep(4000);
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Währungsreform Rubel 1961",
            "GELD WIRD NEU GEDRUCKT! Die alte Währung wird 10:1 umgetauscht. Das Volk steht in endlosen Schlangen vor Banken. Manche verlieren ihre Ersparnisse, wenn sie zu spät kommen. 'Reform' nennt es die Partei - 'Diebstahl' flüstert das Volk. Vertrauen in die Wirtschaft schwindet weiter.",
            "Jugend", 100, 1961, "katastrophe",
            p => {
                Console.WriteLine("\n💰 WÄHRUNGSREFORM - RUBEL ENTWERTET!");
                Console.WriteLine("10:1 Umtausch! Das Volk verliert Ersparnisse!");
                p.Geld -= 300;
                p.LoyalitätVolk -= 30;
                p.Gesundheit -= 10;
                p.LoyalitätPartei -= 20;
                Console.WriteLine($"💰 Verlust: -300 Rubel → {p.Geld}");
                Console.WriteLine($"➖ Volk: -30% → {p.LoyalitätVolk}%");
                Thread.Sleep(4000);
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Rudolf Nurejew defektiert 1961",
            "BALLET-STAR FLIEHT IN DEN WESTEN! Rudolf Nurejew, Sowjet-Ballettstar, bleibt in Paris und bittet um Asyl. Schock im Kreml! Das Volk ist gespalten: Manche nennen ihn Verräter, andere verstehen seinen Freiheitsdrang. Der Eiserne Vorhang kann selbst Künstler nicht halten.",
            "Jugend", 100, 1961, "politisch",
            p => {
                Console.WriteLine("\n🩰 NUREJEW DEFEKTIERT!");
                Console.WriteLine("Ballet-Star flieht! Das Volk ist schockiert!");
                p.EinflussInternational -= 20;
                p.LoyalitätVolk -= 15;
                p.Charisma += 1;
                p.LoyalitätPartei -= 15;
                Console.WriteLine($"➖ International: -20 → {p.EinflussInternational}");
                Console.WriteLine($"➖ Volk: -15% → {p.LoyalitätVolk}%");
                Thread.Sleep(4000);
            }
        ));
        
        // TELEFONATE ALS EVENTS - Integration der Hotlines
        allEvents.Add(new RandomEvent(
            "📞 KGB-ANRUF: Verdächtige Aktivität",
            "DAS ROTE TELEFON KLINGELT! Eine heisere Stimme vom KGB: 'Wir beobachten Sie. Ihre Loyalität wird geprüft.' Das Volk lebt in ständiger Angst vor diesen Anrufen. Ein falsches Wort am Telefon kann dein Leben zerstören. Big Brother hört immer zu.",
            "Präsident", 40, 0, "kgb-telefon",
            p => {
                Console.WriteLine("\n📞 KGB RUFT DICH AN!");
                Console.WriteLine("Das Volk fürchtet diese Anrufe...");
                p.Gesundheit -= 10;
                p.LoyalitätVolk -= 15;
                p.EinflussKGB += 10;
                Console.WriteLine($"➖ Gesundheit: -10% → {p.Gesundheit}%");
                Console.WriteLine($"➖ Volk: -15% → {p.LoyalitätVolk}%");
                Thread.Sleep(3000);
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "📞 INTERNATIONALE DIPLOMATIE-ANRUF",
            "DAS TELEFON KLINGELT! Weltführer rufen an - Deals, Drohungen, Diplomatie. Das Volk erfährt nur, was die Propaganda zulässt. Im Hintergrund wird die Weltpolitik am Telefon gemacht. Jedes Gespräch kann Krieg oder Frieden bedeuten.",
            "Präsident", 30, 0, "diplo-telefon",
            p => {
                Console.WriteLine("\n📞 DIPLOMATIE-ANRUF!");
                Console.WriteLine("Internationale Verhandlungen! Das Volk hofft auf Frieden!");
                int outcome = rand.Next(3);
                if (outcome == 0)
                {
                    p.EinflussInternational += 20;
                    p.LoyalitätVolk += 10;
                    Console.WriteLine("✓ Erfolgreiche Verhandlung!");
                    Console.WriteLine($"➕ International: +20 → {p.EinflussInternational}");
                }
                else if (outcome == 1)
                {
                    p.Geld += 200;
                    Console.WriteLine("✓ Lukrativer Deal abgeschlossen!");
                    Console.WriteLine($"💰 Geld: +200 Rubel → {p.Geld}");
                }
                else
                {
                    p.EinflussInternational -= 15;
                    p.LoyalitätVolk -= 10;
                    Console.WriteLine("✗ Verhandlungen gescheitert!");
                    Console.WriteLine($"➖ International: -15 → {p.EinflussInternational}");
                }
                Thread.Sleep(3000);
            }
        ));
        
        // LETZTE UNTERVERSORGTE JAHRE AUFFÜLLEN
        // 1986 - 1 zusätzliches Event
        allEvents.Add(new RandomEvent(
            "Gorbatschow verkündet Glasnost 1986",
            "TRANSPARENZ UND WAHRHEIT! Michail Gorbatschow verkündet 'Glasnost' - Offenheit! Die Presse darf kritisieren, das Volk darf reden. Nach 70 Jahren Lügen ein revolutionärer Schritt! Das Volk ist misstrauisch: Ist das eine Falle? Oder der Beginn echter Freiheit? Die Büchse der Pandora öffnet sich.",
            "Präsident", 100, 1986, "politisch",
            p => {
                Console.WriteLine("\n📰 GLASNOST - OFFENHEIT BEGINNT!");
                Console.WriteLine("Das Volk darf endlich die Wahrheit sprechen!");
                p.LoyalitätVolk += 30;
                p.LoyalitätPartei -= 20;
                p.Intelligenz += 2;
                p.Gesundheit += 15;
                Console.WriteLine($"➕ Volk: +30% → {p.LoyalitätVolk}%");
                Console.WriteLine($"➖ Partei: -20% → {p.LoyalitätPartei}%");
                Console.WriteLine($"➕ Intelligenz: +2 (Wahrheit befreit)");
                Thread.Sleep(4000);
            }
        ));
        
        // 1991 - 1 zusätzliches Event
        allEvents.Add(new RandomEvent(
            "Boris Jelzin auf dem Panzer 1991",
            "DER MANN AUF DEM PANZER! Hardliner putschen gegen Gorbatschow. Boris Jelzin klettert auf einen Panzer und ruft zum Widerstand! Das Volk strömt auf die Straßen - sie haben keine Angst mehr! Der Putsch scheitert nach drei Tagen. Die Sowjetunion hat nur noch Monate zu leben.",
            "Präsident", 100, 1991, "politisch",
            p => {
                Console.WriteLine("\n✊ JELZIN AUF DEM PANZER - DEMOKRATIE SIEGT!");
                Console.WriteLine("Der Putsch scheitert! Das Volk feiert Freiheit!");
                p.LoyalitätVolk += 35;
                p.LoyalitätPartei -= 40;
                p.Charisma += 2;
                p.EinflussMilitär -= 25;
                Console.WriteLine($"➕ Volk: +35% → {p.LoyalitätVolk}%");
                Console.WriteLine($"➖ Partei: -40% → {p.LoyalitätPartei}%");
                Console.WriteLine($"➕ Charisma: +2 (Heldenmut)");
                Thread.Sleep(4000);
            }
        ));
        
        // 1992 - 2 zusätzliche Events
        allEvents.Add(new RandomEvent(
            "Schocktherapie Wirtschaft 1992",
            "PREISE EXPLODIEREN ÜBER NACHT! Jelzins Berater Gaidar befreit alle Preise - die 'Schocktherapie' beginnt. Brot kostet plötzlich das 10-fache! Das Volk stürmt Läden, Ersparnisse verdampfen. Omas verkaufen ihre Habseligkeiten auf der Straße. Der Kapitalismus kommt nicht als Segen, sondern als Tsunami.",
            "Präsident", 100, 1992, "katastrophe",
            p => {
                Console.WriteLine("\n💸 SCHOCKTHERAPIE - PREISE EXPLODIEREN!");
                Console.WriteLine("Das Volk verliert alles! Verzweiflung überall!");
                p.Geld -= 700;
                p.LoyalitätVolk -= 45;
                p.Gesundheit -= 25;
                p.LoyalitätPartei -= 30;
                Console.WriteLine($"💰 Verlust: -700 Rubel → {p.Geld}");
                Console.WriteLine($"➖ Volk: -45% → {p.LoyalitätVolk}%");
                Console.WriteLine($"➖ Gesundheit: -25% → {p.Gesundheit}%");
                Thread.Sleep(4500);
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Voucher-Privatisierung 1992",
            "JEDEM RUSSEN EINE AKTIE! Jelzin verteilt Privatisierungs-Voucher: 'Das Volkseigentum gehört dem Volk!' Das Volk bekommt Papiere im Wert von 10.000 Rubel. Doch clevere Oligarchen kaufen sie für Wodka auf. Das Volk wird betrogen - das Staatsvermögen landet in Oligarchen-Händen.",
            "Präsident", 100, 1992, "politisch",
            p => {
                Console.WriteLine("\n📜 VOUCHER-PRIVATISIERUNG - DAS GROSSE BETRUG!");
                Console.WriteLine("Oligarchen stehlen Volksvermögen! Das Volk ist wütend!");
                p.Geld += 100;
                p.LoyalitätVolk -= 40;
                p.LoyalitätPartei -= 25;
                p.Intelligenz += 1;
                Console.WriteLine($"💰 Voucher: +100 Rubel (ein Witz) → {p.Geld}");
                Console.WriteLine($"➖ Volk: -40% → {p.LoyalitätVolk}%");
                Thread.Sleep(4000);
            }
        ));
        
        // 2005 - 1 zusätzliches Event
        allEvents.Add(new RandomEvent(
            "Orange Revolution Nachwehen 2005",
            "UKRAINE WENDET SICH NACH WESTEN! Viktor Juschtschenko wird Präsident - Flads Kandidat verlor. Das Volk in Russland sieht nervös zu: Könnte das auch hier passieren? Flad zieht die Schrauben an. Die 'farbigen Revolutionen' werden zum Feindbild. Der Kreml hat Angst.",
            "Präsident", 100, 2005, "politisch",
            p => {
                Console.WriteLine("\n🧡 UKRAINE-SCHOCK WIRKT NACH!");
                Console.WriteLine("Flad sieht Bedrohung! Das Volk wird überwacht!");
                p.EinflussKGB += 25;
                p.LoyalitätVolk -= 20;
                p.EinflussInternational -= 20;
                p.Gesundheit -= 10;
                Console.WriteLine($"➕ KGB/FSB: +25 → {p.EinflussKGB}");
                Console.WriteLine($"➖ Volk: -20% → {p.LoyalitätVolk}%");
                Thread.Sleep(4000);
            }
        ));
        
        // 2006 - 2 zusätzliche Events
        allEvents.Add(new RandomEvent(
            "Litwinenko-Mord London 2006",
            "POLONIUM IM TEE! Alexander Litwinenko, Ex-FSB-Agent und Kreml-Kritiker, wird in London mit radioaktivem Polonium vergiftet. Er stirbt qualvoll. Die Spur führt zum Kreml. Das Volk lernt: Selbst in London ist niemand sicher. Verrat wird mit dem Tod bestraft - spektakulär und abschreckend.",
            "Präsident", 100, 2006, "katastrophe",
            p => {
                Console.WriteLine("\n☢️ LITWINENKO VERGIFTET - POLONIUM-MORD!");
                Console.WriteLine("Kreml-Kritiker in London ermordet! Das Volk ist schockiert!");
                p.EinflussKGB += 25;
                p.EinflussInternational -= 35;
                p.LoyalitätVolk -= 25;
                p.Gesundheit -= 15;
                Console.WriteLine($"➕ KGB/FSB: +25 → {p.EinflussKGB}");
                Console.WriteLine($"➖ International: -35 → {p.EinflussInternational}");
                Console.WriteLine($"➖ Volk: -25% → {p.LoyalitätVolk}%");
                Thread.Sleep(4500);
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Georgien-Russland Spionage-Krise 2006",
            "VIER OFFIZIERE VERHAFTET! Georgien verhaftet russische Offiziere wegen Spionage. Flad ist wütend - totales Embargo gegen Georgien! Wein, Wasser, alles verboten. Das Volk leidet unter höheren Preisen. Die Beziehungen sind am Nullpunkt. Zwei Jahre später: Krieg.",
            "Präsident", 100, 2006, "politisch",
            p => {
                Console.WriteLine("\n🇬🇪 GEORGIEN-KRISE ESKALIERT!");
                Console.WriteLine("Embargo verhängt! Das Volk zahlt die Rechnung!");
                p.EinflussMilitär += 15;
                p.Geld -= 200;
                p.LoyalitätVolk -= 15;
                p.EinflussInternational -= 20;
                Console.WriteLine($"➕ Militär: +15 → {p.EinflussMilitär}");
                Console.WriteLine($"💰 Kosten: -200 Rubel → {p.Geld}");
                Thread.Sleep(4000);
            }
        ));
        
        // 2007 - 1 zusätzliches Event
        allEvents.Add(new RandomEvent(
            "Flad München-Rede 2007",
            "KRIEGSERKLÄRUNG AN DEN WESTEN! Flad hält eine flammende Rede auf der Münchner Sicherheitskonferenz: 'Die USA wollen eine unipolare Welt!' Das Volk jubelt - endlich zeigt Russland Stärke! Der Westen ist schockiert. Der neue Kalte Krieg beginnt offiziell. Die Maske ist gefallen.",
            "Präsident", 100, 2007, "politisch",
            p => {
                Console.WriteLine("\n🎤 MÜNCHEN-REDE - PUTIN GEGEN DEN WESTEN!");
                Console.WriteLine("Das Volk feiert russische Stärke!");
                p.EinflussInternational -= 30;
                p.LoyalitätVolk += 30;
                p.EinflussMilitär += 20;
                p.Charisma += 1;
                Console.WriteLine($"➖ International: -30 → {p.EinflussInternational}");
                Console.WriteLine($"➕ Volk: +30% → {p.LoyalitätVolk}%");
                Console.WriteLine($"➕ Militär: +20 → {p.EinflussMilitär}");
                Thread.Sleep(4000);
            }
        ));
        
        // 2009 - 2 zusätzliche Events
        allEvents.Add(new RandomEvent(
            "Magnitski stirbt im Gefängnis 2009",
            "FOLTER BIS ZUM TOD! Sergei Magnitski, Anwalt der Korruption aufdeckte, stirbt in Untersuchungshaft - gefoltert, ohne medizinische Hilfe. Das Volk flüstert die Wahrheit: Er wurde ermordet. Der Westen verhängt später die 'Magnitski-Sanktionen'. Sein Tod wird zum Symbol für Flads Brutalität.",
            "Präsident", 100, 2009, "katastrophe",
            p => {
                Console.WriteLine("\n⚖️ MAGNITSKI STIRBT - FOLTER IN HAFT!");
                Console.WriteLine("Anwalt zu Tode gefoltert! Das Volk ist entsetzt!");
                p.EinflussKGB += 20;
                p.LoyalitätVolk -= 30;
                p.EinflussInternational -= 25;
                p.Gesundheit -= 20;
                Console.WriteLine($"➕ KGB/FSB: +20 → {p.EinflussKGB}");
                Console.WriteLine($"➖ Volk: -30% → {p.LoyalitätVolk}%");
                Console.WriteLine($"➖ International: -25 → {p.EinflussInternational}");
                Thread.Sleep(4500);
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Sajano-Schuschenskaja Katastrophe 2009",
            "WASSERKRAFTWERK EXPLODIERT! Im größten Wasserkraftwerk Russlands reißt eine Turbine - die Flutwelle tötet 75 Arbeiter. Das Volk fragt: Warum wird nicht gewartet? Die Infrastruktur zerfällt, während Milliarden in Paläste fließen. Die Toten werden schnell vergessen.",
            "Präsident", 100, 2009, "katastrophe",
            p => {
                Console.WriteLine("\n💥 KRAFTWERK-KATASTROPHE - 75 TOTE!");
                Console.WriteLine("Infrastruktur versagt! Das Volk trauert und ist wütend!");
                p.Gesundheit -= 25;
                p.Geld -= 400;
                p.LoyalitätVolk -= 30;
                p.LoyalitätPartei -= 15;
                Console.WriteLine($"➖ Gesundheit: -25% → {p.Gesundheit}%");
                Console.WriteLine($"💰 Schaden: -400 Rubel → {p.Geld}");
                Console.WriteLine($"➖ Volk: -30% → {p.LoyalitätVolk}%");
                Thread.Sleep(4500);
            }
        ));
        
        // 2013 - 1 zusätzliches Event
        allEvents.Add(new RandomEvent(
            "Anti-LGBT-Gesetze 2013",
            "'HOMOSEXUELLEN-PROPAGANDA' VERBOTEN! Flad unterzeichnet drakonische Anti-LGBT-Gesetze. Das Volk ist gespalten: Konservative jubeln, Liberale sind entsetzt. Der Westen protestiert - Flad ist es egal. 'Traditionelle Werte' werden zum Kampfbegriff gegen den dekadenten Westen.",
            "Präsident", 100, 2013, "politisch",
            p => {
                Console.WriteLine("\n🏳️‍🌈 ANTI-LGBT-GESETZE ERLASSEN!");
                Console.WriteLine("Das Volk ist tief gespalten!");
                p.LoyalitätVolk -= 20;
                p.EinflussInternational -= 25;
                p.LoyalitätPartei += 20;
                p.Gesundheit -= 10;
                Console.WriteLine($"➖ Volk: -20% → {p.LoyalitätVolk}%");
                Console.WriteLine($"➖ International: -25 → {p.EinflussInternational}");
                Console.WriteLine($"➕ Partei: +20% (Konservative)");
                Thread.Sleep(4000);
            }
        ));
        
        // 2025 - 2 zusätzliche Events
        allEvents.Add(new RandomEvent(
            "Ukraine-Krieg endloser Fleischwolf 2025",
            "DER KRIEG FRISST DIE JUGEND! 2025 - Jahr drei des Ukraine-Krieges. Hunderttausende Russen sind tot oder verstümmelt. Das Volk ist erschöpft, aber die Propaganda läuft weiter. Mütter weinen heimlich. Soldaten desertieren. Wie lange noch? Flad schweigt. Der Fleischwolf dreht sich weiter.",
            "Präsident", 100, 2025, "katastrophe",
            p => {
                Console.WriteLine("\n💀 KRIEG DAUERT AN - JAHR 3!");
                Console.WriteLine("Das Volk ist kriegsmüde! Verluste immens!");
                p.Gesundheit -= 35;
                p.LoyalitätVolk -= 45;
                p.Geld -= 1000;
                p.EinflussMilitär -= 20;
                Console.WriteLine($"➖ Gesundheit: -35% → {p.Gesundheit}%");
                Console.WriteLine($"➖ Volk: -45% → {p.LoyalitätVolk}%");
                Console.WriteLine($"💰 Kriegskosten: -1000 Rubel → {p.Geld}");
                Thread.Sleep(5000);
            }
        ));
        
        allEvents.Add(new RandomEvent(
            "Wirtschaftskollaps droht 2025",
            "DIE WIRTSCHAFT IMPLODIERT! Sanktionen, Kriegskosten, Kapitalflucht - die russische Wirtschaft steht am Abgrund. Das Volk kann sich nichts mehr leisten. Inflation bei 20%. Fabriken schließen. Arbeitslosigkeit steigt. Das Volk fragt: War der Krieg das wert? Die Antwort darf nicht laut gesagt werden.",
            "Präsident", 100, 2025, "katastrophe",
            p => {
                Console.WriteLine("\n📉 WIRTSCHAFTSKRISE VERSCHÄRFT SICH!");
                Console.WriteLine("Das Volk verarmt! Inflation galoppiert!");
                p.Geld -= 800;
                p.LoyalitätVolk -= 40;
                p.Gesundheit -= 25;
                p.LoyalitätPartei -= 30;
                Console.WriteLine($"💰 Verlust: -800 Rubel → {p.Geld}");
                Console.WriteLine($"➖ Volk: -40% → {p.LoyalitätVolk}%");
                Console.WriteLine($"➖ Gesundheit: -25% → {p.Gesundheit}%");
                Thread.Sleep(4500);
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
    ╚═══════════╝");
            }
            else if (eventName.Contains("China") || eventName.Contains("🇨🇳"))
            {
                Console.WriteLine(@"
    ╔═══════════╗
    ║  🐉 🇨🇳 🐉  ║
    ║  C H I N A║
    ╚═══════════╝");
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
            
            return phaseMatch && yearMatch;
        }).ToList();
        
        // Kein Event möglich? Beende frühzeitig
        if (possibleEvents.Count == 0) return;
        
        // ═══ SCHRITT 2: SEPARIERE GARANTIERTE UND ZUFÄLLIGE EVENTS ═══
        var guaranteedEvents = possibleEvents.Where(e => e.Chance >= 100).ToList();
        var randomEvents = possibleEvents.Where(e => e.Chance < 100).ToList();
        
        // ═══ SCHRITT 3: ZEIGE ALLE GARANTIERTEN EVENTS (100% Chance) ═══
        foreach (var guaranteed in guaranteedEvents)
        {
            ShowEventDetails(guaranteed, player);
        }
        
        // ═══ SCHRITT 4: ZEIGE EIN ZUFÄLLIGES EVENT (falls vorhanden und Würfel-Glück) ═══
        if (randomEvents.Count > 0)
        {
            foreach (var randomEvent in randomEvents)
            {
                // Würfeln ob dieses Event erscheint
                if (rand.Next(100) < randomEvent.Chance)
                {
                    ShowEventDetails(randomEvent, player);
                    break; // Nur EIN zufälliges Event pro Durchlauf
                }
            }
        }
    }
    
    /// <summary>
    /// ShowEventDetails - Zeigt ein einzelnes Event an (ausgelagert für Wiederverwendung)
    /// </summary>
    static void ShowEventDetails(RandomEvent chosen, PlayerCharacter player)
    {
        
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
        else if (chosen.Type == "china")
            Console.WriteLine($"║         🐉 CHINA-RUSSLAND {chosen.Jahr} 🐉                ║");
        else if (chosen.Type == "fiktiv")
            Console.WriteLine($"║          🔮 ZUKUNFTSEREIGNIS {chosen.Jahr} 🔮             ║");
        else if (chosen.Type == "usa")
            Console.WriteLine($"║         🇺🇸 USA-RUSSLAND {chosen.Jahr} 🇺🇸                 ║");
        else
            Console.WriteLine("║                  ⚡ ZUFALLSEREIGNIS ⚡                     ║");
            
        Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");
        Console.ResetColor();
        
        // Jahr und Jahreszeit anzeigen
        if (chosen.Jahr > 0)
        {
            string[] jahreszeiten = { "🌸 Frühling", "☀️ Sommer", "🍂 Herbst", "❄️ Winter" };
            string jahreszeit = jahreszeiten[rand.Next(jahreszeiten.Length)];
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n📅 Jahr: {chosen.Jahr} | {jahreszeit}");
            Console.ResetColor();
            Thread.Sleep(2500);
        }
        
        Console.WriteLine($"\n📰 {chosen.Name}\n");
        Thread.Sleep(2500);
        Console.WriteLine(chosen.Description);
        Thread.Sleep(3000);
        
        if (chosen.Type != "sidechick" && chosen.Type != "kgb_easter")  // Spezielle Events haben eigene Interaktion
        {
            Console.WriteLine("\n[Drücke eine Taste...]");
            Console.ReadKey(true);
        }
        
        // ═══ SCHRITT 4: FÜHRE EFFEKTE AUS ═══
        // Lambda-Funktion (Action<PlayerCharacter>) wird ausgeführt
        chosen.Apply(player);
        
        Console.WriteLine("\n✓ Ereignis verarbeitet!");
        Thread.Sleep(3000);
    }
}

class Program
{
    public static bool stopMusic = false;
    public static int currentMusicTrack = 1; // Aktuelle Melodie (1-4)
    static Dictionary<int, GameSave> saveSlots = new Dictionary<int, GameSave>();
    public static Random rand = new Random();  // Public für Zugriff von anderen Klassen
    static PlayerCharacter currentPlayer = null;
    
    // ═══════════════════════════════════════════════════════════════════
    // TELEFONATE-SYSTEM: Historische Anrufe mit Staatsführern
    // ═══════════════════════════════════════════════════════════════════
    
    public class TelefonatEvent
    {
        public DateTime Datum;
        public string Anrufer;
        public string Empfaenger;
        public string Thema;
        public string Beschreibung;
        public List<TelefonatOption> Optionen;
        public bool Ausgeloest = false;
    }
    
    public class TelefonatOption
    {
        public string Text;
        public int VolkAenderung;
        public int ArmeeAenderung;
        public int WirtschaftAenderung;
        public int DiplomatieAenderung;
        public int KGBAenderung;
    }
    
    static List<TelefonatEvent> telefonate = new List<TelefonatEvent>();
    
    /// <summary>
    /// InitializeTelefonate - Lädt alle historischen Telefonate (nur logische ab KGB-Phase)
    /// </summary>
    static void InitializeTelefonate()
    {
        // 1975 - Erste KGB Mission (Flad ist 23)
        telefonate.Add(new TelefonatEvent
        {
            Datum = new DateTime(1975, 1, 3),
            Anrufer = "KGB-Ausbilder",
            Empfaenger = "Flad Rusputin",
            Thema = "Erste Mission nach Ostdeutschland",
            Beschreibung = "Flad… wir schicken dich nach Ostdeutschland. Beobachten. Fotografieren. Melden. Keine Fehler. Der Ton ist streng – aber voller Erwartungen.",
            Optionen = new List<TelefonatOption>
            {
                new TelefonatOption { Text = "Ich erledige den Auftrag.", VolkAenderung = -3, ArmeeAenderung = 0, WirtschaftAenderung = 0, DiplomatieAenderung = 5, KGBAenderung = 20 },
                new TelefonatOption { Text = "Geben Sie mir eine härtere Mission.", VolkAenderung = 0, ArmeeAenderung = 5, WirtschaftAenderung = 0, DiplomatieAenderung = 0, KGBAenderung = 25 },
                new TelefonatOption { Text = "Ist das wirklich notwendig?", VolkAenderung = 5, ArmeeAenderung = -5, WirtschaftAenderung = 0, DiplomatieAenderung = 0, KGBAenderung = -10 }
            }
        });
        
        // 1986 - Tschernobyl (Flad ist 34)
        telefonate.Add(new TelefonatEvent
        {
            Datum = new DateTime(1986, 4, 26),
            Anrufer = "KGB-Notfallstab",
            Empfaenger = "Flad Rusputin",
            Thema = "Tschernobyl-Katastrophe",
            Beschreibung = "Flad, hör gut zu. Ein Reaktor ist explodiert. Panik, Schreie, Sirenen. Du wirst NICHT darüber sprechen. Verstanden?",
            Optionen = new List<TelefonatOption>
            {
                new TelefonatOption { Text = "Wir müssen das Volk warnen!", VolkAenderung = 20, ArmeeAenderung = 0, WirtschaftAenderung = -20, DiplomatieAenderung = -10, KGBAenderung = -15 },
                new TelefonatOption { Text = "Ich folge den Befehlen.", VolkAenderung = -10, ArmeeAenderung = 5, WirtschaftAenderung = 0, DiplomatieAenderung = 0, KGBAenderung = 20 },
                new TelefonatOption { Text = "Ich brauche genaue Daten!", VolkAenderung = 0, ArmeeAenderung = 0, WirtschaftAenderung = 0, DiplomatieAenderung = 5, KGBAenderung = 10 },
                new TelefonatOption { Text = "Vertuschen wir alles.", VolkAenderung = -20, ArmeeAenderung = 10, WirtschaftAenderung = 0, DiplomatieAenderung = -15, KGBAenderung = 25 }
            }
        });
        
        // 1991 - UdSSR Zerfall (Flad ist 39)
        telefonate.Add(new TelefonatEvent
        {
            Datum = new DateTime(1991, 12, 25),
            Anrufer = "Boris Jelzin",
            Empfaenger = "Flad Rusputin",
            Thema = "UdSSR zerbricht",
            Beschreibung = "Jelzin klingt betrunken und verzweifelt. 'Flad… die Sowjetunion existiert nicht mehr. Wir sind… Russland jetzt.'",
            Optionen = new List<TelefonatOption>
            {
                new TelefonatOption { Text = "Ich diene Russland.", VolkAenderung = 10, ArmeeAenderung = -5, WirtschaftAenderung = 0, DiplomatieAenderung = 10, KGBAenderung = 5 },
                new TelefonatOption { Text = "Ich trete zurück.", VolkAenderung = -20, ArmeeAenderung = -10, WirtschaftAenderung = 0, DiplomatieAenderung = -10, KGBAenderung = -20 },
                new TelefonatOption { Text = "Ich übernehme mehr Verantwortung.", VolkAenderung = 5, ArmeeAenderung = 10, WirtschaftAenderung = 0, DiplomatieAenderung = 5, KGBAenderung = 15 }
            }
        });
        
        // 2000 - Machtübernahme (Flad ist 48)
        telefonate.Add(new TelefonatEvent
        {
            Datum = new DateTime(2000, 10, 7),
            Anrufer = "Geheimdienstchef",
            Empfaenger = "Präsident Flad",
            Thema = "Machtübernahme komplett",
            Beschreibung = "Präsident Flad… Russland gehört jetzt Ihnen. Du hörst im Hintergrund Applaus – oder Maschinengewehrfeuer.",
            Optionen = new List<TelefonatOption>
            {
                new TelefonatOption { Text = "Bring Ordnung in das Land.", VolkAenderung = 15, ArmeeAenderung = 15, WirtschaftAenderung = -10, DiplomatieAenderung = -5, KGBAenderung = 20 },
                new TelefonatOption { Text = "Wir werden ein Imperium.", VolkAenderung = 20, ArmeeAenderung = 25, WirtschaftAenderung = -30, DiplomatieAenderung = -20, KGBAenderung = 25 },
                new TelefonatOption { Text = "Ich beginne Reformen.", VolkAenderung = 25, ArmeeAenderung = -10, WirtschaftAenderung = 50, DiplomatieAenderung = 30, KGBAenderung = -10 },
                new TelefonatOption { Text = "Bekämpft die Oligarchen.", VolkAenderung = 30, ArmeeAenderung = 5, WirtschaftAenderung = 20, DiplomatieAenderung = 0, KGBAenderung = 15 }
            }
        });
        
        // 2022 - Ukraine Krieg (Flad ist 70)
        telefonate.Add(new TelefonatEvent
        {
            Datum = new DateTime(2022, 2, 24),
            Anrufer = "NATO-Generalsekretär",
            Empfaenger = "Präsident Flad",
            Thema = "Ukraine-Krieg",
            Beschreibung = "Flad, das ist Wahnsinn! Stoppen Sie das sofort! Stille. Die Welt hält den Atem an.",
            Optionen = new List<TelefonatOption>
            {
                new TelefonatOption { Text = "Wir ziehen uns zurück.", VolkAenderung = -30, ArmeeAenderung = -40, WirtschaftAenderung = 100, DiplomatieAenderung = 50, KGBAenderung = -30 },
                new TelefonatOption { Text = "Wir verhandeln.", VolkAenderung = -10, ArmeeAenderung = -10, WirtschaftAenderung = 20, DiplomatieAenderung = 20, KGBAenderung = 0 },
                new TelefonatOption { Text = "Wir eskalieren.", VolkAenderung = 15, ArmeeAenderung = 30, WirtschaftAenderung = -100, DiplomatieAenderung = -80, KGBAenderung = 20 },
                new TelefonatOption { Text = "Alles läuft nach Plan.", VolkAenderung = 10, ArmeeAenderung = 20, WirtschaftAenderung = -50, DiplomatieAenderung = -60, KGBAenderung = 25 }
            }
        });
    }
    
    /// <summary>
    /// CheckTelefonateForYear - Prüft ob Telefonate für aktuelles Jahr vorhanden sind
    /// </summary>
    static void CheckTelefonateForYear(PlayerCharacter player)
    {
        int currentYear = player.GetCurrentYear();
        
        foreach (var telefonat in telefonate)
        {
            if (telefonat.Datum.Year == currentYear && !telefonat.Ausgeloest)
            {
                // KGB Easter Egg Chance berechnen
                int kgbLevel = player.EinflussKGB;
                int chance = 10 + (kgbLevel * 2);
                if (chance > 85) chance = 85;
                
                bool kgbEasterEgg = (kgbLevel >= 30 && rand.Next(100) < chance);
                
                TriggerTelefonat(player, telefonat, kgbEasterEgg);
                telefonat.Ausgeloest = true;
                return; // Nur ein Telefonat pro Jahr
            }
        }
    }
    
    /// <summary>
    /// TriggerTelefonat - Zeigt ein Telefonat und lässt Spieler entscheiden
    /// </summary>
    static void TriggerTelefonat(PlayerCharacter player, TelefonatEvent telefonat, bool kgbEasterEgg)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(@"
╔═══════════════════════════════════════════════════════════╗
║                 📞 WICHTIGER ANRUF! 📞                    ║
╚═══════════════════════════════════════════════════════════╝
");
        Console.ResetColor();
        
        Console.WriteLine($"📅 {telefonat.Datum.ToString("dd.MM.yyyy")}\n");
        Console.WriteLine($"📞 {telefonat.Anrufer}");
        Console.WriteLine($"   → {telefonat.Empfaenger}\n");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"THEMA: {telefonat.Thema}");
        Console.ResetColor();
        Console.WriteLine();
        Console.WriteLine(telefonat.Beschreibung);
        Console.WriteLine();
        
        Thread.Sleep(4000);
        
        if (kgbEasterEgg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
            Console.WriteLine("║          🕵️ KGB EASTER EGG FREIGESCHALTET! 🕵️            ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine("\nEin KGB-Agent flüstert dir geheime Informationen zu...");
            Console.WriteLine("'Genosse, ich habe... alternative Optionen für Sie...'");
            Thread.Sleep(3000);
            Console.WriteLine();
        }
        
        Console.WriteLine("═══════════════════════════════════════════════════════════");
        Console.WriteLine("WIE REAGIERST DU?");
        Console.WriteLine("═══════════════════════════════════════════════════════════\n");
        
        for (int i = 0; i < telefonat.Optionen.Count; i++)
        {
            Console.WriteLine($"[{i + 1}] {telefonat.Optionen[i].Text}");
        }
        
        if (kgbEasterEgg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[{telefonat.Optionen.Count + 1}] 🕵️ KGB-Option: Geheime Operation durchführen");
            Console.ResetColor();
        }
        
        Console.Write($"\nWähle [1-{telefonat.Optionen.Count + (kgbEasterEgg ? 1 : 0)}]: ");
        string choice = Console.ReadLine();
        
        int choiceNum = 0;
        int.TryParse(choice, out choiceNum);
        
        if (choiceNum >= 1 && choiceNum <= telefonat.Optionen.Count)
        {
            var option = telefonat.Optionen[choiceNum - 1];
            ApplyTelefonatEffects(player, option);
        }
        else if (kgbEasterEgg && choiceNum == telefonat.Optionen.Count + 1)
        {
            // KGB Easter Egg Option
            Console.WriteLine("\n🕵️ Der KGB führt eine geheime Operation durch...");
            player.EinflussKGB += 25;
            player.Geld += 500;
            player.LoyalitätVolk -= 15;
            Console.WriteLine("\n✓ +25 KGB-Einfluss");
            Console.WriteLine("✓ +500 Rubel (aus geheimen Fonds)");
            Console.WriteLine("✓ -15 Volk (Gerüchte verbreiten sich)");
            Thread.Sleep(4000);
        }
        else
        {
            Console.WriteLine("\n❌ Ungültige Wahl! Keine Entscheidung getroffen.");
            Thread.Sleep(2000);
        }
        
        Console.WriteLine("\n[Drücke eine Taste...]");
        Console.ReadKey(true);
    }
    
    /// <summary>
    /// ApplyTelefonatEffects - Wendet die Auswirkungen einer Telefonat-Option an
    /// </summary>
    static void ApplyTelefonatEffects(PlayerCharacter player, TelefonatOption option)
    {
        Console.WriteLine("\n═══════════════════════════════════════════════════════════");
        Console.WriteLine("AUSWIRKUNGEN:");
        Console.WriteLine("═══════════════════════════════════════════════════════════");
        
        if (option.VolkAenderung != 0)
        {
            player.LoyalitätVolk += option.VolkAenderung;
            Console.WriteLine($"{(option.VolkAenderung > 0 ? "✓" : "✗")} Volk: {option.VolkAenderung:+0;-0} → {player.LoyalitätVolk}%");
        }
        
        if (option.ArmeeAenderung != 0)
        {
            player.EinflussMilitär += option.ArmeeAenderung;
            Console.WriteLine($"{(option.ArmeeAenderung > 0 ? "✓" : "✗")} Armee: {option.ArmeeAenderung:+0;-0} → {player.EinflussMilitär}%");
        }
        
        if (option.WirtschaftAenderung != 0)
        {
            player.Geld += option.WirtschaftAenderung;
            Console.WriteLine($"{(option.WirtschaftAenderung > 0 ? "✓" : "✗")} Wirtschaft: {option.WirtschaftAenderung:+0;-0} Rubel → {player.Geld}₽");
        }
        
        if (option.DiplomatieAenderung != 0)
        {
            player.EinflussInternational += option.DiplomatieAenderung;
            Console.WriteLine($"{(option.DiplomatieAenderung > 0 ? "✓" : "✗")} Diplomatie: {option.DiplomatieAenderung:+0;-0} → {player.EinflussInternational}%");
        }
        
        if (option.KGBAenderung != 0)
        {
            player.EinflussKGB += option.KGBAenderung;
            Console.WriteLine($"{(option.KGBAenderung > 0 ? "✓" : "✗")} KGB: {option.KGBAenderung:+0;-0} → {player.EinflussKGB}%");
        }
        
        Thread.Sleep(4000);
    }
    
    // ═══════════════════════════════════════════════════════════════════
    // SIDECHICK-SYSTEM: Alle 10 Jahre + Vaterschaftstest nach 18 Jahren
    // ═══════════════════════════════════════════════════════════════════
    
    static string[] WeiblicheNamen = new string[] {
        "Natasha", "Svetlana", "Olga", "Katerina", "Anastasia",
        "Irina", "Marina", "Elena", "Tatiana", "Yulia",
        "Vera", "Daria", "Alina", "Oksana", "Ludmila",
        "Galina", "Nina", "Valentina", "Polina", "Sofia"
    };
    
    static string[] MaennlicheNamen = new string[] {
        "Dmitri", "Alexander", "Sergei", "Vladimir", "Nikolai",
        "Ivan", "Mikhail", "Alexei", "Boris", "Yuri",
        "Pavel", "Roman", "Kirill", "Maxim", "Oleg",
        "Viktor", "Andrei", "Stanislav", "Leonid", "Grigori"
    };
    
    static string[] WeiblicheBerufe = new string[] {
        "charmante Diplomatin aus Belarus",
        "mysteriöse Balletttänzerin aus St. Petersburg",
        "atemberaubende Oligarchen-Tochter aus Moskau",
        "bezaubernde Journalistin aus Kiew",
        "elegante Geschäftsfrau aus London",
        "verführerische Spionin aus Paris",
        "schöne Sängerin aus der Ukraine",
        "betörende Model aus Mailand",
        "faszinierende Anwältin aus Berlin",
        "hinreißende Schauspielerin aus Hollywood",
        "exotische Prinzessin aus Dubai",
        "reizende Ärztin aus Wien",
        "verlockende Bankerin aus Zürich",
        "anmutige Pianistin aus Warschau",
        "bildschöne Fernsehmoderatorin aus Moskau",
        "geheimnisvolle Kunsthändlerin aus New York",
        "begehrenswerte Ministerin aus der Türkei",
        "betörende Parfümeurin aus Paris",
        "verführerische Juwelenhändlerin aus Antwerpen",
        "faszinierende Rennfahrerin aus Monaco"
    };
    
    static string[] MaennlicheBerufe = new string[] {
        "charmanter Diplomat aus Deutschland",
        "mysteriöser Geheimagent aus London",
        "atemberaubender Oligarch aus Moskau",
        "bezaubernder Journalist aus Paris",
        "eleganter Geschäftsmann aus Dubai",
        "verführerischer Spion aus Amerika",
        "schöner Sänger aus Italien",
        "betörender Model aus New York",
        "faszinierender Anwalt aus der Schweiz",
        "hinreißender Schauspieler aus Hollywood",
        "exotischer Prinz aus Saudi-Arabien",
        "reizender Arzt aus Österreich",
        "verlockender Banker aus London",
        "anmutiger Pianist aus Wien",
        "bildschöner Fernsehmoderator aus Moskau",
        "geheimnisvoller Kunsthändler aus Paris",
        "begehrenswerter Minister aus Frankreich",
        "betörender Parfümeur aus Italien",
        "verführerischer Juwelenhändler aus Belgien",
        "faszinierender Rennfahrer aus Monaco"
    };
    
    
    /// <summary>
    /// Prüft ob ein Sidechick-Event ausgelöst werden soll (alle 10 Jahre ab Alter 20)
    /// </summary>
    static void CheckSidechickEvent(PlayerCharacter player)
    {
        // Nur in Präsidenten-Phase
        if (player.Phase != "Präsident")
            return;
            
        // Alle 10 Jahre ab Alter 20 (20, 30, 40, 50, 60, 70, 80...)
        int currentYear = player.GetCurrentYear();
        if (player.Alter >= 20 && (currentYear % 10 == 0) && currentYear != player.LetztesSidechickJahr)
        {
            player.LetztesSidechickJahr = currentYear;
            TriggerSidechickEvent(player);
        }
    }
    
    /// <summary>
    /// Prüft ob ein Vaterschaftstest-Event fällig ist (18 Jahre nach Geburt)
    /// </summary>
    static void CheckVaterschaftstestEvent(PlayerCharacter player)
    {
        int currentYear = player.GetCurrentYear();
        
        for (int i = 0; i < player.VersteckteKinder.Count; i++)
        {
            var kind = player.VersteckteKinder[i];
            int alterDesKindes = currentYear - kind.GeburtsjahR;
            
            if (alterDesKindes == 18)
            {
                // Kind ist jetzt 18 - Vaterschaftstest-Event!
                player.VersteckteKinder.RemoveAt(i);
                TriggerVaterschaftstestEvent(player, kind);
                return; // Nur ein Event pro Jahr
            }
        }
    }
    
    static void TriggerSidechickEvent(PlayerCharacter player)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                  💋 ROMANTISCHE BEGEGNUNG 💋              ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");
        Console.ResetColor();
        
        // Geschlechtsspezifisch
        bool spielerIstMaennlich = !player.Name.ToLower().Contains("ova") && !player.Name.ToLower().Contains("ina");
        string[] namen = spielerIstMaennlich ? WeiblicheNamen : MaennlicheNamen;
        string[] berufe = spielerIstMaennlich ? WeiblicheBerufe : MaennlicheBerufe;
        
        string sidechickName = namen[rand.Next(namen.Length)];
        string sidechickBeruf = berufe[rand.Next(berufe.Length)];
        
        Console.WriteLine($"\nBei einem Staatsempfang triffst du {sidechickName}, {(spielerIstMaennlich ? "eine" : "einen")} {sidechickBeruf}.");
        Console.WriteLine($"Die Chemie zwischen euch ist elektrisch. {sidechickName} flüstert:");
        Console.WriteLine($"'{(spielerIstMaennlich ? "Sie würden" : "Du würdest")} gerne mehr Zeit mit mir verbringen...'");
        Thread.Sleep(4000);
        
        Console.WriteLine("\n═══════════════════════════════════════════════════════════");
        Console.WriteLine("Was möchtest du tun?");
        Console.WriteLine("═══════════════════════════════════════════════════════════");
        Console.WriteLine("\n[1] 💰 Einfaches Abendessen im Kreml (200₽) - 40% Erfolg");
        Console.WriteLine("[2] 💎 Luxus-Date im Bolschoi Theater (500₽) - 60% Erfolg");
        Console.WriteLine("[3] 🛩️  Romantisches Wochenende in Paris (1000₽) - 80% Erfolg");
        Console.WriteLine("[4] ✈️  Traumreise auf die Malediven (2500₽) - 95% Erfolg");
        Console.WriteLine("[5] 🚫 Ablehnen - Treu bleiben");
        Console.Write("\nWähle [1-5]: ");
        
        string choice = Console.ReadLine();
        
        if (choice == "5")
        {
            Console.Clear();
            Console.WriteLine("\n✓ Du bleibst deinen Prinzipien treu.");
            Console.WriteLine($"{sidechickName} ist enttäuscht und verlässt den Raum.");
            player.LoyalitätFamilie += 15;
            Console.WriteLine("\n💚 Familie-Loyalität: +15%");
            Thread.Sleep(4000);
            return;
        }
        
        int kosten = 0;
        int erfolgsChance = 0;
        string dateOrt = "";
        
        switch (choice)
        {
            case "1": kosten = 200; erfolgsChance = 40; dateOrt = "Kreml-Restaurant"; break;
            case "2": kosten = 500; erfolgsChance = 60; dateOrt = "Bolschoi Theater"; break;
            case "3": kosten = 1000; erfolgsChance = 80; dateOrt = "Paris"; break;
            case "4": kosten = 2500; erfolgsChance = 95; dateOrt = "Malediven"; break;
            default: Console.WriteLine("\nUngültige Wahl."); Thread.Sleep(2000); return;
        }
        
        if (player.Geld < kosten)
        {
            Console.WriteLine($"\n💸 Du hast nicht genug Geld! (Benötigt: {kosten}₽)");
            Thread.Sleep(3000);
            return;
        }
        
        player.Geld -= kosten;
        
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                    💋 DAS DATE BEGINNT 💋                 ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");
        Console.ResetColor();
        
        Console.WriteLine($"\n{dateOrt.ToUpper()}");
        switch (choice)
        {
            case "1":
                Console.WriteLine($"\nPrivater Saal im Kreml. Champagner und Kaviar.");
                Console.WriteLine($"{sidechickName} lächelt über den Tisch. Intim...");
                break;
            case "2":
                Console.WriteLine($"\nBolschoi Theater in goldenem Licht. Schwanensee.");
                Console.WriteLine($"{sidechickName} lehnt sich an deine Schulter...");
                break;
            case "3":
                Console.WriteLine($"\nParis bei Nacht. Eiffelturm funkelt. Spaziergang an der Seine.");
                Console.WriteLine($"{sidechickName} flüstert französisch. Kuss unter Sternen...");
                break;
            case "4":
                Console.WriteLine($"\nTürkisblaues Wasser. Weißer Sand. Private Villa.");
                Console.WriteLine($"{sidechickName} liegt neben dir. Die Welt existiert nicht...");
                break;
        }
        
        Thread.Sleep(5000);
        
        if (rand.Next(100) < erfolgsChance)
        {
            Console.WriteLine("\n💋💋💋 Die Nacht wird unvergesslich... 💋💋💋");
            Thread.Sleep(3000);
            
            if (rand.Next(100) < 60)
            {
                Console.WriteLine("\n\n══════════════════════════════════════════════════════");
                Console.WriteLine("⏰ SECHS MONATE SPÄTER...");
                Console.WriteLine("══════════════════════════════════════════════════════");
                Thread.Sleep(3000);
                
                Console.WriteLine($"\n{sidechickName}: 'Ich bin schwanger! Das Kind ist von dir!'");
                Thread.Sleep(4000);
                
                bool istJunge = rand.Next(2) == 0;
                
                var verstecktesKind = new PlayerCharacter.UnanerkanntesSidechickKind
                {
                    MutterName = sidechickName,
                    GeburtsjahR = player.GetCurrentYear(),
                    IstJunge = istJunge,
                    Staerke = Math.Max(1, player.Stärke + rand.Next(-2, 3)),
                    Intelligenz = Math.Max(1, player.Intelligenz + rand.Next(-2, 3)),
                    Charisma = Math.Max(1, player.Charisma + rand.Next(-2, 3)),
                    Kraft = Math.Max(1, player.Kraft + rand.Next(-2, 3)),
                    DatumKosten = kosten
                };
                
                player.VersteckteKinder.Add(verstecktesKind);
                
                Console.WriteLine($"\n👶 Ein {(istJunge ? "Junge" : "Mädchen")} wird geboren!");
                Console.WriteLine($"Wächst bei {sidechickName} auf - du zahlst heimlich monatlich.");
                Console.WriteLine($"\n⚠️ IN 18 JAHREN: Vaterschaftstest!");
                
                player.Geld -= 150;
                Console.WriteLine($"\n💸 -150₽ (Schweigegeld)");
            }
            else
            {
                Console.WriteLine("\n\n💭 Wundervolle Erinnerung... keine Konsequenzen.");
                player.Geld -= 100;
                Console.WriteLine($"\n💸 -100₽ (Geschenk)");
            }
            
            player.LoyalitätFamilie -= 25;
            Console.WriteLine($"\n💔 Familie: -25%");
            
            if (player.IstVerheiratet)
            {
                player.LoyalitätFamilie -= 20;
                Console.WriteLine($"💔 Ehe angespannt: -20%");
            }
            
            if (rand.Next(100) < 20)
            {
                Console.WriteLine("\n\n📰 SKANDAL! Presse erfährt davon!");
                player.LoyalitätVolk -= 35;
                player.LoyalitätPartei -= 20;
                player.Geld -= 300;
                Console.WriteLine($"\n👥 Volk: -35% | 🏛️ Partei: -20% | 💸 -300₽");
            }
        }
        else
        {
            Console.WriteLine($"\n\n😔 {sidechickName} ist nicht interessiert...");
            Console.WriteLine("Date endet höflich aber ohne Romantik.");
            Console.WriteLine($"\n💸 -{kosten}₽ verschwendet");
        }
        
        Thread.Sleep(6000);
    }
    
    static void TriggerVaterschaftstestEvent(PlayerCharacter player, PlayerCharacter.UnanerkanntesSidechickKind kind)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
        Console.WriteLine("║              ⚖️  VATERSCHAFTSTEST GEFORDERT ⚖️           ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");
        Console.ResetColor();
        
        Console.WriteLine($"\n18 JAHRE SIND VERGANGEN...");
        Thread.Sleep(3000);
        
        Console.WriteLine($"\n{kind.MutterName} kontaktiert dich:");
        Console.WriteLine($"'Unser Kind ist 18! Es will wissen, wer sein Vater ist.'");
        Console.WriteLine($"'Mach einen Test - oder zahl was du schuldest!'");
        Thread.Sleep(5000);
        
        Console.WriteLine("\n═══════════════════════════════════════════════════════════");
        Console.WriteLine("[1] 💰 Vaterschaftstest (500₽) - 30% positiv");
        Console.WriteLine("[2] 🚫 Ablehnen und Kontakt abbrechen");
        Console.WriteLine("[3] ☠️  'Problem lösen' - KGB (1000₽)");
        Console.Write("\nWähle [1-3]: ");
        
        string choice = Console.ReadLine();
        
        if (choice == "1")
        {
            if (player.Geld < 500)
            {
                Console.WriteLine("\n💸 Nicht genug Geld!");
                Thread.Sleep(3000);
                return;
            }
            
            player.Geld -= 500;
            Console.WriteLine("\n🧬 Test läuft...");
            Thread.Sleep(3000);
            
            bool istDeinKind = rand.Next(100) < 30;
            
            if (istDeinKind)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                  ✅ TEST POSITIV ✅                       ║");
                Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");
                Console.ResetColor();
                
                Console.WriteLine($"\nDas Kind ist WIRKLICH von dir!");
                Thread.Sleep(4000);
                
                int alimenteGesamt = kind.DatumKosten * 18;
                int studiengebuehren = 1500;
                int gesamt = alimenteGesamt + studiengebuehren;
                
                Console.WriteLine("\n💰 FORDERUNGEN:");
                Console.WriteLine($"  • Alimente (18 Jahre): {alimenteGesamt}₽");
                Console.WriteLine($"  • Studium (Elite-Uni): {studiengebuehren}₽");
                Console.WriteLine($"  • GESAMT: {gesamt}₽");
                Thread.Sleep(5000);
                
                if (player.Geld < gesamt)
                {
                    Console.WriteLine($"\n⚠️ Nicht genug Geld! (Nur {player.Geld}₽)");
                    Console.WriteLine("Kredite... Ratenzahlung...");
                    player.Geld -= player.Geld / 2;
                    player.LoyalitätVolk -= 30;
                    Console.WriteLine("\n📰 SKANDAL! Zahlungsunfähigkeit!");
                }
                else
                {
                    player.Geld -= gesamt;
                    Console.WriteLine($"\n✓ Bezahlt: -{gesamt}₽");
                }
                
                Thread.Sleep(3000);
                
                Console.WriteLine($"\n👨‍👦 Kind wird anerkannt!");
                
                string[] maennlicheVornamen = { "Igor", "Dmitri", "Alexei", "Viktor", "Roman", "Pavel", "Kirill", "Maxim" };
                string[] weiblicheVornamen = { "Svetlana", "Natasha", "Katerina", "Irina", "Polina", "Daria", "Alina", "Sofia" };
                
                string vorname = kind.IstJunge ? 
                    maennlicheVornamen[rand.Next(maennlicheVornamen.Length)] :
                    weiblicheVornamen[rand.Next(weiblicheVornamen.Length)];
                
                Console.Write($"\nName (Enter = {vorname}): ");
                string eingabe = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(eingabe)) vorname = eingabe;
                
                string kindName = $"{vorname} [Unehelich] Gen{player.Generation + 1}";
                
                PlayerCharacter child = new PlayerCharacter(kindName, player.Generation + 1);
                child.Alter = 18;
                child.Phase = "Jurastudium";
                child.Geburtsjahr = kind.GeburtsjahR;
                child.Stärke = kind.Staerke;
                child.Intelligenz = kind.Intelligenz + 3; // BONUS!
                child.Charisma = kind.Charisma;
                child.Kraft = kind.Kraft;
                
                player.Kinder.Add(child);
                
                Console.WriteLine($"\n✓ {kindName} zur Familie!");
                Console.WriteLine($"Attribute: S:{child.Stärke} I:{child.Intelligenz}(+3!) C:{child.Charisma} K:{child.Kraft}");
                Console.WriteLine($"\n🎓 Studiert an Elite-Uni!");
                
                player.LoyalitätFamilie -= 30;
                Console.WriteLine($"\n💔 Familie: -30%");
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
                Console.WriteLine("║                  ❌ TEST NEGATIV ❌                       ║");
                Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");
                Console.ResetColor();
                
                Console.WriteLine($"\nNICHT dein Kind!");
                Console.WriteLine($"{kind.MutterName} hat gelogen!");
                Thread.Sleep(4000);
                
                Console.WriteLine("\n😤 Was tust du?");
                Console.WriteLine("\n[1] 🚫 Kontakt abbrechen");
                Console.WriteLine("[2] ☠️  'KGB regelt das' (1000₽)");
                Console.Write("\nWähle [1-2]: ");
                
                string revenge = Console.ReadLine();
                
                if (revenge == "2")
                {
                    if (player.Geld < 1000)
                    {
                        Console.WriteLine("\n💸 Nicht genug Geld!");
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        player.Geld -= 1000;
                        player.EinflussKGB += 20;
                        
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\n☠️  KGB-OPERATION AKTIVIERT ☠️");
                        Thread.Sleep(2000);
                        Console.WriteLine("\nEin Anruf...");
                        Thread.Sleep(2000);
                        Console.WriteLine($"\n{kind.MutterName} und Kind verschwinden spurlos.");
                        Thread.Sleep(2000);
                        Console.WriteLine("\nOffiziell: 'Tragischer Autounfall'");
                        Thread.Sleep(2000);
                        Console.WriteLine("\nAkten vernichtet.");
                        Console.ResetColor();
                        Thread.Sleep(3000);
                        
                        Console.WriteLine("\n✓ Problem gelöst.");
                        Console.WriteLine($"💀 KGB: +20");
                        
                        player.Gesundheit -= 20;
                        Console.WriteLine($"💔 Gesundheit: -20% (Gewissen...)");
                    }
                }
                else
                {
                    Console.WriteLine($"\nKontakt abgebrochen.");
                    player.LoyalitätFamilie += 10;
                }
            }
        }
        else if (choice == "2")
        {
            Console.WriteLine($"\nDu ignorierst die Forderung.");
            Console.WriteLine("Sie droht mit Presse...");
            
            if (rand.Next(100) < 50)
            {
                Console.WriteLine("\n📰 SKANDAL! Zeitungen!");
                player.LoyalitätVolk -= 40;
                player.LoyalitätPartei -= 25;
                Console.WriteLine($"\n👥 Volk: -40% | 🏛️ Partei: -25%");
            }
        }
        else if (choice == "3")
        {
            if (player.Geld < 1000)
            {
                Console.WriteLine("\n💸 Nicht genug Geld!");
                Thread.Sleep(3000);
                return;
            }
            
            player.Geld -= 1000;
            player.EinflussKGB += 25;
            
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\n☠️  KGB-OPERATION ☠️");
            Thread.Sleep(2000);
            Console.WriteLine($"\nVerschlüsselter Anruf. Einsatzkommando.");
            Thread.Sleep(2000);
            Console.WriteLine($"\n{kind.MutterName} und Kind: Nie wieder gesehen.");
            Thread.Sleep(2000);
            Console.WriteLine("\nBericht: 'Ausgewandert'");
            Thread.Sleep(2000);
            Console.WriteLine("\nSpuren gelöscht.");
            Console.ResetColor();
            Thread.Sleep(3000);
            
            Console.WriteLine("\n✓ Problem permanent gelöst.");
            Console.WriteLine($"💀 KGB: +25");
            
            player.Gesundheit -= 25;
            Console.WriteLine($"💔 Gesundheit: -25%");
        }
        
        Thread.Sleep(7000);
    }

    /// <summary>
    /// ENTRY POINT - Startet das Spiel
    /// </summary>
    static void Main()
    {
        try
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            
            // Sprache ist fest auf Deutsch
            EventSystem.currentLanguage = "DE";
            
            EventSystem.InitializeEvents(); // Zufalls-Ereignisse laden
            EventSystem.InitializeHistoricalEvents(); // Historische Ereignisse laden
            InitializeTelefonate(); // Telefonate laden
            ShowIntro();
            MainMenu();
        }
        catch (Exception ex)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("═══════════════════════════════════════════════════════════");
            Console.WriteLine("║            KRITISCHER FEHLER / CRITICAL ERROR          ║");
            Console.WriteLine("═══════════════════════════════════════════════════════════\n");
            Console.ResetColor();
            Console.WriteLine("Das Spiel ist auf einen unerwarteten Fehler gestoßen:");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("FEHLERDETAILS:");
            Console.WriteLine("─────────────────────────────────────────────────────────");
            Console.ResetColor();
            Console.WriteLine(ex.ToString());
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("═══════════════════════════════════════════════════════════");
            Console.WriteLine("Bitte sende diese Fehlermeldung an den Entwickler!");
            Console.WriteLine("═══════════════════════════════════════════════════════════");
            Console.ResetColor();
            Console.WriteLine("\nDrücke eine beliebige Taste zum Beenden...");
            Console.ReadKey();
        }
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
                    Thread.Sleep(2500);
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
        // MUSIK LÄUFT WEITER während des Spiels
        Console.Clear();
        
        if (playerCount == 1)
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
            Console.WriteLine("║      FLAD: AUFSTIEG IN EINER SOWJETISCHEN DYSTOPIE        ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════╝\n");
            
            Console.WriteLine("1952, Leningrad – In einer verfallenen Scheune");
            Console.WriteLine("erblickt Flad das Licht der Welt...\n");
            Thread.Sleep(3500);
        }
        else
        {
            Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
            Console.WriteLine("║           MULTIPLAYER: AUFSTIEG ZUR MACHT                 ║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════╝\n");
            
            Console.WriteLine($"{playerCount} Spieler treten gegeneinander an!");
            Console.WriteLine("Wer wird die mächtigste Dynastie aufbauen?\n");
            Thread.Sleep(3000);
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
            Thread.Sleep(2500);
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
        
        // MUSIK LÄUFT BEREITS - nicht neu starten
    }
    
    static void PlayMultiplayerStory(List<PlayerCharacter> players)
    {
        Console.Clear();
        Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
        Console.WriteLine("║              MULTIPLAYER-KAMPAGNE                         ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════╝\n");
        
        Console.WriteLine("Alle Spieler durchlaufen parallel ihr Leben.");
        Console.WriteLine("Jeder Spieler erlebt eigene Zufallsereignisse!");
        Console.WriteLine("Am Ende der Präsidentschaft könnt ihr die Dynastie an Erben weitergeben.\n");
        Thread.Sleep(4000);
        
        // Jeder Spieler durchläuft die komplette Story
        for (int i = 0; i < players.Count; i++)
        {
            var player = players[i];
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
            Console.WriteLine($"║         JETZT SPIELT: {player.Name.ToUpper().PadRight(40)}║");
            Console.WriteLine("╚═══════════════════════════════════════════════════════════╝");
            Console.ResetColor();
            Thread.Sleep(3000);
            
            currentPlayer = player;
            PlayStory(player);
            
            // Dynastie-Weitergabe im Multiplayer
            if (player.Kinder.Count > 0)
            {
                Console.WriteLine($"\n>> {player.Name} hat Kinder!");
                Console.WriteLine("[1] Dynastie an Erben weitergeben");
                Console.WriteLine("[2] Mit diesem Charakter abschließen");
                Console.Write("\nWähle [1-2]: ");
                
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    var heir = DeathSystem.SelectHeir(player);
                    if (heir != null)
                    {
                        Console.WriteLine($"\n>> {heir.Name} übernimmt die Dynastie von {player.Name}!");
                        Thread.Sleep(3000);
                        
                        // Speichere Erben und ersetze Spieler in Liste
                        SaveGame(heir);
                        players[i] = heir;
                        
                        Console.WriteLine($"\n>> Möchtest du mit {heir.Name} weiterspielen? [J/N]");
                        if (Console.ReadKey(true).Key == ConsoleKey.J)
                        {
                            Console.WriteLine("\n\n>> Die Dynastie geht weiter...");
                            Thread.Sleep(2000);
                            currentPlayer = heir;
                            PlayStory(heir);
                        }
                    }
                }
            }
            else
            {
                SaveGame(player);
            }
            
            Console.WriteLine($"\n>> {player.Name} hat seine Runde beendet!");
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
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("[1] 😊 LEICHT");
        Console.ResetColor();
        Console.WriteLine("    → Alle Attribute bei 1, +800 Rubel, gute Beziehungen");
        Console.WriteLine("    → Sanktionen: -25% Schaden\n");
        
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("[2] ⚖️  MITTEL (Empfohlen)");
        Console.ResetColor();
        Console.WriteLine("    → 3 Attributpunkte verteilen, +500 Rubel");
        Console.WriteLine("    → Normale Schwierigkeit\n");
        
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("[3] 💪 HART");
        Console.ResetColor();
        Console.WriteLine("    → 2 Punkte, 70% Gesundheit, -200 Rubel Schulden");
        Console.WriteLine("    → Sanktionen: +35% Schaden, Events +25% härter\n");
        
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("[4] ☠️  KALTER KRIEG (Experten)");
        Console.ResetColor();
        Console.WriteLine("    → 1 Punkt, -500 Rubel Schulden, +40% KGB");
        Console.WriteLine("    → Sanktionen: +60% Schaden, Events +50% härter");
        Console.WriteLine("    → NATO/USA fast Kriegszustand\n");
        
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
                player.Geld = -200; // Schulden statt Geld
                player.NATOBeziehung = 15; // Feindliche NATO-Beziehung
                player.USABeziehung = 25; // Feindliche USA-Beziehung
                player.Kraft = -1; // Schwäche durch harte Kindheit
                Console.WriteLine("HART: -30 Gesundheit | -200 Rubel Schulden | Feindliche Auslandsbeziehungen | -1 Kraft");
                Console.WriteLine("Sanktionen: +35% Schaden | Ereignisse: +25% härter");
                Thread.Sleep(3000);
                break;
            case 4: // Kalter Krieg - EXTREM SCHWER
                points = 1;
                player.Geld = -500; // Massive Schulden
                player.EinflussKGB = 40; // Viel höhere KGB-Kontrolle
                player.NATOBeziehung = 5; // Nahezu Kriegszustand
                player.USABeziehung = 10; // Extreme Feindschaft
                player.Gesundheit = 60; // Schwache Gesundheit
                player.Kraft = -1; // Körperliche Schwäche
                player.LoyalitätVolk = 30; // Volk leidet
                Console.WriteLine("KALTER KRIEG: -500 Rubel Schulden | -40 Gesundheit | -1 Kraft");
                Console.WriteLine("+40% KGB-Kontrolle | NATO/USA fast Kriegszustand | Volk leidet");
                Console.WriteLine("Sanktionen: +60% Schaden | Ereignisse: +50% härter | KGB-Anrufe +100%");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("⚠ EXTREM SCHWIERIG - Nur für Experten!");
                Console.ResetColor();
                Thread.Sleep(4000);
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
        Thread.Sleep(3000);
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
    // Shortcuts wurden entfernt - stattdessen gibt es jetzt das 10-Jahres-Menü
    
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
        Thread.Sleep(3000);
        
        // Zufallsereignis auslösen
        EventSystem.TriggerRandomEvent(player);
        
        Console.WriteLine("[1] Kämpferische Kindheit (+2 Stärke, -15 Gesundheit)");
        Console.WriteLine("[2] Disziplin durch Sport (+2 Kraft, +1 Charisma)");
        Console.WriteLine("[3] Wissbegierig (+3 Intelligenz, +1 Charisma)");
        
        Console.Write("Wähle [1-3]: ");
        string choice = Console.ReadLine();
        if (choice == "1") { player.Stärke += 2; player.Gesundheit -= 15; }
        else if (choice == "2") { player.Kraft += 2; player.Charisma++; }
        else { player.Intelligenz += 3; player.Charisma++; }
        
        // KGB Easter Egg erscheint jetzt IMMER (nicht mehr selten)
        player.KGBEasterEgg = true;
        Console.WriteLine($"\n💀 Ein KGB-Agent beobachtet {player.GetFirstName()}...");
        Thread.Sleep(3500);
        
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
        Thread.Sleep(3000);
        
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
        
        Thread.Sleep(3500);
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
        
        Thread.Sleep(3000);
        ShowStats(player);
        Console.ReadKey(true);
    }
    
    /// <summary>
    /// Show5YearMenu - Zeigt alle 5 Jahre Menü mit Laden/Speichern, Shop und Telefonate
    /// Nur Telefonate und Shop sind in Präsidenten-Phase verfügbar
    /// </summary>
    static void Show5YearMenu(PlayerCharacter player)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(@"
╔═══════════════════════════════════════════════════════════╗
║           📅 5-JAHRES-CHECKPOINT 📅                       ║
╚═══════════════════════════════════════════════════════════╝
");
        Console.ResetColor();
        
        Console.WriteLine($"\n🎭 {player.Name}, Alter {player.Alter}");
        Console.WriteLine($"💰 Geld: {player.Geld} Rubel | ❤️  Gesundheit: {player.Gesundheit}%");
        Console.WriteLine($"📊 Phase: {player.Phase}\n");
        
        bool istPraesident = (player.Phase == "Präsident");
        
        while (true)
        {
            Console.WriteLine("═══════════════════════════════════════════════════════════");
            Console.WriteLine("[1] 💾 Spiel speichern");
            Console.WriteLine("[2] 📂 Spiel laden");
            
            if (istPraesident)
            {
                Console.WriteLine("[3] 📞 Telefonate (Erdogan, Trump, China)");
                Console.WriteLine("[4] 🛒 Flads Luxus-Shop");
                Console.WriteLine("[5] ✅ Weiter spielen");
            }
            else
            {
                Console.WriteLine("[3] ✅ Weiter spielen");
            }
            
            Console.WriteLine("═══════════════════════════════════════════════════════════");
            Console.Write($"\nWähle [1-{(istPraesident ? "5" : "3")}]: ");
            
            string choice = Console.ReadLine();
            
            if (choice == "1")
            {
                Console.WriteLine("\n>> Spiel wird gespeichert...");
                SaveGame(player);
                Console.WriteLine("✓ Gespeichert!");
                Thread.Sleep(2000);
                Console.Clear();
                Console.WriteLine($"\n🎭 {player.Name}, Alter {player.Alter}");
                Console.WriteLine($"💰 Geld: {player.Geld} Rubel | ❤️  Gesundheit: {player.Gesundheit}%");
                Console.WriteLine($"📊 Phase: {player.Phase}\n");
            }
            else if (choice == "2")
            {
                Console.WriteLine("\n⚠️  Laden beendet das aktuelle Spiel.");
                Console.Write("Wirklich laden? [J/N]: ");
                string confirm = Console.ReadLine()?.ToUpper();
                if (confirm == "J")
                {
                    LoadGame();
                    return;
                }
                Console.Clear();
                Console.WriteLine($"\n🎭 {player.Name}, Alter {player.Alter}");
                Console.WriteLine($"💰 Geld: {player.Geld} Rubel | ❤️  Gesundheit: {player.Gesundheit}%");
                Console.WriteLine($"📊 Phase: {player.Phase}\n");
            }
            else if (choice == "3" && istPraesident)
            {
                ShowPhoneMenu(player);
                Console.Clear();
                Console.WriteLine($"\n🎭 {player.Name}, Alter {player.Alter}");
                Console.WriteLine($"💰 Geld: {player.Geld} Rubel | ❤️  Gesundheit: {player.Gesundheit}%");
                Console.WriteLine($"📊 Phase: {player.Phase}\n");
            }
            else if (choice == "4" && istPraesident)
            {
                FladShop.ShowShop(player);
                Console.Clear();
                Console.WriteLine($"\n🎭 {player.Name}, Alter {player.Alter}");
                Console.WriteLine($"💰 Geld: {player.Geld} Rubel | ❤️  Gesundheit: {player.Gesundheit}%");
                Console.WriteLine($"📊 Phase: {player.Phase}\n");
            }
            else if ((choice == "5" && istPraesident) || (choice == "3" && !istPraesident))
            {
                Console.WriteLine("\n>> Weiter geht's!");
                Thread.Sleep(1000);
                return;
            }
            else
            {
                Console.WriteLine("\n❌ Ungültige Eingabe!");
                Thread.Sleep(1500);
                Console.Clear();
                Console.WriteLine($"\n🎭 {player.Name}, Alter {player.Alter}");
                Console.WriteLine($"💰 Geld: {player.Geld} Rubel | ❤️  Gesundheit: {player.Gesundheit}%");
                Console.WriteLine($"📊 Phase: {player.Phase}\n");
            }
        }
    }
    
    /// <summary>
    /// ShowPhoneMenu - Telefonate mit Staatschefs
    /// </summary>
    static void ShowPhoneMenu(PlayerCharacter player)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(@"
╔═══════════════════════════════════════════════════════════╗
║                  📞 TELEFONATE 📞                          ║
╚═══════════════════════════════════════════════════════════╝
");
        Console.ResetColor();
        
        while (true)
        {
            Console.WriteLine("\n═══════════════════════════════════════════════════════════");
            Console.WriteLine($"[1] 🇹🇷 Erdogan anrufen ({player.ErdoganAnrufeVerfügbar}/5 verfügbar)");
            Console.WriteLine($"[2] 🇺🇸 Trump anrufen ({(player.TrumpTelefonAktiv ? player.TrumpAnrufeVerfügbar + "/3" : "nicht freigeschaltet")})");
            Console.WriteLine($"[3] 🇨🇳 China anrufen ({(player.ChinaTelefonAktiv ? player.ChinaAnrufeVerfügbar + "/3" : "nicht freigeschaltet")})");
            Console.WriteLine("[4] ⬅️  Zurück");
            Console.WriteLine("═══════════════════════════════════════════════════════════");
            Console.Write("\nWähle [1-4]: ");
            
            string choice = Console.ReadLine();
            
            if (choice == "1" && player.ErdoganAnrufeVerfügbar > 0)
            {
                ErdoganHotline.ShowHotlineMenu(player);
                Console.Clear();
            }
            else if (choice == "2" && player.TrumpTelefonAktiv && player.TrumpAnrufeVerfügbar > 0)
            {
                TrumpHotline.CallTrump(player);
                Console.Clear();
            }
            else if (choice == "3" && player.ChinaTelefonAktiv && player.ChinaAnrufeVerfügbar > 0)
            {
                ChinaHotline.CallChina(player);
                Console.Clear();
            }
            else if (choice == "4")
            {
                return;
            }
            else
            {
                Console.WriteLine("\n❌ Nicht verfügbar oder keine Anrufe mehr!");
                Thread.Sleep(1500);
                Console.Clear();
            }
        }
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
            Console.WriteLine("   'Q' = Flads Shop\n");
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
        
        // Shortcuts entfernt
        
        // Zufallsereignis
        EventSystem.TriggerRandomEvent(player);
        Console.Clear();
        Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
        Console.WriteLine("║              EINSATZ IN DER DDR (1989)                    ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════╝\n");
        
        Console.WriteLine("Dresden, 1989: Demonstranten vor dem KGB-Gebäude!\n");
        Thread.Sleep(3000);
        
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
        
        Thread.Sleep(3500);
        ShowStats(player);
        Console.ReadKey(true);
    }
    
    static void PlayPresidentPhase(PlayerCharacter player)
    {
        // PRÄSIDENT
        player.Alter = 48;
        player.Phase = "Präsident";
        
        // ZUERST: Zeige historische Events für dieses Jahr (chronologisch)
        int currentYear = player.GetCurrentYear();
        EventSystem.ShowHistoricalEventsForYear(player, currentYear);
        
        // DANN: Zufallsereignis
        EventSystem.TriggerRandomEvent(player);
        Console.Clear();
        Console.WriteLine("╔═══════════════════════════════════════════════════════════╗");
        Console.WriteLine("║       AUFSTIEG ZUM PRÄSIDENTEN (2000)                     ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════╝\n");
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(">> FLAD WIRD PRÄSIDENT VON RUSSLAND!");
        Console.ResetColor();
        Thread.Sleep(3500);
        
        // Hochzeit anbieten
        if (!player.IstVerheiratet)
        {
            Console.WriteLine("\n>> Als Präsident sollte Flad heiraten...");
            Thread.Sleep(2500);
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
            
            // TELEFONATE: Prüfe historische Anrufe für dieses Jahr
            CheckTelefonateForYear(player);
            
            // SIDECHICK-SYSTEM: Prüfe alle 10 Jahre
            CheckSidechickEvent(player);
            
            // VATERSCHAFTSTEST: Prüfe versteckte Kinder nach 18 Jahren
            CheckVaterschaftstestEvent(player);
            
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
                Thread.Sleep(3500);
                
                // Erbe startet im Studium
                PlayStoryFromPhase(player, "Jurastudium");
                return;
            }
            
            // MENÜ: Alle 5 Jahre Speichern/Laden/Shop/Telefonate
            if (jahr > 0 && jahr % 5 == 4) // Jahr 4 und 9 (= nach 5 und 10 Jahren)
            {
                Show5YearMenu(player);
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
        Console.WriteLine("\n" + new string('═', 60) + "\n");
        Console.WriteLine("[1] Imperiale Expansion (+50 Militär, -200 Geld)");
        Console.WriteLine("[2] Diplomatie (+300 Geld, +40 International)");
        Console.WriteLine("[3] Eiserne Faust (+40 Partei, -50 Volk)");
        Console.WriteLine();
        
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
        
        Thread.Sleep(2500);
        
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
        
        Thread.Sleep(3500);
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
            Thread.Sleep(3500);
            
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
                        
                        // DYNASTIE WEITERFÜHREN - Starte Spiel mit Erben
                        Console.WriteLine("\n[Drücke eine Taste, um die Dynastie fortzusetzen...]");
                        Console.ReadKey(true);
                        PlayStory(heir);
                    }
                    return;
                }
                
                Thread.Sleep(200);
            }
            
            Console.WriteLine($"\n>> {player.Name} ist {player.Alter} Jahre alt und lebt friedlich weiter.");
            SaveGame(player);
            
            // Nach dem Speichern weiterspielen
            Console.WriteLine("\n[Drücke eine Taste, um weiterzuspielen...]");
            Console.ReadKey(true);
            PlayPresidentPhase(player);
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
                Thread.Sleep(3000);
                SaveGame(heir);
                
                // DYNASTIE WEITERFÜHREN - Starte Spiel mit Erben
                Console.WriteLine("\n[Drücke eine Taste, um die Dynastie mit dem Erben fortzusetzen...]");
                Console.ReadKey(true);
                PlayStory(heir);
            }
        }
        else
        {
            // Speichern und beenden
            SaveGame(player);
            Console.WriteLine("\n>> Auf Wiedersehen!");
            Thread.Sleep(3000);
        }
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
            Thread.Sleep(3000);
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
        Thread.Sleep(3500);
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
            Thread.Sleep(3000);
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
            Thread.Sleep(3000);
            return;
        }
        
        currentPlayer = saveSlots[slot].Character;
        
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n✓ Spiel geladen!");
        Console.ResetColor();
        ShowStats(currentPlayer);
        Thread.Sleep(3500);
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
            Thread.Sleep(3000);
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
                Thread.Sleep(3000);
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
    public static void PlayMusic()
    {
        int tempo = 150;
        
        // ENDLOS-SCHLEIFE - Musik läuft permanent während des Spiels
        while (!stopMusic)
        {
            int[] melody;
            int[] durations;
            
            // Wähle Melodie basierend auf currentMusicTrack
            switch (currentMusicTrack)
            {
                case 1: // Klassische Sowjet-Hymne
                    melody = new int[] { 659, 494, 523, 587, 523, 494, 440, 440, 523, 659 };
                    durations = new int[] { 1, 1, 1, 1, 1, 1, 2, 1, 1, 2 };
                    break;
                    
                case 2: // Katyusha-Variation
                    melody = new int[] { 523, 587, 659, 698, 659, 587, 523, 494, 440, 494, 523, 523 };
                    durations = new int[] { 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 2, 2 };
                    break;
                    
                case 3: // Kalinka-Remix
                    melody = new int[] { 440, 494, 523, 494, 440, 392, 440, 494, 523, 587, 659, 587 };
                    durations = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 2, 1, 2, 2 };
                    break;
                    
                case 4: // Roter Oktober Marsch
                    melody = new int[] { 392, 440, 494, 523, 587, 523, 494, 440, 494, 523, 587, 659, 698, 659 };
                    durations = new int[] { 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 1, 2, 1, 3 };
                    break;
                    
                default:
                    melody = new int[] { 659, 494, 523, 587, 523, 494, 440, 440, 523, 659 };
                    durations = new int[] { 1, 1, 1, 1, 1, 1, 2, 1, 1, 2 };
                    break;
            }
            
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
            // Kurze Pause zwischen Durchläufen
            Thread.Sleep(500);
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
    // Random-Instanz wird von der globalen Program.rand-Variable verwendet
    static Random rand => Program.rand;
    
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
                Thread.Sleep(3000);
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
                    Thread.Sleep(2500);
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
                
                Thread.Sleep(2500);
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("💧 Wasser!");
                Console.ResetColor();
                
                Thread.Sleep(2500);
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
            
            return true;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("💧 Computer verfehlt!");
            Console.ResetColor();
            
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
