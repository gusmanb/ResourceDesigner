using BTMapEditorPlugin.Classes;
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
        MapElement elementSelected;
        BTMap activeMap;

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

        public IEnumerable<BTMap> Maps 
        {
            get 
            { 
                return mapList.Maps; 
            } 
            set 
            { 
                mapList.Maps = value;
                SelectElement(null);
                MapList_MapSelected(null, new MapSelectedEventArgs { SelectedMap = null });
            } 
        }

        public MainForm()
        {
            InitializeComponent();
            SizeWindow();
        }

        public MainForm(MainPlugin Plugin)
        {
            InitializeComponent();
            PluginInstance = Plugin;
            gridSet = Plugin.PluginRequestCharSet(null, "Grid", CharSetType.TileObject).FirstOrDefault()?.Clone();
            mapList.MapSelected += MapList_MapSelected;

            btnDelete.Click += BtnDelete_Click;
            btnUp.Click += BtnUp_Click;
            btnDown.Click += BtnDown_Click;
            btnSizeUp.Click += BtnSizeUp_Click;
            btnSizeDown.Click += BtnSizeDown_Click;

            btnNewMap.Click += BtnNewMap_Click;
            btnSaveMap.Click += BtnSaveMap_Click;
            btnDuplicateMap.Click += BtnDuplicateMap_Click;
            btnDeleteMap.Click += BtnDeleteMap_Click;

            CreateTexture();
            SizeWindow();
            UpdateToolbarAndDropStatus();
        }

        private void BtnDeleteMap_Click(object sender, EventArgs e)
        {
            if (activeMap != null)
            {
                mapList.DeleteMap();
                foreach (var elem in elements)
                {
                    this.Controls.Remove(elem);
                    elem.Dispose();
                }
                elements.Clear();
                activeMap = null;
                SelectElement(null);
            }
        }

        private void BtnDuplicateMap_Click(object sender, EventArgs e)
        {
            if (activeMap != null)
            {
                SelectElement(null);
                activeMap = mapList.AddMap(CaptureMapAspect(), elements);
            }
        }

        private void BtnSaveMap_Click(object sender, EventArgs e)
        {
            if (activeMap != null)
            {
                SelectElement(null);
                mapList.UpdateMap(CaptureMapAspect(), elements);
            }
        }

        private void BtnNewMap_Click(object sender, EventArgs e)
        {
            if (activeMap != null)
            {
                foreach (var elem in elements)
                {
                    this.Controls.Remove(elem);
                    elem.Dispose();
                }
                elements.Clear();
                activeMap = null;
                this.Refresh();
            }

            var aspect = CaptureMapAspect();
            activeMap = mapList.AddMap(aspect, elements);
            UpdateToolbarAndDropStatus();
        }

        Bitmap CaptureMapAspect()
        {
            using (Bitmap bmp = new Bitmap(this.Width, this.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb))
            {
                ReverseControlZIndex();
                //this.Refresh();
                DrawToBitmap(bmp, new Rectangle(0, 0, this.Width, this.Height));
                ReverseControlZIndex();
                //this.Refresh();

                var location = PointToScreen(Point.Empty);
                var onScreenLocation = Point.Add(this.Location, new Size(this.MdiParent.Location));

                var offset = Point.Subtract(location, new Size(onScreenLocation));

                var finalLocation = Point.Add(bgImage.Location, new Size(offset));

                finalLocation.X = (finalLocation.X - 2) / 2;
                finalLocation.Y = (finalLocation.Y - 2) / 2;

                var sourceRectangle = new Rectangle(finalLocation, bgImage.Size);

                Bitmap cropped = new Bitmap(bgImage.Width, bgImage.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                Graphics g = Graphics.FromImage(cropped);
                g.DrawImage(bmp, new Rectangle(Point.Empty, cropped.Size), sourceRectangle, GraphicsUnit.Pixel);
                g.Dispose();
                return cropped;
            }

        }

        private void ReverseControlZIndex()
        {
            var list = new List<Control>();
            foreach (Control i in Controls)
            {
                list.Add(i);
            }
            var total = list.Count;
            for (int i = 0; i < total / 2; i++)
            {
                var left = Controls.GetChildIndex(list[i]);
                var right = Controls.GetChildIndex(list[total - 1 - i]);

                Controls.SetChildIndex(list[i], right);
                Controls.SetChildIndex(list[total - 1 - i], left);
            }
        }

        private void MapList_MapSelected(object sender, MapSelectedEventArgs e)
        {
            activeMap = e.SelectedMap;
            SelectElement(null);

            foreach (var elem in elements)
            {
                this.Controls.Remove(elem);
                elem.Dispose();
            }

            elements.Clear();

            if (activeMap == null)
                return;

            foreach (var elem in activeMap.Elements)
            {
                var set = PluginInstance.PluginRequestCharSet(elem.CharSetId, null, null).FirstOrDefault();

                if (set == null)
                    continue;

                var newLemen = new MapElement();
                newLemen.PixelScale = pixelScale;
                newLemen.Set = set.Clone();
                newLemen.CellX = elem.CharX;
                newLemen.CellY = elem.CharY;
                newLemen.SetScale = elem.Scale;
                newLemen.Click += ElementOnDrag_Click;
                newLemen.Drag += ElementOnDrag_Drag;
                this.Controls.Add(newLemen);
                newLemen.BringToFront();
                PlaceElement(newLemen);
                elements.Add(newLemen);
            }
        }

        private void BtnSizeDown_Click(object sender, EventArgs e)
        {
            elementSelected.SetScale = elementSelected.SetScale - 1;
        }

        private void BtnSizeUp_Click(object sender, EventArgs e)
        {
            elementSelected.SetScale = elementSelected.SetScale + 1;
        }

        private void BtnDown_Click(object sender, EventArgs e)
        {
            elementSelected.SendToBack();
            bgImage.SendToBack();
            elements.Remove(elementSelected);
            elements.Insert(0, elementSelected);
        }

        private void BtnUp_Click(object sender, EventArgs e)
        {
            elementSelected.BringToFront();
            elements.Remove(elementSelected);
            elements.Add(elementSelected);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            elements.Remove(elementSelected);
            Controls.Remove(elementSelected);

            SelectElement(null);
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
            ClientSize = new Size(20 * 8 * pixelScale + MapList.ItemSize + 20, 20 * 8 * pixelScale + bgToolbar.Height);
            mapList.Width = MapList.ItemSize + 20;
            mapList.Height = ClientSize.Height - bgToolbar.Height;
            mapList.Location = new Point(ClientSize.Width - mapList.Width, bgToolbar.Height);
            bgImage.Location = new Point(0, bgToolbar.Height);
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
                var coords = bgImage.PointToClient(new Point(e.X, e.Y));
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

            if (cellX < 0)
                cellX = 0;

            if (cellY < 0)
                cellY = 0;

            if (cellX + elementOnDrag.Set.Width > 20)
                cellX = 20 - elementOnDrag.Width;

            if (cellY + elementOnDrag.Set.Height > 20)
                cellY = 20 - elementOnDrag.Height;

            elementOnDrag.Left = cellX * 8 * pixelScale;
            elementOnDrag.Top = cellY * 8 * pixelScale + bgToolbar.Height;

            elementOnDrag.CellX = cellX;
            elementOnDrag.CellY = cellY;
        }

        private void PlaceElement(MapElement NewElement)
        {
            NewElement.Left = NewElement.CellX * 8 * pixelScale;
            NewElement.Top = NewElement.CellY * 8 * pixelScale + bgToolbar.Height;
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
                var coords = bgImage.PointToClient(new Point(e.X, e.Y));
                PlaceElement(elementOnDrag, coords.X, coords.Y);
                e.Effect = DragDropEffects.Copy;
            }
            else
                e.Effect = DragDropEffects.None;
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            if (elementOnDrag != null)
            {
                var coords = bgImage.PointToClient(new Point(e.X, e.Y));
                PlaceElement(elementOnDrag, coords.X, coords.Y);
                elements.Add(elementOnDrag);
                elementOnDrag.OverColor = Color.Transparent;
                elementOnDrag.Click += ElementOnDrag_Click;
                elementOnDrag.Drag += ElementOnDrag_Drag;
                elementOnDrag = null;
                e.Effect = DragDropEffects.None;
            }
            else
                e.Effect = DragDropEffects.None;
        }

        private void ElementOnDrag_Drag(object sender, EventArgs e)
        {
            var element = SelectElement(sender);
                        
            var coords = bgImage.PointToClient(Cursor.Position);
            PlaceElement(element, coords.X, coords.Y);
        }

        private void ElementOnDrag_Click(object sender, EventArgs e)
        {
            SelectElement(sender);
        }

        private void bgImage_Click(object sender, EventArgs e)
        {
            SelectElement(null);
        }

        MapElement SelectElement(object Element)
        {
            if (elementSelected != null)
            {
                elementSelected.OverColor = Color.Transparent;
                elementSelected = null;
            }

            if (Element != null)
            {
                elementSelected = Element as MapElement;
                elementSelected.OverColor = Color.FromArgb(128, Color.LightBlue);
            }

            UpdateToolbarAndDropStatus();

            return elementSelected;
        }

        void UpdateToolbarAndDropStatus()
        {
            if (elementSelected == null)
            {
                btnDelete.Enabled = false;
                btnDown.Enabled = false; 
                btnUp.Enabled = false;
                btnSizeDown.Enabled = false;
                btnSizeUp.Enabled = false;
            }
            else
            {
                btnDelete.Enabled = true;
                btnDown.Enabled = true;
                btnUp.Enabled = true;

                if (elementSelected.Set.Width < 3 && elementSelected.Set.Height < 3)
                {
                    btnSizeDown.Enabled = false;
                    btnSizeUp.Enabled = false;
                }
                else
                {
                    btnSizeDown.Enabled = true;
                    btnSizeUp.Enabled = true;
                }
            }

            if (activeMap == null)
            {
                btnDuplicateMap.Enabled = false;
                btnDeleteMap.Enabled = false;
                btnSaveMap.Enabled = false;
                this.AllowDrop = false;
            }
            else
            {
                btnDuplicateMap.Enabled = true;
                btnDeleteMap.Enabled = true;
                btnSaveMap.Enabled = true;
                this.AllowDrop = true;
            }
        }
    }
}
