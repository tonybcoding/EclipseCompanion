
namespace EclipseCompanionView
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.eclipseUserNameLabel = new System.Windows.Forms.Label();
            this.eclipsePasswordLabel = new System.Windows.Forms.Label();
            this.userNameValue = new System.Windows.Forms.TextBox();
            this.passwordValue = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // eclipseUserNameLabel
            // 
            this.eclipseUserNameLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.eclipseUserNameLabel.Location = new System.Drawing.Point(27, 36);
            this.eclipseUserNameLabel.Name = "eclipseUserNameLabel";
            this.eclipseUserNameLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.eclipseUserNameLabel.Size = new System.Drawing.Size(156, 17);
            this.eclipseUserNameLabel.TabIndex = 0;
            this.eclipseUserNameLabel.Text = "<username>";
            this.eclipseUserNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // eclipsePasswordLabel
            // 
            this.eclipsePasswordLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.eclipsePasswordLabel.Location = new System.Drawing.Point(27, 76);
            this.eclipsePasswordLabel.Name = "eclipsePasswordLabel";
            this.eclipsePasswordLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.eclipsePasswordLabel.Size = new System.Drawing.Size(156, 17);
            this.eclipsePasswordLabel.TabIndex = 1;
            this.eclipsePasswordLabel.Text = "<password>";
            this.eclipsePasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // userNameValue
            // 
            this.userNameValue.Location = new System.Drawing.Point(189, 32);
            this.userNameValue.Name = "userNameValue";
            this.userNameValue.Size = new System.Drawing.Size(190, 25);
            this.userNameValue.TabIndex = 2;
            // 
            // passwordValue
            // 
            this.passwordValue.Location = new System.Drawing.Point(189, 72);
            this.passwordValue.Name = "passwordValue";
            this.passwordValue.PasswordChar = '*';
            this.passwordValue.Size = new System.Drawing.Size(190, 25);
            this.passwordValue.TabIndex = 3;
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(127, 131);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 35);
            this.okButton.TabIndex = 4;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(226, 131);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 35);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(428, 191);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.passwordValue);
            this.Controls.Add(this.userNameValue);
            this.Controls.Add(this.eclipsePasswordLabel);
            this.Controls.Add(this.eclipseUserNameLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Log in";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label eclipseUserNameLabel;
        private System.Windows.Forms.Label eclipsePasswordLabel;
        private System.Windows.Forms.TextBox userNameValue;
        private System.Windows.Forms.TextBox passwordValue;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
    }
}