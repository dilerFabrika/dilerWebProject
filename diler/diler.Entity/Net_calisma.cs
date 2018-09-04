using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace diler.Entity
{
    public class Net_calisma
    {
        private int id;
        private string cap;
        private string durus;
        private string net_calisma_suresi;
        private string nyfd;
        private string tonaj;
        private string tonaj_kisaparca;
        private string kutuk_tonaj;
        private string ambardepo;

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
        public string Cap
        {
            get { return cap; }
            set { cap = value; }
        }
        public string Durus
        {
            get { return durus; }
            set { durus = value; }
        }
        public string Net_calisma_suresi
        {
            get { return net_calisma_suresi; }
            set { net_calisma_suresi = value; }
        }
        public string Nyfd
        {
            get { return nyfd; }
            set { nyfd = value; }
        }
        public string Tonaj
        {
            get { return tonaj; }
            set { tonaj = value; }
        }
        public string Kutuk_tonaj
        {
            get { return kutuk_tonaj; }
            set { kutuk_tonaj = value; }
        }
        public string Ambardepo
        {
            get { return ambardepo; }
            set { ambardepo = value; }
        }
        public string Tonaj_kisaparca
        {
            get { return tonaj_kisaparca; }
            set { tonaj_kisaparca = value; }
        }


    }
}
