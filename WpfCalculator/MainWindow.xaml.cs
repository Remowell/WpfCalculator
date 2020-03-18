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
        public int indentation = 5;
        public int count = 0;
        public MainWindow()
        {
            InitializeComponent();
            lbl.Content = 0;
        }
        public void PlusClick(object sender, RoutedEventArgs e)
        {
            TextBox box = new TextBox();
            {
                Name = "box" + count;
                Margin = new Thickness(5, indentation, 5, 5);
            }
            box.TextChanged += Text_Changed;
            myStackPanel.Children.Add(box);
            indentation += 1;

            Button delete = new Button()
            {
                Content = "Delete",
                Name = "delete" + count,
                FontSize = 20,
            };
            delete.Click += Delete_Click;
            myStackPanel.Children.Add(delete);
            count++;
        }
        private void Text_Changed(object sender, RoutedEventArgs e)
        {
            int result = 0;
            foreach (var item in myStackPanel.Children)
            {
                if (item is TextBox textInBox)
                {
                    try
                    {
                        int number = int.Parse(textInBox.Text);
                        result += number;
                    }
                    catch
                    {
                        if (textInBox.Text == "") { }
                        else MessageBox.Show("Input normal number");
                    }
                }
            }
            lbl.Content = result;
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Button delete = (Button)sender;
            string deleteName = delete.Name.Substring(6);
            foreach (object element in myStackPanel.Children)
            {
                if (element is TextBox box)
                {
                    if (box.Name.Substring(3).Equals(deleteName))
                    {
                        myStackPanel.Children.Remove(box);
                        myStackPanel.Children.Remove(delete);
                        break;
                    }
                }
            }
            Text_Changed(sender, e);
        }
    }
}
