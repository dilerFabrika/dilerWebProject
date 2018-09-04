using diler.Dal;
using diler.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace diler.Web.Forms.WebRaporlar
{
    public partial class sevkiyat_uretim : System.Web.UI.Page
    {
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [System.Web.Services.WebMethod]
        public static List<string> tike_noya_gore_dno_listele(string tarih, string tike_no)
        {
            EndMuh_raporlar_db db = new EndMuh_raporlar_db();
            List<Sevkiyat_uretim> kayitlar = new List<Sevkiyat_uretim>();
            List<string> properties = new List<string>();

            string tarih_ = tarih.Replace("-", "");//veritabanindaki kayit bicimi

            db.Connect();
            kayitlar = db.tikeyegore_dno_listele_data_read(tarih_, tike_no);
            db.Disconnect();
            StringBuilder htmlTable = new StringBuilder();
            if (kayitlar[0].Id == 0)
            {
                // Kayit Bululnamadı
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan=\"11\">" + kayitlar[0].Kalite + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {

                foreach (var kayit in kayitlar)
                {
                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td  style=\"text-align:center\">" + kayit.Dokum_no + "</td>");
                    htmlTable.Append("<td  style=\"text-align:center\"> " + kayit.Cap + "</td>");
                    htmlTable.Append("<td  style=\"text-align:center\"> " + kayit.Boy + "</td>");
                    htmlTable.Append("<td  style=\"text-align:center\"> " + kayit.Standart + "</td>");
                    htmlTable.Append("<td  style=\"text-align:center\">" + kayit.Kalite + "</td>");
                    htmlTable.Append("</tr>");

                }
            }
            properties.Add(htmlTable.ToString());
            return properties;
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [System.Web.Services.WebMethod]
        public static List<string> dno_veya_capa_gore_listele(string dokum_no, string cap)
        {
            EndMuh_raporlar_db db = new EndMuh_raporlar_db();
            List<Sevkiyat_uretim> kayitlar = new List<Sevkiyat_uretim>();
            List<string> properties = new List<string>();


            db.Connect();
            kayitlar = db.dno_veya_capa_gore_listele_data_read(dokum_no, cap);
            db.Disconnect();
            StringBuilder htmlTable = new StringBuilder();
            if (kayitlar[0].Id == 0)
            {
                // Kayit Bululnamadı
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan=\"11\">" + kayitlar[0].Kalite + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {

                foreach (var kayit in kayitlar)
                {

                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td>" + kayit.Tarih + "</td>");
                    htmlTable.Append("<td>" + kayit.Kalite + "</td>");
                    htmlTable.Append("<td>" + kayit.Kutuk_tonaj.Replace(",",".") + "</td>");
                    htmlTable.Append("<td>" + kayit.Mamul_standart + "</td>");
                    htmlTable.Append("<td>" + kayit.Mamul_cap + "</td>");
                    htmlTable.Append("<td>" + kayit.Mamul_boy + "</td>");
                    htmlTable.Append("<td>" + kayit.Ny + "</td>");
                    htmlTable.Append("<td>" + kayit.Fd + "</td>");
                    htmlTable.Append("<td>" + kayit.Mamul_tonaj.Replace(",", ".") + "</td>");


                    htmlTable.Append("</tr>");

                }
            }
            properties.Add(htmlTable.ToString());
            return properties;
        }



        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [System.Web.Services.WebMethod]
        public static List<string> sipno_ve_capa_gore_listele(string siparis_no, string cap)
        {
            EndMuh_raporlar_db db = new EndMuh_raporlar_db();
            List<Sevkiyat_uretim> kayitlar = new List<Sevkiyat_uretim>();
            List<string> properties = new List<string>();


            db.Connect();
            kayitlar = db.sipno_ve_capa_gore_listele_data_read(siparis_no, cap);
            db.Disconnect();
            StringBuilder htmlTable = new StringBuilder();
            if (kayitlar[0].Id == 0)
            {
                // Kayit Bululnamadı
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan=\"11\">" + kayitlar[0].Kalite + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {

                foreach (var kayit in kayitlar)
                {

                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td>" + kayit.Tarih + "</td>");
                    htmlTable.Append("<td>" + kayit.Kalite + "</td>");
                    htmlTable.Append("<td>" + kayit.Kutuk_tonaj.Replace(",", ".") + "</td>");
                    htmlTable.Append("<td>" + kayit.Mamul_standart + "</td>");
                    htmlTable.Append("<td>" + kayit.Mamul_cap + "</td>");
                    htmlTable.Append("<td>" + kayit.Mamul_boy + "</td>");
                    htmlTable.Append("<td>" + kayit.Ny + "</td>");
                    htmlTable.Append("<td>" + kayit.Fd + "</td>");
                    htmlTable.Append("<td>" + kayit.Mamul_tonaj.Replace(",", ".") + "</td>");

                    htmlTable.Append("</tr>");

                }
            }



            properties.Add(htmlTable.ToString());
            return properties;
        }



        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../../Default2.aspx");
        }
    }
}