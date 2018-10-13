using diler.Dal;
using diler.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace diler.Web.Forms.Kimya
{
    public partial class Milltest_analiz : System.Web.UI.Page
    {
        Kimya_analiz_db db = new Kimya_analiz_db();
        List<Kimya_lab_analiz> analizler = new List<Kimya_lab_analiz>();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void kimya_lab_analizleri_getir(int bas_dokum_no = 0, int bit_dokum_no = 0)
        {
            db.Connect();
            analizler = db.kimya_lab_analiz_data_read(bas_dokum_no, bit_dokum_no);
            db.Disconnect();
        }

        private void analizler_2_ekrana_bas()
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
                    if (k.Yer == "S1")
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

                        htmlTable.Append("<tr>");
                        htmlTable.Append("<td>" + k.Yer + "</td>");
                        htmlTable.Append("<td>" + k.Yil + "</td>");
                        htmlTable.Append("<td>" + k.Dokum_no + "</td>");
                        htmlTable.Append("<td>" + k.Celik_cinsi + "</td>");

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
                        htmlTable.Append("<td>" + k.Ract + "</td>");

                        htmlTable.Append("</tr>");
                    }
                }
            }
            ph_kimya_lab_analiz_2.Controls.Clear();
            ph_kimya_lab_analiz_2.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }

        private void dokum_changed()
        {

            string bas_dokum_no_s = tx_bas_dokum_no.Text;
            string bit_dokum_no_s = tx_bit_dokum_no.Text;

            int bas_dokum_no = Convert.ToInt32(bas_dokum_no_s);
            int bit_dokum_no = Convert.ToInt32(bit_dokum_no_s);

            kimya_lab_analizleri_getir(bas_dokum_no, bit_dokum_no);

            analizler_2_ekrana_bas();
        }

        protected void btn_mill_test_Click(object sender, EventArgs e)
        {
            dokum_changed();
        }
    }
}