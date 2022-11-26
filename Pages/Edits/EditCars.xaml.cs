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

namespace Autoprokat.Pages.Edits
{
    /// <summary>
    /// Логика взаимодействия для EditCars.xaml
    /// </summary>
    public partial class EditCars : Page
    {
        public EditCars()
        {
            InitializeComponent(); 
            RedList.ItemsSource = AppConnect.model.Cars.ToArray();

            

        }

        private void RedList_TextInput(object sender, TextCompositionEventArgs e)
        {
        }

        private void cmb_TypeAuto1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
