using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace diler.Entity
{
    public class Izlenebilirlik_bilgileri
    {
        private string lokasyon;
        private int id;
        private int dokum_no;
        private int dokum_tarihi;
        private string vrd;
        private object srj;
        private object toplam_srj;
        private string enerjili_sure;
        private string enerjisiz_sure;
        private string toplam_sure;
        private string po_giris_sicakligi;
        private string po_cikis_sicakligi;
        private object po_enerjilisure;
        private double kutuk_tonaji;
        private object enj_Kok_elt;
        private object enj_kirec;
        private object parca_kirec;
        private double toplam_kirec;
        private string tandis_bnd_sayisi;
        private string fesi;
        private string fesimn;
        private string c;
        private string cao;
        private string al;
        private string caf2;
        private string mgo;
        private string boksit;
        private string fev;
        private object toplam_dgaz;
        private string devirme_sicaklik;
        private string toplam_tonaj;
        private string sirano;
        private string kutuk_sayisi;
        private string ebat;
        private string boy;
        private string std;
        private string stddisi;
        private string celik_cinsi;
        private string dokum_sayisi;
        private string bb_ao_enj;
        private string bb_po_enj;
        private string verim;
        private string baslangic_sicaklik;
        private string bitis_sicaklik;
        private string parca_kok;
        private string dolamit;
        private string devFesiMn;
        private string devFesi;
        private string dokumsuresi;
        private string dev_al;
        private string potano;
        private string sarjtipi;
        private string yil;
        private string cikis_tarihi;
        private string giris_saati;
        private string cikis_saati;
        private string bolge4;
        private string bolge5;
        private string bolge6;
        private string kutuk_sicaklik;
        private string cap;
        private string akma;
        private string cekme;
        private string uzama;
        private string cekme_akma;
        private string agt;
        private string rbend;
        private string bend;
        private string debi_a;
        private string debi_b;
        private string debi_c;
        private string debi_d;
        private string mamulkalite;
        private string nozulcapi;
        private string hiz;
        private string pompasayisi;
        private string pompabasinci;
        private string yol1;
        private string yol2;
        private string yol3;
        private string yol4;
        private string yol5;
        private string yol6;
        private string pota_acma_saati;
        private string pota_kapatma_saati;

        private string stok_yeri;
        private string istif_yeri;
        private string istif_adet;
        private string tel_cubuk_haddesi;
        private string kutuk_paketleme;
        private string kutuk_satis;
        private string aciklama;
        private string ocak_onu;
        private string sipno;
        private string lot;
        private string istif_sirano;
        private string celik_cinsi_orj;
        private string sonuc;
        private string firina_verilecek;
        private string fid_hurda;
        private string fde_hurda;
        private string egri_kutuk_sayisi;
        private string dokum_baslangic_saati;
        private string dokum_bitis_saati;
        private string pota_giris_saati;
        private string pota_bitis_saati;
        public string Pota_giris_saati
        {
            get { return pota_giris_saati; }
            set { pota_giris_saati = value; }
        }
        public string Pota_bitis_saati
        {
            get { return pota_bitis_saati; }
            set { pota_bitis_saati = value; }
        }
        public string Dokum_baslangic_saati
        {
            get { return dokum_baslangic_saati; }
            set { dokum_baslangic_saati = value; }
        }
        public string Dokum_bitis_saati
        {
            get { return dokum_bitis_saati; }
            set { dokum_bitis_saati = value; }
        }
        public string Egri_kutuk_sayisi
        {
            get { return egri_kutuk_sayisi; }
            set { egri_kutuk_sayisi = value; }
        }
        public string Firina_verilecek
        {
            get { return firina_verilecek; }
            set { firina_verilecek = value; }
        }
        public string Fid_hurda
        {
            get { return fid_hurda; }
            set { fid_hurda = value; }
        }
        public string Fde_hurda
        {
            get { return fde_hurda; }
            set { fde_hurda = value; }
        }
        public string Sonuc
        {
            get { return sonuc; }
            set { sonuc = value; }
        }
        public string Celik_cinsi_orj
        {
            get { return celik_cinsi_orj; }
            set { celik_cinsi_orj = value; }
        }
        public string Lot
        {
            get { return lot; }
            set { lot = value; }
        }
        public string Istif_sirano
        {
            get { return istif_sirano; }
            set { istif_sirano = value; }
        }
        public string Sipno
        {
            get { return sipno; }
            set { sipno = value; }
        }
        public string Ocak_onu
        {
            get { return ocak_onu; }
            set { ocak_onu = value; }
        }
        public string Aciklama
        {
            get { return aciklama; }
            set { aciklama = value; }
        }
        public string Kutuk_satis
        {
            get { return kutuk_satis; }
            set { kutuk_satis = value; }
        }
        public string Kutuk_paketleme
        {
            get { return kutuk_paketleme; }
            set { kutuk_paketleme = value; }
        }
        public string Tel_cubuk_haddesi
        {
            get { return tel_cubuk_haddesi; }
            set { tel_cubuk_haddesi = value; }
        }
        public string Stok_yeri
        {
            get { return stok_yeri; }
            set { stok_yeri = value; }
        }
        public string Istif_adet
        {
            get { return istif_adet; }
            set { istif_adet = value; }
        }
        public string Istif_yeri
        {
            get { return istif_yeri; }
            set { istif_yeri = value; }
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
        public string Yol1
        {
            get { return yol1; }
            set { yol1 = value; }
        }
        public string Yol2
        {
            get { return yol2; }
            set { yol2 = value; }
        }
        public string Yol3
        {
            get { return yol3; }
            set { yol3 = value; }
        }
        public string Yol4
        {
            get { return yol4; }
            set { yol4 = value; }
        }
        public string Yol5
        {
            get { return yol5; }
            set { yol5 = value; }
        }
        public string Yol6
        {
            get { return yol6; }
            set { yol6 = value; }
        }

        public string Debi_a
        {
            get { return debi_a; }
            set { debi_a = value; }
        }
        public string Debi_b
        {
            get { return debi_b; }
            set { debi_b = value; }
        }
        public string Debi_c
        {
            get { return debi_c; }
            set { debi_c = value; }
        }
        public string Debi_d
        {
            get { return debi_d; }
            set { debi_d = value; }
        }
        public string Mamulkalite
        {
            get { return mamulkalite; }
            set { mamulkalite = value; }
        }
        public string Nozulcapi
        {
            get { return nozulcapi; }
            set { nozulcapi = value; }
        }
        public string Hiz
        {
            get { return hiz; }
            set { hiz = value; }
        }
        public string Pompasayisi
        {
            get { return pompasayisi; }
            set { pompasayisi = value; }
        }

        public string Pompabasinci
        {
            get { return pompabasinci; }
            set { pompabasinci = value; }
        }

        public string Cap
        {
            get { return cap; }
            set { cap = value; }
        }
        public string Akma
        {
            get { return akma; }
            set { akma = value; }
        }
        public string Cekme
        {
            get { return cekme; }
            set { cekme = value; }
        }
        public string Uzama
        {
            get { return uzama; }
            set { uzama = value; }
        }
        public string Cekme_akma
        {
            get { return cekme_akma; }
            set { cekme_akma = value; }
        }
        public string Agt
        {
            get { return agt; }
            set { agt = value; }
        }

        public string Bend
        {
            get { return bend; }
            set { bend = value; }
        }
        public string Rbend
        {
            get { return rbend; }
            set { rbend = value; }
        }
        public string Bolge4
        {
            get { return bolge4; }
            set { bolge4 = value; }
        }

        public string Bolge5
        {
            get { return bolge5; }
            set { bolge5 = value; }
        }

        public string Bolge6
        {
            get { return bolge6; }
            set { bolge6 = value; }
        }

        public string Kutuk_sicaklik
        {
            get { return kutuk_sicaklik; }
            set { kutuk_sicaklik = value; }
        }
        public string Sarjtipi
        {
            get { return sarjtipi; }
            set { sarjtipi = value; }
        }
        public string Cikis_saati
        {
            get { return cikis_saati; }
            set { cikis_saati = value; }
        }

        public string Giris_saati
        {
            get { return giris_saati; }
            set { giris_saati = value; }
        }
        public string Cikis_tarihi
        {
            get { return cikis_tarihi; }
            set { cikis_tarihi = value; }
        }

        public string Yil
        {
            get { return yil; }
            set { yil = value; }
        }
        public string Po_cikis_sicakligi
        {
            get { return po_cikis_sicakligi; }
            set { po_cikis_sicakligi = value; }
        }
        public string Lokasyon
        {
            get { return lokasyon; }
            set { lokasyon = value; }
        }


        public string Potano
        {
            get { return potano; }
            set { potano = value; }
        }

        public string Dev_al
        {
            get { return dev_al; }
            set { dev_al = value; }
        }

        public string Dokumsuresi
        {
            get { return dokumsuresi; }
            set { dokumsuresi = value; }
        }

        public string Baslangic_sicaklik
        {
            get { return baslangic_sicaklik; }
            set { baslangic_sicaklik = value; }
        }
        public string Bitis_sicaklik
        {
            get { return bitis_sicaklik; }
            set { bitis_sicaklik = value; }
        }
        public string Parca_kok
        {
            get { return parca_kok; }
            set { parca_kok = value; }
        }
        public string Dolamit
        {
            get { return dolamit; }
            set { dolamit = value; }
        }
        public string DevFesi
        {
            get { return devFesi; }
            set { devFesi = value; }
        }
        public string DevFesiMn
        {
            get { return devFesiMn; }
            set { devFesiMn = value; }
        }

        public string Bb_po_enj
        {
            get { return bb_po_enj; }
            set { bb_po_enj = value; }
        }
        public string Bb_ao_enj
        {
            get { return bb_ao_enj; }
            set { bb_ao_enj = value; }
        }
        public string Verim
        {
            get { return verim; }
            set { verim = value; }
        }

        public object Toplam_dgaz
        {
            get { return toplam_dgaz; }
            set { toplam_dgaz = value; }
        }
        public object Enj_kirec
        {
            get { return enj_kirec; }
            set { enj_kirec = value; }
        }
        public object Parca_kirec
        {
            get { return parca_kirec; }
            set { parca_kirec = value; }
        }
        public string Toplam_sure
        {
            get { return toplam_sure; }
            set { toplam_sure = value; }
        }
        public string Devirme_sicaklik
        {
            get { return devirme_sicaklik; }
            set { devirme_sicaklik = value; }
        }
        public string CaO
        {
            get { return cao; }
            set { cao = value; }

        }
        public string Al
        {
            get { return al; }
            set { al = value; }

        }
        public string MgO
        {
            get { return mgo; }
            set { mgo = value; }
        }
        public string Boksit
        {
            get { return boksit; }
            set { boksit = value; }
        }
        public string FeV
        {
            get { return fev; }
            set { fev = value; }
        }
        public string C
        {
            get { return c; }
            set { c = value; }
        }
        public string Tandis_bnd_sayisi
        {
            get { return tandis_bnd_sayisi; }
            set { tandis_bnd_sayisi = value; }
        }
        public double Toplam_kirec
        {
            get { return toplam_kirec; }
            set { toplam_kirec = value; }
        }
        public object Enj_Kok_elt
        {
            get { return enj_Kok_elt; }
            set { enj_Kok_elt = value; }
        }
        public double Kutuk_tonaji
        {
            get { return kutuk_tonaji; }
            set { kutuk_tonaji = value; }
        }
        public object Po_enerjilisure
        {
            get { return po_enerjilisure; }
            set { po_enerjilisure = value; }
        }
        public string CaF2
        {
            get { return caf2; }
            set { caf2 = value; }
        }
        public string Po_giris_sicakligi
        {
            get { return po_giris_sicakligi; }
            set { po_giris_sicakligi = value; }
        }
        public string Enerjisiz_sure
        {
            get { return enerjisiz_sure; }
            set { enerjisiz_sure = value; }
        }
        public string Enerjili_sure
        {
            get { return enerjili_sure; }
            set { enerjili_sure = value; }
        }
        public object Toplam_srj
        {
            get { return toplam_srj; }
            set { toplam_srj = value; }
        }
        public object Srj
        {
            get { return srj; }
            set { srj = value; }
        }
        public string Vrd
        {
            get { return vrd; }
            set { vrd = value; }
        }
        public int Dokum_tarihi
        {
            get { return dokum_tarihi; }
            set { dokum_tarihi = value; }
        }
        public int Dokum_no
        {
            get { return dokum_no; }
            set { dokum_no = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }


        public string Toplam_tonaj
        {
            get { return toplam_tonaj; }
            set { toplam_tonaj = value; }
        }


        public string Celik_cinsi
        {
            get { return celik_cinsi; }
            set { celik_cinsi = value; }
        }
        public string Sirano
        {
            get { return sirano; }
            set { sirano = value; }
        }
        public string Kutuk_sayisi
        {
            get { return kutuk_sayisi; }
            set { kutuk_sayisi = value; }
        }
        public string Ebat
        {
            get { return ebat; }
            set { ebat = value; }
        }
        public string Boy
        {
            get { return boy; }
            set { boy = value; }
        }
        public string Std
        {
            get { return std; }
            set { std = value; }
        }
        public string Stddisi
        {
            get { return stddisi; }
            set { stddisi = value; }
        }
        public string Dokum_sayisi
        {
            get { return dokum_sayisi; }
            set { dokum_sayisi = value; }
        }
        public string Fesi
        {
            get { return fesi; }
            set { fesi = value; }
        }
        public string FesiMn
        {
            get { return fesimn; }
            set { fesimn = value; }
        }
    }


}
