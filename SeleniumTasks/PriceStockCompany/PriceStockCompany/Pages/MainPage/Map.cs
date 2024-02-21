using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace PriceStockCompany.Pages.MainPage;
public partial class MainPage
{
    public IWebElement AcceptCookieButton => WaitAndFindElement(By.Id("onetrust-accept-btn-handler"));
    public IWebElement SearchBoxField => WaitAndFindElement(By.XPath("//*[@data-test='search-section']"));
    public IWebElement ClickOnFirstResult => WaitAndFindElement(By.XPath("//*[contains(@class ,'list_list__item__dwS6E mainSearch_search-results-item-wrapper__NUG7e')][1]"));
    public IWebElement HistoryDataPrice => WaitAndFindElement(By.XPath("//*[@data-test='Historical Data']"));
    public IWebElement PriceOfTheCompany => WaitAndFindElement(By.XPath("//div[@class='flex flex-wrap gap-x-4 gap-y-2 items-center md:gap-6 mb-3 md:mb-0.5']"));
}
