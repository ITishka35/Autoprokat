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

        private void AddWorkers_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.Frames.Navigate(new Add_Workers());
        }

        private void OnBack_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.Frames.Navigate(new Workers.Autoriz());
        }

        private void AddCars_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.Frames.Navigate(new Add_Cars());

        }
    }
}
