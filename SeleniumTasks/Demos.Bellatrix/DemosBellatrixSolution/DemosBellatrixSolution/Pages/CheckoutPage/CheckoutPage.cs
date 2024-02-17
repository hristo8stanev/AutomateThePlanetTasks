using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using static System.Net.WebRequestMethods;

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
        BillingEmail.SendKeys(purchaseInfo.Email);
        BillingCountry.SendKeys(purchaseInfo.Country);
        BillingAddress.SendKeys(purchaseInfo.Address1);
        BillingAddress.SendKeys(purchaseInfo.City);
        BillingPostCode.SendKeys(purchaseInfo.PostCode);
        BillingPostCode.SendKeys(purchaseInfo.Phone);

    }
} 


