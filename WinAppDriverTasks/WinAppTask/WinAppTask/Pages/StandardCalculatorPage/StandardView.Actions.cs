using OpenQA.Selenium.Appium.Windows;
using WinAppTask.Pages.BaseCalculatorPage;

namespace WinAppTask.Views;
public partial class StandardCalculatorPage : BasePage
{
    public readonly WindowsDriver<WindowsElement> _driver;
    public StandardCalculatorPage(WindowsDriver<WindowsElement> driver) => _driver = driver;

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

    protected string GetCalculatorResultText() => CalculatorResultButton.Text.Replace("Display is", string.Empty).Trim();
    protected void ClearCalcInput() => ClearCalcInputButton.Click();
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