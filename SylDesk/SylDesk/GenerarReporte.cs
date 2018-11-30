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
        }

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            form1.formRegistro2ToFront(proyecto);
        }
    }
}
