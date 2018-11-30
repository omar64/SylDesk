using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

namespace SylDesk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            // hilo de inicializacion el formLoading
            Thread t = new Thread(new ThreadStart(StartForm));
            t.Start();
            Thread.Sleep(2000);

            InitializeComponent();

            t.Abort(); // se utiliza para terminar el hilo y dejar al form principal comenzar

            this.formRegistro1.setForm(this);
            this.formRegistro2.setForm(this);
            this.formRegistro3.setForm(this);
            this.formRegistroEspecie.setForm(this);
            this.formInicial.setForm(this);
            this.grafica.setForm(this);
            //this.report.setForm(this);
            this.generarreporte.setForm(this);
            this.calculadoraEcu.setForm(this);
            this.formEditar.setForm(this);
            this.dasometricos.setForm(this);
            this.diversidadyRiqueza.setForm(this);
            this.valordeImportancia.setForm(this);

            

          


            SidePanel1.Hide();
            SidePanel2.Hide();
            SidePanel3.Hide();
            SidePanel4.Hide();

            formInicialToFront();
            this.Show();
            this.Activate();
            this.TopMost = true;
            this.TopMost = false;
            this.Focus();
            
            
            
        }

        //permite inicializar el form loading
        public void StartForm()
        {
            Application.Run(new LoadingForm());
        }

        //########  minimizar y maximizar desde la barra de tareas  #######\\

        const int WS_MINIMIZEDBOX = 0x20000;
        const int CS_DBLCLKS = 0X8;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= WS_MINIMIZEDBOX;
                cp.ClassStyle |= CS_DBLCLKS;
                return cp;
            }
        } 
        // Side panel para seleccionar el boton seleccionado 


        private void button1_Click(object sender, EventArgs e)
        {

            SidePanel2.Hide();
            SidePanel3.Hide();
            SidePanel4.Hide();

            SidePanel1.Show();           

            formRegistro1ToFront();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            SidePanel1.Hide();
            SidePanel3.Hide();
            SidePanel4.Hide();

            SidePanel2.Show();

            formRegistro3ToFront();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            formRegistroEspecieToFront(null, 0, "");
            SidePanel1.Hide();
            SidePanel2.Hide();
            SidePanel4.Hide();

            SidePanel3.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        
        private void button11_Click(object sender, EventArgs e)
        {
            if (WindowState.ToString() == "Normal")
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
            
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            calculadoraEcuToFront(null, 0, "");
            SidePanel1.Hide();
            SidePanel2.Hide();
            SidePanel3.Hide();

            SidePanel4.Show();
        }


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }



        public void formRegistro1ToFront()
        {
            formRegistro1.Empty();
            formRegistro1.BringToFront();
        }
        
        public void formRegistro2ToFront(Proyecto proyecto)
        {
            formRegistro2.Initialize(proyecto);
            formRegistro2.BringToFront();
        }
        public void formRegistro3ToFront()
        {
            formRegistro3.Initialize();
            formRegistro3.BringToFront();
        }
        public void formRegistroEspecieToFront(Proyecto proyecto, int status, String nombre)
        {
            formRegistroEspecie.Initialize(proyecto, status, nombre);
            formRegistroEspecie.BringToFront();
        }
        public void formInicialToFront()
        {
            formInicial.BringToFront();
        }
        public void graficaToFront(Proyecto proyecto)
        {
            grafica.Initialize(proyecto);
            grafica.BringToFront();
        }
        /*public void reportToFront()
        {            
            report.InitializeLifetimeService();
            report.BringToFront();
        }*/
        
        public void generarreporteToFront(Proyecto proyecto)
        {
            generarreporte.Initialize(proyecto);
            
            generarreporte.BringToFront();
        }

        public void calculadoraEcuToFront(Proyecto proyecto , int status, String especie)
        {
            calculadoraEcu.Initialize(proyecto, status, especie);
            calculadoraEcu.BringToFront();
        }
        public void formEditarToFront(Proyecto proyecto)
        {
            formEditar.Initialize(proyecto);
            formEditar.BringToFront();
        }
        public void dasometricosToFront(Proyecto proyecto)
        {
            dasometricos.Initialize(proyecto);
            dasometricos.BringToFront();
        }
        public void diversidadyriquezaToFront(Proyecto proyecto)
        {
            diversidadyRiqueza.Initialize(proyecto);
            diversidadyRiqueza.BringToFront();
        }
        public void valordeimportanciaToFront(Proyecto proyecto)
        {
            valordeImportancia.Initialize(proyecto);
            valordeImportancia.BringToFront();
        }


        

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            formInicial.BringToFront();
        }
    }
}
