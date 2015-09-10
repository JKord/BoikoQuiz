using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoikoQuiz.Core.BusinessLayer;

namespace BoikoQuiz.Core.Test.BusinessLayer
{
    [TestClass]
    public class AnswerTest
    {
        [TestMethod]
        public void Equals()
        {
            Answer
                a1 = new Answer() { Id = 1, Text = "a1", QuestionId = 1 },
                a2 = new Answer() { Id = 1, Text = "a1", QuestionId = 1 },
                a3 = new Answer() { Id = 1, Text = "a2", QuestionId = 1 };

            Assert.IsTrue(a1.Equals(a2));
            Assert.IsFalse(a1.Equals(a3));
        }
    }
}