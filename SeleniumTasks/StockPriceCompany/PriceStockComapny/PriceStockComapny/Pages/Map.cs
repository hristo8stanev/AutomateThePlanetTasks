using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace PriceStockComapny.Pages;
public partial class InvestingPage
{

    public IWebElement AcceptConceptButton => WaitElementToBeClicable(By.Id("onetrust-accept-btn-handler"));
    public IWebElement searchBoxFIeld => WaitElementToBeClicable(By.XPath("//input[@data-test='search-section']"));
    public IWebElement SelectCompany => WaitElementToBeClicable(By.XPath("//li[contains(@class ,'list_list__item__dwS6E mainSearch_search-results-item-wrapper')][1]"));
    public IWebElement historicData => WaitAndFindElement(By.XPath("//li[@data-test='Historical Data']"));
    public IWebElement priceField => WaitAndFindElement(By.XPath("//div[@class='flex flex-wrap gap-x-4 gap-y-2 items-center md:gap-6 mb-3 md:mb-0.5']"));
    public IWebElement priceExtract => WaitAndFindElement(By.XPath("//div[@data-test='instrument-price-last']"));

}
