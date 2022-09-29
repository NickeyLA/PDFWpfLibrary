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
using System.Threading;

namespace PDFWpfLIbrary
{
    public partial class TestPage : Page
    {
        public IEnumerable<TestElement> _testElements = GetQuestions.TestElements;
        private int rndNum;

        public int score;
        public int element_pub;
        public int iter;
        int amount;

        public string[] AllAnswer;


        public TestPage(int element, int scor, int ite)
        {
            InitializeComponent();

            NavigatePage.ListTest["test1"] = false;

            iter = ite;
            score = scor;
            element_pub = element;
            amount = _testElements.ElementAt(element).Opinions.Length + 1;

            AllAnswer = new string[amount];
            
            Random rand = new Random();

            rndNum = rand.Next(0, amount);

            AllAnswer[rndNum] = _testElements.ElementAt(element).RightOpinion;

            int i = 0;
            foreach (var item in _testElements.ElementAt(element).Opinions)
            {
                if (AllAnswer[i] == null)
                {
                    AllAnswer[i] = item;
                }
                else
                {
                    i++;
                    AllAnswer[i] = item;
                }
                i++;
            }

            Question.Content = _testElements.ElementAt(element).Question;



            Radio1.Content = AllAnswer[0];
            Radio2.Content = AllAnswer[1];

            if (amount < 3)
            {
                Radio3.Height = 0;
                Radio3.Width = 0;
                
            }
            else
            {
                Radio3.Content = AllAnswer[2];
            }
            if (amount < 4)
            {
                Radio4.Height = 0;
                Radio4.Width = 0;
                
            }
            else
            {
                Radio4.Content = AllAnswer[3];
            }

        }

        private void Button_ClickNext(object sender, RoutedEventArgs e)
        {
            if (Radio1.IsChecked == true && Convert.ToString(Radio1.Content) == Convert.ToString(AllAnswer[rndNum]))
            {
                score++;
            }
            if (Radio2.IsChecked == true && Convert.ToString(Radio2.Content) == Convert.ToString(AllAnswer[rndNum]))
            {
                score++;
            }
            if (Radio3.IsChecked == true && Convert.ToString(Radio3.Content) == Convert.ToString(AllAnswer[rndNum]))
            {
                score++;
            }
            if (Radio4.IsChecked == true && Convert.ToString(Radio4.Content) == Convert.ToString(AllAnswer[rndNum]))
            {
                score++;
            }


            NavigationService.Navigate(new TestPage(element_pub+1, score, iter+1));
            if (iter == 3)
            {
                NavigationService.Navigate(new TestResult(score, element_pub));
            }
        }

        private void Button_ClickStop(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new TestResult(score, element_pub));
        }
    }
}
