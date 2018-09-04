using diler.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using diler.Dal;

namespace diler.Web.Forms.Celikhane
{
    public partial class Celikhane_rapor : System.Web.UI.Page
    {


        Celikhane_rapor_db db = new Celikhane_rapor_db();
        StringBuilder htmlTable = new StringBuilder();

        [System.Web.Services.WebMethod]
        public static string durus_ayrinti_getir(string tarih, string durus_tipi)
        {

            StringBuilder htmlTable = new StringBuilder();
            Celikhane_rapor_db db = new Celikhane_rapor_db();
            List<Durus_ayrintisi> duruslar = new List<Durus_ayrintisi>();

            db.Connect();
            duruslar = db.durus_ayrintisi_data_read(tarih, durus_tipi);
            db.Disconnect();
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

            return htmlTable.ToString();
        }
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

            ch_uretim(tarih);
            ch_uretim_ozet(tarih);
            ch_enerjiler(tarih);
            ch_sarfiyatlar(tarih);
            ch_duruslar(tarih);
            ch_hurdalar(tarih);
            ch_oksijen(tarih);
            ch_analizler(tarih);

            db.Disconnect();
        }


        private void ch_enerjiler(string tarih)
        {
            htmlTable.Clear();
            List<Enerjiler> enerjiler = new List<Enerjiler>();
            enerjiler = db.enerjiler_data_read(tarih);
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
                    htmlTable.Append("<td class='gun';\">" + e.Gun_kwh + "</td>");
                    htmlTable.Append("<td>" + e.Gun_kwh_ton + "</td>");
                    htmlTable.Append("<td class='ay';\">" + e.Ay_kwh + "</td>");
                    htmlTable.Append("<td>" + e.Ay_kwh_ton + "</td>");
                    htmlTable.Append("<td class='yil';\">" + e.Yil_kwh + "</td>");
                    htmlTable.Append("<td>" + e.Yil_kwh_ton + "</td>");
                    htmlTable.Append("</tr>");
                }
            }
            ph_enerjiler.Controls.Clear();
            ph_enerjiler.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }
        private void ch_hurdalar(string tarih)
        {
            htmlTable.Clear();
            List<Hurdalar> hurdalar = new List<Hurdalar>();
            hurdalar = db.hurdalar_data_read(tarih);
            if (hurdalar[0].Hurda_id == 0)
            {
                //kayit bulunamadi
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan='8'>" + hurdalar[0].Hurda_bilgitnm + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var h in hurdalar)
                {
                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td>" + h.Hurda_bilgitnm + "</td>");
                    htmlTable.Append("<td>" + h.Gunluk_kullanim + "</td>");
                    htmlTable.Append("<td>" + h.Aylik_kullanim + "</td>");
                    htmlTable.Append("<td>" + h.Yillik_kullanim + "</td>");
                    htmlTable.Append("<td>" + h.Gunluk_giris + "</td>");
                    htmlTable.Append("<td>" + h.Aylik_giris + "</td>");
                    htmlTable.Append("<td>" + h.Yillik_giris + "</td>");
                    htmlTable.Append("<td>" + h.Stok + "</td>");
                    htmlTable.Append("</tr>");
                }
            }
            ph_hurdalar.Controls.Clear();
            ph_hurdalar.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }
        private void ch_analizler(string tarih)
        {
            htmlTable.Clear();
            List<Analizler> analizler = new List<Analizler>();
            analizler = db.analizler_data_read(tarih);

            if (analizler[0].Analiz_id == 0)
            {
                //kayit bulunamadi
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan='10'>" + analizler[0].Dokum_no + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var a in analizler)
                {
                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td>" + a.Dokum_no + "</td>");
                    htmlTable.Append("<td>" + a.C + "</td>");
                    htmlTable.Append("<td>" + a.Si + "</td>");
                    htmlTable.Append("<td>" + a.S + "</td>");
                    htmlTable.Append("<td>" + a.P + "</td>");
                    htmlTable.Append("<td>" + a.Mn + "</td>");
                    htmlTable.Append("<td>" + a.Ni + "</td>");
                    htmlTable.Append("<td>" + a.Cr + "</td>");
                    htmlTable.Append("<td>" + a.Cu + "</td>");
                    htmlTable.Append("<td>" + a.V + "</td>");
                    htmlTable.Append("</tr>");
                }
            }
            ph_analizler.Controls.Clear();
            ph_analizler.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }
        private void ch_uretim(string tarih)
        {
            htmlTable.Clear();
            List<Uretimler> uretimler = new List<Uretimler>();

            uretimler = db.uretimler_data_read(tarih);
            if (uretimler[0].Uretim_id == 0)
            {
                //kayit bulunamadi
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan='4'>" + uretimler[0].Uretim_bilgitnm + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var uretim in uretimler)
                {

                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td>" + uretim.Uretim_bilgitnm + "</td>");
                    htmlTable.Append("<td>" + uretim.Dokum_sayisi + "</td>");
                    htmlTable.Append("<td>" + uretim.Imale_sevk_hurda + "</td>");
                    htmlTable.Append("<td>" + uretim.Uretim + "</td>");
                    htmlTable.Append("</tr>");

                }
            }
            ph_uretim.Controls.Clear();
            ph_uretim.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }
        private void ch_uretim_ozet(string tarih)
        {
            htmlTable.Clear();
            List<Analizler> uretim_ozetler = new List<Analizler>();

            uretim_ozetler = db.uretim_ozetler_data_read(tarih);
            if (uretim_ozetler[0].Analiz_id == 0)
            {
                //kayit bulunamadi
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan='4'>" + uretim_ozetler[0].Celik_cinsi + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var u_ozet in uretim_ozetler)
                {
                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td>" + u_ozet.Celik_cinsi + "</td>");
                    htmlTable.Append("<td>" + u_ozet.Ebat + "</td>");
                    htmlTable.Append("<td>" + u_ozet.Boy + "</td>");
                    htmlTable.Append("<td>" + u_ozet.Tonaj + "</td>");
                    htmlTable.Append("</tr>");
                }
            }
            ph_uretim_ozet.Controls.Clear();
            ph_uretim_ozet.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }
        private void ch_sarfiyatlar(string tarih)
        {
            htmlTable.Clear();
            List<Sarfiyatlar> sarfiyatlar = new List<Sarfiyatlar>();
            sarfiyatlar = db.sarfiyatlar_data_read(tarih);

            if (sarfiyatlar[0].Sarfiyat_id == 0)
            {
                //kayit bulunamadi
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan='7'>" + sarfiyatlar[0].Sarfiyat_bilgitnm + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var s in sarfiyatlar)
                {
                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td>" + s.Sarfiyat_bilgitnm + "</td>");
                    htmlTable.Append("<td>" + s.Gun_miktar + "</td>");
                    htmlTable.Append("<td>" + s.Gun_ton + "</td>");
                    htmlTable.Append("<td>" + s.Ay_miktar + "</td>");
                    htmlTable.Append("<td>" + s.Ay_ton + "</td>");
                    htmlTable.Append("<td>" + s.Yil_miktar + "</td>");
                    htmlTable.Append("<td>" + s.Yil_ton + "</td>");
                    htmlTable.Append("</tr>");
                }
            }
            ph_sarfiyatlar.Controls.Clear();
            ph_sarfiyatlar.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }
        private void ch_duruslar(string tarih)
        {
            htmlTable.Clear();
            List<Duruslar> duruslar = new List<Duruslar>();
            duruslar = db.duruslar_data_read(tarih);

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
                    htmlTable.Append("<td><a class='durus_ayrintisi_getir' href=\"javascript:__doPostBack('btn_durus_ayrinti_getir','" + d.Durus_nedeni + "')\">" + d.Durus_nedeni + "</a></td>");

                    // htmlTable.Append("<td><a data-bilgi=\"" + d.Durus_nedeni + "\" title=\"Duruş ayrıntısı için tıklayın.\" class='durus_ayrintisi_getir' href=\"javascript:void(0);\">" + d.Durus_nedeni + "</a></td>");
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
        private void ch_durus_ayrintisi(string tarih, string durus_tipi)
        {
            htmlTable.Clear();
            List<Durus_ayrintisi> duruslar = new List<Durus_ayrintisi>();

            duruslar = db.durus_ayrintisi_data_read(tarih, durus_tipi);

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
            ph_durus_ayrintisi.Controls.Clear();
            ph_durus_ayrintisi.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }
        private void ch_oksijen(string tarih)
        {
            htmlTable.Clear();
            List<Oksijen> oksijen = new List<Oksijen>();
            oksijen = db.oksijen_data_read(tarih);

            if (oksijen[0].Oksijen_id == 0)
            {
                //kayit bulunamadi
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan='7'>" + oksijen[0].Oksijen_bilgitnm + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var o in oksijen)
                {
                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td>" + o.Oksijen_bilgitnm + "</td>");
                    htmlTable.Append("<td>" + o.Gun_miktar + "</td>");
                    htmlTable.Append("<td>" + o.Gun_ton + "</td>");
                    htmlTable.Append("<td>" + o.Ay_miktar + "</td>");
                    htmlTable.Append("<td>" + o.Ay_ton + "</td>");
                    htmlTable.Append("<td>" + o.Yil_miktar + "</td>");
                    htmlTable.Append("<td>" + o.Yil_ton + "</td>");
                    htmlTable.Append("</tr>");
                }
            }
            ph_oksijen.Controls.Clear();
            ph_oksijen.Controls.Add(new Literal { Text = htmlTable.ToString() });

        }

        private void rapor_tarihi_al()
        {
            string tarih2 = tx_rapor_tarihi.Text;//textboxdaki bicimi
            string tarih = tarih2.Replace("-", "");//veritabanindaki kayit bicimi
            tx_rapor_tarihi.Text = tarih2;

            raporlari_getir(tarih);
        }


        protected void tx_rapor_tarihi_TextChanged(object sender, EventArgs e)
        {
            rapor_tarihi_al();
        }
        protected void btn_durus_ayrinti_getir_Click(object sender, EventArgs e)
        {

            string tarih2 = tx_rapor_tarihi.Text;//textboxdaki bicimi
            string tarih = tarih2.Replace("-", "");//veritabanindaki kayit bicimi
            string durus_tipi = Request["__EVENTARGUMENT"].ToString();
            db.Connect();
            if (durus_tipi != "TOPLAM")
            {
                ch_durus_ayrintisi(tarih, durus_tipi);
            }


            ch_uretim(tarih);
            ch_uretim_ozet(tarih);
            ch_enerjiler(tarih);
            ch_sarfiyatlar(tarih);
            ch_duruslar(tarih);
            ch_hurdalar(tarih);
            ch_oksijen(tarih);
            ch_analizler(tarih);

            db.Disconnect();
        }
    }
}