using diler.Entity;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace diler.Dal
{
    public class Login_db
    {

        OracleConnection conn, conn2;
        string connetionString, sql;
        OracleCommand cmd;
        OracleDataReader dr;
        public string birim, kullanici,kullanici_ozet;

        public Login_db()
        {
            this.connetionString = @"Data Source=(DESCRIPTION=" +
                "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.198.191)(PORT=1521)))" +
                "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=DLRORA)));" + "User Id=IK;Password=IK;";

            this.cmd = new OracleCommand();
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
        public string kullanici_giris(string user, string password)
        {
            this.sql = "SELECT * FROM URTTNM.USRTNM" +
                      " WHERE USERNAME='" + user + "' AND SIFRE='" + password + "'";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            while (this.dr.Read())
            {
                kullanici = this.dr[7].ToString();

            }
            this.dr.Close();
            this.dr.Dispose();
            return kullanici;


        }
        public string Ikden_Unite_bul(int Id)
        {
            this.sql = "SELECT * FROM IK.UNITESI WHERE ID="+Id+"";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            while (this.dr.Read())
            {
                kullanici_ozet = this.dr[2].ToString() + this.dr[3].ToString();

            }
            this.dr.Close();
            this.dr.Dispose();
            return kullanici_ozet;


        }



        public List<Kullanici_bilgileri> kullanici_bilgisi_getir(object kullanici)
        {
            List<Kullanici_bilgileri> kayitlar = new List<Kullanici_bilgileri>();
            this.sql = "SELECT PERFORMANS,IKID,ADSOYAD,FRMNUM " +
                     "FROM URTTNM.USRTNM WHERE " +
                     "USERNAME='" + kullanici + "'";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            while (this.dr.Read())
            {
                Kullanici_bilgileri kayit = new Kullanici_bilgileri();
                kayit.izin = this.dr[0].ToString();
                kayit.Ik_id = this.dr[1].ToString();
                kayit.Ik_adsadx = this.dr[2].ToString();
                kayit.FRMKOD= this.dr[3].ToString();
                kayitlar.Add(kayit);


            }
            this.dr.Close();
            this.dr.Dispose();
            return kayitlar;
        }

        public List<Kullanici_bilgileri> kullanici_bilgisi_getirWebSip(object kullanici, object sifre)
        {
            List<Kullanici_bilgileri> kayitlar = new List<Kullanici_bilgileri>();
            this.sql = "SELECT * from  URTTNM.USRSIPARIS " +
                     " where URTTNM.USRSIPARIS.USRNAME='" + kullanici + "'" +
                     " AND URTTNM.USRSIPARIS.PASSWORD='" + sifre + "'";

            this.cmd.Parameters.Clear();
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            while (this.dr.Read())
            {
                Kullanici_bilgileri kayit = new Kullanici_bilgileri();
                kayit.izin = this.dr[0].ToString();
                kayit.Ik_id = this.dr[1].ToString();
                kayit.Ik_adsadx = this.dr[3].ToString();
                kayit.PRGKOD = this.dr[0].ToString();
                kayitlar.Add(kayit);


            }
            this.dr.Close();
            this.dr.Dispose();
            return kayitlar;
        }

        public List<Kullanici_bilgileri> ana_menu_gorulecekler(object kullanici)
        {
            List<Kullanici_bilgileri> kayitlar = new List<Kullanici_bilgileri>();
            this.sql = "Select URTTNM.PRGLIST.BRM FROM URTTNM.PRGLIST " +
                      "INNER JOIN URTTNM.YETKI ON URTTNM.PRGLIST.PRGKOD = URTTNM.YETKI.PRGKOD " +
                      "AND(((URTTNM.YETKI.KULLANICI) ='" + kullanici + "')) " +
                      "GROUP BY URTTNM.PRGLIST.BRM,URTTNM.PRGLIST.YETKILI1 " +
                      "HAVING URTTNM.PRGLIST.YETKILI1='WEB' " +
                      "ORDER BY URTTNM.PRGLIST.BRM";

            this.cmd.Parameters.Clear();
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {

                Kullanici_bilgileri kayit = new Kullanici_bilgileri();
                kayit.birim = "0";
                kayitlar.Add(kayit);
            }
            else
            {
                while (this.dr.Read())
                {
                    Kullanici_bilgileri kayit = new Kullanici_bilgileri();
                    kayit.birim = this.dr[0].ToString();
                    kayitlar.Add(kayit);

                }
            }
            this.dr.Close();
            this.dr.Dispose();
            return kayitlar;

        }


        public List<Kullanici_bilgileri> ana_menu_listesi(object kullanici, object Left_substr_donen, string birim)
        {
            List<Kullanici_bilgileri> kayitlar = new List<Kullanici_bilgileri>();

            sql = " SELECT " + Left_substr_donen + " , PRGLIST.PRGADI, YETKI.SS, YETKI.LST, PRGLIST.PRGKOD";
            sql = sql + " FROM URTTNM.PRGLIST INNER JOIN URTTNM.YETKI ON PRGLIST.PRGKOD = YETKI.PRGKOD";
            sql = string.Format("{0} WHERE(((YETKI.KULLANICI) ='{1}'))", sql, kullanici);
            sql = sql + " GROUP BY " + Left_substr_donen + ", PRGLIST.PRGADI, PRGLIST.BRM, YETKI.SS, YETKI.LST, PRGLIST.PRGKOD";
            sql = sql + " HAVING(((PRGLIST.BRM) = '" + birim + "'))";
            sql = sql + " ORDER BY PRGLIST.BRM, PRGLIST.PRGKOD";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            while (this.dr.Read())
            {
                Kullanici_bilgileri kayit = new Kullanici_bilgileri();

                kayit.donen = this.dr[1].ToString();
                kayit.prg_ad = this.dr[4].ToString();
                kayitlar.Add(kayit);

            }
            this.dr.Close();
            this.dr.Dispose();
            return kayitlar;
        }

    }
}
