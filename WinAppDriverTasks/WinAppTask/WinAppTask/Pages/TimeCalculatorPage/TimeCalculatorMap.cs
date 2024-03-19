using OpenQA.Selenium.Appium.Windows;

namespace WinAppTask.Pages.TimeCalculatorPage;
public partial class TimeCalculatorPage
{
    public WindowsElement OneButton => _driver.FindElementByName("One");
    public WindowsElement TwoButton => _driver.FindElementByName("Two");
    public WindowsElement ThreeButton => _driver.FindElementByName("Three");
    public WindowsElement FourButton => _driver.FindElementByName("Four");
    public WindowsElement FiveButton => _driver.FindElementByName("Five");
    public WindowsElement SixButton => _driver.FindElementByName("Six");
    public WindowsElement SevenButton => _driver.FindElementByName("Seven");
    public WindowsElement EightButton => _driver.FindElementByName("Eight");
    public WindowsElement ClearEntryButton => _driver.FindElementByName("Clear entry");
    public WindowsElement InputUnitButton => _driver.FindElementByName("Input unit");
    public WindowsElement OutputValueDegreeButton => _driver.FindElementByAccessibilityId("Value2");
    public WindowsElement OutputUnitButton => _driver.FindElementByName("Output unit");
    public WindowsElement NegateButton => _driver.FindElementByAccessibilityId("negateButton");
    public WindowsElement DecimalSeparator => _driver.FindElementByAccessibilityId("decimalSeparatorButton");
    public WindowsElement NineButton => _driver.FindElementByName("Nine");
   
}