using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using WinAppTask.Enums;
using WinAppTask.Views;

namespace WinAppTask.Pages.BaseClass;

[TestFixture]
public class CalculatorPageObject
{
    protected int WAIT => 5;
    protected WindowsDriver<WindowsElement> _driver;
    protected CalculatorStandardPage _standardCalculatorPage;
    protected CalculatorStandardPage _views;

    [SetUp]
    public void TestInit()
    {
        var options = new AppiumOptions();
        options.AddAdditionalCapability("app", "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App");
        options.AddAdditionalCapability("deviceName", "WindowsPC");
        _driver = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), options);
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(WAIT);
        _standardCalculatorPage = new CalculatorStandardPage(_driver);


    }

    public void SelectCalculator(CalculatorType calculatorType)
    {
        _standardCalculatorPage.TogglePanelButton.Click();
        _standardCalculatorPage.CalculatorTypeButton(calculatorType).Click();
    }


    [TearDown]
    public void TestCleanup()
    {

        _driver.Quit();
    }
}