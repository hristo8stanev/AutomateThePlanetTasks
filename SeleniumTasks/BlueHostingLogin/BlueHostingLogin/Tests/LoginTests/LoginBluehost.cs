using Faker;
using BlueHostingLogin.Pages.LambdaTestPage;
using BlueHostingLogin.Pages.BlueHostPage;
using BlueHostingLogin.Tests.Core;

namespace BlueHostingLogin.Tests.LoginTests;

public class LoginTests : BaseTest
{
    string randomEmail;
    string randomPassword;


   [SetUp]
    public void GenerateInfoBeforeTests()
    {
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