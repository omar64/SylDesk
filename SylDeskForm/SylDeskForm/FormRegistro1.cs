using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Windows;

namespace SylDeskForm
{
    public partial class FormRegistro1 : System.Windows.Forms.Form
    {
        //String MyConnectionString = "Server=localhost;Database=syldesk_db;Uid=root;Pwd='';";
        int mouseX = 0, mouseY = 0;
        bool mouseDown;
        //MySqlConnection connection;
        MySqlCommand cmd;

        public FormRegistro1()
        {
            InitializeComponent();
            //connection = new MySqlConnection(MyConnectionString);
            //connection.Open();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }



        /*private void labelClose_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }*/

        private void buttonRegistrar_Click(object sender, EventArgs e)
        {
            try
<<<<<<< HEAD
            {
                /*cmd = SqlConnector.getConnection().CreateCommand();

                string messageBoxText = "all gud";
                string caption = "Message Box";
                MessageBoxButton button = MessageBoxButton.YesNoCancel;
                MessageBoxImage icon = MessageBoxImage.Warning;

=======
            {                 
                /*
                cmd = SqlConnector.getConnection(cmd);                
>>>>>>> de3032e7d93b29a14a9bfcf0572c828a1d4312a5
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

<<<<<<< HEAD
                var results = cmd.ExecuteReader();*/

                /*
                string textolargo = "";
                while (results.Read())
                {
                    textolargo += String.Format("{0}", results[0]) + "\n";
                }
                */

                // Configure the message box to be displayed
                /*results.Read();
                string proyecto_idS = string.Format("{0}", results[0]) + "\n";
                int proyecto_idI = int.Parse(proyecto_idS);
                */
                /*
                string messageBoxText = proyecto_idS;
                string caption = "Word Processor";
                MessageBoxButton button = MessageBoxButton.YesNoCancel;
                MessageBoxImage icon = MessageBoxImage.Warning;

                System.Windows.MessageBox.Show(messageBoxText, caption, button, icon);
                */

                this.Hide(); //esconde el form actual


                FormRegistro2 obj = new FormRegistro2(0); //objeto declarado para abrir el form2
=======
                var results = cmd.ExecuteReader();                                
                results.Read();
                string proyecto_idS = string.Format("{0}", results[0]) + "\n";
                int proyecto_idI = int.Parse(proyecto_idS);
                results.Close();
                results.Dispose();

                cmd = SqlConnector.getConnection(cmd);
                cmd.CommandText = "Insert into sitios(proyecto_id, numero_sitio, numero_consecutivo)Values(@proyecto_id, @numero_sitio, @numero_consecutivo)";
                cmd.Parameters.AddWithValue("@proyecto_id", proyecto_idI);
                cmd.Parameters.AddWithValue("@numero_sitio", 1);
                cmd.Parameters.AddWithValue("@numero_consecutivo", 1);
                cmd.ExecuteNonQuery();
                */

                this.Hide(); //esconde el form actual
                FormRegistro2 obj = new FormRegistro2(1); //objeto declarado para abrir el form2 proyecto_idI
>>>>>>> de3032e7d93b29a14a9bfcf0572c828a1d4312a5
                obj.Show(); //abre el form declarado con el objeto
            }
            catch (Exception)
            {

            }
        }

        /*private void labelClose_MouseHover(object sender, EventArgs e)
        {
            this.labelClose.ForeColor=Color.Red;
        }*/

        /*private void labelMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }*/

        /*private void labelClose_MouseLeave(object sender, EventArgs e)
        {
            this.labelClose.ForeColor = Color.Transparent;
        }*/

        /*private void labelMinimize_MouseHover(object sender, EventArgs e)
        {
            this.labelMinimize.ForeColor = Color.Gray;
        }*/

        /*private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }*/

        /*private void panelTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                mouseX = MousePosition.X - 400;
                mouseY = MousePosition.Y - 40;

                this.SetDesktopLocation(mouseX, mouseY);
            }
        }*/

        /*private void panelTop_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }*/

        /*private void labelMinimize_MouseLeave(object sender, EventArgs e)
        {
            this.labelMinimize.ForeColor = Color.Transparent;
        }*/
    }
}
