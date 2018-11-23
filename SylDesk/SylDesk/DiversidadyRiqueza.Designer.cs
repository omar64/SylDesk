namespace SylDesk
{
    partial class DiversidadyRiqueza
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DiversidadyRiqueza));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonHer = new System.Windows.Forms.Button();
            this.buttonAr = new System.Windows.Forms.Button();
            this.buttonArb = new System.Windows.Forms.Button();
            this.panelGrafica = new System.Windows.Forms.Panel();
            this.PanelCargando = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LoadingBox = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.panelGrafica.SuspendLayout();
            this.PanelCargando.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LoadingBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(446, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 27);
            this.label1.TabIndex = 115;
            this.label1.Text = "Diversidad y Riqueza";
            // 
            // buttonHer
            // 
            this.buttonHer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonHer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.buttonHer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHer.ForeColor = System.Drawing.Color.DodgerBlue;
            this.buttonHer.Location = new System.Drawing.Point(255, 36);
            this.buttonHer.Name = "buttonHer";
            this.buttonHer.Size = new System.Drawing.Size(75, 40);
            this.buttonHer.TabIndex = 118;
            this.buttonHer.Text = "IVI Herbáceo";
            this.buttonHer.UseVisualStyleBackColor = true;
            this.buttonHer.Click += new System.EventHandler(this.buttonHer_Click);
            // 
            // buttonAr
            // 
            this.buttonAr.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAr.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.buttonAr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAr.ForeColor = System.Drawing.Color.DodgerBlue;
            this.buttonAr.Location = new System.Drawing.Point(174, 36);
            this.buttonAr.Name = "buttonAr";
            this.buttonAr.Size = new System.Drawing.Size(75, 40);
            this.buttonAr.TabIndex = 117;
            this.buttonAr.Text = "IVI Arbustivo";
            this.buttonAr.UseVisualStyleBackColor = true;
            this.buttonAr.Click += new System.EventHandler(this.buttonAr_Click);
            // 
            // buttonArb
            // 
            this.buttonArb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonArb.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.buttonArb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonArb.ForeColor = System.Drawing.Color.DodgerBlue;
            this.buttonArb.Location = new System.Drawing.Point(93, 36);
            this.buttonArb.Name = "buttonArb";
            this.buttonArb.Size = new System.Drawing.Size(75, 40);
            this.buttonArb.TabIndex = 116;
            this.buttonArb.Text = "IVI   Arbóreo";
            this.buttonArb.UseVisualStyleBackColor = true;
            this.buttonArb.Click += new System.EventHandler(this.buttonArb_Click);
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
            this.panelGrafica.TabIndex = 119;
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
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(592, 11);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(483, 417);
            this.dataGridView1.TabIndex = 98;
            // 
            // chart1
            // 
            chartArea4.AxisX.MajorGrid.Enabled = false;
            chartArea4.AxisX.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea4.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea4);
            legend4.Enabled = false;
            legend4.Name = "Legend1";
            this.chart1.Legends.Add(legend4);
            this.chart1.Location = new System.Drawing.Point(13, 11);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(573, 417);
            this.chart1.TabIndex = 97;
            this.chart1.Text = "chart1";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(695, 48);
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
            this.numericUpDown1.TabIndex = 100;
            this.numericUpDown1.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown1.Visible = false;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged_1);
            // 
            // DiversidadyRiqueza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.panelGrafica);
            this.Controls.Add(this.buttonHer);
            this.Controls.Add(this.buttonAr);
            this.Controls.Add(this.buttonArb);
            this.Controls.Add(this.label1);
            this.Name = "DiversidadyRiqueza";
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

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonHer;
        private System.Windows.Forms.Button buttonAr;
        private System.Windows.Forms.Button buttonArb;
        private System.Windows.Forms.Panel panelGrafica;
        private System.Windows.Forms.Panel PanelCargando;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox LoadingBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}
