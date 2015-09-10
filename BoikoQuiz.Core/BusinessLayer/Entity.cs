using SQLite.Net.Attributes;

namespace BoikoQuiz.Core.BusinessLayer
{
    public abstract class Entity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}
