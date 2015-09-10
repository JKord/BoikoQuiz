#region namespace
using System;
using System.Windows;
using System.Threading;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Ninject;
using BoikoQuiz.Core.BusinessLayer;
using BoikoQuiz.Core.Event;
using BoikoQuiz.Core.Repository;
using BoikoQuiz.WP.Panels;
#endregion

namespace BoikoQuiz.WP.Pages
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Конструктор
        public MainPage()
        {
            InitializeComponent();

            var db = App.Database;            
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);

            BuildLocalizedApplicationBar();
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            App.HNavigation = new NavigationHelper(NavigationService);

            UserListPanel.Items.Clear();
            App.Kernel.Get<RUser>().GetAll((object s, DBEventArgs<User> ea) => {
                foreach (User user in ea.Result)
                    UserListPanel.Items.Add(new UserItemControl(user));
            });   
        }

        private void BuildLocalizedApplicationBar()
        {
            ApplicationBar = new ApplicationBar();

            /*ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
            appBarButton.Text = AppResources.AppBarButtonText;
            ApplicationBar.Buttons.Add(appBarButton);*/

            ApplicationBarMenuItem addUseMenuItem = new ApplicationBarMenuItem("Додати персонажа");
            addUseMenuItem.Click += (object sender, EventArgs e) => App.HNavigation.GoToAddPage();
            ApplicationBar.MenuItems.Add(addUseMenuItem);

            ApplicationBarMenuItem leaderMenuItem = new ApplicationBarMenuItem("Лідер борд");
            leaderMenuItem.Click += (object sender, EventArgs e) => App.HNavigation.GoToLeaderPage();
            ApplicationBar.MenuItems.Add(leaderMenuItem);
        }
    }
}