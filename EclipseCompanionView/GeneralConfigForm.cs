using EclipseCompanionControlLibrary;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace EclipseCompanionView
{
    public partial class GeneralConfigForm : Form
    {
        public GeneralConfigForm()
        {
            InitializeComponent();
            PopulateValues();
        }

        private void PopulateValues()
        {
            try
            {
                // Retrive values
                DateTime lastRefresh = Linq2SqlProcessor.GetRefreshLastUpdate();
                string lastRefreshedBy = Linq2SqlProcessor.GetRefreshLastUpdateBy();
                bool isRefreshStatus = Linq2SqlProcessor.GetRefreshStatus();
                string truncateString = Linq2SqlProcessor.GetTruncateString();
                List<string> indicators = Linq2SqlProcessor.GetIndicatorValues();

                // Populate Controls
                lastRefreshDateValue.Text = $"{lastRefresh}";
                lastRefreshByValue.Text = lastRefreshedBy;
                truncateStringValue.Text = truncateString;
                if (isRefreshStatus)
                {
                    clearRefreshingApiButton.Enabled = true;
                    clearRefreshingApiLabel.Enabled = true;
                }
                eclipseGreenValue.Text = indicators[0];
                eclipseYellowValue.Text = indicators[1];
                eclipseRedValue.Text = indicators[2];
                complexityGreenValue.Text = indicators[3];
                complexityYellowValue.Text = indicators[4];
                complexityRedValue.Text = indicators[5];
                scheduleGreenValue.Text = indicators[6];
                scheduleYellowValue.Text = indicators[7];
                scheduleRedValue.Text = indicators[8];
                overallGreenValue.Text = indicators[9];
                overallYellowValue.Text = indicators[10];
                overallRedValue.Text = indicators[11];
            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }
        }

        private void SaveValues()
        {
            try
            {
                Linq2SqlProcessor.UpdateTruncateString(truncateStringValue.Text);
                List<string> indicators = new List<string>();
                indicators.AddRange(new List<string>
                {
                    eclipseGreenValue.Text,
                    eclipseYellowValue.Text,
                    eclipseRedValue.Text,
                    complexityGreenValue.Text,
                    complexityYellowValue.Text,
                    complexityRedValue.Text,
                    scheduleGreenValue.Text,
                    scheduleYellowValue.Text,
                    scheduleRedValue.Text,
                    overallGreenValue.Text,
                    overallYellowValue.Text,
                    overallRedValue.Text
                });
                Linq2SqlProcessor.UpdateIndicatorValues(indicators);
                MessageBox.Show("General configuration successfully saved.",
                    "Configuration Saved",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.None);
                this.Close();
            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
            }
        }

        private void clearRefreshingApiButton_Click(object sender, EventArgs e)
        {
            Linq2SqlProcessor.ChangeRefreshStatus(false);
            clearRefreshingApiButton.Enabled = false;
            clearRefreshingApiLabel.Enabled = false;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveValues();
            this.Close();
        }
    }
}
