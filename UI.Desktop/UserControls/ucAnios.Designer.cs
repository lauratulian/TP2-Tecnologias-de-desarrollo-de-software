
namespace UI.Desktop.UserControls
{
    partial class ucAnios
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
            this.cbAnios = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cbAnios
            // 
            this.cbAnios.FormattingEnabled = true;
            this.cbAnios.Location = new System.Drawing.Point(0, 0);
            this.cbAnios.Name = "cbAnios";
            this.cbAnios.Size = new System.Drawing.Size(155, 21);
            this.cbAnios.TabIndex = 0;
            this.cbAnios.SelectedIndexChanged += new System.EventHandler(this.cbAnios_SelectedIndexChanged);
            // 
            // ucAnios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbAnios);
            this.Name = "ucAnios";
            this.Size = new System.Drawing.Size(156, 23);
            this.Load += new System.EventHandler(this.ucAnios_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbAnios;
    }
}
