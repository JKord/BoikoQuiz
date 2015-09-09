using Ninject;
using Microsoft.Phone.Controls;
using BoikoQuiz.Core.Repository;
using BoikoQuiz.Core.Event;
using BoikoQuiz.Core.BusinessLayer;
using BoikoQuiz.WP.Panels;

namespace BoikoQuiz.WP.Pages
{
    public partial class QuizPage : PhoneApplicationPage
    {
        protected RQuestion rQuestion;

        public QuizPage()
        {
            InitializeComponent();
            rQuestion = App.Kernel.Get<RQuestion>();

            showQuestion();
        }

        public void showQuestion()
        {
            rQuestion.GetRand((object s, DBEventArgs<Question> ea) => {
                Question q = ea.Result[0];
                questionPanorama.Items.Add(new QuizeItemControl(q));
            });
        }
    }
}