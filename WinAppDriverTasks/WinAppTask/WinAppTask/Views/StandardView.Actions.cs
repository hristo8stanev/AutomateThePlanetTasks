using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WinAppTask.Views;
public partial class CalculatorStandardView
{

    private readonly WindowsDriver<WindowsElement> _driver;
    public CalculatorStandardView(WindowsDriver<WindowsElement> driver) => _driver = driver;

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
    protected string ResultTextTemp => GetResultElementTemp().Text.Replace("Converts into ", string.Empty).Replace("Fahrenheit", string.Empty).Trim();
    public void NavigationalMenu() => NavigationButton.Click();
    public void NavigateToScientificMenu() => ScientificMenuButton.Click();
    protected string GetCalculatorResultText() => CalculatorResultButton.Text.Replace("Display is", string.Empty).Trim();

    public void ConvertTemperatures(string num2)
    {
        ClearCalcInput();
        TemperatureConverterMenuButton.Click();
        InputUnitButton.SendKeys("Celsius");
        PickNumericValue(num2);
        OutputUnitButton.SendKeys("Fahrenheit");
    }

    protected void ClearCalcInput() => ClearInput.Click();
    

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