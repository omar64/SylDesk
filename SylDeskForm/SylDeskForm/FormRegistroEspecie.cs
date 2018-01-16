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
    public partial class FormRegistroEspecie : Form
    {
        MySqlCommand cmd;

        public FormRegistroEspecie()
        {
            InitializeComponent();
            dataGridViewEspecies_Populate("");
        }

        private void buttonRegistrar_Click(object sender, EventArgs e)
        {
            cmd = SqlConnector.getConnection(cmd);
            cmd.CommandText = "Insert into especies(especie, nombrecientifico, nombrecomun, familia)" +
                "Values(@especie, @nombrecientifico, @nombrecomun, @familia)";
            cmd.Parameters.AddWithValue("@especie", textBoxEspecie.Text);
            cmd.Parameters.AddWithValue("@nombrecientifico", textBoxNombreComun.Text);
            cmd.Parameters.AddWithValue("@nombrecomun", textBoxNombreCientifico.Text);
            cmd.Parameters.AddWithValue("@familia", textBoxFamilia.Text);
            cmd.ExecuteNonQuery();

            textBoxEspecie.Text = "";
            textBoxNombreCientifico.Text = "";
            textBoxNombreComun.Text = "";
            textBoxFamilia.Text = "";
            textBoxBuscarEspecie.Text = "";

            dataGridViewEspecies_Populate("");
        }

        private void dataGridViewEspecies_Populate(string text)
        {
            dataGridViewEspecies.Rows.Clear();

            cmd = SqlConnector.getConnection(cmd);

            string sqlQueryString = "SELECT especie, nombrecientifico, nombrecomun, familia from especies where especie like ('%" + text + "%') ORDER BY especie DESC";
            cmd.CommandText = sqlQueryString;

            var results = cmd.ExecuteReader();


            while (results.Read())
            {
                List<Object> lista_especies = new List<Object>();
                lista_especies.Add(results[0]);
                lista_especies.Add(results[1]);
                lista_especies.Add(results[2]);
                lista_especies.Add(results[3]);

                dataGridViewEspecies.Rows.Insert(0, lista_especies.ToArray());
            }

            results.Close();
            results.Dispose();
        }

        private void sendMessageBox(string message)
        {
            string messageBoxText = message;
            string caption = "Error";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Error;
            System.Windows.MessageBox.Show(messageBoxText, caption, button, icon);
        }

        private void textBoxBuscarEspecie_TextChanged(object sender, EventArgs e)
        {
            dataGridViewEspecies_Populate(textBoxBuscarEspecie.Text);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
