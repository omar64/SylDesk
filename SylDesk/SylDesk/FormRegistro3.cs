using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SylDesk
{
    public partial class FormRegistro3 : UserControl
    {
        MySqlCommand cmd;
        Form1 form1;

        public FormRegistro3(Form1 form1)
        {
            this.form1 = form1;
            InitializeComponent();            
        }

        public void Initialize()
        {
            Empty();
            dataGridView1_Populate("");
        }

        public void Empty()
        {
            textBoxBuscar.Text = "";
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {

        }

        private void textBoxBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            dataGridView1_Populate(textBoxBuscar.Text);
        }

        /*
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                //TODO - Button Clicked - Execute Code Here
                //this.Hide(); //esconde el form actual

                
                form1.formRegistro2ToFront((int)dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                
                Empty();
                //FormRegistro2 obj = new FormRegistro2((int)dataGridView1.Rows[e.RowIndex].Cells[0].Value); //objeto declarado para abrir el form2 proyecto_idI

                //obj.Show(); //abre el form declarado con el objeto
            }            
        }
        */


        private void sendMessageBox(string message)
        {
            string messageBoxText = message;
            string caption = "Error";
            MessageBox.Show(messageBoxText, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            /*this.Hide(); //esconde el form actual


            FormRegistro3 objeto = new FormRegistro3(); //objeto declarado para abrir el form3
            objeto.Show(); //abre el form declarado con el objeto*/
        }

        private void FormRegistro3_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == this.detalle.Index)
                {
                    form1.formRegistro2ToFront((int)dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                }
                else if (e.ColumnIndex == this.editar.Index)
                {
                    form1.formEditarToFront((int)dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                    // etc.
                }
            }
        }
    }
}
