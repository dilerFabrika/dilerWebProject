using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace diler.Entity
{
 public   class Kalibrasyon_Paketleme
    {

        private int vrd;
        private int yol;
        private string kalibreTnm;
        private string tonaj;
        private string saat;
        private string aciklama;


        public int Vrd
    {
        get { return vrd; }
        set { vrd = value; }
    }


        public int Yol
        {
            get { return yol; }
            set { yol = value; }
        }


        public string KalibreTnm
        {
            get { return kalibreTnm; }
            set { kalibreTnm = value; }
        }


        public string Tonaj
        {
            get { return tonaj; }
            set { tonaj = value; }
        }


        public string Saat
        {
            get { return saat; }
            set { saat = value; }
        }
        public string Aciklama
        {
            get { return aciklama; }
            set { aciklama = value; }
        }

    }
}