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
        private static MySqlCommand cmd;

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

        ////////////////////////////// Proyectos /////////////////////////////////////////////

        public static List<Proyecto> proyectosGet(String query, String[] var_names, String[] var_values)
        {
            List<Proyecto> list_proyectos = new List<Proyecto>();
            cmd = SqlConnector.getConnection(cmd);
            string sqlQueryString = query;
            cmd.CommandText = sqlQueryString;
            for (int i = 0; i < var_names.Length; i++)
            {
                cmd.Parameters.AddWithValue("@" + var_names[i], var_values[i]);
            }

            var results = cmd.ExecuteReader();
            while (results.Read())
            {
                list_proyectos.Add(new Proyecto("" + results[0], "" + results[1], "" + results[2], "" + results[3], "" + results[4], "" + results[5], "" + results[6]));
            }
            results.Close();
            results.Dispose();
            return list_proyectos;
        }


        public static Proyecto proyectoGet(String query, String[] var_names, String[] var_values)
        {
            Proyecto proyecto = null;
            cmd = SqlConnector.getConnection(cmd);
            string sqlQueryString = query;
            cmd.CommandText = sqlQueryString;
            sendMessageBox("" + var_names.Length);
            for (int i = 0; i < var_names.Length; i++)
            {
                cmd.Parameters.AddWithValue("@" + var_names[i], var_values[i]);
            }

            sendMessageBox("k");
            var results = cmd.ExecuteReader();
            sendMessageBox("hoo yu");
            if (results.Read())
            {
                sendMessageBox("resultsss" + results[0]);
                proyecto = new Proyecto("" + results[0], "" + results[1], "" + results[2], "" + results[3], "" + results[4], "" + results[5], "" + results[6]);
            }
            sendMessageBox("y no onsuer");
            results.Close();
            results.Dispose();
            sendMessageBox("pls");

            return proyecto;
        }


        public static void proyectoPost(String query, String[] var_names, String[] var_values)
        {
            cmd = SqlConnector.getConnection(cmd);

            cmd.CommandText = query;
            for (int i = 0; i < var_names.Length; i++)
            {
                cmd.Parameters.AddWithValue("@" + var_names[i], var_values[i]);
            }
            cmd.ExecuteNonQuery();
        }

        public static void proyectoPut(String query, String[] var_names, String[] var_values)
        {
            cmd = SqlConnector.getConnection(cmd);
            cmd.CommandText = query;
            for (int i = 0; i < var_names.Length; i++)
            {
                cmd.Parameters.AddWithValue("@" + var_names[i], var_values[i]);
            }
            cmd.ExecuteNonQuery();
        }

        public static void proyectoDelete(String query, String[] var_names, String[] var_values)
        {
            cmd = SqlConnector.getConnection(cmd);
            cmd.CommandText = query;
            for (int i = 0; i < var_names.Length; i++)
            {
                cmd.Parameters.AddWithValue("@" + var_names[i], var_values[i]);
            }
            cmd.ExecuteNonQuery();
        }

        ////////////////////////////// Proyecto Ecuaciones /////////////////////////////////////////////

        public static List<ProyectoEcuacion> proyectoEcuacionesGet(String query, String[] var_names, String[] var_values)
        {
            List<ProyectoEcuacion> list_proyecto_ecuaciones = new List<ProyectoEcuacion>();
            cmd = SqlConnector.getConnection(cmd);
            string sqlQueryString = query;
            cmd.CommandText = sqlQueryString;
            for (int i = 0; i < var_names.Length; i++)
            {
                cmd.Parameters.AddWithValue("@" + var_names[i], var_values[i]);
            }

            var results = cmd.ExecuteReader();
            while (results.Read())
            {
                list_proyecto_ecuaciones.Add(new ProyectoEcuacion("" + results[0], "" + results[1], "" + results[2]));
            }
            results.Close();
            results.Dispose();
            return list_proyecto_ecuaciones;
        }

        public static void proyectoEcuacionPost(String query, String[] var_names, String[] var_values)
        {
            cmd = SqlConnector.getConnection(cmd);
            cmd.CommandText = query;
            for (int i = 0; i < var_names.Length; i++)
            {
                cmd.Parameters.AddWithValue("@" + var_names[i], var_values[i]);
            }
            cmd.ExecuteNonQuery();
        }

        public static void proyectoEcuacionDelete(String query, String[] var_names, String[] var_values)
        {
            cmd = SqlConnector.getConnection(cmd);
            cmd.CommandText = query;
            for (int i = 0; i < var_names.Length; i++)
            {
                cmd.Parameters.AddWithValue("@" + var_names[i], var_values[i]);
            }
            cmd.ExecuteNonQuery();
        }

        ////////////////////////////// Sitios /////////////////////////////////////////////

        public static List<Sitio> sitiosGet(String query, String[] var_names, String[] var_values)
        {
            List<Sitio> list_sitios = new List<Sitio>();
            cmd = SqlConnector.getConnection(cmd);
            string sqlQueryString = query;
            cmd.CommandText = sqlQueryString;
            for (int i = 0; i < var_names.Length; i++)
            {
                cmd.Parameters.AddWithValue("@" + var_names[i], var_values[i]);
            }

            var results = cmd.ExecuteReader();
            while (results.Read())
            {
                list_sitios.Add(new Sitio("" + results[0], "" + results[1], "" + results[2], "" + results[3], "" + results[4], "" + results[5], "" + results[6], "" + results[7], "" + results[8], "" + results[9]));
            }
            results.Close();
            results.Dispose();
            return list_sitios;
        }

        public static Sitio sitioGet(String query, String[] var_names, String[] var_values)
        {
            Sitio sitio = null;
            cmd = SqlConnector.getConnection(cmd);
            string sqlQueryString = query;
            cmd.CommandText = sqlQueryString;
            for (int i = 0; i < var_names.Length; i++)
            {
                cmd.Parameters.AddWithValue("@" + var_names[i], var_values[i]);
            }

            var results = cmd.ExecuteReader();
            if(results.Read())
            {
                sitio = new Sitio("" + results[0], "" + results[1], "" + results[2], "" + results[3], "" + results[4], "" + results[5], "" + results[6], "" + results[7], "" + results[8], "" + results[9]);
            }
            results.Close();
            results.Dispose();
            return sitio;
        }

        public static void sitioPost(String query, String[] var_names, String[] var_values)
        {
            cmd = SqlConnector.getConnection(cmd);
            cmd.CommandText = query;
            for (int i = 0; i < var_names.Length; i++)
            {
                cmd.Parameters.AddWithValue("@" + var_names[i], var_values[i]);
            }
            cmd.ExecuteNonQuery();
        }

        public static void sitioDelete(String query, String[] var_names, String[] var_values)
        {
            cmd = SqlConnector.getConnection(cmd);
            cmd.CommandText = query;
            for (int i = 0; i < var_names.Length; i++)
            {
                cmd.Parameters.AddWithValue("@" + var_names[i], var_values[i]);
            }
            cmd.ExecuteNonQuery();
        }

        ////////////////////////////// Individuos /////////////////////////////////////////////

        public static List<Individuo> individuosGet(String query, String[] var_names, String[] var_values)
        {
            List<Individuo> list_individuos = new List<Individuo>();
            cmd = SqlConnector.getConnection(cmd);
            string sqlQueryString = query;
            cmd.CommandText = sqlQueryString;
            for (int i = 0; i < var_names.Length; i++)
            {
                cmd.Parameters.AddWithValue("@" + var_names[i], var_values[i]);
            }

            var results = cmd.ExecuteReader();
            while (results.Read())
            {
                list_individuos.Add(new Individuo("" + results[0], "" + results[1], "" + results[2], "" + results[3], "" + results[4], "" + results[5], "" + results[6], "" + results[7], "" + results[8], "" + results[9], "" + results[10], "" + results[11], "" + results[12], "" + results[13], "" + results[14], "" + results[15], "" + results[16], "" + results[17], "" + results[18], "" + results[19], "" + results[20], "" + results[21], "" + results[22], "" + results[23], "" + results[24], "" + results[25], "" + results[26]));
            }
            results.Close();
            results.Dispose();
            return list_individuos;
        }

        public static Individuo individuoGet(String query, String[] var_names, String[] var_values)
        {
            Individuo individuo = null;
            cmd = SqlConnector.getConnection(cmd);
            string sqlQueryString = query;
            cmd.CommandText = sqlQueryString;
            for (int i = 0; i < var_names.Length; i++)
            {
                cmd.Parameters.AddWithValue("@" + var_names[i], var_values[i]);
            }

            var results = cmd.ExecuteReader();
            if(results.Read())
            {
                individuo = new Individuo("" + results[0], "" + results[1], "" + results[2], "" + results[3], "" + results[4], "" + results[5], "" + results[6], "" + results[7], "" + results[8], "" + results[9], "" + results[10], "" + results[11], "" + results[12], "" + results[13], "" + results[14], "" + results[15], "" + results[16], "" + results[17], "" + results[18], "" + results[19], "" + results[20], "" + results[21], "" + results[22], "" + results[23], "" + results[24], "" + results[25], "" + results[26]);
            }
            results.Close();
            results.Dispose();
            return individuo;
        }

        public static void individuoPost(String query, String[] var_names, String[] var_values)
        {
            cmd = SqlConnector.getConnection(cmd);
            cmd.CommandText = query;
            for (int i = 0; i < var_names.Length; i++)
            {
                cmd.Parameters.AddWithValue("@" + var_names[i], var_values[i]);
            }
            cmd.ExecuteNonQuery();
        }

        public static void individuoPut(String query, String[] var_names, String[] var_values)
        {
            cmd = SqlConnector.getConnection(cmd);
            cmd.CommandText = query;
            for (int i = 0; i < var_names.Length; i++)
            {
                cmd.Parameters.AddWithValue("@" + var_names[i], var_values[i]);
            }
            cmd.ExecuteNonQuery();
        }

        public static void individuoDelete(String query, String[] var_names, String[] var_values)
        {
            cmd = SqlConnector.getConnection(cmd);
            cmd.CommandText = query;
            for (int i = 0; i < var_names.Length; i++)
            {
                cmd.Parameters.AddWithValue("@" + var_names[i], var_values[i]);
            }
            cmd.ExecuteNonQuery();
        }

        ////////////////////////////// Familias /////////////////////////////////////////////

        public static List<Familia> familiasGet(String query, String[] var_names, String[] var_values)
        {
            List<Familia> list_familias = new List<Familia>();
            cmd = SqlConnector.getConnection(cmd);
            string sqlQueryString = query;
            cmd.CommandText = sqlQueryString;
            for (int i = 0; i < var_names.Length; i++)
            {
                cmd.Parameters.AddWithValue("@" + var_names[i], var_values[i]);
            }

            var results = cmd.ExecuteReader();
            while (results.Read())
            {
                list_familias.Add(new Familia("" + results[0], "" + results[1]));
            }
            results.Close();
            results.Dispose();
            return list_familias;
        }

        public static Familia familiaGet(String query, String[] var_names, String[] var_values)
        {
            Familia familia = null;
            cmd = SqlConnector.getConnection(cmd);
            string sqlQueryString = query;
            cmd.CommandText = sqlQueryString;
            for (int i = 0; i < var_names.Length; i++)
            {
                cmd.Parameters.AddWithValue("@" + var_names[i], var_values[i]);
            }

            var results = cmd.ExecuteReader();
            if(results.Read())
            {
                familia = new Familia("" + results[0], "" + results[1]);
            }
            results.Close();
            results.Dispose();
            return familia;
        }

        public static void familiaPost(String query, String[] var_names, String[] var_values)
        {
            cmd = SqlConnector.getConnection(cmd);
            cmd.CommandText = query;
            for (int i = 0; i < var_names.Length; i++)
            {
                cmd.Parameters.AddWithValue("@" + var_names[i], var_values[i]);
            }
            cmd.ExecuteNonQuery();
        }

        public static void familiaDelete(String query, String[] var_names, String[] var_values)
        {
            cmd = SqlConnector.getConnection(cmd);
            cmd.CommandText = query;
            for (int i = 0; i < var_names.Length; i++)
            {
                cmd.Parameters.AddWithValue("@" + var_names[i], var_values[i]);
            }
            cmd.ExecuteNonQuery();
        }

        ////////////////////////////// Generos /////////////////////////////////////////////

        public static List<Genero> generosGet(String query, String[] var_names, String[] var_values)
        {
            List<Genero> list_generos = new List<Genero>();
            cmd = SqlConnector.getConnection(cmd);
            string sqlQueryString = query;
            cmd.CommandText = sqlQueryString;
            for (int i = 0; i < var_names.Length; i++)
            {
                cmd.Parameters.AddWithValue("@" + var_names[i], var_values[i]);
            }

            var results = cmd.ExecuteReader();
            while (results.Read())
            {
                list_generos.Add(new Genero("" + results[0], "" + results[1], "" + results[2]));
            }
            results.Close();
            results.Dispose();
            return list_generos;
        }

        public static Genero generoGet(String query, String[] var_names, String[] var_values)
        {
            Genero genero = null;
            cmd = SqlConnector.getConnection(cmd);
            string sqlQueryString = query;
            cmd.CommandText = sqlQueryString;
            for (int i = 0; i < var_names.Length; i++)
            {
                cmd.Parameters.AddWithValue("@" + var_names[i], var_values[i]);
            }

            var results = cmd.ExecuteReader();
            while (results.Read())
            {
                genero = new Genero("" + results[0], "" + results[1], "" + results[2]);
            }
            results.Close();
            results.Dispose();
            return genero;
        }

        public static void generoPost(String query, String[] var_names, String[] var_values)
        {
            cmd = SqlConnector.getConnection(cmd);
            cmd.CommandText = query;
            for (int i = 0; i < var_names.Length; i++)
            {
                cmd.Parameters.AddWithValue("@" + var_names[i], var_values[i]);
            }
            cmd.ExecuteNonQuery();
        }

        public static void generoDelete(String query, String[] var_names, String[] var_values)
        {
            cmd = SqlConnector.getConnection(cmd);
            cmd.CommandText = query;
            for (int i = 0; i < var_names.Length; i++)
            {
                cmd.Parameters.AddWithValue("@" + var_names[i], var_values[i]);
            }
            cmd.ExecuteNonQuery();
        }

        ////////////////////////////// Especies /////////////////////////////////////////////

        public static List<Especie> especiesGet(String query, String[] var_names, String[] var_values)
        {
            List<Especie> list_especies = new List<Especie>();
            cmd = SqlConnector.getConnection(cmd);
            string sqlQueryString = query;
            cmd.CommandText = sqlQueryString;
            for (int i = 0; i < var_names.Length; i++)
            {
                cmd.Parameters.AddWithValue("@" + var_names[i], var_values[i]);
            }

            var results = cmd.ExecuteReader();
            while (results.Read())
            {
                list_especies.Add(new Especie("" + results[0], "" + results[1], "" + results[2], "" + results[3], "" + results[4], "" + results[5], "" + results[6]));
            }
            results.Close();
            results.Dispose();
            return list_especies;
        }

        public static Especie especieGet(String query, String[] var_names, String[] var_values)
        {
            Especie especie = null;
            cmd = SqlConnector.getConnection(cmd);
            string sqlQueryString = query;
            cmd.CommandText = sqlQueryString;
            for (int i = 0; i < var_names.Length; i++)
            {
                cmd.Parameters.AddWithValue("@" + var_names[i], var_values[i]);
            }

            var results = cmd.ExecuteReader();
            if(results.Read())
            {
                especie = new Especie("" + results[0], "" + results[1], "" + results[2], "" + results[3], "" + results[4], "" + results[5], "" + results[6]);
            }
            results.Close();
            results.Dispose();
            return especie;
        }

        public static void especiePost(String query, String[] var_names, String[] var_values)
        {
            cmd = SqlConnector.getConnection(cmd);
            cmd.CommandText = query;
            for (int i = 0; i < var_names.Length; i++)
            {
                cmd.Parameters.AddWithValue("@" + var_names[i], var_values[i]);
            }
            cmd.ExecuteNonQuery();
        }

        public static void especiePut(String query, String[] var_names, String[] var_values)
        {
            cmd = SqlConnector.getConnection(cmd);
            cmd.CommandText = query;
            for (int i = 0; i < var_names.Length; i++)
            {
                cmd.Parameters.AddWithValue("@" + var_names[i], var_values[i]);
            }
            cmd.ExecuteNonQuery();
        }

        public static void especieDelete(String query, String[] var_names, String[] var_values)
        {
            cmd = SqlConnector.getConnection(cmd);
            cmd.CommandText = query;
            for (int i = 0; i < var_names.Length; i++)
            {
                cmd.Parameters.AddWithValue("@" + var_names[i], var_values[i]);
            }
            cmd.ExecuteNonQuery();
        }

        ////////////////////////////// Ecuaciones Volumen /////////////////////////////////////////////

        public static List<EcuacionVolumen> ecuacionesVolumenGet(String query, String[] var_names, String[] var_values)
        {
            List<EcuacionVolumen> list_ecuaciones_volumen = new List<EcuacionVolumen>();
            cmd = SqlConnector.getConnection(cmd);
            string sqlQueryString = query;
            cmd.CommandText = sqlQueryString;
            for (int i = 0; i < var_names.Length; i++)
            {
                cmd.Parameters.AddWithValue("@" + var_names[i], var_values[i]);
            }

            var results = cmd.ExecuteReader();
            while (results.Read())
            {
                list_ecuaciones_volumen.Add(new EcuacionVolumen("" + results[0], "" + results[1], "" + results[2], "" + results[3], "" + results[4], "" + results[5]));
            }
            results.Close();
            results.Dispose();
            return list_ecuaciones_volumen;
        }

        public static EcuacionVolumen ecuacionVolumenGet(String query, String[] var_names, String[] var_values)
        {
            EcuacionVolumen ecuacion_volumen = null;
            cmd = SqlConnector.getConnection(cmd);
            string sqlQueryString = query;
            cmd.CommandText = sqlQueryString;
            for (int i = 0; i < var_names.Length; i++)
            {
                cmd.Parameters.AddWithValue("@" + var_names[i], var_values[i]);
            }

            var results = cmd.ExecuteReader();
            while (results.Read())
            {
                ecuacion_volumen = new EcuacionVolumen("" + results[0], "" + results[1], "" + results[2], "" + results[3], "" + results[4], "" + results[5]);
            }
            results.Close();
            results.Dispose();
            return ecuacion_volumen;
        }

        public static void ecuacionVolumenPost(String query, String[] var_names, String[] var_values)
        {
            cmd = SqlConnector.getConnection(cmd);
            cmd.CommandText = query;
            for (int i = 0; i < var_names.Length; i++)
            {
                cmd.Parameters.AddWithValue("@" + var_names[i], var_values[i]);
            }
            cmd.ExecuteNonQuery();
        }

        public static void ecuacionVolumenPut(String query, String[] var_names, String[] var_values)
        {
            cmd = SqlConnector.getConnection(cmd);
            cmd.CommandText = query;
            for (int i = 0; i < var_names.Length; i++)
            {
                cmd.Parameters.AddWithValue("@" + var_names[i], var_values[i]);
            }
            cmd.ExecuteNonQuery();
        }

        public static void ecuacionVolumenDelete(String query, String[] var_names, String[] var_values)
        {
            cmd = SqlConnector.getConnection(cmd);
            cmd.CommandText = query;
            for (int i = 0; i < var_names.Length; i++)
            {
                cmd.Parameters.AddWithValue("@" + var_names[i], var_values[i]);
            }
            cmd.ExecuteNonQuery();
        }
    }
}