
namespace EclipseCompanionView
{
    partial class ProjectsDisplayForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectsDisplayForm));
            this.projectsDataGridView = new System.Windows.Forms.DataGridView();
            this.saveButton = new System.Windows.Forms.Button();
            this.closeNoSaveButton = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.showResultsViewCheckBox = new System.Windows.Forms.CheckBox();
            this.filterPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.projectsDisplayedLabel = new System.Windows.Forms.Label();
            this.filterLabel = new System.Windows.Forms.Label();
            this.closedRadioButton = new System.Windows.Forms.RadioButton();
            this.filterSuspendedRadioButton = new System.Windows.Forms.RadioButton();
            this.filterActiveRadioButton = new System.Windows.Forms.RadioButton();
            this.filterAllRadioButton = new System.Windows.Forms.RadioButton();
            this.searchButton = new System.Windows.Forms.Button();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.projectsDataGridView)).BeginInit();
            this.filterPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // projectsDataGridView
            // 
            this.projectsDataGridView.AllowUserToAddRows = false;
            this.projectsDataGridView.AllowUserToDeleteRows = false;
            this.projectsDataGridView.AllowUserToOrderColumns = true;
            this.projectsDataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.projectsDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.projectsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.projectsDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.projectsDataGridView.BackgroundColor = System.Drawing.Color.White;
            this.projectsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.projectsDataGridView.Location = new System.Drawing.Point(13, 60);
            this.projectsDataGridView.MultiSelect = false;
            this.projectsDataGridView.Name = "projectsDataGridView";
            this.projectsDataGridView.RowHeadersWidth = 120;
            this.projectsDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.projectsDataGridView.RowTemplate.Height = 25;
            this.projectsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.projectsDataGridView.Size = new System.Drawing.Size(1322, 501);
            this.projectsDataGridView.TabIndex = 0;
            this.projectsDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.projectsDataGridView_CellDoubleClick);
            this.projectsDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.projectsDataGridView_CellEndEdit);
            this.projectsDataGridView.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.projectsDataGridView_ColumnWidthChanged);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.saveButton.Location = new System.Drawing.Point(524, 570);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(140, 35);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "Save and Close";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // closeNoSaveButton
            // 
            this.closeNoSaveButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.closeNoSaveButton.Location = new System.Drawing.Point(682, 570);
            this.closeNoSaveButton.Name = "closeNoSaveButton";
            this.closeNoSaveButton.Size = new System.Drawing.Size(140, 35);
            this.closeNoSaveButton.TabIndex = 6;
            this.closeNoSaveButton.Text = "Close Without Saving";
            this.closeNoSaveButton.UseVisualStyleBackColor = true;
            this.closeNoSaveButton.Click += new System.EventHandler(this.closeNoSaveButton_Click);
            // 
            // exportButton
            // 
            this.exportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exportButton.Location = new System.Drawing.Point(1146, 570);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(87, 35);
            this.exportButton.TabIndex = 7;
            this.exportButton.Text = "Export";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.Location = new System.Drawing.Point(1248, 570);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(87, 35);
            this.closeButton.TabIndex = 8;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // showResultsViewCheckBox
            // 
            this.showResultsViewCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.showResultsViewCheckBox.AutoSize = true;
            this.showResultsViewCheckBox.Location = new System.Drawing.Point(364, 578);
            this.showResultsViewCheckBox.Name = "showResultsViewCheckBox";
            this.showResultsViewCheckBox.Size = new System.Drawing.Size(146, 21);
            this.showResultsViewCheckBox.TabIndex = 9;
            this.showResultsViewCheckBox.Text = "Show Resulting View";
            this.showResultsViewCheckBox.UseVisualStyleBackColor = true;
            this.showResultsViewCheckBox.CheckedChanged += new System.EventHandler(this.showResultsViewCheckBox_CheckedChanged);
            // 
            // filterPanel
            // 
            this.filterPanel.Controls.Add(this.searchButton);
            this.filterPanel.Controls.Add(this.searchTextBox);
            this.filterPanel.Controls.Add(this.label1);
            this.filterPanel.Controls.Add(this.projectsDisplayedLabel);
            this.filterPanel.Controls.Add(this.filterLabel);
            this.filterPanel.Controls.Add(this.closedRadioButton);
            this.filterPanel.Controls.Add(this.filterSuspendedRadioButton);
            this.filterPanel.Controls.Add(this.filterActiveRadioButton);
            this.filterPanel.Controls.Add(this.filterAllRadioButton);
            this.filterPanel.Location = new System.Drawing.Point(13, 6);
            this.filterPanel.Name = "filterPanel";
            this.filterPanel.Size = new System.Drawing.Size(1322, 48);
            this.filterPanel.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(389, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "~ or ~";
            // 
            // projectsDisplayedLabel
            // 
            this.projectsDisplayedLabel.AutoSize = true;
            this.projectsDisplayedLabel.Location = new System.Drawing.Point(688, 17);
            this.projectsDisplayedLabel.Name = "projectsDisplayedLabel";
            this.projectsDisplayedLabel.Size = new System.Drawing.Size(11, 17);
            this.projectsDisplayedLabel.TabIndex = 13;
            this.projectsDisplayedLabel.Text = ":";
            // 
            // filterLabel
            // 
            this.filterLabel.AutoSize = true;
            this.filterLabel.Location = new System.Drawing.Point(14, 17);
            this.filterLabel.Name = "filterLabel";
            this.filterLabel.Size = new System.Drawing.Size(61, 17);
            this.filterLabel.TabIndex = 4;
            this.filterLabel.Text = "Filter by :";
            // 
            // closedRadioButton
            // 
            this.closedRadioButton.AutoSize = true;
            this.closedRadioButton.Location = new System.Drawing.Point(316, 15);
            this.closedRadioButton.Name = "closedRadioButton";
            this.closedRadioButton.Size = new System.Drawing.Size(66, 21);
            this.closedRadioButton.TabIndex = 3;
            this.closedRadioButton.TabStop = true;
            this.closedRadioButton.Text = "Closed";
            this.closedRadioButton.UseVisualStyleBackColor = true;
            // 
            // filterSuspendedRadioButton
            // 
            this.filterSuspendedRadioButton.AutoSize = true;
            this.filterSuspendedRadioButton.Location = new System.Drawing.Point(211, 15);
            this.filterSuspendedRadioButton.Name = "filterSuspendedRadioButton";
            this.filterSuspendedRadioButton.Size = new System.Drawing.Size(91, 21);
            this.filterSuspendedRadioButton.TabIndex = 2;
            this.filterSuspendedRadioButton.TabStop = true;
            this.filterSuspendedRadioButton.Text = "Suspended";
            this.filterSuspendedRadioButton.UseVisualStyleBackColor = true;
            // 
            // filterActiveRadioButton
            // 
            this.filterActiveRadioButton.AutoSize = true;
            this.filterActiveRadioButton.Location = new System.Drawing.Point(137, 15);
            this.filterActiveRadioButton.Name = "filterActiveRadioButton";
            this.filterActiveRadioButton.Size = new System.Drawing.Size(60, 21);
            this.filterActiveRadioButton.TabIndex = 1;
            this.filterActiveRadioButton.TabStop = true;
            this.filterActiveRadioButton.Text = "Active";
            this.filterActiveRadioButton.UseVisualStyleBackColor = true;
            // 
            // filterAllRadioButton
            // 
            this.filterAllRadioButton.AutoSize = true;
            this.filterAllRadioButton.Location = new System.Drawing.Point(83, 15);
            this.filterAllRadioButton.Name = "filterAllRadioButton";
            this.filterAllRadioButton.Size = new System.Drawing.Size(40, 21);
            this.filterAllRadioButton.TabIndex = 0;
            this.filterAllRadioButton.TabStop = true;
            this.filterAllRadioButton.Text = "All";
            this.filterAllRadioButton.UseVisualStyleBackColor = true;
            // 
            // searchButton
            // 
            this.searchButton.Enabled = false;
            this.searchButton.Location = new System.Drawing.Point(447, 12);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(70, 27);
            this.searchButton.TabIndex = 17;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(524, 13);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(149, 25);
            this.searchTextBox.TabIndex = 18;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            this.searchTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchTextBox_KeyDown);
            // 
            // ProjectsDisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1347, 613);
            this.Controls.Add(this.filterPanel);
            this.Controls.Add(this.showResultsViewCheckBox);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.closeNoSaveButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.projectsDataGridView);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "ProjectsDisplayForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "View Projects";
            ((System.ComponentModel.ISupportInitialize)(this.projectsDataGridView)).EndInit();
            this.filterPanel.ResumeLayout(false);
            this.filterPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView projectsDataGridView;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button closeNoSaveButton;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.CheckBox showResultsViewCheckBox;
        private System.Windows.Forms.Panel filterPanel;
        private System.Windows.Forms.Label filterLabel;
        private System.Windows.Forms.RadioButton closedRadioButton;
        private System.Windows.Forms.RadioButton filterSuspendedRadioButton;
        private System.Windows.Forms.RadioButton filterActiveRadioButton;
        private System.Windows.Forms.RadioButton filterAllRadioButton;
        private System.Windows.Forms.Label projectsDisplayedLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox searchTextBox;
    }
}