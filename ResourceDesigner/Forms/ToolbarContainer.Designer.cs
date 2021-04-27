
namespace ResourceDesigner.Forms
{
    partial class ToolbarContainer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolbarContainer));
            this.actionToolbar = new ResourceDesigner.Controls.ToolStripEx();
            this.saveButton = new System.Windows.Forms.ToolStripButton();
            this.duplicateButton = new System.Windows.Forms.ToolStripButton();
            this.renameButton = new System.Windows.Forms.ToolStripButton();
            this.discardButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bitmapImportButton = new System.Windows.Forms.ToolStripButton();
            this.randomizeButton = new System.Windows.Forms.ToolStripButton();
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
            this.toolbarGrip = new System.Windows.Forms.ToolStripButton();
            this.actionToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // actionToolbar
            // 
            this.actionToolbar.CanOverflow = false;
            this.actionToolbar.ClickThrough = true;
            this.actionToolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.actionToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolbarGrip,
            this.saveButton,
            this.duplicateButton,
            this.renameButton,
            this.discardButton,
            this.toolStripSeparator1,
            this.bitmapImportButton,
            this.randomizeButton,
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
            this.actionToolbar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.actionToolbar.Location = new System.Drawing.Point(0, 0);
            this.actionToolbar.Name = "actionToolbar";
            this.actionToolbar.Size = new System.Drawing.Size(34, 606);
            this.actionToolbar.TabIndex = 1;
            this.actionToolbar.Text = "toolStrip1";
            // 
            // saveButton
            // 
            this.saveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveButton.Image = ((System.Drawing.Image)(resources.GetObject("saveButton.Image")));
            this.saveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(32, 20);
            this.saveButton.Text = "Save";
            // 
            // duplicateButton
            // 
            this.duplicateButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.duplicateButton.Image = ((System.Drawing.Image)(resources.GetObject("duplicateButton.Image")));
            this.duplicateButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.duplicateButton.Name = "duplicateButton";
            this.duplicateButton.Size = new System.Drawing.Size(32, 20);
            this.duplicateButton.Text = "Duplicate";
            // 
            // renameButton
            // 
            this.renameButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.renameButton.Image = ((System.Drawing.Image)(resources.GetObject("renameButton.Image")));
            this.renameButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.renameButton.Name = "renameButton";
            this.renameButton.Size = new System.Drawing.Size(32, 20);
            this.renameButton.Text = "Rename";
            // 
            // discardButton
            // 
            this.discardButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.discardButton.Image = ((System.Drawing.Image)(resources.GetObject("discardButton.Image")));
            this.discardButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.discardButton.Name = "discardButton";
            this.discardButton.Size = new System.Drawing.Size(32, 20);
            this.discardButton.Text = "Discard";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(32, 6);
            // 
            // bitmapImportButton
            // 
            this.bitmapImportButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bitmapImportButton.Image = ((System.Drawing.Image)(resources.GetObject("bitmapImportButton.Image")));
            this.bitmapImportButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bitmapImportButton.Name = "bitmapImportButton";
            this.bitmapImportButton.Size = new System.Drawing.Size(32, 20);
            this.bitmapImportButton.Text = "Bitmap import";
            // 
            // randomizeButton
            // 
            this.randomizeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.randomizeButton.Image = ((System.Drawing.Image)(resources.GetObject("randomizeButton.Image")));
            this.randomizeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.randomizeButton.Name = "randomizeButton";
            this.randomizeButton.Size = new System.Drawing.Size(32, 20);
            this.randomizeButton.Text = "Randomize";
            this.randomizeButton.ToolTipText = "Randomize";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(32, 6);
            // 
            // clipboardButton
            // 
            this.clipboardButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.clipboardButton.Image = ((System.Drawing.Image)(resources.GetObject("clipboardButton.Image")));
            this.clipboardButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clipboardButton.Name = "clipboardButton";
            this.clipboardButton.Size = new System.Drawing.Size(32, 20);
            this.clipboardButton.Text = "Copy to clipboard";
            // 
            // toEditorButton
            // 
            this.toEditorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toEditorButton.Image = ((System.Drawing.Image)(resources.GetObject("toEditorButton.Image")));
            this.toEditorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toEditorButton.Name = "toEditorButton";
            this.toEditorButton.Size = new System.Drawing.Size(32, 20);
            this.toEditorButton.Text = "Send to text editor";
            // 
            // toFileButton
            // 
            this.toFileButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toFileButton.Image = ((System.Drawing.Image)(resources.GetObject("toFileButton.Image")));
            this.toFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toFileButton.Name = "toFileButton";
            this.toFileButton.Size = new System.Drawing.Size(32, 20);
            this.toFileButton.Text = "Export as file";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(32, 6);
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
            this.ddScale.ShowDropDownArrow = false;
            this.ddScale.Size = new System.Drawing.Size(32, 20);
            this.ddScale.Text = "x1";
            // 
            // mnuScale1
            // 
            this.mnuScale1.Name = "mnuScale1";
            this.mnuScale1.Size = new System.Drawing.Size(86, 22);
            this.mnuScale1.Text = "x1";
            // 
            // mnuScale2
            // 
            this.mnuScale2.Name = "mnuScale2";
            this.mnuScale2.Size = new System.Drawing.Size(86, 22);
            this.mnuScale2.Text = "x2";
            // 
            // mnuScale3
            // 
            this.mnuScale3.Name = "mnuScale3";
            this.mnuScale3.Size = new System.Drawing.Size(86, 22);
            this.mnuScale3.Text = "x3";
            // 
            // mnuScale4
            // 
            this.mnuScale4.Name = "mnuScale4";
            this.mnuScale4.Size = new System.Drawing.Size(86, 22);
            this.mnuScale4.Text = "x4";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(32, 6);
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
            this.inkButton.ShowDropDownArrow = false;
            this.inkButton.Size = new System.Drawing.Size(32, 20);
            this.inkButton.Text = "Ink color";
            // 
            // inkBlackMnu
            // 
            this.inkBlackMnu.Image = ((System.Drawing.Image)(resources.GetObject("inkBlackMnu.Image")));
            this.inkBlackMnu.Name = "inkBlackMnu";
            this.inkBlackMnu.Size = new System.Drawing.Size(114, 22);
            this.inkBlackMnu.Text = "Black";
            // 
            // inkBlueMnu
            // 
            this.inkBlueMnu.Image = ((System.Drawing.Image)(resources.GetObject("inkBlueMnu.Image")));
            this.inkBlueMnu.Name = "inkBlueMnu";
            this.inkBlueMnu.Size = new System.Drawing.Size(114, 22);
            this.inkBlueMnu.Text = "Blue";
            // 
            // inkRedMnu
            // 
            this.inkRedMnu.Image = ((System.Drawing.Image)(resources.GetObject("inkRedMnu.Image")));
            this.inkRedMnu.Name = "inkRedMnu";
            this.inkRedMnu.Size = new System.Drawing.Size(114, 22);
            this.inkRedMnu.Text = "Red";
            // 
            // inkFuchsiaMnu
            // 
            this.inkFuchsiaMnu.Image = ((System.Drawing.Image)(resources.GetObject("inkFuchsiaMnu.Image")));
            this.inkFuchsiaMnu.Name = "inkFuchsiaMnu";
            this.inkFuchsiaMnu.Size = new System.Drawing.Size(114, 22);
            this.inkFuchsiaMnu.Text = "Fuchsia";
            // 
            // inkGreenMnu
            // 
            this.inkGreenMnu.Image = ((System.Drawing.Image)(resources.GetObject("inkGreenMnu.Image")));
            this.inkGreenMnu.Name = "inkGreenMnu";
            this.inkGreenMnu.Size = new System.Drawing.Size(114, 22);
            this.inkGreenMnu.Text = "Green";
            // 
            // inkCyanMnu
            // 
            this.inkCyanMnu.Image = ((System.Drawing.Image)(resources.GetObject("inkCyanMnu.Image")));
            this.inkCyanMnu.Name = "inkCyanMnu";
            this.inkCyanMnu.Size = new System.Drawing.Size(114, 22);
            this.inkCyanMnu.Text = "Cyan";
            // 
            // inkYellowMnu
            // 
            this.inkYellowMnu.Image = ((System.Drawing.Image)(resources.GetObject("inkYellowMnu.Image")));
            this.inkYellowMnu.Name = "inkYellowMnu";
            this.inkYellowMnu.Size = new System.Drawing.Size(114, 22);
            this.inkYellowMnu.Text = "Yellow";
            // 
            // inkWhiteMnu
            // 
            this.inkWhiteMnu.Image = ((System.Drawing.Image)(resources.GetObject("inkWhiteMnu.Image")));
            this.inkWhiteMnu.Name = "inkWhiteMnu";
            this.inkWhiteMnu.Size = new System.Drawing.Size(114, 22);
            this.inkWhiteMnu.Text = "White";
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
            this.paperButton.ShowDropDownArrow = false;
            this.paperButton.Size = new System.Drawing.Size(32, 20);
            this.paperButton.Text = "Paper color";
            // 
            // paperBlackMnu
            // 
            this.paperBlackMnu.Image = ((System.Drawing.Image)(resources.GetObject("paperBlackMnu.Image")));
            this.paperBlackMnu.Name = "paperBlackMnu";
            this.paperBlackMnu.Size = new System.Drawing.Size(114, 22);
            this.paperBlackMnu.Text = "Black";
            // 
            // paperBlueMnu
            // 
            this.paperBlueMnu.Image = ((System.Drawing.Image)(resources.GetObject("paperBlueMnu.Image")));
            this.paperBlueMnu.Name = "paperBlueMnu";
            this.paperBlueMnu.Size = new System.Drawing.Size(114, 22);
            this.paperBlueMnu.Text = "Blue";
            // 
            // paperRedMnu
            // 
            this.paperRedMnu.Image = ((System.Drawing.Image)(resources.GetObject("paperRedMnu.Image")));
            this.paperRedMnu.Name = "paperRedMnu";
            this.paperRedMnu.Size = new System.Drawing.Size(114, 22);
            this.paperRedMnu.Text = "Red";
            // 
            // paperFuchsiaMnu
            // 
            this.paperFuchsiaMnu.Image = ((System.Drawing.Image)(resources.GetObject("paperFuchsiaMnu.Image")));
            this.paperFuchsiaMnu.Name = "paperFuchsiaMnu";
            this.paperFuchsiaMnu.Size = new System.Drawing.Size(114, 22);
            this.paperFuchsiaMnu.Text = "Fuchsia";
            // 
            // paperGreenMnu
            // 
            this.paperGreenMnu.Image = ((System.Drawing.Image)(resources.GetObject("paperGreenMnu.Image")));
            this.paperGreenMnu.Name = "paperGreenMnu";
            this.paperGreenMnu.Size = new System.Drawing.Size(114, 22);
            this.paperGreenMnu.Text = "Green";
            // 
            // paperCyanMnu
            // 
            this.paperCyanMnu.Image = ((System.Drawing.Image)(resources.GetObject("paperCyanMnu.Image")));
            this.paperCyanMnu.Name = "paperCyanMnu";
            this.paperCyanMnu.Size = new System.Drawing.Size(114, 22);
            this.paperCyanMnu.Text = "Cyan";
            // 
            // paperYellowMnu
            // 
            this.paperYellowMnu.Image = ((System.Drawing.Image)(resources.GetObject("paperYellowMnu.Image")));
            this.paperYellowMnu.Name = "paperYellowMnu";
            this.paperYellowMnu.Size = new System.Drawing.Size(114, 22);
            this.paperYellowMnu.Text = "Yellow";
            // 
            // paperWhiteMnu
            // 
            this.paperWhiteMnu.Image = ((System.Drawing.Image)(resources.GetObject("paperWhiteMnu.Image")));
            this.paperWhiteMnu.Name = "paperWhiteMnu";
            this.paperWhiteMnu.Size = new System.Drawing.Size(114, 22);
            this.paperWhiteMnu.Text = "White";
            // 
            // brightButton
            // 
            this.brightButton.CheckOnClick = true;
            this.brightButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.brightButton.Image = ((System.Drawing.Image)(resources.GetObject("brightButton.Image")));
            this.brightButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.brightButton.Name = "brightButton";
            this.brightButton.Size = new System.Drawing.Size(32, 20);
            this.brightButton.Text = "Brightness";
            // 
            // flashButton
            // 
            this.flashButton.CheckOnClick = true;
            this.flashButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.flashButton.Image = ((System.Drawing.Image)(resources.GetObject("flashButton.Image")));
            this.flashButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.flashButton.Name = "flashButton";
            this.flashButton.Size = new System.Drawing.Size(32, 20);
            this.flashButton.Text = "Flash";
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
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(32, 6);
            // 
            // mirrorHorizontalButton
            // 
            this.mirrorHorizontalButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mirrorHorizontalButton.Image = ((System.Drawing.Image)(resources.GetObject("mirrorHorizontalButton.Image")));
            this.mirrorHorizontalButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mirrorHorizontalButton.Name = "mirrorHorizontalButton";
            this.mirrorHorizontalButton.Size = new System.Drawing.Size(32, 20);
            this.mirrorHorizontalButton.Text = "Horizontal mirror";
            // 
            // mirrorVerticalButton
            // 
            this.mirrorVerticalButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mirrorVerticalButton.Image = ((System.Drawing.Image)(resources.GetObject("mirrorVerticalButton.Image")));
            this.mirrorVerticalButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mirrorVerticalButton.Name = "mirrorVerticalButton";
            this.mirrorVerticalButton.Size = new System.Drawing.Size(32, 20);
            this.mirrorVerticalButton.Text = "Vertical mirror";
            // 
            // upButton
            // 
            this.upButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.upButton.Image = ((System.Drawing.Image)(resources.GetObject("upButton.Image")));
            this.upButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.upButton.Name = "upButton";
            this.upButton.Size = new System.Drawing.Size(32, 20);
            this.upButton.Text = "Shift up";
            // 
            // downButton
            // 
            this.downButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.downButton.Image = ((System.Drawing.Image)(resources.GetObject("downButton.Image")));
            this.downButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.downButton.Name = "downButton";
            this.downButton.Size = new System.Drawing.Size(32, 20);
            this.downButton.Text = "Shift down";
            // 
            // leftButton
            // 
            this.leftButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.leftButton.Image = ((System.Drawing.Image)(resources.GetObject("leftButton.Image")));
            this.leftButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.leftButton.Name = "leftButton";
            this.leftButton.Size = new System.Drawing.Size(32, 20);
            this.leftButton.Text = "Shift left";
            // 
            // rightButton
            // 
            this.rightButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rightButton.Image = ((System.Drawing.Image)(resources.GetObject("rightButton.Image")));
            this.rightButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rightButton.Name = "rightButton";
            this.rightButton.Size = new System.Drawing.Size(32, 20);
            this.rightButton.Text = "Shift right";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(32, 6);
            // 
            // lineToolButton
            // 
            this.lineToolButton.CheckOnClick = true;
            this.lineToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.lineToolButton.Image = ((System.Drawing.Image)(resources.GetObject("lineToolButton.Image")));
            this.lineToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lineToolButton.Name = "lineToolButton";
            this.lineToolButton.Size = new System.Drawing.Size(32, 20);
            this.lineToolButton.Text = "Line tool";
            // 
            // multiToolButton
            // 
            this.multiToolButton.CheckOnClick = true;
            this.multiToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.multiToolButton.Image = ((System.Drawing.Image)(resources.GetObject("multiToolButton.Image")));
            this.multiToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.multiToolButton.Name = "multiToolButton";
            this.multiToolButton.Size = new System.Drawing.Size(32, 20);
            this.multiToolButton.Text = "Multiline tool";
            // 
            // clearButton
            // 
            this.clearButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.clearButton.Image = ((System.Drawing.Image)(resources.GetObject("clearButton.Image")));
            this.clearButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(32, 20);
            this.clearButton.Text = "Clear";
            // 
            // toolbarGrip
            // 
            this.toolbarGrip.AutoSize = false;
            this.toolbarGrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbarGrip.Image = ((System.Drawing.Image)(resources.GetObject("toolbarGrip.Image")));
            this.toolbarGrip.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolbarGrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbarGrip.Margin = new System.Windows.Forms.Padding(0);
            this.toolbarGrip.Name = "toolbarGrip";
            this.toolbarGrip.Size = new System.Drawing.Size(38, 20);
            this.toolbarGrip.Text = "Grip";
            this.toolbarGrip.MouseDown += new System.Windows.Forms.MouseEventHandler(this.toolbarGrip_MouseDown);
            // 
            // ToolbarContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(34, 608);
            this.ControlBox = false;
            this.Controls.Add(this.actionToolbar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ToolbarContainer";
            this.actionToolbar.ResumeLayout(false);
            this.actionToolbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.ToolStripEx actionToolbar;
        private System.Windows.Forms.ToolStripButton saveButton;
        private System.Windows.Forms.ToolStripButton duplicateButton;
        private System.Windows.Forms.ToolStripButton renameButton;
        private System.Windows.Forms.ToolStripButton discardButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton bitmapImportButton;
        private System.Windows.Forms.ToolStripButton randomizeButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton clipboardButton;
        private System.Windows.Forms.ToolStripButton toEditorButton;
        private System.Windows.Forms.ToolStripButton toFileButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripDropDownButton ddScale;
        private System.Windows.Forms.ToolStripMenuItem mnuScale1;
        private System.Windows.Forms.ToolStripMenuItem mnuScale2;
        private System.Windows.Forms.ToolStripMenuItem mnuScale3;
        private System.Windows.Forms.ToolStripMenuItem mnuScale4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripDropDownButton inkButton;
        private System.Windows.Forms.ToolStripMenuItem inkBlackMnu;
        private System.Windows.Forms.ToolStripMenuItem inkBlueMnu;
        private System.Windows.Forms.ToolStripMenuItem inkRedMnu;
        private System.Windows.Forms.ToolStripMenuItem inkFuchsiaMnu;
        private System.Windows.Forms.ToolStripMenuItem inkGreenMnu;
        private System.Windows.Forms.ToolStripMenuItem inkCyanMnu;
        private System.Windows.Forms.ToolStripMenuItem inkYellowMnu;
        private System.Windows.Forms.ToolStripMenuItem inkWhiteMnu;
        private System.Windows.Forms.ToolStripDropDownButton paperButton;
        private System.Windows.Forms.ToolStripMenuItem paperBlackMnu;
        private System.Windows.Forms.ToolStripMenuItem paperBlueMnu;
        private System.Windows.Forms.ToolStripMenuItem paperRedMnu;
        private System.Windows.Forms.ToolStripMenuItem paperFuchsiaMnu;
        private System.Windows.Forms.ToolStripMenuItem paperGreenMnu;
        private System.Windows.Forms.ToolStripMenuItem paperCyanMnu;
        private System.Windows.Forms.ToolStripMenuItem paperYellowMnu;
        private System.Windows.Forms.ToolStripMenuItem paperWhiteMnu;
        private System.Windows.Forms.ToolStripButton brightButton;
        private System.Windows.Forms.ToolStripButton flashButton;
        private System.Windows.Forms.ToolStripLabel lblDrop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton mirrorHorizontalButton;
        private System.Windows.Forms.ToolStripButton mirrorVerticalButton;
        private System.Windows.Forms.ToolStripButton upButton;
        private System.Windows.Forms.ToolStripButton downButton;
        private System.Windows.Forms.ToolStripButton leftButton;
        private System.Windows.Forms.ToolStripButton rightButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton lineToolButton;
        private System.Windows.Forms.ToolStripButton multiToolButton;
        private System.Windows.Forms.ToolStripButton clearButton;
        private System.Windows.Forms.ToolStripButton toolbarGrip;
    }
}