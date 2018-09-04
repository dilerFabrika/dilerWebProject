using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;
using System.Data;

namespace diler.Bll
{
    public class OracleConnect
    {
        public string datasource,username,password;
        public OracleConnection conn = new OracleConnection();
        public OracleCommand cmd = new OracleCommand();
        public OracleDataAdapter da = new OracleDataAdapter();
        public DataSet ds = new DataSet();
        public DataRow dr;
        public OracleDataReader MyDataReader;
        public OracleDataReader MyDataReader2;
        public object GeriDonenRakam;
        public string GeriDonenString;
        public void DbBaglan()
        {
            try
            {
                string connectionString = "Data Source=(DESCRIPTION=" +
                    "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.198.191)(PORT=1521)))" +
                    "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=DLRORA)));" + "User Id=URTHRK;Password=URTHRK;";
                conn = (new OracleConnection(connectionString));
                cmd.Connection = conn;
                conn.Open();
            }
            catch
            {
                throw new System.InvalidOperationException("Veri Tabani baglantisi kurulamiyor!");

            }
        }
        public void RaporWhile(string GelenTxt)
        {
           
            OracleCommand ObjS1 = new OracleCommand(GelenTxt, cmd.Connection);
            MyDataReader = ObjS1.ExecuteReader();
        }
        public void RaporWhile2(string GelenTxt)
        {
            OracleCommand ObjRS1 = new OracleCommand(GelenTxt, cmd.Connection);
            MyDataReader2 = ObjRS1.ExecuteReader();

        }
        public void Delete(string GelenTxt)
        {

            try
            {
                OracleCommand ObjS1 = new OracleCommand(GelenTxt, cmd.Connection);
                GeriDonenRakam = ObjS1.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                GeriDonenRakam = 0;
            }

        }
        public void Sayac(string GelenTxt)
        {
            try
            {
                OracleCommand ObjRS1 = new OracleCommand(GelenTxt, cmd.Connection);
                GeriDonenRakam = ObjRS1.ExecuteScalar();

            }
            catch (Exception ex)
            {
                GeriDonenRakam = 0;
            }

        }
        public void SaveUpdate(string GelenTxt)
        {
            try
            {
                OracleCommand ObjRS1 = new OracleCommand(GelenTxt, cmd.Connection);
                GeriDonenRakam = ObjRS1.ExecuteNonQuery();             

            }
            catch (Exception ex)
            {
                GeriDonenRakam = 0;
            }

        }
        public void Close()
        {
            conn.Close();
        }
    }
}

