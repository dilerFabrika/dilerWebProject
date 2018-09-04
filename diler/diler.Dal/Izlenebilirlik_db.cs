using diler.Entity;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System.Linq;
using System.Text;

namespace diler.Dal
{
    public class Izlenebilirlik_db
    {

        OracleConnection conn, conn2;
        string connetionString, sql, gelentarih;
        OracleCommand cmd;
        OracleDataReader dr, dr2, dr3;
        public string tarih_parse, saat_parse;
        public string kutuk_sayisi_ds2, karisim_sayisi_ds2, kutuk_sayisi_ds1, karisim_sayisi_ds1, kutuk_sayisi_ds3, karisim_sayisi_ds3, aciklama;
        public string kalite_kod, ebat_kod, boy_kod, mesaj, mesaj2;
        public int kutuksayisi, ktkdus, fie_hurda, fde_hurda, kontrol, egri_kutuk_sayisi;

        //OleDbConnection con_access;
        ////OleDbDataAdapter dr_access;
        //OleDbDataReader dr_access;
        //OleDbCommand cmd_access;

        public Izlenebilirlik_db()
        {
            this.connetionString = @"Data Source=(DESCRIPTION=" +
                "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.198.191)(PORT=1521)))" +
                "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=DLRORA)));" +
                "User Id=URTHRK;Password=URTHRK;";
            this.cmd = new OracleCommand();
            this.conn = new OracleConnection(this.connetionString);
            this.conn2 = new OracleConnection(this.connetionString);


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

        //public void Access_connect()
        //{
        //    if (this.con_access.State != System.Data.ConnectionState.Open)
        //    {
        //        try
        //        {
        //            this.con_access.Open();
        //            this.cmd_access.Connection = this.con_access;
        //        }
        //        catch
        //        {
        //            throw new System.InvalidOperationException(" Veri Tabani baglantisi kurulamiyor!");
        //        }
        //    }
        //}

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

        ///
        public List<Izlenebilirlik_bilgileri> ao_izlenebilirlik_data_read(int dokum_no = 0)
        {
            List<Izlenebilirlik_bilgileri> kayitlar = new List<Izlenebilirlik_bilgileri>();
            this.sql = "SELECT * " +
                      "FROM URTHRK.CH_IZLENEBILIRLIK AI " +
                      "WHERE AI.DNO = 0";
            if (dokum_no > 0)
            {
                this.sql = "SELECT * " +
                            "FROM URTHRK.CH_IZLENEBILIRLIK AI " +
                            "WHERE AI.DNO = " + dokum_no;
            }
            this.sql += " ORDER BY DNO ASC";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Izlenebilirlik_bilgileri kayit = new Izlenebilirlik_bilgileri();
                kayit.Vrd = "Listelenecek Kayıt Bulunamadı !!";
                kayit.Id = 0;
                kayitlar.Add(kayit);
            }
            else
            {

                while (this.dr.Read())
                {
                    Izlenebilirlik_bilgileri kayit = new Izlenebilirlik_bilgileri();
                    kayit.Id = 1;
                    kayit.Lokasyon = "AO";
                    kayit.Vrd = (this.dr[1].ToString());
                    kayit.Dokumsuresi = (this.dr[2].ToString());
                    kayit.Enerjili_sure = (this.dr[3].ToString());
                    kayit.Enerjisiz_sure = (this.dr[4].ToString());
                    kayit.Devirme_sicaklik = (this.dr[5].ToString());
                    kayit.Parca_kirec = (this.dr[6].ToString());
                    kayit.Enj_kirec = (this.dr[7].ToString());
                    kayit.Parca_kok = (this.dr[8].ToString());
                    kayit.Dolamit = (this.dr[9].ToString());
                    kayit.Dev_al = (this.dr[10].ToString());
                    kayit.DevFesiMn = (this.dr[11].ToString());
                    kayit.Dokum_baslangic_saati = this.dr["DOKUM_BASLANGIC_SAATI"].ToString();
                    kayit.Dokum_bitis_saati = this.dr["DEVIRME_SAATI"].ToString();
                    kayitlar.Add(kayit);
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;
        }
        public List<Izlenebilirlik_bilgileri> po_izlenebilirlik_data_read(int dokum_no = 0)
        {

            List<Izlenebilirlik_bilgileri> kayitlar = new List<Izlenebilirlik_bilgileri>();
            this.sql = "SELECT * " +
                      "FROM URTHRK.CH_IZLENEBILIRLIK AI " +
                      "WHERE AI.DNO = 0";
            if (dokum_no > 0)
            {
                this.sql = "SELECT * " +
                            "FROM URTHRK.CH_IZLENEBILIRLIK AI " +
                            "WHERE AI.DNO = " + dokum_no;
            }
            this.sql += " ORDER BY DNO ASC";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Izlenebilirlik_bilgileri kayit = new Izlenebilirlik_bilgileri();
                kayit.Vrd = "Listelenecek Kayıt Bulunamadı !!";
                kayit.Id = 0;
                kayitlar.Add(kayit);
            }
            else
            {

                while (this.dr.Read())
                {
                    Izlenebilirlik_bilgileri kayit = new Izlenebilirlik_bilgileri();
                    kayit.Id = 1;
                    kayit.Lokasyon = "PO";
                    kayit.Potano = (this.dr[12].ToString());
                    kayit.Po_giris_sicakligi = (this.dr[13].ToString());
                    kayit.Po_cikis_sicakligi = (this.dr[14].ToString());
                    kayit.Po_enerjilisure = (this.dr[15].ToString());
                    kayit.C = (this.dr[16].ToString());
                    kayit.CaO = (this.dr[17].ToString());
                    kayit.Fesi = (this.dr[24].ToString());
                    kayit.FesiMn = (this.dr[23].ToString());
                    kayit.Al = (this.dr[18].ToString());
                    kayit.CaF2 = (this.dr[19].ToString());
                    kayit.MgO = (this.dr[20].ToString());
                    kayit.Boksit = (this.dr[21].ToString());
                    kayit.FeV = (this.dr[22].ToString());
                    kayit.Pota_giris_saati = this.dr["PO_GIRIS_SAATI"].ToString();
                    kayit.Pota_bitis_saati = this.dr["PO_CIKIS_SAATI"].ToString();

                    kayitlar.Add(kayit);
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;
        }
        public List<Izlenebilirlik_bilgileri> sdm_izlenebilirlik_data_read(int dokum_no = 0)
        {

            List<Izlenebilirlik_bilgileri> kayitlar = new List<Izlenebilirlik_bilgileri>();
            this.sql = "SELECT * " +
                      "FROM URTHRK.CH_IZLENEBILIRLIK AI " +
                      "WHERE AI.DNO = 0";
            if (dokum_no > 0)
            {
                this.sql = "SELECT * " +
                            "FROM URTHRK.CH_IZLENEBILIRLIK AI " +
                            "WHERE AI.DNO = " + dokum_no;
            }
            this.sql += " ORDER BY DNO ASC";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Izlenebilirlik_bilgileri kayit = new Izlenebilirlik_bilgileri();
                kayit.Vrd = "Listelenecek Kayıt Bulunamadı !!";
                kayit.Id = 0;
                kayitlar.Add(kayit);
            }
            else
            {

                while (this.dr.Read())
                {
                    Izlenebilirlik_bilgileri kayit = new Izlenebilirlik_bilgileri();
                    kayit.Id = 1;
                    kayit.Pota_acma_saati = (this.dr[25].ToString());
                    kayit.Pota_kapatma_saati = (this.dr[26].ToString());
                    kayit.Yol1 = (this.dr[27].ToString());
                    kayit.Yol2 = (this.dr[28].ToString());
                    kayit.Yol3 = (this.dr[29].ToString());
                    kayit.Yol4 = (this.dr[30].ToString());
                    kayit.Yol5 = (this.dr[31].ToString());
                    kayit.Yol6 = (this.dr[32].ToString());
                    kayitlar.Add(kayit);
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;
        }

        public List<Izlenebilirlik_bilgileri> uretim_izlenebilirlik_data_read(int dokum_no = 0)
        {
            List<Izlenebilirlik_bilgileri> kayitlar = new List<Izlenebilirlik_bilgileri>();
            this.sql = "SELECT * " +
                      "FROM URTHRK.CH_DOKUMNO_URETIM U " +
                      "WHERE U.DNO = 0";
            if (dokum_no > 0)
            {
                this.sql = "SELECT * " +
                            "FROM URTHRK.CH_DOKUMNO_URETIM U " +
                            "WHERE U.DNO = " + dokum_no;
            }
            this.sql += " ORDER BY DNO ASC";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Izlenebilirlik_bilgileri kayit = new Izlenebilirlik_bilgileri();
                kayit.Vrd = "Listelenecek Kayıt Bulunamadı !!";
                kayit.Id = 0;
                kayitlar.Add(kayit);
            }
            else
            {

                while (this.dr.Read())
                {
                    Izlenebilirlik_bilgileri kayit = new Izlenebilirlik_bilgileri();
                    kayit.Id = 1;
                    kayit.Lokasyon = "ÜRETİM";
                    kayit.Ebat = (this.dr[9].ToString());
                    kayit.Boy = (this.dr[8].ToString());
                    kayit.Celik_cinsi = (this.dr[7].ToString());
                    kayit.Std = (this.dr[15].ToString());
                    kayit.Stddisi = (this.dr[20].ToString());

                    kayitlar.Add(kayit);
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;
        }

        public List<Izlenebilirlik_bilgileri> tavfrn_izlenebilirlik_data_read(int dokum_no = 0)
        {
            List<Izlenebilirlik_bilgileri> kayitlar = new List<Izlenebilirlik_bilgileri>();
            this.sql = "SELECT * " +
                      "FROM URTHRK.TAVFRN T " +
                      "WHERE T.DNO = 0";
            if (dokum_no > 0)
            {
                this.sql = "SELECT * " +
                            "FROM URTHRK.TAVFRN T " +
                            "WHERE T.DNO = " + dokum_no;
            }
            this.sql += " ORDER BY DNO ASC";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Izlenebilirlik_bilgileri kayit = new Izlenebilirlik_bilgileri();
                kayit.Vrd = "Listelenecek Kayıt Bulunamadı !!";
                kayit.Id = 0;
                kayitlar.Add(kayit);
            }
            else
            {

                while (this.dr.Read())
                {
                    Izlenebilirlik_bilgileri kayit = new Izlenebilirlik_bilgileri();
                    kayit.Id = 1;
                    kayit.Lokasyon = "FIRIN İÇİ";
                    kayit.Yil = (this.dr[2].ToString());
                    kayit.Sarjtipi = (this.dr[8].ToString());
                    int grs_saat = Convert.ToInt32(this.dr[9].ToString());
                    saat_parse = saat_format(grs_saat);
                    kayit.Giris_saati = saat_parse;
                    int cks_saat = Convert.ToInt32(this.dr[10].ToString());
                    saat_parse = saat_format(cks_saat);
                    kayit.Cikis_saati = saat_parse;
                    int cks_tarih = Convert.ToInt32(this.dr[14].ToString());
                    tarih_parse = tarihFormat(cks_tarih);
                    kayit.Cikis_tarihi = tarih_parse;
                    string sqlx = "SELECT KALITE FROM URTHRK.CH_DOKUMNO_URETIM WHERE DNO=" + dokum_no + "";
                    this.cmd.Parameters.Clear();
                    this.cmd.CommandText = sqlx;
                    this.dr2 = this.cmd.ExecuteReader();
                    while (this.dr2.Read())
                    {
                        kayit.Celik_cinsi = (this.dr2[0].ToString());
                    }
                    kayit.Kutuk_sayisi = (this.dr[11].ToString());

                    kayitlar.Add(kayit);
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;
        }

        public List<Izlenebilirlik_bilgileri> firindan_dusmus_izlenebilirlik_data_read(int dokum_no = 0)
        {
            List<Izlenebilirlik_bilgileri> kayitlar = new List<Izlenebilirlik_bilgileri>();
            this.sql = "SELECT * " +
                      "FROM URTHRK.TAVFRNKTKDUS T " +
                      "WHERE T.DNO = 0";
            if (dokum_no > 0)
            {
                this.sql = "SELECT  COUNT(DNO), GIRSAAT, CIKTAR " +
                    "FROM URTHRK.TAVFRNKTKDUS T WHERE T.DNO = " + dokum_no + " GROUP BY DNO, GIRSAAT, CIKTAR";
            }
            this.sql += " ORDER BY COUNT(DNO) DESC";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Izlenebilirlik_bilgileri kayit = new Izlenebilirlik_bilgileri();
                kayit.Vrd = "Listelenecek Kayıt Bulunamadı !!";
                kayit.Id = 0;
                kayitlar.Add(kayit);
            }
            else
            {

                while (this.dr.Read())
                {
                    Izlenebilirlik_bilgileri kayit = new Izlenebilirlik_bilgileri();
                    kayit.Id = 1;
                    kayit.Lokasyon = "FIRINDAN ÇIKMIŞ";
                    int cks_tarih = Convert.ToInt32(this.dr[2].ToString());
                    tarih_parse = tarihFormat(cks_tarih);
                    kayit.Cikis_tarihi = tarih_parse;
                    //kayit.Giris_saati = (this.dr[6].ToString());
                    //kayit.Cikis_saati = (this.dr[20].ToString());
                    string sqlx = "SELECT KALITE FROM URTHRK.CH_DOKUMNO_URETIM WHERE DNO=" + dokum_no + "";
                    this.cmd.Parameters.Clear();
                    this.cmd.CommandText = sqlx;
                    this.dr2 = this.cmd.ExecuteReader();
                    while (this.dr2.Read())
                    {
                        kayit.Celik_cinsi = (this.dr2[0].ToString());
                    }
                    kayit.Kutuk_sayisi = (this.dr[0].ToString());

                    kayitlar.Add(kayit);
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;
        }

        public List<Izlenebilirlik_bilgileri> tavfrn_sicaklik_izlenebilirlik_data_read(int dokum_no = 0)
        {
            List<Izlenebilirlik_bilgileri> kayitlar = new List<Izlenebilirlik_bilgileri>();
            this.sql = "SELECT DNO,BOY,EBAT,CELIKCINSI,BOLGE4,BOLGE5,BOLGE6,KTKSICAKLIGI " +
                      "FROM URTHRK.TAVFRNSICAKLIK T " +
                      "WHERE T.DNO = 0";
            if (dokum_no > 0)
            {
                this.sql = "SELECT DNO,BOY,EBAT,CELIKCINSI,BOLGE4,BOLGE5,BOLGE6,KTKSICAKLIGI " +
                            "FROM URTHRK.TAVFRNSICAKLIK T " +
                            "WHERE T.DNO = " + dokum_no + " ";
            }
            this.sql += " ORDER BY DNO ASC";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Izlenebilirlik_bilgileri kayit = new Izlenebilirlik_bilgileri();
                kayit.Vrd = "Listelenecek Kayıt Bulunamadı !!";
                kayit.Id = 0;
                kayitlar.Add(kayit);
            }
            else
            {

                while (this.dr.Read())
                {
                    Izlenebilirlik_bilgileri kayit = new Izlenebilirlik_bilgileri();
                    kayit.Id = 1;
                    kayit.Lokasyon = "TAVFRN SICAKLIK";
                    kayit.Dokum_no = Convert.ToInt32(this.dr[0]);
                    kayit.Bolge4 = this.dr[4].ToString();
                    kayit.Bolge5 = this.dr[5].ToString();
                    kayit.Bolge6 = this.dr[6].ToString();
                    kayit.Kutuk_sicaklik = this.dr[7].ToString();
                    kayit.Ebat = this.dr[2].ToString();
                    kayit.Boy = this.dr[1].ToString();
                    kayit.Celik_cinsi = this.dr[3].ToString();


                    kayitlar.Add(kayit);
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;
        }

        public List<Izlenebilirlik_bilgileri> filmasin_sevk_izlenebilirlik_data_read(int dokum_no = 0)
        {
            List<Izlenebilirlik_bilgileri> kayitlar = new List<Izlenebilirlik_bilgileri>();
            this.sql = "SELECT * " +
                      "FROM URTHRK.CH_FILMASIN_KTK_TRANSFER U " +
                      "WHERE U.DOKUMNO = 0";
            if (dokum_no > 0)
            {
                this.sql = "SELECT * " +
                            "FROM URTHRK.CH_FILMASIN_KTK_TRANSFER U " +
                            "WHERE U.DOKUMNO = " + dokum_no + "";
            }
            this.sql += " ORDER BY DOKUMNO ASC";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            while (this.dr.Read())
            {
                Izlenebilirlik_bilgileri kayit = new Izlenebilirlik_bilgileri();
                kayit.Id = 1;
                kayit.Lokasyon = "FİLMAŞİN SEVK";
                kayit.Celik_cinsi = (this.dr["KALITE"].ToString());
                kayit.Ebat = (this.dr["KUTUKEBAT"].ToString());
                kayit.Boy = (this.dr["KUTUKBOY"].ToString());
                kayit.Kutuk_sayisi = (this.dr["ADET"].ToString());
                kayitlar.Add(kayit);


            }

            string sqlx = "SELECT STDKTKSAY,KALITE,BOY,EBAT FROM URTHRK.CH_DOKUMNO_URETIM U WHERE U.DNO=" + dokum_no + " AND GIDECEGIYER='Filmaşin'";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = sqlx;
            this.dr = this.cmd.ExecuteReader();
            while (this.dr.Read())
            {
                Izlenebilirlik_bilgileri kayit = new Izlenebilirlik_bilgileri();
                kayit.Id = 2;
                kayit.Kutuk_sayisi = (this.dr[0].ToString());
                kayit.Celik_cinsi = (this.dr["KALITE"].ToString());
                kayit.Ebat = (this.dr["EBAT"].ToString());
                kayit.Boy = (this.dr["BOY"].ToString());
                kayitlar.Add(kayit);
            }

            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;
        }

        public List<Izlenebilirlik_bilgileri> fizik_izlenebilirlik_data_read(int dokum_no = 0)
        {
            List<Izlenebilirlik_bilgileri> kayitlar = new List<Izlenebilirlik_bilgileri>();
            this.sql = "SELECT DNO,AKMANMM2,CEKMENMM,UZAMAL,CEMKEAKMA,AGT,BEND,REBEND,MAMCAPKOD " +
                      "FROM URTHRK.FIZLAB F " +
                      "WHERE F.DNO = 0";
            if (dokum_no > 0)
            {
                this.sql = "SELECT DNO,AKMANMM2,CEKMENMM,UZAMAL,CEMKEAKMA,AGT,BEND,REBEND,MAMCAPKOD " +
                            "FROM URTHRK.FIZLAB F " +
                            "WHERE F.DNO = " + dokum_no + " ";
            }
            this.sql += " ORDER BY DNO ASC";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Izlenebilirlik_bilgileri kayit = new Izlenebilirlik_bilgileri();
                kayit.Vrd = "Listelenecek Kayıt Bulunamadı !!";
                kayit.Id = 0;
                kayitlar.Add(kayit);
            }
            else
            {

                while (this.dr.Read())
                {
                    Izlenebilirlik_bilgileri kayit = new Izlenebilirlik_bilgileri();
                    kayit.Id = 1;
                    kayit.Lokasyon = "FİZİK";
                    kayit.Dokum_no = Convert.ToInt32(this.dr[0].ToString());
                    string sqlx = "SELECT ACK FROM URTTNM.CAP WHERE KOD='" + this.dr[8].ToString() + "' AND TESIS='DHH'";
                    this.cmd.Parameters.Clear();
                    this.cmd.CommandText = sqlx;
                    this.dr2 = this.cmd.ExecuteReader();
                    while (this.dr2.Read())
                    {
                        kayit.Cap = this.dr2[0].ToString();
                    }

                    // kayit.Cap = this.dr[8].ToString();
                    kayit.Akma = this.dr[1].ToString();
                    kayit.Cekme = this.dr[2].ToString();
                    kayit.Uzama = this.dr[3].ToString();
                    kayit.Cekme_akma = this.dr[4].ToString();
                    kayit.Agt = this.dr[5].ToString();
                    kayit.Bend = this.dr[6].ToString();
                    kayit.Rbend = this.dr[7].ToString();
                    kayitlar.Add(kayit);
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;
        }

        public List<Izlenebilirlik_bilgileri> tempcore_izlenebilirlik_data_read(int dokum_no = 0)
        {
            List<Izlenebilirlik_bilgileri> kayitlar = new List<Izlenebilirlik_bilgileri>();
            this.sql = "SELECT DNO,DEBI_A,DEBI_B,DEBI_C,DEBI_D,MAMULKALITE,CAP,NOZULCAPI,HIZ,P_SAYISI,P_BASINCI " +
                      "FROM URTHRK.TEMPCORE T " +
                      "WHERE T.DNO = 0";
            if (dokum_no > 0)
            {
                this.sql = "SELECT DNO,DEBI_A,DEBI_B,DEBI_C,DEBI_D,MAMULKALITE,CAP,NOZULCAPI,HIZ,P_SAYISI,P_BASINCI " +
                            "FROM URTHRK.TEMPCORE T " +
                            "WHERE T.DNO = " + dokum_no + " ";
            }
            this.sql += " ORDER BY DNO ASC";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Izlenebilirlik_bilgileri kayit = new Izlenebilirlik_bilgileri();
                kayit.Vrd = "Listelenecek Kayıt Bulunamadı !!";
                kayit.Id = 0;
                kayitlar.Add(kayit);
            }
            else
            {

                while (this.dr.Read())
                {
                    Izlenebilirlik_bilgileri kayit = new Izlenebilirlik_bilgileri();
                    kayit.Id = 1;
                    kayit.Lokasyon = "Tempcore";
                    kayit.Dokum_no = Convert.ToInt32(this.dr[0].ToString());
                    // kayit.Cap = this.dr[8].ToString();
                    kayit.Debi_a = this.dr[1].ToString();
                    kayit.Debi_b = this.dr[2].ToString();
                    kayit.Debi_c = this.dr[3].ToString();
                    kayit.Debi_d = this.dr[4].ToString();
                    kayit.Mamulkalite = this.dr[5].ToString();
                    kayit.Cap = this.dr[6].ToString();
                    kayit.Nozulcapi = this.dr[7].ToString();
                    kayit.Hiz = this.dr[8].ToString();
                    kayit.Pompasayisi = this.dr[9].ToString();
                    kayit.Pompabasinci = this.dr[10].ToString();

                    kayitlar.Add(kayit);
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;
        }

        public List<Izlenebilirlik_bilgileri> toplam_hurda_izlenebilirlik_data_read(int dokum_no = 0)
        {

            List<Izlenebilirlik_bilgileri> kayitlar = new List<Izlenebilirlik_bilgileri>();
            this.sql = "SELECT SUM(MIKTAR) " +
                      "FROM URTHRK.CH_DOKUMNO_HURDA_DATA H " +
                      "WHERE H.DOKUMNO = 0";
            if (dokum_no > 0)
            {
                this.sql = "SELECT SUM(MIKTAR) " +
                            "FROM  URTHRK.CH_DOKUMNO_HURDA_DATA H " +
                            "WHERE H.DOKUMNO = " + dokum_no + " ";
            }
            this.sql += " ORDER BY DOKUMNO ASC";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Izlenebilirlik_bilgileri kayit = new Izlenebilirlik_bilgileri();
                kayit.Vrd = "Listelenecek Kayıt Bulunamadı !!";
                kayit.Id = 0;
                kayit.Toplam_srj = this.dr[0].ToString();
                kayitlar.Add(kayit);
            }
            else
            {

                while (this.dr.Read())
                {
                    Izlenebilirlik_bilgileri kayit = new Izlenebilirlik_bilgileri();
                    kayit.Id = 1;
                    kayit.Toplam_srj = this.dr[0].ToString();

                    kayitlar.Add(kayit);
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;
        }




        public List<Izlenebilirlik_bilgileri> haddahane_istif_izlenebilirlik_data_read(int dokum_no = 0)
        {
            List<Izlenebilirlik_bilgileri> kayitlar = new List<Izlenebilirlik_bilgileri>();
            this.sql = "SELECT STOK_YERI,ISTIF_YERI,ISTIF_ADET,CELIKCINSI " +
                         "FROM URTHRK.CH_DOKUMNO_ISTIF  " +
                         "WHERE DOKUMNO = 0 AND STOK_YERI='Haddehane'";
            if (dokum_no > 0)
            {
                this.sql = "SELECT STOK_YERI,ISTIF_YERI,ISTIF_ADET,CELIKCINSI " +
                            "FROM URTHRK.CH_DOKUMNO_ISTIF " +
                            "WHERE DOKUMNO = " + dokum_no + " AND STOK_YERI='Haddehane' ";
            }
            this.sql += " ORDER BY DOKUMNO ASC";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {

                //kayit bulunamadiysa
                Izlenebilirlik_bilgileri kayit = new Izlenebilirlik_bilgileri();
                kayit.Vrd = "Listelenecek Kayıt Bulunamadı !!";
                kayit.Id = 0;
                kayitlar.Add(kayit);
            }
            else
            {

                while (this.dr.Read())
                {
                    Izlenebilirlik_bilgileri kayit = new Izlenebilirlik_bilgileri();
                    kayit.Id = 1;
                    kayit.Stok_yeri = this.dr[0].ToString();
                    kayit.Istif_yeri = this.dr[1].ToString();
                    kayit.Kutuk_sayisi = this.dr[2].ToString();
                    kayit.Celik_cinsi = this.dr[3].ToString();

                    kayitlar.Add(kayit);
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;
        }
        public List<Izlenebilirlik_bilgileri> celikhane_istif_izlenebilirlik_data_read(int dokum_no = 0)
        {
            List<Izlenebilirlik_bilgileri> kayitlar = new List<Izlenebilirlik_bilgileri>();
            this.sql = "SELECT STOK_YERI,ISTIF_YERI,ISTIF_ADET,CELIKCINSI " +
                         "FROM URTHRK.CH_DOKUMNO_ISTIF  " +
                         "WHERE DOKUMNO = 0 AND STOK_YERI<>'Haddehane'";
            if (dokum_no > 0)
            {
                this.sql = "SELECT STOK_YERI,ISTIF_YERI,ISTIF_ADET,CELIKCINSI " +
                            "FROM URTHRK.CH_DOKUMNO_ISTIF " +
                            "WHERE DOKUMNO = " + dokum_no + " AND STOK_YERI<>'Haddehane'";
            }
            this.sql += " ORDER BY DOKUMNO ASC";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {

                //kayit bulunamadiysa
                Izlenebilirlik_bilgileri kayit = new Izlenebilirlik_bilgileri();
                kayit.Vrd = "Listelenecek Kayıt Bulunamadı !!";
                kayit.Id = 0;
                kayitlar.Add(kayit);
            }
            else
            {

                while (this.dr.Read())
                {
                    Izlenebilirlik_bilgileri kayit = new Izlenebilirlik_bilgileri();
                    kayit.Id = 1;
                    kayit.Stok_yeri = this.dr[0].ToString();
                    kayit.Istif_yeri = this.dr[1].ToString();
                    kayit.Kutuk_sayisi = this.dr[2].ToString();
                    kayit.Celik_cinsi = this.dr[3].ToString();

                    kayitlar.Add(kayit);
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;
        }



        //Döküm bazında izlenebilirlik
        public List<Izlenebilirlik_bilgileri> dokumbazinda_kutuk_takip_ozet_read(int dokum_no = 0, int dokum_no2 = 0)
        {
            List<Izlenebilirlik_bilgileri> kayitlar = new List<Izlenebilirlik_bilgileri>();


            this.sql = "SELECT DISTINCT(DNO),KALITE, KTKACIKLAMA " +
                      "FROM URTHRK.CH_DOKUMNO_URETIM " +
                      "WHERE ";
            if (dokum_no >= 0 && dokum_no2 >= 0)
            {
                this.sql += "  DNO >= " + dokum_no +
                        " AND DNO <= " + dokum_no2 + " AND DSNO = 1 ";
            }
            this.sql += " GROUP BY DNO, KALITE, KTKACIKLAMA ORDER BY DNO ASC";
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
                    // kayit.Aciklama = this.dr[2].ToString();
                    string sqlx = "SELECT " +
             "(SELECT SUM(STDKTKSAY) FROM URTHRK.CH_DOKUMNO_URETIM WHERE DNO = " + kayit.Dokum_no + ") AS STANDARTKUTUK," +
             "(SELECT SUM(STNKARSAY) FROM URTHRK.CH_DOKUMNO_URETIM WHERE DNO = " + kayit.Dokum_no + ") AS STANDARTKARISIM," +
             "(SELECT SUM(KTKADET) FROM URTHRK.TAVFRN  GROUP BY DNO HAVING DNO = " + kayit.Dokum_no + ") AS TAVFRN," +
             "(SELECT SUM(ISTIF_ADET) FROM URTHRK.CH_DOKUMNO_ISTIF  WHERE DOKUMNO = " + kayit.Dokum_no + ") AS ISTIF," +
             "(SELECT SUM(ADET) FROM URTHRK.KTKSATIS  GROUP BY DNO HAVING DNO = " + kayit.Dokum_no + ") AS SATIS," +
             "(SELECT SUM(KTKSAY) FROM URTHRK.TAVFRNOONU GROUP BY DNO HAVING DNO = " + kayit.Dokum_no + ") AS TAVFRNONU," +
             "(SELECT SUM(STDKTKSAY) FROM URTHRK.CH_DOKUMNO_URETIM WHERE DNO = " + kayit.Dokum_no + " AND GIDECEGIYER = 'Filmaşin') AS TELCUBUKHadde_KUTUK," +
             "(SELECT SUM(STNKARSAY) FROM URTHRK.CH_DOKUMNO_URETIM WHERE DNO = " + kayit.Dokum_no + " AND GIDECEGIYER = 'Filmaşin') AS TELCUBUKHadde_KARISIM," +
              "(SELECT KTKACIKLAMA from URTHRK.CH_DOKUMNO_URETIM WHERE DNO = " + kayit.Dokum_no + "AND DSNO = 2) AS A," +
             "(SELECT KTKACIKLAMA from URTHRK.CH_DOKUMNO_URETIM WHERE DNO =" + kayit.Dokum_no + " AND DSNO = 3) AS B " +
             " FROM URTHRK.CH_DOKUMNO_URETIM WHERE ROWNUM = 1";
                    this.cmd.Parameters.Clear();
                    this.cmd.CommandText = sqlx;
                    this.dr2 = this.cmd.ExecuteReader();
                    while (this.dr2.Read())
                    {

                        kayit.Kutuk_sayisi = (Convert.ToInt32(this.dr2[0].ToString().Equals("") ? "0" : this.dr2[0].ToString()) +
                                             Convert.ToInt32(this.dr2[1].ToString().Equals("") ? "0" : this.dr2[1].ToString())).ToString();
                        kayit.Srj = this.dr2[2].ToString();
                        kayit.Istif_adet = this.dr2[3].ToString();
                        kayit.Kutuk_satis = this.dr2[4].ToString();
                        kayit.Tel_cubuk_haddesi = (Convert.ToInt32(this.dr2[6].ToString().Equals("") ? "0" : this.dr2[6].ToString()) +
                                             Convert.ToInt32(this.dr2[7].ToString().Equals("") ? "0" : this.dr2[7].ToString())).ToString();
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
                        kayit.Ocak_onu = this.dr2[5].ToString();

                        kayit.Sonuc = ((Convert.ToInt32(this.dr2[5].ToString().Equals("") ? "0" : this.dr2[5].ToString()) +
                                      Convert.ToInt32(kayit.Kutuk_sayisi.Equals("") ? "0" : kayit.Kutuk_sayisi)) -
                                        (Convert.ToInt32(kayit.Srj.Equals("") ? "0" : kayit.Srj) +
                                      Convert.ToInt32(kayit.Istif_adet.Equals("") ? "0" : kayit.Istif_adet) +
                                       Convert.ToInt32(kayit.Kutuk_satis.Equals("") ? "0" : kayit.Kutuk_satis) +
                                      Convert.ToInt32(kayit.Tel_cubuk_haddesi.Equals("") ? "0" : kayit.Tel_cubuk_haddesi))).ToString();
                        kayit.Aciklama = this.dr[2].ToString() + " " + this.dr2[8].ToString() + "\n" + this.dr2[9].ToString();

                    }
                    kayitlar.Add(kayit);
                }
            }


            this.dr.Close();
            this.dr.Dispose();


            return kayitlar;
        }




        //Ana stok

        public List<Izlenebilirlik_bilgileri> ana_stok_listele_data_read(string ebat)
        {
            List<Izlenebilirlik_bilgileri> kayitlar = new List<Izlenebilirlik_bilgileri>();

            this.sql = " SELECT EBAT,CELIKCINSI, BOY,SUM(ISTIF_ADET),CELIKCINSI_ORJINAL " +
                         "FROM URTHRK.CH_DOKUMNO_ISTIF WHERE " +
                         "EBAT ='" + ebat + "' " +
                         "GROUP BY CELIKCINSI, BOY, EBAT, CELIKCINSI_ORJINAL ORDER BY SUM(ISTIF_ADET) DESC";

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
                    kayit.Ebat = this.dr[0].ToString();
                    kayit.Celik_cinsi = this.dr[1].ToString();
                    kayit.Boy = this.dr[2].ToString();
                    kayit.Istif_adet = this.dr[3].ToString();
                    string sqlx = "SELECT KATSAYI FROM(SELECT * FROM URTTNM.KATSAYI_TARTIMDAN WHERE EBAT ='" + ebat + "' AND BOY = '" + kayit.Boy + "' " +
                        " AND CC = '" + kayit.Celik_cinsi + "'  ORDER BY TARIH DESC, VRD) WHERE ROWNUM = 1";
                    this.cmd.CommandText = sqlx;
                    this.dr2 = this.cmd.ExecuteReader();
                    while (this.dr2.Read())
                    {
                        string tonaj = this.dr2[0].ToString();
                        kayit.Kutuk_tonaji = Convert.ToDouble(tonaj) / 1000 * Convert.ToDouble(kayit.Istif_adet);
                    }

                    kayit.Celik_cinsi_orj = this.dr[4].ToString();
                    kayitlar.Add(kayit);

                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;
        }

        public List<Izlenebilirlik_bilgileri> tum_ebatlarin_stok_takibi()
        {
            List<Izlenebilirlik_bilgileri> kayitlar = new List<Izlenebilirlik_bilgileri>();

            this.sql = " SELECT EBAT,CELIKCINSI, BOY,SUM(ISTIF_ADET) " +
                         "FROM URTHRK.CH_DOKUMNO_ISTIF " +
                         "GROUP BY CELIKCINSI, BOY, EBAT, CELIKCINSI_ORJINAL ORDER BY EBAT";

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
                    kayit.Ebat = this.dr[0].ToString();
                    kayit.Celik_cinsi = this.dr[1].ToString();
                    kayit.Boy = this.dr[2].ToString();
                    kayit.Istif_adet = this.dr[3].ToString();
                    string sqlx = "SELECT KATSAYI FROM(SELECT * FROM URTTNM.KATSAYI_TARTIMDAN WHERE EBAT='" + kayit.Ebat + "'" +
                        " AND BOY = '" + kayit.Boy + "' AND CC = '" + kayit.Celik_cinsi + "'  ORDER BY TARIH DESC, VRD) WHERE ROWNUM = 1";
                    this.cmd.CommandText = sqlx;
                    this.dr2 = this.cmd.ExecuteReader();
                    while (this.dr2.Read())
                    {
                        string tonaj = this.dr2[0].ToString();
                        kayit.Kutuk_tonaji = Convert.ToDouble(tonaj) / 1000 * Convert.ToDouble(kayit.Istif_adet);
                    }

                    kayitlar.Add(kayit);





                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;
        }
        public List<string> Cmb_ebat_doldur()
        {
            List<string> kayitlar = new List<string>();
            string sql = "SELECT DISTINCT(EBAT) FROM URTHRK.CH_DOKUMNO_ISTIF ORDER BY EBAT";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = sql;
            this.dr = this.cmd.ExecuteReader();
            while (this.dr.Read())
            {
                string ebat = dr[0].ToString();

                kayitlar.Add(ebat);
            }
            return kayitlar;
        }
        public List<Izlenebilirlik_bilgileri> Celik_cinsine_gore_Stok_takip(string celik_cinsi)
        {

            List<Izlenebilirlik_bilgileri> kayitlar = new List<Izlenebilirlik_bilgileri>();
            this.sql = " SELECT STOK_YERI, DOKUMNO, ISTIF_YERI, ISTIF_ADET,CELIKCINSI " +
                "FROM URTHRK.CH_DOKUMNO_ISTIF " +
                "WHERE CELIKCINSI = '" + celik_cinsi + "' " +
                "ORDER BY ISTIF_ADET";
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
                    kayit.Stok_yeri = this.dr[0].ToString();
                    kayit.Dokum_no = Convert.ToInt32(this.dr[1].ToString());
                    kayit.Istif_yeri = this.dr[2].ToString();
                    kayit.Istif_adet = this.dr[3].ToString();
                    kayit.Celik_cinsi = this.dr[4].ToString();
                    kayitlar.Add(kayit);

                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;



        }


        public string tarihyaz(int dokum_no = 0)
        {
            string sql = "Select DOKUMTAR FROM URTHRK.CH_DOKUMNO_URETIM WHERE DNO=" + dokum_no + "";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = sql;
            this.dr = this.cmd.ExecuteReader();
            while (this.dr.Read())
            {
                gelentarih = this.dr[0].ToString();
            }

            return gelentarih;
        }
        public void Disconnect()
        {
            if (this.conn.State == System.Data.ConnectionState.Open)
            {
                this.conn.Close();
            }
        }


        //public void Disconnect_access()
        //{
        //    if (this.con_access.State == System.Data.ConnectionState.Open)
        //    {
        //        this.con_access.Close();
        //    }
        //}

    }
}
