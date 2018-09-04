using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace diler.Entity
{
    public class Performans_raporu
    {

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
        private object ao_enerji;
        private object po_enerji;
        private double kutuk_tonaji;
        private object enj_Kok_elt;
        private object enj_kirec;
        private object parca_kirec;
        private double toplam_kirec;
        private string tandis_bnd_sayisi;
        private string canak_dokum_say;
        private string kapak_dokum_say;
        private string yurek_dokum_say;
        private string rbt_delik_sayisi;
        private object ao_trnk_kapatma_enerjisi;
        private object rcb_brl_dgaz;
        private object brl_dgaz;
        private object pc_dgaz;
        private object toplam_dgaz;
        private string devirme_saati;
        private string devirme_sicaklik;
        private string toplam_tonaj;
        private object toplam_dgaz_toplamTonaj;
        private string toplam_dgaz_toplamkireç;
        private string sirano;
        private string kutuk_sayisi;
        private string ebat;
        private string boy;
        private string aciklama;
        private string celik_cinsi;
        private string dokum_sayisi;
        private string bb_ao_enj;
        private string bb_po_enj;
        private string verim;
        private string dokum_baslangic_saati;
        private string po_enerjili_sure;
        private string po_brut_sure;

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
        public string Dokum_baslangic_saati
        {
            get { return dokum_baslangic_saati; }
            set { dokum_baslangic_saati = value; }
        }

        public string Rbt_delik_sayisi
        {
            get { return rbt_delik_sayisi; }
            set { rbt_delik_sayisi = value; }
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
        public object Toplam_dgaz_ToplamTonaj
        {
            get { return toplam_dgaz_toplamTonaj; }
            set { toplam_dgaz_toplamTonaj = value; }
        }

        public string Toplam_dgaz_Toplamkireç
        {
            get { return toplam_dgaz_toplamkireç; }
            set { toplam_dgaz_toplamkireç = value; }
        }
        public object Toplam_dgaz
        {
            get { return toplam_dgaz; }
            set { toplam_dgaz = value; }
        }
        public object Enj_kırec
        {
            get { return enj_kirec; }
            set { enj_kirec = value; }
        }
        public object Parca_kırec
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
        public string Devirme_saati
        {
            get { return devirme_saati; }
            set { devirme_saati = value; }
        }
        public object Pc_dgaz
        {
            get { return pc_dgaz; }
            set { pc_dgaz = value; }

        }
        public object Brl_dgaz
        {
            get { return brl_dgaz; }
            set { brl_dgaz = value; }

        }
        public object Rcb_brl_dgaz
        {
            get { return rcb_brl_dgaz; }
            set { rcb_brl_dgaz = value; }

        }
        public object Ao_trnk_kapatma_enerjisi
        {
            get { return ao_trnk_kapatma_enerjisi; }
            set { ao_trnk_kapatma_enerjisi = value; }
        }
        public string Yurek_dokum_say
        {
            get { return yurek_dokum_say; }
            set { yurek_dokum_say = value; }
        }
        public string Kapak_dokum_say
        {
            get { return kapak_dokum_say; }
            set { kapak_dokum_say = value; }
        }
        public string Canak_dokum_say
        {
            get { return canak_dokum_say; }
            set { canak_dokum_say = value; }
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
        public object Po_enerji
        {
            get { return po_enerji; }
            set { po_enerji = value; }
        }
        public object Ao_enerji
        {
            get { return ao_enerji; }
            set { ao_enerji = value; }
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
        public string Aciklama
        {
            get { return aciklama; }
            set { aciklama = value; }
        }
        public string Dokum_sayisi
        {
            get { return dokum_sayisi; }
            set { dokum_sayisi = value; }
        }



    }
}
