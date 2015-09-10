#region namespace
using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
#endregion

namespace BoikoQuiz.Core.BusinessLayer
{
    [Table("Answers")]
    public class Answer : Entity
    {
        [MaxLength(300)]
        public string Text { get; set; }

        //[ForeignKey(typeof(Question))]
        public int QuestionId { get; set; }

        //[ManyToOne(CascadeOperations = CascadeOperation.CascadeRead)]
        //public Question Question { get; set; }

        public static List<Answer> createByJToken(JToken data, Question question)
        {
            List<Answer> answers = new List<Answer>();
            foreach (var answer in data)
                answers.Add(new Answer() {
                    Id = Convert.ToInt32(answer["id"]),
                    Text = answer["text"].ToString(),
                    QuestionId = question.Id,
                   // Question = question
                });

            return answers;
        }

        public bool Equals(Answer answer)
        {
            return Id == answer.Id && Text == answer.Text;
        }
    }
}