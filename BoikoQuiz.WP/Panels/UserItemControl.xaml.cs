#region namespace
using System.Windows.Controls;
using System.Windows.Input;
using BoikoQuiz.Core.BusinessLayer;
#endregion

namespace BoikoQuiz.WP.Panels
{
    public partial class UserItemControl : UserControl
    {
        User user;

        public UserItemControl(User _user)
        {
            InitializeComponent();
            LayoutRoot.DataContext = user = _user;
        }

        protected override void OnTap(GestureEventArgs e)
        {
            base.OnTap(e);

            App.HNavigation.GoToQuizPage();
            App.User = user;
        }
    }
}
