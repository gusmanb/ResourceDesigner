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
        public const int PixelSize = 16;
        public const int EditorSize = PixelSize * 8;

        Bitmap pixels;

        public event EventHandler<CoordinatesEventArgs> PixelDown;
        public event EventHandler Updated;

        public byte[] Data 
        { 
            get 
            {
                byte[] data = new byte[8];
                for (int y = 0; y < 8; y++)
                {
                    for (int x = 0; x < 8; x++)
                    {
                        if (pixels.GetPixel(x, y).A != 0)
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
                            pixels.SetPixel(x, y, Color.Black);
                        else
                            pixels.SetPixel(x, y, Color.Transparent);
                    }
                }

                drawArea.Invalidate();
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

            this.MaximumSize = new Size(EditorSize, EditorSize);
            this.MinimumSize = new Size(EditorSize, EditorSize);

            this.BackColor = Color.Transparent;
            drawArea.BackColor = Color.Transparent;

            pixels = new Bitmap(8, 8, PixelFormat.Format32bppPArgb);
            Graphics g = Graphics.FromImage(pixels);
            g.Clear(Color.Transparent);
            g.Dispose();
            drawArea.Image = pixels;
            drawArea.MouseDown += DrawArea_MouseDown;
            drawArea.MouseUp += DrawArea_MouseUp;
            drawArea.MouseMove += DrawArea_MouseMove;
        }

        private void DrawArea_MouseUp(object sender, MouseEventArgs e)
        {
            Updated(this, EventArgs.Empty);
        }

        public void SetPixel(int X, int Y)
        {
            pixels.SetPixel(X, Y, Color.Black);
            this.Invalidate();
        }

        public void ClearPixel(int X, int Y)
        {
            pixels.SetPixel(X, Y, Color.Transparent);
            this.Invalidate();
        }

        private void DrawArea_MouseDown(object sender, MouseEventArgs e)
        {
            drawArea.Capture = false;

            int x = e.X / PixelSize;
            int y = e.Y / PixelSize;

            if (x < 0 || x > 7 || y < 0 || y > 7)
                return;


            if (e.Button == MouseButtons.Left)
            {
                pixels.SetPixel(x, y, Color.Black);
                PixelDown(this, new CoordinatesEventArgs { Coordinates = new Point(x, y), Set = true });
            }
            else if (e.Button == MouseButtons.Right)
            {
                pixels.SetPixel(x, y, Color.Transparent);
                PixelDown(this, new CoordinatesEventArgs { Coordinates = new Point(x, y), Set = false });
            }

            drawArea.Invalidate();
        }

        private void DrawArea_MouseMove(object sender, MouseEventArgs e)
        {
            int x = e.X / PixelSize;
            int y = e.Y / PixelSize;

            if (x < 0 || x > 7 || y < 0 || y > 7)
                return;

            if (e.Button == MouseButtons.Left)
                pixels.SetPixel(e.X / PixelSize, e.Y / PixelSize, Color.Black);
            else if (e.Button == MouseButtons.Right)
                pixels.SetPixel(e.X / PixelSize, e.Y / PixelSize, Color.Transparent);

            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
                drawArea.Invalidate();

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
        }

        public void MirrorVertical()
        {
            Data = Data.Reverse().ToArray();
        }
    }

    public class CoordinatesEventArgs : EventArgs
    {
        public Point Coordinates { get; set; }
        public bool Set { get; set; }
    }
}
