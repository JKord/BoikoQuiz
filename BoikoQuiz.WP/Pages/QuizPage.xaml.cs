#region namespace
using System;
using System.Windows;
using Ninject;
using Microsoft.Phone.Controls;
using BoikoQuiz.Core.Repository;
using BoikoQuiz.Core.Event;
using BoikoQuiz.Core.BusinessLayer;
using BoikoQuiz.WP.Panels;
#endregion

namespace BoikoQuiz.WP.Pages
{
    public partial class QuizPage : PhoneApplicationPage
    {
        protected RQuestion rQuestion;
        private const int maxQuestion = 2;
        private int countQuestion = 0;

        public QuizPage()
        {
            InitializeComponent();
            rQuestion = App.Kernel.Get<RQuestion>();

            showQuestion();
        }

        public void showQuestion()
        {
            rQuestion.GetRand((object s, DBEventArgs<Question> ea) => {
                if (ea.Result.Count < 1)
                {
                    NavigationService.GoBack();
                    return;
                }

                Question q = ea.Result[0];
                rQuestion.GetAnswerById(q.Id, (object s2, DBEventArgs<Answer> ea2) => {
                    q.Answers = ea2.Result;
                    questionPanorama.Items.Add(new QuizeItemControl(q, (object s3, EventArgs ea3) => {
                        if (countQuestion >= maxQuestion) {
                            MessageBox.Show("Тест пройдено! Загальна кількість балів: " + App.User.Points);
                            NavigationService.GoBack();
                        } else {
                            countQuestion++;
                            showQuestion();
                            App.Database.Update(App.User);
                        }
                    }));

                    if (countQuestion != 0)
                        questionPanorama.DefaultItem = questionPanorama.Items[countQuestion];
                });
            });
        }
    }
}