
namespace ResourceDesigner.Forms
{
    partial class CharSetEditor
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

            Export = null;

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CharSetEditor));
            this.actionToolbar = new System.Windows.Forms.ToolStrip();
            this.saveButton = new System.Windows.Forms.ToolStripButton();
            this.duplicateButton = new System.Windows.Forms.ToolStripButton();
            this.discardButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.clipboardButton = new System.Windows.Forms.ToolStripButton();
            this.toEditorButton = new System.Windows.Forms.ToolStripButton();
            this.toFileButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ddScale = new System.Windows.Forms.ToolStripDropDownButton();
            this.mnuScale1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScale2 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScale3 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuScale4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.lineToolButton = new System.Windows.Forms.ToolStripButton();
            this.multiToolButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mirrorHorizontalButton = new System.Windows.Forms.ToolStripButton();
            this.mirrorVerticalButton = new System.Windows.Forms.ToolStripButton();
            this.clearButton = new System.Windows.Forms.ToolStripButton();
            this.actionToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // actionToolbar
            // 
            this.actionToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveButton,
            this.duplicateButton,
            this.discardButton,
            this.toolStripSeparator1,
            this.clipboardButton,
            this.toEditorButton,
            this.toFileButton,
            this.toolStripSeparator2,
            this.ddScale,
            this.toolStripSeparator4,
            this.lineToolButton,
            this.multiToolButton,
            this.toolStripSeparator3,
            this.mirrorHorizontalButton,
            this.mirrorVerticalButton,
            this.clearButton});
            this.actionToolbar.Location = new System.Drawing.Point(0, 0);
            this.actionToolbar.Name = "actionToolbar";
            this.actionToolbar.Size = new System.Drawing.Size(433, 25);
            this.actionToolbar.TabIndex = 0;
            this.actionToolbar.Text = "toolStrip1";
            // 
            // saveButton
            // 
            this.saveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveButton.Image = ((System.Drawing.Image)(resources.GetObject("saveButton.Image")));
            this.saveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(23, 22);
            this.saveButton.Text = "Save";
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // duplicateButton
            // 
            this.duplicateButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.duplicateButton.Image = ((System.Drawing.Image)(resources.GetObject("duplicateButton.Image")));
            this.duplicateButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.duplicateButton.Name = "duplicateButton";
            this.duplicateButton.Size = new System.Drawing.Size(23, 22);
            this.duplicateButton.Text = "Duplicate";
            this.duplicateButton.Click += new System.EventHandler(this.duplicateButton_Click);
            // 
            // discardButton
            // 
            this.discardButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.discardButton.Image = ((System.Drawing.Image)(resources.GetObject("discardButton.Image")));
            this.discardButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.discardButton.Name = "discardButton";
            this.discardButton.Size = new System.Drawing.Size(23, 22);
            this.discardButton.Text = "Discard";
            this.discardButton.Click += new System.EventHandler(this.discardButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // clipboardButton
            // 
            this.clipboardButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.clipboardButton.Image = ((System.Drawing.Image)(resources.GetObject("clipboardButton.Image")));
            this.clipboardButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clipboardButton.Name = "clipboardButton";
            this.clipboardButton.Size = new System.Drawing.Size(23, 22);
            this.clipboardButton.Text = "Copy to clipboard";
            this.clipboardButton.Click += new System.EventHandler(this.clipboardButton_Click);
            // 
            // toEditorButton
            // 
            this.toEditorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toEditorButton.Image = ((System.Drawing.Image)(resources.GetObject("toEditorButton.Image")));
            this.toEditorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toEditorButton.Name = "toEditorButton";
            this.toEditorButton.Size = new System.Drawing.Size(23, 22);
            this.toEditorButton.Text = "Send to text editor";
            this.toEditorButton.Click += new System.EventHandler(this.toEditorButton_Click);
            // 
            // toFileButton
            // 
            this.toFileButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toFileButton.Image = ((System.Drawing.Image)(resources.GetObject("toFileButton.Image")));
            this.toFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toFileButton.Name = "toFileButton";
            this.toFileButton.Size = new System.Drawing.Size(23, 22);
            this.toFileButton.Text = "Export as file";
            this.toFileButton.Click += new System.EventHandler(this.toFileButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // ddScale
            // 
            this.ddScale.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ddScale.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuScale1,
            this.mnuScale2,
            this.mnuScale3,
            this.mnuScale4});
            this.ddScale.Image = ((System.Drawing.Image)(resources.GetObject("ddScale.Image")));
            this.ddScale.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ddScale.Name = "ddScale";
            this.ddScale.Size = new System.Drawing.Size(29, 22);
            this.ddScale.Text = "x1";
            // 
            // mnuScale1
            // 
            this.mnuScale1.Name = "mnuScale1";
            this.mnuScale1.Size = new System.Drawing.Size(86, 22);
            this.mnuScale1.Text = "x1";
            this.mnuScale1.Click += new System.EventHandler(this.mnuScale1_Click);
            // 
            // mnuScale2
            // 
            this.mnuScale2.Name = "mnuScale2";
            this.mnuScale2.Size = new System.Drawing.Size(86, 22);
            this.mnuScale2.Text = "x2";
            this.mnuScale2.Click += new System.EventHandler(this.mnuScale2_Click);
            // 
            // mnuScale3
            // 
            this.mnuScale3.Name = "mnuScale3";
            this.mnuScale3.Size = new System.Drawing.Size(86, 22);
            this.mnuScale3.Text = "x3";
            this.mnuScale3.Click += new System.EventHandler(this.mnuScale3_Click);
            // 
            // mnuScale4
            // 
            this.mnuScale4.Name = "mnuScale4";
            this.mnuScale4.Size = new System.Drawing.Size(86, 22);
            this.mnuScale4.Text = "x4";
            this.mnuScale4.Click += new System.EventHandler(this.mnuScale4_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // lineToolButton
            // 
            this.lineToolButton.CheckOnClick = true;
            this.lineToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lineToolButton.Image = ((System.Drawing.Image)(resources.GetObject("lineToolButton.Image")));
            this.lineToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lineToolButton.Name = "lineToolButton";
            this.lineToolButton.Size = new System.Drawing.Size(23, 22);
            this.lineToolButton.Text = "Line tool";
            this.lineToolButton.CheckedChanged += new System.EventHandler(this.lineToolButton_CheckedChanged);
            // 
            // multiToolButton
            // 
            this.multiToolButton.CheckOnClick = true;
            this.multiToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.multiToolButton.Image = ((System.Drawing.Image)(resources.GetObject("multiToolButton.Image")));
            this.multiToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.multiToolButton.Name = "multiToolButton";
            this.multiToolButton.Size = new System.Drawing.Size(23, 22);
            this.multiToolButton.Text = "Multiline tool";
            this.multiToolButton.Click += new System.EventHandler(this.multiToolButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // mirrorHorizontalButton
            // 
            this.mirrorHorizontalButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mirrorHorizontalButton.Image = ((System.Drawing.Image)(resources.GetObject("mirrorHorizontalButton.Image")));
            this.mirrorHorizontalButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mirrorHorizontalButton.Name = "mirrorHorizontalButton";
            this.mirrorHorizontalButton.Size = new System.Drawing.Size(23, 22);
            this.mirrorHorizontalButton.Text = "Horizontal mirror";
            this.mirrorHorizontalButton.Click += new System.EventHandler(this.mirrorHorizontalButton_Click);
            // 
            // mirrorVerticalButton
            // 
            this.mirrorVerticalButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mirrorVerticalButton.Image = ((System.Drawing.Image)(resources.GetObject("mirrorVerticalButton.Image")));
            this.mirrorVerticalButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mirrorVerticalButton.Name = "mirrorVerticalButton";
            this.mirrorVerticalButton.Size = new System.Drawing.Size(23, 22);
            this.mirrorVerticalButton.Text = "Vertical mirror";
            this.mirrorVerticalButton.Click += new System.EventHandler(this.mirrorVerticalButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.clearButton.Image = ((System.Drawing.Image)(resources.GetObject("clearButton.Image")));
            this.clearButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(23, 22);
            this.clearButton.Text = "Clear";
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // CharSetEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 366);
            this.Controls.Add(this.actionToolbar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CharSetEditor";
            this.Text = "CharSet Editor";
            this.actionToolbar.ResumeLayout(false);
            this.actionToolbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip actionToolbar;
        private System.Windows.Forms.ToolStripButton clearButton;
        private System.Windows.Forms.ToolStripButton saveButton;
        private System.Windows.Forms.ToolStripButton discardButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton clipboardButton;
        private System.Windows.Forms.ToolStripButton toEditorButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton mirrorHorizontalButton;
        private System.Windows.Forms.ToolStripButton mirrorVerticalButton;
        private System.Windows.Forms.ToolStripButton toFileButton;
        private System.Windows.Forms.ToolStripButton duplicateButton;
        private System.Windows.Forms.ToolStripButton lineToolButton;
        private System.Windows.Forms.ToolStripButton multiToolButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripDropDownButton ddScale;
        private System.Windows.Forms.ToolStripMenuItem mnuScale1;
        private System.Windows.Forms.ToolStripMenuItem mnu;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem mnuScale2;
        private System.Windows.Forms.ToolStripMenuItem mnuScale3;
        private System.Windows.Forms.ToolStripMenuItem mnuScale4;
    }
}