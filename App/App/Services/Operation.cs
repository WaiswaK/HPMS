using System.Threading.Tasks;

namespace App.Services
{
    class Operation
    {
        public static async Task UpdatedataAsync(string user)
        {
            Database.UpdateUser(await Json.GetDashboard(user));
        }
        public static async Task UpdateVisitAsync(string user)
        {
            Database.InsertVisits(await Json.GetData(user), user);
        }
    }
}
