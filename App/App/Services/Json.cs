﻿using App.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace App.Services
{
    class Json
    {
        #region Login Json Methods
        public static LoginTokenResult GetLoginToken(string username, string password)
        {
            HttpClient client = new HttpClient()
            {
                BaseAddress = new Uri(Constants.hostUrl)
            };
            HttpResponseMessage response =
        client.PostAsync("Token",
          new StringContent(string.Format("grant_type=password&username={0}&password={1}",
            username,
            password,
            "application/x-www-form-urlencoded"))).Result;
            string resultJSON = response.Content.ReadAsStringAsync().Result;
            LoginTokenResult result = Newtonsoft.Json.JsonConvert.DeserializeObject<LoginTokenResult>(resultJSON);
            return result;
        }
        #endregion

        #region Visits Request
        private static async Task<List<Visit>> GetData(string _username)
        {
            List<Visit> visitdata = new List<Visit>();
            string connected = await Plugin.Connectivity.CrossConnectivity.Current.
                IsRemoteReachable(Constants.baseUrl, Constants.port) ? "Reachable" : "Not reachable";

            if (connected == "Reachable")
            {
                var request_httpclient = new HttpClient();
                var request_postData = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("UserName", _username)
                    };
                var request_formContent = new FormUrlEncodedContent(request_postData);
                var request_response = await request_httpclient.PostAsync(Constants.Json_link_request,
                                request_formContent);
                var request_result = await request_response.Content.ReadAsStreamAsync();
                var request_streamReader = new System.IO.StreamReader(request_result);
                var request_responseContent = request_streamReader.ReadToEnd().Trim().ToString();
                var request_visit = JArray.Parse(request_responseContent);
                visitdata = Visits(request_visit);
            }
                return visitdata;
        }
        private static List<Visit> Visits(JArray VisitArray)
        {
            List<Visit> visits = new List<Visit>();
            var VisitList = (from i in VisitArray select (i as JObject)).ToList();
            visits = VisitObjects(VisitList);
            return visits;
        }
        private static List<Visit> VisitObjects(List<JObject> All_Objects)
        {
            List<Visit> visits = new List<Visit>();
            foreach (var _object in All_Objects)
            {
                Visit visit = new Visit()
                {
                    Blood_pressure___Diastolic = _object.Value<int>("Blood_pressure___Diastolic"),
                    Visit_ID = _object.Value<string>("Visit_ID "),
                    PID = _object.Value<string>("PID"),
                    MUAC_SCORE = _object.Value<decimal>("MUAC_SCORE"),
                    Visit_Date = _object.Value<DateTime>("Visit_Date"),

                    Date_Next_Visit = _object.Value<DateTime>("Date_Next_Visit"),
                    Weight = _object.Value<decimal>("Weight"),
                    Weight_Score = _object.Value<string>("Weight_Score"),
                    Blood_pressure___Systolic = _object.Value<decimal>("Blood_pressure___Systolic"),
                    Blood_Sugar = _object.Value<decimal>("Blood_Sugar"),
                    CD4_Count = _object.Value<decimal>("CD4_Count"),
                    Viral_Load = _object.Value<decimal>("Viral_Load")
                };
                visits.Add(visit);
            }
            return visits;
        }
        #endregion

        #region Dashboard
        public static async Task<Dashboard> GetDashboard(string _username)
        {
            Dashboard data = new Dashboard();
            string connected = await Plugin.Connectivity.CrossConnectivity.Current.
                IsRemoteReachable(Constants.baseUrl, Constants.port) ? "Reachable" : "Not reachable";

            if (connected == "Reachable")
            {
                var request_httpclient = new HttpClient();
                var request_postData = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("UserName", _username)
                    };
                var request_formContent = new FormUrlEncodedContent(request_postData);
                var request_response = await request_httpclient.PostAsync(Constants.Json_link_request,
                                request_formContent);
                var request_result = await request_response.Content.ReadAsStreamAsync();
                var request_streamReader = new System.IO.StreamReader(request_result);
                var request_responseContent = request_streamReader.ReadToEnd().Trim().ToString();
                var request_dashboard = JObject.Parse(request_responseContent);
                data = DashboardData(request_dashboard);
            }
            return data;
        }
        private static Dashboard DashboardData(JObject _object)
        {
            Dashboard dashboard = new Dashboard()
            {
                ART_CARE_COHORT = _object.Value<string>("ART_CARE_COHORT"),
                Current_Drugs = _object.Value<string>("Current_Drugs"),
                Date_Next_Visit = _object.Value<DateTime>("Date_Next_Visit"),
                Fullnames = _object.Value<string>("Fullnames"),
                Profile_photo = _object.Value<string>("Profile_photo"),
                TB_Regimen = _object.Value<string>("TB_Regimen"),
                Username = _object.Value<string>("Username"),
                WHO_HIV_Stage = _object.Value<string>("WHO_HIV_Stage")
            };
            return dashboard;
        }

        #endregion

        #region Graph
        //Getting graphs
        public static async Task<List<GraphData>> GraphContent(string _type, string _username)
        {
            List<GraphData> graphs = new List<GraphData>();
            List<Visit> visits = await GetData(_username);
            visits.Count();
            if (visits.Count() < 7)
            {
                foreach(var visit in visits)
                {
                    GraphData graph = new GraphData()
                    {
                        Month = Constants.Month(visit.Visit_Date),
                        Value = float.Parse(Constants.Value(visit, _type).ToString())                        
                    };
                    graphs.Add(graph);
                }
            }
            else
            {
                int start_number = visits.Count() - 5;
                int last_number = visits.Count + 1;
                for (int i = start_number; i < last_number; i++)
                {
                    GraphData graph = new GraphData()
                    {
                        Month = Constants.Month(visits.ElementAt(i).Visit_Date),
                        Value = float.Parse(Constants.Value(visits.ElementAt(i), _type).ToString())
                    };
                    graphs.Add(graph);
                }
            }
            return graphs;
        }
        #endregion
    }
}