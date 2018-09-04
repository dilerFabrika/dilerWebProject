

using System;
using System.Collections.Generic;
using diler.Entity;
using diler.Bll;

namespace diler.Dal
{
    public class Celikhane_db
    {
        public string AljayTanımı, AljayDegeri, AljayDokumNo, bas_tarih, iskarta_tarihi;
        public string gelentarih, gelenBasTar, gelenBitTar, gelenDokumdurumu, gelenVardiya;
        public string gelen_dokum_tip, gelen_durus_kodu, gelen_ariza_kodu, gelen_tonaj;
        public string gelenDokum, boy, tarih_parse, gelenyenidokum_refrakter, gelen_tandis_miktari;
        dynamic DonenDeger;
        string DonenDeger2, stdktkton, stnkarton, toplam_tonaj, yemek_sql;
        dynamic gun_kontrol;
        dynamic Sarj1_degeri, Sarj2_degeri, Sarj3_degeri, Sarj4_degeri;
        dynamic Toplam_sarj1, Toplam_sarj2, Toplam_sarj3, Toplam_sarj4, Toplam_sarj;
        public int hurda_miktar;


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

        public List<alyaj_tnm_bilgileri> AljayKolonListFull()
        {

            List<alyaj_tnm_bilgileri> alyajtnmbilgileri = new List<alyaj_tnm_bilgileri>();

            string sql = "Select ALYAJTANIMI,LOKASYON,GRUPTANIMI from URTTNM.CH_ALYAJ_TNM WHERE EKRAN=1 ORDER BY LOKASYON,EKRANSIRANO";
            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {
                alyaj_tnm_bilgileri alyajtnmbilgileri_ = new alyaj_tnm_bilgileri();
                alyajtnmbilgileri_.TANIM = DbConn.MyDataReader["ALYAJTANIMI"].ToString();
                alyajtnmbilgileri_.LOKASYON = DbConn.MyDataReader["LOKASYON"].ToString();
                alyajtnmbilgileri_.GRUPTANIM = DbConn.MyDataReader["GRUPTANIMI"].ToString();
                alyajtnmbilgileri.Add(alyajtnmbilgileri_);
            }
            return alyajtnmbilgileri;

        }

        public List<string> DokumNolarList(string bastar, string bittar)
        {

            gelenBasTar = tarihFormat(bastar);
            gelenBitTar = tarihFormat(bittar);

            List<string> DokumNolar = new List<string>();
            string sql = "Select distinct DNO FROM URTHRK.CH_DOKUMNO_URETIM WHERE DOKUMTAR BETWEEN " + gelenBasTar + " AND " + gelenBitTar + " order by DNO";
            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {
                string Tnm = DbConn.MyDataReader["DNO"].ToString();
                DokumNolar.Add(Tnm);
            }
            return DokumNolar;

        }
        public List<genel_bilgiler> DokumNoBilgileri(string bastar, string bittar)
        {

            List<genel_bilgiler> DokumNolar = new List<genel_bilgiler>();
            string sql = "Select DNO,DOKUMTAR FROM URTHRK.CH_DOKUMNO_URETIM WHERE DOKUMTAR BETWEEN " + gelenBasTar + " AND " + gelenBitTar + " order by DNO";
            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {
                genel_bilgiler DokumNoBilgileri_ = new genel_bilgiler();
                DokumNoBilgileri_.DOKUMNO = Convert.ToInt32(DbConn.MyDataReader["DNO"].ToString());
                DokumNoBilgileri_.TARIH = Convert.ToInt32(DbConn.MyDataReader["DOKUMTAR"].ToString());
                DokumNolar.Add(DokumNoBilgileri_);
            }
            return DokumNolar;

        }
        public List<genel_bilgiler> DokumTonajı(string bastar, string bittar)
        {

            List<genel_bilgiler> DokumTonajlar = new List<genel_bilgiler>();
            string sql = "Select DNO,KUTUK_TONAJI FROM URTHRK.CH_DOKUMNO_PERFORMANS WHERE DOKUMTAR BETWEEN " + gelenBasTar + " AND " + gelenBitTar + " ORDER BY DNO";
            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {
                genel_bilgiler DokumTonajBilgileri_ = new genel_bilgiler();
                DokumTonajBilgileri_.DOKUMNO = Convert.ToInt32(DbConn.MyDataReader["DNO"].ToString());
                DokumTonajBilgileri_.KUTUK_TONAJI = Convert.ToDouble(DbConn.MyDataReader["KUTUK_TONAJI"].ToString());
                DokumTonajlar.Add(DokumTonajBilgileri_);
            }
            return DokumTonajlar;

        }
        public List<genel_bilgiler> DokumKalitesi(string bastar, string bittar)
        {

            List<genel_bilgiler> DokumKalitesi = new List<genel_bilgiler>();
            string sql = "Select DNO, KALITE FROM URTHRK.CH_DOKUMNO_URETIM WHERE DOKUMTAR BETWEEN " + gelenBasTar + " AND " + gelenBitTar + " ORDER BY DNO";
            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {
                genel_bilgiler DokumKaliteBilgileri_ = new genel_bilgiler();
                DokumKaliteBilgileri_.DOKUMNO = Convert.ToInt32(DbConn.MyDataReader["DNO"].ToString());
                DokumKaliteBilgileri_.KALITE = Convert.ToString(DbConn.MyDataReader["KALITE"].ToString());
                DokumKalitesi.Add(DokumKaliteBilgileri_);
            }
            return DokumKalitesi;

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

                AlyajDegeri.Add(AljayDokumNo);
                AlyajDegeri.Add(AljayTanımı);
                AlyajDegeri.Add(AljayDegeri);
            }
            return AlyajDegeri;

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

        //*****************
        public dynamic gun_kontrolu_yap(DateTime tarih)
        {
            dynamic DegerAO = 0;
            dynamic DegerPO = 0;
            dynamic DegerSDM = 0;
            dynamic DegerUretim = 0;
            gelentarih = tarih.ToString("yyyyMMdd");//veritabanindaki kayit bicimi     
            string sql = "SELECT AO,PO,SDM,KIMYALAB FROM URTTNM.PRGACKAPAT WHERE TARIH=" + gelentarih + "";
            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {
                DegerAO = DbConn.MyDataReader.GetValue(0);
                DegerPO = DbConn.MyDataReader.GetValue(1);
                DegerSDM = DbConn.MyDataReader.GetValue(2);
                DegerUretim = DbConn.MyDataReader.GetValue(3);
            }
            if (DegerAO == 0 || DegerPO == 0 || DegerSDM == 0 || DegerUretim == 0)
            {
                gun_kontrol = "True";

            }
            else
            {
                if (DegerAO == 1 && DegerPO == 1 && DegerSDM == 1 && DegerUretim == 1)
                    gun_kontrol = "False";
            }

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
            string sql = "select DISTINCT DNO,DRM from URTHRK.CH_DOKUMNO_URETIM WHERE DOKUMTAR=" + gelentarih + " ORDER BY DNO ASC";
            DbConn.RaporWhile(sql);
            DbConn.Sayac(sql);
            while (DbConn.MyDataReader.Read())
            {
                uretim_bilgileri satir = new uretim_bilgileri();
                satir.DOKUMNO = DbConn.MyDataReader.GetValue(0);
                satir.durum = DbConn.MyDataReader.GetValue(1).ToString();
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
                veriler.Add(satir);

            }
            return veriler;
        }
        public string dokum_ozellikleri_kayit(object vardiya, object dokum_no, object dokum_tarihi)
        {

            string MESAJ = "BAŞARIYLA GÜNCELLENDİ.";
            string sql_uretim = "UPDATE URTHRK.CH_DOKUMNO_URETIM SET VRD=" + vardiya + ", DOKUMTAR= " + dokum_tarihi + " " +
                 "WHERE DNO=" + dokum_no + "";
            DbConn.SaveUpdate(sql_uretim);
            string sql_durus = "UPDATE URTHRK.CH_DOKUMNO_DURUS_DATA SET VRD=" + vardiya + ", BASTAR= " + dokum_tarihi + ",BITTAR=" + dokum_tarihi + " " +
                              "WHERE DNO=" + dokum_no + "";
            DbConn.SaveUpdate(sql_durus);
            string sql_enerji = "UPDATE URTHRK.CH_DOKUMNO_ENERJI_DATA SET TARIH= " + dokum_tarihi + " " +
                                 "WHERE DOKUMNO=" + dokum_no + "";
            DbConn.SaveUpdate(sql_enerji);
            string sql_genelbilgi = "UPDATE URTHRK.CH_DOKUMNO_GENELBILGILER_DATA SET TARIH= " + dokum_tarihi + " " +
                                 "WHERE DOKUMNO=" + dokum_no + "";
            DbConn.SaveUpdate(sql_genelbilgi);
            string sql_hurda = "UPDATE URTHRK.CH_DOKUMNO_HURDA_DATA SET TARIH= " + dokum_tarihi + " " +
                                "WHERE DOKUMNO=" + dokum_no + "";
            DbConn.SaveUpdate(sql_hurda);
            string sql_refrakter = "UPDATE URTHRK.CH_DOKUMNO_REFRAKTER SET TARIH= " + dokum_tarihi + " " +
                                   "WHERE DNO=" + dokum_no + "";
            DbConn.SaveUpdate(sql_refrakter);
            string sql_sarf = "UPDATE URTHRK.CH_DOKUMNO_SARFMALZEME_DATA SET TARIH= " + dokum_tarihi + " " +
                                 "WHERE DOKUMNO=" + dokum_no + "";
            DbConn.SaveUpdate(sql_sarf);
            string sql_alyaj = "UPDATE URTHRK.CH_DOKUMNO_ALYAJ_DATA SET TARIH= " + dokum_tarihi + " " +
                               "WHERE DOKUMNO=" + dokum_no + "";
            DbConn.SaveUpdate(sql_alyaj);

            return MESAJ;

        }

        //Alyaj
        public List<alyaj_bilgileri> alyaj_listesi(object dokum_no, string lokasyon)
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
                alyaj_degeri_bul(dokum_no, DbConn.MyDataReader.GetValue(0), DbConn.MyDataReader.GetValue(1));
                satir.DEGERI = DonenDeger;
                if (Convert.ToInt32(satir.DEGERI) == 0 && (satir.SARJTIP == "Enjekte_Kok_Elti" || satir.SARJTIP == "Enjekte_Kok_Panel"))
                {
                    satir.DEGERI = 715;
                }

