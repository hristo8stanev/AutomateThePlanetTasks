using OpenQA.Selenium;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using GPSCordinatesProject.Pages.MainPage;
using WebDriverManager.Helpers;
using GPSCordinatesProject.Enums;
namespace GPSCordinatesProject.Test.Core.BaseTest;    public class BaseTest    {        protected IWebDriver _driver;        protected MainPage _mainPage;        protected readonly Dictionary<string, (double latitude, double longitude)> CountryCoordinates =            new Dictionary<string, (double latitude, double longitude)>        {            { "Germany", (52.517037, 13.38886) },            { "Argentina", (-34.6037, -58.3816) },            { "Australia", (-35.297591, 149.101268) },            { "Canada", ( 45.4215, -75.6972) },            { "Japan", (35.6764, 139.6500) },            { "11455, Taipei Neihu District 開眼山步道", (25.105497, 121.597366) },            { "Norway", (59.91333, 10.73897) },            { "South Africa", (-33.9249, 18.4241) }        };        [SetUp]        public void Setup()        {            new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
            _driver = DriverFacade.DriverFacade.StartBrowser(BrowserType.CHROME);            _driver.Manage().Window.Maximize();            _mainPage = new MainPage(_driver);        }        [TearDown]        public void Cleanup()        {            _driver.Dispose();        }
    }