using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace diler.Entity
{
    public class Istif_bilgileri
    {
        private string saha_tanim;
        private string stok_yeri;
        private string istif_yeri;
        private string istif_adet;
        private int id;
        private string aciklama;

        private string sipno;
        private string lot;
        private string istif_sirano;
        private string celik_cinsi_orj;
        private string ebat;
        private string boy;
        private string celik_cinsi;

        private string dokum_no;
        private string dokum_tarihi;
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
        public string Dokum_tarihi
        {
            get { return dokum_tarihi; }
            set { dokum_tarihi = value; }
        }
        public string Dokum_no
        {
            get { return dokum_no; }
            set { dokum_no = value; }
        }
        public string Stok_yeri
        {
            get { return stok_yeri; }
            set { stok_yeri = value; }
        }
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
        public string Istif_yeri
        {
            get { return istif_yeri; }
            set { istif_yeri = value; }
        }
        public string Istif_adet
        {
            get { return istif_adet; }
            set { istif_adet = value; }
        }
        public string Saha_tanim
        {
            get { return saha_tanim; }
            set { saha_tanim = value; }
        }
        public string Celik_cinsi_orj
        {
            get { return celik_cinsi_orj; }
            set { celik_cinsi_orj = value; }
        }
        public string Celik_cinsi
        {
            get { return celik_cinsi; }
            set { celik_cinsi = value; }
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

        public string Aciklama
        {
            get { return aciklama; }
            set { aciklama = value; }
        }
    }
}
