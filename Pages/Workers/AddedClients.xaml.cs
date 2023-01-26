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
            AppConnect.model = new CarsProkatEntities();
            InitializeComponent();
            ListSpisok.ItemsSource = AppConnect.model.Clients.ToArray();
            RedList.ItemsSource = AppConnect.model.Cars.ToArray();
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
                Birthday = dp_Birthday.SelectedDate.Value.ToString("dd-mm-yyyy"),
                Adress = txt_Address.Text,
            };
            AppConnect.model.Clients.Add(clients);
            AppConnect.model.SaveChanges();
            MessageBox.Show("Запись была добавлена!");
            AppFrame.Frames.Navigate(new Contract());
        }

        private void BackPage(object sender, RoutedEventArgs e)
        {
            AppFrame.Frames.Navigate(new Manager());
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Clients client= new Clients();
                client = ListSpisok.SelectedItem as Clients;
                AppConnect.model.Clients.Remove(client);
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
            RedList.Visibility = Visibility.Visible;
            AppConnect.model.SaveChanges();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            RedList.ItemsSource = ListSpisok.SelectedItems;
            Red.Visibility = Visibility.Hidden;
            AppConnect.model.SaveChanges();
        }

        private void ListSpisok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //ListBox listBox = (ListBox)sender;
            //Clients clients= (Clients)listBox.Items[listBox.SelectedIndex];
            //ID = int.Parse(clients.ID_Client.ToString());
        }
    }
}
