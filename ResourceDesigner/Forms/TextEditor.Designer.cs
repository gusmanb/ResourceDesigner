
namespace ResourceDesigner.Forms
{
    partial class TextEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextEditor));
            this.txtToolStrip = new System.Windows.Forms.ToolStrip();
            this.saveButton = new System.Windows.Forms.ToolStripButton();
            this.rtBody = new System.Windows.Forms.RichTextBox();
            this.txtToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtToolStrip
            // 
            this.txtToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveButton});
            this.txtToolStrip.Location = new System.Drawing.Point(0, 0);
            this.txtToolStrip.Name = "txtToolStrip";
            this.txtToolStrip.Size = new System.Drawing.Size(800, 25);
            this.txtToolStrip.TabIndex = 1;
            this.txtToolStrip.Text = "toolStrip1";
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
            // rtBody
            // 
            this.rtBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtBody.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rtBody.Location = new System.Drawing.Point(0, 25);
            this.rtBody.Name = "rtBody";
            this.rtBody.Size = new System.Drawing.Size(800, 425);
            this.rtBody.TabIndex = 2;
            this.rtBody.Text = "";
            // 
            // TextEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rtBody);
            this.Controls.Add(this.txtToolStrip);
            this.Name = "TextEditor";
            this.Text = "TextEditor";
            this.txtToolStrip.ResumeLayout(false);
            this.txtToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip txtToolStrip;
        private System.Windows.Forms.RichTextBox rtBody;
        private System.Windows.Forms.ToolStripButton saveButton;
    }
}