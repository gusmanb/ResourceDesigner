
namespace ResourceDesigner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainToolbar = new System.Windows.Forms.ToolStrip();
            this.newProjectButton = new System.Windows.Forms.ToolStripButton();
            this.openProjectButton = new System.Windows.Forms.ToolStripButton();
            this.saveProjectButton = new System.Windows.Forms.ToolStripButton();
            this.closeProjectButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toClipboardButton = new System.Windows.Forms.ToolStripButton();
            this.toEditorButton = new System.Windows.Forms.ToolStripButton();
            this.toFileButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.addCharSetButton = new System.Windows.Forms.ToolStripButton();
            this.addScreenButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.newAnimationButton = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.mainToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainToolbar
            // 
            this.mainToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newProjectButton,
            this.openProjectButton,
            this.saveProjectButton,
            this.closeProjectButton,
            this.toolStripSeparator2,
            this.toClipboardButton,
            this.toEditorButton,
            this.toFileButton,
            this.toolStripSeparator1,
            this.addCharSetButton,
            this.addScreenButton,
            this.toolStripSeparator3,
            this.newAnimationButton});
            this.mainToolbar.Location = new System.Drawing.Point(0, 0);
            this.mainToolbar.Name = "mainToolbar";
            this.mainToolbar.Size = new System.Drawing.Size(841, 25);
            this.mainToolbar.TabIndex = 1;
            this.mainToolbar.Text = "toolStrip1";
            // 
            // newProjectButton
            // 
            this.newProjectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newProjectButton.Image = ((System.Drawing.Image)(resources.GetObject("newProjectButton.Image")));
            this.newProjectButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newProjectButton.Name = "newProjectButton";
            this.newProjectButton.Size = new System.Drawing.Size(23, 22);
            this.newProjectButton.Text = "New project";
            this.newProjectButton.Click += new System.EventHandler(this.newProjectButton_Click);
            // 
            // openProjectButton
            // 
            this.openProjectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openProjectButton.Image = ((System.Drawing.Image)(resources.GetObject("openProjectButton.Image")));
            this.openProjectButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openProjectButton.Name = "openProjectButton";
            this.openProjectButton.Size = new System.Drawing.Size(23, 22);
            this.openProjectButton.Text = "Open project";
            this.openProjectButton.Click += new System.EventHandler(this.openProjectButton_Click);
            // 
            // saveProjectButton
            // 
            this.saveProjectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveProjectButton.Enabled = false;
            this.saveProjectButton.Image = ((System.Drawing.Image)(resources.GetObject("saveProjectButton.Image")));
            this.saveProjectButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveProjectButton.Name = "saveProjectButton";
            this.saveProjectButton.Size = new System.Drawing.Size(23, 22);
            this.saveProjectButton.Text = "Save project";
            this.saveProjectButton.Click += new System.EventHandler(this.saveProjectButton_Click);
            // 
            // closeProjectButton
            // 
            this.closeProjectButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.closeProjectButton.Enabled = false;
            this.closeProjectButton.Image = ((System.Drawing.Image)(resources.GetObject("closeProjectButton.Image")));
            this.closeProjectButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.closeProjectButton.Name = "closeProjectButton";
            this.closeProjectButton.Size = new System.Drawing.Size(23, 22);
            this.closeProjectButton.Text = "Close project";
            this.closeProjectButton.Click += new System.EventHandler(this.closeProjectButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toClipboardButton
            // 
            this.toClipboardButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toClipboardButton.Enabled = false;
            this.toClipboardButton.Image = ((System.Drawing.Image)(resources.GetObject("toClipboardButton.Image")));
            this.toClipboardButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toClipboardButton.Name = "toClipboardButton";
            this.toClipboardButton.Size = new System.Drawing.Size(23, 22);
            this.toClipboardButton.Text = "Export to clipboard";
            this.toClipboardButton.Click += new System.EventHandler(this.toClipboardButton_Click);
            // 
            // toEditorButton
            // 
            this.toEditorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toEditorButton.Enabled = false;
            this.toEditorButton.Image = ((System.Drawing.Image)(resources.GetObject("toEditorButton.Image")));
            this.toEditorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toEditorButton.Name = "toEditorButton";
            this.toEditorButton.Size = new System.Drawing.Size(23, 22);
            this.toEditorButton.Text = "Export to editor";
            this.toEditorButton.Click += new System.EventHandler(this.toEditorButton_Click);
            // 
            // toFileButton
            // 
            this.toFileButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toFileButton.Enabled = false;
            this.toFileButton.Image = ((System.Drawing.Image)(resources.GetObject("toFileButton.Image")));
            this.toFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toFileButton.Name = "toFileButton";
            this.toFileButton.Size = new System.Drawing.Size(23, 22);
            this.toFileButton.Text = "Export to file";
            this.toFileButton.Click += new System.EventHandler(this.toFileButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // addCharSetButton
            // 
            this.addCharSetButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addCharSetButton.Enabled = false;
            this.addCharSetButton.Image = ((System.Drawing.Image)(resources.GetObject("addCharSetButton.Image")));
            this.addCharSetButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addCharSetButton.Name = "addCharSetButton";
            this.addCharSetButton.Size = new System.Drawing.Size(23, 22);
            this.addCharSetButton.Text = "Add Char set";
            this.addCharSetButton.Click += new System.EventHandler(this.addCharsetButton_Click);
            // 
            // addScreenButton
            // 
            this.addScreenButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addScreenButton.Enabled = false;
            this.addScreenButton.Image = ((System.Drawing.Image)(resources.GetObject("addScreenButton.Image")));
            this.addScreenButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addScreenButton.Name = "addScreenButton";
            this.addScreenButton.Size = new System.Drawing.Size(23, 22);
            this.addScreenButton.Text = "Add screen";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // newAnimationButton
            // 
            this.newAnimationButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newAnimationButton.Enabled = false;
            this.newAnimationButton.Image = ((System.Drawing.Image)(resources.GetObject("newAnimationButton.Image")));
            this.newAnimationButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newAnimationButton.Name = "newAnimationButton";
            this.newAnimationButton.Size = new System.Drawing.Size(23, 22);
            this.newAnimationButton.Text = "New animation window";
            this.newAnimationButton.Click += new System.EventHandler(this.newAnimationButton_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 643);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(841, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 665);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.mainToolbar);
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " GuSprites Resource Designer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.MdiChildActivate += new System.EventHandler(this.MainForm_MdiChildActivate);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.mainToolbar.ResumeLayout(false);
            this.mainToolbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip mainToolbar;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripButton newProject;
        private System.Windows.Forms.ToolStripButton newProjectButton;
        private System.Windows.Forms.ToolStripButton saveProjectButton;
        private System.Windows.Forms.ToolStripButton closeProjectButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton addCharSetButton;
        private System.Windows.Forms.ToolStripButton addScreenButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toClipboardButton;
        private System.Windows.Forms.ToolStripButton toEditorButton;
        private System.Windows.Forms.ToolStripButton toFileButton;
        private System.Windows.Forms.ToolStripButton openProjectButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton newAnimationButton;
    }
}

