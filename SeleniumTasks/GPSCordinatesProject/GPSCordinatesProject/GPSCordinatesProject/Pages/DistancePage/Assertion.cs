using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using SeleniumWebdriverHelpers;

namespace GPSCordinatesProject.Pages.DistancePage;
public partial class DistancePage
{

    private string ErrorMessageUrl => "The URL is not correct";
    private string ErrorMessageIsPriceDisplayed => "The distance is not displayed";
    private string ErrorMessagePrice = "The expected distance is not correct";

    public void AssertDistanceUrlIsShown(string distanceUrl)
    {

        var expecterResult = "https://www.gps-coordinates.net/distance";
        var actualResults = distanceUrl;
        var message = $"{ErrorMessageUrl} \n Actual Text: {actualResults}, \n Expected Text: {expecterResult}";
        CollectionAssert.AreEqual(expecterResult, actualResults, message);

    }

    public void AssertCalculateTheDistanceBetwwenTwoCities(string expectedDistance)
    {
      
        WaitTextToBePresentInElement(By.XPath("//*[@id='distance']"), DistanceElement.GetText());
        ScrollToTheElement(By.XPath("//*[@id='distance']"));
        Thread.Sleep(700);
        var message = $"{ErrorMessagePrice} \n Actual Text: {DistanceElement.Text}, \n Expected Text: {expectedDistance}";      
        CollectionAssert.AreEqual(expectedDistance, DistanceElement.Text, message);
    }

    public void AsserTheDistanceBetwwenTwoCitiesIsShown()
    {
        bool isPriceDisplayed = DistanceElement.Displayed;
        Assert.That(isPriceDisplayed, ErrorMessageIsPriceDisplayed);
    }
}
