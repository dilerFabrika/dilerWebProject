using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diler.Entity
{
    public class Enerjiler
    {
        private int enerji_id;
        private string enerji_bilgitnm;
        private string gun_kwh;
        private string gun_kwh_ton;
        private string ay_kwh;
        private string ay_kwh_ton;
        private string yil_kwh;
        private string yil_kwh_ton;

        public int Enerji_id
        {
            get { return enerji_id; }
            set
            {
                if (value < 0)
                {
                    enerji_id = 0;
                }
                else
                {
                    enerji_id = value;
                }
            }
        }

        public string Enerji_bilgitnm
        {
            get { return enerji_bilgitnm; }
            set { enerji_bilgitnm = value; }
        }
        public string Gun_kwh
        {
            get { return gun_kwh; }
            set { gun_kwh = value; }
        }
        public string Gun_kwh_ton
        {
            get { return gun_kwh_ton; }
            set { gun_kwh_ton = value; }
        }
        public string Ay_kwh
        {
            get { return ay_kwh; }
            set { ay_kwh = value; }
        }
        public string Ay_kwh_ton
        {
            get { return ay_kwh_ton; }
            set { ay_kwh_ton = value; }
        }
        public string Yil_kwh
        {
            get { return yil_kwh; }
            set { yil_kwh = value; }
        }
        public string Yil_kwh_ton
        {
            get { return yil_kwh_ton; }
            set { yil_kwh_ton = value; }
        }
    }
}
