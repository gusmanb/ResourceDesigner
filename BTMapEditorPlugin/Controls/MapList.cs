using BTMapEditorPlugin.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTMapEditorPlugin
{
    public partial class MapList : UserControl
    {
        public const int ItemSize = 64;

        List<ListedMap> maps = new List<ListedMap>();
        ListedMap currentMap;

        public event EventHandler<MapSelectedEventArgs> MapSelected;

        public MapList()
        {
            InitializeComponent();
        }

        public BTMap AddMap(Bitmap Image, IEnumerable<MapElement> Elements)
        {
            BTMap newMap = new BTMap
            {
                Id = Guid.NewGuid(),
                Image = Image,
                Elements = Elements.Select(e => new BTMapElement
                {
                    CharSetId = e.Set.Id,
                    CharX = e.CellX,
                    CharY = e.CellY,
                    Scale = e.SetScale

                }).ToArray()
                
            };

            PixelPerfectPictureBox pb = new PixelPerfectPictureBox();
            pb.Size = new Size(ItemSize, ItemSize);
            pb.Image = Image;
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.Click += Pb_Click;

            ListedMap newListedMap = new ListedMap
            {
                Map = newMap,
                Aspect = pb
            };

            maps.Add(newListedMap);
            currentMap = newListedMap;

            pb.BorderStyle = BorderStyle.FixedSingle;

            viewPanel.Controls.Add(pb);

            return newMap;
        }
        public void UpdateMap(Bitmap Image, IEnumerable<MapElement> Elements)
        {
            if (currentMap == null)
                return;

            currentMap.Map.Image = Image;
            currentMap.Map.Elements = Elements.Select(e => new BTMapElement
            {
                CharSetId = e.Set.Id,
                CharX = e.CellX,
                CharY = e.CellY,
                Scale = e.SetScale

            }).ToArray();
            currentMap.Aspect.Image = Image;
        }
        public void DeleteMap()
        {
            maps.Remove(currentMap);
            viewPanel.Controls.Remove(currentMap.Aspect);
            currentMap.Aspect.Dispose();
            currentMap = null;
        }
        private void Pb_Click(object sender, EventArgs e)
        {
            if (currentMap != null)
                currentMap.Aspect.BorderStyle = BorderStyle.None;

            currentMap = maps.Where(m => m.Aspect == (sender as PixelPerfectPictureBox)).FirstOrDefault();

            if (currentMap != null)
                currentMap.Aspect.BorderStyle = BorderStyle.FixedSingle;

            if (MapSelected != null)
                MapSelected(this, new MapSelectedEventArgs { SelectedMap = currentMap.Map });
        }
        private class ListedMap
        {
            public BTMap Map { get; set; }
            public PixelPerfectPictureBox Aspect { get; set; }
        }
    }

    public class MapSelectedEventArgs : EventArgs
    {
        public BTMap SelectedMap { get; set; }
    }
}
