using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace CurrecyConverter_Static
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<string, double> myTable = new Dictionary<string, double>()
        {
            { "TRY",1 },
            { "EUR",30 },
            { "DOL",27 },
        };

        public MainWindow()
        {
            InitializeComponent();
            cFromCurrency.ItemsSource= myTable.Keys;
            cFromCurrency.SelectedIndex=0;
            cToCurrency.ItemsSource = myTable.Keys;
            cToCurrency.SelectedIndex=2;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(myInput.Text))
            {
                string myAns=myInput.Text;
                string myTo= (string)cToCurrency.SelectedItem;
                string myFrom= (string)cFromCurrency.SelectedItem;
                double converter= myTable[myFrom] / myTable[myTo];
                double myDouble = Math.Round(double.Parse(myAns)*converter,4);
                cResult.Text = (string)cToCurrency.SelectedItem +" " +myDouble.ToString();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            cFromCurrency.SelectedIndex = 0;
            cToCurrency.SelectedIndex = 2;
            myInput.Text = "";
            cResult.Text = "";
        }
    }
}
