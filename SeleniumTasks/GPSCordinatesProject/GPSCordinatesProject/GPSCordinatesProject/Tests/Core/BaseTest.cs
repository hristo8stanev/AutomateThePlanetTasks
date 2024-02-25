global using System;
global using System.Collections.Generic;
global using GPSCordinatesProject.Enums;
global using OpenQA.Selenium;
global using OpenQA.Selenium.Firefox;
global using OpenQA.Selenium.Interactions;
global using OpenQA.Selenium.Support.UI;
global using WebDriverManager;
global using WebDriverManager.DriverConfigs.Impl;
global using WebDriverManager.Helpers;
global using GPSCordinatesProject.Pages.MainPage;
global using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Chrome;
using static System.Net.WebRequestMethods;
using OpenQA.Selenium.DevTools.V120.Emulation;
using System.Runtime.Intrinsics.Arm;


namespace GPSCordinatesProject.Test.Core.BaseTest;
public class BaseTest
{
    protected IDevToolsSession DevToolsSession;
    protected IWebDriver _driver;
    protected MainPage _mainPage;

    [SetUp]
    public void Setup()
    {
        new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
        _driver = DriverFacade.DriverFacade.StartBrowser(BrowserType.CHROME);
        _driver.Manage().Window.Maximize();
        _mainPage = new MainPage(_driver);
        using var devToolssession = ((IDevTools)_driver).GetDevToolsSession();
        var domains = devToolssession.GetVersionSpecificDomains<DevToolsSessionDomains>();
        var settings = new SetGeolocationOverrideCommandSettings();
        settings.Latitude = -34.6037;
        settings.Longitude = -58.3816;
        settings.Accuracy = 1;
        devToolssession.SendCommand(settings);
        _driver.Navigate().Refresh();
    }

    [TearDown]
    public void Cleanup()
    {

        _driver.Dispose();

    }
}
