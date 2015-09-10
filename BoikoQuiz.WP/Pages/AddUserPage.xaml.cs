#region namespace
using System.Windows;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using BoikoQuiz.Core.BusinessLayer;
#endregion

namespace BoikoQuiz.WP.Pages
{
    public partial class AddUserPage : PhoneApplicationPage
    {
        public AddUserPage()
        {
            InitializeComponent();
        }

        private void btnAdd_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            string name = tbName.Text;
            if (name.Trim() == "")
            {
                MessageBox.Show("Name incorrect!");
                return;
            }

            App.Database.AddNew(new User() { Name = name });
            NavigationService.GoBack();
        }
    }
}