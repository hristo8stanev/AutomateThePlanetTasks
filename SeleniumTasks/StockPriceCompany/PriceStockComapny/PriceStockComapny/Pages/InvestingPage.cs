using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using PriceStockComapny.Pages.BasePage;
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
        SearchBoxFIeld.SendKeys(value);
        SearchBoxFIeld.Click();
        MoveToElement((By.XPath("//li[contains(@class ,'list_list__item__dwS6E mainSearch_search-results-item-wrapper')][1]")));
        SelectCompany.Click();
    }

    public void ClickOnHistoryDataPage()
    {
        HistoricData.Click();

    }
    public void ExtractTheStockPrice()
    {
    
        Console.WriteLine($"Last Stock Price:  {PriceExtract.Text}");
    }
}