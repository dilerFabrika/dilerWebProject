using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using diler.Dal;
using Microsoft.Office.Interop.Excel;
using diler.Entity;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Reflection;
using System.Text;

namespace diler.Web
{
    public partial class DokumAlyajRaporu : System.Web.UI.Page
    {
        string appdirname;
        string pathname;

        private string upDir;
        string DokumNosuX;
        string AlyajTnmX;
        string AlyajınDegeri;
        string AlyajınDokumNo;
        Celikhane_db database = new Celikhane_db();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            { }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            FpSpread1.Rows.Count = 1;
            FpSpread1.Columns.Count = 2;

            FpSpread1.Columns.Count = FpSpread1.Columns.Count + 1;
            FpSpread1.Sheets[0].Cells[0, FpSpread1.Columns.Count - 2].Text = "Tarih";
            FpSpread1.Sheets[0].Cells[0, FpSpread1.Columns.Count - 1].Text = "DokumNo";

            /* gelecek kolonları bulduk*/
            database.connect();

            List<string> kolonlar = new List<string>();
            kolonlar = database.AljayKolonList();


            foreach (var kolonadı in kolonlar)
            {
                FpSpread1.Columns.Count = FpSpread1.Columns.Count + 1;
                FpSpread1.Sheets[0].Cells[0, FpSpread1.Columns.Count - 1].Text = kolonadı;
                //Cmb_Kutukboy.Items.Add(boy);
            }
            database.disConnect();


            /* simdi dokum noları bul*/
            database.connect();
            List<string> DokumNolar = new List<string>();
            DokumNolar = database.DokumNolarList(bastar.Text, bittar.Text);

            foreach (var Dno in DokumNolar)
            {
                FpSpread1.Rows.Count = FpSpread1.Rows.Count + 1;
                FpSpread1.Sheets[0].Cells[FpSpread1.Rows.Count - 1, 2].Text = Dno;

            }
            database.disConnect();

            /* simdi dokum noların tarihlerini bul*/



            // ŞIMDI BURDA YATAYDA GELEN KOLONLARLA BIR TABLO CREATE EDELIM
            StringBuilder CreateSqlDizi = new StringBuilder();
            string AlyajTnm = "";
            string CreateSql = "";
            CreateSqlDizi.Clear();

            CreateSql = " Create table Temp (";
            CreateSqlDizi = CreateSqlDizi.Append(CreateSql);

            for (int s = 1; s <= FpSpread1.Columns.Count - 1; s++)
            {
                if (s == 1)
                {
                    AlyajTnm = FpSpread1.Sheets[0].Cells[0, s].Text + " NUMBER(10, 4)";
                }
                else
                {
                    AlyajTnm = "," + FpSpread1.Sheets[0].Cells[0, s].Text + " NUMBER(10, 4)";
                }
                CreateSqlDizi = CreateSqlDizi.Append(AlyajTnm);
            }
            CreateSql = CreateSqlDizi + ")";

            database.connect();

            List<string> DokumunDegeri = new List<string>();
            DokumunDegeri = database.DokumunDegerleri(bastar.Text, bittar.Text);
            database.disConnect();

            for (int k = 0; k <= DokumunDegeri.Count - 1; k++)
            {
                AlyajınDokumNo = DokumunDegeri[k];
                AlyajTnmX = DokumunDegeri[k + 1];
                AlyajınDegeri = DokumunDegeri[k + 2];
                k = k + 2;
                for (int m = 0; m <= FpSpread1.Rows.Count - 1; m++)
                {
                    DokumNosuX = FpSpread1.Sheets[0].Cells[m, 2].Text;
                    if (DokumNosuX == AlyajınDokumNo)
                    {
                        for (int s = 1; s <= FpSpread1.Columns.Count - 1; s++)
                        {
                            var bulunan = FpSpread1.Sheets[0].Cells[0, s].Text;
                            if (bulunan == AlyajTnmX)
                            {
                                FpSpread1.Sheets[0].Cells[m, s].Text = AlyajınDegeri;
                            }
                        }
                    }
                }
            }



            for (int s = 1; s <= FpSpread1.Columns.Count - 1; s++)
            {
                FpSpread1.Sheets[0].Cells[0, s].Font.Bold = true;
                FpSpread1.Sheets[0].Cells[0, s].Font.Size = 8;
            }

            //BIRAZ AMELE ISI OLDU AMA 
            // SIMDI  DOKUMUN TARIHLERINI GETIR

            database.connect();
            List<genel_bilgiler> DokumNoTarih = new List<genel_bilgiler>();
            DokumNoTarih = database.DokumNoBilgileri(bastar.Text, bittar.Text);
            database.disConnect();

            foreach (var kolon in DokumNoTarih)
            {
                var TANIM = kolon.DOKUMNO.ToString();
                var TARIHI = kolon.TARIH.ToString();
                for (int m = 0; m <= FpSpread1.Rows.Count - 1; m++)
                {
                    var TANIM_ = FpSpread1.Sheets[0].Cells[m, 2].Text;
                    if (TANIM_ == TANIM)
                    {
                        FpSpread1.Sheets[0].Cells[m, 1].Text = TARIHI.ToString();
                    }
                }
            }



