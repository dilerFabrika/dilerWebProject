using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diler.Entity
{
    public class Sarfiyatlar
    {
        private int sarfiyat_id;
        private string sarfiyat_bilgitnm;
        private string gun_miktar;
        private string gun_ton;
        private string ay_miktar;
        private string ay_ton;
        private string yil_miktar;
        private string yil_ton;

        public int Sarfiyat_id
        {
            get { return sarfiyat_id; }
            set
            {
                if (value < 0)
                {
                    sarfiyat_id = 0;
                }
                else
                {
                    sarfiyat_id = value;
                }
            }
        }

        public string Sarfiyat_bilgitnm
        {
            get { return sarfiyat_bilgitnm; }
            set { sarfiyat_bilgitnm = value; }
        }
        public string Gun_miktar
        {
            get { return gun_miktar; }
            set { gun_miktar = value; }
        }
        public string Gun_ton
        {
            get { return gun_ton; }
            set { gun_ton = value; }
        }
        public string Ay_miktar
        {
            get { return ay_miktar; }
            set { ay_miktar = value; }
        }
        public string Ay_ton
        {
            get { return ay_ton; }
            set { ay_ton = value; }
        }
        public string Yil_miktar
        {
            get { return yil_miktar; }
            set { yil_miktar = value; }
        }
        public string Yil_ton
        {
            get { return yil_ton; }
            set { yil_ton = value; }
        }
    }
}
