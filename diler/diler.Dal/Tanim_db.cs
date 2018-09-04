using diler.Entity;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace diler.Dal
{
    public class Tanim_db
    {


        OracleConnection conn;
        string connetionString, sql;
        SqlConnection con2;
        SqlCommand cmd2;
        OracleCommand cmd;
        OracleDataReader dr;
        public string tarih_parse, saat_parse, kod, kod_ack;
        int tanim_kod;
        public string kutuk_sayisi_ds2, karisim_sayisi_ds2, kutuk_sayisi_ds1, karisim_sayisi_ds1, aciklama;

        public Tanim_db()
        {
            this.connetionString = @"Data Source=(DESCRIPTION=" +
                "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.198.191)(PORT=1521)))" +
                "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=DLRORA)));" +
                "User Id=URTHRK;Password=URTHRK;";
            string sql_connectionstring = @"Data Source=192.168.189.196\FLMSQL;Initial Catalog=FILMASINSQL;Persist Security Info=True;User ID=sa;Password=PLc123456789";
            this.cmd = new OracleCommand();
            this.conn = new OracleConnection(this.connetionString);
           
            //this.con2 = new SqlConnection(sql_connectionstring);
            //this.cmd2 = new SqlCommand();




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
            //if (this.con2.State != System.Data.ConnectionState.Open)
            //{
            //    try
            //    {
            //        this.con2.Open();
            //        this.cmd2.Connection = this.con2;
            //    }
            //    catch
            //    {
            //        throw new System.InvalidOperationException("Veri Tabani baglantisi kurulamiyor!");
            //    }
            //}
        }



        public List<Tanim_bilgileri> tanimlari_listele_data_read(string tesis, string tanim_tipi)
        {
            List<Tanim_bilgileri> kayitlar = new List<Tanim_bilgileri>();
            this.sql = "SELECT * " +
                        "FROM URTTNM.TANIMLAR " +
                        "WHERE ";

            this.sql += "  TESIS= '" + tesis + "'" +
                    " AND TNMTIPI ='" + tanim_tipi + "' ORDER BY AUTONUM DESC";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Tanim_bilgileri kayit = new Tanim_bilgileri();
                kayit.Tanim_tipi = "Listelenecek Kayıt Bulunamadı !!";
                kayit.Id = 0;
                kayitlar.Add(kayit);
            }
            else
            {

                while (this.dr.Read())
                {
                    Tanim_bilgileri kayit = new Tanim_bilgileri();
                    kayit.Id = 1;
                    kayit.Tanim_tipi = tanim_tipi;
                    kayit.Tesis = tesis;
                    kayit.Ekransirano = this.dr[3].ToString();
                    kayit.Kod = this.dr[5].ToString();
                    kayit.Kod_ack = this.dr[6].ToString();
                    kayit.As400kod = this.dr[7].ToString();
                    kayit.As400_ambardepo = this.dr[15].ToString();
                    kayit.prg1 = this.dr[12].ToString();
                    kayit.prg2 = this.dr[13].ToString();
                    kayitlar.Add(kayit);

                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;
        }
     
        public List<Tanim_bilgileri> tanimlari_ekle_data_read(string tesis, string tanim_tipi)
        {
            List<Tanim_bilgileri> kayitlar = new List<Tanim_bilgileri>();
            this.sql = " SELECT MAX(KOD)FROM URTTNM.TANIMLAR WHERE ";
            this.sql += "  TESIS= '" + tesis + "'" +
                    " AND TNMTIPI ='" + tanim_tipi + "' ";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Tanim_bilgileri kayit = new Tanim_bilgileri();
                kayit.Tanim_tipi = "Listelenecek Kayıt Bulunamadı !!";
                kayit.Id = 0;
                kayitlar.Add(kayit);
            }
            else
            {

                while (this.dr.Read())
                {
                    Tanim_bilgileri kayit = new Tanim_bilgileri();
                    kayit.Id = 1;
                    kayit.Tanim_tipi = tanim_tipi;
                    kayit.Tesis = tesis;
                    kayit.Kod = (Convert.ToInt32(this.dr[0].ToString()) + 1).ToString();
                    kayitlar.Add(kayit);

                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;
        }
     
    
        public int tanim_ekle(string tesis, string tanim_tipi, int tanim_tipi_kod, string kod_ack, string as400_kod, string as400ambar_depo)
        {

            Tanim_bilgileri kayit = new Tanim_bilgileri();
            if (tanim_tipi != "FLM")
            {
                string ayrilma = 'D' + tesis;
                if (tanim_tipi == "STANDART")
                {
                    string sql_standart = "INSERT INTO URTTNM.STANDART VALUES('D','" + tanim_tipi_kod + "','" + ayrilma + "','" + as400_kod + "', " +
                            "'" + kod_ack + "',NULL" + ",NULL" + ",NULL" + ",NULL" + ")";
                    this.cmd.CommandText = sql_standart;
                    this.cmd.Parameters.Clear();
                    this.cmd.ExecuteNonQuery();
                }
                if (tanim_tipi == "BOY")
                {
                    string sql_boy = "INSERT INTO URTTNM.BOY VALUES('D','" + ayrilma + "','" + tanim_tipi_kod + "', " +
                " '" + kod_ack + "','" + as400_kod + "',NULL" + ",NULL" + ",NULL" + ")";
                    this.cmd.CommandText = sql_boy;
                    this.cmd.Parameters.Clear();
                    this.cmd.ExecuteNonQuery();
                }
                if (tanim_tipi == "KALITE" && kod_ack != "")
                {
                    string sql_kalite = "INSERT INTO URTTNM.KALITE VALUES('D','" + tanim_tipi_kod + "','" + ayrilma + "','" + as400_kod + "', " +
                     " '" + kod_ack + "',NULL" + ",NULL" + ",NULL" + ")";
                    this.cmd.CommandText = sql_kalite;
                    this.cmd.Parameters.Clear();
                    this.cmd.ExecuteNonQuery();
                }

                if (tanim_tipi == "CAP")
                {
                    string sql_cap = "INSERT INTO URTTNM.CAP VALUES('D','" + ayrilma + "','" + tanim_tipi_kod + "','" + kod_ack + "','" + as400_kod + "', " +
                   " NULL" + ",NULL" + ",NULL" + ",NULL" + ")";
                    this.cmd.CommandText = sql_cap;
                    this.cmd.Parameters.Clear();
                    this.cmd.ExecuteNonQuery();
                }
                if (tanim_tipi == "EBAT")
                {
                    string sql_ebat = "INSERT INTO URTTNM.EBAT VALUES('D','" + ayrilma + "','" + tanim_tipi_kod + "','" + kod_ack + "', " +
                " '" + as400_kod + "',NULL" + ",NULL" + ",NULL" + ")";
                    this.cmd.CommandText = sql_ebat;
                    this.cmd.Parameters.Clear();
                    this.cmd.ExecuteNonQuery();
                }

            }
            if (tanim_tipi == "FLM")
            {
                string ayrilma = " F";
                if (tanim_tipi == "STANDART")
                {
                    string sql_standart = "INSERT INTO URTTNM.STANDART VALUES('D','" + tanim_tipi_kod + "','" + ayrilma + "','" + as400_kod + "', " +
                            "'" + kod_ack + "',NULL" + ",NULL" + ",NULL" + ",NULL" + ")";
                    this.cmd.CommandText = sql_standart;
                    this.cmd.Parameters.Clear();
                    this.cmd.ExecuteNonQuery();
                }
                if (tanim_tipi == "BOY")
                {
                    string sql_boy = "INSERT INTO URTTNM.BOY VALUES('D','" + ayrilma + "','" + tanim_tipi_kod + "', " +
                " '" + kod_ack + "','" + as400_kod + "',NULL" + ",NULL" + ",NULL" + ")";
                    this.cmd.CommandText = sql_boy;
                    this.cmd.Parameters.Clear();
                    this.cmd.ExecuteNonQuery();
                }
                if (tanim_tipi == "KALITE" && kod_ack != "")
                {
                    string sql_kalite = "INSERT INTO URTTNM.KALITE VALUES('D','" + tanim_tipi_kod + "','" + ayrilma + "','" + as400_kod + "', " +
                     " '" + kod_ack + "',NULL" + ",NULL" + ",NULL" + ")";
                    this.cmd.CommandText = sql_kalite;
                    this.cmd.Parameters.Clear();
                    this.cmd.ExecuteNonQuery();
                }

                if (tanim_tipi == "CAP")
                {
                    string sql_cap = "INSERT INTO URTTNM.CAP VALUES('D','" + ayrilma + "','" + tanim_tipi_kod + "','" + kod_ack + "','" + as400_kod + "', " +
                   " NULL" + ",NULL" + ",NULL" + ",NULL" + ")";
                    this.cmd.CommandText = sql_cap;
                    this.cmd.Parameters.Clear();
                    this.cmd.ExecuteNonQuery();
                }
                if (tanim_tipi == "EBAT")
                {
                    string sql_ebat = "INSERT INTO URTTNM.EBAT VALUES('D','" + ayrilma + "','" + tanim_tipi_kod + "','" + kod_ack + "', " +
                                      " '" + as400_kod + "',NULL" + ",NULL" + ",NULL" + ")";
                    this.cmd.CommandText = sql_ebat;
                    this.cmd.Parameters.Clear();
                    this.cmd.ExecuteNonQuery();
                }

            }

            this.sql = "INSERT INTO URTTNM.TANIMLAR  VALUES(NULL" + ",'" + tesis + "','" + tanim_tipi + "',NULL" + ",NULL" + ", " +
                "" + tanim_tipi_kod + ",'" + kod_ack + "','" + as400_kod + "',NULL" + ",NULL" + ",NULL" + ",NULL" + ",'0','0','0','" + as400ambar_depo + "')";
            this.cmd.CommandText = this.sql;
            this.cmd.Parameters.Clear();
            this.cmd.ExecuteNonQuery();

            // insert success
            return 1;

        }


        public int tanim_tipi_kod_bul(string tesis, string tanim_tipi)
        {


            string sql = "select (Max(kod)+1) FROM URTTNM.TANIMLAR WHERE TESIS='" + tesis + "' AND TNMTIPI='" + tanim_tipi + "'";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = sql;
            this.dr = this.cmd.ExecuteReader();
            while (this.dr.Read())
            {
                tanim_kod = Convert.ToInt32(this.dr[0].ToString().Equals("") ? "1" : this.dr[0].ToString());
            }
            return tanim_kod;

        }

        //****
        public List<Tanim_bilgileri> standart_ozellikleri()
        {
            List<Tanim_bilgileri> kayitlar = new List<Tanim_bilgileri>();
            string sql = "SELECT KOD,KOD_ACK FROM URTTNM.TANIMLAR WHERE TNMTIPI='STANDART' ORDER BY KOD";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = sql;
            this.dr = this.cmd.ExecuteReader();
            while (this.dr.Read())
            {
                Tanim_bilgileri kayit = new Tanim_bilgileri();
                kayit.Kod = dr[0].ToString();
                kayit.prg1 = dr[1].ToString();
                kayitlar.Add(kayit);
            }
            return kayitlar;
        }
        public List<Tanim_bilgileri> kalite_ozellikleri()
        {
            List<Tanim_bilgileri> kayitlar = new List<Tanim_bilgileri>();
            string sql = "SELECT KOD,KOD_ACK FROM URTTNM.TANIMLAR WHERE TNMTIPI='KALITE' ORDER BY KOD";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = sql;
            this.dr = this.cmd.ExecuteReader();
            while (this.dr.Read())
            {
                Tanim_bilgileri kayit = new Tanim_bilgileri();
                kayit.Kod_ack = dr[0].ToString();
                kayit.prg2 = dr[1].ToString();
                kayitlar.Add(kayit);
            }
            return kayitlar;
        }




        public string std_kalite_Insert(string tesis, string tanim_tipi, string kalite_aciklamasi, string std_aciklamasi)
        {
            //standart kod=kod
            //standart kod_ack=prg1
            //kalite kod=kod_ack
            //kalite kod_ack=prg2
            string mesaj;
            List<Tanim_bilgileri> kayit = new List<Tanim_bilgileri>();
            string sql = "SELECT KOD FROM URTTNM.TANIMLAR WHERE TNMTIPI='STANDART' AND KOD_ACK='" + std_aciklamasi + "' AND TESIS='HH'";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = sql;
            this.dr = this.cmd.ExecuteReader();
            while (this.dr.Read())
            {

                kod = dr[0].ToString();
            }
            string sqlx = "SELECT KOD FROM URTTNM.TANIMLAR WHERE TNMTIPI='KALITE' AND KOD_ACK='" + kalite_aciklamasi + "' AND TESIS='HH'";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = sqlx;
            this.dr = this.cmd.ExecuteReader();
            while (this.dr.Read())
            {
                kod_ack = dr[0].ToString();
            }

            string sql_Insert = "INSERT INTO URTTNM.TANIMLAR VALUES(NULL" + ",'" + tesis + "','" + tanim_tipi + "',NULL" + ",NULL" + ", " +
                "'" + kod + "','" + kod_ack + "','0',NULL" + ",NULL" + ",NULL" + ",NULL" + ",'" + std_aciklamasi + "','" + kalite_aciklamasi + "','0','0')";

            this.cmd.CommandText = sql_Insert;
            this.cmd.Parameters.Clear();
            string Insert = this.cmd.ExecuteNonQuery().ToString();
            if (Insert == "1")
            {
                mesaj = "Standart kalite başarıyla eklendi.";      // insert success
            }
            else
            {
                mesaj = "Tekrar deneyiniz";

            }


            return mesaj;

        }



        //AS400 Ekranı

        public List<Tanim_bilgileri> as400_tanimlari_listele(string tanim_tipi)
        {
            List<Tanim_bilgileri> kayitlar = new List<Tanim_bilgileri>();

            if (tanim_tipi == "BOY")
            {
                this.sql = "SELECT * " +
                    "FROM URTTNM.AS400_KOD_BOY ORDER BY AS400KOD ASC ";
            }
            if (tanim_tipi == "CAP")
            {
                this.sql = "SELECT * " +
                    "FROM URTTNM.AS400_KOD_CAP ORDER BY AS400KOD ASC ";
            }
            if (tanim_tipi == "KALITE")
            {
                this.sql = "SELECT * " +
                    "FROM URTTNM.AS400_KOD_KALITE ORDER BY AS400KOD  ASC ";
            }
            if (tanim_tipi == "MAMULSTANDART")
            {
                this.sql = "SELECT * " +
                    "FROM URTTNM.AS400_KOD_MAMULSTANDART ORDER BY AS400KOD ASC ";
            }

            this.cmd.Parameters.Clear();
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Tanim_bilgileri kayit = new Tanim_bilgileri();
                kayit.Tanim_tipi = "Listelenecek Kayıt Bulunamadı !!";
                kayit.Id = 0;
                kayitlar.Add(kayit);
            }
            else
            {

                while (this.dr.Read())
                {
                    Tanim_bilgileri kayit = new Tanim_bilgileri();
                    kayit.Id = 1;
                    kayit.As400kod = this.dr["AS400KOD"].ToString();
                    kayit.As400_isim = this.dr["AS400ISIM"].ToString();
                    kayit.Pc_kod = this.dr["PCKOD"].ToString();
                    kayit.Pc_isim = this.dr["PCISIM"].ToString();

                    kayitlar.Add(kayit);

                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;
        }
        public int as400_tanim_ekle(string as400_kod, string as400_isim, string pc_kod, string pc_isim, string as400tanim_tipi)
        {
            Tanim_bilgileri kayit = new Tanim_bilgileri();

            if (as400tanim_tipi.Trim() != "KALITE")
            {
                this.sql = "INSERT INTO URTTNM.AS400_KOD_" + as400tanim_tipi.Trim() + "  VALUES('" + as400_kod.Trim() + "','" + as400_isim.Trim() + "'," +
                      " '" + pc_kod.Trim() + "','" + pc_isim.Trim() + "')";
            }
            else
            {
                this.sql = "INSERT INTO URTTNM.AS400_KOD_KALITE  VALUES('" + as400_kod.Trim() + "','" + as400_isim.Trim() + "'," +
                      " '" + pc_kod.Trim() + "','" + pc_isim.Trim() + "','','')";
            }

            this.cmd.CommandText = this.sql;
            this.cmd.Parameters.Clear();
            this.cmd.ExecuteNonQuery();

            // insert success
            return 1;

        }

        public string tanim_sil(string as400_kod, string as400_isim, string pc_isim, string tanim_tipi)
        {

            string sql = "DELETE FROM URTTNM.AS400_KOD_" + tanim_tipi.Trim() + " " +
                         "WHERE AS400KOD='" + as400_kod.Trim() + "' AND AS400ISIM='" + as400_isim.Trim() + "' AND PCISIM='" + pc_isim.Trim() + "'";

            this.cmd.CommandText = sql;

            this.cmd.ExecuteNonQuery();

            return "1";
        }


        public void Disconnect()
        {
            if (this.conn.State == System.Data.ConnectionState.Open)
            {
                this.conn.Close();
            }
            //if (this.con2.State == System.Data.ConnectionState.Open)
            //{
            //    this.con2.Close();
            //}
        }

    }
}
