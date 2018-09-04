using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace diler.Entity
{
    public class uretim_sira
    {
        private int uretim_id;
        private string uretim_miktari;
        private string ebat_boy;
        private string aciklama;
        private string kalite;
        private string siparis_no;
        private string uretim_tarihi;
        private string genel_aciklama;

        public int Uretim_id
        {
            get { return uretim_id; }
            set
            {
                if (value < 0)
                {
                    uretim_id = 0;
                }
                else
                {
                    uretim_id = value;
                }
            }
        }

        public string Uretim_miktari
        {
            get { return uretim_miktari; }
            set { uretim_miktari = value; }
        }
        public string Ebat_boy
        {
            get { return ebat_boy; }
            set { ebat_boy = value; }
        }
        public string Aciklama
        {
            get { return aciklama; }
            set { aciklama = value; }
        }
        public string Kalite
        {
            get { return kalite; }
            set { kalite = value; }
        }
        public string Siparis_no
        {
            get { return siparis_no; }
            set { siparis_no = value; }
        }
        public string Uretim_tarihi
        {
            get { return uretim_tarihi; }
            set { uretim_tarihi = value; }
        }
        public string Genel_aciklama
        {
            get { return genel_aciklama; }
            set { genel_aciklama = value; }
        }

    }
}