using diler.Dal;
using diler.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace diler.Web.Forms.holding_raporlari
{
    public partial class Default : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DateTime dt = new DateTime();
                dt = DateTime.Now;
                string tarih = dt.ToString("yyyyMMdd");
                string yil = tarih.Substring(0, 4);
                string ay = (tarih.Substring(4)).Substring(0, 2);
                txt_tarih.Text = yil + ay;



            }
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

            /** Yazici CH  */
            List<Tonajlar> tonajlar2 = new List<Tonajlar>();
            firma = "YAZICI";
            dbh.Connect();
            tonajlar2 = dbh.tonajlar_data_read(firma, unite, yil);
            dbh.Disconnect();


            for (int i = tonajlar2.Count; i < 12; i++)
            {
                /** Veri girilmemis aylara sıfır degeri ataycagiz. */
                Tonajlar t = new Tonajlar();
                t.Tonaj_id = 1;
                t.Ay = i.ToString();
                t.Tonaj = "0";
                tonajlar2.Add(t);
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

            /** Yazici HH  */
            List<Tonajlar> tonajlar4 = new List<Tonajlar>();
            firma = "YAZICI";
            unite = "HH";
            dbh.Connect();
            tonajlar4 = dbh.tonajlar_data_read(firma, unite, yil);
            dbh.Disconnect();


            for (int i = tonajlar4.Count; i < 12; i++)
            {
                /** Veri girilmemis aylara sıfır degeri ataycagiz. */
                Tonajlar t = new Tonajlar();
                t.Tonaj_id = 1;
                t.Ay = i.ToString();
                t.Tonaj = "0";
                tonajlar4.Add(t);
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
            foreach (var t in tonajlar2)
            {
                tonaj += "{\"ay\":\"" + t.Ay + "\",\"tonaj\":\"" + t.Tonaj + "\",\"firma\":\"YAZICI\"},";
            }
            foreach (var t in tonajlar3)
            {
                tonaj += "{\"ay\":\"" + t.Ay + "\",\"tonaj\":\"" + t.Tonaj + "\",\"firma\":\"DILER\"},";
            }
            foreach (var t in tonajlar4)
            {
                tonaj += "{\"ay\":\"" + t.Ay + "\",\"tonaj\":\"" + t.Tonaj + "\",\"firma\":\"YAZICI\"},";
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

            /** Yazici CH  */
            List<Tonajlar> tonajlar2 = new List<Tonajlar>();
            firma = "YAZICI";
            unite = "CH";
            dbh.Connect();
            tonajlar2 = dbh.yillik_tonajlarch_data_read(firma, unite);
            dbh.Disconnect();



            for (int i = tonajlar2.Count; i < 5; i++)
            {
                /** Veri girilmemis aylara sıfır degeri ataycagiz. */
                Tonajlar t = new Tonajlar();
                t.Tonaj_id = 1;
                t.Yil = i.ToString();
                t.Tonaj = "0";
                tonajlar2.Add(t);
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

            /** Yazici HH  */
            List<Tonajlar> tonajlar4 = new List<Tonajlar>();
            firma = "YAZICI";
            unite = "HH";


            dbh.Connect();
            tonajlar4 = dbh.yillik_tonajlarhh_data_read(firma, unite);
            dbh.Disconnect();



            for (int i = tonajlar4.Count; i < 5; i++)
            {
                /** Veri girilmemis aylara sıfır degeri ataycagiz. */
                Tonajlar t = new Tonajlar();
                t.Tonaj_id = 1;
                t.Yil = i.ToString();
                t.Tonaj = "0";
                tonajlar4.Add(t);
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
            foreach (var t in tonajlar2)
            {
                tonaj += "{\"yil\":\"" + t.Yil + "\",\"tonaj\":\"" + t.Tonaj + "\",\"firma\":\"YAZICI\"},";
            }
            foreach (var t in tonajlar3)
            {
                tonaj += "{\"yil\":\"" + t.Yil + "\",\"tonaj\":\"" + t.Tonaj + "\",\"firma\":\"DILER\"},";
            }
            foreach (var t in tonajlar4)
            {
                tonaj += "{\"yil\":\"" + t.Yil + "\",\"tonaj\":\"" + t.Tonaj + "\",\"firma\":\"YAZICI\"},";
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