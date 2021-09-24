using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EclipseCompanionModelLibrary
{
    // this will only be instantiated once at the global level
    // to contain the eclipse login credentials of the current user
    public class EclipseLoginModel
    {
        // first two properties are the only two API returned name/value pairs
        public int ID { get; set; }             // organization ID, not user ID
        public string Name { get; set; }        // organization name

        // these values will be set outside of the API returned information
        public string UserEmail { get; set; }   // will be used to capture user email, so that we can look up user record based on email address
        public int UserID { get; set; }
        public bool LoggedIn { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public int UserPolicyID { get; set; }

        public EclipseLoginModel()
        {
            this.LoggedIn = false;
        }

    }
}
