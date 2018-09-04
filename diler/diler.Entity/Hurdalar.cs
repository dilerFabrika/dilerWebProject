using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diler.Entity
{
    public class Hurdalar
    {
        private int hurda_id;
        private string hurda_bilgitnm;
        private string gunluk_kullanim;
        private string aylik_kullanim;
        private string yillik_kullanim;
        private string gunluk_giris;
        private string aylik_giris;
        private string yillik_giris;
        private string stok;

        public int Hurda_id
        {
            get { return hurda_id; }
            set
            {
                if (value < 0)
                {
                    hurda_id = 0;
                }
                else
                {
                    hurda_id = value;
                }
            }
        }

        public string Hurda_bilgitnm
        {
            get { return hurda_bilgitnm; }
            set { hurda_bilgitnm = value; }
        }
        public string Gunluk_kullanim
        {
            get { return gunluk_kullanim; }
            set { gunluk_kullanim = value; }
        }
        public string Aylik_kullanim
        {
            get { return aylik_kullanim; }
            set { aylik_kullanim = value; }
        }
        public string Yillik_kullanim
        {
            get { return yillik_kullanim; }
            set { yillik_kullanim = value; }
        }
        public string Gunluk_giris
        {
            get { return gunluk_giris; }
            set { gunluk_giris = value; }
        }
        public string Aylik_giris
        {
            get { return aylik_giris; }
            set { aylik_giris = value; }
        }
        public string Yillik_giris
        {
            get { return yillik_giris; }
            set { yillik_giris = value; }
        }
        public string Stok
        {
            get { return stok; }
            set { stok = value; }
        }
    }
}
