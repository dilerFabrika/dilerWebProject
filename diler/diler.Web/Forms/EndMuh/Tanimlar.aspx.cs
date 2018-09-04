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

namespace diler.Web.Forms.EndMuh
{
    public partial class Tanimlar : System.Web.UI.Page
    {
        List<Tanim_bilgileri> kayitlar = new List<Tanim_bilgileri>();
        Tanim_db db = new Tanim_db();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                db.Connect();

                ddl_std_aciklama_fill();
                ddl_kalite_aciklama_fill();
                db.Disconnect();
                stdklt_tablosu_show();
            }
        }


        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [System.Web.Services.WebMethod]
        public static int yeni_tanim_ekle(string tesis, string tanim_tipi, string kod_ack, string as400_kod, string as400ambar_depo)
        {

            Tanim_db db = new Tanim_db();
            db.Connect();
            int tanim_tipi_kod = db.tanim_tipi_kod_bul(tesis, tanim_tipi);
            int tanim_Insert = db.tanim_ekle(tesis, tanim_tipi, tanim_tipi_kod, kod_ack, as400_kod, as400ambar_depo);
            if (tanim_Insert == 0)
            {
                return 0;
            }
            db.Disconnect();
            return 1;


        }


        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [System.Web.Services.WebMethod]
        public static List<string> tanimlari_listele(string tanim_tipi, string tesis)
        {
            Tanim_db db = new Tanim_db();
            List<Tanim_bilgileri> kayitlar = new List<Tanim_bilgileri>();
            List<string> tanimlar = new List<string>();

            db.Connect();
            kayitlar = db.tanimlari_listele_data_read(tesis, tanim_tipi);
            db.Disconnect();
            StringBuilder htmlTable = new StringBuilder();
            if (kayitlar[0].Id == 0)
            {
                // Kayit Bululnamadı
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan=\"11\">" + kayitlar[0].Tanim_tipi + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {

                foreach (var kayit in kayitlar)
                {
                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td  style=\"text-align:center\">" + kayit.Tesis + "</td>");
                    htmlTable.Append("<td  style=\"text-align:center\"> " + kayit.Tanim_tipi + "</td>");
                    htmlTable.Append("<td  style=\"text-align:center\"> " + kayit.Kod + "</td>");
                    htmlTable.Append("<td  style=\"text-align:center\"> " + kayit.Kod_ack + "</td>");
                    htmlTable.Append("<td  style=\"text-align:center\">" + kayit.Ekransirano + "</td>");
                    htmlTable.Append("<td style=\"text-align:center\"></td>");
                    htmlTable.Append("<td  style=\"text-align:center\"> " + kayit.As400kod + "</td>");
                    htmlTable.Append("<td  style=\"text-align:center\"> " + kayit.As400_ambardepo + "</td>");

                    htmlTable.Append("</tr>");

                }
            }



            tanimlar.Add(htmlTable.ToString());
            return tanimlar;
        }

        private void stdklt_tablosu_show()
        {
            StringBuilder htmlTable = new StringBuilder();
            string tesis = "HH";
            string tanim_tipi = "STDKLT";
            db.Connect();
            kayitlar = db.tanimlari_listele_data_read(tesis, tanim_tipi);
            db.Disconnect();
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
                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td  style=\"text-align:center\">" + kayit.Tesis + "</td>");
                    htmlTable.Append("<td  style=\"text-align:center\"> " + kayit.Tanim_tipi + "</td>");
                    htmlTable.Append("<td  style=\"text-align:center\"> " + kayit.Kod + "</td>");
                    htmlTable.Append("<td  style=\"text-align:center\"> " + kayit.Kod_ack + "</td>");

                    htmlTable.Append("<td style=\"text-align:center\">" + kayit.prg1 + "</td>");
                    htmlTable.Append("<td  style=\"text-align:center\">" + kayit.prg2 + " </td>");

                    htmlTable.Append("</tr>");

                }
            }
            ph_stdklt_tablosu.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }

        private void ddl_std_aciklama_fill()
        {
            ddl_std_aciklama.Items.Clear();
            List<Tanim_bilgileri> kayitlar = new List<Tanim_bilgileri>();
            kayitlar = db.standart_ozellikleri();
            foreach (var kayit in kayitlar)
            {
                ddl_std_aciklama.Items.Add(kayit.prg1); //standart açıklama

            }



        }
        private void ddl_kalite_aciklama_fill()
        {
            ddl_kalite_aciklama.Items.Clear();
            List<Tanim_bilgileri> kayitlar = new List<Tanim_bilgileri>();
            kayitlar = db.kalite_ozellikleri();
            foreach (var kayit in kayitlar)
            {
                ddl_kalite_aciklama.Items.Add(kayit.prg2); //kalite açıklama

            }



        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {

            string kalite_aciklamasi = ddl_kalite_aciklama.SelectedItem.ToString();
            string std_aciklamasi = ddl_std_aciklama.SelectedItem.ToString();
            string tesis = tx_tesis.Text;
            string tanim_tipi = tx_tanim_tipi.Text;
            db.Connect();
            string mesaj = db.std_kalite_Insert(tesis, tanim_tipi, kalite_aciklamasi, std_aciklamasi);
            db.Disconnect();
            Response.Write("<script language='javascript'>alert('" + mesaj + "');</script>");
            stdklt_tablosu_show();



        }


        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../../Default2.aspx");
        }

    }
}