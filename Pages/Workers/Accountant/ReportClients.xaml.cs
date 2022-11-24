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
    /// Логика взаимодействия для ReportClients.xaml
    /// </summary>
    public partial class ReportClients : System.Windows.Controls.Page
    {

        private Application application;
        private Workbook workBook;
        private Worksheet worksheet;

        //private ExcelFile workbook;
        public ReportClients()
        {
            InitializeComponent();
            AppConnect.model = new CarsProkatEntities();
            //SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
            ReporClients.ItemsSource = AppConnect.model.Issued_Cars.ToArray();



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
            var row = 6;
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

            //for (int i = 0; i < list.Count; i++)
            //{
            //    ws.Range["A1"].Value = list[i].Clients.LastName;
            //    ws.Range["B1"].Value = list[i].Clients.FirstName;
            //    ws.Range["C1"].Value = list[i].Clients.MiddleName;
            //    ws.Range["G1"].Value = list[i].Clients.Phone;
            //}
            //ws.Range["A4"].Value = Classes.HelpClassClients.FirstName;
            //ws.Range["A5"].Value = Classes.HelpClassClients.MiddleName;
            //ws.Range["B6"].Value = "Tommorow's date is: =>";
            //ws.Range["C6"].FormulaLocal = "= A5 + 1";
            //ws.Range["A7"].FormulaLocal = "=SUM(D1:D10)";
            //for (int i = 1; i <= 10; i++)
            //    ws.Range["D" + i].Value = i * 2;

            //workBook.SaveAs($"{Environment.CurrentDirectory}\\TEST.xlsx");
            PrintDialog printDialog = new PrintDialog();
            printDialog.PrintVisual(ReporClients, "");
            //Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            //app.Visible = true;
            //app.WindowState = XlWindowState.xlMaximized;

            //const string template3 = "StraxLifeShabl.xls";
            //Workbook wb = app.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            //wb = application.Workbooks.Open(System.IO.Path.Combine(Environment.CurrentDirectory, template3));

            //Worksheet ws = wb.Worksheets[1];
            //DateTime currentDate = DateTime.Now;

            //ws.Range["A1:A3"].Value = Classes.HelpClassClients.LasName;
            //ws.Range["A4"].Value = Classes.HelpClassClients.FirstName;
            //ws.Range["A5"].Value = Classes.HelpClassClients.MiddleName;
            //ws.Range["B6"].Value = "Tommorow's date is: =>";
            //ws.Range["C6"].FormulaLocal = "= A5 + 1";
            //ws.Range["A7"].FormulaLocal = "=SUM(D1:D10)";
            //for (int i = 1; i <= 10; i++)
            //    ws.Range["D" + i].Value = i * 2;

            //wb.SaveAs("C:\\Maria & Vlad\\repos\\TEST.xlsx");
            ////PrintDialog printDialog = new PrintDialog();
            ////printDialog.PrintVisual(ReportClients, "");
            //if (this.workbook == null)
            //    return;

            //PrintDialog printDialog = new PrintDialog() { UserPageRangeEnabled = true };
            //if (printDialog.ShowDialog() == true)
            //{
            //    PrintOptions printOptions = new PrintOptions(printDialog.PrintTicket.GetXmlStream())
            //    {
            //        SelectionType = SelectionType.EntireFile
            //    };

            //    printOptions.FromPage = printDialog.PageRange.PageFrom - 1;
            //    printOptions.ToPage = printDialog.PageRange.PageTo == 0 ? int.MaxValue : printDialog.PageRange.PageTo - 1;

            //    this.workbook.Print(printDialog.PrintQueue.FullName, printOptions);
            //}

        }

        private void btn_load_Click(object sender, RoutedEventArgs e)
        {

        }
    }
   
}
