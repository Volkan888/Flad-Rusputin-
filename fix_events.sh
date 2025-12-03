#!/bin/bash
cd /app

# Fix line 1728 - Already correct with lambda
sed -i '1728s/.*/            p => $"{p.GetFirstName()} verliert seinen Bruder durch Krankheit. Ein traumatisches Ereignis...",/' RiseOfTheNorthborn.cs

# Fix line 1774
sed -i '1774s/.*/            "Pionier-Auszeichnung im Roten Halstuch!",/' RiseOfTheNorthborn.cs
sed -i '1776a\                Console.WriteLine($"{p.GetFirstName()} wird feierlich ausgezeichnet!");' RiseOfTheNorthborn.cs

# Fix line 1785
sed -i '1785s/.*/            "Aufstieg in der Komsomol-Hierarchie!",/' RiseOfTheNorthborn.cs
sed -i '1787a\                Console.WriteLine($"{p.GetFirstName()} wird zum Anführer gewählt!");' RiseOfTheNorthborn.cs

# Fix line 1828
sed -i '1828s/.*/            "Stadtmeisterschaft im Judo gewonnen!",/' RiseOfTheNorthborn.cs
sed -i '1830a\                Console.WriteLine($"{p.GetFirstName()} gewinnt die Stadtmeisterschaft!");' RiseOfTheNorthborn.cs

# Fix line 1870
sed -i '1870s/.*/            "Erster Feldauftrag: Observierung von Intellektuellen",/' RiseOfTheNorthborn.cs
sed -i '1872a\                Console.WriteLine($"{p.GetFirstName()} erhält ersten Feldauftrag!");' RiseOfTheNorthborn.cs

# Fix line 1942
sed -i '1942s/.*/            "Hochkarätiger westlicher Offizier rekrutiert!",/' RiseOfTheNorthborn.cs
sed -i '1944a\                Console.WriteLine($"{p.GetFirstName()} rekrutiert Offizier erfolgreich!");' RiseOfTheNorthborn.cs

# Fix Console.WriteLines
sed -i '2060s/.*Console.WriteLine("p => \$"{p.GetFirstName()}/                    Console.WriteLine($"{p.GetFirstName()}/' RiseOfTheNorthborn.cs
sed -i '2199s/.*Console.WriteLine("p => \$"{p.GetFirstName()}/                Console.WriteLine($"{p.GetFirstName()}/' RiseOfTheNorthborn.cs
sed -i '2233s/.*Console.WriteLine("p => \$"{p.GetFirstName()}/                Console.WriteLine($"{p.GetFirstName()}/' RiseOfTheNorthborn.cs
