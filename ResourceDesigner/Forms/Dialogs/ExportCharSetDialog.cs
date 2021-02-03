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
    public partial class ExportCharSetDialog : Form
    {
        public bool SingleDimension 
        { 
            get { return chkOneDimArray.Checked; } 
        }

        public string Prefix
        {
            get { return txtPrefix.Text; }
        }

        public string Postfix 
        {
            get { return txtPostfix.Text; }
        }

        public ExportCharSetDialog()
        {
            InitializeComponent();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
