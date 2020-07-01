using App.Database;
using App.DependencyInterface;
using App.Droid;
using App.Services;
using SQLite.Net;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(ClientDatabase))]

namespace App.Droid
{
    class ClientDatabase : IClientDatabase
    {      
        public SQLiteConnection GetConnection()
        {
            ///string dbPath = Path.Combine(AppFolderPath(), "PDDT");
            string dbPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            dbPath = Path.Combine(dbPath, Constants.dbName);
            var conn = new SQLiteConnection(new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid(), dbPath, true, null, null, null, null);
            return conn;
        }
        public void InitializeDatabase()
        {
            if (LocalDatabaseNotPresent(Constants.dbName))
            {
                using (var db = GetConnection())
                {
                    db.CreateTable<Server>();
                    db.CreateTable<User>();
                };
            }
            else
            {
            }
        }
        bool LocalDatabaseNotPresent(string fileName)
        {
            if (!File.Exists(fileName))
                return true;
            else
                return false;
        }
    }
}