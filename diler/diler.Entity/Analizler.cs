using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace diler.Entity
{
    public class Analizler
    {
        private int analiz_id;
        private string dokumno;
        private string c;
        private string si;
        private string s;
        private string p;
        private string mn;
        private string ni;
        private string cr;
        private string cu;
        private string mo;
        private string sn;
        private string v;
        private string n;
        private string ceg;
        private string b;
        private string ca;
        private string ti;
        private string al;
        private string pb;
        private string nb;
        private string celik_cinsi;
        private string sirano;
        private string kutuk_sayisi;
        private string ebat;
        private string boy;
        private string uretimdensapmanedeni;
        private string uretimdensapma_element;
        private string aciklama;
        private string tonaj;
        private string dokum_sayisi;
        private string tandis_bindirme_sayisi;
        private string tandis_no;
        private string vardiya;
        private string tandis_no_bindirme_sayisi;
        private string radyoaktivite;
        private string ks1;
        private string ks2;
        private string standart_disi_neden;
        private string standart_disi_element;
        private string radyasyon;
        private string karisim_sayisi;
        private string karisim_tonaji;
        private string siparis_no;
        private string uretim_yeri;
        public string Uretim_yeri
        {
            get { return uretim_yeri; }
            set { uretim_yeri = value; }
        }
        public string Siparis_no
        {
            get { return siparis_no; }
            set { siparis_no = value; }
        }
        public string Karisim_sayisi
        {
            get { return karisim_sayisi; }
            set { karisim_sayisi = value; }
        }
        public string Karisim_tonaji
        {
            get { return karisim_tonaji; }
            set { karisim_tonaji = value; }
        }
        public int Analiz_id
        {
            get { return analiz_id; }
            set
            {
                if (value < 0)
                {
                    analiz_id = 0;
                }
                else
                {
                    analiz_id = value;
                }
            }
        }
        public string Dokum_no
        {
            get { return dokumno; }
            set { dokumno = value; }
        }
        public string Dokum_sayisi
        {
            get { return dokum_sayisi; }
            set { dokum_sayisi = value; }
        }
        public string C
        {
            get { return c; }
            set { c = value; }
        }
        public string Si
        {
            get { return si; }
            set { si = value; }
        }
        public string S
        {
            get { return s; }
            set { s = value; }
        }
        public string P
        {
            get { return p; }
            set { p = value; }
        }
        public string Mn
        {
            get { return mn; }
            set { mn = value; }
        }
        public string Ni
        {
            get { return ni; }
            set { ni = value; }
        }
        public string Cr
        {
            get { return cr; }
            set { cr = value; }
        }
        public string Cu
        {
            get { return cu; }
            set { cu = value; }
        }
        public string Mo
        {
            get { return mo; }
            set { mo = value; }
        }
        public string Sn
        {
            get { return sn; }
            set { sn = value; }
        }
        public string V
        {
            get { return v; }
            set { v = value; }
        }
        public string N
        {
            get { return n; }
            set { n = value; }
        }
        public string Ceg
        {
            get { return ceg; }
            set { ceg = value; }
        }
        public string B
        {
            get { return b; }
            set { b = value; }
        }
        public string Ca
        {
            get { return ca; }
            set { ca = value; }
        }
        public string Ti
        {
            get { return ti; }
            set { ti = value; }
        }
        public string Al
        {
            get { return al; }
            set { al = value; }
        }
        public string Pb
        {
            get { return pb; }
            set { pb = value; }
        }
        public string Nb
        {
            get { return nb; }
            set { nb = value; }
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
        public string Uretimdensapma_nedeni
        {
            get { return uretimdensapmanedeni; }
            set { uretimdensapmanedeni = value; }
        }
        public string Uretimdensapma_element
        {
            get { return uretimdensapma_element; }
            set { uretimdensapma_element = value; }
        }
        public string Standart_disi_element
        {
            get { return standart_disi_element; }
            set { standart_disi_element = value; }
        }
        public string Standart_disi_neden
        {
            get { return standart_disi_neden; }
            set { standart_disi_neden = value; }
        }
        public string Aciklama
        {
            get { return aciklama; }
            set { aciklama = value; }
        }
        public string Tonaj
        {
            get { return tonaj; }
            set { tonaj = value; }
        }
        public string Tandis_bindirme_sayisi
        {
            get { return tandis_bindirme_sayisi; }
            set { tandis_bindirme_sayisi = value; }
        }
        public string Tandis_no
        {
            get { return tandis_no; }
            set { tandis_no = value; }
        }

        public string Tandis_no_bindirme_sayisi
        {
            get { return tandis_no_bindirme_sayisi; }
            set { tandis_no_bindirme_sayisi = value; }
        }
        public string Radyoaktivite
        {
            get { return radyoaktivite; }
            set { radyoaktivite = value; }
        }
        public string Vardiya
        {
            get { return vardiya; }
            set { vardiya = value; }
        }
        public string KS1
        {
            get { return ks1; }
            set { ks1 = value; }
        }
        public string KS2
        {
            get { return ks2; }
            set { ks2 = value; }
        }

        public string Radyasyon
        {
            get { return radyasyon; }
            set { radyasyon = value; }
        }
    }
}
