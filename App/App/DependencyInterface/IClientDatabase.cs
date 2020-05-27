using SQLite.Net;

namespace App.DependencyInterface
{
    public interface IClientDatabase
    {
        void InitializeDatabase();
        SQLiteConnection GetConnection();
    }
}
