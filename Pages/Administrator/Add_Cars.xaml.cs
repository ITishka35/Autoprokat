using Autoprokat.AppConnestion;
using Autoprokat.Classes;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
            bindcmb();
            var rezult = AppConnect.model.Cars.ToArray().Join(AppConnect.model.Cars.ToArray(),
                P => P.ID_Car,
                t => t.ID_Type,
                (P, t) => new { ID = P.ID_Type,  = P.status, LastName = t.LastName });
            listviewFines.ItemsSource = rezult;

        }
        public  List<TypeCars>  types{ get; set; }

        private void bindcmb()
        {
            //throw new NotImplementedException();
            CarsProkatEntities carsProkatEntities = new CarsProkatEntities();
            var item = carsProkatEntities.TypeCars.ToList();
            types = item;
            DataContext = types;
        }

        



        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            TypeTransmission typeTransmission = new TypeTransmission();
            {
                
            };
            //RedList.ItemsSource = ListSpisok.SelectedItems;
            //cmb_EditEngine.SelectedValuePath = "ID_Engine";
            //cmb_EditEngine.DisplayMemberPath = "Engine";
            //cmb_EditEngine.ItemsSource = AppConnect.model.TypeEngineCars.ToArray();
            //cmb_EditType.SelectedValuePath = "ID_Engine";
            //cmb_EditType.DisplayMemberPath = "Engine";
            //cmb_EditType.ItemsSource = AppConnect.model.TypeCars.ToArray();
            //cmb_EditTypeTransmission.SelectedValuePath = "ID_Tranmission";
            //cmb_EditTypeTransmission.DisplayMemberPath = "Transmission";
            //cmb_EditTypeTransmission.ItemsSource = AppConnect.model.TypeTransmission.ToArray();
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
                Deposit_Amount = int.Parse(txb_Amount_Deposit.Text),
                State_Number = txb_State_Number.Text,
                ID_Type = AppConnect.model.TypeCars.Where(p => p.ID_Type == cmb_TypeAuto.SelectedIndex + 1).Select(p => p.ID_Type).FirstOrDefault(),
                ID_Engine = AppConnect.model.TypeEngineCars.Where(p => p.ID_Engine == cmb_Engine.SelectedIndex).Select(p => p.ID_Engine).FirstOrDefault()
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
        }

        private void ListSpisok_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            Cars car = (Cars)listBox.Items[listBox.SelectedIndex];
            ID = int.Parse(car.ID_Car.ToString());
        }
    }
}
