using DemosBellatrixSolution.Pages.BaseWebPage;
using OpenQA.Selenium;

namespace DemosBellatrixSolution.Pages.CheckoutPage;

public partial class CheckoutPage : WebPage
{
    public CheckoutPage(IWebDriver driver)
    : base(driver)
    {
    }

    protected override string Url => "https://demos.bellatrix.solutions/checkout/";

    public void FillBillingInfo(PurchaseInfo purchaseInfo)
    {
        BillingFirstName.SendKeys(purchaseInfo.FirstName);
        BillingLastName.SendKeys(purchaseInfo.LastName);
        BillingCompany.SendKeys(purchaseInfo.Company);
        BillingCountryWrapper.Click();
        BillingCountryFilter.SendKeys(purchaseInfo.Country);
        GetCountryByName(purchaseInfo.Country).Click();
        BillingAddress1.SendKeys(purchaseInfo.Address1);
        BillingAddress2.SendKeys(purchaseInfo.Address2);
        BillingZip.SendKeys(purchaseInfo.Zip);
        BillingCity.SendKeys(purchaseInfo.City);
        BillingPhone.SendKeys(purchaseInfo.Phone);
        BillingEmail.SendKeys(purchaseInfo.Email);

        if (purchaseInfo.ShouldCreateAccout == false)
        {
            CreateAccountButtonBox.Click();

        }

        if (purchaseInfo.ShouldCheckPayment == false)
        {
            
            var PlaceOrderLocator = PlaceOrderButton.Displayed;
            var PaymentLocator = PaymentElement.Displayed;
            CheckPaymentsButton.Click();
        }

        WaitForAjax();
        PlaceOrderButton.Click();
        WaitForAjax();
    }

    public void ProceedToPlaceOrder()
    {
        PlaceOrderButton.Click();
    }
} 


