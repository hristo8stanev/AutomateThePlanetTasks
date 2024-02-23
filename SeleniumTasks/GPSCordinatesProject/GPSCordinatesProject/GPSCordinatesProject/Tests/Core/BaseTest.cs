global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.Text;
global using System.Threading.Tasks;
global using NUnit.Framework;
global using GPSCordinatesProject.DriverFacade;
global using GPSCordinatesProject.Enums;
global using OpenQA.Selenium;
global using OpenQA.Selenium.Firefox;
global using OpenQA.Selenium.Interactions;
global using OpenQA.Selenium.Support.UI;
global using WebDriverManager;
global using WebDriverManager.DriverConfigs.Impl;
global using WebDriverManager.Helpers;
global using static OpenQA.Selenium.RelativeBy;
global using static OpenQA.Selenium.By;
global using GPSCordinatesProject.Pages.MainPage;
global using OpenQA.Selenium.DevTools;


namespace GPSCordinatesProject.Test.Core.BaseTest;
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
