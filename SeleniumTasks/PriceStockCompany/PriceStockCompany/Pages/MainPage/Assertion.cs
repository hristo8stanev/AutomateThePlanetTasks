using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using NUnit.Framework.Legacy;
using System.Diagnostics.Metrics;

namespace PriceStockCompany.Pages.MainPage;
public partial class MainPage
{
    private const string ErrorMessagePrice = "The price is not displated";

    private string ErrorMessageUrl => "Your URL is not correct";

    public void AssertHistoricalDataUrlIsShown(string currentUrl)
    {

        Assert.That(currentUrl.Contains("historical-data"), Is.True, ErrorMessageUrl);
    }

    public void AssertThePriceOfStockIsShown()
    {

        MoveToElement(PriceElement);
        bool actualResults = priceDisplayed.Displayed;
        Assert.That(actualResults, ErrorMessagePrice);

        var price = priceDisplayed.Text;
        var message = $"Actual Text: {price}";
        Console.WriteLine(message);
    }
}
    

