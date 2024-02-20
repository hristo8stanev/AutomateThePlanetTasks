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
using BlueHostingLogin.Tests.Core;

namespace BlueHostingLogin.Tests.LoginTests;

public class LoginTests : BaseTest
{
    //Cookie cookie = new Cookie("key", "value");
    string randomEmail;
    string randomPassword;

    [SetUp]
    public void Setup()
    {
        // _driver.Manage().Cookies.AllCookies();
        randomEmail = Internet.UserName() + "@gmail.com";
        randomPassword = Name.FullName() + "S3!#%";
    }

   
    [Test]
    public void Try_ToLogin_When_IncorrectEmailInputEntered()
    {
        var purchaseInfoBlueHost = new FillingInfo()
        {
            EmailAdress = randomEmail,
        };
        _blueHostMainPage.GoTo();
        _blueHostMainPage.AcceptCookies();
        _blueHostMainPage.ClickOnWemailLogin();
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