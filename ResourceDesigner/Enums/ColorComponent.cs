using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceDesigner.Enums
{
    public enum ColorComponent : byte
    {
        None = 0,
        Ink = 7,
        Paper = 56,
        Bright = 64,
        Flash = 128,
        InkBlack = 0,
        InkBlue = 1,
        InkRed = 2,
        InkFuchsia = 3,
        InkGreen = 4,
        InkCyan = 5,
        InkYellow = 6,
        InkWhite = 7,
        PaperBlack = 0,
        PaperBlue = 1 << 3,
        PaperRed = 2 << 3,
        PaperFuchsia = 2 << 3,
        PaperGreen = 4 << 3,
        PaperCyan = 5 << 3,
        PaperYellow = 6 << 3,
        PaperWhite = 7 << 3
    }
}
