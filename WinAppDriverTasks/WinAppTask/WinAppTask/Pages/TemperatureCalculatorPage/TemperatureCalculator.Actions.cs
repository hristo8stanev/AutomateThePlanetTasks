using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using WinAppTask.Enums;
using WinAppTask.Pages.BaseCalculatorPage;

namespace WinAppTask.Pages.TemperatureCalculatorPage;
public partial class TemperatureCalculatorPage : BasePage
{

    public readonly WindowsDriver<WindowsElement> _driver;

    public TemperatureCalculatorPage(WindowsDriver<WindowsElement> driver) : base(driver)
    {
        _driver = driver;
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
    protected string ResultTextTemp => GetResultElementTemp().Text.Replace("Converts into ", string.Empty).Replace(TemperatureScale.Fahrenheit.ToString(), string.Empty).Trim();


    public void ConvertTemperatures(string num2)
    {
        Clear();
        InputUnitButton.SendKeys(TemperatureScale.Celsius.ToString());
        PickNumericValue(num2);
        OutputUnitButton.SendKeys(TemperatureScale.Fahrenheit.ToString());
    }
    protected void Clear() => ClearEntryButton.Click();

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
}