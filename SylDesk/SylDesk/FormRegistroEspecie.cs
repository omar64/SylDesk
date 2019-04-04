using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using ExcelDataReader;

namespace SylDesk
{
    public partial class FormRegistroEspecie : UserControl
    {
        private Form1 form1;
        private Proyecto proyecto = null;
        private int status = 0;
        private string nombre = "";

        private int rowIndex = 0;

        public FormRegistroEspecie()
        {
            InitializeComponent();
        }

        public void setForm(Form1 form1)
        {
            this.form1 = form1;
        }

        public void Initialize(Proyecto proyecto, int status, String nombre)
        {
            Empty();
            dataGridViewEspecies_Populate("");
            this.proyecto = proyecto;
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
                    form1.formRegistro2ToFront(proyecto);
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

                        dt = dataSet.Tables[0];

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
                    else
                    {
                        SqlConnector.sendMessage("Error", "No se selecciono archivo o no ese archivo no es compatible.", MessageBoxIcon.Error);
                        return;
                    }
                }

            }
            catch (Exception ex)
            {
                SqlConnector.sendMessage("Error", "Error inesperado.", MessageBoxIcon.Error);
                return;
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


        private void FormRegistroEspecie_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(TipBox, "Lorem ipsum dolor sit amet consectetur adipiscing\n elit ornare, accumsan nec auctor morbi eget diam cubilia curae,\n justo nisl fringilla natoque sodales dignissim tristique.\n Massa morbi fringilla taciti pulvinar vel nascetur risus luctus eros,\n aliquam orci accumsan quam convallis id sociis lectus egestas, dui mattis aptent leo conubia arcu mi consequat.\n Dictumst senectus litora suscipit proin pretium mattis facilisi, montes posuere ut felis convallis\n dignissim eleifend luctus, praesent urna nullam ridiculus vitae enim.");
        }

        private void textBoxNombreCientifico_TextChanged(object sender, EventArgs e)
        {
            string s = textBoxNombreCientifico.Text;
            textBoxGenero.Text = SqlConnector.getFirstWord(s);

        }

        private void dataGridViewEspecies_RowContextMenuStripNeeded(object sender, DataGridViewRowContextMenuStripNeededEventArgs e)
        {
            
        }

        private void dataGridViewEspecies_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.dataGridViewEspecies.Rows[e.RowIndex].Selected = true;
                this.rowIndex = e.RowIndex;
                this.dataGridViewEspecies.CurrentCell = this.dataGridViewEspecies.Rows[e.RowIndex].Cells[1];
                this.contextMenuStrip1.Show(this.dataGridViewEspecies, e.Location);
                contextMenuStrip1.Show(Cursor.Position);
            }
        }

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
            if (!this.dataGridViewEspecies.Rows[this.rowIndex].IsNewRow)
            {
                this.dataGridViewEspecies.Rows.RemoveAt(this.rowIndex);
            }
        }
    }
}
