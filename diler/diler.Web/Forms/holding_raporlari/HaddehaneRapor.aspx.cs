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
    public partial class HaddehaneRapor : System.Web.UI.Page
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
            db.Connect();

            d_hh_genel_uretim(tarih);
            d_hh_yb_uretim_ozet(tarih);
            d_hh_duruslar(tarih);
            y_hh_genel_uretim(tarih);
            y_hh_duruslar(tarih);
            y2_hh_genel_uretim(tarih);
            y2_hh_duruslar(tarih);

            db.Disconnect();
        }
        private void rapor_tarihi_al()
        {
            string tarih2 = tx_rapor_tarihi.Text;//textboxdaki bicimi
            string tarih = tarih2.Replace("-", "");//veritabanindaki kayit bicimi
            tx_rapor_tarihi.Text = tarih2;

            raporlari_getir(tarih);
        }
        private void d_hh_genel_uretim(string tarih)
        {
            firma = "DILER";
            unite = "HH";
            htmlTable.Clear();
            List<Genel_uretim> genel_uretimler = new List<Genel_uretim>();
            genel_uretimler = db.genel_uretim_data_read(tarih, firma, unite);

            if (genel_uretimler[0].Gu_id == 0)
            {
                //kayit bulunamadi
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan='7'>" + genel_uretimler[0].Gu_bilgitnm + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var gu in genel_uretimler)
                {
                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td>" + gu.Gu_bilgitnm + "</td>");
                    htmlTable.Append("<td>" + gu.Gu_gunluk + "</td>");
                    htmlTable.Append("<td>" + gu.Gu_gunluk_ort + "</td>");
                    htmlTable.Append("<td>" + gu.Gu_aylik + "</td>");
                    htmlTable.Append("<td>" + gu.Gu_aylik_ort + "</td>");
                    htmlTable.Append("<td>" + gu.Gu_yillik + "</td>");
                    htmlTable.Append("<td>" + gu.Gu_yillik_ort + "</td>");
                    htmlTable.Append("</tr>");
                }
            }
            ph_genel_uretim.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }
        private void d_hh_yb_uretim_ozet(string tarih)
        {
            firma = "DILER";
            unite = "HH-ORTAK";
            htmlTable.Clear();
            List<Yol_bazinda_uretim_ozet> yb_uretim_ozet = new List<Yol_bazinda_uretim_ozet>();
            yb_uretim_ozet = db.d_hh_ybuo_data_read(tarih, firma, unite);

            if (yb_uretim_ozet[0].Ybu_id == 0)
            {
                //kayit bulunamadi
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan='4'>" + yb_uretim_ozet[0].Vrd + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var uo in yb_uretim_ozet)
                {
                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td>" + uo.Vrd + "</td>");
                    htmlTable.Append("<td>" + uo.Yol + "</td>");
                    htmlTable.Append("<td>" + uo.Net_urt + "</td>");
                    htmlTable.Append("<td>" + uo.Mamul + "</td>");
                    htmlTable.Append("</tr>");
                }
            }
            ph_yb_uretim_ozet.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }
        private void d_hh_duruslar(string tarih)
        {
            string tablotip = "DURUS_OZET";
            string unite = "HH";
            htmlTable.Clear();
            List<Duruslar> duruslar = new List<Duruslar>();
            duruslar = db.duruslar_hh_data_read(tarih, firma, unite, tablotip);

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
                    htmlTable.Append("<td><a data-bilgi=\"" + d.Durus_nedeni + ";" + firma + ";" + unite + "\" title=\"Duruş ayrıntısı için tıklayın.\" class='durus_ayrintisi_getir' href=\"javascript:void(0);\">" + d.Durus_nedeni + "</a></td>");
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
            ph_duruslar.Controls.Clear();
            ph_duruslar.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }
        private void d_hh_durus_ayrintisi(string tarih, string durus_tipi)
        {
            htmlTable.Clear();
            List<Durus_ayrintisi> duruslar = new List<Durus_ayrintisi>();

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

        private void y_hh_genel_uretim(string tarih)
        {
            firma = "YAZICI";
            unite = "HH";
            htmlTable.Clear();
            List<Genel_uretim> genel_uretimler = new List<Genel_uretim>();
            genel_uretimler = db.genel_uretim_data_read(tarih, firma, unite);

            if (genel_uretimler[0].Gu_id == 0)
            {
                //kayit bulunamadi
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan='7'>" + genel_uretimler[0].Gu_bilgitnm + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var gu in genel_uretimler)
                {
                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td>" + gu.Gu_bilgitnm + "</td>");
                    htmlTable.Append("<td>" + gu.Gu_gunluk + "</td>");
                    htmlTable.Append("<td>" + gu.Gu_gunluk_ort + "</td>");
                    htmlTable.Append("<td>" + gu.Gu_aylik + "</td>");
                    htmlTable.Append("<td>" + gu.Gu_aylik_ort + "</td>");
                    htmlTable.Append("<td>" + gu.Gu_yillik + "</td>");
                    htmlTable.Append("<td>" + gu.Gu_yillik_ort + "</td>");
                    htmlTable.Append("</tr>");
                }
            }
            ph_yazici_genel_uretim.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }
        private void y_hh_duruslar(string tarih)
        {
            string tablotip = "DURUS_OZET";
            firma = "YAZICI";
            unite = "HH";

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
                    htmlTable.Append("<td>" + d.Durus_nedeni + "</td>");
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

            ph_yazici_duruslar.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }

        private void y2_hh_genel_uretim(string tarih)
        {
            firma = "YAZICI2";
            unite = "HH";
            htmlTable.Clear();
            List<Genel_uretim> genel_uretimler = new List<Genel_uretim>();
            genel_uretimler = db.genel_uretim_data_read(tarih, firma, unite);

            if (genel_uretimler[0].Gu_id == 0)
            {
                //kayit bulunamadi
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan='7'>" + genel_uretimler[0].Gu_bilgitnm + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var gu in genel_uretimler)
                {
                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td>" + gu.Gu_bilgitnm + "</td>");
                    htmlTable.Append("<td>" + gu.Gu_gunluk + "</td>");
                    htmlTable.Append("<td>" + gu.Gu_gunluk_ort + "</td>");
                    htmlTable.Append("<td>" + gu.Gu_aylik + "</td>");
                    htmlTable.Append("<td>" + gu.Gu_aylik_ort + "</td>");
                    htmlTable.Append("<td>" + gu.Gu_yillik + "</td>");
                    htmlTable.Append("<td>" + gu.Gu_yillik_ort + "</td>");
                    htmlTable.Append("</tr>");
                }
            }
            ph_yazici2_genel_uretim.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }
        private void y2_hh_duruslar(string tarih)
        {
            string tablotip = "DURUS_OZET";
            firma = "YAZICI2";
            unite = "HH";

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
                    htmlTable.Append("<td>" + d.Durus_nedeni + "</td>");
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

            ph_yazici2_duruslar.Controls.Add(new Literal { Text = htmlTable.ToString() });
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