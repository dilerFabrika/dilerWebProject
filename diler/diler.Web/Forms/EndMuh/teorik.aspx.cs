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
    public partial class teorik : System.Web.UI.Page
    {

        TeorikTolerans_db db = new TeorikTolerans_db();
        List<Teorik_tolerans_bilgiler> kayitlar = new List<Teorik_tolerans_bilgiler>();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btn_listele_Click(object sender, EventArgs e)
        {
            string siparisNo = txt_siparisNo.Text;
            db.Connect();
            db.as400_connect();
            siparisBilgisiListele(siparisNo);
            db.Disconnect();
            db.as400_Disconnect();

        }
        private void siparisBilgisiListele(string siparisNo)
        {

            StringBuilder htmlTable = new StringBuilder();
            kayitlar = db.siparisBilgisiGetir(siparisNo);
            if (kayitlar[0].Id == 0)
            {
                // Kayit Bulunamadı
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan=\"11\">" + kayitlar[0].Lc + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {

                foreach (var kayit in kayitlar)
                {

                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td>" + kayit.SiparisNo + "</td>");
                    htmlTable.Append("<td>" + kayit.Lot + "</td>");
                    htmlTable.Append("<td>" + kayit.Cap + "</td>");
                    htmlTable.Append("<td>" + kayit.Boy + "</td>");
                    htmlTable.Append("<td>" + kayit.CubukSayisi + "</td>");

                    if (kayit.Id == 2)
                    {
                        htmlTable.Append("<td style=\"font-weight: bold; color:#272626;\">" + kayit.TeorikAgirlik + "</td>");
                        htmlTable.Append("<td style=\"font-weight: bold; color:#272626;\">" + kayit.Lc + "</td>");
                        htmlTable.Append("<td style=\"background-color:#aeeafe; font-weight: bold; color:#272626;\">" + kayit.Renk + "</td>");
                        htmlTable.Append("<td style=\"background-color:#aeeafe; font-weight: bold; color:#272626;\">" + kayit.PaketSayisi + "</td>");
                        htmlTable.Append("<td style=\"background-color:#aeeafe; font-weight: bold; color:#272626;\">" + kayit.KantarAgirligi + "</td>");
                        htmlTable.Append("<td style=\"background-color:#aeeafe; font-weight: bold; color:#272626;\">" + kayit.TeorikPaketAgirligi + "</td>");
                        htmlTable.Append("<td style=\"background-color:#aeeafe; font-weight: bold; color:#f01616;\">" + kayit.TeorikHaddelemeTolerans + "</td>");
                        //aeeafemavi
                    }
                    else
                    {

                        htmlTable.Append("<td>" + kayit.TeorikAgirlik + "</td>");
                        htmlTable.Append("<td>" + kayit.Lc + "</td>");
                        htmlTable.Append("<td>" + kayit.Renk + "</td>");
                        htmlTable.Append("<td>" + kayit.PaketSayisi + "</td>");
                        htmlTable.Append("<td>" + kayit.KantarAgirligi + "</td>");
                        htmlTable.Append("<td>" + kayit.TeorikPaketAgirligi + "</td>");
                        htmlTable.Append("<td>" + kayit.TeorikHaddelemeTolerans + "</td>");
                    }


                    htmlTable.Append("</tr>");

                }
            }
            ph_teorik_tolerans.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }
        protected void Home_image_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../../Default2.aspx");
        }
    }
}