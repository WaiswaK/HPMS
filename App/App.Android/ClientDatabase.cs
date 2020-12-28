using App.Database;
using App.DependencyInterface;
using App.Droid;
using App.Services;
using SQLite;
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
            string dbPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            dbPath = Path.Combine(dbPath, Constants.dbName);
            var conn = new SQLiteConnection(dbPath);
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
                    db.CreateTable<Visit>();
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