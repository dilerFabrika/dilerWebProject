using System;
using System.Collections.Generic;
using System.Data.Odbc;

using System.Data.OleDb;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using diler.Entity;

namespace diler.Dal
{
    public class TeorikTolerans_db
    {
        OracleConnection conn;
        string connectionString, connection_string, sql;
        OracleCommand cmd;
        OdbcConnection conn_as400;
        OdbcCommand cmd_as400;
        OracleDataReader dr, dr3;
        OdbcDataReader dr2;

        public TeorikTolerans_db()
        {
            this.connectionString = @"Data Source=(DESCRIPTION=" +
                "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.198.191)(PORT=1521)))" +
                "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=DLRORA)));" +
                "User Id=URTHRK;Password=URTHRK;";


            //this.connection_string = ("Driver={Client Access ODBC Driver (32-bit)};" +
            //                "System=GEBZE400;" +
            //                "TRANSLATE=1;" +
            //                "Uid=OPRRPR;" +
            //                "Pwd=OPRRPR");

            this.connection_string = ("Driver={Client Access ODBC Driver (32-bit)};" +
                                    "System=192.168.199.252;" +
                                    "TRANSLATE=1;" +
                                    "Uid=OPRRAPOR;" +
                                    "Pwd=OPRRAPOR");

            cmd_as400 = new OdbcCommand();
            conn_as400 = new OdbcConnection(this.connection_string);

            cmd = new OracleCommand();
            conn = new OracleConnection(connectionString);


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
        public void as400_connect()
        {
            if (this.conn_as400.State != System.Data.ConnectionState.Open)
            {


                conn_as400.Open();
                cmd_as400.Connection = this.conn_as400;

            }
        }
        public void as400_Disconnect()
        {
            if (this.conn_as400.State == System.Data.ConnectionState.Open)
            {
                this.conn_as400.Close();

            }
        }

        public List<Teorik_tolerans_bilgiler> siparisBilgisiGetir(string siparisNo)
        {
            List<Teorik_tolerans_bilgiler> kayitlar = new List<Teorik_tolerans_bilgiler>();
            int genelToplamLc = 0;
            int paketSayisi = 0;
            int enToplam = 0;
            int enPaketSayisi = 0;
            double enKantarAgirligi = 0;
            double enTeorikPaketAgirligi = 0;
            double kantarAgirligi = 0;
            double teorikPaketAgirligi = 0;
            string teorikHaddelemeToleransi;
            this.sql = " SELECT DISTINCT(LOT) FROM URTHRK.MRKSIP_CBK_FLM_ALT WHERE SIP_NO = '" + siparisNo + "' AND " +
                       " REVIZ_NO IN(SELECT MAX(REVIZ_NO) FROM URTHRK.MRKSIP_CBK_FLM_ALT WHERE SIP_NO = '" + siparisNo + "' AND MAM_TIP = 'C')" +
                       " ORDER BY CAST(LOT AS INT)";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = this.sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                Teorik_tolerans_bilgiler kayit = new Teorik_tolerans_bilgiler();
                kayit.Lc = "Listelenecek Kayıt Bulunamadı";
                kayit.Id = 0;
                kayitlar.Add(kayit);
            }
            else
            {

                while (this.dr.Read())
                {
                    Teorik_tolerans_bilgiler kayit = new Teorik_tolerans_bilgiler();


                    kayit.Lot = this.dr[0].ToString();

                    string sql_ = "SELECT * FROM URTHRK.MRKSIP_CBK_FLM_ALT " +
                                  "WHERE LOT = '" + kayit.Lot + "' AND SIP_NO = '" + siparisNo + "' AND " +
                                  "(REVIZ_NO IN(SELECT MAX(REVIZ_NO) FROM URTHRK.MRKSIP_CBK_FLM_ALT " +
                                  "WHERE SIP_NO = '" + siparisNo + "' AND MAM_TIP = 'C' AND LOT = '" + kayit.Lot + "')) " +
                                  "ORDER BY CAST(EBAT AS INT)";
                    this.cmd.Parameters.Clear();
                    this.cmd.CommandText = sql_;
                    this.dr3 = this.cmd.ExecuteReader();
                    while (this.dr3.Read())
                    {
                        Teorik_tolerans_bilgiler veri = new Teorik_tolerans_bilgiler();

                        veri.Id = 1;
                        veri.SiparisNo = this.dr3["SIP_NO"].ToString();
                        veri.Lot = this.dr3["LOT"].ToString();
                        veri.Cap = this.dr3["EBAT"].ToString();
                        veri.Boy = this.dr3["BOY"].ToString();
                        veri.CubukSayisi = this.dr3["HESAPLANAN_PAKET_CUBSAY"].ToString();
                        veri.TeorikAgirlik = this.dr3["PAKET_AGIRLIK"].ToString();
                        veri.Lc = this.dr3["MIKTAR"].ToString();
                        veri.Renk = this.dr3["BOYAMADLR"].ToString();
                        veri.Mamkalite = this.dr3["MAM_KALITE"].ToString();
                        DateTime dt = new DateTime();
                        dt = DateTime.Now;
                        string tarih = dt.AddDays(-180).ToString("yyyyMMdd");//veritabanındaki kayit bicimi

                        string sqlcap;

                        if (veri.Cap.IndexOf("/") != -1)
                        {
                            sqlcap = " AND YUSPGMNSN.GETMLZCAPACK(mlznum) LIKE '%" + veri.Cap + "%' ";
                        }
                        else
                        {
                            sqlcap = " AND YUSPGMNSN.GETMLZCAPACK(mlznum) LIKE '" + veri.Cap + "MM%' ";
                        }

                        veri.Boy = veri.Boy.Replace(".", ",");
                        if (veri.Mamkalite == "GR 60")
                        {
                            veri.Mamkalite = "G60";
                        }
                        if (veri.Mamkalite == "GR 40")
                        {
                            veri.Mamkalite = "G40";
                        }
                        string lotnum = veri.SiparisNo.Substring(5) + "-" + veri.Lot;

                        string sql_as400 = "SELECT SUM(mlzmik),SUM(tikbag) FROM yusbilnsn.tikhrk t " +
                                           "WHERE (frmnum = 1010) " +
                                           "AND tiktur='Y' " +
                                           "AND tiktar >= " + tarih + " " +
                                           "AND tikbag <> 0 " +
                                           "AND LOTNUM like '%" + lotnum + "%' " +
                                           "" + sqlcap + " " +
                                           "AND YUSPGMNSN.GETMLZBOYACK(mlznum) LIKE '%" + veri.Boy + "M%' " +
                                           "AND mlznum like 'DM%' AND irstar>0  " +
                                           "AND YUSPGMNSN.GETMLZKLTACK(mlznum) LIKE '%" + veri.Mamkalite + "%' " +
                                           "AND irsnum<>'' AND SHANUM = 'FAB-GEBZE'";

                        cmd_as400.Parameters.Clear();
                        cmd_as400.CommandText = sql_as400;
                        dr2 = cmd_as400.ExecuteReader();
                        while (dr2.Read())
                        {
                            veri.PaketSayisi = dr2[1].ToString();
                            veri.KantarAgirligi = dr2[0].ToString();

                        }
                        dr2.Close();
                        dr2.Dispose();
                        if (veri.KantarAgirligi != "")
                        {
                            veri.TeorikPaketAgirligi = ((Convert.ToDouble(veri.PaketSayisi.Equals("") ? "0.0" : veri.PaketSayisi) *
                                                         Convert.ToDouble(veri.TeorikAgirlik.Equals("") ? "0.0" : veri.TeorikAgirlik)) / 1000).ToString();

                            veri.TeorikHaddelemeTolerans = ((Convert.ToDouble(veri.KantarAgirligi.Equals("") ? "0.0" : veri.KantarAgirligi) -
                                                              Convert.ToDouble(veri.TeorikPaketAgirligi.Equals("") ? "0.0" : veri.TeorikPaketAgirligi)) /
                                                              Convert.ToDouble(veri.TeorikPaketAgirligi.Equals("") ? "0.0" : veri.TeorikPaketAgirligi) * 100).ToString("0.##");
                        }
                        genelToplamLc = genelToplamLc + Convert.ToInt32(veri.Lc.Equals("") ? "0" : veri.Lc);
                        paketSayisi = paketSayisi + Convert.ToInt32(veri.PaketSayisi.Equals("") ? "0" : veri.PaketSayisi);
                        kantarAgirligi = kantarAgirligi + Convert.ToDouble(veri.KantarAgirligi.Equals("") ? "0.0" : veri.KantarAgirligi);
                        if (kantarAgirligi != 0)
                        {
                            teorikPaketAgirligi = teorikPaketAgirligi + Convert.ToDouble(veri.TeorikPaketAgirligi.Equals("") ? "0" : veri.TeorikPaketAgirligi);
                        }

                        kayitlar.Add(veri);

                    }


                    Teorik_tolerans_bilgiler veri2 = new Teorik_tolerans_bilgiler();
                    veri2.Id = 2;
                    veri2.TeorikAgirlik = "TOPLAM";
                    veri2.Lc = genelToplamLc.ToString();
                    if (paketSayisi != 0)
                    {
                        veri2.KantarAgirligi = kantarAgirligi.ToString();
                        veri2.PaketSayisi = paketSayisi.ToString();
                        veri2.TeorikPaketAgirligi = teorikPaketAgirligi.ToString();

                        teorikHaddelemeToleransi = ((Convert.ToDouble(veri2.KantarAgirligi.Equals("") ? "0.0" : veri2.KantarAgirligi) -
                                                   Convert.ToDouble(veri2.TeorikPaketAgirligi.Equals("") ? "0.0" : veri2.TeorikPaketAgirligi)) /
                                                   Convert.ToDouble(veri2.TeorikPaketAgirligi.Equals("") ? "0.0" : veri2.TeorikPaketAgirligi) * 100).ToString("0.##");

                        veri2.TeorikHaddelemeTolerans = teorikHaddelemeToleransi;
                    }
                    if (genelToplamLc != 0)
                    {
                        kayitlar.Add(veri2);
                    }

                    enToplam = enToplam + genelToplamLc;
                    enPaketSayisi = enPaketSayisi + paketSayisi;
                    enKantarAgirligi = enKantarAgirligi + kantarAgirligi;
                    enTeorikPaketAgirligi = enTeorikPaketAgirligi + teorikPaketAgirligi;
                    genelToplamLc = 0;
                    paketSayisi = 0;
                    kantarAgirligi = 0;
                    paketSayisi = 0;
                    teorikPaketAgirligi = 0;
                    teorikHaddelemeToleransi = 0.ToString();

                }

            }

            Teorik_tolerans_bilgiler veri3 = new Teorik_tolerans_bilgiler();
            veri3.Id = 2;
            veri3.TeorikAgirlik = "GENEL TOPLAM";
            veri3.Lc = enToplam.ToString();
            veri3.PaketSayisi = enPaketSayisi.ToString();
            veri3.KantarAgirligi = enKantarAgirligi.ToString();
            veri3.TeorikPaketAgirligi = enTeorikPaketAgirligi.ToString();

            teorikHaddelemeToleransi = ((Convert.ToDouble(veri3.KantarAgirligi.Equals("") ? "0.0" : veri3.KantarAgirligi) -
                                         Convert.ToDouble(veri3.TeorikPaketAgirligi.Equals("") ? "0.0" : veri3.TeorikPaketAgirligi)) /
                                         Convert.ToDouble(veri3.TeorikPaketAgirligi.Equals("") ? "0.0" : veri3.TeorikPaketAgirligi) * 100).ToString("0.##");

            veri3.TeorikHaddelemeTolerans = teorikHaddelemeToleransi.ToString();
            kayitlar.Add(veri3);


            Teorik_tolerans_bilgiler veri4 = new Teorik_tolerans_bilgiler();
            veri4.Id = 2;
            veri4.TeorikPaketAgirligi = "FARK";
            veri4.TeorikHaddelemeTolerans = (enTeorikPaketAgirligi - enKantarAgirligi).ToString("0.###");
            kayitlar.Add(veri4);


            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;

        }

    }
}
