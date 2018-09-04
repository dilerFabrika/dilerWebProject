using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diler.Entity
{
    public class Duruslar
    {
        private int durus_id;
        private string durus_nedeni;
        private string gun_sure;
        private string gun_tekrar;
        private string gun_yuzde;
        private string ay_sure;
        private string ay_tekrar;
        private string ay_yuzde;
        private string yil_sure;
        private string yil_tekrar;
        private string yil_yuzde;

        public int Durus_id
        {
            get { return durus_id; }
            set
            {
                if (value < 0)
                {
                    durus_id = 0;
                }
                else
                {
                    durus_id = value;
                }
            }
        }

        public string Durus_nedeni
        {
            get { return durus_nedeni; }
            set { durus_nedeni = value; }
        }
        public string Gun_sure
        {
            get { return gun_sure; }
            set { gun_sure = value; }
        }
        public string Gun_tekrar
        {
            get { return gun_tekrar; }
            set { gun_tekrar = value; }
        }
        public string Gun_yuzde
        {
            get { return gun_yuzde; }
            set { gun_yuzde = value; }
        }
        public string Ay_sure
        {
            get { return ay_sure; }
            set { ay_sure = value; }
        }
        public string Ay_tekrar
        {
            get { return ay_tekrar; }
            set { ay_tekrar = value; }
        }
        public string Ay_yuzde
        {
            get { return ay_yuzde; }
            set { ay_yuzde = value; }
        }

        public string Yil_sure
        {
            get { return yil_sure; }
            set { yil_sure = value; }
        }
        public string Yil_tekrar
        {
            get { return yil_tekrar; }
            set { yil_tekrar = value; }
        }
        public string Yil_yuzde
        {
            get { return yil_yuzde; }
            set { yil_yuzde = value; }
        }

    }
}
