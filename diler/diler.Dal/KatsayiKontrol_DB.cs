using diler.Entity;
using System;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Types;
using Oracle.ManagedDataAccess.Client;
using System.Linq;
using System.Text;
using diler.Dal;
using System.Globalization;
using diler.Bll;

namespace diler.Dal
{
    public class KatsayiKontrol_DB
    {
        Int32 GelenTarih, GelenVrd;
        decimal Katsayi_Tartımdan_Value;

        OracleConnect DbConn = new OracleConnect();
        OracleConnect DbConn2 = new OracleConnect();
        OracleConnect DbConn3 = new OracleConnect();
        OracleConnect DbConn4 = new OracleConnect();


        public void connect()
        {

            DbConn.DbBaglan();
            DbConn2.DbBaglan();
            DbConn3.DbBaglan();
            DbConn4.DbBaglan();

        }
        public void disConnect()

        {
            DbConn.Close();
            DbConn2.Close();
            DbConn3.Close();
            DbConn4.Close();

        }
        public void Katsayi_Tartımdan_Bul(Int32 Tarih, Int16 Vrd, string Kalite, string Ebat, string Boy)
        {
            //09.08.2018 hatice tarafından düzenlendi.

            Katsayi_Tartımdan_Value = 0;

            string sql2 = "SELECT KATSAYI FROM URTTNM.KATSAYI_TARTIMDAN"
                        + " WHERE CC='" + Kalite + "'"
                        + " AND EBAT='" + Ebat + "'"
                        + " AND BOY='" + Boy + "'"
                        + " AND TARIH=" + Tarih + ""
                        + " AND VRD=" + Vrd + "";

            DbConn4.RaporWhile(sql2);

            while (DbConn4.MyDataReader.Read())
            {
                Katsayi_Tartımdan_Value = Convert.ToInt32(DbConn4.MyDataReader.GetValue(0).ToString());
            }


            if (Katsayi_Tartımdan_Value == 0)
            {

                sql2 = "SELECT KATSAYI FROM "
                                    + "("
                                    + " SELECT * FROM URTTNM.KATSAYI_TARTIMDAN"
                                    + " WHERE CC='" + Kalite + "'"
                                    + " AND EBAT='" + Ebat + "'"
                                    + " AND BOY='" + Boy + "'"
                                    + " ORDER BY TARIH DESC"
                                    + " )"
                                    + " WHERE ROWNUM = 1";

                DbConn3.RaporWhile(sql2);
                while (DbConn3.MyDataReader.Read())
                {
                    Katsayi_Tartımdan_Value = Convert.ToInt32(DbConn3.MyDataReader.GetValue(0).ToString());
                }

                if (Katsayi_Tartımdan_Value == 0)
                {

                    sql2 = "SELECT KATSAYI FROM "
                                   + "("
                                   + " SELECT * FROM URTTNM.KATSAYI_TARTIMDAN"
                                   + " AND EBAT='" + Ebat + "'"
                                   + " AND BOY='" + Boy + "'"
                                   + " ORDER BY TARIH DESC"
                                   + " )"
                                   + " WHERE ROWNUM = 1";

                    DbConn3.RaporWhile(sql2);
                    while (DbConn3.MyDataReader.Read())
                    {
                        Katsayi_Tartımdan_Value = Convert.ToInt32(DbConn3.MyDataReader.GetValue(0).ToString());
                    }


                }



            }
        }

        public string  Tonaj_Updateleri(Int32 DokumNo = 0, int DokumSiraNo = 0, decimal YeniTonaj=0, string HangiAlan="")
        {
            //    MESAJ = "BAŞARIYLA GÜNCELLENDİ.";
            //    sql = "UPDATE URTHRK.CH_DOKUMNO_ALYAJ_DATA SET MIKTAR=" + d1 + " " +
            //        "WHERE DOKUMNO=" + dokumno + " AND ALYAJTANIM='" + d2 + "'" + " AND LOKASYON ='" + d3 + "'";
            //}
            //DbConn.SaveUpdate(sql);
            //    return MESAJ; 

            string sqlnew = "";

            if (HangiAlan == "kutuk_tonaj")
            {
                sqlnew = "UPDATE URTHRK.CH_DOKUMNO_URETIM SET STDKTKTON=" + YeniTonaj.ToString().Replace(",", ".")
                     + " WHERE DNO=" + DokumNo
                     + " AND DSNO=" + DokumSiraNo;
            }
            if (HangiAlan == "karisim_tonaj")
            {
                sqlnew = "UPDATE URTHRK.CH_DOKUMNO_URETIM SET STNKARTON=" + YeniTonaj.ToString().Replace(",", ".")
                     + " WHERE DNO=" + DokumNo
                     + " AND DSNO=" + DokumSiraNo;
            }
            string MESAJ = "BAŞARIYLA GÜNCELLENDİ.";
            DbConn.Sayac(sqlnew);

            return "ok";

        }



