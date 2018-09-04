using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using diler.Dal;
using diler.Entity;
using System.Text;


namespace diler.Web.Forms.Paketleme
{
    public partial class KalibrasyonRpr : System.Web.UI.Page
    {

        Kalibrasyon_Paketleme_db db = new Kalibrasyon_Paketleme_db();
        List<PaketlemeRapor> kalibrasyon_Paketleme = new List<PaketlemeRapor>();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                DateTime dt = new DateTime();
                dt = DateTime.Now;
                string tarih = dt.ToString("yyyy-MM-dd");//textboxdaki bicimi;
                //tx_rapor_tarihi.Text = tarih;
                TxtBasTar.Text = tarih;
                TxtBitTar.Text = tarih;

            }

        }
        private void Rapor_Getir()
        {
            int Yolumuz = 0;
            int Vardiyamız = 0;

            string tarih1_ = TxtBasTar.Text;//textboxdaki bicimi
            string tarih2_ = TxtBitTar.Text;//textboxdaki bicimi
            tarih1_ = tarih1_.Replace("-", "");//veritabanindaki kayit bicimi
            tarih2_ = tarih2_.Replace("-", "");//veritabanindaki kayit bicimi

            if (CmbYol.Text.ToString() == "YOL 1")
            {
                Yolumuz = 1;
            }
            if (CmbYol.Text.ToString() == "YOL 2")
            {
                Yolumuz = 2;
            }
            if (CmbYol.Text.ToString() == "YOL 1+2")
            {
                Yolumuz = 0;
            }


            if (CmbVrd.Text.ToString() == "VRD 1")
            {
                Vardiyamız = 1;
            }
            if (CmbVrd.Text.ToString() == "VRD 2")
            {
                Vardiyamız = 2;
            }
            if (CmbVrd.Text.ToString() == "VRD 3")
            {
                Vardiyamız = 3;
            }
            if (CmbVrd.Text.ToString() == "VRD 1+2+3")
            {
                Vardiyamız = 0;
            }




            if (TxtBasTar.Text != "")
            {
                db.Connect();
                int tarih1 = Convert.ToInt32(tarih1_);
                int tarih2 = Convert.ToInt32(tarih2_);
                double ToplampaketSay = 0;
                decimal ToplamTonaj = 0;
                double oran = 0;
                //performans_raporu_gun_liste(tarih2, secilen_vardiya);

                StringBuilder htmlTable = new StringBuilder();
                kalibrasyon_Paketleme = db.datalar(tarih1, tarih2,CmbYer.Text, Yolumuz, Vardiyamız,TxtBoy.Text,TxtCap.Text,TxtSip.Text,TxtLot.Text);

                {
                   
                        htmlTable.Append("<thead>");
                        htmlTable.Append("<tr >");
                        htmlTable.Append("<th class='auto - style5'>Tarih</th>");
                        htmlTable.Append("<th class='auto - style5'>SipNo</th>");
                        htmlTable.Append("<th class='auto - style5'>Lot</th>");
                        htmlTable.Append("<th class='auto - style3'>DNo</th>");
                        htmlTable.Append("<th class='auto - style3'>Vrd</th>");
                        htmlTable.Append("<th class='auto - style3'>Yol</th>");
                        htmlTable.Append("<th class='auto - style5'>Cap</th>");
                        htmlTable.Append("<th class='auto - style5'>Boy</th>");
                        htmlTable.Append("<th class='auto - style5'>Kalite</th>");
                        htmlTable.Append("<th class='auto - style5'>Paket Yeri</th>");
                        htmlTable.Append("<th class='auto - style5'>Tartım(kg)</th>");
                        htmlTable.Append("<th class='auto - style5'>PaketSayısı</th>");
                        htmlTable.Append("<th class='auto - style5'>Ort</th>");
                        htmlTable.Append("</tr> ");
                        htmlTable.Append("</thead> ");
                        htmlTable.Append("</tr>");

                        foreach (var kayit in kalibrasyon_Paketleme)
                        {
                            //htmlTable.Append("<tr>");
                            htmlTable.Append("<tr class='table_t'>");
                            htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER;background-color:#F4F5F5\">" + kayit.Tarih + "</td>");
                            htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER;background-color:#F4F5F5\">" + kayit.Sipno + "</td>");
                            htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER;background-color:#F4F5F5\">" + kayit.Lot + "</td>");
                            htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER;background-color:#F4F5F5\">" + kayit.Dno + "</td>");

                            if (kayit.Vrd == 1)
                            {
                                htmlTable.Append("<td style =\"text-align:center; background-color:#ff1c33;  font-weight: bold;\">" + (kayit.Vrd) + "</td>");
                            }

                            if (kayit.Vrd == 2)
                            {
                                htmlTable.Append("<td style =\"text-align:center; background-color:#81DC25; font-weight: bold;\">" + (kayit.Vrd) + "</td>");
                            }

                            if (kayit.Vrd == 3)
                            {
                                htmlTable.Append("<td style =\"text-align:center; background-color:#25DCDC; font-weight: bold;\">" + (kayit.Vrd) + "</td>");
                            }

                            htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER;background-color:#F4F5F5\">" + kayit.Yol + "</td>");
                            htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER;background-color:#F4F5F5\">" + kayit.Cap + "</td>");
                            htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER;background-color:#F4F5F5\">" + kayit.Boy + "</td>");
                            htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER;background-color:#F4F5F5\">" + kayit.Kalite + "</td>");
                            htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER;background-color:#F4F5F5\">" + kayit.KalibreTnm + "</td>");
                            htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER;background-color:#F4F5F5\">" + kayit.Tonaj + "</td>");
                            htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER;background-color:#F4F5F5\">" + kayit.Paketsayisi + "</td>");
                            htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER;background-color:#F4F5F5\">" + kayit.Ortalama + "</td>");

                            htmlTable.Append("</tr>");

                        paketleme_kalibrasyon_html_table.Controls.Clear();
                        paketleme_kalibrasyon_html_table.Controls.Add(new Literal { Text = htmlTable.ToString() });

                        ToplampaketSay = ToplampaketSay + kayit.Paketsayisi;

                       if (kayit.Tonaj == null)
                        {
                            ToplamTonaj = 0;
                            
                        }
                        else
                            ToplamTonaj = ToplamTonaj + Convert.ToDecimal(kayit.Tonaj.ToString());
                         oran = (double) ToplamTonaj / ToplampaketSay;

                    }
                    
                    // Create an empty <tr> element and add it to the 1st position of the table:
                    
                    htmlTable.Append("<tr class='table_t'>");
                    htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER;background-color:#FFFF99\">" + "" + "</td>");
                    htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER;background-color:#FFFF99\">" + "" + "</td>");
                    htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER;background-color:#FFFF99\">" + "" + "</td>");
                    htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER;background-color:#FFFF99\">" + "" + "</td>");
                    htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER;background-color:#FFFF99\">" + "" + "</td>");
                    htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER;background-color:#FFFF99\">" + "" + "</td>");
                    htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER;background-color:#FFFF99\">" + "" + "</td>");
                    htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER;background-color:#FFFF99\">" + "" + "</td>");
                    htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER;background-color:#FFFF99\">" + "" + "</td>");
                    htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER;background-color:#FFFF99\">" + "" + "</td>");
                    htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER;background-color:#FFFF99\">" + ToplamTonaj + "</td>");
                    htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER;background-color:#FFFF99\">" + ToplampaketSay + "</td>");
                    htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER;background-color:#FFFF99\">" +Math.Round(oran,0) + "</td>");
                    htmlTable.Append("</tr>");
                    paketleme_kalibrasyon_html_table.Controls.Clear();
                    paketleme_kalibrasyon_html_table.Controls.Add(new Literal { Text = htmlTable.ToString() });

                }
    

                db.Disconnect();

            }
        }
        private void Rapor_Getir_STOK()
        {
          
            string tarih1_ = TxtBasTar.Text;//textboxdaki bicimi
            string tarih2_ = TxtBitTar.Text;//textboxdaki bicimi
            tarih1_ = tarih1_.Replace("-", "");//veritabanindaki kayit bicimi
            tarih2_ = tarih2_.Replace("-", "");//veritabanindaki kayit bicimi

         
            
            if (TxtBasTar.Text != "")
            {
                db.Connect();
                int tarih1 = Convert.ToInt32(tarih1_);
                int tarih2 = Convert.ToInt32(tarih2_);

                StringBuilder htmlTable = new StringBuilder();
                kalibrasyon_Paketleme = db.datalarStok(tarih1, tarih2);

                {
                   
                        htmlTable.Append("<thead>");
                        htmlTable.Append("<tr >");
                        htmlTable.Append("<th class='auto - style5'>Tarih</th>");
                        htmlTable.Append("<th class='auto - style5'>SipNo</th>");
                        htmlTable.Append("<th class='auto - style5'>Lot</th>");
                        htmlTable.Append("<th class='auto - style3'>Vrd</th>");
                        htmlTable.Append("<th class='auto - style3'>Yol</th>");
                        htmlTable.Append("<th class='auto - style5'>Cap</th>");
                        htmlTable.Append("<th class='auto - style5'>Boy</th>");
                        htmlTable.Append("<th class='auto - style5'>Kalite</th>");
                        htmlTable.Append("<th class='auto - style5'>Paket Yeri</th>");
                        htmlTable.Append("<th class='auto - style5'>Tartım(kg)</th>");
                        htmlTable.Append("<th class='auto - style5'>PaketSayısı</th>");
                        htmlTable.Append("<th class='auto - style5'>Ort</th>");
                        htmlTable.Append("</tr> ");
                        htmlTable.Append("</thead> ");
                        htmlTable.Append("</tr>");

                        foreach (var kayit in kalibrasyon_Paketleme)
                        {
                            //htmlTable.Append("<tr>");
                            htmlTable.Append("<tr class='table_t'>");
                            htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER;background-color:#F4F5F5\">" + kayit.Tarih + "</td>");
                            htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER;background-color:#F4F5F5\">" + kayit.Sipno + "</td>");
                            htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER;background-color:#F4F5F5\">" + kayit.Lot + "</td>");
                            htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER;background-color:#F4F5F5\">" + kayit.Vrd + "</td>");
                            htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER;background-color:#F4F5F5\">" + kayit.Yol + "</td>");
                            htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER;background-color:#F4F5F5\">" + kayit.Cap + "</td>");
                            htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER;background-color:#F4F5F5\">" + kayit.Boy + "</td>");
                            htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER;background-color:#F4F5F5\">" + kayit.Kalite + "</td>");
                            htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER;background-color:#F4F5F5\">" + kayit.KalibreTnm + "</td>");
                            htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER;background-color:#F4F5F5\">" + kayit.Tonaj + "</td>");
                            htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER;background-color:#F4F5F5\">" + kayit.Paketsayisi + "</td>");
                            htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER;background-color:#F4F5F5\">" + kayit.Ortalama + "</td>");

                            htmlTable.Append("</tr>");

                        paketleme_kalibrasyon_html_table.Controls.Clear();
                        paketleme_kalibrasyon_html_table.Controls.Add(new Literal { Text = htmlTable.ToString() });
                    }
                }

                db.Disconnect();

            }
        }
        private void Rapor_Getir_Ozet()
        {
            int Yolumuz = 0;
            string tarih1_ = TxtBasTar.Text;//textboxdaki bicimi
            string tarih2_ = TxtBitTar.Text;//textboxdaki bicimi
            tarih1_ = tarih1_.Replace("-", "");//veritabanindaki kayit bicimi
            tarih2_ = tarih2_.Replace("-", "");//veritabanindaki kayit bicimi
        

            if (tarih1_ != "")
            {

                db.Connect();
                int tarih1 = Convert.ToInt32(tarih1_);
                int tarih2 = Convert.ToInt32(tarih2_);

                StringBuilder htmlTable = new StringBuilder();

                kalibrasyon_Paketleme = db.PaketlemeOzet(tarih1, tarih2);
                foreach (var kayit in kalibrasyon_Paketleme)
                {
                    T1.Text = kayit.T1.ToString();
                    T2.Text = kayit.T2.ToString();
                    T3.Text = kayit.T3.ToString();

                    T4.Text = kayit.T4.ToString();
                    T5.Text = kayit.T5.ToString();
                    T6.Text = kayit.T6.ToString();

                    T7.Text = kayit.T7.ToString();

                    T8.Text = T1.Text;
                    T9.Text = T2.Text;
                    T10.Text = T3.Text;


                    T11.Text = kayit.T11.ToString();
                    T12.Text = kayit.T12.ToString();
                    T13.Text = kayit.T13.ToString();

                    T14.Text = kayit.T14.ToString();



                }

            }

            db.Disconnect();
            

        }
        private void Rapor_Getir_Kalibrasyon()
        {
            int Yolumuz=0;
            string tarih1_ = TxtBasTar.Text;//textboxdaki bicimi
            string tarih2_ = TxtBitTar.Text;//textboxdaki bicimi
            tarih1_ = tarih1_.Replace("-", "");//veritabanindaki kayit bicimi
            tarih2_ = tarih2_.Replace("-", "");//veritabanindaki kayit bicimi

            if (CmbYol.Text.ToString() == "YOL 1")
            {
                Yolumuz = 1;
            }
            if (CmbYol.Text.ToString() == "YOL 2")
            {
                Yolumuz = 2;
            }
            if (CmbYol.Text.ToString() == "YOL 1+2")
            {
                Yolumuz = 0;
            }



            if (tarih1_ != "")
            {
                db.Connect();
                int tarih1 = Convert.ToInt32(tarih1_);
                int tarih2 = Convert.ToInt32(tarih2_);


                StringBuilder htmlTable = new StringBuilder();
                kalibrasyon_Paketleme = db.datalarKalibrasyon(tarih1, tarih2, Yolumuz);

 

                {


                    htmlTable.Append("<thead>");
                    htmlTable.Append("<tr >");
                    htmlTable.Append("<th class='auto - style5'>Tarih</th>");
                    htmlTable.Append("<th class='auto - style5'>Vrd</th>");
                    htmlTable.Append("<th class='auto - style5'>Yol</th>");
                    htmlTable.Append("<th class='auto -style3'>KalibreTnm</th>");
                    htmlTable.Append("<th class='auto -style3'>Tonaj</th>");
                    htmlTable.Append("<th class='auto -style5'>Saat</th>");
                    htmlTable.Append("</tr> ");
                    htmlTable.Append("</thead> ");
                    
                    foreach (var kayit in kalibrasyon_Paketleme)
                    {
                        htmlTable.Append("<tr class='table_t'>");
                        
                        htmlTable.Append("<td style =\"text-align:center; background-color:#F4F5F5;  font-weight: bold;\">" + (kayit.Tarih) + "</td>");
                        
                        if (kayit.Vrd == 1)
                        {
                            htmlTable.Append("<td style =\"text-align:center; background-color:#ff1c33;  font-weight: bold;\">" + (kayit.Vrd) + "</td>");
                        }

                        if (kayit.Vrd == 2)
                        {
                            htmlTable.Append("<td style =\"text-align:center; background-color:#81DC25; font-weight: bold;\">" + (kayit.Vrd) + "</td>");
                        }

                        if (kayit.Vrd == 3)
                        {
                            htmlTable.Append("<td style =\"text-align:center; background-color:#25DCDC; font-weight: bold;\">" + (kayit.Vrd) + "</td>");
                        }

                        htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER;background-color:#F4F5F5\">" + kayit.Yol + "</td>");
                        htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER;background-color:#F4F5F5\">" + kayit.KalibreTnm + "</td>");
                        htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER;background-color:#F4F5F5\">" + kayit.Tonaj + "</td>");
                        htmlTable.Append("<td style=\"TEXT-ALIGN:CENTER;background-color:#F4F5F5\">" + kayit.Saat + "</td>");
                        htmlTable.Append("</tr>");
                      
                    }
                }
                    paketleme_kalibrasyon_html_table.Controls.Clear();
                 paketleme_kalibrasyon_html_table.Controls.Add(new Literal { Text = htmlTable.ToString() });
            }

            db.Disconnect();
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../../Default2.aspx");
        }

        protected void BtnListele_Click(object sender, EventArgs e)
        {



            if (CmbYer.SelectedValue == "Kalibrasyon")
            {
                Rapor_Getir_Kalibrasyon();
                Rapor_Getir_Ozet();
            }
            else if (CmbYer.SelectedValue == "STOK")
            {
                Rapor_Getir_STOK();
                Rapor_Getir_Ozet();
            }
            else if (CmbYer.SelectedValue == "İHRACAT")
            {
                Rapor_Getir();
                Rapor_Getir_Ozet();
            }
            else if (CmbYer.SelectedValue == "İÇ PİYASA")
            {
                Rapor_Getir();
                Rapor_Getir_Ozet();
            }

            else if (CmbYer.SelectedValue == "STANDART DIŞI")
            {
                Rapor_Getir();
                Rapor_Getir_Ozet();
            }
            else if (CmbYer.SelectedValue == "KISA PARÇA")
            {
                Rapor_Getir();
                Rapor_Getir_Ozet();
            }
            else if (CmbYer.SelectedValue == "PAKETLEME")
            {
                Rapor_Getir();
                Rapor_Getir_Ozet();
            }

        }
        private void TABLO2GİZLE()
        {
            StringBuilder htmlTable = new StringBuilder();
            htmlTable.Append("<table style='display: none;'");
            htmlTable.Append("   > ");

            
            //paketleme_kalibrasyon_html_table.Controls.Clear();
            paketleme_kalibrasyon_html_table.Controls.Add(new Literal { Text = htmlTable.ToString() });
        }
        private void TABLO1GİZLE()
        {

        }
    }

    }
