
namespace ResourceDesigner.Forms.Dialogs
{
    partial class ExportProjectDialog
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ckSpriteAddresses = new System.Windows.Forms.CheckBox();
            this.ckSingleDimSprites = new System.Windows.Forms.CheckBox();
            this.txtSpriteNames = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ckExportSprites = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ckTileIndexes = new System.Windows.Forms.CheckBox();
            this.ckSingleDimTiles = new System.Windows.Forms.CheckBox();
            this.txtTileNames = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ckExportTiles = new System.Windows.Forms.CheckBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAccept = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ckSpriteAddresses);
            this.groupBox1.Controls.Add(this.ckSingleDimSprites);
            this.groupBox1.Controls.Add(this.txtSpriteNames);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ckExportSprites);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(209, 128);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sprite set";
            // 
            // ckSpriteAddresses
            // 
            this.ckSpriteAddresses.AutoSize = true;
            this.ckSpriteAddresses.Checked = true;
            this.ckSpriteAddresses.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckSpriteAddresses.Location = new System.Drawing.Point(6, 101);
            this.ckSpriteAddresses.Name = "ckSpriteAddresses";
            this.ckSpriteAddresses.Size = new System.Drawing.Size(194, 19);
            this.ckSpriteAddresses.TabIndex = 4;
            this.ckSpriteAddresses.Text = "Generate defines with addresses";
            this.ckSpriteAddresses.UseVisualStyleBackColor = true;
            // 
            // ckSingleDimSprites
            // 
            this.ckSingleDimSprites.AutoSize = true;
            this.ckSingleDimSprites.Location = new System.Drawing.Point(6, 76);
            this.ckSingleDimSprites.Name = "ckSingleDimSprites";
            this.ckSingleDimSprites.Size = new System.Drawing.Size(146, 19);
            this.ckSingleDimSprites.TabIndex = 3;
            this.ckSingleDimSprites.Text = "Single dimension array";
            this.ckSingleDimSprites.UseVisualStyleBackColor = true;
            // 
            // txtSpriteNames
            // 
            this.txtSpriteNames.Location = new System.Drawing.Point(51, 47);
            this.txtSpriteNames.Name = "txtSpriteNames";
            this.txtSpriteNames.Size = new System.Drawing.Size(123, 23);
            this.txtSpriteNames.TabIndex = 2;
            this.txtSpriteNames.Text = "spriteSet";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // ckExportSprites
            // 
            this.ckExportSprites.AutoSize = true;
            this.ckExportSprites.Checked = true;
            this.ckExportSprites.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckExportSprites.Location = new System.Drawing.Point(6, 22);
            this.ckExportSprites.Name = "ckExportSprites";
            this.ckExportSprites.Size = new System.Drawing.Size(110, 19);
            this.ckExportSprites.TabIndex = 0;
            this.ckExportSprites.Text = "Export sprite set";
            this.ckExportSprites.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ckTileIndexes);
            this.groupBox2.Controls.Add(this.ckSingleDimTiles);
            this.groupBox2.Controls.Add(this.txtTileNames);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.ckExportTiles);
            this.groupBox2.Location = new System.Drawing.Point(227, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(209, 128);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tile set";
            // 
            // ckTileIndexes
            // 
            this.ckTileIndexes.AutoSize = true;
            this.ckTileIndexes.Checked = true;
            this.ckTileIndexes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckTileIndexes.Location = new System.Drawing.Point(6, 101);
            this.ckTileIndexes.Name = "ckTileIndexes";
            this.ckTileIndexes.Size = new System.Drawing.Size(183, 19);
            this.ckTileIndexes.TabIndex = 4;
            this.ckTileIndexes.Text = "Generate defines with indexes";
            this.ckTileIndexes.UseVisualStyleBackColor = true;
            // 
            // ckSingleDimTiles
            // 
            this.ckSingleDimTiles.AutoSize = true;
            this.ckSingleDimTiles.Location = new System.Drawing.Point(6, 76);
            this.ckSingleDimTiles.Name = "ckSingleDimTiles";
            this.ckSingleDimTiles.Size = new System.Drawing.Size(146, 19);
            this.ckSingleDimTiles.TabIndex = 3;
            this.ckSingleDimTiles.Text = "Single dimension array";
            this.ckSingleDimTiles.UseVisualStyleBackColor = true;
            // 
            // txtTileNames
            // 
            this.txtTileNames.Location = new System.Drawing.Point(51, 47);
            this.txtTileNames.Name = "txtTileNames";
            this.txtTileNames.Size = new System.Drawing.Size(123, 23);
            this.txtTileNames.TabIndex = 2;
            this.txtTileNames.Text = "tileSet";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Name";
            // 
            // ckExportTiles
            // 
            this.ckExportTiles.AutoSize = true;
            this.ckExportTiles.Checked = true;
            this.ckExportTiles.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckExportTiles.Location = new System.Drawing.Point(6, 22);
            this.ckExportTiles.Name = "ckExportTiles";
            this.ckExportTiles.Size = new System.Drawing.Size(97, 19);
            this.ckExportTiles.TabIndex = 0;
            this.ckExportTiles.Text = "Export tile set";
            this.ckExportTiles.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(361, 166);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Location = new System.Drawing.Point(280, 166);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 7;
            this.btnAccept.Text = "Accept";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // ExportProjectDialog
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(450, 201);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ExportProjectDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Export project";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox ckSpriteAddresses;
        private System.Windows.Forms.CheckBox ckSingleDimSprites;
        private System.Windows.Forms.TextBox txtSpriteNames;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ckExportSprites;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox ckTileIndexes;
        private System.Windows.Forms.CheckBox ckSingleDimTiles;
        private System.Windows.Forms.TextBox txtTileNames;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ckExportTiles;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAccept;
    }
}