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
using SetGeolocationOverrideCommandSettings = OpenQA.Selenium.DevTools.V122.Emulation.SetGeolocationOverrideCommandSettings;

namespace SeleniumDocs.Bidirectional.ChromeDevtools
{
 
    public class GPSCordinatesTests : BaseTest
    {

     [TestCase("Germany", "Unter den Linden, Friedrichstraße, 10117 Berlin")]
     [TestCase("Argentina", "Obelisco, Avenida Corrientes, San Nicolás, Buenos Aires")]
     [TestCase("Australia", "Australian Capital Territory, CGS Rowing, Alexandrina Drive, Yarralumla 2600")]
     [TestCase("Canada", "World Exchange Plaza, 45 O'Connor Street, Ottawa, ON K1P 5M4")]
     [TestCase("Japan", "unnamed road, Izumi 2, Suginami, 168-0063")]
     [TestCase("11455, Taipei Neihu District 開眼山步道", "Taiwan")]
     [TestCase("Norway", "Karl Johans gate, 0026 Oslo")]
     [TestCase("South Africa", "unnamed road, City Centre, Cape Town, 8001")]
        public void RunningFromDifferentLocation_When_DifferentCountyIsEntered(string country, string city)
        {
            var (latitude, longitude) = CountryCoordinates[country];

            _mainPage.SetGeolocation(latitude, longitude);
            _mainPage.GoTo();
            _mainPage.AcceptCookies();
            _mainPage.ScrooToTheAddress();

            _mainPage.AssertMapIsDisplayed();
            _mainPage.AssertCityAndCountryIsCorrect(country,city);
            _mainPage.AssertLongtitudeAndLatitudeIsCorrect(latitude, longitude);
        }
    }
}