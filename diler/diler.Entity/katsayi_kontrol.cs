using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace diler.Entity
{
    public class katsayi_kontrol
    {
        public string dokumNo { get; set; }
        public string sira { get; set; }
        public string vrd { get; set; }
        public string ebat { get; set; }
        public string boy { get; set; }
        public string celikcinsi { get; set; }
        public string kütükadet { get; set; }
        public string kütüktonaj { get; set; }
        public string uretim_katsayisi { get; set; }

        public string karisimadet { get; set; }
        public string karisimtonaj { get; set; }
        public string karisim_katsayi { get; set; }

        public string tartim_katsayisi { get; set; }


        public string Update_DokumNo { get; set; }
        public string Update_DokumSıraNo { get; set; }
        public string Update_Alan { get; set; }


        public int Gun_TK_Top { get; set; }
        public int Gun_ACYK_Top { get; set; }

        public Decimal Gun_TK_Tnj { get; set; }
        public Decimal Gun_ACYK_Tnj { get; set; }



        public int Ay_TK_Top { get; set; }
        public int Ay_ACYK_Top { get; set; }

        public Decimal Ay_TK_Tnj { get; set; }
        public Decimal Ay_ACYK_Tnj { get; set; }



        public int Yıl_TK_Top { get; set; }
        public int Yıl_ACYK_Top { get; set; }

        public Decimal Yıl_TK_Tnj { get; set; }
        public Decimal Yıl_ACYK_Tnj { get; set; }



    }
}
