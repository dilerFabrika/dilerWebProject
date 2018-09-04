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


namespace diler.Web.Forms.IK
{
    public partial class PerformansRapor : System.Web.UI.Page
    {

        int gerigunsayisi;
        Mesai_db db = new Mesai_db();
        Personel giris_yapan = new Personel();
        List<Personel> personel_listesi = new List<Personel>();
        List<Personel> personel_listesi_test = new List<Personel>();
        List<double> mesailer = new List<double>();
        private object ddl_bagli_birim;

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
                Session.Add("GirisYapan", "Müdür");
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
             //   Pdks_Mesai_Listesi(tx_mesai_tarihii.Text, giris_yapan.Bolum, secili_alt_grup);
                //Pdks_Acık_Mesai_Listesi_test(tx_mesai_tarihi.Text, giris_yapan.Bolum);
            }
            db.Disconnect();
            db.sql_Disconnect();
            DateTime dt = new DateTime();
            dt = DateTime.Now.AddDays(-3);
            string mintarih = String.Format("{0:yyyy-MM-dd}", dt);
            //tx_mesai_tarihi.Attributes.Add("min", mintarih);





        }
        protected void lb_cikis_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("../../Login.aspx");
        }



        protected void ddl_bagli_birim_SelectedIndexChanged(object sender, EventArgs e)
        {
            db.Connect();
            StringBuilder htmlTable = new StringBuilder();
            string secili_alt_grup = ddl_bagli_birim0.SelectedValue.ToString();

            personel_listesini_ekrana_bas(secili_alt_grup);
            db.Disconnect();
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


        private void personelleri_getir(string personel_bolum)
        {
            personel_listesi = db.personel_bilgileri_data_read(0, personel_bolum);
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

        //protected void Pdks_Mesai_Listesi(string mesai_tarihh, string personel_bolum, string secili_alt_grup)
        //{
        //    StringBuilder htmlTable = new StringBuilder();
        //    string mesai_neden = " <select id='mesaineden' style=\"height: 22px;\"> " +
        //                  " <option value = '0'>Seçim Yapınız......" +
        //                  " <option value = 1.1>1.Eleman Eksik 1-a) Yıllık Izın" +
        //                  " <option value = 1.2>1.Eleman Eksik 1-b) İş Kazası" +
        //                  " <option value = 1.3>1.Eleman Eksik 1-c) Raporlu Eleman" +
        //                  " <option value = 1.4>1.Eleman Eksik 1-d) Mazeretli İzin" +
        //                  " <option value = 1.5>1.Eleman Eksik 1-e) Mazeretsiz İzin" +
        //                  " <option value = 1.6>1.Eleman Eksik 1-f) Kadro Eksikliği" +
        //                  " <option value = 1.7>1.Eleman Eksik 1-g) Eğitim" +
        //                  " <option value = 2>2.ARIZA" +
        //                  " <option value = 3>3.PLANLI BAKIM" +
        //                  " <option value = 4>4.EXTRA PROGRAMLI İŞ" +
        //                  " <option value = 5>5.RESMİ TATİL" +
        //                  " <option value = 6>6.DIGER" +
        //                  " </select>";
        //    string mesai_tarih = mesai_tarihh.Replace("-", "");

        //    if (mesai_tarih == "")
        //    {
        //        htmlTable.Append("<tr>");
        //        htmlTable.Append("<td colspan='10'>Personel bilgisi bulunamadı</a></td>");
        //        htmlTable.Append("</tr>");

        //    }
        //    else
        //    {
        //        personel_listesi_test = db.personel_bilgileri_data_read_test(0, mesai_tarih, personel_bolum, secili_alt_grup);

        //        foreach (var personel in personel_listesi_test)
        //        {
        //            if (personel.Hesaplanan > 0)
        //            {
        //                htmlTable.Append("<tr>");
        //                htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER; padding-top: 6px;\">" + personel.Pdksnum + "</td>");
        //                htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER; padding-top: 6px;\">" + personel.Ad + " " + personel.Soyad + "</td>");
        //                htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER; padding-top: 6px;\">" + personel.Bolum + "</td>");
        //                htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER; padding-top: 6px;\">" + personel.Mesai_tarih + "</td>");
        //                htmlTable.Append("<td style=\" TEXT-ALIGN:CENTER; padding-top: 6px;\">" + personel.Hesaplanan + "</td>");
        //                htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER; padding-top: 6px;\">" + personel.Mesai_giris_saati + "</td>");
        //                htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER; padding-top: 6px;\">" + personel.Mesai_cikis_saati + "</td>");
        //                htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER; height: 22px;\">" + mesai_neden + "</td>");
        //                htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER;width:100px;\"><input type='text' style=\"color:#1e88e5;text-align: center; width: 1000px; height: 27px; border-radius: 1px; border: 2px solid #e4effa;font-weight: bold;\"></input></td>");
        //                htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER; padding-top: 6px;\" ><a \"style=\"color: #F00;\" title=\"Onay\" class='mesainedeni';\"> <i  style=\"font-size: 25px;\" class=\"fa fa-check-square\"></i></a></td>");
        //                htmlTable.Append("</tr>");
        //            }
        //        }
        //    }
        //    pkdslistesi.Controls.Add(new Literal { Text = htmlTable.ToString() });
        //}


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
    }


}