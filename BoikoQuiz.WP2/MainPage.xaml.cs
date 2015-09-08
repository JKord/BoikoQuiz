#region namespace
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using BoikoQuiz.Core.BusinessLayer;
using BoikoQuiz.Core.Event;
#endregion

// Документацию по шаблону элемента "Пустая страница" см. по адресу http://go.microsoft.com/fwlink/?LinkId=391641

namespace BoikoQuiz.WP
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Вызывается перед отображением этой страницы во фрейме.
        /// </summary>
        /// <param name="e">Данные события, описывающие, каким образом была достигнута эта страница.
        /// Этот параметр обычно используется для настройки страницы.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var db = App.Database;
            db.AddNew(new User() { Name = "fff" });

            db.GetAllUser((object sender, DBEventArgs<User> ea) => {
                var user = ea.Result;
                int t = 1;
            });

            // событие Windows.Phone.UI.Input.HardwareButtons.BackPressed.
            // Если вы используете NavigationHelper, предоставляемый некоторыми шаблонами,
        }
    }
}
