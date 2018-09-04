using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.OracleClient;
using diler.Entity;
using System.IO;

namespace diler.Dal
{
    public class Mesai_db
    {
        OracleConnection conn,conn2;
        string sql,sql1, sqlx, connetionString;
        OracleCommand cmd,cmd1;
        OracleDataReader dr,dr1;


        SqlConnection sql_con;
        SqlCommand sql_cmd;


        SqlDataReader sql_dr, sql_dr_2;
       


        public Mesai_db()
        {
            DateTime dt = new DateTime();
            dt = DateTime.Now;
            string mintarih = String.Format("{0:yyyyMMdd}", dt);
            string d3 = mintarih.ToString().Substring(0, mintarih.ToString().Length - 4);

            this.connetionString = "Data Source=DDCSERVER\\PDKS;Initial Catalog=PRO03_" + d3 + "; User id=UTARIT; Password=4747";
            this.sql_cmd = new SqlCommand();
            this.sql_con = new SqlConnection(this.connetionString);


            this.connetionString = @"Data Source=(DESCRIPTION=" + 
                "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.198.191)(PORT=1521)))" + 
                "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=DLRORA)));" + "User Id=IK;Password=IK;";
            this.cmd = new OracleCommand();
            this.cmd1 = new OracleCommand();
            this.conn = new OracleConnection(this.connetionString);
            this.conn2 = new OracleConnection(this.connetionString);
        }

        public void Connect()
        {
            if (this.conn.State != System.Data.ConnectionState.Open)
            {
                try
                {
                    this.conn.Open();
                    this.cmd.Connection = this.conn;
                    this.cmd1.Connection = this.conn;
                }
                catch
                {
                    throw new System.InvalidOperationException("Oops! Veri Tabani baglantisi kurulamiyor!");
                }
            }
        }
        public void sql_Connect()
        {
            if (this.sql_con.State != System.Data.ConnectionState.Open)
            {
                try
                {
                    this.sql_con.Open();
                    this.sql_cmd.Connection = this.sql_con;
                }
                catch
                {
                    throw new System.InvalidOperationException("Veri Tabani baglantisi kurulamiyor!");
                }
            }
        }

