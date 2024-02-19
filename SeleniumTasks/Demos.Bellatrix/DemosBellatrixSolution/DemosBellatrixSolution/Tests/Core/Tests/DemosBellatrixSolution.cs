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
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace DemosBellatrixSolution.Tests.Core.DemosBellatrixTests;

public class DemosBellatrixSolution : BaseTest
{
    private string CouponVaucher => "happybirthday";

    private int Quantity => 4;
    string RandomFirstName;
    string RandomLastName;
    string randomEmail;
    string randomAddress1;
    string randomAddress2;
    string randomCompany;


    [OneTimeSetUp]
    public void generateInputData()
    {
        RandomFirstName = Faker.Name.First();
        RandomLastName = Faker.Name.Last();
        randomEmail = Faker.Name.First() + "@gmail.com";
        randomAddress1 = Faker.Address.StreetAddress();
        randomAddress2 = Faker.Address.StreetAddress();
        randomCompany = Faker.Company.Name();
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
            Company = randomCompany,
            Country = "Germany",
            Address1 = randomAddress1,
            Address2 = randomAddress2,
            Zip = "10115",
            City = "Munich",
            Phone = "3594231232",
            Email = randomEmail,
            RocketName = "Falcon 9"
        };

        _bellatrixMainPage.GoTo();
        _bellatrixMainPage.AddRocketToCart(rocketName);
        _cartPage.AppluCouponVaucher(CouponVaucher);
        _cartPage.AssertCouponApplied();
        _cartPage.IncreaseProductQuantity(Quantity);
        _cartPage.ProceedToCheckoOut();
        _checkoutPage.AssertQuantityOfTheProductCheckoutPage(rocketName, Quantity);
        _checkoutPage.AssertCheckoutPage(_driver.Url);
        _checkoutPage.FillBillingInfo(purchaseInfo);
        _checkoutPage.AssertOrderReceived();
        _checkoutPage.AssertOrderReceivedUr(_driver.Url);
    }


    [Test]
    public void Try_ToPurchaseOfRocket_When_AlreadyExistingClient_TryToUse_LoginFormPrefillingBillingInfo()
    {
        //LOG BUG FO THIS TEST
        _bellatrixMainPage.GoTo();
    }

    [Test]
    public void Try_ToVerifyAllOrdersPresentInTheAccountSection()
    {

        _bellatrixMainPage.GoTo();
    }
}