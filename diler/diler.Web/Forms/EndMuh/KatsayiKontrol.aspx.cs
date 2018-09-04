using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using diler.Dal;
using diler.Web;
using diler.Entity;
using FarPoint.Web.Spread;

namespace diler.Web.Forms.EndMuh
{
    public partial class KatsayiKontrol : System.Web.UI.Page
    {

        KatsayiKontrol_DB database = new KatsayiKontrol_DB();
        int Sure
        {
            get
            {
                return Convert.ToInt32(10);
            }
        }
        bool OtoKapa
        {
            get
            {
                return false;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {



        }

        protected void Button4_Click(object sender, EventArgs e)
        {

            try

            {
                FpSpread1.Sheets[0].Columns[0].Width = 10;
                FpSpread1.Sheets[0].Columns[1].Width = 10;
                FpSpread1.Sheets[0].Columns[2].Width = 10;

                FpSpread1.Rows.Count = 0;

                /* gelecek kolonları bulduk*/

                List<katsayi_kontrol> veriler = new List<katsayi_kontrol>();
                database.connect();



                Convert.ToDateTime(bastar.Text);
                var tar1 = Convert.ToDateTime(bastar.Text).ToString("yyyyMMdd");
                var tar2 = Convert.ToDateTime(bastar.Text).ToString("yyyyMMdd");
                veriler = database.GunBazındaVeriler(Convert.ToInt32(tar1), Convert.ToInt32(tar2));

                foreach (var veriler_ in veriler)
                {

                    FpSpread1.Rows.Count = FpSpread1.Rows.Count + 1;


                    FpSpread1.Sheets[0].Cells[FpSpread1.Rows.Count - 1, 0].Text = veriler_.dokumNo;
                    FpSpread1.Sheets[0].Cells[FpSpread1.Rows.Count - 1, 1].Text = veriler_.sira;
                    FpSpread1.Sheets[0].Cells[FpSpread1.Rows.Count - 1, 2].Text = veriler_.vrd;
                    FpSpread1.Sheets[0].Cells[FpSpread1.Rows.Count - 1, 3].Text = veriler_.ebat;
                    FpSpread1.Sheets[0].Cells[FpSpread1.Rows.Count - 1, 4].Text = veriler_.boy;
                    FpSpread1.Sheets[0].Cells[FpSpread1.Rows.Count - 1, 5].Text = veriler_.celikcinsi;


                    if (veriler_.kütükadet != "" && veriler_.kütükadet != "0")
                    {

                        FpSpread1.Sheets[0].Cells[FpSpread1.Rows.Count - 1, 6].Text = veriler_.kütükadet;
                        FpSpread1.Sheets[0].Cells[FpSpread1.Rows.Count - 1, 7].Text = veriler_.kütüktonaj;


                        Int32 d1 = Convert.ToInt32(FpSpread1.Sheets[0].Cells[FpSpread1.Rows.Count - 1, 6].Text);
                        decimal d2 = Convert.ToDecimal(FpSpread1.Sheets[0].Cells[FpSpread1.Rows.Count - 1, 7].Text);
                        decimal katsayı = (d2 / d1) * 1000;
                        string sonuc = katsayı.ToString("0.000").Replace(".000", "");
                        FpSpread1.Sheets[0].Cells[FpSpread1.Rows.Count - 1, 8].Text = sonuc.ToString();

                    }
                    else
                    {
                        FpSpread1.Sheets[0].Cells[FpSpread1.Rows.Count - 1, 8].Text = "0";
                    }



                    if (veriler_.karisimadet != "" && veriler_.karisimadet != "0")
                    {
                        FpSpread1.Sheets[0].Cells[FpSpread1.Rows.Count - 1, 9].Text = veriler_.karisimadet;
                        FpSpread1.Sheets[0].Cells[FpSpread1.Rows.Count - 1, 10].Text = veriler_.karisimtonaj;

                        Int32 d1x = Convert.ToInt32(FpSpread1.Sheets[0].Cells[FpSpread1.Rows.Count - 1, 9].Text);
                        decimal d2x = Convert.ToDecimal(FpSpread1.Sheets[0].Cells[FpSpread1.Rows.Count - 1, 10].Text);
                        decimal katsayı2 = (d2x / d1x) * 1000;
                        string sonuc2 = katsayı2.ToString("0.000").Replace(".000", "");

                        FpSpread1.Sheets[0].Cells[FpSpread1.Rows.Count - 1, 11].Text = sonuc2.ToString();

                    }
                    else
                    {
                        FpSpread1.Sheets[0].Cells[FpSpread1.Rows.Count - 1, 11].Text = "0";
                    }



                    FpSpread1.Sheets[0].Cells[FpSpread1.Rows.Count - 1, 12].Text = veriler_.tartim_katsayisi.ToString();
                    decimal kolon8 = Convert.ToDecimal(FpSpread1.Sheets[0].Cells[FpSpread1.Rows.Count - 1, 8].Text);
                    decimal kolon11 = Convert.ToDecimal(FpSpread1.Sheets[0].Cells[FpSpread1.Rows.Count - 1, 8].Text);
                    decimal kolon12 = Convert.ToDecimal(veriler_.tartim_katsayisi.ToString());

                    // eger 8. satırda deger varsa 12. stırla karsılastır farklı ıse boya
                    if (kolon8.ToString() != "" && kolon8.ToString() != "0")
                    {

                        if (kolon8 != kolon12)
                        {
                            FpSpread1.Sheets[0].Cells[FpSpread1.Rows.Count - 1, 12].BackColor = System.Drawing.Color.Red;
                        }
                    }

                    // eger 11. satırda deger varsa 12. stırla karsılastır farklı ıse boya
                    if (kolon11.ToString() != "" && kolon11.ToString() != "0")
                    {

                        if (kolon11 != kolon12)
                        {
                            FpSpread1.Sheets[0].Cells[FpSpread1.Rows.Count - 1, 12].BackColor = System.Drawing.Color.Red;
                        }
                    }



                    // burada UPDATE EDILECEK YENI TONAJLARI BUL
                    Int16 Degisecek_DokumNo, Yeni_Katsayi, Kutuk_sayisi;
                    Int16 i;

                    for (i = 0; i <= FpSpread1.Rows.Count - 1; i++)
                    {

                        // eger 8. satırda deger varsa 12. stırla karsılastır farklı ıse yeni tonaj
                        if (FpSpread1.Sheets[0].Cells[i, 8].Text != "" && FpSpread1.Sheets[0].Cells[i, 8].Text != "0")
                        {

                            if (FpSpread1.Sheets[0].Cells[i, 8].Text != FpSpread1.Sheets[0].Cells[i, 12].Text)
                            {
                                Kutuk_sayisi = Convert.ToInt16(FpSpread1.Sheets[0].Cells[i, 6].Text);
                                decimal yt = (Kutuk_sayisi * Convert.ToInt32(FpSpread1.Sheets[0].Cells[i, 12].Text));
                                yt = yt / 1000;
                                FpSpread1.Sheets[0].Cells[i, 13].Text = yt.ToString();
                            }
                        }
                    }

                    //******************************************************************************************************
                    for (i = 0; i <= FpSpread1.Rows.Count - 1; i++)
                    {

                        // eger 11. satırda deger varsa 12. stırla karsılastır farklı ıse yeni tonaj
                        if (FpSpread1.Sheets[0].Cells[i, 11].Text != "" && FpSpread1.Sheets[0].Cells[i, 11].Text != "0")
                        {

                            if (FpSpread1.Sheets[0].Cells[i, 11].Text != FpSpread1.Sheets[0].Cells[i, 12].Text)
                            {
                                Kutuk_sayisi = Convert.ToInt16(FpSpread1.Sheets[0].Cells[i, 9].Text);
                                decimal yt = (Kutuk_sayisi * Convert.ToInt32(FpSpread1.Sheets[0].Cells[i, 12].Text));
                                yt = yt / 1000;
                                FpSpread1.Sheets[0].Cells[i, 14].Text = yt.ToString();
                            }
                        }
                    }

                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Bu gune ait kayıt yok", MessageBox.MesajTipleri.Error, OtoKapa, Sure);
                //throw ex;

            }

            database.disConnect();

        }

        //public void Sakla()
        //{

        //    Int32 Degisecek_DokumNo, Degisecek_SiraNo, Yeni_Katsayi, Kutuk_sayisi;
        //    Int16 i;
        //    decimal YeniTonaj;

        //    for (i = 0; i <= FpSpread1.Rows.Count - 1; i++)
        //    {
        //        if (FpSpread1.Sheets[0].Cells[i, 13].Text != "")
        //        {
        //            Degisecek_DokumNo = Convert.ToInt32(FpSpread1.Sheets[0].Cells[i, 0].Text);
        //            Degisecek_SiraNo = Convert.ToInt16(FpSpread1.Sheets[0].Cells[i, 1].Text);
        //            YeniTonaj = Convert.ToDecimal(FpSpread1.Sheets[0].Cells[i, 13].Text);
        //        }
        //    }

        //    MessageBox.Show("saklama işlemi yapıldı", MessageBox.MesajTipleri.Info, false, 5);

        //}


        [System.Web.Services.WebMethod]
        public static string GetirIsim(string ad, string soyad)
        {

            return "1";
        }


        public void BilgileriSakla1()
        {
            string x = "0";
        }


        protected void Sakla_Click(object sender, EventArgs e)
        {


        }


        protected void FpSpread1_ButtonCommand(object sender, FarPoint.Web.Spread.SpreadCommandEventArgs e)
        {
            // string bak;
            // bak = e.CommandName;

            // string[] commandArgs = e.CommandArgument.ToString().Split(new char[] { ',' });
            // Int32 Satır =Convert.ToInt16( commandArgs[0].ToString());
            // Int32 Sutun = Convert.ToInt32(commandArgs[1]);


            // Int32 Degisecek_DokumNo, Degisecek_SiraNo, Yeni_Katsayi, Kutuk_sayisi;
            // Int16 i;
            // decimal YeniTonaj = 0;

            //if (FpSpread1.Sheets[0].Cells[Satır, 11].Text != "")
            //     {
            //         Degisecek_DokumNo = Convert.ToInt32(FpSpread1.Sheets[0].Cells[Satır, 0].Text);
            //         Degisecek_SiraNo = Convert.ToInt16(FpSpread1.Sheets[0].Cells[Satır, 1].Text);
            //         YeniTonaj = Convert.ToDecimal(FpSpread1.Sheets[0].Cells[Satır, 13].Text);
            //     }

            // MessageBox.Show("saklama işlemi yapıldı", MessageBox.MesajTipleri.Info, false, 5);
            // //   MessageBox.Show("saklama işlemi yapıldı", MessageBox.MesajTipleri.Info, false, 5);


        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../../Default2.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Convert.ToDateTime(bastar.Text);
            var tar1 = Convert.ToDateTime(bastar.Text).ToString("yyyyMMdd");

            FpSpread2.Rows.Count = 5;
            FpSpread2.Sheets[0].Cells[0, 0].Text = "Kapalı(TK)";
            FpSpread2.Sheets[0].Cells[1, 0].Text = "Açık(AC+YK)";


            // GUNLUKLER
            List<katsayi_kontrol> veriler = new List<katsayi_kontrol>();
            database.connect();


            veriler = database.DokumTip_Gunluk_Degerler(tar1);

            foreach (var veriler_ in veriler)
            {
                FpSpread2.Sheets[0].Cells[0, 1].Text = veriler_.Gun_TK_Top.ToString();
                FpSpread2.Sheets[0].Cells[1, 1].Text = veriler_.Gun_ACYK_Top.ToString();

                FpSpread2.Sheets[0].Cells[0, 2].Text = veriler_.Gun_TK_Tnj.ToString();
                FpSpread2.Sheets[0].Cells[1, 2].Text = veriler_.Gun_ACYK_Tnj.ToString();
            }


            // AYLIKLAR
            List<katsayi_kontrol> Ay_veriler = new List<katsayi_kontrol>();
            database.connect();

            Convert.ToDateTime(bastar.Text);

            Ay_veriler = database.DokumTip_Aylik_Degerler(tar1);

            foreach (var Ay_veriler_ in Ay_veriler)
            {



                FpSpread2.Sheets[0].Cells[0, 3].Text = Ay_veriler_.Ay_TK_Top.ToString();
                FpSpread2.Sheets[0].Cells[1, 3].Text = Ay_veriler_.Ay_ACYK_Top.ToString();

                Int32 GunSay = Convert.ToInt32(tar1.Substring(6, 2));
                Int32 d1 = Convert.ToInt32(Ay_veriler_.Ay_TK_Top.ToString());
                Int32 d2 = Convert.ToInt32(Ay_veriler_.Ay_ACYK_Top.ToString());
                decimal d1_1 = d1 / GunSay;
                d1_1 = Math.Round(d1_1, 2);
                decimal d2_1 = d2 / GunSay;
                d2_1 = Math.Round(d2_1, 2);


                FpSpread2.Sheets[0].Cells[0, 4].Text = d1_1.ToString();
                FpSpread2.Sheets[0].Cells[1, 4].Text = d2_1.ToString();



                FpSpread2.Sheets[0].Cells[0, 5].Text = Ay_veriler_.Ay_TK_Tnj.ToString();
                FpSpread2.Sheets[0].Cells[1, 5].Text = Ay_veriler_.Ay_ACYK_Tnj.ToString();

                decimal e1 = Convert.ToDecimal(Ay_veriler_.Ay_TK_Tnj.ToString());
                decimal e2 = Convert.ToDecimal(Ay_veriler_.Ay_ACYK_Tnj.ToString());
                decimal e1_1 = e1 / GunSay;
                e1_1 = Math.Round(e1_1, 2);
                decimal e2_1 = e2 / GunSay;
                e2_1 = Math.Round(e2_1, 2);

                FpSpread2.Sheets[0].Cells[0, 6].Text = e1_1.ToString();
                FpSpread2.Sheets[0].Cells[1, 6].Text = e2_1.ToString();

            }




            // YILLIKLAR
            List<katsayi_kontrol> Yil_veriler = new List<katsayi_kontrol>();
            database.connect();

            Convert.ToDateTime(bastar.Text);
            Int32 YilGunSay = Convert.ToInt32(tar1.Substring(6, 2));
            Yil_veriler = database.DokumTip_Yillik_Degerler(tar1);

            foreach (var Yil_veriler_ in Yil_veriler)
            {
                FpSpread2.Sheets[0].Cells[0, 7].Text = Yil_veriler_.Yıl_TK_Top.ToString();
                FpSpread2.Sheets[0].Cells[1, 7].Text = Yil_veriler_.Yıl_ACYK_Top.ToString();


                /*yıl toplam oranları*/
                decimal ya1 = Convert.ToDecimal(Yil_veriler_.Yıl_TK_Top.ToString());
                decimal ya2 = Convert.ToDecimal(Yil_veriler_.Yıl_TK_Top.ToString());
                decimal ya1_1 = ya1 / YilGunSay;
                ya1_1 = Math.Round(ya1_1, 2);
                decimal ya2_1 = ya2 / YilGunSay;
                ya2_1 = Math.Round(ya2_1, 2);

                FpSpread2.Sheets[0].Cells[0, 8].Text = ya1_1.ToString();
                FpSpread2.Sheets[0].Cells[1, 8].Text = ya2_1.ToString();


                FpSpread2.Sheets[0].Cells[0, 9].Text = Yil_veriler_.Yıl_TK_Tnj.ToString();
                FpSpread2.Sheets[0].Cells[1, 9].Text = Yil_veriler_.Yıl_ACYK_Tnj.ToString();

                /*yıl tonaj oranları*/
                decimal y1 = Convert.ToDecimal(Yil_veriler_.Yıl_TK_Tnj.ToString());
                decimal y2 = Convert.ToDecimal(Yil_veriler_.Yıl_ACYK_Tnj.ToString());
                decimal y1_1 = y1 / YilGunSay;
                y1_1 = Math.Round(y1_1, 2);
                decimal y2_1 = y2 / YilGunSay;
                y2_1 = Math.Round(y2_1, 2);

                FpSpread2.Sheets[0].Cells[0, 10].Text = y1_1.ToString();
                FpSpread2.Sheets[0].Cells[1, 10].Text = y2_1.ToString();

            }

        }

        protected void LnkButton1_Click(object sender, EventArgs e)
        {


            string Sonuc;
            Int32 Degisecek_DokumNo, Degisecek_SiraNo, Yeni_Katsayi, Kutuk_sayisi;
            Int16 i;
            decimal YeniTonaj = 0;
            var satısay = Convert.ToInt16(FpSpread1.Rows.Count);
            if (satısay <= 3)
            {
                MessageBox.Show("Hiç kayıt yok, Listelemeyi unuttunuz galiba", MessageBox.MesajTipleri.Error, OtoKapa, Sure);
            }
            else
            {

                for (i = 0; i <= FpSpread1.Rows.Count - 1; i++)
                {
                    if (FpSpread1.Sheets[0].Cells[i, 13].Text != "")
                    {
                        Degisecek_DokumNo = Convert.ToInt32(FpSpread1.Sheets[0].Cells[i, 0].Text);
                        Degisecek_SiraNo = Convert.ToInt16(FpSpread1.Sheets[0].Cells[i, 1].Text);
                        YeniTonaj = Convert.ToDecimal(FpSpread1.Sheets[0].Cells[i, 13].Text);

                        if (FpSpread1.Sheets[0].Cells[i, 7].Text != "")
                        {
                            database.connect();
                            database.Tonaj_Updateleri(Degisecek_DokumNo, Degisecek_SiraNo, YeniTonaj, "kutuk_tonaj");
                            database.disConnect();
                            //Sonuc = database.Tonaj_Updateleri(Degisecek_DokumNo, Degisecek_SiraNo, YeniTonaj, "kutuk_tonaj");
                            //MessageBox.Show(Sonuc, MessageBox.MesajTipleri.Info, false, 5);
                        }

                      
                    }


                    if (FpSpread1.Sheets[0].Cells[i, 14].Text != "")
                    {
                        Degisecek_DokumNo = Convert.ToInt32(FpSpread1.Sheets[0].Cells[i, 0].Text);
                        Degisecek_SiraNo = Convert.ToInt16(FpSpread1.Sheets[0].Cells[i, 1].Text);
                        YeniTonaj = Convert.ToDecimal(FpSpread1.Sheets[0].Cells[i, 14].Text);


                        if (FpSpread1.Sheets[0].Cells[i, 10].Text != "")
                        {
                            //Sonuc = database.Tonaj_Updateleri(Degisecek_DokumNo, Degisecek_SiraNo, YeniTonaj, "karisim_tonaj");
                            database.connect();
                            database.Tonaj_Updateleri(Degisecek_DokumNo, Degisecek_SiraNo, YeniTonaj, "karisim_tonaj");
                            database.disConnect();
                        }

                    }


                    MessageBox.Show("Kayıtlar update edildi kontrol edelim...", MessageBox.MesajTipleri.Info, OtoKapa, 5);

                    //MessageBox.Show("Deneme metni", MessageBox.MesajTipleri.Warning, OtoKapa, Sure);
                    //MessageBox.Show("Deneme metni", MessageBox.MesajTipleri.Info, OtoKapa, Sure);
                    //MessageBox.Show("Deneme metni", MessageBox.MesajTipleri.Error, OtoKapa, Sure);
                }

            }
        }


    }
}
