using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace kalapacsvetes6
{
    class Program
    {
        static List<Sportolo> adatok = new List<Sportolo>();
        static void Main(string[] args)
        {
            adatbeolvasas();
            feladat05();
            feladat06();
            feladat07();
            feladat08();
            Console.ReadLine();
        }

        private static void feladat08()
        {
            StreamWriter irocsatorna = new StreamWriter("magyarok.txt");
            irocsatorna.WriteLine("Helyezés;Eredmény;Sportoló;Országkód;Helyszín;Dátum");

            foreach (Sportolo adat in adatok)
            {
                if (adat.orszagKod == "HUN")
                {
                    irocsatorna.WriteLine(adat.helyezes+";"+adat.eredmeny+";"+adat.nev+";"+adat.orszagKod+";"+adat.helyszin+";"+adat.datum.ToString("yyyy.MM.dd"));
                }
            }

            irocsatorna.Close();
        }

        private static void feladat07()
        {
            HashSet<string> orszagok = new HashSet<string>();

            foreach (Sportolo adat in adatok)
            {
                orszagok.Add(adat.orszagKod);
            }


            foreach (string orszag in orszagok)
            {
                int dobasokSzama = 0;

                foreach (Sportolo adat in adatok)
                {
                    if (adat.orszagKod == orszag)
                    {
                        dobasokSzama++;
                    }
                }

                Console.WriteLine("{0} - {1} dobás", orszag, dobasokSzama);
            }
            
        }

        private static void feladat06()
        {
            Console.WriteLine("kérek egy évszámot: ");
            int bekert = int.Parse(Console.ReadLine());
            bool talalat = false;

            foreach (Sportolo adat in adatok)
            {
                if (bekert == adat.datum.Year)
                {
                    talalat = true;
                    Console.WriteLine(adat.nev);
                }
            }

            if (!talalat)
            {
                Console.WriteLine("nem volt");
            }
        }

        private static void feladat05()
        {
            double magyar = 0;
            double eredmeny = 0;

            foreach (Sportolo adat in adatok)
            {
                if (adat.orszagKod == "HUN")
                {
                    magyar++;
                    eredmeny = eredmeny + adat.eredmeny;
                }
            }

            Console.WriteLine(eredmeny / magyar);
        }

        private static void adatbeolvasas()
        {
            StreamReader olvasocsatorna = new StreamReader("kalapacsvetes.txt");

            string fejlec = olvasocsatorna.ReadLine();
            string sor;

            while (!olvasocsatorna.EndOfStream)
            {
                sor = olvasocsatorna.ReadLine();
                Sportolo adat = new Sportolo(sor);
                adatok.Add(adat);

            }

            Console.WriteLine(adatok.Count);

            olvasocsatorna.Close();
        }
    }
}
