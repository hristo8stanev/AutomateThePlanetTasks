using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
using WebDriverManager;

namespace BlueHostingLogin;

public class Tests
{
    private IWebDriver driver;
    private WebDriverWait wait; 

    [SetUp]
    public void Setup()
    {
        new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    [Test]
    public void Try_ToLog_When_IncorrectEmailInputEntered()
    {
        driver.Navigate().GoToUrl("https://login.bluehost.com/hosting/webmail");
        var webMailLogin = driver.FindElement(By.XPath("//div[@id='mat-tab-label-0-1']"));
        webMailLogin.Click();

        var emailField = driver.FindElement(By.Id("emailId"));
        emailField.SendKeys("test@gmail.com");

        var loginButton = driver.FindElement(By.XPath("//button[@type='submit'][1]"));
        loginButton.Click();

        var nextButton = driver.FindElement(By.XPath("//div//span[text()='Next']"));
        nextButton.Click();

        bool isDisplayed = driver.FindElement(By.XPath("//div[text()='Couldn’t find your Google Account']")).Displayed;
        Assert.That(isDisplayed);
    }
    [Test]
    public void Try_ToRegister_When_ValidDataProvided_LambdaTestAccount()
    {
        driver.Navigate().GoToUrl("https://accounts.lambdatest.com/register");
        var lambdaTestUsername = driver.FindElement(By.Id("email"));
        lambdaTestUsername.SendKeys("lambaTes2123ter@gmail.com");

        var lambdaTestPassword = driver.FindElement(By.Id("userpassword"));
        lambdaTestPassword.SendKeys("aasdaad123!@");

        var lambdaTestSignIn = driver.FindElement(By.XPath("//button[@type='submit']"));
        lambdaTestSignIn.Click();

        var verifyButtonDisplayed = driver.FindElement(By.XPath("//button[text()='Verify']"));
        verifyButtonDisplayed.Click();
    }

    [TearDown]
    public void Cleanup()
    {
        driver.Dispose();
    }
}