﻿using BTMapEditorPlugin.Classes;
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

        public IEnumerable<BTMap> Maps 
        {
            get { return maps.Select(m => m.Map).ToArray(); }
            set 
            {
                viewPanel.Controls.Clear();

                foreach (var map in maps)
                {
                    map.Aspect.Dispose();
                    map.Map.Image.Dispose();
                }

                maps.Clear();

                if (MapSelected != null)
                    MapSelected(this, new MapSelectedEventArgs { SelectedMap = null });

                if (value != null)
                {
                    foreach (var map in value)
                        CreateMap(map, false);
                }
                
            }
        }

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

            CreateMap(newMap, true);

            return newMap;
        }

        private void CreateMap(BTMap newMap, bool Select)
        {

            PictureBox pb = new PictureBox();
            pb.Size = new Size(ItemSize, ItemSize);
            pb.Image = newMap.Image;
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.BorderStyle = BorderStyle.None;
            pb.Click += Pb_Click;

            ListedMap newListedMap = new ListedMap
            {
                Map = newMap,
                Aspect = pb
            };

            maps.Add(newListedMap);

            if (currentMap != null)
                currentMap.Aspect.BorderStyle = BorderStyle.None;

            if (Select)
            {
                currentMap = newListedMap;
                pb.BorderStyle = BorderStyle.FixedSingle;
            }

            viewPanel.Controls.Add(pb);
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

            currentMap = maps.Where(m => m.Aspect == (sender as PictureBox)).FirstOrDefault();

            if (currentMap != null)
                currentMap.Aspect.BorderStyle = BorderStyle.FixedSingle;

            if (MapSelected != null)
                MapSelected(this, new MapSelectedEventArgs { SelectedMap = currentMap.Map });
        }
        private class ListedMap
        {
            public BTMap Map { get; set; }
            public PictureBox Aspect { get; set; }
        }
    }

    public class MapSelectedEventArgs : EventArgs
    {
        public BTMap SelectedMap { get; set; }
    }
}
