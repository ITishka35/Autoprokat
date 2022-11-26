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
        private Application application;
        private Workbook workBook;
        private Worksheet worksheet;

        public Contract()
        {
            InitializeComponent();
            AppConnect.model = new CarsProkatEntities();
            cm_Clients.ItemsSource = AppConnect.model.Clients.Select(p => p.FirstName + " " + p.LastName + " " + p.MiddleName).ToArray();
            cmb_Auto.ItemsSource = AppConnect.model.Cars.Select(p => p.Marks + " " + p.Model).ToArray();
            cm_Work.ItemsSource = AppConnect.model.WorkersAutoProkat.Select(p => p.FirstName + " " + p.LastName + " " + p.MiddleName).ToArray();
            //AppConnect.model.Cars.Where(x => x.Marks.Contains(txtbMarks.Text)).Where(x => x.TypeCars.Type == cmbFilter.Text).ToArray()



        }


        private void load_Click(object sender, RoutedEventArgs e)
        {
        
                Issued_Cars issued_Cars = new Issued_Cars()
                {
                    ID_Client = AppConnect.model.Clients.Where(p => p.ID_Client == cm_Clients.SelectedIndex + 1).Select(p => p.ID_Client).FirstOrDefault(),
                    ID_Car = AppConnect.model.Cars.Where(p => p.Marks == cmb_Auto.Text).Select(p => p.ID_Car).FirstOrDefault(),
                    ID_Workers = AppConnect.model.WorkersAutoProkat.Where(p => p.ID_Workers == cm_Work.SelectedIndex).Select(p => p.ID_Workers).FirstOrDefault(),
                    Date_Issue = tx_D_I.SelectedDate,
                    Quatity_Days = tx_Q_D.Text,
                    Date_Return = tx_D_I.SelectedDate,
                    Deposit_amount = tx_D_A.Text,
                    Amount_Payable = tx_A_P.Text
                };
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
            //Workbook wb = app.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            string path = System.IO.Path.Combine(@"C:\Users\Maria & Vlad\source\repos\Autoprokat\bin\Debug\", template3);
            //wb = application.Workbooks.Open(path);
            workBook = app.Workbooks.Open(path);

            Worksheet ws = workBook.Worksheets[1];
            DateTime currentDate = DateTime.Now;

            int count = 0;
            //var sheets = workBook.Worksheets.Add("Clients");
            int i;
            int j = 0;



            List<Issued_Cars> listRep = AppConnect.model.Issued_Cars.ToList();
            for (i = 0; i < listRep.Count; i++)
            {

                //for (j = 0; j < list.Count; j++)
                
                    ws.Range["C7"].Value = listRep[i].WorkersAutoProkat.LastName;
                    ws.Range["C8"].Value = listRep[i].WorkersAutoProkat.FirstName;
                    ws.Range["C9"].Value = listRep[i].WorkersAutoProkat.MiddleName;
                    ws.Range["F7"].Value = listRep[i].Clients.LastName;
                    ws.Range["F8"].Value = listRep[i].Clients.FirstName;
                    ws.Range["F9"].Value = listRep[i].Clients.MiddleName;
                    ws.Range["E18"].Value = listRep[i].Quatity_Days;
                    ws.Range["C12"].Value = listRep[i].Cars.State_Number;
                    ws.Range["E12"].Value = listRep[i].Cars.Marks;
                    ws.Range["G12"].Value = listRep[i].Cars.Year_Release;
                    ws.Range["F15"].Value = listRep[i].Date_Return;
                    ws.Range["H18"].Value = listRep[i].Amount_Payable;

                    i++;
                
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.Frames.Navigate(new Manager());
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

