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
    public partial class uretim_sirasi : System.Web.UI.Page
    {
        EndMuh_raporlar_db db = new EndMuh_raporlar_db();
        List<uretim_sira> kayitlar = new List<uretim_sira>();

        //[System.Web.Services.WebMethod]
        //public static string order_detail_pdf_view(string sip_no)
        //{

        //    System.Diagnostics.Process.Start(@"F://DusNet/ISLETME/tools/SIPARIS/CH/" + sip_no.Trim() + ".pdf");
        //    return "1";

        //}
        protected void Page_Load(object sender, EventArgs e)
        {
            db.Connect();
            uretim_siralarini_listele();
            db.Disconnect();

        }

        private void uretim_siralarini_listele()
        {

            StringBuilder htmlTable = new StringBuilder();
            kayitlar = db.uretim_sirasi_data_read();
            if (kayitlar[0].Uretim_id == 0)
            {
                // Kayıt Bulunamadı
                htmlTable.Append(" < tr>");
                htmlTable.Append("<td colspan=\"11\">" + kayitlar[0].Aciklama + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {

                foreach (var kayit in kayitlar)
                {

                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td style=\"padding-top: 20px;\"> " + kayit.Uretim_tarihi + "</td>");
                    htmlTable.Append("<td style=\"padding-top: 20px;\"> " + kayit.Ebat_boy + "</td>");
                    htmlTable.Append("<td style=\"padding-top: 20px;\"> " + kayit.Kalite + "</td>");
                    htmlTable.Append("<td style=\"padding-top: 20px;\"> " + kayit.Uretim_miktari + "</td>");
                    htmlTable.Append("<td style=\"padding-top: 20px;\"> " + kayit.Aciklama + "</td>");
                    htmlTable.Append("<td style=\"padding-top: 20px;\"> " + kayit.Siparis_no + "</td>");
                    htmlTable.Append("<td><input type='button' id='btn_sip_ayrinti' class='sip_ayrinti' value='Sipariş Ayrıntı'" +
                    "style=\"height: 30px; width: 120px; padding: 0px;  background-color: #ffb7b7; color:#323232; font-weight: bold;border: 1px solid #ffb7b7;\"</td>");
                    htmlTable.Append("</tr>");
                    txt_genel_aciklama.Text = "***  " + kayit.Genel_aciklama;
                   
                }
            }
            ph_uretim_sirasi.Controls.Clear();
            ph_uretim_sirasi.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../../Default2.aspx");
        }
    }
}