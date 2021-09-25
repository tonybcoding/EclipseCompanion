
namespace EclipseCompanionView
{
    partial class LaunchForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LaunchForm));
            this.launchMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectsFromMostRecentRunToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectsToResourceTrackerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrativeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshDBWithAPICallsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configureExportViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generalConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectLabel = new System.Windows.Forms.Label();
            this.addTaskLabel = new System.Windows.Forms.Label();
            this.projectComboBox = new System.Windows.Forms.ComboBox();
            this.addTaskValue = new System.Windows.Forms.TextBox();
            this.logButton = new System.Windows.Forms.Button();
            this.workingOnGroupBox = new System.Windows.Forms.GroupBox();
            this.addNewTaskButton = new System.Windows.Forms.Button();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.launchMenuStrip.SuspendLayout();
            this.workingOnGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // launchMenuStrip
            // 
            this.launchMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.administrativeToolStripMenuItem});
            this.launchMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.launchMenuStrip.Name = "launchMenuStrip";
            this.launchMenuStrip.Size = new System.Drawing.Size(587, 24);
            this.launchMenuStrip.TabIndex = 0;
            this.launchMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changePasswordToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projectsFromMostRecentRunToolStripMenuItem,
            this.projectsToResourceTrackerToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // projectsFromMostRecentRunToolStripMenuItem
            // 
            this.projectsFromMostRecentRunToolStripMenuItem.Name = "projectsFromMostRecentRunToolStripMenuItem";
            this.projectsFromMostRecentRunToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.projectsFromMostRecentRunToolStripMenuItem.Text = "Projects";
            this.projectsFromMostRecentRunToolStripMenuItem.Click += new System.EventHandler(this.projectsFromMostRecentRunToolStripMenuItem_Click);
            // 
            // projectsToResourceTrackerToolStripMenuItem
            // 
            this.projectsToResourceTrackerToolStripMenuItem.Enabled = false;
            this.projectsToResourceTrackerToolStripMenuItem.Name = "projectsToResourceTrackerToolStripMenuItem";
            this.projectsToResourceTrackerToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.projectsToResourceTrackerToolStripMenuItem.Text = "Projects to Resource Tracker";
            // 
            // administrativeToolStripMenuItem
            // 
            this.administrativeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshDBWithAPICallsToolStripMenuItem,
            this.configureExportViewerToolStripMenuItem,
            this.generalConfigurationToolStripMenuItem,
            this.userManagementToolStripMenuItem});
            this.administrativeToolStripMenuItem.Name = "administrativeToolStripMenuItem";
            this.administrativeToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.administrativeToolStripMenuItem.Text = "Administrative";
            this.administrativeToolStripMenuItem.Visible = false;
            // 
            // refreshDBWithAPICallsToolStripMenuItem
            // 
            this.refreshDBWithAPICallsToolStripMenuItem.Name = "refreshDBWithAPICallsToolStripMenuItem";
            this.refreshDBWithAPICallsToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.refreshDBWithAPICallsToolStripMenuItem.Text = "Refresh Projects Tables via API Calls";
            this.refreshDBWithAPICallsToolStripMenuItem.Click += new System.EventHandler(this.refreshDBWithAPICallsToolStripMenuItem_Click);
            // 
            // configureExportViewerToolStripMenuItem
            // 
            this.configureExportViewerToolStripMenuItem.Name = "configureExportViewerToolStripMenuItem";
            this.configureExportViewerToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.configureExportViewerToolStripMenuItem.Text = "Configure Export/Viewer";
            this.configureExportViewerToolStripMenuItem.Click += new System.EventHandler(this.configureExportViewerToolStripMenuItem_Click);
            // 
            // generalConfigurationToolStripMenuItem
            // 
            this.generalConfigurationToolStripMenuItem.Name = "generalConfigurationToolStripMenuItem";
            this.generalConfigurationToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.generalConfigurationToolStripMenuItem.Text = "General Configuration";
            this.generalConfigurationToolStripMenuItem.Click += new System.EventHandler(this.generalConfigurationToolStripMenuItem_Click);
            // 
            // userManagementToolStripMenuItem
            // 
            this.userManagementToolStripMenuItem.Name = "userManagementToolStripMenuItem";
            this.userManagementToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.userManagementToolStripMenuItem.Text = "User Management";
            this.userManagementToolStripMenuItem.Click += new System.EventHandler(this.userManagementToolStripMenuItem_Click);
            // 
            // projectLabel
            // 
            this.projectLabel.AutoSize = true;
            this.projectLabel.Location = new System.Drawing.Point(12, 30);
            this.projectLabel.Name = "projectLabel";
            this.projectLabel.Size = new System.Drawing.Size(89, 17);
            this.projectLabel.TabIndex = 2;
            this.projectLabel.Text = "Project / Task:";
            // 
            // addTaskLabel
            // 
            this.addTaskLabel.AutoSize = true;
            this.addTaskLabel.Location = new System.Drawing.Point(8, 63);
            this.addTaskLabel.Name = "addTaskLabel";
            this.addTaskLabel.Size = new System.Drawing.Size(93, 17);
            this.addTaskLabel.TabIndex = 3;
            this.addTaskLabel.Text = "Add new task :";
            // 
            // projectComboBox
            // 
            this.projectComboBox.FormattingEnabled = true;
            this.projectComboBox.Location = new System.Drawing.Point(104, 26);
            this.projectComboBox.Name = "projectComboBox";
            this.projectComboBox.Size = new System.Drawing.Size(393, 25);
            this.projectComboBox.TabIndex = 4;
            // 
            // addTaskValue
            // 
            this.addTaskValue.Location = new System.Drawing.Point(104, 59);
            this.addTaskValue.Name = "addTaskValue";
            this.addTaskValue.Size = new System.Drawing.Size(393, 25);
            this.addTaskValue.TabIndex = 5;
            // 
            // logButton
            // 
            this.logButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logButton.Location = new System.Drawing.Point(503, 23);
            this.logButton.Name = "logButton";
            this.logButton.Size = new System.Drawing.Size(49, 30);
            this.logButton.TabIndex = 7;
            this.logButton.Text = "Log";
            this.logButton.UseVisualStyleBackColor = true;
            this.logButton.Click += new System.EventHandler(this.logButton_Click);
            // 
            // workingOnGroupBox
            // 
            this.workingOnGroupBox.Controls.Add(this.addNewTaskButton);
            this.workingOnGroupBox.Controls.Add(this.projectComboBox);
            this.workingOnGroupBox.Controls.Add(this.projectLabel);
            this.workingOnGroupBox.Controls.Add(this.addTaskLabel);
            this.workingOnGroupBox.Controls.Add(this.logButton);
            this.workingOnGroupBox.Controls.Add(this.addTaskValue);
            this.workingOnGroupBox.Enabled = false;
            this.workingOnGroupBox.Location = new System.Drawing.Point(11, 32);
            this.workingOnGroupBox.Name = "workingOnGroupBox";
            this.workingOnGroupBox.Size = new System.Drawing.Size(564, 98);
            this.workingOnGroupBox.TabIndex = 10;
            this.workingOnGroupBox.TabStop = false;
            this.workingOnGroupBox.Text = "Select existing or add new";
            this.workingOnGroupBox.Visible = false;
            // 
            // addNewTaskButton
            // 
            this.addNewTaskButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addNewTaskButton.Location = new System.Drawing.Point(503, 56);
            this.addNewTaskButton.Name = "addNewTaskButton";
            this.addNewTaskButton.Size = new System.Drawing.Size(49, 30);
            this.addNewTaskButton.TabIndex = 10;
            this.addNewTaskButton.Text = "Add";
            this.addNewTaskButton.UseVisualStyleBackColor = true;
            this.addNewTaskButton.Click += new System.EventHandler(this.addNewTaskButton_Click);
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.changePasswordToolStripMenuItem.Text = "Change Password";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // LaunchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(587, 141);
            this.Controls.Add(this.workingOnGroupBox);
            this.Controls.Add(this.launchMenuStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.launchMenuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "LaunchForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Eclipse Companion";
            this.launchMenuStrip.ResumeLayout(false);
            this.launchMenuStrip.PerformLayout();
            this.workingOnGroupBox.ResumeLayout(false);
            this.workingOnGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip launchMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectsFromMostRecentRunToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectsToResourceTrackerToolStripMenuItem;
        private System.Windows.Forms.Label projectLabel;
        private System.Windows.Forms.Label addTaskLabel;
        private System.Windows.Forms.ComboBox projectComboBox;
        private System.Windows.Forms.TextBox addTaskValue;
        private System.Windows.Forms.Button logButton;
        private System.Windows.Forms.GroupBox workingOnGroupBox;
        private System.Windows.Forms.ToolStripMenuItem administrativeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshDBWithAPICallsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configureExportViewerToolStripMenuItem;
        private System.Windows.Forms.Button addNewTaskButton;
        private System.Windows.Forms.ToolStripMenuItem generalConfigurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
    }
}

