using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlueHostingLogin.Pages;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace PriceStockComapny.Pages;
public partial class InvestingPage : WebPage
{
    public InvestingPage(IWebDriver driver) 
        : base(driver)
    {
    }

    protected override string Url => "https://www.investing.com/";



    public void SearchCompany(string value)
    {
        AcceptConceptButton.Click();
        searchBoxFIeld.SendKeys(value);
        searchBoxFIeld.Click();
        MoveToElement((By.XPath("//li[contains(@class ,'list_list__item__dwS6E mainSearch_search-results-item-wrapper')][1]")));
        SelectCompany.Click();
    }

    public void ClickOnHistoryDataPage()
    {
        historicData.Click();

    }
    public void ExtractTheStockPrice()
    {
      
        IWebElement priceElement = Driver.FindElement(By.XPath("//div[@data-test='instrument-price-last']"));
        string priceText = priceElement.Text;
        Console.WriteLine($"Last Stock Price:  {priceText}");
    }
}