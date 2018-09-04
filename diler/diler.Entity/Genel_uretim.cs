using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace diler.Entity
{
    public class Genel_uretim
    {
        private int gu_id;
        private string gu_bilgitnm;
        private string gu_gunluk;
        private string gu_gunluk_ort;
        private string gu_aylik;
        private string gu_aylik_ort;
        private string gu_yillik;
        private string gu_yillik_ort;

        public int Gu_id
        {
            get { return gu_id; }
            set
            {
                if (value < 0)
                {
                    gu_id = 0;
                }
                else
                {
                    gu_id = value;
                }
            }
        }
        public string Gu_bilgitnm
        {
            get { return gu_bilgitnm; }
            set { gu_bilgitnm = value; }
        }
        public string Gu_gunluk
        {
            get { return gu_gunluk; }
            set { gu_gunluk = value; }
        }
        public string Gu_gunluk_ort
        {
            get { return gu_gunluk_ort; }
            set { gu_gunluk_ort = value; }
        }
        public string Gu_aylik
        {
            get { return gu_aylik; }
            set { gu_aylik = value; }
        }
        public string Gu_aylik_ort
        {
            get { return gu_aylik_ort; }
            set { gu_aylik_ort = value; }
        }
        public string Gu_yillik
        {
            get { return gu_yillik; }
            set { gu_yillik = value; }
        }
        public string Gu_yillik_ort
        {
            get { return gu_yillik_ort; }
            set { gu_yillik_ort = value; }
        }
    }
}


