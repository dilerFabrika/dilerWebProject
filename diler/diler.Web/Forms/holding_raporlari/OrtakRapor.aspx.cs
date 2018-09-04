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
    public partial class OrtakRapor : System.Web.UI.Page
    {
        Holding_raporu_db db = new Holding_raporu_db();
        StringBuilder htmlTable = new StringBuilder();
        StringBuilder htmlTable2;
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

            dy_ortak(tarih);

            db.Disconnect();
        }

        private void dy_ortak(string tarih)
        {
            htmlTable.Clear();
            StringBuilder sb_celikhane = new StringBuilder();
            StringBuilder sb_cubukhaddehane = new StringBuilder();
            StringBuilder sb_failmasinyazici2 = new StringBuilder();
            StringBuilder sb_mamul_uretim = new StringBuilder();
            StringBuilder sb_sevkiyat_cubuk = new StringBuilder();
            StringBuilder sb_sevkiyat_filmasin = new StringBuilder();
            StringBuilder sb_sevkiyat_toplam_mamul = new StringBuilder();
            StringBuilder sb_sevkiyat_kutuk = new StringBuilder();

            List<Ortak_rapor> ortak_rapor = new List<Ortak_rapor>();
            ortak_rapor = db.ortak_rapor_data_read(tarih);

            if (ortak_rapor[0].Ortak_rapor_id == 0)
            {
                //kayit bulunamadi
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan='17'>" + ortak_rapor[0].Bilgitnm + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var ortak in ortak_rapor)
                {

                }
                string td_class = "";
                for (int i = 0; i < ortak_rapor.Count(); i++)
                {
                    if (i < 12)
                    {
                        htmlTable2 = sb_celikhane;
                    }
                    else if (i < 19)
                    {
                        htmlTable2 = sb_cubukhaddehane;
                    }
                    else if (i < 26)
                    {
                        htmlTable2 = sb_failmasinyazici2;
                    }
                    else if (i < 29)
                    {
                        htmlTable2 = sb_mamul_uretim;
                        td_class = "td_yesil";
                    }
                    else if (i < 32)
                    {
                        htmlTable2 = sb_sevkiyat_cubuk;
                        td_class = "";
                    }
                    else if (i < 35)
                    {
                        htmlTable2 = sb_sevkiyat_filmasin;
                        td_class = "";
                    }
                    else if (i < 38)
                    {
                        htmlTable2 = sb_sevkiyat_toplam_mamul;
                        td_class = "td_yesil";
                    }
                    else if (i < 41)
                    {
                        htmlTable2 = sb_sevkiyat_kutuk;
                        td_class = "";
                    }
                    htmlTable2.Append("<tr>");
                    htmlTable2.Append("<td class=' " + td_class + "'>" + ortak_rapor[i].Bilgitnm + "</td>");
                    htmlTable2.Append("<td class='td_turuncu " + td_class + "'>" + ortak_rapor[i].Diler_gun + "</td>");
                    htmlTable2.Append("<td class=' " + td_class + "'>" + ortak_rapor[i].Diler_gun_ort + "</td>");
                    htmlTable2.Append("<td class=' " + td_class + "'>" + ortak_rapor[i].Diler_ay + "</td>");
                    htmlTable2.Append("<td class=' " + td_class + "'>" + ortak_rapor[i].Diler_ay_ort + "</td>");
                    htmlTable2.Append("<td class=' " + td_class + "'>" + ortak_rapor[i].Diler_yil + "</td>");
                    htmlTable2.Append("<td class=' " + td_class + "'>" + ortak_rapor[i].Diler_yil_ort + "</td>");
                    htmlTable2.Append("<td class='td_sari " + td_class + "'>" + ortak_rapor[i].Diler_yil_tempo + "</td>");
                    htmlTable2.Append("<td class='td_turuncu " + td_class + "'>" + ortak_rapor[i].Yazici_gun + "</td>");
                    htmlTable2.Append("<td class=' " + td_class + "'>" + ortak_rapor[i].Yazici_gun_ort + "</td>");
                    htmlTable2.Append("<td class=' " + td_class + "'>" + ortak_rapor[i].Yazici_ay + "</td>");
                    htmlTable2.Append("<td class=' " + td_class + "'>" + ortak_rapor[i].Yazici_ay_ort + "</td>");
                    htmlTable2.Append("<td class=' " + td_class + "'>" + ortak_rapor[i].Yazici_yil + "</td>");
                    htmlTable2.Append("<td class=' " + td_class + "'>" + ortak_rapor[i].Yazici_yil_ort + "</td>");
                    htmlTable2.Append("<td class='td_sari " + td_class + "'>" + ortak_rapor[i].Yazici_yil_tempo + "</td>");
                    htmlTable2.Append("<td class='td_mavi " + td_class + "'>" + ortak_rapor[i].Diler_toplam_yil_tempo + "</td>");
                    htmlTable2.Append("<td class='td_mavi " + td_class + "'>" + ortak_rapor[i].Yazici_toplam_yil_tempo + "</td>");
                    htmlTable2.Append("</tr>");
                }

            }
            ph_or_celikhane.Controls.Add(new Literal { Text = sb_celikhane.ToString() });
            ph_or_cubuk_had.Controls.Add(new Literal { Text = sb_cubukhaddehane.ToString() });
            ph_or_filmasin_yazici2.Controls.Add(new Literal { Text = sb_failmasinyazici2.ToString() });
            ph_or_mamul_uretim.Controls.Add(new Literal { Text = sb_mamul_uretim.ToString() });
            ph_or_sevkiyat_cubuk.Controls.Add(new Literal { Text = sb_sevkiyat_cubuk.ToString() });
            ph_or_sevkiyat_filmasin.Controls.Add(new Literal { Text = sb_sevkiyat_filmasin.ToString() });
            ph_or_sevkiyat_toplam_mamul.Controls.Add(new Literal { Text = sb_sevkiyat_toplam_mamul.ToString() });
            ph_or_sevkiyat_kutuk.Controls.Add(new Literal { Text = sb_sevkiyat_kutuk.ToString() });
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