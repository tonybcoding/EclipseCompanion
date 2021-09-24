using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EclipseCompanionModelLibrary
{
    public class ProjectTaskModel
    {
        public int Id { get; set; }
        public bool IsThisATask { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
