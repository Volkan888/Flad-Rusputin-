using System;

/// <summary>
/// HistoricalEvent - Historische/Politische/Wirtschaftliche Ereignisse mit genauem Datum
/// Diese Events erscheinen CHRONOLOGISCH und GARANTIERT (nicht zufällig!)
/// </summary>
public class HistoricalEvent
{
    public string ID;                      // Eindeutige ID (z.B. "UDSSR_ZERFALL_1991")
    public string NameDE, NameRU, NameEN;  // Titel in 3 Sprachen
    public string DatumDE, DatumRU, DatumEN;  // Datum in 3 Sprachen
    public int Jahr;                       // Jahr für Sortierung
    public int Monat;                      // Monat für Sortierung (1-12)
    public string GeschichteDE, GeschichteRU, GeschichteEN;  // Geschichte in 3 Sprachen
    public string Kategorie;               // "POLITIK", "WIRTSCHAFT", "KRIEG", "KATASTROPHE"
    public Action<PlayerCharacter> Auswirkungen;  // Effekte auf Spieler
    
    public HistoricalEvent(string id, string nameDE, string nameRU, string nameEN, 
                          string datumDE, string datumRU, string datumEN,
                          int jahr, int monat, string kategorie, 
                          string geschichteDE, string geschichteRU, string geschichteEN,
                          Action<PlayerCharacter> auswirkungen)
    {
        ID = id;
        NameDE = nameDE;
        NameRU = nameRU;
        NameEN = nameEN;
        DatumDE = datumDE;
        DatumRU = datumRU;
        DatumEN = datumEN;
        Jahr = jahr;
        Monat = monat;
        GeschichteDE = geschichteDE;
        GeschichteRU = geschichteRU;
        GeschichteEN = geschichteEN;
        Kategorie = kategorie;
        Auswirkungen = auswirkungen;
    }
    
    // Helper-Methoden um aktuelle Sprache zu bekommen
    public string GetName()
    {
        switch (EventSystem.currentLanguage)
        {
            case "RU": return NameRU;
            case "EN": return NameEN;
            default: return NameDE;
        }
    }
    
    public string GetDatum()
    {
        switch (EventSystem.currentLanguage)
        {
            case "RU": return DatumRU;
            case "EN": return DatumEN;
            default: return DatumDE;
        }
    }
    
    public string GetGeschichte()
    {
        switch (EventSystem.currentLanguage)
        {
            case "RU": return GeschichteRU;
            case "EN": return GeschichteEN;
            default: return GeschichteDE;
        }
    }
}

/// <summary>
/// RandomEvent - Zufällige Ereignisse während des Spiels
/// </summary>
public class RandomEvent
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