            // SIMDI  DOKUMUN TONAJ GETIR
            FpSpread1.Columns.Count = FpSpread1.Columns.Count + 1;

            database.connect();
            List<genel_bilgiler> DokumTonaj = new List<genel_bilgiler>();
            DokumTonaj = database.DokumTonajı(bastar.Text, bittar.Text);
            database.disConnect();

            foreach (var kolon in DokumTonaj)
            {
                var TANIM = kolon.DOKUMNO.ToString();
                var TONAJ = kolon.KUTUK_TONAJI.ToString();
                for (int m = 0; m <= FpSpread1.Rows.Count - 1; m++)
                {
                    var TANIM_ = FpSpread1.Sheets[0].Cells[m, 2].Text;
                    if (TANIM_ == TANIM)
                    {
                        FpSpread1.Sheets[0].Cells[m, FpSpread1.Columns.Count - 1].Text = TONAJ.ToString();
                    }
                }
            }




            // SIMDI  DOKUMUN KALITESINI GETIR
            FpSpread1.Columns.Count = FpSpread1.Columns.Count + 1;

            database.connect();
            List<genel_bilgiler> DokumKalitesi = new List<genel_bilgiler>();
            DokumTonaj = database.DokumKalitesi(bastar.Text, bittar.Text);
            database.disConnect();

            foreach (var kolon in DokumTonaj)
            {
                var TANIM = kolon.DOKUMNO.ToString();
                var KALITE = kolon.KALITE.ToString();
                for (int m = 0; m <= FpSpread1.Rows.Count - 1; m++)
                {
                    var TANIM_ = FpSpread1.Sheets[0].Cells[m, 2].Text;
                    if (TANIM_ == TANIM)
                    {
                        FpSpread1.Sheets[0].Cells[m, FpSpread1.Columns.Count - 1].Text = KALITE.ToString();
                    }
                }
            }



        }


