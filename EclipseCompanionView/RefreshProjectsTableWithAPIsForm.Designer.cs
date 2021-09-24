
namespace EclipseCompanionView
{
    partial class RefreshProjectsTableWithAPIsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RefreshProjectsTableWithAPIsForm));
            this.refreshProjectsProgressBar = new System.Windows.Forms.ProgressBar();
            this.closeButton = new System.Windows.Forms.Button();
            this.cancelLoadButton = new System.Windows.Forms.Button();
            this.actionLabel = new System.Windows.Forms.Label();
            this.noticeLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // refreshProjectsProgressBar
            // 
            this.refreshProjectsProgressBar.Location = new System.Drawing.Point(40, 36);
            this.refreshProjectsProgressBar.Name = "refreshProjectsProgressBar";
            this.refreshProjectsProgressBar.Size = new System.Drawing.Size(481, 23);
            this.refreshProjectsProgressBar.TabIndex = 0;
            // 
            // closeButton
            // 
            this.closeButton.Enabled = false;
            this.closeButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.Location = new System.Drawing.Point(294, 97);
            this.closeButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(115, 38);
            this.closeButton.TabIndex = 5;
            this.closeButton.Text = "Close Window";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // cancelLoadButton
            // 
            this.cancelLoadButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelLoadButton.Location = new System.Drawing.Point(151, 97);
            this.cancelLoadButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cancelLoadButton.Name = "cancelLoadButton";
            this.cancelLoadButton.Size = new System.Drawing.Size(115, 38);
            this.cancelLoadButton.TabIndex = 4;
            this.cancelLoadButton.TabStop = false;
            this.cancelLoadButton.Text = "Cancel Load";
            this.cancelLoadButton.UseVisualStyleBackColor = true;
            this.cancelLoadButton.Click += new System.EventHandler(this.cancelLoadButton_Click);
            // 
            // actionLabel
            // 
            this.actionLabel.AutoSize = true;
            this.actionLabel.Location = new System.Drawing.Point(40, 66);
            this.actionLabel.Name = "actionLabel";
            this.actionLabel.Size = new System.Drawing.Size(97, 17);
            this.actionLabel.TabIndex = 6;
            this.actionLabel.Text = "<Action Label>";
            // 
            // noticeLabel
            // 
            this.noticeLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noticeLabel.ForeColor = System.Drawing.Color.Red;
            this.noticeLabel.Location = new System.Drawing.Point(20, 161);
            this.noticeLabel.Name = "noticeLabel";
            this.noticeLabel.Size = new System.Drawing.Size(521, 17);
            this.noticeLabel.TabIndex = 7;
            this.noticeLabel.Text = "Canceling the operation will result in no changes being made to the SQL tables.";
            this.noticeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RefreshProjectsTableWithAPIsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(560, 210);
            this.ControlBox = false;
            this.Controls.Add(this.noticeLabel);
            this.Controls.Add(this.actionLabel);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.cancelLoadButton);
            this.Controls.Add(this.refreshProjectsProgressBar);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RefreshProjectsTableWithAPIsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Refresh Projects Tables via API Calls";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar refreshProjectsProgressBar;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button cancelLoadButton;
        private System.Windows.Forms.Label actionLabel;
        private System.Windows.Forms.Label noticeLabel;
    }
}