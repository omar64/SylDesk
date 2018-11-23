using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using kawaii_lolis = System.Windows.Forms.DataVisualization.Charting;

namespace SylDesk
{
    public partial class Grafica : UserControl
    {
        private Proyecto proyecto;
        private Form1 form1;

        public Grafica()
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

        private void button17_Click(object sender, EventArgs e)
        {
            form1.formRegistro2ToFront(proyecto);
        }


        private void ReportButton_Click(object sender, EventArgs e)
        {
            form1.reportToFront();
        }

        private void Grafica_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(TipBox, "Lorem ipsum dolor sit amet consectetur adipiscing\n elit ornare, accumsan nec auctor morbi eget diam cubilia curae,\n justo nisl fringilla natoque sodales dignissim tristique.\n Massa morbi fringilla taciti pulvinar vel nascetur risus luctus eros,\n aliquam orci accumsan quam convallis id sociis lectus egestas, dui mattis aptent leo conubia arcu mi consequat.\n Dictumst senectus litora suscipit proin pretium mattis facilisi, montes posuere ut felis convallis\n dignissim eleifend luctus, praesent urna nullam ridiculus vitae enim.");
        }

        private void buttonDasom_Click(object sender, EventArgs e)
        {
            form1.dasometricosToFront(proyecto);
        }

        private void buttonDR_Click(object sender, EventArgs e)
        {
            form1.diversidadyriquezaToFront(proyecto);
        }

        private void buttonVI_Click(object sender, EventArgs e)
        {
            form1.valordeimportanciaToFront(proyecto);
        }
    }
}