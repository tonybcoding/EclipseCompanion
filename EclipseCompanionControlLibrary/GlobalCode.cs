using EclipseCompanionModelLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EclipseCompanionControlLibrary
{
    public class GlobalCode
    {
        // each applicatoin instance will have just one of each at most
        public static EclipseLoginModel EclipseLogin { get; set; }
        public static MainLoginModel MainLogin { get; set; }

        // Project Search Filter IDs... Built in project filter 8 is for all projects
        // Here is where the id of 8 comes from
        // https://help.uplandsoftware.com/eclipseppm/en/user-guide/articles/API/search-id-reference-sheet.htm
        //public const int IdForAllProjectsAPICall = 8;
        // build in search did not include operations projects, so
        // I had to copy that and edit to remove the filtering out of operations projects
        // this is the id that shows in the edit URL for the search I created: DONTERASE-ALLPROJECTS-ECLIPSECOMPANION
        public const int IdForAllProjectsAPICall = 7400;

        // used to monitor api calls between async processes
        public static int CallsToApisForProjectData = 0;
        public static string CallsToApisResults = "";

        // TODO: the following will become configuration items and stored in an XML file
        // the integer values shown are the StatusTypeIds retreived from Eclipse via API calls
        public const int ActiveQueuedStatusCategory = 1;
        public const int ActiveStatusCategory = 2;
        public const int ClosedStatusCategory = 22;
        public const int ArchivedStatusCategory = 23;
        public const int SuspendedStatusCategory = 3;
        public static DateTime BadExportDate = Convert.ToDateTime("1/1/1900");
        public const string StartDateField = "StartDate";
        public const string EndDateField = "EndDate";
        public const string CreatedField = "CreatedDate";
        public const string ModifiedField = "ModifiedDate";
        public const string FullNotesField = "FullStatusNotes";
        public const string StatusTypeIdField = "StatusTypeId";
        public const string DefaultPassword = "pass";
        public static string[] ExportSheets = new string[]
        {
            "All Projects",
            "Active",
            "Suspended",
            "New Since",
            "Closed Since"
        };

        public static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["EclipseCompanion"].ConnectionString;

        public static string FindStringBetween(string source, string begin, string end)
        {
            string firstMarker = begin;
            string secondMarker = end;
            int firstPostion = source.IndexOf(firstMarker) + firstMarker.Length;
            int secondPosition = source.IndexOf(secondMarker);
            return source.Substring(firstPostion, secondPosition - firstPostion);
        }

        public static void DisableAllControls(dynamic obj)
        {
            foreach (Control c in obj.Controls)
            {
                c.Enabled = false;
            }
        }

        public static string SHA256Hash(string inputString)
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes(inputString);
            data = new System.Security.Cryptography.SHA256Managed().ComputeHash(data);
            String hash = System.Text.Encoding.ASCII.GetString(data);
            return hash;
        }

        public static void UpdateProgressBar(ProgressBar bar, int num)
        {
            num = num > 100 ? 100 : num;
            bar.Value = num;
        }

        public static bool ProcessIndicator(string heading, ProjectModel.Indicator i, ColumnModel c,
            List<string> inds, int startIndex, ref Color shading, ref string newValue)
        {
            bool found = false;
            if (i.Name == heading)
            {
                found = true;
                int offSet = 0;
                if (i.StateName == inds[0])
                {
                    shading = Color.LimeGreen;
                }
                else if (i.StateName == inds[1])
                {
                    offSet = 1;
                    shading = Color.Yellow;
                }
                else if (i.StateName == inds[2])
                {
                    offSet = 2;
                    shading = Color.Red;
                }
                newValue = inds[startIndex + offSet];
            }
            return found;
        }

        public static void ExceptionHandler(Exception ex)
        {
            string newln = Environment.NewLine;
            string stack = ex.StackTrace;
            string source = ex.Source;
            string message = ex.Message;
            string errorMessage = $"Application crashed: {newln}- {source}{newln + newln}" +
                                  $"Error message generated: {newln}- {message}{newln + newln}" +
                                  $"Last code executed: {newln}{stack}{newln + newln}";

            MessageBox.Show($"Please take a screenshot of this error and email Tony Burge: tony.burge@kdmc.kdhs.us." +
                        $"{newln + newln + errorMessage}",
                        "Application Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Stop);
        }
    }
}
