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
    public partial class Kimyalab_genel_rapor : System.Web.UI.Page
    {
        Kimya_raporu_db db = new Kimya_raporu_db();
        List<Analizler> kayitlar = new List<Analizler>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DateTime dt = new DateTime();
                dt = DateTime.Now;
                string tarih = dt.ToString("yyyy-MM-dd");//textboxdaki bicimi;
                tx_rapor_tarihi.Text = tarih;

                raporlari_getir(tarih.Replace("-", ""));
            }
        }
        private void raporlari_getir(string tarih)
        {

            if (tarih != "")
            {
                db.Connect();
                int tarih2 = Convert.ToInt32(tarih);
                kimya_geneltakip_sol(tarih2);
                kimya_geneltakip_sag(tarih2);
                kimya_geneltakip_ozet(tarih2);
                kimya_analiz_ortalama_listesi(tarih2);
                db.Disconnect();
            }
        }
        private void rapor_tarihi_al()
        {
            string tarih2 = tx_rapor_tarihi.Text;//textboxdaki bicimi
            string tarih = tarih2.Replace("-", "");//veritabanindaki kayit bicimi
            tx_rapor_tarihi.Text = tarih2;

            raporlari_getir(tarih);
        }
        protected void tx_rapor_tarihi_TextChanged(object sender, EventArgs e)
        {
            rapor_tarihi_al();
        }
        private void kimya_geneltakip_sol(int tarih2)
        {
            StringBuilder htmlTable = new StringBuilder();
            kayitlar = db.kimya_geneltakip_sol_data_read(tarih2);
            if (kayitlar[0].Analiz_id == 0)
            {
                // Kayit Bululnamadı
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan=\"24\">" + kayitlar[0].B + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {

                foreach (var kayit in kayitlar)
                {
                    if (kayit.Analiz_id == 1)
                    {

                        htmlTable.Append("<tr>");
                    
                        htmlTable.Append("<td style=\"text-align:center;\">" + kayit.Dokum_no + "</td>");
                        htmlTable.Append("<td style=\"text-align:center;\">" + kayit.Celik_cinsi + "</td>");
                        htmlTable.Append("<td>" + kayit.C + "</td>");
                        htmlTable.Append("<td>" + kayit.Si + "</td>");
                        htmlTable.Append("<td>" + kayit.S + "</td>");
                        htmlTable.Append("<td>" + kayit.P + "</td>");
                        htmlTable.Append("<td>" + kayit.Mn + "</td>");
                        htmlTable.Append("<td>" + kayit.Ni + "</td>");
                        htmlTable.Append("<td>" + kayit.Cr + "</td>");
                        htmlTable.Append("<td>" + kayit.Cu + "</td>");
                        htmlTable.Append("<td>" + kayit.Mo + "</td>");
                        htmlTable.Append("<td>" + kayit.Sn + "</td>");
                        htmlTable.Append("<td>" + kayit.V + "</td>");
                        htmlTable.Append("<td>" + kayit.N + "</td>");
                        htmlTable.Append("<td>" + kayit.Ceg + "</td>");
                        htmlTable.Append("<td>" + kayit.B + "</td>");
                        htmlTable.Append("<td>" + kayit.Ca + "</td>");
                        htmlTable.Append("<td>" + kayit.Ti + "</td>");
                        htmlTable.Append("<td>" + kayit.Al + "</td>");
                        htmlTable.Append("<td>" + kayit.Pb + "</td>");
                        htmlTable.Append("<td>" + kayit.Nb + "</td>");

                        htmlTable.Append("</tr>");

                    }

                    if (kayit.Analiz_id == 2)
                    {
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td style=\"color: #e602f3; font-weight: bold; text-align:center;\">" + kayit.Dokum_no + "</td>");
                        htmlTable.Append("<td style=\"color: #e602f3; font-weight: bold; text-align:center;\">" + kayit.Celik_cinsi + "</td>");
                        htmlTable.Append("<td style=\"color: #e602f3; font-weight: bold;\">" + kayit.C + "</td>");
                        htmlTable.Append("<td style=\"color: #e602f3; font-weight: bold;\">" + kayit.Si + "</td>");
                        htmlTable.Append("<td style=\"color: #e602f3; font-weight: bold;\">" + kayit.S + "</td>");
                        htmlTable.Append("<td style=\"color: #e602f3; font-weight: bold;\">" + kayit.P + "</td>");
                        htmlTable.Append("<td style=\"color: #e602f3; font-weight: bold;\">" + kayit.Mn + "</td>");
                        htmlTable.Append("<td style=\"color: #e602f3; font-weight: bold;\">" + kayit.Ni + "</td>");
                        htmlTable.Append("<td style=\"color: #e602f3; font-weight: bold;\">" + kayit.Cr + "</td>");
                        htmlTable.Append("<td style=\"color: #e602f3; font-weight: bold;\">" + kayit.Cu + "</td>");
                        htmlTable.Append("<td style=\"color: #e602f3; font-weight: bold;\">" + kayit.Mo + "</td>");
                        htmlTable.Append("<td style=\"color: #e602f3; font-weight: bold;\">" + kayit.Sn + "</td>");
                        htmlTable.Append("<td style=\"color: #e602f3; font-weight: bold;\">" + kayit.V + "</td>");
                        htmlTable.Append("<td style=\"color: #e602f3; font-weight: bold;\">" + kayit.N + "</td>");
                        htmlTable.Append("<td style=\"color: #e602f3; font-weight: bold;\">" + kayit.Ceg + "</td>");
                        htmlTable.Append("<td style=\"color: #e602f3; font-weight: bold;\">" + kayit.B + "</td>");
                        htmlTable.Append("<td style=\"color: #e602f3; font-weight: bold;\">" + kayit.Ca + "</td>");
                        htmlTable.Append("<td style=\"color: #e602f3; font-weight: bold;\">" + kayit.Ti + "</td>");
                        htmlTable.Append("<td style=\"color: #e602f3; font-weight: bold;\">" + kayit.Al + "</td>");
                        htmlTable.Append("<td style=\"color: #e602f3; font-weight: bold;\">" + kayit.Pb + "</td>");
                        htmlTable.Append("<td style=\"color: #e602f3; font-weight: bold;\">" + kayit.Nb + "</td>");

                        htmlTable.Append("</tr>");
                    }
                }
            }
            ph_kimya_listesi.Controls.Clear();
            ph_kimya_listesi.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }
        private void kimya_geneltakip_sag(int tarih2)
        {
            StringBuilder htmlTable = new StringBuilder();
            kayitlar = db.kimya_geneltakip_sag_data_read(tarih2);
            if (kayitlar[0].Analiz_id == 0)
            {
                // Kayit Bululnamadı
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan=\"14\">" + kayitlar[0].Aciklama + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {

                foreach (var kayit in kayitlar)
                {
                    if (kayit.Uretimdensapma_element != "")
                    {
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td style=\"color: #e602f3; font-weight: bold;\">" + kayit.Dokum_no + "</td>");
                        htmlTable.Append("<td style=\"color: #e602f3; font-weight: bold;\">" + kayit.Celik_cinsi + "</td>");
                        htmlTable.Append("<td style=\" color: #e602f3; font-weight: bold;\">" + kayit.Sirano + "</td>");
                        htmlTable.Append("<td style=\"color: #e602f3; font-weight: bold;\">" + kayit.Vardiya + "</td>");
                        htmlTable.Append("<td style=\" color: #e602f3;font-weight: bold;\">" + kayit.Tandis_no_bindirme_sayisi + "</td>");
                        htmlTable.Append("<td style=\" color: #e602f3;font-weight: bold;\">" + kayit.KS1 + "</td>");
                        htmlTable.Append("<td style=\" color: #e602f3;font-weight: bold;\">" + kayit.KS2 + "</td>");
                        htmlTable.Append("<td style=\" color: #e602f3;font-weight: bold;\">" + kayit.Ebat + "</td>");
                        htmlTable.Append("<td style=\" color: #e602f3;font-weight: bold;\">" + kayit.Boy + "</td>");
                        htmlTable.Append("<td style=\" color: #e602f3;font-weight: bold;\">" + kayit.Radyasyon + "</td>");
                        htmlTable.Append("<td style=\" color: #e602f3;font-weight: bold;\">" + kayit.Uretimdensapma_element + "</td>");
                        htmlTable.Append("<td style=\"color: #e602f3;font-weight: bold;\">" + kayit.Standart_disi_element + "</td>");
                        htmlTable.Append("<td style=\"color: #e602f3; font-weight: bold;\">" + kayit.Siparis_no + "</td>");
                        htmlTable.Append("<td style=\" color: #e602f3;font-weight: bold; text-align:left;\">" + kayit.Aciklama + "</td>");
                        htmlTable.Append("</tr>");
                    }
                    if (kayit.Uretimdensapma_element == "")
                    {

                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td>" + kayit.Dokum_no + "</td>");
                        htmlTable.Append("<td>" + kayit.Celik_cinsi + "</td>");
                        htmlTable.Append("<td>" + kayit.Sirano + "</td>");
                        htmlTable.Append("<td>" + kayit.Vardiya + "</td>");
                        htmlTable.Append("<td>" + kayit.Tandis_no_bindirme_sayisi + "</td>");
                        htmlTable.Append("<td>" + kayit.KS1 + "</td>");
                        htmlTable.Append("<td>" + kayit.KS2 + "</td>");
                        htmlTable.Append("<td>" + kayit.Ebat + "</td>");
                        htmlTable.Append("<td>" + kayit.Boy + "</td>");
                        htmlTable.Append("<td>" + kayit.Radyasyon + "</td>");
                        htmlTable.Append("<td>" + kayit.Uretimdensapma_element + "</td>");
                        htmlTable.Append("<td>" + kayit.Standart_disi_element + "</td>");
                        htmlTable.Append("<td>" + kayit.Siparis_no + "</td>");
                        htmlTable.Append("<td style=\"text-align:left;\">" + kayit.Aciklama + "</td>");
                        htmlTable.Append("</tr>");
                    }
                }
            }
            ph_kimya_listesi2.Controls.Clear();
            ph_kimya_listesi2.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }
        private void kimya_geneltakip_ozet(int tarih2)
        {
            StringBuilder htmlTable = new StringBuilder();
            kayitlar = db.kimya_geneltakip_ozet_data_read(tarih2);
            if (kayitlar[0].Analiz_id == 0)
            {
                // Kayit Bulunamadı
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan=\"6\">" + kayitlar[0].B + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {

                foreach (var kayit in kayitlar)
                {
                    if (kayit.Celik_cinsi != "")
                    {
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER;\"> " + kayit.Celik_cinsi + "</td>");
                        htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER;\">" + kayit.Ebat + "</td>");
                        htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER;\">" + kayit.Boy + "</td>");
                        htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER;\">" + kayit.Kutuk_sayisi + "</td>");
                        htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER; \">" + kayit.Tonaj.ToString().Replace(",", ".") + "</td>");
                        htmlTable.Append("</tr>");
                    }
                }
            }
            ph_kimya_listesi3.Controls.Clear();
            ph_kimya_listesi3.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }
        private void kimya_analiz_ortalama_listesi(int tarih2)
        {
            StringBuilder htmlTable = new StringBuilder();
            kayitlar = db.kimya_analiz_ortalama_listesi_data_read(tarih2);
            if (kayitlar[0].Analiz_id == 0)
            {
                // Kayit Bulunamadı
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan=\"9\">" + kayitlar[0].Aciklama + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {

                foreach (var kayit in kayitlar)
                {
                    if (kayit.Celik_cinsi != "")
                    {
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER;\"> " + kayit.Celik_cinsi.Replace(",", ".") + "</td>");
                        htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER;\">" + kayit.C.Replace(",", ".") + "</td>");
                        htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER;\">" + kayit.Si.Replace(",", ".") + "</td>");
                        htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER;\">" + kayit.Mn.Replace(",", ".") + "</td>");
                        htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER; \">" + kayit.V.Replace(",", ".") + "</td>");
                        htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER; \">" + kayit.Nb.Replace(",", ".") + "</td>");
                        htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER; \">" + kayit.Ca.Replace(",", ".") + "</td>");
                        htmlTable.Append("</tr>");
                    }
                }
            }
            ph_kimya_listesi4.Controls.Clear();
            ph_kimya_listesi4.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../../Default2.aspx");
        }

    }
}