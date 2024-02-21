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
using AngleSharp.Dom;
using SeleniumWebdriverHelpers;

namespace BlueHostingLogin.Tests.LoginTests;

public class LoginTests : BaseTest
{
    string randomEmail;
    string randomPassword;


   [SetUp]
    public void Setup()
    {
        randomEmail = Internet.UserName() + "@gmail.com";
        randomPassword = Name.FullName() + "S3!#%";
    }


    [Test]
    public void AddCookie()
    {
        _driver.Navigate().GoToUrl("https://www.google.com/");
        _driver.Manage().Cookies.AddCookie(new Cookie("NID", "511=K-wYhVTBO1JmxZQpGBQUZUiAAlnDCXNU9Z7j2D14gNYRjZrirc0TM7QYr27R40yjMIe2Beyg_5t6ib2hwu-zQgV2ArWyhRKLEwchaZgI01pVFXQgxN0ChXZSpgU3JMeusWOobUtRSafwpPYwwB3A5WYvNvr7HUbKi-uZLJjzHJtzBoA9evknaFzmcJYsknx7Ai4"));
        _driver.Manage().Cookies.AddCookie(new Cookie("AEC", "CAISHAgBEhJnd3NfMjAyNDAyMTQtMF9SQzMaAmJnIAEaBgiA-tSuBg"));
        _driver.Manage().Cookies.AddCookie(new Cookie("AEC", "Ae3NU9MWE1FSWzFa2yf3YtINNTDDkqipi0cmsVktAM-xeGZR4Md2vLZVbV0"));
        _driver.Manage().Cookies.AddCookie(new Cookie("NID", "511=j6wH-SnM_AjFBTjZP_ObtSWiN7XNKYHtikg2E_i3rFnLLVuUi472G2nmVWDGicrLnRupDTB-xYiYAY_4BKAwxVTWZVl1QASodJi1-lPCw7MRKywPnSnQ5qhH6Zl01BmNGyReQBwX5RTIoj94RG83nNpKMFdnzsmcUYJljlUDOtacyhOegNpTeWwf6afFqJtFbA"));
        _driver.Manage().Cookies.AddCookie(new Cookie("SOCS", "CAISHAgBEhJnd3NfMjAyNDAyMTQtMF9SQzMaAmJnIAEaBgiA-tSuBg"));
        _driver.Navigate().Refresh();
   
        var element = _driver.FindElement(By.XPath("//*[@data-pid='23']"));
        element.Click();
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