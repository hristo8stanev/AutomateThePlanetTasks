using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace BlueHostingLogin.Pages.BlueHostPage;
public partial class BlueHostMainPage : WebPage
{
    public BlueHostMainPage(IWebDriver driver)
        : base(driver)
    {
    }

    protected override string Url => "https://www.bluehost.com/my-account/login";
    public void ClickOnWemailLogin()
    {
        WebmailLogin.Click();

    }
    public void AcceptCookies()
    {
        AcceptCookie.Click();
    }

    public void FillEmail(FillingInfo purchaseInfo)
    {
        EmailField.SendKeys(purchaseInfo.EmailAdress);
    }


    public void ProceedWithLogin()
    {
        LoginButton.Click();
        NextButton.Click();

    }

   
}
