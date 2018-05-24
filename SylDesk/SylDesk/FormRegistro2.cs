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

                updateData("perimetro", row, Convert.ToString(row.Cells["perimetro"].Value));

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

                    grupo_especie(row);
                    volumen_ecuacion(row);                    
                }
                else
                {
                    results.Close();
                    results.Dispose();

                    sendMessageBox("No existe esa especie!");
                    row.Cells[column_name].Value = "";

                    row.Cells["nombrecomun"].Value = "";
                    row.Cells["familia"].Value = "";
                    row.Cells["genero"].Value = "";

                    updateData("nombrecomun", row, "");
                    updateData("familia", row, "");
                    updateData("genero", row, "");
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
                    String sgrupo = row.Cells["grupo"].Value.ToString();
                    String snombrecientifico = row.Cells["nombrecientifico"].Value.ToString();

                    if (!sdiametro.Equals("") && !salturatotal.Equals("") && !sgrupo.Equals("") && !snombrecientifico.Equals(""))
                    {
                        cmd = SqlConnector.getConnection(cmd);

                        String sqlQueryString = "SELECT ecuacion, num1, num2, num3 FROM ecuaciones_volumen where grupo = @grupo";
                        cmd.CommandText = sqlQueryString;
                        cmd.Parameters.AddWithValue("@grupo", row.Cells["grupo"].Value);

                        var results = cmd.ExecuteReader();

                        if (results.Read())
                        {
                            string ecuacion = results[0].ToString();
                            sendMessageBox("V= " + ecuacion);
                            double num1 = Convert.ToDouble(results[1].ToString());
                            double num2 = Convert.ToDouble(results[2].ToString());
                            double num3 = Convert.ToDouble(results[3].ToString());
                            double diametro = Convert.ToDouble(row.Cells["diametro"].Value);
                            double alturatotal = Convert.ToDouble(row.Cells["alturatotal"].Value);
                            double volumen = Math.Exp(num1 + num2 * Math.Log(diametro) + num3 * Math.Log(alturatotal));

                            results.Close();
                            results.Dispose();

                            row.Cells["volumen"].Value = volumen;
                            updateData("volumenvv", row, "" + volumen);
                        }
                        else
                        {
                            results.Close();
                            results.Dispose();

                            row.Cells["volumen"].Value = volumen;
                            updateData("volumenvv", row, "" + volumen);
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

            Empty();
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

                especiesObject.Add(new Especie(labelNombreCientificoText, labelFamiliaText, labelGeneroText));
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

            if (headerText.Equals("Nombre Cientifico"))
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

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void buttonGrafica_Click(object sender, EventArgs e)
        {
            Empty();
            //form1.formRegistro1ToFront();
            form1.graficaToFront();
            
        }
    }
}
