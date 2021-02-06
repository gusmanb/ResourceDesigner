
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
            this.SuspendLayout();
            // 
            // CharEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.MaximumSize = new System.Drawing.Size(128, 128);
            this.MinimumSize = new System.Drawing.Size(128, 128);
            this.Name = "CharEditor";
            this.Size = new System.Drawing.Size(128, 128);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.CharEditor_DragDrop);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.CharEditor_DragOver);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CharEditor_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CharEditor_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CharEditor_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
