using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using WinAppTask.Enums;
using WinAppTask.Pages.BaseClass;

namespace WinAppTask.Pages.ScientificCalculatorPage;
public partial class CalculatorStandardPage : CalculatorPageObject
{

    private readonly WindowsDriver<WindowsElement> _driver;
    public CalculatorStandardPage(WindowsDriver<WindowsElement> driver) => _driver = driver;

    public void PerformCalculation(string num1, char option, string num2)
    {
        ClearCalcInput();
        PickNumericValue(num1);
        PerformOperation(option);
        PickNumericValue(num2);
        EqualButton.Click();

    }

    public void PerformSquareCantimetersCalculation(string num1, string num2)
    {
        ClearCalcInput();
        PickNumericValue(num1);
        DivideButton.Click();
        PickNumericValue(num2);
        ZeroButton.Click();
        ZeroButton.Click();
        ZeroButton.Click();
        EqualButton.Click();
    }

    protected AppiumWebElement GetResultElement()
    {
        var result = CalculatorResultButton;
        return result;
    }

    protected AppiumWebElement GetResultElementTemp()
    {
        var result = OutputValueDegreeButton;
        return result;
    }

    protected string ResultText => GetResultElement().Text.Replace("Display is", string.Empty).Replace("point", string.Empty).Trim();
    protected string ResultTextTemp => GetResultElementTemp().Text.Replace("Converts into ", string.Empty).Replace(TemperatureScale.Fahrenheit.ToString(), string.Empty).Trim();
    protected string ResultTextWeitght => GetResultElementTemp().Text.Replace("Converts into ", string.Empty).Replace(" Pounds", string.Empty).Trim();
    protected string ResultTextDays => GetResultElementTemp().Text.Replace("Converts into ", string.Empty).Replace(" Seconds", string.Empty).Trim();
    protected string ResultBytesToGigabytes => GetResultElementTemp().Text.Replace("Converts into ", string.Empty).Replace(" Gigabytes", string.Empty).Trim();
    protected string GetCalculatorResultText() => CalculatorResultButton.Text.Replace("Display is", string.Empty).Trim();

    public void ConvertTemperatures(string num2)
    {
        Clear();
        InputUnitButton.SendKeys(TemperatureScale.Celsius.ToString());
        PickNumericValue(num2);
        OutputUnitButton.SendKeys(TemperatureScale.Fahrenheit.ToString());
    }

    public void ConvertFromKilogramsToPounds(string num2)
    {
        Clear();
        InputUnitButton.SendKeys("Kilograms");
        PickNumericValue(num2);
        OutputUnitButton.SendKeys("Pounds");
    }

    public void ConvertBetweenBytesAndGigabytes(string num1)
    {
        Clear();
        InputUnitButton.SendKeys("Bytes");
        PickNumericValue(num1);
        OutputUnitButton.SendKeys("Gigabytes");
    }

    public void ConvertBetweenDaysAndSeconds(string num1)
    {
        Clear();
        InputUnitButton.SendKeys("Days");
        PickNumericValue(num1);
        OutputUnitButton.SendKeys("Seconds");

    }

    protected void ClearCalcInput() => ClearCalcInputButton.Click();
    protected void Clear() => ClearEntryButton.Click();

    public void ExecuteFormulaFormula(string n, string x, string y)
    {
       ClearCalcInput();
       PiButton.Click();
       PlusButton.Click();
       PickNumericValue(n);
       LogButton.Click();
       MinusButton.Click();
       PickNumericValue(x);
       PowerButton.Click();
       PickNumericValue(y);
       PowerButton.Click();
       EqualButton.Click();
       
    }

    public void ExecuteTanFucntionOfNumbers(string num)
    {
        ClearCalcInput();
        DegreeButtonElement.Click();
        PickNumericValue(num);
        TrigonometricsElement.Click();
        TanFunctionElement.Click();
       
    }
    public void ExecuteSinFucntionOfNumbers(string num)
    {
        ClearCalcInput();
        DegreeButtonElement.Click();
        PickNumericValue(num);
        TrigonometricsElement.Click();
        SinFunctionElement.Click();


    }

    public void ChooseFromDateToDate(string firstDate, string SecondDate)
    {
       FromDatePickerButton.Click();
       FromDate(firstDate).Click();
       ToDatePickerButton.Click();
       ToDate(SecondDate).Click();
    }

    public void PickNumericValue(string numberCharacter)
    {
        if (numberCharacter.StartsWith('-'))
        {
            string value = numberCharacter.Substring(1);
            numberCharacter = value + "-";
        }

        foreach (char item in numberCharacter)
        {
            if (char.IsDigit(item))
            {
                switch (item)
                {
                    case '1':
                        OneButton.Click();
                        break;
                    case '2':
                        TwoButton.Click();
                        break;
                    case '3':
                        ThreeButton.Click();
                        break;
                    case '4':
                        FourButton.Click();
                        break;
                    case '5':
                        FiveButton.Click();
                        break;
                    case '6':
                        SixButton.Click();
                        break;
                    case '7':
                        SevenButton.Click();
                        break;
                    case '8':
                        EightButton.Click();
                        break;
                    case '9':
                        NineButton.Click();
                        break;
                }
            }

            if (item.Equals('-'))
            {
                NegateButton.Click();
            }
            if (item.Equals('.'))
            {
                DecimalSeparator.Click();
            }
        }
    }
  
    private void PerformOperation(char operation)
    {
        switch (operation)
        {
            case '+':
                PlusButton.Click();
                break;
            case '-':
                MinusButton.Click();
                break;
            case '=':
                EqualButton.Click();
                break;
            case '*':
                MultiplyButton.Click();
                break;
            case '/':
                DivideButton.Click();
                break;
            case '%':
                PercentButton.Click();
                break;
            case 'π':
                PiButton.Click();
                break;
            case 'L':
                LogButton.Click();
                break;
            case 'p':
                PowerButton.Click();
                break;

        }
    }
}