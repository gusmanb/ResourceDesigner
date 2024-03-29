﻿using Newtonsoft.Json;
using ResourceDesigner.Classes;
using ResourceDesigner.Enums;
using ResourceDesigner.Forms;
using ResourceDesigner.Forms.Dialogs;
using ResourceDesigner.PluginSystem;
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
        ToolbarContainer charEditTools;
        public MainForm()
        {
            InitializeComponent();
            charEditTools = new ToolbarContainer();
            charEditTools.MdiParent = this;
            charEditTools.Show();
            PluginManager.PluginOpenNewWindow += PluginManager_PluginOpenNewWindow;
            PluginManager.PluginRequestCharSet += PluginManager_PluginRequestCharSet;
            PluginManager.PluginAddUpdateCharSet += PluginManager_PluginAddUpdateCharSet;
            PluginManager.PluginDeleteCharSet += PluginManager_PluginDeleteCharSet;
            PluginManager.PluginRequestCharSetIndex += PluginManager_PluginRequestCharsetIndex;
            PluginManager.PluginOpenEditorWindow += PluginManager_PluginOpenEditorWindow;
            PluginManager.LoadPlugins(this, mainToolbar);
        }

        private void PluginManager_PluginOpenEditorWindow(object sender, PluginEditorEventArgs e)
        {
            TextEditor editor = new TextEditor(e.Title, e.Content);
            editor.MdiParent = this;
            editor.Show();
        }

        private void PluginManager_PluginRequestCharsetIndex(object sender, PluginCharSetIdEventArgs e)
        {
            var sets = csManager.CharSets;
            int idx = -1;

            if (sets.Sprites != null && sets.Sprites.Any(s => s.Id == e.Id))
            {
                //Sprite index
                idx = 0;

                foreach (var item in sets.Sprites)
                {
                    if (item.Id == e.Id)
                    {
                        e.Index = idx;
                        return;
                    }
                    else
                        idx++;
                }

                //error?
                idx = -1;
            }
            else if (sets.Tiles != null && sets.Tiles.Any(s => s.Id == e.Id))
            {
                //Tile index
                idx = 0;

                foreach (var item in sets.Sprites)
                {
                    if (item.Id == e.Id)
                    {
                        e.Index = idx;
                        return;
                    }
                    else
                        idx += item.Data.Length;
                }

                //error?
                idx = -1;
            }
        }

        private void PluginManager_PluginDeleteCharSet(object sender, PluginCharSetEventArgs e)
        {
            csManager.DeleteCharSet(e.Set);
        }

        private void PluginManager_PluginAddUpdateCharSet(object sender, PluginCharSetEventArgs e)
        {
            csManager.AddUpdateCharSet(e.Set);
        }

        private void PluginManager_PluginRequestCharSet(object sender, PluginRequestCharSetEventArgs e)
        {
            IEnumerable<CharSet> source = null;

            if (e.SetType == null)
                source = csManager.CharSets.Sprites.Concat(csManager.CharSets.Tiles);
            else if (e.SetType.Value == CharSetType.Sprite)
                source = csManager.CharSets.Sprites;
            else
                source = csManager.CharSets.Tiles;


            if (e.Id != null)
                source = source.Where(cs => cs.Id == e.Id.Value);

            if (!string.IsNullOrWhiteSpace(e.Name))
                source = source.Where(cs => cs.Name == e.Name);

            if (e.SetType != null)
                source = source.Where(cs => cs.SetType == e.SetType.Value);

            e.FoundCharSets = source.ToArray();
        }

        private void PluginManager_PluginOpenNewWindow(object sender, PluginNewWindowEventArgs e)
        {
            e.NewWindow.MdiParent = this;
            e.NewWindow.Show();
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

            if (charEditTools.ActiveEditor == edit)
                charEditTools.ActiveEditor = null;

        }

        private void Editor_Update(object sender, CharSetEventArgs e)
        {
            foreach (var anim in animations)
                anim.UpdateCharSet(e.CharSet);
        }

        private void Editor_Save(object sender, CharSetEventArgs e)
        {
            csManager.AddUpdateCharSet(e.CharSet);
            PluginManager.AddOrUpdateCharset(e.CharSet);
        }

        private void Editor_Export(object sender, ExportEventArgs e)
        {
            switch (e.Target)
            {
                case Enums.ExportTarget.Editor:
                    string content = GenerateCharSetCode(e.Prefix, e.Postfix, e.SingleDim, e.CharSet, e.Colors);
                    TextEditor editor = new TextEditor(e.CharSet.Name, content);
                    editor.MdiParent = this;
                    editor.Show();
                    break;

                case Enums.ExportTarget.Clipboard:
                    string contentc = GenerateCharSetCode(e.Prefix, e.Postfix, e.SingleDim, e.CharSet, e.Colors);
                    Clipboard.SetText(contentc);
                    MessageBox.Show("Content copied to clipboard");
                    break;

                case Enums.ExportTarget.File:

                    string contentf = GenerateCharSetCode(e.Prefix, e.Postfix, e.SingleDim, e.CharSet, e.Colors);
                    using (var dlg = new SaveFileDialog { FileName = this.Name + ".zxbas", Filter = "Basic files (.zxbas)|*.zxbas|Basic files (.bas)|*.bas" })
                    {
                        if (dlg.ShowDialog() == DialogResult.OK)
                            File.WriteAllText(dlg.FileName, contentf);
                    }

                    break;
            }
        }

        private string GenerateCharSetCode(string Prefix, string Postfix, bool SingleDim, CharSet Set, bool WithColors)
        {
            string name = ((Prefix ?? "") + Set.Name + (Postfix ?? "")).Replace(" ", "");
            string nameColors = ((Prefix ?? "") + Set.Name + "Colors" + (Postfix ?? "")).Replace(" ", "");

            List<string> arrays = new List<string>();
            var dataSet = Set.Data;

            string colorContent = ColorArrayToHex(Set.ColorData);

            if (SingleDim)
            {
                foreach (byte[] data in dataSet)
                    arrays.Add(ByteArrayToHex(data));

                string arrayContent = string.Join(",   ", arrays);


                return string.Format(CodeTemplates.CharSetSingleDimTemplate, name, dataSet.Length * 8, arrayContent) + (WithColors ? "\r\n" +
                        string.Format(CodeTemplates.CharSetSingleDimTemplate, nameColors, Set.ColorData.Length, colorContent) : "");
            }
            else
            {
                for(int buc = 0; buc < dataSet.Length; buc++)
                    arrays.Add(string.Format(buc < dataSet.Length - 1 ? CodeTemplates.MultiDimRowTemplate : CodeTemplates.MultiDimLastRowTemplate,
                        ByteArrayToHex(dataSet[buc])));

                string arrayContent = string.Concat(arrays);

                return string.Format(CodeTemplates.CharSetMultiDimTemplate, name, dataSet.Length, 8, arrayContent) + (WithColors ? "\r\n" +
                        string.Format(CodeTemplates.CharSetSingleDimTemplate, nameColors, Set.ColorData.Length, colorContent) : "");
            }
        }

        private string ColorArrayToHex(ColorComponent[] ColorData)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var b in ColorData)
                sb.Append("$" + ((byte)b).ToString("X2").PadLeft(2, '0') + ", ");

            sb.Remove(sb.Length - 2, 2);

            return sb.ToString();
        }

        public string ByteArrayToHex(byte[] Data)
        {
            StringBuilder sb = new StringBuilder();

            foreach (byte b in Data)
                sb.Append("$" + b.ToString("X2").PadLeft(2, '0') + ", ");

            sb.Remove(sb.Length - 2, 2);

            return sb.ToString();
        }

        public string ByteArrayToASMHex(byte[] Data)
        {
            StringBuilder sb = new StringBuilder();

            for (int buc = 0; buc < Data.Length; buc++)
            {
                if (buc % 8 == 0)
                    sb.Append("    DEFB " + Data[buc].ToString("X2").PadLeft(3, '0') + "h, ");
                else if (buc == Data.Length - 1 || buc % 8 == 7)
                    sb.Append(Data[buc].ToString("X2").PadLeft(3, '0') + "h\r\n");
                else
                    sb.Append(Data[buc].ToString("X2").PadLeft(3, '0') + "h, ");
            }

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
                    if (child is ToolbarContainer)
                        continue;

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
                    csManager.CharSetUp -= CsManager_CharSetUp;
                    csManager.CharSetDown -= CsManager_CharSetDown;
                    csManager.Close();
                    csManager.Dispose();
                    csManager = null;
                }

                PluginManager.ProjectUnload();
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
            csManager.CharSetUp += CsManager_CharSetUp;
            csManager.CharSetDown += CsManager_CharSetDown;

            PluginManager.NewProject();

            EnableProjectButtons();
        }

        private void CsManager_CharSetDown(object sender, CharSetEventArgs e)
        {
           
        }

        private void CsManager_CharSetUp(object sender, CharSetEventArgs e)
        {
            
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
            }

            PluginManager.DeleteCharSet(e.CharSet);
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
                save.FileName = Path.GetFileName(currentFile);
                save.InitialDirectory = Path.GetDirectoryName(currentFile);
                if (save.ShowDialog() != DialogResult.OK)
                    return false;

                var sets = csManager.CharSets;

                currentProject.Sprites = sets.Sprites;
                currentProject.Tiles = sets.Tiles;
                currentProject.StoredData = PluginManager.GetPluginsData();

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
                    if (child is ToolbarContainer)
                        continue;

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
                    csManager.CharSetUp -= CsManager_CharSetUp;
                    csManager.CharSetDown -= CsManager_CharSetDown;
                    csManager.Close();
                    csManager.Dispose();
                    csManager = null;
                }

                PluginManager.ProjectUnload();
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
                csManager.CharSetUp += CsManager_CharSetUp;
                csManager.CharSetDown += CsManager_CharSetDown;

                csManager.CharSets = new CharSetListCharSets { Sprites = currentProject.Sprites, Tiles = currentProject.Tiles };
                this.Text = $"Editing project {currentProject.Name}";
            }

            PluginManager.ProjectLoad(currentProject.StoredData, currentProject.Sprites, currentProject.Tiles);

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
                    if (string.IsNullOrWhiteSpace(content))
                        return;
                    TextEditor editor = new TextEditor(currentProject.Name, content);
                    editor.MdiParent = this;
                    editor.Show();
                    break;

                case Enums.ExportTarget.Clipboard:
                    string contentc = GenerateProjectCode(spriteSection, tileSection);
                    if (string.IsNullOrWhiteSpace(contentc))
                        return;
                    Clipboard.SetText(contentc);
                    MessageBox.Show("Content copied to clipboard");
                    break;

                case Enums.ExportTarget.File:

                    string contentf = GenerateProjectCode(spriteSection, tileSection);
                    if (string.IsNullOrWhiteSpace(contentf))
                        return;
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

                if (SpriteSection.Preshifted)
                {
                    List<byte[]> shiftedData = new List<byte[]>();
                    List<string> names = new List<string>();
                    List<int> offsets = new List<int>();

                    StringBuilder dataBuilder = new StringBuilder();
                    StringBuilder indexBuilder = new StringBuilder();
                    StringBuilder defineBuilder = new StringBuilder();

                    offsets.Add(0);
                    int offset = 0;

                    foreach (var set in charsets.Sprites)
                    {

                        if (set.Sort != CharSetSort.UpDown)
                        {
                            MessageBox.Show("Only Up-to-down sprites can be used with GuSprites, export cancelled.");
                            return null;
                        }

                        names.Add(set.Name.Replace(" ", "").ToUpper());
                        var newData = GenerateShiftedData(set);
                        shiftedData.Add(newData);
                        offset += newData.Length;
                        offsets.Add(offset);
                    }

                    dataBuilder.AppendLine("SPRITE_BUFFER:");
                    indexBuilder.AppendLine("SPRITE_INDEX:");
                    for (int buc = 0; buc < shiftedData.Count; buc++)
                    {
                        if (SpriteSection.Defines)
                        {
                            dataBuilder.AppendLine(names[buc] + "_ADDRESS:");
                            defineBuilder.AppendLine("#define " + names[buc] + "_INDEX " + (buc + 1));
                        }
                        dataBuilder.AppendLine(ByteArrayToASMHex(shiftedData[buc]));
                        indexBuilder.AppendLine($"    DEFW (SPRITE_BUFFER + {offsets[buc]})");
                    }

                    indexBuilder.AppendLine($"    DEFW (SPRITE_BUFFER + {offsets.Last()})");
                    indexBuilder.AppendLine($"\r\nSPRITE_COUNT:\r\n    DEFB {shiftedData.Count}");

                    fullCode.AppendLine("'REM --SPRITE SECTION--\r\n");
                    fullCode.AppendLine("asm\r\n");

                    fullCode.Append(dataBuilder.ToString());
                    fullCode.AppendLine(indexBuilder.ToString());

                    fullCode.AppendLine("end asm\r\n");

                    if (SpriteSection.Defines)
                        fullCode.AppendLine(defineBuilder.ToString());
                }
                else
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

                        var byteData = set.Data;

                        foreach (var arr in byteData)
                        {
                            currentSet.Add(ByteArrayToHex(arr));
                            totalChars++;
                        }

                        indexes.Add(currentIndex);
                        currentIndex = currentIndex + set.Data.Length * 8;
                        names.Add(set.Name.Replace(" ", ""));
                        setStrings.Add(currentSet.ToArray());

                    }
                    if (SpriteSection.Defines)
                    {
                        for (int buc = 0; buc < indexes.Count; buc++)
                        {
                            defineBuilder.AppendLine($"#define {names[buc].ToUpper()}_ADDRESS (@{SpriteSection.Name} + {indexes[buc]})");
                        }
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
                        arrayBuilder.Append(" _");
                    }


                    fullCode.AppendLine("'REM --SPRITE SECTION--\r\n");

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
                    arrayBuilder.Append(" _");
                }

                fullCode.AppendLine("'REM --TILE SECTION--\r\n");

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

                if (TileSection.IncludeColors)
                {

                    string colorContent = "$0, " + ColorArrayToHex(charsets.Tiles.SelectMany(c => c.ColorData).ToArray());

                    fullCode.Append(string.Format(CodeTemplates.CharSetSingleDimTemplate, TileSection.ColorsName, currentIndex, colorContent));
                    fullCode.AppendLine();
                }

            }

            return fullCode.ToString();
        }

        private byte[] GenerateShiftedData(CharSet set)
        {
            if (set.Sort != CharSetSort.UpDown)
                return new byte[0];

            var byteData = set.Data;

            //First, generate the only vertically shifted sprite.
            //Its used for unshifted or only vertically shifted sprites on screen.
            List<byte> shiftedData = new List<byte>();

            for (int x = 0; x < set.Width; x++)
            {
                //First, add four empty bytes to the column

                shiftedData.Add(0);
                shiftedData.Add(0);
                shiftedData.Add(0);
                shiftedData.Add(0);

                //Then add the unshifted bytes
                for (int y = 0; y < set.Height; y++)
                {
                    shiftedData.AddRange(byteData[set.GetCharIndex(x, y)]);
                }

                //And add the final four empty bytes
                shiftedData.Add(0);
                shiftedData.Add(0);
                shiftedData.Add(0);
                shiftedData.Add(0);
            }

            //Now, create the real shifted sprites.
            //To ease the calculations first we create rows of bytes and after that we will reoirder it in columns
            List<byte[]> shiftedRows = new List<byte[]>();

            int rowWidth = set.Width + 1;

            byte[] emptyRow = new byte[rowWidth];

            //Add four empty rows
            shiftedRows.Add(emptyRow);
            shiftedRows.Add(emptyRow);
            shiftedRows.Add(emptyRow);
            shiftedRows.Add(emptyRow);

            //Now, shift the data

            for (int y = 0; y < set.Height; y++)
            {
                for (int charRow = 0; charRow < 8; charRow++)
                {
                    byte[] newRow = new byte[rowWidth];
                    
                    for (int x = 0; x < set.Width; x++)
                        newRow[x] = byteData[set.GetCharIndex(x, y)][charRow];

                    newRow.ShiftRight();
                    newRow.ShiftRight();
                    newRow.ShiftRight();
                    newRow.ShiftRight();

                    shiftedRows.Add(newRow);
                }
            }

            shiftedRows.Add(emptyRow);
            shiftedRows.Add(emptyRow);
            shiftedRows.Add(emptyRow);
            shiftedRows.Add(emptyRow);

            for (int x = 0; x < rowWidth; x++)
            {
                for (int y = 0; y < shiftedRows.Count; y++)
                {
                    shiftedData.Add(shiftedRows[y][x]);
                }
            }

            return shiftedData.ToArray();
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
                    if (child is ToolbarContainer)
                        continue;

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
                    csManager.CharSetUp -= CsManager_CharSetUp;
                    csManager.CharSetDown -= CsManager_CharSetDown;
                    csManager.Close();
                    csManager.Dispose();
                    csManager = null;
                }

                PluginManager.ProjectUnload();
            }

            currentProject = null;
            this.Text = " GuSprites Resource Designer";
            DisableProjectButtons();
        }

        void EnableProjectButtons()
        {
            saveProjectButton.Enabled = true;
            closeProjectButton.Enabled = true;
            toClipboardButton.Enabled = true;
            toEditorButton.Enabled = true;
            toFileButton.Enabled = true;
            addCharSetButton.Enabled = true;
            newAnimationButton.Enabled = true;

            PluginManager.EnablePluginItems();
        }

        void DisableProjectButtons()
        {
            saveProjectButton.Enabled = false;
            closeProjectButton.Enabled = false;
            toClipboardButton.Enabled = false;
            toEditorButton.Enabled = false;
            toFileButton.Enabled = false;
            addCharSetButton.Enabled = false;
            newAnimationButton.Enabled = false;

            PluginManager.DisablePluginItems();
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
            if (this.WindowState != FormWindowState.Minimized && csManager != null)
            {
                csManager.Height = this.ClientSize.Height - (mainToolbar.Height + statusStrip.Height + 5);
                csManager.Left = this.ClientSize.Width - (csManager.Width + 5);
                csManager.Top = 0;
            }
        }

        private void MainForm_MdiChildActivate(object sender, EventArgs e)
        {
            if (ActiveMdiChild is CharSetEditor)
                charEditTools.ActiveEditor = ActiveMdiChild as CharSetEditor;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            PluginManager.Terminate();
        }
    }
}
