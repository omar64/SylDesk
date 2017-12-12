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
    public partial class FormRegistroEspecie : Form
    {
        MySqlCommand cmd;

        public FormRegistroEspecie()
        {
            InitializeComponent();
        }

        private void buttonRegistrar_Click(object sender, EventArgs e)
        {
            cmd = SqlConnector.getConnection(cmd);
            cmd.CommandText = "Insert into especies(especie, nombrecientifico, nombrecomun, familia)" +
                "Values(@especie, @nombrecientifico, @nombrecomun, @familia)";
            cmd.Parameters.AddWithValue("@especie", textBoxEspecie.Text);
            cmd.Parameters.AddWithValue("@nombrecientifico", textBoxNombreCientifico.Text);
            cmd.Parameters.AddWithValue("@nombrecomun", textBoxNombreComun.Text);
            cmd.Parameters.AddWithValue("@familia", textBoxFamilia.Text);
            cmd.ExecuteNonQuery();
        }
    }
}
