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
    public partial class Izlenebilirlik_ikitarih_arasi : System.Web.UI.Page
    {
        EndMuh_raporlar_db db = new EndMuh_raporlar_db();
        List<Izlenebilirlik_bilgileri> kayitlar = new List<Izlenebilirlik_bilgileri>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DateTime dt = new DateTime();
                dt = DateTime.Now;
                string tarih = dt.ToString("yyyyMMdd");//veritabanindaki kayit bicimi  
                string tarih2 = dt.ToString("yyyy-MM-dd");//textboxdaki bicimi
                tx_rapor_tarihi.Text = tarih2;
                tx_rapor_tarihi2.Text = tarih2;
                raporlari_getir(Convert.ToInt32(tarih), Convert.ToInt32(tarih));
            }

        }

        private void raporlari_getir(int tarih, int tarih2)
        {
            db.Connect();

            kayitlar = db.tarihbazinda_kutuk_takip_ozet_read(tarih, tarih2);
            tarihbazinda_kutuk_takip_ozet();

            db.Disconnect();



        }

        private void tarihbazinda_kutuk_takip_ozet()
        {
            StringBuilder htmlTable = new StringBuilder();

            if (kayitlar[0].Id == 0)
            {
                // Kayit Bululnamadı
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan=\"19\">" + kayitlar[0].Celik_cinsi + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var kayit in kayitlar)
                {
                    htmlTable.Append("<tr class='table_t'>");

                    htmlTable.Append("<td style =\"text-align:center\">" + kayit.Cikis_tarihi + "</td>");
                    htmlTable.Append("<td style =\"text-align:center\">" + kayit.Dokum_no + "</td>");
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
                    htmlTable.Append("<td style =\"text-align:center\">" + kayit.Firina_verilecek + "</td>");
                    htmlTable.Append("<td style =\"text-align:center\">" + kayit.Fid_hurda + "</td>");
                    htmlTable.Append("<td style =\"text-align:center\">" + kayit.Fde_hurda + "</td>");
                    htmlTable.Append("<td style =\"text-align:center\">" + kayit.Egri_kutuk_sayisi + "</td>");
                    htmlTable.Append("<td style =\"text-align:center\">" + kayit.Celik_cinsi + "</td>");
                    htmlTable.Append("<td style =\"text-align: left;\">" + kayit.Aciklama + "</td>");
                    htmlTable.Append("</tr>");

                }
            }
            ph_ktk_izlenebilirlik.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }

        protected void btn_Listele_Click(object sender, EventArgs e)
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

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../../Default2.aspx");
        }
    }
}