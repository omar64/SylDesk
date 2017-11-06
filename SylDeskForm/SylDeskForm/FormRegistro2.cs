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
    public partial class FormRegistro2 : System.Windows.Forms.Form
    {
        public int proyecto_id;
        MySqlCommand cmd;

        public FormRegistro2(int proyecto_id)
        {
            this.proyecto_id = proyecto_id;

            InitializeComponent();

            dataGridViewIndividuos.Rows[0].Cells[0].Value = proyecto_id;
        }

        private void labelClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void labelMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void labelClose_MouseHover(object sender, EventArgs e)
        {
            this.labelClose.ForeColor = Color.Red;
        }

        private void labelClose_MouseLeave(object sender, EventArgs e)
        {
            this.labelClose.ForeColor = Color.Transparent;
        }

        private void labelMinimize_MouseHover(object sender, EventArgs e)
        {
            this.labelMinimize.ForeColor = Color.Gray;
        }

        private void labelMinimize_MouseLeave(object sender, EventArgs e)
        {
            this.labelMinimize.ForeColor = Color.Transparent;
        }

        private void dataGridViewIndividuos_Populate()
        {
            string sqlQueryString = "SELECT id from proyectos where nombre = @nombre";
            cmd.CommandText = sqlQueryString;
            cmd.Parameters.AddWithValue("@nombre", "banana");

            var results = cmd.ExecuteReader();
            
            string textolargo = "";
            while (results.Read())
            {
                textolargo += String.Format("{0}", results[0]) + "\n";
            }
        }
        private void dataGridViewIndividuos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewIndividuos.CurrentCell.ColumnIndex == 7)
            {
                dataGridViewIndividuos.Rows[dataGridViewIndividuos.CurrentCell.RowIndex].Cells[6].Value = (Convert.ToDouble(dataGridViewIndividuos.CurrentCell.Value) * Math.PI).ToString("F4");

            }
            if (dataGridViewIndividuos.CurrentCell.ColumnIndex == 6)
            {
                dataGridViewIndividuos.Rows[dataGridViewIndividuos.CurrentCell.RowIndex].Cells[7].Value = (Convert.ToDouble(dataGridViewIndividuos.CurrentCell.Value) / Math.PI).ToString("F4");
            }
        }

        private void dataGridViewIndividuos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                dataGridViewIndividuos.Rows.Clear();
            }
        }

        private void dataGridViewIndividuos_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            dataGridViewIndividuos.Rows[dataGridViewIndividuos.Rows.Count - 1].Cells[1].Value = 1;
            dataGridViewIndividuos.Rows[dataGridViewIndividuos.Rows.Count - 1].Cells[2].Value = 2;
        }
    }
}
