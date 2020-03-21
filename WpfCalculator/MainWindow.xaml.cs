using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public int number;
        public MainWindow()
        {
            InitializeComponent();
            lbl.Content = 0;
        }

        public void PlusClick(object sender, RoutedEventArgs e)
        {
            StackPanel newStack = new StackPanel()
            {
                Name = "newStack" + count
            };
            myStackPanel.Children.Add(newStack);

            ComboBox comboBox = new ComboBox();
            newStack.Children.Add(comboBox);

            ObservableCollection<string> operations = new ObservableCollection<string>();
            operations.Add("+");
            operations.Add("-");
            operations.Add("*");
            operations.Add("/");
            comboBox.ItemsSource = operations;

            TextBox box = new TextBox();
            {
                Margin = new Thickness(5, indentation, 5, 5);
            }
            box.TextChanged += Text_Changed;
            newStack.Children.Add(box);
            indentation += 1;

            Button delete = new Button()
            {
                Content = "Delete",
                Name = "delete" + count,
            };
            delete.Click += Delete_Click;
            newStack.Children.Add(delete);
            count++;
        }
        int result = 0;
        private void Text_Changed(object sender, RoutedEventArgs e)
        { 
            foreach (var item in myStackPanel.Children)
            {
                if (item is StackPanel stackPanel)
                {
                    TextBox textBox = FindTextBox(stackPanel);
                    ComboBox comboBox = FindComboBox(stackPanel);
                    try
                    {
                        number = int.Parse(textBox.Text);
                    }
                    catch
                    {
                        if (textBox.Text == "") { }
                        else MessageBox.Show("Input normal number");
                    }
                    switch (comboBox.SelectedItem)
                    {
                        case "+":
                            result += number;
                            break;
                        case "-":
                            result -= number;
                            break;
                        case "*":
                            result *= number;
                            break;
                        case "/":
                            result /= number;
                            break;
                    }
                }
            }
            lbl.Content = result;
            result = 0;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Button delete = (Button)sender;
            foreach (object element in myStackPanel.Children)
            {
                if (element is StackPanel stackPanel)
                {
                    if (delete.Name.Substring(6) == stackPanel.Name.Substring(8))
                    {
                        myStackPanel.Children.Remove(stackPanel);
                        break;
                    }
                }
            }
            Text_Changed(sender, e);
        }
        TextBox FindTextBox(StackPanel stackPanel)
        {
            foreach (var item in stackPanel.Children)
                if (item is TextBox)
                    return item as TextBox;
            return null;
        }
        ComboBox FindComboBox(StackPanel stackPanel)
        {
            foreach (var item in stackPanel.Children)
                if (item is ComboBox)
                    return item as ComboBox;
            return null;
        }
    }
}
