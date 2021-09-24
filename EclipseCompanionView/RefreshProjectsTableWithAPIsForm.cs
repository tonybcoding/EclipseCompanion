using EclipseCompanionControlLibrary;
using EclipseCompanionModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EclipseCompanionView
{
    public partial class RefreshProjectsTableWithAPIsForm : Form
    {
        public bool cancelProjectLoad { get; set; }
        public int progressBarValue { get; set; } = 0;
        public int projectCount { get; set; } = 0;
        List<ProjectModel> projectsList = new List<ProjectModel>();

        public RefreshProjectsTableWithAPIsForm()
        {
            GlobalCode.CallsToApisForProjectData = 0;
            GlobalCode.CallsToApisResults = "";
            InitializeComponent();
            MakePrimaryApiCall();   // follow on calls to ancillary and readyforsql are handled through event handlers
        }

        private async void MakePrimaryApiCall()
        {
            try
            {
                cancelLoadButton.Enabled = false;
                if (!cancelProjectLoad)
                {
                    actionLabel.Text = "Loading project from Eclipse...";
                    projectsList = await ApiProjectProcessor.GetEclipseProjectIDsAsync();
                }
                else
                {
                    actionLabel.Text = $"Operation canceled by user.";
                    refreshProjectsProgressBar.Value = 0;
                    closeButton.Enabled = true;
                    cancelLoadButton.Enabled = false;
                }
                if (!cancelProjectLoad)
                {
                    cancelLoadButton.Enabled = true;
                    readyToCallAncillaryApis = true;
                }
            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }
        }

        private async void MakeAncillaryApiCalls()
        {
            try
            {
                double percentageRatio = 100.0 / projectsList.Count();
                List<string> indicatorLabelName = new List<string>();
                List<string> indicatorName = new List<string>();

                foreach (ProjectModel project in projectsList)
                {
                    if (!cancelProjectLoad)
                    {
                        actionLabel.Text = $"Making API calls for project {projectCount} of {projectsList.Count()}. " +
                            $"API calls: {GlobalCode.CallsToApisForProjectData}";

                        ProjectModel tempProject = await ApiProjectProcessor.GetProjectInfoAsync(project);

                        // use values from tempProject to update project
                        project.ProjectOwner = tempProject.ProjectOwner;
                        project.Priority = tempProject.Priority;
                        project.PrioritySortOrder = tempProject.PrioritySortOrder;
                        project.StatusTypeId = tempProject.StatusTypeId;
                        project.StatusType = tempProject.StatusType;
                        project.StatusSortOrder = tempProject.StatusSortOrder;
                        project.Status = tempProject.Status;
                        project.LastStatusDate = tempProject.LastStatusDate;
                        project.ListOfStatusIndicators = tempProject.ListOfStatusIndicators;
                        project.FullStatusNotes = tempProject.FullStatusNotes;
                        project.ShortStatusNotes = tempProject.ShortStatusNotes;
                        project.Description = tempProject.Description;
                        project.ProjectOwner = tempProject.ProjectOwner;

                        progressBarValue = Convert.ToInt32(projectCount * percentageRatio);
                        GlobalCode.UpdateProgressBar(this.refreshProjectsProgressBar, progressBarValue);
                        projectCount++;
                    }
                    else
                    {
                        actionLabel.Text = $"Operation canceled by user. On project {projectCount} making " +
                            $"{GlobalCode.CallsToApisForProjectData} API calls.";
                        refreshProjectsProgressBar.Value = 0;
                        closeButton.Enabled = true;
                        cancelLoadButton.Enabled = false;
                        break;
                    }
                }
                cancelLoadButton.Enabled = false;
                if (!cancelProjectLoad)
                {
                    GlobalCode.UpdateProgressBar(this.refreshProjectsProgressBar, 100);
                    readyToUpdateSql = true;
                }
            }
            catch (Exception ex)
            {

                GlobalCode.ExceptionHandler(ex);
            }
        }

        private void cancelLoadButton_Click(object sender, EventArgs e)
        {
            cancelProjectLoad = true;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            cancelProjectLoad = true;
            this.Close();
        }



        #region "Event handler for changes to readyToCallAncillaryApis"
        // Since the API calls are asynchronous, need to ensure
        // calls to ancillary apis do not start until this process is completed
        public event EventHandler ReadyToCallAncillaryApisChanged;
        protected virtual void OnReadyToCallAncillaryApisChanged()
        {
            if (ReadyToCallAncillaryApisChanged != null) ReadyToCallAncillaryApisChanged(this, EventArgs.Empty);
            MakeAncillaryApiCalls();
        }
        private bool _readyToCallAncillaryApis;
        public bool readyToCallAncillaryApis
        {
            get
            {
                return _readyToCallAncillaryApis;
            }
            set
            {
                _readyToCallAncillaryApis = value;
                OnReadyToCallAncillaryApisChanged();
            }
        }
        #endregion



        #region "Event handler for changes to readyToUpdateSql"
        // Since the API calls are asynchronous, need to ensure
        // SQL methods do not start until this process is completed
        public event EventHandler ReadyToUpdateSqlChanged;
        protected virtual void OnReadyToUpdateSqlChanged()
        {
            if (ReadyToUpdateSqlChanged != null) ReadyToUpdateSqlChanged(this, EventArgs.Empty);
            try
            {
                // TODO: for degugging, i could check the projectcount property
                // and truncate the projectsList accordingly
                Linq2SqlProcessor.UpdateSqlProjectTables(projectsList, projectsList.Count());
            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }
            this.Close();
        }
        private bool _readyToUpdateSql;
        public bool readyToUpdateSql
        {
            get
            {
                return _readyToUpdateSql;
            }
            set
            {
                _readyToUpdateSql = value;
                OnReadyToUpdateSqlChanged();
            }
        }
        #endregion


    }
}
