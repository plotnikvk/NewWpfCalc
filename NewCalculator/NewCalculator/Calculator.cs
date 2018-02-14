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
    class Calculator
    {
        private decimal firstNumberSave;
        private decimal secondNumberSave;
        private string operation;
        private bool isSecondNumberExist;
        private bool isOperatorButtonPressed;
        private string outputResult = "0";
        private string currentState;

        public string OutputResult { get { return outputResult; } set { outputResult = value; } }
        public string Operation { get { return operation; } set { operation = value; } }
        public string CurrentState { get { return currentState; } set { currentState = value; } }

        //метод, который соединяет значения тегов и сохраняет в строковую переменную
        public void Input(string numberInTag)
        {
            if (isSecondNumberExist)
            {
                Clear(); 
            }
            if (outputResult == "0" && numberInTag != ",")
            {
                outputResult = numberInTag;
            }
            else
            {
                if (outputResult.Contains(",") && numberInTag == ",")
                {
                    outputResult = outputResult + "";
                }
                else
                {
                    outputResult += numberInTag;
                }
            }
        }
        //метод, который присваивает значение второй переменной и добавляет к верхней метке значение второй переменной
        void SecondNumberEnter()
        {
            secondNumberSave = decimal.Parse(outputResult);
            currentState += secondNumberSave.ToString();
            isSecondNumberExist = true;
        }
        //второй основной метод, в котором производятся операции над переменными в зависимости от значения переменной "operation"
        public void Equals()
        {
            switch (operation)
            {
                case "+":
                    SecondNumberEnter();
                    outputResult = (firstNumberSave + secondNumberSave).ToString();
                    break;
                case "-":
                    SecondNumberEnter();
                    outputResult = (firstNumberSave - secondNumberSave).ToString();
                    break;
                case "×":
                    SecondNumberEnter();
                    outputResult = (firstNumberSave * secondNumberSave).ToString();
                    break;
                case "÷":
                    SecondNumberEnter();
                    if (secondNumberSave == 0)
                    {
                     outputResult = "Divide by Zero \n impossible!!!";
                    }
                    else
                    {
                     outputResult = (firstNumberSave / secondNumberSave).ToString();
                    }
                    break;
                case "%":
                    SecondNumberEnter();
                    outputResult = (firstNumberSave / 100 * secondNumberSave).ToString() + "%";
                    break;
                case "^2":
                    outputResult = Math.Pow((double)firstNumberSave, 2).ToString() ;
                    break;
                case "^":
                    SecondNumberEnter();
                    outputResult = Math.Pow((double)firstNumberSave, (double)secondNumberSave).ToString();
                    break;
                case "√":
                    outputResult = Math.Sqrt((double)firstNumberSave).ToString();
                    break;
                case "1/x":
                    outputResult = (1 / firstNumberSave).ToString();
                    break;
                default:
                    break;
            }
            isSecondNumberExist = true;
            isOperatorButtonPressed = false;
        }
        //метод, который добавляет минус перед строкой из цифр
        public void ButtonMinusPressed()
        {
            outputResult =((-1)*decimal.Parse(outputResult)).ToString();
        }
        //метод, который делает полный сброс к начальным настройкам
        public void Clear()
        {
            firstNumberSave = 0;
            secondNumberSave = 0;
            isSecondNumberExist = false;
            isOperatorButtonPressed = false;
            outputResult = "0";
            currentState = "";
        }
        //метод, который стирает последнюю введенную цифру
        public void Erase()
        {
            if (outputResult != "0")
            {
                if (outputResult.Length == 1)
                {
                    outputResult = "0";
                }
                else if (outputResult.Length > 0)
                {
                    outputResult = outputResult.Substring(0, outputResult.Length - 1);
                }
            }
        }
        //первый основной метод, который присваивает значение первой переменной, а также присваивает 
        //значение первой переменной и знака операции верхней метке
        public void Operator()
        {
            if (outputResult != "")
            {
                if (outputResult == "Divide by Zero \n impossible!!!")
                {
                    outputResult = "0";
                }
                if (firstNumberSave != 0 && outputResult != "" && isSecondNumberExist == false && isOperatorButtonPressed)
                {
                    Equals();
                    //this.Operator();
                }
                    firstNumberSave = decimal.Parse(outputResult);
                    if (operation == "√")
                    {
                        currentState = operation + firstNumberSave;
                    }
                    else if(operation == "1/x")
                    {
                        currentState = "1÷" + firstNumberSave;
                    }
                    else
                    {
                        currentState = firstNumberSave + " " + operation + " ";
                    }
                    isSecondNumberExist = false;
                    outputResult = "";

                    isOperatorButtonPressed = true;
            }
        }
        
    }
}

