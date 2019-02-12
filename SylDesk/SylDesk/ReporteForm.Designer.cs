namespace SylDesk
{
    partial class ReporteForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReporteForm));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkIVI = new System.Windows.Forms.CheckBox();
            this.buttonFiltrar = new System.Windows.Forms.Button();
            this.checkAB = new System.Windows.Forms.CheckBox();
            this.checkDyR = new System.Windows.Forms.CheckBox();
            this.checkCAD = new System.Windows.Forms.CheckBox();
            this.checkVolumen = new System.Windows.Forms.CheckBox();
            this.checkCAT = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "SylDesk.ReporteFormato.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(5, 29);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1034, 470);
            this.reportViewer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkIVI);
            this.groupBox1.Controls.Add(this.buttonFiltrar);
            this.groupBox1.Controls.Add(this.checkAB);
            this.groupBox1.Controls.Add(this.checkDyR);
            this.groupBox1.Controls.Add(this.checkCAD);
            this.groupBox1.Controls.Add(this.checkVolumen);
            this.groupBox1.Controls.Add(this.checkCAT);
            this.groupBox1.Location = new System.Drawing.Point(1042, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(139, 475);
            this.groupBox1.TabIndex = 124;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro";
            // 
            // checkIVI
            // 
            this.checkIVI.AutoSize = true;
            this.checkIVI.Location = new System.Drawing.Point(6, 138);
            this.checkIVI.Name = "checkIVI";
            this.checkIVI.Size = new System.Drawing.Size(45, 17);
            this.checkIVI.TabIndex = 128;
            this.checkIVI.Text = "I.V.I";
            this.checkIVI.UseVisualStyleBackColor = true;
            // 
            // buttonFiltrar
            // 
            this.buttonFiltrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFiltrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFiltrar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.buttonFiltrar.Image = ((System.Drawing.Image)(resources.GetObject("buttonFiltrar.Image")));
            this.buttonFiltrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonFiltrar.Location = new System.Drawing.Point(2, 423);
            this.buttonFiltrar.Name = "buttonFiltrar";
            this.buttonFiltrar.Size = new System.Drawing.Size(136, 46);
            this.buttonFiltrar.TabIndex = 119;
            this.buttonFiltrar.Text = "Filtrar";
            this.buttonFiltrar.UseVisualStyleBackColor = true;
            this.buttonFiltrar.Click += new System.EventHandler(this.buttonFiltrar_Click);
            // 
            // checkAB
            // 
            this.checkAB.AutoSize = true;
            this.checkAB.Location = new System.Drawing.Point(6, 115);
            this.checkAB.Name = "checkAB";
            this.checkAB.Size = new System.Drawing.Size(74, 17);
            this.checkAB.TabIndex = 127;
            this.checkAB.Text = "AreaBasal";
            this.checkAB.UseVisualStyleBackColor = true;
            // 
            // checkDyR
            // 
            this.checkDyR.AutoSize = true;
            this.checkDyR.Location = new System.Drawing.Point(6, 92);
            this.checkDyR.Name = "checkDyR";
            this.checkDyR.Size = new System.Drawing.Size(131, 17);
            this.checkDyR.TabIndex = 126;
            this.checkDyR.Text = "Diversisdad y Riqueza";
            this.checkDyR.UseVisualStyleBackColor = true;
            // 
            // checkCAD
            // 
            this.checkCAD.AutoSize = true;
            this.checkCAD.Location = new System.Drawing.Point(6, 46);
            this.checkCAD.Name = "checkCAD";
            this.checkCAD.Size = new System.Drawing.Size(131, 17);
            this.checkCAD.TabIndex = 125;
            this.checkCAD.Text = "Categoria de Diametro";
            this.checkCAD.UseVisualStyleBackColor = true;
            // 
            // checkVolumen
            // 
            this.checkVolumen.AutoSize = true;
            this.checkVolumen.Location = new System.Drawing.Point(6, 69);
            this.checkVolumen.Name = "checkVolumen";
            this.checkVolumen.Size = new System.Drawing.Size(67, 17);
            this.checkVolumen.TabIndex = 124;
            this.checkVolumen.Text = "Volumen";
            this.checkVolumen.UseVisualStyleBackColor = true;
            // 
            // checkCAT
            // 
            this.checkCAT.AutoSize = true;
            this.checkCAT.Location = new System.Drawing.Point(6, 23);
            this.checkCAT.Name = "checkCAT";
            this.checkCAT.Size = new System.Drawing.Size(116, 17);
            this.checkCAT.TabIndex = 123;
            this.checkCAT.Text = "Categoria de Altura";
            this.checkCAT.UseVisualStyleBackColor = true;
            // 
            // ReporteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 506);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReporteForm";
            this.Text = "ReporteForm";
            this.Load += new System.EventHandler(this.ReporteForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkIVI;
        private System.Windows.Forms.Button buttonFiltrar;
        private System.Windows.Forms.CheckBox checkAB;
        private System.Windows.Forms.CheckBox checkDyR;
        private System.Windows.Forms.CheckBox checkCAD;
        private System.Windows.Forms.CheckBox checkVolumen;
        private System.Windows.Forms.CheckBox checkCAT;
    }
}