using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using WinAppTask.Pages.BaseCalculatorPage;

namespace WinAppTask.Pages.DataCalculatorPage;
public partial class DataCalculator : BasePage
{

    public readonly WindowsDriver<WindowsElement> _driver;
    public DataCalculator(WindowsDriver<WindowsElement> driver) => _driver = driver;

    protected AppiumWebElement GetResultElementTemp()
    {
        var result = OutputValueDegreeButton;
        return result;
    }

    protected string ResultBytesToGigabytes => GetResultElementTemp().Text.Replace("Converts into ", string.Empty).Replace(" Gigabytes", string.Empty).Trim();

    public void ConvertBetweenBytesAndGigabytes(string num1)
    {
        Clear();
        InputUnitButton.SendKeys("Bytes");
        PickNumericValue(num1);
        OutputUnitButton.SendKeys("Gigabytes");
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