using App.Database;
using App.DependencyInterface;
using App.Models;
using System;
using Xamarin.Forms;

namespace App.Services
{
    public class Constants
    {
        public static string dbName = "HPMS.sqlite";
        private static string http = @"http://";
        public static string baseUrl = http + HostIP();
        public static int port = HostPort();
        public static string hostUrl = baseUrl + ":" + port;
        public static string hostAPI = hostUrl + @"/api";
        public static string Json_link_request = hostAPI + @"/request";
        public static string NullRemove(string input)
        {
            if (input == null)
            {
                return string.Empty;
            }
            else
            {
                return input;
            }
        }
        //Method to Initialize the SQLite Database
        public static void InitializeDatabase()
        {
            DependencyService.Get<IClientDatabase>().InitializeDatabase();
        }
        public static string HostIP()
        {
            string host = string.Empty;
            try
            {
                using (var db = DependencyService.Get<IClientDatabase>().GetConnection())
                {
                    var query = db.Table<Server>().FirstOrDefault();
                    host = query.Host;
                }
            }
            catch
            {

            }
            return host;
        }
        public static int HostPort()
        {
            int port = 0;
            try
            {
                using (var db = DependencyService.Get<IClientDatabase>().GetConnection())
                {
                    var query = db.Table<Server>().FirstOrDefault();
                    port = query.Port;
                }
            }
            catch
            {

            }
            return port;
        }
        public static string Month(DateTime _date)
        {
            string _month = string.Empty;
            if (_date.Month == 1)
                _month = "January";
            if (_date.Month == 2)
                _month = "February";
            if (_date.Month == 3)
                _month = "March";
            if (_date.Month == 4)
                _month = "April";
            if (_date.Month == 5)
                _month = "May";
            if (_date.Month == 6)
                _month = "June";
            if (_date.Month ==7)
                _month = "July";
            if (_date.Month ==8)
                _month = "August";
            if (_date.Month ==9)
                _month = "September";
            if (_date.Month ==10)
                _month = "October";
            if (_date.Month ==11)
                _month = "November";
            if (_date.Month ==12)
                _month = "December";
            return _month;
        }
        public static decimal Value(Visit visit, string _type)
        {
            decimal _value = 0;
            if (_type == "MUAC_SCORE")
                _value = visit.MUAC_SCORE;
            if (_type == "Weight")
                _value = visit.Weight;
            if (_type == "Blood_Sugar")
                _value = visit.Blood_Sugar;
            if (_type == "Viral_Load")
                _value = visit.Viral_Load;
            return _value;
        }
    }
}
