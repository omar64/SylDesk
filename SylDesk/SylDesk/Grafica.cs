using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts; //Core of the library
using LiveCharts.Wpf; //The WPF controls
using LiveCharts.WinForms; //the WinForm wrappers
using kawaii_lolis = System.Windows.Forms.DataVisualization.Charting;
using MySql.Data.MySqlClient;


namespace SylDesk
{
    public partial class Grafica : UserControl
    {
        private int proyecto_id;
        private Form1 form1;
        private MySqlCommand cmd;
        private Boolean flag = false;
        private double superficie = 0;

        public Grafica(Form1 form1)
        {
            this.form1 = form1;
            InitializeComponent();            
        }

        public void Initialize(int proyecto_id)
        {
            Empty();
            this.proyecto_id = proyecto_id;
            numericUpDown1.Visible = false;
            comboBox1.Visible = true;
            comboBox1.SelectedIndex = 0;

            string sqlQueryString = "SELECT superficie " +
                " from proyectos where id = @id";
            cmd = SqlConnector.getConnection(cmd);
            cmd.CommandText = sqlQueryString;
            cmd.Parameters.AddWithValue("@id", proyecto_id);
            var results = cmd.ExecuteReader();
            results.Read();
            superficie = Convert.ToDouble(results[0]);

            results.Close();
            results.Dispose();
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
            //chart1.Titles.Add("Detalles de Categorías de Altura");   //titulo de la Grafica
            //chart1.ChartAreas[0].AxisX.Title = "Categorías de altura (m)";  //pie de grafica
            chart1.ChartAreas[0].AxisY.Title = "Número de individuos";            
            dataGridView1.Columns.Add("cat", "Categoría de Altura");
            dataGridView1.Columns.Add("conteo", "Conteo");


            cmd = SqlConnector.getConnection(cmd);

            string sqlQueryString = "SELECT Min(alturatotal) as minimo " +
                " from individuos where proyecto_id = @proyecto_id AND area = 500 AND alturatotal > 0 AND bifurcados = 0";
            cmd.CommandText = sqlQueryString;
            cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);

            var results = cmd.ExecuteReader();
            results.Read();
            double min = Convert.ToDouble(results[0]);
            results.Close();
            results.Dispose();


            cmd = SqlConnector.getConnection(cmd);

            sqlQueryString = "SELECT Max(alturatotal) as maximo " +
                " from individuos where proyecto_id = @proyecto_id AND area = 500 AND alturatotal > 0 AND bifurcados = 0";
            cmd.CommandText = sqlQueryString;
            cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);

            results = cmd.ExecuteReader();
            results.Read();
            double max = Convert.ToDouble(results[0]);
           
            results.Close();
            results.Dispose();

            int length = Convert.ToInt32(max / 2.5) - 1;

            double current_rango = 5;
            double rango_cat = 2.5;
            double rango_cat2 = rango_cat / 2;

            for (int i = 0; i < length; i++)
            {
                cmd = SqlConnector.getConnection(cmd);

                double lower_point = current_rango - rango_cat2;
                double upper_point = current_rango + rango_cat2;
                if (i == 0)
                {
                    sqlQueryString = "SELECT Count(*) as conteo " +
                        " from individuos where proyecto_id = @proyecto_id AND bifurcados = 0 AND area = 500 AND alturatotal < " + upper_point;
                }
                else if (i == (length - 1))
                {
                    sqlQueryString = "SELECT Count(*) as conteo " +
                        " from individuos where proyecto_id = @proyecto_id AND bifurcados = 0 AND area = 500 AND alturatotal > " + lower_point;
                }
                else
                {
                    sqlQueryString = "SELECT Count(*) as conteo " +
                        " from individuos where proyecto_id = @proyecto_id AND bifurcados = 0 AND area = 500 AND alturatotal > " + lower_point + " AND alturatotal < " + upper_point;
                }

                cmd.CommandText = sqlQueryString;
                cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);

                results = cmd.ExecuteReader();
                results.Read();
                chart1.Series.Add(new kawaii_lolis.Series("" + current_rango));
                chart1.Series[i].Points.AddXY("" + current_rango, results[0]);
                chart1.Series[i].ToolTip = "CAT: #VALX\nConteo: #VALY ";          //Tooltips para cada barra
                //chart1.Series[i].LegendText = "BANANA";

