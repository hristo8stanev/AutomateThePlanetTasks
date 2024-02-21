using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
using WebDriverManager;
using ZipCodes.Pages.ZipCodeMainPage;
using ZipCodes.Pages.SearchPage;

namespace ZipCodes.Test.Core.BaseTest;
public class BaseTest
{
    protected IWebDriver _driver;
    protected static ZipCodeMainPage _zipCodeMainPage;
    protected static SearchPage _searchPage;

    [SetUp]
    public void Setup()
    {
        new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
        _driver = DriverFacade.DriverFacade.StartBrowser(BrowserType.EDGE);
        _driver.Manage().Window.Maximize();
        _zipCodeMainPage = new ZipCodeMainPage(_driver);
        _searchPage = new SearchPage(_driver);
    }

    [TearDown]
    public void Cleanup()
    {

        _driver.Dispose();

    }
}
