using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIMJ5M_beadando
{
    class Jatekos
    {
        string jatekosNev;
        bool jatekosSzin;                    // igaz: fehér, hamis: piros
        Babu[] jatekosBabui;
        public Jatekos(string jatekos, bool logikai)
        { 
            this.jatekosNev = jatekos;
            this.jatekosSzin = logikai;
        }
   
        public string JatekosNev
        {
            get { return jatekosNev; }
        }
        public bool JatekosSzin
        {
            get { return jatekosSzin; }
        }

    }
}
