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
    public partial class FormRegistroEspecie : UserControl
    {
        MySqlCommand cmd;

        public FormRegistroEspecie()
        {
            InitializeComponent();
            dataGridViewEspecies_Populate("");
        }

        private void buttonRegistrar_Click(object sender, EventArgs e)
        {
            if (textBoxNombreCientifico.Text != "" && textBoxNombreComun.Text != "" && textBoxFamilia.Text != "" && textBoxGenero.Text != "" && textBoxFormaDeVida.Text != "" && textBoxCategoriaDeNorma.Text != "")
            {
                cmd = SqlConnector.getConnection(cmd);
                cmd.CommandText = "Insert into especies(nombrecientifico, nombrecomun, familia, genero, formadevida, categoriadenorma)" +
                    "Values(@nombrecientifico, @nombrecomun, @familia, @genero, @formadevida, @categoriadenorma)";
                cmd.Parameters.AddWithValue("@nombrecientifico", textBoxNombreCientifico.Text);
                cmd.Parameters.AddWithValue("@nombrecomun", textBoxNombreComun.Text);
                cmd.Parameters.AddWithValue("@familia", textBoxFamilia.Text);
                cmd.Parameters.AddWithValue("@genero", textBoxGenero.Text);
                cmd.Parameters.AddWithValue("@formadevida", textBoxFormaDeVida.Text);
                cmd.Parameters.AddWithValue("@categoriadenorma", textBoxCategoriaDeNorma.Text);
                cmd.ExecuteNonQuery();

                textBoxNombreCientifico.Text = "";
                textBoxNombreComun.Text = "";
                textBoxFamilia.Text = "";
                textBoxGenero.Text = "";
                textBoxFormaDeVida.Text = "";
                textBoxCategoriaDeNorma.Text = "";

                dataGridViewEspecies_Populate("");
            }
        }

        private void dataGridViewEspecies_Populate(string text)
        {
            dataGridViewEspecies.Rows.Clear();

            cmd = SqlConnector.getConnection(cmd);

            string sqlQueryString = "SELECT familia, genero, nombrecientifico, nombrecomun, formadevida, categoriadenorma  from especies where nombrecientifico like ('%" + text + "%') ORDER BY nombrecientifico DESC";
            cmd.CommandText = sqlQueryString;

            var results = cmd.ExecuteReader();


            while (results.Read())
            {
                List<Object> lista_especies = new List<Object>();
                lista_especies.Add(results[0]);
                lista_especies.Add(results[1]);
                lista_especies.Add(results[2]);
                lista_especies.Add(results[3]);
                lista_especies.Add(results[4]);
                lista_especies.Add(results[5]);

                dataGridViewEspecies.Rows.Insert(0, lista_especies.ToArray());
            }

            results.Close();
            results.Dispose();
        }

        private void sendMessageBox(string message)
        {
            /*string messageBoxText = message;
            string caption = "Error";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Error;
            System.Windows.MessageBox.Show(messageBoxText, caption, button, icon);*/
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            this.Hide(); //esconde el form actual


            FormRegistro3 objeto = new FormRegistro3(); //objeto declarado para abrir el form3
            objeto.Show(); //abre el form declarado con el objeto
        }

        private void dataGridViewEspecies_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            var row = dataGridViewEspecies.Rows[e.RowIndex];

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                cmd = SqlConnector.getConnection(cmd);
                cmd.CommandText = "DELETE FROM especies WHERE familia = @familia AND genero = @genero AND nombrecientifico = @nombrecientifico AND nombrecomun = @nombrecomun";
                cmd.Parameters.AddWithValue("@familia", row.Cells["familia"].Value);
                cmd.Parameters.AddWithValue("@genero", row.Cells["genero"].Value);
                cmd.Parameters.AddWithValue("@nombrecientifico", row.Cells["nombrecientifico"].Value);
                cmd.Parameters.AddWithValue("@nombrecomun", row.Cells["nombrecomun"].Value);
                cmd.ExecuteNonQuery();

                dataGridViewEspecies.Rows.RemoveAt(e.RowIndex);
            }
        }


    }
}
