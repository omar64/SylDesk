using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SylDesk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //formRegistro1ToFront();
            formInicialToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formRegistro1ToFront();
            //formRegistroEspecieToFront();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            formRegistro3ToFront();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            formRegistroEspecieToFront("");
        }
        private void button10_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        public void formRegistro1ToFront()
        {
            formRegistro11.Empty();
            formRegistro11.BringToFront();
        }
        public void formRegistro2ToFront(int proyecto_id)
        {
            formRegistro21.Initialize(proyecto_id);
            formRegistro21.BringToFront();
        }
        public void formRegistro3ToFront()
        {
            formRegistro31.Initialize();
            formRegistro31.BringToFront();
        }
        public void formRegistroEspecieToFront(String nombre)
        {
            formRegistroEspecie1.Initialize(nombre);
            formRegistroEspecie1.BringToFront();
        }
        public void formInicialToFront()
        {
            formInicial1.BringToFront();
        }
        public void graficaToFront(int proyecto_id)
        {
            grafica1.Initialize(proyecto_id);
            grafica1.BringToFront();
        }
       public void reportToFront()
        {
            
            report.InitializeLifetimeService();
            report.BringToFront();
        }
        
    }
}
