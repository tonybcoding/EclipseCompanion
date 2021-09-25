using EclipseCompanionControlLibrary;
using EclipseCompanionModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EclipseCompanionView
{
    public partial class LaunchForm : Form
    {
        public LaunchForm()
        {
            // Only required once per application launch
            InitializeComponent();
            ApiHelper.InitializeClient();
            GlobalCode.EclipseLogin = new EclipseLoginModel();
            GlobalCode.MainLogin = new MainLoginModel();

            bool logInSuccess = LogInToMain();
            if (!logInSuccess)
            {
                GlobalCode.DisableAllControls(this);
            }

            if (logInSuccess)
            {
                this.Text = $"Eclipse Companion for {GlobalCode.MainLogin.FirstName} {GlobalCode.MainLogin.LastName} | {GlobalCode.MainLogin.AccessLevel}";
                populateProjectTaskComboBox();
                ApplyAccessLevel();
            }
        }

        private void ApplyAccessLevel()
        {
            if (GlobalCode.MainLogin.AccessLevel == AccessLevels.Admin)
            {
                administrativeToolStripMenuItem.Visible = true;
            }
            else if (GlobalCode.MainLogin.AccessLevel == AccessLevels.ISTMember)
            {
                workingOnGroupBox.Visible = true;
            }
            else if (GlobalCode.MainLogin.AccessLevel == AccessLevels.Manager)
            {
            }
            else if (GlobalCode.MainLogin.AccessLevel == AccessLevels.General)
            {
                projectsToResourceTrackerToolStripMenuItem.Visible = false;
            }
            else if (GlobalCode.MainLogin.AccessLevel == AccessLevels.Debug)
            {
                workingOnGroupBox.Visible = true;
                administrativeToolStripMenuItem.Visible = true;
            }
        }

        private bool LogInToMain()
        {
            bool cancelLogin = false;
            try
            {
                while (!GlobalCode.MainLogin.LoggedIn)
                {
                    using (LoginForm mainLogin = new LoginForm(LoginTo.Main))
                    {
                        DialogResult result = mainLogin.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            bool loggedIn = MainLoginHelper.Login(mainLogin.UserName, mainLogin.Password);
                            GlobalCode.MainLogin.LoggedIn = loggedIn;
                        }
                        else if (result == DialogResult.Cancel)
                        {
                            cancelLogin = true;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }
            return !cancelLogin && GlobalCode.MainLogin.LoggedIn;
        }

        private void refreshDBWithAPICallsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool cancelLogin = false;
            try
            {
                if (!Linq2SqlProcessor.GetRefreshStatus())
                {
                    Linq2SqlProcessor.ChangeRefreshStatus(true);
                    while (!GlobalCode.EclipseLogin.LoggedIn)
                    {
                        using (LoginForm eclipseLogin = new LoginForm(LoginTo.Eclipse))
                        {
                            DialogResult result = eclipseLogin.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                bool loggedIn = EclipseLogInHelper.LogIn(eclipseLogin.UserName, eclipseLogin.EclipseServiceCredentials);
                                GlobalCode.EclipseLogin.LoggedIn = loggedIn;
                            }
                            else if (result == DialogResult.Cancel)
                            {
                                cancelLogin = true;
                                break;
                            }
                        }
                    }

                    if (GlobalCode.EclipseLogin.LoggedIn && !cancelLogin)
                    {
                        RefreshProjectsTableWithAPIsForm refreshProjectsForm = new RefreshProjectsTableWithAPIsForm();
                        refreshProjectsForm.ShowDialog();
                        if (GlobalCode.CallsToApisResults != "")
                        {
                            MessageBox.Show(GlobalCode.CallsToApisResults,
                                "Processing Complete",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            Linq2SqlProcessor.UpdateRefreshLastUpdate();
                        }
                        else
                        {
                            MessageBox.Show("Operation canceled by user",
                                "Processing Canceled",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                        }
                        Linq2SqlProcessor.ChangeRefreshStatus(false);
                    }
                }
                else
                {
                    MessageBox.Show("The process of refreshing tables is currently running. Please try again later.",
                        "Unable to Proceed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }
        }

        private void populateProjectTaskComboBox()
        {

            // TODO: this should populate based on the latest and most used projects/tasks for this user

            // clear datasource prior to adding
            projectComboBox.DataSource = null;
            List<ProjectTaskModel> listOfProjectsTasks = Linq2SqlProcessor.RetrieveProjectsTasks();
            Dictionary<string, string> comboSource = new Dictionary<string, string>();
            foreach (ProjectTaskModel pt in listOfProjectsTasks)
            {
                if (pt.IsActive)
                {
                    comboSource.Add(pt.Id.ToString(), pt.Name);
                }
            }
            if (listOfProjectsTasks.Any())
            {
                projectComboBox.DataSource = new BindingSource(comboSource, null);
                projectComboBox.DisplayMember = "Value";
                projectComboBox.ValueMember = "Key";
            }
            this.projectComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void configureExportViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectsDisplayForm cform = new ProjectsDisplayForm(true);      // true indicates configuration
            cform.ShowDialog();
        }

        private void logButton_Click(object sender, EventArgs e)
        {
            int key = Convert.ToInt32(((KeyValuePair<string, string>)projectComboBox.SelectedItem).Key);
            string value = ((KeyValuePair<string, string>)projectComboBox.SelectedItem).Value;

            string results = $"{value} has an integer id of {key} and is a ";
            results += (value.StartsWith("Task:")) ? "Task" : "Project";

            MessageBox.Show(results);
        }

        private void addNewTaskButton_Click(object sender, EventArgs e)
        {
            if (addTaskValue.Text == "")
            {
                MessageBox.Show("No data entered. Please enter new task before hitting the 'Add' button.", "No task to add", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // add task to task table
                Linq2SqlProcessor.UpdateSqlTasksTable(addTaskValue.Text, GlobalCode.MainLogin.Id);
                // refresh dropdown
                populateProjectTaskComboBox();
                addTaskValue.Text = "";


                // log that task for current user


                MessageBox.Show("Task added to dropdown list", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void projectsFromMostRecentRunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProjectsDisplayForm pform = new ProjectsDisplayForm(false);      // false indicates this is not a config session
            pform.ShowDialog();
        }

        private void generalConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GeneralConfigForm gform = new GeneralConfigForm();
            gform.ShowDialog();
        }

        private void userManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserManagerForm uform = new UserManagerForm();
            uform.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePasswordForm cform = new ChangePasswordForm(GlobalCode.MainLogin.Id);
            cform.ShowDialog();
        }
    }
}
