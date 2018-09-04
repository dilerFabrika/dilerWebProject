using diler.Entity;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace diler.Dal
{
    public class Haddehane_rapor_db
    {

        OracleConnection conn, conn2;
        string connetionString, sql;
        OracleCommand cmd;
        OracleDataReader dr;
        public string tarih_parse;
        string yuvarlak_gunluk, yuvarlak_aylik, yuvarlak_yillik, kisa_gunluk, kisa_aylik, kisa_yillik, gun_toplam_tekrar_hh, ay_toplam_tekrar_hh, yil_toplam_tekrar_hh;

        public Haddehane_rapor_db()
        {
            try
            {
                this.connetionString = @"Data Source=(DESCRIPTION=" +
                    "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.198.191)(PORT=1521)))" +
                    "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=DLRORA)));" +
                    "User Id=URTHRK;Password=URTHRK;";
                this.cmd = new OracleCommand();
                this.conn = new OracleConnection(this.connetionString);
                this.conn2 = new OracleConnection(this.connetionString);
            }
            catch
            {
                throw new System.InvalidOperationException("Veri tabanı bağlantısı gerçekleştirilemiyor.Tekrar deneyiniz");
            }



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
                    throw new System.InvalidOperationException("Veri Tabani baglantısı kurulamıyor!");
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


        /** Haddehane **/
        public List<Genel_uretim> genel_uretim_data_read(string tarih)
        {
            List<Genel_uretim> genel_uretimler = new List<Genel_uretim>();
            string yil = tarih.Substring(0, 4);
            string yil_baslangic = yil + "0101";
            string yil_ay = tarih.Substring(0, 6);
            string su_anki_ay_gunu = tarih.Substring(6, 2); // ayın kaçıncı günü
            string ay = tarih.Substring(4, 2);
            string ay_baslangic = yil_ay + "01";

            DateTime baslangictarihi = new DateTime(Convert.ToInt32(yil), 01, 01);
            DateTime bitistarihi = new DateTime(Convert.ToInt32(yil), Convert.ToInt32(ay), Convert.ToInt32(su_anki_ay_gunu));

            TimeSpan arasindakigunler = bitistarihi - baslangictarihi;
            double days = arasindakigunler.TotalDays + 1;

            this.sql = "SELECT " +
             "(SELECT SUM(KUTUKTONAJI)+SUM(EGRIKTKTON) FROM URTHRK.VERIM WHERE TARIH = " + tarih + ") AS GUN, " +
             "(SELECT SUM(KUTUKTONAJI)+SUM(EGRIKTKTON) FROM URTHRK.VERIM WHERE TARIH BETWEEN '" + ay_baslangic + "' AND '" + tarih + "') AS AY, " +
             "(SELECT SUM(KUTUKTONAJI)+SUM(EGRIKTKTON) FROM URTHRK.VERIM WHERE TARIH BETWEEN '" + yil_baslangic + "' AND '" + tarih + "') AS YIL " +
             "FROM URTHRK.VERIM WHERE ROWNUM = 1";
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();

            while (this.dr.Read())
            {
                Genel_uretim gu = new Genel_uretim();
                gu.Gu_id = 1;
                gu.Gu_bilgitnm = "Kütük";
                gu.Gu_gunluk = Convert.ToDouble(this.dr[0].ToString().Equals("") ? 0 : this.dr[0]).ToString("###,###.##");
                gu.Gu_gunluk_ort = "0";
                gu.Gu_aylik = Convert.ToDouble(this.dr[1].ToString().Equals("") ? 0 : this.dr[1]).ToString("###,###.##");
                gu.Gu_aylik_ort = (Convert.ToDouble(gu.Gu_aylik) / Convert.ToDouble(su_anki_ay_gunu)).ToString("###,###.##");
                gu.Gu_yillik = Convert.ToDouble(this.dr[2].ToString().Equals("") ? 0 : this.dr[2]).ToString("###,###.##");
                gu.Gu_yillik_ort = (Convert.ToDouble(gu.Gu_yillik) / days).ToString("###,###.##");

                genel_uretimler.Add(gu);
            }

            this.sql = "SELECT " +
       "(SELECT  SUM(TPAKTON)+ SUM(TSTDPAKTON) FROM URTHRK.VERIM WHERE TARIH = " + tarih + ") AS GUN, " +
       "(SELECT  SUM(TPAKTON)+ SUM(TSTDPAKTON) FROM URTHRK.VERIM WHERE TARIH BETWEEN '" + ay_baslangic + "' AND '" + tarih + "') AS AY, " +
       "(SELECT SUM(TPAKTON)+ SUM(TSTDPAKTON) FROM URTHRK.VERIM WHERE TARIH BETWEEN '" + yil_baslangic + "' AND '" + tarih + "') AS YIL " +
       "FROM URTHRK.VERIM WHERE ROWNUM = 1";
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();

            while (this.dr.Read())
            {
                Genel_uretim gu = new Genel_uretim();
                gu.Gu_id = 1;
                gu.Gu_bilgitnm = "Yuvarlak";
                gu.Gu_gunluk = Convert.ToDouble(this.dr[0].ToString().Equals("") ? 0 : this.dr[0]).ToString("###,###.##");
                yuvarlak_gunluk = gu.Gu_gunluk;
                gu.Gu_gunluk_ort = "0";
                gu.Gu_aylik = Convert.ToDouble(this.dr[1].ToString().Equals("") ? 0 : this.dr[1]).ToString("###,###.##");
                yuvarlak_aylik = gu.Gu_aylik;
                gu.Gu_aylik_ort = (Convert.ToDouble(gu.Gu_aylik) / Convert.ToDouble(su_anki_ay_gunu)).ToString("###,###.##");
                gu.Gu_yillik = Convert.ToDouble(this.dr[2].ToString().Equals("") ? 0 : this.dr[2]).ToString("###,###.##");
                yuvarlak_yillik = gu.Gu_yillik;
                gu.Gu_yillik_ort = (Convert.ToDouble(gu.Gu_yillik) / days).ToString("###,###.##");

                genel_uretimler.Add(gu);
            }

            this.sql = "SELECT " +
       "(SELECT SUM(KISAPARCA)/1000 FROM URTHRK.HHTARTHBKP WHERE TARIH = " + tarih + ") AS GUN, " +
       "(SELECT SUM(KISAPARCA)/1000 FROM URTHRK.HHTARTHBKP WHERE TARIH BETWEEN '" + ay_baslangic + "' AND '" + tarih + "') AS AY, " +
       "(SELECT SUM(KISAPARCA)/1000 FROM URTHRK.HHTARTHBKP WHERE TARIH BETWEEN '" + yil_baslangic + "' AND '" + tarih + "') AS YIL " +
       "FROM URTHRK.HHTARTHBKP WHERE ROWNUM = 1";
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();

            while (this.dr.Read())
            {
                Genel_uretim gu = new Genel_uretim();
                gu.Gu_id = 1;
                gu.Gu_bilgitnm = "Kısa Mamul";
                gu.Gu_gunluk = Convert.ToDouble(this.dr[0].ToString().Equals("") ? 0 : this.dr[0]).ToString("###,###.##");

                kisa_gunluk = gu.Gu_gunluk;
                gu.Gu_gunluk_ort = "0";
                gu.Gu_aylik = Convert.ToDouble(this.dr[1].ToString().Equals("") ? 0 : this.dr[1]).ToString("###,###.##");
                kisa_aylik = gu.Gu_aylik;
                gu.Gu_aylik_ort = (Convert.ToDouble(gu.Gu_aylik) / Convert.ToDouble(su_anki_ay_gunu)).ToString("###,###.##");
                gu.Gu_yillik = Convert.ToDouble(this.dr[2].ToString().Equals("") ? 0 : this.dr[2]).ToString("###,###.###");
                kisa_yillik = gu.Gu_yillik;
                gu.Gu_yillik_ort = (Convert.ToDouble(gu.Gu_yillik) / days).ToString("###,###.##");

                genel_uretimler.Add(gu);
            }

            this.sql = "SELECT " +
              "(SELECT SUM(TPAKTON) + SUM(TSTDPAKTON) from URTHRK.VERIM WHERE TARIH =  " + tarih + ") AS GUNLUK," +
              "(SELECT SUM(TPAKTON) + SUM(TSTDPAKTON) from URTHRK.VERIM WHERE TARIH BETWEEN '" + ay_baslangic + "' AND '" + tarih + "') AS AYLIK," +
              "(SELECT SUM(TPAKTON) + SUM(TSTDPAKTON) from URTHRK.VERIM WHERE TARIH BETWEEN '" + yil_baslangic + "' AND '" + tarih + "') AS YILLIK," +
              "(SELECT SUM(KISAPARCA) / 1000 from URTHRK.HHTARTHBKP WHERE TARIH =  " + tarih + ") AS GUNLUK," +
              "(SELECT SUM(KISAPARCA) / 1000 from URTHRK.HHTARTHBKP WHERE TARIH BETWEEN '" + ay_baslangic + "' AND '" + tarih + "') AS AYLIK," +
              "(SELECT SUM(KISAPARCA) / 1000 from URTHRK.HHTARTHBKP WHERE TARIH BETWEEN '" + yil_baslangic + "' AND '" + tarih + "') AS YILLIK," +
              "(SELECT SUM(KUTUKTONAJI) from URTHRK.VERIM WHERE TARIH =  " + tarih + ") AS GUNLUK," +
              "(SELECT SUM(KUTUKTONAJI) from URTHRK.VERIM WHERE TARIH BETWEEN '" + ay_baslangic + "' AND '" + tarih + "') AS AYLIK," +
              "(SELECT SUM(KUTUKTONAJI) from URTHRK.VERIM WHERE TARIH BETWEEN '" + yil_baslangic + "' AND '" + tarih + "') AS YILLIK " +
                       "FROM URTHRK.HHTARTHBKP WHERE ROWNUM = 1";

            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();

            while (this.dr.Read())
            {
                Genel_uretim gu = new Genel_uretim();
                gu.Gu_id = 1;
                gu.Gu_bilgitnm = "Fire %";
                gu.Gu_gunluk = ((1 -
                    ((Convert.ToDouble(this.dr[0].ToString().Equals("") ? 0 : this.dr[0]) +
                      Convert.ToDouble(this.dr[3].ToString().Equals("") ? 0 : this.dr[3])) /
                     Convert.ToDouble(this.dr[6].ToString().Equals("") ? 0 : this.dr[6]))) * 100).ToString("###,###.##");
                if (gu.Gu_gunluk == "NaN")
                {
                    gu.Gu_gunluk = "0";
                }


                gu.Gu_gunluk_ort = "0";
                gu.Gu_aylik = ((1 -
                    ((Convert.ToDouble(this.dr[1].ToString().Equals("") ? 0 : this.dr[1]) +
                     Convert.ToDouble(this.dr[4].ToString().Equals("") ? 0 : this.dr[4])) /
                      Convert.ToDouble(this.dr[7].ToString().Equals("") ? 0 : this.dr[7]))) * 100).ToString("###,###.##");
                gu.Gu_aylik_ort = "0";
                gu.Gu_yillik = ((1 -
                    ((Convert.ToDouble(this.dr[2].ToString().Equals("") ? 0 : this.dr[2]) +
                     Convert.ToDouble(this.dr[5].ToString().Equals("") ? 0 : this.dr[5])) /
                     Convert.ToDouble(this.dr[8].ToString().Equals("") ? 0 : this.dr[8]))) * 100).ToString("###,###.##");
                gu.Gu_yillik_ort = "0";

                genel_uretimler.Add(gu);
            }




            this.sql = "SELECT " +
         "(SELECT SUM(HBTONAJ) FROM URTHRK.HHTARTHBKP WHERE TARIH = " + tarih + ") AS GUN," +
         "(SELECT SUM(HBTONAJ) FROM URTHRK.HHTARTHBKP WHERE TARIH BETWEEN '" + ay_baslangic + "' AND '" + tarih + "') AS AY," +
         "(SELECT SUM(HBTONAJ) FROM URTHRK.HHTARTHBKP WHERE TARIH BETWEEN '" + yil_baslangic + "' AND '" + tarih + "') AS YIL, " + //hddebozugu
         "(SELECT SUM(TARTIM1)/1000 FROM URTHRK.HHTARTKIRP WHERE TARIH = " + tarih + ") AS GUN," +
         "(SELECT SUM(TARTIM1)/1000 FROM URTHRK.HHTARTKIRP WHERE TARIH BETWEEN '" + ay_baslangic + "' AND '" + tarih + "') AS AY," +
         "(SELECT SUM(TARTIM1)/1000 FROM URTHRK.HHTARTKIRP WHERE TARIH BETWEEN '" + yil_baslangic + "' AND '" + tarih + "') AS YIL " + //ucbas
         "FROM URTHRK.HHTARTKIRP WHERE ROWNUM = 1";
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();

            while (this.dr.Read())
            {
                Genel_uretim gu = new Genel_uretim();
                gu.Gu_id = 1;
                gu.Gu_bilgitnm = "Hadde b. + Uçbaş";
                gu.Gu_gunluk = (Convert.ToDouble(this.dr[0].ToString().Equals("") ? 0 : this.dr[0]) +
                        Convert.ToDouble(this.dr[3].ToString().Equals("") ? 0 : this.dr[3])).ToString("###,###.##");
                gu.Gu_gunluk_ort = "0";
                gu.Gu_aylik = (Convert.ToDouble(this.dr[1].ToString().Equals("") ? 0 : this.dr[1]) +
                        Convert.ToDouble(this.dr[4].ToString().Equals("") ? 0 : this.dr[4])).ToString("###,###.##");
                gu.Gu_aylik_ort = (Convert.ToDouble(gu.Gu_aylik) / Convert.ToDouble(su_anki_ay_gunu)).ToString("###,###.##");
                gu.Gu_yillik = (Convert.ToDouble(this.dr[2].ToString().Equals("") ? 0 : this.dr[2]) +
                        Convert.ToDouble(this.dr[5].ToString().Equals("") ? 0 : this.dr[5])).ToString("###,###.##");
                gu.Gu_yillik_ort = (Convert.ToDouble(gu.Gu_yillik) / days).ToString("###,###.##");

                genel_uretimler.Add(gu);
            }



            this.sql = "SELECT " +
                          "(SELECT GUNLUKTUKETIM FROM URTHRK.ELK_HHAOCH_SERVIS WHERE TARIH = " + tarih + " AND YER = 'Haddehane') AS GUN," +
                          "(SELECT SUM(GUNLUKTUKETIM) FROM URTHRK.ELK_HHAOCH_SERVIS WHERE TARIH BETWEEN '" + ay_baslangic + "' AND '" + tarih + "' AND YER = 'Haddehane') AS AY," +
                          "(SELECT SUM(GUNLUKTUKETIM) FROM URTHRK.ELK_HHAOCH_SERVIS WHERE TARIH BETWEEN '" + yil_baslangic + "' AND '" + tarih + "' AND YER = 'Haddehane') AS YIL, " +

                          "(SELECT GUNLUKTUKETIM FROM URTHRK.ELK_HHAOCH_SERVIS WHERE TARIH = " + tarih + " AND YER = 'JoyKompPompa') AS GUN," +
                          "(SELECT SUM(GUNLUKTUKETIM) FROM URTHRK.ELK_HHAOCH_SERVIS WHERE TARIH BETWEEN '" + ay_baslangic + "' AND '" + tarih + "' AND YER = 'JoyKompPompa') AS AY," +
                          "(SELECT SUM(GUNLUKTUKETIM) FROM URTHRK.ELK_HHAOCH_SERVIS WHERE TARIH BETWEEN '" + yil_baslangic + "' AND '" + tarih + "' AND YER = 'JoyKompPompa') AS YIL, " +

                          "(SELECT GUNLUKTUKETIM FROM URTHRK.ELK_HHAOCH_SERVIS WHERE TARIH = " + tarih + " AND YER = 'HaddeKompA') AS GUN," +
                          "(SELECT SUM(GUNLUKTUKETIM) FROM URTHRK.ELK_HHAOCH_SERVIS WHERE TARIH BETWEEN '" + ay_baslangic + "' AND '" + tarih + "' AND YER = 'HaddeKompA') AS AY," +
                          "(SELECT SUM(GUNLUKTUKETIM) FROM URTHRK.ELK_HHAOCH_SERVIS WHERE TARIH BETWEEN '" + yil_baslangic + "' AND '" + tarih + "' AND YER = 'HaddeKompA') AS YIL," +

                          "(SELECT GUNLUKTUKETIM FROM URTHRK.ELK_HHAOCH_SERVIS WHERE TARIH = " + tarih + " AND YER = 'HaddeKompB') AS GUN," +
                          "(SELECT SUM(GUNLUKTUKETIM) FROM URTHRK.ELK_HHAOCH_SERVIS WHERE TARIH BETWEEN '" + ay_baslangic + "' AND '" + tarih + "' AND YER = 'HaddeKompB') AS AY," +
                          "(SELECT SUM(GUNLUKTUKETIM) FROM URTHRK.ELK_HHAOCH_SERVIS WHERE TARIH BETWEEN '" + yil_baslangic + "' AND '" + tarih + "' AND YER = 'HaddeKompB') AS YIL, " +

                          "(SELECT GUNLUKTUKETIM FROM URTHRK.ELK_HHAOCH_SERVIS WHERE TARIH = " + tarih + " AND YER = 'Atelyeler') AS GUN," +
                          "(SELECT SUM(GUNLUKTUKETIM) FROM URTHRK.ELK_HHAOCH_SERVIS WHERE TARIH BETWEEN '" + ay_baslangic + "' AND '" + tarih + "' AND YER = 'Atelyeler') AS AY," +
                          "(SELECT SUM(GUNLUKTUKETIM) FROM URTHRK.ELK_HHAOCH_SERVIS WHERE TARIH BETWEEN '" + yil_baslangic + "' AND '" + tarih + "' AND YER = 'Atelyeler') AS YIL " +
                          "FROM URTHRK.ELK_HHAOCH_SERVIS WHERE ROWNUM = 1";

            //HaddeKompA,HaddeKompB,Atelyeler
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Genel_uretim gu = new Genel_uretim();
                gu.Gu_bilgitnm = "Listelenecek kayıt bulunamadı.";
                gu.Gu_id = 0;
                genel_uretimler.Add(gu);
            }
            else
            {
                while (this.dr.Read())
                {
                    Genel_uretim gu = new Genel_uretim();
                    gu.Gu_id = 1;
                    gu.Gu_bilgitnm = "Enerji(Kwh)";
                    gu.Gu_gunluk = ((Convert.ToDouble(this.dr[0].ToString().Equals("") ? 0 : this.dr[0]) - Convert.ToDouble(this.dr[3].ToString().Equals("") ? 0 : this.dr[3])) +
                                   Convert.ToDouble(this.dr[6].ToString().Equals("") ? 0 : this.dr[6]) +
                                   Convert.ToDouble(this.dr[9].ToString().Equals("") ? 0 : this.dr[9]) +
                                   Convert.ToDouble(this.dr[12].ToString().Equals("") ? 0 : this.dr[12])).ToString("###,###.###");
                    if ((gu.Gu_gunluk != "" && gu.Gu_gunluk != "0") && (yuvarlak_gunluk != "" && kisa_gunluk != ""))
                    {
                        gu.Gu_gunluk_ort = (Convert.ToDouble(gu.Gu_gunluk) / (Convert.ToDouble(yuvarlak_gunluk) + Convert.ToDouble(kisa_gunluk))).ToString("###,###.##");
                    }
                    gu.Gu_aylik = ((Convert.ToDouble(this.dr[1].ToString().Equals("") ? 0 : this.dr[1]) - Convert.ToDouble(this.dr[4].ToString().Equals("") ? 0 : this.dr[4])) +
                                   Convert.ToDouble(this.dr[7].ToString().Equals("") ? 0 : this.dr[7]) +
                                   Convert.ToDouble(this.dr[10].ToString().Equals("") ? 0 : this.dr[10]) +
                                   Convert.ToDouble(this.dr[13].ToString().Equals("") ? 0 : this.dr[13])).ToString("###,###.###");

                    if (gu.Gu_aylik != "" && gu.Gu_aylik != "0")
                    {
                        gu.Gu_aylik_ort = (Convert.ToDouble(gu.Gu_aylik) / (Convert.ToDouble(yuvarlak_aylik) + Convert.ToDouble(kisa_aylik))).ToString("###,###.##");
                    }
                    gu.Gu_yillik = ((Convert.ToDouble(this.dr[2].ToString().Equals("") ? 0 : this.dr[2]) - Convert.ToDouble(this.dr[5].ToString().Equals("") ? 0 : this.dr[5])) +
                                   Convert.ToDouble(this.dr[8].ToString().Equals("") ? 0 : this.dr[8]) +
                                   Convert.ToDouble(this.dr[11].ToString().Equals("") ? 0 : this.dr[11]) +
                                   Convert.ToDouble(this.dr[14].ToString().Equals("") ? 0 : this.dr[14])).ToString("###,###.###");

                    if (gu.Gu_yillik != "" && gu.Gu_yillik != "0")
                    {
                        gu.Gu_yillik_ort = (Convert.ToDouble(gu.Gu_yillik) / (Convert.ToDouble(yuvarlak_yillik) + Convert.ToDouble(kisa_yillik))).ToString("###,###.##");
                    }

                    genel_uretimler.Add(gu);
                }

            }
            this.sql = "SELECT " +
              "(SELECT HH_DOGALGAZ FROM URTHRK.OKSIJEN_GIRIS WHERE TARIH = " + tarih + " ) AS GUN," +
              "(SELECT SUM(HH_DOGALGAZ) FROM URTHRK.OKSIJEN_GIRIS WHERE TARIH BETWEEN '" + ay_baslangic + "' AND '" + tarih + "') AS AY," +
              "(SELECT SUM(HH_DOGALGAZ) FROM URTHRK.OKSIJEN_GIRIS WHERE TARIH BETWEEN '" + yil_baslangic + "' AND '" + tarih + "') AS YIL " +
              "FROM URTHRK.OKSIJEN_GIRIS WHERE ROWNUM = 1";
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Genel_uretim gu = new Genel_uretim();
                gu.Gu_bilgitnm = "Listelenecek kayıt bulunamadı.";
                gu.Gu_id = 0;
                genel_uretimler.Add(gu);
            }
            else
            {
                while (this.dr.Read())
                {
                    Genel_uretim gu = new Genel_uretim();
                    gu.Gu_id = 1;
                    gu.Gu_bilgitnm = "Doğal gaz(m3)";
                    gu.Gu_gunluk = Convert.ToDouble(this.dr[0].ToString().Equals("") ? 0 : this.dr[0]).ToString("###,###.###");
                    if ((gu.Gu_gunluk != "" && gu.Gu_gunluk != "0") && (yuvarlak_gunluk != "" && kisa_gunluk != ""))
                    {
                        gu.Gu_gunluk_ort = (Convert.ToDouble(gu.Gu_gunluk) / (Convert.ToDouble(yuvarlak_gunluk) + Convert.ToDouble(kisa_gunluk))).ToString("###,###.##");
                    }
                    gu.Gu_aylik = Convert.ToDouble(this.dr[1].ToString().Equals("") ? 0 : this.dr[1]).ToString("###,###.###");
                    if (gu.Gu_aylik != "" && gu.Gu_aylik != "0")
                    {
                        gu.Gu_aylik_ort = (Convert.ToDouble(gu.Gu_aylik) / (Convert.ToDouble(yuvarlak_aylik) + Convert.ToDouble(kisa_aylik))).ToString("###,###.##");
                    }
                    gu.Gu_yillik = Convert.ToDouble(this.dr[2].ToString().Equals("") ? 0 : this.dr[2]).ToString("###,###.###");
                    if (gu.Gu_yillik != "" && gu.Gu_yillik != "0")
                    {
                        gu.Gu_yillik_ort = (Convert.ToDouble(gu.Gu_yillik) / (Convert.ToDouble(yuvarlak_yillik) + Convert.ToDouble(kisa_yillik))).ToString("###,###.##");
                    }
                    genel_uretimler.Add(gu);
                }

            }
            this.dr.Close();
            this.dr.Dispose();

            return genel_uretimler;
        }
        public List<Yol_bazinda_uretim_ozet> d_hh_ybuo_data_read(string tarih)
        {
            List<Yol_bazinda_uretim_ozet> ybuo = new List<Yol_bazinda_uretim_ozet>();
            this.sql = "SELECT VRD, YOL,SUM(TPAKTON)+ SUM(TSTDPAKTON), CAP, BOY FROM VERIM " +
                       "WHERE TARIH = " + tarih + " GROUP BY VRD, CAP, YOL, BOY ORDER BY VRD ";
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Yol_bazinda_uretim_ozet uo = new Yol_bazinda_uretim_ozet();
                uo.Vrd = "Listelenecek kayıt bulunamadı.";
                uo.Ybu_id = 0;
                ybuo.Add(uo);
            }
            else
            {
                try
                {
                    while (this.dr.Read())
                    {
                        Yol_bazinda_uretim_ozet uo = new Yol_bazinda_uretim_ozet();
                        uo.Ybu_id = 1;
                        uo.Vrd = this.dr[0].ToString();
                        uo.Yol = this.dr[1].ToString();
                        uo.Net_urt = Convert.ToDouble(this.dr[2].ToString().Equals("") ? "0.0" : this.dr[2]).ToString("###.###.###");
                        uo.Mamul = this.dr[3].ToString() + "mm N D" + " " + this.dr[4].ToString() + "m";

                        ybuo.Add(uo);
                    }
                }
                catch
                {
                    throw new System.InvalidOperationException("Bağlantı gerçekleştirilirken bir hata oluştu.Tekrar deneyiniz!");
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return ybuo;
        }
        public List<Duruslar> duruslar_data_read_hh(string tarih)
        {
            List<Duruslar> duruslar = new List<Duruslar>();
            string yil = tarih.Substring(0, 4);
            string yil_baslangic = yil + "0101";
            string yil_ay = tarih.Substring(0, 6);
            string ay_baslangic = yil_ay + "01";

            this.sql = "SELECT " +
          "(SELECT SUM(NETSURE) FROM DURUS_RAPOR_OZT H WHERE TARIH = " + tarih + "  ) AS GUNLUKSURE," +
          "(SELECT SUM(NETSURE) FROM DURUS_RAPOR_OZT H WHERE TARIH BETWEEN '" + ay_baslangic + "' AND '" + tarih + "' ) AS AYLIKSURE," +
          "(SELECT SUM(NETSURE) FROM DURUS_RAPOR_OZT H WHERE TARIH BETWEEN '" + yil_baslangic + "' AND '" + tarih + "') AS YILLIKSURE," +
          "(SELECT COUNT(DURUS) FROM DURUS_RAPOR_OZT H WHERE TARIH = " + tarih + ") AS GUNLUKSURE," +
          "(SELECT  COUNT(DURUS) FROM DURUS_RAPOR_OZT H WHERE TARIH BETWEEN '" + ay_baslangic + "' AND '" + tarih + "' ) AS AYLIKSURE," +
          "(SELECT COUNT(DURUS) FROM DURUS_RAPOR_OZT H WHERE TARIH BETWEEN '" + yil_baslangic + "' AND '" + tarih + "' ) AS YILLIKSURE " +
          "FROM DURUS_RAPOR_OZT WHERE ROWNUM=1";
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            while (this.dr.Read())
            {
                Duruslar d = new Duruslar();
                d.Durus_id = 1;
                d.Durus_nedeni = "TOPLAM";
                d.Gun_sure = Convert.ToDouble(this.dr[0].ToString().Equals("") ? 0 : this.dr[0]).ToString("###,###.###");
                d.Gun_tekrar = Convert.ToDouble(this.dr[3].ToString().Equals("") ? 0 : this.dr[3]).ToString("###,###.###");
                gun_toplam_tekrar_hh = d.Gun_tekrar;
                d.Gun_yuzde = "100";
                d.Ay_sure = Convert.ToDouble(this.dr[1].ToString().Equals("") ? 0 : this.dr[1]).ToString("###,###.###");
                d.Ay_yuzde = "100";
                d.Ay_tekrar = Convert.ToDouble(this.dr[4].ToString().Equals("") ? 0 : this.dr[4]).ToString("###,###.###");
                ay_toplam_tekrar_hh = d.Ay_tekrar;
                d.Yil_sure = Convert.ToDouble(this.dr[2].ToString().Equals("") ? 0 : this.dr[2]).ToString("###,###.###");
                d.Yil_yuzde = "100";
                d.Yil_tekrar = Convert.ToDouble(this.dr[5].ToString().Equals("") ? 0 : this.dr[5]).ToString("###,###.###");
                yil_toplam_tekrar_hh = d.Yil_tekrar;
                duruslar.Add(d);
            }

            this.sql = "SELECT TNM.DURUS," +
           "(SELECT SUM(NETSURE) FROM DURUS_RAPOR_OZT H WHERE TARIH = " + tarih + " AND H.DURUS = TNM.DURUS ) AS GUNLUKSURE," +
           "(SELECT SUM(NETSURE) FROM DURUS_RAPOR_OZT H WHERE TARIH BETWEEN '" + ay_baslangic + "' AND '" + tarih + "' AND H.DURUS = TNM.DURUS) AS AYLIKSURE," +
           "(SELECT SUM(NETSURE) FROM DURUS_RAPOR_OZT H WHERE TARIH BETWEEN '" + yil_baslangic + "' AND '" + tarih + "' AND H.DURUS = TNM.DURUS) AS YILLIKSURE, " +
           "(SELECT COUNT(DURUS) FROM DURUS_RAPOR_OZT H WHERE TARIH = " + tarih + "  AND TNM.DURUS = H.DURUS ) AS GUNLUKSURE," +
           "(SELECT  COUNT(DURUS) FROM DURUS_RAPOR_OZT H WHERE TARIH BETWEEN '" + ay_baslangic + "' AND '" + tarih + "' AND TNM.DURUS = H.DURUS ) AS AYLIKSURE," +
           "(SELECT COUNT(DURUS) FROM DURUS_RAPOR_OZT H WHERE TARIH BETWEEN '" + yil_baslangic + "' AND '" + tarih + "' AND  TNM.DURUS = H.DURUS) AS YILLIKSURE " +
           "FROM DURUS_RAPOR_OZT TNM GROUP BY TNM.DURUS";
            //D2 duruş nedeni
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            while (this.dr.Read())
            {
                Duruslar d = new Duruslar();
                d.Durus_id = 1;
                d.Durus_nedeni = this.dr[0].ToString();
                d.Gun_sure = this.dr[1].ToString();
                d.Gun_tekrar = this.dr[4].ToString();
                if (d.Gun_tekrar != "" && d.Gun_tekrar != "0")
                {
                    d.Gun_yuzde = ((Convert.ToInt32(d.Gun_tekrar) / Convert.ToDouble(gun_toplam_tekrar_hh)) * 100).ToString("0.#");
                }
                d.Ay_sure = Convert.ToDouble(this.dr[2].ToString().Equals("") ? 0 : this.dr[2]).ToString("###,###.###");
                d.Ay_tekrar = this.dr[5].ToString();
                if (d.Ay_tekrar != "" && d.Ay_tekrar != "0")
                {
                    d.Ay_yuzde = ((Convert.ToInt32(d.Ay_tekrar) / Convert.ToDouble(ay_toplam_tekrar_hh)) * 100).ToString("0.#");
                }
                d.Yil_sure = Convert.ToDouble(this.dr[3].ToString().Equals("") ? 0 : this.dr[3]).ToString("###,###.###");
                d.Yil_tekrar = this.dr[6].ToString();
                if (d.Yil_tekrar != "" && d.Yil_tekrar != "0")
                {
                    d.Yil_yuzde = ((Convert.ToInt32(d.Yil_tekrar) / Convert.ToDouble(yil_toplam_tekrar_hh)) * 100).ToString("0.#");
                }
                duruslar.Add(d);
            }


            this.dr.Close();
            this.dr.Dispose();

            return duruslar;
        }
        public List<Durus_ayrintisi> durus_ayrintisi_data_read_hh(string tarih, string durus_tipi)
        {
            List<Durus_ayrintisi> durus_ayrintisi = new List<Durus_ayrintisi>();

            this.sql = "SELECT DURUS,ARIZA,SUM(NETSURE),COUNT(ARIZA) from URTHRK.DURUS_RAPOR_OZT " +
                       "WHERE DURUS = '" + durus_tipi + "' AND TARIH = " + tarih + " GROUP BY ARIZA,DURUS";

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

                        da.Durus_tipi = this.dr[0].ToString();
                        da.Ariza_nedeni = this.dr[1].ToString();
                        da.Toplam_sure = this.dr[2].ToString();
                        da.Gun_tekrar = this.dr[3].ToString();

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
    }
}