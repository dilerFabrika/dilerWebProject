using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diler.Entity
{
    public class Mesai_yillik_izin
    {
        private int personel_sicil_no;
        private string mesai_cikis_tipi;
        private string mesai_nedeni;
        private string mesai_genel_aciklama;
        private double mesai_toplam_saat;
        private string mesai_tarih;
        private int geri_gun_sayisi;
        public int Geri_gun_sayisi
        {
            get { return geri_gun_sayisi; }
            set { geri_gun_sayisi = value; }
        }
        public int Personel_sicil_no
        {
            get { return personel_sicil_no; }
            set { personel_sicil_no = value; }
        }
        public string Mesai_cikis_tipi
        {
            get { return mesai_cikis_tipi; }
            set { mesai_cikis_tipi = value; }
        }

        public string Mesai_nedeni
        {
            get { return mesai_nedeni; }
            set { mesai_nedeni = value; }
        }
        public string Mesai_genel_aciklama
        {
            get { return mesai_genel_aciklama; }
            set { mesai_genel_aciklama = value; }
        }

        public double Mesai_toplam_saat
        {
            get { return mesai_toplam_saat; }
            set { mesai_toplam_saat = value; }
        }

        public string Mesai_tarih
        {
            get { return mesai_tarih; }
            set { mesai_tarih = value; }
        }

    }
}
