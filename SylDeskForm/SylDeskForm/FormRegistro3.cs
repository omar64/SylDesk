using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace SylDeskForm
{
    public partial class FormRegistro3 : Form
    {

        MySqlCommand cmd;

        public FormRegistro3()
        {
            InitializeComponent();

            dataGridView1_Populate("");

            
        }

        private void textBoxBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridView1_Populate(textBoxBuscar.Text);
        }

        private void FormRegistro3_Load(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                //TODO - Button Clicked - Execute Code Here
                this.Hide(); //esconde el form actual
                FormRegistro2 obj = new FormRegistro2((int)dataGridView1.Rows[e.RowIndex].Cells[0].Value); //objeto declarado para abrir el form2 proyecto_idI

                obj.Show(); //abre el form declarado con el objeto
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void sendMessageBox(string message)
        {
            string messageBoxText = message;
            string caption = "Error";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Error;
            System.Windows.MessageBox.Show(messageBoxText, caption, button, icon);
        }

        private void dataGridView1_Populate(string text)
        {
            dataGridView1.Rows.Clear();

            cmd = SqlConnector.getConnection(cmd);

            string sqlQueryString = "SELECT * FROM proyectos where nombre like ('%" + text + "%') ORDER BY id DESC";
            cmd.CommandText = sqlQueryString;

            var results = cmd.ExecuteReader();

            while (results.Read())
            {
                List<Object> lista_proyectos = new List<Object>();
                lista_proyectos.Add(results[0]);
                lista_proyectos.Add(results[1]);
                lista_proyectos.Add(results[2]);
                lista_proyectos.Add(results[3]);
                lista_proyectos.Add(results[4]);

                dataGridView1.Rows.Insert(0, lista_proyectos.ToArray());
            }

            results.Close();
            results.Dispose();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide(); //esconde el form actual


            FormRegistroEspecie objeto = new FormRegistroEspecie(); //objeto declarado para abrir el form3
            objeto.Show(); //abre el form declarado con el objeto
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            this.Hide(); //esconde el form actual


            FormRegistro3 objeto = new FormRegistro3(); //objeto declarado para abrir el form3
            objeto.Show(); //abre el form declarado con el objeto
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide(); //esconde el form actual


            FormKml objeto = new FormKml(); //objeto declarado para abrir el form3
            objeto.Show(); //abre el form declarado con el objeto
        }
    }
}