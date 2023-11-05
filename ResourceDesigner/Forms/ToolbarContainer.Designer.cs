
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
            actionToolbar = new Controls.ToolStripEx();
            toolbarGrip = new System.Windows.Forms.ToolStripButton();
            saveButton = new System.Windows.Forms.ToolStripButton();
            duplicateButton = new System.Windows.Forms.ToolStripButton();
            renameButton = new System.Windows.Forms.ToolStripButton();
            discardButton = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            bitmapImportButton = new System.Windows.Forms.ToolStripButton();
            randomizeButton = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            clipboardButton = new System.Windows.Forms.ToolStripButton();
            toEditorButton = new System.Windows.Forms.ToolStripButton();
            toFileButton = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            ddScale = new System.Windows.Forms.ToolStripDropDownButton();
            mnuScale025 = new System.Windows.Forms.ToolStripMenuItem();
            mnuScale05 = new System.Windows.Forms.ToolStripMenuItem();
            mnuScale1 = new System.Windows.Forms.ToolStripMenuItem();
            mnuScale2 = new System.Windows.Forms.ToolStripMenuItem();
            mnuScale3 = new System.Windows.Forms.ToolStripMenuItem();
            mnuScale4 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            inkButton = new System.Windows.Forms.ToolStripDropDownButton();
            inkBlackMnu = new System.Windows.Forms.ToolStripMenuItem();
            inkBlueMnu = new System.Windows.Forms.ToolStripMenuItem();
            inkRedMnu = new System.Windows.Forms.ToolStripMenuItem();
            inkFuchsiaMnu = new System.Windows.Forms.ToolStripMenuItem();
            inkGreenMnu = new System.Windows.Forms.ToolStripMenuItem();
            inkCyanMnu = new System.Windows.Forms.ToolStripMenuItem();
            inkYellowMnu = new System.Windows.Forms.ToolStripMenuItem();
            inkWhiteMnu = new System.Windows.Forms.ToolStripMenuItem();
            paperButton = new System.Windows.Forms.ToolStripDropDownButton();
            paperBlackMnu = new System.Windows.Forms.ToolStripMenuItem();
            paperBlueMnu = new System.Windows.Forms.ToolStripMenuItem();
            paperRedMnu = new System.Windows.Forms.ToolStripMenuItem();
            paperFuchsiaMnu = new System.Windows.Forms.ToolStripMenuItem();
            paperGreenMnu = new System.Windows.Forms.ToolStripMenuItem();
            paperCyanMnu = new System.Windows.Forms.ToolStripMenuItem();
            paperYellowMnu = new System.Windows.Forms.ToolStripMenuItem();
            paperWhiteMnu = new System.Windows.Forms.ToolStripMenuItem();
            brightButton = new System.Windows.Forms.ToolStripButton();
            flashButton = new System.Windows.Forms.ToolStripButton();
            lblDrop = new System.Windows.Forms.ToolStripLabel();
            toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            mirrorHorizontalButton = new System.Windows.Forms.ToolStripButton();
            mirrorVerticalButton = new System.Windows.Forms.ToolStripButton();
            upButton = new System.Windows.Forms.ToolStripButton();
            downButton = new System.Windows.Forms.ToolStripButton();
            leftButton = new System.Windows.Forms.ToolStripButton();
            rightButton = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            lineToolButton = new System.Windows.Forms.ToolStripButton();
            multiToolButton = new System.Windows.Forms.ToolStripButton();
            circleToolButton = new System.Windows.Forms.ToolStripButton();
            clearButton = new System.Windows.Forms.ToolStripButton();
            actionToolbar.SuspendLayout();
            SuspendLayout();
            // 
            // actionToolbar
            // 
            actionToolbar.CanOverflow = false;
            actionToolbar.ClickThrough = true;
            actionToolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            actionToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolbarGrip, saveButton, duplicateButton, renameButton, discardButton, toolStripSeparator1, bitmapImportButton, randomizeButton, toolStripSeparator6, clipboardButton, toEditorButton, toFileButton, toolStripSeparator2, ddScale, toolStripSeparator4, inkButton, paperButton, brightButton, flashButton, lblDrop, toolStripSeparator5, mirrorHorizontalButton, mirrorVerticalButton, upButton, downButton, leftButton, rightButton, toolStripSeparator3, lineToolButton, multiToolButton, circleToolButton, clearButton });
            actionToolbar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            actionToolbar.Location = new System.Drawing.Point(0, 0);
            actionToolbar.Name = "actionToolbar";
            actionToolbar.Size = new System.Drawing.Size(34, 648);
            actionToolbar.TabIndex = 1;
            actionToolbar.Text = "toolStrip1";
            // 
            // toolbarGrip
            // 
            toolbarGrip.AutoSize = false;
            toolbarGrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            toolbarGrip.Image = (System.Drawing.Image)resources.GetObject("toolbarGrip.Image");
            toolbarGrip.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            toolbarGrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolbarGrip.Margin = new System.Windows.Forms.Padding(0);
            toolbarGrip.Name = "toolbarGrip";
            toolbarGrip.Size = new System.Drawing.Size(38, 20);
            toolbarGrip.Text = "Grip";
            toolbarGrip.MouseDown += toolbarGrip_MouseDown;
            // 
            // saveButton
            // 
            saveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            saveButton.Image = (System.Drawing.Image)resources.GetObject("saveButton.Image");
            saveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            saveButton.Name = "saveButton";
            saveButton.Size = new System.Drawing.Size(32, 20);
            saveButton.Text = "Save";
            // 
            // duplicateButton
            // 
            duplicateButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            duplicateButton.Image = (System.Drawing.Image)resources.GetObject("duplicateButton.Image");
            duplicateButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            duplicateButton.Name = "duplicateButton";
            duplicateButton.Size = new System.Drawing.Size(32, 20);
            duplicateButton.Text = "Duplicate";
            // 
            // renameButton
            // 
            renameButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            renameButton.Image = (System.Drawing.Image)resources.GetObject("renameButton.Image");
            renameButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            renameButton.Name = "renameButton";
            renameButton.Size = new System.Drawing.Size(32, 20);
            renameButton.Text = "Rename";
            // 
            // discardButton
            // 
            discardButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            discardButton.Image = (System.Drawing.Image)resources.GetObject("discardButton.Image");
            discardButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            discardButton.Name = "discardButton";
            discardButton.Size = new System.Drawing.Size(32, 20);
            discardButton.Text = "Discard";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(32, 6);
            // 
            // bitmapImportButton
            // 
            bitmapImportButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            bitmapImportButton.Image = (System.Drawing.Image)resources.GetObject("bitmapImportButton.Image");
            bitmapImportButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            bitmapImportButton.Name = "bitmapImportButton";
            bitmapImportButton.Size = new System.Drawing.Size(32, 20);
            bitmapImportButton.Text = "Bitmap import";
            // 
            // randomizeButton
            // 
            randomizeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            randomizeButton.Image = (System.Drawing.Image)resources.GetObject("randomizeButton.Image");
            randomizeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            randomizeButton.Name = "randomizeButton";
            randomizeButton.Size = new System.Drawing.Size(32, 20);
            randomizeButton.Text = "Randomize";
            randomizeButton.ToolTipText = "Randomize";
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new System.Drawing.Size(32, 6);
            // 
            // clipboardButton
            // 
            clipboardButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            clipboardButton.Image = (System.Drawing.Image)resources.GetObject("clipboardButton.Image");
            clipboardButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            clipboardButton.Name = "clipboardButton";
            clipboardButton.Size = new System.Drawing.Size(32, 20);
            clipboardButton.Text = "Copy to clipboard";
            // 
            // toEditorButton
            // 
            toEditorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            toEditorButton.Image = (System.Drawing.Image)resources.GetObject("toEditorButton.Image");
            toEditorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            toEditorButton.Name = "toEditorButton";
            toEditorButton.Size = new System.Drawing.Size(32, 20);
            toEditorButton.Text = "Send to text editor";
            // 
            // toFileButton
            // 
            toFileButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            toFileButton.Image = (System.Drawing.Image)resources.GetObject("toFileButton.Image");
            toFileButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            toFileButton.Name = "toFileButton";
            toFileButton.Size = new System.Drawing.Size(32, 20);
            toFileButton.Text = "Export as file";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(32, 6);
            // 
            // ddScale
            // 
            ddScale.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            ddScale.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { mnuScale025, mnuScale05, mnuScale1, mnuScale2, mnuScale3, mnuScale4 });
            ddScale.Image = (System.Drawing.Image)resources.GetObject("ddScale.Image");
            ddScale.ImageTransparentColor = System.Drawing.Color.Magenta;
            ddScale.Name = "ddScale";
            ddScale.ShowDropDownArrow = false;
            ddScale.Size = new System.Drawing.Size(32, 20);
            ddScale.Text = "x1";
            // 
            // mnuScale025
            // 
            mnuScale025.Name = "mnuScale025";
            mnuScale025.Size = new System.Drawing.Size(180, 22);
            mnuScale025.Text = "x0.25";
            // 
            // mnuScale05
            // 
            mnuScale05.Name = "mnuScale05";
            mnuScale05.Size = new System.Drawing.Size(180, 22);
            mnuScale05.Text = "x0.5";
            // 
            // mnuScale1
            // 
            mnuScale1.Name = "mnuScale1";
            mnuScale1.Size = new System.Drawing.Size(180, 22);
            mnuScale1.Text = "x1";
            // 
            // mnuScale2
            // 
            mnuScale2.Name = "mnuScale2";
            mnuScale2.Size = new System.Drawing.Size(180, 22);
            mnuScale2.Text = "x2";
            // 
            // mnuScale3
            // 
            mnuScale3.Name = "mnuScale3";
            mnuScale3.Size = new System.Drawing.Size(180, 22);
            mnuScale3.Text = "x3";
            // 
            // mnuScale4
            // 
            mnuScale4.Name = "mnuScale4";
            mnuScale4.Size = new System.Drawing.Size(180, 22);
            mnuScale4.Text = "x4";
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new System.Drawing.Size(32, 6);
            // 
            // inkButton
            // 
            inkButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            inkButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { inkBlackMnu, inkBlueMnu, inkRedMnu, inkFuchsiaMnu, inkGreenMnu, inkCyanMnu, inkYellowMnu, inkWhiteMnu });
            inkButton.Image = (System.Drawing.Image)resources.GetObject("inkButton.Image");
            inkButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            inkButton.Name = "inkButton";
            inkButton.ShowDropDownArrow = false;
            inkButton.Size = new System.Drawing.Size(32, 20);
            inkButton.Text = "Ink color";
            // 
            // inkBlackMnu
            // 
            inkBlackMnu.Image = (System.Drawing.Image)resources.GetObject("inkBlackMnu.Image");
            inkBlackMnu.Name = "inkBlackMnu";
            inkBlackMnu.Size = new System.Drawing.Size(114, 22);
            inkBlackMnu.Text = "Black";
            // 
            // inkBlueMnu
            // 
            inkBlueMnu.Image = (System.Drawing.Image)resources.GetObject("inkBlueMnu.Image");
            inkBlueMnu.Name = "inkBlueMnu";
            inkBlueMnu.Size = new System.Drawing.Size(114, 22);
            inkBlueMnu.Text = "Blue";
            // 
            // inkRedMnu
            // 
            inkRedMnu.Image = (System.Drawing.Image)resources.GetObject("inkRedMnu.Image");
            inkRedMnu.Name = "inkRedMnu";
            inkRedMnu.Size = new System.Drawing.Size(114, 22);
            inkRedMnu.Text = "Red";
            // 
            // inkFuchsiaMnu
            // 
            inkFuchsiaMnu.Image = (System.Drawing.Image)resources.GetObject("inkFuchsiaMnu.Image");
            inkFuchsiaMnu.Name = "inkFuchsiaMnu";
            inkFuchsiaMnu.Size = new System.Drawing.Size(114, 22);
            inkFuchsiaMnu.Text = "Fuchsia";
            // 
            // inkGreenMnu
            // 
            inkGreenMnu.Image = (System.Drawing.Image)resources.GetObject("inkGreenMnu.Image");
            inkGreenMnu.Name = "inkGreenMnu";
            inkGreenMnu.Size = new System.Drawing.Size(114, 22);
            inkGreenMnu.Text = "Green";
            // 
            // inkCyanMnu
            // 
            inkCyanMnu.Image = (System.Drawing.Image)resources.GetObject("inkCyanMnu.Image");
            inkCyanMnu.Name = "inkCyanMnu";
            inkCyanMnu.Size = new System.Drawing.Size(114, 22);
            inkCyanMnu.Text = "Cyan";
            // 
            // inkYellowMnu
            // 
            inkYellowMnu.Image = (System.Drawing.Image)resources.GetObject("inkYellowMnu.Image");
            inkYellowMnu.Name = "inkYellowMnu";
            inkYellowMnu.Size = new System.Drawing.Size(114, 22);
            inkYellowMnu.Text = "Yellow";
            // 
            // inkWhiteMnu
            // 
            inkWhiteMnu.Image = (System.Drawing.Image)resources.GetObject("inkWhiteMnu.Image");
            inkWhiteMnu.Name = "inkWhiteMnu";
            inkWhiteMnu.Size = new System.Drawing.Size(114, 22);
            inkWhiteMnu.Text = "White";
            // 
            // paperButton
            // 
            paperButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            paperButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { paperBlackMnu, paperBlueMnu, paperRedMnu, paperFuchsiaMnu, paperGreenMnu, paperCyanMnu, paperYellowMnu, paperWhiteMnu });
            paperButton.Image = (System.Drawing.Image)resources.GetObject("paperButton.Image");
            paperButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            paperButton.Name = "paperButton";
            paperButton.ShowDropDownArrow = false;
            paperButton.Size = new System.Drawing.Size(32, 20);
            paperButton.Text = "Paper color";
            // 
            // paperBlackMnu
            // 
            paperBlackMnu.Image = (System.Drawing.Image)resources.GetObject("paperBlackMnu.Image");
            paperBlackMnu.Name = "paperBlackMnu";
            paperBlackMnu.Size = new System.Drawing.Size(114, 22);
            paperBlackMnu.Text = "Black";
            // 
            // paperBlueMnu
            // 
            paperBlueMnu.Image = (System.Drawing.Image)resources.GetObject("paperBlueMnu.Image");
            paperBlueMnu.Name = "paperBlueMnu";
            paperBlueMnu.Size = new System.Drawing.Size(114, 22);
            paperBlueMnu.Text = "Blue";
            // 
            // paperRedMnu
            // 
            paperRedMnu.Image = (System.Drawing.Image)resources.GetObject("paperRedMnu.Image");
            paperRedMnu.Name = "paperRedMnu";
            paperRedMnu.Size = new System.Drawing.Size(114, 22);
            paperRedMnu.Text = "Red";
            // 
            // paperFuchsiaMnu
            // 
            paperFuchsiaMnu.Image = (System.Drawing.Image)resources.GetObject("paperFuchsiaMnu.Image");
            paperFuchsiaMnu.Name = "paperFuchsiaMnu";
            paperFuchsiaMnu.Size = new System.Drawing.Size(114, 22);
            paperFuchsiaMnu.Text = "Fuchsia";
            // 
            // paperGreenMnu
            // 
            paperGreenMnu.Image = (System.Drawing.Image)resources.GetObject("paperGreenMnu.Image");
            paperGreenMnu.Name = "paperGreenMnu";
            paperGreenMnu.Size = new System.Drawing.Size(114, 22);
            paperGreenMnu.Text = "Green";
            // 
            // paperCyanMnu
            // 
            paperCyanMnu.Image = (System.Drawing.Image)resources.GetObject("paperCyanMnu.Image");
            paperCyanMnu.Name = "paperCyanMnu";
            paperCyanMnu.Size = new System.Drawing.Size(114, 22);
            paperCyanMnu.Text = "Cyan";
            // 
            // paperYellowMnu
            // 
            paperYellowMnu.Image = (System.Drawing.Image)resources.GetObject("paperYellowMnu.Image");
            paperYellowMnu.Name = "paperYellowMnu";
            paperYellowMnu.Size = new System.Drawing.Size(114, 22);
            paperYellowMnu.Text = "Yellow";
            // 
            // paperWhiteMnu
            // 
            paperWhiteMnu.Image = (System.Drawing.Image)resources.GetObject("paperWhiteMnu.Image");
            paperWhiteMnu.Name = "paperWhiteMnu";
            paperWhiteMnu.Size = new System.Drawing.Size(114, 22);
            paperWhiteMnu.Text = "White";
            // 
            // brightButton
            // 
            brightButton.CheckOnClick = true;
            brightButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            brightButton.Image = (System.Drawing.Image)resources.GetObject("brightButton.Image");
            brightButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            brightButton.Name = "brightButton";
            brightButton.Size = new System.Drawing.Size(32, 20);
            brightButton.Text = "Brightness";
            // 
            // flashButton
            // 
            flashButton.CheckOnClick = true;
            flashButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            flashButton.Image = (System.Drawing.Image)resources.GetObject("flashButton.Image");
            flashButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            flashButton.Name = "flashButton";
            flashButton.Size = new System.Drawing.Size(32, 20);
            flashButton.Text = "Flash";
            // 
            // lblDrop
            // 
            lblDrop.AutoSize = false;
            lblDrop.BackgroundImage = (System.Drawing.Image)resources.GetObject("lblDrop.BackgroundImage");
            lblDrop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            lblDrop.Margin = new System.Windows.Forms.Padding(10, 1, 10, 2);
            lblDrop.Name = "lblDrop";
            lblDrop.Size = new System.Drawing.Size(16, 16);
            lblDrop.Text = "Drop to char to set its color";
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new System.Drawing.Size(32, 6);
            // 
            // mirrorHorizontalButton
            // 
            mirrorHorizontalButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            mirrorHorizontalButton.Image = (System.Drawing.Image)resources.GetObject("mirrorHorizontalButton.Image");
            mirrorHorizontalButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            mirrorHorizontalButton.Name = "mirrorHorizontalButton";
            mirrorHorizontalButton.Size = new System.Drawing.Size(32, 20);
            mirrorHorizontalButton.Text = "Horizontal mirror";
            // 
            // mirrorVerticalButton
            // 
            mirrorVerticalButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            mirrorVerticalButton.Image = (System.Drawing.Image)resources.GetObject("mirrorVerticalButton.Image");
            mirrorVerticalButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            mirrorVerticalButton.Name = "mirrorVerticalButton";
            mirrorVerticalButton.Size = new System.Drawing.Size(32, 20);
            mirrorVerticalButton.Text = "Vertical mirror";
            // 
            // upButton
            // 
            upButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            upButton.Image = (System.Drawing.Image)resources.GetObject("upButton.Image");
            upButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            upButton.Name = "upButton";
            upButton.Size = new System.Drawing.Size(32, 20);
            upButton.Text = "Shift up";
            // 
            // downButton
            // 
            downButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            downButton.Image = (System.Drawing.Image)resources.GetObject("downButton.Image");
            downButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            downButton.Name = "downButton";
            downButton.Size = new System.Drawing.Size(32, 20);
            downButton.Text = "Shift down";
            // 
            // leftButton
            // 
            leftButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            leftButton.Image = (System.Drawing.Image)resources.GetObject("leftButton.Image");
            leftButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            leftButton.Name = "leftButton";
            leftButton.Size = new System.Drawing.Size(32, 20);
            leftButton.Text = "Shift left";
            // 
            // rightButton
            // 
            rightButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            rightButton.Image = (System.Drawing.Image)resources.GetObject("rightButton.Image");
            rightButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            rightButton.Name = "rightButton";
            rightButton.Size = new System.Drawing.Size(32, 20);
            rightButton.Text = "Shift right";
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new System.Drawing.Size(32, 6);
            // 
            // lineToolButton
            // 
            lineToolButton.CheckOnClick = true;
            lineToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            lineToolButton.Image = (System.Drawing.Image)resources.GetObject("lineToolButton.Image");
            lineToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            lineToolButton.Name = "lineToolButton";
            lineToolButton.Size = new System.Drawing.Size(32, 20);
            lineToolButton.Text = "Line tool";
            // 
            // multiToolButton
            // 
            multiToolButton.CheckOnClick = true;
            multiToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            multiToolButton.Image = (System.Drawing.Image)resources.GetObject("multiToolButton.Image");
            multiToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            multiToolButton.Name = "multiToolButton";
            multiToolButton.Size = new System.Drawing.Size(32, 20);
            multiToolButton.Text = "Multiline tool";
            // 
            // circleToolButton
            // 
            circleToolButton.CheckOnClick = true;
            circleToolButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            circleToolButton.Image = (System.Drawing.Image)resources.GetObject("circleToolButton.Image");
            circleToolButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            circleToolButton.Name = "circleToolButton";
            circleToolButton.Size = new System.Drawing.Size(32, 20);
            circleToolButton.Text = "Circle tool";
            // 
            // clearButton
            // 
            clearButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            clearButton.Image = (System.Drawing.Image)resources.GetObject("clearButton.Image");
            clearButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            clearButton.Name = "clearButton";
            clearButton.Size = new System.Drawing.Size(32, 20);
            clearButton.Text = "Clear";
            // 
            // ToolbarContainer
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(34, 632);
            ControlBox = false;
            Controls.Add(actionToolbar);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Name = "ToolbarContainer";
            actionToolbar.ResumeLayout(false);
            actionToolbar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private System.Windows.Forms.ToolStripButton circleToolButton;
        private System.Windows.Forms.ToolStripMenuItem mnuScale025;
        private System.Windows.Forms.ToolStripMenuItem mnuScale05;
    }
}