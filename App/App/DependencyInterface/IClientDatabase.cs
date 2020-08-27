using SQLite;

namespace App.DependencyInterface
{
    public interface IClientDatabase
    {
        void InitializeDatabase();
        SQLiteConnection GetConnection();
    }
}