        public List<katsayi_kontrol> DokumTip_Gunluk_Degerler(String Tarih_ = "")
        {

            List<katsayi_kontrol> veriler = new List<katsayi_kontrol>();

            string sql = "";
            String DTip = "";
            Int16 Adet = 0;
            Decimal Tonaj_ = 0;

            decimal Gun_TK_Tnj_ = 0;
            decimal Gun_ACYK_Tnj_ = 0;

            Int16 Gun_TK_Top_ = 0;
            Int16 Gun_ACYK_Top_ = 0;


            sql = "SELECT DOKUMTIP, COUNT(STDKTKSAY) FROM URTHRK.CH_DOKUMNO_URETIM"
                    + " WHERE DOKUMTAR=" + Convert.ToInt32(Tarih_)
                    + " AND DSNO=1"
                    + " GROUP BY DOKUMTIP";

            DbConn.RaporWhile(sql);
            DbConn.Sayac(sql);
            while (DbConn.MyDataReader.Read())
            {
                DTip = DbConn.MyDataReader.GetValue(0).ToString();
                Adet = Convert.ToInt16(DbConn.MyDataReader.GetValue(1).ToString());

                if (DTip == "TK")
                {
                    Gun_TK_Top_ += Adet;
                }
                if (DTip == "AC" || DTip == "YK")
                {
                    Gun_ACYK_Top_ += Adet;

                }

            }

            /// BURDA GUNUNU TONAJLARINI GETIR

            sql = "SELECT DOKUMTIP, SUM(STDKTKTON)+SUM(STNKARTON) FROM URTHRK.CH_DOKUMNO_URETIM"
                   + " WHERE DOKUMTAR=" + Convert.ToInt32(Tarih_)
                   + " GROUP BY DOKUMTIP";

            DbConn.RaporWhile(sql);
            DbConn.Sayac(sql);
            while (DbConn.MyDataReader.Read())
            {
                DTip = DbConn.MyDataReader.GetValue(0).ToString();
                Tonaj_ = Convert.ToDecimal(DbConn.MyDataReader.GetValue(1).ToString());

                if (DTip == "TK")
                {
                    Gun_TK_Tnj_ = ++Tonaj_;
                }
                if (DTip == "AC" || DTip == "YK")
                {
                    Gun_ACYK_Tnj_ = ++Tonaj_;
                }

            }

            katsayi_kontrol satir = new katsayi_kontrol();
            satir.Gun_TK_Top = Gun_TK_Top_;
            satir.Gun_ACYK_Top = Gun_ACYK_Top_;

            satir.Gun_TK_Tnj = Gun_TK_Tnj_;
            satir.Gun_ACYK_Tnj = Gun_ACYK_Tnj_;

            veriler.Add(satir);

            return veriler;

        }



