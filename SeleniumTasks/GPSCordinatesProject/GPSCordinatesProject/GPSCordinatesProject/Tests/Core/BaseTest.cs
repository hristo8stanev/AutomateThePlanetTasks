using NUnit.Framework;using OpenQA.Selenium;using OpenQA.Selenium.Chrome;using OpenQA.Selenium.DevTools;using OpenQA.Selenium.DevTools.V122;using OpenQA.Selenium.DevTools.V122.Emulation;using WebDriverManager;using WebDriverManager.DriverConfigs.Impl;using GPSCordinatesProject.Pages;using System.Collections.Generic;using GPSCordinatesProject.Pages.MainPage;using WebDriverManager.Helpers;using DevToolsSessionDomains = OpenQA.Selenium.DevTools.V122.DevToolsSessionDomains;namespace GPSCordinatesProject.Test.Core.BaseTest{    public class BaseTest    {        protected IWebDriver _driver;        protected MainPage _mainPage;        protected readonly Dictionary<string, (double latitude, double longitude)> CountryCoordinates = new Dictionary<string, (double latitude, double longitude)>        {            { "Germany", (52.5200, 13.4050) },            { "Argentina", (-34.6037, -58.3816) },            { "Australia", (-35.2820, 149.1287) },            { "Canada", (45.4215, -75.6919) },            { "Japan", (35.6895, 139.6917) },            { "Taiwan", (25.0330, 121.5654) },            { "Norway", (59.9139, 10.7522) },            { "South Africa", (-33.9249, 18.4241) }        };        [SetUp]        public void Setup()        {            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);            _driver = new ChromeDriver();            _driver.Manage().Window.Maximize();            _mainPage = new MainPage(_driver);        }        [TearDown]        public void Cleanup()        {            _driver.Dispose();        }        [TestCase("Germany", "Berlin")]        [TestCase("Argentina", "Buenos Aires")]        [TestCase("Australia", "Canberra")]        [TestCase("Canada", "Ottawa")]        [TestCase("Japan", "Tokyo")]        [TestCase("Taiwan", "Taipei City")]        [TestCase("Norway", "Oslo")]        [TestCase("South Africa", "Cape Town")]        public void RunningFromDifferentLocation_When_DifferentCountyIsEntered(string country, string city)        {            var (latitude, longitude) = CountryCoordinates[country];            SetGeolocation(latitude, longitude);

            _mainPage.GoTo();
            _mainPage.AcceptCookies();
            _mainPage.ScrooToTheAddress();
            _mainPage.AssertMapIsDisplayed();
        }        private void SetGeolocation(double latitude, double longitude)        {
            using var devToolsSession = ((IDevTools)_driver).GetDevToolsSession();
            var domains = devToolsSession.GetVersionSpecificDomains<DevToolsSessionDomains>();
            var emulation = domains.Emulation;

            var overrideSettings = new SetGeolocationOverrideCommandSettings
            {
                Latitude = latitude,
                Longitude = longitude,
                Accuracy = 1
            };
            emulation.SetGeolocationOverride(overrideSettings);
        }
    }
}