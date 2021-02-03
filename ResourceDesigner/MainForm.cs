using Newtonsoft.Json;
using ResourceDesigner.Classes;
using ResourceDesigner.Enums;
using ResourceDesigner.Forms;
using ResourceDesigner.Forms.Dialogs;
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

namespace ResourceDesigner
{
    public partial class MainForm : Form
    {
        Project currentProject;
        string currentFile;
        CharSetListManager csManager;

        List<AnimationViewer> animations = new List<AnimationViewer>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void addCharsetButton_Click(object sender, EventArgs e)
        {
            using (var dlg = new NewCharSetDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    CharSetEditor editor = new CharSetEditor(dlg.CharSetName, dlg.CharWidth, dlg.CharHeight, dlg.CharSetSort, dlg.CharSetType);
                    editor.MdiParent = this;
                    editor.Export += Editor_Export;
                    editor.Save += Editor_Save;
                    editor.Update += Editor_Update;
                    editor.FormClosed += Editor_FormClosed;
                    editor.Show();
                }
            }
        }

        private void Editor_FormClosed(object sender, FormClosedEventArgs e)
        {
            var edit = sender as CharSetEditor;

            edit.Export -= Editor_Export;
            edit.Save -= Editor_Save;
            edit.Update -= Editor_Update;
            edit.FormClosed -= Editor_FormClosed;

            if (csManager == null)
                return;

            var setId = edit.CurrentSet.Id;
            var set = csManager.CharSets.Sprites.Concat(csManager.CharSets.Tiles).Where(cs => cs.Id == setId).FirstOrDefault();

            if (set != null)
            {
                foreach (var anim in animations)
                    anim.UpdateCharSet(set);
            }
            
        }

        private void Editor_Update(object sender, CharSetEventArgs e)
        {
            foreach (var anim in animations)
                anim.UpdateCharSet(e.CharSet);
        }

        private void Editor_Save(object sender, CharSetEventArgs e)
        {
            csManager.AddUpdateCharSet(e.CharSet);
        }

        private void Editor_Export(object sender, ExportEventArgs e)
        {
            switch (e.Target)
            {
                case Enums.ExportTarget.Editor:
                    string content = GenerateCharSetCode(e.Prefix, e.Postfix, e.SingleDim, e.CharSet);
                    TextEditor editor = new TextEditor(e.CharSet.Name, content);
                    editor.MdiParent = this;
                    editor.Show();
                    break;

                case Enums.ExportTarget.Clipboard:
                    string contentc = GenerateCharSetCode(e.Prefix, e.Postfix, e.SingleDim, e.CharSet);
                    Clipboard.SetText(contentc);
                    MessageBox.Show("Content copied to clipboard");
                    break;

                case Enums.ExportTarget.File:

                    string contentf = GenerateCharSetCode(e.Prefix, e.Postfix, e.SingleDim, e.CharSet);
                    using (var dlg = new SaveFileDialog { FileName = this.Name + ".zxbas", Filter = "Basic files (.zxbas)|*.zxbas|Basic files (.bas)|*.bas" })
                    {
                        if (dlg.ShowDialog() == DialogResult.OK)
                            File.WriteAllText(dlg.FileName, contentf);
                    }

                    break;
            }
        }

        private string GenerateCharSetCode(string Prefix, string Postfix, bool SingleDim, CharSet Set)
        {
            string name = ((Prefix ?? "") + Set.Name + (Postfix ?? "")).Replace(" ", "");

            List<string> arrays = new List<string>();
            var dataSet = Set.Data;

            if (SingleDim)
            {
                foreach (byte[] data in dataSet)
                    arrays.Add(ByteArrayToHex(data));

                string arrayContent = string.Join(",   ", arrays);

                return string.Format(CodeTemplates.CharSetSingleDimTemplate, name, dataSet.Length * 8, arrayContent);
            }
            else
            {
                for(int buc = 0; buc < dataSet.Length; buc++)
                    arrays.Add(string.Format(buc < dataSet.Length - 1 ? CodeTemplates.MultiDimRowTemplate : CodeTemplates.MultiDimLastRowTemplate,
                        ByteArrayToHex(dataSet[buc])));

                string arrayContent = string.Concat(arrays);

                return string.Format(CodeTemplates.CharSetMultiDimTemplate, name, dataSet.Length, 8, arrayContent);
            }
        }