        protected void Button2_Click(object sender, EventArgs e)
        {

            //FpSpread1.SaveExcel("C:\testfile.xlsx", FarPoint.Excel.ExcelSaveFlags.SaveCustomColumnHeaders);

            appdirname = Request.ApplicationPath;
            pathname = HttpContext.Current.Server.MapPath(Request.ApplicationPath);
            string newfilepath;
            string filename = "Documents\\ALJAYLAR.xls";

            newfilepath = pathname + filename;

            //Store the path name
            //FpSpread1.SaveExcelToResponse(newfilepath);

            FpSpread1.SaveExcelToResponse("alyajlar.xls");

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kayıtlar update edildi kontrol edelim...", MessageBox.MesajTipleri.Info, false, 5);

        

        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("../../Default2.ASPX");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {

            string excelFilePath = @"\\192.168.198.8\Documents\alyajlar.xlsx";
            System.IO.FileInfo file = new System.IO.FileInfo(excelFilePath);

            if (file.Exists)
            {


                FarPoint.Web.Spread.FpSpread fpSpread1 = new FarPoint.Web.Spread.FpSpread();
                FarPoint.Web.Spread.SheetView shv = new FarPoint.Web.Spread.SheetView();
                Controls.Add(fpSpread1);
                //  fpSpread1.Sheets.Add(shv);
                string fileName;
                fileName = excelFilePath;
                //fpSpread1.OpenExcel(fileName);


                //FpSpread1.OpenExcel(fileName, FarPoint.Excel.ExcelOpenFlags.NoFlagsSet);
                FpSpread1.OpenExcel(@"\\192.168.198.8\Documents\alyajlar.xlsx", FarPoint.Excel.ExcelOpenFlags.NoFlagsSet);

                FpSpread1.ActiveSheetView.PageSize = FpSpread1.Rows.Count;


            }
            else
            {

                MessageBox.Show("Yuklenecek Dosyayı Seçin...", MessageBox.MesajTipleri.Error, false, 5);
            }

            //if (FileUpload1.PostedFile.FileName != "")
            //{
            //    try
            //    {
            //            appdirname = Request.ApplicationPath;   
            //            pathname = HttpContext.Current.Server.MapPath(Request.ApplicationPath);
            //            OpenExcelFile("Documents\\"+ FileUpload1.PostedFile.FileName);

            //            FpSpread1.Sheets[0].PageSize = 20;
            //            FpSpread1.Sheets[0].AllowPage = false;
            //    }
            //            catch (IOException ex)
            //    {
            //          // Label1.Text = "dosya yok";
            //    }

            //}
            //    else
            //{
            //    MessageBox.Show("Yuklenecek Dosyayı Seçin...", MessageBox.MesajTipleri.Error, false, 5);
            //}

        }


        public void OpenExcelFile(string filename)
        {
            bool ret;
            string newfilepath;

            newfilepath = pathname + filename;

            //Open
            try
            {

                //ret = FpSpread1.OpenExcel(@"\\192.168.198.8\c$\Web Projeleri\diler\diler.Web\Documents\alyajlar.xls");
                //ret = FpSpread1.OpenExcel(@"\\WEBSERVER2\Documents\Documents\alyajlar.xls");
                ret = FpSpread1.OpenExcel("http:\\192.168.198.8\\Documents\\alyajlar.xls");




                if (ret == false)
                {
                    //Error opening file
                    //Label2.ForeColor = Color.Red;
                    //Label2.Text = "PROBLEM: Could not open file - " + newfilepath;
                }
            }
            catch (Exception ex)
            {
                string c = ex.Message;
                //Label2.ForeColor = Color.Red;
                //Label2.Text = ex.Message.ToString();
            }
        }

        protected void FileUpload1_Init(object sender, EventArgs e)
        {
            try
            {


                if (FileUpload1.PostedFile.FileName != "")
                {
                    // check extension  
                    string ext = Path.GetExtension(FileUpload1.PostedFile.FileName);
                    switch (ext.ToLower())
                    {
                        case ".xls":
                            break;
                        default:
                            // Label1.Text = "Unfortunately the selected file type is not currently supported, sorry...";
                            return;
                    }

                    string sfn = Path.GetFileName(FileUpload1.PostedFile.FileName);

                    try
                    {
                    }
                    catch (IOException ex)
                    {
                        // Label1.Text = "Error uploading file: " + ex.Message;
                    }
                    catch (Exception er)
                    {
                        // Label1.Text += "Unknown error: " + er.Message;
                    }
                }
            }
            catch (Exception er)
            {
                // Label1.Text = "dosyayı seciniz";
            }


        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Hazırlama İşlemi Tamam...Omercik", MessageBox.MesajTipleri.Info, false, 5);

            Int32 x, y;
            Int32 Tarih, DokumNo;
            Decimal Deger;
            String Alanadi;
            FpSpread1.ColumnHeader.Visible = false;
            FpSpread2.ColumnHeader.Visible = false;

            FpSpread2.Rows.Count = 0;
            FpSpread2.Columns.Count = 6;

            for (x = 1; x <= FpSpread1.Rows.Count - 1; x++)
            {
                DokumNo = Convert.ToInt32(FpSpread1.Sheets[0].Cells[x, 1].Value);
                Tarih = Convert.ToInt32(FpSpread1.Sheets[0].Cells[x, 0].Value);

                for (y = 2; y <= FpSpread1.Columns.Count - 1; y++)
                {
                    Alanadi = (FpSpread1.Sheets[0].Cells[0, y].Text.ToString());
                    Deger = Convert.ToDecimal(FpSpread1.Sheets[0].Cells[x, y].Value);

                    //if (veriler_.kütükadet != "" && veriler_.kütükadet != "0")
                    if (Deger != 0)

                    {

                        FpSpread2.Rows.Count = FpSpread2.Rows.Count + 1;
                        FpSpread2.Sheets[0].Cells[FpSpread2.Rows.Count - 1, 0].Text = Tarih.ToString();
                        FpSpread2.Sheets[0].Cells[FpSpread2.Rows.Count - 1, 1].Text = DokumNo.ToString();
                        FpSpread2.Sheets[0].Cells[FpSpread2.Rows.Count - 1, 2].Text = Alanadi.ToString();
                        FpSpread2.Sheets[0].Cells[FpSpread2.Rows.Count - 1, 5].Text = Deger.ToString();
                    }
                }
            }

            database.connect();
            List<alyaj_tnm_bilgileri> kolonlarFull = new List<alyaj_tnm_bilgileri>();
            kolonlarFull = database.AljayKolonListFull();
            database.disConnect();

            FpSpread2.Sheets[0].ColumnCount = 6;
            foreach (var kolon in kolonlarFull)
            {
                var TANIM = kolon.TANIM.ToString();
                var GRUPTANIM = kolon.GRUPTANIM.ToString();
                var LOKASYON = kolon.LOKASYON.ToString();

                for (int m = 0; m <= FpSpread2.Rows.Count - 1; m++)
                {
                    var TANIM_ = FpSpread2.Sheets[0].Cells[m, 2].Text;
                    if (TANIM_ == TANIM)

                    {
                        FpSpread2.Sheets[0].Cells[m, 3].Text = GRUPTANIM.ToString();
                        FpSpread2.Sheets[0].Cells[m, 4].Text = LOKASYON.ToString();
                    }
                }
            }

        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            //FpSpread1.SaveExcel("C:\testfile.xlsx", FarPoint.Excel.ExcelSaveFlags.SaveCustomColumnHeaders);

            appdirname = Request.ApplicationPath;
            pathname = HttpContext.Current.Server.MapPath(Request.ApplicationPath);
            string newfilepath;
            string filename = "Documents\\ALJAYLAR_ozet";

            newfilepath = pathname + filename;

            //Store the path name
            //FpSpread1.SaveExcelToResponse(newfilepath);

            FpSpread2.SaveExcelToResponse("alyajlar_ozet");
        }
    }
}
