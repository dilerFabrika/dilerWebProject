using diler.Entity;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace diler.Dal
{
    public class Refrakter_db
    {
        OracleConnection conn, conn2;
        string connetionString,sql;
        OracleCommand cmd;
        OracleDataReader dr, dr2;

        public Refrakter_db()
        {
            this.connetionString = @"Data Source=(DESCRIPTION=" + "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.198.191)(PORT=1521)))" + 
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

        public List<refrakter_bilgileri> refrakter_takip_data_read(string yil_ay, string yer)
        {

            List<refrakter_bilgileri> kayitlar = new List<refrakter_bilgileri>();
            if (yer == "Gaz Tapası")
            {
                this.sql = "SELECT COUNT(GAZDS), GAZFRM FROM URTHRK.CH_DOKUMNO_REFRAKTER WHERE TARIH LIKE '" + yil_ay + "%' AND GAZDS = 1 GROUP BY GAZFRM";
                this.cmd.CommandText = this.sql;
                this.dr = this.cmd.ExecuteReader();
                if (!this.dr.HasRows)
                {
                    //kayit bulunamadiysa
                    refrakter_bilgileri kayit = new refrakter_bilgileri();
                    kayit.firma = "Listelenecek Kayıt Bulunamadı !!";
                    kayit.Id = 0;
                    kayitlar.Add(kayit);
                }
                else
                {
                    while (this.dr.Read())
                    {
                        refrakter_bilgileri kayit = new refrakter_bilgileri();
                        kayit.Id = 1;
                        kayit.kullanilan_adet = this.dr[0].ToString();
                        kayit.firma = this.dr[1].ToString();
                        string sqlx = "SELECT COUNT(DNO) FROM  URTHRK.CH_DOKUMNO_REFRAKTER WHERE TARIH LIKE '" + yil_ay + "%' AND GAZFRM='" + kayit.firma + "'";
                        this.cmd.CommandText = sqlx;
                        this.dr2 = this.cmd.ExecuteReader();
                        while (this.dr2.Read())
                        {
                            kayit.toplamds = this.dr2[0].ToString();
                        }
                        if (kayit.toplamds != "")
                        {
                            kayit.ortalama_dokumsayisi = (Convert.ToDouble(kayit.toplamds) / Convert.ToDouble(kayit.kullanilan_adet)).ToString("0.##");
                        }
                        kayitlar.Add(kayit);
                    }
                }
            }
            if (yer == "Üst nozul")
            {
                this.sql = "SELECT COUNT(USTDS),USTFRM FROM URTHRK.CH_DOKUMNO_REFRAKTER WHERE TARIH LIKE '" + yil_ay + "%' AND USTDS=1 GROUP BY USTFRM";
                this.cmd.CommandText = this.sql;
                this.dr = this.cmd.ExecuteReader();
                if (!this.dr.HasRows)
                {
                    //kayit bulunamadiysa
                    refrakter_bilgileri kayit = new refrakter_bilgileri();
                    kayit.firma = "Listelenecek Kayıt Bulunamadı !!";
                    kayit.Id = 0;
                    kayitlar.Add(kayit);
                }
                else
                {
                    while (this.dr.Read())
                    {
                        refrakter_bilgileri kayit = new refrakter_bilgileri();
                        kayit.Id = 1;
                        kayit.kullanilan_adet = this.dr[0].ToString();
                        kayit.firma = this.dr[1].ToString();
                        string sqlx = "SELECT COUNT(DNO) FROM  URTHRK.CH_DOKUMNO_REFRAKTER WHERE TARIH LIKE '" + yil_ay + "%' AND USTFRM='" + kayit.firma + "'";
                        this.cmd.CommandText = sqlx;
                        this.dr2 = this.cmd.ExecuteReader();
                        while (this.dr2.Read())
                        {
                            kayit.toplamds = this.dr2[0].ToString();
                        }

                        if (kayit.toplamds != "")
                        {
                            kayit.ortalama_dokumsayisi = (Convert.ToDouble(kayit.toplamds) / Convert.ToDouble(kayit.kullanilan_adet)).ToString("0.##");
                        }
                        kayitlar.Add(kayit);

                    }
                }
            }
            if (yer == "Alt nozul")
            {
                this.sql = "SELECT COUNT(ALTDS),ALTFRM FROM URTHRK.CH_DOKUMNO_REFRAKTER WHERE TARIH LIKE '" + yil_ay + "%' AND ALTDS = 1 GROUP BY ALTFRM";
                this.cmd.CommandText = this.sql;
                this.dr = this.cmd.ExecuteReader();
                if (!this.dr.HasRows)
                {
                    //kayit bulunamadiysa
                    refrakter_bilgileri kayit = new refrakter_bilgileri();
                    kayit.firma = "Listelenecek Kayıt Bulunamadı !!";
                    kayit.Id = 0;
                    kayitlar.Add(kayit);
                }
                else
                {
                    while (this.dr.Read())
                    {
                        refrakter_bilgileri kayit = new refrakter_bilgileri();
                        kayit.Id = 1;
                        kayit.kullanilan_adet = this.dr[0].ToString();
                        kayit.firma = this.dr[1].ToString();
                        string sqlx = "SELECT COUNT(DNO) FROM  URTHRK.CH_DOKUMNO_REFRAKTER WHERE TARIH LIKE '" + yil_ay + "%' AND ALTFRM='" + kayit.firma + "'";
                        this.cmd.CommandText = sqlx;
                        this.dr2 = this.cmd.ExecuteReader();
                        while (this.dr2.Read())
                        {
                            kayit.toplamds = this.dr2[0].ToString();
                        }
                        if (kayit.toplamds != "")
                        {
                            kayit.ortalama_dokumsayisi = (Convert.ToDouble(kayit.toplamds) / Convert.ToDouble(kayit.kullanilan_adet)).ToString("0.##");
                        }
                        kayitlar.Add(kayit);
                    }
                }
            }
            if (yer == "Plaka T")
            {
                this.sql = "SELECT COUNT(SURGUDS),SURGUFRM FROM URTHRK.CH_DOKUMNO_REFRAKTER WHERE TARIH LIKE '" + yil_ay + "%' AND SURGUDS=1 AND SURGUPLKTY='T' GROUP BY SURGUFRM";
                this.cmd.CommandText = this.sql;
                this.dr = this.cmd.ExecuteReader();
                if (!this.dr.HasRows)
                {
                    //kayit bulunamadiysa
                    refrakter_bilgileri kayit = new refrakter_bilgileri();
                    kayit.firma = "Listelenecek Kayıt Bulunamadı !!";
                    kayit.Id = 0;
                    kayitlar.Add(kayit);
                }
                else
                {
                    while (this.dr.Read())
                    {
                        refrakter_bilgileri kayit = new refrakter_bilgileri();
                        kayit.Id = 1;
                        kayit.kullanilan_adet = this.dr[0].ToString();
                        kayit.firma = this.dr[1].ToString();
                        string sqlx = "SELECT COUNT(DNO) FROM URTHRK.CH_DOKUMNO_REFRAKTER WHERE TARIH LIKE '" + yil_ay + "%'  AND SURGUPLKTY = 'T'  AND SURGUFRM = '" + kayit.firma + "'  GROUP BY SURGUFRM";
                        this.cmd.CommandText = sqlx;
                        this.dr2 = this.cmd.ExecuteReader();
                        while (this.dr2.Read())
                        {
                            kayit.toplamds = this.dr2[0].ToString();
                        }
                        if (kayit.toplamds != "")
                        {
                            kayit.ortalama_dokumsayisi = (Convert.ToDouble(kayit.toplamds) / Convert.ToDouble(kayit.kullanilan_adet)).ToString("0.##");
                        }
                        kayitlar.Add(kayit);
                    }
                }
            }
            if (yer == "Plaka Y")
            {

                this.sql = "SELECT COUNT(SURGUDS),SURGUFRM FROM URTHRK.CH_DOKUMNO_REFRAKTER WHERE TARIH LIKE '" + yil_ay + "%' AND SURGUDS=1 AND SURGUPLKTY='Y' GROUP BY SURGUFRM";
                this.cmd.CommandText = this.sql;
                this.dr = this.cmd.ExecuteReader();
                if (!this.dr.HasRows)
                {
                    //kayit bulunamadiysa
                    refrakter_bilgileri kayit = new refrakter_bilgileri();
                    kayit.firma = "Listelenecek Kayıt Bulunamadı !!";
                    kayit.Id = 0;
                    kayitlar.Add(kayit);
                }
                else
                {
                    while (this.dr.Read())
                    {
                        refrakter_bilgileri kayit = new refrakter_bilgileri();
                        kayit.Id = 1;
                        kayit.kullanilan_adet = this.dr[0].ToString();
                        kayit.firma = this.dr[1].ToString();
                        string sqlx = "SELECT COUNT(DNO) FROM URTHRK.CH_DOKUMNO_REFRAKTER WHERE TARIH LIKE '" + yil_ay + "%'  AND SURGUPLKTY = 'Y'  AND SURGUFRM = '" + kayit.firma + "'  GROUP BY SURGUFRM";
                        this.cmd.CommandText = sqlx;
                        this.dr2 = this.cmd.ExecuteReader();
                        while (this.dr2.Read())
                        {
                            kayit.toplamds = this.dr2[0].ToString();
                        }
                        if (kayit.toplamds != "")
                        {
                            kayit.ortalama_dokumsayisi = (Convert.ToDouble(kayit.toplamds) / Convert.ToDouble(kayit.kullanilan_adet)).ToString("0.##");
                        }
                        kayitlar.Add(kayit);
                    }
                }


            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;
        }
        public List<refrakter_bilgileri> refrakter_takip_data_read2(string yil_ay, string yer)
        {
            List<refrakter_bilgileri> kayitlar = new List<refrakter_bilgileri>();
            if (yer == "Gaz Tapası")
            {
                string sqly = "SELECT SUM(COUNT(DNO)) FROM URTHRK.CH_DOKUMNO_refrakter WHERE TARIH LIKE '" + yil_ay + "%'  GROUP BY GAZFRM";
                this.cmd.CommandText = sqly;
                this.dr = this.cmd.ExecuteReader();
                if (!this.dr.HasRows)
                {
                    //kayit bulunamadiysa
                    refrakter_bilgileri kayit = new refrakter_bilgileri();
                    kayit.firma = "Listelenecek Kayıt Bulunamadı !!";
                    kayit.Id = 0;
                    kayitlar.Add(kayit);
                }
                else
                {
                    while (this.dr.Read())
                    {
                        refrakter_bilgileri kayit = new refrakter_bilgileri();
                        kayit.Id = 1;
                        kayit.toplamds = this.dr[0].ToString();
                        kayit.firma = yer;
                        string sqlz = "SELECT COUNT(GAZDS)FROM  URTHRK.CH_DOKUMNO_REFRAKTER WHERE TARIH LIKE '" + yil_ay + "%' AND GAZDS = 1";
                        this.cmd.CommandText = sqlz;
                        this.dr2 = this.cmd.ExecuteReader();
                        while (this.dr2.Read())
                        {
                            kayit.kullanilan_adet = this.dr2[0].ToString();
                        }
                        if (kayit.toplamds != "")
                        {
                            kayit.ortalama_dokumsayisi = (Convert.ToDouble(kayit.toplamds) / Convert.ToDouble(kayit.kullanilan_adet)).ToString("0.##");
                        }
                        kayitlar.Add(kayit);
                    }
                }

            }

            if (yer == "Üst nozul")
            {
                string sqly = "SELECT SUM(COUNT(DNO)) FROM URTHRK.CH_DOKUMNO_refrakter WHERE TARIH LIKE '" + yil_ay + "%'  GROUP BY USTFRM";
                this.cmd.CommandText = sqly;
                this.dr = this.cmd.ExecuteReader();
                if (!this.dr.HasRows)
                {
                    //kayit bulunamadiysa
                    refrakter_bilgileri kayit = new refrakter_bilgileri();
                    kayit.firma = "Listelenecek Kayıt Bulunamadı !!";
                    kayit.Id = 0;
                    kayitlar.Add(kayit);
                }
                else
                {
                    while (this.dr.Read())
                    {
                        refrakter_bilgileri kayit = new refrakter_bilgileri();
                        kayit.Id = 1;
                        kayit.firma = yer;
                        kayit.toplamds = this.dr[0].ToString();
                        string sqlz = "SELECT COUNT(USTDS)FROM  URTHRK.CH_DOKUMNO_REFRAKTER WHERE TARIH LIKE '" + yil_ay + "%' AND USTDS = 1";
                        this.cmd.CommandText = sqlz;
                        this.dr2 = this.cmd.ExecuteReader();
                        while (this.dr2.Read())
                        {
                            kayit.kullanilan_adet = this.dr2[0].ToString();
                        }
                        if (kayit.toplamds != "")
                        {
                            kayit.ortalama_dokumsayisi = (Convert.ToDouble(kayit.toplamds) / Convert.ToDouble(kayit.kullanilan_adet)).ToString("0.##");
                        }
                        kayitlar.Add(kayit);
                    }
                }
            }
            if (yer == "Alt nozul")
            {
                string sqly = "SELECT SUM(COUNT(DNO)) FROM URTHRK.CH_DOKUMNO_refrakter WHERE TARIH LIKE '" + yil_ay + "%'  GROUP BY ALTFRM";
                this.cmd.CommandText = sqly;
                this.dr = this.cmd.ExecuteReader();
                if (!this.dr.HasRows)
                {
                    //kayit bulunamadiysa
                    refrakter_bilgileri kayit = new refrakter_bilgileri();
                    kayit.firma = "Listelenecek Kayıt Bulunamadı !!";
                    kayit.Id = 0;
                    kayitlar.Add(kayit);
                }
                else
                {
                    while (this.dr.Read())
                    {
                        refrakter_bilgileri kayit = new refrakter_bilgileri();
                        kayit.Id = 1;
                        kayit.firma = yer;
                        kayit.toplamds = this.dr[0].ToString();
                        string sqlz = "SELECT COUNT(ALTDS) FROM  URTHRK.CH_DOKUMNO_REFRAKTER WHERE TARIH LIKE '" + yil_ay + "%' AND ALTDS = 1";
                        this.cmd.CommandText = sqlz;
                        this.dr2 = this.cmd.ExecuteReader();
                        while (this.dr2.Read())
                        {
                            kayit.kullanilan_adet = this.dr2[0].ToString();
                        }
                        if (kayit.toplamds != "")
                        {
                            kayit.ortalama_dokumsayisi = (Convert.ToDouble(kayit.toplamds) / Convert.ToDouble(kayit.kullanilan_adet)).ToString("0.##");
                        }
                        kayitlar.Add(kayit);
                    }
                }
            }
            if (yer == "Plaka T")
            {
                string sqly = "SELECT SUM(COUNT(DNO)) FROM URTHRK.CH_DOKUMNO_refrakter WHERE TARIH LIKE '" + yil_ay + "%' AND SURGUPLKTY = 'T' GROUP BY SURGUFRM";
                this.cmd.CommandText = sqly;
                this.dr = this.cmd.ExecuteReader();
                if (!this.dr.HasRows)
                {
                    //kayit bulunamadiysa
                    refrakter_bilgileri kayit = new refrakter_bilgileri();
                    kayit.firma = "Listelenecek Kayıt Bulunamadı !!";
                    kayit.Id = 0;
                    kayitlar.Add(kayit);
                }
                else
                {
                    while (this.dr.Read())
                    {
                        refrakter_bilgileri kayit = new refrakter_bilgileri();
                        kayit.Id = 1;
                        kayit.toplamds = this.dr[0].ToString();
                        kayit.firma = yer;
                        string sqlz = "SELECT COUNT(SURGUDS) FROM  URTHRK.CH_DOKUMNO_REFRAKTER WHERE TARIH LIKE '" + yil_ay + "%' AND SURGUDS = 1 AND SURGUPLKTY = 'T'";
                        this.cmd.CommandText = sqlz;
                        this.dr2 = this.cmd.ExecuteReader();
                        while (this.dr2.Read())
                        {
                            kayit.kullanilan_adet = this.dr2[0].ToString();
                        }
                        if (kayit.toplamds != "")
                        {
                            kayit.ortalama_dokumsayisi = (Convert.ToDouble(kayit.toplamds) / Convert.ToDouble(kayit.kullanilan_adet)).ToString("0.##");
                        }
                        kayitlar.Add(kayit);
                    }
                }
            }
            if (yer == "Plaka Y")
            {
                string sql = "SELECT SUM(COUNT(DNO)) FROM URTHRK.CH_DOKUMNO_refrakter WHERE TARIH LIKE '" + yil_ay + "%' AND SURGUPLKTY = 'Y' GROUP BY SURGUFRM";
                this.cmd.CommandText = sql;
                this.dr = this.cmd.ExecuteReader();
                if (!this.dr.HasRows)
                {
                    //kayit bulunamadiysa
                    refrakter_bilgileri kayit = new refrakter_bilgileri();
                    kayit.firma = "Listelenecek Kayıt Bulunamadı !!";
                    kayit.Id = 0;
                    kayitlar.Add(kayit);
                }
                else
                {
                    while (this.dr.Read())
                    {
                        refrakter_bilgileri kayit = new refrakter_bilgileri();
                        kayit.Id = 1;
                        kayit.firma = yer;
                        kayit.toplamds = this.dr[0].ToString();
                        string sqlz = "SELECT COUNT(SURGUDS) FROM  URTHRK.CH_DOKUMNO_REFRAKTER WHERE TARIH LIKE '" + yil_ay + "%' AND SURGUDS = 1 AND SURGUPLKTY = 'Y'";
                        this.cmd.CommandText = sqlz;
                        this.dr2 = this.cmd.ExecuteReader();
                        while (this.dr2.Read())
                        {
                            kayit.kullanilan_adet = this.dr2[0].ToString();
                        }
                        if (kayit.toplamds != "")
                        {
                            kayit.ortalama_dokumsayisi = (Convert.ToDouble(kayit.toplamds) / Convert.ToDouble(kayit.kullanilan_adet)).ToString("0.##");
                        }
                        kayitlar.Add(kayit);
                    }
                }

            }

            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;
        }
 
    
    }
}
