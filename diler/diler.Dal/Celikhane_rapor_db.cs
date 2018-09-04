using diler.Entity;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace diler.Dal
{
    public class Celikhane_rapor_db
    {

        List<Sarfiyatlar> sarfiyatlar = new List<Sarfiyatlar>();
        OracleConnection conn,conn1, conn2;
        string connetionString, sql;
        OracleCommand cmd,cmd1;
        OracleDataReader dr,dr1;

        string Gun_kwh_elktoztutma, Ay_kwh_elktoztutma, Yil_kwh_elktoztutma;
        string gunluk_uretim, aylik_uretim, yillik_uretim, gun_toplam_sure, ay_toplam_sure, yil_toplam_sure;
        string ark_gun, pota_gun, oksijen_gun, ch_servis_gun_global, toztutma_gun, hava_komp_gun, su_pomp_gun, denizsuyu_gun, hurda_eleme_gun;

        string ark_ay, pota_ay, oksijen_ay, ch_servis_ay_global, toztutma_ay, hava_komp_ay, su_pomp_ay, denizsuyu_ay, hurda_eleme_ay;

        string ark_yil, pota_yil, oksijen_yil, ch_servis_yil_global, toztutma_yil, hava_komp_yil, su_pomp_yil, denizsuyu_yil, hurda_eleme_yil;

        string ark_Gun_kwh_ton, pota_Gun_kwh_ton, oksijen_Gun_kwh_ton, ch_servis_Gun_kwh_ton, toztutma_Gun_kwh_ton, hava_komp_Gun_kwh_ton,
            su_pomp_Gun_kwh_ton, denizsuyu_Gun_kwh_ton, hurda_eleme_Gun_kwh_ton;

        string ark_Ay_kwh_ton, pota_Ay_kwh_ton, oksijen_Ay_kwh_ton, ch_servis_Ay_kwh_ton, toztutma_Ay_kwh_ton, hava_komp_Ay_kwh_ton,
            su_pomp_Ay_kwh_ton, denizsuyu_Ay_kwh_ton, hurda_eleme_Ay_kwh_ton;

        string ark_yil_kwh_ton, pota_yil_kwh_ton, oksijen_yil_kwh_ton, ch_servis_yil_kwh_ton, toztutma_yil_kwh_ton, hava_komp_yil_kwh_ton,
            su_pomp_yil_kwh_ton, denizsuyu_yil_kwh_ton, hurda_eleme_yil_kwh_ton;



        public Celikhane_rapor_db()
        {
            try
            {
                this.connetionString = @"Data Source=(DESCRIPTION=" +
                    "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.198.191)(PORT=1521)))" +
                    "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=DLRORA)));" +
                    "User Id=URTHRK;Password=URTHRK;";
                this.cmd = new OracleCommand();
                this.cmd1 = new OracleCommand();
                this.conn = new OracleConnection(this.connetionString);
                this.conn1 = new OracleConnection(this.connetionString);
                this.conn2 = new OracleConnection(this.connetionString);
            }
            catch
            {
                throw new System.InvalidOperationException("Veri tabanı bağlantısı gerçekleştirilemiyor.Tekrar deneyiniz");
            }



        }

        public List<Analizler> analizler_data_read(string tarih)
        {

            List<Analizler> kayitlar = new List<Analizler>();
            this.sql = "SELECT * " +
                       "FROM URTHRK.CH_DOKUMNO_GENELTAKIP_ANALIZ KA ";
            if (Convert.ToInt32(tarih) > 0)
            {
                this.sql += "WHERE KA.DOKUMTAR = " + tarih + " ORDER BY DNO ASC";
            }
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Analizler kayit = new Analizler();
                kayit.B = "Listelenecek Kayıt Bulunamadı !!";
                kayit.Analiz_id = 0;
                kayitlar.Add(kayit);
            }
            else
            {

                while (this.dr.Read())
                {
                    Analizler kayit = new Analizler();
                    kayit.Uretimdensapma_element = this.dr[3].ToString();
                    if (kayit.Uretimdensapma_element != "")
                    {
                        kayit.Analiz_id = 2;
                    }

                    if (kayit.Uretimdensapma_element == "")
                    {
                        kayit.Analiz_id = 1;
                    }
                    kayit.Dokum_no = this.dr[1].ToString();
                    kayit.Celik_cinsi = this.dr[2].ToString();
                    kayit.C = this.dr[5].ToString();
                    kayit.Si = this.dr[6].ToString();
                    kayit.S = this.dr[7].ToString();
                    kayit.P = this.dr[8].ToString();
                    kayit.Mn = this.dr[9].ToString();
                    kayit.Ni = this.dr[10].ToString();
                    kayit.Cr = this.dr[11].ToString();
                    kayit.Cu = this.dr[12].ToString();
                    kayit.Mo = this.dr[13].ToString();
                    kayit.Sn = this.dr[14].ToString();
                    kayit.V = this.dr[15].ToString();
                    kayit.N = this.dr[16].ToString();
                    kayit.Ceg = this.dr[17].ToString();
                    kayit.B = this.dr[18].ToString();
                    kayit.Ca = this.dr[19].ToString();
                    kayit.Ti = this.dr[20].ToString();
                    kayit.Al = this.dr[21].ToString();
                    kayit.Pb = this.dr[22].ToString();
                    kayit.Nb = this.dr[23].ToString();
                    kayitlar.Add(kayit);
                }

            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;
        }
        public List<Uretimler> uretimler_data_read(string tarih)
        {
            List<Uretimler> uretimler = new List<Uretimler>();
            string yil = tarih.Substring(0, 4);
            string yil_baslangic = yil + "0101";
            string yil_ay = tarih.Substring(0, 6);
            string ay_baslangic = yil_ay + "01";
            //3 ayrı sorgu UNION ALL ile tekte birleştirilebilir günlük aylık yıllık diye tabloda belirtmek sıkıntılı
            this.sql = "SELECT (SELECT COUNT(dno) FROM URTHRK.CH_DOKUMNO_URETIM WHERE DOKUMTAR = " + tarih + " AND DSNO = 1) AS DNO, " +
                  "(SELECT SUM(STDKTKTON) FROM URTHRK.CH_DOKUMNO_URETIM WHERE  DOKUMTAR = " + tarih + ") AS STDKTKTON," +
                  "(SELECT SUM(STNKARTON) FROM URTHRK.CH_DOKUMNO_URETIM WHERE  DOKUMTAR = " + tarih + ") AS STNKARTON," +
                 "(SELECT SUM(miktar) FROM urthrk.ch_dokumno_hurda_data WHERE TARIH = " + tarih + ") AS HURDA " +
                  "FROM CH_DOKUMNO_URETIM WHERE DOKUMTAR = " + tarih + " AND ROWNUM = 1 ";

            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            while (this.dr.Read())
            {
                Uretimler u = new Uretimler();
                u.Uretim_id = 1;
                u.Uretim_bilgitnm = "GÜNLÜK";
                u.Dokum_sayisi = Convert.ToDouble(this.dr[0]).ToString("###,###.###");
                u.Uretim = (Convert.ToDouble(this.dr[1].ToString().Equals("") ? "0.0" : this.dr[1].ToString()) +
                  Convert.ToDouble(this.dr[2].ToString().Equals("") ? "0.0" : this.dr[2].ToString())).ToString("###,###.###");

                gunluk_uretim = (Convert.ToDouble(this.dr[1].ToString().Equals("") ? "0.0" : this.dr[1].ToString()) +
                  Convert.ToDouble(this.dr[2].ToString().Equals("") ? "0.0" : this.dr[2].ToString())).ToString("0");

                u.Imale_sevk_hurda = Convert.ToDouble(this.dr[3]).ToString("###,###.###");
                uretimler.Add(u);
            }

            this.sql = "SELECT (SELECT(COUNT(dno)) FROM URTHRK.CH_DOKUMNO_URETIM WHERE DOKUMTAR BETWEEN '" + ay_baslangic + "' AND '" + tarih + "' AND DSNO = 1) AS DNO," +
                  "(SELECT SUM(STDKTKTON) FROM URTHRK.CH_DOKUMNO_URETIM WHERE DOKUMTAR BETWEEN '" + ay_baslangic + "' AND '" + tarih + "') AS STDKTKTON," +
                  "(SELECT SUM(STNKARTON) FROM URTHRK.CH_DOKUMNO_URETIM WHERE DOKUMTAR BETWEEN '" + ay_baslangic + "' AND '" + tarih + "') AS STNKARTON," +
                   "(SELECT SUM(miktar) FROM urthrk.ch_dokumno_hurda_data WHERE TARIH BETWEEN '" + ay_baslangic + "' AND '" + tarih + "') AS HURDA " +
                   "FROM CH_DOKUMNO_URETIM WHERE ROWNUM = 1 ";

            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            while (this.dr.Read())
            {
                Uretimler u = new Uretimler();
                u.Uretim_id = 1;
                u.Uretim_bilgitnm = "AYLIK";
                u.Dokum_sayisi = Convert.ToDouble(this.dr[0]).ToString("###,###.###");
                u.Uretim = (Convert.ToDouble(this.dr[1].ToString().Equals("") ? "0.0" : this.dr[1].ToString()) +
             Convert.ToDouble(this.dr[2].ToString().Equals("") ? "0.0" : this.dr[2].ToString())).ToString("###,###.###");

                aylik_uretim = (Convert.ToDouble(this.dr[1].ToString().Equals("") ? "0.0" : this.dr[1].ToString()) +
             Convert.ToDouble(this.dr[2].ToString().Equals("") ? "0.0" : this.dr[2].ToString())).ToString("0");
                u.Imale_sevk_hurda = Convert.ToDouble(this.dr[3]).ToString("###,###.###");
                uretimler.Add(u);
            }
            this.sql = "SELECT (SELECT COUNT(dno) FROM URTHRK.CH_DOKUMNO_URETIM WHERE DOKUMTAR BETWEEN '" + yil_baslangic + "' AND '" + tarih + "'   AND  DSNO = 1) AS DNO," +
               "(SELECT SUM(STDKTKTON) FROM URTHRK.CH_DOKUMNO_URETIM WHERE DOKUMTAR BETWEEN '" + yil_baslangic + "' AND '" + tarih + "') AS STDKTKTON," +
                  "(SELECT SUM(STNKARTON) FROM URTHRK.CH_DOKUMNO_URETIM WHERE DOKUMTAR BETWEEN '" + yil_baslangic + "' AND '" + tarih + "') AS STNKARTON," +
                "(SELECT SUM(miktar) FROM urthrk.ch_dokumno_hurda_data WHERE TARIH BETWEEN '" + yil_baslangic + "' AND '" + tarih + "') AS HURDA " +
                "FROM CH_DOKUMNO_URETIM  WHERE ROWNUM = 1";
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            while (this.dr.Read())
            {
                Uretimler u = new Uretimler();
                u.Uretim_id = 1;
                u.Uretim_bilgitnm = "YILLIK";
                u.Dokum_sayisi = Convert.ToDouble(this.dr[0]).ToString("###,###.###");

                u.Uretim = (Convert.ToDouble(this.dr[1].ToString().Equals("") ? "0.0" : this.dr[1].ToString()) +
                            Convert.ToDouble(this.dr[2].ToString().Equals("") ? "0.0" : this.dr[2].ToString())).ToString("###,###.###");
                yillik_uretim = (Convert.ToDouble(this.dr[1].ToString().Equals("") ? "0.0" : this.dr[1].ToString()) +
                                Convert.ToDouble(this.dr[2].ToString().Equals("") ? "0.0" : this.dr[2].ToString())).ToString("0");

                u.Imale_sevk_hurda = Convert.ToDouble(this.dr[3]).ToString("###,###.###");
                uretimler.Add(u);
            }

            this.dr.Close();
            this.dr.Dispose();

            return uretimler;
        }
        public List<Analizler> uretim_ozetler_data_read(string tarih)
        {
            List<Analizler> kayitlar = new List<Analizler>();
            this.sql = "SELECT KALITE,EBAT,BOY,STDKTKTON,STNKARTON FROM URTHRK.CH_ONLINE_URETIM_OZET ";
            if (Convert.ToInt32(tarih) > 0)
            {
                this.sql += "WHERE DOKUMTAR = " + tarih;
            }
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Analizler analiz = new Analizler();
                analiz.B = "Listelenecek Kayıt Bulunamadı !!";
                analiz.Analiz_id = 0;
                kayitlar.Add(analiz);
            }
            else
            {

                while (this.dr.Read())
                {
                    Analizler kayit = new Analizler();
                    kayit.Analiz_id = 1;
                    kayit.Celik_cinsi = this.dr[0].ToString();
                    kayit.Ebat = this.dr[1].ToString();
                    kayit.Boy = this.dr[2].ToString();
                    kayit.Tonaj = (Convert.ToDouble(this.dr[3].ToString().Equals("") ? "0.0" : this.dr[3].ToString()) +
                      Convert.ToDouble(this.dr[4].ToString().Equals("") ? "0.0" : this.dr[4].ToString())).ToString("0");

                    kayitlar.Add(kayit);

                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;
        }
        public List<Hurdalar> hurdalar_data_read(string tarih)
        {
            List<Hurdalar> hurdalar = new List<Hurdalar>();
            string yil = tarih.Substring(0, 4);
            string yil_baslangic = yil + "0101";
            string yil_ay = tarih.Substring(0, 6);
            string ay_baslangic = yil_ay + "01";

            this.sql = "SELECT HURDATANIM," +
    "(SELECT SUM(MIKTAR) FROM URTHRK.CH_DOKUMNO_HURDA_DATA H WHERE TARIH = " + tarih + " AND H.HURDATANIM = HD.HURDATANIM) AS GUNLUK," +
    "(SELECT SUM(MIKTAR) FROM URTHRK.CH_DOKUMNO_HURDA_DATA H WHERE TARIH BETWEEN '" + ay_baslangic + "' AND '" + tarih + "'  AND  H.HURDATANIM = HD.HURDATANIM) AS AYLIK," +
    "(SELECT SUM(MIKTAR) FROM URTHRK.CH_DOKUMNO_HURDA_DATA H WHERE TARIH BETWEEN '" + yil_baslangic + "' AND '" + tarih + "'  AND H.HURDATANIM = HD.HURDATANIM) as YILLIK," +
    "(SELECT SUM(MIKTAR) FROM URTHRK.CH_DOKUMNO_HURDA_AS400_STOK H WHERE TIP = 'GIRIS' AND TARIH = " + tarih + " AND H.HURDATANIM = HD.HURDATANIM) AS GUNLUKGIRIS," +
    "(SELECT SUM(MIKTAR) FROM URTHRK.CH_DOKUMNO_HURDA_AS400_STOK H WHERE TIP = 'GIRIS' AND TARIH BETWEEN '" + ay_baslangic + "' AND '" + tarih + "'   AND H.HURDATANIM = HD.HURDATANIM) AS AYLIKGIRIS," +
    "(SELECT SUM(MIKTAR) FROM URTHRK.CH_DOKUMNO_HURDA_AS400_STOK H WHERE TIP = 'GIRIS' AND TARIH BETWEEN '" + yil_baslangic + "' AND '" + tarih + "'   AND H.HURDATANIM = HD.HURDATANIM) AS YILLIKGIRIS," +
    "(SELECT SUM(MIKTAR) FROM URTHRK.CH_DOKUMNO_HURDA_AS400_STOK H WHERE TIP = 'STOK' AND TARIH =" + tarih + "  AND  H.HURDATANIM = HD.HURDATANIM) AS STOK " +
    "FROM URTHRK.CH_DOKUMNO_HURDA_DATA HD GROUP BY HURDATANIM";

            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Hurdalar h = new Hurdalar();
                h.Hurda_bilgitnm = " Listelenecek kayıt bulunamadı.";
                h.Hurda_id = 0;
                hurdalar.Add(h);
            }
            else
            {
                try
                {
                    while (this.dr.Read())
                    {
                        Hurdalar h = new Hurdalar();
                        h.Hurda_id = 1;
                        h.Hurda_bilgitnm = this.dr[0].ToString();
                        h.Gunluk_kullanim = Convert.ToDouble(this.dr[1].ToString().Equals("") ? 0 : this.dr[1]).ToString("###,###.###");
                        h.Aylik_kullanim = Convert.ToDouble(this.dr[2].ToString().Equals("") ? 0 : this.dr[2]).ToString("###,###.###");
                        h.Yillik_kullanim = Convert.ToDouble(this.dr[3].ToString().Equals("") ? 0 : this.dr[3]).ToString("###,###.###");
                        h.Gunluk_giris = Convert.ToDouble(this.dr[4].ToString().Equals("") ? 0 : this.dr[4]).ToString("###,###.###");
                        h.Aylik_giris = Convert.ToDouble(this.dr[5].ToString().Equals("") ? 0 : this.dr[5]).ToString("###,###.###");
                        h.Yillik_giris = Convert.ToDouble(this.dr[6].ToString().Equals("") ? 0 : this.dr[6]).ToString("###,###.###");
                        h.Stok = Convert.ToDouble(this.dr[7].ToString().Equals("") ? 0 : this.dr[7]).ToString("###,###.###");
                        hurdalar.Add(h);
                    }
                }
                catch
                {
                    throw new System.InvalidOperationException("Bağlantı gerçekleştirilirken bir hata oluştu.Tekrar deneyiniz!");
                }
            }

            this.sql = "SELECT N.HURDATANIM, " +
        "(SELECT SUM(MIKTAR) FROM URTHRK.CH_DOKUMNO_HURDA_AS400_STOK M WHERE TIP = 'GIRIS' AND TARIH=" + tarih + "  AND M.HURDATANIM = N.HURDATANIM) AS GUN," +
       " (SELECT SUM(MIKTAR) FROM URTHRK.CH_DOKUMNO_HURDA_AS400_STOK M WHERE TIP = 'GIRIS' AND  TARIH BETWEEN '" + ay_baslangic + "' AND '" + tarih + "' AND M.HURDATANIM = N.HURDATANIM)  AS AY," +
        "(SELECT SUM(MIKTAR) FROM URTHRK.CH_DOKUMNO_HURDA_AS400_STOK M WHERE TIP = 'GIRIS' AND TARIH BETWEEN '" + yil_baslangic + "' AND '" + tarih + "' AND M.HURDATANIM = N.HURDATANIM)  AS YIL," +
       " (SELECT SUM(MIKTAR) FROM URTHRK.CH_DOKUMNO_HURDA_AS400_STOK M WHERE TIP = 'STOK' AND TARIH=" + tarih + "  AND M.HURDATANIM = N.HURDATANIM) AS STOK " +
       "FROM URTHRK.CH_DOKUMNO_HURDA_AS400_STOK N GROUP BY HURDATANIM";
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            while (this.dr.Read())
            {
                Hurdalar h = new Hurdalar();
                h.Hurda_id = 1;
                h.Hurda_bilgitnm = this.dr[0].ToString();
                if (h.Hurda_bilgitnm == "CURUF SH." || h.Hurda_bilgitnm == "KABAH.STK" || h.Hurda_bilgitnm == "KIRPINTI" || h.Hurda_bilgitnm == "TOPRHSTK")
                {
                    h.Gunluk_giris = Convert.ToDouble(this.dr[1].ToString().Equals("") ? 0 : this.dr[1]).ToString("###,###.###");
                    h.Aylik_giris = Convert.ToDouble(this.dr[2].ToString().Equals("") ? 0 : this.dr[2]).ToString("###,###.###");
                    h.Yillik_giris = Convert.ToDouble(this.dr[3].ToString().Equals("") ? 0 : this.dr[3]).ToString("###,###.###");
                    h.Stok = Convert.ToDouble(this.dr[4].ToString().Equals("") ? 0 : this.dr[4]).ToString("###,###.###");

                    hurdalar.Add(h);
                }
            }


            this.sql = " SELECT " +
                      " (SELECT SUM(MIKTAR) FROM URTHRK.CH_DOKUMNO_HURDA_DATA WHERE TARIH = " + tarih + ") AS GUNLUK," +
                      " (SELECT SUM(MIKTAR) FROM URTHRK.CH_DOKUMNO_HURDA_DATA WHERE TARIH BETWEEN '" + ay_baslangic + "' AND '" + tarih + "') AS AYLIK," +
                      " (SELECT SUM(MIKTAR) FROM URTHRK.CH_DOKUMNO_HURDA_DATA WHERE TARIH BETWEEN '" + yil_baslangic + "' AND '" + tarih + "') AS YILLIK, " +
                       " (SELECT SUM(MIKTAR) FROM URTHRK.CH_DOKUMNO_HURDA_AS400_STOK WHERE TARIH = " + tarih + " AND TIP='GIRIS' ) AS GUNLUKGIRIS," +
                       " (SELECT SUM(MIKTAR) FROM URTHRK.CH_DOKUMNO_HURDA_AS400_STOK WHERE TARIH BETWEEN '" + ay_baslangic + "' AND '" + tarih + "' AND TIP='GIRIS' ) AS AYLIKGIRIS," +
                       " (SELECT SUM(MIKTAR) FROM URTHRK.CH_DOKUMNO_HURDA_AS400_STOK WHERE TARIH BETWEEN '" + yil_baslangic + "' AND '" + tarih + "' AND TIP='GIRIS' ) AS YILLIKGIRIS, " +
                        "(SELECT SUM(MIKTAR) FROM URTHRK.CH_DOKUMNO_HURDA_AS400_STOK WHERE TIP = 'STOK' AND TARIH = " + tarih + ") AS STOK " +
                      " FROM URTHRK.CH_DOKUMNO_HURDA_DATA WHERE ROWNUM = 1";
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            while (this.dr.Read())
            {
                Hurdalar h = new Hurdalar();
                h.Hurda_id = 1;
                h.Hurda_bilgitnm = "TOPLAM";
                h.Gunluk_kullanim = Convert.ToDouble(this.dr[0].ToString().Equals("") ? 0 : this.dr[0]).ToString("###,###.###");
                h.Aylik_kullanim = Convert.ToDouble(this.dr[1].ToString().Equals("") ? 0 : this.dr[1]).ToString("###,###.###");
                h.Yillik_kullanim = Convert.ToDouble(this.dr[2].ToString().Equals("") ? 0 : this.dr[2]).ToString("###,###.###");
                h.Gunluk_giris = Convert.ToDouble(this.dr[3].ToString().Equals("") ? 0 : this.dr[3]).ToString("###,###.###");
                h.Aylik_giris = Convert.ToDouble(this.dr[4].ToString().Equals("") ? 0 : this.dr[4]).ToString("###,###.###");
                h.Yillik_giris = Convert.ToDouble(this.dr[5].ToString().Equals("") ? 0 : this.dr[5]).ToString("###,###.###");
                h.Stok = Convert.ToDouble(this.dr[6].ToString().Equals("") ? 0 : this.dr[6]).ToString("###,###.###");

                hurdalar.Add(h);
            }

            this.dr.Close();
            this.dr.Dispose();

            return hurdalar;
        }
        public List<Duruslar> duruslar_data_read(string tarih)
        {
            List<Duruslar> duruslar = new List<Duruslar>();
            string yil = tarih.Substring(0, 4);
            string yil_baslangic = yil + "0101";
            string yil_ay = tarih.Substring(0, 6);
            string ay_baslangic = yil_ay + "01";

            this.sql = "SELECT " +
                     "(SELECT SUM(SURE) FROM URTHRK.CH_DOKUMNO_DURUS_DATA WHERE BASTAR = " + tarih + ") AS GUNLUK," +
                     "(SELECT SUM(SURE) FROM URTHRK.CH_DOKUMNO_DURUS_DATA WHERE BASTAR BETWEEN '" + ay_baslangic + "' AND '" + tarih + "') AS AYLIK," +
                     "(SELECT SUM(SURE) FROM URTHRK.CH_DOKUMNO_DURUS_DATA WHERE BASTAR BETWEEN '" + yil_baslangic + "' AND '" + tarih + "') AS YILLIK," +
                     "(SELECT COUNT(DNO) FROM URTHRK.CH_DOKUMNO_DURUS_DATA WHERE BASTAR = " + tarih + ") AS GUNLUKK," +
                     "(SELECT COUNT(DNO) FROM URTHRK.CH_DOKUMNO_DURUS_DATA WHERE BASTAR BETWEEN '" + ay_baslangic + "' AND '" + tarih + "') AS AYLIKK," +
                    " (SELECT COUNT(DNO) FROM URTHRK.CH_DOKUMNO_DURUS_DATA WHERE BASTAR BETWEEN '" + yil_baslangic + "' AND '" + tarih + "') AS YILLIKK " +
                    "FROM URTHRK.CH_DOKUMNO_DURUS_DATA WHERE ROWNUM = 1";

            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            while (this.dr.Read())
            {
                Duruslar d = new Duruslar();
                d.Durus_id = 1;
                d.Durus_nedeni = "TOPLAM";
                d.Gun_sure = this.dr[0].ToString();
                d.Gun_tekrar = this.dr[3].ToString();
                gun_toplam_sure = d.Gun_sure;
                d.Gun_yuzde = "100";
                d.Ay_sure = Convert.ToDouble(this.dr[1].ToString().Equals("") ? 0 : this.dr[1]).ToString("###,###.###");
                d.Ay_tekrar = Convert.ToDouble(this.dr[4].ToString().Equals("") ? 0 : this.dr[4]).ToString("###,###.###");
                ay_toplam_sure = d.Ay_sure;
                d.Ay_yuzde = "100";
                d.Yil_sure = Convert.ToDouble(this.dr[2].ToString().Equals("") ? 0 : this.dr[2]).ToString("###,###.###");
                d.Yil_tekrar = Convert.ToDouble(this.dr[5].ToString().Equals("") ? 0 : this.dr[5]).ToString("###,###.###");
                yil_toplam_sure = d.Yil_sure;
                d.Yil_yuzde = "100";
                duruslar.Add(d);
            }



            this.sql = "SELECT TRIM(TNM.TANIMI),TNM.KOD, " +
           "(SELECT SUM(DATAX.SURE) FROM URTHRK.CH_DOKUMNO_DURUS_DATA DATAX WHERE TRIM(DATAX.DURUSNEDEN) = TRIM(TNM.TANIMI) AND TRIM(DATAX.DURNEDKOD) = TRIM(TNM.KOD) AND DATAX.BASTAR  BETWEEN '" + tarih + "' AND '" + tarih + "') AS GUNLUK_TOPLAM_SURE," +
           "(SELECT COUNT(DATAX.SURE) FROM URTHRK.CH_DOKUMNO_DURUS_DATA DATAX WHERE TRIM(DATAX.DURUSNEDEN) = TRIM(TNM.TANIMI) AND TRIM(DATAX.DURNEDKOD) = TRIM(TNM.KOD) AND DATAX.BASTAR BETWEEN '" + tarih + "' AND '" + tarih + "') AS GUNLUK_TOPLAM_TEKRAR," +
           "(SELECT SUM(DATAX.SURE) FROM URTHRK.CH_DOKUMNO_DURUS_DATA DATAX WHERE TRIM(DATAX.DURUSNEDEN) = TRIM(TNM.TANIMI) AND TRIM(DATAX.DURNEDKOD) = TRIM(TNM.KOD) AND DATAX.BASTAR BETWEEN '" + ay_baslangic + "' AND '" + tarih + "') AS AYLIK_TOPLAM_SURE," +
           "(SELECT COUNT(DATAX.SURE) FROM URTHRK.CH_DOKUMNO_DURUS_DATA DATAX WHERE TRIM(DATAX.DURUSNEDEN) = TRIM(TNM.TANIMI) AND TRIM(DATAX.DURNEDKOD) = TRIM(TNM.KOD) AND DATAX.BASTAR BETWEEN '" + ay_baslangic + "' AND '" + tarih + "') AS AYLIK_TOPLAM_TEKRAR," +
           "(SELECT SUM(DATAX.SURE) FROM URTHRK.CH_DOKUMNO_DURUS_DATA DATAX WHERE TRIM(DATAX.DURUSNEDEN) = TRIM(TNM.TANIMI) AND TRIM(DATAX.DURNEDKOD) = TRIM(TNM.KOD) AND DATAX.BASTAR BETWEEN '" + yil_baslangic + "' AND '" + tarih + "') AS YILLIK_TOPLAM_SURE," +
           "(SELECT COUNT(DATAX.SURE) FROM URTHRK.CH_DOKUMNO_DURUS_DATA DATAX WHERE TRIM(DATAX.DURUSNEDEN) = TRIM(TNM.TANIMI) AND TRIM(DATAX.DURNEDKOD) = TRIM(TNM.KOD) AND DATAX.BASTAR  BETWEEN '" + yil_baslangic + "' AND '" + tarih + "') AS YILLIK_TOPLAM_TEKRAR" +
           " FROM URTHRK.ch_DURUS_tnm TNM ";
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Duruslar d = new Duruslar();
                d.Durus_nedeni = "Listelenecek kayıt bulunamadı.";
                d.Durus_id = 0;
                duruslar.Add(d);
            }
            else
            {
                while (this.dr.Read())
                {
                    Duruslar d = new Duruslar();
                    d.Durus_id = 1;
                    d.Durus_nedeni = this.dr[0].ToString();
                    d.Gun_sure = this.dr[2].ToString();
                    d.Gun_tekrar = this.dr[3].ToString();
                    if (d.Gun_sure != "" && d.Gun_sure != "0")
                    {
                        d.Gun_yuzde = ((Convert.ToInt32(d.Gun_sure) / Convert.ToDouble(gun_toplam_sure)) * 100).ToString("0.#");
                    }
                    d.Ay_sure = Convert.ToDouble(this.dr[4].ToString().Equals("") ? 0 : this.dr[4]).ToString("###,###.###");
                    d.Ay_tekrar = Convert.ToDouble(this.dr[5].ToString().Equals("") ? 0 : this.dr[5]).ToString("###,###.###");
                    if (d.Ay_sure != "" && d.Ay_sure != "0")
                    {
                        d.Ay_yuzde = ((Convert.ToDouble(d.Ay_sure) / Convert.ToDouble(ay_toplam_sure)) * 100).ToString("0.#");
                    }

                    d.Yil_sure = Convert.ToDouble(this.dr[6].ToString().Equals("") ? 0 : this.dr[6]).ToString("###,###.###");
                    d.Yil_tekrar = Convert.ToDouble(this.dr[7].ToString().Equals("") ? 0 : this.dr[7]).ToString("###,###.###");
                    if (d.Yil_sure != "" && d.Yil_sure != "0")
                    {
                        d.Yil_yuzde = ((Convert.ToDouble(d.Yil_sure) / Convert.ToDouble(yil_toplam_sure)) * 100).ToString("0.#");
                    }


                    duruslar.Add(d);
                }

            }


            this.dr.Close();
            this.dr.Dispose();

            return duruslar;
        }

        public List<Durus_ayrintisi> durus_ayrintisi_data_read(string tarih, string durus_tipi)
        {
            List<Durus_ayrintisi> durus_ayrintisi = new List<Durus_ayrintisi>();

            this.sql = "SELECT COUNT(DISTINCT(DNO)),DURUSNEDEN,ARIZANEDEN,SUM(SURE) " +
                       "FROM URTHRK.CH_DOKUMNO_DURUS_DATA " +
                       "WHERE  BASTAR = " + tarih + " AND DURUSNEDEN='" + durus_tipi.Trim() + "' GROUP BY ARIZANEDEN,DURUSNEDEN ORDER BY SUM(SURE) DESC";


            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Durus_ayrintisi da = new Durus_ayrintisi();
                da.Durus_tipi = " Listelenecek kayıt bulunamadı.";
                da.Durus_ayrintisi_id = 0;
                durus_ayrintisi.Add(da);
            }
            else
            {
                try
                {
                    while (this.dr.Read())
                    {
                        Durus_ayrintisi da = new Durus_ayrintisi();
                        da.Durus_ayrintisi_id = 1;

                        da.Durus_tipi = this.dr[1].ToString();
                        da.Ariza_nedeni = this.dr[2].ToString();
                        da.Toplam_sure = this.dr[3].ToString();
                        da.Gun_tekrar = this.dr[0].ToString();

                        durus_ayrintisi.Add(da);
                    }
                }
                catch
                {
                    throw new System.InvalidOperationException("Bağlantı gerçekleştirilirken bir hata oluştu.Tekrar deneyiniz!");
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return durus_ayrintisi;
        }

        public List<Oksijen> oksijen_data_read(string tarih)
        {
            List<Oksijen> oksijen = new List<Oksijen>();
            string yil = tarih.Substring(0, 4);
            string yil_baslangic = yil + "0101";
            string yil_ay = tarih.Substring(0, 6);
            string ay_baslangic = yil_ay + "01";
            this.sql = "SELECT TANIMI, CASE TANIMI " +
                   " when 'DILER TUKETIM' THEN(select SUM(O_TOPLAM_TUKETIM)* 1.43 from URTHRK.OKSIJEN_GIRIS WHERE TARIH = " + tarih + ")" +
                   " when 'Çolakoglu' THEN(select sum(COLAKOGLU) * 1.43 from URTHRK.OKSIJEN_GIRIS WHERE TARIH = " + tarih + " )" +
                   " when 'PIYASA' THEN(select sum(LINDE) * 1.43 from URTHRK.OKSIJEN_GIRIS WHERE TARIH =" + tarih + " ) end as GUNLUKDEGER, " +
                   " CASE TANIMI " +
                   " when 'DILER TUKETIM' THEN(select SUM(O_TOPLAM_TUKETIM)* 1.43 from URTHRK.OKSIJEN_GIRIS WHERE TARIH BETWEEN '" + ay_baslangic + "' AND '" + tarih + "')" +
                   " when 'Çolakoglu' THEN(select SUM(COLAKOGLU) * 1.43 from URTHRK.OKSIJEN_GIRIS WHERE TARIH BETWEEN '" + ay_baslangic + "' AND '" + tarih + "')" +
                   " when 'PIYASA' THEN(select SUM(LINDE) * 1.43 from URTHRK.OKSIJEN_GIRIS WHERE TARIH  BETWEEN '" + ay_baslangic + "' AND '" + tarih + "') end as AYLIKDEGER, " +
                   " CASE TANIMI " +
                   " when 'DILER TUKETIM' THEN(select SUM(O_TOPLAM_TUKETIM)* 1.43  from URTHRK.OKSIJEN_GIRIS WHERE TARIH BETWEEN '" + yil_baslangic + "' AND '" + tarih + "')" +
                   " when 'Çolakoglu' THEN(select SUM(COLAKOGLU) * 1.43 from URTHRK.OKSIJEN_GIRIS WHERE TARIH BETWEEN '" + yil_baslangic + "' AND '" + tarih + "')" +
                   " when 'PIYASA' THEN(select SUM(LINDE) * 1.43 from URTHRK.OKSIJEN_GIRIS WHERE TARIH  BETWEEN '" + yil_baslangic + "' AND '" + tarih + "') end as YILLIKDEGER" +
                   " FROM URTHRK.CH_OKSIJEN_TNM ";
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Oksijen o = new Oksijen();
                o.Oksijen_bilgitnm = "Listelenecek kayıt bulunamadı.";
                o.Oksijen_id = 0;
                oksijen.Add(o);
            }
            else
            {

                while (this.dr.Read())
                {
                    Oksijen o = new Oksijen();
                    o.Oksijen_id = 1;
                    o.Oksijen_bilgitnm = this.dr[0].ToString();
                    o.Gun_miktar = Convert.ToDouble(this.dr[1].ToString().Equals("") ? 0 : this.dr[1]).ToString("###,###.###");
                    if (o.Gun_miktar != "" && o.Gun_miktar != "0")
                    {
                        o.Gun_ton = ((Convert.ToDouble(o.Gun_miktar) / Convert.ToDouble(gunluk_uretim))).ToString("###,###.#");
                    }

                    o.Ay_miktar = Convert.ToDouble(this.dr[2].ToString().Equals("") ? 0 : this.dr[2]).ToString("###,###.###");
                    if (o.Ay_miktar != "" && o.Ay_miktar != "0")
                    {
                        o.Ay_ton = ((Convert.ToDouble(o.Ay_miktar) / Convert.ToDouble(aylik_uretim))).ToString("###,###.#");
                    }
                    o.Yil_miktar = Convert.ToDouble(this.dr[3].ToString().Equals("") ? 0 : this.dr[3]).ToString("###,###");
                    if (o.Yil_miktar != "" && o.Yil_miktar != "0")
                    {
                        o.Yil_ton = ((Convert.ToDouble(o.Yil_miktar) / Convert.ToDouble(yillik_uretim))).ToString("###,###.#");
                    }

                    oksijen.Add(o);
                }
            }

            this.sql = "SELECT (select sum(O_TOPLAM_TUKETIM)*1.43 from URTHRK.OKSIJEN_GIRIS WHERE TARIH=" + tarih + ") AS GUNTOPLAM," +
                     " (SELECT SUM(O_TOPLAM_TUKETIM) * 1.43 from URTHRK.OKSIJEN_GIRIS WHERE TARIH BETWEEN '" + ay_baslangic + "' AND '" + tarih + "')  AS AYTOPLAM," +
                     " (SELECT SUM(O_TOPLAM_TUKETIM) * 1.43 from URTHRK.OKSIJEN_GIRIS WHERE TARIH BETWEEN '" + yil_baslangic + "' AND '" + tarih + "' ) AS YILTOPLAM " +
                      "FROM URTHRK.OKSIJEN_GIRIS WHERE ROWNUM = 1";
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            while (this.dr.Read())
            {
                Oksijen o = new Oksijen();
                o.Oksijen_id = 1;
                o.Oksijen_bilgitnm = "O2 TOPLAM";
                o.Gun_miktar = Convert.ToDouble(this.dr[0].ToString().Equals("") ? 0 : this.dr[0]).ToString("###,###.###");
                if (o.Gun_miktar != "" && o.Gun_miktar != "0")
                {
                    o.Gun_ton = ((Convert.ToDouble(o.Gun_miktar) / Convert.ToDouble(gunluk_uretim))).ToString("###,###.#");
                }

                o.Ay_miktar = Convert.ToDouble(this.dr[1].ToString().Equals("") ? 0 : this.dr[1]).ToString("###,###.###");
                if (o.Ay_miktar != "" && o.Ay_miktar != "0")
                {
                    o.Ay_ton = ((Convert.ToDouble(o.Ay_miktar) / Convert.ToDouble(aylik_uretim))).ToString("###,###.#");
                }
                o.Yil_miktar = Convert.ToDouble(this.dr[2].ToString().Equals("") ? 0 : this.dr[2]).ToString("###,###");
                if (o.Yil_miktar != "" && o.Yil_miktar != "0")
                {
                    o.Yil_ton = ((Convert.ToDouble(o.Yil_miktar) / Convert.ToDouble(yillik_uretim))).ToString("###,###.#");
                }
                oksijen.Add(o);
            }

            this.dr.Close();
            this.dr.Dispose();

            return oksijen;
        }

        public List<Sarfiyatlar> sarfiyatlar_data_read_Kirecler(string tarih)
        {
       //     List<Sarfiyatlar> sarfiyatlar = new List<Sarfiyatlar>();
            string yil = tarih.Substring(0, 4);
            string yil_baslangic = yil + "0101";
            string yil_ay = tarih.Substring(0, 6);
            string ay_baslangic = yil_ay + "01";

            this.sql = "SELECT  " +
                       "(SELECT MIKTAR FROM URTHRK.CH_GVR_ALYAJ WHERE TARIH = " + tarih + " AND GRUPTANIMI='AO_Kirec') AS GUNLUK," +
                       "(SELECT SUM(MIKTAR) FROM URTHRK.CH_GVR_ALYAJ WHERE TARIH BETWEEN '" + ay_baslangic + "' AND '" + tarih + "'  AND GRUPTANIMI='AO_Kirec' ) AS AYLIK," +
                       " (SELECT SUM(MIKTAR) FROM URTHRK.CH_GVR_ALYAJ WHERE TARIH BETWEEN '" + yil_baslangic + "' AND '" + tarih + "' AND GRUPTANIMI='AO_Kirec' ) AS YILLIK, " +
                      "(SELECT MIKTAR FROM URTHRK.CH_GVR_ALYAJ WHERE TARIH = " + tarih + " AND GRUPTANIMI='PO_Kirec') AS GUNLUK," +
                     "(SELECT SUM(MIKTAR) FROM URTHRK.CH_GVR_ALYAJ WHERE TARIH BETWEEN '" + ay_baslangic + "' AND '" + tarih + "'  AND GRUPTANIMI='PO_Kirec' ) AS AYLIK," +
                      " (SELECT SUM(MIKTAR) FROM URTHRK.CH_GVR_ALYAJ WHERE TARIH BETWEEN '" + yil_baslangic + "' AND '" + tarih + "' AND GRUPTANIMI='PO_Kirec' ) AS YILLIK " +
                       "FROM URTHRK.CH_GVR_ALYAJ WHERE ROWNUM=1";
            this.cmd.CommandText = this.sql;
            this.dr1 = this.cmd.ExecuteReader();
            while (this.dr1.Read())
            {

                Sarfiyatlar e = new Sarfiyatlar();
                e.Sarfiyat_id = 1;
                e.Sarfiyat_bilgitnm = "Toplam Kireç";

                e.Gun_miktar = (Convert.ToInt32(this.dr1[0].ToString().Equals("") ? 0 : this.dr1[0]) +
                    Convert.ToInt32(this.dr1[3].ToString().Equals("") ? 0 : this.dr1[3])).ToString("###,###.###");

                e.Ay_miktar = (Convert.ToInt32(this.dr1[1].ToString().Equals("") ? 0 : this.dr1[1]) +
                    Convert.ToInt32(this.dr1[4].ToString().Equals("") ? 0 : this.dr1[4])).ToString("###,###.###");

                e.Yil_miktar = (Convert.ToInt32(this.dr1[2].ToString().Equals("") ? 0 : this.dr1[2]) +
                    Convert.ToInt32(this.dr1[5].ToString().Equals("") ? 0 : this.dr1[5])).ToString("###,###.###");

                if (e.Gun_miktar != "" && e.Gun_miktar != "0")
                {
                    e.Gun_ton = ((Convert.ToDouble(e.Gun_miktar) / Convert.ToDouble(gunluk_uretim))).ToString("0.#");
                }
                if (e.Ay_miktar != "" && e.Ay_miktar != "0")
                {
                    e.Ay_ton = (((Convert.ToDouble(e.Ay_miktar) / Convert.ToDouble(aylik_uretim)))).ToString("0.#");
                }

                if (e.Yil_miktar != "" && e.Yil_miktar != "0")
                {
                    e.Yil_ton = ((Convert.ToDouble(e.Yil_miktar) / Convert.ToDouble(yillik_uretim))).ToString("0.#");
                }

                sarfiyatlar.Add(e);
            }

          
            this.dr1.Close();
            this.dr1.Dispose();

            return sarfiyatlar;
        }

        public List<Sarfiyatlar> sarfiyatlar_data_read_Koklar(string tarih)
        {
            
            string yil = tarih.Substring(0, 4);
            string yil_baslangic = yil + "0101";
            string yil_ay = tarih.Substring(0, 6);
            string ay_baslangic = yil_ay + "01";
            
            this.sql = "SELECT  " +
                  "(SELECT MIKTAR FROM URTHRK.CH_GVR_ALYAJ WHERE TARIH = " + tarih + " AND GRUPTANIMI='AO_Kok') AS GUNLUK," +
                  "(SELECT SUM(MIKTAR) FROM URTHRK.CH_GVR_ALYAJ WHERE TARIH BETWEEN '" + ay_baslangic + "' AND '" + tarih + "'  AND GRUPTANIMI='AO_Kok' ) AS AYLIK," +
                  " (SELECT SUM(MIKTAR) FROM URTHRK.CH_GVR_ALYAJ WHERE TARIH BETWEEN '" + yil_baslangic + "' AND '" + tarih + "' AND GRUPTANIMI='AO_Kok' ) AS YILLIK, " +
                 "(SELECT MIKTAR FROM URTHRK.CH_GVR_ALYAJ WHERE TARIH = " + tarih + " AND GRUPTANIMI='PO_Kok') AS GUNLUK," +
                "(SELECT SUM(MIKTAR) FROM URTHRK.CH_GVR_ALYAJ WHERE TARIH BETWEEN '" + ay_baslangic + "' AND '" + tarih + "'  AND GRUPTANIMI='PO_Kok' ) AS AYLIK," +
                 " (SELECT SUM(MIKTAR) FROM URTHRK.CH_GVR_ALYAJ WHERE TARIH BETWEEN '" + yil_baslangic + "' AND '" + tarih + "' AND GRUPTANIMI='PO_Kok' ) AS YILLIK " +
                  "FROM URTHRK.CH_GVR_ALYAJ WHERE ROWNUM=1";
            this.cmd.CommandText = this.sql;
            this.dr1 = this.cmd.ExecuteReader();
            while (this.dr1.Read())
            {

                Sarfiyatlar e = new Sarfiyatlar();
                e.Sarfiyat_id = 1;
                e.Sarfiyat_bilgitnm = "Toplam Karbon";

                e.Gun_miktar = (Convert.ToInt32(this.dr1[0].ToString().Equals("") ? 0 : this.dr1[0]) +
                    Convert.ToInt32(this.dr1[3].ToString().Equals("") ? 0 : this.dr1[3])).ToString("###,###.###");

                e.Ay_miktar = (Convert.ToInt32(this.dr1[1].ToString().Equals("") ? 0 : this.dr1[1]) +
                    Convert.ToInt32(this.dr1[4].ToString().Equals("") ? 0 : this.dr1[4])).ToString("###,###.###");

                e.Yil_miktar = (Convert.ToInt32(this.dr1[2].ToString().Equals("") ? 0 : this.dr1[2]) +
                    Convert.ToInt32(this.dr1[5].ToString().Equals("") ? 0 : this.dr1[5])).ToString("###,###.###");

                if (e.Gun_miktar != "" && e.Gun_miktar != "0")
                {
                    e.Gun_ton = ((Convert.ToDouble(e.Gun_miktar) / Convert.ToDouble(gunluk_uretim))).ToString("0.#");
                }
                if (e.Ay_miktar != "" && e.Ay_miktar != "0")
                {
                    e.Ay_ton = (((Convert.ToDouble(e.Ay_miktar) / Convert.ToDouble(aylik_uretim)))).ToString("0.#");
                }

                if (e.Yil_miktar != "" && e.Yil_miktar != "0")
                {
                    e.Yil_ton = ((Convert.ToDouble(e.Yil_miktar) / Convert.ToDouble(yillik_uretim))).ToString("0.#");
                }

                sarfiyatlar.Add(e);
            }

            
            this.dr1.Close();
            this.dr1.Dispose();

            return sarfiyatlar;
        }
        public List<Sarfiyatlar> sarfiyatlar_data_read(string tarih)
        {
            
            string yil = tarih.Substring(0, 4);
            string yil_baslangic = yil + "0101";
            string yil_ay = tarih.Substring(0, 6);
            string ay_baslangic = yil_ay + "01";

            //this.sql = "SELECT  " +
            //           "(SELECT MIKTAR FROM URTHRK.CH_GVR_ALYAJ WHERE TARIH = " + tarih + " AND GRUPTANIMI='AO_Kirec') AS GUNLUK," +
            //           "(SELECT SUM(MIKTAR) FROM URTHRK.CH_GVR_ALYAJ WHERE TARIH BETWEEN '" + ay_baslangic + "' AND '" + tarih + "'  AND GRUPTANIMI='AO_Kirec' ) AS AYLIK," +
            //           " (SELECT SUM(MIKTAR) FROM URTHRK.CH_GVR_ALYAJ WHERE TARIH BETWEEN '" + yil_baslangic + "' AND '" + tarih + "' AND GRUPTANIMI='AO_Kirec' ) AS YILLIK, " +
            //          "(SELECT MIKTAR FROM URTHRK.CH_GVR_ALYAJ WHERE TARIH = " + tarih + " AND GRUPTANIMI='PO_Kirec') AS GUNLUK," +
            //         "(SELECT SUM(MIKTAR) FROM URTHRK.CH_GVR_ALYAJ WHERE TARIH BETWEEN '" + ay_baslangic + "' AND '" + tarih + "'  AND GRUPTANIMI='PO_Kirec' ) AS AYLIK," +
            //          " (SELECT SUM(MIKTAR) FROM URTHRK.CH_GVR_ALYAJ WHERE TARIH BETWEEN '" + yil_baslangic + "' AND '" + tarih + "' AND GRUPTANIMI='PO_Kirec' ) AS YILLIK " +
            //           "FROM URTHRK.CH_GVR_ALYAJ WHERE ROWNUM=1";
            //this.cmd.CommandText = this.sql;
            //this.dr = this.cmd.ExecuteReader();
            //while (this.dr.Read())
            //{

            //    Sarfiyatlar e = new Sarfiyatlar();
            //    e.Sarfiyat_id = 1;
            //    e.Sarfiyat_bilgitnm = "Toplam Kireç";

            //    e.Gun_miktar = (Convert.ToInt32(this.dr[0].ToString().Equals("") ? 0 : this.dr[0]) +
            //        Convert.ToInt32(this.dr[3].ToString().Equals("") ? 0 : this.dr[3])).ToString("###,###.###");

            //    e.Ay_miktar = (Convert.ToInt32(this.dr[1].ToString().Equals("") ? 0 : this.dr[1]) +
            //        Convert.ToInt32(this.dr[4].ToString().Equals("") ? 0 : this.dr[4])).ToString("###,###.###");

            //    e.Yil_miktar = (Convert.ToInt32(this.dr[2].ToString().Equals("") ? 0 : this.dr[2]) +
            //        Convert.ToInt32(this.dr[5].ToString().Equals("") ? 0 : this.dr[5])).ToString("###,###.###");

            //    if (e.Gun_miktar != "" && e.Gun_miktar != "0")
            //    {
            //        e.Gun_ton = ((Convert.ToDouble(e.Gun_miktar) / Convert.ToDouble(gunluk_uretim))).ToString("0.#");
            //    }
            //    if (e.Ay_miktar != "" && e.Ay_miktar != "0")
            //    {
            //        e.Ay_ton = (((Convert.ToDouble(e.Ay_miktar) / Convert.ToDouble(aylik_uretim)))).ToString("0.#");
            //    }

            //    if (e.Yil_miktar != "" && e.Yil_miktar != "0")
            //    {
            //        e.Yil_ton = ((Convert.ToDouble(e.Yil_miktar) / Convert.ToDouble(yillik_uretim))).ToString("0.#");
            //    }

            //    sarfiyatlar.Add(e);
            //}

            //this.sql = "SELECT  " +
            //      "(SELECT MIKTAR FROM URTHRK.CH_GVR_ALYAJ WHERE TARIH = " + tarih + " AND GRUPTANIMI='AO_Kok') AS GUNLUK," +
            //      "(SELECT SUM(MIKTAR) FROM URTHRK.CH_GVR_ALYAJ WHERE TARIH BETWEEN '" + ay_baslangic + "' AND '" + tarih + "'  AND GRUPTANIMI='AO_Kok' ) AS AYLIK," +
            //      " (SELECT SUM(MIKTAR) FROM URTHRK.CH_GVR_ALYAJ WHERE TARIH BETWEEN '" + yil_baslangic + "' AND '" + tarih + "' AND GRUPTANIMI='AO_Kok' ) AS YILLIK, " +
            //     "(SELECT MIKTAR FROM URTHRK.CH_GVR_ALYAJ WHERE TARIH = " + tarih + " AND GRUPTANIMI='PO_Kok') AS GUNLUK," +
            //    "(SELECT SUM(MIKTAR) FROM URTHRK.CH_GVR_ALYAJ WHERE TARIH BETWEEN '" + ay_baslangic + "' AND '" + tarih + "'  AND GRUPTANIMI='PO_Kok' ) AS AYLIK," +
            //     " (SELECT SUM(MIKTAR) FROM URTHRK.CH_GVR_ALYAJ WHERE TARIH BETWEEN '" + yil_baslangic + "' AND '" + tarih + "' AND GRUPTANIMI='PO_Kok' ) AS YILLIK " +
            //      "FROM URTHRK.CH_GVR_ALYAJ WHERE ROWNUM=1";
            //this.cmd.CommandText = this.sql;
            //this.dr = this.cmd.ExecuteReader();
            //while (this.dr.Read())
            //{

            //    Sarfiyatlar e = new Sarfiyatlar();
            //    e.Sarfiyat_id = 1;
            //    e.Sarfiyat_bilgitnm = "Toplam Karbon";

            //    e.Gun_miktar = (Convert.ToInt32(this.dr[0].ToString().Equals("") ? 0 : this.dr[0]) +
            //        Convert.ToInt32(this.dr[3].ToString().Equals("") ? 0 : this.dr[3])).ToString("###,###.###");

            //    e.Ay_miktar = (Convert.ToInt32(this.dr[1].ToString().Equals("") ? 0 : this.dr[1]) +
            //        Convert.ToInt32(this.dr[4].ToString().Equals("") ? 0 : this.dr[4])).ToString("###,###.###");

            //    e.Yil_miktar = (Convert.ToInt32(this.dr[2].ToString().Equals("") ? 0 : this.dr[2]) +
            //        Convert.ToInt32(this.dr[5].ToString().Equals("") ? 0 : this.dr[5])).ToString("###,###.###");

            //    if (e.Gun_miktar != "" && e.Gun_miktar != "0")
            //    {
            //        e.Gun_ton = ((Convert.ToDouble(e.Gun_miktar) / Convert.ToDouble(gunluk_uretim))).ToString("0.#");
            //    }
            //    if (e.Ay_miktar != "" && e.Ay_miktar != "0")
            //    {
            //        e.Ay_ton = (((Convert.ToDouble(e.Ay_miktar) / Convert.ToDouble(aylik_uretim)))).ToString("0.#");
            //    }

            //    if (e.Yil_miktar != "" && e.Yil_miktar != "0")
            //    {
            //        e.Yil_ton = ((Convert.ToDouble(e.Yil_miktar) / Convert.ToDouble(yillik_uretim))).ToString("0.#");
            //    }

            //    sarfiyatlar.Add(e);
            //}

            this.sql = "SELECT TNM.GRUPTANIMI, " +
                       "(SELECT GALJ.MIKTAR FROM URTHRK.CH_GVR_ALYAJ GALJ WHERE GALJ.TARIH = " + tarih + " AND TNM.GRUPTANIMI = GALJ.GRUPTANIMI) AS GUNLUK," +
                       "(SELECT SUM(GALJ.MIKTAR) FROM URTHRK.CH_GVR_ALYAJ GALJ WHERE GALJ.TARIH BETWEEN '" + ay_baslangic + "' AND '" + tarih + "'  AND TNM.GRUPTANIMI = GALJ.GRUPTANIMI ) AS AYLIK," +
                       " (SELECT SUM(GALJ.MIKTAR) FROM URTHRK.CH_GVR_ALYAJ GALJ WHERE GALJ.TARIH BETWEEN '" + yil_baslangic + "' AND '" + tarih + "' AND TNM.GRUPTANIMI = GALJ.GRUPTANIMI ) AS YILLIK " +
                       "FROM URTHRK.CH_GVR_ALYAJ_TNM TNM ";
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Sarfiyatlar s = new Sarfiyatlar();
                s.Sarfiyat_bilgitnm = "Listelenecek kayıt bulunamadı.";
                s.Sarfiyat_id = 0;
                sarfiyatlar.Add(s);
            }
            else
            {
                try
                {
                    while (this.dr.Read())
                    {
                        Sarfiyatlar e = new Sarfiyatlar();
                        e.Sarfiyat_id = 1;
                        e.Sarfiyat_bilgitnm = this.dr[0].ToString();
                          

                        e.Gun_miktar = Convert.ToDouble(this.dr[1].ToString().Equals("") ? 0 : this.dr[1]).ToString("###,###.###");
                        if (e.Gun_miktar != "" && e.Gun_miktar != "0")
                        {
                            e.Gun_ton = ((Convert.ToDouble(e.Gun_miktar) / Convert.ToDouble(gunluk_uretim))).ToString("0.#");
                        }
                        e.Ay_miktar = Convert.ToDouble(this.dr[2].ToString().Equals("") ? 0 : this.dr[2]).ToString("###,###.###");
                        if (e.Ay_miktar != "" && e.Ay_miktar != "0")
                        {
                            e.Ay_ton = (((Convert.ToDouble(e.Ay_miktar) / Convert.ToDouble(aylik_uretim)))).ToString("0.#");
                        }

                        e.Yil_miktar = Convert.ToDouble(this.dr[3].ToString().Equals("") ? 0 : this.dr[3]).ToString("###,###.###");
                        if (e.Yil_miktar != "" && e.Yil_miktar != "0")
                        {
                            e.Yil_ton = ((Convert.ToDouble(e.Yil_miktar) / Convert.ToDouble(yillik_uretim))).ToString("0.#");
                        }
                        sarfiyatlar.Add(e);

                        
                        if (e.Sarfiyat_bilgitnm == "PO_Kirec")
                        {
                            sarfiyatlar_data_read_Kirecler(tarih);
                          
                        }

                        if (e.Sarfiyat_bilgitnm == "PO_Kok")
                        {
                            sarfiyatlar_data_read_Koklar(tarih);
                          
                        }

                    }
                }
                catch
                {
                    throw new System.InvalidOperationException("Bağlantı gerçekleştirilirken bir hata oluştu.Tekrar deneyiniz!");
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return sarfiyatlar;
        }
        public List<Enerjiler> enerjiler_data_read(string tarih)
        {

            List<Enerjiler> enerjiler = new List<Enerjiler>();
            string yil = tarih.Substring(0, 4);
            string yil_baslangic = yil + "0101";
            string yil_ay = tarih.Substring(0, 6);
            string ay_baslangic = yil_ay + "01";
            this.sql = "SELECT " +
                    "(SELECT sum(DEGERI) from URTHRK.CH_DOKUMNO_ENERJI_DATA E  where E.TARIH = " + tarih + " AND BILGITNM='AO Enerji') AS GUNLUK," +
                    "(SELECT sum(DEGERI) from URTHRK.CH_DOKUMNO_ENERJI_DATA E  where E.TARIH  BETWEEN '" + ay_baslangic + "' AND '" + tarih + "' AND BILGITNM='AO Enerji') AS AYLIK," +
                    "(SELECT sum(DEGERI) from URTHRK.CH_DOKUMNO_ENERJI_DATA E  where E.TARIH  BETWEEN '" + yil_baslangic + "' AND '" + tarih + "' AND BILGITNM='AO Enerji') AS YILLIK " +
                     "FROM URTHRK.CH_DOKUMNO_ENERJI_DATA WHERE ROWNUM=1";
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Enerjiler e = new Enerjiler();
                e.Enerji_bilgitnm = "Listelenecek kayıt bulunamadı.";
                e.Enerji_id = 0;
                enerjiler.Add(e);
            }
            else
            {
                while (this.dr.Read())
                {
                    Enerjiler e = new Enerjiler();
                    e.Enerji_id = 1;
                    e.Enerji_bilgitnm = "Ark Ocağı";
                    e.Gun_kwh = Convert.ToDouble(this.dr[0].ToString().Equals("") ? 0 : this.dr[0]).ToString("###,###.###");
                    ark_gun = Convert.ToDouble(this.dr[0].ToString().Equals("") ? 0 : this.dr[0]).ToString();
                    if (e.Gun_kwh != "" && e.Gun_kwh != "0")
                    {
                        ark_Gun_kwh_ton = ((Convert.ToDouble(e.Gun_kwh) / Convert.ToDouble(gunluk_uretim))).ToString("0.#");
                        e.Gun_kwh_ton = ark_Gun_kwh_ton;

                    }
                    e.Ay_kwh = Convert.ToDouble(this.dr[1].ToString().Equals("") ? 0 : this.dr[1]).ToString("###,###.###");
                    ark_ay = Convert.ToDouble(this.dr[1].ToString().Equals("") ? 0 : this.dr[1]).ToString();
                    if (e.Ay_kwh != "" && e.Ay_kwh != "0")
                    {
                        ark_Ay_kwh_ton = (((Convert.ToDouble(e.Ay_kwh) / Convert.ToDouble(aylik_uretim)))).ToString("0.#");
                        e.Ay_kwh_ton = ark_Ay_kwh_ton;
                    }

                    e.Yil_kwh = Convert.ToDouble(this.dr[2].ToString().Equals("") ? 0 : this.dr[2]).ToString("###,###.###");
                    ark_yil = Convert.ToDouble(this.dr[2].ToString().Equals("") ? 0 : this.dr[2]).ToString();
                    if (e.Yil_kwh != "" && e.Yil_kwh != "0")
                    {
                        ark_yil_kwh_ton = ((Convert.ToDouble(e.Yil_kwh) / Convert.ToDouble(yillik_uretim))).ToString("0.#");
                        e.Yil_kwh_ton = ark_yil_kwh_ton;
                    }
                    enerjiler.Add(e);
                }


            }

            this.sql = "SELECT " +
                        "(SELECT sum(DEGERI) from URTHRK.CH_DOKUMNO_ENERJI_DATA E  where E.TARIH = " + tarih + " AND BILGITNM='PO Enerji') AS GUNLUK," +
                        "(SELECT sum(DEGERI) from URTHRK.CH_DOKUMNO_ENERJI_DATA E  where E.TARIH  BETWEEN '" + ay_baslangic + "' AND '" + tarih + "' AND BILGITNM='PO Enerji') AS AYLIK," +
                        "(SELECT sum(DEGERI) from URTHRK.CH_DOKUMNO_ENERJI_DATA E  where E.TARIH  BETWEEN '" + yil_baslangic + "' AND '" + tarih + "' AND BILGITNM='PO Enerji') AS YILLIK " +
                     "FROM URTHRK.CH_DOKUMNO_ENERJI_DATA WHERE ROWNUM=1";
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Enerjiler e = new Enerjiler();
                e.Enerji_bilgitnm = "Listelenecek kayıt bulunamadı.";
                e.Enerji_id = 0;
                enerjiler.Add(e);
            }
            else
            {
                while (this.dr.Read())
                {
                    Enerjiler e = new Enerjiler();
                    e.Enerji_id = 1;
                    e.Enerji_bilgitnm = "Pota Ocağı";
                    e.Gun_kwh = Convert.ToDouble(this.dr[0].ToString().Equals("") ? 0 : this.dr[0]).ToString("###,###.###");
                    pota_gun = Convert.ToDouble(this.dr[0].ToString().Equals("") ? 0 : this.dr[0]).ToString();
                    if (e.Gun_kwh != "" && e.Gun_kwh != "0")
                    {

                        pota_Gun_kwh_ton = ((Convert.ToDouble(e.Gun_kwh) / Convert.ToDouble(gunluk_uretim))).ToString("0.#");
                        e.Gun_kwh_ton = pota_Gun_kwh_ton;
                    }
                    e.Ay_kwh = Convert.ToDouble(this.dr[1].ToString().Equals("") ? 0 : this.dr[1]).ToString("###,###.###");
                    pota_ay = Convert.ToDouble(this.dr[1].ToString().Equals("") ? 0 : this.dr[1]).ToString();
                    if (e.Ay_kwh != "" && e.Ay_kwh != "0")
                    {
                        pota_Ay_kwh_ton = (((Convert.ToDouble(e.Ay_kwh) / Convert.ToDouble(aylik_uretim)))).ToString("0.#");
                        e.Ay_kwh_ton = pota_Ay_kwh_ton;
                    }

                    e.Yil_kwh = Convert.ToDouble(this.dr[2].ToString().Equals("") ? 0 : this.dr[2]).ToString("###,###.###");
                    pota_yil = Convert.ToDouble(this.dr[2].ToString().Equals("") ? 0 : this.dr[2]).ToString();
                    if (e.Yil_kwh != "" && e.Yil_kwh != "0")
                    {
                        pota_yil_kwh_ton = ((Convert.ToDouble(e.Yil_kwh) / Convert.ToDouble(yillik_uretim))).ToString("0.#");
                        e.Yil_kwh_ton = pota_yil_kwh_ton;
                    }
                    enerjiler.Add(e);
                }


            }

            this.sql = " SELECT " +
                      "(SELECT SUM(CATIC_O_ENERJI) FROM URTHRK.OKSIJEN_GIRIS  WHERE TARIH = " + tarih + ") AS GUNLUK," +
                     "(SELECT SUM(CATIC_O_ENERJI) FROM URTHRK.OKSIJEN_GIRIS  WHERE TARIH  BETWEEN '" + ay_baslangic + "' AND '" + tarih + "') AS AYLIK," +
                      "(SELECT SUM(CATIC_O_ENERJI) FROM URTHRK.OKSIJEN_GIRIS  WHERE TARIH BETWEEN '" + yil_baslangic + "' AND '" + tarih + "') AS YILLIK " +
                      "FROM URTHRK.OKSIJEN_GIRIS WHERE ROWNUM = 1";
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            while (this.dr.Read())
            {
                Enerjiler e = new Enerjiler();
                e.Enerji_id = 1;
                e.Enerji_bilgitnm = "OKSIJEN";
                e.Gun_kwh = Convert.ToDouble(this.dr[0].ToString().Equals("") ? 0 : this.dr[0]).ToString("###,###.###");
                oksijen_gun = Convert.ToDouble(this.dr[0].ToString().Equals("") ? 0 : this.dr[0]).ToString();
                if (e.Gun_kwh != "" && e.Gun_kwh != "0")
                {
                    oksijen_Gun_kwh_ton = ((Convert.ToDouble(e.Gun_kwh) / Convert.ToDouble(gunluk_uretim))).ToString("0.#");
                    e.Gun_kwh_ton = oksijen_Gun_kwh_ton;
                }
                e.Ay_kwh = Convert.ToDouble(this.dr[1].ToString().Equals("") ? 0 : this.dr[1]).ToString("###,###.###");
                oksijen_ay = Convert.ToDouble(this.dr[1].ToString().Equals("") ? 0 : this.dr[1]).ToString();
                if (e.Ay_kwh != "" && e.Ay_kwh != "0")
                {
                    oksijen_Ay_kwh_ton = (((Convert.ToDouble(e.Ay_kwh) / Convert.ToDouble(aylik_uretim)))).ToString("0.#");
                    e.Ay_kwh_ton = oksijen_Ay_kwh_ton;
                }

                e.Yil_kwh = Convert.ToDouble(this.dr[2].ToString().Equals("") ? 0 : this.dr[2]).ToString("###,###.###");
                oksijen_yil = Convert.ToDouble(this.dr[2].ToString().Equals("") ? 0 : this.dr[2]).ToString();
                if (e.Yil_kwh != "" && e.Yil_kwh != "0")
                {
                    oksijen_yil_kwh_ton = ((Convert.ToDouble(e.Yil_kwh) / Convert.ToDouble(yillik_uretim))).ToString("0.#");
                    e.Yil_kwh_ton = oksijen_yil_kwh_ton;
                }
                enerjiler.Add(e);
            }


            this.sql = " SELECT " +
            "(SELECT SUM(GUNLUKTUKETIM) FROM URTHRK.ELK_HHAOCH_SERVIS WHERE YER='CH_SERVIS_END' AND TARIH = " + tarih + ") AS GUNLUK," +
           "(SELECT SUM(GUNLUKTUKETIM) FROM URTHRK.ELK_HHAOCH_SERVIS WHERE YER='CH_SERVIS_END' AND TARIH  BETWEEN '" + ay_baslangic + "' AND '" + tarih + "') AS AYLIK," +
            "(SELECT SUM(GUNLUKTUKETIM) FROM URTHRK.ELK_HHAOCH_SERVIS WHERE YER='CH_SERVIS_END' AND TARIH BETWEEN '" + yil_baslangic + "' AND '" + tarih + "') AS YILLIK " +
           " FROM URTHRK.ELK_HHAOCH_SERVIS WHERE ROWNUM = 1";

            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            while (this.dr.Read())
            {
                Enerjiler e = new Enerjiler();
                e.Enerji_id = 1;
                e.Enerji_bilgitnm = "CH.SERVİS";
                int ch_servis_gun = Convert.ToInt32(this.dr[0].ToString().Equals("") ? 0 : this.dr[0]);
                double ch_servis_toplam_gun = ch_servis_gun;

                e.Gun_kwh = (ch_servis_toplam_gun).ToString("###,###.###");
                ch_servis_gun_global = ch_servis_toplam_gun.ToString();
                if (e.Gun_kwh != "" && e.Gun_kwh != "0")
                {
                    ch_servis_Gun_kwh_ton = ((Convert.ToDouble(e.Gun_kwh) / Convert.ToDouble(gunluk_uretim))).ToString("0.#");
                    e.Gun_kwh_ton = ch_servis_Gun_kwh_ton;
                }
                int ch_servis_ay = Convert.ToInt32(this.dr[1].ToString().Equals("") ? 0 : this.dr[1]);
                double ch_servis_toplam_ay = ch_servis_ay;
                e.Ay_kwh = (ch_servis_toplam_ay).ToString("###,###");
                ch_servis_ay_global = ch_servis_toplam_ay.ToString();
                if (e.Ay_kwh != "" && e.Ay_kwh != "0")
                {
                    ch_servis_Ay_kwh_ton = (((Convert.ToDouble(e.Ay_kwh) / Convert.ToDouble(aylik_uretim)))).ToString("0.#");
                    e.Ay_kwh_ton = ch_servis_Ay_kwh_ton;
                }
                int ch_servis_yil = Convert.ToInt32(this.dr[2].ToString().Equals("") ? 0 : this.dr[2]);
                double ch_servis_toplam_yil = ch_servis_yil;
                e.Yil_kwh = (ch_servis_toplam_yil).ToString("###,###");
                ch_servis_yil_global = ch_servis_toplam_yil.ToString();
                if (e.Yil_kwh != "" && e.Yil_kwh != "0")
                {
                    ch_servis_yil_kwh_ton = ((Convert.ToDouble(e.Yil_kwh) / Convert.ToDouble(yillik_uretim))).ToString("0.#");
                    e.Yil_kwh_ton = ch_servis_yil_kwh_ton;
                }
                enerjiler.Add(e);
            }



            this.sql = " SELECT " +
            "(SELECT SUM(GUNLUKTUKETIM) FROM URTHRK.ELK_TOZTUTMA WHERE TARIH = " + tarih + ") AS GUNLUK," +
           "(SELECT SUM(GUNLUKTUKETIM) FROM URTHRK.ELK_TOZTUTMA WHERE TARIH  BETWEEN '" + ay_baslangic + "' AND '" + tarih + "') AS AYLIK," +
            "(SELECT SUM(GUNLUKTUKETIM) FROM URTHRK.ELK_TOZTUTMA WHERE TARIH BETWEEN '" + yil_baslangic + "' AND '" + tarih + "') AS YILLIK " +
            "FROM URTHRK.ELK_TOZTUTMA  WHERE ROWNUM = 1";
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            while (this.dr.Read())
            {

                Gun_kwh_elktoztutma = this.dr[0].ToString();
                Ay_kwh_elktoztutma = this.dr[1].ToString();
                Yil_kwh_elktoztutma = this.dr[2].ToString();
            }

            this.sql = " SELECT " +
            "(SELECT SUM(GUNLUKTUKETIM) FROM URTHRK.ELKOKSIJEN WHERE TARIH = " + tarih + " AND YER='FDCFan') AS GUNLUK," +
           "(SELECT SUM(GUNLUKTUKETIM) FROM URTHRK.ELKOKSIJEN WHERE TARIH  BETWEEN '" + ay_baslangic + "' AND '" + tarih + "' AND YER='FDCFan') AS AYLIK," +
            "(SELECT SUM(GUNLUKTUKETIM) FROM URTHRK.ELKOKSIJEN WHERE TARIH BETWEEN '" + yil_baslangic + "' AND '" + tarih + "' AND YER='FDCFan') AS YILLIK " +
            "FROM URTHRK.ELKOKSIJEN WHERE ROWNUM = 1";
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            while (this.dr.Read())
            {
                Enerjiler e = new Enerjiler();
                e.Enerji_id = 1;
                string Gun_kwh_elkoksijen = this.dr[0].ToString();
                string Ay_kwh_elkoksijen = this.dr[1].ToString();
                string Yil_kwh_elkoksijen = this.dr[2].ToString();

                e.Enerji_bilgitnm = "TOZ TUTMA";
                if (Gun_kwh_elkoksijen != "")
                {
                    e.Gun_kwh = (Convert.ToInt32(Gun_kwh_elktoztutma) + Convert.ToInt32(Gun_kwh_elkoksijen)).ToString("###,###.###");
                    toztutma_gun = (Convert.ToInt32(Gun_kwh_elktoztutma) + Convert.ToInt32(Gun_kwh_elkoksijen)).ToString();
                    if (e.Gun_kwh != "" && e.Gun_kwh != "0")
                    {
                        toztutma_Gun_kwh_ton = ((Convert.ToDouble(e.Gun_kwh) / Convert.ToDouble(gunluk_uretim))).ToString("0.#");
                        e.Gun_kwh_ton = toztutma_Gun_kwh_ton;
                    }
                }
                if (Ay_kwh_elkoksijen != "")
                {
                    e.Ay_kwh = (Convert.ToInt32(Ay_kwh_elktoztutma) + Convert.ToInt32(Ay_kwh_elkoksijen)).ToString("###,###.###");
                    toztutma_ay = (Convert.ToInt32(Ay_kwh_elktoztutma) + Convert.ToInt32(Ay_kwh_elkoksijen)).ToString();
                    if (e.Ay_kwh != "" && e.Ay_kwh != "0")
                    {

                        toztutma_Ay_kwh_ton = (((Convert.ToDouble(e.Ay_kwh) / Convert.ToDouble(aylik_uretim)))).ToString("0.#");
                        e.Ay_kwh_ton = toztutma_Ay_kwh_ton;
                    }
                }
                if (Yil_kwh_elkoksijen != "")
                {
                    e.Yil_kwh = (Convert.ToInt32(Yil_kwh_elktoztutma) + Convert.ToInt32(Yil_kwh_elkoksijen)).ToString("###,###.###");
                    toztutma_yil = (Convert.ToInt32(Yil_kwh_elktoztutma) + Convert.ToInt32(Yil_kwh_elkoksijen)).ToString();
                    if (e.Yil_kwh != "" && e.Yil_kwh != "0")
                    {
                        toztutma_yil_kwh_ton = ((Convert.ToDouble(e.Yil_kwh) / Convert.ToDouble(yillik_uretim))).ToString("0.#");
                        e.Yil_kwh_ton = toztutma_yil_kwh_ton;
                    }
                }


                enerjiler.Add(e);
            }

            this.sql = "SELECT " +
                "(SELECT SUM(GUNLUKTUKETIM) FROM URTHRK.ELK_HHAOCH_SERVIS WHERE TARIH = " + tarih + " AND YER = 'HaddeKompA') AS HADDEA_gunluk," +
                "(SELECT SUM(GUNLUKTUKETIM) FROM URTHRK.ELK_HHAOCH_SERVIS WHERE TARIH =" + tarih + " AND YER = 'HaddeKompB') AS HADDEB_gunluk," +
                 "(SELECT SUM(GUNLUKTUKETIM) FROM URTHRK.ELK_HHAOCH_SERVIS WHERE TARIH =" + tarih + " AND YER = 'JoyHavaKomp') AS joykomp_gunluk," +
                "(SELECT SUM(GUNLUKTUKETIM) FROM URTHRK.ELK_HHAOCH_SERVIS WHERE TARIH =" + tarih + " AND YER = 'ToplamKomp') AS toplamkomp_gunluk," +
                " (SELECT SUM(GUNLUKTUKETIM) FROM URTHRK.ELK_HHAOCH_SERVIS WHERE TARIH BETWEEN '" + ay_baslangic + "' AND '" + tarih + "' AND YER = 'HaddeKompA') AS HADDEA_aylik," +
                "(SELECT SUM(GUNLUKTUKETIM) FROM URTHRK.ELK_HHAOCH_SERVIS WHERE TARIH BETWEEN '" + ay_baslangic + "' AND '" + tarih + "' AND YER = 'HaddeKompB') AS HADDEB_aylik," +
                "(SELECT SUM(GUNLUKTUKETIM) FROM URTHRK.ELK_HHAOCH_SERVIS WHERE TARIH BETWEEN '" + ay_baslangic + "' AND '" + tarih + "' AND YER = 'JoyHavaKomp') AS joykomp_aylik," +
               " (SELECT SUM(GUNLUKTUKETIM) FROM URTHRK.ELK_HHAOCH_SERVIS WHERE TARIH BETWEEN '" + ay_baslangic + "' AND '" + tarih + "' AND YER = 'ToplamKomp') AS toplamkomp_aylik," +
               "(SELECT SUM(GUNLUKTUKETIM) FROM URTHRK.ELK_HHAOCH_SERVIS WHERE TARIH BETWEEN '" + yil_baslangic + "' AND '" + tarih + "' AND YER = 'HaddeKompA') AS HADDEA_yillik," +
              " (SELECT SUM(GUNLUKTUKETIM) FROM URTHRK.ELK_HHAOCH_SERVIS WHERE TARIH BETWEEN '" + yil_baslangic + "' AND '" + tarih + "' AND YER = 'HaddeKompB') AS HADDEB_yillik," +
               "(SELECT SUM(GUNLUKTUKETIM) FROM URTHRK.ELK_HHAOCH_SERVIS WHERE TARIH BETWEEN '" + yil_baslangic + "' AND '" + tarih + "' AND YER = 'JoyHavaKomp') AS joykomp_yillik, " +
              " (SELECT SUM(GUNLUKTUKETIM) FROM URTHRK.ELK_HHAOCH_SERVIS WHERE TARIH BETWEEN '" + yil_baslangic + "' AND '" + tarih + "' AND YER = 'ToplamKomp') AS toplamkomp_yillik, " +
               "(SELECT SUM(GUNLUKTUKETIM) FROM URTHRK.ELK_HHAOCH_SERVIS WHERE TARIH =" + tarih + " AND YER = 'JoyKompPompa') AS joykomp_pompa_gunluk," +
               "(SELECT SUM(GUNLUKTUKETIM) FROM URTHRK.ELK_HHAOCH_SERVIS WHERE TARIH BETWEEN '" + ay_baslangic + "' AND '" + tarih + "' AND YER = 'JoyKompPompa') AS joykomp_pompa_aylik," +
               "(SELECT SUM(GUNLUKTUKETIM) FROM URTHRK.ELK_HHAOCH_SERVIS WHERE TARIH BETWEEN '" + yil_baslangic + "' AND '" + tarih + "' AND YER = 'JoyKompPompa') AS joykomp_pompa_yillik " +

               "FROM URTHRK.ELK_HHAOCH_SERVIS WHERE ROWNUM = 1";
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();

            while (this.dr.Read())
            {
                Enerjiler e = new Enerjiler();
                e.Enerji_id = 1;

                e.Enerji_bilgitnm = "HAVA KOMP";
                if (this.dr[0].ToString() != "" && this.dr[1].ToString() != "")
                {
                    int hhkompresor_gun_toplam = Convert.ToInt32(this.dr[0].ToString().Equals("") ? "0" : this.dr[0].ToString()) +
                                                 Convert.ToInt32(this.dr[1].ToString().Equals("") ? "0" : this.dr[1].ToString()); //gunluk hhkompresora ve hhkompresorb 

                    int toplamkompresor_gun = Convert.ToInt32(this.dr[3].ToString()) +
                         Convert.ToInt32(this.dr[2].ToString().Equals("") ? "0" : this.dr[2].ToString()) +
                         Convert.ToInt32(this.dr[12].ToString().Equals("") ? "0" : this.dr[12].ToString());

                    e.Gun_kwh = (toplamkompresor_gun - hhkompresor_gun_toplam).ToString("###,###.###");
                    hava_komp_gun = (toplamkompresor_gun - hhkompresor_gun_toplam).ToString();

                    if (e.Gun_kwh != "" && e.Gun_kwh != "0")
                    {
                        hava_komp_Gun_kwh_ton = ((Convert.ToDouble(e.Gun_kwh) / Convert.ToDouble(gunluk_uretim))).ToString("0.#");
                        e.Gun_kwh_ton = hava_komp_Gun_kwh_ton;
                    }
                }
                int hhkompresor_ay_toplam = Convert.ToInt32(this.dr[4].ToString().Equals("") ? "0" : this.dr[4].ToString()) +
                                            Convert.ToInt32(this.dr[5].ToString().Equals("") ? "0" : this.dr[5].ToString()); //aylik hhkompresora ve hhkompresorb

                int hhkompresor_yil_toplam = Convert.ToInt32(this.dr[8].ToString().Equals("") ? "0" : this.dr[8].ToString()) +
                                            Convert.ToInt32(this.dr[9].ToString().Equals("") ? "0" : this.dr[9].ToString()); //yillik hhkompresora ve hhkompresorb


                int toplamkompresor_ay = Convert.ToInt32(this.dr[7].ToString().Equals("") ? "0" : this.dr[7].ToString()) +
                                         Convert.ToInt32(this.dr[6].ToString().Equals("") ? "0" : this.dr[6].ToString()) +
                                         Convert.ToInt32(this.dr[13].ToString().Equals("") ? "0" : this.dr[13].ToString());

                int toplamkompresor_yil = Convert.ToInt32(this.dr[11].ToString().Equals("") ? "0" : this.dr[11].ToString()) +
                                          Convert.ToInt32(this.dr[10].ToString().Equals("") ? "0" : this.dr[10].ToString()) +
                                          Convert.ToInt32(this.dr[14].ToString().Equals("") ? "0" : this.dr[14].ToString());
                int deneme = Convert.ToInt32(this.dr[10].ToString().Equals("") ? "0" : this.dr[10].ToString());

                e.Ay_kwh = (toplamkompresor_ay - hhkompresor_ay_toplam).ToString("###,###.###");
                hava_komp_ay = (toplamkompresor_ay - hhkompresor_ay_toplam).ToString();

                e.Yil_kwh = (toplamkompresor_yil - hhkompresor_yil_toplam).ToString("###,###.###");

                hava_komp_yil = (toplamkompresor_yil - hhkompresor_yil_toplam).ToString();

                if (e.Ay_kwh != "" && e.Ay_kwh != "0")
                {
                    hava_komp_Ay_kwh_ton = (((Convert.ToDouble(e.Ay_kwh) / Convert.ToDouble(aylik_uretim)))).ToString("0.#");
                    e.Ay_kwh_ton = hava_komp_Ay_kwh_ton;
                }
                if (e.Yil_kwh != "" && e.Yil_kwh != "0")
                {
                    hava_komp_yil_kwh_ton = ((Convert.ToDouble(e.Yil_kwh) / Convert.ToDouble(yillik_uretim))).ToString("0.#");
                    e.Yil_kwh_ton = hava_komp_yil_kwh_ton;
                }
                enerjiler.Add(e);
            }
            this.sql = "SELECT(SELECT SUM(GUNLUKTUKETIM) FROM URTHRK.ELKOKSIJEN WHERE TARIH = " + tarih + " AND YER = 'Pompa') AS gunluk," +
               " (SELECT SUM(GUNLUKTUKETIM) FROM URTHRK.ELKOKSIJEN WHERE TARIH BETWEEN '" + ay_baslangic + "' AND '" + tarih + "' AND YER = 'Pompa') AS aylik," +
              "  (SELECT SUM(GUNLUKTUKETIM) FROM URTHRK.ELKOKSIJEN WHERE TARIH BETWEEN '" + yil_baslangic + "' AND '" + tarih + "' AND YER = 'Pompa') AS yillik " +
               "FROM URTHRK.ELKOKSIJEN WHERE ROWNUM = 1";
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            while (this.dr.Read())
            {
                Enerjiler e = new Enerjiler();
                e.Enerji_id = 1;

                e.Enerji_bilgitnm = "SU POMPASI";
                e.Gun_kwh = Convert.ToDouble(this.dr[0].ToString().Equals("") ? 0 : this.dr[0]).ToString("###,###.###");
                su_pomp_gun = Convert.ToDouble(this.dr[0].ToString().Equals("") ? 0 : this.dr[0]).ToString();
                e.Ay_kwh = Convert.ToDouble(this.dr[1].ToString().Equals("") ? 0 : this.dr[1]).ToString("###,###.###");
                su_pomp_ay = Convert.ToDouble(this.dr[1].ToString().Equals("") ? 0 : this.dr[1]).ToString();
                e.Yil_kwh = Convert.ToDouble(this.dr[2].ToString().Equals("") ? 0 : this.dr[2]).ToString("###,###.###");
                su_pomp_yil = Convert.ToDouble(this.dr[2].ToString().Equals("") ? 0 : this.dr[2]).ToString();
                if (e.Gun_kwh != "" && e.Gun_kwh != "0")
                {
                    su_pomp_Gun_kwh_ton = ((Convert.ToDouble(e.Gun_kwh) / Convert.ToDouble(gunluk_uretim))).ToString("0.#");
                    e.Gun_kwh_ton = su_pomp_Gun_kwh_ton;
                }
                if (e.Ay_kwh != "" && e.Ay_kwh != "0")
                {
                    su_pomp_Ay_kwh_ton = (((Convert.ToDouble(e.Ay_kwh) / Convert.ToDouble(aylik_uretim)))).ToString("0.#");
                    e.Ay_kwh_ton = su_pomp_Ay_kwh_ton;
                }
                if (e.Yil_kwh != "" && e.Yil_kwh != "0")
                {
                    su_pomp_yil_kwh_ton = ((Convert.ToDouble(e.Yil_kwh) / Convert.ToDouble(yillik_uretim))).ToString("0.#");
                    e.Yil_kwh_ton = su_pomp_yil_kwh_ton;
                }
                enerjiler.Add(e);
            }
            this.sql = "SELECT(SELECT SUM(GUNLUKTUKETIM) FROM URTHRK.ELK_HHAOCH_SERVIS WHERE TARIH = " + tarih + " AND YER = 'DenizSuyu') AS gun_denizsuyu," +
                "(SELECT SUM(GUNLUKTUKETIM) FROM URTHRK.ELK_HHAOCH_SERVIS WHERE TARIH =" + tarih + " AND YER = 'HurdaEleme') AS gun_hurdaeleme," +
               "(SELECT SUM(GUNLUKTUKETIM) FROM URTHRK.ELK_HHAOCH_SERVIS WHERE TARIH BETWEEN '" + ay_baslangic + "' AND '" + tarih + "' AND YER = 'DenizSuyu') AS ay_denizsuyu," +
               "(SELECT SUM(GUNLUKTUKETIM) FROM URTHRK.ELK_HHAOCH_SERVIS WHERE TARIH BETWEEN '" + ay_baslangic + "' AND '" + tarih + "' AND YER = 'HurdaEleme') AS ay_hurdaeleme," +
               "(SELECT SUM(GUNLUKTUKETIM) FROM URTHRK.ELK_HHAOCH_SERVIS WHERE TARIH BETWEEN '" + yil_baslangic + "' AND '" + tarih + "' AND YER = 'DenizSuyu') AS yil_denizsuyu ," +
               "(SELECT SUM(GUNLUKTUKETIM) FROM URTHRK.ELK_HHAOCH_SERVIS WHERE TARIH BETWEEN '" + yil_baslangic + "' AND '" + tarih + "' AND YER = 'HurdaEleme') AS yil_hurdaeleme " +
                "FROM URTHRK.ELK_HHAOCH_SERVIS WHERE ROWNUM = 1";
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            while (this.dr.Read())
            {
                Enerjiler e = new Enerjiler();
                e.Enerji_id = 1;

                e.Enerji_bilgitnm = "DENİZ SUYU";
                if (this.dr[0].ToString() != "" && this.dr[1].ToString() != "")
                {
                    int chdenizsuyu_gun = Convert.ToInt32(this.dr[0].ToString()) - Convert.ToInt32(this.dr[1].ToString()); // gun_denizsuyu - gun_hurdaeleme
                    e.Gun_kwh = (chdenizsuyu_gun * 0.49).ToString("###,###");
                    denizsuyu_gun = (chdenizsuyu_gun * 0.49).ToString();
                    if (e.Gun_kwh != "" && e.Gun_kwh != "0")
                    {
                        denizsuyu_Gun_kwh_ton = ((Convert.ToDouble(e.Gun_kwh) / Convert.ToDouble(gunluk_uretim))).ToString("0.#");
                        e.Gun_kwh_ton = denizsuyu_Gun_kwh_ton;
                    }
                }

                int chdenizsuyu_ay = Convert.ToInt32(this.dr[2].ToString().Equals("") ? "0" : this.dr[2].ToString()) -
                                     Convert.ToInt32(this.dr[3].ToString().Equals("") ? "0" : this.dr[3].ToString()); //ay_denizsuyu -ay_hurdaeleme

                int chdenizsuyu_yil = Convert.ToInt32(this.dr[4].ToString().Equals("") ? "0" : this.dr[4].ToString()) -
                                     Convert.ToInt32(this.dr[5].ToString().Equals("") ? "0" : this.dr[5].ToString());  // yil_denizsuyu - yil_hurdaeleme


                e.Ay_kwh = (chdenizsuyu_ay * 0.49).ToString("###,###");
                denizsuyu_ay = (chdenizsuyu_ay * 0.49).ToString();
                e.Yil_kwh = (chdenizsuyu_yil * 0.49).ToString("###,###");
                denizsuyu_yil = (chdenizsuyu_yil * 0.49).ToString();

                if (e.Ay_kwh != "" && e.Ay_kwh != "0")
                {
                    denizsuyu_Ay_kwh_ton = (((Convert.ToDouble(e.Ay_kwh) / Convert.ToDouble(aylik_uretim)))).ToString("0.#");
                    e.Ay_kwh_ton = denizsuyu_Ay_kwh_ton;
                }
                if (e.Yil_kwh != "" && e.Yil_kwh != "0")
                {
                    denizsuyu_yil_kwh_ton = ((Convert.ToDouble(e.Yil_kwh) / Convert.ToDouble(yillik_uretim))).ToString("0.#");
                    e.Yil_kwh_ton = denizsuyu_yil_kwh_ton;
                }
                enerjiler.Add(e);
            }
            this.sql = "SELECT " +
               "(SELECT SUM(GUNLUKTUKETIM) FROM URTHRK.ELK_HHAOCH_SERVIS WHERE TARIH =" + tarih + " AND YER = 'HurdaEleme') AS gun_hurdaeleme," +
               "(SELECT SUM(GUNLUKTUKETIM) FROM URTHRK.ELK_HHAOCH_SERVIS WHERE TARIH BETWEEN '" + ay_baslangic + "' AND '" + tarih + "' AND YER = 'HurdaEleme') AS ay_hurdaeleme," +
               "(SELECT SUM(GUNLUKTUKETIM) FROM URTHRK.ELK_HHAOCH_SERVIS WHERE TARIH BETWEEN '" + yil_baslangic + "' AND '" + tarih + "' AND YER = 'HurdaEleme') AS yil_hurdaeleme " +
               "FROM URTHRK.ELK_HHAOCH_SERVIS WHERE ROWNUM = 1";
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            while (this.dr.Read())
            {
                Enerjiler e = new Enerjiler();
                e.Enerji_id = 1;

                e.Enerji_bilgitnm = "HURDA ELEME";

                e.Gun_kwh = Convert.ToDouble(this.dr[0].ToString().Equals("") ? 0.0 : this.dr[0]).ToString("###,###.###");
                hurda_eleme_gun = Convert.ToDouble(this.dr[0].ToString().Equals("") ? 0.0 : this.dr[0]).ToString();
                e.Ay_kwh = Convert.ToDouble(this.dr[1].ToString().Equals("") ? 0.0 : this.dr[1]).ToString("###,###.###");
                hurda_eleme_ay = Convert.ToDouble(this.dr[1].ToString().Equals("") ? 0.0 : this.dr[1]).ToString();
                e.Yil_kwh = Convert.ToDouble(this.dr[2].ToString().Equals("") ? 0.0 : this.dr[2]).ToString("###,###.###");
                hurda_eleme_yil = Convert.ToDouble(this.dr[2].ToString().Equals("") ? 0.0 : this.dr[2]).ToString();
                if (e.Gun_kwh != "" && e.Gun_kwh != "0")
                {
                    hurda_eleme_Gun_kwh_ton = ((Convert.ToDouble(e.Gun_kwh) / Convert.ToDouble(gunluk_uretim))).ToString("0.#");
                    e.Gun_kwh_ton = hurda_eleme_Gun_kwh_ton;
                }
                if (e.Ay_kwh != "" && e.Ay_kwh != "0")
                {
                    hurda_eleme_Ay_kwh_ton = (((Convert.ToDouble(e.Ay_kwh) / Convert.ToDouble(aylik_uretim)))).ToString("0.#");
                    e.Ay_kwh_ton = hurda_eleme_Ay_kwh_ton;
                }
                if (e.Yil_kwh != "" && e.Yil_kwh != "0")
                {
                    hurda_eleme_yil_kwh_ton = ((Convert.ToDouble(e.Yil_kwh) / Convert.ToDouble(yillik_uretim))).ToString("0.#");
                    e.Yil_kwh_ton = hurda_eleme_yil_kwh_ton;
                }
                enerjiler.Add(e);
            }

            Enerjiler enerji = new Enerjiler();
            enerji.Enerji_id = 1;
            enerji.Enerji_bilgitnm = "TOPLAM";
            enerji.Gun_kwh = (Convert.ToInt32(ark_gun) + Convert.ToInt32(pota_gun) +
                              Convert.ToInt32(oksijen_gun) + Convert.ToDouble(ch_servis_gun_global) +
                              Convert.ToInt32(toztutma_gun) + Convert.ToInt32(hava_komp_gun) +
                              Convert.ToInt32(su_pomp_gun) + Convert.ToDouble(denizsuyu_gun) +
                              Convert.ToInt32(hurda_eleme_gun)).ToString("###,###");

            enerji.Ay_kwh = (Convert.ToInt32(ark_ay) + Convert.ToInt32(pota_ay) +
                    Convert.ToInt32(oksijen_ay) + Convert.ToDouble(ch_servis_ay_global) +
                    Convert.ToInt32(toztutma_ay) + Convert.ToInt32(hava_komp_ay) +
                    Convert.ToInt32(su_pomp_ay) + Convert.ToDouble(denizsuyu_ay) +
                    Convert.ToInt32(hurda_eleme_ay)).ToString("###,###");

            enerji.Yil_kwh = (Convert.ToInt32(ark_yil) + Convert.ToInt32(pota_yil) +
                Convert.ToInt32(oksijen_yil) + Convert.ToDouble(ch_servis_yil_global) +
                Convert.ToInt32(toztutma_yil) + Convert.ToInt32(hava_komp_yil) +
                Convert.ToInt32(su_pomp_yil) + Convert.ToDouble(denizsuyu_yil) +
                Convert.ToInt32(hurda_eleme_yil)).ToString("###,###");

            enerji.Gun_kwh_ton = (Convert.ToDouble(ark_Gun_kwh_ton) + Convert.ToDouble(pota_Gun_kwh_ton) +
                Convert.ToDouble(oksijen_Gun_kwh_ton) + Convert.ToDouble(ch_servis_Gun_kwh_ton) +
                Convert.ToDouble(toztutma_Gun_kwh_ton) + Convert.ToDouble(hava_komp_Gun_kwh_ton) +
                Convert.ToDouble(su_pomp_Gun_kwh_ton) + Convert.ToDouble(denizsuyu_Gun_kwh_ton) +
                Convert.ToDouble(hurda_eleme_Gun_kwh_ton)).ToString();

            enerji.Ay_kwh_ton = (Convert.ToDouble(ark_Ay_kwh_ton) + Convert.ToDouble(pota_Ay_kwh_ton) +
               Convert.ToDouble(oksijen_Ay_kwh_ton) + Convert.ToDouble(ch_servis_Ay_kwh_ton) +
               Convert.ToDouble(toztutma_Ay_kwh_ton) + Convert.ToDouble(hava_komp_Ay_kwh_ton) +
               Convert.ToDouble(su_pomp_Ay_kwh_ton) + Convert.ToDouble(denizsuyu_Ay_kwh_ton) +
               Convert.ToDouble(hurda_eleme_Ay_kwh_ton)).ToString();

            enerji.Yil_kwh_ton = (Convert.ToDouble(ark_yil_kwh_ton) + Convert.ToDouble(pota_yil_kwh_ton) +
               Convert.ToDouble(oksijen_yil_kwh_ton) + Convert.ToDouble(ch_servis_yil_kwh_ton) +
               Convert.ToDouble(toztutma_yil_kwh_ton) + Convert.ToDouble(hava_komp_yil_kwh_ton) +
               Convert.ToDouble(su_pomp_yil_kwh_ton) + Convert.ToDouble(denizsuyu_yil_kwh_ton) +
               Convert.ToDouble(hurda_eleme_yil_kwh_ton)).ToString();

            enerjiler.Add(enerji);




            this.dr.Close();
            this.dr.Dispose();

            return enerjiler;
        }
        public void Connect()
        {
            if (this.conn.State != System.Data.ConnectionState.Open)
            {
                try
                {
                    this.conn.Open();
                    this.cmd.Connection = this.conn;
                }
                catch
                {
                    throw new System.InvalidOperationException("Veri Tabani baglantisi kurulamiyor!");
                }
            }
        }
        public void Disconnect()
        {
            if (this.conn.State == System.Data.ConnectionState.Open)
            {
                this.conn.Close();
            }
        }


    }
}
