using System.Reflection.Emit;
using GPSCordinatesProject.Test.Core.BaseTest;
using OpenQA.Selenium;
using static System.Net.WebRequestMethods;

namespace GPSCordinatesProject.Tests.DistanceTests;
public class CalculateTheDistanceBetweenToCities : BaseTest
{
    [TestCase("Germany", "Unter den Linden, Friedrichstraße, 10117 Berlin")]
    [TestCase("Argentina", "Obelisco, Avenida Corrientes, San Nicolás, Buenos Aires")]
    [TestCase("Australia", "Australian Capital Territory, CGS Rowing, Alexandrina Drive, Yarralumla 2600")]
    [TestCase("Canada", "World Exchange Plaza, 45 O'Connor Street, Ottawa, ON K1P 5M4")]
    [TestCase("Japan", "unnamed road, Izumi 2, Suginami, 168-0063")]
    [TestCase("11455, Taipei Neihu District 開眼山步道", "Taiwan")]
    [TestCase("Norway", "Karl Johans gate, 0026 Oslo")]
    [TestCase("South Africa", "unnamed road, City Centre, Cape Town, 8001")]
    [Test]
    public void CalculateDistanceBetweenToCity(string country, string city)
    {
     
        var (latitude, longitude) = CountryCoordinates[country];

        _mainPage.SetGeolocation(latitude, longitude);
        _mainPage.GoTo();
        _mainPage.AcceptCookies();
        _mainPage.ScrollToTheAddress();
        var currentAddress = _mainPage.AdressTitle.Text;
        _distancePage.SwitchToDistancePage();
        _distancePage.AssertDistanceUrlIsShown(_driver.Url);
        _distancePage.SetFirstAddress(currentAddress);
        _distancePage.SetSecondAddress();
        _distancePage.CalculateTheDistance();
        _distancePage.AssertCalculateTheDistanceBetwwenTwoCities();
    }
}
