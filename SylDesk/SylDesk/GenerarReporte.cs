using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace SylDesk
{
    public partial class GenerarReporte : UserControl
    {
        private Proyecto proyecto;
        private Form1 form1;
        private ReportParameter[] parameters = new ReportParameter[6];


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
            parameters[0] = new ReportParameter("flag1", "True");
            parameters[1] = new ReportParameter("flag2", "True");
            parameters[2] = new ReportParameter("flag3", "True");
            parameters[3] = new ReportParameter("flag4", "True");
            parameters[4] = new ReportParameter("flag5", "True");
            parameters[5] = new ReportParameter("flag6", "True");
            this.reportViewer1.LocalReport.SetParameters(parameters);


            reportViewer1.LocalReport.Refresh();
            reportViewer1.RefreshReport(); // refresh report

            reportViewer1.LocalReport.DataSources.Clear();

            checkCAT.Checked = true;
            checkVolumen.Checked = true;
            checkCAD.Checked = true;
            checkDyR.Checked = true;
            checkAB.Checked = true;
            checkIVI.Checked = true;

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

            ///
            ///Tabla y Grafica de Categoria de altura(cat)
            ///
            List<Cad> list_cad = getCads();  //get list of students
            Microsoft.Reporting.WinForms.ReportDataSource dataset_cad = new Microsoft.Reporting.WinForms.ReportDataSource("cadDS", list_cad); // set the datasource
            reportViewer1.LocalReport.DataSources.Add(dataset_cad);
            dataset_cad.Value = list_cad;

            ///
            ///Tabla y Grafica de Numero Individuos
            ///
            List<No_Individuos> list_no_individuos = getNumeroIndividuos();  //get list of students
            Microsoft.Reporting.WinForms.ReportDataSource dataset_no_individuos = new Microsoft.Reporting.WinForms.ReportDataSource("no_individuosDS", list_no_individuos); // set the datasource
            reportViewer1.LocalReport.DataSources.Add(dataset_no_individuos);
            dataset_no_individuos.Value = list_no_individuos;

            ///
            ///Tabla y Grafica de Area Basal
            ///
            List<Area_Basal> list_area_basal = getAreaBasal();  //get list of students
            Microsoft.Reporting.WinForms.ReportDataSource dataset_area_basal = new Microsoft.Reporting.WinForms.ReportDataSource("areabasalDS", list_area_basal); // set the datasource
            reportViewer1.LocalReport.DataSources.Add(dataset_area_basal);
            dataset_area_basal.Value = list_area_basal;

            ///
            ///Tabla y Grafica de Volumen
            ///
            List<Volumen> list_volumen = getVolumen();  //get list of students
            Microsoft.Reporting.WinForms.ReportDataSource dataset_volumen = new Microsoft.Reporting.WinForms.ReportDataSource("volumenDS", list_volumen); // set the datasource
            reportViewer1.LocalReport.DataSources.Add(dataset_volumen);
            dataset_volumen.Value = list_volumen;

            ///
            ///Tabla y Grafica de IVI
            ///
            List<IVI2> list_ivi = getIVI(500);  //get list of students
            Microsoft.Reporting.WinForms.ReportDataSource dataset_ivi = new Microsoft.Reporting.WinForms.ReportDataSource("iviDS", list_ivi); // set the datasource
            reportViewer1.LocalReport.DataSources.Add(dataset_ivi);
            dataset_ivi.Value = list_ivi;

            
            ///
            ///Tabla y Grafica de IDR
            ///
            List<IDR> list_idr = getIDR("500");  //get list of students
            Microsoft.Reporting.WinForms.ReportDataSource dataset_idr = new Microsoft.Reporting.WinForms.ReportDataSource("idrDS", list_idr); // set the datasource
            reportViewer1.LocalReport.DataSources.Add(dataset_idr);
            dataset_idr.Value = list_idr;

            //IEnumerable<ReportParameter> parameters;
            //parameters.Aggregate(new ReportParameter("flag1", "False"));


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
            else
            {
                SqlConnector.sendMessage("Datos Faltantes/Inadecuados", "La grafica Categorias de Altura no puede mostrarse porque no tiene datos adecuados", MessageBoxIcon.Stop);
                return null;
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
            else
            {
                SqlConnector.sendMessage("Datos Faltantes/Inadecuados", "La grafica Categorias de Diametro no puede mostrarse porque no tiene datos adecuados", MessageBoxIcon.Stop);
                return null;
            }

            return list;
        }

        private List<No_Individuos> getNumeroIndividuos(int size = 5) // Mayor numero de individuos en el predio
        {
            List<No_Individuos> list = new List<No_Individuos>();

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

                for (int i = 0; i < size && i < aux.Count; i++)
                {
                    double ha = Convert.ToDouble(aux[i][1]) / 0.6;
                    double ha2 = Convert.ToDouble(aux[i][1]) / (0.6 / Convert.ToDouble(proyecto.getSuperficie()));
                    //chart1.Series.Add(new kawaii_lolis.Series("" + aux[i][0]));
                    //chart1.Series[i].Points.AddXY("" + aux[i][0], ha);

                    list.Add(
                        new No_Individuos
                        {
                            especie = aux[i][0],
                            no_individuos = Convert.ToInt32(aux[i][1]),
                            indidviduos_ha = Convert.ToDouble(ha.ToString("F4")),
                            individuos_scustf = Convert.ToDouble(ha2.ToString("F4"))
                        }
                    );
                    //dataGridView1.Rows.Add(aux[i][0], aux[i][1], ha.ToString("F4"), ha2.ToString("F4"));

                }
            }
            else
            {
                SqlConnector.sendMessage("Datos Faltantes/Inadecuados", "La grafica Numero de Individuos no puede mostrarse porque no tiene datos adecuados", MessageBoxIcon.Stop);
                return null;
            }

            return list;
        }

        private List<Area_Basal> getAreaBasal(int size = 5) // area basal por especie (m^2 / ha)
        {
            List<Area_Basal> list = new List<Area_Basal>();

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

                for (int i = 0; i < size && i < aux.Count; i++)
                {
                    double ha = Convert.ToDouble(aux[i][1]) / 0.6;
                    double ha2 = Convert.ToDouble(aux[i][1]) / (0.6 / Convert.ToDouble(proyecto.getSuperficie()));


                    //dataGridView1.Rows.Add(aux[i][0], aux[i][1], ha.ToString("F4"), ha2.ToString("F4"));

                    list.Add(
                        new Area_Basal
                        {
                            especie = aux[i][0],
                            suma_ab = Convert.ToDouble(aux[i][1]),
                            ab_ha = Convert.ToDouble(ha.ToString("F4")),
                            ab_ha2 = Convert.ToDouble(ha2.ToString("F4"))
                        }
                    );

                    //chart1.Series.Add(new kawaii_lolis.Series("" + aux[i][0]));
                    //chart1.Series[i].Points.AddXY("" + aux[i][0], ha);
                }
            }
            else
            {
                SqlConnector.sendMessage("Datos Faltantes/Inadecuados", "La grafica Area Basal no puede mostrarse porque no tiene datos adecuados", MessageBoxIcon.Stop);
                return null;
            }

            return list;
        }

        
        private List<IDR> getIDR()
        {
            List<IDR> list = new List<IDR>();

            list.Add(
                new IDR
                {
                    especie = "1",
                    ni = 1,
                    pi = 2,
                    ln_pi = 3,
                    shannon = 4,
                    simpson = 5
                }
            );

            list.Add(
                new IDR
                {
                    especie = "6",
                    ni = 7,
                    pi = 8,
                    ln_pi = 9,
                    shannon = 10,
                    simpson = 11
                }
            );
            return list;
        }
        

        private List<Volumen> getVolumen(int size = 5) // volumen por especie (m^3/ha)
        {
            List<Volumen> list = new List<Volumen>();

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

                for (int i = 0; i < size && i < aux.Count; i++)
                {
                    List<Object> lista_individuos = new List<Object>();
                    lista_individuos.Add(aux[i][0]);
                    lista_individuos.Add(aux[i][1]);

                    double ha = Convert.ToDouble(aux[i][1]) / 0.6;
                    double ha2 = Convert.ToDouble(aux[i][1]) / (0.6 / Convert.ToDouble(proyecto.getSuperficie()));

                    //dataGridView1.Rows.Add(aux[i][0], aux[i][1], ha.ToString("F4"), ha2.ToString("F4"));

                    list.Add(
                        new Volumen
                        {
                            especie = aux[i][0],
                            suma_volumen = Convert.ToDouble(aux[i][1]),
                            volumen_ha = Convert.ToDouble(ha.ToString("F4")),
                            volumen_ha2 = Convert.ToDouble(ha2.ToString("F4"))
                        }
                    );

                    //chart1.Series.Add(new kawaii_lolis.Series("" + aux[i][0]));
                    //chart1.Series[i].Points.AddXY("" + aux[i][0], ha);
                }
            }
            else
            {
                SqlConnector.sendMessage("Datos Faltantes/Inadecuados", "La grafica Volumen no puede mostrarse porque no tiene datos adecuados", MessageBoxIcon.Stop);
                return null;
            }

            return list;
        }

        private List<IVI2> getIVI(int area, int size = 5)
        {
            List<IVI2> list = new List<IVI2>();


            /////////////////////////// ARREGLAAAAAAAAAAAAAAAAAR ////////////////////////////////////////////

            //SqlConnector.sendOptionsMessage("Decision", "Diametro(Si) o Cobertura(No)", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);

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

                //dataGridView1.Rows.Add(lista_individuos[i], Convert.ToDouble(frec_abs[i].ToString("F4")), Convert.ToDouble(frec_rel[i].ToString("F4")), Convert.ToDouble(den_abs[i].ToString("F4")), Convert.ToDouble(den_rel[i].ToString("F4")), Convert.ToDouble(dom_abs[i].ToString("F5")), Convert.ToDouble(dom_rel[i].ToString("F4")), Convert.ToDouble(((frec_rel[i] + den_rel[i] + dom_rel[i])).ToString("F4")));

                list.Add(
                    new IVI2
                    {
                        nombrecientifico = lista_individuos[i].ToString(),
                        frec_abs = Convert.ToDouble(frec_abs[i].ToString("F4")),
                        frec_rel = Convert.ToDouble(frec_rel[i].ToString("F4")),
                        den_abs = Convert.ToDouble(den_abs[i].ToString("F4")),
                        den_rel = Convert.ToDouble(den_rel[i].ToString("F4")),
                        dom_abs = Convert.ToDouble(dom_abs[i].ToString("F5")),
                        dom_rel = Convert.ToDouble(dom_rel[i].ToString("F4")),
                        ivi = Convert.ToDouble(((frec_rel[i] + den_rel[i] + dom_rel[i])).ToString("F4"))
                    }
                );
            }
            List<IVI> list_ivis2 = list_ivis.OrderByDescending((x) => x.ivi).ToList();
            for (int i = 0; i < size && i < list_ivis2.Count; i++)
            {
                //chart1.Series["frecuencia"].Points.AddXY("" + list_ivis2[i].get_nombrecientifico(), Convert.ToDouble((list_ivis2[i].get_frec_rel())).ToString("F4"));
                //chart1.Series["densidad"].Points.AddXY("" + list_ivis2[i].get_nombrecientifico(), Convert.ToDouble((list_ivis2[i].get_den_rel())).ToString("F4"));
                //chart1.Series["dominancia"].Points.AddXY("" + list_ivis2[i].get_nombrecientifico(), Convert.ToDouble((list_ivis2[i].get_dom_rel())).ToString("F4"));
            }

            return list;
        }

        private List<IDR> getIDR(String area) //Indice Diversidad
        {
            List<IDR> list = new List<IDR>();

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

                    //dataGridView1.Rows.Add(aux2[0], aux2[1], pi, ln, shannon, simpson);
                    list.Add(
                        new IDR
                        {
                            especie = aux2[0],
                            ni = Convert.ToDouble(aux2[1]),
                            pi = pi,
                            ln_pi = ln,
                            shannon = shannon,
                            simpson = simpson,
                        }
                    );
                }
                i_shannon = Math.Abs(i_shannon);
                e_shannon = i_shannon / Math.Log(null_checker.Count);
                i_simpson = 1 - i_simpson;
                i_margalef = (null_checker.Count - 1) / Math.Log(Convert.ToDouble(aux[0]));

                //textBox1.Text = "" + i_shannon;
                //textBox2.Text = "" + e_shannon;
                //textBox3.Text = "" + i_simpson;
                //textBox4.Text = "" + i_margalef;                
            }
            else
            {
                SqlConnector.sendMessage("Datos Faltantes/Inadecuados", "La grafica no puede mostrarse porque no tiene datos adecuados", MessageBoxIcon.Stop);
                return null;
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

        private void buttonFiltrar_Click(object sender, EventArgs e)
        {
            parameters[0] = new ReportParameter("flag1", checkVolumen.Checked.ToString());
            parameters[1] = new ReportParameter("flag2", checkCAT.Checked.ToString());
            parameters[2] = new ReportParameter("flag3", checkCAD.Checked.ToString());
            parameters[3] = new ReportParameter("flag4", checkDyR.Checked.ToString());
            parameters[4] = new ReportParameter("flag5", checkAB.Checked.ToString());
            parameters[5] = new ReportParameter("flag6", checkIVI.Checked.ToString());
            this.reportViewer1.LocalReport.SetParameters(parameters);


            reportViewer1.LocalReport.Refresh();
            reportViewer1.RefreshReport();
        }
    }
}
