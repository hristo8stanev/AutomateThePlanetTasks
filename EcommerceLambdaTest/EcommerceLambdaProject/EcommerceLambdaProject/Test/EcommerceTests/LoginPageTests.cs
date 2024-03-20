

namespace EcommerceLambdaProject.Test.EcommerceTests;
public class LoginPageTests : BaseTest
{


    [Test]
    public void LoginPage()
    {
        _driver.GoToUrl(Url.LOGIN_PAGE);
    }

}
