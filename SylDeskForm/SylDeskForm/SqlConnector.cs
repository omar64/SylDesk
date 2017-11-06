using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Windows;

namespace SylDeskForm
{
    public static class SqlConnector
    {
        private static String MyConnectionString = "Server=localhost;Database=syldesk_db;Uid=root;Pwd='';";
        private static MySqlConnection connection;

        public static void InitializeConnection()
        {
            SqlConnector.connection = new MySqlConnection(MyConnectionString);
            SqlConnector.connection.Open();
        }

        public static MySqlConnection getConnection()
        {
            return SqlConnector.connection;
        }
    }
}
