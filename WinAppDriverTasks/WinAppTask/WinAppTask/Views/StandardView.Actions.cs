using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using System;

namespace WinAppTask.Views;
public partial class CalculatorStandardView
{

    private readonly WindowsDriver<WindowsElement> _driver;
    public CalculatorStandardView(WindowsDriver<WindowsElement> driver) => _driver = driver;

    public void PerformCalculation(int num1, char option, int num2)
    {
        ClickByDigit(num1);
        PerformOperation(option);
        ClickByDigit(num2);
        EqualButton.Click();

    }

     public void PerformSquareCantimetersCalculation(int num1, char option, int num2, int num3, int num4, int num5)
    {
        ClickByDigit(num1);
        PerformOperation(option);
        ClickByDigit(num2);
        ClickByDigit(num3);
        ClickByDigit(num4);
        ClickByDigit(num5);
        EqualButton.Click();

    }

    public void ConvertTemperatures()
    {
       TemperatureConverterButton.Click();
       InputUnitButton.SendKeys("Celsius");
       FiveButton.Click();
       OutputUnitButton.SendKeys("Fahrenheit");
    }

    protected void ClearCalcInput()
    {
        var clear = _driver.FindElement(By.Name("Clear"));
        clear?.Click();
    }

    public void NavigationalMenu()
    {
        NavigationButton.Click();
    }


    protected string GetCalculatorResultText() => CalculatorResultButton.Text.Replace("Display is", string.Empty).Trim();


   public string GetCalculatorResultText22222()
    {
        return CalculatorResultButton.Text;
    }

    public string GetCalculatorResultTextValue2() => _driver.FindElementByAccessibilityId("Value2").Text.Replace("Display is", string.Empty).Trim();
    
 

    private void ClickByDigit(int digit)
    {
        switch (digit)
        {
            case 1:
                OneButton.Click();
                break;
            case 2:
                OneButton.Click();
                break;
            case 3:
                FourButton.Click();
                break;
            case 4:
                FourButton.Click();
                break;
            case 5:
                FiveButton.Click();
                break;
            case 6:
                SixButton.Click();
                break;
            case 7:
                SevenButton.Click();
                break;
            case 8:
                EightButton.Click();
                break;
            case 9:
                NineButton.Click();
                break;
            case 0:
                ZeroButton.Click();
                break;
            default:
                throw new NotSupportedException($"Not Supported digit = {digit}");
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

        }
    }
    public void AddNumberToFormula(int number)
    {
        foreach (char digit in number.ToString())
        {
            _driver.FindElementByName(digit.ToString()).Click();
        }
    }
}
