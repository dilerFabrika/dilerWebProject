using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace diler.Entity
{
    public class R_pota_ocagi_genel
    {

        private int id;
        private string kalite;
        private string dokum_no;
        private string tarih;
        private string dokum_tip;
        private string sip_no;

        private string po_giris_saati;
        private string po_cikis_saati;
        private string po_brut_sure;
        private string po_enerjili_sure;
        private string po_power_off_time;
        private string po_giris_sicaklik;
        private string po_cikis_sicaklik;
        private string po_sivi_celik_son;
        private string po_bos_pota_tonaj;
        private string po_sivi_celik;
        private string po_ekfaz1;
        private string po_ekfaz2;
        private string po_ekfaz3;
        private string po_genel_aciklama;
        private string yeniden_isitma_giris;
        private string yeniden_isitma_cikis;
        private string elektrod_kodu_po;



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
        public string Po_giris_saati
        {
            get { return po_giris_saati; }
            set { po_giris_saati = value; }
        }
        public string Po_cikis_saati
        {
            get { return po_cikis_saati; }
            set { po_cikis_saati = value; }
        }
        public string Po_brut_sure
        {
            get { return po_brut_sure; }
            set { po_brut_sure = value; }
        }
        public string Po_enerjili_sure
        {
            get { return po_enerjili_sure; }
            set { po_enerjili_sure = value; }
        }

        public string Po_power_off_time
        {
            get { return po_power_off_time; }
            set { po_power_off_time = value; }
        }
        public string Po_giris_sicaklik
        {
            get { return po_giris_sicaklik; }
            set { po_giris_sicaklik = value; }
        }
        public string Po_cikis_sicaklik
        {
            get { return po_cikis_sicaklik; }
            set { po_cikis_sicaklik = value; }
        }
        public string Po_sivi_celik_son
        {
            get { return po_sivi_celik_son; }
            set { po_sivi_celik_son = value; }

        }
        public string Po_bos_pota_tonaj
        {
            get { return po_bos_pota_tonaj; }
            set { po_bos_pota_tonaj = value; }
        }
        public string Po_sivi_celik
        {
            get { return po_sivi_celik; }
            set { po_sivi_celik = value; }
        }
        public string Po_ekfaz1
        {
            get { return po_ekfaz1; }
            set { po_ekfaz1 = value; }
        }
        public string Po_ekfaz2
        {
            get { return po_ekfaz2; }
            set { po_ekfaz2 = value; }
        }
        public string Po_ekfaz3
        {
            get { return po_ekfaz3; }
            set { po_ekfaz3 = value; }
        }
        public string Po_genel_aciklama
        {
            get { return po_genel_aciklama; }
            set { po_genel_aciklama = value; }
        }
 
        public string Yeniden_isitma_giris
        {
            get { return yeniden_isitma_giris; }
            set { yeniden_isitma_giris = value; }
        }
        public string Yeniden_isitma_cikis
        {
            get { return yeniden_isitma_cikis; }
            set { yeniden_isitma_cikis = value; }
        }
        public string Eletrodkodu_Po
        {
            get { return elektrod_kodu_po; }
            set { elektrod_kodu_po = value; }
        }


    }
}
