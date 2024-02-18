using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
using WebDriverManager;
using DemosBellatrixSolution.Pages.MainPage;
using DemosBellatrixSolution.Pages.CartPage;
using DemosBellatrixSolution.Pages.CheckoutPage;
using Faker;

namespace DemosBellatrixSolution;

public class DemosBellatrixSolution
{

    private IWebDriver _driver;
    BellatrixMainPage _bellatrixMainPage;
    CheckoutPage _checkoutPage;
    CartPage _cartPage;
    string RandomFirstName;
    string RandomLastName;
    string randomEmail;

    [SetUp]
    public void Setup()
    {
        new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
        _driver = DriverFacade.DriverFacade.StartBrowser(BrowserType.CHROME);
        _driver.Manage().Window.Maximize();
        _bellatrixMainPage = new BellatrixMainPage(_driver);
        _checkoutPage = new CheckoutPage(_driver);
        _cartPage = new CartPage(_driver);
        RandomFirstName = Internet.UserName();
        RandomLastName = Internet.UserName();
        randomEmail = Internet.UserName() + "@gmail.com";
    }

        [TearDown]
    public void Cleanup()
    {
        _driver.Dispose();
        
    }

    [Test]
    [TestCase("Falcon 9")]
    [TestCase("Proton Rocket")]
    [TestCase("Proton-M")]
    [TestCase("Saturn V")]
    [TestCase("Falcon Heavy")]
    public void PurchaseRocket_When_NewClientAppear(string rocketName)
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
            RocketName = rocketName
        };

        _bellatrixMainPage.GoTo();
        _bellatrixMainPage.AddRocketToCart(rocketName);
        _cartPage.AppluCouponVaucher("happybirthday");
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