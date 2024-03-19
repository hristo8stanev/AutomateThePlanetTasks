using OpenQA.Selenium.Appium.Windows;
using WinAppTask.Pages.BaseCalculatorPage;

namespace WinAppTask.Pages.DateCalculatorPage;
public partial class DateCalculatorPage : BasePage
{

    public readonly WindowsDriver<WindowsElement> _driver;
    public DateCalculatorPage(WindowsDriver<WindowsElement> driver) => _driver = driver;

    public void ChooseFromDateToDate(string firstDate, string SecondDate)
    {
       FromDatePickerButton.Click();
       FromDate(firstDate).Click();
       ToDatePickerButton.Click();
       ToDate(SecondDate).Click();
    }
}