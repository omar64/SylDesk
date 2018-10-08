using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using ExcelDataReader;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace SylDesk
{
    public partial class FormRegistro2 : UserControl
    {
        private Form1 form1;
        private int proyecto_id;
        public List<Especie> especiesObject;
        public List<string> especiesString;
        MySqlCommand cmd;
        AutoCompleteStringCollection source = new AutoCompleteStringCollection();

        public FormRegistro2(Form1 form1)
        {
            this.form1 = form1;
            InitializeComponent();
            getEspecies();
        }

        public void Initialize(int proyecto_id)
        {
            Empty();
            this.proyecto_id = proyecto_id;

            comboBoxSitios_Populate();
            comboBoxSitios.SelectedIndex = 0;
            comboBoxAreas.SelectedIndex = 0;

            dataGridViewIndividuos_Populate();
            fillForm();
        }

        public void Empty()
        {
            comboBoxSitios.Items.Clear();
            //comboBoxAreas.Items.Clear();
            dataGridViewIndividuos.Rows.Clear();
            dataGridViewIndividuos.Refresh();
        }        

        private void dataGridViewIndividuos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int row_index = dataGridViewIndividuos.CurrentCell.RowIndex;
            string column_name = dataGridViewIndividuos.Columns[dataGridViewIndividuos.CurrentCell.ColumnIndex].Name;
            DataGridViewRow row = dataGridViewIndividuos.Rows[dataGridViewIndividuos.CurrentCell.RowIndex];
            if (column_name == "alturatotal")
            {               
                volumen_ecuacion(row);
            }
            if (column_name == "diametro")
            {
                dataGridViewIndividuos.Rows[row_index].Cells["perimetro"].Value = (Convert.ToDouble(dataGridViewIndividuos.CurrentCell.Value) * Math.PI).ToString("F4");
                dataGridViewIndividuos.Rows[row_index].Cells["areabasal"].Value = (Math.PI * Math.Pow(Convert.ToDouble(dataGridViewIndividuos.CurrentCell.Value) / 2, 2)) / 10000;

                updateData("perimetro", row, Convert.ToString(row.Cells["perimetro"].Value));
                updateData("areabasal", row, Convert.ToString(row.Cells["areabasal"].Value));

                volumen_ecuacion(row);
            }
            else if (column_name == "perimetro")
            {
                dataGridViewIndividuos.Rows[row_index].Cells["diametro"].Value = (Convert.ToDouble(dataGridViewIndividuos.CurrentCell.Value) / Math.PI).ToString("F4");

                updateData("diametro", row, Convert.ToString(row.Cells["diametro"].Value));

                volumen_ecuacion(row);
            }
            else if (column_name == "nombrecientifico")
            {
                cmd = SqlConnector.getConnection(cmd);

                string sqlQueryString = "SELECT nombrecomun, familia, genero FROM especies where nombrecientifico = @nombrecientifico";
                cmd.CommandText = sqlQueryString;
                cmd.Parameters.AddWithValue("@nombrecientifico", row.Cells["nombrecientifico"].Value);

                var results = cmd.ExecuteReader();

                if (results.Read())
                {
                    string textBoxNombreComun = results[0].ToString();
                    string textBoxFamilia = results[1].ToString();
                    string textBoxGenero = results[2].ToString();

                    results.Close();
                    results.Dispose();
                    //sendMessageBox(textBoxNombreCientificoText + " " + textBoxNombreComunText + " " + textBoxFamiliaText);

                    row.Cells["nombrecomun"].Value = textBoxNombreComun;
                    row.Cells["familia"].Value = textBoxFamilia;
                    row.Cells["genero"].Value = textBoxGenero;

                    updateData("nombrecomun", row, textBoxNombreComun);
                    updateData("familia", row, textBoxFamilia);
                    updateData("genero", row, textBoxGenero);

                    //grupo_especie(row);
                    volumen_ecuacion(row);                    
                }
                else
                {
                    results.Close();
                    results.Dispose();
                    DialogResult dialog_result = MessageBox.Show("No existe esa especie, desea crearla?",
                        "",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2);
                    //
                    // Test the results of the previous three dialogs. [6]
                    //
                    if (dialog_result == DialogResult.Yes)
                    {                        
                        form1.formRegistroEspecieToFront("" + row.Cells[column_name].Value);
                    }
                    row.Cells[column_name].Value = "";

                    row.Cells["nombrecomun"].Value = "";
                    row.Cells["familia"].Value = "";
                    row.Cells["genero"].Value = "";
                    row.Cells["volumen"].Value = "0";

                    updateData("nombrecomun", row, "");
                    updateData("familia", row, "");
                    updateData("genero", row, "");
                    updateData("volumenvv", row, "");

                }
            }

            cmd = SqlConnector.getConnection(cmd);
            cmd.CommandText = "UPDATE individuos SET " + column_name + " = @" + column_name + " WHERE proyecto_id = @proyecto_id AND sitio = @sitio AND area = @area AND numero = @numero";
            cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);
            cmd.Parameters.AddWithValue("@sitio", comboBoxSitios.SelectedItem);
            cmd.Parameters.AddWithValue("@area", comboBoxAreas.SelectedItem);
            cmd.Parameters.AddWithValue("@numero", row.Cells["numero"].Value);
            cmd.Parameters.AddWithValue("@" + column_name, row.Cells[column_name].Value);
            cmd.ExecuteNonQuery();
        }

        private void grupo_especie(DataGridViewRow row)
        {
            cmd = SqlConnector.getConnection(cmd);

            string sqlQueryString = "SELECT grupo FROM grupo_especie where nombrecientifico = @nombrecientifico";
            cmd.CommandText = sqlQueryString;
            cmd.Parameters.AddWithValue("@nombrecientifico", row.Cells["nombrecientifico"].Value);

            var results = cmd.ExecuteReader();

            if (results.Read())
            {
                string grupo = results[0].ToString();
                results.Close();
                results.Dispose();

                row.Cells["grupo"].Value = grupo;
                updateData("grupo", row, grupo);
            }
            else
            {
                results.Close();
                results.Dispose();

                sendMessageBox("No se encontro un grupo adecuado para esta especie");
                row.Cells["grupo"].Value = "";
                updateData("grupo", row, "");
            }            
        }

        private void volumen_ecuacion(DataGridViewRow row)
        {
            try
            {
                if (comboBoxAreas.SelectedIndex == 0)
                {
                    String sdiametro = row.Cells["diametro"].Value.ToString();
                    String salturatotal = row.Cells["alturatotal"].Value.ToString();
                    //String sgrupo = row.Cells["grupo"].Value.ToString();
                    String snombrecientifico = row.Cells["nombrecientifico"].Value.ToString();

                    double diametro = Convert.ToDouble(row.Cells["diametro"].Value);
                    double alturatotal = Convert.ToDouble(row.Cells["alturatotal"].Value);
                    double perimetro = Convert.ToDouble(row.Cells["perimetro"].Value);
                    double areabasal = Convert.ToDouble(row.Cells["areabasal"].Value);
                    double alturafl = Convert.ToDouble(row.Cells["alturafl"].Value);
                    double coberturalargo = Convert.ToDouble(row.Cells["coberturalargo"].Value);
                    double coberturaancho = Convert.ToDouble(row.Cells["coberturaancho"].Value);

                    bool found_flag = false;

                    if (!sdiametro.Equals("") && !salturatotal.Equals("") && !snombrecientifico.Equals("")) // && !sgrupo.Equals("")
                    {

                        cmd = SqlConnector.getConnection(cmd);

                        string sqlQueryString = "SELECT umafor_region FROM `proyecto_ecuaciones` Where proyecto_id = @proyecto_id";
                        cmd.CommandText = sqlQueryString;
                        cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);

                        var results = cmd.ExecuteReader();
                        List<String> umafor_region_list = new List<String>();

                        while (results.Read())
                        {
                            umafor_region_list.Add(results[0].ToString());
                            SqlConnector.sendMessageBox("H" + results[0].ToString());

                        }
                        results.Close();
                        results.Dispose();


                        foreach(String umafor_region in umafor_region_list)
                        {
                            cmd = SqlConnector.getConnection(cmd);

                            //String sqlQueryString = "SELECT ecuacion, num1, num2, num3 FROM ecuaciones_volumen where grupo = @grupo";
                            sqlQueryString = "SELECT ecuacion FROM ecuaciones_volumen where umafor = @umafor AND especie = @especie";
                            cmd.CommandText = sqlQueryString;

                            cmd.Parameters.AddWithValue("@umafor", umafor_region);
                            cmd.Parameters.AddWithValue("@especie", snombrecientifico);
                            //cmd.Parameters.AddWithValue("@grupo", row.Cells["grupo"].Value);

                            results = cmd.ExecuteReader();
                            if (results.Read())
                            {
                                SqlConnector.sendMessageBox("Z" + umafor_region);

                                string ecuacion = results[0].ToString();
                                //sendMessageBox("V= " + ecuacion);
                                //double num1 = Convert.ToDouble(results[1].ToString());
                                //double num2 = Convert.ToDouble(results[2].ToString());
                                //double num3 = Convert.ToDouble(results[3].ToString());

                                //double volumen = Math.Exp(num1 + num2 * Math.Log(diametro) + num3 * Math.Log(alturatotal));
                                MathParser parser = new MathParser();
                                string pattern = @"\bDIAMETRO\b";
                                string replace = "" + diametro;
                                string result = Regex.Replace(ecuacion, pattern, replace);
                                pattern = @"\bALTURATOTAL\b";
                                replace = "" + alturatotal;
                                result = Regex.Replace(result, pattern, replace);
                                pattern = @"\bPERIMETRO\b";
                                replace = "" + perimetro;
                                result = Regex.Replace(result, pattern, replace);
                                pattern = @"\bAREABASAL\b";
                                replace = "" + areabasal;
                                result = Regex.Replace(result, pattern, replace);
                                pattern = @"\bALTURAFL\b";
                                replace = "" + areabasal;
                                result = Regex.Replace(result, pattern, replace);
                                pattern = @"\bCOBERTURAANCHO\b";
                                replace = "" + areabasal;
                                result = Regex.Replace(result, pattern, replace);
                                pattern = @"\bCOBERTURALARGO\b";
                                replace = "" + areabasal;
                                result = Regex.Replace(result, pattern, replace);

                                double volumen = parser.Parse(result, false);

                                SqlConnector.sendMessageBox("" + result + " ---- " + volumen);
                                
                                row.Cells["volumen"].Value = volumen;
                                updateData("volumenvv", row, "" + volumen);
                                found_flag = true;
                                break;
                            }
                            results.Close();
                            results.Dispose();
                        }
                        SqlConnector.sendMessageBox("A");

                        results.Close();
                        results.Dispose();
                        SqlConnector.sendMessageBox("B");
                        if (!found_flag)
                        {
                            SqlConnector.sendMessageBox("Algunas especies capturadas no presentan ecuación para los inventarios seleccionados o no existe ecuación registrada. Para su registro se desplegará el editor de ecuaciones.");
                            form1.calculadoraEcuToFront(1, proyecto_id);
                        }
                    }
                }
            }
            catch (Exception e)
            {

            }
        }

        private void dataGridViewIndividuos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                dataGridViewIndividuos.Rows.Clear();
            }
        }

        private void sendMessageBox(string message)
        {
            string messageBoxText = message;
            string caption = "Error";
            //MessageBoxButton button = MessageBoxButton.OK;
            //MessageBoxImage icon = MessageBoxImage.Error;
            MessageBox.Show(messageBoxText, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void buttonAgregarSitio_Click(object sender, EventArgs e)
        {
            comboBoxSitios.Items.Add(comboBoxSitios.Items.Count + 1);
            cmd = SqlConnector.getConnection(cmd);
            cmd.CommandText = "Insert into sitios(proyecto_id, numero_sitio)Values(@proyecto_id, @numero_sitio)";
            cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);
            cmd.Parameters.AddWithValue("@numero_sitio", comboBoxSitios.Items.Count);
            cmd.ExecuteNonQuery();
        }

        private void buttonBorrarSitio_Click(object sender, EventArgs e)
        {
            if (comboBoxSitios.Items.Count > 1)
            {
                cmd = SqlConnector.getConnection(cmd);
                cmd.CommandText = "DELETE FROM individuos WHERE proyecto_id = @proyecto_id AND sitio = @sitio";
                cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);
                cmd.Parameters.AddWithValue("@sitio", comboBoxSitios.Items.Count);
                cmd.ExecuteNonQuery();

                cmd = SqlConnector.getConnection(cmd);
                cmd.CommandText = "DELETE FROM sitios WHERE proyecto_id = @proyecto_id AND numero_sitio = @numero_sitio";
                cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);
                cmd.Parameters.AddWithValue("@numero_sitio", comboBoxSitios.Items.Count);
                cmd.ExecuteNonQuery();

                if (comboBoxSitios.Items.Count == comboBoxSitios.SelectedIndex + 1)
                {
                    comboBoxSitios.SelectedIndex -= 1;
                }
                comboBoxSitios.Items.Remove(comboBoxSitios.Items.Count);
            }
        }

        private void comboBoxSitios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSitios.SelectedItem != null)
            {
                fillForm();
                if (comboBoxAreas.SelectedItem != null)
                {
                    dataGridViewIndividuos_Populate();
                }
            }
        }

        private void comboBoxAreas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSitios.SelectedItem != null && comboBoxAreas.SelectedItem != null)
            {
                dataGridViewIndividuos_Populate();
            }

            if (comboBoxAreas.SelectedIndex < 2)
            {
                dataGridViewIndividuos.Columns["perimetro"].Visible = true;
                dataGridViewIndividuos.Columns["diametro"].Visible = true;
                dataGridViewIndividuos.Columns["alturafl"].Visible = true;
                dataGridViewIndividuos.Columns["coberturalargo"].Visible = false;
                dataGridViewIndividuos.Columns["coberturaancho"].Visible = false;
                dataGridViewIndividuos.Columns["formadefuste"].Visible = true;
                dataGridViewIndividuos.Columns["estadocondicion"].Visible = true;
            }
            else
            {
                dataGridViewIndividuos.Columns["perimetro"].Visible = false;
                dataGridViewIndividuos.Columns["diametro"].Visible = false;
                dataGridViewIndividuos.Columns["alturafl"].Visible = false;
                dataGridViewIndividuos.Columns["coberturalargo"].Visible = true;
                dataGridViewIndividuos.Columns["coberturaancho"].Visible = true;
                dataGridViewIndividuos.Columns["formadefuste"].Visible = false;
                dataGridViewIndividuos.Columns["estadocondicion"].Visible = false;
            }
        }

        private void textBoxX_TextChanged(object sender, EventArgs e)
        {
            cmd = SqlConnector.getConnection(cmd);
            cmd.CommandText = "UPDATE sitios SET coordenada_x = @coordenada_x WHERE proyecto_id = @proyecto_id AND numero_sitio = @numero_sitio";
            cmd.Parameters.AddWithValue("@coordenada_x", textBoxX.Text);
            cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);
            cmd.Parameters.AddWithValue("@numero_sitio", comboBoxSitios.SelectedItem);
            cmd.ExecuteNonQuery();
        }

        private void textBoxY_TextChanged(object sender, EventArgs e)
        {
            cmd = SqlConnector.getConnection(cmd);
            cmd.CommandText = "UPDATE sitios SET coordenada_y = @coordenada_y WHERE proyecto_id = @proyecto_id AND numero_sitio = @numero_sitio";
            cmd.Parameters.AddWithValue("@coordenada_y", textBoxY.Text);
            cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);
            cmd.Parameters.AddWithValue("@numero_sitio", comboBoxSitios.SelectedItem);
            cmd.ExecuteNonQuery();
        }

        private void textBoxMunicipio_TextChanged(object sender, EventArgs e)
        {
            cmd = SqlConnector.getConnection(cmd);
            cmd.CommandText = "UPDATE sitios SET municipio = @municipio WHERE proyecto_id = @proyecto_id AND numero_sitio = @numero_sitio";
            cmd.Parameters.AddWithValue("@municipio", textBoxMunicipio.Text);
            cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);
            cmd.Parameters.AddWithValue("@numero_sitio", comboBoxSitios.SelectedItem);
            cmd.ExecuteNonQuery();
        }

        private void textBoxEstadoSucesional_TextChanged(object sender, EventArgs e)
        {
            cmd = SqlConnector.getConnection(cmd);
            cmd.CommandText = "UPDATE sitios SET estado_sucesional = @estado_sucesional WHERE proyecto_id = @proyecto_id AND numero_sitio = @numero_sitio";
            cmd.Parameters.AddWithValue("@estado_sucesional", textBoxEstadoSucesional.Text);
            cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);
            cmd.Parameters.AddWithValue("@numero_sitio", comboBoxSitios.SelectedItem);
            cmd.ExecuteNonQuery();
        }


        private void fillForm()
        {
            cmd = SqlConnector.getConnection(cmd);

            string sqlQueryString = "SELECT municipio, coordenada_x, coordenada_y, estado_sucesional FROM `sitios` where proyecto_id = @proyecto_id AND numero_sitio = @numero_sitio";
            cmd.CommandText = sqlQueryString;
            cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);
            cmd.Parameters.AddWithValue("@numero_sitio", comboBoxSitios.SelectedItem);

            var results = cmd.ExecuteReader();

            results.Read();

            string textBoxMunicipioText = results[0].ToString();
            string textBoxXText = results[1].ToString();
            string textBoxYText = results[2].ToString();
            string textBoxEstadoSucesionalText = results[3].ToString();

            results.Close();
            results.Dispose();

            textBoxMunicipio.Text = textBoxMunicipioText;
            textBoxX.Text = textBoxXText;
            textBoxY.Text = textBoxYText;
            textBoxEstadoSucesional.Text = textBoxEstadoSucesionalText;


            cmd = SqlConnector.getConnection(cmd);

            sqlQueryString = "SELECT nombre, superficie, sector, descripcion FROM `proyectos` where id = @proyecto_id";
            cmd.CommandText = sqlQueryString;
            cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);

            results = cmd.ExecuteReader();

            results.Read();

            string labelNombreText = results[0].ToString();
            string labelSuperficieText = results[1].ToString();
            string labelSectorText = results[2].ToString();
            string labelDescripcionText = results[3].ToString();

            results.Close();
            results.Dispose();

            labelNombre.Text = labelNombreText;
            //labelSuperficie.Text = labelSuperficieText;
            //labelSector.Text = labelSectorText;
            //labelDescripcion.Text = labelDescripcionText;
        }


        private void comboBoxSitios_Populate()
        {
            cmd = SqlConnector.getConnection(cmd);

            string sqlQueryString = "SELECT numero_sitio FROM `sitios` where proyecto_id = @proyecto_id";
            cmd.CommandText = sqlQueryString;
            cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);

            var results = cmd.ExecuteReader();

            while (results.Read())
            {
                comboBoxSitios.Items.Add(results[0]);
            }

            results.Close();
            results.Dispose();
        }

        private void dataGridViewIndividuos_Populate()
        {
            dataGridViewIndividuos.Rows.Clear();

            cmd = SqlConnector.getConnection(cmd);

            string sqlQueryString = "SELECT cuadrante, numero, arbolnumeroensitio, bifurcados, nombrecientifico, " +
                "nombrecomun, familia, genero, perimetro, diametro, alturafl, alturatotal, coberturalargo, coberturaancho, " +
                "formadefuste, estadocondicion, grupo, volumenvv " +
                " from `individuos` where proyecto_id = @proyecto_id AND sitio = @sitio AND area = @area ORDER BY arbolnumeroensitio DESC";
            cmd.CommandText = sqlQueryString;
            cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);
            cmd.Parameters.AddWithValue("@sitio", comboBoxSitios.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@area", comboBoxAreas.SelectedItem.ToString());

            var results = cmd.ExecuteReader();


            while (results.Read())
            {
                List<Object> lista_individuos = new List<Object>();
                lista_individuos.Add(results[0]);
                lista_individuos.Add(results[1]);
                lista_individuos.Add(results[2]);
                lista_individuos.Add(results[3]);
                lista_individuos.Add(results[4]);
                lista_individuos.Add(results[5]);
                lista_individuos.Add(results[6]);
                lista_individuos.Add(results[7]);
                lista_individuos.Add(results[8]);
                lista_individuos.Add(results[9]);
                lista_individuos.Add(results[10]);
                lista_individuos.Add(results[11]);
                lista_individuos.Add(results[12]);
                lista_individuos.Add(results[13]);
                lista_individuos.Add(results[14]);
                lista_individuos.Add(results[15]);
                lista_individuos.Add(results[16]);
                lista_individuos.Add(results[17]);

                dataGridViewIndividuos.Rows.Insert(0, lista_individuos.ToArray());
                if (Convert.ToBoolean(dataGridViewIndividuos.Rows[0].Cells["bifurcados"].Value))
                {
                    dataGridViewIndividuos.Rows[0].DefaultCellStyle.BackColor = Color.DarkGray;
                }
            }

            results.Close();
            results.Dispose();
        }



        private void button12_Click(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Minimized;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //System.Windows.Forms.Application.Exit();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            //this.Hide(); //esconde el form actual


            //FormRegistro1 objeto = new FormRegistro1(); //objeto declarado para abrir el form2
            //objeto.Show(); //abre el form declarado con el objeto
            form1.formRegistro1ToFront();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            /*this.Hide(); //esconde el form actual


            FormRegistro3 objeto = new FormRegistro3(); //objeto declarado para abrir el form3
            objeto.Show(); //abre el form declarado con el objeto*/
        }

        private void buttonAgregarIndividuo_Click(object sender, EventArgs e)
        {
            cmd = SqlConnector.getConnection(cmd);
            int numero = comboBoxAreas.SelectedIndex + 1;

            string sqlQueryString = "SELECT numero_consecutivo" + numero + " FROM `sitios` where proyecto_id = @proyecto_id AND numero_sitio = @numero_sitio";
            cmd.CommandText = sqlQueryString;
            cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);
            cmd.Parameters.AddWithValue("@numero_sitio", comboBoxSitios.SelectedItem);

            var results = cmd.ExecuteReader();

            results.Read();

            int numero_consecutivo = (int)results[0];

            results.Close();
            results.Dispose();

            cmd = SqlConnector.getConnection(cmd);
            cmd.CommandText = "UPDATE sitios SET numero_consecutivo" + numero + " = @numero_consecutivo WHERE proyecto_id = @proyecto_id AND numero_sitio = @numero_sitio";
            cmd.Parameters.AddWithValue("@numero_consecutivo", numero_consecutivo + 1);
            cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);
            cmd.Parameters.AddWithValue("@numero_sitio", comboBoxSitios.SelectedItem);
            cmd.ExecuteNonQuery();

            var newRow = dataGridViewIndividuos.Rows[dataGridViewIndividuos.Rows.Add()];
            newRow.Cells["numero"].Value = numero_consecutivo;
            newRow.Cells["bifurcados"].Value = false;
            if (dataGridViewIndividuos.RowCount > 1)
            {
                newRow.Cells["arbolnumeroensitio"].Value = Convert.ToInt32(dataGridViewIndividuos.Rows[dataGridViewIndividuos.RowCount - 2].Cells["arbolnumeroensitio"].Value) + 1;
            }
            else
            {
                newRow.Cells["arbolnumeroensitio"].Value = 1;
            }

            var row = dataGridViewIndividuos.Rows[dataGridViewIndividuos.RowCount - 1];

            cmd = SqlConnector.getConnection(cmd);
            cmd.CommandText = "Insert into individuos(proyecto_id, sitio, area, numero, arbolnumeroensitio, bifurcados)" +
                "Values(@proyecto_id, @sitio, @area, @numero, @arbolnumeroensitio, false)";
            cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);
            cmd.Parameters.AddWithValue("@sitio", comboBoxSitios.SelectedItem);
            cmd.Parameters.AddWithValue("@area", comboBoxAreas.SelectedItem);
            cmd.Parameters.AddWithValue("@numero", row.Cells["numero"].Value);
            cmd.Parameters.AddWithValue("@arbolnumeroensitio", row.Cells["arbolnumeroensitio"].Value);
            cmd.ExecuteNonQuery();
        }

        private void buttonAgregarBifurcacion_Click(object sender, EventArgs e)
        {
            if (dataGridViewIndividuos.SelectedRows.Count > 0)
            {
                var row = dataGridViewIndividuos.SelectedRows[0];
                var clonedRow = (DataGridViewRow)row.Clone();
                for (Int32 index = 0; index < row.Cells.Count; index++)
                {
                    clonedRow.Cells[index].Value = row.Cells[index].Value;
                }
                clonedRow.Cells[2].Value = Convert.ToInt32(row.Cells[2].Value) + 1;

                dataGridViewIndividuos.Rows.Insert(row.Index + 1, clonedRow);
                clonedRow.DefaultCellStyle.BackColor = Color.Gray;

                cmd = SqlConnector.getConnection(cmd);
                cmd.CommandText = "UPDATE individuos SET arbolnumeroensitio = (arbolnumeroensitio + 1) WHERE proyecto_id = @proyecto_id AND sitio = @sitio AND area = @area AND arbolnumeroensitio > @arbolnumeroensitio";
                cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);
                cmd.Parameters.AddWithValue("@sitio", comboBoxSitios.SelectedItem);
                cmd.Parameters.AddWithValue("@area", comboBoxAreas.SelectedItem);
                cmd.Parameters.AddWithValue("@arbolnumeroensitio", dataGridViewIndividuos.Rows[row.Index].Cells["arbolnumeroensitio"].Value);
                cmd.ExecuteNonQuery();

                cmd = SqlConnector.getConnection(cmd);
                cmd.CommandText = "Insert into individuos(proyecto_id, sitio, area, cuadrante, numero, arbolnumeroensitio, bifurcados, nombrecientifico, nombrecomun, familia, genero, perimetro, diametro, alturafl, alturatotal, coberturaancho, coberturalargo, formadefuste, estadocondicion)" +
                    "Values(@proyecto_id, @sitio, @area, @cuadrante, @numero, @arbolnumeroensitio, true, @nombrecientifico, @nombrecomun, @familia, @genero, @perimetro, @diametro, @alturafl, @alturatotal, @coberturaancho, @coberturalargo, @formadefuste, @estadocondicion)";
                cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);
                cmd.Parameters.AddWithValue("@sitio", comboBoxSitios.SelectedItem);
                cmd.Parameters.AddWithValue("@area", comboBoxAreas.SelectedItem);
                cmd.Parameters.AddWithValue("@cuadrante", clonedRow.Cells["cuadrante"].Value);
                cmd.Parameters.AddWithValue("@numero", clonedRow.Cells["numero"].Value);
                cmd.Parameters.AddWithValue("@arbolnumeroensitio", clonedRow.Cells["arbolnumeroensitio"].Value);
                cmd.Parameters.AddWithValue("@nombrecientifico", clonedRow.Cells["nombrecientifico"].Value);
                cmd.Parameters.AddWithValue("@nombrecomun", clonedRow.Cells["nombrecomun"].Value);
                cmd.Parameters.AddWithValue("@familia", clonedRow.Cells["familia"].Value);
                cmd.Parameters.AddWithValue("@genero", clonedRow.Cells["genero"].Value);
                cmd.Parameters.AddWithValue("@perimetro", clonedRow.Cells["perimetro"].Value);
                cmd.Parameters.AddWithValue("@diametro", clonedRow.Cells["diametro"].Value);
                cmd.Parameters.AddWithValue("@alturafl", clonedRow.Cells["alturafl"].Value);
                cmd.Parameters.AddWithValue("@alturatotal", clonedRow.Cells["alturatotal"].Value);
                cmd.Parameters.AddWithValue("@coberturaancho", clonedRow.Cells["coberturaancho"].Value);
                cmd.Parameters.AddWithValue("@coberturalargo", clonedRow.Cells["coberturalargo"].Value);
                cmd.Parameters.AddWithValue("@formadefuste", clonedRow.Cells["formadefuste"].Value);
                cmd.Parameters.AddWithValue("@estadocondicion", clonedRow.Cells["estadocondicion"].Value);

                cmd.ExecuteNonQuery();

                dataGridViewIndividuos_Populate();
            }
        }

        private void buttonEliminarIndividuo_Click(object sender, EventArgs e)
        {
            if (dataGridViewIndividuos.SelectedRows.Count > 0)
            {
                var row = dataGridViewIndividuos.SelectedRows[0];
                int numero = comboBoxAreas.SelectedIndex + 1;

                if (!(bool)row.Cells["bifurcados"].Value)
                {
                    cmd = SqlConnector.getConnection(cmd);
                    string sqlQueryString = "SELECT COUNT(id) FROM individuos WHERE proyecto_id = @proyecto_id AND sitio = @sitio AND area = @area AND numero = @numero";
                    cmd.CommandText = sqlQueryString;
                    cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);
                    cmd.Parameters.AddWithValue("@sitio", comboBoxSitios.SelectedItem);
                    cmd.Parameters.AddWithValue("@area", comboBoxAreas.SelectedItem);
                    cmd.Parameters.AddWithValue("@numero", dataGridViewIndividuos.Rows[row.Index].Cells["numero"].Value);

                    var results = cmd.ExecuteReader();

                    results.Read();

                    int numero_elementos = Convert.ToInt32(results[0]);

                    results.Close();
                    results.Dispose();

                    cmd = SqlConnector.getConnection(cmd);
                    cmd.CommandText = "DELETE FROM individuos WHERE proyecto_id = @proyecto_id AND sitio = @sitio AND area = @area AND numero  = @numero";
                    cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);
                    cmd.Parameters.AddWithValue("@sitio", comboBoxSitios.SelectedItem);
                    cmd.Parameters.AddWithValue("@area", comboBoxAreas.SelectedItem);
                    cmd.Parameters.AddWithValue("@numero", dataGridViewIndividuos.Rows[row.Index].Cells["numero"].Value);
                    cmd.ExecuteNonQuery();

                    cmd = SqlConnector.getConnection(cmd);
                    cmd.CommandText = "UPDATE individuos SET numero = (numero - 1) WHERE proyecto_id = @proyecto_id AND sitio = @sitio AND area = @area AND numero > @numero";
                    cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);
                    cmd.Parameters.AddWithValue("@sitio", comboBoxSitios.SelectedItem);
                    cmd.Parameters.AddWithValue("@area", comboBoxAreas.SelectedItem);
                    cmd.Parameters.AddWithValue("@numero", dataGridViewIndividuos.Rows[row.Index].Cells["numero"].Value);
                    cmd.ExecuteNonQuery();

                    cmd = SqlConnector.getConnection(cmd);
                    cmd.CommandText = "UPDATE individuos SET arbolnumeroensitio = (arbolnumeroensitio - " + numero_elementos + ") WHERE proyecto_id = @proyecto_id AND sitio = @sitio AND area = @area AND arbolnumeroensitio > @arbolnumeroensitio";
                    cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);
                    cmd.Parameters.AddWithValue("@sitio", comboBoxSitios.SelectedItem);
                    cmd.Parameters.AddWithValue("@area", comboBoxAreas.SelectedItem);
                    cmd.Parameters.AddWithValue("@arbolnumeroensitio", dataGridViewIndividuos.Rows[row.Index].Cells["arbolnumeroensitio"].Value);
                    cmd.ExecuteNonQuery();

                    cmd = SqlConnector.getConnection(cmd);
                    cmd.CommandText = "UPDATE sitios SET numero_consecutivo" + numero + " = (numero_consecutivo" + numero + " - 1) WHERE proyecto_id = @proyecto_id AND numero_sitio = @numero_sitio";
                    cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);
                    cmd.Parameters.AddWithValue("@numero_sitio", comboBoxSitios.SelectedItem);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    cmd = SqlConnector.getConnection(cmd);
                    cmd.CommandText = "DELETE FROM individuos WHERE proyecto_id = @proyecto_id AND sitio = @sitio AND area = @area AND arbolnumeroensitio = @arbolnumeroensitio";
                    cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);
                    cmd.Parameters.AddWithValue("@sitio", comboBoxSitios.SelectedItem);
                    cmd.Parameters.AddWithValue("@area", comboBoxAreas.SelectedItem);
                    cmd.Parameters.AddWithValue("@arbolnumeroensitio", dataGridViewIndividuos.Rows[row.Index].Cells["arbolnumeroensitio"].Value);
                    cmd.ExecuteNonQuery();

                    cmd = SqlConnector.getConnection(cmd);
                    cmd.CommandText = "UPDATE individuos SET arbolnumeroensitio = (arbolnumeroensitio - 1) WHERE proyecto_id = @proyecto_id AND sitio = @sitio AND area = @area AND arbolnumeroensitio > @arbolnumeroensitio";
                    cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);
                    cmd.Parameters.AddWithValue("@sitio", comboBoxSitios.SelectedItem);
                    cmd.Parameters.AddWithValue("@area", comboBoxAreas.SelectedItem);
                    cmd.Parameters.AddWithValue("@arbolnumeroensitio", dataGridViewIndividuos.Rows[row.Index].Cells["arbolnumeroensitio"].Value);
                    cmd.ExecuteNonQuery();
                }

                dataGridViewIndividuos_Populate();

                /*
                if (dataGridViewIndividuos.RowCount > 0)
                {
                    if (dataGridViewIndividuos.SelectedRows.Count > 0)
                    {
                        dataGridViewIndividuos.Rows.RemoveAt(row.Index);
                    }
                }
                */
            }
        }

        private void labelNombre_Click(object sender, EventArgs e)
        {

        }

        private void textboxSetAutoComplete(TextBox textbox)
        {
            textbox.AutoCompleteCustomSource = source;
            textbox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textbox.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void updateData(string name, DataGridViewRow row, string newdata)
        {
            cmd = SqlConnector.getConnection(cmd);
            cmd.CommandText = "UPDATE individuos SET " + name + " = @" + name + " WHERE proyecto_id = @proyecto_id AND sitio = @sitio AND area = @area AND numero = @numero";
            cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);
            cmd.Parameters.AddWithValue("@sitio", comboBoxSitios.SelectedItem);
            cmd.Parameters.AddWithValue("@area", comboBoxAreas.SelectedItem);
            cmd.Parameters.AddWithValue("@numero", row.Cells["numero"].Value);
            cmd.Parameters.AddWithValue("@" + name, newdata);
            cmd.ExecuteNonQuery();
        }

        private void getEspecies()
        {
            especiesObject = new List<Especie>();
            especiesString = new List<string>();
            cmd = SqlConnector.getConnection(cmd);

            string sqlQueryString = "SELECT nombrecientifico, familia, genero FROM especies";
            cmd.CommandText = sqlQueryString;

            var results = cmd.ExecuteReader();

            while (results.Read())
            {
                string labelNombreCientificoText = results[0].ToString();
                string labelFamiliaText = results[1].ToString();
                string labelGeneroText = results[2].ToString();

                //especiesObject.Add(new Especie(labelNombreCientificoText, labelFamiliaText, labelGeneroText));
                especiesString.Add(labelNombreCientificoText);
            }

            results.Close();
            results.Dispose();

            source.AddRange(especiesString.ToArray());
        }

        private void dataGridViewIndividuos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            /*
            int row_index = dataGridViewIndividuos.CurrentCell.RowIndex;
            string column_name = dataGridViewIndividuos.Columns[dataGridViewIndividuos.CurrentCell.ColumnIndex].Name;

            var source = new AutoCompleteStringCollection();
            source.AddRange(new string[]
            {
                "January",
                "February",
                "March",
                "April",
                "May",
                "June",
                "July",
                "August",
                "September",
                "October",
                "November",
                "December"
            });

            
            dataGridViewIndividuos.Rows[row_index].Cells[0];
            AutoCompleteCustomSource = source,
            AutoCompleteMode =
                AutoCompleteMode.SuggestAppend,
            AutoCompleteSource =
            AutoCompleteSource.CustomSource
            */
        }

        private void dataGridViewIndividuos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int column = dataGridViewIndividuos.CurrentCell.ColumnIndex;
            string headerText = dataGridViewIndividuos.Columns[column].HeaderText;

            if (headerText.Equals("Nombre Científico"))
            {
                TextBox tb = e.Control as TextBox;

                if (tb != null)
                {
                    tb.AutoCompleteCustomSource = source;
                    tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    tb.AutoCompleteSource = AutoCompleteSource.CustomSource;

                }

            }
        }

        /*private void button6_Click(object sender, EventArgs e)
        {

        }*/

        private void buttonGrafica_Click(object sender, EventArgs e)
        {
            //form1.formRegistro1ToFront();
            form1.graficaToFront(proyecto_id);
        }

        private void buttonImportar_Click(object sender, EventArgs e)
        {
            cmd = SqlConnector.getConnection(cmd);
            cmd.CommandText = "Delete from individuos where proyecto_id = " + proyecto_id;
            cmd.ExecuteNonQuery();
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            DataSet dataSet = new DataSet();
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                dataSet = ReadXlsx(openFileDialog1.FileName);
            }

            DataTable dt = new DataTable();
            dt = dataSet.Tables[0];

            //Cuadrante, NoenCampo, Consecutivo, Familia, nombrecientifico, nombrecomun, perimetro, diametro, altura fuste, altura total, cobertura, forma fuste, estado condicion, bifurcado, ALT CAT, DN CAT, Grupo, Ecuacion Volumen, Volumen
            String[] array;
            int sitio_max = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                array = new String[50];
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    var val = dt.Rows[i][j].ToString().Trim();
                    array[j] = val;
                    //sendMessageBox(val);
                }

                cmd = SqlConnector.getConnection(cmd);
                cmd.CommandText = "Insert into individuos(proyecto_id, sitio, area, cuadrante, numero, arbolnumeroensitio, familia, nombrecientifico, nombrecomun, perimetro, diametro, alturafl, alturatotal, coberturalargo, coberturaancho, formadefuste, estadocondicion, bifurcados, atcategorias, dncategorias, volumenvv, areabasal)" +
                    "Values(@proyecto_id, @sitio, @area, @cuadrante, @numero, @arbolnumeroensitio, @familia, @nombrecientifico, @nombrecomun, @perimetro, @diametro, @alturafl, @alturatotal, @coberturalargo, @coberturaancho, @formadefuste, @estadocondicion, @bifurcados, @atcategorias, @dncategorias, @volumenvv, @areabasal)";
                cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);
                cmd.Parameters.AddWithValue("@sitio", array[0]);
                cmd.Parameters.AddWithValue("@area", array[1]);
                cmd.Parameters.AddWithValue("@cuadrante", array[2]);
                cmd.Parameters.AddWithValue("@numero", array[3]);
                cmd.Parameters.AddWithValue("@arbolnumeroensitio", array[4]);
                cmd.Parameters.AddWithValue("@familia", array[5]);
                cmd.Parameters.AddWithValue("@nombrecientifico", array[6]);
                cmd.Parameters.AddWithValue("@nombrecomun", array[7]);
                cmd.Parameters.AddWithValue("@perimetro", array[8]);
                cmd.Parameters.AddWithValue("@diametro", array[9]);
                cmd.Parameters.AddWithValue("@alturafl", array[10]);
                cmd.Parameters.AddWithValue("@alturatotal", array[11]);
                cmd.Parameters.AddWithValue("@coberturalargo", array[12]);
                cmd.Parameters.AddWithValue("@coberturaancho", array[12]);
                cmd.Parameters.AddWithValue("@formadefuste", "");  // array[13]);
                cmd.Parameters.AddWithValue("@estadocondicion", ""); //array[14]);
                //sendMessageBox(array[3] + " - " + array[6] + ": " + array[15]);
                if (array[15] == "un fuste")
                {
                    cmd.Parameters.AddWithValue("@bifurcados", 0); // array[15]);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@bifurcados", 1); // array[15]);
                }
                cmd.Parameters.AddWithValue("@atcategorias", array[16]);
                cmd.Parameters.AddWithValue("@dncategorias", array[17]);
                cmd.Parameters.AddWithValue("@grupo", array[18]);
                cmd.Parameters.AddWithValue("@volumenvv", array[20]);
                double areabasal = 0;
                try
                {
                    double aux = Convert.ToDouble(array[9]) / 2;
                    double aux2 = Math.Pow(aux, 2);
                    areabasal = (Math.PI * aux) / 10000;
                }
                catch (Exception ex)
                {
                }
                cmd.Parameters.AddWithValue("@areabasal", "" + areabasal);
                cmd.ExecuteNonQuery();

                

                int sitio_aux = Convert.ToInt32(array[0]);
                if (sitio_max < sitio_aux)
                {
                    sitio_max = sitio_aux;
                }
            }

            sendMessageBox("Importacion Completa");
            for (int i = 1; i <= sitio_max; i++)
            {
                cmd = SqlConnector.getConnection(cmd);
                cmd.CommandText = "Insert into sitios(proyecto_id, numero_sitio)" +
                    "Values(@proyecto_id, @numero_sitio)";
                cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);
                cmd.Parameters.AddWithValue("@numero_sitio", i);
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
