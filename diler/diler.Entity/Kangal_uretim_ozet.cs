using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace diler.Entity
{
   public class Kangal_uretim_ozet
    {
        private int uo_id;
        private string cap;
        private string kalite;
        private string tonaj;
        public int Uo_id
        {
            get { return uo_id; }
            set { uo_id = value; }
        }


        public string Cap
        {
            get { return cap; }
            set { cap = value; }
        }


        public string Kalite
        {
            get { return kalite; }
            set { kalite = value; }
        }


        public string Tonaj
        {
            get { return tonaj; }
            set { tonaj = value; }
        }
    }
}
