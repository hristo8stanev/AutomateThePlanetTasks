namespace EcommerceLambdaProject.Test.EcommerceTests;

public class LoginPageTests : BaseTest
{
   
    [Test]
    public void LoginIntoSystem_When_ValidEmailAddressAndPasswordProvided_And_LoginButtonClicked()
    {
        var loginUser = CustomerFactory.LoginUser(EmailAddress, Password);

        _webSite.LoginPage.Navigate();
        _webSite.LoginPage.LoginUser(loginUser);

        _webSite.MyAccountPage.AssertUrlPage();
        _webSite.LoginPage.AssertLogoutButtonDisplayed();
    }

    [Test]
    public void LoginIntoSystem_When_InvalidEmailAddress_And_LoginButtonClicked()
    {
        var loginUser = CustomerFactory.LoginUser(InvalidEmail, Password);

        _webSite.LoginPage.Navigate();
        _webSite.LoginPage.LoginUser(loginUser);

        _webSite.LoginPage.AssertUrlPage();
        _webSite.LoginPage.AssertErrorMessageWithWrongCredentials();
    }

    [Test]
    public void LoginIntoSystem_When_EmptyCredentials_And_LoginButtonClicked()
    {
        var loginUser = CustomerFactory.LoginUser(email:string.Empty, password:string.Empty);

        _webSite.LoginPage.Navigate();
        _webSite.LoginPage.LoginUser(loginUser);

        _webSite.LoginPage.AssertUrlPage();
        _webSite.LoginPage.AssertErrorMessageWithWrongCredentials();
    }

    [Test]
    public void LogoutFromTheSystem_When_LogoutButtonClicked()
    {
        var loginUser = CustomerFactory.LoginUser(EmailAddress, Password);

        _webSite.LoginPage.Navigate();
        _webSite.LoginPage.LoginUser(loginUser);

        _webSite.MyAccountPage.AssertUrlPage();

        _webSite.LoginPage.LogoutUser();
        _webSite.LogoutPage.AssertUrlPage();
        _webSite.LoginPage.AssertAccountSuccessfullyLogout();
    }

    [Test]
    public void ForgotPassword_When_ValidEmailAddressProvided_And_ContinueButtonClicked()
    {
        _webSite.LoginPage.Navigate();
        _webSite.LoginPage.ProceedToForgottenPasswordSection();

        _webSite.ForgotPasswordPage.AssertUrlPage();

        _webSite.LoginPage.SentEmail(EmailAddress);

        _webSite.LoginPage.AssertSuccessfullySentEmail();
        _webSite.LoginPage.AssertUrlPage();
    }

    [Test]
    public void ForgotPassword_When_InvalidEmailAddressProvided_And_ContinueButtonIsClicked()
    {
        _webSite.LoginPage.Navigate();
        _webSite.LoginPage.ProceedToForgottenPasswordSection();

        _webSite.ForgotPasswordPage.AssertUrlPage();

        _webSite.LoginPage.SentEmail(InvalidEmail);

        _webSite.LoginPage.AssertWarningMessageInvalidEmail();
        _webSite.ForgotPasswordPage.AssertUrlPage();
    }
}