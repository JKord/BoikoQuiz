#region namespace
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BoikoQuiz.Core.BusinessLayer;
#endregion


namespace BoikoQuiz.WP.Panels
{
    public partial class QuizeItemControl : UserControl
    {
        #region Fields

        private Question question;
        private EventHandler clickNext;
        private bool isClick = false;

        #endregion

        public QuizeItemControl(Question _question, EventHandler _clickNext)
        {            
            InitializeComponent();
            LayoutRoot.DataContext = question = _question;
            clickNext = _clickNext;
        }

        private void answerTextBlock_Tap(object sender, GestureEventArgs e)
        {
            if (isClick)
                return;
            isClick = true;

            Answer answer = question.getAnswerById(Convert.ToInt32((sender as TextBlock).Tag));
            if (question.isCorectAnswer(answer))
            {
                MessageBox.Show("Вірно!");
                App.User.Points += 10;
            } else {
                MessageBox.Show("Не вірно!");
            }

            clickNext(this, e);
        }
    }
}