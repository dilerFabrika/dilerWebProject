using diler.Entity;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace diler.Dal
{
    public class EndMuh_raporlar_db
    {

        OracleConnection conn, conn_filmasin;
        string connetionString, connection_string, sql;
        OracleCommand cmd;
        OracleDataReader dr, dr2, dr3;
        public string tarih_parse, saat_parse;
        public double brm_tonaj, yeni_kutuk_tonaji;
        public string kalite_kod, ebat_kod, boy_kod;
        public int kutuksayisi, ktkdus, fie_hurda, fde_hurda, kontrol, egri_kutuk_sayisi;

        public EndMuh_raporlar_db()
        {
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



            //string dosya = "F:/CELIKHANE/DILER/stok/data/STOK.MDB";
            //connectionstring_access = "Provider=Microsoft.Jet.OLEDB.4.0;" +
            //                          "Data Source=F:/CELIKHANE/DILER/stok/data/STOK.MDB;" +
            //                          "Jet OLEDB:Database Password=" + "";
            //cmd_access = new OleDbCommand();
            //con_access = new OleDbConnection(connectionstring_access);

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
        public dynamic tarihFormat(int gelen)
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
        public dynamic saat_format(int gelen)
        {
            string saat = (gelen / 10000).ToString();
            int dk_saniye = gelen % 10000;
            string dk = (dk_saniye / 100).ToString();
            string saniye = (dk_saniye % 100).ToString();
            if (saat.Length == 1)
            {
                saat = "0" + saat;

            }
            if (dk.Length == 1)
            {
                dk = "0" + dk;

            }
            if (saniye.Length == 1)
            {
                saniye = "0" + saniye;
            }

            saat_parse = (saat + ":" + dk + ":" + saniye).ToString();
            return saat_parse;

        }

        /** Haddehane üretim raporu*/
        public List<Haddehane_ozet> hh_genel_uretim_data_read(string tarih, string tarih2)
        {
            List<Haddehane_ozet> hh_genel_uretim = new List<Haddehane_ozet>();
            this.sql = "SELECT TARIH,KTKCC,SUM(KTKTONAJ),MAMSTANDART,MAMCAP,MAMBOY,NYFD,SUM(MAMTONAJ),SUM(KISAPARCA)/1000,SUM(HBTONAJ),SUM(UBAS) " +
                        "FROM URTHRK.HHTARTHBKP WHERE TARIH BETWEEN '" + tarih + "' AND '" + tarih2 + "' " +
                        "GROUP BY KTKCC,MAMSTANDART,MAMCAP,MAMBOY,TARIH,NYFD " +
                        "ORDER BY TARIH ";

            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Haddehane_ozet h = new Haddehane_ozet();
                h.Hadde_bozugu = "";
                h.Id = 0;
                hh_genel_uretim.Add(h);
            }
            else
            {
                try
                {
                    while (this.dr.Read())
                    {
                        Haddehane_ozet h = new Haddehane_ozet();
                        h.Id = 1;

                        int cks_tarih = Convert.ToInt32(this.dr[0].ToString());
                        tarih_parse = tarihFormat(cks_tarih);
                        h.Tarih = tarih_parse;
                        h.Kutuk_kalitesi = this.dr[1].ToString();
                        h.Kutuk_tonaj = Convert.ToDouble(this.dr[2].ToString().Equals("") ? 0 : this.dr[2]).ToString();
                        h.Mamul_standart = this.dr[3].ToString();
                        h.Mamul_cap = this.dr[4].ToString();
                        h.Mamul_boy = this.dr[5].ToString();
                        h.Ny = this.dr[6].ToString().Replace("D", "").Trim();
                        h.Fd = this.dr[6].ToString().Replace("N", "").Trim();
                        h.Mamul_tonaj = Convert.ToDouble(this.dr[7].ToString().Equals("") ? 0 : this.dr[7]).ToString();
                        //h.Kisa_parca = Convert.ToDouble(this.dr[8].ToString().Equals("") ? 0 : this.dr[8]).ToString();
                        //h.Hadde_bozugu = this.dr[9].ToString();
                        //h.Ucbas = this.dr[10].ToString();
                        hh_genel_uretim.Add(h);
                    }
                }
                catch
                {
                    throw new System.InvalidOperationException("Bağlantı gerçekleştirilirken bir hata oluştu.Tekrar deneyiniz!");
                }
            }
            string sqlx = "SELECT " +
        "(SELECT SUM(KTKTONAJ) FROM URTHRK.HHTARTHBKP WHERE TARIH BETWEEN '" + tarih + "' AND '" + tarih2 + "') AS IS_KUTUKTONAJI," +
        "(SELECT  SUM(HBTONAJ) FROM URTHRK.HHTARTHBKP WHERE TARIH BETWEEN '" + tarih + "' AND '" + tarih2 + "') AS HADDEBOZUGU," +
        "(SELECT  SUM(UBAS) / 1000 FROM URTHRK.HHTARTHBKP WHERE TARIH BETWEEN '" + tarih + "' AND '" + tarih2 + "') AS UCBAS," +
        "(SELECT  SUM(KISAPARCA) / 1000 FROM URTHRK.HHTARTHBKP WHERE TARIH BETWEEN '" + tarih + "' AND '" + tarih2 + "') AS KISAPARCA," +
       " (SELECT  SUM(MAMTONAJ) FROM URTHRK.HHTARTHBKP WHERE TARIH BETWEEN '" + tarih + "' AND '" + tarih2 + "') AS MAMULTONAJI " +
       " FROM URTHRK.HHTARTKIRP WHERE ROWNUM = 1";
            this.cmd.CommandText = sqlx;
            this.dr = this.cmd.ExecuteReader();
            while (this.dr.Read())
            {
                Haddehane_ozet h = new Haddehane_ozet();
                h.Id = 1;
                h.Tarih = "TOPLAM";
                h.Kutuk_tonaj = Convert.ToDouble(this.dr[0].ToString().Equals("") ? 0 : this.dr[0]).ToString();
                h.Mamul_tonaj = Convert.ToDouble(this.dr[4].ToString().Equals("") ? 0 : this.dr[4]).ToString();
                h.Kisa_parca = Convert.ToDouble(this.dr[3].ToString().Equals("") ? 0 : this.dr[3]).ToString();
                h.Hadde_bozugu = Convert.ToDouble(this.dr[1].ToString().Equals("") ? 0 : this.dr[1]).ToString();
                h.Ucbas = Convert.ToDouble(this.dr[2].ToString().Equals("") ? 0 : this.dr[2]).ToString();
                hh_genel_uretim.Add(h);

            }
            this.dr.Close();
            this.dr.Dispose();

            return hh_genel_uretim;
        }


        /** izlenebilirlik iki tarih arası **/

        public List<Izlenebilirlik_bilgileri> tarihbazinda_kutuk_takip_ozet_read(int tarih = 0, int tarih2 = 0)
        {
            List<Izlenebilirlik_bilgileri> kayitlar = new List<Izlenebilirlik_bilgileri>();


            this.sql = "SELECT * FROM URTHRK.CH_GENEL_DATA ";
            if (tarih > 0 && tarih2 > 0)
            {
                this.sql += "WHERE DOKUMTAR >= " + tarih +
                        " AND DOKUMTAR <= " + tarih2 + "";
            }
            this.sql += "ORDER BY DNO";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Izlenebilirlik_bilgileri kayit = new Izlenebilirlik_bilgileri();
                kayit.Celik_cinsi = "Listelenecek Kayıt Bulunamadı !!";
                kayit.Id = 0;
                kayitlar.Add(kayit);
            }
            else
            {
                while (this.dr.Read())
                {
                    Izlenebilirlik_bilgileri kayit = new Izlenebilirlik_bilgileri();
                    kayit.Id = 1;
                    kayit.Dokum_no = Convert.ToInt32(this.dr[0]);
                    kayit.Celik_cinsi = this.dr[1].ToString();
                    int cks_tarih = Convert.ToInt32(this.dr[3].ToString());
                    tarih_parse = tarihFormat(cks_tarih);
                    kayit.Cikis_tarihi = tarih_parse;
                    kayit.Kutuk_sayisi = (Convert.ToInt32(this.dr[8].ToString().Equals("") ? "0" : this.dr[8].ToString()) +
                                         Convert.ToInt32(this.dr[9].ToString().Equals("") ? "0" : this.dr[9].ToString())).ToString();

                    kayit.Srj = this.dr[11].ToString();
                    kayit.Istif_adet = this.dr[12].ToString();
                    kayit.Kutuk_satis = this.dr[13].ToString();
                    kayit.Tel_cubuk_haddesi = (Convert.ToInt32(this.dr[18].ToString().Equals("") ? "0" : this.dr[18].ToString()) +
                                         Convert.ToInt32(this.dr[19].ToString().Equals("") ? "0" : this.dr[19].ToString())).ToString();
                    if (kayit.Tel_cubuk_haddesi == "0")
                    {
                        string sqly = "SELECT SUM(ADET) FROM URTHRK.CH_FILMASIN_KTK_TRANSFER WHERE DOKUMNO = " + kayit.Dokum_no + "";
                        this.cmd.CommandText = sqly;
                        this.dr3 = this.cmd.ExecuteReader();
                        while (this.dr3.Read())
                        {
                            kayit.Tel_cubuk_haddesi = Convert.ToInt32(this.dr3[0].ToString().Equals("") ? "0" : this.dr3[0].ToString()).ToString();
                        }
                    }
                    kayit.Ocak_onu = this.dr[14].ToString();
                    kayit.Firina_verilecek = this.dr[15].ToString();
                    kayit.Fid_hurda = this.dr[16].ToString();
                    kayit.Fde_hurda = this.dr[17].ToString();
                    kayit.Egri_kutuk_sayisi = this.dr[22].ToString();
                    kayit.Sonuc = ((Convert.ToInt32(kayit.Kutuk_sayisi.Equals("") ? "0" : kayit.Kutuk_sayisi)) -
                                    (Convert.ToInt32(kayit.Srj.Equals("") ? "0" : kayit.Srj) +
                                    Convert.ToInt32(kayit.Istif_adet.Equals("") ? "0" : kayit.Istif_adet) +
                                    Convert.ToInt32(kayit.Kutuk_satis.Equals("") ? "0" : kayit.Kutuk_satis) +
                                    Convert.ToInt32(kayit.Tel_cubuk_haddesi.Equals("") ? "0" : kayit.Tel_cubuk_haddesi) +
                                    Convert.ToInt32(kayit.Fid_hurda.Equals("") ? "0" : kayit.Fid_hurda) +
                                    Convert.ToInt32(kayit.Fde_hurda.Equals("") ? "0" : kayit.Fde_hurda) +
                                    Convert.ToInt32(kayit.Egri_kutuk_sayisi.Equals("") ? "0" : kayit.Egri_kutuk_sayisi))).ToString();
                    if (kayit.Sonuc == kayit.Kutuk_sayisi)
                    {

                        kayit.Sonuc = "0";
                    }

                    kayit.Aciklama = this.dr[2].ToString() + " " + this.dr[20].ToString() + "\n" + this.dr[21].ToString();


                    kayitlar.Add(kayit);
                }
            }


            this.dr.Close();
            this.dr.Dispose();


            return kayitlar;
        }


        /** Aylık alyaj takip*/
        public List<Aylik_alyaj_rapor_bilgileri> aylik_alyaj_data_read(string yil_ay)
        {
            List<Aylik_alyaj_rapor_bilgileri> alyajlar = new List<Aylik_alyaj_rapor_bilgileri>();
            string sql_a = "SELECT DISTINCT(KALITE),SUM(URETIM),SUM(HURDA), " +
                       "SUM(AO_KOK),SUM(PO_KOK),SUM(AO_KIREC),SUM(PO_KIREC),SUM(FESI),SUM(FESIMN), " +
                       "SUM(AL),SUM(ALWIRE),SUM(BOKSIT),SUM(CAC2),SUM(CAFE),SUM(CAF2),SUM(CASI),SUM(DOLAMIT),SUM(DOLAMITIKKIREC),SUM(FEB),SUM(FECR), " +
                       "SUM(FEMN),SUM(FEMNHCR),SUM(FEMNLOWC),SUM(FESILOWAL),SUM(FESIMN6030),SUM(FETI),SUM(FEV),SUM(KOLAMANIT),SUM(MGO),SUM(SILISKUMU) " +
                       "FROM URTHRK.CH_TARIH_ALYAJ_DATA WHERE TARIH LIKE '" + yil_ay + "%' GROUP BY KALITE ";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = sql_a;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Aylik_alyaj_rapor_bilgileri a = new Aylik_alyaj_rapor_bilgileri();
                a.Celik_cinsi = "Listelenecek Kayıt Bulunamadı !!";
                a.Id = 0;
                alyajlar.Add(a);
            }
            else
            {
                while (this.dr.Read())
                {
                    Aylik_alyaj_rapor_bilgileri a = new Aylik_alyaj_rapor_bilgileri();
                    a.Id = 1;
                    a.Celik_cinsi = this.dr[0].ToString();
                    a.Tonaj = this.dr[1].ToString();
                    a.Hurda = this.dr[2].ToString();
                    a.Aokok = this.dr[3].ToString();
                    a.Pokok = this.dr[4].ToString();
                    a.Aokirec = this.dr[5].ToString();
                    a.Pokirec = this.dr[6].ToString();
                    a.Fesi = this.dr[7].ToString();
                    a.Fesimn = this.dr[8].ToString();
                    a.Al = this.dr[9].ToString();
                    a.Alwire = this.dr[10].ToString();
                    a.Boksit = this.dr[11].ToString();
                    a.Cac2 = this.dr[12].ToString();
                    a.Cafe = this.dr[13].ToString();
                    a.Caf2 = this.dr[14].ToString();
                    a.Casi = this.dr[15].ToString();
                    a.Dolamit = this.dr[16].ToString();
                    a.Dolamitik_kirec = this.dr[17].ToString();
                    a.Feb = this.dr[18].ToString();
                    a.Fecr = this.dr[19].ToString();
                    a.Femn = this.dr[20].ToString();
                    a.Femnhcr = this.dr[21].ToString();
                    a.Femnlowc = this.dr[22].ToString();
                    a.Fesilowal = this.dr[23].ToString();
                    a.Fesimn6030 = this.dr[24].ToString();
                    a.Feti = this.dr[25].ToString();
                    a.Fev = this.dr[26].ToString();
                    a.Kolamanit = this.dr[27].ToString();
                    a.Mgo = this.dr[28].ToString();
                    a.Siliskumu = this.dr[29].ToString();
                    if (a.Tonaj != "" && a.Tonaj != "0")
                    {
                        a.Aokok_kg = (Convert.ToDouble(a.Aokok.Equals("") ? "0" : a.Aokok) / Convert.ToDouble(a.Tonaj)).ToString("0.##");
                        a.Pokok_kg = (Convert.ToDouble(a.Pokok.Equals("") ? "0" : a.Pokok) / Convert.ToDouble(a.Tonaj)).ToString("0.##");
                        a.Aokirec_kg = (Convert.ToDouble(a.Aokirec.Equals("") ? "0" : a.Aokirec) / Convert.ToDouble(a.Tonaj)).ToString("0.##");
                        a.Pokirec_kg = (Convert.ToDouble(a.Pokirec.Equals("") ? "0" : a.Pokirec) / Convert.ToDouble(a.Tonaj)).ToString("0.##");
                        a.Fesi_kg = (Convert.ToDouble(a.Fesi.Equals("") ? "0" : a.Fesi) / Convert.ToDouble(a.Tonaj)).ToString("0.##");
                        a.Fesimn_kg = (Convert.ToDouble(a.Fesimn.Equals("") ? "0" : a.Fesimn) / Convert.ToDouble(a.Tonaj)).ToString("0.##");
                        a.Al_kg = (Convert.ToDouble(a.Al.Equals("") ? "0" : a.Al) / Convert.ToDouble(a.Tonaj)).ToString("0.##");
                        a.Alwire_kg = (Convert.ToDouble(a.Alwire.Equals("") ? "0" : a.Alwire) / Convert.ToDouble(a.Tonaj)).ToString("0.##");
                        a.Boksit_kg = (Convert.ToDouble(a.Boksit.Equals("") ? "0" : a.Boksit) / Convert.ToDouble(a.Tonaj)).ToString("0.##");
                        a.Cac2_kg = (Convert.ToDouble(a.Cac2.Equals("") ? "0" : a.Cac2) / Convert.ToDouble(a.Tonaj)).ToString("0.##");
                        a.Cafe_kg = (Convert.ToDouble(a.Cafe.Equals("") ? "0" : a.Cafe) / Convert.ToDouble(a.Tonaj)).ToString("0.##");
                        a.Caf2_kg = (Convert.ToDouble(a.Caf2.Equals("") ? "0" : a.Caf2) / Convert.ToDouble(a.Tonaj)).ToString("0.##");
                        a.Casi_kg = (Convert.ToDouble(a.Casi.Equals("") ? "0" : a.Casi) / Convert.ToDouble(a.Tonaj)).ToString("0.##");
                        a.Dolamit_kg = (Convert.ToDouble(a.Dolamit.Equals("") ? "0" : a.Dolamit) / Convert.ToDouble(a.Tonaj)).ToString("0.##");
                        a.Dolamitik_kirec_kg = (Convert.ToDouble(a.Dolamitik_kirec.Equals("") ? "0" : a.Dolamitik_kirec) / Convert.ToDouble(a.Tonaj)).ToString("0.##");
                        a.Feb_kg = (Convert.ToDouble(a.Feb.Equals("") ? "0" : a.Feb) / Convert.ToDouble(a.Tonaj)).ToString("0.##");
                        a.Fecr_kg = (Convert.ToDouble(a.Fecr.Equals("") ? "0" : a.Fecr) / Convert.ToDouble(a.Tonaj)).ToString("0.##");
                        a.Femn_kg = (Convert.ToDouble(a.Femn.Equals("") ? "0" : a.Femn) / Convert.ToDouble(a.Tonaj)).ToString("0.##");
                        a.Femnhcr_kg = (Convert.ToDouble(a.Femnhcr.Equals("") ? "0" : a.Femnhcr) / Convert.ToDouble(a.Tonaj)).ToString("0.##");
                        a.Femnlowc_kg = (Convert.ToDouble(a.Femnlowc.Equals("") ? "0" : a.Femnlowc) / Convert.ToDouble(a.Tonaj)).ToString("0.##");
                        a.Fesilowal_kg = (Convert.ToDouble(a.Fesilowal.Equals("") ? "0" : a.Fesilowal) / Convert.ToDouble(a.Tonaj)).ToString("0.##");
                        a.Fesimn6030_kg = (Convert.ToDouble(a.Fesimn6030.Equals("") ? "0" : a.Fesimn6030) / Convert.ToDouble(a.Tonaj)).ToString("0.##");
                        a.Feti_kg = (Convert.ToDouble(a.Feti.Equals("") ? "0" : a.Feti) / Convert.ToDouble(a.Tonaj)).ToString("0.##");
                        a.Fev_kg = (Convert.ToDouble(a.Fev.Equals("") ? "0" : a.Fev) / Convert.ToDouble(a.Tonaj)).ToString("0.##");
                        a.Kolamanit_kg = (Convert.ToDouble(a.Kolamanit.Equals("") ? "0" : a.Kolamanit) / Convert.ToDouble(a.Tonaj)).ToString("0.##");
                        a.Mgo_kg = (Convert.ToDouble(a.Mgo.Equals("") ? "0" : a.Mgo) / Convert.ToDouble(a.Tonaj)).ToString("0.##");
                        a.Siliskumu_kg = (Convert.ToDouble(a.Siliskumu.Equals("") ? "0" : a.Siliskumu) / Convert.ToDouble(a.Tonaj)).ToString("0.##");

                    }

                    alyajlar.Add(a);
                }
            }
            return alyajlar;
        }



        /** Net çalışma*/

        public List<Net_calisma> cubuk_haddehane_data_read(string yil_ay)
        {
            List<Net_calisma> net_calismalar = new List<Net_calisma>();

            this.sql = "SELECT CAP,NYFD,SUM(DURUS),SUM(NCS),SUM(TONAJ),(SUM(KISAPARCA)/1000),SUM(KUTUKTONAJI) FROM URTHRK.NETCALSURE" +
                " WHERE TARIH LIKE '" + yil_ay + "%' GROUP BY CAP,NYFD ORDER BY CAP";

            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Net_calisma a = new Net_calisma();
                a.Durus = "Listelenecek Kayıt Bulunamadı!";
                a.Id = 0;
                net_calismalar.Add(a);
            }
            else
            {
                while (this.dr.Read())
                {
                    Net_calisma a = new Net_calisma();
                    a.Id = 1;
                    a.Cap = this.dr[0].ToString();
                    a.Nyfd = this.dr[1].ToString().Replace("D", "").Trim();
                    a.Durus = this.dr[2].ToString();
                    a.Net_calisma_suresi = this.dr[3].ToString();
                    a.Tonaj_kisaparca = (Convert.ToDouble(this.dr[4].ToString().Equals("") ? "0" : this.dr[4].ToString()) +
                        Convert.ToDouble(this.dr[5].ToString().Equals("") ? "0" : this.dr[5].ToString())).ToString();
                    a.Kutuk_tonaj = Convert.ToDouble(this.dr[6].ToString().Equals("") ? "0" : this.dr[6].ToString()).ToString();

                    net_calismalar.Add(a);
                }
            }


            this.sql = "SELECT SUM(DURUS),SUM(NCS),SUM(TONAJ),(SUM(KISAPARCA)/1000),SUM(KUTUKTONAJI) FROM URTHRK.NETCALSURE" +
                " WHERE TARIH LIKE '" + yil_ay + "%'";
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            while (this.dr.Read())
            {
                Net_calisma a = new Net_calisma();
                a.Id = 1;
                a.Cap = "TOPLAM";
                a.Durus = this.dr[0].ToString();
                a.Net_calisma_suresi = this.dr[1].ToString();
                a.Tonaj_kisaparca = (Convert.ToDouble(this.dr[2].ToString().Equals("") ? "0" : this.dr[2].ToString()) +
                    Convert.ToDouble(this.dr[3].ToString().Equals("") ? "0" : this.dr[3].ToString())).ToString();
                a.Kutuk_tonaj = Convert.ToDouble(this.dr[4].ToString().Equals("") ? "0" : this.dr[4].ToString()).ToString();

                net_calismalar.Add(a);
            }

            return net_calismalar;
        }
        public List<Net_calisma> tel_cubuk_haddehane_data_read(string yil_ay)
        {
            List<Net_calisma> net_calismalar = new List<Net_calisma>();
            this.sql = "SELECT CAP, NYFD, SUM(DURUS), AMBARDEPO, SUM(NCS), SUM(TONAJ), SUM(KTKTONAJ) " +
                   "FROM URTHRK.NETCALSURE_FLM_AYRINTILI WHERE TARIH LIKE '" + yil_ay + "%' GROUP BY CAP, NYFD, AMBARDEPO ORDER BY CAP";

            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Net_calisma a = new Net_calisma();
                a.Durus = "Listelenecek Kayıt Bulunamadı!";
                a.Id = 0;
                net_calismalar.Add(a);
            }
            else
            {
                while (this.dr.Read())
                {
                    Net_calisma a = new Net_calisma();
                    a.Id = 1;
                    a.Cap = this.dr[0].ToString();
                    a.Nyfd = this.dr[1].ToString();
                    a.Durus = this.dr[2].ToString();
                    a.Ambardepo = this.dr[3].ToString();
                    a.Net_calisma_suresi = this.dr[4].ToString();

                    a.Tonaj = Convert.ToDouble(this.dr[5].ToString().Equals("") ? "0" : this.dr[5].ToString()).ToString();
                    a.Kutuk_tonaj = Convert.ToDouble(this.dr[6].ToString().Equals("") ? "0" : this.dr[6].ToString()).ToString();

                    net_calismalar.Add(a);
                }
            }
            this.sql = "SELECT SUM(DURUS),SUM(NCS),SUM(TONAJ),SUM(KTKTONAJ) FROM URTHRK.NETCALSURE_FLM_AYRINTILI" +
                " WHERE TARIH LIKE '" + yil_ay + "%'";
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            while (this.dr.Read())
            {
                Net_calisma a = new Net_calisma();
                a.Id = 1;
                a.Cap = "TOPLAM";
                a.Durus = this.dr[0].ToString();
                a.Net_calisma_suresi = this.dr[1].ToString();
                a.Tonaj = Convert.ToDouble(this.dr[2].ToString().Equals("") ? "0" : this.dr[2].ToString()).ToString();
                a.Kutuk_tonaj = Convert.ToDouble(this.dr[3].ToString().Equals("") ? "0" : this.dr[3].ToString()).ToString();

                net_calismalar.Add(a);
            }
            return net_calismalar;
        }



        /** Haddehane üretim vardiya özet*/
        public List<Hh_vrd_Ozet> ozet_data_read(string tarih)
        {
            List<Hh_vrd_Ozet> hh_vrd_ozet = new List<Hh_vrd_Ozet>();

            this.sql = "SELECT VRD,SUM(KTKTONAJ),SUM(MAMTONAJ),SUM(KISAPARCA)/1000,SUM(HBTONAJ),SUM(UBAS)/1000 FROM URTHRK.HHTARTHBKP WHERE TARIH=" + tarih + " GROUP BY VRD";

            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Hh_vrd_Ozet h = new Hh_vrd_Ozet();
                h.Hadde_bozugu = " Listelenecek kayıt bulunamadı.";
                h.Id = 0;
                hh_vrd_ozet.Add(h);
            }
            else
            {
                try
                {
                    while (this.dr.Read())
                    {
                        Hh_vrd_Ozet h = new Hh_vrd_Ozet();
                        h.Id = 1;
                        h.Vrd = this.dr[0].ToString();
                        h.Kutuk_tonaj = Convert.ToDouble(this.dr[1].ToString().Equals("") ? "0" : this.dr[1].ToString()).ToString();
                        h.Mamul_tonaj = Convert.ToDouble(this.dr[2].ToString().Equals("") ? "0" : this.dr[2].ToString()).ToString();
                        h.Kisa_parca(this.dr[3].ToString());
                        h.Hadde_bozugu = Convert.ToDouble(this.dr[4].ToString().Equals("") ? "0" : this.dr[4].ToString()).ToString();
                        h.Ucbas = this.dr[5].ToString();

                        hh_vrd_ozet.Add(h);
                    }
                }
                catch
                {
                    throw new System.InvalidOperationException("Bağlantı gerçekleştirilirken bir hata oluştu.Tekrar deneyiniz!");
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return hh_vrd_ozet;
        }
        public List<Hh_vrd_Ozet> imalata_sevk_edilen_kutuk_bilgileri_data_read(string tarih)
        {
            List<Hh_vrd_Ozet> hh_vrd_ozet = new List<Hh_vrd_Ozet>();

            this.sql = "SELECT VRD, KTKCC, KTKEBAT, KTKBOY, SUM(KTKSAY), SUM(KTKTONAJ),SUM(OCAKONU) " +
                "FROM URTHRK.HHTARTHBKP WHERE TARIH = " + tarih + " GROUP BY VRD, KTKCC, KTKEBAT, KTKBOY";

            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Hh_vrd_Ozet h = new Hh_vrd_Ozet();
                h.Hadde_bozugu = " Listelenecek kayıt bulunamadı.";
                h.Id = 0;
                hh_vrd_ozet.Add(h);
            }
            else
            {
                try
                {
                    while (this.dr.Read())
                    {
                        Hh_vrd_Ozet h = new Hh_vrd_Ozet();
                        h.Id = 1;
                        h.Vrd = this.dr[0].ToString();
                        h.Kutuk_kalitesi = this.dr[1].ToString();
                        h.Kutuk_ebat = this.dr[2].ToString();
                        h.Kutuk_boy = this.dr[3].ToString();
                        h.Kutuk_adet = this.dr[4].ToString();
                        h.Kutuk_tonaj = Convert.ToDouble(this.dr[5].ToString().Equals("") ? "0" : this.dr[5].ToString()).ToString();
                        h.Iade = this.dr[6].ToString();

                        hh_vrd_ozet.Add(h);
                    }
                }
                catch
                {
                    throw new System.InvalidOperationException("Bağlantı gerçekleştirilirken bir hata oluştu.Tekrar deneyiniz!");
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return hh_vrd_ozet;
        }
        public List<Hh_vrd_Ozet> imal_olunan_mamul_bilgileri_data_read(string tarih)
        {
            List<Hh_vrd_Ozet> hh_vrd_ozet = new List<Hh_vrd_Ozet>();

            this.sql = "SELECT VRD, MAMSTANDART, MAMCAP, MAMBOY, NYFD,(MAMTONAJ) FROM URTHRK.HHTARTHBKP WHERE TARIH = " + tarih + " ORDER BY VRD, MAMTONAJ DESC";

            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Hh_vrd_Ozet h = new Hh_vrd_Ozet();
                h.Hadde_bozugu = " Listelenecek kayıt bulunamadı.";
                h.Id = 0;
                hh_vrd_ozet.Add(h);
            }
            else
            {
                try
                {
                    while (this.dr.Read())
                    {
                        Hh_vrd_Ozet h = new Hh_vrd_Ozet();
                        h.Id = 1;
                        h.Vrd = this.dr[0].ToString();
                        h.Mamul_standart = this.dr[1].ToString();
                        h.Mamul_cap = this.dr[2].ToString();
                        h.Mamul_boy = this.dr[3].ToString();
                        h.Ny = this.dr[4].ToString().Replace("D", "").Trim();
                        h.Fd = this.dr[4].ToString().Replace("N", "").Trim();
                        h.Mamul_tonaj = Convert.ToDouble(this.dr[5].ToString().Equals("") ? "0" : this.dr[5].ToString()).ToString();
                        hh_vrd_ozet.Add(h);
                    }
                }
                catch
                {
                    throw new System.InvalidOperationException("Bağlantı gerçekleştirilirken bir hata oluştu.Tekrar deneyiniz!");
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return hh_vrd_ozet;
        }



        /** Filmasin üretim raporu*/
        public List<Hh_vrd_Ozet> filmasin_genel_uretim_data_read(string tarih, string tarih2)
        {
            List<Hh_vrd_Ozet> filmasin_genel_uretim = new List<Hh_vrd_Ozet>();

            this.sql = "SELECT TARIH, KALITE, SUM(GIRISTARTIM) / 1000, MAMKALITE,CAP,ND " +
           " FROM FILMASIN.FLMURT WHERE TARIH BETWEEN '" + tarih + "' AND '" + tarih2 + "' AND MAMTIP <> 'C' AND DURUM NOT IN(0,9) " +
            "GROUP BY KALITE, CAP, TARIH, ND, MAMKALITE " +
            "ORDER BY TARIH, CAP DESC ";

            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Hh_vrd_Ozet h = new Hh_vrd_Ozet();
                h.Hadde_bozugu = " Listelenecek kayıt bulunamadı.";
                h.Id = 0;
                filmasin_genel_uretim.Add(h);
            }
            else
            {
                try
                {
                    while (this.dr.Read())
                    {
                        Hh_vrd_Ozet h = new Hh_vrd_Ozet();
                        h.Id = 1;
                        int cks_tarih = Convert.ToInt32(this.dr[0].ToString());
                        tarih_parse = tarihFormat(cks_tarih);
                        h.Tarih = tarih_parse;
                        h.Kutuk_kalitesi = this.dr[1].ToString();
                        h.Kutuk_tonaj = Convert.ToDouble(this.dr[2].ToString().Equals("") ? 0 : this.dr[2]).ToString();
                        h.Mamul_standart = this.dr[3].ToString();
                        h.Mamul_cap = this.dr[4].ToString();
                        h.Ny = this.dr[5].ToString();

                        string sql_mamtonaj = "SELECT " +
         "(SELECT SUM(GERCEK_TARTIM) / 1000 FROM FILMASIN.FLMURT WHERE TARIH = " + cks_tarih + " " +
         " AND MAMTIP <> 'C' AND  DURUM IN(1, 2, 6, 7) AND CAP ='" + h.Mamul_cap + "' AND MAMKALITE = '" + h.Mamul_standart + "' AND KALITE = '" + h.Kutuk_kalitesi + "' ) AS MAMTONAJ," +

         "(SELECT SUM(GERCEK_TARTIM) / 1000 FROM FILMASIN.FLMURT WHERE TARIH = " + cks_tarih + " AND MAMTIP <> 'C' AND  DURUM IN(1, 2, 6, 7) AND CAP ='" + h.Mamul_cap + "' " +
         " AND MAMKALITE ='" + h.Mamul_standart + "'  AND KALITE ='" + h.Kutuk_kalitesi + "' AND  SIPARIS_DURUMU_SONRA = 'Hurda' ) AS HURDAOLMAYAN_MAMTONAJ " +
         "FROM FILMASIN.FLMURT WHERE TARIH = " + cks_tarih + " AND ROWNUM = 1";
                        this.cmd.CommandText = sql_mamtonaj;
                        this.dr2 = this.cmd.ExecuteReader();
                        if (!this.dr2.HasRows)
                        {

                            h.Mamul_tonaj = "0";
                        }
                        else
                        {
                            while (this.dr2.Read())
                            {

                                h.Mamul_tonaj = (Convert.ToDouble(this.dr2[0].ToString().Equals("") ? "0" : this.dr2[0].ToString()) -
                                    Convert.ToDouble(this.dr2[1].ToString().Equals("") ? "0" : this.dr2[1].ToString())).ToString();

                            }
                        }
                        filmasin_genel_uretim.Add(h);


                    }
                }
                catch
                {
                    throw new System.InvalidOperationException("Bağlantı gerçekleştirilirken bir hata oluştu.Tekrar deneyiniz!");
                }
            }

            //Toplam
            string sqlx = "SELECT " +
        "(SELECT SUM(GIRISTARTIM) / 1000 FROM FILMASIN.FLMURT WHERE TARIH BETWEEN '" + tarih + "' AND '" + tarih2 + "'  AND DURUM IN(3, 4, 5)  AND MAMTIP <> 'C' ) AS A, " +
        "(SELECT SUM(HBTONAJ) FROM FILMASIN.FLMURT WHERE TARIH BETWEEN '" + tarih + "' AND '" + tarih2 + "'  AND DURUM IN(1, 2, 6, 7)  AND MAMTIP <> 'C' ) AS B," +
        "(SELECT SUM(GERCEK_TARTIM) / 1000 FROM FILMASIN.FLMURT WHERE TARIH BETWEEN '" + tarih + "' AND '" + tarih2 + "'  AND DURUM IN(1, 2, 6, 7) AND  SIPARIS_DURUMU_SONRA='Hurda'  AND MAMTIP <> 'C') AS C," +
        "(SELECT SUM(UBTONAJ)+SUM(UCKUYRUKTONAJ) FROM FILMASIN.FLMURT WHERE TARIH BETWEEN '" + tarih + "' AND '" + tarih2 + "'  AND DURUM IN(1, 2, 6, 7) AND MAMTIP <> 'C') AS UCBAS," +
        "(SELECT SUM(GERCEK_TARTIM) / 1000 FROM FILMASIN.FLMURT WHERE TARIH BETWEEN '" + tarih + "' AND '" + tarih2 + "'   AND MAMTIP <> 'C' AND DURUM NOT IN(0,3,4,5,9) ) AS MAMTONAJ," +
        "(SELECT SUM(GIRISTARTIM) / 1000 FROM FILMASIN.FLMURT WHERE TARIH BETWEEN '" + tarih + "' AND '" + tarih2 + "'  AND MAMTIP <> 'C' AND DURUM NOT IN(0,9)) AS KUTUKTONAJ  " +
        " FROM FILMASIN.FLMURT WHERE TARIH BETWEEN '" + tarih + "' AND '" + tarih2 + "'  AND ROWNUM = 1 GROUP BY VRD";
            this.cmd.CommandText = sqlx;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                Hh_vrd_Ozet h = new Hh_vrd_Ozet();
                h.Id = 0;
                h.Mamul_tonaj = "0";
                h.Kutuk_tonaj = "0";
                h.Hadde_bozugu = "0";
                h.Ucbas = "0";
            }
            else
            {
                while (this.dr.Read())
                {
                    Hh_vrd_Ozet h = new Hh_vrd_Ozet();
                    h.Id = 1;
                    h.Tarih = "TOPLAM";
                    h.Kutuk_tonaj = Convert.ToDouble(this.dr[5].ToString().Equals("") ? 0 : this.dr[5]).ToString();
                    h.Hadde_bozugu = (Convert.ToDouble(this.dr[0].ToString().Equals("") ? "0" : this.dr[0].ToString()) +
                        Convert.ToDouble(this.dr[1].ToString().Equals("") ? "0" : this.dr[1].ToString()) +
                        Convert.ToDouble(this.dr[2].ToString().Equals("") ? "0" : this.dr[2].ToString())).ToString();

                    h.Mamul_tonaj = (Convert.ToDouble(this.dr[4].ToString().Equals("") ? "0" : this.dr[4].ToString()) -
                      Convert.ToDouble(this.dr[2].ToString().Equals("") ? "0" : this.dr[2].ToString())).ToString();

                    h.Ucbas = Convert.ToDouble(this.dr[3].ToString().Equals("") ? "0" : this.dr[3].ToString()).ToString();
                    filmasin_genel_uretim.Add(h);

                }
            }


            this.dr.Close();
            this.dr.Dispose();

            return filmasin_genel_uretim;
        }



        /** Filmasin üretim vardiya özet*/
        public List<Hh_vrd_Ozet> flm_ozet_data_read(string tarih)
        {
            List<Hh_vrd_Ozet> hh_vrd_ozet = new List<Hh_vrd_Ozet>();

            this.sql = "SELECT VRD,SUM(GIRISTARTIM)/1000,SUM(GERCEK_TARTIM)/1000  " +
                " FROM FILMASIN.FLMURT  WHERE TARIH=" + tarih + " GROUP BY VRD";

            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Hh_vrd_Ozet h = new Hh_vrd_Ozet();
                h.Hadde_bozugu = " Listelenecek kayıt bulunamadı.";
                h.Id = 0;
                hh_vrd_ozet.Add(h);
            }
            else
            {
                try
                {
                    while (this.dr.Read())
                    {
                        Hh_vrd_Ozet h = new Hh_vrd_Ozet();
                        h.Id = 1;
                        h.Vrd = this.dr[0].ToString();
                        h.Kutuk_tonaj = Convert.ToDouble(this.dr[1].ToString().Equals("") ? "0" : this.dr[1].ToString()).ToString();

                        string sqlx = "SELECT " +
                "(SELECT SUM(GIRISTARTIM) / 1000 FROM FILMASIN.FLMURT WHERE TARIH =" + tarih + " AND DURUM IN(3, 4, 5) AND  VRD =" + h.Vrd + ") AS A, " +
                "(SELECT SUM(HBTONAJ) FROM FILMASIN.FLMURT WHERE TARIH =" + tarih + " AND DURUM IN(1, 2, 6, 7) AND  VRD =" + h.Vrd + ") AS B," +
                "(SELECT SUM(GERCEK_TARTIM) / 1000 FROM FILMASIN.FLMURT WHERE TARIH =" + tarih + " AND DURUM IN(1, 2, 6, 7)  AND  VRD =" + h.Vrd + " AND  SIPARIS_DURUMU_SONRA = 'Hurda') AS C," +
                "(SELECT SUM(UBTONAJ) + SUM(UCKUYRUKTONAJ) FROM FILMASIN.FLMURT WHERE TARIH =" + tarih + " AND DURUM NOT IN(3, 4, 5) AND  VRD =" + h.Vrd + " ) AS D " +
                "FROM FILMASIN.FLMURT WHERE TARIH =" + tarih + " AND VRD =" + h.Vrd + " AND ROWNUM = 1";
                        this.cmd.CommandText = sqlx;
                        this.dr2 = this.cmd.ExecuteReader();
                        while (this.dr2.Read())
                        {
                            h.Hadde_bozugu = (Convert.ToDouble(this.dr2[0].ToString().Equals("") ? "0" : this.dr2[0].ToString()) +
                                Convert.ToDouble(this.dr2[1].ToString().Equals("") ? "0" : this.dr2[1].ToString()) +
                                Convert.ToDouble(this.dr2[2].ToString().Equals("") ? "0" : this.dr2[2].ToString())).ToString();
                            h.Mamul_tonaj = h.Mamul_tonaj = (Convert.ToDouble(this.dr[2].ToString().Equals("") ? 0 : this.dr[2]) -
                                Convert.ToDouble(this.dr2[2].ToString().Equals("") ? "0" : this.dr2[2].ToString())).ToString();
                            h.Ucbas = Convert.ToDouble(this.dr2[3].ToString().Equals("") ? "0" : this.dr2[3].ToString()).ToString();
                        }

                        hh_vrd_ozet.Add(h);
                    }
                }
                catch
                {
                    throw new System.InvalidOperationException("Bağlantı gerçekleştirilirken bir hata oluştu.Tekrar deneyiniz!");
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return hh_vrd_ozet;
        }
        public List<Hh_vrd_Ozet> flm_imalata_sevk_edilen_kutuk_bilgileri_data_read(string tarih)
        {
            List<Hh_vrd_Ozet> hh_vrd_ozet = new List<Hh_vrd_Ozet>();

            this.sql = "SELECT VRD, KALITE, EBAT, BOY, SUM(GIRISTARTIM)/1000,COUNT(KTKID) " +
                "FROM FILMASIN.FLMURT  WHERE TARIH = " + tarih + " GROUP BY VRD, KALITE, EBAT,BOY ORDER BY VRD";

            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Hh_vrd_Ozet h = new Hh_vrd_Ozet();
                h.Hadde_bozugu = " Listelenecek kayıt bulunamadı.";
                h.Id = 0;
                hh_vrd_ozet.Add(h);
            }
            else
            {
                try
                {
                    while (this.dr.Read())
                    {
                        Hh_vrd_Ozet h = new Hh_vrd_Ozet();
                        h.Id = 1;
                        h.Vrd = this.dr[0].ToString();
                        h.Kutuk_kalitesi = this.dr[1].ToString();
                        h.Kutuk_ebat = this.dr[2].ToString();
                        h.Kutuk_boy = this.dr[3].ToString();
                        h.Iade = "0";
                        h.Kutuk_tonaj = Convert.ToDouble(this.dr[4].ToString().Equals("") ? "0" : this.dr[4].ToString()).ToString();
                        h.Kutuk_adet = this.dr[5].ToString();

                        hh_vrd_ozet.Add(h);
                    }
                }
                catch
                {
                    throw new System.InvalidOperationException("Bağlantı gerçekleştirilirken bir hata oluştu.Tekrar deneyiniz!");
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return hh_vrd_ozet;
        }
        public List<Hh_vrd_Ozet> flm_imal_olunan_mamul_bilgileri_data_read(string tarih)
        {
            List<Hh_vrd_Ozet> hh_vrd_ozet = new List<Hh_vrd_Ozet>();

            this.sql = "SELECT VRD, MAMKALITE, CAP, ND,SUM(GERCEK_TARTIM)/1000,BOY FROM FILMASIN.FLMURT  WHERE TARIH = " + tarih + " " +
                "GROUP BY MAMKALITE,BOY,VRD,CAP,ND ORDER BY VRD,MAMKALITE,CAP,ND DESC";
            try
            {
                this.cmd.CommandText = this.sql;
                this.dr = this.cmd.ExecuteReader();
                if (!this.dr.HasRows)
                {
                    //kayit bulunamadiysa
                    Hh_vrd_Ozet h = new Hh_vrd_Ozet();
                    h.Hadde_bozugu = " Listelenecek kayıt bulunamadı.";
                    h.Id = 0;
                    hh_vrd_ozet.Add(h);
                }
                else
                {

                    while (this.dr.Read())
                    {
                        Hh_vrd_Ozet h = new Hh_vrd_Ozet();
                        h.Id = 1;
                        h.Vrd = this.dr[0].ToString();
                        h.Mamul_standart = this.dr[1].ToString();
                        h.Mamul_cap = this.dr[2].ToString();
                        h.Ny = this.dr[3].ToString();
                        string sqly = "SELECT SUM(GERCEK_TARTIM) / 1000 FROM FILMASIN.FLMURT " +
                         "WHERE TARIH =" + tarih + " AND DURUM IN(1, 2, 6, 7) AND  SIPARIS_DURUMU_SONRA = 'Hurda' AND KALITE='" + h.Mamul_standart + "' AND VRD=" + h.Vrd + "";
                        this.cmd.CommandText = sqly;
                        this.dr2 = this.cmd.ExecuteReader();
                        while (this.dr2.Read())
                        {

                            h.Mamul_tonaj = (Convert.ToDouble(this.dr[4].ToString().Equals("") ? 0 : this.dr[4]) -
                                Convert.ToDouble(this.dr2[0].ToString().Equals("") ? "0" : this.dr2[0].ToString())).ToString();

                        }


                        h.Kutuk_boy = this.dr[5].ToString();
                        hh_vrd_ozet.Add(h);
                    }
                }

            }
            catch
            {
                throw new System.InvalidOperationException("Bağlantı gerçekleştirilirken bir hata oluştu.Tekrar deneyiniz!");
            }
            this.dr.Close();
            this.dr.Dispose();

            return hh_vrd_ozet;
        }




        /** Sevkiyat üretim**/
        public List<Sevkiyat_uretim> tikeyegore_dno_listele_data_read(string tarih, string tike_no)
        {
            List<Sevkiyat_uretim> dokumler = new List<Sevkiyat_uretim>();

            this.sql = "SELECT DNO,CAP,BOY,STANDART,KALITE from URTHRK.TABLE_ICPIYASA WHERE TARIH=" + tarih + " AND TIKENO='" + tike_no + "'";

            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Sevkiyat_uretim a = new Sevkiyat_uretim();
                a.Kalite = "Listelenecek Kayıt Bulunamadı!";
                a.Id = 0;
                dokumler.Add(a);
            }
            else
            {
                while (this.dr.Read())
                {
                    Sevkiyat_uretim a = new Sevkiyat_uretim();
                    a.Id = 1;
                    a.Dokum_no = this.dr[0].ToString();
                    a.Cap = this.dr[1].ToString();
                    a.Boy = this.dr[2].ToString();
                    a.Standart = this.dr[3].ToString();
                    a.Kalite = this.dr[4].ToString();


                    dokumler.Add(a);
                }
            }
            return dokumler;
        }
        public List<Sevkiyat_uretim> dno_veya_capa_gore_listele_data_read(string dokum_no, string cap)
        {
            List<Sevkiyat_uretim> dokumler = new List<Sevkiyat_uretim>();

            this.sql = "SELECT TESTTAR,KTKCC,SUM(KTKTON),KALITE,MAMCAPI,BOY,N_Y,F_D,SUM(STD_PAK_TONAJI)+ SUM(STD_DISI_PAK_TONAJI)  " +
                        "FROM URTHRK.TABLE3 WHERE DOKUMTAR=" + dokum_no + " ";
            if (cap != "")
            {

                this.sql += "AND MAMCAPI='" + cap + "'";
            }
            this.sql += " GROUP BY KTKCC, KALITE, MAMCAPI, BOY, TESTTAR, N_Y, F_D ORDER BY TESTTAR DESC";

            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Sevkiyat_uretim a = new Sevkiyat_uretim();
                a.Kalite = "Listelenecek Kayıt Bulunamadı!";
                a.Id = 0;
                dokumler.Add(a);
            }
            else
            {
                while (this.dr.Read())
                {
                    Sevkiyat_uretim h = new Sevkiyat_uretim();
                    h.Id = 1;
                    int cks_tarih = Convert.ToInt32(this.dr[0].ToString());
                    tarih_parse = tarihFormat(cks_tarih);
                    h.Tarih = tarih_parse;
                    h.Kalite = this.dr[1].ToString();
                    h.Kutuk_tonaj = Convert.ToDouble(this.dr[2].ToString().Equals("") ? 0 : this.dr[2]).ToString();
                    h.Mamul_standart = this.dr[3].ToString();
                    h.Mamul_cap = this.dr[4].ToString();
                    h.Mamul_boy = this.dr[5].ToString();
                    h.Ny = this.dr[6].ToString();
                    h.Fd = this.dr[7].ToString();
                    h.Mamul_tonaj = Convert.ToDouble(this.dr[8].ToString().Equals("") ? 0 : this.dr[8]).ToString();



                    dokumler.Add(h);
                }
            }
            return dokumler;
        }

        public List<Sevkiyat_uretim> sipno_ve_capa_gore_listele_data_read(string siparis_no, string cap)
        {
            List<Sevkiyat_uretim> dokumler = new List<Sevkiyat_uretim>();
            this.sql = "SELECT TESTTAR,KTKCC,SUM(KTKTON),KALITE,MAMCAPI,BOY,N_Y,F_D,SUM(STD_PAK_TONAJI)+ SUM(STD_DISI_PAK_TONAJI)  " +
                      "FROM URTHRK.TABLE3 WHERE SIPNO=" + siparis_no + " ";
            if (cap != "")
            {

                this.sql += "AND MAMCAPI='" + cap + "'";
            }
            this.sql += " GROUP BY KTKCC, KALITE, MAMCAPI, BOY, TESTTAR, N_Y, F_D ORDER BY TESTTAR DESC";

            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Sevkiyat_uretim s = new Sevkiyat_uretim();
                s.Kalite = "Listelenecek Kayıt Bulunamadı!";
                s.Id = 0;
                dokumler.Add(s);
            }
            else
            {
                while (this.dr.Read())
                {
                    Sevkiyat_uretim h = new Sevkiyat_uretim();
                    h.Id = 1;
                    int cks_tarih = Convert.ToInt32(this.dr[0].ToString());
                    tarih_parse = tarihFormat(cks_tarih);
                    h.Tarih = tarih_parse;
                    h.Kalite = this.dr[1].ToString();
                    h.Kutuk_tonaj = Convert.ToDouble(this.dr[2].ToString().Equals("") ? 0 : this.dr[2]).ToString();
                    h.Mamul_standart = this.dr[3].ToString();
                    h.Mamul_cap = this.dr[4].ToString();
                    h.Mamul_boy = this.dr[5].ToString();
                    h.Ny = this.dr[6].ToString();
                    h.Fd = this.dr[7].ToString();
                    h.Mamul_tonaj = Convert.ToDouble(this.dr[8].ToString().Equals("") ? 0 : this.dr[8]).ToString();

                    dokumler.Add(h);
                }
            }
            return dokumler;
        }



        /**Hadde durusları**/
        public List<durus_bilgileri> cubuk_haddehane_durus_data_read(int tarih_cubuk, int tarih2_cubuk)
        {
            List<durus_bilgileri> duruslar = new List<durus_bilgileri>();

            this.sql = "  SELECT TARIH,VRD,CAP,DURUSNEDENI,ARIZANEDENI,BASLANGIC,BITIS,SUM(NETSURE) " +
           "  FROM URTHRK.HHDURUS_RAPOR_CAP " +
           "WHERE ";
            if (tarih_cubuk > 0 && tarih2_cubuk > 0)
            {
                this.sql += "  TARIH >= " + tarih_cubuk +
                        " AND TARIH <= " + tarih2_cubuk + "  GROUP BY TARIH,VRD,CAP,DURUSNEDENI,ARIZANEDENI,BASLANGIC,BITIS,NETSURE ORDER BY TARIH,VRD ";
            }
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                durus_bilgileri d = new durus_bilgileri();
                d.Cap = "Listelenecek Kayıt Bulunamadı!";
                d.Id = 0;
                duruslar.Add(d);
            }
            else
            {
                while (this.dr.Read())
                {
                    durus_bilgileri d = new durus_bilgileri();
                    d.Id = 1;
                    int cks_tarih = Convert.ToInt32(this.dr[0].ToString());
                    tarih_parse = tarihFormat(cks_tarih);
                    d.tarih = tarih_parse;
                    d.vrd = this.dr[1].ToString();
                    d.Cap = this.dr[2].ToString();
                    d.DURUSNEDEN = this.dr[3].ToString();
                    d.ARIZANEDEN = this.dr[4].ToString();
                    d.BASSAATI = this.dr[5].ToString();
                    int baslangic_saati = Convert.ToInt32(this.dr[5].ToString().Equals("") ? "0" : this.dr[5].ToString());

                    saat_parse = saat_format(baslangic_saati);
                    d.BASSAATI = saat_parse;

                    int bitis_saati = Convert.ToInt32(this.dr[6].ToString());

                    saat_parse = saat_format(bitis_saati);
                    d.BITISSAATI = saat_parse;

                    d.SURE = this.dr[7].ToString();

                    duruslar.Add(d);
                }
            }

            return duruslar;
        }
        public List<durus_bilgileri> tel_cubuk_haddehane_durus_data_read(int tarih_telcubuk, int tarih2_telcubuk)
        {
            List<durus_bilgileri> duruslar = new List<durus_bilgileri>();

            this.sql = "  SELECT TARIH,VRD,CAP,DURUS_NEDENI,ARIZA_NEDENI,BASLAMA_SAATI,BITIS_SAATI,SUM(SURE) " +
          "  FROM FILMASIN.FILMASIN_DURUS " +
          "WHERE ";
            if (tarih_telcubuk > 0 && tarih2_telcubuk > 0)
            {
                this.sql += "  TARIH >= " + tarih_telcubuk +
                        " AND TARIH <= " + tarih2_telcubuk + "  GROUP BY TARIH,VRD,CAP,DURUS_NEDENI,ARIZA_NEDENI,BASLAMA_SAATI,BITIS_SAATI,SURE ORDER BY TARIH,VRD ";
            }

            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                durus_bilgileri d = new durus_bilgileri();
                d.Cap = "Listelenecek Kayıt Bulunamadı!";
                d.Id = 0;
                duruslar.Add(d);
            }
            else
            {
                while (this.dr.Read())
                {
                    durus_bilgileri d = new durus_bilgileri();
                    d.Id = 1;
                    int cks_tarih = Convert.ToInt32(this.dr[0].ToString());
                    tarih_parse = tarihFormat(cks_tarih);
                    d.tarih = tarih_parse;
                    d.vrd = this.dr[1].ToString();
                    d.Cap = this.dr[2].ToString();
                    d.DURUSNEDEN = this.dr[3].ToString();
                    d.ARIZANEDEN = this.dr[4].ToString();
                    d.BASSAATI = this.dr[5].ToString();
                    int baslangic_saati = Convert.ToInt32(this.dr[5].ToString());
                    saat_parse = saat_format(baslangic_saati);
                    d.BASSAATI = saat_parse;
                    int bitis_saati = Convert.ToInt32(this.dr[6].ToString());
                    saat_parse = saat_format(bitis_saati);
                    d.BITISSAATI = saat_parse;
                    d.SURE = this.dr[7].ToString();

                    duruslar.Add(d);
                }
            }




            return duruslar;
        }



        /**Kütük düzenleme**/


        public List<uretim_bilgileri> dokum_listesi(int tarih)
        {
            List<uretim_bilgileri> kayitlar = new List<uretim_bilgileri>();
            string sql = "SELECT DNO,DSNO,DOKUMTAR,KALITE,EBAT,BOY,STDKTKTON,STDKTKSAY FROM URTHRK.CH_DOKUMNO_URETIM WHERE DOKUMTAR=" + tarih + "";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                uretim_bilgileri kayit = new uretim_bilgileri();
                kayit.CELIKCINSI = "Listelenecek Kayıt Bulunamadı !!";
                kayit.Id = 0;
                kayitlar.Add(kayit);
            }
            else
            {
                while (this.dr.Read())
                {
                    uretim_bilgileri kayit = new uretim_bilgileri();
                    kayit.Id = 1;

                    kayit.SIRANO = this.dr[1].ToString();
                    kayit.DOKUMNO = this.dr[0].ToString();
                    kayit.CELIKCINSI = this.dr[3].ToString();
                    kayit.KTKBOY = this.dr[5].ToString();
                    kayit.KTKEBAT = this.dr[4].ToString();
                    kayit.KTKADET = Convert.ToInt32(this.dr[7].ToString().Equals("") ? "0" : this.dr[7].ToString()).ToString();
                    kayit.STDKTKTONAJ = Convert.ToDouble(this.dr[6].ToString().Equals("") ? "0" : this.dr[6].ToString()).ToString().Replace(",", ".");


                    kayitlar.Add(kayit);
                }
            }

            return kayitlar;
        }
        public string uretim_kayit(string dokum_no, string sira_no, string kutuk_sayisi, string birim_tonaj, string tarih)
        {
            string sql, mesaj;
            double brm_tonaj = double.Parse(birim_tonaj, System.Globalization.CultureInfo.InvariantCulture);

            sql = "UPDATE URTHRK.CH_DOKUMNO_URETIM SET STDKTKTON=" + (brm_tonaj * Convert.ToInt32(kutuk_sayisi)).ToString().Replace(",", ".") + " " +
                " ,STDKTKSAY=" + kutuk_sayisi + "" +
                " WHERE DNO=" + dokum_no + " AND  DSNO=" + sira_no + "  AND DOKUMTAR=" + tarih + " ";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = sql;
            string sql_sorgu = this.cmd.ExecuteNonQuery().ToString();
            if (sql_sorgu != "0")
            {
                mesaj = "ÜRETİM BİLGİLERİ BAŞARIYLA GÜNCELLENDİ";

            }
            else
            {
                mesaj = "BAĞLANTI GERÇEKLEŞTİRİLİRKEN HATA OLUŞTU.  " +
                           " TEKRAR DENEYİNİZ.";

            }

            return mesaj;


        }





        /**Üretim sırası**/

        public List<uretim_sira> uretim_sirasi_data_read()
        {

            List<uretim_sira> kayitlar = new List<uretim_sira>();
            string sql = "SELECT TARIH,EBAT_BOY,KALITE,MIKTAR,ACIKLAMA,SIPARISNO,GENELACIKLAMA FROM URTHRK.URETIMSIRASI_CH WHERE DRM='A' ORDER BY SIRA ";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //Kayıt yok
                uretim_sira u = new uretim_sira();
                u.Aciklama = "Listelenecek Kayıt Bulunamadı!";
                u.Uretim_id = 0;
                kayitlar.Add(u);
            }
            else
            {
                while (this.dr.Read())
                {
                    uretim_sira u = new uretim_sira();
                    u.Uretim_id = 1;
                    u.Uretim_tarihi = this.dr[0].ToString();
                    u.Ebat_boy = this.dr[1].ToString();
                    u.Kalite = this.dr[2].ToString();
                    u.Uretim_miktari = this.dr[3].ToString();
                    u.Aciklama = this.dr[4].ToString();
                    u.Siparis_no = this.dr[5].ToString();
                    u.Genel_aciklama = this.dr[6].ToString();
                    kayitlar.Add(u);
                }
            }

            return kayitlar;
        }

    }
}
