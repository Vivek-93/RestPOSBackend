using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace RestApies.Models.Database
{
    public class SQLConnection
    {
        public static readonly string connectionString = ConfigurationManager.ConnectionStrings["SqlServerConnection"].ToString();
        public static SqlConnection GetOpenSQLConnection(bool mars = false)
        {
            var cs = connectionString;
            if (mars)
            {
                SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder(cs);
                scsb.MultipleActiveResultSets = true;
                scsb.ConnectTimeout = 0;
                cs = scsb.ConnectionString;
            }
            var connection = new SqlConnection(cs);

            connection.Open();
            return connection;
        }
        public static SqlConnection GetClosedConnection()
        {
            return new SqlConnection(connectionString);
        }


    }
}