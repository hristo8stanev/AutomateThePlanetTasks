namespace EcommerceLambdaProject.Test.EcommerceTests;
public class LoginPageTests : BaseTest
{
    string validEmail = "alabala@gmail.com";
    string invalidEmail = "testtest@gmail.com";
    string password = "tester";

    [Test]
    public void LoginIntoTheSystem_When_ValidCredentialsAreProvided()
    {
        var loginUser = Factories.CustomerFactory.LoginUser(validEmail, password);

        _driver.GoToUrl(Url.LOGIN_PAGE);
        _webSite.LoginPage.LoginUser(loginUser);

        _webSite.LoginPage.AssertSuccessfullyLoginUrlIsShown(_driver.Url);
        _webSite.LoginPage.AssertLogoutButtonIsDisplayed();

        _webSite.LoginPage.LogoutButton.Click();
    }

    [Test]
    public void TryToForgottenPasswordFunctionality_When_ValidEmailProvided()
    {
        _driver.GoToUrl(Url.LOGIN_PAGE);
        _webSite.LoginPage.GoToForgottenPassword();
        _webSite.LoginPage.AssertSuccessfullyForgottenPasswordUrlIsShown(_driver.Url);

        _webSite.LoginPage.SentEmail(validEmail);
        _webSite.LoginPage.AssertSuccessfullySentEmail();
        _webSite.LoginPage.AssertLoginUrlIsShown(_driver.Url);

    }

    [Test]
    public void TryToForgottenPasswordFunctionality_When_InvalidEmailProvided()
    {
        _driver.GoToUrl(Url.LOGIN_PAGE);
        _webSite.LoginPage.GoToForgottenPassword();
        _webSite.LoginPage.AssertSuccessfullyForgottenPasswordUrlIsShown(_driver.Url);

        _webSite.LoginPage.SentEmail(invalidEmail);
        _webSite.LoginPage.AssertWarningMessageInvalidEmail();
        _webSite.LoginPage.AssertSuccessfullyForgottenPasswordUrlIsShown(_driver.Url);

    }
}