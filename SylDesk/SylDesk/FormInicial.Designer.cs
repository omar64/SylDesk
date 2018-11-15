namespace SylDesk
{
    partial class FormInicial
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInicial));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SliderPic = new System.Windows.Forms.PictureBox();
            this.buttonIniciar = new System.Windows.Forms.Button();
            this.labelB = new System.Windows.Forms.Label();
            this.labelTxt = new System.Windows.Forms.Label();
            this.labelS = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SliderPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 4000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // SliderPic
            // 
            this.SliderPic.Image = ((System.Drawing.Image)(resources.GetObject("SliderPic.Image")));
            this.SliderPic.Location = new System.Drawing.Point(18, 37);
            this.SliderPic.Name = "SliderPic";
            this.SliderPic.Size = new System.Drawing.Size(1062, 403);
            this.SliderPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SliderPic.TabIndex = 13;
            this.SliderPic.TabStop = false;
            this.SliderPic.Paint += new System.Windows.Forms.PaintEventHandler(this.SliderPic_Paint);
            // 
            // buttonIniciar
            // 
            this.buttonIniciar.BackColor = System.Drawing.Color.LightGreen;
            this.buttonIniciar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonIniciar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LimeGreen;
            this.buttonIniciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonIniciar.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonIniciar.ForeColor = System.Drawing.Color.White;
            this.buttonIniciar.Image = ((System.Drawing.Image)(resources.GetObject("buttonIniciar.Image")));
            this.buttonIniciar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonIniciar.Location = new System.Drawing.Point(429, 249);
            this.buttonIniciar.Name = "buttonIniciar";
            this.buttonIniciar.Size = new System.Drawing.Size(275, 56);
            this.buttonIniciar.TabIndex = 14;
            this.buttonIniciar.Text = "Iniciar Proyectos";
            this.buttonIniciar.UseVisualStyleBackColor = false;
            this.buttonIniciar.Click += new System.EventHandler(this.buttonIniciar_Click);
            // 
            // labelB
            // 
            this.labelB.AutoSize = true;
            this.labelB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(119)))), ((int)(((byte)(119)))));
            this.labelB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelB.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelB.ForeColor = System.Drawing.Color.White;
            this.labelB.Location = new System.Drawing.Point(302, 68);
            this.labelB.Name = "labelB";
            this.labelB.Size = new System.Drawing.Size(322, 56);
            this.labelB.TabIndex = 15;
            this.labelB.Text = "Bienvenido a";
            // 
            // labelTxt
            // 
            this.labelTxt.AutoSize = true;
            this.labelTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(119)))), ((int)(((byte)(119)))));
            this.labelTxt.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTxt.ForeColor = System.Drawing.Color.White;
            this.labelTxt.Location = new System.Drawing.Point(62, 141);
            this.labelTxt.Name = "labelTxt";
            this.labelTxt.Size = new System.Drawing.Size(984, 29);
            this.labelTxt.TabIndex = 16;
            this.labelTxt.Text = "SylDesk es una aplicación que permite al usuario el manejo de proyectos forestale" +
    "s. ";
            this.labelTxt.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelS
            // 
            this.labelS.AutoSize = true;
            this.labelS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(119)))), ((int)(((byte)(119)))));
            this.labelS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelS.Font = new System.Drawing.Font("Cambria", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelS.ForeColor = System.Drawing.Color.Lime;
            this.labelS.Location = new System.Drawing.Point(617, 67);
            this.labelS.Name = "labelS";
            this.labelS.Size = new System.Drawing.Size(197, 57);
            this.labelS.TabIndex = 17;
            this.labelS.Text = "SylDesk";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(32, 53);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(3, 366);
            this.panel1.TabIndex = 18;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(32, 416);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1034, 3);
            this.panel2.TabIndex = 19;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(1066, 53);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(3, 366);
            this.panel3.TabIndex = 19;
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(35, 53);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1034, 3);
            this.panel4.TabIndex = 20;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(566, 447);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(43, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(243, 447);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(43, 43);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 22;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(863, 447);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(43, 43);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 23;
            this.pictureBox3.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(190, 496);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 16);
            this.label1.TabIndex = 24;
            this.label1.Text = "Creación de Proyectos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(521, 497);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(139, 16);
            this.label2.TabIndex = 25;
            this.label2.Text = "Registro de Especies";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(803, 497);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 16);
            this.label3.TabIndex = 26;
            this.label3.Text = "Generación de Reportes";
            // 
            // FormInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelS);
            this.Controls.Add(this.labelTxt);
            this.Controls.Add(this.labelB);
            this.Controls.Add(this.buttonIniciar);
            this.Controls.Add(this.SliderPic);
            this.Name = "FormInicial";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Size = new System.Drawing.Size(1096, 528);
            this.Load += new System.EventHandler(this.FormInicial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SliderPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox SliderPic;
        private System.Windows.Forms.Button buttonIniciar;
        private System.Windows.Forms.Label labelB;
        private System.Windows.Forms.Label labelTxt;
        private System.Windows.Forms.Label labelS;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
