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
    public partial class Refrakter_ : System.Web.UI.Page
    {
        Refrakter_db db = new Refrakter_db();
        List<refrakter_bilgileri> kayitlar = new List<refrakter_bilgileri>();
        List<refrakter_bilgileri> kayitlar2 = new List<refrakter_bilgileri>();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btn_Listele_Click(object sender, EventArgs e)
        {
            string ay = cmb_ay.SelectedValue.ToString();
            string yil = cmb_yil.SelectedItem.ToString();
            string yil_ay = yil + ay;
            string yer = cmb_yer.SelectedItem.ToString();
            // string istif_yeri_test = istif_yeri.Substring(0, 3).Replace("H", "").Trim();
            refrakter_takip_Listele(yil_ay, yer);



        }

        private void refrakter_takip_Listele(string yil_ay, string yer)
        {
            db.Connect();
            kayitlar = db.refrakter_takip_data_read(yil_ay, yer);
            kayitlar2 = db.refrakter_takip_data_read2(yil_ay, yer);
            db.Disconnect();
            ekrana_rafrakteri_listele();
            ekrana_rafrakteri_listele2();
        }

        private void ekrana_rafrakteri_listele()
        {
            StringBuilder htmlTable = new StringBuilder();

            if (kayitlar[0].Id == 0)
            {
                // Kayit Bululnamadı
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan=\"5\">" + kayitlar[0].firma + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {

                foreach (var kayit in kayitlar)
                {

                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td  style=\"text-align: center;font-weight: bold;\">" + kayit.firma + "</td>");
                    htmlTable.Append("<td  style=\"text-align: center;font-weight: bold;\">" + kayit.toplamds + "</td>");
                    htmlTable.Append("<td  style=\"text-align: center;font-weight: bold;\">" + kayit.kullanilan_adet + "</td>");
                    htmlTable.Append("<td style=\"text-align: center;font-weight: bold;\">" + kayit.ortalama_dokumsayisi + "</td>");
                    htmlTable.Append("</tr>");

                }


            }
            ph_refrakter_takip.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }

        private void ekrana_rafrakteri_listele2()
        {
            StringBuilder htmlTable = new StringBuilder();

            if (kayitlar2[0].Id == 0)
            {
                // Kayit Bululnamadı
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan=\"5\">" + kayitlar2[0].firma + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {

                foreach (var kayit in kayitlar2)
                {

                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td  style=\"text-align: center;font-weight: bold;\">" + kayit.firma + "</td>");
                    htmlTable.Append("<td  style=\"text-align: center;font-weight: bold;\">" + kayit.toplamds + "</td>");
                    htmlTable.Append("<td  style=\"text-align: center;font-weight: bold;\">" + kayit.kullanilan_adet + "</td>");
                    htmlTable.Append("<td style=\"text-align: center;font-weight: bold;\">" + kayit.ortalama_dokumsayisi + "</td>");
                    htmlTable.Append("</tr>");

                }
            }
            ph_refrakter_takip_ozet.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../../Default2.aspx");
        }
    }
}