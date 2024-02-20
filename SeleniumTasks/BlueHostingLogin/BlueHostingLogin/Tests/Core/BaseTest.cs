using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlueHostingLogin.@enum;
using BlueHostingLogin.Pages.BlueHostPage;
using BlueHostingLogin.Pages.LambdaTestPage;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
using WebDriverManager;

namespace BlueHostingLogin.Tests.Core;
public class BaseTest
{
    protected IWebDriver _driver;
    protected static  LambdaMainPage _lambdaMainPage;
    protected static  BlueHostMainPage _blueHostMainPage;


    [SetUp]
    public void Setup()
    {
        new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
        _driver = DriverFacade.DriverFacade.StartBrowser(BrowserType.CHROME);
        _driver.Manage().Window.Maximize();
        _lambdaMainPage = new LambdaMainPage(_driver);
        _blueHostMainPage = new BlueHostMainPage(_driver);
    }

    [TearDown]
    public void Cleanup()
    {
        _driver.Dispose();
    }
}