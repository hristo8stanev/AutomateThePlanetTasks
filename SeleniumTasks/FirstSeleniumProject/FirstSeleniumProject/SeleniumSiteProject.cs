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


namespace SeleniumSiteProject;
public class SeleniumTests
{
    private string seleniumSiteUrl = "https://www.selenium.dev/documentation/webdriver/getting_started/";
    private string githubUrl => "https://github.com/SeleniumHQ/seleniumhq.github.io/commit/6b87463b63700d38146e82130776bf4d832bf82d";
    private IWebDriver driver;
    private WebDriverWait wait;
    

        [SetUp]
        public void Setup()
        {
        new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Navigate().GoToUrl("https://www.selenium.dev/documentation/en/getting_started");
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }


    [Test]
        public void SeleniumDocumentationPageTitleCurrentUrlTests()
        {

        string currentURL = driver.Url;
        Assert.That(seleniumSiteUrl, Is.EqualTo(currentURL));

    }

    [Test]
    public void SeleniumDocumentationComponentGridFieldClicknOnGitHubRepoLink()
    {

        //"//a[@href='/documentation/overview/']"
        var element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//a[@title='Selenium Overview']")));
        var overviewElement = driver.FindElement(By.XPath("//a[@title='Selenium Overview']"));
        overviewElement.Click();
        var componentElement = driver.FindElement(By.XPath("//a[@title='Selenium components']"));
        componentElement.Click();

        var currentUlr = driver.Url;
        Assert.That(currentUlr, Is.EqualTo("https://www.selenium.dev/documentation/overview/components/"));

        var gitHubElement = driver.FindElement(By.XPath("//a[@href='https://github.com/SeleniumHQ/seleniumhq.github.io/commit/6b87463b63700d38146e82130776bf4d832bf82d']"));
        Actions actions = new Actions(driver);
        actions.MoveToElement(gitHubElement);
        actions.Perform();
        gitHubElement.Click();

        var expectedGithubUrl = driver.Url;
        Assert.That(githubUrl, Is.EqualTo(expectedGithubUrl));
    }

    [TearDown]
        public void Cleanup()
        {
            driver.Dispose();
        }
    }