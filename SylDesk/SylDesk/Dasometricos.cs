using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using kawaii_lolis = System.Windows.Forms.DataVisualization.Charting;

namespace SylDesk
{
    public partial class Dasometricos : UserControl
    {
        private Proyecto proyecto;
        private Form1 form1;
        private int flag = 0;
        private double superficie = 0;

        public Dasometricos()
        {
            InitializeComponent();
        }
        public void setForm(Form1 form1)
        {
            this.form1 = form1;
        }
        public void Initialize(Proyecto proyecto)
        {
            PanelCargando.Hide();


            Empty();
            this.proyecto = proyecto;
            numericUpDown1.Visible = false;


            superficie = Convert.ToDouble(proyecto.getSuperficie());
        }
        public void Empty()
        {
            chart1.Series.Clear();
            chart1.Titles.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
        }

        private void get_cat() //individuos por categorias de altura
        {
            Empty();
            chart1.ChartAreas[0].AxisY.Title = "No. Individuos";
            chart1.Legends[0].Enabled = false;
            dataGridView1.Columns.Add("cat", "Categoría de Altura");
            dataGridView1.Columns.Add("no_individuos", "No. Individuos");

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            string areas_query = getVolumeAreas();

            List<String> null_checker = SqlConnector.anyEspecificValueGet(
                "SELECT * from individuos where proyecto_id = @proyecto_id AND (" + areas_query + ") AND alturatotal > 0 AND bifurcados = 0",
                new String[] { "proyecto_id" },
                new String[] { "" + proyecto.getId() }
            );

            if (null_checker != null && null_checker.Count > 0)
            {
                List<String> aux = SqlConnector.anyEspecificValueGet(
                    "SELECT Min(alturatotal) as minimo from individuos where proyecto_id = @proyecto_id AND (" + areas_query + ") AND alturatotal > 0 AND bifurcados = 0",
                    new String[] { "proyecto_id" },
                    new String[] { "" + proyecto.getId() }
                );

                double min = Convert.ToDouble(aux[0]);

                aux = SqlConnector.anyEspecificValueGet(
                    "SELECT Max(alturatotal) as maximo from individuos where proyecto_id = @proyecto_id AND (" + areas_query + ") AND alturatotal > 0 AND bifurcados = 0",
                    new String[] { "proyecto_id" },
                    new String[] { "" + proyecto.getId() }
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
                        sqlQueryString = "SELECT Count(*) as conteo " +
                            " from individuos where proyecto_id = @proyecto_id AND bifurcados = 0 AND (" + areas_query + ") AND alturatotal < " + upper_point;
                    }
                    else if (i == (length - 1))
                    {
                        sqlQueryString = "SELECT Count(*) as conteo " +
                            " from individuos where proyecto_id = @proyecto_id AND bifurcados = 0 AND (" + areas_query + ") AND alturatotal > " + lower_point;
                    }
                    else
                    {
                        sqlQueryString = "SELECT Count(*) as conteo " +
                            " from individuos where proyecto_id = @proyecto_id AND bifurcados = 0 AND (" + areas_query + ") AND alturatotal > " + lower_point + " AND alturatotal < " + upper_point;
                    }

                    aux = SqlConnector.anyEspecificValueGet(
                        sqlQueryString,
                        new String[] { "proyecto_id" },
                        new String[] { "" + proyecto.getId() }
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

            string areas_query = getVolumeAreas();

            List<String> null_checker = SqlConnector.anyEspecificValueGet(
                "SELECT * from individuos where proyecto_id = @proyecto_id AND (" + areas_query + ") AND diametro > 0 AND bifurcados = 0",
                new String[] { "proyecto_id" },
                new String[] { "" + proyecto.getId() }
            );

            if (null_checker != null && null_checker.Count > 0)
            {
                List<String> aux = SqlConnector.anyEspecificValueGet(
                    "SELECT Min(diametro) as minimo from individuos where proyecto_id = @proyecto_id AND (" + areas_query + ") AND diametro > 0 AND bifurcados = 0",
                    new String[] { "proyecto_id" },
                    new String[] { "" + proyecto.getId() }
                );
                double min = Convert.ToDouble(aux[0]);

                aux = SqlConnector.anyEspecificValueGet(
                    "SELECT Max(diametro) as maximo from individuos where proyecto_id = @proyecto_id AND (" + areas_query + ") AND diametro > 0 AND bifurcados = 0",
                    new String[] { "proyecto_id" },
                    new String[] { "" + proyecto.getId() }
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
                            " from individuos where proyecto_id = @proyecto_id AND bifurcados = 0 AND (" + areas_query + ") AND diametro < " + upper_point;
                    }
                    else if (i == (length - 1))
                    {
                        sqlQueryString = "SELECT Count(*) as conteo " +
                            " from individuos where proyecto_id = @proyecto_id AND bifurcados = 0 AND (" + areas_query + ") AND diametro > " + lower_point;
                    }
                    else
                    {
                        sqlQueryString = "SELECT Count(*) as conteo " +
                            " from individuos where proyecto_id = @proyecto_id AND bifurcados = 0 AND (" + areas_query + ") AND diametro >= " + lower_point + " AND diametro < " + upper_point;
                    }

                    aux = SqlConnector.anyEspecificValueGet(
                        sqlQueryString,
                        new String[] { "proyecto_id" },
                        new String[] { "" + proyecto.getId() }
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

            string areas_query = getVolumeAreas();

            List<String> null_checker = SqlConnector.anyEspecificValueGet(
                "SELECT * from individuos where proyecto_id = @proyecto_id AND (" + areas_query + ") AND bifurcados = 0 Group By nombrecientifico",
                new String[] { "proyecto_id" },
                new String[] { "" + proyecto.getId() }
            );


            if (null_checker != null && null_checker.Count > 0)
            {
                List<List<String>> aux = SqlConnector.anyEspecificValuesGet(
                    "SELECT nombrecientifico, Count(nombrecientifico) as conteo from individuos where proyecto_id = @proyecto_id AND " + areas_query + " AND bifurcados = 0 Group By nombrecientifico ORDER BY conteo DESC",
                    new String[] { "proyecto_id" },
                    new String[] { "" + proyecto.getId() }
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

            string areas_query = getVolumeAreas();

            List<String> null_checker = SqlConnector.anyEspecificValueGet(
                "SELECT * from individuos where proyecto_id = @proyecto_id AND (" + areas_query + ") AND areabasal > 0 AND bifurcados = 0",
                new String[] { "proyecto_id" },
                new String[] { "" + proyecto.getId() }
            );

            if (null_checker != null && null_checker.Count > 0)
            {
                List<List<String>> aux = SqlConnector.anyEspecificValuesGet(
                    "SELECT nombrecientifico, Sum(areabasal) as areabasal2 from individuos where proyecto_id = @proyecto_id AND (" + areas_query + ") AND areabasal > 0 Group By nombrecientifico ORDER BY areabasal2 DESC",
                    new String[] { "proyecto_id" },
                    new String[] { "" + proyecto.getId() }
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

            string areas_query = getVolumeAreas();

            List<String> null_checker = SqlConnector.anyEspecificValueGet(
                "SELECT * from individuos where proyecto_id = @proyecto_id AND (" + areas_query + ") AND volumen > 0 AND bifurcados = 0",
                new String[] { "proyecto_id" },
                new String[] { "" + proyecto.getId() }
            );

            if (null_checker != null && null_checker.Count > 0)
            {
                List<List<String>> aux = SqlConnector.anyEspecificValuesGet(
                    "SELECT nombrecientifico, Sum(volumen) as volumen2 from individuos where proyecto_id = @proyecto_id AND (" + areas_query + ") AND volumen > 0 Group By nombrecientifico ORDER BY volumen DESC",
                    new String[] { "proyecto_id" },
                    new String[] { "" + proyecto.getId() }
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

        private string getVolumeAreas()
        {
            string areas_query = "";
            if (proyecto.getArea1Activo() && Convert.ToBoolean(proyecto.getArea1VolCob()))
            {
                areas_query += " area = " + proyecto.getArea1Superficie();
            }
            if (proyecto.getArea2Activo() && Convert.ToBoolean(proyecto.getArea2VolCob()))
            {
                if (areas_query != "")
                {
                    areas_query += " OR ";
                }
                areas_query += " area = " + proyecto.getArea2Superficie();
            }
            if (proyecto.getArea3Activo() && Convert.ToBoolean(proyecto.getArea3VolCob()))
            {
                if (areas_query != "")
                {
                    areas_query += " OR ";
                }
                areas_query += " area = " + proyecto.getArea2Superficie();
            }
            if (proyecto.getArea4Activo() && Convert.ToBoolean(proyecto.getArea4VolCob()))
            {
                if (areas_query != "")
                {
                    areas_query += " OR ";
                }
                areas_query += " area = " + proyecto.getArea2Superficie();
            }
            return areas_query;
        }

        private void buttonAlt_Click(object sender, EventArgs e)
        {
            numericUpDown1.Visible = false;
            get_cat();
        }

        private void buttonDiam_Click(object sender, EventArgs e)
        {
            numericUpDown1.Visible = false;
            get_cad();
        }

        private void buttonDensi_Click(object sender, EventArgs e)
        {
            numericUpDown1.Visible = true;
            numericUpDown1.Value = 5;
            flag = 0;
            get_numero_individuos();
        }

        private void buttonAB_Click(object sender, EventArgs e)
        {
            numericUpDown1.Visible = true;
            numericUpDown1.Value = 5;
            flag = 1;
            get_area_basal();
        }

        private void buttonVolum_Click(object sender, EventArgs e)
        {
            numericUpDown1.Visible = true;
            numericUpDown1.Value = 5;
            flag = 2;
            get_volumen();
        }

        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
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
        }
    }
}