                dataGridView1.Rows.Add(current_rango, results[0]);

                results.Close();
                results.Dispose();

                current_rango += rango_cat;

                //chart1.Series[i].ChartType = kawaii_lolis.SeriesChartType.FastLine;
                //chart1.Series[i].BorderWidth = 2;
                //chart1.ChartAreas[0].InnerPlotPosition.X = 0;


                //chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -45;

                chart1.AlignDataPointsByAxisLabel();

                //chart1.Series[i]["PixelPointWidth"] = "75";

                //chart1.Series[i]["PointWidth"] = "0.3";  //grosor de las barras

                //chart1.Series[0].BorderWidth = 10;
                //chart1.ChartAreas[0].AxisX.Interval = 0;

                chart1.Series[i]["LabelStyle"] = "Center";
                chart1.Series[i]["LabelStyle"] = "Top";
                chart1.Series[i].IsValueShownAsLabel = true;
                chart1.Series[i].ChartType = kawaii_lolis.SeriesChartType.Column;
                chart1.Series[i].LabelBackColor = Color.LightCyan;
                chart1.Series[i].Font = new Font("Arial", 9);


                chart1.Series[i].Points[i].Color = Color.ForestGreen;  //color de barras verde
                //chart1.Series[i].Points[i].Label = "#VALY";  //Valor position top


