using ResourceDesigner.Classes;
using ResourceDesigner.Controls;
using ResourceDesigner.Enums;
using ResourceDesigner.Forms.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResourceDesigner.Forms
{
    public partial class CharSetEditor : Form, IDisposable
    {
        public event EventHandler<ExportEventArgs> Export;
        public event EventHandler<CharSetEventArgs> Save;
        public event EventHandler<CharSetEventArgs> Update;

        CharTool currentChartTool = CharTool.None;
        Point? currentPoint = null;
        bool set = false;

        int currentScale = 1;
        public CharSet CurrentSet
        {
            get
            {
                return new CharSet
                {
                    Data = chars.Select(c => c.Data).ToArray(),
                    ColorData = chars.Select(c => c.CharColor).ToArray(),
                    Height = CharHeight,
                    SetType = CharSetType,
                    Sort = CharSetSort,
                    Width = CharWidth,
                    Name = CharSetName,
                    Id = CharSetId
                };

            }
        }
        public int CharWidth { get; private set; }
        public int CharHeight { get; private set; }
        public CharSetSort CharSetSort { get; private set; }
        public CharSetType CharSetType { get; set; }
        public string CharSetName { get; set; }

        public Guid CharSetId { get; private set; }

        CharEditor[] chars;

        Bitmap bitmapGrid;

        ColorComponent currentInk = ColorComponent.InkBlack;
        ColorComponent currentPaper = ColorComponent.PaperWhite;
        ColorComponent currentBright = ColorComponent.None;
        ColorComponent currentFlash = ColorComponent.None;

        public CharSetEditor(string CharSetName, int CharWidth, int CharHeight, CharSetSort CharSetSort, CharSetType CharSetType)
        {
            ConfigureForm();

            this.CharWidth = CharWidth;
            this.CharHeight = CharHeight;
            this.CharSetSort = CharSetSort;
            this.CharSetName = CharSetName;
            this.CharSetType = CharSetType;
            this.CharSetId = Guid.NewGuid();

            SetText();
            GenerateEditors();

            if (CharSetType == CharSetType.Sprite)
            {
                inkButton.Enabled = false;
                paperButton.Enabled = false;
                brightButton.Enabled = false;
                flashButton.Enabled = false;
                lblDrop.Enabled = false;
            }
        }
        public CharSetEditor(CharSet Source)
        {
            ConfigureForm();

            this.CharWidth = Source.Width;
            this.CharHeight = Source.Height;
            this.CharSetSort = Source.Sort;
            this.CharSetName = Source.Name;
            this.CharSetType = Source.SetType;
            this.CharSetId = Source.Id;

            SetText();
            GenerateEditors();
            for (int buc = 0; buc < chars.Length; buc++)
            {
                chars[buc].CharColor = Source.ColorData?[buc] ?? ColorComponent.InkBlack | ColorComponent.PaperWhite;
                chars[buc].Data = Source.Data[buc];
            }
        }

        private void ConfigureForm()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            InitializeComponent();
        }
        private void SetText()
        {
            this.Text = $"{CharSetType.ToString()} {CharSetName}, {CharWidth}x{CharHeight} chars, sorted {CharSetSort.ToString()}";
        }
        private void GenerateEditors()
        {
            chars = new CharEditor[CharWidth * CharHeight];

            if (CharSetSort == CharSetSort.UpDown)
            {
                for (int x = 0; x < CharWidth; x++)
                {
                    for (int y = 0; y < CharHeight; y++)
                    {
                        CharEditor newChar = new CharEditor();
                        newChar.PixelDown += NewChar_PixelDown;
                        newChar.Updated += NewChar_Updated;
                        newChar.Top = y * CharEditor.EditorSizeBase + actionToolbar.Height;
                        newChar.Left = x * CharEditor.EditorSizeBase;
                        this.Controls.Add(newChar);
                        newChar.Visible = true;
                        chars[y + x * CharHeight] = newChar;
                    }
                }
            }
            else
            {
                for (int y = 0; y < CharHeight; y++)
                {
                    for (int x = 0; x < CharWidth; x++)
                    {
                        CharEditor newChar = new CharEditor();
                        newChar.PixelDown += NewChar_PixelDown;
                        newChar.Updated += NewChar_Updated;
                        newChar.Top = y * CharEditor.EditorSizeBase + actionToolbar.Height;
                        newChar.Left = x * CharEditor.EditorSizeBase;
                        this.Controls.Add(newChar);
                        newChar.Visible = true;
                        chars[x + y * CharHeight] = newChar;
                    }
                }
            }

            this.ClientSize = new Size(CharWidth * CharEditor.EditorSizeBase, CharHeight * CharEditor.EditorSizeBase + actionToolbar.Height);
        }

        private void NewChar_Updated(object sender, EventArgs e)
        {
            Update(this, new CharSetEventArgs { CharSet = CurrentSet });
        }

        private void NewChar_PixelDown(object sender, CoordinatesEventArgs e)
        {
            if (currentChartTool != CharTool.None)
            {

                var newPoint = GetCoordinates(Array.IndexOf(chars, (CharEditor)sender));
                newPoint.X = newPoint.X + e.Coordinates.X;
                newPoint.Y = newPoint.Y + e.Coordinates.Y;

                if (currentPoint == null)
                {
                    currentPoint = newPoint;
                    set = e.Set;
                }
                else if (set != e.Set)
                    currentPoint = null;
                else
                {
                    var linePoints = ComputeLine(currentPoint.Value.X, currentPoint.Value.Y, newPoint.X, newPoint.Y);

                    foreach (var point in linePoints)
                    {
                        int idx = GetIndexPixel(point.X, point.Y);

                        var edit = chars[idx];
                        if (set)
                            edit.SetPixel(point.X % 8, point.Y % 8);
                        else
                            edit.ClearPixel(point.X % 8, point.Y % 8);
                    }

                    if (currentChartTool == CharTool.Line)
                        currentPoint = null;
                    else
                        currentPoint = newPoint;
                }
            }
        }

        /*
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            var rect = new Rectangle(e.ClipRectangle.Location, e.ClipRectangle.Size);
            rect.Y -= actionToolbar.Height;
            base.OnPaintBackground(e);
            e.Graphics.DrawImage(bitmapGrid, e.ClipRectangle, rect, GraphicsUnit.Pixel);

        }
        private void GenerateGrid()
        {
            bitmapGrid = new Bitmap(this.ClientSize.Width, this.ClientSize.Height - actionToolbar.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            Graphics g = Graphics.FromImage(bitmapGrid);

            for (int x = 1; x < 8 * CharWidth; x++)
            {
                int offset = x * CharEditor.PixelSizeBase * currentScale;

                g.DrawLine(Pens.Black, offset, 0, offset, this.ClientSize.Height - actionToolbar.Height);
            }

            for (int y = 1; y < 8 * CharHeight; y++)
            {
                int offset = y * CharEditor.PixelSizeBase * currentScale;

                g.DrawLine(Pens.Black, 0, offset, this.ClientSize.Width, offset);
            }

            g.DrawRectangle(Pens.Black, 0, 0, bitmapGrid.Width-1, bitmapGrid.Height-1);

            g.Flush();
            g.Dispose();
        }
        */

        private void clipboardButton_Click(object sender, EventArgs e)
        {
            BeginExport(ExportTarget.Clipboard);
        }
        private void toEditorButton_Click(object sender, EventArgs e)
        {
            BeginExport(ExportTarget.Editor);
        }
        private void toFileButton_Click(object sender, EventArgs e)
        {
            BeginExport(ExportTarget.File);
        }
        private void discardButton_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
        private void clearButton_Click(object sender, EventArgs e)
        {
            foreach (var charEditor in chars)
                charEditor.Data = new byte[8];
        }
        private void mirrorHorizontalButton_Click(object sender, EventArgs e)
        {
            MirrorHorizontal();
        }
        private void mirrorVerticalButton_Click(object sender, EventArgs e)
        {
            MirrorVertical();
        }
        private void BeginExport(ExportTarget Target)
        {
            using (var dlg = new ExportCharSetDialog())
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    ExportEventArgs args = new ExportEventArgs
                    {
                        Prefix = dlg.Prefix,
                        Postfix = dlg.Postfix,
                        SingleDim = dlg.SingleDimension,
                        CharSet = CurrentSet,
                        Target = Target,
                        Colors = dlg.IncludeColors
                    };

                    Export(this, args);
                }
            }
        }
        private void MirrorVertical()
        {
            foreach (var charEdit in chars)
                charEdit.MirrorVertical();

            for (int x = 0; x < CharWidth; x++)
            {
                for (int y = 0; y < CharHeight / 2; y++)
                {
                    int yRight = (CharHeight - 1) - y;

                    var leftIndex = GetIndex(x, y);
                    var rightIndex = GetIndex(x, yRight);

                    var tmp = chars[leftIndex];
                    chars[leftIndex] = chars[rightIndex];
                    chars[rightIndex] = tmp;

                    chars[leftIndex].Top = CharEditor.EditorSizeBase * currentScale * y + actionToolbar.Height;
                    chars[rightIndex].Top = CharEditor.EditorSizeBase * currentScale * yRight + actionToolbar.Height;
                }
            }

            Update(this, new CharSetEventArgs { CharSet = CurrentSet });
        }
        private void MirrorHorizontal()
        {
            foreach (var charEdit in chars)
                charEdit.MirrorHorizontal();

            for (int y = 0; y < CharHeight; y++)
            {
                for (int x = 0; x < CharWidth / 2; x++)
                {
                    int xRight = (CharWidth - 1) - x;
                    
                    var leftIndex = GetIndex(x, y);
                    var rightIndex = GetIndex(xRight, y);

                    var tmp = chars[leftIndex];
                    chars[leftIndex] = chars[rightIndex];
                    chars[rightIndex] = tmp;

                    chars[leftIndex].Left = CharEditor.EditorSizeBase * currentScale * x;
                    chars[rightIndex].Left = CharEditor.EditorSizeBase * currentScale * xRight;
                }
            }

            Update(this, new CharSetEventArgs { CharSet = CurrentSet });
        }
        private int GetIndex(int X, int Y)
        {
            int index = 0;

            if (CharSetSort == CharSetSort.LeftRight)
            {
                index = Y * CharWidth;
                index += X;
            }
            else
            {
                index = X * CharHeight;
                index += Y;
            }

            return index;
        }
        private int GetIndexPixel(int X, int Y)
        {
            int index = 0;

            X = (X - (X % 8)) / 8;
            Y = (Y - (Y % 8)) / 8;

            if (CharSetSort == CharSetSort.LeftRight)
            {
                index = Y * CharWidth;
                index += X;
            }
            else
            {
                index = X * CharHeight;
                index += Y;
            }

            return index;
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            Save(this, new CharSetEventArgs { CharSet = CurrentSet });
        }
        private void duplicateButton_Click(object sender, EventArgs e)
        {
            using(var dlg = new DuplicateCharSetDialog())
            {
                dlg.NewName = CharSetName + "Copy";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    CharSetId = Guid.NewGuid();
                    CharSetName = dlg.NewName;
                    Save(this, new CharSetEventArgs { CharSet = CurrentSet });
                    SetText();
                }
            }
        }
        private Point GetCoordinates(int Index)
        {
            if (CharSetSort == Enums.CharSetSort.UpDown)
            {
                int y = Index % CharHeight;
                int x = (Index - y) / CharHeight;
                return new Point(x * 8, y * 8);
            }
            else
            {
                int x = Index % CharWidth;
                int y = (Index - x) / CharWidth;
                return new Point(x * 8, y * 8);
            }
        }
        private List<Point> ComputeLine(int x0, int y0, int x1, int y1)
        {

            int dx = Math.Abs(x1 - x0), sx = x0 < x1 ? 1 : -1;
            int dy = Math.Abs(y1 - y0), sy = y0 < y1 ? 1 : -1;
            int err = (dx > dy ? dx : -dy) / 2, e2;

            List<Point> finalPoints = new List<Point>();

            for (; ; )
            {
                finalPoints.Add(new Point(x0, y0));

                if (x0 == x1 && y0 == y1) break;
                e2 = err;
                if (e2 > -dx) { err -= dy; x0 += sx; }
                if (e2 < dy) { err += dx; y0 += sy; }
            }

            return finalPoints;
        }
        private void lineToolButton_CheckedChanged(object sender, EventArgs e)
        {
            if (lineToolButton.Checked)
            {
                multiToolButton.Checked = false;
                currentChartTool = CharTool.Line;
                currentPoint = null;
            }
            else
            {
                if (!multiToolButton.Checked)
                    currentChartTool = CharTool.None;
            }
        }
        private void multiToolButton_Click(object sender, EventArgs e)
        {
            if (multiToolButton.Checked)
            {
                lineToolButton.Checked = false;
                currentChartTool = CharTool.Multiline;
                currentPoint = null;
            }
            else
            {
                if (!lineToolButton.Checked)
                    currentChartTool = CharTool.None;
            }
        }
        private void Scale(CharSetEditorScale NewScale)
        {
            currentScale = (int)NewScale;
            this.ClientSize = new Size(CharWidth * CharEditor.EditorSizeBase * currentScale, CharHeight * CharEditor.EditorSizeBase * currentScale + actionToolbar.Height);
            
            for (int buc = 0; buc < chars.Length; buc++)
            {
                var editor = chars[buc];
                editor.ViewScale = NewScale;

                var coords = GetCoordinates(buc);
                int x = (coords.X / 8) * editor.EditorSize;
                int y = (coords.Y / 8) * editor.EditorSize + actionToolbar.Height;
                editor.Top = y;
                editor.Left = x;
            }


            //grid.GridSize = chars[0].PixelSize;

            Invalidate();
        }
        private void mnuScale1_Click(object sender, EventArgs e)
        {
            Scale(CharSetEditorScale.x1);
        }
        private void mnuScale2_Click(object sender, EventArgs e)
        {
            Scale(CharSetEditorScale.x2);
        }
        private void mnuScale3_Click(object sender, EventArgs e)
        {
            Scale(CharSetEditorScale.x3);
        }
        private void mnuScale4_Click(object sender, EventArgs e)
        {
            Scale(CharSetEditorScale.x4);
        }
        private void lblDrop_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DataObject dob = new DataObject("ColorComponent", currentInk | currentPaper | currentBright | currentFlash);
                lblDrop.DoDragDrop(dob, DragDropEffects.Copy);
            }
        }
        private void UpdateDragColorsImage()
        {
            var currentColor = currentInk | currentPaper | currentBright | currentFlash;
            var inkColor = currentColor.ToColor(ColorComponent.Ink);
            var paperColor = currentColor.ToColor(ColorComponent.Paper);

            Bitmap newBitmap = new Bitmap(16, 16, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            using (Graphics g = Graphics.FromImage(newBitmap))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
                using (Brush inkBrush = new SolidBrush(inkColor))
                    g.FillRectangle(inkBrush, new Rectangle(0, 0, 8, 16));
                using (Brush paperBrush = new SolidBrush(paperColor))
                    g.FillRectangle(paperBrush, new Rectangle(8, 0, 8, 16));
                g.DrawRectangle(Pens.Black, 1, 1, 15, 15);
            }

            if (lblDrop.Image != null)
                lblDrop.Image.Dispose();

            lblDrop.Image = newBitmap;
        }
        private void InkMenu_Click(object sender, EventArgs e)
        {
            currentInk = Enum.Parse<ColorComponent>("Ink" + (sender as ToolStripMenuItem).Text);
            UpdateDragColorsImage();
        }
        private void PaperMnu_Click(object sender, EventArgs e)
        {
            currentPaper = Enum.Parse<ColorComponent>("Paper" + (sender as ToolStripMenuItem).Text);
            UpdateDragColorsImage();
        }
        private void brightButton_Click(object sender, EventArgs e)
        {
            if (brightButton.Checked)
                currentBright = ColorComponent.Bright;
            else
                currentBright = ColorComponent.None;

            UpdateDragColorsImage();
        }
        private void flashButton_Click(object sender, EventArgs e)
        {
            if (flashButton.Checked)
                currentFlash = ColorComponent.Flash;
            else
                currentFlash = ColorComponent.None;

            UpdateDragColorsImage();
        }
        private void ShiftUp()
        {
            for (int x = 0; x < CharWidth; x++)
            {
                byte shiftedByte = 0;

                for(int y = CharHeight - 1; y >= 0; y--)
                {
                    int index = GetIndex(x, y);
                    shiftedByte = chars[index].ShiftUp(shiftedByte);
                }
            }

            Update(this, new CharSetEventArgs { CharSet = CurrentSet });
        }
        private void ShiftDown()
        {
            for (int x = 0; x < CharWidth; x++)
            {
                byte shiftedByte = 0;

                for (int y = 0; y < CharHeight; y++)
                {
                    int index = GetIndex(x, y);
                    shiftedByte = chars[index].ShiftDown(shiftedByte);
                }
            }

            Update(this, new CharSetEventArgs { CharSet = CurrentSet });
        }
        private void ShiftLeft()
        {
            for (int y = 0; y < CharHeight; y++)
            {
                byte shiftedByte = 0;

                for (int x = CharWidth - 1; x >= 0; x--)
                {
                    int index = GetIndex(x, y);
                    shiftedByte = chars[index].ShiftLeft(shiftedByte);
                }
            }

            Update(this, new CharSetEventArgs { CharSet = CurrentSet });
        }
        private void ShiftRight()
        {
            for (int y = 0; y < CharHeight; y++)
            {
                byte shiftedByte = 0;

                for (int x = 0; x < CharWidth; x++)
                {
                    int index = GetIndex(x, y);
                    shiftedByte = chars[index].ShiftRight(shiftedByte);
                }
            }

            Update(this, new CharSetEventArgs { CharSet = CurrentSet });
        }

        private void upButton_Click(object sender, EventArgs e)
        {
            ShiftUp();
        }

        private void downButton_Click(object sender, EventArgs e)
        {
            ShiftDown();
        }

        private void leftButton_Click(object sender, EventArgs e)
        {
            ShiftLeft();
        }

        private void rightButton_Click(object sender, EventArgs e)
        {
            ShiftRight();
        }
    }
    enum CharTool
    {
        None,
        Line,
        Multiline
    }
    public class CharSetEventArgs : EventArgs
    {
        public CharSet CharSet { get; set; }
    }
    public class ExportEventArgs : CharSetEventArgs
    {
        public string Prefix { get; set; }
        public string Postfix { get; set; }
        public bool SingleDim { get; set; }
        public ExportTarget Target { get; set; }
        public bool Colors { get; set; }
    }
}
