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
            ((System.ComponentModel.ISupportInitialize)(this.SliderPic)).BeginInit();
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
            this.SliderPic.Location = new System.Drawing.Point(18, 59);
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
            this.buttonIniciar.Location = new System.Drawing.Point(444, 256);
            this.buttonIniciar.Name = "buttonIniciar";
            this.buttonIniciar.Size = new System.Drawing.Size(226, 56);
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
            this.labelB.Font = new System.Drawing.Font("Arial", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelB.ForeColor = System.Drawing.Color.White;
            this.labelB.Location = new System.Drawing.Point(366, 95);
            this.labelB.Name = "labelB";
            this.labelB.Size = new System.Drawing.Size(228, 41);
            this.labelB.TabIndex = 15;
            this.labelB.Text = "Bienvenido a";
            // 
            // labelTxt
            // 
            this.labelTxt.AutoSize = true;
            this.labelTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(119)))), ((int)(((byte)(119)))));
            this.labelTxt.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTxt.ForeColor = System.Drawing.Color.White;
            this.labelTxt.Location = new System.Drawing.Point(62, 163);
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
            this.labelS.Font = new System.Drawing.Font("Cambria", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelS.ForeColor = System.Drawing.Color.Lime;
            this.labelS.Location = new System.Drawing.Point(585, 93);
            this.labelS.Name = "labelS";
            this.labelS.Size = new System.Drawing.Size(153, 43);
            this.labelS.TabIndex = 17;
            this.labelS.Text = "SylDesk";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(32, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(3, 366);
            this.panel1.TabIndex = 18;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(32, 438);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1034, 3);
            this.panel2.TabIndex = 19;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(1066, 75);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(3, 366);
            this.panel3.TabIndex = 19;
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(35, 75);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1034, 3);
            this.panel4.TabIndex = 20;
            // 
            // FormInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
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
    }
}
