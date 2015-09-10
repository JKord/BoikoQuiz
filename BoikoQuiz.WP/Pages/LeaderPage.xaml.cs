#region namespace
using Ninject;
using System.Windows;
using Microsoft.Phone.Controls;
using BoikoQuiz.Core.Repository;
using BoikoQuiz.Core.Event;
using BoikoQuiz.Core.BusinessLayer;
using BoikoQuiz.WP.Panels;
#endregion

namespace BoikoQuiz.WP.Pages
{
    public partial class LeaderPage : PhoneApplicationPage
    {
        public LeaderPage()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            App.HNavigation = new NavigationHelper(NavigationService);

            App.Kernel.Get<RUser>().GetLeaders((object s, DBEventArgs<User> ea) => {
                foreach (User user in ea.Result)
                    UserListPanel.Items.Add(new UserItemControl(user));
            });
        }
    }
}