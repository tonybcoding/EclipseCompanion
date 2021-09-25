using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EclipseCompanionModelLibrary
{
    public class UserModel : MainLoginModel
    {
        public string EmailAddress { get; set; }
        public DateTime ?LastLogin { get; set; }
        public bool ForcePasswordChange { get; set; }
        public bool IsActive { get; set; }
        public bool IsLocked { get; set; }
    }
}
