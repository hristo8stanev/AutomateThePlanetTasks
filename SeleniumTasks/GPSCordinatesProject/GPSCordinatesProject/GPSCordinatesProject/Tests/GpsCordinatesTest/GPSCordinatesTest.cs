﻿using GPSCordinatesProject.Test.Core.BaseTest;

namespace SeleniumDocs.Bidirectional.ChromeDevtools;
    public class GPSCordinatesTests : BaseTest
    {

       [TestCase("Germany", "Unter den Linden, 10117 Berlin")]
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
            _mainPage.ScrollToTheAddress();

            _mainPage.AssertMapIsDisplayed();
            _mainPage.AssertCityAndCountryIsCorrect(country,city);
            _mainPage.AssertLongtitudeAndLatitudeIsCorrect(latitude, longitude);
        }
    }
