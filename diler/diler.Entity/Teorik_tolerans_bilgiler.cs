using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace diler.Entity
{
    public class Teorik_tolerans_bilgiler
    {
        private string siparisNo;
        private string cap;
        private string lot;
        private string cubukSayisi;
        private string teorikAgirlik;
        private int id;
        private string lc;
        private string renk;
        private string paketSayisi;
        private string kantarAgirligi;
        private string teorikHaddelemeTolerans;
        private string teorikPaketAgirligi;
        private string boy;
        private string mamkalite;

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
        public string SiparisNo
        {
            get { return siparisNo; }
            set { siparisNo = value; }
        }
        public string Cap
        {
            get { return cap; }
            set { cap = value; }
        }
        public string CubukSayisi
        {
            get { return cubukSayisi; }
            set { cubukSayisi = value; }
        }
        public string Boy
        {
            get { return boy; }
            set { boy = value; }
        }
        public string Lc
        {
            get { return lc; }
            set { lc = value; }
        }
        public string Renk
        {
            get { return renk; }
            set { renk = value; }
        }
        public string TeorikPaketAgirligi
        {
            get { return teorikPaketAgirligi; }
            set { teorikPaketAgirligi = value; }
        }
        public string TeorikHaddelemeTolerans
        {
            get { return teorikHaddelemeTolerans; }
            set { teorikHaddelemeTolerans = value; }
        }

        public string TeorikAgirlik
        {
            get { return teorikAgirlik; }
            set { teorikAgirlik = value; }
        }
        public string Lot
        {
            get { return lot; }
            set { lot = value; }
        }
        public string Mamkalite
        {
            get { return mamkalite; }
            set { mamkalite = value; }
        }

        public string PaketSayisi
        {
            get { return paketSayisi; }
            set { paketSayisi = value; }
        }
        public string KantarAgirligi
        {
            get { return kantarAgirligi; }
            set { kantarAgirligi = value; }
        }



    }
}
