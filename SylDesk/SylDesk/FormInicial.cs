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
    public partial class FormInicial : UserControl
    {
        Form1 form1;

        public FormInicial()
        {
            InitializeComponent();

            
        }

        public void setForm(Form1 form1)
        {
            this.form1 = form1;
        }

        /*private void button1_Click(object sender, EventArgs e)
        {
            form1.formRegistro3ToFront();
        }*/

        private int imageNumber = 1;

        private void LoadNextImage()
        {
            if(imageNumber == 4)
            {
                imageNumber = 1;
            }
            SliderPic.ImageLocation = string.Format(@"..\..\..\Images\{0}.jpg", imageNumber);
            imageNumber++;

            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LoadNextImage();
        }

        

        private void FormInicial_Load(object sender, EventArgs e)
        {
            //panel2.BackColor = Color.FromArgb(180,0,0,0);
            //pictureBox1.BackColor = Color.FromArgb(180,0,0,0);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            form1.formRegistro3ToFront();
        }
    }
}
