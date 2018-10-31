namespace SylDesk
{
    partial class Grafica
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Grafica));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.label1 = new System.Windows.Forms.Label();
            this.button17 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.ReportButton = new System.Windows.Forms.Button();
            this.TipBox = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panelGrafica = new System.Windows.Forms.Panel();
            this.PanelCargando = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LoadingBox = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TipBox)).BeginInit();
            this.panelGrafica.SuspendLayout();
            this.PanelCargando.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LoadingBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(553, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Graficas";
            // 
            // button17
            // 
            this.button17.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button17.FlatAppearance.BorderSize = 0;
            this.button17.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightCoral;
            this.button17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button17.Image = ((System.Drawing.Image)(resources.GetObject("button17.Image")));
            this.button17.Location = new System.Drawing.Point(3, 5);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(62, 47);
            this.button17.TabIndex = 74;
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.button1.Location = new System.Drawing.Point(99, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 40);
            this.button1.TabIndex = 83;
            this.button1.Text = "Categoría de altura";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.DodgerBlue;
            this.button2.Location = new System.Drawing.Point(180, 40);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 40);
            this.button2.TabIndex = 84;
            this.button2.Text = "Categoría Diámetro";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.DodgerBlue;
            this.button3.Location = new System.Drawing.Point(261, 40);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 40);
            this.button3.TabIndex = 85;
            this.button3.Text = "Densidad";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.Color.DodgerBlue;
            this.button4.Location = new System.Drawing.Point(342, 40);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 40);
            this.button4.TabIndex = 86;
            this.button4.Text = "Área Basal";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.ForeColor = System.Drawing.Color.DodgerBlue;
            this.button5.Location = new System.Drawing.Point(423, 40);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 40);
            this.button5.TabIndex = 87;
            this.button5.Text = "Volumen";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(810, 52);
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
            this.numericUpDown1.TabIndex = 89;
            this.numericUpDown1.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown1.Visible = false;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // button6
            // 
            this.button6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.ForeColor = System.Drawing.Color.DodgerBlue;
            this.button6.Location = new System.Drawing.Point(504, 40);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 40);
            this.button6.TabIndex = 91;
            this.button6.Text = "IVI   Arbóreo";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.ForeColor = System.Drawing.Color.DodgerBlue;
            this.button7.Location = new System.Drawing.Point(585, 40);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 40);
            this.button7.TabIndex = 92;
            this.button7.Text = "IVI Arbustivo";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.ForeColor = System.Drawing.Color.DodgerBlue;
            this.button8.Location = new System.Drawing.Point(666, 40);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 40);
            this.button8.TabIndex = 93;
            this.button8.Text = "IVI Herbáceo";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // ReportButton
            // 
            this.ReportButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ReportButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightBlue;
            this.ReportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReportButton.ForeColor = System.Drawing.Color.DodgerBlue;
            this.ReportButton.Image = ((System.Drawing.Image)(resources.GetObject("ReportButton.Image")));
            this.ReportButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ReportButton.Location = new System.Drawing.Point(954, 40);
            this.ReportButton.Name = "ReportButton";
            this.ReportButton.Size = new System.Drawing.Size(124, 40);
            this.ReportButton.TabIndex = 94;
            this.ReportButton.Text = "Reporte";
            this.ReportButton.UseVisualStyleBackColor = true;
            this.ReportButton.Click += new System.EventHandler(this.ReportButton_Click);
            // 
            // TipBox
            // 
            this.TipBox.Cursor = System.Windows.Forms.Cursors.Help;
            this.TipBox.Image = ((System.Drawing.Image)(resources.GetObject("TipBox.Image")));
            this.TipBox.Location = new System.Drawing.Point(1052, 3);
            this.TipBox.Name = "TipBox";
            this.TipBox.Size = new System.Drawing.Size(23, 22);
            this.TipBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.TipBox.TabIndex = 106;
            this.TipBox.TabStop = false;
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 25000;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ReshowDelay = 100;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Graficas";
            // 
            // panelGrafica
            // 
            this.panelGrafica.BackColor = System.Drawing.Color.Gainsboro;
            this.panelGrafica.Controls.Add(this.PanelCargando);
            this.panelGrafica.Controls.Add(this.dataGridView1);
            this.panelGrafica.Controls.Add(this.chart1);
            this.panelGrafica.Location = new System.Drawing.Point(3, 86);
            this.panelGrafica.Name = "panelGrafica";
            this.panelGrafica.Size = new System.Drawing.Size(1090, 439);
            this.panelGrafica.TabIndex = 107;
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
            // Grafica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelGrafica);
            this.Controls.Add(this.TipBox);
            this.Controls.Add(this.ReportButton);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button17);
            this.Controls.Add(this.label1);
            this.Name = "Grafica";
            this.Size = new System.Drawing.Size(1096, 528);
            this.Load += new System.EventHandler(this.Grafica_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TipBox)).EndInit();
            this.panelGrafica.ResumeLayout(false);
            this.PanelCargando.ResumeLayout(false);
            this.PanelCargando.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LoadingBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button17;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button ReportButton;
        private System.Windows.Forms.PictureBox TipBox;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panelGrafica;
        private System.Windows.Forms.Panel PanelCargando;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox LoadingBox;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}
