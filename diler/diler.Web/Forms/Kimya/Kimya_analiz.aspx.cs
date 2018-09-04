
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Services;
using System.Web.Script.Services;
using System.Web.UI.WebControls;
using System.Text;
using diler.Dal;
using diler.Entity;


namespace diler.Web.Forms.Kimya
{
    public partial class Kimya_analiz : System.Web.UI.Page
    {
        dynamic kullanici;
        Kimya_analiz_db db = new Kimya_analiz_db();
        List<Kimya_lab_analiz> analizler = new List<Kimya_lab_analiz>();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {

                kullanici = Session["KULLANICI"];

                if (kullanici != "OPRKIM")
                {
                    txt_deger.Visible = false;
                    cmb_yer.Visible = false;
                    cmb_yer2.Visible = false;
                    btn_degistir.Visible = false;
                    btn_sil.Visible = false;
                    cmb_element.Visible = false;
                }
            }
        }

        private void kimya_lab_analizleri_getir(int dokum_no)
        {
            db.Connect();
            analizler = db.kimya_lab_analiz_data_read(dokum_no);
            dokum_ayrinti(dokum_no);
            db.Disconnect();
        }
        private void dokum_ayrinti(int dokum_no)
        {
            StringBuilder htmlTable = new StringBuilder();
            htmlTable.Clear();
            List<Kimya_lab_analiz> kayitlar = new List<Kimya_lab_analiz>();
            kayitlar = db.dokum_ayrinti(dokum_no);
            if (kayitlar[0].Analiz_id == 0)
            {
                //kayit bulunamadi
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan='21'>" + kayitlar[0].Aciklama + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var kayit in kayitlar)
                {

                    htmlTable.Append("<tr>");
                    htmlTable.Append("<td style=\"text-align:center\">" + kayit.Dokum_tarihi + "</td>");
                    htmlTable.Append("<td style=\"text-align:center\">" + kayit.Celik_cinsi + "</td>");
                    htmlTable.Append("<td style=\"text-align:center\">" + kayit.Boy + "</td>");
                    htmlTable.Append("<td style=\"text-align:center\">" + kayit.Ebat + "</td>");
                    htmlTable.Append("<td style=\"text-align:center\">" + kayit.Adet + "</td>");
                    htmlTable.Append("<td style=\"text-align:center\">" + kayit.Aciklama + "</td>");


                }
            }
            ph_dokum_ayrinti.Controls.Clear();
            ph_dokum_ayrinti.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }

