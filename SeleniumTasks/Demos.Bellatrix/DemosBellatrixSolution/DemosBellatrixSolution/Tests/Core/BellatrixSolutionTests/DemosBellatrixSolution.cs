using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
using WebDriverManager;
using DemosBellatrixSolution.Pages.MainPage;
using DemosBellatrixSolution.Pages.CartPage;
using DemosBellatrixSolution.Pages.CheckoutPage;
using Faker;
using DemosBellatrixSolution.Tests.Core.BaseTests;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using NUnit.Framework;

namespace DemosBellatrixSolution.Tests.Core.DemosBellatrixTests;

public class DemosBellatrixSolution : BaseTest
{
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
    public void PurchaseRocket_When_NewClientAppears()
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
        //LOG BUG FOR THIS TEST
        //IMPOSIBBLE TO USE LOGIN FORM, REGISTER FORM IS MISSING
        //PASSWORD FIELD IS MISSING
        //YOU CAN FIND IT IN  --> C:\Users\UsernameT\Documents\GitHub\AutomateThePlanetTasks\SeleniumTasks\Demos.Bellatrix\BugReport
    }

    [Test]
    public void VerifyOrdersPresence_When_AccountSectionVisited()
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