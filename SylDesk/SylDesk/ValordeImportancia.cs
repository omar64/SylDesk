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
        //private int flag = 0;
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
        }
        public void Empty()
        {
            chart1.Series.Clear();
            chart1.Titles.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
        }




    }
}
