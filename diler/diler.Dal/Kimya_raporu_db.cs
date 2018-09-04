using diler.Entity;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace diler.Dal
{
    public class Kimya_raporu_db
    {

        OracleConnection conn, conn2;
        string connetionString, sql;
        OracleCommand cmd;
        OracleDataReader dr, dr2;

        public Kimya_raporu_db()
        {
            this.connetionString = @"Data Source=(DESCRIPTION=" +
                "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.198.191)(PORT=1521)))" +
                "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=DLRORA)));" +
                 "User Id=URTHRK; Password=URTHRK;";
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

        public List<Analizler> kimya_geneltakip_sol_data_read(int tarih = 0)
        {
            List<Analizler> kayitlar = new List<Analizler>();
            this.sql = "SELECT * " +
                       "FROM URTHRK.CH_DOKUMNO_GENELTAKIP_ANALIZ KA ";
            if (tarih > 0)
            {
                this.sql += "WHERE KA.DOKUMTAR = " + tarih + " ORDER BY DNO ASC";
            }
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Analizler kayit = new Analizler();
                kayit.B = "Listelenecek Kayıt Bulunamadı !!";
                kayit.Analiz_id = 0;
                kayitlar.Add(kayit);
            }
            else
            {

                while (this.dr.Read())
                {
                    Analizler kayit = new Analizler();
                    kayit.Uretimdensapma_element = this.dr[3].ToString();
                    if (kayit.Uretimdensapma_element != "")
                    {
                        kayit.Analiz_id = 2;
                    }

                    if (kayit.Uretimdensapma_element == "")
                    {
                        kayit.Analiz_id = 1;
                    }
                    kayit.Dokum_no = this.dr[1].ToString();
                    kayit.Celik_cinsi = this.dr[2].ToString();
                    kayit.C = this.dr[5].ToString();
                    kayit.Si = this.dr[6].ToString();
                    kayit.S = this.dr[7].ToString();
                    kayit.P = this.dr[8].ToString();
                    kayit.Mn = this.dr[9].ToString();
                    kayit.Ni = this.dr[10].ToString();
                    kayit.Cr = this.dr[11].ToString();
                    kayit.Cu = this.dr[12].ToString();
                    kayit.Mo = this.dr[13].ToString();
                    kayit.Sn = this.dr[14].ToString();
                    kayit.V = this.dr[15].ToString();
                    kayit.N = this.dr[16].ToString();
                    kayit.Ceg = this.dr[17].ToString();
                    kayit.B = this.dr[18].ToString();
                    kayit.Ca = this.dr[19].ToString();
                    kayit.Ti = this.dr[20].ToString();
                    kayit.Al = this.dr[21].ToString();
                    kayit.Pb = this.dr[22].ToString();
                    kayit.Nb = this.dr[23].ToString();
                    kayitlar.Add(kayit);
                }

            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;

        }
        public List<Analizler> kimya_geneltakip_sag_data_read(int tarih = 0)
        {
            List<Analizler> kayitlar = new List<Analizler>();
            this.sql = "SELECT * " +
                      "FROM URTHRK.CH_DOKUMNO_URETIM ";
            if (tarih > 0)
            {
                this.sql += "WHERE DOKUMTAR = " + tarih;
            }
            this.sql += " ORDER BY DNO ASC";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Analizler kayit = new Analizler();
                kayit.Aciklama = "Listelenecek Kayıt Bulunamadı !!";
                kayit.Analiz_id = 0;
                kayitlar.Add(kayit);
            }
            else
            {
                while (this.dr.Read())
                {

                    Analizler kayit = new Analizler();
                    kayit.Analiz_id = 1;
                    kayit.Dokum_no = this.dr["DNO"].ToString();
                    kayit.Sirano = this.dr["DSNO"].ToString();
                    kayit.Vardiya = this.dr["VRD"].ToString();
                    kayit.Celik_cinsi = this.dr["KALITE"].ToString();
                    kayit.KS1 = this.dr["STDKTKSAY"].ToString();
                    kayit.KS2 = this.dr["STNKARSAY"].ToString();
                    kayit.Ebat = this.dr["EBAT"].ToString();
                    kayit.Boy = this.dr["BOY"].ToString();
                    kayit.Radyasyon = this.dr["RADYOAKTIVITE"].ToString();
                    kayit.Uretimdensapma_element = this.dr["SAPMA_ELEMENT"].ToString();
                    kayit.Standart_disi_element = this.dr["STD_ELEMENT"].ToString();
                    kayit.Siparis_no = this.dr["SIPNUM"].ToString();
                    kayit.Aciklama = this.dr["KTKACIKLAMA"].ToString();             
                    kayit.Tandis_no_bindirme_sayisi = this.dr["TANDIS_BINDIRME"].ToString(); 
                    //kayit.Dokum_tarihi = Convert.ToInt32(this.dr["DOKUMTAR"].ToString().Equals("") ? "0" : this.dr["DOKUMTAR"].ToString());
                    kayitlar.Add(kayit);

                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;

        }
        public List<Analizler> kimya_geneltakip_ozet_data_read(int tarih = 0)
        {
            List<Analizler> kayitlar = new List<Analizler>();
            this.sql = "SELECT distinct(KALITE), SUM(STDKTKSAY), EBAT, BOY,SUM(STDKTKTON),SUM(STNKARTON),SUM(STNKARSAY) " +
                        "FROM URTHRK.CH_DOKUMNO_URETIM  ";
            if (tarih > 0)
            {
                this.sql += "WHERE DOKUMTAR = " + tarih;
            }
            this.sql += " GROUP BY BOY,KALITE,EBAT ORDER BY SUM(STDKTKSAY) DESC";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Analizler analiz = new Analizler();
                analiz.B = "Listelenecek Kayıt Bulunamadı !!";
                analiz.Analiz_id = 0;
                kayitlar.Add(analiz);
            }
            else
            {

                while (this.dr.Read())
                {
                    Analizler kayit = new Analizler();
                    kayit.Analiz_id = 1;
                    kayit.Celik_cinsi = this.dr[0].ToString();
                    kayit.Ebat = this.dr[2].ToString();
                    kayit.Boy = this.dr[3].ToString();
                    kayit.Tonaj = (Convert.ToDouble(this.dr[4].ToString().Equals("") ? "0.0" : this.dr[4].ToString()) +
                     Convert.ToDouble(this.dr[5].ToString().Equals("") ? "0.0" : this.dr[5].ToString())).ToString("0.###");
                    kayit.Kutuk_sayisi = (Convert.ToDouble(this.dr[1].ToString().Equals("") ? "0.0" : this.dr[1].ToString())
                     + Convert.ToDouble(this.dr[6].ToString().Equals("") ? "0.0" : this.dr[6].ToString())).ToString();
                    //kayit.Dokum_tarihi = Convert.ToInt32(this.dr["DOKUMTAR"].ToString().Equals("") ? "0" : this.dr["DOKUMTAR"].ToString());
                    kayitlar.Add(kayit);

                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;
        }
        public List<Analizler> kimya_analiz_ortalama_listesi_data_read(int tarih = 0)
        {
            List<Analizler> kayitlar = new List<Analizler>();
            this.sql = "SELECT KALITE FROM URTHRK.CH_DOKUMNO_GENELTAKIP_ANALIZ WHERE DOKUMTAR=" + tarih + " GROUP BY KALITE ";
            this.cmd.CommandText = this.sql;
            this.cmd.Parameters.Clear();
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Analizler kayit = new Analizler();
                kayit.Aciklama = "Listelenecek Kayıt Bulunamadı !!";
                kayit.Analiz_id = 0;
                kayitlar.Add(kayit);
            }
            else
            {
                while (this.dr.Read())
                {
                    Analizler kayit = new Analizler();
                    kayit.Analiz_id = 1;
                    kayit.Celik_cinsi = this.dr[0].ToString();
                    if (kayit.Celik_cinsi != "")
                    {

                        string sqlx = "SELECT ROUND(AVG(cast(replace(C,'.', ',') AS decimal(9,5))),4)," +
                            "ROUND(AVG(cast(replace(SI,'.', ',') AS decimal(9,5))),4),ROUND(AVG(cast(replace(Mn,'.', ',') AS decimal(9,5))),2), " +
                           " ROUND(AVG(cast(replace(V,'.', ',') AS decimal(9,5))),4),ROUND(AVG(cast(replace(Nb,'.', ',') AS decimal(9, 5))),4), " +
                           " ROUND(AVG(cast(replace(Ca,'.', ',') AS decimal(9,5))),4)" +
                           " FROM urthrk.CH_DOKUMNO_GENELTAKIP_ANALIZ  WHERE" +
                           " KALITE='" + kayit.Celik_cinsi + "' AND DOKUMTAR=" + tarih + " ";
                        this.cmd.CommandText = sqlx;
                        this.cmd.Parameters.Clear();
                        this.dr2 = this.cmd.ExecuteReader();
                        while (this.dr2.Read())
                        {
                            Analizler kayitx = new Analizler();
                            kayitx.Analiz_id = 1;
                            kayitx.Celik_cinsi = kayit.Celik_cinsi;
                            kayitx.C = this.dr2[0].ToString();
                            kayitx.Si = this.dr2[1].ToString();
                            kayitx.Mn = this.dr2[2].ToString();
                            kayitx.V = this.dr2[3].ToString();
                            kayitx.Nb = this.dr2[4].ToString();
                            kayitx.Ca = this.dr2[5].ToString();
                            kayitlar.Add(kayitx);
                        }
                    }
                }

            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;

        }


        /***********************************/
        // İki Tarih arası

        public List<Analizler> uretim_ozet_read(int tarih = 0, int tarih2 = 0)
        {
            List<Analizler> kayitlar = new List<Analizler>();

            this.sql = "SELECT distinct(KALITE), boy, ebat,SUM(STDKTKTON),SUM(STDKTKSAY),COUNT(DNO),SUM(STNKARSAY),SUM(STNKARTON) " +
            "FROM URTHRK.CH_DOKUMNO_URETIM " +
            "WHERE ";
            if (tarih > 0 && tarih2 > 0)
            {
                this.sql += "  DOKUMTAR >= " + tarih +
                        " AND DOKUMTAR <= " + tarih2 + "  GROUP BY BOY,KALITE,EBAT ORDER BY SUM(STDKTKSAY) DESC";
            }
            this.cmd.CommandText = this.sql;
            this.cmd.Parameters.Clear();
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Analizler kayit = new Analizler();
                kayit.Aciklama = "Listelenecek Kayıt Bulunamadı !!";
                kayit.Analiz_id = 0;
                kayitlar.Add(kayit);
            }
            else
            {
                while (this.dr.Read())
                {
                    Analizler kayit = new Analizler();
                    kayit.Analiz_id = 1;
                    kayit.Celik_cinsi = this.dr[0].ToString();
                    kayit.Boy = this.dr[1].ToString();
                    kayit.Ebat = this.dr[2].ToString();
                    kayit.Tonaj = (Convert.ToDouble(this.dr[3].ToString().Equals("") ? "0.0" : this.dr[3].ToString()) +
                        Convert.ToDouble(this.dr[7].ToString().Equals("") ? "0.0" : this.dr[7].ToString())).ToString("0.###");

                    string sqlx = "SELECT COUNT(DNO) " +
                       "FROM URTHRK.CH_DOKUMNO_URETIM " +
                         "WHERE ";
                    if (tarih > 0 && tarih2 > 0)
                    {
                        sqlx += "  DOKUMTAR >= " + tarih +
                                 " AND DOKUMTAR <= " + tarih2 + "AND KALITE='" + kayit.Celik_cinsi + "' AND BOY='" + kayit.Boy + "' AND EBAT='" + kayit.Ebat + "'" +
                                 " GROUP BY BOY,KALITE,EBAT ORDER BY SUM(STDKTKSAY) DESC";
                    }
                    this.cmd.CommandText = sqlx;
                    this.cmd.Parameters.Clear();
                    this.dr2 = this.cmd.ExecuteReader();
                    while (this.dr2.Read())
                    {
                        kayit.Dokum_sayisi = this.dr2[0].ToString();

                    }
                    kayit.Kutuk_sayisi = (Convert.ToDouble(this.dr[4].ToString().Equals("") ? "0.0" : this.dr[4].ToString())
                        + Convert.ToDouble(this.dr[6].ToString().Equals("") ? "0.0" : this.dr[6].ToString())).ToString();
                    kayitlar.Add(kayit);
                }

            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;

        }

        public List<Analizler> filmasin_ozet_read(int tarih = 0, int tarih2 = 0)
        {
            List<Analizler> kayitlar = new List<Analizler>();

            this.sql = "SELECT distinct(KALITE), boy, ebat,SUM(STDKTKTON),SUM(STDKTKSAY),COUNT(DNO),SUM(STNKARSAY),SUM(STNKARTON) " +
            "FROM URTHRK.CH_DOKUMNO_URETIM " +
            "WHERE ";
            if (tarih > 0 && tarih2 > 0)
            {
                this.sql += "  DOKUMTAR >= " + tarih +
                        " AND DOKUMTAR <= " + tarih2 + "  AND GIDECEGIYER='Filmaşin'  GROUP BY BOY,KALITE,EBAT ORDER BY SUM(STDKTKSAY) DESC";
            }
            this.cmd.CommandText = this.sql;
            this.cmd.Parameters.Clear();
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Analizler kayit = new Analizler();
                kayit.Aciklama = "Listelenecek Kayıt Bulunamadı !!";
                kayit.Analiz_id = 0;
                kayitlar.Add(kayit);
            }
            else
            {
                while (this.dr.Read())
                {
                    Analizler kayit = new Analizler();
                    kayit.Analiz_id = 1;
                    kayit.Celik_cinsi = this.dr[0].ToString();
                    kayit.Boy = this.dr[1].ToString();
                    kayit.Ebat = this.dr[2].ToString();
                    kayit.Tonaj = (Convert.ToDouble(this.dr[3].ToString().Equals("") ? "0.0" : this.dr[3].ToString()) +
                         Convert.ToDouble(this.dr[7].ToString().Equals("") ? "0.0" : this.dr[7].ToString())).ToString("0.###");


                    string sqlx = "SELECT COUNT(DNO) " +
                    "FROM URTHRK.CH_DOKUMNO_URETIM " +
                   "WHERE ";
                    if (tarih > 0 && tarih2 > 0)
                    {
                        sqlx += "  DOKUMTAR >= " + tarih +
                                " AND DOKUMTAR <= " + tarih2 + " AND KALITE='" + kayit.Celik_cinsi + "' AND BOY='" + kayit.Boy + "' AND EBAT='" + kayit.Ebat + "'" +
                                " AND GIDECEGIYER='Filmaşin'  GROUP BY BOY,KALITE,EBAT ORDER BY SUM(STDKTKSAY) DESC";
                    }
                    this.cmd.CommandText = sqlx;
                    this.cmd.Parameters.Clear();
                    this.dr2 = this.cmd.ExecuteReader();
                    while (this.dr2.Read())
                    {
                        kayit.Dokum_sayisi = this.dr2[0].ToString();

                    }

                    kayit.Kutuk_sayisi = (Convert.ToDouble(this.dr[4].ToString().Equals("") ? "0.0" : this.dr[4].ToString())
                    + Convert.ToDouble(this.dr[6].ToString().Equals("") ? "0.0" : this.dr[6].ToString())).ToString();

                    kayitlar.Add(kayit);
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;

        }

        public List<Analizler> uretimdensapma_ozet_read(int tarih = 0, int tarih2 = 0)
        {
            List<Analizler> kayitlar = new List<Analizler>();

            this.sql = "SELECT SAPMA_NEDENI, SAPMA_ELEMENT, SUM(STDKTKTON),COUNT(DNO),SUM(STNKARTON) " +
           "FROM URTHRK.CH_DOKUMNO_URETIM " +
           "WHERE ";
            if (tarih > 0 && tarih2 > 0)
            {
                this.sql += "  DOKUMTAR >= " + tarih +
                        " AND DOKUMTAR <= " + tarih2 + "  GROUP BY SAPMA_NEDENI, SAPMA_ELEMENT";
            }

            this.cmd.CommandText = this.sql;
            this.cmd.Parameters.Clear();
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Analizler kayit = new Analizler();
                kayit.Aciklama = "Listelenecek Kayıt Bulunamadı !!";
                kayit.Analiz_id = 0;
                kayitlar.Add(kayit);
            }
            else
            {
                while (this.dr.Read())
                {
                    Analizler kayit = new Analizler();
                    kayit.Analiz_id = 1;
                    kayit.Uretimdensapma_element = this.dr[1].ToString();
                    kayit.Uretimdensapma_nedeni = this.dr[0].ToString();
                    kayit.Tonaj = (Convert.ToDouble(this.dr[2].ToString().Equals("") ? "0.0" : this.dr[2].ToString()) +
                     Convert.ToDouble(this.dr[4].ToString().Equals("") ? "0.0" : this.dr[4].ToString())).ToString("0.###");
                    string sqlx = "SELECT COUNT(DNO) " +
                 "FROM URTHRK.CH_DOKUMNO_URETIM " +
                   "WHERE ";
                    if (tarih > 0 && tarih2 > 0)
                    {
                        sqlx += "  DOKUMTAR >= " + tarih +
                                 " AND DOKUMTAR <= " + tarih2 + " AND DSNO=1  AND SAPMA_ELEMENT='" + kayit.Uretimdensapma_element + "' " +
                                 " ";
                    }
                    this.cmd.CommandText = sqlx;
                    this.cmd.Parameters.Clear();
                    this.dr2 = this.cmd.ExecuteReader();
                    while (this.dr2.Read())
                    {
                        kayit.Dokum_sayisi = this.dr2[0].ToString();

                    }
                    //kayit.Dokum_sayisi = this.dr[3].ToString();
                    kayitlar.Add(kayit);
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;

        }

        public List<Analizler> uretim_std_disi_ozet_read(int tarih = 0, int tarih2 = 0)
        {
            List<Analizler> kayitlar = new List<Analizler>();
            this.sql = "SELECT STD_ELEMENT, STD_NEDEN, COUNT(DNO), SUM(STDKTKTON),SUM(STNKARTON) " +
                       "FROM URTHRK.CH_DOKUMNO_URETIM " +
                       "WHERE ";
            if (tarih > 0 && tarih2 > 0)
            {
                this.sql += "  DOKUMTAR >= " + tarih +
                        " AND DOKUMTAR <= " + tarih2 + "  GROUP BY STD_ELEMENT, STD_NEDEN";
            }

            this.cmd.CommandText = this.sql;
            this.cmd.Parameters.Clear();
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Analizler kayit = new Analizler();
                kayit.Aciklama = "Listelenecek Kayıt Bulunamadı !!";
                kayit.Analiz_id = 0;
                kayitlar.Add(kayit);
            }
            else
            {
                while (this.dr.Read())
                {
                    Analizler kayit = new Analizler();
                    kayit.Analiz_id = 1;
                    kayit.Standart_disi_element = this.dr[0].ToString();
                    kayit.Standart_disi_neden = this.dr[1].ToString();
                    kayit.Dokum_sayisi = this.dr[2].ToString();
                    kayit.Tonaj = (Convert.ToDouble(this.dr[3].ToString().Equals("") ? "0.0" : this.dr[3].ToString()) +
                  Convert.ToDouble(this.dr[4].ToString().Equals("") ? "0.0" : this.dr[4].ToString())).ToString("0.###");
                    kayitlar.Add(kayit);
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;

        }

        public List<Analizler> toplam_uretim(int tarih = 0, int tarih2 = 0)
        {
            List<Analizler> kayitlar = new List<Analizler>();
            this.sql = "SELECT SUM(STDKTKTON),SUM(STDKTKSAY), SUM(STNKARSAY),SUM(STNKARTON) " +
                        "FROM URTHRK.CH_DOKUMNO_URETIM " +
                        "WHERE ";
            if (tarih > 0 && tarih2 > 0)
            {
                this.sql += "  DOKUMTAR >= " + tarih +
                        " AND DOKUMTAR <= " + tarih2 + " ";
            }
            this.cmd.CommandText = this.sql;
            this.cmd.Parameters.Clear();
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Analizler kayit = new Analizler();
                kayit.Aciklama = "Listelenecek Kayıt Bulunamadı !!";
                kayit.Analiz_id = 0;
                kayitlar.Add(kayit);
            }
            else
            {
                while (this.dr.Read())
                {
                    Analizler kayit = new Analizler();
                    kayit.Analiz_id = 1;
                    string sqlx = "SELECT COUNT(DNO) " +
                      "FROM URTHRK.CH_DOKUMNO_URETIM " +
                      "WHERE ";
                    if (tarih > 0 && tarih2 > 0)
                    {
                        sqlx += "  DOKUMTAR >= " + tarih +
                                " AND DOKUMTAR <= " + tarih2 + " AND DSNO=1 ";
                    }
                    this.cmd.CommandText = sqlx;
                    this.cmd.Parameters.Clear();
                    this.dr2 = this.cmd.ExecuteReader();
                    while (this.dr2.Read())
                    {
                        kayit.Dokum_sayisi = this.dr2[0].ToString();
                    }
                    kayit.Kutuk_sayisi = kayit.Kutuk_sayisi = (Convert.ToDouble(this.dr[1].ToString().Equals("") ? "0.0" : this.dr[1].ToString())
                    + Convert.ToDouble(this.dr[2].ToString().Equals("") ? "0.0" : this.dr[2].ToString())).ToString();

                    kayit.Tonaj = (Convert.ToDouble(this.dr[0].ToString().Equals("") ? "0.0" : this.dr[0].ToString()) +
                       Convert.ToDouble(this.dr[3].ToString().Equals("") ? "0.0" : this.dr[3].ToString())).ToString("0.###");

                    kayitlar.Add(kayit);
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;

        }

        public List<Analizler> toplam_uretim_filmasin(int tarih = 0, int tarih2 = 0)
        {
            List<Analizler> kayitlar = new List<Analizler>();
            this.sql = "SELECT SUM(STDKTKTON),SUM(STDKTKSAY), SUM(STNKARSAY),SUM(STNKARTON) " +
                       "FROM URTHRK.CH_DOKUMNO_URETIM " +
                       "WHERE ";
            if (tarih > 0 && tarih2 > 0)
            {
                this.sql += "  DOKUMTAR >= " + tarih +
                        " AND DOKUMTAR <= " + tarih2 + "  AND GIDECEGIYER='Filmaşin'";
            }

            this.cmd.CommandText = this.sql;
            this.cmd.Parameters.Clear();
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Analizler kayit = new Analizler();
                kayit.Aciklama = "Listelenecek Kayıt Bulunamadı !!";
                kayit.Analiz_id = 0;
                kayitlar.Add(kayit);
            }
            else
            {
                while (this.dr.Read())
                {
                    Analizler kayit = new Analizler();
                    kayit.Analiz_id = 1;

                    kayit.Tonaj = (Convert.ToDouble(this.dr[0].ToString().Equals("") ? "0.0" : this.dr[0].ToString()) +
                   Convert.ToDouble(this.dr[3].ToString().Equals("") ? "0.0" : this.dr[3].ToString())).ToString("0.###");
                    string sqlx = "SELECT COUNT(DNO) " +
                    "FROM URTHRK.CH_DOKUMNO_URETIM " +
                    "WHERE ";
                    if (tarih > 0 && tarih2 > 0)
                    {
                        sqlx += "  DOKUMTAR >= " + tarih +
                                " AND DOKUMTAR <= " + tarih2 + " AND DSNO=1 AND GIDECEGIYER='Filmaşin' ";
                    }
                    this.cmd.CommandText = sqlx;
                    this.cmd.Parameters.Clear();
                    this.dr2 = this.cmd.ExecuteReader();
                    while (this.dr2.Read())
                    {
                        kayit.Dokum_sayisi = this.dr2[0].ToString();
                    }
                    kayit.Kutuk_sayisi = kayit.Kutuk_sayisi = (Convert.ToDouble(this.dr[1].ToString().Equals("") ? "0.0" : this.dr[1].ToString())
                     + Convert.ToDouble(this.dr[2].ToString().Equals("") ? "0.0" : this.dr[2].ToString())).ToString();
                    kayitlar.Add(kayit);
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;

        }




    }
}
