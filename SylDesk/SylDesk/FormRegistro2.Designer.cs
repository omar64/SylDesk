namespace SylDesk
{
    partial class FormRegistro2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegistro2));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.buttonEliminarIndividuo = new System.Windows.Forms.Button();
            this.buttonAgregarBifurcacion = new System.Windows.Forms.Button();
            this.buttonAgregarIndividuo = new System.Windows.Forms.Button();
            this.labelNombre = new System.Windows.Forms.Label();
            this.labelNombreProyecto = new System.Windows.Forms.Label();
            this.textBoxEstadoSucesional = new System.Windows.Forms.TextBox();
            this.textBoxMunicipio = new System.Windows.Forms.TextBox();
            this.labelEstadoSucesional = new System.Windows.Forms.Label();
            this.labelMunicipio = new System.Windows.Forms.Label();
            this.textBoxY = new System.Windows.Forms.TextBox();
            this.textBoxX = new System.Windows.Forms.TextBox();
            this.labelY = new System.Windows.Forms.Label();
            this.labelX = new System.Windows.Forms.Label();
            this.labelCoordenadas = new System.Windows.Forms.Label();
            this.labelAreas = new System.Windows.Forms.Label();
            this.labelSitios = new System.Windows.Forms.Label();
            this.buttonBorrarSitio = new System.Windows.Forms.Button();
            this.buttonAgregarSitio = new System.Windows.Forms.Button();
            this.comboBoxAreas = new System.Windows.Forms.ComboBox();
            this.comboBoxSitios = new System.Windows.Forms.ComboBox();
            this.dataGridViewIndividuos = new System.Windows.Forms.DataGridView();
            this.cuadrante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.arbolnumeroensitio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bifurcados = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombrecientifico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombrecomun = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.familia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.genero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.perimetro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diametro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alturafl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alturatotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coberturalargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coberturaancho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formadefuste = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.estadocondicion = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.grupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.volumen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button6 = new System.Windows.Forms.Button();
            this.buttonGrafica = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIndividuos)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonEliminarIndividuo
            // 
            this.buttonEliminarIndividuo.Location = new System.Drawing.Point(264, 473);
            this.buttonEliminarIndividuo.Name = "buttonEliminarIndividuo";
            this.buttonEliminarIndividuo.Size = new System.Drawing.Size(75, 36);
            this.buttonEliminarIndividuo.TabIndex = 88;
            this.buttonEliminarIndividuo.Text = "Eliminar\r\nIndividuo";
            this.buttonEliminarIndividuo.UseVisualStyleBackColor = true;
            // 
            // buttonAgregarBifurcacion
            // 
            this.buttonAgregarBifurcacion.Location = new System.Drawing.Point(149, 473);
            this.buttonAgregarBifurcacion.Name = "buttonAgregarBifurcacion";
            this.buttonAgregarBifurcacion.Size = new System.Drawing.Size(75, 36);
            this.buttonAgregarBifurcacion.TabIndex = 87;
            this.buttonAgregarBifurcacion.Text = "Agregar\r\nBifurcacion";
            this.buttonAgregarBifurcacion.UseVisualStyleBackColor = true;
            // 
            // buttonAgregarIndividuo
            // 
            this.buttonAgregarIndividuo.Location = new System.Drawing.Point(39, 473);
            this.buttonAgregarIndividuo.Name = "buttonAgregarIndividuo";
            this.buttonAgregarIndividuo.Size = new System.Drawing.Size(75, 36);
            this.buttonAgregarIndividuo.TabIndex = 86;
            this.buttonAgregarIndividuo.Text = "Agregar\r\nIndividuo";
            this.buttonAgregarIndividuo.UseVisualStyleBackColor = true;
            this.buttonAgregarIndividuo.Click += new System.EventHandler(this.buttonAgregarIndividuo_Click);
            // 
            // labelNombre
            // 
            this.labelNombre.AutoSize = true;
            this.labelNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombre.Location = new System.Drawing.Point(910, 38);
            this.labelNombre.Name = "labelNombre";
            this.labelNombre.Size = new System.Drawing.Size(65, 20);
            this.labelNombre.TabIndex = 85;
            this.labelNombre.Text = "Nombre";
            // 
            // labelNombreProyecto
            // 
            this.labelNombreProyecto.AutoSize = true;
            this.labelNombreProyecto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombreProyecto.Location = new System.Drawing.Point(829, 38);
            this.labelNombreProyecto.Name = "labelNombreProyecto";
            this.labelNombreProyecto.Size = new System.Drawing.Size(75, 20);
            this.labelNombreProyecto.TabIndex = 84;
            this.labelNombreProyecto.Text = "Proyecto:";
            // 
            // textBoxEstadoSucesional
            // 
            this.textBoxEstadoSucesional.Location = new System.Drawing.Point(715, 106);
            this.textBoxEstadoSucesional.Name = "textBoxEstadoSucesional";
            this.textBoxEstadoSucesional.Size = new System.Drawing.Size(100, 20);
            this.textBoxEstadoSucesional.TabIndex = 83;
            // 
            // textBoxMunicipio
            // 
            this.textBoxMunicipio.Location = new System.Drawing.Point(715, 67);
            this.textBoxMunicipio.Name = "textBoxMunicipio";
            this.textBoxMunicipio.Size = new System.Drawing.Size(100, 20);
            this.textBoxMunicipio.TabIndex = 82;
            // 
            // labelEstadoSucesional
            // 
            this.labelEstadoSucesional.AutoSize = true;
            this.labelEstadoSucesional.Location = new System.Drawing.Point(614, 108);
            this.labelEstadoSucesional.Name = "labelEstadoSucesional";
            this.labelEstadoSucesional.Size = new System.Drawing.Size(95, 13);
            this.labelEstadoSucesional.TabIndex = 81;
            this.labelEstadoSucesional.Text = "Estado Sucesional";
            this.labelEstadoSucesional.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelMunicipio
            // 
            this.labelMunicipio.AutoSize = true;
            this.labelMunicipio.Location = new System.Drawing.Point(657, 70);
            this.labelMunicipio.Name = "labelMunicipio";
            this.labelMunicipio.Size = new System.Drawing.Size(52, 13);
            this.labelMunicipio.TabIndex = 80;
            this.labelMunicipio.Text = "Municipio";
            // 
            // textBoxY
            // 
            this.textBoxY.Location = new System.Drawing.Point(496, 102);
            this.textBoxY.Name = "textBoxY";
            this.textBoxY.Size = new System.Drawing.Size(100, 20);
            this.textBoxY.TabIndex = 79;
            // 
            // textBoxX
            // 
            this.textBoxX.Location = new System.Drawing.Point(496, 64);
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.Size = new System.Drawing.Size(100, 20);
            this.textBoxX.TabIndex = 78;
            this.textBoxX.TextChanged += new System.EventHandler(this.textBoxX_TextChanged);
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(476, 109);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(14, 13);
            this.labelY.TabIndex = 77;
            this.labelY.Text = "Y";
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(476, 69);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(14, 13);
            this.labelX.TabIndex = 76;
            this.labelX.Text = "X";
            // 
            // labelCoordenadas
            // 
            this.labelCoordenadas.AutoSize = true;
            this.labelCoordenadas.Location = new System.Drawing.Point(493, 45);
            this.labelCoordenadas.Name = "labelCoordenadas";
            this.labelCoordenadas.Size = new System.Drawing.Size(70, 13);
            this.labelCoordenadas.TabIndex = 75;
            this.labelCoordenadas.Text = "Coordenadas";
            // 
            // labelAreas
            // 
            this.labelAreas.AutoSize = true;
            this.labelAreas.Location = new System.Drawing.Point(39, 84);
            this.labelAreas.Name = "labelAreas";
            this.labelAreas.Size = new System.Drawing.Size(34, 13);
            this.labelAreas.TabIndex = 74;
            this.labelAreas.Text = "Areas";
            // 
            // labelSitios
            // 
            this.labelSitios.AutoSize = true;
            this.labelSitios.Location = new System.Drawing.Point(39, 44);
            this.labelSitios.Name = "labelSitios";
            this.labelSitios.Size = new System.Drawing.Size(32, 13);
            this.labelSitios.TabIndex = 72;
            this.labelSitios.Text = "Sitios";
            // 
            // buttonBorrarSitio
            // 
            this.buttonBorrarSitio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBorrarSitio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonBorrarSitio.Image = ((System.Drawing.Image)(resources.GetObject("buttonBorrarSitio.Image")));
            this.buttonBorrarSitio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonBorrarSitio.Location = new System.Drawing.Point(326, 60);
            this.buttonBorrarSitio.Name = "buttonBorrarSitio";
            this.buttonBorrarSitio.Size = new System.Drawing.Size(144, 54);
            this.buttonBorrarSitio.TabIndex = 71;
            this.buttonBorrarSitio.Text = "Eliminar Sitio";
            this.buttonBorrarSitio.UseVisualStyleBackColor = true;
            this.buttonBorrarSitio.Click += new System.EventHandler(this.buttonBorrarSitio_Click);
            // 
            // buttonAgregarSitio
            // 
            this.buttonAgregarSitio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAgregarSitio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonAgregarSitio.Image = ((System.Drawing.Image)(resources.GetObject("buttonAgregarSitio.Image")));
            this.buttonAgregarSitio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAgregarSitio.Location = new System.Drawing.Point(175, 60);
            this.buttonAgregarSitio.Name = "buttonAgregarSitio";
            this.buttonAgregarSitio.Size = new System.Drawing.Size(145, 54);
            this.buttonAgregarSitio.TabIndex = 70;
            this.buttonAgregarSitio.Text = "Añadir Sitio";
            this.buttonAgregarSitio.UseVisualStyleBackColor = true;
            this.buttonAgregarSitio.Click += new System.EventHandler(this.buttonAgregarSitio_Click);
            // 
            // comboBoxAreas
            // 
            this.comboBoxAreas.AutoCompleteCustomSource.AddRange(new string[] {
            "500",
            "100",
            "5"});
            this.comboBoxAreas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAreas.FormattingEnabled = true;
            this.comboBoxAreas.Items.AddRange(new object[] {
            "500",
            "100",
            "5"});
            this.comboBoxAreas.Location = new System.Drawing.Point(39, 100);
            this.comboBoxAreas.Name = "comboBoxAreas";
            this.comboBoxAreas.Size = new System.Drawing.Size(121, 21);
            this.comboBoxAreas.TabIndex = 69;
            this.comboBoxAreas.SelectedIndexChanged += new System.EventHandler(this.comboBoxAreas_SelectedIndexChanged);
            // 
            // comboBoxSitios
            // 
            this.comboBoxSitios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSitios.FormattingEnabled = true;
            this.comboBoxSitios.Location = new System.Drawing.Point(39, 60);
            this.comboBoxSitios.Name = "comboBoxSitios";
            this.comboBoxSitios.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSitios.TabIndex = 68;
            this.comboBoxSitios.SelectedIndexChanged += new System.EventHandler(this.comboBoxSitios_SelectedIndexChanged);
            // 
            // dataGridViewIndividuos
            // 
            this.dataGridViewIndividuos.AllowUserToAddRows = false;
            this.dataGridViewIndividuos.AllowUserToDeleteRows = false;
            this.dataGridViewIndividuos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewIndividuos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cuadrante,
            this.numero,
            this.arbolnumeroensitio,
            this.bifurcados,
            this.nombrecientifico,
            this.nombrecomun,
            this.familia,
            this.genero,
            this.perimetro,
            this.diametro,
            this.alturafl,
            this.alturatotal,
            this.coberturalargo,
            this.coberturaancho,
            this.formadefuste,
            this.estadocondicion,
            this.grupo,
            this.volumen});
            this.dataGridViewIndividuos.Location = new System.Drawing.Point(39, 170);
            this.dataGridViewIndividuos.Name = "dataGridViewIndividuos";
            this.dataGridViewIndividuos.Size = new System.Drawing.Size(1031, 297);
            this.dataGridViewIndividuos.TabIndex = 67;
            this.dataGridViewIndividuos.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewIndividuos_CellEndEdit);
            this.dataGridViewIndividuos.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridViewIndividuos_EditingControlShowing);
            this.dataGridViewIndividuos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridViewIndividuos_KeyPress);
            // 
            // cuadrante
            // 
            this.cuadrante.HeaderText = "Cuadrante";
            this.cuadrante.Name = "cuadrante";
            // 
            // numero
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numero.DefaultCellStyle = dataGridViewCellStyle1;
            this.numero.HeaderText = "*Consecutivo";
            this.numero.Name = "numero";
            this.numero.ReadOnly = true;
            // 
            // arbolnumeroensitio
            // 
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.arbolnumeroensitio.DefaultCellStyle = dataGridViewCellStyle2;
            this.arbolnumeroensitio.HeaderText = "*NO. EN CAMPO";
            this.arbolnumeroensitio.Name = "arbolnumeroensitio";
            this.arbolnumeroensitio.ReadOnly = true;
            // 
            // bifurcados
            // 
            this.bifurcados.HeaderText = "Bifurcado";
            this.bifurcados.Name = "bifurcados";
            this.bifurcados.ReadOnly = true;
            this.bifurcados.Visible = false;
            // 
            // nombrecientifico
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombrecientifico.DefaultCellStyle = dataGridViewCellStyle3;
            this.nombrecientifico.HeaderText = "Nombre Cientifico";
            this.nombrecientifico.Name = "nombrecientifico";
            // 
            // nombrecomun
            // 
            this.nombrecomun.HeaderText = "*Nombre Comun";
            this.nombrecomun.Name = "nombrecomun";
            this.nombrecomun.ReadOnly = true;
            // 
            // familia
            // 
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.familia.DefaultCellStyle = dataGridViewCellStyle4;
            this.familia.HeaderText = "*Familia";
            this.familia.Name = "familia";
            this.familia.ReadOnly = true;
            // 
            // genero
            // 
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.genero.DefaultCellStyle = dataGridViewCellStyle5;
            this.genero.HeaderText = "*Genero";
            this.genero.Name = "genero";
            this.genero.ReadOnly = true;
            // 
            // perimetro
            // 
            this.perimetro.HeaderText = "Perimetro";
            this.perimetro.Name = "perimetro";
            this.perimetro.Width = 70;
            // 
            // diametro
            // 
            this.diametro.HeaderText = "Diametro";
            this.diametro.Name = "diametro";
            this.diametro.Width = 71;
            // 
            // alturafl
            // 
            this.alturafl.HeaderText = "Altura F.L";
            this.alturafl.Name = "alturafl";
            this.alturafl.Width = 70;
            // 
            // alturatotal
            // 
            this.alturatotal.HeaderText = "Altura Total";
            this.alturatotal.Name = "alturatotal";
            this.alturatotal.Width = 71;
            // 
            // coberturalargo
            // 
            this.coberturalargo.HeaderText = "Cobertura(Largo)";
            this.coberturalargo.Name = "coberturalargo";
            this.coberturalargo.Visible = false;
            // 
            // coberturaancho
            // 
            this.coberturaancho.HeaderText = "Cobertura(Ancho)";
            this.coberturaancho.Name = "coberturaancho";
            this.coberturaancho.Visible = false;
            // 
            // formadefuste
            // 
            this.formadefuste.HeaderText = "Forma de Fuste";
            this.formadefuste.Items.AddRange(new object[] {
            "Curvo",
            "Curvo Bifurcado",
            "Recto",
            "Curvo",
            "Curvo Bifurcado",
            "Recto"});
            this.formadefuste.Name = "formadefuste";
            this.formadefuste.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.formadefuste.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.formadefuste.Width = 70;
            // 
            // estadocondicion
            // 
            this.estadocondicion.HeaderText = "Estado o Condicion";
            this.estadocondicion.Items.AddRange(new object[] {
            "Sano",
            "Sano despuntado",
            "Samago",
            "Inclinado",
            "Sano",
            "Sano despuntado",
            "Samago",
            "Inclinado"});
            this.estadocondicion.Name = "estadocondicion";
            this.estadocondicion.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.estadocondicion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.estadocondicion.Width = 71;
            // 
            // grupo
            // 
            this.grupo.HeaderText = "Grupo";
            this.grupo.Name = "grupo";
            this.grupo.ReadOnly = true;
            // 
            // volumen
            // 
            this.volumen.HeaderText = "Volumen";
            this.volumen.Name = "volumen";
            this.volumen.ReadOnly = true;
            // 
            // button6
            // 
            this.button6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.ForeColor = System.Drawing.Color.DodgerBlue;
            this.button6.Image = ((System.Drawing.Image)(resources.GetObject("button6.Image")));
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.Location = new System.Drawing.Point(867, 119);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(141, 45);
            this.button6.TabIndex = 89;
            this.button6.Text = "Ubicacion";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // buttonGrafica
            // 
            this.buttonGrafica.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonGrafica.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGrafica.ForeColor = System.Drawing.Color.DodgerBlue;
            this.buttonGrafica.Image = ((System.Drawing.Image)(resources.GetObject("buttonGrafica.Image")));
            this.buttonGrafica.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGrafica.Location = new System.Drawing.Point(867, 70);
            this.buttonGrafica.Name = "buttonGrafica";
            this.buttonGrafica.Size = new System.Drawing.Size(141, 45);
            this.buttonGrafica.TabIndex = 90;
            this.buttonGrafica.Text = "Grafica";
            this.buttonGrafica.UseVisualStyleBackColor = true;
            this.buttonGrafica.Click += new System.EventHandler(this.buttonGrafica_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(477, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 24);
            this.label1.TabIndex = 91;
            this.label1.Text = "Detalles Proyecto";
            // 
            // FormRegistro2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonGrafica);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.buttonEliminarIndividuo);
            this.Controls.Add(this.buttonAgregarBifurcacion);
            this.Controls.Add(this.buttonAgregarIndividuo);
            this.Controls.Add(this.labelNombre);
            this.Controls.Add(this.labelNombreProyecto);
            this.Controls.Add(this.textBoxEstadoSucesional);
            this.Controls.Add(this.textBoxMunicipio);
            this.Controls.Add(this.labelEstadoSucesional);
            this.Controls.Add(this.labelMunicipio);
            this.Controls.Add(this.textBoxY);
            this.Controls.Add(this.textBoxX);
            this.Controls.Add(this.labelY);
            this.Controls.Add(this.labelX);
            this.Controls.Add(this.labelCoordenadas);
            this.Controls.Add(this.labelAreas);
            this.Controls.Add(this.labelSitios);
            this.Controls.Add(this.buttonBorrarSitio);
            this.Controls.Add(this.buttonAgregarSitio);
            this.Controls.Add(this.comboBoxAreas);
            this.Controls.Add(this.comboBoxSitios);
            this.Controls.Add(this.dataGridViewIndividuos);
            this.Name = "FormRegistro2";
            this.Size = new System.Drawing.Size(1096, 528);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIndividuos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonEliminarIndividuo;
        private System.Windows.Forms.Button buttonAgregarBifurcacion;
        private System.Windows.Forms.Button buttonAgregarIndividuo;
        private System.Windows.Forms.Label labelNombre;
        private System.Windows.Forms.Label labelNombreProyecto;
        private System.Windows.Forms.TextBox textBoxEstadoSucesional;
        private System.Windows.Forms.TextBox textBoxMunicipio;
        private System.Windows.Forms.Label labelEstadoSucesional;
        private System.Windows.Forms.Label labelMunicipio;
        private System.Windows.Forms.TextBox textBoxY;
        private System.Windows.Forms.TextBox textBoxX;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label labelCoordenadas;
        private System.Windows.Forms.Label labelAreas;
        private System.Windows.Forms.Label labelSitios;
        private System.Windows.Forms.Button buttonBorrarSitio;
        private System.Windows.Forms.Button buttonAgregarSitio;
        private System.Windows.Forms.ComboBox comboBoxAreas;
        private System.Windows.Forms.ComboBox comboBoxSitios;
        private System.Windows.Forms.DataGridView dataGridViewIndividuos;

        private System.Windows.Forms.DataGridViewTextBoxColumn cuadrante;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn arbolnumeroensitio;
        private System.Windows.Forms.DataGridViewTextBoxColumn bifurcados;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombrecientifico;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombrecomun;
        private System.Windows.Forms.DataGridViewTextBoxColumn familia;
        private System.Windows.Forms.DataGridViewTextBoxColumn genero;
        private System.Windows.Forms.DataGridViewTextBoxColumn perimetro;
        private System.Windows.Forms.DataGridViewTextBoxColumn diametro;
        private System.Windows.Forms.DataGridViewTextBoxColumn alturafl;
        private System.Windows.Forms.DataGridViewTextBoxColumn alturatotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn coberturalargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn coberturaancho;
        private System.Windows.Forms.DataGridViewComboBoxColumn formadefuste;
        private System.Windows.Forms.DataGridViewComboBoxColumn estadocondicion;


        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button buttonGrafica;
        private System.Windows.Forms.Label label1;


        private System.Windows.Forms.DataGridViewTextBoxColumn grupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn volumen;


    }
}
