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

        _webSite.LoginPage.AssertUrlPage(Url.ACCOUNT_PAGE);
        _webSite.LoginPage.AssertLogoutButtonIsDisplayed();
    }

    [Test]
    public void TryLoginIntoTheSystem_When_InvalidCredentialsAreProvided()
    {
        var loginUser = Factories.CustomerFactory.LoginUser(invalidEmail, password);

        _driver.GoToUrl(Url.LOGIN_PAGE);
        _webSite.LoginPage.LoginUser(loginUser);

        _webSite.LoginPage.AssertUrlPage(Url.LOGIN_PAGE);
        _webSite.LoginPage.AssertErrorMessageWithWrongCreedntials();
    }

    [Test]
    public void LogoutFromTheSystem_When_ValidCredentialsAreProvided()
    {
        var loginUser = Factories.CustomerFactory.LoginUser(validEmail, password);

        _driver.GoToUrl(Url.LOGIN_PAGE);
        _webSite.LoginPage.LoginUser(loginUser);

        _webSite.LoginPage.AssertUrlPage(Url.ACCOUNT_PAGE);

        _webSite.LoginPage.LogoutUser();
        _webSite.LoginPage.AssertUrlPage(Url.LOGOUT_USER_PAGE);
        _webSite.LoginPage.AssertAccountSuccessfullyLogout();
    }

    [Test]
    public void TryToForgottenPasswordFunctionality_When_ValidEmailProvided()
    {
        _driver.GoToUrl(Url.LOGIN_PAGE);
        _webSite.LoginPage.GoToForgottenPassword();
        _webSite.LoginPage.AssertUrlPage(Url.FORGOTTEN_PASSWORD_PAGE);

        _webSite.LoginPage.SentEmail(validEmail);

        _webSite.LoginPage.AssertSuccessfullySentEmail();
        _webSite.LoginPage.AssertUrlPage(Url.LOGIN_PAGE);
    }

    [Test]
    public void TryToForgottenPasswordFunctionality_When_InvalidEmailProvided()
    {
        _driver.GoToUrl(Url.LOGIN_PAGE);
        _webSite.LoginPage.GoToForgottenPassword();
        _webSite.LoginPage.AssertUrlPage(Url.FORGOTTEN_PASSWORD_PAGE);

        _webSite.LoginPage.SentEmail(invalidEmail);

        _webSite.LoginPage.AssertWarningMessageInvalidEmail();
        _webSite.LoginPage.AssertUrlPage(Url.FORGOTTEN_PASSWORD_PAGE);
    }

}