        public string ByteArrayToHex(byte[] Data)
        {
            StringBuilder sb = new StringBuilder();

            foreach (byte b in Data)
                sb.Append("$" + b.ToString("X2").PadLeft(2, '0') + ", ");

            sb.Remove(sb.Length - 2, 2);

            return sb.ToString();
        }

        private void newProjectButton_Click(object sender, EventArgs e)
        {
            if (currentProject != null)
            {
                var result = MessageBox.Show("There is an open project, save it?", "New project...", MessageBoxButtons.YesNoCancel);

                switch (result)
                {
                    case DialogResult.Yes:
                        if (!SaveProject())
                            return;
                        break;

                    case DialogResult.Cancel:
                        return;
                }

                foreach (var anm in animations)
                {
                    anm.FormClosed -= Anm_FormClosed;
                    anm.Close();
                    anm.Dispose();
                }

                animations.Clear();

                currentProject = null;

                foreach (var child in MdiChildren)
                {
                    child.Close();
                    child.Dispose();

                    if (child is CharSetEditor)
                    {
                        var edit = child as CharSetEditor;
                        edit.Export -= Editor_Export;
                        edit.Save -= Editor_Save;
                        edit.Update -= Editor_Update;
                        edit.FormClosed -= Editor_FormClosed;
                    }
                }

                if (csManager != null)
                {
                    csManager.CharSetSelected -= CsManager_CharSetSelected;
                    csManager.CharSetDeleted -= CsManager_CharSetDeleted;
                    csManager.Close();
                    csManager.Dispose();
                    csManager = null;
                }
            }

            currentProject = new Project { Name = "Unnamed" };
            this.Text = "Editing project (Unnamed)";

            csManager = new CharSetListManager(true, true);
            csManager.MdiParent = this;
            csManager.Show();
            csManager.Height = this.ClientSize.Height - (mainToolbar.Height + statusStrip.Height + 5);
            csManager.Left = this.ClientSize.Width - (csManager.Width + 5);
            csManager.Top = 0;
            csManager.CharSetSelected += CsManager_CharSetSelected;
            csManager.CharSetDeleted += CsManager_CharSetDeleted;

            EnableProjectButtons();
        }

        private void Anm_FormClosed(object sender, FormClosedEventArgs e)
        {
            animations.Remove((AnimationViewer)sender);
        }

        private void CsManager_CharSetDeleted(object sender, CharSetEventArgs e)
        {
            var existing = MdiChildren.FirstOrDefault(c => (c as CharSetEditor)?.CharSetId == e.CharSet.Id) as CharSetEditor;

            if (existing != null)
            {
                existing.Close();
                existing.Dispose();
                existing.Export -= Editor_Export;
                existing.Save -= Editor_Save;
                existing.Update -= Editor_Update;
                existing.FormClosed -= Editor_FormClosed;
                return;
            }
        }

        private void CsManager_CharSetSelected(object sender, CharSetEventArgs e)
        {
            var existing = MdiChildren.FirstOrDefault(c => (c as CharSetEditor)?.CharSetId == e.CharSet.Id);

            if (existing != null)
            {
                existing.BringToFront();
                return;
            }

            CharSetEditor editor = new CharSetEditor(e.CharSet);
            editor.MdiParent = this;
            editor.Export += Editor_Export;
            editor.Save += Editor_Save;
            editor.Update += Editor_Update;
            editor.FormClosed += Editor_FormClosed;
            editor.Show();
        }

        private bool SaveProject()
        {
            if (currentProject == null)
                return false;

            if (currentProject.Name == "Unnamed")
            {
                using (var nameDlg = new SaveProjectDialog())
                {
                    if (nameDlg.ShowDialog() != DialogResult.OK)
                        return false;

                    currentProject.Name = nameDlg.ProjectName;
                    this.Text = $"Editing project {currentProject.Name}";
                    currentFile = currentProject.Name + ".resproj";
                }
            }

            using (var save = new SaveFileDialog())
            {
                save.Filter = "Archivos de proyecto de recursos (*.resproj)|*.resproj";
                save.FileName = currentFile;

                if (save.ShowDialog() != DialogResult.OK)
                    return false;

                var sets = csManager.CharSets;

                currentProject.Sprites = sets.Sprites;
                currentProject.Tiles = sets.Tiles;

                string content = JsonConvert.SerializeObject(currentProject, Formatting.Indented);
                File.WriteAllText(save.FileName, content);
                currentFile = save.FileName;

                return true;
            }
        }

