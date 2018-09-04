using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
using System.Text;
using diler.Entity;
using diler.Dal;
using System.Web.Services;

namespace diler.Web
{
    public partial class Mesailer : System.Web.UI.Page
    {


        int gerigunsayisi;
        Mesai_db db = new Mesai_db();
        Personel giris_yapan = new Personel();
        List<Personel> personel_listesi = new List<Personel>();
        List<Personel> personel_listesi_test = new List<Personel>();
        List<double> mesailer = new List<double>();
        private object ddl_bagli_birim;

        [System.Web.Services.WebMethod]
        public static string aylik_mesai_bilgileri_to_excel(string ay, string bolum, string personel_alt_grup, string personel_alt_grup_text)
        {
            Mesai_db db = new Mesai_db();
            db.Connect();
            StringBuilder htmlTable = new StringBuilder();
            List<Personel> aylik = new List<Personel>();
            List<Personel> personel_listesi = new List<Personel>();
            double yillik_toplam = 0.0;
            List<double> mesailer = new List<double>();
            int satir = 1;
            int sutun = 1;// Excel'de indisler 1'den baslar

            Excel.Application uygulama = new Excel.Application();
            Excel.Workbook wb = uygulama.Workbooks.Add(System.Reflection.Missing.Value);
            Excel.Worksheet ws = (Excel.Worksheet)wb.Sheets[1];

            ws.Cells[satir++, sutun] = personel_alt_grup_text;
            ws.Cells[satir, sutun++] = "Sicil no";
            ws.Cells[satir, sutun++] = "Adı soyadı";
            for (int i = 1; i <= 31; i++)
            {
                /** hucre arkaplan rengini degistirme
                Excel.Range alan = (Excel.Range)ws.Cells[satir, i+2];
                alan.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.SkyBlue); 
                */
                ws.Cells[satir, sutun++] = i;
            }
            ws.Cells[satir, sutun++] = "Ay";
            //satir++;
            //sutun = 1;

            /********/
            personel_listesi = db.personel_bilgileri_data_read(0, bolum);
            if (personel_listesi[0].Id == 0)
            {
                // Kayit Bulunamadi
                ws.Cells[2, 1] = "Oops! Listelenecek Kayıt Bulunamadı.";
            }
            else
            {
                foreach (var personel in personel_listesi)
                {

                    if (personel_alt_grup != "all" && personel_alt_grup != "sadece-mesaisi-olanlar")
                        if (personel.Alt_grup != personel_alt_grup)
                            continue;

                    List<Mesai_yillik_izin> mesailer_personel = new List<Mesai_yillik_izin>();
                    StringBuilder sb = new StringBuilder();
                    List<double> aylik_mesailer = new List<double>();

                    mesailer_personel = db.personel_yillik_izin_data_read(personel.Sicil_no, Convert.ToInt32(DateTime.Now.Year.ToString() + ay.PadLeft(2, '0')));
                    if (personel_alt_grup == "sadece-mesaisi-olanlar")
                        if (mesailer_personel[0].Personel_sicil_no == 0) // mesaisi yoksa
                            continue;

                    satir++;
                    sutun = 1;


                    //if ((personel.Sicil_no != giris_yapan.Sicil_no))
                    //{
                    ws.Cells[satir, sutun++] = personel.Sicil_no;
                    ws.Cells[satir, sutun++] = personel.Ad + " " + personel.Soyad;
                    //Yillik Mesailer Getirilecek...
                    /***/

                    for (int i = 0; i <= 31; i++)
                    {
                        aylik_mesailer.Add(-1.0);
                    }


                    if (mesailer_personel[0].Personel_sicil_no == 0)
                    {
                        // Kayit Bululnamadi
                        sb.Append("");
                        aylik_mesailer[0] = 1.0;
                    }
                    else
                    {
                        foreach (var mesai in mesailer_personel)
                        {
                            int gun = Convert.ToInt32(mesai.Mesai_tarih.Substring(6, 2));
                            if (aylik_mesailer[gun] > -1)
                            {
                                aylik_mesailer[gun] += mesai.Mesai_toplam_saat;
                            }
                            else
                            {
                                aylik_mesailer[gun] = mesai.Mesai_toplam_saat;
                            }
                        }
                    }
                    /***/
                    double aylik_toplam = 0;
                    for (int i = 1; i <= 31; i++)
                    {
                        if (aylik_mesailer[i] > -1.0)
                        {
                            ws.Cells[satir, sutun++] = aylik_mesailer[i];
                            aylik_toplam += aylik_mesailer[i];
                        }
                        else
                        {
                            sutun++;
                        }
                    }
                    if (aylik_toplam > 0)
                        ws.Cells[satir, sutun++] = aylik_toplam;
                    else
                        sutun++;

                    //satir++;
                    //sutun = 1;
                    yillik_toplam += aylik_toplam;
                    //}
                }
                ws.Cells[++satir, --sutun] = "Toplam : " + yillik_toplam;
            }
            /******/
            db.Disconnect();
            uygulama.Visible = true; // Exceli açar
            return "success";
        }

