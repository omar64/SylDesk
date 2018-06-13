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
            get_volumen();
            //comboBoxSitios_Populate();
        }

        public void Empty()
        {
            chart1.Series.Clear();
            //chartPie.Series.Clear();
        }


        private void button17_Click(object sender, EventArgs e)
        {

            form1.formRegistro2ToFront(proyecto_id);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {            
            if(checkBox1.Checked)
            {

                chart1.Series[0].Enabled = true;
            }
            else
            {

                chart1.Series[0].Enabled = false;
            }

        }


        private void get_volumen()
        {
            cmd = SqlConnector.getConnection(cmd);

            string sqlQueryString = "SELECT nombrecientifico, Sum(volumenvv) as volumen " +
                " from individuos where proyecto_id = @proyecto_id AND area = 500 AND volumenvv > 0 Group By nombrecientifico ORDER BY volumen DESC";
            cmd.CommandText = sqlQueryString;
            cmd.Parameters.AddWithValue("@proyecto_id", proyecto_id);

            var results = cmd.ExecuteReader();


            chart1.Titles.Add("Detalles de Volumen");   //titulo de la Grafica
            

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


                    //chart1.Dock = System.Windows.Forms.DockStyle.Fill;
                    
                    chart1.Series[i].ToolTip = "#VALX\nVolumen: #VALY ";          //Tooltips para cada barra
                }
                else
                {
                    break;
                }
            }

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
    }
}
