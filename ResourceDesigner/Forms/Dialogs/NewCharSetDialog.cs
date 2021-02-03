using ResourceDesigner.Enums;
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
    public partial class NewCharSetDialog : Form
    {
        public string CharSetName { get; set; }
        public int CharWidth { get; set; }
        public int CharHeight { get; set; }
        public CharSetType CharSetType { get; set; }
        public CharSetSort CharSetSort { get; set; }

        public NewCharSetDialog()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || (cbSort.SelectedItem == null &&cbType.SelectedIndex != 1) || cbType.SelectedItem == null)
            {
                MessageBox.Show("You must fill all fields to create a new charSet");
                return;
            }

            if (cbType.SelectedIndex == 0 &&
                !(nudWidth.Value == 1 && nudHeight.Value == 1) &&
                !(nudWidth.Value == 1 && nudHeight.Value == 2) &&
                !(nudWidth.Value == 2 && nudHeight.Value == 2))
            {
                MessageBox.Show("Invalid sprite size, only 1x1, 1x2 and 2x2 sizes are acceptable");
                return;
            }

            CharSetName = txtName.Text;
            CharWidth = (int)nudWidth.Value;
            CharHeight = (int)nudHeight.Value;
            CharSetType = (CharSetType)cbType.SelectedIndex;
            CharSetSort = (CharSetSort)cbSort.SelectedIndex;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbType.SelectedIndex == 1)
            {
                nudHeight.Enabled = false;
                nudWidth.Enabled = false;
                nudHeight.Value = 1;
                nudWidth.Value = 1;
            }
            else
            {
                nudHeight.Enabled = true;
                nudWidth.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
