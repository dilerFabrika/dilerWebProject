using diler.Dal;
using diler.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace diler.Web.Forms.Kimya
{
    public partial class istif_yedekleri : System.Web.UI.Page
    {
        Istife_kutuk_gonderimi_db db = new Istife_kutuk_gonderimi_db();
        List<Istif_bilgileri> kayitlar = new List<Istif_bilgileri>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               cmb_yedek_tarihi_doldur();
            }
        }

        private void cmb_yedek_tarihi_doldur()
        {
            cmb_yedek_tarihi.Items.Clear();
           
            db.Connect();
            List<string> veriler = new List<string>();
            veriler = db.cmb_yedek_tarihi_doldur();
            foreach (var yedek_tarihi in veriler)
            {
               
                cmb_yedek_tarihi.Items.Add(yedek_tarihi);
            }
            db.Disconnect();
        }
        protected void Cmb_stok_yeri_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cmb_istif_yeri.Items.Clear();
            if (Cmb_stok_yeri.SelectedItem.ToString() != "Stok yeri seçiniz")
            {

                db.Connect();
                List<string> veriler = new List<string>();
                string secilen_stok_yeri = Cmb_stok_yeri.SelectedItem.ToString();
                string secilen_yedek_tarihi =  cmb_yedek_tarihi.SelectedItem.ToString();
                veriler = db.Cmb_istif_yeri_yedek_doldur(secilen_stok_yeri,secilen_yedek_tarihi);
                foreach (var istifyeri in veriler)
                {
                    Cmb_istif_yeri.Items.Add(istifyeri);
                }
                db.Disconnect();
            }

        }

        protected void btn_Listele_Click(object sender, EventArgs e)
        {
            if (Cmb_istif_yeri.Text != "")
            {
                string stok_yeri = Cmb_stok_yeri.SelectedItem.ToString();
                string istif_yeri = Cmb_istif_yeri.SelectedItem.ToString();
                string yedek_tarihi = cmb_yedek_tarihi.SelectedItem.ToString();

                string istifyeri = istif_yeri.Substring(0, 3).Replace("H", "").Replace("C", "").Trim();
                db.Connect();
                yedek_istifleri_Listele(stok_yeri, istifyeri, yedek_tarihi);


                db.Disconnect();

            }

        }
        private void yedek_istifleri_Listele(string stok_yeri, string istif_yeri, string yedek_tarihi)
        {
            StringBuilder htmlTable = new StringBuilder();
            kayitlar = db.yedek_istifleri_listele(stok_yeri, istif_yeri, yedek_tarihi);
            if (kayitlar[0].Id == 0)
            {
                // Kayit Bulunamadı
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan=\"13\">" + kayitlar[0].Lot + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {

                foreach (var kayit in kayitlar)
                {

                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td>" + kayit.Istif_sirano + "</td>");
                    htmlTable.Append("<td>" + kayit.Dokum_tarihi + "</td>");
                    htmlTable.Append("<td>" + kayit.Dokum_no + "</td>");
                    htmlTable.Append("<td>" + kayit.Stok_yeri + "</td>");
                    htmlTable.Append("<td>" + kayit.Istif_yeri + "</td>");
                    htmlTable.Append("<td>" + kayit.Istif_adet + "</td>");
                    htmlTable.Append("<td>" + kayit.Celik_cinsi + "</td>");
                    htmlTable.Append("<td>" + kayit.Boy + "</td>");
                    htmlTable.Append("<td>" + kayit.Ebat + "</td>");
                    htmlTable.Append("<td>" + kayit.Sipno + "</td>");
                    htmlTable.Append("<td>" + kayit.Lot + " </td>");
                    htmlTable.Append("<td>" + kayit.Aciklama + " </td>");
                    htmlTable.Append("</tr>");

                }

            }
            ph_istif_takip.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../../Default2.aspx");
        }

        protected void cmb_yedek_tarihi_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            Cmb_istif_yeri.Items.Clear();
            Cmb_stok_yeri.Text = "Stok yeri seçiniz";
        }
    }
}