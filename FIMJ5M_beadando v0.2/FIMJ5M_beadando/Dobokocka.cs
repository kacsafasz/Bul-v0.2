using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIMJ5M_beadando
{
    class Dobokocka
    {
        Random rnd = new Random();

        public int Dobas()
        {
            return rnd.Next(1, 7);

        }
    }
}
