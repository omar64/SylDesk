using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
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

        public static void sendMessage(string caption, string message, MessageBoxIcon icon)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, icon);
        }


        public static DialogResult sendOptionsMessage(string caption, string message, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            DialogResult dr = MessageBox.Show(message, caption, buttons, icon);
            return dr;
        }

        public static string getFirstWord(string s)
        {
            string first_word = "";
            if (s.IndexOf(" ") > -1)
            {
                first_word = s.Substring(0, s.IndexOf(" "));
            }
            else
            {
                first_word = s;
            }
            return first_word.Trim();
        }

        public static string[] getWordsDividedByMinus(string s)
        {
            if (s.IndexOf("-") > -1)
            {
                string s1 = s.Substring(0, s.IndexOf("-")).Trim();
                string s2 = s.Substring(s.IndexOf("-") + 1).Trim();

                return new String[] { s1, s2 };
            }
            else
            {
                sendMessage("Error", "El texto debe de tener simbolo \"-\" como separacion", MessageBoxIcon.Error);
                return null;
            }
        }

        ////////////////////////////// any especific value /////////////////////////////////////////////
        public static List<String> anyEspecificValueGet(String query, String[] var_names, String[] var_values)
        {
            List<String> list_values = new List<String>();
            cmd = SqlConnector.getConnection(cmd);
            string sqlQueryString = query;
            cmd.CommandText = sqlQueryString;
            for (int i = 0; i < var_names.Length; i++)
            {
                cmd.Parameters.AddWithValue("@" + var_names[i], var_values[i]);
            }
            MySqlDataReader results = null;
            try
            {
                results = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                return null;
            }
            if(results.Read())
            {
                int j = 0;
                while(true)
                {
                    try
                    {
                        list_values.Add("" + results[j]);
                        j++;
                    }
                    catch (Exception ex)
                    {
                        break;
                    }                
                }
            }

            results.Close();
            results.Dispose();
            return list_values;
        }

        public static List<List<String>> anyEspecificValuesGet(String query, String[] var_names, String[] var_values)
        {
            List<List<String>> list_list_values = new List<List<String>>();
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
                //list_list_values.Add(new List<String>());
                int j = 0;
                List<String> aux = new List<String>();
                while (true)
                {
                    try
                    {
                        //sendMessageBox("" + results[k]);
                        aux.Add("" + results[j]);
                        j++;
                    }
                    catch (Exception ex)
                    {
                        break;
                    }
                }
                list_list_values.Add(aux);
            }

            results.Close();
            results.Dispose();
            return list_list_values;
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
                list_proyectos.Add(new Proyecto(
                    "" + results[0], "" + results[1], "" + results[2], "" + results[3], 
                    "" + results[4], "" + results[5], "" + results[6], "" + results[7], "" + results[8], 
                    "" + results[9], "" + results[10], "" + results[11], "" + results[12], "" + results[13],
                    "" + results[14], "" + results[15], "" + results[16], "" + results[17], "" + results[18],
                    "" + results[19], "" + results[20], "" + results[21], "" + results[22], "" + results[23],
                    "" + results[24], "" + results[25]
                ));
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
            for (int i = 0; i < var_names.Length; i++)
            {
                cmd.Parameters.AddWithValue("@" + var_names[i], var_values[i]);
            }

            var results = cmd.ExecuteReader();
            if (results.Read())
            {
                proyecto = new Proyecto(
                    "" + results[0], "" + results[1], "" + results[2], "" + results[3],
                    "" + results[4], "" + results[5], "" + results[6], "" + results[7], "" + results[8],
                    "" + results[9], "" + results[10], "" + results[11], "" + results[12], "" + results[13],
                    "" + results[14], "" + results[15], "" + results[16], "" + results[17], "" + results[18],
                    "" + results[19], "" + results[20], "" + results[21], "" + results[22], "" + results[23],
                    "" + results[24], "" + results[25]
                );
            }
            results.Close();
            results.Dispose();

            return proyecto;
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

        public static ProyectoEcuacion proyectoEcuacionGet(String query, String[] var_names, String[] var_values)
        {
            ProyectoEcuacion proyecto_ecuacion = null;
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
                proyecto_ecuacion = new ProyectoEcuacion("" + results[0], "" + results[1], "" + results[2]);
            }
            results.Close();
            results.Dispose();
            return proyecto_ecuacion;
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
                list_sitios.Add(new Sitio(
                    "" + results[0], "" + results[1], "" + results[2], "" + results[3], "" + results[4], 
                    "" + results[5], "" + results[6], "" + results[7], "" + results[8], "" + results[9]
                ));
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
                sitio = new Sitio(
                    "" + results[0], "" + results[1], "" + results[2], "" + results[3], "" + results[4], 
                    "" + results[5], "" + results[6], "" + results[7], "" + results[8], "" + results[9]
                );
            }

            results.Close();
            results.Dispose();
            return sitio;
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

        ////////////////////////////// Ecuaciones Volumen /////////////////////////////////////////////

        public static List<EcuacionVolumen> ecuacionesVolumenGet(String query, String[] var_names, String[] var_values)
        {
            List<EcuacionVolumen> list_ecuaciones_volumen = new List<EcuacionVolumen>();
            cmd = SqlConnector.getConnection(cmd);
            string sqlQueryString = query;
            cmd.CommandText = sqlQueryString;

            if (var_names != null)
            {
                for (int i = 0; i < var_names.Length; i++)
                {
                    cmd.Parameters.AddWithValue("@" + var_names[i], var_values[i]);
                }
            }

            var results = cmd.ExecuteReader();
            while (results.Read())
            {
                list_ecuaciones_volumen.Add(new EcuacionVolumen("" + results[0], "" + results[1], "" + results[2], "" + results[3], "" + results[4]));
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
                ecuacion_volumen = new EcuacionVolumen("" + results[0], "" + results[1], "" + results[2], "" + results[3], "" + results[4]);
            }
            results.Close();
            results.Dispose();
            return ecuacion_volumen;
        }

        ////////////////////////////// Post Put Delete Generico /////////////////////////////////////////////

        public static void postPutDeleteGenerico(String query, String[] var_names, String[] var_values)
        {
            cmd = SqlConnector.getConnection(cmd);
            cmd.CommandText = query;
            for (int i = 0; i < var_names.Length; i++)
            {
                string s = var_values[i].Trim();
                if (!string.IsNullOrEmpty(s))
                {
                    s = char.ToUpper(s[0]) + s.Substring(1).ToLower();
                }
                
                cmd.Parameters.AddWithValue("@" + var_names[i], s);
            }
            cmd.ExecuteNonQuery();
        }
    }
}