        [System.Web.Services.WebMethod]
        public static string aylik_mesailer_to_excel(string ay, string bolum, string personel_alt_grup, string personel_alt_grup_text)
        {
            Mesai_db db = new Mesai_db();
            db.Connect();
            StringBuilder htmlTable = new StringBuilder();
            List<Personel> aylik = new List<Personel>();
            int satir = 1;
            int sutun = 1;// 0'dan baslatinca hata veriyor.


            //Excel.Range alan = (Excel.Range)ws.Cells[2,5];
            //alan.Value2 = "Hello world !!";


            Excel.Application uygulama = new Excel.Application();
            Excel.Workbook wb = uygulama.Workbooks.Add(System.Reflection.Missing.Value);
            Excel.Worksheet ws = (Excel.Worksheet)wb.Sheets[1];
            ws.Cells[satir++, sutun] = personel_alt_grup_text;
            ws.Cells[satir, sutun++] = "Sicil no";
            ws.Cells[satir, sutun++] = "Adı soyadı";
            ws.Cells[satir, sutun++] = "Bölüm";
            ws.Cells[satir, sutun++] = "Toplam Saat";

            satir++;
            sutun = 1;

            aylik = db.personel_aylik_izin_data_read(ay, -1, bolum);

            if (aylik[0].Sicil_no == 0)
            {
                // Kayit Bululnamadı
                ws.Cells[1, 1] = "Oops! Listelenecek Kayıt Bulunamadı.";
            }
            else
            {
                foreach (var personel in aylik)
                {
                    if (personel_alt_grup != "all" && personel_alt_grup != "sadece-mesaisi-olanlar")
                        if (personel.Alt_grup != personel_alt_grup)
                            continue;

                    ws.Cells[satir, sutun++] = personel.Sicil_no;
                    ws.Cells[satir, sutun++] = personel.Ad + " " + personel.Soyad;
                    ws.Cells[satir, sutun++] = personel.Alt_grup;
                    ws.Cells[satir, sutun++] = personel.Bolum;

                    sutun = 1;
                    satir++;
                }
            }
            db.Disconnect();
            uygulama.Visible = true;
            return "success";
        }

        // [WebMethod(EnableSession = false)]
        [System.Web.Services.WebMethod]
        public static int Mesai_onay(int kullanici, string mesaineden, int hesaplanan_mesai, string aciklama, int mesai_tarihi,string GirenKim)
        {
            int SONUC=0;

            if (GirenKim.Contains("MÜDÜR"))
            {

                Mesai_db db = new Mesai_db();
                db.Connect();
                db.sql_Connect();
                int personel = db.Mesai_onay_Mudur(kullanici, mesaineden, hesaplanan_mesai, aciklama, mesai_tarihi);

                if (personel == 0)
                {
                    SONUC = 0;
                }
                else
                {
                    db.Disconnect();
                    db.sql_Disconnect();
                    SONUC = 1;
                }
            }
                else
            {
                Mesai_db db = new Mesai_db();
                db.Connect();
                db.sql_Connect();
                int personel = db.Mesai_onay(kullanici, mesaineden, hesaplanan_mesai, aciklama, mesai_tarihi);

                if (personel == 0)
                {
                    SONUC = 0;
                }
                else
                {
                    db.Disconnect();
                    db.sql_Disconnect();
                    SONUC = 1;
                }
            }

            return SONUC;

            // return "Hello: " + kullanici + mesaineden;
        }


        protected void Page_Load(object sender, EventArgs e)

