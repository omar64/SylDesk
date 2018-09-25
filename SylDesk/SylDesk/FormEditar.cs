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
    public partial class FormEditar : UserControl
    {
        private Form1 form1;
        private int proyecto_id;
        MySqlCommand cmd;
        public FormEditar(Form1 form1)
        {
            this.form1 = form1;
            InitializeComponent();
        }

        public void Initialize(int proyecto_id)
        {            
            this.proyecto_id = proyecto_id;
            cmd = SqlConnector.getConnection(cmd);

            string sqlQueryString = "SELECT nombre,superficie, sector, descripcion FROM `proyectos` where id = @proyecto_id";
            cmd.CommandText = sqlQueryString;
            cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);

            var results = cmd.ExecuteReader();

            if (results.Read())
            {
                textNombre.Text = results[0].ToString();
                textSuperficie.Text = results[1].ToString();
                textSector.Text = results[2].ToString();
                textDescr.Text = results[3].ToString();
            }

            results.Close();
            results.Dispose();


        }

        public void Empty()
        {

        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            cmd = SqlConnector.getConnection(cmd);
            cmd.CommandText = "UPDATE proyectos SET nombre = @nombre AND superficie = @superficie AND sector = @sector AND descripcion = @descripcion WHERE id = @id";
            //cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);
            cmd.Parameters.AddWithValue("@nombre", textNombre.Text);
            cmd.Parameters.AddWithValue("@superficie", textSuperficie.Text);
            cmd.Parameters.AddWithValue("@sector", textSector.Text);
            cmd.Parameters.AddWithValue("@descripcion", textDescr.Text);
            cmd.Parameters.AddWithValue("@id", proyecto_id);
            cmd.ExecuteNonQuery();

            /*cmd = SqlConnector.getConnection(cmd);
            cmd.CommandText = "Insert into individuos(proyecto_id, sitio, area, numero, arbolnumeroensitio, bifurcados)" +
                "Values(@proyecto_id, @sitio, @area, @numero, @arbolnumeroensitio, false)";
            cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);
            cmd.Parameters.AddWithValue("@sitio", comboBoxSitios.SelectedItem);
            cmd.Parameters.AddWithValue("@area", comboBoxAreas.SelectedItem);
            cmd.Parameters.AddWithValue("@numero", row.Cells["numero"].Value);
            cmd.Parameters.AddWithValue("@arbolnumeroensitio", row.Cells["arbolnumeroensitio"].Value);
            cmd.ExecuteNonQuery();*/


        }
    }
}
