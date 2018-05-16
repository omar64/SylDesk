namespace SylDesk
{
    partial class FormKml
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
            this.mapControl1 = new DevExpress.XtraMap.MapControl();
            this.AbrirKml = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mapControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // mapControl1
            // 
            this.mapControl1.Location = new System.Drawing.Point(14, 17);
            this.mapControl1.Name = "mapControl1";
            this.mapControl1.Size = new System.Drawing.Size(945, 492);
            this.mapControl1.TabIndex = 0;
            // 
            // AbrirKml
            // 
            this.AbrirKml.Location = new System.Drawing.Point(994, 63);
            this.AbrirKml.Name = "AbrirKml";
            this.AbrirKml.Size = new System.Drawing.Size(75, 23);
            this.AbrirKml.TabIndex = 70;
            this.AbrirKml.Text = "Abrir KML";
            this.AbrirKml.UseVisualStyleBackColor = true;
            // 
            // FormKml
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.AbrirKml);
            this.Controls.Add(this.mapControl1);
            this.Name = "FormKml";
            this.Size = new System.Drawing.Size(1096, 528);
            this.Load += new System.EventHandler(this.FormKml_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mapControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraMap.MapControl mapControl1;
        private System.Windows.Forms.Button AbrirKml;
    }
}
