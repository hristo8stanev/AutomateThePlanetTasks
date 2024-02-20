using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlueHostingLogin.Pages.BasePage;
using BlueHostingLogin.Pages.BlueHostPage;
using OpenQA.Selenium;

namespace BlueHostingLogin.Pages.LambdaTestPage;
public partial class LambdaMainPage : WebPage
{
    public LambdaMainPage(IWebDriver driver)
        : base(driver)
    {
    }

    protected override string Url => "https://accounts.lambdatest.com/register";

    public void FillBillingInfo(PurchaseInfo purchaseInfo)
    {
        LambdaEmailField.SendKeys(purchaseInfo.EmailAdress);
        LambdaPasswordField.SendKeys(purchaseInfo.Password);
    }

    public void ProceedToUserLogin()
    {
        LambdaSubmitButton.Click();
        LambdaVerifyButton.Click();

    }

    
}
