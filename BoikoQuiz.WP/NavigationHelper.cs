using System;
using System.Windows.Navigation;

namespace BoikoQuiz.WP
{
    public class NavigationHelper
    {
        protected NavigationService ns;

        public NavigationHelper(NavigationService _ns)
        {
            ns = _ns;
        }

        public void GoTo(string name)
        {
            ns.Navigate(new Uri(name, UriKind.Relative));
        }

        public void GoToQuizPage()
        {
            GoTo("/Pages/QuizPage.xaml");
        }

        public void GoToAddPage()
        {
            GoTo("/Pages/AddUserPage.xaml");
        }

        public void GoToLeaderPage()
        {
            GoTo("/Pages/LeaderPage.xaml");
        }
    }
}