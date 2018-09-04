using diler.Dal;
using diler.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace diler.Web.Forms.Haddehane
{
    public partial class istiften_soguk_sarj : System.Web.UI.Page
    {
        Istiften_soguksarj_db db = new Istiften_soguksarj_db();
        List<Istif_bilgileri> kayitlar = new List<Istif_bilgileri>();
        List<Istif_bilgileri> kayitlar_istif_Ozet = new List<Istif_bilgileri>();

        [System.Web.Services.WebMethod]
        public static int soguksarja_kutuk_gonder(string dokum_no, string istif_adet, string istif_sirano, string istif_yeri, string kalite, string boy, string ebat,string siparis_no)
        {

            Istiften_soguksarj_db db = new Istiften_soguksarj_db();
            db.Connect();
            string sent_billet = db.send_billet(dokum_no, istif_adet, istif_sirano, istif_yeri, kalite, boy, ebat,siparis_no);
            db.Disconnect();
            if (sent_billet == "ATILAMAZ")
            {
                return 0;
            }
            else
            {

                return 1;
            }


        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Cmb_stok_yeri_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cmb_istif_yeri.Items.Clear();
            if (Cmb_stok_yeri.SelectedItem.ToString() != "Stok yeri seçiniz")
            {

                db.Connect();
                List<string> veriler = new List<string>();
                string secilen_stok_yeri = Cmb_stok_yeri.SelectedItem.ToString();
                veriler = db.Cmb_istif_yeri_doldur(secilen_stok_yeri);
                foreach (var istifyeri in veriler)
                {
                    Cmb_istif_yeri.Items.Add(istifyeri);
                }
                db.Disconnect();
            }

        }

        protected void btn_Listele_Click(object sender, EventArgs e)
        {
            if (Cmb_istif_yeri.Text != "")
            {
                string stok_yeri = Cmb_stok_yeri.SelectedItem.ToString();
                string istif_yeri = Cmb_istif_yeri.SelectedItem.ToString();

                string istifyeri = istif_yeri.Substring(0, 3).Replace("H", "").Replace("C", "").Trim();
                db.Connect();
                istif_takip_Listele(stok_yeri, istifyeri);
                istif_takip_Ozet_listele(stok_yeri, istifyeri);
                aciklama_yazisi(stok_yeri, istifyeri);
                db.Disconnect();

            }

        }
        private void aciklama_yazisi(string stok_yeri, string istifyeri)
        {
            string aciklama1 = db.aciklama1(stok_yeri, istifyeri);
            string aciklama2 = db.aciklama2(stok_yeri, istifyeri);
            string aciklama3 = db.aciklama3(stok_yeri, istifyeri);
            txt_genel_aciklama.Text = aciklama1;
            txt_genel_aciklama2.Text = aciklama2;
            txt_genel_aciklama3.Text = aciklama3;
        }

        private void istif_takip_Ozet_listele(string stok_yeri, string istif_yeri)
        {

            StringBuilder htmlTable = new StringBuilder();
            kayitlar_istif_Ozet = db.istif_takip_ozet_listele_data_read(stok_yeri, istif_yeri);
            if (kayitlar_istif_Ozet[0].Id == 0)
            {
                // Kayit Bululnamadı
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan=\"11\">" + kayitlar_istif_Ozet[0].Lot + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {

                foreach (var kayit in kayitlar_istif_Ozet)
                {

                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td>" + kayit.Istif_yeri + "</td>");
                    htmlTable.Append("<td>" + kayit.Istif_adet + "</td>");
                    htmlTable.Append("<td> " + kayit.Ebat + "</td>");
                    htmlTable.Append("<td>" + kayit.Celik_cinsi + "</td>");
                    htmlTable.Append("<td> " + kayit.Boy + "</td>");
                    htmlTable.Append("<td> " + kayit.Celik_cinsi_orj + "</td>");
                    htmlTable.Append("</tr>");

                }
            }
            ph_istif_Ozet.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }

        private void istif_takip_Listele(string stok_yeri, string istif_yeri)
        {
            StringBuilder htmlTable = new StringBuilder();
            kayitlar = db.istif_takip_listele_data_read(stok_yeri, istif_yeri);
            if (kayitlar[0].Id == 0)
            {
                // Kayit Bulunamadı
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan=\"13\">" + kayitlar[0].Lot + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {

                foreach (var kayit in kayitlar)
                {

                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td>" + kayit.Istif_sirano + "</td>");
                    htmlTable.Append("<td>" + kayit.Dokum_tarihi + "</td>");
                    htmlTable.Append("<td> " + kayit.Dokum_no + "</td>");
                    htmlTable.Append("<td> " + kayit.Stok_yeri + "</td>");
                    htmlTable.Append("<td> " + kayit.Istif_yeri + "</td>");
                    htmlTable.Append("<td>" + kayit.Istif_adet + "</td>");
                    htmlTable.Append("<td>" + kayit.Celik_cinsi + "</td>");
                    htmlTable.Append("<td> " + kayit.Boy + "</td>");
                    htmlTable.Append("<td> " + kayit.Ebat + "</td>");
                    htmlTable.Append("<td> " + kayit.Sipno + "</td>");
                    htmlTable.Append("<td> " + kayit.Lot + " </td>");
                    htmlTable.Append("<td style=\"padding-top: 6px;\" ><a \"style=\"color: #252525;\" title=\"Gönder\" class='ktk_gonder';\"> <i  style=\"font-size: 20px; color: #252525;\" class=\"fa fa-check-square\"></i></a></td>");
                    htmlTable.Append("</tr>");

                }

            }
            ph_istif_takip.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../../Default2.aspx");
        }
    }
}