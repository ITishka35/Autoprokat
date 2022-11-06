using Autoprokat.AppConnestion;
using Autoprokat.Classes;
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
    /// Логика взаимодействия для Add_Workers.xaml
    /// </summary>
    public partial class Add_Workers : Page
    {
        
        public Add_Workers()
        {
            InitializeComponent();
            ListSpisok.ItemsSource = AppConnect.model.WorkersAutoProkat.ToArray();
            RedList.ItemsSource = AppConnect.model.WorkersAutoProkat.ToArray();
        }

        private void BackPage_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.Frames.Navigate(new Administrator());

        }

        private void AllSave_Click(object sender, RoutedEventArgs e)
        {
            WorkersAutoProkat workers = new WorkersAutoProkat
            {
                LastName = LastNameTXT.Text,
                FirstName = FirstNameTXT.Text,
                MiddleName = MiddleNameTXT.Text,
                Position = PositionTXT.Text,
            };
            AppConnect.model.WorkersAutoProkat.Add(workers);
            AppConnect.model.SaveChanges();
            MessageBox.Show("Запись была добавлена!");
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            RedList.ItemsSource = ListSpisok.SelectedItems;
            Red.Visibility = Visibility.Visible;
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {

            if (ListSpisok.SelectedIndex == -1)//Если не выбран ни один блок Select Index принимает значение -1, первый же блок всегда нумеруется 0
                MessageBox.Show("Выберите сотрудника", "Уведомление", MessageBoxButton.OK);
            else
                try
                {
                    AppConnect.model.WorkersAutoProkat.Remove(AppConnect.model.WorkersAutoProkat.Where(p => p.ID_Workers == AppHelp.ID_Workers).FirstOrDefault()); //Код удаление по Id
                                                                                                                                                                   //Здесь возможно понадобиться код для удаления из двух других таблиц строк, в которых Id сервиса внешний ключ. Пишется от также как сверху,
                                                                                                                                                                   ////Только имеет не метод Firstordefault()
                    AppConnect.model.SaveChanges();
                    ListSpisok.ItemsSource = AppConnect.model.WorkersAutoProkat.ToArray();
                }
                catch
                {
                    MessageBox.Show("Ошибка удаления из базы данных:", "уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            AppConnect.model.SaveChanges();
            Red.Visibility = Visibility.Hidden;
        }


        private void cmbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cmbFilter_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Search_Online(object sender, TextChangedEventArgs e)
        {
            
            ListSpisok.ItemsSource = AppConnect.model.WorkersAutoProkat.Where(x => x.LastName.Contains(txtbLastName.Text)).ToArray(); // Поиск по наименованию
                                                                                                                                      //Фильтрация по размеру скидки
            if (cmbFilter.Text == "Менеджер")
            {
                ListSpisok.ItemsSource = AppConnect.model.WorkersAutoProkat.Where(x => x.LastName.Contains(txtbLastName.Text)).Where(x=> x.Position == cmbFilter.Text).ToArray();
            }
            else
            {
                if (cmbFilter.Text == "Бухгалтер")
                {
                    ListSpisok.ItemsSource = AppConnect.model.WorkersAutoProkat.Where(x => x.LastName.Contains(txtbLastName.Text)).Where(x => x.Position == cmbFilter.Text).ToArray();
                }
                else
                {

                    if (cmbFilter.Text == "Администратор")
                    {
                        ListSpisok.ItemsSource = AppConnect.model.WorkersAutoProkat.Where(x => x.LastName.Contains(txtbLastName.Text)).Where(x => x.Position == cmbFilter.Text).ToArray();
                    }

                    else
                    {
                        //if (cmbFilter.Text == "Внедорожник")
                        //{
                        //    ListSpisok.ItemsSource = AppConnect.model.WorkersAutoProkat.Where(x => x.LastName.Contains(txtbLastName.Text)).Where(x => x.Discount >= 0.3 x.Discount < 0.7).ToArray();
                        //}
                        //else
                        //{
                            if (cmbFilter.Text == "Все")
                            {
                                ListSpisok.ItemsSource = AppConnect.model.WorkersAutoProkat.Where(x => x.LastName.Contains(txtbLastName.Text)).ToArray();
                            }
                        }
                    }
                }
            }
        }
    }


