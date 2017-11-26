using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIMJ5M_beadando
{
    class Babu
    {
        private int babuID, babuSOR, babuOSZLOP;
        private Babu [] foglyok;
        private int foglyokSzama;
        private bool babuSzin;                      // játékosnak és bábunak is van sziné. Elég lenne csak az egyik?
        private bool fogsagban;
        private int bazisOszlop;

        public Babu(int id, int oszlop, int sor, bool szin)                                                     // Kontstruktor új játékhoz
        {
            this.babuID = id;
            this.babuSOR = sor;
            this.babuOSZLOP = oszlop;
            this.babuSzin = szin;
            foglyok = new Babu[(sor * 2) - 1];          // maximális bábuszám, mínusz önmaga
            if (szin)
            {
                bazisOszlop = sor - 1;
            }
            else
            {
                bazisOszlop = 0;
            }
        }

        public Babu(int id, int oszlop, int sor, bool szin, bool fogsagban, int foglyokSzama, Babu[] foglyok)   // Konstruktor betöltéshez       
        {
            this.babuID = id;
            this.babuSOR = sor;
            this.babuOSZLOP = oszlop;
            this.babuSzin = szin;
            this.fogsagban = fogsagban;
            this.foglyokSzama = foglyokSzama;
            this.foglyok = foglyok;
            if (szin)
            {
                bazisOszlop = sor - 1;
            }
            else
            {
                bazisOszlop = 0;
            }
        }

        public int BabuID
        {
            get { return babuID; }           
        }
        public int BabuSOR
        {
            get { return babuSOR; }
            set { babuSOR = value; }
        }
        public int BabuOSZLOP
        {
            get { return babuOSZLOP; }
            set { babuOSZLOP = value; }
        }
        public bool BabuSzin
        {
            get { return babuSzin; }
        }

        public int BazisOszlop
        {
            get { return bazisOszlop; }
        }

        public Babu [] Foglyok
        {
            get { return foglyok; }
            set { foglyok = value; }     // felülírható a tömb egy másikkal. Bázisra visszatéréskor talán hasznos.
        }

        public bool Fogsagban
        {
            get { return fogsagban; }
            set { fogsagban = value; }
        }

        public void FoglyulEjt(Babu babu)
        {
            foglyokSzama++;                 // elejtett babu foglyaival mi legyen?
            foglyok[foglyokSzama] = babu;
            babu.Fogsagban = true;
        }

        private void FelszabaditVagyMegol(Babu babu)
        {
            babu.Hazater();
        }

        public void Hazater()
        {
            foreach  (Babu fogoly in foglyok)
            {
                if (fogoly.BabuSzin == BabuSzin)
                {
                    felszabadul
                }
                else
                {
                    megol
                }
            }
        }
    }
}
