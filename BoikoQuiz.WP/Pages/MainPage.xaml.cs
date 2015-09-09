#region namespace
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using BoikoQuiz.WP.Resources;
using BoikoQuiz.Core.BusinessLayer;
using BoikoQuiz.Core.Event;
#endregion

namespace BoikoQuiz.WP
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Конструктор
        public MainPage()
        {
            InitializeComponent();

            var db = App.Database;
            //db.AddNew(new User() { Name = "fff", PhotoPath = "22" });

           /* System.Threading.Thread.Sleep(5000);
            db.GetAllUser((object sender, DBEventArgs<Question> ea) => {
                var user = ea.Result;
                string n = user[0].Text;
            });*/
           
            //BuildLocalizedApplicationBar();
        }

        // Пример кода для сборки локализованной панели ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Установка в качестве ApplicationBar страницы нового экземпляра ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Создание новой кнопки и установка текстового значения равным локализованной строке из AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Создание нового пункта меню с локализованной строкой из AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}