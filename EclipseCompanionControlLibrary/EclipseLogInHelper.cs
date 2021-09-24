using EclipseCompanionModelLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EclipseCompanionControlLibrary
{
    public static class EclipseLogInHelper
    {
        public static bool LogIn(string eclipseUser, string eclipseSvcCredentials)
        {
            return AttemptToLogInToEclipse(eclipseUser, eclipseSvcCredentials);

            // local synchronous function
            bool AttemptToLogInToEclipse(string eU, string eSC)
            {
                string username = eU;
                string svcCredentials = eSC;
                bool loggedIn = false;

                ApiHelper.ApiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", svcCredentials);
                string url = ApiHelper.ApiClient.BaseAddress + $"/environments";

                using (HttpResponseMessage response = ApiHelper.ApiClient.GetAsync(url).Result) // we want this to be synchronous
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = response.Content.ReadAsStringAsync().Result;

                        // substring removes the brackets at the front and back of the response
                        GlobalCode.EclipseLogin = JsonConvert.DeserializeObject<EclipseLoginModel>(responseBody.Substring(1, responseBody.Length - 2));
                        GlobalCode.EclipseLogin.UserEmail = username;
                        loggedIn = (RetrieveUserInfo() && RetrieveUserAccessPolicy());
                    }
                    else if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        MessageBox.Show($"Action Not Authorized: {response.ReasonPhrase}");
                    }
                    else if (response.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        MessageBox.Show($"API call to Ecipse to get IDs of projects failed: {response.ReasonPhrase}",
                             "Login Unsuccessful",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        MessageBox.Show($"Unknown error: {response.ReasonPhrase}");
                    }

                }
                return loggedIn;
            }

            // Local function
            bool RetrieveUserInfo()
            {
                bool success = false;

                // call api to get list of all users (only relevant fields)
                string url = ApiHelper.ApiClient.BaseAddress + "/users";
                using (HttpResponseMessage response = ApiHelper.ApiClient.GetAsync(url).Result) // want this to be synchronous
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        List<EclipseUserModel> users = new List<EclipseUserModel>();

                        // iterate each user is json and add to list of users
                        dynamic deserializedJson = JsonConvert.DeserializeObject(responseBody);
                        foreach (var user in deserializedJson)
                        {
                            EclipseUserModel thisuser = new EclipseUserModel();
                            thisuser.ID = user["id"];
                            thisuser.FirstName = user["firstName"];
                            thisuser.LastName = user["lastName"];
                            thisuser.Email = user["email"];
                            thisuser.LastLogin = user["lastLogin"];
                            users.Add(thisuser);
                        }

                        // find user in list with matching email
                        foreach (EclipseUserModel user in users)
                        {
                            if (user.Email == GlobalCode.EclipseLogin.UserEmail)
                            {
                                GlobalCode.EclipseLogin.UserID = user.ID;
                                GlobalCode.EclipseLogin.UserFirstName = user.FirstName;
                                GlobalCode.EclipseLogin.UserLastName = user.LastName;
                                success = true;
                                break;
                            }
                        }
                    }
                    else if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        MessageBox.Show($"Action Not Authorized: {response.ReasonPhrase}");
                    }
                    else
                    {
                        MessageBox.Show($"Unknown error: {response.ReasonPhrase}");
                    }
                }
                return success;
            }

            // Local function
            bool RetrieveUserAccessPolicy()
            {
                bool success = false;

                string url = "";
                url = ApiHelper.ApiClient.BaseAddress + $"/users/{GlobalCode.EclipseLogin.UserID}/policies";
                using (HttpResponseMessage response = ApiHelper.ApiClient.GetAsync(url).Result) // we want this to be synchronous
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        dynamic deserializedJson = JsonConvert.DeserializeObject(responseBody);
                        GlobalCode.EclipseLogin.UserPolicyID = deserializedJson[0]["id"];
                        success = true;
                    }
                    else if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        MessageBox.Show($"Action to Authorized: {response.ReasonPhrase}");
                    }
                    else
                    {
                        MessageBox.Show($"Unknown error: {response.ReasonPhrase}");
                    }
                }
                return success;
            }
        }
    }
}
