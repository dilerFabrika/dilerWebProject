using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace diler.Entity
{
    public class R_hurda
    {
        private int id;
        private string kalite;
        private string dokum_no;
        private string tarih;
        private string dokum_tip;
        private string sip_no;

        private string degirmen;
        private string hms1;
        private string hms2;
        private string piyasa;
        private string hms1_2;
        private string pik;
        private string elek;
        private string skal;
        private string hbi;
        private string talas;
        private string dkp;
        private string busheling;


        public int Id
        {
            get { return id; }
            set
            {
                if (value < 0)
                {
                    id = 0;
                }
                else
                {
                    id = value;
                }
            }
        }

        public string Kalite
        {
            get { return kalite; }
            set { kalite = value; }
        }

        public string Tarih
        {
            get { return tarih; }
            set { tarih = value; }
        }
        public string Dokum_no
        {
            get { return dokum_no; }
            set { dokum_no = value; }
        }
        public string Dokum_tip
        {
            get { return dokum_tip; }
            set { dokum_tip = value; }
        }
        public string Sip_no
        {
            get { return sip_no; }
            set { sip_no = value; }
        }
        public string Degirmen
        {
            get { return degirmen; }
            set { degirmen = value; }
        }
        public string Hms1
        {
            get { return hms1; }
            set { hms1 = value; }
        }
        public string Hms2
        {
            get { return hms2; }
            set { hms2 = value; }
        }
        public string Piyasa
        {
            get { return piyasa; }
            set { piyasa = value; }
        }
        public string Hms1_2
        {
            get { return hms1_2; }
            set { hms1_2 = value; }
        }


        public string Pik
        {
            get { return pik; }
            set { pik = value; }
        }
        public string Elek
        {
            get { return elek; }
            set { elek = value; }
        }
        public string Skal
        {
            get { return skal; }
            set { skal = value; }

        }
        public string Hbi
        {
            get { return hbi; }
            set { hbi = value; }
        }
        public string Talas
        {
            get { return talas; }
            set { talas = value; }
        }
        public string Dkp
        {
            get { return dkp; }
            set { dkp = value; }
        }
        public string Busheling
        {
            get { return busheling; }
            set { busheling = value; }
        }
 
 


    }
}
