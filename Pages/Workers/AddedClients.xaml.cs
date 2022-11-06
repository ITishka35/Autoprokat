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
    /// Логика взаимодействия для AddedClients.xaml
    /// </summary>
    public partial class AddedClients : Page
    {
        private int ID;
        public AddedClients()
        {
            InitializeComponent();
        }

        private void SaveAll_Click(object sender, RoutedEventArgs e)
        {
            Clients clients = new Clients
            {
                LastName = txt_LastName.Text,
                FirstName = txt_FirstName.Text,
                MiddleName = txt_MiddleName.Text,
                NumberPassport = txt_NumberPassport.Text,
                SeriaPassport = txt_SeriasPassport.Text,
                Phone = txt_Phone.Text,
                Birthday = DateTime.Parse(txt_Birthday.Text),
                Adress = txt_Address.Text,
            };
            AppConnect.model.Clients.Add(clients);
            AppConnect.model.SaveChanges();
            MessageBox.Show("Запись была добавлена!");
        }

        private void BackPage(object sender, RoutedEventArgs e)
        {
            AppFrame.Frames.Navigate(new Manager());
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AppConnect.model.Clients.Remove(AppConnect.model.Clients.Where(p => p.ID_Client == ID).FirstOrDefault());
                AppConnect.model.SaveChanges();
                MessageBox.Show("Запись удалена");
            }
            catch (Exception ex)
            {
                MessageBox.Show(" " + ex);
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            RedList.ItemsSource = ListSpisok.SelectedItems;
            Red.Visibility = Visibility.Visible;
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            RedList.ItemsSource = ListSpisok.SelectedItems;
            Red.Visibility = Visibility.Hidden;
        }

        private void ListSpisok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            Cars car = (Cars)listBox.Items[listBox.SelectedIndex];
            ID = int.Parse(car.ID_Car.ToString());
        }
    }
}
