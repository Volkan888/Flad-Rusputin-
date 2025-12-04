#!/bin/bash
# Ändert "Putin" zu "Flad" wo es den Spieler betrifft (nicht historische Fakten)

cd /app

# Backup
cp RiseOfTheNorthborn.cs RiseOfTheNorthborn_before_putin_fix.cs

# 1. "Putin wird Premierminister" → "Flad wird Premierminister"
sed -i 's/Putin wird Premierminister/Flad wird Premierminister/g' RiseOfTheNorthborn.cs

# 2. "Putin übernimmt" → "Flad übernimmt"  
sed -i 's/Putin übernimmt/Flad übernimmt/g' RiseOfTheNorthborn.cs

# 3. "Putin wird zum Präsidenten" → "Flad wird zum Präsidenten"
sed -i 's/Putin wird zum Präsidenten/Flad wird zum Präsidenten/g' RiseOfTheNorthborn.cs

# 4. "Putin gewinnt" → "Flad gewinnt"
sed -i 's/Putin gewinnt/Flad gewinnt/g' RiseOfTheNorthborn.cs

# 5. "Putin bleibt" → "Flad bleibt"
sed -i 's/Putin bleibt/Flad bleibt/g' RiseOfTheNorthborn.cs

# 6. "Putin trifft" → "Flad trifft"
sed -i 's/Putin trifft/Flad trifft/g' RiseOfTheNorthborn.cs

# 7. "Putin unterstützt" → "Flad unterstützt"  
sed -i 's/Putin unterstützt/Flad unterstützt/g' RiseOfTheNorthborn.cs

# 8. "Putin schafft" → "Flad schafft"
sed -i 's/Putin schafft/Flad schafft/g' RiseOfTheNorthborn.cs

# 9. "Putins" → "Flads"
sed -i 's/Putins /Flads /g' RiseOfTheNorthborn.cs

# 10. "Putin hält" → "Flad hält"
sed -i 's/Putin hält/Flad hält/g' RiseOfTheNorthborn.cs

# 11. "Putin darf" → "Flad darf"
sed -i 's/Putin darf/Flad darf/g' RiseOfTheNorthborn.cs

# 12. "Putin verkündet" → "Flad verkündet"
sed -i 's/Putin verkündet/Flad verkündet/g' RiseOfTheNorthborn.cs

# 13. "Putin nennt" → "Flad nennt"
sed -i 's/Putin nennt/Flad nennt/g' RiseOfTheNorthborn.cs

# 14. "Putin erhöht" → "Flad erhöht"
sed -i 's/Putin erhöht/Flad erhöht/g' RiseOfTheNorthborn.cs

# 15. "Putin ändert" → "Flad ändert"
sed -i 's/Putin ändert/Flad ändert/g' RiseOfTheNorthborn.cs

# 16. "Putin testet" → "Flad testet"
sed -i 's/Putin testet/Flad testet/g' RiseOfTheNorthborn.cs

# 17. "Putin kann" → "Flad kann"
sed -i 's/Putin kann/Flad kann/g' RiseOfTheNorthborn.cs

# 18. Weichen für Putin → Weichen für Flad
sed -i 's/Weichen für Putin/Weichen für Flad/g' RiseOfTheNorthborn.cs

# 19. Premierminister Putin → Premierminister Flad
sed -i 's/Premierminister Putin /Premierminister Flad /g' RiseOfTheNorthborn.cs

# 20. widersetzt, fällt → widersetzt Flad
sed -i 's/Wer sich Putin widersetzt/Wer sich Flad widersetzt/g' RiseOfTheNorthborn.cs

# 21. beschuldigte vorher Putin → beschuldigte vorher Flad
sed -i 's/beschuldigte vorher Putin/beschuldigte vorher Flad/g' RiseOfTheNorthborn.cs

# 22. Die Macht bleibt bei Putin → Die Macht bleibt bei Flad
sed -i 's/Die Macht bleibt bei Putin/Die Macht bleibt bei Flad/g' RiseOfTheNorthborn.cs
sed -i 's/Putin hat weiter das Sagen/Flad hat weiter das Sagen/g' RiseOfTheNorthborn.cs

# 23. Protest gegen Putin
sed -i 's/gegen Putin/gegen Flad/g' RiseOfTheNorthborn.cs
sed -i 's/Putin muss/Flad muss/g' RiseOfTheNorthborn.cs

# 24. Putin annektiert
sed -i 's/Putin annektiert/Flad annektiert/g' RiseOfTheNorthborn.cs

# 25. Konkrete Event-IDs ändern
sed -i 's/PUTIN_PREMIER_1999/FLAD_PREMIER_1999/g' RiseOfTheNorthborn.cs
sed -i 's/PUTIN_PRAESIDENT_2000/FLAD_PRAESIDENT_2000/g' RiseOfTheNorthborn.cs
sed -i 's/PUTIN_BUSH_2001/FLAD_BUSH_2001/g' RiseOfTheNorthborn.cs
sed -i 's/PUTIN_GOUVERNEURE_2004/FLAD_GOUVERNEURE_2004/g' RiseOfTheNorthborn.cs

# 26. In Texten
sed -i 's/der bis dahin kaum bekannte Putin/der bis dahin kaum bekannte Flad/g' RiseOfTheNorthborn.cs
sed -i 's/amtierender Präsident Putin/amtierender Präsident Flad/g' RiseOfTheNorthborn.cs

# 27. Putin-Kritiker → Flad-Kritiker
sed -i 's/Putin-Kritiker/Flad-Kritiker/g' RiseOfTheNorthborn.cs

# 28. Putin-Medwedew → Flad-Medwedew
sed -i 's/Putin-Medwedew/Flad-Medwedew/g' RiseOfTheNorthborn.cs

echo "✓ Putin → Flad Konvertierung abgeschlossen"
