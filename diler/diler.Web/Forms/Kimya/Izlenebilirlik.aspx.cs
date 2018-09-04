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
    public partial class Izlenebilirlik : System.Web.UI.Page
    {
        Izlenebilirlik_db db = new Izlenebilirlik_db();
        List<Izlenebilirlik_bilgileri> kayitlar_ao = new List<Izlenebilirlik_bilgileri>();
        List<Izlenebilirlik_bilgileri> kayitlar_po = new List<Izlenebilirlik_bilgileri>();
        List<Izlenebilirlik_bilgileri> kayitlar_sdm = new List<Izlenebilirlik_bilgileri>();
        List<Izlenebilirlik_bilgileri> kayitlar_urt = new List<Izlenebilirlik_bilgileri>();
        List<Izlenebilirlik_bilgileri> kayitlar_tavfrn = new List<Izlenebilirlik_bilgileri>();
        List<Izlenebilirlik_bilgileri> kayitlar_filmasin_sevk = new List<Izlenebilirlik_bilgileri>();
        List<Izlenebilirlik_bilgileri> kayitlar_frndan_dusmus = new List<Izlenebilirlik_bilgileri>();
        List<Izlenebilirlik_bilgileri> kayitlar_tavfrn_sicaklik = new List<Izlenebilirlik_bilgileri>();
        List<Izlenebilirlik_bilgileri> kayitlar_fizik = new List<Izlenebilirlik_bilgileri>();
        List<Izlenebilirlik_bilgileri> kayitlar_tempcore = new List<Izlenebilirlik_bilgileri>();
        List<Izlenebilirlik_bilgileri> kayitlar_hurda_toplam = new List<Izlenebilirlik_bilgileri>();
        List<Izlenebilirlik_bilgileri> kayitlar_istif = new List<Izlenebilirlik_bilgileri>();


        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                DateTime dt = new DateTime();
                dt = DateTime.Now;
                string tarih = dt.ToString("yyyy-MM-dd");//textboxdaki bicimi;
                string tarih2 = dt.ToString("yyyy-MM-dd");//textboxdaki bicimi;

            }

        }
        private void tarihyaz(int dokumno = 0)
        {
            int gelen = Convert.ToInt32(db.tarihyaz(dokumno));
            string yil = (gelen / 10000).ToString();
            int aygun = gelen % 10000;
            string ay = (aygun / 100).ToString();
            string gun = (aygun % 100).ToString();
            if (gun.Length == 1)
            {
                gun = "0" + gun;

            }
            if (ay.Length == 1)
            {
                ay = "0" + ay;
            }
            string tarih_parse = (gun + "." + ay + "." + yil).ToString();
            txt_dokumnoyagore_tarih.Text = tarih_parse;

        }
        private void ao_izlenebilirlik_data(int dokumno = 0)
        {

            StringBuilder htmlTable = new StringBuilder();
            kayitlar_ao = db.ao_izlenebilirlik_data_read(dokumno);
            if (kayitlar_ao[0].Id == 0)
            {
                // Kayit Bululnamadı
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan=\"19\">" + kayitlar_ao[0].Vrd + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {

                foreach (var kayit in kayitlar_ao)
                {

                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td>" + kayit.Vrd + "</td>");
                    htmlTable.Append("<td>" + kayit.Dokum_baslangic_saati + "</td>");
                    htmlTable.Append("<td>" + kayit.Dokum_bitis_saati + "</td>");
                    htmlTable.Append("<td>" + kayit.Dokumsuresi + "</td>");
                    htmlTable.Append("<td>" + kayit.Enerjili_sure + "</td>");
                    htmlTable.Append("<td>" + kayit.Enerjisiz_sure + "</td>");
                    htmlTable.Append("<td>" + kayit.Devirme_sicaklik + "</td>");
                    htmlTable.Append("<td>" + kayit.Parca_kirec + "</td>");
                    htmlTable.Append("<td>" + kayit.Enj_kirec + "</td>");
                    htmlTable.Append("<td>" + kayit.Parca_kok + "</td>");
                    htmlTable.Append("<td>" + kayit.Dolamit + "</td>");
                    htmlTable.Append("<td>" + kayit.Dev_al + "</td>");
                    htmlTable.Append("<td>" + kayit.DevFesiMn + "</td>");

                    htmlTable.Append("</tr>");

                }
            }
            ph_ao_izlenebilirlik.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }
        private void po_izlenebilirlik_data(int dokumno = 0)
        {

            StringBuilder htmlTable = new StringBuilder();
            kayitlar_po = db.po_izlenebilirlik_data_read(dokumno);
            if (kayitlar_po[0].Id == 0)
            {
                // Kayit Bululnamadı
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan=\"19\">" + kayitlar_po[0].Vrd + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {

                foreach (var kayit in kayitlar_po)
                {

                    htmlTable.Append("<tr>");

                    htmlTable.Append("<td>" + kayit.Potano + "</td>");
                    htmlTable.Append("<td>" + kayit.Pota_giris_saati + "</td>");
                    htmlTable.Append("<td>" + kayit.Pota_bitis_saati + "</td>");
                    htmlTable.Append("<td>" + kayit.Po_giris_sicakligi + "</td>");
                    htmlTable.Append("<td>" + kayit.Po_cikis_sicakligi + "</td>");
                    htmlTable.Append("<td>" + kayit.Po_enerjilisure + "</td>");
                    htmlTable.Append("<td>" + kayit.C + "</td>");
                    htmlTable.Append("<td>" + kayit.CaO + "</td>");
                    htmlTable.Append("<td>" + kayit.Fesi + "</td>");
                    htmlTable.Append("<td>" + kayit.FesiMn + "</td>");
                    htmlTable.Append("<td>" + kayit.Al + "</td>");
                    htmlTable.Append("<td>" + kayit.CaF2 + "</td>");
                    htmlTable.Append("<td>" + kayit.MgO + "</td>");
                    htmlTable.Append("<td>" + kayit.Boksit + "</td>");
                    htmlTable.Append("<td>" + kayit.FeV + "</td>");

                    htmlTable.Append("</tr>");

                }
            }
            ph_po_izlenebilirlik.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }
        private void sdm_izlenebilirlik_data(int dokumno = 0)
        {

            StringBuilder htmlTable = new StringBuilder();
            kayitlar_sdm = db.sdm_izlenebilirlik_data_read(dokumno);
            if (kayitlar_sdm[0].Id == 0)
            {
                // Kayit Bululnamadı
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan=\"12\">" + kayitlar_sdm[0].Vrd + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {

                foreach (var kayit in kayitlar_sdm)
                {
                    htmlTable.Append("<tr>");

                    htmlTable.Append("<td style=\"text-align:center\">" + kayit.Pota_acma_saati + "</td>");
                    htmlTable.Append("<td style=\"text-align:center\">" + kayit.Pota_kapatma_saati + "</td>");
                    htmlTable.Append("<td>" + kayit.Yol1 + "</td>");
                    htmlTable.Append("<td>" + kayit.Yol2 + "</td>");
                    htmlTable.Append("<td>" + kayit.Yol3 + "</td>");
                    htmlTable.Append("<td>" + kayit.Yol4 + "</td>");
                    htmlTable.Append("<td>" + kayit.Yol5 + "</td>");
                    htmlTable.Append("<td>" + kayit.Yol6 + "</td>");
                    htmlTable.Append("</tr>");

                }
            }
            ph_sdm_izlenebilirlik.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }
        private void uretim_izlenebilirlik_data(int dokumno = 0)
        {

            StringBuilder htmlTable = new StringBuilder();
            kayitlar_urt = db.uretim_izlenebilirlik_data_read(dokumno);
            if (kayitlar_urt[0].Id == 0)
            {
                // Kayit Bululnamadı
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan=\"12\">" + kayitlar_urt[0].Vrd + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {

                foreach (var kayit in kayitlar_urt)
                {

                    htmlTable.Append("<tr>");

                    htmlTable.Append("<td>" + kayit.Boy + "</td>");
                    htmlTable.Append("<td>" + kayit.Ebat + "</td>");
                    htmlTable.Append("<td >" + kayit.Celik_cinsi + "</td>");
                    htmlTable.Append("<td>" + kayit.Std + "</td>");
                    htmlTable.Append("<td>" + kayit.Stddisi + "</td>");

                    htmlTable.Append("</tr>");

                }


                ph_uretim_izlenebilirlik.Controls.Add(new Literal { Text = htmlTable.ToString() });
            }
        }
        private void tavfrn_izlenebilirlik_data(int dokumno = 0)
        {

            StringBuilder htmlTable = new StringBuilder();
            kayitlar_tavfrn = db.tavfrn_izlenebilirlik_data_read(dokumno);
            if (kayitlar_tavfrn[0].Id == 0)
            {
                // Kayit Bululnamadı
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan=\"7\">" + kayitlar_tavfrn[0].Vrd + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {

                foreach (var kayit in kayitlar_tavfrn)
                {

                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td>" + kayit.Yil + "</td>");
                    htmlTable.Append("<td>" + kayit.Sarjtipi + "</td>");
                    htmlTable.Append("<td>" + kayit.Cikis_tarihi + "</td>");
                    htmlTable.Append("<td >" + kayit.Giris_saati + "</td>");
                    htmlTable.Append("<td>" + kayit.Cikis_saati + "</td>");
                    htmlTable.Append("<td>" + kayit.Celik_cinsi + "</td>");
                    htmlTable.Append("<td>" + kayit.Kutuk_sayisi + "</td>");

                    htmlTable.Append("</tr>");

                }
            }
            ph_tavfrn_izlenebilirlik.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }

        private void filmasin_sevk_izlenebilirlik_data(int dokumno = 0)
        {

            StringBuilder htmlTable = new StringBuilder();
            kayitlar_filmasin_sevk = db.filmasin_sevk_izlenebilirlik_data_read(dokumno);


            foreach (var kayit in kayitlar_filmasin_sevk)
            {

                htmlTable.Append("<tr>");
                htmlTable.Append("<td>" + kayit.Celik_cinsi + "</td>");
                htmlTable.Append("<td>" + kayit.Ebat + "</td>");
                htmlTable.Append("<td>" + kayit.Boy + "</td>");
                htmlTable.Append("<td >" + kayit.Kutuk_sayisi + "</td>");

                htmlTable.Append("</tr>");

            }
            ph_filmasin_sevk_kutuk.Controls.Add(new Literal { Text = htmlTable.ToString() });

        }
        private void firindan_dusmus_izlenebilirlik_data(int dokumno = 0)
        {

            StringBuilder htmlTable = new StringBuilder();
            kayitlar_frndan_dusmus = db.firindan_dusmus_izlenebilirlik_data_read(dokumno);
            if (kayitlar_frndan_dusmus[0].Id == 0)
            {
                // Kayit Bululnamadı
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan=\"6\">" + kayitlar_frndan_dusmus[0].Vrd + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {

                foreach (var kayit in kayitlar_frndan_dusmus)
                {
                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td>" + kayit.Cikis_tarihi + "</td>");
                    htmlTable.Append("<td>" + kayit.Celik_cinsi + "</td>");
                    htmlTable.Append("<td>" + kayit.Kutuk_sayisi + "</td>");
                    //htmlTable.Append("<td>" + kayit.Giris_saati + "</td>");
                    //htmlTable.Append("<td>" + kayit.Cikis_saati + "</td>");
                    htmlTable.Append("</tr>");

                }

            }
            ph_firindan_dusmus.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }
        private void tavfrn_sicaklik_izlenebilirlik_data(int dokumno = 0)
        {

            StringBuilder htmlTable = new StringBuilder();
            kayitlar_tavfrn_sicaklik = db.tavfrn_sicaklik_izlenebilirlik_data_read(dokumno);
            if (kayitlar_tavfrn_sicaklik[0].Id == 0)
            {
                // Kayit Bululnamadı
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan=\"11\">" + kayitlar_tavfrn_sicaklik[0].Vrd + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var kayit in kayitlar_tavfrn_sicaklik)
                {

                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td>" + kayit.Dokum_no + "</td>");
                    htmlTable.Append("<td>" + kayit.Bolge4 + "</td>");
                    htmlTable.Append("<td>" + kayit.Bolge5 + "</td>");
                    htmlTable.Append("<td>" + kayit.Bolge6 + "</td>");
                    htmlTable.Append("<td  Style=\"text-align:center\">" + kayit.Kutuk_sicaklik + "</td>");
                    htmlTable.Append("<td>" + kayit.Ebat + "</td>");
                    htmlTable.Append("<td>" + kayit.Boy + "</td>");
                    htmlTable.Append("<td>" + kayit.Celik_cinsi + "</td>");
                    htmlTable.Append("</tr>");

                }
            }
            ph_tavfrn_sicaklik.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }
        private void fizik_izlenebilirlik_data(int dokumno = 0)
        {

            StringBuilder htmlTable = new StringBuilder();
            kayitlar_fizik = db.fizik_izlenebilirlik_data_read(dokumno);
            if (kayitlar_fizik[0].Id == 0)
            {
                // Kayit Bululnamadı
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan=\"10\">" + kayitlar_fizik[0].Vrd + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {

                foreach (var kayit in kayitlar_fizik)
                {

                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td>" + kayit.Dokum_no + "</td>");
                    htmlTable.Append("<td>" + kayit.Cap + "</td>");
                    htmlTable.Append("<td>" + kayit.Akma + "</td>");
                    htmlTable.Append("<td>" + kayit.Cekme + "</td>");
                    htmlTable.Append("<td>" + kayit.Uzama + "</td>");
                    htmlTable.Append("<td  Style=\"text-align:center\"> " + kayit.Cekme_akma + "</td>");
                    htmlTable.Append("<td>" + kayit.Agt + "</td>");
                    htmlTable.Append("<td>" + kayit.Bend + "</td>");
                    htmlTable.Append("<td>" + kayit.Rbend + "</td>");
                    htmlTable.Append("</tr>");
                }
            }
            ph_fizik_izlenebilirlik.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }
        private void tempcore_izlenebilirlik_data(int dokumno = 0)
        {

            StringBuilder htmlTable = new StringBuilder();
            kayitlar_tempcore = db.tempcore_izlenebilirlik_data_read(dokumno);
            if (kayitlar_tempcore[0].Id == 0)
            {
                // Kayit Bululnamadı
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan=\"17\">" + kayitlar_tempcore[0].Vrd + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {

                foreach (var kayit in kayitlar_tempcore)
                {

                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td>" + kayit.Dokum_no + "</td>");
                    htmlTable.Append("<td>" + kayit.Debi_a + "</td>");
                    htmlTable.Append("<td>" + kayit.Debi_b + "</td>");
                    htmlTable.Append("<td>" + kayit.Debi_c + "</td>");
                    htmlTable.Append("<td>" + kayit.Debi_d + "</td>");
                    htmlTable.Append("<td>" + kayit.Mamulkalite + "</td>");
                    htmlTable.Append("<td>" + kayit.Cap + "</td>");
                    htmlTable.Append("<td>" + kayit.Nozulcapi + "</td>");
                    htmlTable.Append("<td>" + kayit.Hiz + "</td>");
                    htmlTable.Append("<td  Style=\"text-align:center\"> " + kayit.Pompasayisi + "</td>");
                    htmlTable.Append("<td  Style=\"text-align:center\"> " + kayit.Pompabasinci + "</td>");
                    htmlTable.Append("</tr>");

                }
            }
            ph_tempcore_izlenebilirlik.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }
        private void toplam_hurda_izlenebilirlik_data(int dokumno = 0)
        {

            StringBuilder htmlTable = new StringBuilder();
            kayitlar_hurda_toplam = db.toplam_hurda_izlenebilirlik_data_read(dokumno);
            if (kayitlar_hurda_toplam[0].Id == 0)
            {
                // Kayit Bululnamadı
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan=\"2\">" + kayitlar_hurda_toplam[0].Vrd + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {

                foreach (var kayit in kayitlar_hurda_toplam)
                {

                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td Style=\"text-align:center\">" + kayit.Toplam_srj + "</td>");

                    htmlTable.Append("</tr>");

                }

            }
            ph_toplam_hurda.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }


        private void haddahane_istif_izlenebilirlik_data(int dokumno = 0)
        {

            StringBuilder htmlTable = new StringBuilder();
            kayitlar_istif = db.haddahane_istif_izlenebilirlik_data_read(dokumno);
            if (kayitlar_istif[0].Id == 0)
            {
                // Kayit Bululnamadı
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan=\"5\">" + kayitlar_istif[0].Vrd + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {

                foreach (var kayit in kayitlar_istif)
                {
                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td>" + kayit.Stok_yeri + "</td>");
                    htmlTable.Append("<td>" + kayit.Istif_yeri + "</td>");
                    htmlTable.Append("<td>" + kayit.Kutuk_sayisi + "</td>");
                    htmlTable.Append("<td>" + kayit.Celik_cinsi + "</td>");
                    htmlTable.Append("</tr>");

                }
            }
            ph_haddahane_istif_izlenebilirlik.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }
        private void celikhane_istif_izlenebilirlik_data(int dokum_no = 0)
        {
            StringBuilder htmlTable = new StringBuilder();
            kayitlar_istif = db.celikhane_istif_izlenebilirlik_data_read(dokum_no);
            if (kayitlar_istif[0].Id == 0)
            {
                // Kayit Bululnamadı
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan=\"5\">" + kayitlar_istif[0].Vrd + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var kayit in kayitlar_istif)
                {
                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td>" + kayit.Stok_yeri + "</td>");
                    htmlTable.Append("<td>" + kayit.Istif_yeri + "</td>");
                    htmlTable.Append("<td>" + kayit.Kutuk_sayisi + "</td>");
                    htmlTable.Append("<td>" + kayit.Celik_cinsi + "</td>");
                    htmlTable.Append("</tr>");

                }

            }
            ph_celikhane_istif_izlenebilirlik.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }


        protected void tx_dokum_no_TextChanged(object sender, EventArgs e)
        {
            degerleri_getir();

        }

        protected void btn_Listele_Click(object sender, EventArgs e)
        {
            degerleri_getir();
        }
        protected void degerleri_getir()
        {
            int dokum_no = 0;
            if (tx_dokum_no.Text != "")
            {
                dokum_no = Convert.ToInt32(tx_dokum_no.Text);
                db.Connect();
                tarihyaz(dokum_no);
                ao_izlenebilirlik_data(dokum_no);
                po_izlenebilirlik_data(dokum_no);
                sdm_izlenebilirlik_data(dokum_no);
                uretim_izlenebilirlik_data(dokum_no);
                tavfrn_izlenebilirlik_data(dokum_no);
                firindan_dusmus_izlenebilirlik_data(dokum_no);
                tavfrn_sicaklik_izlenebilirlik_data(dokum_no);
                filmasin_sevk_izlenebilirlik_data(dokum_no);
                fizik_izlenebilirlik_data(dokum_no);
                tempcore_izlenebilirlik_data(dokum_no);
                toplam_hurda_izlenebilirlik_data(dokum_no);
                haddahane_istif_izlenebilirlik_data(dokum_no);
                celikhane_istif_izlenebilirlik_data(dokum_no);
                db.Disconnect();
            }
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../../Default2.aspx");
        }


    }
}