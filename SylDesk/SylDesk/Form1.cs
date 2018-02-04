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
            formRegistro11.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formRegistroEspecie1.BringToFront();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            formRegistro31.BringToFront();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
