using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace diler.Entity
{
    public class refrakter_bilgileri
    {
        public int Id { get; set; }
        public object DOKUMNO { get; set; }
        public object BASLANGICTARIHI { get; set; }
        public object TARIH { get; set; }
        public object POTANO { get; set; }
        public object DKMSAYISI { get; set; }
        public string TUGLAFIRMA { get; set; }
        public string POTADURUM { get; set; }
        public object PUSKURTMELI { get; set; }
        public object GAZTAPASIDS { get; set; }
        public string gazFirma { get; set; }
        public string gazTip { get; set; }
        public object USTNOZULDS { get; set; }
        public string ustFirma { get; set; }
        public object ALTNOZULDS { get; set; }
        public string altFirma { get; set; }
        public object SURGUDS { get; set; }
        public string SURGUFIRMA { get; set; }
        public string SURGUPLKTY { get; set; }
        public string KONTROLEDEN { get; set; }
        public string ACIKLAMA { get; set; }
        public object ISKARTATARIHI { get; set; }
        public object POTAGELISSAATI { get; set; }
        public object POTACIKISSAATI { get; set; }
        public object TANDIS_PLK_FRM { get; set; }
        public object firma { get; set; }
        public object toplamds { get; set; }
        public object kullanilan_adet { get; set; }

        public object ortalama_dokumsayisi { get; set; }


    }
}
