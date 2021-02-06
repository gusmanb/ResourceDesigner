using ResourceDesigner.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceDesigner.Classes
{
    public class CharSet
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public byte[][] Data { get; set; }
        public ColorComponent[] ColorData { get; set; }
        public CharSetSort Sort { get; set; }
        public CharSetType SetType { get; set; }

        public CharSet Clone()
        {
            var set = new CharSet
            {
                Id = this.Id,
                Name = this.Name,
                Height = this.Height,
                Width = this.Width,
                SetType = this.SetType,
                Sort = this.Sort
            };

            byte[][] newData = new byte[Data.Length][];

            for (int buc = 0; buc < newData.Length; buc++)
                newData[buc] = (byte[])Data[buc].Clone();

            set.Data = newData;

            set.ColorData = ColorData == null ? Enumerable.Range(0, Data.Length).Select(n => ColorComponent.InkBlack | ColorComponent.PaperWhite).ToArray() : (ColorComponent[])ColorData?.Clone();

            return set;
        }

        public Bitmap GenerateImage()
        {
            Bitmap unscaledBitmap = new Bitmap(Width * 8, Height * 8, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            Graphics g = Graphics.FromImage(unscaledBitmap);
            g.Clear(Color.Blue);
            g.Dispose();

            for (int index = 0; index < Data.Length; index++)
            {
                byte[] data = Data[index];
                Point charOffset = GetCharCoordinates(index);

                var ink = ColorData[index].ToColor(ColorComponent.Ink);
                var paper = ColorData[index].ToColor(ColorComponent.Paper);

                for (int y = 0; y < 8; y++)
                {
                    for (int x = 0; x < 8; x++)
                    {
                        if ((data[y] & (128 >> x)) != 0)
                            unscaledBitmap.SetPixel(x + charOffset.X, y + charOffset.Y, ink);
                        else
                            unscaledBitmap.SetPixel(x + charOffset.X, y + charOffset.Y, paper);
                    }
                }
            }

            return unscaledBitmap;
        }

        public Point GetCharCoordinates(int Index)
        {
            if (Sort == Enums.CharSetSort.UpDown)
            {
                int y = Index % Height;
                int x = (Index - y) / Height;
                return new Point(x * 8, y * 8);
            }
            else
            {
                int x = Index % Width;
                int y = (Index - x) / Width;
                return new Point(x * 8, y * 8);
            }
        }
    }
}
