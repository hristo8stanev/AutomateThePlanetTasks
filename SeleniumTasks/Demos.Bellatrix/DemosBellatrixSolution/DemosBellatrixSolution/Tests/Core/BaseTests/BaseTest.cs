using DemosBellatrixSolution.Pages.CartPage;
using DemosBellatrixSolution.Pages.CheckoutPage;
using OpenQA.Selenium;
using DemosBellatrixSolution.Pages.MainPage;

namespace DemosBellatrixSolution.Tests.Core.BaseTests;
public class BaseTest
{
    protected IWebDriver _driver;
    public static BellatrixMainPage _bellatrixMainPage;
    public static CheckoutPage _checkoutPage;
    public static CartPage _cartPage;

    [SetUp]
    public void Setup()
    {
        _driver = DriverFacade.StartBrowserType.StartBrowser(BrowserType.FIREFOX);
        _driver.Manage().Window.Maximize();
        _bellatrixMainPage = new BellatrixMainPage(_driver);
        _checkoutPage = new CheckoutPage(_driver);
        _cartPage = new CartPage(_driver);
    }

    [TearDown]
    public void Cleanup()
    {
        _driver.Close();

    }
}