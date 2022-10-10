using Autoprokat.AppConnestion;
using System.Windows;
using System.Windows.Controls;

namespace Autoprokat
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AppFrame.Frames = MainFrame;
            MainFrame.Navigate(new Pages.Workers.Autoriz());

        }

        private void OnExit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
