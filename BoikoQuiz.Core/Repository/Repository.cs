using BoikoQuiz.Core.DataLayer;

namespace BoikoQuiz.Core.Repository
{
    public abstract class Repository
    {
        public static Database Db { get; set; }
    }
}
