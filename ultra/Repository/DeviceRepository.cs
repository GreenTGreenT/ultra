using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace device.Repository
{
    public class DeviceRepository
    {
        public static DataSet ReadData(string SQL)
        {
            DataSet ds = new DataSet();
            string connect = "Server=localhost;Database=lightdb;Uid=root;Pwd=;";
            MySqlConnection conn = new MySqlConnection(connect);
            //conn.ConnectionString = connect;

            try
            {
                conn.Open();
                MySqlDataAdapter dap = new MySqlDataAdapter(SQL, conn);
                dap.Fill(ds);
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
            finally
            {
                conn.Close();
            }



            return ds;
        }
    }
}