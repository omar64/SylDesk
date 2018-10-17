using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.IO;
using ExcelDataReader;

namespace SylDesk
{
    public partial class FormRegistroEspecie : UserControl
    {
        private Form1 form1;
        private int proyecto_id = -1;
        private int status = 0;
        private string nombre = "";

        public FormRegistroEspecie()
        {
            InitializeComponent();
        }

        public void setForm(Form1 form1)
        {
            this.form1 = form1;
        }

        public void Initialize(int proyecto_id, int status, String nombre)
        {
            Empty();
            dataGridViewEspecies_Populate("");
            this.proyecto_id = proyecto_id;
            this.status = status;
            this.nombre = nombre;
            textBoxNombreCientifico.Text = nombre;
        }

        public void Empty()
        {
            dataGridViewEspecies.Rows.Clear();
            dataGridViewEspecies.Refresh();
            textBoxFamilia.Text = "";
            textBoxGenero.Text = "";
            textBoxNombreCientifico.Text = nombre;
            textBoxNombreComun.Text = "";
            comboBoxFormaDeVida.SelectedIndex = 0;
            comboBoxCategoriaDeNorma.SelectedIndex = 0;
        }

        private void buttonRegistrar_Click(object sender, EventArgs e)
        {
            if (textBoxNombreCientifico.Text != "" && textBoxNombreComun.Text != "" && textBoxFamilia.Text != "" && textBoxGenero.Text != "" && comboBoxFormaDeVida.Text != "" && comboBoxCategoriaDeNorma.Text != "")
            {
                SqlConnector.postPutDeleteGenerico(
                    "Insert into especies(nombrecientifico, nombrecomun, familia, genero, formadevida, categoriadenorma)" +
                    "Values(@nombrecientifico, @nombrecomun, @familia, @genero, @formadevida, @categoriadenorma)",
                    new String[] { "nombrecientifico", "nombrecomun", "familia", "genero", "formadevida", "categoriadenorma" },
                    new String[] { textBoxNombreCientifico.Text, textBoxNombreComun.Text, textBoxFamilia.Text, textBoxGenero.Text, comboBoxFormaDeVida.Text, comboBoxCategoriaDeNorma.Text }
                );

                Empty();

                dataGridViewEspecies_Populate("");
                SqlConnector.sendMessage("Aviso", "Especie agregada!", MessageBoxIcon.Information);

                if (status == 1)
                {
                    form1.formRegistro2ToFront(proyecto_id);
                }
            }
            else
            {
                SqlConnector.sendMessage("Error", "Ingrese todos los datos", MessageBoxIcon.Error);
            }
        }

        private void dataGridViewEspecies_Populate(string text)
        {
            dataGridViewEspecies.Rows.Clear();

            List<Especie> list_especies = SqlConnector.especiesGet(
                "SELECT * from especies where nombrecientifico like \"%" + text + "%\" ORDER BY nombrecientifico DESC",
                new String[] { },
                new String[] { }
            );

            foreach (Especie especie in list_especies)
            {
                
                dataGridViewEspecies.Rows.Insert(0, new String[] { especie.getFamilia(), especie.getGenero(), especie.getNombreCientifico(), especie.getNombreComun(), especie.getFormaDeVida(), especie.getCategoriaDeNorma() });
            }
        }

        private void dataGridViewEspecies_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            var row = dataGridViewEspecies.Rows[e.RowIndex];

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                SqlConnector.postPutDeleteGenerico(
                    "DELETE FROM especies WHERE familia = @familia AND genero = @genero AND nombrecientifico = @nombrecientifico AND nombrecomun = @nombrecomun",
                    new String[] { "familia", "genero", "nombrecientifico", "nombrecomun" },
                    new String[] { row.Cells["familia"].Value.ToString() , row.Cells["genero"].Value.ToString(), row.Cells["nombrecientifico"].Value.ToString(), row.Cells["nombrecomun"].Value.ToString() }
                );

                dataGridViewEspecies_Populate("");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataSet dataSet = new DataSet();
            DataTable dt = new DataTable();
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (openFileDialog1.FileName != "")
                    {
                        dataSet = ReadXlsx(openFileDialog1.FileName);
                    }
                    else
                    {
                        SqlConnector.sendMessage("Error", "No se selecciono archivo o no ese archivo no es compatible.", MessageBoxIcon.Error);
                        return;
                    }
                }

                dt = dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                SqlConnector.sendMessage("Error", "Error inesperado.", MessageBoxIcon.Error);
                return;
            }

            if (dataSet == null)
            {
                
            }

            SqlConnector.postPutDeleteGenerico(
            "Delete from especies",
            new String[] { },
            new String[] { }
            );

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

                    char aux_char = (char)160;
                    len = array[2].Trim().IndexOf(aux_char);
                    subString = array[2].Substring(0, len);
                }

                SqlConnector.postPutDeleteGenerico(
                    "Insert into especies(nombrecientifico, nombrecomun, familia, formadevida, genero)" +
                    "Values(@nombrecientifico, @nombrecomun, @familia, @formadevida, @genero)",
                    new String[] { "nombrecientifico", "nombrecomun", "familia", "formadevida", "genero" },
                    new String[] { array[2], array[0], array[1], array[3], subString }
                );
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

        private void textBoxBuscarEspecie_TextChanged(object sender, EventArgs e)
        {
            dataGridViewEspecies_Populate(textBoxBuscarEspecie.Text);
        }
    }
}
