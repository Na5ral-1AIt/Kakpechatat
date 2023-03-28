using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace kaLk
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();
        }

        private string _output;
        public string Output { get { return _output; } set { if (_output != value) { _output = value; OnPropertyChanged(); }; } }
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Button_1_Click(object sender, RoutedEventArgs e)
        {
            string str = "1";
            Output += str;
        }

        private void Button_2_Click(object sender, RoutedEventArgs e)
        {
            string str = "2";
            Output += str;
        }

        private void Button_3_Click(object sender, RoutedEventArgs e)
        {
            string str = "3";
            Output += str;
        }

        private void Button_4_Click(object sender, RoutedEventArgs e)
        {
            string str = "4";
            Output += str;
        }

        private void Button_5_Click(object sender, RoutedEventArgs e)
        {
            string str = "5";
            Output += str;
        }

        private void Button_6_Click(object sender, RoutedEventArgs e)
        {
            string str = "6";
            Output += str;
        }

        private void Button_7_Click(object sender, RoutedEventArgs e)
        {
            string str = "7";
            Output += str;
        }

        private void Button_8_Click(object sender, RoutedEventArgs e)
        {
            string str = "8";
            Output += str;
        }

        private void Button_9_Click(object sender, RoutedEventArgs e)
        {
            string str = "9";
            Output += str;
        }

        private void Button_0_Click(object sender, RoutedEventArgs e)
        {
            string str = "0";
            Output += str;
        }
        private void Button_plus_Click(object sender, RoutedEventArgs e)
        {
            if (Output != null)
            {
                if (Output.Length > 0)
                {
                    if (Output[^1] != '+' && Output[^1] != '-' && Output[^1] != '/' && Output[^1] != '*' && Output[^1] != ',')
                    {
                        string str = "+";
                        Output += str;
                    }
                }
            }
        }

        private void Button_minus_Click(object sender, RoutedEventArgs e)
        {
            if (Output == "" || Output == null)
            {
                string str = "-";
                Output += str;
            }
            else
            {
                if (Output[^1] != '+' && Output[^1] != '-' && Output[^1] != '/' && Output[^1] != '*' && Output[^1] != ',')
                {
                    string str = "-";
                    Output += str;
                }
            }
        }

        private void Button_multiply_Click(object sender, RoutedEventArgs e)
        {
            if (Output != null && Output != "")
            {
                if (Output.Length > 0)
                {
                    if (Output[^1] != '+' && Output[^1] != '-' && Output[^1] != '/' && Output[^1] != '*' && Output[^1] != ',')
                    {
                        string str = "*";
                        Output += str;
                    }
                }
            }
        }

        private void Button_divide_Click(object sender, RoutedEventArgs e)
        {
            if (Output != null)
            {
                if (Output.Length > 0)
                {
                    if (Output[^1] != '+' && Output[^1] != '-' && Output[^1] != '/' && Output[^1] != '*' && Output[^1] != ',')
                    {
                        string str = "/";
                        Output += str;
                    }
                }
            }
        }

        private void Button_dot_Click(object sender, RoutedEventArgs e)
        {
            if (Output != null)
            {
                if (Output.Length > 0)
                {
                    if (Output[^1] != '+' && Output[^1] != '-' && Output[^1] != '/' && Output[^1] != '*' && Output[^1] != ',')
                    {
                        string str = ",";
                        Output += str;
                    }
                }
            }
        }

        private void Button_leftbracket_Click(object sender, RoutedEventArgs e)
        {
            string str = "(";
            Output += str;
        }

        private void Button_rightbracket_Click(object sender, RoutedEventArgs e)
        {
            string str = ")";
            Output += str;
        }

        private void Button_backspace_Click(object sender, RoutedEventArgs e)
        {
            if (Output != "" && Output != null)
            Output = new string(math2.DeleteE(Output.ToCharArray(), Output.Length));
        }

        private void Button_C_Click(object sender, RoutedEventArgs e)
        {
            Output = "";
        }

        public double[] NUMBERS;
        public char[] OPERATS;
        Mathcal2 math2 = new Mathcal2();
        private void Button_equal_Click(object sender, RoutedEventArgs e)
        {
            if (Output != null && Output != "0" && Output != "")
            {
                //NUMBERS = math.ParserN(Output);
                //OPERATS = math.ParserC(Output);
                //string result = Convert.ToString(math.Calculate(NUMBERS, OPERATS));

                string result = Convert.ToString(math2.Calculate(Output));
                Output = result;
            }
        }

    }
}