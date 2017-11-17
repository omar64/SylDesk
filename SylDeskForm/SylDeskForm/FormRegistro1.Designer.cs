namespace SylDeskForm
{
    partial class FormRegistro1
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegistro1));
            this.textBoxNombre = new System.Windows.Forms.TextBox();
            this.textBoxSuperficie = new System.Windows.Forms.TextBox();
            this.textBoxSector = new System.Windows.Forms.TextBox();
            this.labelNombre = new System.Windows.Forms.Label();
            this.labelSuperficie = new System.Windows.Forms.Label();
            this.labelSector = new System.Windows.Forms.Label();
            this.labelDescripcion = new System.Windows.Forms.Label();
            this.richTextBoxDescripcion = new System.Windows.Forms.RichTextBox();
            this.buttonRegistrar = new System.Windows.Forms.Button();
            this.groupBoxRegistro = new System.Windows.Forms.GroupBox();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.buttonsSitio = new System.Windows.Forms.Button();
            this.buttonCampo = new System.Windows.Forms.Button();
            this.buttonGalerias = new System.Windows.Forms.Button();
            this.buttonProyectos = new System.Windows.Forms.Button();
            this.buttonHome = new System.Windows.Forms.Button();
            this.panelTop = new System.Windows.Forms.Panel();
            this.labelMinimize = new System.Windows.Forms.Label();
            this.labelClose = new System.Windows.Forms.Label();
            this.pictureBoxSylvaticaLogo = new System.Windows.Forms.PictureBox();
            this.labelHectareas = new System.Windows.Forms.Label();
            this.groupBoxRegistro.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSylvaticaLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxNombre
            // 
            this.textBoxNombre.Location = new System.Drawing.Point(136, 45);
            this.textBoxNombre.Name = "textBoxNombre";
            this.textBoxNombre.Size = new System.Drawing.Size(100, 21);
            this.textBoxNombre.TabIndex = 0;
            // 
            // textBoxSuperficie
            // 
            this.textBoxSuperficie.Location = new System.Drawing.Point(136, 94);
            this.textBoxSuperficie.Name = "textBoxSuperficie";
            this.textBoxSuperficie.Size = new System.Drawing.Size(100, 21);
            this.textBoxSuperficie.TabIndex = 1;
            // 
            // textBoxSector
            // 
            this.textBoxSector.Location = new System.Drawing.Point(136, 143);
            this.textBoxSector.Name = "textBoxSector";
            this.textBoxSector.Size = new System.Drawing.Size(100, 21);
            this.textBoxSector.TabIndex = 2;
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Location = new System.Drawing.Point(5, 51);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(125, 15);
            this.labelNombre.TabIndex = 3;
            this.labelNombre.Text = "Nombre del Proyecto:";
            // 
            // labelSuperficie
            // 
            this.labelSuperficie.AutoSize = true;
            this.labelSuperficie.Location = new System.Drawing.Point(65, 100);
            this.labelSuperficie.Name = "labelSuperficie";
            this.labelSuperficie.Size = new System.Drawing.Size(65, 15);
            this.labelSuperficie.TabIndex = 4;
            this.labelSuperficie.Text = "Superficie:";
            // 
            // labelSector
            // 
            this.labelSector.AutoSize = true;
            this.labelSector.Location = new System.Drawing.Point(85, 149);
            this.labelSector.Name = "labelSector";
            this.labelSector.Size = new System.Drawing.Size(45, 15);
            this.labelSector.TabIndex = 5;
            this.labelSector.Text = "Sector:";
            // 
            // labelDescripcion
            // 
            this.labelDescripcion.AutoSize = true;
            this.labelDescripcion.Location = new System.Drawing.Point(54, 202);
            this.labelDescripcion.Name = "labelDescripcion";
            this.labelDescripcion.Size = new System.Drawing.Size(76, 15);
            this.labelDescripcion.TabIndex = 6;
            this.labelDescripcion.Text = "Descripcion:";
            // 
            // richTextBoxDescripcion
            // 
            this.richTextBoxDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBoxDescripcion.Location = new System.Drawing.Point(136, 203);
            this.richTextBoxDescripcion.Name = "richTextBoxDescripcion";
            this.richTextBoxDescripcion.Size = new System.Drawing.Size(233, 100);
            this.richTextBoxDescripcion.TabIndex = 7;
            this.richTextBoxDescripcion.Text = "";
            // 
            // buttonRegistrar
            // 
            this.buttonRegistrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(86)))), ((int)(((byte)(180)))), ((int)(((byte)(89)))));
            this.buttonRegistrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRegistrar.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRegistrar.ForeColor = System.Drawing.Color.White;
            this.buttonRegistrar.Location = new System.Drawing.Point(707, 488);
            this.buttonRegistrar.Name = "buttonRegistrar";
            this.buttonRegistrar.Size = new System.Drawing.Size(111, 42);
            this.buttonRegistrar.TabIndex = 8;
            this.buttonRegistrar.Text = "Registrar";
            this.buttonRegistrar.UseVisualStyleBackColor = false;
            this.buttonRegistrar.Click += new System.EventHandler(this.buttonRegistrar_Click);
            // 
            // groupBoxRegistro
            // 
            this.groupBoxRegistro.BackColor = System.Drawing.SystemColors.Control;
            this.groupBoxRegistro.Controls.Add(this.labelHectareas);
            this.groupBoxRegistro.Controls.Add(this.richTextBoxDescripcion);
            this.groupBoxRegistro.Controls.Add(this.textBoxNombre);
            this.groupBoxRegistro.Controls.Add(this.textBoxSuperficie);
            this.groupBoxRegistro.Controls.Add(this.labelDescripcion);
            this.groupBoxRegistro.Controls.Add(this.textBoxSector);
            this.groupBoxRegistro.Controls.Add(this.labelSector);
            this.groupBoxRegistro.Controls.Add(this.labelNombre);
            this.groupBoxRegistro.Controls.Add(this.labelSuperficie);
            this.groupBoxRegistro.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxRegistro.ForeColor = System.Drawing.Color.Black;
            this.groupBoxRegistro.Location = new System.Drawing.Point(161, 145);
            this.groupBoxRegistro.Name = "groupBoxRegistro";
            this.groupBoxRegistro.Size = new System.Drawing.Size(419, 332);
            this.groupBoxRegistro.TabIndex = 9;
            this.groupBoxRegistro.TabStop = false;
            this.groupBoxRegistro.Text = "Registro";
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.panelLeft.Controls.Add(this.buttonsSitio);
            this.panelLeft.Controls.Add(this.buttonCampo);
            this.panelLeft.Controls.Add(this.buttonGalerias);
            this.panelLeft.Controls.Add(this.buttonProyectos);
            this.panelLeft.Controls.Add(this.buttonHome);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(136, 565);
            this.panelLeft.TabIndex = 10;
            // 
            // buttonsSitio
            // 
            this.buttonsSitio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonsSitio.FlatAppearance.BorderSize = 0;
            this.buttonsSitio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonsSitio.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonsSitio.ForeColor = System.Drawing.Color.White;
            this.buttonsSitio.Image = ((System.Drawing.Image)(resources.GetObject("buttonsSitio.Image")));
            this.buttonsSitio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonsSitio.Location = new System.Drawing.Point(12, 307);
            this.buttonsSitio.Name = "buttonsSitio";
            this.buttonsSitio.Size = new System.Drawing.Size(124, 55);
            this.buttonsSitio.TabIndex = 16;
            this.buttonsSitio.Text = "     Sitio";
            this.buttonsSitio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonsSitio.UseVisualStyleBackColor = true;
            // 
            // buttonCampo
            // 
            this.buttonCampo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCampo.FlatAppearance.BorderSize = 0;
            this.buttonCampo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCampo.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCampo.ForeColor = System.Drawing.Color.White;
            this.buttonCampo.Image = ((System.Drawing.Image)(resources.GetObject("buttonCampo.Image")));
            this.buttonCampo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCampo.Location = new System.Drawing.Point(12, 252);
            this.buttonCampo.Name = "buttonCampo";
            this.buttonCampo.Size = new System.Drawing.Size(124, 55);
            this.buttonCampo.TabIndex = 15;
            this.buttonCampo.Text = "     Campo";
            this.buttonCampo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonCampo.UseVisualStyleBackColor = true;
            // 
            // buttonGalerias
            // 
            this.buttonGalerias.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonGalerias.FlatAppearance.BorderSize = 0;
            this.buttonGalerias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGalerias.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonGalerias.ForeColor = System.Drawing.Color.White;
            this.buttonGalerias.Image = ((System.Drawing.Image)(resources.GetObject("buttonGalerias.Image")));
            this.buttonGalerias.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGalerias.Location = new System.Drawing.Point(12, 197);
            this.buttonGalerias.Name = "buttonGalerias";
            this.buttonGalerias.Size = new System.Drawing.Size(124, 55);
            this.buttonGalerias.TabIndex = 14;
            this.buttonGalerias.Text = "     Galerias";
            this.buttonGalerias.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonGalerias.UseVisualStyleBackColor = true;
            // 
            // buttonProyectos
            // 
            this.buttonProyectos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonProyectos.FlatAppearance.BorderSize = 0;
            this.buttonProyectos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonProyectos.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonProyectos.ForeColor = System.Drawing.Color.White;
            this.buttonProyectos.Image = ((System.Drawing.Image)(resources.GetObject("buttonProyectos.Image")));
            this.buttonProyectos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonProyectos.Location = new System.Drawing.Point(12, 142);
            this.buttonProyectos.Name = "buttonProyectos";
            this.buttonProyectos.Size = new System.Drawing.Size(124, 55);
            this.buttonProyectos.TabIndex = 13;
            this.buttonProyectos.Text = "  Proyectos";
            this.buttonProyectos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonProyectos.UseVisualStyleBackColor = true;
            // 
            // buttonHome
            // 
            this.buttonHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonHome.FlatAppearance.BorderSize = 0;
            this.buttonHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHome.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonHome.ForeColor = System.Drawing.Color.White;
            this.buttonHome.Image = ((System.Drawing.Image)(resources.GetObject("buttonHome.Image")));
            this.buttonHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonHome.Location = new System.Drawing.Point(12, 87);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Size = new System.Drawing.Size(124, 55);
            this.buttonHome.TabIndex = 12;
            this.buttonHome.Text = "     Home";
            this.buttonHome.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonHome.UseVisualStyleBackColor = true;
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(135)))), ((int)(((byte)(179)))));
            this.panelTop.Controls.Add(this.labelMinimize);
            this.panelTop.Controls.Add(this.labelClose);
            this.panelTop.Controls.Add(this.pictureBoxSylvaticaLogo);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(136, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(764, 84);
            this.panelTop.TabIndex = 11;
            this.panelTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTop_MouseDown);
            this.panelTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelTop_MouseMove);
            this.panelTop.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panelTop_MouseUp);
            // 
            // labelMinimize
            // 
            this.labelMinimize.AutoSize = true;
            this.labelMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelMinimize.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMinimize.ForeColor = System.Drawing.Color.White;
            this.labelMinimize.Location = new System.Drawing.Point(670, 21);
            this.labelMinimize.Name = "labelMinimize";
            this.labelMinimize.Size = new System.Drawing.Size(22, 24);
            this.labelMinimize.TabIndex = 13;
            this.labelMinimize.Text = "_";
            this.labelMinimize.Click += new System.EventHandler(this.labelMinimize_Click);
            this.labelMinimize.MouseLeave += new System.EventHandler(this.labelMinimize_MouseLeave);
            this.labelMinimize.MouseHover += new System.EventHandler(this.labelMinimize_MouseHover);
            // 
            // labelClose
            // 
            this.labelClose.AutoSize = true;
            this.labelClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelClose.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClose.ForeColor = System.Drawing.Color.White;
            this.labelClose.Location = new System.Drawing.Point(698, 21);
            this.labelClose.Name = "labelClose";
            this.labelClose.Size = new System.Drawing.Size(23, 25);
            this.labelClose.TabIndex = 12;
            this.labelClose.Text = "X";
            this.labelClose.Click += new System.EventHandler(this.labelClose_Click);
            this.labelClose.MouseLeave += new System.EventHandler(this.labelClose_MouseLeave);
            this.labelClose.MouseHover += new System.EventHandler(this.labelClose_MouseHover);
            // 
            // pictureBoxSylvaticaLogo
            // 
            this.pictureBoxSylvaticaLogo.Image = global::SylDeskForm.Properties.Resources.logo1;
            this.pictureBoxSylvaticaLogo.Location = new System.Drawing.Point(6, 11);
            this.pictureBoxSylvaticaLogo.Name = "pictureBoxSylvaticaLogo";
            this.pictureBoxSylvaticaLogo.Size = new System.Drawing.Size(222, 70);
            this.pictureBoxSylvaticaLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxSylvaticaLogo.TabIndex = 0;
            this.pictureBoxSylvaticaLogo.TabStop = false;
            // 
            // labelHectareas
            // 
            this.labelHectareas.AutoSize = true;
            this.labelHectareas.Location = new System.Drawing.Point(242, 97);
            this.labelHectareas.Name = "labelHectareas";
            this.labelHectareas.Size = new System.Drawing.Size(64, 15);
            this.labelHectareas.TabIndex = 8;
            this.labelHectareas.Text = "Hectareas";
            // 
            // FormRegistro1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 565);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelLeft);
            this.Controls.Add(this.groupBoxRegistro);
            this.Controls.Add(this.buttonRegistrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormRegistro1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.groupBoxRegistro.ResumeLayout(false);
            this.groupBoxRegistro.PerformLayout();
            this.panelLeft.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSylvaticaLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.TextBox textBoxSuperficie;
        private System.Windows.Forms.TextBox textBoxSector;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Label labelSuperficie;
        private System.Windows.Forms.Label labelSector;
        private System.Windows.Forms.Label labelDescripcion;
        private System.Windows.Forms.RichTextBox richTextBoxDescripcion;
        private System.Windows.Forms.Button buttonRegistrar;
        private System.Windows.Forms.GroupBox groupBoxRegistro;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button buttonsSitio;
        private System.Windows.Forms.Button buttonCampo;
        private System.Windows.Forms.Button buttonGalerias;
        private System.Windows.Forms.Button buttonProyectos;
        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.PictureBox pictureBoxSylvaticaLogo;
        private System.Windows.Forms.Label labelClose;
        private System.Windows.Forms.Label labelMinimize;
        private System.Windows.Forms.Label labelHectareas;
    }
}

