using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
using WebDriverManager;
using DemosBellatrixSolution.Pages.MainPage;
using DemosBellatrixSolution.Pages.CartPage;
using DemosBellatrixSolution.Pages.CheckoutPage;


namespace DemosBellatrixSolution;

public class DemosBellatrixSolution
{

    private IWebDriver _driver;
    BellatrixMainPage _bellatrixMainPage;
    CheckoutPage _checkoutPage;
    CartPage _cartPage;



    [SetUp]
    public void Setup()
    {
        new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
        _driver = DriverFacade.DriverFacade.StartBrowser(BrowserType.CHROME);
        _driver.Manage().Window.Maximize();
        _bellatrixMainPage = new BellatrixMainPage(_driver);
        _checkoutPage = new CheckoutPage(_driver);
        _cartPage = new CartPage(_driver);
    }

        [TearDown]
    public void Cleanup()
    {
        _driver.Dispose();
        
    }



    //DATA-DRIVEN TEST WITH ALL PRODUCT (  
    [Test]
    public void Try_ToPurchaseOfRocket_When_NewClientAppear()
    {
        //NEW CLIENT

        //USE DISCOUNT COUPON

        //INCREASE THE QUANTITY TO 3 
        _bellatrixMainPage.GoTo();
        
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