namespace EcommerceLambdaProject.Test.EcommerceTests;
public class LoginPageTests : BaseTest
{
    string emailAddress = "alabala@gmail.com";
    string password = "tester";

    [Test]
    public void LoginPage()
    {
        var loginUser = Factories.CustomerFactory.LoginUser(emailAddress, password);

        _driver.GoToUrl(Url.LOGIN_PAGE);
        _webSite.LoginPage.LoginUser(loginUser);

        _webSite.LoginPage.AssertSuccessfullyLoginUrlIsShown(_driver.Url);
        _webSite.LoginPage.AssertLogoutButtonIsDisplayed();

        _webSite.LoginPage.LogoutButton.Click();

    }
}
