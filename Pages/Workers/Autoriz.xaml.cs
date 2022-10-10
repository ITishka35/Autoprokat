using Autoprokat.AppConnestion;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Autoprokat.Pages.Workers
{
    /// <summary>
    /// Логика взаимодействия для Autoriz.xaml
    /// </summary>
    public partial class Autoriz : Page
    {
        public Autoriz()
        {
            InitializeComponent();
            AppConnect.model = new CarsProkatEntities();
            AppFrame.Frames.NavigationUIVisibility = NavigationUIVisibility.Hidden;
        }

        private void Sign_In_Click(object sender, RoutedEventArgs e)
        {
            var userr = AppConnect.model.Users.Where(p => p.Password == Password.Text.ToString() && p.Login == Login.Text.ToString()).FirstOrDefault();
            if (userr == null)
            {
                MessageBox.Show("Пользователь не найден");
            }
            else
            {
                if (userr.Role.ID_Role == 1)
                {
                    MessageBox.Show("Вы зашли как админ");
                    AppFrame.Frames.Navigate(new Administrator.Administrator());
                }
                else
                {
                    if (userr.Role.ID_Role == 2)
                    {
                        MessageBox.Show("Вы зашли как менеджер");
                        AppFrame.Frames.Navigate(new Manager());
                    }
                    else if (userr.Role.ID_Role == 3)
                    {
                        MessageBox.Show("Вы зашли как менеджер");
                        AppFrame.Frames.Navigate(new Accountant.AccountantMenu());
                    }
                }
            }
        }
    }
}

