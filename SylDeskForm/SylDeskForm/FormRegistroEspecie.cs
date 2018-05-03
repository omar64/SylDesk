using ExcelDataReader;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        AutoCompleteStringCollection source1;
        AutoCompleteStringCollection source2;

        public FormRegistroEspecie()
        {
            InitializeComponent();
            dataGridViewEspecies_Populate("");

            getFamilias();
            
            getGeneros();
            
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

        private void label4_Click(object sender, EventArgs e)
        {

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

        private void textBoxAutoComplete(TextBox textbox, AutoCompleteStringCollection source)
        {
            textbox.AutoCompleteCustomSource = source;
            textbox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textbox.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void getFamilias()
        {
            textBoxFamilia.AutoCompleteMode = AutoCompleteMode.None;
            textBoxFamilia.AutoCompleteSource = AutoCompleteSource.None;
            source1 = new AutoCompleteStringCollection();

            //familiasObject = new List<Familia>();
            List<string> familiasString = new List<string>();
            cmd = SqlConnector.getConnection(cmd);

            string sqlQueryString = "SELECT familia FROM familias";
            cmd.CommandText = sqlQueryString;

            var results = cmd.ExecuteReader();

            while (results.Read())
            {
                string familiaNombre = results[0].ToString();
                
                //especiesObject.Add(new Especie(labelNombreCientificoText, labelFamiliaText, labelGeneroText));
                familiasString.Add(familiaNombre);
            }

            results.Close();
            results.Dispose();

            source1.AddRange(familiasString.ToArray());
            textBoxAutoComplete(textBoxFamilia, source1);
        }

        private int getFamilia()
        {
            int flag = -1;
            string textBoxFamiliaText = textBoxFamilia.Text;
            if(!textBoxFamiliaText.Equals(""))
            {
                cmd = SqlConnector.getConnection(cmd);

                string sqlQueryString = "SELECT id FROM familias where familia = \"" + textBoxFamiliaText + "\"";
                
                cmd.CommandText = sqlQueryString;


                var results = cmd.ExecuteReader();

                if (results.Read())
                {
                    flag = (int)results[0];
                }

                results.Close();
                results.Dispose();
            }
            
            return flag;
        }

        private string getFamilia(int id)
        {
            string familia = "";
            cmd = SqlConnector.getConnection(cmd);

            string sqlQueryString = "SELECT familia FROM familias where id = " + id;

            cmd.CommandText = sqlQueryString;
             
            var results = cmd.ExecuteReader();

            if (results.Read())
            {
                familia = (string)results[0];
            }

            results.Close();
            results.Dispose();
            

            return familia;
        }

        private int[] getGenero()
        {
            int[] flag = { -1, -1 };
            string textBoxGeneroText = textBoxGenero.Text;
            if (!textBoxGeneroText.Equals(""))
            {
                cmd = SqlConnector.getConnection(cmd);

                string sqlQueryString = "SELECT id, familia_id FROM generos where genero = \"" + textBoxGeneroText + "\"";
                //sendMessageBox(sqlQueryString);
                cmd.CommandText = sqlQueryString;


                var results = cmd.ExecuteReader();

                if (results.Read())
                {
                    flag[0] = (int)results[0];
                    flag[1] = (int)results[1];
                    //sendMessageBox(flag[0] + " " + flag[1]);
                }

                results.Close();
                results.Dispose();
            }

            return flag;
        }

        private void getGeneros()
        {
            textBoxGenero.AutoCompleteMode = AutoCompleteMode.None;
            textBoxGenero.AutoCompleteSource = AutoCompleteSource.None;
            source2 = new AutoCompleteStringCollection();

            //familiasObject = new List<Familia>();
            List<string> generosString = new List<string>();
            string extra_query = "";
            cmd = SqlConnector.getConnection(cmd);
            int familiaId = getFamilia();
            if (familiaId != -1)
            {
                extra_query = " where familia_id = " + familiaId;
            }
            string sqlQueryString = "SELECT genero FROM generos" + extra_query;
            cmd.CommandText = sqlQueryString;

            var results = cmd.ExecuteReader();

            while (results.Read())
            {
                string generoNombre = results[0].ToString();                
                //especiesObject.Add(new Especie(labelNombreCientificoText, labelFamiliaText, labelGeneroText));
                generosString.Add(generoNombre);
            }

            results.Close();
            results.Dispose();

            source2.AddRange(generosString.ToArray());
            textBoxAutoComplete(textBoxGenero, source2);
        }

        private void textBoxFamilia_Leave(object sender, EventArgs e)
        {
            string familia = textBoxFamilia.Text;
            if (!familia.Equals(""))
            {
                int familiaId = getFamilia();
                if (familiaId == -1)
                {
                    cmd = SqlConnector.getConnection(cmd);
                    cmd.CommandText = "Insert into familias(familia)" +
                        "Values(@familia)";
                    cmd.Parameters.AddWithValue("@familia", familia);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    getGeneros();
                }
            }
        }

        private void textBoxGenero_Leave(object sender, EventArgs e)
        {
            string nombreCientifico = textBoxNombreCientifico.Text;
            string genero = textBoxGenero.Text;

            if (!genero.Equals(""))
            {
                verifyGenero();
                genero = textBoxGenero.Text;
                if (!genero.Equals(""))
                {
                    if (nombreCientifico.Equals(""))
                    {
                        textBoxNombreCientifico.Text = genero;
                    }
                    else
                    {
                        int len = nombreCientifico.IndexOf(" ");
                        string nombreCientificoSubtString1 = nombreCientifico.Substring(0, len);
                        String nombreCientificoSubtString2 = nombreCientifico.Substring(nombreCientifico.IndexOf(" "), nombreCientifico.Length - len);

                        textBoxNombreCientifico.Text = genero + nombreCientificoSubtString2;
                    }
                    if(textBoxFamilia.Text.Equals(""))
                    {
                        int familia_id = getGenero()[1];
                        getFamilia(familia_id);
                    }
                }
            }
        }

        private void textBoxNombreCientifico_Leave(object sender, EventArgs e)
        {
            string nombreCientifico = textBoxNombreCientifico.Text;
            if (!nombreCientifico.Equals(""))
            {
                string genero = nombreCientifico;
                try
                {
                    genero = nombreCientifico.Substring(0, nombreCientifico.IndexOf(" "));                    
                }
                catch (Exception exception)
                {
                    
                }

                if (!genero.Equals(textBoxGenero.Text))
                {
                    textBoxGenero.Text = genero;
                    verifyGenero();
                    if(!textBoxGenero.Equals("") && textBoxFamilia.Text.Equals(""))
                    {
                        int familia_id = getGenero()[1];
                        getFamilia(familia_id);
                    }
                }
            }
        }

        private void verifyGenero()
        {
            string genero = textBoxGenero.Text;
            int familiaId = getFamilia();
            
            int[] generoIds = getGenero();
            sendMessageBox("VerifyGenero: FamiliaId: " + familiaId + ", generoId: " + generoIds[0]);
            if(generoIds[0] != -1)
            {
                if (familiaId == -1)
                {
                    string familia = getFamilia(generoIds[1]);
                    textBoxFamilia.Text = familia;
                }
                else if (familiaId != generoIds[1])
                {
                    sendMessageBox("Ese Genero no existe en esa familia");
                    textBoxGenero.Text = "";
                }
            }
            else
            {
                if (familiaId != -1)
                {
                    cmd = SqlConnector.getConnection(cmd);
                    cmd.CommandText = "Insert into generos(familia_id, genero)" +
                        "Values(@familia_id, @genero)";

                    cmd.Parameters.AddWithValue("@familia_id", familiaId);
                    cmd.Parameters.AddWithValue("@genero", genero);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    sendMessageBox("Genero Inexistente, primero agregue la familia para crear el genero");
                    textBoxGenero.Text = "";
                }
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

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide(); //esconde el form actual


            //FormKml objeto = new FormKml(); //objeto declarado para abrir el form3
            //objeto.Show(); //abre el form declarado con el objeto
        }
    }
}