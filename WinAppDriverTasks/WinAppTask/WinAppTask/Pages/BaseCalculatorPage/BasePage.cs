using OpenQA.Selenium.Appium.Windows;

namespace WinAppTask.Pages.BaseCalculatorPage;
public abstract class BasePage
{
    protected int WAIT => 5;

  //  protected BasePage(WindowsDriver<WindowsElement> driver)
  //  {
  //      _driver = driver;
  //  }

    protected WindowsDriver<WindowsElement> _driver { get; set; }
}
