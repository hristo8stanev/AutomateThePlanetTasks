using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using SeleniumWebdriverHelpers;

namespace GPSCordinatesProject.Pages.MainPage;
public partial class MainPage
{
    private string ErrorMessageMap => "Map Address is not displayed";
    private string ErrorMessageCity => "Your expected City and Country is not displayed";
    private string ErrorMessageCordinates => "Your expected Longtitude and Latitude is not displayed";


    public void AssertCityAndCountryIsCorrect(string city, string country)
    {
        MoveToElement(Address);

        var expecterResult = $"{country}, {city}";
        var actualResults = AdressTitle.Text;
        var message = $"{ErrorMessageCity} \n Actual SetCountries: {actualResults}, \n Expected SetCountries: {expecterResult}";
        CollectionAssert.AreEqual(expecterResult, actualResults, message);
    }

    public void AssertLongtitudeAndLatitudeIsCorrect(double latitude, double longtitude)
    {
        var expecterResult = $"Latitude: {latitude} | Longitude: {longtitude}";
        var replace = "\r\n\r\nGet Altitude";
        var actualResults = Cordinates.GetText().Replace(replace,"");
        var message = $"{ErrorMessageCordinates} \n Actual SetCountries: {actualResults}, \n Expected SetCountries: {expecterResult}";
        CollectionAssert.AreEqual(expecterResult, actualResults,message);

    }

    public void AssertMapIsDisplayed()
    {
        bool isMapDisplayed = Map.Displayed;
        Assert.That(isMapDisplayed, ErrorMessageMap);

    }
}
