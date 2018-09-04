using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace diler.Entity
{
    public class R_sdm_genel
    {
        private int id;
        private string kalite;
        private string hurda;
        private string dokum_no;
        private string tarih;
        private string dokum_tip;
        private string sip_no;

        private string kalip_dokum_sayisi1;
        private string kalip_dokum_sayisi2;
        private string kalip_dokum_sayisi3;
        private string kalip_dokum_sayisi4;
        private string kalip_dokum_sayisi5;
        private string kalip_dokum_sayisi6;

        private string tandis_baslangic_sicaklik;
        private string tandis_orta_sicaklik;
        private string tandis_no;
        private string tandis_bindirme_sayisi;
        private string pota_acma_saati;
        private string pota_kapatma_saati;
        private string net_sure;
        private string pota_plaka_no;
        private string pota_durumu;



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
        public string Sip_no
        {
            get { return sip_no; }
            set { sip_no = value; }
        }

        public string Kalip_dokum_sayisi1
        {
            get { return kalip_dokum_sayisi1; }
            set { kalip_dokum_sayisi1 = value; }
        }
        public string Kalip_dokum_sayisi2
        {
            get { return kalip_dokum_sayisi2; }
            set { kalip_dokum_sayisi2 = value; }
        }
        public string Kalip_dokum_sayisi3
        {
            get { return kalip_dokum_sayisi3; }
            set { kalip_dokum_sayisi3 = value; }
        }

        public string Kalip_dokum_sayisi4
        {
            get { return kalip_dokum_sayisi4; }
            set { kalip_dokum_sayisi4 = value; }
        }
        public string Kalip_dokum_sayisi5
        {
            get { return kalip_dokum_sayisi5; }
            set { kalip_dokum_sayisi5 = value; }
        }
        public string Kalip_dokum_sayisi6
        {
            get { return kalip_dokum_sayisi6; }
            set { kalip_dokum_sayisi6 = value; }
        }


        public string Tandis_baslangic_sicaklik
        {
            get { return tandis_baslangic_sicaklik; }
            set { tandis_baslangic_sicaklik = value; }

        }
        public string Tandis_orta_sicaklik
        {
            get { return tandis_orta_sicaklik; }
            set { tandis_orta_sicaklik = value; }

        }
        public string Tandis_no
        {
            get { return tandis_no; }
            set { tandis_no = value; }

        }
        public string Tandis_bindirme_sayisi
        {
            get { return tandis_bindirme_sayisi; }
            set { tandis_bindirme_sayisi = value; }

        }
        public string Pota_acma_saati
        {
            get { return pota_acma_saati; }
            set { pota_acma_saati = value; }

        }
        public string Pota_kapatma_saati
        {
            get { return pota_kapatma_saati; }
            set { pota_kapatma_saati = value; }

        }
        public string Net_sure
        {
            get { return net_sure; }
            set { net_sure = value; }

        }
        public string Pota_plaka_no
        {
            get { return pota_plaka_no; }
            set { pota_plaka_no = value; }

        }
        public string Pota_durumu
        {
            get { return pota_durumu; }
            set { pota_durumu = value; }

        }
    }
}
