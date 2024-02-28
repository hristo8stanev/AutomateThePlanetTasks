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

        var price = WebDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class='text-5xl/9 font-bold text-[#232526] md:text-[42px] md:leading-[60px]']"))).Text;
        Console.WriteLine(price);
    }
}
    

