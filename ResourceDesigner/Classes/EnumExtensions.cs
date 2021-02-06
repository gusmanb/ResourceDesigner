using ResourceDesigner.Enums;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceDesigner.Classes
{
    public static class EnumExtensions
    {
        public static Color ToColor(this ColorComponent Value, ColorComponent Component)
        {
            ColorComponent finalValue;

            switch (Component)
            {
                case ColorComponent.Ink:

                    finalValue = Value;
                    break;

                case ColorComponent.Paper:

                    finalValue = (ColorComponent)((byte)(Value & ColorComponent.Paper) >> 3) | (Value & ColorComponent.Bright);
                    break;

                default:

                    return Color.Transparent;
            }

            switch (finalValue & ColorComponent.Ink)
            {
                case ColorComponent.InkBlack:

                    return Color.Black;

                case ColorComponent.InkBlue:

                    return Value.HasFlag(ColorComponent.Bright) ? Color.FromArgb(0, 0, 255) : Color.FromArgb(0, 0, 192);

                case ColorComponent.InkRed:

                    return Value.HasFlag(ColorComponent.Bright) ? Color.FromArgb(255, 0, 0) : Color.FromArgb(192, 0, 0);

                case ColorComponent.InkFuchsia:

                    return Value.HasFlag(ColorComponent.Bright) ? Color.FromArgb(255, 0, 255) : Color.FromArgb(192, 0, 192);

                case ColorComponent.InkGreen:

                    return Value.HasFlag(ColorComponent.Bright) ? Color.FromArgb(0, 255, 0) : Color.FromArgb(0, 192, 0);

                case ColorComponent.InkCyan:

                    return Value.HasFlag(ColorComponent.Bright) ? Color.FromArgb(0, 255, 255) : Color.FromArgb(0, 192, 192);

                case ColorComponent.InkYellow:

                    return Value.HasFlag(ColorComponent.Bright) ? Color.FromArgb(255, 255, 0) : Color.FromArgb(192, 192, 0);

                case ColorComponent.InkWhite:

                    return Value.HasFlag(ColorComponent.Bright) ? Color.FromArgb(255, 255, 255) : Color.FromArgb(192, 192, 192);
            }

            return Color.Transparent;
        }
    }
}
