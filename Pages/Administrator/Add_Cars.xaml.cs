using Autoprokat.AppConnestion;
using Autoprokat.Classes;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        private int ID;


        public Add_Cars()
        {
            InitializeComponent();
            ListSpisok.ItemsSource = AppConnect.model.Cars.ToArray();
            RedList.ItemsSource = AppConnect.model.Cars.ToArray();
            cmb_Engine.SelectedValuePath = "ID_Engine";
            cmb_Engine.DisplayMemberPath = "Engine";
            cmb_Engine.ItemsSource = AppConnect.model.TypeEngineCars.ToArray();
            cmb_TypeTransmission.SelectedValuePath = "ID_Transmission";
            cmb_TypeTransmission.DisplayMemberPath = "Transmission";
            cmb_TypeTransmission.ItemsSource = AppConnect.model.TypeTransmission.ToArray();
            cmb_TypeAuto.SelectedValuePath = "ID_Type";
            cmb_TypeAuto.DisplayMemberPath = "Type";
            cmb_TypeAuto.ItemsSource = AppConnect.model.TypeCars.ToArray();

            cmb_EditEngine.SelectedValue = "ID_Engine";
            cmb_EditEngine.DisplayMemberPath = "Engine";
            //int ID_Engines = Convert.ToInt32(cmb_EditEngine.SelectedValue);
            cmb_EditEngine.ItemsSource = AppConnect.model.TypeEngineCars.ToList();

            cmb_EditType.SelectedValue = "ID_Type";
            cmb_EditType.DisplayMemberPath = "Type";
            //int ID_Type = Convert.ToInt32(cmb_EditType.SelectedValue);
            cmb_EditType.ItemsSource = AppConnect.model.TypeCars.ToList();

            cmb_EditTypeTransmission.SelectedValue = "ID_Transmission";
            cmb_EditTypeTransmission.DisplayMemberPath = "Transmission";
            //int ID_Transmission = Convert.ToInt32(cmb_EditTypeTransmission.SelectedValue);
            cmb_EditTypeTransmission.ItemsSource = AppConnect.model.TypeTransmission.ToList();

            //var TypeEngineCars = AppConnect.model.TypeEngineCars.Where(x => x.ID_Engine == ID_Engines).FirstOrDefault();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            //var item = ListSpisok.SelectedItem as Cars;
            //item.TypeEngineCars = cmb_EditEngine.SelectedItem as TypeEngineCars;
            //item.TypeCars = cmb_EditType.SelectedItem as TypeCars;
            //item.TypeTransmission = cmb_EditTypeTransmission.SelectedItem as TypeTransmission;


            RedList.ItemsSource = ListSpisok.SelectedItems;
            cmb_EditEngine.Visibility = Visibility.Visible;
            cmb_EditTypeTransmission.Visibility = Visibility.Visible;
            cmb_EditType.Visibility = Visibility.Visible;
            Red.Visibility = Visibility.Visible;
            StackEdit.Visibility = Visibility.Visible;



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

        private void All_Save_Click(object sender, RoutedEventArgs e)
        {
            Cars cars = new Cars
            {
                Marks = txtbMarks.Text,   
                MainImagePath = imagePath.Text,
                Model = txb_Model.Text,
                Year_Release = txb_Year.SelectedDate.ToString(),
                Color = txb_Color.Text,
                ID_Transmission = AppConnect.model.TypeTransmission.Where(p => p.ID_Transmission == cmb_TypeTransmission.SelectedIndex + 1).Select(p => p.ID_Transmission).FirstOrDefault(),
                Engine_Volume = txb_Eng_Volume.Text,
                Deposit_Amount = txb_Amount_Deposit.Text,
                State_Number = txb_State_Number.Text,
                ID_Type = AppConnect.model.TypeCars.Where(p => p.ID_Type == cmb_TypeAuto.SelectedIndex + 1).Select(p => p.ID_Type).FirstOrDefault(),
                ID_Engines = AppConnect.model.TypeEngineCars.Where(p => p.ID_Engine == cmb_Engine.SelectedIndex).Select(p => p.ID_Engine).FirstOrDefault()
            };

            AppConnect.model.Cars.Add(cars);
            AppConnect.model.SaveChanges();
            MessageBox.Show("Запись была добавлена!");
        }

        private void BackPage_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.Frames.Navigate(new Administrator());
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


        private void AddPic_Click(object sender, RoutedEventArgs e)
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



        private void save_Click(object sender, RoutedEventArgs e)
        {
            
            RedList.ItemsSource = ListSpisok.SelectedItems;
            Red.Visibility = Visibility.Hidden;
            StackEdit.Visibility = Visibility.Hidden;
            var item = ListSpisok.SelectedItem as Cars;
            item.TypeEngineCars = cmb_EditEngine.SelectedItem as TypeEngineCars;
            item.TypeCars = cmb_EditType.SelectedItem as TypeCars;
            item.TypeTransmission = cmb_EditTypeTransmission.SelectedItem as TypeTransmission;
            AppConnect.model.SaveChanges();

        }

        private void ListSpisok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            Cars car = (Cars)listBox.Items[listBox.SelectedIndex];
            ID = int.Parse(car.ID_Car.ToString());
        }

        private void cmb_EditEngine_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
