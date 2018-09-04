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
    public partial class KarsilastirmalarRaporu : System.Web.UI.Page
    {
        Holding_raporu_db db = new Holding_raporu_db();
        StringBuilder htmlTable = new StringBuilder();
        string firma = "DILER";
        string unite = "HH";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DateTime dt = new DateTime();
                dt = DateTime.Now;
                string tarih = dt.AddDays(-1).ToString("yyyyMMdd");//veritabanindaki kayit bicimi
                string tarih2 = dt.AddDays(-1).ToString("yyyy-MM-dd");//textboxdaki bicimi
                tx_rapor_tarihi.Text = tarih2;
                raporlari_getir(tarih);
            }
        }
        private void raporlari_getir(string tarih)
        {
            db.flm_connect();
            db.Connect();

            dc_uretim(tarih);
            yc_uretim(tarih);
            dh_uretim(tarih);
            yh_uretim(tarih);
            fh_uretim(tarih);
            fh_enerji(tarih);

            db.Disconnect();
            db.flm_Disconnect();
        }

        private void dc_uretim(string tarih)
        {
            string firma = "DILER";
            string unite = "CH-ORTAK";
            htmlTable.Clear();
            List<Genel_uretim> genel_uretim = new List<Genel_uretim>();

            genel_uretim = db.genel_uretim_data_read(tarih, firma, unite);
            if (genel_uretim[0].Gu_id == 0)
            {
                //kayit bulunamadi
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan='7'>" + genel_uretim[0].Gu_bilgitnm + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var uretim in genel_uretim)
                {
                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td>" + uretim.Gu_bilgitnm + "</td>");
                    htmlTable.Append("<td>" + uretim.Gu_gunluk + "</td>");
                    htmlTable.Append("<td>" + uretim.Gu_gunluk_ort + "</td>");
                    htmlTable.Append("<td>" + uretim.Gu_aylik + "</td>");
                    htmlTable.Append("<td>" + uretim.Gu_aylik_ort + "</td>");
                    htmlTable.Append("<td>" + uretim.Gu_yillik + "</td>");
                    htmlTable.Append("<td>" + uretim.Gu_yillik_ort + "</td>");
                    htmlTable.Append("</tr>");
                }
            }
            ph_dc_uretimi.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }

        private void yc_uretim(string tarih)
        {
            string firma = "YAZICI";
            string unite = "CH-ORTAK";
            htmlTable.Clear();
            List<Genel_uretim> genel_uretim = new List<Genel_uretim>();

            genel_uretim = db.genel_uretim_data_read(tarih, firma, unite);
            if (genel_uretim[0].Gu_id == 0)
            {
                //kayit bulunamadi
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan='7'>" + genel_uretim[0].Gu_bilgitnm + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var uretim in genel_uretim)
                {
                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td>" + uretim.Gu_bilgitnm + "</td>");
                    htmlTable.Append("<td>" + uretim.Gu_gunluk + "</td>");
                    htmlTable.Append("<td>" + uretim.Gu_gunluk_ort + "</td>");
                    htmlTable.Append("<td>" + uretim.Gu_aylik + "</td>");
                    htmlTable.Append("<td>" + uretim.Gu_aylik_ort + "</td>");
                    htmlTable.Append("<td>" + uretim.Gu_yillik + "</td>");
                    htmlTable.Append("<td>" + uretim.Gu_yillik_ort + "</td>");
                    htmlTable.Append("</tr>");
                }
            }
            ph_yc_uretimi.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }

        private void dh_uretim(string tarih)
        {
            string firma = "DILER";
            string unite = "HH-ORTAK";
            htmlTable.Clear();
            List<Genel_uretim> genel_uretim = new List<Genel_uretim>();

            genel_uretim = db.genel_uretim_data_read(tarih, firma, unite);
            if (genel_uretim[0].Gu_id == 0)
            {
                //kayit bulunamadi
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan='7'>" + genel_uretim[0].Gu_bilgitnm + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var uretim in genel_uretim)
                {
                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td>" + uretim.Gu_bilgitnm + "</td>");
                    htmlTable.Append("<td>" + uretim.Gu_gunluk + "</td>");
                    htmlTable.Append("<td>" + uretim.Gu_gunluk_ort + "</td>");
                    htmlTable.Append("<td>" + uretim.Gu_aylik + "</td>");
                    htmlTable.Append("<td>" + uretim.Gu_aylik_ort + "</td>");
                    htmlTable.Append("<td>" + uretim.Gu_yillik + "</td>");
                    htmlTable.Append("<td>" + uretim.Gu_yillik_ort + "</td>");
                    htmlTable.Append("</tr>");
                }
            }
            ph_dh_uretimi.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }

        private void yh_uretim(string tarih)
        {
            string firma = "YAZICI";
            string unite = "HH-ORTAK";
            htmlTable.Clear();
            List<Genel_uretim> genel_uretim = new List<Genel_uretim>();

            genel_uretim = db.genel_uretim_data_read(tarih, firma, unite);
            if (genel_uretim[0].Gu_id == 0)
            {
                //kayit bulunamadi
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan='7'>" + genel_uretim[0].Gu_bilgitnm + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var uretim in genel_uretim)
                {
                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td>" + uretim.Gu_bilgitnm + "</td>");
                    htmlTable.Append("<td>" + uretim.Gu_gunluk + "</td>");
                    htmlTable.Append("<td>" + uretim.Gu_gunluk_ort + "</td>");
                    htmlTable.Append("<td>" + uretim.Gu_aylik + "</td>");
                    htmlTable.Append("<td>" + uretim.Gu_aylik_ort + "</td>");
                    htmlTable.Append("<td>" + uretim.Gu_yillik + "</td>");
                    htmlTable.Append("<td>" + uretim.Gu_yillik_ort + "</td>");
                    htmlTable.Append("</tr>");
                }
            }
            ph_yh_uretimi.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }

        private void fh_uretim(string tarih)
        {
            string firma = "FILMASIN";
            string unite = "KNG";
            htmlTable.Clear();
            List<Kangal_uretim> genel_uretim = new List<Kangal_uretim>();

            genel_uretim = db.kangal_uretim_data_read(tarih, firma, unite);
            if (genel_uretim[0].Uretim_id == 0)
            {
                //kayit bulunamadi
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan='6'>" + genel_uretim[0].Uretim_bilgitnm + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var uretim in genel_uretim)
                {
                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td>" + uretim.Uretim_bilgitnm + "</td>");
                    htmlTable.Append("<td>" + uretim.Gunluk + "</td>");
                    htmlTable.Append("<td>" + uretim.Aylik + "</td>");
                    htmlTable.Append("<td>" + uretim.Aylik_ort + "</td>");
                    htmlTable.Append("<td>" + uretim.Yillik + "</td>");
                    htmlTable.Append("<td>" + uretim.Yillik_ort + "</td>");
                    htmlTable.Append("</tr>");
                }
            }
            ph_fh_uretimi.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }

        private void fh_enerji(string tarih)
        {
            string firma = "FILMASIN";
            string unite = "KNG";
            string tablotip = "ENERJI";
            htmlTable.Clear();
            List<Genel_uretim> genel_uretim = new List<Genel_uretim>();

            genel_uretim = db.genel_uretim_data_read(tarih, firma, unite, tablotip);
            if (genel_uretim[0].Gu_id == 0)
            {
                //kayit bulunamadi
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan='7'>" + genel_uretim[0].Gu_bilgitnm + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var uretim in genel_uretim)
                {
                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td>" + uretim.Gu_bilgitnm + "</td>");
                    htmlTable.Append("<td>" + uretim.Gu_gunluk + "</td>");
                    htmlTable.Append("<td>" + uretim.Gu_gunluk_ort + "</td>");
                    htmlTable.Append("<td>" + uretim.Gu_aylik + "</td>");
                    htmlTable.Append("<td>" + uretim.Gu_aylik_ort + "</td>");
                    htmlTable.Append("<td>" + uretim.Gu_yillik + "</td>");
                    htmlTable.Append("<td>" + uretim.Gu_yillik_ort + "</td>");
                    htmlTable.Append("</tr>");
                }
            }
            ph_fh_enerji.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }

        protected void bt_rapor_goster_Click(object sender, EventArgs e)
        {
            string tarih2 = tx_rapor_tarihi.Text;//textboxdaki bicimi
            string tarih = tarih2.Replace("-", "");//veritabanindaki kayit bicimi
            raporlari_getir(tarih);

            tx_rapor_tarihi.Text = tarih2;
        }

        protected void tx_rapor_tarihi_TextChanged(object sender, EventArgs e)
        {
            string tarih2 = tx_rapor_tarihi.Text;//textboxdaki bicimi
            string tarih = tarih2.Replace("-", "");//veritabanindaki kayit bicimi
            raporlari_getir(tarih);

            tx_rapor_tarihi.Text = tarih2;
        }
    }
}