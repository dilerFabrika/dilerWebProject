using diler.Dal;
using diler.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace diler.Web.Forms.holding_raporlari
{
    public partial class CHTonajlari : System.Web.UI.Page
    {
        Holding_raporu_db db = new Holding_raporu_db();
        protected void Page_Load(object sender, EventArgs e)
        {
            raporlari_getir();
        }
        private void raporlari_getir()
        {
            db.Connect();

            d_ch_genel_uretimi();
            y_ch_genel_uretimi();

            db.Disconnect();
        }

        private string ay_getir(int ay_index)
        {
            string ay = "";
            switch (ay_index)
            {
                case 1:
                    ay = "Ocak";
                    break;
                case 2:
                    ay = "Şubat";
                    break;
                case 3:
                    ay = "Mart";
                    break;
                case 4:
                    ay = "Nisan";
                    break;
                case 5:
                    ay = "Mayıs";
                    break;
                case 6:
                    ay = "Haziran";
                    break;
                case 7:
                    ay = "Temmuz";
                    break;
                case 8:
                    ay = "Ağustos";
                    break;
                case 9:
                    ay = "Eylül";
                    break;
                case 10:
                    ay = "Ekim";
                    break;
                case 11:
                    ay = "Kasım";
                    break;
                case 12:
                    ay = "Aralık";
                    break;
                default:
                    ay = "Oops!";
                    break;
            }
            return ay;
        }

        private StringBuilder tonajlari_getir(string firma, string unite)
        {
            StringBuilder htmlTable = new StringBuilder();
            htmlTable.Clear();
            List<Tonajlar> tonajlar = new List<Tonajlar>();
            tonajlar = db.tonajlar_data_read(firma, unite);

            htmlTable.Append("<thead><tr><th></th>");
            DateTime dt2 = new DateTime();
            dt2 = DateTime.Now;
            double[] toplam_tonaj = new double[5] { 0, 0, 0, 0, 0 };
            int yil = dt2.Year - 5;
            for (int i = dt2.Year; i > dt2.Year - 5; i--)
            {
                htmlTable.Append("<th>" + i.ToString() + "</th>");
            }
            htmlTable.Append("</tr></thead><tbody>");

            if (tonajlar[0].Tonaj_id == 0)
            {
                //kayit bulunamadi
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan='6'>" + tonajlar[0].Yil + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                for (int i = 1; i <= 12; i++)
                {
                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td>" + ay_getir(i) + "</td>");
                    for (int j = dt2.Year; j > dt2.Year - 5; j--)
                    {
                        htmlTable.Append("<td>");
                        foreach (var t in tonajlar)
                        {
                            if (Convert.ToInt32(t.Yil) == j && Convert.ToInt32(t.Ay) == i)
                            {
                                htmlTable.Append(t.Tonaj);
                                toplam_tonaj[dt2.Year - Convert.ToInt32(t.Yil)] += Convert.ToDouble(t.Tonaj);
                            }
                        }
                        htmlTable.Append("</td>");
                    }
                    htmlTable.Append("</tr>");
                }
            }
            htmlTable.Append("<tr><td style='background-color:#FF0;font-weight:bold;'>TOPLAM</td>");
            for (int i = 0; i < toplam_tonaj.Length; i++)
            {
                htmlTable.Append("<td style='background-color:#FF0;font-weight:bold;'>" + toplam_tonaj[i] + "</td>");
            }
            htmlTable.Append("</tr>");
            htmlTable.Append("</tbody>");

            return htmlTable;
        }
        private void d_ch_genel_uretimi()
        {
            StringBuilder table = new StringBuilder();
            string firma = "DILER";
            string unite = "CH";
            table = tonajlari_getir(firma, unite);
            ph_d_ch_uretimi.Controls.Add(new Literal { Text = table.ToString() });
        }
        private void y_ch_genel_uretimi()
        {
            StringBuilder table = new StringBuilder();
            string firma = "YAZICI";
            string unite = "CH";
            table = tonajlari_getir(firma, unite);
            ph_y_ch_uretimi.Controls.Add(new Literal { Text = table.ToString() });
        }
    }
}