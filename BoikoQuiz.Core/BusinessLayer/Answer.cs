#region namespace
using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
#endregion

namespace BoikoQuiz.Core.BusinessLayer
{
    public class Answer : Entity
    {
        [MaxLength(300)]
        public string Text { get; set; }

        [ManyToOne]
        public Question question { get; set; }

        public static List<Answer> createByJToken(JToken data)
        {
            List<Answer> answers = new List<Answer>();
            foreach (var answer in data)
                answers.Add(new Answer() {
                    Id = Convert.ToInt32(answer["id"]),
                    Text = answer["text"].ToString()
                });

            return answers;
        }
    }
}