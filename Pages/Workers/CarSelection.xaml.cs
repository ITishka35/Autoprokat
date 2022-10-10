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
    /// Логика взаимодействия для CarSelection.xaml
    /// </summary>
    public partial class CarSelection : Page
    {
        public CarSelection()
        {
            InitializeComponent();
            ListSpisok.ItemsSource = AppConnect.model.Cars.ToArray();
            DataGrid1.ItemsSource = AppConnect.model.Cars.ToArray();
            Binding binding = new Binding();
            // ListSpisok.ItemsSource = AppConnect.model.Type_Cars.ToArray();
            ListSpisok.DataContext = AppConnect.model.Type_Cars.ToArray();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            RedList.ItemsSource = ListSpisok.SelectedItems;
            Red.Visibility = Visibility.Visible;
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {

        }

        private void save_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddPicture_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
