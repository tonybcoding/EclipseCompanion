using EclipseCompanionControlLibrary;
using EclipseCompanionModelLibrary;
using System;
using System.Text;
using System.Windows.Forms;

namespace EclipseCompanionView
{
    public partial class LoginForm : Form
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EclipseServiceCredentials { get; set; }
        public LoginTo LogInToWhat { get; set; }

        public LoginForm(LoginTo loginTo)
        {
            LogInToWhat = loginTo;
            InitializeComponent();

            if (LogInToWhat == LoginTo.Eclipse)
            {
                this.Text = "Log in to Eclipse";
                eclipseUserNameLabel.Text = "Eclipse Email :";
                eclipsePasswordLabel.Text = "Eclipse Password :";

                // TODO: look up GlobalCode.MainUsers Id to get email address and
                // pre-populate userNameValue

            }
            else if (LogInToWhat == LoginTo.Main)
            {
                this.Text = "Log in to Eclipse Companion";
                eclipseUserNameLabel.Text = "User Name :";
                eclipsePasswordLabel.Text = "Password :";
            }
            this.ActiveControl = userNameValue;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.UserName = userNameValue.Text;
            if (this.LogInToWhat == LoginTo.Main)
            {
                // our own encryption method
                this.Password = GlobalCode.SHA256Hash(passwordValue.Text);
            }
            else if (this.LogInToWhat == LoginTo.Eclipse)
            {
                // Eclipse-required encryption for API call
                this.EclipseServiceCredentials = Convert.ToBase64String(
                    ASCIIEncoding.ASCII.GetBytes(
                    $"{this.userNameValue.Text}:{this.passwordValue.Text}"));
            }
            this.Close();
        }
    }
}
