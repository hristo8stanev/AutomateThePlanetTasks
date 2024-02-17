using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
using WebDriverManager;
using SeleniumExtras.WaitHelpers;
using System.Diagnostics;
using SeleniumWebdriverHelpers;
using PriceStockCompany.enums;
using PriceStockComapny.Pages;


namespace PriceStockComapny;

public class StockPriceTests
{
   
    private IWebDriver _driver;
    public InvestingPage _investingPage;
    string companyName;

    [SetUp]
    public void Setup()
    {
        new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
        _driver = DriverFacade.DriverFacade.StartBrowser(BrowserType.FIREFOX);
        _driver.Manage().Window.Maximize();
        _investingPage = new InvestingPage(_driver);
        companyName = "Google";
    }

    [TearDown]
    public void Cleanup()
    {

        _driver.Dispose();
    }

    [Test]
    public void CompanyHistoryStocksPricesTest()
    {

        _investingPage.GoTo();
        _investingPage.SearchCompany(companyName);
        _investingPage.ClickOnHistoryDataPage();
        _investingPage.ExtractTheStockPrice();
        _investingPage.AssertHistoricDataUrlIsCorrect(_driver.Url);
    }
}