        private void analizler_1_ekrana_bas()
        {
            StringBuilder htmlTable = new StringBuilder();
            htmlTable.Clear();
            List<Kimya_lab_analiz> kayitlar = new List<Kimya_lab_analiz>();
            kayitlar = analizler;
            if (analizler[0].Analiz_id == 0)
            {
                //kayit bulunamadi
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan='21'>" + analizler[0].Yer + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var k in analizler)
                {

                    double Alsol = double.Parse(k.Alsol, System.Globalization.CultureInfo.InvariantCulture);
                    double Al = double.Parse(k.Al, System.Globalization.CultureInfo.InvariantCulture);

                    // analizler_1_ekrana_bas
                    if (k.Yer != "S1")
                    {
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td>" + k.Yer + "</td>");
                        htmlTable.Append("<td>" + k.Dokum_no + "</td>");

                        htmlTable.Append("<td>" + k.C + "</td>");
                        htmlTable.Append("<td>" + k.Si + "</td>");
                        htmlTable.Append("<td>" + k.S + "</td>");
                        htmlTable.Append("<td>" + k.P + "</td>");
                        htmlTable.Append("<td>" + k.Mn + "</td>");
                        htmlTable.Append("<td>" + k.Ni + "</td>");

                        htmlTable.Append("<td>" + k.Cr + "</td>");
                        htmlTable.Append("<td>" + k.Mo + "</td>");
                        htmlTable.Append("<td>" + k.V + "</td>");
                        htmlTable.Append("<td>" + k.Cu + "</td>");
                        htmlTable.Append("<td>" + k.W + "</td>");
                        htmlTable.Append("<td>" + k.Sn + "</td>");

                        htmlTable.Append("<td>" + k.Co + "</td>");
                        htmlTable.Append("<td>" + k.Al + "</td>");
                        htmlTable.Append("<td>" + k.Alsol + "</td>");
                        htmlTable.Append("<td>" + k.Alinsol + "</td>");
                        htmlTable.Append("<td>" + k.Pb + "</td>");

                        htmlTable.Append("<td>" + (Alsol / Al).ToString("0.##").Replace(",", ".") + "</td>");
                        htmlTable.Append("<td></td>");

                        htmlTable.Append("</tr>");
                    }
                    else
                    {
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\">" + k.Yer + "</td>");
                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\">" + k.Dokum_no + "</td>");

                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\">" + k.C + "</td>");
                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\">" + k.Si + "</td>");
                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\">" + k.S + "</td>");
                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\">" + k.P + "</td>");
                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\">" + k.Mn + "</td>");
                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\">" + k.Ni + "</td>");

                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\">" + k.Cr + "</td>");
                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\">" + k.Mo + "</td>");
                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\">" + k.V + "</td>");
                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\">" + k.Cu + "</td>");
                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\">" + k.W + "</td>");
                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\">" + k.Sn + "</td>");

                        htmlTable.Append("<td style =\"background-color:#c8d9de;font-weight:bold\">" + k.Co + "</td>");
                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\">" + k.Al + "</td>");
                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\">" + k.Alsol + " </td>");
                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\">" + k.Alinsol + "</td>");
                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\">" + k.Pb + "</td>");

                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\">" + Math.Round((Convert.ToDouble(k.Alsol) / Convert.ToDouble(k.Al)), 2).ToString().Replace(",", ".") + "</td>");
                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\">" + k.Ract + "</td>");
                        htmlTable.Append("</tr>");

                    }

                }
            }
            ph_kimya_lab_analiz_1.Controls.Clear();
            ph_kimya_lab_analiz_1.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }

        private void analizler_2_ekrana_bas()
        {
            StringBuilder htmlTable = new StringBuilder();
            htmlTable.Clear();
            List<Kimya_lab_analiz> kayitlar = new List<Kimya_lab_analiz>();
            kayitlar = analizler;
            if (analizler[0].Analiz_id == 0)
            {
                //kayit bulunamadi
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan='31'>" + analizler[0].Yer + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var k in analizler)
                {
                    double B3 = 0.0, B4 = 0.0, B5 = 0.0, B6 = 0.0, B7 = 0.0, B8 = 0.0, B9 = 0.0, B10 = 0.0, B11 = 0.0, hesap_Tliq = 0.0, hesap_cu_8_sn = 0.0;

                    double B2 = double.Parse(k.C, System.Globalization.CultureInfo.InvariantCulture);
                    B3 = double.Parse(k.Si, System.Globalization.CultureInfo.InvariantCulture);
                    B4 = double.Parse(k.Mn, System.Globalization.CultureInfo.InvariantCulture);
                    B5 = double.Parse(k.Cr, System.Globalization.CultureInfo.InvariantCulture);
                    B6 = double.Parse(k.S, System.Globalization.CultureInfo.InvariantCulture);
                    B7 = double.Parse(k.Mo, System.Globalization.CultureInfo.InvariantCulture);
                    B8 = double.Parse(k.Ni, System.Globalization.CultureInfo.InvariantCulture);
                    B9 = double.Parse(k.P, System.Globalization.CultureInfo.InvariantCulture);
                    B10 = double.Parse(k.Sn, System.Globalization.CultureInfo.InvariantCulture);
                    B11 = double.Parse(k.Cu, System.Globalization.CultureInfo.InvariantCulture);

                    if (B2 <= 0.55)
                        hesap_Tliq = 1538 - ((B2 * 76.24) + (B2 * B2 * 10.3542) + (B3 * 11.66) + (B2 * B3 * 4.3512 + (B4 * 5.62) +

                            (B2 * B4 * 0.223) + (B5 * 1.95) + (B2 * B5 * 0.0329) + (B7 * 2.2) + (B2 * B7 * 0.8451) + (B8 * 3.58) +

                            (B2 * B8 * 0.8364) + (B9 * 24.78) + (B2 * B9 * 12.9409 + (B2 * B6 * 17.7234) + (B6 * 32.81))));
                    if (B2 >= 0.56)
                        hesap_Tliq = 1528 - ((60.09 * B2) + (6.1399 * B2 * B2) + (11.49 * B3) + (5.6055 * B2 * B3) +

                            (4.26 * B4) - (0.453 * B2 * B4) - (2.47 * B5) - (1.3303 * B2 * B5) + (4.36 * B7) - (0.0701 * B2 * B7) +

                            (1.97 * B8) + (0.5886 * B2 * B8) + (30.92 * B9) + (5.3494 * B2 * B9) + (33.19 * B6) + (10.09 * B2 * B6));

                    hesap_Tliq = Math.Round(hesap_Tliq, 2);

                    hesap_cu_8_sn = Math.Round((B11 + (8 * B10)), 3);

                    if (k.Yer != "S1")
                    {
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td>" + k.Yer + "</td>");
                        htmlTable.Append("<td>" + k.Dokum_no + "</td>");

                        htmlTable.Append("<td>" + k.B + "</td>");

                        htmlTable.Append("<td>" + k.Bsol + "</td>");
                        htmlTable.Append("<td>" + k.Binsol + "</td>");
                        htmlTable.Append("<td>" + k.Sb + "</td>");
                        htmlTable.Append("<td>" + k.Nb + "</td>");
                        htmlTable.Append("<td>" + k.Ca + "</td>");
                        htmlTable.Append("<td>" + k.Casol + "</td>");

                        htmlTable.Append("<td>" + k.Cainso + "</td>");
                        htmlTable.Append("<td>" + k.Zn + "</td>");
                        htmlTable.Append("<td>" + k.N + "</td>");
                        htmlTable.Append("<td>" + k.Ti + "</td>");
                        htmlTable.Append("<td>" + k.Tisol + "</td>");
                        htmlTable.Append("<td>" + k.Tiinsol + "</td>");

                        htmlTable.Append("<td>" + k.Ass + "</td>");
                        htmlTable.Append("<td>" + k.Zr + "</td>");
                        htmlTable.Append("<td>" + k.Bi + "</td>");
                        htmlTable.Append("<td>" + k.O + "</td>");
                        htmlTable.Append("<td>" + k.Fe + "</td>");
                        htmlTable.Append("<td>" + k.Ceq + "</td>");
                        htmlTable.Append("<td>" + k.Ce + "</td>");
                        htmlTable.Append("<td>" + hesap_Tliq.ToString().Replace(",", ".") + "</td>");
                        htmlTable.Append("<td>" + hesap_cu_8_sn.ToString().Replace(",", ".") + "</td>");
                        htmlTable.Append("<td></td>");

                        htmlTable.Append("</tr>");
                    }
                    else
                    {
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\">" + k.Yer + "</td>");
                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\">" + k.Dokum_no + "</td>");

                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\">" + k.B + "</td>");

                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\">" + k.Bsol + "</td>");
                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\">" + k.Binsol + "</td>");
                        htmlTable.Append("<td style =\"background-color:#c8d9de;font-weight:bold\">" + k.Sb + "</td>");
                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\">" + k.Nb + "</td>");
                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\">" + k.Ca + " </td>");
                        htmlTable.Append("<td style =\"background-color:#c8d9de;font-weight:bold\">" + k.Casol + " </td>");

                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\">" + k.Cainso + "</td>");
                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\">" + k.Zn + "</td>");
                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\">" + k.N + "</td>");
                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\">" + k.Ti + "</td>");
                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\">" + k.Tisol + "</td>");
                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\">" + k.Tiinsol + "</td>");

                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\">" + k.Ass + "</td>");
                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\">" + k.Zr + "</td>");
                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\">" + k.Bi + "</td>");
                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\">" + k.O + "</td>");
                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\">" + k.Fe + "</td>");
                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\">" + k.Ceq + "</td>");
                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\">" + k.Ce + "</td>");
                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\">" + hesap_Tliq.ToString().Replace(",", ".") + "</td>");
                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\">" + hesap_cu_8_sn.ToString().Replace(",", ".") + "</td>");
                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\"></td>");

                        htmlTable.Append("</tr>");

                    }

                }
            }
            ph_kimya_lab_analiz_2.Controls.Clear();
            ph_kimya_lab_analiz_2.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }

        private void analizler_3_ekrana_bas()
        {
            StringBuilder htmlTable = new StringBuilder();
            htmlTable.Clear();
            List<Kimya_lab_analiz> kayitlar = new List<Kimya_lab_analiz>();
            kayitlar = analizler;

            if (kayitlar[0].Analiz_id == 0)
            {
                //kayit bulunamadi
                htmlTable.Append("<tr>");
                htmlTable.Append("<td colspan='21'>" + kayitlar[0].Yer + "</td>");
                htmlTable.Append("</tr>");
            }
            else
            {
                foreach (var k in kayitlar)
                {
                    double hesap_CuEQ = 0.0;
                    double cu = double.Parse(k.Cu, System.Globalization.CultureInfo.InvariantCulture);
                    double sn = double.Parse(k.Sn, System.Globalization.CultureInfo.InvariantCulture);
                    double sb = double.Parse(k.Sb, System.Globalization.CultureInfo.InvariantCulture);
                    double ni = double.Parse(k.Ni, System.Globalization.CultureInfo.InvariantCulture);
                    double mn = double.Parse(k.Mn, System.Globalization.CultureInfo.InvariantCulture);
                    double s = double.Parse(k.S, System.Globalization.CultureInfo.InvariantCulture);
                    double si = double.Parse(k.Si, System.Globalization.CultureInfo.InvariantCulture);

                    hesap_CuEQ = Math.Round((cu + (10 * sn) + (10 * sb) - ni), 2);

                    if (k.Yer != "S1")
                    {
                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td>" + k.Yer + "</td>");
                        htmlTable.Append("<td>" + k.Dokum_no + "</td>");

                        htmlTable.Append("<td>" + k.Crnicu + "</td>");

                        htmlTable.Append("<td>" + k.Alcao + "</td>");
                        htmlTable.Append("<td>" + k.Almgo + "</td>");
                        htmlTable.Append("<td>" + k.Alsio + "</td>");
                        htmlTable.Append("<td>" + k.Altio + "</td>");
                        htmlTable.Append("<td>" + k.Alca + "</td>");
                        htmlTable.Append("<td>" + k.Alo + "</td>");

                        htmlTable.Append("<td>" + k.Cao + "</td>");
                        htmlTable.Append("<td>" + k.Cas + "</td>");
                        htmlTable.Append("<td>" + k.Tio + "</td>");
                        htmlTable.Append("<td>" + k.Tial + "</td>");
                        htmlTable.Append("<td>" + k.Mns + "</td>");
                        htmlTable.Append("<td>" + k.Mgo + "</td>");

                        htmlTable.Append("<td>" + k.Zro + "</td>");
                        htmlTable.Append("<td>" + k.Sio + "</td>");
                        htmlTable.Append("<td>" + hesap_CuEQ.ToString() + "</td>");
                        htmlTable.Append("<td>" + Math.Round((mn / s), 2).ToString().Replace(",", ".") + "</td>");
                        htmlTable.Append("<td>" + Math.Round((mn / si), 2).ToString().Replace(",", ".") + "</td>");
                        htmlTable.Append("<td></td>");

                        htmlTable.Append("</tr>");
                    }
                    else
                    {
                        htmlTable.Append("<tr style=\";\">");
                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\">" + k.Yer + "</td>");
                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\">" + k.Dokum_no + "</td>");

                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\">" + k.Crnicu + "</td>");

                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\">" + k.Alcao + "</td>");
                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\">" + k.Almgo + "</td>");
                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\">" + k.Alsio + "</td>");
                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\">" + k.Altio + "</td>");
                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\">" + k.Alca + "</td>");
                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\">" + k.Alo + "</td>");

                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\">" + k.Cao + "</td>");
                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\">" + k.Cas + "</td>");
                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\">" + k.Tio + "</td>");
                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\">" + k.Tial + "</td>");
                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\">" + k.Mns + "</td>");
                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\">" + k.Mgo + "</td>");

                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\">" + k.Zro + "</td>");
                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\">" + k.Sio + "</td>");
                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\">" + hesap_CuEQ.ToString() + "</td>");
                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\">" + Math.Round((mn / s), 2).ToString().Replace(",", ".") + "</td>");
                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\">" + Math.Round((mn / si), 2).ToString().Replace(",", ".") + "</td>");
                        htmlTable.Append("<td style=\"background-color:#c8d9de;font-weight:bold\"></td>");

                        htmlTable.Append("</tr>");
                    }
                }
            }
            ph_kimya_lab_analiz_3.Controls.Clear();
            ph_kimya_lab_analiz_3.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }



        private void dokum_changed()
        {

            string dokum_no_s = tx_dokum_no.Text;
            int dokum_no = Convert.ToInt32(dokum_no_s.Equals("") ? "0" : dokum_no_s);

            kimya_lab_analizleri_getir(dokum_no);

            analizler_1_ekrana_bas();
            analizler_2_ekrana_bas();
            analizler_3_ekrana_bas();


        }

        protected void btn_analiz_liste_Click(object sender, EventArgs e)
        {
            dokum_changed();
        }
        protected void btn_degistir_Click(object sender, EventArgs e)
        {
            string yer = cmb_yer.SelectedItem.ToString();
            string element = cmb_element.SelectedItem.ToString();
            string miktar = txt_deger.Text;
            string dokum_no = tx_dokum_no.Text;
            if (yer != "Yer" && element != "Element" && miktar != "")
            {
                db.Connect();
                string mesaj = db.dokumnoya_gore_yer_element_guncellemesi(yer, element, miktar, dokum_no);
                db.Disconnect();
                if (mesaj == "BAŞARILI")
                {
                    System.Web.HttpContext.Current.Response.Write("<script LANGUAGE='JavaScript'>alert(    ' " + yer + " ALANINDAKİ " + element + "  DEĞERİ DEĞİŞTİRİLDİ.     ')</script>");
                }
                else
                {
                    System.Web.HttpContext.Current.Response.Write("<script LANGUAGE='JavaScript'>alert('  HATA OLUŞTU.LÜTFEN TEKRAR DENEYİNİZ. ')</script>");
                }
            }

            else
            {
                Response.Write("<script language='javascript'>alert('   LÜTFEN TÜM ALANLARI EKSİKSİZ DOLDURUNUZ !!  ');</script>");

            }
            dokum_changed();

        }

        protected void btn_sil_Click(object sender, EventArgs e)
        {
            string yer = cmb_yer2.SelectedItem.ToString();
            string dokum_no = tx_dokum_no.Text;
            if (yer != "Yer")
            {
                db.Connect();
                string mesaj = db.dokumnoyagore_yer_sil(yer, dokum_no);
                db.Disconnect();
                if (mesaj == "BAŞARILI")
                {
                    System.Web.HttpContext.Current.Response.Write("<script LANGUAGE='JavaScript'>alert('    YER ALANI SİLİNDİ    ')</script>");
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('    HATA OLUŞTU.LÜTFEN TEKRAR DENEYİNİZ.  ');</script>");
                }

            }
            else
            {
                Response.Write("<script language='javascript'>alert('   LÜTFEN SİLMEK İSTEDİĞİNİZ YERİ SEÇİNİZ !!  ');</script>");
            }
            dokum_changed();

        }



    }
}