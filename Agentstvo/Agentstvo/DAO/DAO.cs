﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Agentstvo.DAO
{
    public class DAO
    {
        private static string connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=C:\Users\Димасик\Desktop\KP_TP\KP_TP\Agentstvo\Agentstvo\App_Data\aspnet-Agentstvo-20181118052359.mdf;Initial Catalog=aspnet-Agentstvo-20181118052359;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework";
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