using System.Windows;
using System.Windows.Controls;
using BoikoQuiz.Core.BusinessLayer;

namespace BoikoQuiz.WP.Panels
{
    public partial class QuizeItemControl : UserControl
    {
        public QuizeItemControl(Question question)
        {            
            InitializeComponent();
            LayoutRoot.DataContext = question;
        }

        private void AnswerPanel_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            MessageBox.Show("Tap!");
        }
    }
}
