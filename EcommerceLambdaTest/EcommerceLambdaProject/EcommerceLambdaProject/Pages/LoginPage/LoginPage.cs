namespace EcommerceLambdaProject.Pages;

public partial class LoginPage : WebPage
{
    public LoginPage(IDriver driver) : base(driver)
    {
    }

    public void LoginUser(LoginInformation login)
    {
        EmailAddressLogin.TypeText(login.EmailAddress);
        PasswordLogin.TypeText(login.PasswordField);
        LoginButton.Click();
    }

    public void LogoutUser()
    {
        LogoutButton.Click();
    }

    public void GoToForgottenPassword()
    {
        ForgotPasswordButton.Click();
    }

    public void SentEmail(string validEmail)
    {
        EmailAddressFieldForgotPassword.TypeText(validEmail);
        ContinueButton.Click();
    }
}