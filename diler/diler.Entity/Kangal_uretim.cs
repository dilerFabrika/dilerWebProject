using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace diler.Entity
{
    public class Kangal_uretim
    {

        private int uretim_id;
        private string uretim_bilgitnm;
        private string gunluk;
        private string aylik;
        private string aylik_ort;
        private string yillik;
        private string yillik_ort;

        public int Uretim_id
        {
            get { return uretim_id; }
            set
            {
                if (value < 0)
                {
                    uretim_id = 0;
                }
                else
                {
                    uretim_id = value;
                }
            }
        }
        public string Uretim_bilgitnm
        {
            get { return uretim_bilgitnm; }
            set { uretim_bilgitnm = value; }
        }
        public string Gunluk
        {
            get { return gunluk; }
            set { gunluk = value; }
        }


        public string Aylik
        {
            get { return aylik; }
            set { aylik = value; }
        }


        public string Aylik_ort
        {
            get { return aylik_ort; }
            set { aylik_ort = value; }
        }


        public string Yillik
        {
            get { return yillik; }
            set { yillik = value; }
        }


        public string Yillik_ort
        {
            get { return yillik_ort; }
            set { yillik_ort = value; }
        }


    }
}
