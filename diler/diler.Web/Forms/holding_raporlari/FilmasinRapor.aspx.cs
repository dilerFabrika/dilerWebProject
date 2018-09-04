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
    public partial class FilmasinRapor : System.Web.UI.Page
    {
        Holding_raporu_db db = new Holding_raporu_db();
        StringBuilder htmlTable = new StringBuilder();
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
            db.Connect();
            //db.flm_connect();
            kangal_uretim(tarih);
            kangal_uretim_ozet(tarih);
            kangal_duruslar(tarih);
            cubuk_uretim(tarih);
            cubuk_uretim_ozet(tarih);
            cubuk_enerjiler(tarih);

            db.Disconnect();
            //  db.flm_Disconnect();
        }
        private void rapor_tarihi_al()
        {
            string tarih2 = tx_rapor_tarihi.Text;//textboxdaki bicimi
            string tarih = tarih2.Replace("-", "");//veritabanindaki kayit bicimi
            tx_rapor_tarihi.Text = tarih2;

            raporlari_getir(tarih);
        }
        private void kangal_uretim(string tarih)
        {
            htmlTable.Clear();
            List<Kangal_uretim> kangal_uretim = new List<Kangal_uretim>();

            kangal_uretim = db.kangal_uretim_data_read(tarih);
            if (kangal_uretim[0].Uretim_id == 0)
            {
                //kayit bulunamadi
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan='6'>" + kangal_uretim[0].Uretim_bilgitnm + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var uretim in kangal_uretim)
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
            ph_uretim.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }

        private void kangal_uretim_ozet(string tarih)
        {
            htmlTable.Clear();
            List<Kangal_uretim_ozet> kangal_uretim_ozet = new List<Kangal_uretim_ozet>();

            kangal_uretim_ozet = db.kangal_uretim_ozet_data_read(tarih);
            if (kangal_uretim_ozet[0].Uo_id == 0)
            {
                //kayit bulunamadi
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan='3'>" + kangal_uretim_ozet[0].Kalite + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var u_ozet in kangal_uretim_ozet)
                {
                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td>" + u_ozet.Cap + "</td>");
                    htmlTable.Append("<td>" + u_ozet.Kalite + "</td>");
                    htmlTable.Append("<td>" + u_ozet.Tonaj + "</td>");
                    htmlTable.Append("</tr>");
                }
            }
            ph_cubuk_uretim_ozet.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }

        private void kangal_duruslar(string tarih)
        {
            string firma = "FILMASIN";
            string unite = "KNG";
            string tablotip = "DURUS_OZET";

            string ayrinti_firma = "DILER";
            string ayrinti_unite = "FLM";

            htmlTable.Clear();
            List<Duruslar> duruslar = new List<Duruslar>();
            duruslar = db.duruslar_data_read(tarih, firma, unite, tablotip);

            if (duruslar[0].Durus_id == 0)
            {
                //kayit bulunamadi
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan='10'>" + duruslar[0].Durus_nedeni + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var d in duruslar)
                {
                    htmlTable.Append("<tr>");
                    /** jQuery kullanmadan durus ayrintisi getirmek icin.
                     * htmlTable.Append("<td><a class='durus_ayrintisi_getir' href=\"javascript:__doPostBack('btn_durus_ayrinti_getir','" + d.Durus_nedeni + "')\">" + d.Durus_nedeni + "</a></td>");
                     */
                    htmlTable.Append("<td><a data-bilgi=\"" + d.Durus_nedeni + ";" + ayrinti_firma + ";" + ayrinti_unite + "\" title=\"Duruş ayrıntısı için tıklayın.\" class='durus_ayrintisi_getir' href=\"javascript:void(0);\">" + d.Durus_nedeni + "</a></td>");
                    htmlTable.Append("<td>" + d.Gun_sure + "</td>");
                    htmlTable.Append("<td>" + d.Gun_tekrar + "</td>");
                    htmlTable.Append("<td>" + d.Gun_yuzde + "</td>");
                    htmlTable.Append("<td>" + d.Ay_sure + "</td>");
                    htmlTable.Append("<td>" + d.Ay_tekrar + "</td>");
                    htmlTable.Append("<td>" + d.Ay_yuzde + "</td>");
                    htmlTable.Append("<td>" + d.Yil_sure + "</td>");
                    htmlTable.Append("<td>" + d.Yil_tekrar + "</td>");
                    htmlTable.Append("<td>" + d.Yil_yuzde + "</td>");
                    htmlTable.Append("</tr>");
                }
            }

            ph_duruslar.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }

        private void kangal_durus_ayrintisi(string tarih, string durus_tipi)
        {
            htmlTable.Clear();
            List<Durus_ayrintisi> duruslar = new List<Durus_ayrintisi>();
            string firma = "DILER";
            string unite = "FLM";

            duruslar = db.durus_ayrintisi_data_read(tarih, durus_tipi, firma, unite);
            if (duruslar[0].Durus_ayrintisi_id == 0)
            {
                //kayit bulunamadi
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan='4'>" + duruslar[0].Durus_tipi + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var durus in duruslar)
                {
                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td>" + durus.Durus_tipi + "</td>");
                    htmlTable.Append("<td>" + durus.Ariza_nedeni + "</td>");
                    htmlTable.Append("<td>" + durus.Toplam_sure + "</td>");
                    htmlTable.Append("<td>" + durus.Gun_tekrar + "</td>");
                    htmlTable.Append("</tr>");
                }
            }
            ph_durus_ayrintisi.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }

        private void cubuk_uretim(string tarih)
        {
            string firma = "FILMASIN";
            string unite = "KNG";
            string tablotip = "CBK";

            htmlTable.Clear();
            List<Kangal_uretim> uretimler = new List<Kangal_uretim>();

            uretimler = db.kangal_uretim_data_read(tarih, firma, unite, tablotip);
            if (uretimler[0].Uretim_id == 0)
            {
                //kayit bulunamadi
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan='6'>" + uretimler[0].Uretim_bilgitnm + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var uretim in uretimler)
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
            ph_cubuk_uretim.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }

        private void cubuk_uretim_ozet(string tarih)
        {
            htmlTable.Clear();
            List<Kangal_uretim_ozet> uretim_ozetler = new List<Kangal_uretim_ozet>();

            uretim_ozetler = db.kangal_uretim_ozet_data_read(tarih);
            if (uretim_ozetler[0].Uo_id == 0)
            {
                //kayit bulunamadi
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan='3'>" + uretim_ozetler[0].Kalite + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var u_ozet in uretim_ozetler)
                {
                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td>" + u_ozet.Cap + "</td>");
                    htmlTable.Append("<td>" + u_ozet.Kalite + "</td>");
                    htmlTable.Append("<td>" + u_ozet.Tonaj + "</td>");
                    htmlTable.Append("</tr>");
                }
            }
            ph_uretim_ozet.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }

        private void cubuk_enerjiler(string tarih)
        {
            string firma = "FILMASIN";
            string unite = "KNG";

            htmlTable.Clear();
            List<Enerjiler> enerjiler = new List<Enerjiler>();

            enerjiler = db.enerjiler_data_read(tarih, firma, unite);
            if (enerjiler[0].Enerji_id == 0)
            {
                //kayit bulunamadi
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan='7'>" + enerjiler[0].Enerji_bilgitnm + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var e in enerjiler)
                {
                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td>" + e.Enerji_bilgitnm + "</td>");
                    htmlTable.Append("<td>" + e.Gun_kwh + "</td>");
                    htmlTable.Append("<td>" + e.Gun_kwh_ton + "</td>");
                    htmlTable.Append("<td>" + e.Ay_kwh + "</td>");
                    htmlTable.Append("<td>" + e.Ay_kwh_ton + "</td>");
                    htmlTable.Append("<td>" + e.Yil_kwh + "</td>");
                    htmlTable.Append("<td>" + e.Yil_kwh_ton + "</td>");
                    htmlTable.Append("</tr>");
                }
            }

            ph_enerjiler.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }

        protected void bt_rapor_goster_Click(object sender, EventArgs e)
        {
            rapor_tarihi_al();
        }

        protected void tx_rapor_tarihi_TextChanged(object sender, EventArgs e)
        {
            rapor_tarihi_al();
        }
        protected void btn_durus_ayrinti_getir_Click(object sender, EventArgs e)
        {
            /** Durus ayrintilarini Jquery kullanmadan getirince kullanilmisti
             * string durus_tipi = Request["__EVENTARGUMENT"].ToString();
             */
            rapor_tarihi_al();

        }
    }
}