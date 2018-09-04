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
    public partial class Flm_genel_uretim : System.Web.UI.Page
    {
        EndMuh_raporlar_db db = new EndMuh_raporlar_db();
        StringBuilder htmlTable = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DateTime dt = new DateTime();
                dt = DateTime.Now;
                string tarih = dt.AddDays(-1).ToString("yyyyMMdd");//veritabanindaki kayit bicimi
                //string tarih2 = dt.AddDays(-1).ToString("yyyy-MM-dd");//textboxdaki bicimi
                //string tarih = dt.ToString("yyyyMMdd");//veritabanindaki kayit bicimi  
                string tarih2 = dt.AddDays(-1).ToString("yyyy-MM-dd");//textboxdaki bicimi
                tx_rapor_tarihi.Text = tarih2;
                tx_rapor_tarihi2.Text = tarih2;
                raporlari_getir(tarih, tarih);
            }
        }



        protected void btn_Listele_Click(object sender, EventArgs e)
        {
            string tarih_bas = tx_rapor_tarihi.Text;//textboxdaki bicimi
            string tarih = tarih_bas.Replace("-", "");//veritabanindaki kayit bicimi
            string tarih_bitis = tx_rapor_tarihi2.Text;
            string tarih2 = tarih_bitis.Replace("-", "");

            tx_rapor_tarihi.Text = tarih_bas;
            tx_rapor_tarihi2.Text = tarih_bitis;

            raporlari_getir(tarih, tarih2);
        }
        private void raporlari_getir(string tarih, string tarih2)
        {
            db.flm_connect();
            filmasin_genel_uretim(tarih, tarih2);

            db.flm_Disconnect();
        }

        private void filmasin_genel_uretim(string tarih, string tarih2)
        {
            htmlTable.Clear();
            List<Hh_vrd_Ozet> filmasin_genel_uretim = new List<Hh_vrd_Ozet>();
            filmasin_genel_uretim = db.filmasin_genel_uretim_data_read(tarih, tarih2);

            if (filmasin_genel_uretim[0].Id == 0)
            {
                //kayit bulunamadi
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan='16'>" + filmasin_genel_uretim[0].Hadde_bozugu + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var h in filmasin_genel_uretim)
                {

                    if (h.Tarih == "TOPLAM")
                    {
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td style=\"color: #e602f3; font-weight:bold \">" + h.Tarih + "</td>");
                        htmlTable.Append("<td style=\"color: #e602f3; font-weight:bold\">" + h.Kutuk_kalitesi + "</td>");
                        htmlTable.Append("<td style=\"color: #e602f3; font-weight:bold\">" + h.Kutuk_tonaj.Replace(",", ".") + "</td>");
                        htmlTable.Append("<td style=\"color: #e602f3;\">" + h.Mamul_standart + "</td>");
                        htmlTable.Append("<td style=\"color: #e602f3;\">" + h.Mamul_cap + "</td>");
                        htmlTable.Append("<td style=\"color: #e602f3;\">" + h.Ny + "</td>");
                        htmlTable.Append("<td style=\"color: #e602f3; font-weight:bold\">" + h.Mamul_tonaj.Replace(",", ".") + "</td>");
                        htmlTable.Append("<td style=\"color: #e602f3; font-weight:bold\">" + h.Hadde_bozugu.Replace(",", ".") + "</td>");
                        htmlTable.Append("<td style=\"color: #e602f3; font-weight:bold\">" + h.Ucbas.Replace(",", ".") + "</td>");
                        htmlTable.Append("</tr>");
                    }
                    else
                    {
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td>" + h.Tarih + "</td>");
                        htmlTable.Append("<td>" + h.Kutuk_kalitesi + "</td>");
                        htmlTable.Append("<td>" + h.Kutuk_tonaj.Replace(",", ".") + "</td>");
                        htmlTable.Append("<td>" + h.Mamul_standart + "</td>");
                        htmlTable.Append("<td>" + h.Mamul_cap + "</td>");

                        htmlTable.Append("<td>" + h.Ny + "</td>");

                        htmlTable.Append("<td>" + h.Mamul_tonaj.Replace(",", ".") + "</td>");
                        htmlTable.Append("<td>" + h.Hadde_bozugu + "</td>");
                        htmlTable.Append("<td>" + h.Ucbas + "</td>");

                        htmlTable.Append("</tr>");
                    }


                }
            }
            ph_filmasin_uretim_raporu.Controls.Clear();
            ph_filmasin_uretim_raporu.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../../Default2.aspx");
        }
    }
}