using EclipseCompanionControlLibrary;
using EclipseCompanionModelLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EclipseCompanionView
{
    public partial class UserManagerForm : Form
    {

        private List<UserModel> users = new List<UserModel>();
        private UserModel user = new UserModel();
        
        public UserManagerForm()
        {
            InitializeComponent();
            PopulateUserComboBox();
            PopulateAccessLevelComboBox();
        }

        private void PopulateAccessLevelComboBox()
        {
            accessLevelComboBox.DataSource = null;
            Dictionary<string, string> accessLevelComboSource = new Dictionary<string, string>();
            foreach(AccessLevels level in Enum.GetValues(typeof(AccessLevels)))
            {
                accessLevelComboSource.Add(((int)level).ToString(), (level).ToString());
            }
            accessLevelComboBox.DataSource = new BindingSource(accessLevelComboSource, null);
            accessLevelComboBox.DisplayMember = "Value";
            accessLevelComboBox.ValueMember = "Key";
            accessLevelComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            accessLevelComboBox.SelectedIndex = -1;

        }

        private void PopulateUserComboBox()
        {
            usersComboBox.DataSource = null;
            users = Linq2SqlProcessor.RetrieveUsers();
            Dictionary<string, string> userComboSource = new Dictionary<string, string>();
            // I want a blank value always available, not just on initial display
            // of combo box
            userComboSource.Add("-1", $"");
            foreach (UserModel user in users)
            {
                userComboSource.Add(user.Id.ToString(), $"{user.LastName}, {user.FirstName}");
            }
            if (users.Any())
            {
                usersComboBox.DataSource = new BindingSource(userComboSource, null);
                usersComboBox.DisplayMember = "Value";
                usersComboBox.ValueMember = "Key";
            }
            usersComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void usersComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // When populating the first time, the selected index is 0; however,
            // when populating a second time, the selected index is -1. I think that's
            // because this event is triggered when the box is cleared (any update user after
            // initial population
            if (usersComboBox.SelectedIndex == 0 || usersComboBox.SelectedIndex == -1)
            {
                userDetailGroupBox.Enabled = false;
                ClearUserDetails();
            }
            else
            {
                userDetailGroupBox.Enabled = true;
                int itemKey = Convert.ToInt32(((KeyValuePair<string, string>)usersComboBox.SelectedItem).Key);
                user = users.Find(u => u.Id == itemKey);
                firstNameValue.Text = user.FirstName;
                lastNameValue.Text = user.LastName;
                loginIdValue.Text = user.UserLoginName;
                emailAddressValue.Text = user.EmailAddress;
                lastLoginValue.Text = Convert.ToString(user.LastLogin);
                lockedCheckBox.Checked = user.IsLocked;
                forcePasswordResetCheckbox.Checked = user.ForcePasswordChange;
                activeUserCheckbox.Checked = user.IsActive;
                accessLevelComboBox.SelectedIndex = accessLevelComboBox.FindString(Convert.ToString(user.AccessLevel));
            }
        }

        private void updateUserButton_Click(object sender, EventArgs e)
        {
            int itemKey = Convert.ToInt32(((KeyValuePair<string, string>)usersComboBox.SelectedItem).Key);
            UserModel user = users.Find(u => u.Id == itemKey);
            PopulateUserModel(ref user);
            Linq2SqlProcessor.AddUpdateUser(user, SqlAction.Update);
            MessageBox.Show($"{user.FirstName} {user.LastName} successfully updated.",
                "User Updated",
                MessageBoxButtons.OK,
                MessageBoxIcon.None);
           
            PopulateUserComboBox();
        }

        private void ClearUserDetails()
        {
            firstNameValue.Text = "";
            lastNameValue.Text = "";
            loginIdValue.Text = "";
            emailAddressValue.Text = "";
            lastLoginValue.Text = "";
            lockedCheckBox.Checked = false;
            forcePasswordResetCheckbox.Checked = false;
            activeUserCheckbox.Checked = false;
            accessLevelComboBox.SelectedIndex = -1;
        }

        private void PopulateUserModel(ref UserModel user)
        {
            user.FirstName = firstNameValue.Text;
            user.LastName = lastNameValue.Text;
            user.UserLoginName = loginIdValue.Text;
            user.EmailAddress = emailAddressValue.Text;
            user.AccessLevel = (AccessLevels)Enum.Parse(typeof(AccessLevels), accessLevelComboBox.SelectedValue.ToString());
            user.IsActive = activeUserCheckbox.Checked;
            user.IsLocked = lockedCheckBox.Checked;
            user.ForcePasswordChange = forcePasswordResetCheckbox.Checked;
        }

        private void addNewUserButton_Click(object sender, EventArgs e)
        {
            //TODO ensure users combo box is refreshed after adding
            userDetailGroupBox.Enabled = true;
            addNewUserButton.Enabled = false;
            resetPasswordButton.Enabled = false;
            usersComboBox.Enabled = false;
            updateUserButton.Hide();
            addUserButton.Show();
            ClearUserDetails();
        }

        private void resetPasswordButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"Are you sure you want to reset {user.FirstName} {user.LastName}'s password to {GlobalCode.DefaultPassword}?",
                "Please Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Hand);
            if(result == DialogResult.Yes)
            {
                Linq2SqlProcessor.ChangePassword(user.Id, GlobalCode.SHA256Hash(GlobalCode.DefaultPassword));
                MessageBox.Show("Password successfully reset.", "Success");
            }
        }

        private void addUserButton_Click(object sender, EventArgs e)
        {
            if(firstNameValue.Text == "" || lastNameValue.Text == "" || loginIdValue.Text == "" || 
                emailAddressValue.Text == "" || accessLevelComboBox.SelectedIndex < 0)
            {
                MessageBox.Show("First Name, Last Name, User Login ID, Email Address, and " +
                    "Access Level cannot be blank. Please check your entries.",
                    "Incomplete Data");
            } else
            {
                UserModel user = new UserModel();
                PopulateUserModel(ref user);

                Linq2SqlProcessor.AddUpdateUser(user, SqlAction.Add, GlobalCode.SHA256Hash(GlobalCode.DefaultPassword));
                MessageBox.Show($"{user.FirstName} {user.LastName} successfully added.",
                    "User Added",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.None);

                addUserButton.Hide();
                updateUserButton.Show();
                resetPasswordButton.Enabled = true;
                addNewUserButton.Enabled = true;
                usersComboBox.Enabled = true;

                PopulateUserComboBox();
            }
        }
    }
}
