
namespace BTMapEditorPlugin
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bgImage = new BTMapEditorPlugin.PixelPerfectPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.bgImage)).BeginInit();
            this.SuspendLayout();
            // 
            // bgImage
            // 
            this.bgImage.Location = new System.Drawing.Point(12, 12);
            this.bgImage.Name = "bgImage";
            this.bgImage.PixelPerfect = true;
            this.bgImage.Size = new System.Drawing.Size(131, 117);
            this.bgImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bgImage.TabIndex = 0;
            this.bgImage.TabStop = false;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.ClientSize = new System.Drawing.Size(158, 146);
            this.Controls.Add(this.bgImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.MainForm_DragEnter);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.MainForm_DragOver);
            this.DragLeave += new System.EventHandler(this.MainForm_DragLeave);
            ((System.ComponentModel.ISupportInitialize)(this.bgImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PixelPerfectPictureBox bgImage;
    }
}

