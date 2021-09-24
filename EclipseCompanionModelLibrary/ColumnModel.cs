using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EclipseCompanionModelLibrary
{
    public class ColumnModel
    {
        public string FieldName { get; set; }
        public ColType FieldType { get; set; }
        public string DisplayName { get; set; }
        public int DisplayColumn { get; set; }
        public int ColumnWidth { get; set; }
        public bool ToDisplay { get; set; }
        public bool ReferenceOnly { get; set; } = false;      // used when exporting to Excel to indicate shading
    }
}
