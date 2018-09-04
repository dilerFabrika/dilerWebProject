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
   
    public partial class Durus_raporu : System.Web.UI.Page
    {

        Durus_raporu_db db = new Durus_raporu_db();
        List<durus_bilgileri> kayitlar = new List<durus_bilgileri>();
        List<durus_bilgileri> kayitlarx = new List<durus_bilgileri>();
        List<durus_bilgileri> kayitlary = new List<durus_bilgileri>();
        List<durus_bilgileri> kayitlarz = new List<durus_bilgileri>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DateTime dt = new DateTime();
                dt = DateTime.Now;
                string tarih = dt.ToString("yyyy-MM-dd");//textboxdaki bicimi;
                string tarih2 = dt.ToString("yyyy-MM-dd");//textboxdaki bicimi;
                tx_rapor_tarihi.Text = tarih;
                tx_rapor_tarihi2.Text = tarih2;

                raporlari_getir(tarih.Replace("-", ""), tarih2.Replace("-", ""));
            }
        }

        [System.Web.Services.WebMethod]
        public static string detay(string arizakodu, object tarih, object tarih2)
        {

            Durus_raporu_db db = new Durus_raporu_db();
            string tarihh = Convert.ToString(tarih).Replace("-", "");//veritabanindaki kayit bicimi
            string tarihh2 = Convert.ToString(tarih2).Replace("-", "");//veritabanindaki kayit bicimi
            List<durus_bilgileri> kayit_detay = new List<durus_bilgileri>();
            db.Connect();
            string kayit = db.detay(arizakodu, tarihh, tarihh2);
            db.Disconnect();
            return kayit;

        }
        private void rapor_tarihi_al()
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

            if (tarih != "" && tarih2 != "")
            {
                db.Connect();
                int tarih_bas = Convert.ToInt32(tarih);
                int tarih2_bts = Convert.ToInt32(tarih2);
                string durus_nedeni = fillname.Text;
                kayitlar = db.durus_ozet_data_read(tarih_bas, tarih2_bts);
                kayitlary = db.durus_ayrinti_data_read(tarih_bas, tarih2_bts);
                kayitlarx = db.dokum_bazinda_durus_ozet_read(tarih_bas, tarih2_bts, durus_nedeni);
                kayitlarz = db.ariza_bazinda_toplamsure_read(tarih_bas, tarih2_bts, durus_nedeni);
                db.Disconnect();
                durus_nedenine_gore_listele();
                durus_ayrintilarini_listele();
                dokum_bazinda_listele();
                ariza_bazinda_toplamsure_listele();


            }
        }

        private void durus_ayrintilarini_listele()
        {
            StringBuilder htmlTable = new StringBuilder();
            if (kayitlary[0].DURUS_ID == "0")
            {
                // Kayit Bululnamadı
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan=\"17\">" + kayitlary[0].ARIZANEDEN + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var kayit in kayitlary)
                {
                    if (kayit.DURUS_ID != "2")
                    {
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td  style=\"font-weight: bold; color:#890d62;\"> " + kayit.dokumno + "</td>");
                        htmlTable.Append("<td> " + kayit.vrd + "</td>");
                        htmlTable.Append("<td> " + kayit.tarih + "</td>");
                        htmlTable.Append("<td> " + kayit.BASSAATI + "</td>");
                        htmlTable.Append("<td> " + kayit.BITISSAATI + "</td>");
                        htmlTable.Append("<td> " + kayit.SURE + "</td>");
                        htmlTable.Append("<td>" + kayit.DURUSNEDEN + "</td>");
                        htmlTable.Append("<td> " + kayit.DURUSKOD + "</td>");
                        htmlTable.Append("<td> " + kayit.ARIZANEDEN + "</td>");
                        htmlTable.Append("<td> " + kayit.ARIZAKOD + "</td>");
                        htmlTable.Append("<td> " + kayit.SARJALMA + "</td>");
                        htmlTable.Append("<td> " + kayit.aciklama + "</td>");
                        htmlTable.Append("</tr>");
                    }
                    else
                    {
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td> " + kayit.dokumno + "</td>");
                        htmlTable.Append("<td> " + kayit.vrd + "</td>");
                        htmlTable.Append("<td> " + kayit.tarih + "</td>");
                        htmlTable.Append("<td> " + kayit.BASSAATI + "</td>");
                        htmlTable.Append("<td> " + kayit.BITISSAATI + "</td>");
                        htmlTable.Append("<td> " + kayit.SURE + "</td>");
                        htmlTable.Append("<td>" + kayit.DURUSNEDEN + "</td>");
                        htmlTable.Append("<td> " + kayit.DURUSKOD + "</td>");
                        htmlTable.Append("<td> " + kayit.ARIZANEDEN + "</td>");
                        htmlTable.Append("<td> " + kayit.ARIZAKOD + "</td>");
                        htmlTable.Append("<td> " + kayit.SARJALMA + "</td>");
                        htmlTable.Append("<td> " + kayit.aciklama + "</td>");
                        htmlTable.Append("</tr>");

                    }

                }
            }
            ph_durus_tablosu3.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }
        private void durus_nedenine_gore_listele()
        {
            StringBuilder htmlTable = new StringBuilder();
            if (kayitlar[0].DURUS_ID == "0")
            {
                // Kayit Bululnamadı
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan=\"11\">" + kayitlar[0].ARIZANEDEN + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var kayit in kayitlar)
                {

                    htmlTable.Append("<tr style=\"background-color:#e9e8e9\"></tr>");
                    htmlTable.Append("<td> " + kayit.DURUSNEDEN + "</td>");
                    htmlTable.Append("<td>" + kayit.SURE + "</td>");
                    htmlTable.Append("<td> " + kayit.ADET + "</td>");
                    htmlTable.Append("</tr>");

                }
            }
            ph_durus_tablosu.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }
        private void dokum_bazinda_listele()
        {
            StringBuilder htmlTable = new StringBuilder();
            if (kayitlarx[0].DURUS_ID == "0")
            {
                // Kayit Bululnamadı
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan=\"11\">" + kayitlarx[0].ARIZANEDEN + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var kayit in kayitlarx)
                {
                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td> " + kayit.tarih + "</td>");
                    htmlTable.Append("<td>" + kayit.vrd + "</td>");
                    htmlTable.Append("<td> " + kayit.dokumno + "</td>");
                    htmlTable.Append("<td> " + kayit.ARIZANEDEN + "</td>");
                    htmlTable.Append("<td>" + kayit.ARIZAKOD + "</td>");
                    htmlTable.Append("<td> " + kayit.SURE + "</td>");
                    htmlTable.Append("</tr>");
                }
            }
            ph_durus_tablosu2.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }
        private void ariza_bazinda_toplamsure_listele()
        {
            StringBuilder htmlTable = new StringBuilder();
            if (kayitlar[0].DURUS_ID == "0")
            {
                // Kayit Bulunamadı
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan=\"11\">" + kayitlar[0].ARIZANEDEN + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var kayit in kayitlarz)
                {

                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td> " + kayit.DURUSNEDEN + "</td>");
                    htmlTable.Append("<td> " + kayit.ARIZANEDEN + "</td>");
                    htmlTable.Append("<td> " + kayit.ARIZAKOD + "</td>");
                    htmlTable.Append("<td> " + kayit.dokumno + "</td>");
                    htmlTable.Append("<td>" + kayit.SURE + "</td>");

                    htmlTable.Append("</tr>");

                }
                ph_durus_tablosu4.Controls.Add(new Literal { Text = htmlTable.ToString() });
            }

        }

        protected void btn_Listele_Click(object sender, EventArgs e)
        {
            rapor_tarihi_al();


        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../../Default2.aspx");
        }

        protected void txt_arizakod_TextChanged(object sender, EventArgs e)
        {
            db.Connect();
            string durus_nedeni = fillname.Text;
            string tarih_bas = tx_rapor_tarihi.Text;//textboxdaki bicimi
            string tarih = tarih_bas.Replace("-", "");//veritabanindaki kayit bicimi
            string tarih_bitis = tx_rapor_tarihi2.Text;
            string tarih2 = tarih_bitis.Replace("-", "");
            if (tarih != "" && tarih2 != "")
            {
                int tarih_ = Convert.ToInt32(tarih);
                int tarih2_ = Convert.ToInt32(tarih2);

                kayitlarx = db.dokum_bazinda_durus_ozet_read(tarih_, tarih2_, durus_nedeni);

            }
            db.Disconnect();
            dokum_bazinda_listele();

        }

    }
}