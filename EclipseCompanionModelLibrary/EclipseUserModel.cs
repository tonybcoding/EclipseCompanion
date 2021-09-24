using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EclipseCompanionModelLibrary
{
    // this class exists so that we may populate a list of Eclipse
    // users to find the current user logging in to Eclipse, which is the 
    // only place this class is instantiated
    public class EclipseUserModel
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string LastLogin { get; set; }
    }
}
