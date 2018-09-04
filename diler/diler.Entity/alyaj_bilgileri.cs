using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diler.Entity
{
    public class alyaj_bilgileri
    {
        public string SARJTIP { get; set; }  
        public string LOKASYON{ get; set; }
        public object DEGERI { get; set; }
    }

    public class alyaj_tnm_bilgileri
    {
        public string LOKASYON { get; set; }
        public string TANIM { get; set; }
        public object GRUPTANIM { get; set; }
    }

}
