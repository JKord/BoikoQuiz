using System;
using Newtonsoft.Json.Linq;
using SQLite.Net.Attributes;

namespace BoikoQuiz.Core.BusinessLayer
{
    public class User : Entity
    {
        [MaxLength(150)]
        public string Name { get; set; }

        public string PhotoPath { get; set; }

        public int Points { get; set; }

        public static User createByJToken(JToken data)
        {
            return new User()
            {
                Name = data["name"].ToString(),
                //PhotoPath = data["photoPath"].ToString(),
                Points = Convert.ToInt32(data["points"])
            };
        }
    }
}