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

        [TestCase("Germany", "Berlin")]
       //[TestCase("Argentina", "Buenos Aires")]
       //[TestCase("Australia", "Canberra")]
       //[TestCase("Canada", "Ottawa")]
       //[TestCase("Japan", "Tokyo")]
       //[TestCase("Taiwan", "Taipei City")]
       //[TestCase("Norway", "Oslo")]
       //[TestCase("South Africa", "Cape Town")]
        public void RunningFromDifferentLocation_When_DifferentCountyIsEntered(string country, string city)
        {
            var (latitude, longitude) = CountryCoordinates[country];
            _mainPage.SetGeolocation(latitude, longitude);


            _mainPage.GoTo();
            _mainPage.AcceptCookies();
            _mainPage.ScrooToTheAddress();
            _mainPage.AssertMapIsDisplayed();
             _mainPage.AssertCityAndCountryIsCorrect();
            _mainPage.AssertLongtitudeAndLatitudeIsCorrect();
        }
    }
}