using OpenQA.Selenium;
using PriceStockCompany.Pages.BasePage;

namespace PriceStockCompany.Pages.MainPage;
public partial class MainPage : WebPage
{
    public MainPage(IWebDriver driver)
        : base(driver)
    {
    }

    protected override string Url => "https://www.investing.com/";

    public void AcceptCookies()
    {
        AcceptCookieButton.Click();
    }

    public void SearchCompany(string companyName)
    {
        SearchBoxField.Click();
        SearchBoxField.SendKeys(companyName);
        SearchBoxField.Click();

    }

    public void ChooseFirstResultFromSearchButton()
    {
        Thread.Sleep(500);
        MoveToElement(By.XPath("(//*[@class='mainSearch_description__mrmg5'])[1]"));
        ClickOnFirstResult.Click();
    }
    
    public void ProceedToTheHistoryPriceOftheStock()
    {

        HistoryDataPrice.Click();
    }
}
