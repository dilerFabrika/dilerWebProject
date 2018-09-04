using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace diler.Entity
{
    public class Ortak_rapor
    {
        private int ortak_rapor_id;
        private string bilgitnm;
        private string diler_gun;
        private string diler_gun_ort;
        private string diler_ay;
        private string diler_ay_ort;
        private string diler_yil;
        private string diler_yil_ort;
        private string diler_yil_tempo;
        private string yazici_gun;
        private string yazici_gun_ort;
        private string yazici_ay;
        private string yazici_ay_ort;
        private string yazici_yil;
        private string yazici_yil_ort;
        private string yazici_yil_tempo;
        private string diler_toplam_yil_tempo;
        private string yazici_toplam_yil_tempo;

        public string Yazici_toplam_yil_tempo
        {
            get { return yazici_toplam_yil_tempo; }
            set { yazici_toplam_yil_tempo = value; }
        }

        public string Diler_toplam_yil_tempo
        {
            get { return diler_toplam_yil_tempo; }
            set { diler_toplam_yil_tempo = value; }
        }

        public string Yazici_yil_tempo
        {
            get { return yazici_yil_tempo; }
            set { yazici_yil_tempo = value; }
        }

        public string Yazici_yil_ort
        {
            get { return yazici_yil_ort; }
            set { yazici_yil_ort = value; }
        }

        public string Yazici_yil
        {
            get { return yazici_yil; }
            set { yazici_yil = value; }
        }

        public string Yazici_ay_ort
        {
            get { return yazici_ay_ort; }
            set { yazici_ay_ort = value; }
        }

        public string Yazici_ay
        {
            get { return yazici_ay; }
            set { yazici_ay = value; }
        }

        public string Yazici_gun_ort
        {
            get { return yazici_gun_ort; }
            set { yazici_gun_ort = value; }
        }

        public string Yazici_gun
        {
            get { return yazici_gun; }
            set { yazici_gun = value; }
        }

        public string Diler_yil_tempo
        {
            get { return diler_yil_tempo; }
            set { diler_yil_tempo = value; }
        }

        public string Diler_yil_ort
        {
            get { return diler_yil_ort; }
            set { diler_yil_ort = value; }
        }

        public string Diler_yil
        {
            get { return diler_yil; }
            set { diler_yil = value; }
        }

        public string Diler_ay_ort
        {
            get { return diler_ay_ort; }
            set { diler_ay_ort = value; }
        }

        public string Diler_ay
        {
            get { return diler_ay; }
            set { diler_ay = value; }
        }

        public string Diler_gun_ort
        {
            get { return diler_gun_ort; }
            set { diler_gun_ort = value; }
        }


        public int Ortak_rapor_id
        {
            get { return ortak_rapor_id; }
            set
            {
                if (value < 0)
                {
                    ortak_rapor_id = 0;
                }
                else
                {
                    ortak_rapor_id = value;
                }
            }
        }
        public string Bilgitnm
        {
            get { return bilgitnm; }
            set { bilgitnm = value; }
        }
        public string Diler_gun
        {
            get { return diler_gun; }
            set { diler_gun = value; }
        }

    }
}