        {
            db.sql_Connect();
            db.Connect();
            int personel_id = 0;

            if (HttpContext.Current.Session["IKIDSI"] != null)
                {
                    personel_id = Convert.ToInt32(Session["Personel_id"]);
                    giris_yapan = giris_kontrol(personel_id);

                    if (giris_yapan.Id == 0)
                    {
                        //Giris Yapilmamis
                        db.Disconnect();
                        Page.Response.Redirect("~/Login.aspx");
                    }
                }
                else
                {
                    db.Disconnect();
                    Page.Response.Redirect("~/Login.aspx");
                }

                if (giris_yapan.Bolum.Contains("Müdür"))
                {
                    personelleri_getir(giris_yapan.Unite);
                    Session.Add("GirisYapan",   "Müdür");
                }
                else
                {
                    personelleri_getir(giris_yapan.Bolum);
                    Session.Add("GirisYapan", "Şef");
                }

            if (!Page.IsPostBack)
            {
                personel_listesini_ekrana_bas();
                bagli_birimleri_listele(giris_yapan.Bolum);
                //Pdks_Acık_Mesai_Listesi( tx_mesai_tarihi.Text, giris_yapan.Bolum);
                string secili_alt_grup = ddl_bagli_birim0.SelectedValue.ToString();
                Pdks_Mesai_Listesi(tx_mesai_tarihii.Text, giris_yapan.Bolum, secili_alt_grup);
                //Pdks_Acık_Mesai_Listesi_test(tx_mesai_tarihi.Text, giris_yapan.Bolum);
            }
            db.Disconnect();
            db.sql_Disconnect();
            DateTime dt = new DateTime();
            dt = DateTime.Now.AddDays(-3);
            string mintarih = String.Format("{0:yyyy-MM-dd}", dt);
            //tx_mesai_tarihi.Attributes.Add("min", mintarih);

        }
        protected void aylik_mesai_bilgilerini_akrana_bas(int ay)
        {
            StringBuilder htmlTable = new StringBuilder();
            double yillik_toplam = 0.0;
            if (personel_listesi[0].Id == 0)
            {
                // Kayit Bulunamadi
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan='18'>" + personel_listesi[0].Ad + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                string personel_alt_grup = ddl_bagli_birim0.SelectedValue.ToString();
                foreach (var personel in personel_listesi)
                {
                    if ((personel.Sicil_no != giris_yapan.Sicil_no))
                    {
                        if (personel_alt_grup != "all" && personel_alt_grup != "sadece-mesaisi-olanlar")
                            if (personel.Alt_grup != personel_alt_grup)
                                continue;

                        mesailer = aylik_mesaileri_getir(personel.Sicil_no, ay);
                        if (personel_alt_grup == "sadece-mesaisi-olanlar")
                            if (mesailer[0] > -1) // mesaisi yoksa
                                continue;

                        htmlTable.Append("<tr>");

                        htmlTable.Append("<td>" + personel.Sicil_no + "</td>");
                        htmlTable.Append("<td>" + personel.Ad + " " + personel.Soyad + "</td>");
                        //Yillik Mesailer Getirilecek...

                        double aylik_toplam = 0;
                        for (int i = 1; i <= 31; i++)
                        {
                            if (mesailer[i] > -1.0)
                            {
                                htmlTable.Append("<td>" + mesailer[i] + "</td>");
                                aylik_toplam += mesailer[i];
                            }
                            else
                            {
                                htmlTable.Append("<td></td>");
                            }
                        }
                        if (aylik_toplam > 0)
                            htmlTable.Append("<td>" + aylik_toplam + "</td>");
                        else
                            htmlTable.Append("<td></td>");

                        yillik_toplam += aylik_toplam;
                        htmlTable.Append("</tr>");
                    }
                }
                htmlTable.Append(
                    "<tr>" +
                    "<td colspan='33' class='text-right'>Toplam :</td>" +
                    "<td>" + yillik_toplam.ToString() + "</td>" +
                    "</tr>"
                );
            }
        }
        private void personelleri_getir(string personel_bolum)
        {
            personel_listesi = db.personel_bilgileri_data_read(0, personel_bolum);
        }

