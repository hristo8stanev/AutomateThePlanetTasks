using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
using WebDriverManager;
using PriceStockCompany.enums;
using PriceStockCompany.Pages.MainPage;

namespace PriceStockCompany.Tests.Core;
public class BaseTest
{
    protected IWebDriver _driver;
    protected MainPage _mainPage;

    [SetUp]
    public void Setup()
    {
        new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
        _driver = DriverFacade.DriverFacade.StartBrowser(BrowserType.CHROME);
        _driver.Manage().Window.Maximize();
        _mainPage = new MainPage(_driver);
    }

    [TearDown]
    public void Cleanup()
    {
        _driver.Dispose();
    }
}
