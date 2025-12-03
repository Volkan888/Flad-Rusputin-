import re

# Lese die Datei
with open('/app/RiseOfTheNorthborn.cs', 'r', encoding='utf-8') as f:
    content = f.read()

# Finde alle Events mit komplexerem Pattern
pattern = r'historicalEvents\.Add\(new HistoricalEvent\((.*?)\)\);'
matches = re.finditer(pattern, content, re.DOTALL)

extracted_events = []

for match in matches:
    event_text = match.group(1)
    
    # Extrahiere Felder mit regex
    id_match = re.search(r'"([A-Z_0-9]+)"', event_text)
    event_id = id_match.group(1) if id_match else "UNKNOWN"
    
    # Extrahiere Jahr (das ist eine Zahl ohne Anführungszeichen)
    year_match = re.search(r',\s*(\d{4})\s*,\s*\d{1,2}\s*,', event_text)
    jahr = int(year_match.group(1)) if year_match else 0
    
    # Extrahiere alle Strings
    all_strings = re.findall(r'"([^"]*)"', event_text)
    if len(all_strings) >= 2:
        titel_de = all_strings[1]
        datum_de = all_strings[4] if len(all_strings) > 4 else ""
    else:
        continue
    
    # Extrahiere die deutsche Geschichte (zwischen @" und ")
    story_match = re.search(r'@"([^"]*)"', event_text)
    if story_match:
        geschichte_de = story_match.group(1)
    else:
        geschichte_de = ""
    
    extracted_events.append({
        'id': event_id,
        'titel_de': titel_de,
        'datum_de': datum_de,
        'jahr': jahr,
        'geschichte_de': geschichte_de
    })

print(f"Extrahiert: {len(extracted_events)} Events")

# Sortiere nach Jahr
extracted_events.sort(key=lambda x: x['jahr'])

# Zeiträume
zeitraeume = [
    (1952, 1956, "01_1952-1956"),
    (1957, 1962, "02_1957-1962"),
    (1963, 1969, "03_1963-1969"),
    (1970, 1977, "04_1970-1977"),
    (1978, 1984, "05_1978-1984"),
    (1985, 1990, "06_1985-1990"),
    (1991, 1997, "07_1991-1997"),
    (1998, 2007, "08_1998-2007"),
    (2008, 2017, "09_2008-2017"),
    (2018, 2025, "10_2018-2025")
]

# Erstelle die Dateien
for von, bis, filename in zeitraeume:
    events_in_range = [e for e in extracted_events if von <= e['jahr'] <= bis]
    
    with open(f'/app/translations/deutsch/{filename}.txt', 'w', encoding='utf-8') as f:
        f.write('═' * 70 + '\n')
        f.write(f'  HISTORISCHE EVENTS {von}-{bis}\n')
        f.write('═' * 70 + '\n\n')
        f.write(f'ANZAHL EVENTS: {len(events_in_range)}\n\n')
        f.write('ANLEITUNG:\n')
        f.write('1. Übersetze die Felder mit [HIER...] / [HERE...]\n')
        f.write('2. Behalte das Format GENAU bei!\n')
        f.write('3. Kopiere die übersetzten Dateien nach russisch/ und englisch/\n')
        f.write('4. Russische Datums: "5 марта 1953 года"\n')
        f.write('5. Englische Datums: "March 5, 1953"\n\n')
        f.write('═' * 70 + '\n\n')
        
        for i, ev in enumerate(events_in_range, 1):
            f.write(f'[EVENT_{i:03d}_START]\n')
            f.write(f'ID: {ev["id"]}\n')
            f.write(f'JAHR: {ev["jahr"]}\n\n')
            f.write(f'TITEL_DE: {ev["titel_de"]}\n')
            f.write(f'TITEL_RU: [HIER RUSSISCHE ÜBERSETZUNG]\n')
            f.write(f'TITEL_EN: [HERE ENGLISH TRANSLATION]\n\n')
            f.write(f'DATUM_DE: {ev["datum_de"]}\n')
            f.write(f'DATUM_RU: [HIER RUSSISCHES DATUM]\n')
            f.write(f'DATUM_EN: [HERE ENGLISH DATE]\n\n')
            f.write(f'GESCHICHTE_DE:\n{ev["geschichte_de"]}\n\n')
            f.write(f'GESCHICHTE_RU:\n[HIER RUSSISCHE GESCHICHTE]\n\n')
            f.write(f'GESCHICHTE_EN:\n[HERE ENGLISH STORY]\n\n')
            f.write(f'[EVENT_{i:03d}_END]\n')
            f.write('\n' + '─' * 70 + '\n\n')
    
    print(f"✓ {filename}.txt ({len(events_in_range)} Events)")

print("\n✅ FERTIG! Alle 10 Dateien im Ordner /app/translations/deutsch/")
