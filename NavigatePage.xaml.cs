using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace PDFWpfLIbrary
{
    [Serializable]
    public partial class NavigatePage : Page
    {
        public static Dictionary<string, bool> ListTest {
            get=> TestsListObject.Tests;
        }

        SolidColorBrush graycolor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Gray"));

        public NavigatePage()
        {
            InitializeComponent();
            Load();
            

            for (int i = 0; i < 25; i++)
            {
                int it = i;
                ((Label)FindName($"test{1 + it}")).PreviewMouseDown += (o, e) =>
                {
                    if (ListTest[$"test{1 + it}"] == true)
                    {
                        NavigationService.Navigate(new TestPage(it * 4, 0, 0));
                    }
                    else
                    {
                        MessageBox.Show("Пройдите предыдущий тест!");
                    }
                };
            }

            for (int i = 0; i < 25; i++)
            {
                int its = i;
                ((Label)FindName($"label{1 + its}")).PreviewMouseDown += (o, e) =>
                {
                    if (ListTest[$"test{1 + its}"] == true)
                    {
                        NavigationService.Navigate(new ReaderPDF(DocType.PDF, its));
                    }
                    else
                    {
                        MessageBox.Show("Пройдите предыдущий тест!");
                    }
                };
            }
        }

        public void Load()
        {
            ListTest[$"test1"] = true;
            for (int i = 0; i < 25; i++)
            {
                if (ListTest[$"test{1 + i}"] == false)
                {
                    ((Label)this.FindName($"test{1 + i}")).Foreground = graycolor;
                    ((Label)this.FindName($"label{1 + i}")).Foreground = graycolor;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TestsListObject.Clear();
            Load();
        }
    }
}
