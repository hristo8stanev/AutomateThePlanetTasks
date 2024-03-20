using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using WinAppTask.Enums;
using WinAppTask.Pages.BaseCalculatorPage;

namespace WinAppTask.Pages.TimeCalculatorPage;
public partial class TimeCalculatorPage : BasePage
{

    public readonly WindowsDriver<WindowsElement> _driver;

    public TimeCalculatorPage(WindowsDriver<WindowsElement> driver) : base(driver)
    {
        _driver = driver;
    }

    protected AppiumWebElement GetResultElementTemp()
    {
        var result = OutputValueDegreeButton;
        return result;
    }

    protected string ResultTextDays => GetResultElementTemp().Text.Replace("Converts into ", string.Empty).Replace(" Seconds", string.Empty).Trim();

    public void ConvertBetweenDaysAndSeconds(string num1)
    {
        Clear();
        InputUnitButton.SendKeys(TimeScale.Days.ToString());
        PickNumericValue(num1);
        OutputUnitButton.SendKeys(TimeScale.Seconds.ToString());

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