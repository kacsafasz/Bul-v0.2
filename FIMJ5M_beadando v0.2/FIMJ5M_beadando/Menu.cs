using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIMJ5M_beadando
{
    class Menu
    {                                   // lehetne vezérlő osztály. Minden szöveget áthelyezni ide. Minden statikus.
        public static void Fomenu()
        {
            Console.WriteLine("Kérem válassza ki, hogy az alábbi opciók közül melyiket szeretné:");
            Console.WriteLine("1: Új játék kezdete");
            Console.WriteLine("2: Játék mentése");
            Console.WriteLine("3: Játék betöltése");
            Console.WriteLine("4. Vissza a játékba");
            Console.WriteLine("Egyéb szám: Kilépés");
            int dontes = int.Parse(Console.ReadLine());
            switch (dontes)
            {
                case 1:
                    UjJatek();
                    break;
                case 2:
                    // mentés
                    break;
                case 3:
                    // betöltés
                    break;
                case 4:
                    // vissza
                default:
                    Console.WriteLine("A játék bezárul.");
                    break;
            }
            Console.Clear();
        }

        private static void JatekMenu()
        {
            // bábuválasztás és menübe visszalépést ide.    Lépés metódus a tábla osztályban van.
        }

        static void UjJatek()
        {
            JatekosLetrehozas();
            TablaLetrehozas();
            JatekMenu();
        }

        public static void JatekosLetrehozas()
        {
            Console.WriteLine("Első játékos neve");
            Jatek.PirosJatekos = new Jatekos(Console.ReadLine(), false);
            Console.WriteLine("Második játékos neve");
            Jatek.FeherJatekos = new Jatekos(Console.ReadLine(), true);
        }


        public static void TablaLetrehozas()
        {
            int sor, oszlop;
            Console.WriteLine("Tábla mérete(hosszúkás legyen, páros oszlopszámmal):");
            sor = int.Parse(Console.ReadLine());
            oszlop = int.Parse(Console.ReadLine());
            int szamlalo = 1;

            if ((oszlop > sor && oszlop % 2 == 0) && (sor != 0))                // fölösleges
            {
                Console.WriteLine(szamlalo + ". alkalomra kaptam jó táblát");
                Jatek.Tabla = new Tabla(sor, oszlop);
                Jatek.Tabla.Kirajzol();
            }
            else
            {
                do
                {
                    Console.WriteLine("Rossz tábla méret, kérem adjon meg újat:");
                    sor = int.Parse(Console.ReadLine());
                    oszlop = int.Parse(Console.ReadLine());
                    szamlalo++;
                } while (!((oszlop > sor && oszlop % 2 == 0) && (sor != 0)));

                if (oszlop > sor && oszlop % 2 == 0)
                {
                    Console.WriteLine(szamlalo + ". alkalomra kaptam jó táblát");
                    Jatek.Tabla = new Tabla(sor, oszlop);
                    Jatek.Tabla.Kirajzol();
                }
            }
        }

        private static void TablaLetrehozas2()
        {
            Console.WriteLine("Tábla mérete(hosszúkás legyen, páros oszlopszámmal):");
            int sor, oszlop;
            do
            {
                Console.Write("Bábuk száma: ");
                sor = int.Parse(Console.ReadLine());
                Console.Write("Oszlopok száma: ");
                oszlop = int.Parse(Console.ReadLine());
                if (sor == 0 || !(oszlop > sor && oszlop % 2 == 0))
                {
                    Console.WriteLine("Rossz tábla méret, kérem adjon meg újat:");
                }
            } while (!((oszlop > sor && oszlop % 2 == 0) && (sor != 0)));
        }
    }
}
