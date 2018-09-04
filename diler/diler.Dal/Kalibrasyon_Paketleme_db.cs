using diler.Entity;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;

namespace diler.Dal
{

    public class Kalibrasyon_Paketleme_db
    {


        OracleConnection conn, conn2;
        string connetionString, sql;
        OracleCommand cmd;
        OracleDataReader dr;

        public Kalibrasyon_Paketleme_db()
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
        public void Disconnect()
        {
            if (this.conn.State == System.Data.ConnectionState.Open)
            {
                this.conn.Close();
            }
        }

        public List<PaketlemeRapor> datalarKalibrasyon(int tarih1 = 0, int tarih2 = 0, int Yol = 1)
        {

            List<PaketlemeRapor> kayitlar = new List<PaketlemeRapor>();

            this.sql = "SELECT tarih,vrd,yol,KALIBRE_TNM,TONAJ,KAYIT_SAAT from URTHRK.PAKETLEME_KALIBRASYON" +
                       " WHERE ";
            if (tarih1 > 0)
            {
                this.sql += "  TARIH between  " + tarih1 + " and " + tarih2;
            }

            if ( Yol != 0) { this.sql += " AND YOL=" + Yol; }

            this.sql += "  ORDER BY VRD,YOL";

            this.cmd.CommandText = this.sql;
            this.cmd.Parameters.Clear();
            this.dr = this.cmd.ExecuteReader();

            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                PaketlemeRapor kayit = new PaketlemeRapor();
                kayit.Aciklama = "Listelenecek Kayıt Bulunamadı !!";
                kayitlar.Add(kayit);
            }

            else

