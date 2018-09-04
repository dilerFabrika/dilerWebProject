using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.ComponentModel;
using System.Text;
using diler.Dal;
using diler.Entity;
namespace diler.Web
{
    public partial class FizikInstron : System.Web.UI.Page
    {
        Fizik_Instron_db db = new Fizik_Instron_db();
        List<Rm_veriler> kayitlar = new List<Rm_veriler>();
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private void rm_verileri_ekrana_bas()
        {
            StringBuilder htmlTable = new StringBuilder();

            if (kayitlar[0].Id == 0)
            {
                // Kayit Bulunamadi
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan='15'>" + kayitlar[0].Testi_yapan + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var kayit in kayitlar)
                {

                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td>" + kayit.Tarih + "</td>");
                    htmlTable.Append("<td>" + kayit.Siparis_numarasi + "</td>");
                    htmlTable.Append("<td>" + kayit.Dokum_numarasi + "</td>");
                    htmlTable.Append("<td>" + kayit.Testi_yapan + "</td>");
                    htmlTable.Append("<td>" + kayit.Cap + "</td>");
                    htmlTable.Append("<td>" + kayit.Nervur_yuksekligi + "</td>");
                    htmlTable.Append("<td>" + kayit.Nervur_yuksekligi_1_4 + "</td>");
                    htmlTable.Append("<td>" + kayit.Nervur_yuksekligi_3_4 + "</td>");
                    htmlTable.Append("<td>" + kayit.Cs_mesafesi + "</td>");
                    htmlTable.Append("<td>" + kayit.Toplam_e_mesafesi + "</td>");
                    htmlTable.Append("<td>" + kayit.Nervur_uzunlugu + "</td>");
                    htmlTable.Append("<td>" + kayit.Nervur_genisligi + "</td>");
                    htmlTable.Append("<td>" + kayit.Beta_acisi + "</td>");
                    htmlTable.Append("<td>" + kayit.Alfa_acisi + "</td>");
                    htmlTable.Append("<td>" + kayit.Fr + "</td>");
                    htmlTable.Append("</tr>");
                }
            }
            ph_rm_veriler.Controls.Clear();
            ph_rm_veriler.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }

        protected void tx_rapor_tarihi_TextChanged(object sender, EventArgs e)
        {
            string tarih_s = "";
            string tarih2_s = "";
            int tarih = 0;
            int tarih2 = 0;
            tarih_s = tx_rapor_tarihi.Text.Replace("-", "");
            tarih2_s = tx_rapor_tarihi2.Text.Replace("-", "");
            if (tarih_s.Length != 0 && tarih2_s.Length != 0)
            {
                tarih = Convert.ToInt32(tarih_s);
                tarih2 = Convert.ToInt32(tarih2_s);
                db.Connect();
                kayitlar = db.rm_veriler_data_read(0, tarih,tarih2);
                db.Disconnect();
                rm_verileri_ekrana_bas();
            }
        }

        protected void tx_dokum_no_TextChanged(object sender, EventArgs e)
        {
            int dokum_no = 0;
            if (tx_dokum_no.Text != "")
            { 
            dokum_no = Convert.ToInt32(tx_dokum_no.Text);
            db.Connect();
            kayitlar = db.rm_veriler_data_read(dokum_no);
            db.Disconnect();
            rm_verileri_ekrana_bas();
        }

        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../../Default2.aspx");
        }
    }
}