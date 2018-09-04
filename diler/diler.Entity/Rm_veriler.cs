using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diler.Entity
{
    public class Rm_veriler
    {
        private int id;
        private int tarih;
        private string siparis_numarasi;
        private int dokum_numarasi;
        private string testi_yapan;
        private string cap;
        private string nervur_yuksekligi;
        private string nervur_yuksekligi_1_4;
        private string nervur_yuksekligi_3_4;
        private string cs_mesafesi;
        private string toplam_e_mesafesi;
        private string nervur_uzunlugu;
        private string nervur_genisligi;
        private string beta_acisi;
        private string alfa_acisi;
        private string fr;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int Tarih
        {
            get { return tarih; }
            set
            {
                if (value < 0)
                {
                    tarih = 0;
                }
                else
                {
                    tarih = value;
                }
            }
        }
        public string Siparis_numarasi
        {
            get { return siparis_numarasi; }
            set { siparis_numarasi = value; }
        }
        public int Dokum_numarasi
        {
            get { return dokum_numarasi; }
            set
            {
                if (value < 0)
                {
                    dokum_numarasi = 0;
                }
                else
                {
                    dokum_numarasi = value;
                }
            }
        }
        public string Testi_yapan
        {
            get { return testi_yapan; }
            set { testi_yapan = value; }
        }
        public string Cap
        {
            get { return cap; }
            set { cap = value; }
        }
        public string Nervur_yuksekligi
        {
            get { return nervur_yuksekligi; }
            set { nervur_yuksekligi = value; }
        }
        public string Nervur_yuksekligi_1_4
        {
            get { return nervur_yuksekligi_1_4; }
            set { nervur_yuksekligi_1_4 = value; }
        }
        public string Nervur_yuksekligi_3_4
        {
            get { return nervur_yuksekligi_3_4; }
            set { nervur_yuksekligi_3_4 = value; }
        }
        public string Cs_mesafesi
        {
            get { return cs_mesafesi; }
            set { cs_mesafesi = value; }
        }
        public string Toplam_e_mesafesi
        {
            get { return toplam_e_mesafesi; }
            set { toplam_e_mesafesi = value; }
        }
        public string Nervur_uzunlugu
        {
            get { return nervur_uzunlugu; }
            set { nervur_uzunlugu = value; }
        }
        public string Nervur_genisligi
        {
            get { return nervur_genisligi; }
            set { nervur_genisligi = value; }
        }
        public string Beta_acisi
        {
            get { return beta_acisi; }
            set { beta_acisi = value; }
        }
        public string Alfa_acisi
        {
            get { return alfa_acisi; }
            set { alfa_acisi = value; }
        }
        public string Fr
        {
            get { return fr; }
            set { fr = value; }
        }
    }
}
