using System.Windows;
using System.Windows.Controls;
using Microsoft.Office.Interop.Excel;
using Autoprokat.AppConnestion;
using System.Linq;
using Microsoft.Win32;
using System;
using Application = Microsoft.Office.Interop.Excel.Application;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Autoprokat.Pages.Workers.Accountant
{
    /// <summary>
    /// Логика взаимодействия для ReportQuantityCarsIssued.xaml
    /// </summary>
    public partial class ReportQuantityCarsIssued : System.Windows.Controls.Page
    {
        private Application application;
        private Workbook workBook;
        private Worksheet worksheet;
        public ReportQuantityCarsIssued()
        {
            InitializeComponent();
            AppConnect.model = new CarsProkatEntities();
            ReporClients.ItemsSource = AppConnect.model.Issued_Cars.ToArray();

        }

        private void btn_load_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.Frames.Navigate(new Accountant.AccountantMenu());
        }

        private void btn_Report_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            app.Visible = true;
            app.WindowState = XlWindowState.xlMaximized;


            const string template3 = "ReportsClients.xlsx";
            //Workbook wb = app.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            string path = Path.Combine(Environment.CurrentDirectory, template3);
            //wb = application.Workbooks.Open(path);
            workBook = app.Workbooks.Open(path);

            Worksheet ws = workBook.Worksheets[1];
            DateTime currentDate = DateTime.Now;
            List<Issued_Cars> list = AppConnect.model.Issued_Cars.ToList();
            int count = 0;
            //var sheets = workBook.Worksheets.Add("Clients");
            int i;
            int j = 0;
            var row = 7;
            var column = 1;
            for (i = 0; i < list.Count; i++)
            {

                foreach (Issued_Cars item in list)
                //for (j = 0; j < list.Count; j++)
                {
                    ws.Cells[row, column].Value = list[i].Clients.LastName;
                    ws.Cells[row, column + 1].Value = list[i].Clients.FirstName;
                    ws.Cells[row, column + 2].Value = list[i].Clients.MiddleName;
                    ws.Cells[row, column + 3].Value = list[i].Clients.Phone;
                    ws.Cells[row, column + 4].Value = list[i].Clients.SeriaPassport;
                    ws.Cells[row, column + 5].Value = list[i].Clients.NumberPassport;
                    ws.Cells[row, column + 6].Value = list[i].Clients.Birthday;
                    ws.Cells[row, column + 7].Value = list[i].Clients.Phone;
                    ws.Cells[row, column + 8].Value = list[i].Clients.Adress;
                    ws.Cells[row, column + 9].Value = list[i].Cars.Marks;
                    ws.Cells[row, column + 10].Value = list[i].Cars.Model;
                    ws.Cells[row, column + 11].Value = list[i].Cars.Deposit_Amount;
                    row++;
                    i++;
                    j++;
                }
            }
            ws.Cells[row + 1, column + 12].Value = "ИТОГО:";
            ws.Cells[row + 1, column + 13].Value = j.ToString();
            PrintDialog printDialog = new PrintDialog();
            printDialog.PrintVisual(ReporClients, "");
        }
    }
}
