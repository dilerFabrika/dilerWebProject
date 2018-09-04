using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diler.Entity
{
    public class Personel
    {

        private int id;
        private int sicil_no;
        private string ad;
        private string soyad;
        private string dogum_tarihi;
        private string medeni_hali;
        private string unite_gecis_tarihi;
        private string unite;
        private string bolum;
        private string alt_grup;
        private string egitim_durumu;
        private int kisim_kodu;
        private long tc_no;
        private int mesai_tarih;
        private int hesaplanan;
        private string mesai_giris_saati;
        private string mesai_cikis_saati;
        private int pdksnum;
        private string hareket;
        private string mesaiNedeni;
        private string mesaiAciklaması;


        public string MesaiNedeni
        {
            get { return mesaiNedeni; }
            set { mesaiNedeni = value; }

        }


        public string MesaiAciklaması
        {
            get { return mesaiAciklaması; }
            set { mesaiAciklaması = value; }

        }


        public string Hareket
        {
            get { return hareket; }
            set { hareket = value; }

        }
        public string Mesai_cikis_saati
        {
            get { return mesai_cikis_saati; }
            set { mesai_cikis_saati = value; }
 
        }
        public string Mesai_giris_saati
        {
            get { return mesai_giris_saati; }
            set { mesai_giris_saati = value; }
        }

        public int Pdksnum
        {
            get { return pdksnum; }
            set { pdksnum = value; }
        }
        public int Hesaplanan
        {

            get { return hesaplanan; }
            set { hesaplanan = value; }
        }
        public int Mesai_tarih
        {

            get { return mesai_tarih; }
            set { mesai_tarih = value; }
        }
        public long Tc_no
        {
            get { return tc_no; }
            set { tc_no = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int Sicil_no
        {
            get { return sicil_no; }
            set { sicil_no = value; }
        }
        public string Ad
        {
            get { return ad; }
            set { ad = value; }
        }
        public string Soyad
        {
            get { return soyad; }
            set { soyad = value; }
        }
        public string Dogum_tarihi
        {
            get { return dogum_tarihi; }
            set { dogum_tarihi = value; }
        }
        public string Medeni_hali
        {
            get { return medeni_hali; }
            set { medeni_hali = value; }
        }
        public string Unite_gecis_tarihi
        {
            get { return unite_gecis_tarihi; }
            set { unite_gecis_tarihi = value; }
        }
        public string Unite
        {
            get { return unite; }
            set { unite = value; }
        }
        public string Bolum
        {
            get { return bolum; }
            set { bolum = value; }
        }
        public string Alt_grup
        {
            get { return alt_grup; }
            set { alt_grup = value; }
        }
        public string Egitim_durumu
        {
            get { return egitim_durumu; }
            set { egitim_durumu = value; }
        }
        public int Kisim_kodu
        {
            get { return kisim_kodu; }
            set { kisim_kodu = value; }
        }
    }
}
