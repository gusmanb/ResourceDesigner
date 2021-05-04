using ResourceDesigner.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTMapEditorPlugin
{
    public partial class MapElement : UserControl
    {
        Bitmap currentTexture;

        CharSet set;
        public CharSet Set 
        {
            get { return set; }
            set 
            {
                set = value; 
                DrawElement(); 
            } 
        }
        int scale = 1;
        public int SetScale 
        {
            get { return scale; }
            set 
            { 
                scale = value; 
                DrawElement(); 
            } 
        }

        int pixelScale;
        public int PixelScale 
        {
            get 
            {
                return pixelScale;
            }
            set 
            {
                pixelScale = value;
                DrawElement();
            }
        }

        Color overColor = Color.Transparent;
        public Color OverColor
        {
            get { return OverColor; }
            set 
            {
                overColor = value;
                DrawElement();
            }
        }

        public int CellX { get; set; }
        public int CellY { get; set; }

        public MapElement()
        {
            InitializeComponent();
        }

        void DrawElement()
        {
            elementView.Image = null;

            if (currentTexture != null)
                currentTexture.Dispose();

            if (set == null)
                return;

            if (scale == 1)
                currentTexture = set.GenerateImage();
            else
            {
                if (set.Width < 3 && set.Height < 3)
                {
                    scale = 1;
                    currentTexture = set.GenerateImage();

                    if (overColor.A != 0)
                    {
                        Brush br = new SolidBrush(overColor);
                        Graphics g = Graphics.FromImage(currentTexture);
                        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                        g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
                        g.FillRectangle(br, 0, 0, currentTexture.Width, currentTexture.Height);
                        br.Dispose();
                        g.Dispose();
                    }
                }
                else
                {
                    int he = set.Height == 3 ? 3 + scale - 1 : set.Height;
                    int wi = set.Width == 3 ? 3 + scale - 1 : set.Width;

                    currentTexture = new Bitmap(he * 8, wi * 8, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                    Graphics g = Graphics.FromImage(currentTexture);
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                    g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;

                    var charImages = set.GenerateCharImages();

                    for (int y = 0; y < he; y++)
                    {
                        for (int x = 0; x < wi; x++)
                        {
                            int xI = x == 0 ? 0 : (x == wi - 1 ? 2 : 1);
                            int yI = y == 0 ? 0 : (y == he - 1 ? 2 : 1);

                            int index = set.GetCharIndex(xI, yI);
                            g.DrawImageUnscaled(charImages[index], x * 8, y * 8);
                            charImages[index].Dispose();
                        }
                    }

                    if (overColor.A != 0)
                    {
                        Brush br = new SolidBrush(overColor);
                        g.FillRectangle(br, 0, 0, currentTexture.Width, currentTexture.Height);
                        br.Dispose();
                    }

                    g.Dispose();
                }
            }

            elementView.Image = currentTexture;
            this.Width = currentTexture.Width * pixelScale;
            this.Height = currentTexture.Height * pixelScale;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            pe.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            pe.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;
            base.OnPaint(pe);
        }
    }
}
