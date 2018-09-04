using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace diler.Entity
{
    public class R_enerji
    {
        private int id;
        private string kalite;
        private string hurda;
        private string dokum_no;
        private string tarih;
        private string dokum_tip;
        private string sip_no;

        private string ao_enerji;
        private string ao_tirnak_kapatma_enerjisi;
        private string brl_dgaz;
        private string rcb_brl_dgaz;
        private string pc_dgaz;
        private string po_enerji;




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

        public string Kalite
        {
            get { return kalite; }
            set { kalite = value; }
        }
        public string Hurda
        {
            get { return hurda; }
            set { hurda = value; }
        }
        public string Tarih
        {
            get { return tarih; }
            set { tarih = value; }
        }
        public string Dokum_no
        {
            get { return dokum_no; }
            set { dokum_no = value; }
        }
        public string Dokum_tip
        {
            get { return dokum_tip; }
            set { dokum_tip = value; }
        }
        public string Sip_no
        {
            get { return sip_no; }
            set { sip_no = value; }
        }
        public string Ao_enerji
        {
            get { return ao_enerji; }
            set { ao_enerji = value; }
        }
        public string Ao_tirnak_kapatma_enerjisi
        {
            get { return ao_tirnak_kapatma_enerjisi; }
            set { ao_tirnak_kapatma_enerjisi = value; }
        }
        public string Brl_dgaz
        {
            get { return brl_dgaz; }
            set { brl_dgaz = value; }
        }
        public string Rcb_brl_dgaz
        {
            get { return rcb_brl_dgaz; }
            set { rcb_brl_dgaz = value; }
        }
        public string Pc_dgaz
        {
            get { return pc_dgaz; }
            set { pc_dgaz = value; }
        }
        public string Po_enerji
        {
            get { return po_enerji; }
            set { po_enerji = value; }
        }

    }
}
