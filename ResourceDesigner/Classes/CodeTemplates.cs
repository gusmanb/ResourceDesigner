using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceDesigner.Classes
{
    public static class CodeTemplates
    {
        public const string CharSetSingleDimTemplate =
@"Dim {0}({1}) as ubyte => {{ {2} }}";
        public const string CharSetMultiDimTemplate =
@"Dim {0}({1},{2}) as uByte => {{ _
{3}
}}
";
        public const string MultiDimRowTemplate =
@"    {{ {0} }}, _
";
        public const string MultiDimLastRowTemplate =
@"    {{ {0} }} _";
    }
}
