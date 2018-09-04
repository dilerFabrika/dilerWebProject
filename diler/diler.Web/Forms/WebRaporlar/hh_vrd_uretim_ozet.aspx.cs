using diler.Dal;
using diler.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace diler.Web.Forms.WebRaporlar
{
    public partial class hh_vrd_uretim_ozet : System.Web.UI.Page
    {
        EndMuh_raporlar_db db = new EndMuh_raporlar_db();
        StringBuilder htmlTable = new StringBuilder();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DateTime dt = new DateTime();
                dt = DateTime.Now;
                string tarih = dt.ToString("yyyyMMdd");//veritabanindaki kayit bicimi
                string tarih2 = dt.ToString("yyyy-MM-dd");//textboxdaki bicimi
                tx_rapor_tarihi.Text = tarih2;
                raporlari_getir(tarih);

            }

        }

        private void raporlari_getir(string tarih)
        {

            db.Connect();

            imal_olunan_mamul_bilgileri(tarih);
            ozet(tarih);
            imalata_sevk_edilen_kutuk_bilgileri(tarih);


            db.Disconnect();
        }
        private void ozet(string tarih)
        {
            htmlTable.Clear();
            List<Hh_vrd_Ozet> hh_vrd_ozet = new List<Hh_vrd_Ozet>();
            hh_vrd_ozet = db.ozet_data_read(tarih);

            if (hh_vrd_ozet[0].Id == 0)
            {
                //kayit bulunamadi
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan='10'>" + hh_vrd_ozet[0].Hadde_bozugu + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var h in hh_vrd_ozet)
                {
                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td>" + h.Vrd + "</td>");
                    htmlTable.Append("<td>" + h.Kutuk_tonaj.Replace(",", ".") + "</td>");
                    htmlTable.Append("<td>" + h.Mamul_tonaj.Replace(",", ".") + "</td>");
                    htmlTable.Append("<td>" + h.GetKisa_parca().Replace(",", ".") + "</td>");
                    htmlTable.Append("<td>" + h.Hadde_bozugu.Replace(",", ".") + "</td>");
                    htmlTable.Append("<td>" + h.Ucbas + "</td>");

                    htmlTable.Append("</tr>");
                }
            }
            ph_ozet.Controls.Clear();
            ph_ozet.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }
        private void imal_olunan_mamul_bilgileri(string tarih)
        {
            htmlTable.Clear();
            List<Hh_vrd_Ozet> hh_vrd_ozet = new List<Hh_vrd_Ozet>();
            hh_vrd_ozet = db.imal_olunan_mamul_bilgileri_data_read(tarih);

            if (hh_vrd_ozet[0].Id == 0)
            {
                //kayit bulunamadi
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan='10'>" + hh_vrd_ozet[0].Hadde_bozugu + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var h in hh_vrd_ozet)
                {
                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td>" + h.Vrd + "</td>");
                    htmlTable.Append("<td>" + h.Mamul_standart + "</td>");
                    htmlTable.Append("<td>" + h.Mamul_cap + "</td>");
                    htmlTable.Append("<td>" + h.Mamul_boy + "</td>");
                    htmlTable.Append("<td>" + h.Ny + "</td>");
                    htmlTable.Append("<td>" + h.Fd + "</td>");
                    htmlTable.Append("<td>" + h.Mamul_tonaj.Replace(",", ".") + "</td>");

                    htmlTable.Append("</tr>");
                }
            }
            ph_imal_olunan_mamul_bilgileri.Controls.Clear();
            ph_imal_olunan_mamul_bilgileri.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }
        private void imalata_sevk_edilen_kutuk_bilgileri(string tarih)
        {
            htmlTable.Clear();
            List<Hh_vrd_Ozet> hh_vrd_ozet = new List<Hh_vrd_Ozet>();
            hh_vrd_ozet = db.imalata_sevk_edilen_kutuk_bilgileri_data_read(tarih);

            if (hh_vrd_ozet[0].Id == 0)
            {
                //kayit bulunamadi
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan='10'>" + hh_vrd_ozet[0].Hadde_bozugu + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var h in hh_vrd_ozet)
                {
                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td>" + h.Vrd + "</td>");
                    htmlTable.Append("<td>" + h.Kutuk_kalitesi + "</td>");
                    htmlTable.Append("<td>" + h.Kutuk_ebat + "</td>");
                    htmlTable.Append("<td>" + h.Kutuk_boy + "</td>");
                    htmlTable.Append("<td>" + h.Kutuk_adet + "</td>");
                    htmlTable.Append("<td>" + h.Iade + "</td>");
                    htmlTable.Append("<td>" + h.Kutuk_adet + "</td>");
                    htmlTable.Append("<td>" + h.Kutuk_tonaj.Replace(",", ".") + "</td>");
                    htmlTable.Append("</tr>");
                }
            }
            ph_imalata_sevk_edilen_kutukbilgisi.Controls.Clear();
            ph_imalata_sevk_edilen_kutukbilgisi.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }

        protected void tx_rapor_tarihi_TextChanged(object sender, EventArgs e)
        {
            string tarih2 = tx_rapor_tarihi.Text;//textboxdaki bicimi
            string tarih = tarih2.Replace("-", "");//veritabanindaki kayit bicimi

            raporlari_getir(tarih);
        }
    }
}