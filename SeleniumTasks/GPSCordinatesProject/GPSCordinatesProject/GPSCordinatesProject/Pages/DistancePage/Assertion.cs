﻿using NUnit.Framework.Legacy;

namespace GPSCordinatesProject.Pages.DistancePage;
public partial class DistancePage
{

    private string ErrorMessageUrl => "The URL does not contain 'order-received'";

    public void AssertDistanceUrlIsShown(string distanceUrl)
    {

        var expecterResult = "https://www.gps-coordinates.net/distance";
        var actualResults = distanceUrl;
        var message = $"{ErrorMessageUrl} \n Actual Text: {actualResults}, \n Expected Text: {expecterResult}";
        CollectionAssert.AreEqual(expecterResult, actualResults, message);

    }

    public void AssertCalculateTheDistanceBetwwenTwoCities()
    {
        bool isPriceDisplayed = DistanceElement.Displayed;
        Assert.That(isPriceDisplayed);
    }
}
