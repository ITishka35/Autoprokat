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
        }

        private void BackPage(object sender, RoutedEventArgs e)
        {

        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void save_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
