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
    public partial class ValordeImportancia : UserControl
    {
        private Proyecto proyecto;
        private Form1 form1;
        private int flag = 0;
        private double superficie = 0;

        public ValordeImportancia()
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

            if (!proyecto.getArea1Activo())
            {
                buttonIVI1.Visible = false;
            }
            if (!proyecto.getArea2Activo())
            {
                buttonIVI2.Visible = false;
            }
            if (!proyecto.getArea3Activo())
            {
                buttonIVI3.Visible = false;
            }
            if (!proyecto.getArea4Activo())
            {
                buttonIVI4.Visible = false;
            }

            buttonIVI1.Text = "" + proyecto.getArea1Tag();
            buttonIVI2.Text = "" + proyecto.getArea2Tag();
            buttonIVI3.Text = "" + proyecto.getArea3Tag();
            buttonIVI4.Text = "" + proyecto.getArea4Tag();
        }
        public void Empty()
        {
            chart1.Series.Clear();
            chart1.Titles.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
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

            /////////////////////////// ARREGLAAAAAAAAAAAAAAAAAR ////////////////////////////////////////////

            SqlConnector.sendOptionsMessage("Decision", "Diametro(Si) o Cobertura(No)", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);

            ////////////////////////////////////////////////////////////////////////////////////////////////

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
                new String[] { "" + proyecto.getId() }
            );
            num_sitios = Convert.ToInt32(aux[0]);

            List<Object> lista_individuos = new List<Object>();
            List<IVI> list_ivis = new List<IVI>();

            List<List<String>> aux2 = SqlConnector.anyEspecificValuesGet(
                "SELECT nombrecientifico from individuos where proyecto_id = @proyecto_id AND area = " + area + " AND nombrecientifico != \"\" Group By nombrecientifico ORDER BY nombrecientifico ASC",
                new String[] { "proyecto_id" },
                new String[] { "" + proyecto.getId() }
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
                        new String[] { "" + proyecto.getId() }
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
            for (int i = 0; i < numericUpDown1.Value && i < list_ivis2.Count; i++)
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

        

        

        

        private void numericUpDown1_ValueChanged_1(object sender, EventArgs e)
        {
            if (flag == 3)
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

        

        private void buttonIVI1_Click(object sender, EventArgs e)
        {
            numericUpDown1.Visible = true;
            numericUpDown1.Value = 5;
            flag = 3;
            get_IVI(Convert.ToInt32(proyecto.getArea1Superficie()));
        }

        private void buttonIVI2_Click(object sender, EventArgs e)
        {
            numericUpDown1.Visible = true;
            numericUpDown1.Value = 5;
            flag = 4;
            get_IVI(Convert.ToInt32(proyecto.getArea2Superficie()));
        }

        private void buttonIVI3_Click(object sender, EventArgs e)
        {
            numericUpDown1.Visible = true;
            numericUpDown1.Value = 5;
            flag = 5;
            get_IVI(Convert.ToInt32(proyecto.getArea3Superficie()));
        }

        private void buttonIVI4_Click(object sender, EventArgs e)
        {
            numericUpDown1.Visible = true;
            numericUpDown1.Value = 5;
            flag = 5;
            get_IVI(Convert.ToInt32(proyecto.getArea4Superficie()));
        }

        private void buttonback_Click(object sender, EventArgs e)
        {
            form1.formRegistro2ToFront(proyecto);
        }
    }
}
