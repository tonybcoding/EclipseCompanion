using EclipseCompanionControlLibrary;
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
    public partial class ChangePasswordForm : Form
    {
        public int userSqlId { get; set; }

        public ChangePasswordForm(int id)
        {
            InitializeComponent();
            userSqlId = id;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {

            if(newValue.Text == confirmValue.Text && GlobalCode.SHA256Hash(oldValue.Text) == Linq2SqlProcessor.RetrievePassword(userSqlId))
            {
                Linq2SqlProcessor.ChangePassword(userSqlId, GlobalCode.SHA256Hash(newValue.Text));
                MessageBox.Show("Password was successfully changed.",
                    "Password Changed");
                this.Close();
            }
            else
            {
                MessageBox.Show("Either the old password is incorrect or the new/confirm values are different. Please check your entries and try again", 
                    "Data Invalid",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
