using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GPSCordinatesProject.DriverFacade;
using GPSCordinatesProject.Enums;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
using WebDriverManager;
using GPSCordinatesProject.Pages.MainPage;

namespace GPSCordinatesProject.Test.Core.BaseTest;
public class BaseTest
{
    protected IWebDriver _driver;
    protected MainPage _mainPage;

    [SetUp]
    public void Setup()
    {
        new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
        _driver = DriverFacade.DriverFacade.StartBrowser(BrowserType.FIREFOX);
        _driver.Manage().Window.Maximize();
        _mainPage = new MainPage(_driver);
    }

    [TearDown]
    public void Cleanup()
    {

        _driver.Dispose();

    }
}
