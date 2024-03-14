using System;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using WinAppTask.Views;

namespace WinAppTask.BaseClass;

[TestFixture]
public class CalculatorPageObject
{
    protected int WAIT => 5;
    protected WindowsDriver<WindowsElement> _driver;
    protected CalculatorStandardView _calcStandardView;

    [SetUp]
    public void TestInit()
    {
        var options = new AppiumOptions();
        options.AddAdditionalCapability("app", "Microsoft.WindowsCalculator_8wekyb3d8bbwe!App");
        options.AddAdditionalCapability("deviceName", "WindowsPC");
        _driver = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), options);
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(WAIT);
        _calcStandardView = new CalculatorStandardView(_driver);

    }

    [TearDown]
    public void TestCleanup()
    {

        _driver.Quit();
    }
}