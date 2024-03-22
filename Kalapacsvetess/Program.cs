using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Kalapacsvetess
{
    internal class Program
    {

        static void Main(string[] args)
        {
            List<Sportolo> sportolok = new List<Sportolo>();
            using (var sr = new StreamReader(@"..\..\..\src\kalapacsvetes.txt"))
            {
                _ = sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    sportolok.Add(new Sportolo(sr.ReadLine()));
                }
            }
            Console.WriteLine($"4.feladat\t:{sportolok.Count()} dobás eredménye található ");

            var magyarDobasok = sportolok.Where(s => s.orszagkod == "HUN").Select(s => s.eredmeny);
            double atlagEredmeny = magyarDobasok.Average();

            Console.WriteLine($"5.feladat\tA magyar sportolók átlaagosan {atlagEredmeny:F2} métert dobtak");

            Console.WriteLine("6.feladat\tAdjon meg egy évszámot:");
            if (int.TryParse(Console.ReadLine(), out int evszam))
            {
                var legjobbak = sportolok.Where(s => s.datum.Year == evszam).OrderByDescending(s => s.eredmeny);
                if (legjobbak.Any())
                {
                    int legjobbakSzama = legjobbak.Count();
                    Console.WriteLine($"{evszam}-ben/ban összesen {legjobbakSzama} dobás került be a legjobbak közé.");
                    Console.WriteLine("Az alábbi sportolók érték el ezeket:");
                    foreach (var sportolo in legjobbak)
                    {
                        Console.WriteLine($"- {sportolo.sportolo} ({sportolo.orszagkod}): {sportolo.eredmeny}");
                    }
                }
                else
                {
                    Console.WriteLine($"{evszam}-ben nem került be egy dobás eredménye sem a legjobbak közé.");
                }
            }
            else
            {
                Console.WriteLine("Hibás évszám formátum.");
            }
            var legjobbakk = sportolok.OrderByDescending(s => s.eredmeny);
            Dictionary<string, int> orszagStatisztika = new Dictionary<string, int>();

            foreach (var sportolo in legjobbakk)
            {
                if (!orszagStatisztika.ContainsKey(sportolo.orszagkod))
                {
                    orszagStatisztika.Add(sportolo.orszagkod, 0);
                }
                orszagStatisztika[sportolo.orszagkod]++;
            }

            Console.WriteLine("\n7.feladat\tStatisztika:");
            foreach (var kvp in orszagStatisztika.OrderByDescending(k => k.Value))
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value} dobás");
            }
            var magyarEredmenyek = sportolok.Where(s => s.orszagkod == "HUN").ToList();
            using (var sw = new StreamWriter(@"..\..\..\src\magyarok.txt"))
            {
                foreach (var sportolo in magyarEredmenyek)
                {
                    sw.WriteLine(sportolo.sportolo);
                }
            }
        }
    }
}

