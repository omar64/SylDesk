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
        }

        private void GenerarReporte_Load(object sender, EventArgs e)
        {

          

            this.reportViewer1.RefreshReport();            

            List<Cat> list = getCats();  //get list of students

            //reportViewer1.LocalReport.DataSources.Clear(); //clear report

            //reportViewer1.LocalReport.ReportEmbeddedResource = "Syldesk.ReporteFormato.rdlc"; // bind reportviewer with .rdlc

            Microsoft.Reporting.WinForms.ReportDataSource dataset = new Microsoft.Reporting.WinForms.ReportDataSource("catDS", list); // set the datasource

            reportViewer1.LocalReport.DataSources.Add(dataset);

            dataset.Value = list;

            reportViewer1.LocalReport.Refresh();

            reportViewer1.RefreshReport(); // refresh report
        }

        public static List<Cat> getCats()
        {

            List<Cat> list = new List<Cat>
            {
                new Cat
                {
                    cat = 2,
                    no_individuos = 102,
                },
                new Cat
                {
                    cat = 2,
                    no_individuos = 202,
                },
                new Cat
                {
                    cat = 3,
                    no_individuos = 302,
                },
            };
            return list;
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            form1.formRegistro2ToFront(proyecto);
        }
    }

    /// 
    ///  DASOMETRICOS
    /// 
    public class Cat
    {
        public int cat { get; set; }
        public int no_individuos { get; set; }
    }

    public class Cad
    {
        public int cad { get; set; }
        public int no_individuos { get; set; }
    }

    public class No_Individuos
    {
        public int no_individuos { get; set; }
        public int indidviduos_ha { get; set; }
        public int individuos_scustf { get; set; }
    }

    public class Area_Basal
    {
        public string especie { get; set; }
        public double suma_ab { get; set; }
        public double ab_ha { get; set; }
        public double ab_ha2 { get; set; }
    }

    public class Volumen
    {
        public string especie { get; set; }
        public double suma_volumen { get; set; }
        public double volumen_ha { get; set; }
        public double volumen_ha2 { get; set; }
    }
    ///
    /// IVI
    ///
    public class IVI2
    {
        public string nombrecientifico { get; set; }
        public double frec_abs { get; set; }
        public double frec_rel { get; set; }
        public double den_abs { get; set; }
        public double den_rel { get; set; }
        public double dom_abs { get; set; }
        public double dom_rel { get; set; }
        public double ivi { get; set; }
    }
    ///
    /// Diversidad y Riqueza
    ///
    public class IDR
    {
        public string especie { get; set; }
        public double ni { get; set; }
        public double pi { get; set; }
        public double ln_pi { get; set; }
        public double shannon { get; set; }
        public double simpson { get; set; }
    }
}
