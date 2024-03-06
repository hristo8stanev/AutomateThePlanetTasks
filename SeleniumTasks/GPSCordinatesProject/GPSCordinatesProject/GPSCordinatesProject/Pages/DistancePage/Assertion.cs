using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using SeleniumWebdriverHelpers;

namespace GPSCordinatesProject.Pages.DistancePage;
public partial class DistancePage
{

    private string ErrorMessageUrl => "The URL is not correct";
    private string ErrorMessageIsPriceDisplayed => "The distance is not displayed";
    private string ExpectedUrl =>"https://www.gps-coordinates.net/distance";
    private string ErrorMessagePrice => "The expected distance is not correct";

    public void AssertDistanceUrlIsShown(string distanceUrl)
    {
  
        var message = $"{ErrorMessageUrl} \n Actual URL:{distanceUrl} \n Expected URL:{ExpectedUrl}";
        CollectionAssert.AreEqual(distanceUrl,ExpectedUrl, message);

    }

    public void AssertCalculateTheDistanceBetwwenTwoCities(string expectedDistance)
    {
      
        WaitTextToBePresentInElement(By.XPath("//*[@id='distance']"), DistanceElement.GetText());
        ScrollToTheElement(Distance);
        MoveToElement(DistanceField);
        var message = $"{ErrorMessagePrice} \n Actual Distance:{DistanceElement.Text}, \n Expected Distance:{expectedDistance}";      
        CollectionAssert.AreEqual(expectedDistance,DistanceElement.Text, message);
    }

    public void AsserTheDistanceBetwwenTwoCitiesIsShown()
    {
        bool isPriceDisplayed = DistanceElement.Displayed;
        Assert.That(isPriceDisplayed, ErrorMessageIsPriceDisplayed);
    }
}
