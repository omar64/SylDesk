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
        AutoCompleteStringCollection source = new AutoCompleteStringCollection();

        public FormRegistro2()
        {
            InitializeComponent();
            getEspecies();
        }

        public void setForm(Form1 form1)
        {
            this.form1 = form1;
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
                Especie especie = SqlConnector.especieGet(
                    "SELECT * FROM especies where nombrecientifico = @nombrecientifico",
                    new String[] { "nombrecientifico" },
                    new String[] { row.Cells["nombrecientifico"].Value.ToString() }
                );

                if (especie != null)
                {
                    string textBoxNombreCientifico = row.Cells["nombrecientifico"].Value.ToString();
                    string textBoxNombreComun = especie.getNombreComun();
                    string textBoxFamilia = especie.getFamilia();
                    string textBoxGenero = especie.getGenero();

                    
                    row.Cells["nombrecomun"].Value = textBoxNombreComun;
                    row.Cells["familia"].Value = textBoxFamilia;
                    row.Cells["genero"].Value = textBoxGenero;

                    updateData("nombrecomun", row, textBoxNombreComun);
                    updateData("familia", row, textBoxFamilia);
                    updateData("genero", row, textBoxGenero);

                    volumen_ecuacion(row);                    
                }
                else
                {
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
                        form1.formRegistroEspecieToFront(proyecto_id, 1, "" + row.Cells[column_name].Value);
                    }
                    row.Cells[column_name].Value = "";

                    row.Cells["nombrecomun"].Value = "";
                    row.Cells["familia"].Value = "";
                    row.Cells["genero"].Value = "";
                    row.Cells["volumen"].Value = "0";

                    updateData("nombrecomun", row, "");
                    updateData("familia", row, "");
                    updateData("genero", row, "");
                    updateData("volumen", row, "");

                }
            }

            updateData(column_name, row, row.Cells[column_name].Value.ToString());
        }

        private void volumen_ecuacion(DataGridViewRow row)
        {
            try
            {
                if (comboBoxAreas.SelectedIndex == 0)
                {
                    String sdiametro = row.Cells["diametro"].Value.ToString();
                    String salturatotal = row.Cells["alturatotal"].Value.ToString();
                    String nombrecientifico = row.Cells["nombrecientifico"].Value.ToString();

                    double diametro = Convert.ToDouble(row.Cells["diametro"].Value);
                    double alturatotal = Convert.ToDouble(row.Cells["alturatotal"].Value);
                    double perimetro = Convert.ToDouble(row.Cells["perimetro"].Value);
                    double areabasal = Convert.ToDouble(row.Cells["areabasal"].Value);
                    double alturafl = Convert.ToDouble(row.Cells["alturafl"].Value);
                    double coberturalargo = Convert.ToDouble(row.Cells["coberturalargo"].Value);
                    double coberturaancho = Convert.ToDouble(row.Cells["coberturaancho"].Value);

                    bool found_flag = false;

                    if (!sdiametro.Equals("") && !salturatotal.Equals("") && !nombrecientifico.Equals("")) // && !sgrupo.Equals("")
                    {

                        List<ProyectoEcuacion> list_proyecto_ecuacion = SqlConnector.proyectoEcuacionesGet(
                            "SELECT * FROM `proyecto_ecuaciones` Where proyecto_id = @proyecto_id",
                            new String[] { "proyecto_id" },
                            new String[] { "" + proyecto_id }
                        );
                        List<String> umafor_region_list = new List<String>();


                        foreach (ProyectoEcuacion proyecto_ecuacion in list_proyecto_ecuacion)
                        {
                            umafor_region_list.Add(proyecto_ecuacion.getUmaforRegion());
                        }
                        

                        foreach(String umafor_region in umafor_region_list)
                        {
                            //ecuacion, num1, num2, num3
                            EcuacionVolumen ecuacion_volumen = SqlConnector.ecuacionVolumenGet(
                                "SELECT * FROM ecuaciones_volumen where especie = @especie AND umafor = @umafor",
                                new String[] { "especie", "umafor" },
                                new String[] { nombrecientifico, umafor_region }
                            );

                            if(ecuacion_volumen != null)
                            {

                                string ecuacion = ecuacion_volumen.getEcuacion();

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
                                updateData("volumen", row, "" + volumen);
                                found_flag = true;
                                break;
                            }
                        }

                        if (!found_flag)
                        {
                            //SqlConnector.sendMessageBox("Algunas especies capturadas no presentan ecuación para los inventarios seleccionados o no existe ecuación registrada. Para su registro se desplegará el editor de ecuaciones.");
                            if(SqlConnector.sendYNMessageBox("Algunas especies capturadas no presentan ecuación para los inventarios seleccionados o no existe ecuación registrada. Para su registro se desplegará el editor de ecuaciones.\n\n Usar ventana emergente?") == DialogResult.Yes)
                            {
                                FormEmergente form_emergente = new FormEmergente();
                                form_emergente.Show();
                            }
                            else
                            {
                                form1.calculadoraEcuToFront(proyecto_id, 1, nombrecientifico);
                            }
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

        private void buttonAgregarSitio_Click(object sender, EventArgs e)
        {
            comboBoxSitios.Items.Add(comboBoxSitios.Items.Count + 1);
            SqlConnector.postPutDeleteGenerico(
                "Insert into sitios(proyecto_id, numero_sitio)Values(@proyecto_id, @numero_sitio)",
                new String[] { "proyecto_id", "numero_sitio" },
                new String[] { "" + proyecto_id, "" + comboBoxSitios.Items.Count }
            );
        }

        private void buttonBorrarSitio_Click(object sender, EventArgs e)
        {
            if (comboBoxSitios.Items.Count > 1)
            {
                SqlConnector.postPutDeleteGenerico(
                    "DELETE FROM individuos WHERE proyecto_id = @proyecto_id AND sitio = @sitio",
                    new String[] { "proyecto_id", "sitio" },
                    new String[] { "" + proyecto_id, "" + comboBoxSitios.Items.Count }
                );

                SqlConnector.postPutDeleteGenerico(
                    "DELETE FROM sitios WHERE proyecto_id = @proyecto_id AND numero_sitio = @numero_sitio",
                    new String[] { "proyecto_id", "numero_sitio" },
                    new String[] { "" + proyecto_id, "" + comboBoxSitios.Items.Count }
                );

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
            SqlConnector.postPutDeleteGenerico(
                "UPDATE sitios SET coordenada_x = @coordenada_x WHERE proyecto_id = @proyecto_id AND numero_sitio = @numero_sitio",
                new String[] { "coordenada_x", "proyecto_id", "numero_sitio" },
                new String[] { textBoxX.Text, "" + proyecto_id, "" + comboBoxSitios.SelectedItem }
            );
        }

        private void textBoxY_TextChanged(object sender, EventArgs e)
        {
            SqlConnector.postPutDeleteGenerico(
                "UPDATE sitios SET coordenada_y = @coordenada_y WHERE proyecto_id = @proyecto_id AND numero_sitio = @numero_sitio",
                new String[] { "coordenada_y", "proyecto_id", "numero_sitio" },
                new String[] { textBoxX.Text, "" + proyecto_id, "" + comboBoxSitios.SelectedItem }
            );
        }

        private void textBoxMunicipio_TextChanged(object sender, EventArgs e)
        {
            SqlConnector.postPutDeleteGenerico(
                "UPDATE sitios SET municipio = @municipio WHERE proyecto_id = @proyecto_id AND numero_sitio = @numero_sitio",
                new String[] { "municipio", "proyecto_id", "numero_sitio" },
                new String[] { textBoxMunicipio.Text, "" + proyecto_id, "" + comboBoxSitios.SelectedItem }
            );
        }

        private void textBoxEstadoSucesional_TextChanged(object sender, EventArgs e)
        {
            SqlConnector.postPutDeleteGenerico(
                "UPDATE sitios SET estado_sucesional = @estado_sucesional WHERE proyecto_id = @proyecto_id AND numero_sitio = @numero_sitio",
                new String[] { "estado_sucesional", "proyecto_id", "numero_sitio" },
                new String[] { textBoxEstadoSucesional.Text, "" + proyecto_id, "" + comboBoxSitios.SelectedItem }
            );
        }


        private void fillForm()
        {
            Sitio sitio = SqlConnector.sitioGet(
                "SELECT * FROM `sitios` where proyecto_id = @proyecto_id AND numero_sitio = @numero_sitio",
                new String[] { "proyecto_id", "numero_sitio" },
                new String[] { "" + proyecto_id, "" + comboBoxSitios.SelectedItem }
            );

            string textBoxMunicipioText = sitio.getMunicipio();
            string textBoxXText = sitio.getCoordenadaX();
            string textBoxYText = sitio.getCoordenadaY();
            string textBoxEstadoSucesionalText = sitio.getEstadoSucesional();

            textBoxMunicipio.Text = textBoxMunicipioText;
            textBoxX.Text = textBoxXText;
            textBoxY.Text = textBoxYText;
            textBoxEstadoSucesional.Text = textBoxEstadoSucesionalText;

            Proyecto proyecto = SqlConnector.proyectoGet(
                "SELECT * FROM `proyectos` where id = @proyecto_id",
                new String[] { "proyecto_id" },
                new String[] { "" + proyecto_id }
            );

            string labelNombreText = proyecto.getNombre();
            string labelSuperficieText = proyecto.getSuperficie();
            string labelDescripcionText = proyecto.getDescripcion();

            labelNombre.Text = labelNombreText;
        }


        private void comboBoxSitios_Populate()
        {
            List<Sitio> list_sitios = SqlConnector.sitiosGet(
                "SELECT * FROM `sitios` where proyecto_id = @proyecto_id",
                new String[] { "proyecto_id" },
                new String[] { "" + proyecto_id }
            );

            foreach (Sitio sitio in list_sitios)
            {
                comboBoxSitios.Items.Add(sitio.getNumeroSitio());
            }
        }

        private void dataGridViewIndividuos_Populate()
        {
            dataGridViewIndividuos.Rows.Clear();

            List<Individuo> list_individuos = SqlConnector.individuosGet(
                "SELECT * from `individuos` where proyecto_id = @proyecto_id AND sitio = @sitio AND area = @area ORDER BY arbolnumeroensitio DESC",
                new String[] { "proyecto_id", "sitio", "area" },
                new String[] { "" + proyecto_id, comboBoxSitios.SelectedItem.ToString(), comboBoxAreas.SelectedItem.ToString() }
            );
            
            foreach(Individuo individuo in list_individuos)
            {
                List<Object> lista_individuos = new List<Object>();

                lista_individuos.Add(individuo.getCuadrante());
                lista_individuos.Add(individuo.getNumero());
                lista_individuos.Add(individuo.getNumeroArbolEnSitio());
                lista_individuos.Add(individuo.getBifurcados());
                lista_individuos.Add(individuo.getNombreCientifico());
                lista_individuos.Add(individuo.getNombreComun());
                lista_individuos.Add(individuo.getFamilias());
                lista_individuos.Add(individuo.getGenero());
                lista_individuos.Add(individuo.getPerimetro());
                lista_individuos.Add(individuo.getDiametro());
                lista_individuos.Add(individuo.getAlturaFl());
                lista_individuos.Add(individuo.getAlturaTotal());
                lista_individuos.Add(individuo.getCoberturaLargo());
                lista_individuos.Add(individuo.getCoberturaAncho());
                lista_individuos.Add(individuo.getFormaFuste());
                lista_individuos.Add(individuo.getEstadoCondicion());
                lista_individuos.Add(individuo.getGrupo());
                lista_individuos.Add(individuo.getVolumen());

                dataGridViewIndividuos.Rows.Insert(0, lista_individuos.ToArray());
                if (Convert.ToBoolean(dataGridViewIndividuos.Rows[0].Cells["bifurcados"].Value))
                {
                    dataGridViewIndividuos.Rows[0].DefaultCellStyle.BackColor = Color.DarkGray;
                }
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            form1.formRegistro1ToFront();
        }


        private void buttonAgregarIndividuo_Click(object sender, EventArgs e)
        {
            int numero = comboBoxAreas.SelectedIndex + 1;

            Sitio sitio = SqlConnector.sitioGet(
                "SELECT * FROM `sitios` where proyecto_id = @proyecto_id AND numero_sitio = @numero_sitio",
                new String[] { "proyecto_id", "numero_sitio" },
                new String[] { "" + proyecto_id, comboBoxSitios.SelectedItem.ToString() }
            );

            int numero_consecutivo;
            if (numero == 1)
            {
                numero_consecutivo = Convert.ToInt32(sitio.getNumeroConsecutivo1());
            }
            else if(numero == 2)
            {
                numero_consecutivo = Convert.ToInt32(sitio.getNumeroConsecutivo2());
            }
            else
            {
                numero_consecutivo = Convert.ToInt32(sitio.getNumeroConsecutivo3());
            }

            SqlConnector.postPutDeleteGenerico(
                "UPDATE sitios SET numero_consecutivo" + numero + " = @numero_consecutivo WHERE proyecto_id = @proyecto_id AND numero_sitio = @numero_sitio",
                new String[] { "numero_consecutivo", "proyecto_id", "numero_sitio" },
                new String[] { ""  + (numero_consecutivo + 1), "" + proyecto_id, comboBoxSitios.SelectedItem.ToString() }
            );


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

            SqlConnector.postPutDeleteGenerico(
                "Insert into individuos(proyecto_id, sitio, area, numero, arbolnumeroensitio, bifurcados)" +
                "Values(@proyecto_id, @sitio, @area, @numero, @arbolnumeroensitio, false)",
                new String[] { "proyecto_id", "sitio", "area", "numero", "arbolnumeroensitio" },
                new String[] { "" + proyecto_id, comboBoxSitios.SelectedItem.ToString(), comboBoxAreas.SelectedItem.ToString(), row.Cells["numero"].Value.ToString(), row.Cells["arbolnumeroensitio"].Value.ToString() }
            );
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

                SqlConnector.postPutDeleteGenerico(
                    "UPDATE individuos SET arbolnumeroensitio = (arbolnumeroensitio + 1) WHERE proyecto_id = @proyecto_id AND sitio = @sitio AND area = @area AND arbolnumeroensitio > @arbolnumeroensitio",
                    new String[] { "proyecto_id", "sitio", "area", "arbolnumeroensitio" },
                    new String[] { "" + proyecto_id, comboBoxSitios.SelectedItem.ToString(), comboBoxAreas.SelectedItem.ToString(), row.Cells["arbolnumeroensitio"].Value.ToString() }
                );

                SqlConnector.postPutDeleteGenerico(
                    "Insert into individuos(proyecto_id, sitio, area, cuadrante, numero, arbolnumeroensitio, bifurcados, nombrecientifico, nombrecomun, familia, genero, perimetro, diametro, alturafl, alturatotal, coberturaancho, coberturalargo, formadefuste, estadocondicion)" +
                    "Values(@proyecto_id, @sitio, @area, @cuadrante, @numero, @arbolnumeroensitio, true, @nombrecientifico, @nombrecomun, @familia, @genero, @perimetro, @diametro, @alturafl, @alturatotal, @coberturaancho, @coberturalargo, @formadefuste, @estadocondicion)",
                    new String[] { "proyecto_id", "sitio", "area", "cuadrante", "numero", "arbolnumeroensitio", "nombrecientifico", "nombrecomun",
                    "familia", "genero", "perimetro", "diametro", "alturafl", "alturatotal", "coberturaancho", "coberturalargo", "formadefuste", "estadocondicion" },
                    new String[] { "" + proyecto_id, comboBoxSitios.SelectedItem.ToString(), comboBoxAreas.SelectedItem.ToString(), clonedRow.Cells["cuadrante"].Value.ToString(), clonedRow.Cells["numero"].Value.ToString(), clonedRow.Cells["arbolnumeroensitio"].Value.ToString(), clonedRow.Cells["nombrecientifico"].Value.ToString(), clonedRow.Cells["nombrecomun"].Value.ToString(), clonedRow.Cells["familia"].Value.ToString(), clonedRow.Cells["genero"].Value.ToString(), clonedRow.Cells["perimetro"].Value.ToString(), clonedRow.Cells["diametro"].Value.ToString(), clonedRow.Cells["alturafl"].Value.ToString(), clonedRow.Cells["alturatotal"].Value.ToString(), clonedRow.Cells["coberturaancho"].Value.ToString(), clonedRow.Cells["coberturalargo"].Value.ToString(), clonedRow.Cells["formadefuste"].Value.ToString(), clonedRow.Cells["estadocondicion"].Value.ToString() }
                );

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
                    List<String> list_values = SqlConnector.anyEspecificValueGet(
                        "SELECT COUNT(id) FROM individuos WHERE proyecto_id = @proyecto_id AND sitio = @sitio AND area = @area AND numero = @numero",
                        new String[] { "proyecto_id", "sitio", "area", "numero" },
                        new String[] { ""+ proyecto_id, comboBoxSitios.SelectedItem.ToString(), comboBoxAreas.SelectedItem.ToString(), dataGridViewIndividuos.Rows[row.Index].Cells["numero"].Value.ToString() }
                    );

                    int numero_elementos = Convert.ToInt32(list_values[0]);


                    SqlConnector.postPutDeleteGenerico(
                        "DELETE FROM individuos WHERE proyecto_id = @proyecto_id AND sitio = @sitio AND area = @area AND numero  = @numero",
                        new String[] { "proyecto_id", "sitio", "area", "numero" },
                        new String[] { "" + proyecto_id, comboBoxSitios.SelectedItem.ToString(), comboBoxAreas.SelectedItem.ToString(), dataGridViewIndividuos.Rows[row.Index].Cells["numero"].Value.ToString() }
                    );

                    SqlConnector.postPutDeleteGenerico(
                        "UPDATE individuos SET numero = (numero - 1) WHERE proyecto_id = @proyecto_id AND sitio = @sitio AND area = @area AND numero > @numero",
                        new String[] { "proyecto_id", "sitio", "area", "numero" },
                        new String[] { "" + proyecto_id, comboBoxSitios.SelectedItem.ToString(), comboBoxAreas.SelectedItem.ToString(), dataGridViewIndividuos.Rows[row.Index].Cells["numero"].Value.ToString() }
                    );

                    SqlConnector.postPutDeleteGenerico(
                        "UPDATE individuos SET arbolnumeroensitio = (arbolnumeroensitio - " + numero_elementos + ") WHERE proyecto_id = @proyecto_id AND sitio = @sitio AND area = @area AND arbolnumeroensitio > @arbolnumeroensitio",
                        new String[] { "proyecto_id", "sitio", "area", "arbolnumeroensitio" },
                        new String[] { "" + proyecto_id, comboBoxSitios.SelectedItem.ToString(), comboBoxAreas.SelectedItem.ToString(), dataGridViewIndividuos.Rows[row.Index].Cells["arbolnumeroensitio"].Value.ToString() }
                    );

                    SqlConnector.postPutDeleteGenerico(
                        "UPDATE sitios SET numero_consecutivo" + numero + " = (numero_consecutivo" + numero + " - 1) WHERE proyecto_id = @proyecto_id AND numero_sitio = @numero_sitio",
                        new String[] { "proyecto_id", "numero_sitio" },
                        new String[] { "" + proyecto_id, comboBoxSitios.SelectedItem.ToString() }
                    );
                }
                else
                {
                    SqlConnector.postPutDeleteGenerico(
                        "DELETE FROM individuos WHERE proyecto_id = @proyecto_id AND sitio = @sitio AND area = @area AND arbolnumeroensitio = @arbolnumeroensitio",
                        new String[] { "proyecto_id", "sitio", "area", "arbolnumeroensitio" },
                        new String[] { "" + proyecto_id, comboBoxSitios.SelectedItem.ToString(), comboBoxAreas.SelectedItem.ToString(), dataGridViewIndividuos.Rows[row.Index].Cells["arbolnumeroensitio"].Value.ToString() }
                    );

                    SqlConnector.postPutDeleteGenerico(
                        "UPDATE individuos SET arbolnumeroensitio = (arbolnumeroensitio - 1) WHERE proyecto_id = @proyecto_id AND sitio = @sitio AND area = @area AND arbolnumeroensitio > @arbolnumeroensitio",
                        new String[] { "proyecto_id", "sitio", "area", "arbolnumeroensitio" },
                        new String[] { "" + proyecto_id, comboBoxSitios.SelectedItem.ToString(), comboBoxAreas.SelectedItem.ToString(), dataGridViewIndividuos.Rows[row.Index].Cells["arbolnumeroensitio"].Value.ToString() }
                    );
                }

                dataGridViewIndividuos_Populate();
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
            SqlConnector.postPutDeleteGenerico(
                "UPDATE individuos SET " + name + " = @" + name + " WHERE proyecto_id = @proyecto_id AND sitio = @sitio AND area = @area AND numero = @numero",
                new String[] { "proyecto_id", "sitio", "area", "numero", name },
                new String[] { "" + proyecto_id, comboBoxSitios.SelectedItem.ToString(), comboBoxAreas.SelectedItem.ToString(), row.Cells["numero"].Value.ToString(), "" + newdata }
            );
        }

        private void getEspecies()
        {
            especiesObject = new List<Especie>();
            especiesString = new List<string>();

            List<Especie> list_especies = SqlConnector.especiesGet(
                "SELECT * FROM especies",
                new String[] { },
                new String[] { }
            );

            foreach (Especie especie in list_especies)
            {
                string labelNombreCientificoText = especie.getNombreCientifico();
                string labelFamiliaText = especie.getFamilia();
                string labelGeneroText = especie.getGenero();

                //especiesObject.Add(new Especie(labelNombreCientificoText, labelFamiliaText, labelGeneroText));
                especiesString.Add(labelNombreCientificoText);
            }

            source.AddRange(especiesString.ToArray());
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

        private void buttonGrafica_Click(object sender, EventArgs e)
        {
            form1.graficaToFront(proyecto_id);
        }

        private void buttonImportar_Click(object sender, EventArgs e)
        {
            SqlConnector.postPutDeleteGenerico(
                "Delete from individuos where proyecto_id = " + proyecto_id,
                new String[] { },
                new String[] { }
            );

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

                ///////// PARA DESPUEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEES ////////////////////////
                /*
                EcuacionVolumen ecuacion_volumen = SqlConnector.ecuacionVolumenGet(
                    "SELECT * FROM ecuaciones_volumen where especie = @especie AND umafor = @umafor",
                    new String[] { "especie", "umafor" },
                    new String[] { nombrecientifico, umafor_region }
                );

                cmd = SqlConnector.getConnection(cmd);
                cmd.CommandText = "Insert into individuos(proyecto_id, sitio, area, cuadrante, numero, arbolnumeroensitio, familia, nombrecientifico, nombrecomun, perimetro, diametro, alturafl, alturatotal, coberturalargo, coberturaancho, formadefuste, estadocondicion, bifurcados, atcategorias, dncategorias, volumen, areabasal)" +
                    "Values(@proyecto_id, @sitio, @area, @cuadrante, @numero, @arbolnumeroensitio, @familia, @nombrecientifico, @nombrecomun, @perimetro, @diametro, @alturafl, @alturatotal, @coberturalargo, @coberturaancho, @formadefuste, @estadocondicion, @bifurcados, @atcategorias, @dncategorias, @volumen, @areabasal)";
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
                cmd.Parameters.AddWithValue("@volumenv", array[20]);
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
                EcuacionVolumen ecuacion_volumen = SqlConnector.ecuacionVolumenGet(
                    "SELECT * FROM ecuaciones_volumen where especie = @especie AND umafor = @umafor",
                    new String[] { "especie", "umafor" },
                    new String[] { nombrecientifico, umafor_region }
                );

                cmd = SqlConnector.getConnection(cmd);
                cmd.CommandText = "Insert into sitios(proyecto_id, numero_sitio)" +
                    "Values(@proyecto_id, @numero_sitio)";
                cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);
                cmd.Parameters.AddWithValue("@numero_sitio", i);
                */
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
