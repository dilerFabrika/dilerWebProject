using diler.Entity;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;


namespace diler.Dal
{
    public class Istife_kutuk_gonderimi_db
    {
        OracleConnection conn, conn2;
        string connetionString, sql;
        OracleCommand cmd;
        OracleDataReader dr;
        public string tarih_parse;

        public Istife_kutuk_gonderimi_db()
        {
            this.connetionString = @"Data Source=(DESCRIPTION=" +
                "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.198.191)(PORT=1521)))" +
                "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=DLRORA)));" +
                "User Id=URTHRK;Password=URTHRK;";
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

        public dynamic tarih_format(int gelen)
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

    
  
        public List<Istif_bilgileri> istifleri_listele(string stok_yeri, string istif_yeri)
        {

            List<Istif_bilgileri> kayitlar = new List<Istif_bilgileri>();
            this.sql = "SELECT * FROM URTHRK.CH_DOKUMNO_ISTIF WHERE ";
            this.sql += "  STOK_YERI ='" + stok_yeri + "' AND ISTIF_YERI =" + istif_yeri + " ORDER BY ISTIF_SIRANO DESC ";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Istif_bilgileri kayit = new Istif_bilgileri();
                // kayit.Lot = "Listelenecek Kayıt Bulunamadı !!";
                //kayit.Id = 0;
                //kayitlar.Add(kayit);
            }
            else
            {

                while (this.dr.Read())
                {
                    Istif_bilgileri kayit = new Istif_bilgileri();
                    kayit.Id = 1;

                    kayit.Istif_sirano = Convert.ToInt32(this.dr[0].ToString().Equals("") ? 0 : this.dr[0]).ToString();
                    int dokumtarih = Convert.ToInt32(this.dr[1].ToString().Equals("") ? 0 : this.dr[1]);
                    if (dokumtarih != 0)
                    {
                        tarih_parse = tarih_format(dokumtarih);
                        kayit.Dokum_tarihi = tarih_parse;
                    }


                    kayit.Dokum_no = this.dr[2].ToString();
                    kayit.Stok_yeri = this.dr[3].ToString();
                    kayit.Istif_yeri = this.dr[4].ToString();
                    kayit.Istif_adet = this.dr[5].ToString();
                    kayit.Celik_cinsi = this.dr[6].ToString();
                    kayit.Boy = this.dr[7].ToString();
                    kayit.Ebat = this.dr[8].ToString();
                    kayit.Sipno = this.dr[10].ToString();
                    kayit.Lot = this.dr[11].ToString();
                    kayit.Aciklama = this.dr[13].ToString();
                    kayit.Id = Convert.ToInt32(this.dr[14].ToString());
                    kayitlar.Add(kayit);

                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;
        }
        public string single_row_insert(int istif_yeri, string stok_yeri, string saha_tanim)
        {
            string deneme = "";
            int istif_sirano = 0;
            List<string> kayitlar = new List<string>();
            string sql_ = "SELECT MAX(ISTIF_SIRANO) FROM URTHRK.CH_DOKUMNO_ISTIF WHERE ISTIF_YERI=" + istif_yeri + " AND STOK_YERI='" + stok_yeri + "' ";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = sql_;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                istif_sirano = 1;
            }
            else
            {
                while (this.dr.Read())
                {

                    istif_sirano = Convert.ToInt32(this.dr[0].ToString().Equals("") ? 0 : this.dr[0]) + 1;
                }
            }

            string sql = "INSERT INTO URTHRK.CH_DOKUMNO_ISTIF VALUES(" + istif_sirano + ",NULL" + ",NULL" + ", " +
                 " '" + stok_yeri + "'," + istif_yeri + ",NULL" + ", NULL" + " , NULL" + ", NULL" + ",NULL" + ",NULL" + ",'-','" + saha_tanim + "',NULL" + ",NULL" + ",NULL" + ")";
            this.cmd.CommandText = sql;
            string insert = this.cmd.ExecuteNonQuery().ToString();

            return deneme;

        }
        public string row_delete(int istif_id)
        {

            string sql = "DELETE FROM CH_DOKUMNO_ISTIF WHERE ISTIF_ID=" + istif_id + "";
            this.cmd.CommandText = sql;
            string delete = this.cmd.ExecuteNonQuery().ToString();

            return delete;

        }
        public string all_row_insert(string sira_no, string istif_tarihi, string dokum_no,
            string stok_yeri, string istif_yeri, string istif_adet, string celik_cinsi, string boy, string ebat, string sip_no, string lot, string saha_tanim, string aciklama, string istif_id)
        {


            string update_sql = "UPDATE URTHRK.CH_DOKUMNO_ISTIF SET " +
                  " ISTIF_SIRANO = '" + sira_no + "',TARIH = '" + istif_tarihi + "', DOKUMNO = '" + dokum_no + "'," +
                  " STOK_YERI = '" + stok_yeri + "',ISTIF_YERI = '" + istif_yeri + "',ISTIF_ADET = '" + istif_adet + "'," +
                  " CELIKCINSI = '" + celik_cinsi + "',BOY = '" + boy + "',EBAT = '" + ebat + "'," +
                  " CELIKCINSI_ORJINAL = '" + celik_cinsi + "',SIPNO = '" + sip_no + "',LOT = '" + lot + "'," +
                  " SAHA_TANIM = '" + saha_tanim + "',ACIKLAMA = '" + aciklama + "'" +
                  " WHERE ISTIF_ID=" + istif_id + "";


            this.cmd.CommandText = update_sql;
            string update = this.cmd.ExecuteNonQuery().ToString();

            string MESAJ = "BAŞARIYLA KAYDEDİLDİ";


            return MESAJ;





        }

        public List<Istif_bilgileri> istif_ide_gore_copy_paste(int istif_id)
        {
            List<Istif_bilgileri> kayitlar = new List<Istif_bilgileri>();
            this.sql = "SELECT * FROM URTHRK.CH_DOKUMNO_ISTIF WHERE ";
            this.sql += "  ISTIF_ID =" + istif_id + "";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();

            while (this.dr.Read())
            {
                Istif_bilgileri kayit = new Istif_bilgileri();
                kayit.Id = 1;

                kayit.Istif_sirano = Convert.ToInt32(this.dr[0].ToString().Equals("") ? 0 : this.dr[0]).ToString();
                int dokumtarih = Convert.ToInt32(this.dr[1].ToString().Equals("") ? 0 : this.dr[1]);
                if (dokumtarih != 0)
                {
                    tarih_parse = tarih_format(dokumtarih);
                    kayit.Dokum_tarihi = tarih_parse;
                }


                kayit.Dokum_no = this.dr[2].ToString();
                kayit.Stok_yeri = this.dr[3].ToString();
                kayit.Istif_yeri = this.dr[4].ToString();
                kayit.Istif_adet = this.dr[5].ToString();
                kayit.Celik_cinsi = this.dr[6].ToString();
                kayit.Boy = this.dr[7].ToString();
                kayit.Ebat = this.dr[8].ToString();
                kayit.Sipno = this.dr[10].ToString();
                kayit.Lot = this.dr[11].ToString();
                kayit.Aciklama = this.dr[13].ToString();
                kayit.Id = Convert.ToInt32(this.dr[14].ToString());
                kayitlar.Add(kayit);

            }

            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;
        }
        public List<Istif_bilgileri> stokYeri_v_sahaTanim_bul(string istif_yeri)
        {
            List<Istif_bilgileri> kayitlar = new List<Istif_bilgileri>();
            string sql = "SELECT STOK_YERI,SAHA_TANIM FROM URTTNM.CH_ISTIF_TNM " +
                         "WHERE ISTIF_YERI=" + istif_yeri + "";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = sql;
            this.dr = this.cmd.ExecuteReader();
            while (this.dr.Read())
            {
                Istif_bilgileri kayit = new Istif_bilgileri();

                kayit.Stok_yeri = this.dr[0].ToString();
                kayit.Saha_tanim = this.dr[1].ToString();
                kayitlar.Add(kayit);
            }
            this.dr.Close();
            this.dr.Dispose();
            return kayitlar;
        }



        //****İstif yedek sayfası
        public string istif_kayitlari_yedekleme(string tarih)
        {
         

            string sql = " INSERT INTO CH_DOKUMNO_ISTIF_Y " +
                "(ISTIF_SIRANO, TARIH, DOKUMNO,STOK_YERI,ISTIF_YERI, ISTIF_ADET, CELIKCINSI, BOY, EBAT, CELIKCINSI_ORJINAL, SIPNO, LOT, SAHA_TANIM, ACIKLAMA, ISTIF_ID, YEDEKLEME_TARIHSAAT) " +
                 "SELECT ISTIF_SIRANO, TARIH, DOKUMNO,STOK_YERI, ISTIF_YERI, ISTIF_ADET, CELIKCINSI, BOY, EBAT, CELIKCINSI_ORJINAL, SIPNO, LOT, SAHA_TANIM, ACIKLAMA, ISTIF_ID,'" + tarih + "' " +
                 "FROM CH_DOKUMNO_ISTIF";


            cmd.CommandText = sql;
            string yedekleme = cmd.ExecuteNonQuery().ToString();


          
            return yedekleme;

        }
        public List<string> cmb_yedek_tarihi_doldur()
        {
            List<string> kayitlar = new List<string>();
            string sql = "SELECT DISTINCT(YEDEKLEME_TARIHSAAT) FROM URTHRK.CH_DOKUMNO_ISTIF_Y ORDER BY YEDEKLEME_TARIHSAAT ";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = sql;
            this.dr = this.cmd.ExecuteReader();
            while (this.dr.Read())
            {
                string yedek_tarihi = dr[0].ToString();

                kayitlar.Add(yedek_tarihi);
            }
            return kayitlar;
        }
        public List<string> Cmb_istif_yeri_yedek_doldur(string secilen_stok_yeri, string secilen_yedek_tarihi)
        {
            List<string> kayitlar = new List<string>();
            string sql = "SELECT DISTINCT(ISTIF_YERI),SAHA_TANIM FROM URTHRK.CH_DOKUMNO_ISTIF_Y " +
                "WHERE STOK_YERI='" + secilen_stok_yeri + "' AND YEDEKLEME_TARIHSAAT='" + secilen_yedek_tarihi + "' ORDER BY ISTIF_YERI";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = sql;
            this.dr = this.cmd.ExecuteReader();
            while (this.dr.Read())
            {
                string istif_yeri = dr[0].ToString();
                string saha_tanim = dr[1].ToString();
                string istif_saha = istif_yeri + " " + saha_tanim;
                kayitlar.Add(istif_saha);
            }
            return kayitlar;
        }
        public List<Istif_bilgileri> yedek_istifleri_listele(string stok_yeri, string istif_yeri, string yedek_tarihi)
        {

            List<Istif_bilgileri> kayitlar = new List<Istif_bilgileri>();
            this.sql = "SELECT * FROM URTHRK.CH_DOKUMNO_ISTIF_Y  WHERE ";
            this.sql += "  STOK_YERI ='" + stok_yeri + "' AND ISTIF_YERI =" + istif_yeri + " AND YEDEKLEME_TARIHSAAT='" + yedek_tarihi + "' ORDER BY ISTIF_SIRANO DESC ";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Istif_bilgileri kayit = new Istif_bilgileri();
                // kayit.Lot = "Listelenecek Kayıt Bulunamadı !!";
                //kayit.Id = 0;
                //kayitlar.Add(kayit);
            }
            else
            {

                while (this.dr.Read())
                {
                    Istif_bilgileri kayit = new Istif_bilgileri();
                    kayit.Id = 1;

                    kayit.Istif_sirano = Convert.ToInt32(this.dr[0].ToString().Equals("") ? 0 : this.dr[0]).ToString();
                    int dokumtarih = Convert.ToInt32(this.dr[1].ToString().Equals("") ? 0 : this.dr[1]);
                    if (dokumtarih != 0)
                    {
                        tarih_parse = tarih_format(dokumtarih);
                        kayit.Dokum_tarihi = tarih_parse;
                    }


                    kayit.Dokum_no = this.dr[2].ToString();
                    kayit.Stok_yeri = this.dr[3].ToString();
                    kayit.Istif_yeri = this.dr[4].ToString();
                    kayit.Istif_adet = this.dr[5].ToString();
                    kayit.Celik_cinsi = this.dr[6].ToString();
                    kayit.Boy = this.dr[7].ToString();
                    kayit.Ebat = this.dr[8].ToString();
                    kayit.Sipno = this.dr[10].ToString();
                    kayit.Lot = this.dr[11].ToString();
                    kayit.Aciklama = this.dr[13].ToString();
                    kayit.Id = Convert.ToInt32(this.dr[14].ToString());
                    kayitlar.Add(kayit);

                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;
        }

    }
}