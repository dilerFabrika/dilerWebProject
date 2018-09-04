using diler.Entity;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace diler.Dal
{
    public class Performans_database
    {
        OracleConnection conn;
        OracleConnection conn2;
        string connetionString;
        string sql;
        OracleCommand cmd;
        OracleDataReader dr;
        OracleDataReader dr2;
        public Performans_database()
        {
            this.connetionString = @"Data Source=(DESCRIPTION=" + "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.198.191)(PORT=1521)))" + "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=DLRORA)));" + "User Id=IK;Password=IK;";
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


        public List<Performans_raporu> performans_raporu_data_read(int tarih = 0, int secilen_vrd = 0)
        {
            return performans_raporu_select(tarih, secilen_vrd);

        }
        public List<Performans_raporu> performans_raporu_data_read2(int tarih = 0, int secilen_vrd = 0)
        {
            return performans_raporu_select3(tarih, secilen_vrd);

        }
        public List<Performans_raporu> performans_raporu_data_read4(int tarih = 0, int secilen_vrd = 0)
        {
            return performans_raporu_select4(tarih, secilen_vrd);

        }
        public List<Performans_raporu> performans_raporu_data_read5(int tarih = 0, int secilen_vrd = 0)
        {
            return performans_raporu_select5(tarih, secilen_vrd);

        }

        public List<Performans_raporu> performans_raporu_data_read6(int tarih = 0, int secilen_vrd = 0)
        {
            return performans_raporu_select6(tarih, secilen_vrd);

        }

        public List<Performans_raporu> performans_raporu_select(int tarih = 0, int secilen_vrd = 0)
        {
            List<Performans_raporu> kayitlar = new List<Performans_raporu>();
            this.sql = "SELECT * " +
                       "FROM URTHRK.CH_DOKUMNO_PERFORMANS PR ";
            if (tarih > 0)
            {
                this.sql += "WHERE PR.DOKUMTAR = " + tarih + "";
            }
            if (secilen_vrd != 0)
            {
                this.sql += " AND VRD=" + secilen_vrd + "";
            }
            this.sql += " ORDER BY PR.DNO ASC";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Performans_raporu kayit = new Performans_raporu();
                kayit.Vrd = "Listelenecek Kayıt Bulunamadı !!";
                kayit.Id = 0;
                kayitlar.Add(kayit);
            }
            else
            {
                while (this.dr.Read())
                {
                    Performans_raporu kayit = new Performans_raporu();
                    kayit.Id = 1;
                    kayit.Dokum_no = Convert.ToInt32(this.dr[1].ToString());
                    kayit.Vrd = this.dr[2].ToString();
                    //kayit.Dokum_tarihi = Convert.ToInt32(this.dr["DOKUMTAR"].ToString().Equals("") ? "0" : this.dr["DOKUMTAR"].ToString());
                    kayit.Srj = (dr[3].ToString());
                    kayit.Toplam_srj = (dr[4].ToString());
                    kayit.Dokum_baslangic_saati = this.dr[28].ToString();
                    kayit.Devirme_saati = this.dr[5].ToString();
                    kayit.Enerjili_sure = this.dr[6].ToString();
                    kayit.Enerjisiz_sure = this.dr[7].ToString();
                    kayit.Toplam_sure = this.dr[8].ToString();
                    kayit.Devirme_sicaklik = this.dr[9].ToString();
                    kayit.Po_giris_sicakligi = this.dr[10].ToString();
                    kayit.Ao_enerji = (dr[11].ToString());
                    kayit.Po_enerji = this.dr[12].ToString();
                    kayit.Enj_Kok_elt = this.dr[13].ToString();
                    kayit.Enj_kırec = this.dr[14].ToString();
                    kayit.Parca_kırec = this.dr[15].ToString();
                    kayit.Toplam_kirec = Convert.ToDouble(this.dr[16].ToString().Equals("") ? "0.0" : this.dr[16].ToString());
                    kayit.Kutuk_tonaji = Convert.ToDouble(this.dr[17].ToString().Equals("") ? "0.0" : this.dr[17].ToString());
                    kayit.Tandis_bnd_sayisi = this.dr[18].ToString();
                    kayit.Canak_dokum_say = this.dr[19].ToString();
                    kayit.Kapak_dokum_say = this.dr[20].ToString();
                    kayit.Yurek_dokum_say = this.dr[21].ToString();
                    kayit.Rbt_delik_sayisi = this.dr[22].ToString();
                    kayit.Ao_trnk_kapatma_enerjisi = (dr[23].ToString());
                    kayit.Brl_dgaz = this.dr[24].ToString();
                    kayit.Rcb_brl_dgaz = this.dr[25].ToString();
                    kayit.Pc_dgaz = this.dr[26].ToString();
                    kayit.Toplam_dgaz = this.dr[27].ToString();
                    if (kayit.Toplam_dgaz != "")
                    {
                        //    // kayit.Deneme = Convert.ToDouble(kayit.Toplam_dgaz) / kayit.Kutuk_tonaji;
                        //    // kayit.Deneme = Math.Round(Convert.ToDouble(kayit.Toplam_dgaz) / kayit.Kutuk_tonaji, 3);
                        kayit.Toplam_dgaz_ToplamTonaj = Math.Round(Convert.ToDouble(kayit.Toplam_dgaz) / kayit.Kutuk_tonaji,2).Equals("") ? "0.0" : Math.Round(Convert.ToDouble(kayit.Toplam_dgaz) / kayit.Kutuk_tonaji, 2).ToString();
                        if (kayit.Toplam_kirec != 0)
                        {

                            // kayit.Toplam_dgaz_Toplamkireç = Math.Round(Convert.ToDouble(kayit.Toplam_dgaz) / kayit.Toplam_kirec, 3).Equals("") ? "0.0" : Math.Round(Convert.ToDouble(kayit.Toplam_dgaz) / kayit.Toplam_kirec, 3).ToString();
                            kayit.Toplam_dgaz_Toplamkireç = Math.Round(Convert.ToDouble(kayit.Toplam_kirec) / kayit.Kutuk_tonaji,2).Equals("") ? "0.0" : Math.Round(Convert.ToDouble(kayit.Toplam_kirec) / kayit.Kutuk_tonaji,2).ToString();
                        }
                    }
                    else
                    {
                        kayit.Toplam_dgaz_ToplamTonaj = "";
                        kayit.Toplam_dgaz_Toplamkireç = "";
                    }

                    kayitlar.Add(kayit);
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;
        }
        public List<Performans_raporu> performans_raporu_select3(int tarih = 0, int secilen_vrd = 0)
        {
            List<Performans_raporu> kayitlar = new List<Performans_raporu>();
            this.sql = "SELECT COUNT(DNO),ROUND(AVG(SARJ_SAYISI),0),ROUND(AVG(TOPLAM_SARJ),0), " +
                       "ROUND(AVG(ENERJILI_SURE),2),ROUND(AVG(ENERJISIZ_SURE),2),ROUND(AVG(TOPLAM_SURE),2),ROUND(AVG(DEVIRME_SICAKLIK),2), " +
                       "ROUND(AVG(PO_GIRIS_SICAKLIK),2),ROUND(AVG(AO_ENERJI),2),ROUND(AVG(PO_ENERJI),2),ROUND(AVG(ENJEKTE_KOK_ELTI),2),ROUND(AVG(ENJEKTE_KIREC),2),ROUND(AVG(PARCA_KIREC),2), " +
                       "ROUND(AVG(TOPLAM_KIREC),2),ROUND(AVG(KUTUK_TONAJI),2),MAX(TANDIS_BINDIRME_SAYISI),MAX(CANAK_DOKUM_SAYISI), " +
                       "MAX(KAPAK_DOKUM_SAYISI),MAX(YUREK_DOKUM_SAYISI),ROUND(AVG(AO_TIRNAK_KAPATMA_ENERJISI),2),ROUND(AVG(BRL_DGAZ),2),ROUND(AVG(RCB_BRL_DGAZ),2), " +
                       "ROUND(AVG(PC_DGAZ),2),ROUND(AVG(TOPLAM_GAZ),2),SUM(KUTUK_TONAJI), " +
                       "ROUND((AVG(AO_ENERJI)/AVG(KUTUK_TONAJI)),3),ROUND((AVG(PO_ENERJI)/AVG(KUTUK_TONAJI)),3)" +
                       "FROM URTHRK.CH_DOKUMNO_PERFORMANS ";

            if (tarih > 0)
            {
                this.sql += "WHERE DOKUMTAR = " + tarih + " AND KUTUK_TONAJI> 0 ";
            }
            if (secilen_vrd != 0)
            {
                this.sql += " AND VRD=" + secilen_vrd + "";
            }
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Performans_raporu kayit = new Performans_raporu();
                kayit.Vrd = "Listelenecek Kayıt Bulunamadı !!";
                kayit.Id = 0;
                kayitlar.Add(kayit);
            }
            else
            {
                while (this.dr.Read())
                {
                    Performans_raporu kayit = new Performans_raporu();
                    kayit.Id = 1;
                    kayit.Dokum_no = Convert.ToInt32(this.dr[0].ToString());
                    kayit.Srj = (dr[1].ToString());
                    kayit.Toplam_srj = (dr[2].ToString());
                    kayit.Enerjili_sure = this.dr[3].ToString();
                    kayit.Enerjisiz_sure = this.dr[4].ToString();
                    kayit.Toplam_sure = this.dr[5].ToString();
                    kayit.Devirme_sicaklik = this.dr[6].ToString();
                    kayit.Po_giris_sicakligi = this.dr[7].ToString();
                    kayit.Ao_enerji = Convert.ToDouble(this.dr[25].ToString().Equals("") ? "0.0" : this.dr[25].ToString()).ToString("0.##");
                    //kayit.Po_enerji = Convert.ToDouble(this.dr[26]).ToString("0.##");
                    kayit.Po_enerji = Convert.ToDouble(this.dr[26].ToString().Equals("") ? "0.0" : this.dr[26].ToString()).ToString("0.##");
                    //kayit.Ao_enerji = this.dr[25].ToString();
                    kayit.Enj_Kok_elt = this.dr[10].ToString();
                    kayit.Enj_kırec = this.dr[11].ToString();
                    kayit.Parca_kırec = this.dr[12].ToString();
                    kayit.Toplam_kirec = Convert.ToDouble(this.dr[13].ToString().Equals("") ? "0.0" : this.dr[13].ToString());
                    kayit.Kutuk_tonaji = Convert.ToDouble(this.dr[14].ToString().Equals("") ? "0.0" : this.dr[14].ToString());
                    kayit.Tandis_bnd_sayisi = this.dr[15].ToString();
                    kayit.Canak_dokum_say = this.dr[16].ToString();
                    kayit.Kapak_dokum_say = this.dr[17].ToString();
                    kayit.Yurek_dokum_say = this.dr[18].ToString();
                    kayit.Ao_trnk_kapatma_enerjisi = (dr[19].ToString());
                    kayit.Brl_dgaz = this.dr[20].ToString();
                    kayit.Rcb_brl_dgaz = this.dr[21].ToString();
                    kayit.Pc_dgaz = this.dr[22].ToString();
                    kayit.Toplam_dgaz = this.dr[23].ToString();
                    // kayit.Toplam_tonaj = this.dr[24].ToString();
                    kayitlar.Add(kayit);
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;
        }

        public List<Performans_raporu> performans_raporu_select4(int tarih = 0, int secilen_vrd = 0)
        {

            List<Performans_raporu> kayitlar = new List<Performans_raporu>();
            this.sql = "SELECT distinct(KALITE), boy, ebat,SUM(STDKTKTON)+SUM(STNKARTON),SUM(STDKTKSAY),COUNT(DNO) " +
                      "FROM URTHRK.CH_DOKUMNO_URETIM " +
                      "WHERE ";
            if (tarih > 0)
            {
                this.sql += "  DOKUMTAR = " + tarih + "";

            }
            if (secilen_vrd != 0)
            {
                this.sql += " AND VRD=" + secilen_vrd + "";
            }
            this.sql += "GROUP BY BOY,KALITE,EBAT ORDER BY SUM(STDKTKSAY) DESC";

            this.cmd.CommandText = this.sql;
            this.cmd.Parameters.Clear();
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Performans_raporu kayit = new Performans_raporu();
                kayit.Aciklama = "Listelenecek Kayıt Bulunamadı !!";
                kayit.Id = 0;
                kayitlar.Add(kayit);
            }
            else
            {
                while (this.dr.Read())
                {
                    Performans_raporu kayit = new Performans_raporu();
                    kayit.Id = 1;
                    kayit.Celik_cinsi = this.dr[0].ToString();
                    kayit.Boy = this.dr[1].ToString();
                    kayit.Ebat = this.dr[2].ToString();
                    if (this.dr[3].ToString() != "")
                    {
                        kayit.Toplam_tonaj = Convert.ToDouble(this.dr[3]).ToString("0.##");
                    }
                    kayit.Kutuk_sayisi = this.dr[4].ToString();
                    kayit.Dokum_sayisi = this.dr[5].ToString();
                    kayitlar.Add(kayit);
                }

            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;

        }

        public List<Performans_raporu> performans_raporu_select5(int tarih = 0, int secilen_vrd = 0)
        {

            List<Performans_raporu> kayitlar = new List<Performans_raporu>();
            this.sql = "SELECT COUNT(DNO), SUM(STDKTKTON)+SUM(STNKARTON) " +
                       "FROM URTHRK.CH_DOKUMNO_URETIM " +
                       "WHERE ";
            if (tarih > 0)
            {
                this.sql += "  DOKUMTAR = " + tarih + "";
            }
            if (secilen_vrd != 0)
            {
                this.sql += " AND VRD=" + secilen_vrd + "";
            }
            this.cmd.CommandText = this.sql;
            this.cmd.Parameters.Clear();
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Performans_raporu kayit = new Performans_raporu();
                kayit.Aciklama = "Listelenecek Kayıt Bulunamadı !!";
                kayit.Id = 0;
                kayitlar.Add(kayit);
            }
            else
            {
                while (this.dr.Read())
                {
                    Performans_raporu kayit = new Performans_raporu();
                    kayit.Id = 1;
                    kayit.Dokum_sayisi = this.dr[0].ToString();
                    if (this.dr[1].ToString() != "")
                    {
                        kayit.Toplam_tonaj = Convert.ToDouble(this.dr[1]).ToString("0.##");
                    }
                    kayitlar.Add(kayit);
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;


        }
        public List<Performans_raporu> performans_raporu_select6(int tarih = 0, int secilen_vrd = 0)   //verim
        {

            List<Performans_raporu> kayitlar = new List<Performans_raporu>();
            this.sql = "SELECT SUM(AO_ENERJI), SUM(PO_ENERJI),SUM(TOPLAM_SARJ),SUM(KUTUK_TONAJI), ROUND(SUM(AO_ENERJI)/SUM(KUTUK_TONAJI),3), " +
                " ROUND(SUM(PO_ENERJI)/SUM(KUTUK_TONAJI),3), ROUND((SUM(KUTUK_TONAJI)/SUM(TOPLAM_SARJ)*100000),1)" +
                       " FROM URTHRK.CH_DOKUMNO_PERFORMANS " +
                       "WHERE ";
            if (tarih > 0)
            {
                this.sql += "  DOKUMTAR = " + tarih + "  AND KUTUK_TONAJI> 0 ";
            }
            if (secilen_vrd != 0)
            {
                this.sql += " AND VRD=" + secilen_vrd + "";
            }

            this.cmd.CommandText = this.sql;
            this.cmd.Parameters.Clear();
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Performans_raporu kayit = new Performans_raporu();
                kayit.Aciklama = "Listelenecek Kayıt Bulunamadı !!";
                kayit.Id = 0;
                kayitlar.Add(kayit);
            }
            else
            {
                while (this.dr.Read())
                {
                    Performans_raporu kayit = new Performans_raporu();
                    kayit.Id = 1;

                    kayit.Toplam_srj = this.dr[2].ToString();
                    //kayit.Toplam_tonaj = this.dr[3].ToString();
                    kayit.Toplam_tonaj = Convert.ToDouble(this.dr[3].ToString().Equals("") ? "0.0" : this.dr[3].ToString()).ToString("0.##");                
                    kayit.Verim = this.dr[6].ToString();

                    kayitlar.Add(kayit);
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;


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
