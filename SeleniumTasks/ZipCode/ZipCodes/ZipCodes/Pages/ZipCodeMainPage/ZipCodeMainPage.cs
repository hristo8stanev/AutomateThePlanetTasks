using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
