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
    public partial class GenerarReporte : UserControl
    {
        private Proyecto proyecto;
        private Form1 form1;
      

        public GenerarReporte()
        {
            InitializeComponent();
        }

        public void setForm(Form1 form1)
        {
            this.form1 = form1;
        }
        public void Initialize(Proyecto proyecto)
        {
            this.proyecto = proyecto;

            ///
            ///Tabla y Grafica de Categoria de altura(cat)
            ///
            List<Cat> list_cat = getCats();  //get list of students
            //reportViewer1.LocalReport.DataSources.Clear(); //clear report
            //reportViewer1.LocalReport.ReportEmbeddedResource = "Syldesk.ReporteFormato.rdlc"; // bind reportviewer with .rdlc
            Microsoft.Reporting.WinForms.ReportDataSource dataset_cat = new Microsoft.Reporting.WinForms.ReportDataSource("catDS", list_cat); // set the datasource
            reportViewer1.LocalReport.DataSources.Add(dataset_cat);
            dataset_cat.Value = list_cat;
            reportViewer1.LocalReport.Refresh();
            reportViewer1.RefreshReport(); // refresh report

            ///
            ///Tabla y Grafica de Categoria de altura(cat)
            ///
            List<Cad> list_cad = getCads();  //get list of students
            //reportViewer1.LocalReport.DataSources.Clear(); //clear report
            //reportViewer1.LocalReport.ReportEmbeddedResource = "Syldesk.ReporteFormato.rdlc"; // bind reportviewer with .rdlc
            Microsoft.Reporting.WinForms.ReportDataSource dataset_cad = new Microsoft.Reporting.WinForms.ReportDataSource("cadDS", list_cad); // set the datasource
            reportViewer1.LocalReport.DataSources.Add(dataset_cad);
            dataset_cad.Value = list_cad;
            reportViewer1.LocalReport.Refresh();
            reportViewer1.RefreshReport(); // refresh report



        }

        private void GenerarReporte_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();                        
        }

        
        public List<Cat> getCats()
        {
            List<Cat> list = new List<Cat>();

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


                    //chart1.Series.Add(new kawaii_lolis.Series("" + current_rango));
                    //chart1.Series[i].Points.AddXY("" + current_rango, aux[0]);
                    //chart1.Series[i].ToolTip = "CAT: #VALX\nConteo: #VALY ";          //Tooltips para cada barra

                    list.Add(
                        new Cat
                        {
                            cat = current_rango,
                            no_individuos = Convert.ToInt32(aux[0]),
                        }
                    );

                    current_rango += rango_cat;
                }
            }

            return list;
        }

        public List<Cad> getCads()
        {
            List<Cad> list = new List<Cad>();

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

                    //chart1.Series.Add(new kawaii_lolis.Series("" + current_rango));
                    //chart1.Series[i].Points.AddXY("" + current_rango, aux[0]);
                    //chart1.Series[i].ToolTip = "CaD #VALX\nConteo: #VALY ";          //Tooltips para cada barra

                    list.Add(
                        new Cad
                        {
                            cad = current_rango,
                            no_individuos = Convert.ToInt32(aux[0]),
                        }
                    );

                    //dataGridView1.Rows.Add(current_rango, aux[0]);

                    current_rango += rango_cad;
                }
            }

            return list;
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
                areas_query += " area = " + proyecto.getArea3Superficie();
            }
            if (proyecto.getArea4Activo() && Convert.ToBoolean(proyecto.getArea4VolCob()))
            {
                if (areas_query != "")
                {
                    areas_query += " OR ";
                }
                areas_query += " area = " + proyecto.getArea4Superficie();
            }
            return areas_query;
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            form1.formRegistro2ToFront(proyecto);
        }
    }
}
