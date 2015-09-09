#region
using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
#endregion

namespace BoikoQuiz.Core.BusinessLayer
{
    public class Question : Entity
    {
        #region Fields

        [MaxLength(300)]
        public string Text { get; set; }

        [OneToMany]
        public List<Answer> Answers { get; set; }

        public int CorectAnswerId { get; set; }

        #endregion

        public Question()
        {
            Answers = new List<Answer>();
        }

        public static Question createByJToken(JToken data)
        {
            return new Question() {
                Text = data["text"].ToString(),
                CorectAnswerId = Convert.ToInt32(data["corectAnswerId"]),
                Answers = Answer.createByJToken(data["answers"])
            };
        }

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
