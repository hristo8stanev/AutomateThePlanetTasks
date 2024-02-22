using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using ZipCodes.Pages.BasePage;
using static System.Net.Mime.MediaTypeNames;

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
        AcceptCookie.Click();
    }

    public void AcceptGoogleCookies()
    { 
     var consentForm = WebDriverWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@class='G4njw']")));
     var agreeButton = consentForm.FindElement(By.XPath("(//*[@class='VfPpkd-LgbsSe VfPpkd-LgbsSe-OWXEXe-k8QpJ VfPpkd-LgbsSe-OWXEXe-dgl2Hf nCP5yc AjY5Oe DuMIQc LQeN7 XWZjwc'])[2]"));
     agreeButton.Click();
    }

    public void SearchTownByName(string name)
    {
        CityField.SendKeys(name);
        searchField.Click();
    }
}