using diler.Entity;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace diler.Dal
{
    public class Kimya_raporu_database
    {

        OracleConnection conn;
        OracleConnection conn2;
        string connetionString;
        string sql;
        OracleCommand cmd;
        OracleDataReader dr, dr2, dr3;

        public Kimya_raporu_database()
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

        public List<Analizler> kimya_read(int tarih = 0)
        {
            return kimya_geneltakip_sol(tarih); 

        }
        public List<Analizler> kimya_read2(int tarih = 0)
        {
            return kimya_geneltakip_sag(tarih);

        }
        public List<Analizler> kimya_read3(int tarih = 0)
        {
            return kimya_geneltakip_ozet(tarih);

        }

        public List<Analizler> kimya_geneltakip_sol(int tarih = 0)
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
        public List<Analizler> kimya_geneltakip_sag(int tarih = 0)
        {
            List<Analizler> kayitlar = new List<Analizler>();
            this.sql = "SELECT * " +
                      "FROM URTHRK.CH_DOKUMNO_URETIM_GENELTAKIP ";
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
                    kayit.Dokum_no = this.dr[1].ToString();
                    kayit.Sirano = this.dr[2].ToString();
                    kayit.Vardiya = this.dr[3].ToString();
                    kayit.Celik_cinsi = this.dr[4].ToString();
                    kayit.KS1 = this.dr[5].ToString();
                    kayit.KS2 = this.dr[6].ToString();
                    kayit.Ebat = this.dr[7].ToString();
                    kayit.Boy = this.dr[8].ToString();
                    kayit.Radyasyon = this.dr[9].ToString();
                    kayit.Uretimdensapma_element = this.dr[10].ToString();
                    kayit.Standart_disi_element = this.dr[11].ToString();
                    kayit.Aciklama = this.dr[12].ToString();
                    kayit.Tandis_bindirme_sayisi = this.dr[13].ToString();
                    kayit.Tandis_no = this.dr[14].ToString();
                    kayit.Tandis_no_bindirme_sayisi = kayit.Tandis_no + "/" + kayit.Tandis_bindirme_sayisi;
                    //kayit.Dokum_tarihi = Convert.ToInt32(this.dr["DOKUMTAR"].ToString().Equals("") ? "0" : this.dr["DOKUMTAR"].ToString());
                    kayitlar.Add(kayit);

                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;
        }
        public List<Analizler> kimya_geneltakip_ozet(int tarih = 0)
        {
            List<Analizler> kayitlar = new List<Analizler>();
            this.sql = "SELECT distinct(KALITE), SUM(STDKTKSAY), EBAT, BOY,SUM(STDKTKTON) + SUM(STNKARTON),SUM(STNKARSAY) " +
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
                Analizler analiz = new Analizler();

                while (this.dr.Read())
                {
                    Analizler kayit = new Analizler();
                    kayit.Analiz_id = 1;
                    kayit.Celik_cinsi = this.dr[0].ToString();
                    kayit.Ebat = this.dr[2].ToString();
                    kayit.Boy = this.dr[3].ToString();
                    //kayit.Kutuk_sayisi = this.dr[1].ToString();
                    kayit.Tonaj = this.dr[4].ToString();
                    kayit.Kutuk_sayisi = (Convert.ToDouble(this.dr[1].ToString().Equals("") ? "0.0" : this.dr[1].ToString())
                     + Convert.ToDouble(this.dr[5].ToString().Equals("") ? "0.0" : this.dr[5].ToString())).ToString();
                    //kayit.Dokum_tarihi = Convert.ToInt32(this.dr["DOKUMTAR"].ToString().Equals("") ? "0" : this.dr["DOKUMTAR"].ToString());
                    kayitlar.Add(kayit);

                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;
        }



        /***********************************/
        // İki Tatih arası

        public List<Analizler> uretim_ozet_read(int tarih = 0, int tarih2 = 0)
        {
            return uretim_ozet_select(tarih, tarih2);

        }
        public List<Analizler> uretim_ozet_select(int tarih = 0, int tarih2 = 0)
        {
            List<Analizler> kayitlar = new List<Analizler>();

            this.sql = "SELECT distinct(KALITE), boy, ebat,SUM(STDKTKTON)+ SUM(STNKARTON),SUM(STDKTKSAY),COUNT(DNO),SUM(STNKARSAY) " +
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
                    if (this.dr[3].ToString() != "")
                    {
                        kayit.Tonaj = Convert.ToDouble(this.dr[3]).ToString();
                    }
                    //kayit.Tonaj = this.dr[3].ToString();
                    ///kayit.Kutuk_sayisi = this.dr[4].ToString();
                    ///
                    string sqlx = "SELECT distinct(KALITE), boy, ebat,SUM(STDKTKTON)+ SUM(STNKARTON),SUM(STDKTKSAY),COUNT(DNO) " +
                     "FROM URTHRK.CH_DOKUMNO_URETIM " +
                       "WHERE ";
                    if (tarih > 0 && tarih2 > 0)
                    {
                        sqlx += "  DOKUMTAR >= " + tarih +
                                 " AND DOKUMTAR <= " + tarih2 + " AND DSNO=1  AND KALITE='" + kayit.Celik_cinsi + "' GROUP BY BOY,KALITE,EBAT ORDER BY SUM(STDKTKSAY) DESC";
                    }
                    this.cmd.CommandText = sqlx;
                    this.cmd.Parameters.Clear();
                    this.dr2 = this.cmd.ExecuteReader();
                    while (this.dr2.Read())
                    {
                        kayit.Dokum_sayisi = this.dr2[5].ToString();

                    }

                    // kayit.Dokum_sayisi = this.dr[5].ToString();
                    // kayit.Karisim_sayisi = this.dr[6].ToString();
                    kayit.Kutuk_sayisi = (Convert.ToDouble(this.dr[4].ToString().Equals("") ? "0.0" : this.dr[4].ToString())
                        + Convert.ToDouble(this.dr[6].ToString().Equals("") ? "0.0" : this.dr[6].ToString())).ToString();

                    kayitlar.Add(kayit);
                }

            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;
        }

        //**

        public List<Analizler> filmasin_ozet_read(int tarih = 0, int tarih2 = 0)
        {
            return filmasin_ozet_select(tarih, tarih2);

        }
        public List<Analizler> filmasin_ozet_select(int tarih = 0, int tarih2 = 0)
        {
            List<Analizler> kayitlar = new List<Analizler>();

            this.sql = "SELECT distinct(KALITE), boy, ebat,SUM(STDKTKTON)+ SUM(STNKARTON),SUM(STDKTKSAY),COUNT(DNO),SUM(STNKARSAY) " +
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
                    if (this.dr[3].ToString() != "")
                    {
                        kayit.Tonaj = Convert.ToDouble(this.dr[3]).ToString();
                    }
                    // kayit.Tonaj = this.dr[3].ToString();
                    string sqlx = "SELECT distinct(KALITE), boy, ebat,SUM(STDKTKTON)+ SUM(STNKARTON),SUM(STDKTKSAY),COUNT(DNO) " +
                    "FROM URTHRK.CH_DOKUMNO_URETIM " +
                   "WHERE ";
                    if (tarih > 0 && tarih2 > 0)
                    {
                        sqlx += "  DOKUMTAR >= " + tarih +
                                " AND DOKUMTAR <= " + tarih2 + " AND DSNO=1  AND KALITE='" + kayit.Celik_cinsi + "' " +
                                " AND GIDECEGIYER='Filmaşin' GROUP BY BOY,KALITE,EBAT ORDER BY SUM(STDKTKSAY) DESC";
                    }
                    this.cmd.CommandText = sqlx;
                    this.cmd.Parameters.Clear();
                    this.dr2 = this.cmd.ExecuteReader();
                    while (this.dr2.Read())
                    {
                        kayit.Dokum_sayisi = this.dr2[5].ToString();

                    }

                    kayit.Kutuk_sayisi = (Convert.ToDouble(this.dr[4].ToString().Equals("") ? "0.0" : this.dr[4].ToString())
                    + Convert.ToDouble(this.dr[6].ToString().Equals("") ? "0.0" : this.dr[6].ToString())).ToString();

                    // kayit.Kutuk_sayisi = this.dr[4].ToString();
                    // kayit.Dokum_sayisi = this.dr[5].ToString();
                    kayitlar.Add(kayit);
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;
        }

        //**

        public List<Analizler> uretimdensapma_ozet_read(int tarih = 0, int tarih2 = 0)
        {
            return uretimdensapma_ozet_select(tarih, tarih2);

        }
        public List<Analizler> uretimdensapma_ozet_select(int tarih = 0, int tarih2 = 0)
        {
            List<Analizler> kayitlar = new List<Analizler>();

            this.sql = "SELECT SAPMA_NEDENI, SAPMA_ELEMENT, SUM(STDKTKTON),COUNT(DNO) " +
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
                    kayit.Tonaj = this.dr[2].ToString();
                    kayit.Dokum_sayisi = this.dr[3].ToString();
                    kayitlar.Add(kayit);
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;
        }

        //**
        public List<Analizler> uretim_std_disi_ozet_read(int tarih = 0, int tarih2 = 0)
        {
            return uretim_std_disi_ozet_select(tarih, tarih2);

        }
        public List<Analizler> uretim_std_disi_ozet_select(int tarih = 0, int tarih2 = 0)
        {
            List<Analizler> kayitlar = new List<Analizler>();
            this.sql = "SELECT STD_ELEMENT, STD_NEDEN, COUNT(DNO), SUM(STDKTKTON) " +
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
                    kayit.Tonaj = this.dr[3].ToString();
                    kayitlar.Add(kayit);
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;
        }

        //**

        public List<Analizler> toplam_uretim(int tarih = 0, int tarih2 = 0)
        {
            return toplam_uretim_select(tarih, tarih2);

        }
        public List<Analizler> toplam_uretim_select(int tarih = 0, int tarih2 = 0)
        {
            List<Analizler> kayitlar = new List<Analizler>();
            this.sql = "SELECT SUM(STDKTKTON) + SUM(STNKARTON),SUM(STDKTKSAY), SUM(STNKARSAY) " +
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
                    if (this.dr[0].ToString() != "")
                    {
                        kayit.Tonaj = Convert.ToDouble(this.dr[0]).ToString();

                    }

                    kayitlar.Add(kayit);
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;
        }

        //**

        public List<Analizler> toplam_uretim_filmasin(int tarih = 0, int tarih2 = 0)
        {
            return toplam_uretim_filmasin_select(tarih, tarih2);

        }
        public List<Analizler> toplam_uretim_filmasin_select(int tarih = 0, int tarih2 = 0)
        {
            List<Analizler> kayitlar = new List<Analizler>();
            this.sql = "SELECT SUM(STDKTKTON) + SUM(STNKARTON),SUM(STDKTKSAY), SUM(STNKARSAY) " +
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


                    if (this.dr[0].ToString() != "")
                    {
                        kayit.Tonaj = Convert.ToDouble(this.dr[0]).ToString();
                    }
                    //kayit.Tonaj = this.dr[0].ToString();
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
        public void Disconnect()
        {
            if (this.conn.State == System.Data.ConnectionState.Open)
            {
                this.conn.Close();
            }
        }


    }
}
