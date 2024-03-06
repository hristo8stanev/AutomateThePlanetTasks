using OpenQA.Selenium;

namespace PriceStockCompany.Pages.MainPage;
public partial class MainPage
{
    public IWebElement AcceptCookieButton => WaitAndFindElement(By.Id("onetrust-accept-btn-handler"));
    public IWebElement SearchBoxField => WaitAndFindElement(By.XPath("//*[@data-test='search-section']"));
    public IWebElement ClickOnFirstResult => WaitAndFindElement(By.XPath("//*[contains(@class ,'list_list__item__dwS6E mainSearch_search-results-item-wrapper__NUG7e')][1]"));
    public IWebElement HistoryDataPrice => WaitAndFindElement(By.XPath("//*[@data-test='Historical Data']"));
    public string MainSearchDescription => "(//*[@class='mainSearch_description__mrmg5'])[1]";
    public string FirstResultCompany => "//*[contains(@class ,'list_list__item__dwS6E mainSearch_search-results-item-wrapper__NUG7e')][1]";
    public IWebElement priceDisplayed => WaitAndFindElement(By.XPath("//*[@class='text-5xl/9 font-bold text-[#232526] md:text-[42px] md:leading-[60px]']"));
    public string PriceElement => "//*[@class='text-5xl/9 font-bold text-[#232526] md:text-[42px] md:leading-[60px]']";
    public IWebElement PriceOfTheCompany => WaitAndFindElement(By.XPath("//div[@class='flex flex-wrap gap-x-4 gap-y-2 items-center md:gap-6 mb-3 md:mb-0.5']"));
}
