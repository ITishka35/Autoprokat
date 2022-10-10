using Autoprokat.AppConnestion;
using System.Windows;
using System.Windows.Controls;

namespace Autoprokat.Pages.Administrator
{
    /// <summary>
    /// Логика взаимодействия для Administrator.xaml
    /// </summary>
    public partial class Administrator : Page
    {
        public Administrator()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AppFrame.Frames.Navigate(new Workers.Autoriz());
        }
    }
}
