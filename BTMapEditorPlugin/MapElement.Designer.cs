
namespace BTMapEditorPlugin
{
    partial class MapElement
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
            this.elementView = new BTMapEditorPlugin.PixelPerfectPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.elementView)).BeginInit();
            this.SuspendLayout();
            // 
            // elementView
            // 
            this.elementView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementView.Location = new System.Drawing.Point(0, 0);
            this.elementView.Name = "elementView";
            this.elementView.PixelPerfect = true;
            this.elementView.Size = new System.Drawing.Size(150, 150);
            this.elementView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.elementView.TabIndex = 0;
            this.elementView.TabStop = false;
            // 
            // MapElement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.elementView);
            this.Name = "MapElement";
            ((System.ComponentModel.ISupportInitialize)(this.elementView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PixelPerfectPictureBox elementView;
    }
}
