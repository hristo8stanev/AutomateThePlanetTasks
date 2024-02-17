using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;
using WebDriverManager;
using SeleniumExtras.WaitHelpers;
using System.Diagnostics;
using Faker;
using Faker.Extensions;
using BlueHostingLogin.@enum;
using BlueHostingLogin.Pages.LambdaTestPage;
using System.Net.Mail;
using BlueHostingLogin.Pages.BlueHostPage;

namespace BlueHostingLogin;

public class Tests
{
    private IWebDriver _driver;
    LambdaMainPage _lambdaMainPage;
    BlueHostMainPage _blueHostMainPage;
    //Cookie cookie = new Cookie("key", "value");
    string randomEmail;
    string randomPassword;

    [SetUp]
    public void Setup()
    {
        new DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
        _driver = DriverFacade.DriverFacade.StartBrowser(BrowserType.CHROME);
        _driver.Manage().Window.Maximize();
        _lambdaMainPage = new LambdaMainPage(_driver);
        _blueHostMainPage = new BlueHostMainPage(_driver);
       // _driver.Manage().Cookies.AllCookies();
        randomEmail = Internet.UserName() + "@gmail.com";
        randomPassword = Faker.Name.FullName() + "S3!#%";
    }

    [TearDown]
    public void Cleanup()
    {
        _driver.Dispose();
    }

    [Test]
     public void Try_ToLog_When_IncorrectEmailInputEntered()
    
     {

        _blueHostMainPage.GoTo();
        _blueHostMainPage.AcceptCookies();
        _blueHostMainPage.ClickOnWemailLogin();
        var purchaseInfoBlueHost = new FillingInfo()
        {
            EmailAdress = randomEmail,

        };

        _blueHostMainPage.FillEmail(purchaseInfoBlueHost);
        _blueHostMainPage.ProceedWithLogin();
        _blueHostMainPage.AssertVerifyButtonIsDisplayed();

    }

    [Test]
    public void Try_ToRegister_When_ValidDataProvided_LambdaTestAccount()
    {
        _lambdaMainPage.GoTo();
        var purchaseInfo = new PurchaseInfo()
        {
            EmailAdress = randomEmail,
            Password = randomPassword
        };

        _lambdaMainPage.FillBillingInfo(purchaseInfo);
        _lambdaMainPage.ProceedToUserLogin();
        _lambdaMainPage.AssertUserSuccssesfullyLoginUrl(_driver.Url);
        _lambdaMainPage.AssertSentEmailToVerify(randomEmail);

    }
}