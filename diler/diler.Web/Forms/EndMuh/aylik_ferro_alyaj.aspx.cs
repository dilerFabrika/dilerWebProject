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
    public partial class aylik_ferro_alyaj : System.Web.UI.Page
    {
        EndMuh_raporlar_db db = new EndMuh_raporlar_db();
        List<Aylik_alyaj_rapor_bilgileri> kayitlar = new List<Aylik_alyaj_rapor_bilgileri>();
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btn_Listele_Click(object sender, EventArgs e)
        {
            string ay = cmb_ay.SelectedValue.ToString();
            string yil = cmb_yil.SelectedItem.ToString();
            string yil_ay = yil + ay;

            aylik_alyaj_raporu_listele(yil_ay);


        }

        private void aylik_alyaj_raporu_listele(string yil_ay)
        {
            StringBuilder htmlTable = new StringBuilder();
            db.Connect();
            kayitlar = db.aylik_alyaj_data_read(yil_ay);
            db.Disconnect();
            if (kayitlar[0].Id == 0)
            {
                // Kayit Bulunamadı
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan=\"60\">" + kayitlar[0].Celik_cinsi + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {

                foreach (var kayit in kayitlar)
                {

                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td>" + kayit.Celik_cinsi + "</td>");
                    htmlTable.Append("<td>" + kayit.Hurda + "</td>");
                    htmlTable.Append("<td>" + kayit.Tonaj + "</td>");
                    htmlTable.Append("<td>" + kayit.Aokok + "</td>");
                    htmlTable.Append("<td>" + kayit.Aokok_kg + "</td>");
                    htmlTable.Append("<td>" + kayit.Pokok + "</td>");
                    htmlTable.Append("<td>" + kayit.Pokok_kg + "</td>");
                    htmlTable.Append("<td>" + kayit.Aokirec + "</td>");
                    htmlTable.Append("<td>" + kayit.Aokirec_kg + "</td>");
                    htmlTable.Append("<td>" + kayit.Pokirec + "</td>");
                    htmlTable.Append("<td>" + kayit.Pokirec_kg + "</td>");
                    htmlTable.Append("<td>" + kayit.Fesi + "</td>");
                    htmlTable.Append("<td>" + kayit.Fesi_kg + "</td>");
                    htmlTable.Append("<td>" + kayit.Fesimn + "</td>");
                    htmlTable.Append("<td>" + kayit.Fesimn_kg + "</td>");
                    htmlTable.Append("<td>" + kayit.Al + "</td>");
                    htmlTable.Append("<td>" + kayit.Al_kg + "</td>");
                    htmlTable.Append("<td>" + kayit.Alwire + "</td>");
                    htmlTable.Append("<td>" + kayit.Alwire_kg + "</td>");
                    htmlTable.Append("<td>" + kayit.Boksit + "</td>");
                    htmlTable.Append("<td>" + kayit.Boksit_kg + "</td>");
                    htmlTable.Append("<td>" + kayit.Cac2 + "</td>");
                    htmlTable.Append("<td>" + kayit.Cac2_kg + "</td>");
                    htmlTable.Append("<td>" + kayit.Cafe + "</td>");
                    htmlTable.Append("<td>" + kayit.Cafe_kg + "</td>");
                    htmlTable.Append("<td>" + kayit.Caf2 + "</td>");
                    htmlTable.Append("<td>" + kayit.Caf2_kg + "</td>");
                    htmlTable.Append("<td>" + kayit.Casi + "</td>");
                    htmlTable.Append("<td>" + kayit.Casi_kg + "</td>");
                    htmlTable.Append("<td>" + kayit.Dolamit + "</td>");
                    htmlTable.Append("<td>" + kayit.Dolamit_kg + "</td>");
                    htmlTable.Append("<td>" + kayit.Dolamitik_kirec + "</td>");
                    htmlTable.Append("<td>" + kayit.Dolamitik_kirec_kg + "</td>");
                    htmlTable.Append("<td>" + kayit.Feb + "</td>");
                    htmlTable.Append("<td>" + kayit.Feb_kg + "</td>");
                    htmlTable.Append("<td>" + kayit.Fecr + "</td>");
                    htmlTable.Append("<td>" + kayit.Fecr_kg + "</td>");
                    htmlTable.Append("<td>" + kayit.Femn + "</td>");
                    htmlTable.Append("<td>" + kayit.Femn_kg + "</td>");
                    htmlTable.Append("<td>" + kayit.Femnhcr + "</td>");
                    htmlTable.Append("<td>" + kayit.Femnhcr_kg + "</td>");
                    htmlTable.Append("<td>" + kayit.Femnlowc + "</td>");
                    htmlTable.Append("<td>" + kayit.Femnlowc_kg + "</td>");
                    htmlTable.Append("<td>" + kayit.Fesilowal + "</td>");
                    htmlTable.Append("<td>" + kayit.Fesilowal_kg + "</td>");
                    htmlTable.Append("<td>" + kayit.Fesimn6030 + "</td>");
                    htmlTable.Append("<td>" + kayit.Fesimn6030_kg + "</td>");
                    htmlTable.Append("<td>" + kayit.Feti + "</td>");
                    htmlTable.Append("<td>" + kayit.Feti_kg + "</td>");
                    htmlTable.Append("<td>" + kayit.Fev + "</td>");
                    htmlTable.Append("<td>" + kayit.Fev_kg + "</td>");
                    htmlTable.Append("<td>" + kayit.Kolamanit + "</td>");
                    htmlTable.Append("<td>" + kayit.Kolamanit_kg + "</td>");
                    htmlTable.Append("<td>" + kayit.Mgo + "</td>");
                    htmlTable.Append("<td>" + kayit.Mgo_kg + "</td>");
                    htmlTable.Append("<td>" + kayit.Siliskumu + "</td>");
                    htmlTable.Append("<td>" + kayit.Siliskumu_kg + "</td>");
                    htmlTable.Append("</tr>");

                }
            }
            ph_aylik_alyaj_takip.Controls.Clear();
            ph_aylik_alyaj_takip.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }


        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../../Default2.aspx");
        }
    }
}