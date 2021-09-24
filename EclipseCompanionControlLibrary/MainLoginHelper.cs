using EclipseCompanionModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EclipseCompanionControlLibrary
{
    public static class MainLoginHelper
    {
        
        // TODO: add ability to
        // indicate if first loggin in. If so, require password change
        // have flag to log/unlock account
        public static bool Login(string mainUser, string mainPassword)
        {
            try
            {
                SQLDataClassesDataContext dbContext = new SQLDataClassesDataContext(GlobalCode.ConnectionString);
                var user = dbContext.Users.SingleOrDefault(u => u.EmailAddress == mainUser && u.Password == mainPassword);
                if (user == null)
                {
                    MessageBox.Show($"Wrong username or password entered. Please try again.",
                            "Login Unsuccessful",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Asterisk);
                    return false;
                }
                else
                {
                    GlobalCode.MainLogin.AccessLevel = (AccessLevels)user.AccessLevel;
                    GlobalCode.MainLogin.Id = user.id;
                    GlobalCode.MainLogin.UserName = user.EmailAddress;
                    GlobalCode.MainLogin.FirstName = user.FirstName;
                    GlobalCode.MainLogin.LastName = user.LastName;
                    // set last login column in sql table to now
                    user.LastLogIn = DateTime.Now;
                    dbContext.SubmitChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                GlobalCode.ExceptionHandler(ex);
                return false;
            }
        }
    }
}