        private void saveProjectButton_Click(object sender, EventArgs e)
        {
            SaveProject();
        }

        private void openProjectButton_Click(object sender, EventArgs e)
        {
            if (currentProject != null)
            {
                var result = MessageBox.Show("There is an open project, save it?", "Open project...", MessageBoxButtons.YesNoCancel);

                switch (result)
                {
                    case DialogResult.Yes:
                        if (!SaveProject())
                            return;
                        break;

                    case DialogResult.Cancel:
                        return;
                }

                foreach (var anm in animations)
                {
                    anm.FormClosed -= Anm_FormClosed;
                    anm.Close();
                    anm.Dispose();
                }

                animations.Clear();

                currentProject = null;

                foreach (var child in MdiChildren)
                {
                    child.Close();
                    child.Dispose();

                    if (child is CharSetEditor)
                    {
                        var edit = child as CharSetEditor;
                        edit.Export -= Editor_Export;
                        edit.Save -= Editor_Save;
                        edit.Update -= Editor_Update;
                        edit.FormClosed -= Editor_FormClosed;
                    }
                }

                if (csManager != null)
                {
                    csManager.CharSetSelected -= CsManager_CharSetSelected;
                    csManager.CharSetDeleted -= CsManager_CharSetDeleted;
                    csManager.Close();
                    csManager.Dispose();
                    csManager = null;
                }
            }

            using (var dlg = new OpenFileDialog())
            {
                dlg.Filter = "Archivos de proyecto de recursos (*.resproj)|*.resproj";

                if (dlg.ShowDialog() != DialogResult.OK)
                    return;
                try
                {
                    string data = File.ReadAllText(dlg.FileName);
                    currentProject = JsonConvert.DeserializeObject<Project>(data);
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unexpected error: {ex.Message}");
                    return;
                }

                csManager = new CharSetListManager(true, true);
                csManager.MdiParent = this;
                csManager.Show();
                csManager.Height = this.ClientSize.Height - (mainToolbar.Height + statusStrip.Height + 5);
                csManager.Left = this.ClientSize.Width - (csManager.Width + 5);
                csManager.Top = 0;
                csManager.CharSetSelected += CsManager_CharSetSelected;
                csManager.CharSetDeleted += CsManager_CharSetDeleted;
                csManager.CharSets = new CharSetListCharSets { Sprites = currentProject.Sprites, Tiles = currentProject.Tiles };
                this.Text = $"Editing project {currentProject.Name}";
            }

            EnableProjectButtons();
        }

        private void toClipboardButton_Click(object sender, EventArgs e)
        {
            ExportProject(ExportTarget.Clipboard);
        }

        private void toEditorButton_Click(object sender, EventArgs e)
        {
            ExportProject(ExportTarget.Editor);
        }

        private void toFileButton_Click(object sender, EventArgs e)
        {
            ExportProject(ExportTarget.File);
        }

        private void ExportProject(ExportTarget Target)
        {
            ExportProjectSectionOptions spriteSection;
            ExportProjectSectionOptions tileSection;

            using (var exportDialog = new ExportProjectDialog())
            {
                if (exportDialog.ShowDialog() != DialogResult.OK)
                    return;

                spriteSection = exportDialog.SpriteOptions;
                tileSection = exportDialog.TilesOptions;
            }

            switch (Target)
            {
                case Enums.ExportTarget.Editor:
                    string content = GenerateProjectCode(spriteSection, tileSection);
                    TextEditor editor = new TextEditor(currentProject.Name, content);
                    editor.MdiParent = this;
                    editor.Show();
                    break;

                case Enums.ExportTarget.Clipboard:
                    string contentc = GenerateProjectCode(spriteSection, tileSection);
                    Clipboard.SetText(contentc);
                    MessageBox.Show("Content copied to clipboard");
                    break;

                case Enums.ExportTarget.File:

                    string contentf = GenerateProjectCode(spriteSection, tileSection);
                    using (var dlg = new SaveFileDialog { FileName = currentProject.Name + ".zxbas", Filter = "Basic files (.zxbas)|*.zxbas|Basic files (.bas)|*.bas" })
                    {
                        if (dlg.ShowDialog() == DialogResult.OK)
                            File.WriteAllText(dlg.FileName, contentf);
                    }

                    break;
            }
        }

