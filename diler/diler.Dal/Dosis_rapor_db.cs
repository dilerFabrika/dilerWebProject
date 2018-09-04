using diler.Entity;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace diler.Dal
{
    public class Dosis_rapor_db
    {
        OracleConnection conn, conn2;
        string connetionString, sql;
        OracleCommand cmd;
        OracleDataReader dr, dr2;
        public string ad_soyad, unite, mudur_onayi, odul_verilis_tarihi, uygulama_gorevlisi, getiri_miktari , tarih_parse;
        public Dosis_rapor_db()
        {
            try
            {
                this.connetionString = @"Data Source=(DESCRIPTION=" +
                    "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.198.191)(PORT=1521)))" +
                    "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=DLRORA)));" +
                    "User Id=DOSIS;Password=DOSIS;";
                this.cmd = new OracleCommand();
                this.conn = new OracleConnection(this.connetionString);
                this.conn2 = new OracleConnection(this.connetionString);
            }
            catch
            {
                throw new System.InvalidOperationException("Veri tabanı bağlantısı gerçekleştirilemiyor.Tekrar deneyiniz");
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
        public List<Dosis_rapor_bilgileri> oneri_formlari(int tarih, int tarih2)
        {
            List<Dosis_rapor_bilgileri> kayitlar = new List<Dosis_rapor_bilgileri>();
            //Klasik Form
            this.sql = "SELECT COUNT(ONR_NO) FROM ONRFRM " +
                       "WHERE ONRGIRTAR BETWEEN " + tarih + " AND " + tarih2 + " " +
                       "AND  (FRM_NO!='-' OR FRM_NO!='')";
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Dosis_rapor_bilgileri kayit = new Dosis_rapor_bilgileri();
                kayit.Rapor_id = 0;
                kayitlar.Add(kayit);
            }
            else
            {
                while (this.dr.Read())
                {
                    Dosis_rapor_bilgileri d = new Dosis_rapor_bilgileri();
                    d.Rapor_id = 1;
                    d.Oneri_form_durumu = "Klasik form";
                    d.Oneri_sayisi = this.dr[0].ToString();
                    kayitlar.Add(d);
                }
            }
            //Bilgisayar
            this.sql = "SELECT COUNT(ONR_NO) FROM ONRFRM " +
                       "WHERE ONRGIRTAR BETWEEN " + tarih + " AND " + tarih2 + " " +
                       " AND (FRM_NO='-' OR FRM_NO='')";
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Dosis_rapor_bilgileri kayit = new Dosis_rapor_bilgileri();
                kayit.Rapor_id = 0;
                kayitlar.Add(kayit);
            }
            else
            {
                while (this.dr.Read())
                {
                    Dosis_rapor_bilgileri d = new Dosis_rapor_bilgileri();
                    d.Rapor_id = 1;
                    d.Oneri_form_durumu = "Bilgisayardan";
                    d.Oneri_sayisi = this.dr[0].ToString();
                    kayitlar.Add(d);
                }
            }
            //Toplam
            this.sql = "SELECT COUNT(ONR_NO) FROM ONRFRM " +
                       "WHERE ONRGIRTAR BETWEEN " + tarih + " AND " + tarih2 + " ";
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Dosis_rapor_bilgileri kayit = new Dosis_rapor_bilgileri();
                kayit.Rapor_id = 0;
                kayitlar.Add(kayit);
            }
            else
            {
                while (this.dr.Read())
                {
                    Dosis_rapor_bilgileri d = new Dosis_rapor_bilgileri();
                    d.Rapor_id = 1;
                    d.Oneri_form_durumu = "Toplam";
                    d.Oneri_sayisi = this.dr[0].ToString();
                    kayitlar.Add(d);
                }
            }

            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;

        }
        public List<Dosis_rapor_bilgileri> oneri_durum_listesi(int tarih, int tarih2)
        {
            List<Dosis_rapor_bilgileri> kayitlar = new List<Dosis_rapor_bilgileri>();

            this.sql = "SELECT COUNT(ONR_NO) FROM ONRFRM " +
                       "WHERE (((KAP_TARIHI) Between " + tarih + " AND " + tarih2 + ") " +
                       "AND (ONRFRM.Uygulayıcı_Red<>0 or ONRFRM.Mdr_Red<>0))";
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //Kayıt bulunamadı
                Dosis_rapor_bilgileri kayit = new Dosis_rapor_bilgileri();
                kayit.Rapor_id = 0;
                kayitlar.Add(kayit);
            }
            else
            {
                while (this.dr.Read())
                {
                    Dosis_rapor_bilgileri d = new Dosis_rapor_bilgileri();
                    d.Rapor_id = 1;
                    d.Oneri_durumu = "Red edilen öneriler";
                    d.Oneri_sayisi = this.dr[0].ToString();
                    kayitlar.Add(d);
                }
            }
            this.sql = "SELECT COUNT(ONR_NO) FROM ONRFRM " +
                       "WHERE (((KAP_TARIHI) Between " + tarih + " AND " + tarih2 + ") " +
                       "AND (ONRFRM.Iptal=1 ))";
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Dosis_rapor_bilgileri kayit = new Dosis_rapor_bilgileri();
                kayit.Rapor_id = 0;
                kayitlar.Add(kayit);
            }
            else
            {
                while (this.dr.Read())
                {
                    Dosis_rapor_bilgileri d = new Dosis_rapor_bilgileri();
                    d.Rapor_id = 1;
                    d.Oneri_durumu = "İptal edilen öneriler";
                    d.Oneri_sayisi = this.dr[0].ToString();
                    kayitlar.Add(d);
                }
            }

            this.sql = "SELECT COUNT(ONR_NO) FROM ONRFRM WHERE (ONRFRM.YER=4)";
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Dosis_rapor_bilgileri kayit = new Dosis_rapor_bilgileri();
                kayit.Rapor_id = 0;
                kayitlar.Add(kayit);
            }
            else
            {
                while (this.dr.Read())
                {
                    Dosis_rapor_bilgileri d = new Dosis_rapor_bilgileri();
                    d.Rapor_id = 1;
                    d.Oneri_durumu = "Uygulamadaki öneriler";
                    d.Oneri_sayisi = this.dr[0].ToString();
                    kayitlar.Add(d);
                }
            }
            this.sql = "SELECT COUNT(ONR_NO) FROM ONRFRM WHERE (ONRFRM.YER=3)";
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Dosis_rapor_bilgileri kayit = new Dosis_rapor_bilgileri();
                kayit.Rapor_id = 0;
                kayitlar.Add(kayit);
            }
            else
            {
                while (this.dr.Read())
                {
                    Dosis_rapor_bilgileri d = new Dosis_rapor_bilgileri();
                    d.Rapor_id = 1;
                    d.Oneri_durumu = "Müdürden atanmayı bekleyen öneriler";
                    d.Oneri_sayisi = this.dr[0].ToString();
                    kayitlar.Add(d);
                }
            }

            this.sql = "SELECT COUNT(ONR_NO) FROM ONRFRM " +
                       "WHERE (((KAP_TARIHI) Between " + tarih + " AND " + tarih2 + ") " +
                       "AND (ONRFRM.ODUL<>'0'))";
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Dosis_rapor_bilgileri kayit = new Dosis_rapor_bilgileri();
                kayit.Rapor_id = 0;
                kayitlar.Add(kayit);
            }
            else
            {
                while (this.dr.Read())
                {
                    Dosis_rapor_bilgileri d = new Dosis_rapor_bilgileri();
                    d.Rapor_id = 1;
                    d.Oneri_durumu = "Ödül alan öneriler";
                    d.Oneri_sayisi = this.dr[0].ToString();
                    kayitlar.Add(d);
                }
            }

            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;

        }
        public List<Dosis_rapor_bilgileri> lokasyona_gore_oneriler_listesi(int tarih, int tarih2)
        {
            List<Dosis_rapor_bilgileri> kayitlar = new List<Dosis_rapor_bilgileri>();

            this.sql = "SELECT COUNT(ONR_NO) FROM ONRFRM WHERE ONRGIRTAR BETWEEN " + tarih + " AND " + tarih2 + " AND LOKASYON='Diler'";
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //Kayıt bulunamadı
                Dosis_rapor_bilgileri kayit = new Dosis_rapor_bilgileri();
                kayit.Rapor_id = 0;
                kayitlar.Add(kayit);
            }
            else
            {
                while (this.dr.Read())
                {
                    Dosis_rapor_bilgileri d = new Dosis_rapor_bilgileri();
                    d.Rapor_id = 1;
                    d.Lokasyon = "Diler";
                    d.Oneri_sayisi = this.dr[0].ToString();
                    kayitlar.Add(d);
                }
            }
            this.sql = "SELECT COUNT(ONR_NO) FROM ONRFRM WHERE ONRGIRTAR BETWEEN " + tarih + " AND " + tarih2 + " AND LOKASYON='Filmasin'";
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Dosis_rapor_bilgileri kayit = new Dosis_rapor_bilgileri();
                kayit.Rapor_id = 0;
                kayitlar.Add(kayit);
            }
            else
            {
                while (this.dr.Read())
                {
                    Dosis_rapor_bilgileri d = new Dosis_rapor_bilgileri();
                    d.Rapor_id = 1;
                    d.Lokasyon = "Filmasin";
                    d.Oneri_sayisi = this.dr[0].ToString();
                    kayitlar.Add(d);
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;
        }
        public List<Dosis_rapor_bilgileri> kategoriye_gore_oneriler_listesi(int tarih, int tarih2)
        {
            List<Dosis_rapor_bilgileri> kayitlar = new List<Dosis_rapor_bilgileri>();
            this.sql = "SELECT ONERI_KATEGORI,COUNT(ONR_NO) FROM ONRFRM WHERE ONRGIRTAR BETWEEN " + tarih + " AND " + tarih2 + " GROUP BY ONERI_KATEGORI";
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Dosis_rapor_bilgileri kayit = new Dosis_rapor_bilgileri();
                kayit.Rapor_id = 0;
                kayitlar.Add(kayit);
            }
            else
            {
                while (this.dr.Read())
                {
                    Dosis_rapor_bilgileri d = new Dosis_rapor_bilgileri();
                    d.Rapor_id = 1;
                    d.Kategori = this.dr[0].ToString();
                    d.Oneri_sayisi = this.dr[1].ToString();
                    kayitlar.Add(d);
                }
            }

            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;
        }
        public List<Dosis_rapor_bilgileri> oneri_veren_bolum_listesi(int tarih, int tarih2)
        {
            List<Dosis_rapor_bilgileri> kayitlar = new List<Dosis_rapor_bilgileri>();

            this.sql = "SELECT DISTINCT(UNITESI),COUNT(UNITESI) FROM DOSIS.ONERINOYAGORE_UNITE " +
                        "WHERE ONRGIRTAR BETWEEN " + tarih + " AND " + tarih2 + " GROUP BY UNITESI";
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //Kayıt bulunamadı
                Dosis_rapor_bilgileri kayit = new Dosis_rapor_bilgileri();
                kayit.Rapor_id = 0;
                kayitlar.Add(kayit);
            }
            else
            {
                while (this.dr.Read())
                {
                    Dosis_rapor_bilgileri d = new Dosis_rapor_bilgileri();
                    d.Rapor_id = 1;
                    d.Oneri_veren_bolum = this.dr[0].ToString();
                    d.Oneri_sayisi = this.dr[1].ToString();
                    kayitlar.Add(d);
                }
            }

            this.sql = "SELECT COUNT(UNITESI) FROM DOSIS.ONERINOYAGORE_UNITE " +
                        "WHERE ONRGIRTAR BETWEEN " + tarih + " AND " + tarih2 + "";
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            while (this.dr.Read())
            {
                Dosis_rapor_bilgileri d = new Dosis_rapor_bilgileri();
                d.Rapor_id = 1;
                d.Oneri_veren_bolum = "TOPLAM";
                d.Oneri_sayisi = this.dr[0].ToString();
                kayitlar.Add(d);
            }




            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;
        }
        public List<Dosis_rapor_bilgileri> oneri_uygulayan_bolum_listesi(int tarih, int tarih2)
        {
            List<Dosis_rapor_bilgileri> kayitlar = new List<Dosis_rapor_bilgileri>();

            //this.sql = "SELECT ONRFRM.Uyg_Blm, COUNT(ONRFRM.Uyg_Blm) FROM ONRFRM " +
            //           "WHERE (ONRFRM.YER=4) AND ONRGIRTAR BETWEEN " + tarih + " AND " + tarih2 + " " +
            //           "GROUP BY ONRFRM.Uyg_Blm ORDER BY COUNT(ONRFRM.Uyg_Blm) DESC";


            this.sql = "SELECT  ONRFRM.Uyg_Blm, COUNT(ONRFRM.Uyg_Blm) FROM ONRFRM " +
                   "WHERE (((KAP_TARIHI) Between " + tarih + " AND " + tarih2 + ") " +
                   "AND (ONRFRM.ODUL<>'0')) GROUP BY ONRFRM.Uyg_Blm ORDER BY COUNT(ONRFRM.Uyg_Blm) DESC";

            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Dosis_rapor_bilgileri kayit = new Dosis_rapor_bilgileri();
                kayit.Rapor_id = 0;
                kayitlar.Add(kayit);
            }
            else
            {
                while (this.dr.Read())
                {
                    Dosis_rapor_bilgileri d = new Dosis_rapor_bilgileri();
                    d.Rapor_id = 1;
                    d.Oneri_uygulayan_bolum = this.dr[0].ToString();
                    d.Oneri_sayisi = this.dr[1].ToString();
                    kayitlar.Add(d);
                }
            }
            this.sql = "SELECT COUNT(ONRFRM.Uyg_Blm) FROM ONRFRM " +
                        "WHERE (ONRFRM.ODUL<>'0') AND KAP_TARIHI BETWEEN " + tarih + " AND " + tarih2 + "";
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            while (this.dr.Read())
            {
                Dosis_rapor_bilgileri d = new Dosis_rapor_bilgileri();
                d.Rapor_id = 1;
                d.Oneri_uygulayan_bolum = "TOPLAM";
                d.Oneri_sayisi = this.dr[0].ToString();
                kayitlar.Add(d);
            }



            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;
        }

        public List<Dosis_rapor_bilgileri> kategoriye_gore_oneriler_listesi_lokasyon_trigger(string gelen_veri_oneri_durumu, string gelen_veri_lokasyon, int tarih, int tarih2)
        {
            List<Dosis_rapor_bilgileri> kayitlar = new List<Dosis_rapor_bilgileri>();

            if (gelen_veri_oneri_durumu == "Uygulamadaki öneriler")
            {
                this.sql = "SELECT ONERI_KATEGORI, COUNT(ONR_NO) FROM ONRFRM WHERE ONRFRM.YER=4 ";
                if (gelen_veri_lokasyon == "Diler")
                {
                    this.sql += "AND LOKASYON='Diler' GROUP BY ONERI_KATEGORI";
                }
                else
                {
                    this.sql += "AND LOKASYON='Filmasin' GROUP BY ONERI_KATEGORI";
                }

            }
            if (gelen_veri_oneri_durumu == "Red edilen öneriler")
            {
                this.sql = "SELECT ONERI_KATEGORI,COUNT(ONR_NO) FROM ONRFRM WHERE KAP_TARIHI BETWEEN " + tarih + " AND " + tarih2 + " ";
                this.sql += "AND (Uygulayıcı_Red<>0 or Mdr_Red<>0) ";
                if (gelen_veri_lokasyon == "Diler")
                {
                    this.sql += "AND LOKASYON='Diler' GROUP BY ONERI_KATEGORI";
                }
                else
                {
                    this.sql += "AND LOKASYON='Filmasin' GROUP BY ONERI_KATEGORI";
                }

            }
            if (gelen_veri_oneri_durumu == "İptal edilen öneriler")
            {
                this.sql = "SELECT ONERI_KATEGORI,COUNT(ONR_NO) FROM ONRFRM WHERE KAP_TARIHI BETWEEN " + tarih + " AND " + tarih2 + " ";
                this.sql += " AND Iptal=1 ";
                if (gelen_veri_lokasyon == "Diler")
                {
                    this.sql += "AND LOKASYON='Diler' GROUP BY ONERI_KATEGORI";
                }
                else
                {
                    this.sql += "AND LOKASYON='Filmasin' GROUP BY ONERI_KATEGORI";
                }
            }
            if (gelen_veri_oneri_durumu == "Müdürden atanmayı bekleyen öneriler")
            {
                this.sql = "SELECT  ONERI_KATEGORI,COUNT(ONR_NO) FROM ONRFRM WHERE YER=3 ";
                if (gelen_veri_lokasyon == "Diler")
                {
                    this.sql += "AND LOKASYON='Diler' GROUP BY ONERI_KATEGORI";
                }
                else
                {
                    this.sql += "AND LOKASYON='Filmasin' GROUP BY ONERI_KATEGORI";
                }
            }
            if (gelen_veri_oneri_durumu == "Ödül alan öneriler")
            {
                this.sql = "SELECT ONERI_KATEGORI,COUNT(ONR_NO) FROM ONRFRM WHERE KAP_TARIHI BETWEEN " + tarih + " AND " + tarih2 + " ";
                this.sql += "AND ODUL<>'0' ";
                if (gelen_veri_lokasyon == "Diler")
                {
                    this.sql += "AND LOKASYON='Diler' GROUP BY ONERI_KATEGORI";
                }
                else
                {
                    this.sql += "AND LOKASYON='Filmasin' GROUP BY ONERI_KATEGORI";
                }

            }
            if (gelen_veri_oneri_durumu == "Diler")
            {
                this.sql = "SELECT ONERI_KATEGORI,COUNT(ONR_NO) FROM ONRFRM WHERE KAP_TARIHI BETWEEN " + tarih + " AND " + tarih2 + " ";
                this.sql += "AND ODUL<>'0' AND LOKASYON='Diler' ";
                if (gelen_veri_lokasyon == "Diler")
                {
                    this.sql += "AND LOKASYON='Diler' GROUP BY ONERI_KATEGORI";
                }
                else
                {
                    this.sql += "AND LOKASYON='Filmasin' GROUP BY ONERI_KATEGORI";
                }
            }
            if (gelen_veri_oneri_durumu == "Filmasin")
            {
                this.sql = "SELECT ONERI_KATEGORI,COUNT(ONR_NO) FROM ONRFRM WHERE KAP_TARIHI BETWEEN " + tarih + " AND " + tarih2 + " ";
                this.sql += "AND ODUL<>'0' AND LOKASYON='Filmasin' ";
                if (gelen_veri_lokasyon == "Diler")
                {
                    this.sql += "AND LOKASYON='Diler' GROUP BY ONERI_KATEGORI";
                }
                else
                {
                    this.sql += "AND LOKASYON='Filmasin' GROUP BY ONERI_KATEGORI";
                }
            }
            if (gelen_veri_oneri_durumu == "")
            {
                this.sql = "SELECT ONERI_KATEGORI, COUNT(ONR_NO)FROM ONRFRM WHERE ONRGIRTAR BETWEEN " + tarih + " AND " + tarih2 + " GROUP BY ONERI_KATEGORI";
            }
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //Kayıt bulunamadı
                Dosis_rapor_bilgileri kayit = new Dosis_rapor_bilgileri();
                kayit.Rapor_id = 0;
                kayitlar.Add(kayit);
            }
            else
            {
                while (this.dr.Read())
                {
                    Dosis_rapor_bilgileri d = new Dosis_rapor_bilgileri();
                    d.Rapor_id = 1;
                    d.Kategori = this.dr[0].ToString();
                    d.Oneri_sayisi = this.dr[1].ToString();
                    kayitlar.Add(d);
                }
            }

            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;
        }



        public List<Dosis_rapor_bilgileri> kategoriye_gore_oneriler_listesi_(string gelen_veri, int tarih, int tarih2)
        {
            List<Dosis_rapor_bilgileri> kayitlar = new List<Dosis_rapor_bilgileri>();

            if (gelen_veri == "Uygulamadaki öneriler")
            {
                this.sql = "SELECT ONERI_KATEGORI, COUNT(ONR_NO) FROM ONRFRM WHERE ONRFRM.YER=4 GROUP BY ONERI_KATEGORI ";

            }
            if (gelen_veri == "Red edilen öneriler")
            {
                this.sql = "SELECT ONERI_KATEGORI,COUNT(ONR_NO) FROM ONRFRM WHERE KAP_TARIHI BETWEEN " + tarih + " AND " + tarih2 + "";
                this.sql += "AND (Uygulayıcı_Red<>0 or Mdr_Red<>0) GROUP BY ONERI_KATEGORI ";


            }
            if (gelen_veri == "İptal edilen öneriler")
            {
                this.sql = "SELECT ONERI_KATEGORI,COUNT(ONR_NO) FROM ONRFRM WHERE KAP_TARIHI BETWEEN " + tarih + " AND " + tarih2 + "";
                this.sql += " AND Iptal=1  GROUP BY ONERI_KATEGORI ";

            }
            if (gelen_veri == "Müdürden atanmayı bekleyen öneriler")
            {
                this.sql = "SELECT ONERI_KATEGORI,COUNT(ONR_NO) FROM ONRFRM WHERE YER=3 GROUP BY ONERI_KATEGORI";

            }
            if (gelen_veri == "Ödül alan öneriler")
            {
                this.sql = "SELECT ONERI_KATEGORI,COUNT(ONR_NO) FROM ONRFRM WHERE KAP_TARIHI BETWEEN " + tarih + " AND " + tarih2 + "";
                this.sql += "AND ODUL<>'0' GROUP BY ONERI_KATEGORI ";

            }
            if (gelen_veri == "")
            {
                this.sql = "SELECT ONERI_KATEGORI, COUNT(ONR_NO)FROM ONRFRM WHERE ONRGIRTAR BETWEEN " + tarih + " AND " + tarih2 + " GROUP BY ONERI_KATEGORI";
            }

            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //Kayıt bulunamadı
                Dosis_rapor_bilgileri kayit = new Dosis_rapor_bilgileri();
                kayit.Rapor_id = 0;
                kayitlar.Add(kayit);
            }
            else
            {
                while (this.dr.Read())
                {
                    Dosis_rapor_bilgileri d = new Dosis_rapor_bilgileri();
                    d.Rapor_id = 1;
                    d.Kategori = this.dr[0].ToString();
                    d.Oneri_sayisi = this.dr[1].ToString();
                    kayitlar.Add(d);
                }
            }

            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;
        }

        public List<Dosis_rapor_bilgileri> lokasyona_gore_oneriler_listesi_(string gelen_veri, int tarih, int tarih2)
        {
            List<Dosis_rapor_bilgileri> kayitlar = new List<Dosis_rapor_bilgileri>();

            if (gelen_veri == "Uygulamadaki öneriler")
            {
                this.sql = "SELECT LOKASYON,COUNT(ONR_NO) FROM ONRFRM WHERE YER=4 GROUP BY LOKASYON";

            }
            if (gelen_veri == "Red edilen öneriler")
            {
                this.sql = "SELECT LOKASYON,COUNT(ONR_NO) FROM ONRFRM WHERE KAP_TARIHI BETWEEN " + tarih + " AND " + tarih2 + "";
                this.sql += "AND (Uygulayıcı_Red<>0 or Mdr_Red<>0) GROUP BY LOKASYON";


            }
            if (gelen_veri == "İptal edilen öneriler")
            {
                this.sql = "SELECT LOKASYON,COUNT(ONR_NO) FROM ONRFRM WHERE KAP_TARIHI BETWEEN " + tarih + " AND " + tarih2 + "";
                this.sql += " AND Iptal=1  GROUP BY LOKASYON";

            }
            if (gelen_veri == "Müdürden atanmayı bekleyen öneriler")
            {
                this.sql = "SELECT LOKASYON,COUNT(ONR_NO) FROM ONRFRM WHERE YER=3 GROUP BY LOKASYON";

            }
            if (gelen_veri == "Ödül alan öneriler")
            {
                this.sql = "SELECT LOKASYON,COUNT(ONR_NO) FROM ONRFRM WHERE KAP_TARIHI BETWEEN " + tarih + " AND " + tarih2 + "";
                this.sql += "AND ODUL<>'0' GROUP BY LOKASYON";

            }
            if (gelen_veri == "")
            {
                this.sql = "SELECT LOKASYON,COUNT(ONR_NO) FROM ONRFRM WHERE ONRGIRTAR BETWEEN " + tarih + " AND " + tarih2 + "";
                this.sql += " GROUP BY LOKASYON";

            }
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //Kayıt bulunamadı
                Dosis_rapor_bilgileri kayit = new Dosis_rapor_bilgileri();
                kayit.Rapor_id = 0;
                kayitlar.Add(kayit);
            }
            else
            {
                while (this.dr.Read())
                {
                    Dosis_rapor_bilgileri d = new Dosis_rapor_bilgileri();
                    d.Rapor_id = 1;
                    d.Lokasyon = this.dr[0].ToString();
                    d.Oneri_sayisi = this.dr[1].ToString();
                    kayitlar.Add(d);
                }
            }

            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;
        }

        public List<Dosis_rapor_bilgileri> dosis_listesi_lokasyon_trigger(string gelen_veri_oneri_durumu, string gelen_veri_lokasyon, string tarih, string tarih2)
        {

            List<Dosis_rapor_bilgileri> kayitlar = new List<Dosis_rapor_bilgileri>();

            if (gelen_veri_oneri_durumu == "Uygulamadaki öneriler")
            {
                this.sql = "SELECT * FROM ONRFRM WHERE ONRFRM.YER=4 ";
                if (gelen_veri_lokasyon == "Diler")
                {
                    this.sql += "AND LOKASYON='Diler' ORDER BY ONRGIRTAR DESC";
                }
                else
                {
                    this.sql += "AND LOKASYON='Filmasin' ORDER BY ONRGIRTAR DESC";
                }
            }
            if (gelen_veri_oneri_durumu == "Red edilen öneriler")
            {
                this.sql = "SELECT * FROM ONRFRM WHERE KAP_TARIHI BETWEEN " + tarih + " AND " + tarih2 + " AND (Uygulayıcı_Red<>0 or Mdr_Red<>0) ";
                if (gelen_veri_lokasyon == "Diler")
                {
                    this.sql += "AND LOKASYON='Diler' ORDER BY ONRGIRTAR DESC";
                }
                else
                {
                    this.sql += "AND LOKASYON='Filmasin' ORDER BY ONRGIRTAR DESC";
                }
            }
            if (gelen_veri_oneri_durumu == "İptal edilen öneriler")
            {
                this.sql = "SELECT * FROM ONRFRM WHERE KAP_TARIHI BETWEEN " + tarih + " AND " + tarih2 + " AND Iptal=1 ";
                if (gelen_veri_lokasyon == "Diler")
                {
                    this.sql += "AND LOKASYON='Diler' ORDER BY ONRGIRTAR DESC";
                }
                else
                {
                    this.sql += "AND LOKASYON='Filmasin' ORDER BY ONRGIRTAR DESC";
                }
            }
            if (gelen_veri_oneri_durumu == "Müdürden atanmayı bekleyen öneriler")
            {
                this.sql = "SELECT * FROM ONRFRM WHERE YER=3 ";
                if (gelen_veri_lokasyon == "Diler")
                {
                    this.sql += "AND LOKASYON='Diler' ORDER BY ONRGIRTAR DESC";
                }
                else
                {
                    this.sql += "AND LOKASYON='Filmasin' ORDER BY ONRGIRTAR DESC";
                }
            }
            if (gelen_veri_oneri_durumu == "Ödül alan öneriler")
            {
                this.sql = "SELECT * FROM ONRFRM WHERE KAP_TARIHI BETWEEN " + tarih + " AND " + tarih2 + " AND ODUL<>'0' ";
                if (gelen_veri_lokasyon == "Diler")
                {
                    this.sql += "AND LOKASYON='Diler' ORDER BY ONRGIRTAR DESC";
                }
                else
                {
                    this.sql += "AND LOKASYON='Filmasin' ORDER BY ONRGIRTAR DESC";
                }
            }
            if (gelen_veri_oneri_durumu == "")
            {
                this.sql = "SELECT * FROM ONRFRM WHERE ONRGIRTAR BETWEEN " + tarih + " AND " + tarih2 + " ";
                if (gelen_veri_lokasyon == "Diler")
                {
                    this.sql += "AND LOKASYON='Diler' ORDER BY ONRGIRTAR DESC";
                }
                else
                {
                    this.sql += "AND LOKASYON='Filmasin' ORDER BY ONRGIRTAR DESC";
                }
            }

            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Dosis_rapor_bilgileri kayit = new Dosis_rapor_bilgileri();
                kayit.Rapor_id = 0;
                kayitlar.Add(kayit);
            }
            else
            {
                while (this.dr.Read())
                {
                    Dosis_rapor_bilgileri d = new Dosis_rapor_bilgileri();
                    d.Rapor_id = 1;
                    d.Oneri_no = this.dr[0].ToString();
                    d.Form_no = this.dr[1].ToString();
                    d.Lokasyon = this.dr[28].ToString();
                    d.Kategori = this.dr[32].ToString();
                    d.Oneri_giris_tarihi = this.dr[2].ToString();
                    string sqly = "(SELECT (ONERYI_VEREN) FROM DOSIS.ONRVRN WHERE ONR_NO = " + d.Oneri_no + ") ";
                    this.cmd.CommandText = sqly;
                    this.dr2 = this.cmd.ExecuteReader();
                    while (this.dr2.Read())
                    {
                        d.Oneri_veren_adsoyad = this.dr2[0].ToString();
                        ad_soyad += "," + (d.Oneri_veren_adsoyad);
                        d.Oneri_veren_adsoyad = ad_soyad.Substring(1);

                    }
                    string sqlz = "(SELECT DISTINCT(UNITESI) FROM DOSIS.ONRVRN WHERE ONR_NO = " + d.Oneri_no + ") ";
                    this.cmd.CommandText = sqlz;
                    this.dr2 = this.cmd.ExecuteReader();
                    while (this.dr2.Read())
                    {
                        d.Oneri_veren_bolum = this.dr2[0].ToString();
                        unite += "," + (d.Oneri_veren_bolum);
                        d.Oneri_veren_bolum = unite.Substring(1);

                    }
                    string sqlt = "(SELECT (GIDYER) FROM DOSIS.ONROZT WHERE YAZISI = 'Müdür' AND ONR_NO = " + d.Oneri_no + ") ";
                    this.cmd.CommandText = sqlt;
                    this.dr2 = this.cmd.ExecuteReader();
                    while (this.dr2.Read())
                    {

                        d.Mudur_onayi = this.dr2[0].ToString();
                        mudur_onayi += "," + (d.Mudur_onayi);
                        d.Mudur_onayi = mudur_onayi.Substring(1);

                    }
                    string sqlw = "(SELECT KAYTAR FROM DOSIS.ONROZT WHERE YAZISI = 'Ödülü Verildi' AND ONR_NO = " + d.Oneri_no + ") ";
                    this.cmd.CommandText = sqlw;
                    this.dr2 = this.cmd.ExecuteReader();
                    while (this.dr2.Read())
                    {
                        d.Odul_verilis_tarihi = this.dr2[0].ToString();
                        odul_verilis_tarihi += "," + (d.Odul_verilis_tarihi);
                        d.Odul_verilis_tarihi = odul_verilis_tarihi.Substring(1);
                    }
                    string sqlp = "(SELECT (GIDYER) FROM DOSIS.ONROZT WHERE YAZISI = 'Uygulayıcı Atandı' AND ONR_NO =" + d.Oneri_no + ") ";
                    this.cmd.CommandText = sqlp;
                    this.dr2 = this.cmd.ExecuteReader();
                    while (this.dr2.Read())
                    {
                        d.Uygulama_gorevlisi = this.dr2[0].ToString();
                        uygulama_gorevlisi += "," + (d.Uygulama_gorevlisi);
                        d.Uygulama_gorevlisi = uygulama_gorevlisi.Substring(1);
                    }

                    string sqlr = "(SELECT DISTINCT(GETIRISI),YAZISI FROM DOSIS.ONROZT WHERE " +
                        " ONR_NO =" + d.Oneri_no + " AND GETIRISI<>'0.00 TL'  AND GETIRISI<>'0') ";
                    this.cmd.CommandText = sqlr;
                    this.dr2 = this.cmd.ExecuteReader();
                    while (this.dr2.Read())
                    {
                        if (this.dr2[1].ToString().Substring(0, 40) == "Uygulayıcıdan Başkana, getiri hesaplandı")
                        {
                            d.Getiri_miktari = this.dr2[0].ToString();
                            getiri_miktari += "," + (d.Getiri_miktari);
                            d.Getiri_miktari = getiri_miktari.Substring(1);
                        }
                    }
                    d.Oneri_uygulayan_bolum = this.dr[17].ToString();
                    d.Uygulama_yeri = this.dr[3].ToString();
                    d.Oneri_ozeti = this.dr[7].ToString();
                    d.Oneri_baslama_tarihi = this.dr[10].ToString();
                    d.Planlanan_bitis_tarihi = this.dr[11].ToString();
                    d.Oneri_bitis_tarihi = this.dr[15].ToString();
                    d.Oneri_kapanis_tarihi = this.dr[16].ToString();
                    d.Getiri_aciklamasi = this.dr[6].ToString();
                    d.Odul = this.dr[12].ToString();
                    d.İptal_nedeni = this.dr[22].ToString();
                    d.Uygulayici_red_nedeni = this.dr[24].ToString();
                    d.Mudur_red_nedeni = this.dr[26].ToString();
                    d.Planlanan_bitis_tarihi_guncelleme = this.dr[11].ToString();
                    kayitlar.Add(d);
                    ad_soyad = "";
                    unite = "";
                    mudur_onayi = "";
                    odul_verilis_tarihi = "";
                    uygulama_gorevlisi = "";
                    getiri_miktari = "";
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;
        }

        public List<Dosis_rapor_bilgileri> dosis_listesi(string gelen_veri, string tarih, string tarih2)
        {
            List<Dosis_rapor_bilgileri> kayitlar = new List<Dosis_rapor_bilgileri>();
            if (gelen_veri == "Diler" || gelen_veri == "Filmasin")
            {
                this.sql = "SELECT * FROM ONRFRM WHERE ONRGIRTAR BETWEEN " + tarih + " AND " + tarih2 + " AND LOKASYON='" + gelen_veri + "' ORDER BY ONRGIRTAR DESC";
            }
            if (gelen_veri == "Uygulamadaki öneriler")
            {
                this.sql = "SELECT * FROM ONRFRM WHERE ONRFRM.YER=4 ORDER BY ONRGIRTAR DESC";

            }
            if (gelen_veri == "Red edilen öneriler")
            {
                this.sql = "SELECT * FROM ONRFRM WHERE KAP_TARIHI BETWEEN " + tarih + " AND " + tarih2 + " AND (Uygulayıcı_Red<>0 or Mdr_Red<>0) ORDER BY ONRGIRTAR DESC";

            }
            if (gelen_veri == "İptal edilen öneriler")
            {
                this.sql = "SELECT * FROM ONRFRM WHERE KAP_TARIHI BETWEEN " + tarih + " AND " + tarih2 + " AND Iptal=1  ORDER BY ONRGIRTAR DESC";

            }
            if (gelen_veri == "Müdürden atanmayı bekleyen öneriler")
            {
                this.sql = "SELECT * FROM ONRFRM WHERE YER=3  ORDER BY ONRGIRTAR DESC";

            }
            if (gelen_veri == "Ödül alan öneriler")
            {
                this.sql = "SELECT * FROM ONRFRM WHERE KAP_TARIHI BETWEEN " + tarih + " AND " + tarih2 + " AND ODUL<>'0'  ORDER BY ONRGIRTAR DESC";

            }
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Dosis_rapor_bilgileri kayit = new Dosis_rapor_bilgileri();
                kayit.Rapor_id = 0;
                kayitlar.Add(kayit);
            }
            else
            {
                while (this.dr.Read())
                {
                    Dosis_rapor_bilgileri d = new Dosis_rapor_bilgileri();
                    d.Rapor_id = 1;
                    d.Oneri_no = this.dr[0].ToString();
                    d.Form_no = this.dr[1].ToString();
                    d.Lokasyon = this.dr[28].ToString();
                    d.Kategori = this.dr[32].ToString();
                    d.Oneri_giris_tarihi = this.dr[2].ToString();
 
                    string sqly = "(SELECT (ONERYI_VEREN) FROM DOSIS.ONRVRN WHERE ONR_NO = " + d.Oneri_no + ") ";
                    this.cmd.CommandText = sqly;
                    this.dr2 = this.cmd.ExecuteReader();
                    while (this.dr2.Read())
                    {
                        d.Oneri_veren_adsoyad = this.dr2[0].ToString();
                        ad_soyad += "," + (d.Oneri_veren_adsoyad);
                        d.Oneri_veren_adsoyad = ad_soyad.Substring(1);

                    }
                    string sqlz = "(SELECT DISTINCT(UNITESI) FROM DOSIS.ONRVRN WHERE ONR_NO = " + d.Oneri_no + ") ";
                    this.cmd.CommandText = sqlz;
                    this.dr2 = this.cmd.ExecuteReader();
                    while (this.dr2.Read())
                    {
                        d.Oneri_veren_bolum = this.dr2[0].ToString();
                        unite += "," + (d.Oneri_veren_bolum);
                        d.Oneri_veren_bolum = unite.Substring(1);

                    }
                    string sqlt = "(SELECT (GIDYER) FROM DOSIS.ONROZT WHERE YAZISI = 'Müdür' AND ONR_NO = " + d.Oneri_no + ") ";
                    this.cmd.CommandText = sqlt;
                    this.dr2 = this.cmd.ExecuteReader();
                    while (this.dr2.Read())
                    {

                        d.Mudur_onayi = this.dr2[0].ToString();
                        mudur_onayi += "," + (d.Mudur_onayi);
                        d.Mudur_onayi = mudur_onayi.Substring(1);

                    }
                    string sqlw = "(SELECT KAYTAR FROM DOSIS.ONROZT WHERE YAZISI = 'Ödülü Verildi' AND ONR_NO = " + d.Oneri_no + ") ";
                    this.cmd.CommandText = sqlw;
                    this.dr2 = this.cmd.ExecuteReader();
                    while (this.dr2.Read())
                    {
                        d.Odul_verilis_tarihi = this.dr2[0].ToString();
                        odul_verilis_tarihi += "," + (d.Odul_verilis_tarihi);
                        d.Odul_verilis_tarihi = odul_verilis_tarihi.Substring(1);
                    }
                    string sqlp = "(SELECT (GIDYER) FROM DOSIS.ONROZT WHERE YAZISI = 'Uygulayıcı Atandı' AND ONR_NO =" + d.Oneri_no + ") ";
                    this.cmd.CommandText = sqlp;
                    this.dr2 = this.cmd.ExecuteReader();
                    while (this.dr2.Read())
                    {
                        d.Uygulama_gorevlisi = this.dr2[0].ToString();
                        uygulama_gorevlisi += "," + (d.Uygulama_gorevlisi);
                        d.Uygulama_gorevlisi = uygulama_gorevlisi.Substring(1);
                    }

                    string sqlr = "(SELECT DISTINCT(GETIRISI),YAZISI FROM DOSIS.ONROZT WHERE " +
                        " ONR_NO =" + d.Oneri_no + " AND GETIRISI<>'0.00 TL'  AND GETIRISI<>'0') ";
                    this.cmd.CommandText = sqlr;
                    this.dr2 = this.cmd.ExecuteReader();
                    while (this.dr2.Read())
                    {
                        if (this.dr2[1].ToString().Substring(0, 40) == "Uygulayıcıdan Başkana, getiri hesaplandı")
                        {
                            d.Getiri_miktari = this.dr2[0].ToString();
                            getiri_miktari += "," + (d.Getiri_miktari);
                            d.Getiri_miktari = getiri_miktari.Substring(1);
                        }
                    }
                    d.Oneri_uygulayan_bolum = this.dr[17].ToString();
                    d.Uygulama_yeri = this.dr[3].ToString();
                    d.Oneri_ozeti = this.dr[7].ToString();
                    d.Oneri_baslama_tarihi = this.dr[10].ToString();
                    d.Planlanan_bitis_tarihi = this.dr[11].ToString();
                    d.Oneri_bitis_tarihi = this.dr[15].ToString();
                    d.Oneri_kapanis_tarihi = this.dr[16].ToString();
                    d.Getiri_aciklamasi = this.dr[6].ToString();
                    d.Odul = this.dr[12].ToString();
                    //if (d.Planlanan_bitis_tarihi != "0")
                    //{
                    //    DateTime dt = new DateTime();
                    //    dt = DateTime.Now;
                    //    string bugunku_tarih = dt.ToString("yyyyMMdd");//veritabanindaki kayit bicimi  
                    //    int yil_ = Convert.ToInt32(bugunku_tarih.Substring(0, 4));
                    //    int ay_ = Convert.ToInt32(bugunku_tarih.Substring(4).Substring(0, 2));
                    //    int gun_ = Convert.ToInt32(bugunku_tarih.Substring(6));

                    //    int planlanan_yil = Convert.ToInt32(d.Planlanan_bitis_tarihi.Substring(0, 4));
                    //    int planlanan_ay = Convert.ToInt32(d.Planlanan_bitis_tarihi.Substring(4).Substring(0, 2));
                    //    int planlanan_gun = Convert.ToInt32(d.Planlanan_bitis_tarihi.Substring(6));
                    //    DateTime baslama_tarihi = new DateTime(planlanan_yil, planlanan_ay, planlanan_gun);
                    //    DateTime bitis_tarihi = new DateTime(yil_, ay_, gun_);
                    //    TimeSpan kalan_gun = bitis_tarihi - baslama_tarihi;//Sonucu zaman olarak döndürür
                    //    double toplam_gun = kalan_gun.TotalDays;// kalan_gun den TotalDays ile sadece toplam gun değerini çekiyoruz. 

                    //    d.Gecikme_gunu = toplam_gun.ToString();
                    //}

                    d.İptal_nedeni = this.dr[22].ToString();
                    d.Uygulayici_red_nedeni = this.dr[24].ToString();
                    d.Mudur_red_nedeni = this.dr[26].ToString();
                    d.Planlanan_bitis_tarihi_guncelleme = this.dr[11].ToString();
                    kayitlar.Add(d);
                    ad_soyad = "";
                    unite = "";
                    mudur_onayi = "";
                    odul_verilis_tarihi = "";
                    uygulama_gorevlisi = "";
                    getiri_miktari = "";
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;

        }
        public List<Dosis_rapor_bilgileri> dosis_listesi_kategori_trigger(string gelen_veri_oneri_durumu, string gelen_veri_kategori, string gelen_veri_lokasyon, string tarih, string tarih2)
        {
            List<Dosis_rapor_bilgileri> kayitlar = new List<Dosis_rapor_bilgileri>();

            if (gelen_veri_oneri_durumu == "Uygulamadaki öneriler")
            {
                this.sql = "SELECT * FROM ONRFRM WHERE ONRFRM.YER=4 ";
                if (gelen_veri_lokasyon == "Diler")
                {
                    this.sql += "AND LOKASYON='Diler' AND ONERI_KATEGORI='" + gelen_veri_kategori + "' ORDER BY ONRGIRTAR DESC";
                }
                else
                {
                    this.sql += "AND LOKASYON='Filmasin' AND ONERI_KATEGORI='" + gelen_veri_kategori + "' ORDER BY ONRGIRTAR DESC";
                }
            }
            if (gelen_veri_oneri_durumu == "Red edilen öneriler")
            {
                this.sql = "SELECT * FROM ONRFRM WHERE KAP_TARIHI BETWEEN " + tarih + " AND " + tarih2 + " AND (Uygulayıcı_Red<>0 or Mdr_Red<>0) ";
                if (gelen_veri_lokasyon == "Diler")
                {
                    this.sql += "AND LOKASYON='Diler' AND ONERI_KATEGORI='" + gelen_veri_kategori + "' ORDER BY ONRGIRTAR DESC";
                }
                else
                {
                    this.sql += "AND LOKASYON='Filmasin' AND ONERI_KATEGORI='" + gelen_veri_kategori + "' ORDER BY ONRGIRTAR DESC";
                }
            }
            if (gelen_veri_oneri_durumu == "İptal edilen öneriler")
            {
                this.sql = "SELECT * FROM ONRFRM WHERE KAP_TARIHI BETWEEN " + tarih + " AND " + tarih2 + " AND Iptal=1 ";
                if (gelen_veri_lokasyon == "Diler")
                {
                    this.sql += "AND LOKASYON='Diler' AND ONERI_KATEGORI='" + gelen_veri_kategori + "' ORDER BY ONRGIRTAR DESC";
                }
                else
                {
                    this.sql += "AND LOKASYON='Filmasin' AND ONERI_KATEGORI='" + gelen_veri_kategori + "' ORDER BY ONRGIRTAR DESC";
                }
            }
            if (gelen_veri_oneri_durumu == "Müdürden atanmayı bekleyen öneriler")
            {
                this.sql = "SELECT * FROM ONRFRM WHERE YER=3 ";
                if (gelen_veri_lokasyon == "Diler")
                {
                    this.sql += "AND LOKASYON='Diler' AND ONERI_KATEGORI='" + gelen_veri_kategori + "' ORDER BY ONRGIRTAR DESC";
                }
                else
                {
                    this.sql += "AND LOKASYON='Filmasin' AND ONERI_KATEGORI='" + gelen_veri_kategori + "' ORDER BY ONRGIRTAR DESC";
                }
            }
            if (gelen_veri_oneri_durumu == "Ödül alan öneriler")
            {
                this.sql = "SELECT * FROM ONRFRM WHERE KAP_TARIHI BETWEEN " + tarih + " AND " + tarih2 + " AND ODUL<>'0' ";
                if (gelen_veri_lokasyon == "Diler")
                {
                    this.sql += "AND LOKASYON='Diler' AND ONERI_KATEGORI='" + gelen_veri_kategori + "' ORDER BY ONRGIRTAR DESC";
                }
                else
                {
                    this.sql += "AND LOKASYON='Filmasin' AND ONERI_KATEGORI='" + gelen_veri_kategori + "' ORDER BY ONRGIRTAR DESC";
                }
            }
            if (gelen_veri_oneri_durumu == "")
            {
                this.sql = "SELECT * FROM ONRFRM WHERE ONRGIRTAR BETWEEN " + tarih + " AND " + tarih2 + " ";
                if (gelen_veri_lokasyon == "Diler")
                {
                    this.sql += "AND LOKASYON='Diler' AND ONERI_KATEGORI='" + gelen_veri_kategori + "' ORDER BY ONRGIRTAR DESC";

                }

                if (gelen_veri_lokasyon == "Filmasin")
                {
                    this.sql += "AND LOKASYON='Filmasin' AND ONERI_KATEGORI='" + gelen_veri_kategori + "' ORDER BY ONRGIRTAR DESC";

                }
                if (gelen_veri_lokasyon == "")
                {
                    this.sql += "AND ONERI_KATEGORI='" + gelen_veri_kategori + "' ORDER BY ONRGIRTAR DESC";
                }


            }
            if (gelen_veri_oneri_durumu == "" && gelen_veri_lokasyon != "")
            {
                this.sql = "SELECT * FROM ONRFRM WHERE ONRGIRTAR BETWEEN " + tarih + " AND " + tarih2 + " ";

                this.sql += "AND ONERI_KATEGORI='" + gelen_veri_kategori + "' ORDER BY ONRGIRTAR DESC";



            }


            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Dosis_rapor_bilgileri kayit = new Dosis_rapor_bilgileri();
                kayit.Rapor_id = 0;
                kayitlar.Add(kayit);
            }
            else
            {
                while (this.dr.Read())
                {
                    Dosis_rapor_bilgileri d = new Dosis_rapor_bilgileri();
                    d.Rapor_id = 1;
                    d.Oneri_no = this.dr[0].ToString();
                    d.Form_no = this.dr[1].ToString();
                    d.Lokasyon = this.dr[28].ToString();
                    d.Kategori = this.dr[32].ToString();
                    d.Oneri_giris_tarihi = this.dr[2].ToString();
                    string sqly = "(SELECT (ONERYI_VEREN) FROM DOSIS.ONRVRN WHERE ONR_NO = " + d.Oneri_no + ") ";
                    this.cmd.CommandText = sqly;
                    this.dr2 = this.cmd.ExecuteReader();
                    while (this.dr2.Read())
                    {
                        d.Oneri_veren_adsoyad = this.dr2[0].ToString();
                        ad_soyad += "," + (d.Oneri_veren_adsoyad);
                        d.Oneri_veren_adsoyad = ad_soyad.Substring(1);

                    }
                    string sqlz = "(SELECT DISTINCT(UNITESI) FROM DOSIS.ONRVRN WHERE ONR_NO = " + d.Oneri_no + ") ";
                    this.cmd.CommandText = sqlz;
                    this.dr2 = this.cmd.ExecuteReader();
                    while (this.dr2.Read())
                    {
                        d.Oneri_veren_bolum = this.dr2[0].ToString();
                        unite += "," + (d.Oneri_veren_bolum);
                        d.Oneri_veren_bolum = unite.Substring(1);

                    }
                    string sqlt = "(SELECT (GIDYER) FROM DOSIS.ONROZT WHERE YAZISI = 'Müdür' AND ONR_NO = " + d.Oneri_no + ") ";
                    this.cmd.CommandText = sqlt;
                    this.dr2 = this.cmd.ExecuteReader();
                    while (this.dr2.Read())
                    {

                        d.Mudur_onayi = this.dr2[0].ToString();
                        mudur_onayi += "," + (d.Mudur_onayi);
                        d.Mudur_onayi = mudur_onayi.Substring(1);

                    }
                    string sqlw = "(SELECT KAYTAR FROM DOSIS.ONROZT WHERE YAZISI = 'Ödülü Verildi' AND ONR_NO = " + d.Oneri_no + ") ";
                    this.cmd.CommandText = sqlw;
                    this.dr2 = this.cmd.ExecuteReader();
                    while (this.dr2.Read())
                    {
                        d.Odul_verilis_tarihi = this.dr2[0].ToString();
                        odul_verilis_tarihi += "," + (d.Odul_verilis_tarihi);
                        d.Odul_verilis_tarihi = odul_verilis_tarihi.Substring(1);
                    }
                    string sqlp = "(SELECT (GIDYER) FROM DOSIS.ONROZT WHERE YAZISI = 'Uygulayıcı Atandı' AND ONR_NO =" + d.Oneri_no + ") ";
                    this.cmd.CommandText = sqlp;
                    this.dr2 = this.cmd.ExecuteReader();
                    while (this.dr2.Read())
                    {
                        d.Uygulama_gorevlisi = this.dr2[0].ToString();
                        uygulama_gorevlisi += "," + (d.Uygulama_gorevlisi);
                        d.Uygulama_gorevlisi = uygulama_gorevlisi.Substring(1);
                    }

                    string sqlr = "(SELECT DISTINCT(GETIRISI),YAZISI FROM DOSIS.ONROZT WHERE " +
                        " ONR_NO =" + d.Oneri_no + " AND GETIRISI<>'0.00 TL'  AND GETIRISI<>'0') ";
                    this.cmd.CommandText = sqlr;
                    this.dr2 = this.cmd.ExecuteReader();
                    while (this.dr2.Read())
                    {
                        if (this.dr2[1].ToString().Substring(0, 40) == "Uygulayıcıdan Başkana, getiri hesaplandı")
                        {
                            d.Getiri_miktari = this.dr2[0].ToString();
                            getiri_miktari += "," + (d.Getiri_miktari);
                            d.Getiri_miktari = getiri_miktari.Substring(1);
                        }
                    }
                    d.Oneri_uygulayan_bolum = this.dr[17].ToString();
                    d.Uygulama_yeri = this.dr[3].ToString();
                    d.Oneri_ozeti = this.dr[7].ToString();
                    d.Oneri_baslama_tarihi = this.dr[10].ToString();
                    d.Planlanan_bitis_tarihi = this.dr[11].ToString();
                    d.Oneri_bitis_tarihi = this.dr[15].ToString();
                    d.Oneri_kapanis_tarihi = this.dr[16].ToString();
                    d.Getiri_aciklamasi = this.dr[6].ToString();
                    d.Odul = this.dr[12].ToString();
                    d.İptal_nedeni = this.dr[22].ToString();
                    d.Uygulayici_red_nedeni = this.dr[24].ToString();
                    d.Mudur_red_nedeni = this.dr[26].ToString();
                    d.Planlanan_bitis_tarihi_guncelleme = this.dr[11].ToString();
                    kayitlar.Add(d);
                    ad_soyad = "";
                    unite = "";
                    mudur_onayi = "";
                    odul_verilis_tarihi = "";
                    uygulama_gorevlisi = "";
                    getiri_miktari = "";
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;
        }


        //** iyileştirme raporu
        public List<string> cmb_bolum_doldur()
        {
            List<string> kayitlar = new List<string>();
            string sql = "SELECT DISTINCT(BLM_MDR) FROM DOSIS.IYILESTIRME";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = sql;
            this.dr = this.cmd.ExecuteReader();
            while (this.dr.Read())
            {
                string bolum = dr[0].ToString();

                kayitlar.Add(bolum);
            }
            return kayitlar;
        }
        public List<string> cmb_kategori_doldur()
        {
            List<string> kayitlar = new List<string>();
            string sql = "SELECT DISTINCT(IYILESTIRME_KATEGORI) FROM DOSIS.IYILESTIRME";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = sql;
            this.dr = this.cmd.ExecuteReader();
            while (this.dr.Read())
            {
                string kategori = dr[0].ToString();

                kayitlar.Add(kategori);
            }
            return kayitlar;
        }

        public List<Dosis_rapor_bilgileri> iyilestirme_no_raporu(string yil, string bolum, string kategori)
        {
            List<Dosis_rapor_bilgileri> kayitlar = new List<Dosis_rapor_bilgileri>();
            this.sql = "SELECT INO FROM DOSIS.IYILESTIRME ";
            if (yil != "Tümü")
            {
                this.sql += "WHERE YIL='" + yil + "'";
            }
            if (bolum != "Tümü")
            {
                if (yil == "Tümü")
                {
                    this.sql += "WHERE BLM_MDR='" + bolum + "'";
                }
                else
                {
                    this.sql += "AND BLM_MDR='" + bolum + "'";
                }


            }
            if (kategori != "Tümü")
            {
                if (yil == "Tümü")
                {
                    if (bolum != "Tümü")
                    {
                        this.sql += " AND IYILESTIRME_KATEGORI='" + kategori + "'";
                    }
                    else
                    {
                        this.sql += "WHERE IYILESTIRME_KATEGORI='" + kategori + "'";
                    }
                }
                else
                {

                    this.sql += " AND IYILESTIRME_KATEGORI='" + kategori + "'";

                }
            }



            this.sql += " ORDER BY INO ";
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Dosis_rapor_bilgileri kayit = new Dosis_rapor_bilgileri();
                kayit.Iyilestirme_no = "Kayıt yok";
                kayitlar.Add(kayit);
            }
            else
            {
                while (this.dr.Read())
                {
                    Dosis_rapor_bilgileri d = new Dosis_rapor_bilgileri();
                    d.Rapor_id = 1;
                    d.Iyilestirme_no = this.dr[0].ToString();
                    kayitlar.Add(d);
                }
            }


            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;
        }
        public List<Dosis_rapor_bilgileri> iyilestirme_no_ayrinti(string iyilestirme_no)
        {
            List<Dosis_rapor_bilgileri> kayitlar = new List<Dosis_rapor_bilgileri>();
            this.sql = "SELECT KONU,GRUBU,KAYNAK,PRB_TNM,HEDEF,YAP_IS,DEGERLENDIRME,CAL_TAR,CALBIT_TAR,IYILESTIRME_KATEGORI FROM DOSIS.IYILESTIRME WHERE INO='" + iyilestirme_no + "' ";
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Dosis_rapor_bilgileri kayit = new Dosis_rapor_bilgileri();
                kayit.Degerlendirme = "Kayıt yok";
                kayitlar.Add(kayit);
            }
            else
            {
                while (this.dr.Read())
                {
                    Dosis_rapor_bilgileri d = new Dosis_rapor_bilgileri();
                    d.Rapor_id = 1;
                    d.Iyilestirme_no = iyilestirme_no;
                    d.Konu = this.dr[0].ToString();
                    d.Calisma_grubu = this.dr[1].ToString();
                    d.Kaynaklar = this.dr[2].ToString();
                    d.Problem_tanimi = this.dr[3].ToString();
                    d.Hedef = this.dr[4].ToString();
                    d.Yapilan_isler = this.dr[5].ToString();
                    d.Degerlendirme = this.dr[6].ToString();
                    if (this.dr[7].ToString() != "")
                    {
                        int calisma_baslangic = Convert.ToInt32(this.dr[7].ToString());

                        tarih_parse = tarihFormat(calisma_baslangic);
                        d.Calisma_baslangic_tarihi = tarih_parse.ToString();

                    }
                    if (this.dr[8].ToString() != "")
                    {
                        int calisma_bitis = Convert.ToInt32(this.dr[8].ToString());

                        tarih_parse = tarihFormat(calisma_bitis);
                        d.Calisma_bitis_tarihi = tarih_parse.ToString();
                    }
                    d.Iyilestirme_kategori = this.dr[9].ToString();

                    kayitlar.Add(d);
                }
            }


            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;
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
    }
}

