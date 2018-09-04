using diler.Dal;
using diler.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace diler.Web.Forms.EndMuh
{
    public partial class net_calisma_suresi : System.Web.UI.Page
    {

        EndMuh_raporlar_db db = new EndMuh_raporlar_db();
        List<Net_calisma> kayitlar = new List<Net_calisma>();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btn_Listele_Click(object sender, EventArgs e)
        {
            string ay = cmb_ay.SelectedValue.ToString();
            string yil = cmb_yil.SelectedItem.ToString();
            string yil_ay = yil + ay;

            db.Connect();
            cubuk_haddehane_verileri_Listele(yil_ay);
            tel_cubuk_haddehane_verileri_Listele(yil_ay);
            db.Disconnect();

        }


        private void cubuk_haddehane_verileri_Listele(string yil_ay)
        {
            StringBuilder htmlTable = new StringBuilder();        
            kayitlar = db.cubuk_haddehane_data_read(yil_ay);          
            if (kayitlar[0].Id == 0)
            {
                // Kayit Bulunamadı
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan=\"8\">" + kayitlar[0].Durus + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {

                foreach (var kayit in kayitlar)
                {

                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td>" + kayit.Cap + "</td>");
                    htmlTable.Append("<td>" + kayit.Nyfd + "</td>");
                    htmlTable.Append("<td>" + kayit.Durus + "</td>");
                    htmlTable.Append("<td>" + kayit.Net_calisma_suresi + "</td>");
                    htmlTable.Append("<td>" + kayit.Tonaj_kisaparca + "</td>");
                    htmlTable.Append("<td>" + kayit.Kutuk_tonaj + "</td>");
                    htmlTable.Append("</tr>");

                }


            }
            ph_cubuk_haddehane.Controls.Clear();
            ph_cubuk_haddehane.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }
        private void tel_cubuk_haddehane_verileri_Listele(string yil_ay)
        {
            StringBuilder htmlTable = new StringBuilder();
            kayitlar = db.tel_cubuk_haddehane_data_read(yil_ay);
            if (kayitlar[0].Id == 0)
            {
                // Kayit Bulunamadı
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan=\"10\">" + kayitlar[0].Durus + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {

                foreach (var kayit in kayitlar)
                {

                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td>" + kayit.Cap + "</td>");
                    htmlTable.Append("<td>" + kayit.Nyfd + "</td>");
                    htmlTable.Append("<td>" + kayit.Ambardepo + "</td>");
                    htmlTable.Append("<td>" + kayit.Durus + "</td>");
                    htmlTable.Append("<td>" + kayit.Net_calisma_suresi + "</td>");
                    htmlTable.Append("<td>" + kayit.Tonaj + "</td>");
                    htmlTable.Append("<td>" + kayit.Kutuk_tonaj + "</td>");
                    htmlTable.Append("</tr>");

                }


            }
            ph_telcubuk_haddehane.Controls.Clear();
            ph_telcubuk_haddehane.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }


        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../../Default2.aspx");
        }
    }
}