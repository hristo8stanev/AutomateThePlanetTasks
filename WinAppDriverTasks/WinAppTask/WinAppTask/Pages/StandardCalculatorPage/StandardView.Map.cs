using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using WinAppTask.Enums;

namespace WinAppTask.Views;
public partial class StandardCalculatorPage
{
    public WindowsElement ZeroButton => _driver.FindElementByName("Zero");
    public WindowsElement OneButton => _driver.FindElementByName("One");
    public WindowsElement TwoButton => _driver.FindElementByName("Two");
    public WindowsElement ThreeButton => _driver.FindElementByName("Three");
    public WindowsElement FourButton => _driver.FindElementByName("Four");
    public WindowsElement FiveButton => _driver.FindElementByName("Five");
    public WindowsElement SixButton => _driver.FindElementByName("Six");
    public WindowsElement SevenButton => _driver.FindElementByName("Seven");
    public WindowsElement EightButton => _driver.FindElementByName("Eight");
    public WindowsElement NineButton => _driver.FindElementByName("Nine");
    public WindowsElement EqualButton => _driver.FindElementByName("Equals");
    public WindowsElement DivideButton => _driver.FindElementByName("Divide by");
    public WindowsElement ClearCalcInputButton => _driver.FindElementByName("Clear");
    public WindowsElement CalculatorResultButton => _driver.FindElementByAccessibilityId("CalculatorResults");
    public WindowsElement NegateButton => _driver.FindElementByAccessibilityId("negateButton");
    public WindowsElement DecimalSeparator => _driver.FindElementByAccessibilityId("decimalSeparatorButton");
    public WindowsElement TogglePanelButton => _driver.FindElement(ByAccessibilityId.AccessibilityId("TogglePaneButton"));
    public WindowsElement CalculatorTypeButton(CalculatorType calculatorType) => _driver.FindElement(ByAccessibilityId.AccessibilityId(calculatorType.ToString()));
}