using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using WinAppTask.Pages.BaseCalculatorPage;

namespace WinAppTask.Pages.ScientificCalculatorPage;
public partial class ScientificCalculatorPages : BasePage
{

    public readonly WindowsDriver<WindowsElement> _driver;
    public ScientificCalculatorPages(WindowsDriver<WindowsElement> driver) => _driver = driver;
    protected AppiumWebElement GetResultElement()
    {
        var result = CalculatorResultButton;
        return result;
    }

    protected string ResultText => GetResultElement().Text.Replace("Display is", string.Empty).Replace("point", string.Empty).Trim();
    protected void ClearCalcInput() => ClearCalcInputButton.Click();

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
}