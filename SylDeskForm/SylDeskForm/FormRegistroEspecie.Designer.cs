namespace SylDeskForm
{
    partial class FormRegistroEspecie
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
            this.buttonRegistrar = new System.Windows.Forms.Button();
            this.labelEspecie = new System.Windows.Forms.Label();
            this.labelNombreComun = new System.Windows.Forms.Label();
            this.labelNombreCientifico = new System.Windows.Forms.Label();
            this.labelFamilia = new System.Windows.Forms.Label();
            this.textBoxEspecie = new System.Windows.Forms.TextBox();
            this.textBoxNombreComun = new System.Windows.Forms.TextBox();
            this.textBoxNombreCientifico = new System.Windows.Forms.TextBox();
            this.textBoxFamilia = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonRegistrar
            // 
            this.buttonRegistrar.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonRegistrar.Location = new System.Drawing.Point(579, 218);
            this.buttonRegistrar.Name = "buttonRegistrar";
            this.buttonRegistrar.Size = new System.Drawing.Size(75, 23);
            this.buttonRegistrar.TabIndex = 0;
            this.buttonRegistrar.Text = "Registrar";
            this.buttonRegistrar.UseVisualStyleBackColor = true;
            this.buttonRegistrar.Click += new System.EventHandler(this.buttonRegistrar_Click);
            // 
            // labelEspecie
            // 
            this.labelEspecie.AutoSize = true;
            this.labelEspecie.Location = new System.Drawing.Point(301, 50);
            this.labelEspecie.Name = "labelEspecie";
            this.labelEspecie.Size = new System.Drawing.Size(45, 13);
            this.labelEspecie.TabIndex = 1;
            this.labelEspecie.Text = "Especie";
            // 
            // labelNombreComun
            // 
            this.labelNombreComun.AutoSize = true;
            this.labelNombreComun.Location = new System.Drawing.Point(232, 132);
            this.labelNombreComun.Name = "labelNombreComun";
            this.labelNombreComun.Size = new System.Drawing.Size(80, 13);
            this.labelNombreComun.TabIndex = 2;
            this.labelNombreComun.Text = "Nombre Comun";
            // 
            // labelNombreCientifico
            // 
            this.labelNombreCientifico.AutoSize = true;
            this.labelNombreCientifico.Location = new System.Drawing.Point(284, 96);
            this.labelNombreCientifico.Name = "labelNombreCientifico";
            this.labelNombreCientifico.Size = new System.Drawing.Size(90, 13);
            this.labelNombreCientifico.TabIndex = 3;
            this.labelNombreCientifico.Text = "Nombre Cientifico";
            // 
            // labelFamilia
            // 
            this.labelFamilia.AutoSize = true;
            this.labelFamilia.Location = new System.Drawing.Point(319, 173);
            this.labelFamilia.Name = "labelFamilia";
            this.labelFamilia.Size = new System.Drawing.Size(39, 13);
            this.labelFamilia.TabIndex = 4;
            this.labelFamilia.Text = "Familia";
            // 
            // textBoxEspecie
            // 
            this.textBoxEspecie.Location = new System.Drawing.Point(363, 61);
            this.textBoxEspecie.Name = "textBoxEspecie";
            this.textBoxEspecie.Size = new System.Drawing.Size(100, 20);
            this.textBoxEspecie.TabIndex = 5;
            // 
            // textBoxNombreComun
            // 
            this.textBoxNombreComun.Location = new System.Drawing.Point(322, 129);
            this.textBoxNombreComun.Name = "textBoxNombreComun";
            this.textBoxNombreComun.Size = new System.Drawing.Size(100, 20);
            this.textBoxNombreComun.TabIndex = 6;
            // 
            // textBoxNombreCientifico
            // 
            this.textBoxNombreCientifico.Location = new System.Drawing.Point(386, 93);
            this.textBoxNombreCientifico.Name = "textBoxNombreCientifico";
            this.textBoxNombreCientifico.Size = new System.Drawing.Size(100, 20);
            this.textBoxNombreCientifico.TabIndex = 7;
            // 
            // textBoxFamilia
            // 
            this.textBoxFamilia.Location = new System.Drawing.Point(386, 186);
            this.textBoxFamilia.Name = "textBoxFamilia";
            this.textBoxFamilia.Size = new System.Drawing.Size(100, 20);
            this.textBoxFamilia.TabIndex = 8;
            // 
            // FormRegistroEspecie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 525);
            this.Controls.Add(this.textBoxFamilia);
            this.Controls.Add(this.textBoxNombreCientifico);
            this.Controls.Add(this.textBoxNombreComun);
            this.Controls.Add(this.textBoxEspecie);
            this.Controls.Add(this.labelFamilia);
            this.Controls.Add(this.labelNombreCientifico);
            this.Controls.Add(this.labelNombreComun);
            this.Controls.Add(this.labelEspecie);
            this.Controls.Add(this.buttonRegistrar);
            this.Name = "FormRegistroEspecie";
            this.Text = "FormRegistroEspecie";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonRegistrar;
        private System.Windows.Forms.Label labelEspecie;
        private System.Windows.Forms.Label labelNombreComun;
        private System.Windows.Forms.Label labelNombreCientifico;
        private System.Windows.Forms.Label labelFamilia;
        private System.Windows.Forms.TextBox textBoxEspecie;
        private System.Windows.Forms.TextBox textBoxNombreComun;
        private System.Windows.Forms.TextBox textBoxNombreCientifico;
        private System.Windows.Forms.TextBox textBoxFamilia;
    }
}