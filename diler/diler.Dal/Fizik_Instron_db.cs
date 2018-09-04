using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.OracleClient;
using diler.Entity;
using diler.Dal;
using System.IO;

namespace diler.Dal
{
    public class Fizik_Instron_db
    {
        
        OracleConnection conn,conn2;
        string connetionString,sql;
        OracleCommand cmd;
        OracleDataReader dr;

        public Fizik_Instron_db()
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
                    throw new System.InvalidOperationException("Veri Tabani baglantisi kurulamiyor!");
                }
            }
        }

        public string temizle(string veri)
        {
            veri = veri.Replace("<", "&lt;");
            veri = veri.Replace("[", "&#091;");
            veri = veri.Replace("]", "&#093;");
            veri = veri.Replace("\"\"", "");
            veri = veri.Replace("=", "&#061;");
            veri = veri.Replace("'", "''");
            veri = veri.Replace("select", "sel&#101;ct");
            veri = veri.Replace("join", "jo&#105;n");
            veri = veri.Replace("union", "un&#105;on");
            veri = veri.Replace("where", "wh&#101;re");
            veri = veri.Replace("insert", "ins&#101;rt");
            veri = veri.Replace("delete", "del&#101;te");
            veri = veri.Replace("update", "up&#100;ate");
            veri = veri.Replace("like", "lik&#101;");
            veri = veri.Replace("drop", "dro&#112;");
            veri = veri.Replace("create", "cr&#101;ate");
            veri = veri.Replace("modify", "mod&#105;fy");
            veri = veri.Replace("rename", "ren&#097;me");
            veri = veri.Replace("alter", "alt&#101;r");
            veri = veri.Replace("cast", "ca&#115;t");

            return veri;
        }

        public bool nervur_dosyasi_kayit(StreamReader reader, string delimiter)
        {
            string line;
            line = reader.ReadLine();//ilk satirda sutun bilgileri var, o yuzden bosa okutuyoruz.
            this.sql = "INSERT ALL ";
            string dokum_no_text = null;
            while (true)
            {
                Rm_veriler kayit = new Rm_veriler();
                line = reader.ReadLine();
                if (line == null) { break; }
                line = this.temizle(line);
                string[] values = line.Split(delimiter.ToCharArray()[0]);
                int sayac = 0;
                string tarih = "";
                DateTime dt = new DateTime();
                dt = DateTime.Now;
                int bugun = dt.Day;
                dokum_no_text = null;
                foreach (var value in values)
                {
                    if (sayac == 0)
                    {
                        // tarih
                        string[] tarih_eski = value.Split('.');
                        //  if (Convert.ToInt32(tarih_eski[0]) < bugun)
                        //  {
                        //      break;
                        // }
                        //  else
                        //  {
                        this.sql += "INTO URTHRK.ANALIZ_INSTRON_VERILER VALUES (";
                        //  }
                        tarih = value;
                        if (tarih_eski.Length == 3)
                        {
                            tarih = (dt.Year / 100) + tarih_eski[2] + tarih_eski[1] + tarih_eski[0];
                        }
                        else
                        {
                            tarih = dt.Year.ToString();
                        }

                        this.sql += tarih + ",";
                    }
                    else
                    {
                        if (sayac == 2)
                        {
                            //dokum_no
                            try
                            {
                                this.sql += Convert.ToInt32(value) + ",";
                            }
                            catch (Exception)
                            {
                                this.sql += "0,";
                                dokum_no_text = value;
                            }

                        }
                        else
                        {
                            if (sayac == 3)
                            {
                                if (dokum_no_text != null)
                                {
                                    this.sql += "'" + dokum_no_text + "-" + value + "',";
                                }
                                else
                                {
                                    this.sql += "'" + value + "',";
                                }
                            }
                            else
                            {
                                this.sql += "'" + value + "',";
                            }

                        }
                    }
                    sayac++;
                }

                this.sql = this.sql.Trim(',');
                if (sayac > 0)
                    this.sql += ")";
            }
            this.sql = this.sql.TrimEnd("INTO URTHRK.ANALIZ_INSTRON_VERILER VALUES (".ToCharArray());
            this.sql += " SELECT * FROM dual";

            this.cmd.CommandText = this.sql;
            this.cmd.Parameters.Clear();

            int rowCount = this.cmd.ExecuteNonQuery();

            if (rowCount < 1)
            {
                // Oops!!
                return false;
            }
            else
            {
                // insert success
                return true;
            }
        }

        public List<Rm_veriler> rm_veriler_data_read(int dokum_no = 0, int tarih = 0, int tarih2 = 0)
        {
            List<Rm_veriler> kayitlar = new List<Rm_veriler>();
            this.sql = "SELECT * " +
                       "FROM URTHRK.ANALIZ_INSTRON_VERILER " +
                       "WHERE URTHRK.ANALIZ_INSTRON_VERILER.DOKUMNO = 0";
            if (dokum_no > 0)
            {
                this.sql = "SELECT * " +
                            "FROM URTHRK.ANALIZ_INSTRON_VERILER " +
                            "WHERE URTHRK.ANALIZ_INSTRON_VERILER.DOKUMNO = " + dokum_no;
            }
            else
            {
                if (tarih > 0 && tarih2 > 0)
                {
                    this.sql = "SELECT * " +
                            "FROM URTHRK.ANALIZ_INSTRON_VERILER " +
                            "WHERE URTHRK.ANALIZ_INSTRON_VERILER.TARIH >= " + tarih +
                            " AND URTHRK.ANALIZ_INSTRON_VERILER.TARIH <= " + tarih2;
                }
            }


            this.cmd.CommandText = this.sql;
            this.cmd.Parameters.Clear();
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Rm_veriler kayit = new Rm_veriler();
                kayit.Testi_yapan = "Oops! RM Kayıtları Bulunamadı.";
                kayit.Id = 0;
                kayitlar.Add(kayit);
            }
            else
            {
                try
                {
                    while (this.dr.Read())
                    {
                        Rm_veriler kayit = new Rm_veriler();
                        kayit.Id = 1;
                        kayit.Tarih = Convert.ToInt32(this.dr["TARIH"].ToString());
                        kayit.Siparis_numarasi = this.dr["SIPNO"].ToString();
                        kayit.Dokum_numarasi = Convert.ToInt32(this.dr["DOKUMNO"].ToString());
                        kayit.Testi_yapan = this.dr["TESTI_YAPAN"].ToString();
                        kayit.Cap = this.dr["CAP"].ToString();
                        kayit.Nervur_yuksekligi = this.dr["NERVYUK"].ToString();
                        kayit.Nervur_yuksekligi_1_4 = this.dr["NERVYUK_14"].ToString();
                        kayit.Nervur_yuksekligi_3_4 = this.dr["NERVYUK_34"].ToString();
                        kayit.Cs_mesafesi = this.dr["CS_MESAFESI"].ToString();
                        kayit.Toplam_e_mesafesi = this.dr["TOPLAM_E_MESAFESI"].ToString();
                        kayit.Nervur_uzunlugu = this.dr["NERV_UZUNLUGU"].ToString();
                        kayit.Nervur_genisligi = this.dr["NERV_GENISLIGI"].ToString();
                        kayit.Beta_acisi = this.dr["BETA_ACISI"].ToString();
                        kayit.Alfa_acisi = this.dr["ALFA_ACISI"].ToString();
                        kayit.Fr = this.dr["FR"].ToString();

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


        public void Disconnect()
        {
            if (this.conn.State == System.Data.ConnectionState.Open)
            {
                this.conn.Close();
            }
        }

    }
}