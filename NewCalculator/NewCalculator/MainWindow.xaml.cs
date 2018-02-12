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
        //Экземпляр класса Calculator
        Calculator calc;

        public MainWindow()
        {
            InitializeComponent();
            calc = new Calculator();
        }
        //метод, обновляющий метки
        private void Update()
        {
            outputLabel.Content = calc.OutputResult;
            actualLabel.Content = calc.CurrentState;
        }
        //метод для всех кнопок с цифрами
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button pressedButton = (Button)sender;
            string BtnTag = pressedButton.Tag.ToString();
            calc.Input(BtnTag);
            Update();
        }
        //метод для кнопок операторов
        private void ButtonOperator_Click(object sender, RoutedEventArgs e)
        {
            Button operatorButton = (Button)sender;
            calc.Operation = operatorButton.Tag.ToString();
            calc.Operator();
            Update();
        }
        //метод для кнопки равно
        private void ButtonEquals_Click(object sender, RoutedEventArgs e)
        {
            calc.Equals();
            Update();
        }
        //метод для кнопки стирания последней цифры
        private void ButtonErase_Click(object sender, RoutedEventArgs e)
        {
            calc.Erase();
            Update();
        }
        //метод для кнопки очиски
        private void ButtonClear_Click(object sender, RoutedEventArgs e)
        {
            calc.Clear();
            Update();
        }
        //метод для кнопки отрицательного числа
        private void ButtonMinus_Click(object sender, RoutedEventArgs e)
        {
            calc.ButtonMinusPressed();
            Update();
        }
        //метод для кнопки с запятой
        private void ButtonDot_Click(object sender, RoutedEventArgs e)
        {
            Button btnDotPressed = (Button)sender;
            calc.BtnDot = btnDotPressed.Tag.ToString();
            calc.ButtonDotPressed();
            Update();
        }
    } 
}