        public List<katsayi_kontrol> DokumTip_Aylik_Degerler(String Tarih_ = "")
        {

            List<katsayi_kontrol> veriler = new List<katsayi_kontrol>();

            string sql = "";
            String DTip = "";
            string Ay_Adet = "0";
            string Ay_Tonaj_ = "0";

            decimal Ay_TK_Tnj_ = 0;
            decimal Ay_ACYK_Tnj_ = 0;

            Int32 Ay_TK_Top_ = 0;
            Int32 Ay_ACYK_Top_ = 0;

            CultureInfo provider = CultureInfo.InvariantCulture;


            sql = "select DOKUMTIP,COUNT(STDKTKSAY),SUM(STDKTKTON)+SUM(STNKARTON) from URTHRK.CH_DOKUMNO_URETIM "
                + " Where DOKUMTIP IS NOT NULL "
                + " AND DSNO=1 "
                + " AND DOKUMTAR BETWEEN '" + Tarih_.ToString().Substring(0, 6) + "01' AND '" + Tarih_ + "'"
                + " GROUP BY DOKUMTIP ";


            DbConn.RaporWhile(sql);
            DbConn.Sayac(sql);
            while (DbConn.MyDataReader.Read())
            {
                DTip = DbConn.MyDataReader.GetValue(0).ToString();
                Ay_Adet = DbConn.MyDataReader.GetValue(1).ToString();

                if (DTip == "TK")
                {
                    Ay_TK_Top_ += Convert.ToInt32(Ay_Adet);


                }
                if (DTip == "AC" || DTip == "YK")
                {
                    Ay_ACYK_Top_ += Convert.ToInt32(Ay_Adet);
                }

            }

            /// BURDA ayın TONAJLARINI GETIR
            //SL2 = "select DOKUMTIP,COUNT(STDKTKSAY),SUM(STDKTKTON)+SUM(STNKARTON) from URTHRK.CH_DOKUMNO_URETIM 


            sql = "select DOKUMTIP,COUNT(STDKTKSAY),SUM(STDKTKTON)+SUM(STNKARTON) from URTHRK.CH_DOKUMNO_URETIM "
                 + " Where DOKUMTIP IS NOT NULL "
                 + " AND DOKUMTAR BETWEEN '" + Tarih_.ToString().Substring(0, 6) + "01' AND '" + Tarih_ + "'"
                 + " GROUP BY DOKUMTIP ";


            DbConn.RaporWhile(sql);
            DbConn.Sayac(sql);
            while (DbConn.MyDataReader.Read())
            {
                DTip = DbConn.MyDataReader.GetValue(0).ToString();
                Ay_Tonaj_ = DbConn.MyDataReader.GetValue(2).ToString();

                if (DTip == "TK")
                {
                    Ay_TK_Tnj_ += Convert.ToDecimal(Ay_Tonaj_);
                }
                if (DTip == "AC" || DTip == "YK")
                {
                    Ay_ACYK_Tnj_ += Convert.ToDecimal(Ay_Tonaj_);
                }

            }

            katsayi_kontrol satir = new katsayi_kontrol();
            satir.Ay_TK_Top = Ay_TK_Top_;
            satir.Ay_ACYK_Top = Ay_ACYK_Top_;

            satir.Ay_TK_Tnj = Ay_TK_Tnj_;
            satir.Ay_ACYK_Tnj = Ay_ACYK_Tnj_;

            veriler.Add(satir);

            return veriler;

        }



