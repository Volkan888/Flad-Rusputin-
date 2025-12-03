#!/usr/bin/env python3
"""
Entfernt Duplikate aus den historischen Events
"""

# Putin 2000 Duplikate (Zeilen zu entfernen)
duplicates_to_remove = [
    7336,  # RandomEvent Putin 2000 doppelt
    8811,  # Nawalny stirbt doppelt (Random Event)
]

with open('/app/RiseOfTheNorthborn.cs', 'r', encoding='utf-8') as f:
    lines = f.readlines()

# Zeilen löschen (von oben nach unten, damit Zeilennummern stimmen)
for line_num in sorted(duplicates_to_remove, reverse=True):
    if line_num <= len(lines):
        print(f"Entferne Zeile {line_num}: {lines[line_num-1][:80]}...")
        del lines[line_num-1]

# Speichern
with open('/app/RiseOfTheNorthborn.cs', 'w', encoding='utf-8') as f:
    f.writelines(lines)

print("\n✓ Duplikate entfernt!")
