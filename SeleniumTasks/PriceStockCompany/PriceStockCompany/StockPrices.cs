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

namespace PriceStockCompany;

public class StockPrices
{
    private string errorMessageUrl => "The URL does not contain 'historical-data'";

    private int WAIT_FOR_ELEMEN => 30;
    private IWebDriver driver;
    private WebDriverWait wait;
    string companyName;

[SetUp]
    public void Setup()
    {
        new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
        driver = BrowserManager.StartBrowser(BrowserType.EDGE);
        driver.Manage().Window.Maximize();
        driver.Navigate().GoToUrl("https://www.investing.com/");
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(WAIT_FOR_ELEMEN));
        companyName = "Tesla";
    }

    [Test]
    public void CompanyHistoryStocksPricesTest()
    {
        var stockButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("onetrust-accept-btn-handler")));
        var concentAcceptButton = driver.FindElement(By.Id("onetrust-accept-btn-handler"));
        concentAcceptButton.Click();

        var searchBox = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@data-test='search-section']")));
        searchBox.SendKeys(companyName);

        var searchBoxWait = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@data-test='search-section']")));
        searchBoxWait.Click();

        var clickOnCompany = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//li[contains(@class ,'list_list__item__dwS6E mainSearch_search-results-item-wrapper__NUG7e')][1]")));
        clickOnCompany.Click();

        var historicData = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//li[@data-test='Historical Data']")));
        historicData.Click();

        var priceWait = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='flex flex-wrap gap-x-4 gap-y-2 items-center md:gap-6 mb-3 md:mb-0.5']")));
        var price = driver.FindElement(By.XPath("//div[@class='flex flex-wrap gap-x-4 gap-y-2 items-center md:gap-6 mb-3 md:mb-0.5']"));
        var priceText = price.Text;

        Console.WriteLine(priceText);

        string currentUrl = driver.Url;
        Assert.That(currentUrl.Contains("historical-data"), Is.True, errorMessageUrl);
    }

    [TearDown]
    public void Cleanup()
    {

        driver.Dispose();
    }
}