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
            this.labelNombreCientifico = new System.Windows.Forms.Label();
            this.labelNombreComun = new System.Windows.Forms.Label();
            this.labelFamilia = new System.Windows.Forms.Label();
            this.textBoxEspecie = new System.Windows.Forms.TextBox();
            this.textBoxNombreCientifico = new System.Windows.Forms.TextBox();
            this.textBoxNombreComun = new System.Windows.Forms.TextBox();
            this.textBoxFamilia = new System.Windows.Forms.TextBox();
            this.dataGridViewEspecies = new System.Windows.Forms.DataGridView();
            this.especie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombrecientifico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombrecomun = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.familia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.borrar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.labelBuscarEspecie = new System.Windows.Forms.Label();
            this.textBoxBuscarEspecie = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEspecies)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonRegistrar
            // 
            this.buttonRegistrar.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonRegistrar.Location = new System.Drawing.Point(490, 111);
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
            this.labelEspecie.Location = new System.Drawing.Point(301, 29);
            this.labelEspecie.Name = "labelEspecie";
            this.labelEspecie.Size = new System.Drawing.Size(45, 13);
            this.labelEspecie.TabIndex = 1;
            this.labelEspecie.Text = "Especie";
            // 
            // labelNombreCientifico
            // 
            this.labelNombreCientifico.AutoSize = true;
            this.labelNombreCientifico.Location = new System.Drawing.Point(278, 58);
            this.labelNombreCientifico.Name = "labelNombreCientifico";
            this.labelNombreCientifico.Size = new System.Drawing.Size(80, 13);
            this.labelNombreCientifico.TabIndex = 2;
            this.labelNombreCientifico.Text = "Nombre Comun";
            // 
            // labelNombreComun
            // 
            this.labelNombreComun.AutoSize = true;
            this.labelNombreComun.Location = new System.Drawing.Point(266, 85);
            this.labelNombreComun.Name = "labelNombreComun";
            this.labelNombreComun.Size = new System.Drawing.Size(80, 13);
            this.labelNombreComun.TabIndex = 3;
            this.labelNombreComun.Text = "Nombre Comun";
            // 
            // labelFamilia
            // 
            this.labelFamilia.AutoSize = true;
            this.labelFamilia.Location = new System.Drawing.Point(278, 111);
            this.labelFamilia.Name = "labelFamilia";
            this.labelFamilia.Size = new System.Drawing.Size(39, 13);
            this.labelFamilia.TabIndex = 4;
            this.labelFamilia.Text = "Familia";
            // 
            // textBoxEspecie
            // 
            this.textBoxEspecie.Location = new System.Drawing.Point(363, 29);
            this.textBoxEspecie.Name = "textBoxEspecie";
            this.textBoxEspecie.Size = new System.Drawing.Size(100, 20);
            this.textBoxEspecie.TabIndex = 5;
            // 
            // textBoxNombreCientifico
            // 
            this.textBoxNombreCientifico.Location = new System.Drawing.Point(363, 58);
            this.textBoxNombreCientifico.Name = "textBoxNombreCientifico";
            this.textBoxNombreCientifico.Size = new System.Drawing.Size(100, 20);
            this.textBoxNombreCientifico.TabIndex = 6;
            // 
            // textBoxNombreComun
            // 
            this.textBoxNombreComun.Location = new System.Drawing.Point(352, 85);
            this.textBoxNombreComun.Name = "textBoxNombreComun";
            this.textBoxNombreComun.Size = new System.Drawing.Size(100, 20);
            this.textBoxNombreComun.TabIndex = 7;
            // 
            // textBoxFamilia
            // 
            this.textBoxFamilia.Location = new System.Drawing.Point(323, 111);
            this.textBoxFamilia.Name = "textBoxFamilia";
            this.textBoxFamilia.Size = new System.Drawing.Size(100, 20);
            this.textBoxFamilia.TabIndex = 8;
            // 
            // dataGridViewEspecies
            // 
            this.dataGridViewEspecies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEspecies.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.especie,
            this.nombrecientifico,
            this.nombrecomun,
            this.familia,
            this.borrar});
            this.dataGridViewEspecies.Location = new System.Drawing.Point(36, 166);
            this.dataGridViewEspecies.Name = "dataGridViewEspecies";
            this.dataGridViewEspecies.Size = new System.Drawing.Size(663, 150);
            this.dataGridViewEspecies.TabIndex = 9;
            // 
            // especie
            // 
            this.especie.HeaderText = "Especie";
            this.especie.Name = "especie";
            // 
            // nombrecientifico
            // 
            this.nombrecientifico.HeaderText = "Nombre Cientifico";
            this.nombrecientifico.Name = "nombrecientifico";
            // 
            // nombrecomun
            // 
            this.nombrecomun.HeaderText = "Nombre Cientifico";
            this.nombrecomun.Name = "nombrecomun";
            // 
            // familia
            // 
            this.familia.HeaderText = "Familia";
            this.familia.Name = "familia";
            // 
            // borrar
            // 
            this.borrar.HeaderText = "Borrar";
            this.borrar.Name = "borrar";
            // 
            // labelBuscarEspecie
            // 
            this.labelBuscarEspecie.AutoSize = true;
            this.labelBuscarEspecie.Location = new System.Drawing.Point(83, 150);
            this.labelBuscarEspecie.Name = "labelBuscarEspecie";
            this.labelBuscarEspecie.Size = new System.Drawing.Size(81, 13);
            this.labelBuscarEspecie.TabIndex = 10;
            this.labelBuscarEspecie.Text = "Buscar Especie";
            // 
            // textBoxBuscarEspecie
            // 
            this.textBoxBuscarEspecie.Location = new System.Drawing.Point(170, 143);
            this.textBoxBuscarEspecie.Name = "textBoxBuscarEspecie";
            this.textBoxBuscarEspecie.Size = new System.Drawing.Size(100, 20);
            this.textBoxBuscarEspecie.TabIndex = 11;
            this.textBoxBuscarEspecie.TextChanged += new System.EventHandler(this.textBoxBuscarEspecie_TextChanged);
            // 
            // FormRegistroEspecie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 525);
            this.Controls.Add(this.textBoxBuscarEspecie);
            this.Controls.Add(this.labelBuscarEspecie);
            this.Controls.Add(this.dataGridViewEspecies);
            this.Controls.Add(this.textBoxFamilia);
            this.Controls.Add(this.textBoxNombreComun);
            this.Controls.Add(this.textBoxNombreCientifico);
            this.Controls.Add(this.textBoxEspecie);
            this.Controls.Add(this.labelFamilia);
            this.Controls.Add(this.labelNombreComun);
            this.Controls.Add(this.labelNombreCientifico);
            this.Controls.Add(this.labelEspecie);
            this.Controls.Add(this.buttonRegistrar);
            this.Name = "FormRegistroEspecie";
            this.Text = "FormRegistroEspecie";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEspecies)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonRegistrar;
        private System.Windows.Forms.Label labelEspecie;
        private System.Windows.Forms.Label labelNombreCientifico;
        private System.Windows.Forms.Label labelNombreComun;
        private System.Windows.Forms.Label labelFamilia;
        private System.Windows.Forms.TextBox textBoxEspecie;
        private System.Windows.Forms.TextBox textBoxNombreCientifico;
        private System.Windows.Forms.TextBox textBoxNombreComun;
        private System.Windows.Forms.TextBox textBoxFamilia;
        private System.Windows.Forms.DataGridView dataGridViewEspecies;
        private System.Windows.Forms.DataGridViewTextBoxColumn especie;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombrecientifico;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombrecomun;
        private System.Windows.Forms.DataGridViewTextBoxColumn familia;
        private System.Windows.Forms.DataGridViewButtonColumn borrar;
        private System.Windows.Forms.Label labelBuscarEspecie;
        private System.Windows.Forms.TextBox textBoxBuscarEspecie;
    }
}