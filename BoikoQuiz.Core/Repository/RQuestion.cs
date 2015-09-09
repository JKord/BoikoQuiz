using System;
using BoikoQuiz.Core.BusinessLayer;
using BoikoQuiz.Core.DataLayer;

namespace BoikoQuiz.Core.Repository
{
    public class RQuestion : Repository
    {
        public void GetRand(DBEventHandler<Question> completed)
        {
            var rand = new Random();
            var query = from q in Db.Dbc.Table<Question>()
                        where q.Text != null
                        select q;
            query = query.Skip(rand.Next(0, 7)).Take(1);           

            Db.Execute<Question>(query, completed);
        }
    }
}