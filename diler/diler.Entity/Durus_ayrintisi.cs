using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diler.Entity
{
    public class Durus_ayrintisi
    {
        private int durus_ayrintisi_id;
        private string durus_tipi;
        private string ariza_nedeni;
        private string toplam_sure;
        private string gun_tekrar;

        public int Durus_ayrintisi_id
        {
            get { return durus_ayrintisi_id; }
            set { durus_ayrintisi_id = value; }
        }
        public string Durus_tipi
        {
            get { return durus_tipi; }
            set { durus_tipi = value; }
        }
        public string Ariza_nedeni
        {
            get { return ariza_nedeni; }
            set { ariza_nedeni = value; }
        }
        public string Toplam_sure
        {
            get { return toplam_sure; }
            set { toplam_sure = value; }
        }
        public string Gun_tekrar
        {
            get { return gun_tekrar; }
            set { gun_tekrar = value; }
        }
    }
}
