using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EclipseCompanionModelLibrary
{
     /// <summary>
     /// Represents one project record retrieved directly from Eclipse using several API
     /// calls. Once a list of these objects are fully populated, they will immediately
     /// be saved to SQL using a data model and associated method calls
     /// </summary>
    public class ProjectModel
    {
        // get this data from our initial api call
        // subsequent calls to get additional information
        public int EclipseId { get; set; }                 // Eclipse ID
        public string Name { get; set; }                   // Project name
        public string Description { get; set; }
        public string FullStatusNotes { get; set; }        // full status notes
        public string ShortStatusNotes { get; set; }       // truncated version of full status notes
        public int ?ProjectOwnerId { get; set; }        
        public int PriorityId { get; set; }
        public int StatusId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal PercentComplete { get; set; }        // percentage complete in decimail

        // used in certain methods
        public int SqlId { get; set; }

        // from API query to resources/{ProjectOwnerID}
        public string ProjectOwner { get; set; }

        // from API query to configuration/project/priorities/{PriorityID}
        public string Priority { get; set; }
        public int PrioritySortOrder { get; set; }

        // two api calls required
        // first: /configuration/project/statuses/{StatusID} (typeID, sortOrder)
        // second: /configuration/project/statustypes/{TypeID} (name)
        public int StatusTypeId { get; set; }
        public string StatusType { get; set; }
        public int StatusSortOrder { get; set; }

        // from API query to projects/{id}/statusupdates/current
        public string Status { get; set; }              // text version of status
        public DateTime LastStatusDate { get; set; }    // last status update
        public List<Indicator> ListOfStatusIndicators { get; set; }

        public class Indicator
        {
            public string Name { get; set; }            // e.g., Complexity
            public int StateId { get; set; }            // 1001
            public string StateName { get; set; }       // Green
        }
    }
}