        protected void Pdks_Mesai_Listesi(string mesai_tarihh, string personel_bolum, string secili_alt_grup)
        {
            StringBuilder htmlTable = new StringBuilder();
            string mesai_neden = " <select id='mesaineden' style=\"height: 22px;\"> " +
                          " <option value = '0'>Seçim Yapınız......" +
                          " <option value = 1.1>1.Eleman Eksik 1-a) Yıllık Izın" +
                          " <option value = 1.2>1.Eleman Eksik 1-b) İş Kazası" +
                          " <option value = 1.3>1.Eleman Eksik 1-c) Raporlu Eleman" +
                          " <option value = 1.4>1.Eleman Eksik 1-d) Mazeretli İzin" +
                          " <option value = 1.5>1.Eleman Eksik 1-e) Mazeretsiz İzin" +
                          " <option value = 1.6>1.Eleman Eksik 1-f) Kadro Eksikliği" +
                          " <option value = 1.7>1.Eleman Eksik 1-g) Eğitim" +
                          " <option value = 2>2.ARIZA" +
                          " <option value = 3>3.PLANLI BAKIM" +
                          " <option value = 4>4.EXTRA PROGRAMLI İŞ" +
                          " <option value = 5>5.RESMİ TATİL" +
                          " <option value = 6>6.DIGER" +
                          " </select>";
            string mesai_tarih = mesai_tarihh.Replace("-", "");

            if (mesai_tarih == "")
            {
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan='10'>Personel bilgisi bulunamadı</a></td>");
                htmlTable.Append("</tr>");

            }
            else
            {
                personel_listesi_test = db.personel_bilgileri_data_read_test(0, mesai_tarih, personel_bolum, secili_alt_grup);

                foreach (var personel in personel_listesi_test)
                {
                    if (personel.Hesaplanan > 0)
                    {
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER; padding-top: 6px;\">" + personel.Pdksnum + "</td>");
                        htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER; padding-top: 6px;\">" + personel.Ad + " " + personel.Soyad + "</td>");
                        htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER; padding-top: 6px;\">" + personel.Bolum + "</td>");
                        htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER; padding-top: 6px;\">" + personel.Mesai_tarih + "</td>");
                        htmlTable.Append("<td style=\" TEXT-ALIGN:CENTER; padding-top: 6px;\">" + personel.Hesaplanan + "</td>");
                        htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER; padding-top: 6px;\">" + personel.Mesai_giris_saati + "</td>");
                        htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER; padding-top: 6px;\">" + personel.Mesai_cikis_saati + "</td>");
                        htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER; height: 22px;\">" + mesai_neden + "</td>");
                        htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER;width:100px;\"><input type='text' style=\"color:#1e88e5;text-align: center; width: 1000px; height: 27px; border-radius: 1px; border: 2px solid #e4effa;font-weight: bold;\"></input></td>");
                        htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER; padding-top: 6px;\" ><a \"style=\"color: #F00;\" title=\"Onay\" class='mesainedeni';\"> <i  style=\"font-size: 25px;\" class=\"fa fa-check-square\"></i></a></td>");
                        htmlTable.Append("</tr>");
                    }
                }
            }
            pkdslistesi.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }


        protected void Pdks_Mesai_Listesi_Mudur(string mesai_tarihh, string personel_bolum, string secili_alt_grup, string secilen_tarih)
        {
            StringBuilder htmlTable = new StringBuilder();
            string mesai_neden = " <select id='mesaineden' style=\"height: 22px;\"> " +
                          " <option value = '0'>Seçim Yapınız......" +
                          " <option value = 1.1>1.Eleman Eksik 1-a) Yıllık Izın" +
                          " <option value = 1.2>1.Eleman Eksik 1-b) İş Kazası" +
                          " <option value = 1.3>1.Eleman Eksik 1-c) Raporlu Eleman" +
                          " <option value = 1.4>1.Eleman Eksik 1-d) Mazeretli İzin" +
                          " <option value = 1.5>1.Eleman Eksik 1-e) Mazeretsiz İzin" +
                          " <option value = 1.6>1.Eleman Eksik 1-f) Kadro Eksikliği" +
                          " <option value = 1.7>1.Eleman Eksik 1-g) Eğitim" +
                          " <option value = 2>2.ARIZA" +
                          " <option value = 3>3.PLANLI BAKIM" +
                          " <option value = 4>4.EXTRA PROGRAMLI İŞ" +
                          " <option value = 5>5.RESMİ TATİL" +
                          " <option value = 6>6.DIGER" +
                          " </select>";
            string mesai_tarih = mesai_tarihh.Replace("-", "");

            if (mesai_tarih == "")
            {
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan='10'>Personel bilgisi bulunamadı</a></td>");
                htmlTable.Append("</tr>");

            }
            else
            {
                personel_listesi_test = db.personel_bilgileri_data_read_MUDUR(0, mesai_tarih, personel_bolum, secili_alt_grup, secilen_tarih);

                foreach (var personel in personel_listesi_test)
                {
                    if (personel.Hesaplanan > 0)
                    {
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER; padding-top: 6px;\">" + personel.Pdksnum + "</td>");
                        htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER; padding-top: 6px;\">" + personel.Ad + " " + personel.Soyad + "</td>");
                        htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER; padding-top: 6px;\">" + personel.Bolum + "</td>");
                        htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER; padding-top: 6px;\">" + personel.Mesai_tarih + "</td>");
                        htmlTable.Append("<td style=\" TEXT-ALIGN:CENTER; padding-top: 6px;\">" + personel.Hesaplanan + "</td>");
                        htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER; padding-top: 6px;\">" + personel.Mesai_giris_saati + "</td>");
                        htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER; padding-top: 6px;\">" + personel.Mesai_cikis_saati + "</td>");
                        htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER; height: 22px;\">" + personel.MesaiNedeni + "</td>");
                        htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER; height: 22px;\">" + personel.MesaiAciklaması + "</td>");
                        htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER; padding-top: 6px;\" ><a \"style=\"color: #F00;\" title=\"Onay\" class='mesainedeni';\"> <i  style=\"font-size: 25px;\" class=\"fa fa-check-square\"></i></a></td>");
                        htmlTable.Append("</tr>");
                    }
                }
            }
            pkdslistesi.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }


        protected void bagli_birimleri_listele(string bolum)
        {
            List<ListItem> items = new List<ListItem>();
            items.Add(new ListItem("Tümü", "all"));
            items.Add(new ListItem(" ** Sadece Mesaisi Olanlar", "sadece-mesaisi-olanlar"));
            List<string> eklenenler = new List<string>();

            foreach (var personel in personel_listesi)
            {
                if (eklenenler.IndexOf(personel.Alt_grup) > -1)
                {

                }
                else
                {
                    if (personel.Alt_grup == giris_yapan.Alt_grup)
                        continue;
                    eklenenler.Add(personel.Alt_grup);
                    items.Add(new ListItem(personel.Alt_grup, personel.Alt_grup));
                }
            }
            ddl_bagli_birim0.Items.Clear();
            ddl_bagli_birim0.Items.AddRange(items.ToArray());
        }
        protected List<double> aylik_mesaileri_getir(int personel_sicil_no, int ay)
        {
            List<Mesai_yillik_izin> mesailer_personel = new List<Mesai_yillik_izin>();
            StringBuilder sb = new StringBuilder();
            List<double> aylik_mesailer = new List<double>();
            for (int i = 0; i <= 31; i++)
            {
                aylik_mesailer.Add(-1.0);
            }

            mesailer_personel = db.personel_yillik_izin_data_read(personel_sicil_no, ay);

            if (mesailer_personel[0].Personel_sicil_no == 0)
            {
                // Kayit Bululnamadi
                sb.Append("");
                aylik_mesailer[0] = 1.0;
            }
            else
            {
                foreach (var mesai in mesailer_personel)
                {
                    int gun = Convert.ToInt32(mesai.Mesai_tarih.Substring(6, 2));
                    if (aylik_mesailer[gun] > -1)
                    {
                        aylik_mesailer[gun] += mesai.Mesai_toplam_saat;
                    }
                    else
                    {
                        aylik_mesailer[gun] = mesai.Mesai_toplam_saat;
                    }
                }
            }
            return aylik_mesailer;
        }
        protected List<double> mesaileri_getir(int personel_sicil_no)
        {
            List<Mesai_yillik_izin> mesailer_personel = new List<Mesai_yillik_izin>();
            StringBuilder sb = new StringBuilder();
            List<double> aylik_mesailer = new List<double>();
            for (int i = 0; i <= 12; i++)
            {
                aylik_mesailer.Add(-1.0);
            }

            mesailer_personel = db.personel_yillik_izin_data_read(personel_sicil_no);

            if (mesailer_personel[0].Personel_sicil_no == 0)
            {
                // Kayit Bululnamadı
                sb.Append("");
                aylik_mesailer[0] = 1.0;
            }
            else
            {
                foreach (var mesai in mesailer_personel)
                {
                    int ay = Convert.ToInt32(mesai.Mesai_tarih.Substring(4, 2));
                    if (aylik_mesailer[ay] > -1)
                    {
                        aylik_mesailer[ay] += mesai.Mesai_toplam_saat;
                    }
                    else
                    {
                        aylik_mesailer[ay] = mesai.Mesai_toplam_saat;
                    }
                }
            }
            return aylik_mesailer;
        }
        private Personel giris_kontrol(int personel_id)
        {
            Personel personel = new Personel();
            personel = db.personel_bilgileri_data_read(personel_id)[0];
            if (personel.Id == 0)
            {
                //kayit bulunamadi
                lbl_giris_yapan.Text = personel.Ad;
            }
            else
            {
                //lbl_giris_yapan.Text = "Programa Giriş Yapan: <font color='red'>" + personel.Sicil_no + "</font> Sicil Numarası " + personel.Bolum +":"+ " <font color=\"3752F9\"><strong>" + personel.Ad + " " + personel.Soyad + "</strong></font> " + personel.Alt_grup;
                lbl_giris_yapan.Text = "Programa Giriş Yapan: <font color='red'> <strong>" + personel.Ad + " " + personel.Soyad + "</strong> - " + personel.Alt_grup + "</font>";
            }
            return personel; 
        }
        private void personel_listesini_ekrana_bas(string personel_alt_grup = "all")
        {
            StringBuilder htmlTable = new StringBuilder();

            if (personel_listesi[0].Id == 0)
            {
                // Kayit Bulunamadi
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan='18'>" + personel_listesi[0].Ad + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var personel in personel_listesi)
                {
                    if ((personel.Sicil_no != giris_yapan.Sicil_no))
                    {
                        if (personel_alt_grup != "all" && personel_alt_grup != "sadece-mesaisi-olanlar")
                            if (personel.Alt_grup != personel_alt_grup)
                                continue;

                        mesailer = mesaileri_getir(personel.Sicil_no);
                        if (personel_alt_grup == "sadece-mesaisi-olanlar")
                            if (mesailer[0] > -1) // mesaisi yoksa
                                continue;

                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td><a class='a_personel_ayrinti_getir' href=\"javascript:__doPostBack('btn_personel_ayrinti_getir','" + personel.Sicil_no + "')\" title='Getir'>Getir</a></td>");
                        htmlTable.Append("<td>" + personel.Sicil_no + "</td>");
                        htmlTable.Append("<td>" + personel.Ad + " " + personel.Soyad + "</td>");
                        htmlTable.Append("<td>" + personel.Alt_grup + "</td>");

                        htmlTable.Append("<td></td>");
                        //Yillik Mesailer Getirilecek...
                        double yillik_toplam = 0;
                        for (int i = 1; i <= 12; i++)
                        {
                            if (mesailer[i] > -1.0)
                            {
                                htmlTable.Append("<td>" + mesailer[i] + "</td>");
                                yillik_toplam += mesailer[i];
                            }
                            else
                            {
                                htmlTable.Append("<td></td>");
                            }
                        }
                        if (yillik_toplam > 0)
                            htmlTable.Append("<td>" + yillik_toplam + "</td>");
                        else
                            htmlTable.Append("<td></td>");

                        htmlTable.Append("</tr>");
                    }
                }
            }
            ph_personel_listesi.Controls.Clear();
            ph_personel_listesi.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }
        protected void personeli_ekrana_bas(int sicil_no)
        {
            foreach (var personel in personel_listesi)
            {
                if (personel.Sicil_no == sicil_no)
                {
                    lbl_isim.Text = personel.Ad + " " + personel.Soyad;
                    lbl_sicil_no.Text = personel.Sicil_no.ToString();
                    lbl_dogum_tarihi.Text = personel.Dogum_tarihi.Substring(6, 2) + "." + personel.Dogum_tarihi.Substring(4, 2) + "." + personel.Dogum_tarihi.Substring(0, 4);
                    lbl_medeni_hali.Text = personel.Medeni_hali;
                    if (personel.Unite_gecis_tarihi.Length == 6)
                    {
                        lbl_ise_baslama_tarihi.Text = personel.Unite_gecis_tarihi.Substring(6, 2) + "." + personel.Unite_gecis_tarihi.Substring(4, 2) + "." + personel.Unite_gecis_tarihi.Substring(0, 4);
                    }
                    else
                    {
                        lbl_ise_baslama_tarihi.Text = personel.Unite_gecis_tarihi;
                    }


                    lbl_egitim_durumu.Text = personel.Egitim_durumu;
                    lbl_kisim_kodu.Text = personel.Kisim_kodu.ToString();


                    var GirenKim = HttpContext.Current.Session["Personel_id"].ToString();
                    var GireninUnitesi = HttpContext.Current.Session["GirisYapan"].ToString();

                    var VARMI = GireninUnitesi.IndexOf("Şef");
                    if (GireninUnitesi == "Şef")
                    {
                        btn_Kayit.Enabled = true;
                    }
                    else
                    { btn_Kayit.Enabled = false; }



                    
                    break;
                }
            }
        }
        protected void mesaileri_ekrana_bas(int personel_sicil_no)
        {
            StringBuilder htmlTable = new StringBuilder();
            List<Mesai_yillik_izin> mesailer_personel = new List<Mesai_yillik_izin>();

            mesailer_personel = db.personel_yillik_izin_data_read(personel_sicil_no);

            if (mesailer_personel[0].Personel_sicil_no == 0)
            {
                // Kayit Bulunamadı

            }
            else
            {
                foreach (var mesai in mesailer_personel)
                {
                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td>" + mesai.Mesai_nedeni + "</td>");
                    htmlTable.Append("<td>" + mesai.Mesai_tarih.Substring(6, 2) + "." + mesai.Mesai_tarih.Substring(4, 2) + "." + mesai.Mesai_tarih.Substring(0, 4) + "</td>");
                    htmlTable.Append("<td>" + mesai.Mesai_toplam_saat + "</td>");
                    htmlTable.Append("<td>" + mesai.Mesai_genel_aciklama + "</td>");
                    htmlTable.Append("<td><a href=\"javascript:javascript:__doPostBack('lb_secili_personele_ait_kayitlar','" + mesai.Personel_sicil_no + "," + mesai.Mesai_tarih + "," + mesai.Mesai_toplam_saat + "')\" class=\"on-default remove-row\" style=\"color: #F00;\" title=\"Sil\" onclick=\"return confirm('Kaydı Silmek İstediğinizden Emin Misiniz?');\"><i class=\"fa fa-trash-o\"></i></a></td>");
                    htmlTable.Append("</tr>");
                }
            }
            ph_secili_personele_ait_kayitlar.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }
        protected void mesaileri_ekrana_bas_Tek_Kisi(int personel_sicil_no)
        {
            StringBuilder htmlTable = new StringBuilder();
            List<Mesai_yillik_izin> mesailer_personel = new List<Mesai_yillik_izin>();

            mesailer_personel = db.personel_yillik_izin_data_read_Tek_Kisi(personel_sicil_no);

            if (mesailer_personel[0].Personel_sicil_no == 0)
            {
                // Kayit Bulunamadı

            }
            else
            {
                foreach (var mesai in mesailer_personel)
                {
                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td>" + mesai.Mesai_nedeni + "</td>");
                    htmlTable.Append("<td>" + mesai.Mesai_tarih.Substring(6, 2) + "." + mesai.Mesai_tarih.Substring(4, 2) + "." + mesai.Mesai_tarih.Substring(0, 4) + "</td>");
                    htmlTable.Append("<td>" + mesai.Mesai_toplam_saat + "</td>");
                    htmlTable.Append("<td>" + mesai.Mesai_genel_aciklama + "</td>");
                    htmlTable.Append("<td><a href=\"javascript:javascript:__doPostBack('lb_secili_personele_ait_kayitlar','" + mesai.Personel_sicil_no + "," + mesai.Mesai_tarih + "," + mesai.Mesai_toplam_saat + "')\" class=\"on-default remove-row\" style=\"color: #F00;\" title=\"Sil\" onclick=\"return confirm('Kaydı Silmek İstediğinizden Emin Misiniz?');\"><i class=\"fa fa-trash-o\"></i></a></td>");
                    htmlTable.Append("</tr>");
                }
            }
            ph_secili_personele_ait_kayitlar.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }

        protected void btn_personel_ayrinti_getir_Click(object sender, EventArgs e)
        {
            db.sql_Connect();
            db.Connect();
            btn_Kayit.Enabled = false;
            string parameter = Request["__EVENTARGUMENT"].ToString();
            int personel_sicil_no = Convert.ToInt32(parameter);

            personel_fotosunu_ekrana_bas(personel_sicil_no);

            personel_listesini_ekrana_bas(ddl_bagli_birim0.SelectedValue);
            personeli_ekrana_bas(personel_sicil_no);
            mesaileri_ekrana_bas_Tek_Kisi(personel_sicil_no);
            string secili_alt_grup = ddl_bagli_birim0.SelectedValue.ToString();
            Pdks_Mesai_Listesi(tx_mesai_tarihii.Text, giris_yapan.Bolum, secili_alt_grup);
            db.Disconnect();
            db.sql_Disconnect();
        }
        protected void personel_fotosunu_ekrana_bas(int sicil_no)
        {
            foreach (var personel in personel_listesi)
            {
                if (personel.Sicil_no == sicil_no)
                {
                    img_secilen_personel.ImageUrl = "/tum_fotolar/" + personel.Tc_no + "-" + personel.Sicil_no + ".JPG";
                    break;
                }
            }
        }

        protected void lb_secili_personele_ait_kayitlar_Click(object sender, EventArgs e)
        {
            db.sql_Connect();
            db.Connect();
            string parameter = Request["__EVENTARGUMENT"].ToString();
            if (db.personel_yillik_izin_sil(parameter))
            {
                //mesaileri_ekrana_bas( Convert.ToInt32(lbl_sicil_no.Text) );
                //Page.Response.Redirect("~/Mesailer.aspx", true);
            }

            personel_listesini_ekrana_bas(ddl_bagli_birim0.SelectedValue);
            personeli_ekrana_bas(Convert.ToInt32(lbl_sicil_no.Text));
            mesaileri_ekrana_bas(Convert.ToInt32(lbl_sicil_no.Text));
            string secili_alt_grup = ddl_bagli_birim0.SelectedValue.ToString();
            Pdks_Mesai_Listesi(tx_mesai_tarihii.Text, giris_yapan.Bolum, secili_alt_grup);
            db.Disconnect();
            db.sql_Disconnect();
        }

        protected void lb_aylik_mesaileri_getir_Click(object sender, EventArgs e)
        {
            db.sql_Connect();
            db.Connect();
            StringBuilder htmlTable = new StringBuilder();
            List<Personel> aylik = new List<Personel>();
            string parameter = Request["__EVENTARGUMENT"].ToString();

            string ay = ay_getir(Convert.ToInt32(parameter));
        
            aylik = db.personel_aylik_izin_data_read(parameter, -1, giris_yapan.Bolum);

            if (aylik[0].Sicil_no == 0)
            {
                // Kayit Bululnamadı
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan=\"4\">Oops! Listelenecek Kayıt Bulunamadı.</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                string personel_alt_grup = ddl_bagli_birim0.SelectedValue.ToString();
                foreach (var personel in aylik)
                {
                    if (personel_alt_grup != "all" && personel_alt_grup != "sadece-mesaisi-olanlar")
                        if (personel.Alt_grup != personel_alt_grup)
                            continue;

                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td>" + personel.Sicil_no + "</td>");
                    htmlTable.Append("<td>" + personel.Ad + " " + personel.Soyad + "</td>");
                    htmlTable.Append("<td>" + personel.Alt_grup + "</td>");
                    htmlTable.Append("<td>" + personel.Bolum + "</td>");
                    htmlTable.Append("</tr>");
                }
            }
            personel_listesini_ekrana_bas(ddl_bagli_birim0.SelectedValue);
            string secili_alt_grup = ddl_bagli_birim0.SelectedValue.ToString();
            Pdks_Mesai_Listesi(tx_mesai_tarihii.Text, giris_yapan.Bolum, secili_alt_grup);

            if (lbl_sicil_no.Text != "...")
            {
                personeli_ekrana_bas(Convert.ToInt32(lbl_sicil_no.Text));
                mesaileri_ekrana_bas(Convert.ToInt32(lbl_sicil_no.Text));
            }
            /** Aylik Mesai Bilgileri */
            int ay2 = Convert.ToInt32(DateTime.Now.Year.ToString() + parameter.PadLeft(2, '0'));
            aylik_mesai_bilgilerini_akrana_bas(ay2);

            db.Disconnect();
            db.sql_Disconnect();
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

        protected void ddl_bagli_birim_SelectedIndexChanged(object sender, EventArgs e)
        {
            db.Connect();
            StringBuilder htmlTable = new StringBuilder();
            string secili_alt_grup = ddl_bagli_birim0.SelectedValue.ToString();

            personel_listesini_ekrana_bas(secili_alt_grup);
            db.Disconnect();
        }


        protected void lb_cikis_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("../../Login.aspx");
        }

        protected void btn_tarihe_gore_mesai_Click(object sender, EventArgs e)
        {
            lbl_sonucc.Text = "";
            db.Connect();
            db.sql_Connect();
            if (tx_mesai_tarihii.Text == "")
            {
                lbl_sonucc.Text = "Tarih seçinizz  !!";

            }
            else
            {
                string secili_alt_grup = ddl_bagli_birim0.SelectedValue.ToString();

                gerigunsayisi = GeriGunsayisiBul();
                DateTime dt = new DateTime();
                dt = DateTime.Now.AddDays(-1 * gerigunsayisi);
                string mintarih = String.Format("{0:yyyyMMdd}", dt);
                
                string mesai_tarih = tx_mesai_tarihii.Text.Replace("-", "");
                string now_month = mintarih.ToString().Substring(4, 2);
                string secilen_ay = mesai_tarih.Substring(4, 2);
                string now_day = mintarih.ToString().Substring(6, 2);
                string secilen_gun = mesai_tarih.Substring(6, 2);
                string secilen_tarih = String.Format("{0:yyyyMMdd}", tx_mesai_tarihii.Text);

                //if (Convert.ToInt32(now_month) == Convert.ToInt32(secilen_ay))
                //{
                //    if (Convert.ToInt32(secilen_gun) >= Convert.ToInt32(now_day))
                //    {

                        if (lbl_giris_yapan.Text.Contains("MÜDÜR"))

                            { Pdks_Mesai_Listesi_Mudur(mesai_tarih, giris_yapan.Bolum, secili_alt_grup, secilen_tarih); }
                        else
                            { Pdks_Mesai_Listesi(mesai_tarih, giris_yapan.Bolum, secili_alt_grup); }
                        
                        
                    //}
                    //else
                    //{

                    //    lbl_sonucc.Text = "En fazla 3 gün önceki mesaileri onaylayabilirsiniz !! ";
                    //}

                //}
            }
            personel_listesini_ekrana_bas();
     //       bagli_birimleri_listele(giris_yapan.Bolum);
            db.Disconnect();
            db.sql_Disconnect();
        }
        protected int GeriGunsayisiBul()
        {
            db.Connect();
            gerigunsayisi = db.geri_gun_sayisi_bul();
            return gerigunsayisi;
            db.Disconnect();

        }
        protected void btn_Kayit_Click(object sender, EventArgs e)
        {

            db.sql_Connect();
            db.Connect();
            string trh = tx_mesai_tarihi.Text;
            if (trh != "")
            {
                DateTime dt = new DateTime();
             //   dt = DateTime.Now.AddDays(-3);
               // string mintarih = String.Format("{0:yyyyMMdd}", dt);
                string mesai_tarih = trh.Replace("-", "");
                string now_month = mesai_tarih.ToString().Substring(4, 2);
                string secilen_ay = mesai_tarih.Substring(4, 2);

                string now_day = mesai_tarih.ToString().Substring(6, 2);
                string secilen_gun = mesai_tarih.Substring(6, 2);

                //if (Convert.ToInt32(now_month) == Convert.ToInt32(secilen_ay))
                //{
                   
                        if (tx_toplam_saati.Text == "")
                        {
                            lbl_sonuc.Text = "Toplam saati giriniz ";
                        }
                        else
                        {
                            Mesai_yillik_izin mesai = new Mesai_yillik_izin();
                            // mesai.Mesai_cikis_tipi = ddl_mesai_cikis_tipi.SelectedItem.Value;
                            mesai.Mesai_tarih = tx_mesai_tarihi.Text;
                            mesai.Mesai_cikis_tipi = "Fazla Mesai";
                            mesai.Mesai_nedeni = ddl_mesai_nedeni.SelectedValue;
                            mesai.Mesai_toplam_saat = Convert.ToDouble(tx_toplam_saati.Text);
                            mesai.Mesai_genel_aciklama = tx_genel_aciklama.Text;
                            mesai.Personel_sicil_no = Convert.ToInt32(lbl_sicil_no.Text);

                            if (db.personel_yillik_izin_kaydet(mesai))
                                lbl_sonuc.Text = "Başarıyla Kaydedildi.";
                            else
                                lbl_sonuc.Text = "!!!! Kayıt Sırasında Hata Oluştu.";
                        }
                  
                   
                   // }
                }
           
            else { lbl_sonuc.Text = "Tarih seçiniz !! "; }

            personel_listesini_ekrana_bas(ddl_bagli_birim0.SelectedValue);
            personeli_ekrana_bas(Convert.ToInt32(lbl_sicil_no.Text));
            mesaileri_ekrana_bas(Convert.ToInt32(lbl_sicil_no.Text));
            string secili_alt_grup = ddl_bagli_birim0.SelectedValue.ToString();
            Pdks_Mesai_Listesi(tx_mesai_tarihii.Text, giris_yapan.Bolum, secili_alt_grup);
            //Page.Response.Redirect("~/Mesailer.aspx", true);
            db.sql_Disconnect();
            db.Disconnect();
        }

    }
}