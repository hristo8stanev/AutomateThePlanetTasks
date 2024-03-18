using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
using WebDriverManager;
using ZipCodes.Pages.ZipCodeMainPage;
using ZipCodes.Pages.SearchPage;
using OpenQA.Selenium.Support.UI;

namespace ZipCodes.Test.Core.BaseTest;
public class BaseTest
{
    protected IWebDriver _driver;
    protected WebDriverWait _webDriverWait;
    protected static ZipCodeMainPage _zipCodeMainPage;
    protected static SearchPage _searchPage;

    [SetUp]
    public void Setup()
    {
        new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
        _driver = DriverFacade.StartBrowserService.StartBrowser(BrowserType.CHROME);
        _driver.Manage().Window.Maximize();
        _zipCodeMainPage = new ZipCodeMainPage(_driver);
        _searchPage = new SearchPage(_driver);
        _webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
    }

    [TearDown]
    public void Cleanup()
    {

        _driver.Dispose();

    }
}
