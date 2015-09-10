#region namespace
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoikoQuiz.Core.BusinessLayer;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
#endregion

namespace BoikoQuiz.Core.Test.BusinessLayer
{
    [TestClass]
    public class QuestionTest
    {
        public Answer getCorrectAnswer()
        {
            return new Answer() { Id = 1, Text = "a1", QuestionId = 1 };
        }

        public Question getQuestion()
        {
            List<Answer> answers = new List<Answer>();
            answers.Add(getCorrectAnswer());
            answers.Add(new Answer() { Id = 2, Text = "a2" });
            answers.Add(new Answer() { Id = 3, Text = "a3" });

            foreach (Answer answer in answers)
                answer.QuestionId = 1;

            Question question = new Question()
            {
                Id = 1,
                Text = "Text",
                CorectAnswerId = 1,
                Answers = answers
            };

            return question;
        }

        [TestMethod]
        public void createByJToken()
        {
            Question qTest = getQuestion();
            string json = JsonConvert.SerializeObject(qTest); System.Console.WriteLine(json);
            var parsedJson = JObject.Parse(json);
            //Question q = Question.createByJToken(parsedJson);

            Assert.AreEqual(qTest, qTest);
        }

        [TestMethod]
        public void getCorectAnswer()
        {
            Answer answer = getQuestion().getCorectAnswer();
            Answer answerTest = getCorrectAnswer();

            Assert.AreEqual(answerTest.Id, answer.Id);
            Assert.AreEqual(answerTest.Text, answer.Text);
            Assert.AreEqual(answerTest.QuestionId, answer.QuestionId);
        }

        [TestMethod]
        public void corectAnswer()
        {
            Question answer = getQuestion();
            Answer answerTest = getCorrectAnswer();

            Assert.IsTrue(answer.isCorectAnswer(answerTest));
            Assert.IsTrue(answer.isCorectAnswer(answerTest.Id));
        }
    }
}