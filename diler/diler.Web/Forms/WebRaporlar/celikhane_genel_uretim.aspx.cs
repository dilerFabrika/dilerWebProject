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
    public partial class celikhane_genel_uretim : System.Web.UI.Page
    {

        Kimya_raporu_db db = new Kimya_raporu_db();
        List<Analizler> kayitlar = new List<Analizler>();
        List<Analizler> kayitlart = new List<Analizler>();
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

        private void raporlari_getir(string tarih, string tarih2)
        {
            StringBuilder htmlTable = new StringBuilder();
            if (tarih != "" && tarih2 != "")
            {
                db.Connect();
                int tarih_bas = Convert.ToInt32(tarih);
                int tarih2_bts = Convert.ToInt32(tarih2);
                kayitlar = db.uretim_ozet_read(tarih_bas, tarih2_bts);
                kayitlart = db.toplam_uretim(tarih_bas, tarih2_bts);
                db.Disconnect();
                uretim_ozet_bas();
                toplam_uretim();
            }
        }

        private void uretim_ozet_bas()
        {

            StringBuilder htmlTable = new StringBuilder();

            if (kayitlar[0].Analiz_id == 0)
            {
                // Kayit Bulunamadi
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan='8'>" + kayitlar[0].Aciklama + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var kayit in kayitlar)
                {
                    if (kayit.Celik_cinsi != "")
                    {
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td>" + kayit.Celik_cinsi + "</td>");
                        htmlTable.Append("<td>" + kayit.Ebat + "</td>");
                        htmlTable.Append("<td>" + kayit.Boy + "</td>");
                        htmlTable.Append("<td>" + kayit.Kutuk_sayisi + "</td>");
                        htmlTable.Append("<td>" + kayit.Dokum_sayisi + "</td>");
                        htmlTable.Append("<td>" + kayit.Tonaj.Replace(",", ".") + "</td>");
                        htmlTable.Append("</tr>");
                    }
                }
            }
            ph_uretim_ozet.Controls.Clear();
            ph_uretim_ozet.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }
        private void toplam_uretim()
        {

            StringBuilder htmlTable = new StringBuilder();

            if (kayitlart[0].Analiz_id == 0)
            {
                // Kayit Bulunamadi
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan='5'>" + kayitlart[0].Aciklama + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var kayit in kayitlart)
                {
                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td style=\"color: #e602f3; font-weight: bold;\">" + kayit.Dokum_sayisi + " </td>");
                    htmlTable.Append("<td style=\"color: #e602f3; font-weight: bold;\">" + kayit.Kutuk_sayisi + " </td>");
                    htmlTable.Append("<td style=\"color: #e602f3; font-weight: bold;\">" + kayit.Tonaj.Replace(",", ".") + "</td>");
                    htmlTable.Append("</tr>");
                }
            }
            ph_toplam_uretim.Controls.Clear();
            ph_toplam_uretim.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }

        protected void btn_Listele_Click(object sender, EventArgs e)
        {
            string tarih_bas = tx_rapor_tarihi.Text;//textboxdaki bicimi
            string tarih = tarih_bas.Replace("-", "");//veritabanindaki kayit bicimi
            string tarih_bitis = tx_rapor_tarihi2.Text;
            string tarih2 = tarih_bitis.Replace("-", "");

            tx_rapor_tarihi.Text = tarih_bas;
            tx_rapor_tarihi2.Text = tarih_bitis;

            raporlari_getir(tarih, tarih2);
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../../Default2.aspx");
        }
    }
}