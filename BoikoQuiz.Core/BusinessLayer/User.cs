using SQLite.Net.Attributes;

namespace BoikoQuiz.Core.BusinessLayer
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
    }
}