using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Net.Http;
using EclipseCompanionModelLibrary;
using System.Diagnostics;

namespace EclipseCompanionControlLibrary
{
    public class ApiProjectProcessor
    {
        public static async Task<List<ProjectModel>> GetEclipseProjectIDsAsync()
        {
            List<ProjectModel> projects = new List<ProjectModel>();

            string url = ApiHelper.ApiClient.BaseAddress + $"/search/projects/{GlobalCode.IdForAllProjectsAPICall}" +
                $"?%24select=id%2C%20name%2C%20description%2C%20statusUpdate%2C%20projectOwnerId%2C%20priorityId%2C%20" +
                $"statusId%2C%20createdDate%2C%20modifiedDate%2C%20startDate%2C%20endDate%2C%20workComplete&%24orderBy=id";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    string body = await response.Content.ReadAsStringAsync();
                    dynamic bodyJson = JsonConvert.DeserializeObject(body);
                    foreach (dynamic item in bodyJson["value"])
                    {
                        ProjectModel p = new ProjectModel();
                        p.EclipseId = Convert.ToInt32(item.id);
                        p.Name = item.name;
                        p.Description = item.description;
                        p.FullStatusNotes = item.statusUpdate;
                        string truncateString = Linq2SqlProcessor.GetTruncateString();
                        if(p.FullStatusNotes != null && p.FullStatusNotes.Contains(truncateString))
                        {
                            p.ShortStatusNotes = p.FullStatusNotes.Split(new[] { truncateString }, StringSplitOptions.None)[0];
                        }
                        if (item.projectOwnerId != null)
                        {
                            p.ProjectOwnerId = Convert.ToInt32(item.projectOwnerId);
                        }
                        p.PriorityId = item.priorityId;
                        p.StatusId = item.statusId;
                        p.CreatedDate = Convert.ToDateTime(item.createdDate);
                        p.ModifiedDate = Convert.ToDateTime(item.modifiedDate);
                        p.StartDate = Convert.ToDateTime(item.startDate);
                        p.EndDate = Convert.ToDateTime(item.endDate);
                        p.PercentComplete = item.workComplete;
                        projects.Add(p);
                    }
                    return projects;
                }
                else
                {
                    MessageBox.Show($"API call to Ecipse to get IDs of projects failed: {response.ReasonPhrase}",
                        "Login Unsuccessful",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return null;
                }
            }
        }

