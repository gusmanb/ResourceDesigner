using ResourceDesigner.Classes;
using ResourceDesigner.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResourceDesigner.Controls
{
    public partial class CharSetList : UserControl
    {
        public const int ItemSize = 64;

        List<ListedCharSet> charSets = new List<ListedCharSet>();
        public event EventHandler<CharSetMenuEventArgs> CharSetMenuRequested;
        public event EventHandler<CharSetEventArgs> CharSetSelected;
        public CharSet[] CharSets 
        { 
            get 
            {
                return charSets.Select(cs => cs.Set).ToArray();
            }

            set
            {
                foreach (var set in charSets)
                {
                    viewPanel.Controls.Remove(set.ImageView);
                    set.ImageView.DoubleClick -= ImageView_DoubleClick;
                    set.ImageView.Dispose();
                    set.Image.Dispose();
                }

                charSets.Clear();

                if (value == null)
                    return;

                foreach (var set in value)
                    AddOrUpdateCharSet(set);
            }
        }
        public string Title 
        {
            get { return lblTitle.Text; }
            set { lblTitle.Text = value; }
        }
        private ToolTip helperTip = new ToolTip();
        public CharSetList()
        {
            InitializeComponent();
        }
        public void AddOrUpdateCharSet(CharSet Set)
        {
            var existingSet = charSets.Where(cs => cs.Set.Id == Set.Id).FirstOrDefault();
            if (existingSet != null)
            {
                existingSet.Set = Set.Clone();
                GenerateImage(existingSet);
                helperTip.SetToolTip(existingSet.ImageView, $"{existingSet.Set.SetType} {existingSet.Set.Name}\r\nSort order {existingSet.Set.Sort}\r\nRight click for more options");
            }
            else 
            {
                var newSet = new ListedCharSet 
                {
                    Set = Set.Clone(),
                    ImageView = new PixelPerfectPictureBox()
                };

                newSet.ImageView.Size = new Size(ItemSize, ItemSize);
                newSet.ImageView.DoubleClick += ImageView_DoubleClick;
                newSet.ImageView.MouseClick += ImageView_MouseClick;
                newSet.ImageView.MouseMove += ImageView_MouseMove;

                GenerateImage(newSet);
                charSets.Add(newSet);
                viewPanel.Controls.Add(newSet.ImageView);
                helperTip.SetToolTip(newSet.ImageView, $"{newSet.Set.SetType} {newSet.Set.Name}\r\nSort order {newSet.Set.Sort}\r\nRight click for more options");
            }
        }

        private void ImageView_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var charSet = charSets.Where(c => c.ImageView == (PixelPerfectPictureBox)sender).FirstOrDefault();
                DataObject obj = new DataObject("CHARSET_1", charSet.Set);
                DoDragDrop(obj, DragDropEffects.Copy);
            }
        }

        private void ImageView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var item = sender as PixelPerfectPictureBox;
                var charSet = charSets.Where(c => c.ImageView == item).FirstOrDefault();
                CharSetMenuRequested(this, new CharSetMenuEventArgs { CharSet = charSet.Set, Position = e.Location, Source = sender as Control });
            }
        }

        public void RemoveCharSet(CharSet Set)
        {
            var existingSet = charSets.Where(cs => cs.Set.Id == Set.Id).FirstOrDefault();
            if (existingSet != null)
            {
                viewPanel.Controls.Remove(existingSet.ImageView);
                existingSet.ImageView.DoubleClick -= ImageView_DoubleClick;
                existingSet.ImageView.MouseClick -= ImageView_MouseClick;
                existingSet.ImageView.MouseMove -= ImageView_MouseMove;
                existingSet.ImageView.Dispose();
                existingSet.Image.Dispose();
                charSets.Remove(existingSet);
            }
        }
        private void ImageView_DoubleClick(object sender, EventArgs e)
        {
            var item = sender as PixelPerfectPictureBox;
            var charSet = charSets.Where(c => c.ImageView == item).FirstOrDefault();
            CharSetSelected(this, new CharSetEventArgs { CharSet = charSet.Set });
        }
        private void GenerateImage(ListedCharSet Set)
        {
            /*
            Bitmap unscaledBitmap = new Bitmap(Set.Set.Width * 8, Set.Set.Height * 8, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            
            Graphics g = Graphics.FromImage(unscaledBitmap);
            g.Clear(Color.Blue);
            g.Dispose();

            for (int index = 0; index < Set.Set.Data.Length; index++)
            {
                byte[] data = Set.Set.Data[index];
                Point charOffset = GetCharCoordinates(index, Set.Set);

                for (int y = 0; y < 8; y++)
                {
                    for (int x = 0; x < 8; x++)
                    {
                        if ((data[y] & (128 >> x)) != 0)
                            unscaledBitmap.SetPixel(x + charOffset.X, y + charOffset.Y, Color.Black);
                        else
                            unscaledBitmap.SetPixel(x + charOffset.X, y + charOffset.Y, Color.White);
                    }
                }
            }
            */

            if (Set.Image != null)
                Set.Image.Dispose();

            Set.Image = Set.Set.GenerateImage();
            Set.ImageView.Image = Set.Image;
            Set.ImageView.SizeMode = PictureBoxSizeMode.Zoom;
            Set.ImageView.BackColor = Color.White;
        }
        /*
        private Point GetCharCoordinates(int Index, CharSet Set)
        {
            if (Set.Sort == Enums.CharSetSort.UpDown)
            {
                int y = Index % Set.Height;
                int x = (Index - y) / Set.Height;
                return new Point(x * 8, y * 8);
            }
            else
            {
                int x = Index % Set.Width;
                int y = (Index - x) / Set.Width;
                return new Point(x * 8, y * 8);
            }
        }*/
    }

    public class CharSetMenuEventArgs : CharSetEventArgs
    {
        public Control Source { get; set; }
        public Point Position { get; set; }
    }

    class ListedCharSet
    { 
        public CharSet Set { get; set; }
        public Bitmap Image { get; set; }
        public PixelPerfectPictureBox ImageView { get; set; }
    }
}
