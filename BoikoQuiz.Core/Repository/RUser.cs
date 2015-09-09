using BoikoQuiz.Core.BusinessLayer;
using BoikoQuiz.Core.DataLayer;

namespace BoikoQuiz.Core.Repository
{
    class RUser : Repository
    {
        public void GetAllUser(DBEventHandler<User> completed)
        {
            Db.ExecuteList(completed);
        }
    }
}