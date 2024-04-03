namespace EcommerceLambdaProject.Test.EcommerceTests;

public class RegisterPageTests : BaseTest
{
    [Test]
    public void RegisterUser_When_ValidCredentialsAreProvided()
    {
        _driver.GoToUrl(Urls.Urls.REGISTER_PAGE);

        var registerUser = CustomerFactory.RegisterUser();
        _webSite.RegisterPage.RegisterUser(registerUser);

        _webSite.MyAccountPage.AssertUrlPage(Urls.Urls.SUCCESSFUL_REGISTRATION_PAGE);
        _webSite.RegisterPage.AssertLogoutButtonIsDisplayed();
    }

    [Test]
    public void RegisterUser_When_FirstNameIsEmptyField()
    {
        _driver.GoToUrl(Urls.Urls.REGISTER_PAGE);

        var registerUser = CustomerFactory.RegisterUser(firstName: string.Empty);
        _webSite.RegisterPage.RegisterUser(registerUser);

        _webSite.MyAccountPage.AssertUrlPage(Urls.Urls.REGISTER_PAGE);
        _webSite.RegisterPage.AssertErrorMessageForErrorMessageFirstName();
    }

    [Test]
    public void RegisterUser_When_EmailAddressIsEmptyField()
    {
        _driver.GoToUrl(Urls.Urls.REGISTER_PAGE);

        var registerUser = CustomerFactory.RegisterUser(email: string.Empty);
        _webSite.RegisterPage.RegisterUser(registerUser);

        _webSite.MyAccountPage.AssertUrlPage(Urls.Urls.REGISTER_PAGE);
        _webSite.RegisterPage.AssertErrorMessageForErrorMessageEmailAddress();
    }

    [Test]
    public void RegisterUser_When_PasswordIsEmptyField()
    {
        _driver.GoToUrl(Urls.Urls.REGISTER_PAGE);

        var registerUser = CustomerFactory.RegisterUser(password: string.Empty);
        _webSite.RegisterPage.RegisterUser(registerUser);

        _webSite.MyAccountPage.AssertUrlPage(Urls.Urls.REGISTER_PAGE);
        _webSite.RegisterPage.AssertErrorMessageForErrorMessagePassword();
    }
}