namespace SylDesk
{
    partial class ValordeImportancia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ValordeImportancia));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.label1 = new System.Windows.Forms.Label();
            this.panelGrafica = new System.Windows.Forms.Panel();
            this.PanelCargando = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LoadingBox = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.buttonIVI3 = new System.Windows.Forms.Button();
            this.buttonIVI2 = new System.Windows.Forms.Button();
            this.buttonIVI1 = new System.Windows.Forms.Button();
            this.buttonIVI4 = new System.Windows.Forms.Button();
            this.buttonback = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panelGrafica.SuspendLayout();
            this.PanelCargando.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LoadingBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(446, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 27);
            this.label1.TabIndex = 116;
            this.label1.Text = "Valor de Importancia";
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
            this.panelGrafica.TabIndex = 120;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(592, 11);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(483, 417);
            this.dataGridView1.TabIndex = 98;
            // 
            // chart1
            // 
            chartArea2.AxisX.MajorGrid.Enabled = false;
            chartArea2.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Enabled = false;
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(13, 11);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(573, 417);
            this.chart1.TabIndex = 97;
            this.chart1.Text = "chart1";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown1.Location = new System.Drawing.Point(885, 57);
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
            this.numericUpDown1.Size = new System.Drawing.Size(120, 22);
            this.numericUpDown1.TabIndex = 121;
            this.numericUpDown1.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown1.Visible = false;
            // 
            // buttonIVI3
            // 
            this.buttonIVI3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonIVI3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.buttonIVI3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonIVI3.ForeColor = System.Drawing.Color.DodgerBlue;
            this.buttonIVI3.Location = new System.Drawing.Point(266, 37);
            this.buttonIVI3.Name = "buttonIVI3";
            this.buttonIVI3.Size = new System.Drawing.Size(75, 40);
            this.buttonIVI3.TabIndex = 124;
            this.buttonIVI3.Text = "IVI 3";
            this.buttonIVI3.UseVisualStyleBackColor = true;
            this.buttonIVI3.Click += new System.EventHandler(this.buttonIVI3_Click);
            // 
            // buttonIVI2
            // 
            this.buttonIVI2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonIVI2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.buttonIVI2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonIVI2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.buttonIVI2.Location = new System.Drawing.Point(185, 37);
            this.buttonIVI2.Name = "buttonIVI2";
            this.buttonIVI2.Size = new System.Drawing.Size(75, 40);
            this.buttonIVI2.TabIndex = 123;
            this.buttonIVI2.Text = "IVI 2";
            this.buttonIVI2.UseVisualStyleBackColor = true;
            this.buttonIVI2.Click += new System.EventHandler(this.buttonIVI2_Click);
            // 
            // buttonIVI1
            // 
            this.buttonIVI1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonIVI1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.buttonIVI1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonIVI1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.buttonIVI1.Location = new System.Drawing.Point(104, 37);
            this.buttonIVI1.Name = "buttonIVI1";
            this.buttonIVI1.Size = new System.Drawing.Size(75, 40);
            this.buttonIVI1.TabIndex = 122;
            this.buttonIVI1.Text = "IVI  1";
            this.buttonIVI1.UseVisualStyleBackColor = true;
            this.buttonIVI1.Click += new System.EventHandler(this.buttonIVI1_Click);
            // 
            // buttonIVI4
            // 
            this.buttonIVI4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonIVI4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.buttonIVI4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonIVI4.ForeColor = System.Drawing.Color.DodgerBlue;
            this.buttonIVI4.Location = new System.Drawing.Point(347, 37);
            this.buttonIVI4.Name = "buttonIVI4";
            this.buttonIVI4.Size = new System.Drawing.Size(75, 40);
            this.buttonIVI4.TabIndex = 125;
            this.buttonIVI4.Text = "IVI 4";
            this.buttonIVI4.UseVisualStyleBackColor = true;
            this.buttonIVI4.Click += new System.EventHandler(this.buttonIVI4_Click);
            // 
            // buttonback
            // 
            this.buttonback.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonback.FlatAppearance.BorderSize = 0;
            this.buttonback.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCoral;
            this.buttonback.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonback.Image = ((System.Drawing.Image)(resources.GetObject("buttonback.Image")));
            this.buttonback.Location = new System.Drawing.Point(3, 5);
            this.buttonback.Name = "buttonback";
            this.buttonback.Size = new System.Drawing.Size(62, 47);
            this.buttonback.TabIndex = 132;
            this.buttonback.UseVisualStyleBackColor = true;
            this.buttonback.Click += new System.EventHandler(this.buttonback_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(412, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(28, 27);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 133;
            this.pictureBox2.TabStop = false;
            // 
            // ValordeImportancia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.buttonback);
            this.Controls.Add(this.buttonIVI4);
            this.Controls.Add(this.buttonIVI3);
            this.Controls.Add(this.buttonIVI2);
            this.Controls.Add(this.buttonIVI1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.panelGrafica);
            this.Controls.Add(this.label1);
            this.Name = "ValordeImportancia";
            this.Size = new System.Drawing.Size(1096, 528);
            this.panelGrafica.ResumeLayout(false);
            this.PanelCargando.ResumeLayout(false);
            this.PanelCargando.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LoadingBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelGrafica;
        private System.Windows.Forms.Panel PanelCargando;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox LoadingBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button buttonIVI3;
        private System.Windows.Forms.Button buttonIVI2;
        private System.Windows.Forms.Button buttonIVI1;
        private System.Windows.Forms.Button buttonIVI4;
        private System.Windows.Forms.Button buttonback;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}
