using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
using WebDriverManager;
using DemosBellatrixSolution.Pages.MainPage;
using DemosBellatrixSolution.Pages.CartPage;
using DemosBellatrixSolution.Pages.CheckoutPage;
using Faker;
using DemosBellatrixSolution.Pages.MainPage.MainPage;
using DemosBellatrixSolution.Tests.Core.BaseTests;

namespace DemosBellatrixSolution.Tests.Core.DemosBellatrixTests;

public class DemosBellatrixSolution : BaseTest
{
    private string CouponVaucher => "happybirthday";
    string RandomFirstName;
    string RandomLastName;
    string randomEmail;


    [OneTimeSetUp]
    public void generateInputData()
    {
        RandomFirstName = Internet.UserName();
        RandomLastName = Internet.UserName();
        randomEmail = Internet.UserName() + "@gmail.com";
    }


    [Test]
    [TestCase("Falcon 9")]
    [TestCase("Proton Rocket")]
    [TestCase("Proton-M")]
    [TestCase("Saturn V")]
    [TestCase("Falcon Heavy")]
    public void PurchaseRocket_When_NewClientAppearsWithDifferentRockets(string rocketName)
    {
        var purchaseInfo = new PurchaseInfo()
        {
            FirstName = RandomFirstName,
            LastName = RandomLastName,
            Company = "Automate The Planet",
            Country = "Germany",
            Address1 = "Random Street 123",
            Address2 = "Random Random Street 321",
            Zip = "10115",
            City = "Varna",
            Phone = "+088223182",
            Email = randomEmail,
            RocketName = "Falcon 9"
        };

        _bellatrixMainPage.GoTo();
        _bellatrixMainPage.AddRocketToCart(rocketName);
        _cartPage.AppluCouponVaucher(CouponVaucher);
        _cartPage.AssertCouponApplied();
        _cartPage.IncreaseProductQuantity(3);
        _cartPage.ProceedToCheckoOut();
        _cartPage.AssertCheckoutPage(_driver.Url);

        _checkoutPage.FillBillingInfo(purchaseInfo);
        _checkoutPage.AssertOrderReceived();
        _checkoutPage.AssertOrderReceivedUr(_driver.Url);
    }


    [Test]
    public void Try_ToPurchaseOfRocket_When_AlreadyExistingClient_TryToUse_LoginFormPrefillingBillingInfo()
    {

        _bellatrixMainPage.GoTo();
    }

    [Test]
    public void Try_ToVerifyAllOrdersPresentInTheAccountSection()
    {

        _bellatrixMainPage.GoTo();
    }
}