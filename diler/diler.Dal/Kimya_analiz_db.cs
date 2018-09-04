using diler.Entity;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace diler.Dal
{
    public class Kimya_analiz_db
    {

        OracleConnection conn,conn2;
        string connetionString,sql;
        OracleCommand cmd;
        OracleDataReader dr, dr2;
        public string tarih_parse;

        public Kimya_analiz_db()
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

        public List<Kimya_lab_analiz> dokum_ayrinti(int dokum_no)
        {
            List<Kimya_lab_analiz> kayitlar = new List<Kimya_lab_analiz>();
            this.sql = "SELECT DISTINCT(DOKUMTAR),SUM(STDKTKSAY),SUM(STNKARSAY),KALITE,BOY,EBAT FROM CH_DOKUMNO_URETIM WHERE DNO=" + dokum_no + "   GROUP BY DOKUMTAR,KALITE,BOY,EBAT ";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Kimya_lab_analiz kayit = new Kimya_lab_analiz();
                kayit.Aciklama = "Ayrıntı Bulunamadı.";
                kayit.Analiz_id = 0;
                kayitlar.Add(kayit);
            }
            else
            {

                try
                {
                    while (this.dr.Read())
                    {
                        Kimya_lab_analiz kayit = new Kimya_lab_analiz();
                        kayit.Analiz_id = 1;

                        kayit.Dokum_no = dokum_no;

                        int tarih = Convert.ToInt32(this.dr[0].ToString());

                        tarih_parse = tarihFormat(tarih);
                        kayit.Dokum_tarihi = tarih_parse;

                        kayit.Adet = (Convert.ToDouble(this.dr[1].ToString().Equals("") ? "0.0" : this.dr[1].ToString()) +
                                       Convert.ToDouble(this.dr[2].ToString().Equals("") ? "0.0" : this.dr[2].ToString())).ToString();

                        kayit.Celik_cinsi = this.dr[3].ToString();
                        kayit.Boy = dr[4].ToString();
                        kayit.Ebat = dr[5].ToString();
                        string sqlx = "SELECT (SELECT KTKACIKLAMA FROM CH_DOKUMNO_URETIM WHERE DNO=" + dokum_no + "  AND DSNO = 1) AS A1," +
                                      "(SELECT KTKACIKLAMA FROM CH_DOKUMNO_URETIM WHERE DNO=" + dokum_no + "  AND DSNO = 2) AS A2 " +
                                      "FROM CH_DOKUMNO_URETIM WHERE ROWNUM = 1";
                        this.cmd.Parameters.Clear();
                        this.cmd.CommandText = sqlx;
                        dr2 = this.cmd.ExecuteReader();
                        while (this.dr2.Read())
                        {
                            kayit.Aciklama = this.dr2[0].ToString() + " " + this.dr2[1].ToString();
                        }


                        kayitlar.Add(kayit);
                    }
                }
                catch
                {
                    throw new System.InvalidOperationException("Bağlantı gerçekleştirilirken bir hata oluştu.Tekrar deneyiniz!");
                }
            }
            this.dr.Close();
            this.dr.Dispose();
         
            return kayitlar;
        }
        public List<Kimya_lab_analiz> kimya_lab_analiz_data_read(int bas_dokum_no = 0, int bit_dokum_no = 0)
        {
            List<Kimya_lab_analiz> kayitlar = new List<Kimya_lab_analiz>();
            this.sql = "SELECT KA.YER,KA.DNO,KA.C,KA.SI,KA.S,KA.P,KA.MN,KA.NI,KA.CR,KA.MO,KA.V,KA.CU,KA.W,KA.SN,KA.CO,KA.AL,KA.ALSOL,KA.ALINSOL,KA.PB," +
                        "KA.B,KA.BSOL,KA.BINSOL,KA.SB,KA.NB,KA.CA,KA.CASOL,KA.CAINSOL,KA.ZN,KA.N,KA.TI,KA.TISOL,KA.TIINSOL,KA.ASS,KA.ZR,KA.BI,KA.OO,KA.FE,KA.CEQ,KA.CE," +
                        "KA.CRNICUX,KA.ALCAOX,KA.AlMGOX,KA.ALSIOX,KA.ALTIOX,KA.ALCAX,KA.ALOX,KA.CAOX,KA.CASX,KA.TIOX,KA.TIALX,KA.MNSX,KA.MGOX,KA.ZROX,KA.SIOX," +
                        "KA.KTKKALITESI,KA.RADYOACTIVITE,KA.YIL " +
                       "FROM URTHRK.KIMYAANALIZ KA ";
            if (bit_dokum_no > 0)
            {
                this.sql += "WHERE KA.DNO >= " + bas_dokum_no +
                            " AND KA.DNO <= " + bit_dokum_no + ""; ;
            }
            else
            {
                this.sql += "WHERE KA.DNO=" + bas_dokum_no + "";
            }
            this.sql += "ORDER BY KA.DNO ASC,KA.YER ASC";

            this.cmd.Parameters.Clear();
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Kimya_lab_analiz kayit = new Kimya_lab_analiz();
                kayit.Yer = "Listelenecek Analiz Kaydı Bulunamadı.";
                kayit.Analiz_id = 0;
                kayitlar.Add(kayit);
            }
            else
            {
                try
                {
                    while (this.dr.Read())
                    {
                        Kimya_lab_analiz kayit = new Kimya_lab_analiz();
                        kayit.Analiz_id = 1;
                        kayit.Yer = this.dr[0].ToString();
                        kayit.Dokum_no = Convert.ToInt32(this.dr[1].ToString());

                        string sqlx = "SELECT KALITE,RADYOAKTIVITE FROM URTHRK.CH_DOKUMNO_URETIM WHERE DNO=" + kayit.Dokum_no + "";
                        this.cmd.Parameters.Clear();
                        this.cmd.CommandText = sqlx;
                        this.dr2 = this.cmd.ExecuteReader();
                        while (this.dr2.Read())
                        {
                            kayit.Celik_cinsi = this.dr2[0].ToString();
                            kayit.Ract = this.dr2[1].ToString();
                        }


                        kayit.C = this.dr[2].ToString();
                        kayit.Si = this.dr[3].ToString();
                        kayit.S = this.dr[4].ToString();
                        kayit.P = this.dr[5].ToString();
                        kayit.Mn = this.dr[6].ToString();
                        kayit.Ni = this.dr[7].ToString();
                        kayit.Cr = this.dr[8].ToString();
                        kayit.Mo = this.dr[9].ToString();
                        kayit.V = this.dr[10].ToString();
                        kayit.Cu = this.dr[11].ToString();
                        kayit.W = this.dr[12].ToString();
                        kayit.Sn = this.dr[13].ToString();

                        kayit.Co = this.dr[14].ToString();
                        kayit.Al = this.dr[15].ToString();
                        kayit.Alsol = this.dr[16].ToString();
                        kayit.Alinsol = this.dr[17].ToString();
                        kayit.Pb = this.dr[18].ToString();

                        /** ikinci grid */
                        kayit.B = this.dr[19].ToString();
                        kayit.Bsol = this.dr[20].ToString();
                        kayit.Binsol = this.dr[21].ToString();
                        kayit.Sb = this.dr[22].ToString();
                        kayit.Nb = this.dr[23].ToString();
                        kayit.Ca = this.dr[24].ToString();
                        kayit.Casol = this.dr[25].ToString();

                        kayit.Cainso = this.dr[26].ToString();
                        kayit.Zn = this.dr[27].ToString();
                        kayit.N = this.dr[28].ToString();
                        kayit.Ti = this.dr[29].ToString();
                        kayit.Tisol = this.dr[30].ToString();
                        kayit.Tiinsol = this.dr[31].ToString();

                        kayit.Ass = this.dr[32].ToString();
                        kayit.Zr = this.dr[33].ToString();
                        kayit.Bi = this.dr[34].ToString();
                        kayit.O = this.dr[35].ToString();
                        kayit.Fe = this.dr[36].ToString();
                        kayit.Ceq = this.dr[37].ToString();
                        kayit.Ce = this.dr[38].ToString();

                        /** ucuncu grid */
                        kayit.Crnicu = this.dr[39].ToString();
                        kayit.Alcao = this.dr[40].ToString();
                        kayit.Almgo = this.dr[41].ToString();
                        kayit.Alsio = this.dr[42].ToString();
                        kayit.Altio = this.dr[43].ToString();
                        kayit.Alca = this.dr[44].ToString();
                        kayit.Alo = this.dr[45].ToString();

                        kayit.Cao = this.dr[46].ToString();
                        kayit.Cas = this.dr[47].ToString();
                        kayit.Tio = this.dr[48].ToString();
                        kayit.Tial = this.dr[49].ToString();
                        kayit.Mns = this.dr[50].ToString();
                        kayit.Mgo = this.dr[51].ToString();

                        kayit.Zro = this.dr[52].ToString();
                        kayit.Sio = this.dr["SIOX"].ToString();

                        // kayit.Celik_cinsi = this.dr["KTKKALITESI"].ToString();
                        // kayit.Ract = this.dr["RADYOACTIVITE"].ToString();
                        kayit.Yil = Convert.ToInt32(this.dr["YIL"].ToString());

                        kayitlar.Add(kayit);
                    }
                }
                catch
                {
                    throw new System.InvalidOperationException("Bağlantı gerçekleştirilirken bir hata oluştu.Tekrar deneyiniz!");
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;
        }

        public string dokumnoya_gore_yer_element_guncellemesi(string yer, string element, string miktar, string dokum_no)
        {
            string mesaj, sql;
            sql = "UPDATE URTHRK.KIMYAANALIZ SET  " + element + "='" + miktar + "' WHERE YER='" + yer + "' AND DNO=" + dokum_no + "";
            this.cmd.CommandText = sql;
            //this.cmd.ExecuteNonQuery();
            string update = this.cmd.ExecuteNonQuery().ToString();
            if (update != "0")
            {
                mesaj = "BAŞARILI";
            }
            else
            {
                mesaj = "BAŞARISIZ";
            }

            return mesaj;

        }

        public string dokumnoyagore_yer_sil(string yer, string dokum_no)
        {
            string mesaj, sql;
            sql = "DELETE FROM URTHRK.KIMYAANALIZ WHERE YER='" + yer + "' AND DNO=" + dokum_no + "";
            this.cmd.CommandText = sql;
            //this.cmd.ExecuteNonQuery();
            string delete = this.cmd.ExecuteNonQuery().ToString();
            if (delete != "0")
            {
                mesaj = "BAŞARILI";
            }
            else
            {
                mesaj = "BAŞARISIZ";
            }

            return mesaj;

        }

    }
}
