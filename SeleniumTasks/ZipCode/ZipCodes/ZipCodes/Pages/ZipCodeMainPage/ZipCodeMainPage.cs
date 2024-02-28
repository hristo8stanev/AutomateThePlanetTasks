using OpenQA.Selenium;
using ZipCodes.Pages.BasePage;

namespace ZipCodes.Pages.ZipCodeMainPage;
public partial class ZipCodeMainPage : WebPage
{
    public ZipCodeMainPage(IWebDriver driver)
        : base(driver)
    {
    }
    protected override string Url => "https://www.zip-codes.com/";

    public void AdvanceSearch()
    {
        ProceedToSearchButton.Click();
    }
}
