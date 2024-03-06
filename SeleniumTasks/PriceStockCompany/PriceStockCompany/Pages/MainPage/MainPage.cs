using OpenQA.Selenium;
using PriceStockCompany.Pages.BasePage;
using SeleniumExtras.WaitHelpers;

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
        VisibilityOfAllElementsLocated(MainSearchDescription);
        MoveToElement(FirstResultCompany);
        VisibilityOfAllElementsLocated(FirstResultCompany);
        ClickOnFirstResult.Click();
    }
    
    public void ProceedToTheHistoryPriceOftheStock()
    {

        HistoryDataPrice.Click();
    }
}