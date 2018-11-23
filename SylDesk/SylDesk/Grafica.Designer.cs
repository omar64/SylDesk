namespace SylDesk
{
    partial class Grafica
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Grafica));
            this.label1 = new System.Windows.Forms.Label();
            this.button17 = new System.Windows.Forms.Button();
            this.ReportButton = new System.Windows.Forms.Button();
            this.TipBox = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.buttonDasom = new System.Windows.Forms.Button();
            this.buttonDR = new System.Windows.Forms.Button();
            this.buttonVI = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.TipBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(491, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Graficas";
            // 
            // button17
            // 
            this.button17.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button17.FlatAppearance.BorderSize = 0;
            this.button17.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCoral;
            this.button17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button17.Image = ((System.Drawing.Image)(resources.GetObject("button17.Image")));
            this.button17.Location = new System.Drawing.Point(3, 5);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(62, 47);
            this.button17.TabIndex = 74;
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // ReportButton
            // 
            this.ReportButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ReportButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.ReportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReportButton.ForeColor = System.Drawing.Color.DodgerBlue;
            this.ReportButton.Image = ((System.Drawing.Image)(resources.GetObject("ReportButton.Image")));
            this.ReportButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ReportButton.Location = new System.Drawing.Point(954, 40);
            this.ReportButton.Name = "ReportButton";
            this.ReportButton.Size = new System.Drawing.Size(124, 40);
            this.ReportButton.TabIndex = 94;
            this.ReportButton.Text = "Reporte";
            this.ReportButton.UseVisualStyleBackColor = true;
            this.ReportButton.Click += new System.EventHandler(this.ReportButton_Click);
            // 
            // TipBox
            // 
            this.TipBox.Cursor = System.Windows.Forms.Cursors.Help;
            this.TipBox.Image = ((System.Drawing.Image)(resources.GetObject("TipBox.Image")));
            this.TipBox.Location = new System.Drawing.Point(1052, 3);
            this.TipBox.Name = "TipBox";
            this.TipBox.Size = new System.Drawing.Size(23, 22);
            this.TipBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.TipBox.TabIndex = 106;
            this.TipBox.TabStop = false;
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 25000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ReshowDelay = 100;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Graficas";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(457, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(28, 27);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 110;
            this.pictureBox2.TabStop = false;
            // 
            // buttonDasom
            // 
            this.buttonDasom.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDasom.Location = new System.Drawing.Point(165, 123);
            this.buttonDasom.Name = "buttonDasom";
            this.buttonDasom.Size = new System.Drawing.Size(320, 147);
            this.buttonDasom.TabIndex = 111;
            this.buttonDasom.Text = "Dasometricos";
            this.buttonDasom.UseVisualStyleBackColor = true;
            this.buttonDasom.Click += new System.EventHandler(this.buttonDasom_Click);
            // 
            // buttonDR
            // 
            this.buttonDR.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDR.Location = new System.Drawing.Point(588, 123);
            this.buttonDR.Name = "buttonDR";
            this.buttonDR.Size = new System.Drawing.Size(294, 147);
            this.buttonDR.TabIndex = 112;
            this.buttonDR.Text = "Diversidad y Riqueza";
            this.buttonDR.UseVisualStyleBackColor = true;
            this.buttonDR.Click += new System.EventHandler(this.buttonDR_Click);
            // 
            // buttonVI
            // 
            this.buttonVI.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonVI.Location = new System.Drawing.Point(165, 329);
            this.buttonVI.Name = "buttonVI";
            this.buttonVI.Size = new System.Drawing.Size(311, 146);
            this.buttonVI.TabIndex = 113;
            this.buttonVI.Text = "Valor de Importancia";
            this.buttonVI.UseVisualStyleBackColor = true;
            this.buttonVI.Click += new System.EventHandler(this.buttonVI_Click);
            // 
            // Grafica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonVI);
            this.Controls.Add(this.buttonDR);
            this.Controls.Add(this.buttonDasom);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.TipBox);
            this.Controls.Add(this.ReportButton);
            this.Controls.Add(this.button17);
            this.Controls.Add(this.label1);
            this.Name = "Grafica";
            this.Size = new System.Drawing.Size(1096, 528);
            this.Load += new System.EventHandler(this.Grafica_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TipBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button ReportButton;
        private System.Windows.Forms.PictureBox TipBox;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button buttonDasom;
        private System.Windows.Forms.Button buttonDR;
        private System.Windows.Forms.Button buttonVI;
    }
}
