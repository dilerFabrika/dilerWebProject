using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace diler.Entity
{
    public class R_ark_ocagi_genel
    {

        private int id;
        private string kalite;
        private string hurda;
        private string dokum_no;
        private string tarih;
        private string dokum_tip;
        private string sip_no;

        private string dokum_baslangic_saati;
        private string devirme_saati;
        private string dokum_suresi;
        private string canak_dokum_sayisi;
        private string kapak_dokum_sayisi;
        private string yurek_dokum_sayisi;
        private string rbt_delik_sayisi;
        private string yurek_no;
        private string ted_al_saati;
        private string ted_tirnak_acma_saati;
        private string ted_tb_sure;
        private string ao_enerjili_sure;
        private string ao_enerjisiz_sure;
        private string devirme_sicaklik;
        private string eletrodkodu_ao;



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
        public string Dokum_baslangic_saati
        {
            get { return dokum_baslangic_saati; }
            set { dokum_baslangic_saati = value; }
        }
        public string Devirme_saati
        {
            get { return devirme_saati; }
            set { devirme_saati = value; }
        }
        public string Dokum_suresi
        {
            get { return dokum_suresi; }
            set { dokum_suresi = value; }
        }
        public string Canak_dokum_sayisi
        {
            get { return canak_dokum_sayisi; }
            set { canak_dokum_sayisi = value; }
        }

        public string Kapak_dokum_sayisi
        {
            get { return kapak_dokum_sayisi; }
            set { kapak_dokum_sayisi = value; }
        }
        public string Yurek_dokum_sayisi
        {
            get { return yurek_dokum_sayisi; }
            set { yurek_dokum_sayisi = value; }
        }
        public string Rbt_delik_sayisi
        {
            get { return rbt_delik_sayisi; }
            set { rbt_delik_sayisi = value; }
        }
        public string Yurek_no
        {
            get { return yurek_no; }
            set { yurek_no = value; }

        }
        public string Ted_al_saati
        {
            get { return ted_al_saati; }
            set { ted_al_saati = value; }
        }
        public string Ted_tirnak_acma_saati
        {
            get { return ted_tirnak_acma_saati; }
            set { ted_tirnak_acma_saati = value; }
        }
        public string Ted_tb_sure
        {
            get { return ted_tb_sure; }
            set { ted_tb_sure = value; }
        }
        public string Ao_enerjili_sure
        {
            get { return ao_enerjili_sure; }
            set { ao_enerjili_sure = value; }
        }
        public string Ao_enerjisiz_sure
        {
            get { return ao_enerjisiz_sure; }
            set { ao_enerjisiz_sure = value; }
        }
        public string Devirme_sicaklik
        {
            get { return devirme_sicaklik; }
            set { devirme_sicaklik = value; }
        }
        public string Eletrodkodu_ao
        {
            get { return eletrodkodu_ao; }
            set { eletrodkodu_ao = value; }
        }


    }
}
