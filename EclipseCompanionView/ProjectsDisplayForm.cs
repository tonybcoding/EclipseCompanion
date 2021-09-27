using EclipseCompanionControlLibrary;
using EclipseCompanionModelLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace EclipseCompanionView
{
    public partial class ProjectsDisplayForm : Form
    {
        private int currentRow { get; set; }
        private int configDisplayNameIndex { get; set; }
        private int colWidthInPixelsIndex { get; set; }
        private int configToDisplayIndex { get; set; }
        private bool inConfig { get; set; }
        public string searchString { get; set; }
        private Filter currentFilter { get; set; }

        // disable the X button on the form
        // CREDIT: https://www.codeproject.com/Articles/20379/Disabling-Close-Button-on-Forms
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        public ProjectsDisplayForm(bool showConfig)
        {
            InitializeComponent();
            this.inConfig = showConfig;
            SetVisiblePropertiesBasedOnUserRights();

            // if no records in CongurationFields table, then attemtp to add records based on defaults
            // false is returned if this is not successful (perhaps no config and no projects by which to build config
            if (Linq2SqlProcessor.AddDefaultConfigIfNeeded())
            {
                // Populate columns based on existing or newly added column config settings
                List<ColumnModel> cols = Linq2SqlProcessor.GetColumnConfigs();
                BuildGridHeaders(ref cols, this.inConfig);
                AddProjectDataToGrid(cols);
            }
            else
            {
                MessageBox.Show("Configuration not complete. Please contact application administrator.",
                    "Missing Configuration",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                exportButton.Hide();
                saveButton.Hide();
                filterPanel.Hide();
                closeButton.Show();
            }
        }

        private void SetVisiblePropertiesBasedOnUserRights()
        {
            if (this.inConfig)
            {
                this.Text = "Configuration View";
                exportButton.Hide();
                closeButton.Hide();
                currentFilter = Filter.All;
                filterPanel.Hide();
            }
            else
            {
                this.Text = "View Projects";
                saveButton.Hide();
                closeNoSaveButton.Hide();
                showResultsViewCheckBox.Hide();
                currentFilter = Filter.Active;
                filterActiveRadioButton.Checked = true;
            }

            AccessLevels accessLevel = GlobalCode.MainLogin.AccessLevel;
            if (accessLevel == AccessLevels.General || accessLevel == AccessLevels.ISTMember)
            {
                filterPanel.Hide();
                exportButton.Hide();
            }
            else
            {
                // add event for each radioButton in filterPanel
                foreach (Control control in filterPanel.Controls)
                {
                    if (control.GetType() == typeof(RadioButton))
                    {
                        RadioButton rbn = (RadioButton)control;
                        rbn.CheckedChanged += new System.EventHandler(filterRbn_CheckedChanged);
                    }
                }
            }
        }

        private void BeginFilterSearchingProjects()
        {
            searchTextBox.Text = "";
            projectsDataGridView.Rows.Clear();
            projectsDataGridView.Refresh();

            currentRow = 0;

            exportButton.Enabled = false;
            closeButton.Enabled = false;
            filterPanel.Enabled = false;
        }

        private void EndFilterSearchingProjects()
        {
            exportButton.Enabled = true;
            closeButton.Enabled = true;
            filterPanel.Enabled = true;
        }

        private void filterRbn_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rbn = (RadioButton)sender;
            if (rbn.Checked)
            {
                BeginFilterSearchingProjects();

                if (rbn.Text == "All")
                {
                    currentFilter = Filter.All;
                }
                else if (rbn.Text == "Closed")
                {
                    currentFilter = Filter.ClosedAndArchived;
                }
                else if (rbn.Text == "Suspended")
                {
                    currentFilter = Filter.Suspended;
                }
                else if (rbn.Text == "Active")
                {
                    currentFilter = Filter.Active;
                }

                List<ColumnModel> cols = Linq2SqlProcessor.GetColumnConfigs();
                AddProjectDataToGrid(cols);
                EndFilterSearchingProjects();
            }
        }

        private void AddProjectDataToGrid(List<ColumnModel> cols)
        {
            try
            {
                // get projects from sql based on currentFilter or text
                List<ProjectModel> projects = new List<ProjectModel>();
                if (currentFilter == Filter.Search)
                {
                    projects = Linq2SqlProcessor.GetProjectsFromSql(this.currentFilter, -1, searchString);
                }
                else
                {
                    projects = Linq2SqlProcessor.GetProjectsFromSql(this.currentFilter);
                }

                projectsDisplayedLabel.Text = $"Projects in current view: {projects.Count}";

                // use reflection to get properties of ProjectModel class
                PropertyInfo[] properties = typeof(ProjectModel).GetProperties();

                // Traverse each project record
                foreach (ProjectModel p in projects)
                {
                    // create new row element
                    DataGridViewRow row = new DataGridViewRow();
                    row.HeaderCell.Value = p.EclipseId;
                    row.ReadOnly = true;
                    projectsDataGridView.Rows.Add(row);

                    // Traverse each column, then each property of projectmodel
                    foreach (ColumnModel c in cols)
                    {
                        foreach (PropertyInfo property in properties)
                        {
                            if (c.FieldName == property.Name)
                            {
                                var value = property.GetValue(p, null);
                                if (property.PropertyType == typeof(DateTime))
                                {
                                    if (ShowDate(p.StatusTypeId, property.Name))
                                    {
                                        DateTime thisDate = Convert.ToDateTime(value).Date;
                                        value = thisDate.ToShortDateString();
                                        projectsDataGridView.Columns[c.DisplayColumn].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                    }
                                    else
                                    {
                                        value = null;
                                    }
                                }
                                else if (property.PropertyType == typeof(Decimal))
                                {
                                    int thisDecimal = Convert.ToInt32((Decimal)value * 100);
                                    value = $"{thisDecimal}%";
                                    projectsDataGridView.Columns[c.DisplayColumn].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                }
                                projectsDataGridView.Rows[currentRow].Cells[c.DisplayColumn].Value = value;
                                break; // since we've found the field we can exit foreach
                            }
                        }
                    }

                    // Traverse each column, then each item in p.ListOfIndicators and add those as appropriate
                    List<string> indicatorValues = Linq2SqlProcessor.GetIndicatorValues();
                    foreach (ColumnModel c in cols)
                    {
                        if (p.ListOfStatusIndicators != null)
                        {
                            foreach (ProjectModel.Indicator i in p.ListOfStatusIndicators)
                            {
                                if (c.FieldName == i.Name)
                                {
                                    bool isIndicator = false;
                                    if (i.StateName != "Not Set")
                                    {
                                        Color shading = new Color();
                                        string newValue = "";
                                        isIndicator = GlobalCode.ProcessIndicator("Complexity", i, c, indicatorValues, 3, ref shading, ref newValue) ||
                                            GlobalCode.ProcessIndicator("Schedule", i, c, indicatorValues, 6, ref shading, ref newValue) ||
                                            GlobalCode.ProcessIndicator("Overall Project Health", i, c, indicatorValues, 9, ref shading, ref newValue);
                                        if (isIndicator)
                                        {
                                            projectsDataGridView.Columns[c.DisplayColumn].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                                            projectsDataGridView.Rows[currentRow].Cells[c.DisplayColumn].Style.BackColor = shading;
                                            projectsDataGridView.Rows[currentRow].Cells[c.DisplayColumn].Value = newValue;
                                        }
                                        else
                                        {
                                            projectsDataGridView.Rows[currentRow].Cells[c.DisplayColumn].Value = i.StateName;
                                        }
                                    }
                                    break; // can stop looking
                                }
                            }
                        }
                    }

                    // move to next row
                    currentRow++;
                }
            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }

            /////////////////////////////////////////////////////
            // local functions
            /////////////////////////////////////////////////////
            bool ShowDate(int typeId, string fieldName)
            {
                bool showIt = true;
                if (typeId != GlobalCode.ActiveStatusCategory && (fieldName == GlobalCode.StartDateField || fieldName == GlobalCode.EndDateField))
                {
                    showIt = false;
                }
                return showIt;
            }
        }

        private void BuildGridHeaders(ref List<ColumnModel> cols, bool inConfig)
        {
            int index = 0;
            foreach (ColumnModel c in cols)
            {
                DataGridViewColumn newCol = new DataGridViewColumn();
                newCol.CellTemplate = new DataGridViewTextBoxCell();
                string headerName = inConfig ? c.FieldName : c.DisplayName;
                newCol.HeaderText = headerName;
                newCol.Name = $"column{index++}";
                newCol.Visible = true;
                newCol.Width = Convert.ToInt32(c.ColumnWidth);
                projectsDataGridView.Columns.Add(newCol);
                // we want all date there, but just not visible unless intended
                // this way on double, click, the data is already there to retrieve without making
                // another sql call for a single project.
                // especially important if EclipseId and SqlId are both hidden
                newCol.Visible = (inConfig || c.ToDisplay) ? true : false;
            }

            // if in config, add configuration rows and configuration data
            if (inConfig)
            {
                projectsDataGridView.RowHeadersVisible = true;
                //projectsDataGridView.RowHeadersWidth = GlobalCode.ConfigurationHeaderRowWidth;

                DataGridViewRow row = new DataGridViewRow();
                row.HeaderCell.Value = "Display name";
                row.DefaultCellStyle.BackColor = Color.LightGray;
                configDisplayNameIndex = projectsDataGridView.Rows.Add(row);
                foreach (ColumnModel c in cols)
                {
                    projectsDataGridView.Rows[currentRow].Cells[c.DisplayColumn].Value = c.DisplayName;
                }
                currentRow++;

                row = new DataGridViewRow();
                row.HeaderCell.Value = "Column width";
                row.DefaultCellStyle.BackColor = Color.LightGray;
                colWidthInPixelsIndex = projectsDataGridView.Rows.Add(row);
                foreach (ColumnModel c in cols)
                {
                    projectsDataGridView.Rows[currentRow].Cells[c.DisplayColumn].Value = c.ColumnWidth;
                }
                currentRow++;

                row = new DataGridViewRow();
                row.HeaderCell.Value = "Include in display";
                row.DefaultCellStyle.BackColor = Color.LightGray;
                configToDisplayIndex = projectsDataGridView.Rows.Add(row);
                foreach (ColumnModel c in cols)
                {
                    DataGridViewCheckBoxCell cell = new DataGridViewCheckBoxCell();
                    cell.Value = c.ToDisplay;
                    projectsDataGridView.Rows[currentRow].Cells[c.DisplayColumn] = cell;
                }
                currentRow++;
            }
            else
            {
                projectsDataGridView.RowHeadersVisible = false;
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            ExportForm exportForm = new ExportForm();
            exportForm.ShowDialog();
        }

        private void closeNoSaveButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit without saving? Any changes will be lost.",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {

            List<ColumnModel> cols = new List<ColumnModel>();
            foreach (DataGridViewColumn dgcol in projectsDataGridView.Columns)
            {
                // must use [column.Index] even if the column was moved. Index still refers to data in that column
                // while display Index shows where the user moved the column
                ColumnModel col = new ColumnModel();
                col.FieldName = dgcol.HeaderText;
                col.DisplayName = projectsDataGridView.Rows[configDisplayNameIndex].Cells[dgcol.Index].Value.ToString();
                col.DisplayColumn = dgcol.DisplayIndex;
                col.ColumnWidth = Convert.ToInt32(projectsDataGridView.Rows[colWidthInPixelsIndex].Cells[dgcol.Index].Value);
                col.ToDisplay = Convert.ToBoolean(projectsDataGridView.Rows[configToDisplayIndex].Cells[dgcol.Index].Value);
                cols.Add(col);
            }
            SQLDataClassesDataContext dbContext = new SQLDataClassesDataContext(GlobalCode.ConnectionString);
            Linq2SqlProcessor.AddFieldRecordsToSQL(cols, ref dbContext);
            MessageBox.Show($"Field configuration was properly saved.",
                $"Configuration Saved",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            this.Close();
        }

        private void projectsDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!inConfig && GlobalCode.MainLogin.AccessLevel != AccessLevels.General)
            {
                // get eclipseId from row.header.value
                int eclipseId = Convert.ToInt32(projectsDataGridView.Rows[e.RowIndex].HeaderCell.Value);

                // Load single project from Sql based on that EclipseId
                List<ProjectModel> projects = Linq2SqlProcessor.GetProjectsFromSql(Filter.Single, eclipseId);
                ProjectModel p = projects[0];
                ProjectDetailsForm detailsForm = new ProjectDetailsForm(p);
                detailsForm.ShowDialog();
            }
        }

        private void showResultsViewCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (showResultsViewCheckBox.Checked)
            {
                // hide config rows and change header row width
                showResultsViewCheckBox.Enabled = false;
                saveButton.Enabled = false;
                closeNoSaveButton.Enabled = false;
                projectsDataGridView.ColumnHeadersVisible = false;
                projectsDataGridView.Rows[configToDisplayIndex].Visible = false;
                projectsDataGridView.Rows[colWidthInPixelsIndex].Visible = false;
                projectsDataGridView.RowHeadersVisible = false;
                // hide columns that are not checked for ToDisplay
                foreach (DataGridViewColumn c in projectsDataGridView.Columns)
                {
                    DataGridViewCheckBoxCell cell = new DataGridViewCheckBoxCell();
                    cell.Value = projectsDataGridView.Rows[configToDisplayIndex].Cells[c.Index].Value;
                    if (!Convert.ToBoolean(cell.Value))
                    {
                        c.Visible = false;
                    }
                }
                showResultsViewCheckBox.Enabled = true;
            }
            else
            {
                // show config rows and go to first position and change header row width
                showResultsViewCheckBox.Enabled = false;
                saveButton.Enabled = true;
                closeNoSaveButton.Enabled = true;
                projectsDataGridView.ColumnHeadersVisible = true;
                projectsDataGridView.Rows[configToDisplayIndex].Visible = true;
                projectsDataGridView.Rows[colWidthInPixelsIndex].Visible = true;
                projectsDataGridView.RowHeadersVisible = true;
                projectsDataGridView.FirstDisplayedScrollingRowIndex = projectsDataGridView.SelectedRows[0].Index;
                // unhide all columns
                foreach (DataGridViewColumn c in projectsDataGridView.Columns)
                {
                    c.Visible = true;
                }
                showResultsViewCheckBox.Enabled = true;
            }
        }

        private void projectsDataGridView_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            projectsDataGridView.Rows[colWidthInPixelsIndex].Cells[e.Column.Index].Value = e.Column.Width;
        }

        private void projectsDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // if column width cell was changed            
            if (e.RowIndex == colWidthInPixelsIndex)
            {
                projectsDataGridView.Columns[e.ColumnIndex].Width = Convert.ToInt32(projectsDataGridView.Rows[colWidthInPixelsIndex].Cells[e.ColumnIndex].Value);
            }
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            searchButton.Enabled = searchTextBox.Text != "";
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            this.searchString = searchTextBox.Text;
            // this check is required in case the user hits the Enter button in
            // the search field with no text entered
            if (this.searchString != "")
            {
                currentFilter = Filter.Search;
                foreach (Control ctrl in filterPanel.Controls)
                {
                    if (ctrl.GetType() == typeof(RadioButton))
                    {
                        RadioButton rbn = (RadioButton)ctrl;
                        rbn.Checked = false;
                    }
                }
                BeginFilterSearchingProjects();
                List<ColumnModel> cols = Linq2SqlProcessor.GetColumnConfigs();
                AddProjectDataToGrid(cols);
                EndFilterSearchingProjects();
            }
        }

        private void searchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchButton_Click(this, new EventArgs());
            }
        }
    }
}
