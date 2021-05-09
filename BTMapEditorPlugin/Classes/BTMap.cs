using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTMapEditorPlugin.Classes
{
    public class BTMap
    {
        public Guid Id { get; set; }
        [JsonConverter(typeof(BitmapConverter))]
        public Bitmap Image { get; set; }
        public BTMapElement[] Elements { get; set; }
    }

    public class BTMapElement
    {
        public Guid CharSetId { get; set; }
        public int CharX { get; set; }
        public int CharY { get; set; }
        public int Scale { get; set; }
    }
}
