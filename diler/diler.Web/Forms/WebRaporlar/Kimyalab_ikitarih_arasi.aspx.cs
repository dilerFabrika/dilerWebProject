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
    public partial class Kimyalab_ikitarih_arasi : System.Web.UI.Page
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
                int baslangic_tarihi = Convert.ToInt32(tarih);
                int bitis_tarihi = Convert.ToInt32(tarih2);

                db.Connect();
                uretim_ozet_liste(baslangic_tarihi, bitis_tarihi);
                filmasin_ozet_liste(baslangic_tarihi, bitis_tarihi);
                ihracat_ozet_liste(baslangic_tarihi, bitis_tarihi);
                uretimden_sapma_ozet_liste(baslangic_tarihi, bitis_tarihi);
                stddisi_uretim_ozet(baslangic_tarihi, bitis_tarihi);
                toplam_uretim(baslangic_tarihi, bitis_tarihi);
                toplam_uretim_filmasin(baslangic_tarihi, bitis_tarihi);
                toplam_uretim_ihracat(baslangic_tarihi, bitis_tarihi);

                db.Disconnect();

            }
        }


        //
        private void toplam_uretim(int baslangic_tarihi, int bitis_tarihi)
        {

            StringBuilder htmlTable = new StringBuilder();
            kayitlar = db.toplam_uretim(baslangic_tarihi, bitis_tarihi);
            if (kayitlar[0].Analiz_id == 0)
            {
                // Kayit Bulunamadı
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan='5'>" + kayitlar[0].Aciklama + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var kayit in kayitlar)
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
        private void toplam_uretim_filmasin(int baslangic_tarihi, int bitis_tarihi)
        {

            StringBuilder htmlTable = new StringBuilder();
            kayitlar = db.toplam_uretim_filmasin(baslangic_tarihi, bitis_tarihi);
            if (kayitlar[0].Analiz_id == 0)
            {
                // Kayit Bulunamadi
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan='5'>" + kayitlar[0].Aciklama + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var kayit in kayitlar)
                {
                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td style=\"color: #e602f3; font-weight: bold;\">" + kayit.Dokum_sayisi + " </td>");
                    htmlTable.Append("<td style=\"color: #e602f3; font-weight: bold;\">" + kayit.Kutuk_sayisi + " </td>");
                    htmlTable.Append("<td style=\"color: #e602f3; font-weight: bold;\">" + kayit.Tonaj.Replace(",", ".") + "</td>");
                    htmlTable.Append("</tr>");
                }
            }
            ph_filmasin_uretim_toplam.Controls.Clear();
            ph_filmasin_uretim_toplam.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }
        private void toplam_uretim_ihracat(int baslangic_tarihi, int bitis_tarihi)
        {

            StringBuilder htmlTable = new StringBuilder();
            kayitlar = db.toplam_uretim_ihracat(baslangic_tarihi, bitis_tarihi);
            if (kayitlar[0].Analiz_id == 0)
            {
                // Kayit Bulunamadi
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan='5'>" + kayitlar[0].Aciklama + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var kayit in kayitlar)
                {
                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td style=\"color: #e602f3; font-weight: bold;\">" + kayit.Dokum_sayisi + " </td>");
                    htmlTable.Append("<td style=\"color: #e602f3; font-weight: bold;\">" + kayit.Kutuk_sayisi + " </td>");
                    htmlTable.Append("<td style=\"color: #e602f3; font-weight: bold;\">" + kayit.Tonaj.Replace(",", ".") + "</td>");
                    htmlTable.Append("</tr>");
                }
            }
            ph_ihracat_uretim_toplam.Controls.Clear();
            ph_ihracat_uretim_toplam.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }
        //
        private void uretim_ozet_liste(int baslangic_tarihi, int bitis_tarihi)
        {

            StringBuilder htmlTable = new StringBuilder();

            kayitlar = db.uretim_ozet_read(baslangic_tarihi, bitis_tarihi);
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
                        htmlTable.Append("<td>" + kayit.Uretim_yeri + "</td>");
                        htmlTable.Append("</tr>");
                    }
                }
            }
            ph_uretim_ozet.Controls.Clear();
            ph_uretim_ozet.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }
        private void filmasin_ozet_liste(int baslangic_tarihi, int bitis_tarihi)
        {

            StringBuilder htmlTable = new StringBuilder();
            kayitlar = db.filmasin_ozet_read(baslangic_tarihi, bitis_tarihi);
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
            ph_filmasin_ozet.Controls.Clear();
            ph_filmasin_ozet.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }
        private void ihracat_ozet_liste(int baslangic_tarihi, int bitis_tarihi)
        {
            StringBuilder htmlTable = new StringBuilder();
            kayitlar = db.ihracat_ozet_read(baslangic_tarihi, bitis_tarihi);
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
                        htmlTable.Append("<td>" + kayit.Siparis_no + "</td>");
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
            ph_ihracat_ozet.Controls.Clear();
            ph_ihracat_ozet.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }



        private void uretimden_sapma_ozet_liste(int baslangic_tarihi, int bitis_tarihi)
        {

            StringBuilder htmlTable = new StringBuilder();
            kayitlar = db.uretimdensapma_ozet_read(baslangic_tarihi, bitis_tarihi);
            if (kayitlar[0].Analiz_id == 0)
            {
                // Kayit Bulunamadi
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan='6'>" + kayitlar[0].Aciklama + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var kayit in kayitlar)
                {
                    if (kayit.Uretimdensapma_nedeni != "")
                    {
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td>" + kayit.Uretimdensapma_element + "</td>");
                        htmlTable.Append("<td>" + kayit.Dokum_sayisi + " </td>");
                        htmlTable.Append("<td class='tonaj'>" + kayit.Tonaj.Replace(",", ".") + "</td>");
                        htmlTable.Append("<td>" + kayit.Uretimdensapma_nedeni + "</td>");
                        htmlTable.Append("</tr>");
                    }
                }
            }
            ph_uretimden_sapma_ozet.Controls.Clear();
            ph_uretimden_sapma_ozet.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }
        private void stddisi_uretim_ozet(int baslangic_tarihi, int bitis_tarihi)
        {

            StringBuilder htmlTable = new StringBuilder();
            kayitlar = db.uretim_std_disi_ozet_read(baslangic_tarihi, bitis_tarihi);
            if (kayitlar[0].Analiz_id == 0)
            {
                // Kayit Bulunamadi
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan='6'>" + kayitlar[0].Aciklama + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var kayit in kayitlar)
                {
                    if (kayit.Standart_disi_element != "")
                    {
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td>" + kayit.Standart_disi_element + "</td>");
                        htmlTable.Append("<td>" + kayit.Dokum_sayisi + " </td>");
                        htmlTable.Append("<td class='tonaj'>" + kayit.Tonaj.Replace(",", ".") + "</td>");
                        htmlTable.Append("<td>" + kayit.Standart_disi_neden + "</td>");
                        htmlTable.Append("</tr>");
                    }
                }
            }
            ph_uretim_std_disi_ozet.Controls.Clear();
            ph_uretim_std_disi_ozet.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }



        protected void btn_Listele_Click(object sender, EventArgs e)
        {
            string baslangic_tarihi = tx_rapor_tarihi.Text;//textboxdaki bicimi
            string tarih = baslangic_tarihi.Replace("-", "");//veritabanindaki kayit bicimi
            string bitis_tarihi = tx_rapor_tarihi2.Text;
            string tarih2 = bitis_tarihi.Replace("-", "");

            tx_rapor_tarihi.Text = baslangic_tarihi;
            tx_rapor_tarihi2.Text = bitis_tarihi;

            raporlari_getir(tarih, tarih2);
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../../Default2.aspx");
        }
    }
}