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

        public void GetLeaders(DBEventHandler<User> completed)
        {
            var query = from u in Db.Dbc.Table<User>()
                        orderby u.Points descending
                        select u;

            Db.Execute(query, completed);
        }
    }
}