
namespace EclipseCompanionView
{
    partial class UserManagerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserManagerForm));
            this.label1 = new System.Windows.Forms.Label();
            this.usersComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.accessLevelComboBox = new System.Windows.Forms.ComboBox();
            this.resetPasswordButton = new System.Windows.Forms.Button();
            this.updateUserButton = new System.Windows.Forms.Button();
            this.addNewUserButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.userDetailGroupBox = new System.Windows.Forms.GroupBox();
            this.activeUserCheckbox = new System.Windows.Forms.CheckBox();
            this.lastLoginValue = new System.Windows.Forms.TextBox();
            this.emailAddressValue = new System.Windows.Forms.TextBox();
            this.loginIdValue = new System.Windows.Forms.TextBox();
            this.lastNameValue = new System.Windows.Forms.TextBox();
            this.firstNameValue = new System.Windows.Forms.TextBox();
            this.forcePasswordResetCheckbox = new System.Windows.Forms.CheckBox();
            this.lockedCheckBox = new System.Windows.Forms.CheckBox();
            this.addUserButton = new System.Windows.Forms.Button();
            this.userDetailGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Users :";
            // 
            // usersComboBox
            // 
            this.usersComboBox.FormattingEnabled = true;
            this.usersComboBox.Location = new System.Drawing.Point(105, 27);
            this.usersComboBox.Name = "usersComboBox";
            this.usersComboBox.Size = new System.Drawing.Size(254, 25);
            this.usersComboBox.TabIndex = 1;
            this.usersComboBox.SelectedIndexChanged += new System.EventHandler(this.usersComboBox_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "First Name :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(270, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Last Name :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(270, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Email Address :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "User Login ID :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "Access Level :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(270, 138);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 17);
            this.label9.TabIndex = 9;
            this.label9.Text = "Last Login :";
            // 
            // accessLevelComboBox
            // 
            this.accessLevelComboBox.FormattingEnabled = true;
            this.accessLevelComboBox.Location = new System.Drawing.Point(117, 134);
            this.accessLevelComboBox.Name = "accessLevelComboBox";
            this.accessLevelComboBox.Size = new System.Drawing.Size(116, 25);
            this.accessLevelComboBox.TabIndex = 10;
            // 
            // resetPasswordButton
            // 
            this.resetPasswordButton.Location = new System.Drawing.Point(154, 226);
            this.resetPasswordButton.Name = "resetPasswordButton";
            this.resetPasswordButton.Size = new System.Drawing.Size(109, 35);
            this.resetPasswordButton.TabIndex = 11;
            this.resetPasswordButton.Text = "Reset Password";
            this.resetPasswordButton.UseVisualStyleBackColor = true;
            this.resetPasswordButton.Click += new System.EventHandler(this.resetPasswordButton_Click);
            // 
            // updateUserButton
            // 
            this.updateUserButton.Location = new System.Drawing.Point(280, 226);
            this.updateUserButton.Name = "updateUserButton";
            this.updateUserButton.Size = new System.Drawing.Size(109, 35);
            this.updateUserButton.TabIndex = 12;
            this.updateUserButton.Text = "Update User";
            this.updateUserButton.UseVisualStyleBackColor = true;
            this.updateUserButton.Click += new System.EventHandler(this.updateUserButton_Click);
            // 
            // addNewUserButton
            // 
            this.addNewUserButton.Location = new System.Drawing.Point(395, 25);
            this.addNewUserButton.Name = "addNewUserButton";
            this.addNewUserButton.Size = new System.Drawing.Size(109, 29);
            this.addNewUserButton.TabIndex = 13;
            this.addNewUserButton.Text = "Add New User";
            this.addNewUserButton.UseVisualStyleBackColor = true;
            this.addNewUserButton.Click += new System.EventHandler(this.addNewUserButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(230, 362);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(109, 35);
            this.closeButton.TabIndex = 14;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // userDetailGroupBox
            // 
            this.userDetailGroupBox.Controls.Add(this.addUserButton);
            this.userDetailGroupBox.Controls.Add(this.activeUserCheckbox);
            this.userDetailGroupBox.Controls.Add(this.lastLoginValue);
            this.userDetailGroupBox.Controls.Add(this.emailAddressValue);
            this.userDetailGroupBox.Controls.Add(this.loginIdValue);
            this.userDetailGroupBox.Controls.Add(this.lastNameValue);
            this.userDetailGroupBox.Controls.Add(this.firstNameValue);
            this.userDetailGroupBox.Controls.Add(this.forcePasswordResetCheckbox);
            this.userDetailGroupBox.Controls.Add(this.lockedCheckBox);
            this.userDetailGroupBox.Controls.Add(this.updateUserButton);
            this.userDetailGroupBox.Controls.Add(this.resetPasswordButton);
            this.userDetailGroupBox.Controls.Add(this.accessLevelComboBox);
            this.userDetailGroupBox.Controls.Add(this.label9);
            this.userDetailGroupBox.Controls.Add(this.label6);
            this.userDetailGroupBox.Controls.Add(this.label5);
            this.userDetailGroupBox.Controls.Add(this.label4);
            this.userDetailGroupBox.Controls.Add(this.label3);
            this.userDetailGroupBox.Controls.Add(this.label2);
            this.userDetailGroupBox.Enabled = false;
            this.userDetailGroupBox.Location = new System.Drawing.Point(12, 71);
            this.userDetailGroupBox.Name = "userDetailGroupBox";
            this.userDetailGroupBox.Size = new System.Drawing.Size(543, 281);
            this.userDetailGroupBox.TabIndex = 15;
            this.userDetailGroupBox.TabStop = false;
            this.userDetailGroupBox.Text = "User Information";
            // 
            // activeUserCheckbox
            // 
            this.activeUserCheckbox.AutoSize = true;
            this.activeUserCheckbox.Location = new System.Drawing.Point(359, 183);
            this.activeUserCheckbox.Name = "activeUserCheckbox";
            this.activeUserCheckbox.Size = new System.Drawing.Size(90, 21);
            this.activeUserCheckbox.TabIndex = 22;
            this.activeUserCheckbox.Text = "Active user";
            this.activeUserCheckbox.UseVisualStyleBackColor = true;
            // 
            // lastLoginValue
            // 
            this.lastLoginValue.Location = new System.Drawing.Point(386, 134);
            this.lastLoginValue.Name = "lastLoginValue";
            this.lastLoginValue.ReadOnly = true;
            this.lastLoginValue.Size = new System.Drawing.Size(141, 25);
            this.lastLoginValue.TabIndex = 21;
            this.lastLoginValue.TabStop = false;
            // 
            // emailAddressValue
            // 
            this.emailAddressValue.Location = new System.Drawing.Point(383, 85);
            this.emailAddressValue.Name = "emailAddressValue";
            this.emailAddressValue.Size = new System.Drawing.Size(144, 25);
            this.emailAddressValue.TabIndex = 20;
            // 
            // loginIdValue
            // 
            this.loginIdValue.Location = new System.Drawing.Point(117, 85);
            this.loginIdValue.Name = "loginIdValue";
            this.loginIdValue.Size = new System.Drawing.Size(116, 25);
            this.loginIdValue.TabIndex = 19;
            // 
            // lastNameValue
            // 
            this.lastNameValue.Location = new System.Drawing.Point(383, 36);
            this.lastNameValue.Name = "lastNameValue";
            this.lastNameValue.Size = new System.Drawing.Size(144, 25);
            this.lastNameValue.TabIndex = 18;
            // 
            // firstNameValue
            // 
            this.firstNameValue.Location = new System.Drawing.Point(117, 36);
            this.firstNameValue.Name = "firstNameValue";
            this.firstNameValue.Size = new System.Drawing.Size(116, 25);
            this.firstNameValue.TabIndex = 17;
            // 
            // forcePasswordResetCheckbox
            // 
            this.forcePasswordResetCheckbox.AutoSize = true;
            this.forcePasswordResetCheckbox.Location = new System.Drawing.Point(184, 183);
            this.forcePasswordResetCheckbox.Name = "forcePasswordResetCheckbox";
            this.forcePasswordResetCheckbox.Size = new System.Drawing.Size(153, 21);
            this.forcePasswordResetCheckbox.TabIndex = 16;
            this.forcePasswordResetCheckbox.Text = "Force password reset";
            this.forcePasswordResetCheckbox.UseVisualStyleBackColor = true;
            // 
            // lockedCheckBox
            // 
            this.lockedCheckBox.AutoSize = true;
            this.lockedCheckBox.Location = new System.Drawing.Point(94, 183);
            this.lockedCheckBox.Name = "lockedCheckBox";
            this.lockedCheckBox.Size = new System.Drawing.Size(68, 21);
            this.lockedCheckBox.TabIndex = 15;
            this.lockedCheckBox.Text = "Locked";
            this.lockedCheckBox.UseVisualStyleBackColor = true;
            // 
            // addUserButton
            // 
            this.addUserButton.Location = new System.Drawing.Point(280, 226);
            this.addUserButton.Name = "addUserButton";
            this.addUserButton.Size = new System.Drawing.Size(109, 35);
            this.addUserButton.TabIndex = 23;
            this.addUserButton.Text = "Add User";
            this.addUserButton.UseVisualStyleBackColor = true;
            this.addUserButton.Visible = false;
            this.addUserButton.Click += new System.EventHandler(this.addUserButton_Click);
            // 
            // UserManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(567, 406);
            this.Controls.Add(this.userDetailGroupBox);
            this.Controls.Add(this.addNewUserButton);
            this.Controls.Add(this.usersComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.closeButton);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserManagerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "User Manager";
            this.userDetailGroupBox.ResumeLayout(false);
            this.userDetailGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox usersComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox accessLevelComboBox;
        private System.Windows.Forms.Button resetPasswordButton;
        private System.Windows.Forms.Button updateUserButton;
        private System.Windows.Forms.Button addNewUserButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.GroupBox userDetailGroupBox;
        private System.Windows.Forms.TextBox lastLoginValue;
        private System.Windows.Forms.TextBox emailAddressValue;
        private System.Windows.Forms.TextBox loginIdValue;
        private System.Windows.Forms.TextBox lastNameValue;
        private System.Windows.Forms.TextBox firstNameValue;
        private System.Windows.Forms.CheckBox forcePasswordResetCheckbox;
        private System.Windows.Forms.CheckBox lockedCheckBox;
        private System.Windows.Forms.CheckBox activeUserCheckbox;
        private System.Windows.Forms.Button addUserButton;
    }
}