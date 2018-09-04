using diler.Dal;
using diler.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace diler.Web.Forms.EndMuh
{
    public partial class as400_tanimlar : System.Web.UI.Page
    {
        List<Tanim_bilgileri> kayitlar = new List<Tanim_bilgileri>();
        Tanim_db db = new Tanim_db();


        [System.Web.Services.WebMethod]
        public static int as400_tanim_sil(string as400_kod, string as400_isim, string pc_isim, string tanim_tipi)
        {

            List<Tanim_bilgileri> kayitlar = new List<Tanim_bilgileri>();
            Tanim_db db = new Tanim_db();
            db.Connect();
            string tanim_sil = db.tanim_sil(as400_kod, as400_isim, pc_isim, tanim_tipi);
            db.Disconnect();

            return 1;



        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btn_listele_Click(object sender, EventArgs e)
        {
            string tanim_tipi = cmb_tanimtipi.Text;
            as400_tanimlari_listele(tanim_tipi);
            txt_as400_isim.Text = "";
            txt_as400_kod.Text = "";
            txt_pcKod.Text = "";
            txt_pcİsim.Text = "";

        }

        private void as400_tanimlari_listele(string tanim_tipi)
        {
            StringBuilder htmlTable = new StringBuilder();
            db.Connect();
            kayitlar = db.as400_tanimlari_listele(tanim_tipi);
            db.Disconnect();
            if (kayitlar[0].Id == 0)
            {
                // Kayit Bulunamadı
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan=\"6\">" + kayitlar[0].Tanim_tipi + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {

                foreach (var kayit in kayitlar)
                {
                    htmlTable.Append("<tr class='tanim_tablosu'>");
                    htmlTable.Append("<td  style=\"text-align:center\"> " + kayit.As400kod + "</td>");
                    htmlTable.Append("<td  style=\"text-align:center\"> " + kayit.As400_isim + "</td>");
                    htmlTable.Append("<td  style=\"text-align:center\"> " + kayit.Pc_kod + "</td>");
                    htmlTable.Append("<td  style=\"text-align:center\"> " + kayit.Pc_isim + "</td>");
                    htmlTable.Append("<td style=\"padding-top:2px;\" ><a \"style=\"color: #252525;\" title=\"Sil\" class='tanim_sil';\"> <i  style=\"font-size: 20px; color: #252525;\" class=\"fa fa-trash\"></i></a></td>");
                    htmlTable.Append("</tr>");

                }
            }
            ph_tanim_listesi.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }

        protected void btn_yeni_tanim_ekle_Click(object sender, EventArgs e)
        {
            string as400_kod = txt_as400_kod.Text;
            string as400_isim = txt_as400_isim.Text;
            string pc_kod = txt_pcKod.Text;
            string pc_isim = txt_pcİsim.Text;
            string tanim_tipi = cmb_tanimtipi.Text;
            db.Connect();
            if (as400_kod != "" && as400_isim != "" && pc_isim != "")
            {

                int as400_tanim_Insert = db.as400_tanim_ekle(as400_kod, as400_isim, pc_kod, pc_isim, tanim_tipi);

                Response.Write("<script language='javascript'>alert('AS400 tanımı başarıyla kaydedildi.');</script>");

            }
            else
            {

                Response.Write("<script language='javascript'>alert('LÜTFEN TÜM ALANLARI DOLDURUNUZ !');</script>");
            }
            as400_tanimlari_listele(tanim_tipi);
            db.Disconnect();

        }

        //protected void Btn_tanim_guncelle_Click(object sender, EventArgs e)
        //{
        //    string as400_kod = txt_as400_kod.Text;
        //    string as400_isim = txt_as400_isim.Text;
        //    string pc_kod = txt_pcKod.Text;
        //    string pc_isim = txt_pcİsim.Text;
        //    string tanim_tipi = cmb_tanimtipi.Text;

        //    if (as400_kod != "" && as400_isim != "" && pc_isim != "")
        //    {
        //        db.Connect();
        //        int as400_tanim_update = db.as400_tanim_guncelle(as400_kod, as400_isim, pc_kod, pc_isim, tanim_tipi);
        //        as400_tanimlari_listele(tanim_tipi);
        //        db.Disconnect();

        //        Response.Write("<script language='javascript'>alert('AS400 tanımı başarıyla güncellendi.');</script>");         
        //    }
        //    else
        //    {

        //        Response.Write("<script language='javascript'>alert('GÜNCELLEMEK İSTEDİĞİNİZ ALANLARI DOLDURUNUZ !');</script>");
        //    }


        //}


        protected void Image_home_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../../Default2.aspx");
        }
    }
}