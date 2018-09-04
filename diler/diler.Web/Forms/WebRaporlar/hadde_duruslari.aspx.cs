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

namespace diler.Web.Forms.WebRaporlar
{
    public partial class hadde_duruslari : System.Web.UI.Page
    {
        EndMuh_raporlar_db db = new EndMuh_raporlar_db();
        List<durus_bilgileri> kayitlar = new List<durus_bilgileri>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //DateTime dt = new DateTime();
                //dt = DateTime.Now;
                //string tarih = dt.ToString("yyyyMMdd");//veritabanindaki kayit bicimi

                //string tarih2 = dt.ToString("yyyy-MM-dd");//textboxdaki bicimi
                //tx_tarih_cubuk.Text = tarih2;
                //tx_tarih2_cubuk.Text = tarih2;
                //tx_tarih_telcubuk.Text = tarih2;
                //tx_tarih2_telcubuk.Text = tarih2;
                //cubuk_hadde_durus_listele(tarih, tarih);
                //telcubuk_hadde_durus_listele(tarih, tarih);
            }
        }

        private void cubuk_hadde_durus_listele(int tarih_cubuk, int tarih2_cubuk)
        {
            StringBuilder htmlTable = new StringBuilder();
            db.Connect();
            kayitlar = db.cubuk_haddehane_durus_data_read(tarih_cubuk, tarih2_cubuk);
            db.Disconnect();
            if (kayitlar[0].Id == 0)
            {
                // Kayit Bululnamadı
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan=\"11\">" + kayitlar[0].Cap + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {

                foreach (var kayit in kayitlar)
                {

                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td> " + kayit.tarih + "</td>");
                    htmlTable.Append("<td> " + kayit.vrd + "</td>");
                    htmlTable.Append("<td> " + kayit.Cap + "</td>");
                    htmlTable.Append("<td> " + kayit.DURUSNEDEN + "</td>");
                    htmlTable.Append("<td> " + kayit.ARIZANEDEN + "</td>");
                    htmlTable.Append("<td> " + kayit.BASSAATI + "</td>");
                    htmlTable.Append("<td> " + kayit.BITISSAATI + "</td>");
                    htmlTable.Append("<td> " + kayit.SURE.Replace(",", ".") + "</td>");
                    htmlTable.Append("</tr>");

                }
            }
            ph_cubuk_durus.Controls.Add(new Literal { Text = htmlTable.ToString() });

        }

        private void telcubuk_hadde_durus_listele(int tarih_telcubuk, int tarih2_telcubuk)
        {

            StringBuilder htmlTable = new StringBuilder();
            db.flm_connect();
            kayitlar = db.tel_cubuk_haddehane_durus_data_read(tarih_telcubuk, tarih2_telcubuk);
            db.flm_Disconnect();
            if (kayitlar[0].Id == 0)
            {
                // Kayit Bulunamadı
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan=\"11\">" + kayitlar[0].Cap + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {

                foreach (var kayit in kayitlar)
                {


                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td> " + kayit.tarih + "</td>");
                    htmlTable.Append("<td> " + kayit.vrd + "</td>");
                    htmlTable.Append("<td> " + kayit.Cap + "</td>");
                    htmlTable.Append("<td> " + kayit.DURUSNEDEN + "</td>");
                    htmlTable.Append("<td> " + kayit.ARIZANEDEN + "</td>");
                    htmlTable.Append("<td> " + kayit.BASSAATI + "</td>");
                    htmlTable.Append("<td> " + kayit.BITISSAATI + "</td>");
                    htmlTable.Append("<td> " + kayit.SURE.Replace(",", ".") + "</td>");
                    htmlTable.Append("</tr>");


                }
            }
            ph_telcubuk_durus.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }

        protected void btn_Listele_Click(object sender, EventArgs e)
        {
            rapor_tarihi_al();


        }
        private void rapor_tarihi_al()
        {
            string tarih_bas = tx_rapor_tarihi.Text;//textboxdaki bicimi
            string tarih = tarih_bas.Replace("-", "");//veritabanindaki kayit bicimi
            string tarih_bitis = tx_rapor_tarihi2.Text;
            string tarih2 = tarih_bitis.Replace("-", "");
            raporlari_getir(tarih, tarih2);
        }
        private void raporlari_getir(string tarih, string tarih2)
        {
            if (tarih != "" && tarih2 != "")
            {            
                int tarih_bas = Convert.ToInt32(tarih);
                int tarih2_bts = Convert.ToInt32(tarih2);
                cubuk_hadde_durus_listele(tarih_bas, tarih2_bts);
                telcubuk_hadde_durus_listele(tarih_bas, tarih2_bts);
             


            }
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../../Default2.aspx");
        }
    }
}