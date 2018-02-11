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

namespace NewCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Calculator calc;

        public MainWindow()
        {
            InitializeComponent();
            calc = new Calculator();
        }
        private void Update()
        {
            outputLabel.Content = calc.OutputResult;
            actualLabel.Content = calc.CurrentState;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button pressedButton = (Button)sender;
            string BtnTag = pressedButton.Tag.ToString();
            calc.Input(BtnTag);
            Update();
        }

        private void ButtonOperator_Click(object sender, RoutedEventArgs e)
        {
            Button operatorButton = (Button)sender;
            calc.Operation = operatorButton.Tag.ToString();
            calc.Operator();
            Update();
        }

        private void ButtonEquals_Click(object sender, RoutedEventArgs e)
        {
            calc.Equals();
            Update();
        }

        private void ButtonErase_Click(object sender, RoutedEventArgs e)
        {
            calc.Erase();
            Update();
        }

        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            calc.Clear();
            Update();
        }

        private void ButtonMinus_Click(object sender, RoutedEventArgs e)
        {
            calc.ButtonMinusPressed();
            Update();
        }
    } 
}
