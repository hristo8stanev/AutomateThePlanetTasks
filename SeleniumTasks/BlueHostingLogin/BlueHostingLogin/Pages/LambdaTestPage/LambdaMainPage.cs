using BlueHostingLogin.Pages.BasePage;
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
