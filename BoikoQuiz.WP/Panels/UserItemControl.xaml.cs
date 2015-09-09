#region namespace
using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using BoikoQuiz.Core.BusinessLayer;
#endregion

namespace BoikoQuiz.WP.Panels
{
    public partial class UserItemControl : UserControl
    {
        public UserItemControl(User user)
        {
            InitializeComponent();
            LayoutRoot.DataContext = user;
        }

        protected override void OnTap(GestureEventArgs e)
        {
            base.OnTap(e);

            App.HNavigation.GoToQuizPage();
        }
    }
}
