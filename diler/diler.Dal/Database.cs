using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using diler.Entity;
using diler.Bll;
using System.Data;
using DevExpress.Utils.OAuth.Provider;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace diler.Dal
{
    public class Database
    {
        public string AljayTanımı;
        public string AljayDegeri;
        public string AljayDokumNo;
        public string bas_tarih, iskarta_tarihi;
        public string gelentarih;
        public string gelenBasTar;
        public string gelenBitTar;
        public string gelenVardiya;
        public string gelenDokumdurumu;
        public string gelendokumTip;
        public string gelendurusKodu;
        public string gelenarizaKodu;
        public string gelenTonaj;
        public string gelenDokum;
        public string boy;
        public string tarih_parse;
        public string gelenyenidokum_refrakter;
        public string gelen_tandis_miktari;
        dynamic DonenDeger;
        string DonenDeger2;
        string toplam_tonaj;
        string stdktkton, stnkarton;
        string yemek_sql;
        dynamic gun_kontrol;
        dynamic Sarj1_degeri;
        dynamic Sarj2_degeri;
        dynamic Sarj3_degeri;
        dynamic Sarj4_degeri;
        dynamic Toplam_sarj1, Toplam_sarj2, Toplam_sarj3, Toplam_sarj4, Toplam_sarj;




        OracleConnection conn;
        OracleConnection conn2;
        string connetionString;
        string sql;
        OracleCommand cmd;
        OracleDataReader dr;
        OracleDataReader dr2;

        OracleConnect DbConn = new OracleConnect();
        OracleConnect DbConn2 = new OracleConnect();
        public void connect()
        {

            DbConn.DbBaglan();

        }
        public void disConnect()

        {
            DbConn.Close();

        }


        public List<string> AljayKolonList()
        {
            List<string> AlyajKolon = new List<string>();
            string sql = "Select ALYAJTANIMI from URTTNM.CH_ALYAJ_TNM WHERE EKRAN=1 ORDER BY LOKASYON,EKRANSIRANO";
            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {
                string Tnm = DbConn.MyDataReader["ALYAJTANIMI"].ToString();
                AlyajKolon.Add(Tnm);
            }
            return AlyajKolon;

        }

        


        public List<string> DokumNolarList(string bastar, string bittar)
        {

            gelenBasTar = tarihFormat(bastar);
            gelenBitTar = tarihFormat(bittar);

            List<string> DokumNolar = new List<string>();
            string sql = "Select DNO FROM URTHRK.CH_DOKUMNO_URETIM WHERE DOKUMTAR BETWEEN " + gelenBasTar + " AND " + gelenBitTar + " order by DNO";
            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {
                string Tnm = DbConn.MyDataReader["DNO"].ToString();
                DokumNolar.Add(Tnm);
            }
            return DokumNolar;

        }
        public dynamic tarihFormat(object gelen)
        {

            dynamic yil = Convert.ToDateTime(gelen).Year.ToString();
            dynamic ay = Convert.ToDateTime(gelen).Month.ToString();
            dynamic gun = Convert.ToDateTime(gelen).Day.ToString();
            if (ay.Length == 1)
            {
                ay = "0" + ay;
            }
            if (gun.Length == 1)
            {
                gun = "0" + gun;
            }
            gelentarih = yil + ay + gun;
            return gelentarih;

        }

        public List<string> DokumunDegerleri(string bastar, string bittar)
        {

            gelenBasTar = tarihFormat(bastar);
            gelenBitTar = tarihFormat(bittar);

            List<string> AlyajDegeri = new List<string>();
            string sql = "Select DOKUMNO,ALYAJTANIM,MIKTAR FROM URTHRK.CH_DOKUMNO_ALYAJ_DATA WHERE TARIH BETWEEN " + gelenBasTar + " AND " + gelenBitTar + " order by DOKUMNO";

            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {
                AljayDokumNo = DbConn.MyDataReader.GetValue(0).ToString();
                AljayTanımı = DbConn.MyDataReader.GetValue(1).ToString();
                AljayDegeri = DbConn.MyDataReader.GetValue(2).ToString();

                if (AljayDokumNo != "0" && AljayDegeri != "0" ) { 

                AlyajDegeri.Add(AljayDokumNo);
                AlyajDegeri.Add(AljayTanımı);
                AlyajDegeri.Add(AljayDegeri);
                }
            }
            return AlyajDegeri;

        }


        //*****************
        public dynamic GunKontroluYap(DateTime tarih, string KULLANICI)
        {
            dynamic DegerAO = 0;
            dynamic DegerPO = 0;
            dynamic DegerSDM = 0;
            dynamic DegerUretim = 0;
            gelentarih = tarih.ToString("yyyyMMdd");//veritabanindaki kayit bicimi     
            gun_kontrol = "False";
            string sql = "SELECT AO,PO,SDM,KIMYALAB FROM URTTNM.PRGACKAPAT WHERE TARIH=" + gelentarih + "";
            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {
                DegerAO = DbConn.MyDataReader.GetValue(0);
                DegerPO = DbConn.MyDataReader.GetValue(1);
                DegerSDM = DbConn.MyDataReader.GetValue(2);
                DegerUretim = DbConn.MyDataReader.GetValue(3);
            }
            if (KULLANICI == "CHAOOPR")
            {
                if (DegerAO == 0)
                {
                    gun_kontrol = "True";

                }
                if (DegerAO == 1)
                {
                    gun_kontrol = "False";

                }
            }

            if (KULLANICI == "CHPOOPR")
            {
                if (DegerPO == 0)
                {
                    gun_kontrol = "True";
                }

                if (DegerPO == 1)
                {
                    gun_kontrol = "False";
                }
            }
            if (KULLANICI == "CHSDMOPR")
            {
                if (DegerSDM == 0)
                {
                    gun_kontrol = "True";
                }
                if (DegerSDM == 1)
                {
                    gun_kontrol = "False";
                }
            }

            if (KULLANICI == "OPRKIM")
            {

                if (DegerUretim == 0)
                {
                    gun_kontrol = "True";
                }
                if (DegerUretim == 1)
                {
                    gun_kontrol = "False";
                }
            }


            if (KULLANICI == "CHREFOPR")
            {
                if (DegerPO == 0)
                {
                    gun_kontrol = "True";

                }
                if (DegerPO == 1)
                {
                    gun_kontrol = "False";
                }

            }
            //if (DegerAO == 0 && DegerPO == 0 && DegerSDM == 0 && DegerUretim == 0)
            //{
            //    gun_kontrol = "True";

            //}
            //else
            //{

            //    if (DegerAO == 1 && DegerPO == 1 && DegerSDM == 1 && DegerUretim == 1)
            //        gun_kontrol = "False";


            //}
            return gun_kontrol;


        }

        public dynamic tarihFormat1(int gelen)
        {
            string yil = (gelen / 10000).ToString();
            int aygun = gelen % 10000;
            string ay = (aygun / 100).ToString();
            string gun = (aygun % 100).ToString();
            if (gun.Length == 1)
            {
                gun = "0" + gun;

            }
            if (ay.Length == 1)
            {
                ay = "0" + ay;
            }

            tarih_parse = (gun + "." + ay + "." + yil).ToString();
            return tarih_parse;

        }

        public List<uretim_bilgileri> dokum_listesi(DateTime tarih)
        {
            List<uretim_bilgileri> veriler = new List<uretim_bilgileri>();
            gelentarih = tarih.ToString("yyyyMMdd");//veritabanindaki kayit bicimi   
            string sql = "select DISTINCT DNO from URTHRK.CH_DOKUMNO_URETIM WHERE DOKUMTAR=" + gelentarih + " ORDER BY DNO ASC";
            DbConn.RaporWhile(sql);
            DbConn.Sayac(sql);
            while (DbConn.MyDataReader.Read())
            {
                uretim_bilgileri satir = new uretim_bilgileri();
                satir.DOKUMNO = DbConn.MyDataReader.GetValue(0);
                //  satir.DOKUMNO = DbConn.MyDataReader["DNO"];
                veriler.Add(satir);

            }
            return veriler;
        }

        public List<uretim_bilgileri> dokum_ozellikleri_liste(DateTime tarih)
        {
            List<uretim_bilgileri> veriler = new List<uretim_bilgileri>();
            gelentarih = tarih.ToString("yyyyMMdd");//veritabanindaki kayit bicimi   
            string sql = "select DISTINCT DNO,VRD,DOKUMTAR from URTHRK.CH_DOKUMNO_URETIM WHERE DOKUMTAR=" + gelentarih + " ORDER BY DNO ASC";
            DbConn.RaporWhile(sql);
            DbConn.Sayac(sql);
            while (DbConn.MyDataReader.Read())
            {
                uretim_bilgileri satir = new uretim_bilgileri();
                satir.DOKUMNO = DbConn.MyDataReader.GetValue(0);
                satir.vardiya = DbConn.MyDataReader.GetValue(1).ToString();
                satir.dokumtarihi = DbConn.MyDataReader.GetValue(2).ToString();
                //  satir.DOKUMNO = DbConn.MyDataReader["DNO"];
                veriler.Add(satir);

            }
            return veriler;
        }
        public string dokum_ozellikleri_kayit(object vardiya, object dokumno, object dokumtarihi)
        {

            string MESAJ;
            MESAJ = "BAŞARIYLA GÜNCELLENDİ.";
            string sql_uretim = "UPDATE URTHRK.CH_DOKUMNO_URETIM SET VRD=" + vardiya + ", DOKUMTAR= " + dokumtarihi + " " +
                 "WHERE DNO=" + dokumno + "";
            DbConn.SaveUpdate(sql_uretim);
            string sql_durus = "UPDATE URTHRK.CH_DOKUMNO_DURUS_DATA SET VRD=" + vardiya + ", BASTAR= " + dokumtarihi + ",BITTAR=" + dokumtarihi + " " +
                              "WHERE DNO=" + dokumno + "";
            DbConn.SaveUpdate(sql_durus);
            string sql_enerji = "UPDATE URTHRK.CH_DOKUMNO_ENERJI_DATA SET TARIH= " + dokumtarihi + " " +
                                 "WHERE DOKUMNO=" + dokumno + "";
            DbConn.SaveUpdate(sql_enerji);
            string sql_genelbilgi = "UPDATE URTHRK.CH_DOKUMNO_GENELBILGILER_DATA SET TARIH= " + dokumtarihi + " " +
                                 "WHERE DOKUMNO=" + dokumno + "";
            DbConn.SaveUpdate(sql_genelbilgi);
            string sql_hurda = "UPDATE URTHRK.CH_DOKUMNO_HURDA_DATA SET TARIH= " + dokumtarihi + " " +
                                "WHERE DOKUMNO=" + dokumno + "";
            DbConn.SaveUpdate(sql_hurda);
            string sql_refrakter = "UPDATE URTHRK.CH_DOKUMNO_REFRAKTER SET TARIH= " + dokumtarihi + " " +
                                   "WHERE DNO=" + dokumno + "";
            DbConn.SaveUpdate(sql_refrakter);
            string sql_sarf = "UPDATE URTHRK.CH_DOKUMNO_SARFMALZEME_DATA SET TARIH= " + dokumtarihi + " " +
                                 "WHERE DOKUMNO=" + dokumno + "";
            DbConn.SaveUpdate(sql_sarf);

            return MESAJ;

        }

        //Alyaj
        public List<alyaj_bilgileri> alyaj_listesi(object dokumno, string lokasyon)
        {
            List<alyaj_bilgileri> veriler = new List<alyaj_bilgileri>();
            string sql = "SELECT LOKASYON,ALYAJTANIMI FROM URTTNM.CH_ALYAJ_TNM" +
                " WHERE EKRAN=1 AND LOKASYON IN('" + lokasyon + "')" + " ORDER BY LOKASYON,EKRANSIRANO";
            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {
                alyaj_bilgileri satir = new alyaj_bilgileri();
                satir.SARJTIP = DbConn.MyDataReader.GetValue(1).ToString();
                satir.LOKASYON = DbConn.MyDataReader.GetValue(0).ToString();
                alyaj_degeri_bul(dokumno, DbConn.MyDataReader.GetValue(0), DbConn.MyDataReader.GetValue(1));
                satir.DEGERI = DonenDeger;
                veriler.Add(satir);
            }
            return veriler;
        }
        public void alyaj_degeri_bul(object DokumNox, object Lokasyonux, object AlyajTanimx)
        {
            DonenDeger = 0;
            string Sql = "SELECT MIKTAR FROM URTHRK.CH_DOKUMNO_ALYAJ_DATA" +
                " WHERE DOKUMNO=" + DokumNox + " and ALYAJTANIM='" + AlyajTanimx + "'" + " and LOKASYON='" + Lokasyonux + "'";
            DbConn2.DbBaglan();
            DbConn2.RaporWhile(Sql);
            while (DbConn2.MyDataReader.Read())
            {
                DonenDeger = DbConn2.MyDataReader.GetValue(0).ToString();
            }
            DbConn2.Close();
        }
        public string alyaj_kayit(DateTime tarih, object dokumno, object d1, object d2, object d3)
        {
            dynamic kayitVarmi = 0;
            dynamic GrupKodu = null;
            string sql, MESAJ;
            sql = "SELECT count(DOKUMNO) from URTHRK.CH_DOKUMNO_ALYAJ_DATA " +
                " WHERE DOKUMNO=" + dokumno + " AND ALYAJTANIM='" + d2 + "'" + " AND LOKASYON ='" + d3 + "'";
            DbConn.Sayac(sql);
            kayitVarmi = DbConn.GeriDonenRakam;
            GrupKodu = "";
            gelentarih = tarih.ToString("yyyyMMdd");//veritabanindaki kayit bicimi  
            sql = "SELECT GRUPTANIMI FROM URTTNM.CH_ALYAJ_TNM " +
                  " WHERE ALYAJTANIMI='" + d2 + "'";
            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {
                GrupKodu = DbConn.MyDataReader.GetValue(0).ToString();
            }
            if (kayitVarmi == 0)
            {
                MESAJ = "BAŞARIYLA EKLENDİ.";
                sql = "INSERT INTO URTHRK.CH_DOKUMNO_ALYAJ_DATA VALUES(" + gelentarih + "," + dokumno + "," +
                    "'" + d2 + "','" + GrupKodu + "','" + d3 + "'," + d1 + ",NULL" + ")";
            }
            else
            {
                MESAJ = "BAŞARIYLA GÜNCELLENDİ.";
                sql = "UPDATE URTHRK.CH_DOKUMNO_ALYAJ_DATA SET MIKTAR=" + d1 + " " +
                    "WHERE DOKUMNO=" + dokumno + " AND ALYAJTANIM='" + d2 + "'" + " AND LOKASYON ='" + d3 + "'";
            }
            DbConn.SaveUpdate(sql);
            return MESAJ;

        }

        //Hurda

        public List<hurda_bilgileri> hurda_listesi(DateTime tarih, object dokumno)
        {
            List<hurda_bilgileri> veriler = new List<hurda_bilgileri>();
            gelentarih = tarih.ToString("yyyyMMdd");//veritabanindaki kayit bicimi     
            string sql = "SELECT HURDATANIMI FROM URTTNM.CH_HURDA_TNM" +
                         " WHERE EKRAN=1" + " ORDER BY EKRANSIRANO";
            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {
                DonenDeger = 0;
                hurda_bilgileri satir = new hurda_bilgileri();
                satir.HURDATIP = DbConn.MyDataReader.GetValue(0).ToString();
                hurda_degeri_bul(gelentarih, dokumno, DbConn.MyDataReader.GetValue(0));
                satir.SARJ1 = Sarj1_degeri;
                satir.SARJ2 = Sarj2_degeri;
                satir.SARJ3 = Sarj3_degeri;
                satir.SARJ4 = Sarj4_degeri;
                satir.TOPLAM = Convert.ToDecimal(Sarj1_degeri) + Convert.ToDecimal(Sarj2_degeri) + Convert.ToDecimal(Sarj3_degeri) + Convert.ToDecimal(Sarj4_degeri);
                veriler.Add(satir);
            }

            return veriler;
        }
        public void hurda_degeri_bul(string tarih, object DokumNo, object HurdaTanimi)
        {
            Sarj1_degeri = 0;
            string sql = "SELECT MIKTAR FROM URTHRK.CH_DOKUMNO_HURDA_DATA" +
                " WHERE TARIH=" + tarih + " AND DOKUMNO=" + DokumNo + " AND HURDATANIM='" + HurdaTanimi + "'" + " AND SARJNO=1";
            DbConn2.DbBaglan();
            DbConn2.RaporWhile(sql);
            while (DbConn2.MyDataReader.Read())
            {
                Sarj1_degeri = DbConn2.MyDataReader.GetValue(0).ToString();
            }
            Sarj2_degeri = 0;
            sql = "SELECT MIKTAR FROM URTHRK.CH_DOKUMNO_HURDA_DATA" +
                " WHERE TARIH=" + tarih + " AND DOKUMNO=" + DokumNo + " AND HURDATANIM='" + HurdaTanimi + "'" + " AND SARJNO=2";
            DbConn2.RaporWhile(sql);
            while (DbConn2.MyDataReader.Read())
            {
                Sarj2_degeri = DbConn2.MyDataReader.GetValue(0).ToString();
            }
            Sarj3_degeri = 0;
            sql = "SELECT MIKTAR FROM URTHRK.CH_DOKUMNO_HURDA_DATA" +
                " WHERE TARIH=" + tarih + " AND DOKUMNO=" + DokumNo + " AND HURDATANIM='" + HurdaTanimi + "'" + " AND SARJNO=3";
            DbConn2.RaporWhile(sql);
            while (DbConn2.MyDataReader.Read())
            {
                Sarj3_degeri = DbConn2.MyDataReader.GetValue(0).ToString();
            }
            Sarj4_degeri = 0;
            sql = "SELECT MIKTAR FROM URTHRK.CH_DOKUMNO_HURDA_DATA" +
                " WHERE TARIH=" + tarih + " AND DOKUMNO=" + DokumNo + " AND HURDATANIM='" + HurdaTanimi + "'" + " AND SARJNO=4";
            DbConn2.RaporWhile(sql);
            while (DbConn2.MyDataReader.Read())
            {
                Sarj4_degeri = DbConn2.MyDataReader.GetValue(0).ToString();
            }

            DbConn2.Close();
        }
        public string hurda_kayit(DateTime tarih, object DokumNo, object SarjNo, object HurdaTanim, object Degeri)
        {
            string sql, MESAJ;
            gelentarih = tarih.ToString("yyyyMMdd");//veritabanindaki kayit bicimi   
            sql = "SELECT COUNT(DOKUMNO) FROM URTHRK.CH_DOKUMNO_HURDA_DATA " +
                " WHERE DOKUMNO=" + DokumNo + " AND HURDATANIM='" + HurdaTanim + "'" + " AND SARJNO =" + SarjNo + " AND TARIH=" + gelentarih + "";
            DbConn.Sayac(sql);
            dynamic kayitVarmi = DbConn.GeriDonenRakam;
            if (kayitVarmi == 0)
            {
                MESAJ = "BAŞARIYLA EKLENDİ.";
                sql = "INSERT INTO URTHRK.CH_DOKUMNO_HURDA_DATA VALUES(" + gelentarih + "," + DokumNo + "," + SarjNo + "," + "'" + HurdaTanim + "'," + Degeri + "" + ")";
            }
            else
            {
                MESAJ = "BAŞARIYLA GÜNCELLENDİ. ";
                sql = "UPDATE URTHRK.CH_DOKUMNO_HURDA_DATA set MIKTAR=" + Degeri + " " +
                      " WHERE DOKUMNO=" + DokumNo + " AND HURDATANIM='" + HurdaTanim + "' AND SARJNO =" + SarjNo + " AND TARIH=" + gelentarih + "";
            }
            DbConn.SaveUpdate(sql);
            return MESAJ;
        }
        public List<string> Toplam_Sarj_(object dokumno, DateTime tarih)
        {

            List<string> secilenler = new List<string>();
            gelentarih = tarih.ToString("yyyyMMdd");//veritabanindaki kayit bicimi     
            string sql;
            Toplam_sarj1 = 0;
            sql = "SELECT SUM(MIKTAR) FROM CH_DOKUMNO_HURDA_DATA  WHERE DOKUMNO =" + dokumno + " AND  TARIH=" + gelentarih + " AND SARJNO=1";
            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {
                Toplam_sarj1 = DbConn.MyDataReader.GetValue(0).ToString();
                secilenler.Add(Toplam_sarj1);
            }
            Toplam_sarj2 = 0;
            sql = "SELECT SUM(MIKTAR) FROM CH_DOKUMNO_HURDA_DATA  WHERE DOKUMNO =" + dokumno + " AND  TARIH=" + gelentarih + " AND SARJNO=2";
            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {
                Toplam_sarj2 = DbConn.MyDataReader.GetValue(0).ToString();
                secilenler.Add(Toplam_sarj2);
            }
            Toplam_sarj3 = 0;
            sql = "SELECT SUM(MIKTAR) FROM CH_DOKUMNO_HURDA_DATA  WHERE DOKUMNO =" + dokumno + " AND  TARIH=" + gelentarih + " AND SARJNO=3";
            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {
                Toplam_sarj3 = DbConn.MyDataReader.GetValue(0).ToString();
                secilenler.Add(Toplam_sarj3);
            }
            Toplam_sarj4 = 0;
            sql = "SELECT SUM(MIKTAR) FROM CH_DOKUMNO_HURDA_DATA  WHERE DOKUMNO =" + dokumno + " AND  TARIH=" + gelentarih + " AND SARJNO=4";
            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {
                Toplam_sarj4 = DbConn.MyDataReader.GetValue(0).ToString();
                secilenler.Add(Toplam_sarj4);
            }
            Toplam_sarj = 0;
            sql = "SELECT SUM(MIKTAR) FROM CH_DOKUMNO_HURDA_DATA  WHERE DOKUMNO =" + dokumno + " AND  TARIH=" + gelentarih + "";
            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {
                Toplam_sarj = DbConn.MyDataReader.GetValue(0).ToString();
                secilenler.Add(Toplam_sarj);
            }

            return secilenler;

        }



        //Sarf

        public List<sarf_bilgileri> Sarf_Listesi(object dokumno)
        {
            List<sarf_bilgileri> veriler = new List<sarf_bilgileri>();
            string sql = "SELECT MALZEMETANIMI FROM URTTNM.CH_SARFMALZEME_TNM" + " WHERE EKRAN=1 AND LOKASYON IN('SDM')" + " ORDER BY LOKASYON,EKRANSIRANO";
            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {
                sarf_bilgileri satir = new sarf_bilgileri();
                satir.SARFMLZTNM = DbConn.MyDataReader.GetValue(0).ToString();
                sarf_degeri_bul(dokumno, DbConn.MyDataReader.GetValue(0));
                if (DbConn.MyDataReader.GetValue(0).ToString() == "STARTER TUBE (ADET)")
                    DonenDeger = "6";
                if (DbConn.MyDataReader.GetValue(0).ToString() == "ÇANAK (WELL BLOCK) (ADET)")
                    DonenDeger = "6";
                if (DbConn.MyDataReader.GetValue(0).ToString() == "PÜSKÜRTME (TON)")
                    DonenDeger = "2.2";
                if (DbConn.MyDataReader.GetValue(0).ToString() == "TURBOSTOP (ADET)")
                    DonenDeger = "1";
                if (DbConn.MyDataReader.GetValue(0).ToString() == "UPPER PLATE (ADET)")
                    DonenDeger = "6";
                if (DbConn.MyDataReader.GetValue(0).ToString() == "MIDDLE PLATE (ADET)")
                    DonenDeger = "6";
                if (DbConn.MyDataReader.GetValue(0).ToString() == "LOWER PLATE (ADET)")
                    DonenDeger = "6";
                if (DbConn.MyDataReader.GetValue(0).ToString() == "GASKET C52")
                    DonenDeger = "6";
                satir.DEGERI = DonenDeger;
                veriler.Add(satir);
            }
            return veriler;
        }
        public List<sarf_bilgileri> sarf_veriler(object dokumno, object lokasyon)
        {
            List<sarf_bilgileri> veriler = new List<sarf_bilgileri>();
            string sql = "SELECT MALZEMETANIMI FROM URTTNM.CH_SARFMALZEME_TNM " +
                " WHERE EKRAN=1 AND LOKASYON IN('" + lokasyon + "') " +
                " ORDER BY LOKASYON,EKRANSIRANO";

            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {
                sarf_bilgileri satir = new sarf_bilgileri();
                satir.SARFMLZTNM = DbConn.MyDataReader.GetValue(0).ToString();
                sarf_degeri_bul(dokumno, DbConn.MyDataReader.GetValue(0));
                satir.DEGERI = DonenDeger;
                veriler.Add(satir);
            }
            return veriler;
        }
        public void sarf_degeri_bul(object DokumNox, object MalzemeTanımx)
        {
            DonenDeger = 0;
            dynamic Sql = "SELECT MIKTAR FROM URTHRK.CH_DOKUMNO_SARFMALZEME_DATA" + " WHERE DOKUMNO=" + DokumNox + " and SARFMALZEMETANIM='" + MalzemeTanımx + "'";
            DbConn2.DbBaglan();
            DbConn2.RaporWhile(Sql);
            while (DbConn2.MyDataReader.Read())
            {
                DonenDeger = DbConn2.MyDataReader.GetValue(0).ToString();
            }
            DbConn2.Close();

        }
        public string sarf_kayit(DateTime tarih, object dokumno, object d1, object d2, object d3)
        {
            dynamic kayitVarmi, MESAJ;
            gelentarih = tarih.ToString("yyyyMMdd");//veritabanindaki kayit bicimi     
            string sql = "select count(DOKUMNO) from URTHRK.CH_DOKUMNO_SARFMALZEME_DATA " +
                " where DOKUMNO=" + dokumno + " AND SARFMALZEMETANIM='" + d2 + "'" + " AND LOKASYON ='" + d3 + "'";
            DbConn.Sayac(sql);
            kayitVarmi = DbConn.GeriDonenRakam;
            if (kayitVarmi == 0)
            {
                MESAJ = " Başarıyla Eklendi";
                sql = "INSERT INTO URTHRK.CH_DOKUMNO_SARFMALZEME_DATA  VALUES(" + gelentarih + "," +
                    " " + dokumno + "," + "'" + d2 + "'," + "'" + d2 + "'," + "'" + d3 + "'," + d1 + "," + "1" + "" + ")";
            }
            else
            {
                MESAJ = " Başarıyla Güncellendi";
                sql = "update URTHRK.CH_DOKUMNO_SARFMALZEME_DATA  set MIKTAR=" + d1 + " " +
                    " where DOKUMNO=" + dokumno + " AND SARFMALZEMETANIM='" + d2 + "'" + " AND LOKASYON ='" + d3 + "'";
            }

            DbConn.SaveUpdate(sql);
            return MESAJ;
        }

        //GenelBilgi
        public List<genel_bilgiler> genel_bilgi_listesi_analiz(DateTime tarih, object lokasyon)
        {
            dynamic sql = null;
            gelentarih = tarih.ToString("yyyyMMdd");//veritabanindaki kayit bicimi  
            List<genel_bilgiler> veriler = new List<genel_bilgiler>();
            sql = "SELECT TANIMI,LOKASYON FROM URTTNM.CH_GENELBILGILER_TNM" +
                  " WHERE EKRAN=1 AND LOKASYON IN('" + lokasyon + "')" + " ORDER BY LOKASYON,EKRANSIRANO";
            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {
                genel_bilgiler satir = new genel_bilgiler();
                satir.BILGITNM = DbConn.MyDataReader.GetValue(0).ToString();
                genel_bilgi_degeri_bul_analiz(gelentarih, DbConn.MyDataReader.GetValue(0), lokasyon);
                satir.DEGERI = DonenDeger2;

                veriler.Add(satir);

            }
            return veriler;


        }
        public List<genel_bilgiler> genel_bilgi_listesi(DateTime tarih, object dokumno, object lokasyon)
        {
            dynamic sql = null;
            List<genel_bilgiler> veriler = new List<genel_bilgiler>();
            sql = "SELECT TANIMI,LOKASYON FROM URTTNM.CH_GENELBILGILER_TNM" +
                  " WHERE EKRAN=1 AND LOKASYON IN('" + lokasyon + "')" + " ORDER BY LOKASYON,EKRANSIRANO";
            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {
                genel_bilgiler satir = new genel_bilgiler();
                satir.BILGITNM = DbConn.MyDataReader.GetValue(0).ToString();
                genel_bilgi_degeri_bul(dokumno, DbConn.MyDataReader.GetValue(0), lokasyon);
                satir.DEGERI = DonenDeger;
                if (satir.DEGERI == "" && (satir.BILGITNM == "KALIPDOKUMSAYISI_YOL1" || satir.BILGITNM == "KALIPDOKUMSAYISI_YOL2" || satir.BILGITNM == "KALIPDOKUMSAYISI_YOL3" || satir.BILGITNM == "KALIPDOKUMSAYISI_YOL4"
                || satir.BILGITNM == "KALIPDOKUMSAYISI_YOL5" || satir.BILGITNM == "KALIPDOKUMSAYISI_YOL6" || satir.BILGITNM == "TANDIS BINDIRME SAYISI"))
                {
                    int dokumnox = (Convert.ToInt32(dokumno) - 1);
                    sql = "SELECT COUNT(DNO) FROM URTHRK.CH_DOKUMNO_URETIM WHERE DNO=" + dokumnox + " ";
                    DbConn.Sayac(sql);
                    if (DbConn.GeriDonenRakam.ToString() != "0")
                    {
                        genel_bilgi_degeri_bul2(dokumnox, satir.BILGITNM, "SDM");

                        if (DonenDeger2 != "")
                        {
                            satir.DEGERI = Convert.ToInt32(DonenDeger2) + 1;
                        }

                    }
                }
                if (satir.DEGERI == "" && (satir.BILGITNM == "TANDIS NO"))
                {
                    int dokumnox = (Convert.ToInt32(dokumno) - 1);
                    sql = "SELECT COUNT(DNO) FROM URTHRK.CH_DOKUMNO_URETIM WHERE DNO=" + dokumnox + " ";
                    DbConn.Sayac(sql);
                    if (DbConn.GeriDonenRakam.ToString() != "0")
                    {
                        genel_bilgi_degeri_bul2(dokumnox, satir.BILGITNM, "SDM");

                        if (DonenDeger2 != "")
                        {
                            satir.DEGERI = Convert.ToInt32(DonenDeger2);
                        }

                    }
                }


                if (satir.DEGERI == "" && (satir.BILGITNM == "CANAK DOKUM SAYISI" || satir.BILGITNM == "KAPAK DOKUM SAYISI" || satir.BILGITNM == "YUREK DOKUM SAYISI" || satir.BILGITNM == "RBT DELIK SAYISI"))
                {
                    int dokumnox = (Convert.ToInt32(dokumno) - 1);
                    sql = "SELECT COUNT(DNO) FROM URTHRK.CH_DOKUMNO_URETIM WHERE DNO=" + dokumnox + " ";
                    DbConn.Sayac(sql);
                    if (DbConn.GeriDonenRakam.ToString() != "0")
                    {
                        genel_bilgi_degeri_bul3(dokumnox, satir.BILGITNM, "AO");

                        if (DonenDeger2 != "")
                        {
                            satir.DEGERI = Convert.ToInt32(DonenDeger2) + 1;
                        }

                    }
                }

                veriler.Add(satir);

            }
            return veriler;


        }
        public void genel_bilgi_degeri_bul_analiz(object gelentarih, object BILGITNMX, object LOKASYONX)
        {
            DonenDeger2 = "";
            dynamic Sql = "SELECT DEGERI FROM URTHRK.CH_DOKUMNO_GENELBILGILER_DATA" +
                " WHERE TARIH=" + gelentarih + " and BILGITNM='" + BILGITNMX + "'" + " and LOKASYON='" + LOKASYONX + "'";
            DbConn2.DbBaglan();
            DbConn2.RaporWhile(Sql);
            while (DbConn2.MyDataReader.Read())
            {
                DonenDeger2 = DbConn2.MyDataReader.GetValue(0).ToString();
            }
            DbConn2.Close();
        }
        public void genel_bilgi_degeri_bul3(object DokumNox, object BILGITNMX, object LOKASYONX)
        {
            DonenDeger2 = "";
            dynamic Sql = "SELECT DEGERI FROM URTHRK.CH_DOKUMNO_GENELBILGILER_DATA" +
                " WHERE DOKUMNO=" + DokumNox + " and BILGITNM='" + BILGITNMX + "'" + " and LOKASYON='" + LOKASYONX + "'";
            DbConn2.DbBaglan();
            DbConn2.RaporWhile(Sql);
            while (DbConn2.MyDataReader.Read())
            {
                DonenDeger2 = DbConn2.MyDataReader.GetValue(0).ToString();
            }
            DbConn2.Close();
        }
        public void genel_bilgi_degeri_bul2(object DokumNox, object BILGITNMX, object LOKASYONX)
        {
            DonenDeger2 = "";
            dynamic Sql = "SELECT DEGERI FROM URTHRK.CH_DOKUMNO_GENELBILGILER_DATA" +
                " WHERE DOKUMNO=" + DokumNox + " and BILGITNM='" + BILGITNMX + "'" + " and LOKASYON='" + LOKASYONX + "'";
            DbConn2.DbBaglan();
            DbConn2.RaporWhile(Sql);
            while (DbConn2.MyDataReader.Read())
            {
                DonenDeger2 = DbConn2.MyDataReader.GetValue(0).ToString();
            }
            DbConn2.Close();
        }
        public void genel_bilgi_degeri_bul(object DokumNox, object BILGITNMX, object LOKASYONX)
        {
            DonenDeger = "";
            dynamic Sql = "SELECT DEGERI FROM URTHRK.CH_DOKUMNO_GENELBILGILER_DATA" +
                " WHERE DOKUMNO=" + DokumNox + " and BILGITNM='" + BILGITNMX + "'" + " and LOKASYON='" + LOKASYONX + "'";
            DbConn2.DbBaglan();
            DbConn2.RaporWhile(Sql);
            while (DbConn2.MyDataReader.Read())
            {
                DonenDeger = DbConn2.MyDataReader.GetValue(0).ToString();
            }
            DbConn2.Close();
        }
        public string genel_bilgi_kayit(DateTime tarih, object dokumno, object d1, object d2, object d3)
        {
            gelentarih = tarih.ToString("yyyyMMdd");//veritabanindaki kayit bicimi  
            string MESAJ;
            string sql = "select count(DOKUMNO) from URTHRK.CH_DOKUMNO_GENELBILGILER_DATA " + " where DOKUMNO=" + dokumno + " AND BILGITNM='" + d2 + "'" + " AND LOKASYON ='" + d3 + "'";
            DbConn.Sayac(sql);
            dynamic kayitVarmi = DbConn.GeriDonenRakam;
            if (kayitVarmi == 0)
            {
                MESAJ = "BAŞARIYLA EKLENDİ";
                sql = "INSERT INTO URTHRK.CH_DOKUMNO_GENELBILGILER_DATA  VALUES(" + gelentarih + "," + dokumno + "," + "'" + d2 + "'," + "'" + d3 + "'," + "'" + d1 + "'" + ")";
            }
            else
            {
                MESAJ = "BAŞARIYLA GÜNCELLENDİ";
                sql = "update URTHRK.CH_DOKUMNO_GENELBILGILER_DATA  set DEGERI='" + d1 + "'" + " where DOKUMNO=" + dokumno + " AND BILGITNM='" + d2 + "'" + " AND LOKASYON ='" + d3 + "'";
            }
            DbConn.SaveUpdate(sql);
            return MESAJ;
        }
        public string genel_bilgi_kayit_analiz(DateTime tarih, object d1, object d2, object lokasyon)
        {
            gelentarih = tarih.ToString("yyyyMMdd");//veritabanindaki kayit bicimi  
            string MESAJ;
            string sql = "select count(BILGITNM) from URTHRK.CH_DOKUMNO_GENELBILGILER_DATA  where TARIH = " + gelentarih + " AND LOKASYON = '" + lokasyon + "' AND BILGITNM = '" + d2 + "'";
            DbConn.Sayac(sql);
            dynamic kayitVarmi = DbConn.GeriDonenRakam;
            if (kayitVarmi == 0)
            {
                MESAJ = "DÖKÜMÜN ANALİZ ARALIKLARI BAŞARIYLA EKLENDİ";
                sql = "INSERT INTO URTHRK.CH_DOKUMNO_GENELBILGILER_DATA  VALUES(" + gelentarih + ",NULL" + "," + "'" + d2 + "'," + "'" + lokasyon + "'," + "'" + d1 + "'" + ")";
            }
            else
            {
                MESAJ = "DÖKÜMÜN ANALİZ ARALIKLARI BAŞARIYLA GÜNCELLENDİ";
                sql = "update URTHRK.CH_DOKUMNO_GENELBILGILER_DATA  set DEGERI='" + d1 + "'" + " where  BILGITNM='" + d2 + "'" + " AND LOKASYON ='" + lokasyon + "'";
            }
            DbConn.SaveUpdate(sql);
            return MESAJ;
        }


        //Enerji

        public List<genel_bilgiler> enerji_liste(object tarih, object dokumno, object lokasyon)
        {
            List<genel_bilgiler> veriler = new List<genel_bilgiler>();
            string sql = "SELECT TANIMI,LOKASYON FROM URTTNM.CH_ENERJILER_TNM" + " WHERE EKRAN=1 AND LOKASYON IN('" + lokasyon + "')" + " ORDER BY LOKASYON,EKRANSIRANO";
            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {
                genel_bilgiler satir = new genel_bilgiler();
                satir.BILGITNM = DbConn.MyDataReader.GetValue(0).ToString();
                enerji_degeri_bul(dokumno, DbConn.MyDataReader.GetValue(0), lokasyon);
                satir.DEGERI = DonenDeger;
                veriler.Add(satir);
            }
            return veriler;

        }
        public void enerji_degeri_bul(object DokumNox, object BILGITNMX, object LOKASYONX)
        {
            DonenDeger = "";
            dynamic Sql = "SELECT DEGERI FROM URTHRK.CH_DOKUMNO_ENERJI_DATA" + " WHERE DOKUMNO=" + DokumNox + " and BILGITNM='" + BILGITNMX + "'" + " and LOKASYON='" + LOKASYONX + "'";
            DbConn2.DbBaglan();
            DbConn2.RaporWhile(Sql);
            while (DbConn2.MyDataReader.Read())
            {
                DonenDeger = DbConn2.MyDataReader.GetValue(0).ToString();
            }
            DbConn2.Close();
        }
        public string enerji_kayit(DateTime tarih, object dokumno, object d1, object d2, object d3)
        {

            string MESAJ;
            gelentarih = tarih.ToString("yyyyMMdd");//veritabanindaki kayit bicimi
            string sql = "select count(DOKUMNO) from URTHRK.CH_DOKUMNO_ENERJI_DATA " + " where DOKUMNO=" + dokumno + " AND BILGITNM='" + d2 + "'" + " AND LOKASYON ='" + d3 + "'";
            DbConn.Sayac(sql);
            dynamic kayitVarmi = DbConn.GeriDonenRakam;
            if (kayitVarmi == 0)
            {
                MESAJ = "BAŞARIYLA EKLENDİ";
                sql = "INSERT INTO URTHRK.CH_DOKUMNO_ENERJI_DATA  VALUES(" + gelentarih + "," + dokumno + "," + "'" + d2 + "'," + "'" + d3 + "'," + "'" + d1 + "'" + ")";
            }
            else
            {
                MESAJ = "BAŞARIYLA GÜNCELLENDİ";
                sql = "update URTHRK.CH_DOKUMNO_ENERJI_DATA  set DEGERI='" + d1 + "'" + " where DOKUMNO=" + dokumno + " AND BILGITNM='" + d2 + "'" + " AND LOKASYON ='" + d3 + "'";
            }
            DbConn.SaveUpdate(sql);
            return MESAJ;

        }


        //Üretim

        public List<uretim_bilgileri> uretim_liste(object dokumno)
        {
            List<uretim_bilgileri> veriler = new List<uretim_bilgileri>();
            string sql = "SELECT * FROM URTHRK.CH_DOKUMNO_URETIM WHERE DNO=" + dokumno + "   ORDER BY DSNO";
            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {
                uretim_bilgileri satir = new uretim_bilgileri();
                satir.SIRANO = DbConn.MyDataReader.GetValue(1).ToString();
                satir.DOKUMNO = DbConn.MyDataReader.GetValue(0).ToString();
                satir.CELIKCINSI = DbConn.MyDataReader.GetValue(7).ToString();
                satir.KTKBOY = DbConn.MyDataReader.GetValue(8).ToString();
                satir.KTKEBAT = DbConn.MyDataReader.GetValue(9).ToString();
                satir.KTKADET = DbConn.MyDataReader.GetValue(15).ToString();
                satir.STDKTKTONAJ = DbConn.MyDataReader.GetValue(16).ToString().Replace(",", ".");
                //if (DbConn.MyDataReader.GetValue(16).ToString() != "")
                //{
                //    satir.STDKTKTONAJ = Convert.ToDouble(DbConn.MyDataReader.GetValue(16)).ToString().Replace(",", ".");
                //}
                satir.KARISIMSAYISI = DbConn.MyDataReader.GetValue(20).ToString();
                satir.KARISIMTONAJ = DbConn.MyDataReader.GetValue(21).ToString().Replace(",", ".");

                veriler.Add(satir);
            }

            return veriler;

        }
        public string toplam_tonaj_getir(int dokumno)
        {

            // string sqll = "SELECT SUM(STDKTKTON) FROM URTHRK.CH_DOKUMNO_URETIM WHERE DNO=" + dokumno + "";
            string sqlx = "SELECT SUM(STDKTKTON), SUM(STNKARTON) FROM URTHRK.CH_DOKUMNO_URETIM WHERE DNO = " + dokumno + "";
            // DbConn.Sayac(sqll);
            DbConn.RaporWhile(sqlx);
            while (DbConn.MyDataReader.Read())
            {

                stdktkton = DbConn.MyDataReader.GetValue(0).ToString();
                stnkarton = DbConn.MyDataReader.GetValue(1).ToString();

            }
            toplam_tonaj = (Convert.ToDouble(stdktkton.Equals("") ? "0.0" : stdktkton) + Convert.ToDouble(stnkarton.Equals("") ? "0.0" : stnkarton)).ToString();

            return toplam_tonaj;


        }
        public string dokumSakla(object siraNo, DateTime tarih, object d2, object d3)
        {
            string sql = "SELECT MAX(DNO) FROM CH_DOKUMNO_URETIM";
            DbConn.Sayac(sql);
            string dokumnumarasi = (Convert.ToUInt32(DbConn.GeriDonenRakam) + 1).ToString();
            dynamic MESAJ;
            gelentarih = tarih.ToString("yyyyMMdd");//veritabanindaki kayit bicimi
            string sqlx = "INSERT INTO CH_DOKUMNO_URETIM VALUES(" + dokumnumarasi + "," + siraNo + " , " +
                " " + gelentarih + ",'" + d2 + "',NULL" + ",NULL" + ",NULL" + ",NULL" + ",NULL" + ",NULL" + ",NULL" + ",NULL" + ",NULL" + ",NULL" + ", " +
                " NULL" + ",NULL" + ",NULL" + ",NULL" + ",NULL" + ",NULL" + ",NULL" + ",NULL" + ",NULL" + ",'" + d3 + "',NULL" + ",NULL" + ")";

            MESAJ = dokumnumarasi + " " + "NUMARALI DÖKÜM AÇILDI." + "\n" + "\n" + "DÖKÜM NUMARASI LİSTESİNDEN SEÇİM YAPARAK ÜRETİM BİLGİLERİNİ EKLEYEBİLİRSİNİZ.";
            DbConn.SaveUpdate(sqlx);
            return MESAJ;
        }
        public void dokumKapat(object gelenDokum, object d3)
        {
            string sql = "UPDATE CH_DOKUMNO_URETIM SET DRM='" + d3 + "'  WHERE DNO= " + gelenDokum + " ";
            DbConn.SaveUpdate(sql);
        }
        public string uretim_kayit(object dokumno, object d1, DateTime tarih, object vardiya, object d11, object d19, object d4, object d2, object d3, object d16,
            object d13, object d15, object d14, object d20, object d5, object kutuk_tonaj, object d18, object d17, object d21, object d12, object karisim_tonaj, object d22,
            object dokumdurum, object dokumtip, object radyo_aktivite)
        {
            string MESAJ;
            string sql = "SELECT COUNT(DNO) FROM URTHRK.CH_DOKUMNO_URETIM " +
                " WHERE DSNO=" + d1 + " AND DNO=" + dokumno + "";
            DbConn.Sayac(sql);
            dynamic kayitVarmi = DbConn.GeriDonenRakam;
            gelentarih = tarih.ToString("yyyyMMdd");//veritabanindaki kayit bicimi
            if (kayitVarmi == 0)
            {
                sql = "INSERT INTO URTHRK.CH_DOKUMNO_URETIM VALUES(" + dokumno + "," + d1 + "," +
                    "" + gelentarih + " ,'" + vardiya + "','" + d11 + "','" + d19 + "',NULL" + ",'" + d4 + "', " +
                    "'" + d2 + "', '" + d3 + "','" + d16 + "','" + d13 + "','" + d15 + "','" + d14 + "','" + d20 + "'," +
                    "'" + d5 + "'," + kutuk_tonaj + ",'" + d18 + "'," + d17 + ",'" + d21 + "','" + d12 + "'," + karisim_tonaj + ",'" + d22 + "','" + dokumdurum + "','" + dokumtip + "','" + radyo_aktivite + "')";
                DbConn.SaveUpdate(sql);
                dynamic sql_sorgu = DbConn.GeriDonenRakam;
                if (sql_sorgu != 0)
                {
                    MESAJ = "ÜRETİM BİLGİLERİ BAŞARIYLA EKLENDİ";
                }
                else
                {
                    MESAJ = "LÜTFEN SIRA NUMARASI SEÇİNİZ.";
                }
            }
            else
            {
                sql = "UPDATE URTHRK.CH_DOKUMNO_URETIM SET " +
                      "DOKOZLKOD='" + d11 + "',SIPNUM='" + d19 + "',KALITE='" + d4 + "',BOY= '" + d2 + "',EBAT='" + d3 + "',SAPMA_NEDENI='" + d16 + "',SAPMA_ELEMENT='" + d13 + "'," +
                      "STD_NEDEN='" + d15 + "',STD_ELEMENT='" + d14 + "',GIDECEGIYER='" + d20 + "'," +
                      "STDKTKSAY='" + d5 + "', STDKTKTON=" + kutuk_tonaj + ", SARIKTKSAY='" + d18 + "',SARIKTKTON=" + d17 + ", KALITEKODSARI='" + d21 + "',STNKARSAY='" + d12 + "', " +
                      "STNKARTON=" + karisim_tonaj + ", KTKACIKLAMA='" + d22 + "',DRM='" + dokumdurum + "',DOKUMTIP='" + dokumtip + "',RADYOAKTIVITE='" + radyo_aktivite + "',VRD=" + vardiya + ", DOKUMTAR=" + gelentarih + "" +
                      "WHERE DNO=" + dokumno + " AND  DSNO=" + d1 + " ";
                DbConn.SaveUpdate(sql);
                MESAJ = "ÜRETİM BİLGİLERİ BAŞARIYLA GÜNCELLENDİ";
            }

            return MESAJ;
        }

        public string dokum_sirasi_sil(object dokumno, object d1, object tarih)
        {
            string MESAJ, sql;
            sql = "DELETE FROM CH_DOKUMNO_URETIM WHERE DNO = " + dokumno + " AND DSNO=" + d1 + " ";
            DbConn.Delete(sql);
            dynamic sql_sorgu = DbConn.GeriDonenRakam;
            if (sql_sorgu != 0)
            {
                MESAJ = "  ÜRETİM BİLGİSİ SİLİNDİ. ";
            }
            else
            {
                MESAJ = "   LÜTFEN SIRA NUMARASI SEÇİNİZ.";
            }

            return MESAJ;

        }
        public List<string> uretimdegiskeni_Bul(object dokumno)
        {
            List<string> uretimDegiskenleri = new List<string>();
            string sql = "SELECT DRM,VRD FROM URTHRK.CH_DOKUMNO_URETIM WHERE DNO=" + dokumno + " ";
            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {

                string gelenDokumdurumu = DbConn.MyDataReader.GetValue(0).ToString();
                string gelenVardiya = DbConn.MyDataReader.GetValue(1).ToString();

                uretimDegiskenleri.Add(gelenDokumdurumu);
                uretimDegiskenleri.Add(gelenVardiya);
            }
            return uretimDegiskenleri;
        }
        public string dokum_tip_getir(object gelencelikCinsi)
        {
            string sql = "SELECT YER FROM URTTNM.KAPALIDOKUM_KALITE WHERE KALITE=  '" + gelencelikCinsi + "'";
            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {
                gelendokumTip = DbConn.MyDataReader.GetValue(0).ToString();

            }

            return gelendokumTip;


        }
        public List<string> kutukboy_comboDoldur()
        {
            List<string> boys = new List<string>();
            string tesis = "CH";
            string sql = "Select KOD_ACK FROM URTTNM.TANIMLAR WHERE TNMTIPI IN('BOY') AND TESIS='" + tesis + "' ORDER BY KOD_ACK ASC";
            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {
                string boy = DbConn.MyDataReader["KOD_ACK"].ToString();
                boys.Add(boy);
            }
            return boys;

        }
        public List<string> kutukEbat_comboDoldur()
        {
            List<string> ebatlar = new List<string>();
            string sql = "SELECT DISTINCT KOD_ACK FROM URTTNM.TANIMLAR WHERE TNMTIPI IN('EBAT') ORDER BY KOD_ACK ASC";
            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {
                string ebat = DbConn.MyDataReader["KOD_ACK"].ToString();
                ebatlar.Add(ebat);
            }

            return ebatlar;
        }
        public List<string> kalite_comboDoldur()
        {
            List<string> kaliteler = new List<string>();
            string sql = "SELECT KOD_ACK FROM URTTNM.TANIMLAR WHERE TNMTIPI IN('KALITE') AND TESIS='CH' ORDER BY KOD_ACK";
            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {
                string kalite = DbConn.MyDataReader["KOD_ACK"].ToString();
                kaliteler.Add(kalite);
            }
            return kaliteler;
        }
        public List<string> uretim_secilen_getir(object dokumNo, object siraNo, DateTime tarih)
        {

            List<string> secilenler = new List<string>();
            gelentarih = tarih.ToString("yyyyMMdd");//veritabanindaki kayit bicimi
            string sql = "SELECT KALITE,BOY,EBAT,STDKTKSAY,VRD,DOKUMTIP,DOKOZLKOD,SIPNUM," +
                         "SAPMA_NEDENI,SAPMA_ELEMENT,STD_NEDEN,STD_ELEMENT,GIDECEGIYER,STDKTKTON,SARIKTKSAY," +
                         "SARIKTKTON,KALITEKODSARI,STNKARSAY,STNKARTON,KTKACIKLAMA,DNO,DSNO,RADYOAKTIVITE " +
                         " FROM URTHRK.CH_DOKUMNO_URETIM WHERE DNO=" + dokumNo + " AND DSNO=" + siraNo + " AND DOKUMTAR=" + gelentarih + "";
            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {
                string celikCinsi = DbConn.MyDataReader.GetValue(0).ToString();
                string kutukBoy = DbConn.MyDataReader.GetValue(1).ToString();
                string kutukEbat = DbConn.MyDataReader.GetValue(2).ToString();
                string kutukSayi = DbConn.MyDataReader.GetValue(3).ToString();
                string vardiya = DbConn.MyDataReader.GetValue(4).ToString();
                string dokumTip = DbConn.MyDataReader.GetValue(5).ToString();
                string ozelKod = DbConn.MyDataReader.GetValue(6).ToString();
                string siparisNo = DbConn.MyDataReader.GetValue(7).ToString();
                string sapmaNedeni = DbConn.MyDataReader.GetValue(8).ToString();
                string sapmaKimyasali = DbConn.MyDataReader.GetValue(9).ToString();
                string standartDisNeden = DbConn.MyDataReader.GetValue(10).ToString();
                string standartDisKimyasal = DbConn.MyDataReader.GetValue(11).ToString();
                string kutukGidecek_yer = DbConn.MyDataReader.GetValue(12).ToString();

                // string kutuktonaj_ = Convert.ToDouble(DbConn.MyDataReader.GetValue(13)).ToString().Replace(",", ".");

                string kutuktonaj_ = DbConn.MyDataReader.GetValue(13).ToString().Replace(",", ".");

                string sariKutuk_sayisi = DbConn.MyDataReader.GetValue(14).ToString();
                string sarikutuk_Tonaji = DbConn.MyDataReader.GetValue(15).ToString();
                string sariKutukcelik_Cinsi = DbConn.MyDataReader.GetValue(16).ToString();
                string standartKarisimSayisi = DbConn.MyDataReader.GetValue(17).ToString();
                string karisimTonaj = DbConn.MyDataReader.GetValue(18).ToString();
                string aciklama = DbConn.MyDataReader.GetValue(19).ToString();
                string dokumno = DbConn.MyDataReader.GetValue(20).ToString();
                string siranumarasi = DbConn.MyDataReader.GetValue(21).ToString();
                string radyoaktivite = DbConn.MyDataReader.GetValue(22).ToString();

                secilenler.Add(celikCinsi);
                secilenler.Add(kutukBoy);
                secilenler.Add(kutukEbat);
                secilenler.Add(kutukSayi);
                secilenler.Add(vardiya);
                secilenler.Add(dokumTip);
                secilenler.Add(ozelKod);
                secilenler.Add(siparisNo);
                secilenler.Add(sapmaNedeni);
                secilenler.Add(sapmaKimyasali);
                secilenler.Add(standartDisNeden);
                secilenler.Add(standartDisKimyasal);
                secilenler.Add(kutukGidecek_yer);
                secilenler.Add(kutuktonaj_);
                secilenler.Add(sariKutuk_sayisi);
                secilenler.Add(sarikutuk_Tonaji);
                secilenler.Add(sariKutukcelik_Cinsi);
                secilenler.Add(standartKarisimSayisi);
                secilenler.Add(karisimTonaj);
                secilenler.Add(aciklama);
                secilenler.Add(dokumno);
                secilenler.Add(siranumarasi);
                secilenler.Add(radyoaktivite);
            }

            return secilenler;
        }
        public string dokum_yeni_sira(object dokumNo)
        {


            string sql = "SELECT MAX(DSNO) FROM URTHRK.CH_DOKUMNO_URETIM  WHERE DNO=" + dokumNo + " GROUP BY DNO";
            DbConn.Sayac(sql);
            string gelenSirano = (DbConn.GeriDonenRakam).ToString();
            return gelenSirano;

        }
        public string katsayiGetir(object d1, object d2, DateTime tarih, object vardiya, object d8)
        {
            gelentarih = tarih.ToString("yyyyMMdd");//veritabanindaki kayit bicimi
            string sql = "SELECT KATSAYI FROM URTTNM.KATSAYI_TARTIMDAN " +
                "WHERE BOY=  '" + d1 + "' AND EBAT= '" + d2 + "' AND TARIH= " + gelentarih + " AND VRD = " + vardiya + " AND CC = '" + d8 + "' ";
            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {
                gelenTonaj = DbConn.MyDataReader.GetValue(0).ToString();

            }
            if (gelenTonaj == null)
            {

                //string sql1 = "SELECT KATSAYI FROM URTTNM.KATSAYI_TARTIMDAN" +
                //    " WHERE BOY=  '" + d1 + "' AND EBAT= '" + d2 + "' AND CC = '" + d8 + "' AND rownum=1 ORDER BY TARIH DESC ";

                string sql1 = "SELECT KATSAYI FROM " +
                    " (SELECT * FROM URTTNM.KATSAYI_TARTIMDAN WHERE BOY ='" + d1 + "' AND EBAT ='" + d2 + "'  AND CC ='" + d8 + "' ORDER BY TARIH DESC) " +
                    " WHERE ROWNUM= 1 ";
                DbConn.RaporWhile(sql1);
                while (DbConn.MyDataReader.Read())
                {
                    gelenTonaj = DbConn.MyDataReader.GetValue(0).ToString();

                }
            }
            return gelenTonaj;
        }
        public List<uretim_bilgileri> send_ktk_dokum_liste(object dokumno)
        {
            List<uretim_bilgileri> veriler = new List<uretim_bilgileri>();
            string sqly = "SELECT COUNT(DNO) FROM URTHRK.TAVFRN WHERE DNO=" + dokumno + " ";
            DbConn.Sayac(sqly);
            if (DbConn.GeriDonenRakam.ToString() != "0")
            {
                string sqlyy = "SELECT  DISTINCT(DNO),sum(KTKADET) FROM TAVFRN WHERE DNO = " + dokumno + " GROUP BY DNO";
                DbConn.RaporWhile(sqlyy);
                while (DbConn.MyDataReader.Read())
                {
                    uretim_bilgileri satir = new uretim_bilgileri();
                    satir.DOKUMNO = DbConn.MyDataReader.GetValue(0).ToString();
                    satir.GIDENKUTUK = DbConn.MyDataReader.GetValue(1).ToString();
                    veriler.Add(satir);
                }

            }
            else
            {
                string sql = "SELECT DISTINCT(DNO) FROM URTHRK.CH_DOKUMNO_URETIM WHERE DNO=" + dokumno + "";
                DbConn.RaporWhile(sql);
                while (DbConn.MyDataReader.Read())
                {
                    uretim_bilgileri satir = new uretim_bilgileri();
                    satir.DOKUMNO = DbConn.MyDataReader.GetValue(0).ToString();
                    veriler.Add(satir);
                }
            }
            return veriler;


        }
        public string sicak_sarja_gonderilecek_kutuk(DateTime tarih, object dokumno, int GKTKSAYISI, object kalite, object boy, object ebat)
        {

            string sql1, sql2, sql3, MESAJ, d1, d2, d3, d4, d5;
            int kutuk_adet_tav;
            string gelentarih = DateTime.Now.Date.ToString("yyyyMMdd");
            //gelentarih = tarih.ToString("yyyyMMdd");//veritabanindaki kayit bicimi
            d1 = "D";
            d2 = "DHH";
            d3 = gelentarih.Substring(0, gelentarih.Length - 4);
            //d3 = "2017";
            d4 = "SCK";
            d5 = "ACK";
            string saniye = DateTime.Now.Second.ToString();
            string dakika = DateTime.Now.Minute.ToString();
            string saat = DateTime.Now.Hour.ToString();
            if (saniye.Length == 1)
            {
                saniye = "0" + saniye;
            }
            if (dakika.Length == 1)
            {
                dakika = "0" + dakika;
            }
            if (saat.Length == 1)
            {
                saat = "0" + saat;
            }
            string gir_saati = saat + dakika + saniye;
            string cikis_saati = saat + dakika + saniye;
            sql2 = "SELECT sum(KTKADET) FROM TAVFRN WHERE DNO=" + dokumno + "";
            DbConn.Sayac(sql2);
            string ktkadet = DbConn.GeriDonenRakam.ToString();
            sql3 = "SELECT SUM(STDKTKSAY) FROM CH_DOKUMNO_URETIM WHERE DNO = " + dokumno + "";
            DbConn.Sayac(sql3);
            string adet = DbConn.GeriDonenRakam.ToString();
            if (ktkadet == "")
            {
                kutuk_adet_tav = 0;
            }
            else
            {
                kutuk_adet_tav = Convert.ToInt32(ktkadet);
            }
            if (adet == "")
            {
                MESAJ = "KÜTÜK SAYISI GİRİNİZ";
            }
            else
            {
                //int kutuk_adet_tav = Convert.ToInt32(ktkadet);
                int kutuk_adet_dokum = Convert.ToInt32(adet);
                if (kutuk_adet_dokum >= kutuk_adet_tav + GKTKSAYISI)
                {
                    sql1 = "INSERT INTO URTHRK.TAVFRN VALUES('" + d1 + "','" + d2 + "','" + d3 + "',NULL" + ", " +
                        " '" + dokumno + "','" + kalite + "','" + ebat + "','" + boy + "','" + d4 + "','" + gir_saati + "', " +
                        " '" + cikis_saati + "'," + GKTKSAYISI + ",NULL" + ",'" + d5 + "'," + gelentarih + ",NULL" + ",NULL" + "," +
                        " NULL" + ",NULL" + ",NULL" + ",NULL" + ",NULL" + ",NULL" + ",NULL" + ")";
                    MESAJ = GKTKSAYISI + " ADET KÜTÜK SICAK ŞARJA GÖNDERİLDİ  ";
                    DbConn.SaveUpdate(sql1);
                }
                else
                {
                    MESAJ = "GÖNDERECEĞİNİZ KÜTÜK SAYISI TOPLAM KÜTÜK ADETİNDEN AZ OLMALIDIR ";
                }
            }

            return MESAJ;

        }
        public List<string> kaliteBoyEbat_Kodbul(object kalite, object boy, object ebat)
        {
            List<string> degiskenler = new List<string>();
            string sql = "SELECT KOD FROM URTTNM.TANIMLAR WHERE KOD_ACK = '" + kalite + "' AND TESIS = 'HH'";
            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {
                string gelenKalite_kod = DbConn.MyDataReader.GetValue(0).ToString();
                degiskenler.Add(gelenKalite_kod);
            }
            string sqlx = "SELECT KOD FROM URTTNM.TANIMLAR WHERE KOD_ACK = '" + boy + "' AND TESIS = 'HH'";
            DbConn.RaporWhile(sqlx);
            while (DbConn.MyDataReader.Read())
            {
                string gelenKalite_boy = DbConn.MyDataReader.GetValue(0).ToString();
                degiskenler.Add(gelenKalite_boy);
            }
            string sqly = "SELECT KOD FROM URTTNM.TANIMLAR WHERE KOD_ACK = '" + ebat + "' AND TESIS = 'HH'";
            DbConn.RaporWhile(sqly);
            while (DbConn.MyDataReader.Read())
            {
                string gelenKalite_ebat = DbConn.MyDataReader.GetValue(0).ToString();
                degiskenler.Add(gelenKalite_ebat);
            }
            return degiskenler;
        }


        //Duruş 
        public List<durus_bilgileri> durus_liste(object dokumno, DateTime tarih)
        {
            List<durus_bilgileri> veriler = new List<durus_bilgileri>();
            gelentarih = tarih.ToString("yyyyMMdd");//veritabanindaki kayit bicimi
            string sql = "SELECT * FROM URTHRK.CH_DOKUMNO_DURUS_DATA WHERE DNO=" + dokumno + "  AND BASTAR=" + gelentarih + " ORDER BY BASSAAT";
            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {
                durus_bilgileri satir = new durus_bilgileri();
                satir.BASSAATI = DbConn.MyDataReader.GetValue(4).ToString();
                satir.BITISSAATI = DbConn.MyDataReader.GetValue(6).ToString();
                satir.SURE = DbConn.MyDataReader.GetValue(7).ToString();
                satir.DURUSNEDEN = DbConn.MyDataReader.GetValue(10).ToString();
                satir.ARIZANEDEN = DbConn.MyDataReader.GetValue(11).ToString();
                satir.ARIZAKOD = DbConn.MyDataReader.GetValue(9).ToString();
                satir.SARJALMA = DbConn.MyDataReader.GetValue(12).ToString();
                satir.DURUSKOD = DbConn.MyDataReader.GetValue(8).ToString();
                satir.DURUS_ID = DbConn.MyDataReader.GetValue(15).ToString();
                veriler.Add(satir);
            }
            return veriler;

        }
        public List<string> durusNeden_comboDoldur()
        {
            List<string> nedenler = new List<string>();
            string sql = "SELECT DURNDNACK FROM URTTNM.CH_DURUS_NEDEN";
            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {
                string neden = DbConn.MyDataReader["DURNDNACK"].ToString();
                nedenler.Add(neden);
            }

            return nedenler;


        }
        public string durus_kod_getir(object gelenNeden)
        {
            string sql = "Select DURNDNKOD FROM URTTNM.CH_DURUS_NEDEN WHERE DURNDNACK= '" + gelenNeden + "'";
            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {
                gelendurusKodu = DbConn.MyDataReader.GetValue(0).ToString();

            }
            return gelendurusKodu;
        }
        public List<string> arizaNeden_cmbDoldur(object durusKod)
        {
            List<string> nedenler = new List<string>();
            string sqlx = "SELECT ARZACK FROM URTTNM.CH_ARIZA_NEDEN WHERE DURNDNKOD='" + durusKod + "'";
            DbConn.RaporWhile(sqlx);
            while (DbConn.MyDataReader.Read())
            {
                string neden = DbConn.MyDataReader["ARZACK"].ToString();
                nedenler.Add(neden);
            }
            return nedenler;
        }
  
        public string ariza_kod_getir(object gelenarizaNeden, object duruskod)
        {
            dynamic sqly = "SELECT ARZNDNKOD FROM URTTNM.CH_ARIZA_NEDEN WHERE ARZACK= '" + gelenarizaNeden + "' AND DURNDNKOD='" + duruskod + "'";
            DbConn.RaporWhile(sqly);
            while (DbConn.MyDataReader.Read())
            {
                gelenarizaKodu = DbConn.MyDataReader.GetValue(0).ToString();

            }
            return gelenarizaKodu;
        }
        public void durus_sablon_getir(object dokumno, DateTime tarih, object durus_ID)
        {
            string sql, sql1, sql2, sql3, sql4, d1, d2, d3, d4, d5, d9, d10, d11, d12, d13, d14, d15, d17, sqlx;
            d1 = "DCH";
            d2 = "13A";
            d3 = "Proses";
            d5 = "RBT HAZIRLAMA";
            d17 = " ";
            gelentarih = tarih.ToString("yyyyMMdd");//veritabanindaki kayit bicimi
            sqlx = "SELECT COUNT(DNO) FROM URTHRK.CH_DOKUMNO_DURUS_DATA WHERE DNO=" + dokumno + " AND TESIS='" + d1 + "' AND BASTAR=" + gelentarih + "";
            DbConn.Sayac(sqlx);
            dynamic kayitVarmi = DbConn.GeriDonenRakam;
            if (kayitVarmi == 0)
            {
                List<string> uretimDegiskenleri = new List<string>();
                uretimDegiskenleri = uretimdegiskeni_Bul(dokumno);
                d4 = uretimDegiskenleri[0];

                sql = "INSERT INTO URTHRK.CH_DOKUMNO_DURUS_DATA VALUES('" + d1 + "','" + dokumno + "','" + d4 + "' ,'" + gelentarih + "',NULL" + ",'" + gelentarih + "', NULL" + " , '" + 2 + "', '" + 1 + "','" + d2 + "','" + d3 + "','" + d5 + "','" + d17 + "',NULL" + ",'" + 1 + "',NULL" + ")";
                DbConn.SaveUpdate(sql);
                d9 = "11A";
                d10 = "ŞARJ ALMA";
                d11 = "1. VE 2. ŞARJ ALMA";
                sql1 = "INSERT INTO URTHRK.CH_DOKUMNO_DURUS_DATA VALUES('" + d1 + "','" + dokumno + "','" + d4 + "' ,'" + gelentarih + "',NULL" + ",'" + gelentarih + "', NULL" + " , '" + 2 + "', '" + 1 + "','" + d9 + "','" + d3 + "','" + d10 + "','" + d11 + "',NULL" + "," + 1 + ",NULL" + ")";
                DbConn.SaveUpdate(sql1);
                d12 = "3.ŞARJ ALMA";
                sql2 = "INSERT INTO URTHRK.CH_DOKUMNO_DURUS_DATA VALUES('" + d1 + "','" + dokumno + "','" + d4 + "' ,'" + gelentarih + "',NULL" + ",'" + gelentarih + "', NULL" + " , '" + 2 + "', '" + 1 + "','" + d9 + "','" + d3 + "','" + d10 + "','" + d12 + "',NULL" + "," + 1 + ",NULL" + ")";
                DbConn.SaveUpdate(sql2);
                d13 = "TD 1.ŞARJ ALMA";
                sql3 = "INSERT INTO URTHRK.CH_DOKUMNO_DURUS_DATA VALUES('" + d1 + "','" + dokumno + "','" + d4 + "' ,'" + gelentarih + "',NULL" + ",'" + gelentarih + "', NULL" + " , '" + 2 + "', '" + 1 + "','" + d9 + "','" + d3 + "','" + d10 + "','" + d13 + "',NULL" + "," + 1 + ",NULL" + ")";
                DbConn.SaveUpdate(sql3);
                d14 = "12A";
                d15 = "Döküm devirme";
                sql4 = "INSERT INTO URTHRK.CH_DOKUMNO_DURUS_DATA VALUES('" + d1 + "','" + dokumno + "','" + d4 + "' ,'" + gelentarih + "',NULL" + ",'" + gelentarih + "', NULL" + " , '" + 4 + "', '" + 1 + "','" + d14 + "','" + d3 + "','" + d15 + "','" + d17 + "',NULL" + "," + 1 + ",NULL" + ")";
                DbConn.SaveUpdate(sql4);
            }


        }
        public string durus_kayit(object dokumno, object d1, object d2, object d3, object d4, object d5, object d6, object d7, object d8, object d9, object d10, object d11, object d12, DateTime tarih)

        {
            string sql, sqlx, MESAJ;
            dynamic kayitVarmi, kayit;
            gelentarih = tarih.ToString("yyyyMMdd");//veritabanindaki kayit bicimi
            //sql = "SELECT COUNT(SURE) FROM URTHRK.CH_DOKUMNO_DURUS_DATA WHERE  DNO='" + dokumno + "' AND  ARZNEDKOD='" + d8 + "' AND DURUSNEDEN='" + d1 + "' AND SARJDRM='" + d5 + "'";
            sql = "SELECT COUNT(DNO) FROM URTHRK.CH_DOKUMNO_DURUS_DATA WHERE  DURUS_ID=" + d12 + "";
            DbConn.Sayac(sql);
            kayitVarmi = DbConn.GeriDonenRakam;
            sqlx = "SELECT COUNT(DNO) FROM URTHRK.CH_DOKUMNO_DURUS_DATA WHERE BASSAAT='" + d10 + "' AND BITSAAT='" + d11 + "' AND BASTAR=" + gelentarih + " ";
            DbConn.Sayac(sqlx);
            kayit = DbConn.GeriDonenRakam;
            if (kayitVarmi == 0)
            {
                if (kayit == 0)
                {
                    sql = "INSERT INTO CH_DOKUMNO_DURUS_DATA VALUES('" + d6 + "','" + dokumno + "','" + d4 + "', " + gelentarih + " " +
                        " ,'" + d10 + "'," + gelentarih + ",'" + d11 + "','" + d7 + "','" + d2 + "','" + d8 + "'," +
                        " '" + d1 + "','" + d3 + "','" + d5 + "','" + d9 + "'," + 1 + ",NULL" + ")";
                    MESAJ = " DURUŞ BİLGİLERİ BAŞARIYLA EKLENDİ ";
                    DbConn.SaveUpdate(sql);
                }
                else
                {
                    MESAJ = "\n" + tarih + "'de seçtiğiniz saat" + " aralığında " + " duruş bulunmaktadır !! ";
                }

            }
            else
            {
                //if (kayit == 0)
                //{

                sql = "UPDATE URTHRK.CH_DOKUMNO_DURUS_DATA SET BASSAAT='" + d10 + "'," +
               " BITSAAT='" + d11 + "', SURE='" + d7 + "', SARJDRM='" + d5 + "', DURUSNEDEN= '" + d1 + "'," +
               " ARIZANEDEN='" + d3 + "',DURNEDKOD='" + d2 + "',ARZNEDKOD='" + d8 + "',ACIKLAMA='" + d9 + "'" +
               " WHERE DNO='" + dokumno + "' AND  DURUS_ID='" + d12 + "'";
                MESAJ = " DURUŞ BİLGİLERİ BAŞARIYLA GÜNCELLENDİ";
                DbConn.SaveUpdate(sql);
                //}
                //else
                //{

                //    MESAJ = "\n" + tarih + "'de seçtiğiniz saat" + " aralığında " + " duruş bulunmaktadır !! ";
                //}

            }
            return MESAJ;

        }
        public List<string> durus_bilgisi_getir(object dokumno, object durusId)
        {

            List<string> secilenler = new List<string>();
            string sql = "SELECT BASSAAT,BITSAAT,SARJDRM,DURUSNEDEN,ARIZANEDEN," +
                " DURNEDKOD,ARZNEDKOD,SURE,ACIKLAMA FROM URTHRK.CH_DOKUMNO_DURUS_DATA" +
                " WHERE DNO=" + dokumno + " AND DURUS_ID=" + durusId + " ";
            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {
                string basSaat = DbConn.MyDataReader.GetValue(0).ToString();
                string bitisSaat = DbConn.MyDataReader.GetValue(1).ToString();
                string sarjDrm = DbConn.MyDataReader.GetValue(2).ToString();
                string durusNeden = DbConn.MyDataReader.GetValue(3).ToString();
                string arizaNeden = DbConn.MyDataReader.GetValue(4).ToString();
                string durnedkod = DbConn.MyDataReader.GetValue(5).ToString();
                string arznedkod = DbConn.MyDataReader.GetValue(6).ToString();
                string sure = DbConn.MyDataReader.GetValue(7).ToString();
                string aciklama = DbConn.MyDataReader.GetValue(8).ToString();
                secilenler.Add(basSaat);
                secilenler.Add(bitisSaat);
                secilenler.Add(sarjDrm);
                secilenler.Add(durusNeden);
                secilenler.Add(arizaNeden);
                secilenler.Add(durnedkod);
                secilenler.Add(arznedkod);
                secilenler.Add(sure);
                secilenler.Add(aciklama);

            }
            return secilenler;

        }

        public string durus_bilgisi_sil(object durus_Id)
        {
            string MESAJ, sql;
            sql = "DELETE FROM CH_DOKUMNO_DURUS_DATA WHERE  DURUS_ID=" + durus_Id + " ";
            DbConn.Delete(sql);
            dynamic sql_sorgu = DbConn.GeriDonenRakam;
            if (sql_sorgu != 0)
            {
                MESAJ = "  DURUŞ BİLGİSİ SİLİNDİ. ";
            }
            else
            {
                MESAJ = "HATA OLUŞTU TEKRAR DENEYİNİZ!";
            }

            return MESAJ;

        }





        //Refrakter
        public string refrakter_kayit(object dokumno, DateTime tarih, object baslangic_tarih, object pota_no, object dokum_sayisi, object d4, object d5, object d6, object d7, object d8, object d9, object d10,
            object d13, object d14, object d15, object d16, object d17, object d18, object d19, object d20, object iskarta_tarih, object d22, object d23, object d24)
        {
            dynamic kayitVarmi, MESAJ;
            gelentarih = tarih.ToString("yyyyMMdd");//veritabanindaki kayit bicimi
            //if (baslangic_tarih.ToString() != "" && iskarta_tarih.ToString() != "")
            //{
            //    bas_tarih = Convert.ToDateTime(baslangic_tarih).ToString("yyyyMMdd");
            //    iskarta_tarihi = Convert.ToDateTime(iskarta_tarih).ToString("yyyyMMdd");


            //}
            if (baslangic_tarih.ToString() != "")
            {
                bas_tarih = Convert.ToDateTime(baslangic_tarih).ToString("yyyyMMdd");

            }
            if (iskarta_tarih.ToString() != "")
            {

                iskarta_tarihi = Convert.ToDateTime(iskarta_tarih).ToString("yyyyMMdd");
            }
            string sql = "SELECT count(DNO) from URTHRK.CH_DOKUMNO_REFRAKTER " + " where DNO=" + dokumno + "";
            DbConn.Sayac(sql);
            kayitVarmi = DbConn.GeriDonenRakam;
            if (kayitVarmi == 0)
            {
                sql = "INSERT INTO URTHRK.CH_DOKUMNO_REFRAKTER VALUES(" + dokumno + "," + gelentarih + ",'" + pota_no + "'," +
                    " '" + dokum_sayisi + "','" + d4 + "','" + d5 + "','" + d6 + "','" + d7 + "','" + d8 + "','" + d9 + "'," +
                    " '" + d13 + "','" + d14 + "','" + d15 + "','" + d16 + "','" + d17 + "','" + d18 + "'," +
                    " '" + d19 + "','" + d20 + "','" + iskarta_tarihi + "','" + d23 + "','" + d22 + "','" + d24 + "','" + bas_tarih + "', '" + d10 + "')";
                MESAJ = "REFRAKTER BİLGİLERİ BAŞARIYLA EKLENDİ";
            }
            else
            {
                sql = "UPDATE URTHRK.CH_DOKUMNO_REFRAKTER " +
                     "SET " +
                    "PNO='" + pota_no + "',DSAY='" + dokum_sayisi + "',TUGLAFRM ='" + d4 + "',PDRM ='" + d5 + "', " +
                    "PSKTMR ='" + d6 + "',GAZDS ='" + d7 + "',GAZFRM ='" + d8 + "',GAZTIP ='" + d9 + "', " +
                    " TANDIS_PLK_FRM='" + d10 + "',USTDS ='" + d13 + "', " +
                    "USTFRM ='" + d14 + "', ALTDS ='" + d15 + "', ALTFRM ='" + d16 + "', SURGUDS ='" + d17 + "', " +
                    "SURGUFRM ='" + d18 + "',SURGUPLKTY ='" + d19 + "',KONTROLEDEN ='" + d20 + "',ISKARTATAR ='" + iskarta_tarihi + "', " +
                    "PCKSSAAT ='" + d23 + "',PGLSSAAT ='" + d22 + "',GENELACIKLAMA ='" + d24 + "',POTADVRALMATRH= '" + bas_tarih + "' WHERE DNO=" + dokumno + " ";
                MESAJ = "REFRAKTER BİLGİLERİ BAŞARIYLA GÜNCELLENDİ";
            }
            DbConn.SaveUpdate(sql);
            return MESAJ;

        }
        public List<refrakter_bilgileri> refrakter_liste(DateTime tarih)
        {
            gelentarih = tarih.ToString("yyyyMMdd");//veritabanindaki kayit bicimi
            List<refrakter_bilgileri> veriler = new List<refrakter_bilgileri>();
            string sql = "SELECT * FROM URTHRK.CH_DOKUMNO_REFRAKTER WHERE TARIH=" + gelentarih + "   ORDER BY DNO DESC";
            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {
                refrakter_bilgileri satir = new refrakter_bilgileri();
                satir.DOKUMNO = DbConn.MyDataReader.GetValue(0);
                satir.POTANO = DbConn.MyDataReader.GetValue(2);
                satir.DKMSAYISI = DbConn.MyDataReader.GetValue(3);
                satir.TUGLAFIRMA = DbConn.MyDataReader.GetValue(4).ToString();
                satir.PUSKURTMELI = DbConn.MyDataReader.GetValue(6).ToString();
                satir.BASLANGICTARIHI = DbConn.MyDataReader.GetValue(22).ToString();
                satir.POTADURUM = DbConn.MyDataReader.GetValue(5).ToString();
                satir.ISKARTATARIHI = DbConn.MyDataReader.GetValue(18).ToString();
                satir.GAZTAPASIDS = DbConn.MyDataReader.GetValue(7).ToString();
                satir.USTNOZULDS = DbConn.MyDataReader.GetValue(10).ToString();
                satir.ALTNOZULDS = DbConn.MyDataReader.GetValue(12).ToString();
                satir.SURGUDS = DbConn.MyDataReader.GetValue(14).ToString();
                satir.SURGUFIRMA = DbConn.MyDataReader.GetValue(15).ToString();
                satir.SURGUPLKTY = DbConn.MyDataReader.GetValue(16).ToString();
                satir.POTACIKISSAATI = DbConn.MyDataReader.GetValue(19).ToString();
                satir.POTAGELISSAATI = DbConn.MyDataReader.GetValue(20).ToString();
                satir.KONTROLEDEN = DbConn.MyDataReader.GetValue(17).ToString();
                satir.ACIKLAMA = DbConn.MyDataReader.GetValue(21).ToString();
                veriler.Add(satir);
            }
            return veriler;

        }
        public List<string> refrakter_bilgisi_getir(object d1)
        {
            List<string> secilenler = new List<string>();
            string sql = "SELECT PDRM,DSAY,TUGLAFRM,PSKTMR,GAZDS,GAZFRM,GAZTIP, " +
                " USTDS,USTFRM,ALTDS, ALTFRM,SURGUDS, " +
                " SURGUFRM,SURGUPLKTY,KONTROLEDEN,ISKARTATAR,PCKSSAAT,PGLSSAAT,GENELACIKLAMA, " +
                " POTADVRALMATRH,PNO,TANDIS_PLK_FRM FROM URTHRK.CH_DOKUMNO_REFRAKTER WHERE DNO=" + d1 + " ";
            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {
                string PDRM = DbConn.MyDataReader.GetValue(0).ToString();
                string DSAY = DbConn.MyDataReader.GetValue(1).ToString();
                string TUGLAFRM = DbConn.MyDataReader.GetValue(2).ToString();
                string PSKTMR = DbConn.MyDataReader.GetValue(3).ToString();
                string GAZDS = DbConn.MyDataReader.GetValue(4).ToString();
                string GAZFRM = DbConn.MyDataReader.GetValue(5).ToString();
                string GAZTIP = DbConn.MyDataReader.GetValue(6).ToString();
                string USTDS = DbConn.MyDataReader.GetValue(7).ToString();
                string USTFRM = DbConn.MyDataReader.GetValue(8).ToString();
                string ALTDS = DbConn.MyDataReader.GetValue(9).ToString();
                string ALTFRM = DbConn.MyDataReader.GetValue(10).ToString();
                string SURGUDS = DbConn.MyDataReader.GetValue(11).ToString();
                string SURGUFRM = DbConn.MyDataReader.GetValue(12).ToString();
                string SURGUPLKTY = DbConn.MyDataReader.GetValue(13).ToString();
                string KONTROLEDEN = DbConn.MyDataReader.GetValue(14).ToString();
                string ISKARTATAR = DbConn.MyDataReader.GetValue(15).ToString();
                //int Iskarta = Convert.ToInt32(ISKARTATAR);
                //tarih_parse = tarihFormat1(Iskarta);
                string PCKSSAAT = DbConn.MyDataReader.GetValue(16).ToString();
                string PGLSSAAT = DbConn.MyDataReader.GetValue(17).ToString();
                string GENELACIKLAMA = DbConn.MyDataReader.GetValue(18).ToString();
                string POTADVRALMATRH = DbConn.MyDataReader.GetValue(19).ToString();
                string PNO = DbConn.MyDataReader.GetValue(20).ToString();
                string TANDIS_PLK_FRM = DbConn.MyDataReader.GetValue(21).ToString();

                secilenler.Add(PDRM);
                secilenler.Add(DSAY);
                secilenler.Add(TUGLAFRM);
                secilenler.Add(PSKTMR);
                secilenler.Add(GAZDS);
                secilenler.Add(GAZFRM);
                secilenler.Add(GAZTIP);
                secilenler.Add(USTDS);
                secilenler.Add(USTFRM);
                secilenler.Add(ALTDS);
                secilenler.Add(ALTFRM);
                secilenler.Add(SURGUDS);
                secilenler.Add(SURGUFRM);
                secilenler.Add(SURGUPLKTY);
                secilenler.Add(KONTROLEDEN);
                secilenler.Add(ISKARTATAR);
                secilenler.Add(PCKSSAAT);
                secilenler.Add(PGLSSAAT);
                secilenler.Add(GENELACIKLAMA);
                secilenler.Add(POTADVRALMATRH);
                secilenler.Add(PNO);
                secilenler.Add(TANDIS_PLK_FRM);
            }

            return secilenler;

        }

        public List<string> yeni_refrakter(string potano)
        {
            string sql, sqlx, PDRM, DSAY, TUGLAFRM, PSKTMR, GAZDS, GAZFRM, GAZTIP, USTDS, USTFRM, ALTDS, ALTFRM, SURGUDS, SURGUFRM, SURGUPLKTY, KONTROLEDEN, ISKARTATAR, PCKSSAAT, PGLSSAAT, GENELACIKLAMA, PNO, TANDIS_PLK_FRM, POTADVRALMATRH;
            List<string> secilenler = new List<string>();
            sql = "SELECT MAX(DNO) FROM " +
              " URTHRK.CH_DOKUMNO_REFRAKTER WHERE PNO=" + potano + " ";
            DbConn.Sayac(sql);
            dynamic dokumno = DbConn.GeriDonenRakam;
            sqlx = "SELECT * FROM " +
              " URTHRK.CH_DOKUMNO_REFRAKTER WHERE DNO=" + dokumno + " ";
            DbConn.RaporWhile(sqlx);
            while (DbConn.MyDataReader.Read())
            {

                if (DbConn.MyDataReader.GetValue(5).ToString() == "ISKARTA")
                {
                    PDRM = DbConn.MyDataReader.GetValue(5).ToString();
                    DSAY = "1";
                    TUGLAFRM = DbConn.MyDataReader.GetValue(4).ToString();
                    PSKTMR = DbConn.MyDataReader.GetValue(6).ToString();
                    GAZDS = "1";
                    GAZFRM = DbConn.MyDataReader.GetValue(8).ToString();
                    GAZTIP = DbConn.MyDataReader.GetValue(9).ToString();
                    USTDS = "1";
                    USTFRM = DbConn.MyDataReader.GetValue(11).ToString();
                    ALTDS = "1";
                    ALTFRM = DbConn.MyDataReader.GetValue(13).ToString();
                    SURGUDS = "1";
                    SURGUFRM = DbConn.MyDataReader.GetValue(15).ToString();
                    SURGUPLKTY = DbConn.MyDataReader.GetValue(16).ToString();
                    KONTROLEDEN = DbConn.MyDataReader.GetValue(17).ToString();
                    ISKARTATAR = DbConn.MyDataReader.GetValue(18).ToString();
                    //int Iskarta = Convert.ToInt32(ISKARTATAR);
                    //tarih_parse = tarihFormat1(Iskarta);
                    PCKSSAAT = DbConn.MyDataReader.GetValue(19).ToString();
                    PGLSSAAT = DbConn.MyDataReader.GetValue(20).ToString();
                    GENELACIKLAMA = DbConn.MyDataReader.GetValue(21).ToString();
                    POTADVRALMATRH = DbConn.MyDataReader.GetValue(22).ToString();
                    PNO = DbConn.MyDataReader.GetValue(2).ToString();
                    TANDIS_PLK_FRM = DbConn.MyDataReader.GetValue(23).ToString();

                }
                else
                {

                    PDRM = DbConn.MyDataReader.GetValue(5).ToString();
                    DSAY = DbConn.MyDataReader.GetValue(3).ToString();
                    if (DSAY != "")
                    {
                        DSAY = (Convert.ToInt32(DSAY) + 1).ToString();

                    }
                    TUGLAFRM = DbConn.MyDataReader.GetValue(4).ToString();
                    PSKTMR = DbConn.MyDataReader.GetValue(6).ToString();
                    GAZDS = DbConn.MyDataReader.GetValue(7).ToString();
                    if (GAZDS != "")
                    {
                        GAZDS = (Convert.ToInt32(GAZDS) + 1).ToString();
                    }
                    GAZFRM = DbConn.MyDataReader.GetValue(8).ToString();
                    GAZTIP = DbConn.MyDataReader.GetValue(9).ToString();
                    USTDS = DbConn.MyDataReader.GetValue(10).ToString();
                    if (USTDS != "")
                    {
                        USTDS = (Convert.ToInt32(USTDS) + 1).ToString();

                    }
                    USTFRM = DbConn.MyDataReader.GetValue(11).ToString();
                    ALTDS = DbConn.MyDataReader.GetValue(12).ToString();
                    if (ALTDS != "")
                    {
                        ALTDS = (Convert.ToInt32(ALTDS) + 1).ToString();
                    }
                    ALTFRM = DbConn.MyDataReader.GetValue(13).ToString();
                    SURGUDS = DbConn.MyDataReader.GetValue(14).ToString();
                    if (SURGUDS != "")
                    {
                        SURGUDS = (Convert.ToInt32(SURGUDS) + 1).ToString();

                    }
                    SURGUFRM = DbConn.MyDataReader.GetValue(15).ToString();
                    SURGUPLKTY = DbConn.MyDataReader.GetValue(16).ToString();
                    KONTROLEDEN = DbConn.MyDataReader.GetValue(17).ToString();
                    ISKARTATAR = DbConn.MyDataReader.GetValue(18).ToString();
                    //int Iskarta = Convert.ToInt32(ISKARTATAR);
                    //tarih_parse = tarihFormat1(Iskarta);
                    PCKSSAAT = DbConn.MyDataReader.GetValue(19).ToString();
                    PGLSSAAT = DbConn.MyDataReader.GetValue(20).ToString();
                    GENELACIKLAMA = DbConn.MyDataReader.GetValue(21).ToString();
                    POTADVRALMATRH = DbConn.MyDataReader.GetValue(22).ToString();
                    PNO = DbConn.MyDataReader.GetValue(2).ToString();
                    TANDIS_PLK_FRM = DbConn.MyDataReader.GetValue(23).ToString();
                }

                secilenler.Add(PDRM);
                secilenler.Add(DSAY);
                secilenler.Add(TUGLAFRM);
                secilenler.Add(PSKTMR);
                secilenler.Add(GAZDS);
                secilenler.Add(GAZFRM);
                secilenler.Add(GAZTIP);
                secilenler.Add(USTDS);
                secilenler.Add(USTFRM);
                secilenler.Add(ALTDS);
                secilenler.Add(ALTFRM);
                secilenler.Add(SURGUDS);
                secilenler.Add(SURGUFRM);
                secilenler.Add(SURGUPLKTY);
                secilenler.Add(KONTROLEDEN);
                secilenler.Add(ISKARTATAR);
                secilenler.Add(PCKSSAAT);
                secilenler.Add(PGLSSAAT);
                secilenler.Add(GENELACIKLAMA);
                secilenler.Add(POTADVRALMATRH);
                secilenler.Add(PNO);
                secilenler.Add(TANDIS_PLK_FRM);
            }

            return secilenler;

        }

        public string yenirefrakter_dokum(DateTime tarih)
        {

            gelentarih = tarih.ToString("yyyyMMdd");//veritabanindaki kayit bicimi
            string sql = "Select MAX(DNO) FROM URTHRK.CH_DOKUMNO_REFRAKTER WHERE TARIH= '" + gelentarih + "'";
            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {
                if (DbConn.MyDataReader.GetValue(0).ToString() == "")
                {
                    //gelenyenidokum_refrakter = "0";
                    string sqlx = "Select MIN(DNO) FROM URTHRK.CH_DOKUMNO_URETIM WHERE DOKUMTAR= " + gelentarih + "";
                    DbConn.Sayac(sqlx);
                    dynamic geridonenrakam = DbConn.GeriDonenRakam;
                    gelenyenidokum_refrakter = geridonenrakam.ToString();

                }
                else
                {
                    gelenyenidokum_refrakter = (Convert.ToInt32(DbConn.MyDataReader.GetValue(0)) + 1).ToString();
                }
            }


            return gelenyenidokum_refrakter;

            //gelen tarihi datetime.now şeklinde daha sonra düzeneleyebilirim

        }

        public string tandis_degeri_bul(object dokumno)
        {
            string sql = "SELECT DEGERI FROM URTHRK.CH_DOKUMNO_GENELBILGILER_DATA WHERE DOKUMNO= '" + dokumno + "' AND BILGITNM='TANDIS BINDIRME SAYISI'";
            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {
                gelen_tandis_miktari = DbConn.MyDataReader.GetValue(0).ToString();
            }

            return gelen_tandis_miktari;
        }
        public string refrakter_dokum_sil(object dokumno, object tarih)
        {
            string MESAJ, sql;
            sql = "DELETE FROM CH_DOKUMNO_REFRAKTER WHERE DNO = " + dokumno + "";
            DbConn.Delete(sql);
            dynamic sql_sorgu = DbConn.GeriDonenRakam;
            if (sql_sorgu != 0)
            {
                MESAJ = "  REFRAKTER BİLGİSİ SİLİNDİ. ";
            }
            else
            {
                MESAJ = "HATA OLUŞTU.TEKRAR DENEYİNİZ";
            }


            return MESAJ;

        }


        /// 


        public List<Kimya_lab_analiz> kimya_lab_analiz_data_read(int bas_dokum_no = 0, int bit_dokum_no = 0)
        {
            return kimya_lab_analiz_select(bas_dokum_no, bit_dokum_no);
        }

        public List<Kimya_lab_analiz> kimya_lab_analiz_select(int bas_dokum_no = 0, int bit_dokum_no = 0)
        {
            string sql;
            List<Kimya_lab_analiz> kayitlar = new List<Kimya_lab_analiz>();
            sql = "SELECT KA.YER,KA.DNO,KA.C,KA.SI,KA.S,KA.P,KA.MN,KA.NI,KA.CR,KA.MO,KA.V,KA.CU,KA.W,KA.SN,KA.CO,KA.AL,KA.ALSOL,KA.ALINSOL,KA.PB," +
                        "KA.B,KA.BSOL,KA.BINSOL,KA.SB,KA.NB,KA.CA,KA.CASOL,KA.CAINSOL,KA.ZN,KA.N,KA.TI,KA.TISOL,KA.TIINSOL,KA.ASS,KA.ZR,KA.BI,KA.OO,KA.FE,KA.CEQ,KA.CE," +
                        "KA.CRNICUX,KA.ALCAOX,KA.AlMGOX,KA.ALSIOX,KA.ALTIOX,KA.ALCAX,KA.ALOX,KA.CAOX,KA.CASX,KA.TIOX,KA.TIALX,KA.MNSX,KA.MGOX,KA.ZROX,KA.SIOX," +
                        "KA.KTKKALITESI,KA.RADYOACTIVITE,KA.YIL " +
                       "FROM URTHRK.KIMYAANALIZ KA ";
            if (bit_dokum_no > 0)
            {
                sql += "WHERE KA.DNO >= " + bas_dokum_no +
                            " AND KA.DNO <= " + bit_dokum_no + ""; ;
            }
            else
            {
                sql += "WHERE KA.DNO=" + bas_dokum_no + "";
            }
            sql += "ORDER BY KA.YER ASC";

            cmd.Parameters.Clear();
            cmd.CommandText = sql;
            dr = cmd.ExecuteReader();
            if (!dr.HasRows)
            {
                //kayit bulunamadiysa
                Kimya_lab_analiz kayit = new Kimya_lab_analiz();
                kayit.Yer = "Listelenecek Analiz Kaydı Bulunamadı.";
                kayit.Analiz_id = 0;
                kayitlar.Add(kayit);
            }
            else
            {
                try
                {
                    while (dr.Read())
                    {
                        Kimya_lab_analiz kayit = new Kimya_lab_analiz();
                        kayit.Analiz_id = 1;
                        kayit.Yer = dr[0].ToString();
                        kayit.Dokum_no = Convert.ToInt32(dr[1].ToString());

                        string sqlx = "SELECT KALITE,RADYOAKTIVITE FROM URTHRK.CH_DOKUMNO_URETIM WHERE DNO=" + kayit.Dokum_no + "";
                        cmd.Parameters.Clear();
                        cmd.CommandText = sqlx;
                        dr2 = cmd.ExecuteReader();
                        while (dr2.Read())
                        {
                            kayit.Celik_cinsi = dr2[0].ToString();
                            kayit.Ract = dr2[1].ToString();
                        }

                        kayit.C = dr[2].ToString();
                        kayit.Si = dr[3].ToString();
                        kayit.S = dr[4].ToString();
                        kayit.P = dr[5].ToString();
                        kayit.Mn = dr[6].ToString();
                        kayit.Ni = dr[7].ToString();

                        kayit.Cr = dr[8].ToString();
                        kayit.Mo = dr[9].ToString();
                        kayit.V = dr[10].ToString();
                        kayit.Cu = dr[11].ToString();
                        kayit.W = dr[12].ToString();
                        kayit.Sn = dr[13].ToString();

                        kayit.Co = dr[14].ToString();
                        kayit.Al = dr[15].ToString();
                        kayit.Alsol = dr[16].ToString();
                        kayit.Alinsol = dr[17].ToString();
                        kayit.Pb = dr[18].ToString();

                        /** ikinci grid */
                        kayit.B = dr[19].ToString();
                        kayit.Bsol = dr[20].ToString();
                        kayit.Binsol = dr[21].ToString();
                        kayit.Sb = dr[22].ToString();
                        kayit.Nb = dr[23].ToString();
                        kayit.Ca = dr[24].ToString();
                        kayit.Casol = dr[25].ToString();

                        kayit.Cainso = dr[26].ToString();
                        kayit.Zn = dr[27].ToString();
                        kayit.N = dr[28].ToString();
                        kayit.Ti = dr[29].ToString();
                        kayit.Tisol = dr[30].ToString();
                        kayit.Tiinsol = dr[31].ToString();

                        kayit.Ass = dr[32].ToString();
                        kayit.Zr = dr[33].ToString();
                        kayit.Bi = dr[34].ToString();
                        kayit.O = dr[35].ToString();
                        kayit.Fe = dr[36].ToString();
                        kayit.Ceq = dr[37].ToString();
                        kayit.Ce = dr[38].ToString();

                        /** ucuncu grid */
                        kayit.Crnicu = dr[39].ToString();
                        kayit.Alcao = dr[40].ToString();
                        kayit.Almgo = dr[41].ToString();
                        kayit.Alsio = dr[42].ToString();
                        kayit.Altio = dr[43].ToString();
                        kayit.Alca = dr[44].ToString();
                        kayit.Alo = dr[45].ToString();

                        kayit.Cao = dr[46].ToString();
                        kayit.Cas = dr[47].ToString();
                        kayit.Tio = dr[48].ToString();
                        kayit.Tial = dr[49].ToString();
                        kayit.Mns = dr[50].ToString();
                        kayit.Mgo = dr[51].ToString();

                        kayit.Zro = dr[52].ToString();
                        kayit.Sio = dr["SIOX"].ToString();

                        // kayit.Celik_cinsi =  dr["KTKKALITESI"].ToString();
                        // kayit.Ract =  dr["RADYOACTIVITE"].ToString();
                        kayit.Yil = Convert.ToInt32(dr["YIL"].ToString());

                        kayitlar.Add(kayit);
                    }
                }
                catch
                {
                    throw;
                }
            }
            dr.Close();
            dr.Dispose();

            return kayitlar;
        }


        //
        public List<Yemek> yemek_tablosu()
        {
            string sql;
            List<Yemek> kayitlar = new List<Yemek>();
            this.yemek_sql = "SELECT MENU " +
                       "FROM URTHRK.YEMEK  ";

            DbConn.RaporWhile(yemek_sql);
            while (DbConn.MyDataReader.Read())
            {
                Yemek kayit = new Yemek();
                kayit.menu = DbConn.MyDataReader.GetValue(0).ToString();
                kayitlar.Add(kayit);

            }


            return kayitlar;
        }



    }
}




