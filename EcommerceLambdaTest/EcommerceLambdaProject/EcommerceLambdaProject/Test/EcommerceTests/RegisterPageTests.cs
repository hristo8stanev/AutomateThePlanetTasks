namespace EcommerceLambdaProject.Test.EcommerceTests;
public class RegisterPageTests : BaseTest
{


    [Test]
    public void RegisterUserWithValidCredentials()
    {
        _driver.GoToUrl(Url.REGISTER_PAGE);

        var purchaseGift = Factories.CustomerFactory.UserDetails();
        _webSite.RegisterPage.RegisterUer(purchaseGift);


        _webSite.RegisterPage.AssertSuccessfullyRegisterUrlIsShown(_driver.Url);
        _webSite.RegisterPage.AssertLogoutButtonIsDisplayed();

    }
}
