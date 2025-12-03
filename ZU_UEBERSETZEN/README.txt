═══════════════════════════════════════════════════════════════════
  ÜBERSETZUNGS-ORDNER
═══════════════════════════════════════════════════════════════════

📁 STRUKTUR:

/app/translations/
├── deutsch/     ✅ 10 Dateien mit deutschen Texten (FERTIG)
├── russisch/    ⏳ LEER - du fügst russische Übersetzungen ein
└── englisch/    ⏳ LEER - du fügst englische Übersetzungen ein

═══════════════════════════════════════════════════════════════════
  INHALT
═══════════════════════════════════════════════════════════════════

✅ DEUTSCH-ORDNER (fertig):
   01_1952-1956.txt  (17 Events) - Stalin, Korea, Beria, Ungarn
   02_1957-1962.txt  (17 Events) - Sputnik, Gagarin, Kuba, Mauer
   03_1963-1969.txt  (22 Events) - Kennedy, Tereschkowa, Prag
   04_1970-1977.txt  (24 Events) - Breschnew, SALT I, Helsinki
   05_1978-1984.txt  (21 Events) - Afghanistan, Andropow, KAL007
   06_1985-1990.txt  (19 Events) - Gorbatschow, Tschernobyl, Mauerfall
   07_1991-1997.txt  (18 Events) - UdSSR-Ende, Jelzin, Tschetschenien
   08_1998-2007.txt  (23 Events) - Rubelkrise, Putin, Kursk, Beslan
   09_2008-2017.txt  (20 Events) - Georgien, Krim, Syrien, Nemzow
   10_2018-2025.txt  (13 Events) - WM, Nawalny, Ukraine, Prigoschin

   GESAMT: 194 Events

═══════════════════════════════════════════════════════════════════
  SO ÜBERSETZT DU
═══════════════════════════════════════════════════════════════════

SCHRITT 1: Übersetze die deutschen Dateien
   - Öffne eine Datei aus deutsch/ (z.B. 01_1952-1956.txt)
   - Ersetze alle [HIER...] und [HERE...] mit Übersetzungen
   - Behalte das Format GENAU bei!

SCHRITT 2: Russische Übersetzung
   - Kopiere die übersetzte Datei nach russisch/
   - Lösche die deutschen und englischen Texte
   - Behalte nur: ID, JAHR, TITEL_RU, DATUM_RU, GESCHICHTE_RU
   
   Beispiel für russisch/01_1952-1956.txt:
   
   [EVENT_001_START]
   ID: STALIN_NOTE_1952
   JAHR: 1952
   TITEL_RU: Сталинская нота об объединении Германии
   DATUM_RU: 10 марта 1952 года
   GESCHICHTE_RU: Сталин предлагает западным державам...
   [EVENT_001_END]

SCHRITT 3: Englische Übersetzung
   - Kopiere die übersetzte Datei nach englisch/
   - Lösche die deutschen und russischen Texte
   - Behalte nur: ID, JAHR, TITEL_EN, DATUM_EN, GESCHICHTE_EN
   
   Beispiel für englisch/01_1952-1956.txt:
   
   [EVENT_001_START]
   ID: STALIN_NOTE_1952
   JAHR: 1952
   TITEL_EN: Stalin Note on German Reunification
   DATUM_EN: March 10, 1952
   GESCHICHTE_EN: Stalin offers the Western powers...
   [EVENT_001_END]

═══════════════════════════════════════════════════════════════════
  WICHTIG: FORMAT BEIBEHALTEN!
═══════════════════════════════════════════════════════════════════

✅ RICHTIG:
[EVENT_001_START]
ID: STALIN_NOTE_1952
JAHR: 1952
TITEL_RU: Сталинская нота
DATUM_RU: 10 марта 1952 года
GESCHICHTE_RU: Текст...
[EVENT_001_END]

❌ FALSCH:
- Keine [EVENT_START] / [EVENT_END] Tags
- ID fehlt
- Falsche Feldnamen
- Zusätzliche Leerzeilen

═══════════════════════════════════════════════════════════════════
  DATUMS-FORMATE
═══════════════════════════════════════════════════════════════════

Deutsch:  5. März 1953
Russisch: 5 марта 1953 года
Englisch: March 5, 1953

Russische Monatsnamen (Genitiv):
января, февраля, марта, апреля, мая, июня,
июля, августа, сентября, октября, ноября, декабря

═══════════════════════════════════════════════════════════════════
  NACH DER ÜBERSETZUNG
═══════════════════════════════════════════════════════════════════

Wenn alle Dateien übersetzt sind, sage mir Bescheid!
Ich erstelle dann ein Script, das die Übersetzungen automatisch
zurück in die Haupt-Datei RiseOfTheNorthborn.cs einfügt.

═══════════════════════════════════════════════════════════════════
  TIPP
═══════════════════════════════════════════════════════════════════

Du kannst auch erstmal nur 1-2 Dateien übersetzen zum Testen!
z.B. nur 01_1952-1956.txt mit den wichtigsten Events.

═══════════════════════════════════════════════════════════════════
