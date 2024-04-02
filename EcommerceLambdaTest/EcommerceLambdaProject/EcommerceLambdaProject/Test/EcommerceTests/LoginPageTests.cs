namespace EcommerceLambdaProject.Test.EcommerceTests;

public class LoginPageTests : BaseTest
{
    private string validEmail = "alabala@gmail.com";
    private string invalidEmail = "testtest@gmail.com";
    private string password = "tester";

    [Test]
    public void LoginIntoTheSystem_When_ValidCredentialsAreProvided()
    {
        var loginUser = Factories.CustomerFactory.LoginUser(validEmail, password);

        _driver.GoToUrl(Urls.Urls.LOGIN_PAGE);
        _webSite.LoginPage.LoginUser(loginUser);

        _webSite.LoginPage.AssertUrlPage(Urls.Urls.ACCOUNT_PAGE);
        _webSite.LoginPage.AssertLogoutButtonIsDisplayed();
    }

    [Test]
    public void TryLoginIntoTheSystem_When_InvalidCredentialsAreProvided()
    {
        var loginUser = Factories.CustomerFactory.LoginUser(invalidEmail, password);

        _driver.GoToUrl(Urls.Urls.LOGIN_PAGE);
        _webSite.LoginPage.LoginUser(loginUser);

        _webSite.LoginPage.AssertUrlPage(Urls.Urls.LOGIN_PAGE);
        _webSite.LoginPage.AssertErrorMessageWithWrongCredentials();
    }

    [Test]
    public void LogoutFromTheSystem_When_ValidCredentialsAreProvided()
    {
        var loginUser = Factories.CustomerFactory.LoginUser(validEmail, password);

        _driver.GoToUrl(Urls.Urls.LOGIN_PAGE);
        _webSite.LoginPage.LoginUser(loginUser);

        _webSite.LoginPage.AssertUrlPage(Urls.Urls.ACCOUNT_PAGE);

        _webSite.LoginPage.LogoutUser();
        _webSite.LoginPage.AssertUrlPage(Urls.Urls.LOGOUT_USER_PAGE);
        _webSite.LoginPage.AssertAccountSuccessfullyLogout();
    }

    [Test]
    public void TryToForgottenPasswordFunctionality_When_ValidEmailProvided()
    {
        _driver.GoToUrl(Urls.Urls.LOGIN_PAGE);
        _webSite.LoginPage.GoToForgottenPassword();
        _webSite.LoginPage.AssertUrlPage(Urls.Urls.FORGOTTEN_PASSWORD_PAGE);

        _webSite.LoginPage.SentEmail(validEmail);

        _webSite.LoginPage.AssertSuccessfullySentEmail();
        _webSite.LoginPage.AssertUrlPage(Urls.Urls.LOGIN_PAGE);
    }

    [Test]
    public void TryToForgottenPasswordFunctionality_When_InvalidEmailProvided()
    {
        _driver.GoToUrl(Urls.Urls.LOGIN_PAGE);
        _webSite.LoginPage.GoToForgottenPassword();
        _webSite.LoginPage.AssertUrlPage(Urls.Urls.FORGOTTEN_PASSWORD_PAGE);

        _webSite.LoginPage.SentEmail(invalidEmail);

        _webSite.LoginPage.AssertWarningMessageInvalidEmail();
        _webSite.LoginPage.AssertUrlPage(Urls.Urls.FORGOTTEN_PASSWORD_PAGE);
    }
}