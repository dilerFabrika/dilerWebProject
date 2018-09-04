using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace diler.Entity
{
    public class Tanim_bilgileri
    {
        public int Id { get; set; }

        public string Tesis { get; set; }

        public string Tanim_tipi { get; set; }
  
        public string Ekransirano { get; set; }
        public string Kod { get; set; }
        public string Kod_ack { get; set; }
        public string As400kod { get; set; }
        public string As400_ambardepo { get; set; }
        public string prg1 { get; set; }
        public string prg2 { get; set; }
        public string As400_isim { get; set; }
        public string Pc_isim { get; set; }
        public string Pc_kod { get; set; }
    }
}
