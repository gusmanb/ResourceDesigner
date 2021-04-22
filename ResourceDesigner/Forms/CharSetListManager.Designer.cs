
namespace ResourceDesigner.Forms
{
    partial class CharSetListManager
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
            this.ctmCharSets = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuUp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDown = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.ctmCharSets.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctmCharSets
            // 
            this.ctmCharSets.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuUp,
            this.mnuDown,
            this.toolStripSeparator1,
            this.mnuDelete});
            this.ctmCharSets.Name = "ctmCharSets";
            this.ctmCharSets.Size = new System.Drawing.Size(138, 76);
            // 
            // mnuUp
            // 
            this.mnuUp.Name = "mnuUp";
            this.mnuUp.Size = new System.Drawing.Size(137, 22);
            this.mnuUp.Text = "Move up";
            this.mnuUp.Click += new System.EventHandler(this.mnuUp_Click);
            // 
            // mnuDown
            // 
            this.mnuDown.Name = "mnuDown";
            this.mnuDown.Size = new System.Drawing.Size(137, 22);
            this.mnuDown.Text = "Move down";
            this.mnuDown.Click += new System.EventHandler(this.mnuDown_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(134, 6);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(137, 22);
            this.mnuDelete.Text = "Delete item";
            this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
            // 
            // CharSetListManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(202, 512);
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CharSetListManager";
            this.Text = "List manager";
            this.ctmCharSets.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip ctmCharSets;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.Windows.Forms.ToolStripMenuItem mnuUp;
        private System.Windows.Forms.ToolStripMenuItem mnuDown;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}