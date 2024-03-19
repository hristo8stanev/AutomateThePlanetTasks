using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using WinAppTask.Enums;
using WinAppTask.Pages.DataCalculatorPage;
using WinAppTask.Pages.DateCalculatorPage;
using WinAppTask.Pages.ScientificCalculatorPage;
using WinAppTask.Pages.TemperatureCalculatorPage;
using WinAppTask.Pages.TimeCalculatorPage;
using WinAppTask.Pages.WeightAndMassCalculatorPage;
using WinAppTask.Views;

namespace WinAppTask.Tests.BaseTest;

[TestFixture]
public class BaseCalculatorTest
{
    protected int WAIT => 5;
    protected WindowsDriver<WindowsElement> _driver;
    protected StandardCalculatorPage _standardCalculatorPage;
    protected ScientificCalculatorPages _scientificCalculatorPages;
    protected DateCalculatorPage _dateCalculatorPage;
    protected TemperatureCalculatorPage _temperatureCalculatorPage;
    protected TimeCalculatorPage _timeCalculatorPage;
    protected WeightAndMassCalculator _weightAndMassCalculator;
    protected DataCalculator _dataCalculatorPage;



    [SetUp]
    public void TestInit()
    {
        var options = new AppiumOptions();
        options.AddAdditionalCapability("app", "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App");
        options.AddAdditionalCapability("deviceName", "WindowsPC");
        _driver = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), options);
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(WAIT);
        _standardCalculatorPage = new StandardCalculatorPage(_driver);
        _scientificCalculatorPages = new ScientificCalculatorPages(_driver);
        _dateCalculatorPage = new DateCalculatorPage(_driver);
        _temperatureCalculatorPage = new TemperatureCalculatorPage(_driver);
        _timeCalculatorPage = new TimeCalculatorPage(_driver);
        _weightAndMassCalculator = new WeightAndMassCalculator(_driver);
        _dataCalculatorPage = new DataCalculator(_driver);
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