﻿namespace EcommerceLambdaProject.Test.EcommerceTests;

public class RegisterPageTests : BaseTest
{
    [Test]
    public void RegisterUser_When_ValidCredentialsProvided_And_ContinueButtonClicked()
    {
        _webSite.RegisterPage.Navigate();

        var registerUser = CustomerFactory.FillUserPersonalInformation();
        _webSite.RegisterPage.RegisterUser(registerUser);

        _webSite.MyAccountPage.AssertUrlPage(Urls.Urls.SUCCESSFUL_REGISTRATION_PAGE);
        _webSite.RegisterPage.AssertLogoutButtonIsDisplayed();
    }

    [Test]
    public void RegisterUser_When_EmptyFirstNameField_And_ContinueButtonIsClicked()
    {
        _webSite.RegisterPage.Navigate();

        var registerUser = CustomerFactory.FillUserPersonalInformation(firstName: string.Empty);
        _webSite.RegisterPage.RegisterUser(registerUser);

        _webSite.MyAccountPage.AssertUrlPage(Urls.Urls.REGISTER_PAGE);
        _webSite.RegisterPage.AssertErrorMessageForErrorMessageFirstName();
    }

    [Test]
    public void RegisterUser_When_EmptyEmailAddressField_And_ContinueButtonClicked()
    {
        _webSite.RegisterPage.Navigate();

        var registerUser = CustomerFactory.FillUserPersonalInformation(email: string.Empty);
        _webSite.RegisterPage.RegisterUser(registerUser);

        _webSite.MyAccountPage.AssertUrlPage(Urls.Urls.REGISTER_PAGE);
        _webSite.RegisterPage.AssertErrorMessageForErrorMessageEmailAddress();
    }

    [Test]
    public void RegisterUser_When_EmptyPasswordField_And_ContinueButtonClicked()
    {
        _webSite.RegisterPage.Navigate();

        var registerUser = CustomerFactory.FillUserPersonalInformation(password: string.Empty);
        _webSite.RegisterPage.RegisterUser(registerUser);

        _webSite.MyAccountPage.AssertUrlPage(Urls.Urls.REGISTER_PAGE);
        _webSite.RegisterPage.AssertErrorMessageForErrorMessagePassword();
    }
}