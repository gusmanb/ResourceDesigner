
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.bgImage = new BTMapEditorPlugin.PixelPerfectPictureBox();
            this.bgToolbar = new System.Windows.Forms.ToolStrip();
            this.btnNewMap = new System.Windows.Forms.ToolStripButton();
            this.btnSaveMap = new System.Windows.Forms.ToolStripButton();
            this.btnDuplicateMap = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteMap = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSizeUp = new System.Windows.Forms.ToolStripButton();
            this.btnSizeDown = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnUp = new System.Windows.Forms.ToolStripButton();
            this.btnDown = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.mapList = new BTMapEditorPlugin.MapList();
            ((System.ComponentModel.ISupportInitialize)(this.bgImage)).BeginInit();
            this.bgToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // bgImage
            // 
            this.bgImage.Location = new System.Drawing.Point(57, 80);
            this.bgImage.Name = "bgImage";
            this.bgImage.PixelPerfect = true;
            this.bgImage.Size = new System.Drawing.Size(131, 117);
            this.bgImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bgImage.TabIndex = 0;
            this.bgImage.TabStop = false;
            this.bgImage.Click += new System.EventHandler(this.bgImage_Click);
            // 
            // bgToolbar
            // 
            this.bgToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNewMap,
            this.btnSaveMap,
            this.btnDuplicateMap,
            this.btnDeleteMap,
            this.toolStripSeparator3,
            this.btnSizeUp,
            this.btnSizeDown,
            this.toolStripSeparator1,
            this.btnUp,
            this.btnDown,
            this.toolStripSeparator2,
            this.btnDelete});
            this.bgToolbar.Location = new System.Drawing.Point(0, 0);
            this.bgToolbar.Name = "bgToolbar";
            this.bgToolbar.Size = new System.Drawing.Size(404, 25);
            this.bgToolbar.TabIndex = 1;
            this.bgToolbar.Text = "toolStrip1";
            // 
            // btnNewMap
            // 
            this.btnNewMap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNewMap.Image = ((System.Drawing.Image)(resources.GetObject("btnNewMap.Image")));
            this.btnNewMap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNewMap.Name = "btnNewMap";
            this.btnNewMap.Size = new System.Drawing.Size(23, 22);
            this.btnNewMap.Text = "New";
            // 
            // btnSaveMap
            // 
            this.btnSaveMap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSaveMap.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveMap.Image")));
            this.btnSaveMap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveMap.Name = "btnSaveMap";
            this.btnSaveMap.Size = new System.Drawing.Size(23, 22);
            this.btnSaveMap.Text = "Save";
            // 
            // btnDuplicateMap
            // 
            this.btnDuplicateMap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDuplicateMap.Image = ((System.Drawing.Image)(resources.GetObject("btnDuplicateMap.Image")));
            this.btnDuplicateMap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDuplicateMap.Name = "btnDuplicateMap";
            this.btnDuplicateMap.Size = new System.Drawing.Size(23, 22);
            this.btnDuplicateMap.Text = "New";
            // 
            // btnDeleteMap
            // 
            this.btnDeleteMap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDeleteMap.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteMap.Image")));
            this.btnDeleteMap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteMap.Name = "btnDeleteMap";
            this.btnDeleteMap.Size = new System.Drawing.Size(23, 22);
            this.btnDeleteMap.Text = "Delete";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnSizeUp
            // 
            this.btnSizeUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSizeUp.Image = ((System.Drawing.Image)(resources.GetObject("btnSizeUp.Image")));
            this.btnSizeUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSizeUp.Name = "btnSizeUp";
            this.btnSizeUp.Size = new System.Drawing.Size(23, 22);
            this.btnSizeUp.Text = "Size up";
            // 
            // btnSizeDown
            // 
            this.btnSizeDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSizeDown.Image = ((System.Drawing.Image)(resources.GetObject("btnSizeDown.Image")));
            this.btnSizeDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSizeDown.Name = "btnSizeDown";
            this.btnSizeDown.Size = new System.Drawing.Size(23, 22);
            this.btnSizeDown.Text = "Size down";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnUp
            // 
            this.btnUp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUp.Image = ((System.Drawing.Image)(resources.GetObject("btnUp.Image")));
            this.btnUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(23, 22);
            this.btnUp.Text = "Bring to front";
            this.btnUp.ToolTipText = "Bring to front";
            // 
            // btnDown
            // 
            this.btnDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDown.Image = ((System.Drawing.Image)(resources.GetObject("btnDown.Image")));
            this.btnDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(23, 22);
            this.btnDown.Text = "Send to back";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnDelete
            // 
            this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(23, 22);
            this.btnDelete.Text = "Delete";
            // 
            // mapList
            // 
            this.mapList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mapList.Location = new System.Drawing.Point(194, 80);
            this.mapList.Name = "mapList";
            this.mapList.Size = new System.Drawing.Size(94, 193);
            this.mapList.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.ClientSize = new System.Drawing.Size(404, 341);
            this.Controls.Add(this.mapList);
            this.Controls.Add(this.bgToolbar);
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
            this.bgToolbar.ResumeLayout(false);
            this.bgToolbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PixelPerfectPictureBox bgImage;
        private System.Windows.Forms.ToolStrip bgToolbar;
        private System.Windows.Forms.ToolStripButton btnSizeUp;
        private System.Windows.Forms.ToolStripButton btnSizeDown;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnUp;
        private System.Windows.Forms.ToolStripButton btnDown;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private MapList mapList;
        private System.Windows.Forms.ToolStripButton btnNewMap;
        private System.Windows.Forms.ToolStripButton btnSaveMap;
        private System.Windows.Forms.ToolStripButton btnDuplicateMap;
        private System.Windows.Forms.ToolStripButton btnDeleteMap;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}

