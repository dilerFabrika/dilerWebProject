using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace diler.Entity
{
    public class Aylik_alyaj_rapor_bilgileri
    {
        private int id;
        private string celik_cinsi;
        private string hurda;
        private string tonaj;
        private string aokok;
        private string aokok_kg;
        private string pokok;
        private string pokok_kg;
        private string aokirec;
        private string aokirec_kg;
        private string pokirec;
        private string pokirec_kg;
        private string fesi;
        private string fesi_kg;
        private string fesimn;
        private string fesimn_kg;
        private string al;
        private string al_kg;
        private string alwire;
        private string alwire_kg;
        private string boksit;
        private string boksit_kg;
        private string cac2;
        private string cac2_kg;
        private string cafe;
        private string cafe_kg;
        private string caf2;
        private string caf2_kg;
        private string casi;
        private string casi_kg;
        private string dolamit;
        private string dolamit_kg;
        private string dolamitik_kirec;
        private string dolamitik_kirec_kg;
        private string feb;
        private string feb_kg;
        private string fecr;
        private string fecr_kg;
        private string femn;
        private string femn_kg;
        private string femnhcr;
        private string femnhcr_kg;
        private string femnlowc;
        private string femnlowc_kg;
        private string fesilowal;
        private string fesilowal_kg;
        private string fesimn6030;
        private string fesimn6030_kg;
        private string feti;
        private string feti_kg;
        private string fev;
        private string fev_kg;
        private string kolamanit;
        private string kolamanit_kg;
        private string mgo;
        private string mgo_kg;
        private string siliskumu;
        private string siliskumu_kg;


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

        public string Celik_cinsi
        {
            get { return celik_cinsi; }
            set { celik_cinsi = value; }
        }
        public string Hurda
        {
            get { return hurda; }
            set { hurda = value; }
        }
        public string Tonaj
        {
            get { return tonaj; }
            set { tonaj = value; }
        }
        public string Aokok
        {
            get { return aokok; }
            set { aokok = value; }
        }

        public string Aokok_kg
        {
            get { return aokok_kg; }
            set { aokok_kg = value; }
        }
        public string Pokok
        {
            get { return pokok; }
            set { pokok = value; }
        }
        public string Pokok_kg
        {
            get { return pokok_kg; }
            set { pokok_kg = value; }
        }
        public string Aokirec
        {
            get { return aokirec; }
            set { aokirec = value; }
        }
        public string Aokirec_kg
        {
            get { return aokirec_kg; }
            set { aokirec_kg = value; }
        }

        public string Pokirec
        {
            get { return pokirec; }
            set { pokirec = value; }
        }
        public string Pokirec_kg
        {
            get { return pokirec_kg; }
            set { pokirec_kg = value; }
        }
        public string Fesi
        {
            get { return fesi; }
            set { fesi = value; }
        }
        public string Fesi_kg
        {
            get { return fesi_kg; }
            set { fesi_kg = value; }

        }
        public string Fesimn
        {
            get { return fesimn; }
            set { fesimn = value; }
        }
        public string Fesimn_kg
        {
            get { return fesimn_kg; }
            set { fesimn_kg = value; }
        }
        public string Al
        {
            get { return al; }
            set { al = value; }
        }
        public string Al_kg
        {
            get { return al_kg; }
            set { al_kg = value; }
        }
        public string Alwire
        {
            get { return alwire; }
            set { alwire = value; }
        }
        public string Alwire_kg
        {
            get { return alwire_kg; }
            set { alwire_kg = value; }
        }
        public string Boksit
        {
            get { return boksit; }
            set { boksit = value; }
        }
        public string Boksit_kg
        {
            get { return boksit_kg; }
            set { boksit_kg = value; }
        }
        public string Cac2
        {
            get { return cac2; }
            set { cac2 = value; }
        }
        public string Cac2_kg
        {
            get { return cac2_kg; }
            set { cac2_kg = value; }

        }
        public string Cafe
        {
            get { return cafe; }
            set { cafe = value; }
        }
        public string Cafe_kg
        {
            get { return cafe_kg; }
            set { cafe_kg = value; }
        }
        public string Caf2
        {
            get { return caf2; }
            set { caf2 = value; }
        }
        public string Caf2_kg
        {
            get { return caf2_kg; }
            set { caf2_kg = value; }
        }
        public string Casi
        {
            get { return casi; }
            set { casi = value; }
        }
        public string Casi_kg
        {
            get { return casi_kg; }
            set { casi_kg = value; }
        }
        public string Dolamit
        {
            get { return dolamit; }
            set { dolamit = value; }
        }
        public string Dolamit_kg
        {
            get { return dolamit_kg; }
            set { dolamit_kg = value; }
        }
        public string Dolamitik_kirec
        {
            get { return dolamitik_kirec; }
            set { dolamitik_kirec = value; }
        }
        public string Dolamitik_kirec_kg
        {
            get { return dolamitik_kirec_kg; }
            set { dolamitik_kirec_kg = value; }

        }
        public string Feb
        {
            get { return feb; }
            set { feb = value; }
        }
        public string Feb_kg
        {
            get { return feb_kg; }
            set { feb_kg = value; }
        }
        public string Fecr
        {
            get { return fecr; }
            set { fecr = value; }
        }
        public string Fecr_kg
        {
            get { return fecr_kg; }
            set { fecr_kg = value; }
        }
        public string Femn
        {
            get { return femn; }
            set { femn = value; }
        }
        public string Femn_kg
        {
            get { return femn_kg; }
            set { femn_kg = value; }
        }
        public string Femnhcr
        {
            get { return femnhcr; }
            set { femnhcr = value; }
        }
        public string Femnhcr_kg
        {
            get { return femnhcr_kg; }
            set { femnhcr_kg = value; }
        }
        public string Femnlowc
        {
            get { return femnlowc; }
            set { femnlowc = value; }
        }
        public string Femnlowc_kg
        {
            get { return femnlowc_kg; }
            set { femnlowc_kg = value; }

        }
        public string Fesilowal
        {
            get { return fesilowal; }
            set { fesilowal = value; }
        }
        public string Fesilowal_kg
        {
            get { return fesilowal_kg; }
            set { fesilowal_kg = value; }
        }
        public string Fesimn6030
        {
            get { return fesimn6030; }
            set { fesimn6030 = value; }
        }
        public string Fesimn6030_kg
        {
            get { return fesimn6030_kg; }
            set { fesimn6030_kg = value; }
        }
        public string Feti
        {
            get { return feti; }
            set { feti = value; }

        }
        public string Feti_kg
        {
            get { return feti_kg; }
            set { feti_kg = value; }
        }
        public string Fev
        {
            get { return fev; }
            set { fev = value; }
        }
        public string Fev_kg
        {
            get { return fev_kg; }
            set { fev_kg = value; }
        }
        public string Kolamanit
        {
            get { return kolamanit; }
            set { kolamanit = value; }
        }
        public string Kolamanit_kg
        {
            get { return kolamanit_kg; }
            set { kolamanit_kg = value; }
        }
        public string Mgo
        {
            get { return mgo; }
            set { mgo = value; }

        }
        public string Mgo_kg
        {
            get { return mgo_kg; }
            set { mgo_kg = value; }
        }
        public string Siliskumu
        {
            get { return siliskumu; }
            set { siliskumu = value; }
        }
        public string Siliskumu_kg
        {
            get { return siliskumu_kg; }
            set { siliskumu_kg = value; }
        }


    }
}
