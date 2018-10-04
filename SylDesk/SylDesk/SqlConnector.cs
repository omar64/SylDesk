using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Forms;

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

        public static void sendMessageBox(string message)
        {
            string messageBoxText = message;
            string caption = "Notice";
            System.Windows.Forms.MessageBox.Show(messageBoxText, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult sendYNMessageBox(string message)
        {
            string messageBoxText = message;
            string caption = "Question";
            DialogResult dr = System.Windows.Forms.MessageBox.Show(messageBoxText, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return dr;
        }

        public static void proyectosGet()
        {

        }

        public static void proyectoGet()
        {

        }

        public static void proyectoPost()
        {

        }

        public static void proyectoPut()
        {

        }

        public static void proyectoDelete()
        {

        }

        public static void proyectoEcuacionesGet()
        {

        }

        public static void proyectoEcuacionPost()
        {

        }

        public static void proyectoEcuacionDelete() //SABE
        {

        }

        public static void sitiosGet()
        {

        }

        public static void sitioGet()
        {

        }

        public static void sitioPost()
        {

        }

        public static void sitioDelete()
        {

        }

        public static void individuosGet()
        {

        }

        public static void individuoGet()
        {

        }

        public static void individuoPost()
        {

        }

        public static void individuoPut()
        {

        }

        public static void individuoDelete()
        {

        }

        public static void familiasGet()
        {

        }

        public static void familiaGet()
        {

        }

        public static void familiaPost()
        {

        }

        public static void familiaDelete() //Sabe
        {

        }

        public static void generosGet()
        {

        }

        public static void generoGet()
        {

        }

        public static void generoPost()
        {

        }

        public static void generoDelete()
        {

        }

        public static void especiesGet()
        {

        }

        public static void especieGet()
        {

        }

        public static void especiePost()
        {

        }

        public static void especiePut() //SABE
        {

        }

        public static void especieDelete()
        {

        }

        public static void ecuacionesVolumenGet()
        {

        }

        public static void ecuacionVolumenGet()
        {

        }

        public static void ecuacionVolumenPost()
        {

        }

        public static void ecuacionVolumenPut()
        {

        }

        public static void ecuacionVolumenDelete()
        {

        }
    }
}