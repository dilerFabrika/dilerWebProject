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

namespace diler.Web.Forms.Dosis
{
    public partial class rapor_ozet : System.Web.UI.Page
    {
        Dosis_rapor_db db = new Dosis_rapor_db();
        List<Dosis_rapor_bilgileri> kayitlar = new List<Dosis_rapor_bilgileri>();
        List<Dosis_rapor_bilgileri> kayitlar_ = new List<Dosis_rapor_bilgileri>();



        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../../Default2.aspx");
        }
        protected void btn_listele_Click(object sender, EventArgs e)
        {
            string tarih_bas = tx_rapor_tarihi.Text;//textboxdaki bicimi
            string tarih = tarih_bas.Replace("-", "");//veritabanindaki kayit bicimi
            string tarih_bitis = tx_rapor_tarihi2.Text;
            string tarih2 = tarih_bitis.Replace("-", "");
            if (tarih_bas != "" && tarih_bitis != "")
            {
                raporlari_getir(Convert.ToInt32(tarih), Convert.ToInt32(tarih2));
            }

        }

        private void raporlari_getir(int tarih, int tarih2)
        {
            db.Connect();
            oneri_formlari(tarih, tarih2);
            oneri_durum_listesi(tarih, tarih2);
            lokasyona_gore_oneriler_listesi(tarih, tarih2);
            kategoriye_gore_oneriler_listesi(tarih, tarih2);
            oneri_veren_bolum_listesi(tarih, tarih2);
            oneri_uygulayan_bolum_listesi(tarih, tarih2);
            db.Disconnect();
        }
        private void oneri_uygulayan_bolum_listesi(int tarih, int tarih2)
        {
            StringBuilder htmlTable = new StringBuilder();
            kayitlar = db.oneri_uygulayan_bolum_listesi(tarih, tarih2);
            if (kayitlar[0].Rapor_id == 0)
            {
                // Kayit Bulunamadı
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan=\"3\">" + kayitlar[0].Rapor_id + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var kayit in kayitlar)
                {
                    htmlTable.Append("<tr class='table_t'>");
                    htmlTable.Append("<td style =\"text-align:center\">" + kayit.Oneri_uygulayan_bolum + "</td>");
                    htmlTable.Append("<td style =\"text-align:center\">" + kayit.Oneri_sayisi + "</td>");
                    htmlTable.Append("</tr>");

                }
            }
            ph_oneri_uygulayan_bolum.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }
        private void oneri_veren_bolum_listesi(int tarih, int tarih2)
        {
            StringBuilder htmlTable = new StringBuilder();
            kayitlar = db.oneri_veren_bolum_listesi(tarih, tarih2);
            if (kayitlar[0].Rapor_id == 0)
            {
                // Kayit Bulunamadı
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan=\"3\">" + kayitlar[0].Rapor_id + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var kayit in kayitlar)
                {
                    if (kayit.Oneri_sayisi != "0")
                    {
                        htmlTable.Append("<tr class='table_t'>");
                        htmlTable.Append("<td style =\"text-align:center\">" + kayit.Oneri_veren_bolum + "</td>");
                        htmlTable.Append("<td style =\"text-align:center\">" + kayit.Oneri_sayisi + "</td>");
                        htmlTable.Append("</tr>");
                    }
                }
            }
            ph_oneri_veren_bolum.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }
        private void kategoriye_gore_oneriler_listesi(int tarih, int tarih2)
        {
            StringBuilder htmlTable = new StringBuilder();
            kayitlar = db.kategoriye_gore_oneriler_listesi(tarih, tarih2);
            if (kayitlar[0].Rapor_id == 0)
            {
                // Kayit Bulunamadı
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan=\"3\">" + kayitlar[0].Rapor_id + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var kayit in kayitlar)
                {
                    htmlTable.Append("<tr class='table_t'>");
                    htmlTable.Append("<td style =\"text-align:center\">" + kayit.Kategori + "</td>");
                    htmlTable.Append("<td style =\"text-align:center\">" + kayit.Oneri_sayisi + "</td>");
                    htmlTable.Append("</tr>");

                }
            }
            ph_kategoriye_gore_oneri_sayisi.Controls.Add(new Literal { Text = htmlTable.ToString() });

        }
        private void lokasyona_gore_oneriler_listesi(int tarih, int tarih2)
        {
            StringBuilder htmlTable = new StringBuilder();
            kayitlar = db.lokasyona_gore_oneriler_listesi(tarih, tarih2);
            if (kayitlar[0].Rapor_id == 0)
            {
                // Kayit Bulunamadı
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan=\"3\">" + kayitlar[0].Rapor_id + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var kayit in kayitlar)
                {
                    htmlTable.Append("<tr class='table_t'>");
                    htmlTable.Append("<td style =\"text-align:center\">" + kayit.Lokasyon + "</td>");
                    htmlTable.Append("<td style =\"text-align:center\">" + kayit.Oneri_sayisi + "</td>");
                    htmlTable.Append("</tr>");

                }
            }
            ph_lokasyona_gore_oneri_sayisi.Controls.Add(new Literal { Text = htmlTable.ToString() });

        }
        private void oneri_durum_listesi(int tarih, int tarih2)
        {
            StringBuilder htmlTable = new StringBuilder();
            kayitlar = db.oneri_durum_listesi(tarih, tarih2);
            if (kayitlar[0].Rapor_id == 0)
            {
                // Kayit Bulunamadı
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan=\"3\">" + kayitlar[0].Rapor_id + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var kayit in kayitlar)
                {
                    htmlTable.Append("<tr class='table_t'>");
                    htmlTable.Append("<td style =\"text-align:center\">" + kayit.Oneri_durumu + "</td>");
                    htmlTable.Append("<td style =\"text-align:center\">" + kayit.Oneri_sayisi + "</td>");
                    htmlTable.Append("</tr>");

                }
            }
            ph_oneri_durum_ozet.Controls.Add(new Literal { Text = htmlTable.ToString() });

        }
        private void oneri_formlari(int tarih, int tarih2)
        {
            StringBuilder htmlTable = new StringBuilder();
            kayitlar = db.oneri_formlari(tarih, tarih2);
            if (kayitlar[0].Rapor_id == 0)
            {
                // Kayit Bulunamadı
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan=\"3\">" + kayitlar[0].Rapor_id + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var kayit in kayitlar)
                {
                    htmlTable.Append("<tr class='table_t'>");
                    htmlTable.Append("<td style =\"text-align:center\">" + kayit.Oneri_form_durumu + "</td>");
                    htmlTable.Append("<td style =\"text-align:center\">" + kayit.Oneri_sayisi + "</td>");
                    htmlTable.Append("</tr>");

                }
            }
            ph_oneri_sayisi_ozet.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }




        private void kategoriye_gore_oneriler_listesi_lokasyon_trigger(string gelen_veri_oneri_durumu, string gelen_veri_lokasyon, int tarih, int tarih2)
        {
            StringBuilder htmlTable = new StringBuilder();
            kayitlar = db.kategoriye_gore_oneriler_listesi_lokasyon_trigger(gelen_veri_oneri_durumu, gelen_veri_lokasyon, tarih, tarih2);
            if (kayitlar[0].Rapor_id == 0)
            {
                // Kayit Bulunamadı
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan=\"3\">" + kayitlar[0].Rapor_id + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var kayit in kayitlar)
                {
                    htmlTable.Append("<tr class='table_t'>");
                    htmlTable.Append("<td style =\"text-align:center\">" + kayit.Kategori + "</td>");
                    htmlTable.Append("<td style =\"text-align:center\">" + kayit.Oneri_sayisi + "</td>");
                    htmlTable.Append("</tr>");

                }
            }
            ph_kategoriye_gore_oneri_sayisi.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }

        private void kategoriye_gore_oneriler_listesi_oneri_durumu_trigger(string gelen_veri_oneri_durumu, int tarih, int tarih2)
        {
            StringBuilder htmlTable = new StringBuilder();
            kayitlar = db.kategoriye_gore_oneriler_listesi_(gelen_veri_oneri_durumu, tarih, tarih2);
            if (kayitlar[0].Rapor_id == 0)
            {
                // Kayit Bulunamadı
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan=\"3\">" + kayitlar[0].Rapor_id + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var kayit in kayitlar)
                {
                    htmlTable.Append("<tr class='table_t'>");
                    htmlTable.Append("<td style =\"text-align:center\">" + kayit.Kategori + "</td>");
                    htmlTable.Append("<td style =\"text-align:center\">" + kayit.Oneri_sayisi + "</td>");
                    htmlTable.Append("</tr>");

                }
            }
            ph_kategoriye_gore_oneri_sayisi.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }

        private void lokasyona_gore_oneriler_listesi_oneri_durumu_trigger(string gelen_veri_oneri_durumu, int tarih, int tarih2)
        {
            StringBuilder htmlTable = new StringBuilder();
            kayitlar = db.lokasyona_gore_oneriler_listesi_(gelen_veri_oneri_durumu, tarih, tarih2);
            if (kayitlar[0].Rapor_id == 0)
            {
                // Kayit Bulunamadı
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan=\"3\">" + kayitlar[0].Rapor_id + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var kayit in kayitlar)
                {
                    htmlTable.Append("<tr class='table_t'>");
                    htmlTable.Append("<td style =\"text-align:center\">" + kayit.Lokasyon + "</td>");
                    htmlTable.Append("<td style =\"text-align:center\">" + kayit.Oneri_sayisi + "</td>");
                    htmlTable.Append("</tr>");

                }
            }
            ph_lokasyona_gore_oneri_sayisi.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }




        protected void btn_listele_oneri_durumu_trigger_Click(object sender, EventArgs e)
        {
            string gelen_veri_oneri_durumu = txt_gelen_veri_oneri_durumu.Text;
            string tarih_bas = tx_rapor_tarihi.Text;//textboxdaki bicimi
            string tarih = tarih_bas.Replace("-", "");//veritabanindaki kayit bicimi
            string tarih_bitis = tx_rapor_tarihi2.Text;
            string tarih2 = tarih_bitis.Replace("-", "");
            db.Connect();

            oneri_formlari(Convert.ToInt32(tarih), Convert.ToInt32(tarih2));
            oneri_veren_bolum_listesi(Convert.ToInt32(tarih), Convert.ToInt32(tarih2));
            oneri_uygulayan_bolum_listesi(Convert.ToInt32(tarih), Convert.ToInt32(tarih2));
            oneri_durum_listesi(Convert.ToInt32(tarih), Convert.ToInt32(tarih2));

            lokasyona_gore_oneriler_listesi_oneri_durumu_trigger(gelen_veri_oneri_durumu, Convert.ToInt32(tarih), Convert.ToInt32(tarih2));
            kategoriye_gore_oneriler_listesi_oneri_durumu_trigger(gelen_veri_oneri_durumu, Convert.ToInt32(tarih), Convert.ToInt32(tarih2));

            dosis_listesi(gelen_veri_oneri_durumu, tarih, tarih2);
            db.Disconnect();
        }
        protected void btn_listele_lokasyon_trigger_Click(object sender, EventArgs e)
        {
            string gelen_veri_oneri_durumu = txt_gelen_veri_oneri_durumu.Text;
            string gelen_veri_lokasyon = txt_gelen_veri_lokasyon.Text;
            string tarih_bas = tx_rapor_tarihi.Text;//textboxdaki bicimi
            string tarih = tarih_bas.Replace("-", "");//veritabanindaki kayit bicimi
            string tarih_bitis = tx_rapor_tarihi2.Text;
            string tarih2 = tarih_bitis.Replace("-", "");
            db.Connect();

            oneri_formlari(Convert.ToInt32(tarih), (Convert.ToInt32(tarih2)));
            oneri_veren_bolum_listesi((Convert.ToInt32(tarih)), (Convert.ToInt32(tarih2)));
            oneri_uygulayan_bolum_listesi((Convert.ToInt32(tarih)), (Convert.ToInt32(tarih2)));
            oneri_durum_listesi((Convert.ToInt32(tarih)), (Convert.ToInt32(tarih2)));

            lokasyona_gore_oneriler_listesi_oneri_durumu_trigger(gelen_veri_oneri_durumu, (Convert.ToInt32(tarih)), (Convert.ToInt32(tarih2)));
            if (gelen_veri_lokasyon == "Diler" || gelen_veri_lokasyon == "Filmasin")
            {
                kategoriye_gore_oneriler_listesi_lokasyon_trigger(gelen_veri_oneri_durumu, gelen_veri_lokasyon, (Convert.ToInt32(tarih)), (Convert.ToInt32(tarih2)));
                dosis_listesi_lokasyon_trigger(gelen_veri_oneri_durumu, gelen_veri_lokasyon, tarih, tarih2);
            }
            else
            {
                kategoriye_gore_oneriler_listesi_oneri_durumu_trigger(gelen_veri_oneri_durumu, (Convert.ToInt32(tarih)), (Convert.ToInt32(tarih2)));
            }

            db.Disconnect();


        }
        protected void btn_listele_kategori_trigger_Click(object sender, EventArgs e)
        {

            string gelen_veri_oneri_durumu = txt_gelen_veri_oneri_durumu.Text;
            string gelen_veri_lokasyon = txt_gelen_veri_lokasyon.Text;
            string gelen_veri_kategori = txt_gelen_veri_kategori.Text;

            string tarih_bas = tx_rapor_tarihi.Text;//textboxdaki bicimi
            string tarih = tarih_bas.Replace("-", "");//veritabanindaki kayit bicimi
            string tarih_bitis = tx_rapor_tarihi2.Text;
            string tarih2 = tarih_bitis.Replace("-", "");
            db.Connect();

            oneri_formlari(Convert.ToInt32(tarih), (Convert.ToInt32(tarih2)));
            oneri_veren_bolum_listesi((Convert.ToInt32(tarih)), (Convert.ToInt32(tarih2)));
            oneri_uygulayan_bolum_listesi((Convert.ToInt32(tarih)), (Convert.ToInt32(tarih2)));
            oneri_durum_listesi((Convert.ToInt32(tarih)), (Convert.ToInt32(tarih2)));
            dosis_listesi_kategori_trigger(gelen_veri_oneri_durumu, gelen_veri_kategori, gelen_veri_lokasyon, tarih, tarih2);
            lokasyona_gore_oneriler_listesi_oneri_durumu_trigger(gelen_veri_oneri_durumu, (Convert.ToInt32(tarih)), (Convert.ToInt32(tarih2)));
            if (gelen_veri_lokasyon == "Diler" || gelen_veri_lokasyon == "Filmasin")
            {
                kategoriye_gore_oneriler_listesi_lokasyon_trigger(gelen_veri_oneri_durumu, gelen_veri_lokasyon, (Convert.ToInt32(tarih)), (Convert.ToInt32(tarih2)));

            }
            else
            {
                kategoriye_gore_oneriler_listesi_oneri_durumu_trigger(gelen_veri_oneri_durumu, (Convert.ToInt32(tarih)), (Convert.ToInt32(tarih2)));

            }

            db.Disconnect();

        }



        private void dosis_listesi(string gelen_veri_oneri_durumu, string tarih, string tarih2)
        {
            StringBuilder htmlTable = new StringBuilder();
            kayitlar_ = db.dosis_listesi(gelen_veri_oneri_durumu, tarih, tarih2);
            if (kayitlar_[0].Rapor_id == 0)
            {
                //kayit bulunamadı
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan='21'>" + kayitlar_[0].Rapor_id + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var kayit in kayitlar_)
                {

                    htmlTable.Append("<tr class='table_t'>");
                    htmlTable.Append("<td> " + kayit.Oneri_no + "</td>");
                    htmlTable.Append("<td> " + kayit.Form_no + "</td>");
                    htmlTable.Append("<td> " + kayit.Lokasyon + "</td>");
                    htmlTable.Append("<td> " + kayit.Kategori + "</td>");
                    htmlTable.Append("<td> " + kayit.Oneri_giris_tarihi + "</td>");
                    htmlTable.Append("<td> " + kayit.Oneri_veren_adsoyad + "</td>");
                    htmlTable.Append("<td> " + kayit.Oneri_veren_bolum + "</td>");
                    htmlTable.Append("<td> " + kayit.Uygulama_yeri + "</td>");
                    htmlTable.Append("<td> " + kayit.Oneri_ozeti + "</td>");
                    htmlTable.Append("<td> " + kayit.Mudur_onayi + "</td>");
                    htmlTable.Append("<td> " + kayit.Oneri_baslama_tarihi + " </td>");
                    htmlTable.Append("<td> " + kayit.Planlanan_bitis_tarihi + " </td>");
                    htmlTable.Append("<td> " + kayit.Oneri_bitis_tarihi + "</td>");
                    htmlTable.Append("<td> " + kayit.Oneri_kapanis_tarihi + "</td>");
                    htmlTable.Append("<td> " + kayit.Uygulama_gorevlisi + "</td>");
                    htmlTable.Append("<td> " + kayit.Oneri_uygulayan_bolum + "</td>");
                    htmlTable.Append("<td> " + kayit.Getiri_aciklamasi + "</td>");
                    htmlTable.Append("<td> " + kayit.Getiri_miktari + " </td>");
                    htmlTable.Append("<td> " + kayit.Odul + " </td>");
                    htmlTable.Append("<td> " + kayit.Odul_verilis_tarihi + "</td>");
                    htmlTable.Append("<td> " + kayit.İptal_nedeni + "</td>");
                    htmlTable.Append("<td> " + kayit.Uygulayici_red_nedeni + "</td>");
                    htmlTable.Append("<td> " + kayit.Mudur_red_nedeni + " </td>");
                    htmlTable.Append("</tr>");

                }
            }
            ph_dosis_tablosu.Controls.Clear();
            ph_dosis_tablosu.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }
        private void dosis_listesi_lokasyon_trigger(string gelen_veri_oneri_durumu, string gelen_veri_lokasyon, string tarih, string tarih2)
        {
            StringBuilder htmlTable = new StringBuilder();
            kayitlar_ = db.dosis_listesi_lokasyon_trigger(gelen_veri_oneri_durumu, gelen_veri_lokasyon, tarih, tarih2);
            if (kayitlar_[0].Rapor_id == 0)
            {
                //kayit bulunamadı
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan='21'>" + kayitlar_[0].Rapor_id + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var kayit in kayitlar_)
                {

                    htmlTable.Append("<tr class='table_t'>");
                    htmlTable.Append("<td> " + kayit.Oneri_no + "</td>");
                    htmlTable.Append("<td> " + kayit.Form_no + "</td>");
                    htmlTable.Append("<td> " + kayit.Lokasyon + "</td>");
                    htmlTable.Append("<td> " + kayit.Kategori + "</td>");
                    htmlTable.Append("<td> " + kayit.Oneri_giris_tarihi + "</td>");
                    htmlTable.Append("<td> " + kayit.Oneri_veren_adsoyad + "</td>");
                    htmlTable.Append("<td> " + kayit.Oneri_veren_bolum + "</td>");
                    htmlTable.Append("<td> " + kayit.Uygulama_yeri + "</td>");
                    htmlTable.Append("<td> " + kayit.Oneri_ozeti + "</td>");
                    htmlTable.Append("<td> " + kayit.Mudur_onayi + "</td>");
                    htmlTable.Append("<td> " + kayit.Oneri_baslama_tarihi + " </td>");
                    htmlTable.Append("<td> " + kayit.Planlanan_bitis_tarihi + " </td>");
                    htmlTable.Append("<td> " + kayit.Oneri_bitis_tarihi + "</td>");
                    htmlTable.Append("<td> " + kayit.Oneri_kapanis_tarihi + "</td>");
                    htmlTable.Append("<td> " + kayit.Uygulama_gorevlisi + "</td>");
                    htmlTable.Append("<td> " + kayit.Oneri_uygulayan_bolum + "</td>");
                    htmlTable.Append("<td> " + kayit.Getiri_aciklamasi + "</td>");
                    htmlTable.Append("<td> " + kayit.Getiri_miktari + " </td>");
                    htmlTable.Append("<td> " + kayit.Odul + " </td>");
                    htmlTable.Append("<td> " + kayit.Odul_verilis_tarihi + "</td>");
                    htmlTable.Append("<td> " + kayit.İptal_nedeni + "</td>");
                    htmlTable.Append("<td> " + kayit.Uygulayici_red_nedeni + "</td>");
                    htmlTable.Append("<td> " + kayit.Mudur_red_nedeni + " </td>");
                    htmlTable.Append("</tr>");

                }
            }
            ph_dosis_tablosu.Controls.Clear();
            ph_dosis_tablosu.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }
        private void dosis_listesi_kategori_trigger(string gelen_veri_oneri_durumu, string gelen_veri_kategori, string gelen_veri_lokasyon, string tarih, string tarih2)
        {
            StringBuilder htmlTable = new StringBuilder();
            kayitlar_ = db.dosis_listesi_kategori_trigger(gelen_veri_oneri_durumu, gelen_veri_kategori, gelen_veri_lokasyon, tarih, tarih2);
            if (kayitlar_[0].Rapor_id == 0)
            {
                //kayit bulunamadı
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan='21'>" + kayitlar_[0].Rapor_id + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var kayit in kayitlar_)
                {

                    htmlTable.Append("<tr class='table_t'>");
                    htmlTable.Append("<td> " + kayit.Oneri_no + "</td>");
                    htmlTable.Append("<td> " + kayit.Form_no + "</td>");
                    htmlTable.Append("<td> " + kayit.Lokasyon + "</td>");
                    htmlTable.Append("<td> " + kayit.Kategori + "</td>");
                    htmlTable.Append("<td> " + kayit.Oneri_giris_tarihi + "</td>");
                    htmlTable.Append("<td> " + kayit.Oneri_veren_adsoyad + "</td>");
                    htmlTable.Append("<td> " + kayit.Oneri_veren_bolum + "</td>");
                    htmlTable.Append("<td> " + kayit.Uygulama_yeri + "</td>");
                    htmlTable.Append("<td> " + kayit.Oneri_ozeti + "</td>");
                    htmlTable.Append("<td> " + kayit.Mudur_onayi + "</td>");
                    htmlTable.Append("<td> " + kayit.Oneri_baslama_tarihi + " </td>");
                    htmlTable.Append("<td> " + kayit.Planlanan_bitis_tarihi + " </td>");
                    htmlTable.Append("<td> " + kayit.Oneri_bitis_tarihi + "</td>");
                    htmlTable.Append("<td> " + kayit.Oneri_kapanis_tarihi + "</td>");
                    htmlTable.Append("<td> " + kayit.Uygulama_gorevlisi + "</td>");
                    htmlTable.Append("<td> " + kayit.Oneri_uygulayan_bolum + "</td>");
                    htmlTable.Append("<td> " + kayit.Getiri_aciklamasi + "</td>");
                    htmlTable.Append("<td> " + kayit.Getiri_miktari + " </td>");
                    htmlTable.Append("<td> " + kayit.Odul + " </td>");
                    htmlTable.Append("<td> " + kayit.Odul_verilis_tarihi + "</td>");
                    htmlTable.Append("<td> " + kayit.İptal_nedeni + "</td>");
                    htmlTable.Append("<td> " + kayit.Uygulayici_red_nedeni + "</td>");
                    htmlTable.Append("<td> " + kayit.Mudur_red_nedeni + " </td>");
                    htmlTable.Append("</tr>");

                }
            }
            ph_dosis_tablosu.Controls.Clear();
            ph_dosis_tablosu.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }





    }
}