using OpenQA.Selenium.Appium.Windows;

namespace WinAppTask.Pages.DateCalculatorPage;
public partial class DateCalculatorPage
{
    public WindowsElement FromDatePickerButton => _driver.FindElementByAccessibilityId("DateDiff_FromDate");
    public WindowsElement ToDatePickerButton => _driver.FindElementByAccessibilityId("DateDiff_ToDate");
    public WindowsElement FromDate(string date) => _driver.FindElementByName(date);
    public WindowsElement ToDate(string date) => _driver.FindElementByName(date);
    public WindowsElement DateResult => _driver.FindElementByAccessibilityId("DateDiffAllUnitsResultLabel");

}