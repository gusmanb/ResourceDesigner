using Newtonsoft.Json;
using ResourceDesigner.Classes;
using ResourceDesigner.Enums;
using ResourceDesigner.Forms;
using ResourceDesigner.Forms.Dialogs;
using ResourceDesigner.PluginSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTMapEditorPlugin
{
    public partial class MainForm : Form
    {
        List<MapElement> elements = new List<MapElement>();
        MapElement elementOnDrag;
        bool internalDrag;
        int pixelScale = 4;

        CharSet gridSet;
        public CharSet GridSet 
        {
            get 
            {
                return gridSet;
            }
            set 
            {
                gridSet = value;
                CreateTexture();
            }
        }
        public MainPlugin PluginInstance { get; set; }

        public MainForm()
        {
            InitializeComponent();
            SizeWindow();
        }

        public MainForm(MainPlugin Plugin)
        {
            InitializeComponent();
            PluginInstance = Plugin;
            gridSet = Plugin.PluginRequestCharSet("Grid", CharSetType.TileObject)?.Clone();
            CreateTexture();
            SizeWindow();
        }

        void CreateTexture()
        {

            if (bgImage.Image != null)
            {
                bgImage.Image.Dispose();
                bgImage.Image = null;
            }

            if (gridSet != null && gridSet.SetType == CharSetType.TileObject && gridSet.Width == 3 && gridSet.Height == 3)
            {
                var images = gridSet.GenerateCharImages();
                var centerImage = images[4];
                Bitmap bmpBack = new Bitmap(20 * 8, 20 * 8, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                Graphics g = Graphics.FromImage(bmpBack);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;

                for (int y = 0; y < 20; y++)
                {
                    for (int x = 0; x < 20; x++)
                    {
                        g.DrawImageUnscaled(centerImage, x * 8, y * 8);
                    }
                }

                g.Dispose();
                
                foreach (var bm in images)
                    bm.Dispose();

                bgImage.Image = bmpBack;
            }
        }

        void SizeWindow()
        {
            ClientSize = new Size(20 * 8 * pixelScale, 20 * 8 * pixelScale);
            bgImage.Location = Point.Empty;
            bgImage.Width = 20 * 8 * pixelScale;
            bgImage.Height = 20 * 8 * pixelScale;
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.AllowedEffect == DragDropEffects.Copy && e.Data.GetDataPresent("CHARSET_1"))
            {
                CharSet set = e.Data.GetData("CHARSET_1") as CharSet;

                if (set.SetType == CharSetType.Sprite)
                {
                    e.Effect = DragDropEffects.None;
                    return;
                }

                elementOnDrag = new MapElement();
                elementOnDrag.OverColor = Color.FromArgb(128, Color.LightBlue);
                elementOnDrag.PixelScale = pixelScale;
                elementOnDrag.Set = set.Clone();
                this.Controls.Add(elementOnDrag);
                elementOnDrag.BringToFront();
                var coords = PointToClient(new Point(e.X, e.Y));
                PlaceElement(elementOnDrag, coords.X, coords.Y);
                e.Effect = DragDropEffects.Copy;
            }
            else
                e.Effect = DragDropEffects.None;
        }

        private void PlaceElement(MapElement elementOnDrag, int x, int y)
        {
            int cellX = x / (8 * pixelScale);
            int cellY = y / (8 * pixelScale);

            if (cellX + elementOnDrag.Set.Width > 20)
                cellX = 20 - elementOnDrag.Width;

            if (cellY + elementOnDrag.Set.Height > 20)
                cellY = 20 - elementOnDrag.Height;

            elementOnDrag.Left = cellX * 8 * pixelScale;
            elementOnDrag.Top = cellY * 8 * pixelScale;
        }

        private void MainForm_DragLeave(object sender, EventArgs e)
        {
            if (elementOnDrag != null)
            {
                this.Controls.Remove(elementOnDrag);
                elementOnDrag.Dispose();
                elementOnDrag = null;
            }
        }

        private void MainForm_DragOver(object sender, DragEventArgs e)
        {
            if (elementOnDrag != null)
            {
                var coords = PointToClient(new Point(e.X, e.Y));
                PlaceElement(elementOnDrag, coords.X, coords.Y);
                e.Effect = DragDropEffects.Copy;
                Debug.WriteLine($"{coords.X} {coords.Y}");
            }
            else
                e.Effect = DragDropEffects.None;
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            if (elementOnDrag != null)
            {
                var coords = PointToClient(new Point(e.X, e.Y));
                PlaceElement(elementOnDrag, coords.X, coords.Y);
                elements.Add(elementOnDrag);
                elementOnDrag = null;
                e.Effect = DragDropEffects.None;
            }
            else
                e.Effect = DragDropEffects.None;
        }
    }
}
