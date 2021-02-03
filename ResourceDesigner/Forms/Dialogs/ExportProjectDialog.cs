using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResourceDesigner.Forms.Dialogs
{
    public partial class ExportProjectDialog : Form
    {
        public ExportProjectSectionOptions SpriteOptions
        {
            get 
            {
                return new ExportProjectSectionOptions 
                { 
                    Enable = ckExportSprites.Checked, 
                    Name = txtSpriteNames.Text, 
                    SingleDim = ckSingleDimSprites.Checked,
                    Defines = ckSpriteAddresses.Checked
                };
            }
        }

        public ExportProjectSectionOptions TilesOptions
        {
            get 
            {
                return new ExportProjectSectionOptions
                {
                    Enable = ckExportTiles.Checked,
                    Name = txtTileNames.Text,
                    SingleDim = ckSingleDimTiles.Checked,
                    Defines = ckTileIndexes.Checked
                };
            }
        }

        public ExportProjectDialog()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if ((ckExportSprites.Checked && string.IsNullOrWhiteSpace(txtSpriteNames.Text)) || (ckExportTiles.Checked && string.IsNullOrWhiteSpace(txtTileNames.Text)))
            {
                MessageBox.Show("All enabled sections must have a name");
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }

    public class ExportProjectSectionOptions
    {
        public bool Enable { get; set; }
        public string Name { get; set; }
        public bool SingleDim { get; set; }
        public bool Defines { get; set; }
    }
}
