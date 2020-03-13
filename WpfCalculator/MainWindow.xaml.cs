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

namespace WpfCalculator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            lbl.Content = 0;
        }

        private void PlusClick(object sender, RoutedEventArgs e)
        {
            TextBox box = new TextBox();
            box.TextChanged += Text_Changed;
            myGrid.Children.Add(box);
            box.Width = 100;
            box.Height = 50;
        }
        private void Text_Changed(object sender, RoutedEventArgs e)
        {
            int result = 0;
            foreach (var item in myGrid.Children)
            {
                if (item is TextBox textInBox)
                {
                    if
                        (int.TryParse(textInBox.Text, out var number)) ;
                    else 
                        MessageBox.Show("Input normal number");
                    result += number;
                }
            }
            lbl.Content = result;
        }
    }
}
