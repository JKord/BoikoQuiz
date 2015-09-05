using SQLite.Net.Attributes;

namespace BoikoQuiz.Core.BusinessLayer
{
    public class Entity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}
