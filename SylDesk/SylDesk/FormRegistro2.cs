using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using ExcelDataReader;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace SylDesk
{
    public partial class FormRegistro2 : UserControl
    {
        private Form1 form1;
        private Proyecto proyecto;
        public List<Especie> especiesObject;
        public List<string> especiesString;
        AutoCompleteStringCollection source = new AutoCompleteStringCollection();

        public FormRegistro2()
        {
            InitializeComponent();
            
        }

        public void setForm(Form1 form1)
        {
            this.form1 = form1;           
        }

        public void Initialize(Proyecto proyecto)
        {
            Empty();
            this.proyecto = proyecto;

            comboBoxSitios_Populate();
            comboBoxAreas_Populate();
            comboBoxSitios.SelectedIndex = 0;
            comboBoxAreas.SelectedIndex = 0;

            dataGridViewIndividuos_Populate();
            fillForm();
            getEspecies();
        }

        public void Empty()
        {
            comboBoxSitios.Items.Clear();
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
                double[] rangos = getCurrentAltAnc();
                if (rangos[0] > Convert.ToDouble(row.Cells["alturatotal"].Value) || rangos[1] < Convert.ToDouble(row.Cells["alturatotal"].Value))
                {
                    SqlConnector.sendMessage("Error", "La altura total no debe de ser menor que " + rangos[0] + " y no debe ser mayor a " + rangos[1], MessageBoxIcon.Error);
                    row.Cells["alturatotal"].Value = "";
                }
            }

            if (column_name == "coberturaancho")
            {
                double[] rangos = getCurrentAltAnc();
                if (rangos[0] > Convert.ToDouble(row.Cells["coberturaancho"].Value) || rangos[1] < Convert.ToDouble(row.Cells["coberturaancho"].Value))
                {
                    SqlConnector.sendMessage("Error", "La cobertura ancho no debe de ser menor que " + rangos[0] + " y no debe ser mayor a " + rangos[1], MessageBoxIcon.Error);
                    row.Cells["coberturaancho"].Value = "";
                }
                {
                    calculateCobertura(row);
                }
            }            

            if (column_name == "coberturalargo")
            {
                double[] rangos = getCurrentDiaLar();
                if (rangos[0] > Convert.ToDouble(row.Cells["coberturalargo"].Value) || rangos[1] < Convert.ToDouble(row.Cells["coberturalargo"].Value))
                {
                    SqlConnector.sendMessage("Error", "La cobertura largo no debe de ser menor que " + rangos[0] + " y no debe ser mayor a " + rangos[1], MessageBoxIcon.Error);
                    row.Cells["coberturalargo"].Value = "";
                }
                else
                {
                    calculateCobertura(row);
                }
            }

            if (column_name == "diametro")
            {
                double[] rangos = getCurrentDiaLar();
                if (rangos[0] > Convert.ToDouble(row.Cells["diametro"].Value) || rangos[1] < Convert.ToDouble(row.Cells["diametro"].Value))
                {
                    SqlConnector.sendMessage("Error", "El diametro no debe de ser menor que " + rangos[0] + " y no debe ser mayor a " + rangos[1], MessageBoxIcon.Error);
                    row.Cells["diametro"].Value = "";
                    row.Cells["perimetro"].Value = "";
                    row.Cells["areabasal"].Value = "";

                    updateData("diametro", row, "");
                    updateData("perimetro", row, "");
                    updateData("areabasal", row, "");
                }
                else
                {
                    try
                    {
                        row.Cells["perimetro"].Value = (Convert.ToDouble(row.Cells[column_name].Value) * Math.PI).ToString("F4");
                    }
                    catch (Exception ex)                    
                    {
                        SqlConnector.sendMessage("Error", "Hubo un error al momento de calcular el perimetro." , MessageBoxIcon.Error);
                        row.Cells["diametro"].Value = "";
                        row.Cells["perimetro"].Value = "";
                        row.Cells["areabasal"].Value = "";

                        updateData("diametro", row, "");
                        updateData("perimetro", row, "");
                        updateData("areabasal", row, "");
                    }
                    try
                    {
                        row.Cells["areabasal"].Value = (Math.PI * Math.Pow(Convert.ToDouble(row.Cells[column_name].Value) / 2, 2)) / 10000;
                    }
                    catch (Exception ex)
                    {
                        SqlConnector.sendMessage("Error", "Hubo un error al momento de calcular el area basal.", MessageBoxIcon.Error);
                        row.Cells["diametro"].Value = "";
                        row.Cells["perimetro"].Value = "";
                        row.Cells["areabasal"].Value = "";

                        updateData("diametro", row, "");
                        updateData("perimetro", row, "");
                        updateData("areabasal", row, "");
                    }
                    updateData("perimetro", row, Convert.ToString(row.Cells["perimetro"].Value));
                    updateData("areabasal", row, Convert.ToString(row.Cells["areabasal"].Value));
                    
                }
            }
            else if (column_name == "perimetro")
            {
                try
                {
                    row.Cells["diametro"].Value = (Convert.ToDouble(row.Cells["perimetro"].Value) * Math.PI).ToString("F4");
                }
                catch (Exception ex)
                {
                    SqlConnector.sendMessage("Error", "Hubo un error al momento de calcular el perimetro.", MessageBoxIcon.Error);
                    row.Cells["diametro"].Value = "";
                    row.Cells["perimetro"].Value = "";
                    row.Cells["areabasal"].Value = "";

                    updateData("diametro", row, "");
                    updateData("perimetro", row, "");
                    updateData("areabasal", row, "");
                }

                double[] rangos = getCurrentDiaLar();
                if (rangos[0] > Convert.ToDouble(row.Cells["diametro"].Value) || rangos[1] < Convert.ToDouble(row.Cells["diametro"].Value))
                {
                    SqlConnector.sendMessage("Error", "El diametro no debe de ser menor que " + rangos[0] + " y no debe ser mayor a " + rangos[1], MessageBoxIcon.Error);
                    row.Cells["diametro"].Value = "";
                    row.Cells["perimetro"].Value = "";
                    row.Cells["areabasal"].Value = "";

                    updateData("diametro", row, "");
                    updateData("perimetro", row, "");
                    updateData("areabasal", row, "");
                }
                else
                {                    
                    try
                    {
                        row.Cells["areabasal"].Value = (Math.PI * Math.Pow(Convert.ToDouble(row.Cells[column_name].Value) / 2, 2)) / 10000;
                    }
                    catch (Exception ex)
                    {
                        SqlConnector.sendMessage("Error", "Hubo un error al momento de calcular el area basal.", MessageBoxIcon.Error);
                        row.Cells["diametro"].Value = "";
                        row.Cells["perimetro"].Value = "";
                        row.Cells["areabasal"].Value = "";

                        updateData("diametro", row, "");
                        updateData("perimetro", row, "");
                        updateData("areabasal", row, "");
                    }
                    updateData("diametro", row, Convert.ToString(row.Cells["diametro"].Value));
                    updateData("areabasal", row, Convert.ToString(row.Cells["areabasal"].Value));
                }
            }
            else if (column_name == "nombrecientifico")
            {
                String nombrecientifico = tryGetStringCellValue(row, "nombrecientifico");
                row.Cells["nombrecientifico"].Value = char.ToUpper(nombrecientifico[0]) + nombrecientifico.Substring(1);

                if (nombrecientifico != "")
                {
                    Especie especie = SqlConnector.especieGet(
                        "SELECT * FROM especies where nombrecientifico = @nombrecientifico",
                        new String[] { "nombrecientifico" },
                        new String[] { nombrecientifico }
                    );

                    if (especie != null)
                    {
                        string textBoxNombreCientifico = nombrecientifico;
                        string textBoxNombreComun = especie.getNombreComun();
                        string textBoxFamilia = especie.getFamilia();
                        string textBoxGenero = especie.getGenero();


                        row.Cells["nombrecomun"].Value = textBoxNombreComun;
                        row.Cells["familia"].Value = textBoxFamilia;
                        row.Cells["genero"].Value = textBoxGenero;

                        updateData("nombrecomun", row, textBoxNombreComun);
                        updateData("familia", row, textBoxFamilia);
                        updateData("genero", row, textBoxGenero);
                    }
                    else
                    {
                        DialogResult dialog_result = MessageBox.Show("No existe esa especie, desea crearla?",
                            "",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question,
                            MessageBoxDefaultButton.Button2);
                        
                        if (dialog_result == DialogResult.Yes)
                        {
                            form1.formRegistroEspecieToFront(proyecto, 1, "" + row.Cells[column_name].Value);                            
                        }

                        row.Cells[column_name].Value = "";
                        row.Cells["nombrecomun"].Value = "";
                        row.Cells["familia"].Value = "";
                        row.Cells["genero"].Value = "";
                        row.Cells["volumen"].Value = "0";

                        updateData(column_name, row, "");
                        updateData("nombrecomun", row, "");
                        updateData("familia", row, "");
                        updateData("genero", row, "");
                        updateData("volumen", row, "");

                        return;
                    }
                }
                else
                {
                    row.Cells[column_name].Value = "";

                    row.Cells["nombrecomun"].Value = "";
                    row.Cells["familia"].Value = "";
                    row.Cells["genero"].Value = "";
                    row.Cells["volumen"].Value = "0";

                    updateData(column_name, row, "");
                    updateData("nombrecomun", row, "");
                    updateData("familia", row, "");
                    updateData("genero", row, "");
                    updateData("volumen", row, "0");
                }
            }

            String new_value = tryGetStringCellValue(row, column_name);
            updateData(column_name, row, new_value);
            volumen_ecuacion(row);
        }

        private void volumen_ecuacion(DataGridViewRow row)
        {
            try
            {
                String nombrecientifico = row.Cells["nombrecientifico"].Value.ToString();

                if (getCurrentVolCob() && nombrecientifico != "")
                {
                    double diametro = tryGetDoubleCellValue(row, "diametro");
                    double alturatotal = tryGetDoubleCellValue(row, "alturatotal");
                    double perimetro = tryGetDoubleCellValue(row, "perimetro"); ;
                    double areabasal = tryGetDoubleCellValue(row, "areabasal"); ;
                    double alturafl = tryGetDoubleCellValue(row, "alturafl"); ;
                    double coberturalargo = tryGetDoubleCellValue(row, "coberturalargo");
                    double coberturaancho = tryGetDoubleCellValue(row, "coberturaancho");

                    bool found_flag = false;

                    List<ProyectoEcuacion> list_proyecto_ecuacion = SqlConnector.proyectoEcuacionesGet(
                        "SELECT * FROM `proyecto_ecuaciones` Where proyecto_id = @proyecto_id",
                        new String[] { "proyecto_id" },
                        new String[] { "" + Convert.ToInt32(proyecto.getId()) }
                    );

                    if (list_proyecto_ecuacion.Count > 0)
                    {
                        foreach (ProyectoEcuacion proyecto_ecuacion in list_proyecto_ecuacion)
                        {
                            EcuacionVolumen ecuacion_volumen = SqlConnector.ecuacionVolumenGet(
                                "SELECT * FROM ecuaciones_volumen where especie = @especie AND umafor = @umafor",
                                new String[] { "especie", "umafor" },
                                new String[] { nombrecientifico, proyecto_ecuacion.getUmaforRegion() }
                            );

                            if (ecuacion_volumen != null)
                            {
                                string ecuacion, pattern, replace, result;

                                ecuacion = ecuacion_volumen.getEcuacion();

                                MathParser parser = new MathParser();

                                pattern = @"\bDIAMETRO\b";
                                replace = "" + diametro;
                                if (Regex.IsMatch(ecuacion, pattern) && diametro == 0)
                                {
                                    SqlConnector.sendMessage("Valores Faltantes", "Valor de diametro faltante para la ecuacion: " + ecuacion, MessageBoxIcon.Warning);
                                    break;
                                }
                                result = Regex.Replace(ecuacion, pattern, replace);

                                pattern = @"\bALTURATOTAL\b";
                                replace = "" + alturatotal;
                                if (Regex.IsMatch(ecuacion, pattern) && alturatotal == 0)
                                {
                                    SqlConnector.sendMessage("Valores Faltantes", "Valor de altura total faltante para la ecuacion: " + ecuacion, MessageBoxIcon.Warning);
                                    break;
                                }
                                result = Regex.Replace(result, pattern, replace);

                                pattern = @"\bPERIMETRO\b";
                                replace = "" + perimetro;
                                if (Regex.IsMatch(ecuacion, pattern) && perimetro == 0)
                                {
                                    SqlConnector.sendMessage("Valores Faltantes", "Valor de perimetro faltante para la ecuacion: " + ecuacion, MessageBoxIcon.Warning);
                                    break;
                                }
                                result = Regex.Replace(result, pattern, replace);

                                pattern = @"\bAREABASAL\b";
                                replace = "" + areabasal;
                                if (Regex.IsMatch(ecuacion, pattern) && areabasal == 0)
                                {
                                    SqlConnector.sendMessage("Valores Faltantes", "Valor area basal faltante para la ecuacion: " + ecuacion, MessageBoxIcon.Warning);
                                    break;
                                }
                                result = Regex.Replace(result, pattern, replace);

                                pattern = @"\bALTURAFL\b";
                                replace = "" + alturafl;
                                if (Regex.IsMatch(ecuacion, pattern) && alturafl == 0)
                                {
                                    SqlConnector.sendMessage("Valores Faltantes", "Valor altura fuste limpio faltante para la ecuacion: " + ecuacion, MessageBoxIcon.Warning);
                                    break;
                                }
                                result = Regex.Replace(result, pattern, replace);

                                pattern = @"\bCOBERTURAANCHO\b";
                                replace = "" + coberturaancho;
                                if (Regex.IsMatch(ecuacion, pattern) && coberturaancho == 0)
                                {
                                    SqlConnector.sendMessage("Valores Faltantes", "Valor cobertura ancho faltante para la ecuacion: " + ecuacion, MessageBoxIcon.Warning);
                                    break;
                                }
                                result = Regex.Replace(result, pattern, replace);

                                pattern = @"\bCOBERTURALARGO\b";
                                replace = "" + coberturalargo;
                                if (Regex.IsMatch(ecuacion, pattern) && coberturalargo == 0)
                                {
                                    SqlConnector.sendMessage("Valores Faltantes", "Valor cobertura largo faltante para la ecuacion: " + ecuacion, MessageBoxIcon.Warning);
                                    break;
                                }
                                result = Regex.Replace(result, pattern, replace);

                                double volumen = parser.Parse(result, false);

                                SqlConnector.sendMessage("La Ecuacion", "" + result + "  =  " + volumen, MessageBoxIcon.Information);

                                if (volumen < 0 || volumen > 50)
                                {
                                    SqlConnector.sendMessage("Error", "El volumen debe estar en el rango de 0 a 50" , MessageBoxIcon.Information);

                                    row.Cells["volumen"].Value = 0;
                                    updateData("volumen", row, "" + 0);                                    
                                }
                                else
                                {
                                    row.Cells["volumen"].Value = volumen;
                                    updateData("volumen", row, "" + volumen);
                                    found_flag = true;
                                    break;
                                }
                            }
                        }

                        if (!found_flag)
                        {
                            DialogResult dr = SqlConnector.sendOptionsMessage("Decision", "Algunas especies capturadas no presentan ecuación para los inventarios seleccionados o no existe ecuación registrada. Para su registro se desplegará el editor de ecuaciones.\n\n Usar ventana emergente?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                            if (dr == DialogResult.Yes)
                            {
                                FormEmergente form_emergente = new FormEmergente();
                                form_emergente.Show();
                            }
                            else if (dr == DialogResult.No)
                            {
                                form1.calculadoraEcuToFront(proyecto, 1, nombrecientifico);
                            }
                        }
                    }
                    else
                    {
                        SqlConnector.sendMessage("Importante", "No hay Umafor/Region ligadas al proyecto.", MessageBoxIcon.Exclamation);
                        DialogResult dr = SqlConnector.sendOptionsMessage("Decision", "Para su registro desea desplegar el editor del Proyecto?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            form1.formEditarToFront(proyecto);
                        }
                        else
                        {
                            dr = SqlConnector.sendOptionsMessage("Decision", "O prefiere el editor de Ecuaciones?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dr == DialogResult.Yes)
                            {
                                form1.calculadoraEcuToFront(proyecto, 1, nombrecientifico);
                            }
                            else
                            {
                                SqlConnector.sendMessage("Importante", "El proyecto sigue sin tener Umafor/Region ligados.", MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
                else
                {
                    row.Cells["volumen"].Value = "0";
                    updateData("volumen", row, "0");
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
                new String[] { "" + Convert.ToInt32(proyecto.getId()), "" + comboBoxSitios.Items.Count }
            );
            SqlConnector.sendMessage("Aviso", "Sitio agregado.", MessageBoxIcon.Question);
        }

        private void buttonBorrarSitio_Click(object sender, EventArgs e)
        {
            
            if (comboBoxSitios.Items.Count > 1)
            {
                DialogResult dr = SqlConnector.sendOptionsMessage("Alerta", "¿Seguro que desea eliminar el sitio?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    SqlConnector.postPutDeleteGenerico(
                        "DELETE FROM individuos WHERE proyecto_id = @proyecto_id AND sitio = @sitio",
                        new String[] { "proyecto_id", "sitio" },
                        new String[] { "" + Convert.ToInt32(proyecto.getId()), "" + comboBoxSitios.Items.Count }
                    );

                    SqlConnector.postPutDeleteGenerico(
                        "DELETE FROM sitios WHERE proyecto_id = @proyecto_id AND numero_sitio = @numero_sitio",
                        new String[] { "proyecto_id", "numero_sitio" },
                        new String[] { "" + Convert.ToInt32(proyecto.getId()), "" + comboBoxSitios.Items.Count }
                    );

                    if (comboBoxSitios.Items.Count == comboBoxSitios.SelectedIndex + 1)
                    {
                        comboBoxSitios.SelectedIndex -= 1;
                    }
                    comboBoxSitios.Items.Remove(comboBoxSitios.Items.Count);
                }
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

            if (getCurrentVolCob())
            {
                dataGridViewIndividuos.Columns["alturafl"].Visible = true;
                dataGridViewIndividuos.Columns["volumen"].Visible = true;
                dataGridViewIndividuos.Columns["areabasal"].Visible = true;
            }
            else
            {
                dataGridViewIndividuos.Columns["alturafl"].Visible = false;
                dataGridViewIndividuos.Columns["volumen"].Visible = false;
                dataGridViewIndividuos.Columns["areabasal"].Visible = false;
            }
        }

        private void textBoxX_TextChanged(object sender, EventArgs e)
        {
            SqlConnector.postPutDeleteGenerico(
                "UPDATE sitios SET coordenada_x = @coordenada_x WHERE proyecto_id = @proyecto_id AND numero_sitio = @numero_sitio",
                new String[] { "coordenada_x", "proyecto_id", "numero_sitio" },
                new String[] { textBoxX.Text, "" + Convert.ToInt32(proyecto.getId()), "" + comboBoxSitios.SelectedItem }
            );
        }

        private void textBoxY_TextChanged(object sender, EventArgs e)
        {
            SqlConnector.postPutDeleteGenerico(
                "UPDATE sitios SET coordenada_y = @coordenada_y WHERE proyecto_id = @proyecto_id AND numero_sitio = @numero_sitio",
                new String[] { "coordenada_y", "proyecto_id", "numero_sitio" },
                new String[] { textBoxX.Text, "" + Convert.ToInt32(proyecto.getId()), "" + comboBoxSitios.SelectedItem }
            );
        }

        private void textBoxMunicipio_TextChanged(object sender, EventArgs e)
        {
            SqlConnector.postPutDeleteGenerico(
                "UPDATE sitios SET municipio = @municipio WHERE proyecto_id = @proyecto_id AND numero_sitio = @numero_sitio",
                new String[] { "municipio", "proyecto_id", "numero_sitio" },
                new String[] { textBoxMunicipio.Text, "" + Convert.ToInt32(proyecto.getId()), "" + comboBoxSitios.SelectedItem }
            );
        }

        private void textBoxEstadoSucesional_TextChanged(object sender, EventArgs e)
        {
            SqlConnector.postPutDeleteGenerico(
                "UPDATE sitios SET estado_sucesional = @estado_sucesional WHERE proyecto_id = @proyecto_id AND numero_sitio = @numero_sitio",
                new String[] { "estado_sucesional", "proyecto_id", "numero_sitio" },
                new String[] { textBoxEstadoSucesional.Text, "" + Convert.ToInt32(proyecto.getId()), "" + comboBoxSitios.SelectedItem }
            );
        }


        private void fillForm()
        {
            Sitio sitio = SqlConnector.sitioGet(
                "SELECT * FROM `sitios` where proyecto_id = @proyecto_id AND numero_sitio = @numero_sitio",
                new String[] { "proyecto_id", "numero_sitio" },
                new String[] { "" + Convert.ToInt32(proyecto.getId()), "" + comboBoxSitios.SelectedItem }
            );

            string textBoxMunicipioText = sitio.getMunicipio();
            string textBoxXText = sitio.getCoordenadaX();
            string textBoxYText = sitio.getCoordenadaY();
            string textBoxEstadoSucesionalText = sitio.getEstadoSucesional();

            textBoxMunicipio.Text = textBoxMunicipioText;
            textBoxX.Text = textBoxXText;
            textBoxY.Text = textBoxYText;
            textBoxEstadoSucesional.Text = textBoxEstadoSucesionalText;


            TBNombre.Text = proyecto.getNombre();
            string labelSuperficieText = proyecto.getSuperficie();
            string labelDescripcionText = proyecto.getDescripcion();
        }

        private void comboBoxAreas_Populate()
        {
            comboBoxAreas.Items.Clear();
            if (proyecto.getArea1Activo())
            {
                comboBoxAreas.Items.Add(proyecto.getArea1Superficie());
            }
            if (proyecto.getArea2Activo())
            {
                comboBoxAreas.Items.Add(proyecto.getArea2Superficie());
            } 
            if (proyecto.getArea3Activo())
            {
                comboBoxAreas.Items.Add(proyecto.getArea3Superficie());
            }                            
            if (proyecto.getArea4Activo())
            {
                comboBoxAreas.Items.Add(proyecto.getArea4Superficie());
            }
        }


        private void comboBoxSitios_Populate()
        {
            comboBoxSitios.Items.Clear();
            List<Sitio> list_sitios = SqlConnector.sitiosGet(
                "SELECT * FROM `sitios` where proyecto_id = @proyecto_id",
                new String[] { "proyecto_id" },
                new String[] { "" + proyecto.getId()
            }
            );

            foreach (Sitio sitio in list_sitios)
            {
                comboBoxSitios.Items.Add(1);
            }
        }

        private void dataGridViewIndividuos_Populate()
        {
            dataGridViewIndividuos.Rows.Clear();

            List<Individuo> list_individuos = SqlConnector.individuosGet(
                "SELECT * from `individuos` where proyecto_id = @proyecto_id AND sitio = @sitio AND area = @area ORDER BY arbolnumeroensitio DESC",
                new String[] { "proyecto_id", "sitio", "area" },
                new String[] { "" + Convert.ToInt32(proyecto.getId()), comboBoxSitios.SelectedItem.ToString(), comboBoxAreas.SelectedItem.ToString() }
            );
            
            foreach(Individuo individuo in list_individuos)
            {
                List<Object> lista_individuos = new List<Object>();

                lista_individuos.Add(individuo.getCuadrante());
                lista_individuos.Add(individuo.getNumero());
                lista_individuos.Add(individuo.getNumeroArbolEnSitio());
                lista_individuos.Add(individuo.getBifurcado());
                lista_individuos.Add(individuo.getNombreCientifico());
                lista_individuos.Add(individuo.getNombreComun());
                lista_individuos.Add(individuo.getFamilia());
                lista_individuos.Add(individuo.getGenero());
                lista_individuos.Add(individuo.getPerimetro());
                lista_individuos.Add(individuo.getDiametro());
                lista_individuos.Add(individuo.getAlturaFl());
                lista_individuos.Add(individuo.getAlturaTotal());
                lista_individuos.Add(individuo.getCoberturaLargo());
                lista_individuos.Add(individuo.getCoberturaAncho());
                lista_individuos.Add(individuo.getCobertura());
                lista_individuos.Add(individuo.getFormaFuste());
                lista_individuos.Add(individuo.getEstadoCondicion());
                lista_individuos.Add(individuo.getVolumen());
                lista_individuos.Add(individuo.getAreaBasal());

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
                new String[] { "" + Convert.ToInt32(proyecto.getId()), comboBoxSitios.SelectedItem.ToString() }
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
                new String[] { ""  + (numero_consecutivo + 1), "" + Convert.ToInt32(proyecto.getId()), comboBoxSitios.SelectedItem.ToString() }
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

            SqlConnector.postPutDeleteGenerico(
                "Insert into individuos(proyecto_id, sitio, area, numero, arbolnumeroensitio, bifurcados)" +
                "Values(@proyecto_id, @sitio, @area, @numero, @arbolnumeroensitio, false)",
                new String[] { "proyecto_id", "sitio", "area", "numero", "arbolnumeroensitio" },
                new String[] { "" + Convert.ToInt32(proyecto.getId()), comboBoxSitios.SelectedItem.ToString(), comboBoxAreas.SelectedItem.ToString(), "" + numero_consecutivo, newRow.Cells["arbolnumeroensitio"].Value.ToString() }
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
                    new String[] { "" + Convert.ToInt32(proyecto.getId()), comboBoxSitios.SelectedItem.ToString(), comboBoxAreas.SelectedItem.ToString(), row.Cells["arbolnumeroensitio"].Value.ToString() }
                );

                SqlConnector.postPutDeleteGenerico(
                    "Insert into individuos(proyecto_id, sitio, area, cuadrante, numero, arbolnumeroensitio, bifurcados, nombrecientifico, nombrecomun, familia, genero, perimetro, diametro, alturafl, alturatotal, coberturaancho, coberturalargo, formadefuste, estadocondicion)" +
                    "Values(@proyecto_id, @sitio, @area, @cuadrante, @numero, @arbolnumeroensitio, true, @nombrecientifico, @nombrecomun, @familia, @genero, @perimetro, @diametro, @alturafl, @alturatotal, @coberturaancho, @coberturalargo, @formadefuste, @estadocondicion)",
                    new String[] { "proyecto_id", "sitio", "area", "cuadrante", "numero", "arbolnumeroensitio", "nombrecientifico", "nombrecomun",
                    "familia", "genero", "perimetro", "diametro", "alturafl", "alturatotal", "coberturaancho", "coberturalargo", "formadefuste", "estadocondicion" },
                    new String[] { "" + Convert.ToInt32(proyecto.getId()), comboBoxSitios.SelectedItem.ToString(), comboBoxAreas.SelectedItem.ToString(), tryGetStringCellValue(clonedRow, "cuadrante"), tryGetStringCellValue(clonedRow, "numero"), tryGetStringCellValue(clonedRow, "arbolnumeroensitio"), tryGetStringCellValue(clonedRow, "nombrecientifico"), tryGetStringCellValue(clonedRow, "nombrecomun"), tryGetStringCellValue(clonedRow, "familia"), tryGetStringCellValue(clonedRow, "genero"), tryGetStringCellValue(clonedRow, "perimetro"), tryGetStringCellValue(clonedRow, "diametro"), tryGetStringCellValue(clonedRow, "alturafl"), tryGetStringCellValue(clonedRow, "alturatotal"), tryGetStringCellValue(clonedRow, "coberturaancho"), tryGetStringCellValue(clonedRow, "coberturalargo"), tryGetStringCellValue(clonedRow, "formadefuste"), tryGetStringCellValue(clonedRow, "estadocondicion") }
                );

                dataGridViewIndividuos_Populate();
            }
        }

        private void buttonEliminarIndividuo_Click(object sender, EventArgs e)
        {
            if (dataGridViewIndividuos.SelectedRows.Count > 0)
            {
                DialogResult dr = SqlConnector.sendOptionsMessage("Alerta", "¿Seguro que desea eliminar ese individuo?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    var row = dataGridViewIndividuos.SelectedRows[0];
                    int numero = comboBoxAreas.SelectedIndex + 1;

                    if (Convert.ToBoolean(row.Cells["bifurcados"].Value))
                    {
                        List<String> list_values = SqlConnector.anyEspecificValueGet(
                            "SELECT COUNT(id) FROM individuos WHERE proyecto_id = @proyecto_id AND sitio = @sitio AND area = @area AND numero = @numero",
                            new String[] { "proyecto_id", "sitio", "area", "numero" },
                            new String[] { "" + Convert.ToInt32(proyecto.getId()), comboBoxSitios.SelectedItem.ToString(), comboBoxAreas.SelectedItem.ToString(), row.Cells["numero"].Value.ToString() }
                        );

                        int numero_elementos = Convert.ToInt32(list_values[0]);

                        SqlConnector.postPutDeleteGenerico(
                            "DELETE FROM individuos WHERE proyecto_id = @proyecto_id AND sitio = @sitio AND area = @area AND numero  = @numero",
                            new String[] { "proyecto_id", "sitio", "area", "numero" },
                            new String[] { "" + Convert.ToInt32(proyecto.getId()), comboBoxSitios.SelectedItem.ToString(), comboBoxAreas.SelectedItem.ToString(), row.Cells["numero"].Value.ToString() }
                        );

                        SqlConnector.postPutDeleteGenerico(
                            "UPDATE individuos SET numero = (numero - 1) WHERE proyecto_id = @proyecto_id AND sitio = @sitio AND area = @area AND numero > @numero",
                            new String[] { "proyecto_id", "sitio", "area", "numero" },
                            new String[] { "" + Convert.ToInt32(proyecto.getId()), comboBoxSitios.SelectedItem.ToString(), comboBoxAreas.SelectedItem.ToString(), row.Cells["numero"].Value.ToString() }
                        );

                        SqlConnector.postPutDeleteGenerico(
                            "UPDATE individuos SET arbolnumeroensitio = (arbolnumeroensitio - " + numero_elementos + ") WHERE proyecto_id = @proyecto_id AND sitio = @sitio AND area = @area AND arbolnumeroensitio > @arbolnumeroensitio",
                            new String[] { "proyecto_id", "sitio", "area", "arbolnumeroensitio" },
                            new String[] { "" + Convert.ToInt32(proyecto.getId()), comboBoxSitios.SelectedItem.ToString(), comboBoxAreas.SelectedItem.ToString(), row.Cells["arbolnumeroensitio"].Value.ToString() }
                        );

                        SqlConnector.postPutDeleteGenerico(
                            "UPDATE sitios SET numero_consecutivo" + numero + " = (numero_consecutivo" + numero + " - 1) WHERE proyecto_id = @proyecto_id AND numero_sitio = @numero_sitio",
                            new String[] { "proyecto_id", "numero_sitio" },
                            new String[] { "" + Convert.ToInt32(proyecto.getId()), comboBoxSitios.SelectedItem.ToString() }
                        );
                    }
                    else
                    {
                        SqlConnector.postPutDeleteGenerico(
                            "DELETE FROM individuos WHERE proyecto_id = @proyecto_id AND sitio = @sitio AND area = @area AND arbolnumeroensitio = @arbolnumeroensitio",
                            new String[] { "proyecto_id", "sitio", "area", "arbolnumeroensitio" },
                            new String[] { "" + Convert.ToInt32(proyecto.getId()), comboBoxSitios.SelectedItem.ToString(), comboBoxAreas.SelectedItem.ToString(), row.Cells["arbolnumeroensitio"].Value.ToString() }
                        );

                        SqlConnector.postPutDeleteGenerico(
                            "UPDATE individuos SET numero = (numero - 1), arbolnumeroensitio = (arbolnumeroensitio - 1) WHERE proyecto_id = @proyecto_id AND sitio = @sitio AND area = @area AND arbolnumeroensitio > @arbolnumeroensitio",
                            new String[] { "proyecto_id", "sitio", "area", "arbolnumeroensitio" },
                            new String[] { "" + Convert.ToInt32(proyecto.getId()), comboBoxSitios.SelectedItem.ToString(), comboBoxAreas.SelectedItem.ToString(), row.Cells["arbolnumeroensitio"].Value.ToString() }
                        );
                    }
                }

                dataGridViewIndividuos_Populate();
            }
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
                new String[] { "" + Convert.ToInt32(proyecto.getId()), comboBoxSitios.SelectedItem.ToString(), comboBoxAreas.SelectedItem.ToString(), row.Cells["numero"].Value.ToString(), "" + newdata }
            );
        }

        private void getEspecies()
        {
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
            form1.graficaToFront(proyecto);
        }

        private void buttonImportar_Click(object sender, EventArgs e)
        {
            SqlConnector.postPutDeleteGenerico(
                "Delete from individuos where proyecto_id = " + Convert.ToInt32(proyecto.getId()),
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

        public double getCurrentArea()
        {
            double current_area = 0;
            if (comboBoxAreas.SelectedItem.ToString() == proyecto.getArea1Superficie())
            {
                current_area = 1;
            }
            else if (comboBoxAreas.SelectedItem.ToString() == proyecto.getArea2Superficie())
            {
                current_area = 2;
            }
            else if (comboBoxAreas.SelectedItem.ToString() == proyecto.getArea3Superficie())
            {
                current_area = 3;
            }
            else if (comboBoxAreas.SelectedItem.ToString() == proyecto.getArea4Superficie())
            {
                current_area = 4;
            }
            else
            {
                SqlConnector.sendMessage("Error", "Este mensaje no deberia aparececr", MessageBoxIcon.Error);
            }
            return current_area;
        }

        public double getCurrentAreaSuperficie()
        {
            double current_area_superficie = 0;
            if (comboBoxAreas.SelectedItem.ToString() == proyecto.getArea1Superficie())
            {
                current_area_superficie = Convert.ToDouble(proyecto.getArea1Superficie());
            }
            else if (comboBoxAreas.SelectedItem.ToString() == proyecto.getArea2Superficie())
            {
                current_area_superficie = Convert.ToDouble(proyecto.getArea2Superficie());
            }
            else if (comboBoxAreas.SelectedItem.ToString() == proyecto.getArea3Superficie())
            {
                current_area_superficie = Convert.ToDouble(proyecto.getArea3Superficie());
            }
            else if (comboBoxAreas.SelectedItem.ToString() == proyecto.getArea4Superficie())
            {
                current_area_superficie = Convert.ToDouble(proyecto.getArea4Superficie());
            }
            else
            {
                SqlConnector.sendMessage("Error", "Este mensaje no deberia aparececr" , MessageBoxIcon.Error);
            }
            return current_area_superficie;
        }

        public bool getCurrentVolCob()
        {
            bool current_vol_cob = false;
            if (comboBoxAreas.SelectedItem.ToString() == proyecto.getArea1Superficie())
            {
                current_vol_cob = Convert.ToBoolean(proyecto.getArea1VolCob());
            }
            else if (comboBoxAreas.SelectedItem.ToString() == proyecto.getArea2Superficie())
            {
                current_vol_cob = Convert.ToBoolean(proyecto.getArea2VolCob());
            }
            else if (comboBoxAreas.SelectedItem.ToString() == proyecto.getArea3Superficie())
            {
                current_vol_cob = Convert.ToBoolean(proyecto.getArea3VolCob());
            }
            else if (comboBoxAreas.SelectedItem.ToString() == proyecto.getArea4Superficie())
            {
                current_vol_cob = Convert.ToBoolean(proyecto.getArea4VolCob());
            }
            else
            {
                SqlConnector.sendMessage("Error", "Este mensaje no deberia aparececr", MessageBoxIcon.Error);
            }
            return current_vol_cob;
        }

        public double[] getCurrentDiaLar()
        {
            string aux = "";
            if (comboBoxAreas.SelectedItem.ToString() == proyecto.getArea1Superficie())
            {
                aux = proyecto.getArea1DiaLar();
            }
            else if (comboBoxAreas.SelectedItem.ToString() == proyecto.getArea2Superficie())
            {
                aux = proyecto.getArea2DiaLar();
            }
            else if (comboBoxAreas.SelectedItem.ToString() == proyecto.getArea3Superficie())
            {
                aux = proyecto.getArea3DiaLar();
            }
            else if (comboBoxAreas.SelectedItem.ToString() == proyecto.getArea4Superficie())
            {
                aux = proyecto.getArea4DiaLar();
            }
            else
            {
                SqlConnector.sendMessage("Error", "Este mensaje no deberia aparececr", MessageBoxIcon.Error);
                return new Double[]{ 0 , 0};
            }
            String[] aux2 = SqlConnector.getWordsDividedByMinus(aux);
            return new Double[] { Convert.ToDouble(aux2[0]), Convert.ToDouble(aux2[1]) };
        }

        public double[] getCurrentAltAnc()
        {
            double[] current_alt_anc = { };
            string aux = "";
            if (comboBoxAreas.SelectedItem.ToString() == proyecto.getArea1Superficie())
            {
                aux = proyecto.getArea1AltAnc();
            }
            else if (comboBoxAreas.SelectedItem.ToString() == proyecto.getArea2Superficie())
            {
                aux = proyecto.getArea2AltAnc();
            }
            else if (comboBoxAreas.SelectedItem.ToString() == proyecto.getArea3Superficie())
            {
                aux = proyecto.getArea3AltAnc();
            }
            else if (comboBoxAreas.SelectedItem.ToString() == proyecto.getArea4Superficie())
            {
                aux = proyecto.getArea4AltAnc();
            }
            else
            {
                SqlConnector.sendMessage("Error", "Este mensaje no deberia aparececr", MessageBoxIcon.Error);
                return new Double[] { 0, 0 };
            }
            String[] aux2 = SqlConnector.getWordsDividedByMinus(aux);
            return new Double[] { Convert.ToDouble(aux2[0]), Convert.ToDouble(aux2[1]) };
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

        public double tryGetDoubleCellValue(DataGridViewRow row, String column_name)
        {
            if (row.Cells[column_name].Value != null && row.Cells[column_name].Value.ToString() != String.Empty)
            {
                try
                {
                    return Convert.ToDouble(row.Cells[column_name].Value.ToString());
                }
                catch (Exception ex)
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }

        public String tryGetStringCellValue(DataGridViewRow row, String column_name)
        {
            if (row.Cells[column_name].Value != null && row.Cells[column_name].Value.ToString() != String.Empty)
            {
                try
                {
                    return row.Cells[column_name].Value.ToString();
                }
                catch (Exception ex)
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }

        public void calculateCobertura(DataGridViewRow row)
        {
            if (row.Cells["coberturaancho"].Value != "" && row.Cells["coberturalargo"].Value != "")
            {
                row.Cells["cobertura"].Value = Math.PI * Math.Pow(((Convert.ToDouble(row.Cells["coberturaancho"].Value) * Convert.ToDouble(row.Cells["coberturalargo"].Value)) / 4), 2);
                updateData("cobertura", row, Convert.ToString(row.Cells["cobertura"].Value));
            }
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            form1.formRegistro3ToFront();
        }

        private void FormRegistro2_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(TipBox, "Lorem ipsum dolor sit amet consectetur adipiscing\n elit ornare, accumsan nec auctor morbi eget diam cubilia curae,\n justo nisl fringilla natoque sodales dignissim tristique.\n Massa morbi fringilla taciti pulvinar vel nascetur risus luctus eros,\n aliquam orci accumsan quam convallis id sociis lectus egestas, dui mattis aptent leo conubia arcu mi consequat.\n Dictumst senectus litora suscipit proin pretium mattis facilisi, montes posuere ut felis convallis\n dignissim eleifend luctus, praesent urna nullam ridiculus vitae enim.");
        }
    }
}
