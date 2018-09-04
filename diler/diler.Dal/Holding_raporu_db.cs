using diler.Entity;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace diler.Dal
{
    public class Holding_raporu_db
    {
        OracleConnection conn, conn_filmasin;
        string connetionString, sql, connection_string;
        OracleCommand cmd;
        OracleDataReader dr;

        public Holding_raporu_db()
        {

            //this.connetionString = @"Data Source=94.138.197.30;Initial Catalog=wbteknik;User ID=Wbteknik;Password=Wbteknik123";//uzak host
            //this.cmd = new SqlCommand();

            try
            {
                this.connetionString = @"Data Source=(DESCRIPTION=" +
                      "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.198.191)(PORT=1521)))" +
                      "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=DLRORA)));" +
                      "User Id=URTHRK;Password=URTHRK;";

                this.connection_string = @"Data Source=(DESCRIPTION=" +
                  "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.189.191)(PORT=1521)))" +
                  "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=FLMORA)));" +
                  "User Id=URTHRK;Password=URTHRK;";


                this.cmd = new OracleCommand();
                this.conn = new OracleConnection(this.connetionString);
                this.conn_filmasin = new OracleConnection(this.connection_string);

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
        public void flm_connect()
        {
            if (this.conn_filmasin.State != System.Data.ConnectionState.Open)
            {
                try
                {

                    this.conn_filmasin.Open();
                    this.cmd.Connection = this.conn_filmasin;
                }
                catch
                {
                    throw new System.InvalidOperationException("Veri Tabani baglantisi kurulamiyor!");
                }
            }
        }
        public void flm_Disconnect()
        {
            if (this.conn_filmasin.State == System.Data.ConnectionState.Open)
            {
                this.conn_filmasin.Close();

            }
        }




        /** Celikhane */
        public List<Uretimler> uretimler_data_read(string tarih, string firma, string unite)
        {
            List<Uretimler> uretimler = new List<Uretimler>();

            this.sql = "SELECT BILGITNM,K1,K2,K3 FROM API_DB_001_Y " +
                       "WHERE TARIH=" + tarih + " AND FIRMA='" + firma + "' AND UNITE='" + unite + "' AND TABLOTIP='URETIM' " +
                       "ORDER BY CAST(BILGISIRANO AS INT)";

            try
            {
                this.cmd.CommandText = this.sql;
                this.dr = this.cmd.ExecuteReader();

                if (!this.dr.HasRows)
                {
                    //kayit bulunamadiysa
                    Uretimler u = new Uretimler();
                    u.Uretim_bilgitnm = "Listelenecek kayıt bulunamadı.";
                    u.Uretim_id = 0;
                    uretimler.Add(u);
                }
                else
                {

                    while (this.dr.Read())
                    {
                        Uretimler u = new Uretimler();
                        u.Uretim_id = 1;
                        //if (firma != "YAZICI")
                        //{
                        //    u.Uretim_bilgitnm = this.dr[0].ToString();
                        //    u.Dokum_sayisi = (Convert.ToDouble(this.dr[1].ToString().Equals("") ? "0.0" : this.dr[1].ToString())).ToString("###,###.###");
                        //    u.Imale_sevk_hurda = (Convert.ToDouble(this.dr[2].ToString().Equals("") ? "0.0" : this.dr[2].ToString())).ToString("###,###.###");
                        //    u.Uretim = (Convert.ToDouble(this.dr[3].ToString().Equals("") ? "0.0" : this.dr[3].ToString())).ToString("###,###.###");
                        //}
                        //else
                        //{}
                        u.Uretim_bilgitnm = this.dr[0].ToString();
                        u.Dokum_sayisi = this.dr[1].ToString();
                        u.Imale_sevk_hurda = this.dr[2].ToString();
                        u.Uretim = this.dr[3].ToString();

                        uretimler.Add(u);

                    }
                }
            }
            catch
            {
                throw new System.InvalidOperationException("Bağlantı gerçekleştirilirken bir hata oluştu.Tekrar deneyiniz!");
            }
            this.dr.Close();
            this.dr.Dispose();

            return uretimler;
        }
        public List<Uretim_ozetler> uretim_ozetler_data_read(string tarih, string firma, string unite)
        {
            List<Uretim_ozetler> uretim_ozetler = new List<Uretim_ozetler>();
            this.sql = "SELECT BILGITNM,K1,K2,K3 FROM API_DB_001_Y " +
                       "WHERE TARIH=" + tarih + " AND FIRMA='" + firma + "' AND UNITE='" + unite + "' AND TABLOTIP='GUNLUK' " +
                       "ORDER BY CAST(BILGISIRANO AS INT)";
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Uretim_ozetler u = new Uretim_ozetler();
                u.Kalite = "Listelenecek kayıt bulunamadı.";
                u.Uretim_ozet_id = 0;
                uretim_ozetler.Add(u);
            }
            else
            {
                try
                {
                    while (this.dr.Read())
                    {
                        Uretim_ozetler u = new Uretim_ozetler();
                        u.Uretim_ozet_id = 1;
                        u.Kalite = this.dr[0].ToString();
                        u.Ebat = this.dr[1].ToString();
                        u.Boy = this.dr[2].ToString();
                        //u.Tonaj = (Convert.ToDouble(this.dr[3].ToString().Equals("") ? "0.0" : this.dr[3].ToString())).ToString("0");

                        u.Tonaj = this.dr[3].ToString();

                        uretim_ozetler.Add(u);
                    }
                }
                catch
                {
                    throw;
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return uretim_ozetler;
        }
        public List<Enerjiler> enerjiler_data_read(string tarih, string firma, string unite)
        {
            List<Enerjiler> enerjiler = new List<Enerjiler>();

            this.sql = "SELECT BILGITNM,K1,K2,K3,K4,K5,K6 FROM API_DB_001_Y " +
                       "WHERE TARIH=" + tarih + " AND FIRMA='" + firma + "' AND UNITE='" + unite + "' AND TABLOTIP='ENERJI' " +
                       "ORDER BY CAST(BILGISIRANO AS INT)";
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
                try
                {
                    while (this.dr.Read())
                    {
                        Enerjiler e = new Enerjiler();
                        e.Enerji_id = 1;
                        e.Enerji_bilgitnm = this.dr[0].ToString();
                        //if (firma != "YAZICI")
                        //{
                        //    e.Gun_kwh = Convert.ToDouble(this.dr[1].ToString().Equals("") ? 0 : this.dr[1]).ToString("###,###");
                        //    e.Gun_kwh_ton = Convert.ToDouble(this.dr[2].ToString().Equals("") ? 0 : this.dr[2]).ToString("0.#");
                        //    e.Ay_kwh = Convert.ToDouble(this.dr[3].ToString().Equals("") ? 0 : this.dr[3]).ToString("###,###");
                        //    e.Ay_kwh_ton = Convert.ToDouble(this.dr[4].ToString().Equals("") ? 0 : this.dr[4]).ToString("0.#");
                        //    e.Yil_kwh = Convert.ToDouble(this.dr[5].ToString().Equals("") ? 0 : this.dr[5]).ToString("###,###");
                        //    e.Yil_kwh_ton = Convert.ToDouble(this.dr[6].ToString().Equals("") ? 0 : this.dr[6]).ToString("0.#");
                        //}
                        //else
                        //{
                        e.Gun_kwh = this.dr[1].ToString();
                        e.Gun_kwh_ton = this.dr[2].ToString();
                        e.Ay_kwh = this.dr[3].ToString();
                        e.Ay_kwh_ton = this.dr[4].ToString();
                        e.Yil_kwh = this.dr[5].ToString();
                        e.Yil_kwh_ton = this.dr[6].ToString();

                        enerjiler.Add(e);
                    }
                }
                catch
                {
                    throw;
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return enerjiler;
        }
        public List<Sarfiyatlar> sarfiyatlar_data_read(string tarih, string firma, string unite)
        {
            List<Sarfiyatlar> sarfiyatlar = new List<Sarfiyatlar>();

            this.sql = "SELECT BILGITNM,K1,K2,K3,K4,K5,K6 FROM API_DB_001_Y " +
                       "WHERE TARIH=" + tarih + " AND FIRMA='" + firma + "' AND UNITE='" + unite + "' AND TABLOTIP='SARFMLZ' " +
                       "ORDER BY CAST(BILGISIRANO AS INT)";

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

                while (this.dr.Read())
                {
                    Sarfiyatlar e = new Sarfiyatlar();
                    e.Sarfiyat_id = 1;
                    e.Sarfiyat_bilgitnm = this.dr[0].ToString();
                    //if (firma != "YAZICI")
                    //{
                    //    e.Gun_miktar = Convert.ToDouble(this.dr[1].ToString().Equals("") ? 0 : this.dr[1]).ToString("###,###.###");
                    //    e.Gun_ton = (Convert.ToDouble(this.dr[2].ToString().Equals("") ? 0 : this.dr[2])).ToString("0.#");
                    //    e.Ay_miktar = Convert.ToDouble(this.dr[3].ToString().Equals("") ? 0 : this.dr[3]).ToString("###,###.###");
                    //    e.Ay_ton = Convert.ToDouble(this.dr[4].ToString().Equals("") ? 0 : this.dr[4]).ToString("0.#");
                    //    e.Yil_miktar = Convert.ToDouble(this.dr[5].ToString().Equals("") ? 0 : this.dr[5]).ToString("###,###.###");
                    //    e.Yil_ton = Convert.ToDouble(this.dr[6].ToString().Equals("") ? 0 : this.dr[6]).ToString("0.#");
                    //}
                    //else
                    //{

                    e.Gun_miktar = this.dr[1].ToString();
                    e.Gun_ton = this.dr[2].ToString();
                    e.Ay_miktar = this.dr[3].ToString();
                    e.Ay_ton = this.dr[4].ToString();
                    e.Yil_miktar = this.dr[5].ToString();
                    e.Yil_ton = this.dr[6].ToString();

                    sarfiyatlar.Add(e);
                }

            }
            this.dr.Close();
            this.dr.Dispose();

            return sarfiyatlar;
        }
        public List<Duruslar> duruslar_data_read(string tarih, string firma, string unite, string tablotip = "DURUS")
        {
            List<Duruslar> duruslar = new List<Duruslar>();

            this.sql = "SELECT BILGITNM,K1,K2,K3,K4,K5,K6,K7,K8,K9 FROM API_DB_001_Y " +
                       "WHERE TARIH=" + tarih + " AND FIRMA='" + firma + "' AND UNITE='" + unite + "' AND TABLOTIP='" + tablotip + "' " +
                       "ORDER BY CAST(BILGISIRANO AS INT)";

            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Duruslar d = new Duruslar();
                d.Durus_nedeni = " Listelenecek kayıt bulunamadı.";
                d.Durus_id = 0;
                duruslar.Add(d);
            }
            else
            {
                try
                {
                    while (this.dr.Read())
                    {
                        Duruslar d = new Duruslar();
                        d.Durus_id = 1;
                        d.Durus_nedeni = this.dr[0].ToString();
                        d.Gun_sure = this.dr[1].ToString();
                        d.Gun_tekrar = this.dr[2].ToString();
                        d.Gun_yuzde = this.dr[3].ToString();
                        d.Ay_yuzde = this.dr[6].ToString();
                        d.Yil_yuzde = this.dr[9].ToString();
                        //if (firma != "YAZICI")
                        //{
                        //    d.Ay_sure = Convert.ToDouble(this.dr[4].ToString().Equals("") ? 0 : this.dr[4]).ToString("###,###.###");
                        //    d.Ay_tekrar = Convert.ToDouble(this.dr[5].ToString().Equals("") ? 0 : this.dr[5]).ToString("###,###.###");

                        //    d.Yil_sure = Convert.ToDouble(this.dr[7].ToString().Equals("") ? 0 : this.dr[7]).ToString("###,###.###");
                        //    d.Yil_tekrar = Convert.ToDouble(this.dr[8].ToString().Equals("") ? 0 : this.dr[8]).ToString("###,###.###");
                        //}
                        //else
                        //{
                        d.Ay_sure = this.dr[4].ToString();
                        d.Ay_tekrar = this.dr[5].ToString();
                        d.Yil_sure = this.dr[7].ToString();
                        d.Yil_tekrar = this.dr[8].ToString();

                        duruslar.Add(d);
                    }
                }
                catch
                {
                    throw;
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return duruslar;
        }
        public List<Durus_ayrintisi> durus_ayrintisi_data_read(string tarih, string durus, string firma, string unite)
        {
            List<Durus_ayrintisi> durus_ayrintisi = new List<Durus_ayrintisi>();
            this.sql = "SELECT DURUS,ARIZA,TOPLAM_SURE,TEKRAR FROM API_DB_003_Y " +
                       "WHERE TARIH=" + tarih + " AND DURUS='" + durus + "' AND FIRMA='" + firma + "' AND UNITE='" + unite + "' ";
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Durus_ayrintisi da = new Durus_ayrintisi();
                da.Durus_tipi = "Oops! Listelenecek kayıt bulunamadı.";
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
                    throw;
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return durus_ayrintisi;
        }
        public List<Hurdalar> hurdalar_data_read(string tarih, string firma, string unite)
        {
            List<Hurdalar> hurdalar = new List<Hurdalar>();

            this.sql = "SELECT BILGITNM,K1,K2,K3,K4,K5,K6,K7 FROM API_DB_001_Y " +
                       "WHERE TARIH=" + tarih + " AND FIRMA='" + firma + "' AND UNITE='" + unite + "' AND TABLOTIP='KULLANIM' " +
                       "ORDER BY CAST(BILGISIRANO AS INT)";

            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Hurdalar h = new Hurdalar();
                h.Hurda_bilgitnm = "Listelenecek kayıt bulunamadı.";
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
                        //if (firma != "YAZICI")
                        //{
                        //    h.Gunluk_kullanim = Convert.ToDouble(this.dr[1].ToString().Equals("") ? 0 : this.dr[1]).ToString("###,###.###");
                        //    h.Aylik_kullanim = Convert.ToDouble(this.dr[2].ToString().Equals("") ? 0 : this.dr[2]).ToString("###,###.###");
                        //    h.Yillik_kullanim = Convert.ToDouble(this.dr[3].ToString().Equals("") ? 0 : this.dr[3]).ToString("###,###.###");
                        //    h.Gunluk_giris = Convert.ToDouble(this.dr[4].ToString().Equals("") ? 0 : this.dr[4]).ToString("###,###.###");
                        //    h.Aylik_giris = Convert.ToDouble(this.dr[5].ToString().Equals("") ? 0 : this.dr[5]).ToString("###,###.###");
                        //    h.Yillik_giris = Convert.ToDouble(this.dr[6].ToString().Equals("") ? 0 : this.dr[6]).ToString("###,###.###");
                        //    h.Stok = Convert.ToDouble(this.dr[7].ToString().Equals("") ? 0 : this.dr[7]).ToString("###,###.###");
                        //}
                        //else
                        //{

                        h.Gunluk_kullanim = this.dr[1].ToString();
                        h.Aylik_kullanim = this.dr[2].ToString();
                        h.Yillik_kullanim = this.dr[3].ToString();
                        h.Gunluk_giris = this.dr[4].ToString();
                        h.Aylik_giris = this.dr[5].ToString();
                        h.Yillik_giris = this.dr[6].ToString();
                        h.Stok = this.dr[7].ToString();


                        hurdalar.Add(h);
                    }
                }
                catch
                {
                    throw;
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return hurdalar;
        }
        public List<Oksijen> oksijen_data_read(string tarih, string firma, string unite)
        {
            List<Oksijen> oksijen = new List<Oksijen>();

            this.sql = "SELECT BILGITNM,K1,K2,K3,K4,K5,K6 FROM API_DB_001_Y "+
                       "WHERE TARIH=" + tarih + " AND FIRMA='" + firma + "' AND UNITE='" + unite + "' AND TABLOTIP='TUKETIM' "+
                       "ORDER BY CAST(BILGISIRANO AS INT)";
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
                try
                {
                    while (this.dr.Read())
                    {
                        Oksijen o = new Oksijen();
                        o.Oksijen_id = 1;
                        o.Oksijen_bilgitnm = this.dr[0].ToString();
                        //if (firma != "YAZICI")
                        //{
                        //    o.Gun_miktar = Convert.ToDouble(this.dr[1].ToString().Equals("") ? 0 : this.dr[1]).ToString("###,###.###");
                        //    o.Gun_ton = Convert.ToDouble(this.dr[2].ToString().Equals("") ? 0 : this.dr[2]).ToString("###,###.#");
                        //    o.Ay_miktar = Convert.ToDouble(this.dr[3].ToString().Equals("") ? 0 : this.dr[3]).ToString("###,###.###");
                        //    o.Ay_ton = Convert.ToDouble(this.dr[4].ToString().Equals("") ? 0 : this.dr[4]).ToString("###,###.#");
                        //    o.Yil_miktar = Convert.ToDouble(this.dr[5].ToString().Equals("") ? 0 : this.dr[5]).ToString("###,###.###");
                        //    o.Yil_ton = Convert.ToDouble(this.dr[6].ToString().Equals("") ? 0 : this.dr[6]).ToString("###,###.#");
                        //}
                        //else
                        //{
                        o.Gun_miktar = this.dr[1].ToString();
                        o.Gun_ton = this.dr[2].ToString();
                        o.Ay_miktar = this.dr[3].ToString();
                        o.Ay_ton = this.dr[4].ToString();
                        o.Yil_miktar = this.dr[5].ToString();
                        o.Yil_ton = this.dr[6].ToString();

                        oksijen.Add(o);
                    }
                }
                catch
                {
                    throw;
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return oksijen;
        }
        public List<Analizler> analizler_data_read(string tarih, string firma, string unite)
        {
            List<Analizler> analizler = new List<Analizler>();

            this.sql = "SELECT BILGITNM,K1,K2,K3,K4,K5,K6,K7,K8,K9 FROM API_DB_001_Y "+
                       "WHERE TARIH=" + tarih + " AND FIRMA='" + firma + "' AND UNITE='" + unite + "' AND TABLOTIP='ANALIZ' "+
                       "ORDER BY CAST(BILGISIRANO AS INT)";
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Analizler a = new Analizler();
                a.Dokum_no = "Listelenecek kayıt bulunamadı.";
                a.Analiz_id = 0;
                analizler.Add(a);
            }
            else
            {
                try
                {
                    while (this.dr.Read())
                    {
                        Analizler a = new Analizler();
                        a.Analiz_id = 1;
                        a.Dokum_no = this.dr[0].ToString();
                        a.C = this.dr[1].ToString();
                        a.Si = this.dr[2].ToString();
                        a.S = this.dr[3].ToString();
                        a.P = this.dr[4].ToString();
                        a.Mn = this.dr[5].ToString();
                        a.Ni = this.dr[6].ToString();
                        a.Cr = this.dr[7].ToString();
                        a.Cu = this.dr[8].ToString();
                        a.V = this.dr[9].ToString();
                        analizler.Add(a);
                    }
                }
                catch
                {
                    throw;
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return analizler;
        }



        /** Haddehane */
        public List<Genel_uretim> genel_uretim_data_read(string tarih, string firma = "DILER", string unite = "HH", string tablotip = "URETIM")
        {
            List<Genel_uretim> genel_uretimler = new List<Genel_uretim>();
            this.sql = "SELECT BILGITNM,K1,K2,K3,K4,K5,K6 FROM API_DB_001_Y " +
                       "WHERE TARIH=" + tarih + " AND FIRMA='" + firma + "' AND UNITE='" + unite + "' AND TABLOTIP='" + tablotip + "' "+
                       "ORDER BY CAST(BILGISIRANO AS INT)";
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
                    gu.Gu_bilgitnm = this.dr[0].ToString();
                    //if (firma != "YAZICI")
                    //{
                    //    gu.Gu_gunluk = Convert.ToDouble(this.dr[1].ToString().Equals("") ? 0 : this.dr[1]).ToString("###,###.##");
                    //    gu.Gu_gunluk_ort = Convert.ToDouble(this.dr[2].ToString().Equals("") ? 0 : this.dr[2]).ToString("###,###.##");
                    //    gu.Gu_aylik = Convert.ToDouble(this.dr[3].ToString().Equals("") ? 0 : this.dr[3]).ToString("###,###.##");
                    //    gu.Gu_aylik_ort = Convert.ToDouble(this.dr[4].ToString().Equals("") ? 0 : this.dr[4]).ToString("###,###.##");
                    //    gu.Gu_yillik = Convert.ToDouble(this.dr[5].ToString().Equals("") ? 0 : this.dr[5]).ToString("###,###.##");
                    //    gu.Gu_yillik_ort = Convert.ToDouble(this.dr[6].ToString().Equals("") ? 0 : this.dr[6]).ToString("###,###.##");
                    //}
                    //else
                    //{
                    gu.Gu_gunluk = this.dr[1].ToString();
                    gu.Gu_gunluk_ort = this.dr[2].ToString();
                    gu.Gu_aylik = this.dr[3].ToString();
                    gu.Gu_aylik_ort = this.dr[4].ToString();
                    gu.Gu_yillik = this.dr[5].ToString();
                    gu.Gu_yillik_ort = this.dr[6].ToString();

                    genel_uretimler.Add(gu);
                }


            }
            this.dr.Close();
            this.dr.Dispose();

            return genel_uretimler;
        }
        public List<Yol_bazinda_uretim_ozet> d_hh_ybuo_data_read(string tarih, string firma = "DILER", string unite = "HH-ORTAK")
        {
            List<Yol_bazinda_uretim_ozet> ybuo = new List<Yol_bazinda_uretim_ozet>();
            string sql_hh_ortak = "SELECT BILGITNM,K1,K2,K14 FROM API_DB_001_Y " +
                                  "WHERE TARIH=" + tarih + " AND FIRMA='" + firma + "' AND UNITE='" + unite + "' AND TABLOTIP='URETIM_OZET' "+
                                  "ORDER BY CAST(BILGISIRANO AS INT)";
            this.cmd.CommandText = sql_hh_ortak;
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

                        // uo.Net_urt = Convert.ToDouble(this.dr[2].ToString().Equals("") ? "0.0" : this.dr[2]).ToString("###.###.###");

                        uo.Net_urt = this.dr[2].ToString();
                        uo.Mamul = this.dr[3].ToString();

                        ybuo.Add(uo);
                    }
                }
                catch
                {
                    throw;
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return ybuo;
        }
        public List<Duruslar> duruslar_hh_data_read(string tarih, string firma = "DILER", string unite = "HH", string tablotip = "DURUS_OZET")
        {
            List<Duruslar> duruslar = new List<Duruslar>();

            string sql_durus_hh = "SELECT BILGITNM,K1,K2,K3,K4,K5,K6,K7,K8,K9 FROM API_DB_001_Y " +
                                  "WHERE TARIH=" + tarih + " AND FIRMA='" + firma + "' AND UNITE='" + unite + "' AND TABLOTIP='" + tablotip + "' "+
                                  "ORDER BY CAST(BILGISIRANO AS INT)";
            this.cmd.CommandText = sql_durus_hh;
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
                try
                {
                    while (this.dr.Read())
                    {
                        Duruslar d = new Duruslar();
                        d.Durus_id = 1;
                        d.Durus_nedeni = this.dr[0].ToString();
                        d.Gun_sure = this.dr[1].ToString();
                        d.Gun_tekrar = this.dr[2].ToString();
                        d.Gun_yuzde = this.dr[3].ToString();
                        d.Ay_yuzde = this.dr[6].ToString();
                        d.Yil_yuzde = this.dr[9].ToString();
                        //if (firma != "YAZICI")
                        //{
                        //    d.Ay_sure = Convert.ToDouble(this.dr[4].ToString().Equals("") ? 0 : this.dr[4]).ToString("###,###.###");
                        //    d.Ay_tekrar = Convert.ToDouble(this.dr[5].ToString().Equals("") ? 0 : this.dr[5]).ToString("###,###.###");

                        //    d.Yil_sure = Convert.ToDouble(this.dr[7].ToString().Equals("") ? 0 : this.dr[7]).ToString("###,###.###");
                        //    d.Yil_tekrar = Convert.ToDouble(this.dr[8].ToString().Equals("") ? 0 : this.dr[8]).ToString("###,###.###");
                        //}
                        //else
                        //{
                        d.Ay_sure = this.dr[4].ToString();
                        d.Ay_tekrar = this.dr[5].ToString();

                        d.Yil_sure = this.dr[7].ToString();
                        d.Yil_tekrar = this.dr[8].ToString();


                        duruslar.Add(d);
                    }
                }
                catch
                {
                    throw;
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return duruslar;
        }


        /** Filmasin */
        public List<Kangal_uretim> kangal_uretim_data_read(string tarih, string firma = "FILMASIN", string unite = "KNG", string tablotip = "KNG_URETIM")
        {
            List<Kangal_uretim> kangal_uretim = new List<Kangal_uretim>();
            this.sql = "SELECT BILGITNM,K1,K2,K3,K4,K5 FROM API_DB_001_Y " +
                       "WHERE TARIH=" + tarih + " AND FIRMA='" + firma + "' AND UNITE = '" + unite + "' AND TABLOTIP ='" + tablotip + "' " +
                       "ORDER BY CAST(BILGISIRANO AS INT)";
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Kangal_uretim ku = new Kangal_uretim();
                ku.Uretim_bilgitnm = "Listelenecek kayıt bulunamadı.";
                ku.Uretim_id = 0;
                kangal_uretim.Add(ku);
            }
            else
            {
                try
                {
                    while (this.dr.Read())
                    {
                        Kangal_uretim ku = new Kangal_uretim();
                        ku.Uretim_id = 1;
                        ku.Uretim_bilgitnm = this.dr[0].ToString();
                        ku.Gunluk = this.dr[1].ToString();
                        ku.Aylik = this.dr[2].ToString();
                        ku.Aylik_ort = this.dr[3].ToString();
                        ku.Yillik = this.dr[4].ToString();
                        ku.Yillik_ort = this.dr[5].ToString();

                        kangal_uretim.Add(ku);
                    }
                }
                catch
                {
                    throw;
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return kangal_uretim;
        }
        public List<Kangal_uretim_ozet> kangal_uretim_ozet_data_read(string tarih, string firma = "FILMASIN", string unite = "KNG")
        {
            List<Kangal_uretim_ozet> kangal_uretim_ozet = new List<Kangal_uretim_ozet>();
            this.sql = "SELECT BILGITNM,K1,K2 FROM API_DB_001_Y " +
                       "WHERE TARIH=" + tarih + " AND FIRMA='" + firma + "' AND UNITE = '" + unite + "' AND TABLOTIP ='KNG_URETIM_OZET' "+
                       "ORDER BY CAST(BILGISIRANO AS INT)";
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Kangal_uretim_ozet kuo = new Kangal_uretim_ozet();
                kuo.Kalite = "Listelenecek kayıt bulunamadı.";
                kuo.Uo_id = 0;
                kangal_uretim_ozet.Add(kuo);
            }
            else
            {
                try
                {
                    while (this.dr.Read())
                    {
                        Kangal_uretim_ozet kuo = new Kangal_uretim_ozet();
                        kuo.Uo_id = 1;
                        kuo.Cap = this.dr[0].ToString();
                        kuo.Kalite = this.dr[1].ToString();
                        kuo.Tonaj = this.dr[2].ToString();

                        kangal_uretim_ozet.Add(kuo);
                    }
                }
                catch
                {
                    throw;
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return kangal_uretim_ozet;
        }


        /** Ortak Rapor */
        public List<Ortak_rapor> ortak_rapor_data_read(string tarih, string firma = "RAPOR_ORTAK", string unite = "RAPOR_ORTAK")
        {
            List<Ortak_rapor> ortak_rapor = new List<Ortak_rapor>();
            this.sql = "SELECT BILGITNM,K1,K2,K3,K4,K5,K6,K7,K8,K9,K10,K11,K12,K13,K14,K15,K16 FROM API_DB_001_Y " +
                       "WHERE TARIH=" + tarih + " AND FIRMA='" + firma + "' AND UNITE='" + unite + "' AND TABLOTIP='RAPOR_ORTAK' "+
                       "ORDER BY CAST(BILGISIRANO AS INT)";
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Ortak_rapor or = new Ortak_rapor();
                or.Bilgitnm = " Listelenecek kayıt bulunamadı.";
                or.Ortak_rapor_id = 0;
                ortak_rapor.Add(or);
            }
            else
            {
                try
                {
                    while (this.dr.Read())
                    {
                        Ortak_rapor or = new Ortak_rapor();
                        or.Ortak_rapor_id = 1;
                        or.Bilgitnm = this.dr[0].ToString();
                        or.Diler_gun = this.dr[1].ToString();
                        or.Diler_gun_ort = this.dr[2].ToString();
                        or.Diler_ay = this.dr[3].ToString();
                        or.Diler_ay_ort = this.dr[4].ToString();
                        or.Diler_yil = this.dr[5].ToString();
                        or.Diler_yil_ort = this.dr[6].ToString();
                        or.Diler_yil_tempo = this.dr[7].ToString();
                        or.Yazici_gun = this.dr[8].ToString();
                        or.Yazici_gun_ort = this.dr[9].ToString();
                        or.Yazici_ay = this.dr[10].ToString();
                        or.Yazici_ay_ort = this.dr[11].ToString();
                        or.Yazici_yil = this.dr[12].ToString();
                        or.Yazici_yil_ort = this.dr[13].ToString();
                        or.Yazici_yil_tempo = this.dr[14].ToString();
                        or.Diler_toplam_yil_tempo = this.dr[15].ToString();
                        or.Yazici_toplam_yil_tempo = this.dr[16].ToString();

                        ortak_rapor.Add(or);
                    }
                }
                catch
                {
                    throw;
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return ortak_rapor;
        }



        /** Tonajlar */
        public List<Tonajlar> tonajlar_data_read(string firma, string unite, int yil = 1111)
        {
            DateTime dt = new DateTime();
            dt = DateTime.Now;

            List<Tonajlar> tonajlar = new List<Tonajlar>();
            this.sql = "SELECT YIL,AY,TONAJ " +
                       "FROM urthrk.API_DB_002 " +
                       "WHERE FIRMA='" + firma + "' AND UNITE='" + unite + "' AND YIL='" + yil + "' ORDER BY AY";

            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Tonajlar t = new Tonajlar();
                t.Yil = "Oops! Listelenecek kayıt bulunamadı.";
                t.Tonaj_id = 0;
                tonajlar.Add(t);
            }
            else
            {
                try
                {
                    while (this.dr.Read())
                    {
                        Tonajlar t = new Tonajlar();
                        t.Tonaj_id = 1;
                        t.Yil = this.dr[0].ToString();
                        t.Ay = this.dr[1].ToString();
                        t.Tonaj = this.dr[2].ToString();

                        tonajlar.Add(t);
                    }
                }
                catch
                {
                    throw;
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return tonajlar;
        }
        public List<Tonajlar> yillik_tonajlarch_data_read(string firma = "DILER", string unite = "CH", int yil = 1111)
        {
            DateTime dt = new DateTime();
            dt = DateTime.Now;


            List<Tonajlar> tonajlar = new List<Tonajlar>();
            this.sql = "SELECT YIL,SUM(TONAJ) " +
                       "FROM urthrk.API_DB_002  " +
                       "WHERE FIRMA='" + firma + "' AND UNITE='" + unite + "' GROUP BY YIL ORDER BY YIL ";

            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Tonajlar t = new Tonajlar();
                t.Yil = "Oops! Listelenecek kayıt bulunamadı.";
                t.Tonaj_id = 0;
                tonajlar.Add(t);
            }
            else
            {
                try
                {
                    while (this.dr.Read())
                    {
                        Tonajlar t = new Tonajlar();
                        t.Tonaj_id = 1;
                        t.Yil = this.dr[0].ToString();
                        t.Tonaj = this.dr[1].ToString();

                        tonajlar.Add(t);
                    }
                }
                catch
                {
                    throw;
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return tonajlar;
        }
        public List<Tonajlar> yillik_tonajlarhh_data_read(string firma, string unite)
        {
            DateTime dt = new DateTime();
            dt = DateTime.Now;


            List<Tonajlar> tonajlar = new List<Tonajlar>();
            this.sql = "SELECT YIL,SUM(TONAJ) " +
                       "FROM urthrk.API_DB_002  " +
                       "WHERE FIRMA='" + firma + "' AND UNITE='" + unite + "' AND YIL>2007  GROUP BY YIL ORDER BY YIL ";

            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Tonajlar t = new Tonajlar();
                t.Yil = "Oops! Listelenecek kayıt bulunamadı.";
                t.Tonaj_id = 0;
                tonajlar.Add(t);
            }
            else
            {
                try
                {
                    while (this.dr.Read())
                    {
                        Tonajlar t = new Tonajlar();
                        t.Tonaj_id = 1;
                        t.Yil = this.dr[0].ToString();
                        t.Tonaj = this.dr[1].ToString();

                        tonajlar.Add(t);
                    }
                }
                catch
                {
                    throw;
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return tonajlar;
        }

    }
}
