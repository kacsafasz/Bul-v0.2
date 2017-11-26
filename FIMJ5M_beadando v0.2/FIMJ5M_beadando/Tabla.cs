using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIMJ5M_beadando
{
    class Tabla
    {
        private Babu[,] palya;                  // alapérték null (üres négyzet). Egyéb esetben egy bábu példány referenciája


        public Babu[,] Palya
        {
            get { return palya; }
            set { palya = value; }
        }

        public Tabla(int sor, int oszlop)
        {
            palya = new Babu[sor, oszlop];
            KezdoAllas(sor, oszlop);
        }

        private void KezdoAllas(int sor, int oszlop)                // sor oszlop szükséges?
        {
            for (int i = 0; i < sor; i++)
            {
                Babu B1 = new Babu(i, 0, i, false);                 // első i -> id második i -> sor
                Babu B2 = new Babu(i, oszlop - 1, i, true);         // 0-i id, utolsó oszlop, i. sor
                palya[B1.BabuSOR, B1.BabuOSZLOP] = B1;              // bábuk elhelyezése
                palya[B2.BabuSOR, B2.BabuOSZLOP] = B2;
            }
        }

        public void Lepes(int lepesHossz, Babu babu)
        {

            int celOszlop;
            if ((babu.Foglyok.Length > 0) == babu.BabuSzin)             // Lépjen jobbra:
            {                                                           // ha van foglya (IGAZ) és fehér (IGAZ)     --> Hazamegy.   A saját bázisa jobbra van.
                celOszlop = palya.GetLength(0) + lepesHossz;            // ha nincs foglya (HAMIS) és piros (HAMIS) --> Támad.      Az ellemfél bázisa jobbra van
            }
            else                                                        // Lépjen balra:
            {                                                           // ha nincs foglya (HAMIS) és fehér (IGAZ)  --> Támad.      Az ellenfél bázisa balra van.
                celOszlop = palya.GetLength(1) - lepesHossz;            // ha van foglya (IGAZ) és piros (HAMIS)    --> Hazamegy.   A saját bázisa balra van.
            }

            Babu celBabu = OszloponLevoBabu(celOszlop);
            if ((babu.BabuSzin && celOszlop > (palya.GetLength(1) - 1)) || (!babu.BabuSzin && celOszlop < 0))   // ha egy bábu a bázison túl lép
            {
                hazater;                                                                                                // hazatér
            }
            if (babu.BabuSzin && celOszlop == (palya.GetLength(1) - 1) || (!babu.BabuSzin && celOszlop == 0))   // ha bázisra lép 
            {

            }
            else if (celBabu == null)
            {
                palya[babu.BabuSOR, celOszlop] = babu;                  // felülír
                palya[babu.BabuSOR, babu.BabuSOR] = null;               // előző referencia törlése
                babu.BabuOSZLOP = celOszlop;
            }
            else if (celBabu.BabuSzin == babu.BabuSzin)     // saját bábu helye. Kimarad.
            {
                Jatek.KovetkezoKor();
            }
            else                                                                // ellenséges bábu
            {
                babu.FoglyulEjt(celBabu);                               // foglyul ejt
                palya[celBabu.BabuSOR, celOszlop] = babu;                  // felülír
                palya[babu.BabuSOR, babu.BabuOSZLOP] = null;            // előző referencia törlése
                babu.BabuSOR = celBabu.BabuSOR;
                babu.BabuOSZLOP = celBabu.BabuOSZLOP;
            }
        }


        private void SzabadBabukElhelyezese()
        {

        }

        private Babu OszloponLevoBabu(int oszlop)
        {
            // Az oszlop első bábuját adja vissza, vagy null-t, ha üres
            int i = 0;
            while (i < palya.GetLength(0) && palya[i, oszlop] == null)
            {
                i++;
            }
            if (i < palya.GetLength(0))
            {
                return palya[i, oszlop];
            }
            else
            {
                return null;
            }
        }

        private bool? OszloponLevoBabuSzine(int oszlop)
        {
            // Az oszlop első bábujának színét adja vissza, vagy null-t ha üres.
            int i = 0;
            while (i < palya.GetLength(0) && palya[i, oszlop] == null)
            {
                i++;
            }
            if (i < palya.GetLength(0))
            {
                return palya[i, oszlop].BabuSzin;
            }
            else
            {
                return null;
            }
        }

        public void Kirajzol()
        {
            Console.WriteLine();                            // sortörésnek nem itt a helye
            for (int i = 0; i < palya.GetLength(0); i++)        // i a sor indexe   (0. dimenzió)
            {                
                for (int j = 0; j < palya.GetLength(1); j++)    // j az oszlop indexe   (1. dimenzió)
                {                    
                    if (palya[i, j] != null)        // Lehetne "if fehér" "else if piros" "else(null)"
                    {     
                        if (palya[i, j].BabuSzin)
                        {
                            Console.ForegroundColor = ConsoleColor.White;               // igaz: fehér
                            Console.Write("  " + palya[i, j].BabuID + " ");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;                 // hamis: prios
                            Console.Write("  " + palya[i, j].BabuID + " ");
                        }                        
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;        // null esetén X
                        Console.Write(" X ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
