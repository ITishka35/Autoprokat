using Autoprokat.AppConnestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Autoprokat.Pages.Workers
{
    /// <summary>
    /// Логика взаимодействия для Manager.xaml
    /// </summary>
    public partial class Manager : Page
    {
        public Manager()
        {
            InitializeComponent();
        }

        private void AddedClients_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.Frames.Navigate(new AddedClients());
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.Frames.Navigate(new Autoriz());
        }

        private void CarSelection_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.Frames.Navigate(new CarSelection());

        }
    }
}
