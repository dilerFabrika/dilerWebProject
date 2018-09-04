using DevExpress.Web;
using diler.Dal;
using diler.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace diler.Web
{
    public partial class Default2 : System.Web.UI.Page
    {

        Celikhane_db database = new Celikhane_db();
        protected void Page_Load(object sender, EventArgs e)
        {


            dynamic kullanici;
            if (!Page.IsPostBack)
            {

                DateTime dt = new DateTime();
                dt = DateTime.Now;

                //string tarih = dt.AddDays(-14).ToString("yyyyMMdd");//veritabanindaki kayit bicimi
                //string tarih2 = dt.AddDays(-8).ToString("yyyyMMdd");

                kullanici = Session["kullanici"];
                if (kullanici != "D1690" && kullanici != "YAZICI")
                {
                    btn_show_hrapor.Visible = false;
                }
                string tarih3 = dt.ToString("yyyyMMdd");

                database.connect();
                yemek_listesi(tarih3);
                haber_listesi(tarih3);
                bes_listesi(tarih3);
                dosis_listesi(tarih3);
                database.disConnect();


            }
        }


        private void dosis_listesi(string tarih3)
        {
            List<Haber> kayitlar = new List<Haber>();
            StringBuilder htmlTable = new StringBuilder();
            kayitlar = database.dosis_tablosu(tarih3);

            foreach (var kayit in kayitlar)
            {
                htmlTable.Append("<tr>");

                htmlTable.Append("<td style=\" Text-align:center;font-weight: bold; padding: 6px; \">" + kayit.dosis + "</td>");

                htmlTable.Append("</tr>");
            }

            ph_dosis_takip.Controls.Add(new Literal { Text = htmlTable.ToString() });

        }

        private void bes_listesi(string tarih3)
        {

            List<Haber> kayitlar = new List<Haber>();
            StringBuilder htmlTable = new StringBuilder();
            kayitlar = database.bes_tablosu(tarih3);

            foreach (var kayit in kayitlar)
            {
                htmlTable.Append("<tr>");

                htmlTable.Append("<td style=\" Text-align:center;font-weight: bold; padding: 6px; \">" + kayit.bes + "</td>");

                htmlTable.Append("</tr>");
            }

            ph_bes_takip.Controls.Add(new Literal { Text = htmlTable.ToString() });

        }

        private void haber_listesi(string tarih3)
        {

            List<Haber> kayitlar = new List<Haber>();
            StringBuilder htmlTable = new StringBuilder();
            kayitlar = database.haber_tablosu(tarih3);

            foreach (var kayit in kayitlar)
            {
                htmlTable.Append("<tr>");

                htmlTable.Append("<td style=\" Text-align:center;font-weight: bold; padding: 6px; \">" + kayit.haber + "</td>");

                htmlTable.Append("</tr>");
            }

            ph_haber_takip.Controls.Add(new Literal { Text = htmlTable.ToString() });

        }

        private void yemek_listesi(string tarih3)
        {


            List<Yemek> kayitlar = new List<Yemek>();
            StringBuilder htmlTable = new StringBuilder();
            kayitlar = database.yemek_tablosu(tarih3);

            foreach (var kayit in kayitlar)
            {
                htmlTable.Append("<tr>");
                htmlTable.Append("<td style=\" Text-align:center;font-weight: bold;color: #635b5b;padding: 6px;\">" + kayit.gun + "</td>");
                htmlTable.Append("<td style=\" Text-align:center;font-weight: bold; padding: 6px; \">" + kayit.menu + "</td>");

                htmlTable.Append("</tr>");
            }

            ph_yemek_takip.Controls.Add(new Literal { Text = htmlTable.ToString() });

        }

        protected void btn_show_hrapor_Click(object sender, EventArgs e)
        {
            Response.Redirect("Forms/holding_raporlari/Default.aspx", false);
        }


        [System.Web.Services.WebMethod]
        public static string aylik_tonaj_verileri_getir()
        {
            Holding_raporu_db dbh = new Holding_raporu_db();
            List<Tonajlar> tonajlar = new List<Tonajlar>();

            DateTime dt = new DateTime();
            dt = DateTime.Now;
            int yil = dt.Year;

            string firma = "DILER";
            string unite = "CH";

            dbh.Connect();
            /** Diler CH */
            tonajlar = dbh.tonajlar_data_read(firma, unite, yil);
            dbh.Disconnect();

            for (int i = tonajlar.Count; i < 12; i++)
            {
                /** Veri girilmemis aylara sıfır degeri ataycagiz. */
                Tonajlar t = new Tonajlar();
                t.Tonaj_id = 1;
                t.Ay = i.ToString();
                t.Tonaj = "0";
                tonajlar.Add(t);
            }



            /** Diler HH  */
            List<Tonajlar> tonajlar3 = new List<Tonajlar>();
            firma = "DILER";
            unite = "HH";
            dbh.Connect();
            tonajlar3 = dbh.tonajlar_data_read(firma, unite, yil);
            dbh.Disconnect();


            for (int i = tonajlar3.Count; i < 12; i++)
            {
                /** Veri girilmemis aylara sıfır degeri ataycagiz. */
                Tonajlar t = new Tonajlar();
                t.Tonaj_id = 1;
                t.Ay = i.ToString();
                t.Tonaj = "0";
                tonajlar3.Add(t);
            }

            /** Filmasin HH  */
            List<Tonajlar> tonajlar5 = new List<Tonajlar>();
            firma = "FILMASIN";
            unite = "HH";

            dbh.Connect();
            tonajlar5 = dbh.tonajlar_data_read(firma, unite, yil);
            dbh.Disconnect();


            for (int i = tonajlar5.Count; i < 12; i++)
            {
                /** Veri girilmemis aylara sıfır degeri ataycagiz. */
                Tonajlar t = new Tonajlar();
                t.Tonaj_id = 1;
                t.Ay = i.ToString();
                t.Tonaj = "0";
                tonajlar5.Add(t);
            }


            string tonaj = "[";
            foreach (var t in tonajlar)
            {
                tonaj += "{\"ay\":\"" + t.Ay + "\",\"tonaj\":\"" + t.Tonaj + "\",\"firma\":\"DILER\"},";
            }

            foreach (var t in tonajlar3)
            {
                tonaj += "{\"ay\":\"" + t.Ay + "\",\"tonaj\":\"" + t.Tonaj + "\",\"firma\":\"DILER\"},";
            }

            foreach (var t in tonajlar5)
            {
                tonaj += "{\"ay\":\"" + t.Ay + "\",\"tonaj\":\"" + t.Tonaj + "\",\"firma\":\"FILMASIN\"},";
            }

            tonaj = tonaj.Trim(',');
            tonaj += "]";
            return (tonaj);
        }

        [System.Web.Services.WebMethod]
        public static string yillik_tonaj_verileri_getir()
        {
            Holding_raporu_db dbh = new Holding_raporu_db();
            List<Tonajlar> tonajlar = new List<Tonajlar>();

            string firma = "DILER";
            string unite = "CH";


            dbh.Connect();
            tonajlar = dbh.yillik_tonajlarch_data_read(firma, unite);
            dbh.Disconnect();


            /** Diler CH */

            for (int i = tonajlar.Count; i < 5; i++)
            {
                /** Veri girilmemis aylara sıfır degeri ataycagiz. */
                Tonajlar t = new Tonajlar();
                t.Tonaj_id = 1;
                t.Yil = i.ToString();
                t.Tonaj = "0";
                tonajlar.Add(t);
            }



            /** Diler HH  */
            List<Tonajlar> tonajlar3 = new List<Tonajlar>();
            firma = "DILER";
            unite = "HH";

            dbh.Connect();
            tonajlar3 = dbh.yillik_tonajlarhh_data_read(firma, unite);
            dbh.Disconnect();



            for (int i = tonajlar3.Count; i < 5; i++)
            {
                /** Veri girilmemis aylara sıfır degeri ataycagiz. */
                Tonajlar t = new Tonajlar();
                t.Tonaj_id = 1;
                t.Yil = i.ToString();
                t.Tonaj = "0";
                tonajlar3.Add(t);
            }



            /** Filmasin HH  */
            List<Tonajlar> tonajlar5 = new List<Tonajlar>();
            firma = "FILMASIN";
            unite = "HH";


            dbh.Connect();
            tonajlar5 = dbh.yillik_tonajlarhh_data_read(firma, unite);
            dbh.Disconnect();




            for (int i = tonajlar5.Count; i < 5; i++)
            {
                /** Veri girilmemis aylara sıfır degeri ataycagiz. */
                Tonajlar t = new Tonajlar();
                t.Tonaj_id = 1;
                t.Yil = i.ToString();
                t.Tonaj = "0";
                tonajlar5.Add(t);
            }

            string tonaj = "[";
            foreach (var t in tonajlar)
            {
                tonaj += "{\"yil\":\"" + t.Yil + "\",\"tonaj\":\"" + t.Tonaj + "\",\"firma\":\"DILER\"},";
            }

            foreach (var t in tonajlar3)
            {
                tonaj += "{\"yil\":\"" + t.Yil + "\",\"tonaj\":\"" + t.Tonaj + "\",\"firma\":\"DILER\"},";
            }

            foreach (var t in tonajlar5)
            {
                tonaj += "{\"yil\":\"" + t.Yil + "\",\"tonaj\":\"" + t.Tonaj + "\",\"firma\":\"FILMASIN\"},";
            }

            tonaj = tonaj.Trim(',');
            tonaj += "]";
            return (tonaj);
        }
    }

}