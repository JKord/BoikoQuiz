using System.Linq;
using System.Collections.Generic;
using SQLite.Net.Attributes;

namespace BoikoQuiz.Core.BusinessLayer
{
    class Question
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Text { get; set; }
        public List<Answer> Answers { get; set; }
        public int CorectAnswerId { get; }

        public Answer getCorectAnswer()
        {
            return Answers.Where<Answer>(a => a.Id == CorectAnswerId).First();
        }

        public bool isCorectAnswer(Answer answer)
        {
            return getCorectAnswer().Equals(answer);
        }

        public bool isCorectAnswer(int _corectAnswerId)
        {
            return CorectAnswerId == _corectAnswerId;
        }
    }
}
