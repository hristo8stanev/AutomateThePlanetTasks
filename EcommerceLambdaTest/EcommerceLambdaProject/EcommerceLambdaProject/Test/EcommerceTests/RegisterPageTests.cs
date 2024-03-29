namespace EcommerceLambdaProject.Test.EcommerceTests;
public class RegisterPageTests : BaseTest
{

    [Test]
    public void RegisterUserWithValidCredentials()
    {
        _driver.GoToUrl(Url.REGISTER_PAGE);

        var purchaseGift = Factories.CustomerFactory.RegisterUser();
        _webSite.RegisterPage.RegisterUer(purchaseGift);


        _webSite.MyAccountPage.AssertUrlPage(Url.SUCCESSFUL_REGISTRATION_PAGE);
        _webSite.RegisterPage.AssertLogoutButtonIsDisplayed();

    }
}