using EclipseCompanionControlLibrary;
using EclipseCompanionModelLibrary;
using System;
using System.Windows.Forms;

namespace EclipseCompanionView
{
    public partial class ProjectDetailsForm : Form
    {
        public ProjectDetailsForm(ProjectModel p)
        {
            InitializeComponent();

            this.Text += $" - {p.Name}";
            titleTextBox.Text = p.Name;
            descriptionRichTextBox.Text = p.Description;
            ownerTextBox.Text = p.ProjectOwner;
            createOnTextBox.Text = p.CreatedDate.ToShortDateString();
            lastModifiedTextBox.Text = p.ModifiedDate.ToShortDateString();
            if (p.StatusTypeId == GlobalCode.ActiveStatusCategory)
            {
                startTextBox.Text = p.StartDate.ToShortDateString();
                endTextBox.Text = p.EndDate.ToShortDateString();
            }
            percCompleteTextBox.Text = $"{Convert.ToInt32(p.PercentComplete * 100)}%";
            statusNotesRichTextBox.Text = $"Full status notes{Environment.NewLine}{Environment.NewLine}{p.FullStatusNotes}";
            statusTextBox.Text = p.Status;
            statusDateTextBox.Text = p.LastStatusDate.ToShortDateString();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
