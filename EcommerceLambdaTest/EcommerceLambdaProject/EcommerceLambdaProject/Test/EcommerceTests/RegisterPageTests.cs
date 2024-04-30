namespace EcommerceLambdaProject.Test.EcommerceTests;

public class RegisterPageTests : BaseTest
{
    [Test]
    public void RegisterUser_When_ValidCredentialsProvided_And_ContinueButtonClicked()
    {
        _webSite.RegisterPage.Navigate();

        var registerUser = CustomerFactory.GenerateUserDetails();
        _webSite.RegisterPage.CreateUser(registerUser);

        _webSite.MyAccountPage.AssertUrlPage(SUCCESSFUL_REGISTRATION_PAGE);
        _webSite.RegisterPage.AssertLogoutButtonIsDisplayed();
    }

    [Test]
    public void RegisterUser_When_EmptyFirstNameField_And_ContinueButtonIsClicked()
    {
        _webSite.RegisterPage.Navigate();

        var registerUser = CustomerFactory.GenerateUserDetails(firstName: string.Empty);
        _webSite.RegisterPage.CreateUser(registerUser);

        _webSite.MyAccountPage.AssertUrlPage(REGISTER_PAGE);
        _webSite.RegisterPage.AssertErrorMessageForErrorMessageFirstName();
    }

    [Test]
    public void RegisterUser_When_EmptyEmailAddressField_And_ContinueButtonClicked()
    {
        _webSite.RegisterPage.Navigate();

        var registerUser = CustomerFactory.GenerateUserDetails(email: string.Empty);
        _webSite.RegisterPage.CreateUser(registerUser);

        _webSite.MyAccountPage.AssertUrlPage(REGISTER_PAGE);
        _webSite.RegisterPage.AssertErrorMessageForErrorMessageEmailAddress();
    }

    [Test]
    public void RegisterUser_When_EmptyPasswordField_And_ContinueButtonClicked()
    {
        _webSite.RegisterPage.Navigate();

        var registerUser = CustomerFactory.GenerateUserDetails(password: string.Empty);
        _webSite.RegisterPage.CreateUser(registerUser);

        _webSite.MyAccountPage.AssertUrlPage(REGISTER_PAGE);
        _webSite.RegisterPage.AssertErrorMessageForErrorMessagePassword();
    }
}