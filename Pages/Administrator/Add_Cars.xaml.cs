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

namespace Autoprokat.Pages.Administrator
{
    /// <summary>
    /// Логика взаимодействия для Add_Cars.xaml
    /// </summary>
    public partial class Add_Cars : Page
    {
        public Add_Cars()
        {
            InitializeComponent();
            ListSpisok.ItemsSource = AppConnect.model.Cars.ToArray();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {

        }

        private void save_Click(object sender, RoutedEventArgs e)
        {

        }

        private void All_Save_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BackPage_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.Frames.Navigate(new Administrator());
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Edits_Item_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Search_Online(object sender, TextChangedEventArgs e)
        {
            ListSpisok.ItemsSource = AppConnect.model.Cars.Where(x => x.Marks.Contains(txtbMarks.Text)).ToArray(); // Поиск по наименованию
                                                                                                                  //Фильтрация по размеру скидки
            if (cmbFilter.Text == "Седан")
            {
                ListSpisok.ItemsSource = AppConnect.model.Cars.Where(x => x.Marks.Contains(txtbMarks.Text)).Where(x => x.TypeCars.Type == cmbFilter.Text).ToArray();
            }
            else
            {
                if (cmbFilter.Text == "Хэчбэк")
                {
                    ListSpisok.ItemsSource = AppConnect.model.Cars.Where(x => x.Marks.Contains(txtbMarks.Text)).Where(x => x.TypeCars.Type == cmbFilter.Text).ToArray();
                }
                else
                {

                    if (cmbFilter.Text == "Кроссовер")
                    {
                        ListSpisok.ItemsSource = AppConnect.model.Cars.Where(x => x.Marks.Contains(txtbMarks.Text)).Where(x => x.TypeCars.Type == cmbFilter.Text).ToArray();
                    }

                    else
                    {
                        if (cmbFilter.Text == "Внедорожник")
                        {
                            ListSpisok.ItemsSource = AppConnect.model.Cars.Where(x => x.Marks.Contains(txtbMarks.Text)).Where(x => x.TypeCars.Type == cmbFilter.Text).ToArray();
                        }
                        else
                        {
                            if (cmbFilter.Text == "Все")
                            {
                                ListSpisok.ItemsSource = AppConnect.model.Cars.Where(x => x.Marks.Contains(txtbMarks.Text)).ToArray();
                            }
                        }
                    }
                }
            }
        }

        private void cmbFilter_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void cmbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
