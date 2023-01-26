using Microsoft.Win32;
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
using System.Windows.Xps.Packaging;
using System.IO;
using System.Windows.Xps;
using Autoprokat.AppConnestion;
using Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;
using Autoprokat.Classes;


namespace Autoprokat.Pages.Workers
{
    /// <summary>
    /// Логика взаимодействия для Contract.xaml
    /// </summary>
    public partial class Contract : System.Windows.Controls.Page
    {
        Issued_Cars issued_Cars = new Issued_Cars();
        private Application application;
        private Workbook workBook;
        private Worksheet worksheet;

        public Contract()
        {
            InitializeComponent();

            AppConnect.model = new CarsProkatEntities();
            cm_Clients.SelectedValuePath = "ID_Client";
            cm_Clients.ItemsSource = AppConnect.model.Clients.ToArray();
            cmb_Auto.SelectedValuePath = "ID_Car";
            cmb_Auto.ItemsSource = AppConnect.model.Cars.ToArray();
            cm_Work.SelectedValuePath = "ID_Workers";
            cm_Work.ItemsSource = AppConnect.model.WorkersAutoProkat.ToArray();

        }


        private void load_Click(object sender, RoutedEventArgs e)
        {
            //Clients[] clients = cm_Clients.Items.

            issued_Cars.Clients = cm_Clients.SelectedItem as Clients;
            issued_Cars.Cars = cmb_Auto.SelectedItem as Cars;
            issued_Cars.WorkersAutoProkat = cm_Work.SelectedItem as WorkersAutoProkat;
            issued_Cars.Date_Issue = tx_D_I.SelectedDate;
            issued_Cars.Quatity_Days = tx_Q_D.Text;
            issued_Cars.Date_Return = tx_D_I.SelectedDate;
            issued_Cars.Deposit_amount = tx_D_A.Text;
            issued_Cars.Amount_Payable = tx_A_P.Text;

            AppConnect.model.Issued_Cars.Add(issued_Cars);
            AppConnect.model.SaveChanges();
            MessageBox.Show("Запись была добавлена!");

        }


        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            app.Visible = true;
            app.WindowState = XlWindowState.xlMaximized;


            const string template3 = "Contracts.xlsx";
            string path = System.IO.Path.Combine(Environment.CurrentDirectory, template3);
            workBook = app.Workbooks.Open(path);
            Worksheet ws = workBook.Worksheets[1];
            DateTime currentDate = DateTime.Now;
            int count = 0;
            int i;
            int j = 0;



            //List<Issued_Cars> listRep = AppConnect.model.Issued_Cars.ToList();
            //for (i = 0; i < listRep.Count; i++)
            //{

            ws.Range["C7"].Value = issued_Cars.WorkersAutoProkat.LastName;
            ws.Range["C8"].Value = issued_Cars.WorkersAutoProkat.FirstName;
            ws.Range["C9"].Value = issued_Cars.WorkersAutoProkat.MiddleName;
            ws.Range["F7"].Value = issued_Cars.Clients.LastName;
            ws.Range["F8"].Value = issued_Cars.Clients.FirstName;
            ws.Range["F9"].Value = issued_Cars.Clients.MiddleName;
            ws.Range["E18"].Value = issued_Cars.Quatity_Days;
            ws.Range["C12"].Value = issued_Cars.Cars.State_Number;
            ws.Range["E12"].Value = issued_Cars.Cars.Marks;
            ws.Range["G12"].Value = issued_Cars.Cars.Year_Release;
            ws.Range["F15"].Value = issued_Cars.Date_Return;
            ws.Range["H18"].Value = issued_Cars.Amount_Payable;

            //        i++;

            //}
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.Frames.Navigate(new AddedClients());
        }

        private void rez_Click(object sender, RoutedEventArgs e)
        {
            DateTime d = tx_D_I.SelectedDate.Value;


            DateTime w = tx_D_R.SelectedDate.Value;

            DateTime rez = w.AddDays(-1 * (d.Day));
            tx_Q_D.Text = rez.Day.ToString();
        }

        private void summary_Click(object sender, RoutedEventArgs e)
        {
            tx_A_P.Text = (Int32.Parse(tx_D_A.Text) * Int32.Parse(tx_Q_D.Text)).ToString();

        }

        private void cmb_Auto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


        }
    }
}

