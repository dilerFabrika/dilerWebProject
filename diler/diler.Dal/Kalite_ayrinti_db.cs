using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using diler.Entity;

namespace diler.Dal
{
    public class Kalite_ayrinti_db
    {
        OracleConnection conn, conn2;
        string connetionString, sql;
        OracleCommand cmd;
        OracleDataReader dr;
        public string tarih_parse;

        public Kalite_ayrinti_db()
        {
            try
            {
                this.connetionString = @"Data Source=(DESCRIPTION=" +
                    "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.198.191)(PORT=1521)))" +
                    "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=DLRORA)));" +
                    "User Id=URTHRK;Password=URTHRK;";

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

        public List<R_ark_ocagi_genel> ark_ocagi_genel_data_read(string tarih1, string tarih2, string kalite, string dokum_no, string sip_no, string dokum_tipi)
        {
            List<R_ark_ocagi_genel> ark_ocagi_genel = new List<R_ark_ocagi_genel>();

            this.sql = "SELECT *   " +
            "FROM URTHRK.CH_DOKUMNO_YATAY_AO_GENEL " +
            "WHERE TARIH >= " + tarih1 + " " +
            "AND TARIH <= " + tarih2 + " ";
            if (kalite != "Tümü")
            {
                this.sql += "AND KALITE='" + kalite + "' ";
            }
            if (dokum_no != "")
            {
                this.sql += "AND DOKUMNO=" + dokum_no + " ";
            }
            if (sip_no != "")
            {
                this.sql += "AND SIPNO='" + sip_no + "' ";
            }
            if (dokum_tipi != "Seçiniz")
            {
                this.sql += "AND DOKUMTIPI='" + dokum_tipi + "' ";
            }

            this.sql += "ORDER BY DOKUMNO ASC";

            this.cmd.Parameters.Clear();
            this.cmd.CommandText = sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                R_ark_ocagi_genel a = new R_ark_ocagi_genel();
                a.Kalite = "Listelenecek Kayıt Bulunamadı !!";
                a.Id = 0;
                ark_ocagi_genel.Add(a);
            }
            else
            {
                while (this.dr.Read())
                {
                    R_ark_ocagi_genel a = new R_ark_ocagi_genel();
                    a.Id = 1;
                   // a.Tarih = this.dr[0].ToString();
                    int tarih = Convert.ToInt32(this.dr[0].ToString());
                    tarih_parse = tarihFormat(tarih);
                    a.Tarih = tarih_parse.ToString();
                    a.Dokum_no = this.dr[1].ToString();
                    a.Kalite = this.dr[2].ToString();
                    a.Dokum_tip = this.dr[3].ToString();
                    a.Sip_no = this.dr[4].ToString();
                    a.Dokum_baslangic_saati = this.dr[5].ToString();
                    a.Devirme_saati = this.dr[6].ToString();
                    a.Dokum_suresi = this.dr[7].ToString();
                    a.Canak_dokum_sayisi = this.dr[8].ToString();
                    a.Kapak_dokum_sayisi = this.dr[9].ToString();
                    a.Yurek_dokum_sayisi = this.dr[10].ToString();
                    a.Rbt_delik_sayisi = this.dr[11].ToString();
                    a.Yurek_no = this.dr[12].ToString();
                    a.Ted_al_saati = this.dr[13].ToString();
                    a.Ted_tirnak_acma_saati = this.dr[14].ToString();
                    a.Ted_tb_sure = this.dr[15].ToString();
                    a.Ao_enerjili_sure = this.dr[16].ToString();
                    a.Ao_enerjisiz_sure = this.dr[17].ToString();
                    a.Devirme_sicaklik = this.dr[18].ToString();
                    a.Eletrodkodu_ao = this.dr[19].ToString();


                    ark_ocagi_genel.Add(a);
                }
            }
            return ark_ocagi_genel;
        }
        public List<R_pota_ocagi_genel> pota_ocagi_genel_data_read(string tarih1, string tarih2, string kalite, string dokum_no, string sip_no, string dokum_tipi)
        {
            List<R_pota_ocagi_genel> pota_ocagi_genel = new List<R_pota_ocagi_genel>();

            this.sql = "SELECT *   " +
         "FROM URTHRK.CH_DOKUMNO_YATAY_PO_GENEL " +
         "WHERE TARIH >= " + tarih1 + " " +
         "AND TARIH <= " + tarih2 + " ";
            if (kalite != "Tümü")
            {
                this.sql += "AND KALITE='" + kalite + "' ";
            }
            if (dokum_no != "")
            {
                this.sql += "AND DOKUMNO=" + dokum_no + " ";
            }
            if (sip_no != "")
            {
                this.sql += "AND SIPNO='" + sip_no + "' ";
            }
            if (dokum_tipi != "Seçiniz")
            {
                this.sql += "AND DOKUMTIPI='" + dokum_tipi + "' ";
            }

            this.sql += "ORDER BY DOKUMNO ASC";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                R_pota_ocagi_genel p = new R_pota_ocagi_genel();
                p.Kalite = "Listelenecek Kayıt Bulunamadı !!";
                p.Id = 0;
                pota_ocagi_genel.Add(p);
            }
            else
            {
                while (this.dr.Read())
                {
                    R_pota_ocagi_genel p = new R_pota_ocagi_genel();
                    p.Id = 1;
                    int tarih = Convert.ToInt32(this.dr[0].ToString());
                    tarih_parse = tarihFormat(tarih);
                    p.Tarih = tarih_parse.ToString();
                    p.Dokum_no = this.dr[1].ToString();
                    p.Kalite = this.dr[2].ToString();
                    p.Dokum_tip = this.dr[3].ToString();
                    p.Sip_no = this.dr[4].ToString();
                    p.Po_giris_saati = this.dr[5].ToString();
                    p.Po_cikis_saati = this.dr[6].ToString();
                    p.Po_brut_sure = this.dr[7].ToString();
                    p.Po_enerjili_sure = this.dr[8].ToString();
                    p.Po_power_off_time = this.dr[9].ToString();
                    p.Po_giris_sicaklik = this.dr[10].ToString();
                    p.Po_cikis_sicaklik = this.dr[11].ToString();
                    p.Po_sivi_celik_son = this.dr[12].ToString();
                    p.Po_bos_pota_tonaj = this.dr[13].ToString();
                    p.Po_sivi_celik = this.dr[14].ToString();
                    p.Po_ekfaz1 = this.dr[15].ToString();
                    p.Po_ekfaz2 = this.dr[16].ToString();
                    p.Po_ekfaz3 = this.dr[17].ToString();
                    p.Po_genel_aciklama = this.dr[18].ToString();
                    p.Yeniden_isitma_giris = this.dr[19].ToString();
                    p.Yeniden_isitma_cikis = this.dr[20].ToString();
                    p.Eletrodkodu_Po = this.dr[21].ToString();


                    pota_ocagi_genel.Add(p);
                }
            }
            return pota_ocagi_genel;
        }
        public List<R_sdm_genel> sdm_genel_data_read(string tarih1, string tarih2, string kalite, string dokum_no, string sip_no, string dokum_tipi)
        {
            List<R_sdm_genel> sdm_genel = new List<R_sdm_genel>();

            this.sql = "SELECT *   " +
         "FROM URTHRK.CH_DOKUMNO_YATAY_SDM_GENEL " +
         "WHERE TARIH >= " + tarih1 + " " +
         "AND TARIH <= " + tarih2 + " ";
            if (kalite != "Tümü")
            {
                this.sql += "AND KALITE='" + kalite + "' ";
            }
            if (dokum_no != "")
            {
                this.sql += "AND DOKUMNO=" + dokum_no + " ";
            }
            if (sip_no != "")
            {
                this.sql += "AND SIPNO='" + sip_no + "' ";
            }
            if (dokum_tipi != "Seçiniz")
            {
                this.sql += "AND DOKUMTIPI='" + dokum_tipi + "' ";
            }

            this.sql += "ORDER BY DOKUMNO ASC";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                R_sdm_genel s = new R_sdm_genel();
                s.Kalite = "Listelenecek Kayıt Bulunamadı !!";
                s.Id = 0;
                sdm_genel.Add(s);
            }
            else
            {
                while (this.dr.Read())
                {
                    R_sdm_genel s = new R_sdm_genel();
                    s.Id = 1;
                    int tarih = Convert.ToInt32(this.dr[0].ToString());
                    tarih_parse = tarihFormat(tarih);
                    s.Tarih = tarih_parse.ToString();
                    s.Dokum_no = this.dr[1].ToString();
                    s.Kalite = this.dr[2].ToString();
                    s.Dokum_tip = this.dr[3].ToString();
                    s.Sip_no = this.dr[4].ToString();
                    s.Kalip_dokum_sayisi1 = this.dr[5].ToString();
                    s.Kalip_dokum_sayisi2 = this.dr[6].ToString();
                    s.Kalip_dokum_sayisi3 = this.dr[7].ToString();
                    s.Kalip_dokum_sayisi4 = this.dr[8].ToString();
                    s.Kalip_dokum_sayisi5 = this.dr[9].ToString();
                    s.Kalip_dokum_sayisi6 = this.dr[10].ToString();
                    s.Tandis_baslangic_sicaklik = this.dr[11].ToString();
                    s.Tandis_orta_sicaklik = this.dr[12].ToString();
                    s.Tandis_no = this.dr[13].ToString();
                    s.Tandis_bindirme_sayisi = this.dr[14].ToString();
                    s.Pota_acma_saati = this.dr[15].ToString();
                    s.Pota_kapatma_saati = this.dr[16].ToString();
                    s.Net_sure = this.dr[17].ToString();
                    s.Pota_plaka_no = this.dr[18].ToString();
                    s.Pota_durumu = this.dr[19].ToString();

                    sdm_genel.Add(s);
                }
            }
            return sdm_genel;
        }
        public List<R_po_alyaj> po_alyaj_data_read(string tarih1, string tarih2, string kalite, string dokum_no, string sip_no, string dokum_tipi)
        {
            List<R_po_alyaj> po_alyaj = new List<R_po_alyaj>();

            //this.sql = "SELECT *   " +
            //"FROM URTHRK.CH_DOKUMNO_YATAY_PO_ALYAJ_V " +
            //"WHERE ";
            //if (Convert.ToInt32(tarih1) > 0 && Convert.ToInt32(tarih2) > 0)
            //{
            //    this.sql += "  TARIH >= " + tarih1 +
            //            " AND TARIH <= " + tarih2 + " ORDER BY DOKUMNO ASC";
            //}
            this.sql = "SELECT *   " +
       "FROM URTHRK.CH_DOKUMNO_YATAY_PO_ALYAJ " +
       "WHERE TARIH >= " + tarih1 + " " +
       "AND TARIH <= " + tarih2 + " ";
            if (kalite != "Tümü")
            {
                this.sql += "AND KALITE='" + kalite + "' ";
            }
            if (dokum_no != "")
            {
                this.sql += "AND DOKUMNO=" + dokum_no + " ";
            }
            if (sip_no != "")
            {
                this.sql += "AND SIPNO='" + sip_no + "' ";
            }
            if (dokum_tipi != "Seçiniz")
            {
                this.sql += "AND DOKUMTIPI='" + dokum_tipi + "' ";
            }

            this.sql += "ORDER BY DOKUMNO ASC";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                R_po_alyaj p = new R_po_alyaj();
                p.Kalite = "Listelenecek Kayıt Bulunamadı !!";
                p.Id = 0;
                po_alyaj.Add(p);
            }
            else
            {
                while (this.dr.Read())
                {
                    R_po_alyaj p = new R_po_alyaj();
                    p.Id = 1;
                    int tarih = Convert.ToInt32(this.dr[0].ToString());
                    tarih_parse = tarihFormat(tarih);
                    p.Tarih = tarih_parse.ToString();
                    p.Dokum_no = this.dr[1].ToString();
                    p.Kalite = this.dr[2].ToString();
                    p.Dokum_tip = this.dr[3].ToString();
                    p.Sip_no = this.dr[4].ToString();
                    p.C = this.dr[5].ToString();
                    p.Cao = this.dr[6].ToString();
                    p.Fesi65 = this.dr[7].ToString();
                    p.Fesi70 = this.dr[8].ToString();
                    p.Fesi75 = (this.dr[9].ToString());
                    p.Dev_kirec = this.dr[10].ToString();
                    p.Fesilowal_po = this.dr[11].ToString();
                    p.Fesimn60 = this.dr[12].ToString();
                    p.Fesimn65 = this.dr[13].ToString();
                    p.Fesimn70 = this.dr[14].ToString();
                    p.Fesimn6030 = this.dr[15].ToString();
                    p.Femn = this.dr[16].ToString();
                    p.Femnhcr = this.dr[17].ToString();
                    p.Femnlowc_po = this.dr[18].ToString();
                    p.Fev = this.dr[19].ToString();
                    p.Al = this.dr[20].ToString();
                    p.Al_granul = this.dr[21].ToString();
                    p.Casi = this.dr[22].ToString();
                    p.Caf2 = this.dr[23].ToString();
                    p.Mgo = this.dr[24].ToString();
                    p.Boksit = this.dr[25].ToString();
                    p.Cafe = this.dr[26].ToString();

                    p.Alwire = this.dr[27].ToString();
                    p.Feti = this.dr[28].ToString();
                    p.Dolamitik_kirec = this.dr[29].ToString();
                    p.Siliskumu = this.dr[30].ToString();
                    p.Cac2 = this.dr[31].ToString();
                    p.Feb = this.dr[32].ToString();
                    p.Kolamanit = this.dr[33].ToString();
                    p.Fecr = this.dr[34].ToString();
                    p.S = this.dr[35].ToString();
                    p.Fep = this.dr[36].ToString();

                    p.Nb = this.dr[37].ToString();
                    p.Ca_solid_tel = this.dr[38].ToString();
                    p.Azotsuz_c = this.dr[39].ToString();
                    p.Al_curufu = this.dr[40].ToString();




                    po_alyaj.Add(p);
                }
            }
            return po_alyaj;
        }
        public List<R_ao_alyaj> ao_alyaj_data_read(string tarih1, string tarih2, string kalite, string dokum_no, string sip_no, string dokum_tipi)
        {
            List<R_ao_alyaj> ao_alyaj = new List<R_ao_alyaj>();

            this.sql = "SELECT *   " +
    "FROM URTHRK.CH_DOKUMNO_YATAY_AO_ALYAJ " +
    "WHERE TARIH >= " + tarih1 + " " +
    "AND TARIH <= " + tarih2 + " ";
            if (kalite != "Tümü")
            {
                this.sql += "AND KALITE='" + kalite + "' ";
            }
            if (dokum_no != "")
            {
                this.sql += "AND DOKUMNO=" + dokum_no + " ";
            }
            if (sip_no != "")
            {
                this.sql += "AND SIPNO='" + sip_no + "' ";
            }
            if (dokum_tipi != "Seçiniz")
            {
                this.sql += "AND DOKUMTIPI='" + dokum_tipi + "' ";
            }

            this.sql += "ORDER BY DOKUMNO ASC";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                R_ao_alyaj a = new R_ao_alyaj();
                a.Kalite = "Listelenecek Kayıt Bulunamadı !!";
                a.Id = 0;
                ao_alyaj.Add(a);
            }
            else
            {
                while (this.dr.Read())
                {
                    R_ao_alyaj a = new R_ao_alyaj();
                    a.Id = 1;
                    int tarih = Convert.ToInt32(this.dr[0].ToString());
                    tarih_parse = tarihFormat(tarih);
                    a.Tarih = tarih_parse.ToString();
                    a.Dokum_no = this.dr[1].ToString();
                    a.Kalite = this.dr[2].ToString();
                    a.Dokum_tip = this.dr[3].ToString();
                    a.Sip_no = this.dr[4].ToString();
                    a.Parca_kok = this.dr[5].ToString();
                    a.Enjekte_kok_elti = this.dr[6].ToString();
                    a.Enjekte_kok_panel = this.dr[7].ToString();
                    a.Parca_kirec = this.dr[8].ToString();
                    a.Enjekte_kirec = (this.dr[9].ToString());
                    a.Dev_al = this.dr[10].ToString();
                    a.Dev_fesi65 = this.dr[11].ToString();
                    a.Dev_fesi70 = this.dr[12].ToString();
                    a.Dev_fesi75 = this.dr[13].ToString();
                    a.Dev_fesimn60 = this.dr[14].ToString();
                    a.Dev_fesimn65 = this.dr[15].ToString();
                    a.Dev_fesimn70 = this.dr[16].ToString();
                    a.Dev_femn = this.dr[17].ToString();
                    a.Dev_femn_hcr = this.dr[18].ToString();
                    a.Fesilowal_ao = this.dr[19].ToString();
                    a.Femnlowc_ao = this.dr[20].ToString();


                    ao_alyaj.Add(a);
                }
            }
            return ao_alyaj;
        }
        public List<R_hurda> hurda_data_read(string tarih1, string tarih2, string kalite, string dokum_no, string sip_no, string dokum_tipi)
        {
            List<R_hurda> hurda = new List<R_hurda>();

            this.sql = "SELECT *   " +
   "FROM URTHRK.CH_DOKUMNO_YATAY_HURDALAR " +
   "WHERE TARIH >= " + tarih1 + " " +
   "AND TARIH <= " + tarih2 + " ";
            if (kalite != "Tümü")
            {
                this.sql += "AND KALITE='" + kalite + "' ";
            }
            if (dokum_no != "")
            {
                this.sql += "AND DOKUMNO=" + dokum_no + " ";
            }
            if (sip_no != "")
            {
                this.sql += "AND SIPNO='" + sip_no + "' ";
            }
            if (dokum_tipi != "Seçiniz")
            {
                this.sql += "AND DOKUMTIPI='" + dokum_tipi + "' ";
            }

            this.sql += "ORDER BY DOKUMNO ASC";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                R_hurda h = new R_hurda();
                h.Kalite = "Listelenecek Kayıt Bulunamadı !!";
                h.Id = 0;
                hurda.Add(h);
            }
            else
            {
                while (this.dr.Read())
                {
                    R_hurda h = new R_hurda();
                    h.Id = 1;
                    int tarih = Convert.ToInt32(this.dr[0].ToString());
                    tarih_parse = tarihFormat(tarih);
                    h.Tarih = tarih_parse.ToString();
                    h.Dokum_no = this.dr[1].ToString();
                    h.Kalite = this.dr[2].ToString();
                    h.Dokum_tip = this.dr[3].ToString();
                    h.Sip_no = this.dr[4].ToString();
                    h.Degirmen = this.dr[5].ToString();
                    h.Hms1 = this.dr[6].ToString();
                    h.Hms2 = this.dr[7].ToString();
                    h.Piyasa = this.dr[8].ToString();
                    h.Hms1_2 = (this.dr[9].ToString());
                    h.Pik = this.dr[10].ToString();
                    h.Elek = this.dr[11].ToString();
                    h.Skal = this.dr[12].ToString();
                    h.Hbi = this.dr[13].ToString();
                    h.Talas = this.dr[14].ToString();
                    h.Dkp = this.dr[15].ToString();
                    h.Busheling = this.dr[16].ToString();


                    hurda.Add(h);
                }
            }
            return hurda;
        }
        public List<R_enerji> enerji_data_read(string tarih1, string tarih2, string kalite, string dokum_no, string sip_no, string dokum_tipi)
        {
            List<R_enerji> enerji = new List<R_enerji>();

            this.sql = "SELECT *   " +
   "FROM URTHRK.CH_DOKUMNO_YATAY_ENERJIDGAZ " +
   "WHERE TARIH >= " + tarih1 + " " +
   "AND TARIH <= " + tarih2 + " ";
            if (kalite != "Tümü")
            {
                this.sql += "AND KALITE='" + kalite + "' ";
            }
            if (dokum_no != "")
            {
                this.sql += "AND DOKUMNO=" + dokum_no + " ";
            }
            if (sip_no != "")
            {
                this.sql += "AND SIPNO='" + sip_no + "' ";
            }
            if (dokum_tipi != "Seçiniz")
            {
                this.sql += "AND DOKUMTIPI='" + dokum_tipi + "' ";
            }

            this.sql += "ORDER BY DOKUMNO ASC";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                R_enerji e = new R_enerji();
                e.Kalite = "Listelenecek Kayıt Bulunamadı !!";
                e.Id = 0;
                enerji.Add(e);
            }
            else
            {
                while (this.dr.Read())
                {
                    R_enerji e = new R_enerji();
                    e.Id = 1;
                    int tarih = Convert.ToInt32(this.dr[0].ToString());
                    tarih_parse = tarihFormat(tarih);
                    e.Tarih = tarih_parse.ToString();
                    e.Dokum_no = this.dr[1].ToString();
                    e.Kalite = this.dr[2].ToString();
                    e.Dokum_tip = this.dr[3].ToString();
                    e.Sip_no = this.dr[4].ToString();
                    e.Ao_enerji = this.dr[5].ToString();
                    e.Ao_tirnak_kapatma_enerjisi = this.dr[6].ToString();
                    e.Brl_dgaz = this.dr[7].ToString();
                    e.Rcb_brl_dgaz = this.dr[8].ToString();
                    e.Pc_dgaz = this.dr[9].ToString();
                    e.Po_enerji = this.dr[10].ToString();


                    enerji.Add(e);
                }
            }
            return enerji;
        }
        public List<R_sarfmalzeme> sarf_malzeme_data_read(string tarih1, string tarih2, string kalite, string dokum_no, string sip_no, string dokum_tipi)
        {
            List<R_sarfmalzeme> sarfmalzeme = new List<R_sarfmalzeme>();
            this.sql = "SELECT *   " +
   "FROM URTHRK.CH_DOKUMNO_YATAY_SARFMALZEME " +
   "WHERE TARIH >= " + tarih1 + " " +
   "AND TARIH <= " + tarih2 + " ";
            if (kalite != "Tümü")
            {
                this.sql += "AND KALITE='" + kalite + "' ";
            }
            if (dokum_no != "")
            {
                this.sql += "AND DOKUMNO=" + dokum_no + " ";
            }
            if (sip_no != "")
            {
                this.sql += "AND SIPNO='" + sip_no + "' ";
            }
            if (dokum_tipi != "Seçiniz")
            {
                this.sql += "AND DOKUMTIPI='" + dokum_tipi + "' ";
            }

            this.sql += "ORDER BY DOKUMNO ASC";
            this.cmd.Parameters.Clear();
            this.cmd.CommandText = sql;
            this.dr = this.cmd.ExecuteReader();
            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                R_sarfmalzeme s = new R_sarfmalzeme();
                s.Kalite = "Listelenecek Kayıt Bulunamadı !!";
                s.Id = 0;
                sarfmalzeme.Add(s);
            }
            else
            {
                while (this.dr.Read())
                {
                    R_sarfmalzeme s = new R_sarfmalzeme();
                    s.Id = 1;
                    int tarih = Convert.ToInt32(this.dr[0].ToString());
                    tarih_parse = tarihFormat(tarih);
                    s.Tarih = tarih_parse.ToString();
                    s.Dokum_no = this.dr[1].ToString();
                    s.Kalite = this.dr[2].ToString();
                    s.Dokum_tip = this.dr[3].ToString();
                    s.Sip_no = this.dr[4].ToString();
                    s.Ladle_shroud_adet = this.dr[5].ToString();
                    s.Ladle_shroud_gasket_adet = this.dr[6].ToString();
                    s.Tundish_c_m_p_asidik_kg = this.dr[7].ToString();
                    s.Tundish_c_m_p_bazik_kg = this.dr[8].ToString();
                    s.Tundish_c_m_p_w_kg = this.dr[9].ToString();
                    s.Natural_gas_m3 = this.dr[10].ToString();
                    s.Ses_shroud_adet = this.dr[11].ToString();
                    s.Scorialit_sph_c_411_81_e_kg = this.dr[12].ToString();
                    s.Scorialit_sph_c_176_als_9_kg = this.dr[13].ToString();
                    s.Scorialit_sph_c_189_v_3_kg = this.dr[14].ToString();
                    s.Ramag_92p_ramming_mass_kg = this.dr[15].ToString();
                    s.Melting_gasket_c52_adet = this.dr[16].ToString();
                    s.Scorialit_sph_c_189_gm_23_kg = this.dr[17].ToString();
                    s.Scorialit_sph_c_189_e_3_kg = this.dr[18].ToString();
                    s.Sph_c_189_vv1 = this.dr[19].ToString();
                    s.Brl_o2 = this.dr[20].ToString();
                    s.Elti_o2 = this.dr[21].ToString();
                    s.Rcb_ref_o2 = this.dr[22].ToString();
                    s.Rcb_brl_o2 = this.dr[23].ToString();


                    sarfmalzeme.Add(s);
                }
            }
            return sarfmalzeme;
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


      
        public List<string> kalite_comboDoldur(string tarih1_, string tarih2_)
        {
            List<string> kaliteler = new List<string>();
            // string sql = "SELECT KOD_ACK FROM URTTNM.TANIMLAR WHERE TNMTIPI IN('KALITE') AND TESIS='CH' ORDER BY KOD_ACK";
            string sql = "SELECT DISTINCT(KALITE)FROM CH_DOKUMNO_URETIM WHERE DOKUMTAR BETWEEN " + tarih1_ + " AND " + tarih2_ + " ORDER BY KALITE";
            this.cmd.CommandText = sql;
            this.dr = this.cmd.ExecuteReader();
            while (dr.Read())
            {
                string kalite = dr["KALITE"].ToString();
                kaliteler.Add(kalite);
            }
            return kaliteler;
        }

    }
}
