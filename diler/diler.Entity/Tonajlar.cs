using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace diler.Entity
{
    public class Tonajlar
    {
        int tonaj_id;
        string yil;
        string ay;
        string tonaj;

        public string Tonaj
        {
            get { return tonaj; }
            set { tonaj = value; }
        }

        public string Ay
        {
            get { return ay; }
            set { ay = value; }
        }

        public string Yil
        {
            get { return yil; }
            set { yil = value; }
        }

        public int Tonaj_id
        {
            get { return tonaj_id; }
            set { tonaj_id = value; }
        }
    }
}
