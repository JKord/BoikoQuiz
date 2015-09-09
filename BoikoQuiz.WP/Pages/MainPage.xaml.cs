#region namespace
using System;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Ninject;
using BoikoQuiz.Core.BusinessLayer;
using BoikoQuiz.Core.Event;
using BoikoQuiz.Core.Repository;
using BoikoQuiz.WP.Panels;
using BoikoQuiz.WP.Resources;
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

            //BuildLocalizedApplicationBar();
        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            App.HNavigation = new NavigationHelper(NavigationService);

            App.Kernel.Get<RUser>().GetAll((object s, DBEventArgs<User> ea) => {
                foreach (User user in ea.Result)
                    UserListPanel.Children.Add(new UserItemControl(user));
            });
        }

        private void BuildLocalizedApplicationBar()
        {
            // Установка в качестве ApplicationBar страницы нового экземпляра ApplicationBar.
            ApplicationBar = new ApplicationBar();

            // Создание новой кнопки и установка текстового значения равным локализованной строке из AppResources.
            ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
            appBarButton.Text = AppResources.AppBarButtonText;
            ApplicationBar.Buttons.Add(appBarButton);

            // Создание нового пункта меню с локализованной строкой из AppResources.
            ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
            ApplicationBar.MenuItems.Add(appBarMenuItem);
        }
    }
}