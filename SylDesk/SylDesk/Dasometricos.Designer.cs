namespace SylDesk
{
    partial class Dasometricos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dasometricos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.panelGrafica = new System.Windows.Forms.Panel();
            this.PanelCargando = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LoadingBox = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonVolum = new System.Windows.Forms.Button();
            this.buttonAB = new System.Windows.Forms.Button();
            this.buttonDensi = new System.Windows.Forms.Button();
            this.buttonDiam = new System.Windows.Forms.Button();
            this.buttonAlt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.buttonBack = new System.Windows.Forms.Button();
            this.panelGrafica.SuspendLayout();
            this.PanelCargando.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LoadingBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelGrafica
            // 
            this.panelGrafica.BackColor = System.Drawing.Color.Gainsboro;
            this.panelGrafica.Controls.Add(this.PanelCargando);
            this.panelGrafica.Controls.Add(this.dataGridView1);
            this.panelGrafica.Controls.Add(this.chart1);
            this.panelGrafica.Location = new System.Drawing.Point(3, 83);
            this.panelGrafica.Name = "panelGrafica";
            this.panelGrafica.Size = new System.Drawing.Size(1090, 439);
            this.panelGrafica.TabIndex = 113;
            // 
            // PanelCargando
            // 
            this.PanelCargando.BackColor = System.Drawing.Color.SeaGreen;
            this.PanelCargando.Controls.Add(this.label3);
            this.PanelCargando.Controls.Add(this.label2);
            this.PanelCargando.Controls.Add(this.LoadingBox);
            this.PanelCargando.Location = new System.Drawing.Point(440, 75);
            this.PanelCargando.Name = "PanelCargando";
            this.PanelCargando.Size = new System.Drawing.Size(303, 156);
            this.PanelCargando.TabIndex = 99;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(16, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 20);
            this.label3.TabIndex = 98;
            this.label3.Text = "Porfavor Espere!!";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(15, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 29);
            this.label2.TabIndex = 97;
            this.label2.Text = "Cargando...";
            // 
            // LoadingBox
            // 
            this.LoadingBox.BackColor = System.Drawing.Color.SeaGreen;
            this.LoadingBox.Image = ((System.Drawing.Image)(resources.GetObject("LoadingBox.Image")));
            this.LoadingBox.Location = new System.Drawing.Point(106, 85);
            this.LoadingBox.Name = "LoadingBox";
            this.LoadingBox.Size = new System.Drawing.Size(100, 58);
            this.LoadingBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LoadingBox.TabIndex = 96;
            this.LoadingBox.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(592, 11);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(483, 417);
            this.dataGridView1.TabIndex = 98;
            // 
            // chart1
            // 
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(13, 11);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(573, 417);
            this.chart1.TabIndex = 97;
            this.chart1.Text = "chart1";
            // 
            // buttonVolum
            // 
            this.buttonVolum.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonVolum.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.buttonVolum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonVolum.ForeColor = System.Drawing.Color.DodgerBlue;
            this.buttonVolum.Location = new System.Drawing.Point(423, 37);
            this.buttonVolum.Name = "buttonVolum";
            this.buttonVolum.Size = new System.Drawing.Size(75, 40);
            this.buttonVolum.TabIndex = 112;
            this.buttonVolum.Text = "Volumen";
            this.buttonVolum.UseVisualStyleBackColor = true;
            this.buttonVolum.Click += new System.EventHandler(this.buttonVolum_Click);
            // 
            // buttonAB
            // 
            this.buttonAB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAB.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.buttonAB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAB.ForeColor = System.Drawing.Color.DodgerBlue;
            this.buttonAB.Location = new System.Drawing.Point(342, 37);
            this.buttonAB.Name = "buttonAB";
            this.buttonAB.Size = new System.Drawing.Size(75, 40);
            this.buttonAB.TabIndex = 111;
            this.buttonAB.Text = "Área Basal";
            this.buttonAB.UseVisualStyleBackColor = true;
            this.buttonAB.Click += new System.EventHandler(this.buttonAB_Click);
            // 
            // buttonDensi
            // 
            this.buttonDensi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDensi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.buttonDensi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDensi.ForeColor = System.Drawing.Color.DodgerBlue;
            this.buttonDensi.Location = new System.Drawing.Point(261, 37);
            this.buttonDensi.Name = "buttonDensi";
            this.buttonDensi.Size = new System.Drawing.Size(75, 40);
            this.buttonDensi.TabIndex = 110;
            this.buttonDensi.Text = "Densidad";
            this.buttonDensi.UseVisualStyleBackColor = true;
            this.buttonDensi.Click += new System.EventHandler(this.buttonDensi_Click);
            // 
            // buttonDiam
            // 
            this.buttonDiam.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDiam.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.buttonDiam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDiam.ForeColor = System.Drawing.Color.DodgerBlue;
            this.buttonDiam.Location = new System.Drawing.Point(180, 37);
            this.buttonDiam.Name = "buttonDiam";
            this.buttonDiam.Size = new System.Drawing.Size(75, 40);
            this.buttonDiam.TabIndex = 109;
            this.buttonDiam.Text = "Categoría Diámetro";
            this.buttonDiam.UseVisualStyleBackColor = true;
            this.buttonDiam.Click += new System.EventHandler(this.buttonDiam_Click);
            // 
            // buttonAlt
            // 
            this.buttonAlt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAlt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.buttonAlt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAlt.ForeColor = System.Drawing.Color.DodgerBlue;
            this.buttonAlt.Location = new System.Drawing.Point(99, 37);
            this.buttonAlt.Name = "buttonAlt";
            this.buttonAlt.Size = new System.Drawing.Size(75, 40);
            this.buttonAlt.TabIndex = 108;
            this.buttonAlt.Text = "Categoría de altura";
            this.buttonAlt.UseVisualStyleBackColor = true;
            this.buttonAlt.Click += new System.EventHandler(this.buttonAlt_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(491, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 27);
            this.label1.TabIndex = 114;
            this.label1.Text = "Dasometricos";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(663, 49);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 115;
            this.numericUpDown1.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown1.Visible = false;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged_1);
            // 
            // buttonBack
            // 
            this.buttonBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonBack.FlatAppearance.BorderSize = 0;
            this.buttonBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCoral;
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack.Image = ((System.Drawing.Image)(resources.GetObject("buttonBack.Image")));
            this.buttonBack.Location = new System.Drawing.Point(3, 5);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(62, 47);
            this.buttonBack.TabIndex = 132;
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // Dasometricos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelGrafica);
            this.Controls.Add(this.buttonVolum);
            this.Controls.Add(this.buttonAB);
            this.Controls.Add(this.buttonDensi);
            this.Controls.Add(this.buttonDiam);
            this.Controls.Add(this.buttonAlt);
            this.Name = "Dasometricos";
            this.Size = new System.Drawing.Size(1096, 528);
            this.panelGrafica.ResumeLayout(false);
            this.PanelCargando.ResumeLayout(false);
            this.PanelCargando.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LoadingBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelGrafica;
        private System.Windows.Forms.Panel PanelCargando;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox LoadingBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button buttonVolum;
        private System.Windows.Forms.Button buttonAB;
        private System.Windows.Forms.Button buttonDensi;
        private System.Windows.Forms.Button buttonDiam;
        private System.Windows.Forms.Button buttonAlt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button buttonBack;
    }
}
