using GPSCordinatesProject.Test.Core.BaseTest;

namespace GPSCordinatesProject.Tests.DistanceTests;
public class CalculateTheDistanceBetweenToCities : BaseTest
{

     [TestCase("Germany", "Unter den Linden, Friedrichstraße, 10117 Berlin", "0.01 km / 0 mi")]
     [TestCase("Argentina", "Obelisco, Avenida Corrientes, San Nicolás, Buenos Aires", "11921.52 km / 7407.69 mi")]
     [TestCase("Australia", "Australian Capital Territory, CGS Rowing, Alexandrina Drive, Yarralumla 2600", "16089.14 km / 9997.33 mi")]
     [TestCase("Canada", "World Exchange Plaza, 45 O'Connor Street, Ottawa, ON K1P 5M4", "6134.52 km / 3811.82 mi")]
     [TestCase("Japan", "unnamed road, Izumi 2, Suginami, 168-0063", "8926.31 km / 5546.55 mi")]
     [TestCase("11455, Taipei Neihu District 開眼山步道", "Taiwan", "8965.74 km / 5571.05 mi")]
     [TestCase("Norway", "Karl Johans gate, 0026 Oslo", "839.35 km / 521.55 mi")]
     [TestCase("South Africa", "unnamed road, City Centre, Cape Town, 8001", "9635.01 km / 5986.92 mi")]
     [Test]
    public void CalculateDistanceBetweenTheTwoCities(string country, string city, string distance)
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

        _distancePage.AssertCalculateTheDistanceBetwwenTwoCities(distance);
        _distancePage.AsserTheDistanceBetwwenTwoCitiesIsShown();
    }
}
 