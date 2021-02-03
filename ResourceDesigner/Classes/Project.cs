using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceDesigner.Classes
{
    class Project
    {
        public string Name { get; set; }
        public CharSet[] Sprites { get; set; }
        public CharSet[] Tiles { get; set; }
        public Screen[] Screens { get; set; }
    }
}
