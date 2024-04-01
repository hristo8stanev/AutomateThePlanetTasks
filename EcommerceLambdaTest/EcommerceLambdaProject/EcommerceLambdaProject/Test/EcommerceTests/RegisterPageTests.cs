namespace EcommerceLambdaProject.Test.EcommerceTests;
public class RegisterPageTests : BaseTest
{

    [Test]
    public void RegisterUser_When_ValidCredentialsAreProvided()
    {
        _driver.GoToUrl(Url.REGISTER_PAGE);

        var registerUser = Factories.CustomerFactory.RegisterUser();
        _webSite.RegisterPage.RegisterUer(registerUser);

        _webSite.MyAccountPage.AssertUrlPage(Url.SUCCESSFUL_REGISTRATION_PAGE);
        _webSite.RegisterPage.AssertLogoutButtonIsDisplayed();

    }

    [Test]
    public void RegisterUser_When_FirstNameIsEmpyField()
    {
        _driver.GoToUrl(Url.REGISTER_PAGE);

        var registerUser = Factories.CustomerFactory.RegisterUserWithoutName();
        _webSite.RegisterPage.RegisterUerWithoutName(registerUser);

        _webSite.MyAccountPage.AssertUrlPage(Url.REGISTER_PAGE);
        _webSite.RegisterPage.AssertErrorMessageForErrorMessageFirstName();

    }

    [Test]
    public void RegisterUser_When_EmailAddressIsEmpyField()
    {
        _driver.GoToUrl(Url.REGISTER_PAGE);

        var registerUser = Factories.CustomerFactory.RegisterUserWithoutEmailAddress();
        _webSite.RegisterPage.RegisterUerWithoutEmailAddress(registerUser);

        _webSite.MyAccountPage.AssertUrlPage(Url.REGISTER_PAGE);
        _webSite.RegisterPage.AssertErrorMessageForErrorMessageEmailAddress();

    }

    [Test]
    public void RegisterUser_When_PasswordIsEmpyField()
    {
        _driver.GoToUrl(Url.REGISTER_PAGE);

        var registerUser = Factories.CustomerFactory.RegisterUserWithoutPassword();
        _webSite.RegisterPage.RegisterUerWithoutPassword(registerUser);

        _webSite.MyAccountPage.AssertUrlPage(Url.REGISTER_PAGE);
        _webSite.RegisterPage.AssertErrorMessageForErrorMessagePassword();

    }
}