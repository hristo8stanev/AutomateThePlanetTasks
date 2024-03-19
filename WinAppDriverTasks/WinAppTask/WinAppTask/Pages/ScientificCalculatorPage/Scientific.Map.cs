using OpenQA.Selenium.Appium.Windows;

namespace WinAppTask.Pages.ScientificCalculatorPage;
public partial class ScientificCalculatorPages
{
    public WindowsElement OneButton => _driver.FindElementByName("One");
    public WindowsElement TwoButton => _driver.FindElementByName("Two");
    public WindowsElement ThreeButton => _driver.FindElementByName("Three");
    public WindowsElement FourButton => _driver.FindElementByName("Four");
    public WindowsElement FiveButton => _driver.FindElementByName("Five");
    public WindowsElement SixButton => _driver.FindElementByName("Six");
    public WindowsElement SevenButton => _driver.FindElementByName("Seven");
    public WindowsElement EightButton => _driver.FindElementByName("Eight");
    public WindowsElement NineButton => _driver.FindElementByName("Nine");
    public WindowsElement MinusButton => _driver.FindElementByName("Minus");
    public WindowsElement PlusButton => _driver.FindElementByName("Plus");
    public WindowsElement PiButton => _driver.FindElementByName("Pi");
    public WindowsElement LogButton => _driver.FindElementByName("Log");
    public WindowsElement PowerButton => _driver.FindElementByAccessibilityId("powerButton");
    public WindowsElement EqualButton => _driver.FindElementByName("Equals");
    public WindowsElement ClearCalcInputButton => _driver.FindElementByName("Clear");
    public WindowsElement CalculatorResultButton => _driver.FindElementByAccessibilityId("CalculatorResults");
    public WindowsElement NegateButton => _driver.FindElementByAccessibilityId("negateButton");
    public WindowsElement DecimalSeparator => _driver.FindElementByAccessibilityId("decimalSeparatorButton");
    public WindowsElement TrigonometricsElement => _driver.FindElementByAccessibilityId("trigButton");
    public WindowsElement SinFunctionElement => _driver.FindElementByAccessibilityId("sinButton");
    public WindowsElement TanFunctionElement => _driver.FindElementByAccessibilityId("tanButton");
    public WindowsElement DegreeButtonElement => _driver.FindElementByAccessibilityId("degButton");
}