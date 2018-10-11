using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

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
            calculadoraEcuToFront(0, -1);
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
        public void calculadoraEcuToFront(int status, int proyecto_id)
        {
            calculadoraEcu.Initialize(status, proyecto_id);
            calculadoraEcu.BringToFront();
        }
        public void formEditarToFront(int proyecto_id)
        {
            formEditar.Initialize(proyecto_id);
            formEditar.BringToFront();
        }

    }
}
