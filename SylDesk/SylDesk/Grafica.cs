using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using kawaii_lolis = System.Windows.Forms.DataVisualization.Charting;

namespace SylDesk
{
    public partial class Grafica : UserControl
    {
        private int proyecto_id;
        private Form1 form1;
        private int flag = 0;
        private double superficie = 0;

        public Grafica()
        {
            InitializeComponent();            
        }

        public void setForm(Form1 form1)
        {
            this.form1 = form1;
        }

        public void Initialize(int proyecto_id)
        {
            Empty();
            this.proyecto_id = proyecto_id;
            numericUpDown1.Visible = false;

            Proyecto proyecto = SqlConnector.proyectoGet(
                "SELECT * from proyectos where id = @id",
                new String[] { "id" },
                new String[] { "" + proyecto_id }                
            );
            superficie = Convert.ToDouble(proyecto.getSuperficie());
        }

        public void Empty()
        {
            chart1.Series.Clear();
            chart1.Titles.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
        }


        private void button17_Click(object sender, EventArgs e)
        {
            form1.formRegistro2ToFront(proyecto_id);
        }

        private void get_cat() //individuos por categorias de altura
        {
            Empty();
            chart1.ChartAreas[0].AxisY.Title = "No. Individuos";
            chart1.Legends[0].Enabled = false;
            dataGridView1.Columns.Add("cat", "Categoría de Altura");
            dataGridView1.Columns.Add("no_individuos", "No. Individuos");

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            List<String> null_checker = SqlConnector.anyEspecificValueGet(
                "SELECT * from individuos where proyecto_id = @proyecto_id AND area = 500 AND alturatotal > 0 AND bifurcados = 0",
                new String[] { "proyecto_id" },
                new String[] { "" + proyecto_id }
            );
            
            if (null_checker != null && null_checker.Count > 0)
            {
                List<String> aux = SqlConnector.anyEspecificValueGet(
                    "SELECT Min(alturatotal) as minimo from individuos where proyecto_id = @proyecto_id AND area = 500 AND alturatotal > 0 AND bifurcados = 0",
                    new String[] { "proyecto_id" },
                    new String[] { "" + proyecto_id }
                );

                double min = Convert.ToDouble(aux[0]);

                aux = SqlConnector.anyEspecificValueGet(
                    "SELECT Max(alturatotal) as maximo from individuos where proyecto_id = @proyecto_id AND area = 500 AND alturatotal > 0 AND bifurcados = 0",
                    new String[] { "proyecto_id" },
                    new String[] { "" + proyecto_id }
                );

                double max = Convert.ToDouble(aux[0]);
                int length = Convert.ToInt32(max / 2.5) - 1;

                double current_rango = 5;
                double rango_cat = 2.5;
                double rango_cat2 = rango_cat / 2;

                for (int i = 0; i < length; i++)
                {
                    String sqlQueryString = "";
                    double lower_point = current_rango - rango_cat2;
                    double upper_point = current_rango + rango_cat2;
                    if (i == 0)
                    {
                        SqlConnector.sendMessage("Debug", "1", MessageBoxIcon.Hand);
                        sqlQueryString = "SELECT Count(*) as conteo " +
                            " from individuos where proyecto_id = @proyecto_id AND bifurcados = 0 AND area = 500 AND alturatotal < " + upper_point;
                    }
                    else if (i == (length - 1))
                    {
                        SqlConnector.sendMessage("Debug", "2", MessageBoxIcon.Hand);
                        sqlQueryString = "SELECT Count(*) as conteo " +
                            " from individuos where proyecto_id = @proyecto_id AND bifurcados = 0 AND area = 500 AND alturatotal > " + lower_point;
                    }
                    else
                    {
                        SqlConnector.sendMessage("Debug", "3", MessageBoxIcon.Hand);
                        sqlQueryString = "SELECT Count(*) as conteo " +
                            " from individuos where proyecto_id = @proyecto_id AND bifurcados = 0 AND area = 500 AND alturatotal > " + lower_point + " AND alturatotal < " + upper_point;
                    }

                    aux = SqlConnector.anyEspecificValueGet(
                        sqlQueryString,
                        new String[] { "proyecto_id" },
                        new String[] { "" + proyecto_id }
                    );

                    chart1.Series.Add(new kawaii_lolis.Series("" + current_rango));
                    chart1.Series[i].Points.AddXY("" + current_rango, aux[0]);
                    chart1.Series[i].ToolTip = "CAT: #VALX\nConteo: #VALY ";          //Tooltips para cada barra

                    dataGridView1.Rows.Add(current_rango, aux[0]);

                    current_rango += rango_cat;
                    chart1.ChartAreas[0].AxisX.LabelStyle.Angle = 0;  //inclinacion de letras en graf.
                    chart1.AlignDataPointsByAxisLabel();

                    chart1.Series[i]["LabelStyle"] = "Center";
                    chart1.Series[i]["LabelStyle"] = "Top";
                    chart1.Series[i].IsValueShownAsLabel = true;
                    chart1.Series[i].ChartType = kawaii_lolis.SeriesChartType.Column;
                    chart1.Series[i].LabelBackColor = Color.LightCyan;
                    chart1.Series[i].Font = new Font("Arial", 9);
                    chart1.Series[i].Points[i].Color = Color.ForestGreen;  //color de barras verde
                    chart1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 9);  //Font grafica
                }
            }
            else
            {
                SqlConnector.sendMessage("Datos Faltantes/Inadecuados", "La grafica no puede mostrarse porque no tiene datos adecuados", MessageBoxIcon.Stop);
            }
            chart1.ChartAreas[0].RecalculateAxesScale();
        }

