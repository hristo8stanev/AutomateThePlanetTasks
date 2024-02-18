using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
using WebDriverManager;
using ZipCodes.Pages.ZipCodeMainPage;

namespace ZipCodes;

public class Tests
{
    private IWebDriver _driver;
    ZipCodeMainPage _zipCodeMainPage;
    [SetUp]
    public void Setup()
    {
        new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
        _driver = DriverFacade.DriverFacade.StartBrowser(BrowserType.CHROME);
        _driver.Manage().Window.Maximize();
        _zipCodeMainPage = new ZipCodeMainPage(_driver);
    }
    [TearDown]
    public void Cleanup()
    {
       
        _driver.Dispose();

    }

    [Test]
    public void Test1()
    {
        _zipCodeMainPage.GoTo();
        Assert.Pass();
    }
}