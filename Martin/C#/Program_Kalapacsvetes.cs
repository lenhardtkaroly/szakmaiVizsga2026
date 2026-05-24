using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KalapacsvetesEloGyak
{
    internal class Program
    {

        static List<Sportolo> adatok = new List<Sportolo>();

        static void Main(string[] args)
        {

            adatbeolvasas();
            feladat4();
            feladat5();
            feladat6();
            feladat7();
            feladat8();

            Console.ReadKey();

        }

        private static void feladat8()
        {
            StreamWriter irocsatorna = new StreamWriter("magyarok.txt");

            foreach (var adat in adatok)
            {
                if (adat.orszagKod == "HUN")
                {
                    irocsatorna.WriteLine($"{adat.helyezes}; {adat.eredmeny}; {adat.sportoloNev}; {adat.orszagKod}; {adat.helyszin}; {adat.datum}");
                }
            }
            irocsatorna.Close();

        }

        private static void feladat7()
        {
            Console.WriteLine("7. feladat: Statisztika");

            var stat = adatok
                .GroupBy(x => x.orszagKod)
                .Select(g => new { Orszag = g.Key, Db = g.Count() })
                .OrderByDescending(x => x.Db);

            foreach (var s in stat)
                Console.WriteLine($"\t{s.Orszag} - {s.Db} dobás");
        }

        private static void feladat6()
        {
            Console.WriteLine("6. feladat: Adjon meg egy évszámot: ");
            string bekertEvszam = Console.ReadLine();

            string ev;
            List<string> sportolok = new List<string>();


            foreach (var adat in adatok)
            {
                ev = adat.datum.Split('.')[0];


                if (ev == bekertEvszam)
                {
                    sportolok.Add(adat.sportoloNev);
                }
            }
            Console.WriteLine($"\t{sportolok.Count} darab dobás került be ebben az évben.");
            for (int i = 0; i < sportolok.Count; i++)
            {
                Console.WriteLine($"\t{sportolok[i]}");
            }


        }

        private static void feladat5()
        {
            double osszMagyarDobas = 0;
            double dobasSzamalalo = 0;

            foreach (var adat in adatok)
            {
                if (adat.orszagKod == "HUN")
                {
                    osszMagyarDobas = osszMagyarDobas + adat.eredmeny;
                    dobasSzamalalo++;
                }
            }
            Console.WriteLine($"5. feladat: A magyar sportolók átlagosan {osszMagyarDobas / dobasSzamalalo} métert dobtak.");

        }

        private static void feladat4()
        {
            Console.WriteLine($"4. feladat: {adatok.Count} dobás eredménye található.");
        }

        private static void adatbeolvasas()
        {
            StreamReader olvasocsatorna = new StreamReader("kalapacsvetes.txt");

            string elsosor = olvasocsatorna.ReadLine();
            string sor;
            string[] darabol;

            while (!olvasocsatorna.EndOfStream)
            {
                sor = olvasocsatorna.ReadLine();

                darabol = sor.Split(';');

                Sportolo adat = new Sportolo(darabol);
                adatok.Add(adat);
            }
            olvasocsatorna.Close();
        }
    }
}
