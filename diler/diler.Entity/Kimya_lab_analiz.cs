using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace diler.Entity
{
    public class Kimya_lab_analiz
    {
        private int analiz_id;
        private string yer;
        private int yil;
        private string ract;
        private string celik_cinsi;
        private string tonaj;
        private string aciklama;
        private int dokum_no;
        private string dokum_tarihi;
        private string boy;
        private string ebat;
        private string adet;



        private string c;
    
        private string mn;
        private string cr;
        private string si;
        private string s;
        private string p;

        private string ni;

        private string mo;
        private string cu;
        private string v;
        private string w;
        private string sn;

        private string co;
        private string al;
        private string alsol;
        private string alinsol;
        private string pb;

        /*** ikinci grid */
        private string b;

        private string bsol;
        private string binsol;
        private string sb;
        private string nb;
        private string ca;
        private string casol;

        private string cainso;
        private string zn;
        private string n;
        private string ti;
        private string tisol;
        private string tiinsol;

        private string ass;
        private string zr;
        private string bi;
        private string o;
        private string fe;
        private string ceq;
        private string ce;

        /** ucuncu grid */
        private string crnicu;

        private string alcao;
        private string almgo;
        private string alsio;
        private string altio;
        private string alca;
        private string alo;

        private string cao;
        private string cas;
        private string tio;
        private string tial;
        private string mns;
        private string mgo;

        private string zro;
        private string sio;
        private string tliq;
        private string cu_sn;
        private object mn_si;

        public string Boy
        {
            get { return boy; }
            set { boy = value; }
        }
        public string Ebat
        {
            get { return ebat; }
            set { ebat = value; }
        }
        public string Adet
        {
            get { return adet; }
            set { adet = value; }
        }
        public string Dokum_tarihi
        {
            get { return dokum_tarihi; }
            set { dokum_tarihi = value; }
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
        public string Tliq
        {
            get { return tliq; }
            set { tliq = value; }
        }
        public object Mn_si
        {
            get { return mn_si; }
            set { mn_si = value; }
        }
        public string Cu_sn
        {
            get { return cu_sn; }
            set { cu_sn = value; }
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
        public int Yil
        {
            get { return yil; }
            set { yil = value; }
        }
        public string Yer
        {
            get { return yer; }
            set { yer = value; }
        }
        public string Celik_cinsi
        {
            get { return celik_cinsi; }
            set { celik_cinsi = value; }
        }
        public int Dokum_no
        {
            get { return dokum_no; }
            set { dokum_no = value; }
        }
        public string Ract
        {
            get { return ract; }
            set { ract = value; }
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
        public string Mo
        {
            get { return mo; }
            set { mo = value; }
        }
        public string Cu
        {
            get { return cu; }
            set { cu = value; }
        }
        public string V
        {
            get { return v; }
            set { v = value; }
        }

        public string W
        {
            get { return w; }
            set { w = value; }
        }
        public string Sn
        {
            get { return sn; }
            set { sn = value; }
        }

        public string Co
        {
            get { return co; }
            set { co = value; }
        }
        public string Al
        {
            get { return al; }
            set { al = value; }
        }
        public string Alsol
        {
            get { return alsol; }
            set { alsol = value; }
        }
        public string Alinsol
        {
            get { return alinsol; }
            set { alinsol = value; }
        }
        public string Pb
        {
            get { return pb; }
            set { pb = value; }
        }

        /** ikinci grid */
        public string B
        {
            get { return b; }
            set { b = value; }
        }

        public string Bsol
        {
            get { return bsol; }
            set { bsol = value; }
        }
        public string Binsol
        {
            get { return binsol; }
            set { binsol = value; }
        }
        public string Sb
        {
            get { return sb; }
            set { sb = value; }
        }
        public string Nb
        {
            get { return nb; }
            set { nb = value; }
        }

        public string Ca
        {
            get { return ca; }
            set { ca = value; }
        }
        public string Casol
        {
            get { return casol; }
            set { casol = value; }
        }
        public string Cainso
        {
            get { return cainso; }
            set { cainso = value; }
        }
        public string Zn
        {
            get { return zn; }
            set { zn = value; }
        }
        public string N
        {
            get { return n; }
            set { n = value; }
        }
        public string Ti
        {
            get { return ti; }
            set { ti = value; }
        }
        public string Tisol
        {
            get { return tisol; }
            set { tisol = value; }
        }
        public string Tiinsol
        {
            get { return tiinsol; }
            set { tiinsol = value; }
        }

        public string Ass
        {
            get { return ass; }
            set { ass = value; }
        }
        public string Zr
        {
            get { return zr; }
            set { zr = value; }
        }
        public string Bi
        {
            get { return bi; }
            set { bi = value; }
        }
        public string O
        {
            get { return o; }
            set { o = value; }
        }
        public string Fe
        {
            get { return fe; }
            set { fe = value; }
        }
        public string Ceq
        {
            get { return ceq; }
            set { ceq = value; }
        }
        public string Ce
        {
            get { return ce; }
            set { ce = value; }
        }

        /** ucuncu grid */
        public string Crnicu
        {
            get { return crnicu; }
            set { crnicu = value; }
        }

        public string Alcao
        {
            get { return alcao; }
            set { alcao = value; }
        }
        public string Almgo
        {
            get { return almgo; }
            set { almgo = value; }
        }
        public string Alsio
        {
            get { return alsio; }
            set { alsio = value; }
        }
        public string Altio
        {
            get { return altio; }
            set { altio = value; }
        }
        public string Alca
        {
            get { return alca; }
            set { alca = value; }
        }
        public string Alo
        {
            get { return alo; }
            set { alo = value; }
        }

        public string Cao
        {
            get { return cao; }
            set { cao = value; }
        }
        public string Cas
        {
            get { return cas; }
            set { cas = value; }
        }
        public string Tio
        {
            get { return tio; }
            set { tio = value; }
        }
        public string Tial
        {
            get { return tial; }
            set { tial = value; }
        }
        public string Mns
        {
            get { return mns; }
            set { mns = value; }
        }
        public string Mgo
        {
            get { return mgo; }
            set { mgo = value; }
        }

        public string Zro
        {
            get { return zro; }
            set { zro = value; }
        }
        public string Sio
        {
            get { return sio; }
            set { sio = value; }
        }

    }
}
