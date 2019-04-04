using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

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

            labelB.BackColor = Color.Transparent;
            labelB.Parent = SliderPic;


            labelTxt.BackColor = Color.Transparent;
            labelTxt.Parent = SliderPic;

            labelTxt2.BackColor = Color.Transparent;
            labelTxt2.Parent = SliderPic;

            labelS.BackColor = Color.Transparent;
            labelS.Parent = SliderPic;

            buttonIniciar.BackColor = Color.Transparent;
            buttonIniciar.Parent = SliderPic;

            

            

        }

        private void SliderPic_Paint(object sender, PaintEventArgs e)
        {
            
            e.Graphics.DrawImage(SliderPic.Image, 0, 0, SliderPic.ClientRectangle, GraphicsUnit.Pixel);

            Color top = Color.FromArgb(150, Color.Black);
            Color bottom = Color.FromArgb(150, Color.Black);
            LinearGradientMode direction = LinearGradientMode.Vertical;
            LinearGradientBrush brush = new LinearGradientBrush(SliderPic.ClientRectangle, top, bottom, direction);

            e.Graphics.FillRectangle(brush, SliderPic.ClientRectangle);
        }

        private void buttonIniciar_Click(object sender, EventArgs e)
        {
            

            form1.formRegistro3ToFront();
        }
    }
}
