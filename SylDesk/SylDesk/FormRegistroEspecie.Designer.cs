namespace SylDesk
{
    partial class FormRegistroEspecie
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegistroEspecie));
            this.textBoxCategoriaDeNorma = new System.Windows.Forms.TextBox();
            this.textBoxGenero = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxFormaDeVida = new System.Windows.Forms.TextBox();
            this.textBoxBuscarEspecie = new System.Windows.Forms.TextBox();
            this.labelBuscarEspecie = new System.Windows.Forms.Label();
            this.dataGridViewEspecies = new System.Windows.Forms.DataGridView();
            this.familia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.genero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombrecientifico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombrecomun = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formadevida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoriadelanorma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.borrar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.textBoxFamilia = new System.Windows.Forms.TextBox();
            this.textBoxNombreComun = new System.Windows.Forms.TextBox();
            this.textBoxNombreCientifico = new System.Windows.Forms.TextBox();
            this.labelFamilia = new System.Windows.Forms.Label();
            this.labelNombreComun = new System.Windows.Forms.Label();
            this.labelNombreCientifico = new System.Windows.Forms.Label();
            this.buttonRegistrar = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEspecies)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxCategoriaDeNorma
            // 
            this.textBoxCategoriaDeNorma.Location = new System.Drawing.Point(648, 134);
            this.textBoxCategoriaDeNorma.Name = "textBoxCategoriaDeNorma";
            this.textBoxCategoriaDeNorma.Size = new System.Drawing.Size(234, 20);
            this.textBoxCategoriaDeNorma.TabIndex = 87;
            // 
            // textBoxGenero
            // 
            this.textBoxGenero.Location = new System.Drawing.Point(237, 101);
            this.textBoxGenero.Name = "textBoxGenero";
            this.textBoxGenero.Size = new System.Drawing.Size(234, 20);
            this.textBoxGenero.TabIndex = 86;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(507, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 15);
            this.label6.TabIndex = 85;
            this.label6.Text = "Categoria de la Norma:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(180, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 15);
            this.label5.TabIndex = 84;
            this.label5.Text = "Genero:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(552, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 15);
            this.label4.TabIndex = 83;
            this.label4.Text = "Forma de Vida:";
            // 
            // textBoxFormaDeVida
            // 
            this.textBoxFormaDeVida.Location = new System.Drawing.Point(648, 101);
            this.textBoxFormaDeVida.Name = "textBoxFormaDeVida";
            this.textBoxFormaDeVida.Size = new System.Drawing.Size(234, 20);
            this.textBoxFormaDeVida.TabIndex = 82;
            // 
            // textBoxBuscarEspecie
            // 
            this.textBoxBuscarEspecie.Location = new System.Drawing.Point(367, 235);
            this.textBoxBuscarEspecie.Name = "textBoxBuscarEspecie";
            this.textBoxBuscarEspecie.Size = new System.Drawing.Size(189, 20);
            this.textBoxBuscarEspecie.TabIndex = 81;
            // 
            // labelBuscarEspecie
            // 
            this.labelBuscarEspecie.AutoSize = true;
            this.labelBuscarEspecie.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBuscarEspecie.Location = new System.Drawing.Point(264, 237);
            this.labelBuscarEspecie.Name = "labelBuscarEspecie";
            this.labelBuscarEspecie.Size = new System.Drawing.Size(97, 15);
            this.labelBuscarEspecie.TabIndex = 80;
            this.labelBuscarEspecie.Text = "Buscar Especie:";
            // 
            // dataGridViewEspecies
            // 
            this.dataGridViewEspecies.AllowUserToAddRows = false;
            this.dataGridViewEspecies.AllowUserToDeleteRows = false;
            this.dataGridViewEspecies.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewEspecies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewEspecies.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.familia,
            this.genero,
            this.nombrecientifico,
            this.nombrecomun,
            this.formadevida,
            this.categoriadelanorma,
            this.borrar});
            this.dataGridViewEspecies.Location = new System.Drawing.Point(47, 286);
            this.dataGridViewEspecies.Name = "dataGridViewEspecies";
            this.dataGridViewEspecies.Size = new System.Drawing.Size(1011, 225);
            this.dataGridViewEspecies.TabIndex = 79;
            // 
            // familia
            // 
            this.familia.HeaderText = "Familia";
            this.familia.Name = "familia";
            // 
            // genero
            // 
            this.genero.HeaderText = "Genero";
            this.genero.Name = "genero";
            // 
            // nombrecientifico
            // 
            this.nombrecientifico.HeaderText = "Nombre Cientifico";
            this.nombrecientifico.Name = "nombrecientifico";
            // 
            // nombrecomun
            // 
            this.nombrecomun.HeaderText = "Nombre Comun";
            this.nombrecomun.Name = "nombrecomun";
            // 
            // formadevida
            // 
            this.formadevida.HeaderText = "Forma de Vida";
            this.formadevida.Name = "formadevida";
            // 
            // categoriadelanorma
            // 
            this.categoriadelanorma.HeaderText = "Categoria de la norma";
            this.categoriadelanorma.Name = "categoriadelanorma";
            // 
            // borrar
            // 
            this.borrar.HeaderText = "Borrar";
            this.borrar.Name = "borrar";
            // 
            // textBoxFamilia
            // 
            this.textBoxFamilia.Location = new System.Drawing.Point(237, 65);
            this.textBoxFamilia.Name = "textBoxFamilia";
            this.textBoxFamilia.Size = new System.Drawing.Size(234, 20);
            this.textBoxFamilia.TabIndex = 78;
            // 
            // textBoxNombreComun
            // 
            this.textBoxNombreComun.Location = new System.Drawing.Point(237, 178);
            this.textBoxNombreComun.Name = "textBoxNombreComun";
            this.textBoxNombreComun.Size = new System.Drawing.Size(234, 20);
            this.textBoxNombreComun.TabIndex = 77;
            // 
            // textBoxNombreCientifico
            // 
            this.textBoxNombreCientifico.Location = new System.Drawing.Point(237, 136);
            this.textBoxNombreCientifico.Name = "textBoxNombreCientifico";
            this.textBoxNombreCientifico.Size = new System.Drawing.Size(234, 20);
            this.textBoxNombreCientifico.TabIndex = 76;
            // 
            // labelFamilia
            // 
            this.labelFamilia.AutoSize = true;
            this.labelFamilia.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFamilia.Location = new System.Drawing.Point(180, 70);
            this.labelFamilia.Name = "labelFamilia";
            this.labelFamilia.Size = new System.Drawing.Size(51, 15);
            this.labelFamilia.TabIndex = 75;
            this.labelFamilia.Text = "Familia:";
            // 
            // labelNombreComun
            // 
            this.labelNombreComun.AutoSize = true;
            this.labelNombreComun.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombreComun.Location = new System.Drawing.Point(132, 183);
            this.labelNombreComun.Name = "labelNombreComun";
            this.labelNombreComun.Size = new System.Drawing.Size(99, 15);
            this.labelNombreComun.TabIndex = 74;
            this.labelNombreComun.Text = "Nombre Comun:";
            // 
            // labelNombreCientifico
            // 
            this.labelNombreCientifico.AutoSize = true;
            this.labelNombreCientifico.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombreCientifico.Location = new System.Drawing.Point(122, 141);
            this.labelNombreCientifico.Name = "labelNombreCientifico";
            this.labelNombreCientifico.Size = new System.Drawing.Size(109, 15);
            this.labelNombreCientifico.TabIndex = 73;
            this.labelNombreCientifico.Text = "Nombre Cientifico:";
            // 
            // buttonRegistrar
            // 
            this.buttonRegistrar.BackColor = System.Drawing.SystemColors.Control;
            this.buttonRegistrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.buttonRegistrar.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRegistrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRegistrar.ForeColor = System.Drawing.Color.DodgerBlue;
            this.buttonRegistrar.Image = ((System.Drawing.Image)(resources.GetObject("buttonRegistrar.Image")));
            this.buttonRegistrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonRegistrar.Location = new System.Drawing.Point(741, 222);
            this.buttonRegistrar.Name = "buttonRegistrar";
            this.buttonRegistrar.Size = new System.Drawing.Size(141, 45);
            this.buttonRegistrar.TabIndex = 72;
            this.buttonRegistrar.Text = "Registrar";
            this.buttonRegistrar.UseVisualStyleBackColor = false;
            this.buttonRegistrar.Click += new System.EventHandler(this.buttonRegistrar_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(689, 48);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(152, 37);
            this.button2.TabIndex = 88;
            this.button2.Text = "Importar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(479, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 24);
            this.label1.TabIndex = 89;
            this.label1.Text = "Registrar Especies";
            // 
            // FormRegistroEspecie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBoxCategoriaDeNorma);
            this.Controls.Add(this.textBoxGenero);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxFormaDeVida);
            this.Controls.Add(this.textBoxBuscarEspecie);
            this.Controls.Add(this.labelBuscarEspecie);
            this.Controls.Add(this.dataGridViewEspecies);
            this.Controls.Add(this.textBoxFamilia);
            this.Controls.Add(this.textBoxNombreComun);
            this.Controls.Add(this.textBoxNombreCientifico);
            this.Controls.Add(this.labelFamilia);
            this.Controls.Add(this.labelNombreComun);
            this.Controls.Add(this.labelNombreCientifico);
            this.Controls.Add(this.buttonRegistrar);
            this.Name = "FormRegistroEspecie";
            this.Size = new System.Drawing.Size(1096, 528);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewEspecies)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxCategoriaDeNorma;
        private System.Windows.Forms.TextBox textBoxGenero;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxFormaDeVida;
        private System.Windows.Forms.TextBox textBoxBuscarEspecie;
        private System.Windows.Forms.Label labelBuscarEspecie;
        private System.Windows.Forms.DataGridView dataGridViewEspecies;
        private System.Windows.Forms.DataGridViewTextBoxColumn familia;
        private System.Windows.Forms.DataGridViewTextBoxColumn genero;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombrecientifico;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombrecomun;
        private System.Windows.Forms.DataGridViewTextBoxColumn formadevida;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoriadelanorma;
        private System.Windows.Forms.DataGridViewButtonColumn borrar;
        private System.Windows.Forms.TextBox textBoxFamilia;
        private System.Windows.Forms.TextBox textBoxNombreComun;
        private System.Windows.Forms.TextBox textBoxNombreCientifico;
        private System.Windows.Forms.Label labelFamilia;
        private System.Windows.Forms.Label labelNombreComun;
        private System.Windows.Forms.Label labelNombreCientifico;
        private System.Windows.Forms.Button buttonRegistrar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
    }
}
