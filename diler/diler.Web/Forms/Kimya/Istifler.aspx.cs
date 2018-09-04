using diler.Dal;
using diler.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace diler.Web.Forms.Kimya
{
    public partial class Istifler : System.Web.UI.Page
    {

        Istiften_soguksarj_db db = new Istiften_soguksarj_db();
        List<Istif_bilgileri> kayitlar = new List<Istif_bilgileri>();
        List<Istif_bilgileri> kayitlar_istif_Ozet = new List<Istif_bilgileri>();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {

            }
        }


        private void istif_takip_Ozet_listele(string stok_yeri, string istif_yeri)
        {

            StringBuilder htmlTable = new StringBuilder();
            kayitlar_istif_Ozet = db.istif_takip_ozet_listele_data_read(stok_yeri, istif_yeri);
            if (kayitlar_istif_Ozet[0].Id == 0)
            {
                // Kayit Bulunamadı
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan=\"11\">" + kayitlar_istif_Ozet[0].Lot + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {

                foreach (var kayit in kayitlar_istif_Ozet)
                {

                    htmlTable.Append("<tr class='istif_tablosu'>");
                    htmlTable.Append("<td style=\"text-align:center; padding: 10px;\">" + kayit.Istif_yeri + "</td>");
                    htmlTable.Append("<td style=\"text-align:center; padding: 10px;\">" + kayit.Istif_adet + "</td>");
                    htmlTable.Append("<td style=\"text-align:center; padding: 10px;\"> " + kayit.Ebat + "</td>");
                    htmlTable.Append("<td style=\"text-align:center; padding: 10px;\">" + kayit.Celik_cinsi + "</td>");
                    htmlTable.Append("<td style=\"text-align:center; padding: 10px;\"> " + kayit.Boy + "</td>");
                    htmlTable.Append("</tr>");

                }
            }




            ph_istif_Ozethh1.Controls.Clear();
            ph_istif_Ozethh1.Controls.Add(new Literal { Text = htmlTable.ToString() });

            ph_istif_Ozethh2.Controls.Clear();
            ph_istif_Ozethh2.Controls.Add(new Literal { Text = htmlTable.ToString() });

            ph_istif_Ozetcubuk.Controls.Clear();
            ph_istif_Ozetcubuk.Controls.Add(new Literal { Text = htmlTable.ToString() });

            ph_istif_Ozetch.Controls.Clear();
            ph_istif_Ozetch.Controls.Add(new Literal { Text = htmlTable.ToString() });


        }
        private void istif_takip_Listele(string stok_yeri, string istif_yeri)
        {
            StringBuilder htmlTable = new StringBuilder();
            kayitlar = db.istif_takip_listele_data_read(stok_yeri, istif_yeri);
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

                    htmlTable.Append("<tr class='istif_tablosu'>");
                    htmlTable.Append("<td  style=\"text-align:center; padding: 10px;\">" + kayit.Istif_sirano + " </td>");
                    htmlTable.Append("<td  style=\"text-align:center; padding: 10px;\">" + kayit.Dokum_tarihi + " </td>");
                    htmlTable.Append("<td  style=\"text-align:center; padding: 10px;\">" + kayit.Dokum_no + " </td>");
                    htmlTable.Append("<td  style=\"text-align:center; padding: 10px;\">" + kayit.Stok_yeri + " </td>");
                    htmlTable.Append("<td  style=\"text-align:center; padding: 10px;\">" + kayit.Istif_yeri + " </td>");
                    htmlTable.Append("<td  style=\"text-align:center; padding: 10px;\">" + kayit.Istif_adet + " </td>");
                    htmlTable.Append("<td  style=\"text-align:center; padding: 10px;\">" + kayit.Celik_cinsi + " </td>");
                    htmlTable.Append("<td  style=\"text-align:center; padding: 10px;\">" + kayit.Boy + " </td>");
                    htmlTable.Append("<td  style=\"text-align:center; padding: 10px;\">" + kayit.Ebat + " </td>");
                    htmlTable.Append("<td  style=\"text-align:center; padding: 10px;\">" + kayit.Sipno + " </td>");
                    htmlTable.Append("<td  style=\"text-align:center; padding: 10px;\">" + kayit.Lot + " </td>");
                    htmlTable.Append("<td  style=\"text-align:center; padding: 10px;\">" + kayit.Aciklama + " </td>");
                    htmlTable.Append("</tr>");

                }

            }

            ph_istif_takiphh1.Controls.Clear();
            ph_istif_takiphh1.Controls.Add(new Literal { Text = htmlTable.ToString() });


            ph_istif_takiphh2.Controls.Clear();
            ph_istif_takiphh2.Controls.Add(new Literal { Text = htmlTable.ToString() });

            ph_istif_takipcubuk.Controls.Clear();
            ph_istif_takipcubuk.Controls.Add(new Literal { Text = htmlTable.ToString() });

            ph_istif_takipch.Controls.Clear();
            ph_istif_takipch.Controls.Add(new Literal { Text = htmlTable.ToString() });




        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../../Default2.aspx");
        }



        protected void ASPxCallbackPanel_istif_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            if (e.Parameter == "istif_hh1")
            {
                db.Connect();
                string istif_yeri = txt_istif.Text.Replace("_", "").Trim();
                istif_takip_Listele("Haddehane", istif_yeri);
                istif_takip_Ozet_listele("Haddehane", istif_yeri);
                db.Disconnect();

            }

        }
        protected void ASPxCallbackPanel_istif2_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            if (e.Parameter == "istif_hh2")
            {
                db.Connect();
                string istif_yeri = txt_istif.Text.Replace("_", "").Trim();
                istif_takip_Listele("Haddehane", istif_yeri);
                istif_takip_Ozet_listele("Haddehane", istif_yeri);
                db.Disconnect();

            }
        }
        protected void ASPxCallbackPanel_cubukistif_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            if (e.Parameter == "istif_cubuk")
            {
                db.Connect();
                string istif_yeri = txt_istif.Text.Replace("_", "").Trim();
                istif_takip_Listele("Haddehane", istif_yeri);
                istif_takip_Ozet_listele("Haddehane", istif_yeri);
                db.Disconnect();

            }
        }
        protected void ASPxCallbackPanel_chistif_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            if (e.Parameter == "istif_ch")
            {
                db.Connect();
                string istif_yeri = txt_istif.Text.Replace("_", "").Trim();
                istif_takip_Listele("Çelikhane", istif_yeri);
                istif_takip_Ozet_listele("Çelikhane", istif_yeri);
                db.Disconnect();

            }
        }
    }
}
