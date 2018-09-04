using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace diler.Entity
{
    public class Hh_vrd_Ozet
    {

        private int id;
        private string tarih;
        private string sicak_soguk_sarjadet;
        private string vrd;
        private string mamul_standart;
        private string mamul_ebat;
        private string mamul_boy;
        private string mamul_cap;
        private string mamul_tonaj;
        private string kisa_parca;
        private string hadde_bozugu;
        private string ucbas;
        private string kutuk_kalitesi;
        private string kutuk_boy;
        private string kutuk_ebat;
        private string kutuk_tonaj;
        private string kutuk_adet;
        private string ny;
        private string fd;
        private string iade;

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
        public string Mamul_ebat
        {
            get { return mamul_ebat; }
            set { mamul_ebat = value; }
        }
        public string Iade
        {
            get { return iade; }
            set { iade = value; }
        }
        public string Sicak_soguk_sarjadet
        {
            get { return sicak_soguk_sarjadet; }
            set { sicak_soguk_sarjadet = value; }
        }
        public string Tarih
        {
            get { return tarih; }
            set { tarih = value; }
        }
        public string Mamul_boy
        {
            get { return mamul_boy; }
            set { mamul_boy = value; }
        }
        public string Mamul_cap
        {
            get { return mamul_cap; }
            set { mamul_cap = value; }
        }
        public string Mamul_tonaj
        {
            get { return mamul_tonaj; }
            set { mamul_tonaj = value; }
        }
        public void Kisa_parca(string value)
        {
            kisa_parca = value;
        }
        public string GetKisa_parca()
        {
            return kisa_parca;
        }
        public string Hadde_bozugu
        {
            get { return hadde_bozugu; }
            set { hadde_bozugu = value; }
        }
        public string Ucbas
        {
            get { return ucbas; }
            set { ucbas = value; }
        }
        public string Kutuk_boy
        {
            get { return kutuk_boy; }
            set { kutuk_boy = value; }
        }
        public string Kutuk_ebat
        {
            get { return kutuk_ebat; }
            set { kutuk_ebat = value; }
        }
        public string Kutuk_tonaj
        {
            get { return kutuk_tonaj; }
            set { kutuk_tonaj = value; }
        }
        public string Kutuk_adet
        {
            get { return kutuk_adet; }
            set { kutuk_adet = value; }
        }
        public string Ny
        {
            get { return ny; }
            set { ny = value; }
        }
        public string Fd
        {
            get { return fd; }
            set { fd = value; }
        }
        public string Kutuk_kalitesi
        {
            get { return kutuk_kalitesi; }
            set { kutuk_kalitesi = value; }
        }
        public string Mamul_standart
        {
            get { return mamul_standart; }
            set { mamul_standart = value; }
        }
        public string Vrd
        {
            get { return vrd; }
            set { vrd = value; }
        }

    }
}
