using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIMJ5M_beadando
{
    class Jatek
    {                                                   // csak egy játék lehet. Minden legyen statikus.
        private static Jatekos pirosJatekos;
        private static Jatekos feherJatekos;
        private static Tabla tabla;
        private static bool kovetkezoJatekos;          // melyik játékos van soron. igaz: fehér, hamis: piros

        public static Jatekos PirosJatekos
        {
            get { return PirosJatekos; }
            set { PirosJatekos = value; }
        }

        public static Jatekos FeherJatekos
        {
            get { return feherJatekos; }
            set { feherJatekos = value; }
        }

        public static Tabla Tabla
        {
            get { return tabla; }
            set { tabla = value; }
        }

        public static void KovetkezoKor()
        {
            kovetkezoJatekos = !kovetkezoJatekos;
        }
    }
}
