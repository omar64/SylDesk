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
    public partial class DiversidadyRiqueza : UserControl
    {
        private Proyecto proyecto;
        private Form1 form1;
        private int flag = 0;
        private double superficie = 0;

        public DiversidadyRiqueza()
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
            

            superficie = Convert.ToDouble(proyecto.getSuperficie());
        }
        public void Empty()
        {

            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
        }

        private void get_IDR(String area) //Indice Diversidad
        {
            Empty();
            dataGridView1.Columns.Add("especie", "Especie");
            dataGridView1.Columns.Add("ni", "ni");
            dataGridView1.Columns.Add("pi", "pi");
            dataGridView1.Columns.Add("ln_pi", "Ln(pi)");
            dataGridView1.Columns.Add("shannon", "pi * Ln(pi)");
            dataGridView1.Columns.Add("simpson", "pi^2");

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;


            List<List<String>> null_checker = SqlConnector.anyEspecificValuesGet(
                "SELECT nombrecientifico, Count(*) as conteo from individuos where proyecto_id = @proyecto_id AND area = " + area + " AND nombrecientifico != \"\" AND bifurcados = 0 Group By nombrecientifico",
                new String[] { "proyecto_id" },
                new String[] { "" + proyecto.getId() }
            );

            if (null_checker != null && null_checker.Count > 1)
            {
                List<String> aux = SqlConnector.anyEspecificValueGet(
                    "SELECT Count(*) as conteo from individuos where proyecto_id = @proyecto_id AND area = " + area + " AND nombrecientifico != \"\" AND bifurcados = 0",
                    new String[] { "proyecto_id" },
                    new String[] { "" + proyecto.getId() }
                );

                double i_shannon = 0;
                double e_shannon = 0;
                double i_simpson = 0;
                double i_margalef = 0;
                foreach (List<String> aux2 in null_checker)
                {
                    double pi = Convert.ToDouble(aux2[1]) / Convert.ToDouble(aux[0]);
                    double ln = Math.Log(pi);
                    double shannon = pi * ln;
                    double simpson = Math.Pow(pi, 2);

                    i_shannon += shannon;
                    i_simpson += simpson;

                    dataGridView1.Rows.Add(aux2[0], aux2[1], pi, ln, shannon, simpson);
                }
                i_shannon = Math.Abs(i_shannon);
                e_shannon = i_shannon / Math.Log(null_checker.Count);
                i_simpson = 1 - i_simpson;
                i_margalef = (null_checker.Count - 1) / Math.Log(Convert.ToDouble(aux[0]));

                dataGridView1.Rows.Add("", "", "I. de Shannon", "Sum. pi*Ln(pi)", i_shannon, "");
                dataGridView1.Rows.Add("", "", "Equitatividad Shannon", "E=H/Ln(S)", e_shannon, "");
                dataGridView1.Rows.Add("", "", "I. de Simpson", "S=1-D", "", i_simpson);
                dataGridView1.Rows.Add("", "", "I. de Margalef", "(S-1)/Ln(N)", "", i_margalef);

                List<String> area1 = get_IDR_Resume("500");
                String area1_s = "";
                foreach (string aux3 in area1)
                {
                    area1_s += aux3;
                }
                SqlConnector.sendMessage("Debug", area1_s, MessageBoxIcon.Stop);
            }
            else
            {
                SqlConnector.sendMessage("Datos Faltantes/Inadecuados", "La grafica no puede mostrarse porque no tiene datos adecuados", MessageBoxIcon.Stop);
            }
        }

        private List<String> get_IDR_Resume(String area) //Indice Diversidad
        {
            List<String> results = new List<String>();
            List<List<String>> null_checker = SqlConnector.anyEspecificValuesGet(
                "SELECT nombrecientifico, Count(*) as conteo from individuos where proyecto_id = @proyecto_id AND area = " + area + " AND nombrecientifico != \"\" AND bifurcados = 0 Group By nombrecientifico",
                new String[] { "proyecto_id" },
                new String[] { "" + proyecto.getId() }
            );

            if (null_checker != null && null_checker.Count > 1)
            {
                List<String> aux = SqlConnector.anyEspecificValueGet(
                    "SELECT Count(*) as conteo from individuos where proyecto_id = @proyecto_id AND area = " + area + " AND nombrecientifico != \"\" AND bifurcados = 0",
                    new String[] { "proyecto_id" },
                    new String[] { "" + proyecto.getId() }
                );

                double i_shannon = 0;
                double e_shannon = 0;
                double i_simpson = 0;
                double i_margalef = 0;
                foreach (List<String> aux2 in null_checker)
                {
                    double pi = Convert.ToDouble(aux2[1]) / Convert.ToDouble(aux[0]);
                    double ln = Math.Log(pi);
                    double shannon = pi * ln;
                    double simpson = Math.Pow(pi, 2);

                    i_shannon += shannon;
                    i_simpson += simpson;
                }
                i_shannon = Math.Abs(i_shannon);
                e_shannon = i_shannon / Math.Log(null_checker.Count);
                i_simpson = 1 - i_simpson;
                i_margalef = (null_checker.Count - 1) / Math.Log(Convert.ToDouble(aux[0]));

                results.Add("" + aux[0]);
                results.Add("" + null_checker.Count);
                results.Add("" + i_simpson);
                results.Add("" + i_shannon);
                results.Add("" + e_shannon);
                results.Add("" + i_margalef);

                return results;
            }
            else
            {
                return null;
            }
        }

        private void get_IDR_Resumes() //Indice Diversidad
        {
            Empty();
            dataGridView1.Columns.Add("estrato", "Estrato");
            dataGridView1.Columns.Add("abundancia", "Abundancia");
            dataGridView1.Columns.Add("riqueza", "Riqueza");
            dataGridView1.Columns.Add("i_simpson", "Índice de diversidad Simpson");
            dataGridView1.Columns.Add("i_shannon", "Índice de Shannon-Wiener (H’)");
            dataGridView1.Columns.Add("e_shannon", "Equidad de Shannon");
            dataGridView1.Columns.Add("i_margalef", "Índice de Margalef");

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            List<String> area1 = get_IDR_Resume(proyecto.getArea1Superficie());
            List<String> area2 = get_IDR_Resume(proyecto.getArea2Superficie());
            List<String> area3 = get_IDR_Resume(proyecto.getArea3Superficie());
            List<String> area4 = get_IDR_Resume(proyecto.getArea4Superficie());

            if (area1 != null)
            {
                dataGridView1.Rows.Add(proyecto.getArea1Superficie(), area1[0], area1[1], area1[2], area1[3], area1[4]);
            }
            if (area2 != null)
            {
                dataGridView1.Rows.Add(proyecto.getArea2Superficie(), area2[0], area2[1], area2[2], area2[3], area2[4]);
            }
            if (area3 != null)
            {
                dataGridView1.Rows.Add(proyecto.getArea3Superficie(), area3[0], area3[1], area3[2], area3[3], area3[4]);
            }
            if (area4 != null)
            {
                dataGridView1.Rows.Add(proyecto.getArea4Superficie(), area4[0], area4[1], area4[2], area4[3], area4[4]);
            }
        }

        private void buttonArea1_Click(object sender, EventArgs e)
        {
            get_IDR(proyecto.getArea1Superficie());
        }

        private void buttonArea2_Click(object sender, EventArgs e)
        {
            get_IDR(proyecto.getArea2Superficie());
        }

        private void buttonArea3_Click(object sender, EventArgs e)
        {
            get_IDR(proyecto.getArea3Superficie());
        }

        private void buttonArea4_Click(object sender, EventArgs e)
        {
            get_IDR(proyecto.getArea4Superficie());
        }

        private void buttonResumen_Click(object sender, EventArgs e)
        {
            get_IDR_Resumes();
        }
    }
}
