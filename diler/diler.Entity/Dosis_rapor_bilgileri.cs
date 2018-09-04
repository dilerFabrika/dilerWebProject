using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace diler.Entity
{
   public class Dosis_rapor_bilgileri
    {
        private int rapor_id;
        private string oneri_form_durumu;
        private string oneri_sayisi;
        private string oneri_durumu;
        private string lokasyon;
        private string kategori;
        private string oneri_veren_bolum;
        private string oneri_uygulayan_bolum;
        private string oneri_no;
        private string form_no;
        private string oneri_giris_tarihi;
        private string oneri_veren_adsoyad;
        private string oneri_ozeti;
        private string mudur_onayi;
        private string oneri_baslama_tarihi;
        private string planlanan_bitis_tarihi;
        private string oneri_bitis_tarihi;
        private string oneri_kapanis_tarihi;
        private string uygulama_gorevlisi;
        private string uygulama_yeri;
        private string getiri_aciklamasi;
        private string getiri_miktari;
        private string odul;
        private string odul_verilis_tarihi;
        private string gecikme_gunu;
        private string uygulayici_red_nedeni;
        private string mudur_red_nedeni;
        private string iptal_nedeni;
        private string planlanan_bitis_tarihi_guncelleme;

        private string iyilestirme_no;
        private string konu;
        private string calisma_grubu;
        private string kaynaklar;
        private string problem_tanimi;
        private string hedef;
        private string yapilan_isler;
        private string degerlendirme;
        private string calisma_baslangic_tarihi;

        private string calisma_bitis_tarihi;
        private string iyilestirme_kategori;

        public int Rapor_id
        {
            get { return rapor_id; }
            set
            {
                if (value < 0)
                {
                    rapor_id = 0;
                }
                else
                {
                    rapor_id = value;
                }
            }
        }
        public string Oneri_form_durumu
        {
            get { return oneri_form_durumu; }
            set { oneri_form_durumu = value; }
        }
        public string Oneri_sayisi
        {
            get { return oneri_sayisi; }
            set { oneri_sayisi = value; }
        }
        public string Oneri_durumu
        {
            get { return oneri_durumu; }
            set { oneri_durumu = value; }

        }
        public string Lokasyon
        {
            get { return lokasyon; }
            set { lokasyon = value; }
        }
        public string Kategori
        {
            get { return kategori; }
            set { kategori = value; }
        }
        public string Oneri_veren_bolum
        {
            get { return oneri_veren_bolum; }
            set { oneri_veren_bolum = value; }
        }
        public string Oneri_uygulayan_bolum
        {
            get { return oneri_uygulayan_bolum; }
            set { oneri_uygulayan_bolum = value; }
        }
        public string Oneri_no
        {
            get { return oneri_no; }
            set { oneri_no = value; }
        }
        public string Form_no
        {
            get { return form_no; }
            set { form_no = value; }
        }
        public string Oneri_giris_tarihi
        {
            get { return oneri_giris_tarihi; }
            set { oneri_giris_tarihi = value; }
        }
        public string Oneri_veren_adsoyad
        {
            get { return oneri_veren_adsoyad; }
            set { oneri_veren_adsoyad = value; }
        }
        public string Oneri_ozeti
        {
            get { return oneri_ozeti; }
            set { oneri_ozeti = value; }
        }
        public string Mudur_onayi
        {
            get { return mudur_onayi; }
            set { mudur_onayi = value; }
        }
        public string Oneri_baslama_tarihi
        {
            get { return oneri_baslama_tarihi; }
            set { oneri_baslama_tarihi = value; }

        }
        public string Planlanan_bitis_tarihi
        {
            get { return planlanan_bitis_tarihi; }
            set { planlanan_bitis_tarihi = value; }
        }
        public string Oneri_bitis_tarihi
        {
            get { return oneri_bitis_tarihi; }
            set { oneri_bitis_tarihi = value; }
        }
        public string Oneri_kapanis_tarihi
        {
            get { return oneri_kapanis_tarihi; }
            set { oneri_kapanis_tarihi = value; }
        }
        public string Uygulama_gorevlisi
        {
            get { return uygulama_gorevlisi; }
            set { uygulama_gorevlisi = value; }
        }
        public string Uygulama_yeri
        {
            get { return uygulama_yeri; }
            set { uygulama_yeri = value; }
        }
        public string Getiri_aciklamasi
        {
            get { return getiri_aciklamasi; }
            set { getiri_aciklamasi = value; }
        }
        public string Getiri_miktari
        {
            get { return getiri_miktari; }
            set { getiri_miktari = value; }
        }
        public string Odul
        {
            get { return odul; }
            set { odul = value; }
        }
        public string Odul_verilis_tarihi
        {
            get { return odul_verilis_tarihi; }
            set { odul_verilis_tarihi = value; }

        }
        public string Gecikme_gunu
        {
            get { return gecikme_gunu; }
            set { gecikme_gunu = value; }

        }
        public string Uygulayici_red_nedeni
        {
            get { return uygulayici_red_nedeni; }
            set { uygulayici_red_nedeni = value; }
        }
        public string Mudur_red_nedeni
        {
            get { return mudur_red_nedeni; }
            set { mudur_red_nedeni = value; }

        }
        public string İptal_nedeni
        {
            get { return iptal_nedeni; }
            set { iptal_nedeni = value; }
        }
        public string Planlanan_bitis_tarihi_guncelleme
        {
            get { return planlanan_bitis_tarihi_guncelleme; }
            set { planlanan_bitis_tarihi_guncelleme = value; }

        }
        public string Iyilestirme_no
        {
            get { return iyilestirme_no; }
            set { iyilestirme_no = value; }
        }
        public string Konu
        {
            get { return konu; }
            set { konu = value; }
        }
        public string Calisma_grubu
        {
            get { return calisma_grubu; }
            set { calisma_grubu = value; }
        }
        public string Kaynaklar
        {
            get { return kaynaklar; }
            set { kaynaklar = value; }
        }
        public string Problem_tanimi
        {
            get { return problem_tanimi; }
            set { problem_tanimi = value; }
        }
        public string Hedef
        {
            get { return hedef; }
            set { hedef = value; }
        }
        public string Yapilan_isler
        {
            get { return yapilan_isler; }
            set { yapilan_isler = value; }
        }
        public string Degerlendirme
        {
            get { return degerlendirme; }
            set { degerlendirme = value; }
        }
        public string Calisma_baslangic_tarihi
        {
            get { return calisma_baslangic_tarihi; }
            set { calisma_baslangic_tarihi = value; }
        }
        public string Calisma_bitis_tarihi
        {
            get { return calisma_bitis_tarihi; }
            set { calisma_bitis_tarihi = value; }
        }
        public string Iyilestirme_kategori
        {
            get { return iyilestirme_kategori; }
            set { iyilestirme_kategori = value; }
        }
    }

}

