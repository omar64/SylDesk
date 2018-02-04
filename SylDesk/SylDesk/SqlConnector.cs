using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Windows;


namespace SylDesk
{
    class SqlConnector
    {
        private static String MyConnectionString = "Server=localhost;Database=syldesk_db;Uid=root;Pwd='';";
        private static MySqlConnection connection;

        public static void InitializeConnection()
        {
            SqlConnector.connection = new MySqlConnection(MyConnectionString);
            SqlConnector.connection.Open();
        }

        public static MySqlCommand getConnection(MySqlCommand cmd)
        {
            return SqlConnector.connection.CreateCommand();
        }

        public static void closeConnection(MySqlCommand cmd)
        {
            SqlConnector.connection.Close();
            SqlConnector.connection.Dispose();
        }

    }
}
