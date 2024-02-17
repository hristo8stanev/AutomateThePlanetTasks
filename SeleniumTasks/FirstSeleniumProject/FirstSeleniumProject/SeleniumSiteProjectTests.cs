using System.Security.Principal;
using AngleSharp.Dom;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
using SeleniumExtras.WaitHelpers;
using static System.Net.WebRequestMethods;
using FirstSeleniumProject.Pages.GettingStartedPage;
using FirstSeleniumProject;
using FirstSeleniumProject.@enum;


namespace SeleniumSiteProject;
public class SeleniumTests : IDisposable
{
    private static IWebDriver _driver;
    private static MainPage _mainPage;

    public SeleniumTests()
    {
        new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
        _driver = DriverFacade.StartBrowser(BrowserType.CHROME);
        _driver.Manage().Window.Maximize();
        _mainPage = new MainPage(_driver);
    }

    [TearDown]
    public void Dispose()
    {

        _driver.Quit();
    }


    [Test]
    public void SeleniumDocumentationComponentGridFieldClicknOnGitHubRepoLink()
    {
        _mainPage.GoTo();
        _mainPage.ClickOnComponentsField();
        _mainPage.AssertComponentsDocumentationPageIsShown(_driver.Url);
        _mainPage.CliclOnGitHubRepoLink();
        _mainPage.AssertGitHubLinkIsShown(_driver.Url);
    }
}