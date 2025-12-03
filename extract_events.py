import re

# Lese die Datei
with open('/app/RiseOfTheNorthborn.cs', 'r', encoding='utf-8') as f:
    content = f.read()

# Finde alle Events
pattern = r'historicalEvents\.Add\(new HistoricalEvent\((.*?)\)\);'
events = re.findall(pattern, content, re.DOTALL)

print(f"Gefunden: {len(events)} Events")

# Extrahiere die wichtigen Infos aus jedem Event
extracted_events = []
for event in events:
    # Suche nach den einzelnen Feldern
    parts = event.split(',', 11)  # Maximal 11 Kommas bis zu den Geschichten
    
    if len(parts) >= 11:
        event_id = parts[0].strip().strip('"')
        titel_de = parts[1].strip().strip('"')
        datum_de = parts[4].strip().strip('"')
        jahr = parts[7].strip()
        
        # Extrahiere die deutsche Geschichte
        story_match = re.search(r'@"([^"]*)"', parts[10])
        geschichte_de = story_match.group(1) if story_match else ""
        
        extracted_events.append({
            'id': event_id,
            'titel_de': titel_de,
            'datum_de': datum_de,
            'jahr': int(jahr),
            'geschichte_de': geschichte_de
        })

print(f"Extrahiert: {len(extracted_events)} Events")

# Sortiere nach Jahr
extracted_events.sort(key=lambda x: x['jahr'])

# Teile in 10 Dateien auf
events_per_file = len(extracted_events) // 10
print(f"Pro Datei: ca. {events_per_file} Events")

# Zeiträume definieren
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
        f.write('WICHTIG: Behalte das Format genau bei!\n')
        f.write('Jeder Block muss mit [EVENT_START] beginnen und [EVENT_END] enden.\n\n')
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
    
    print(f"✓ {filename}.txt erstellt ({len(events_in_range)} Events)")

print("\nFertig!")
