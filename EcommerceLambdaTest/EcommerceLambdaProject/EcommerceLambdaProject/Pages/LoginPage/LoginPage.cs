﻿namespace EcommerceLambdaProject.Pages;

public partial class LoginPage : WebPage
{
    public LoginPage(IDriver driver)
        : base(driver)
    {
    }

    public override string Url => LOGIN_PAGE;

    public void LoginUser(LoginInformation login)
    {
        EmailAddressInput.TypeText(login.EmailAddress);
        PasswordInput.TypeText(login.PasswordField);
        LoginButton.Click();
    }

    public void LogoutUser()
    {
        MyAccountNavigationBarElement.Hover();
        LogoutButton.Click();
    }

    public void ProceedToForgottenPasswordSection()
    {
        ForgotPasswordButton.Click();
    }

    public void SentEmail(string validEmail)
    {
        EmailAddress.TypeText(validEmail);
        ContinueButton.Click();
    }
}