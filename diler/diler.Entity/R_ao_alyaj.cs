using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace diler.Entity
{
    public class R_ao_alyaj
    {

        private int id;
        private string kalite;
        private string hurda;
        private string dokum_no;
        private string tarih;
        private string dokum_tip;
        private string sip_no;

        private string parca_kok;
        private string enjekte_kok_elti;
        private string enjekte_kok_panel;
        private string parca_kirec;
        private string enjekte_kirec;
        private string dev_al;
        private string dev_fesi65;

        private string dev_fesi70;
        private string dev_fesi75;
        private string dev_fesimn60;
        private string dev_fesimn65;
        private string dev_fesimn70;
        private string dev_femn;
        private string dev_femn_hcr;

        private string fesilowal_ao;
        private string femnlowc_ao;



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
        public string Hurda
        {
            get { return hurda; }
            set { hurda = value; }
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
        public string Parca_kok
        {
            get { return parca_kok; }
            set { parca_kok = value; }
        }
        public string Enjekte_kok_elti
        {
            get { return enjekte_kok_elti; }
            set { enjekte_kok_elti = value; }
        }
        public string Enjekte_kok_panel
        {
            get { return enjekte_kok_panel; }
            set { enjekte_kok_panel = value; }
        }
        public string Sip_no
        {
            get { return sip_no; }
            set { sip_no = value; }
        }
        public string Parca_kirec
        {
            get { return parca_kirec; }
            set { parca_kirec = value; }
        }
        public string Enjekte_kirec
        {
            get { return enjekte_kirec; }
            set { enjekte_kirec = value; }
        }
        public string Dev_al
        {
            get { return dev_al; }
            set { dev_al = value; }
        }
        public string Dev_fesi65
        {
            get { return dev_fesi65; }
            set { dev_fesi65 = value; }
        }
        public string Dev_fesi70
        {
            get { return dev_fesi70; }
            set { dev_fesi70 = value; }
        }
        public string Dev_fesi75
        {
            get { return dev_fesi75; }
            set { dev_fesi75 = value; }
        }
        public string Dev_fesimn60
        {
            get { return dev_fesimn60; }
            set { dev_fesimn60 = value; }
        }
        public string Dev_fesimn65
        {
            get { return dev_fesimn65; }
            set { dev_fesimn65 = value; }
        }
        public string Dev_fesimn70
        {
            get { return dev_fesimn70; }
            set { dev_fesimn70 = value; }
        }
        public string Dev_femn
        {
            get { return dev_femn; }
            set { dev_femn = value; }
        }

        public string Dev_femn_hcr
        {
            get { return dev_femn_hcr; }
            set { dev_femn_hcr = value; }
        }

        public string Fesilowal_ao
        {
            get { return fesilowal_ao; }
            set { fesilowal_ao = value; }
        }

        public string Femnlowc_ao
        {
            get { return femnlowc_ao; }
            set { femnlowc_ao = value; }
        }



    }
}
