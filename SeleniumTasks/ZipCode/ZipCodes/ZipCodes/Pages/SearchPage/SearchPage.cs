using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using ZipCodes.Pages.BasePage;

namespace ZipCodes.Pages.SearchPage;
public partial class SearchPage : WebPage
{
    public SearchPage(IWebDriver driver)
        : base(driver)
    {
    }
    protected override string Url => "https://www.zip-codes.com/search.asp";


    public void ProceedToAdvanceSearch()
    {
        AdvanceSearchButton.Click();

    }

    public void AcceptCookies()
    {
        acceptCookie.Click();
    }
    public void SearchTownByName(string name)
    {
        CityField.SendKeys(name);
        searchField.Click();
    }

    public void ChooseFirstCity()
    {
        FirstCity.Click();
    }

}
    