        private string GenerateProjectCode(ExportProjectSectionOptions SpriteSection, ExportProjectSectionOptions TileSection)
        {
            StringBuilder fullCode = new StringBuilder();
            var charsets = csManager.CharSets;

            if (SpriteSection.Enable && charsets.Sprites != null && charsets.Sprites.Length > 0)
            {
                int currentIndex = 0;
                int totalChars = 0;

                List<int> indexes = new List<int>();
                List<string[]> setStrings = new List<string[]>();
                List<string> names = new List<string>();

                StringBuilder arrayBuilder = new StringBuilder();
                StringBuilder defineBuilder = new StringBuilder();

                foreach (var set in charsets.Sprites)
                {
                    List<string> currentSet = new List<string>();

                    foreach (var arr in set.Data)
                    {
                        currentSet.Add(ByteArrayToHex(arr));
                        totalChars++;
                    }

                    indexes.Add(currentIndex);
                    currentIndex = currentIndex + set.Data.Length * 8;
                    names.Add(set.Name.Replace(" ", ""));
                    setStrings.Add(currentSet.ToArray());
                }

                for (int buc = 0; buc < indexes.Count; buc++)
                {

                    if (SpriteSection.Defines)
                        defineBuilder.AppendLine($"#define {names[buc].ToUpper()}_ADDRESS (@{SpriteSection.Name} + {indexes[buc]})");
                }

                if (SpriteSection.SingleDim)
                {
                    arrayBuilder.Append(string.Join(", ", setStrings.Select(c => string.Join(", ", c))) + ", ");
                    arrayBuilder.Remove(arrayBuilder.Length - 2, 2);
                }
                else
                {
                    arrayBuilder.Append(string.Join(", _\r\n", setStrings.Select(c => string.Join(", _\r\n", c.Select(cc => "{ " + cc + " }")))) + ", _\r\n");
                    arrayBuilder.Remove(arrayBuilder.Length - 5, 5);
                    arrayBuilder.Append(" _\r\n");
                }
                

                fullCode.AppendLine("'REM --SPRITE SECTION--");

                if (SpriteSection.Defines)
                {
                    fullCode.Append(defineBuilder);
                    fullCode.AppendLine();
                }
                if (SpriteSection.SingleDim)
                {
                    fullCode.Append(string.Format(CodeTemplates.CharSetSingleDimTemplate, SpriteSection.Name, currentIndex, arrayBuilder));
                    fullCode.AppendLine();
                }
                else
                {
                    fullCode.Append(string.Format(CodeTemplates.CharSetMultiDimTemplate, SpriteSection.Name, totalChars, 8, arrayBuilder));
                    fullCode.AppendLine();
                }

            }

            if (TileSection.Enable && charsets.Tiles != null && charsets.Tiles.Length > 0)
            {
                int currentIndex = 1;

                List<int> indexes = new List<int>();
                List<string[]> setStrings = new List<string[]>();
                List<string> names = new List<string>();

                StringBuilder arrayBuilder = new StringBuilder();
                StringBuilder defineBuilder = new StringBuilder();

                indexes.Add(0);
                setStrings.Add(new string[] { ByteArrayToHex(new byte[8]) });
                names.Add("empty_tile");
                foreach (var set in charsets.Tiles)
                {
                    List<string> currentSet = new List<string>();

                    foreach (var arr in set.Data)
                        currentSet.Add(ByteArrayToHex(arr));
                    
                    indexes.Add(currentIndex);
                    currentIndex = currentIndex + set.Data.Length;
                    names.Add(set.Name.Replace(" ", ""));
                    setStrings.Add(currentSet.ToArray());
                }

                for (int buc = 0; buc < indexes.Count; buc++)
                {
                    if (TileSection.Defines)
                        defineBuilder.AppendLine($"#define {names[buc].ToUpper()}_INDEX {indexes[buc]}");
                }

                if (TileSection.SingleDim)
                {
                    arrayBuilder.Append(string.Join(", ", setStrings.Select(c => string.Join(", ", c))) + ", ");
                    arrayBuilder.Remove(arrayBuilder.Length - 2, 2);
                }
                else
                {
                    arrayBuilder.Append(string.Join(", _\r\n", setStrings.Select(c => string.Join(", _\r\n", c.Select(cc => "{ " + cc + " }")))) + ", _\r\n");
                    arrayBuilder.Remove(arrayBuilder.Length - 5, 5);
                    arrayBuilder.Append(" _\r\n");
                }

                fullCode.AppendLine("'REM --TILE SECTION--");

                if (TileSection.Defines)
                {
                    fullCode.Append(defineBuilder);
                    fullCode.AppendLine();
                }
                if (TileSection.SingleDim)
                {
                    fullCode.Append(string.Format(CodeTemplates.CharSetSingleDimTemplate, TileSection.Name, currentIndex, arrayBuilder));
                    fullCode.AppendLine();
                }
                else
                {
                    fullCode.Append(string.Format(CodeTemplates.CharSetMultiDimTemplate, TileSection.Name, currentIndex, 8, arrayBuilder));
                    fullCode.AppendLine();
                }

            }

            return fullCode.ToString();
        }

