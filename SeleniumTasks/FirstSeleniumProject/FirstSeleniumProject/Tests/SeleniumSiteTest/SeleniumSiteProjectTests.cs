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
using FirstSeleniumProject.Tests.Core.BaseTest;


namespace FirstSeleniumProject.Tests.SeleniumSiteProjectTests;
public class SeleniumTests : BaseTest
{
  
    [Test]
    public void SeleniumDocumentationComponentGridFieldClicknOnGitHubRepoLink()
    {
        _mainPage.GoTo();
        _mainPage.ProceedToComponents();
        _mainPage.AssertComponentsDocumentationPageIsShown(_driver.Url);
        _mainPage.ProceedToGitHubLink();
        _mainPage.AssertGitHubLinkIsShown(_driver.Url);
    }
}