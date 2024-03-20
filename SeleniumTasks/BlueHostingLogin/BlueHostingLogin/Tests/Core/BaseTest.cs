using BlueHostingLogin.@enum;
using BlueHostingLogin.Pages.BlueHostPage;
using BlueHostingLogin.Pages.LambdaTestPage;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
using WebDriverManager;
using OpenQA.Selenium.Support.UI;

namespace BlueHostingLogin.Tests.Core;
public class BaseTest
{
    private const int TIMEOUT_SECONDS = 30;
    protected IWebDriver _driver;
    protected WebDriverWait _WebDriverWait;
    protected static  LambdaMainPage _lambdaMainPage;
    protected static  BlueHostMainPage _blueHostMainPage;



    [SetUp]
    public void Setup()
    {
        new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
        _driver = DriverFacade.StartBrowserType.StartBrowser(BrowserType.CHROME);
        _driver.Manage().Window.Maximize();
        _lambdaMainPage = new LambdaMainPage(_driver);
        _blueHostMainPage = new BlueHostMainPage(_driver);
        _WebDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(TIMEOUT_SECONDS));
    }

    [TearDown]
    public void Cleanup()
    {
        _driver.Dispose();
    }
}