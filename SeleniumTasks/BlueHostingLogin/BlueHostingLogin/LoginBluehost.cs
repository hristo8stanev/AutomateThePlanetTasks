using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
using WebDriverManager;
using SeleniumExtras.WaitHelpers;
using static BlueHostingLogin.BrowserType;
using OpenQA.Selenium.Edge;

namespace BlueHostingLogin;

public class Tests
{
    private IWebDriver driver;
    private WebDriverWait wait;
    private string successfullyLoginUrl = "https://accounts.lambdatest.com/email/verify";

    [SetUp]
    public void Setup()
    {
        new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
        driver = BrowserManager.StartBrowser(BrowserType.CHROME);
        driver.Manage().Window.Maximize();
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

    }


    [Test]
    public void Try_ToLog_When_IncorrectEmailInputEntered()

    {
        driver.Navigate().GoToUrl("https://www.bluehost.com/my-account/login");
        var webMailLogin = driver.FindElement(By.XPath("//div[@id='mat-tab-label-0-1']"));
        webMailLogin.Click();

        var emailField = driver.FindElement(By.Id("emailId"));
        emailField.SendKeys("test@gmail.com");

        var loginButton = driver.FindElement(By.XPath("//button[@type='submit'][1]"));
        loginButton.Click();

        var verifyNextButton = wait.Until((ExpectedConditions.ElementIsVisible(By.XPath("//div//span[text()='Next']"))));
        var nextButton = driver.FindElement(By.XPath("//div//span[text()='Next']"));
        nextButton.Click();

        var errorMessageWait = wait.Until((ExpectedConditions.ElementIsVisible(By.XPath("//div[text()='Couldn’t find your Google Account']"))));
        bool isDisplayed = driver.FindElement(By.XPath("//div[text()='Couldn’t find your Google Account']")).Displayed;

        Assert.That(isDisplayed);
    }

    [Test]
    public void Try_ToRegister_When_ValidDataProvided_LambdaTestAccount()
    {
        driver.Navigate().GoToUrl("https://accounts.lambdatest.com/register");
        var lambdaTestUsername = driver.FindElement(By.Id("email"));
        lambdaTestUsername.SendKeys("goshoSasho@gmail.com");

        var lambdaTestPassword = driver.FindElement(By.Id("userpassword"));
        lambdaTestPassword.SendKeys("aasdaad123!@");

        var lambdaTestSignIn = driver.FindElement(By.XPath("//button[@type='submit']"));
        lambdaTestSignIn.Click();

        var verifyWait = wait.Until((ExpectedConditions.ElementIsVisible(By.XPath("//button[text()='Verify']"))));
        var verifyButtonDisplayed = driver.FindElement(By.XPath("//button[text()='Verify']"));
        verifyButtonDisplayed.Click();
        bool isVerifyDisplayed = driver.FindElement(By.XPath("//button[text()='Verify']")).Displayed;

        Assert.That(isVerifyDisplayed);
        Assert.That(successfullyLoginUrl, Is.EqualTo(driver.Url));
    }

    [TearDown]
    public void Cleanup()
    {

        driver.Dispose();
    }
}