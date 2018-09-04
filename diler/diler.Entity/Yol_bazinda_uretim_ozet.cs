using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace diler.Entity
{
    public class Yol_bazinda_uretim_ozet
    {
        int ybu_id;
        string vrd;
        string yol;
        string net_urt;
        string mamul;

        public string Mamul
        {
            get { return mamul; }
            set { mamul = value; }
        }
        public string Net_urt
        {
            get { return net_urt; }
            set { net_urt = value; }
        }
        public string Yol
        {
            get { return yol; }
            set { yol = value; }
        }
        public string Vrd
        {
            get { return vrd; }
            set { vrd = value; }
        }

        public int Ybu_id
        {
            get { return ybu_id; }
            set { ybu_id = value; }
        }
    }
}