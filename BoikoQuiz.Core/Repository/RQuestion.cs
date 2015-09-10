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

            Db.Execute(query, completed);
        }

        public void GetAnswerById(int id, DBEventHandler<Answer> completed)
        {
            var rand = new Random();
            var query = from a in Db.Dbc.Table<Answer>()
                        where a.QuestionId == id
                        select a;

            Db.Execute(query, completed);

            /*return database.Table<Question>()
                    .Join(database.Table<Answer>().Where(t => t.ThemeId == ThemeID)
                        , (m, t) => new { mym = m, myt = t })
                    .Select(a => new Playlist
                    {
                        Name = a.mym.Name,
                        ResId = a.mym.ResId,
                        LoopStart = 0
                    })
                    .ToList();*/
        }
    }
}