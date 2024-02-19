using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemosBellatrixSolution.Pages.CartPage;
using DemosBellatrixSolution.Pages.CheckoutPage;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
using WebDriverManager;
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
}
//    × 4