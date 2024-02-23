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


namespace PriceStockComapny.Tests.BaseTest;

public class StockPriceTests : BaseTest
{

    string companyName = "Google";

    [Test]
    public void CompanyHistoryStocksPricesTest()
    {

        _investingPage.GoTo();
        _investingPage.SearchCompany(companyName);
        _investingPage.ClickOnHistoryDataPage();
        _investingPage.ExtractTheStockPrice();
        _investingPage.AssertHistoricDataUrlIsCorrect(_driver.Url);
        _investingPage.AssertPriceStockIsShown();
    }
}