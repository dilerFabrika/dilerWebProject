using diler.Entity;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace diler.Dal
{
    public class Durus_raporu_db
    {
        OracleConnection conn,conn2;
        string connetionString,sql;
        OracleCommand cmd;
        OracleDataReader dr, dr2;
        public string tarih_parse;

        public Durus_raporu_db()
        {
            this.connetionString = @"Data Source=(DESCRIPTION=" +
                "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.198.191)(PORT=1521)))" +
                "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=DLRORA)));" + "User Id=URTHRK; Password=URTHRK;";
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
                    throw new System.InvalidOperationException("Oops! Veri Tabani baglantisi kurulamiyor!");
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

        public List<durus_bilgileri> durus_ozet_data_read(int tarih = 0, int tarih2 = 0)
        {
            List<durus_bilgileri> kayitlar = new List<durus_bilgileri>();
            this.sql = "  SELECT DURUSNEDEN,SUM(SURE),COUNT(DURUSNEDEN) " +
           "  FROM URTHRK.CH_DOKUMNO_DURUS_DATA " +
           "WHERE ";
            if (tarih > 0 && tarih2 > 0)
            {
                this.sql += "  BASTAR >= " + tarih +
                        " AND BASTAR <= " + tarih2 + "  GROUP BY DURUSNEDEN,DURNEDKOD";
            }
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                durus_bilgileri kayit = new durus_bilgileri();
                kayit.ARIZANEDEN = "Listelenecek Kayıt Bulunamadı !!";
                kayit.DURUS_ID = "0";
                kayitlar.Add(kayit);
            }
            else
            {

                while (this.dr.Read())
                {
                    durus_bilgileri kayit = new durus_bilgileri();
                    kayit.DURUS_ID = "1";
                    kayit.DURUSNEDEN = this.dr[0].ToString();
                    kayit.SURE = this.dr[1].ToString();
                    kayit.ADET = this.dr[2].ToString();
                    kayitlar.Add(kayit);

                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;
        }
       

        public List<durus_bilgileri> dokum_bazinda_durus_ozet_read(int tarih = 0, int tarih2 = 0, string durus_nedeni = "")
        {
            List<durus_bilgileri> kayitlar = new List<durus_bilgileri>();
            this.sql = "SELECT ARIZANEDEN,SURE,DNO, BASTAR,ARZNEDKOD,VRD " +
            "FROM URTHRK.CH_DOKUMNO_DURUS_DATA " +
           "WHERE ";
            if (tarih > 0 && tarih2 > 0)
            {
                this.sql += "  BASTAR >= " + tarih +
                        " AND BASTAR <= " + tarih2 + "  AND DURUSNEDEN='" + durus_nedeni.Trim() + "' ORDER BY DNO ASC";
            }
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                durus_bilgileri kayit = new durus_bilgileri();
                kayit.ARIZANEDEN = "Listelenecek Kayıt Bulunamadı !!";
                kayit.DURUS_ID = "0";
                kayitlar.Add(kayit);
            }
            else
            {

                while (this.dr.Read())
                {
                    durus_bilgileri kayit = new durus_bilgileri();
                    kayit.DURUS_ID = "1";
                    kayit.ARIZANEDEN = this.dr[0].ToString();
                    kayit.ARIZAKOD = this.dr[4].ToString();
                    kayit.vrd = this.dr[5].ToString();
                    kayit.SURE = this.dr[1].ToString();
                    kayit.dokumno = this.dr[2].ToString();
                    int dokum_tarihi = Convert.ToInt32(this.dr[3].ToString());
                    tarih_parse = tarihFormat(dokum_tarihi);
                    kayit.tarih = tarih_parse;
                    kayitlar.Add(kayit);

                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;
        }
       

        public List<durus_bilgileri> ariza_bazinda_toplamsure_read(int tarih = 0, int tarih2 = 0, string durus_nedeni = "")
        {
            List<durus_bilgileri> kayitlar = new List<durus_bilgileri>();
            this.sql = "SELECT COUNT(DISTINCT(DNO)),DURUSNEDEN,ARIZANEDEN,ARZNEDKOD,SUM(SURE) " +
                       "FROM URTHRK.CH_DOKUMNO_DURUS_DATA " +
                       "WHERE ";
            if (tarih > 0 && tarih2 > 0)
            {
                this.sql += "BASTAR >= " + tarih +
                        " AND BASTAR <= " + tarih2 + "  AND DURUSNEDEN='" + durus_nedeni.Trim() + "' GROUP BY ARIZANEDEN,DURUSNEDEN,ARZNEDKOD";
            }
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                durus_bilgileri kayit = new durus_bilgileri();
                kayit.ARIZANEDEN = "Listelenecek Kayıt Bulunamadı !!";
                kayit.DURUS_ID = "0";
                kayitlar.Add(kayit);
            }
            else
            {

                while (this.dr.Read())
                {
                    durus_bilgileri kayit = new durus_bilgileri();
                    kayit.DURUS_ID = "1";
                    kayit.dokumno = this.dr[0].ToString();
                    kayit.DURUSNEDEN = this.dr[1].ToString();
                    kayit.ARIZANEDEN = this.dr[2].ToString();
                    kayit.ARIZAKOD = this.dr[3].ToString();
                    kayit.SURE = this.dr[4].ToString();
                    kayitlar.Add(kayit);

                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;
        }
     

        public List<durus_bilgileri> durus_ayrinti_data_read(int tarih = 0, int tarih2 = 0)
        {
            List<durus_bilgileri> kayitlar = new List<durus_bilgileri>();
            this.sql = "SELECT DISTINCT(DNO) " +
                       "FROM URTHRK.CH_DOKUMNO_DURUS_DATA " +
                       "WHERE ";
            if (tarih > 0 && tarih2 > 0)
            {
                this.sql += "BASTAR >= " + tarih +
                        " AND BASTAR <= " + tarih2 + " ORDER BY DNO";
            }
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                durus_bilgileri kayit = new durus_bilgileri();
                kayit.ARIZANEDEN = "Listelenecek Kayıt Bulunamadı !!";
                kayit.DURUS_ID = "0";
                kayitlar.Add(kayit);
            }
            else
            {

                while (this.dr.Read())
                {
                    durus_bilgileri kayit = new durus_bilgileri();
                    kayit.DURUS_ID = "1";
                    kayit.dokumno = this.dr[0].ToString();
                    this.sql = "  SELECT * " +
                    "FROM URTHRK.CH_DOKUMNO_DURUS_DATA " +
                    "WHERE ";
                    this.sql += "DNO=" + kayit.dokumno + "";
                    this.cmd.CommandText = this.sql;
                    this.dr2 = this.cmd.ExecuteReader();
                    kayitlar.Add(kayit);
                    while (dr2.Read())
                    {
                        durus_bilgileri kayitx = new durus_bilgileri();
                        kayitx.DURUS_ID = "2";
                        kayitx.vrd = this.dr2[2].ToString();
                        int dokum_tarihi = Convert.ToInt32(this.dr2[3].ToString());
                        tarih_parse = tarihFormat(dokum_tarihi);
                        kayitx.tarih = tarih_parse;
                        kayitx.BASSAATI = this.dr2[4].ToString();
                        kayitx.BITISSAATI = this.dr2[6].ToString();
                        kayitx.SURE = this.dr2[7].ToString();
                        kayitx.DURUSKOD = this.dr2[8].ToString();
                        kayitx.DURUSNEDEN = this.dr2[10].ToString();
                        kayitx.ARIZAKOD = this.dr2[9].ToString();
                        kayitx.ARIZANEDEN = this.dr2[11].ToString();
                        kayitx.SARJALMA = this.dr2[12].ToString();
                        kayitx.aciklama = this.dr2[13].ToString();
                        kayitlar.Add(kayitx);
                    }
                }

            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;
        }
     

        public string detay(string arizakodu, string tarihh, string tarihh2)
        {
            durus_bilgileri kayit = new durus_bilgileri();

            this.sql = "SELECT COUNT(DISTINCT(DNO)),SUM(SURE) " +
               "FROM URTHRK.CH_DOKUMNO_DURUS_DATA " +
               "WHERE ";
            if (Convert.ToInt32(tarihh) > 0 && Convert.ToInt32(tarihh2) > 0)
            {
                this.sql += "ARZNEDKOD='" + arizakodu + "' AND BASTAR >= " + tarihh +
                        " AND BASTAR <= " + tarihh2 + " ORDER BY DNO";
            }
            this.cmd.CommandText = this.sql;
            this.cmd.Parameters.Clear();
            this.dr = this.cmd.ExecuteReader();
            while (dr.Read())
            {
                kayit.dokumno = this.dr[0].ToString();
                kayit.SURE = this.dr[1].ToString();
            }

            return "TOPLAM:" + " " + kayit.dokumno + " " + "DÖKÜM" + " " + kayit.SURE + " " + "DAKİKA";
        }


    }
}
