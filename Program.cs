using System.Text;
using vizsgazok_console;

var vizsgazok = Vizsgazo.LoadFromJSON("vizsgazok.json");


//4. feladat
Console.Write("Kérlek, adj meg egy névkezdetet: ");
string keresettNev = Console.ReadLine()?.ToLower() ?? "";

var talalatok = vizsgazok.FindAll(v => v.name.ToLower().StartsWith(keresettNev));

if (talalatok.Count > 0)
{
    foreach (var vizsgazo in talalatok)
    {
        Console.WriteLine($"{vizsgazo.name}, {vizsgazo.score} pont, tantárgy: {vizsgazo.subject}");
    }
}
else
{
    Console.WriteLine("Nem található a megadott névvel vizsgázó!");
}


//5. feladat
var csoportositas = vizsgazok.GroupBy(v => v.name[0]).OrderBy(g => g.Key).ToDictionary(g => g.Key, g => g.ToList());

StringBuilder tartalom = new StringBuilder();

foreach (var csoport in csoportositas)
{
    tartalom.AppendLine($"[{csoport.Key}] - {csoport.Value.Count} vizsgázó");
    foreach (var vizsgazo in csoport.Value)
    {
        tartalom.AppendLine($"{vizsgazo.name}, {vizsgazo.score} éves, tantárgy: {vizsgazo.subject}");
    }
    tartalom.AppendLine();
}

try
{
    File.WriteAllText("csoportositott_vizsgazok.txt", tartalom.ToString());
    Console.WriteLine("A fájl sikeresen létrehozva!");
}
catch (Exception)
{
    Console.WriteLine("A fájl írása sikertelen!");
}