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
        int proyecto_id;
        Form1 form1;
        MySqlCommand cmd;

        public Grafica(Form1 form1)
        {
            this.form1 = form1;
            InitializeComponent();
            //series1 = chart1.Series[0];

        }

        /*private void Grafica_Load(object sender, EventArgs e)
        {
           
        }*/

        public void Initialize(int proyecto_id)
        {
            Empty();
            this.proyecto_id = proyecto_id;
            //comboBoxSitios_Populate();
        }

        public void Empty()
        {
            chart1.Series.Clear();
            chart1.Titles.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            //chartPie.Series.Clear();
        }


        private void button17_Click(object sender, EventArgs e)
        {

            form1.formRegistro2ToFront(proyecto_id);
        }

        private void get_cat() //individuos por categorias de altura
        {
            Empty();
            chart1.Titles.Add("Detalles de Categorias de AlTura");   //titulo de la Grafica
            dataGridView1.Columns.Add("cat", "categoria de altura");
            dataGridView1.Columns.Add("conteo", "conteo");

            double rango_cat = 0;

            cmd = SqlConnector.getConnection(cmd);

            string sqlQueryString = "SELECT Min(alturatotal) as minimo " +
                " from individuos where proyecto_id = @proyecto_id AND area = 500 AND alturatotal > 0";
            cmd.CommandText = sqlQueryString;
            cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);

            var results = cmd.ExecuteReader();
            results.Read();
            double min = Convert.ToDouble(results[0]);
           results.Close();
            results.Dispose();


            cmd = SqlConnector.getConnection(cmd);

            sqlQueryString = "SELECT Max(alturatotal) as maximo " +
                " from individuos where proyecto_id = @proyecto_id AND area = 500 AND alturatotal > 0";
            cmd.CommandText = sqlQueryString;
            cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);

            results = cmd.ExecuteReader();
            results.Read();
            double max = Convert.ToDouble(results[0]);
           
            results.Close();
            results.Dispose();

            if (max <= 15)
            {
                rango_cat = 2;
            }
            else if (max <= 20)
            {
                rango_cat = 2.5;
            }
            else if (max <= 25)
            {
                rango_cat = 5;
            }
            else if (max <= 30)
            {
                rango_cat = 7.5;
            }
            else if (max <= 35)
            {
                rango_cat = 10;
            }
            else if (max <= 40)
            {
                rango_cat = 12.5;
            }

            double rango_cat2 = rango_cat / 2;
            double current_rango = 5;
            for (int i = 0; i < 5; i++)
            {
                cmd = SqlConnector.getConnection(cmd);

                double lower_point = current_rango - rango_cat2;
                double upper_point = current_rango + rango_cat2;
                if (i == 0)
                {
                    sqlQueryString = "SELECT Count(*) as conteo " +
                        " from individuos where proyecto_id = @proyecto_id AND area = 500 AND alturatotal < " + upper_point;
                }
                else if (i == 4)
                {
                    sqlQueryString = "SELECT Count(*) as conteo " +
                        " from individuos where proyecto_id = @proyecto_id AND area = 500 AND alturatotal > " + lower_point;
                }
                else
                {
                    sqlQueryString = "SELECT Count(*) as conteo " +
                        " from individuos where proyecto_id = @proyecto_id AND area = 500 AND alturatotal > " + lower_point + " AND alturatotal < " + upper_point;
                }

                cmd.CommandText = sqlQueryString;
                cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);

                results = cmd.ExecuteReader();
                results.Read();
                chart1.Series.Add(new kawaii_lolis.Series("" + current_rango));
                chart1.Series[i].Points.AddXY("" + current_rango, results[0]);
                chart1.Series[i].ToolTip = "CAT: #VALX\nConteo: #VALY ";          //Tooltips para cada barra

                dataGridView1.Rows.Add(current_rango, results[0]);

                results.Close();
                results.Dispose();

                current_rango += rango_cat;
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
            chart1.Titles.Add("Detalles de Categorias Diametricas");   //titulo de la Grafica
            dataGridView1.Columns.Add("cad", "categoria de diametro");
            dataGridView1.Columns.Add("conteo", "conteo");

            double rango_cad = 0;

            cmd = SqlConnector.getConnection(cmd);

            string sqlQueryString = "SELECT Min(diametro) as minimo " +
                " from individuos where proyecto_id = @proyecto_id AND area = 500 AND diametro > 0";
            cmd.CommandText = sqlQueryString;
            cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);

            var results = cmd.ExecuteReader();
            results.Read();
            double min = Convert.ToDouble(results[0]);
            results.Close();
            results.Dispose();


            cmd = SqlConnector.getConnection(cmd);

            sqlQueryString = "SELECT Max(diametro) as maximo " +
                " from individuos where proyecto_id = @proyecto_id AND area = 500 AND diametro > 0";
            cmd.CommandText = sqlQueryString;
            cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);

            results = cmd.ExecuteReader();
            results.Read();
            double max = Convert.ToDouble(results[0]);

            results.Close();
            results.Dispose();

            if (max <= 20)
            {
                rango_cad = 2;
            }
            else if (max <= 25)
            {
                rango_cad = 2.5;
            }
            else if (max <= 30)
            {
                rango_cad = 5;
            }
            else if (max <= 35)
            {
                rango_cad = 7.5;
            }
            else if (max <= 40)
            {
                rango_cad = 10;
            }
            else if (max <= 45)
            {
                rango_cad = 12.5;
            }
            else if (max <= 50)
            {
                rango_cad = 15;
            }
            else if (max <= 55)
            {
                rango_cad = 17.5;
            }
            else if (max <= 60)
            {
                rango_cad = 20;
            }

            double rango_cad2 = rango_cad / 2;
            double current_rango = 5;
            for (int i = 0; i < 5; i++)
            {
                cmd = SqlConnector.getConnection(cmd);

                double lower_point = current_rango - rango_cad2;
                double upper_point = current_rango + rango_cad2;
                if (i == 0)
                {
                    sqlQueryString = "SELECT Count(*) as conteo " +
                        " from individuos where proyecto_id = @proyecto_id AND area = 500 AND diametro < " + upper_point;
                }
                else if (i == 4)
                {
                    sqlQueryString = "SELECT Count(*) as conteo " +
                        " from individuos where proyecto_id = @proyecto_id AND area = 500 AND diametro > " + lower_point;
                }
                else
                {
                    sqlQueryString = "SELECT Count(*) as conteo " +
                        " from individuos where proyecto_id = @proyecto_id AND area = 500 AND diametro >= " + lower_point + " AND diametro < " + upper_point;
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
            chart1.Titles.Add("Detalles de Conteo");   //titulo de la Grafica
            dataGridView1.Columns.Add("numero_individuos", "numero de individuos");
            dataGridView1.Columns.Add("conteo", "conteo");

            cmd = SqlConnector.getConnection(cmd);  

            string sqlQueryString = "SELECT nombrecientifico, Count(nombrecientifico) as conteo " +
                " from individuos where proyecto_id = @proyecto_id AND area = 500 AND bifurcados = 0 Group By nombrecientifico ORDER BY conteo DESC";
            cmd.CommandText = sqlQueryString;
            cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);

            var results = cmd.ExecuteReader();

            for (int i = 0; i < 5; i++)
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

                    chart1.Series[i].ToolTip = "#VALX\nConteo: #VALY ";          //Tooltips para cada barra
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
            chart1.Titles.Add("Detalles de Area Basal");   //titulo de la Grafica
            dataGridView1.Columns.Add("especie", "especie de altura");
            dataGridView1.Columns.Add("suma_ab", "suma de ab");
            dataGridView1.Columns.Add("ab_ha", "AB (m2/ha)");
            dataGridView1.Columns.Add("ab_ha2", "AB (m2/2.812 ha)");







            chart1.ChartAreas[0].RecalculateAxesScale();

        }

        private void get_volumen()
        {
            Empty();

            chart1.Titles.Add("Detalles de Volumen");   //titulo de la Grafica
            dataGridView1.Columns.Add("especie", "especie");
            dataGridView1.Columns.Add("conteo", "conteo");

            cmd = SqlConnector.getConnection(cmd);

            string sqlQueryString = "SELECT nombrecientifico, Sum(volumenvv) as volumen " +
                " from individuos where proyecto_id = @proyecto_id AND area = 500 AND volumenvv > 0 Group By nombrecientifico ORDER BY volumen DESC";
            cmd.CommandText = sqlQueryString;
            cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);

            var results = cmd.ExecuteReader();


            

            for (int i = 0; i < 5; i++)
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

                    chart1.Series[i].ToolTip = "#VALX\nVolumen: #VALY ";          //Tooltips para cada barra
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
            get_cat();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            get_cad();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            get_numero_individuos();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            get_area_basal();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            get_volumen();
        }
    }
}
