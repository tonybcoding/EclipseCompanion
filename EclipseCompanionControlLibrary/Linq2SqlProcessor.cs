using EclipseCompanionModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EclipseCompanionControlLibrary
{
    public class Linq2SqlProcessor
    {
        public static List<string>GetIndicatorValues()
        {
            try
            {
                SQLDataClassesDataContext dbContext = new SQLDataClassesDataContext(GlobalCode.ConnectionString);
                GeneralConfiguration config = dbContext.GeneralConfigurations.First();
                List<string> indicators = new List<string>();
                indicators.AddRange(new List<string>
                {
                    config.EclipseGreen,
                    config.EclipseYellow,
                    config.EclipseRed,
                    config.ComplexityGreen,
                    config.ComplexityYellow,
                    config.ComplexityRed,
                    config.ScheduleGreen,
                    config.ScheduleYellow,
                    config.ScheduleRed,
                    config.OverallGreen,
                    config.OverallYellow,
                    config.OverallRed
                });
                return indicators;
            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
                return null;
            }
        }

        public static void UpdateIndicatorValues(List<string> indicators)
        {
            try
            {
                SQLDataClassesDataContext dbContext = new SQLDataClassesDataContext(GlobalCode.ConnectionString);
                GeneralConfiguration config = dbContext.GeneralConfigurations.First();
                config.EclipseGreen = indicators[0];
                config.EclipseYellow = indicators[1];
                config.EclipseRed = indicators[2];
                config.ComplexityGreen = indicators[3];
                config.ComplexityYellow = indicators[4];
                config.ComplexityRed = indicators[5];
                config.ScheduleGreen = indicators[6];
                config.ScheduleYellow = indicators[7];
                config.ScheduleRed = indicators[8];
                config.OverallGreen = indicators[9];
                config.OverallYellow = indicators[10];
                config.OverallRed = indicators[11];
                dbContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }
        }

        public static string GetTruncateString()
        {
            try
            {
                SQLDataClassesDataContext dbContext = new SQLDataClassesDataContext(GlobalCode.ConnectionString);
                GeneralConfiguration config = dbContext.GeneralConfigurations.First();
                return config.TruncateString;
            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
                return null;
            }
        }

        public static void UpdateTruncateString(string newTruncateString)
        {
            try
            {
                SQLDataClassesDataContext dbContext = new SQLDataClassesDataContext(GlobalCode.ConnectionString);
                GeneralConfiguration config = dbContext.GeneralConfigurations.First();
                config.TruncateString = newTruncateString;
                dbContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }
        }

        public static bool GetRefreshStatus()
        {
            try
            {
                SQLDataClassesDataContext dbContext = new SQLDataClassesDataContext(GlobalCode.ConnectionString);
                GeneralConfiguration config = dbContext.GeneralConfigurations.First();
                return (bool)config.UpdatingAPI;
            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
                return true;
            }
        }
        
        public static void ChangeRefreshStatus(bool toThis)
        {
            try
            {
                SQLDataClassesDataContext dbContext = new SQLDataClassesDataContext(GlobalCode.ConnectionString);
                GeneralConfiguration config = dbContext.GeneralConfigurations.First();
                config.UpdatingAPI = toThis;
                dbContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }
        }

        public static string GetRefreshLastUpdateBy()
        {
            try
            {
                SQLDataClassesDataContext dbContext = new SQLDataClassesDataContext(GlobalCode.ConnectionString);
                GeneralConfiguration config = dbContext.GeneralConfigurations.First();
                var user = dbContext.Users.Where(u => u.id == config.LastUpdatedByUserId).ToList();
                return $"{user[0].FirstName} {user[0].LastName}";
            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
                return null;
            }
        }
        
        public static DateTime GetRefreshLastUpdate()
        {
            try
            {
                SQLDataClassesDataContext dbContext = new SQLDataClassesDataContext(GlobalCode.ConnectionString);
                GeneralConfiguration config = dbContext.GeneralConfigurations.First();
                return config.LastAPIRefresh;
            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
                return Convert.ToDateTime("2001-01-01");
            }
        }

        public static void UpdateRefreshLastUpdate()
        {
            try
            {
                SQLDataClassesDataContext dbContext = new SQLDataClassesDataContext(GlobalCode.ConnectionString);
                GeneralConfiguration config = dbContext.GeneralConfigurations.First();
                config.LastAPIRefresh = DateTime.Now;
                config.LastUpdatedByUserId = GlobalCode.MainLogin.Id;
                dbContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }
        }

        public static string RetrievePassword(int id)
        {
            try
            {
                SQLDataClassesDataContext dbContext = new SQLDataClassesDataContext(GlobalCode.ConnectionString);
                User uSql = dbContext.Users.SingleOrDefault(u => u.id == id);
                return uSql.Password;
            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
                return null;
            }
        }
        
        public static void ChangePassword(int id, string password)
        {
            try
            {
                SQLDataClassesDataContext dbContext = new SQLDataClassesDataContext(GlobalCode.ConnectionString);
                User uSql = dbContext.Users.SingleOrDefault(u => u.id == id);
                uSql.Password = password;
                uSql.LastUpdated = DateTime.Now;
                dbContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }
        }

        public static void AddUpdateUser(UserModel user, SqlAction action, string password = "")
        {
            try
            {
                SQLDataClassesDataContext dbContext = new SQLDataClassesDataContext(GlobalCode.ConnectionString);
                User uSql = (action == SqlAction.Add) ? new User() : uSql = dbContext.Users.SingleOrDefault(u => u.id == user.Id);

                uSql.FirstName = user.FirstName;
                uSql.LastName = user.LastName;
                uSql.LoginId = user.UserLoginName;
                uSql.EmailAddress = user.EmailAddress;
                uSql.AccessLevel = (int)user.AccessLevel;
                uSql.Active = user.IsActive;
                uSql.Locked = user.IsLocked;
                uSql.ForcePasswordChange = user.ForcePasswordChange;
                uSql.LastUpdated = DateTime.Now;
                if(action == SqlAction.Add)
                {
                    uSql.CreateDate = DateTime.Now;
                    uSql.Password = password;
                    dbContext.Users.InsertOnSubmit(uSql);
                }
                dbContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }
        }
        
        public static List<UserModel> RetrieveUsers()
        {
            try
            {
                SQLDataClassesDataContext dbContext = new SQLDataClassesDataContext(GlobalCode.ConnectionString);
                List<UserModel> users = new List<UserModel>();

                // load all users from SQL
                var userList = dbContext.Users.OrderBy(u => u.LastName).ThenBy(u => u.FirstName).ToList();
                foreach(User user in userList)
                {
                    UserModel u = new UserModel();
                    u.Id = user.id;
                    u.FirstName = user.FirstName;
                    u.LastName = user.LastName;
                    u.UserLoginName = user.LoginId;
                    u.AccessLevel = (AccessLevels)user.AccessLevel;
                    u.IsActive = user.Active;
                    u.IsLocked = user.Locked;
                    u.EmailAddress = user.EmailAddress;
                    u.LastLogin = user.LastLogIn;
                    u.ForcePasswordChange = user.ForcePasswordChange;
                    users.Add(u);
                }

                return users;
            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
                return null;
            }
        }
        
        public static List<ProjectTaskModel> RetrieveProjectsTasks()
        {
            try
            {
                SQLDataClassesDataContext dbContext = new SQLDataClassesDataContext(GlobalCode.ConnectionString);
                List<ProjectTaskModel> ptList = new List<ProjectTaskModel>();

                // load all active tasks assigned to this user
                var sqlTasks = dbContext.Tasks.Where(t => t.UserCreatedId == GlobalCode.MainLogin.Id).OrderBy(t => t.TaskName).ToList(); ;
                foreach (EclipseCompanionModelLibrary.Task t in sqlTasks)
                {
                    ProjectTaskModel pt = new ProjectTaskModel();
                    pt.Id = t.id;
                    pt.Name = $"Task: {t.TaskName}";
                    pt.IsActive = t.IsActive;
                    pt.IsThisATask = true;
                    ptList.Add(pt);
                }

                // load all active category projects
                var sqlProjects = dbContext.Projects.Where(p => p.StatusCategoryId == GlobalCode.ActiveStatusCategory).OrderBy(p => p.Name).ToList();
                foreach (Project p in sqlProjects)
                {
                    ProjectTaskModel pt = new ProjectTaskModel();
                    pt.Id = p.id;
                    pt.Name = $"{p.EclipseId}-{p.Name}";
                    pt.IsActive = true;
                    pt.IsThisATask = false;
                    ptList.Add(pt);
                }

                return ptList;
            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
                return null;
            }        
        }

        public static void UpdateSqlTasksTable(string taskName, int userId)
        {
            try
            {
                SQLDataClassesDataContext dbContext = new SQLDataClassesDataContext(GlobalCode.ConnectionString);
                
                // add Task record
                EclipseCompanionModelLibrary.Task thisTask = new EclipseCompanionModelLibrary.Task();
                thisTask.IsActive = true;
                thisTask.TaskName = taskName;
                thisTask.UserCreatedId = userId;
                thisTask.CreateDate = DateTime.Now;
                thisTask.LastUpdated = DateTime.Now;
                dbContext.Tasks.InsertOnSubmit(thisTask);
                dbContext.SubmitChanges();
            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }
        }

        public static bool AddDefaultConfigIfNeeded()
        {
            try
            {
                SQLDataClassesDataContext dbContext = new SQLDataClassesDataContext(GlobalCode.ConnectionString);
                List<ProjectModel> projects = GetProjectsFromSql(Filter.All);

                // if config doesn't exist and there are no project records
                // indicate that we do not want to proceed by returning false
                if (!dbContext.ConfigurationFields.Any() && !projects.Any())
                {
                    return false;
                }
                // however, if config doesn't exist but we do have projects, then
                // populate config with default field settings
                else if (!dbContext.ConfigurationFields.Any())
                {
                    List<ColumnModel> columns = PopulateColumnModelList(ref projects);
                    AddFieldRecordsToSQL(columns, ref dbContext);
                    return true;
                }
                // if config already exists, return true
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
                return false;
            }

            ////////////////////////////////////////////////////////
            // local functions
            ////////////////////////////////////////////////////////
            List<ColumnModel> PopulateColumnModelList(ref List<ProjectModel> projectsList)
            {
                List<ColumnModel> cmList = new List<ColumnModel>();

                // get property types of fields using reflection and handling nullables and lists
                PropertyInfo[] properties = typeof(ProjectModel).GetProperties();
                int displayColumn = 0;
                int defaultColumnWidth = 140;
                foreach (PropertyInfo property in properties)
                {
                    string type = property.PropertyType.Name;
                    if (type.StartsWith("Nullable"))
                    {
                        type = GlobalCode.FindStringBetween($"{property.PropertyType}", "[System.", "]");
                    }

                    if (!type.StartsWith("List"))
                    {
                        ColumnModel column = new ColumnModel();
                        column.FieldName = property.Name;
                        column.FieldType = (ColType)Enum.Parse(typeof(ColType), type);
                        column.DisplayName = $"{property.Name}";
                        column.DisplayColumn = displayColumn++;
                        column.ToDisplay = true;
                        column.ColumnWidth = defaultColumnWidth;
                        cmList.Add(column);
                    }
                }

                // then traverse all projects to see all possible indicators for that column data
                // add add it to cmList
                foreach (ProjectModel p in projectsList)
                {
                    foreach (ProjectModel.Indicator i in p.ListOfStatusIndicators)
                    {
                        bool exists = false;
                        foreach (ColumnModel cm in cmList)
                        {
                            if (i.Name == cm.FieldName)
                            {
                                exists = true;
                                break;
                            }
                        }
                        if (!exists)
                        {
                            ColumnModel column = new ColumnModel();
                            column.FieldName = i.Name;
                            column.FieldType = ColType.String;
                            column.DisplayName = i.Name;
                            column.DisplayColumn = displayColumn++;
                            column.ToDisplay = true;
                            column.ColumnWidth = defaultColumnWidth;
                            cmList.Add(column);
                        }
                    }
                }
                return cmList;
            }
        }

        public static List<ColumnModel> GetColumnConfigs()
        {
            try
            {
                SQLDataClassesDataContext dbContext = new SQLDataClassesDataContext();
                List<ColumnModel> cols = new List<ColumnModel>();
                var rows = dbContext.ConfigurationFields.Select(row => row).OrderBy(row => row.displaycolumn);

                // add column information
                foreach (ConfigurationField r in rows)
                {
                    ColumnModel c = new ColumnModel();
                    c.FieldName = r.fieldname;
                    c.FieldType = (ColType)Enum.Parse(typeof(ColType), r.fieldtype, true);
                    c.DisplayName = r.displayname;
                    c.DisplayColumn = r.displaycolumn;
                    c.ColumnWidth = r.displaycolumnwidth;
                    c.ToDisplay = r.todisplay;
                    cols.Add(c);
                }

                return cols;
            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
                return null;
            }
        }
        
        /// <summary>
        /// This method is called either when there are no configuration field records or
        /// the user desires to save an updated configuration. Therefore, the call to
        /// truncate the table
        /// </summary>
        /// <param name="cols"></param>
        /// <param name="context"></param>
        public static void AddFieldRecordsToSQL(List<ColumnModel> cols, ref SQLDataClassesDataContext context)
        {
            try
            {
                // clear out old entries
                context.ExecuteCommand("delete ConfigurationFields");

                // add new records
                foreach (ColumnModel c in cols)
                {
                    // add field information
                    ConfigurationField f = new ConfigurationField();
                    f.fieldname = c.FieldName;
                    f.fieldtype = c.FieldType.ToString();
                    f.displayname = c.DisplayName;
                    f.displaycolumn = c.DisplayColumn;
                    f.displaycolumnwidth = c.ColumnWidth;
                    f.todisplay = c.ToDisplay;
                    context.ConfigurationFields.InsertOnSubmit(f);
                    context.SubmitChanges();

                }
            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }
        }

        public static List<ProjectModel> GetProjectsFromSql(Filter filter, int eclipseId = -1, string searchString = "")
        {
            try
            {
                SQLDataClassesDataContext dbContext = new SQLDataClassesDataContext();
                List<ProjectModel> projects = new List<ProjectModel>();
                GetFilteredProjects(ref projects, ref dbContext, filter, eclipseId, searchString);
                GetProjectIndicators(ref projects, ref dbContext);
                return projects;
            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
                return null;
            }

            //////////////////////////////////////////////////////////
            // local functions
            //////////////////////////////////////////////////////////
            void GetProjectIndicators(ref List<ProjectModel> projs, ref SQLDataClassesDataContext context)
            {
                try
                {
                    foreach (ProjectModel p in projs)
                    {
                        List<ProjectModel.Indicator> sqlIndicators = new List<ProjectModel.Indicator>();
                        var inds = context.ProjectIndicators.Where(i => i.ProjectEclipseId == p.EclipseId).OrderBy(i => i.StateId);
                        foreach (ProjectIndicator i in inds)
                        {
                            ProjectModel.Indicator pi = new ProjectModel.Indicator();
                            pi.Name = i.Name;
                            pi.StateId = i.StateId;
                            pi.StateName = i.StateName;
                            sqlIndicators.Add(pi);
                        }
                        p.ListOfStatusIndicators = sqlIndicators;
                    }
                }
                catch (Exception ex)
                {
                    GlobalCode.ExceptionHandler(ex);
                }
            }

            void GetFilteredProjects(ref List<ProjectModel> projs, ref SQLDataClassesDataContext context, Filter flt, int eId, string sString)
            {
                try
                {
                    List<Project> sqlProjects = new List<Project>();
                    switch(flt)
                    {
                        case Filter.Active:
                            sqlProjects = context.Projects.Where(p => p.StatusCategoryId == GlobalCode.ActiveStatusCategory || p.StatusCategoryId == GlobalCode.ActiveQueuedStatusCategory).OrderBy(p => p.StatusSortOder).ToList();
                            break;
                        case Filter.Suspended:
                            sqlProjects = context.Projects.Where(p => p.StatusCategoryId == GlobalCode.SuspendedStatusCategory).OrderBy(p => p.StatusSortOder).ToList();
                            break;
                        case Filter.ClosedAndArchived:
                            sqlProjects = context.Projects.Where(p => p.StatusCategoryId == GlobalCode.ArchivedStatusCategory || p.StatusCategoryId == GlobalCode.ClosedStatusCategory).OrderBy(p => p.StatusSortOder).ToList();
                            break;
                        case Filter.All:
                            sqlProjects = context.Projects.Select(row => row).OrderBy(p => p.StatusSortOder).ToList();
                            break;
                        case Filter.Single:
                            sqlProjects = context.Projects.Where(p => p.EclipseId == eId).ToList();
                            break;
                        case Filter.Search:
                            sString = sString.ToLower();
                            sqlProjects = context.Projects.Where(
                                p => Convert.ToString(p.EclipseId).ToLower().Contains(sString) ||
                                p.Name.ToLower().Contains(sString) ||
                                p.ProjectOwner.ToLower().Contains(sString) ||
                                p.Description.ToLower().Contains(sString)).ToList();
                            break;
                    }
                    foreach (Project p in sqlProjects)
                    {
                        ProjectModel ps = new ProjectModel();
                        ps.SqlId = p.id;
                        ps.EclipseId = p.EclipseId;
                        ps.Name = p.Name;
                        ps.Description = p.Description;
                        ps.FullStatusNotes = p.FullStatusNotes;
                        ps.ShortStatusNotes = p.ShortStatusNotes;
                        ps.ProjectOwner = p.ProjectOwner;
                        ps.Priority = p.Priority;
                        ps.StatusTypeId = p.StatusCategoryId;
                        ps.StatusType = p.StatusCategory;
                        ps.StartDate = p.StartDate;
                        ps.EndDate = p.EndDate;
                        ps.CreatedDate = p.DateCreated;
                        ps.ModifiedDate = p.DateLastModified;
                        ps.PercentComplete = p.PercentComplete;
                        ps.Status = p.Status;
                        ps.StatusSortOrder = p.StatusSortOder;
                        ps.LastStatusDate = p.LastStatusDate;
                        ps.PrioritySortOrder = p.PrioritySortOrder;
                        ps.StatusId = p.StatusId;
                        ps.PriorityId = p.PriorityId;
                        ps.ProjectOwnerId = p.ProjectOwnerId;
                        projs.Add(ps);
                    }
                }
                catch (Exception ex)
                {
                    GlobalCode.ExceptionHandler(ex);
                }
            }
        }

        /// <summary>
        /// This method updates, adds projects in Projects table and associate
        /// indicators in ProjectsIndicators table.
        /// This method must also ensure the ProjectsTasks table reflects the most recent
        /// active projects
        /// </summary>
        /// <param name="projectsList"></param>
        /// <param name="projectCount"></param>
        public static void UpdateSqlProjectTables(List<ProjectModel> projectsList, int projectCount)
        {
            try
            {
                SQLDataClassesDataContext dbContext = new SQLDataClassesDataContext(GlobalCode.ConnectionString);
                List<int> existingEclipseIds = GetListOfEclipseIds(ref dbContext);

                foreach (ProjectModel project in projectsList)
                {
                    // checking project record
                    if (existingEclipseIds.Contains(project.EclipseId))                 // does record exist?
                    {
                        if (HasProjectRecordChanged(project, ref dbContext))            // it does, but has it changed?
                        {
                            AddUpdateProjectRecord(project, ref dbContext, SqlAction.Update);
                        }
                    }
                    else
                    {
                        AddUpdateProjectRecord(project, ref dbContext, SqlAction.Add);  // record doesn't exist, so add it
                    }

                    // checking indicators associated with project
                    if (HaveIndicatorRecordsChanged(project, ref dbContext))
                    {
                        var indicators = dbContext.ProjectIndicators.Where(i => i.ProjectEclipseId == project.EclipseId);

                        if (indicators.Any())
                        {
                            dbContext.ProjectIndicators.DeleteAllOnSubmit(indicators);
                            dbContext.SubmitChanges();
                        }

                        if (project.ListOfStatusIndicators.Any())
                        {
                            AddProjectIndicators(project, ref dbContext);
                        }
                    }
                }
                GlobalCode.CallsToApisResults = $"Process complete. {GlobalCode.CallsToApisForProjectData} API calls for {projectCount} projects.";
            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }

            //////////////////////////////////////////////////
            // Local functions
            //////////////////////////////////////////////////
            void AddUpdateProjectRecord(ProjectModel p, ref SQLDataClassesDataContext context, SqlAction action)
            {
                try
                {
                    Project o;
                    o = action == SqlAction.Add ? new Project() : context.Projects.Single(r => r.EclipseId == p.EclipseId);
                    o.Name = p.Name;
                    o.Description = p.Description;
                    o.FullStatusNotes = p.FullStatusNotes;
                    o.ShortStatusNotes = p.ShortStatusNotes;
                    o.ProjectOwner = p.ProjectOwner;
                    o.Priority = p.Priority;
                    o.StatusCategoryId = p.StatusTypeId;
                    o.StatusCategory = p.StatusType;
                    o.StartDate = p.StartDate;
                    o.EndDate = p.EndDate;
                    o.DateCreated = p.CreatedDate;
                    o.DateLastModified = p.ModifiedDate;
                    o.PercentComplete = p.PercentComplete;
                    o.Status = p.Status;
                    o.StatusSortOder = p.StatusSortOrder;
                    o.PrioritySortOrder = p.PrioritySortOrder;
                    o.StatusId = p.StatusId;
                    o.PriorityId = p.PriorityId;
                    o.ProjectOwnerId = p.ProjectOwnerId == null ? -1 : (int)p.ProjectOwnerId;
                    o.LastStatusDate = p.LastStatusDate;
                    o.LastUpdated = DateTime.Now;
                    if (action == SqlAction.Add)
                    {
                        o.EclipseId = p.EclipseId;
                        o.CreateDate = DateTime.Now;
                        context.Projects.InsertOnSubmit(o);
                    }
                    context.SubmitChanges();
                }
                catch (Exception ex)
                {
                    GlobalCode.ExceptionHandler(ex);
                }
            }

            void AddProjectIndicators(ProjectModel p, ref SQLDataClassesDataContext context)
            {
                try
                {
                    foreach (ProjectModel.Indicator indicator in p.ListOfStatusIndicators)
                    {
                        ProjectIndicator objIndicator = new ProjectIndicator();
                        objIndicator.ProjectEclipseId = p.EclipseId;
                        objIndicator.Name = indicator.Name;
                        objIndicator.StateId = indicator.StateId;
                        objIndicator.StateName = indicator.StateName;
                        objIndicator.CreateDate = DateTime.Now;
                        objIndicator.LastUpdated = DateTime.Now;
                        context.ProjectIndicators.InsertOnSubmit(objIndicator);
                        context.SubmitChanges();
                    }
                }
                catch (Exception ex)
                {
                    GlobalCode.ExceptionHandler(ex);
                }
            }

            List<int> GetListOfEclipseIds(ref SQLDataClassesDataContext context)
            {
                var eclipseIds = from p in context.Projects select p.EclipseId;
                List<int> existingIds = new List<int>();
                foreach (int eclipseId in eclipseIds)
                {
                    existingIds.Add(eclipseId);
                }
                return existingIds;
            }

            bool HaveIndicatorRecordsChanged(ProjectModel p, ref SQLDataClassesDataContext context)
            {
                List<ProjectIndicator> sqlIndList = new List<ProjectIndicator>();
                sqlIndList = context.ProjectIndicators.Where(i => i.ProjectEclipseId == p.EclipseId).ToList();
                bool noChangeRequired = true;

                // if no indicators in project from API, trust API and delete any corresponding SQL indicators for project
                if (!p.ListOfStatusIndicators.Any())
                {
                    noChangeRequired = false;
                }
                // since there are indicators in api project object, check if 
                // there are any corresponding records in sql. if not, add them
                else if (!sqlIndList.Any())
                {
                    noChangeRequired = false;
                }
                // since there are records in both, do they have the same number of indicators
                // if not, trust project api object, delete sql entries and add project api indicators
                else if (p.ListOfStatusIndicators.Count() != sqlIndList.Count())
                {
                    noChangeRequired = false;
                }
                // the same number of indicators exist in both, now check if they are the same
                else
                {
                    int i = 0;
                    foreach (ProjectModel.Indicator projInd in p.ListOfStatusIndicators)
                    {
                        // check values of current indicator. must be in same order and be equal
                        if (projInd.Name != sqlIndList[i].Name || projInd.StateId != sqlIndList[i].StateId || projInd.StateName != sqlIndList[i].StateName)
                        {
                            noChangeRequired = false;
                            break;
                        }
                        i++;
                    }
                }
                return !noChangeRequired;
            }

            bool HasProjectRecordChanged(ProjectModel p, ref SQLDataClassesDataContext context)
            {
                Project objProject = context.Projects.Single(r => r.EclipseId == p.EclipseId);

                // SQL decimal is set to precision of 4 places after decimal
                string objPercComp = Convert.ToString(objProject.PercentComplete);
                string pPerComp = Convert.ToString(p.PercentComplete);
                objPercComp = objPercComp.Length > pPerComp.Length ? objPercComp.Substring(0, pPerComp.Length) : objPercComp;
                pPerComp = pPerComp.Length > objPercComp.Length ? pPerComp.Substring(0, objPercComp.Length) : pPerComp;

                // Remove special characters from status notes and desciption
                string objFullStatusNotes = Regex.Replace(objProject.FullStatusNotes, @"[^\w\d\s]", "");
                string pStatusUpdate = Regex.Replace(p.FullStatusNotes, @"[^\w\d\s]", "");
                string objDescription = Regex.Replace(objProject.Description, @"[^\w\d\s]", "");
                string pDescription = Regex.Replace(p.Description, @"[^\w\d\s]", "");

                // return whether object properties are equal
                return !(objProject.Name == p.Name &&
                    objDescription == pDescription &&
                    objFullStatusNotes == pStatusUpdate &&
                    objProject.ProjectOwner == p.ProjectOwner &&
                    objProject.Priority == p.Priority &&
                    objProject.StatusCategoryId == p.StatusTypeId &&
                    objProject.StatusCategory == p.StatusType &&
                    objProject.StartDate == p.StartDate &&
                    objProject.EndDate == p.EndDate &&
                    objPercComp == pPerComp &&
                    objProject.Status == p.Status &&
                    objProject.StatusSortOder == p.StatusSortOrder &&
                    objProject.LastStatusDate == p.LastStatusDate
                );
            }
        }
    }
}
