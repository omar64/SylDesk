using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SylDeskForm
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        int mouseX = 0, mouseY = 0;
        bool mouseDown;

        private void label5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 obj = new Form2(); //objeto declarado para abrir el form2


            this.Hide(); //esconde el form actual

            obj.Show(); //abre el form declarado con el objeto

            
        }

        private void label5_MouseHover(object sender, EventArgs e)
        {
            this.label5.ForeColor=Color.Red;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            this.label5.ForeColor = Color.Transparent;
        }

        private void label6_MouseHover(object sender, EventArgs e)
        {
            this.label6.ForeColor = Color.Gray;
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                mouseX = MousePosition.X - 400;
                mouseY = MousePosition.Y - 40;

                this.SetDesktopLocation(mouseX, mouseY);
            }
        }

        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void label6_MouseLeave(object sender, EventArgs e)
        {
            this.label6.ForeColor = Color.Transparent;
        }
    }
}
