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

        
    }
}
