using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Windows;

namespace SylDesk
{
    public partial class FormRegistro1 : UserControl
    {
        private Form1 form1;
        MySqlCommand cmd;

        public FormRegistro1(Form1 form1)
        {
            this.form1 = form1;
            InitializeComponent();
        }

        public void Empty()
        {
            textBoxNombre.Text = "";
            textBoxSector.Text = "";
            textBoxSuperficie.Text = "";
            richTextBoxDescripcion.Text = "";
        }

        private void buttonRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = SqlConnector.getConnection(cmd);

                cmd.CommandText = "Insert into proyectos(nombre, superficie, sector, descripcion)Values(@nombre,@superficie,@sector,@descripcion)";
                cmd.Parameters.AddWithValue("@nombre", textBoxNombre.Text);
                cmd.Parameters.AddWithValue("@superficie", int.Parse(textBoxSuperficie.Text));
                cmd.Parameters.AddWithValue("@sector", textBoxSector.Text);
                cmd.Parameters.AddWithValue("@descripcion", richTextBoxDescripcion.Text);
                cmd.ExecuteNonQuery();

                cmd = SqlConnector.getConnection(cmd);
                string sqlQueryString = "SELECT id from proyectos where nombre = @nombre";
                cmd.CommandText = sqlQueryString;
                cmd.Parameters.AddWithValue("@nombre", textBoxNombre.Text);

                var results = cmd.ExecuteReader();
                results.Read();
                string proyecto_idS = string.Format("{0}", results[0]) + "\n";
                int proyecto_idI = int.Parse(proyecto_idS);
                results.Close();
                results.Dispose();

                cmd = SqlConnector.getConnection(cmd);
                cmd.CommandText = "Insert into sitios(proyecto_id, numero_sitio)Values(@proyecto_id, @numero_sitio)";
                cmd.Parameters.AddWithValue("@proyecto_id", proyecto_idI);
                cmd.Parameters.AddWithValue("@numero_sitio", 1);
                cmd.ExecuteNonQuery();


                /*
                this.Hide(); //esconde el form actual
                FormRegistro2 obj = new FormRegistro2(proyecto_idI, this); //objeto declarado para abrir el form2 proyecto_idI

                obj.Show(); //abre el form declarado con el objeto*/
               
                form1.formRegistro2ToFront(proyecto_idI);
            }
            catch (Exception)
            {

            }
        }

        private void sendMessageBox(string message)
        {
            /*string messageBoxText = message;
            string caption = "Error";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Error;
            System.Windows.MessageBox.Show(messageBoxText, caption, button, icon);*/
        }
    }
}
