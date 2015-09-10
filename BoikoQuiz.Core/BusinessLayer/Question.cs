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
    [Table("Questions")]
    public class Question : Entity
    {
        #region Fields

        [MaxLength(300)]
        public string Text { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Answer> Answers { get; set; }

        public int CorectAnswerId { get; set; }

        #endregion

        public Question()
        {
            Answers = new List<Answer>();
        }

        public static Question createByJToken(JToken data)
        {
            Question question = new Question() {
                Id = Convert.ToInt32(data["id"]),
                Text = data["text"].ToString(),
                CorectAnswerId = Convert.ToInt32(data["corectAnswerId"])
            };
            question.Answers = Answer.createByJToken(data["answers"], question);

            return question;
        }

        public Answer getCorectAnswer()
        {
            try {
                return Answers.Where(a => a.Id == CorectAnswerId).First();
            } catch {
                return Answers[0];
            }
        }

        public Answer getAnswerById(int id)
        {
            try {
                return Answers.Where(a => a.Id == id).First();
            } catch {
                return Answers[0];
            }
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
