using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TP.DAO
{
    public class DAO
    {
        private static string connectionString = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=tp;Integrated Security=True;Pooling=False";
        public SqlConnection Connection { get; set; }
        public void Connect()
        {
            Connection = new SqlConnection(connectionString);
            Connection.Open();
        }

        public void Disconnect()
        {
            Connection.Close();
        }

    }
}