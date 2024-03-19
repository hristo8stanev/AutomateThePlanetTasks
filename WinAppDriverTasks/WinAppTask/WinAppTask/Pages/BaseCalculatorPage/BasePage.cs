using OpenQA.Selenium.Appium.Windows;

namespace WinAppTask.Pages.BaseCalculatorPage;
public abstract class BasePage
{
    protected int WAIT => 5;
    protected WindowsDriver<WindowsElement> _driver;


  // public void SelectCalculator(CalculatorType calculatorType)
  // {
  //     _standardCalculatorPage.TogglePanelButton.Click();
  //     _standardCalculatorPage.CalculatorTypeButton(calculatorType).Click();
  // }
}
