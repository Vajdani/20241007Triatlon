using vajda_daniel_triatlon;

List<Versenyzo> versenyzok = [];

StreamReader reader = new(path: "../../../forras.txt", encoding: System.Text.Encoding.UTF8);
while (!reader.EndOfStream)
{
    versenyzok.Add(new Versenyzo(reader.ReadLine()!));
}
reader.Close();

Console.WriteLine($"{versenyzok.Count} versenyző fejezte be a versenyt.");
Console.WriteLine($"{versenyzok.Count(p => p.Kategoria == "elit")} versenyző volt az 'elit' kategóriában.");
Console.WriteLine($"A női versenyzők átlagéletkora: {versenyzok.Where(p => !p.Nem).Average(p => DateTime.Now.Year - p.SzuletesiEv):0.00} év");
Console.WriteLine($"A versenyzők kerékpározással töltött összideje: {versenyzok.Sum(p => p.KerekparIdo.TotalSeconds)/60/60:0.00} óra");
Console.WriteLine($"Átlagos úszási idő elit junior kategóriában: {TimeSpan.FromSeconds(versenyzok.Where(p => p.Kategoria == "elit junior").Average(p => p.UszasIdo.TotalSeconds))}");
Console.WriteLine($"Férfi győztes: {versenyzok.Where(p => p.Nem).MinBy(p => (p.UszasIdo + p.Depo1Ido + p.KerekparIdo + p.Depo2Ido + p.FutasIdo).TotalSeconds)}");

Console.WriteLine($"A versenyzők kategóriánként:");
var kategoriak = versenyzok.OrderBy(p => p.Kategoria).GroupBy(p => p.Kategoria);
foreach (var item in kategoriak)
{
    Console.WriteLine($"\t{item.Key}: {item.Count()}");
}

Console.WriteLine($"Kategóriánként az átlagos depóban töltött idő:");
foreach (var item in kategoriak)
{
    Console.WriteLine($"\t{item.Key}: {TimeSpan.FromSeconds(item.Average(p => (p.Depo1Ido + p.Depo1Ido).TotalSeconds))}");
}