        private void closeProjectButton_Click(object sender, EventArgs e)
        {
            if (currentProject != null)
            {
                var result = MessageBox.Show("Save project before closing?", "Close project...", MessageBoxButtons.YesNoCancel);

                switch (result)
                {
                    case DialogResult.Yes:
                        if (!SaveProject())
                            return;
                        break;

                    case DialogResult.Cancel:
                        return;
                }

                foreach (var anm in animations)
                {
                    anm.FormClosed -= Anm_FormClosed;
                    anm.Close();
                    anm.Dispose();
                }

                animations.Clear();

                currentProject = null;

                foreach (var child in MdiChildren)
                {
                    child.Close();
                    child.Dispose();

                    if (child is CharSetEditor)
                    {
                        var edit = child as CharSetEditor;
                        edit.Export -= Editor_Export;
                        edit.Save -= Editor_Save;
                        edit.Update -= Editor_Update; 
                        edit.FormClosed -= Editor_FormClosed;
                    }
                }

                if (csManager != null)
                {
                    csManager.CharSetSelected -= CsManager_CharSetSelected;
                    csManager.CharSetDeleted -= CsManager_CharSetDeleted;
                    csManager.Close();
                    csManager.Dispose();
                    csManager = null;
                }
            }

            currentProject = null;
            this.Text = " GuSprites Resource Designer";
            DisableProjectButtons();
        }

        void EnableProjectButtons()
        {
            saveProjectButton.Enabled = true;
            saveProjectAsButton.Enabled = true;
            closeProjectButton.Enabled = true;
            toClipboardButton.Enabled = true;
            toEditorButton.Enabled = true;
            toFileButton.Enabled = true;
            addCharSetButton.Enabled = true;
            newAnimationButton.Enabled = true;
        }

        void DisableProjectButtons()
        {
            saveProjectButton.Enabled = false;
            saveProjectAsButton.Enabled = false;
            closeProjectButton.Enabled = false;
            toClipboardButton.Enabled = false;
            toEditorButton.Enabled = false;
            toFileButton.Enabled = false;
            addCharSetButton.Enabled = false;
            newAnimationButton.Enabled = false;
        }

        private void newAnimationButton_Click(object sender, EventArgs e)
        {
            var anim = new AnimationViewer();
            anim.MdiParent = this;
            anim.Show();
            animations.Add(anim);
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal && csManager != null)
            {
                csManager.Height = this.ClientSize.Height - (mainToolbar.Height + statusStrip.Height + 5);
                csManager.Left = this.ClientSize.Width - (csManager.Width + 5);
                csManager.Top = 0;
            }
        }
    }
}
