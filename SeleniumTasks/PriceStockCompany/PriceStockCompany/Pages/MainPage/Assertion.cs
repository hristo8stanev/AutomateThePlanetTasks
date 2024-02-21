using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace PriceStockCompany.Pages.MainPage;
public partial class MainPage
{
    private string ErrorMessageUrl => "Your URL is not correct";

    public void AssertHistoricalDataUrlIsShown(string currentUrl)
    {

        Assert.That(currentUrl.Contains("historical-data"), Is.True, ErrorMessageUrl);
    }

    public void AssertThePriceOfStockIsShown()
    {

        var price = WebDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='flex flex-wrap gap-x-4 gap-y-2 items-center md:gap-6 mb-3 md:mb-0.5']"))).Text;
        Console.WriteLine(price);
    }
}
    

