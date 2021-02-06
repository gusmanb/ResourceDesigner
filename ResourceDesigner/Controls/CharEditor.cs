using ResourceDesigner.Classes;
using ResourceDesigner.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResourceDesigner.Controls
{
    public partial class CharEditor : UserControl
    {
        public const int PixelSizeBase = 16;
        public const int EditorSizeBase = PixelSizeBase * 8;

        private int pixelSize = PixelSizeBase;
        private int editorSize = EditorSizeBase;

        private CharSetEditorScale currentScale = CharSetEditorScale.x1;
       
        Bitmap pixels;

        public event EventHandler<CoordinatesEventArgs> PixelDown;
        public event EventHandler Updated;

        ColorComponent charColor = ColorComponent.InkBlack | ColorComponent.PaperWhite;
        Color inkColor = ColorComponent.InkBlack.ToColor(ColorComponent.Ink);
        Color paperColor = ColorComponent.PaperWhite.ToColor(ColorComponent.Paper);

        public ColorComponent CharColor 
        { 
            get 
            {
                return charColor;
            } 
            set
            {
                charColor = value;
                var data = Data;
                inkColor = charColor.ToColor(ColorComponent.Ink);
                paperColor = charColor.ToColor(ColorComponent.Paper);
                Data = data;
            } 
        }
        public int PixelSize { get { return pixelSize; } }
        public int EditorSize { get { return editorSize; } }
        public CharSetEditorScale ViewScale 
        {
            get { return currentScale; }
            set { currentScale = value; Rescale(); }
        }

        public byte[] Data 
        { 
            get 
            {
                byte[] data = new byte[8];
                for (int y = 0; y < 8; y++)
                {
                    for (int x = 0; x < 8; x++)
                    {
                        if (pixels.GetPixel(x, y).ToArgb() == inkColor.ToArgb())
                            data[y] = (byte)(data[y] | (128 >>  x));
                    }
                }

                return data;
            }
            set 
            {
                if (value.Length != 8)
                    return;

                for (int y = 0; y < 8; y++)
                {
                    for (int x = 0; x < 8; x++)
                    {
                        if ((value[y] & (128 >> x)) != 0)
                            pixels.SetPixel(x, y, inkColor);
                        else
                            pixels.SetPixel(x, y, paperColor);
                    }
                }

                Invalidate();
            }
        }

        public Bitmap Image 
        {
            get 
            {
                return pixels.Clone() as Bitmap;
            }
        }

        public CharEditor()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;

            InitializeComponent();

            AllowDrop = true;

            Rescale();

            pixels = new Bitmap(8, 8, PixelFormat.Format32bppPArgb);
            Graphics g = Graphics.FromImage(pixels);
            g.Clear(paperColor);
            g.Dispose();
        }

        private void Rescale()
        {
            pixelSize = PixelSizeBase * (int)currentScale;
            editorSize = EditorSizeBase * (int)currentScale;

            this.MaximumSize = new Size(editorSize, editorSize);
            this.MinimumSize = new Size(editorSize, editorSize);
            this.Size = new Size(editorSize, editorSize);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            e.Graphics.DrawImage(pixels, new Rectangle(0, 0, this.Width, this.Height), new RectangleF(0,0,pixels.Width, pixels.Height), GraphicsUnit.Pixel);

            for (int x = PixelSize; x < this.Width; x += PixelSize)
                e.Graphics.DrawLine(Pens.Black, x, 0, x, this.Height);

            for (int y = PixelSize; y < this.Height; y += PixelSize)
                e.Graphics.DrawLine(Pens.Black, 0, y, this.Width, y);

            e.Graphics.DrawRectangle(Pens.Black, new Rectangle(1, 1, this.Width - 1, this.Height - 1));
        }

        private void CharEditor_MouseUp(object sender, MouseEventArgs e)
        {
            Updated(this, EventArgs.Empty);
        }

        public void SetPixel(int X, int Y)
        {
            pixels.SetPixel(X, Y, inkColor);
            this.Invalidate();
        }

        public void ClearPixel(int X, int Y)
        {
            pixels.SetPixel(X, Y, paperColor);
            this.Invalidate();
        }

        private void CharEditor_MouseDown(object sender, MouseEventArgs e)
        {
            Capture = false;

            int x = e.X / PixelSize;
            int y = e.Y / PixelSize;

            if (x < 0 || x > 7 || y < 0 || y > 7)
                return;


            if (e.Button == MouseButtons.Left)
            {
                pixels.SetPixel(x, y, inkColor);
                PixelDown(this, new CoordinatesEventArgs { Coordinates = new Point(x, y), Set = true });
            }
            else if (e.Button == MouseButtons.Right)
            {
                pixels.SetPixel(x, y, paperColor);
                PixelDown(this, new CoordinatesEventArgs { Coordinates = new Point(x, y), Set = false });
            }

            Invalidate();
        }

        private void CharEditor_MouseMove(object sender, MouseEventArgs e)
        {
            int x = e.X / PixelSize;
            int y = e.Y / PixelSize;

            if (x < 0 || x > 7 || y < 0 || y > 7)
                return;

            if (e.Button == MouseButtons.Left)
                pixels.SetPixel(e.X / PixelSize, e.Y / PixelSize, inkColor);
            else if (e.Button == MouseButtons.Right)
                pixels.SetPixel(e.X / PixelSize, e.Y / PixelSize, paperColor);

            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
                Invalidate();

        }

        public void MirrorHorizontal()
        {
            byte[] data = Data;
            for (int buc = 0; buc < 8; buc++)
            {
                var currentByte = data[buc];
                byte newByte = 0;
                for (int bit = 0; bit < 8; bit++)
                {
                    var value = (currentByte >> bit) & 1;
                    newByte = (byte)(newByte | (value << (7 - bit)));
                }
                data[buc] = newByte;
            }
            Data = data;
            Updated(this, EventArgs.Empty);
        }

        public void MirrorVertical()
        {
            Data = Data.Reverse().ToArray();
            Updated(this, EventArgs.Empty);
        }

        private void CharEditor_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("ColorComponent"))
                e.Effect = e.AllowedEffect;
            else
                e.Effect = DragDropEffects.None;
        }

        private void CharEditor_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("ColorComponent"))
            {
                this.CharColor = (ColorComponent)e.Data.GetData("ColorComponent");
                Updated(this, EventArgs.Empty);
            }
        }
    }

    public class CoordinatesEventArgs : EventArgs
    {
        public Point Coordinates { get; set; }
        public bool Set { get; set; }
    }

    public enum CharSetEditorScale
    {
        x1 = 1,
        x2 = 2,
        x3 = 3,
        x4 = 4
    }
}
