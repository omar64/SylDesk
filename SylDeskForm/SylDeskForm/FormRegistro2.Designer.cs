namespace SylDeskForm
{
    partial class FormRegistro2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegistro2));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelTop = new System.Windows.Forms.Panel();
            this.labelMinimize = new System.Windows.Forms.Label();
            this.labelClose = new System.Windows.Forms.Label();
            this.pictureBoxSylvaticaLogo = new System.Windows.Forms.PictureBox();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.buttonSitio = new System.Windows.Forms.Button();
            this.buttonCampo = new System.Windows.Forms.Button();
            this.buttonGalerias = new System.Windows.Forms.Button();
            this.buttonProyectos = new System.Windows.Forms.Button();
            this.buttonHome = new System.Windows.Forms.Button();
            this.dataGridViewIndividuos = new System.Windows.Forms.DataGridView();
            this.comboBoxSitios = new System.Windows.Forms.ComboBox();
            this.comboBoxAreas = new System.Windows.Forms.ComboBox();
            this.buttonAgregarSitio = new System.Windows.Forms.Button();
            this.buttonBorrarSitio = new System.Windows.Forms.Button();
            this.labelSitios = new System.Windows.Forms.Label();
            this.labelAreas = new System.Windows.Forms.Label();
            this.labelCoordenadas = new System.Windows.Forms.Label();
            this.labelX = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.textBoxX = new System.Windows.Forms.TextBox();
            this.textBoxY = new System.Windows.Forms.TextBox();
            this.labelMunicipio = new System.Windows.Forms.Label();
            this.labelEstadoSucesional = new System.Windows.Forms.Label();
            this.textBoxMunicipio = new System.Windows.Forms.TextBox();
            this.textBoxEstadoSucesional = new System.Windows.Forms.TextBox();
            this.cuadrante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.arbolnumeroensitio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.especie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombrecientifico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombrecomun = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.familia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.perimetro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diametro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alturafl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alturatotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coberturalargo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coberturaancho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.formadefuste = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.estadocondicion = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSylvaticaLogo)).BeginInit();
            this.panelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIndividuos)).BeginInit();
            this.SuspendLayout();
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
            this.panelTop.TabIndex = 15;
            // 
            // labelMinimize
            // 
            this.labelMinimize.AutoSize = true;
            this.labelMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelMinimize.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMinimize.ForeColor = System.Drawing.Color.White;
            this.labelMinimize.Location = new System.Drawing.Point(670, 22);
            this.labelMinimize.Name = "labelMinimize";
            this.labelMinimize.Size = new System.Drawing.Size(22, 24);
            this.labelMinimize.TabIndex = 14;
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
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(39)))), ((int)(((byte)(40)))));
            this.panelLeft.Controls.Add(this.buttonSitio);
            this.panelLeft.Controls.Add(this.buttonCampo);
            this.panelLeft.Controls.Add(this.buttonGalerias);
            this.panelLeft.Controls.Add(this.buttonProyectos);
            this.panelLeft.Controls.Add(this.buttonHome);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(136, 565);
            this.panelLeft.TabIndex = 14;
            // 
            // buttonSitio
            // 
            this.buttonSitio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSitio.FlatAppearance.BorderSize = 0;
            this.buttonSitio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSitio.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSitio.ForeColor = System.Drawing.Color.White;
            this.buttonSitio.Image = ((System.Drawing.Image)(resources.GetObject("buttonSitio.Image")));
            this.buttonSitio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSitio.Location = new System.Drawing.Point(12, 307);
            this.buttonSitio.Name = "buttonSitio";
            this.buttonSitio.Size = new System.Drawing.Size(124, 55);
            this.buttonSitio.TabIndex = 16;
            this.buttonSitio.Text = "     Sitio";
            this.buttonSitio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonSitio.UseVisualStyleBackColor = true;
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
            // dataGridViewIndividuos
            // 
            this.dataGridViewIndividuos.AllowUserToAddRows = false;
            this.dataGridViewIndividuos.AllowUserToDeleteRows = false;
            this.dataGridViewIndividuos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewIndividuos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cuadrante,
            this.numero,
            this.arbolnumeroensitio,
            this.especie,
            this.nombrecientifico,
            this.nombrecomun,
            this.familia,
            this.perimetro,
            this.diametro,
            this.alturafl,
            this.alturatotal,
            this.coberturalargo,
            this.coberturaancho,
            this.formadefuste,
            this.estadocondicion});
            this.dataGridViewIndividuos.Location = new System.Drawing.Point(146, 211);
            this.dataGridViewIndividuos.Name = "dataGridViewIndividuos";
            this.dataGridViewIndividuos.Size = new System.Drawing.Size(742, 328);
            this.dataGridViewIndividuos.TabIndex = 16;
            this.dataGridViewIndividuos.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewIndividuos_CellEndEdit);
            this.dataGridViewIndividuos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridViewIndividuos_KeyPress);
            // 
            // comboBoxSitios
            // 
            this.comboBoxSitios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSitios.FormattingEnabled = true;
            this.comboBoxSitios.Location = new System.Drawing.Point(146, 121);
            this.comboBoxSitios.Name = "comboBoxSitios";
            this.comboBoxSitios.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSitios.TabIndex = 18;
            this.comboBoxSitios.SelectedIndexChanged += new System.EventHandler(this.comboBoxSitios_SelectedIndexChanged);
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
            this.comboBoxAreas.Location = new System.Drawing.Point(146, 161);
            this.comboBoxAreas.Name = "comboBoxAreas";
            this.comboBoxAreas.Size = new System.Drawing.Size(121, 21);
            this.comboBoxAreas.TabIndex = 19;
            this.comboBoxAreas.SelectedIndexChanged += new System.EventHandler(this.comboBoxAreas_SelectedIndexChanged);
            // 
            // buttonAgregarSitio
            // 
            this.buttonAgregarSitio.Location = new System.Drawing.Point(288, 121);
            this.buttonAgregarSitio.Name = "buttonAgregarSitio";
            this.buttonAgregarSitio.Size = new System.Drawing.Size(75, 23);
            this.buttonAgregarSitio.TabIndex = 20;
            this.buttonAgregarSitio.Text = "Añadir Sitio";
            this.buttonAgregarSitio.UseVisualStyleBackColor = true;
            this.buttonAgregarSitio.Click += new System.EventHandler(this.buttonAgregarSitio_Click);
            // 
            // buttonBorrarSitio
            // 
            this.buttonBorrarSitio.Location = new System.Drawing.Point(369, 121);
            this.buttonBorrarSitio.Name = "buttonBorrarSitio";
            this.buttonBorrarSitio.Size = new System.Drawing.Size(75, 23);
            this.buttonBorrarSitio.TabIndex = 21;
            this.buttonBorrarSitio.Text = "Eliminar Sitio";
            this.buttonBorrarSitio.UseVisualStyleBackColor = true;
            this.buttonBorrarSitio.Click += new System.EventHandler(this.buttonBorrarSitio_Click);
            // 
            // labelSitios
            // 
            this.labelSitios.AutoSize = true;
            this.labelSitios.Location = new System.Drawing.Point(146, 105);
            this.labelSitios.Name = "labelSitios";
            this.labelSitios.Size = new System.Drawing.Size(32, 13);
            this.labelSitios.TabIndex = 22;
            this.labelSitios.Text = "Sitios";
            // 
            // labelAreas
            // 
            this.labelAreas.AutoSize = true;
            this.labelAreas.Location = new System.Drawing.Point(146, 145);
            this.labelAreas.Name = "labelAreas";
            this.labelAreas.Size = new System.Drawing.Size(34, 13);
            this.labelAreas.TabIndex = 23;
            this.labelAreas.Text = "Areas";
            // 
            // labelCoordenadas
            // 
            this.labelCoordenadas.AutoSize = true;
            this.labelCoordenadas.Location = new System.Drawing.Point(477, 105);
            this.labelCoordenadas.Name = "labelCoordenadas";
            this.labelCoordenadas.Size = new System.Drawing.Size(70, 13);
            this.labelCoordenadas.TabIndex = 24;
            this.labelCoordenadas.Text = "Coordenadas";
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(460, 129);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(14, 13);
            this.labelX.TabIndex = 25;
            this.labelX.Text = "X";
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(460, 169);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(14, 13);
            this.labelY.TabIndex = 26;
            this.labelY.Text = "Y";
            // 
            // textBoxX
            // 
            this.textBoxX.Location = new System.Drawing.Point(480, 124);
            this.textBoxX.Name = "textBoxX";
            this.textBoxX.Size = new System.Drawing.Size(100, 20);
            this.textBoxX.TabIndex = 27;
            this.textBoxX.TextChanged += new System.EventHandler(this.textBoxX_TextChanged);
            // 
            // textBoxY
            // 
            this.textBoxY.Location = new System.Drawing.Point(480, 162);
            this.textBoxY.Name = "textBoxY";
            this.textBoxY.Size = new System.Drawing.Size(100, 20);
            this.textBoxY.TabIndex = 28;
            this.textBoxY.TextChanged += new System.EventHandler(this.textBoxY_TextChanged);
            // 
            // labelMunicipio
            // 
            this.labelMunicipio.AutoSize = true;
            this.labelMunicipio.Location = new System.Drawing.Point(613, 130);
            this.labelMunicipio.Name = "labelMunicipio";
            this.labelMunicipio.Size = new System.Drawing.Size(52, 13);
            this.labelMunicipio.TabIndex = 29;
            this.labelMunicipio.Text = "Municipio";
            // 
            // labelEstadoSucesional
            // 
            this.labelEstadoSucesional.AutoSize = true;
            this.labelEstadoSucesional.Location = new System.Drawing.Point(613, 168);
            this.labelEstadoSucesional.Name = "labelEstadoSucesional";
            this.labelEstadoSucesional.Size = new System.Drawing.Size(95, 13);
            this.labelEstadoSucesional.TabIndex = 30;
            this.labelEstadoSucesional.Text = "Estado Sucesional";
            this.labelEstadoSucesional.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxMunicipio
            // 
            this.textBoxMunicipio.Location = new System.Drawing.Point(714, 127);
            this.textBoxMunicipio.Name = "textBoxMunicipio";
            this.textBoxMunicipio.Size = new System.Drawing.Size(100, 20);
            this.textBoxMunicipio.TabIndex = 31;
            this.textBoxMunicipio.TextChanged += new System.EventHandler(this.textBoxMunicipio_TextChanged);
            // 
            // textBoxEstadoSucesional
            // 
            this.textBoxEstadoSucesional.Location = new System.Drawing.Point(714, 166);
            this.textBoxEstadoSucesional.Name = "textBoxEstadoSucesional";
            this.textBoxEstadoSucesional.Size = new System.Drawing.Size(100, 20);
            this.textBoxEstadoSucesional.TabIndex = 32;
            this.textBoxEstadoSucesional.TextChanged += new System.EventHandler(this.textBoxEstadoSucesional_TextChanged);
            // 
            // cuadrante
            // 
            this.cuadrante.HeaderText = "Cuadrante";
            this.cuadrante.Name = "cuadrante";
            // 
            // numero
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numero.DefaultCellStyle = dataGridViewCellStyle1;
            this.numero.HeaderText = "Consecutivo";
            this.numero.Name = "numero";
            this.numero.ReadOnly = true;
            // 
            // arbolnumeroensitio
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.arbolnumeroensitio.DefaultCellStyle = dataGridViewCellStyle2;
            this.arbolnumeroensitio.HeaderText = "NO. EN CAMPO";
            this.arbolnumeroensitio.Name = "arbolnumeroensitio";
            this.arbolnumeroensitio.ReadOnly = true;
            // 
            // especie
            // 
            this.especie.HeaderText = "Especie";
            this.especie.Name = "especie";
            // 
            // nombrecientifico
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver;
            this.nombrecientifico.DefaultCellStyle = dataGridViewCellStyle3;
            this.nombrecientifico.HeaderText = "Nombre Cientifico";
            this.nombrecientifico.Name = "nombrecientifico";
            this.nombrecientifico.ReadOnly = true;
            // 
            // nombrecomun
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nombrecomun.DefaultCellStyle = dataGridViewCellStyle4;
            this.nombrecomun.HeaderText = "Nombre Comun";
            this.nombrecomun.Name = "nombrecomun";
            this.nombrecomun.ReadOnly = true;
            // 
            // familia
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.familia.DefaultCellStyle = dataGridViewCellStyle5;
            this.familia.HeaderText = "Familia";
            this.familia.Name = "familia";
            this.familia.ReadOnly = true;
            // 
            // perimetro
            // 
            this.perimetro.HeaderText = "Perimetro";
            this.perimetro.Name = "perimetro";
            // 
            // diametro
            // 
            this.diametro.HeaderText = "Diametro";
            this.diametro.Name = "diametro";
            // 
            // alturafl
            // 
            this.alturafl.HeaderText = "Altura F.L";
            this.alturafl.Name = "alturafl";
            // 
            // alturatotal
            // 
            this.alturatotal.HeaderText = "Altura Total";
            this.alturatotal.Name = "alturatotal";
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
            "Recto"});
            this.formadefuste.Name = "formadefuste";
            this.formadefuste.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.formadefuste.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // estadocondicion
            // 
            this.estadocondicion.HeaderText = "Estado o Condicion";
            this.estadocondicion.Items.AddRange(new object[] {
            "Sano",
            "Sano despuntado",
            "Samago",
            "Inclinado"});
            this.estadocondicion.Name = "estadocondicion";
            this.estadocondicion.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.estadocondicion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // FormRegistro2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 565);
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
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormRegistro2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSylvaticaLogo)).EndInit();
            this.panelLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIndividuos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Label labelClose;
        private System.Windows.Forms.PictureBox pictureBoxSylvaticaLogo;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Button buttonSitio;
        private System.Windows.Forms.Button buttonCampo;
        private System.Windows.Forms.Button buttonGalerias;
        private System.Windows.Forms.Button buttonProyectos;
        private System.Windows.Forms.Button buttonHome;
        private System.Windows.Forms.DataGridView dataGridViewIndividuos;
        private System.Windows.Forms.Label labelMinimize;
        private System.Windows.Forms.ComboBox comboBoxSitios;
        private System.Windows.Forms.ComboBox comboBoxAreas;
        private System.Windows.Forms.Button buttonAgregarSitio;
        private System.Windows.Forms.Button buttonBorrarSitio;
        private System.Windows.Forms.Label labelSitios;
        private System.Windows.Forms.Label labelAreas;
        private System.Windows.Forms.Label labelCoordenadas;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.TextBox textBoxX;
        private System.Windows.Forms.TextBox textBoxY;
        private System.Windows.Forms.Label labelMunicipio;
        private System.Windows.Forms.Label labelEstadoSucesional;
        private System.Windows.Forms.TextBox textBoxMunicipio;
        private System.Windows.Forms.TextBox textBoxEstadoSucesional;
        private System.Windows.Forms.DataGridViewTextBoxColumn cuadrante;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn arbolnumeroensitio;
        private System.Windows.Forms.DataGridViewTextBoxColumn especie;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombrecientifico;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombrecomun;
        private System.Windows.Forms.DataGridViewTextBoxColumn familia;
        private System.Windows.Forms.DataGridViewTextBoxColumn perimetro;
        private System.Windows.Forms.DataGridViewTextBoxColumn diametro;
        private System.Windows.Forms.DataGridViewTextBoxColumn alturafl;
        private System.Windows.Forms.DataGridViewTextBoxColumn alturatotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn coberturalargo;
        private System.Windows.Forms.DataGridViewTextBoxColumn coberturaancho;
        private System.Windows.Forms.DataGridViewComboBoxColumn formadefuste;
        private System.Windows.Forms.DataGridViewComboBoxColumn estadocondicion;
    }
}