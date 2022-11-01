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
    /// Логика взаимодействия для Add_Workers.xaml
    /// </summary>
    public partial class Add_Workers : Page
    {
        public Add_Workers()
        {
            InitializeComponent();
        }

        private void BackPage_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.Frames.Navigate(new Administrator());

        }

        private void AllSave_Click(object sender, RoutedEventArgs e)
        {


        }

        private void DeleteItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditsItem_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
