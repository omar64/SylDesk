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
using System.IO;
using ExcelDataReader;
using System.Windows;

namespace SylDesk
{
    public partial class FormRegistroEspecie : UserControl
    {
        private Form1 form1;
        MySqlCommand cmd;

        public FormRegistroEspecie(Form1 form1)
        {
            this.form1 = form1;
            InitializeComponent();
        }

        public void Initialize(String nombre)
        {
            Empty();
            dataGridViewEspecies_Populate("");
            textBoxNombreCientifico.Text = nombre;
        }

        public void Empty()
        {
            dataGridViewEspecies.Rows.Clear();
            dataGridViewEspecies.Refresh();
            textBoxFamilia.Text = "";
            textBoxGenero.Text = "";
            textBoxNombreCientifico.Text = "";
            textBoxNombreComun.Text = "";
            textBoxFormaDeVida.Text = "";
            textBoxCategoriaDeNorma.Text = "";
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
                SqlConnector.sendMessageBox("Especie agregada!");
            }
            else
            {
                SqlConnector.sendMessageBox("Ingrese todos los datos");
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
            string messageBoxText = message;
            string caption = "Error";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Error;
            System.Windows.MessageBox.Show(messageBoxText, caption, button, icon);
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            //this.Hide(); //esconde el form actual


            //FormRegistro3 objeto = new FormRegistro3(); //objeto declarado para abrir el form3
            //objeto.Show(); //abre el form declarado con el objeto
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

        private void button2_Click(object sender, EventArgs e)
        {
            cmd = SqlConnector.getConnection(cmd);
            cmd.CommandText = "Delete from especies";
            cmd.ExecuteNonQuery();
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            DataSet dataSet = new DataSet();
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                dataSet = ReadXlsx(openFileDialog1.FileName);
            }

            DataTable dt = new DataTable();
            dt = dataSet.Tables[0];

            String[] array = new String[4];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    var val = dt.Rows[i][j].ToString().Trim();
                    array[j] = val;
                }

                int len = array[2].Trim().IndexOf(" ");

                string subString = array[2];
                try
                {
                    subString = array[2].Substring(0, len);
                }
                catch (Exception exc)
                {
                    /*
                    sendMessageBox("|" + array[0] + "|");
                    sendMessageBox("|" + array[1] + "|");
                    sendMessageBox("ERROR MAGICOOOOO: |" + i + "|" + array[2] + "|" + len);
                    sendMessageBox("|" + array[3] + "|");
                    */

                    char aux_char = (char)160;
                    len = array[2].Trim().IndexOf(aux_char);
                    subString = array[2].Substring(0, len);
                }

                cmd = SqlConnector.getConnection(cmd);
                cmd.CommandText = "Insert into especies(nombrecientifico, nombrecomun, familia, formadevida, genero)" +
                    "Values(@nombrecientifico, @nombrecomun, @familia, @formadevida, @genero)";

                cmd.Parameters.AddWithValue("@nombrecientifico", array[2]);
                cmd.Parameters.AddWithValue("@nombrecomun", array[0]);
                cmd.Parameters.AddWithValue("@familia", array[1]);
                cmd.Parameters.AddWithValue("@formadevida", array[3]);
                cmd.Parameters.AddWithValue("@genero", subString);
                cmd.ExecuteNonQuery();
            }
        }

        public DataSet ReadXlsx(string filepath)
        {
            try
            {
                FileStream stream = File.Open(filepath, FileMode.Open, FileAccess.Read);
                IExcelDataReader excelReader2 = ExcelReaderFactory.CreateOpenXmlReader(stream);

                var conf = new ExcelDataSetConfiguration
                {
                    ConfigureDataTable = _ => new ExcelDataTableConfiguration
                    {
                        UseHeaderRow = true
                    }
                };
                DataSet result2 = excelReader2.AsDataSet(conf);

                return result2;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    
    }
}
