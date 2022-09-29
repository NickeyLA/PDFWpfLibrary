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
using CefSharp;
using System.Diagnostics;

namespace PDFWpfLIbrary
{
    /// <summary>
    /// Логика взаимодействия для ReaderPDF.xaml
    /// </summary>
    public partial class ReaderPDF : Page
    {
        private DocType _docType;
        private int i_pub;
        public ReaderPDF(DocType docType, int i)
        {
            i_pub = i;
            InitializeComponent();
            _docType = docType;
            browser.BeginInit();

            IEnumerable<string> t = GetPath.GetTitles(_docType);


            var title = t.ElementAt(i);

            var path = GetPath.GetKeys(title, _docType);
            var fullPath = ("file:///" + System.IO.Path.Combine(Environment.CurrentDirectory, @"PDF\", path)).Replace(@"\", "/").Replace(" ", "%20") + "#toolbar=0&navpanes=0&scrollbar=0";
            browser.Address = fullPath;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NavigatePage());
        }


        private void Button_Click_Next(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TestPage(i_pub * 4, 0, 0));
        }
    }
}