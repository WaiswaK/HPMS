using SQLite;

namespace App.Database
{
    [Table("Server")]
    public class Server
    {
        [PrimaryKey]
        public string Host { get; set; }
        public int Port { get; set; }
    }
}
