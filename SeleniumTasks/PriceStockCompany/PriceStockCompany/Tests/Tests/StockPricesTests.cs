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
using PriceStockCompany.Tests.Core;

namespace PriceStockCompany.Tests.Tests;

public class StockPricesTests : BaseTest
{
    
    string compnanyName = "Tesla";
    
    [Test]
    public void CompanyHistoryStocksPricesTest()
    {

        _mainPage.GoTo();
        _mainPage.AcceptCookies();
        _mainPage.SearchCompany(compnanyName);
        _mainPage.ChooseFirstResultFromSearchButton();
        _mainPage.ProceedToTheHistoryPriceOftheStock();
        _mainPage.AssertHistoricalDataUrlIsShown(_driver.Url);
        _mainPage.AssertThePriceOfStockIsShown();
    }
}