                veriler.Add(satir);
            }
            return veriler;
        }
        public void alyaj_degeri_bul(object dokum_no, object lokasyon, object alyaj_tanimi)
        {
            DonenDeger = 0;
            string Sql = "SELECT MIKTAR FROM URTHRK.CH_DOKUMNO_ALYAJ_DATA" +
                " WHERE DOKUMNO=" + dokum_no + " and ALYAJTANIM='" + alyaj_tanimi + "'" + " and LOKASYON='" + lokasyon + "'";
            DbConn2.DbBaglan();
            DbConn2.RaporWhile(Sql);
            while (DbConn2.MyDataReader.Read())
            {
                DonenDeger = DbConn2.MyDataReader.GetValue(0).ToString();
            }
            DbConn2.Close();
        }
        public string alyaj_kayit( object dokum_no, object miktar, object alyaj_tanim, object lokasyon)
        {
            dynamic kayitVarmi = 0;
            dynamic grup_kodu = null;
            string sql, mesaj,sql_tarih, dokumun_tarihi;
            dokumun_tarihi = "";
            sql_tarih = "SELECT DISTINCT(DOKUMTAR) FROM URTHRK.CH_DOKUMNO_URETIM WHERE DNO=" + dokum_no + "";
            DbConn.RaporWhile(sql_tarih);
            while (DbConn.MyDataReader.Read())
            {
                dokumun_tarihi = DbConn.MyDataReader.GetValue(0).ToString(); // üretim tablosundaki tarihi alıp ilgili tabloya kayıt yapacak.
            }
            sql = "SELECT COUNT(DOKUMNO) from URTHRK.CH_DOKUMNO_ALYAJ_DATA " +
                " WHERE DOKUMNO=" + dokum_no + " AND ALYAJTANIM='" + alyaj_tanim + "'" + " AND LOKASYON ='" + lokasyon + "'";
            DbConn.Sayac(sql);
            kayitVarmi = DbConn.GeriDonenRakam;
            grup_kodu = "";
           
            sql = "SELECT GRUPTANIMI FROM URTTNM.CH_ALYAJ_TNM " +
                  " WHERE ALYAJTANIMI='" + alyaj_tanim + "'";
            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {
                grup_kodu = DbConn.MyDataReader.GetValue(0).ToString();
            }
            if (kayitVarmi == 0)
            {
                mesaj = "BAŞARIYLA EKLENDİ.";
                sql = "INSERT INTO URTHRK.CH_DOKUMNO_ALYAJ_DATA VALUES(" + dokumun_tarihi + "," + dokum_no + "," +
                    "'" + alyaj_tanim + "','" + grup_kodu + "','" + lokasyon + "'," + miktar + ",NULL" + ")";
            }
            else
            {
                mesaj = "BAŞARIYLA GÜNCELLENDİ.";
                sql = "UPDATE URTHRK.CH_DOKUMNO_ALYAJ_DATA SET MIKTAR=" + miktar + " " +
                    "WHERE DOKUMNO=" + dokum_no + " AND ALYAJTANIM='" + alyaj_tanim + "'" + " AND LOKASYON ='" + lokasyon + "'";
            }
            DbConn.SaveUpdate(sql);
            return mesaj;

        }

        //Hurda

        public List<hurda_bilgileri> hurda_listesi(object dokum_no)
        {
            List<hurda_bilgileri> veriler = new List<hurda_bilgileri>();

            string sql = "SELECT HURDATANIMI FROM URTTNM.CH_HURDA_TNM" +
                         " WHERE EKRAN=1" + " ORDER BY EKRANSIRANO";
            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {
                DonenDeger = 0;
                hurda_bilgileri satir = new hurda_bilgileri();
                satir.HURDATIP = DbConn.MyDataReader.GetValue(0).ToString();
                hurda_degeri_bul(dokum_no, DbConn.MyDataReader.GetValue(0));
                satir.SARJ1 = Sarj1_degeri;
                satir.SARJ2 = Sarj2_degeri;
                satir.SARJ3 = Sarj3_degeri;
                satir.SARJ4 = Sarj4_degeri;
                satir.TOPLAM = Convert.ToDecimal(Sarj1_degeri) + Convert.ToDecimal(Sarj2_degeri) + Convert.ToDecimal(Sarj3_degeri) + Convert.ToDecimal(Sarj4_degeri);
                veriler.Add(satir);
            }

            return veriler;
        }
        public void hurda_degeri_bul(object dokum_no, object hurda_tanimi)
        {
            Sarj1_degeri = 0;
            string sql = "SELECT MIKTAR FROM URTHRK.CH_DOKUMNO_HURDA_DATA" +
                " WHERE  DOKUMNO=" + dokum_no + " AND HURDATANIM='" + hurda_tanimi + "'" + " AND SARJNO=1";
            DbConn2.DbBaglan();
            DbConn2.RaporWhile(sql);
            while (DbConn2.MyDataReader.Read())
            {
                Sarj1_degeri = DbConn2.MyDataReader.GetValue(0).ToString();
            }
            Sarj2_degeri = 0;
            sql = "SELECT MIKTAR FROM URTHRK.CH_DOKUMNO_HURDA_DATA" +
                " WHERE  DOKUMNO=" + dokum_no + " AND HURDATANIM='" + hurda_tanimi + "'" + " AND SARJNO=2";
            DbConn2.RaporWhile(sql);
            while (DbConn2.MyDataReader.Read())
            {
                Sarj2_degeri = DbConn2.MyDataReader.GetValue(0).ToString();
            }
            Sarj3_degeri = 0;
            sql = "SELECT MIKTAR FROM URTHRK.CH_DOKUMNO_HURDA_DATA" +
                " WHERE DOKUMNO=" + dokum_no + " AND HURDATANIM='" + hurda_tanimi + "'" + " AND SARJNO=3";
            DbConn2.RaporWhile(sql);
            while (DbConn2.MyDataReader.Read())
            {
                Sarj3_degeri = DbConn2.MyDataReader.GetValue(0).ToString();
            }
            Sarj4_degeri = 0;
            sql = "SELECT MIKTAR FROM URTHRK.CH_DOKUMNO_HURDA_DATA" +
                " WHERE DOKUMNO=" + dokum_no + " AND HURDATANIM='" + hurda_tanimi + "'" + " AND SARJNO=4";
            DbConn2.RaporWhile(sql);
            while (DbConn2.MyDataReader.Read())
            {
                Sarj4_degeri = DbConn2.MyDataReader.GetValue(0).ToString();
            }

            DbConn2.Close();
        }
        public int hurda_degeri_bul_kayit(DateTime tarih, object dokum_no, object sarj_no, object hurda_tanimi, object degeri)
        {
            hurda_miktar = 0;
            gelentarih = tarih.ToString("yyyyMMdd");//veritabanindaki kayit bicimi 
            string sql = "SELECT MIKTAR FROM URTHRK.CH_DOKUMNO_HURDA_DATA" +
                " WHERE TARIH=" + gelentarih + " AND DOKUMNO=" + dokum_no + " AND HURDATANIM='" + hurda_tanimi + "'" + " AND SARJNO='" + sarj_no + "'";
            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {
                hurda_miktar = Convert.ToInt32(DbConn.MyDataReader.GetValue(0));
            }
            return hurda_miktar;

        }
        public string hurda_kayit( object dokum_no, object sarj_no, object hurda_tanimi, object miktar)
        {
            string sql,sql_tarih,mesaj,dokumun_tarihi;
            dokumun_tarihi = "";
            sql_tarih = "SELECT DISTINCT(DOKUMTAR) FROM URTHRK.CH_DOKUMNO_URETIM WHERE DNO=" + dokum_no + "";
            DbConn.RaporWhile(sql_tarih);
            while (DbConn.MyDataReader.Read())
            {
                dokumun_tarihi = DbConn.MyDataReader.GetValue(0).ToString(); // üretim tablosundaki tarihi alıp ilgili tabloya kayıt yapacak.
            }
            sql = "SELECT COUNT(DOKUMNO) FROM URTHRK.CH_DOKUMNO_HURDA_DATA " +
                " WHERE DOKUMNO=" + dokum_no + " AND HURDATANIM='" + hurda_tanimi + "'" + " AND SARJNO =" + sarj_no + " AND TARIH=" + dokumun_tarihi + "";
            DbConn.Sayac(sql);
            dynamic kayitVarmi = DbConn.GeriDonenRakam;
            if (kayitVarmi == 0)
            {
                mesaj = "BAŞARIYLA EKLENDİ.";
                sql = "INSERT INTO URTHRK.CH_DOKUMNO_HURDA_DATA VALUES(" + dokumun_tarihi + "," + dokum_no + "," + sarj_no + "," + "'" + hurda_tanimi + "'," + miktar + "" + ")";
            }
            else
            {
                mesaj = "BAŞARIYLA GÜNCELLENDİ. ";
                sql = "UPDATE URTHRK.CH_DOKUMNO_HURDA_DATA set MIKTAR=" + miktar + " " +
                      " WHERE DOKUMNO=" + dokum_no + " AND HURDATANIM='" + hurda_tanimi + "' AND SARJNO =" + sarj_no + " AND TARIH=" + dokumun_tarihi + "";
            }
            DbConn.SaveUpdate(sql);
            return mesaj;
        }
        public List<string> Toplam_Sarj_(object dokum_no)
        {

            List<string> secilenler = new List<string>();
            string sql;
            Toplam_sarj1 = 0;
            sql = "SELECT SUM(MIKTAR) FROM CH_DOKUMNO_HURDA_DATA  WHERE DOKUMNO =" + dokum_no + " AND SARJNO=1";
            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {
                Toplam_sarj1 = DbConn.MyDataReader.GetValue(0).ToString();
                secilenler.Add(Toplam_sarj1);
            }
            Toplam_sarj2 = 0;
            sql = "SELECT SUM(MIKTAR) FROM CH_DOKUMNO_HURDA_DATA  WHERE DOKUMNO =" + dokum_no + " AND SARJNO=2";
            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {
                Toplam_sarj2 = DbConn.MyDataReader.GetValue(0).ToString();
                secilenler.Add(Toplam_sarj2);
            }
            Toplam_sarj3 = 0;
            sql = "SELECT SUM(MIKTAR) FROM CH_DOKUMNO_HURDA_DATA  WHERE DOKUMNO =" + dokum_no + "  AND SARJNO=3";
            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {
                Toplam_sarj3 = DbConn.MyDataReader.GetValue(0).ToString();
                secilenler.Add(Toplam_sarj3);
            }
            Toplam_sarj4 = 0;
            sql = "SELECT SUM(MIKTAR) FROM CH_DOKUMNO_HURDA_DATA  WHERE DOKUMNO =" + dokum_no + "  AND SARJNO=4";
            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {
                Toplam_sarj4 = DbConn.MyDataReader.GetValue(0).ToString();
                secilenler.Add(Toplam_sarj4);
            }
            Toplam_sarj = 0;
            sql = "SELECT SUM(MIKTAR) FROM CH_DOKUMNO_HURDA_DATA  WHERE DOKUMNO =" + dokum_no + "";
            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {
                Toplam_sarj = DbConn.MyDataReader.GetValue(0).ToString();
                secilenler.Add(Toplam_sarj);
            }

            return secilenler;

        }



        //Sarf

        public List<sarf_bilgileri> Sarf_Listesi(object dokum_no)
        {
            List<sarf_bilgileri> veriler = new List<sarf_bilgileri>();
            string sql = "SELECT MALZEMETANIMI FROM URTTNM.CH_SARFMALZEME_TNM" +
                         " WHERE EKRAN=1 AND LOKASYON IN('SDM')" + " ORDER BY LOKASYON,EKRANSIRANO";
            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {
                sarf_bilgileri satir = new sarf_bilgileri();
                satir.SARFMLZTNM = DbConn.MyDataReader.GetValue(0).ToString();
                sarf_degeri_bul(dokum_no, DbConn.MyDataReader.GetValue(0));
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
        public List<sarf_bilgileri> sarf_veriler(object dokum_no, object lokasyon)
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
                sarf_degeri_bul(dokum_no, DbConn.MyDataReader.GetValue(0));
                satir.DEGERI = DonenDeger;
                veriler.Add(satir);
            }
            return veriler;
        }
        public void sarf_degeri_bul(object dokum_no, object malzeme_tanimi)
        {
            DonenDeger = 0;
            dynamic Sql = "SELECT MIKTAR FROM URTHRK.CH_DOKUMNO_SARFMALZEME_DATA" +
                          " WHERE DOKUMNO=" + dokum_no + " and SARFMALZEMETANIM='" + malzeme_tanimi + "'";
            DbConn2.DbBaglan();
            DbConn2.RaporWhile(Sql);
            while (DbConn2.MyDataReader.Read())
            {
                DonenDeger = DbConn2.MyDataReader.GetValue(0).ToString();
            }
            DbConn2.Close();

        }
        public string sarf_kayit(object dokum_no, object miktar, object malzeme_tanimi, object lokasyon)
        {
            dynamic kayitVarmi, mesaj;
            string sql, sql_tarih, dokumun_tarihi;
            dokumun_tarihi = "";
            sql_tarih = "SELECT DISTINCT(DOKUMTAR) FROM URTHRK.CH_DOKUMNO_URETIM WHERE DNO=" + dokum_no + "";
            DbConn.RaporWhile(sql_tarih);
            while (DbConn.MyDataReader.Read())
            {
                dokumun_tarihi = DbConn.MyDataReader.GetValue(0).ToString(); // üretim tablosundaki tarihi alıp ilgili tabloya kayıt yapacak.
            }
           sql = "SELECT COUNT(DOKUMNO) from URTHRK.CH_DOKUMNO_SARFMALZEME_DATA " +
                " WHERE DOKUMNO=" + dokum_no + " AND SARFMALZEMETANIM='" + malzeme_tanimi + "'" + " AND LOKASYON ='" + lokasyon + "'";
            DbConn.Sayac(sql);
            kayitVarmi = DbConn.GeriDonenRakam;
            if (kayitVarmi == 0)
            {

                sql = "INSERT INTO URTHRK.CH_DOKUMNO_SARFMALZEME_DATA  VALUES(" + dokumun_tarihi + ", " + dokum_no + ",'" + malzeme_tanimi + "','" + malzeme_tanimi + "','" + lokasyon + "'," + miktar + ", '1' )";
                mesaj = " Başarıyla Eklendi";
            }
            else
            {

                sql = "UPDATE URTHRK.CH_DOKUMNO_SARFMALZEME_DATA  SET MIKTAR=" + miktar + " " +
                    " WHERE DOKUMNO=" + dokum_no + " AND SARFMALZEMETANIM='" + malzeme_tanimi + "'" + " AND LOKASYON ='" + lokasyon + "'";
                mesaj = " Başarıyla Güncellendi";
            }

            DbConn.SaveUpdate(sql);
            return mesaj;
        }


        //GenelBilgi
        public List<genel_bilgiler> genel_bilgi_listesi_analiz(DateTime tarih, object lokasyon)
        {

            gelentarih = tarih.ToString("yyyyMMdd");//veritabanindaki kayit bicimi  
            List<genel_bilgiler> veriler = new List<genel_bilgiler>();
            string sql = "SELECT TANIMI,LOKASYON FROM URTTNM.CH_GENELBILGILER_TNM" +
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
        public List<genel_bilgiler> genel_bilgi_listesi(object dokum_no, object lokasyon)
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
                genel_bilgi_degeri_bul(dokum_no, DbConn.MyDataReader.GetValue(0), lokasyon);
                satir.DEGERI = DonenDeger;
                if (satir.DEGERI == "" && (satir.BILGITNM == "KALIPDOKUMSAYISI_YOL1" || satir.BILGITNM == "KALIPDOKUMSAYISI_YOL2" || satir.BILGITNM == "KALIPDOKUMSAYISI_YOL3" || satir.BILGITNM == "KALIPDOKUMSAYISI_YOL4"
                || satir.BILGITNM == "KALIPDOKUMSAYISI_YOL5" || satir.BILGITNM == "KALIPDOKUMSAYISI_YOL6" || satir.BILGITNM == "TANDIS BINDIRME SAYISI"))
                {
                    int dokumnox = (Convert.ToInt32(dokum_no) - 1);
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
                    int dokumnox = (Convert.ToInt32(dokum_no) - 1);
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
                    int dokumnox = (Convert.ToInt32(dokum_no) - 1);
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


                if (satir.DEGERI == "" && (satir.BILGITNM == "YUREK NO"))
                {
                    int dokumnox = (Convert.ToInt32(dokum_no) - 1);
                    sql = "SELECT COUNT(DNO) FROM URTHRK.CH_DOKUMNO_URETIM WHERE DNO=" + dokumnox + " ";
                    DbConn.Sayac(sql);
                    if (DbConn.GeriDonenRakam.ToString() != "0")
                    {
                        genel_bilgi_degeri_bul3(dokumnox, satir.BILGITNM, "AO");

                        if (DonenDeger2 != "")
                        {
                            satir.DEGERI = Convert.ToInt32(DonenDeger2);
                        }

                    }
                }

                if (satir.DEGERI == "" && (satir.BILGITNM == "DEVIRME SICAKLIK"))
                {
                    satir.DEGERI = 1640;
                }

                veriler.Add(satir);

            }
            return veriler;


        }
        public void genel_bilgi_degeri_bul_analiz(object gelentarih, object bilgi_tanim, object lokasyon)
        {
            DonenDeger2 = "";
            dynamic Sql = "SELECT DEGERI FROM URTHRK.CH_DOKUMNO_GENELBILGILER_DATA" +
                " WHERE TARIH=" + gelentarih + " and BILGITNM='" + bilgi_tanim + "'" + " and LOKASYON='" + lokasyon + "'";
            DbConn2.DbBaglan();
            DbConn2.RaporWhile(Sql);
            while (DbConn2.MyDataReader.Read())
            {
                DonenDeger2 = DbConn2.MyDataReader.GetValue(0).ToString();
            }
            DbConn2.Close();
        }
        public void genel_bilgi_degeri_bul3(object dokum_no, object bilgi_tanim, object lokasyon)
        {
            DonenDeger2 = "";
            dynamic Sql = "SELECT DEGERI FROM URTHRK.CH_DOKUMNO_GENELBILGILER_DATA" +
                " WHERE DOKUMNO=" + dokum_no + " and BILGITNM='" + bilgi_tanim + "'" + " and LOKASYON='" + lokasyon + "'";
            DbConn2.DbBaglan();
            DbConn2.RaporWhile(Sql);
            while (DbConn2.MyDataReader.Read())
            {
                DonenDeger2 = DbConn2.MyDataReader.GetValue(0).ToString();
            }
            DbConn2.Close();
        }
        public void genel_bilgi_degeri_bul2(object dokum_no, object bilgi_tanim, object lokasyon)
        {
            DonenDeger2 = "";
            dynamic Sql = "SELECT DEGERI FROM URTHRK.CH_DOKUMNO_GENELBILGILER_DATA" +
                " WHERE DOKUMNO=" + dokum_no + " and BILGITNM='" + bilgi_tanim + "'" + " and LOKASYON='" + lokasyon + "'";
            DbConn2.DbBaglan();
            DbConn2.RaporWhile(Sql);
            while (DbConn2.MyDataReader.Read())
            {
                DonenDeger2 = DbConn2.MyDataReader.GetValue(0).ToString();
            }
            DbConn2.Close();
        }
        public void genel_bilgi_degeri_bul(object dokum_no, object bilgi_tanim, object lokasyon)
        {
            DonenDeger = "";
            dynamic Sql = "SELECT DEGERI FROM URTHRK.CH_DOKUMNO_GENELBILGILER_DATA" +
                " WHERE DOKUMNO=" + dokum_no + " and BILGITNM='" + bilgi_tanim + "'" + " and LOKASYON='" + lokasyon + "'";
            DbConn2.DbBaglan();
            DbConn2.RaporWhile(Sql);
            while (DbConn2.MyDataReader.Read())
            {
                DonenDeger = DbConn2.MyDataReader.GetValue(0).ToString();
            }
            DbConn2.Close();
        }
        public string genel_bilgi_kayit(object dokum_no, object degeri, object bilgi_tanim, object lokasyon)
        {
           
            string mesaj, sql,dokumun_tarihi,sql_tarih;
            dokumun_tarihi = "";
            sql_tarih = "SELECT DISTINCT(DOKUMTAR) FROM URTHRK.CH_DOKUMNO_URETIM WHERE DNO=" + dokum_no + "";
            DbConn.RaporWhile(sql_tarih);
            while (DbConn.MyDataReader.Read())
            {
                dokumun_tarihi = DbConn.MyDataReader.GetValue(0).ToString(); // üretim tablosundaki tarihi alıp ilgili tabloya kayıt yapacak.
            }
            sql = "SELECT COUNT(DOKUMNO) FROM URTHRK.CH_DOKUMNO_GENELBILGILER_DATA " +
                  " WHERE DOKUMNO=" + dokum_no + " AND BILGITNM='" + bilgi_tanim + "'" + " AND LOKASYON ='" + lokasyon + "'";
            DbConn.Sayac(sql);
            dynamic kayitVarmi = DbConn.GeriDonenRakam;
            if (kayitVarmi == 0)
            {

                sql = "INSERT INTO URTHRK.CH_DOKUMNO_GENELBILGILER_DATA VALUES(" + dokumun_tarihi + "," + dokum_no + "," + "'" + bilgi_tanim + "'," + "'" + lokasyon + "'," + "'" + degeri + "'" + ")";
                mesaj = "BAŞARIYLA EKLENDİ";
            }
            else
            {

                sql = "UPDATE URTHRK.CH_DOKUMNO_GENELBILGILER_DATA SET DEGERI='" + degeri + "'" +
                      " WHERE DOKUMNO=" + dokum_no + " AND BILGITNM='" + bilgi_tanim + "'" + " AND LOKASYON ='" + lokasyon + "'";
                mesaj = "BAŞARIYLA GÜNCELLENDİ";
            }
            DbConn.SaveUpdate(sql);
            return mesaj;
        }
        public string genel_bilgi_kayit_analiz(DateTime tarih, object degeri, object bilgi_tanim, object lokasyon)
        {
            gelentarih = tarih.ToString("yyyyMMdd");//veritabanindaki kayit bicimi  
            string MESAJ, sql;
            sql = "SELECT COUNT(BILGITNM) from URTHRK.CH_DOKUMNO_GENELBILGILER_DATA  WHERE TARIH = " + gelentarih + " AND LOKASYON = '" + lokasyon + "' AND BILGITNM = '" + bilgi_tanim + "'";
            DbConn.Sayac(sql);
            dynamic kayitVarmi = DbConn.GeriDonenRakam;
            if (kayitVarmi == 0)
            {

                sql = "INSERT INTO URTHRK.CH_DOKUMNO_GENELBILGILER_DATA  VALUES(" + gelentarih + ",NULL" + "," + "'" + bilgi_tanim + "'," + "'" + lokasyon + "'," + "'" + degeri + "'" + ")";
                MESAJ = "DÖKÜMÜN ANALİZ ARALIKLARI BAŞARIYLA EKLENDİ";
            }
            else
            {

                sql = "UPDATE URTHRK.CH_DOKUMNO_GENELBILGILER_DATA SET DEGERI='" + degeri + "'" + " WHERE  BILGITNM='" + bilgi_tanim + "'" + " AND LOKASYON ='" + lokasyon + "'";
                MESAJ = "DÖKÜMÜN ANALİZ ARALIKLARI BAŞARIYLA GÜNCELLENDİ";
            }
            DbConn.SaveUpdate(sql);
            return MESAJ;
        }


        //Enerji

        public List<genel_bilgiler> enerji_liste(object dokum_no, object lokasyon)
        {
            List<genel_bilgiler> veriler = new List<genel_bilgiler>();
            string sql = "SELECT TANIMI,LOKASYON FROM URTTNM.CH_ENERJILER_TNM" +
                         " WHERE EKRAN=1 AND LOKASYON IN('" + lokasyon + "')" +
                         " ORDER BY LOKASYON,EKRANSIRANO";
            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {
                genel_bilgiler satir = new genel_bilgiler();
                satir.BILGITNM = DbConn.MyDataReader.GetValue(0).ToString();
                enerji_degeri_bul(dokum_no, DbConn.MyDataReader.GetValue(0), lokasyon);
                satir.DEGERI = DonenDeger;
                veriler.Add(satir);
            }
            return veriler;

        }
        public void enerji_degeri_bul(object dokum_no, object bilgi_tanim, object lokasyon)
        {
            DonenDeger = "";
            string sql = "SELECT DEGERI FROM URTHRK.CH_DOKUMNO_ENERJI_DATA" +
                         " WHERE DOKUMNO=" + dokum_no + " and BILGITNM='" + bilgi_tanim + "'" + " and LOKASYON='" + lokasyon + "'";
            DbConn2.DbBaglan();
            DbConn2.RaporWhile(sql);
            while (DbConn2.MyDataReader.Read())
            {
                DonenDeger = DbConn2.MyDataReader.GetValue(0).ToString();
            }
            DbConn2.Close();
        }
        public string enerji_kayit(object dokum_no, object deger, object bilgi_tanim, object lokasyon)
        {

            string sql, sql_tarih, dokumun_tarihi,mesaj;
            dokumun_tarihi = "";
            sql_tarih = "SELECT DISTINCT(DOKUMTAR) FROM URTHRK.CH_DOKUMNO_URETIM WHERE DNO=" + dokum_no + "";
            DbConn.RaporWhile(sql_tarih);
            while (DbConn.MyDataReader.Read())
            {
                dokumun_tarihi = DbConn.MyDataReader.GetValue(0).ToString(); // üretim tablosundaki tarihi alıp ilgili tabloya kayıt yapacak.
            }
             sql = "SELECT COUNT(DOKUMNO) FROM URTHRK.CH_DOKUMNO_ENERJI_DATA " + 
                   "WHERE DOKUMNO=" + dokum_no + " AND BILGITNM='" + bilgi_tanim + "'" + " AND LOKASYON ='" + lokasyon + "'";
            DbConn.Sayac(sql);
            dynamic kayit_varmi = DbConn.GeriDonenRakam;
            if (kayit_varmi == 0)
            {

                sql = "INSERT INTO URTHRK.CH_DOKUMNO_ENERJI_DATA  VALUES(" + dokumun_tarihi + "," + dokum_no + ",'" + bilgi_tanim + "','" + lokasyon + "','" + deger + "')";
                mesaj = "BAŞARIYLA EKLENDİ";
            }
            else
            {

                sql = "UPDATE URTHRK.CH_DOKUMNO_ENERJI_DATA SET DEGERI='" + deger + "'" + " WHERE DOKUMNO=" + dokum_no + " AND BILGITNM='" + bilgi_tanim + "'" + " AND LOKASYON ='" + lokasyon + "'";
                mesaj = "BAŞARIYLA GÜNCELLENDİ";
            }
            DbConn.SaveUpdate(sql);
            return mesaj;

        }


        //Üretim

        public List<uretim_bilgileri> uretim_liste(object dokum_no)
        {
            List<uretim_bilgileri> veriler = new List<uretim_bilgileri>();
            string sql = "SELECT * FROM URTHRK.CH_DOKUMNO_URETIM WHERE DNO=" + dokum_no + "   ORDER BY DSNO";
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
                satir.STDKTKTONAJ = Convert.ToDouble(DbConn.MyDataReader.GetValue(16).ToString().Equals("") ? "0.0" :
                                     DbConn.MyDataReader.GetValue(16).ToString()).ToString().Replace(",", ".");
                satir.KARISIMSAYISI = DbConn.MyDataReader.GetValue(20).ToString();
                satir.KARISIMTONAJ = Convert.ToDouble(DbConn.MyDataReader.GetValue(21).ToString().Equals("") ? "0.0" :
                                     DbConn.MyDataReader.GetValue(21).ToString()).ToString().Replace(",", ".");
                veriler.Add(satir);
            }

            return veriler;

        }
        public string toplam_tonaj_getir(int dokum_no)
        {


            string sqlx = "SELECT SUM(STDKTKTON), SUM(STNKARTON) FROM URTHRK.CH_DOKUMNO_URETIM WHERE DNO = " + dokum_no + "";
            DbConn.RaporWhile(sqlx);
            while (DbConn.MyDataReader.Read())
            {

                stdktkton = DbConn.MyDataReader.GetValue(0).ToString();
                stnkarton = DbConn.MyDataReader.GetValue(1).ToString();

            }
            toplam_tonaj = (Convert.ToDouble(stdktkton.Equals("") ? "0.0" : stdktkton) + Convert.ToDouble(stnkarton.Equals("") ? "0.0" : stnkarton)).ToString();

            return toplam_tonaj;


        }
        public string dokum_kayit(object sira_no, DateTime tarih, object vardiya, object dokum_durumu)
        {
            string sql = "SELECT MAX(DNO) FROM CH_DOKUMNO_URETIM";
            DbConn.Sayac(sql);
            string dokumnumarasi = (Convert.ToUInt32(DbConn.GeriDonenRakam) + 1).ToString();
            dynamic MESAJ;
            gelentarih = tarih.ToString("yyyyMMdd");//veritabanindaki kayit bicimi
            string sqlx = "INSERT INTO CH_DOKUMNO_URETIM VALUES(" + dokumnumarasi + "," + sira_no + " , " +
                " " + gelentarih + ",'" + vardiya + "',NULL" + ",NULL" + ",NULL" + ",NULL" + ",NULL" + ",NULL" + ",NULL" + ",NULL" + ",NULL" + ",NULL" + ", " +
                " NULL" + ",NULL" + ",NULL" + ",NULL" + ",NULL" + ",NULL" + ",NULL" + ",NULL" + ",NULL" + ",'" + dokum_durumu + "',NULL" + ",NULL" + ",NULL" + ",NULL" + ")";

            MESAJ = dokumnumarasi + " " + "NUMARALI DÖKÜM AÇILDI." + "\n" + "\n" + "DÖKÜM NUMARASI LİSTESİNDEN SEÇİM YAPARAK ÜRETİM BİLGİLERİNİ EKLEYEBİLİRSİNİZ.";
            DbConn.SaveUpdate(sqlx);
            return MESAJ;
        }
        public void dokum_kapat(object gelen_dokum, object durum)
        {
            string sql = "UPDATE CH_DOKUMNO_URETIM SET DRM='" + durum + "'  WHERE DNO= " + gelen_dokum + " ";
            DbConn.SaveUpdate(sql);
        }
        public string uretim_kayit(object dokumno, object sira_no, DateTime tarih, object vardiya, object ozel_kod, object siparis_no,
             object kalite, object boy, object ebat, object sapma_nedeni, object sapma_element, object std_neden, object std_disi_element, object gidecegi_yer, object std_kutuk_sayisi,
             object kutuk_tonaj, object sari_kutuk_sayisi, object sari_kutuk_tonaji, object kalite_kod_sari, object std_karisim_sayisi, object karisim_tonaj, object aciklama,
             object dokumdurum, object dokumtip, object radyo_aktivite, object egri_kutuk_sayisi, object tandis_bindirme)
        {
            string MESAJ;
            string sql = "SELECT COUNT(DNO) FROM URTHRK.CH_DOKUMNO_URETIM " +
                " WHERE DSNO=" + sira_no + " AND DNO=" + dokumno + "";
            DbConn.Sayac(sql);
            dynamic kayitVarmi = DbConn.GeriDonenRakam;
            gelentarih = tarih.ToString("yyyyMMdd");//veritabanindaki kayit bicimi
            if (kayitVarmi == 0)
            {
                sql = "INSERT INTO URTHRK.CH_DOKUMNO_URETIM VALUES(" + dokumno + "," + sira_no + "," + gelentarih + " ," +
                    "'" + vardiya + "','" + ozel_kod + "','" + siparis_no + "',NULL" + ",'" + kalite + "','" + boy + "','" + ebat + "'," +
                    "'" + sapma_nedeni + "','" + sapma_element + "','" + std_neden + "','" + std_disi_element + "','" + gidecegi_yer + "'," +
                    "'" + std_kutuk_sayisi + "'," + kutuk_tonaj + ",'" + sari_kutuk_sayisi + "'," + sari_kutuk_tonaji + ",'" + kalite_kod_sari + "'," +
                    "'" + std_karisim_sayisi + "'," + karisim_tonaj + "," +
                    "'" + aciklama + "','" + dokumdurum + "','" + dokumtip + "','" + radyo_aktivite + "','" + egri_kutuk_sayisi + "','" + tandis_bindirme + "')";
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
                      "DOKOZLKOD='" + ozel_kod + "',SIPNUM='" + siparis_no + "',KALITE='" + kalite + "',BOY= '" + boy + "',EBAT='" + ebat + "'," +
                      "SAPMA_NEDENI='" + sapma_nedeni + "',SAPMA_ELEMENT='" + sapma_element + "'," +
                      "STD_NEDEN='" + std_neden + "',STD_ELEMENT='" + std_disi_element + "',GIDECEGIYER='" + gidecegi_yer + "'," +
                      "STDKTKSAY='" + std_kutuk_sayisi + "', STDKTKTON=" + kutuk_tonaj + ", SARIKTKSAY='" + sari_kutuk_sayisi + "'," +
                      "SARIKTKTON=" + sari_kutuk_tonaji + ", KALITEKODSARI='" + kalite_kod_sari + "',STNKARSAY='" + std_karisim_sayisi + "', " +
                      "STNKARTON=" + karisim_tonaj + ", KTKACIKLAMA='" + aciklama + "',DRM='" + dokumdurum + "',DOKUMTIP='" + dokumtip + "'," +
                      "RADYOAKTIVITE='" + radyo_aktivite + "',VRD=" + vardiya + ", DOKUMTAR=" + gelentarih + ",EGRI_KUTUK_SAYISI='" + egri_kutuk_sayisi + "',TANDIS_BINDIRME = '" + tandis_bindirme + "'" +
                      " WHERE DNO=" + dokumno + " AND  DSNO=" + sira_no + " ";

                DbConn.SaveUpdate(sql);
                MESAJ = "ÜRETİM BİLGİLERİ BAŞARIYLA GÜNCELLENDİ";
            }

            return MESAJ;
        }

        public string dokum_sirasi_sil(object dokum_no, object sira_no, object tarih)
        {
            string MESAJ, sql;
            sql = "DELETE FROM CH_DOKUMNO_URETIM WHERE DNO = " + dokum_no + " AND DSNO=" + sira_no + " ";
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
        public List<string> uretimdegiskeni_Bul(object dokum_no)
        {
            List<string> uretimDegiskenleri = new List<string>();
            string sql = "SELECT DRM,VRD FROM URTHRK.CH_DOKUMNO_URETIM WHERE DNO=" + dokum_no + " ";
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
        public string dokum_tip_getir(object gelen_celik_cinsi)
        {
            string sql = "SELECT YER FROM URTTNM.KAPALIDOKUM_KALITE WHERE KALITE=  '" + gelen_celik_cinsi + "'";
            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {
                gelen_dokum_tip = DbConn.MyDataReader.GetValue(0).ToString();

            }

            return gelen_dokum_tip;


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
        public List<uretim_bilgileri> uretim_secilen_getir(object dokum_no, object sira_no)
        {

            List<uretim_bilgileri> kayitlar = new List<uretim_bilgileri>();
            // gelentarih = tarih.ToString("yyyyMMdd");//veritabanindaki kayit bicimi
            string sql = "SELECT KALITE,BOY,EBAT,STDKTKSAY,VRD,DOKUMTIP,DOKOZLKOD,SIPNUM," +
                         "SAPMA_NEDENI,SAPMA_ELEMENT,STD_NEDEN,STD_ELEMENT,GIDECEGIYER,STDKTKTON,SARIKTKSAY," +
                         "SARIKTKTON,KALITEKODSARI,STNKARSAY,STNKARTON,KTKACIKLAMA,DNO,DSNO,RADYOAKTIVITE,EGRI_KUTUK_SAYISI,DOKUMTAR,TANDIS_BINDIRME" +
                         " FROM URTHRK.CH_DOKUMNO_URETIM WHERE DNO=" + dokum_no + " AND DSNO=" + sira_no + "";
            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {
                uretim_bilgileri kayit = new uretim_bilgileri();
                kayit.CELIKCINSI = DbConn.MyDataReader.GetValue(0).ToString();
                kayit.KTKBOY = DbConn.MyDataReader.GetValue(1).ToString();
                kayit.KTKEBAT = DbConn.MyDataReader.GetValue(2).ToString();
                kayit.KTKADET = DbConn.MyDataReader.GetValue(3).ToString();
                kayit.vrd = DbConn.MyDataReader.GetValue(4).ToString();
                kayit.dokumTip = DbConn.MyDataReader.GetValue(5).ToString();
                kayit.ozel_kod = DbConn.MyDataReader.GetValue(6).ToString();
                kayit.sipnum = DbConn.MyDataReader.GetValue(7).ToString();
                kayit.sapma_Nedeni = DbConn.MyDataReader.GetValue(8).ToString();
                kayit.sapma_Element = DbConn.MyDataReader.GetValue(9).ToString();
                kayit.std_Neden = DbConn.MyDataReader.GetValue(10).ToString();
                kayit.std_Element = DbConn.MyDataReader.GetValue(11).ToString();
                kayit.gidecegi_yer = DbConn.MyDataReader.GetValue(12).ToString();

                kayit.stdktkton = Convert.ToDouble(DbConn.MyDataReader.GetValue(13).ToString().Equals("") ? "0.0" :
                                    DbConn.MyDataReader.GetValue(13).ToString()).ToString().Replace(",", ".");
                kayit.sariktksay = DbConn.MyDataReader.GetValue(14).ToString();
                kayit.sariktkton = Convert.ToDouble(DbConn.MyDataReader.GetValue(15).ToString().Equals("") ? "0.0" :
                                    DbConn.MyDataReader.GetValue(15).ToString()).ToString().Replace(",", ".");
                kayit.kalitekodsari = DbConn.MyDataReader.GetValue(16).ToString();
                kayit.stnkarsay = DbConn.MyDataReader.GetValue(17).ToString();
                kayit.stnkarton = Convert.ToDouble(DbConn.MyDataReader.GetValue(18).ToString().Equals("") ? "0.0" :
                                    DbConn.MyDataReader.GetValue(18).ToString()).ToString().Replace(",", ".");
                kayit.ktkaciklama = DbConn.MyDataReader.GetValue(19).ToString();
                kayit.DOKUMNO = DbConn.MyDataReader.GetValue(20).ToString();
                kayit.SIRANO = DbConn.MyDataReader.GetValue(21).ToString();
                kayit.radyo_aktivite = DbConn.MyDataReader.GetValue(22).ToString();
                kayit.egri_kutuk_sayisi = DbConn.MyDataReader.GetValue(23).ToString();
                kayit.dokumtar = Convert.ToInt32(DbConn.MyDataReader.GetValue(24).ToString());
                kayit.tandis_bindirme = DbConn.MyDataReader.GetValue(25).ToString();

                kayitlar.Add(kayit);
            }

            return kayitlar;
        }
        public string dokum_yeni_sira(object dokumNo)
        {


            string sql = "SELECT MAX(DSNO) FROM URTHRK.CH_DOKUMNO_URETIM  WHERE DNO=" + dokumNo + " GROUP BY DNO";
            DbConn.Sayac(sql);
            string gelen_sirano = (DbConn.GeriDonenRakam).ToString();
            return gelen_sirano;

        }
        public string katsayiGetir(object boy, object ebat, DateTime tarih, object vardiya, object d8)
        {
            gelentarih = tarih.ToString("yyyyMMdd");//veritabanindaki kayit bicimi
            string sql = "SELECT KATSAYI FROM URTTNM.KATSAYI_TARTIMDAN " +
                "WHERE BOY=  '" + boy + "' AND EBAT= '" + ebat + "' AND TARIH= " + gelentarih + " AND VRD = " + vardiya + " AND CC = '" + d8 + "' ";
            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {
                gelen_tonaj = DbConn.MyDataReader.GetValue(0).ToString();

            }
            if (gelen_tonaj == null)
            {

                string sql1 = "SELECT KATSAYI FROM " +
                    " (SELECT * FROM URTTNM.KATSAYI_TARTIMDAN WHERE BOY ='" + boy + "' AND EBAT ='" + ebat + "'  AND CC ='" + d8 + "' ORDER BY TARIH DESC) " +
                    " WHERE ROWNUM= 1 ";
                DbConn.RaporWhile(sql1);
                while (DbConn.MyDataReader.Read())
                {
                    gelen_tonaj = DbConn.MyDataReader.GetValue(0).ToString();

                }
                if (gelen_tonaj == null) //04.07.2018 tarihinde eklendi
                {

                    string sql2 = "SELECT KATSAYI FROM " +
                        " (SELECT * FROM URTTNM.KATSAYI_TARTIMDAN WHERE BOY ='" + boy + "' AND EBAT ='" + ebat + "'  ORDER BY TARIH DESC) " +
                        " WHERE ROWNUM= 1 ";
                    DbConn.RaporWhile(sql2);
                    while (DbConn.MyDataReader.Read())
                    {
                        gelen_tonaj = DbConn.MyDataReader.GetValue(0).ToString();

                    }
                }
            }
            return gelen_tonaj;
        }
        public List<uretim_bilgileri> send_ktk_dokum_liste(object dokum_no)
        {
            List<uretim_bilgileri> veriler = new List<uretim_bilgileri>();
            string sqly = "SELECT COUNT(DNO) FROM URTHRK.TAVFRN WHERE DNO=" + dokum_no + " ";
            DbConn.Sayac(sqly);
            if (DbConn.GeriDonenRakam.ToString() != "0")
            {
                string sqlyy = "SELECT  DISTINCT(DNO),sum(KTKADET) FROM TAVFRN WHERE DNO = " + dokum_no + " GROUP BY DNO";
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
                string sql = "SELECT DISTINCT(DNO) FROM URTHRK.CH_DOKUMNO_URETIM WHERE DNO=" + dokum_no + "";
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
        public string sicak_sarja_gonderilecek_kutuk(DateTime tarih, object dokum_no,
                                                     int GKTKSAYISI, object kalite, object boy, object ebat)
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
            sql2 = "SELECT sum(KTKADET) FROM TAVFRN WHERE DNO=" + dokum_no + "";
            DbConn.Sayac(sql2);
            string ktkadet = DbConn.GeriDonenRakam.ToString();
            sql3 = "SELECT SUM(STDKTKSAY) FROM CH_DOKUMNO_URETIM WHERE DNO = " + dokum_no + "";
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
                        " '" + dokum_no + "','" + kalite + "','" + ebat + "','" + boy + "','" + d4 + "','" + gir_saati + "', " +
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
            //Koda tanım tipi 04.04.2018de eklendi Ömer bey söyledi
            List<string> degiskenler = new List<string>();
            string sql = "SELECT KOD FROM URTTNM.TANIMLAR WHERE KOD_ACK ='" + kalite + "' AND TESIS ='HH' AND TNMTIPI='KALITE'";
            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {
                string gelenKalite_kod = DbConn.MyDataReader.GetValue(0).ToString();
                degiskenler.Add(gelenKalite_kod);
            }
            string sqlx = "SELECT KOD FROM URTTNM.TANIMLAR WHERE KOD_ACK ='" + boy + "' AND TESIS ='HH' AND TNMTIPI='BOY'";
            DbConn.RaporWhile(sqlx);
            while (DbConn.MyDataReader.Read())
            {
                string gelenKalite_boy = DbConn.MyDataReader.GetValue(0).ToString();
                degiskenler.Add(gelenKalite_boy);
            }
            string sqly = "SELECT KOD FROM URTTNM.TANIMLAR WHERE KOD_ACK ='" + ebat + "' AND TESIS ='HH' AND TNMTIPI='EBAT'";
            DbConn.RaporWhile(sqly);
            while (DbConn.MyDataReader.Read())
            {
                string gelenKalite_ebat = DbConn.MyDataReader.GetValue(0).ToString();
                degiskenler.Add(gelenKalite_ebat);
            }
            return degiskenler;
        }



        //Duruş 
        public List<durus_bilgileri> durus_liste(object dokum_no)
        {
            List<durus_bilgileri> kayitlar = new List<durus_bilgileri>();
            string sql = "SELECT * FROM URTHRK.CH_DOKUMNO_DURUS_DATA WHERE DNO=" + dokum_no + " ORDER BY BASSAAT";
            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {
                durus_bilgileri kayit = new durus_bilgileri();
                kayit.BASSAATI = DbConn.MyDataReader.GetValue(4).ToString();
                kayit.BITISSAATI = DbConn.MyDataReader.GetValue(6).ToString();
                kayit.SURE = DbConn.MyDataReader.GetValue(7).ToString();
                kayit.DURUSNEDEN = DbConn.MyDataReader.GetValue(10).ToString();
                kayit.ARIZANEDEN = DbConn.MyDataReader.GetValue(11).ToString();
                kayit.ARIZAKOD = DbConn.MyDataReader.GetValue(9).ToString();
                kayit.SARJALMA = DbConn.MyDataReader.GetValue(12).ToString();
                kayit.DURUSKOD = DbConn.MyDataReader.GetValue(8).ToString();
                kayit.DURUS_ID = DbConn.MyDataReader.GetValue(15).ToString();
                kayitlar.Add(kayit);
            }
            return kayitlar;

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
        public string durus_kod_getir(object gelen_neden)
        {
            string sql = "Select DURNDNKOD FROM URTTNM.CH_DURUS_NEDEN WHERE DURNDNACK= '" + gelen_neden + "'";
            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {
                gelen_durus_kodu = DbConn.MyDataReader.GetValue(0).ToString();

            }
            return gelen_durus_kodu;
        }
        public List<string> ariza_neden_cmbDoldur(object durus_kod)
        {
            List<string> nedenler = new List<string>();
            string sqlx = "SELECT ARZACK FROM URTTNM.CH_ARIZA_NEDEN WHERE DURNDNKOD='" + durus_kod + "'";
            DbConn.RaporWhile(sqlx);
            while (DbConn.MyDataReader.Read())
            {
                string neden = DbConn.MyDataReader["ARZACK"].ToString();
                nedenler.Add(neden);
            }
            return nedenler;
        }

        public string ariza_kod_getir(object gelen_ariza_neden, object durus_kod)
        {
            dynamic sqly = "SELECT ARZNDNKOD FROM URTTNM.CH_ARIZA_NEDEN WHERE ARZACK= '" + gelen_ariza_neden + "' AND DURNDNKOD='" + durus_kod + "'";
            DbConn.RaporWhile(sqly);
            while (DbConn.MyDataReader.Read())
            {
                gelen_ariza_kodu = DbConn.MyDataReader.GetValue(0).ToString();

            }
            return gelen_ariza_kodu;
        }
        public void durus_sablon_getir(object dokum_no, DateTime tarih)
        {
            string sql, sql1, sql2, sql3, sql4, d1, d2, d3, d4, d5, d9, d10, d11, d12, d13, d14, d15, d17, sqlx;
            d1 = "DCH";
            d2 = "13A";
            d3 = "Proses";
            d5 = "RBT HAZIRLAMA";
            d17 = " ";
            gelentarih = tarih.ToString("yyyyMMdd");//veritabanindaki kayit bicimi
            sqlx = "SELECT COUNT(DNO) FROM URTHRK.CH_DOKUMNO_DURUS_DATA WHERE DNO=" + dokum_no + " AND TESIS='" + d1 + "' AND BASTAR=" + gelentarih + "";
            DbConn.Sayac(sqlx);
            dynamic kayitVarmi = DbConn.GeriDonenRakam;
            if (kayitVarmi == 0)
            {

                List<string> uretimDegiskenleri = new List<string>();
                uretimDegiskenleri = uretimdegiskeni_Bul(dokum_no);
                d4 = uretimDegiskenleri[0];

                sql = "INSERT INTO URTHRK.CH_DOKUMNO_DURUS_DATA VALUES('" + d1 + "','" + dokum_no + "','" + d4 + "' , " +
                    " '" + gelentarih + "',NULL" + ",'" + gelentarih + "', NULL" + " , '" + 2 + "', '" + 1 + "','" + d2 + "','" + d3 + "','" + d5 + "','" + d17 + "',NULL" + ",'" + 1 + "',NULL" + ")";
                DbConn.SaveUpdate(sql);
                d9 = "11A";
                d10 = "ŞARJ ALMA";
                d11 = "1. VE 2. ŞARJ ALMA";
                sql1 = "INSERT INTO URTHRK.CH_DOKUMNO_DURUS_DATA VALUES('" + d1 + "','" + dokum_no + "','" + d4 + "' ," +
                   " '" + gelentarih + "',NULL" + ",'" + gelentarih + "', NULL" + " , '" + 2 + "', '" + 1 + "','" + d9 + "','" + d3 + "','" + d10 + "','" + d11 + "',NULL" + "," + 1 + ",NULL" + ")";
                DbConn.SaveUpdate(sql1);
                d12 = "3.ŞARJ ALMA";
                sql2 = "INSERT INTO URTHRK.CH_DOKUMNO_DURUS_DATA VALUES('" + d1 + "','" + dokum_no + "','" + d4 + "' , " +
                    "'" + gelentarih + "',NULL" + ",'" + gelentarih + "', NULL" + " , '" + 2 + "', '" + 1 + "','" + d9 + "','" + d3 + "','" + d10 + "','" + d12 + "',NULL" + "," + 1 + ",NULL" + ")";
                DbConn.SaveUpdate(sql2);
                d13 = "TD 1.ŞARJ ALMA";
                sql3 = "INSERT INTO URTHRK.CH_DOKUMNO_DURUS_DATA VALUES('" + d1 + "','" + dokum_no + "','" + d4 + "' ," +
                    "'" + gelentarih + "',NULL" + ",'" + gelentarih + "', NULL" + " , '" + 2 + "', '" + 1 + "','" + d9 + "','" + d3 + "','" + d10 + "','" + d13 + "',NULL" + "," + 1 + ",NULL" + ")";
                DbConn.SaveUpdate(sql3);
                d14 = "12A";
                d15 = "Döküm devirme";
                sql4 = "INSERT INTO URTHRK.CH_DOKUMNO_DURUS_DATA VALUES('" + d1 + "','" + dokum_no + "','" + d4 + "' ," +
                    "'" + gelentarih + "',NULL" + ",'" + gelentarih + "', NULL" + " , '" + 4 + "', '" + 1 + "','" + d14 + "','" + d3 + "','" + d15 + "','" + d17 + "',NULL" + "," + 1 + ",NULL" + ")";
                DbConn.SaveUpdate(sql4);
            }


        }
        public string durus_kayit(object dokum_no, object durus_neden, object durus_neden_kod, object ariza_neden, object vardiya, object sarj_durum,
            object tesis, object netsure, object ariza_neden_kod, object aciklama, object baslangic_saati, object bitis_saati, object durus_id)
        {
            string sql, sqlx, sql_tarih, mesaj,dokumun_tarihi;
            dynamic kayitVarmi, kayit;
            dokumun_tarihi = "";
            sql_tarih = "SELECT DISTINCT(DOKUMTAR) FROM URTHRK.CH_DOKUMNO_URETIM WHERE DNO=" + dokum_no + "";
            DbConn.RaporWhile(sql_tarih);
            while (DbConn.MyDataReader.Read())
            {
                dokumun_tarihi = DbConn.MyDataReader.GetValue(0).ToString(); // üretim tablosundaki tarihi alıp ilgili tabloya kayıt yapacak.
            }
            sql = "SELECT COUNT(DNO) FROM URTHRK.CH_DOKUMNO_DURUS_DATA WHERE  DURUS_ID=" + durus_id + "";
            DbConn.Sayac(sql);
            kayitVarmi = DbConn.GeriDonenRakam;
            sqlx = "SELECT COUNT(DNO) FROM URTHRK.CH_DOKUMNO_DURUS_DATA WHERE BASSAAT='" + baslangic_saati + "' AND BITSAAT='" + bitis_saati + "' AND BASTAR=" + gelentarih + " ";
            DbConn.Sayac(sqlx);
            kayit = DbConn.GeriDonenRakam;
            if (kayitVarmi == 0)
            {
                //if (kayit == 0)
                //{
                sql = "INSERT INTO CH_DOKUMNO_DURUS_DATA VALUES('" + tesis + "','" + dokum_no + "','" + vardiya + "', " + dokumun_tarihi + " " +
                    " ,'" + baslangic_saati + "'," + gelentarih + ",'" + bitis_saati + "','" + netsure + "','" + durus_neden_kod + "','" + ariza_neden_kod + "'," +
                    " '" + durus_neden + "','" + ariza_neden + "','" + sarj_durum + "','" + aciklama + "'," + 1 + ",NULL" + ")";
                mesaj = " DURUŞ BİLGİLERİ BAŞARIYLA EKLENDİ ";
                DbConn.SaveUpdate(sql);
                //}
                //else
                //{
                //    MESAJ = "\n" + tarih + "'de seçtiğiniz saat" + " aralığında " + " duruş bulunmaktadır !! ";
                //}

            }
            else
            {

                sql = "UPDATE URTHRK.CH_DOKUMNO_DURUS_DATA SET BASSAAT='" + baslangic_saati + "'," +
               " BITSAAT='" + bitis_saati + "', SURE='" + netsure + "', SARJDRM='" +sarj_durum + "', DURUSNEDEN= '" + durus_neden + "'," +
               " ARIZANEDEN='" + ariza_neden + "',DURNEDKOD='" + durus_neden_kod + "',ARZNEDKOD='" + ariza_neden_kod + "',ACIKLAMA='" + aciklama + "'" +
               " WHERE DNO='" + dokum_no + "' AND  DURUS_ID='" + durus_id + "'";
                mesaj = " DURUŞ BİLGİLERİ BAŞARIYLA GÜNCELLENDİ";
                DbConn.SaveUpdate(sql);

            }
            return mesaj;

        }
        public List<durus_bilgileri> durus_bilgisi_getir(object dokum_no, object durus_Id)
        {
            List<durus_bilgileri> kayitlar = new List<durus_bilgileri>();
            string sql = "SELECT BASSAAT,BITSAAT,SARJDRM,DURUSNEDEN,ARIZANEDEN," +
                " DURNEDKOD,ARZNEDKOD,SURE,ACIKLAMA FROM URTHRK.CH_DOKUMNO_DURUS_DATA" +
                " WHERE DNO=" + dokum_no + " AND DURUS_ID=" + durus_Id + " ";
            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {
                durus_bilgileri kayit = new durus_bilgileri();
                kayit.BASSAATI = DbConn.MyDataReader.GetValue(0).ToString();
                kayit.BITISSAATI = DbConn.MyDataReader.GetValue(1).ToString();
                kayit.SARJALMA = DbConn.MyDataReader.GetValue(2).ToString();
                kayit.DURUSNEDEN = DbConn.MyDataReader.GetValue(3).ToString();
                kayit.ARIZANEDEN = DbConn.MyDataReader.GetValue(4).ToString();
                kayit.DURUSKOD = DbConn.MyDataReader.GetValue(5).ToString();
                kayit.ARIZAKOD = DbConn.MyDataReader.GetValue(6).ToString();
                kayit.SURE = DbConn.MyDataReader.GetValue(7).ToString();
                kayit.aciklama = DbConn.MyDataReader.GetValue(8).ToString();
                kayitlar.Add(kayit);

            }
            return kayitlar;

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
        public string refrakter_kayit(object dokum_no, object baslangic_tarih, object pota_no,
               object dokum_sayisi, object d4, object d5, object d6, object d7, object d8, object d9, object d10,
               object d13, object d14, object d15, object d16, object d17, object d18, object d19, object d20,
               object iskarta_tarih, object d22, object d23, object d24)
        {
            dynamic kayit_count;
            string sql, sql_tarih, dokumun_tarihi, mesaj;
            dokumun_tarihi = "";
            sql_tarih = "SELECT DISTINCT(DOKUMTAR) FROM URTHRK.CH_DOKUMNO_URETIM WHERE DNO=" + dokum_no + "";
            DbConn.RaporWhile(sql_tarih);
            while (DbConn.MyDataReader.Read())
            {
                dokumun_tarihi = DbConn.MyDataReader.GetValue(0).ToString(); // üretim tablosundaki tarihi alıp ilgili tabloya kayıt yapacak.
            }
            if (baslangic_tarih.ToString() != "")
            {
                bas_tarih = Convert.ToDateTime(baslangic_tarih).ToString("yyyyMMdd");

            }
            if (iskarta_tarih.ToString() != "")
            {

                iskarta_tarihi = Convert.ToDateTime(iskarta_tarih).ToString("yyyyMMdd");
            }
           sql = "SELECT COUNT(DNO) FROM URTHRK.CH_DOKUMNO_REFRAKTER " + " where DNO=" + dokum_no + "";
            DbConn.Sayac(sql);
            kayit_count = DbConn.GeriDonenRakam;
            if (kayit_count == 0)
            {
                sql = "INSERT INTO URTHRK.CH_DOKUMNO_REFRAKTER VALUES(" + dokum_no + "," + dokumun_tarihi + ",'" + pota_no + "'," +
                    " '" + dokum_sayisi + "','" + d4 + "','" + d5 + "','" + d6 + "','" + d7 + "','" + d8 + "','" + d9 + "'," +
                    " '" + d13 + "','" + d14 + "','" + d15 + "','" + d16 + "','" + d17 + "','" + d18 + "'," +
                    " '" + d19 + "','" + d20 + "','" + iskarta_tarihi + "','" + d23 + "','" + d22 + "','" + d24 + "','" + bas_tarih + "', '" + d10 + "')";
                mesaj = "REFRAKTER BİLGİLERİ BAŞARIYLA EKLENDİ";

                //d17 surguds genel bilgilerdeki tandis son sıcaklık değerine kayıt ediliyor.
                string sql_kayit = "SELECT COUNT(DOKUMNO) FROM URTHRK.CH_DOKUMNO_GENELBILGILER_DATA " +
                      " WHERE DOKUMNO=" + dokum_no + " AND BILGITNM='POTA PLAKA NO'  AND LOKASYON ='SDM'";
                DbConn.Sayac(sql_kayit);
                kayit_count = DbConn.GeriDonenRakam;
                if (kayit_count == 0)
                {
                    string sql_x = "INSERT INTO URTHRK.CH_DOKUMNO_GENELBILGILER_DATA VALUES " +
                        "(" + dokumun_tarihi + "," + dokum_no + "," + "  'POTA PLAKA NO', " + " 'SDM'," + "'" + d17 + "'" + ")";
                    DbConn.SaveUpdate(sql_x);
                }
                else
                {
                    string sql_y = "UPDATE URTHRK.CH_DOKUMNO_GENELBILGILER_DATA SET DEGERI='" + d17 + "'" +
                        " WHERE DOKUMNO=" + dokum_no + " AND BILGITNM='POTA PLAKA NO' " + " AND LOKASYON ='SDM'";
                    DbConn.SaveUpdate(sql_y);
                }

                //potano genelbilgilerdeki pota durumuna kayıt ediliyor
                string sql_kayit2 = "SELECT COUNT(DOKUMNO) FROM URTHRK.CH_DOKUMNO_GENELBILGILER_DATA " +
                    " WHERE DOKUMNO=" + dokum_no + " AND BILGITNM='POTA DURUMU'  AND LOKASYON ='SDM'";
                DbConn.Sayac(sql_kayit2);
                kayit_count = DbConn.GeriDonenRakam;
                if (kayit_count == 0)
                {
                    string sqlx = "INSERT INTO URTHRK.CH_DOKUMNO_GENELBILGILER_DATA VALUES " +
                         "(" + dokumun_tarihi + "," + dokum_no + "," + "  'POTA DURUMU', " + " 'SDM'," + "'" + pota_no + "'" + ")";
                    DbConn.SaveUpdate(sqlx);
                }
                else
                {
                    string sqly = "UPDATE URTHRK.CH_DOKUMNO_GENELBILGILER_DATA SET DEGERI='" + pota_no + "'" +
                         " WHERE DOKUMNO=" + dokum_no + " AND BILGITNM='POTA DURUMU' " + " AND LOKASYON ='SDM'";
                    DbConn.SaveUpdate(sqly);
                }

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
                    "PCKSSAAT ='" + d23 + "',PGLSSAAT ='" + d22 + "',GENELACIKLAMA ='" + d24 + "',POTADVRALMATRH= '" + bas_tarih + "' WHERE DNO=" + dokum_no + " ";
                mesaj = "REFRAKTER BİLGİLERİ BAŞARIYLA GÜNCELLENDİ";

                // d17 surguds genel bilgilerdeki tandis son sıcaklık değerine kayıt ediliyor.
                string sql_kayit = "SELECT COUNT(DOKUMNO) FROM URTHRK.CH_DOKUMNO_GENELBILGILER_DATA " +
                      " WHERE DOKUMNO=" + dokum_no + " AND BILGITNM='POTA PLAKA NO'  AND LOKASYON ='SDM'";
                DbConn.Sayac(sql_kayit);
                kayit_count = DbConn.GeriDonenRakam;
                if (kayit_count == 0)
                {
                    string sql_x = "INSERT INTO URTHRK.CH_DOKUMNO_GENELBILGILER_DATA VALUES " +
                         "(" + dokumun_tarihi + "," + dokum_no + "," + "  'POTA PLAKA NO', " + " 'SDM'," + "'" + d17 + "'" + ")";
                    DbConn.SaveUpdate(sql_x);
                }
                else
                {
                    string sql_y = "UPDATE URTHRK.CH_DOKUMNO_GENELBILGILER_DATA SET DEGERI='" + d17 + "'" +
                        " WHERE DOKUMNO=" + dokum_no + " AND BILGITNM='POTA PLAKA NO' " + " AND LOKASYON ='SDM'";
                    DbConn.SaveUpdate(sql_y);
                }

                //potano genelbilgilerdeki pota durumuna kayıt ediliyor
                string sql_kayit2 = "SELECT COUNT(DOKUMNO) FROM URTHRK.CH_DOKUMNO_GENELBILGILER_DATA " +
                    " WHERE DOKUMNO=" + dokum_no + " AND BILGITNM='POTA DURUMU'  AND LOKASYON ='SDM'";
                DbConn.Sayac(sql_kayit2);
                kayit_count = DbConn.GeriDonenRakam;
                if (kayit_count == 0)
                {
                    string sqlx = "INSERT INTO URTHRK.CH_DOKUMNO_GENELBILGILER_DATA VALUES " +
                          "(" + dokumun_tarihi + "," + dokum_no + "," + "  'POTA DURUMU', " + " 'SDM'," + "'" + pota_no + "'" + ")";
                    DbConn.SaveUpdate(sqlx);
                }
                else
                {
                    string sqly = "UPDATE URTHRK.CH_DOKUMNO_GENELBILGILER_DATA SET DEGERI='" + pota_no + "'" +
                        " WHERE DOKUMNO=" + dokum_no + " AND BILGITNM='POTA DURUMU' " + " AND LOKASYON ='SDM'";
                    DbConn.SaveUpdate(sqly);
                }

            }

            DbConn.SaveUpdate(sql);
            return mesaj;

        }
        public List<refrakter_bilgileri> refrakter_liste(DateTime tarih)
        {
            gelentarih = tarih.ToString("yyyyMMdd");//veritabanindaki kayit bicimi
            List<refrakter_bilgileri> kayitlar = new List<refrakter_bilgileri>();
            string sql = "SELECT * FROM URTHRK.CH_DOKUMNO_REFRAKTER WHERE TARIH=" + gelentarih + "   ORDER BY DNO DESC";
            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {
                refrakter_bilgileri kayit = new refrakter_bilgileri();
                kayit.DOKUMNO = DbConn.MyDataReader.GetValue(0);
                kayit.POTANO = DbConn.MyDataReader.GetValue(2);
                kayit.DKMSAYISI = DbConn.MyDataReader.GetValue(3);
                kayit.TUGLAFIRMA = DbConn.MyDataReader.GetValue(4).ToString();
                kayit.PUSKURTMELI = DbConn.MyDataReader.GetValue(6).ToString();
                kayit.BASLANGICTARIHI = DbConn.MyDataReader.GetValue(22).ToString();
                kayit.POTADURUM = DbConn.MyDataReader.GetValue(5).ToString();
                kayit.ISKARTATARIHI = DbConn.MyDataReader.GetValue(18).ToString();
                kayit.GAZTAPASIDS = DbConn.MyDataReader.GetValue(7).ToString();
                kayit.USTNOZULDS = DbConn.MyDataReader.GetValue(10).ToString();
                kayit.ALTNOZULDS = DbConn.MyDataReader.GetValue(12).ToString();
                kayit.SURGUDS = DbConn.MyDataReader.GetValue(14).ToString();
                kayit.SURGUFIRMA = DbConn.MyDataReader.GetValue(15).ToString();
                kayit.SURGUPLKTY = DbConn.MyDataReader.GetValue(16).ToString();
                kayit.POTACIKISSAATI = DbConn.MyDataReader.GetValue(19).ToString();
                kayit.POTAGELISSAATI = DbConn.MyDataReader.GetValue(20).ToString();
                kayit.KONTROLEDEN = DbConn.MyDataReader.GetValue(17).ToString();
                kayit.ACIKLAMA = DbConn.MyDataReader.GetValue(21).ToString();
                kayitlar.Add(kayit);
            }
            return kayitlar;

        }
        public List<refrakter_bilgileri> refrakter_bilgisi_getir(object dokum_no)
        {
            List<refrakter_bilgileri> kayitlar = new List<refrakter_bilgileri>();

            string sql = "SELECT PDRM,DSAY,TUGLAFRM,PSKTMR,GAZDS,GAZFRM,GAZTIP, " +
                        " USTDS,USTFRM,ALTDS, ALTFRM,SURGUDS, " +
                        " SURGUFRM,SURGUPLKTY,KONTROLEDEN,ISKARTATAR,PCKSSAAT,PGLSSAAT,GENELACIKLAMA, " +
                         " POTADVRALMATRH,PNO,TANDIS_PLK_FRM FROM URTHRK.CH_DOKUMNO_REFRAKTER WHERE DNO=" + dokum_no + " ";
            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {
                refrakter_bilgileri kayit = new refrakter_bilgileri();
                kayit.POTADURUM = DbConn.MyDataReader.GetValue(0).ToString();
                kayit.DKMSAYISI = DbConn.MyDataReader.GetValue(1).ToString();
                kayit.TUGLAFIRMA = DbConn.MyDataReader.GetValue(2).ToString();
                kayit.PUSKURTMELI = DbConn.MyDataReader.GetValue(3).ToString();
                kayit.GAZTAPASIDS = DbConn.MyDataReader.GetValue(4).ToString();
                kayit.gazFirma = DbConn.MyDataReader.GetValue(5).ToString();
                kayit.gazTip = DbConn.MyDataReader.GetValue(6).ToString();
                kayit.USTNOZULDS = DbConn.MyDataReader.GetValue(7).ToString();
                kayit.ustFirma = DbConn.MyDataReader.GetValue(8).ToString();
                kayit.ALTNOZULDS = DbConn.MyDataReader.GetValue(9).ToString();
                kayit.altFirma = DbConn.MyDataReader.GetValue(10).ToString();
                kayit.SURGUDS = DbConn.MyDataReader.GetValue(11).ToString();
                kayit.SURGUFIRMA = DbConn.MyDataReader.GetValue(12).ToString();
                kayit.SURGUPLKTY = DbConn.MyDataReader.GetValue(13).ToString();
                kayit.KONTROLEDEN = DbConn.MyDataReader.GetValue(14).ToString();
                kayit.ISKARTATARIHI = DbConn.MyDataReader.GetValue(15).ToString();
                kayit.POTACIKISSAATI = DbConn.MyDataReader.GetValue(16).ToString();
                kayit.POTAGELISSAATI = DbConn.MyDataReader.GetValue(17).ToString();
                kayit.ACIKLAMA = DbConn.MyDataReader.GetValue(18).ToString();
                kayit.BASLANGICTARIHI = DbConn.MyDataReader.GetValue(19).ToString();
                kayit.POTANO = DbConn.MyDataReader.GetValue(20).ToString();
                kayit.TANDIS_PLK_FRM = DbConn.MyDataReader.GetValue(21).ToString();

                kayitlar.Add(kayit);
            }

            return kayitlar;

        }
        public List<refrakter_bilgileri> yeni_refrakter(string pota_no)
        {
            List<refrakter_bilgileri> kayitlar = new List<refrakter_bilgileri>();
            string sql, sqlx;
            sql = "SELECT MAX(DNO) FROM " +
             " URTHRK.CH_DOKUMNO_REFRAKTER WHERE PNO=" + pota_no + " ";
            DbConn.Sayac(sql);
            dynamic dokum_no = DbConn.GeriDonenRakam;
            sqlx = "SELECT * FROM " +
              " URTHRK.CH_DOKUMNO_REFRAKTER WHERE DNO=" + dokum_no + " ";
            DbConn.RaporWhile(sqlx);
            while (DbConn.MyDataReader.Read())
            {

                refrakter_bilgileri kayit = new refrakter_bilgileri();
                if (DbConn.MyDataReader.GetValue(5).ToString() == "ISKARTA")
                {
                    kayit.POTADURUM = DbConn.MyDataReader.GetValue(5).ToString();
                    kayit.DKMSAYISI = "1";
                    kayit.TUGLAFIRMA = DbConn.MyDataReader.GetValue(4).ToString();
                    kayit.PUSKURTMELI = DbConn.MyDataReader.GetValue(6).ToString();
                    kayit.GAZTAPASIDS = "1";
                    kayit.gazFirma = DbConn.MyDataReader.GetValue(8).ToString();
                    kayit.gazTip = DbConn.MyDataReader.GetValue(9).ToString();
                    kayit.USTNOZULDS = "1";
                    kayit.ustFirma = DbConn.MyDataReader.GetValue(11).ToString();
                    kayit.ALTNOZULDS = "1";
                    kayit.altFirma = DbConn.MyDataReader.GetValue(13).ToString();
                    kayit.SURGUDS = "1";
                    kayit.SURGUFIRMA = DbConn.MyDataReader.GetValue(15).ToString();
                    kayit.SURGUPLKTY = DbConn.MyDataReader.GetValue(16).ToString();
                    kayit.KONTROLEDEN = DbConn.MyDataReader.GetValue(17).ToString();
                    kayit.ISKARTATARIHI = DbConn.MyDataReader.GetValue(18).ToString();
                    kayit.POTACIKISSAATI = DbConn.MyDataReader.GetValue(19).ToString();
                    kayit.POTAGELISSAATI = DbConn.MyDataReader.GetValue(20).ToString();
                    kayit.ACIKLAMA = DbConn.MyDataReader.GetValue(21).ToString();
                    kayit.BASLANGICTARIHI = DbConn.MyDataReader.GetValue(22).ToString();
                    kayit.POTANO = DbConn.MyDataReader.GetValue(2).ToString();
                    kayit.TANDIS_PLK_FRM = DbConn.MyDataReader.GetValue(23).ToString();

                }
                else
                {

                    kayit.POTADURUM = DbConn.MyDataReader.GetValue(5).ToString();
                    kayit.DKMSAYISI = DbConn.MyDataReader.GetValue(3).ToString();
                    if (kayit.DKMSAYISI != "")
                    {
                        kayit.DKMSAYISI = (Convert.ToInt32(kayit.DKMSAYISI) + 1).ToString();

                    }
                    kayit.TUGLAFIRMA = DbConn.MyDataReader.GetValue(4).ToString();
                    kayit.PUSKURTMELI = DbConn.MyDataReader.GetValue(6).ToString();
                    kayit.GAZTAPASIDS = DbConn.MyDataReader.GetValue(7).ToString();
                    if (kayit.GAZTAPASIDS != "")
                    {
                        kayit.GAZTAPASIDS = (Convert.ToInt32(kayit.GAZTAPASIDS) + 1).ToString();
                    }
                    kayit.gazFirma = DbConn.MyDataReader.GetValue(8).ToString();
                    kayit.gazTip = DbConn.MyDataReader.GetValue(9).ToString();
                    kayit.USTNOZULDS = DbConn.MyDataReader.GetValue(10).ToString();
                    if (kayit.USTNOZULDS != "")
                    {
                        kayit.USTNOZULDS = (Convert.ToInt32(kayit.USTNOZULDS) + 1).ToString();

                    }
                    kayit.ustFirma = DbConn.MyDataReader.GetValue(11).ToString();
                    kayit.ALTNOZULDS = DbConn.MyDataReader.GetValue(12).ToString();
                    if (kayit.ALTNOZULDS != "")
                    {
                        kayit.ALTNOZULDS = (Convert.ToInt32(kayit.ALTNOZULDS) + 1).ToString();
                    }
                    kayit.altFirma = DbConn.MyDataReader.GetValue(13).ToString();
                    kayit.SURGUDS = DbConn.MyDataReader.GetValue(14).ToString();
                    if (kayit.SURGUDS != "")
                    {
                        kayit.SURGUDS = (Convert.ToInt32(kayit.SURGUDS) + 1).ToString();

                    }


                    kayit.SURGUFIRMA = DbConn.MyDataReader.GetValue(15).ToString();
                    kayit.SURGUPLKTY = DbConn.MyDataReader.GetValue(16).ToString();
                    kayit.KONTROLEDEN = DbConn.MyDataReader.GetValue(17).ToString();
                    kayit.ISKARTATARIHI = DbConn.MyDataReader.GetValue(18).ToString();
                    kayit.POTACIKISSAATI = DbConn.MyDataReader.GetValue(19).ToString();
                    kayit.POTAGELISSAATI = DbConn.MyDataReader.GetValue(20).ToString();
                    kayit.ACIKLAMA = DbConn.MyDataReader.GetValue(21).ToString();
                    kayit.BASLANGICTARIHI = DbConn.MyDataReader.GetValue(22).ToString();
                    kayit.POTANO = DbConn.MyDataReader.GetValue(2).ToString();
                    kayit.TANDIS_PLK_FRM = DbConn.MyDataReader.GetValue(23).ToString();


                }

                kayitlar.Add(kayit);

            }

            return kayitlar;

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
        public string tandis_degeri_bul(object dokum_no)
        {
            string sql = "SELECT DEGERI FROM URTHRK.CH_DOKUMNO_GENELBILGILER_DATA" +
                         " WHERE DOKUMNO= '" + dokum_no + "' AND BILGITNM='TANDIS BINDIRME SAYISI'";
            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {
                gelen_tandis_miktari = DbConn.MyDataReader.GetValue(0).ToString();
            }

            return gelen_tandis_miktari;
        }
        public string refrakter_dokum_sil(object dokum_no)
        {
            string MESAJ, sql;
            sql = "DELETE FROM CH_DOKUMNO_REFRAKTER WHERE DNO = " + dokum_no + "";
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




        //

        //
        public List<Yemek> yemek_tablosu(string tarih, string tarih2)
        {

            List<Yemek> kayitlar = new List<Yemek>();
            this.yemek_sql = "SELECT GUN,MENU " +
                       "FROM URTHRK.YEMEK WHERE TARIH BETWEEN '" + tarih + "' AND '" + tarih2 + "' ORDER BY TARIH ";

            DbConn.RaporWhile(yemek_sql);
            while (DbConn.MyDataReader.Read())
            {
                Yemek kayit = new Yemek();
                kayit.gun = DbConn.MyDataReader.GetValue(0).ToString();
                kayit.menu = DbConn.MyDataReader.GetValue(1).ToString();
                kayitlar.Add(kayit);

            }


            return kayitlar;
        }

        public List<Yemek> yemek_tablosu(string tarih3)
        {

            List<Yemek> kayitlar = new List<Yemek>();
            this.yemek_sql = "SELECT GUN,MENU " +
                       "FROM URTHRK.YEMEK WHERE TARIH='" + tarih3 + "' ORDER BY TARIH ";

            DbConn.RaporWhile(yemek_sql);
            while (DbConn.MyDataReader.Read())
            {
                Yemek kayit = new Yemek();
                kayit.gun = DbConn.MyDataReader.GetValue(0).ToString();
                kayit.menu = DbConn.MyDataReader.GetValue(1).ToString();
                kayitlar.Add(kayit);

            }


            return kayitlar;
        }

        public List<Haber> haber_tablosu(string tarih3)
        {
            List<Haber> kayitlar = new List<Haber>();
            string sql = "SELECT HABER " +
                       "FROM URTHRK.HABERLER WHERE BASLIK='DOGUM GUNU TEBRIGI' AND SON_GORULME='" + tarih3 + "' ORDER BY SON_GORULME ";

            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {
                Haber kayit = new Haber();
                kayit.haber = DbConn.MyDataReader.GetValue(0).ToString();

                kayitlar.Add(kayit);

            }


            return kayitlar;
        }

        public List<Haber> bes_tablosu(string tarih3)
        {

            List<Haber> kayitlar = new List<Haber>();
            string sql = "SELECT HABER " +
                       "FROM URTHRK.HABERLER WHERE BASLIK='5S'  ORDER BY SON_GORULME ";

            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {
                Haber kayit = new Haber();
                kayit.bes = DbConn.MyDataReader.GetValue(0).ToString();

                kayitlar.Add(kayit);

            }


            return kayitlar;
        }
        public List<Haber> dosis_tablosu(string tarih3)
        {

            List<Haber> kayitlar = new List<Haber>();
            string sql = "SELECT HABER " +
                       "FROM URTHRK.HABERLER WHERE BASLIK='DOSIS'  ORDER BY SON_GORULME ";

            DbConn.RaporWhile(sql);
            while (DbConn.MyDataReader.Read())
            {
                Haber kayit = new Haber();
                kayit.dosis = DbConn.MyDataReader.GetValue(0).ToString();

                kayitlar.Add(kayit);

            }


            return kayitlar;
        }



    }
}




