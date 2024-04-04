namespace EcommerceLambdaProject.Test.EcommerceTests;

public class LoginPageTests : BaseTest
{
   
    [Test]
    public void LoginIntoSystem_When_ValidEmailAddressAndPasswordProvided_And_LoginButtonClicked()
    {
        var loginUser = CustomerFactory.LoginUser(Constants.Constants.EmailAddress, Constants.Constants.Password);

        _webSite.LoginPage.Navigate();
        _webSite.LoginPage.LoginUser(loginUser);

        _webSite.LoginPage.AssertUrlPage(Urls.Urls.ACCOUNT_PAGE);
        _webSite.LoginPage.AssertLogoutButtonDisplayed();
    }

    [Test]
    public void LoginIntoSystem_When_InvalidEmailAddress_And_LoginButtonClicked()
    {
        var loginUser = CustomerFactory.LoginUser(Constants.Constants.InvalidEmail, Constants.Constants.Password);

        _webSite.LoginPage.Navigate();
        _webSite.LoginPage.LoginUser(loginUser);

        _webSite.LoginPage.AssertUrlPage(Urls.Urls.LOGIN_PAGE);
        _webSite.LoginPage.AssertErrorMessageWithWrongCredentials();
    }

    [Test]
    public void LoginIntoSystem_When_EmptyCredentials_And_LoginButtonClicked()
    {
        var loginUser = CustomerFactory.LoginUser(email:string.Empty, password:string.Empty);

        _webSite.LoginPage.Navigate();
        _webSite.LoginPage.LoginUser(loginUser);

        _webSite.LoginPage.AssertUrlPage(Urls.Urls.LOGIN_PAGE);
        _webSite.LoginPage.AssertErrorMessageWithWrongCredentials();
    }

    [Test]
    public void LogoutFromTheSystem_When_LogoutButtonClicked()
    {
        var loginUser = CustomerFactory.LoginUser(Constants.Constants.EmailAddress, Constants.Constants.Password);

        _webSite.LoginPage.Navigate();
        _webSite.LoginPage.LoginUser(loginUser);

        _webSite.LoginPage.AssertUrlPage(Urls.Urls.ACCOUNT_PAGE);

        _webSite.LoginPage.LogoutUser();
        _webSite.LoginPage.AssertUrlPage(Urls.Urls.LOGOUT_USER_PAGE);
        _webSite.LoginPage.AssertAccountSuccessfullyLogout();
    }

    [Test]
    public void ForgotPassword_When_ValidEmailAddressProvided_And_ContinueButtonClicked()
    {
        _webSite.LoginPage.Navigate();
        _webSite.LoginPage.ProceedToForgottenPasswordSection();
        _webSite.LoginPage.AssertUrlPage(Urls.Urls.FORGOTTEN_PASSWORD_PAGE);

        _webSite.LoginPage.SentEmail(Constants.Constants.EmailAddress);

        _webSite.LoginPage.AssertSuccessfullySentEmail();
        _webSite.LoginPage.AssertUrlPage(Urls.Urls.LOGIN_PAGE);
    }

    [Test]
    public void ForgotPassword_When_InvalidEmailAddressProvided_And_ContinueButtonIsClicked()
    {
        _webSite.LoginPage.Navigate();
        _webSite.LoginPage.ProceedToForgottenPasswordSection();
        _webSite.LoginPage.AssertUrlPage(Urls.Urls.FORGOTTEN_PASSWORD_PAGE);

        _webSite.LoginPage.SentEmail(Constants.Constants.InvalidEmail);

        _webSite.LoginPage.AssertWarningMessageInvalidEmail();
        _webSite.LoginPage.AssertUrlPage(Urls.Urls.FORGOTTEN_PASSWORD_PAGE);
    }
}