        private void get_cad() //individuos categoria diametricas
        {
            Empty();
            chart1.ChartAreas[0].AxisY.Title = "No. Individuos";
            chart1.Legends[0].Enabled = false;
            dataGridView1.Columns.Add("cad", "Categoría de Diámetro");
            dataGridView1.Columns.Add("no_individuos", "No. Individuos");
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            List<String> null_checker = SqlConnector.anyEspecificValueGet(
                "SELECT * from individuos where proyecto_id = @proyecto_id AND area = 500 AND diametro > 0 AND bifurcados = 0",
                new String[] { "proyecto_id" },
                new String[] { "" + proyecto_id }
            );

            if (null_checker != null && null_checker.Count > 0)
            {
                List<String> aux = SqlConnector.anyEspecificValueGet(
                    "SELECT Min(diametro) as minimo from individuos where proyecto_id = @proyecto_id AND area = 500 AND diametro > 0 AND bifurcados = 0",
                    new String[] { "proyecto_id" },
                    new String[] { "" + proyecto_id }
                );
                double min = Convert.ToDouble(aux[0]);

                aux = SqlConnector.anyEspecificValueGet(
                    "SELECT Max(diametro) as maximo from individuos where proyecto_id = @proyecto_id AND area = 500 AND diametro > 0 AND bifurcados = 0",
                    new String[] { "proyecto_id" },
                    new String[] { "" + proyecto_id }
                );
                double max = Convert.ToDouble(aux[0]);

                int length = Convert.ToInt32(max / 5) - 1;

                double current_rango = 10;
                double rango_cad = 5;
                double rango_cad2 = rango_cad / 2;

                for (int i = 0; i < length; i++)
                {
                    String sqlQueryString = "";

                    double lower_point = current_rango - rango_cad2;
                    double upper_point = current_rango + rango_cad2;
                    if (i == 0)
                    {
                        sqlQueryString = "SELECT Count(*) as conteo " +
                            " from individuos where proyecto_id = @proyecto_id AND bifurcados = 0 AND area = 500 AND diametro < " + upper_point;
                    }
                    else if (i == (length - 1))
                    {
                        sqlQueryString = "SELECT Count(*) as conteo " +
                            " from individuos where proyecto_id = @proyecto_id AND bifurcados = 0 AND area = 500 AND diametro > " + lower_point;
                    }
                    else
                    {
                        sqlQueryString = "SELECT Count(*) as conteo " +
                            " from individuos where proyecto_id = @proyecto_id AND bifurcados = 0 AND area = 500 AND diametro >= " + lower_point + " AND diametro < " + upper_point;
                    }

                    aux = SqlConnector.anyEspecificValueGet(
                        sqlQueryString,
                        new String[] { "proyecto_id" },
                        new String[] { "" + proyecto_id }
                    );

                    chart1.Series.Add(new kawaii_lolis.Series("" + current_rango));
                    chart1.Series[i].Points.AddXY("" + current_rango, aux[0]);
                    chart1.Series[i].ToolTip = "CaD #VALX\nConteo: #VALY ";          //Tooltips para cada barra

                    dataGridView1.Rows.Add(current_rango, aux[0]);

                    current_rango += rango_cad;
                    chart1.AlignDataPointsByAxisLabel();
                    chart1.Series[i]["PixelPointWidth"] = "75";
                    chart1.ChartAreas[0].AxisX.LabelStyle.Angle = 0;  //inclinacion de letras en graf.

                    chart1.Series[i].Points[i].Color = Color.ForestGreen;  //color de barras verde
                    chart1.Series[i]["LabelStyle"] = "Center";
                    chart1.Series[i]["LabelStyle"] = "Top";
                    chart1.Series[i].IsValueShownAsLabel = true;
                    chart1.Series[i].ChartType = kawaii_lolis.SeriesChartType.Column;
                    chart1.Series[i].LabelBackColor = Color.LightCyan;
                    chart1.Series[i].Font = new Font("Arial", 9);
                    chart1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 9); //Font grafica
                }
            }
            else
            {
                SqlConnector.sendMessage("Datos Faltantes/Inadecuados", "La grafica no puede mostrarse porque no tiene datos adecuados", MessageBoxIcon.Stop);
            }
            chart1.ChartAreas[0].RecalculateAxesScale();
        }

        private void get_numero_individuos() // Mayor numero de individuos en el predio
        {
            Empty();
            chart1.ChartAreas[0].AxisY.Title = "Densidad (Ind/ha)";
            chart1.Legends[0].Enabled = false;
            dataGridView1.Columns.Add("especie", "Especie");
            dataGridView1.Columns[0].DefaultCellStyle.Font = new Font("arial", 11);  //font Cursiva columna Nom. Cient. 
            dataGridView1.Columns.Add("no_individuos", "No. Individuos");
            dataGridView1.Columns.Add("individuos_ha", "Individuos (Hectarea)");
            dataGridView1.Columns.Add("individuos_scustf", "Individuos (SCUSTF)");

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            List<String> null_checker = SqlConnector.anyEspecificValueGet(
                "SELECT * from individuos where proyecto_id = @proyecto_id AND area = 500 AND bifurcados = 0 Group By nombrecientifico",
                new String[] { "proyecto_id" },
                new String[] { "" + proyecto_id }
            );


            if (null_checker != null && null_checker.Count > 0)
            {
                List<List<String>> aux = SqlConnector.anyEspecificValuesGet(
                    "SELECT nombrecientifico, Count(nombrecientifico) as conteo from individuos where proyecto_id = @proyecto_id AND area = 500 AND bifurcados = 0 Group By nombrecientifico ORDER BY conteo DESC",
                    new String[] { "proyecto_id" },
                    new String[] { "" + proyecto_id }
                );

                for (int i = 0; i < numericUpDown1.Value && i < aux.Count; i++)
                {
                    double ha = Convert.ToDouble(aux[i][1]) / 0.6;
                    double ha2 = Convert.ToDouble(aux[i][1]) / (0.6 / superficie);
                    chart1.Series.Add(new kawaii_lolis.Series("" + aux[i][0]));
                    chart1.Series[i].Points.AddXY("" + aux[i][0], ha);
                    dataGridView1.Rows.Add(aux[i][0], aux[i][1], ha.ToString("F4"), ha2.ToString("F4"));

                    chart1.AlignDataPointsByAxisLabel();
                    chart1.Series[i]["PixelPointWidth"] = "75";
                    chart1.Series[i]["PointWidth"] = "0.3";  //grosor de las barras

                    chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -45;          //inclinacion de letras en graf.
                    chart1.Series[i].ToolTip = "#VALX\nConteo: #VALY ";          //Tooltips para cada barra
                    chart1.Series[i].Points[i].Color = Color.ForestGreen;       //color de barras verde
                    chart1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("arial", 11, FontStyle.Italic);
                }
            }
            else
            {
                SqlConnector.sendMessage("Datos Faltantes/Inadecuados", "La grafica no puede mostrarse porque no tiene datos adecuados", MessageBoxIcon.Stop);
            }
            chart1.ChartAreas[0].RecalculateAxesScale();
        }

        private void get_area_basal() // area basal por especie (m^2 / ha)
        {
            Empty();
            chart1.ChartAreas[0].AxisY.Title = "m^2/ha";
            chart1.Legends[0].Enabled = false;
            dataGridView1.Columns.Add("especie", "Especie");
            dataGridView1.Columns[0].DefaultCellStyle.Font = new Font("arial", 11);  //font Cursiva columna Nom. Cient.
            dataGridView1.Columns.Add("suma_ab", "AB m^2 (Muestreo)");
            dataGridView1.Columns.Add("ab_ha", "AB m^2 (Hectárea)");
            dataGridView1.Columns.Add("ab_ha2", "AB m^2  (SCUSTF)");

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            List<String> null_checker = SqlConnector.anyEspecificValueGet(
                "SELECT * from individuos where proyecto_id = @proyecto_id AND area = 500 AND areabasal > 0 AND bifurcados = 0",
                new String[] { "proyecto_id" },
                new String[] { "" + proyecto_id }
            );

            if (null_checker != null && null_checker.Count > 0)
            {
                List<List<String>> aux = SqlConnector.anyEspecificValuesGet(
                    "SELECT nombrecientifico, Sum(areabasal) as areabasal2 from individuos where proyecto_id = @proyecto_id AND area = 500 AND areabasal > 0 Group By nombrecientifico ORDER BY areabasal2 DESC",
                    new String[] { "proyecto_id" },
                    new String[] { "" + proyecto_id }
                );

                for (int i = 0; i < numericUpDown1.Value && i < aux.Count; i++)
                {
                    double ha = Convert.ToDouble(aux[i][1]) / 0.6;
                    double ha2 = Convert.ToDouble(aux[i][1]) / (0.6 / superficie);
                    dataGridView1.Rows.Add(aux[i][0], aux[i][1], ha.ToString("F4"), ha2.ToString("F4"));

                    chart1.Series.Add(new kawaii_lolis.Series("" + aux[i][0]));
                    chart1.Series[i].Points.AddXY("" + aux[i][0], ha);
                    chart1.AlignDataPointsByAxisLabel();
                    chart1.Series[i]["PixelPointWidth"] = "75";
                    chart1.Series[i]["PointWidth"] = "0.3";                         //grosor de las barras
                    chart1.Series[i].ToolTip = "#VALX\nArea Basal: #VALY ";          //Tooltips para cada barra
                    chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -45;              //inclinacion de letras en graf.
                    chart1.Series[i].Points[i].Color = Color.ForestGreen;             //color de barras verde
                    chart1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("arial", 11, FontStyle.Italic);
                }
            }
            else
            {
                SqlConnector.sendMessage("Datos Faltantes/Inadecuados", "La grafica no puede mostrarse porque no tiene datos adecuados", MessageBoxIcon.Stop);
            }
            chart1.ChartAreas[0].RecalculateAxesScale();            
        }

        private void get_volumen()
        {
            Empty();

            chart1.ChartAreas[0].AxisY.Title = "m^3/ha";
            chart1.Legends[0].Enabled = false;
            dataGridView1.Columns.Add("especie", "Especie");
            dataGridView1.Columns[0].DefaultCellStyle.Font = new Font("arial", 11);  //font Cursiva columna Nom. Cient.
            dataGridView1.Columns.Add("suma_volumen", "Vol m^3 (Muestreo)");
            dataGridView1.Columns.Add("volumen_ha", "Vol m^3 (Hectárea)");
            dataGridView1.Columns.Add("volumen_ha2", "Vol m^3 (SCUSTF)");

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            List<String> null_checker = SqlConnector.anyEspecificValueGet(
                "SELECT * from individuos where proyecto_id = @proyecto_id AND area = 500 AND volumen > 0 AND bifurcados = 0",
                new String[] { "proyecto_id" },
                new String[] { "" + proyecto_id }
            );

            if (null_checker != null && null_checker.Count > 0)
            {
                List<List<String>> aux = SqlConnector.anyEspecificValuesGet(
                    "SELECT nombrecientifico, Sum(volumen) as volumen2 from individuos where proyecto_id = @proyecto_id AND area = 500 AND volumen > 0 Group By nombrecientifico ORDER BY volumen DESC",
                    new String[] { "proyecto_id" },
                    new String[] { "" + proyecto_id }
                );

                for (int i = 0; i < numericUpDown1.Value && i < aux.Count; i++)
                {
                    List<Object> lista_individuos = new List<Object>();
                    lista_individuos.Add(aux[i][0]);
                    lista_individuos.Add(aux[i][1]);

                    double ha = Convert.ToDouble(aux[i][1]) / 0.6;
                    double ha2 = Convert.ToDouble(aux[i][1]) / (0.6 / superficie);
                    dataGridView1.Rows.Add(aux[i][0], aux[i][1], ha.ToString("F4"), ha2.ToString("F4"));
                    chart1.Series.Add(new kawaii_lolis.Series("" + aux[i][0]));

                    chart1.Series[i].Points.AddXY("" + aux[i][0], ha);
                    chart1.AlignDataPointsByAxisLabel();
                    chart1.Series[i]["PixelPointWidth"] = "75";
                    chart1.Series[i]["PointWidth"] = "0.3";  //grosor de las barras
                    chart1.Series[i].ToolTip = "#VALX\nVolumen: #VALY ";          //Tooltips para cada barra
                    chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -45;      //inclinacion de letras en graf.
                    chart1.Series[i].Points[i].Color = Color.ForestGreen;  //color de barras verde
                    chart1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("arial", 11, FontStyle.Italic);
                }
            }
            else
            {
                SqlConnector.sendMessage("Datos Faltantes/Inadecuados", "La grafica no puede mostrarse porque no tiene datos adecuados", MessageBoxIcon.Stop);
            }
            chart1.ChartAreas[0].RecalculateAxesScale();
            
        }

        private void get_IVI(int area)
        {
            Empty();

            chart1.ChartAreas[0].AxisY.Title = "I.V.I";
            dataGridView1.Columns.Add("especie", "Especie");
            dataGridView1.Columns[0].DefaultCellStyle.Font = new Font("arial", 11);  //font Cursiva columna Nom. Cient.
            dataGridView1.Columns.Add("frecuencia_absoluta", "Frecuencia absoluta");
            dataGridView1.Columns.Add("frecuencia_relativa", "Frecuencia relativa");
            dataGridView1.Columns.Add("densidad_absoluta", "Densidad absoluta");
            dataGridView1.Columns.Add("densidad_relativa", "Densidad relativa");
            dataGridView1.Columns.Add("dominancia_absoluta", "Dominancia absoluta");
            dataGridView1.Columns.Add("dominancia_relativa", "Dominancia relativa");
            dataGridView1.Columns.Add("ivi", "IVI");

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            chart1.Legends[0].Enabled = true;
            chart1.Series.Add(new kawaii_lolis.Series("frecuencia"));
            chart1.Series.Add(new kawaii_lolis.Series("densidad"));
            chart1.Series.Add(new kawaii_lolis.Series("dominancia"));
            chart1.Series[0].LegendText = "Frecuencia";
            chart1.Series[1].LegendText = "Densidad";
            chart1.Series[2].LegendText = "Dominancia";



            int num_sitios = 0;
            List<double> frec_abs = new List<double>();
            List<double> frec_rel = new List<double>();
            List<double> den_abs = new List<double>();
            List<double> den_rel = new List<double>();
            List<double> dom_abs = new List<double>();
            List<double> dom_rel = new List<double>();

            List<String> aux = SqlConnector.anyEspecificValueGet(
                "SELECT Count(*) from sitios where proyecto_id = @proyecto_id",
                new String[] { "proyecto_id" },
                new String[] { "" + proyecto_id }
            );
            num_sitios = Convert.ToInt32(aux[0]);

            List<Object> lista_individuos = new List<Object>();
            List<IVI> list_ivis = new List<IVI>();

            List<List<String>> aux2 = SqlConnector.anyEspecificValuesGet(
                "SELECT nombrecientifico from individuos where proyecto_id = @proyecto_id AND area =  " + area + " AND nombrecientifico != \"\" Group By nombrecientifico ORDER BY nombrecientifico ASC",
                new String[] { "proyecto_id" },
                new String[] { "" + proyecto_id }
            );

            foreach (List<String> results in aux2)
            {
                lista_individuos.Add(results[0]);
            }

            for (int i = 0; i < lista_individuos.Count; i++)
            {
                frec_abs.Add(0);
                frec_rel.Add(0);
                den_abs.Add(0);
                den_rel.Add(0);
                dom_abs.Add(0);
                dom_rel.Add(0);
            }

            double frec_total = 0, den_total = 0, dom_total = 0;
            for (int i = 0; i < lista_individuos.Count; i++)
            {
                double frec_aux = 0;
                double dens_aux = 0;
                double dom_aux = 0;
                for (int j = 1; j <= num_sitios; j++)
                {
                    aux = SqlConnector.anyEspecificValueGet(
                        //"SELECT Count(nombrecientifico), areabasal from individuos where proyecto_id = @proyecto_id AND area =  " + area + " AND sitio = " + j + " AND nombrecientifico = \"" + lista_individuos[i] + "\" AND areabasal > 0",
                        "SELECT Count(nombrecientifico), Sum(areabasal) from individuos where proyecto_id = @proyecto_id AND area =  " + area + " AND sitio = " + j + " AND nombrecientifico = \"" + lista_individuos[i] + "\" AND areabasal > 0",
                        new String[] { "proyecto_id" },
                        new String[] { "" + proyecto_id }
                    );

                    int aux3 = Convert.ToInt32(aux[0]);
                    if (aux3 > 0)
                    {
                        frec_aux += 1;
                        dens_aux += aux3;
                        dom_aux += Convert.ToDouble(aux[1]);
                    }
                }

                int area_muestreada = area * num_sitios;
                frec_abs[i] = (frec_aux / num_sitios) * 100;
                den_abs[i] = (dens_aux / area_muestreada) * 100;
                dom_abs[i] = (dom_aux / area_muestreada) * 100;
                frec_total += frec_abs[i];
                den_total += den_abs[i];
                dom_total += dom_abs[i];
            }

            for (int i = 0; i < lista_individuos.Count; i++)
            {
                frec_rel[i] = (frec_abs[i] / frec_total) * 100;
                den_rel[i] = (den_abs[i] / den_total) * 100;
                dom_rel[i] = (dom_abs[i] / dom_total) * 100;
                list_ivis.Add(new IVI(lista_individuos[i].ToString(), frec_abs[i], frec_rel[i], den_abs[i], den_rel[i], dom_abs[i], dom_rel[i]));

                dataGridView1.Rows.Add(lista_individuos[i], Convert.ToDouble(frec_abs[i].ToString("F4")), Convert.ToDouble(frec_rel[i].ToString("F4")), Convert.ToDouble(den_abs[i].ToString("F4")), Convert.ToDouble(den_rel[i].ToString("F4")), Convert.ToDouble(dom_abs[i].ToString("F5")), Convert.ToDouble(dom_rel[i].ToString("F4")), Convert.ToDouble(((frec_rel[i] + den_rel[i] + dom_rel[i])).ToString("F4")));
                chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -45;  //inclinacion de letras en graf.
                chart1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("arial", 11, FontStyle.Italic);
            }
            List<IVI> list_ivis2 = list_ivis.OrderByDescending((x) => x.ivi).ToList();
            for(int i = 0; i < numericUpDown1.Value && i < list_ivis2.Count; i++)
            {
                chart1.Series["frecuencia"].Points.AddXY("" + list_ivis2[i].get_nombrecientifico(), Convert.ToDouble((list_ivis2[i].get_frec_rel())).ToString("F4"));
                chart1.Series["densidad"].Points.AddXY("" + list_ivis2[i].get_nombrecientifico(), Convert.ToDouble((list_ivis2[i].get_den_rel())).ToString("F4"));
                chart1.Series["dominancia"].Points.AddXY("" + list_ivis2[i].get_nombrecientifico(), Convert.ToDouble((list_ivis2[i].get_dom_rel())).ToString("F4"));
                chart1.Series["frecuencia"].Points[i].ToolTip = "#VALX\nIVI: " + ((list_ivis2[i].get_frec_rel() + list_ivis2[i].get_den_rel() + list_ivis2[i].get_dom_rel())).ToString("F4");  //Valor position top
                chart1.Series["densidad"].Points[i].ToolTip = "#VALX\nIVI: " + ((list_ivis2[i].get_frec_rel() + list_ivis2[i].get_den_rel() + list_ivis2[i].get_dom_rel())).ToString("F4");  //Valor position top
                chart1.Series["dominancia"].Points[i].ToolTip = "#VALX\nIVI: " + ((list_ivis2[i].get_frec_rel() + list_ivis2[i].get_den_rel() + list_ivis2[i].get_dom_rel())).ToString("F4");  //Valor position top
            }

            chart1.ChartAreas[0].RecalculateAxesScale();
            chart1.Series["frecuencia"].ChartType = kawaii_lolis.SeriesChartType.StackedColumn;
            chart1.Series["densidad"].ChartType = kawaii_lolis.SeriesChartType.StackedColumn;
            chart1.Series["dominancia"].ChartType = kawaii_lolis.SeriesChartType.StackedColumn;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            numericUpDown1.Visible = false;
            get_cat();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            numericUpDown1.Visible = false;
            get_cad();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            numericUpDown1.Visible = true;
            numericUpDown1.Value = 5;
            flag = 0;
            get_numero_individuos();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            numericUpDown1.Visible = true;
            numericUpDown1.Value = 5;
            flag = 1;
            get_area_basal();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            numericUpDown1.Visible = true;
            numericUpDown1.Value = 5;
            flag = 2;
            get_volumen();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            numericUpDown1.Visible = true;
            numericUpDown1.Value = 5;
            flag = 3;
            get_IVI(500);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            numericUpDown1.Visible = true;
            numericUpDown1.Value = 5;
            flag = 4;
            get_IVI(100);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            numericUpDown1.Visible = true;
            numericUpDown1.Value = 5;
            flag = 5;
            get_IVI(5);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (flag == 0)
            {
                get_numero_individuos();
            }
            else if (flag == 1)
            {
                get_area_basal();
            }
            else if (flag == 2)
            {
                get_volumen();
            }
            else if (flag == 3)
            {
                get_IVI(500);
            }
            else if (flag == 4)
            {
                get_IVI(100);
            }
            else if (flag == 5)
            {
                get_IVI(5);
            }
        }

        private void ReportButton_Click(object sender, EventArgs e)
        {
            form1.reportToFront();
        }
    }
}