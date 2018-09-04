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
    public partial class Anastok_takip : System.Web.UI.Page
    {
        dynamic kullanici;
        Izlenebilirlik_db db = new Izlenebilirlik_db();
        List<Izlenebilirlik_bilgileri> kayitlar = new List<Izlenebilirlik_bilgileri>();
        List<Izlenebilirlik_bilgileri> kayitlar_anastok = new List<Izlenebilirlik_bilgileri>();
        List<Izlenebilirlik_bilgileri> kayitlar_tum_ebat_stogu = new List<Izlenebilirlik_bilgileri>();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                kullanici = Session["KULLANICI"];
                db.Connect();
                istif_ebat_doldur();
                kayitlar_tum_ebat_stogu = db.tum_ebatlarin_stok_takibi();
                tum_ebatlarin_stok_takibi();
                db.Disconnect();


           }

        }

        private void istif_ebat_doldur()
        {
            Cmb_ebat.Items.Clear();

            List<string> veriler = new List<string>();
            veriler = db.Cmb_ebat_doldur();
            foreach (var ebat in veriler)
            {
                Cmb_ebat.Items.Add(ebat);
            }

        }

        protected void btn_Listele_Click(object sender, EventArgs e)
        {
            string ebat = Cmb_ebat.SelectedItem.ToString();
            ana_stok_Listele(ebat);


        }

        private void ana_stok_Listele(string ebat)
        {
            db.Connect();
            kayitlar = db.ana_stok_listele_data_read(ebat);
            kayitlar_tum_ebat_stogu = db.tum_ebatlarin_stok_takibi();
            db.Disconnect();
            ana_stok_takip_listele();
            tum_ebatlarin_stok_takibi();

        }
        private void ana_stok_takip_listele()
        {

            StringBuilder htmlTable = new StringBuilder();

            if (kayitlar[0].Id == 0)
            {
                // Kayit Bululnamadı
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan=\"11\">" + kayitlar[0].Id + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {

                foreach (var kayit in kayitlar)
                {

                    htmlTable.Append("<tr style=\"background-color:#e9e8e9\"></tr>");
                    htmlTable.Append("<td  style=\"text-align:center\"> " + kayit.Ebat + "</td>");
                    htmlTable.Append("<td style=\"text-align:center\">" + kayit.Celik_cinsi + "</td>");
                    htmlTable.Append("<td  style=\"text-align:center\"> " + kayit.Boy + "</td>");
                    htmlTable.Append("<td  style=\"text-align:center\">" + kayit.Istif_adet + "</td>");
                    htmlTable.Append("<td  style=\"text-align:center\" class='tonaj';\">" + kayit.Kutuk_tonaji.ToString("0.###").Replace(",", ".") + " </td>");
                    htmlTable.Append("<td  style=\"text-align:center\"> " + kayit.Celik_cinsi_orj + " </td>");
                    htmlTable.Append("</tr>");

                }
            }
            ph_ana_stok_takip.Controls.Add(new Literal { Text = htmlTable.ToString() });

        }


        private void tum_ebatlarin_stok_takibi()
        {
            StringBuilder htmlTable = new StringBuilder();
            
            if (kayitlar_tum_ebat_stogu[0].Id == 0)
            {
                // Kayit Bululnamadı
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan=\"11\">" + kayitlar_tum_ebat_stogu[0].Id + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {

                foreach (var kayit in kayitlar_tum_ebat_stogu)
                {

                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td  style=\"text-align:center\"> " + kayit.Ebat + "</td>");
                    htmlTable.Append("<td style=\"text-align:center\">" + kayit.Celik_cinsi + "</td>");
                    htmlTable.Append("<td  style=\"text-align:center\"> " + kayit.Boy + "</td>");
                    htmlTable.Append("<td  style=\"text-align:center\">" + kayit.Istif_adet + "</td>");
                    htmlTable.Append("<td  style=\"text-align:center\" class='tonaj';\">" + kayit.Kutuk_tonaji.ToString("0.###").Replace(",", ".") + " </td>");

                    htmlTable.Append("</tr>");

                }

            }
            ph_celikcinsi_bazinda.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }
        protected void fillname_TextChanged(object sender, EventArgs e)
        {

            db.Connect();
            string celik_cinsi = fillname.Text;
            kayitlar_anastok = db.Celik_cinsine_gore_Stok_takip(celik_cinsi);
            db.Disconnect();
            Celik_cinsine_gore_Stok_takip_listele();


        }

        private void Celik_cinsine_gore_Stok_takip_listele()
        {
            StringBuilder htmlTable = new StringBuilder();
            if (kayitlar_anastok[0].Id == 0)
            {
                // Kayit Bululnamadı
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan=\"11\">" + kayitlar_anastok[0].Id + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var kayit in kayitlar_anastok)
                {

                    htmlTable.Append("<tr style=\"background-color:#e9e8e9\"></tr>");
                    htmlTable.Append("<td  style=\"text-align:center\"> " + kayit.Stok_yeri + "</td>");
                    htmlTable.Append("<td style=\"text-align:center\">" + kayit.Dokum_no + "</td>");
                    htmlTable.Append("<td style=\"text-align:center\">" + kayit.Celik_cinsi + "</td>");
                    htmlTable.Append("<td  style=\"text-align:center\"> " + kayit.Istif_yeri + "</td>");
                    htmlTable.Append("<td  style=\"text-align:center\">" + kayit.Istif_adet + "</td>");
                    htmlTable.Append("</tr>");

                }
            }
            ph_ana_stok_takip_Ozet.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            kullanici = Session["KULLANICI"];
            Response.Redirect("../../Default2.aspx");
        }

    }
}