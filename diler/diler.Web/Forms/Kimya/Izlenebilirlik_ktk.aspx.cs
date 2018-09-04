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
    public partial class Izlenebilirlik_ktk : System.Web.UI.Page
    {
        Izlenebilirlik_db db = new Izlenebilirlik_db();
        List<Izlenebilirlik_bilgileri> kayitlar = new List<Izlenebilirlik_bilgileri>();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void raporlari_getir(string baslangic_dokumnumarasi, string bitis_dokumnumarasi)
        {

            if (baslangic_dokumnumarasi != "" && bitis_dokumnumarasi != "")
            {
                int baslangic_dokumno = Convert.ToInt32(baslangic_dokumnumarasi);
                int bitis_dokumno = Convert.ToInt32(bitis_dokumnumarasi);
                dokumbazinda_kutuk_takip_ozet(baslangic_dokumno, bitis_dokumno);
            }
        }

        private void dokumbazinda_kutuk_takip_ozet(int baslangic_dokumno, int bitis_dokumno)
        {
            StringBuilder htmlTable = new StringBuilder();
            db.Connect();
            kayitlar = db.dokumbazinda_kutuk_takip_ozet_read(baslangic_dokumno, bitis_dokumno);
            db.Disconnect();
            if (kayitlar[0].Id == 0)
            {
                // Kayit Bululnamadı
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan=\"19\">" + kayitlar[0].Id + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var kayit in kayitlar)
                {
                    htmlTable.Append("<tr class='table_t'>");
                    htmlTable.Append("<td style =\"text-align:center\">" + kayit.Dokum_no + "</td>");
                    htmlTable.Append("<td style =\"text-align:center\">" + kayit.Celik_cinsi + "</td>");
                    htmlTable.Append("<td style =\"text-align:center\">" + kayit.Kutuk_sayisi + "</td>");
                    htmlTable.Append("<td style =\"text-align:center\">" + kayit.Srj + "</td>");
                    htmlTable.Append("<td style =\"text-align:center\">" + kayit.Istif_adet + "</td>");
                    if (kayit.Tel_cubuk_haddesi != "0")
                    {
                        htmlTable.Append("<td style =\"text-align:center\">" + kayit.Tel_cubuk_haddesi + "</td>");
                    }
                    else { htmlTable.Append("<td style =\"text-align:center\"></td>"); }
                    htmlTable.Append("<td style =\"text-align:center\">" + kayit.Kutuk_paketleme + "</td>");
                    htmlTable.Append("<td style =\"text-align:center\">" + kayit.Kutuk_satis + "</td>");
                    htmlTable.Append("<td style =\"text-align:center\">" + kayit.Kutuk_sayisi + "</td>");

                    if (kayit.Sonuc != "0")
                    {
                        htmlTable.Append("<td style =\"text-align:center; background-color:#ff1c33; color:#f7f3f3; font-weight: bold;\">" + (kayit.Sonuc) + "</td>");

                    }
                    else
                    {
                        htmlTable.Append("<td style =\"text-align:center; background-color:#7ef59c\"></td>");
                    }

                    htmlTable.Append("<td style =\"text-align:center\">" + kayit.Ocak_onu + "</td>");
                    htmlTable.Append("<td style =\"text-align:left\">" + kayit.Aciklama + "</td>");
                    htmlTable.Append("</tr>");

                }
            }
            ph_ktk_izlenebilirlik.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }

        protected void btn_Listele_Click(object sender, EventArgs e)
        {
            string baslangic_dokumnumarasi = tx_dokum_no.Text;
            string bitis_dokumnumarasi = tx_dokum_no2.Text;

            raporlari_getir(baslangic_dokumnumarasi, bitis_dokumnumarasi);
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../../Default2.aspx");
        }
    }
}