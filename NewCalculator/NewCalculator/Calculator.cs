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
        private double firstNumberSave;
        private double secondNumberSave;
        private string operation;
        private bool isSecondNumberExist;
        private bool isOperatorButtonPressed;
        private string outputResult = "0";
        private string currentState;
        private string nextOperation;
        private string currentOperation;

        public string OutputResult { get { return outputResult; } set { outputResult = value; } }
        public string Operation { get { return operation; } set { operation = value; } }
        public string CurrentState { get { return currentState; } set { currentState = value; } } 


        //метод, который соединяет значения тегов и сохраняет в строковую переменную
        public void Input(string numberInTag)
        {
            if (outputResultOverFlow() == false)
                return;
            if (isSecondNumberExist)
                Clear(); 
            if (outputResult == "0" && numberInTag != ",")
                outputResult = numberInTag;
            else
            {
                if (outputResult.Contains(",") && numberInTag == ",")
                   outputResult = outputResult + "";
                else
                   outputResult += numberInTag;
            }
        }
        //метод, который присваивает значение второй переменной и добавляет к верхней метке значение второй переменной
        void SecondNumberEnter()
        {
            secondNumberSave = double.Parse(outputResult);
            currentState += secondNumberSave.ToString();
            isSecondNumberExist = true;
        }
        //Метод, который присваивает значение первой переменной и и метке присваивает значение переменной плюс оператор
        void FirstNumberEnter()
        {
            firstNumberSave = double.Parse(outputResult);
            if (operation == "√")
                currentState = operation + "(" + firstNumberSave + ")";
            else if (operation == "1/x")
                currentState = "1÷" + "(" + firstNumberSave + ")";
            else if (operation == "^2" || operation == "^")
                currentState = "(" + firstNumberSave + ") " + operation + " ";
            else
                currentState = firstNumberSave + " " + operation + " ";
        }
        //второй основной метод, в котором производятся операции над переменными в зависимости от значения переменной "operation"
        public void Equals()
        {
                nextOperation = operation;
                operation = currentOperation;
            
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
                     outputResult = "Divide by Zero \n impossible!!!";
                    else
                     outputResult = (firstNumberSave / secondNumberSave).ToString();
                    break;
                case "%":
                    SecondNumberEnter();
                    outputResult = (firstNumberSave / 100 * secondNumberSave).ToString();
                    break;
                case "^2":
                    outputResult = Math.Pow(firstNumberSave, 2).ToString() ;
                    break;
                case "^":
                    SecondNumberEnter();
                    outputResult = Math.Pow(firstNumberSave, (double)secondNumberSave).ToString();
                    break;
                case "√":
                    if (firstNumberSave < 0)
                        outputResult = "Not A Number!!!";
                    else
                        outputResult = Math.Sqrt(firstNumberSave).ToString();
                    break;
                case "1/x":
                    outputResult = (1 / firstNumberSave).ToString();
                    break;
                default:
                    break;
            }
            isSecondNumberExist = true;
            isOperatorButtonPressed = false;
            operation = nextOperation;
            if (outputResult == "Divide by Zero \n impossible!!!" || outputResult == "Not A Number!!!")
                return;
            outputResult = outputResultCheckLenght(double.Parse(outputResult));
            outputResult = (Math.Round(double.Parse(outputResult), 10)).ToString();
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
                if (outputResult == "Divide by Zero \n impossible!!!" || outputResult == "Not A Number!!!")
                {
                    outputResult = "0";
                }
                if (firstNumberSave != 0 && outputResult != "" && isSecondNumberExist == false 
                    && isOperatorButtonPressed)
                {
                    Equals();
                }
                FirstNumberEnter();
                isSecondNumberExist = false;
                if(operation== "1/x" || operation == "^2" || operation == "√")
                {  
                    outputResult = outputResult + "";
                    isSecondNumberExist = true;
                }
                else
                {
                    outputResult = "";
                }
               isOperatorButtonPressed = true;
               currentOperation = operation;
            }
        }
        //метод, который проверяет длину строки и возвращает ее в виде экспоненциального формата,
        //если слишком большое или слишком маленькое, или в обычном формате если не превышает ограничений.
        private string outputResultCheckLenght(double length)
        {
            if (length.ToString().Length > 15)
            {
                if (length > 999999999999999)
                    return length.ToString("E10");
                else
                    return length.ToString("G");
            }
            else
            {
                return length.ToString();
            }
        }
        //Метод, который проверяет outputResult на переполнение и возвращает false методу Input, если переполнено
        private bool outputResultOverFlow()
        {
            if (outputResult.Length > 18)
                return false;
            else
                return true;
        }
    }
}

