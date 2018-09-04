using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace diler.Entity
{
    public class Uretim_ozetler
    {
        private int uretim_ozet_id;
        private string kalite;
        private string ebat;
        private string boy;
        private string tonaj;

        public int Uretim_ozet_id
        {
            get { return uretim_ozet_id; }
            set
            {
                if (value < 0)
                {
                    uretim_ozet_id = 0;
                }
                else
                {
                    uretim_ozet_id = value;
                }
            }
        }
        public string Kalite
        {
            get { return kalite; }
            set { kalite = value; }
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
        public string Tonaj
        {
            get { return tonaj; }
            set { tonaj = value; }
        }
    }
}
