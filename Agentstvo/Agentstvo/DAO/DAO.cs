using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Agentstvo.DAO
{
    public class DAO
    {
        private static string connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=C:\Users\Димасик\Desktop\Agentstvo\Agentstvo\App_Data\aspnet-Agentstvo-20181118052359.mdf;Initial Catalog=aspnet-Agentstvo-20181118052359;Integrated Security=True";
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