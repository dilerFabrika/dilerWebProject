using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diler.Entity
{
    public class Uretimler
    {
        private int uretim_id;
        private string uretim_bilgitnm;
        private string dokum_sayisi;
        private string imale_sevk_hurda;
        private string uretim;

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

        public string Uretim_bilgitnm
        {
            get { return uretim_bilgitnm; }
            set { uretim_bilgitnm = value; }
        }
        public string Dokum_sayisi
        {
            get { return dokum_sayisi; }
            set { dokum_sayisi = value; }
        }
        public string Imale_sevk_hurda
        {
            get { return imale_sevk_hurda; }
            set { imale_sevk_hurda = value; }
        }
        public string Uretim
        {
            get { return uretim; }
            set { uretim = value; }
        }
    }
}