            {
                while (this.dr.Read())
                {
                    PaketlemeRapor kayit = new PaketlemeRapor();
                    kayit.Tarih = Convert.ToInt32(this.dr[0]);
                    kayit.Vrd = Convert.ToInt16(this.dr[1]);
                    kayit.Yol = Convert.ToInt16(this.dr[2]);
                    kayit.KalibreTnm = this.dr[3].ToString();
                    kayit.Tonaj = this.dr[4].ToString(); ;
                    kayit.Saat = this.dr[5].ToString();

                    kayitlar.Add(kayit);
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;


        }

        public List<PaketlemeRapor> datalar(int tarih1 = 0, int tarih2 = 0, string CmbYer="", int Yol = 1, int Vardiyamız=0, string TxtBoy="", string TxtCap="", string TxtSip="", string TxtLot="")
        {

            List<PaketlemeRapor> kayitlar = new List<PaketlemeRapor>();

            this.sql = "";

            this.sql = " SELECT TARIH ,SIPNUM, LOT, DNO, VRD, YOL, cap,boy,standart, YER, Sum(AGIRLIK) , Count(PAKETSAYISI),round(AVG(AGIRLIK),0) From URTHRK.PAKETLEME_v " +
                " WHERE TARIH BETWEEN " + tarih1 + " AND " + tarih2;

            if (Vardiyamız != 0)
            {
                this.sql = this.sql + " AND VRD=" + Vardiyamız;
            }

            if (Yol != 0)
            {
                this.sql = this.sql + " AND YOL=" + Yol;
            }


            if (CmbYer == "İHRACAT" || CmbYer == "KISA PARÇA" || CmbYer == "STANDART DIŞI" || CmbYer == "İÇ PİYASA")
            {
                this.sql = this.sql + " AND YER='" + CmbYer + "'";
            }
            if (CmbYer == "PAKETLEME")
            {

            }

            if (TxtBoy != "")
            {
                this.sql = this.sql + " AND BOY='" + TxtBoy + "'";
            }
            if (TxtCap != "")
            {
                this.sql = this.sql + " AND CAP='" + TxtCap + "'";
            }

            if (TxtSip != "")
            {
                this.sql = this.sql + " AND SIPNUM='" + TxtSip +"'" ;
            }

            if (TxtLot != "")
            {
                this.sql = this.sql + " AND LOT='" + TxtLot + "'";
            }

          




            this.sql = this.sql + "  GROUP BY SIPNUM, LOT, DNO, VRD, YOL, CAP, BOY, standart, YER, TARIH" +
             " ORDER  BY TARIH,VRD,YOL,CAP, BOY, standart, YER";


            this.cmd.CommandText = this.sql;
            this.cmd.Parameters.Clear();
            this.dr = this.cmd.ExecuteReader();

            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                PaketlemeRapor kayit = new PaketlemeRapor();
                kayit.Aciklama = "Listelenecek Kayıt Bulunamadı !!";
                kayitlar.Add(kayit);
            }

            else

            {
                while (this.dr.Read())
                {
                    PaketlemeRapor kayit = new PaketlemeRapor();
                

                        kayit.Tarih = Convert.ToInt32((this.dr[0]));
                        kayit.Sipno = (this.dr[1].ToString());
                        kayit.Lot = this.dr[2].ToString();
                        kayit.Dno = Convert.ToInt32(this.dr[3]);
                        kayit.Vrd = Convert.ToInt16(this.dr[4]);
                        kayit.Yol = Convert.ToInt16(this.dr[5]);
                        kayit.Cap = (this.dr[6]).ToString();
                        kayit.Boy = (this.dr[7]).ToString();
                        kayit.Kalite = (this.dr[8]).ToString();
                        kayit.KalibreTnm = this.dr[9].ToString();// paket yeri
                        kayit.Tonaj = this.dr[10].ToString(); ;//tartım
                        kayit.Paketsayisi = Convert.ToInt32(this.dr[11]);
                        kayit.Ortalama = Convert.ToDecimal(this.dr[12]);

                    kayitlar.Add(kayit);
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;

        }
        public List<PaketlemeRapor> datalarStok(int tarih1 = 0, int tarih2 = 0)
        {

            List<PaketlemeRapor> kayitlar = new List<PaketlemeRapor>();

            this.sql = "";

         
                this.sql = " SELECT TARIH ,SIPNUM, LOT,  VRD,YOL,  cap,boy,standart, YER, Sum(AGIRLIK) , Count(PAKETSAYISI),round(AVG(AGIRLIK),0) From URTHRK.PAKETLEME_v " +
             " WHERE TARIH BETWEEN " + tarih1 + " AND " + tarih2 +
             " GROUP BY SIPNUM, LOT,  VRD,YOL,  CAP, BOY, standart, YER, TARIH" +
             " ORDER  BY YER ASC,STANDART,CAP,BOY,SIPNUM,LOT";
         
            this.cmd.CommandText = this.sql;
            this.cmd.Parameters.Clear();
            this.dr = this.cmd.ExecuteReader();

            if (!this.dr.HasRows)
            {
                //kayit bulunamadiysa
                PaketlemeRapor kayit = new PaketlemeRapor();
                kayit.Aciklama = "Listelenecek Kayıt Bulunamadı !!";
                kayitlar.Add(kayit);
            }

            else

            {
                while (this.dr.Read())
                {
                    PaketlemeRapor kayit = new PaketlemeRapor();
                   
                        kayit.Tarih = Convert.ToInt32((this.dr[0]));
                        kayit.Sipno = (this.dr[1].ToString());
                        kayit.Lot = this.dr[2].ToString();
                        kayit.Vrd = Convert.ToInt16(this.dr[3]);
                        kayit.Yol = Convert.ToInt16(this.dr[4]);
                        kayit.Cap = (this.dr[5]).ToString();
                        kayit.Boy = (this.dr[6]).ToString();
                        kayit.Kalite = (this.dr[7]).ToString();
                        kayit.KalibreTnm = this.dr[8].ToString();// paket yeri
                        kayit.Tonaj = this.dr[9].ToString(); ;//tartım
                        kayit.Paketsayisi = Convert.ToInt32(this.dr[10]);
                        kayit.Ortalama = Convert.ToDecimal(this.dr[11]);
                                       
                    kayitlar.Add(kayit);
                }
            }
            this.dr.Close();
            this.dr.Dispose();

            return kayitlar;

        }

        public List<PaketlemeRapor> PaketlemeOzet(int tarih1 = 0, int tarih2 = 0)

        {


                Decimal T1_ = 0;
            Decimal T2_ = 0;
            Decimal T3_ = 0;
            Decimal T4_ = 0;
            Decimal T5_ = 0;
            Decimal T6_ = 0;
            Decimal T7_ = 0;
            Decimal T8_ = 0;
            Decimal T9_ = 0;
            Decimal T10_ = 0;
            Decimal T11_ = 0;
            Decimal T12_ = 0;
            Decimal T13_ = 0;
            Decimal T14_ = 0;
          

                this.sql = " SELECT YOL,SUM(AGIRLIK)/1000 FROM URTHRK.PAKETLEME" +
             " WHERE TARIH BETWEEN " + tarih1 + " AND " + tarih2 +
             " AND YER<>'KISA PARÇA'" +
             " GROUP BY YOL";

                this.cmd.CommandText = this.sql;
                this.cmd.Parameters.Clear();
                this.dr = this.cmd.ExecuteReader();

                if (!this.dr.HasRows)
                {
                }

                else

                {
                    while (this.dr.Read())
                    {
                        if (this.dr[0].ToString() == "1") { T1_ = Convert.ToDecimal(this.dr[1]); }
                        if (this.dr[0].ToString() == "2") { T2_ = Convert.ToDecimal(this.dr[1]); }
                    }
                }
                this.dr.Close();
                this.dr.Dispose();

                //**********************************************************/

                this.sql = " SELECT YOL,SUM(AGIRLIK)/1000 FROM URTHRK.PAKETLEME" +
                            " WHERE TARIH BETWEEN " + tarih1 + " AND " + tarih2 +
                            " AND YER='KISA PARÇA'" +
                            " GROUP BY YOL";

                this.cmd.CommandText = this.sql;
                this.cmd.Parameters.Clear();
                this.dr = this.cmd.ExecuteReader();

                if (!this.dr.HasRows)
                {
                }

                else

                {
                    while (this.dr.Read())
                    {
                        if (this.dr[0].ToString() == "1") { T4_ = Convert.ToDecimal(this.dr[1]); }
                        if (this.dr[0].ToString() == "2") { T5_ = Convert.ToDecimal(this.dr[1]); }
                    }
                }
                this.dr.Close();
                this.dr.Dispose();

                //*****************************************************************//

                this.sql = " SELECT YOL,SUM(KISAPARCA)/1000 FROM URTHRK.HHTARTHBKP" +
                           " WHERE TARIH BETWEEN " + tarih1 + " AND " + tarih2 +
                           " GROUP BY YOL";

                this.cmd.CommandText = this.sql;
                this.cmd.Parameters.Clear();
                this.dr = this.cmd.ExecuteReader();

                if (!this.dr.HasRows)
                {
                }

                else

                {
                    while (this.dr.Read())
                    {
                        if (this.dr[0].ToString() == "1") { T11_ = Convert.ToDecimal(this.dr[1]); }
                        if (this.dr[0].ToString() == "2") { T12_ = Convert.ToDecimal(this.dr[1]); }
                    }
                }
                this.dr.Close();
                this.dr.Dispose();

            //*****************************************************************//


            //*****************************************************************//
            try
            {
                this.sql = " SELECT SUM(KISAPARCA)/1000 FROM URTHRK.HHTARTHBKP" +
                           " WHERE TARIH BETWEEN " + tarih1 + " AND " + tarih2;

                this.cmd.CommandText = this.sql;
                this.cmd.Parameters.Clear();
                this.dr = this.cmd.ExecuteReader();

                if (!this.dr.HasRows)
                {
                }

                else

                {
                    while (this.dr.Read())
                    {
                        T13_ = Convert.ToDecimal(this.dr[0]);
                    }
                }
                this.dr.Close();
                this.dr.Dispose();

                }

            catch(Exception hata)
            {

            }

                //*****************************************************************//





                PaketlemeRapor kayit = new PaketlemeRapor();
                kayit.T1 = T1_;
                kayit.T2 = T2_;
                kayit.T3 = T1_ + T2_;

                kayit.T4 = T4_;
                kayit.T5 = T5_;
                kayit.T6 = T4_ + T5_;

                kayit.T7 = T1_ + T2_ + T4_ + T5_;

                kayit.T11 = T11_;
                kayit.T12 = T12_;
                kayit.T13 = T13_;

                kayit.T8 = kayit.T1;
                kayit.T9 = kayit.T2;
                kayit.T10 = kayit.T3;

                kayit.T14 = kayit.T10 + kayit.T13;


                List<PaketlemeRapor> kayitlar = new List<PaketlemeRapor>();
                kayitlar.Add(kayit);
                return kayitlar;

        
        }
    }
}
