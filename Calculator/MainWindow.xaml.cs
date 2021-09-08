using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Data;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool _ { get; set; } = true;
        public MainWindow()
        {
            InitializeComponent();

        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            if(sender is Button btn)
            {
                if (int.TryParse(btn.Content.ToString(), out int res))
                {
                    if (_)
                    {
                        Screen.Text = res.ToString();
                        _ = false;
                    }
                    else Screen.Text += res.ToString();
                }
                else if (btn.Name == "C") Screen.Text = "";
                else if (btn.Name == "Equal")
                {
                    Screen.Text = Calculate();
                    _ = true;
                }
                else
                {
                    if (btn.Content.ToString() == "+") Screen.Text += "+";
                    if (btn.Content.ToString() == "-") Screen.Text += "-";
                    if (btn.Content.ToString() == "×") Screen.Text += "*";
                    if (btn.Content.ToString() == "÷") Screen.Text += "/";
                    if (btn.Content.ToString() == ".") Screen.Text += ".";
                    if (btn.Content.ToString() == "x^2") Screen.Text += "*" + Screen.Text;
                    //if (btn.Content.ToString() == "+/-") if (Screen.Text[0].ToString() == "-") Screen.Text[0] = "";
                    _ = false;
                }
                
            }
        }

        private string Calculate()
        {
            DataTable dt = new DataTable();
            return dt.Compute(Screen.Text, "").ToString();
        }

    }
}
