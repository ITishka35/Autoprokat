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

namespace Autoprokat.Pages.Workers.Accountant
{
    /// <summary>
    /// Логика взаимодействия для AccountantMenu.xaml
    /// </summary>
    public partial class AccountantMenu : Page
    {
        public AccountantMenu()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.Frames.Navigate(new Autoriz());
        }
    }
}
