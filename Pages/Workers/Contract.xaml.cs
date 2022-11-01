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

namespace Autoprokat.Pages.Workers
{
    /// <summary>
    /// Логика взаимодействия для Contract.xaml
    /// </summary>
    public partial class Contract : Page
    {
        public Contract()
        {
            InitializeComponent();
        }


        private void load_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "XPS Files (*.xps)|*.xps|All files (*.*)|*.*";

            if (ofd.ShowDialog() == true)
            {
                XpsDocument doc = new XpsDocument(ofd.FileName, FileAccess.Read);

            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "XPS Files (*.xps)|*.xps";
            if (sfd.ShowDialog() == true)
            {
                XpsDocument doc = new XpsDocument(sfd.FileName, FileAccess.Write);
                XpsDocumentWriter writer = XpsDocument.CreateXpsDocumentWriter(doc);
                writer.Write(documentViewer.Document as FixedDocument);
                doc.Close();
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
