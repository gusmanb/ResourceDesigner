
namespace ResourceDesigner.Controls
{
    partial class CharEditor
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
            this.drawArea = new ResourceDesigner.Controls.PixelPerfectPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.drawArea)).BeginInit();
            this.SuspendLayout();
            // 
            // drawArea
            // 
            this.drawArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawArea.Location = new System.Drawing.Point(0, 0);
            this.drawArea.Name = "drawArea";
            this.drawArea.Size = new System.Drawing.Size(128, 128);
            this.drawArea.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.drawArea.TabIndex = 0;
            this.drawArea.TabStop = false;
            // 
            // CharEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.drawArea);
            this.MaximumSize = new System.Drawing.Size(128, 128);
            this.MinimumSize = new System.Drawing.Size(128, 128);
            this.Name = "CharEditor";
            this.Size = new System.Drawing.Size(128, 128);
            ((System.ComponentModel.ISupportInitialize)(this.drawArea)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PixelPerfectPictureBox drawArea;
    }
}
