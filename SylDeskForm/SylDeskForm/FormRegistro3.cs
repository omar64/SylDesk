using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SylDeskForm
{
    public partial class FormRegistro3 : Form
    {

        MySqlCommand cmd;

        public FormRegistro3()
        {
            InitializeComponent();
        }

        private void textBoxBuscar_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxBuscar_KeyUp(object sender, KeyEventArgs e)
        {
            cmd = SqlConnector.getConnection(cmd);

            cmd.CommandType = CommandType.Text;
            string sqlQueryString = "SELECT * FROM proyectos where nombre like ('%" + textBoxBuscar.Text + "%')";
            //string sqlQueryString = "SELECT * from proyectos where nombre = @nombre";
            //cmd.ExecuteNonQuery();
            cmd.CommandText = sqlQueryString;
            cmd.Parameters.AddWithValue("@nombre", textBoxBuscar.Text);

            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            da.Fill(dt);

            dataGridView1.DataSource = dt;

        }
    }
}
