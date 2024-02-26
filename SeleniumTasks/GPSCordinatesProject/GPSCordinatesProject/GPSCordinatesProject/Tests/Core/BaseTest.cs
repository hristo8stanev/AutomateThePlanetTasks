using GPSCordinatesProject.Test.Core.BaseTest;
using OpenQA.Selenium.DevTools.V120.Emulation;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools;
using DevToolsSessionDomains = OpenQA.Selenium.DevTools.V122.DevToolsSessionDomains;
using OpenQA.Selenium.DevTools.V122.Emulation;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using GPSCordinatesProject.Pages;
using System.Collections.Generic;
using GPSCordinatesProject.Pages.MainPage;
using WebDriverManager.Helpers;
using GPSCordinatesProject.Enums;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using SetGeolocationOverrideCommandSettings = OpenQA.Selenium.DevTools.V122.Emulation.SetGeolocationOverrideCommandSettings;namespace GPSCordinatesProject.Test.Core.BaseTest{    public class BaseTest    {        protected IWebDriver _driver;        protected MainPage _mainPage;        protected readonly Dictionary<string, (double latitude, double longitude)> CountryCoordinates =            new Dictionary<string, (double latitude, double longitude)>        {            { "Germany", (52.5170365, 13.3888599) },            { "Argentina", (-34.6037, -58.3816) },            { "Australia", (-35.2820, 149.1287) },            { "Canada", (45.4215, -75.6919) },            { "Japan", (35.6895, 139.6917) },            { "Taiwan", (25.0330, 121.5654) },            { "Norway", (59.9139, 10.7522) },            { "South Africa", (-33.9249, 18.4241) }        };        [SetUp]        public void Setup()        {            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            _driver = DriverFacade.DriverFacade.StartBrowser(BrowserType.CHROME);            _driver.Manage().Window.Maximize();            _mainPage = new MainPage(_driver);        }        [TearDown]        public void Cleanup()        {            _driver.Dispose();        }
    }
}