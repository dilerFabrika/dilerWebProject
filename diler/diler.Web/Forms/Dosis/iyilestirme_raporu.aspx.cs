using diler.Dal;
using diler.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace diler.Web.Forms.Dosis
{
    public partial class iyilestirme_raporu : System.Web.UI.Page
    {
        Dosis_rapor_db db = new Dosis_rapor_db();
        List<Dosis_rapor_bilgileri> kayitlar = new List<Dosis_rapor_bilgileri>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                cmb_bolum.Items.Clear();
                cmb_kategori.Items.Clear();
                db.Connect();
                List<string> veriler_bolum = new List<string>();
                List<string> veriler_kategori = new List<string>();
                veriler_bolum = db.cmb_bolum_doldur();
                veriler_kategori = db.cmb_kategori_doldur();
                cmb_bolum.Items.Add("Tümü");
                cmb_kategori.Items.Add("Tümü");
                foreach (var bolum in veriler_bolum)
                {
                    cmb_bolum.Items.Add(bolum);
                }
                foreach (var kategori in veriler_kategori)
                {
                    cmb_kategori.Items.Add(kategori);
                }


                db.Disconnect();


            }

        }


        protected void btn_listele_Click(object sender, EventArgs e)
        {
            db.Connect();
            iyilestirme_no_getir();
            db.Disconnect();
            txt_iyilestirme_numarasi.Text = "";
            txt_konu.Text = "";
            txt_calisma_grubu.Text = "";
            txt_kaynak.Text = "";
            txt_problem_tanimi.Text = "";
            txt_hedef.Text = "";
            txt_yapilan_is.Text = "";
            txt_degerlendirme.Text = "";
            txt_calisma_baslangic.Text = "";
            txt_calisma_bitis.Text = "";
            txt_iyilestirme_kategori.Text = "";


        }

        private void iyilestirme_no_getir()
        {
            StringBuilder htmlTable = new StringBuilder();
            string bolum = cmb_bolum.Text;
            string kategori = cmb_kategori.Text;
            string yil = cmb_yil.Text;
            kayitlar = db.iyilestirme_no_raporu(yil, bolum, kategori);
            if (kayitlar[0].Rapor_id == 0)
            {
                // Kayit Bulunamadı
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan=\"3\">" + kayitlar[0].Iyilestirme_no + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var kayit in kayitlar)
                {
                    htmlTable.Append("<tr class='table_t'>");
                    htmlTable.Append("<td>" + kayit.Iyilestirme_no + "</td>");
                    htmlTable.Append("</tr>");

                }
            }
            ph_dosis_iyilestirme_no.Controls.Add(new Literal { Text = htmlTable.ToString() });

        }

        protected void Home_image_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../../Default2.aspx");
        }

        protected void btn_listele_iyilestirmeno_trigger_Click(object sender, EventArgs e)
        {
            db.Connect();
            iyilestirme_no_getir();
            iyilestirme_ayrinti();
            db.Disconnect();

        }

        private void iyilestirme_ayrinti()
        {
            StringBuilder htmlTable = new StringBuilder();
            string iyilestirme_no = txt_iyilestirme_no.Text;
            kayitlar = db.iyilestirme_no_ayrinti(iyilestirme_no);

            foreach (var kayit in kayitlar)
            {
                txt_iyilestirme_numarasi.Text = kayit.Iyilestirme_no;
                txt_konu.Text = kayit.Konu;
                txt_calisma_grubu.Text = kayit.Calisma_grubu;
                txt_kaynak.Text = kayit.Kaynaklar;
                txt_problem_tanimi.Text = kayit.Problem_tanimi;
                txt_hedef.Text = kayit.Hedef;
                txt_yapilan_is.Text = kayit.Yapilan_isler;
                txt_degerlendirme.Text = kayit.Degerlendirme;
                txt_calisma_baslangic.Text = kayit.Calisma_baslangic_tarihi;
                txt_calisma_bitis.Text = kayit.Calisma_bitis_tarihi;
                txt_iyilestirme_kategori.Text = kayit.Iyilestirme_kategori;



            }
        }

    }
}