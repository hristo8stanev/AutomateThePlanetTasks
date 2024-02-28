using FirstSeleniumProject.Pages.GettingStartedPage;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
using WebDriverManager;
using FirstSeleniumProject.@enum;

namespace FirstSeleniumProject.Tests.Core.BaseTest;
public class BaseTest
{
    protected static IWebDriver _driver;
    protected static MainPage _mainPage;


    [SetUp]
    public void Setup()
    {
        new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
        _driver = DriverFacade.DriverFacade.StartBrowser(BrowserType.CHROME);
        _driver.Manage().Window.Maximize();
        _mainPage = new MainPage(_driver);
    }

    [TearDown]
    public void Dispose()
    {
        _driver.Dispose();
    }

}