        public List<Personel> personel_bilgileri_data_read(int personel_id = 0, string bolum = null)
        {
            List<Personel> kayitlar = new List<Personel>();

            this.sql = "SELECT IK.NUFUS.ID,IK.NUFUS.ADI,IK.NUFUS.SOYADI,IK.UNITESI.UNITE,IK.UNITESI.BOLUM,IK.UNITESI.ALT_GRUP,IK.NUFUS.D_TAR,IK.NUFUS.M_HAL,IK.AS400IKTABLE.ISE_GIRIS_TAR,IK.TAHSIL.GRUP,IK.AS400IKTABLE.KISIM_KODU,IK.NUFUS.TCNO,IK.FABRIKAGENEL.PDKSNUM " +
                       "FROM IK.NUFUS " +
                       "INNER JOIN IK.UNITESI ON IK.NUFUS.ID=IK.UNITESI.ID " +
                       "INNER JOIN IK.TAHSIL ON IK.NUFUS.ID=IK.TAHSIL.ID " +
                        "INNER JOIN IK.FABRIKAGENEL ON IK.NUFUS.ID = IK.FABRIKAGENEL.ID " +
                       "LEFT JOIN IK.AS400IKTABLE ON IK.NUFUS.ID=IK.AS400IKTABLE.IKID  AND IK.AS400IKTABLE.ISTEN_CIKIS_TAR =0 " +
                       "WHERE IK.NUFUS.DRM=1 AND IK.UNITESI.DURUMU='AKTIF' ";
            if (bolum != null)
                if ((bolum.Contains("Müdür")))
                    this.sql += "AND IK.UNITESI.UNITE LIKE '%" + bolum + "%' ";
                else
                    this.sql += "AND IK.UNITESI.BOLUM LIKE '%" + bolum + "%' ";

            if (personel_id > 0)
                this.sql += "AND IK.NUFUS.ID=" + personel_id;

            this.cmd.CommandText = this.sql;
            this.cmd.Parameters.Clear();
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Personel kayit = new Personel();
                kayit.Ad = "Oops! Personel Bilgileri Bulunamadı.";
                kayit.Id = 0;
                kayitlar.Add(kayit);
            }
            else
            {
                try
                {
                    while (this.dr.Read())
                    {
                        Personel kayit = new Personel();
                        kayit.Id = 1;
                        kayit.Sicil_no = Convert.ToInt32(this.dr[0].ToString());
                        kayit.Ad = this.dr[1].ToString();
                        kayit.Soyad = this.dr[2].ToString();
                        kayit.Unite = this.dr[3].ToString();
                        kayit.Bolum = this.dr[4].ToString();
                        kayit.Alt_grup = this.dr[5].ToString();
                        kayit.Dogum_tarihi = this.dr[6].ToString();
                        kayit.Medeni_hali = this.dr[7].ToString();
                        kayit.Unite_gecis_tarihi = this.dr[8].ToString();
                        kayit.Egitim_durumu = this.dr[9].ToString();
                        if (this.dr[10].ToString().Length > 0)
                            kayit.Kisim_kodu = Convert.ToInt32(this.dr[10].ToString());

                        kayit.Tc_no = Convert.ToInt64(this.dr[11].ToString());
                        kayit.Pdksnum = Convert.ToInt32(this.dr[12].ToString());
                        //this.sql = "SELECT TARIH,HESAPLANAN FROM FAZLAMESAI WHERE SICILNO=" + kayit.Pdksnum + " AND ONAY=0 AND ";
                        //this.sql_cmd.CommandText = this.sql;
                        //this.sql_cmd.Parameters.Clear();
                        //this.sql_dr = this.sql_cmd.ExecuteReader();
                        //while (this.sql_dr.Read())
                        //{
                        //    kayit.Mesai_tarih = Convert.ToInt32(this.sql_dr[0].ToString());
                        //    kayit.Hesaplanan = Convert.ToInt32(this.sql_dr[1].ToString());
                        //    //kayitlar.Add(kayit);
                        //}
                        //this.sql_dr.Close();
                        //this.sql_dr.Dispose();
                        kayitlar.Add(kayit);
                    }
                }
                catch
                {

                    throw;
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;
        }


        public List<Personel> personel_bilgileri_data_read_test(int personel_id = 0, string mesaitarih = null, string bolum = null, string secili_alt_grup = null)
        {
            List<Personel> kayitlar = new List<Personel>();

            this.sql = "SELECT IK.NUFUS.ID,IK.NUFUS.ADI,IK.NUFUS.SOYADI,IK.UNITESI.UNITE,IK.UNITESI.BOLUM,IK.UNITESI.ALT_GRUP,IK.NUFUS.D_TAR,IK.NUFUS.M_HAL,IK.AS400IKTABLE.ISE_GIRIS_TAR,IK.TAHSIL.GRUP,IK.AS400IKTABLE.KISIM_KODU,IK.NUFUS.TCNO,IK.FABRIKAGENEL.PDKSNUM " +
                       "FROM IK.NUFUS " +
                       "INNER JOIN IK.UNITESI ON IK.NUFUS.ID=IK.UNITESI.ID " +
                       "INNER JOIN IK.TAHSIL ON IK.NUFUS.ID=IK.TAHSIL.ID " +
                        "INNER JOIN IK.FABRIKAGENEL ON IK.NUFUS.ID = IK.FABRIKAGENEL.ID " +
                       "LEFT JOIN IK.AS400IKTABLE ON IK.NUFUS.ID=IK.AS400IKTABLE.IKID  AND IK.AS400IKTABLE.ISTEN_CIKIS_TAR =0 " +
                       "WHERE IK.NUFUS.DRM=1 AND IK.UNITESI.DURUMU='AKTIF' ";
            if (bolum != null)
                if ((bolum.Contains("Müdür")))
                    this.sql += "AND IK.UNITESI.UNITE LIKE '%" + bolum + "%' ";
                else
                    this.sql += "AND IK.UNITESI.BOLUM LIKE '%" + bolum + "%' ";
            if (secili_alt_grup != "all")

                this.sql += "AND IK.UNITESI.ALT_GRUP LIKE '%" + secili_alt_grup + "%' ";


            if (personel_id > 0)
                this.sql += "AND IK.NUFUS.ID=" + personel_id;

            this.cmd.CommandText = this.sql;
            this.cmd.Parameters.Clear();
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Personel kayit = new Personel();
                kayit.Ad = "Oops! Personel Bilgileri Bulunamadı.";
                kayit.Id = 0;
                kayitlar.Add(kayit);
            }
            else
            {
                try
                {
                    while (this.dr.Read())
                    {
                        Personel kayit = new Personel();
                        kayit.Id = 1;
                        kayit.Sicil_no = Convert.ToInt32(this.dr[0].ToString());
                        kayit.Ad = this.dr[1].ToString();
                        kayit.Soyad = this.dr[2].ToString();
                        kayit.Unite = this.dr[3].ToString();
                        kayit.Bolum = this.dr[4].ToString();
                        kayit.Alt_grup = this.dr[5].ToString();
                        kayit.Dogum_tarihi = this.dr[6].ToString();
                        kayit.Medeni_hali = this.dr[7].ToString();
                        kayit.Unite_gecis_tarihi = this.dr[8].ToString();
                        kayit.Egitim_durumu = this.dr[9].ToString();
                        if (this.dr[10].ToString().Length > 0)
                            kayit.Kisim_kodu = Convert.ToInt32(this.dr[10].ToString());

                        kayit.Tc_no = Convert.ToInt64(this.dr[11].ToString());
                        kayit.Pdksnum = Convert.ToInt32(this.dr[12].ToString());
                        this.sql = "SELECT TARIH,HESAPLANAN FROM FAZLAMESAI_TEST WHERE SICILNO=" + kayit.Pdksnum + " AND ONAY=0 AND TARIH=" + mesaitarih + "";
                        this.sql_cmd.CommandText = this.sql;
                        this.sql_cmd.Parameters.Clear();
                        this.sql_dr = this.sql_cmd.ExecuteReader();
                        while (this.sql_dr.Read())
                        {
                            kayit.Mesai_tarih = Convert.ToInt32(this.sql_dr[0].ToString());
                            kayit.Hesaplanan = Convert.ToInt32(this.sql_dr[1].ToString());
                        }
                        this.sql_dr.Close();
                        this.sql_dr.Dispose();
                        this.sqlx = "SELECT KABULSAATI,HAREKET FROM HAREKET_TEST WHERE SICILNO=" + kayit.Pdksnum + " AND KABULTARIHI=" + kayit.Mesai_tarih + " ";
                        this.sql_cmd.CommandText = this.sqlx;
                        this.sql_cmd.Parameters.Clear();
                        this.sql_dr_2 = sql_cmd.ExecuteReader();
                        while (sql_dr_2.Read())
                        {
                            kayit.Hareket = this.sql_dr_2[1].ToString();
                            if (kayit.Hareket == "G")
                            {
                                kayit.Mesai_giris_saati = this.sql_dr_2[0].ToString();

                                string hesaplanan_mesai_saati = (Convert.ToInt32(kayit.Mesai_giris_saati) / 60).ToString();
                                string hesaplanan_mesai_dakikası = (Convert.ToInt32(kayit.Mesai_giris_saati) - Convert.ToInt32(hesaplanan_mesai_saati) * 60).ToString();
                                if (hesaplanan_mesai_saati.Length == 1)
                                {
                                    hesaplanan_mesai_saati = "0" + hesaplanan_mesai_saati;

                                }
                                if (hesaplanan_mesai_dakikası.Length == 1)
                                {
                                    hesaplanan_mesai_dakikası = "0" + hesaplanan_mesai_dakikası;

                                }
                                kayit.Mesai_giris_saati = hesaplanan_mesai_saati + ":" + hesaplanan_mesai_dakikası;

                            }
                            if (kayit.Hareket == "C")
                            {
                                kayit.Mesai_cikis_saati = this.sql_dr_2[0].ToString();

                                string hesaplanan_mesai_saati = (Convert.ToInt32(kayit.Mesai_cikis_saati) / 60).ToString();
                                string hesaplanan_mesai_dakikası = (Convert.ToInt32(kayit.Mesai_cikis_saati) - Convert.ToInt32(hesaplanan_mesai_saati) * 60).ToString();
                                if (hesaplanan_mesai_saati.Length == 1)
                                {
                                    hesaplanan_mesai_saati = "0" + hesaplanan_mesai_saati;

                                }
                                if (hesaplanan_mesai_dakikası.Length == 1)
                                {
                                    hesaplanan_mesai_dakikası = "0" + hesaplanan_mesai_dakikası;

                                }
                                kayit.Mesai_cikis_saati = hesaplanan_mesai_saati + ":" + hesaplanan_mesai_dakikası;

                            }

                            //kayitlar.Add(kayit);
                        }

                        this.sql_dr_2.Close();
                        this.sql_dr_2.Dispose();
                        kayitlar.Add(kayit);
                    }
                }
                catch
                {
                    throw;
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;
        }

        public List<Personel> personel_bilgileri_data_read_MUDUR(int personel_id = 0, string mesaitarih = null, string bolum = null, string secili_alt_grup = null,string KayitTar=null)
        {
            List<Personel> kayitlar = new List<Personel>();

            this.sql = "SELECT IK.NUFUS.ID,IK.NUFUS.ADI,IK.NUFUS.SOYADI,IK.UNITESI.UNITE,IK.UNITESI.BOLUM,IK.UNITESI.ALT_GRUP,IK.NUFUS.D_TAR,IK.NUFUS.M_HAL,IK.AS400IKTABLE.ISE_GIRIS_TAR,IK.TAHSIL.GRUP,IK.AS400IKTABLE.KISIM_KODU,IK.NUFUS.TCNO,IK.FABRIKAGENEL.PDKSNUM " +
                       "FROM IK.NUFUS " +
                       "INNER JOIN IK.UNITESI ON IK.NUFUS.ID=IK.UNITESI.ID " +
                       "INNER JOIN IK.TAHSIL ON IK.NUFUS.ID=IK.TAHSIL.ID " +
                        "INNER JOIN IK.FABRIKAGENEL ON IK.NUFUS.ID = IK.FABRIKAGENEL.ID " +
                       "LEFT JOIN IK.AS400IKTABLE ON IK.NUFUS.ID=IK.AS400IKTABLE.IKID  AND IK.AS400IKTABLE.ISTEN_CIKIS_TAR =0 " +
                       "WHERE IK.NUFUS.DRM=1 AND IK.UNITESI.DURUMU='AKTIF' ";
            if (bolum != null)
                if ((bolum.Contains("Müdür")))
                    this.sql += "AND IK.UNITESI.UNITE LIKE '%" + bolum + "%' ";
                else
                    this.sql += "AND IK.UNITESI.BOLUM LIKE '%" + bolum + "%' ";
            if (secili_alt_grup != "all")

                this.sql += "AND IK.UNITESI.ALT_GRUP LIKE '%" + secili_alt_grup + "%' ";


            if (personel_id > 0)
                this.sql += "AND IK.NUFUS.ID=" + personel_id;

            this.cmd.CommandText = this.sql;
            this.cmd.Parameters.Clear();
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Personel kayit = new Personel();
                kayit.Ad = "Oops! Personel Bilgileri Bulunamadı.";
                kayit.Id = 0;
                kayitlar.Add(kayit);
            }
            else
            {
                try
                {

                    while (this.dr.Read())
                    {
                        Personel kayit = new Personel();
                        kayit.Id = 1;
                        kayit.Sicil_no = Convert.ToInt32(this.dr[0].ToString());
                        kayit.Ad = this.dr[1].ToString();
                        kayit.Soyad = this.dr[2].ToString();
                        kayit.Unite = this.dr[3].ToString();
                        kayit.Bolum = this.dr[4].ToString();
                        kayit.Alt_grup = this.dr[5].ToString();
                        kayit.Dogum_tarihi = this.dr[6].ToString();
                        kayit.Medeni_hali = this.dr[7].ToString();
                        kayit.Unite_gecis_tarihi = this.dr[8].ToString();
                        kayit.Egitim_durumu = this.dr[9].ToString();
                        kayit.Pdksnum = Convert.ToInt32(this.dr[12].ToString());

                        string secilen_tarih = String.Format("{0:yyyyMMdd}", KayitTar);

                        string secilen_yil = secilen_tarih.Substring(0, 4);
                        string secilen_ay = secilen_tarih.Substring(5, 2);
                        string secilen_gun = secilen_tarih.Substring(8, 2);



                        kayit.Mesai_tarih = Convert.ToInt32(secilen_yil+ secilen_ay+ secilen_gun);

                        if (this.dr[10].ToString().Length > 0)
                            kayit.Kisim_kodu = Convert.ToInt32(this.dr[10].ToString());

                        
                        this.sql = "SELECT * FROM IK.MESAI_YILLIKIZIN WHERE ID=" + kayit.Sicil_no + " AND TARIH1=" + kayit.Mesai_tarih +
                            " AND SEF_ONAY =1" +
                            " AND MUDUR_ONAY =0";

                        this.cmd1.CommandText = this.sql.ToString();
                        this.cmd1.Parameters.Clear();
                        dr1 = cmd1.ExecuteReader();

                        while (dr1.Read())
                        {
                            kayitlar.Add(kayit);
                            kayit.MesaiNedeni = this.dr1[2].ToString();
                            kayit.MesaiAciklaması= this.dr1[9].ToString();
                            kayit.Mesai_giris_saati = "X";// this.dr1[1].ToString();
                            kayit.Mesai_cikis_saati = "X"; // this.dr1[1].ToString();
                            kayit.Hesaplanan =Convert.ToInt32(this.dr1[8]) ;
                        }

                        this.dr1.Close();
                        this.dr1.Dispose();
                      
                    }
                }
                catch
                {
                    throw;
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;
        }


        public List<Mesai_yillik_izin> personel_yillik_izin_data_read(int personel_id, int yil = -1)
        {
            int MaxGeriGun, CalısmaYılı;
            Int32 NewTarih;
            string tarih;


            DateTime dt = new DateTime();

            if (yil == -1)
            {
                dt = DateTime.Now;
                yil = dt.Year;
            }



            sql1 = "SELECT  IK.MESAI_YILLIKIZIN_GERIGUNSAYISI.GUN,IK.MESAI_YILLIKIZIN_GERIGUNSAYISI.CALISMA_YIL FROM IK.MESAI_YILLIKIZIN_GERIGUNSAYISI";
            this.cmd1.CommandText = this.sql1.ToString();
            this.cmd1.Parameters.Clear();
            dr1 = cmd1.ExecuteReader();

            while (dr1.Read())
            {
                MaxGeriGun = Convert.ToInt32(this.dr1[0].ToString());
                yil = Convert.ToInt32(this.dr1[1].ToString());
            }

            this.dr1.Close();
            this.dr1.Dispose();




            DateTime dateForButton = DateTime.Now;
            dateForButton = dateForButton.AddDays(-3);  // ERROR: un-representable DateTime
            int mintarih1 = Convert.ToInt32(String.Format("{0:yyyyMMdd}", dateForButton).ToString());


            List<Mesai_yillik_izin> kayitlar = new List<Mesai_yillik_izin>();
            this.sql = "SELECT IK.MESAI_YILLIKIZIN.ID,IK.MESAI_YILLIKIZIN.CIKISTIPI,IK.MESAI_YILLIKIZIN.MESAINEDENI,IK.MESAI_YILLIKIZIN.TARIH1,IK.MESAI_YILLIKIZIN.SURE,IK.MESAI_YILLIKIZIN.GENELACK " +
                       "FROM IK.MESAI_YILLIKIZIN " +
                       " WHERE IK.MESAI_YILLIKIZIN.ID =" + personel_id + " AND IK.MESAI_YILLIKIZIN.TARIH1 LIKE '" + yil.ToString() + "%'" +
                       " AND MUDUR_ONAY=1";

           

            this.cmd.CommandText = this.sql;
            this.cmd.Parameters.Clear();
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Mesai_yillik_izin kayit = new Mesai_yillik_izin();
                kayit.Mesai_nedeni = "Oops! Persomele Ait Mesai Bulunamadı.";
                kayit.Personel_sicil_no = 0;
                kayitlar.Add(kayit);
            }
            else
            {
                try
                {
                    while (this.dr.Read())
                    {
                        Mesai_yillik_izin kayit = new Mesai_yillik_izin();
                        kayit.Personel_sicil_no = Convert.ToInt32(this.dr[0].ToString());
                        kayit.Mesai_cikis_tipi = this.dr[1].ToString();
                        kayit.Mesai_nedeni = this.dr[2].ToString();
                        kayit.Mesai_tarih = this.dr[3].ToString();
                        kayit.Mesai_toplam_saat = Convert.ToDouble(this.dr[4]);
                        kayit.Mesai_genel_aciklama = this.dr[5].ToString();
                        kayitlar.Add(kayit);
                    }
                }
                catch
                {
                    throw;
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;
        }
        public List<Mesai_yillik_izin> personel_yillik_izin_data_read_Tek_Kisi(int personel_id, int yil = -1)
        {
            int MaxGeriGun, CalısmaYılı;
            Int32 NewTarih;
            string tarih;


            DateTime dt = new DateTime();

            if (yil == -1)
            {
                dt = DateTime.Now;
                yil = dt.Year;
            }



            sql1 = "SELECT  IK.MESAI_YILLIKIZIN_GERIGUNSAYISI.GUN,IK.MESAI_YILLIKIZIN_GERIGUNSAYISI.CALISMA_YIL FROM IK.MESAI_YILLIKIZIN_GERIGUNSAYISI";
            this.cmd1.CommandText = this.sql1.ToString();
            this.cmd1.Parameters.Clear();
            dr1 = cmd1.ExecuteReader();

            while (dr1.Read())
            {
                MaxGeriGun = Convert.ToInt32(this.dr1[0].ToString());
                CalısmaYılı = Convert.ToInt32(this.dr1[1].ToString());
            }

            this.dr1.Close();
            this.dr1.Dispose();




            DateTime dateForButton = DateTime.Now;
            dateForButton = dateForButton.AddDays(-3);  // ERROR: un-representable DateTime
            int mintarih1 = Convert.ToInt32(String.Format("{0:yyyyMMdd}", dateForButton).ToString());


            List<Mesai_yillik_izin> kayitlar = new List<Mesai_yillik_izin>();
            this.sql = "SELECT IK.MESAI_YILLIKIZIN.ID,IK.MESAI_YILLIKIZIN.CIKISTIPI,IK.MESAI_YILLIKIZIN.MESAINEDENI,IK.MESAI_YILLIKIZIN.TARIH1,IK.MESAI_YILLIKIZIN.SURE,IK.MESAI_YILLIKIZIN.GENELACK " +
                       "FROM IK.MESAI_YILLIKIZIN " +
                       " WHERE IK.MESAI_YILLIKIZIN.ID =" + personel_id + " AND IK.MESAI_YILLIKIZIN.TARIH1 >= " + mintarih1.ToString();



            this.cmd.CommandText = this.sql;
            this.cmd.Parameters.Clear();
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Mesai_yillik_izin kayit = new Mesai_yillik_izin();
                kayit.Mesai_nedeni = "Oops! Persomele Ait Mesai Bulunamadı.";
                kayit.Personel_sicil_no = 0;
                kayitlar.Add(kayit);
            }
            else
            {
                try
                {
                    while (this.dr.Read())
                    {
                        Mesai_yillik_izin kayit = new Mesai_yillik_izin();
                        kayit.Personel_sicil_no = Convert.ToInt32(this.dr[0].ToString());
                        kayit.Mesai_cikis_tipi = this.dr[1].ToString();
                        kayit.Mesai_nedeni = this.dr[2].ToString();
                        kayit.Mesai_tarih = this.dr[3].ToString();
                        kayit.Mesai_toplam_saat = Convert.ToDouble(this.dr[4]);
                        kayit.Mesai_genel_aciklama = this.dr[5].ToString();
                        kayitlar.Add(kayit);
                    }
                }
                catch
                {
                    throw;
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;
        }


        public bool personel_yillik_izin_kaydet(Mesai_yillik_izin kayit)
        {
            // verilerin kontrolleri yapilacak...
            kayit.Mesai_tarih = kayit.Mesai_tarih.Replace("-", "");
            return personel_yillik_izin_insert(kayit);
        }

        public bool personel_yillik_izin_sil(string mesai_bilgileri)
        {
            // verilerin kontrolleri yapilacak...
            string[] parameter = mesai_bilgileri.Split(',');
            int personel_sicil_no = Convert.ToInt32(parameter[0]);
            int mesai_tarihi = Convert.ToInt32(parameter[1]);
            double toplam_saat = Convert.ToDouble(parameter[2]);

            return personel_yillik_izin_delete(personel_sicil_no, mesai_tarihi, toplam_saat);
        }

        public bool personel_yillik_izin_insert(Mesai_yillik_izin kayit)
        {


            //this.sql = "UPDATE IK.MESAI_YILLIKIZIN SET MUDURR_ONAY=1 " +
            //           " WHERE IK.MESAI_YILLIKIZIN.ID=" + kayit.Personel_sicil_no +
            //           " and IK.MESAI_YILLIKIZIN.TARIH1=" + Convert.ToInt32(kayit.Mesai_tarih);

            
            this.sql = "INSERT INTO IK.MESAI_YILLIKIZIN " +
                       "(IK.MESAI_YILLIKIZIN.ID,IK.MESAI_YILLIKIZIN.CIKISTIPI,IK.MESAI_YILLIKIZIN.MESAINEDENI,IK.MESAI_YILLIKIZIN.TARIH1,IK.MESAI_YILLIKIZIN.SURE,IK.MESAI_YILLIKIZIN.GENELACK,IK.MESAI_YILLIKIZIN.SEF_ONAY,IK.MESAI_YILLIKIZIN.MUDUR_ONAY,IK.MESAI_YILLIKIZIN.IK_ONAY) " +
                       "VALUES" +
                       "(:sicil_no, :cikis_tipi, :mesai_nedeni, :tarih, :sure, :genelack,:sefonay,:muduronay,:ikonay)";
            
            this.cmd.CommandText = this.sql;
            this.cmd.Parameters.Clear();
            this.cmd.Parameters.AddWithValue("sicil_no", kayit.Personel_sicil_no);
            this.cmd.Parameters.AddWithValue("cikis_tipi", kayit.Mesai_cikis_tipi);
            this.cmd.Parameters.AddWithValue("mesai_nedeni", kayit.Mesai_nedeni);
            this.cmd.Parameters.AddWithValue("tarih", Convert.ToInt32(kayit.Mesai_tarih));
            this.cmd.Parameters.AddWithValue("sure", kayit.Mesai_toplam_saat);
            this.cmd.Parameters.AddWithValue("genelack", kayit.Mesai_genel_aciklama);
            this.cmd.Parameters.AddWithValue("sefonay", 1);
            this.cmd.Parameters.AddWithValue("muduronay", 0);
            this.cmd.Parameters.AddWithValue("ikonay", 0);

            int rowCount = this.cmd.ExecuteNonQuery();

            if (rowCount < 1)
            {
                // Oops!!
                return false;
            }
            else
            {
                // insert success
                return true;
            }
        }

        public bool personel_yillik_izin_delete(int personel_sicil_no, int mesai_tarihi, double toplam_saat)
        {
            this.sql = "DELETE FROM IK.MESAI_YILLIKIZIN " +
                       "WHERE IK.MESAI_YILLIKIZIN.ID=:sicil_no AND IK.MESAI_YILLIKIZIN.TARIH1=:tarih AND IK.MESAI_YILLIKIZIN.SURE=:sure";

            this.cmd.CommandText = this.sql;
            this.cmd.Parameters.Clear();
            this.cmd.Parameters.AddWithValue("sicil_no", personel_sicil_no);
            this.cmd.Parameters.AddWithValue("tarih", Convert.ToInt32(mesai_tarihi));
            this.cmd.Parameters.AddWithValue("sure", toplam_saat);

            int rowCount = this.cmd.ExecuteNonQuery();

            if (rowCount < 1)
            {
                // Oops!!
                return false;
            }
            else
            {
                // insert success
                return true;
            }
        }


        public List<Personel> personel_aylik_izin_data_read(string ay, int yil = -1, string bolum = "")
        {

            string tarih = "";
            if (yil == -1)
            {
                DateTime dt = new DateTime();
                dt = DateTime.Now;
                yil = dt.Year;
            }
            if (ay.ToString().Length == 1)
            {
                tarih = yil.ToString() + "0" + ay.ToString();
            }
            else if (ay.ToString().Length == 2)
            {
                tarih = yil.ToString() + ay.ToString();
            }

            List<Personel> kayitlar = new List<Personel>();
            this.sql = "SELECT IK.NUFUS.ID,IK.NUFUS.ADI,IK.NUFUS.SOYADI,IK.UNITESI.ALT_GRUP,SUM(IK.MESAI_YILLIKIZIN.SURE) " +
                       "FROM IK.NUFUS  " +
                       "INNER JOIN IK.UNITESI ON IK.NUFUS.ID=IK.UNITESI.ID " +
                       "INNER JOIN IK.MESAI_YILLIKIZIN ON IK.NUFUS.ID=IK.MESAI_YILLIKIZIN.ID " +
                       "WHERE IK.NUFUS.DRM=1 AND IK.UNITESI.DURUMU='AKTIF' AND IK.MESAI_YILLIKIZIN.TARIH1 LIKE '" + tarih + "%' AND IK.UNITESI.BOLUM LIKE '%" + bolum + "%' " +
                       "GROUP BY IK.MESAI_YILLIKIZIN.ID,IK.NUFUS.ID,IK.NUFUS.ADI,IK.NUFUS.SOYADI,IK.UNITESI.ALT_GRUP";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Personel kayit = new Personel();
                kayit.Ad = "Oops! PersomelE Ait Mesai Bulunamadı.";
                kayit.Sicil_no = 0;
                kayitlar.Add(kayit);
            }
            else
            {
                try
                {
                    while (this.dr.Read())
                    {
                        Personel kayit = new Personel();
                        kayit.Sicil_no = Convert.ToInt32(this.dr[0].ToString());
                        kayit.Ad = this.dr[1].ToString();
                        kayit.Soyad = this.dr[2].ToString();
                        kayit.Alt_grup = this.dr[3].ToString();
                        kayit.Bolum = this.dr[4].ToString();
                        kayitlar.Add(kayit);
                    }
                }
                catch
                {
                    throw;
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;
        }

        public Personel giris_kontrol(string username, string password)
        {
            return giris_kontrol_select(username, password);
        }

        public Personel giris_kontrol_select(string username, string password)
        {
            Personel kayit = new Personel();
            this.sql = "SELECT URTTNM.USRTNM.IKID,URTTNM.USRTNM.ADSOYAD FROM URTTNM.USRTNM" + " WHERE URTTNM.USRTNM.USERNAME='" + username + "' AND URTTNM.USRTNM.SIFRE='" + password + "'";
            this.cmd.CommandText = this.sql;
            this.cmd.Parameters.Clear();
            this.dr = this.cmd.ExecuteReader();

            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                kayit.Sicil_no = 0;
            }
            else
            {
                try
                {
                    while (this.dr.Read())
                    {
                        kayit.Sicil_no = Convert.ToInt32(this.dr[0].ToString());
                        kayit.Ad = this.dr[1].ToString();
                    }
                }
                catch
                {
                    throw;
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return kayit;
        }
        public int Mesai_onay(int kullanici, string mesaineden, int hesaplanan_mesai, string aciklama, int mesai_tarihi)
        {
            if (hesaplanan_mesai != 0)
            {
                this.sql = "UPDATE FAZLAMESAI_TEST SET  NEDEN ='" + mesaineden + "',ONAY=" + -1 + ", FM=" + hesaplanan_mesai + " WHERE SICILNO=" + kullanici + "";
                this.sql_cmd.CommandText = this.sql;
                int rowCount = this.sql_cmd.ExecuteNonQuery();

                if (rowCount < 1)
                {
                    // Error!!
                    return 0;


                }
                else
                {
                    // Connect();
                    Personel kayit = new Personel();
                    this.sql = "SELECT ID  from IK.FABRIKAGENEL WHERE PDKSNUM= " + kullanici + "";
                    this.cmd.CommandText = this.sql;
                    this.cmd.Parameters.Clear();
                    this.dr = this.cmd.ExecuteReader();
                    while (this.dr.Read())
                    {
                        kayit.Sicil_no = Convert.ToInt32(this.dr[0].ToString());
                    }

                    int hesaplanan_mesai_saati = hesaplanan_mesai / 60;
                    int dakika = hesaplanan_mesai - hesaplanan_mesai_saati * 60;
                    string toplam_mesai = hesaplanan_mesai_saati + "." + dakika;
                    //  int toplam_mesai = Convert.ToInt32(toplam_mesaii);

                    this.sql = "INSERT INTO IK.MESAI_YILLIKIZIN  VALUES(" + kayit.Sicil_no + ",'Fazla Mesai','" + mesaineden + "',NULL" + "," + mesai_tarihi + ",NULL" + ",NULL" + ",NULL" + "," + toplam_mesai + ",'" + aciklama + "',NULL" + ",NULL" + ",1"+",0"+",0)";
                    this.cmd.CommandText = this.sql;
                    this.cmd.Parameters.Clear();
                    this.cmd.ExecuteNonQuery();
                    // Disconnect();

                    // insert success
                    return 1;
                }
            }
            else
            {
                return 0;

            }

        }
        public int Mesai_onay_Mudur(int kullanici, string mesaineden, int hesaplanan_mesai, string aciklama, int mesai_tarihi)
        {
                    // Connect();
                    Personel kayit = new Personel();

            this.sql = "SELECT ID  from IK.FABRIKAGENEL WHERE PDKSNUM= " + kullanici + "";
            this.cmd.CommandText = this.sql;
            this.cmd.Parameters.Clear();
            this.dr = this.cmd.ExecuteReader();
            while (this.dr.Read())
            {
                kayit.Sicil_no = Convert.ToInt32(this.dr[0].ToString());
            }

            this.sql = "UPDATE IK.MESAI_YILLIKIZIN SET MUDUR_ONAY=1 " +
                     " WHERE IK.MESAI_YILLIKIZIN.ID=" + kayit.Sicil_no +
                     " and IK.MESAI_YILLIKIZIN.TARIH1=" + mesai_tarihi;
            
                    this.cmd.CommandText = this.sql;
                    this.cmd.Parameters.Clear();
                    this.cmd.ExecuteNonQuery();
                    return 1;

        }

        public int geri_gun_sayisi_bul()
        {

            Mesai_yillik_izin kayit = new Mesai_yillik_izin();
            string sql = "SELECT GUN FROM IK.MESAI_YILLIKIZIN_GERIGUNSAYISI";
            this.cmd.CommandText = sql;
            this.dr = this.cmd.ExecuteReader();
            while (this.dr.Read())
            {
                kayit.Geri_gun_sayisi = Convert.ToInt32(this.dr[0].ToString());
            }

            return kayit.Geri_gun_sayisi;

        }
        public void Disconnect()
        {
            if (this.conn.State == System.Data.ConnectionState.Open)
            {
                this.conn.Close();
            }
        }
        public void sql_Disconnect()
        {
            if (this.sql_con.State == System.Data.ConnectionState.Open)
            {
                this.sql_con.Close();
            }
        }



    }
}