        public static async Task<ProjectModel> GetProjectInfoAsync(ProjectModel project)
        {
            GlobalCode.CallsToApisForProjectData++;
            string url = ApiHelper.ApiClient.BaseAddress + $"/projects/{project.EclipseId}";
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    // Status and Indicators Processor
                    GlobalCode.CallsToApisForProjectData++;
                    url = ApiHelper.ApiClient.BaseAddress + $"/projects/{project.EclipseId}/statusupdates/current";
                    using (HttpResponseMessage statusresp = await ApiHelper.ApiClient.GetAsync(url))
                    {
                        if (statusresp.IsSuccessStatusCode)
                        {
                            string statusbody = await statusresp.Content.ReadAsStringAsync();
                            dynamic statusjson = JsonConvert.DeserializeObject(statusbody);
                            project.Status = statusjson["status"];
                            project.LastStatusDate = Convert.ToDateTime(statusjson["date"]);

                            List<ProjectModel.Indicator> indicatorList = new List<ProjectModel.Indicator>();
                            foreach (dynamic item in statusjson["healthIndicators"])
                            {
                                ProjectModel.Indicator indicator = new ProjectModel.Indicator();
                                indicator.Name = item.name;
                                indicator.StateId = item.state.id;
                                indicator.StateName = item.state.name;
                                indicatorList.Add(indicator);
                            }
                            project.ListOfStatusIndicators = indicatorList;

                        }
                        else
                        {
                            MessageBox.Show($"Failed: {statusresp.ReasonPhrase}");
                        }
                    }

                    if (project.ProjectOwnerId != null)
                    {
                        GlobalCode.CallsToApisForProjectData++;
                        url = ApiHelper.ApiClient.BaseAddress + $"/resources/{project.ProjectOwnerId}";
                        using (HttpResponseMessage ownerresp = await ApiHelper.ApiClient.GetAsync(url))
                        {
                            if (ownerresp.IsSuccessStatusCode)
                            {
                                string ownerbody = await ownerresp.Content.ReadAsStringAsync();
                                dynamic ownerjson = JsonConvert.DeserializeObject(ownerbody);
                                project.ProjectOwner = $"{ownerjson["firstName"]} {ownerjson["lastName"]}";
                            }
                            else
                            {
                                MessageBox.Show($"Failed: {ownerresp.ReasonPhrase}");
                            }
                        } 
                    }

                    // Priority Processor
                    GlobalCode.CallsToApisForProjectData++;
                    url = ApiHelper.ApiClient.BaseAddress + $"/configuration/project/priorities/{project.PriorityId}";
                    using (HttpResponseMessage priorityresp = await ApiHelper.ApiClient.GetAsync(url))
                    {
                        if (priorityresp.IsSuccessStatusCode)
                        {
                            string prioritybody = await priorityresp.Content.ReadAsStringAsync();
                            dynamic priorityjson = JsonConvert.DeserializeObject(prioritybody);
                            project.Priority = priorityjson["name"];
                            project.PrioritySortOrder = priorityjson["sortOrder"];
                        }
                        else
                        {
                            MessageBox.Show($"Failed: {priorityresp.ReasonPhrase}");
                        }
                    }

                    // StatusType Processor Part 1
                    GlobalCode.CallsToApisForProjectData++;
                    url = ApiHelper.ApiClient.BaseAddress + $"/configuration/project/statuses/{project.StatusId}";
                    using (HttpResponseMessage statustyperesp = await ApiHelper.ApiClient.GetAsync(url))
                    {
                        if (statustyperesp.IsSuccessStatusCode)
                        {
                            string statustypebody = await statustyperesp.Content.ReadAsStringAsync();
                            dynamic statustypejson = JsonConvert.DeserializeObject(statustypebody);
                            project.StatusTypeId = statustypejson["typeId"];
                            project.StatusSortOrder = statustypejson["sortOrder"];
                        }
                        else
                        {
                            MessageBox.Show($"Failed: {statustyperesp.ReasonPhrase}");
                        }
                    }

                    // StatusType Processor Part 2
                    GlobalCode.CallsToApisForProjectData++;
                    url = ApiHelper.ApiClient.BaseAddress + $"/configuration/project/statustypes/{project.StatusTypeId}";
                    using (HttpResponseMessage statustype2resp = await ApiHelper.ApiClient.GetAsync(url))
                    {
                        if (statustype2resp.IsSuccessStatusCode)
                        {
                            string statustype2body = await statustype2resp.Content.ReadAsStringAsync();
                            dynamic statustype2json = JsonConvert.DeserializeObject(statustype2body);
                            project.StatusType = statustype2json["name"];
                        }
                        else
                        {
                            MessageBox.Show($"Failed: {statustype2resp.ReasonPhrase}");
                        }
                    }

                    // Required to support no nulls in SQL using Linq-to-Sql
                    // These are the only fields in Eclipse that may be null
                    project.Description = project.Description == null ? "" : project.Description;
                    project.FullStatusNotes = project.FullStatusNotes == null ? "" : project.FullStatusNotes;
                    project.ShortStatusNotes = project.ShortStatusNotes == null ? "" : project.ShortStatusNotes;
                    project.ProjectOwner = project.ProjectOwner == null ? "" : project.ProjectOwner;

                    // return project to caller
                    return project;
                }
                else
                {
                    MessageBox.Show($"Failed: {response.ReasonPhrase}");
                    return null;
                }
            }
        }
    }
}
