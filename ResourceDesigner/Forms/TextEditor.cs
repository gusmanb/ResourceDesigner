using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResourceDesigner.Forms
{
    public partial class TextEditor : Form
    {
        public TextEditor(string Title, string Content)
        {
            InitializeComponent();
            this.Text = Title;
            this.rtBody.Text = Content;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            using (var dlg = new SaveFileDialog { FileName = this.Name + ".zxbas", Filter = "Basic files (.zxbas)|*.zxbas|Basic files (.bas)|*.bas" })
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                    File.WriteAllText(dlg.FileName, rtBody.Text);
            }
        }
    }
}
