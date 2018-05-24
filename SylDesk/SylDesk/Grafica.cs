using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SylDesk
{
    public partial class Grafica : UserControl
    {
        Form1 form1;
        public Grafica(Form1 form1)
        {
            this.form1 = form1;
            InitializeComponent();
        }

        private void Grafica_Load(object sender, EventArgs e)
        {
            chart1.Series["Volumen"].Points.AddXY("Arbol", 1000);
            chart1.Series["Volumen"].Points.AddXY("Rama", 100);
            chart1.Series["Volumen"].Points.AddXY("Arbusto", 400);
            chart1.Series["Volumen"].Points.AddXY("Cactus", 2000);
            chart1.Series["Volumen"].Points.AddXY("Ardilla", 300);
            chart1.Series["Volumen"].Points.AddXY("Pepino", 450);
            chart1.Series["Volumen"].Points.AddXY("Ceiba", 100);
            chart1.Series["Volumen"].Points.AddXY("Espinas", 500);


            chartPie.Series["VolumenPie"].Points.AddXY("Arbol", 1000);
            chartPie.Series["VolumenPie"].Points.AddXY("Rama", 100);
            chartPie.Series["VolumenPie"].Points.AddXY("Arbusto", 400);
            chartPie.Series["VolumenPie"].Points.AddXY("Cactus", 2000);
            chartPie.Series["VolumenPie"].Points.AddXY("Ardilla", 300);
            chartPie.Series["VolumenPie"].Points.AddXY("Pepino", 450);
            chartPie.Series["VolumenPie"].Points.AddXY("Ceiba", 100);
            chartPie.Series["VolumenPie"].Points.AddXY("Espinas", 500);
        }
    }
}
