
namespace EclipseCompanionView
{
    partial class GeneralConfigForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GeneralConfigForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.apiTrackingIndicatorsGroupBox = new System.Windows.Forms.GroupBox();
            this.truncateStringValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.clearRefreshingApiLabel = new System.Windows.Forms.Label();
            this.clearRefreshingApiButton = new System.Windows.Forms.Button();
            this.lastRefreshByValue = new System.Windows.Forms.TextBox();
            this.lastRefreshDateValue = new System.Windows.Forms.TextBox();
            this.projectHealthIndicatorsGroupBox = new System.Windows.Forms.GroupBox();
            this.overallRedValue = new System.Windows.Forms.TextBox();
            this.overallYellowValue = new System.Windows.Forms.TextBox();
            this.overallGreenValue = new System.Windows.Forms.TextBox();
            this.scheduleRedValue = new System.Windows.Forms.TextBox();
            this.scheduleYellowValue = new System.Windows.Forms.TextBox();
            this.scheduleGreenValue = new System.Windows.Forms.TextBox();
            this.complexityRedValue = new System.Windows.Forms.TextBox();
            this.complexityYellowValue = new System.Windows.Forms.TextBox();
            this.complexityGreenValue = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.eclipseRedValue = new System.Windows.Forms.TextBox();
            this.eclipseYellowValue = new System.Windows.Forms.TextBox();
            this.eclipseGreenValue = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.apiTrackingIndicatorsGroupBox.SuspendLayout();
            this.projectHealthIndicatorsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Last Refresh with API calls :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(399, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "By :";
            // 
            // apiTrackingIndicatorsGroupBox
            // 
            this.apiTrackingIndicatorsGroupBox.Controls.Add(this.truncateStringValue);
            this.apiTrackingIndicatorsGroupBox.Controls.Add(this.label3);
            this.apiTrackingIndicatorsGroupBox.Controls.Add(this.clearRefreshingApiLabel);
            this.apiTrackingIndicatorsGroupBox.Controls.Add(this.clearRefreshingApiButton);
            this.apiTrackingIndicatorsGroupBox.Controls.Add(this.lastRefreshByValue);
            this.apiTrackingIndicatorsGroupBox.Controls.Add(this.lastRefreshDateValue);
            this.apiTrackingIndicatorsGroupBox.Controls.Add(this.label1);
            this.apiTrackingIndicatorsGroupBox.Controls.Add(this.label2);
            this.apiTrackingIndicatorsGroupBox.Location = new System.Drawing.Point(19, 25);
            this.apiTrackingIndicatorsGroupBox.Name = "apiTrackingIndicatorsGroupBox";
            this.apiTrackingIndicatorsGroupBox.Size = new System.Drawing.Size(623, 113);
            this.apiTrackingIndicatorsGroupBox.TabIndex = 3;
            this.apiTrackingIndicatorsGroupBox.TabStop = false;
            // 
            // truncateStringValue
            // 
            this.truncateStringValue.Location = new System.Drawing.Point(533, 66);
            this.truncateStringValue.Name = "truncateStringValue";
            this.truncateStringValue.Size = new System.Drawing.Size(67, 25);
            this.truncateStringValue.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(426, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "Truncate String :";
            // 
            // clearRefreshingApiLabel
            // 
            this.clearRefreshingApiLabel.AutoSize = true;
            this.clearRefreshingApiLabel.Enabled = false;
            this.clearRefreshingApiLabel.Location = new System.Drawing.Point(20, 70);
            this.clearRefreshingApiLabel.Name = "clearRefreshingApiLabel";
            this.clearRefreshingApiLabel.Size = new System.Drawing.Size(312, 17);
            this.clearRefreshingApiLabel.TabIndex = 14;
            this.clearRefreshingApiLabel.Text = "Clear API Refreshing Flag (only enabled if flag is set)";
            // 
            // clearRefreshingApiButton
            // 
            this.clearRefreshingApiButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.clearRefreshingApiButton.Enabled = false;
            this.clearRefreshingApiButton.Location = new System.Drawing.Point(336, 65);
            this.clearRefreshingApiButton.Name = "clearRefreshingApiButton";
            this.clearRefreshingApiButton.Size = new System.Drawing.Size(70, 27);
            this.clearRefreshingApiButton.TabIndex = 13;
            this.clearRefreshingApiButton.Text = "Clear";
            this.clearRefreshingApiButton.UseVisualStyleBackColor = true;
            this.clearRefreshingApiButton.Click += new System.EventHandler(this.clearRefreshingApiButton_Click);
            // 
            // lastRefreshByValue
            // 
            this.lastRefreshByValue.Location = new System.Drawing.Point(433, 25);
            this.lastRefreshByValue.Name = "lastRefreshByValue";
            this.lastRefreshByValue.ReadOnly = true;
            this.lastRefreshByValue.Size = new System.Drawing.Size(167, 25);
            this.lastRefreshByValue.TabIndex = 4;
            // 
            // lastRefreshDateValue
            // 
            this.lastRefreshDateValue.Location = new System.Drawing.Point(191, 25);
            this.lastRefreshDateValue.Name = "lastRefreshDateValue";
            this.lastRefreshDateValue.ReadOnly = true;
            this.lastRefreshDateValue.Size = new System.Drawing.Size(184, 25);
            this.lastRefreshDateValue.TabIndex = 3;
            // 
            // projectHealthIndicatorsGroupBox
            // 
            this.projectHealthIndicatorsGroupBox.Controls.Add(this.overallRedValue);
            this.projectHealthIndicatorsGroupBox.Controls.Add(this.overallYellowValue);
            this.projectHealthIndicatorsGroupBox.Controls.Add(this.overallGreenValue);
            this.projectHealthIndicatorsGroupBox.Controls.Add(this.scheduleRedValue);
            this.projectHealthIndicatorsGroupBox.Controls.Add(this.scheduleYellowValue);
            this.projectHealthIndicatorsGroupBox.Controls.Add(this.scheduleGreenValue);
            this.projectHealthIndicatorsGroupBox.Controls.Add(this.complexityRedValue);
            this.projectHealthIndicatorsGroupBox.Controls.Add(this.complexityYellowValue);
            this.projectHealthIndicatorsGroupBox.Controls.Add(this.complexityGreenValue);
            this.projectHealthIndicatorsGroupBox.Controls.Add(this.label11);
            this.projectHealthIndicatorsGroupBox.Controls.Add(this.label10);
            this.projectHealthIndicatorsGroupBox.Controls.Add(this.label9);
            this.projectHealthIndicatorsGroupBox.Controls.Add(this.eclipseRedValue);
            this.projectHealthIndicatorsGroupBox.Controls.Add(this.eclipseYellowValue);
            this.projectHealthIndicatorsGroupBox.Controls.Add(this.eclipseGreenValue);
            this.projectHealthIndicatorsGroupBox.Controls.Add(this.label8);
            this.projectHealthIndicatorsGroupBox.Controls.Add(this.label7);
            this.projectHealthIndicatorsGroupBox.Controls.Add(this.label6);
            this.projectHealthIndicatorsGroupBox.Controls.Add(this.label5);
            this.projectHealthIndicatorsGroupBox.Controls.Add(this.label4);
            this.projectHealthIndicatorsGroupBox.Location = new System.Drawing.Point(19, 150);
            this.projectHealthIndicatorsGroupBox.Name = "projectHealthIndicatorsGroupBox";
            this.projectHealthIndicatorsGroupBox.Size = new System.Drawing.Size(623, 274);
            this.projectHealthIndicatorsGroupBox.TabIndex = 4;
            this.projectHealthIndicatorsGroupBox.TabStop = false;
            this.projectHealthIndicatorsGroupBox.Text = "Project Health Indicators";
            // 
            // overallRedValue
            // 
            this.overallRedValue.Location = new System.Drawing.Point(485, 223);
            this.overallRedValue.Name = "overallRedValue";
            this.overallRedValue.Size = new System.Drawing.Size(94, 25);
            this.overallRedValue.TabIndex = 31;
            // 
            // overallYellowValue
            // 
            this.overallYellowValue.Location = new System.Drawing.Point(355, 223);
            this.overallYellowValue.Name = "overallYellowValue";
            this.overallYellowValue.Size = new System.Drawing.Size(94, 25);
            this.overallYellowValue.TabIndex = 30;
            // 
            // overallGreenValue
            // 
            this.overallGreenValue.Location = new System.Drawing.Point(225, 223);
            this.overallGreenValue.Name = "overallGreenValue";
            this.overallGreenValue.Size = new System.Drawing.Size(94, 25);
            this.overallGreenValue.TabIndex = 29;
            // 
            // scheduleRedValue
            // 
            this.scheduleRedValue.Location = new System.Drawing.Point(485, 182);
            this.scheduleRedValue.Name = "scheduleRedValue";
            this.scheduleRedValue.Size = new System.Drawing.Size(94, 25);
            this.scheduleRedValue.TabIndex = 28;
            // 
            // scheduleYellowValue
            // 
            this.scheduleYellowValue.Location = new System.Drawing.Point(355, 182);
            this.scheduleYellowValue.Name = "scheduleYellowValue";
            this.scheduleYellowValue.Size = new System.Drawing.Size(94, 25);
            this.scheduleYellowValue.TabIndex = 27;
            // 
            // scheduleGreenValue
            // 
            this.scheduleGreenValue.Location = new System.Drawing.Point(225, 182);
            this.scheduleGreenValue.Name = "scheduleGreenValue";
            this.scheduleGreenValue.Size = new System.Drawing.Size(94, 25);
            this.scheduleGreenValue.TabIndex = 26;
            // 
            // complexityRedValue
            // 
            this.complexityRedValue.Location = new System.Drawing.Point(485, 141);
            this.complexityRedValue.Name = "complexityRedValue";
            this.complexityRedValue.Size = new System.Drawing.Size(94, 25);
            this.complexityRedValue.TabIndex = 25;
            // 
            // complexityYellowValue
            // 
            this.complexityYellowValue.Location = new System.Drawing.Point(355, 141);
            this.complexityYellowValue.Name = "complexityYellowValue";
            this.complexityYellowValue.Size = new System.Drawing.Size(94, 25);
            this.complexityYellowValue.TabIndex = 24;
            // 
            // complexityGreenValue
            // 
            this.complexityGreenValue.Location = new System.Drawing.Point(225, 141);
            this.complexityGreenValue.Name = "complexityGreenValue";
            this.complexityGreenValue.Size = new System.Drawing.Size(94, 25);
            this.complexityGreenValue.TabIndex = 23;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(23, 227);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(138, 17);
            this.label11.TabIndex = 22;
            this.label11.Text = "Overall Health Values :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(23, 186);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(108, 17);
            this.label10.TabIndex = 21;
            this.label10.Text = "Schedule Values :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(23, 145);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 17);
            this.label9.TabIndex = 20;
            this.label9.Text = "Complexity Values :";
            // 
            // eclipseRedValue
            // 
            this.eclipseRedValue.Location = new System.Drawing.Point(485, 59);
            this.eclipseRedValue.Name = "eclipseRedValue";
            this.eclipseRedValue.Size = new System.Drawing.Size(94, 25);
            this.eclipseRedValue.TabIndex = 19;
            // 
            // eclipseYellowValue
            // 
            this.eclipseYellowValue.Location = new System.Drawing.Point(355, 59);
            this.eclipseYellowValue.Name = "eclipseYellowValue";
            this.eclipseYellowValue.Size = new System.Drawing.Size(94, 25);
            this.eclipseYellowValue.TabIndex = 18;
            // 
            // eclipseGreenValue
            // 
            this.eclipseGreenValue.Location = new System.Drawing.Point(225, 59);
            this.eclipseGreenValue.Name = "eclipseGreenValue";
            this.eclipseGreenValue.Size = new System.Drawing.Size(94, 25);
            this.eclipseGreenValue.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(56, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 17);
            this.label8.TabIndex = 5;
            this.label8.Text = "Convert To";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(500, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 17);
            this.label7.TabIndex = 4;
            this.label7.Text = "Red/Alert";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(351, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 17);
            this.label6.TabIndex = 3;
            this.label6.Text = "Yellow/Warning";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(224, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "Green/Healthy";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Eclipse Generic Values :";
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cancelButton.Location = new System.Drawing.Point(340, 437);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(94, 35);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.saveButton.Location = new System.Drawing.Point(229, 437);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(94, 35);
            this.saveButton.TabIndex = 7;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // GeneralConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(662, 486);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.projectHealthIndicatorsGroupBox);
            this.Controls.Add(this.apiTrackingIndicatorsGroupBox);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GeneralConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "General Configuration";
            this.apiTrackingIndicatorsGroupBox.ResumeLayout(false);
            this.apiTrackingIndicatorsGroupBox.PerformLayout();
            this.projectHealthIndicatorsGroupBox.ResumeLayout(false);
            this.projectHealthIndicatorsGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox apiTrackingIndicatorsGroupBox;
        private System.Windows.Forms.TextBox lastRefreshByValue;
        private System.Windows.Forms.TextBox lastRefreshDateValue;
        private System.Windows.Forms.GroupBox projectHealthIndicatorsGroupBox;
        private System.Windows.Forms.Label clearRefreshingApiLabel;
        private System.Windows.Forms.Button clearRefreshingApiButton;
        private System.Windows.Forms.TextBox truncateStringValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox overallRedValue;
        private System.Windows.Forms.TextBox overallYellowValue;
        private System.Windows.Forms.TextBox overallGreenValue;
        private System.Windows.Forms.TextBox scheduleRedValue;
        private System.Windows.Forms.TextBox scheduleYellowValue;
        private System.Windows.Forms.TextBox scheduleGreenValue;
        private System.Windows.Forms.TextBox complexityRedValue;
        private System.Windows.Forms.TextBox complexityYellowValue;
        private System.Windows.Forms.TextBox complexityGreenValue;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox eclipseRedValue;
        private System.Windows.Forms.TextBox eclipseYellowValue;
        private System.Windows.Forms.TextBox eclipseGreenValue;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}