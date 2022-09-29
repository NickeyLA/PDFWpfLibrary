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
    /// <summary>
    /// Логика взаимодействия для TestResult.xaml
    /// </summary>
    public partial class TestResult : Page
    {
        private int element_pub;
        public TestResult(int score, int element)
        {
            InitializeComponent();
            
            element_pub = element;

            Score.Content = "Количество правильных ответов " + score + " из 4";
            if (score == 4)
            {
                Result.Content = "Вы прошли тест" ;
                Result.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("Green"));
                NavigatePage.ListTest[$"test{1 + ((element+1) / 4)}"] = true;
                TestsListObject.Save();
            }
            else
            {
                Result.Content = "Вы не прошли тест";
                Result.Foreground = new SolidColorBrush( (Color)ColorConverter.ConvertFromString("Red"));;
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NavigatePage());
        }

        private void Button_Click_Next(object sender, RoutedEventArgs e)
        {
            if (NavigatePage.ListTest[$"test{1 + ((element_pub + 1) / 4)}"] == true)
            {
                NavigationService.Navigate(new ReaderPDF(DocType.PDF,  1 + (element_pub / 4)));
            }
            else
            {
                MessageBox.Show("Пройдите предыдущий тест!");
            }
        }
    }
}
