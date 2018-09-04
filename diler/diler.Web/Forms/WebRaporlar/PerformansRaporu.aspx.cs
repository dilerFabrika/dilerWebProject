using diler.Dal;
using diler.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace diler.Web
{
    public partial class PerformansRaporu : System.Web.UI.Page
    {
        Performans_db db = new Performans_db();
        List<Performans_raporu> performans_raporu = new List<Performans_raporu>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DateTime dt = new DateTime();
                dt = DateTime.Now;
                string tarih = dt.ToString("yyyy-MM-dd");//textboxdaki bicimi;
                tx_rapor_tarihi.Text = tarih;
                string secilen_vrd = cmb_vrd.SelectedValue;
                if (secilen_vrd != "all")
                {
                    raporlari_getir(tarih.Replace("-", ""), secilen_vrd);

                }
                else
                {
                    raporlari_getir(tarih.Replace("-", ""), "0");
                }

            }
        }

        private void raporlari_getir(string tarih, string secilen_vrd)
        {
            StringBuilder htmlTable = new StringBuilder();
            if (tarih != "")
            {
                db.Connect();
                int tarih2 = Convert.ToInt32(tarih);

                if (secilen_vrd != "all")
                {
                    int secilen_vardiya = Convert.ToInt32(secilen_vrd);

                    performans_raporu_gun_liste(tarih2, secilen_vardiya);
                    performans_raporu_gun_ort_liste(tarih2, secilen_vardiya);
                    gunluk_uretim_ozet_liste(tarih2, secilen_vardiya);
                    gunluk_toplam_uretim(tarih2, secilen_vardiya);
                    gunluk_verim(tarih2, secilen_vardiya);

                }
                else
                {
                    performans_raporu_gun_liste(tarih2, 0);
                    performans_raporu_gun_ort_liste(tarih2, 0);
                    gunluk_uretim_ozet_liste(tarih2, 0);
                    gunluk_toplam_uretim(tarih2, 0);
                    gunluk_verim(tarih2, 0);

                }
                db.Disconnect();
            }
        }
        private void performans_raporu_gun_liste(int tarih2, int secilen_vardiya)
        {
            StringBuilder htmlTable = new StringBuilder();
            performans_raporu = db.performans_raporu_gun_data_read(tarih2, secilen_vardiya);
            if (performans_raporu[0].Id == 0)
            {
                // Kayit Bululnamadı
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan=\"38\">" + performans_raporu[0].Vrd + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {

                foreach (var kayit in performans_raporu)
                {
                    if (kayit.Kutuk_tonaji != 0)
                    {
                        if (kayit.Vrd == "1")
                        {
                            htmlTable.Append("<tr>");
                            htmlTable.Append("<td style=\"color:#e602f3; font-weight: bold;\">" + kayit.Dokum_no + "</td>");
                            htmlTable.Append("<td style=\"color:#e602f3; font-weight: bold;\">" + kayit.Vrd + "</td>");
                            htmlTable.Append("<td style=\"color:#e602f3; font-weight: bold;\">" + kayit.Srj + "</td>");
                            htmlTable.Append("<td style=\" color:#e602f3;font-weight: bold;text-align:center\">" + kayit.Toplam_srj + "</td>");
                            htmlTable.Append("<td style=\"color:#e602f3; font-weight: bold;text-align:center\">" + kayit.Dokum_baslangic_saati + "</td>");
                            htmlTable.Append("<td style=\"color:#e602f3; font-weight: bold;text-align:center\">" + kayit.Devirme_saati + "</td>");
                            htmlTable.Append("<td style=\"color:#e602f3; font-weight: bold;\">" + kayit.Enerjili_sure + "</td>");
                            htmlTable.Append("<td style=\"color:#e602f3; font-weight: bold;\">" + kayit.Enerjisiz_sure + "</td>");
                            htmlTable.Append("<td style=\"color:#e602f3; font-weight: bold;text-align:center\">" + kayit.Toplam_sure + "</td>");
                            htmlTable.Append("<td style=\" color:#e602f3; font-weight: bold; text-align:center\" > " + kayit.Devirme_sicaklik + "</td>");
                            htmlTable.Append("<td style=\"color:#e602f3; font-weight: bold;text-align:center\" > " + kayit.Po_giris_sicakligi + "</td>");
                            htmlTable.Append("<td style=\" color:#e602f3; font-weight: bold;\">" + kayit.Ao_enerji + "</td>");
                            htmlTable.Append("<td style=\"color:#e602f3; font-weight: bold;\">" + kayit.Po_enerji + "</td>");
                            htmlTable.Append("<td style=\" color:#e602f3; font-weight: bold;text-align:center\">" + kayit.Po_enerjili_sure + "</td>");
                            htmlTable.Append("<td style=\"color:#e602f3; font-weight: bold;text-align:center\">" + kayit.Po_brut_sure + "</td>");
                            htmlTable.Append("<td style=\" color:#e602f3; font-weight: bold;\">" + kayit.Enj_Kok_elt + "</td>");
                            htmlTable.Append("<td style=\"color: #e602f3; font-weight: bold;\">" + kayit.Enj_kırec + "</td>");
                            htmlTable.Append("<td style=\"color: #e602f3; font-weight: bold;\">" + kayit.Parca_kırec + "</td>");
                            htmlTable.Append("<td style=\"color: #e602f3; font-weight: bold;\">" + kayit.Toplam_kirec + "</td>");
                            htmlTable.Append("<td style=\"color: #e602f3; font-weight: bold;text-align:center\">" + kayit.Kutuk_tonaji.ToString().Replace(",", ".") + "</td>");
                            htmlTable.Append("<td style=\"color: #e602f3; font-weight: bold;\">" + kayit.Tandis_bnd_sayisi + "</td>");
                            htmlTable.Append("<td style=\"color: #e602f3; font-weight: bold;\">" + kayit.Canak_dokum_say + "</td>");
                            htmlTable.Append("<td style=\"color: #e602f3; font-weight: bold;\">" + kayit.Kapak_dokum_say + "</td>");
                            htmlTable.Append("<td style=\"color: #e602f3; font-weight: bold;\">" + kayit.Yurek_dokum_say + "</td>");
                            htmlTable.Append("<td style=\"color: #e602f3; font-weight: bold; text-align:center\">" + kayit.Rbt_delik_sayisi + "</td>");
                            htmlTable.Append("<td style=\"color: #e602f3; font-weight: bold;text-align:center\">" + kayit.Ao_trnk_kapatma_enerjisi + "</td>");
                            htmlTable.Append("<td style=\"color: #e602f3; font-weight: bold;\">" + kayit.Brl_dgaz + "</td>");
                            htmlTable.Append("<td style=\"color: #e602f3; font-weight: bold;\">" + kayit.Rcb_brl_dgaz + "</td>");
                            htmlTable.Append("<td style=\"color: #e602f3; font-weight: bold;\">" + kayit.Pc_dgaz + "</td>");
                            htmlTable.Append("<td style=\"color: #e602f3; font-weight: bold;\">" + kayit.Toplam_dgaz + "</td>");
                            htmlTable.Append("<td style=\"color: #e602f3; font-weight: bold; text-align:center\">" + kayit.Toplam_dgaz_ToplamTonaj.ToString().Replace(",", ".") + "</td>");
                            htmlTable.Append("<td style=\"color: #e602f3; font-weight: bold; text-align:center\">" + kayit.Toplam_dgaz_Toplamkireç + "</td>");
                            htmlTable.Append("</tr>");
                        }


                        if (kayit.Vrd == "2")
                        {
                            htmlTable.Append("<tr>");
                            htmlTable.Append("<td style=\"color: #4620d8; font-weight: bold;\">" + kayit.Dokum_no + "</td>");
                            htmlTable.Append("<td style=\"color: #4620d8;font-weight: bold; \">" + kayit.Vrd + "</td>");
                            htmlTable.Append("<td style=\"color: #4620d8; font-weight: bold;\">" + kayit.Srj + "</td>");
                            htmlTable.Append("<td style=\"color: #4620d8;font-weight: bold;text-align:center \">" + kayit.Toplam_srj + "</td>");
                            htmlTable.Append("<td style=\"color:#4620d8; font-weight: bold;text-align:center\">" + kayit.Dokum_baslangic_saati + "</td>");
                            htmlTable.Append("<td style=\"color: #4620d8; font-weight: bold;text-align:center\">" + kayit.Devirme_saati + "</td>");
                            htmlTable.Append("<td style=\"color: #4620d8; font-weight: bold;\">" + kayit.Enerjili_sure + "</td>");
                            htmlTable.Append("<td style=\"color: #4620d8; font-weight: bold;\">" + kayit.Enerjisiz_sure + "</td>");
                            htmlTable.Append("<td style=\"color: #4620d8; font-weight: bold;text-align:center\">" + kayit.Toplam_sure + "</td>");
                            htmlTable.Append("<td style=\"color: #4620d8; font-weight: bold;text-align:center\" > " + kayit.Devirme_sicaklik + "</td>");
                            htmlTable.Append("<td style=\"color: #4620d8; font-weight: bold; text-align:center\" > " + kayit.Po_giris_sicakligi + "</td>");
                            htmlTable.Append("<td style=\"color: #4620d8; font-weight: bold;\">" + kayit.Ao_enerji + "</td>");
                            htmlTable.Append("<td style=\"color: #4620d8; font-weight: bold;\">" + kayit.Po_enerji + "</td>");
                            htmlTable.Append("<td style=\"color: #4620d8; font-weight: bold;text-align:center\">" + kayit.Po_enerjili_sure + "</td>");
                            htmlTable.Append("<td style=\"color: #4620d8; font-weight: bold;text-align:center\">" + kayit.Po_brut_sure + "</td>");
                            htmlTable.Append("<td style=\"color: #4620d8; font-weight: bold;\">" + kayit.Enj_Kok_elt + "</td>");
                            htmlTable.Append("<td style=\"color: #4620d8; font-weight: bold;\">" + kayit.Enj_kırec + "</td>");
                            htmlTable.Append("<td style=\"color: #4620d8; font-weight: bold;\">" + kayit.Parca_kırec + "</td>");
                            htmlTable.Append("<td style=\"color: #4620d8; font-weight: bold;\">" + kayit.Toplam_kirec + "</td>");
                            htmlTable.Append("<td style=\"color: #4620d8; font-weight: bold; text-align:center\">" + kayit.Kutuk_tonaji.ToString().Replace(",", ".") + "</td>");
                            htmlTable.Append("<td style=\"color: #4620d8; font-weight: bold;\">" + kayit.Tandis_bnd_sayisi + "</td>");
                            htmlTable.Append("<td style=\"color: #4620d8; font-weight: bold;\">" + kayit.Canak_dokum_say + "</td>");
                            htmlTable.Append("<td style=\"color: #4620d8; font-weight: bold;\">" + kayit.Kapak_dokum_say + "</td>");
                            htmlTable.Append("<td style=\"color: #4620d8; font-weight: bold;\">" + kayit.Yurek_dokum_say + "</td>");
                            htmlTable.Append("<td style=\"color: #4620d8; font-weight: bold; text-align:center\">" + kayit.Rbt_delik_sayisi + "</td>");
                            htmlTable.Append("<td style=\"color: #4620d8; font-weight: bold;text-align:center\">" + kayit.Ao_trnk_kapatma_enerjisi + "</td>");
                            htmlTable.Append("<td style=\"color: #4620d8; font-weight: bold;\">" + kayit.Brl_dgaz + "</td>");
                            htmlTable.Append("<td style=\"color: #4620d8; font-weight: bold;\">" + kayit.Rcb_brl_dgaz + "</td>");
                            htmlTable.Append("<td style=\"color: #4620d8; font-weight: bold;\">" + kayit.Pc_dgaz + "</td>");
                            htmlTable.Append("<td style=\"color: #4620d8; font-weight: bold;\">" + kayit.Toplam_dgaz + "</td>");
                            htmlTable.Append("<td style=\"color: #4620d8; font-weight: bold;text-align:center\">" + kayit.Toplam_dgaz_ToplamTonaj.ToString().Replace(",", ".") + "</td>");
                            htmlTable.Append("<td style=\"color: #4620d8; font-weight: bold;text-align:center\">" + kayit.Toplam_dgaz_Toplamkireç + "</td>");
                            htmlTable.Append("</tr>");
                        }

                        if (kayit.Vrd == "3")
                        {
                            htmlTable.Append("<tr>");
                            htmlTable.Append("<td style=\"color:#f76d6d; font-weight: bold;\">" + kayit.Dokum_no + "</td>");
                            htmlTable.Append("<td style=\"color:#f76d6d; font-weight: bold;\" >" + kayit.Vrd + "</td>");
                            htmlTable.Append("<td style=\"color:#f76d6d;font-weight: bold;\">" + kayit.Srj + "</td>");
                            htmlTable.Append("<td style=\"color:#f76d6d;font-weight: bold;text-align:center\">" + kayit.Toplam_srj + "</td>");
                            htmlTable.Append("<td style=\"color:#f76d6d; font-weight: bold;text-align:center\">" + kayit.Dokum_baslangic_saati + "</td>");
                            htmlTable.Append("<td style=\"color:#f76d6d;font-weight: bold;text-align:center\">" + kayit.Devirme_saati + "</td>");
                            htmlTable.Append("<td style=\"color:#f76d6d; font-weight: bold;\">" + kayit.Enerjili_sure + "</td>");
                            htmlTable.Append("<td style=\"color:#f76d6d; font-weight: bold;\">" + kayit.Enerjisiz_sure + "</td>");
                            htmlTable.Append("<td style=\"color:#f76d6d; font-weight: bold;text-align:center\">" + kayit.Toplam_sure + "</td>");
                            htmlTable.Append("<td style=\"color:#f76d6d; font-weight: bold;text-align:center\" > " + kayit.Devirme_sicaklik + "</td>");
                            htmlTable.Append("<td style=\"color:#f76d6d; font-weight: bold;text-align:center\" > " + kayit.Po_giris_sicakligi + "</td>");
                            htmlTable.Append("<td style=\"color:#f76d6d; font-weight: bold;\">" + kayit.Ao_enerji + "</td>");
                            htmlTable.Append("<td style=\"color:#f76d6d; font-weight: bold;\">" + kayit.Po_enerji + "</td>");
                            htmlTable.Append("<td style=\"color:#f76d6d; font-weight: bold;text-align:center\">" + kayit.Po_enerjili_sure + "</td>");
                            htmlTable.Append("<td style=\"color:#f76d6d; font-weight: bold;text-align:center\">" + kayit.Po_brut_sure + "</td>");
                            htmlTable.Append("<td style=\"color:#f76d6d; font-weight: bold;\">" + kayit.Enj_Kok_elt + "</td>");
                            htmlTable.Append("<td style=\"color:#f76d6d; font-weight: bold;\">" + kayit.Enj_kırec + "</td>");
                            htmlTable.Append("<td style=\"color:#f76d6d; font-weight: bold;\">" + kayit.Parca_kırec + "</td>");
                            htmlTable.Append("<td style=\"color:#f76d6d; font-weight: bold;\">" + kayit.Toplam_kirec + "</td>");
                            htmlTable.Append("<td style=\"color:#f76d6d; font-weight: bold; text-align:center\">" + kayit.Kutuk_tonaji.ToString().Replace(",", ".") + "</td>");
                            htmlTable.Append("<td style=\"color:#f76d6d; font-weight: bold;\">" + kayit.Tandis_bnd_sayisi + "</td>");
                            htmlTable.Append("<td style=\"color:#f76d6d; font-weight: bold;\">" + kayit.Canak_dokum_say + "</td>");
                            htmlTable.Append("<td style=\"color:#f76d6d; font-weight: bold;\">" + kayit.Kapak_dokum_say + "</td>");
                            htmlTable.Append("<td style=\"color:#f76d6d; font-weight: bold;\">" + kayit.Yurek_dokum_say + "</td>");
                            htmlTable.Append("<td style=\"color:#f76d6d; font-weight: bold; text-align:center\">" + kayit.Rbt_delik_sayisi + "</td>");
                            htmlTable.Append("<td style=\"color:#f76d6d; font-weight: bold;text-align:center\">" + kayit.Ao_trnk_kapatma_enerjisi + "</td>");
                            htmlTable.Append("<td style=\"color:#f76d6d; font-weight: bold;\">" + kayit.Brl_dgaz + "</td>");
                            htmlTable.Append("<td style=\"color:#f76d6d; font-weight: bold;\">" + kayit.Rcb_brl_dgaz + "</td>");
                            htmlTable.Append("<td style=\"color:#f76d6d; font-weight: bold;\">" + kayit.Pc_dgaz + "</td>");
                            htmlTable.Append("<td style=\"color:#f76d6d; font-weight: bold;\">" + kayit.Toplam_dgaz + "</td>");
                            htmlTable.Append("<td style=\"color:#f76d6d; font-weight: bold;text-align:center\">" + kayit.Toplam_dgaz_ToplamTonaj.ToString().Replace(",", ".") + "</td>");
                            htmlTable.Append("<td style=\"color:#f76d6d; font-weight: bold;text-align:center\">" + kayit.Toplam_dgaz_Toplamkireç + "</td>");
                            htmlTable.Append("</tr>");
                        }

                    }
                }
            }
            ph_performans_raporu.Controls.Clear();
            ph_performans_raporu.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }
        private void performans_raporu_gun_ort_liste(int tarih2, int secilen_vardiya)
        {
            StringBuilder htmlTable = new StringBuilder();
            performans_raporu = db.performans_raporu_gun_ort_data_read(tarih2, secilen_vardiya);
            if (performans_raporu[0].Id == 0)
            {
                // Kayit Bululnamadı
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan=\"30\">" + performans_raporu[0].Vrd + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {

                foreach (var kayit in performans_raporu)
                {
                    if (kayit.Dokum_no != 0)
                    {
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td> </td>");
                        htmlTable.Append("<td>" + kayit.Dokum_no + "</td>");
                        htmlTable.Append("<td>" + kayit.Srj + "</td>");
                        htmlTable.Append("<td>" + kayit.Toplam_srj + "</td>");
                        htmlTable.Append("<td>" + kayit.Enerjili_sure.Replace(",", ".") + "</td>");
                        htmlTable.Append("<td>" + kayit.Enerjisiz_sure.Replace(",", ".") + "</td>");
                        htmlTable.Append("<td>" + kayit.Toplam_sure.Replace(",", ".") + "</td>");
                        htmlTable.Append("<td>" + kayit.Devirme_sicaklik.Replace(",", ".") + "</td>");
                        htmlTable.Append("<td>" + kayit.Po_giris_sicakligi.Replace(",", ".") + "</td>");
                        htmlTable.Append("<td>" + kayit.Ao_enerji.ToString().Replace(",", ".") + "</td>");
                        htmlTable.Append("<td>" + kayit.Po_enerji.ToString().Replace(",", ".") + "</td>");
                        htmlTable.Append("<td>" + kayit.Po_enerjili_sure.ToString().Replace(",", ".") + "</td>");
                        htmlTable.Append("<td>" + kayit.Po_brut_sure.ToString().Replace(",", ".") + "</td>");
                        htmlTable.Append("<td>" + kayit.Enj_Kok_elt.ToString().Replace(",", ".") + "</td>");
                        htmlTable.Append("<td>" + kayit.Enj_kırec.ToString().Replace(",", ".") + "</td>");
                        htmlTable.Append("<td>" + kayit.Parca_kırec.ToString().Replace(",", ".") + "</td>");
                        htmlTable.Append("<td>" + kayit.Toplam_kirec.ToString().Replace(",", ".") + "</td>");
                        htmlTable.Append("<td>" + kayit.Kutuk_tonaji.ToString().Replace(",", ".") + "</td>");
                        htmlTable.Append("<td>" + kayit.Tandis_bnd_sayisi.Replace(",", ".") + "</td>");
                        htmlTable.Append("<td>" + kayit.Canak_dokum_say + "</td>");
                        htmlTable.Append("<td>" + kayit.Kapak_dokum_say + "</td>");
                        htmlTable.Append("<td>" + kayit.Yurek_dokum_say + "</td>");
                        htmlTable.Append("<td>" + kayit.Ao_trnk_kapatma_enerjisi.ToString().Replace(",", ".") + "</td>");
                        htmlTable.Append("<td>" + kayit.Brl_dgaz.ToString().Replace(",", ".") + "</td>");
                        htmlTable.Append("<td>" + kayit.Rcb_brl_dgaz.ToString().Replace(",", ".") + "</td>");
                        htmlTable.Append("<td>" + kayit.Pc_dgaz.ToString().Replace(",", ".") + "</td>");
                        htmlTable.Append("<td>" + kayit.Toplam_dgaz.ToString().Replace(",", ".") + "</td>");
                        htmlTable.Append("</tr>");
                    }
                }
            }
            ph_performans_raporu_Ort.Controls.Clear();
            ph_performans_raporu_Ort.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }

        private void gunluk_uretim_ozet_liste(int tarih2, int secilen_vardiya)

        {

            StringBuilder htmlTable = new StringBuilder();
            performans_raporu = db.gunluk_uretim_ozet_data_read(tarih2, secilen_vardiya);

            if (performans_raporu[0].Id == 0)
            {
                // Kayit Bulunamadi
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan='7'>" + performans_raporu[0].Aciklama + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var kayit in performans_raporu)
                {
                    if (kayit.Celik_cinsi != "")
                    {
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER;\">" + kayit.Celik_cinsi + "</td>");
                        htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER;\">" + kayit.Ebat + "</td>");
                        htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER;\">" + kayit.Boy + "</td>");
                        htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER;\">" + kayit.Kutuk_sayisi + "</td>");
                        htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER;\">" + kayit.Dokum_sayisi + "</td>");
                        htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER;\">" + kayit.Toplam_tonaj.Replace(",", ".") + "</td>");
                        htmlTable.Append("</tr>");
                    }
                }
            }
            ph_uretim_ozet.Controls.Clear();
            ph_uretim_ozet.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }
        private void gunluk_toplam_uretim(int tarih2, int secilen_vardiya)
        {
            performans_raporu = db.gunluk_toplam_uretim_data_read(tarih2, secilen_vardiya);

            StringBuilder htmlTable = new StringBuilder();

            if (performans_raporu[0].Id == 0)
            {
                // Kayit Bulunamadi
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan='3'>" + performans_raporu[0].Aciklama + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var kayit in performans_raporu)
                {
                    if (kayit.Dokum_sayisi != "0")
                    {
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER; color: #e602f3; font-weight: bold;\">" + kayit.Dokum_sayisi + " </td>");
                        htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER;  color: #e602f3; font-weight: bold;\">" + kayit.Toplam_tonaj.Replace(",", ".") + "</td>");
                        htmlTable.Append("</tr>");
                    }
                }
            }
            ph_toplam_uretim.Controls.Clear();
            ph_toplam_uretim.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }

        private void gunluk_verim(int tarih2, int secilen_vardiya)
        {

            StringBuilder htmlTable = new StringBuilder();
            performans_raporu = db.gunluk_verim_data_read(tarih2, secilen_vardiya);
            if (performans_raporu[0].Id == 0)
            {
                // Kayit Bulunamadi
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan='5'>" + performans_raporu[0].Id + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var kayit in performans_raporu)
                {
                    if (kayit.Toplam_tonaj != "0")
                    {
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER; color: #e602f3; font-weight: bold;\">" + kayit.Toplam_srj + " </td>");
                        htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER;  color: #e602f3; font-weight: bold;\">" + kayit.Toplam_tonaj.Replace(",", ".") + "</td>");
                        htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER;  color: #e602f3; font-weight: bold;\">" + kayit.Verim.Replace(",", ".") + "</td>");
                        htmlTable.Append("</tr>");
                    }
                }
            }
            ph_verim.Controls.Clear();
            ph_verim.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }

        private void rapor_tarihi_al()
        {
            string tarih2 = tx_rapor_tarihi.Text;//textboxdaki bicimi
            string tarih = tarih2.Replace("-", "");//veritabanindaki kayit bicimi
            tx_rapor_tarihi.Text = tarih2;
            string secilen_vrd = cmb_vrd.SelectedValue.ToString();
            raporlari_getir(tarih, secilen_vrd);
        }
        protected void tx_rapor_tarihi_TextChanged(object sender, EventArgs e)
        {
            rapor_tarihi_al();

        }

        protected void cmb_vrd_SelectedIndexChanged(object sender, EventArgs e)
        {

            rapor_tarihi_al();

        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../../Default2.aspx");
        }
    }
}