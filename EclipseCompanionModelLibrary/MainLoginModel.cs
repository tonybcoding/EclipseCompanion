using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EclipseCompanionModelLibrary
{
    public class MainLoginModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool LoggedIn { get; set; }
        public AccessLevels AccessLevel { get; set; }

        public MainLoginModel()
        {
            this.LoggedIn = false;
        }
    }
}
