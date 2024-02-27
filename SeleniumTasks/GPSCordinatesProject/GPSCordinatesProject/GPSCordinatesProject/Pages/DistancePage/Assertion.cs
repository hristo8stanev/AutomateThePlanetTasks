using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using SeleniumWebdriverHelpers;

namespace GPSCordinatesProject.Pages.DistancePage;
public partial class DistancePage
{

    private string ErrorMessageUrl => "The URL does not contain 'order-received'";
    private string ErrorMessagePrice = "The expected price is not correct";

    public void AssertDistanceUrlIsShown(string distanceUrl)
    {

        var expecterResult = "https://www.gps-coordinates.net/distance";
        var actualResults = distanceUrl;
        var message = $"{ErrorMessageUrl} \n Actual Text: {actualResults}, \n Expected Text: {expecterResult}";
        CollectionAssert.AreEqual(expecterResult, actualResults, message);

    }

    public void AssertCalculateTheDistanceBetwwenTwoCities(string expectedDistance)
    {
        var actualDistance = DistanceElement.GetText();
        WaitTextToBePresentInElement(By.XPath("//*[@id='distance']"), actualDistance);
        var message = $"{ErrorMessagePrice} \n Actual Text: {actualDistance}, \n Expected Text: {expectedDistance}";

        CollectionAssert.AreEqual(expectedDistance, actualDistance, message);
    }

    public void AsserTheDistanceBetwwenTwoCitiesIsShown()
    {
        bool isPriceDisplayed = DistanceElement.Displayed;
        Assert.That(isPriceDisplayed);
    }
}
