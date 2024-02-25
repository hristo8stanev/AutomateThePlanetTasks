using DemosBellatrixSolution.Pages.CheckoutPage;
using DemosBellatrixSolution.Tests.Core.BaseTests;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Chrome;

namespace DemosBellatrixSolution.Tests.Core.DemosBellatrixTests;

public class DemosBellatrixSolution : BaseTest
{

    protected DevToolsSession session;
    private string CouponVaucher => "happybirthday";
    string rocketName => "Falcon 9";
    private int quantity => 3;
    string randomFirstName;
    string randomLastName;
    string randomEmail;
    string randomAddress1;
    string randomAddress2;
    string randomCompany;
    

    [SetUp]
    public void generateInputData()
    {
        randomFirstName = Faker.Name.First();
        randomLastName = Faker.Name.Last();
        randomEmail = Faker.Name.First() + "@gmail.com";
        randomAddress1 = Faker.Address.StreetAddress();
        randomAddress2 = Faker.Address.StreetAddress();
        randomCompany = Faker.Company.Name();
    }

    [Test]
    public void NewClientCanPurchaseRocketSuccessfully()
    {

        var purchaseInfo = new PurchaseInfo()
        {
            FirstName = randomFirstName,
            LastName = randomLastName,
            Company = randomCompany,
            Country = "Germany",
            Address1 = randomAddress1,
            Address2 = randomAddress2,
            Zip = "10115",
            City = "Munich",
            Phone = "3594231232",
            Email = randomEmail,
            RocketName = rocketName,
        };
         
        _bellatrixMainPage.GoTo();
        _bellatrixMainPage.AddRocketToCart(rocketName);
        _cartPage.AppluCouponVaucher(CouponVaucher);
        _cartPage.AssertCouponApplied();
        _cartPage.IncreaseProductQuantity(quantity);
        _cartPage.AssertQuantityOfTheProductCartPage(quantity);
        _cartPage.ProceedToCheckoOut();
        _checkoutPage.AssertQuantityOfTheProductCheckoutPage(rocketName, quantity);
        _checkoutPage.AssertCheckoutPage(_driver.Url);
        _checkoutPage.FillBillingInfo(purchaseInfo);
        _checkoutPage.AssertOrderReceived();
        _checkoutPage.AssertOrderReceivedUr(_driver.Url);
    }


    [Test]
    public void PurchaseRocket_When_ExistingClientWithLoginForm()
    {
        //I LOGGED BUG FOR THIS TES.T
        //IMPOSIBBLE TO USE LOGIN FORM, REGISTER FORM IS MISSING
        //PASSWORD FIELD IS MISSING IN BILLING DETAILS FORM
        //YOU CAN FIND IT IN  --> BugReport Folder
    }

    [Test]
    public void OrdersAppearInAccountSectionAfterPurchase()
    {
        var purchaseInfo = new PurchaseInfo()
        {
            FirstName = randomFirstName,
            LastName = randomLastName,
            Company = randomCompany,
            Country = "Germany",
            Address1 = randomAddress1,
            Address2 = randomAddress2,
            Zip = "10115",
            City = "Munich",
            Phone = "3594231232",
            Email = randomEmail,
            RocketName = rocketName,
        };

        _bellatrixMainPage.GoTo();
        _bellatrixMainPage.AddRocketToCart(rocketName);
        _cartPage.AppluCouponVaucher(CouponVaucher);
        _cartPage.AssertCouponApplied();
        _cartPage.IncreaseProductQuantity(quantity);
        _cartPage.AssertQuantityOfTheProductCartPage(quantity);
        _cartPage.ProceedToCheckoOut();
        _checkoutPage.AssertQuantityOfTheProductCheckoutPage(rocketName, quantity);
        _checkoutPage.AssertCheckoutPage(_driver.Url);
        _checkoutPage.FillBillingInfo(purchaseInfo);
        _checkoutPage.AssertOrderReceived();
        _checkoutPage.AssertOrderReceivedUr(_driver.Url);
        _bellatrixMainPage.EnterMyOrderSection();
        _bellatrixMainPage.AssertMyOrdersIsShown();
    }
}