        public List<katsayi_kontrol> DokumTip_Yillik_Degerler(String Tarih_ = "")
        {

            List<katsayi_kontrol> veriler = new List<katsayi_kontrol>();

            string sql = "";
            String DTip = "";
            string Yil_Adet = "0";
            string Yil_Tonaj_ = "0";

            decimal Yil_TK_Tnj_ = 0;
            decimal Yil_ACYK_Tnj_ = 0;

            Int32 Yil_TK_Top_ = 0;
            Int32 Yil_ACYK_Top_ = 0;

            CultureInfo provider = CultureInfo.InvariantCulture;


            sql = "select DOKUMTIP,COUNT(STDKTKSAY),SUM(STDKTKTON)+SUM(STNKARTON) from URTHRK.CH_DOKUMNO_URETIM "
                + " Where DOKUMTIP IS NOT NULL "
                + " AND DSNO=1 "
                + " AND DOKUMTAR BETWEEN '" + Tarih_.ToString().Substring(0, 4) + "0101' AND '" + Tarih_ + "'"
                + " GROUP BY DOKUMTIP ";


            DbConn.RaporWhile(sql);
            DbConn.Sayac(sql);
            while (DbConn.MyDataReader.Read())
            {
                DTip = DbConn.MyDataReader.GetValue(0).ToString();
                Yil_Adet = DbConn.MyDataReader.GetValue(1).ToString();

                if (DTip == "TK")
                {
                    Yil_TK_Top_ = Convert.ToInt32(Yil_TK_Top_) + Convert.ToInt32(Yil_Adet);


                }
                if (DTip == "AC" || DTip == "YK")
                {
                    Yil_ACYK_Top_ = Convert.ToInt32(Yil_ACYK_Top_) + Convert.ToInt32(Yil_Adet);
                }

            }

            /// BURDA ayın TONAJLARINI GETIR
            //SL2 = "select DOKUMTIP,COUNT(STDKTKSAY),SUM(STDKTKTON)+SUM(STNKARTON) from URTHRK.CH_DOKUMNO_URETIM 


            sql = "select DOKUMTIP,COUNT(STDKTKSAY),SUM(STDKTKTON)+SUM(STNKARTON) from URTHRK.CH_DOKUMNO_URETIM "
                 + " Where DOKUMTIP IS NOT NULL "
                 + " AND DOKUMTAR BETWEEN '" + Tarih_.ToString().Substring(0, 4) + "0101' AND '" + Tarih_ + "'"
                 + " GROUP BY DOKUMTIP ";


            DbConn.RaporWhile(sql);
            DbConn.Sayac(sql);
            while (DbConn.MyDataReader.Read())
            {
                DTip = DbConn.MyDataReader.GetValue(0).ToString();
                Yil_Tonaj_ = DbConn.MyDataReader.GetValue(2).ToString();

                if (DTip == "TK")
                {
                    Yil_TK_Tnj_ = Convert.ToDecimal(Yil_TK_Tnj_) + Convert.ToDecimal(Yil_Tonaj_);
                }
                if (DTip == "AC" || DTip == "YK")
                {
                    Yil_ACYK_Tnj_ = Convert.ToDecimal(Yil_ACYK_Tnj_) + Convert.ToDecimal(Yil_Tonaj_);
                }

            }

            katsayi_kontrol satir = new katsayi_kontrol();
            satir.Yıl_TK_Top = Yil_TK_Top_;
            satir.Yıl_ACYK_Top = Yil_ACYK_Top_;

            satir.Yıl_TK_Tnj = Yil_TK_Tnj_;
            satir.Yıl_ACYK_Tnj = Yil_ACYK_Tnj_;

            veriler.Add(satir);

            return veriler;

        }



        public List<katsayi_kontrol> GunBazındaVeriler(int bastarx = 0, int bittarx = 0)
        {
            List<katsayi_kontrol> veriler = new List<katsayi_kontrol>();
            string sql = "Select DNO,DSNO,VRD,KALITE,EBAT,BOY,STDKTKSAY,STDKTKTON,STNKARSAY,STNKARTON,DOKUMTAR "+
                         "FROM URTHRK.CH_DOKUMNO_URETIM WHERE DOKUMTAR BETWEEN " + bastarx + " AND " + bastarx + " order by DNO";

            DbConn.RaporWhile(sql);
            DbConn.Sayac(sql);
            while (DbConn.MyDataReader.Read())
            {
                katsayi_kontrol satir = new katsayi_kontrol();
                satir.dokumNo= DbConn.MyDataReader.GetValue(0).ToString();//DNO
                satir.sira= DbConn.MyDataReader.GetValue(1).ToString();//DSNO
                satir.vrd = DbConn.MyDataReader.GetValue(2).ToString();//VRD
                satir.celikcinsi = DbConn.MyDataReader.GetValue(3).ToString();//
                satir.ebat = DbConn.MyDataReader.GetValue(4).ToString();//
                satir.boy = DbConn.MyDataReader.GetValue(5).ToString();//

                               

                satir.kütükadet= DbConn.MyDataReader.GetValue(6).ToString();//
                satir.kütüktonaj = DbConn.MyDataReader.GetValue(7).ToString();//
                

                satir.karisimadet = DbConn.MyDataReader.GetValue(8).ToString();//
                satir.karisimtonaj = DbConn.MyDataReader.GetValue(9).ToString();//

                Int32 DokumTarx = Convert.ToInt32(DbConn.MyDataReader.GetValue(10).ToString());

               
                Katsayi_Tartımdan_Bul(DokumTarx, Convert.ToInt16(satir.vrd), satir.celikcinsi, satir.ebat, satir.boy);
               

                if (Katsayi_Tartımdan_Value != 0)
                {
                    satir.tartim_katsayisi =Katsayi_Tartımdan_Value.ToString();
                }
                else
                {
                    satir.tartim_katsayisi = "0";
                }

                veriler.Add(satir);

            }
            return veriler;
        }
    }

}
