using SQLite.Net.Attributes;

namespace App.Database
{
    [Table("User")]
    public class User
    {
        [PrimaryKey]
        public string User_name { get; set; }
        public string Code { get; set; }
        public bool Active { get; set; }
    }
}