                chart1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 9);  //Font grafica






            }
            
            

            chart1.ChartAreas[0].RecalculateAxesScale();
            /*
            chart1.Series.Add(new kawaii_lolis.Series("Min"));
            chart1.Series[chart1.Series.Count - 1].Points.AddXY("" + min, min);
            chart1.Series[chart1.Series.Count - 1].ToolTip = "#VALX\nConteo: #VALY ";          //Tooltips para cada barra

            chart1.Series.Add(new kawaii_lolis.Series("Max"));
            chart1.Series[chart1.Series.Count - 1].Points.AddXY("" + max, max);
            chart1.Series[chart1.Series.Count - 1].ToolTip = "#VALX\nConteo: #VALY ";          //Tooltips para cada barra
            */
        }

        private void get_cad() //individuos categoria diametricas
        {
            Empty();
            //chart1.Titles.Add("Detalles de Categorías Diametricas");   //titulo de la Grafica
            //chart1.ChartAreas[0].AxisX.Title = "Clases diamétricas (cm)";  //pie de grafica
            chart1.ChartAreas[0].AxisY.Title = "Número de individuos";
            dataGridView1.Columns.Add("cad", "Categoría de Diámetro");
            dataGridView1.Columns.Add("conteo", "Conteo");

            cmd = SqlConnector.getConnection(cmd);

            string sqlQueryString = "SELECT Min(diametro) as minimo " +
                " from individuos where proyecto_id = @proyecto_id AND area = 500 AND diametro > 0 AND bifurcados = 0";
            cmd.CommandText = sqlQueryString;
            cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);

            var results = cmd.ExecuteReader();
            results.Read();
            double min = Convert.ToDouble(results[0]);
            results.Close();
            results.Dispose();


            cmd = SqlConnector.getConnection(cmd);

            sqlQueryString = "SELECT Max(diametro) as maximo " +
                " from individuos where proyecto_id = @proyecto_id AND area = 500 AND diametro > 0 AND bifurcados = 0";
            cmd.CommandText = sqlQueryString;
            cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);

            results = cmd.ExecuteReader();
            results.Read();
            double max = Convert.ToDouble(results[0]);

            results.Close();
            results.Dispose();

            int length = Convert.ToInt32(max / 5) - 1;

            double current_rango = 10;
            double rango_cad = 5;
            double rango_cad2 = rango_cad / 2;

            for (int i = 0; i < length; i++)
            {
                cmd = SqlConnector.getConnection(cmd);

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

                cmd.CommandText = sqlQueryString;
                cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);

                results = cmd.ExecuteReader();
                results.Read();
                chart1.Series.Add(new kawaii_lolis.Series("" + current_rango));
                chart1.Series[i].Points.AddXY("" + current_rango, results[0]);
                chart1.Series[i].ToolTip = "CaD #VALX\nConteo: #VALY ";          //Tooltips para cada barra

                dataGridView1.Rows.Add(current_rango, results[0]);

                results.Close();
                results.Dispose();

                current_rango += rango_cad;

                chart1.AlignDataPointsByAxisLabel();

                chart1.Series[i]["PixelPointWidth"] = "75";

                //chart1.Series[0]["PointWidth"] = "0";  //grosor de las barras
                //chart1.Series[0].Font = new Font("Gothic", 7, FontStyle.Bold);

                chart1.Series[i].Points[i].Color = Color.ForestGreen;  //color de barras verde

                chart1.Series[i]["LabelStyle"] = "Center";
                chart1.Series[i]["LabelStyle"] = "Top";
                chart1.Series[i].IsValueShownAsLabel = true;
                chart1.Series[i].ChartType = kawaii_lolis.SeriesChartType.Column;
                chart1.Series[i].LabelBackColor = Color.LightCyan;
                chart1.Series[i].Font = new Font("Arial", 9);
                //chart1.Series[i].Points[i].Label = "#VALY"; //Valor position top
                chart1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 9); //Font grafica

            }


            chart1.ChartAreas[0].RecalculateAxesScale();
            /*
            chart1.Series.Add(new kawaii_lolis.Series("Min"));
            chart1.Series[chart1.Series.Count - 1].Points.AddXY("" + min, min);
            chart1.Series[chart1.Series.Count - 1].ToolTip = "#VALX\nConteo: #VALY ";          //Tooltips para cada barra

            chart1.Series.Add(new kawaii_lolis.Series("Max"));
            chart1.Series[chart1.Series.Count - 1].Points.AddXY("" + max, max);
            chart1.Series[chart1.Series.Count - 1].ToolTip = "#VALX\nConteo: #VALY ";          //Tooltips para cada barra
            */
        }

        private void get_numero_individuos() // Mayor numero de individuos en el predio
        {
            Empty();
            //chart1.Titles.Add("Detalles de Conteo");   //titulo de la Grafica
            //chart1.ChartAreas[0].AxisX.Title = "Especies con el mayor número de individuos registrados en el predio"; //pie de grafica
            chart1.ChartAreas[0].AxisY.Title = "Densidad (Ind/ha)";
            dataGridView1.Columns.Add("numero_individuos", "Número de Individuos");
            dataGridView1.Columns[0].DefaultCellStyle.Font = new Font("Palace Script MT", 22);  //font Cursiva columna Nom. Cient. 
            dataGridView1.Columns.Add("conteo", "Conteo");

            cmd = SqlConnector.getConnection(cmd);  

            string sqlQueryString = "SELECT nombrecientifico, Count(nombrecientifico) as conteo " +
                " from individuos where proyecto_id = @proyecto_id AND area = 500 AND bifurcados = 0 Group By nombrecientifico ORDER BY conteo DESC";
            cmd.CommandText = sqlQueryString;
            cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);

            var results = cmd.ExecuteReader();

            for (int i = 0; i < numericUpDown1.Value; i++)
            {
                if (results.Read())
                {
                    List<Object> lista_individuos = new List<Object>();
                    lista_individuos.Add(results[0]);
                    lista_individuos.Add(results[1]);
                    //lista_individuos.Add(results[2]);

                    chart1.Series.Add(new kawaii_lolis.Series("" + results[0]));
                    chart1.Series[i].Points.AddXY("" + results[0], results[1]);
                    
                    dataGridView1.Rows.Add(results[0], results[1]);

                    //chart1.Dock = System.Windows.Forms.DockStyle.Fill;

                    chart1.AlignDataPointsByAxisLabel();

                    
                    chart1.Series[i]["PixelPointWidth"] = "75";
                    chart1.Series[i]["PointWidth"] = "0.3";  //grosor de las barras

                    /*chart1.Series[i]["LabelStyle"] = "Center";
                    chart1.Series[i]["LabelStyle"] = "Top";
                    chart1.Series[i].IsValueShownAsLabel = true;
                    chart1.Series[i].ChartType = kawaii_lolis.SeriesChartType.Column;
                    chart1.Series[i].LabelBackColor = Color.LightCyan;
                    chart1.Series[i].Font = new Font("Arial", 12);*/
                    //chart1.ChartAreas[i].AxisX.Interval = 1;

                    chart1.Series[i].ToolTip = "#VALX\nConteo: #VALY ";          //Tooltips para cada barra

                    chart1.Series[i].Points[i].Color = Color.ForestGreen;  //color de barras verde
                    //chart1.Series[i].Points[i].Label = "#VALY"; //Valor position top

                    chart1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Palace Script MT", 20);
                }
                else
                {
                    break;
                }
            }
            chart1.ChartAreas[0].RecalculateAxesScale();

            results.Close();
            results.Dispose();
        }

        private void get_area_basal() // area basal por especie (m^2 / ha)
        {
            Empty();
            //chart1.Titles.Add("Detalles de Área Basal");   //titulo de la Grafica
            //chart1.ChartAreas[0].AxisX.Title = "Especies con mayor área basal en el predio";  //pie de grafica
            chart1.ChartAreas[0].AxisY.Title = "Area basal (m^2/ha)";
            dataGridView1.Columns.Add("especie", "Especie");
            dataGridView1.Columns[0].DefaultCellStyle.Font = new Font("Palace Script MT", 22);  //font Cursiva columna Nom. Cient.
            dataGridView1.Columns.Add("suma_ab", "AB m^2 (Muestreo)");
            dataGridView1.Columns.Add("ab_ha", "AB m^2 (Hectarea)");
            dataGridView1.Columns.Add("ab_ha2", "AB m^2  (SCUSTF)");

            cmd = SqlConnector.getConnection(cmd);

            string sqlQueryString = "SELECT nombrecientifico, Sum(areabasal) as areabasal2 " +
                " from individuos where proyecto_id = @proyecto_id AND area = 500 AND areabasal > 0 Group By nombrecientifico ORDER BY areabasal2 DESC";
            cmd.CommandText = sqlQueryString;
            cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);

            var results = cmd.ExecuteReader();

            for (int i = 0; i < numericUpDown1.Value; i++)
            {                
                if (results.Read())
                {
                    List<Object> lista_individuos = new List<Object>();
                    lista_individuos.Add(results[0]);
                    lista_individuos.Add(results[1]);
                    //lista_individuos.Add(results[2]);

                    chart1.Series.Add(new kawaii_lolis.Series("" + results[0]));
                    chart1.Series[i].Points.AddXY("" + results[0], results[1]);

                    double ha = Convert.ToDouble(results[1]) / 0.6;
                    double ha2 = Convert.ToDouble(results[1]) / (0.6 / superficie);
                    dataGridView1.Rows.Add(results[0], results[1], ha, ha2);
                    //chart1.Dock = System.Windows.Forms.DockStyle.Fill;

                    chart1.AlignDataPointsByAxisLabel();

                    //chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -45;

                    chart1.Series[i]["PixelPointWidth"] = "75";

                    chart1.Series[i]["PointWidth"] = "0.3";  //grosor de las barras

                    chart1.Series[i].ToolTip = "#VALX\nArea Basal: #VALY ";          //Tooltips para cada barra

                    chart1.Series[i].Points[i].Color = Color.ForestGreen;  //color de barras verde
                    //chart1.Series[i].Points[i].Label = "#VALY"; //Valor position top
                    chart1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Palace Script MT", 20);


                }
                else
                {
                    break;
                }
            }
            chart1.ChartAreas[0].RecalculateAxesScale();

            results.Close();
            results.Dispose();

        }

        private void get_volumen()
        {
            Empty();

            //chart1.Titles.Add("Detalles de Volumen");   //titulo de la Grafica
            //chart1.ChartAreas[0].AxisX.Title = "Especies con mayor volumen en el predio";  //pie de grafica
            chart1.ChartAreas[0].AxisY.Title = "Volumen (m^3/ha)";
            dataGridView1.Columns.Add("especie", "Especie");
            dataGridView1.Columns[0].DefaultCellStyle.Font = new Font("Palace Script MT", 22);  //font Cursiva columna Nom. Cient.
            dataGridView1.Columns.Add("suma_volumen", "Vol m^3 (Muestreo)");
            dataGridView1.Columns.Add("volumen_ha", "Vol m^3 (Hectareo)");
            dataGridView1.Columns.Add("volumen_ha2", "Vol m^3 (SCUSTF)");

            cmd = SqlConnector.getConnection(cmd);

            string sqlQueryString = "SELECT nombrecientifico, Sum(volumenvv) as volumen " +
                " from individuos where proyecto_id = @proyecto_id AND area = 500 AND volumenvv > 0 Group By nombrecientifico ORDER BY volumen DESC";
            cmd.CommandText = sqlQueryString;
            cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);

            var results = cmd.ExecuteReader();
            
            for (int i = 0; i < numericUpDown1.Value; i++)
            {
                if (results.Read())
                {
                    List<Object> lista_individuos = new List<Object>();
                    lista_individuos.Add(results[0]);
                    lista_individuos.Add(results[1]);
                    //lista_individuos.Add(results[2]);

                    chart1.Series.Add(new kawaii_lolis.Series("" + results[0]));
                    chart1.Series[i].Points.AddXY("" + results[0], results[1]);

                    double ha = Convert.ToDouble(results[1]) / 0.6;
                    double ha2 = Convert.ToDouble(results[1]) / (0.6 / superficie);
                    dataGridView1.Rows.Add(results[0], results[1], ha, ha2);
                    //chart1.Dock = System.Windows.Forms.DockStyle.Fill;

                    chart1.AlignDataPointsByAxisLabel();

                    //chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -45;

                    chart1.Series[i]["PixelPointWidth"] = "75";

                    chart1.Series[i]["PointWidth"] = "0.3";  //grosor de las barras

                    chart1.Series[i].ToolTip = "#VALX\nVolumen: #VALY ";          //Tooltips para cada barra

                    chart1.Series[i].Points[i].Color = Color.ForestGreen;  //color de barras verde
                    //chart1.Series[i].Points[i].Label = "#VALY"; //Valor position top
                    chart1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Palace Script MT", 20);

                }
                else
                {
                    break;
                }
            }
            chart1.ChartAreas[0].RecalculateAxesScale();

            results.Close();
            results.Dispose();
        }

        private void get_IVI(int area)
        {
            Empty();

            String area_str = "";
            if (area == 500)
            {
                area_str = "arboreo";
            }
            else if (area == 100)
            {
                area_str = "arbustivo";
            }
            else if (area == 5)
            {
                area_str = "herbaceo";
            }

            //chart1.Titles.Add("IVI " + area_str);   //titulo de la Grafica
            //chart1.ChartAreas[0].AxisX.Title = "Valor de Importancia";  //pie de grafica
            chart1.ChartAreas[0].AxisY.Title = "Especies del estrato arbóreo con el I.V.I";
            dataGridView1.Columns.Add("especie", "Especie");
            dataGridView1.Columns[0].DefaultCellStyle.Font = new Font("Palace Script MT", 22);  //font Cursiva columna Nom. Cient.
            dataGridView1.Columns.Add("frecuencia_absoluta", "Frecuencia absoluta");
            dataGridView1.Columns.Add("frecuencia_relativa", "Frecuencia relativa");
            dataGridView1.Columns.Add("densidad_absoluta", "Densidad absoluta");
            dataGridView1.Columns.Add("densidad_relativa", "Densidad relativa");
            dataGridView1.Columns.Add("dominancia_absoluta", "Dominancia absoluta");
            dataGridView1.Columns.Add("dominancia_relativa", "Dominancia relativa");

            int num_sitios = 0;
            List<double> frec_abs = new List<double>();
            List<double> frec_rel = new List<double>();
            List<double> den_abs = new List<double>();
            List<double> den_rel = new List<double>();
            List<double> dom_abs = new List<double>();
            List<double> dom_rel = new List<double>();

            cmd = SqlConnector.getConnection(cmd);
            string sqlQueryString = "SELECT Count(*)" +
                " from sitios where proyecto_id = @proyecto_id";
            cmd.CommandText = sqlQueryString;
            cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);
            
            var results = cmd.ExecuteReader();
            if(results.Read())
            {
                num_sitios = Convert.ToInt32(results[0]);
            }
            results.Close();
            results.Dispose();            

            List<Object> lista_individuos = new List<Object>();
            cmd = SqlConnector.getConnection(cmd);
            sqlQueryString = "SELECT nombrecientifico" +
                " from individuos where proyecto_id = @proyecto_id AND area =  " + area + " Group By nombrecientifico ORDER BY nombrecientifico ASC";
            cmd.CommandText = sqlQueryString;
            cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);
            results = cmd.ExecuteReader();
            while(results.Read())
            {
                lista_individuos.Add(results[0]);                    
            }
            results.Close();
            results.Dispose();

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
                    cmd = SqlConnector.getConnection(cmd);

                    sqlQueryString = "SELECT Count(nombrecientifico), areabasal" +
                        " from individuos where proyecto_id = @proyecto_id AND area =  " + area + " AND sitio = " + j + " AND nombrecientifico = \"" + lista_individuos[i] + "\"";
                    cmd.CommandText = sqlQueryString;
                    cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);
                    results = cmd.ExecuteReader();
                    if (results.Read())
                    {
                        int aux = Convert.ToInt32(results[0]);
                        //sendMessageBox("" + aux + " - " + lista_individuos[i] + " - " + j);
                        if (aux > 0)
                        {
                            frec_aux += 1;
                            dens_aux += aux;
                            dom_aux += Convert.ToDouble(results[1]);
                            //sendMessageBox("pls tell me" + lista_individuos[i] + " - " + j + " - " + frec_aux + " - " + dens_aux + " - " + dom_aux);
                        }
                    }
                    results.Close();
                    results.Dispose();
                }

                int area_muestreada = area * num_sitios;
                frec_abs[i] = frec_aux / num_sitios;
                den_abs[i] = dens_aux / area_muestreada;
                dom_abs[i] = dom_aux / area_muestreada;
                frec_total += frec_abs[i];
                den_total += den_abs[i];
                dom_total += dom_abs[i];

                /*
                sendMessageBox("UGH");
                sendMessageBox(frec_aux + " - " + dens_aux + " - " + dom_aux);
                sendMessageBox(frec_abs[i] + " - " + den_abs[i] + " - " + dom_abs[i]);
                */
            }

            for (int i = 0; i < lista_individuos.Count; i++)
            {
                frec_rel[i] = frec_abs[i] / frec_total;
                den_rel[i] = den_abs[i] / den_total;
                dom_rel[i] = dom_abs[i] / dom_total;

                chart1.Series.Add(new kawaii_lolis.Series("" + lista_individuos[i]));
                chart1.Series[i].Points.AddXY("" + lista_individuos[i], frec_rel[i] + den_rel[i] + dom_rel[i]);

                dataGridView1.Rows.Add(lista_individuos[i], frec_abs[i], frec_rel[i], den_abs[i], den_rel[i], dom_abs[i], dom_rel[i]);
                //chart1.Dock = System.Windows.Forms.DockStyle.Fill;

                chart1.AlignDataPointsByAxisLabel();

                //chart1.ChartAreas[0].AxisX.LabelStyle.Angle = -45;

                chart1.Series[i]["PixelPointWidth"] = "75";

                chart1.Series[i]["PointWidth"] = "0.3";  //grosor de las barras

                chart1.Series[i].ToolTip = "#VALX\nIVI: #VALY ";          //Tooltips para cada barra

                chart1.Series[i].Points[i].Color = Color.ForestGreen;  //color de barras verde
                //chart1.Series[i].Points[i].Label = "#VALY";  //Valor position top
                chart1.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Palace Script MT", 20);


            }
            chart1.ChartAreas[0].RecalculateAxesScale();
        }

        private void sendMessageBox(string message)
        {
            string messageBoxText = message;
            string caption = "Error";
            //MessageBoxButton button = MessageBoxButton.OK;
            //MessageBoxImage icon = MessageBoxImage.Error;
            MessageBox.Show(messageBoxText, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            flag = false;
            get_numero_individuos();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            numericUpDown1.Visible = false;
            get_area_basal();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            numericUpDown1.Visible = true;
            numericUpDown1.Value = 5;
            flag = true; ;
            get_volumen();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            numericUpDown1.Visible = false;
            get_IVI(500);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            numericUpDown1.Visible = false;
            get_IVI(100);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            numericUpDown1.Visible = false;
            get_IVI(5);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (flag)
            {
                get_volumen();
            }
            else
            {
                get_numero_individuos();
            }
        }

        
    }
}
