using BoikoQuiz.Core.BusinessLayer;
using BoikoQuiz.Core.DataLayer;

namespace BoikoQuiz.Core.Repository
{
    public class RUser : Repository
    {
        public void GetAll(DBEventHandler<User> completed)
        {
            Db.ExecuteList(completed);
        }
    }
}