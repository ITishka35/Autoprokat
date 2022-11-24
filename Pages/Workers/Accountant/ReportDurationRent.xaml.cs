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
using OfficeOpenXml.Style;

namespace Autoprokat.Pages.Workers.Accountant
{
    /// <summary>
    /// Логика взаимодействия для ReportDurationRent.xaml
    /// </summary>
    public partial class ReportDurationRent : System.Windows.Controls.Page
    {
        private Application application;
        private Workbook workBook;
        private Worksheet worksheet;
        public ReportDurationRent()
        {
            InitializeComponent();
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
            string path = Path.Combine(@"C:\Users\Maria & Vlad\source\repos\Autoprokat\bin\Debug\", template3);
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
                    ws.Cells[row, column].Value = list[i].Cars.Color;
                    ws.Cells[row, column + 1].Value = list[i].Cars.Marks;
                    ws.Cells[row, column + 2].Value = list[i].Cars.Model;
                    ws.Cells[row, column + 3].Value = list[i].Date_Issue;
                    ws.Cells[row, column + 4].Value = list[i].Cars.Deposit_Amount;
                    row++;
                    i++;
                }
            }
            PrintDialog printDialog = new PrintDialog();
            printDialog.PrintVisual(ReporClients, "");
        }
    }
}

