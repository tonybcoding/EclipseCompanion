using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EclipseCompanionModelLibrary
{
    public enum LoginTo
    {
        Main,
        Eclipse
    }

    public enum Filter
    {
        All,
        Active,
        Suspended,
        ClosedAndArchived,
        Single,
        Search
    }

    public enum ColType
    {
        Int32,
        String,
        DateTime,
        Decimal
    }

    public enum SqlAction
    {
        Add,
        Update
    }

    public enum AccessLevels
    {
        Debug = 1,
        Admin = 2,
        ISTMember = 3,
        Manager = 4,
        General = 5
    }
}
