namespace EcommerceLambdaProject.Test.EcommerceTests;
public class RegisterPageTests : BaseTest
{


    [Test]
    public void RegisterUserWithValidCredentials()
    {
        _driver.GoToUrl(Url.REGISTER_PAGE);

        var registerUser = Factories.CustomerFactory.UserDetails();
        _webSite.RegisterPage.RegisterUer(registerUser);


        _webSite.RegisterPage.AssertSuccessfullyRegisterUrlIsShown(_driver.Url);
        _webSite.RegisterPage.AssertLogoutButtonIsDisplayed();

    }
}
