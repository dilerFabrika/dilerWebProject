using diler.Entity;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace diler.Dal
{
    public class Istiften_soguksarj_db
    {
        OracleConnection conn, conn2;
        string connetionString, sql, gelentarih;
        OracleCommand cmd;
        OracleDataReader dr, dr2, dr3;
        public string tarih_parse, saat_parse;
        public string kutuk_sayisi_ds2, karisim_sayisi_ds2, kutuk_sayisi_ds1, karisim_sayisi_ds1, kutuk_sayisi_ds3, karisim_sayisi_ds3, aciklama;
        public string kalite_kod, ebat_kod, boy_kod, mesaj, mesaj2;
        public int kutuksayisi, ktkdus, fie_hurda, fde_hurda, kontrol, egri_kutuk_sayisi;


        public Istiften_soguksarj_db()
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
                    throw new System.InvalidOperationException("Veri Tabani baglantisi kurulamıyor!");
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

        //İstifler
        public List<string> Cmb_istif_yeri_doldur(string secilen_stok_yeri)
        {
            List<string> kayitlar = new List<string>();
            string sql = "SELECT DISTINCT(ISTIF_YERI),SAHA_TANIM FROM URTHRK.CH_DOKUMNO_ISTIF WHERE STOK_YERI='" + secilen_stok_yeri + "' ORDER BY ISTIF_YERI";
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
        public List<Istif_bilgileri> istif_takip_listele_data_read(string stok_yeri, string istif_yeri)
        {

            List<Istif_bilgileri> kayitlar = new List<Istif_bilgileri>();
            this.sql = "SELECT * FROM URTHRK.CH_DOKUMNO_ISTIF WHERE ";
            this.sql += "STOK_YERI ='" + stok_yeri + "' AND ISTIF_YERI =" + istif_yeri + " ORDER BY ISTIF_SIRANO DESC ";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Istif_bilgileri kayit = new Istif_bilgileri();
                kayit.Lot = "Listelenecek Kayıt Bulunamadı !";
                kayit.Id = 0;
                kayitlar.Add(kayit);
            }
            else
            {

                while (this.dr.Read())
                {
                    Istif_bilgileri kayit = new Istif_bilgileri();
                    kayit.Id = 1;
                    kayit.Istif_sirano = Convert.ToInt32(this.dr[0]).ToString();
                    //  kayit.Dokum_tarihi = Convert.ToInt32(this.dr[1]);
                    int dokumtarih = Convert.ToInt32(this.dr[1].ToString().Equals("") ? 0 : this.dr[1]);

                    tarih_parse = tarihFormat(dokumtarih);
                    kayit.Dokum_tarihi = tarih_parse;
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
                    kayitlar.Add(kayit);

                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;
        }
        public List<Istif_bilgileri> istif_takip_ozet_listele_data_read(string stok_yeri, string istif_yeri)
        {
            List<Istif_bilgileri> kayitlar_istif_Ozet = new List<Istif_bilgileri>();

            this.sql = " SELECT SUM(ISTIF_ADET), EBAT, CELIKCINSI, BOY, CELIKCINSI_ORJINAL " +
                         "FROM URTHRK.CH_DOKUMNO_ISTIF WHERE " +
                         "STOK_YERI ='" + stok_yeri + "' AND ISTIF_YERI =" + istif_yeri + " " +
                         "GROUP BY CELIKCINSI, BOY, EBAT, CELIKCINSI_ORJINAL ORDER BY CELIKCINSI,SUM(ISTIF_ADET)";

            this.cmd.Parameters.Clear();
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Istif_bilgileri kayit = new Istif_bilgileri();
                kayit.Lot = "Listelenecek Kayıt Bulunamadı !";
                kayit.Id = 0;
                kayitlar_istif_Ozet.Add(kayit);
            }
            else
            {

                while (this.dr.Read())
                {
                    Istif_bilgileri kayit = new Istif_bilgileri();
                    kayit.Id = 1;
                    kayit.Istif_yeri = istif_yeri;
                    kayit.Istif_adet = this.dr[0].ToString();
                    kayit.Ebat = this.dr[1].ToString();
                    kayit.Celik_cinsi = this.dr[2].ToString();
                    kayit.Boy = this.dr[3].ToString();
                    kayit.Celik_cinsi_orj = this.dr[4].ToString();
                    kayitlar_istif_Ozet.Add(kayit);

                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar_istif_Ozet;
        }


        public string aciklama1(string stok_yeri, string istif_yeri)
        {
            string istif_sirano = "";
            string dokum_no = "";
            string kalite = "";
            string boy = "";
            string ebat = "";
            string istif_adet = "";
            List<string> kayitlar = new List<string>();
            this.sql = "SELECT MAX(ISTIF_SIRANO) FROM URTHRK.CH_DOKUMNO_ISTIF WHERE ";
            this.sql += "  STOK_YERI ='" + stok_yeri + "' AND ISTIF_YERI =" + istif_yeri + " ORDER BY ISTIF_SIRANO DESC ";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            while (this.dr.Read())
            {
                istif_sirano = dr[0].ToString();

            }

            string sql_ = "SELECT DOKUMNO,CELIKCINSI,BOY,EBAT,ISTIF_ADET FROM URTHRK.CH_DOKUMNO_ISTIF WHERE ";
            sql_ += "  STOK_YERI ='" + stok_yeri + "' AND ISTIF_YERI =" + istif_yeri + " AND ISTIF_SIRANO=" + istif_sirano + " ORDER BY ISTIF_SIRANO DESC ";
            this.cmd.CommandText = sql_;
            this.dr = this.cmd.ExecuteReader();
            while (this.dr.Read())
            {

                dokum_no = dr[0].ToString();
                kalite = dr[1].ToString();
                boy = dr[2].ToString();
                ebat = dr[3].ToString();
                istif_adet = dr[4].ToString();

            }

            string sqlx = "SELECT " +
                "(SELECT KOD FROM URTTNM.TANIMLAR WHERE KOD_ACK = '" + kalite + "' AND TESIS = 'HH' AND TNMTIPI='KALITE')  AS kalitekodu," +
                "(SELECT KOD FROM URTTNM.TANIMLAR WHERE KOD_ACK = '" + boy.Trim() + "' AND TESIS = 'HH' AND TNMTIPI='BOY') AS boykodu, " +
                "(SELECT KOD FROM URTTNM.TANIMLAR WHERE KOD_ACK = '" + ebat.Trim() + "' AND TESIS = 'HH' AND TNMTIPI='EBAT') AS ebatkodu " +
                "FROM URTTNM.TANIMLAR WHERE ROWNUM=1";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = sqlx;
            this.dr = this.cmd.ExecuteReader();

            while (this.dr.Read())
            {
                kalite_kod = this.dr[0].ToString();
                boy_kod = this.dr[1].ToString();
                ebat_kod = this.dr[2].ToString();
            }
            if (dokum_no != "")
            {
                string sql = "SELECT " +
                  "(SELECT SUM(STDKTKSAY) FROM URTHRK.CH_DOKUMNO_URETIM WHERE DNO = " + dokum_no + ")  AS ktksayisi," +
                  "(SELECT SUM(STNKARSAY) FROM URTHRK.CH_DOKUMNO_URETIM WHERE DNO = " + dokum_no + ") AS karisimsayisi, " +
                  "(SELECT COUNT(KTKADET) FROM URTHRK.TAVFRNKTKDUS WHERE DNO = " + dokum_no + ") AS KTKDUS,  " +
                  "(SELECT SUM(KTKSAY) FROM URTHRK.TAVFRNOONU WHERE islisk ='Fırın Ici Eğrilen (Hurdaya Gidecek)' AND DNO=" + dokum_no + ") AS fiehurda," +
                  "(SELECT SUM(KTKSAY) FROM URTHRK.TAVFRNOONU WHERE islisk ='Fırın Dısı Eğrilen (Hurdaya Gidecek)' AND DNO=" + dokum_no + ") AS fdehurda,  " +
                  "(SELECT SUM(EGRI_KUTUK_SAYISI) FROM URTHRK.CH_DOKUMNO_URETIM WHERE DNO = " + dokum_no + ")  AS EGRI_KUTUK " +
                  "FROM URTHRK.CH_DOKUMNO_URETIM WHERE ROWNUM=1";
                this.cmd.Parameters.Clear();
                this.cmd.CommandText = sql;
                this.dr = this.cmd.ExecuteReader();
                while (this.dr.Read())
                {
                    kutuksayisi = Convert.ToInt32(this.dr[0].ToString().Equals("") ? "0" : this.dr[0].ToString()) +
                                  Convert.ToInt32(this.dr[1].ToString().Equals("") ? "0" : this.dr[1].ToString());
                    ktkdus = Convert.ToInt32(this.dr[2].ToString().Equals("") ? "0" : this.dr[2].ToString());
                    fie_hurda = Convert.ToInt32(this.dr[3].ToString().Equals("") ? "0" : this.dr[3].ToString());
                    fde_hurda = Convert.ToInt32(this.dr[4].ToString().Equals("") ? "0" : this.dr[4].ToString());
                    egri_kutuk_sayisi = Convert.ToInt32(this.dr[5].ToString().Equals("") ? "0" : this.dr[5].ToString());

                }


                kontrol = kutuksayisi - ktkdus - fie_hurda - fde_hurda - egri_kutuk_sayisi;


                mesaj = "Üretilen Kütük Sayısı=" + kutuksayisi + "\n" +
                         "Fırından Çıkan Kütük Sayısı=" + ktkdus + "\n" +
                         "Fırın İçi Eğrilen Hurda=" + fie_hurda + "\n" +
                         "Fırın Dışı Eğrilen Hurda=" + fde_hurda + "\n" +
                         "Eğri Kütük Sayısı=" + egri_kutuk_sayisi + "\n";

            }

            return mesaj;

        }
        public string aciklama2(string stok_yeri, string istif_yeri)
        {
            string istif_sirano = "";
            string dokum_no = "";
            string kalite = "";
            string boy = "";
            string ebat = "";
            string istif_adet = "";
            List<string> kayitlar = new List<string>();
            this.sql = "SELECT MAX(ISTIF_SIRANO) FROM URTHRK.CH_DOKUMNO_ISTIF WHERE ";
            this.sql += "  STOK_YERI ='" + stok_yeri + "' AND ISTIF_YERI =" + istif_yeri + " ORDER BY ISTIF_SIRANO DESC ";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            while (this.dr.Read())
            {
                istif_sirano = dr[0].ToString();

            }

            string sql_ = "SELECT DOKUMNO,CELIKCINSI,BOY,EBAT,ISTIF_ADET FROM URTHRK.CH_DOKUMNO_ISTIF WHERE ";
            sql_ += "  STOK_YERI ='" + stok_yeri + "' AND ISTIF_YERI =" + istif_yeri + " AND ISTIF_SIRANO=" + istif_sirano + " ORDER BY ISTIF_SIRANO DESC ";
            this.cmd.CommandText = sql_;
            this.dr = this.cmd.ExecuteReader();
            while (this.dr.Read())
            {

                dokum_no = dr[0].ToString();
                kalite = dr[1].ToString();
                boy = dr[2].ToString();
                ebat = dr[3].ToString();
                istif_adet = dr[4].ToString();

            }

            string sqlx = "SELECT " +
                "(SELECT KOD FROM URTTNM.TANIMLAR WHERE KOD_ACK = '" + kalite + "' AND TESIS = 'HH' AND TNMTIPI='KALITE')  AS kalitekodu," +
                "(SELECT KOD FROM URTTNM.TANIMLAR WHERE KOD_ACK = '" + boy.Trim() + "' AND TESIS = 'HH' AND TNMTIPI='BOY') AS boykodu, " +
                "(SELECT KOD FROM URTTNM.TANIMLAR WHERE KOD_ACK = '" + ebat.Trim() + "' AND TESIS = 'HH' AND TNMTIPI='EBAT') AS ebatkodu " +
                "FROM URTTNM.TANIMLAR WHERE ROWNUM=1";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = sqlx;
            this.dr = this.cmd.ExecuteReader();

            while (this.dr.Read())
            {
                kalite_kod = this.dr[0].ToString();
                boy_kod = this.dr[1].ToString();
                ebat_kod = this.dr[2].ToString();
            }

            if (dokum_no != "")
            {
                string sql = "SELECT " +
              "(SELECT SUM(STDKTKSAY) FROM URTHRK.CH_DOKUMNO_URETIM WHERE DNO = " + dokum_no + ")  AS ktksayisi," +
              "(SELECT SUM(STNKARSAY) FROM URTHRK.CH_DOKUMNO_URETIM WHERE DNO = " + dokum_no + ") AS karisimsayisi, " +
              "(SELECT COUNT(KTKADET) FROM URTHRK.TAVFRNKTKDUS WHERE DNO = " + dokum_no + ") AS KTKDUS,  " +
              "(SELECT SUM(KTKSAY) FROM URTHRK.TAVFRNOONU WHERE islisk ='Fırın Ici Eğrilen (Hurdaya Gidecek)' AND DNO=" + dokum_no + ") AS fiehurda," +
              "(SELECT SUM(KTKSAY) FROM URTHRK.TAVFRNOONU WHERE islisk ='Fırın Dısı Eğrilen (Hurdaya Gidecek)' AND DNO=" + dokum_no + ") AS fdehurda,  " +
              "(SELECT SUM(EGRI_KUTUK_SAYISI) FROM URTHRK.CH_DOKUMNO_URETIM WHERE DNO = " + dokum_no + ")  AS EGRI_KUTUK " +
              "FROM URTHRK.CH_DOKUMNO_URETIM WHERE ROWNUM=1";
                this.cmd.Parameters.Clear();
                this.cmd.CommandText = sql;
                this.dr = this.cmd.ExecuteReader();
                while (this.dr.Read())
                {
                    kutuksayisi = Convert.ToInt32(this.dr[0].ToString().Equals("") ? "0" : this.dr[0].ToString()) +
                                  Convert.ToInt32(this.dr[1].ToString().Equals("") ? "0" : this.dr[1].ToString());
                    ktkdus = Convert.ToInt32(this.dr[2].ToString().Equals("") ? "0" : this.dr[2].ToString());
                    fie_hurda = Convert.ToInt32(this.dr[3].ToString().Equals("") ? "0" : this.dr[3].ToString());
                    fde_hurda = Convert.ToInt32(this.dr[4].ToString().Equals("") ? "0" : this.dr[4].ToString());
                    egri_kutuk_sayisi = Convert.ToInt32(this.dr[5].ToString().Equals("") ? "0" : this.dr[5].ToString());

                }


                kontrol = kutuksayisi - ktkdus - fie_hurda - fde_hurda - egri_kutuk_sayisi;

                mesaj = "Formül=" + kutuksayisi + " - " + ktkdus + " - " + fie_hurda + " - " + fde_hurda + " - " + egri_kutuk_sayisi + "\n";
            }

            return mesaj;

        }
        public string aciklama3(string stok_yeri, string istif_yeri)
        {
            string istif_sirano = "";
            string dokum_no = "";
            string kalite = "";
            string boy = "";
            string ebat = "";
            string istif_adet = "";
            List<string> kayitlar = new List<string>();
            this.sql = "SELECT MAX(ISTIF_SIRANO) FROM URTHRK.CH_DOKUMNO_ISTIF WHERE ";
            this.sql += "  STOK_YERI ='" + stok_yeri + "' AND ISTIF_YERI =" + istif_yeri + " ORDER BY ISTIF_SIRANO DESC ";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            while (this.dr.Read())
            {
                istif_sirano = dr[0].ToString();

            }

            string sql_ = "SELECT DOKUMNO,CELIKCINSI,BOY,EBAT,ISTIF_ADET FROM URTHRK.CH_DOKUMNO_ISTIF WHERE ";
            sql_ += "  STOK_YERI ='" + stok_yeri + "' AND ISTIF_YERI =" + istif_yeri + " AND ISTIF_SIRANO=" + istif_sirano + " ORDER BY ISTIF_SIRANO DESC ";
            this.cmd.CommandText = sql_;
            this.dr = this.cmd.ExecuteReader();
            while (this.dr.Read())
            {

                dokum_no = dr[0].ToString();
                kalite = dr[1].ToString();
                boy = dr[2].ToString();
                ebat = dr[3].ToString();
                istif_adet = dr[4].ToString();

            }

            string sqlx = "SELECT " +
                "(SELECT KOD FROM URTTNM.TANIMLAR WHERE KOD_ACK = '" + kalite + "' AND TESIS = 'HH' AND TNMTIPI='KALITE')  AS kalitekodu," +
                "(SELECT KOD FROM URTTNM.TANIMLAR WHERE KOD_ACK = '" + boy.Trim() + "' AND TESIS = 'HH' AND TNMTIPI='BOY') AS boykodu, " +
                "(SELECT KOD FROM URTTNM.TANIMLAR WHERE KOD_ACK = '" + ebat.Trim() + "' AND TESIS = 'HH' AND TNMTIPI='EBAT') AS ebatkodu " +
                "FROM URTTNM.TANIMLAR WHERE ROWNUM=1";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = sqlx;
            this.dr = this.cmd.ExecuteReader();

            while (this.dr.Read())
            {
                kalite_kod = this.dr[0].ToString();
                boy_kod = this.dr[1].ToString();
                ebat_kod = this.dr[2].ToString();
            }

            if (dokum_no != "")
            {
                string sql = "SELECT " +
              "(SELECT SUM(STDKTKSAY) FROM URTHRK.CH_DOKUMNO_URETIM WHERE DNO = " + dokum_no + ")  AS ktksayisi," +
              "(SELECT SUM(STNKARSAY) FROM URTHRK.CH_DOKUMNO_URETIM WHERE DNO = " + dokum_no + ") AS karisimsayisi, " +
              "(SELECT COUNT(KTKADET) FROM URTHRK.TAVFRNKTKDUS WHERE DNO = " + dokum_no + ") AS KTKDUS,  " +
              "(SELECT SUM(KTKSAY) FROM URTHRK.TAVFRNOONU WHERE islisk ='Fırın Ici Eğrilen (Hurdaya Gidecek)' AND DNO=" + dokum_no + ") AS fiehurda," +
              "(SELECT SUM(KTKSAY) FROM URTHRK.TAVFRNOONU WHERE islisk ='Fırın Dısı Eğrilen (Hurdaya Gidecek)' AND DNO=" + dokum_no + ") AS fdehurda,  " +
              "(SELECT SUM(EGRI_KUTUK_SAYISI) FROM URTHRK.CH_DOKUMNO_URETIM WHERE DNO = " + dokum_no + ")  AS EGRI_KUTUK " +
              "FROM URTHRK.CH_DOKUMNO_URETIM WHERE ROWNUM=1";
                this.cmd.Parameters.Clear();
                this.cmd.CommandText = sql;
                this.dr = this.cmd.ExecuteReader();
                while (this.dr.Read())
                {
                    kutuksayisi = Convert.ToInt32(this.dr[0].ToString().Equals("") ? "0" : this.dr[0].ToString()) +
                                  Convert.ToInt32(this.dr[1].ToString().Equals("") ? "0" : this.dr[1].ToString());
                    ktkdus = Convert.ToInt32(this.dr[2].ToString().Equals("") ? "0" : this.dr[2].ToString());
                    fie_hurda = Convert.ToInt32(this.dr[3].ToString().Equals("") ? "0" : this.dr[3].ToString());
                    fde_hurda = Convert.ToInt32(this.dr[4].ToString().Equals("") ? "0" : this.dr[4].ToString());
                    egri_kutuk_sayisi = Convert.ToInt32(this.dr[5].ToString().Equals("") ? "0" : this.dr[5].ToString());

                }

                kontrol = kutuksayisi - ktkdus - fie_hurda - fde_hurda - egri_kutuk_sayisi;

                if (Convert.ToInt32(istif_adet) > kontrol)
                {
                    mesaj = ("İlk sıradaki döküm bilgisi için " + "formül sonucu=" + kontrol + " " + "istif adedi sayısı=" + istif_adet + " " + "\n" + "" +
                               "Formül sonucu istif adedi sayısından küçük olduğu için fırına gönderilemez.").ToString();
                }
                else
                {

                    mesaj = ("İlk sıradaki döküm bilgisi için " + "formül sonucu=" + kontrol + " " + "istif adedi sayısı=" + istif_adet + " " + "\n" + "" +
                             "Formül sonucu istif adedi sayısından büyük veya istif adedi sayısına eşit olduğu için fırına gönderilebilir.").ToString();
                }
            }

            return mesaj;

        }




        /**İstiften düşme Tav fırınına ekleme**/

        public string send_billet(string dokum_no, string istif_adet, string istif_sirano, string istif_yeri, string kalite, string boy, string ebat, string siparis_no)
        {
            string frm_num, tesis, yil, sarj_durum, mesaj, dokum_tarihi, dokum_durum;

            string sqlx = "SELECT " +
                "(SELECT KOD FROM URTTNM.TANIMLAR WHERE KOD_ACK = '" + kalite + "' AND TESIS = 'HH' AND TNMTIPI='KALITE')  AS kalitekodu," +
                "(SELECT KOD FROM URTTNM.TANIMLAR WHERE KOD_ACK = '" + boy.Trim() + "' AND TESIS = 'HH' AND TNMTIPI='BOY') AS boykodu, " +
                "(SELECT KOD FROM URTTNM.TANIMLAR WHERE KOD_ACK = '" + ebat.Trim() + "' AND TESIS = 'HH' AND TNMTIPI='EBAT') AS ebatkodu " +
                "FROM URTTNM.TANIMLAR WHERE ROWNUM=1";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = sqlx;
            this.dr = this.cmd.ExecuteReader();
            try
            {
                while (this.dr.Read())
                {
                    kalite_kod = this.dr[0].ToString();
                    boy_kod = this.dr[1].ToString();
                    ebat_kod = this.dr[2].ToString();
                }
            }
            catch
            {
                throw new System.InvalidOperationException("Kütüğün bilgileri eksik olduğu için fırına gönderilemiyor !");
            }
            string sql = "SELECT " +
              "(SELECT SUM(STDKTKSAY) FROM URTHRK.CH_DOKUMNO_URETIM WHERE DNO = " + dokum_no + ")  AS ktksayisi," +
              "(SELECT SUM(STNKARSAY) FROM URTHRK.CH_DOKUMNO_URETIM WHERE DNO = " + dokum_no + ") AS karisimsayisi, " +
              "(SELECT COUNT(KTKADET) FROM URTHRK.TAVFRNKTKDUS WHERE DNO = " + dokum_no + ") AS KTKDUS,  " +
              "(SELECT SUM(KTKSAY) FROM URTHRK.TAVFRNOONU WHERE islisk ='Fırın Ici Eğrilen (Hurdaya Gidecek)' AND DNO=" + dokum_no + ") AS fiehurda," +
              "(SELECT SUM(KTKSAY) FROM URTHRK.TAVFRNOONU WHERE islisk ='Fırın Dısı Eğrilen (Hurdaya Gidecek)' AND DNO=" + dokum_no + ") AS fdehurda,  " +
              "(SELECT DISTINCT(DOKUMTAR) FROM URTHRK.CH_DOKUMNO_URETIM WHERE DNO = " + dokum_no + ")  AS TARIH," +
              "(SELECT SUM(EGRI_KUTUK_SAYISI) FROM URTHRK.CH_DOKUMNO_URETIM WHERE DNO = " + dokum_no + ")  AS EGRI_KUTUK " +
              "FROM URTHRK.CH_DOKUMNO_URETIM WHERE ROWNUM=1";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = sql;
            this.dr = this.cmd.ExecuteReader();
            while (this.dr.Read())
            {
                kutuksayisi = Convert.ToInt32(this.dr[0].ToString().Equals("") ? "0" : this.dr[0].ToString()) +
                              Convert.ToInt32(this.dr[1].ToString().Equals("") ? "0" : this.dr[1].ToString());
                ktkdus = Convert.ToInt32(this.dr[2].ToString().Equals("") ? "0" : this.dr[2].ToString());
                fie_hurda = Convert.ToInt32(this.dr[3].ToString().Equals("") ? "0" : this.dr[3].ToString());
                fde_hurda = Convert.ToInt32(this.dr[4].ToString().Equals("") ? "0" : this.dr[4].ToString());

                dokum_tarihi = this.dr[5].ToString();
                egri_kutuk_sayisi = Convert.ToInt32(this.dr[6].ToString().Equals("") ? "0" : this.dr[6].ToString());

            }
            if (siparis_no.Trim() == "DİLER")
            {
                kontrol = kutuksayisi - ktkdus - fie_hurda - fde_hurda - egri_kutuk_sayisi;


                if (Convert.ToInt32(istif_adet) > kontrol)
                {
                    mesaj = "ATILAMAZ";

                }
                else
                {
                    string gelentarih = DateTime.Now.Date.ToString("yyyyMMdd");
                    frm_num = "D";
                    tesis = "DHH";
                    yil = gelentarih.Substring(0, gelentarih.Length - 4);
                    //istif_yeri = istif_yeri.Substring(0, 2).Trim();
                    sarj_durum = "SOG";
                    dokum_durum = "ACK";
                    string saniye = DateTime.Now.Second.ToString();
                    string dakika = DateTime.Now.Minute.ToString();
                    string saat = DateTime.Now.Hour.ToString();
                    if (saniye.Length == 1)
                    {
                        saniye = "0" + saniye;
                    }
                    if (dakika.Length == 1)
                    {
                        dakika = "0" + dakika;
                    }
                    if (saat.Length == 1)
                    {
                        saat = "0" + saat;
                    }
                    string giris_saati = saat + dakika + saniye;
                    string cikis_saati = "0";

                    try
                    {
                        string sqly = "INSERT INTO URTHRK.TAVFRN VALUES('" + frm_num + "','" + tesis + "','" + yil + "',NULL" + "," +
                      "'" + dokum_no + "','" + kalite_kod + "','" + ebat_kod + "','" + boy_kod + "','" + sarj_durum + "','" + giris_saati + "'," +
                      "'" + cikis_saati + "'," + istif_adet + ",NULL" + ",'" + dokum_durum + "'," + gelentarih + ",NULL" + ",NULL" + "," +
                      "NULL" + ",NULL" + ",NULL" + ",NULL" + ",NULL" + ",NULL" + ",NULL" + ")";
                        this.cmd.CommandText = sqly;
                        this.cmd.ExecuteNonQuery();

                        string sqlz = "DELETE FROM URTHRK.CH_DOKUMNO_ISTIF WHERE ISTIF_YERI=" + istif_yeri.Trim() + " AND ISTIF_SIRANO=" + istif_sirano + " ";
                        this.cmd.CommandText = sqlz;
                        this.cmd.ExecuteNonQuery();

                    }
                    catch
                    {
                        throw new System.InvalidOperationException("Bağlantı gerçekleştirilirken bir hata oluştu.Tekrar deneyiniz!");
                    }


                    mesaj = "FIRIN İÇİ TRANSFER İŞLEMİ BAŞARIYLA GERÇEKLEŞTİ";
                }
            }
            else
            {
                string gelentarih = DateTime.Now.Date.ToString("yyyyMMdd");
                frm_num = "D";
                tesis = "DHH";
                yil = gelentarih.Substring(0, gelentarih.Length - 4);
                //istif_yeri = istif_yeri.Substring(0, 2).Trim();
                sarj_durum = "SOG";
                dokum_durum = "ACK";
                string saniye = DateTime.Now.Second.ToString();
                string dakika = DateTime.Now.Minute.ToString();
                string saat = DateTime.Now.Hour.ToString();
                if (saniye.Length == 1)
                {
                    saniye = "0" + saniye;
                }
                if (dakika.Length == 1)
                {
                    dakika = "0" + dakika;
                }
                if (saat.Length == 1)
                {
                    saat = "0" + saat;
                }
                string giris_saati = saat + dakika + saniye;
                string cikis_saati = "0";

                try
                {
                    string sqly = "INSERT INTO URTHRK.TAVFRN VALUES('" + frm_num + "','" + tesis + "','" + yil + "',NULL" + "," +
                  "'" + dokum_no + "','" + kalite_kod + "','" + ebat_kod + "','" + boy_kod + "','" + sarj_durum + "','" + giris_saati + "'," +
                  "'" + cikis_saati + "'," + istif_adet + ",'" + siparis_no + "','" + dokum_durum + "'," + gelentarih + ",NULL" + ",NULL" + "," +
                  "NULL" + ",NULL" + ",NULL" + ",NULL" + ",NULL" + ",NULL" + ",NULL" + ")";
                    this.cmd.CommandText = sqly;
                    this.cmd.ExecuteNonQuery();

                    string sqlz = "DELETE FROM URTHRK.CH_DOKUMNO_ISTIF WHERE ISTIF_YERI=" + istif_yeri.Trim() + " AND ISTIF_SIRANO=" + istif_sirano + " ";
                    this.cmd.CommandText = sqlz;
                    this.cmd.ExecuteNonQuery();

                }
                catch
                {
                    throw new System.InvalidOperationException("Bağlantı gerçekleştirilirken bir hata oluştu.Tekrar deneyiniz!");
                }


                mesaj = "FIRIN İÇİ TRANSFER İŞLEMİ BAŞARIYLA GERÇEKLEŞTİ";
            }

            return mesaj;

        }


    }
}
