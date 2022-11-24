using Autoprokat.AppConnestion;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private int ID;
        public CarSelection()
        {
            InitializeComponent();
            ListSpisok.ItemsSource = AppConnect.model.Cars.ToArray();
            DataGrid1.ItemsSource = AppConnect.model.Cars.ToArray();


        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            RedList.ItemsSource = ListSpisok.SelectedItems;
            Red.Visibility = Visibility.Visible;
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AppConnect.model.Cars.Remove(AppConnect.model.Cars.Where(p => p.ID_Car == ID).FirstOrDefault());
                AppConnect.model.SaveChanges();
                MessageBox.Show("Запись удалена");
            }
            catch (Exception ex)
            {
                MessageBox.Show(" " + ex);
            }
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            RedList.ItemsSource = ListSpisok.SelectedItems;
            Red.Visibility = Visibility.Hidden;
            ICollectionView view = CollectionViewSource.GetDefaultView(AppConnect.model.Cars);
            view.Refresh();
        }

        private void AddPicture_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                var Picture = AppConnect.model.Cars.Where(p => p.ID_Car == (ListSpisok.SelectedIndex + 1)).FirstOrDefault();
                Picture.MainImagePath = openFileDialog.FileName;
                AppConnect.model.SaveChanges();
                ListSpisok.ItemsSource = AppConnect.model.Cars.Where(p => p.ID_Car == (ListSpisok.SelectedIndex + 1)).ToArray();
            }
        }

        private void BackPage(object sender, RoutedEventArgs e)
        {
            AppFrame.Frames.Navigate(new Manager());
        }

        private void cmbFilter_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void cmbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
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

        private void Bron_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.Frames.Navigate(new AddedClients());

        }
    }
}
