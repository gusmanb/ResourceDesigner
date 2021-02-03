
namespace ResourceDesigner.Forms
{
    partial class AnimationViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.animPic = new ResourceDesigner.Controls.PixelPerfectPictureBox();
            this.animTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.animPic)).BeginInit();
            this.SuspendLayout();
            // 
            // animPic
            // 
            this.animPic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.animPic.Location = new System.Drawing.Point(0, 0);
            this.animPic.Name = "animPic";
            this.animPic.PixelPerfect = true;
            this.animPic.Size = new System.Drawing.Size(243, 232);
            this.animPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.animPic.TabIndex = 0;
            this.animPic.TabStop = false;
            this.animPic.DragDrop += new System.Windows.Forms.DragEventHandler(this.animPic_DragDrop);
            this.animPic.DragOver += new System.Windows.Forms.DragEventHandler(this.animPic_DragOver);
            // 
            // animTimer
            // 
            this.animTimer.Enabled = true;
            this.animTimer.Interval = 500;
            this.animTimer.Tick += new System.EventHandler(this.animTimer_Tick);
            // 
            // AnimationViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 232);
            this.Controls.Add(this.animPic);
            this.Name = "AnimationViewer";
            this.Text = "Animation viewer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AnimationViewer_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.animPic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.PixelPerfectPictureBox animPic;
        private System.Windows.Forms.Timer animTimer;
    }
}