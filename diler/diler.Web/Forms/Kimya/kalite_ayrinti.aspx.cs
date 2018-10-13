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
    public partial class kalite_ayrinti : System.Web.UI.Page
    {

        Kalite_ayrinti_db db = new Kalite_ayrinti_db();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {


            }

        }
        protected void Home_image_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../../Default2.aspx");
        }
        protected void Img_ok_Click(object sender, ImageClickEventArgs e)
        {
            string tarih1 = txt_tarih1.Text;
            string tarih2 = txt_tarih2.Text;
            string tarih1_ = tarih1.Replace("-", "");//veritabanindaki kayit bicimi
            string tarih2_ = tarih2.Replace("-", "");//veritabanindaki kayit bicimi
            if (tarih1 != "" && tarih2 != "")
            {
                cmb_kalite.Items.Clear();
                db.Connect();
                List<string> kayitlar = new List<string>();
                kayitlar = db.kalite_comboDoldur(tarih1_, tarih2_);
                cmb_kalite.Items.Add("Tümü");
                foreach (var kalite in kayitlar)
                {
                    cmb_kalite.Items.Add(kalite);
                }
                db.Disconnect();
            }
        }
        private void ark_ocak_genel_liste()
        {

            List<R_ark_ocagi_genel> kayitlar = new List<R_ark_ocagi_genel>();
            string tarih1 = txt_tarih1.Text;
            string tarih2 = txt_tarih2.Text;
            string kalite = cmb_kalite.Text;
            string dokum_no = txt_dokum_no.Text;
            string sip_no = txt_sipno.Text;
            string dokum_tipi = cmb_dokumtipi.Text;
            string tarih1_ = tarih1.Replace("-", "");//veritabanindaki kayit bicimi
            string tarih2_ = tarih2.Replace("-", "");//veritabanindaki kayit bicimi
            if (tarih1 != "" && tarih2 != "")
            {
                db.Connect();
                kayitlar = db.ark_ocagi_genel_data_read(tarih1_, tarih2_, kalite, dokum_no, sip_no, dokum_tipi);
                db.Disconnect();

                StringBuilder htmlTable = new StringBuilder();
                if (kayitlar[0].Id == 0)
                {
                    // Kayit Bululnamadı
                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td colspan=\"21\">" + kayitlar[0].Kalite + "</td>");
                    htmlTable.Append("</tr>");
                }
                else
                {

                    foreach (var kayit in kayitlar)
                    {
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Tarih + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\"> " + kayit.Dokum_no + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\"> " + kayit.Kalite + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\"> " + kayit.Dokum_tip + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Sip_no + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Dokum_baslangic_saati + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\"> " + kayit.Devirme_saati + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\"> " + kayit.Dokum_suresi + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\"> " + kayit.Canak_dokum_sayisi + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Kapak_dokum_sayisi + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Yurek_dokum_sayisi + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\"> " + kayit.Rbt_delik_sayisi + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\"> " + kayit.Yurek_no + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\"> " + kayit.Ted_al_saati + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Ted_tirnak_acma_saati + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Ted_tb_sure + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\"> " + kayit.Ao_enerjili_sure + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\"> " + kayit.Ao_enerjisiz_sure + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\"> " + kayit.Devirme_sicaklik + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\"> " + kayit.Eletrodkodu_ao + "</td>");
                        htmlTable.Append("</tr>");

                    }
                }

                ph_arkocagi_genel.Controls.Clear();
                ph_arkocagi_genel.Controls.Add(new Literal { Text = htmlTable.ToString() });
            }

        }
        private void pota_ocak_genel_liste()
        {


            List<R_pota_ocagi_genel> kayitlar = new List<R_pota_ocagi_genel>();

            string tarih1 = txt_tarih1.Text;
            string tarih2 = txt_tarih2.Text;
            string kalite = cmb_kalite.Text;
            string dokum_no = txt_dokum_no.Text;
            string sip_no = txt_sipno.Text;
            string dokum_tipi = cmb_dokumtipi.Text;
            string tarih1_ = tarih1.Replace("-", "");//veritabanindaki kayit bicimi
            string tarih2_ = tarih2.Replace("-", "");//veritabanindaki kayit bicimi
            if (tarih1 != "" && tarih2 != "")
            {
                db.Connect();
                kayitlar = db.pota_ocagi_genel_data_read(tarih1_, tarih2_, kalite, dokum_no, sip_no, dokum_tipi);
                db.Disconnect();
                StringBuilder htmlTable = new StringBuilder();
                if (kayitlar[0].Id == 0)
                {
                    // Kayit Bululnamadı
                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td colspan=\"21\">" + kayitlar[0].Kalite + "</td>");
                    htmlTable.Append("</tr>");
                }
                else
                {

                    foreach (var kayit in kayitlar)
                    {
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Tarih + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\"> " + kayit.Dokum_no + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\"> " + kayit.Kalite + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\"> " + kayit.Dokum_tip + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Sip_no + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Po_giris_saati + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\"> " + kayit.Po_cikis_saati + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\"> " + kayit.Po_brut_sure + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\"> " + kayit.Po_enerjili_sure + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Po_power_off_time + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Po_giris_sicaklik + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\"> " + kayit.Po_cikis_sicaklik + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\"> " + kayit.Po_sivi_celik_son + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\"> " + kayit.Po_bos_pota_tonaj + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Po_sivi_celik + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Po_ekfaz1 + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\"> " + kayit.Po_ekfaz2 + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\"> " + kayit.Po_ekfaz3 + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\"> " + kayit.Po_genel_aciklama + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\"> " + kayit.Yeniden_isitma_giris + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\"> " + kayit.Yeniden_isitma_cikis + "</td>");

                        htmlTable.Append("</tr>");

                    }
                }

                ph_potaocagi_genel.Controls.Clear();
                ph_potaocagi_genel.Controls.Add(new Literal { Text = htmlTable.ToString() });
            }
        }
        private void sdm_genel_liste()
        {

            List<R_sdm_genel> kayitlar = new List<R_sdm_genel>();

            string tarih1 = txt_tarih1.Text;
            string tarih2 = txt_tarih2.Text;
            string kalite = cmb_kalite.Text;
            string dokum_no = txt_dokum_no.Text;
            string sip_no = txt_sipno.Text;
            string dokum_tipi = cmb_dokumtipi.Text;
            string tarih1_ = tarih1.Replace("-", "");//veritabanindaki kayit bicimi
            string tarih2_ = tarih2.Replace("-", "");//veritabanindaki kayit bicimi
            if (tarih1 != "" && tarih2 != "")
            {
                db.Connect();
                kayitlar = db.sdm_genel_data_read(tarih1_, tarih2_, kalite, dokum_no, sip_no, dokum_tipi);
                db.Disconnect();
                StringBuilder htmlTable = new StringBuilder();
                if (kayitlar[0].Id == 0)
                {
                    // Kayit Bululnamadı
                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td colspan=\"23\">" + kayitlar[0].Kalite + "</td>");
                    htmlTable.Append("</tr>");
                }
                else
                {

                    foreach (var kayit in kayitlar)
                    {
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Tarih + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Dokum_no + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Kalite + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Dokum_tip + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Sip_no + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Kalip_dokum_sayisi1 + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Kalip_dokum_sayisi2 + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Kalip_dokum_sayisi3 + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Kalip_dokum_sayisi4 + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Kalip_dokum_sayisi5 + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Kalip_dokum_sayisi6 + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Tandis_baslangic_sicaklik + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Tandis_orta_sicaklik + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Tandis_no + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Tandis_bindirme_sayisi + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Pota_acma_saati + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Pota_kapatma_saati + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Net_sure + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Pota_plaka_no + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Pota_durumu + "</td>");
                        htmlTable.Append("</tr>");

                    }
                }

                ph_sdm_genel.Controls.Clear();
                ph_sdm_genel.Controls.Add(new Literal { Text = htmlTable.ToString() });
            }
        }
        private void enerji_liste()
        {
            List<R_enerji> kayitlar = new List<R_enerji>();
            string tarih1 = txt_tarih1.Text;
            string tarih2 = txt_tarih2.Text;
            string kalite = cmb_kalite.Text;
            string dokum_no = txt_dokum_no.Text;
            string sip_no = txt_sipno.Text;
            string dokum_tipi = cmb_dokumtipi.Text;
            string tarih1_ = tarih1.Replace("-", "");//veritabanindaki kayit bicimi
            string tarih2_ = tarih2.Replace("-", "");//veritabanindaki kayit bicimi
            if (tarih1 != "" && tarih2 != "")
            {
                db.Connect();
                kayitlar = db.enerji_data_read(tarih1_, tarih2_, kalite, dokum_no, sip_no, dokum_tipi);
                db.Disconnect();
                StringBuilder htmlTable = new StringBuilder();
                if (kayitlar[0].Id == 0)
                {
                    // Kayit Bululnamadı
                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td colspan=\"21\">" + kayitlar[0].Kalite + "</td>");
                    htmlTable.Append("</tr>");
                }
                else
                {

                    foreach (var kayit in kayitlar)
                    {
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Tarih + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Dokum_no + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Kalite + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Dokum_tip + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Sip_no + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Ao_enerji + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Ao_tirnak_kapatma_enerjisi + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Brl_dgaz + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Rcb_brl_dgaz + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Pc_dgaz + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Po_enerji + "</td>");
                        htmlTable.Append("</tr>");

                    }
                }

                ph_enerji.Controls.Clear();
                ph_enerji.Controls.Add(new Literal { Text = htmlTable.ToString() });
            }
        }
        private void sarf_liste()
        {

            List<R_sarfmalzeme> kayitlar = new List<R_sarfmalzeme>();

            string tarih1 = txt_tarih1.Text;
            string tarih2 = txt_tarih2.Text;
            string kalite = cmb_kalite.Text;
            string dokum_no = txt_dokum_no.Text;
            string sip_no = txt_sipno.Text;
            string dokum_tipi = cmb_dokumtipi.Text;
            string tarih1_ = tarih1.Replace("-", "");//veritabanindaki kayit bicimi
            string tarih2_ = tarih2.Replace("-", "");//veritabanindaki kayit bicimi
            if (tarih1 != "" && tarih2 != "")
            {
                db.Connect();
                kayitlar = db.sarf_malzeme_data_read(tarih1_, tarih2_, kalite, dokum_no, sip_no, dokum_tipi);
                db.Disconnect();
                StringBuilder htmlTable = new StringBuilder();
                if (kayitlar[0].Id == 0)
                {
                    // Kayit Bululnamadı
                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td colspan=\"29\">" + kayitlar[0].Kalite + "</td>");
                    htmlTable.Append("</tr>");
                }
                else
                {
                    foreach (var kayit in kayitlar)
                    {
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Tarih + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Dokum_no + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Kalite + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Dokum_tip + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Sip_no + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Ladle_shroud_adet + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Ladle_shroud_gasket_adet + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Tundish_c_m_p_asidik_kg + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Tundish_c_m_p_bazik_kg + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Tundish_c_m_p_w_kg + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Natural_gas_m3 + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Ses_shroud_adet + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Scorialit_sph_c_411_81_e_kg + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Scorialit_sph_c_176_als_9_kg + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Scorialit_sph_c_189_v_3_kg + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Ramag_92p_ramming_mass_kg + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Melting_gasket_c52_adet + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Scorialit_sph_c_189_gm_23_kg + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Scorialit_sph_c_189_e_3_kg + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Sph_c_189_vv1 + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Brl_o2 + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Elti_o2 + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Rcb_ref_o2 + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Rcb_brl_o2 + "</td>");
                        htmlTable.Append("</tr>");

                    }
                }

                ph_sarfmalzeme.Controls.Clear();
                ph_sarfmalzeme.Controls.Add(new Literal { Text = htmlTable.ToString() });
            }
        }
        private void hurda_liste()
        {
            List<R_hurda> kayitlar = new List<R_hurda>();

            string tarih1 = txt_tarih1.Text;
            string tarih2 = txt_tarih2.Text;
            string kalite = cmb_kalite.Text;
            string dokum_no = txt_dokum_no.Text;
            string sip_no = txt_sipno.Text;
            string dokum_tipi = cmb_dokumtipi.Text;
            string tarih1_ = tarih1.Replace("-", "");//veritabanindaki kayit bicimi
            string tarih2_ = tarih2.Replace("-", "");//veritabanindaki kayit bicimi
            if (tarih1 != "" && tarih2 != "")
            {
                db.Connect();
                kayitlar = db.hurda_data_read(tarih1_, tarih2_, kalite, dokum_no, sip_no, dokum_tipi);
                db.Disconnect();
                StringBuilder htmlTable = new StringBuilder();
                if (kayitlar[0].Id == 0)
                {
                    // Kayit Bululnamadı
                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td colspan=\"21\">" + kayitlar[0].Kalite + "</td>");
                    htmlTable.Append("</tr>");
                }
                else
                {

                    foreach (var kayit in kayitlar)
                    {
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Tarih + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Dokum_no + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Kalite + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Dokum_tip + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Sip_no + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Degirmen + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Hms1 + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Hms2 + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Piyasa + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Hms1_2 + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Pik + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Elek + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Skal + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Hbi + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Talas + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Dkp + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Busheling + "</td>");
                        htmlTable.Append("</tr>");

                    }
                }

                ph_hurda.Controls.Clear();
                ph_hurda.Controls.Add(new Literal { Text = htmlTable.ToString() });
            }
        }
        private void ao_alyaj_liste()
        {
            List<R_ao_alyaj> kayitlar = new List<R_ao_alyaj>();

            string tarih1 = txt_tarih1.Text;
            string tarih2 = txt_tarih2.Text;
            string kalite = cmb_kalite.Text;
            string dokum_no = txt_dokum_no.Text;
            string sip_no = txt_sipno.Text;
            string dokum_tipi = cmb_dokumtipi.Text;
            string tarih1_ = tarih1.Replace("-", "");//veritabanindaki kayit bicimi
            string tarih2_ = tarih2.Replace("-", "");//veritabanindaki kayit bicimi
            if (tarih1 != "" && tarih2 != "")
            {
                db.Connect();
                kayitlar = db.ao_alyaj_data_read(tarih1_, tarih2_, kalite, dokum_no, sip_no, dokum_tipi);
                db.Disconnect();
                StringBuilder htmlTable = new StringBuilder();
                if (kayitlar[0].Id == 0)
                {
                    // Kayit Bululnamadı
                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td colspan=\"21\">" + kayitlar[0].Kalite + "</td>");
                    htmlTable.Append("</tr>");
                }
                else
                {

                    foreach (var kayit in kayitlar)
                    {
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Tarih + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Dokum_no + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Kalite + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Dokum_tip + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Sip_no + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Parca_kok + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Enjekte_kok_elti + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Enjekte_kok_panel + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Parca_kirec + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Enjekte_kirec + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Dev_al + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Dev_fesi65 + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Dev_fesi70 + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Dev_fesi75 + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Dev_fesimn60 + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Dev_fesimn65 + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Dev_fesimn70 + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Dev_femn + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Dev_femn_hcr + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Fesilowal_ao + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Femnlowc_ao + "</td>");
                        htmlTable.Append("</tr>");

                    }
                }

                ph_ao_alyaj.Controls.Clear();
                ph_ao_alyaj.Controls.Add(new Literal { Text = htmlTable.ToString() });
            }
        }
        private void po_alyaj_liste()
        {
            List<R_po_alyaj> kayitlar = new List<R_po_alyaj>();

            string tarih1 = txt_tarih1.Text;
            string tarih2 = txt_tarih2.Text;
            string kalite = cmb_kalite.Text;
            string dokum_no = txt_dokum_no.Text;
            string sip_no = txt_sipno.Text;
            string dokum_tipi = cmb_dokumtipi.Text;
            string tarih1_ = tarih1.Replace("-", "");//veritabanindaki kayit bicimi
            string tarih2_ = tarih2.Replace("-", "");//veritabanindaki kayit bicimi
            if (tarih1 != "" && tarih2 != "")
            {
                db.Connect();
                kayitlar = db.po_alyaj_data_read(tarih1_, tarih2_, kalite, dokum_no, sip_no, dokum_tipi);
                db.Disconnect();
                StringBuilder htmlTable = new StringBuilder();
                if (kayitlar[0].Id == 0)
                {
                    // Kayit Bululnamadı
                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td colspan=\"41\">" + kayitlar[0].Kalite + "</td>");
                    htmlTable.Append("</tr>");
                }
                else
                {

                    foreach (var kayit in kayitlar)
                    {
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Tarih + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Dokum_no + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Kalite + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Dokum_tip + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Sip_no + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.C + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Cao + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Fesi65 + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Fesi70 + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Fesi75 + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Dev_kirec + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Fesilowal_po + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Fesimn60 + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Fesimn65 + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Fesimn70 + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Fesimn6030 + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Femn + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Femnhcr + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Femnlowc_po + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Fev + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Al + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Al_granul + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Casi + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Caf2 + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Mgo + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Boksit + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Cafe + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Alwire + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Feti + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Dolamitik_kirec + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Siliskumu + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Cac2 + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Feb + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Kolamanit + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Fecr + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.S + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Fep + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Nb + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Ca_solid_tel + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Azotsuz_c + "</td>");
                        htmlTable.Append("<td style=\"text-align:center\">" + kayit.Al_curufu + "</td>");
                        htmlTable.Append("</tr>");

                    }
                }

                ph_po_alyaj.Controls.Clear();
                ph_po_alyaj.Controls.Add(new Literal { Text = htmlTable.ToString() });
            }
        }

        protected void ASPxCallbackPanel_ark_genel_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {

            if (e.Parameter == "ark_ocagi_genel_liste")
            {
                ark_ocak_genel_liste();

            }


        }
        protected void ASPxCallbackPanel_pota_genel_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {

            if (e.Parameter == "pota_ocagi_genel_liste")
            {
                pota_ocak_genel_liste();

            }


        }
        protected void ASPxCallbackPanel_sdm_genel_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {

            if (e.Parameter == "sdm_genel_liste")
            {
                sdm_genel_liste();

            }


        }
        protected void ASPxCallbackPanel_enerji_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {

            if (e.Parameter == "enerji_liste")
            {
                enerji_liste();

            }


        }
        protected void ASPxCallbackPanel_sarfmalzeme_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {

            if (e.Parameter == "sarf_liste")
            {
                sarf_liste();

            }
        }
        protected void ASPxCallbackPanel_hurda_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {

            if (e.Parameter == "hurda_liste")
            {
                hurda_liste();

            }
        }
        protected void ASPxCallbackPanel_ao_alyaj_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {

            if (e.Parameter == "ao_alyaj_liste")
            {
                ao_alyaj_liste();

            }
        }
        protected void ASPxCallbackPanel_po_alyaj_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {

            if (e.Parameter == "po_alyaj_liste")
            {
                po_alyaj_liste();

            }
        }

       

    }
}