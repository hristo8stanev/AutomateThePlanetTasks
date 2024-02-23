using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using PriceStockComapny.Pages;
using PriceStockCompany.enums;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
using WebDriverManager;

namespace PriceStockComapny.Tests.BaseTest;
public class BaseTest
{
    protected IWebDriver _driver;
    public InvestingPage _investingPage;

    [SetUp]
    public void Setup()
    {
        new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
        _driver = DriverFacade.DriverFacade.StartBrowser(BrowserType.FIREFOX);
        _driver.Manage().Window.Maximize();
        _investingPage = new InvestingPage(_driver);
    }

    [TearDown]
    public void Cleanup()
    {

        _driver.Dispose();
    }
}
