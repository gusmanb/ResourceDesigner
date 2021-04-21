
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
            this.bitmapImportButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
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
            this.inkButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.inkBlackMnu = new System.Windows.Forms.ToolStripMenuItem();
            this.inkBlueMnu = new System.Windows.Forms.ToolStripMenuItem();
            this.inkRedMnu = new System.Windows.Forms.ToolStripMenuItem();
            this.inkFuchsiaMnu = new System.Windows.Forms.ToolStripMenuItem();
            this.inkGreenMnu = new System.Windows.Forms.ToolStripMenuItem();
            this.inkCyanMnu = new System.Windows.Forms.ToolStripMenuItem();
            this.inkYellowMnu = new System.Windows.Forms.ToolStripMenuItem();
            this.inkWhiteMnu = new System.Windows.Forms.ToolStripMenuItem();
            this.paperButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.paperBlackMnu = new System.Windows.Forms.ToolStripMenuItem();
            this.paperBlueMnu = new System.Windows.Forms.ToolStripMenuItem();
            this.paperRedMnu = new System.Windows.Forms.ToolStripMenuItem();
            this.paperFuchsiaMnu = new System.Windows.Forms.ToolStripMenuItem();
            this.paperGreenMnu = new System.Windows.Forms.ToolStripMenuItem();
            this.paperCyanMnu = new System.Windows.Forms.ToolStripMenuItem();
            this.paperYellowMnu = new System.Windows.Forms.ToolStripMenuItem();
            this.paperWhiteMnu = new System.Windows.Forms.ToolStripMenuItem();
            this.brightButton = new System.Windows.Forms.ToolStripButton();
            this.flashButton = new System.Windows.Forms.ToolStripButton();
            this.lblDrop = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.mirrorHorizontalButton = new System.Windows.Forms.ToolStripButton();
            this.mirrorVerticalButton = new System.Windows.Forms.ToolStripButton();
            this.upButton = new System.Windows.Forms.ToolStripButton();
            this.downButton = new System.Windows.Forms.ToolStripButton();
            this.leftButton = new System.Windows.Forms.ToolStripButton();
            this.rightButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.lineToolButton = new System.Windows.Forms.ToolStripButton();
            this.multiToolButton = new System.Windows.Forms.ToolStripButton();
            this.clearButton = new System.Windows.Forms.ToolStripButton();
            this.renameButton = new System.Windows.Forms.ToolStripButton();
            this.actionToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // actionToolbar
            // 
            this.actionToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveButton,
            this.duplicateButton,
            this.renameButton,
            this.discardButton,
            this.toolStripSeparator1,
            this.bitmapImportButton,
            this.toolStripSeparator6,
            this.clipboardButton,
            this.toEditorButton,
            this.toFileButton,
            this.toolStripSeparator2,
            this.ddScale,
            this.toolStripSeparator4,
            this.inkButton,
            this.paperButton,
            this.brightButton,
            this.flashButton,
            this.lblDrop,
            this.toolStripSeparator5,
            this.mirrorHorizontalButton,
            this.mirrorVerticalButton,
            this.upButton,
            this.downButton,
            this.leftButton,
            this.rightButton,
            this.toolStripSeparator3,
            this.lineToolButton,
            this.multiToolButton,
            this.clearButton});
            this.actionToolbar.Location = new System.Drawing.Point(0, 0);
            this.actionToolbar.Name = "actionToolbar";
            this.actionToolbar.Size = new System.Drawing.Size(561, 25);
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
            // bitmapImportButton
            // 
            this.bitmapImportButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bitmapImportButton.Image = ((System.Drawing.Image)(resources.GetObject("bitmapImportButton.Image")));
            this.bitmapImportButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bitmapImportButton.Name = "bitmapImportButton";
            this.bitmapImportButton.Size = new System.Drawing.Size(23, 22);
            this.bitmapImportButton.Text = "Bitmap import";
            this.bitmapImportButton.Click += new System.EventHandler(this.bitmapImportButton_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
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
            // inkButton
            // 
            this.inkButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.inkButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inkBlackMnu,
            this.inkBlueMnu,
            this.inkRedMnu,
            this.inkFuchsiaMnu,
            this.inkGreenMnu,
            this.inkCyanMnu,
            this.inkYellowMnu,
            this.inkWhiteMnu});
            this.inkButton.Image = ((System.Drawing.Image)(resources.GetObject("inkButton.Image")));
            this.inkButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.inkButton.Name = "inkButton";
            this.inkButton.Size = new System.Drawing.Size(29, 22);
            this.inkButton.Text = "Ink color";
            // 
            // inkBlackMnu
            // 
            this.inkBlackMnu.Image = ((System.Drawing.Image)(resources.GetObject("inkBlackMnu.Image")));
            this.inkBlackMnu.Name = "inkBlackMnu";
            this.inkBlackMnu.Size = new System.Drawing.Size(114, 22);
            this.inkBlackMnu.Text = "Black";
            this.inkBlackMnu.Click += new System.EventHandler(this.InkMenu_Click);
            // 
            // inkBlueMnu
            // 
            this.inkBlueMnu.Image = ((System.Drawing.Image)(resources.GetObject("inkBlueMnu.Image")));
            this.inkBlueMnu.Name = "inkBlueMnu";
            this.inkBlueMnu.Size = new System.Drawing.Size(114, 22);
            this.inkBlueMnu.Text = "Blue";
            this.inkBlueMnu.Click += new System.EventHandler(this.InkMenu_Click);
            // 
            // inkRedMnu
            // 
            this.inkRedMnu.Image = ((System.Drawing.Image)(resources.GetObject("inkRedMnu.Image")));
            this.inkRedMnu.Name = "inkRedMnu";
            this.inkRedMnu.Size = new System.Drawing.Size(114, 22);
            this.inkRedMnu.Text = "Red";
            this.inkRedMnu.Click += new System.EventHandler(this.InkMenu_Click);
            // 
            // inkFuchsiaMnu
            // 
            this.inkFuchsiaMnu.Image = ((System.Drawing.Image)(resources.GetObject("inkFuchsiaMnu.Image")));
            this.inkFuchsiaMnu.Name = "inkFuchsiaMnu";
            this.inkFuchsiaMnu.Size = new System.Drawing.Size(114, 22);
            this.inkFuchsiaMnu.Text = "Fuchsia";
            this.inkFuchsiaMnu.Click += new System.EventHandler(this.InkMenu_Click);
            // 
            // inkGreenMnu
            // 
            this.inkGreenMnu.Image = ((System.Drawing.Image)(resources.GetObject("inkGreenMnu.Image")));
            this.inkGreenMnu.Name = "inkGreenMnu";
            this.inkGreenMnu.Size = new System.Drawing.Size(114, 22);
            this.inkGreenMnu.Text = "Green";
            this.inkGreenMnu.Click += new System.EventHandler(this.InkMenu_Click);
            // 
            // inkCyanMnu
            // 
            this.inkCyanMnu.Image = ((System.Drawing.Image)(resources.GetObject("inkCyanMnu.Image")));
            this.inkCyanMnu.Name = "inkCyanMnu";
            this.inkCyanMnu.Size = new System.Drawing.Size(114, 22);
            this.inkCyanMnu.Text = "Cyan";
            this.inkCyanMnu.Click += new System.EventHandler(this.InkMenu_Click);
            // 
            // inkYellowMnu
            // 
            this.inkYellowMnu.Image = ((System.Drawing.Image)(resources.GetObject("inkYellowMnu.Image")));
            this.inkYellowMnu.Name = "inkYellowMnu";
            this.inkYellowMnu.Size = new System.Drawing.Size(114, 22);
            this.inkYellowMnu.Text = "Yellow";
            this.inkYellowMnu.Click += new System.EventHandler(this.InkMenu_Click);
            // 
            // inkWhiteMnu
            // 
            this.inkWhiteMnu.Image = ((System.Drawing.Image)(resources.GetObject("inkWhiteMnu.Image")));
            this.inkWhiteMnu.Name = "inkWhiteMnu";
            this.inkWhiteMnu.Size = new System.Drawing.Size(114, 22);
            this.inkWhiteMnu.Text = "White";
            this.inkWhiteMnu.Click += new System.EventHandler(this.InkMenu_Click);
            // 
            // paperButton
            // 
            this.paperButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.paperButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.paperBlackMnu,
            this.paperBlueMnu,
            this.paperRedMnu,
            this.paperFuchsiaMnu,
            this.paperGreenMnu,
            this.paperCyanMnu,
            this.paperYellowMnu,
            this.paperWhiteMnu});
            this.paperButton.Image = ((System.Drawing.Image)(resources.GetObject("paperButton.Image")));
            this.paperButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.paperButton.Name = "paperButton";
            this.paperButton.Size = new System.Drawing.Size(29, 22);
            this.paperButton.Text = "Paper color";
            // 
            // paperBlackMnu
            // 
            this.paperBlackMnu.Image = ((System.Drawing.Image)(resources.GetObject("paperBlackMnu.Image")));
            this.paperBlackMnu.Name = "paperBlackMnu";
            this.paperBlackMnu.Size = new System.Drawing.Size(114, 22);
            this.paperBlackMnu.Text = "Black";
            this.paperBlackMnu.Click += new System.EventHandler(this.PaperMnu_Click);
            // 
            // paperBlueMnu
            // 
            this.paperBlueMnu.Image = ((System.Drawing.Image)(resources.GetObject("paperBlueMnu.Image")));
            this.paperBlueMnu.Name = "paperBlueMnu";
            this.paperBlueMnu.Size = new System.Drawing.Size(114, 22);
            this.paperBlueMnu.Text = "Blue";
            this.paperBlueMnu.Click += new System.EventHandler(this.PaperMnu_Click);
            // 
            // paperRedMnu
            // 
            this.paperRedMnu.Image = ((System.Drawing.Image)(resources.GetObject("paperRedMnu.Image")));
            this.paperRedMnu.Name = "paperRedMnu";
            this.paperRedMnu.Size = new System.Drawing.Size(114, 22);
            this.paperRedMnu.Text = "Red";
            this.paperRedMnu.Click += new System.EventHandler(this.PaperMnu_Click);
            // 
            // paperFuchsiaMnu
            // 
            this.paperFuchsiaMnu.Image = ((System.Drawing.Image)(resources.GetObject("paperFuchsiaMnu.Image")));
            this.paperFuchsiaMnu.Name = "paperFuchsiaMnu";
            this.paperFuchsiaMnu.Size = new System.Drawing.Size(114, 22);
            this.paperFuchsiaMnu.Text = "Fuchsia";
            this.paperFuchsiaMnu.Click += new System.EventHandler(this.PaperMnu_Click);
            // 
            // paperGreenMnu
            // 
            this.paperGreenMnu.Image = ((System.Drawing.Image)(resources.GetObject("paperGreenMnu.Image")));
            this.paperGreenMnu.Name = "paperGreenMnu";
            this.paperGreenMnu.Size = new System.Drawing.Size(114, 22);
            this.paperGreenMnu.Text = "Green";
            this.paperGreenMnu.Click += new System.EventHandler(this.PaperMnu_Click);
            // 
            // paperCyanMnu
            // 
            this.paperCyanMnu.Image = ((System.Drawing.Image)(resources.GetObject("paperCyanMnu.Image")));
            this.paperCyanMnu.Name = "paperCyanMnu";
            this.paperCyanMnu.Size = new System.Drawing.Size(114, 22);
            this.paperCyanMnu.Text = "Cyan";
            this.paperCyanMnu.Click += new System.EventHandler(this.PaperMnu_Click);
            // 
            // paperYellowMnu
            // 
            this.paperYellowMnu.Image = ((System.Drawing.Image)(resources.GetObject("paperYellowMnu.Image")));
            this.paperYellowMnu.Name = "paperYellowMnu";
            this.paperYellowMnu.Size = new System.Drawing.Size(114, 22);
            this.paperYellowMnu.Text = "Yellow";
            this.paperYellowMnu.Click += new System.EventHandler(this.PaperMnu_Click);
            // 
            // paperWhiteMnu
            // 
            this.paperWhiteMnu.Image = ((System.Drawing.Image)(resources.GetObject("paperWhiteMnu.Image")));
            this.paperWhiteMnu.Name = "paperWhiteMnu";
            this.paperWhiteMnu.Size = new System.Drawing.Size(114, 22);
            this.paperWhiteMnu.Text = "White";
            this.paperWhiteMnu.Click += new System.EventHandler(this.PaperMnu_Click);
            // 
            // brightButton
            // 
            this.brightButton.CheckOnClick = true;
            this.brightButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.brightButton.Image = ((System.Drawing.Image)(resources.GetObject("brightButton.Image")));
            this.brightButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.brightButton.Name = "brightButton";
            this.brightButton.Size = new System.Drawing.Size(23, 22);
            this.brightButton.Text = "Brightness";
            this.brightButton.Click += new System.EventHandler(this.brightButton_Click);
            // 
            // flashButton
            // 
            this.flashButton.CheckOnClick = true;
            this.flashButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.flashButton.Image = ((System.Drawing.Image)(resources.GetObject("flashButton.Image")));
            this.flashButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.flashButton.Name = "flashButton";
            this.flashButton.Size = new System.Drawing.Size(23, 22);
            this.flashButton.Text = "Flash";
            this.flashButton.Click += new System.EventHandler(this.flashButton_Click);
            // 
            // lblDrop
            // 
            this.lblDrop.AutoSize = false;
            this.lblDrop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("lblDrop.BackgroundImage")));
            this.lblDrop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lblDrop.Margin = new System.Windows.Forms.Padding(10, 1, 10, 2);
            this.lblDrop.Name = "lblDrop";
            this.lblDrop.Size = new System.Drawing.Size(16, 16);
            this.lblDrop.Text = "Drop to char to set its color";
            this.lblDrop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblDrop_MouseMove);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
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
            // upButton
            // 
            this.upButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.upButton.Image = ((System.Drawing.Image)(resources.GetObject("upButton.Image")));
            this.upButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(23, 22);
            this.upButton.Text = "Shift up";
            this.upButton.Click += new System.EventHandler(this.upButton_Click);
            // 
            // downButton
            // 
            this.downButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.downButton.Image = ((System.Drawing.Image)(resources.GetObject("downButton.Image")));
            this.downButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(23, 22);
            this.downButton.Text = "Shift down";
            this.downButton.Click += new System.EventHandler(this.downButton_Click);
            // 
            // leftButton
            // 
            this.leftButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.leftButton.Image = ((System.Drawing.Image)(resources.GetObject("leftButton.Image")));
            this.leftButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.leftButton.Name = "leftButton";
            this.leftButton.Size = new System.Drawing.Size(23, 22);
            this.leftButton.Text = "Shift left";
            this.leftButton.Click += new System.EventHandler(this.leftButton_Click);
            // 
            // rightButton
            // 
            this.rightButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rightButton.Image = ((System.Drawing.Image)(resources.GetObject("rightButton.Image")));
            this.rightButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rightButton.Name = "rightButton";
            this.rightButton.Size = new System.Drawing.Size(23, 22);
            this.rightButton.Text = "Shift right";
            this.rightButton.Click += new System.EventHandler(this.rightButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
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
            this.multiToolButton.Size = new System.Drawing.Size(23, 20);
            this.multiToolButton.Text = "Multiline tool";
            this.multiToolButton.Click += new System.EventHandler(this.multiToolButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.clearButton.Image = ((System.Drawing.Image)(resources.GetObject("clearButton.Image")));
            this.clearButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(23, 20);
            this.clearButton.Text = "Clear";
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // renameButton
            // 
            this.renameButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.renameButton.Image = ((System.Drawing.Image)(resources.GetObject("renameButton.Image")));
            this.renameButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.renameButton.Name = "renameButton";
            this.renameButton.Size = new System.Drawing.Size(23, 22);
            this.renameButton.Text = "Rename";
            this.renameButton.Click += new System.EventHandler(this.renameButton_Click);
            // 
            // CharSetEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 412);
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
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton brightButton;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripDropDownButton inkButton;
        private System.Windows.Forms.ToolStripDropDownButton paperButton;
        private System.Windows.Forms.ToolStripButton flashButton;
        private System.Windows.Forms.ToolStripLabel lblDrop;
        private System.Windows.Forms.ToolStripMenuItem inkBlackMnu;
        private System.Windows.Forms.ToolStripMenuItem inkBlueMnu;
        private System.Windows.Forms.ToolStripMenuItem inkRedMnu;
        private System.Windows.Forms.ToolStripMenuItem inkFuchsiaMnu;
        private System.Windows.Forms.ToolStripMenuItem inkGreenMnu;
        private System.Windows.Forms.ToolStripMenuItem inkCyanMnu;
        private System.Windows.Forms.ToolStripMenuItem inkYellowMnu;
        private System.Windows.Forms.ToolStripMenuItem inkWhiteMnu;
        private System.Windows.Forms.ToolStripMenuItem paperBlackMnu;
        private System.Windows.Forms.ToolStripMenuItem paperBlueMnu;
        private System.Windows.Forms.ToolStripMenuItem paperRedMnu;
        private System.Windows.Forms.ToolStripMenuItem paperFuchsiaMnu;
        private System.Windows.Forms.ToolStripMenuItem paperGreenMnu;
        private System.Windows.Forms.ToolStripMenuItem paperCyanMnu;
        private System.Windows.Forms.ToolStripMenuItem paperYellowMnu;
        private System.Windows.Forms.ToolStripMenuItem paperWhiteMnu;
        private System.Windows.Forms.ToolStripButton upButton;
        private System.Windows.Forms.ToolStripButton downButton;
        private System.Windows.Forms.ToolStripButton leftButton;
        private System.Windows.Forms.ToolStripButton rightButton;
        private System.Windows.Forms.ToolStripButton bitmapImportButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton renameButton;
    }
}