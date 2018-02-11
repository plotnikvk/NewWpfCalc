namespace NewCalculator
{
    class Calculator
    {
        private decimal firstNumberSave;
        private decimal secondNumberSave;
        private string operation;
        private bool isSecondNumberExist;
        private string outputResult = "0";
        private string currentState;

        public string OutputResult { get { return outputResult; } set { outputResult = value; } }
        public string Operation { get { return operation; } set { operation = value; } }
        public string CurrentState { get { return currentState; } set { currentState = value; } }

        public void Input(string numberInTag)
        {
            if (isSecondNumberExist)
            {
                firstNumberSave = 0;
                secondNumberSave = 0;
                isSecondNumberExist = false;
                outputResult = "";
            }

            if (outputResult == "0" && numberInTag != ",")
            {
                outputResult = numberInTag;
            }
            else
            {
                outputResult += numberInTag;
            }
        }

        public void Equals()
        {
            secondNumberSave = decimal.Parse(outputResult);
            currentState += secondNumberSave.ToString();
            switch (operation)
            {
                case "+":
                    outputResult = (firstNumberSave + secondNumberSave).ToString();
                    break;
                case "-":
                    outputResult = (firstNumberSave - secondNumberSave).ToString();
                    break;
                case "*":
                    outputResult = (firstNumberSave * secondNumberSave).ToString();
                    break;
                case "/":
                    if (secondNumberSave == 0)
                    {
                     outputResult = "Деление на ноль \n невозможно!!!";
                    }
                    else
                    {
                     outputResult = (firstNumberSave / secondNumberSave).ToString();
                    }
                    break;
                case "%":
                    outputResult = (firstNumberSave / 100 * secondNumberSave).ToString() + "%";
                    break;
                case "±":
                    outputResult = "-" + outputResult;
                    break;
                case ",":
                      if (outputResult.Contains(","))
                            Input(",");
                    break;
                default:
                    break;
            }
        }
        public void Clear()
        {
            firstNumberSave = 0;
            secondNumberSave = 0;
            outputResult = "0";
            currentState = "";
        }
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
        public void Operator()
        {
            if (outputResult != "")
            {
                if (outputResult == "Деление на ноль \n невозможно!!!")
                {
                    outputResult = "0";
                }
                if (firstNumberSave != 0 && outputResult != "")
                {
                    Equals();
                }
                if (operation == ",")
                {
                    outputResult = outputResult + ",";
                }
                else
                {
                    firstNumberSave = decimal.Parse(outputResult);
                    currentState = firstNumberSave.ToString() + " " + operation + " ";

                    isSecondNumberExist = false;
                    outputResult = "";
                }
            }
        }
        public void DotClick()
        { 
           
            if (operation == ",")
            {
                if (outputResult.Contains(","))
                    Input(",");

            }
        }
    }
}

