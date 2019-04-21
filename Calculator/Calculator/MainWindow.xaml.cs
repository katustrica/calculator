using System;
using System.Windows;
using System.Windows.Controls;

namespace Calculator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Grid_Click(object sender, RoutedEventArgs e)
        {
            Button btn = e.Source as Button;
            if (btn == null)
                return;
            string value = btn.Content.ToString();
            if (String.IsNullOrEmpty(value))
                return;
            switch (value)
            {
                case "C":
                    TextBox.Text = "0";
                    break;
                case "=":
                    try
                    {
                        NCalc.Expression Expression = new NCalc.Expression(TextBox.Text);
                        TextBox.Text = Expression.Evaluate().ToString();
                    }
                    catch
                    {
                        TextBox.Text = "Error";
                    }
                    break;
                case "Стереть":
                    TextBox.Text = TextBox.Text.Substring(0, TextBox.Text.Length - 1);
                    break;
                default:
                    TextBox.Text = TextBox.Text.TrimStart('0') + value;
                    break;
            }
        }
    }
}